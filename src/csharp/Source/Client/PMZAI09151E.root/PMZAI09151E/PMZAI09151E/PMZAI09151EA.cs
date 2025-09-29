//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫履歴現在庫数設定データクラス
// プログラム概要   : 在庫履歴現在庫数設定データクラスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 在庫履歴現在庫数設定データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫履歴現在庫数設定検索条件情報初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class StockHistoryExtractInfo
    {
        # region ■ Private Field

        /// <summary>企業コード</summary>
        private string _enterpriseCode;

        /// <summary>対象年月開始</summary>
        private int _addUpYearMonthSt;
        # endregion ■ Private Field

        # region ■ Public Propaty
        /// <summary>
        /// 企業コードプロパティ
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>
        /// 対象年月開始プロパティ
        /// </summary>
        public int AddUpYearMonthSt
        {
            get { return this._addUpYearMonthSt; }
            set { this._addUpYearMonthSt = value; }
        }
        # endregion ■ Public Propaty

        #region ■コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StockHistoryExtractInfo()
        {

        }
        #endregion
    }
}
