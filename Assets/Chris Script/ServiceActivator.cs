using System;
using Unity.VisualScripting;
using UnityEngine;

public class ServiceActivator : MonoBehaviour
{
    public GameObject serviceCamera;
    public GameObject serviceCanvas;
    
    private PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerMovement = other.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.ServiceCall();
        }
        Debug.Log(other.gameObject.name);
    }
}
