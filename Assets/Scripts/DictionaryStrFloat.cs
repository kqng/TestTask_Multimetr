using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class <c>DictionaryStrFloat</c> словарь для хранения данных ключ-значение.
/// </summary>
[Serializable]
public class DictionaryStrFloat 
{
    public string key;
    public float value;
    public DictionaryStrFloat(string _key, float _value) 
    { 
        key = _key; 
        value = _value;
    } 
}
