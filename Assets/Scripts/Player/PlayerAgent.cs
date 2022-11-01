using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] float speed, forwardSpeed;
    Vector3 moveDir;

    public void Initialize()
    {

    }
    public void StartGame()
    {

    }

    public void Reload()
    {

    }

    public void GameOver()
    {

    }
    public void GameSuccess()
    {

    }
    public void Movement(float inputX)
    {
        moveDir.x = inputX * speed * Time.deltaTime;
        moveDir.y = 0;
        moveDir.z = forwardSpeed * Time.deltaTime;

        transform.position += moveDir;
    }

   

}
