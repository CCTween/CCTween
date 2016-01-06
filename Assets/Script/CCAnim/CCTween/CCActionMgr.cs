//*********************************************************************
//
//					   ScriptName 	: CCActionMgr
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections.Generic;

public class CCActionMgr 
{
  
    private static CCActionMgr instance;
    public readonly Dictionary<Transform, List<CCAction>> Actions = null;
    private readonly List<CCAction> actionList = null;

    public float TimeScale = 1f;

    public CCActionMgr()
    {
        Actions     = new Dictionary<Transform, List<CCAction>>();
        actionList  = new List<CCAction>();
    }

    public static CCActionMgr Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = GameObject.Find("CCGameObject");
                if(!go)
                {
                    go = new GameObject("CCGameObject");
                    GameObject.DontDestroyOnLoad(go);
                }
                if(!go.GetComponent<CCUpdate>())
                    go.AddComponent<CCUpdate>();
                instance = new CCActionMgr();
            }
            return instance;
        }

        // get { return instance ?? (instance = new CCActionMgr()); }
    }

    public static void UnActionMgr()
    {
        
        foreach (CCAction action in Instance.actionList)
        {
            action.Stop();
        }
        instance = null;
    }

    public void Update() {
        float t = Time.deltaTime;

        for(int i = 0; i < actionList.Count; i++) {
            CCAction cc = actionList[i];
            if(cc.IsEnd) {
                actionList.Remove(cc);
                i--;
            } else
            {
                if(cc.isTimeScale)
                    cc.Step(t * TimeScale);
                else
                    cc.Step(t);
                if(cc.IsEnd)
                {
                    actionList.Remove(cc);
                    i--;
                }
            }
        }
    }

    public void AddAction(Transform transform, CCAction action)
    {
        actionList.Add(action);
        if (Actions.ContainsKey(transform))
        {
            Actions[transform].Add(action);
        }
        else
        {
            Actions.Add(transform,new List<CCAction> { action });
        }
    }
}