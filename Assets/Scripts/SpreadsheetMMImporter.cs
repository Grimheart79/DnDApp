using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using System.Linq;

public class SpreadsheetMMImporter : MonoBehaviour
{
    public MM MonsterManualData;
    public List<Monster> MonsterList = new List<Monster>();

    [Header("MM Bookmark Elements")]
    public GameObject MMBookmarkContent;
    public GameObject MMMonsterButton;

    [Header("MM Content Elements")]
    public GameObject MMStatBlock;
    public TextMeshProUGUI MonsterNameText;
    public TextMeshProUGUI MonsterBookText;
    public TextMeshProUGUI TypeSummary;
    public TextMeshProUGUI ChallengeText;
    public TextMeshProUGUI ACText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI SpeedText;

    [Header("MM Ability Elements")]
    public TextMeshProUGUI STRText;
    public TextMeshProUGUI DEXText;
    public TextMeshProUGUI CONText;
    public TextMeshProUGUI INTText;
    public TextMeshProUGUI WISText;
    public TextMeshProUGUI CHAText;
    public TextMeshProUGUI STRSaveText;
    public TextMeshProUGUI DEXSaveText;
    public TextMeshProUGUI CONSaveText;
    public TextMeshProUGUI INTSaveText;
    public TextMeshProUGUI WISSaveText;
    public TextMeshProUGUI CHASaveText;

    [Header("MM Stats 2 Elements")]
    public GameObject SkillsRowGO;
    public TextMeshProUGUI SkillsText;
    public GameObject DVRowGO;
    public TextMeshProUGUI DamageVulnText;
    public GameObject DRRowGO;
    public TextMeshProUGUI DamageResistText;
    public GameObject DIRowGO;
    public TextMeshProUGUI DamageImmuneText;
    public GameObject CIRowGO;
    public TextMeshProUGUI ConditionImmuneText;
    public GameObject SpeechRowGO;
    public TextMeshProUGUI SensesText;
    public TextMeshProUGUI LanguagesText;

    [Header("Notes, Actions, Reactions, Legendary Actions")]
    public GameObject NotesTitleGO;
    public GameObject NotesTextGO;
    public GameObject NotesSpaceGO;
    public TextMeshProUGUI NotesText;

    public GameObject ActionsTitleGO;
    public GameObject ActionsTextGO;
    public GameObject ActionsSpaceGO;
    public TextMeshProUGUI ActionsText;

    public GameObject ReactionsTitleGO;
    public GameObject ReactionsTextGO;
    public GameObject ReactionsSpaceGO;
    public TextMeshProUGUI ReactionsText;

    public GameObject LegendaryTitleGO;
    public GameObject LegendaryTextGO;
    public TextMeshProUGUI LegendaryActionsText;

    // Extract all monsters from the MM spreadsheet and populate the monsters list
    void Awake ()
    {
        foreach (var monster in MonsterManualData.dataArray)
        {
            Monster m = new Monster
            {
                Group = monster.Group,
                Name = monster.Name,
                Book = monster.Book,
                Challenge = monster.Challenge,
                CreatureSize = monster.Creaturesize,
                CreatureAlign = monster.Creaturealignment,
                CreatureType = monster.Creaturetype,
                AC = monster.AC,
                ArmourNotes = monster.Armournotes,
                HP = monster.HP,
                HD = monster.HD,
                Saves = monster.Saves,
                DamageVulnerabilities = monster.Damagevulnerabilities,
                DamageResistances = monster.Damageresistances,
                DamageImmunities = monster.Damageimmunities,
                ConditionImmunities = monster.Conditionimmunities,
                Speed = monster.Speed,
                Strength = monster.Str,
                Dexterity = monster.Dex,
                Constitution = monster.Con,
                Intelligence = monster.Intel,
                Wisdom = monster.Wis,
                Charisma = monster.Cha,
                Senses = monster.Senses,
                PassivePerception = monster.Passiveperception,
                Languages = monster.Languages,
                Skills = monster.Skills,
                Actions = monster.Actions,
                Reactions = monster.Reactions,
                Notes = monster.Notes,
                LegendaryActions = monster.Legendaryactions
            };
            MonsterList.Add(m);
        }
        PopulateMonsterBookmark();
        //print(MonsterList[0].CreateMonsterSummary());
    }

    //Create a button for every monster in the MM bookmark
    private void PopulateMonsterBookmark()
    {
        foreach (var monster in MonsterList)
        {
            GameObject MMButton = Instantiate(MMMonsterButton, MMBookmarkContent.transform);
            MMButton.name = monster.Name + " Btn";
            MMButton.transform.GetComponentInChildren<TextMeshProUGUI>().text = monster.Name;
            MMButton.GetComponent<Button>().onClick.AddListener(() => { ShowMonsterCard(monster.Name); });
        }
    }

