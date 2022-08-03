using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMob : IMob
{
    public void Damage();
    public float triggerDistance { get; }

}
