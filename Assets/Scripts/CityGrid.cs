using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CityGrid : MonoBehaviour
{

    public int citySize;
    public CityBlock cityBlock;
    public GameObject player;

    private void Start()
    {
        CitySpawn();
    }

    //Spaces out individual city blocks into a grid formation
    private void CitySpawn()
    {
        GameObject cityContainer = new GameObject("CityContainer");
        float offset = citySize / 2;
        int blockSize = cityBlock.blockSize;

        for (int y = 0; y < citySize; y++)
        {
            for (int x = 0; x < citySize; x++)
            {
                GameObject block =  cityBlock.BlockSpawn(x,y);
                
                //sets the blocks an appropriate distance apart
                block.transform.position = new Vector3((x * blockSize * cityBlock.cellSize), 0, y * blockSize * cityBlock.cellSize);
                block.transform.SetParent(cityContainer.transform);

            }
        }
        cityContainer.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }
}
