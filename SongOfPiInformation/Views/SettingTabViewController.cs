﻿using SongOfPiInformation.Configuration;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace SongOfPiInformation.Views
{
    [HotReload]
    internal class SettingTabViewController : BSMLAutomaticViewController, IInitializable
    {
        public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);
        [UIValue("enable")]
        public bool Enable
        {
            get => PluginConfig.Instance.Enable;
            set => PluginConfig.Instance.Enable = value;
        }

        [UIValue("postion-lock")]
        public bool PositionLovk
        {
            get => PluginConfig.Instance.LockPosition;
            set => PluginConfig.Instance.LockPosition = value;
        }

        protected override void OnDestroy()
        {
            GameplaySetup.instance.RemoveTab("Song of PI Information");
            base.OnDestroy();
        }

        public void Initialize()
        {
            GameplaySetup.instance.AddTab("Song of PI Information", this.ResourceName, this);
        }

        [UIAction("reset-position")]
        private void ResetPositionAndRotation()
        {
            PluginConfig.Instance.ScreenPosX = 0f;
            PluginConfig.Instance.ScreenPosY = 2.5f;
            PluginConfig.Instance.ScreenPosZ = 8f;

            PluginConfig.Instance.ScreenRotX = 0f;
            PluginConfig.Instance.ScreenRotY = 0f;
            PluginConfig.Instance.ScreenRotZ = 0f;
        }
    }
}