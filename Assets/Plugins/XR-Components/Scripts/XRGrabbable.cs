using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class XRGrabbable : MonoBehaviour
{

    private new Rigidbody rigidbody;

    private void Awake()
    {

        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    public void OnGrab(Transform parentTransform)
    {

        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

        gameObject.transform.SetParent(parentTransform);

    }


    public void OnRelease()
    {

        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;

        gameObject.transform.SetParent(null);

    }

}
