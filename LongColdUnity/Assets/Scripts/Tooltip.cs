using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private Transform transformBody;
    [SerializeField] private new TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float showInTime;

    [Header("Left Action")]
    [SerializeField] private GameObject leftActionBody;
    [SerializeField] private TextMeshProUGUI leftActionText;

    [Space]

    [Header("Right Action")]
    [SerializeField] private GameObject rightActionBody;
    [SerializeField] private TextMeshProUGUI rightActionText;

    private new Camera camera;
    private static float _time = 0;

    private static Tooltip _instance;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        camera = Camera.main;
    }

    private void Update()
    {
        transformBody.position = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    public static void Show(string name, string description = "", string leftClickText = "", string rightClickText = "")
    {
        _time += Time.deltaTime;
        if (_time < _instance.showInTime) return;

        _instance.transformBody.gameObject.SetActive(true);
        _instance.name.text = name;

        if (description != "")
        {
            _instance.description.gameObject.SetActive(true);
            _instance.description.text = description;
        }

        if (leftClickText != "")
        {
            _instance.leftActionBody.gameObject.SetActive(true);
            _instance.leftActionText.text = leftClickText;  
        }

        if (rightClickText != "")
        {
            _instance.rightActionBody.gameObject.SetActive(true);
            _instance.rightActionText.text = rightClickText;
        }
    }

    public static void Hide()
    {
        _time = 0;
        _instance.leftActionBody.gameObject.SetActive(false);
        _instance.leftActionText.text = "";
        _instance.rightActionBody.gameObject.SetActive(false);
        _instance.rightActionText.text = "";
        _instance.transformBody.gameObject.SetActive(false);
        _instance.description.text = "";
        _instance.description.gameObject.SetActive(false);


    }
}
