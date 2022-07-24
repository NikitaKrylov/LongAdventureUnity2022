using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class AggregationComponent : MonoBehaviour
{
    public bool isActive { get { return gameObject.activeSelf; } }
    public UIAggregator aggregator;
    public bool stopTimeOnEnabled = false;

    public UnityEvent OnEnable;
    public UnityEvent OnDisable;

    public void SetAggregator(UIAggregator aggregator)
    {
        this.aggregator = aggregator;
    }
    public void Close()
    {
        aggregator.Close(this);
        OnDisable?.Invoke();
        if (stopTimeOnEnabled) Time.timeScale = 1;
    }
    public void Show()
    {
        aggregator.Show(this);
        OnEnable?.Invoke();
        if (stopTimeOnEnabled) Time.timeScale = 0;
    }
    public void Execute()
    {
        if (isActive) Close();
        else Show();
    }
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }


}
