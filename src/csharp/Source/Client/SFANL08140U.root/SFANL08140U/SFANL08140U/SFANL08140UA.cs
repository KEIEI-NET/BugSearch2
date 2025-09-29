using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using System.Threading;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自由帳票選択ガイドUIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置設定画面で使用されるガイドです。</br>
	///					: 次期改良時に帳票区分をvisible = trueに変更する
	/// <br>Programmer	: 30015　橋本 裕毅</br>
	/// <br>Date		: 2007.05.30</br>
	/// <br></br>
	/// </remarks>
    public partial class FPprSearchGuide : Form
    {
		#region Enum

		/// <summary>
		/// ガイド結果列挙
		/// </summary>
		public enum DialogRetCode
		{
			/// <summary>エラー</summary>
			Error = -1,
			/// <summary>戻る</summary>
			Return = 0,
			/// <summary>自由帳票の帳票</summary>
			FreePrt = 1,
			/// <summary>自由帳票の伝票</summary>
			FreeSlip = 2,
			/// <summary>既存帳票</summary>
			PrintPaper = 3,
			/// <summary>既存伝票</summary>
            Slip = 4,
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            ///// <summary>自由帳票のDM一覧表</summary>
            //FreeDMList = 5,
            ///// <summary>自由帳票のDMはがき</summary>
            //FreeDMPostCard = 6,
            ///// <summary>既存DM一覧表</summary>
            //DMList = 7,
            ///// <summary>既存DMはがき</summary>
            //DMPostCard = 8,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            /// <summary>自由帳票の請求書</summary>
            FreeDmdBill = 9,
            /// <summary>既存請求書</summary>
            DmdBill = 10,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
		}

		#endregion

// **** コンストラクタ **********************************************************************
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FPprSearchGuide()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; //　企業コード取得
            _frePrtGuideAcs = new FrePrtGuideAcs();
            _dsFrePrtGuide = new DataSet();
            DataTable dtFrePrt;
            CreateSchema( out dtFrePrt ); // 自由帳票ガイドデータスキーマ作成処理

            _dsFrePrtGuide.Tables.Add( dtFrePrt );

            this.setToolbarAppearance(); // Toolbar表示設定処理
        }

        #endregion

// **** Const *******************************************************************************
        #region Const

		private const string TBL_FrePrtGuide = "FrePrtGuide";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
        private const string COL_FREEPRTPPRITEMGRPNM = "FreePrtPprItemGrpNm"; // グループ名
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        private const string COL_OUTPUTFORMFILENAME = "OutputFormFileName"; // 帳票ID
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		private const string COL_DATAINPUTSYSTEMNM            	= "DataInputSystemNm";		    // データ入力システム名称
		private const string COL_DISPLAYNAME            		= "DisplayName";		        // 出力名称
		private const string COL_PRTPPRUSERDERIVNOCMT			= "PrtPprUserDerivNoCmt";		// 帳票ユーザー枝番コメント
		private const string COL_PRINTPAPERUSEDIVCD			    = "PrintPaperUseDivcd";		    // 帳票使用区分
		private const string COL_DATAINPUTSYSTEM           		= "DataInputSystem";		    // データ入力システム
		private const string COL_PRINTPAPERDIVCD            	= "PrintPaperDivCd";		    // 帳票区分コード
		private const string COL_FPPRSCHMGR                 	= "FPprSchmGr";		            // スキーマグループデータクラス
		private const string COL_FREPRTPSET                  	= "FrePrtPSet";	                // 印字位置設定データクラス

        #endregion

// **** Private Members *********************************************************************
        #region Private Members

        private string _enterpriseCode;　               // 企業コード
        private int printPaperUseDivcd;                 // 選択帳票
        private int printPaperDivCd;                    // 帳票区分
        private int[] dataInputSystemArray;             // データ入力システム

		private DialogRetCode _dialogRetCode;           // ダイアログリザルトコード
        private DataSet _dsFrePrtGuide;                	// 自由帳票DataSet
        private FrePrtGuideAcs _frePrtGuideAcs = null;　// 自由帳票選択ガイドアクセスクラス
		private FrePrtGuideSearchRet _frePrtGuideSearchRet = null;     // 自由帳票結果クラス
        private bool _dataflag = false;                 // 確定フラグ
		private bool _searchFlag = false;				// 検索対象フラグ(false;自由帳票,true;既存)
		private bool _optFreeSheetgMng = false;			// 自由帳票メンテナンスオプションフラグ
        //private DmGuideSnt _dmGuideSnt;
        //private DmPgMng _dmPgMng;
        private List<PrtItemGrpWork> _prtItemGrpWorkList;
        #endregion

// **** Property ****************************************************************************
        ///// <summary>
        ///// 案内文設定プロパティ
        ///// </summary>
        //public DmGuideSnt dmGuideSnt
        //{
        //    get { return _dmGuideSnt; }
        //    set { _dmGuideSnt = value; }
        //}

        ///// <summary>
        ///// DMプログラム管理プロパティ
        ///// </summary>
        //public DmPgMng dmPgMng
        //{
        //    get { return _dmPgMng; }
        //    set { _dmPgMng = value; }
        //}

        /// <summary>
        /// 自由帳票グループリスト
        /// </summary>
        public List<PrtItemGrpWork> PrtItemGrpList
        {
            get { return _prtItemGrpWorkList; }
            set { _prtItemGrpWorkList = value; }
        }
	
// **** Public Method ***********************************************************************
        #region Public Method

        /// <summary>
		/// 自由帳票選択ガイドを表示する
		/// </summary>
        /// <param name="frePrtGuideSearchRet"></param>
		/// <returns>列挙体</returns>
		/// <remarks>
		/// <br>Note		: フォームが呼び出された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        public DialogRetCode ShowFrePrtGuide( out FrePrtGuideSearchRet frePrtGuideSearchRet )
        {
			try
			{
                _dialogRetCode = DialogRetCode.Return;
				this.ShowDialog();
			}
			catch ( Exception ex )
			{
				string message = "自由帳票選択ガイドにて例外が発生しました。\r\n" + ex.Message;
				TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, message, 0, MessageBoxButtons.OK );
				_dialogRetCode = DialogRetCode.Error;
			}

			frePrtGuideSearchRet = _frePrtGuideSearchRet;

			return _dialogRetCode;

        }
        #endregion

