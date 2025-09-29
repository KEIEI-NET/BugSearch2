//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 支払一覧表（総括）
// プログラム概要   : 支払一覧表（総括）の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI東　隆史
// 作 成 日  2012/09/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 支払一覧表（総括）抽出クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 支払一覧表（総括）抽出クラス</br>
    /// <br>Programmer : FSI東 隆史</br>
    /// <br>Date       : 2012/09/04</br>
    /// </remarks>
    public class PMKAK02001EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
		/// 支払一覧表（総括）抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 支払一覧表（総括）UIクラス</br>
		/// <br>Programmer : FSI東 隆史</br>
		/// <br>Date       : 2012/09/04</br>
		/// </remarks>
        public PMKAK02001EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as SumSuplierPayMainCndtn;

            this._extraInfo.PrintDiv = this._printInfo.frycd;
            this._extraInfo.PrintDivName = this._printInfo.prpnm;
            this._sumSuplierPayMainAcs = new SumSuplierPayMainAcs();
        }
        #endregion ■ Constructor

        #region ■ private member

        private SFCMN06002C _printInfo = null;                       // 印刷情報クラス
        private SumSuplierPayMainAcs _sumSuplierPayMainAcs = null;   // 支払一覧表（総括）アクセスクラス
        private SumSuplierPayMainCndtn _extraInfo = null;            // 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "PMKAK02001E";
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
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
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
                form.Show();                // ダイアログ表示
                status = this.ExtraProc();  // 抽出処理実行
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
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
				// 印刷帳票により取得データを変更する
				switch ( this._extraInfo.PrintDiv )
				{
                    case (int)SumSuplierPayMainCndtn.PrintDivState.DetailTyp:		//明細 
                        status = this._sumSuplierPayMainAcs.SearchSuplierPayMain(this._extraInfo, out errMsg);
						break;
					default:
                        status = this._sumSuplierPayMainAcs.SearchSuplierPayMain(this._extraInfo, out errMsg);
						break;
				}

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    // 印刷データ取得
                    this._printInfo.rdData = this._sumSuplierPayMainAcs.SuplierPayDs;
                }
            }
            catch (Exception ex)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
                            // ステータスが以上のときはメッセージを表示
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
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
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/09/04</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}
