//*********************************************************************
//
//							ScriptName:	CCUITypewriting
//
//							Project	  : CCAnim
//
//*********************************************************************

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CCUITypewriting : CCActionTime {

    public static CCUITypewriting Cerate(Text text, string content, float time, AudioClip audio)
    {
        return new CCUITypewriting() {
            Content   = content,
            MyText    = text,
            Interval  = time / content.Length,
            Audio     = audio,
            _duration = time
        };
    }

    public string   Content { get; set; }
    public Text     MyText  { get; set; }
    public float    Interval{ get; set; }
    public AudioClip Audio  { get; set; }

    protected AudioSource Source { get; set; }
    protected override void StartRun()
    {
        if (Source == null) {
            Source = _target.GetComponent<AudioSource>();
            if (Source == null)
                Source = _target.gameObject.AddComponent<AudioSource>();
        }
   
        //MyText.text = "";
        CCCoroutineController.Instance.StartCoroutine(Writing());
    }

    public override void Stop()
    {
        CCCoroutineController.Instance.StopCoroutine(Writing());
        base.Stop();
    }
    protected override void EndRun() {
        //MyText.text = Content;
        Source.Stop();
    }
    public IEnumerator Writing()
    {
    
        for(int i = 0; i < Content.Length; i++)
        {
            MyText.text = Content.Substring(0, i + 1);
            if (Audio != null)
                Source.PlayOneShot(Audio);
            yield return new WaitForSeconds(Interval);
        }
    }
}