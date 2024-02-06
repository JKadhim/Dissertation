using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CityGrid : MonoBehaviour
{

    public int citySize;
    public CityBlock cityBlock;

    private void Start()
    {
        CitySpawn();
    }

    private void CitySpawn()
    {
        GameObject CityContainer = new GameObject("CityContainer");
        float offset = citySize / 2;
        int blockSize = cityBlock.blockSize;

        for (int y = 0; y <= citySize; y++)
        {
            for (int x = 0; x <= citySize; x++)
            {
                GameObject block =  cityBlock.BlockSpawn(x,y);
                
                //convert following
                //roadTile.transform.position = new Vector3(x - offset - (cellSize / 2), 0, y - offset - (cellSize / 2));
                //roadTile.transform.SetParent(blockContainer.transform);

            }
        }
    }
}
