using UnityEngine;

public interface IState 
{
    public abstract IState handleInput(GameObject obj);
    public abstract void Update();
    public abstract void OnEnter(GameObject gameObject);
    public abstract void OnExit();
}
