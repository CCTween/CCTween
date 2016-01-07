//*********************************************************************
//
//							ScriptName:	CCTweenAlpha
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCTweenAlpha : CCTweener {


    public float StartAlpha ;
    public float EndAlpha   ;
    public float durtion  = 1f;

    private CanvasGroup group;

    public CanvasGroup Group
    {
        get
        {
            if(group == null){
                group = GetComponent<CanvasGroup>();
                if(group == null)
                    group = gameObject.AddComponent<CanvasGroup>();
            }
            return group;
        }
    }
    public override void PlayForward()
    {
        StyleFunction(StartAlpha, EndAlpha, durtion);
    }
    public override void PlayReverse()
    {
        StyleFunction(EndAlpha, StartAlpha, durtion);
    }

    void StyleFunction(float fromAlpha, float toAlpha, float animTime)
    {
        switch(style)
        {
            case Style.Once:        One     (fromAlpha, toAlpha, animTime); break;
            case Style.Loop:        Loop    (fromAlpha, toAlpha, animTime); break;
            case Style.Repeatedly:  One     (toAlpha ,fromAlpha, animTime); break;
            case Style.PingPong:    PingPong(fromAlpha, toAlpha, animTime); break;
        }
    }

    void One(float fromAlpha, float toAlpha, float time)
    {
        transform.UIAlpha(fromAlpha, toAlpha, time);
    }
    void Loop(float fromAlpha, float toAlpha, float time)
    {
        transform.UIAlpha(fromAlpha, toAlpha, time).SetComplete = () => { Loop(fromAlpha, toAlpha, time); };
    }
    void PingPong(float fromAlpha, float toAlpha, float time)
    {
        transform.UIAlpha(fromAlpha, toAlpha, time).SetComplete = () => { Loop(toAlpha,fromAlpha, time); };
    }

    protected override void StartValue()
    {
        StartAlpha = Group.alpha;
        EndAlpha   = 0;
    }
}
