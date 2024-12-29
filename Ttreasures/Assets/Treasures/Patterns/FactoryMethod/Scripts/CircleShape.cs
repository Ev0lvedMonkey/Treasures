using UnityEngine;

internal class CircleShape : Shape
{
    [SerializeField] private float _circleRadius;

    public void Init(string shapeName, float circleRadius)
    {
        Init(shapeName);
        _circleRadius = circleRadius;
    }

    public override void DoSomething()
    {
        Debug.Log($"Circle doing something");
    }
}

