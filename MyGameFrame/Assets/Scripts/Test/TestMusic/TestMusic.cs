using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Done;
public class TestMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.GetInstance().PlayBackgroundMusic("BGM");
    }
    float volume = 1f;
    void OnGUI()
    {
        if (GUI.Button(new Rect(50, 50, 100, 30), "停止"))
        {
            MusicManager.GetInstance().StopBackgroundMusic();
        }
        if (GUI.Button(new Rect(50, 100, 100, 30), "暂停"))
        {
            MusicManager.GetInstance().PauseBackgroundMusic();
        }
        if (GUI.Button(new Rect(50, 150, 100, 30), "播放"))
        {
            MusicManager.GetInstance().ResumePlayBackgroundMusic();
        }
        volume = GUI.HorizontalSlider(new Rect(50, 200, 100, 30), volume, 0, 1);
        MusicManager.GetInstance().ChangeBackgroundMusicVolume(volume);
    }
}
