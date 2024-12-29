using UnityEngine;

internal abstract class Shape : MonoBehaviour
{
    [SerializeField] private string _shapeName;

    protected virtual void Init(string shapeName)
    {
        _shapeName = shapeName;
    }

    public abstract void DoSomething();
}

