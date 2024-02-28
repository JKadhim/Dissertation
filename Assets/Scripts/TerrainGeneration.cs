using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public GameObject player;
    public GameObject plane;

    private int radius = 5;
    private int planeOffset = 10;
    private Vector3 startPosition;
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
    private int xPlayerLocation
    {
        get
        {
            return (int)Mathf.Floor(player.transform.position.x / planeOffset) * planeOffset;
        }
    }
    private int zPlayerLocation
    {
        get
        {
            return (int)Mathf.Floor(player.transform.position.z / planeOffset) * planeOffset;
        }
    }

    private Hashtable tilePlane = new Hashtable();

    private void Update()
    {
        if (startPosition == Vector3.zero)
        {
            for (int x = -radius; x < radius; x++)
            {
                for (int z = -radius; z < radius; z++)
                {
                    Vector3 pos = new Vector3 (x*planeOffset + xPlayerLocation, 0, z*planeOffset + zPlayerLocation); 

                    if (!tilePlane.ContainsKey(pos))
                    {
                        GameObject planeObject = Instantiate(plane, pos, Quaternion.identity);
                        tilePlane.Add(pos, planeObject);
                    }
                }
            }
        }

        if (HasPlayerMoved())
        {
            for (int x = -radius; x < radius; x++)
            {
                for (int z = -radius; z < radius; z++)
                {
                    Vector3 pos = new Vector3(x * planeOffset + xPlayerLocation, 0, z * planeOffset + zPlayerLocation);

                    if (!tilePlane.ContainsKey(pos))
                    {
                        GameObject planeObject = Instantiate(plane, pos, Quaternion.identity);
                        tilePlane.Add(pos, planeObject);
                    }
                }
            }
        }
    }

    bool HasPlayerMoved()
    {
        if (Mathf.Abs(xPlayerMove) >= planeOffset || Mathf.Abs(zPlayerMove) >= planeOffset)
        {
            return true;
        }
        else {
            return false;
        }
    }

}
