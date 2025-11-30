# 애플리케이션 아이콘 생성 가이드

## 📋 개요

lol.ps 위젯 애플리케이션에 사용할 아이콘 파일(.ico) 생성 방법을 안내합니다.

---

## 🎨 아이콘 요구사항

### 파일 형식
- **형식**: `.ico` (Windows Icon)
- **위치**: `LolpsWidget/Resources/Icons/app.ico`
- **크기**: 여러 해상도 포함 권장
  - 16x16 (작업 표시줄)
  - 32x32 (작업 표시줄 고해상도)
  - 48x48 (파일 탐색기)
  - 256x256 (큰 아이콘)

### 디자인 권장사항
- **테마**: lol.ps 톤 팔레트 사용
- **배경**: 투명 또는 다크 배경
- **메인 컬러**: 오렌지(#F4A460) 또는 노랑(#FFD700)
- **간결함**: 16x16에서도 식별 가능하도록 단순한 디자인

---

## 🛠️ 아이콘 생성 방법

### 방법 1: 온라인 도구 사용 (권장 - 가장 간단)

#### 1-1. PNG에서 ICO로 변환

1. **PNG 이미지 준비**
   - 정사각형 이미지 (512x512 권장)
   - 투명 배경 권장
   - lol.ps 로고 또는 "L" 문자 디자인

2. **온라인 변환 도구**
   - https://convertio.co/kr/png-ico/
   - https://www.icoconverter.com/
   - https://favicon.io/

3. **변환 설정**
   - 여러 크기 선택: 16, 32, 48, 256
   - 다운로드: `app.ico`

4. **파일 배치**
   ```
   LolpsWidget/Resources/Icons/app.ico
   ```

#### 1-2. 텍스트 아이콘 생성 (빠른 테스트용)

간단한 텍스트 아이콘 생성:
- https://favicon.io/favicon-generator/
- 텍스트: "L" 또는 "lol.ps"
- 배경: Dark (#1C1C1F)
- 텍스트 색상: Orange (#F4A460)
- 다운로드 후 `favicon.ico`를 `app.ico`로 이름 변경

---

### 방법 2: GIMP 사용 (무료 오픈소스)

#### 설치
- 다운로드: https://www.gimp.org/downloads/
- Windows 설치 파일 실행

#### 아이콘 생성 단계

1. **새 이미지 생성**
   ```
   파일 → 새 이미지
   크기: 256x256 픽셀
   배경: 투명
   ```

2. **디자인 작업**
   - 텍스트 도구 (T): "L" 문자 입력
   - 폰트: 굵은 Sans-serif
   - 색상: #F4A460 (오렌지)
   - 정렬: 중앙

3. **여러 크기 생성**
   ```
   이미지 → 크기 조정
   256x256 저장

   각 크기별로 반복:
   - 48x48
   - 32x32
   - 16x16
   ```

4. **ICO 형식으로 내보내기**
   ```
   파일 → 다음으로 내보내기
   파일 형식: Microsoft Windows icon (*.ico)
   위치: LolpsWidget/Resources/Icons/app.ico
   ```

---

### 방법 3: Visual Studio 내장 도구

#### 단계

1. **Visual Studio에서 새 아이콘 파일 생성**
   ```
   솔루션 탐색기 → LolpsWidget → Resources → Icons 우클릭
   → 추가 → 새 항목
   → "아이콘 파일 (.ico)" 선택
   → 이름: app.ico
   ```

2. **아이콘 편집**
   - Visual Studio 아이콘 편집기가 자동으로 열림
   - 여러 크기 (16x16, 32x32, 48x48, 256x256) 편집 가능
   - 그리기 도구로 간단한 디자인 작성

3. **저장**
   - Ctrl+S로 저장

---

### 방법 4: Inkscape 사용 (벡터 그래픽)

#### 설치
- 다운로드: https://inkscape.org/release/

#### 단계

1. **벡터 디자인 생성**
   ```
   파일 → 새 문서
   크기: 256x256
   ```

2. **디자인**
   - 텍스트 도구: "L" 입력
   - 경로로 변환: 경로 → 객체를 경로로
   - 색상: #F4A460

3. **PNG로 내보내기**
   ```
   파일 → PNG 이미지로 내보내기
   크기: 256x256
   ```

4. **PNG를 ICO로 변환**
   - 방법 1의 온라인 도구 사용

---

## 📂 파일 배치

아이콘 파일을 생성했다면:

### 1. 디렉토리 확인
```powershell
# PowerShell에서 실행
cd C:\QuickLOLPS-claude-lol-search-widget-0133MjB3nPQ6wR48UchPSuHh\LolpsWidget

# Resources\Icons 폴더가 없으면 생성
if (!(Test-Path "Resources\Icons")) {
    New-Item -ItemType Directory -Path "Resources\Icons"
}
```

### 2. 아이콘 파일 복사
```powershell
# app.ico 파일을 Resources\Icons\ 폴더로 복사
Copy-Item "다운로드경로\app.ico" "Resources\Icons\app.ico"
```

### 3. 프로젝트 파일 수정

`LolpsWidget.csproj` 파일에서 아이콘 참조 활성화:

```xml
<!-- 주석 제거 -->
<ApplicationIcon>Resources\Icons\app.ico</ApplicationIcon>
```

**변경 전:**
```xml
<!-- <ApplicationIcon>Resources\Icons\app.ico</ApplicationIcon> -->
```

**변경 후:**
```xml
<ApplicationIcon>Resources\Icons\app.ico</ApplicationIcon>
```

### 4. 빌드 확인
```powershell
dotnet build --configuration Debug
```

---

## 🎨 추천 아이콘 디자인 (빠른 시작)

### 옵션 1: 단순 문자 "L"
```
배경: 투명 또는 #1C1C1F (다크)
텍스트: "L"
폰트: 굵은 Sans-serif
색상: #F4A460 (오렌지)
크기: 256x256
```

### 옵션 2: "lol.ps" 텍스트
```
배경: #1C1C1F (다크)
텍스트: "lol.ps" (여러 줄)
폰트: 모던 Sans-serif
색상: #FFD700 (노랑)
```

### 옵션 3: 검색 아이콘
```
배경: 투명
모양: 돋보기 아이콘
색상: #F4A460 (오렌지)
내부: "L" 또는 "lol" 텍스트
```

---

## 🚀 빠른 시작: 임시 아이콘 생성

아이콘 디자인 전에 빠르게 테스트하려면:

### PowerShell 스크립트로 간단한 ICO 생성

```powershell
# 임시 아이콘 생성 (Windows 기본 아이콘 복사)
cd C:\QuickLOLPS-claude-lol-search-widget-0133MjB3nPQ6wR48UchPSuHh\LolpsWidget

# Resources\Icons 폴더 생성
New-Item -ItemType Directory -Path "Resources\Icons" -Force

# Windows 기본 아이콘 복사 (임시)
Copy-Item "C:\Windows\System32\imageres.dll" "temp.dll"
# 또는 온라인에서 무료 아이콘 다운로드
```

**또는 무료 아이콘 다운로드:**
- https://icons8.com/icons/set/search (검색 아이콘)
- https://www.flaticon.com/ (무료 아이콘)
- https://iconmonstr.com/ (간단한 아이콘)

---

## ✅ 확인 사항

아이콘 적용 후 다음을 확인하세요:

### 1. 파일 존재 확인
```powershell
Test-Path "LolpsWidget\Resources\Icons\app.ico"
# True 출력되어야 함
```

### 2. 프로젝트 파일 수정 확인
```xml
<!-- LolpsWidget.csproj에서 확인 -->
<ApplicationIcon>Resources\Icons\app.ico</ApplicationIcon>
```

### 3. 빌드 성공 확인
```powershell
dotnet build --configuration Debug
# 오류 없이 빌드 성공
```

### 4. 실행 파일 아이콘 확인
```
bin\Debug\net8.0-windows\win-x64\LolpsWidget.exe
→ 파일 탐색기에서 아이콘이 표시되는지 확인
```

---

## 🔧 문제 해결

### 오류: "아이콘 파일을 여는 동안 오류가 발생했습니다"

**원인:** 파일 경로가 잘못되었거나 파일이 없음

**해결:**
```powershell
# 파일 존재 확인
ls LolpsWidget\Resources\Icons\app.ico

# 없으면 다시 생성/복사
```

### 오류: "유효하지 않은 아이콘 형식"

**원인:** ICO 파일이 손상되었거나 잘못된 형식

**해결:**
- 온라인 변환 도구로 다시 변환
- 또는 Visual Studio 아이콘 편집기로 새로 생성

---

## 📚 참고 자료

- [Microsoft - 애플리케이션 아이콘 추가](https://learn.microsoft.com/ko-kr/dotnet/desktop/wpf/)
- [GIMP 튜토리얼](https://www.gimp.org/tutorials/)
- [Inkscape 가이드](https://inkscape.org/learn/)
- [아이콘 디자인 가이드](https://developer.microsoft.com/en-us/windows/apps/design/)

---

## 📞 추가 지원

아이콘 생성에 어려움이 있다면:
1. 온라인 도구 사용 (가장 간단)
2. 무료 아이콘 다운로드 후 변환
3. 임시로 아이콘 없이 빌드 (현재 설정)

현재 프로젝트는 **아이콘 없이도 정상적으로 빌드 및 실행**됩니다.
나중에 아이콘을 추가하려면 이 가이드를 참고하세요!
