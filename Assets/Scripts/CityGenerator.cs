using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int renderDistance;

    private CityBlock blockInstance;
    private List<Vector2Int> removeCoordinates;


    void Start()
    {
        blockInstance = GetComponent<CityBlock>();
        removeCoordinates = new List<Vector2Int>();
    }

    
    void Update()
    {
        int playerBlockX = (int) player.position.x / blockInstance.blockSize.x;
        int playerBlockZ = (int) player.position.z / blockInstance.blockSize.z;

        removeCoordinates.Clear();
    }
}
