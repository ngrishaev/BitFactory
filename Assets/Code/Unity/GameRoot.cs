using System;
using Code.Application.Orchestrators;
using Code.Unity.GameField.Builder;
using Code.Unity.GameField.Input;
using Code.Unity.Palette;
using UnityEngine;

namespace Code.Unity
{
    public class GameRoot: MonoBehaviour
    {
        [SerializeField] private NodesPalette _palette;
        [SerializeField] private NodeBuilder _builder;
        [SerializeField] private GameFieldCellsInput _input;

        private void Start()
        {
            var orchestration = new GameFieldOrchestrator(_input, _builder, _palette);
        }
    }
}