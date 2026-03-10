using UnityEngine;

public class GameDirectory : MonoBehaviour
{

    public LevelManager LevelManager;
    public HUD HUD;

    public static GameDirectory instance;

    private void Awake()
    {
        instance = this;    
    }

}
