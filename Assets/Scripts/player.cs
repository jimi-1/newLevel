using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using System.Runtime.InteropServices;

public class player : MonoBehaviour
{   
    
    public float speed = 0.175f;//游戏人物移动速度
    private Vector2 dest = Vector2.zero; //人物下次移动的目的地
    //public int pathLenth;
	public gameManager theLevel;
    public bool isJump ;
	public Vector2 RespawnPosition;
    public GameObject text;

    private int direction; //面向方向1 2 3 4 分别为上下左右
    //public Vector2 previousPace;

    public int score = 0;
    //public int scoreDouble = 1;
    private void Start()
    {
        isJump = false;
    
        dest = transform.position; //定义游戏人物开始不动
        direction = 1;//默认向下跳跃
    }

    private void FixedUpdate()
    {
        //Debug.Log(Valid(Vector2.up));
        //text.GetComponent<Text>().text = "分数：" + score.ToString();
        Vector2 temp = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(temp);
        if ((Vector2)transform.position == dest)
        {
            isJump =false;
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                direction = 1;
            }
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Valid(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;
                direction = 2;
            }
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Valid(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;
                direction = 3;
            }
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                direction = 4;
            }
            //跳跃
            if (Input.GetKey(KeyCode.Space))
            {
             
                isJump = true;
                switch (direction){
                    case 1:
                            if(Valid(Vector2.up*2)){
                                dest = (Vector2)transform.position + Vector2.up*2;
                            }
                            break;
                    case 2:
                            if(Valid(Vector2.down*2)){
                                dest = (Vector2)transform.position + Vector2.down*2;
                            }
                            break;
                    case 3:
                            if(Valid(Vector2.left*2)){
                                dest = (Vector2)transform.position + Vector2.left*2;
                            }
                            break;
                    case 4:
                            if(Valid(Vector2.right*2)){
                                dest = (Vector2)transform.position + Vector2.right*2;
                            }
                            break;
                  //若是任何一个方向，都执行
                    default: isJump =false;break;
                }
            

            }
            //抓
             if (Input.GetKey(KeyCode.F))
            {  
                //Debug.Log(findDir(direction));              
                CatchFood(findDir(direction));
            }
           // Debug.Log(findDir(direction));
           // if(ValidWater(findDir(direction))){
                    
            //        dest = RespawnPosition;
           //         theLevel.Respawn();
           // }
            //获取移动方向
            Vector2 dir = dest - (Vector2)transform.position;

			if(dir.x == 0 && dir.y == 0){      
                      //把获取到的方向传给状态机
                RespawnPosition = transform.position;
                 GetComponent<Animator>().SetFloat("DirX",dir.x);
                GetComponent<Animator>().SetFloat("DirY", dir.y);

			}else{
			    GetComponent<Animator>().SetFloat("DirX",dir.x);
                GetComponent<Animator>().SetFloat("DirY", dir.y);
			}

            //把获取到的方向传给状态机
            //GetComponent<Animator>().SetFloat("DirX",dir.x);
            //GetComponent<Animator>().SetFloat("DirY", dir.y);
        }
    }
    //寻找物体面对的方向单位坐标
    private Vector2 findDir(int direction){
        Vector2 dir1; 
        switch (direction){
                    case 1:                         
                            dir1 =  Vector2.up;                           
                            break;
                    case 2:                         
                            dir1 = Vector2.down;
                            break;
                    case 3:
                            dir1 =  Vector2.left;                           
                            break;
                    case 4:
                            dir1 =  Vector2.right;
                            break;
                    default: dir1 = Vector2.down;
                             break;
        }
        return dir1;
    }
    //检测目的地能否到达
    private bool Valid(Vector2 dir)
    {
        //可在Inspector的Layer中设置忽略
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        //return (hit.collider == GetComponent<Collider2D>());
        return (hit.collider.name != "Tree");
    }
    private void CatchFood(Vector2 dir)
    {

        //可在Inspector的Layer中设置忽略
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (hit.collider.tag == "Food"){
            Destroy(hit.collider.gameObject);
          
        }
    }
    
    void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Tree"){
			//Destroy(gameObject);
		}
        else if(col.gameObject.tag == "Water"){
			//Destroy(col.transform.gameObject);
         
           if(isJump == false){

                dest = RespawnPosition;
                theLevel.Respawn();
            }
            /* 
            else if((Vector2)transform.position == dest)
            {
               if(ValidWater(dest - (Vector2)transform.position)){
                dest = RespawnPosition;
                theLevel.Respawn();
               } 
            }
            */
		}
        else if(col.gameObject.tag == "Food"){

            //Debug.Log("x: " + Mathf.Abs(col.transform.position.x - previousPace.x));
            //Debug.Log("y: " + Mathf.Abs(col.transform.position.y - previousPace.y));
            //连续吃水果分数翻倍
            // if(Mathf.Abs(col.transform.position.x - previousPace.x) < 1.1 && Mathf.Abs(col.transform.position.y - previousPace.y) < 1.1){
            //     scoreDouble +=1;        
            // }else{
            //     scoreDouble = 1;
            // }
            // previousPace = col.transform.position;
            // score += (int)Mathf.Pow(2,scoreDouble);
            score +=2;
            //第二个参数，延迟多久消失
            Destroy(col.transform.gameObject);
        }
        else if(col.gameObject.tag == "Exit"){
            //结束时把星星数量传给游戏管理器
            theLevel.starsNum = score/6;
            gameManager._instance.win.SetActive(true);
        }
    }

}
