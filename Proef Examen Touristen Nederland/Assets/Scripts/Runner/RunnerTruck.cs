using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerTruck : MonoBehaviour
{
    float movespeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * movespeed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<RunnerPlayerStats>().TruckCrash();
        }
    }
}
