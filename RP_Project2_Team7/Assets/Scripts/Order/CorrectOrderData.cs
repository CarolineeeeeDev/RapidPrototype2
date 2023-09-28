using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectOrderData : MonoBehaviour
{
    [SerializeField]private int correctOrderCount;
    public int CorrectOrderCount => correctOrderCount;
    void Start()
    {
        correctOrderCount = 0;
        GameObject.DontDestroyOnLoad(gameObject);
    }


    public void SetCorrectOrderCount(int orderCount)
    {
        correctOrderCount = orderCount;
    }
}
