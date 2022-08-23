
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Spawner;


    public void OnPlayerDied()
    {
        Spawner.SetActive(false);

    }
}
