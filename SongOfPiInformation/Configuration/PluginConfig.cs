using System;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace SongOfPiInformation.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool Enable { get; set; } = true;
        public virtual bool LockPosition { get; set; } = false;
        public virtual bool ChangeScale { get; set; } = false;
        public virtual float ScreenScale { get; set; } = 0.02f;
        public virtual float SuujiTextSpaceHeight { get; set; } = 25f;
        public virtual float SuujiTextSpaceWidth { get; set; } = 180f;
        public virtual float KetaTextSpaceHeight { get; set; } = 25f;
        public virtual float KetaTextSpaceWidth { get; set; } = 140f;
        public virtual int PiImaFontSize { get; set; } = 20;
        public virtual int PiNokoriFontSize { get; set; } = 15;
        public virtual int PiSuujiZengoFontSize { get; set; } = 18;
        public virtual int PiSuujiImaFontSize { get; set; } = 60;
        public virtual float ScreenPosX { get; set; } = 0f;
        public virtual float ScreenPosY { get; set; } = 2.5f;
        public virtual float ScreenPosZ { get; set; } = 8f;
        public virtual float ScreenRotX { get; set; } = 0f;
        public virtual float ScreenRotY { get; set; } = 0f;
        public virtual float ScreenRotZ { get; set; } = 0f;

        public event Action<PluginConfig> OnReloaded;
        public event Action<PluginConfig> OnChenged;
        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
            this.OnReloaded?.Invoke(this);
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
            this.OnChenged?.Invoke(this);
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
            this.Enable = other.Enable;
            this.LockPosition = other.LockPosition;
            this.ChangeScale = other.ChangeScale;
            this.ScreenScale = other.ScreenScale;
            this.SuujiTextSpaceWidth = other.SuujiTextSpaceWidth;
            this.SuujiTextSpaceHeight = other.SuujiTextSpaceHeight;
            this.KetaTextSpaceWidth = other.KetaTextSpaceWidth;
            this.KetaTextSpaceHeight = other.KetaTextSpaceHeight;
            this.PiImaFontSize = other.PiImaFontSize;
            this.PiNokoriFontSize = other.PiNokoriFontSize;
            this.PiSuujiZengoFontSize = other.PiSuujiZengoFontSize;
            this.PiSuujiImaFontSize = other.PiSuujiImaFontSize;
            this.ScreenPosX = other.ScreenPosX;
            this.ScreenPosY = other.ScreenPosY;
            this.ScreenPosZ = other.ScreenPosZ;
            this.ScreenRotX = other.ScreenRotX;
            this.ScreenRotY = other.ScreenRotY;
            this.ScreenRotZ = other.ScreenRotZ;
        }
    }
}