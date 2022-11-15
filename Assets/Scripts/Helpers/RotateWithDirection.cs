using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateWithDirection : MonoBehaviour
{
    [SerializeField] Vector3 rot;
    private void Start()
    {
        transform.DOLocalRotate(rot, 2f, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
    }
}
