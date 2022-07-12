using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    SpriteRenderer shieldSprite;
    CircleCollider2D shieldCollider;
    Color shieldColour;
    public bool shieldIsActive = false;
    public bool needShield = false;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (needShield)
        {
            DrawShield();

        }else
        {
            shieldSprite.enabled = false;
            shieldCollider.enabled = false;
            shieldIsActive = false;
        }
        


    }
    private void Awake()
    {
        shieldCollider = GetComponent<CircleCollider2D>();      
        shieldSprite = GetComponent<SpriteRenderer>();
        shieldColour = shieldSprite.color;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.transform.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 1000);
    }
    public void DrawShield()
    {
        
        shieldSprite.enabled = true;
        shieldCollider.enabled = true;
        shieldIsActive = true;
        
       
    }
}
