using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MeshGenerator : MonoBehaviour
{
    public void Generate()
    {
        Mesh mesh = new Mesh();
        Vector2Int zoneSize = GetComponentInParent<GenerateGrid>().zoneSize;
        MeshFilter filter = GetComponent<MeshFilter>();
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);

        mesh.vertices = CreateVertices(zoneSize);
        mesh.triangles = CreateTriangles(zoneSize);

        mesh.RecalculateNormals();
        filter.sharedMesh = mesh;
     
        
    }

    private Vector3[] CreateVertices(Vector2Int zoneSize)
    {
        Vector3[] vertices = new Vector3[(zoneSize.x + 1) * (zoneSize.y + 1)];

        for (int i = 0, z = 0; z <= zoneSize.y; z++)
        {
            for (int x = 0; x <= zoneSize.x; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        return vertices;
    }

    private int[] CreateTriangles(Vector2Int zoneSize)
    {
        int[] triangles = new int[zoneSize.x * zoneSize.y * 6];

        for (int z = 0, verts = 0, tris = 0; z < zoneSize.y; ++z)
        {
            for (int x = 0; x < zoneSize.x; x++)
            {
                triangles[tris + 0] = verts + 0;
                triangles[tris + 1] = verts + zoneSize.x + 1;
                triangles[tris + 2] = verts + 1;

                triangles[tris + 3] = verts + 1;
                triangles[tris + 4] = verts + zoneSize.x + 1;
                triangles[tris + 5] = verts + zoneSize.x + 2;

                verts++;
                tris += 6;
            }
            verts++;
        }
        return triangles;
    }  
}
