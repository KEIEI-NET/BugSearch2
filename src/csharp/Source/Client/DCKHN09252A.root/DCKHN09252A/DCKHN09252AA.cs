using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

using Broadleaf.Application.Resources;// 2010/06/29 Add

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 端末別伝票出力設定マスタアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 端末別伝票出力設定マスタのアクセス制御を行います。</br>
	/// <br>Programmer : 30167 上野　弘貴</br>
	/// <br>Date       : 2007.12.10</br>
	/// <br>Update     : 2007/12/19  30167 上野　弘貴</br>
	/// <br>     		 伝票印刷設定マスタ紐づけ対応</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
    /// <br>           : 2008/10/03       照田 貴志</br>
    /// <br>             バグ修正、仕様変更対応</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>UpdateNote   : 2008/12/08 30365 宮津 銀次郎　請求書項目の追加に対応</br>
    /// <br>UpdateNote   : 2010/06/29 30517 夏野 駿希　Mantsi.15669　Adminログイン時はUSER_APの端末管理設定を参照する様に変更</br>
    /// <br>UpdateNote   : 2010/09/27 22018 鈴木 正臣　一般帳票も設定可能に変更</br>
    /// <br>UpdateNote   : 2010/10/12 22018 鈴木 正臣　データビューのソート順を変更する為にソート用列を追加</br>
    /// </remarks>
	public class SlipOutputSetAcs
	{
		//----------------------------------------
		// 端末別伝票出力設定設定マスタ定数定義
		//----------------------------------------
		public const string CREATEDATETIME = "CreateDateTime";
		public const string UPDATEDATETIME = "UpdateDateTime";
		public const string ENTERPRISECODE = "EnterpriseCode";
		public const string FILEHEADERGUID = "FileHeaderGuid";
		public const string UPDEMPLOYEECODE = "UpdEmployeeCode";
		public const string UPDASSEMBLYID1 = "UpdAssemblyId1";
		public const string UPDASSEMBLYID2 = "UpdAssemblyId2";
		public const string LOGICALDELETECODE = "LogicalDeleteCode";

		public const string SECTIONCODE_TITLE		= "拠点コード";
        public const string WAREHOUSECODE_TITLE     = "倉庫コード";
        //public const string WAREHOUSENAME_TITLE     = "倉庫名称";             //DEL 2008/10/03 名称変更
        public const string WAREHOUSENAME_TITLE = "倉庫名";                     //ADD 2008/10/03
        public const string SECTIONNAME_TITLE = "拠点名称";	// 内部保持用
		public const string CASHREGISTERNO_TITLE	= "端末番号";
		//----- h.ueno add---------- start 2007.12.19
		public const string DATAINPUTSYSTEM_TITLE	= "データ入力システムコード";
		public const string DATAINPUTSYSTEMNM_TITLE = "データ入力システム";	// グリッド表示用
		//----- h.ueno add---------- end   2007.12.19		
		public const string SLIPPRTKIND_TITLE		= "伝票印刷種別コード";
        // --- ADD m.suzuki 2010/10/12 ---------->>>>>
        public const string SLIPPRTKIND_SORT_TITLE = "伝票印刷種別コード(ソート用)";
        // --- ADD m.suzuki 2010/10/12 ----------<<<<<
		public const string SLIPPRTKINDNM_TITLE		= "伝票印刷種別";		// グリッド表示用
		// --- UPD m.suzuki 2010/09/27 ---------->>>>>
        //public const string SLIPPRTSETPAPERID_TITLE = "伝票印刷設定用帳票ID";
        public const string SLIPPRTSETPAPERID_TITLE = "伝票印刷設定用帳票ID(非表示)"; // 内部保持用
        // --- UPD m.suzuki 2010/09/27 ----------<<<<<
        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        public const string SLIPPRTSETPAPERID_DISP_TITLE = "伝票印刷設定用帳票ID"; // グリッド表示用
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		public const string PRINTERMNGNO_TITLE		= "プリンタ管理No";
        // DEL 2008/10/09 不具合対応[6428] ↓
        //public const string SLIPCOMMENT_TITLE		= "伝票コメント";
        public const string SLIPCOMMENT_TITLE       = "伝票印刷帳票名"; // ADD 2008/10/09 不具合対応[6428]
		public const string PRINTERNAME_TITLE		= "プリンタ名";
		public const string PRINTERPORT_TITLE		= "プリンタパス";
		public const string DELETE_DATE_TITLE		= "削除日";

		// テーブル名
		public const string MAIN_TABLE				= "MainTable";
		public const string SECOND_TABLE			= "SecondTable";

        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        // カラム名
        public const string ct_col_Pgid = "PGID";
        public const string ct_col_Name = "NAME";
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		// private member定義
		// リモートオブジェクト格納バッファ
		private ISlipOutputSetDB _iSlipOutputSetDB = null;    // 端末別伝票出力設定設定リモート

		//----- ueno add ---------- start 2008.01.31
		private SlipOutputSetLcDB _slipOutputSetLcDB = null;

		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31

		private DataSet _dataTableList = null;
		
		// 拠点マスタアクセス
		private SecInfoAcs _secInfoAcs = null;
		
		// 端末管理マスタアクセス
        private PosTerminalMgAcs _posTerminalMgAcs = null;

        //--- ADD 2008/06/20 ---------->>>>>
        // 倉庫マスタアクセス
        private WarehouseAcs _warehouseAcs = null;
        //--- ADD 2008/06/20 ----------<<<<<<

		// 伝票印刷設定用マスタアクセスクラス
        private SlipPrtSetAcs _slipPrtSetAcs = null;

        // >>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
        // 請求書印刷パターン設定用マスタアクセスクラス
        private DmdPrtPtnAcs _dmdPrtPtnAcs = null;

        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        // 出力設定アクセスクラス
        private OutputSetAcs _outputSetAcs = null;
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		// プリンタマスタアクセスクラス
		private PrtManageAcs _prtManageAcs = null;
		
		// 文字列結合用
		private StringBuilder _stringBuilder = null;

        private bool _scmFlg = false;    // 2010/06/29 Add

	    // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        // 一般帳票のタイトル取得用ディクショナリ
        private Dictionary<string, string> _outputSetDic;
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		#region Construcstor
		/// <summary>
		/// 端末別伝票出力設定マスタアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 端末別伝票出力設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public SlipOutputSetAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iSlipOutputSetDB = (ISlipOutputSetDB)MediationSlipOutputSetDB.GetSlipOutputSetDB();

				//----- ueno del ---------- start 2008.01.31
				// ローカルＤＢ対応により取得位置変更
				// 拠点マスタアクセスクラス
				//this._secInfoAcs = new SecInfoAcs();
				//----- ueno del ---------- end 2008.01.31

				// 端末管理マスタアクセス
				this._posTerminalMgAcs = new PosTerminalMgAcs();

                //--- ADD 2008/06/20 ---------->>>>>
                // 倉庫マスタアクセス
                this._warehouseAcs = new WarehouseAcs();
                //--- ADD 2008/06/20 ---------->>>>>

                // 伝票印刷設定用マスタアクセスクラス
				this._slipPrtSetAcs = new SlipPrtSetAcs();

                // >>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
                // 請求書印刷パターン設定用マスタアクセスクラス
                this._dmdPrtPtnAcs = new DmdPrtPtnAcs();

                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                // 出力設定アクセスクラス
                this._outputSetAcs = new OutputSetAcs();
                // --- ADD m.suzuki 2010/09/27 ----------<<<<<

				// プリンタマスタアクセスクラス
				this._prtManageAcs = new PrtManageAcs();

                // 2010/06/29 Add >>>
                Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
                scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
                if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    _scmFlg = true;
                }
                else
                {
                    _scmFlg = false;
                }
                // 2010/06/29 Add <<<
            }
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iSlipOutputSetDB = null;
			}

			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._slipOutputSetLcDB = new SlipOutputSetLcDB();
			//----- ueno add ---------- end 2008.01.31

			// データセット列情報構築処理
			this._dataTableList = new DataSet();
			DataSetColumnConstruction(ref this._dataTableList);

			// 文字列結合用
			this._stringBuilder = new StringBuilder();
		}
		#endregion

		// 列挙型
		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online
		}

		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  プロパティ
		//================================================================================
		/// <summary>
		/// ローカルＤＢReadモード
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSlipOutputSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		#region Property
		/// <summary>第１テーブル（端末番号テーブル）</summary>
		public DataTable DtMainTable
		{
			get { return this._dataTableList.Tables[MAIN_TABLE]; }
		}
		/// <summary>第２テーブル（伝票印刷テーブル）</summary>
		public DataTable DtDetailsTable
		{
			get { return this._dataTableList.Tables[SECOND_TABLE]; }
		}
		#endregion

		#region public member

		#region GetTable テーブル取得
		/// <summary>
		/// テーブル取得
		/// </summary>
		/// <param name="tableName">テーブル名</param>		
		/// <returns>DataTable</returns>
		/// <remarks>
		/// <br>Note       : 指定されたテーブルのオブジェクトを返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public DataTable GetTable(string tableName)
		{
			if (this._dataTableList.Tables.Contains(tableName))
			{
				return this._dataTableList.Tables[tableName];
			}
			return null;
		}
		#endregion

		#region GetSlipOutputSet 端末別伝票出力設定設定データ取得
		/// <summary>
		/// 端末別伝票出力設定設定データ取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>		
		/// <param name="cashRegisterNo">端末番号</param>		
		/// <param name="dataInputSystem">データ入力システム</param>		
		/// <param name="slipPrtKind">伝票印刷種別</param>		
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID</param>		
		/// <param name="slipOutputSet">端末別伝票出力設定設定クラス</param>
		/// <param name="message">エラーメッセージ</param>		
		/// <returns>ファンクションのステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定されたKEYを持つ端末別伝票出力設定設定クラスを返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int GetSlipOutputSet(//string sectionCode,       // DEL 2008/06/20
									int cashRegisterNo,
                                    //--- ADD 2008/06/20 ---------->>>>>
                                    string warehouseCode,
                                    //--- ADD 2008/06/20 ----------<<<<<
									//----- h.ueno add---------- start 2007.12.19
									int dataInputSystem,
									//----- h.ueno add---------- start 2007.12.19
									int slipPrtKind,
									string slipPrtSetPaperId,
									out SlipOutputSet slipOutputSet,
									out string message)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			slipOutputSet = new SlipOutputSet();
			message = "";

			try
			{
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {  //sectionCode,      // DEL 2008/06/20
																								cashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								warehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								dataInputSystem,
																								//----- h.ueno add---------- start 2007.12.19
																								slipPrtKind,
																								slipPrtSetPaperId });
				if (dr == null)
				{
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}

				// 作成日時
				slipOutputSet.CreateDateTime = (DateTime)dr[CREATEDATETIME];
				// 更新日時
				slipOutputSet.UpdateDateTime = (DateTime)dr[UPDATEDATETIME];
				// 企業コード
				slipOutputSet.EnterpriseCode = dr[ENTERPRISECODE].ToString();
				// GUID
				slipOutputSet.FileHeaderGuid = (Guid)dr[FILEHEADERGUID];
				// 更新従業員コード
				slipOutputSet.UpdEmployeeCode = dr[UPDEMPLOYEECODE].ToString();
				// 更新アセンブリID1
				slipOutputSet.UpdAssemblyId1 = dr[UPDASSEMBLYID1].ToString();
				// 更新アセンブリID2
				slipOutputSet.UpdAssemblyId2 = dr[UPDASSEMBLYID2].ToString();
				// 論理削除区分
				slipOutputSet.LogicalDeleteCode = Convert.ToInt32(dr[LOGICALDELETECODE]);

				// 拠点コード
                //slipOutputSet.SectionCode = dr[SECTIONCODE_TITLE].ToString();             // DEL 2008/06/20
                //--- ADD 2008/06/18 ---------->>>>>
                // 倉庫コード
                slipOutputSet.WarehouseCode = dr[WAREHOUSECODE_TITLE].ToString();
                //--- ADD 2008/06/18 ----------<<<<<
                // 端末番号
				slipOutputSet.CashRegisterNo = (int)dr[CASHREGISTERNO_TITLE];
				//----- h.ueno add---------- start 2007.12.19
				// データ入力システム
				slipOutputSet.DataInputSystem = (int)dr[DATAINPUTSYSTEM_TITLE];
				//----- h.ueno add---------- end   2007.12.19		
				// 伝票印刷種別
				slipOutputSet.SlipPrtKind = (int)dr[SLIPPRTKIND_TITLE];
				// 伝票印刷設定用帳票ID
				slipOutputSet.SlipPrtSetPaperId = dr[SLIPPRTSETPAPERID_TITLE].ToString();
				// プリンタ管理No
				slipOutputSet.PrinterMngNo = (int)dr[PRINTERMNGNO_TITLE];
				
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				slipOutputSet = null;
			}

			return status;
		}
		#endregion
		
		#region 伝票コメント取得
		/// <summary>
		/// 伝票コメント取得
		/// </summary>
		/// <remarks>
		/// <param name="dataInputSystem">データ入力システム</param>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID</param>
		/// <returns>伝票コメント</returns>
		/// <br>Note       : 伝票コメントを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public string GetSlipComment(int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId)
		{
			string retStr = "";

            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 99:帳票の場合はディクショナリを使用する。
            // (※名前順でソートする為にKEYにindexを入れた為、KEY指定で引けない)
            if ( slipPrtKind == 99 )
            {
                if ( _outputSetDic != null && _outputSetDic.ContainsKey( slipPrtSetPaperId ) )
                {
                    return _outputSetDic[slipPrtSetPaperId];
                }
                else
                {
                    return string.Empty;
                }
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

			// キー作成（データ入力システム＋伝票印刷種別＋伝票印刷設定用帳票ID）
			this._stringBuilder.Remove(0, this._stringBuilder.Length);
			this._stringBuilder.Append(dataInputSystem.ToString("d2"));
			this._stringBuilder.Append(slipPrtKind.ToString("d4"));
			this._stringBuilder.Append(slipPrtSetPaperId.TrimEnd());

			string key = this._stringBuilder.ToString();

			if (SlipOutputSet._slipPrtSetPaperIdList.ContainsKey(key) == true)
			{
				SlipPrtSet slipPrtSetWk = (SlipPrtSet)SlipOutputSet._slipPrtSetPaperIdList[key];

				retStr = slipPrtSetWk.SlipComment;
			}
			return retStr;
		}
		#endregion

		#region プリンタ名取得
		/// <summary>
		/// プリンタ名取得
		/// </summary>
		/// <remarks>
		/// <param name="printerMngNo">プリンタ管理No</param>
		/// <returns>プリンタ名</returns>
		/// <br>Note       : プリンタ名を取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public string GetPrinterName(int printerMngNo)
		{
			string retStr = "";

			if (SlipOutputSet._printerMngNoList.ContainsKey(printerMngNo) == true)
			{
				PrtManage prtManageWk = (PrtManage)SlipOutputSet._printerMngNoList[printerMngNo];
				retStr = prtManageWk.PrinterName;
			}
			return retStr;
		}
		#endregion

		#region プリンタポート取得
		/// <summary>
		/// プリンタポート取得
		/// </summary>
		/// <remarks>
		/// <param name="printerMngNo">プリンタ管理No</param>
		/// <returns>プリンタポート</returns>
		/// <br>Note       : プリンタポートを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public string GetPrinterPort(int printerMngNo)
		{
			string retStr = "";

			if (SlipOutputSet._printerMngNoList.ContainsKey(printerMngNo) == true)
			{
				PrtManage prtManageWk = (PrtManage)SlipOutputSet._printerMngNoList[printerMngNo];
				retStr = prtManageWk.PrinterPort;
			}
			return retStr;
		}
		#endregion

		#region Search 検索処理
		/// <summary>
		/// 検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="message">メッセージ</param>		
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 伝票出力設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Search(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
		{
			DataSet dmyDataSet = null;	// データセットは使用しない

			// 検索
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, 0, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}

		/// <summary>
		/// 検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="message">メッセージ</param>		
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 伝票出力設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Search(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
		{
			ArrayList dmyArrayList = null;	// ArrayListは使用しない

			// 検索
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, 0, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}
		#endregion
		
		#region SearchAll 検索処理
		/// <summary>
		/// 検索処理（論理削除含む）
		/// </summary>
		/// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="message">メッセージ</param>		
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 伝票出力設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int SearchAll(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
		{
			DataSet dmyDataSet = null;	// データセットは使用しない
			
			// 検索
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}
		
		/// <summary>
		/// 検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="message">メッセージ</param>		
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 伝票出力設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int SearchAll(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
		{
			ArrayList dmyArrayList = null;	// ArrayListは使用しない
			
			// 検索
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}
		#endregion

		#region Write 書き込み処理
		/// <summary>
		/// 書き込み処理
		/// </summary>
		/// <param name="slipOutputSet">保存データ</param>
		/// <param name="message">メッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 書き込み処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Write(ref SlipOutputSet slipOutputSet, out string message)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

			try
			{
				// クラスデータをワーククラスデータに変換
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				ArrayList paraSlipOutputSetWorkList = new ArrayList();
				paraSlipOutputSetWorkList.Add(slipOutputSetWork);
				object paraObj = paraSlipOutputSetWorkList;

				// 書き込み処理
				status = this._iSlipOutputSetDB.Write(ref paraObj);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 何かしらのエラー発生
					message = "登録に失敗しました。";
					return status;
				}

				// ワークデータをクラスデータに変換
				slipOutputSetWork = (SlipOutputSetWork)((ArrayList)paraObj)[0];
				slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

				// データ登録済みチェック
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSetWork.SectionCode,    // DEL 2008/06/20
																						slipOutputSetWork.CashRegisterNo,
																						//--- ADD 2008/06/20 ---------->>>>>
																						slipOutputSetWork.WarehouseCode,
																						//--- ADD 2008/06/20 ----------<<<<<
																						//----- h.ueno add---------- start 2007.12.19
																						slipOutputSetWork.DataInputSystem,
																						//----- h.ueno add---------- end   2007.12.19
																						slipOutputSetWork.SlipPrtKind,
																						slipOutputSetWork.SlipPrtSetPaperId });
				if (dr == null)
				{
					// 未登録の場合はワークデータをDataRowに変換
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);

					// 未登録の場合はレコードを追加
					this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
				}
				else
				{
					// 登録済みの場合は更新
					dr[UPDATEDATETIME] = slipOutputSetWork.UpdateDateTime;
					dr[UPDEMPLOYEECODE] = slipOutputSetWork.UpdEmployeeCode;
					dr[UPDASSEMBLYID1] = slipOutputSetWork.UpdAssemblyId1;
					dr[UPDASSEMBLYID2] = slipOutputSetWork.UpdAssemblyId2;

					// 拠点コード
                    //dr[SECTIONCODE_TITLE] = slipOutputSetWork.SectionCode;        // DEL 2008/06/20
                    // 端末番号
					dr[CASHREGISTERNO_TITLE] = slipOutputSetWork.CashRegisterNo;
                    //--- ADD 2008/06/20 ---------->>>>>
                    // 倉庫コード
                    dr[WAREHOUSECODE_TITLE] = slipOutputSetWork.WarehouseCode;
                    //--- ADD 2008/06/20 ----------<<<<<
                    //----- h.ueno add---------- start 2007.12.19
					// データ入力システム
					dr[DATAINPUTSYSTEM_TITLE] = slipOutputSetWork.DataInputSystem;
					// データ入力システム名称（グリッド表示用）
					dr[DATAINPUTSYSTEMNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.DataInputSystem, SlipOutputSet._dataInputSystemList);
					//----- h.ueno add---------- end   2007.12.19
					// 伝票印刷種別
					dr[SLIPPRTKIND_TITLE] = slipOutputSetWork.SlipPrtKind;
                    // --- ADD m.suzuki 2010/10/12 ---------->>>>>
                    // 伝票印刷種別（ソート用）
                    dr[SLIPPRTKIND_SORT_TITLE] = GetSlipPrtKindForSort( slipOutputSetWork.SlipPrtKind );
                    // --- ADD m.suzuki 2010/10/12 ----------<<<<<
					// 伝票印刷種別名称（グリッド表示用）
					dr[SLIPPRTKINDNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.SlipPrtKind, SlipOutputSet._slipPrtKindList);				
					// 伝票印刷設定用帳票ID
					dr[SLIPPRTSETPAPERID_TITLE] = slipOutputSetWork.SlipPrtSetPaperId;
                    // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                    // 伝票印刷設定用帳票ID（表示用）
                    if ( slipOutputSetWork.SlipPrtKind == 99 )
                    {
                        // 一般帳票
                        dr[SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
                    }
                    else
                    {
                        // 伝票・請求書
                        dr[SLIPPRTSETPAPERID_DISP_TITLE] = slipOutputSetWork.SlipPrtSetPaperId;
                    }
                    // --- ADD m.suzuki 2010/09/27 ----------<<<<<
					// プリンタ管理No
					dr[PRINTERMNGNO_TITLE] = slipOutputSetWork.PrinterMngNo;
					
					//----------表示用項目----------//
					// 伝票コメント（伝票印刷設定用帳票名称）
					string wkStr = GetSlipComment(slipOutputSet.DataInputSystem, slipOutputSetWork.SlipPrtKind, slipOutputSetWork.SlipPrtSetPaperId);
					dr[SLIPCOMMENT_TITLE] = wkStr;

					// プリンタ名
					dr[PRINTERNAME_TITLE] = GetPrinterName(slipOutputSetWork.PrinterMngNo);
					// プリンタポート（パス）
					dr[PRINTERPORT_TITLE] = GetPrinterPort(slipOutputSetWork.PrinterMngNo);
				}

				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// オフライン時はnullをセット
				this._iSlipOutputSetDB = null;
				// 通信エラー
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

        // --- ADD m.suzuki 2010/10/12 ---------->>>>>
        /// <summary>
        /// 伝票印刷種別（ソート用）取得処理
        /// </summary>
        /// <param name="slipPrtKind"></param>
        /// <returns></returns>
        private int GetSlipPrtKindForSort( int slipPrtKind )
        {
            // ※データビュー上でソートする為に、
            //   実データ上の種別の値とは異なる補正値を返却します。
            switch ( slipPrtKind )
            {
                default:
                    {
                        // 10:見積書
                        // 30:売上伝票
                        // 120:受注伝票
                        // 130:貸出伝票
                        // 140:見積伝票
                        // 150:在庫移動伝票
                        // 160:ＵＯＥ伝票
                        return (slipPrtKind);
                    }
                case 50:
                case 60:
                case 70:
                case 80:
                    {
                        // 50:合計請求書
                        // 60:明細請求書
                        // 70:伝票合計請求書
                        // 80:領収書
                        return (2000 + slipPrtKind);
                    }
                case 99:
                    {
                        // 99:帳票
                        return (9000 + slipPrtKind);
                    }
            }
        }
        // --- ADD m.suzuki 2010/10/12 ----------<<<<<
		#endregion

		#region LogicalDelete 論理削除処理
		/// <summary>
		/// 論理削除処理
		/// </summary>
		/// <param name="slipOutputSet">伝票印刷設定クラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 論理削除処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int LogicalDelete(ref SlipOutputSet slipOutputSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// クラスデータをワーククラスデータに変換
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				ArrayList slipOutputSetWorkList = new ArrayList();
				slipOutputSetWorkList.Add(slipOutputSetWork);
				object paraObj = slipOutputSetWorkList;

				// 削除処理
				status = this._iSlipOutputSetDB.LogicalDelete(ref paraObj);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 何かしらのエラー発生
					message = "削除に失敗しました。";
					return status;
				}

				// クラスデータに反映
				slipOutputSetWork = (SlipOutputSetWork)((ArrayList)paraObj)[0];
				slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

				// データテーブルに反映
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,    // DEL 2008/06/20
																								slipOutputSet.CashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								slipOutputSet.WarehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								slipOutputSet.DataInputSystem,
																								//----- h.ueno add---------- end   2007.12.19
																								slipOutputSet.SlipPrtKind,
																								slipOutputSet.SlipPrtSetPaperId });
				if (dr != null)
				{
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);
				}
				this._dataTableList.AcceptChanges();


				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// オフライン時はnullをセット
				this._iSlipOutputSetDB = null;
				// 通信エラー
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region Revival 復旧処理
		/// <summary>
		/// 復旧処理
		/// </summary>
		/// <param name="slipOutputSet">伝票印刷設定クラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <remarks>
		/// <returns>ステータス</returns>
		/// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Revival(ref SlipOutputSet slipOutputSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// クラスデータをワーククラスデータに変換
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				ArrayList paraSlipOutputSetWorkList = new ArrayList();
				paraSlipOutputSetWorkList.Add(slipOutputSetWork);
				object paraObj = paraSlipOutputSetWorkList;

				// 書き込み処理
				status = this._iSlipOutputSetDB.RevivalLogicalDelete(ref paraObj);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 何かしらのエラー発生
					message = "削除に失敗しました。";
					return status;
				}

				// クラスデータに反映
				slipOutputSetWork = (SlipOutputSetWork)((ArrayList)paraObj)[0];
				slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

				// データテーブルに反映
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,        // DEL 2008/06/20
																								slipOutputSet.CashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								slipOutputSet.WarehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								slipOutputSet.DataInputSystem,
																								//----- h.ueno add---------- end   2007.12.19
																								slipOutputSet.SlipPrtKind,
																								slipOutputSet.SlipPrtSetPaperId });
				if (dr != null)
				{
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);
				}
				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// オフライン時はnullをセット
				this._iSlipOutputSetDB = null;
				// 通信エラー
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region Delete 削除処理
		/// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="slipOutputSet">伝票印刷設定クラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 削除処理（物理削除）を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Delete(ref SlipOutputSet slipOutputSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// クラスデータをワーククラスデータに変換
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				// シリアライズ
				byte[] paraSlipOutputSetWork = XmlByteSerializer.Serialize(slipOutputSetWork);

				// 書き込み処理
				status = this._iSlipOutputSetDB.Delete(paraSlipOutputSetWork);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 何かしらのエラー発生
					message = "削除に失敗しました。";
					return status;
				}

				// データ登録済みチェック
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,        // DEL 2008/06/20
																								slipOutputSet.CashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								slipOutputSet.WarehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								slipOutputSet.DataInputSystem,
																								//----- h.ueno add---------- end   2007.12.19
																								slipOutputSet.SlipPrtKind,
																								slipOutputSet.SlipPrtSetPaperId });
				if (dr != null)
				{
					// 物理削除したデータを削除
					this._dataTableList.Tables[SECOND_TABLE].Rows.Remove(dr);
				}
				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// オフライン時はnullをセット
				this._iSlipOutputSetDB = null;
				// 通信エラー
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#endregion

		#region private member

		#region データセット列情報構築処理
		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void DataSetColumnConstruction(ref DataSet ds)
		{
			//----------------------------------------------------------------
			// 端末番号テーブル列定義
			//----------------------------------------------------------------
			DataTable cashRegisterNoTable = new DataTable(MAIN_TABLE);

			// 拠点コード
            //cashRegisterNoTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));   // DEL 2008/06/20
			
			// 拠点名称
			cashRegisterNoTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));
			
			// 端末番号
			cashRegisterNoTable.Columns.Add(CASHREGISTERNO_TITLE, typeof(Int32));

            //cashRegisterNoTable.PrimaryKey = new DataColumn[] { cashRegisterNoTable.Columns[SECTIONCODE_TITLE], cashRegisterNoTable.Columns[CASHREGISTERNO_TITLE] };  // DEL 2008/06/20
            cashRegisterNoTable.PrimaryKey = new DataColumn[] { cashRegisterNoTable.Columns[CASHREGISTERNO_TITLE] };    // ADD 2008/06/20
            this._dataTableList.Tables.Add(cashRegisterNoTable);

			//----------------------------------------------------------------
			// 端末別伝票出力設定テーブル列定義
			//----------------------------------------------------------------
			DataTable slipPrtTable = new DataTable(SECOND_TABLE);

			// 作成日時
			slipPrtTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
			// 更新日時
			slipPrtTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
			// 企業コード
			slipPrtTable.Columns.Add(ENTERPRISECODE, typeof(string));
			// GUID
			slipPrtTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
			// 更新従業員コード
			slipPrtTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
			// 更新アセンブリID1
			slipPrtTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
			// 更新アセンブリID2
			slipPrtTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
			// 論理削除区分
			slipPrtTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));

			// 拠点コード
            //slipPrtTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));      // DEL 2008/06/20
			// 端末番号
			slipPrtTable.Columns.Add(CASHREGISTERNO_TITLE, typeof(Int32));

            //--- ADD 2008/06/20 ---------->>>>>
            // 倉庫コード
            slipPrtTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            // 倉庫名称
            slipPrtTable.Columns.Add(WAREHOUSENAME_TITLE, typeof(string));
            //--- ADD 2008/06/20 ----------<<<<<

			//----- h.ueno add---------- start 2007.12.19
			// データ入力システム
			slipPrtTable.Columns.Add(DATAINPUTSYSTEM_TITLE, typeof(Int32));
			// データ入力システム名称（グリッド表示用）
			slipPrtTable.Columns.Add(DATAINPUTSYSTEMNM_TITLE, typeof(string));
			//----- h.ueno add---------- end   2007.12.19
			// 伝票印刷種別
			slipPrtTable.Columns.Add(SLIPPRTKIND_TITLE, typeof(Int32));
            // --- ADD m.suzuki 2010/10/12 ---------->>>>>
            // 伝票印刷種別(ソート用)
            slipPrtTable.Columns.Add( SLIPPRTKIND_SORT_TITLE, typeof( Int32 ) );
            // --- ADD m.suzuki 2010/10/12 ----------<<<<<
			// 伝票印刷種別名称（グリッド表示用）
			slipPrtTable.Columns.Add(SLIPPRTKINDNM_TITLE, typeof(string));
			// 伝票印刷設定用帳票ID
			slipPrtTable.Columns.Add(SLIPPRTSETPAPERID_TITLE, typeof(string));
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 伝票印刷設定用帳票ID（表示用）
            slipPrtTable.Columns.Add( SLIPPRTSETPAPERID_DISP_TITLE, typeof( string ) );
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
			// プリンタ管理No
			slipPrtTable.Columns.Add(PRINTERMNGNO_TITLE, typeof(Int32));

			// 伝票コメント（伝票印刷設定用帳票名称）
			slipPrtTable.Columns.Add(SLIPCOMMENT_TITLE, typeof(string));
			// プリンタ名
			slipPrtTable.Columns.Add(PRINTERNAME_TITLE, typeof(string));
			// プリンタポート（パス）
			slipPrtTable.Columns.Add(PRINTERPORT_TITLE, typeof(string));
			
			
			
			// 削除日
			slipPrtTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));

			slipPrtTable.PrimaryKey = new DataColumn[] { //slipPrtTable.Columns[SECTIONCODE_TITLE],     // DEL 2008/06/20
														 slipPrtTable.Columns[CASHREGISTERNO_TITLE],
											 			 //--- ADD 2008/06/20 ---------->>>>>
														 slipPrtTable.Columns[WAREHOUSECODE_TITLE],
											 			 //--- ADD 2008/06/20 ----------<<<<<
											 			 //----- h.ueno add---------- start 2007.12.19
														 slipPrtTable.Columns[DATAINPUTSYSTEM_TITLE],
														 //----- h.ueno add---------- end   2007.12.19
														 slipPrtTable.Columns[SLIPPRTKIND_TITLE],
														 slipPrtTable.Columns[SLIPPRTSETPAPERID_TITLE] };

			this._dataTableList.Tables.Add(slipPrtTable);

		}
		#endregion

		#region クラスメンバコピー処理
		/// <summary>
		/// クラスメンバーコピー処理（端末別伝票出力設定設定クラス⇒端末別伝票出力設定設定ワーククラス）
		/// </summary>
		/// <param name="slipOutputSet">端末別伝票出力設定設定クラス</param>
		/// <returns>SlipOutputSetWork</returns>
		/// <remarks>
		/// <br>Note       : 端末別伝票出力設定設定クラスから端末別伝票出力設定設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private SlipOutputSetWork CopyToSlipOutputSetWorkFromSlipOutputSet(SlipOutputSet slipOutputSet)
		{
			SlipOutputSetWork slipOutputSetWork = new SlipOutputSetWork();

			// 作成日時
			slipOutputSetWork.CreateDateTime = slipOutputSet.CreateDateTime;
			// 更新日時
			slipOutputSetWork.UpdateDateTime = slipOutputSet.UpdateDateTime;
			// 企業コード
			slipOutputSetWork.EnterpriseCode = slipOutputSet.EnterpriseCode;
			// GUID
			slipOutputSetWork.FileHeaderGuid = slipOutputSet.FileHeaderGuid;
			// 更新従業員コード
			slipOutputSetWork.UpdEmployeeCode = slipOutputSet.UpdEmployeeCode;
			// 更新アセンブリID1
			slipOutputSetWork.UpdAssemblyId1 = slipOutputSet.UpdAssemblyId1;
			// 更新アセンブリID2
			slipOutputSetWork.UpdAssemblyId2 = slipOutputSet.UpdAssemblyId2;
			// 論理削除区分
			slipOutputSetWork.LogicalDeleteCode = slipOutputSet.LogicalDeleteCode;

			// 拠点コード
            //slipOutputSetWork.SectionCode = slipOutputSet.SectionCode;        // DEL 2008/06/20
			// 端末番号
			slipOutputSetWork.CashRegisterNo = slipOutputSet.CashRegisterNo;
            //--- ADD 2008/06/19 ---------->>>>>
            // 倉庫コード
            slipOutputSetWork.WarehouseCode = slipOutputSet.WarehouseCode;
            //--- ADD 2008/06/19 ----------<<<<<
			//----- h.ueno add---------- start 2007.12.19
			// データ入力システム
			slipOutputSetWork.DataInputSystem = slipOutputSet.DataInputSystem;
			//----- h.ueno add---------- end   2007.12.19
			// 伝票印刷種別
			slipOutputSetWork.SlipPrtKind = slipOutputSet.SlipPrtKind;
			// 伝票印刷設定用帳票ID
			slipOutputSetWork.SlipPrtSetPaperId = slipOutputSet.SlipPrtSetPaperId;
			// プリンタ管理No
			slipOutputSetWork.PrinterMngNo = slipOutputSet.PrinterMngNo;

			return slipOutputSetWork;
		}

		/// <summary>
		/// クラスメンバーコピー処理（端末別伝票出力設定設定ワーククラス⇒端末別伝票出力設定設定クラス）
		/// </summary>
		/// <param name="slipOutputSetWork">端末別伝票出力設定設定ワーククラス</param>
		/// <returns>SlipOutputSetWork</returns>
		/// <remarks>
		/// <br>Note       : 端末別伝票出力設定設定ワーククラスから端末別伝票出力設定設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private SlipOutputSet CopyToSlipOutputSetFromSlipOutputSetWork(SlipOutputSetWork slipOutputSetWork)
		{
			SlipOutputSet slipOutputSet = new SlipOutputSet();

			// 作成日時
			slipOutputSet.CreateDateTime = slipOutputSetWork.CreateDateTime;
			// 更新日時
			slipOutputSet.UpdateDateTime = slipOutputSetWork.UpdateDateTime;
			// 企業コード
			slipOutputSet.EnterpriseCode = slipOutputSetWork.EnterpriseCode;
			// GUID
			slipOutputSet.FileHeaderGuid = slipOutputSetWork.FileHeaderGuid;
			// 更新従業員コード
			slipOutputSet.UpdEmployeeCode = slipOutputSetWork.UpdEmployeeCode;
			// 更新アセンブリID1
			slipOutputSet.UpdAssemblyId1 = slipOutputSetWork.UpdAssemblyId1;
			// 更新アセンブリID2
			slipOutputSet.UpdAssemblyId2 = slipOutputSetWork.UpdAssemblyId2;
			// 論理削除区分
			slipOutputSet.LogicalDeleteCode = slipOutputSetWork.LogicalDeleteCode;
			
			// 拠点コード
            //slipOutputSet.SectionCode = slipOutputSetWork.SectionCode;            // DEL 2008/06/20
			// 端末番号
			slipOutputSet.CashRegisterNo = slipOutputSetWork.CashRegisterNo;
            //--- ADD 2008/06/19 ---------->>>>>
            // 倉庫コード
            slipOutputSet.WarehouseCode = slipOutputSetWork.WarehouseCode;
            //--- ADD 2008/06/19 ----------<<<<<
            //----- h.ueno add---------- start 2007.12.19
			// データ入力システム
			slipOutputSet.DataInputSystem = slipOutputSetWork.DataInputSystem;
			//----- h.ueno add---------- end   2007.12.19
			// 伝票印刷種別
			slipOutputSet.SlipPrtKind = slipOutputSetWork.SlipPrtKind;
			// 伝票印刷設定用帳票ID
			slipOutputSet.SlipPrtSetPaperId = slipOutputSetWork.SlipPrtSetPaperId;
			// プリンタ管理No
			slipOutputSet.PrinterMngNo = slipOutputSetWork.PrinterMngNo;

			return slipOutputSet;
		}

		/// <summary>
		/// クラスメンバーコピー処理（端末別伝票出力設定設定クラス⇒DataRow）
		/// </summary>
		/// <param name="slipOutputSet">端末別伝票出力設定設定クラス</param>
		/// <returns>DataRow</returns>
		/// <remarks>
		/// <br>Note       : 端末別伝票出力設定設定ワーククラスから端末別伝票出力設定設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private DataRow CopyToDataRowFromSlipOutputSetWork(ref SlipOutputSetWork slipOutputSetWork)
		{
			SlipOutputSet slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

			// 端末別伝票出力設定設定マスタへの登録
			DataRow dr;
			dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,        // DEL 2008/06/20
																					slipOutputSet.CashRegisterNo,
																					//--- ADD 2008/06/20 ---------->>>>>
                                                                                    slipOutputSet.WarehouseCode,
																					//--- ADD 2008/06/20 ----------<<<<<
																					//----- h.ueno add---------- start 2007.12.19
																					slipOutputSet.DataInputSystem,
																					//----- h.ueno add---------- end   2007.12.19
																					slipOutputSet.SlipPrtKind,
																					slipOutputSet.SlipPrtSetPaperId});
			if (dr == null)
			{
				dr = this._dataTableList.Tables[SECOND_TABLE].NewRow();
			}

			// 作成日時
			dr[CREATEDATETIME] = slipOutputSet.CreateDateTime;
			// 更新日時
			dr[UPDATEDATETIME] = slipOutputSet.UpdateDateTime;
			// 企業コード
			dr[ENTERPRISECODE] = slipOutputSet.EnterpriseCode;

			if (slipOutputSet.FileHeaderGuid == Guid.Empty)
			{
				// GUID
				dr[FILEHEADERGUID] = Guid.NewGuid();
			}
			else
			{
				// GUID
				dr[FILEHEADERGUID] = slipOutputSet.FileHeaderGuid;
			}
			// 更新従業員コード
			dr[UPDEMPLOYEECODE] = slipOutputSet.UpdEmployeeCode;
			// 更新アセンブリID1
			dr[UPDASSEMBLYID1] = slipOutputSet.UpdAssemblyId1;
			// 更新アセンブリID2
			dr[UPDASSEMBLYID2] = slipOutputSet.UpdAssemblyId2;
			// 論理削除区分
			dr[LOGICALDELETECODE] = slipOutputSet.LogicalDeleteCode;

			// 拠点コード
            //dr[SECTIONCODE_TITLE] = slipOutputSet.SectionCode;        // DEL 2008/06/20
			// 端末番号
			dr[CASHREGISTERNO_TITLE] = slipOutputSet.CashRegisterNo;
            //--- ADD 2008/06/19 ---------->>>>>
            dr[WAREHOUSECODE_TITLE] = slipOutputSet.WarehouseCode;
            dr[WAREHOUSENAME_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.WarehouseCode, SlipOutputSet._warehouseCodeList);
            //--- ADD 2008/06/19 ----------<<<<<
            //----- h.ueno add---------- start 2007.12.19
			// システムデータ入力
			dr[DATAINPUTSYSTEM_TITLE] = slipOutputSet.DataInputSystem;
			// システムデータ入力（グリッド表示用）
			dr[DATAINPUTSYSTEMNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSet.DataInputSystem, SlipOutputSet._dataInputSystemList);
			//----- h.ueno add---------- end   2007.12.19
			// 伝票印刷種別
			dr[SLIPPRTKIND_TITLE] = slipOutputSet.SlipPrtKind;
            // --- ADD m.suzuki 2010/10/12 ---------->>>>>
            dr[SLIPPRTKIND_SORT_TITLE] = GetSlipPrtKindForSort( slipOutputSet.SlipPrtKind );
            // --- ADD m.suzuki 2010/10/12 ----------<<<<<
			// 伝票印刷設定用帳票ID
			dr[SLIPPRTSETPAPERID_TITLE] = slipOutputSet.SlipPrtSetPaperId;
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 伝票印刷設定用帳票ID（表示用）
            if ( slipOutputSet.SlipPrtKind == 99 )
            {
                // 一般帳票
                dr[SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
            }
            else
            {
                // 伝票・請求書
                dr[SLIPPRTSETPAPERID_DISP_TITLE] = slipOutputSet.SlipPrtSetPaperId;
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

			// プリンタ管理No
			dr[PRINTERMNGNO_TITLE] = slipOutputSet.PrinterMngNo;
			
			//----------表示用項目----------//
			// 伝票印刷種別名称（グリッド表示用）
			dr[SLIPPRTKINDNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSet.SlipPrtKind, SlipOutputSet._slipPrtKindList);
			// 伝票コメント（伝票印刷設定用帳票名称）
			string wkStr = GetSlipComment(slipOutputSet.DataInputSystem, slipOutputSet.SlipPrtKind, slipOutputSet.SlipPrtSetPaperId);
			dr[SLIPCOMMENT_TITLE] = wkStr;
			
			// プリンタ名
			dr[PRINTERNAME_TITLE] = GetPrinterName(slipOutputSet.PrinterMngNo);
			// プリンタポート（パス）
			dr[PRINTERPORT_TITLE] = GetPrinterPort(slipOutputSet.PrinterMngNo);
			
			// 削除日
			if (slipOutputSet.LogicalDeleteCode == 0)
			{
				dr[DELETE_DATE_TITLE] = "";
			}
			else
			{
				dr[DELETE_DATE_TITLE] = slipOutputSet.UpdateDateTimeJpInFormal;
			}

			return dr;
		}

		#endregion

        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------>>>>>
        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        public int Renewal(string enterpriseCode)
        {
            ArrayList retList;
            DataSet retDataSet;
            int totalCount;
            bool nextData;
            string msg;

            int status = SearchProc(out retList, out retDataSet, out totalCount, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, out msg);

            return status;
        }
        // --- ADD 2009/03/30 残案件No.14対応------------------------------------------------------<<<<<

		#region SearchProc 検索処理メイン（論理削除含む）
		/// <summary>
		/// 検索処理メイン（論理削除含む）
		/// </summary>
		/// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 検索処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private int SearchProc(	  out ArrayList retArrayList
								, out DataSet retList
								, out int retTotalCnt
								, out bool nextData
								, string enterpriseCode
                                //, string sectionCode          // DEL 2008/06/20
								, ConstantManagement.LogicalMode logicalMode
								, out string message)
		{

			int status = 0;
			retList = null;
			retTotalCnt = 0;
			nextData = false;
			message = "";
			
			retArrayList = new ArrayList();
			
			//------------------------------
			// コンボボックスデータ初期化
			//------------------------------
			//----- h.ueno add---------- start 2007.12.19
            SlipOutputSet._dataInputSystemComboList = new SortedList();
			//----- h.ueno add---------- end   2007.12.19
			SlipOutputSet._slipPrtSetPaperIdList = new SortedList();
			SlipOutputSet._printerMngNoList = new SortedList();

			//============================
			// 伝票印刷設定マスタ読み込み
			//============================
			// 伝票印刷設定用帳票ID全取得
			ArrayList slipPrtRetList = null;

			//----- ueno add ---------- start 2008.01.31
			// 伝票印刷設定用ローカルフラグ設定
			this._slipPrtSetAcs.IsLocalDBRead = _isLocalDBRead;
			//----- ueno add ---------- end 2008.01.31

			status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, enterpriseCode);
			
			if ((status == 0) && (slipPrtRetList.Count > 0))
			{
				string key = "";

				//----- h.ueno add---------- start 2007.12.19
				int wkDataInputSystem = -999;		// データ入力システム（ダミー設定）
				string wkDataInputSystemNm = "";	// データ入力システム名称
				//----- h.ueno add---------- end   2007.12.19

				foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
				{
					//----- h.ueno add---------- start 2007.12.19
					//------------------------------------------
					// データ入力システムをコンボボックスに設定
					//------------------------------------------
					// 直前のデータと異なっていたら設定する
					if (wkDataInputSystem != slipPrtSet.DataInputSystem)
					{
						// データ入力システム名称取得
						wkDataInputSystemNm = SlipOutputSet.GetSortedListNm(slipPrtSet.DataInputSystem, SlipOutputSet._dataInputSystemList);
						
						SlipOutputSet._dataInputSystemComboList.Add(slipPrtSet.DataInputSystem, wkDataInputSystemNm);
						
						// 現在のデータを保存
						wkDataInputSystem = slipPrtSet.DataInputSystem;
					}
					//----- h.ueno add---------- end   2007.12.19

					//--------------------------------------------------------------------
					// Key  ：ファイルレイアウトのキー項目を結合する
					//   ﾃﾞｰﾀ入力ｼｽﾃﾑ(2桁)＋伝票印刷種別(4桁)＋伝票印刷設定用帳票ID(24桁)
					// Value：伝票印刷設定マスタクラス
					//--------------------------------------------------------------------
					this._stringBuilder.Remove(0, this._stringBuilder.Length);
					this._stringBuilder.Append(slipPrtSet.DataInputSystem.ToString("d2"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtKind.ToString("d4"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtSetPaperId.TrimEnd());
					key = this._stringBuilder.ToString();
					
					SlipOutputSet._slipPrtSetPaperIdList.Add(key, slipPrtSet);
				}
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
            status = 0;
            ArrayList dmdPrtPtnList = null;
            status = this._dmdPrtPtnAcs.Search(out dmdPrtPtnList, enterpriseCode);

            if ((status == 0) && (dmdPrtPtnList.Count > 0))
            {
                string key = "";

                //int wkDataInputSystem = -999;		// データ入力システム（ダミー設定）
                //string wkDataInputSystemNm = "";	// データ入力システム名称

                foreach (DmdPrtPtn dmdPrtPtn in (ArrayList)dmdPrtPtnList)
                {
                    #region [2008/12/08 G.Miyatsu DEL]
                    //>>>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu DEL
                    ////------------------------------------------
                    //// データ入力システムをコンボボックスに設定
                    ////------------------------------------------
                    //// 直前のデータと異なっていたら設定する
                    //if (wkDataInputSystem != dmdPrtPtn.DataInputSystem)
                    //{
                    //    //// データ入力システム名称取得
                    //    //wkDataInputSystemNm = SlipOutputSet.GetSortedListNm(slipPrtSet.DataInputSystem, SlipOutputSet._dataInputSystemList);

                    //    //DmdPrtPtnAcs._dataInputSystemComboList.Add(slipPrtSet.DataInputSystem, wkDataInputSystemNm);

                    //    // 現在のデータを保存
                    //    //wkDataInputSystem = slipPrtSet.DataInputSystem;
                    //}
                    #endregion

                    //--------------------------------------------------------------------
                    // Key  ：ファイルレイアウトのキー項目を結合する
                    //   ﾃﾞｰﾀ入力ｼｽﾃﾑ(2桁)＋伝票印刷種別(4桁)＋伝票印刷設定用帳票ID(24桁)
                    // Value：伝票印刷設定マスタクラス
                    //--------------------------------------------------------------------
                    this._stringBuilder.Remove(0, this._stringBuilder.Length);
                    this._stringBuilder.Append(dmdPrtPtn.DataInputSystem.ToString("d2"));
                    this._stringBuilder.Append(dmdPrtPtn.SlipPrtKind.ToString("d4"));
                    this._stringBuilder.Append(dmdPrtPtn.SlipPrtSetPaperId.TrimEnd());
                    key = this._stringBuilder.ToString();

                    //使用する値のみ移して、dmdPrtPtnをSlipPrtSetに変換する。
                    SlipPrtSet slipPrtSet = new SlipPrtSet();
                    slipPrtSet.DataInputSystem = dmdPrtPtn.DataInputSystem;
                    slipPrtSet.SlipPrtKind = dmdPrtPtn.SlipPrtKind;
                    slipPrtSet.SlipPrtSetPaperId = dmdPrtPtn.SlipPrtSetPaperId;
                    slipPrtSet.SlipComment = dmdPrtPtn.SlipComment;

                    SlipOutputSet._slipPrtSetPaperIdList.Add(key, slipPrtSet);
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD
            #endregion
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 出力設定マスタを参照（帳票の一覧を取得）
            status = 0;
            ArrayList outputSetList = null;
            status = this._outputSetAcs.SearchAllOutputSet( out outputSetList, enterpriseCode );

            if ( (status == 0) && (outputSetList.Count > 0) )
            {
                string key = string.Empty;

                // ディクショナリを初期化
                if ( _outputSetDic == null )
                {
                    _outputSetDic = new Dictionary<string, string>();
                }
                else
                {
                    _outputSetDic.Clear();
                }

                // 抽出結果⇒ディクショナリ
                # region [outputSetList⇒Dictionary]
                // <Key:PGID,Value:帳票名>のディクショナリを生成
                foreach ( OutputSet outputSet in (ArrayList)outputSetList )
                {
                    // 論理削除分は除外
                    if ( outputSet.LogicalDeleteCode != 0 ) continue;
                    // テキスト出力分は除外（選択情報区分 0:帳票,1:テキスト出力）
                    if ( outputSet.SelectInfoCode != 0 ) continue;

                    string dicKey = outputSet.PgId.Trim();
                    if ( !_outputSetDic.ContainsKey( dicKey ) )
                    {
                        // ディクショナリに追加
                        _outputSetDic.Add( dicKey, outputSet.DisplayName.Trim() );
                    }
                    else
                    {
                        // ディクショナリ既存
                        _outputSetDic[dicKey] = AppendToDisplayName( _outputSetDic[dicKey], outputSet.DisplayName.Trim() );
                    }
                }
                # endregion

                // ディクショナリ⇒データビュー
                # region [Dictionary⇒DataView]
                // ディクショナリ⇒データテーブル(ソート用)
                DataTable table = CreateTable();
                foreach ( string dicKey in _outputSetDic.Keys )
                {
                    table.Rows.Add( CreateTableRow( table, dicKey, _outputSetDic[dicKey] ) );
                }
                // データビュー生成(名前順sort)
                DataView view = new DataView( table );
                view.Sort = string.Format( "{0}", ct_col_Name );
                # endregion

                // データビュー⇒表示用のリストへ
                # region [DataView⇒_slipPrtSetPaperIdList]
                int sortIndex = 0;
                foreach( DataRowView rowView in view )
                {
                    //使用する値のみ移して、SlipPrtSetを生成する。
                    SlipPrtSet slipPrtSet = new SlipPrtSet();
                    slipPrtSet.DataInputSystem = 0; // 0:共通
                    slipPrtSet.SlipPrtKind = 99; // 99:帳票
                    slipPrtSet.SlipPrtSetPaperId = (string)rowView[ct_col_Pgid]; // PGID
                    slipPrtSet.SlipComment = (string)rowView[ct_col_Name]; // 帳票名

                    //KEY文字列生成（sortIndexを一意にする事で強制的にソートする）
                    this._stringBuilder.Remove( 0, this._stringBuilder.Length );
                    this._stringBuilder.Append( slipPrtSet.DataInputSystem.ToString( "d2" ) );
                    this._stringBuilder.Append( slipPrtSet.SlipPrtKind.ToString( "d4" ) );
                    this._stringBuilder.Append( sortIndex.ToString( "d5" ) );
                    this._stringBuilder.Append( slipPrtSet.SlipPrtSetPaperId.TrimEnd() );
                    key = this._stringBuilder.ToString();

                    //リストに追加
                    SlipOutputSet._slipPrtSetPaperIdList.Add( key, slipPrtSet );
                    sortIndex++;
                }
                # endregion
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
            

            //============================
			// プリンタ管理マスタ読み込み
			//============================
			// プリンタ管理No全取得
			ArrayList prtManageRetList = null;
			status = this._prtManageAcs.Search(out prtManageRetList, enterpriseCode);

			if ((status == 0) && (prtManageRetList.Count > 0))
			{
				foreach (PrtManage prtManage in (ArrayList)prtManageRetList)
				{
					//---------------------------------
					// Key  ：プリンタ管理No
					// Value：プリンタ管理マスタクラス
					//---------------------------------
					SlipOutputSet._printerMngNoList.Add(prtManage.PrinterMngNo, prtManage);
				}
			}
			
            //--- DEL 2008/06/20 ---------->>>>>
            ////==========================================
            //// 拠点マスタ読み込み
            ////==========================================
            //// 拠点リスト初期化
            //SlipOutputSet._sectionCodeList = new SortedList();

            ////----- ueno add ---------- start 2008.01.31
            //// ローカルＤＢ拠点対応
            //ConstructSecInfoAcs();
            ////----- ueno add ---------- end 2008.01.31

            //if (this._secInfoAcs.SecInfoSetList.Length > 0)
            //{
            //    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //    {
            //        // 拠点コードと名称を保存	
            //        SlipOutputSet._sectionCodeList.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
            //    }
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            //--- DEL 2008/06/20 ----------<<<<<

            //--- ADD 2008/06/20 ---------->>>>>
            //==========================================
            // 倉庫マスタ読み込み
            //==========================================
            SlipOutputSet._warehouseCodeList = new SortedList();
            ArrayList warehouseCodeList = null;
            status = this._warehouseAcs.Search(out warehouseCodeList, enterpriseCode);

            if ((status == 0) && (warehouseCodeList.Count > 0))
            {
                foreach (Warehouse warehouse in (ArrayList)warehouseCodeList)
                {
                    //---------------------------------
                    // Key  ：倉庫コード
                    // Value：倉庫名称
                    //---------------------------------
                    SlipOutputSet._warehouseCodeList.Add(warehouse.WarehouseCode, warehouse.WarehouseName);
                }
            }
            //--- ADD 2008/06/20 ----------<<<<<

			//==========================================
			// 端末別伝票出力設定マスタ読み込み
			//==========================================
			// 抽出条件パラメータ
			SearchSlipOutputSetParaWork paraWork = new SearchSlipOutputSetParaWork();
			
			paraWork.EnterpriseCode = enterpriseCode;

			//----- h.ueno add---------- start 2007.12.19
			// 数値型の項目は「0」データを考慮し、全検索対象時は「-1」とする
			paraWork.CashRegisterNo = -1;	// レジ番号
			paraWork.DataInputSystem = -1;	// データ入力システム
			paraWork.SlipPrtKind = -1;		// 伝票印刷種別
			//----- h.ueno add---------- end   2007.12.19
			
			ArrayList paraList = new ArrayList();
			paraList.Add(paraWork);

			// リモート戻りリスト
			object slipOutputSetWorkList = null;

			//----- ueno upd ---------- start 2008.01.31
			// ローカル
			if (_isLocalDBRead)
			{
				List<SlipOutputSetWork> wkSlipOutputSetWorkList = new List<SlipOutputSetWork>();
				status = this._slipOutputSetLcDB.Search(out wkSlipOutputSetWorkList, paraWork, 0, logicalMode);
				
				if(status == 0)
				{
					ArrayList al = new ArrayList();
					al.AddRange(wkSlipOutputSetWorkList);
					slipOutputSetWorkList = (object)al;
				}
			}
			// リモート
			else
			{
				// 端末別伝票出力設定マスタ検索
				status = this._iSlipOutputSetDB.Search(out slipOutputSetWorkList, paraList, 0, logicalMode);
			}
			//----- ueno upd ---------- end 2008.01.31

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// データテーブルにセット
				foreach (SlipOutputSetWork slipOutputSetWork in (ArrayList)slipOutputSetWorkList)
				{
					// データテーブルへ格納
					AddRowFromSlipOutputSetWork(slipOutputSetWork);

					// ArrayListへ格納
					retArrayList.Add(CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork));
				}
			}

			//==========================================
			// 端末管理マスタ読み込み
			//==========================================
            PosTerminalMg posTerminalMg = null;
            // 2010/06/29 Add >>>
            ArrayList posTerminalMgList = new ArrayList();
            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)
                    status = this._posTerminalMgAcs.SearchServer(out posTerminalMgList, enterpriseCode);
                else
                    status = this._posTerminalMgAcs.Search(out posTerminalMg, enterpriseCode);
            }
            else
                // 2010/06/29 Add <<<
                status = this._posTerminalMgAcs.Search(out posTerminalMg, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データテーブルにセット
                // 2010/06/29 Add >>>
                if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
                {
                    if (_scmFlg == true)
                    {
                        foreach (PosTerminalMg posTerminal in posTerminalMgList)
                        {
                            AddRowFromPosTerminalMg(posTerminal);
                        }
                    }
                    else
                        AddRowFromPosTerminalMg(posTerminalMg);
                }
                else
                    // 2010/06/29 Add <<<
                    AddRowFromPosTerminalMg(posTerminalMg);
            }

            // 2010/06/29 Add >>>
            // 端末番号順に並び替え
            DataTable dt = new DataTable();
            dt = this._dataTableList.Tables[MAIN_TABLE].Clone();
            DataView dv = new DataView(_dataTableList.Tables[MAIN_TABLE]);
            dv.Sort = CASHREGISTERNO_TITLE;
            foreach (DataRowView drv in dv)
            {
                dt.ImportRow(drv.Row);
            }
            this._dataTableList.Tables[MAIN_TABLE].Clear();
            dv = new DataView(dt);
            foreach (DataRowView drv in dv)
            {
                this._dataTableList.Tables[MAIN_TABLE].ImportRow(drv.Row);
            }
            // 2010/06/29 Add <<<

			//==========================================
			// データセットを返す
			//==========================================
			retList = this._dataTableList;

			return status;
		}

        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        /// <summary>
        /// 帳票タイトルの連結処理
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string AppendToDisplayName( string currentText, string appendText )
        {
            // 帳票タイトルの最大長
            const int maxLength = 20;


            if ( currentText.Length < maxLength || currentText[currentText.Length - 1] != '…' )
            {
                // 同内容で連結済みかチェック
                string[] currentTextSub = currentText.Split( ',' );
                foreach ( string sub in currentTextSub )
                {
                    if ( sub.Trim() == appendText.Trim() )
                    {
                        // 該当があったら終了
                        return currentText;
                    }
                }

                // カンマ区切りで連結
                currentText += "," + appendText;
            }
            else 
            {
                // 既に最大長でカット済みならば、それ以上は連結せずにそのまま返す。
                return currentText;
            }


            // 最大長でカット
            if ( currentText.Length > maxLength )
            {
                // 最大長-1でカット
                currentText = currentText.Substring( 0, maxLength - 1 );

                // 最終文字を"…"にする
                currentText += "…";
            }

            return currentText;
        }
        /// <summary>
        /// ソート用データテーブル生成
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add( new DataColumn( ct_col_Pgid, typeof( string ) ) );
            table.Columns.Add( new DataColumn( ct_col_Name, typeof( string ) ) );
            return table;
        }
        /// <summary>
        /// ソート用データテーブル行生成
        /// </summary>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private DataRow CreateTableRow( DataTable table, string key, string value )
        {
            DataRow row = table.NewRow();
            row[ct_col_Pgid] = key;
            row[ct_col_Name] = value;
            return row;
        }
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<
		#endregion

		/// <summary>
		/// 端末別伝票出力設定マスタ　→　データテーブル　追加処理
		/// </summary>
		/// <param name="slipOutputSetWork">端末別伝票出力設定ワーククラス</param>
		private void AddRowFromSlipOutputSetWork(SlipOutputSetWork slipOutputSetWork)
		{
			DataRow dr;

			try
			{
                //--- DEL 2008/06/20 ---------->>>>>
                // 第１グリッド（端末番号）
                //if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { slipOutputSetWork.SectionCode, slipOutputSetWork.CashRegisterNo }) == null)
                //{
                //    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                //    dr[SECTIONCODE_TITLE] = slipOutputSetWork.SectionCode;
                //    dr[SECTIONNAME_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.SectionCode, SlipOutputSet._sectionCodeList);
                //    dr[CASHREGISTERNO_TITLE] = slipOutputSetWork.CashRegisterNo;
					
                //    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                //}
                //--- DEL 2008/06/20 ----------<<<<<

                //--- ADD 2008/06/20 ---------->>>>>
                // 第１グリッド（端末番号）
                if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { slipOutputSetWork.CashRegisterNo }) == null)
                {
                    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                    dr[CASHREGISTERNO_TITLE] = slipOutputSetWork.CashRegisterNo;

                    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                }
                //--- ADD 2008/06/20 ----------<<<<<

				// 第２グリッド（伝票印刷）
				if (this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSetWork.SectionCode,        // DEL 2008/06/20
																						slipOutputSetWork.CashRegisterNo,
                                                                                        //--- ADD 2008/06/20 ---------->>>>>
                                                                                        slipOutputSetWork.WarehouseCode,
                                                                                        //--- ADD 2008/06/20 ----------<<<<<
																						//----- h.ueno add---------- start 2007.12.19
																						slipOutputSetWork.DataInputSystem,
																						//----- h.ueno add---------- end   2007.12.19
																						slipOutputSetWork.SlipPrtKind,
																						slipOutputSetWork.SlipPrtSetPaperId }) == null)
				{
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);
					this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
				}
			}
			catch (Exception ex)
			{
                string err = ex.Message;
			}
		}

		/// <summary>
		/// 端末管理マスタ　→　データテーブル　追加処理
		/// </summary>
		/// <param name="posTerminalMg">端末管理クラス</param>
		private void AddRowFromPosTerminalMg(PosTerminalMg posTerminalMg)
		{
			DataRow dr;

			try
			{
                //--- DEL 2008/06/19 ----------->>>>>
                //// 第１グリッド（端末番号）
                //if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { posTerminalMg.SectionCode, posTerminalMg.CashRegisterNo }) == null)
                //{
                //    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                //    dr[SECTIONCODE_TITLE] = posTerminalMg.SectionCode;
                //    dr[SECTIONNAME_TITLE] = SlipOutputSet.GetSortedListNm(posTerminalMg.SectionCode, SlipOutputSet._sectionCodeList);
                //    dr[CASHREGISTERNO_TITLE] = posTerminalMg.CashRegisterNo;

                //    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                //}
                //--- DEL 2008/06/19 -----------<<<<<

                //--- ADD 2008/06/19 ----------->>>>>
                // 第１グリッド（端末番号）
                if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { posTerminalMg.CashRegisterNo }) == null)
                {
                    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                    dr[CASHREGISTERNO_TITLE] = posTerminalMg.CashRegisterNo;

                    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                }
                //--- ADD 2008/06/19 -----------<<<<<
			}
			catch
			{
			}
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ローカルＤＢ対応拠点情報クラス作成処理
		/// </summary>
		/// <returns>Boolean</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		private Boolean ConstructSecInfoAcs()
		{
			if (this._secInfoAcs == null)
			{
				this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
				if (this._secInfoAcs != null)
				{
					return true;
				}
			}
			return false;
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// 端末別伝票出力先設定読み込み処理
		/// </summary>
		/// <param name="slipOutputSet">端末別伝票出力先設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="cashRegisterNo">端末番号</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="dataInputSystem">データ入力システム</param>		
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 端末別伝票出力先設定情報を読み込みます。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Read(out SlipOutputSet slipOutputSet,
						string enterpriseCode,
                        //string sectionCode,        // DEL 2008/06/20
						Int32 cashRegisterNo,
                        //--- ADD 2008/06/19 ---------->>>>>
                        string warehouseCode,
                        //--- ADD 2008/06/19 ----------<<<<<
                        //----- h.ueno add---------- start 2007.12.19
						Int32 dataInputSystem,
						//----- h.ueno add---------- start 2007.12.19
						Int32 slipPrtKind,
						string slipPrtSetPaperId)
		{			
			try
			{
				int status = 0;
				slipOutputSet = null;
				SlipOutputSetWork slipOutputSetWork = new SlipOutputSetWork();
				
				// キー項目設定
				slipOutputSetWork.EnterpriseCode	= enterpriseCode;
                //slipOutputSetWork.SectionCode		= sectionCode;      // DEL 2008/06/20
				slipOutputSetWork.CashRegisterNo	= cashRegisterNo;
                //--- ADD 2008/06/20 ---------->>>>>
                slipOutputSetWork.WarehouseCode     = warehouseCode;
                //--- ADD 2008/06/20 ----------<<<<<
				//----- h.ueno add---------- start 2007.12.19
				slipOutputSetWork.DataInputSystem	= dataInputSystem;
				//----- h.ueno add---------- start 2007.12.19
				slipOutputSetWork.SlipPrtKind		= slipPrtKind;
				slipOutputSetWork.SlipPrtSetPaperId = slipPrtSetPaperId;

				//----- ueno upd ---------- start 2008.01.31
				if (_isLocalDBRead)
				{
					status = this._slipOutputSetLcDB.Read(ref slipOutputSetWork, 0);
				}
				else
				{
					// XMLへ変換し、文字列のバイナリ化
					byte[] parabyte = XmlByteSerializer.Serialize(slipOutputSetWork);

					// 端末別伝票出力先設定読み込み
					status = this._iSlipOutputSetDB.Read(ref parabyte, 0);

					if (status == 0)
					{
						// XMLの読み込み
						slipOutputSetWork = (SlipOutputSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipOutputSetWork));

						// クラス内メンバコピー
						//slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);
					}
				}

				if (status == 0)
				{
					// クラス内メンバコピー
					slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);
				}
				//----- ueno upd ---------- end 2008.01.31

				return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				slipOutputSet = null;
				//オフライン時はnullをセット
				this._iSlipOutputSetDB = null;
				return -1;
			}
		}

		#region 各種変換
		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>string型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public static string NullChgStr(object obj)
		{
			string ret;
			try
			{
				if (obj == null)
				{
					ret = "";
				}
				else
				{
					ret = obj.ToString();
				}
			}
			catch
			{
				ret = "";
			}
			return ret;
		}

		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>int型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public static int NullChgInt(object obj)
		{
			int ret;
			try
			{
				if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
				{
					ret = 0;
				}
				else
				{
					ret = Convert.ToInt32(obj);
				}
			}
			catch
			{
				ret = 0;
			}
			return ret;
		}
		#endregion
	}
}
