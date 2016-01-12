//*********************************************************************
//
//					   ScriptName 	: CCUIAlpha
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCUIAlpha : CCAction {

    public static CCUIAlpha Create(float startAlpha, float endAlpha, float time)
    {
        return new CCUIAlpha()
        {
            StartAlpha  = startAlpha,
            EndAlpha    = endAlpha,
            _duration   = time,
            Poor        = endAlpha - startAlpha
        };
    }

    public float StartAlpha { get; set; }
    public float EndAlpha{ get; set; }
    public float Poor { get; set; }
    private CanvasGroup group;

    private CanvasGroup Group
    {
        get
        {
            if(group == null)
            {
                group = _target.GetComponent<CanvasGroup>();
                if(group == null)
                {
                    group = _target.gameObject.AddComponent<CanvasGroup>();
                }
            }
            return group;
        }
    }
    protected override void StartRun()
    {
        Group.alpha = StartAlpha;
    }
    protected override void OnUpdate(float ratio)
    {
        Group.alpha = StartAlpha + Poor * ratio;
    }
    protected override void EndRun()
    {
        Group.alpha = EndAlpha;
    }
}
