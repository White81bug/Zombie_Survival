using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerController _player;
    private float _speed;
    private int _health;

    public float Speed;
    public int Health;
   
  

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerController>();
        _speed = Speed * (1 + Random.Range(-0.1f, 0.1f));
        _health = Health + Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {


            transform.up = (_player.transform.position - transform.position).normalized;
            _rb.velocity = transform.up * Speed;
        }
        else _rb.velocity = Vector2.zero;
    }

    public void TakeHit()
    {
        _health -= 1;
        if (_health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Player = collision.collider.GetComponent<PlayerController>();
        if(Player != null)
        {
            Player.TakeHit();
           
        }
        Destroy(gameObject);
    }
}
