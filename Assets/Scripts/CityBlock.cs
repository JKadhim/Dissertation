using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBlock : MonoBehaviour
{

    public Vector3Int blockSize = new Vector3Int(32, 50, 32);

    public GameObject buildingPrefab, roadPrefab;
    
    public Material buildingMaterial, roadMaterial;

    private int[,,] tempData;
 
    //creates a city block on a small grid of squares
    private void Start()
    {
        GameObject block = BlockSpawn(0, 0);
    }

    public GameObject BlockSpawn(int A, int B)
    {
        GameObject blockContainer = new GameObject("Block_" + A + "," + B);

        tempData = new int[blockSize.x, blockSize.y, blockSize.z];
        
        for (int x = 0; x < blockSize.x; x++)
        {
            for (int z = 0; z < blockSize.z; z++)
            {
                //ensures that each block is surrounded by roads
                if (x == 0 || x == 1 || x == 2 || x == 3 || x == blockSize.x - 1 || x == blockSize.x - 2 || x == blockSize.x - 3 || x == blockSize.x - 4)
                {
                    GameObject roadTile = Instantiate(roadPrefab);
                    roadTile.name = "roadTile_" + x + "," + z;
                    roadTile.transform.position = new Vector3(x, 0, z);
                    roadTile.transform.SetParent(blockContainer.transform);
                }
                else if (z == 0 || z == 1 || z == 2 || z == 3 || z == blockSize.z - 1 || z == blockSize.z - 2 || z == blockSize.z - 3 || z == blockSize.z - 4)
                {
                    GameObject roadTile = Instantiate(roadPrefab);
                    roadTile.name = "roadTile_" + x + "," + z;
                    roadTile.transform.position = new Vector3(x, 0, z);
                    roadTile.transform.SetParent(blockContainer.transform);
                }


                else
                {
                    for (int y = 0; y < blockSize.y; y++)
                    {
                        //GameObject buildingTile = Instantiate(buildingPrefab);
                        //buildingTile.name = "buildingTile_" + x + "," + y + "," + z;
                        //buildingTile.transform.position = new Vector3(x, y, z);
                        //buildingTile.transform.SetParent(blockContainer.transform);

                        tempData[x, y, z] = 1;
                    }
                }

            }

        }
        //Vector3Int buildingSize = new Vector3Int(blockSize.x - 8, blockSize.y, blockSize.z - 8);
        //GameObject buildingTile = Instantiate(buildingPrefab);
        //buildingTile.transform.localScale = buildingSize;
        //buildingTile.transform.SetParent(blockContainer.transform);
        //buildingTile.transform.localPosition = new Vector3((float)(blockSize.x - 1) / 2, (float)blockSize.y / 2, (float)(blockSize.z - 1) / 2);

        GameObject tempBlock = new GameObject("Block", new System.Type[] { typeof(MeshRenderer), typeof(MeshFilter) });
        tempBlock.GetComponent<MeshFilter>().mesh = new BlockMeshGenerator().CreateMeshFromData(tempData, this);

        return blockContainer;
    }

}
