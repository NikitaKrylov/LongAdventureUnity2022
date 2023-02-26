using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivable 
{
    float Health { get; set; }
    public void Damage(float value);
    public void Kill();
}
