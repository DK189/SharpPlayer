using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    public partial class AudioPlayer : IPlayerControl
    {
        protected override void LoadCacheData()
        {
            if (_MediaUri != null)
            {
                PlayerInstance.SetMediaUri(_MediaUri);
            }
            if (_Position != -1)
            {
                PlayerInstance.Position = _Position;
            }
            if (_Volume != -1)
            {
                PlayerInstance.Volume = _Volume;
            }
        }

        private Uri _MediaUri;
        private long _Position;
        private int _Volume;

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