    private void ShowMonsterCard(string monsterName)
    {
        print("Show monster card for " + monsterName);
        //Show the monster stat block
        if (!MMStatBlock.activeSelf)
        {
            MMStatBlock.SetActive(true);
        }
        foreach (var monster in MonsterList)
        {
            if (monster.Name == monsterName)
            {
                MonsterNameText.text = monster.Name;
                MonsterBookText.text = monster.Book;
                TypeSummary.text = monster.CreateMonsterSummary();
                ChallengeText.text = monster.Challenge + " (" + GetXPValue(monster.Challenge) +" XP)";
                ACText.text = monster.CreateArmourText();
                HPText.text = monster.CreateHPText();
                SpeedText.text = monster.Speed;
                STRText.text = monster.CreateAbilityText(monster.Strength);
                DEXText.text = monster.CreateAbilityText(monster.Dexterity);
                CONText.text = monster.CreateAbilityText(monster.Constitution);
                INTText.text = monster.CreateAbilityText(monster.Intelligence);
                WISText.text = monster.CreateAbilityText(monster.Wisdom);
                CHAText.text = monster.CreateAbilityText(monster.Charisma);
                string[] saves = monster.Saves.Split(',');
                print(saves);
                foreach (var substring in saves)
                {
                    if (substring.Contains("Str"))
                    {
                        monster.StrSave = ReturnDigitsFromString(substring);
                        STRSaveText.text = " +" + monster.StrSave;
                    }
                    else { STRSaveText.text = ""; }

                    if (substring.Contains("Dex"))
                    {
                        monster.DexSave = ReturnDigitsFromString(substring);
                        DEXSaveText.text = " +" + monster.DexSave;
                    }
                    else { DEXSaveText.text = ""; }
                    if (substring.Contains("Con"))
                    {
                        monster.ConSave = ReturnDigitsFromString(substring);
                        CONSaveText.text = " +" + monster.ConSave;
                    }
                    else { CONSaveText.text = ""; }
                    if (substring.Contains("Int"))
                    {
                        monster.IntSave = ReturnDigitsFromString(substring);
                        INTSaveText.text = " +" + monster.IntSave;
                    }
                    else { INTSaveText.text = ""; }
                    if (substring.Contains("Wis"))
                    {
                        monster.WisSave = ReturnDigitsFromString(substring);
                        WISSaveText.text = " +" + monster.WisSave;
                    }
                    else { WISSaveText.text = ""; }
                    if (substring.Contains("Cha"))
                    {
                        monster.ChaSave = ReturnDigitsFromString(substring);
                        CHASaveText.text = " +" + monster.ChaSave;
                    }
                    else { CHASaveText.text = ""; }
                }

                SkillsRowGO.SetActive(monster.Skills != "NA");
                SkillsText.text = monster.Skills;

                SensesText.text = (monster.Senses == "NA") ? "passive Perception " : monster.Senses + ", passive Perception ";
                SensesText.text = SensesText.text + monster.PassivePerception.ToString();

                DVRowGO.SetActive(monster.DamageVulnerabilities != "NA");
                DamageVulnText.text = monster.DamageVulnerabilities;

                DRRowGO.SetActive(monster.DamageResistances != "NA");
                DamageResistText.text = monster.DamageResistances;

                DIRowGO.SetActive(monster.DamageImmunities != "NA");
                DamageImmuneText.text = monster.DamageImmunities;

                CIRowGO.SetActive(monster.ConditionImmunities != "NA");
                ConditionImmuneText.text = monster.ConditionImmunities;

                SpeechRowGO.SetActive(monster.Languages != "NA");
                LanguagesText.text = monster.Languages;

                //If the note is NA then turn off the text box altogether
                NotesTitleGO.SetActive(monster.Notes != "NA");
                NotesTextGO.SetActive(monster.Notes != "NA");
                NotesSpaceGO.SetActive(monster.Notes != "NA");
                NotesText.text = monster.Notes;

                ActionsTitleGO.SetActive(monster.Actions != "NA");
                ActionsTextGO.SetActive(monster.Actions != "NA");
                ActionsSpaceGO.SetActive(monster.Actions != "NA");
                ActionsText.text = monster.Actions;

                ReactionsTitleGO.SetActive(monster.Reactions != "NA");
                ReactionsTextGO.SetActive(monster.Reactions != "NA");
                ReactionsSpaceGO.SetActive(monster.Reactions != "NA");
                ReactionsText.text = monster.Reactions;

                LegendaryTitleGO.SetActive(monster.LegendaryActions != "NA");
                LegendaryTextGO.SetActive(monster.LegendaryActions != "NA");
                LegendaryActionsText.text = monster.LegendaryActions;
            }
        }
    }

    private string ReturnDigitsFromString(string subString)
    {
        string saveThrowDigit = new String(subString.Where(Char.IsDigit).ToArray());
        return saveThrowDigit;
    }

