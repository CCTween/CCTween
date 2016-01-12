//*********************************************************************
//
//							ScriptName:	CCUIBezier
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections.Generic;
public class CCUIBezier : CCAction {


    public struct BezierConfig {
        public BezierConfig(Vector2 startpos, Vector2 endPos, bool heige = true)
        {
            StartPos = startpos;
            Endpos = endPos;
            float x = (endPos.x - startpos.x) / 2;
            float y = (endPos.y - startpos.y) / 2;
            if(heige)
                ControlPos = new Vector2(startpos.x + x, startpos.y + y + 1f);
            else
                ControlPos = StartPos + (Endpos - StartPos) / 2;
     
            point2  = null;
            isArray = false;
        }

        public BezierConfig(Vector2 startpos, Vector2 endPos, Vector2 controlPos)
        {
            StartPos    = startpos;
            Endpos      = endPos;
            ControlPos  = controlPos;
            point2      = null;
            isArray     = false;
        }
        public BezierConfig(Vector2[] pos)
        {

            point2      = pos;
            StartPos    = pos[0];
            Endpos      = pos[pos.Length-1];
            ControlPos  = Vector2.zero;
            isArray     = true;
        }

        public Vector2[] point2;
        public Vector2   StartPos;
        public Vector2   ControlPos;
        public Vector2   Endpos;
        public bool      isArray;
    }

    protected BezierConfig Config;

    public static CCUIBezier Create(float duartion, BezierConfig config)
    {
        return new CCUIBezier {
            Config      = config,
            _duration   = duartion,
        };
    }
    private Vector2 tarpos = Vector2.zero;

    private RectTransform myTransform;
    protected override void StartRun()
    {
        myTransform = (RectTransform) _target;
        myTransform.anchoredPosition = Config.StartPos;
    }

    protected override void OnUpdate(float ratio)
    {
        if (Config.isArray)   tarpos = GetV2Bezies(Config.point2, ratio);
        else                  tarpos = GetV2Bezie(Config.StartPos, Config.ControlPos, Config.Endpos, ratio);

        myTransform.right = tarpos - myTransform.anchoredPosition;
        myTransform.anchoredPosition = tarpos;
    }

    private float _px1;
    private float _px2;
    private float _py1;
    private float _py2;
    private float _px3;
    private float _py3;

    private float _bx1;
    private float _by1;

    private float _bx2;
    private float _by2;

    private float _cx;
    private float _cy;
    public Vector2 GetV2Bezie(Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {

        _px1 = p1.x;
        _px2 = p2.x;
        _py1 = p1.y;
        _py2 = p2.y;
        _px3 = p3.x;
        _py3 = p3.y;

        _bx1 = (1 - t) * _px1 + t * _px2;
        _by1 = (1 - t) * _py1 + t * _py2;

        _bx2 = (1 - t) * _px2 + t * _px3;
        _by2 = (1 - t) * _py2 + t * _py3;

        _cx  = (1 - t) * _bx1 + t * _bx2;
        _cy  = (1 - t) * _by1 + t * _by2;

        return new Vector2(_cx, _cy);
    }

    List<Vector2> b = null;
    Vector2 point=Vector2.zero;
    public Vector2 GetV2Bezies(Vector2[] p, float t){
        if(b == null || b.Count == 1)
        {
            if(b == null){
                b = new List<Vector2>(p.Length);
            } else
                b.RemoveAt(0);

            for(int i = 0; i < p.Length; i++){
                b.Add(p[i]);
            }

        } else if(b.Count > 1){
            b.RemoveAt(0);
        }

        for(int i = 0; i < p.Length - 1; i++){
            b[i] = GetVector2Pos(p[i], p[i + 1], t);
        }
        if(b.Count >= 2){
            b[0] = GetV2Bezies(b.ToArray(), t);
        }
        return b[0];
    }
    Vector2 c2 = Vector2.zero;
    Vector2 GetVector2Pos(Vector2 p1, Vector2 p2, float t){
        c2.x = GetPos(p1.x, p2.x, t);
        c2.y = GetPos(p1.y, p2.y, t);
        return c2;
    }
    float GetPos(float d1, float d2, float t){
        return (1 - t) * d1 + t * d2;
    }
}
