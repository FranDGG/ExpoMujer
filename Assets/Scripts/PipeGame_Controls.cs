using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGame_Controls : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public void Rotate()
    {
        transform.Rotate(new Vector3 (0, 0, 270));
    }
}
