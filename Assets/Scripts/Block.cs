using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockSizeX = 50;
    public int blockSizeZ = 50;
    public readonly int tileSize = 2;
    public GameObject building;
    public GameObject road;


    private void Start()
    {
        GenerateBlock();
    }

    private void GenerateBlock()
    {
        for (int x = 0; x < blockSizeX; x++)
        {
            for (int z = 0; z < blockSizeZ; z++)
            {

                if (IsRoad(x, z))
                {
                    Vector3 pos = new Vector3(x * tileSize, road.transform.localScale.y /2, z * tileSize);
                    GameObject temp = Instantiate(road, transform);
                    temp.transform.localPosition = pos;
                }
                else
                {
                    Vector3 pos = new Vector3(x * tileSize, building.transform.localScale.y /2, z * tileSize);
                    GameObject temp = Instantiate(building, transform);
                    temp.transform.localPosition = pos;
                }                
            }    
        }
    }

    private bool IsRoad(int x, int z)
    {
        if (x == 0 || x == blockSizeX - 1 || z == 0 || z == blockSizeZ - 1)
            return true;
        if (x == 1 || x == blockSizeX - 2 || z == 1 || z == blockSizeZ - 2)
            return true;
        else
            return false;
    }

}
