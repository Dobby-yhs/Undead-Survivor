## [골드메탈 유튜브](https://www.youtube.com/watch?v=MmW166cHj54&list=PLO-mt5Iu5TeZF8xMHqtT_DhAPKmjF6i3x&index=1)의 Undead Survivor 개발을 위한 Repository입니다.

### Day 1
<details>
	<summary><b>정리 내용</b></summary>
	
- Unity 구조
  - Unity의 핵심 구조 : 컴포넌트 기반
  - 물리 시스템 관련 컴포넌트 및 속성
- Unity에서의 픽셀 아트
  - 아틀라스 (스프라이트 시트)
  - 스프라이트
  - 셀 애니메이션
  - 픽셀 아트를 위한 주요 설정
- Unity의 Input System
  - 설치 방법
  - Player Input 컴포넌트 사용법
  - Input Action 설정
  - Input System의 스크립트 활용
- Rule Tile
  - Number of Tiling Rules
  - Tiling Rules
- Cinemachine 카메라 시스템
  
</details>
<details>
	<summary><b>구현 내용</b></summary>
	
- Player Input System 구현
- 2D Cell Animation 제작
- 무한 맵 적용
- 몬스터 구현
  
</details>

> My Blog Link
>   > *https://sunlight-dby.tistory.com/57*  

### Day 2
<details>
	<summary><b>정리 내용</b></summary>
	
- 트랜스폼과 인스펙터 유용 팁
	- Transform의 Scale 속성 : 비율 고정 기능
 	- Inspector의 자물쇠 아이콘
  	- Header 속성
  	- 직렬화 (Serialization)
  	- 콜라이더 컴포넌트 리셋
  - 프리팹과 오브젝트 풀링
  	- 프리팹 생성
   	- 프리팹의 한계
	- 오브젝트 풀링
- GetComponentsInChildren<T>( )
- Null 체크
- 애니메이터 설정
- 부모 오브젝트
- 스프라이트의 레이어 순서 설정
- 레이어 (Layer)
- AddForce( )
- FromToRotation( )
- 충돌체 감지를 위한 Cast 계열 함수
- 넉백 기능을 위한 코루틴 (Coroutine) 활용
  
</details>
<details>
	<summary><b>구현 내용</b></summary>
	
- Object Pooling을 위한 Pool Manager 생성 및 구현
- 소환 레벨 적용
- 무기 구현
	- 회전하는 근접 무기
	- 자동 원거리 공격
- 몬스터 처리 애니메이션 및 넉백 적용
  
</details>

> My Blog Link
>   > *https://sunlight-dby.tistory.com/59*  

### Day 3
<details>
	<summary><b>정리 내용</b></summary>
	
- RectTransform
	- 앵커 (Anchor)
 - Canvas 컴포넌트
 	- Render Mode
  	- UI Scale Mode
- UI
	- HUD
 	- Text 요소
  		- Text (Legacy UI Text)
    		- TextMeshPro
      	- Image 컴포넌트
      	- Vertical Layout Group 컴포넌트
      	- Outline 컴포넌트
      	- 스크립트에서의 UI
      		- String.Format을 통한 UI Text 지정
      	 	- UI의 위치 갱신
      		- UI 업데이트 타이밍
      		- name 변수
	- Navigation
 - Scriptable Object
	- Scriptable Object 특징
 	- Scriptable Object 생성
  	- CreateAssetMenu 애트리뷰트
- 장면 전환과 관리
- Broadcast Message
   	- 시그니처
   	- 유의사항
- 오브젝트 계층 관련 함수
	- 비활성화 오브젝트 탐색
 - [TextArea] 애트리뷰트
 - 시간 제어
  
</details>
<details>
	<summary><b>구현 내용</b></summary>
	
- HUD 제작
- 능력 업그레이드
- 무기 장착
- 레벨업 시스템
- 게임 시작과 종료
  
</details>

> My Blog Link
>   > *https://sunlight-dby.tistory.com/61*  

### Day 4
<details>
	<summary><b>정리 내용</b></summary>
	
- Grid Layout Group 컴포넌트
- Enum.GetValues
- PlayerPrefs
- WaitForSecondsRealtime
- Unity 오디오 시스템
	- AudioClip
 	- AudioSource
      	- AudioListener
      	- Audio High Pass Filter
      	- 다량의 효과음을 낼 수 있도록 채널 개수 이용
- Prefab 연결 끊기
- Level Up System 변경
  
</details>
<details>
	<summary><b>구현 내용</b></summary>
	
- 플레이어 캐릭터 선택
- 캐릭터 해금 시스템
- 오디오 시스템 구축
- 로직 보완
  
</details>

> My Blog Link
>   > *https://sunlight-dby.tistory.com/62*  
