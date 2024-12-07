using DialogModule_V2;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(CanvasScaler))]
[RequireComponent(typeof(GraphicRaycaster))]
internal class DialogModulesController : MonoBehaviour
{
    [SerializeField] private List<Dialog> _dialogsList = new();

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Alpha1))
            ShowDialog<Dialog1>();
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Alpha2))
            ShowDialog<Dialog2>();
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Alpha3))
            ShowDialog<Dialog3>();

    }

    private void ShowDialog<T>() where T : Dialog
    {
        CleanDialogList();

        foreach (var dialog in _dialogsList)
        {
            if (dialog is T)
            {
                dialog.ShowDialog(transform);
                break;
            }
        }
    }

    private void CleanDialogList()
    {
        foreach (var dialog in _dialogsList)
            dialog.HideDialog();
    }
}

