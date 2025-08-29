using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI, IPoolable
{
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI LevelText;

    public Image Hp;
    public Image Exp;


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

    private void OnEnable()
    {
        Hp.fillAmount = 1;
        Exp.fillAmount = 0;
        LevelText.text = $"Lv. 1";
    }

    public void UpdateHpSlider(float percentage)
    {
        Hp.fillAmount = percentage;
    }

    public void UpdateCount(int count)
    {
        CountText.text = count.ToString();
    }

    public void UpdateLevelText(int level)
    {
        LevelText.text = $"Lv. {level}";
    }

    public void UpdateExp(float exp)
    {
       Exp.fillAmount = exp;
    }

    public void Release()
    {
        Managers.Pool.PoolRegistry.Release<GameUI>(this);
    }
}
