using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] private int gridSizeX, gridSizeZ;
    [SerializeField] private GameObject player;
    public Hashtable hashtable;
    public GameObject blockPrefab;

    private int blockSizeX, blockSizeZ, tileSize;

    private void Start()
    {
        blockSizeX = blockPrefab.GetComponent<Block>().blockSizeX;
        blockSizeZ = blockPrefab.GetComponent<Block>().blockSizeZ;
        tileSize = blockPrefab.GetComponent<Block>().tileSize;
        hashtable = new Hashtable();
        for (int x = -gridSizeX; x < gridSizeX; x++)
        {
            for (int z = -gridSizeZ; z < gridSizeZ; z++)
            {
                Vector3 pos = new Vector3(x * blockSizeX * tileSize, 0, z * blockSizeZ *tileSize);

                if (!hashtable.ContainsKey(pos))
                {
                    GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity, transform);

                    hashtable.Add(pos, block);
                }

            }
        }
    }    
}
