using UnityEngine;

public class MovementLogic : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 _direction = Vector2.zero;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(_direction.x * speed, rb.velocity.y);
    }

    public Vector2 direction() { 
        return _direction;
    }
}
