using UnityEngine;
using UnityEngine.UI;

public class PHNavigation : MonoBehaviour
{
    public GameObject[] chapters;

	public void SelectChapter(int chapter)
    {
        for (int i = 0; i < chapters.Length; i++)
        {
            chapters[i].SetActive(i == chapter);
        }
	}
}
