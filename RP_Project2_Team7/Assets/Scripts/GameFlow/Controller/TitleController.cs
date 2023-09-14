using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    private const string _triggerParam = "Tutorial";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameFlow.Instance.Control.SetTrigger(_triggerParam);
        }
    }
}
