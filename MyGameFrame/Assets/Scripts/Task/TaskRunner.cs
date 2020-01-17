using UnityEngine;
using System.Collections;
namespace Done{
	public class TaskRunner : MonoBehaviour {

		private Filter filter = new Filter();
		private ArrayList tasks = new ArrayList();

		public static TaskRunner Create(GameObject obj){
			TaskRunner runner = obj.GetComponent<TaskRunner>();
			if(runner == null){
				runner = obj.AddComponent<TaskRunner>();
			}
			return runner;
		}


		public void update(float d){
			var tasks = new ArrayList();
			for(var i=0; i< this.tasks.Count; ++i){
				Task task = this.tasks[i] as Task;
				task.update(d);
				if(!task.IsOver()){
					tasks.Add(task);
				}else{
                    if (!task.isBreak)
				    {
                        task.shutdown();
				    }
				}
			}
			this.tasks = tasks;
		}
		/*
		protected virtual void  OnDestroy(){
			try{
				for(int i=0; i< this.tasks.Count; ++i){
					Task task = this.tasks[i] as Task;
					task.shutdown();
				}
				tasks = new ArrayList();
			}catch(System.Exception e){ 
				Debug.LogWarning(e.Message);			
			}
		}*/
		

		public void addTask(Task task){
			task.init();
			this.tasks.Add(task);
		}
		
		protected virtual void Update() { 
			float d = filter.interval(Time.deltaTime);
			this.update(d);
		}
	}
}
