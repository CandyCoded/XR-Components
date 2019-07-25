// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace CandyCoded.XRComponents
{

    public static class XRInput
    {

        public const float TriggerThreshold = 0.75f;

        public enum InputMapping
        {

            Oculus_CrossPlatform_Button_1,

            Oculus_CrossPlatform_Button_2,

            Oculus_CrossPlatform_Button_3,

            Oculus_CrossPlatform_Button_4,

            Oculus_CrossPlatform_Button_Start,

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

        public enum Button
        {

            One = InputMapping.Oculus_CrossPlatform_Button_1,

            Two = InputMapping.Oculus_CrossPlatform_Button_2,

            Three = InputMapping.Oculus_CrossPlatform_Button_3,

            Four = InputMapping.Oculus_CrossPlatform_Button_4,

            Start = InputMapping.Oculus_CrossPlatform_Button_Start,

            PrimaryThumbstick = InputMapping.Oculus_CrossPlatform_Button_PrimaryThumbstick,

            SecondaryThumbstick = InputMapping.Oculus_CrossPlatform_Button_SecondaryThumbstick

        }

        public enum Axis1D
        {

            PrimaryIndexTrigger = InputMapping.Oculus_CrossPlatform_PrimaryIndexTrigger,

            SecondaryIndexTrigger = InputMapping.Oculus_CrossPlatform_SecondaryIndexTrigger,

            PrimaryHandTrigger = InputMapping.Oculus_CrossPlatform_PrimaryHandTrigger,

            SecondaryHandTrigger = InputMapping.Oculus_CrossPlatform_SecondaryHandTrigger

        }

        public enum Axis2D
        {

            PrimaryThumbstickHorizontal = InputMapping.Oculus_CrossPlatform_PrimaryThumbstickHorizontal,

            PrimaryThumbstickVertical = InputMapping.Oculus_CrossPlatform_PrimaryThumbstickVertical,

            SecondaryThumbstickHorizontal = InputMapping.Oculus_CrossPlatform_SecondaryThumbstickHorizontal,

            SecondaryThumbstickVertical = InputMapping.Oculus_CrossPlatform_SecondaryThumbstickVertical

        }

        public static bool Get(Button button)
        {

            return Input.GetButton(((InputMapping)button).ToString());

        }

        public static bool GetDown(Button button)
        {

            return Input.GetButtonDown(((InputMapping)button).ToString());

        }

        public static bool GetUp(Button button)
        {

            return Input.GetButtonUp(((InputMapping)button).ToString());

        }

        public static bool Get(Axis1D button)
        {

            return Input.GetAxis(((InputMapping)button).ToString()) > TriggerThreshold;

        }

        public static float Get(Axis2D button)
        {

            return Input.GetAxis(((InputMapping)button).ToString());

        }

    }

}
