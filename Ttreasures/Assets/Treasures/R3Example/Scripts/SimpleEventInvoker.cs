using R3;
using UnityEngine;
using UnityEngine.UI;

internal class SimpleEventInvoker : MonoBehaviour
{
    [SerializeField] private Button _button;

    public readonly Subject<Unit> OnSimpleR3Event = new();

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OnSimpleR3Event.OnNext(Unit.Default);
    }
}
