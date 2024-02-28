using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSeed : MonoBehaviour
{
    public string stringSeed = "String Seed";
    public bool useStringSeed;
    public int seed;
    public bool randomizeSeed;

    private void Awake()
    {
        //turns the string into a value
        if (useStringSeed)
        {
            seed = stringSeed.GetHashCode();
        }
        //gets a random value for the seed
        else if (randomizeSeed)
        {
            seed = Random.Range(0, 99999);
        }
        Debug.Log(seed);
        Random.InitState(seed);
    }
}
