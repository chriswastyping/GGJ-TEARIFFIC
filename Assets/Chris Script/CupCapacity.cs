using System;
using Cinemachine;
using UnityEngine;

public class CupCapacity : MonoBehaviour
{
    //public HowFullIsCup cupCapacity;
    public bool canServe = false;
    
    [Header("Served")]
    public GameObject serveCanvas;
    public GameObject serveCamera;
    public GameObject mainCamera;

    private PlayerMovement mainCameraPM;

    private void Start()
    {
        mainCameraPM = GetComponent<PlayerMovement>();
    }

    //private void Update()
    //{
    //    if (cupCapacity.volume > 25)
    //    {
    //        canServe = true;
    //    }
    //}

    // ServerCanvasButton
    public void ServeCup()
    {
        Destroy(GameObject.FindGameObjectWithTag("Bubble"));
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        serveCanvas.SetActive(false);
        serveCamera.SetActive(false);
     //   mainCamera.SetActive(true);
        mainCameraPM.ActivateCamera(PlayerMovement.CameraState.Main);
    }
}
