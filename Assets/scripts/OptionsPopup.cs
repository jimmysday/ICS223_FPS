using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    [SerializeField] UIManager manager;
    [SerializeField] SettingPopup settingpopup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        settingpopup.Open();
        Close();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
        manager.SetGameActive(true);
    }
}
