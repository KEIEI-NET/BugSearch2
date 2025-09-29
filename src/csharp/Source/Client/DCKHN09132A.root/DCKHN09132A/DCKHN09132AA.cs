//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：伝票設定マスタ
// プログラム概要   ：伝票設定の登録・修正・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/06/04     修正内容：Partsman用対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2008/08/07     修正内容：得意先マスタ（伝票管理）リストプロパティ追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/10/06     修正内容：バグ修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009/02/04     修正内容：得意先マスタ（伝票管理）情報のみ取得するSearchメソッド追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/17     修正内容：Mantis【12829】速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009.07.13     修正内容：コンストラクタオーバーロード(拠点情報を取得しない)
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先マスタ(伝票管理)テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.09.18</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
	/// <br>Update Note: 2008.03.17 30167 上野　弘貴</br>
	/// <br>			 印刷設定用帳票ＩＤデータ取得追加</br>
    /// <br>Update Note: 2008.06.04 30413 犬飼</br>
    /// <br>             PM.NS対応(拠点コードを追加)</br>
    /// <br>Update Note: 2008.08.07 20056 對馬 大輔</br>
    /// <br>             得意先マスタ（伝票管理）リストプロパティ追加</br>
    /// <br>UpdateNote : 2008/10/06 30462 行澤 仁美　バグ修正</br>
    /// <br>Update Note: 2009.02.04 20056 對馬 大輔</br>
    /// <br>             得意先マスタ（伝票管理）情報のみ取得するSearchメソッド追加</br>
    /// <br>Update Note: 2009.07.13 20056 對馬 大輔</br>
    /// <br>             コンストラクタオーバーロード(拠点情報を取得しない)</br>
    /// </remarks>
	public class CustSlipMngAcs : IGeneralGuideData
	{
		// --------------------------------------------------
		#region Private Members

        // 企業コード
        private string          _enterpriseCode = "";

        /// <summary>得意先マスタ(伝票管理)リモートオブジェクト格納バッファ</summary>
        private ICustSlipMngDB _iCustSlipMngDB = null;

        // データセット
        private DataSet   _bindDataSet = null;
        private DataTable _custslipmngTable = null;

        // マスタクラス格納リスト
        private Dictionary<Guid, CustSlipMngWork> _custslipmngDic = null;     // 得意先マスタ(伝票管理)格納用

        // マスタ取得用リスト
        private ArrayList _custslipmngWorkList = null;                  // 得意先マスタ(伝票管理)取得用

        // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // プロパティセット用リスト
        private ArrayList _custslipMngList = null;
        // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//----- ueno add ---------- start 2008.01.31
		// 伝票印刷設定用マスタアクセスクラス
		private SlipPrtSetAcs _slipPrtSetAcs = null;

		// 印刷設定用帳票コンボボックス用
		public SortedList _slipPrtSetPaperIdList = null;

		// 文字列結合用
		private StringBuilder _stringBuilder = null;
		//----- ueno add ---------- end 2008.01.31

        // 拠点マスタアクセスクラス
        SecInfoAcs _secInfoAcs;     // ADD 2009/04/17

        // ガイド用
        private const string GUIDE_XML_FILENAME = "CUSTSLIPMNGGUIDEPARENT.XML";    // XMLファイル名
        private const string GUIDE_ENTERPRISECODE_TITLE  = "EnterpriseCode";       // 企業コード
        private const string GUIDE_DATAINPUTSYSTEM_TITLE = "DataInputSystem";          // データ入力システム
        private const string GUIDE_DATAINPUTSYSTEMNAME_TITLE = "DataInputSystemName";  // データ入力システム名称
        private const string GUIDE_SLIPPRTKIND_TITLE = "SlipPrtKind";              // 伝票印刷種別コード
        private const string GUIDE_SLIPPRTKINDNAME_TITLE = "SlipPrtKindName";      // 伝票印刷種別名称
        // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";               // 拠点コード
        private const string GUIDE_SECTIONNAME_TITLE = "SectionName";               // 拠点名称
        // 2008.06.04 30413 犬飼 拠点コード追加 <<<<<<END
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";            // 得意先コード
        private const string GUIDE_CUSTOMERNAME_TITLE = "CustomerName";            // 得意先名称
        private const string GUIDE_SLIPPRTSETPAPERID_TITLE = "SlipPrtSetPaperId";  // 伝票印刷設定用帳票ID

		//----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		
		private CustSlipMngLcDB _custSlipMngLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        #endregion

        // --------------------------------------------------
        #region Public Members

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        public static readonly string TBL_CUSTSLIPMNG_TITLE = "CUSTSLIPMNG_TABLE";
        public static readonly string COL_DELETEDATE_TITLE = "削除日";
        public static readonly string COL_DATAINPUTSYSTEM_TITLE = "データ入力システム";
        public static readonly string COL_DATAINPUTSYSTEMNAME_TITLE = "データ入力システム名称";
        public static readonly string COL_SLIPPRTKIND_TITLE = "伝票印刷種別";
        // DEL 2008/10/06 不具合対応[6218]↓
        //public static readonly string COL_SLIPPRTKINDNAME_TITLE = "伝票印刷種別名称";
        public static readonly string COL_SLIPPRTKINDNAME_TITLE = "伝票印刷種別名";   // ADD 2008/10/06 不具合対応[6218]
        // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
        public static readonly string COL_SECTIONCODE_TITLE = "拠点コード";
        // DEL 2008/10/06 不具合対応[6218]↓
        //public static readonly string COL_SECTIONNAME_TITLE = "拠点名称";
        public static readonly string COL_SECTIONNAME_TITLE = "拠点名";   // ADD 2008/10/06 不具合対応[6218]
        // 2008.06.04 30413 犬飼 拠点コード追加 <<<<<<END
        public static readonly string COL_CUSTOMERCODE_TITLE = "得意先コード";
        // DEL 2008/10/06 不具合対応[6218]↓
        //public static readonly string COL_CUSTOMERNAME_TITLE = "得意先名称";
        public static readonly string COL_CUSTOMERNAME_TITLE = "得意先名";   // ADD 2008/10/06 不具合対応[6218]

        // DEL 2008/10/06 不具合対応[6222]↓
        //public static readonly string COL_SLIPPRTSETPAPERID_TITLE = "伝票印刷設定用帳票ID";

        // ADD 2008/10/06 不具合対応[6222] ---------->>>>>
        public static readonly string COL_SLIPPRTSETPAPERID_TITLE = "伝票印刷設定用帳票ID_Dmmy";
        public static readonly string COL_SLIPPRTSETPAPERNAME_TITLE = "伝票印刷設定用帳票ID";
        // ADD 2008/10/06 不具合対応[6222] ----------<<<<<

        public static readonly string COL_GUID_TITLE = "GUID";

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>
        ///得意先マスタ(伝票管理)テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public CustSlipMngAcs()
		{
			try {
				// 企業コード取得
				this._enterpriseCode    = LoginInfoAcquisition.EnterpriseCode;

				// リモートオブジェクト取得
                this._iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();

                // マスタクラス格納リスト初期化
                this._custslipmngDic = new Dictionary<Guid, CustSlipMngWork>();

                // マスタ取得用リスト初期化
                this._custslipmngWorkList = new ArrayList();

                // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // プロパティセット用リスト
                this._custslipMngList = new ArrayList();
                // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // データセット初期化
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();

				//----- ueno add ---------- start 2008.01.31
				// 伝票印刷設定
				this._slipPrtSetAcs = new SlipPrtSetAcs();
								
				// 印刷設定用帳票コンボボックス用
				this._slipPrtSetPaperIdList = new SortedList();
				
				// 文字列結合用
				this._stringBuilder = new StringBuilder();
				//----- ueno add ---------- end 2008.01.31

                this._secInfoAcs = new SecInfoAcs();    // ADD 2009/04/17
			}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iCustSlipMngDB = null;
			}

			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._custSlipMngLcDB = new CustSlipMngLcDB();
			//----- ueno add ---------- end 2008.01.31
		}

        // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 得意先マスタ(伝票管理)テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <param name="mode">処理モード(0:通常(ﾃﾞﾌｫﾙﾄｺﾝｽﾄﾗｸﾀと同様) 1:拠点名称取得なし)</param>
        public CustSlipMngAcs(int mode)
        {
            try
            {
                // 企業コード取得
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // リモートオブジェクト取得
                this._iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();

                // マスタクラス格納リスト初期化
                this._custslipmngDic = new Dictionary<Guid, CustSlipMngWork>();

                // マスタ取得用リスト初期化
                this._custslipmngWorkList = new ArrayList();

                // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // プロパティセット用リスト
                this._custslipMngList = new ArrayList();
                // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // データセット初期化
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();

                //----- ueno add ---------- start 2008.01.31
                // 伝票印刷設定
                this._slipPrtSetAcs = new SlipPrtSetAcs();

                // 印刷設定用帳票コンボボックス用
                this._slipPrtSetPaperIdList = new SortedList();

                // 文字列結合用
                this._stringBuilder = new StringBuilder();
                //----- ueno add ---------- end 2008.01.31

                switch (mode)
                {
                    case 0:
                        this._secInfoAcs = new SecInfoAcs();
                        break;
                    case 1:
                        this._secInfoAcs = null;
                        break;
                    default:
                        this._secInfoAcs = null;
                        break;
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustSlipMngDB = null;
            }

            //----- ueno add ---------- start 2008.01.31
            // ローカルDBアクセスオブジェクト取得
            this._custSlipMngLcDB = new CustSlipMngLcDB();
            //----- ueno add ---------- end 2008.01.31
        }
        // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// 伝票管理マスタテーブル
            this._custslipmngTable = new DataTable(TBL_CUSTSLIPMNG_TITLE);

			// Addを行う順番が、列の表示順位となります。
			this._custslipmngTable.Columns.Add( COL_DELETEDATE_TITLE      , typeof( string ) );      // 削除日
            this._custslipmngTable.Columns.Add( COL_DATAINPUTSYSTEM_TITLE, typeof(Int32));           // データ入力システム
            this._custslipmngTable.Columns.Add( COL_DATAINPUTSYSTEMNAME_TITLE , typeof( string ) );  // データ入力システム名称
            this._custslipmngTable.Columns.Add( COL_SLIPPRTKIND_TITLE     , typeof(Int32));          // 伝票印刷種別
            this._custslipmngTable.Columns.Add( COL_SLIPPRTKINDNAME_TITLE , typeof( string ) );      // 伝票印刷種別名称
            // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
            this._custslipmngTable.Columns.Add(COL_SECTIONCODE_TITLE, typeof(string));              // 拠点コード
            this._custslipmngTable.Columns.Add(COL_SECTIONNAME_TITLE, typeof(string));              // 拠点名称
            // 2008.06.04 30413 犬飼 拠点コード追加 <<<<<<END
            // 2008.06.04 30413 犬飼 得意先コードのコメント化 >>>>>>START
            this._custslipmngTable.Columns.Add( COL_CUSTOMERCODE_TITLE    , typeof(Int32));          // 得意先コード
            // 2008.06.04 30413 犬飼 得意先コードのコメント化 <<<<<<END
            this._custslipmngTable.Columns.Add(COL_CUSTOMERNAME_TITLE, typeof(string));         // 得意先名称
            this._custslipmngTable.Columns.Add( COL_SLIPPRTSETPAPERID_TITLE, typeof(string));        // 帳票ID

            // ADD 2008/10/06 不具合対応[6222] ---------->>>>>
            this._custslipmngTable.Columns.Add(COL_SLIPPRTSETPAPERNAME_TITLE, typeof(string));        // 帳票ID
            // ADD 2008/10/06 不具合対応[6222] ----------<<<<<

            // 2008.06.04 30413 犬飼 GUIDのコメント化 >>>>>>START
            this._custslipmngTable.Columns.Add( COL_GUID_TITLE            , typeof( Guid   ) );      // GUID
            // 2008.06.04 30413 犬飼 GUIDのコメント化 <<<<<<END

            this._custslipmngTable.PrimaryKey = new DataColumn[] { this._custslipmngTable.Columns[COL_GUID_TITLE] };

            this._bindDataSet.Tables.Add(this._custslipmngTable);
		}

		#endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>データセットプロパティ</summary>
        /// <value>データセットを取得します。</value>
        public DataSet BindDataSet
        {
            get
            {
                return this._bindDataSet;
            }
        }
        // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>得意先マスタ（伝票管理）リスト</summary>
        public ArrayList CustSlipMngList
        {
            get { return _custslipMngList; }
        }
        // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ローカルＤＢReadモード
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		//----- ueno add ---------- end 2008.01.31

        #endregion

		// --------------------------------------------------
		#region GetOnlineMode

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// オンラインモードを取得
			if( this._iCustSlipMngDB == null ) {
				// オフライン
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				// オンライン
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

		// --------------------------------------------------
		#region Read Methods

		/// <summary>
        ///読み込み処理
		/// </summary>
        /// <param name="custSlipMng">得意先マスタ(伝票管理)オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="dataInputSystem">データ入力システム</param>
        /// <param name="slipPrtKind">伝票印刷種別コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の読み込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// <br>Update note: 2008.06.04 30413 犬飼</br>
        /// <br>             ・PM.NS対応(拠点コードをparamに追加)</br>
		/// </remarks>
        public int Read(out CustSlipMng custSlipMng, string enterpriseCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
		{
            return this.ReadProc(out custSlipMng, enterpriseCode, dataInputSystem, slipPrtKind, sectionCode, customerCode);
		}

		/// <summary>
        ///得意先マスタ(伝票管理)読み込み処理
		/// </summary>
        /// <param name="custSlipMng">得意先マスタ(伝票管理)オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="dataInputSystem">データ入力システム</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)の読み込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// <br>Update note: 2008.06.04 30413 犬飼</br>
        /// <br>             ・PM.NS対応(拠点コードをparamに追加)</br>
		/// </remarks>
        private int ReadProc(out CustSlipMng custSlipMng, string enterpriseCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode)
		{
            int status1 = 0;

            custSlipMng = null;

            try
            {
                // キー情報をセット
                CustSlipMngWork custSlipMngWork = new CustSlipMngWork();
                custSlipMngWork.EnterpriseCode = enterpriseCode;   // 企業コード
                custSlipMngWork.DataInputSystem = dataInputSystem; // データ入力システム
                custSlipMngWork.SlipPrtKind = slipPrtKind;         // 伝票印刷種別
                // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
                custSlipMngWork.SectionCode = sectionCode;          // 拠点コード
                // 2008.06.04 30413 犬飼 拠点コード追加 <<<<<<END
                custSlipMngWork.CustomerCode = customerCode;       // 得意先コード

				//----- ueno upd ---------- start 2008.01.31
				// ローカル
            	if (_isLocalDBRead)
				{
					status1 = this._custSlipMngLcDB.Read(ref custSlipMngWork, 0);
				}
            	// リモート
				else
				{
	                // XMLへ変換し、文字列のバイナリ化
		            byte[] parabyte = XmlByteSerializer.Serialize(custSlipMngWork);

					//得意先マスタ(伝票管理)読み込み
					status1 = this._iCustSlipMngDB.Read(ref parabyte, 0);

					if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// デシリアライズ処理
						custSlipMngWork = (CustSlipMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSlipMngWork));
						// 結果をメンバコピー
						//custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
					}
				}

				if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 結果をメンバコピー
					custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
				}
				//----- ueno upd ---------- emd 2008.01.31

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                custSlipMng = null;
                this._iCustSlipMngDB = null;

                // 通信エラーは-1を返す
                status1 = -1;
            }

			return status1;
		}

		#endregion

		// --------------------------------------------------
		#region Write Methods

		/// <summary>
        ///書き込み処理
		/// </summary>
        /// <param name="custSlipMng">得意先マスタ(伝票管理)オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Write(CustSlipMng custSlipMng)
        {
            // 得意先マスタ(伝票管理)更新
            return this.WriteProc(custSlipMng);
        }

		/// <summary>
        ///得意先マスタ(伝票管理)書き込み処理
		/// </summary>
        /// <param name="custSlipMng">得意先マスタ(伝票管理)オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)の書き込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int WriteProc(CustSlipMng custSlipMng)
		{
			int status = 0;

			try {
                CustSlipMngWork custSlipMngWork = new CustSlipMngWork();

                // 編集前情報取得
                if (this._custslipmngDic.ContainsKey(custSlipMng.FileHeaderGuid) == true)
                {
                    custSlipMngWork = (this._custslipmngDic[custSlipMng.FileHeaderGuid] as CustSlipMngWork);
                }

                // 編集情報取得
                CopyToCustSlipMngWorkFromDispCustSlipMng(ref custSlipMngWork, custSlipMng);

                object retObj = (object)custSlipMngWork;

                //得意先マスタ(伝票管理)書き込み
                status = this._iCustSlipMngDB.Write(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    custSlipMngWork = (CustSlipMngWork)retArray[0];
                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustSlipMngDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region LogicalDelete Methods

		/// <summary>
        ///論理削除処理
		/// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(伝票管理)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // 得意先マスタ(伝票管理)論理削除
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///得意先マスタ(伝票管理)論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(伝票管理)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)の論理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                CustSlipMngWork custSlipMngWork = (this._custslipmngDic[fileHeaderGuid] as CustSlipMngWork);

                object retObj = (object)custSlipMngWork;

                //得意先マスタ(伝票管理)論理削除
                status = this._iCustSlipMngDB.LogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    custSlipMngWork = (CustSlipMngWork)retObj;
                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustSlipMngDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
        }

		#endregion

		// --------------------------------------------------
		#region Revival Methods

		/// <summary>
        ///論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(伝票管理)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除復活処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // 得意先マスタ(伝票管理)復活
            return this.RevivalProc(fileHeaderGuid);
        }

		/// <summary>
        ///得意先マスタ(伝票管理)論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(伝票管理)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)の論理削除復活処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                CustSlipMngWork custSlipMngWork = (this._custslipmngDic[fileHeaderGuid] as CustSlipMngWork);

                object retObj = (object)custSlipMngWork;

                //得意先マスタ(伝票管理)論理削除復活
                status = this._iCustSlipMngDB.RevivalLogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    custSlipMngWork = (CustSlipMngWork)retObj;
                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustSlipMngDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Delete Methods

		/// <summary>
        ///物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(伝票管理)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // 得意先マスタ(伝票管理)物理削除
            return this.DeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///得意先マスタ(伝票管理)物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(伝票管理)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)の物理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                CustSlipMngWork custSlipMngWork = (this._custslipmngDic[fileHeaderGuid] as CustSlipMngWork);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(custSlipMngWork);

                //得意先マスタ(伝票管理)物理削除
                status = this._iCustSlipMngDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._custslipmngDic.Remove(custSlipMngWork.FileHeaderGuid);
                    // データテーブルから削除
                    DataRow dr = this._custslipmngTable.Rows.Find(custSlipMngWork.FileHeaderGuid);
                    
                    dr.Delete();
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustSlipMngDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Search Methods

		/// <summary>
        ///検索処理(論理削除除く)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Search(out int totalCount, string enterpriseCode)
        {
            // 得意先マスタ(伝票管理)検索
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }

        // 2009.02.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 検索処理（論理削除除く、CustSlipMngのみSearch）
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        public int SearchOnlyCustSlipMng(out int totalCount, string enterpriseCode)
        {
            return this.SearchProcOnlyCustSlipMng(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2009.02.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///検索処理(論理削除含む)
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int SearchAll(out int totalCount, string enterpriseCode)
        {
            // 得意先マスタ(伝票管理)検索
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        ///検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private int SearchProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

			//----- h.ueno add ---------- start 2008.03.17
			//============================
			// 伝票印刷設定マスタ読み込み
			//============================
			// 伝票印刷設定用帳票ID全取得
			ArrayList slipPrtRetList = null;

			// 伝票印刷設定用ローカルフラグ設定
			this._slipPrtSetAcs.IsLocalDBRead = _isLocalDBRead;

			int status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, enterpriseCode);

			if ((status == 0) && (slipPrtRetList.Count > 0))
			{
                this._slipPrtSetPaperIdList = new SortedList();

				string key = "";

				foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
				{
					//--------------------------------------------------------------------
					// Key  ：ファイルレイアウトのキー項目を結合する
					//   ﾃﾞｰﾀ入力ｼｽﾃﾑ(2桁) + 伝票印刷種別(4桁)＋伝票印刷設定用帳票ID(24桁)
					// Value：伝票印刷設定マスタクラス
					//--------------------------------------------------------------------
					this._stringBuilder.Remove(0, this._stringBuilder.Length);
					this._stringBuilder.Append(slipPrtSet.DataInputSystem.ToString("d2"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtKind.ToString("d4"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtSetPaperId.TrimEnd());
					key = this._stringBuilder.ToString();

					this._slipPrtSetPaperIdList.Add(key, slipPrtSet);
				}
			}
			//----- h.ueno add ---------- end 2008.03.17

            // 得意先マスタ(伝票管理)検索
            status1 = this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // キャッシュ処理
            status2 = this.Cache(this._custslipmngWorkList);
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }


            // ステータス判断
            if ((status1 == (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status2 == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        // 2009.02.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 得意先マスタ（伝票管理）検索処理（CustSlipMngのみSearch）
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns></returns>
        private int SearchProcOnlyCustSlipMng(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            return this.SearchSlipTypeMngProc(out totalCount, enterpriseCode, logicalMode);
        }
        // 2009.02.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///得意先マスタ(伝票管理)検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)の検索処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private int SearchSlipTypeMngProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._custslipmngWorkList.Clear();

                // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // プロパティセット用リスト
                this._custslipMngList.Clear();
                // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // キャッシュ用テーブルをクリア
                this._custslipmngDic.Clear();

                // キー情報をセット
                CustSlipMngWork paramCustSlipMngWork = new CustSlipMngWork();
                paramCustSlipMngWork.EnterpriseCode = enterpriseCode;    // 企業コード

                object retobj = null;

				//----- ueno upd ---------- start 2008.01.31
				// ローカル
				if (_isLocalDBRead)
				{
					List<CustSlipMngWork> custSlipMngWorkList = new List<CustSlipMngWork>();
					status = this._custSlipMngLcDB.Search(out custSlipMngWorkList, paramCustSlipMngWork, 0, logicalMode);
					
					if(status == 0)
					{
						ArrayList al = new ArrayList();
						al.AddRange(custSlipMngWorkList);
						retobj = (object)al;
					}
				}
				// リモート
				else
				{
					//得意先マスタ(伝票管理)検索
					status = this._iCustSlipMngDB.Search(out retobj, paramCustSlipMngWork, 0, logicalMode);
				}
				//----- ueno upd ---------- end 2008.01.31

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._custslipmngWorkList = retobj as ArrayList;

                    // 2008.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // プロパティセット用リスト作成
                    this._custslipMngList = this.CopyToCustSlipMngListFromCustSlipMngWorkList(this._custslipmngWorkList);
                    // 2008.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 該当件数格納
                    totalCount = this._custslipmngWorkList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustSlipMngDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }
		#endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// マスタキャッシュ処理
        /// </summary>
        /// <param name="custSlipMngList">伝票管理マスタ取得結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int Cache(ArrayList custSlipMngWorkList)
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._custslipmngTable.BeginLoadData();

                    // テーブルをクリア
                    this._custslipmngTable.Clear();

                    // 管理データをDataSetに格納
                    foreach (CustSlipMngWork custSlipMngWork in custSlipMngWorkList)
                    {
                        // 2008.10.17 30413 犬飼 伝票印刷種別の追加 >>>>>>START
                        // 2008.09.26 30413 犬飼 見積書と納品書のみ抽出 >>>>>>START
                        //// 2008.09.22 30413 犬飼 未登録以外もデータセットへ追加するように修正 >>>>>>START
                        //// この処理に来る前にディクショナリーへの登録がされているので検索結果が
                        //// ビューに表示出来ない状況
                        ////// 未登録の時
                        ////if (this._custslipmngDic.ContainsKey(custSlipMngWork.FileHeaderGuid) == false)
                        ////{
                        //    //// データセットに追加
                        //    //this.CustSlipMngWorkToDataSet(custSlipMngWork);
                        ////}
                        //// データセットに追加
                        //this.CustSlipMngWorkToDataSet(custSlipMngWork);
                        //// 2008.09.22 30413 犬飼 未登録以外もデータセットへ追加するように修正 <<<<<<END
                        //if ((custSlipMngWork.SlipPrtKind == 10) || (custSlipMngWork.SlipPrtKind == 30))
                        //{
                        //    this.CustSlipMngWorkToDataSet(custSlipMngWork);
                        //}
                        switch (custSlipMngWork.SlipPrtKind)
                        {
                            case 10:        // 見積書
                            case 30:        // 売上伝票
                            case 120:       // 受注伝票
                            case 130:       // 貸出伝票
                            case 140:       // 見積伝票
                            case 150:       // 在庫移動伝票
                            case 160:       // ＵＯＥ伝票
                                {
                                    this.CustSlipMngWorkToDataSet(custSlipMngWork);
                                    break;
                                }
                        }
                        // 2008.09.26 30413 犬飼 見積書と納品書のみ抽出 <<<<<<END
                        // 2008.10.17 30413 犬飼 伝票印刷種別の追加 <<<<<<END
                    }
                }
                finally
                {
                    // 更新処理終了
                    this._custslipmngTable.EndLoadData();

                    // ソート
                    this._custslipmngTable.DefaultView.Sort = COL_SLIPPRTKIND_TITLE + " ASC";           // 伝票印刷種別コード
                    this._custslipmngTable.AcceptChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>
        /// クラスメンバコピー処理 (画面変更得意先マスタ(伝票管理)クラス⇒得意先マスタ(伝票管理)ワーククラス)
        /// </summary>
        /// <param name="custSlipMngWork">得意先マスタ(伝票管理)ワーククラス</param>
        /// <param name="custSlipMng">得意先マスタ(伝票管理)クラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更得意先マスタ(伝票管理)クラスから
        ///                  得意先マスタ(伝票管理)ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void CopyToCustSlipMngWorkFromDispCustSlipMng(ref CustSlipMngWork custSlipMngWork, CustSlipMng custSlipMng)
        {
            custSlipMngWork.EnterpriseCode   = custSlipMng.EnterpriseCode;         // 企業コード
            custSlipMngWork.DataInputSystem = custSlipMng.DataInputSystem;         
            custSlipMngWork.SlipPrtKind    = custSlipMng.SlipPrtKind;              // 伝票印刷種別
            // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
            custSlipMngWork.SectionCode = custSlipMng.SectionCode;                  // 拠点コード
            // 2008.06.03 30413 犬飼 拠点コード追加 <<<<<<END
            custSlipMngWork.CustomerCode = custSlipMng.CustomerCode;            // 得意先コード
            custSlipMngWork.CustomerSnm = custSlipMng.CustomerSnm;                 // 得意先名称
            custSlipMngWork.SlipPrtSetPaperId = custSlipMng.SlipPrtSetPaperId;  // 帳票ID
        }

        /// <summary>
        /// クラスメンバコピー処理 (得意先マスタ(伝票管理)ワーククラスリスト⇒得意先マスタ(伝票管理)クラスリスト)
        /// </summary>
        /// <param name="custSlipMngWorkList"></param>
        /// <returns></returns>
        private ArrayList CopyToCustSlipMngListFromCustSlipMngWorkList(ArrayList custSlipMngWorkList)
        {
            ArrayList retList = new ArrayList();
            foreach (CustSlipMngWork custSlipMngWork in custSlipMngWorkList)
            {
                // 2008.10.17 30413 犬飼 伝票印刷種別の追加 >>>>>>START
                // 2008.09.29 30413 犬飼 見積書と納品書のみ抽出 >>>>>>START
                //CustSlipMng custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
                //retList.Add(custSlipMng);
                //if ((custSlipMngWork.SlipPrtKind == 10) || (custSlipMngWork.SlipPrtKind == 30))
                //{
                //    CustSlipMng custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
                //    retList.Add(custSlipMng);
                //}
                switch (custSlipMngWork.SlipPrtKind)
                {
                    case 10:        // 見積書
                    case 30:        // 売上伝票
                    case 120:       // 受注伝票
                    case 130:       // 貸出伝票
                    case 140:       // 見積伝票
                    case 150:       // 在庫移動伝票
                    case 160:       // ＵＯＥ伝票
                        {
                            CustSlipMng custSlipMng = this.CopyToCustSlipMngFromCustSlipMngWork(custSlipMngWork);
                            retList.Add(custSlipMng);
                            break;
                        }
                }
                // 2008.09.29 30413 犬飼 見積書と納品書のみ抽出 <<<<<<END
                // 2008.10.17 30413 犬飼 伝票印刷種別の追加 <<<<<<END
            }
            return retList;
        }

		/// <summary>
        /// クラスメンバコピー処理 (得意先マスタ(伝票管理)ワーククラス⇒得意先マスタ(伝票管理)クラス)
		/// </summary>
        /// <param name="custSlipMngWork">得意先マスタ(伝票管理)ワーククラス</param>
        /// <returns>得意先マスタ(伝票管理)クラス</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)ワーククラスから
        ///                  得意先マスタ(伝票管理)クラスへメンバコピーを行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private CustSlipMng CopyToCustSlipMngFromCustSlipMngWork(CustSlipMngWork custSlipMngWork)
        {
            CustSlipMng custSlipMng = new CustSlipMng();

            custSlipMng.CreateDateTime = custSlipMngWork.CreateDateTime;        // 作成日時
            custSlipMng.UpdateDateTime = custSlipMngWork.UpdateDateTime;        // 更新日時
            custSlipMng.EnterpriseCode = custSlipMngWork.EnterpriseCode;        // 企業コード
            custSlipMng.FileHeaderGuid = custSlipMngWork.FileHeaderGuid;        // GUID
            custSlipMng.UpdEmployeeCode = custSlipMngWork.UpdEmployeeCode;      // 更新従業員コード
            custSlipMng.UpdAssemblyId1 = custSlipMngWork.UpdAssemblyId1;        // 更新アセンブリID1
            custSlipMng.UpdAssemblyId2 = custSlipMngWork.UpdAssemblyId2;        // 更新アセンブリID2
            custSlipMng.LogicalDeleteCode = custSlipMngWork.LogicalDeleteCode;  // 論理削除区分
            custSlipMng.DataInputSystem = custSlipMngWork.DataInputSystem;      // データ入力システム
            custSlipMng.SlipPrtKind = custSlipMngWork.SlipPrtKind;              // 伝票印刷種別
            // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
            custSlipMng.SectionCode = custSlipMngWork.SectionCode;              // 拠点コード
            // 2008.06.03 30413 犬飼 拠点コード追加 <<<<<<END
            custSlipMng.CustomerCode = custSlipMngWork.CustomerCode;            // 得意先コード
            custSlipMng.CustomerSnm = custSlipMngWork.CustomerSnm;              // 得意先名称
            custSlipMng.SlipPrtSetPaperId = custSlipMngWork.SlipPrtSetPaperId;  // 帳票ID
            
            // テーブル更新
            _custslipmngDic[custSlipMngWork.FileHeaderGuid] = custSlipMngWork;

            return custSlipMng;
        }

        /// <summary>
        /// 得意先マスタ(伝票管理)オブジェクトメインDataSet展開処理
        /// </summary>
        /// <param name="custSlipMngWork">得意先マスタ(伝票管理)オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)オブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private void CustSlipMngWorkToDataSet(CustSlipMngWork custSlipMngWork)
        {
            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            DataRow dr = this._custslipmngTable.Rows.Find(custSlipMngWork.FileHeaderGuid);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._custslipmngTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 削除日
            if (custSlipMngWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custSlipMngWork.UpdateDateTime);
            }

            // データ入力システム
            dr[COL_DATAINPUTSYSTEM_TITLE] = custSlipMngWork.DataInputSystem;
            // データ入力システム名称
            switch (custSlipMngWork.DataInputSystem)
            {
                case 0: 
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "共通";
                    break;
                }
                case 1: 
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "整備";
                    break;
                }
                case 2:
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "鈑金";
                    break;
                }
                case 3:
                {
                    dr[COL_DATAINPUTSYSTEMNAME_TITLE] = "車販";
                    break;
                }
            }
            // 伝票印刷種別
            dr[COL_SLIPPRTKIND_TITLE] = custSlipMngWork.SlipPrtKind;
            // 伝票印刷種別名称
            switch (custSlipMngWork.SlipPrtKind)
            {
                case 10:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "見積書";
                        break;
                    }
                case 20:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "指示書(注文書)";
                        break;
                    }
                case 21:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "承り書";
                        break;
                    }
                case 30:
                    {
                        // 2008.10.17 30413 犬飼 納品書→売上伝票に変更 >>>>>>START
                        //dr[COL_SLIPPRTKINDNAME_TITLE] = "納品書";
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "売上伝票";
                        // 2008.10.17 30413 犬飼 納品書→売上伝票に変更 <<<<<<END
                        break;
                    }
                case 40:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "返品伝票";
                        break;
                    }
				case 100:
					{
						dr[COL_SLIPPRTKINDNAME_TITLE] = "ワークシート";
						break;
					}
				case 110:
					{
						dr[COL_SLIPPRTKINDNAME_TITLE] = "ボディ寸法図";
						break;
					}
                // 2008.10.17 30413 犬飼 伝票印刷種別の追加 >>>>>>START
                case 120:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "受注伝票";
                        break;
                    }
                case 130:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "貸出伝票";
                        break;
                    }
                case 140:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "見積伝票";
                        break;
                    }
                case 150:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "在庫移動伝票";
                        break;
                    }
                case 160:
                    {
                        dr[COL_SLIPPRTKINDNAME_TITLE] = "ＵＯＥ伝票";
                        break;
                    }
                // 2008.10.17 30413 犬飼 伝票印刷種別の追加 <<<<<<END
            }

            // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
            // 拠点コード
            dr[COL_SECTIONCODE_TITLE] = custSlipMngWork.SectionCode;
            // 拠点名称
            // TODO 名称が無い、、
            //dr[COL_SECTIONNAME_TITLE] = custSlipMngWork.SectionName;
            if ((int.Parse(custSlipMngWork.SectionCode) == 0) && (custSlipMngWork.CustomerCode == 0))
            {
                // 拠点コードがゼロで、得意先コードが設定されていない
                dr[COL_SECTIONNAME_TITLE] = "全社共通";
            }
            else
            {
                dr[COL_SECTIONNAME_TITLE] = GetSectionName(custSlipMngWork.SectionCode);
            }
            // 2008.06.03 30413 犬飼 拠点コード追加 <<<<<<END
            // 得意先コード
            dr[COL_CUSTOMERCODE_TITLE] = custSlipMngWork.CustomerCode;
            // 得意先名称
            dr[COL_CUSTOMERNAME_TITLE] = custSlipMngWork.CustomerSnm;
            // 帳票ID
            dr[COL_SLIPPRTSETPAPERID_TITLE] = custSlipMngWork.SlipPrtSetPaperId;

            // ADD 2008/10/06 不具合対応[6222] ---------->>>>>
            // 帳票名称
            //dr[COL_SLIPPRTSETPAPERNAME_TITLE] = GetSlipPrtSetPaperName(custSlipMngWork.SlipPrtSetPaperId);    // DEL 2009/04/17
            dr[COL_SLIPPRTSETPAPERNAME_TITLE] = GetSlipPrtSetPaperName(custSlipMngWork);                        // ADD 2009/04/17
            // ADD 2008/10/06 不具合対応[6222] ----------<<<<<

            // GUID
            dr[COL_GUID_TITLE] = custSlipMngWork.FileHeaderGuid;

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._custslipmngTable.Rows.Add(dr);
            }


            // テーブルに格納
            if (this._custslipmngDic.ContainsKey(custSlipMngWork.FileHeaderGuid) == true)
            {
                this._custslipmngDic.Remove(custSlipMngWork.FileHeaderGuid);
            }
            this._custslipmngDic.Add(custSlipMngWork.FileHeaderGuid, custSlipMngWork);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008/06/09</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (this._secInfoAcs == null) return sectionName;
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            ArrayList retList = new ArrayList();
            //SecInfoAcs secInfoAcs = new SecInfoAcs();     // DEL 2009/04/17

            try
            {
                //foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)          // DEL 2009/04/17
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)      // ADD 2009/04/17
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// 印刷設定用帳票名称名称取得処理
        /// </summary>
        /// <param name="slipPrtSetPaperId">印刷設定用帳票ID</param>
        /// <returns>印刷設定用帳票名称</returns>
        /// <remarks>
        /// <br>Note       : 印刷設定用帳票名称を取得します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008/10/07</br>
        /// </remarks> 
        //private string GetSlipPrtSetPaperName(string slipPrtSetPaperId)           // DEL 2009/04/17
        private string GetSlipPrtSetPaperName(CustSlipMngWork custSlipMngWork)      // ADD 2009/04/17
        {
            string slipPrtSetPaperName = "";

            // DEL 2009/04/17 ------>>>
            //ArrayList slipPrtRetList = null;

            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //int status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, this._enterpriseCode);

            //if ((status == 0) && (slipPrtRetList.Count > 0))
            //{
            //    try
            //    {

            //        foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
            //        {
            //            if (slipPrtSetPaperId.Trim() == slipPrtSet.SlipPrtSetPaperId.Trim())
            //            {
            //                slipPrtSetPaperName = slipPrtSet.SlipComment.TrimEnd();
            //            }
            //        }                   
            //    }
            //    catch
            //    {
            //        slipPrtSetPaperName = "";
            //    }
            //}
            //else
            //{
            //    slipPrtSetPaperName = "";
            //}
            // DEL 2009/04/17 ------<<<

            // ADD 2009/04/17 ------>>>
            string key = "";
            this._stringBuilder.Remove(0, this._stringBuilder.Length);
            this._stringBuilder.Append(custSlipMngWork.DataInputSystem.ToString("d2"));
            this._stringBuilder.Append(custSlipMngWork.SlipPrtKind.ToString("d4"));
            this._stringBuilder.Append(custSlipMngWork.SlipPrtSetPaperId.TrimEnd());
            key = this._stringBuilder.ToString();

            if (this._slipPrtSetPaperIdList.ContainsKey(key))
            {
                SlipPrtSet slipPrtSet = (SlipPrtSet)this._slipPrtSetPaperIdList[key];
                slipPrtSetPaperName = slipPrtSet.SlipComment.TrimEnd();
            }
            // ADD 2009/04/17 ------<<<
            
            return slipPrtSetPaperName;

        }
		#endregion

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="custSlipMng">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out CustSlipMng custSlipMng)
        {
            int status = -1;
            custSlipMng = new CustSlipMng();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add(GUIDE_ENTERPRISECODE_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                custSlipMng.DataInputSystem = (int)retObj[GUIDE_DATAINPUTSYSTEM_TITLE];              // データ入力システム
                custSlipMng.SlipPrtKind = (int)retObj[GUIDE_SLIPPRTKIND_TITLE];                      // 伝票印刷種別
                // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
                custSlipMng.SectionCode = retObj[GUIDE_SECTIONCODE_TITLE].ToString();                 // 拠点コード
                //custSlipMng.SectionCode = retObj[GUIDE_SECTIONNAME_TITLE].ToString();                 // 拠点名称
                // 2008.06.04 30413 犬飼 拠点コード追加 <<<<<<END
                custSlipMng.CustomerCode = (int)retObj[GUIDE_CUSTOMERCODE_TITLE];                    // 得意先コード
                custSlipMng.CustomerSnm  = retObj[GUIDE_CUSTOMERNAME_TITLE].ToString();              // 得意先名称
                custSlipMng.SlipPrtSetPaperId = retObj[GUIDE_SLIPPRTSETPAPERID_TITLE].ToString();    // 帳票ID
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // 企業コード設定有り
            if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_TITLE))
            {
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_TITLE].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }

            // マスタテーブル読込み
            int iCnt = 0;
            status = Search(out iCnt, enterpriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // ガイド初期起動時はカラム設定をおこなう
                        if (guideList.Tables.Count == 0)
                        {
                            DataTable table = new DataTable();
                            DataColumn column;

                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_DATAINPUTSYSTEM_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_DATAINPUTSYSTEMNAME_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = System.Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKIND_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTKINDNAME_TITLE;
                            table.Columns.Add(column);

                            // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SECTIONCODE_TITLE;
                            table.Columns.Add(column);
                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SECTIONNAME_TITLE;
                            table.Columns.Add(column);
                            // 2008.06.03 30413 犬飼 拠点コード追加 <<<<<<END

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CUSTOMERCODE_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CUSTOMERNAME_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_SLIPPRTSETPAPERID_TITLE;
                            table.Columns.Add(column);

                            guideList.Tables.Add(table.Clone());
                        }

                        // ガイド用データセットの作成
                        GetGuideDataSet(ref guideList, mode);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    {
                        status = -1;
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// ガイド用データセット作成処理
        /// </summary>
        /// <param name="retDataSet">結果取得データセット</param>>
        /// <param name="mode">汎用ガイド表示切替(0:通常表示 5:全件表示)</param>>
        /// <remarks>
        /// <br>Note	   : ガイド用データセット処理を行なう</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, int mode)
        {
            int dataCnt = 0;

            // 行を初期化して新しいデータを追加
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();
            switch (mode)
            {
                // 通常表示
                case 0:
                // 全件表示
                case 5:
                    {
                        while (dataCnt < this._custslipmngTable.Rows.Count)
                        {
                            // 論理削除区分:有効
                            if ((string)this._custslipmngTable.DefaultView[dataCnt][COL_DELETEDATE_TITLE] == "")
                            {
                                DataRow dr = retDataSet.Tables[0].NewRow();
                                dr[GUIDE_DATAINPUTSYSTEM_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_DATAINPUTSYSTEM_TITLE];
                                dr[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_DATAINPUTSYSTEMNAME_TITLE];
                                // 伝票印刷種別コード
                                dr[GUIDE_SLIPPRTKIND_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SLIPPRTKIND_TITLE];
                                // 伝票印刷種別名称
                                dr[GUIDE_SLIPPRTKINDNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SLIPPRTKINDNAME_TITLE];
                                // 2008.06.04 30413 犬飼 拠点コード追加 >>>>>>START
                                dr[GUIDE_SECTIONCODE_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SECTIONCODE_TITLE];
                                dr[GUIDE_SECTIONNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SECTIONNAME_TITLE];
                                // 2008.06.03 30413 犬飼 拠点コード追加 <<<<<<END
                                // 得意先コード
                                dr[GUIDE_CUSTOMERCODE_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_CUSTOMERCODE_TITLE];
                                // 得意先名称
                                dr[GUIDE_CUSTOMERNAME_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_CUSTOMERNAME_TITLE];
                                // 帳票ID
                                dr[GUIDE_SLIPPRTSETPAPERID_TITLE] = this._custslipmngTable.DefaultView[dataCnt][COL_SLIPPRTSETPAPERID_TITLE];

                                retDataSet.Tables[0].Rows.Add(dr);
                            }
                            dataCnt++;
                        }
                        break;
                    }
            }
            retDataSet.Tables[0].EndLoadData();
        }

        #endregion

		// --------------------------------------------------
		#region 比較用クラス

        /// <summary>
        ///得意先マスタ(伝票管理)比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(伝票管理)オブジェクトの比較を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public class CustSlipMngCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>
            /// 比較用メソッド
            /// </summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 得意先マスタ(伝票管理)オブジェクトの比較を行います。</br>
            /// <br>Programmer : 20081 疋田 勇人</br>
            /// <br>Date       : 2007.09.18</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustSlipMng obj1 = x as CustSlipMng;
                CustSlipMng obj2 = y as CustSlipMng;

                // 伝票印刷種別で比較
                return obj1.SlipPrtKind.CompareTo(obj2.SlipPrtKind);
            }

            #endregion
        }

		#endregion

	}
}
