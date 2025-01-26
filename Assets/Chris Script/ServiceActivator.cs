using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class ServiceActivator : MonoBehaviour
{
    public GameObject serviceCamera;
    public GameObject serviceCanvas;
    
    private PlayerMovement playerMovement;
    
    private AudioSource dingAudio;
    public AudioClip dingClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter2D(Collision2D other)
    {
        playerMovement = other.gameObject.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.ServiceCall();
            dingAudio.pitch = Random.Range(0.9f, 1.1f);
            dingAudio.PlayOneShot(dingClip);
        }
        Debug.Log(other.gameObject.name);
    }
}
