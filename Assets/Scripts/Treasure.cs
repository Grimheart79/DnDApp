using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Treasure : MonoBehaviour
{
    //Import spreadsheet data for gems and art objects
    public GemsAndArtObjects gemsAndArtObjectData;
    private List<Gemstone> gemsWorth10GP = new List<Gemstone>();
    private List<Gemstone> gemsWorth50GP = new List<Gemstone>();
    private List<Gemstone> gemsWorth100GP = new List<Gemstone>();
    private List<Gemstone> gemsWorth500GP = new List<Gemstone>();
    private List<Gemstone> gemsWorth1000GP = new List<Gemstone>();
    private List<Gemstone> gemsWorth5000GP = new List<Gemstone>();
    private List<ArtObject> artWorth25GP = new List<ArtObject>();
    private List<ArtObject> artWorth250GP = new List<ArtObject>();
    private List<ArtObject> artWorth750GP = new List<ArtObject>();
    private List<ArtObject> artWorth2500GP = new List<ArtObject>();
    private List<ArtObject> artWorth7500GP = new List<ArtObject>();

    //Manage toggle for individual or hoard treasure
    public Toggle indHoardToggle;
    public TextMeshProUGUI indHoardToggleText;

    //Get UI components for treasure panel
    public RectTransform TreasureFoundPanel;
    public TextMeshProUGUI TreasureSubTitle;
    public GameObject TreasureTextPrefab;

    //Enums
    public enum GemWorths { Gem10, Gem50, Gem100, Gem500, Gem1000, Gem5000 };
    public GemWorths currentGemWorthEnum = GemWorths.Gem10;
    public enum ArtWorths { Art25, Art250, Art750, Art2500, Art7500 };
    public ArtWorths currentArtWorthEnum = ArtWorths.Art25;

    private void Awake()
    {
        ExtractGemData();
        ExtractArtData();
    }

    #region Extract spreadsheet data
    /// <summary>
    /// Pulls all gem data from the spreadsheet, creates a gemstone struct for each gem
    /// and then assigns the gems to a specific table based on gem worth
    /// </summary>
    public void ExtractGemData()
    {
        foreach (var gem in gemsAndArtObjectData.dataArray)
        {
            Gemstone gemstone = new Gemstone
            {
                desc = gem.Description,
                worth = gem.Worth
            };

            switch (gemstone.worth)
            {
                case 10:
                    gemsWorth10GP.Add(gemstone);
                    break;
                case 50:
                    gemsWorth50GP.Add(gemstone);
                    break;
                case 100:
                    gemsWorth100GP.Add(gemstone);
                    break;
                case 500:
                    gemsWorth500GP.Add(gemstone);
                    break;
                case 1000:
                    gemsWorth1000GP.Add(gemstone);
                    break;
                case 5000:
                    gemsWorth5000GP.Add(gemstone);
                    break;
                default:
                    break;
            }
         }
    }

    /// <summary>
    /// Pulls all gem data from the spreadsheet, creates a gemstone struct for each gem
    /// and then assigns the gems to a specific table based on gem worth
    /// </summary>
    public void ExtractArtData()
    {
        foreach (var art in gemsAndArtObjectData.dataArray)
        {
            ArtObject artObject = new ArtObject
            {
                desc = art.Description,
                worth = art.Worth
            };

            switch (artObject.worth)
            {
                case 25:
                    artWorth25GP.Add(artObject);
                    break;
                case 250:
                    artWorth250GP.Add(artObject);
                    break;
                case 750:
                    artWorth750GP.Add(artObject);
                    break;
                case 2500:
                    artWorth2500GP.Add(artObject);
                    break;
                case 7500:
                    artWorth7500GP.Add(artObject);
                    break;
                default:
                    break;
            }
        }
    }
    #endregion

    #region Return Random Items
    /// <summary>
    /// Returns a random gem from a specific gem table (based on worth)
    /// </summary>
    /// <param name="gemstones"></param>
    /// <returns></returns>
    public Gemstone RandomGemstone(List<Gemstone> gemstones)
    {
        return gemstones[Random.Range(0, gemstones.Count)];
    }
    #endregion

    /// <summary>
    /// Populate a panel with all of the gems of a given worth
    /// </summary>
    /// <param name="gemWorthEnumIndex"></param>The index of the enum used for gem worth groups
    public void CreateGemTable(int gemWorthEnumIndex)
    {
        currentGemWorthEnum = (GemWorths)gemWorthEnumIndex;
        switch (currentGemWorthEnum)
        {
            case GemWorths.Gem10:
                PopulateGemTable(gemsWorth10GP, true);
                break;
            case GemWorths.Gem50:
                PopulateGemTable(gemsWorth50GP, true);
                break;
            case GemWorths.Gem100:
                PopulateGemTable(gemsWorth100GP, true);
                break;
            case GemWorths.Gem500:
                PopulateGemTable(gemsWorth500GP, true);
                break;
            case GemWorths.Gem1000:
                PopulateGemTable(gemsWorth1000GP, true);
                break;
            case GemWorths.Gem5000:
                PopulateGemTable(gemsWorth5000GP, true);
                break;
            default:
                Debug.Log("Impossible error to reach?");
                break;
        }
    }

    /// <summary>
    /// Populate a panel with all of the art objects of a given worth
    /// </summary>
    /// <param name="artWorthEnumIndex"></param>The index of the enum used for art worth groups
    public void CreateArtTable(int artWorthEnumIndex)
    {
        currentArtWorthEnum = (ArtWorths)artWorthEnumIndex;
        switch (currentArtWorthEnum)
        {
            case ArtWorths.Art25:
                PopulateArtTable(artWorth25GP, true);
                break;
            case ArtWorths.Art250:
                PopulateArtTable(artWorth250GP, true);
                break;
            case ArtWorths.Art750:
                PopulateArtTable(artWorth750GP, true);
                break;
            case ArtWorths.Art2500:
                PopulateArtTable(artWorth2500GP, true);
                break;
            case ArtWorths.Art7500:
                PopulateArtTable(artWorth7500GP, true);
                break;
            default:
                Debug.Log("Impossible error to reach?");
                break;
        }
    }

    /// <summary>
    /// Create a single table of gems by worth
    /// </summary>
    /// <param name="gemstones"></param>
    /// <param name="clearTable"></param>
    public void PopulateGemTable(List<Gemstone> gemstones, bool clearTable)
    {
        if (clearTable)
        {
            ClearTable(TreasureFoundPanel.gameObject);
        }
        int i = 1;
        foreach (var gem in gemstones)
        {
            GameObject text = Instantiate(TreasureTextPrefab, new Vector2(0, 0), Quaternion.identity);
            RectTransform rTrans = text.GetComponent<RectTransform>();
            rTrans.SetParent(TreasureFoundPanel);
            text.GetComponent<TextMeshProUGUI>().text = i.ToString() + ". " + gem.desc;
            i++;
        }
    }

    /// <summary>
    /// Create a complete list gems
    /// </summary>
    public void CreateCompleteGemTable()
    {
        ClearTable(TreasureFoundPanel.gameObject);
        PopulateGemTable(gemsWorth10GP, false);
        PopulateGemTable(gemsWorth50GP, false);
        PopulateGemTable(gemsWorth100GP, false);
        PopulateGemTable(gemsWorth500GP, false);
        PopulateGemTable(gemsWorth1000GP, false);
        PopulateGemTable(gemsWorth5000GP, false);
    }

    /// <summary>
    /// Create a single table of art by worth
    /// </summary>
    /// <param name="artObjects"></param>A list of art objects based on worth
    /// <param name="clearTable"></param>
    public void PopulateArtTable(List<ArtObject> artObjects, bool clearTable)
    {
        if (clearTable)
        {
            ClearTable(TreasureFoundPanel.gameObject);
        }
        int i = 1;
        foreach (var art in artObjects)
        {
            GameObject text = Instantiate(TreasureTextPrefab, new Vector2(0, 0), Quaternion.identity);
            RectTransform rTrans = text.GetComponent<RectTransform>();
            rTrans.SetParent(TreasureFoundPanel);
            text.GetComponent<TextMeshProUGUI>().text = i.ToString() + ". " + art.desc;
            i++;
        }
    }

    public void CreateCompleteArtTable()
    {
        ClearTable(TreasureFoundPanel.gameObject);
        PopulateArtTable(artWorth25GP, false);
        PopulateArtTable(artWorth250GP, false);
        PopulateArtTable(artWorth750GP, false);
        PopulateArtTable(artWorth2500GP, false);
        PopulateArtTable(artWorth7500GP, false);
    }

    public void UpdateTreasureTitle(TextMeshProUGUI buttonName)
    {
        TreasureSubTitle.text = buttonName.text;
        
    }

    public void UpdateTreasureTitle(List<GameObject> objectList)
    {

    }

    /// <summary>
    /// This can be made a utility function by passing in the panel you want cleared.
    /// </summary>
    public void ClearTable(GameObject panel)
    {
        for (int i = 0; i < panel.transform.childCount; i++)
        {
            Destroy(panel.transform.GetChild(i).GetComponent<TextMeshProUGUI>());
            Destroy(panel.transform.GetChild(i).gameObject);
        }
    }

    public void ManageToggle()
    {
        indHoardToggleText.text = (indHoardToggle.isOn) ? "Individual" : "Hoard";
    }

    public int CopperFound()
    {
        int copperFound = 0;
        return copperFound;
    }
}

    public class TreasureFound
{
    private int copper;
    private int silver;
    private int gold;
    private int electrum;
    private int platinum;

    private List<Gemstone> gemstones = new List<Gemstone>();
    private List<ArtObject> artObjects = new List<ArtObject>();
    private List<MagicItem> magicItems = new List<MagicItem>();

    public int Copper { get; set; }
    public int Silver { get; set; }
    public int Gold { get; set; }
    public int Electrum { get; set; }
    public int Platinum { get; set; }
    public List<Gemstone> GemStones { get; set; }
    public List<ArtObject> ArtObjects { get; set; }
    public List<MagicItem> MagicItems { get; set; }


}

public struct Gemstone
{
    public string desc;
    public int worth;
}

public struct ArtObject
{
    public string desc;
    public int worth;
}

public struct MagicItem
{
    public string name;
    public string desc;
}

