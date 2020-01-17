using UnityEngine;
using Done;
public class TaskTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TaskList taskList = new TaskList ();
        //创建任务 当回调为true时进行下一个任务
		Task task1 = new Task ();
		task1.init = delegate() {
			Debug.Log("this is first task!!!");
		};
		task1.IsOver = delegate() {
            //只有返回true才会执行下一任务
			return true;
		};
		taskList.push (task1);

        //挂起两秒
		TaskWait wait = new TaskWait ();
		wait.SetAllWaitTime(2f);
		taskList.push (wait);

        //创建第二个任务
		Task task2 = new Task ();
		task2.init = delegate() {
			Debug.Log("this is second task!!!");
		};
		taskList.push (task2);
        
        
		TaskSet mt = new TaskSet();
        //创建第三个任务
        Task task3 = new Task();
		task3.init = delegate() {
			Debug.Log("this is third task!!!");
		};
            task3.IsOver = delegate () 
            {
                Debug.Log("third task is finish");
                return true;
            };
		mt.push (task3);

        //创建第四个任务
        Task task4 = new Task ();
		task4.init = delegate() {
			Debug.Log("this is forth task!!!");
		};
        task4.IsOver= delegate()
            {
                Debug.Log("forth task is finish");
                return true;
            };
		mt.push (task4);
		taskList.push(mt);

            TaskManager.Run(taskList);
        }
    }
