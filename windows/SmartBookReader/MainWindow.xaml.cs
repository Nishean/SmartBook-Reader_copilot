using System.Windows;
using Microsoft.Win32;
using System.IO;
using NAudio.Wave;
using System.Threading.Tasks;

namespace SmartBookReader
{
    public partial class MainWindow : Window
    {
        private IWavePlayer wavePlayer;
        private string currentFile;
        private bool isPlaying;

        public MainWindow()
        {
            InitializeComponent();
            wavePlayer = new WaveOutEvent();
        }

        private void OnConvertButtonClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|EPUB files (*.epub)|*.epub|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                currentFile = openFileDialog.FileName;
                MessageBox.Show($"Выбран файл: {currentFile}");
                // TODO: Добавить логику конвертации
            }
        }

        private async void OnStreamButtonClick(object sender, RoutedEventArgs e)
        {
            if (currentFile == null)
            {
                MessageBox.Show("Сначала выберите файл!");
                return;
            }

            isPlaying = true;
            await StartStreaming();
        }

        private void OnPauseButtonClick(object sender, RoutedEventArgs e)
        {
            if (wavePlayer != null && isPlaying)
            {
                wavePlayer.Pause();
                isPlaying = false;
            }
        }

        private void OnResumeButtonClick(object sender, RoutedEventArgs e)
        {
            if (wavePlayer != null && !isPlaying)
            {
                wavePlayer.Play();
                isPlaying = true;
            }
        }

        private async Task StartStreaming()
        {
            try
            {
                // TODO: Добавить логику потокового воспроизведения
                await Task.Delay(100); // Заглушка
                MessageBox.Show("Начинаем воспроизведение...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
            }
            base.OnClosed(e);
        }
    }
}