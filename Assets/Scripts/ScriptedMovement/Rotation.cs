using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(_rotationSpeed * Time.fixedDeltaTime,0, 0);
    }
}
