using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float money { get; private set; }

    [Space]

    public int qntMultiplier;
    public int qntPassives;

    [Space]

    public float multiValue;
    public float passiveValue;

    [Space]

    public float multiplierPrice;
    public float adMultiplier;
    public float passivePrice;
    public float adPassive;

    float autoSaveTime = 5f;

    public static event System.Action OnMoneyChange;

    private void Start()
    {
        SaveManager.Load();
        StartCoroutine(AutoSave());
        StartCoroutine(PassiveGain());
    }
    public void AddMoney(float value)
    {
        money += value;
        OnMoneyChange?.Invoke();
    }
    public void ClickOn()
    {
        float value = 1;

        float multiplier = 1 + qntMultiplier * multiValue;
        value *= multiplier;

        AddMoney(value); 
    }

    public float TakeMultiplier()
    {
        float price = qntMultiplier * multiplierPrice * adMultiplier;
        if (price <= 0) price = multiplierPrice;

        return price;
    }

    public void BuyMultiplier()
    {
        float price = TakeMultiplier();
        if (money < price)
        {
            Debug.Log("Voce não tem money");
            return;
        }

        AddMoney(-price);

        qntMultiplier++;
        GameDirectory.instance.HUD.UpdateMultiplier();

        SaveManager.Save();
    }

    public IEnumerator PassiveGain()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float value = qntPassives * passiveValue;
            AddMoney(value);
        }
    }

    public IEnumerator AutoSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveTime);
            SaveManager.Save();
        }
    }
}
