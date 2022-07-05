using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Alert : MonoBehaviour
{
    private ViewTime viewTime;
    private static Alert Instance { get; set; }
    private Text text;
    private Image image;

    private static bool viewIsActive = false;
    private float time;
    private float targetTime;

    public enum ViewTime
    {
        Short,
        Default,
        Long
    }

    private void Awake()
    {
        Debug.Log(1);
    }
    void Start()
    {
        Debug.Log(2);

        if (Instance == null) Instance = this;
        text = GetComponent<Text>();
        image = GetComponent<Image>();
    }


    private void Update()
    {
        if (!viewIsActive) return;

        time += Time.deltaTime;

        if (time > targetTime)
        {
            gameObject.SetActive(false);
            viewIsActive = false;
        }
    }


    private void OnEnable()
    {
        time = 0;
    }

    private void OnDisable()
    {
        time = 0;
    }


    private void SetText(string text)
    {
        this.text.text = text;
    }
    private void SetColor(Color color)
    {
        image.color = color;
    }
    private void SetViewTime(ViewTime viewTime)
    {
        switch (viewTime)
        {
            case ViewTime.Short:
                targetTime = 1.5f;
                return;
            case ViewTime.Default:
                targetTime = 2.5f;
                return;
            case ViewTime.Long:
                targetTime = 4;
                return;
        }
    }

    public static void SendMessage(string message, ViewTime viewTime ,Color alerColor)
    {
        viewIsActive = true;
        Instance.gameObject.SetActive(true);
        Instance.SetText(message);
        Instance.SetColor(alerColor);
    }

}
