using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI textscore;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingPopup settingPopup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
        UpdateScore(score);
        SetGameActive(true);
        Debug.Log("start:");
        Debug.Log(optionsPopup.IsActive());
        Debug.Log(settingPopup.IsActive());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && !settingPopup.IsActive())
        {
            SetGameActive(false);
            optionsPopup.Open();
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        textscore.text = "Score: " +newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
        }
    }
}
