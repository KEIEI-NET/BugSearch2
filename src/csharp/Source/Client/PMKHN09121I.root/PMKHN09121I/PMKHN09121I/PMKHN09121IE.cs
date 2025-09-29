//****************************************************************************//
// システム         : 操作履歴表示画面
// プログラム名称   : 操作履歴表示画面インターフェース
// プログラム概要   : 操作履歴表示画面のテキスト出力用共通インタフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11202046-00  作成担当 : 時シン
// 作 成 日  K2016/10/28  修正内容 : 神姫産業㈱ テキスト出力機能追加と時刻検索条件の追加対応
//----------------------------------------------------------------------------//

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 操作履歴表示画面フォームコントロールインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note        : テキスト出力処理と時刻検索条件の追加を行う。</br>
    /// <br>Programmer  : 時シン</br>
    /// <br>Date        : K2016/10/28</br>
    /// </remarks>
    public interface IDoTextOutForm
    {
        /// <summary>
        /// テキスト出力ボタン押下時の処理を行います。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="fileMode">ファイル形式(0:CSV 1:TXT)</param>
        /// <param name="fileCheckFlag">ファイルチェックフラグ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : テキスト出力処理</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        int DoTextOut(string filePath, int fileMode, out bool fileCheckFlag, out string errMsg);

        /// <summary>
        /// 設定情報の設定
        /// </summary>
        /// <param name="canDisplay">true:表表示 false:非表示</param>
        /// <param name="setting"> 設定情報</param>
        /// <remarks>
        /// <br>Note        : 設定情報の設定を行う。</br>
        /// <br>Programmer  : 時シン</br>
        /// <br>Date        : K2016/10/28</br>
        /// </remarks>
        void TransferSettingInfo(bool canDisplay, object setting);
    }
}
