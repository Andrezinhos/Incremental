using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static void Save()
    {
        PlayerPrefs.SetFloat("money", GameDirectory.instance.LevelManager.money);
        PlayerPrefs.SetInt("multiplier", GameDirectory.instance.LevelManager.qntMultiplier);
        PlayerPrefs.SetInt("passives", GameDirectory.instance.LevelManager.qntPassives);
        PlayerPrefs.Save();
        Debug.Log("Salvo");
    }

    public static void Load()
    {
        GameDirectory.instance.LevelManager.AddMoney(PlayerPrefs.GetFloat("money", 0));
        GameDirectory.instance.LevelManager.qntMultiplier = PlayerPrefs.GetInt("multiplier", 0);
        GameDirectory.instance.LevelManager.qntPassives = PlayerPrefs.GetInt("passives", 0);
    }
}
