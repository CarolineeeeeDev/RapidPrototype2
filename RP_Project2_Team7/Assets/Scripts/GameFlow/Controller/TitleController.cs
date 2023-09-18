using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    private const string _triggerParam = "Tutorial";

    public void StartTutorial()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
    }
    
}
