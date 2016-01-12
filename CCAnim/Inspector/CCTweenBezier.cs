//*********************************************************************
//
//							ScriptName:	CCTweenBezier
//
//							Project	  : CCAnim
//
//*********************************************************************

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CCTweenBezier : CCTweener
{
    public List<Vector3> V3Pos   = new List<Vector3>();
    public List<Vector2> V2Pos   = new List<Vector2>();

    public List<Transform> T3Pos = new List<Transform>();
    public int       length   = 0;
    public bool      usingPos = false;

    public bool      isV2;
    public float     Duration = 1;
    private Transform tr;
    private Transform myTransform
    {
        get
        {
            if (tr == null)
                tr = this.transform;
            return tr;
        }
    }
    private RectTransform   rectTransform;

    private Vector3[] V3;
    private Vector2[] V2;

    public override void CCAwake()
    {
        if (isV2)
            rectTransform = (RectTransform) myTransform;

        if (!usingPos)
        {
            V2Pos.Clear();
            V3Pos.Clear();
            
            if (isV2)
            {
                for (int i = 0; i < T3Pos.Count; i++)
                    V2Pos.Add((( RectTransform )T3Pos[i]).anchoredPosition);
            }
            else
            {
                for(int i = 0; i < T3Pos.Count; i++)
                    V3Pos.Add(T3Pos[i].position);
            }  
        }
    }
    void StyleFunction()
    {
        if(isV2)
        {
            switch(style)
            {
                case Style.Once:        One     (V2   ); break;
                case Style.Loop:        Loop    (V2   ); break;
                case Style.Repeatedly:  One     (Re2()); break;
                case Style.PingPong:    PingPong(V2   ); break;
            }
        }
        else
        {
            switch(style)
            {
                case Style.Once:        One3     (V3   ); break;
                case Style.Loop:        Loop3    (V3   ); break;
                case Style.Repeatedly:  One3     (Re3()); break;
                case Style.PingPong:    PingPong3(V3   ); break;
            }
        }
    }

    Vector2[] Re2()
    {
        Vector2[] p = V2Pos.ToArray();
        Array.Reverse(p);
        return p;
    }
    Vector3[] Re3()
    {
        Vector3[] p = V3Pos.ToArray();
        Array.Reverse(p);
        return p;
    }
    void One(Vector2[] pos)
    {
        rectTransform.UIBezierMove(pos, Duration);
    }

    void Loop(Vector2[] pos)
    {
        rectTransform.UIBezierMove(pos, Duration).SetComplete = () => { Loop(pos); };
    }

    void PingPong(Vector2[] pos)
    {
        rectTransform.UIBezierMove(pos, Duration).SetComplete = () =>
        {
            Vector2[] p = V2Pos.ToArray();
            Array.Reverse(p);
            Loop(p);
        };
    }
    void One3(Vector3[] pos)
    {
        myTransform.BezierMove(pos, Duration);
    }

    void Loop3(Vector3[] pos)
    {
        myTransform.BezierMove(pos, Duration).SetComplete = () => { Loop3(pos); };
    }

    void PingPong3(Vector3[] pos)
    {
     
        myTransform.BezierMove(pos, Duration).SetComplete = () =>
        {
            Vector3[] p = pos;
            Array.Reverse(p);
            Loop3(p);
        };
    }


    public override void PlayForward()
    {
        if (isV2)  V2 = V2Pos.ToArray();
        else       V3 = V3Pos.ToArray();
        StyleFunction();
    }

    public override void PlayReverse()
    {
        if(isV2) V2 = Re2();
        else     V3 = Re3();

        StyleFunction();
    }

    protected override void StartValue()
    {
        try
        {
            rectTransform = (RectTransform) myTransform;
            if (rectTransform == null)
            {
                Debug.Log(" 未知错误");
            }
            isV2 = true;
        }
        catch (Exception)
        {
            isV2 = false;
        }
    }
}
