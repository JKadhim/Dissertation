using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBlock : MonoBehaviour
{

    public int blockSize, cellSize, height;

    public GameObject buildingPrefab, roadPrefab;
    
    public Material buildingMaterial, roadMaterial;

    //creates a city block on a small grid of squares
    public GameObject BlockSpawn(int A, int B)
    {
        GameObject blockContainer = new GameObject("Block_" + A + "," + B);
        float offset = (blockSize / 2) * cellSize;

        for (int y = 1; y <= blockSize; y++)
        {
            for (int x = 1; x <= blockSize; x++)
            {
                //ensures that each block is surrounded by roads
                if (y == 1 || y == blockSize || x == 1 || x == blockSize)
                {
                    GameObject roadTile = Instantiate(roadPrefab);
                    roadTile.name = "roadTile_" + x + "," + y;
                    roadTile.transform.localScale = new Vector3(cellSize, roadTile.GetComponent<Transform>().localScale.y, cellSize);
                    roadTile.transform.position = new Vector3(x*cellSize, 0, y*cellSize);
                    roadTile.transform.SetParent(blockContainer.transform);
                }
                //ensures each block contains a ring of 'buildings'
                else if (y == 2 || y == blockSize - 1 || x == 2 || x == blockSize - 1)
                {
                    GameObject buildingTile = Instantiate(buildingPrefab);
                    buildingTile.name = "BuildingTile_" + x + "," + y;
                    buildingTile.transform.localScale = new Vector3(cellSize, height, cellSize);
                    buildingTile.transform.position = new Vector3(x * cellSize, buildingTile.GetComponent<Transform>().localScale.y / 2, y * cellSize);
                    buildingTile.transform.SetParent(blockContainer.transform);
                }

            }
        }
        return blockContainer;
    }

}
