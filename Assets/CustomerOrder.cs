using UnityEngine;
using DG.Tweening;

public class CustomerOrder : MonoBehaviour
{
    public Transform start; // Starting position
    public Transform end;   // Ending position
    public float speed = 1f; // Adjust speed here

    private float t = 0f;   // Progress variable
    public GameObject customerCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        // Increment progress over time
        t += Time.deltaTime * speed;

        // Clamp t to ensure it stays between 0 and 1
        t = Mathf.Clamp01(t);

        // Interpolate position based on t
        transform.position = transform.DOMoveX(Vector2,-1, 1);
        
        

        // Check if the object is close enough to the target position
        if (Vector3.Distance(transform.position, end.position) < 0.01f)
        {
            customerCanvas.SetActive(true);
        }
    }
}