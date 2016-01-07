//*********************************************************************
//
//							ScriptName:	CCJump
//
//							Project	  : CCAnim
//
//*********************************************************************

using System;
using UnityEngine;
using System.Collections;

public class CCJump : CCAction {

    #region Fields

    public Vector2 _delta;

    public float _height;

    public int   _jumps;

    protected Vector2 _orgPos;

    #endregion

    #region Public Methods and Operators

    public float _z;

    public static CCJump Create(float duartion, Vector2 delta, float height, int jumps)
    {
        return new CCJump { _duration = duartion, _delta = delta, _height = height, _jumps = jumps };
    }

    public override void SetTarget(Transform node)
    {
        _firstTick = true;
        _isEnd = false;
        _target = node;
        _elapsed = 0f;
        _orgPos = node.position;
        _z = node.position.z;
    }

    protected override void OnUpdate(float t)
    {
        var p = new Vector2();
        if(t == 1f)
        {
            p = new Vector2(_delta.x + _orgPos.x, _delta.y + _orgPos.y);
            _target.position = new Vector3(p.x, p.y, _z);
            return;
        }
        float num = -_height * Math.Abs(( float )Math.Sin(t * 3.14159274f * _jumps));
        num += _delta.y * t;
        float num2 = _delta.x * t;
        p = new Vector2(num2 + _orgPos.x, num + _orgPos.y);
        _target.position = new Vector3(p.x, p.y, _z);
    }

    #endregion

}
