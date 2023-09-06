using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeGridGenerator : MonoSingleton<RuntimeGridGenerator>
{
    public List<LockerControlSwitcher> SpawnedLockerSwitchers;
    
    [SerializeField] private GameObject _spawnedPrefab;
    [SerializeField] private GameObject _finalParentObject;
    [SerializeField] private Vector3 spawnPosition = Vector3.zero;
    [SerializeField] private Vector3 spawnRotation = Vector3.zero;
    
    public int rows = 5;
    public int columns = 3;
    public float spacing = 0f; 
    
    void Start() 
    {
        Vector3 size = BoundsExtensions.CalculateBounds(_spawnedPrefab).size;

        Vector3 startingPosition = spawnPosition;
        // Offset the starting position to ensure spawnPosition is the center of the bottom row
        startingPosition.x -= (columns - 1) * (size.x + spacing) * 0.5f;
        startingPosition.y -= (rows - 1) * (size.y + spacing) * 0.5f;

        Quaternion rotation = Quaternion.Euler(spawnRotation);
        
        for (int x = 0; x < columns; x++) 
        {
            for (int y = 0; y < rows; y++) 
            {
                Vector3 position = startingPosition + new Vector3(x * (size.x + spacing), y * (size.y + spacing), 0f);
                GameObject spawnedObject = Instantiate(_spawnedPrefab, position, rotation);
                SpawnedLockerSwitchers.Add(spawnedObject.GetComponentInChildren<LockerControlSwitcher>());
                spawnedObject.transform.SetParent(_finalParentObject.transform);
            }
        }
    }
}