//*********************************************************************
//
//					   ScriptName 	: CCFunction
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class CCFunction {

    #region  UI Move  注意 ： 场景物体请使用使用Transfrom移动   ui 请使用 Text image RectTransform 等

    /// <summary>
    /// CCFunction
    /// 
    /// 移动至目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveTo(this RectTransform t, Vector2 endPos, float time)
    {
        return Move(t, t.anchoredPosition, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// x轴 移动至目标点
    /// 
    /// 注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveToX(this RectTransform t, float endx, float time)
    {
        return MoveX(t, t.anchoredPosition.x, endx, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// y轴 移动至目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveToY(this RectTransform t, float endY, float time)
    {
        return MoveY(t, t.anchoredPosition.y, endY, time);
    }

    /// <summary>
    /// CCFunction
    /// 
    /// 坐标移动
    /// 
    /// 从开始点移动到结束点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveTo(this RectTransform t, Vector2 startPos, Vector2 endPos, float time)
    {
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// x轴 移动
    /// 
    /// 从开始点移动到目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveX(this RectTransform t, float startx, float endx, float time)
    {
        Vector3 startPos = t.anchoredPosition;
        startPos.x = startx;
        Vector3 endPos = t.anchoredPosition;
        endPos.x = endx;
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// y轴移动
    /// 
    /// 从开始点移动到目标点
    /// 
    /// 注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveY(this RectTransform t, float starY, float endY, float time)
    {
        Vector3 startPos = t.anchoredPosition;
        startPos.y = starY;
        Vector3 endPos = t.anchoredPosition;
        endPos.y = endY;
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z轴移动
    /// 
    ///从开始点移动到目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveZ(this RectTransform t, float startZ, float endZ, float time)
    {
        Vector3 startPos = t.anchoredPosition;
        startPos.z = startZ;
        Vector3 endPos = t.anchoredPosition;
        endPos.z = endZ;
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z轴移动
    /// 
    ///从开始点移动到目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMove(this RectTransform t, Vector2 startPos, Vector2 endPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("RectTransform 为空请检查 ");
            return null;
        }
        CCUIMove action = CCUIMove.Create(startPos, endPos, time);
        t.transform.RunAction(action);
        return action;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// x轴 移动至目标点
    /// 
    /// 注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveToX(this MaskableGraphic t, float endx, float time)
    {
        return UIMoveX(t, t.rectTransform.anchoredPosition.x, endx, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// y轴 移动至目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveToY(this MaskableGraphic t, float endY, float time)
    {
        return UIMoveY(t, t.rectTransform.anchoredPosition.y, endY, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// x轴 移动
    /// 
    /// 从开始点移动到目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveX(this MaskableGraphic t, float startx, float endx, float time)
    {
        Vector3 startPos = t.rectTransform.anchoredPosition;
        startPos.x = startx;
        Vector3 endPos = t.rectTransform.anchoredPosition;
        endPos.x = endx;
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// y轴移动
    /// 
    /// 从开始点移动到目标点
    /// 
    /// 注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveY(this MaskableGraphic t, float starY, float endY, float time)
    {
        Vector3 startPos = t.rectTransform.anchoredPosition;
        startPos.y = starY;
        Vector3 endPos = t.rectTransform.anchoredPosition;
        endPos.y = endY;
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z轴移动
    /// 
    ///从开始点移动到目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveZ(this MaskableGraphic t, float startZ, float endZ, float time)
    {
        Vector3 startPos = t.rectTransform.anchoredPosition;
        startPos.z = startZ;
        Vector3 endPos = t.rectTransform.anchoredPosition;
        endPos.z = endZ;
        return UIMove(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 坐标移动
    /// 
    /// 从开始点移动到结束点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveTo(this MaskableGraphic t, Vector2 startPos, Vector2 endPos, float time)
    {
        return UIMove(t, startPos, endPos, time);
    }

    /// <summary>
    /// CCFunction
    /// 
    /// 移动至目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMoveTo(this MaskableGraphic t, Vector2 endPos, float time)
    {
        return UIMove(t, t.rectTransform.anchoredPosition, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z轴移动
    /// 
    ///从开始点移动到目标点
    /// 
    ///  注意 ： 只适用于UI 如要场景物体使用 请使用Transfrom
    /// </summary>
    public static CCAction UIMove(this MaskableGraphic t, Vector2 startPos, Vector2 endPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入Transform 为空请检查 ");
            return null;
        }
        CCUIMove action = CCUIMove.Create(startPos, endPos, time);
        t.transform.RunAction(action);
        return action;
    }
    #endregion

    #region Move  场景物体移动  注意 ： 场景物体请使用使用Transfrom移动   ui 请使用 Text 或image RectTransform 等
    /// <summary>                     
    /// CCFunction
    /// 
    /// 移动至目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveTo(this Transform t, Vector3 endPos, float time)
    {
        return Move(t, t.position, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// x轴 移动至目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveToX(this Transform t, float endx, float time)
    {
        return MoveX(t, t.position.x, endx, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// y轴 移动至目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveToY(this Transform t, float endY, float time)
    {
        return MoveY(t, t.position.y, endY, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// z轴 移动至目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveToZ(this Transform t, float endZ, float time)
    {
        return MoveZ(t, t.position.z, endZ, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 坐标移动
    /// 
    /// 从开始点移动到结束点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveTo(this Transform t, Vector3 startPos, Vector3 endPos, float time)
    {
        return Move(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// x轴 移动
    /// 
    /// 从开始点移动到目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveX(this Transform t, float startx, float endx, float time)
    {
        Vector3 startPos = t.position;
        startPos.x = startx;
        Vector3 endPos = t.position;
        endPos.x = endx;
        return Move(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// y轴移动
    /// 
    /// 从开始点移动到目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveY(this Transform t, float starY, float endY, float time)
    {
        Vector3 startPos = t.position;
        startPos.y       = starY;
        Vector3 endPos   = t.position;
        endPos.y         = endY;
  
         
        return Move(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z轴移动
    /// 
    /// 从开始点移动到目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction MoveZ(this Transform t, float startZ, float endZ, float time)
    {
        Vector3 startPos = t.position;
        startPos.z = startZ;
        Vector3 endPos = t.position;
        endPos.z = endZ;
        return Move(t, startPos, endPos, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z轴移动
    /// 
    /// 从开始点移动到目标点
    /// 
    /// 注意 ： 只适用于场景物体 如要UI使用 请使用 Text image 或 RectTransform MaskableGraphic 等
    /// </summary>
    public static CCAction Move(this Transform t, Vector3 startPos, Vector3 endPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入Transform 为空请检查 ");
            return null;
        }

        CCMove action = CCMove.Create(startPos, endPos, time);
        t.RunAction(action);
        return action;
    }
    #endregion


    #region UIBezier
    /// <summary>
    /// CCFunction
    /// 
    ///  Bezier 移动 
    /// 
    ///  默认高度为1
    /// 
    /// 注意 ： 只是用于UI 如要使用场景物体 请使用Transfrom
    /// </summary>
    public static CCAction UIBezierMove(this RectTransform t, Vector2 startPos, Vector2 endPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 RectTransform 为空请检查 ");
            return null;
        }
        CCUIBezier action = CCUIBezier.Create(time, new CCUIBezier.BezierConfig(startPos, endPos));
        t.transform.RunAction(action);
        return action;
    }

    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于UI 如要使用场景物体 请使用Transfrom
    /// </summary>
    public static CCAction UIBezierMove(this RectTransform t, Vector2 startPos, Vector2 endPos, Vector2 controlPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 RectTransform 为空请检查 ");
            return null;
        }
        CCUIBezier action = CCUIBezier.Create(time, new CCUIBezier.BezierConfig(startPos, endPos, controlPos));
        t.transform.RunAction(action);
        return action;
    }


    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于UI 如要使用场景物体 请使用Transfrom
    /// </summary>
    public static CCAction UIBezierMove(this RectTransform t, Vector2[] pos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 RectTransform 为空请检查 ");
            return null;
        }
        CCUIBezier action = CCUIBezier.Create(time, new CCUIBezier.BezierConfig(pos));
        t.transform.RunAction(action);
        return action;
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Bezier 移动 
    /// 
    ///  默认高度为1
    /// 
    /// 注意 ： 只是用于UI 如要使用场景物体 请使用Transfrom
    /// </summary>
    public static CCAction UIBezierMove(this MaskableGraphic t, Vector2 startPos, Vector2 endPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 MaskableGraphic 为空请检查 ");
            return null;
        }
        CCUIBezier action = CCUIBezier.Create(time, new CCUIBezier.BezierConfig(startPos, endPos));
        t.transform.RunAction(action);
        return action;
    }

    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于UI 如要使用场景物体 请使用Transfrom
    /// </summary>
    public static CCAction UIBezierMove(this MaskableGraphic t, Vector2 startPos, Vector2 endPos, Vector2 controlPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 MaskableGraphic 为空请检查 ");
            return null;
        }
        CCUIBezier action = CCUIBezier.Create(time, new CCUIBezier.BezierConfig(startPos, endPos, controlPos));
        t.transform.RunAction(action);
        return action;
    }
    public static CCAction UIBezierMove(this MaskableGraphic t, RectTransform[] pos, float time) {
        Vector2[] ps = new Vector2[pos.Length];
        for (int i = 0; i < pos.Length; i++) {
            ps[i] = pos[i].anchoredPosition;
        }
        return UIBezierMove(t, ps, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于UI 如要使用场景物体 请使用Transfrom
    /// </summary>
    public static CCAction UIBezierMove(this MaskableGraphic t, Vector2[] pos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 MaskableGraphic 为空请检查 ");
            return null;
        }
        CCUIBezier action = CCUIBezier.Create(time, new CCUIBezier.BezierConfig(pos));
        t.transform.RunAction(action);
        return action;
    }
    #endregion

    #region Bezier 
    /// <summary>
    /// CCFunction
    /// 
    ///  Bezier 移动 
    /// 
    /// 默认高度为1
    /// 
    /// 注意 ： 只是用于场景物体 如要UI使用 请使用 Text Image 或 RectTransform  MaskableGraphic
    /// </summary>
    public static CCAction BezierMove(this Transform t, Vector2 startPos, Vector2 endPos, bool isV2, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCBezier action = CCBezier.Create(time, new CCBezier.BezierConfig(startPos, endPos, isV2));
        t.RunAction(action);
        return action;
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Bezier 移动 
    /// 
    /// 注意 ： 只是用于场景物体 如要UI使用 请使用 Text Image 或 RectTransform MaskableGraphic
    /// </summary>
    public static CCAction BezierMove(this Transform t, Vector3 startPos, Vector3 endPos, Vector3 controlPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCBezier action = CCBezier.Create(time, new CCBezier.BezierConfig(startPos, endPos, controlPos));
        t.RunAction(action);
        return action;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于场景物体 如要UI使用 请使用 Text Image 或 RectTransform MaskableGraphic
    /// </summary>
    public static CCAction BezierMove(this Transform t, Vector2 startPos, Vector2 endPos, Vector2 controlPos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCBezier action = CCBezier.Create(time, new CCBezier.BezierConfig(startPos, endPos, controlPos));
        t.RunAction(action);
        return action;
    }
    public static CCAction BezierMove(this Transform t, Transform[] pos, float time) {
        Vector3[] p2 = new Vector3[pos.Length];
        for (int i = 0; i < pos.Length; i++) {
            p2[i] = pos[i].position;
        }
        return BezierMove(t, p2, time);
    }

    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于场景物体 如要UI使用 请使用 Text Image 或 MaskableGraphic
    /// </summary>
    public static CCAction BezierMove(this Transform t, Vector2[] pos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCBezier action=CCBezier.Create(time,new CCBezier.BezierConfig(pos));
        t.RunAction(action);
        return action;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// Bezier 移动 
    /// 
    /// 注意 ： 只是用于场景物体 如要UI使用 请使用 Text Image 或 MaskableGraphic
    /// </summary>
    public static CCAction BezierMove(this Transform t, Vector3[] pos, float time)
    {
        if(t == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCBezier action = CCBezier.Create(time, new CCBezier.BezierConfig(pos));
        t.RunAction(action);
        return action;
    }
    #endregion

    #region Alpha


    /// <summary>
    /// CCFunction
    /// 
    ///  设置目标UI的Alpha 
    /// 
    ///  开始alpha 使用目标身上的alpha 
    ///  如果没有CancasGropu组件 将使用默认值 1
    /// </summary>
    public static CCAction UIAlpha(this Transform s, Transform target, float endAlpha, float time)
    {
        CanvasGroup grope = target.GetComponent<CanvasGroup>();
        return UIAlpha(target, grope != null ? grope.alpha : 1, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 设置目标UI的Alpha
    /// </summary>
    public static CCAction UIAlpha(this Transform s, Transform target, float startAlpha, float endAlpha, float time)
    {
        return UIAlpha(target, startAlpha, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  设置UI的Alpha 
    /// 
    ///  开始alpha 使用目标身上的alpha 
    ///  如果没有CancasGropu组件 将使用默认值 1
    /// </summary>
    public static CCAction UIAlpha(this Transform s, float endAlpha, float time)
    {
        CanvasGroup grope = s.GetComponent<CanvasGroup>();
        return UIAlpha(s, grope != null ? grope.alpha : 1, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  设置UI的Alpha 
    /// 
    ///  开始alpha 使用目标身上的alpha 
    /// </summary>
    public static CCAction UIAlpha(this CanvasGroup group, float endAlpha, float time)
    {
        return UIAlpha(group.transform, group.alpha, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 设置目标UI的Alpha
    /// </summary>
    public static CCAction UIAlpha(this CanvasGroup group, float startAlpha, float endAlpha, float time)
    {
      return  UIAlpha(group.transform, startAlpha, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 设置目标UI的Alpha
    /// </summary>
    public static CCAction UIAlpha(this Text text, float startAlpha, float endAlpha, float time)
    {
        return UIAlpha(text.transform, startAlpha, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  设置UI的Alpha 
    /// 
    ///  开始alpha 使用目标身上的alpha 
    /// </summary>
    public static CCAction UIAlpha(this Text text, float endAlpha, float time)
    {
        CanvasGroup grope = text.transform.GetComponent<CanvasGroup>();
        return UIAlpha(text.transform, grope != null ? grope.alpha : 1, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 设置目标UI的Alpha
    /// </summary>
    public static CCAction UIAlpha(this Image image, float startAlpha, float endAlpha, float time)
    {
        return UIAlpha(image.transform, startAlpha, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  设置UI的Alpha 
    /// 
    ///  开始alpha 使用目标身上的alpha 
    /// </summary>
    public static CCAction UIAlpha(this Image image, float endAlpha, float time)
    {
        CanvasGroup grope = image.transform.GetComponent<CanvasGroup>();
        return UIAlpha(image.transform, grope != null ? grope.alpha : 1, endAlpha, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 设置UI 的Alpha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="startAlpha"></param>
    /// <param name="endAlpha"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static CCAction UIAlpha(this Transform s, float startAlpha, float endAlpha, float time)
    {
        if(s == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCUIAlpha action = CCUIAlpha.Create(startAlpha, endAlpha, time);
        s.RunAction(action);
        return action;
    }
    #endregion

    #region Rotation
    /// <summary>
    /// CCFunction
    /// 
    /// X  轴旋转至
    /// </summary>
    public static CCAction RotationX(this Transform s, float endX, float time)
    {
        Vector3 start = new Vector3(s.eulerAngles.x, s.eulerAngles.y, s.eulerAngles.z);
        Vector3 end = new Vector3(endX, s.eulerAngles.y, s.eulerAngles.z);
        return Rotation(s, start, end, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Y 轴旋转至
    /// </summary>
    public static CCAction RotationY(this Transform s, float endY, float time)
    {
        Vector3 start = new Vector3(s.eulerAngles.x, s.eulerAngles.y, s.eulerAngles.z);
        Vector3 end = new Vector3(s.eulerAngles.x, endY, s.eulerAngles.z);
        return Rotation(s, start, end, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// Z  轴旋转至
    /// </summary>
    public static CCAction RotationZ(this Transform s, float endZ, float time)
    {
        Vector3 start = new Vector3(s.eulerAngles.x, s.eulerAngles.y, s.eulerAngles.z);
        Vector3 end = new Vector3(s.eulerAngles.x, s.eulerAngles.y, endZ);
        return Rotation(s, start, end, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  X 轴从指定角度 旋转到结束角度
    /// </summary>
    public static CCAction RotationX(this Transform s, float startX, float endX, float time)
    {
        Vector3 start   = new Vector3(startX, s.eulerAngles.y, s.eulerAngles.z);
        Vector3 end     = new Vector3(endX, s.eulerAngles.y, s.eulerAngles.z);
        return Rotation(s, start, end,time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Y 轴从指定角度 旋转到结束角度
    /// </summary>
    public static CCAction RotationY(this Transform s, float startY, float endY, float time)
    {
        Vector3 start = new Vector3(s.eulerAngles.x, startY, s.eulerAngles.z);
        Vector3 end   = new Vector3(s.eulerAngles.x, endY, s.eulerAngles.z);
        return Rotation(s, start, end, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  Z 轴从指定角度 旋转到结束角度
    /// </summary>
    public static CCAction RotationZ(this Transform s, float startZ, float endZ, float time)
    {
        Vector3 start = new Vector3(s.eulerAngles.x, s.eulerAngles.y, startZ);
        Vector3 end   = new Vector3(s.eulerAngles.x, s.eulerAngles.y, endZ);
        return Rotation(s, start, end, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  旋转到指定角度
    /// </summary>
    public static CCAction RotationTo(this Transform s, Vector3 endRotation, float time)
    {
        return Rotation(s, s.eulerAngles, endRotation, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 从开始角度旋转到指定角度
    /// </summary>
    public static CCAction Rotation(this Transform s, Vector3 startRotation, Vector3 endRotation, float time)
    {
        if(s == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCRotation rotation=CCRotation.Create(startRotation,endRotation,time);
        s.RunAction(rotation);
        return rotation;
    }
    #endregion

    #region Scale
    /// <summary>
    /// CCFunction
    /// 
    /// 缩放 X 到
    /// </summary>
    public static CCAction ScaleToX(this Transform s, float endX, float time)
    {
        return ScaleToX(s, s.localScale.x, endX, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  缩放 Y 到
    /// </summary>
    public static CCAction ScaleToY(this Transform s, float endY, float time)
    {
        return ScaleToY(s, s.localScale.y, endY, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    ///  缩放 Z 到
    /// </summary>
    public static CCAction ScaleToZ(this Transform s, float endZ, float time)
    {
        return ScaleToZ(s, s.localScale.z, endZ, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 从 startX  缩放 endX 到
    /// </summary>
    public static CCAction ScaleToX(this Transform s, float startX, float endX, float time)
    {
        Vector3 startScale  = s.localScale;
        Vector3 endScale    = s.localScale;
        startScale.x        = startX;
        endScale.x          = endX;
        return Scale(s, startScale, endScale, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 从 startY  缩放 endY 到
    /// </summary>
    public static CCAction ScaleToY(this Transform s, float startY, float endY, float time)
    {
        Vector3 startScale  = s.localScale;
        Vector3 endScale    = s.localScale;
        startScale.y        = startY;
        endScale.y          = endY;
        return Scale(s, startScale, endScale, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 从 startZ  缩放 endZ 到
    /// </summary>
    public static CCAction ScaleToZ(this Transform s, float startZ, float endZ, float time)
    {
        Vector3 startScale  = s.localScale;
        Vector3 endScale    = s.localScale;
        startScale.z        = startZ;
        endScale.z          = endZ;
        return Scale(s, startScale, endScale, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 缩放至目标
    /// </summary>
    public static CCAction ScaleTo(this Transform s, Vector3 endScale, float time)
    {
        return Scale(s, s.localScale, endScale, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// startScale 缩放到 endScale
    /// </summary>
    public static CCAction Scale(this Transform s, Vector3 startScale, Vector3 endScale, float time)
    {
        if(s == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCScale action=CCScale.Create(startScale,endScale,time);
        s.RunAction(action);
        return action;
    }
    #endregion

    #region Color 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色 R 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorRTO(this Transform s, float endr, float time) {
        return ColorR(s, getColor(s).r, endr, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色 G 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorGTO(this Transform s, float endg, float time) {
        return ColorG(s, getColor(s).g, endg, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色 B 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorBTO(this Transform s, float endb, float time) {
        return ColorB(s, getColor(s).b, endb, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色 A 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorATO(this Transform s, float enda, float time) {
        return ColorA(s, getColor(s).a, enda, time);
    }

    /// <summary>
    /// CCFunction
    /// 
    /// 颜色从开始值 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorB(this Transform s, float startb, float endb, float time) {
        Color startcolor = getColor(s);
        Color endColor   = startcolor;
        startcolor.b     = startb;
        endColor.b       = endb;
        return Color(s, startcolor, endColor, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色从开始值 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorG(this Transform s, float startg, float endg, float time) {
        Color startcolor = getColor(s);
        Color endColor   = startcolor;
        startcolor.g     = startg;
        endColor.g       = endg;
        return Color(s, startcolor, endColor, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色从开始值 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorR(this Transform s, float startr, float endr, float time) {
        Color startcolor = getColor(s);
        Color endColor   = startcolor;
        startcolor.r     = startr;
        endColor.r       = endr;
        return Color(s, startcolor, endColor, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色从开始值 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorA(this Transform s, float starta, float enda, float time) {
        Color startcolor = getColor(s);
        Color endColor   = startcolor;
        startcolor.a     = starta;
        endColor.a       = enda;
        return Color(s, startcolor, endColor, time);
    }

    private static Color getColor(Transform s) {
        return s.GetComponent<Renderer>().material.color;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction ColorTo(this Transform s, Color endColor, float time) {
        return Color(s, getColor(s), endColor, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 颜色从开始值 渐变至目标值
    /// 
    /// 注意 ： 颜色值的 R G B A 最大值 为1 最小值 为0
    /// </summary>
    public static CCAction Color(this Transform s,Color startColor,Color endColor,float time) {
        if (s == null) {
            Debug.LogError("传入 Transform 为空 无法完成颜色渐变");
            return null;
        }
        CCColor color = CCColor.Cretate(startColor, endColor, time);
        s.RunAction(color);
        return color;
    }
    #endregion

    #region Jump
    /// <summary>
    /// CCFunction
    /// 
    /// 跳跃
    /// </summary>
    /// <param name="s"></param>
    /// <param name="delta"></param>
    /// <param name="heiht"> 高度</param>
    /// <param name="jumps">次数</param>
    /// <param name="time">时间</param>
    /// <returns></returns>
    public static CCAction Jump(this Transform s, Vector2 delta, float heiht,int jumps, float time)
    {
        if(s == null)
        {
            Debug.LogError("传入 Transform 为空请检查 ");
            return null;
        }
        CCJump action   = CCJump.Create(time, delta, heiht, jumps);
        s.RunAction(action);
        return action;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 跳跃
    /// </summary>
    /// <param name="g"></param>
    /// <param name="delta"></param>
    /// <param name="heiht"> 高度</param>
    /// <param name="jumps">次数</param>
    /// <param name="time">时间</param>
    /// <returns></returns>
    public static CCAction Jump(this GameObject g, Vector2 delta, float heiht, int jumps, float time)
    {
        return Jump(g.transform, delta, heiht, jumps, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 跳跃
    /// </summary>
    /// <param name="g"></param>
    /// <param name="delta"></param>
    /// <param name="heiht"> 高度</param>
    /// <param name="jumps">次数</param>
    /// <param name="time">时间</param>
    /// <returns></returns>
    public static CCAction Jump(this Text g, Vector2 delta, float heiht, int jumps, float time)
    {
        return Jump(g.transform, delta, heiht, jumps, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 跳跃
    /// </summary>
    /// <param name="g"></param>
    /// <param name="delta"></param>
    /// <param name="heiht"> 高度</param>
    /// <param name="jumps">次数</param>
    /// <param name="time">时间</param>
    /// <returns></returns>
    public static CCAction Jump(this Image g, Vector2 delta, float heiht, int jumps, float time)
    {
        return Jump(g.transform, delta, heiht, jumps, time);
    }
    #endregion

    #region  Typewriting
    /// <summary>
    /// CCFunction
    /// 
    /// 打字效果
    /// </summary>
    /// <param name="s"></param>
    /// <param name="text">Text 组件</param>
    /// <param name="content">内容</param>
    /// <param name="time">持续时间</param>
    /// <returns></returns>
    public static CCAction Typewriting(this Transform s,Text text,string content,float time, AudioClip audio)
    {
        return Typewriting(text,content,time, audio);
    }
    public static CCAction Typewriting(this Transform s, Text text, string content, float time)
    {
        return Typewriting(text, content, time, null);
    }
    public static CCAction Typewriting(this MonoBehaviour b, Text text, string content, float time)
    {
        return Typewriting(text, content, time, null);
    }
    public static CCAction Typewriting(this MonoBehaviour b, Text text, string content, float time, AudioClip audio)
    {
        return Typewriting(text, content, time, audio);
    }

    public static CCAction Typewriting(this Text text, string content, float time)
    {
        return Typewriting(text, content, time, null);
    }
    public static CCAction Typewriting(this Text text, string content, float time,AudioClip audio)
    {
        if(text == null)
        {
            Debug.LogError("传入 text 为空请检查 ");
            return null;
        }
        CCUITypewriting action = CCUITypewriting.Cerate(text, content, time, audio);
        text.transform.RunAction(action);
        return action;
    }
    #endregion

    #region Delay
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this MonoBehaviour s, Action action, CCDelay.OnAction onAction, float time, params UnityEngine.Object[] _params)
    {
        CCDelay dela = Delay(s, action, time);
        dela.SetHandle(onAction, _params);
        return dela;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this MonoBehaviour s, Action action, CCDelay.OnAction onAction, float time)
    {
        CCDelay dela = Delay(s, action, time);
        dela.SetHandle(onAction, null);
        return dela;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this MonoBehaviour s, Action onaction, float time)
    {
        return Delay(s.transform, onaction, time);
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this GameObject s, Action action, CCDelay.OnAction onAction, float time, params UnityEngine.Object[] _params)
    {
        CCDelay dela = Delay(s, action, time);
        dela.SetHandle(onAction, _params);
        return dela;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this GameObject s, Action action, CCDelay.OnAction onAction, float time)
    {
        CCDelay dela = Delay(s, action, time);
        dela.SetHandle(onAction, null);
        return dela;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this GameObject s, Action onaction, float time)
    {
        return Delay(s.transform, onaction, time);
    }

    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this Transform s, Action action, CCDelay.OnAction onAction, float time, params object[] _params)
    {
        CCDelay dela = Delay(s, action, time);
        dela.SetHandle(onAction, _params);
        return dela;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this Transform s, Action action, CCDelay.OnAction onAction, float time)
    {
        CCDelay dela = Delay(s, action, time);
        dela.SetHandle(onAction, null);
        return dela;
    }
    /// <summary>
    /// CCFunction
    /// 
    /// 延时调用
    /// </summary>
    public static CCDelay Delay(this Transform s,Action onaction,float time)
    {
        if (s == null)
        {
            Debug.LogError("传入 Transfrom 为空 请检查");

            return null;
        }
        CCDelay action = CCDelay.Create(onaction, time);
        s.RunAction(action);
        return action;
    }
    #endregion
}