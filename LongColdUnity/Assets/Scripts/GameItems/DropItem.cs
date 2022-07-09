using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DropItem 
{
    public AbstractItem item;
    public int minDropAmount;
    public int maxDropAmount;

    [Tooltip("��������� ����������, ���� null, �� ���� ����� ��������� �� ������������� ����������")]
    public bool useRandomDropAmountChance = false;

    [Tooltip("���� ��� ���� �����")] 
    public bool useDropChance = false;
    [Range(0f, 1f)] public float dropChance;

    

    public void Drop(Vector3 position, Vector3? rotation = null, Vector3? force = null)
    {
        if (useDropChance)
        {
            if (UnityEngine.Random.value >= dropChance)
            {
                _Drop(position, rotation, force);
            }
        }
        else
        {
            _Drop(position, rotation, force);
        }
            
    }

    private void _Drop(Vector3 position, Vector3? rotation = null, Vector3? force = null)
    {
        int dropAmount;
        if (useRandomDropAmountChance) dropAmount = UnityEngine.Random.Range(minDropAmount, maxDropAmount);
        else dropAmount = maxDropAmount;    

        for (int i = 0; i < UnityEngine.Random.Range(minDropAmount, maxDropAmount); i++)
        {
            item.CreateObject(position, rotation, force);
        }
        
    }
}
