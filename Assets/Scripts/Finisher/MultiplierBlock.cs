using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierBlock : MonoBehaviour
{
    [SerializeField] int multiplyRate;

    public void OnTrigger(Jelly jelly)
    {
        DataManager.Instance.Money = multiplyRate * COMMONS.SCORE;
        DataManager.Instance.Save();
    }
}
