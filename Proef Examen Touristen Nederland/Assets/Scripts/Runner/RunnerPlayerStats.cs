using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayerStats : MonoBehaviour
{
    [SerializeField]
    float ScoreMult = 1;
    [SerializeField]
    int Score = 0;

    private void Start()
    {
        InvokeRepeating("ContinuousScore", 0, 5);
    }

    private void Update()
    {

    }


    void ContinuousScore()
    {
        Score += Mathf.RoundToInt(100*ScoreMult);
    }

    public void TruckCrash()
    {
        //Make sure that the score multiplier never goes below 0.5
        ScoreMult = ((ScoreMult - 0.15f) >= 0.5f) ? ScoreMult - 0.15f : 0.5f;
    }
}
