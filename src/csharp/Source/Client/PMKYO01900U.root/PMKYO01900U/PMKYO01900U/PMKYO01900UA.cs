//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : エラー詳細ＵＩクラス
// プログラム概要   : エラー詳細表示処理を行い
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宋剛
// 作 成 日  2011/07/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 作 成 日  2011/09/01  修正内容 : #24288 出力設定の画面表示
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 作 成 日  2011/09/16  修正内容 : #25198 「PDF表示」ボタンを「印刷」ボタンに変更
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// エラー詳細フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: エラー詳細を行います
	/// <br>Programmer	: 宋剛</br>
	/// <br>Date		: 2011.07.29</br>
    /// </br>
    /// </remarks>
	public partial class PMKYO01900UA : System.Windows.Forms.Form
	{
		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// エラー詳細フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: エラー詳細フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
        public PMKYO01900UA(ArrayList errList)
		{
			InitializeComponent();

            if (null == errList)
            {
                _errList = new ArrayList();
            }
            else
            {
                _errList = errList;
            }

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 初期化データ
            SetGridLayout();

            // Gridでデータ表示
            ShowData();
		}

		#endregion

		#region -- Private Members --
		/*----------------------------------------------------------------------------------*/
        private ArrayList _errList;
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private DataSet _dataSet = new DataSet();
        private const string tableName = PMKYO01901EA.Tbl_ErrorInfoTable;
        // クラスID
        private const string ct_ClassID = "PMKYO01900UA";
        // プログラムID
        private const string ct_PGID = "PMKYO01900U";
        // 帳票名称
        private const string ct_PrintName = "エラー詳細";
        // 帳票キー	
        private const string ct_PrintKey = "ef11229a-f35a-43ba-8a15-c6721147f50f";

		private string _enterpriseCode;

        private const string COLUMN_0 = "slipCode";
        private const string COLUMN_1 = "noFlg";
        private const string COLUMN_2 = "no";
        private const string COLUMN_3 = "date";
        private const string COLUMN_4 = "sectionInfo";
        private const string COLUMN_5 = "customerInfo";
        private const string COLUMN_6 = "error";

        private const string SLIP_1 = "売上";
        private const string SLIP_2 = "入金";
        private const string SLIP_3 = "仕入";
        private const string SLIP_4 = "支払";

		#endregion

		#region -- Private Methods --
        /// <summary>
        /// Gridでデータ表示処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: Gridでエラー詳細情報を表示する</br>
        /// <br>Programmer	: 宋剛</br>
        /// <br>Date		: 2011.07.29</br>
        /// </remarks>
        private int ShowData()
        {
            int status = 0;

            if (_errList != null && _errList.Count > 0)　　　　　// データ存在する場合
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                // ボタン制御処理
                this.PDF_Button.Enabled = false;

                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // ステータス判断
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        this.uGrid_Details.BeginUpdate();

                        // Gridのデータ初期化処理
                        InitialRowData(_errList);

                        this.uGrid_Details.EndUpdate();

                        break;
                    }
            }

            return status;
        }

		/// <summary>
        /// Gridのデータ初期化処理
		/// </summary>
        /// <param name="errList">エラー詳細</param>
		/// <remarks>
		/// <br>Note       : グリッドに行を追加します。</br>
		/// <br>Programmer : 宋剛</br>
		/// <br>Date       : 2011.07.29</br>
		/// </remarks>
        private void InitialRowData(ArrayList errList)
		{
            foreach (PMKYO01901EA tempBean in errList)
			{
                DataRow dr = _dataTable.NewRow();

                dr[COLUMN_1] = tempBean.NoFlg;
                dr[COLUMN_2] = tempBean.No;
                dr[COLUMN_3] = tempBean.Date;
                dr[COLUMN_4] = tempBean.SectionCode + " " + tempBean.SectionNm;
                dr[COLUMN_5] = tempBean.CustomerCode + " " + tempBean.CustomerNm;
                dr[COLUMN_6] = tempBean.Error;

                if (SLIP_1.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "1";
                }
                else if (SLIP_2.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "2";
                }
                else if (SLIP_3.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "3";
                }
                else if (SLIP_4.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "4";
                }
                _dataTable.Rows.Add(dr);
			}

            _dataSet.Tables.Add(_dataTable);
		}

		/// <summary>
		/// グリッドレイアウト設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : グリッドレイアウトを設定します。</br>
		/// <br>Programmer : 宋剛</br>
		/// <br>Date       : 2011.07.29</br>
		/// </remarks>
		private void SetGridLayout()
		{

            _dataSet = new DataSet();
            _dataTable = new DataTable(tableName);

            _dataTable.Columns.Add(COLUMN_0, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_1, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_2, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_3, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_4, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_5, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_6, System.Type.GetType("System.String"));

            _dataView = _dataTable.DefaultView;
            _dataView.Sort = COLUMN_0 + "," + COLUMN_2 + "," + COLUMN_3 + "," + COLUMN_4 + "," + COLUMN_5;
            this.uGrid_Details.DataSource = _dataView;
            
			ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            //--------------------------------------
            // 表示不可
            //--------------------------------------
            columns[COLUMN_0].Hidden = true;

            //--------------------------------------
            // 入力不可
            //--------------------------------------
            columns[COLUMN_1].CellActivation = Activation.NoEdit;
            columns[COLUMN_2].CellActivation = Activation.NoEdit;
            columns[COLUMN_3].CellActivation = Activation.NoEdit;
            columns[COLUMN_4].CellActivation = Activation.NoEdit;
            columns[COLUMN_5].CellActivation = Activation.NoEdit;
            columns[COLUMN_6].CellActivation = Activation.NoEdit;


			// キャプション
			//--------------------------------------
            columns[COLUMN_1].Header.Caption = "伝票";
            columns[COLUMN_2].Header.Caption = "伝票番号";
            columns[COLUMN_3].Header.Caption = "日付";
            columns[COLUMN_4].Header.Caption = "拠点";
            columns[COLUMN_5].Header.Caption = "得意先/仕入先";
            columns[COLUMN_6].Header.Caption = "エラー内容";

			//--------------------------------------
			// 列幅
			//--------------------------------------
            columns[COLUMN_1].Width = 60;
            columns[COLUMN_2].Width = 100;
            columns[COLUMN_3].Width = 100;
            columns[COLUMN_4].Width = 180;
            columns[COLUMN_5].Width = 200;
            columns[COLUMN_6].Width = 200;

			//--------------------------------------
			// テキスト位置(VAlign)
			//--------------------------------------
			for (int index = 0; index < columns.Count; index++)
			{
				columns[index].CellAppearance.TextVAlign = VAlign.Middle;
			}
		}

		#endregion

		# region -- Control Events --
        /// <summary>
        /// Formロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKYO01900UA_Load(object sender, EventArgs e)
        {
            ImageList imageList = IconResourceManagement.ImageList32;

            this.PDF_Button.ImageList = imageList;
            this.Close_Button.ImageList = imageList;

            //this.PDF_Button.Appearance.Image = Size32_Index.LIST1; //DEL 2011/09/16 #25198
            this.PDF_Button.Appearance.Image = Size32_Index.PRINT; //ADD 2011/09/16 #25198
            this.Close_Button.Appearance.Image = Size32_Index.CLOSE;
        }
		/*----------------------------------------------------------------------------------*/

		/// <summary>
		/// イベント(PDF_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : PDFボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
		private void PDF_Button_Click(object sender, EventArgs e)
		{
            SFCMN06001U printDialog = new SFCMN06001U();		// 帳票選択ガイド
            SFCMN06002C printInfo = new SFCMN06002C();	// 印刷情報パラメータ

            //ADD 2011/09/01 #24288 出力設定の画面表示--------->>>>>
            // PDF出力設定の画面表示
            printInfo.printmode = 1;
            //ADD 2011/09/01 #24288 出力設定の画面表示---------<<<<<

            // 企業コードをセット
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// 起動PGID

            // PDF出力履歴用
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;
            printInfo.rdData = this._dataSet;

            printDialog.PrintInfo = printInfo;

            // 帳票選択ガイド
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません。", 0);
            }
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 宋剛</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
        private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/// <summary>
		/// ChangeFocus イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null)
			{
				return;
			}
		}

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date	   : 2011.07.29</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ct_ClassID,							// アセンブリＩＤまたはクラスＩＤ
                ct_PrintName,						// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
        #endregion
		#endregion
	}
}