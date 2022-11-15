using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinElement : UIElement
{
    [SerializeField] Text coinText;
    public override void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public override void UpdateElement()
    {
        coinText.text = (DataManager.Instance.Money + COMMONS.SCORE).ToString();
    }
}
