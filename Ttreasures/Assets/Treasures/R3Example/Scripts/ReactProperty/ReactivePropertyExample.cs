using R3;
using UnityEngine;
using UnityEngine.UI;

internal class ReactivePropertyExample : MonoBehaviour
{
    [SerializeField] private Button _button;

    public readonly ReactiveProperty<int> IntAmount = new();

    public ReadOnlyReactiveProperty<bool> IntAmountIsNegativeNumber;

    private void Awake()
    {
        IntAmount.Value = 3;
        IntAmountIsNegativeNumber = IntAmount.Select(amount => amount < 0).ToReadOnlyReactiveProperty();

        _button.onClick.AddListener(SubtractTheNumber);
    }

    private void SubtractTheNumber()
    {
        IntAmount.Value--;
    }
}

