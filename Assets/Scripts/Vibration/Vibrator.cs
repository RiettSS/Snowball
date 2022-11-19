using UnityEngine;

namespace Vibration
{
    public static class Vibrator
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        #else
        public static AndroidJavaClass unityPlayer;
        public static AndroidJavaObject currentActivity;
        public static AndroidJavaObject vibrator;
        #endif

        private static bool _vibrationEnabled = true;

        public static void Vibrate(long milliseconds = 100)
        {
            if (!_vibrationEnabled)
                return;
            
            if (IsAndroid())
            {
                vibrator.Call("vibrate", milliseconds);
            }
            else
            {
                Handheld.Vibrate();
            }
        }

        public static void TurnOn()
        {
            _vibrationEnabled = true;
        }

        public static void TurnOff()
        {
            _vibrationEnabled = false;
        }
        
        private static void Cancel()
        {
            if (IsAndroid())
            {
                vibrator.Call("cancel");
            }
        }

        private static bool IsAndroid()
        {
            #if UNITY_ANDROID && !UNITY_EDITOR
                return true;
            #else
                return false;
            #endif
        }
    }
}