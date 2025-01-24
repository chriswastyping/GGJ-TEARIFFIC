using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    
    public float moveSpeed = 5f;

    private Vector2 movementDirection;
    
    public InputActionReference moveAction;
    
    public InputActionReference changeViewAction;
    public InputActionReference changeViewAction2;
    
    public GameObject povCamera2;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(movementDirection.x * moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        changeViewAction.action.started += CafeView;
        changeViewAction2.action.started += CounterView;
    }

    private void OnDisable()
    {
        changeViewAction.action.started -= CafeView;
        changeViewAction2.action.started -= CounterView;
    }
    
    private void CafeView(InputAction.CallbackContext obj)
    {
        povCamera2.SetActive(true);
    }

    private void CounterView(InputAction.CallbackContext obj)
    {
        povCamera2.SetActive(false);
    }
    
    
}
