using UnityEngine;
using System.Collections;
namespace Done { 
public enum GameState
{
    None,
    Pause,//游戏暂停
    Play, //游戏中
    Stop, //游戏结束
}

public class GameBase{
    public static GameState gameState = GameState.None;
}

public delegate void DelegateFloat(float f);
public delegate void DelegateInt(int i);
public delegate void DelegateBool(bool b);
public delegate void DelegateEvent();
public delegate void DelegateGameObject(Object o);

}