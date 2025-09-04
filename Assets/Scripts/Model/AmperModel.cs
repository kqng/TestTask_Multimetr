using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>AmperModel</c> конкретная реализация модели для режима мультиметра "Сила тока".
/// </summary>
public class AmperModel : Model
{
    [SerializeField] private string modelKey = "Amperage";
    public AmperModel()
    {
    }

    protected override float Calculate()
    {
        float R, P, U, I;
        MatchingValues(out R, out P, out U, out I);
        if (I != 0) return I;
        if (R != 0 )
        {
            if (U != 0) return U / R;
            if (P != 0) return (float)Math.Sqrt(P/R);
        }
        else if (P != 0)
        {
            if(U != 0) return P / U;
        }
        
        return 0;
    }

    protected override void DataProcessing()
    {
        float result = Calculate();
        EventHandler.Publish(new ValueChangedEvent(modelKey, result));
    }
}
