using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TomeOfSpells : MonoBehaviour
{
    public Spells SpellData;
    private List<SpellStats> spellList = new List<SpellStats>();
    public RectTransform spellScrollViewContents;
    public GameObject SpellButton;

    //Spell Card UI Components
    public TextMeshProUGUI SpellName;
    public TextMeshProUGUI SpellLevel;
    public TextMeshProUGUI SchoolOfMagic;
    public GameObject SpellRitual;
    public TextMeshProUGUI CastingTimeData;
    public TextMeshProUGUI SpellRangeData;
    public TextMeshProUGUI SpellDurationData;
    public TextMeshProUGUI SpellComponentsData;
    public TextMeshProUGUI SpellBook;
    public TextMeshProUGUI SpellPage;
    public TextMeshProUGUI SpellClassesData;
    public TextMeshProUGUI SpellDescription;

    // Use this for initialization
    void Awake ()
    {
        PopulateSpellList();
        ShowSpellCard("Aid");
        //foreach (var spellItem in SpellData.dataArray)
        //{
        //    SpellStats spellStats = new SpellStats();
        //    spellStats.SpellName = spellItem.Spell;
        //    spellStats.
        //        spellList.Add(spellItem);

        //}

        //Crate a new TextMeshProUGUI and add the spell name to it
    }

    //Create a button for every spell in the PH
    private void PopulateSpellList()
    {
        float height = 0f;
        foreach (var spellItem in SpellData.dataArray)
        {
            GameObject spellButton = Instantiate(SpellButton, spellScrollViewContents.transform);
            spellButton.name = spellItem.Spell + " Btn";
            spellButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = spellItem.Spell;
            spellButton.GetComponent<Button>().onClick.AddListener(() => { ShowSpellCard(spellItem.Spell); });
            height = 358f * 40f;
        }
        spellScrollViewContents.sizeDelta = new Vector2(603f, height);
    }


    private void ShowSpellCard(string spellName)
    {
        print("Show spell card for " + spellName);
        foreach (var spellItem in SpellData.dataArray)
        {
            if (spellName == spellItem.Spell)
            {

                SpellName.text = spellItem.Spell;
                SpellLevel.text = spellItem.Level.ToString();
                SchoolOfMagic.text = spellItem.Category;
                SpellRitual.SetActive(spellItem.Ritual);
                CastingTimeData.text = spellItem.Castingtime;
                SpellRangeData.text = spellItem.Range;
                SpellDurationData.text = spellItem.Duration;
                SpellComponentsData.text = spellItem.Components;
                SpellBook.text = spellItem.Book;
                SpellPage.text = spellItem.Page.ToString();
                SpellClassesData.text = spellItem.Classes;
                SpellDescription.text = spellItem.Description;
                //SpellDescription.rectTransform.position = new Vector3(10f, 0f, 0f);
            }
        }
    }

    public string FormatSpellDescription(string spellDescription)
    {
        string formattedSpell;
        formattedSpell = spellDescription;
        formattedSpell.Replace("#", "<b>");
        return formattedSpell;
    }
}

public class SpellStats
{
    private string spellName;
    public string SpellName { get; set; }

    private short spellLevel;
    public short SpellLevel { get; set; }

    public enum Category {
        Abjuration, Conjuration, Divination,
        Enchantment, Evocation, Illusion,
        Necromancy, Transmutation
    };
    private Category category = Category.Abjuration;

    public Category GetCategory { get; set; }

    private bool isARitual;
    public bool IsARitual { get; set; }

    private string castingTime;
    public string CastingTime { get; set; }

    private string spellRange;
    public string SpellRange { get; set; }

    private string spellComponents;
    public string SpellComponents { get; set; }

    private string spellDuration;
    public string SpellDuration { get; set; }

    private string spellDescription;
    public string SpellDescription { get; set; }

    private string spellFromBook;
    public string SpellFromBook { get; set; }

    private int spellOnPage;
    public int SpellOnPage { get; set; }

    private string spellClasses;
    public string SpellClasses { get; set; }
}
