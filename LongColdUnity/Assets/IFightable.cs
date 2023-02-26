using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFightable : ILivable
{
    public float damageValue { get; }
    public void Attack(IFightable entity);

}
