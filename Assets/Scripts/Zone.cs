using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public MeshGenerator meshGenerator;

    private void Start()
    {
        meshGenerator = GetComponent<MeshGenerator>();
        GenerateZone();
    }

    private void GenerateZone()
    {        
        meshGenerator.Generate();                
    }

}
