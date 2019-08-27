using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float set_targetTime = 60.0f;
    private float targetTime;
    public bool timerStarted;

    private void Start()
    {
        timerReset();
    }

    void Update()
    {
        if (timerStarted)
        {
            targetTime -= Time.deltaTime;


            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }
    }

    void startTimer()
    {
        timerStarted = true;
    }

    void timerEnded()
    {
        Debug.Log("ended");
        // timer ends, the spawning stops.  When the villagers are all inactive, the turn ends: 
        //Which means we calculate the factors, show them to the player, and save them.  
        //When they press "Continue", the scene reloads and loads the new player prefs, simulating 'a new day'.
    }

    void timerReset()
    {
        targetTime = set_targetTime;
        timerStarted = false;
    }


}
