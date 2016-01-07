//*********************************************************************
//
//							ScriptName:	CCTweenPositionEditor
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CCTweenPosition))]
public class CCTweenPositionEditor : Editor
{
    private CCTweenPosition position;

    void OnEnable()
    {
        position = (CCTweenPosition) target;

    }

    public override void OnInspectorGUI()
    {
        position.FormPosition   = EditorGUILayout.Vector3Field("Start Position：", position.FormPosition);
        position.ToPosition     = EditorGUILayout.Vector3Field("End Position：", position.ToPosition);
        position.style          = ( CCTweener.Style )EditorGUILayout.EnumPopup("Anim Type：", position.style);
        position.MoveTime       = EditorGUILayout.FloatField("Anim Play Time :", position.MoveTime);
        position.IsStartRun     = EditorGUILayout.Toggle("Is Start Play：", position.IsStartRun);
    }
}
