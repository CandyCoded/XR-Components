// Copyright (c) Scott Doxey. All Rights Reserved. Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.XR;

namespace CandyCoded.XRComponents
{

    public static class XRControllerVibration
    {

        public static void VibrateController(this XRNode node, float seconds, float amplitude)
        {

            var device = InputDevices.GetDeviceAtXRNode(node);

            var hapticCapabilities = new HapticCapabilities();

            if (!device.TryGetHapticCapabilities(out hapticCapabilities))
            {
                return;
            }

            if (hapticCapabilities.supportsBuffer)
            {

                var buffer = GenerateHapticBufferWithAmplitude(seconds, amplitude, hapticCapabilities.bufferFrequencyHz);

                device.SendHapticBuffer(0, buffer);

            }
            else if (hapticCapabilities.supportsImpulse)
            {

                device.SendHapticImpulse(0, amplitude, seconds);

            }

        }

        public static void VibrateController(this XRNode node, AnimationCurve animationCurve)
        {

            var device = InputDevices.GetDeviceAtXRNode(node);

            var hapticCapabilities = new HapticCapabilities();

            if (!device.TryGetHapticCapabilities(out hapticCapabilities))
            {
                return;
            }

            if (!hapticCapabilities.supportsBuffer)
            {
                return;
            }

            var buffer = GenerateHapticBufferFromAnimationCuve(animationCurve, hapticCapabilities.bufferFrequencyHz);

            device.SendHapticBuffer(0, buffer);

        }

        public static byte[] GenerateHapticBufferWithAmplitude(float seconds, float amplitude, uint bufferFrequencyHz)
        {

            var amplitudeByteValue = (byte)Mathf.Lerp(byte.MinValue, byte.MaxValue, Mathf.InverseLerp(0, 1, Mathf.Clamp01(amplitude)));

            var clip = new byte[(int)(bufferFrequencyHz * seconds)];

            for (var i = 0; i < clip.Length; i += 1)
            {
                clip[i] = amplitudeByteValue;
            }

            return clip;

        }

        public static byte[] GenerateHapticBufferFromAnimationCuve(AnimationCurve animationCurve, uint bufferFrequencyHz)
        {

            var seconds = animationCurve.keys[animationCurve.length - 1].time;

            var clip = new byte[(int)(bufferFrequencyHz * seconds)];

            for (var i = 0; i < clip.Length; i += 1)
            {
                clip[i] = (byte)Mathf.Lerp(byte.MinValue, byte.MaxValue, animationCurve.Evaluate(Mathf.InverseLerp(0, clip.Length, i)));
            }

            return clip;

        }

    }

}
