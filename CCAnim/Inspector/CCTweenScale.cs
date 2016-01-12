//*********************************************************************
//
//							ScriptName:	CCTweenScale
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCTweenScale : CCTweener {

    public Vector3 FormScale;
    public Vector3 ToScale;
    public float   ScaleTime = 1f;
    Transform Tr;
    Transform myTransform
    {
        get
        {
            if(Tr == null)  Tr = transform;
            return Tr;
        }
    }
    Vector3 Scale
    {
        get { return myTransform.localScale;}
    }
    public override void PlayForward()
    {
        StyleFunction(FormScale, ToScale);
    }
    public override void PlayReverse()
    {
        StyleFunction(ToScale, FormScale);
    }

    void StyleFunction(Vector3 from, Vector3 to)
    {
        switch(style)
        {
            case Style.Once:        One     (from, to);  break;
            case Style.Loop:        Loop    (from, to);  break;
            case Style.Repeatedly:  One     (to, from);  break;
            case Style.PingPong:    PingPong(from, to);  break;
        }
    }
    void One(Vector3 from, Vector3 to)
    {
        myTransform.Scale(from, to, ScaleTime);
    }
    void Loop(Vector3 from, Vector3 to)
    {
        myTransform.Scale(from, to, ScaleTime).SetComplete = () => { Loop(from, to); };
    }
    void PingPong(Vector3 from, Vector3 to)
    {
        myTransform.Scale(from, to, ScaleTime).SetComplete = () => { PingPong(to,from); };
    }
    protected override void StartValue()
    {
        FormScale = Scale;
        ToScale   = Scale;
    }
}
