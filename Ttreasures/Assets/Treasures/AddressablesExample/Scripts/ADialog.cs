using UnityEngine;
using UnityEngine.UI;

internal abstract class ADialog : MonoBehaviour
{
    [SerializeField] private Button _exampleBtn;

    private void Awake()
    {
        InitButtonLiseners();
    }

    protected void InitButtonLiseners()
    {
        _exampleBtn?.onClick.AddListener(DOSomething);
    }

    protected void Hide()
    {
        Destroy(gameObject);
    }

    private void DOSomething()
    {
        Debug.Log($"Did base somethig {this.name}");
    }
}
