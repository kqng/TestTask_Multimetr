using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
/// <summary>
/// Class <c>MouseScrollController</c> конкретный класс Контроллера, применимый к управлению данными исходящими от взаимодействия с колесом мультиметра.
/// </summary>
public class MouseScrollController : Controller
{
    public MouseScrollController()
    {
    }
    public void GetUserInputValue(string value, List<DictionaryStrFloat> inputData)
    {
        var context = new Context();
        switch (value)
        {
            case "Zero":
                context.SetStratege(new ZeroModel());
                break;
            case "VoltageDC":
                context.SetStratege(new VoltageDCModel());
                break;
            case "VoltageAC":
                context.SetStratege(new VoltageACModel());
                break;
            case "Amperage":
                context.SetStratege(new AmperModel());
                break;
            case "Omega":
                context.SetStratege(new OmegaModel());
                break;
            default:
                context.SetStratege(new ZeroModel());
                break;

        }
        context.PassingInputData(inputData);

    }
}
