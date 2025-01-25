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
        //Vector2 dispensePosition = new Vector3(transform.position.x, transform.position.y, -transform.parent.position.z);
        if (canDispense)
        {
            var currentBubble = Instantiate(bubbles[0], transform.position, Quaternion.identity);
            currentBubble.transform.SetParent(transform.parent,true);
            //Debug.Log(dispensePosition);
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