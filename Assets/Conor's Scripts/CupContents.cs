using System.Collections;
using UnityEngine;

public class CupContents : MonoBehaviour
{

    public TeaType TeaFlavour;
    public bool _hasIce;
    public bool _hasBubbles;
    public Sizes CupLevel;
    public int SmallTheshold;
    public int MediumTheshold;
    public int LargeTheshold;
    private int currentVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DispencedLiquid currentLiquid = collision.gameObject.GetComponent<DispencedLiquid>();

        if(currentLiquid != null)
        {
            if(currentLiquid.Ice)
            {
                _hasIce = true;
            }
            else if(currentLiquid.Bubbles)
            {
                _hasBubbles = true;
            }
            else
            {
                currentVolume +=1;
                CheckVolume();
                TeaFlavour = currentLiquid.Flavour;
            }
            Debug.Log(currentVolume);
            Debug.Log("Cup Contents: " + TeaFlavour.ToString() + " " + _hasIce + " " + _hasBubbles + " " + CupLevel.ToString());
        }
        else
        {
            Debug.LogError("Dispenced Liquid Has No Type");
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DispencedLiquid currentLiquid = collision.gameObject.GetComponent<DispencedLiquid>();

        if (currentLiquid != null)
        {
            if (currentLiquid.Ice)
            {
                _hasIce = false;
            }
            else if (currentLiquid.Bubbles)
            {
                _hasBubbles = false;
            }
            else
            {
                currentVolume -= 1;
                CheckVolume();
            }
            Debug.Log(currentVolume);
        }
        else
        {
            Debug.LogError("Dispenced Liquid Has No Type");
        }

    }

    private void CheckVolume()
    {
        if (currentVolume >= LargeTheshold)
        {
            CupLevel = Sizes.Large;
            return;
        }
        if (currentVolume >= MediumTheshold)
        {
            CupLevel = Sizes.Medium;
            return;
        }
        if (currentVolume >= SmallTheshold)
        {
            CupLevel = Sizes.Small;
            return;
        }
    }
}
