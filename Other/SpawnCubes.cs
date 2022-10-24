using System;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float maxScale;
    
    private GameObject[] sampleCubes = new GameObject[64];

    private void Start()
    {
        for (int i = 0; i < 64; i++)
        {
            GameObject sampleCube = Instantiate(cube);
            sampleCube.transform.position = transform.position;
            sampleCube.transform.parent = transform;
            transform.eulerAngles = new Vector3(0, -0.703125f*i, 0);
            sampleCube.transform.position=Vector3.forward *100;
            sampleCubes[i] = sampleCube;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 64; i++)
        {
            if (sampleCubes != null)
            {
                sampleCubes[i].transform.localScale = new Vector3(0.2f, AudioParse.Samples[i]*maxScale, 0.2f);
            }
        }
    }
}