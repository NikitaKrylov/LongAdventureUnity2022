using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboHit", menuName = "ScriptableObjects/ComboHit")]
public class ComboHit : ScriptableObject
{
    public AnimationClip clip;
    public ComboHit previousComboHit = null;
    public ComboHit nextComboHit = null;
   
    public float clipLength { get { return clip.length; } }
    public string triggerName { get { return clip.name; } }
    public float addedOffset = 0;

    [Header("��������� Rigidbody2D �� ����� ��������")]
    public bool useRigidbody2DChanging = false;
    public Vector2 force;


    public void Play(Animator anim)
    {
        anim.SetTrigger(triggerName);
    }
    public void Stop(Animator anim)
    {
        anim.ResetTrigger(triggerName);

    }

}
