using System;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class SaveLoadCurrencyToFileService
{
    public static async UniTask Save(string currencyName, int currencyBalance)
    {
        try
        {
            var path = Path.Combine(Application.persistentDataPath, currencyName);
            await File.WriteAllTextAsync(path, currencyBalance.ToString());
        }
        catch (IOException e)
        {
            Debug.LogError($"Error saving to file: {e.Message}");
        }
    }

    public static async UniTask<int> Load(string currencyName)
    {
        try
        {
            var path = Path.Combine(Application.persistentDataPath, currencyName);
            var balance = await File.ReadAllTextAsync(path);
            return Convert.ToInt32(balance);
        }
        catch (IOException e)
        {
            Debug.LogError($"Error loading from file: {e.Message}");
        }
        
        return 0;
    }
}