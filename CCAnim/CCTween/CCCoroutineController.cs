//*********************************************************************
//
//							ScriptName:	CCCoroutineController
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class CCCoroutineController : MonoBehaviour {

    private static CCCoroutineController instance;

    public static CCCoroutineController Instance
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
                instance = go.AddComponent<CCCoroutineController>();
            }
            return instance;
        }
    }
}