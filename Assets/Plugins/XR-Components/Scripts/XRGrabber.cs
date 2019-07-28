using System.Collections.Generic;
using System.Linq;
using CandyCoded.XRComponents;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class XRGrabber : MonoBehaviour
{

    private readonly Dictionary<Collider, XRGrabbable> collisions = new Dictionary<Collider, XRGrabbable>();

    private XRGrabbable grabbed;

    private Transform parentTransform => gameObject.transform;

    private void Update()
    {

        if (XRInput.GetDown(XRInput.Button.One))
        {

            if (!grabbed.Equals(null) || collisions.Count <= 0)
            {
                return;
            }

            grabbed = collisions.OrderBy(c => Vector3.Distance(c.Key.gameObject.transform.position, gameObject.transform.position)).FirstOrDefault().Value;

            grabbed.OnGrab(parentTransform);

        }
        else if (XRInput.GetUp(XRInput.Button.One))
        {

            grabbed.OnRelease();

            grabbed = null;

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<XRGrabbable>() != null && !collisions.ContainsKey(other))
        {
            collisions.Add(other, other.gameObject.GetComponent<XRGrabbable>());
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (collisions.ContainsKey(other))
        {
            collisions.Remove(other);
        }

    }

}
