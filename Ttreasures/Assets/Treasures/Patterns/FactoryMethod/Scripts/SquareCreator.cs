using UnityEngine;

internal class SquareCreator : Creator
{
    public override Shape FactoryMethod()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/SquarePrefab");
        var go = GameObject.Instantiate(prefab);
        var squareShape = go.AddComponent<SquareShape>();
        squareShape.Init("This square", 2, 2);
        return squareShape;
    }
}

