using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State 
{
    public abstract void Update(float deltaTime = 1);
    public abstract void Input();
}
