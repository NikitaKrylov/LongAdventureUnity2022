using UnityEngine;

public interface IState<TEntity> where TEntity : MonoBehaviour
{

    public abstract IState<TEntity> handleInput(TEntity entity);
    public abstract void Update();
    public abstract void OnEnter(TEntity entity); 
    public abstract void OnExit();
}
