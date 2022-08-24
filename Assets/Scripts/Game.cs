using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject LossScreen;
    public GameObject InGameUI;

    public AudioManager _AudioManager;

    public GameObject BloodSplash;

    public enum State
    {
        Playing,
        Lost,
        Pause,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Lost;
        Spawner.SetActive(false);
        InGameUI.SetActive(false);
        LossScreen.SetActive(true);
       

    }
    

    public void KillAll()
    {
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag ("Enemy"); 
        foreach(GameObject e in EnemyList)
        {
            _AudioManager.PlayZombieDieSound();
            Instantiate(BloodSplash, e.transform.position, Quaternion.identity);
            Destroy(e);
        }
    }

}
