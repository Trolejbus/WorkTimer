using System.Media;
using WorkTimer.Interfaces.Controllers;

namespace WorkTimer.Controllers
{
    public class MusicPlayerController : IMusicPlayerController
    {
        private SoundPlayer player;

        public void PlayAlarm()
        {
            player = new SoundPlayer(@"Media\analog-watch-sound.wav");
            player.PlayLooping();
        }

        public void StopAlarm()
        {
            player.Stop();
        }
    }
}
