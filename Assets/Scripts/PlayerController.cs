using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool IsReloading = false;
    public int CurrentAmmo { get; private set; }



    public GameObject Bullet;
    public Transform ShootPoint;
    public int Health;
    public Game Game;
    public int MaxAmmo = 10;
    
    public int ReloadTime;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        CurrentAmmo = MaxAmmo;
    }

    
    void Update()
    {
        transform.up = (ScreenUtils.GetMousePosition2d() - (Vector2)transform.position).normalized;
        if (IsReloading) return;
        if (CurrentAmmo == 0) StartCoroutine(Reload());
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    public IEnumerator Reload()
    {
        IsReloading = true;
        Debug.Log("Reloading");

        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;
        IsReloading = false;
    }
    private void Shoot()
    {
        Instantiate(Bullet,ShootPoint.position, transform.rotation);
        CurrentAmmo--;
    }

    public void TakeHit()
    {
        Health -= 1;
        if(Health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        Game.OnPlayerDied();
    }
}

