using UnityEngine;
using UnityEngine.UI;

public class CreateShapesWindow : MonoBehaviour
{
    [SerializeField] private Button _squareCreateBtn;
    [SerializeField] private Button _circleCreateBtn;

    private void Awake()
    {
        _squareCreateBtn.onClick.AddListener(() => {
            Creator creator = new SquareCreator();
            Shape squareShape = creator.FactoryMethod();
            squareShape.DoSomething();
        });

        _circleCreateBtn.onClick.AddListener(() => {
            Creator creator = new CircleCreator();
            Shape circleShape = creator.FactoryMethod();
            circleShape.DoSomething();
        });
    }
}

