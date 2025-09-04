using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>Context</c> дополнительный класс-контекст для реализации паттерна Стратегия.
/// </summary>
public class Context 
{
    private IStrategy _strategy;
    public Context()
    {  
    
    }

    public Context(IStrategy strategy)
    {
        this._strategy = strategy;
    }
    public void SetStratege(IStrategy strategy)
    {
        this._strategy = strategy;
    }
    public void PassingInputData(List<DictionaryStrFloat> inputData)
    {
        this._strategy.GetInputData(inputData);
        
    }
}
