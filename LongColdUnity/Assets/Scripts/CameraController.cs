using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera m_Camera;
    [SerializeField] private GameObject followingObject;
    [SerializeField] private Vector3 offset = Vector3.zero;
    [SerializeField] private float speed;
    [SerializeField] private bool autoOffset = true;

    void Start()
    {
        m_Camera = Camera.main;

        if (autoOffset)
        {
            offset = m_Camera.transform.position - followingObject.transform.position;
            offset.z = 0;
        }
    }

    
    void Update()
    {
        Vector3 cameraPos = m_Camera.transform.position - offset;
        Vector3 followPos = followingObject.transform.position;

        Vector3 newCameraPos = Vector3.Lerp(cameraPos, followPos, speed * Time.deltaTime);
        newCameraPos.z = cameraPos.y;
        
        m_Camera.transform.position = newCameraPos + offset;
    }
}
