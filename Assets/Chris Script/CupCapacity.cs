using System;
using UnityEngine;

public class CupCapacity : MonoBehaviour
{
    public HowFullIsCup cupCapacity;
    public bool canServe = false;

    private void Update()
    {
        if (cupCapacity.volume > 25)
        {
            canServe = true;
        }
    }

    public void ServeCup()
    {
        Destroy(GameObject.FindGameObjectWithTag("Bubble"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
