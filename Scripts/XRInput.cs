// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded.XRComponents
{

    public static class XRInput
    {

        public const float TriggerThreshold = 0.75f;

        public static class Oculus
        {

            public enum InputNames
            {
                Oculus_CrossPlatform_Button_1,
                Oculus_CrossPlatform_Button_2,
                Oculus_CrossPlatform_Button_3,
                Oculus_CrossPlatform_Button_4,
                Oculus_CrossPlatform_Button_PrimaryThumbstick,
                Oculus_CrossPlatform_Button_SecondaryThumbstick,
                Oculus_CrossPlatform_PrimaryIndexTrigger,
                Oculus_CrossPlatform_SecondaryIndexTrigger,
                Oculus_CrossPlatform_PrimaryHandTrigger,
                Oculus_CrossPlatform_SecondaryHandTrigger,
                Oculus_CrossPlatform_PrimaryThumbstickHorizontal,
                Oculus_CrossPlatform_PrimaryThumbstickVertical,
                Oculus_CrossPlatform_SecondaryThumbstickHorizontal,
                Oculus_CrossPlatform_SecondaryThumbstickVertical
            }

            public static class Button
            {

                public static bool One { get { return Input.GetButton(InputNames.Oculus_CrossPlatform_Button_1.ToString()); } }
                public static bool Two { get { return Input.GetButton(InputNames.Oculus_CrossPlatform_Button_2.ToString()); } }
                public static bool Three { get { return Input.GetButton(InputNames.Oculus_CrossPlatform_Button_3.ToString()); } }
                public static bool Four { get { return Input.GetButton(InputNames.Oculus_CrossPlatform_Button_4.ToString()); } }

                public static bool PrimaryThumbstick { get { return Input.GetButton(InputNames.Oculus_CrossPlatform_Button_PrimaryThumbstick.ToString()); } }
                public static bool SecondaryThumbstick { get { return Input.GetButton(InputNames.Oculus_CrossPlatform_Button_SecondaryThumbstick.ToString()); } }

            }

            public static class Axis1D
            {

                public static bool PrimaryIndexTrigger { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_PrimaryIndexTrigger.ToString()) > TriggerThreshold; } }
                public static bool SecondaryIndexTrigger { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_SecondaryIndexTrigger.ToString()) > TriggerThreshold; } }

                public static bool PrimaryHandTrigger { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_PrimaryHandTrigger.ToString()) > TriggerThreshold; } }
                public static bool SecondaryHandTrigger { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_SecondaryHandTrigger.ToString()) > TriggerThreshold; } }

            }

            public static class Axis2D
            {

                public static float PrimaryThumbstickHorizontal { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_PrimaryThumbstickHorizontal.ToString()); } }
                public static float PrimaryThumbstickVertical { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_PrimaryThumbstickVertical.ToString()); } }

                public static float SecondaryThumbstickHorizontal { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_SecondaryThumbstickHorizontal.ToString()); } }
                public static float SecondaryThumbstickVertical { get { return Input.GetAxis(InputNames.Oculus_CrossPlatform_SecondaryThumbstickVertical.ToString()); } }

                public static Vector2 PrimaryThumbstick { get { return new Vector2(PrimaryThumbstickHorizontal, PrimaryThumbstickVertical); } }
                public static Vector2 SecondaryThumbstick { get { return new Vector2(SecondaryThumbstickHorizontal, SecondaryThumbstickVertical); } }

            }

        }

    }

}
