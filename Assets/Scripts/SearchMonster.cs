using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SearchMonster : MonoBehaviour {

    public Transform MMContentParent;
    public List<GameObject> MMContents;
    public InputField MMSearchField;

    private void Start()
    {
        foreach (Transform child in MMContentParent)
        {
            MMContents.Add(child.gameObject);
        } 
    }

    public void ShowAllMonsters()
    {
        foreach (var monster in MMContents)
        {
            monster.gameObject.SetActive(true);
        }
    }

	public void FilterList()
    {
        foreach (var monster in MMContents)
        {
            if (monster.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Contains(MMSearchField.text))
            {
                monster.gameObject.SetActive(true);
            }
            else
            {
                monster.gameObject.SetActive(false);
            }
        }
    }
}
