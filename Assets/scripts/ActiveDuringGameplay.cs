using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInActive);
    }

    private void DeDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInActive);
    }

    private void OnGameActive()
    {
        Debug.Log("active to ray");
        this.enabled = true;
    }
    private void OnGameInActive()
    {
        Debug.Log("inactive to ray");
        this.enabled = false;
    }
}
