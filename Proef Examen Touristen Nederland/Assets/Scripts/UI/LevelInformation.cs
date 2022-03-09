using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInformation : MonoBehaviour
{
    [SerializeField]
    GameObject Info_UI;
    [SerializeField]
    TextMeshProUGUI Text_UI;
    [SerializeField]
    string Info_txt;
    bool inRange = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&inRange)
        {
            Info_UI.gameObject.SetActive(true);
            Text_UI.text = Info_txt;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            inRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (Info_UI.gameObject.active)
            {
                inRange = false;
                Info_UI.gameObject.SetActive(false);
            }
        }
    }
}
