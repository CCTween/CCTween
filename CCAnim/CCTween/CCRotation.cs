//*********************************************************************
//
//							ScriptName:	CCRotation
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCRotation : CCAction {

    public static CCRotation Create(Vector3 startRotation,Vector3 endRotation,float time)
    {
        return new CCRotation
        {
            StartRotation   = startRotation,
            EndRotation     = endRotation,
            Distance        = endRotation-startRotation,
            _duration       = time
        };
    }


    public Vector3 StartRotation { get; set; }
    public Vector3 EndRotation { get; set; }
    public Vector3 Distance { get; set; }

    protected override void StartRun()
    {
        _target.eulerAngles = StartRotation;
    }

    protected override void OnUpdate(float ratio)
    {
        _target.eulerAngles = StartRotation + Distance*ratio;
    }

    protected override void EndRun()
    {
        _target.eulerAngles = EndRotation;
    }
}
