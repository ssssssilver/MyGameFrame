using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Done{
public class ResourcesManager :SingletonClass<ResourcesManager>
{
        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T LoadRes<T>(string name)where T : UnityEngine.Object
        {
            T res = Resources.Load<T>(name);
                if (res is GameObject)
                {
                    //返回实例化的ob
                    return GameObject.Instantiate(res);
                }
                //返回其他对象
            return res;
           
        }
        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="loadComplete"></param>
        public void LoadResAsync<T>(string name,Action<T> loadComplete)where T: UnityEngine.Object
        {
            MonoManager.GetInstance().StartCoroutine(WaitForLoadAsync(name,loadComplete));
        }

        IEnumerator WaitForLoadAsync<T>(string name,Action<T> action)where T: UnityEngine.Object
        {
            ResourceRequest r = Resources.LoadAsync<T>(name);
            yield return r;
            Debug.Log(r.asset);
            if (r.asset is GameObject)
            {
                action(GameObject.Instantiate(r.asset)as T);
            }
            else
            {
                action(r.asset as T);
            }
        }
}
}