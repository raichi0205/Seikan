using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Star.Common.UI;
using Cysharp.Threading.Tasks;
using TMPro;
using Star.Battle;
using Star.Battle.UI;

public class PlayerInfoPopup : PopupBase
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] ScrollRect statusScroll;
    [SerializeField] CommonButton closeButton;
    [SerializeField] List<StateInfoCell> statusList = new List<StateInfoCell>();

    [SerializeField] StateInfoCell originButton;

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="_states">ステータス情報</param>
    public void Initialize(List<StateBase> _states)
    {
        base.Initialize();

        infoText.text = string.Empty;

        closeButton.onClick.AddListener(() =>
        {
            Close().Forget();
        });

        foreach(StateBase state in _states)
        {
            CreateCell(state);
        }

        BattleSystem.Instance.Actor.OnAddState += CreateCell;
        BattleSystem.Instance.Actor.OnSubState += DeleteCell;
    }

    /// <summary>
    /// セル作成
    /// </summary>
    /// <param name="_state"></param>
    private void CreateCell(StateBase _state)
    {
        if(_state == null)
        {
            return;
        }

        var obj = Instantiate(originButton);
        obj.transform.SetParent(statusScroll.content, false);
        obj.State = _state;
        obj.Button.onClick.AddListener(() =>
        {
            string text = _state.StateData.StateName;
            text += "\n";
            text += _state.StateData.InfoText;

            infoText.text = text;
        });
        obj.Icon.sprite = _state.StateData.IconImage;
        obj.Button.Text.text = _state.StateData.StateName;
        statusList.Add(obj);
    }

    /// <summary>
    /// セル削除
    /// </summary>
    /// <param name="_state"></param>
    private void DeleteCell(StateBase _state)
    {
        StateInfoCell cell = null;
        infoText.text = string.Empty;
        foreach(var stateCell in statusList)
        {
            if(stateCell.State == _state)
            {
                cell = stateCell;
                break;
            }
        }
        if (cell != null)
        {
            statusList.Remove(cell);
            Destroy(cell.gameObject);
        }
    }

    /// <summary>
    /// UIを開く
    /// </summary>
    /// <returns></returns>
    public async UniTask Open()
    {
        await base.Open();
    }

    public async UniTask Close()
    {
        await base.Close();
    }

    private void OnDestroy()
    {
        BattleSystem.Instance.Actor.OnAddState -= CreateCell;
        BattleSystem.Instance.Actor.OnSubState -= DeleteCell;
    }
}
