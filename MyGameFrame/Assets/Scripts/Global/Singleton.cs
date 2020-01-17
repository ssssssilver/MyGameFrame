using UnityEngine;
using System.Collections;
namespace Done { 
    //单例
    public abstract class Singleton<T> : MonoBehaviour where T :MonoBehaviour{

        private static T instance = null;
	    
        public static T Instance
        {
            get { return instance; }
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
