using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damObj : MonoBehaviour
{

    public bool damOpen = false;

    public void OnMouseDown()
    {
        damOpen = !damOpen;
    }
}
