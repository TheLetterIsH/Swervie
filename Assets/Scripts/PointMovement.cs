using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    [SerializeField] private float movesSpeed;

    private void FixedUpdate()
    {
        transform.Translate(0, -movesSpeed * Time.deltaTime, 0);
    }
}
