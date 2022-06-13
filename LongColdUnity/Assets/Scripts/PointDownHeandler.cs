using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class PointDownHeandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float pressTime = .3f;
    public float delta { get; private set; }
    private bool _isPressed = false;
    public UnityEvent PointEvent;


    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        delta = 0;
        CircleProgress.ResetProgress();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
        delta = 0;
        CircleProgress.ResetProgress();
    }

    private void FixedUpdate()
    {
        if (_isPressed)
        {
            delta += Time.deltaTime;
            CircleProgress.ChangeProgress(delta / pressTime);
            if (delta >= pressTime)
            {
                PointEvent.Invoke();
                CircleProgress.ResetProgress();

            }


        }
    }
}
