//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// キャンペーン目標設定マスタ（印刷）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタ（印刷）UIフォームクラス</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class PMKHN08718EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
		/// キャンペーン目標設定マスタ（印刷）クラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタ（印刷）UIクラス</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
		/// <br></br>
		/// </remarks>
        public PMKHN08718EA(object printInfo)
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
        }
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			                        // 印刷情報クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMKHN08718E";
        #endregion ■ private const

        #region ■ IExtrProc メンバ
        #region ◆ Public Property
        /// <summary>
        /// 印刷情報クラスプロパティ
        /// </summary>
        public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }
        #endregion ◆ Public Property

        #region ◆ Public Method
        #region ◎ 抽出処理
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";

            try
            {
                form.Show();			    // ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
        }
        #endregion
        #endregion ◆ Public Method
        #endregion ■ IExtrProc メンバ

        #region ■ Private Method
        #region ◆ 抽出メイン処理
        /// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        private int ExtraProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if ((this._printInfo.rdData as DataView).Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }
        #endregion ◆ 抽出メイン処理

        #region ◆ エラーメッセージ表示
        /// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion ◆ エラーメッセージ表示
        #endregion
    }
}
