using UnityEngine;

internal class CircleCreator : Creator
{
    public override Shape FactoryMethod()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/CirclePrefab");
        var go = GameObject.Instantiate(prefab);
        var circleShape = go.AddComponent<CircleShape>();
        circleShape.Init("This square", 2);
        return circleShape;
    }
}
