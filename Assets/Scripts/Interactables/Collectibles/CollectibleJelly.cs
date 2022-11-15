using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleJelly : Collectible
{
    public override void OnTrigger(Jelly jelly)
    {
        jelly.OnAdd(this.transform.position);
        this.Dismiss();
    }
}
