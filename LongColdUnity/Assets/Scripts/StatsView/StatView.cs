using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatView : MonoBehaviour
{
    public bool IsActive { get { return gameObject.activeSelf; } }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public void Show<T>(T obj)
    {
        gameObject.SetActive(true);
        SetData(obj);
    }

    protected virtual void SetData<T>(T obj)
    {
        if (obj is AbstractItem)
        {
            SetAbstractItemData(obj as AbstractItem);
        }
        else if (obj is Item)
        {
            SetItemData(obj as Item);
        }
        else if (obj is InventoryViewCell)
        {
            SetInventoryViewCellData(obj as InventoryViewCell);
        }
        else
        {
            ThrowTypeError(obj);
        }
    }

    protected void ThrowTypeError<T>(T obj)
    {
        throw new System.Exception($"Type '{obj.GetType().Name}' doesn`t have a realization");
    }

    protected abstract void SetAbstractItemData(AbstractItem obj);
    protected abstract void SetItemData(Item obj);
    protected abstract void SetInventoryViewCellData(InventoryViewCell obj);
}
