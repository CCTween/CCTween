//*********************************************************************
//
//							ScriptName:	CCDelay
//
//							Project	  : CCAnim
//
//*********************************************************************

using System;
using UnityEngine;
using System.Collections;

public class CCDelay : CCAction {

    public static CCDelay Create(Action action, float time)
    {
        return new CCDelay
        {
            MyAction = action,
            _duration = time
        };
    }
    public delegate void OnAction(Transform tr, params UnityEngine.Object[] obj);

    private  OnAction MyOnAction; 
    private UnityEngine.Object[] Params { get; set; }


    public Action MyAction;
    public void SetHandle(OnAction onAction, params UnityEngine.Object[] _params)
    {
        MyOnAction  = onAction;
        Params      = _params;
    }
    protected override void EndRun()
    {
        if (MyAction != null)
        {
            MyAction();  
        }
        if (MyOnAction != null)
            MyOnAction(_target, Params);
    }
  
}
