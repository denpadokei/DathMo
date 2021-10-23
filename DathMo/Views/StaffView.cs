using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.ViewControllers;
using DathMo.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DathMo.Views
{
    [HotReload]
    internal class StaffView : BSMLAutomaticViewController, IInitializable
    {
        // For this method of setting the ResourceName, this class must be the first class in the file.
        //public override string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);

        private bool SetProperty<T>(ref T oldvalue, T newValue, [CallerMemberName] string member = null)
        {
            if (EqualityComparer<T>.Default.Equals(oldvalue, newValue)) {
                return false;
            }
            oldvalue = newValue;
            this.OnPropertyChanged(new PropertyChangedEventArgs(member));
            return true;
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e) => this.NotifyPropertyChanged(e.PropertyName);

        /// <summary>説明 を取得、設定</summary>
        private string staffText_;
        [UIValue("staff-text")]
        /// <summary>説明 を取得、設定</summary>
        public string StaffText
        {
            get => this.staffText_;

            set => this.SetProperty(ref this.staffText_, value);
        }

        public bool Enable => PluginConfig.Instance.Enable;

        #region member
        private AudioTimeSyncController audioTimeSyncController;
        private FloatingScreen _floatingScreen;
        [UIComponent("staff")]
        private readonly TextMeshProUGUI _staffText;
        [UIComponent("vertical-group")]
        private readonly VerticalLayoutGroup verticalLayoutGroup;
        private static readonly string _textFile = Path.Combine(Environment.CurrentDirectory, "UserData", "DathMo", "Staff.txt");
        private float startPosZ;
        private float endPosZ;
        private float moveLength;
        #endregion
        // These methods are automatically called by Unity, you should remove any you aren't using.
        [Inject]
        private void Constractor(AudioTimeSyncController audio) => this.audioTimeSyncController = audio;
        #region UnityMethods
        private IEnumerator Start()
        {
            if (!this.Enable) {
                yield break;
            }

            yield return new WaitWhile(() => !this.verticalLayoutGroup || !this._staffText);
            FontManager.TryGetTMPFontByFamily("Segoe UI", out var font);
            this._staffText.font = font;
            if (!Directory.Exists(Path.GetDirectoryName(_textFile))) {
                Directory.CreateDirectory(Path.GetDirectoryName(_textFile));
                using (var _ = File.Create(_textFile)) {
                }
            }
            this.SetText(File.ReadAllText(_textFile));
            Plugin.Log.Debug($"{this._staffText.preferredHeight}");
            this._floatingScreen.ScreenSize = new Vector2(50f, this._staffText.preferredHeight + 2);
            this.startPosZ = -4f - (this._floatingScreen.ScreenSize.y / 2f);
            this.endPosZ = 8f + (this._floatingScreen.ScreenSize.y / 2f);
            this.moveLength = this.endPosZ - this.startPosZ;
            this._floatingScreen.transform.position = new Vector3(0f, 0.2f, this.startPosZ);
        }

        private void Update() => this.MoveScreen();
        #endregion
        private void MoveScreen()
        {
            if (!this.Enable) {
                return;
            }
            if (this.startPosZ == 0 || this.endPosZ == 0) {
                return;
            }
            var progress = this.audioTimeSyncController.songTime / this.audioTimeSyncController.songLength;
            var diff = this.moveLength * progress;
            this._floatingScreen.ScreenPosition = new Vector3(0f, 0.2f, this.startPosZ + diff);
        }
        public void SetText(string value) => this.StaffText = value;

        public void Initialize()
        {
            if (!this.Enable) {
                return;
            }
            this._floatingScreen = FloatingScreen.CreateFloatingScreen(new Vector2(50f, 100f), false, new Vector3(0f, 0.2f, -50f), Quaternion.Euler(90f, 0f, 0f));
            this._floatingScreen.transform.localScale = Vector3.one;
            this._floatingScreen.SetRootViewController(this, AnimationType.None);
            this._floatingScreen.gameObject.layer = 0;
        }
    }
}
