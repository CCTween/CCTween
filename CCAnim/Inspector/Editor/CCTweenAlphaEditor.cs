//*********************************************************************
//
//							ScriptName:	CCTweenAlphaEditor
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(CCTweenAlpha))]
public class CCTweenAlphaEditor : Editor
{

    CCTweenAlpha alpha;

    void OnEnable()
    {
        alpha = (CCTweenAlpha) target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Start Alpha :");
        alpha.StartAlpha    = EditorGUILayout.Slider(alpha.StartAlpha, 0, 1);
        alpha.Group.alpha   = alpha.StartAlpha;
        EditorGUILayout.LabelField("End   Alpha :");
        alpha.EndAlpha      = EditorGUILayout.Slider(alpha.EndAlpha, 0, 1);
        alpha.style         = ( CCTweener.Style )EditorGUILayout.EnumPopup("Anim Type :", alpha.style);
        alpha.durtion       = EditorGUILayout.FloatField("Anim Time :", alpha.durtion);
        alpha.IsStartRun    = EditorGUILayout.Toggle("Is Start Run :", alpha.IsStartRun);
    }
}
