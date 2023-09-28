using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    private const string _triggerParam = "Title";

    public void StartTitle()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
    }
}
