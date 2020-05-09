using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class manages all of the buttons in the bookmarks for PHB, DMG and MM chapters
/// </summary>
public class BookMark : MonoBehaviour
{
    [Header("Bookmark Elements")]
    public TextMeshProUGUI Title;

    [Header("Book Main Content Panels")]
    public GameObject PHBContentPanel;
    public GameObject DMGContentPanel;
    public GameObject MMContentPanel;

    [Header("PHB Contents")]
    public GameObject currentActivePHPage;
    private GameObject currentActiveDMPage;
    private GameObject currentActiveMMPage;

    private enum Books { PH, DM, MM };
    private Books currentBook = Books.PH;

    public void Button_ManageBookMarkBookButton(string BookName)
    {
        Title.text = BookName;
        PHBContentPanel.SetActive(BookName == "PH");
        DMGContentPanel.SetActive(BookName == "DM");
        MMContentPanel.SetActive(BookName == "MM");
    }

    public void LoadContent(GameObject contentPanel)
    {
        if (currentActivePHPage == null)
        {
            currentActivePHPage = contentPanel;
        }
        else
        {
            currentActivePHPage.SetActive(false);
        }
        contentPanel.SetActive(true);
    }

    public void Button_PHContent(GameObject page)
    {
        currentActivePHPage.SetActive(false);
        currentActivePHPage = page;
        currentActivePHPage.SetActive(true);
        currentBook = Books.PH;
        ManageContent();


    }

    public void Button_DMContent(GameObject page)
    {
        currentActiveDMPage.SetActive(false);
        currentActiveDMPage = page;
        currentActiveDMPage.SetActive(true);
        currentBook = Books.DM;
        ManageContent();


    }

    public void Button_MMContent(GameObject page)
    {
        currentActiveMMPage.SetActive(false);
        currentActiveMMPage = page;
        currentActiveMMPage.SetActive(true);
        currentBook = Books.MM;
        ManageContent();


    }
    public void ManageContent()
    {
        PHBContentPanel.SetActive(currentBook == Books.PH);
        DMGContentPanel.SetActive(currentBook == Books.DM);
        MMContentPanel.SetActive(currentBook == Books.MM);
    }
}