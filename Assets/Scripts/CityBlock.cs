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
        float offset = blockSize / 2;

        for (int y = 1; y <= blockSize; y++)
        {
            for (int x = 1; x <= blockSize; x++)
            {
                //ensures that each block is surrounded by roads
                if (y == 1 || y == blockSize || x == 1 || x == blockSize)
                {
                    GameObject roadTile = Instantiate(roadPrefab);
                    roadTile.name = "roadTile_" + x + "," + y;
                    roadTile.transform.position = new Vector3(x - offset - (cellSize / 2), 0, y - offset - (cellSize / 2));
                    roadTile.transform.SetParent(blockContainer.transform);
                }
                //ensures each block contains a ring of 'buildings'
                else if (y == 2 || y == blockSize - 1 || x == 2 || x == blockSize - 1)
                {
                    GameObject buildingTile = Instantiate(buildingPrefab);
                    buildingTile.name = "BuildingTile_" + x + "," + y;
                    buildingTile.transform.localScale = new Vector3(buildingTile.GetComponent<Transform>().localScale.x, height, buildingTile.GetComponent<Transform>().localScale.z);
                    buildingTile.transform.position = new Vector3(x - offset - (cellSize / 2), buildingTile.GetComponent<Transform>().localScale.y / 2, y - offset - (cellSize / 2));
                    buildingTile.transform.SetParent(blockContainer.transform);
                }

            }
        }
        return blockContainer;
    }

}
