using R3;
using TMPro;
using UnityEngine;


internal class ReactivePrropertyLstener : MonoBehaviour
{
    [SerializeField] private ReactivePropertyExample _reactivePrroperty;
    [SerializeField] private TextMeshProUGUI _textMesh;

    private DisposableBag _disposables = new();

    private void Start()
    {
        _reactivePrroperty.IntAmount.Subscribe(RedrawIntAmount).AddTo(ref _disposables);
        _reactivePrroperty.IntAmountIsNegativeNumber.Subscribe(DrawNegativeText).AddTo(ref _disposables);
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }

    private void DrawNegativeText(bool obj)
    {
        if (obj)
        {
            _textMesh.text = "Negative";
            _reactivePrroperty.IntAmount.Dispose();

        }
    }

    private void RedrawIntAmount(int obj)
    {
        _textMesh.text = obj.ToString();
    }
}

