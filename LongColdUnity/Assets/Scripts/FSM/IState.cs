using UnityEngine;

public interface IState 
{
    /// <summary>
    /// �������� ���������
    /// </summary>
    public abstract IState handleInput(GameObject obj);
    
    public abstract void Update();

    /// <summary>
    /// �������� ��� ������ ���������
    /// </summary>
    public abstract void OnEnter(GameObject obj);
    
    public abstract void OnExit();
}
