//*********************************************************************
//
//							ScriptName:	Move
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public Transform tr;
    public Text      target;
    public Image     iamge;
	void Start ()
	{
        CCAction action = null;
        CCAction action1 = null;
	    CCAction action3 = null;

         action = target.UIMoveTo(new Vector3(300, 0), 3f);
         action.SetComplete = () => { action1 = target.UIMoveToX(-300, 5f); };


        action3 = iamge.UIMoveTo(new Vector3(-300f, 150f), 3f);
        action3.SetComplete = () => { iamge.UIMoveX(350, 330, 3f); };

        action3.SetComplete = () => { CCFunction.UIMove(iamge, new Vector3(300, -150), new Vector3(-300, 150), 4f); };

        // 注意 ： 场景物体请使用使用Transfrom移动 
        //         ui 请使用 Text 或image 等

        tr.Move(new Vector3(-8, -3), new Vector3(8, 3), 5f);
	}
	
	void Update () {
	
	}
}
