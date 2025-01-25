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

    private CameraState currentState = CameraState.Main;

  //  public CustomerOrder isOrdering;

    private enum CameraState
    {
        Main,
        POV1,
        POV2
    }

    void Start()
    {
      //  isOrdering = GetComponent<CustomerOrder>();
        ActivateCamera(CameraState.Main);
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(movementDirection.x * moveSpeed, rb2d.linearVelocity.y);
    }

    void Update()
    {
       // if (!isOrdering.orderRequest)
      //  {
            movementDirection = moveAction.action.ReadValue<Vector2>();
      //  }
     //   else
     //   {
     //       moveAction.action.actionMap.Disable();
     //   }
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

    private void SwitchToPOV1(InputAction.CallbackContext context)
    {
        if (currentState == CameraState.Main)
        {
            ActivateCamera(CameraState.POV1);
        }
        else if (currentState == CameraState.POV2)
        {
            ActivateCamera(CameraState.Main);
        }
    }

    private void SwitchToPOV2(InputAction.CallbackContext context)
    {
        if (currentState == CameraState.POV1)
        {
            ActivateCamera(CameraState.Main);
        }
        else if (currentState == CameraState.Main)
        {
            ActivateCamera(CameraState.POV2);
        }
    }

    private void ActivateCamera(CameraState state)
    {
        // Activate/deactivate cameras based on state
        mainCamera.SetActive(state == CameraState.Main);
        povCamera1.SetActive(state == CameraState.POV1);
        povCamera2.SetActive(state == CameraState.POV2);

        // Update current state
        currentState = state;
    }
}
