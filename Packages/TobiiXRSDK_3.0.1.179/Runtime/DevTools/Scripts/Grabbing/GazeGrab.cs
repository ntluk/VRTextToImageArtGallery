using System.Collections;
using Tobii.XR;
using UnityEngine;
using UnityEngine.Events;

namespace Tobii.XR.Examples
{
    /// <summary>
    /// Monobehaviour which can be put on the player's controller to allow grabbing a <see cref="GazeGrabbableObject"/> by looking at it and pressing a button on the controller.
    /// </summary>
    public class GazeGrab : MonoBehaviour
    {
        // Action which will be triggered when the object is released from the controller.
        public UnityAction<GameObject> OnObjectReleased;
        public GameObject blackBox0;
        public GameObject blackBox4;
        public GameObject earth;
        public GameObject settingIcon;
        public GameObject bookIcon;
        public GameObject hologramIcon;
        public GameObject gazeVisualizer;
        public GameObject backgroundSound;
        public GameObject starBoundMesh;
        public GameObject dummyStars;
        public GameObject settingMenu;
        public GameObject bookMenu;
        public GameObject hologramMenu;
        public GameObject tutorialMenu;
        public GameObject zodiac;
        public GameObject sun;
        public GameObject moon;
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioSource gravityAudioSource;
        [SerializeField] AudioClip blackBoxSound;
        [SerializeField] AudioClip gravitySound;
        public bool IsObjectGrabbing { get; private set; }
        public bool objectGrabbed = false;
        public bool moonGrabbed = false;
        public bool sunGrabbed = false;

        private enum GrabState
        {
            Idle,
            Grabbing,
            Grabbed
        }

        private GrabState _currentGrabState = GrabState.Idle;

        // Fields to keep track of objects which currently have focus or are grabbed.
        private GazeGrabbableObject _grabbedObject;
        private Rigidbody _grabbedObjectRigidBody;
        private GazeGrabbableObject _focusedGameObject;
        private float _focusedGameObjectTime;
        private float _objectGazeStickinessSeconds;

        // Fields related to animating the object flying to the hand.
        private float _grabAnimationProgress;
        private Vector3 _startPosition;
        private Vector3 _startScale;
        private Quaternion _startRotation;
        private Rigidbody _rigidbody;
        private Quaternion _startControllerRotation;
        private Quaternion _startObjectRotation;
        private float _flyToControllerTimeSeconds;
        private AnimationCurve _animationCurve;
        private Vector3 _moonStartPosition;
        private Vector3 _moonStartScale;
        private Quaternion _moonStartRotation;
        private Rigidbody _moonRigidbody;

        // Multiplier to the velocity when releasing the object from the hand.
        private const float ObjectVelocityMultiplier = 2.0f;

        // Distance at which the object snaps to the controller.
        private const float ObjectSnapDistance = 0.1f;
        private const ControllerButton TriggerButton = ControllerButton.Trigger;

        private void Start()
        {
            _moonStartPosition = moon.transform.position;
            _moonStartRotation = moon.transform.rotation;
            _moonStartScale = moon.transform.localScale;
            _moonRigidbody = moon.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (hologramMenu.GetComponent<Canvas>().enabled == false 
                && !bookMenu.activeInHierarchy
                && !settingMenu.activeInHierarchy
                && !tutorialMenu.activeInHierarchy)
            {
                UpdateFocusedObject();
                UpdateObjectState();
            } 
        }

