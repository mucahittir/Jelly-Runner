using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : PoolObject
{
    public abstract void OnTrigger(Jelly jelly);
}
