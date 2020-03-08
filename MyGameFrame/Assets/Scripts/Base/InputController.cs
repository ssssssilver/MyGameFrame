using UnityEngine;

namespace Done
{

    public class InputController : SingletonClass<InputController>
    {

        private bool isOn;
        public InputController()
        {
            MonoManager.GetInstance().AddUpdateListener(Update);
        }

        public void SwitchInput(bool isOn)
        {
            this.isOn = isOn;
        }



        void Update()
        {
            if (!isOn) return;
            KeyCodeCheck(KeyCode.A);
            KeyCodeCheck(KeyCode.D);
            KeyCodeCheck(KeyCode.W);
            KeyCodeCheck(KeyCode.S);

        }

        void KeyCodeCheck(KeyCode key)
        {
            if(Input.GetKeyDown(key))
            EventManager.GetInstance().EventTrigger("WASD按下", key);
            if (Input.GetKeyUp(key))
            EventManager.GetInstance().EventTrigger("WASD松开", key);
        }
    }
}