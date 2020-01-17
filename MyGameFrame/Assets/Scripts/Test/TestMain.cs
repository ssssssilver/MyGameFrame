using UnityEngine;
using System.Collections;
using Done;
public class TestMain :Singleton<TestMain> {

    private FSM fsm = new FSM();

    public TestController Controller;

    void Start()
    {
        //设置游戏帧数
        Application.targetFrameRate = 30;
        Init();
        InitFSM();
    }

    void Init()
    {
        fsm.addState("FirstState", FirstState());
        fsm.addState("SecondState", SecondState());
        fsm.addState("ThirdState", ThirdState());
        fsm.addState("ForthState", ForthState());
    }

    void InitFSM()
    {
        fsm.init("FirstState");
    }
    State FirstState()
    {
        StateWithEventMap state = new StateWithEventMap();

        state.OnStart += delegate
        {
            Debug.Log("好的准备开工");
            Controller.TaskWait(2f, delegate
            {
                //等待0.5秒后开工
                fsm.translation("SecondState");
            });
        };
        state.AddAction("Forth", delegate
        {
            Debug.Log("不干了 直接睡觉！");
            fsm.translation("ForthState");
        });
        state.OnOver += delegate
        {
            Debug.Log("要开始干活了！");
        };
        return state;
    }


    State SecondState()
    {
        StateWithEventMap state = new StateWithEventMap();

        state.OnStart += delegate
        {
            Debug.Log("不说了，已经开工了");
            Controller.TaskWait(5f, delegate
            {
                Debug.Log("准备收工");
                fsm.translation("ThirdState");
            });
        };

        state.OnOver += delegate
        {
            Debug.Log("又干了一天");
        };
        return state;
    }

    State ThirdState()
    {
        StateWithEventMap state = new StateWithEventMap();

        state.OnStart += delegate
        {
            Debug.Log("收工了回家！");
            Controller.TaskWait(1f, delegate
            { 
                fsm.translation("ForthState");
            });
        };
        state.OnOver += delegate
        {
            Debug.Log("回到家了");
        };
        return state;
    }

    State ForthState()
    {
        StateWithEventMap state = new StateWithEventMap();

        state.OnStart += delegate
        {
            Debug.Log("累到睡着了！");
            Controller.TaskWait(10f, delegate
            {
                Debug.Log("10秒后醒来，又要开始新的一天");
                fsm.translation("FirstState");
            });
        };
        state.OnOver += delegate
        {
            Debug.Log("不能睡了");
        };
        state.AddAction("First", delegate
        {
            Debug.Log("良心过意不去,回去干活");
            fsm.translation("FirstState");
        });
        return state;
    }

}
