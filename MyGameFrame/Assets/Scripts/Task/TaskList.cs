using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Done{
    /// <summary>
    /// 任务列表类
    /// </summary>
	public class TaskList:Task{
		private Task begin = null;
		private Task end = null;
		private List<Task> other = new List<Task>(); 
		private bool isOver = false;
		private bool isCompleted = false;

		public TaskList(){
			this.init = this.initImpl;
			this.IsOver = this.isOverImpl;
		}

		public void push(Task task){
			if(this.isCompleted){
				Debug.Log("list task is completed!");
			}
			if(this.begin == null && this.end == null)
			{
				this.begin = task;
				this.end = task;
			}else{
				Task end = this.end;
				TaskShutdown oShutdown = end.shutdown;
				end.shutdown = delegate(){
					oShutdown();
					TaskManager.Run(task);
				};
				other.Add(this.end);
				this.end = task;
			}
		}

		public void initImpl(){
			if(this.isCompleted == false && this.end!=null){
				TaskManager.PushBack(this.end, delegate(){this.isOver = true;});
				this.isCompleted = true;
			}
			if(this.begin != null){ 
				this.isOver = false;
				TaskManager.Run(begin); 
			}else{
				this.isOver = true;
			} 
		}
		
		
		public bool isOverImpl(){
			return this.isOver;
		}
	};
}
