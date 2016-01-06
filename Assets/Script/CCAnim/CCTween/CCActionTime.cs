
//*********************************************************************
//
//					   ScriptName 	: CCActionTime
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCActionTime : CCAction {

    public override void Step(float dt)
    {
        if(_isPause)
            return;
        if(_firstTick)
        {
            _firstTick = false;
            StartRun();
            OnUpdate(0);
            _elapsed = dt;
        } else
        {
            _elapsed += dt;
        }
        if(!_isEnd)
        {
            OnUpdate(dt);
        }
        if(_elapsed >= _duration)
        {
            EndRun();
            if(OnComplete != null)
                OnComplete();
            _isEnd = true;
        }
    }
}