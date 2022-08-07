using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro), typeof(Animator))]
public class FloatingText : MonoBehaviour
{
    [SerializeField] private float destroyTime = .3f;
    [SerializeField] private Vector3 offset = Vector3.zero;

    [ Tooltip("Random value negative and positive randomaize value adding to base font size")] 
    [SerializeField] private float randomaizeTextSize = 0;

    [SerializeField] private Vector3 randomaizeIntensity = Vector3.zero;
    void Start()
    {
        Destroy(gameObject, destroyTime);

        GetComponent<TextMeshPro>().fontSize += Random.Range(-randomaizeTextSize, randomaizeTextSize);
        
        transform.localPosition += offset;
        transform.localPosition += new Vector3(
            Random.Range(-randomaizeIntensity.x, randomaizeIntensity.x),
            Random.Range(-randomaizeIntensity.y, randomaizeIntensity.y),
            0
            );

    }

    
}
