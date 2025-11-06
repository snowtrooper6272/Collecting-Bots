using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public bool IsLocatedInside(Vector3 targetPosition, float distance) 
    {
        Vector2 offset = targetPosition - transform.position;

        return offset.sqrMagnitude <= distance * distance;
    }
}
