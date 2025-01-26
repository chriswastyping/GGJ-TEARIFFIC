using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.Rendering.LookDev;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public TeaType[] TeaOptions;
    public Sizes[] SizeOpions;

    public struct TeaOrder
    {
        public TeaType CurrentFlavour;
        public bool _hasIce;
        public bool _hasBubbles;
        public Sizes Size;
    }

    public TeaOrder CurrentOrder;
    public TextMeshProUGUI CustomerText;
    private OrderManager orderManager;
    //public Button CreateOrderButton;

    private CupContents cupContents;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orderManager = FindFirstObjectByType<OrderManager>();
        CurrentOrder = SetOrder();
        Debug.Log(CurrentOrder.CurrentFlavour.ToString());

        string sizeText = CurrentOrder.Size.ToString();
        string flavorText = AddSpacesToSentence(CurrentOrder.CurrentFlavour.ToString());
        string iceText = (CurrentOrder._hasIce ? "Ice " : "No Ice ");
        string bubbleText = (CurrentOrder._hasBubbles ? "Bubbles" : "No Bubbles");

        CustomerText.text = "Hi! Can I have " + sizeText +  " " + flavorText + " flavoured tea with " + iceText+ "and "+ bubbleText;
    }

    public void CreateOrder()
    {

        string sizeText = CurrentOrder.Size.ToString();
        string flavorText = AddSpacesToSentence(CurrentOrder.CurrentFlavour.ToString());
        string iceText = (CurrentOrder._hasIce ? "Ice " : "No Ice ");
        string bubbleText = (CurrentOrder._hasBubbles ? "Bubbles" : "No Bubbles");

        orderManager.CreateOrder(sizeText, flavorText, iceText, bubbleText);
    }

    TeaOrder SetOrder()
    {
        TeaOrder order = new TeaOrder();
        order.CurrentFlavour = PickRandom(TeaOptions);
        order._hasBubbles = Random.value < 0.5f;
        order._hasIce = Random.value < 0.5f;
        order.Size = PickRandom(SizeOpions);
        return order;
    }

    T PickRandom<T>(IList<T> options)
    {
        int index = Random.Range(0, options.Count);
        return options[index];
    }

    string AddSpacesToSentence(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return "";
        StringBuilder newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                newText.Append(' ');
            newText.Append(text[i]);
        }
        return newText.ToString();
    }

    public void CheckCupContents()
    {
        cupContents = FindFirstObjectByType<CupContents>();

        if(isCorrectOrder())
        {
            CupCapacity capacity = FindFirstObjectByType<CupCapacity>();
            capacity.ServeCup();
        }
    }

    bool isCorrectOrder()
    {
        bool isRight = (CurrentOrder.CurrentFlavour == cupContents.TeaFlavour) && (CurrentOrder._hasIce == cupContents._hasIce)
            && (CurrentOrder._hasBubbles == cupContents._hasBubbles) && (CurrentOrder.Size == cupContents.CupLevel);
        return isRight;

    }
}
