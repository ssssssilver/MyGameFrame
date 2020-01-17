using UnityEngine;

namespace Done { 

public class InputController :MonoBehaviour
{

    

    private static InputController instance;
    public static InputController GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
    }

    //委托类型
    public DelegateEvent KeyEvent1;
    public DelegateEvent KeyEvent2;



    public  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
                GetKey1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
                GetKey2();
        }
        }

        public void GetKey1()
        {
            if (KeyEvent1 != null) KeyEvent1();
        }
        public void GetKey2()
        {
            if (KeyEvent2 != null) KeyEvent2();
        }


    }
}