// See https://aka.ms/new-console-template for more information

using NAudio.Wave;

Console.WriteLine("To stop playing the song, press any key...");



foreach (var arg in args)
{
    if (File.Exists(arg))
    {
        Console.WriteLine($"Play file: {Path.GetFileName(arg)}...");
        using var audioFile = new AudioFileReader(arg);
        using var outputDevice = new WaveOutEvent();
        outputDevice.Init(audioFile);
        outputDevice.Play();
        while (outputDevice.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1000);
            if (Console.KeyAvailable)
            {
                return;
            }
        }
    }
}

