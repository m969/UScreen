using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UScreen : UComponent.Entity
{
    public UScreenMono UScreenMono { get; set; }


    public override void Awake(object initData)
    {
        base.Awake();
        UScreenMono = initData as UScreenMono;
        BindComponents();
    }

    public virtual void BindComponents()
    {

    }

    public virtual void Show()
    {
        OnShow();
        var canvasGroup = UScreenMono.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }

    public virtual void Hide()
    {
        var canvasGroup = UScreenMono.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        OnHide();
    }

    public virtual void OnShow()
    {
        UScreenMono.transform.position = new Vector2(Screen.width * 2, Screen.height / 2);
        UScreenMono.transform.DOMoveX(Screen.width / 2, 0.3f);
        var canvasGroup = UScreenMono.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1f, 0.3f).onComplete = null;
        }
    }

    public virtual void OnHide(Action onFinish = null)
    {
        var canvasGroup = UScreenMono.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(0f, 0.3f).OnComplete(() => { onFinish?.Invoke(); });
        }
        else
        {
            onFinish?.Invoke();
        }
    }
}
