using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HowFullIsCup : MonoBehaviour
{
    // when entered add to array
    public int volume = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        volume = volume + 1;
    }
}
