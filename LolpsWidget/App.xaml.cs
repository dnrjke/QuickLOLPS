using System.Windows;

namespace LolpsWidget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // WebView2 런타임 초기화는 각 WebView2 컨트롤에서 처리됩니다.
            // 필요시 여기서 전역 설정을 추가할 수 있습니다.
        }
    }
}
