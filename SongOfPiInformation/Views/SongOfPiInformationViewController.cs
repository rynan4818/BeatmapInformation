using SongOfPiInformation.Configuration;
using SongOfPiInformation.Models;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.FloatingScreen;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using IPA.Utilities;
using SongCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using VRUIControls;
using Zenject;
using System.Collections.Concurrent;

namespace SongOfPiInformation.Views
{
    [HotReload]
    public class SongOfPiInformationViewController : BSMLAutomaticViewController
    {
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // プロパティ
        // For this method of setting the ResourceName, this class must be the first class in the file.
        //public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);

        /// <summary>πの現在数字スペースの高さ を取得、設定</summary>
        private float suujiTextSpaceHeight_;
        [UIValue("suuji-text-height")]
        /// <summary>πの現在数字スペースの高さ を取得、設定</summary>
        public float suujiTextSpaceHeight {
            get => this.suujiTextSpaceHeight_;

            set => this.SetProperty(ref this.suujiTextSpaceHeight_, value);
        }

        /// <summary>πの現在数字スペースの幅 を取得、設定</summary>
        private float suujiTextSpaceWidth_;
        [UIValue("suuji-text-witdh")]
        /// <summary>πの現在数字スペースの幅 を取得、設定</summary>
        public float suujiTextSpaceWidth {
            get => this.suujiTextSpaceWidth_;

            set => this.SetProperty(ref this.suujiTextSpaceWidth_, value);
        }

        /// <summary>πの桁表示スペースの高さ を取得、設定</summary>
        private float ketaTextSpaceHeight_;
        [UIValue("keta-text-height")]
        /// <summary>πの桁表示スペースの高さ を取得、設定</summary>
        public float ketaTextSpaceHeight {
            get => this.ketaTextSpaceHeight_;

            set => this.SetProperty(ref this.ketaTextSpaceHeight_, value);
        }

        /// <summary>πの桁表示スペースの幅 を取得、設定</summary>
        private float ketaTextSpaceWidth_;
        [UIValue("keta-text-witdh")]
        /// <summary>πの桁表示スペースの幅 を取得、設定</summary>
        public float ketaTextSpaceWidth {
            get => this.ketaTextSpaceWidth_;

            set => this.SetProperty(ref this.ketaTextSpaceWidth_, value);
        }

        /// <summary>πの現在の桁のフォントサイズ を取得、設定</summary>
        private int piImaFontSize_;
        [UIValue("pi-ima-fontsize")]
        /// <summary>πの現在の桁のフォントサイズ を取得、設定</summary>
        public int piImaFontSize {
            get => this.piImaFontSize_;

            set => this.SetProperty(ref this.piImaFontSize_, value);
        }

        /// <summary>πの残りの桁のフォントサイズ を取得、設定</summary>
        private int piNokoriFontSize_;
        [UIValue("pi-nokori-fontsize")]
        /// <summary>πの残りの桁のフォントサイズ を取得、設定</summary>
        public int piNokoriFontSize {
            get => this.piNokoriFontSize_;

            set => this.SetProperty(ref this.piNokoriFontSize_, value);
        }

        /// <summary>πの現在数字前後のフォントサイズ を取得、設定</summary>
        private int piSuujiZengoFontSize_;
        [UIValue("pi-suuji-zengo-fontsize")]
        /// <summary>πの現在数字前後のフォントサイズ を取得、設定</summary>
        public int piSuujiZengoFontSize {
            get => this.piSuujiZengoFontSize_;

            set => this.SetProperty(ref this.piSuujiZengoFontSize_, value);
        }

        /// <summary>πの現在数字のフォントサイズ を取得、設定</summary>
        private int piSuujiImaFontSize_;
        [UIValue("pi-suuji-ima-fontsize")]
        /// <summary>πの現在数字のフォントサイズ を取得、設定</summary>
        public int piSuujiImaFontSize {
            get => this.piSuujiImaFontSize_;

            set => this.SetProperty(ref this.piSuujiImaFontSize_, value);
        }

