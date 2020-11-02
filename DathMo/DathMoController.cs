using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using DathMo.Views;
using HMUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DathMo
{
    /// <summary>
    /// Monobehaviours (scripts) are added to GameObjects.
    /// For a full list of Messages a Monobehaviour can receive from the game, see https://docs.unity3d.com/ScriptReference/MonoBehaviour.html.
    /// </summary>
    public class DathMoController : MonoBehaviour, IInitializable
    {
        [Inject]
        StaffView _staffView;
        FloatingScreen _floatingScreen;
        CurvedCanvasSettings _curvedCanvasSettings;
        CurvedCanvasSettingsHelper _curvedCanvasSettingsHelper = new CurvedCanvasSettingsHelper();

        static readonly string _textFile = Path.Combine(Environment.CurrentDirectory, "UserData", "DathMo", "Staff.txt");
        // These methods are automatically called by Unity, you should remove any you aren't using.
        #region Monobehaviour Messages
        void FixedUpdate()
        {
            this._floatingScreen.transform.position = new Vector3(0f, 0.2f, (float)(this._floatingScreen.transform.position.z + 0.022));
        }
        public void Initialize()
        {
            Plugin.Log.Debug("Inisialize call");
            this._floatingScreen = FloatingScreen.CreateFloatingScreen(new Vector2(1000f, 8000f), false, new Vector3(0f, 0.2f, -50f), Quaternion.Euler(90f, 0f, 0f));
            this._floatingScreen.SetRootViewController(_staffView, HMUI.ViewController.AnimationType.None);
            this._curvedCanvasSettings = this._curvedCanvasSettingsHelper.GetCurvedCanvasSettings(this._floatingScreen.gameObject.GetComponent<Canvas>());
            this._curvedCanvasSettings.SetRadius(0f);
            if (!Directory.Exists(Path.GetDirectoryName(_textFile))) {
                Directory.CreateDirectory(Path.GetDirectoryName(_textFile));
                using (var _ = File.Create(_textFile)) {

                }
            }
            this._staffView.SetText(File.ReadAllText(_textFile));
        }
        #endregion
    }
}
