using UnityEngine;
using System.Collections;
namespace Done{

	public class Task
	{
	    public bool isBreak ;
		public Task(){}
		public TaskInit init = delegate (){};
		public TaskShutdown shutdown = delegate(){};
		public TaskUpdate update = delegate(float d){};
		public TaskIsOver IsOver = delegate(){return true;};
		
	};
}