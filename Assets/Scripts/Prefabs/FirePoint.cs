using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public void Awake()
    {

    }
    // Start is called before the first frame update
    public void Shoot()
    {
        GameObject new_bullet = Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation
            );
        Rigidbody2D rb = new_bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

        Destroy(new_bullet, 2.0f);
    }
}

