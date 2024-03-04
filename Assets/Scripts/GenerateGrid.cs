using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize = new Vector2Int(4, 4);
    [SerializeField] public Vector2Int zoneSize = new Vector2Int(30, 20);
    [SerializeField] private GameObject player;
    public Hashtable hashtable;
    public GameObject zonePrefab;

    private void Start()
    {
        hashtable = new Hashtable();
        for (int x = -gridSize.x; x < gridSize.x; x++)
        {
            for (int z = -gridSize.y; z < gridSize.y; z++)
            {
                Vector3 pos = new Vector3(x * zoneSize.x, 0, z * zoneSize.y);

                if (!hashtable.ContainsKey(pos))
                {
                    GameObject zone = new GameObject("Zone" + pos, typeof(Zone), typeof(MeshGenerator),
                        typeof(MeshFilter), typeof(MeshRenderer));
                    
                    zone.transform.parent = transform;
                    zone.transform.localPosition = pos;

                    hashtable.Add(pos, zone);
                }

            }
        }
    }    
}
