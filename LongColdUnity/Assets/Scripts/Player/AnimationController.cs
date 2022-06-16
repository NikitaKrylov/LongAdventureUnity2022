using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 defaultScale;

    [SerializeField] private EditableImage sleepingImage;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        defaultScale = gameObject.transform.localScale; 
    }

    void Update()
    {
        //float directionX = Input.GetAxis("Horizontal");
        ////float directionY = Input.GetAxis("Vertical");

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    PlayTakeAnimation();
        //}
        
        //if (Mathf.Abs(directionX) > 0.3)
        //{
        //    StartRunAnimation();
        //    Flip(new Vector3(Mathf.Sign(directionX), 1, 1));
        //}
        //else
        //{
        //    StopRunAnimation();
        //}

        
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
    public void PlaySleepingAnimation()
    {
        _animator.enabled = false;
        _spriteRenderer.sprite = sleepingImage.sprite;
        gameObject.transform.localScale = sleepingImage.scale;
    }
    public void StopSleepingAnimation()
    {
        _animator.enabled = true;
        gameObject.transform.localScale = defaultScale;

    }

    [Serializable]
    private class EditableImage
    {
        public Sprite sprite;
        public Vector3 scale;
    }

}
