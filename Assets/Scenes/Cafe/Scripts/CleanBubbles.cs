using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CleanBubbles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            StartCoroutine(DestroyBubbles(other.gameObject));
        }
    }

    IEnumerator DestroyBubbles(GameObject bubble)
    {
        yield return new WaitForSeconds(3);
        Destroy(bubble);
    }
}
