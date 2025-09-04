using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>VoltageDCModel</c> конкретная реализация модели для режима мультиметра "Постоянный ток".
/// </summary>
public class VoltageDCModel : Model
{
    [SerializeField] private string modelKey = "VoltageDC";
    public VoltageDCModel()
    {
    }

    protected override float Calculate()
    {
        float R, P, U, I;
        MatchingValues(out R, out P, out U,out I);
        if (U != 0) return U;
        if (R != 0)
        {
            if (I != 0) return I * R;
            if (P != 0) return (float)Math.Sqrt(P * R);
        }
        else if (P != 0)
        {
            if (I != 0) return P / I;
        }
        return 0;
    }

    protected override void DataProcessing()
    {
        float result = Calculate();
        EventHandler.Publish(new ValueChangedEvent(modelKey, result));
    }
}
