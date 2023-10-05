using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    private const string _triggerParam = "Game";

    public void StartTutorial()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
        MusicManager.Instance.PlayClickButton();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
    }
    
}
