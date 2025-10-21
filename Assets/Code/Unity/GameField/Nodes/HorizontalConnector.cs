using Code.Unity.GameField.Builder;
using UnityEngine;

namespace Code.Unity.GameField.Nodes
{
    public sealed class HorizontalConnector: NodeDisplay
    {
        public void PlayAccept(PacketDisplay display)
        {
            display.transform.SetParent(transform);
            display.transform.localPosition = Vector3.zero;
        }
    }
}