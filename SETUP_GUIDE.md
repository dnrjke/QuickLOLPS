# lol.ps 검색 위젯 - 프로젝트 설정 가이드

## 📁 프로젝트 구조

```
QuickLOLPS/
├── LolpsWidget.sln                 # Visual Studio 솔루션 파일
├── .gitignore                      # Git 제외 파일 목록
├── README.md                       # 프로젝트 소개
├── SETUP_GUIDE.md                  # 이 가이드 문서
└── LolpsWidget/                    # 메인 프로젝트 디렉토리
    ├── LolpsWidget.csproj          # 프로젝트 파일 (.NET 8 LTS)
    ├── App.xaml                    # 애플리케이션 진입점 (XAML)
    ├── App.xaml.cs                 # 애플리케이션 로직
    │
    ├── Views/                      # UI 뷰 컴포넌트
    │   ├── WidgetShell.xaml        # 메인 위젯 윈도우 (축소/확장)
    │   ├── WidgetShell.xaml.cs     # 위젯 로직 (드래그, 애니메이션)
    │   ├── ChampionBrowser.xaml    # 챔피언 탐색 UI
    │   └── ChampionBrowser.xaml.cs # 챔피언 탐색 로직
    │
    ├── ViewModels/                 # MVVM 뷰모델
    │   └── MainViewModel.cs        # 메인 뷰모델 (검색, 챔피언 데이터)
    │
    ├── Models/                     # 데이터 모델
    │   └── ChampionModel.cs        # 챔피언 정보 모델
    │
    ├── Helpers/                    # 헬퍼 클래스
    │   └── SettingsManager.cs      # 위치/설정 저장/복원
    │
    ├── Resources/                  # 리소스 파일
    │   ├── Styles/
    │   │   └── Styles.xaml         # lol.ps 톤 팔레트 스타일
    │   └── Icons/                  # 아이콘 파일 (추후 추가)
    │
    ├── WebView2Host/               # WebView2 통합 (추후 구현)
    ├── Tests/                      # 테스트 파일 (추후 추가)
    └── Scripts/                    # 빌드/배포 스크립트 (추후 추가)
```

## 🛠️ 개발 환경 요구사항

### 필수 요구사항
- **운영체제**: Windows 10 1809 이상 / Windows 11 권장
- **IDE**: Visual Studio 2022 (17.8 이상)
- **.NET SDK**: .NET 8.0 SDK (LTS - 2026년 11월까지 지원)
- **WebView2 런타임**: Microsoft Edge WebView2 Runtime (이미 설치됨)

> **참고**: .NET 6.0은 2024년 11월 12일부로 지원이 종료되었습니다. 이 프로젝트는 장기 지원이 보장되는 .NET 8.0 LTS를 사용합니다.

### 권장 사항
- 듀얼 모니터 환경 (테스트용)
- 다양한 DPI 설정 (100%, 125%, 150%) 테스트 환경

## 📦 NuGet 패키지 의존성

프로젝트 파일(`LolpsWidget.csproj`)에 다음 패키지가 포함되어 있습니다:

| 패키지 | 버전 | 용도 |
|--------|------|------|
| `Microsoft.Web.WebView2` | 1.0.2792.45 | lol.ps 웹 페이지 렌더링 |
| `CommunityToolkit.Mvvm` | 8.3.2 | MVVM 패턴 구현 (Source Generator) |
| `Newtonsoft.Json` | 13.0.3 | 설정 파일 저장/로드 |

## 🚀 빌드 및 실행 방법

### Visual Studio에서 빌드

1. **솔루션 열기**
   ```
   LolpsWidget.sln 파일을 Visual Studio 2022로 엽니다.
   ```

2. **NuGet 패키지 복원**
   - Visual Studio가 자동으로 NuGet 패키지를 복원합니다.
   - 수동 복원: 솔루션 우클릭 → "NuGet 패키지 복원"

