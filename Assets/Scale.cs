//*********************************************************************
//
//							ScriptName:	Scale
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;

public class Scale : MonoBehaviour
{
    public Transform tr;
    public Transform tr1;

    void Start ()
    {

        UIScale(new Vector3(1, 1, 1), new Vector3(0, 0, 0), 2f);
        SceneScale2(new Vector3(1, 1, 1), new Vector3(0, 0, 0), 2f);

        UIRotation(new Vector3(0,0,360),new Vector3(0,0,90), 4f);
        SceneRotation(new Vector3(0, 0, 360), new Vector3(0, 0, 90), 4f);
    }


    public void UIRotation(Vector3 rotation,Vector3 end,float time)
    {
        tr.Rotation(rotation, end, time).SetComplete = () => { UIRotation(end, rotation, time); };
    }

    public void SceneRotation(Vector3 rotation, Vector3 end, float time)
    {
        tr1.Rotation(rotation, end, time).SetComplete = () => { SceneRotation(end, rotation, time); };
    }

  

    public void UIScale(Vector3 scale,Vector3 end, float time)
    {
        tr.Scale(scale, end, time).SetComplete = () => { UIScale(end, scale, time); };   
    }

    public void SceneScale2(Vector3 scale, Vector3 end, float time)
    {
        tr1.Scale(scale, end, time).SetComplete = () => { SceneScale2(end, scale, time); };
    }
}
