using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{   
    [SerializeField, Range(0f, 1f)] public float parallaxStrength = 0.1f;
    private Transform followingTarget;
    private Vector3 targetPreviousPosition;
    void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }
        targetPreviousPosition = followingTarget.position; 
    }

    void Update()
    {
        Vector3 delta = followingTarget.position - targetPreviousPosition;
        targetPreviousPosition = followingTarget.position;
        transform.position += parallaxStrength * delta;
    }
}
