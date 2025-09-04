using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>ZeroModel</c> конкретная реализация модели для режима мультиметра "Ноль(Выключен)".
/// </summary>
public class ZeroModel : Model
{
    [SerializeField] private float defaultValue = 0f;
    [SerializeField] private string modelKey = "Zero";
    public ZeroModel()
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
