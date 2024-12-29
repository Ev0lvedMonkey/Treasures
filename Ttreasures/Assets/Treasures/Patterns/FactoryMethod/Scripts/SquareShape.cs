using UnityEngine;


internal class SquareShape : Shape
{
    [SerializeField] private float _squareWidth;
    [SerializeField] private float _squareHeight;

    public void Init(string shapeName, float squareWidth, float squareHeight)
    {
        Init(shapeName);
        _squareWidth = squareWidth;
        _squareHeight = squareHeight;
    }

    public override void DoSomething()
    {
        Debug.Log($"Square doing something");
    }

}

