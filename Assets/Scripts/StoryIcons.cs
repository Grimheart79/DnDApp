using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryIcons : MonoBehaviour
{
    public Sprite[] StorySprites;
    public Image[] StoryImages;

    public void Button_GenerateStory()
    {
        foreach (var storyImage in StoryImages)
        {
            int randomNumber = Random.Range(0, StorySprites.Length);
            storyImage.overrideSprite = StorySprites[randomNumber];
        }
    }
}
