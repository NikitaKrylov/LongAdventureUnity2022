using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointDownHeandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PointerEventData.InputButton mouseClickType = PointerEventData.InputButton.Left;
    public float pressTime = .3f;
    public string tooltip;
    public float delta { get; private set; }
    private bool _isPressed = false;
    public UnityEvent PointEvent;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != mouseClickType) return;

        _isPressed = true;
        delta = 0;
        CircleProgress.ResetProgress();
        CircleProgress.SetTooltip(tooltip ?? "");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button != mouseClickType) return;

        _isPressed = false;
        delta = 0;
        CircleProgress.ResetProgress();
        CircleProgress.SetTooltip("");

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
