using System;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class W:MonoBehaviour
{
  
    void Start() {
            
        

    }

    private void Update() {

    }
    

  
    public String Pass()
    {       
            string  path =  /*Application.streamingAssetsPath*/Application.dataPath + "\\Plugins\\" +"try\\try.exe";       

            string fileName = path;
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = fileName;
            p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.Arguments = "IHSUSAA_1508211711";//参数以空格分隔，如果某个参数为空，可以传入””
            p.Start();
            p.WaitForExit();
            //此处可以返回一个字符串，此例是返回压缩成功之后的一个文件路径
            string output = p.StandardOutput.ReadToEnd();
            return output;

    }

}