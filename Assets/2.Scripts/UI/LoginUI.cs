using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LoginUI : BaseUI
{

    public GameObject NickNamePanel;

    public TMP_InputField nickNameInput;

    public Button characterSelectBtn;
    public Button nickNameSelectBtn;
    public Button BackBtn;

    public Button firstCharacterBtn;
    public Button secondCharacterBtn;
    public Button thirdCharacterBtn;
    public Button fourthCharacterBtn;


    public Outline firstOutLine;
    public Outline secondOutLine;
    public Outline thirdOutLine;
    public Outline fourthOutLine;

    public int characterInfoId;
    public string nickName;
    public int levelInfoId;



    protected override UIState GetUIState()
    {
        return UIState.Login;
    }

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
        firstCharacterBtn.onClick.AddListener(OnClickSelectFirst);
        secondCharacterBtn.onClick.AddListener(OnClickSelectSecond);
        thirdCharacterBtn.onClick.AddListener(OnClickSelectThird);
        fourthCharacterBtn.onClick.AddListener(OnClickSelectFour);
        characterSelectBtn.onClick.AddListener(OnClickSelectCharacter);
        nickNameSelectBtn.onClick.AddListener(OnClickCharacterCreate);
        BackBtn.onClick.AddListener(OnClickBackBtn);
        NickNamePanel.SetActive(false);
    }

    public void OnClickSelectFirst()
    {
        ChoiceCharacter(Enums.SelectCharacter.Aria);

    }

    public void OnClickSelectSecond()
    {
        ChoiceCharacter(Enums.SelectCharacter.Lowell);
    }

    public void OnClickSelectThird()
    {
        ChoiceCharacter(Enums.SelectCharacter.Elena);
    }

    public void OnClickSelectFour()
    {
        ChoiceCharacter(Enums.SelectCharacter.Masamune);
    }


    public void OnClickSelectCharacter()
    {
        NickNamePanel.SetActive(true);
    }

    public void OnClickCharacterCreate()
    {
        nickName = nickNameInput.text;
        levelInfoId = (int)Enums.SelectLevel.lv1;
        Debug.Log("캐릭터 생성");

        SocketManager.Instance.SendCreatePlayer(characterInfoId, levelInfoId, nickName);

        uIManager.OnClickGame();
    }

    public void OnClickBackBtn()
    {
        NickNamePanel.SetActive(false);
    }

    public void ChoiceCharacter(Enums.SelectCharacter selectCharacter)
    {
        firstOutLine.enabled = false;
        secondOutLine.enabled = false;
        thirdOutLine.enabled = false;
        fourthOutLine.enabled = false;

        characterInfoId = (int)selectCharacter;

        switch (selectCharacter)
        {
            case Enums.SelectCharacter.Aria:
                firstOutLine.enabled = true;
                break;
            case Enums.SelectCharacter.Lowell:
                secondOutLine.enabled = true;
                break;
            case Enums.SelectCharacter.Elena:
               thirdOutLine.enabled = true;

                break;
            case Enums.SelectCharacter.Masamune:
                fourthOutLine.enabled = true;
                break;
        }
    }



}
