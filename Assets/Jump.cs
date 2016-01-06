//*********************************************************************
//
//							ScriptName:	Jump
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{

    public Text target;
    public Image image;
    void Start()
    {
        CCAction action = target.Jump(new Vector2(10, 10), 10, 5, 5f);
        action.SetComplete = () => { target.Jump(new Vector2(50, 50), 10, 5, 5f); };

        image.Jump(new Vector2(100, 100), 20, 10, 5f).SetComplete = () =>
        {
            image.Jump(new Vector2(10, 10), 30, 10, 2f);
        };
    }

    void Update () {
	
	}
}
