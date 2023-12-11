using UnityEngine;

public static class SaveLoadCurrencyToPlayerPrefsService
{
    public static void Save(string currencyName, int currencyBalance)
    {
        PlayerPrefs.SetInt(currencyName, currencyBalance);
        PlayerPrefs.Save();
    }

    public static int Load(string currencyName)
    {
        return PlayerPrefs.GetInt(currencyName);
    }
}