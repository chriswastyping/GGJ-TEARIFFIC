using System;
using Unity.VisualScripting;
using UnityEngine;

public class ServiceActivator : MonoBehaviour
{
    public GameObject serviceCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter2D(Collision2D other)
    {
        serviceCamera.SetActive(true);
    }
}
