using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CdBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isPlayerBullet;

    public float moveSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*moveSpeed*Time.deltaTime,Space.World);//验证自身的y轴移动
    }

    //触发器 碰到的时候
    private void OnTriggerEnter2D(Collider2D collision)//两个游戏物体接触 出来 互相进入的时候触发的方法 enter stay 等方法
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullet)
                {
                    //玩家爆炸 重生
                    collision.SendMessage("Die");

                    Destroy(gameObject);
                }
                
                break;
            case "heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "barrier":
                Destroy(gameObject);
                break;
            case "umi":
                break;
            case "enermy":
                if (isPlayerBullet)
                {
                    //玩家爆炸 重生
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