        /// <summary>πの現在の桁を取得、設定</summary>
        private string piIma_;
        [UIValue("pi-ima")]
        /// <summary>πの現在の桁を取得、設定</summary>
        public string piIma {
            get => this.piIma_ ?? "";

            set => this.SetProperty(ref this.piIma_, value);
        }

        /// <summary>πの残りの桁を取得、設定</summary>
        private string piNokori_;
        [UIValue("pi-nokori")]
        /// <summary>πの残りの桁を取得、設定</summary>
        public string piNokori {
            get => this.piNokori_ ?? "";

            set => this.SetProperty(ref this.piNokori_, value);
        }

        /// <summary>πの現在数字前方を取得、設定</summary>
        private string piSuujiMae_;
        [UIValue("pi-suuji-mae")]
        /// <summary>πの現在数字前方を取得、設定</summary>
        public string piSuujiMae {
            get => this.piSuujiMae_ ?? "";

            set => this.SetProperty(ref this.piSuujiMae_, value);
        }

        /// <summary>πの現在数字を取得、設定</summary>
        private string piSuujiIma_;
        [UIValue("pi-suuji-ima")]
        /// <summary>πの現在数字を取得、設定</summary>
        public string piSuujiIma {
            get => this.piSuujiIma_ ?? "";

            set => this.SetProperty(ref this.piSuujiIma_, value);
        }

        /// <summary>πの現在数字後方を取得、設定</summary>
        private string piSuujiUshiro_;
        [UIValue("pi-suuji-ushiro")]
        /// <summary>πの現在数字後方を取得、設定</summary>
        public string piSuujiUshiro {
            get => this.piSuujiUshiro_ ?? "";

            set => this.SetProperty(ref this.piSuujiUshiro_, value);
        }

        #endregion
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // Unity Message
#if DEBUG
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) {
                HMMainThreadDispatcher.instance.Enqueue(this.SetCover(this._coverSprite));
            }
        }
