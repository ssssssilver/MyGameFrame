using UnityEngine;
using System.Collections;
namespace Done{
	public class TaskWait : Task {

		private float allWaitTime = 0f;
		private float time = 0f;

        //默认构造方法
		public TaskWait(){
			this.init = initImpl;
			this.update = updateImpl;
			this.IsOver = isOverImpl;
		}
        /// <summary>
        /// 设置时长
        /// </summary>
        /// <param name="allTime"></param>
		public void SetAllWaitTime(float allWaitTime){
			this.allWaitTime = allWaitTime;
		}
        /// <summary>
        /// 初始化事件
        /// </summary>
		public void initImpl(){
			time = 0f;
		}
        /// <summary>
        /// 更新时间
        /// </summary>
        /// <param name="d">增加的时间</param>
		public void updateImpl(float d){
			time += d;
		}
        /// <summary>
        /// 是否结束
        /// </summary>
        /// <returns></returns>
		public bool isOverImpl(){
			if (time >= allWaitTime) {
				return true;		
			}
			return false;
		}

	}
}
