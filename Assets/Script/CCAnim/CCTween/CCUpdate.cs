//*********************************************************************
//
//					   ScriptName 	: CCUpdate
//
//                     Project	    : CCAnim                                 
//                                 
//*********************************************************************

using UnityEngine;
public class CCUpdate : MonoBehaviour {


    void OnDisable()
    {
        CCActionMgr.UnActionMgr();
    }

	void Update () {
	    CCActionMgr.Instance.Update();
	}
}