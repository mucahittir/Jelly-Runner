using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeftAndRight : MonoBehaviour
{
    [SerializeField] Vector3 rot;
    [SerializeField] float time; 
    private void OnEnable()
    {
        StartCoroutine(leftAndRight());
    }
    private IEnumerator leftAndRight()
    {
        while (true)
        {
            transform.DOLocalRotate(rot, time).SetEase(Ease.InOutCubic).OnComplete(() => transform.DOLocalRotate(-rot, time).SetEase(Ease.InOutCubic));
            yield return new WaitForSeconds(time*2);
        }
    }
}
