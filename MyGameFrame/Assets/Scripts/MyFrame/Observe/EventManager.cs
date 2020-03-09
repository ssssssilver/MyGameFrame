using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace Done
{
    /// <summary>
    /// 事件委托中心
    /// </summary>
    public class EventManager : SingletonClass<EventManager>
    {
        //事件列表-无参   事件名-对应的委托列表
       // private Dictionary<string, Action> eventDir = new Dictionary<string, Action>();
        //事件列表-有参   事件名-对应的委托列表
        private Dictionary<string, IEventInfo> eventDir = new Dictionary<string, IEventInfo>();

        ///// <summary>
        ///// 添加事件
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="action"></param>
        //public void AddEventListener(string name, Action action)
        //{
        //    if (eventDir.ContainsKey(name))
        //    {
        //        eventDir[name] += action;
        //    }
        //    else
        //    {
        //        eventDir.Add(name, action);
        //    }
        //}

        /// <summary>
        /// 添加事件-有参
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void AddEventListener<T>(string name, Action<T> action)
        {
            if (eventDir.ContainsKey(name))
            {
                ((eventDir[name]) as EventInfo<T>).actions += action;
            }
            else
            {
                eventDir.Add(name, new EventInfo<T>(action));
            }
        }

        /// <summary>
        /// 添加事件-无参
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void AddEventListener(string name, Action action)
        {
            if (eventDir.ContainsKey(name))
            {
                ((eventDir[name]) as EventInfo).actions += action;
            }
            else
            {
                eventDir.Add(name, new EventInfo(action));
            }
        }

        ///// <summary>
        ///// 移除
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="action"></param>
        //public void RevmoeEventListener(string name, Action action)
        //{
        //    if (eventDir.ContainsKey(name))
        //    {
        //        eventDir[name] -= action;
        //    }
        //}


        /// <summary>
        /// 移除-有参
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void RevmoeEventListener<T>(string name, Action<T> action)
        {
            if (eventDir.ContainsKey(name))
            {
                ((eventDir[name]) as EventInfo<T>).actions -= action;
            }
        }

        /// <summary>
        /// 移除-无参
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void RevmoeEventListener(string name, Action action)
        {
            if (eventDir.ContainsKey(name))
            {
                ((eventDir[name]) as EventInfo).actions -= action;
            }
        }

        ///// <summary>
        ///// 触发事件
        ///// </summary>
        ///// <param name="name"></param>
        //public void EventTrigger(string name)
        //{
        //    if (eventDir.ContainsKey(name))
        //    {
        //        eventDir[name].Invoke();
        //    }
        //    else
        //    {

        //    }
        //}

        /// <summary>
        /// 触发事件-有参
        /// </summary>
        /// <param name="name"></param>
        public void EventTrigger<T>(string name, T obj)
        {
            if (eventDir.ContainsKey(name))
            {
                if(((eventDir[name]) as EventInfo<T>).actions!=null)
                ((eventDir[name]) as EventInfo<T>).actions.Invoke(obj);
            }
            else
            {

            }
        }

        /// <summary>
        /// 触发事件-无参
        /// </summary>
        /// <param name="name"></param>
        public void EventTrigger(string name)
        {
            if (eventDir.ContainsKey(name))
            {
                if (((eventDir[name]) as EventInfo).actions != null)
                    ((eventDir[name]) as EventInfo).actions.Invoke();
            }
            else
            {

            }
        }


        public void Clear()
        {
            eventDir.Clear();
            //eventDir2.Clear();
        }

    }
}