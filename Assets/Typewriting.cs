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

    public Text  typing;
    public AudioClip audio;

    public Text textMove;
    public Image imageMove;
	void Start ()
	{

	    dazi("可以实现打字效果吗？ \n 很好奇的样子 \n 试试看吧 \n 你看效果还可以吧 \n This is typing", 3f);
	}

    public void dazi(string content, float time)
    {
        typing.Typewriting(content, time, audio).SetComplete = () => { CCFunction.Delay(this, () => { Move(); ImageMove(); }, 0.5f); };
       
    }

    public void Move() {
        textMove.gameObject.SetActive(true);
        CCAction action = textMove.UIMove(new Vector2(-390, 160), new Vector2(390, 160), 5f);
        action.SetComplete = () => { textMove.UIMoveTo(new Vector2(0, 160), 4f).SetComplete = () => { Scale(new Vector3(1, 1, 1), new Vector3(0, 0, 0), 2f); }; };
    }
    public void Scale(Vector3 start, Vector3 end, float time) {
        textMove.transform.Scale(start, end, time).SetComplete = () => { Scale(end, start, time); };
    }
    public void ImageMove() {
        imageMove.gameObject.SetActive(true);
        CCAction action = imageMove.UIMove(new Vector2(-390, -200), new Vector2(390, -200), 5);
        action.SetComplete = () => { imageMove.UIMoveTo(new Vector2(0, -200), 2f).SetComplete = () => { imageScale(new Vector3(1,1,1),new Vector3(0,0,0),2f); }; };
    }
    public void imageScale(Vector3 start,Vector3 end,float time) {
        imageMove.transform.Scale(start, end, time).SetComplete = () => { imageScale(end, start, time); };
    }
}
