using System;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    private void Start()
    {
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLogin);
    }
}
