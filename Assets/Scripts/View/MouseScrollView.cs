using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Class <c>MouseScrollView</c> конкретная реализация Представления, привязанная к управлению колесом режимов на мультиметре.
/// </summary>
public class MouseScrollView : View
{
    [SerializeField] private Color highlightColor = Color.green;

    [SerializeField] private List<DictionaryStrFloat> modeAngle = new List<DictionaryStrFloat>
    {
        // зависимость от порядка = по часовой  + углы только положительные до 360. !! режим Zero = 90°
        
        new DictionaryStrFloat("Zero", 90f ),
        new DictionaryStrFloat("VoltageDC", 135f ),
        new DictionaryStrFloat("VoltageAC", 225f ),
        new DictionaryStrFloat("Amperage", 315f ),
        new DictionaryStrFloat("Omega", 45f )
    };


    [SerializeField] private List<DictionaryStrFloat> inputValues = new List<DictionaryStrFloat>
    {
        new DictionaryStrFloat("Resistance", 0f ),
        new DictionaryStrFloat("Amperage", 0f ),
        new DictionaryStrFloat("Voltage", 0f ),
        new DictionaryStrFloat("Power", 0f )
    };
    private int _currentModeSequenceIndex = 0;
    private Color _originalColor;
    private Material _material;
    private void Start()
    {
        _originalColor = GetComponent<Renderer>().material.color;
        _material = GetComponent<Renderer>().material;
    }
    private void OnMouseEnter()
    {
        _material.color = highlightColor;
    }

    private void OnMouseOver()
    {
        if (Mouse.current.scroll.ReadValue().y > 0)
        {
            if (_currentModeSequenceIndex == modeAngle.Count - 1)
            {
                _currentModeSequenceIndex = 0;
            }
            else _currentModeSequenceIndex++;

            SetEulerAngle(modeAngle[_currentModeSequenceIndex].value);
        }
        else if (Mouse.current.scroll.ReadValue().y < 0)
        {
            if (_currentModeSequenceIndex == 0)
            {
                _currentModeSequenceIndex = modeAngle.Count - 1;
            }
            else _currentModeSequenceIndex--;

            SetEulerAngle(modeAngle[_currentModeSequenceIndex].value);
        }
    }
    private void SetEulerAngle(float angle)
    {
        transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                angle
                );
        DisplayResult();
    }
    private void OnMouseExit()
    {
        _material.color = _originalColor;
    }
    public override void DisplayResult()
    {
        var controller = new MouseScrollController();
        foreach (var mode in modeAngle)
        {
            if ((int)mode.value == (int)transform.eulerAngles.z)
            {
                controller.GetUserInputValue(mode.key, inputValues);
                
            }
        }
    }
}
