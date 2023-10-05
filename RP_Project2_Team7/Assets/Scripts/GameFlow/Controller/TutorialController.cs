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
    [SerializeField]
    private GameObject tutorialCanvas;
    [SerializeField]
    private HealthManager healthManager;
    [SerializeField]
    private OrderManager orderManager;
    private int currentTutorial = 0;

    public void NextSlide()
    {
        MusicManager.Instance.PlayClickButton();
        if(currentTutorial < tutorialSlides.Count - 1)
        {
            currentTutorial ++;
            tutorialImage.sprite = tutorialSlides[currentTutorial];

        }
        else
        {
            StartGame();
        }
    }

    public void PreviousSlide()
    {
        if(currentTutorial > 0)
        {
            currentTutorial--;
            tutorialImage.sprite = tutorialSlides[currentTutorial];
            MusicManager.Instance.PlayClickButton();

        }
    }

    private IEnumerator StartGameCoroutine()
    {
        tutorialCanvas.SetActive(false);
        orderManager.StartOrder();
        healthManager.RestartSanity();
        yield return null;
        //healthManager.RestartSanity();
    }
    
    private void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
}
