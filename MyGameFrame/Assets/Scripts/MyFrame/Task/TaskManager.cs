using UnityEngine;
using System.Collections;

namespace Done{
    /// <summary>
    /// 任务管理类
    /// </summary>
	public class TaskManager : MonoBehaviour {

		//public TaskFactories _factories = null;
		public TaskRunner runner = null;
		
		private TaskRunner partRunner  = null;
		private static TaskManager instance = null; 
		//private static Hashtable reserve_ = new Hashtable();
		
		public TaskRunner PartRunner{
			set{this.partRunner = value as TaskRunner;}
		}
		
		void Awake(){

			TaskManager.instance = this;
			runner = this.gameObject.GetComponent<TaskRunner>();
            			
			if (runner == null) {
				runner = this.gameObject.AddComponent<TaskRunner>();	
			}
		}
		
		public static TaskManager GetInstance(){
			return TaskManager.instance;
		}
		
		public TaskRunner globalRunner{
			get{return runner;}
		}
		
		public TaskRunner Runner{
			get{
					if(partRunner != null){
						return partRunner;
					}
					return runner;
				}

		}
		
		public static void AddIsOver(Task task, TaskIsOver func){
			TaskIsOver oIsOver = task.IsOver;
			task.IsOver = delegate(){
				return (oIsOver() || func());
			};
		}
		public static void AddUpdate(Task task, TaskUpdate func){
			TaskUpdate update = task.update;
			task.update = delegate(float d){
				update(d);
				func(d);
			};
		}

		public static void PushBack(Task task, TaskShutdown func){
			TaskShutdown oShutdown = task.shutdown;
			task.shutdown = delegate (){
				oShutdown();
				func();
			};
		}
		
	
		public static void Run(Task task){
			if(TaskManager.GetInstance() != null){
				TaskManager.GetInstance().runner.addTask(task);
			}
		}	
        

		public static void PushFront(Task task, TaskInit func){
			TaskInit oInit = task.init;
			task.init = delegate(){
				func();
				oInit();
			};
		}
	}
}
