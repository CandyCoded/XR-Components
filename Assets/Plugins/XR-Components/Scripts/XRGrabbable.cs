// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded.XRComponents
{

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class XRGrabbable : MonoBehaviour
    {

        [SerializeField]
        private bool _snapTransformOnGrab;

        private Transform _transform;

        private Rigidbody _rigidbody;

        private Transform _previousParentTransform;

        private void Awake()
        {

            _transform = gameObject.transform;

            _rigidbody = gameObject.GetComponent<Rigidbody>();

        }

        public void OnGrab(XRGrabber grabber)
        {

            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;

            _previousParentTransform = _transform.parent;

            _transform.SetParent(grabber.parentTransform);

            if (_snapTransformOnGrab)
            {

                _transform.localPosition = Vector3.zero;

            }

        }

        public void OnRelease(XRGrabber grabber)
        {

            _rigidbody.useGravity = true;
            _rigidbody.isKinematic = false;

            _rigidbody.velocity = grabber.nodeController.velocity;

            _transform.SetParent(_previousParentTransform);

        }

    }

}
