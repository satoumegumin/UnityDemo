using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    private int choose = 1;

    public Transform pos1;
    public Transform pos2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            choose = 1;
            transform.position = pos1.transform.position;

        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            choose = 2;
            transform.position = pos2.transform.position;
        }
        if (choose==1&&Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);//"加载游戏场景"
        }
    }
}
