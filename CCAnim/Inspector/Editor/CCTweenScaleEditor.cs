//*********************************************************************
//
//							ScriptName:	CCTweenScaleEditor
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(CCTweenScale))]
public class CCTweenScaleEditor : Editor
{
    private CCTweenScale scale;

    void OnEnable()
    {
        scale = (CCTweenScale) target;
    }

    public override void OnInspectorGUI()
    {
        scale.FormScale     = EditorGUILayout.Vector3Field("Start Scale", scale.FormScale);
        scale.ToScale       = EditorGUILayout.Vector3Field("End Scale", scale.ToScale);
        scale.style         = ( CCTweener.Style )EditorGUILayout.EnumPopup("Anim Type :", scale.style);
        scale.ScaleTime     = EditorGUILayout.FloatField("Anim Time :", scale.ScaleTime);
        scale.IsStartRun    = EditorGUILayout.Toggle("Is Start Run :", scale.IsStartRun);
    }
}
