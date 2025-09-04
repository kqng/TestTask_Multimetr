using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>VoltageACModel</c> конкретная реализация модели для режима мультиметра "Переменный ток".
/// </summary>
public class VoltageACModel : Model
{
    [SerializeField] private float defaultValue = 0.01f;
    [SerializeField] private string modelKey = "VoltageAC";
    public VoltageACModel()
    {
    }

    protected override float Calculate()
    {
        return defaultValue;
    }

    protected override void DataProcessing()
    {
        float result = Calculate();
        EventHandler.Publish(new ValueChangedEvent(modelKey, result));
    }
}
