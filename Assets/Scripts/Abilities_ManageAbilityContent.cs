using UnityEngine;

public class Abilities_ManageAbilityContent : MonoBehaviour
{
    public GameObject AbilitiesDetailPanel;
    public GameObject[] AbilityContent;
    public GameObject AbilitySummaries;

    public void ToggleAbility(int abilityIndex)
    {
        AbilitySummaries.SetActive(false);
        AbilitiesDetailPanel.SetActive(true);
        for (int i = 0; i < AbilityContent.Length; i++)
        {
            AbilityContent[i].SetActive(i == abilityIndex);
        }
    }

    public void TurnOffAbilityDetail()
    {
        AbilitySummaries.SetActive(true);
        AbilitiesDetailPanel.SetActive(false);
    }
}
