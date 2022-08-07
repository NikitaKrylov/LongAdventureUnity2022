using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMob 
{
    public void TakeDamage(float value);
    public void Kill();
    public void DropLoot();
    public IEnumerator TakeDamageAnimation();
    public IState GetInitState();
    public void Move(Vector2 speed, Vector2 direction);
    public void ShowFloatingtext(string text);
}
