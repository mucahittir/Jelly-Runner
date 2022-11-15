using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MultiplierBlock : MonoBehaviour
{
    [SerializeField] int multiplyRate;
    [SerializeField] TextMeshPro tmp;
    [SerializeField] MeshRenderer mr;

    public void OnEnable()
    {
        tmp.text = "X" + multiplyRate;
        mr.material.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

    }
    public void OnTrigger(Jelly jelly)
    {
        DataManager.Instance.Money = multiplyRate * COMMONS.SCORE;
        DataManager.Instance.Save();
    }
}
