//*********************************************************************
//
//					   ScriptName 	: FlutterText
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************
using System;
using UnityEngine;
using UnityEngine.UI;

public class FlutterText : MonoBehaviour
{
    private Text content;
    private Text Content
    {
        get { return content ?? (content = this.GetComponentByPath<Text>("Content")); }
        set { content = value; }
    }
    private Image backdrop;
    private Image Backdrop
    {
        get { return backdrop ?? (backdrop = this.GetComponentByPath<Image>("Backdrop")); }
        set { backdrop = value; }
    }
    private RectTransform _myTransform;
    private RectTransform myTransform
    {
        get
        {
            if (_myTransform == null)
                _myTransform = GetComponent<RectTransform>();

            return _myTransform ;
        }
        set { myTransform = value; }
    }

    public Action<FlutterText> OnComplete;

    public float Time = 1;

    public float height = 50;

    public bool  isBackdrop = false;
  
    T GetComponentByPath<T>(string path) {

       return transform.Find(path).GetComponent<T>();
    }

    #region 内容坐标
    public void SetText(string text)
    {
        SetText(text, Time);
    }
    public void SetText(string text, float time)
    {
        Vector2 endPos = transform.position;
        endPos.y += height;
        SetText(text, endPos, time);
    }
    public void SetText(string text,Vector2 endPos,float time)
    {
        SetText(text, Vector2.zero, endPos, time);
    }
    public void SetText(string text, Vector2 startPos, Vector2 endPos, float time)
    {
        SetText(text, startPos, endPos, Vector2.zero, isBackdrop, time);
    }
    #endregion

    #region 背景坐标
    public void SetText(string content, bool backdrop)
    {
        Vector2 endpos = transform.position;
        endpos.y += height;
        SetText(content, endpos, backdrop);
    }

    public void SetText(string content,Vector2 endPos, bool backdrop)
    {
        SetText(content, Vector2.zero, endPos, backdrop);
    }
    public void SetText(string content,Vector2 startPos, Vector2 endPos, bool backdrop)
    {
        SetText(content, startPos, endPos, Vector2.zero, backdrop, Time);
    }
    #endregion

    #region 大小坐标
    public void SetTextSize(string text, Vector2 size)
    {
        Vector2 endpos = transform.position;
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

    /// <summary>
    ///  设置飘字
    /// </summary>
    /// <param name="text">内容</param>
    /// <param name="startPos">位置</param>
    /// <param name="size">大小</param>
    /// <param name="backdrop">是否显示背景</param>
    public void SetText(string text, Vector2 startPos,Vector2 endPos, Vector2 size, bool backdrop,float time)
    {

        if(!Backdrop || !Content)
        {
            throw new Exception("背景或可显示文本没有找到");
            //return;
        }

        gameObject.SetActive(true);

        Content.text = text;

        myTransform.anchoredPosition = startPos;

        if(size != Vector2.zero)
        {
            myTransform.sizeDelta = size;
        }
        Backdrop.gameObject.SetActive(backdrop);

        myTransform.UIAlpha(1, 0, time);
        myTransform.UIMove(startPos, endPos, time).SetComplete = () => {
            gameObject.SetActive(false);
            if(OnComplete != null)
                OnComplete(this);
        };
    }
}
