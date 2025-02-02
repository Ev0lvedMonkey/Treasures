using R3;
using UnityEngine;


internal class SimpleEventListener : MonoBehaviour
{
    [SerializeField] private SimpleEventInvoker _invoker;

    private CompositeDisposable _disposable = new();

    private void Awake()
    {
        _invoker.OnSimpleR3Event.Subscribe(_ => OnSimpleR3Event()).AddTo(_disposable);
    }

    private void OnSimpleR3Event()
    {
        Debug.Log($"SimpleR3Event handled");
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}

