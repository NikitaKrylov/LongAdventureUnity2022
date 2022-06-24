using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleProgress : MonoBehaviour
{
    private static Image fillImage;
    private static Text tooltipText;
    private RectTransform rectTransform;
    private Camera _cam;
    private static float progress  = 0f;
    
    public Vector3 offset;
    void Start()
    {
        fillImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        _cam = Camera.main;
        tooltipText = GetComponentInChildren<Text>(); 
    }

    void Update()
    {
        fillImage.fillAmount = progress;
        Vector3 pos = _cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position =  new Vector3 (pos.x  , pos.y, transform.position.z) + offset;
        
    }

    public static void ResetProgress()
    {
        progress = 0f;
        SetTooltip("");
    }
    public static void ChangeProgress(float value)
    {
        progress = value;
    }
    public static void UpdateProgress(float value)
    {
        progress += value;
    }
    public static void SetTooltip(string text)
    {
        tooltipText.text = text;
    }

    
}
