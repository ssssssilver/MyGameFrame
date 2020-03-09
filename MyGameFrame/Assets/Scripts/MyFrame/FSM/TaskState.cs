using UnityEngine;
using System.Collections;
namespace Done{
    /// <summary>
    /// 任务状态类
    /// </summary>
	public class TaskState{
		//public 
		//private TaskDelegate.Factory _creater;
		protected static int index_ =  0; 
		//public delegate string NextState();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creater">创建一个任务</param>
        /// <param name="fsm">状态机</param>
        /// <param name="nextState">状态的动作</param>
        /// <returns></returns>
		static public StateWithEventMap Create(TaskFactory creater, FSM fsm, StateWithEventMap.StateAction nextState){
			string over = "over" + index_.ToString();
			index_++;
            
			StateWithEventMap state = new StateWithEventMap ();

			Task task = null;
            //状态开始
			state.OnStart += delegate {
				task = creater();//创建一个任务
				TaskManager.PushBack (task, delegate {
					fsm.post(over);
				});
				TaskManager.Run (task);
			};

            //状态结束
			state.OnOver += delegate {
				task.IsOver = delegate{
					return true;
				};
			};
			state.AddAction (over, nextState);
			return state;
		}
		static public StateWithEventMap Create(TaskFactory creater, FSM fsm, string nextState){
			return Create (creater, fsm, delegate {
				return nextState;
			});
		}
	}
}