        private void UpdateObjectState()
        {
            // If the object is the "idle" state, and the user looks at the object and presses the grab button, start moving the object to the controller.
            if (_currentGrabState == GrabState.Idle)
            {
                if (_focusedGameObject != null && ControllerManager.Instance.GetButtonPressDown(TriggerButton))
                {
                    ChangeObjectState(GrabState.Grabbing);
                }
            }

            // The object is in its "grabbing" state, meaning it's moving towards the controller.
            if (_currentGrabState == GrabState.Grabbing)
            {
                // If the grab* button is held, move the object towards the controller using a lerp function.
                if (ControllerManager.Instance.GetButtonPress(TriggerButton))
                {
                    if (sunGrabbed)
                    {
                        _flyToControllerTimeSeconds = 1.0f;
                    }
                    _grabAnimationProgress += Time.deltaTime / _flyToControllerTimeSeconds;
                    _grabbedObjectRigidBody.position = Vector3.Lerp(_startPosition, ControllerManager.Instance.Position,
                        _animationCurve.Evaluate(_grabAnimationProgress));

                    // If the distance between the controller and the object is close enough, grab the object.
                    if (Vector3.Distance(_grabbedObjectRigidBody.position, ControllerManager.Instance.Position) <
                        ObjectSnapDistance)
                    {
                        ChangeObjectState(GrabState.Grabbed);
                    }
                }
                // If the grab button is released, drop the object.
                else if (!ControllerManager.Instance.GetButtonPress(TriggerButton))
                {
                    ChangeObjectState(GrabState.Idle);
                }
            }

            // If the object is currently being grabbed and the grab button is released, apply the controller's velocity to the object and invoke OnObjectReleased.
            if (_currentGrabState == GrabState.Grabbed)
            {
                if (ControllerManager.Instance.GetButtonPress(TriggerButton))
                {
                    // Keeps the object's original rotation as a starting point, and is otherwise locked to the controller
                    _grabbedObjectRigidBody.rotation =
                        (ControllerManager.Instance.Rotation * Quaternion.Inverse(_startControllerRotation)) *
                        _startObjectRotation;
                    _grabbedObjectRigidBody.position = ControllerManager.Instance.Position;
                }
                else
                {
                    _grabbedObjectRigidBody.angularVelocity =
                        ControllerManager.Instance.AngularVelocity * ObjectVelocityMultiplier;
                    _grabbedObjectRigidBody.velocity = ControllerManager.Instance.Velocity * ObjectVelocityMultiplier;

                    if (OnObjectReleased != null)
                    {
                        OnObjectReleased.Invoke(_grabbedObject.gameObject);
                    }

                    ChangeObjectState(GrabState.Idle);
                }
            }
        }

