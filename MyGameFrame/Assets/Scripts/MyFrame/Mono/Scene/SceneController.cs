using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Done {
    public class SceneController :SingletonClass<SceneController>
    {

        /// <summary>
        /// 同步加载场景
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loadCompleteAction"></param>
        public void LoadScene(string name,Action loadCompleteAction)
        {
            SceneManager.LoadScene(name);
            loadCompleteAction();
        }

        public void LoadSceneAsync(string name, Action loadCompleteAction)
        {
            //非mono方法调用协程
            MonoManager.GetInstance().StartCoroutine(LoadSceneAsyncCoroutine(name, loadCompleteAction));
        }

        IEnumerator LoadSceneAsyncCoroutine(string name,Action loadCompleteAction)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(name);
            yield return async;
            //观察中心响应
            EventManager.GetInstance().AddEventListener<AsyncOperation>("loading", ShowLoadPercent);
            while (!async.isDone)
            {
                //进度条处理
                EventManager.GetInstance().EventTrigger("loading", async.progress);
                yield return 0;

            }
            loadCompleteAction();
        }
        /// <summary>
        /// 显示当前进度
        /// </summary>
        /// <param name="percent"></param>
        void ShowLoadPercent(AsyncOperation percent)
        {
            Debug.Log((percent as AsyncOperation).progress);
        }
    }
}