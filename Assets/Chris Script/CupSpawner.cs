using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CupSpawner : MonoBehaviour
{
    // Cup Prefab
    public GameObject cupPrefab;

    // Input action for spawning the cup
    public InputActionReference spawnCup;
    
    
    // SFX Clip
    private AudioSource newAudio;
    public AudioClip cupClip;

    private void Awake()
    {
        newAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Optionally initialize or log something here
    }

    private void OnEnable()
    {
        spawnCup.action.started += SpawnNewCup;
    }

    private void OnDisable()
    {
        spawnCup.action.started -= SpawnNewCup;
    }

    void SpawnNewCup(InputAction.CallbackContext context)
    {
        GameObject newCup = Instantiate(cupPrefab, transform);
        
        newCup.transform.localPosition = Vector3.zero;
        
        newCup.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        
        newAudio.pitch = Random.Range(-1f, 1f);
        newAudio.PlayOneShot(cupClip);
    }
}