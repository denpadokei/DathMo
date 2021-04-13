using BeatSaberMarkupLanguage;
using HMUI;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DathMo
{
    public class Utility
    {
        private static TMP_FontAsset mainTextFont = null;
        /// <summary>
        /// Gets the main font used by the game for UI text.
        /// </summary>
        public static TMP_FontAsset MainTextFont
            => mainTextFont ?? (mainTextFont = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().FirstOrDefault(t => t.name == "Teko-Medium SDF No Glow"));

        private static Material _noGlow;
        public static Material UINoGlowMaterial
        {
            get
            {
                if (_noGlow == null) {
                    _noGlow = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m.name == "UINoGlow");
                    if (_noGlow != null) {
                        _noGlow = Material.Instantiate(_noGlow);
                    }
                }
                return _noGlow;
            }
        }

        private static Shader _tmpNoGlowFontShader;
        public static Shader TMPNoGlowFontShader
        {
            get
            {
                if (_tmpNoGlowFontShader == null) {
                    _tmpNoGlowFontShader = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().Last(f2 => f2.name == "Teko-Medium SDF No Glow")?.material?.shader;
                }
                return _tmpNoGlowFontShader;
            }
        }

        /// <summary>
        /// Creates a TextMeshProUGUI component.
        /// </summary>
        /// <param name="parent">The transform to parent the new TextMeshProUGUI component to.</param>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="anchoredPosition">The position the button should be anchored to.</param>
        /// <returns>The newly created TextMeshProUGUI component.</returns>
        public static CurvedTextMeshPro CreateText(RectTransform parent, string text, Vector2 anchoredPosition) => CreateText(parent, text, anchoredPosition, new Vector2(60f, 10f));

        /// <summary>
        /// Creates a TextMeshProUGUI component.
        /// </summary>
        /// <param name="parent">The transform to parent the new TextMeshProUGUI component to.</param>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="anchoredPosition">The position the text component should be anchored to.</param>
        /// <param name="sizeDelta">The size of the text components RectTransform.</param>
        /// <returns>The newly created TextMeshProUGUI component.</returns>
        public static CurvedTextMeshPro CreateText(RectTransform parent, string text, Vector2 anchoredPosition, Vector2 sizeDelta)
        {
            var gameObj = new GameObject("CustomUIText");
            gameObj.SetActive(false);
            var textMesh = gameObj.AddComponent<CurvedTextMeshPro>();
            FontManager.TryGetTMPFontByFamily("Segoe UI", out var font);
            textMesh.font = font;

            textMesh.rectTransform.SetParent(parent, false);
            textMesh.text = text;
            textMesh.fontSize = 4;
            textMesh.color = Color.white;

            textMesh.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            textMesh.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            textMesh.rectTransform.sizeDelta = sizeDelta;
            textMesh.rectTransform.anchoredPosition = anchoredPosition;
            gameObj.SetActive(true);
            return textMesh;
        }
    }
}
