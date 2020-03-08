using UnityEngine;
using System.Collections;
namespace Done
{
    /// <summary>
    /// 创建需要单例的普通类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonClass<T> where T : new()
    {
        private static T instance;
        public static T GetInstance()
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
}
