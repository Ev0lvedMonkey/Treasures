using UnityEditor.Il2Cpp;
using UnityEngine;

public class KeyboardInputHandler : MonoBehaviour
{
    private ExampleStorageManager _exampleStorageManager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            _exampleStorageManager.IncrementRoundScore();
    }


    public void Init(ExampleStorageManager exampleStorageManager)
    {
        _exampleStorageManager = exampleStorageManager;
    }
}
