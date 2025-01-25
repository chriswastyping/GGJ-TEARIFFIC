using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CupSpawner : MonoBehaviour
{
    // Cup Prefab
    public GameObject cupPrefab;

    // Input action for spawning the cup
    public InputActionReference spawnCup;

    // Spawn position in world space
    public Vector2 spawnCupPosition;

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
        // Convert 2D spawn position to 3D (assuming z = 0)
        Vector3 spawnPosition = new Vector3(spawnCupPosition.x, spawnCupPosition.y, 0);

        // Instantiate the cup and set it as a child of this object
        GameObject newCup = Instantiate(cupPrefab, spawnPosition, Quaternion.identity);

        // Set the spawned cup's parent to this object
        newCup.transform.SetParent(this.transform);
    }
}