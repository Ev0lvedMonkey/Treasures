using UnityEngine;

public class ExampleStorageManager 
{
    private ExampleStorage _storage;
    private IStorageService _storageService;

    private int _scoreIncrementCalls;

    public ExampleStorageManager(ExampleStorage storage, IStorageService storageService)
    {
        _storage = storage;
        _storageService = storageService;
    }

    public void ResetAllStatistics()
    {
        _storage.BestScore = 0;
        ResetRoundData();
        SaveStatistics();
        Debug.Log("All statistics reset to default!");
    }


    public void IncrementRoundScore()
    {
        _scoreIncrementCalls++;

        int pointsToAdd = CalculatePoints();
        _storage.RoundScore += pointsToAdd;
        CheckAndUpdateBestScore();
        Debug.Log($"Increments count {_scoreIncrementCalls}");
    }

    private int CalculatePoints()
    {
        if (_scoreIncrementCalls <= 20 && _scoreIncrementCalls > 10)
        {
            Debug.Log($"add +200");
            return 200;
        }
        else if (_scoreIncrementCalls <= 10)
        {
            Debug.Log($"add +100");
            return 100;
        }
        else
        {
            Debug.Log($"add +300");
            return 300;
        }
    }


    private void CheckAndUpdateBestScore()
    {
        if (_storage.RoundScore > _storage.BestScore)
        {
            _storage.BestScore = _storage.RoundScore;
            SaveStatistics();
        }
    }

    private void SaveStatistics()
    {
        _storageService.Save(ConstantsService.JsonHASHStorageKey, _storage);
        Debug.Log("Statistics Saved!");
    }

    private void ResetRoundData()
    {
        _storage.RoundScore = 0;
        _scoreIncrementCalls = 0;
    }
}
