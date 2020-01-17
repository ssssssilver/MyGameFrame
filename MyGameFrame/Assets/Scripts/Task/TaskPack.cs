using UnityEngine;
using System.Collections;
namespace Done{
	public class TaskPack : Task {
	    private Task taskisInit = null;
	    private bool isOverisInit = false;
	    public delegate Task CreateTask();
	    public TaskPack(CreateTask createTask){
	     
	        this.init = delegate
	        {
	            isOverisInit = false;
	            taskisInit = createTask();
				if(taskisInit == null){
					isOverisInit = true;
				}else{
		            TaskManager.PushBack(taskisInit, delegate {
		                isOverisInit = true;
		            });
		            TaskManager.Run(taskisInit);
				}
	        };
	        this.IsOver = delegate {
	            return isOverisInit;
	        };
	       
	    }

	}
}
