using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(menuName = "Constant Values/Vector2 Constant")]
    public class Vector2Constant : ScriptableObject
    {
        [SerializeField]
        Vector2 value;

        public Vector2 Value()
        {
            return value;
        }
    } 
}