        /// <summary>
        /// Called when the object transitions from one <see cref="GrabState"/> to another.
        /// </summary>
        /// <param name="state">The state the object should transition to.</param>
        private void ChangeObjectState(GrabState state)
        {
            _currentGrabState = state;

            switch (state)
            {
                // Inform the object that it has been ungrabbed and set it to not be kinematic.
                case GrabState.Idle:
                    StopAllCoroutines();
                    IsObjectGrabbing = false;
                    _grabbedObject.ObjectUngrabbed();
                    _grabbedObjectRigidBody.isKinematic = false;

                    //resets the position and size of the grabbed object while grabbing or when moon got grabbed
                    if (!objectGrabbed) 
                    {
                        _grabbedObject.transform.SetPositionAndRotation(_startPosition, _startRotation);
                        _grabbedObject.transform.localScale = _startScale;
                        _rigidbody.velocity = Vector3.zero;
                        _rigidbody.angularVelocity = Vector3.zero;
                        moon.GetComponent<RotateMoon>().enabled = true;
                        moon.GetComponent<SphereCollider>().enabled = true;
                        sun.GetComponent<SphereCollider>().enabled = true;
                    }
                    if (moonGrabbed)
                    {
                        Invoke(nameof(ResetMoonAfterSeconds), 5.0f);
                        objectGrabbed = false;
                    }
                    if (!sunGrabbed)
                    {
                        SetIconActiveStatus(true);
                    }
                    break;
                // When the user starts grabbing the object, save the object and store its animation values.
                case GrabState.Grabbing:
                    IsObjectGrabbing = true;
                    SetIconActiveStatus(false);
                    _grabbedObject = _focusedGameObject;
                    _startPosition = _grabbedObject.transform.position;
                    _startRotation = _grabbedObject.transform.rotation;
                    _startScale = _grabbedObject.transform.localScale;
                    _rigidbody = _grabbedObject.GetComponent<Rigidbody>();
                    _grabbedObject.ObjectGrabbing();
                    _grabbedObjectRigidBody = _focusedGameObject.GetComponent<Rigidbody>();
                    _grabbedObjectRigidBody.isKinematic = true;
                    _startObjectRotation = _grabbedObject.transform.rotation;
                    _startControllerRotation = ControllerManager.Instance.Rotation;
                    _startPosition = _grabbedObject.transform.position;
                    _grabAnimationProgress = 0f;

                    // if the grabbed object is the sun or moon, adjust the size over time
                    if ((_grabbedObject.name == sun.name && !sunGrabbed) || (_grabbedObject.name == moon.name)) 
                    {
                        if (_grabbedObject.name == moon.name)
                        {
                            moon.GetComponent<RotateMoon>().enabled = false;
                            moon.GetComponent<SphereCollider>().enabled = false;
                            _moonStartPosition = _grabbedObject.transform.position;
                            _moonStartRotation = _grabbedObject.transform.rotation;
                            _moonStartScale = _grabbedObject.transform.localScale;
                            _moonRigidbody = _grabbedObject.GetComponent<Rigidbody>();
                        }
                        if (_grabbedObject.name == sun.name)
                        {
                            sun.GetComponent<SphereCollider>().enabled = false;
                        }
                        moon.GetComponent<SphereCollider>().enabled = false;
                        StartCoroutine(ScaleOverTime(_flyToControllerTimeSeconds));
                    }
                    break;
                // When the object becomes grabbed to the controller, call the grabbed method and set the object's position to the hand.
                case GrabState.Grabbed:
                    ControllerManager.Instance.TriggerHapticPulse(0.25f);
                    _grabbedObject.ObjectGrabbed();
                    _grabbedObject.transform.position = ControllerManager.Instance.Position;

                    // if the sun got grabbed, play end sound, activate black box and make the visualizer invisible
                    if (_grabbedObject.name == sun.name && !sunGrabbed) 
                    {
                        earth.GetComponent<SphereCollider>().enabled = true;
                        sun.GetComponent<SphereCollider>().enabled = true;
                        moon.GetComponent<SphereCollider>().enabled = false;
                        SetIconActiveStatus(false);
                        zodiac.GetComponent<ZodiacSwipe>().StartCoroutine("FadeOutBackgroundSound");

                        Invoke(nameof(PlaySound), 4.0f);
                        Invoke(nameof(ActivateBlackBoxOverTime), 5.0f);
                        Invoke(nameof(PlaySound), 7.0f);
                        Invoke(nameof(ActivateBlackBoxOverTime), 8.0f);
                        Invoke(nameof(PlaySound), 10.0f);
                        Invoke(nameof(ActivateBlackBoxOverTime), 11.0f);
                        Invoke(nameof(PlaySound), 13.0f);
                        Invoke(nameof(ActivateBlackBoxOverTime), 14.0f);
                        Invoke(nameof(PlaySound), 23.0f);
                        Invoke(nameof(ActivateBlackBoxOverTime), 24.0f);
                        Invoke(nameof(EndGame), 29.0f);

                        Color tmp = gazeVisualizer.GetComponent<SpriteRenderer>().color;
                        tmp.a = 0f;
                        gazeVisualizer.GetComponent<SpriteRenderer>().color = tmp;
                        sunGrabbed = true;
                    }
                    if (_grabbedObject.name == moon.name)
                    {
                        moonGrabbed = true;
                    }
                    objectGrabbed = true;
                    break;
            }
        }

        // Scales the planets over time
        private IEnumerator ScaleOverTime(float time)
        {
            Vector3 originalScale = _grabbedObject.transform.localScale;
            Vector3 destinationScale = new Vector3(0.22f, 0.22f, 0.22f);
            float currentTime = 0.0f;

            do
            {
                _grabbedObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
                currentTime += Time.deltaTime;
                yield return null;
            } while (currentTime <= time);

            if (_grabbedObject.name == sun.name)
            {
                _grabbedObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }

            StopAllCoroutines();
        }

