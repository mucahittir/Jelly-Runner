using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePH : PlaceHolder
{
    public int Value;
    public CollectibleType collectibleType;
    protected override void Visual()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}

public enum CollectibleType
{
    Coin,
    CollectibleJelly,
}