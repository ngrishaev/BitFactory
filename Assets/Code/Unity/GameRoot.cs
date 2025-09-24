using System;
using Code.Application.Orchestrators;
using Code.Unity.GameField.Builder;
using Code.Unity.GameField.Input;
using Code.Unity.GameField.Palette;
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
            var gameField = new Domain.GameField(8, 8);
            var orchestration = new GameFieldOrchestrator(gameField, _input, _builder, _palette);
        }
    }
}