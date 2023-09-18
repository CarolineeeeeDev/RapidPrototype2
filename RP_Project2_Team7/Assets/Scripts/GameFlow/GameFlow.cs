using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static GameFlow Instance { get; private set; } = null;

    private bool CheckInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return true;
        }
        else
        {
            DestroyImmediate(gameObject);
            return false;
        }
    }

    public Animator Control { get; private set; } = null;
    private void Awake()
    {
        if (!CheckInstance())
        {
            return;
        }
        Control = GetComponent<Animator>();
    }
}
