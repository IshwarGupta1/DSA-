using Crud;


//Concrete Adaptee Class
public class VlcPlayer : IAdvancedMediaPlayer
{
    public void PlayVlc(string fileName)
    {
        Console.WriteLine("Playing VLC file: " + fileName);
    }

    public void PlayMp4(string fileName)
    {
        // Do nothing
    }
}