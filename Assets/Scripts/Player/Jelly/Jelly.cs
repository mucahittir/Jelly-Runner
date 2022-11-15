using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : PoolObject
{

    public Action OnDamage;
    public Action<Vector3> OnAdd;
    public Action OnFinish;
    public Action OnJump;

    public void DamageJelly()
    {
        OnDamage.Invoke();
    }

    public void AddJelly(Vector3 collectedPosition)
    {
        OnAdd.Invoke(collectedPosition);
    }

    public void Jump()
    {
        OnJump.Invoke();
    }
    private void Update()
    {
        clampMovement();   
    }
    private void clampMovement()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -6.5f, 6.5f);
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                Obstacle obstacle = other.attachedRigidbody.GetComponent<Obstacle>();
                obstacle.OnTrigger(this);
                break;
            case "Collectible":
                Collectible collectible = other.attachedRigidbody.GetComponent<Collectible>();
                collectible.OnTrigger(this);
                break;
            case "MultiplierBlock":
                MultiplierBlock block = other.attachedRigidbody.GetComponent<MultiplierBlock>();
                block.OnTrigger(this);
                GameManager.Instance.GameSuccess();
                break;
            case "FinisherLine":
                OnFinish.Invoke();
                break;
            default:
                break;
        }
    }
}
