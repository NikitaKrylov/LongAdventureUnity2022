using UnityEngine;
using UnityEngine.UI;


public class Twig : MonoBehaviour
{
    [SerializeField] public AbstractItem dropObjectModel;
    public int dropAmount = 2;


    public void DropAndDestroy()
    {
        if (dropObjectModel != null)
            for (int i = 0; i < dropAmount; i++)
            {
                GameObject _obj = dropObjectModel.CreateObject(transform.position, Random.Range(-80, 80) * Vector3.forward);

                Vector3 vector = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * Vector3.up;
                _obj.GetComponent<Rigidbody2D>().AddForce(vector * 100);

            }

        Destroy(gameObject);

    }
}
