using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class DropHeandler : MonoBehaviour, IDropHandler
{
    public UnityEvent<Item> OnDropEvent;
    public void OnDrop(PointerEventData eventData)
    {
        InventoryViewCell ivc = eventData.pointerDrag.gameObject.GetComponent<InventoryViewCell>();
        if (ivc != null)
        {
            OnDropEvent?.Invoke(ivc.ii);
        }
        
    }


}
