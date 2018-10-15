using UnityEngine;

namespace Rocket
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        Transform followTarget;

        public float padding;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!followTarget)
            {
                return;
            }
            transform.position = new Vector3(transform.position.x, followTarget.position.y + padding, transform.position.z);
        }
    } 
}
