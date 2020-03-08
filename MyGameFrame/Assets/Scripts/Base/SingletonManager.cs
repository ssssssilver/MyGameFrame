using UnityEngine;
using System.Collections;
namespace Done
{
    /// <summary>
    /// mono类的单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T GetInstance()
        {
            if (instance == null)
                instance = (T)FindObjectOfType(typeof(T));
            return instance;
        }

        protected virtual void Awake()
        {
            instance = this as T;
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }
}