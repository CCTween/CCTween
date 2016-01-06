
//*********************************************************************
//
//					   ScriptName 	: CCExtension
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
public static class CCExtension  {

    public static void StopAllAction(this Transform s)
    {
        if(!CCActionMgr.Instance.Actions.ContainsKey(s))
            return;

        foreach (CCAction action in CCActionMgr.Instance.Actions[s])
        {
            action.Stop();
        }
    }

    public static void RunAction(this Transform s, CCAction action)
    {
        CCActionMgr.Instance.AddAction(s,action);
        action.SetTarget(s);
    }
}