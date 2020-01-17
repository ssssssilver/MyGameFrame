using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Done{
    /// <summary>
    /// 消息映射状态类
    /// </summary>
	public class StateWithEventMap:State {
        //事件消息列表
        private Dictionary<string, StateAction> actionMap = new Dictionary<string, StateAction>();

        public event Action OnStart;//开始委托
        public event Action OnOver;//结束委托

        public delegate void EventAction(FSMMsg evt);
        //传消息返回事件名称
        public delegate string StateAction(FSMMsg evt);

        //添加事件到消息列表，得到下一个状态的名字
		public void AddEvent(string evt, string nextState){
			actionMap.Add (evt, delegate {
								return nextState;
							});
		}

        //添加事件列表到消息列表
		public void AddAction(string evt, StateAction action){
			actionMap.Add(evt, action);
		}
        //添加事件到消息列表
		public void AddAction(string evt, EventAction action){
			actionMap.Add(evt, delegate(FSMMsg e) {
				action(e);
				return "";
			});
		}

	    public void removeEvent(string key)
	    {
	        actionMap.Remove(key);
	    }
	

        //提交事件消息，如果事件列表有当前消息，返回对应事件列表的状态名字
		public override string PostEvent(FSMMsg evt){
			string ret = "";
			if(actionMap.ContainsKey(evt.msg)){
				ret = actionMap[evt.msg](evt);
			}
			return ret;			

		}


        //开始
		public override void Start ()
		{
			if(OnStart != null)
				OnStart ();
		}
        //结束
		public override void Over()
		{
			if(OnOver != null)
				OnOver();
		}
         
       void OnDestroy()
       {
           OnOver = null;
           OnStart = null;
       }

	}

 
}