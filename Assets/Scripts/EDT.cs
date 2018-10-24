using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rocket
{
    public class EDT : MonoBehaviour
    {
        [SerializeField]
        IntConstant materialLayerIndex;

        [SerializeField]
        IntConstant etherealLayerIndex;

        float edtDuration = 10.0f;

        float timeActive = 0;

        Rocket rocket;

        // Use this for initialization
        void Start()
        {
            rocket = GetComponentInParent<Rocket>();
            if (!rocket) { return; }
            transform.position = rocket.transform.position;
            SetRocketLayer(etherealLayerIndex);
        }

        private void Update()
        {
            timeActive += Time.deltaTime;
            if (timeActive >= edtDuration)
            {
                SetRocketLayer(materialLayerIndex);
                Destroy(gameObject);
            }
        }

        private void SetRocketLayer(IntConstant layerIndex)
        {
            rocket.gameObject.layer = layerIndex.Value;
        }
    } 
}
