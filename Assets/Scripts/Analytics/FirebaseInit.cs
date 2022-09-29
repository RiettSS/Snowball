using Firebase.Analytics;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    private void Start()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
    }
}
