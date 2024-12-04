using UnityEngine;

public enum GAME_STATE
{
    RUNNING,
    STOPPED,
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GAME_STATE _gameState;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    void Start()
    {
        _gameState = GAME_STATE.RUNNING;
    }

    public GAME_STATE GetGameState()
    {
        return _gameState;
    }

    public void PutGameState(GAME_STATE state)
    {
        _gameState = state;
    }
}
