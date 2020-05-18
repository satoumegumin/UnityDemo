using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public Text playerScore;
    public Text playerLife;


    public int lifeValue = 3;
    public int playeSorce = 0;

    public GameObject born;

    public bool isDeath;

    public bool isDefead;
    public static PlayManager instance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public GameObject isDefeatUI;

    // Update is called once per frame
    void Update()
    {
        if (isDefead)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToTheMainMenu", 3);
            return;
        }

        if (isDeath)
        {
            Recover();
        }
        playerScore.text = playeSorce.ToString();
        playerLife.text = lifeValue.ToString();

    }

    private void ReturnToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Recover()
    {
        if (lifeValue <= 0)
        {
            isDeath = true;
            Invoke("ReturnToTheMainMenu", 3);
            //游戏失败 返回主界面
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Birth>().createPlayer = true;
            isDeath = false;
        }

    }
}
