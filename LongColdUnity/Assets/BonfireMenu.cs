using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonfireMenu : MonoBehaviour
{
    [SerializeField] private GameObject fuelViewItem;
    [SerializeField] private Transform fuelViewList;
    [SerializeField] private Text temperature;
    [SerializeField] private Text burningTime;
    [SerializeField] private Text stateName;
    [SerializeField] private Image fireLogo;

    public BonfireController bonfireController;
    public static BonfireMenu Instance { get; private set; }

    private List<GameObject> fuelViewEobjects = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;

    }

    private void Update()
    {
        if (bonfireController.bonfireWorkType == BonfireController.BonfireWorkType.Extinct)
        {
            burningTime.text = "��������� ������";
            stateName.text = "(�����)";
        }
        else
        {
            burningTime.text = $"{((int)bonfireController.GetWorkTime()) / 3600}� {(int)bonfireController.GetWorkTime() / 60}��� {(int)bonfireController.GetWorkTime() % 60}���";
            stateName.text = "(�����)";
        }
        fireLogo.fillAmount = bonfireController.GetWorkTime() / bonfireController.GetWorkTimeThreshold();
    }

    private void OnEnable()
    {
        fuelViewEobjects.ForEach(e => Destroy(e.gameObject));
        fuelViewEobjects.Clear();
        CreateFuilViewItems(Player.GetInstance().inventory.items);
    }

    private void CreateFuilViewItems(List<Item> items)
    {
        foreach (Item item in items)
        {
            if (item.currentItem is BurningMaterial) // Fuel
            {
                GameObject obj = Instantiate(fuelViewItem, fuelViewList);
                FuelPanel fp = obj.GetComponent<FuelPanel>();

                obj.GetComponentInChildren<Button>().onClick.AddListener(delegate {
                    bonfireController.UpdateWorkTime(((BurningMaterial)item.currentItem).fuelValue); //((Fuel)item.currentItem).fuelValue
                    if (item.count - 1 <= 0)
                    {
                        Destroy(obj);
                    }
                    item.Remove(1);
                    fp.SetData(item);

                });
                fp.SetData(item);
                fuelViewEobjects.Add(obj);
            } 
        }
    }


    public void SetController(BonfireController bc)
    {
        bonfireController = bc;
    }
}
