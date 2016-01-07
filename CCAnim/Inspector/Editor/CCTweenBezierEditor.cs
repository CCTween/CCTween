//*********************************************************************
//
//							ScriptName:	CCTweenBezierEditor
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(CCTweenBezier))]
public class CCTweenBezierEditor : Editor
{

    CCTweenBezier bezier;

    private bool showPosition = true;
    void OnEnable()
    {
        bezier = (CCTweenBezier) target;
    }

    public override void OnInspectorGUI()
    {

        bezier.length     = EditorGUILayout.IntField("坐标数量 ：", bezier.length);
        bezier.Duration   = EditorGUILayout.FloatField("动画时间 :", bezier.Duration);
        bezier.usingPos   = EditorGUILayout.Toggle("使用坐标 ：", bezier.usingPos);
        bezier.IsStartRun = EditorGUILayout.Toggle("开始运行", bezier.IsStartRun);
        showPosition      = EditorGUILayout.Foldout(showPosition,"坐标数组 ：");
        if(!showPosition)
            return;

        if (bezier.usingPos)  Position();
        else                  Transfrom();
    }
    void Transfrom()
    {
        if(bezier.length == 0)
            return;

        if(bezier.T3Pos.Count != bezier.length)
        {
            if(bezier.T3Pos.Count > bezier.length)
            {
                int index = bezier.T3Pos.Count - bezier.length;
                for(int i = 0; i < index; i++)
                    bezier.T3Pos.RemoveAt(bezier.T3Pos.Count - 1);

            } else
            {
                int index = bezier.length - bezier.T3Pos.Count;
                for(int i = 0; i < index; i++)
                    bezier.T3Pos.Add(null);
            }
        }

        for(int i = 0; i < bezier.T3Pos.Count; i++)
            bezier.T3Pos[i] = EditorGUILayout.ObjectField("Position " + (i + 1), bezier.T3Pos[i], typeof(Transform), true) as Transform;


    }
    void Position()
    {
        if(bezier.length == 0)
            return;

        if(bezier.isV2)
        {
            if(bezier.V2Pos.Count != bezier.length)
            {
                if(bezier.V2Pos.Count > bezier.length)
                {
                    int index = bezier.V2Pos.Count - bezier.length;
                    for(int i = 0; i < index; i++)
                        bezier.V2Pos.RemoveAt(bezier.V2Pos.Count - 1);
                } else
                {
                    int index = bezier.length - bezier.V2Pos.Count;
                    for(int i = 0; i < index; i++)
                        bezier.V2Pos.Add(Vector2.zero);
                }
            }
        } else
        {
            if(bezier.V3Pos.Count != bezier.length)
            {
                if(bezier.V3Pos.Count > bezier.length)
                {
                    int index = bezier.V3Pos.Count - bezier.length;
                    for(int i = 0; i < index; i++)
                        bezier.V3Pos.RemoveAt(bezier.V3Pos.Count - 1);

                } else
                {
                    int index = bezier.length - bezier.V3Pos.Count;
                    for(int i = 0; i < index; i++)
                        bezier.V3Pos.Add(Vector3.zero);
                }
            }
        }



        if(bezier.isV2)
        {
            for(int i = 0; i < bezier.V2Pos.Count; i++)
                bezier.V2Pos[i] = EditorGUILayout.Vector2Field("Potation " + (i + 1), bezier.V2Pos[i]);
        } else
        {
            for(int i = 0; i < bezier.V3Pos.Count; i++)
                bezier.V3Pos[i] = EditorGUILayout.Vector3Field("Potation " + (i + 1), bezier.V3Pos[i]);

        }
    }
}
