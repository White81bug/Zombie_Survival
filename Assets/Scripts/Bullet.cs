
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        _rb.velocity = (Vector2)(transform.up * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeHit();
        }
        Destroy(gameObject);
    }
}
