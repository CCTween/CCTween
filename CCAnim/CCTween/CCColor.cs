//*********************************************************************
//
//					   ScriptName 	: CCColor
//    
//                          
//    				   PROJECT    	: HORE_PREJECT
//                  	               
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCColor : CCAction{


    public static CCColor Cretate(Color startColor, Color endColor, float time) {
        return new CCColor {
            StartColor  = startColor,
            EndColor    = endColor,
            _duration   = time,
             Distance = endColor - startColor
        };
    }

    public Color StartColor { get; set; }
    public Color EndColor { get; set; }

    public Color Distance { get; set; }


    Material material;
    Material MyMaterial {
        get {
            if (material == null)
                material = _target.GetComponent<Renderer>().material;
            return material;
        }
    }
    protected override void StartRun() {
       
        MyMaterial.color = StartColor;
    }

    Color Ride(Color c,float t) {
        float r = c.r * t;
        float g = c.g * t;
        float b = c.b * t;
        float a = c.a * t;

        return new Color(r, g, b, a);
    }
    Color Plus(Color c, Color d) {
        float r = c.r + d.r;
        float g = c.g + d.g;
        float b = c.b + d.b;
        float a = c.a + d.b;

        return new Color(r, g, b, a);
    }
    Color Subtract(Color c,Color d) {
        float r = c.r - d.r;
        float g = c.g - d.g;
        float b = c.b - d.b;
        float a = c.a - d.b;

        return new Color(r, g, b, a);
    }
    protected override void OnUpdate(float ratio) {

     //   Debug.Log(Subtract(StartColor, Ride(Distance, ratio)));
        MyMaterial.color = StartColor + Distance * ratio;
    }
    protected override void EndRun() {
        MyMaterial.color = EndColor;
    }
}
