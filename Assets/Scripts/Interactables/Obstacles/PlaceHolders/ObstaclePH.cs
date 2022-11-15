using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePH : PlaceHolder
{
    public ObstacleType obstacleType;
    protected override void Visual()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}


public enum ObstacleType : int
{
    Knife,
    Spiky,
    Guillotine,
    Lava,
    Ramp

}

