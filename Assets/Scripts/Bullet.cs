using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    public int bulletDamage = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }
}
