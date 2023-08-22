using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ViewListView : MonoBehaviour
{
    public float fadeTime = 2f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    bool isShow = false;
    public RectTransform transformPannel;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(transformPannel.anchoredPosition3D.x);
    }
    public void panelShow()
    {
        if (!isShow)
        {        
            rectTransform.DOAnchorPos(new Vector2(- 257.2f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
            isShow = true;
        }
        else
        {
            rectTransform.DOAnchorPos(new Vector2(-56.38f, 0f), fadeTime, false).SetEase(Ease.InOutQuint);
            isShow = false;
        }
    }
}
