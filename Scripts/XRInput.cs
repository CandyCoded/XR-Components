// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded.XRComponents
{

    public static class XRInput
    {

        public const float TriggerThreshold = 0.75f;

        public static class Oculus
        {

            public static class Button
            {

                public static bool One { get { return Input.GetButton("Oculus_CrossPlatform_Button_1"); } }
                public static bool Two { get { return Input.GetButton("Oculus_CrossPlatform_Button_2"); } }
                public static bool Three { get { return Input.GetButton("Oculus_CrossPlatform_Button_3"); } }
                public static bool Four { get { return Input.GetButton("Oculus_CrossPlatform_Button_4"); } }

                public static bool PrimaryThumbstick { get { return Input.GetButton("Oculus_CrossPlatform_Button_PrimaryThumbstick"); } }
                public static bool SecondaryThumbstick { get { return Input.GetButton("Oculus_CrossPlatform_Button_SecondaryThumbstick"); } }

            }

            public static class Axis1D
            {

                public static bool PrimaryIndexTrigger { get { return Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") > TriggerThreshold; } }
                public static bool SecondaryIndexTrigger { get { return Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > TriggerThreshold; } }

                public static bool PrimaryHandTrigger { get { return Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") > TriggerThreshold; } }
                public static bool SecondaryHandTrigger { get { return Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger") > TriggerThreshold; } }

            }

            public static class Axis2D
            {

                public static float PrimaryThumbstickHorizontal { get { return Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal"); } }
                public static float PrimaryThumbstickVertical { get { return Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical"); } }

                public static float SecondaryThumbstickHorizontal { get { return Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal"); } }
                public static float SecondaryThumbstickVertical { get { return Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical"); } }

                public static Vector2 PrimaryThumbstick { get { return new Vector2(PrimaryThumbstickHorizontal, PrimaryThumbstickVertical); } }
                public static Vector2 SecondaryThumbstick { get { return new Vector2(SecondaryThumbstickHorizontal, SecondaryThumbstickVertical); } }

            }

        }

    }

}
