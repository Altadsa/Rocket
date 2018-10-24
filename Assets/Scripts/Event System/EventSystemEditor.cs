using UnityEngine;
using UnityEditor;

namespace Rocket
{
    [CustomEditor(typeof(EventSystem))]
    public class EventSystemEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

        }

    } 
}
