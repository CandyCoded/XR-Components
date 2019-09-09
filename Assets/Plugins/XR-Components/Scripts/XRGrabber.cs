// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CandyCoded.XRComponents
{

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(XRNodeController))]
    [AddComponentMenu("CandyCoded/XR Components/XR Grabber")]
    public class XRGrabber : MonoBehaviour
    {

        [SerializeField]
        private XRInput.Axis1D _trigger = XRInput.Axis1D.PrimaryIndexTrigger;

        private readonly Dictionary<Collider, XRGrabbable> _collisions = new Dictionary<Collider, XRGrabbable>();

        private XRNodeController _nodeController;

        public XRNodeController nodeController => _nodeController;

        private XRGrabbable _grabbed;

        public Transform parentTransform => gameObject.transform;

        private void Awake()
        {

            _nodeController = gameObject.GetComponent < XRNodeController>();

        }

        private void Update()
        {

            if (XRInput.Get(_trigger))
            {

                if (_grabbed || _collisions.Count <= 0)
                {
                    return;
                }

                _grabbed = _collisions.OrderBy(c => Vector3.Distance(c.Key.gameObject.transform.position, gameObject.transform.position)).FirstOrDefault().Value;

                _grabbed.OnGrab(this);

            }
            else if (_grabbed)
            {

                _grabbed.OnRelease(this);

                _grabbed = null;

            }

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.GetComponent<XRGrabbable>() != null && !_collisions.ContainsKey(other))
            {
                _collisions.Add(other, other.gameObject.GetComponent<XRGrabbable>());
            }

        }

        private void OnTriggerExit(Collider other)
        {

            if (_collisions.ContainsKey(other))
            {
                _collisions.Remove(other);
            }

        }

    }

}
