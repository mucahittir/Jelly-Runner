using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : Obstacle
{
    [SerializeField] Collider myCollider;
    public override void SetActive()
    {
        myCollider.enabled = true;
        base.SetActive();
    }
    public override void OnTrigger(Jelly jelly)
    {
        if(jelly is SmallJelly)
        {
            jelly.Jump();
            myCollider.enabled = false;
        }
    }
}
