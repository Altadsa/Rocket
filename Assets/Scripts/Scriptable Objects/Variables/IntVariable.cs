using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rocket
{
    [CreateAssetMenu(menuName = "Variables/Int Variable")]
    public class IntVariable : ScriptableObject
    {

        [SerializeField]
        int value;

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

    } 
}
