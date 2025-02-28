using UnityEngine;
using UnityEngine.UI;

internal class FirstDialog : V1Dialog, ISinglRepresentative
{
    [SerializeField] private Button _nextDialogButton;
    private static FirstDialog Instance;

    private void Awake()
    {
        InitButtonLiseners();
        UseSinglRepresentative();
    }

    protected void InitButtonLiseners()
    {
        base.InitButtonLiseners();
        _nextDialogButton.onClick.AddListener(NextDialog);
    }

    private void NextDialog()
    {
        DialogManager.ShowDialog<SecondDialog>();
        base.Hide();
    }

    internal void UseSinglRepresentative()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    void ISinglRepresentative.UseSinglRepresentative()
    {
        throw new System.NotImplementedException();
    }
}
