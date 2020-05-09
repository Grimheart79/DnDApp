using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour
{
    public RectTransform Panel;
    private bool isOpen = false;

    public enum SlideDirection { up, down, left, right };
    public SlideDirection slideDir = SlideDirection.right;

    public bool SlidePanelsWidth = false;
    public float SlideDistance = 10f;
    public float SlideTime = 1f;

    Vector2 closedPos = new Vector2();
    Vector2 openPos = new Vector2();
    Vector2 startPos;
    Vector2 endPos;

    bool isLerping = false;
    float currentLerpTime;

    private void Awake()
    {
        if (SlidePanelsWidth)
        {
            SlideDistance = Panel.sizeDelta.x;
        }
        //closedPos is where the panel starts when the game first runs
        closedPos = Panel.anchoredPosition;

        //openPos is where the panel moves to
        switch (slideDir)
        {
            case SlideDirection.up:
                openPos = new Vector2(Panel.anchoredPosition.x, Panel.anchoredPosition.y + SlideDistance);
                break;
            case SlideDirection.down:
                openPos = new Vector2(Panel.anchoredPosition.x, Panel.anchoredPosition.y - SlideDistance);
                break;
            case SlideDirection.left:
                openPos = new Vector2(Panel.anchoredPosition.x - SlideDistance, Panel.anchoredPosition.y);
                break;
            case SlideDirection.right:
                openPos = new Vector2(Panel.anchoredPosition.x + SlideDistance, Panel.anchoredPosition.y);
                break;
            default:
                break;
        }
    }

    public void SlidePanel()
    {
        //startPos is always the panel's current pos
        startPos = Panel.anchoredPosition;

        endPos = (isOpen) ? closedPos : openPos;

        //Start sliding
        currentLerpTime = 0;
        isLerping = true;
    }

    protected void Update()
    {
        if (isLerping)
        {
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > SlideTime)
            {
                currentLerpTime = SlideTime;
                //Stop sliding when the time is up
                isLerping = false;
                isOpen = !isOpen;
            }

            //lerp!
            float perc = currentLerpTime / SlideTime;
            perc = perc * perc * perc * (perc * (6f * perc - 15f) + 10f);
            Panel.anchoredPosition = Vector2.Lerp(startPos, endPos, perc);
        }
    }
}
