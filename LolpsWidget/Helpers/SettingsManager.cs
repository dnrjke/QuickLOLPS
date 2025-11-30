using System;
using System.IO;
using Newtonsoft.Json;

namespace LolpsWidget.Helpers
{
    /// <summary>
    /// 위젯 위치 및 상태를 저장/복원하는 설정 관리자
    /// </summary>
    public class SettingsManager
    {
        private static readonly string SettingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "LolpsWidget",
            "settings.json"
        );

        /// <summary>
        /// 위치 정보를 저장합니다.
        /// </summary>
        public static void SavePosition(PersistedPosition position)
        {
            try
            {
                var directory = Path.GetDirectoryName(SettingsPath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var json = JsonConvert.SerializeObject(position, Formatting.Indented);
                File.WriteAllText(SettingsPath, json);
            }
            catch (Exception ex)
            {
                // TODO: 로깅 추가
                System.Diagnostics.Debug.WriteLine($"Settings save failed: {ex.Message}");
            }
        }

        /// <summary>
        /// 저장된 위치 정보를 불러옵니다.
        /// </summary>
        public static PersistedPosition? LoadPosition()
        {
            try
            {
                if (!File.Exists(SettingsPath))
                {
                    return null;
                }

                var json = File.ReadAllText(SettingsPath);
                return JsonConvert.DeserializeObject<PersistedPosition>(json);
            }
            catch (Exception ex)
            {
                // TODO: 로깅 추가
                System.Diagnostics.Debug.WriteLine($"Settings load failed: {ex.Message}");
                return null;
            }
        }
    }

    /// <summary>
    /// 저장된 위치 정보 모델
    /// </summary>
    public class PersistedPosition
    {
        /// <summary>
        /// 모니터 ID (예: "\\.\DISPLAY1")
        /// </summary>
        public string MonitorId { get; set; } = string.Empty;

        /// <summary>
        /// X 좌표
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// Y 좌표
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// 너비
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 높이
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 창 상태 (Expanded/Collapsed)
        /// </summary>
        public string WindowState { get; set; } = "Collapsed";
    }
}
