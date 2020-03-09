using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Done { 

public enum UILayer
    {
        bottom,
        middle,
        top,
        system
    }

public class UIManager : SingletonClass<UIManager>
{
        //保存面板的字典
        public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

        Transform canvas;

        Transform bottom;
        Transform middle;
        Transform top;
        Transform system;

        public UIManager()
        {
            //实例化时创建UI
             GameObject ob= ResourcesManager.GetInstance().LoadRes<GameObject>("UI/Canvas");
            canvas = ob.transform;
            bottom = canvas.Find("Bottom");
            middle = canvas.Find("Middle");
            top = canvas.Find("Top");
            system = canvas.Find("System");

            ResourcesManager.GetInstance().LoadRes<GameObject>("UI/EventSystem");
        }

        /// <summary>
        /// 创建并显示面板
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="layer"></param>
        /// <param name="action"></param>
        public void ShowPanel<T>(string name,UILayer layer,Action<T> action=null) where T:BasePanel
        {
            if(panelDic.ContainsKey(name))
            {
                Debug.Log("已经显示UI");
            }
            else
            { 
            ResourcesManager.GetInstance().LoadResAsync<GameObject>("prefab/UI" + name, (o) =>
               {

                   Transform parent = null;
                   switch(layer)
                   {
                       case UILayer.bottom:
                           parent = bottom;
                           break;
                       case UILayer.middle:
                           parent = middle;
                           break;
                       case UILayer.top:
                           parent = top;
                           break;
                       case UILayer.system:
                           parent = system;
                           break;
                   }
                   //复位控件
                   o.transform.SetParent(parent);
                   o.transform.localPosition = Vector3.zero;
                   o.transform.localScale = Vector2.one;
                   (o.transform as RectTransform).offsetMax = Vector2.zero;
                   (o.transform as RectTransform).offsetMin = Vector2.zero;


                   //执行回调
                   T panel = o.GetComponent<T>();
                   if(action!=null)
                   action(panel);
                   //面板显示时执行的方法
                   panel.ShowUIPanel();
                   //保存控件
                   panelDic.Add(name, panel);
               });
            }
        }

        /// <summary>
        /// 删除已存在面板
        /// </summary>
        /// <param name="name"></param>
        public void HidePanel(string name)
        {
            if(panelDic.ContainsKey(name))
            {
                //面板隐藏时执行的方法
                panelDic[name].HideUIPanel();
                GameObject.Destroy(panelDic[name].gameObject);
                panelDic.Remove(name);
            }
        }

        /// <summary>
        /// 回收内存 需要引用mono的destroy
        /// </summary>
        void OnDestroy()
        {
            panelDic = null;
        }
}
}
