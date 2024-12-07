using UnityEngine;

namespace DialogModule_V2
{
    internal abstract class Dialog : MonoBehaviour
    {
        private Dialog _activeInstance;

        internal void ShowDialog(Transform parent)
        {
            if (_activeInstance != null)
            {
                Destroy(_activeInstance.gameObject);
            }

            GameObject instance = Instantiate(gameObject, parent);
            _activeInstance = instance.GetComponent<Dialog>();
        }

        internal void HideDialog()
        {
            if (_activeInstance == null)
                return;
            Destroy(_activeInstance.gameObject);
            _activeInstance = null;
        }
    }
}
