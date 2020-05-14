using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,0.167f);//爆炸产生后 0.167s后销毁掉
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
