using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject LossScreen;
    [SerializeField] private GameObject InGameUI;

    [SerializeField] private AudioManager _AudioManager;

    [SerializeField] private GameObject BloodSplash;

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

    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
