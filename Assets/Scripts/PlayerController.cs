using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public int Health;
   
    public Game Game;

    public GameObject Bullet;
    public Transform ShootPoint;
    public int MaxAmmo = 10;
    public int ReloadTime;
    private bool IsReloading = false;
    public int CurrentAmmo { get; private set; }

    public AudioManager AudioManager;

    public GameObject BloodSplash;
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
        AudioManager.PlayReloadSound();
       

        yield return new WaitForSeconds(ReloadTime);

        CurrentAmmo = MaxAmmo;
        IsReloading = false;
    }
    public void ManualReload()
    {
        StartCoroutine(Reload());
        
    }
    private void Shoot()
    {
        Instantiate(Bullet,ShootPoint.position, transform.rotation);
        AudioManager.PlayShotSound();
        CurrentAmmo--;
    }

    public void TakeHit()
    {
        AudioManager.PlayPlayerHitSound();
        Health -= 1;
        if(Health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Instantiate(BloodSplash, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Game.OnPlayerDied();
    }
}

