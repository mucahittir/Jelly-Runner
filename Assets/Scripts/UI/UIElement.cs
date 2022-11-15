using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    public abstract void SetActive(bool isActive);

    public abstract void UpdateElement();
}
