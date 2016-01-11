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


    /// <summary>
    ///  设置全局的时间缩放
    /// 
    /// 注意 ：  使用了此选项 可能会用为对象本身的时间缩放 而导致错误
    /// </summary>
    /// <param name="scale"></param>
    public void SetGlobalTimeScale(float scale)
    {
        TimeScale = scale;
    }

    /// <summary>
    /// 设置全部时间缩放
    /// </summary>
    /// <param name="scale"></param>
    public void SetTimeScale( float scale)
    {
        for(int i = 0; i < actionList.Count; i++)
        {
            actionList[i].TimeScale = scale;
        }
    }

    /// <summary>
    /// 设置 时间缩放 
    /// </summary>
    /// <param name="exclude">需要排除的</param>
    /// <param name="scale"></param>
    public void SetTimeScale(Transform exclude, float scale)
    {
        for(int i = 0; i < actionList.Count; i++)
        {
            if(actionList[i].GetTarget == exclude)
                continue;

            actionList[i].TimeScale = scale;
        }
    }

    /// <summary>
    /// 设置部分 时间缩放
    /// </summary>
    /// <param name="exclued"></param>
    /// <param name="scale"></param>
    public void SetPartScale(Transform[] exclued, float scale)
    {
        for (int i = 0; i < exclued.Length; i++)
        {
            CCAction action = actionList.Find(x => x.GetTarget == exclued[i]);
            action.TimeScale = scale;
        }
      
    }

}