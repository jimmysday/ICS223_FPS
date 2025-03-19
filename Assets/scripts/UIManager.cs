using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    //private int score = 0;
    [SerializeField] private TextMeshProUGUI textscore;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingPopup settingPopup;
    [SerializeField] private GameOverPopup gameOverPopup;

    private int popupsActive = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealth(1);
        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && popupsActive == 0)
        {
//            SetGameActive(false);
            optionsPopup.Open();
        }
    }

    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }
    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }

    public void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
        Debug.Log("Popup open" + popupsActive);
    }

    public void OnPopupClosed()
    {
        popupsActive--;
        if(popupsActive == 0)
        {
            SetGameActive(true);
        }
        Debug.Log("Popup close" + popupsActive);
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        textscore.text = "Score: " +newScore.ToString();
    }

    private void OnHealthChanged(float healthPersentage)
    {
        UpdateHealth(healthPersentage);
    }

    // update score display
    public void UpdateHealth(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;

        // Define start and end colors for interpolation
        Color startColor;
        Color endColor;
        float t;

        // If health is above 50%, transition from green to yellow
        if (healthPercentage > 0.5f)
        {
            startColor = Color.yellow;
            endColor = Color.green;
            t = (healthPercentage - 0.5f) * 2; // Normalize 0.5 to 1 range
        }
        else
        {
            startColor = Color.red;
            endColor = Color.yellow;
            t = healthPercentage * 2; // Normalize 0 to 0.5 range
        }

        // Apply interpolated color
        healthBar.color = Color.Lerp(startColor, endColor, t);
    }

    public void SetGameActive(bool active)
    {
        Debug.Log("SetGameActive" + active);
        if (active)
        {
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
        }
        else
        {
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
        }
    }
}