#endif
        private IEnumerator Start()
        {
            if (!PluginConfig.Instance.Enable) {
                yield break;
            }
            yield return new WaitWhile(() => this._informationScreen == null || !this._informationScreen);
            this._informationScreen.ShowHandle = false;
#if !DEBUG
            // GameCore中のVRPointerはメニュー画面でのVRpointerと異なるのでもう一度セットしなおす必要がある。
            if (this._pointer.gameObject.GetComponent<FloatingScreenMoverPointer>() == null) {
                var mover = this._pointer.gameObject.AddComponent<FloatingScreenMoverPointer>();
                Destroy(this._informationScreen.screenMover);
                this._informationScreen.screenMover = mover;
            }
            else {
                var mover = this._pointer.gameObject.GetComponent<FloatingScreenMoverPointer>();
                Destroy(this._informationScreen.screenMover);
                this._informationScreen.screenMover = mover;
            }
            this._informationScreen.screenMover.Init(this._informationScreen);
            this._informationScreen.screenMover.enabled = false;
#endif
        }

        protected override void OnDestroy()
        {
            Logger.Debug("OnDestroy call");
            if (this.piFlag) {
                this._pauseController.didPauseEvent -= this.OnDidPauseEvent;
                this._pauseController.didResumeEvent -= this.OnDidResumeEvent;
                PluginConfig.Instance.OnReloaded -= this.OnReloaded;
                PluginConfig.Instance.OnChenged -= this.OnChenged;
                if (this._informationScreen != null) {
                    this._informationScreen.HandleGrabbed -= this.OnHandleGrabbed;
                    this._informationScreen.HandleReleased -= this.OnHandleReleased;
                    Destroy(this._informationScreen);
                }
                this._scoreController.noteWasCutEvent -= this.OnNoteWasCut;
                this._scoreController.noteWasMissedEvent -= this.OnNoteWasMissed;
                // Clear note id mappings.
                noteToIdMapping?.Clear();
            }
            base.OnDestroy();
        }
        #endregion
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // オーバーライドメソッド
        #endregion
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // パブリックメソッド
        #endregion
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // プライベートメソッド
        /// <summary>
        /// ノーツがカットされたときに呼び出されます。
        /// </summary>
        /// <param name="noteData"></param>
        /// <param name="noteCutInfo"></param>
        /// <param name="multiplier"></param>
        public void OnNoteWasCut(NoteData noteData,in NoteCutInfo noteCutInfo, int multiplier)
        {
            PiUpdate(this.SearchNoteID(noteData));
        }

        /// <summary>
        /// ノーツを見逃したときに呼び出されます
        /// </summary>
        /// <param name="noteData"></param>
        /// <param name="multiplier"></param>
        public void OnNoteWasMissed(NoteData noteData, int multiplier)
        {
            PiUpdate(this.SearchNoteID(noteData));
        }

        /// <summary>
        /// noteDataからnoteIDを探します
        /// </summary>
        /// <param name="noteData"></param>
        /// <returns></returns>
        private int SearchNoteID(NoteData noteData)
        {
            if (this.noteToIdMapping.TryRemove(new NoteDataEntity(noteData, this.noArrows), out var id)) {
                if (lastNoteId < id) {
                    lastNoteId = id;
                }
                return id;
            }
            else {
                return lastNoteId;
            }
        }

        /// <summary>
        /// π表示を更新します。
        /// </summary>
        /// <param name="id"></param>
        private void PiUpdate(int id)
        {
            var piIndex = this.piData.noteList[id];
            var piList = PiData.piList;
            int piDigit = 10238;
            int piNow = 0;
            if (piIndex > 1) {
                piDigit = 10238 - piIndex + 1;
                piNow = piIndex - 1;
            }
            this.piIma = $"{piNow}桁";
            this.piNokori = $"(あと{piDigit}桁)";
            this.piSuujiMae = $"{(piIndex - 10 >= 0 ? piList.Substring(piIndex - 10, 1) : " ")}{(piIndex - 9 >= 0 ? piList.Substring(piIndex - 9, 1) : " ")}{(piIndex - 8 >= 0 ? piList.Substring(piIndex - 8, 1) : " ")}{(piIndex - 7 >= 0 ? piList.Substring(piIndex - 7, 1) : " ")}{(piIndex - 6 >= 0 ? piList.Substring(piIndex - 6, 1) : " ")}{(piIndex - 5 >= 0 ? piList.Substring(piIndex - 5, 1) : " ")}{(piIndex - 4 >= 0 ? piList.Substring(piIndex - 4, 1) : " ")}{(piIndex - 3 >= 0 ? piList.Substring(piIndex - 3, 1) : " ")}{(piIndex - 2 >= 0 ? piList.Substring(piIndex - 2, 1) : " ")}{(piIndex - 1 >= 0 ? piList.Substring(piIndex - 1, 1) : " ")}";
            this.piSuujiIma = $"{piList.Substring(piIndex, 1)}";
            this.piSuujiUshiro = $"{(piIndex + 1 <= 10239 ? piList.Substring(piIndex + 1, 1) : " ")}{(piIndex + 2 <= 10239 ? piList.Substring(piIndex + 2, 1) : " ")}{(piIndex + 3 <= 10239 ? piList.Substring(piIndex + 3, 1) : " ")}{(piIndex + 4 <= 10239 ? piList.Substring(piIndex + 4, 1) : " ")}{(piIndex + 5 <= 10239 ? piList.Substring(piIndex + 5, 1) : " ")}{(piIndex + 6 <= 10239 ? piList.Substring(piIndex + 6, 1) : " ")}{(piIndex + 7 <= 10239 ? piList.Substring(piIndex + 7, 1) : " ")}{(piIndex + 8 <= 10239 ? piList.Substring(piIndex + 8, 1) : " ")}{(piIndex + 9 <= 10239 ? piList.Substring(piIndex + 9, 1) : " ")}{(piIndex + 10 <= 10239 ? piList.Substring(piIndex + 10, 1) : " ")}";
        }

        private IEnumerator CanvasConfigUpdate()
        {
            yield return new WaitWhile(() => this._informationScreen == null || !this._informationScreen);
            try {
                var coreGameHUDController = Resources.FindObjectsOfTypeAll<CoreGameHUDController>().FirstOrDefault();
                if (coreGameHUDController != null) {
                    var energyGo = coreGameHUDController.GetField<GameObject, CoreGameHUDController>("_energyPanelGO");
                    var energyCanvas = energyGo.GetComponent<Canvas>();
                    foreach (var canvas in this._informationScreen.GetComponentsInChildren<Canvas>()) {
                        canvas.overrideSorting = energyCanvas.overrideSorting;
                        canvas.sortingLayerID = energyCanvas.sortingLayerID;
                        canvas.sortingLayerName = energyCanvas.sortingLayerName;
                        canvas.sortingOrder = energyCanvas.sortingOrder;
                        canvas.gameObject.layer = energyCanvas.gameObject.layer;
                    }
                }
            }
            catch (Exception e) {
                Logger.Error(e);
            }
        }

        private void OnDidResumeEvent()
        {
            if (this._informationScreen == null) {
                return;
            }
            this._informationScreen.ShowHandle = false;
            this._informationScreen.screenMover.enabled = false;
        }

        private void OnDidPauseEvent()
        {
            if (PluginConfig.Instance.LockPosition || this._informationScreen == null) {
                return;
            }
            this._informationScreen.ShowHandle = true;
            this._informationScreen.screenMover.enabled = true;
        }

        private void OnChenged(PluginConfig obj)
        {
            this.SetConfigValue(obj);
        }

        private void OnReloaded(PluginConfig obj)
        {
            this.SetConfigValue(obj);
        }

        private void SetConfigValue(PluginConfig p)
        {
            this.suujiTextSpaceHeight = p.SuujiTextSpaceHeight;
            this.suujiTextSpaceWidth  = p.SuujiTextSpaceWidth;
            this.ketaTextSpaceHeight  = p.KetaTextSpaceHeight;
            this.ketaTextSpaceWidth   = p.KetaTextSpaceWidth;
            this.piImaFontSize        = p.PiImaFontSize;
            this.piNokoriFontSize     = p.PiNokoriFontSize;
            this.piSuujiZengoFontSize = p.PiSuujiZengoFontSize;
            this.piSuujiImaFontSize   = p.PiSuujiImaFontSize;

            if (this._informationScreen == null || !this._informationScreen) {
                return;
            }
            lock (_lockObject) {
                this._informationScreen.transform.position = new Vector3(p.ScreenPosX, p.ScreenPosY, p.ScreenPosZ);
                this._informationScreen.transform.rotation = Quaternion.Euler(p.ScreenRotX, p.ScreenRotY, p.ScreenRotZ);
                if (PluginConfig.Instance.ChangeScale) {
                    this._informationScreen.transform.localScale = Vector3.one * PluginConfig.Instance.ScreenScale;
                }
            }
        }

        private void OnHandleReleased(object sender, FloatingScreenHandleEventArgs e)
        {
            Logger.Debug($"Handle Released");
            lock (_lockObject) {
                PluginConfig.Instance.ScreenPosX = e.Position.x;
                PluginConfig.Instance.ScreenPosY = e.Position.y;
                PluginConfig.Instance.ScreenPosZ = e.Position.z;

                var rot = e.Rotation.eulerAngles;

                PluginConfig.Instance.ScreenRotX = rot.x;
                PluginConfig.Instance.ScreenRotY = rot.y;
                PluginConfig.Instance.ScreenRotZ = rot.z;
            }
        }

        private void OnHandleGrabbed(object sender, FloatingScreenHandleEventArgs e)
        {
            Logger.Debug($"Handle Grabbed");
        }

        /// <summary>
        /// プロパティへ値をセットし、Viewへ通知します
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="property">プロパティ用変数</param>
        /// <param name="value">更新する値</param>
        /// <param name="membername">このメソッドを呼んだメンバーの名前（自動挿入なので指定する必要なし）</param>
        /// <returns>変更があったかどうか</returns>
        private bool SetProperty<T>(ref T property, T value, [CallerMemberName]string membername = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value)) {
                return false;
            }
            property = value;
            this.OnPropertyChanged(membername);
            return true;
        }

        /// <summary>
        /// プロパティの変更があったときに呼び出されます。Viewへの通知をここでキャンセルできます。
        /// </summary>
        /// <param name="propertyName">呼び出されたプロパティ名</param>
        private void OnPropertyChanged(string propertyName)
        {
            HMMainThreadDispatcher.instance?.Enqueue(() =>
            {
                this.NotifyPropertyChanged(propertyName);
            });
        }
        #endregion
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // メンバ変数
        private ScoreController _scoreController;
        private GameplayCoreSceneSetupData _gameplayCoreSceneSetupData;
        private FloatingScreen _informationScreen;
        private PauseController _pauseController;
        [UIComponent("cover")]
        private ImageView _cover;
        private VRPointer _pointer;
        private static readonly object _lockObject = new object();
        private ConcurrentDictionary<NoteDataEntity, int> noteToIdMapping { get; } = new ConcurrentDictionary<NoteDataEntity, int>();
        private int lastNoteId = 0;
        private bool noArrows = false;
        private PiData piData;
        private bool piFlag = false;
        #endregion
        //ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*ﾟ+｡｡+ﾟ*｡+ﾟ ﾟ+｡*
        #region // 構築・破棄
        [Inject]
        private void Constractor(ScoreController scoreController, GameplayCoreSceneSetupData gameplayCoreSceneSetupData, PauseController pauseController, VRInputModule inputModule)
        {
            Logger.Debug("Constractor call");
            this._scoreController = scoreController;
            this._gameplayCoreSceneSetupData = gameplayCoreSceneSetupData;
            this._pauseController = pauseController;
            this._pointer = inputModule.GetField<VRPointer, VRInputModule>("_vrPointer");
            if (!PluginConfig.Instance.Enable) {
                return;
            }
            var diff = this._gameplayCoreSceneSetupData.difficultyBeatmap;
            var previewBeatmapLevel = Loader.GetLevelById(diff.level.levelID);
            if (previewBeatmapLevel == null) {
                Logger.Debug("previewmap is null!");
                return;
            }
            if (previewBeatmapLevel.songName == "Song of Pi (10238 Digits Ver.)") {
                this.piFlag = true;
            }
            else {
                Logger.Debug("Not song of Pi");
                this.piFlag = false;
                return;
            }

            this._pauseController.didPauseEvent += this.OnDidPauseEvent;
            this._pauseController.didResumeEvent += this.OnDidResumeEvent;
            
            this.SetConfigValue(PluginConfig.Instance);
            this._informationScreen = FloatingScreen.CreateFloatingScreen(new Vector2(200f, 120f), true, new Vector3(PluginConfig.Instance.ScreenPosX, PluginConfig.Instance.ScreenPosY, PluginConfig.Instance.ScreenPosZ), Quaternion.Euler(0f, 0f, 0f));
            this._informationScreen.SetRootViewController(this, HMUI.ViewController.AnimationType.None);
            this._informationScreen.transform.rotation = Quaternion.Euler(PluginConfig.Instance.ScreenRotX, PluginConfig.Instance.ScreenRotY, PluginConfig.Instance.ScreenRotZ);
            if (PluginConfig.Instance.ChangeScale) {
                this._informationScreen.transform.localScale = Vector3.one * PluginConfig.Instance.ScreenScale;
            }
            this._informationScreen.HandleGrabbed += this.OnHandleGrabbed;
            this._informationScreen.HandleReleased += this.OnHandleReleased;
            HMMainThreadDispatcher.instance.Enqueue(this.CanvasConfigUpdate());
            PluginConfig.Instance.OnReloaded += this.OnReloaded;
            PluginConfig.Instance.OnChenged += this.OnChenged;

            this._scoreController.noteWasCutEvent += this.OnNoteWasCut;
            this._scoreController.noteWasMissedEvent += this.OnNoteWasMissed;
            this.noArrows = this._gameplayCoreSceneSetupData.gameplayModifiers.noArrows;
            this.noteToIdMapping.Clear();
            this.lastNoteId = 0;
            foreach (var note in diff.beatmapData.beatmapObjectsData.Where(x => x is NoteData).Select((x, i) => new { note = x, index = i })) {
                this.noteToIdMapping.TryAdd(new NoteDataEntity(note.note as NoteData, this.noArrows), note.index);
            }
            this.piData = new PiData();
            PiUpdate(0);
        }
        #endregion
    }
}
