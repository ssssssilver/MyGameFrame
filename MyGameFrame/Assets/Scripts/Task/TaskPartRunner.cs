using UnityEngine;
using System.Collections;
namespace Done{
	class TaskPartRunner : TaskRunner{
		private bool isInit = false;

		protected void Awake(){	
			if(TaskManager.GetInstance() != null){
				TaskManager.GetInstance().PartRunner = this;
				isInit = true;
			}
			
		} 

		void Start(){
			if(!isInit){
				TaskManager.GetInstance().PartRunner = this;
				isInit = true;
			}
			
		}


		protected void OnDestroy(){
			if(isInit) 
			{
				TaskManager.GetInstance().PartRunner = null; 
				isInit = false;
			}
			
		}
	}
}

