using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    bool PlayerInRange = false;
    [SerializeField]
    bool InstantActive = false;
    [SerializeField]
    int DoorSceneID;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            PlayerInRange=true;
            if (InstantActive)
            {
                GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().LoadScene(DoorSceneID);
            }
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
            GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().LoadScene(DoorSceneID);
        }
    }
}
