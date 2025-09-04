using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Class <c>UIView</c> конкретная реализация Представления, привязанная к выводу данных на интерфейс пользователя и на экран мультиметра.
/// </summary>
public class UIView : View
{
    [SerializeField] private TextMeshPro _screenTMP;
    [SerializeField] private TextMeshProUGUI _omegaTMP_UI;
    [SerializeField] private TextMeshProUGUI _voltageDC_TMP_UI;
    [SerializeField] private TextMeshProUGUI _voltageAC_TMP_UI;
    [SerializeField] private TextMeshProUGUI _amperageTMP_UI;
    private string _lastResultName;
    private float _lastResultValue;

    private void Awake()
    {
        ResetAllField();
    }
    public override void DisplayResult()
    {
        
    }
    protected override void SubscribeToEvents()
    {
        EventHandler.Subscribe<ValueChangedEvent>(ValueChanged);
    }
    protected override void UnsubscribeFromEvents()
    {
        EventHandler.Unsubscribe<ValueChangedEvent>(ValueChanged);
    }
    private void ValueChanged(ValueChangedEvent data)
    {
        _lastResultName = data.VariablesName;
        _lastResultValue = data.VariablesValue;

        ResetAllField();

        switch (_lastResultName)
        { 
        case "Omega":
            _omegaTMP_UI.text += _lastResultValue.ToString("F2");
            break;
        case "VoltageAC":
            _voltageAC_TMP_UI.text += _lastResultValue.ToString("F2");
            break;
        case "VoltageDC":
            _voltageDC_TMP_UI.text += _lastResultValue.ToString("F2");
            break;
        case "Amperage":
            _amperageTMP_UI.text += _lastResultValue.ToString("F2");
            break;
        case "Zero":
                ResetAllField();
                break;
        default:
            throw new ArgumentException($"Unknown result parameter!");
        };

        _screenTMP.text = _lastResultValue.ToString("F2");

        DisplayResult(); 
    }
    private void ResetAllField()
    {
        _omegaTMP_UI.text = "Ω ";
        _voltageDC_TMP_UI.text = "V ";
        _voltageAC_TMP_UI.text = "~ ";
        _amperageTMP_UI.text = "A ";
        _screenTMP.text = "0";
    }
}
