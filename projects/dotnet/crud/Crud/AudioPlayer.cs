namespace Crud
{
    //Client Class
    public class AudioPlayer : IMediaPlayer
    {
        private MediaAdapter mediaAdapter;

        public void Play(string audioType, string fileName)
        {
            if (audioType.Equals("mp3", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Playing MP3 file: " + fileName);
            }
            else if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase) || audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.Play(audioType, fileName);
            }
            else
            {
                Console.WriteLine("Invalid media type: " + audioType);
            }
        }
    }

}
