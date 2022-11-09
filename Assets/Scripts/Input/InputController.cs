using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController
{
    private Vector2 startedPos, delta;
    private Vector2 value;
    private float maxDistance = 10f;

    private float countdown = 0;
    private bool isCountdownStarted = false;

    public Vector2 Value { get => value; set => this.value = value; }
    public float MaxDistance { get => maxDistance; set => maxDistance = value; }

    public Action OnTap;

    public void CustomUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startedPos = (Vector2)Input.mousePosition;
            isCountdownStarted = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
           
            delta = Vector2.zero;
            startedPos = Vector2.zero;
            value = Vector2.zero;

            if (countdown < 0.15f)
                OnTap?.Invoke();
            countdown = 0;
            isCountdownStarted = false;
        }

        if (!Input.GetMouseButton(0)) return;
        delta = (Vector2)Input.mousePosition - startedPos;
        delta.x = Mathf.Clamp(delta.x, -maxDistance, maxDistance);
        delta.y = Mathf.Clamp(delta.y, -maxDistance, maxDistance);

        value = delta / maxDistance;
        startedPos = (Vector2)Input.mousePosition;

        if(isCountdownStarted)
        {
            countdown += Time.deltaTime;
        }
    }
}
