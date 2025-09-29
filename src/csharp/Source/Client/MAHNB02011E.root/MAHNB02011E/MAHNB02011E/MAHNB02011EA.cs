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
    /// 入金一覧表抽出クラスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入金一覧表UIフォームクラス</br>
    /// <br>Programmer : 22013 久保 将太</br>
    /// <br>Date       : 2007.03.08</br>
    /// <br>UpdateNote : 2007.11.14 980035 金沢 貞義</br>
    ///                :    ・DC.NS対応（「入金一覧表」⇒「入金確認表」に変更）
    /// <br></br>
    /// </remarks>
    public class MAHNB02011EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
		/// 入金一覧表抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金一覧表UIクラス</br>
		/// <br>Programmer : 22013 久保 将太</br>
		/// <br>Date       : 2007.03.08</br>
		/// <br></br>
		/// </remarks>
        public MAHNB02011EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._extraInfo = this._printInfo.jyoken as DepositMainCndtn;

			this._extraInfo.PrintDiv = this._printInfo.frycd;
			this._extraInfo.PrintDivName = this._printInfo.prpnm;
            this._depositMainAcs = new DepositMainAcs();
        }
        #endregion ■ Constructor

        #region ■ private member

        private SFCMN06002C _printInfo = null;			// 印刷情報クラス
        private DepositMainAcs _depositMainAcs = null;	// 在庫車両入出庫管理表アクセスクラス
        private DepositMainCndtn _extraInfo = null;		// 抽出条件クラス
        #endregion ■ private member

        #region ■ private const
        private const string ct_PGID = "MAHNB02011E";
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
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.03.08</br>
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
                form.Show();			// ダイアログ表示
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
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.03.08</br>
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
                    // 2008.07.09 30413 犬飼 総合計の帳票レイアウト削除 >>>>>>START
                    //case (int)DepositMainCndtn.PrintDivState.GrandTotal:		// 総合計
                    //    status = this._depositMainAcs.SearchDepositGrandTotal( this._extraInfo, out errMsg );
                    //    break;
                    // 2008.07.09 30413 犬飼 総合計の帳票レイアウト削除 <<<<<<END
                    // 2007.11.14 修正 >>>>>>>>>>>>>>>>>>>>
                    //case (int)DepositMainCndtn.PrintDivState.Details_HaveDraw:	// 詳細-引当有
					//	status = this._depositMainAcs.SearchDepositMainAllowance( this._extraInfo, out errMsg );
					//	break;
                    // 2008.07.09 30413 犬飼 金種別集計の帳票レイアウト削除 >>>>>>START
                    //case (int)DepositMainCndtn.PrintDivState.DepositKind:       // 金種別集計
                    //    status = this._depositMainAcs.SearchDepositDepositKind(this._extraInfo, out errMsg);
                    //    break;
                    // 2007.11.14 修正 <<<<<<<<<<<<<<<<<<<<
                    // 2008.07.09 30413 犬飼 金種別集計の帳票レイアウト削除 <<<<<<END
                    // 2008.07.09 30413 犬飼 詳細-引当無、簡易の帳票レイアウト削除 >>>>>>START
                    //default:													// 詳細-引当無、簡易
                    //    status = this._depositMainAcs.SearchDepositMain( this._extraInfo, out errMsg );
                    //    break;
                    // 2008.07.09 30413 犬飼 詳細-引当無、簡易の帳票レイアウト削除 <<<<<<END
                    
                    // 2008.07.09 30413 犬飼 帳票レイアウトの追加 >>>>>>START
                    case (int)DepositMainCndtn.PrintDivState.DepsitMainList:	        // 入金確認表
                        status = this._depositMainAcs.SearchDepositMainList(this._extraInfo, out errMsg);
                        break;
                    case (int)DepositMainCndtn.PrintDivState.DepositMainList_Sum:		// 入金確認表（集計表）
                        status = this._depositMainAcs.SearchDepositMainList_Sum(this._extraInfo, out errMsg);
                        break;
                    default:
                        break;
                    // 2008.07.09 30413 犬飼 帳票レイアウトの追加 <<<<<<END
                }

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
					// 印刷データ取得
                    this._printInfo.rdData = this._depositMainAcs.DepositDs;
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
        /// <br>Programmer : 22013 kubo</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}
