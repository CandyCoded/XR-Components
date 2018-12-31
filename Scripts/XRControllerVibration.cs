using UnityEngine;
using UnityEngine.XR;

namespace CandyCoded.XRComponents
{

    public static class XRControllerVibratation
    {

        public static void VibrateController(this XRNode node, float seconds, float amplitude)
        {

            var hapticCapabilities = new HapticCapabilities();

            if (InputDevices.GetDeviceAtXRNode(node).TryGetHapticCapabilities(out hapticCapabilities))
            {

                if (hapticCapabilities.supportsBuffer)
                {

                    var buffer = GenerateHapticBufferWithAmplitude(seconds, amplitude, hapticCapabilities.bufferFrequencyHz);

                    InputDevices.GetDeviceAtXRNode(node).SendHapticBuffer(0, buffer);

                }

            }

        }

        public static void VibrateController(this XRNode node, float seconds, AnimationCurve animationCurve)
        {

            var hapticCapabilities = new HapticCapabilities();

            if (InputDevices.GetDeviceAtXRNode(node).TryGetHapticCapabilities(out hapticCapabilities))
            {

                if (hapticCapabilities.supportsBuffer)
                {

                    var buffer = GenerateHapticBufferFromAnimationCuve(animationCurve, hapticCapabilities.bufferFrequencyHz);

                    InputDevices.GetDeviceAtXRNode(node).SendHapticBuffer(0, buffer);

                }

            }

        }

        public static byte[] GenerateHapticBufferWithAmplitude(float seconds, float amplitude, uint bufferFrequencyHz)
        {

            var amplitudeByteValue = (byte)Mathf.Lerp(byte.MinValue, byte.MaxValue, Mathf.InverseLerp(0, 1, Mathf.Clamp01(amplitude)));

            var clip = new byte[(int)(bufferFrequencyHz * seconds)];

            for (int i = 0; i < clip.Length; i += 1)
            {
                clip[i] = amplitudeByteValue;
            }

            return clip;

        }

        public static byte[] GenerateHapticBufferFromAnimationCuve(AnimationCurve animationCurve, uint bufferFrequencyHz)
        {

            var seconds = animationCurve.keys[animationCurve.length - 1].time;

            var clip = new byte[(int)(bufferFrequencyHz * seconds)];

            for (int i = 0; i < clip.Length; i += 1)
            {
                clip[i] = (byte)Mathf.Lerp(byte.MinValue, byte.MaxValue, animationCurve.Evaluate(Mathf.InverseLerp(0, clip.Length, i)));
            }

            return clip;

        }

    }

}
