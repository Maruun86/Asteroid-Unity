using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidChunk: MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject preFabEffectBreak;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        //Modelanzeigen
        int randomChild = Random.Range(0, transform.childCount - 1);
        Transform child = transform.GetChild(randomChild);
        child.gameObject.SetActive(true);
        
        rb.rotation = Random.Range(0,360);
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckInGameField(); 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameObject breakEffect = Instantiate(
                preFabEffectBreak,
                transform.position,
                transform.rotation
                );
            breakEffect.transform.localScale = Vector3.one /2;
            Destroy(breakEffect, 2.0f);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            scoreManager.AddScore(50);
        }

    }
    private void CheckInGameField()
    {
        if (transform.position.x < -18.0f)
        {
            transform.position = new Vector3(10.50f, transform.position.y, transform.position.z);

        }
        else if (transform.position.x > 11.0f)
        {
            transform.position = new Vector3(-17.50f, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < -10.50f)
        {
            transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
        }
        else if (transform.position.y > 10.50f)
        {
            transform.position = new Vector3(transform.position.x, -10.0f, transform.position.z);
        }
    }

}
