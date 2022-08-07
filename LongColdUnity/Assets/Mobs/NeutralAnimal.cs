using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class NeutralAnimal : MonoBehaviour, INeutralMob
{
    [Header("Speed")]
    [SerializeField] protected float defaultSpeed = 1.6f;
    [SerializeField] protected float maxSpeed = 7;
    [Space]

    [SerializeField] protected float maxHealth;

    [Space]
    [SerializeField] private GameObject floatingTextPrefab;

    protected float health;
    private Animator _animotor;
    private Rigidbody2D _rb;
    public Animator animator { get { return _animotor; } }
    public Rigidbody2D rb { get { return _rb; } }

    protected FSM fsm;


    public void Move(Vector2 speed, Vector2 direction)
    {
        rb.velocity = new Vector2(
            direction.x * speed.x,
            direction.y * speed.y + rb.velocity.y
            );
    }

    public void ShowFloatingtext(string text)
    {
        GameObject obj = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform.parent);
        obj.GetComponent<TextMeshPro>().text = text;
    }

    public void TakeDamage(float value)
    {
        ShowFloatingtext(value.ToString());
        StartCoroutine(TakeDamageAnimation());
        health -= value;

        if (health <= 0)
        {
            Kill();
        }
    }

    public abstract void ChangeInimicalStatus();
    public abstract IEnumerator TakeDamageAnimation();
    public abstract IState GetInitState();
    public abstract void Damage();
    public abstract void DropLoot();
    public abstract void Kill();
    public float GetDefaultSpeed() => defaultSpeed;
    public float GetMaxSpeed() => maxSpeed;

}
