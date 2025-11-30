using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using LolpsWidget.Models;

namespace LolpsWidget.ViewModels
{
    /// <summary>
    /// 메인 ViewModel
    /// 검색 쿼리 및 챔피언 데이터 관리
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string searchQuery = string.Empty;

        [ObservableProperty]
        private ObservableCollection<ChampionModel> champions = new();

        public MainViewModel()
        {
            // 초기 데이터 로드 (추후 실제 API 또는 데이터 소스로 대체)
            LoadSampleChampions();
        }

        /// <summary>
        /// 샘플 챔피언 데이터 로드
        /// </summary>
        private void LoadSampleChampions()
        {
            // TODO: 실제 lol.ps API 또는 Riot API를 통한 데이터 로드
            Champions.Add(new ChampionModel { Name = "가렌", Role = "탑" });
            Champions.Add(new ChampionModel { Name = "럭스", Role = "미드" });
            Champions.Add(new ChampionModel { Name = "아리", Role = "미드" });
            Champions.Add(new ChampionModel { Name = "징크스", Role = "원딜" });
            Champions.Add(new ChampionModel { Name = "쓰레쉬", Role = "서포터" });
        }

        /// <summary>
        /// 검색 실행 명령
        /// </summary>
        [RelayCommand]
        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                return;
            }

            // TODO: WebView2를 통한 검색 실행
            string searchUrl = $"https://lol.ps/summoner/search/?q={System.Uri.EscapeDataString(SearchQuery)}";
        }

        /// <summary>
        /// 챔피언 상세 열람 명령
        /// </summary>
        [RelayCommand]
        private void OpenChampion(string championName)
        {
            if (string.IsNullOrWhiteSpace(championName))
            {
                return;
            }

            // TODO: ChampionDetailPopup 열기 또는 WebView2로 챔피언 페이지 로드
            string championUrl = $"https://lol.ps/champions/{championName.ToLower()}";
        }
    }
}
