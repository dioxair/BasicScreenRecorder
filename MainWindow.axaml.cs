using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

using ScreenRecorderLib;

namespace BasicScreenRecorder;

public partial class MainWindow : Window
{
    Recorder _rec;

    // technically i COULD use this class to make the screen recorder have a whole bunch of cool stuff
    // and actually be viable for normal use, but i'm way to lazy for that (hence "BasicScreenRecorder")
    // so i'm only going to enable audio and have nothing else be accessible to the user
    private RecorderOptions _recOptions = new()
    {
        AudioOptions = new AudioOptions
        {
            Bitrate = AudioBitrate.bitrate_128kbps,
            Channels = AudioChannels.Stereo,
            IsAudioEnabled = true
        }
    };

    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartRecordingButton_OnClick(object? sender, RoutedEventArgs e)
    {
        // DateTime format example: BasicScreenRecorder-2024-08-04 14-19-24.mp4
        string videoName = $"BasicScreenRecorder-{DateTime.Now:yyyy-MM-dd H-mm-ss}.mp4";

        string videoPath =
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\BasicScreenRecorder\Videos\{videoName}";
        _rec = Recorder.CreateRecorder(_recOptions);
        _rec.Record(videoPath);
    }

    private void StopRecordingButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _rec.Stop();
    }
}