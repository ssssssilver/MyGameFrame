﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Done
{
    public class MonoController : MonoBehaviour
    {
        //给非mono类增加update方法

         void Start()
        {
            DontDestroyOnLoad(this);
        }

        private event Action UpdateEvent;


        // Update is called once per frame
        void Update()
        {
            if (UpdateEvent != null)
                UpdateEvent();

        }
        /// <summary>
        /// 增加update事件
        /// </summary>
        /// <param name="action"></param>
        public void AddUpdateListener(Action action)
        {
            UpdateEvent += action;
        }

        /// <summary>
        /// 剔除update事件
        /// </summary>
        /// <param name="action"></param>
        public void RemoveUpdateListener(Action action)
        {
            UpdateEvent -= action;
        }

        public void Clear()
        {
            UpdateEvent = null;
        }



    }

}