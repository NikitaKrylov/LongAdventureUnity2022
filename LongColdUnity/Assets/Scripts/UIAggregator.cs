using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class UIAggregator : MonoBehaviour
{
    public List<AggregationComponent> aggregationComponents = new List<AggregationComponent>();
    private AggregationComponent _currentComponent;
    public bool closeAllOnDisable = false;

    public enum AgreggationTypes
    {
        Replace,
        Overlap,
        Stack
    };
    public AgreggationTypes AgreggationType;

    private void Start()
    {
        aggregationComponents.ForEach(a => a.SetAggregator(this));
    }

    private void OnDisable()
    {
        if (closeAllOnDisable) CloseAll();
    }

    public void AddAggregationComponent(AggregationComponent component)
    {
        aggregationComponents.Add(component);
        component.SetAggregator(this);
    }

    public void Show(AggregationComponent component)
    {
        _currentComponent = component;
        switch (AgreggationType)
        {
            case AgreggationTypes.Replace:
                Replace(component);
                return;
            case AgreggationTypes.Overlap:
                Overlap(component);
                return;
        }
    }
    public void Close(AggregationComponent component)
    {
        component.SetActive(false);
        _currentComponent = null;
    }
    public void CloseAll()
    {
        foreach (AggregationComponent component in aggregationComponents)
        {
            Close(component);
        }
    }

    public void Overlap(AggregationComponent component)
    {
        foreach (AggregationComponent _component in aggregationComponents)
        {
            if (_component == component) 
            { 
                
            }
        }
    }
    public void Replace(AggregationComponent component)
    {
        foreach (AggregationComponent _component in aggregationComponents)
        {
            if (component == _component)
            {
                _currentComponent = _component;
                _currentComponent.SetActive(true);
            }
            else
            {
                _component.SetActive(false);
            }
        }
    }
    

    private AggregationComponent Find(AggregationComponent component) {
        return aggregationComponents.Find(cp => cp == component);
    }

}



