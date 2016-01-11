//*********************************************************************
//
//					   ScriptName 	: CCAction 

//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using System;
using UnityEngine;
public class CCAction 
{

    /// <summary>
    /// 持续时间
    /// </summary>
    protected float _duration;
    /// <summary>
    /// 是否进行时间缩放
    /// 
    /// 注意 ：   这个是 全局 (CCActionMag.TimeScale) 时间缩放的影响 
    ///           如果使用 将不会使用本身时间缩放
    /// 
    /// </summary>
    public bool  isTimeScale = false;

    /// <summary>
    /// 本身时间缩放
    /// </summary>
    public float TimeScale = 1;
    /// <summary>
    /// 已使用时间
    /// </summary>
    protected float _elapsed;
    /// <summary>
    /// 第一次？
    /// </summary>
    protected bool _firstTick;
    /// <summary>
    /// 结束
    /// </summary>
    protected bool _isEnd;
    /// <summary>
    /// 暂停
    /// </summary>
    protected bool _isPause;
    /// <summary>
    /// 运动目标
    /// </summary>
    protected Transform _target;


    protected Action OnComplete;

    public Transform GetTarget
    {
        get { return _target; }
    }
    public Action SetComplete {
        set { OnComplete = value; }
    }
    public float Duration {
        get { return _duration; }
    }

    public bool IsEnd {
        get { return _isEnd; }
        set
        {
            _isEnd = value;
            CCActionMgr.Instance.Actions[_target].Remove(this);
        }
    }

    public float Elapsed {
        get { return _elapsed; }
    }

    public virtual void AssignTarget(Transform node) {
         _target = node;
    }

    public virtual void Pause() {
       _isPause = true;
    }

    public virtual void Resume() {
       _isPause = false;
    }


    public virtual void SetTarget(Transform node) {
        if (node==null)
        {
            Debug.LogError("传入 Transfrom 为空 请检查");
            return;
        }

       _firstTick   = true;
       _isEnd       = false;
       _target      = node;
       _elapsed     = 0;
       isTimeScale  = false;
       TimeScale    = 1;
    }

    protected virtual void start() {
        if(_target != null)
            SetTarget(_target);
    }
    public virtual void Step(float dt) {
        if(_isPause)
            return;
        if(_firstTick) {
            _firstTick = false;
            StartRun();
                OnUpdate(0);
            _elapsed = dt;
        } else {
            if (isTimeScale)
            {
                _elapsed += dt ;
            }
            else
            {
                _elapsed += dt * TimeScale;
            }   
        }
        if(!_isEnd) {

                OnUpdate(Mathf.Min(1, _elapsed / _duration));
        }
        if(_elapsed >= _duration)
        {
            EndRun();
            if(OnComplete != null)
                OnComplete();
            _isEnd = true;
        }
    }

    public virtual void Stop()
    {
        _isEnd = true;
    }
    protected virtual void OnUpdate(float ratio) {
    

    }
    protected virtual void StartRun()
    {

    }

    protected virtual void EndRun()
    {

    }
    void Start() {
        _isEnd     = true;
        _firstTick = false;
        start();
    }
}