using System;
using UnityEngine;

namespace Code.Unity.Services
{
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