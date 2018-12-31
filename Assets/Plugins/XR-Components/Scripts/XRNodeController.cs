using UnityEngine;
using UnityEngine.XR;

namespace CandyCoded.XRComponents
{

    public class XRNodeController : MonoBehaviour
    {

        [SerializeField]
        private XRNode nodeType = XRNode.LeftHand;

#pragma warning disable CS0649
        [SerializeField]
        private bool lockPosition;

        [SerializeField]
        private bool lockRotation;
#pragma warning restore CS0649

        public bool isTracking { get; private set; }

        public Vector3 position { get; private set; }
        public Quaternion rotation { get; private set; }

        private void Update()
        {

            if (isTracking)
            {

                position = InputTracking.GetLocalPosition(nodeType);
                rotation = InputTracking.GetLocalRotation(nodeType);

                if (!lockPosition)
                {

                    gameObject.transform.position = position;

                }

                if (!lockRotation)
                {

                    gameObject.transform.rotation = rotation;

                }

            }

        }

        private void HandleTrackingEvent(XRNodeState obj)
        {

            if (obj.nodeType == nodeType)
            {

                isTracking = obj.tracked;

            }

        }

        private void OnEnable()
        {

            InputTracking.trackingAcquired += HandleTrackingEvent;
            InputTracking.trackingLost += HandleTrackingEvent;

        }

        private void OnDisable()
        {

            InputTracking.trackingAcquired -= HandleTrackingEvent;
            InputTracking.trackingLost -= HandleTrackingEvent;

        }

    }

}
