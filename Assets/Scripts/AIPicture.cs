using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPicture : MonoBehaviour
{
    Material artwork;
    string title;
    
    AIPicture(Material art, string title) {
        this.artwork = art;
        this.title = title;
    }
}
