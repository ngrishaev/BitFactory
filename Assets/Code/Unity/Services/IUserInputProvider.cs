using System;
using UnityEngine;

namespace Code.Unity.Services
{
    public interface IUserInputProvider
    {
        event Action OnRKeyPressed;
        
        Vector3 MousePosition();
    }
}