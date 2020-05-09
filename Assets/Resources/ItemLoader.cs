using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemLoader : MonoBehaviour
{
    public const string path = "items";
    public GameObject itemNamePanel;
    public GameObject itemCard; //prefab

    void Start()
    {
        ItemContainer ic = ItemContainer.Load(path);

        //TODO: Create a more robust Item Card instantiator
        foreach (var item in ic.items)
        {
            GameObject itemGO = Instantiate(itemCard, transform.position, Quaternion.identity) as GameObject;
            itemGO.transform.SetParent(itemNamePanel.transform, false);

            itemGO.name = item.name;
            Text nameText = itemGO.transform.Find("Item Name Text").GetComponent<Text>();
            nameText.text = item.name;
            Text costText = itemGO.transform.Find("Item Cost Text").GetComponent<Text>();
            costText.text = item.cost;
            Text weightText = itemGO.transform.Find("Item Weight Text").GetComponent<Text>();
            weightText.text = item.weight.ToString() + "lbs";
            Text descText = itemGO.transform.Find("Item Description Text").GetComponent<Text>();
            descText.text = item.description;
        }
    }
	
}
