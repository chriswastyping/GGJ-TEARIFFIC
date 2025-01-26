using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CupContents : MonoBehaviour
{
    // SFX Clip
    private AudioSource newAudio;
    public AudioClip bubbleClip;
    
    public TeaType TeaFlavour;
    public bool _hasIce;
    public bool _hasBubbles;
    public Sizes CupLevel;
    public int SmallTheshold;
    public int MediumTheshold;
    public int LargeTheshold;
    private int currentVolume;

    public TextMeshProUGUI SizeText;
    private void Awake()
    {
        newAudio = GetComponent<AudioSource>();
    }
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
        
        newAudio.PlayOneShot(bubbleClip);
        
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
                
            }
            else if (currentLiquid.Bubbles)
            {
               
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
            SizeText.text = CupLevel.ToString();
            return;
        }
        if (currentVolume >= MediumTheshold)
        {
            CupLevel = Sizes.Medium;
            SizeText.text = CupLevel.ToString();
            return;
        }
        if (currentVolume >= SmallTheshold)
        {
            CupLevel = Sizes.Small;
            SizeText.text = CupLevel.ToString();
            return;
        }
    }
}
