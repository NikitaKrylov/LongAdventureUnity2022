using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;

    private MovementLogic _movement;
    private Vector2 _direction;

    void Start()
    {
        _animator = GetComponent<Animator>();   
        _movement = GetComponent<MovementLogic>();
        _direction = _movement.direction();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayTakeAnimation();
        }

        _direction = _movement.direction();
        if (Mathf.Abs(_direction.x) > 0.1)
        {
            StartRunAnimation();
            Flip(new Vector3(Mathf.Sign(_direction.x), 1, 1));
        }
        else
        {
            StopRunAnimation();
        }

        
    }

    public void Flip(Vector3 newDirection)
    {
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x) * newDirection.x,
            Mathf.Abs(transform.localScale.y) * newDirection.y,
            Mathf.Abs(transform.localScale.z) * newDirection.z
            );
    }
    public void PlayTakeAnimation() => _animator.SetTrigger("Take");   
    public void StartRunAnimation() => _animator.SetBool("IsRunning", true);
    public void StopRunAnimation() => _animator.SetBool("IsRunning", false);


}
