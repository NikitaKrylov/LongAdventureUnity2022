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


    public void Play(Animator anim)
    {
        //anim.Play(clip.name);
        anim.SetTrigger(triggerName);

        Debug.Log(triggerName);
    }
    public void Stop(Animator anim)
    {
        anim.ResetTrigger(triggerName);

    }

}
