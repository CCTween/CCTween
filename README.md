# CCTween 函数库  


#[博客地址](http://www.cnblogs.com/mdrs/p/5107967.html)
   
        

#//------------ 这是使用的一些变量 以及类型　-------------------------

    public Transform MyTransform;  

    public Text text;  

    public Image image;  

    public Transform[] Bezier;  

    RectTransform rectTransform;  

    public RectTransform[] UIBezier;  

　　

#//-----------------上边 变量 类型------------------------------


     // 缩放  开始目标  结束目标  持续时间    

     MyTransform.Scale(new Vector3(1, 1, 1), new Vector3(0, 0, 0), 2f);  

      // 缩放至 目标值  需要的时间    
 
     MyTransform.ScaleTo(new Vector3(.5f, .5f, .5f), 2f);    

     // 缩放X 至目标值 持续时间    

     MyTransform.ScaleToX(1, 2f);    

     // 缩放Y 至 目标值 持续时间    

     MyTransform.ScaleToY(1, 2f);    


     // 旋转至目标值 所需要的时间    

     MyTransform.RotationTo(new Vector3(0, 0, 90), 2f);    

     // 从 开始值旋转到目标值 持续时间    

     MyTransform.Rotation(new Vector3(0, 0, 0), new Vector3(0, 0, 90), 2f);    


     // Bezier 可以做多次 Bezier 也可以做次 Bezier 最后一个参数延时时间    

     MyTransform.BezierMove(Bezier, 3f);    

     // 延时方法  延时执行函数 持续时间    

     MyTransform.Delay(() => { Debug.Log(" 这里是延时执行的方法 "); }, 3f);    

     // 从开始颜色 渐变到结束颜色 持续时间    

      MyTransform.Color(new Color(1, 1, 0), new Color(0, 1, 1), 2f);    
 
      // 从当前颜色 渐变值 目标颜色 持续时间    
 
      MyTransform.ColorTo(new Color(0, 1, 0.5f), 2f);    
 
     // 颜色G 从开始值 渐变到目标值 持续时间    

     MyTransform.ColorG(1, 0.5f, 2f);   

     // 颜色B 渐变至目标值 持续时间    

     MyTransform.ColorBTO(0.2f, 2f);   

#     // 注意 UI 方法大多需要使用  RectTransform  或者  MaskableGraphic  

     // 否则极有可能会出错  


     // UGUI  做bezier 运动  持续时间  

     rectTransform.UIBezierMove(UIBezier, 2f);  

     // 移动 X 轴到目标值 持续时间  

     text.UIMoveToX(200, 2f);`  
        
     // 从开始值移动到目标值 持续时间  

     text.UIMove(new Vector2(-100, 100), new Vector2(100, -100), 3f);  
        
     // X 轴从开始值 移动到目标值  持续时间  

      text.UIMoveX(100, 300, 2f); 
 
     // 从当前坐标移动到目标值 持续时间  

     text.UIMoveTo(new Vector2(200, 200), 3f); 
 

     //  注意 只有UI （UGUI）才可以设置 alpha   

     //  参数  

     //  渐变到目标值  持续时间  

     //  从开始值 渐变到目标值  持续时间  

     text.UIAlpha(0, 2f);  

     text.UIAlpha(1, 0, 2f); 

     image.UIAlpha(0, 2f);  

     image.UIAlpha(1, 0, 2f); 

     // CCTween 的另一种使用方法 CCFunction   

#     // CCAction 可以设置回调参数  

     CCAction action=  CCFunction.Move("需要移动的物体", "开始坐标", "结束坐标", "持续时间");`  

     // 设置回调  

     action.SetComplete = () => { };  

