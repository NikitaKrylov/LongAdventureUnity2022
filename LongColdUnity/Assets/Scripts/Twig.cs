using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Twig : MonoBehaviour
{
    [SerializeField] private List<DropItem> dropItems = new List<DropItem>();
    private AudioSource breakSound;
    private bool isBreak = false;

    private void Start()
    {
        breakSound = GetComponent<AudioSource>();
    }
    public void DropAndDestroy()
    {
        if (isBreak) return;
        isBreak = true;
        foreach (DropItem item in dropItems)
        {
            Vector3 vector = Quaternion.AngleAxis(Random.Range(-360, 360), Vector3.forward) * Vector3.up;
            item.Drop(transform.position, Vector3.up * Random.Range(-45, 45), vector * 150);
        }


        if (breakSound != null) StartCoroutine(PlayBreakSoundAndDestroy());
        else Destroy(gameObject);

    }
    private IEnumerator PlayBreakSoundAndDestroy()
    {
        breakSound?.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;  
        yield return new WaitForSeconds(breakSound.clip.length);
        Destroy(gameObject);
    }
}
