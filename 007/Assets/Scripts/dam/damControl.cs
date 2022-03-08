using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damControl : MonoBehaviour
{

    public GameObject[] theDams;
    public damObj[] theDamScripts;
    public GameObject waterLevelObj;

    public float waterLevel;
    public float countDown;

    void Start()
    {
        waterLevel = 0f;
        countDown = 30f;
    }

    void Update()
    {
        if (theDamScripts[0].damOpen == true)
        {
            waterLevel += 1f * Time.deltaTime;
        }
        if (theDamScripts[1].damOpen == true)
        {
            waterLevel += 1f * Time.deltaTime;
        }
        if (theDamScripts[2].damOpen == true)
        {
            waterLevel += 1f * Time.deltaTime;
        }
        waterLevel -= 1.5f * Time.deltaTime;

        waterLevelObj.transform.position = new Vector3(25, waterLevel, 22);

        if (waterLevel <= -3 || waterLevel >= 3)
            GameOver();

        if (countDown <= 0)
            GameWon();
        else
            countDown -= 1f * Time.deltaTime;

    }

    public void GameOver()
    {
        Debug.Log("Game over");
    }

    public void GameWon()
    {
        Debug.Log("Game Won");
    }

}
