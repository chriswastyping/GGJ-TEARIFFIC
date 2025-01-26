using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float moveSpeed = 5f;
    private Vector2 movementDirection;

    public InputActionReference moveAction;
    public InputActionReference switchToPOV1Action; // W
    public InputActionReference switchToPOV2Action; // S

    public GameObject mainCamera;
    public GameObject povCamera1;
    public GameObject povCamera2;

    public CameraState currentState = CameraState.Main;
    
    public bool canMove = true;
    
    [Header("Serve")]
    public GameObject serveCanvas;
    public bool isServing = false;
    
    [Header("Making")]
    public GameObject makingCanvas;
    public bool isMaking = false;
    
    [Header("Menu")]
    public GameObject menuCanvas;
    public bool openMenu = false;

    public enum CameraState
    {
        Main,
        POV1,
        POV2
    }

    void Start()
    {
        ActivateCamera(CameraState.Main);
    }

    private void FixedUpdate()
    {
        if (canMove && rb2d != null)
        {
            rb2d.linearVelocity = new Vector2(movementDirection.x * moveSpeed, rb2d.linearVelocity.y);
        }
    }

    void Update()
    {
            movementDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        switchToPOV1Action.action.started += SwitchToPOV1;
        switchToPOV2Action.action.started += SwitchToPOV2;
    }

    private void OnDisable()
    {
        switchToPOV1Action.action.started -= SwitchToPOV1;
        switchToPOV2Action.action.started -= SwitchToPOV2;
    }

    void Service()
    {
        if (isServing)
        {
            serveCanvas.SetActive(true);
        }
        else
        {
            serveCanvas.SetActive(false);
        }
    }

    void Making()
    {
        // for the order tickets?
    }

    void Menu()
    {
        if (openMenu)
        {
            menuCanvas.SetActive(true);
        }
        else
        {
            menuCanvas.SetActive(false);
        }
    }

    private void SwitchToPOV1(InputAction.CallbackContext context)
    {
        if (currentState == CameraState.Main)
        {
            ActivateCamera(CameraState.POV1);
            isServing = true;
            Service();
        }
        else if (currentState == CameraState.POV2)
        {
            ActivateCamera(CameraState.Main);
            openMenu = false;
            Menu();
           
        }
    }

    private void SwitchToPOV2(InputAction.CallbackContext context)
    {
        if (currentState == CameraState.POV1)
        {
            ActivateCamera(CameraState.Main);
            isServing = false;
            Service();
        }
        else if (currentState == CameraState.Main)
        {
            ActivateCamera(CameraState.POV2);
            openMenu = true;
            Menu();
        }
    }

    public void ActivateCamera(CameraState state)
    {
        // Activate/deactivate cameras based on state
        mainCamera.SetActive(state == CameraState.Main);
        povCamera1.SetActive(state == CameraState.POV1);
        povCamera2.SetActive(state == CameraState.POV2);

        // Update current state
        currentState = state;
    }
}
