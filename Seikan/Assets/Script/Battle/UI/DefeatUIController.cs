using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Star.Common.UI;

using UnityEngine.SceneManagement;

public class DefeatUIController : MonoBehaviour
{
    [SerializeField] CommonButton next;     // 次の行動に遷移

    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Initialize()
    {
        next.onClick.AddListener(Next);
    }

    /// <summary>
    /// 次の行動に遷移
    /// </summary>
    private void Next()
    {
        // Todo: 予め設定された次回行動によって遷移先を変更する
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
