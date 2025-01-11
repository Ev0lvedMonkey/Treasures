using UnityEngine;

public class Bootsrtap : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private KeyboardInputHandler _keyboardInputHandler;

    private ExampleStorage _storage;
    private IStorageService _storageService;
    private ExampleStorageManager _exampleStorageManager;


    private void Awake()
    {
        _storage = new();
        _storageService = new JSonToFileStorageService();

        _storageService.Load<ExampleStorage>(ConstantsService.JsonHASHStorageKey, (storage) =>
        {
            _storage = storage;
            Debug.Log($"Loaded data {_storage.RoundScore} Best score {_storage.BestScore}");
        }
            ); ;
        _exampleStorageManager = new ExampleStorageManager(_storage, _storageService);
        _keyboardInputHandler.Init(_exampleStorageManager);
    }
}
