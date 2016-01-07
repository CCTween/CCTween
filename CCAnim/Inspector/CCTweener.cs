//*********************************************************************
//
//							ScriptName:	CCTweener
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public abstract class CCTweener : MonoBehaviour {
    public enum Style {
        Once,
        Loop,
        Repeatedly,
        PingPong
    }
    // 是否是在启动事运行;
    public bool IsStartRun = true;

    public Style style = Style.Once;

    // 回调函数  
    public delegate void CcComplete();

    public CcComplete OnComplete;

    void Reset() {  StartValue(); }

    void Awake() {  CCAwake(); }

    void Start()
    {
        CCStart();
        if(IsStartRun)  PlayForward();   
    }
     
    public virtual      void CCAwake()  { }
    public virtual      void CCStart()  { }
    public abstract     void PlayForward();
    public abstract     void PlayReverse();
    protected abstract  void StartValue ();
}
