using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu(menuName = "Constant Values/Int Constant")]
    public class IntConstant : ScriptableObject
    {
        [SerializeField]
        int value;

        public int Value()
        {
            return value;
        }
    } 
}
