using UnityEngine;

namespace Runtime.Gameplay.Resource
{
    public class TreeWood : MonoBehaviour
    {
        [SerializeField]private Vector3 offset;

        public Vector3 GetOffset()
        {
            return offset;
        }
    }
}
