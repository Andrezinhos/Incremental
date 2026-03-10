using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textMoney;

    [Space]

    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI multiplierDescText;
    string ogTextMultiplier;

    private void OnEnable()
    {
        LevelManager.OnMoneyChange += UpdateMoney;
    }

    private void OnDisable()
    {
        LevelManager.OnMoneyChange -= UpdateMoney;
    }

    private void Start()
    {
        ogTextMultiplier = multiplierDescText.text;
        UpdateMoney();
        UpdateMultiplier();
    }

    public void UpdateMoney()
    {
        textMoney.text = GameDirectory.instance.LevelManager.money.ToString("0.00"); 
    }

    public void UpdateMultiplier()
    {
        multiplierText.text = "$ " + GameDirectory.instance.LevelManager.TakeMultiplier().ToString();
        float gain = GameDirectory.instance.LevelManager.qntMultiplier 
            * GameDirectory.instance.LevelManager.multiValue 
            * 10;
        multiplierDescText.text = ogTextMultiplier.Replace("{X}", gain.ToString());
    }
}
