using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CupSpawner : MonoBehaviour
{
    // Cup Prefab
    public GameObject cupPrefab;

    // Input action for spawning the cup
    public InputActionReference spawnCup;
    

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
    }
}