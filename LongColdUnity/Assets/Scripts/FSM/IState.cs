using UnityEngine;

public interface IState 
{
    /// <summary>
    /// Менеджер переходов
    /// </summary>
    public abstract IState handleInput(GameObject obj);
    
    public abstract void Update();

    /// <summary>
    /// Действие при старте состояния
    /// </summary>
    public abstract void OnEnter(GameObject obj);
    
    public abstract void OnExit();
}
