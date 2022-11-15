using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour
{
    public void Initialize()
    {
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        Visual();
    }

    protected virtual void Visual()
    {

    }
}
