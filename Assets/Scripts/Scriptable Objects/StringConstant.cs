using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu (menuName = "Constant Values/String Constants")]
    public class StringConstant : ScriptableObject
    {
        [SerializeField]
        string value;

        public string Value()
        {
            return value;
        }
    } 
}
