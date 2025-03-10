using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingPopup : BasePopup
{
    [SerializeField] UIManager manager;
    [SerializeField] OptionsPopup popup;
    [SerializeField] TextMeshProUGUI difficultyLabel;
    [SerializeField] Slider difficultySlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " +((int)difficulty).ToString();
        //Debug.Log(difficultyLabel.text);
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }

    public void OnOKButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
        Close();
        popup.Open();
    }
    public void OnCancelButton()
    {
        Close();
        popup.Open();
    }
    override public void Open()
    {
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
//        gameObject.SetActive(true);
        Debug.Log("setting open");
        base.Open();
    }

}
