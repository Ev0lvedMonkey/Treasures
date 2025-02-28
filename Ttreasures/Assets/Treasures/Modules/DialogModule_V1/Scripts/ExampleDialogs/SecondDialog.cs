using UnityEngine;
using UnityEngine.UI;

internal class SecondDialog : V1Dialog
{
    [SerializeField] private Button _nextDialogButton;

    private void Awake()
    {
        InitButtonLiseners();
    }

    protected void InitButtonLiseners()
    {
        base.InitButtonLiseners();
        _nextDialogButton.onClick.AddListener(NextDialog);
    }

    private void NextDialog()
    {
        DialogManager.ShowDialog<FirstDialog>();
        base.Hide();
    }

}
