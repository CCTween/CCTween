//*********************************************************************
//
//							ScriptName:	CCScale
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCScale : CCAction
{


    public static CCScale Create(Vector3 startScale, Vector3 endScale, float time)
    {
        return  new CCScale()
        {
            StartScale  = startScale,
            EndScale    = endScale,
            Distance    = endScale - startScale,
            _duration   = time
        };
    }


    public Vector3 StartScale;
    public Vector3 EndScale;
    public Vector3 Distance;

    protected override void StartRun()
    {
        _target.localScale = StartScale;
    }

    protected override void OnUpdate(float ratio)
    {
        _target.localScale = StartScale + Distance * ratio;
    }

    protected override void EndRun()
    {
        _target.localScale = EndScale;
    }
}
