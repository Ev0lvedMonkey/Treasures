using UnityEngine;
using VContainer;

public class DialogTestDynamic : MonoBehaviour
{
    private DialogLoader _dialogLoader;

    private  void Construct(DialogLoader dialogLoader)
    {
        _dialogLoader = dialogLoader;
    }

    private async void Start()
    {
        var dialog = await _dialogLoader.Load(DialogLoader.DialogLoadKeys.ADialog2);
        Debug.Log($"Loaded dialog: {dialog}");
    }
}
