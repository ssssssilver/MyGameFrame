using System;
using UnityEngine;
using Done;


public class GameController<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T m_instance = null;
    public static T Instance
    {
        get { return m_instance; }
    }

    [HideInInspector]
    public InputController InputCtr;//全局输入事件

    public DelegateEvent PauseEvent;
    public DelegateEvent ResumeEvent;
    public DelegateEvent StopEvent;
 



    public float TimeScale;


    //静态变量记录选择的关卡

    public void Awake()
    {
        m_instance = this as T;

        GameBase.gameState = GameState.Play;

        InputCtr = gameObject.GetComponent<InputController>();
        if (!InputCtr)
        {
            InputCtr = gameObject.AddComponent<InputController>();
        }

    }
    public void Start()
    {
        TimeScale = Time.timeScale;
    }


  
    /// <summary>
    /// 暂停逻辑    
    /// </summary>
     public void Pause()
    {
        GameBase.gameState = GameState.Pause;
        if (PauseEvent!=null)
        {
            PauseEvent();
        }
    } 
    /// <summary>
    /// 继续逻辑
    /// </summary>
     public void Resume()
    {
        if (GameBase.gameState == GameState.Pause)
        {
            GameBase.gameState = GameState.Play;
            if (ResumeEvent != null)
            {
                ResumeEvent();
            }
        }
        else
        {
            Debug.Log("游戏不在暂停状态");
        }
    } 
    /// <summary>
    /// 游戏停止
    /// </summary>
     public void Stop()
    {
        GameBase.gameState = GameState.Stop;
        if (StopEvent != null)
        {
            StopEvent();
        }
    }


    /// <summary>
    /// 等待多少秒后执行任务
    /// </summary>
    /// <param name="time"></param>
    /// <param name="action"></param>
    public void TaskWait(float time, Action action)
    {
        TaskWait taskWait = new TaskWait();
        taskWait.SetAllWaitTime(time);
        TaskManager.PushBack(taskWait, delegate
        {
            if (action != null)
            {
                action();
            }
        });
        TaskManager.Run(taskWait);
    }
   

}
