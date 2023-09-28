using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSwitch : MonoBehaviour
{
    [SerializeField] private Image button1;
    [SerializeField] private Image button2;
    [SerializeField] private Image button3;
    [SerializeField] private Image button4;
    [SerializeField] private Sprite initialSprite1;
    [SerializeField] private Sprite initialSprite2;
    [SerializeField] private Sprite initialSprite3;
    [SerializeField] private Sprite initialSprite4;
    [SerializeField] private Sprite switchedSprite1;
    [SerializeField] private Sprite switchedSprite2;
    [SerializeField] private Sprite switchedSprite3;
    [SerializeField] private Sprite switchedSprite4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchSprite1()
    {
        button1.sprite = switchedSprite1;
        button2.sprite = initialSprite2;
        button3.sprite = initialSprite3;
        button4.sprite = initialSprite4;
    }
    public void SwitchSprite2()
    {
        button1.sprite = initialSprite1;
        button2.sprite = switchedSprite2;
        button3.sprite = initialSprite3;
        button4.sprite = initialSprite4;
    }
    public void SwitchSprite3()
    {
        button1.sprite = initialSprite1;
        button2.sprite = initialSprite2;
        button3.sprite = switchedSprite3;
        button4.sprite = initialSprite4;
    }
    public void SwitchSprite4()
    {
        button1.sprite = initialSprite1;
        button2.sprite = initialSprite2;
        button3.sprite = initialSprite3;
        button4.sprite = switchedSprite4;
    }
    public void ResetSprite()
    {
        button1.sprite = initialSprite1;
        button2.sprite = initialSprite2;
        button3.sprite = initialSprite3;
        button4.sprite = initialSprite4;
    }
}
