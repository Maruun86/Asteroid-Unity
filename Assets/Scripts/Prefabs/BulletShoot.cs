using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject preFabEffectHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Effect"))
        {
            GameObject hitEffect = Instantiate(
                     preFabEffectHit,
                     transform.position,
                     transform.rotation
                     );
            Destroy(hitEffect,2.0f);
        }

    }
}
