using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// Class <c>Model</c> абстрактный родительский класс моделей. Содержит словари имеющихся режимов мультиметра и основные физические величины.
/// Использует методы <c>MatchingValues</c> и <c>GetInputData</c>  для обработки полученных входных данных
/// </summary>
public abstract class Model: IStrategy
{
    protected View _view;
    protected Dictionary<string, float> modePhysicalQuantities = new Dictionary<string, float>()
    {
        {"Resistance", 0 },
        {"Amperage", 0 },
        {"VoltageAC", 0.01f },
        {"VoltageDC", 0 }
    };
    protected Dictionary<string, float> physicalQuantities = new Dictionary<string, float>()
    {
        {"Resistance", 0 },
        {"Amperage", 0 },
        {"Voltage", 0 },
        {"Power", 0 }
    };
    public Model()
    {
    }
    protected abstract float Calculate();
    protected abstract void DataProcessing();
    public void MatchingValues(out float Resistance, out float Power,out  float Voltage,out  float Amperage)
    {
        Resistance = 0f; 
        Power = 0f;
        Voltage = 0f;
        Amperage = 0f;
        foreach (var (key, value) in physicalQuantities)
        {
            switch (key)
            {
                case "Resistance":
                    Resistance = value;
                    break;
                case "Power":
                    Power = value;
                    break;
                case "Voltage":
                    Voltage = value;
                    break;
                case "Amperage":
                    Amperage = value;
                    break;
                default:
                    throw new ArgumentException($"Unknown parameter: {key}");
            }
        }
    }
    public void GetInputData(List<DictionaryStrFloat> inputData)
    {
        foreach (var data in inputData)
        {
            if (physicalQuantities.ContainsKey(data.key))
            {
                physicalQuantities[data.key] = data.value;
            }
        }
        DataProcessing();
    }
}
