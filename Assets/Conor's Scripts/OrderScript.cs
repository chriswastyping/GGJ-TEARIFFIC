using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderScript : MonoBehaviour
{
    private Button button;
    public TextMeshProUGUI buttonText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        //buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOrderDisplay(string Size, string Flavour, string Ice, string Bubbles) 
    { 
        buttonText.text = Size + " " + Flavour + ", " + Ice + ", " + Bubbles;
    }
}
