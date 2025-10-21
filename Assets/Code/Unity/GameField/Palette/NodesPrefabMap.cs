using System;
using System.Collections.Generic;
using Code.Domain.Nodes;
using Code.Unity.GameField.Nodes;
using UnityEngine;
using UnityEngine.TestTools;

namespace Code.Unity.GameField.Palette
{
    [ExcludeFromCoverage]
    [CreateAssetMenu(fileName = "NodePrefabMap", menuName = "ScriptableObjects/MapNodeDictionary", order = 1)]
    public class NodesPrefabMap: ScriptableObject
    {
        [SerializeField] private List<NodeMapData> _nodePrefabs = new();
        private readonly Dictionary<NodeType, NodeDisplay> _typeToPrefabDictionary = new();

        public NodeDisplay? GetPrefab(NodeType id)
        {
            if(_typeToPrefabDictionary.Count == 0)
            {
                Initialize();
            }
            
            if (_typeToPrefabDictionary.TryGetValue(id, out var prefab))
            {
                return prefab;
            }

            Debug.LogError($"Prefab with name {id} not found in MapEntityDictionary.");
            return null;
        }

        private void Initialize()
        {
            _typeToPrefabDictionary.Clear();

            foreach (NodeMapData entry in _nodePrefabs)
            {
                if (!_typeToPrefabDictionary.ContainsKey(entry.Type))
                {
                    _typeToPrefabDictionary.Add(entry.Type, entry.Prefab);
                }
            }
        }

        [Serializable]
        public struct NodeMapData
        {
            public NodeType Type;
            public NodeDisplay Prefab;
        }
    }
}