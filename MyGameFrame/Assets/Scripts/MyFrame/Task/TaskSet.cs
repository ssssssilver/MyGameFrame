using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Done{
    /// <summary>
    /// 任务打包一起执行
    /// </summary>
	public class TaskSet : Task {
		private List<Task> tasks = new List<Task>();
		private int overCount = 0;
		public TaskSet(){
			this.init = delegate() {
				overCount = 0;
				for(int i = 0; i < this.tasks.Count; ++i){
					Task task = this.tasks[i] as Task;
					TaskManager.Run(task);
				}
			}; 
			this.IsOver = delegate(){
				return (this.overCount == this.tasks.Count);
			};
			
		}
		
		public void push(Task task){
			this.tasks.Add (task);
			TaskManager.PushBack(task, delegate(){overCount++;});
		}
	}
}