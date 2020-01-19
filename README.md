# MyGameFrame
 游戏简单框架  
 
 V_1.0    
 1.新增FSM框架  
 有限状态机   
 a.可以添加多个state，通过transit方法可以切换到对应的状态中;  
 b.每个state有对应的onstart,onover回调 可以根据需求添加对应回调  
 c.对应某个状态可以添加多个action，在当前状态可以使用post方法触发对应action  
 d.可配合Task管理器 取代unity中的协程  
   
   
 2.新增Task管理器  
 a.可以创建任务流水线tasklist，按task添加顺序执行 并可以在Task之前添加taskwait 让task挂起指定时间后再执行  
 b.每个task有对应的init,over事件 可以根据需求添加对应回调  
 c.可以给tasklist添加taskset，taskset可以添加多个Task，并且添加进去的子task会并行触发  
 
