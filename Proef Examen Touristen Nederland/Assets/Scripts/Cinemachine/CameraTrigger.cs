using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraSwapper CS;
    public string CameraID;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            CS.AssignCameraTrigger(this);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            CS.AssignCameraTrigger();
        }
    }
}
