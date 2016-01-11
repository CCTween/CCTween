
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

    /// <summary>
    ///  运行 CCAction
    /// </summary>
    /// <param name="s"></param>
    /// <param name="action"></param>
    public static void RunAction(this Transform s, CCAction action)
    {
        action.SetTarget(s);
        CCActionMgr.Instance.AddAction(s,action);      
    }
    /// <summary>
    ///  设置全局的时间缩放
    /// 
    /// 注意 ：可能会以为对象本身的时间缩放 而导致错误
    /// </summary>
    /// <param name="scale"></param>
    public static void SetGlobalTimeScale(float scale)
    {
        CCActionMgr.Instance.SetGlobalTimeScale(scale);
    }

    /// <summary>
    /// 设置全部时间缩放
    /// 
    /// 注意 ： 可能会因为全局时间缩放  而导致错误
    /// </summary>

    public static void SetTimeScaleAll(this Transform s, float scale)
    {
        CCActionMgr.Instance.SetTimeScale(scale);
    }

    /// <summary>
    /// 设置 时间缩放 
    /// 
    /// 默认 排除本身
    /// 
    /// 注意 ： 可能会因为全局时间缩放  而导致错误
    /// </summary>
    /// <param name="scale"></param>
    public static void SetTimeScale(this Transform s, float scale)
    {
        CCActionMgr.Instance.SetTimeScale(s, scale);

    }
    /// <summary>
    /// 设置部分 时间缩放
    /// 
    /// 不包含本身
    /// 
    /// 注意 ： 可能会因为全局时间缩放  而导致错误
    /// </summary>
    /// <param name="exclued"></param>
    /// <param name="scale"></param>
    public static void SetPartScale(this Transform s, Transform[] exclued, float scale)
    {
        CCActionMgr.Instance.SetPartScale(exclued,scale);
    }
}