using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace LolpsWidget.Views
{
    /// <summary>
    /// WidgetShell.xaml에 대한 상호 작용 논리
    /// 축소/확장 토글 및 드래그 이동 기능을 제공합니다.
    /// </summary>
    public partial class WidgetShell : Window
    {
        private bool _isExpanded = false;
        private Point _dragOffset;
        private Point _mouseDownPosition;
        private bool _isDragging = false;
        private bool _hasMoved = false;

        private const double CollapsedWidth = 60;
        private const double CollapsedHeight = 60;
        private const double ExpandedWidth = 900;
        private const double ExpandedHeight = 520;
        private const double DragThreshold = 10; // 드래그로 판단할 최소 이동 거리 (10픽셀로 증가)

        public WidgetShell()
        {
            InitializeComponent();

            // 초기 축소 상태로 설정
            CollapseImmediately();

            // Always-on-top 설정
            this.Topmost = true;

            // 듀얼 모니터 경계 내 초기 위치 설정 (추후 SettingsManager로 대체)
            this.Left = Math.Min(100, SystemParameters.PrimaryScreenWidth - CollapsedWidth);
            this.Top = Math.Min(100, SystemParameters.PrimaryScreenHeight - CollapsedHeight);
        }

        /// <summary>
        /// 애니메이션 없이 즉시 축소 상태로 전환
        /// </summary>
        private void CollapseImmediately()
        {
            this.Width = CollapsedWidth;
            this.Height = CollapsedHeight;
            CollapsedIcon.Visibility = Visibility.Visible;
            ExpandedContent.Visibility = Visibility.Collapsed;
            _isExpanded = false;
        }

        /// <summary>
        /// 애니메이션과 함께 확장 상태로 전환
        /// </summary>
        private void ExpandWithAnimation()
        {
            var wAnim = new DoubleAnimation(this.Width, ExpandedWidth, TimeSpan.FromMilliseconds(200));
            var hAnim = new DoubleAnimation(this.Height, ExpandedHeight, TimeSpan.FromMilliseconds(200));

            wAnim.Completed += (s, e) =>
            {
                CollapsedIcon.Visibility = Visibility.Collapsed;
                ExpandedContent.Visibility = Visibility.Visible;
            };

            this.BeginAnimation(Window.WidthProperty, wAnim);
            this.BeginAnimation(Window.HeightProperty, hAnim);
            _isExpanded = true;
        }

        /// <summary>
        /// 애니메이션과 함께 축소 상태로 전환
        /// </summary>
        private void CollapseWithAnimation()
        {
            CollapsedIcon.Visibility = Visibility.Visible;
            ExpandedContent.Visibility = Visibility.Collapsed;

            var wAnim = new DoubleAnimation(this.Width, CollapsedWidth, TimeSpan.FromMilliseconds(200));
            var hAnim = new DoubleAnimation(this.Height, CollapsedHeight, TimeSpan.FromMilliseconds(200));

            this.BeginAnimation(Window.WidthProperty, wAnim);
            this.BeginAnimation(Window.HeightProperty, hAnim);
            _isExpanded = false;
        }

        /// <summary>
        /// 아이콘 클릭 이벤트 - 확장 토글 (드래그 기능 비활성화)
        /// </summary>
        private void IconButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 간단한 클릭 토글
            if (!_isExpanded)
            {
                ExpandWithAnimation();
            }

            e.Handled = true;
        }

        /// <summary>
        /// 마우스 왼쪽 버튼 업 이벤트 처리 (현재 미사용)
        /// </summary>
        private void IconButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 현재는 Down에서 처리하므로 비워둠
            e.Handled = true;
        }

        // ============================================================
        // 드래그 기능 주석처리 (테스트용)
        // ============================================================
        ///// <summary>
        ///// 마우스 왼쪽 버튼 다운 이벤트 처리 (드래그 시작)
        ///// </summary>
        //private void IconButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    _mouseDownPosition = e.GetPosition(this);
        //    _dragOffset = _mouseDownPosition;
        //    _isDragging = false;
        //    _hasMoved = false;
        //
        //    // 마우스 캡처 (드래그 추적을 위해)
        //    ((UIElement)sender).CaptureMouse();
        //    e.Handled = true;
        //}
        //
        ///// <summary>
        ///// 마우스 왼쪽 버튼 업 이벤트 처리 (토글 실행)
        ///// </summary>
        //private void IconButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    // 마우스 캡처 해제
        //    ((UIElement)sender).ReleaseMouseCapture();
        //
        //    // 드래그가 아니었을 때만 토글 (클릭으로 간주)
        //    if (!_hasMoved || !_isDragging)
        //    {
        //        // 토글: 축소 -> 확장
        //        if (!_isExpanded)
        //        {
        //            ExpandWithAnimation();
        //        }
        //    }
        //
        //    // 플래그 초기화
        //    _isDragging = false;
        //    _hasMoved = false;
        //
        //    // 화면 경계 내 유지
        //    EnsureWithinScreenBounds();
        //
        //    e.Handled = true;
        //}

        ///// <summary>
        ///// 마우스 이동 이벤트 처리 (드래그 이동) - 주석처리 (테스트용)
        ///// </summary>
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //
        //    // 마우스 왼쪽 버튼이 눌려있고, CollapsedIcon이 마우스를 캡처했을 때
        //    if (e.LeftButton == MouseButtonState.Pressed && CollapsedIcon.IsMouseCaptured)
        //    {
        //        var currentPos = e.GetPosition(this);
        //        var distance = Math.Sqrt(
        //            Math.Pow(currentPos.X - _mouseDownPosition.X, 2) +
        //            Math.Pow(currentPos.Y - _mouseDownPosition.Y, 2)
        //        );
        //
        //        // 조금이라도 움직였는지 표시
        //        if (distance > 0.5)
        //        {
        //            _hasMoved = true;
        //        }
        //
        //        // 일정 거리 이상 움직이면 드래그로 간주하고 위치 이동
        //        if (distance > DragThreshold)
        //        {
        //            _isDragging = true;
        //            var screenPos = PointToScreen(currentPos);
        //            this.Left = screenPos.X - _dragOffset.X;
        //            this.Top = screenPos.Y - _dragOffset.Y;
        //        }
        //    }
        //}

        /// <summary>
        /// 화면 경계 내에 위젯이 위치하도록 보정
        /// </summary>
        private void EnsureWithinScreenBounds()
        {
            var wa = SystemParameters.WorkArea;

            if (this.Left < wa.Left)
                this.Left = wa.Left;
            if (this.Top < wa.Top)
                this.Top = wa.Top;
            if (this.Left + this.Width > wa.Right)
                this.Left = wa.Right - this.Width;
            if (this.Top + this.Height > wa.Bottom)
                this.Top = wa.Bottom - this.Height;
        }

        /// <summary>
        /// 타이틀바 드래그 시작
        /// </summary>
        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_isExpanded)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// 축소 버튼 클릭 이벤트
        /// </summary>
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            CollapseWithAnimation();
        }

        /// <summary>
        /// 검색 버튼 클릭 이벤트
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }

        /// <summary>
        /// 검색창에서 Enter 키 입력 처리
        /// </summary>
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformSearch();
            }
        }

        /// <summary>
        /// 검색 실행 (WebView2 로딩)
        /// </summary>
        private void PerformSearch()
        {
            string query = SearchTextBox.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("닉네임을 입력해주세요.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // TODO: WebView2를 통한 검색 페이지 로딩 구현
            string searchUrl = $"https://lol.ps/summoner/search/?q={Uri.EscapeDataString(query)}";

            // WebView2 초기화 및 네비게이션은 추후 구현
            MessageBox.Show($"검색 URL: {searchUrl}\n(WebView2 통합 예정)", "개발 중", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
