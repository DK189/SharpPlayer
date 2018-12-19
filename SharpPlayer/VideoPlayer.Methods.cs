using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    public partial class VideoPlayer : IPlayerControl, IVideoPlayerControl
    {
        protected void LoadCacheData()
        {
            MediaUri = MediaUri;
            Position = Position;
            Volume = Volume;
            if (_Mute.HasValue)
            {
                Mute = _Mute.Value;
            }
        }

        private Uri _MediaUri;
        private long _Position = -1;
        private int _Volume = -1;
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

        public Size VideoSize
        {
            get
            {
                return PlayerInstance == null ? Size.Empty : VideoPlayerInstance.VideoSize;
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
                if (0 <= value && value <= 100)
                {
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Volume",
                        string.Format(
                            "Value of '{0}' is not valid for 'Volume'. 'Volume' should be between '{1}' and '{2}'.",
                            value,
                            0,
                            100
                        )
                    );
                }
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

        public void TakeSnapshot(string dst)
        {
            VideoPlayerInstance.TakeSnapshot(dst);
        }

        public Bitmap TakeSnapshot()
        {
            return VideoPlayerInstance.TakeSnapshot();
        }
    }
}
