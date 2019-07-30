using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public GameObject option;
    public GameObject play;
    public GameObject exit;
    public void onStart(){
        SceneManager.LoadScene(1);
    }
    
    public void onExit(){
        Application.Quit();
    }

    public void onOption(){
        option.SetActive(true);
        play.SetActive(false);
        exit.SetActive(false);
    }

    public void Onclose(){
        option.SetActive(false);
        play.SetActive(true);
        exit.SetActive(true);
    }

    public void OnClear(){
        PlayerPrefs.DeleteAll();
        Debug.Log("数据清除成功！");
    }
}