    private string GetXPValue(string CR)
    {
        if (CR == "0")
        {
            return 0.ToString();
        }
        else if (CR == "1/8")
        {
            return 25.ToString();
        }
        else if (CR == "1/4")
        {
            return 50.ToString();
        }
        else if (CR == "1/2")
        {
            return 100.ToString();
        }
        else if (CR == "1")
        {
            return 200.ToString();
        }
        else if (CR == "2")
        {
            return 450.ToString();
        }
        else if (CR == "3")
        {
            return 700.ToString();
        }
        else if (CR == "4")
        {
            return 1100.ToString();
        }
        else if (CR == "5")
        {
            return 1800.ToString();
        }
        else if (CR == "6")
        {
            return 2300.ToString();
        }
        else if (CR == "7")
        {
            return 2900.ToString();
        }
        else if (CR == "8")
        {
            return 3900.ToString();
        }
        else if (CR == "9")
        {
            return 5000.ToString();
        }
        else if (CR == "10")
        {
            return 5900.ToString();
        }
        else if (CR == "11")
        {
            return 7200.ToString();
        }
        else if (CR == "12")
        {
            return 8400.ToString();
        }
        else if (CR == "13")
        {
            return 10000.ToString();
        }
        else if (CR == "14")
        {
            return 11500.ToString();
        }
        else if (CR == "15")
        {
            return 13000.ToString();
        }
        else if (CR == "16")
        {
            return 15000.ToString();
        }
        else if (CR == "17")
        {
            return 18000.ToString();
        }
        else if (CR == "18")
        {
            return 20000.ToString();
        }
        else if (CR == "19")
        {
            return 22000.ToString();
        }
        else if (CR == "20")
        {
            return 25000.ToString();
        }
        else if (CR == "21")
        {
            return 33000.ToString();
        }
        else if (CR == "22")
        {
            return 41000.ToString();
        }
        else if (CR == "23")
        {
            return 50000.ToString();
        }
        else if (CR == "24")
        {
            return 62000.ToString();
        }
        else if (CR == "25")
        {
            return 75000.ToString();
        }
        else if (CR == "26")
        {
            return 90000.ToString();
        }
        else if (CR == "27")
        {
            return 105000.ToString();
        }
        else if (CR == "28")
        {
            return 120000.ToString();
        }
        else if (CR == "29")
        {
            return 135000.ToString();
        }
        else //(CR == "30")
        {
            return 155000.ToString();
        }
    }
}

public class Monster
{
    #region vars
    public string Group;
    public string Book;
    public string Name;
    public string Challenge;
    public string CreatureSize;
    public string CreatureAlign;
    public string CreatureType;
    public short AC;
    public string ArmourNotes;
    public int HP;
    public string HD;
    public string Saves;
    private string strSave = "";
    public string StrSave { get; set; }
    private string dexSave = "";
    public string DexSave { get; set; }
    private string conSave = "";
    public string ConSave { get; set; }
    private string intSave = "";
    public string IntSave { get; set; }
    private string wisSave = "";
    public string WisSave { get; set; }
    private string chaSave = "";
    public string ChaSave { get; set; }
    public string DamageVulnerabilities;
    public string DamageResistances;
    public string DamageImmunities;
    public string ConditionImmunities;
    public string Speed;
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
    public string Senses;
    public int PassivePerception;
    public string Languages;
    public string Skills;
    public string Actions;
    public string Reactions;
    public string Notes;
    public string LegendaryActions;
    #endregion

    public string CreateMonsterSummary()
    {
        string monsterSummary = "";
        switch (CreatureSize)
        {
            case "T":
                monsterSummary = "Tiny";
                break;
            case "S":
                monsterSummary = "Small";
                break;
            case "M":
                monsterSummary = "Medium ";
                break;
            case "L":
                monsterSummary = "Large ";
                break;
            case "H":
                monsterSummary = "Huge ";
                break;
            case "G":
                monsterSummary = "Gargantuan ";
                break;
            default:
                break;
        }
        monsterSummary = monsterSummary + CreatureType + ", " + CreatureAlign;
        return monsterSummary;
    }

    public string CreateArmourText()
    {
        string armourText = "";
        armourText = AC.ToString();
        if (!ArmourNotes.Contains("NA"))
        {
            armourText = armourText + " (" + ArmourNotes + ")";
        }
        return armourText;
    }

    public string CreateHPText()
    {
        string hpText = "";
        hpText = HP.ToString() + " (" + HD + ")";
        return hpText;
    }

    public string CreateAbilityText(int Ability)
    {
        string ability = "";
        ability = Ability.ToString();

        string modString = "";
        float mod = Utilities.GetAbilityMod(Ability);

        modString = (mod > 0) ? "+" + mod.ToString() : modString = mod.ToString();
        return ability = Ability.ToString() + "(" + modString + ")";
    }
}
