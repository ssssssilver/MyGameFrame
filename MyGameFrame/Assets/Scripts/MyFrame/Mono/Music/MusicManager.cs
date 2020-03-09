using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Done {
    public class MusicManager :SingletonClass<MusicManager>
    {

        public MusicManager()
        {
            //非mono调用update方法
            MonoManager.GetInstance().AddUpdateListener(Update);
        }

         AudioSource backgroundMusic = null;

        List<AudioSource> effectMusicList = new List<AudioSource>();
         GameObject effectMusic = null;

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="name"></param>
        public void PlayBackgroundMusic(string name,float volume,Action<AudioClip> action=null)
        {
            if(backgroundMusic==null)
            {
                GameObject ob = new GameObject("BackgroundMusic");
                backgroundMusic= ob.AddComponent<AudioSource>();
            }
            ResourcesManager.GetInstance().LoadResAsync<AudioClip>("Music/bgm/" + name,
            (o) => {
                backgroundMusic.clip = o;
                backgroundMusic.volume = volume;
                backgroundMusic.loop = true;
                backgroundMusic.Play();
                if (action != null)
                    action(o);
            });
        }

        public void PlayBackgroundMusic(string name)
        {
            PlayBackgroundMusic(name, 1);
        }


        /// <summary>
        /// 停止
        /// </summary>
        public void StopBackgroundMusic()
        {
            if(backgroundMusic!=null&&backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
            }
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void PauseBackgroundMusic()
        {
            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Pause();
            }
        }

        public void ChangeBackgroundMusicVolume(float volume)
        {
            if (backgroundMusic != null)
            {
                backgroundMusic.volume = volume;
            }
        }

        public void ResumePlayBackgroundMusic()
        {
            if (backgroundMusic != null && !backgroundMusic.isPlaying)
            {
                backgroundMusic.Play();
            }
        }

        public void PlayEffectSound(string name,Action<AudioClip> action=null)
        {
            if (effectMusic == null)
            {
                effectMusic = new GameObject("EffectMusic");
            }
            ResourcesManager.GetInstance().LoadResAsync<AudioClip>("Music/effect/" + name,
            (o) => {
                AudioSource effect = effectMusic.AddComponent<AudioSource>();
                effect.clip = o;
                effect.loop = false;
                effect.Play();
                effectMusicList.Add(effect);
                if (action != null)
                    action(o);
            });
        }

        public void StopAllEffectSound()
        {
            for(int i=0;i<effectMusicList.Count;i++)
            {
                if (effectMusicList[i].isPlaying)
                    effectMusicList[i].Stop();
            }
        }

        //Todo:每一帧都运行 待优化 缓存池
        void Update()
        {
            for(int i=0;i<effectMusicList.Count;i++)
            {
                if (!effectMusicList[i].isPlaying)
                { 
                    GameObject.Destroy(effectMusicList[i]);
                    effectMusicList.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// 回收内存 需要引用mono的destroy
        /// </summary>
        void OnDestroy()
        {
            effectMusicList = null;
        }
    }

}