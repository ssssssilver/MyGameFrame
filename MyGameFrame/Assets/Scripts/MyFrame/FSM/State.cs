namespace Done { 
    /// <summary>
    /// 状态实体类
    /// </summary>
    public class State
    {
        //获取当前状态的委托
        public delegate State GetCurrState(string name);

        //当前状态名
        private string name = "";
        //父状态名
        protected string fatherName = "";
        //委托对象
        public GetCurrState getCurrState = null;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FatherName
        {
            get { return fatherName; }
            set { fatherName = value; }
        }
        public State()
        {

        }

        //开始状态
        public virtual void Start()
        {

        }

        //结束状态
        public virtual void Over()
        {

        }

        //发送消息
        public virtual string PostEvent(FSMMsg evt)
        {
            return "";
        }
    }
}