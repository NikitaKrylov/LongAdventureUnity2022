using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeutralMob : IMob
{
    public void Damage();
    public void ChangeInimicalStatus();
}
