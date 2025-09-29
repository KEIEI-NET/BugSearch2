using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Data;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// 自由帳票（請求書）抽出クラスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自由帳票（請求書）UIフォームクラス</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.06.17</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/22  22018 鈴木 正臣</br>
    /// <br>           : アウトオブメモリ対応の為、キャンセル時動作を変更。</br>
    /// </remarks>
    public class PMKAU08000EA : IExtrProc
    {
        #region [private フィールド]
        private SFCMN06002C _printInfo = null;      // 印刷情報クラス
        private FrePBillAcs _frePBillAcs = null;    // 自由帳票（請求書）アクセスクラス
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        Broadleaf.Windows.Forms.SFCMN00299CA _progressForm;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        #endregion

        #region [private const フィールド]
        /// <summary>プログラムID (アセンブリ名)</summary>
        private const string ct_PGID = "PMKAU08000E";
        #endregion

        #region [コンストラクタ]
		/// <summary>
		/// 自由帳票（請求書）抽出クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票（請求書）UIクラス</br>
		/// <br>Programmer : 22018 鈴木 正臣</br>
		/// <br>Date       : 2008.06.17</br>
		/// <br></br>
		/// </remarks>
        public PMKAU08000EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
            this._frePBillAcs = new FrePBillAcs();
        }
        #endregion

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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int ExtrPrintData()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            
            // --- DEL m.suzuki 2010/07/22 ---------->>>>>
            //// 抽出中画面部品のインスタンスを作成
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 DEL
            ////Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            //_progressForm = new Broadleaf.Windows.Forms.SFCMN00299CA();
            //Broadleaf.Windows.Forms.SFCMN00299CA form = _progressForm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            //// 表示文字を設定
            //form.Title = "抽出中";
            //form.Message = "現在、データを抽出中です。";
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
            //form.DispCancelButton = true;
            //form.CancelButtonClick += new EventHandler( form_CancelButtonClick );
            //form.CancelButtonClick += new EventHandler( this._frePBillAcs.CancelButtonClick );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
            // --- UPD m.suzuki 2010/07/22 ----------<<<<<

            try
            {
                // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                //form.Show();			// ダイアログ表示
                // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // --- DEL m.suzuki 2010/07/22 ---------->>>>>
                //// ダイアログを閉じる
                //form.Close();
                // --- DEL m.suzuki 2010/07/22 ----------<<<<<
                this._printInfo.status = status;
            }

            return status;
		}
        // --- DEL m.suzuki 2010/07/22 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/03 ADD
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //void form_CancelButtonClick( object sender, EventArgs e )
        //{
        //    if ( _progressForm != null )
        //    {
        //        _progressForm.Message = "処理を中断します。";
        //    }
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/03 ADD
        /// <summary>
        /// 抽出キャンセル処理
        /// </summary>
        public void Cancel()
        {
            // アクセスクラスの抽出キャンセル処理を呼び出す
            this._frePBillAcs.CancelButtonClick( this, new EventArgs() );
        }
        // --- DEL m.suzuki 2010/07/22 ----------<<<<<
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int ExtraProc()
        {
            string errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
				// Todo:Search Method Call
                status = this._frePBillAcs.SearchMain( this._printInfo.jyoken, (DataView)this._printInfo.rdData, out errMsg );
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
					// 印刷データ取得
                    this._printInfo.rdData = this._frePBillAcs.PrintDataSet;
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
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}
