using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Food : AbstractItem
{
    public abstract void Use();
    public abstract void Use(Condition condition);
}
