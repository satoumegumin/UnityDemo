using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enermy : MonoBehaviour
{
    public float moveSpeed = 3;

    private SpriteRenderer sr;//拿到精灵渲染器

    public GameObject bullet;

    private Vector3 bullectAngles;

    private float timaVal = 0.4f;

    public GameObject explosionObject;



    public Sprite[] tankSprite;//上右下左的顺序
    // Start is called before the first frame update
    private void Awake()
    {

        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    // Update is called once per frame  放在这里的话帧不固定 造成坦克鬼畜 有关移动的方法放在固定物理帧中执行
    void Update()
    {
      
        //攻击的cd
        if (timaVal >= 3f)
        {
            Attack();

        }
        else
        {
            timaVal += Time.deltaTime;
        }

    }

    private void FixedUpdate()//固定物理帧  每一帧锁占用的时间是固定的  希望每一秒作用的大小都有一个固定的值
    {
        Move();// 坦克的移动方法


    }

    private double attackTime;

    //坦克的攻击方法
    private void Attack()
    {
        timaVal = 0;
        Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bullectAngles));
        //子弹产生的角度应该是当前坦克的角度加上子弹应该旋转的角度

    }

    //private float enermyCount = 3;

    private float rotateTimeDirection=4f;
    private float v;
    private float h;
    private void Move()
    {
        if (rotateTimeDirection>=1.5f)
        {
            int num = Random.Range(0, 8);
            if (num>5)
            {
                v = -1;
                h = 0;
            }
            else if (num==0)
            {
                v = 1;
                h = 0;
            }
            else if(num<=2)
            {
                h = -1;
                v = 0;
            }
            else
            {
                h = 1;
                v = 0;
            }
            rotateTimeDirection = 0;
        }
        else
        {
            rotateTimeDirection += Time.fixedDeltaTime;
        }
        
        //float h = Input.GetAxisRaw("Horizontal");//水平输入

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);//每秒来移动  世界坐标轴

        if (h < 0)//左边
        {
            bullectAngles = new Vector3(0, 0, 90);
            sr.sprite = tankSprite[3];

        }
        else if (h > 0)
        {
            bullectAngles = new Vector3(0, 0, -90);
            sr.sprite = tankSprite[1];
        }

        if (h == 0)//移动优先级的添加
        {
            //float v = Input.GetAxisRaw("Vertical");//垂直输入
            transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

            if (v < 0)//下
            {
                bullectAngles = new Vector3(0, 0, -180);
                sr.sprite = tankSprite[2];
            }
            else if (v > 0)//上
            {
                bullectAngles = new Vector3(0, 0, 0);
                sr.sprite = tankSprite[0];
            }

        }
    }

    private void RotateDirection()
    {
        if (v==1)
        {
            v = 0;
            h = 1;
        }
        if (v==-1)
        {
            v = 0;
            h = -1;
        }
        if (h==1)
        {
            h = 0;
            v = -1;
        }
        if (h==-1)
        {
            v = 1;
            h = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enermy")
        {
            RotateDirection();
            //rotateTimeDirection = 1.5f;
        }
        if (collision.gameObject.tag == "barrier" || collision.gameObject.tag == "umi")
        {
            RotateDirection();//
            //rotateTimeDirection = 1.5f;
        }
        if (collision.gameObject.tag == "Tank"|| collision.gameObject.tag == "heart")
        {
            Attack();
        }
       
        if (collision.gameObject.tag == "wall")
        {
            Attack();
        }
    }


    //坦克的死亡方法
    private void Die()
    {
        //产生爆炸特效 死亡 
        //enermyCount--;
        PlayManager.instance.playeSorce++;
        Instantiate(explosionObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
