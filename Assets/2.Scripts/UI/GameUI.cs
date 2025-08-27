using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI, IPoolable
{
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI CountText;

    public Image Hp;


    private void Awake()
    {
        Init(Managers.UI);
    }
    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
        uIManager.gameUI = this;
        StageText.text = Managers.Game.StageNumber.ToString();
        CountText.text = Managers.Game.Count.ToString();
    }


    public void UpdateHpSlider(float percentage)
    {
        Hp.fillAmount = percentage;
    }

    public void UpdateCount(int count)
    {
        CountText.text = count.ToString();
    }

    public void Release()
    {

    }
}
