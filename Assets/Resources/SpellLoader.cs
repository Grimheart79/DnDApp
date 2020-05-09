using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellLoader : MonoBehaviour
{
    public const string path = "Spells";

    public GameObject spellCard;
    private Text textBox;

    void Start()
    {
        SpellManager ic = SpellManager.Load(path);

        foreach (var spell in ic.spells)
        {
            GameObject itemGO = new GameObject("ItemGO");
            itemGO.transform.SetParent(spellCard.transform, false);

            //RectTransform trans = itemGO.AddComponent<RectTransform>();

            Text text = itemGO.AddComponent<Text>();
            text.text = spell.name;
            text.fontSize = 12;
            text.color = Color.black;
            print(spell.name);
        }
    }
}
