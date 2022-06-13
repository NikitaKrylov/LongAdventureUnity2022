using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventoryViewCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    private Item _ii;
    public Item ii { 
        get { return _ii; }
        set { 
            _ii = value; 
            UpdateCell();
        }
    }

    public Transform _originParent;
    public Transform _draggingParent;
    public UnityAction<InventoryViewCell> OnClickAction;
    private CanvasGroup _canvasGroup;

    [SerializeField] private Text countText;
    [SerializeField] private Image image;
    [SerializeField] private GameObject tooltipeObject;

    public bool isDragging { get; private set; } = false;   
    public int count
    {
        get => ii.count;
        
    }
    
    public void SetImage(Sprite sprite)
    {
        this.image.sprite = sprite;
    }

    public void UpdateCell()
    {
        SetImage(ii.currentItem.image);
        countText.text = count.ToString();
    }

    private UnityAction<InventoryViewCell> GetOnClickAction()
    {
        return OnClickAction;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { OnClickAction(this); });
        _canvasGroup = GetComponent<CanvasGroup>();
        tooltipeObject.GetComponentInChildren<Text>().text = ii.currentItem.name;
    }

    

    //Drag events
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(_draggingParent, false);
        isDragging = true;
        _canvasGroup.alpha = .75f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 v = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(v.x, v.y, transform.position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_originParent, false);
        isDragging = false;
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipeObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDragging) tooltipeObject.SetActive(true);
    }
}
