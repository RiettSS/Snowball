using Firebase.Analytics;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    private void Awake()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
    }
}
