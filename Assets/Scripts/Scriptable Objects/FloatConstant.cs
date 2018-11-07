using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(menuName = "Constant Values/Float Constant")]
    public class FloatConstant : ScriptableObject
    {
        [SerializeField]
        float value;

        public float Value { get { return value; } }
    } 
}
