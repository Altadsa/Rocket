using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    [CreateAssetMenu (fileName = "String Constant", menuName = "Constants")]
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
