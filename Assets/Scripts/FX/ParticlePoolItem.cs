using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePoolItem : PoolObject
{
    [SerializeField] ParticleSystem myParticle;
    float autoDismissTime;
    public override void SetActive()
    {
        base.SetActive();
        myParticle.Play();
        autoDismissTime = myParticle.main.duration;
        StartCoroutine(autoDismiss());
    }

    private IEnumerator autoDismiss()
    {
        yield return new WaitForSeconds(autoDismissTime);
        this.Dismiss();
    }
}
