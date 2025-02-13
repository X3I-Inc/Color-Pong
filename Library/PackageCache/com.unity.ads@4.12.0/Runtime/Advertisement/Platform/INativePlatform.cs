using UnityEngine.Advertisements.Platform;

namespace UnityEngine.Advertisements
{
    internal interface INativePlatform
    {
        void SetupPlatform(IPlatform platform);
        void Initialize(string gameId, bool testMode, IUnityAdsInitializationListener initializationListener);
        void Load(string placementId, LoadOptions loadOptions, IUnityAdsLoadListener loadListener);
        void Show(string placementId, string objectId, IUnityAdsShowListener showListener);
        void SetMetaData(MetaData metaData);
        bool GetDebugMode();
        void SetDebugMode(bool debugMode);
        string GetVersion();
        bool IsInitialized();
    }
}
