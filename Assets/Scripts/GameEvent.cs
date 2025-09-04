using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>GameEvent</c> абстрактный класс для создания определённых эвентов.
/// </summary>
public abstract class GameEvent { }

public class ValueChangedEvent : GameEvent
{
    public string VariablesName {  get; }
    public float VariablesValue { get; }

    public ValueChangedEvent(string varName, float varValue)
    {
        VariablesName = varName;
        VariablesValue = varValue;
    }
}