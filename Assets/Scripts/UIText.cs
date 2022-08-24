using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI TimerTextInGame;
    public TextMeshProUGUI TimerTextLoss;
    public TextMeshProUGUI HealthText;
    public PlayerController PlayerController;
    public Game Game;

    public float CurrentTime;
 
    void Start()
    {
        
        HealthText.text = PlayerController.Health.ToString();
        AmmoText.text = PlayerController.CurrentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = PlayerController.Health.ToString();
        AmmoText.text = PlayerController.CurrentAmmo.ToString();
        if(Game.CurrentState == Game.State.Playing) CurrentTime += Time.deltaTime;
        TimerTextInGame.text = CurrentTime.ToString("0.00");
        TimerTextLoss.text = CurrentTime.ToString("0.00") + " s";
    }
}
