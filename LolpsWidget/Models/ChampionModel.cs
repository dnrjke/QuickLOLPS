namespace LolpsWidget.Models
{
    /// <summary>
    /// 챔피언 모델
    /// </summary>
    public class ChampionModel
    {
        /// <summary>
        /// 챔피언 이름
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 챔피언 역할 (탑, 정글, 미드, 원딜, 서포터)
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// 챔피언 이미지 경로
        /// </summary>
        public string? ImagePath { get; set; }

        /// <summary>
        /// 챔피언 상세 페이지 URL
        /// </summary>
        public string? DetailUrl { get; set; }
    }
}
