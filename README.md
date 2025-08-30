# 2D 액션 게임 (2D Action Game)

이 프로젝트는 Unity 엔진으로 개발된 2D 횡스크롤 액션 게임입니다. 픽셀 아트 스타일의 그래픽과 다양한 몬스터, 플레이어 액션을 특징으로 합니다.

## 주요 기능

*   **플레이어**: 이동, 점프, 공격 등 기본적인 액션이 가능합니다.
*   **몬스터**: Goblin, Skeleton, FlyingEye 등 다양한 종류의 몬스터가 등장합니다.
*   **전투**: 플레이어의 공격과 몬스터의 피격 판정이 구현되어 있습니다.
*   **UI**: 몬스터의 체력 바가 표시됩니다.
*   **카메라**: 플레이어를 따라 부드럽게 움직이는 카메라가 구현되어 있습니다.
*   **입력**: Unity의 새로운 Input System을 사용하여 입력을 처리합니다.

## 시작하기

### 요구 사항

*   Unity Hub
*   Unity Editor 버전: `6000.1.7f1`

### 설치 및 실행

1.  이 저장소를 로컬 컴퓨터에 클론합니다.
2.  Unity Hub를 열고 'Add project from disk'를 선택하여 이 프로젝트 폴더를 추가합니다.
3.  프로젝트를 열고 `Assets/1.Scenes/SampleScene.unity` 씬을 실행합니다.

## 프로젝트 구조

*   `Assets/1.Scenes`: 게임의 주요 씬이 들어있습니다.
*   `Assets/2.Scripts`: 게임의 핵심 로직과 스크립트가 들어있습니다.
*   `Assets/3.Prefabs`: 플레이어, 몬스터, 아이템 등 재사용 가능한 오브젝트가 들어있습니다.
*   `Assets/4.Animations`: 캐릭터와 오브젝트의 애니메이션 클립 및 컨트롤러가 들어있습니다.
*   `Assets/5.Art`: 게임에 사용된 2D 아트 리소스(스프라이트, 타일셋 등)가 들어있습니다.
*   `Assets/InputSystem_Actions.inputactions`: 게임의 입력 액션을 정의한 파일입니다.


## 캐릭터 조작
* 이동 : ⬅️➡️
* 점프 : ⬆️
* 공격 : Z

## 아이템
* ❤️ : 체력회복
* 🍖 : 공격력 증가
* 🏴‍☠️ : 체력 감소


## 개발 환경

*   **Engine**: Unity `6000.1.7f1`
*   **Render Pipeline**: Universal Render Pipeline (URP)
*   **Input System**: Unity Input System Package
