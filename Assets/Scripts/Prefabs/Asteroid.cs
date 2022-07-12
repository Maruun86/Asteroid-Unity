using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    float speed;
    public GameObject myPreFab;
    public GameObject preFabEffectBreak;
    Rigidbody2D rb;
    public ScoreManager scoreManager;
    SpawnerAsteroid spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("SpawnerAsteroid").GetComponent<SpawnerAsteroid>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent <ScoreManager>();
        rb = GetComponent<Rigidbody2D>();

        int randomChild = Random.Range(0, transform.childCount - 1);
        Transform child = transform.GetChild(randomChild);
        child.gameObject.SetActive(true);
        

        float rotation = Random.Range(0, 360);
        speed = Random.Range(50, 200);
        Vector3 force = new Vector3(0, -1, 0) ;
        rb.rotation = rotation;
        rb.AddForce(force * speed);
       

    }

    // Update is called once per frame
    void Update()
    {
        CheckInGameField(); 

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameObject breakEffect = Instantiate(
                 preFabEffectBreak,
                 transform.position,
                 transform.rotation
                 );
            Destroy(breakEffect, 2.0f);
 
            Destroy(collision.gameObject);
            Destroy(gameObject);

            scoreManager.AddScore(200);
            if (this.CompareTag("Asteroid"))
            {
                SplitAsteroid();
            }

            spawner.activeAsteroids -= 1;
        }
        

    }
    private void SplitAsteroid()
    {
        for (int i = 0; i < 2; i++)
        {
            float x = Random.Range((int)transform.position.x - 5, (int)transform.position.x + 5);
            Vector3 pos = new Vector3(x, transform.position.y);

            GameObject new_asteroid = Instantiate(
                myPreFab,
                transform.position,
                transform.rotation
            );
            Rigidbody2D rb2 =new_asteroid.GetComponent<Rigidbody2D>();
            rb2.velocity = rb.velocity.normalized * 3;
        }
    }
    private void CheckInGameField()
    {
        //Von einem Spielfeld rand zum gegenüber
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
