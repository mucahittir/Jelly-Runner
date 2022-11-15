using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    private int value;

    public int Value { get => value; set => this.value = value; }

    public override void OnTrigger(Jelly jelly)
    {
        COMMONS.SCORE += Value;
        UIManager.Instance.UpdateUIElements();
        this.Dismiss();
    }
}
