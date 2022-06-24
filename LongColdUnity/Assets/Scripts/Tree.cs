using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] public AbstractItem dropObjectModel;

    public int dropAmount = 3;
    [SerializeField] private bool dropRandomAmount = false;
    [SerializeField] private int minDropAmount;
    [SerializeField] private int maxDropAmount;


    public void DropAndDestroy()
    {

        if (dropObjectModel != null)
        {

            int v;
            if (dropRandomAmount) v = Random.Range(minDropAmount, maxDropAmount);
            else v = dropAmount;

            for (int i = 0; i < v; i++)
            {
                GameObject _obj = dropObjectModel.CreateObject(transform.position, Random.Range(-80, 80) * Vector3.forward);

                Vector3 vector = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * Vector3.up;
                _obj.GetComponent<Rigidbody2D>().AddForce(vector * 100);

            }
        }
        Destroy(gameObject);

    }
}
