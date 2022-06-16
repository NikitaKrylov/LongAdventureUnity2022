using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Raycaster2D : MonoBehaviour
{
    [SerializeField] private Collider2D collider;
    public KeyCode TriggerKey;

    [SerializeField] private UnityEvent OnTriggerEnterEvent;
    [SerializeField] private UnityEvent OnTriggerExitEvent;

    [SerializeField, Tooltip("Действие при нажатии кнопки внутри колайдера")] 
    private UnityEvent OnKeyDownInColliderEvent;

    [SerializeField, Tooltip("Тригеруемые объекты")]
    private GameObject[] targetObjects = new GameObject[0];


    private void Start()
    {
        collider.isTrigger = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(TriggerKey))
        {
            Cast();
        }
    }

    public void Cast()
    {
        if (targetObjects.Length == 0 || OnKeyDownInColliderEvent.GetPersistentEventCount() == 0) return;

        RaycastHit2D[] hits = Physics2D.BoxCastAll(collider.bounds.center, collider.transform.localScale, 0f, Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            foreach (GameObject obj in targetObjects)
            {
                if (hit.transform.gameObject == obj) OnKeyDownInColliderEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj == collision.gameObject) OnTriggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject obj in targetObjects)
        {
            if (obj == collision.gameObject) OnTriggerExitEvent?.Invoke();
        }
    }
}
