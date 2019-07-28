// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

namespace CandyCoded.XRComponents
{

    [Serializable]
    public class TrackingEvent : UnityEvent<bool>
    {

    }

    public class XRNodeController : MonoBehaviour
    {

        [SerializeField]
        private XRNode nodeType = XRNode.LeftHand;

#pragma warning disable CS0649
        [SerializeField]
        private bool lockPosition;

        [SerializeField]
        private bool lockRotation;

        [SerializeField]
        private TrackingEvent TrackingUpdated;
#pragma warning restore CS0649

        public bool isTracking { get; private set; }

        public Vector3 position { get; private set; }

        public Quaternion rotation { get; private set; }

        private void Update()
        {

            if (!isTracking)
            {
                return;
            }

            if (!lockPosition)
            {

                position = InputTracking.GetLocalPosition(nodeType);

            }

            if (!lockRotation)
            {

                rotation = InputTracking.GetLocalRotation(nodeType);

            }

            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;

        }

        private void HandleTrackingEvent(XRNodeState obj)
        {

            if (obj.nodeType != nodeType)
            {
                return;
            }

            isTracking = obj.tracked;

            TrackingUpdated?.Invoke(isTracking);

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
