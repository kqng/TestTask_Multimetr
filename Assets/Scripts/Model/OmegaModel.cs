using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class <c>OmegaModel</c> конкретная реализация модели для режима мультиметра "Сопротивление(Omega)".
/// </summary>
public class OmegaModel : Model
{
    [SerializeField] private string modelKey = "Omega";
    public OmegaModel()
    {
    }

    protected override float Calculate()
    {
        float R,P,U,I;
        MatchingValues(out R, out P, out U, out I);
        if (R != 0) return R;
        if (U != 0)
        {
            if (I != 0) return U / I;
            if (P != 0) return U*U/P;
        }
        else if (P != 0)
        {
            if (I != 0) return P / (I*I);
        }
        return 0;
    }

    protected override void DataProcessing()
    {
        float result = Calculate();
        EventHandler.Publish(new ValueChangedEvent(modelKey, result));
    }
}
