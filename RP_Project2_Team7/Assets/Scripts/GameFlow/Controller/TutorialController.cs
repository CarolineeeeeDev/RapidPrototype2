using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialController : MonoBehaviour
{
    private const string _triggerParam = "Game";

    [SerializeField]
    private List<Sprite> tutorialSlides;
    [SerializeField]
    private Image tutorialImage;
    private int currentTutorial = 0;

    public void NextSlide()
    {
        if(currentTutorial < tutorialSlides.Count-1)
        {
            currentTutorial ++;
            tutorialImage.sprite = tutorialSlides[currentTutorial];

        }
        else
        {
            StartGame();
        }
    }
    
    private void StartGame()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
        MusicManager.Instance.PlayClickButton();
    }
}
