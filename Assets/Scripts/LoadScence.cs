using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake(){
        SceneManager.LoadScene(1);
    }
}
