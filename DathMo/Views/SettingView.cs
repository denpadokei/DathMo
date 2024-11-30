using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.Settings;
using BeatSaberMarkupLanguage.ViewControllers;
using DathMo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace DathMo.Views
{
    [HotReload]
    internal class SettingView : BSMLAutomaticViewController, IInitializable
    {
        [UIValue("enable")]
        public bool Enable
        {
            get => PluginConfig.Instance.Enable;
            set => PluginConfig.Instance.Enable = value;
        }

        // For this method of setting the ResourceName, this class must be the first class in the file.
        public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);

        public void Initialize()
        {
            GameplaySetup.Instance?.RemoveTab("DathMo");
            GameplaySetup.Instance?.AddTab("DathMo", this.ResourceName, this);
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            GameplaySetup.Instance?.RemoveTab("DathMo");
        }
    }
}
