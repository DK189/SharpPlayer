using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    public partial class AudioPlayer : IPlayerControl
    {
        protected void LoadCacheData()
        {
            MediaUri = _MediaUri;
            Position = _Position;
            Volume = _Volume;
            if (_Mute.HasValue)
            {
                Mute = _Mute.Value;
            }
        }

        private Uri _MediaUri;
        private long _Position;
        private int _Volume;
        private bool? _Mute = null;

        public Uri MediaUri
        {
            get
            {
                return _MediaUri;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                _MediaUri = value;
                PlayerInstance.SetMediaUri(_MediaUri);
            }
        }

        public long Position
        {
            get
            {
                return PlayerInstance == null ? 0 : PlayerInstance.Position;
            }
            set
            {
                if (PlayerInstance == null)
                {
                    return;
                }
                _Position = value;
                PlayerInstance.Position = _Position;
            }
        }
        public long Duration
        {
            get
            {
                return PlayerInstance == null ? 0 : PlayerInstance.Duration;
            }
        }

        public int Volume
        {
            get
            {
                return PlayerInstance == null ? 0 : PlayerInstance.Volume;
            }
            set
            {
                if (PlayerInstance == null)
                {
                    return;
                }
                _Volume = value;
                PlayerInstance.Volume = _Volume;
            }
        }

        public bool Mute
        {
            get
            {
                return PlayerInstance == null ? false : PlayerInstance.Mute;
            }
            set
            {
                _Mute = value;
                PlayerInstance.Mute = _Mute.Value;
            }
        }

        public void Play()
        {
            PlayerInstance.Play();
        }

        public void Pause()
        {
            PlayerInstance.Pause();
        }

        public void Stop()
        {
            PlayerInstance.Stop();
        }
    }
}
