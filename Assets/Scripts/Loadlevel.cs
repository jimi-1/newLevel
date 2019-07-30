using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadlevel : MonoBehaviour {

    private void Awake()
    {
        //加载当前的关卡
        Instantiate(Resources.Load(PlayerPrefs.GetString("nowLevel"))); 
    }
}
