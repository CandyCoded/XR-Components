// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

#if UNITY_EDITOR

using UnityEditor;
using static CandyCoded.XRComponents.XRInput;

namespace CandyCoded.XRComponents
{

    public static class InputManagerSetup
    {

        public class Axis
        {
            public string m_Name;
            public string descriptiveName;
            public string descriptiveNegativeName;
            public string negativeButton;
            public string positiveButton;
            public string altNegativeButton;
            public string altPositiveButton;
            public float gravity;
            public float dead;
            public float sensitivity;
            public bool snap;
            public bool invert;
            public int type;
            public int axis;
            public int joyNum;
        }

        [MenuItem("CandyCoded/Tools/XR Components/Setup InputManager")]
        public static void SetupAxes()
        {

            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_PrimaryIndexTrigger.ToString(), dead = 0.19f, sensitivity = 1, type = 2, axis = 8 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_SecondaryIndexTrigger.ToString(), dead = 0.19f, sensitivity = 1, type = 2, axis = 9 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_PrimaryHandTrigger.ToString(), dead = 0.19f, sensitivity = 1, type = 2, axis = 10 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_SecondaryHandTrigger.ToString(), dead = 0.19f, sensitivity = 1, type = 2, axis = 11 });

            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_1.ToString(), positiveButton = "joystick button 0", gravity = 1000, dead = 0.001f, sensitivity = 1000 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_2.ToString(), positiveButton = "joystick button 1", gravity = 1000, dead = 0.001f, sensitivity = 1000 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_3.ToString(), positiveButton = "joystick button 2", gravity = 1000, dead = 0.001f, sensitivity = 1000 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_4.ToString(), positiveButton = "joystick button 3", gravity = 1000, dead = 0.001f, sensitivity = 1000 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_Start.ToString(), positiveButton = "joystick button 6", gravity = 1000, dead = 0.001f, sensitivity = 1000 });

            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_PrimaryThumbstick.ToString(), positiveButton = "joystick button 8", sensitivity = 0.1f });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_Button_SecondaryThumbstick.ToString(), positiveButton = "joystick button 9", sensitivity = 0.1f });

            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_PrimaryThumbstickHorizontal.ToString(), dead = 0.19f, sensitivity = 1, invert = false, type = 2, axis = 0 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_PrimaryThumbstickVertical.ToString(), dead = 0.19f, sensitivity = 1, invert = true, type = 2, axis = 1 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_SecondaryThumbstickHorizontal.ToString(), dead = 0.19f, sensitivity = 1, invert = false, type = 2, axis = 3 });
            AddAxis(new Axis { m_Name = InputMapping.Oculus_CrossPlatform_SecondaryThumbstickVertical.ToString(), dead = 0.19f, sensitivity = 1, invert = true, type = 2, axis = 4 });

        }

        public static bool AxisDefined(string m_Name)
        {

            SerializedObject serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");

            for (int i = 0; i < axesProperty.arraySize; i += 1)
            {

                if (axesProperty.GetArrayElementAtIndex(i).FindPropertyRelative("m_Name").stringValue.Equals(m_Name))
                {

                    return true;

                }

            }

            return false;

        }

        public static void AddAxis(Axis axis)
        {

            if (!AxisDefined(axis.m_Name))
            {

                SerializedObject serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
                SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");

                axesProperty.arraySize += 1;

                serializedObject.ApplyModifiedProperties();

                SerializedProperty axisProperty = axesProperty.GetArrayElementAtIndex(axesProperty.arraySize - 1);

                foreach (var field in typeof(Axis).GetFields())
                {

                    if (field.FieldType.Equals(typeof(string)))
                    {

                        axisProperty.FindPropertyRelative(field.Name).stringValue = (string)field.GetValue(axis);

                    }
                    else if (field.FieldType.Equals(typeof(float)))
                    {

                        axisProperty.FindPropertyRelative(field.Name).floatValue = (float)field.GetValue(axis);

                    }
                    else if (field.FieldType.Equals(typeof(int)))
                    {

                        axisProperty.FindPropertyRelative(field.Name).intValue = (int)field.GetValue(axis);

                    }
                    else if (field.FieldType.Equals(typeof(bool)))
                    {

                        axisProperty.FindPropertyRelative(field.Name).boolValue = (bool)field.GetValue(axis);

                    }

                }

                serializedObject.ApplyModifiedProperties();

            }

        }

    }

}

#endif
