using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public abstract class EnemyAnimal : MonoBehaviour, IEnemyMob 
{
    [Header("Speed")]
    [SerializeField] protected float defaultSpeed;
    [SerializeField] protected float maxSpeed;
    [Space]

    [SerializeField] protected float maxHealth;
    [Space]

    [SerializeField] protected float damage;
    [Space]

    [SerializeField] private GameObject floatingTextPrefab;

    protected float health;
    private Animator _animotor;
    private Rigidbody2D _rb;
    public Animator animator { get { return _animotor; } }
    public Rigidbody2D rb { get { return _rb; } }

    protected FSM fsm;
    public abstract float triggerDistance { get; }


    protected virtual void Start()
    {
        health = maxHealth;
        _rb = GetComponent<Rigidbody2D>();
        _animotor = GetComponent<Animator>();
        fsm = new FSM(gameObject, GetInitState());
    }
    protected void Update()
    {
        fsm.Update();
    }
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

    public virtual void TakeDamage(float value)
    {
        ShowFloatingtext(value.ToString());
        StartCoroutine(TakeDamageAnimation());
        health -= value;

        if (health <= 0)
        {
            Kill();
        }
    }

    public abstract void Damage();
    public abstract void Kill();
    public abstract void DropLoot();
    public abstract IState GetInitState();
    public abstract IEnumerator TakeDamageAnimation();
    public float GetDefaultSpeed() => defaultSpeed;
    public float GetMaxSpeed() => maxSpeed;
}
