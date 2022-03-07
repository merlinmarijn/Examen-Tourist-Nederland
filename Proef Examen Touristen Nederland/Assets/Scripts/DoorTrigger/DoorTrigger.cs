using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    bool PlayerInRange = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerInRange=true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerInRange = false;
        }
    }

    private void Update()
    {
        if (PlayerInRange&&Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Entered Door");
        }
    }
}
