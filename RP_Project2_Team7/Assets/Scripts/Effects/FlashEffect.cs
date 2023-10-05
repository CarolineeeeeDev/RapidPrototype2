using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    private Coroutine flashCoroutine;

    public void RestartFlash(float speed, int reapeatTime)
    {
        if(flashImage == null) { return; }
        if(flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
            flashCoroutine = null;
        }
        ResetImage();
        flashCoroutine = StartCoroutine(FlashCoroutine(speed, reapeatTime));
    }

    private void ResetImage()
    {
        Color newColor = flashImage.color;
        newColor.a = 1;
        flashImage.color = newColor;
    }

    private IEnumerator FlashCoroutine(float speed, int reapeatTime)
    {
        Color newColor = flashImage.color;
        for(int i = 0; i < reapeatTime; i++)
        {
            while(newColor.a > 0)
            {
                newColor.a -= 0.01f;  
                flashImage.color = newColor;
                yield return new WaitForSeconds(1 / speed);
            }
            while(newColor.a < 1)
            {
                newColor.a += 0.01f;  
                flashImage.color = newColor;
                yield return new WaitForSeconds(1 / speed);
            }
        }
    }
}
