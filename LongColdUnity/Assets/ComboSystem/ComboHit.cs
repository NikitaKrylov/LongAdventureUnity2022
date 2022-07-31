using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboHit", menuName = "ScriptableObjects/ComboHit")]
public class ComboHit : ScriptableObject
{
    public AnimationClip clip;
    public ComboHit nextComboHit = null;
    public AudioClip audioClip;
   
    public float clipLength { get { return clip.length; } }
    public string triggerName { get { return clip.name; } }

    [Header("Изменение Rigidbody2D во время анимации")]
    public Vector2 rigidbody2DForce = Vector2.zero;


    public void Play(Animator anim)
    {
        anim.SetTrigger(triggerName);
    }
    public void Stop(Animator anim)
    {
        anim.ResetTrigger(triggerName);

    }

}