3. **빌드 구성 선택**
   - Debug (개발용) 또는 Release (배포용)
   - 플랫폼: x64

4. **빌드 실행**
   - 메뉴: 빌드 → 솔루션 빌드 (Ctrl+Shift+B)

5. **실행**
   - F5 (디버깅) 또는 Ctrl+F5 (디버깅 없이 실행)

### 명령줄에서 빌드 (.NET CLI)

Windows 환경에서 .NET SDK가 설치된 경우:

```powershell
# 프로젝트 디렉토리로 이동
cd QuickLOLPS

# NuGet 패키지 복원
dotnet restore

# 빌드
dotnet build --configuration Release

# 실행
dotnet run --project LolpsWidget/LolpsWidget.csproj
```

## ✅ 1단계 완료 체크리스트

### 생성된 파일 확인

- [x] `LolpsWidget.sln` - 솔루션 파일
- [x] `LolpsWidget/LolpsWidget.csproj` - 프로젝트 파일 (.NET 6 WPF)
- [x] `.gitignore` - Git 제외 파일 목록
- [x] `App.xaml` / `App.xaml.cs` - 애플리케이션 진입점
- [x] `Views/WidgetShell.xaml` / `.xaml.cs` - 메인 위젯 창
- [x] `Views/ChampionBrowser.xaml` / `.xaml.cs` - 챔피언 탐색 UI
- [x] `ViewModels/MainViewModel.cs` - 메인 뷰모델
- [x] `Models/ChampionModel.cs` - 챔피언 모델
- [x] `Helpers/SettingsManager.cs` - 설정 관리자
- [x] `Resources/Styles/Styles.xaml` - lol.ps 톤 팔레트 스타일

### 디렉토리 구조 확인

- [x] Views/ - UI 뷰 컴포넌트
- [x] ViewModels/ - MVVM 뷰모델
- [x] Models/ - 데이터 모델
- [x] Helpers/ - 헬퍼 클래스
- [x] Resources/Styles/ - 스타일 리소스
- [x] Resources/Icons/ - 아이콘 리소스 (빈 디렉토리)
- [x] WebView2Host/ - WebView2 통합 (빈 디렉토리, 추후 구현)
- [x] Tests/ - 테스트 (빈 디렉토리, 추후 추가)
- [x] Scripts/ - 빌드/배포 스크립트 (빈 디렉토리, 추후 추가)

## 🎨 구현된 주요 기능

### 1. WidgetShell (메인 위젯 창)
- **축소/확장 토글**: 아이콘 클릭 시 확장/축소
- **초기 상태**: 축소 상태로 시작
- **Always-On-Top**: 항상 최상위 표시
- **투명 배경**: 반투명 다크 배경
- **드래그 이동**: 마우스로 위치 이동 가능
- **애니메이션**: 200ms 부드러운 전환 (180-250ms 범위 내)
- **화면 경계 보정**: 화면 밖으로 벗어나지 않도록 자동 보정
- **검색 기능**: 닉네임 입력 및 Enter 키/버튼 클릭 (WebView2 연동 예정)

### 2. 스타일 시스템 (Styles.xaml)
- **lol.ps 톤 팔레트**:
  - Primary Dark: `#1C1C1F`
  - Secondary Dark: `#28282C`
  - Accent Orange: `#F4A460`
  - Accent Yellow: `#FFD700`
  - Text Primary: `#FFFFFF`
  - Text Secondary: `#B0B0B0`
- **커스텀 컨트롤 스타일**:
  - PrimaryButton: 오렌지 배경, 호버 시 노랑으로 변경
  - SearchTextBox: 다크 배경, 오렌지 테두리

### 3. MVVM 구조
- **MainViewModel**: 검색 쿼리, 챔피언 데이터 관리
- **CommunityToolkit.Mvvm**: Source Generator 기반 간결한 MVVM 구현
  - `[ObservableProperty]`: 자동 속성 변경 알림
  - `[RelayCommand]`: 자동 명령 생성

