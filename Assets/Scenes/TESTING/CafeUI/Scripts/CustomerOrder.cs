using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CustomerOrder : MonoBehaviour
{
    public Transform end;          // Ending position
    public float duration = 1f;    // Duration of the movement
    public GameObject customerCanvas;

    public InputActionMap moveActionMap;
    public bool orderRequest = true;
    
    public PlayerMovement playerMovement;
    

    void Start()
    {
        if (orderRequest)
        {
            MoveToEndPosition();
        }
    }

    void MoveToEndPosition()
    {
        // Ensure the canvas is inactive at the start
        customerCanvas.SetActive(false);

        // Move the object to the target position using DOTween
        transform.DOMove(end.position, duration).OnComplete(() =>
        {
            // Activate the customerCanvas once the movement is complete
            customerCanvas.SetActive(true);
            playerMovement.canMove = false;
        });
    }

    public void OnClick()
    {
        // Logic to handle canvas deactivation and further order handling
        customerCanvas.SetActive(false);
        orderRequest = false;
        playerMovement.canMove = true;

        Debug.Log("Order request completed.");
        
    }
}