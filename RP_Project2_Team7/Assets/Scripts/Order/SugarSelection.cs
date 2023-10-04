using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarSelection : MonoBehaviour
{
    [SerializeField] private GameObject OrderManager;
    [SerializeField] private GameObject Sugar;
    [SerializeField] private GameObject CupSize;
    private int difficultyIndex;
    public void Click()
    {
        difficultyIndex = OrderManager.GetComponent<OrderManager>().CurrentDifficultyIndex;
       if(difficultyIndex <= 3 )
        {
            CupSize.SetActive(true);
        }
       else
        {
            Sugar.SetActive(true);
        }
    }
}
