using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

using ScreenRecorderLib;

namespace BasicScreenRecorder;

public partial class MainWindow : Window
{
    Recorder _rec;

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
        _rec = Recorder.CreateRecorder();
        _rec.Record(videoPath);
    }

    private void StopRecordingButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _rec.Stop();
    }
}