using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0f;

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
