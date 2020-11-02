using System;
using System.Collections.Generic;
using System.Linq;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using IPA.Utilities;
using UnityEngine;
using Zenject;

namespace DathMo.Views
{
    [HotReload]
    internal class StaffView : BSMLAutomaticViewController
    {
        // For this method of setting the ResourceName, this class must be the first class in the file.
        //public override string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);

        #region member
        CurvedTextMeshPro _curvedTextMeshPro;
        CurvedCanvasSettingsHelper _curvedCanvasSettingsHelper = new CurvedCanvasSettingsHelper();
        #endregion

        #region UnityMethods
        void Awake()
        {
            this._curvedTextMeshPro = Utility.CreateText(this.rectTransform, "test message", new Vector2(0.5f, 0.5f), new Vector2(60f, 12000f));
            this._curvedTextMeshPro.fontSize = 40;
            this._curvedTextMeshPro.alignment = TMPro.TextAlignmentOptions.Midline;
            this._curvedTextMeshPro.overflowMode = TMPro.TextOverflowModes.Overflow;
            this._curvedCanvasSettingsHelper.GetCurvedCanvasSettings(this._curvedTextMeshPro.canvas).SetRadius(0f);
        }
        #endregion

        public void SetText(string value)
        {
            this._curvedTextMeshPro.text = value;
        }
    }
}
