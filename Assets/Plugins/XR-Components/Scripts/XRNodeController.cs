// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

namespace CandyCoded.XRComponents
{

    [Serializable]
    public class TrackingEvent : UnityEvent<bool>
    {

    }

    [AddComponentMenu("CandyCoded/XR Components/XR Node Controller")]
    public class XRNodeController : MonoBehaviour
    {

        [SerializeField]
        private XRNode _nodeType = XRNode.LeftHand;

#pragma warning disable CS0649
        [SerializeField]
        private bool _lockPosition;

        [SerializeField]
        private bool _lockRotation;

        [SerializeField]
        private TrackingEvent TrackingUpdated;
#pragma warning restore CS0649

        public bool isTracking { get; private set; }

        private Vector3 _position;

        public Vector3 position => _position;

        private Quaternion _rotation;

        public Quaternion rotation => _rotation;

        private Vector3 _velocity;

        public Vector3 velocity => _velocity;

        private Vector3 _angularVelocity;

        public Vector3 angularVelocity => _angularVelocity;

        private readonly List<XRNodeState> _nodeStates = new List<XRNodeState>();

        private void Update()
        {

            if (!isTracking)
            {
                return;
            }

            InputTracking.GetNodeStates(_nodeStates);

            foreach (var nodeState in _nodeStates)
            {

                if (!nodeState.nodeType.Equals(_nodeType))
                {
                    continue;
                }

                nodeState.TryGetPosition(out _position);
                nodeState.TryGetRotation(out _rotation);

                nodeState.TryGetVelocity(out _velocity);
                nodeState.TryGetAngularVelocity(out _angularVelocity);

            }

            if (!_lockPosition)
            {

                gameObject.transform.position = position;

            }

            if (!_lockRotation)
            {

                gameObject.transform.rotation = rotation;

            }

        }

        private void HandleTrackingEvent(XRNodeState obj)
        {

            if (!obj.nodeType.Equals(_nodeType))
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
