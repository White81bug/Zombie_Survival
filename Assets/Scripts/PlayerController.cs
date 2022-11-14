using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public int Health;
   
    public Game Game;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private int MaxAmmo = 10;
    [SerializeField] private int ReloadTime;
    private bool IsReloading = false;
    public int CurrentAmmo { get; private set; }

    [SerializeField] private AudioManager AudioManager;

    [SerializeField] private GameObject BloodSplash;
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

