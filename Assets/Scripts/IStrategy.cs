using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// interface <c>IStrategy</c> интерфейс для реализации паттерна Стратегия.
/// </summary>
public interface IStrategy 
{
    void GetInputData(List<DictionaryStrFloat> inputData);
}
