using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Class <c>View</c> абстрактный родительский класс Представлений.
/// </summary>
public abstract class View : MonoBehaviour 
{
    public abstract void DisplayResult();

    protected virtual void OnEnable()
    {
        SubscribeToEvents();
    }

    protected virtual void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    protected virtual void SubscribeToEvents() { }
    protected virtual void UnsubscribeFromEvents() { }

    protected virtual void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}
