# lol.ps 검색 위젯 (QuickLOLPS)

Windows 10/11용 Always-On-Top 투명 데스크톱 위젯으로, lol.ps 닉네임 검색 및 챔피언 정보를 제공합니다.

## ✨ 주요 기능

- 🎯 **축소/확장 토글**: 클릭으로 간편하게 전환
- 🌐 **WebView2 통합**: lol.ps 검색 및 챔피언 정보 렌더링
- 🎨 **lol.ps 톤 팔레트**: 다크 배경, 오렌지/노랑 포인트 컬러
- 🖥️ **듀얼 모니터 지원**: 위치 저장 및 복원
- 📱 **반응형 UI**: DPI 스케일링 대응

## 🛠️ 기술 스택

- **C# WPF** (.NET 6)
- **WebView2** (Chromium 기반)
- **MVVM 패턴** (CommunityToolkit.Mvvm)

## 📦 요구사항

- Windows 10 1809+ / Windows 11
- .NET 6.0 SDK
- Visual Studio 2022
- WebView2 런타임

## 🚀 빌드 및 실행

자세한 내용은 [SETUP_GUIDE.md](SETUP_GUIDE.md)를 참조하세요.

```powershell
# 프로젝트 클론
git clone <repository-url>
cd QuickLOLPS

# NuGet 패키지 복원
dotnet restore

# 빌드
dotnet build --configuration Release

# 실행
dotnet run --project LolpsWidget/LolpsWidget.csproj
```

## 📋 프로젝트 상태

**현재 단계**: 1단계 완료 (프로젝트 뼈대 구성)

### 완료된 항목
- [x] 프로젝트 구조 및 솔루션 생성
- [x] 기본 UI 컴포넌트 (WidgetShell, ChampionBrowser)
- [x] MVVM 구조 및 뷰모델
- [x] lol.ps 톤 팔레트 스타일
- [x] 설정 관리 (위치 저장/복원)

### 추후 구현 예정
- [ ] WebView2 통합 및 검색 기능
- [ ] 챔피언 데이터 로드 (API 연동)
- [ ] 챔피언 상세 팝업
- [ ] 듀얼 모니터 로직 완성
- [ ] MSIX/WiX 배포 패키징

## 📄 문서

- [설치 및 빌드 가이드](SETUP_GUIDE.md)

## 📞 문의

이슈 및 제안사항은 GitHub Issues를 통해 등록해주세요.

## 📝 라이선스

(추후 결정)