        //Initialize game ending
        private void ActivateBlackBoxOverTime()
        {
            if (!earth.activeInHierarchy)
            {
                blackBox0.SetActive(true);
                sun.SetActive(false);
            }
            if (!moon.activeInHierarchy)
            {
                earth.SetActive(false);
            }
            if (!starBoundMesh.activeInHierarchy)
            {
                moon.SetActive(false);
            }
            if (blackBox4.activeInHierarchy)
            {
                starBoundMesh.SetActive(false);
            }
            blackBox4.SetActive(true);
            dummyStars.SetActive(false);
        }

        private void PlaySound()
        {
            if ((audioSource != null) && (blackBoxSound != null))
            {
                audioSource.PlayOneShot(blackBoxSound);
            }
        }

        private void PlayGravitySound(bool set)
        {
            if ((gravityAudioSource != null) && (gravitySound != null) && (set)) 
            {
                gravityAudioSource.PlayOneShot(gravitySound);
            }
            else if ((audioSource != null) && (gravitySound != null) && (!set))
            {
                gravityAudioSource.Stop();
            }            
        }

        private void EndGame()
        {
            Application.Quit();
        }

        private void ResetMoonAfterSeconds()
        {
            moon.transform.SetPositionAndRotation(_moonStartPosition, _moonStartRotation);
            moon.transform.localScale = _moonStartScale;
            _moonRigidbody.velocity = Vector3.zero;
            _moonRigidbody.angularVelocity = Vector3.zero;
            moon.GetComponent<RotateMoon>().enabled = true;
            if (settingIcon.activeInHierarchy && bookIcon.activeInHierarchy && hologramIcon.activeInHierarchy)
            {
                moon.GetComponent<SphereCollider>().enabled = true;
            }
            moonGrabbed = false;
        }

        /// <summary>
        /// Updates the currently focused <see cref="GazeGrabbableObject"/> and keeps it focused for the time set by the object, <see cref="GazeGrabbableObject.GazeStickinessSeconds"/>.
        /// </summary>
        private void UpdateFocusedObject()
        {
            // Check whether Tobii XR has any focused objects.
            foreach (var focusedCandidate in TobiiXR.FocusedObjects)
            {
                var focusedObject = focusedCandidate.GameObject;
                // The candidate list is ordered so that the most likely object is first in the list.
                // So let's try to find the first focused object that also has the GazeGrabbableObject component and save it.
                if (focusedObject != null && focusedObject.GetComponent<GazeGrabbableObject>())
                {
                    SetNewFocusedObject(focusedObject);
                    break;
                }
            }

            // If enough time has passed since the object was last focused, mark it as not focused.
            if (Time.time > _focusedGameObjectTime + _objectGazeStickinessSeconds)
            {
                _focusedGameObjectTime = float.NaN;
                _focusedGameObject = null;
                _objectGazeStickinessSeconds = 0f;
            }
        }

        /// <summary>
        /// Store the values attached to focused object.
        /// </summary>
        /// <param name="focusedObject">The new focused object to store.</param>
        private void SetNewFocusedObject(GameObject focusedObject)
        {
            _focusedGameObject = focusedObject.GetComponent<GazeGrabbableObject>();
            _objectGazeStickinessSeconds = _focusedGameObject.GazeStickinessSeconds;
            _animationCurve = _focusedGameObject.AnimationCurve;
            _flyToControllerTimeSeconds = _focusedGameObject.FlyToControllerTimeSeconds;
            _focusedGameObjectTime = Time.time;
        }

        private void SetIconActiveStatus(bool status)
        {
            settingIcon.SetActive(status);
            bookIcon.SetActive(status);
            hologramIcon.SetActive(status);
        }
    }
}
