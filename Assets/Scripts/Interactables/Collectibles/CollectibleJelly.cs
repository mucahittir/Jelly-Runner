using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleJelly : Collectible
{
    public override void OnTrigger(Jelly jelly)
    {
        this.Dismiss();
        jelly.OnAdd(this.transform.position);
    }
}
