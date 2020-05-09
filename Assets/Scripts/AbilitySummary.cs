using UnityEngine;
using UnityEngine.UI;

public class AbilitySummary : MonoBehaviour
{
    public Button[] abilityPanelBtns;
    public GameObject abilitiesOverviewPanel;
    public GameObject abilitySkillsPanel;
    public GameObject abilityRacialAdjPanel;
    public GameObject[] abilityOverviewPanels;

    public void Button_ShowTab(GameObject tabPressed)
    {
        ManageTabButtonStates(tabPressed);
        ManageAllAbilityPanels(tabPressed);

        //Check if an ability btn was pressed
        switch (tabPressed.name)
        {
            case "Strength Btn":
                abilitiesOverviewPanel.SetActive(true);
                ManageAbilityOverviewPanels(abilityOverviewPanels[0]);
                break;
            case "Dexterity Btn":
                abilitiesOverviewPanel.SetActive(true);
                ManageAbilityOverviewPanels(abilityOverviewPanels[1]);
                break;
            case "Constitution Btn":
                abilitiesOverviewPanel.SetActive(true);
                ManageAbilityOverviewPanels(abilityOverviewPanels[2]);
                break;
            case "Intelligence Btn":
                abilitiesOverviewPanel.SetActive(true);
                ManageAbilityOverviewPanels(abilityOverviewPanels[3]);
                break;
            case "Wisdom Btn":
                abilitiesOverviewPanel.SetActive(true);
                ManageAbilityOverviewPanels(abilityOverviewPanels[4]);
                break;
            case "Charisma Btn":
                abilitiesOverviewPanel.SetActive(true);
                ManageAbilityOverviewPanels(abilityOverviewPanels[5]);
                break;
            default:
                break;
        }
    }

    public void ManageTabButtonStates(GameObject tabPressed)
    {
        print("ManageTabButtonStates();");
        for (int i = 0; i < abilityPanelBtns.Length; i++)
        {
            if (abilityPanelBtns[i].name == tabPressed.name)
            {
                abilityPanelBtns[i].transform.GetChild(0).gameObject.SetActive(false);
                abilityPanelBtns[i].transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                abilityPanelBtns[i].transform.GetChild(0).gameObject.SetActive(true);
                abilityPanelBtns[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void ManageAllAbilityPanels(GameObject tabPressed)
    {
        abilitiesOverviewPanel.SetActive(tabPressed.tag == "Ability Button");
        abilitySkillsPanel.SetActive(tabPressed.tag == "Skill Button");
        abilityRacialAdjPanel.SetActive(tabPressed.tag == "Racial Adj Button");
    }

    public void ManageAbilityOverviewPanels(GameObject tabSelected)
    {
        print("ManageAbilityOverviewPanels();");
        for (int i = 0; i < abilityOverviewPanels.Length; i++)
        {
            if (abilityOverviewPanels[i].name == tabSelected.name)
            {
                abilityOverviewPanels[i].SetActive(true);
            }
            else
            {
                abilityOverviewPanels[i].SetActive(false);
            }
        }
    }
}
