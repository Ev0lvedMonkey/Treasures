using UnityEngine;
using VContainer;

public class DialogTestStatic : MonoBehaviour
{
    [Inject] private DialogLoader _dialogLoader;

    private async void Start()
    {
        var dialog = await _dialogLoader.Load(DialogLoader.DialogLoadKeys.ADialog2);
        Debug.Log($"Loaded dialog: {dialog}");
    }
}

