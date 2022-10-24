using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < 32; i++)
        {
            transform.position = new Vector3(0, Mathf.Lerp(2f, 512 - 1, i / ((float)32 - 1)), 0);
            print(transform.position.y);
        }
    }
}
