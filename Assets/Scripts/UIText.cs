using UnityEngine;
using TMPro;

public class UIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AmmoText;
    [SerializeField] private TextMeshProUGUI TimerTextInGame;
    [SerializeField] private TextMeshProUGUI TimerTextLoss;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private PlayerController PlayerController;
    [SerializeField] private Game Game;

    [SerializeField] private float CurrentTime;
 
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
