//*********************************************************************
//
//							ScriptName:	CCUIMove
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCUIMove : CCActionTime {


    protected Vector2 StartPos;
    protected Vector2 EndPos;
    protected Vector2 Dictance;

    public static CCUIMove Create(Vector2 startPos, Vector2 endPos, float time)
    {
        return new CCUIMove() {
            StartPos    = startPos,
            EndPos      = endPos,
            _duration   = time,
            Dictance    = (endPos - startPos) / time
        };
    }

    private RectTransform myTransform;

    protected override void StartRun()
    {
        myTransform = (RectTransform) _target;

        myTransform.anchoredPosition = StartPos;
    }

    protected override void OnUpdate(float ratio)
    {
        myTransform.anchoredPosition += Dictance * ratio;
    }

    protected override void EndRun()
    {
        myTransform.anchoredPosition = EndPos;
    }
}
