using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementContainer : MonoBehaviour
{
    public List<UIElement> Items;
    public void UpdateUIElements()
    {
        foreach (var item in Items)
        {
            item.UpdateElement();
        }
    }
}
