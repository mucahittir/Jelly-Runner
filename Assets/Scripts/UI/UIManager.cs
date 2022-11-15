using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : CoreObj<UIManager>
{
    [SerializeField] private List<View> views;
    [SerializeField] private UIElementContainer uiElementContainer;

    public override void Initialize()
    {
        for (int i = 0; i < views.Count; i++)
        {
            View item = views[i];
            item.Hide();
        }
    }

    public void OpenUI(string tag)
    {
        for (int i = 0; i < views.Count; i++)
        {
            if (string.Compare(views[i].ViewTag, tag) == 0)
            {
                views[i].Show();
                return;
            }
        }

        Debug.LogError(tag + " cant find.");
    }

    public void OpenUIClean(string setup)
    {
        ClearScreen();
        OpenUI(setup);
    }

    public void CloseUI(string tag)
    {
        for (int i = 0; i < views.Count; i++)
        {
            if (views[i].ViewTag == tag)
            {
                views[i].Hide();
                return;
            }
        }

        Debug.LogError(tag + " cant find.");
    }

    public void ClearScreen()
    {
        for (int i = 0; i < views.Count; i++)
        {
            views[i].Hide();
        }
    }

    public void UpdateUIElements()
    {
        uiElementContainer.UpdateUIElements();
    }
}