### 4. 설정 관리 (SettingsManager)
- **위치 저장/복원**: JSON 파일로 위젯 위치 저장
- **모니터 정보 포함**: 듀얼 모니터 환경 지원 준비
- **저장 경로**: `%AppData%/LolpsWidget/settings.json`

## ⚠️ 현재 제한사항 (추후 구현 예정)

### 미구현 기능
1. **WebView2 통합**: 검색 결과 및 챔피언 페이지 렌더링
2. **챔피언 데이터 로드**: 실제 lol.ps API 또는 Riot API 연동
3. **챔피언 상세 팝업**: ChampionDetailPopup 구현
4. **듀얼 모니터 로직**: 모니터 정보 저장 및 재배치 보정
5. **DPI 대응**: 다양한 DPI 설정에서의 스케일링
6. **아이콘 리소스**: 실제 lol.ps 로고 또는 커스텀 아이콘

### 알려진 이슈
- Linux 환경에서 생성되었으므로 **Windows에서 빌드 및 실행 필요**
- WebView2 통합 시 런타임 초기화 로직 추가 필요
- 챔피언 이미지는 현재 플레이스홀더 사각형으로 표시

## 📝 다음 단계 (2단계 이후)

### 2단계: 챔피언 탐색 UI 개발
- ChampionCard 컴포넌트 구현
- 탭별 챔피언 필터링 (탑, 정글, 미드, 원딜, 서포터)
- 챔피언 이미지 로드 (Data Dragon API)

### 3단계: WebView2 통합
- WebView2 초기화 및 설정
- lol.ps 검색 페이지 로드
- 챔피언 상세 페이지 로드 (팝업 또는 내부 프레임)

### 4단계: 듀얼 모니터 및 DPI 대응
- 모니터 정보 감지 및 저장
- 재시작 시 위치 복원
- DPI 변화에 따른 스케일링

### 5단계: 배포 준비
- MSIX 패키징
- 코드 서명
- 설치 프로그램 생성 (WiX)

## 🔍 프로젝트 검증 방법

### Visual Studio에서 확인

1. **솔루션 열기**: `LolpsWidget.sln` 더블클릭
2. **솔루션 탐색기 확인**: 모든 파일이 올바르게 표시되는지 확인
3. **빌드 오류 확인**: Ctrl+Shift+B로 빌드 시 오류 없이 성공하는지 확인
4. **NuGet 패키지 확인**: 도구 → NuGet 패키지 관리자 → 솔루션용 NuGet 패키지 관리에서 설치된 패키지 확인

### 예상 빌드 결과
- **성공 시**: "빌드: 1개 성공, 0개 실패, 0개 최신 상태"
- **출력 파일**: `LolpsWidget/bin/Debug/net6.0-windows/LolpsWidget.exe`

### 실행 시 예상 동작
1. 축소된 아이콘 위젯이 화면에 표시됨 (60x60 픽셀, "L" 텍스트)
2. 아이콘 클릭 시 확장됨 (900x520 픽셀, 검색창 및 탭 표시)
3. 검색창에 닉네임 입력 후 Enter/검색 버튼 클릭 시 알림 메시지 표시 (WebView2 통합 예정)
4. 드래그로 위젯 이동 가능

## 📞 문의 및 이슈

- 빌드 오류 발생 시: Visual Studio 출력 창의 오류 메시지 확인
- NuGet 패키지 복원 실패 시: 인터넷 연결 확인 및 NuGet 소스 설정 확인
- 실행 오류 발생 시: .NET 6.0 런타임 설치 여부 확인

## 📄 라이선스

(추후 결정)

---

**문서 작성일**: 2025-11-30
**프로젝트 단계**: 1단계 (프로젝트 뼈대 구성) 완료
**다음 단계**: 2단계 - 챔피언 탐색 UI 개발
