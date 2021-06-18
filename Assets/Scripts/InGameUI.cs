using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InGameUI : MonoBehaviour
{
    CanvasGroup canvasGroup;
    float fadeDuration = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeINScore()
    {
        canvasGroup.DOFade(1, fadeDuration);
    }

    public void FadeOutScore()
    {
        canvasGroup.DOFade(0, fadeDuration);
    }

    
    // Update is called once per frame
    void Update()
    {
             
                  
    }
}
