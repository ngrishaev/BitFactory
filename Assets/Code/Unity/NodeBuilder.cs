using UnityEngine;

namespace Code.Unity
{
    public class NodeBuilder: MonoBehaviour
    {
        [SerializeField] private RectTransform _root;
        
        public GameObject Build(Vector2Int at, GameObject prefab)
        {
            var node = Instantiate(prefab, _root);
            node.transform.localPosition = new Vector3(at.x * 100, at.y * 100, _root.transform.localPosition.z);
            return node;
        }
    }
}