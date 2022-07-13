using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerControl playerControl;
    public GameOver gameOverMenu;
    public FirePoint firePoint;
    public ParticleSystem thrustForward;
    public ParticleSystem thrustRotateLeft;
    public ParticleSystem thrustRotateRight;
    public GameObject collissionEffect;

    public Shield shield;
    public float shieldEnergy = 100f;
    public float maxhitpoints = 1000f;
    public float hitpoints = 1000f;
    public float maxVelocity = 15.0f;
    public float rotationSpeed = 15.0f;

    #region MonoBehaviour API
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControl = new PlayerControl();
        playerControl.Player.Enable();
        playerControl.Player.Shoot.performed += Shoot;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckInGameField();
        ClampVelocity();

        //Thrust
        if(playerControl.Player.Thrust.ReadValue<float>() > 0)
        {
            thrustForward.Play();
            float amount = playerControl.Player.Thrust.ReadValue<float>();
            Vector2 force = transform.up * amount;
            rb.AddForce(force);
        }

        //Rotation
        float rota = playerControl.Player.Rotation.ReadValue<float>();
        transform.Rotate(0, 0, rota);
        rb.angularVelocity = rota;

        if (playerControl.Player.Rotation.ReadValue<float>() > 0)
        {
            thrustRotateLeft.Play();
        }else if(playerControl.Player.Rotation.ReadValue<float>() < 0)
        {
            thrustRotateRight.Play();
        }

        if (playerControl.Player.Shield.IsPressed() && shieldEnergy >= 10)
        {
            shield.needShield = true;
            shieldEnergy -= 5f;
        }
        else 
        {
            shield.needShield = false;
            shieldEnergy += 0.5f;
        }
       
    }
    #endregion

    #region Mixed 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && !shield.shieldIsActive)
        {
            float vel = rb.velocity.x + rb.velocity.y;
            hitpoints -= 100 * Math.Abs(vel);
            GameObject effectCollision = Instantiate(
               collissionEffect,
               transform.position - (transform.position - collision.transform.position),
               transform.rotation
               );
            Destroy(effectCollision, 2.0f);
            if (hitpoints <= 0)
            {
             
                Destroy(gameObject);
                playerControl.Disable();
                effectCollision.transform.localScale = Vector3.one * 3;
                gameOverMenu.GameOverMenu();
            }
        }

    }


    public void Shoot(InputAction.CallbackContext context)
    {
        firePoint.Shoot();
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x,-maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y,-maxVelocity, maxVelocity);
        rb.velocity = new Vector2(x, y);
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
    #endregion

}

