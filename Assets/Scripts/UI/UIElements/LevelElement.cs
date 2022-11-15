using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelElement : UIElement
{
    [SerializeField] Text levelText;
    public override void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public override void UpdateElement()
    {
        levelText.text = "Level " + DataManager.Instance.Level;
    }
}
