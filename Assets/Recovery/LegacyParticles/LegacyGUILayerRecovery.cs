using UnityEngine;
namespace CartoonRacerRecovery {
// Source had four legacy GUILayers but zero native GUIText/GUITexture objects.
// Unity2023 no longer needs that camera component for OnGUI/Canvas rendering.
public sealed class LegacyGUILayerRecovery : MonoBehaviour {
 [HideInInspector] public string sourceYamlBase64;
}
}
