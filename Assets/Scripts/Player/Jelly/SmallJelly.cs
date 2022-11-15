using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallJelly : Jelly
{
    [SerializeField] Animator myAnimator;

    public Animator MyAnimator { get => myAnimator; set => myAnimator = value; }
}
