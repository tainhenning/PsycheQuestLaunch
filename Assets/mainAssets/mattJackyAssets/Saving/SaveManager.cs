using UnityEngine;

/**
 * Created by Matthew Lillie
 * 
 * Manages saving and loading for the game and follows the singleton design pattern.
 */
public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance
    {
        set;
        get;
    }

    private GameSave currentSaveState;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    // Saves the current game save state
    public void Save()
    {
        PlayerPrefs.SetString("gameSave", GameSaveSerializer.Serialize<GameSave>(currentSaveState));
    }

    // Loads the current game state and will create a new one if none exists
    public void Load()
    {
        if(PlayerPrefs.HasKey("gameSave"))
        {
            currentSaveState = GameSaveSerializer.Deserialize<GameSave>(PlayerPrefs.GetString("gameSave"));
        }
        else
        {
            //No game save currently exists, so create a new one.
            currentSaveState = new GameSave();
            Save();
        }
    }

    //Gets the current game save state.
    public GameSave GetCurrentSaveState()
    {
        return currentSaveState;
    }
}
