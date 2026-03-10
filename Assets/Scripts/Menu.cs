
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void InitGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
