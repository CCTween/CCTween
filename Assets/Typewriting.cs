//*********************************************************************
//
//							ScriptName:	Typewriting
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typewriting : MonoBehaviour
{

    public Text text;
    public AudioClip audio;

    public Text text2;
    public Image image;
	void Start ()
	{

	    dazi("可以实现打字效果吗？ \n 很好奇的样子 \n 试试看吧 \n 你看效果还可以吧", 3f);
	}

    public void dazi(string content, float time)
    {
        text.Typewriting(content, time, audio).SetComplete = () => { CCFunction.Delay(this, () => { Move(); imageMove(); }, 0.5f); };
       
    }

    public void Move() {
        text2.gameObject.SetActive(true);
        CCAction action = text2.UIMove(new Vector2(-390, 160), new Vector2(390, 160), 5f);
        action.SetComplete = () => { text2.UIMoveTo(new Vector2(0, 160), 4f).SetComplete = () => { Scale(new Vector3(1, 1, 1), new Vector3(0, 0, 0), 2f); }; };
    }
    public void Scale(Vector3 start, Vector3 end, float time) {
        text2.transform.Scale(start, end, time).SetComplete = () => { Scale(end, start, time); };
    }
    public void imageMove() {
        image.gameObject.SetActive(true);
        CCAction action = image.UIMove(new Vector2(-390, -200), new Vector2(390, -200), 5);
        action.SetComplete = () => { image.UIMoveTo(new Vector2(0, -200), 2f).SetComplete = () => { imageScale(new Vector3(1,1,1),new Vector3(0,0,0),2f); }; };
    }
    public void imageScale(Vector3 start,Vector3 end,float time) {
        image.transform.Scale(start, end, time).SetComplete = () => { imageScale(end, start, time); };
    }
}
