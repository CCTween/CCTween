//*********************************************************************
//
//							ScriptName:	CCSpawn
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CCSpawn : CCAction
{

    protected List<CCAction> actionList;

    public static CCSpawn Create(params CCAction[] actions)
    {
        return new CCSpawn(actions);
    }

    public CCSpawn()
    {
        
    }
    public CCSpawn(params CCAction[] actions)
    {
        actionList=new List<CCAction>(actions.Length);
        actionList.AddRange(actions);
        _duration = 0;
        for (int i = 0; i < actions.Length; i++)
        {
            _duration = Mathf.Max(_duration, actions[i].Duration);
        }
    }

    public override void SetTarget(Transform node)
    {
        _firstTick  = true;
        _isEnd      = false;
        _target     = node;
        _elapsed    = 0;

        using (List<CCAction>.Enumerator enumerator=actionList.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                CCAction current = enumerator.Current;
                current.SetTarget(_target);
            }
        }
    }

    public override void Step(float dt)
    {
        if (_isPause)
        {
            return;
        }
        _elapsed += dt;
        for (int i = 0; i < actionList.Count; i++)
        {
            if (!actionList[i].IsEnd)
            {
                actionList[i].Step(dt);
            }
        }
        if (_elapsed >= _duration)
            _isEnd = true;
    }
}
