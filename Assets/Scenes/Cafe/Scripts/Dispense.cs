using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dispense : MonoBehaviour
{
    public GameObject[] bubbles;
    public InputActionReference dispenseAction;
   // public GameObject dispensePrefab;

    private bool canDispense = false;
    private void OnEnable()
    {
        dispenseAction.action.started += DispenseBubbles;
    }

    private void OnDisable()
    {
        dispenseAction.action.started -= DispenseBubbles;
    }

    private void DispenseBubbles(InputAction.CallbackContext obj)
    {
        // Use the current position of the dispenser (this GameObject) for instantiation
        Vector3 dispensePosition = transform.position;
        if (canDispense)
        {
            Instantiate(bubbles[0], dispensePosition, Quaternion.identity);
            Debug.Log(dispensePosition);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector3.down);
        if (ray.collider != null)
        {
            canDispense = ray.collider.CompareTag("Player");
            if (canDispense)
            {
                Debug.DrawRay(transform.position, Vector3.down, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, Vector3.down, Color.red);
            }
        }
    }
}