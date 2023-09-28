using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI missText;
    // Start is called before the first frame update
    void Start()
    {
        missText.CrossFadeAlpha(0f, 5f, false);
        InvokeRepeating("DestroySelf", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
