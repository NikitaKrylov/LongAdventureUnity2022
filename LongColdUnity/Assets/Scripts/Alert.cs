using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Alert : MonoBehaviour
{
    private ViewTime viewTime;
    private static Alert Instance { get; set; }

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject alertBody;
    [SerializeField] private Image timeLeftLine;

    private static bool viewIsActive = false;
    private float time;
    private float targetTime;

    public enum ViewTime
    {
        Short,
        Default,
        Long
    }

    
    void Awake()
    {
        if (Instance == null) Instance = this;
    }


    private void Update()
    {
        if (!viewIsActive) return;

        time += Time.deltaTime;
        UpdateTimeLeftLine();

        if (time > targetTime)
        {
            Close();
        }
    }


   


    private void SetText(string text)
    {
        this.text.text = text;
    }
    
    private void SetViewTime(ViewTime viewTime)
    {
        switch (viewTime)
        {
            case ViewTime.Short:
                targetTime = 2f;
                return;
            case ViewTime.Default:
                targetTime = 3.5f;
                return;
            case ViewTime.Long:
                targetTime = 4.5f;
                return;
        }
    }
    private void UpdateTimeLeftLine()
    {
        timeLeftLine.fillAmount = targetTime / time - 1;
    }

    public static void SendMessage(string message, ViewTime viewTime )
    {
        viewIsActive = true;
        Instance.alertBody.SetActive(true);
        Instance.SetText(message);
        Instance.SetViewTime(viewTime);
    }

    public static void Close()
    {
        Instance.alertBody.SetActive(false);
        viewIsActive = false;
        Instance.time = 0;
    }

}
