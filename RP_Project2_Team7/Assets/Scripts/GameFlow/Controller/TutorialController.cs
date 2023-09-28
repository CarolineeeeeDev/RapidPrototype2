using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private const string _triggerParam = "Game";

    public void StartGame()
    {
        GameFlow.Instance.Control.SetTrigger(_triggerParam);
        MusicManager.Instance.PlayClickButton();
    }
}
