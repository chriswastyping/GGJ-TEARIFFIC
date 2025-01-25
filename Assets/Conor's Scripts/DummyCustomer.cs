using UnityEngine;

public class DummyCustomer : MonoBehaviour
{
    [System.Serializable]
    public struct TeaOrder
    {
        public TeaType CurrentFlavour;
        public bool _hasIce;
        public bool _hasBubbles;
        public Sizes Size;
    }

    public TeaOrder CurrentOrder;

    private CupContents cupContents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cupContents = FindFirstObjectByType<CupContents>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CheckCupContents()) 
        {
            Debug.Log("IT MATCHES");
        }
    }

    bool CheckCupContents() 
    { 
        bool isRight = (CurrentOrder.CurrentFlavour == cupContents.TeaFlavour) && (CurrentOrder._hasIce == cupContents._hasIce)
            &&(CurrentOrder._hasBubbles == cupContents._hasBubbles) && (CurrentOrder.Size == cupContents.CupLevel);
        return isRight;
    
    }
}
