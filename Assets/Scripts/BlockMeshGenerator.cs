using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMeshGenerator
{
    public class FaceData
    {
        public FaceData(Vector3[] verts, int[] tris)
        {
            vertices = verts;
            indicies = tris;
        }
        
        public Vector3[] vertices;
        public int[] indicies;
    }

    #region FaceData

    static readonly Vector3Int[] CheckDirections = new Vector3Int[]
    {
        Vector3Int.right,
        Vector3Int.left,
        Vector3Int.up,
        Vector3Int.down,
        Vector3Int.forward,
        Vector3Int.back
    };

    static readonly Vector3[] RightFace = new Vector3[]
    {
        new Vector3(.5f, -.5f, -.5f),
        new Vector3(.5f, -.5f, .5f),
        new Vector3(.5f, .5f, .5f),
        new Vector3(.5f, .5f, -.5f)
    };

    static readonly int[] RightTris = new int[]
    {
        0,2,1,0,3,2
    };

    static readonly Vector3[] LeftFace = new Vector3[]
    {
        new Vector3(-.5f, -.5f, -.5f),
        new Vector3(-.5f, -.5f, .5f),
        new Vector3(-.5f, .5f, .5f),
        new Vector3(-.5f, .5f, -.5f)
    };

    static readonly int[] LeftTris = new int[]
    {
        0,1,2,0,2,3
    };

    static readonly Vector3[] UpFace = new Vector3[]
    {
        new Vector3(-.5f, .5f, -.5f),
        new Vector3(-.5f, .5f, .5f),
        new Vector3(.5f, .5f, .5f),
        new Vector3(.5f, .5f, -.5f)
    };

    static readonly int[] UpTris = new int[]
    {
        0,1,2,0,2,3
    };

    static readonly Vector3[] DownFace = new Vector3[]
    {
        new Vector3(-.5f, -.5f, -.5f),
        new Vector3(-.5f, -.5f, .5f),
        new Vector3(.5f, -.5f, .5f),
        new Vector3(.5f, -.5f, -.5f)
    };

    static readonly int[] DownTris = new int[]
    {
        0,2,1,0,3,2
    };

    static readonly Vector3[] ForwardFace = new Vector3[]
    {
        new Vector3(-.5f, -.5f, .5f),
        new Vector3(-.5f, .5f, .5f),
        new Vector3(.5f, .5f, .5f),
        new Vector3(.5f, -.5f, .5f)
    };

    static readonly int[] ForwardTris = new int[]
    {
        0,2,1,0,3,2
    };

    static readonly Vector3[] BackFace = new Vector3[]
    {
        new Vector3(-.5f, -.5f, -.5f),
        new Vector3(-.5f, .5f, -.5f),
        new Vector3(.5f, .5f, -.5f),
        new Vector3(.5f, -.5f, -.5f)
    };

    static readonly int[] BackTris = new int[]
    {
        0,1,2,0,2,3
    };

    #endregion


    private Dictionary<Vector3Int, FaceData> CubeFaces = new Dictionary<Vector3Int, FaceData>();

    public BlockMeshGenerator()
    {
        CubeFaces = new Dictionary<Vector3Int, FaceData>();

        for (int i = 0; i < CheckDirections.Length; i++)
        {
            if (CheckDirections[i] == Vector3Int.up)
            {
                CubeFaces.Add(CheckDirections[i], new FaceData(UpFace, UpTris));
            }
            else if (CheckDirections[i] == Vector3Int.down)
            {
                CubeFaces.Add(CheckDirections[i], new FaceData(DownFace, DownTris));
            }
            else if (CheckDirections[i] == Vector3Int.forward)
            {
                CubeFaces.Add(CheckDirections[i], new FaceData(ForwardFace, ForwardTris));
            }
            else if (CheckDirections[i] == Vector3Int.back)
            {
                CubeFaces.Add(CheckDirections[i], new FaceData(BackFace, BackTris));
            }
            else if (CheckDirections[i] == Vector3Int.left)
            {
                CubeFaces.Add(CheckDirections[i], new FaceData(LeftFace, LeftTris));
            }
            else if (CheckDirections[i] == Vector3Int.right)
            {
                CubeFaces.Add(CheckDirections[i], new FaceData(RightFace, RightTris));
            }
        }
    }

    public Mesh CreateMeshFromData(int[,,] Data, CityBlock cityBlock)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> indicies = new List<int>();

        Mesh m = new Mesh();

        for (int x = 0; x < cityBlock.blockSize.x; x++)
        {
            for (int y = 0; y < cityBlock.blockSize.y; y++)
            {
                for ( int z = 0; z < cityBlock.blockSize.z ; z++)
                {
                    Vector3Int cubePos = new Vector3Int(x, y, z);
                    if (Data[x,y,z] == 1)
                    {
                        for (int i = 0; i < CheckDirections.Length; i++)
                        {
                            Vector3Int cubeToCheck = cubePos + CheckDirections[i];

                            try
                            {
                                if (Data[cubeToCheck.x, cubeToCheck.y, cubeToCheck.z] == 0)
                                {
                                    if (Data[cubePos.x, cubePos.y, cubePos.z] != 0)
                                    {
                                        FaceData faceToApply = CubeFaces[CheckDirections[i]];

                                        foreach (Vector3 vert in faceToApply.vertices)
                                        {
                                            vertices.Add(new Vector3(x, y, z) + vert);
                                        }

                                        foreach (int tri in faceToApply.indicies)
                                        {
                                            indicies.Add(vertices.Count - 4 + tri);
                                        }
                                    }
                                }
                            }
                            catch (System.Exception)
                            {
                                if (Data[cubePos.x, cubePos.y, cubePos.z] == 0)
                                {
                                    FaceData FaceToApply = CubeFaces[CheckDirections[i]];

                                    foreach (Vector3 vert in FaceToApply.vertices)
                                    {
                                        vertices.Add(new Vector3(x, y, z) + vert);
                                    }

                                    foreach (int tri in FaceToApply.indicies)
                                    {
                                        indicies.Add(vertices.Count - 4 + tri);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        m.SetVertices(vertices);
        m.SetIndices(indicies, MeshTopology.Triangles, 0);
        m.RecalculateBounds();
        m.RecalculateNormals();
        m.RecalculateTangents();

        return m;
    }

}
