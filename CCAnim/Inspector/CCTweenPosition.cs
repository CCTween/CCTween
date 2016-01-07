//*********************************************************************
//
//							ScriptName:	CCTweenPosition
//
//							Project	  : CCAnim
//
//*********************************************************************

using System;
using UnityEngine;
using System.Collections;

public class CCTweenPosition : CCTweener {

    public Vector3 FormPosition;
    public Vector3 ToPosition;
    public float   MoveTime = 1f;

    private RectTransform rectTransform;
    private Transform     tr;

    private Transform myTransform
    {
        get
        {
            if (tr == null)
                tr = this.transform;
            return tr;
        }
    }
    private bool          isUI;
    public override void PlayForward()
    {
        StyleFunction(this.FormPosition, this.ToPosition);
    }
    public override void PlayReverse()
    {
        StyleFunction(this.ToPosition, this.FormPosition);
    }
    void StyleFunction(Vector3 From, Vector3 To)
    {
        switch(style)
        {
            case Style.Once:       One      (From, To);  break;             
            case Style.Loop:       Loop     (From, To);  break;
            case Style.Repeatedly: One      (To,From) ;  break;
            case Style.PingPong:   PingPong (From, To);  break;
        }
    }
    void One(Vector3 From, Vector3 To)
    {
        if (isUI) rectTransform.UIMove(From, To, MoveTime);
        else      myTransform  .Move  (From, To, MoveTime);
    }
    void Loop(Vector3 From, Vector3 To)
    {
        if(isUI) rectTransform.UIMove(From, To, MoveTime).SetComplete = () => { Loop(From, To); };
         else    myTransform  .Move  (From, To, MoveTime).SetComplete = () => { Loop(From, To); };  
    }
    void PingPong(Vector3 From, Vector3 To)
    {
        if(isUI)  rectTransform.UIMove(From, To, MoveTime).SetComplete = () => { Loop( To, From); };
        else      myTransform  .Move  (From, To, MoveTime).SetComplete = () => { Loop( To, From); };
    }
    protected override void StartValue()
    {
        FormPosition  = ToPosition = myTransform.position;
        try
        {
            rectTransform = ( RectTransform )myTransform;
            FormPosition  = ToPosition = this.rectTransform.anchoredPosition;
            isUI = true;
        }
        catch (Exception)
        {
            isUI = false;
        }
    }
}
