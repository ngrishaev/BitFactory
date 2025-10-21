using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace Code.Unity.Services
{
    [ExcludeFromCoverage]
    public class UserInputProvider : MonoBehaviour, IUserInputProvider
    {
        public event Action? OnRKeyPressed;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnRKeyPressed?.Invoke();
            }
        }

        public Vector3 MousePosition()
        {
            return Input.mousePosition;
        }
    }
}