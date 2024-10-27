using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public enum EColor { 
    White,
    Blue,
    Yellow,
    Magenta
}
public class ColorHandler
{

    public static Color GetColor(EColor color)
    { 
        switch(color)
        {
            case EColor.Blue:
                return Color.blue;
            case EColor.Yellow:
                return Color.yellow;
            case EColor.Magenta:
                return Color.magenta;
            default:
                return Color.white;
        }
    }
}

