using System.Collections;
using System.Collections.Generic;

namespace Done {
public class FSM
{
    //字典存储状态
    private Dictionary<string, State> states = new Dictionary<string, State>();
    //集合存储当前状态
    private ArrayList currState = new ArrayList();

    public string CurrState { get; set; }


    //默认构造函数
    public FSM()
    {
        //根状态
        State root = new State();
        root.Name = "root";
        this.states["root"] = root;
        this.currState.Add(root);
    }

    public void addState(string stateName, State state)
    {
        this.addState(stateName, state, "");
    }
    //
    public void addState(string stateName, State state, string fatherName)
    {
        if (fatherName == "")
        {
            state.FatherName = "root";
        }
        else
        {
            state.FatherName = fatherName;
        }
        //给状态添加一个方法：在当前状态集合列表中查找对应名字的状态
        //在状态对象中，可以查找状态机中的包含的所有状态对象
        state.getCurrState = delegate(string name)
        {
            for (int i = 0; i < this.currState.Count; ++i)
            {
                State s = this.currState[i] as State;
                if (s.Name == name)
                {
                    return s;
                }

            }
            return null;
        };
        //添加状态，如果状态名字一样更改值
        this.states[stateName] = state;
    }


    //切换状态
    public void translation(string name)
    {
        CurrState = name;
        State target = this.states[name] as State;//target state

        if (target == null)//if no target return!
        {
            return;
        }


        //if current, reset 如果是当前状态，重置
        //如果切换的是最后一个状态，先把这个状态结束，然后空闲开启（重启该状态）
        if (target == this.currState[this.currState.Count - 1])
        {
            target.Over();
            target.Start();
            return;
        }


        //公共状态 字典和集合有相同的状态
        State publicState = null;


        //状态集合（从name查找到的状态开始以上的父状态集合）
        ArrayList stateList = new ArrayList();
        //临时状态
        State tempState = target;
        //父名字
        string fatherName = tempState.FatherName;


        //do loop  循环当前状态，如果当前状态的root，即没有父状态，结束循环，如果找到公共状态，退出循环，如果没有，加入列表中，列表存储这个状态以上的父节点
        while (tempState != null)
        {
            //reiterator current list 从当前状态列表中遍历 
            for (var i = this.currState.Count - 1; i >= 0; i--)
            {
                State state = this.currState[i] as State;
                //if has public 
                if (state == tempState)
                {
                    publicState = state;
                    break;
                }
            }

            //end
            if (publicState != null)
            {
                break;
            }

            //else push state_list
            stateList.Insert(0, tempState);
            //state_list.unshift(temp_state);


            //查看当前是否有父状态，如果有，临时状态转为当前状态的父状态
            if (fatherName != "")
            {
                tempState = this.states[fatherName] as State;
                fatherName = tempState.FatherName;
            }
            else
            {
                tempState = null;
            }

        }


        //if no public return
        if (publicState == null)
        {
            return;
        }

        ArrayList newCurrState = new ArrayList();
        bool under = true;
        //-- 析构状态
        for (int i2 = this.currState.Count - 1; i2 >= 0; --i2)
        {
            State state2 = this.currState[i2] as State;
            if (state2 == publicState)
            {
                under = false;
            }
            if (under)
            {
                state2.Over();
            }
            else
            {
                newCurrState.Insert(0, state2);
            }

        }


        //-- 构建状态
        for (int i3 = 0; i3 < stateList.Count; ++i3)
        {
            State state3 = stateList[i3] as State;
            state3.Start();
            newCurrState.Add(state3);
        }
        this.currState = newCurrState;
    }





    //根据名字查询FSM里的状态
    public State getCurrState(string name)
    {
        var self = this;
        for (var i = 0; i < self.currState.Count; ++i)
        {
            State state = self.currState[i] as State;
            if (state.Name == name)
            {
                return state;
            }
        }

        return null;

    }

    //初始化状态机，输入开始状态的名字
    public void init(string state_name)
    {
        var self = this;
        self.translation(state_name);
    }



    //关闭FSM
    public void shutdown()
    {
        for (int i = this.currState.Count - 1; i >= 0; --i)
        {
            State state = this.currState[i] as State;
            state.Over();
        }
        this.currState = null;
    }


    //状态机发送消息，从状态列表中检测，如果包含注册了该消息的状态机，返回需要切换的状态机名字，切换状态
    public void post(string msg)
    {
            FSMMsg evt = new FSMMsg();
        evt.msg = msg;
        this.postEvent(evt);
    }
    public void postEvent(FSMMsg evt)
    {
        for (int i = 0; i < this.currState.Count; ++i)
        {
            State state = this.currState[i] as State;
            string stateName = state.PostEvent(evt) as string;
            if (stateName != "")
            {
                this.translation(stateName);
                break;
            }
        }
    }
    }
}
