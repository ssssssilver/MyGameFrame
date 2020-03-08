using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Done
{
    public class PoolManager : SingletonManager<PoolManager>
    {
        //缓存池
        public Dictionary<string, PoolObject> poolDir = new Dictionary<string, PoolObject>();

        private Transform pool;
        void Start()
        {
            pool = new GameObject("Pool").transform;
        }

        /// <summary>
        /// 获取物体 同步加载
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetGameObject(string name)
        {
            GameObject ob = null;
            if (poolDir.ContainsKey(name))
            {
                //存在但没库存
                if (poolDir[name].poolList.Count == 0)
                {
                    ob = ResourcesManager.GetInstance().LoadRes<GameObject>(name);
                    ob.name = name;
                }
                else
                {
                    ob = poolDir[name].GetObj();
                }
            }
            else
            {

                ob = ResourcesManager.GetInstance().LoadRes<GameObject>(name);
                ob.name = name;
            }
            return ob;
        }

        /// <summary>
        /// 获取物体 异步加载
        /// </summary>
        /// <param name="name"></param>
        /// <param name="loadComplete"></param>
        /// <returns></returns>
        public GameObject GetGameObject(string name,Action<GameObject> loadComplete)
        {
            GameObject ob = null;
            if (poolDir.ContainsKey(name)&&poolDir[name].poolList.Count!=0)
            {

                    ob = poolDir[name].GetObj();
                    loadComplete(ob);
            }
            else
            {

                ResourcesManager.GetInstance().LoadResAsync<GameObject>(name,(e)=> 
                {
                    e.name = name;
                    loadComplete(e);
                });

            }
            return ob;
        }



        /// <summary>
        /// 放回
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ob"></param>
        public void SetGameObject(string name, GameObject ob)
        {
            ob.SetActive(false);
            if (poolDir.ContainsKey(name))
            {
                poolDir[name].SetObj(ob);
            }
            else
            {
                //加入池
                poolDir.Add(name, new PoolObject(ob, pool));
            }
        }

        public void Clear()
        {
            poolDir.Clear();

        }

        protected override void OnDestroy()
        {
            Clear();
        }

    }
}