//*********************************************************************
//
//					   ScriptName 	: CCBezier
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections.Generic;

public class CCBezier: CCAction
{
 
    public struct BezierConfig
    {
        public BezierConfig(Vector2 startpos,Vector2 endPos,bool heige=true)
        {
            StartPos    = startpos;
            Endpos      = endPos;
            float x     = (endPos.x - startpos.x) / 2;
            float y     = (endPos.y - startpos.y) / 2;
            if (heige)
                ControlPos = new Vector2(startpos.x + x, startpos.y + y + 1f);
            else
                ControlPos = StartPos+ (Endpos - StartPos)/2;
            isV2    = true;
            point3  = null;
            point2  = null;
            isArray = false;
        }
        public BezierConfig(Vector2 startpos, Vector2 endPos, Vector2 controlPos)
        {
            StartPos    = startpos;
            Endpos      = endPos;
            ControlPos  = controlPos;
            isV2        = true;
            point3      = null;
            point2      = null;
            isArray     = false;
        }
        public BezierConfig(Vector3 startpos, Vector3 endPos, Vector3 controlPos)
        {
            StartPos    = startpos;
            Endpos      = endPos;
            ControlPos  = controlPos;
            isV2        = false;
            point3      = null;
            point2      = null;
            isArray     = false;
        }
        public BezierConfig(Vector3[] pos)
        {
            point3      = pos;
            point2      = null;
            isV2        = false;
            isArray     = true;

            StartPos    = Vector3.zero;
            Endpos      = Vector3.zero;
            ControlPos  = Vector3.zero;
        }
        public BezierConfig(Vector2[] pos)
        {
            point3      = null;
            point2      = pos;
            isV2        = true;
            isArray     = true;

            StartPos    = Vector3.zero;
            Endpos      = Vector3.zero;
            ControlPos  = Vector3.zero;
       
        }
        public Vector3[] point3;
        public Vector2[] point2;
        public Vector3   StartPos;
        public Vector3   ControlPos;
        public Vector3   Endpos;
        public bool      isV2;
        public bool      isArray;
    }

    protected BezierConfig Config;

    public static CCBezier Create(float duartion, BezierConfig config) {
        return new CCBezier {
            Config      = config,
            _duration   = duartion,
            IsV2        = config.isV2,
        };

    }

    private Vector3 tarpos = Vector3.zero;

    private bool IsV2;
    protected override void OnUpdate(float ratio)
    {
        if(Config.isArray)
        {
            if (IsV2)   tarpos = GetV2Bezies(Config.point2, ratio);
            else        tarpos = GetV3Bezies(Config.point3, ratio);
        } else
        {
            if(IsV2)    tarpos = GetV2Bezie(Config.StartPos, Config.ControlPos, Config.Endpos, ratio);
            else        tarpos = GetV3Bezie(Config.StartPos, Config.ControlPos, Config.Endpos, ratio);
   
        }
        _target.right = tarpos - _target.position;

        _target.position = tarpos;
    }

    private float _x1;
    private float _x2;
    private float _x3;

    private float _y1;
    private float _y2;
    private float _y3;

    private float _z1;
    private float _z2;
    private float _z3;


    private float Bx1;

    private float Bx2;

    private float By1;

    private float By2;

    private float Bz1;

    private float Bz2;
    public Vector3 GetV3Bezie(Vector3 p1, Vector3 p2, Vector3 p3, float t) {
        _x1 = p1.x;
        _x2 = p2.x;
        _x3 = p3.x;

        _y1 = p1.y;
        _y2 = p2.y;
        _y3 = p3.y;

        _z1 = p1.z;
        _z2 = p2.z;
        _z3 = p3.z;

        Bx1 = (1 - t) * _x1 + t * _x2;

        Bx2 = (1 - t) * _x2 + t * _x3;

        By1 = (1 - t) * _y1 + t * _y2;

        By2 = (1 - t) * _y2 + t * _y3;

        Bz1 = (1 - t) * _z1 + t * _z2;

        Bz2 = (1 - t) * _z2 + t * _z3;

        float x = (1 - t) * Bx1 + t * Bx2;
        float y = (1 - t) * By1 + t * By2;
        float z = (1 - t) * Bz1 + t * Bz2;

        return new Vector3(x, y, z);
    }
    List<Vector3> v3 = null;

    public Vector3 GetV3Bezies(Vector3[] p, float t) {

        if(v3 == null || v3.Count == 1) {
            if(v3 == null) {
                v3 = new List<Vector3>(p.Length);
            } else
                v3.RemoveAt(0);

            for(int i = 0; i < p.Length; i++) {
                v3.Add(p[i]);
            }
        } else if(v3.Count >= 2) {
            v3.RemoveAt(0);
        }

        for(int i = 0; i < p.Length - 1; i++) {
            v3[i] = GetVector3Pos(p[i], p[i + 1], t);
        }
        if(v3.Count >= 2) {
            v3[0] = GetV3Bezies(v3.ToArray(), t);
        }
        return v3[0];
    }
    Vector3 c3 = Vector3.zero;
    Vector3 GetVector3Pos(Vector3 p1, Vector3 p2, float t) {
        c3.x = GetPos(p1.x, p2.x, t);
        c3.y = GetPos(p1.y, p2.y, t);
        c3.z = GetPos(p1.z, p2.z, t);
        return c3;
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
    public Vector2 GetV2Bezie(Vector2 p1, Vector2 p2, Vector2 p3, float t) {

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

        _cx = (1 - t) * _bx1 + t * _bx2;
        _cy = (1 - t) * _by1 + t * _by2;

        return new Vector2(_cx, _cy);
    }

    List<Vector2> b = null;
    public Vector2 GetV2Bezies(Vector2[] p, float t) {

        if(b == null || b.Count == 1) {
            if(b == null) {
                b = new List<Vector2>(p.Length);
            } else
                b.RemoveAt(0);

            for(int i = 0; i < p.Length; i++) {
                b.Add(p[i]);
            }
        } else if(b.Count >= 2) {
            b.RemoveAt(0);
        }

        for(int i = 0; i < p.Length - 1; i++) {
            b[i] = GetVector2Pos(p[i], p[i + 1], t);
        }
        if(b.Count >= 2) {
            b[0] = GetV2Bezies(b.ToArray(), t);
        }
        return b[0];
    }

    Vector2 c2 = Vector2.zero;
    Vector2 GetVector2Pos(Vector2 p1, Vector2 p2, float t) {
        c2.x = GetPos(p1.x, p2.x, t);
        c2.y = GetPos(p1.y, p2.y, t);
        return c2;
    }
    float GetPos(float p1, float p2, float t) {
        return (1 - t) * p1 + t * p2;
    }
}
