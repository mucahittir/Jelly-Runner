using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillotine : Obstacle
{
    public override void OnTrigger(Jelly jelly)
    {
        jelly.DamageJelly();
    }
}
