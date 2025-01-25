using UnityEngine;
using DG.Tweening;

public class CustomerOrder : MonoBehaviour
{
   // public Transform start; // Starting position
    public Transform end;   // Ending position
    public float duration = 1f; // Duration of the movement

    public GameObject customerCanvas;

    void Start()
    {
        GetComponent(PlayerMovement).enabled = false;
        // Move the object to the target position using DOTween
        transform.DOMove(end.position, duration).OnComplete(() =>
        {
            // Activate the customerCanvas once the movement is complete
            customerCanvas.SetActive(true);
        });
        
        OnClick();
    }

    public void OnClick()
    {
        customerCanvas.SetActive(false);
    }
}