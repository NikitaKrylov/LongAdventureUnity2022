using UnityEngine;

public interface IState 
{
    public abstract IState handleInput(GameObject obj);
    public abstract void Update();
    public abstract void OnEnter(GameObject obj);
    public abstract void OnExit();
}
