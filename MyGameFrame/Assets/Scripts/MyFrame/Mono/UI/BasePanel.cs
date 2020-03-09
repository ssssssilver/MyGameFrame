using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Done
{ 
    /// <summary>
    /// 面板基类
    /// </summary>
    public class BasePanel : MonoBehaviour
    {

        void Awake()
        {
            //添加常用UI组件
            FindChildrenControl<Button>();
            FindChildrenControl<Text>();
            FindChildrenControl<Slider>();
            FindChildrenControl<ScrollRect>();
            FindChildrenControl<Toggle>();

        }

        //ui控件字典 一个gameobject上可能有多个ui组件
        Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
        /// <summary>
        /// 通过泛型添加子对象组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void FindChildrenControl<T>() where T :UIBehaviour
        {
            T[] controls = this.GetComponentsInChildren<T>();
            string obj;
            for(int i=0;i<controls.Length;i++)
            {
                obj = controls[i].gameObject.name;
                if(controlDic.ContainsKey(obj))
                {
                    controlDic[obj].Add(controls[i]);
                }
                else
                { 
                controlDic.Add(obj,new List<UIBehaviour>() { controls[i] });
                }
            }
        }

        /// <summary>
        /// 获取对应名字的控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T GetControl<T>(string name)where T:UIBehaviour
        {
            if(controlDic.ContainsKey(name))
            {
                for(int i=0;i<controlDic[name].Count;i++)
                {
                    if(controlDic[name][i] is T)
                    {
                        return controlDic[name][i] as T;
                    }
                }
            }

            return null;
        }


        public virtual void HideUIPanel()
        {


        }
        public virtual void ShowUIPanel()
        {

        }

        /// <summary>
        /// 回收内存 需要引用mono的destroy
        /// </summary>
        void OnDestroy()
        {
            controlDic = null;
        }
    }

}
