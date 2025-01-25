using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public int TotalOrders = 0;
    public float OrderYOffset = 100;
    public RectTransform OrderStartPos;
    private Canvas canvas;
    public OrderScript OrderTemplate;
    private Vector3 spawnPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponent<Canvas>();
        spawnPos = OrderStartPos.position;
    }

    public void CreateOrder(string Size, string Flavour, string Ice, string Bubbles)
    {
        TotalOrders += 1;
        var newOrder = Instantiate(OrderTemplate,spawnPos,Quaternion.identity);
        newOrder.transform.SetParent(canvas.transform);
        newOrder.transform.SetAsFirstSibling();
        newOrder.SetOrderDisplay(Size, Flavour, Ice, Bubbles);
        spawnPos.y += OrderYOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
