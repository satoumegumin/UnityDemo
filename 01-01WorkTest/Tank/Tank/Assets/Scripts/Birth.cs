using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birth : MonoBehaviour
{
    public GameObject playPrefab;

    public GameObject[] enermyPrefabList;

    public bool createPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornTank", 0.8f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BornTank()
    {
        if (createPlayer)
        {
            Instantiate(playPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enermyPrefabList[num], transform.position, Quaternion.identity);
        }
       
    }
}
