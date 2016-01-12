//*********************************************************************
//
//					   ScriptName 	: FlutterManager
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlutterManager  {

    static FlutterManager instance;
    public static FlutterManager Instance {
        get {
            if (instance == null)
                instance = new FlutterManager();
            return instance;
        }
    }

    private Transform _uiContainer;

    public Transform UIContainer
    {

        get
        {
            if (_uiContainer == null)
                _uiContainer = GameObject.Find("Canvas").GetComponent<Transform>();
            return _uiContainer;
        }
    }

    private Stack<FlutterText> flutter;

    public FlutterManager()
    {
        flutter = new Stack<FlutterText>();
    }

    private string Paht= "test/Flutter";



    public float Time = 1;

    public float height = 50;

    public bool  isBackdrop = false;

    /// <summary>
    /// 设置预约体 路径
    /// </summary>
    /// <param name="path"></param>
    public void SetPrefabsPaht(string path)
    {
        Paht = path;
    }

    #region 内容坐标
    public void SetText(string text)
    {
        SetText(text, Time);
    }
    public void SetText(string text, float time)
    {
        Vector2 endPos = Vector2.zero;
        endPos.y += height;
        SetText(text, endPos, time);
    }
    public void SetText(string text, Vector2 endPos, float time)
    {
        SetText(text,  Vector2.zero, endPos, time);
    }
    public void SetText(string text, Vector2 startPos, Vector2 endPos, float time)
    {
        SetText(text, startPos, endPos, Vector2.zero, isBackdrop, time);
    }
    #endregion

    #region 背景坐标
    public void SetText(string content, bool backdrop)
    {
        Vector2 endpos = Vector2.zero;
        endpos.y += height;
        SetText(content, endpos, backdrop);
    }

    public void SetText(string content, Vector2 endPos, bool backdrop)
    {
        SetText(content,  Vector2.zero, endPos, backdrop);
    }
    public void SetText(string content, Vector2 startPos, Vector2 endPos, bool backdrop)
    {
        SetText(content, startPos, endPos, Vector2.zero, backdrop, Time);
    }
    #endregion

    #region 大小坐标
    public void SetTextSize(string text, Vector2 size)
    {
        Vector2 endpos = Vector2.zero;
        endpos.y += height;
        SetTextSize(text, endpos, size);
    }
    public void SetTextSize(string text, Vector2 endpos, Vector2 size)
    {
        SetTextSize(text, Vector2.zero, endpos, size);
    }
    public void SetTextSize(string text, Vector2 startPos, Vector2 endPos, Vector2 size)
    {
        SetText(text, startPos, endPos, size, isBackdrop, Time);
    }
    #endregion
    public void SetText(string text, Vector2 startPos, Vector2 endPos, Vector2 size, bool backdrop, float time)
    {
        FlutterText flutterText = GetFlutterText();

        flutterText.OnComplete  = Destry;
        flutterText.SetText(text, startPos, endPos, size,backdrop, time);
    }

    private void Destry(FlutterText text)
    {
        flutter.Push(text);
    }

    private FlutterText GetFlutterText()
    {
        if (flutter.Count <= 0)
        {
           
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(Paht));
            go.transform.SetParent(UIContainer);
            FlutterText text = go.GetComponent<FlutterText>();
            return text;
        }
        return flutter.Pop();  
    }
}
