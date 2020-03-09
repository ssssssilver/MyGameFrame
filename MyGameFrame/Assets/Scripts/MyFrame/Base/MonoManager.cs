using UnityEngine;
using System.Collections;
using System;
using System.ComponentModel;

namespace Done
{/// <summary>
/// 管理monoController
/// 让非mono方法调用update coroutine
/// </summary>
    public class MonoManager : SingletonClass<MonoManager>
    {
        private MonoController monoController=null;

        public MonoManager()
        {
            GameObject ob = new GameObject("MonoController");
            monoController= ob.AddComponent<MonoController>();
        }
        #region update相关
        public void AddUpdateListener(Action action)
        {
            monoController.AddUpdateListener(action);
        }

        public void RemoveUpdateListener(Action action)
        {
            monoController.RemoveUpdateListener(action);
        }
        #endregion

        #region 协程相关
        public Coroutine StartCoroutine(string methodName)
        {
            return monoController.StartCoroutine(methodName);
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return monoController.StartCoroutine(routine);
        }
        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
        {
            return monoController.StartCoroutine(methodName, value);
        }

        public void StopAllCoroutines()
        {
            monoController.StopAllCoroutines();
        }

        public void StopCoroutine(IEnumerator routine)
        {
            monoController.StopCoroutine(routine);
        }
        public void StopCoroutine(Coroutine routine)
        {
            monoController.StopCoroutine(routine);
        }
        public void StopCoroutine(string methodName)
        {
            monoController.StopCoroutine(methodName);
        }
        #endregion
    }
}