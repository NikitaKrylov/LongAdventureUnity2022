using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonfireMenu : MonoBehaviour
{
    [SerializeField] private GameObject fuelViewItem;
    [SerializeField] private Transform fuelViewList;
    [SerializeField] private Text temperature;
    [SerializeField] private Text burningTime;

    public BonfireController bonfireController;
    public static BonfireMenu Instance { get; private set; }

    private List<GameObject> fuelViewEobjects = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;

    }

    private void Update()
    {
        burningTime.text = $"{bonfireController.GetWorkTime() / 3600}ч {bonfireController.GetWorkTime() / 60}мин {bonfireController.GetWorkTime() % 60}сек";
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
