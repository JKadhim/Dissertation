using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public MeshGenerator meshGenerator;
    public Color type;

    private void Start()
    {
        meshGenerator = GetComponent<MeshGenerator>();
        type = DetermineType();
        GenerateZone();
    }

    private void GenerateZone()
    {        
        meshGenerator.Generate(type);                
    }

    private Color DetermineType()
    {
        Vector3 position = GetComponentInParent<Transform>().position;
        Vector2Int zoneSize = GetComponentInParent<GenerateGrid>().zoneSize;
        if (Rem(position.z/zoneSize.x))
        {
            Color colour = Color.gray;
            return colour;
        }
        else
        {
            Color colour = Color.white;
            return colour;
        }
        
    }

    private bool Rem(float x)
    {
        if (x % 10 == 0) return true;
        else return false;
    }

}
