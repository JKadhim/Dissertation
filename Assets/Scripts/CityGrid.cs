using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CityGrid : MonoBehaviour
{

    public int citySize = 5;
    public CityBlock cityBlock;
    public GameObject player;
    
    private Vector3 startPosition;
    private Hashtable blockContainer = new Hashtable();
    private GameObject cityContainer;

    private int xPlayerMove
    {
        get
        {
            return (int)(player.transform.position.x - startPosition.x);
        }
    }
    private int zPlayerMove
    {
        get
        {
            return (int)(player.transform.position.z - startPosition.z);
        }
    }
    private int playerLocationX
    {
        get
        {
            if (player.transform.position.x < 0)
            {
                return (int)Mathf.Floor(player.transform.position.x / (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize)) * (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize);
            }
            else
            {
                return (int)Mathf.Ceil(player.transform.position.x / (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize)) * (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize);
            }
        }
    }

    private int playerLocationZ
    {
        get
        {
            if (player.transform.position.z < 0)
            {
                return (int)Mathf.Floor(player.transform.position.z / (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize)) * (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize);
            }
            else
            {
                return (int)Mathf.Ceil(player.transform.position.z / (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize)) * (citySize * 2 * cityBlock.blockSize * cityBlock.cellSize);
            }
        }
    }

    private void Start()
    {
        cityContainer = new GameObject("CityContainer");
        CitySpawn();
    }

    //Spaces out individual city blocks into a grid formation
    
    private void Update()
    {
        int blockSize = cityBlock.blockSize;
        int cellSize = cityBlock.cellSize;
        int scale = blockSize * citySize * cellSize;
        int cityOffset = citySize * 2;
        
        if (HasPlayerMoved())
        {
            for (int x = -citySize; x < citySize; x++)
            {
                for (int z = -citySize; z < citySize; z++)
                {

                    Vector3 pos = new Vector3((x * blockSize * cellSize)  + playerLocationX, 0, (z * blockSize * cellSize) + playerLocationZ);

                    if (!blockContainer.ContainsKey(pos))
                    {
                        GameObject block = cityBlock.BlockSpawn(x, z);

                        block.transform.position = pos;
                        block.transform.SetParent(cityContainer.transform);

                        blockContainer.Add(pos, block);
                    }

                }
            }
        }
    }

    private void CitySpawn()
    {

        int blockSize = cityBlock.blockSize;
        int cellSize = cityBlock.cellSize;
        int scale = blockSize * citySize * cellSize;

        for (int x = -citySize; x < citySize; x++)
        {
            for (int z = -citySize; z < citySize; z++)
            {

                //sets the blocks an appropriate distance apart
                Vector3 pos = new Vector3((x * blockSize * cellSize) + startPosition.x, 0, (z * blockSize * cellSize) + startPosition.z);

                GameObject block = cityBlock.BlockSpawn(x, z);

                block.transform.position = pos;
                block.transform.SetParent(cityContainer.transform);

                blockContainer.Add(pos, block);

            }
        }
    }

    bool HasPlayerMoved()
    {
        if (Mathf.Abs(xPlayerMove) >= citySize|| Mathf.Abs(zPlayerMove) >= citySize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