// **** Private Methods *********************************************************************
        #region Private Methods

		/// <summary>
		/// グリッド更新処理
		/// </summary>
		/// <param name="alTarget">検索結果オブジェクト</param>
		/// <remarks>
		/// <br>Note        : グリッドの内容を更新します</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void ExtendToGrid( ArrayList alTarget )
		{
            _dsFrePrtGuide.Tables[TBL_FrePrtGuide].Rows.Clear();
			//データの行は隠す
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRINTPAPERUSEDIVCD].Hidden       = true;
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_DATAINPUTSYSTEM].Hidden          = true;
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRINTPAPERDIVCD].Hidden          = true;
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_FPPRSCHMGR].Hidden               = true;
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_FREPRTPSET].Hidden               = true;

            //データが無いときはなにもしない
			if( alTarget == null )
			{
				return;
            }

			int count = 0; // 行数
            // 自由帳票の場合
			if(!_searchFlag)
            {
                foreach ( FrePrtPSet retPSet in alTarget )
                {
                    DataRow drAdd = _dsFrePrtGuide.Tables[TBL_FrePrtGuide].NewRow();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
                    drAdd[COL_FREEPRTPPRITEMGRPNM] = GetGrpName( retPSet.FreePrtPprItemGrpCd );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                    drAdd[COL_OUTPUTFORMFILENAME] = retPSet.OutputFormFileName;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                    drAdd[COL_DISPLAYNAME]         = retPSet.DisplayName;
					drAdd[COL_PRTPPRUSERDERIVNOCMT] = retPSet.PrtPprUserDerivNoCmt;
                    drAdd[COL_DATAINPUTSYSTEMNM]   = DataInputSystemSetting( retPSet.DataInputSystem );
                    drAdd[COL_PRINTPAPERUSEDIVCD]  = printPaperUseDivcd;
                    drAdd[COL_DATAINPUTSYSTEM]     = retPSet.DataInputSystem;
                    // 帳票の場合
                    if ( printPaperUseDivcd == 1 )
                    {
                        drAdd[COL_PRINTPAPERDIVCD]   = printPaperDivCd;
                    }
                    drAdd[COL_FREPRTPSET]          = retPSet;
                    _dsFrePrtGuide.Tables[TBL_FrePrtGuide].Rows.Add( drAdd );

					this.ChangeColorOfSystemDiv(retPSet.DataInputSystem, count);
					count++;
                }
            }
            // 既存の場合
            else
            {
                foreach ( FPprSchmGr retSchm in alTarget )
                {
                    DataRow drAdd = _dsFrePrtGuide.Tables[TBL_FrePrtGuide].NewRow();
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                    drAdd[COL_OUTPUTFORMFILENAME] = retSchm.OutputFormFileName;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                    drAdd[COL_DISPLAYNAME]         = retSchm.DisplayName;
                    drAdd[COL_DATAINPUTSYSTEMNM]   = DataInputSystemSetting( retSchm.DataInputSystem );
                    drAdd[COL_PRINTPAPERUSEDIVCD]  = printPaperUseDivcd;
                    drAdd[COL_DATAINPUTSYSTEM]     = retSchm.DataInputSystem;
                    // 帳票の場合
                    if ( printPaperUseDivcd == 1 )
                    {
                        drAdd[COL_PRINTPAPERDIVCD] = printPaperDivCd;
                    }
                    drAdd[COL_FPPRSCHMGR]          = retSchm;
                    _dsFrePrtGuide.Tables[TBL_FrePrtGuide].Rows.Add( drAdd );

					this.ChangeColorOfSystemDiv(retSchm.DataInputSystem, count);
					count++;
                }
            }

		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
        /// <summary>
        /// 自由帳票グループ名取得
        /// </summary>
        /// <param name="grpCode"></param>
        /// <returns></returns>
        private string GetGrpName( int grpCode )
        {
            if ( _prtItemGrpWorkList == null ) return string.Empty;

            PrtItemGrpWork grpWork = _prtItemGrpWorkList.Find(
                                        delegate(PrtItemGrpWork target)
                                        {
                                            return (target.FreePrtPprItemGrpCd == grpCode);
                                        } );

            if ( grpWork != null )
            {
                return grpWork.FreePrtPprItemGrpNm;
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD

		/// <summary>
		/// 確定押下時処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 確定が押されたときの処理です</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void OkClick()
		{
            // 選択行がある場合
			if( this.FPprGrid.ActiveRow != null )
			{
                _frePrtGuideSearchRet = new FrePrtGuideSearchRet();
                FrePrtPSet targetPrtPSet = new FrePrtPSet();
                FPprSchmGr targetSchmGr = new FPprSchmGr();

                // 自由帳票の場合
				if(!_searchFlag)
                {
                    targetPrtPSet = this.FPprGrid.ActiveRow.Cells[COL_FREPRTPSET].Value as FrePrtPSet;

                    // キー情報の取得
                    this._frePrtGuideSearchRet.UpdateDateTime       = targetPrtPSet.UpdateDateTime;         // 更新日付
                    this._frePrtGuideSearchRet.OutputFormFileName   = targetPrtPSet.OutputFormFileName;     // 出力ファイル名
                    this._frePrtGuideSearchRet.UserPrtPprIdDerivNo  = targetPrtPSet.UserPrtPprIdDerivNo;    // ユーザー帳票ID枝番号
                    this._frePrtGuideSearchRet.PrtPprUserDerivNoCmt = targetPrtPSet.PrtPprUserDerivNoCmt;   // 帳票ユーザー枝番コメント
                    this._frePrtGuideSearchRet.FreePrtPprItemGrpCd  = targetPrtPSet.FreePrtPprItemGrpCd;    // 自由帳票項目グループコード

					switch ( printPaperUseDivcd )
					{
						// 帳票
						case 1:
							_dialogRetCode = DialogRetCode.FreePrt;
							break;
						// 伝票
						case 2:
							_dialogRetCode = DialogRetCode.FreeSlip;
							break;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                        //// DM一覧表
                        //case 3:
                        //    _dialogRetCode = DialogRetCode.FreeDMList;
                        //    break;
                        //// DMはがき
                        //case 4:
                        //    _dialogRetCode = DialogRetCode.FreeDMPostCard;
                        //    break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                        case 5:
                            _dialogRetCode = DialogRetCode.FreeDmdBill;
                            break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					}

					_dataflag = true;
					this.Close();
                }
                // 既存の場合
                else
                {
                    targetSchmGr = this.FPprGrid.ActiveRow.Cells[COL_FPPRSCHMGR].Value as FPprSchmGr;

                    // キー情報の取得
                    this._frePrtGuideSearchRet.UpdateDateTime       = targetSchmGr.UpdateDateTime;      // 更新日付
                    this._frePrtGuideSearchRet.FreePrtPprSchmGrpCd  = targetSchmGr.FreePrtPprSchmGrpCd; // 自由帳票スキーマグループコード
					this._frePrtGuideSearchRet.DisplayName			= targetSchmGr.DisplayName;			// 表示名称
                    this._frePrtGuideSearchRet.OutputFormFileName   = targetSchmGr.OutputFormFileName;  // 出力ファイル名
                    this._frePrtGuideSearchRet.OutputFileClassId    = targetSchmGr.OutputFileClassId;   // 出力ファイルクラスID
                    this._frePrtGuideSearchRet.FreePrtPprItemGrpCd  = targetSchmGr.FreePrtPprItemGrpCd; // 自由帳票項目グループコード
                    this._frePrtGuideSearchRet.DataInputSystem      = targetSchmGr.DataInputSystem;     // データ入力システム
                    int wkPrintPaperUseDivcd                        = ( int )this.FPprGrid.ActiveRow.Cells[COL_PRINTPAPERUSEDIVCD].Value; // 帳票使用区分
                    this._frePrtGuideSearchRet.PrintPaperUseDivcd   = wkPrintPaperUseDivcd;
					this._frePrtGuideSearchRet.SpecialConvtUseDivCd = targetSchmGr.SpecialConvtUseDivCd; // 特種コンバート使用区分
					this._frePrtGuideSearchRet.OptionCode			= targetSchmGr.OptionCode;			// オプションコード
					this._frePrtGuideSearchRet.FormFeedLineCount	= targetSchmGr.FormFeedLineCount;	// 改頁行数
					this._frePrtGuideSearchRet.CrCharCnt			= targetSchmGr.CrCharCnt;			// 改行文字数
					this._frePrtGuideSearchRet.TopMargin			= targetSchmGr.TopMargin;			// 上余白
					this._frePrtGuideSearchRet.LeftMargin			= targetSchmGr.LeftMargin;			// 左余白
					this._frePrtGuideSearchRet.RightMargin			= targetSchmGr.RightMargin;			// 右余白
					this._frePrtGuideSearchRet.BottomMargin			= targetSchmGr.BottomMargin;		// 下余白

					// 案内文表示判断クラスで条件が合えば案内文選択ガイドを開く
					if((targetSchmGr.SpecialConvtUseDivCd == 1) || 
						(targetSchmGr.SpecialConvtUseDivCd == 2))
					{
						// 案内文選択ガイド
						SFANL08140UB sFANL08140UB = new SFANL08140UB();

						// TODO: ここでメソッドを呼び、戻り値は案内文はがき
						_dialogRetCode = sFANL08140UB.ShowDmGuideSnt(_enterpriseCode, ref _frePrtGuideSearchRet);

						switch (_dialogRetCode)
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                            //// DMはがき
                            //case DialogRetCode.DMPostCard:
                            //    _dataflag = true;
                            //    this.Close();
                            //    break;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
							case DialogRetCode.Return:
								break;
						}
					}
					else
					{
						switch (wkPrintPaperUseDivcd)
						{
							// 帳票
							case 1:
								_dialogRetCode = DialogRetCode.PrintPaper;
								break;
							// 伝票
							case 2:
								_dialogRetCode = DialogRetCode.Slip;
								break;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                            //// DM一覧表
                            //case 3:
                            //    _dialogRetCode = DialogRetCode.DMList;
                            //    break;
                            //// DMはがき
                            //case 4:
                            //    _dialogRetCode = DialogRetCode.DMPostCard;
                            //    break;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                            case 5:
                                _dialogRetCode = DialogRetCode.DmdBill;
                                break;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
						}

						_dataflag = true;
						this.Close();
					}
                }
			}
		}
		
		/// <summary>
		/// 戻る押下時処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 戻るが押されたときの処理です</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void CancelClick()
		{
            this.Close();
		}
		
		/// <summary>
		/// 検索押下時処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 検索が押されたときの処理です</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void SearchClick()
        {
            ArrayList retList = new ArrayList();
            int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
            bool msgDiv = false; // メッセージ区分
            string errMsg = String.Empty; // エラーメッセージ

			printPaperUseDivcd = ( int )this.PrintPaperUseDivcd_tComboEditor.SelectedItem.DataValue; // 選択帳票

            this.DataInputSystemDiv(); // データ入力システム選択抽出処理

			// 既存帳票の場合のみ
			if ((this.PrintPaperUseDivcd_tComboEditor.SelectedIndex == 0) && (this.SearchOptionSet.ValueList.SelectedIndex == 1))
			{
				printPaperDivCd = 1;
			}
			else
			{
				printPaperDivCd = 0;
			}
			 
			if (this.panel2.Visible)
			{
				if ((this.PrintPaperUseDivcd_tComboEditor.SelectedIndex == 0) && (this.SearchOptionSet.ValueList.SelectedIndex == 1))
				{
					printPaperDivCd = (int)PrintPaperDivCd_tComboEditor.SelectedItem.DataValue; // 帳票区分
				}
			}

			// 自由帳票メンテナンスオプションフラグが立ってない場合
			if (!_optFreeSheetgMng)
			{
				status = this._frePrtGuideAcs.SearchFrePrtPSetDLDB(_enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray, out retList, out msgDiv, out errMsg);
			}
			else
			{
				//　自由帳票の場合
				if (this.SearchOptionSet.ValueList.SelectedIndex == 0)
				{
					status = this._frePrtGuideAcs.SearchFrePrtPSetDLDB(_enterpriseCode, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray, out retList, out msgDiv, out errMsg);
				}
				// 既存の場合
				else
				{
					status = this._frePrtGuideAcs.SearchFPprSchmGr(out retList, out msgDiv, out errMsg, printPaperUseDivcd, printPaperDivCd, dataInputSystemArray);
				}
			}
            if ( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
            {
				// 検索対象フラグを切り替える
				if (!_optFreeSheetgMng)
				{
					_searchFlag = false;
				}
				else
				{
					if ( this.SearchOptionSet.ValueList.SelectedIndex == 0 ) _searchFlag = false; // 自由帳票
					else _searchFlag = true; // 既存
				}

                this.ExtendToGrid( retList );  //グリッドに結果を表示する

                this.ultraToolbarsManager1.Tools["Deside_Button"].SharedProps.Enabled = true; // 確定ボタン復活

				// 自由帳票メンテナンスオプションフラグが立ってない場合
				if (!_optFreeSheetgMng)
				{
					//this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false; // 削除ボタン復活
				    this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Hidden = false;
				}
				else
				{
				    if ( this.SearchOptionSet.ValueList.SelectedIndex == 0 )
				    {
				        this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = true; // 削除ボタン復活
				        this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Hidden = false;
				    }
				    else
				    {
				        this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false;
				        this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Hidden = true;
				    }
				}

                if ( !this.FPprGrid.Focused )
                {
                    this.FPprGrid.Focus();
                }
                else
                {
                    this.FPprGrid.Rows[0].Activate();
                }
            }
            else
            {
                if ( msgDiv == true )
                {
                    TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                        "SFTKD08140U",                      // アセンブリIDまたはクラスＩＤ
                        "自由帳票ガイドUIクラス",           // プログラム名称
                        "Search",                           // 処理名称
                        TMsgDisp.OPE_GET,                   // オペレーション
                        "自由帳票の検索データ取得に失敗しました。"
                        + "\r\n\r\n" +
                        "*詳細 = " + errMsg,                // サーバーからのメッセージ表示
                        status,                             // ステータス表示
                        this._frePrtGuideAcs,               // エラーが発生したオブジェクト
                        MessageBoxButtons.OK,               // 表示するボタン
                        MessageBoxDefaultButton.Button1);   // 初期表示ボタン
                }
                else
                {
                    if ( status == ( int )ConstantManagement.DB_Status.ctDB_ERROR )
                    {
                        TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, "SFANL08140U", "自由帳票ガイドの検索に失敗しました。", status, MessageBoxButtons.OK );
                    }
                    else if ( status == ( int )ConstantManagement.DB_Status.ctDB_EOF )
                    {
                        TMsgDisp.Show( emErrorLevel.ERR_LEVEL_INFO, "SFANL08140U", "該当するデータが見つかりませんでした。", status, MessageBoxButtons.OK );
                    }
                    
                    _dsFrePrtGuide.Tables[TBL_FrePrtGuide].Rows.Clear();

                }
				this.ultraToolbarsManager1.Tools["Deside_Button"].SharedProps.Enabled = false; // 2007.11.21 キャッチボール対応
				this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false;

				// 自由帳票メンテナンスオプションフラグが立ってない場合
				if (!_optFreeSheetgMng)
				{
					//this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false; // 削除ボタン復活
				    this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Hidden = false;
				}
				else
				{
				    if ( this.SearchOptionSet.ValueList.SelectedIndex == 0 )
				    {
				        this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Hidden = false;
				    }
				    else
				    {
				        this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Hidden = true;
				    }
			        this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false; // 削除ボタン復活
				}
            }

        }

		/// <summary>
		/// 削除押下時処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 削除が押されたときの処理です</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void DeleteClick()
		{
            if ( this.FPprGrid.ActiveRow != null )
            {
                // 自由帳票印字位置DLアクセスクラス
                SFANL08230AE _frePrtPSetAcs = new SFANL08230AE();
                FrePrtPSetWork _frePrtPSetWork = new FrePrtPSetWork();
                int status = ( int )ConstantManagement.DB_Status.ctDB_EOF;

                // 削除できるのは自由帳票のみ
                if ( this.FPprGrid.ActiveRow.Cells[COL_FREPRTPSET].Value != null )
                {
                    FrePrtPSet frePrtPSet = this.FPprGrid.ActiveRow.Cells[COL_FREPRTPSET].Value as FrePrtPSet;

					string msg = frePrtPSet.DisplayName + "\n\r\n\rデータベースから印字位置データを削除します\n\r削除すると元に戻すことはできません\n\r実行しますか？";
					// 完全削除確認
					DialogResult result = TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFTOK08140U", 						// アセンブリＩＤまたはクラスＩＤ
						msg, 								// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OKCancel, 		// 表示するボタン
						MessageBoxDefaultButton.Button2);	// 初期表示ボタン

					if (result == DialogResult.OK)
					{

						// キー情報
						_frePrtPSetWork.UpdateDateTime = frePrtPSet.UpdateDateTime; // 更新日付
						_frePrtPSetWork.EnterpriseCode = _enterpriseCode;	// 企業コード
						_frePrtPSetWork.OutputFormFileName = frePrtPSet.OutputFormFileName;　// 出力ファイル名
						_frePrtPSetWork.UserPrtPprIdDerivNo = frePrtPSet.UserPrtPprIdDerivNo; // ユーザー帳票ID枝番号
						_frePrtPSetWork.PrintPaperUseDivcd = printPaperUseDivcd; // 帳票使用区分
						_frePrtPSetWork.DataInputSystem = frePrtPSet.DataInputSystem; // データ入力システム
						_frePrtPSetWork.TakeInImageGroupCd = frePrtPSet.TakeInImageGroupCd; // 背景画像

						string errMsg = "";
						bool msgDiv;

						status = _frePrtPSetAcs.Delete(_frePrtPSetWork, out msgDiv, out errMsg);

						if (msgDiv)
						{
							TMsgDisp.Show(
								this, 								// 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_STOPDISP, 	// エラーレベル
								"SFANL08140U", 						// アセンブリＩＤまたはクラスＩＤ
								"自由帳票選択ガイドUIクラス",		// プログラム名称
								"Delete_Button",                    // 処理名称
								TMsgDisp.OPE_DELETE, 				// オペレーション
								"タイムアウトが発生しました。"		// 表示するメッセージ
								+ "\r\n\r\n" +
								"*詳細 = " + errMsg,
								status, 							// ステータス値
								_frePrtPSetAcs,      				// エラーが発生したオブジェクト
								MessageBoxButtons.OK, 				// 表示するボタン
								MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						}
						else
						{
							switch (status)
							{
								case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
									{
										this._dsFrePrtGuide.Tables[TBL_FrePrtGuide].Rows[FPprGrid.ActiveRow.Index].Delete(); // 選択行の削除

										// まだ行があるなら、1行目をアクティブにする
										if (this.FPprGrid.Rows.Count <= 0)
										{
											this.ultraToolbarsManager1.Tools["Deside_Button"].SharedProps.Enabled = false;
											this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false;
										}
										else
										{
											this.FPprGrid.Rows[0].Activate();
										}
										break;
									}
								case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
									// 他端末削除
									TMsgDisp.Show(
										this, 								// 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
										"SFANL08140U", 						// アセンブリＩＤまたはクラスＩＤ
										"既に他端末より更新されています。", // 表示するメッセージ
										0, 									// ステータス値
										MessageBoxButtons.OK);				// 表示するボタン
									break;
								case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
									// 他端末削除
									TMsgDisp.Show(
										this, 								// 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
										"SFANL08140U", 						// アセンブリＩＤまたはクラスＩＤ
										"既に他端末より削除されています。", // 表示するメッセージ
										0, 									// ステータス値
										MessageBoxButtons.OK);				// 表示するボタン
									break;
								default:
									// 物理削除
									TMsgDisp.Show(
										this, 								// 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
										"SFANL08140U", 						// アセンブリＩＤまたはクラスＩＤ
										"自由帳票選択ガイドUIクラス",		// プログラム名称
										"Delete_Button",                    // 処理名称
										TMsgDisp.OPE_DELETE, 				// オペレーション
										"削除に失敗しました。", 			// 表示するメッセージ
										status, 							// ステータス値
										_frePrtPSetAcs,      				// エラーが発生したオブジェクト
										MessageBoxButtons.OK, 				// 表示するボタン
										MessageBoxDefaultButton.Button1);	// 初期表示ボタン
									break;
							}
						}
					}
                }
            }
        }

        /// <summary>
		/// システム区分色変換処理
		/// </summary>
		/// <param name="dataInputSystem">データ入力システム</param>
		/// <param name="count">行</param>
		/// <remarks>
		/// <br>Note        : 初期情報をセッティング</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.11.14</br>
		/// </remarks>
		private void ChangeColorOfSystemDiv(int dataInputSystem, int count)
		{
			switch (dataInputSystem)
			{
			    case 1: // 整備は青色
			        this.FPprGrid.Rows[count].Cells[COL_DATAINPUTSYSTEMNM].Appearance.ForeColor = Color.Blue;
			        break;
			    case 2: // 鈑金は緑色
			        this.FPprGrid.Rows[count].Cells[COL_DATAINPUTSYSTEMNM].Appearance.ForeColor = Color.Green;
			        break;
			    case 3: // 車販は紫色
			        this.FPprGrid.Rows[count].Cells[COL_DATAINPUTSYSTEMNM].Appearance.ForeColor = Color.Purple;
			        break;
			    default: // 共通は黒色
			        this.FPprGrid.Rows[count].Cells[COL_DATAINPUTSYSTEMNM].Appearance.ForeColor = Color.Black;
			        break;
			}
		}

        /// <summary>
		/// データ入力システム選択抽出処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 初期情報をセッティング</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void DataInputSystemDiv()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            //if (( SF_ultraCheckEditor.Checked ) && ( !BK_ultraCheckEditor.Checked ) && ( !CS_ultraCheckEditor.Checked ))
            //    dataInputSystemArray = new int[] { 0, 1 }; // 整備のみ

            //else if (( !SF_ultraCheckEditor.Checked ) && ( BK_ultraCheckEditor.Checked ) && ( !CS_ultraCheckEditor.Checked ))
            //    dataInputSystemArray = new int[] { 0, 2 }; // 鈑金のみ

            //else if (( !SF_ultraCheckEditor.Checked ) && ( !BK_ultraCheckEditor.Checked ) && ( CS_ultraCheckEditor.Checked ))
            //    dataInputSystemArray = new int[] { 0, 3 }; // 車販のみ

            //else if (( SF_ultraCheckEditor.Checked ) && ( BK_ultraCheckEditor.Checked ) && ( !CS_ultraCheckEditor.Checked ))
            //    dataInputSystemArray = new int[] { 0, 1, 2 }; // 整備と鈑金

            //else if (( SF_ultraCheckEditor.Checked ) && ( !BK_ultraCheckEditor.Checked ) && ( CS_ultraCheckEditor.Checked ))
            //    dataInputSystemArray = new int[] { 0, 1, 3 }; // 整備と車販

            //else if (( !SF_ultraCheckEditor.Checked ) && ( BK_ultraCheckEditor.Checked ) && ( CS_ultraCheckEditor.Checked ))
            //    dataInputSystemArray = new int[] { 0, 2, 3 }; // 鈑金と車販

            //else
            //    dataInputSystemArray = new int[] { 0, 1, 2, 3 }; // 整備と鈑金と車販
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            dataInputSystemArray = new int[] { 0 } ;   // 0:共通のみ
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
        }

        /// <summary>
		/// データ入力システム名称セッティング処理
	    /// </summary>
        /// <param name="tgtDataInputSystem">選択されたデータ入力システム</param>
        /// <returns>データ入力システム名称</returns>
        /// <remarks>
		/// <br>Note		: 選択されたデータ入力システムの名称です。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private string DataInputSystemSetting( int tgtDataInputSystem )
        {
            string sysName = String.Empty;
            if( tgtDataInputSystem == 0) sysName = "共通";
            else if( tgtDataInputSystem == 1 ) sysName = "整備";
            else if( tgtDataInputSystem == 2 ) sysName = "鈑金";
            else if( tgtDataInputSystem == 3 ) sysName = "車販";
            
            return sysName;
        }

		/// <summary>
		/// 帳票使用区分切替処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 帳票使用区分が切り替わった時の処理です。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void ChangeDivProc()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            //switch (this.PrintPaperUseDivcd_tComboEditor.SelectedIndex)
            //{
            //    case 0:
            //        {
            //            this.SF_ultraCheckEditor.Enabled = true;
            //            this.BK_ultraCheckEditor.Enabled = true;
            //            this.CS_ultraCheckEditor.Enabled = true;
            //            this.PrintPaperDivCd_tComboEditor.Enabled = true;
            //            this.PrintPaperDivCd_tComboEditor.SelectedIndex = 0;
            //        }
            //        break;
            //    case 1:
            //        {
            //            this.SF_ultraCheckEditor.Enabled = true;
            //            this.BK_ultraCheckEditor.Enabled = true;
            //            this.CS_ultraCheckEditor.Enabled = true;
            //            this.PrintPaperDivCd_tComboEditor.Enabled = false;
            //        }
            //        break;
            //    case 2:
            //    case 3:
            //        {
            //            this.SF_ultraCheckEditor.Enabled = false;
            //            this.BK_ultraCheckEditor.Enabled = false;
            //            this.CS_ultraCheckEditor.Enabled = false;
            //            this.PrintPaperDivCd_tComboEditor.Enabled = false;
            //        }
            //        break;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            this.PrintPaperDivCd_tComboEditor.Enabled = true;
            this.PrintPaperDivCd_tComboEditor.SelectedIndex = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 画面を初期化します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void InitializeDisplay()
		{
            this.FPprGrid.DataSource = _dsFrePrtGuide;
            this.FPprGrid.DataMember = TBL_FrePrtGuide;
            
            this.setGridAppearance( this.FPprGrid ); // UltraGrid配色設定処理

            this.setGridBehavior( this.FPprGrid ); // UltraGrid挙動設定処理
			
            this.setGridColumnWidth(); // UltraGrid列幅設定処理


            this.ultraToolbarsManager1.Tools["Deside_Button"].SharedProps.Enabled = false;
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
            //this.SF_ultraCheckEditor.Checked = true; // 整備
            //this.BK_ultraCheckEditor.Checked = true; // 鈑金
            //this.CS_ultraCheckEditor.Checked = true; // 車販
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
			
			// 自由帳票メンテナンスオプション有無取得
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
			//PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FreeSheetgMng);
            PurchaseStatus status = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB( ConstantManagement_SF_PRO.SoftwareCode_PAC_PM );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			if (status < PurchaseStatus.Contract)
			{
				_optFreeSheetgMng = false;
				// 抽出区分をvisible=falseにする
				this.Extraction_panel.Visible = false;
				this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Visible = false;
			}
			else
			{
				_optFreeSheetgMng = true;
				// 抽出区分をvisible=trueにする
				this.Extraction_panel.Visible = true;
				this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Visible = true;
				this.ultraToolbarsManager1.Tools["Delete_Button"].SharedProps.Enabled = false;
			}

            _dsFrePrtGuide.Tables[TBL_FrePrtGuide].Rows.Clear();
		}

		/// <summary>
		/// 自由帳票ガイドデータテーブルスキーマ作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 自由帳票ガイドのスキーマを作成します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void CreateSchema( out DataTable dtFrePrt )
		{
			//列を設定
			dtFrePrt = new DataTable(TBL_FrePrtGuide );
			dtFrePrt.Columns.Add( COL_DATAINPUTSYSTEMNM	, typeof( string ) );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
            dtFrePrt.Columns.Add( COL_FREEPRTPPRITEMGRPNM, typeof( string ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            dtFrePrt.Columns.Add( COL_OUTPUTFORMFILENAME, typeof( string ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			dtFrePrt.Columns.Add( COL_DISPLAYNAME		, typeof( string ) );
			dtFrePrt.Columns.Add( COL_PRTPPRUSERDERIVNOCMT, typeof( string ) );
			dtFrePrt.Columns.Add( COL_PRINTPAPERUSEDIVCD, typeof( int ) );
			dtFrePrt.Columns.Add( COL_DATAINPUTSYSTEM	, typeof( int ) );
			dtFrePrt.Columns.Add( COL_PRINTPAPERDIVCD	, typeof( int ) );
			dtFrePrt.Columns.Add( COL_FPPRSCHMGR		, typeof( FPprSchmGr ) );
			dtFrePrt.Columns.Add( COL_FREPRTPSET		, typeof( FrePrtPSet ) );
        }

        #endregion

// **** Control Events **********************************************************************
        #region Control Events

        /// <summary>
	    /// ultraToolbarsManager_ToolClickイベント
	    /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : ツールバーのボタンをクリックした時のイベントです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch ( e.Tool.Key )
            {
                case "Deside_Button": // 確定
                    {
                        this.OkClick();
                        break;
                    }
                case "Return_Button": // 戻る
                    {
                        this.CancelClick();
                        break;
                    }
                case "Search_Button": // 検索
                    {
                        this.SearchClick();
                        break;
                    }
                case "Delete_Button": // 削除
                    {
                        this.DeleteClick();
                        break;
                    }
            }
		}

		/// <summary>
		/// tComboEditor_ValueChangedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 帳票使用区分が変更された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void SlipOrPrtPprDivCd_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            ChangeDivProc(); // 帳票使用区分切替処理
        }

		/// <summary>
		/// FPprSearchGuide_Loadイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが呼び出された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void FPprSearchGuide_Load(object sender, EventArgs e)
        {
			// 画面初期化
			InitializeDisplay();
            this.PrintPaperUseDivcd_tComboEditor.SelectedIndex = 0; 

			if (!_optFreeSheetgMng)
			{
				this.PrintPaperUseDivcd_tComboEditor.Focus();
			}
			else
			{
				this.SearchOptionSet.CheckedIndex = 0;
				this.SearchOptionSet.FocusedIndex = 0;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            this.Extraction_panel.Visible = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

			// 2007.12.11 次期改良まで帳票区分はvisible=false
			this.panel2.Visible = false;

			this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        ///	SFANL08140UA_Closingイベント
        /// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note			: フォームを閉じる前に、ユーザーがフォームを閉じ
        ///						  ようとしたときに発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.04</br>
        /// </remarks>
        private void FPprSearchGuide_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 確定フラグが立っていない場合
            if( !_dataflag )
            {
                _dialogRetCode = DialogRetCode.Return;
            }
        }

		/// <summary>
		/// FPprGrid_InitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票グリッドが初期化された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		private void FPprGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
            e.Layout.Bands[0].Columns[COL_DATAINPUTSYSTEMNM].Header.Caption
                = "システム";
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
            e.Layout.Bands[0].Columns[COL_DATAINPUTSYSTEMNM].Hidden
                = true;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
            e.Layout.Bands[0].Columns[COL_FREEPRTPPRITEMGRPNM].Header.Caption
                = "帳票種別";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            e.Layout.Bands[0].Columns[COL_OUTPUTFORMFILENAME].Header.Caption
                = "帳票ＩＤ";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			e.Layout.Bands[0].Columns[COL_DISPLAYNAME].Header.Caption
				= "帳票名称";
			e.Layout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Header.Caption
				= "コメント";
            e.Layout.Bands[0].Columns[COL_PRINTPAPERUSEDIVCD].Header.Caption
                = "帳票使用区分";
            e.Layout.Bands[0].Columns[COL_PRINTPAPERUSEDIVCD].Hidden
                = true;
            e.Layout.Bands[0].Columns[COL_DATAINPUTSYSTEM].Header.Caption
                = "データ入力システム";
            e.Layout.Bands[0].Columns[COL_DATAINPUTSYSTEM].Hidden
                = true;
            e.Layout.Bands[0].Columns[COL_PRINTPAPERDIVCD].Header.Caption
                = "帳票区分コード";
            e.Layout.Bands[0].Columns[COL_PRINTPAPERDIVCD].Hidden
                = true;
            e.Layout.Bands[0].Columns[COL_FPPRSCHMGR].Header.Caption
                = "スキーマグループデータクラス";
            e.Layout.Bands[0].Columns[COL_FPPRSCHMGR].Hidden
                = true;
            e.Layout.Bands[0].Columns[COL_FREPRTPSET].Header.Caption
                = "印字位置設定ワーククラス";
            e.Layout.Bands[0].Columns[COL_FREPRTPSET].Hidden
                = true;
		}

		/// <summary>
		/// Initial_Timer_Tickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 初期化タイマーイベントです。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;
        }

		/// <summary>
		/// FPprSearchGuide_KeyDownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : Escボタンで画面を終了させるイベント</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void FPprSearchGuide_KeyDown(object sender, KeyEventArgs e)
        {
			if ( e.KeyCode == Keys.Escape )
			{
				// 戻るボタン押下処理
				ToolClickEventArgs ev = new ToolClickEventArgs( this.ultraToolbarsManager1.Tools["Return_Button"], new ListToolItem() ) ;
				ultraToolbarsManager1_ToolClick( sender, ev );
			}
        }

        #region グリッド内部処理
		/// <summary>
		/// FPprGrid_AfterRowActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : グリッドの列がアクティブになったときの処理</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void FPprGrid_AfterRowActivate(object sender, System.EventArgs e)
		{
			if( this.FPprGrid.ActiveRow == null )
			{
				return;
			}
			this.FPprGrid.ActiveRow.Selected = true;
        }

        /// <summary>
		/// FPprGrid_DoubleClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : グリッドがダブルクリックされたときの処理</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void FPprGrid_DoubleClick(object sender, EventArgs e)
		{
			UltraGridRow ultraGridRow = this.FPprGrid.ActiveRow;
			// マウスポインタがグリッドのどの位置にあるかを判定する
			Point point = System.Windows.Forms.Cursor.Position;
			point = this.FPprGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement	objRowCellAreaUIElement = null;
			objElement = this.FPprGrid.DisplayLayout.UIElement.ElementFromPoint(point);
			
			objRowCellAreaUIElement= (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));
			
			// ヘッダ部の場合は以下の処理をキャンセルします。
			if(objRowCellAreaUIElement == null)
			{
				return;
			}

			if ( ultraGridRow != null )
			{
			    this.OkClick();
			}
		}


		/// <summary>
		/// tArrowKeyControl1_ChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note        : 方向キーでフォーカスが変更されるイベント</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			// グリッド上でEnterキーが押下された場合は確定と同じ動きを行う
			if (( e.PrevCtrl == this.FPprGrid ) &&
				( e.Key == Keys.Enter ))
			{
				e.NextCtrl = null;

				KeyEventArgs keyEvent = new KeyEventArgs( e.Key );
				this.FPprGrid_KeyDown( sender, keyEvent );
                return;
			}

			if (e.NextCtrl == this.FPprGrid)
			{
				if (e.Key == Keys.Down
					&& ((UltraGrid)e.NextCtrl).Rows.Count <= 0)
				{
					e.NextCtrl = e.PrevCtrl;
					return;
				}

				if (e.Key == Keys.Enter
					&& ((UltraGrid)e.NextCtrl).Rows.Count <= 0)
				{
					if ((this.PrintPaperUseDivcd_tComboEditor.DroppedDown) || (this.PrintPaperDivCd_tComboEditor.DroppedDown))
					{
						return;
					}
				}
			}
			else
			{
				if (_optFreeSheetgMng)
				{
					if (e.PrevCtrl == this.SearchOptionSet)
					{
						this.PrintPaperUseDivcd_tComboEditor.Focus();
						return;
					}
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                //if ((e.PrevCtrl == this.PrintPaperUseDivcd_tComboEditor))
                //{
                //    this.SF_ultraCheckEditor.Focus();
                //    return;
                //}

                //if (e.PrevCtrl == this.SF_ultraCheckEditor)
                //{
                //    this.BK_ultraCheckEditor.Focus();
                //    return;
                //}

                //if (e.PrevCtrl == this.BK_ultraCheckEditor)
                //{
                //    this.CS_ultraCheckEditor.Focus();
                //    return;
                //}

                //if (this.panel2.Visible)
                //{
                //    if (e.PrevCtrl == this.CS_ultraCheckEditor)
                //    {
                //        this.PrintPaperDivCd_tComboEditor.Focus();
                //        return;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                if ( (e.PrevCtrl == this.PrintPaperUseDivcd_tComboEditor) )
                {
                    if ( this.panel2.Visible )
                    {
                        this.PrintPaperDivCd_tComboEditor.Focus();
                        return;
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
			}
        }

		/// <summary>
		/// FPprGrid_Enterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票のグリッドがアクティブになったタイミングで発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void FPprGrid_Enter(object sender, EventArgs e)
		{
            if (this.FPprGrid.Rows.Count <= 0)
            {
				if (_optFreeSheetgMng)
				{
					this.SearchOptionSet.FocusedIndex = 0;
					this.SearchOptionSet.Focus();
				}
				else
				{
					this.PrintPaperUseDivcd_tComboEditor.Focus();
				}
                return;
            }
            else
            {
                if (this.FPprGrid.ActiveRow == null)
                {
                    this.FPprGrid.Rows[0].Activate();
                }
            }
		}

		/// <summary>
		/// FPprGrid_KeyDownイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票のグリッド上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
        private void FPprGrid_KeyDown(object sender, KeyEventArgs e)
        {
            switch ( e.KeyCode )
            {
                case Keys.Up:
                {
                    if (( this.FPprGrid.ActiveRow != null ) &&
                        ( this.FPprGrid.ActiveRow.Index == 0 ))
                    {
						if (this.panel2.Visible)
						{
							if (this.PrintPaperUseDivcd_tComboEditor.SelectedIndex == 0)
								this.PrintPaperDivCd_tComboEditor.Focus();
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                            //else if (this.PrintPaperUseDivcd_tComboEditor.SelectedIndex == 1)
                            //    this.BK_ultraCheckEditor.Focus();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
							else
								this.PrintPaperUseDivcd_tComboEditor.Focus();
						}
						else
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                            //if ((this.PrintPaperUseDivcd_tComboEditor.SelectedIndex == 0) ||
                            //    (this.PrintPaperUseDivcd_tComboEditor.SelectedIndex == 1))
                            //{
                            //    this.BK_ultraCheckEditor.Focus();
                            //}
                            //else
                            //{
                            //    this.PrintPaperUseDivcd_tComboEditor.Focus();
                            //}
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                            this.PrintPaperUseDivcd_tComboEditor.Focus();
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
                        }
                    }
                    break;
                }
                case Keys.Enter:
                {
                    UltraGridRow ultraGridRow = this.FPprGrid.ActiveRow;
                    if ( ultraGridRow != null )
                    {
                        this.OkClick();
                    }
                    break;
                }
				case Keys.Escape:
				{
					// 戻るボタン押下処理

					ToolClickEventArgs ev = new ToolClickEventArgs( this.ultraToolbarsManager1.Tools["Return_Button"], new ListToolItem() ) ;
					ultraToolbarsManager1_ToolClick( sender, ev );
					break;
				}
            }
        }

        #endregion

        #endregion

		#region UIの外観設定メソッド

		/// <summary>
		/// UltraGrid配色設定処理
		/// </summary>
		/// <param name="ugTarget"></param>
		/// <remarks>
		/// <br>Note        : UltraGridの配色を設定する</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void setGridAppearance( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
            //タイトルの外観
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor          = Color.FromArgb( 89, 135, 214 );
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2         = Color.FromArgb( 7, 59, 150 );
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle  = Infragistics.Win.GradientStyle.Vertical;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor          = Color.White;

            //背景色を設定
            ugTarget.DisplayLayout.Appearance.BackColor = Color.White;

            //文字をカラムに入るように設定する
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // 選択行の外観を設定
            ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor         = Color.FromArgb( 251, 230, 148 );
            ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackColor2        = Color.FromArgb( 238, 149, 21 );
            ugTarget.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //行セレクタの設定
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor          = Color.FromArgb( 89, 135, 214 );
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2         = Color.FromArgb( 7, 59, 150 );
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor          = Color.White;

            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //行のサイズ変更不可
            ugTarget.DisplayLayout.Override.RowSizing = RowSizing.Fixed;

            //インジゲータ非表示
            ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            //分割領域非表示
            ugTarget.DisplayLayout.MaxColScrollRegions = 1;
            ugTarget.DisplayLayout.MaxRowScrollRegions = 1;

            //交互に行の色を変える
            ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb( 192, 192, 255 );

            //グリッドの背景色を変える
            ugTarget.DisplayLayout.Appearance.BackColor = Color.Gray;

            //アクティブ行のフォントの色を変える
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
			
            //アクティブ行の色を設定する
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb( 247, 227, 156 );
		}
		
		/// <summary>
		/// UltraGrid挙動設定処理
		/// </summary>
		/// <param name="ugTarget"></param>
		/// <remarks>
		/// <br>Note        : UltraGridの挙動を設定する</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void setGridBehavior( Infragistics.Win.UltraWinGrid.UltraGrid ugTarget )
		{
            //行の追加不可
            ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;

            //行の削除不可
            ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

            // 列の移動不可
            ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;

            // 列の交換不可
            ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

            //// フィルタの使用不可
            //ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // フィルタの使用可
            ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

            // ユーザーのデータ書き換え不可
            ugTarget.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;

            //選択方法を行選択に設定。
            ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //+列選択不可にすることでヘッダをクリックしても何も起こらない
            ugTarget.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;

            //一行のみ選択可能にする
            ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            //スクロール中にもいまどこが見えている状態なのかがわかるようにする
            ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            //IME無効
            ugTarget.ImeMode = ImeMode.Disable;

            ugTarget.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            ugTarget.DisplayLayout.LoadStyle = LoadStyle.LoadOnDemand;
		}
		
		/// <summary>
		/// Toolbar表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : Toolbarの表示を設定します</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void setToolbarAppearance()
		{
			//ツールバーにアイコン設定
			//SFCMN00008C
			ImageList imList = IconResourceManagement.ImageList16;
			this.ultraToolbarsManager1.ImageListSmall = imList;

			this.ultraToolbarsManager1.Toolbars[0].Tools[0].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this.ultraToolbarsManager1.Toolbars[0].Tools[1].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this.ultraToolbarsManager1.Toolbars[0].Tools[2].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this.ultraToolbarsManager1.Toolbars[0].Tools[3].InstanceProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;


			//ツールバーをカスタマイズ不可にする
			this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize  = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft   = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight  = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop    = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowFloating   = Infragistics.Win.DefaultableBoolean.False;
			this.ultraToolbarsManager1.ToolbarSettings.AllowHiding     = Infragistics.Win.DefaultableBoolean.False;
		}

		/// <summary>
		/// UltraGrid列幅設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : グリッドの列幅を指定する</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2007.06.05</br>
		/// </remarks>
		private void setGridColumnWidth()
		{
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_DATAINPUTSYSTEMNM].Width       = 100;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
            this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_FREEPRTPPRITEMGRPNM].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_OUTPUTFORMFILENAME].Width = 200;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_DISPLAYNAME].Width				= 350;
			this.FPprGrid.DisplayLayout.Bands[0].Columns[COL_PRTPPRUSERDERIVNOCMT].Width    = 350;
		}
		
		#endregion


	}
}