using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite BrokenSprite;

    public GameObject explosionPrefab;

    public AudioClip dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die()
    {
        AudioSource.PlayClipAtPoint(dieAudio,transform.position);
        PlayManager.instance.isDefead = true;
        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
