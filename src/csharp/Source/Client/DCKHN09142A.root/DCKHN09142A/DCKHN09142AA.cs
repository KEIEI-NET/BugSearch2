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

namespace Broadleaf.Application.Controller
{
	/// <summary>
    ///得意先マスタ(変動情報)テーブルアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先マスタ(変動情報)テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.09.18</br>
    /// <br>Update     : 2008/10/16 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>             2008/12/03 照田 貴志　バグ修正</br>
    /// <br>             2008/12/10 照田 貴志　データービューに論理削除された得意先を表示しないように修正</br>
    /// <br>             2009/02/09 忍 幸史　障害ID:9239,10981対応</br>
	/// </remarks>
	public class CustomerChangeAcs : IGeneralGuideData
	{
		// --------------------------------------------------
		#region Private Members

        // 企業コード
        private string          _enterpriseCode = "";

        /// <summary>得意先マスタ(変動情報)リモートオブジェクト格納バッファ</summary>
        private ICustomerChangeDB _iCustomerChangeDB = null;

        // データセット
        private DataSet   _bindDataSet = null;
        private DataTable _customerchangeTable = null;

        // マスタクラス格納リスト
        private Dictionary<Guid, CustomerChangeWork> _customerchangeDic = null;  // 得意先マスタ(変動情報)格納用

        // マスタ取得用リスト
        private ArrayList       _customerChangeList     = null;                  // 得意先マスタ(変動情報)取得用

        // 得意先マスタアクセスクラス
        private CustomerSearchAcs _customerSearchAcs = null;                    //ADD 2008/12/10 不具合対応[8897][8901]

        // --- ADD 2009/02/09 障害ID:10981対応------------------------------------------------------>>>>>
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        // --- ADD 2009/02/09 障害ID:10981対応------------------------------------------------------<<<<<

        // ガイド用
        private const string GUIDE_XML_FILENAME = "CUSTOMERCHANGEGUIDEPARENT.XML";  // XMLファイル名
        private const string GUIDE_ENTERPRISECODE_TITLE  = "EnterpriseCode";        // 企業コード
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";             // 得意先コード
        private const string GUIDE_CUSTOMERSNM_TITLE = "CustomerSnm";          // 得意先略称
        private const string GUIDE_CREDITMONEY_TITLE = "CreditMoney";               // 与信額
        private const string GUIDE_WARNINGCREDITMONEY_TITLE = "WarningCreditMoney"; // 警告与信額
        #endregion

        // --------------------------------------------------
        #region Public Members
        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        public static readonly string TBL_CUSTOMERCHANGE_TITLE = "CUSTOMERCHANGE_TABLE";
        public static readonly string COL_DELETEDATE_TITLE = "削除日";
        public static readonly string COL_CUSTOMERCODE_TITLE = "得意先コード";
        public static readonly string COL_CUSTOMERSNM_TITLE = "得意先略称";
        public static readonly string COL_CREDITMONEY_TITLE = "与信額";
        public static readonly string COL_WARNINGCREDITMONEY_TITLE = "警告与信額";
        public static readonly string COL_PRSNTACCRECBALANCE_TITLE = "現在売掛残高";
        public static readonly string COL_PRESENTCUSTSLIPNO_TITLE = "現在得意先伝票番号";
        public static readonly string COL_STARTCUSTSLIPNO_TITLE = "開始得意先伝票番号";
        public static readonly string COL_ENDCUSTSLIPNO_TITLE = "終了得意先伝票番号";
        public static readonly string COL_NOCHARCTERCOUNT_TITLE = "番号桁数";
        public static readonly string COL_CUSTSLIPNOHEADER_TITLE = "得意先伝票番号ヘッダ";
        public static readonly string COL_CUSTSLIPNOFOOTER_TITLE = "得意先伝票番号フッタ";
        public static readonly string COL_GUID_TITLE = "GUID";
        #endregion        
        // --------------------------------------------------
		#region Constructor

		/// <summary>
        ///得意先マスタ(変動情報)テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public CustomerChangeAcs()
		{
			try {
				// 企業コード取得
				this._enterpriseCode    = LoginInfoAcquisition.EnterpriseCode;

				// リモートオブジェクト取得
                this._iCustomerChangeDB = (ICustomerChangeDB)MediationCustomerChangeDB.GetCustomerChangeDB();

                // マスタクラス格納リスト初期化
                this._customerchangeDic = new Dictionary<Guid, CustomerChangeWork>();

                // マスタ取得用リスト初期化
                this._customerChangeList = new ArrayList();

                // データセット初期化
                this._bindDataSet = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();

                //得意先マスタアクセスクラスインスタンス化
                this._customerSearchAcs = new CustomerSearchAcs();          //ADD 2008/12/10 不具合対応[8897][8901]

                // --- ADD 2009/02/09 障害ID:10981対応------------------------------------------------------>>>>>
                ReadCustomerSearchRet();
                // --- ADD 2009/02/09 障害ID:10981対応------------------------------------------------------<<<<<
            }
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iCustomerChangeDB = null;
			}
		}

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
			// 得意先マスタ(変動情報)テーブル
            this._customerchangeTable = new DataTable(TBL_CUSTOMERCHANGE_TITLE);

			// Addを行う順番が、列の表示順位となります。
			this._customerchangeTable.Columns.Add( COL_DELETEDATE_TITLE , typeof( string ) );       // 削除日
            this._customerchangeTable.Columns.Add( COL_CUSTOMERCODE_TITLE , typeof(Int32));         // 得意先コード
            this._customerchangeTable.Columns.Add( COL_CUSTOMERSNM_TITLE , typeof( string ) );      // 得意先名称
            this._customerchangeTable.Columns.Add( COL_CREDITMONEY_TITLE , typeof(Int64));          // 与信額
            this._customerchangeTable.Columns.Add( COL_WARNINGCREDITMONEY_TITLE , typeof(Int64));   // 警告与信額
            this._customerchangeTable.Columns.Add( COL_PRSNTACCRECBALANCE_TITLE , typeof(Int64));   // 現在売掛残高
            //--- DEL 2008/06/26 ---------->>>>>
            //this._customerchangeTable.Columns.Add(COL_PRESENTCUSTSLIPNO_TITLE, typeof(Int64));    // 現在得意先伝票番号
            //this._customerchangeTable.Columns.Add(COL_STARTCUSTSLIPNO_TITLE, typeof(Int64));      // 開始得意先伝票番号
            //this._customerchangeTable.Columns.Add(COL_ENDCUSTSLIPNO_TITLE, typeof(Int64));        // 終了得意先伝票番号
            //this._customerchangeTable.Columns.Add(COL_NOCHARCTERCOUNT_TITLE, typeof(Int32));      // 番号桁数
            //this._customerchangeTable.Columns.Add(COL_CUSTSLIPNOHEADER_TITLE, typeof(string));    // 得意先伝票番号ヘッダ
            //this._customerchangeTable.Columns.Add(COL_CUSTSLIPNOFOOTER_TITLE, typeof(string));    // 得意先伝票番号フッタ
            //--- DEL 2008/06/26 ---------->>>>>
            this._customerchangeTable.Columns.Add(COL_GUID_TITLE, typeof(Guid));  // GUID
            // PrimaryKey設定
            this._customerchangeTable.PrimaryKey = new DataColumn[] { this._customerchangeTable.Columns[COL_CUSTOMERCODE_TITLE] };  // 得意先コード
                                                                   
            this._bindDataSet.Tables.Add(this._customerchangeTable);
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
			if( this._iCustomerChangeDB == null ) {
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
        /// <param name="customerChange">得意先マスタ(変動情報)オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の読み込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Read(out CustomerChange customerChange, string enterpriseCode, Int32 customerCode)
		{
            return this.ReadProc(out customerChange, enterpriseCode, customerCode);
		}

		/// <summary>
        ///得意先マスタ(変動情報)読み込み処理
		/// </summary>
        /// <param name="customerChange">得意先マスタ(変動情報)オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)の読み込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int ReadProc(out CustomerChange customerChange, string enterpriseCode, Int32 customerCode)
		{
            int status1 = 0;

            customerChange = null;

            try
            {
                // キー情報をセット
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                customerChangeWork.EnterpriseCode = enterpriseCode;   // 企業コード
                customerChangeWork.CustomerCode = customerCode;       // 得意先コード

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(customerChangeWork);

                //得意先マスタ(変動情報)読み込み
                status1 = this._iCustomerChangeDB.Read(ref parabyte, 0);

                if (status1 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // デシリアライズ処理
                    customerChangeWork = (CustomerChangeWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustomerChangeWork));
                    // 結果をメンバコピー
                    customerChange = this.CopyToCustomerChangeFromCustomerChangeWork(customerChangeWork);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                customerChange = null;
                this._iCustomerChangeDB = null;

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
        /// <param name="customerChange">得意先マスタ(変動情報)オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Write(CustomerChange customerChange)
        {
            // 得意先マスタ(変動情報)更新
            return this.WriteProc(customerChange);
        }

		/// <summary>
        ///得意先マスタ(変動情報)書き込み処理
		/// </summary>
        /// <param name="customerChange">得意先マスタ(変動情報)オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)の書き込み処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int WriteProc(CustomerChange customerChange)
		{
			int status = 0;

			try {
                CustomerChangeWork customerChangeWork = new CustomerChangeWork();

                // 編集前情報取得
                if (this._customerchangeDic.ContainsKey(customerChange.FileHeaderGuid) == true)
                {
                    customerChangeWork = (this._customerchangeDic[customerChange.FileHeaderGuid] as CustomerChangeWork);
                }

                // 編集情報取得
                CopyToCustomerChangeWorkFromDispCustomerChange(ref customerChangeWork, customerChange);

                object retObj = (object)customerChangeWork;

                //得意先マスタ(変動情報)書き込み
                status = this._iCustomerChangeDB.Write(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    ArrayList retArray = new ArrayList();
                    retArray = (ArrayList)retObj;
                    customerChangeWork = (CustomerChangeWork)retArray[0];
                    this.CustomerChangeWorkToDataSet(customerChangeWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustomerChangeDB = null;

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
        /// <param name="fileHeaderGuid">得意先マスタ(変動情報)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int LogicalDelete(Guid fileHeaderGuid)
        {
            // 得意先マスタ(変動情報)論理削除
            return this.LogicalDeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///得意先マスタ(変動情報)論理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(変動情報)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)の論理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int LogicalDeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

                object retObj = (object)customerChangeWork;

                //得意先マスタ(変動情報)論理削除
                status = this._iCustomerChangeDB.LogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    customerChangeWork = (CustomerChangeWork)retObj;
                    this.CustomerChangeWorkToDataSet(customerChangeWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustomerChangeDB = null;

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
        /// <param name="fileHeaderGuid">得意先マスタ(変動情報)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の論理削除復活処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Revival(Guid fileHeaderGuid)
        {
            // 得意先マスタ(変動情報)復活
            return this.RevivalProc(fileHeaderGuid);
        }

		/// <summary>
        ///得意先マスタ(変動情報)論理削除復活処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(変動情報)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)の論理削除復活処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int RevivalProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

                object retObj = (object)customerChangeWork;

                //得意先マスタ(変動情報)論理削除復活
                status = this._iCustomerChangeDB.RevivalLogicalDelete(ref retObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // データセットに追加
                    customerChangeWork = (CustomerChangeWork)retObj;
                    this.CustomerChangeWorkToDataSet(customerChangeWork);
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustomerChangeDB = null;

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
        /// <param name="fileHeaderGuid">得意先マスタ(変動情報)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        public int Delete(Guid fileHeaderGuid)
        {
            // 得意先マスタ(変動情報)物理削除
            return this.DeleteProc(fileHeaderGuid);
        }

		/// <summary>
        ///得意先マスタ(変動情報)物理削除処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先マスタ(変動情報)Guid</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)の物理削除処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private int DeleteProc(Guid fileHeaderGuid)
		{
			int status = 0;

			try {
                // 編集前情報取得
                CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(customerChangeWork);

                //得意先マスタ(変動情報)物理削除
                status = this._iCustomerChangeDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._customerchangeDic.Remove(customerChangeWork.FileHeaderGuid);
                    // データテーブルから削除
                    DataRow dr = this._customerchangeTable.Rows.Find(customerChangeWork.CustomerCode);
                    
                    dr.Delete();
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCustomerChangeDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		// --------------------------------------------------
		#region Search Methods

		/// <summary>
		/// 検索処理(論理削除除く)（オーバーロード)
		/// </summary>
		/// <param name="customerChangeList">得意先変動情報リスト(ArrayList)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2007.01.17</br>
		/// </remarks>
		public int Search( out List<CustomerChange> customerChangeList, string enterpriseCode )
		{
			int totalCount;
			customerChangeList = new List<CustomerChange>();
			int status = this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (CustomerChangeWork customerChangeWork in (ArrayList)this._customerChangeList)
				{
					customerChangeList.Add(this.CopyToCustomerChangeFromCustomerChangeWork(customerChangeWork));
				}
			}

			return status;
		}

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
            // 得意先マスタ(変動情報)検索
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }

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
            // 得意先マスタ(変動情報)検索
            return this.SearchProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        // --- ADD 2009/02/09 障害ID:9239対応------------------------------------------------------>>>>>
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">得意先マスタ(変動情報)リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            retList = new ArrayList();

            int totalCount;

            int status = this.SearchCustomerChangeProc(out totalCount, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList = (ArrayList)this._customerChangeList.Clone();
            }

            return (status);
        }
        // --- ADD 2009/02/09 障害ID:9239対応------------------------------------------------------<<<<<

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

            // 得意先マスタ(変動情報)検索
            status1 = this.SearchCustomerChangeProc(out totalCount, enterpriseCode, logicalMode);
            if ((status1 != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                return status1;
            }

            // キャッシュ処理
            status2 = this.Cache(this._customerChangeList);
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

        /// <summary>
        ///得意先マスタ(変動情報)検索処理
        /// </summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)の検索処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private int SearchCustomerChangeProc(out int totalCount, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._customerChangeList.Clear();

                // キャッシュ用テーブルをクリア
                this._customerchangeDic.Clear();

                // キー情報をセット
                CustomerChangeWork paramCustomerChangeWork = new CustomerChangeWork();
                paramCustomerChangeWork.EnterpriseCode = enterpriseCode;    // 企業コード

                object retobj = null;

                //得意先マスタ(変動情報)検索
                status = this._iCustomerChangeDB.Search(out retobj, paramCustomerChangeWork, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //this._customerChangeList = retobj as ArrayList;                       //DEL 2008/12/10 不具合対応[8897][8901]　論理削除された得意先は対象としない為
                    this._customerChangeList = this.CheckCustomerLogicalDelete(retobj);     //ADD 2008/12/10 不具合対応[8897][8901]

                    // 該当件数格納
                    totalCount = this._customerChangeList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustomerChangeDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        //--- ADD 2008/12/09 不具合対応[8897][8901] --------------------------------------------->>>>>
        /// <summary>
        /// 得意先コード存在チェック(得意先コードが論理削除されているものはNGとする)
        /// </summary>
        /// <param name="obj">対象データ</param>
        /// <returns>論理削除された得意先が除かれたデータ</returns>
        private ArrayList CheckCustomerLogicalDelete(object obj)
        {
            ArrayList arrayList = obj as ArrayList;             //対象データ
            ArrayList retArrayList = new ArrayList();           //「論理削除された得意先」削除後データ
            CustomerSearchPara customerSearchPara = null;       //得意先マスタ抽出条件

            CustomerChangeWork data = null;
            for (int i = 0; i <= arrayList.Count - 1; i++)
            {
                data = (CustomerChangeWork)arrayList[i];
                if (data.CustomerCode == 0)
                {
                    continue;
                }

                // 抽出条件
                customerSearchPara = new CustomerSearchPara();
                customerSearchPara.EnterpriseCode = this._enterpriseCode;
                customerSearchPara.CustomerCode = data.CustomerCode;

                int logicalDeleteCode = this.GetCustomerLogicalDelete(customerSearchPara);
                if (logicalDeleteCode == 0)
                {
                    retArrayList.Add(data);
                }
            }
            return retArrayList;
        }

        /// <summary>
        /// 得意先論理削除区分取得
        /// </summary>
        /// <param name="customerSearchPara">得意先抽出条件</param>
        /// <returns>論理削除区分</returns>
        public int GetCustomerLogicalDelete(CustomerSearchPara customerSearchPara)
        {
            int status = -1;

            // --- CHG 2009/02/09 障害ID:10981対応------------------------------------------------------>>>>>
            //CustomerSearchRet[] customerSearchRetArray = null;

            //// 得意先マスタ取得
            //customerSearchRetArray = null;
            //status = this._customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            //if (status != 0)
            //{
            //    return status;
            //}
            //if (customerSearchRetArray.Length <= 0)
            //{
            //    return status;
            //}

            //foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
            //{
            //    status = customerSearchRet.LogicalDeleteCode;
            //    break;
            //}

            if (this._customerSearchRetDic.ContainsKey(customerSearchPara.CustomerCode))
            {
                status = this._customerSearchRetDic[customerSearchPara.CustomerCode].LogicalDeleteCode;
            }
            // --- CHG 2009/02/09 障害ID:10981対応------------------------------------------------------<<<<<

            return status;
        }
        //--- ADD 2008/12/09 不具合対応[8897][8901] ---------------------------------------------<<<<<

        // --- ADD 2009/02/09 障害ID:10981対応------------------------------------------------------>>>>>
        /// <summary>
        /// 得意先マスタ取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        private int ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            CustomerSearchRet[] customerSearchRetArray;
            int status = this._customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
            if (status == 0)
            {
                foreach (CustomerSearchRet ret in customerSearchRetArray)
                {
                    this._customerSearchRetDic.Add(ret.CustomerCode, ret.Clone());
                }
            }

            return (status);
        }
        // --- ADD 2009/02/09 障害ID:10981対応------------------------------------------------------<<<<<
        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>
        /// マスタキャッシュ処理
        /// </summary>
        /// <param name="customerChangeList">伝票管理マスタ取得結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int Cache(ArrayList customerChangeList)
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._customerchangeTable.BeginLoadData();

                    // テーブルをクリア
                    this._customerchangeTable.Clear();

                    // 伝票管理データをDataSetに格納
                    foreach (CustomerChangeWork customerChangeWork in customerChangeList)
                    {
                        // 未登録の時
                        if (this._customerchangeDic.ContainsKey(customerChangeWork.FileHeaderGuid) == false)
                        {
                            // データセットに追加
                            this.CustomerChangeWorkToDataSet(customerChangeWork);
                        }
                    }
                }
                finally
                {
                    // 更新処理終了
                    this._customerchangeTable.EndLoadData();
                    
                    // ソート
                    this._customerchangeTable.DefaultView.Sort = COL_CUSTOMERCODE_TITLE + " ASC";       // 得意先コード
                    this._customerchangeTable.AcceptChanges();
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
        /// クラスメンバコピー処理 (画面変更得意先マスタ(変動情報)クラス⇒得意先マスタ(変動情報)ワーククラス)
        /// </summary>
        /// <param name="customerChangeWork">得意先マスタ(変動情報)ワーククラス</param>
        /// <param name="customerChange">得意先マスタ(変動情報)クラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更得意先マスタ(変動情報)クラスから
        ///                  得意先マスタ(変動情報)ワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private void CopyToCustomerChangeWorkFromDispCustomerChange(ref CustomerChangeWork customerChangeWork, CustomerChange customerChange)
        {
            customerChangeWork.EnterpriseCode  = customerChange.EnterpriseCode;         // 企業コード
            customerChangeWork.CustomerCode    = customerChange.CustomerCode;           // 得意先コード
            //customerChangeWork.CustomerSnm    = customerChange.CustomerSnm;           // 得意先略称     // DEL 2008/06/23
            customerChangeWork.CreditMoney = customerChange.CreditMoney;
            customerChangeWork.WarningCreditMoney = customerChange.WarningCreditMoney;  // 警告与信額
            customerChangeWork.PrsntAccRecBalance = customerChange.PrsntAccRecBalance;  // 現在売掛残高
            //--- DEL 2008/06/23 ---------->>>>>
            //customerChangeWork.PresentCustSlipNo = customerChange.PresentCustSlipNo;  // 現在得意先伝票番号
            //customerChangeWork.StartCustSlipNo = customerChange.StartCustSlipNo;      // 開始得意先伝票番号
            //customerChangeWork.EndCustSlipNo = customerChange.EndCustSlipNo;          // 終了得意先伝票番号
            //customerChangeWork.NoCharcterCount = customerChange.NoCharcterCount;      // 番号桁数
            //customerChangeWork.CustSlipNoHeader = customerChange.CustSlipNoHeader;    // 得意先伝票番号ヘッダ
            //customerChangeWork.CustSlipNoFooter = customerChange.CustSlipNoFooter;    // 得意先伝票番号フッタ
            //--- DEL 2008/06/23 ----------<<<<<
        }

		/// <summary>
        /// クラスメンバコピー処理 (得意先マスタ(変動情報)ワーククラス⇒得意先マスタ(変動情報)クラス)
		/// </summary>
        /// <param name="customerChangeWork">得意先マスタ(変動情報)ワーククラス</param>
        /// <returns>得意先マスタ(変動情報)クラス</returns>
		/// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)ワーククラスから
        ///                  得意先マスタ(変動情報)クラスへメンバコピーを行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
        private CustomerChange CopyToCustomerChangeFromCustomerChangeWork(CustomerChangeWork customerChangeWork)
        {
            CustomerChange customerChange = new CustomerChange();

            customerChange.CreateDateTime = customerChangeWork.CreateDateTime;        // 作成日時
            customerChange.UpdateDateTime = customerChangeWork.UpdateDateTime;        // 更新日時
            customerChange.EnterpriseCode = customerChangeWork.EnterpriseCode;        // 企業コード
            customerChange.FileHeaderGuid = customerChangeWork.FileHeaderGuid;        // GUID
            customerChange.UpdEmployeeCode = customerChangeWork.UpdEmployeeCode;      // 更新従業員コード
            customerChange.UpdAssemblyId1 = customerChangeWork.UpdAssemblyId1;        // 更新アセンブリID1
            customerChange.UpdAssemblyId2 = customerChangeWork.UpdAssemblyId2;        // 更新アセンブリID2
            customerChange.LogicalDeleteCode = customerChangeWork.LogicalDeleteCode;  // 論理削除区分
            customerChange.CustomerCode = customerChangeWork.CustomerCode;            // 得意先コード
            //customerChange.CustomerSnm = customerChangeWork.CustomerSnm;              // 得意先略称       // DEL 2008/06/23
            customerChange.CreditMoney = customerChangeWork.CreditMoney;              // 与信額 
            customerChange.WarningCreditMoney = customerChangeWork.WarningCreditMoney;// 警告与信額
            customerChange.PrsntAccRecBalance = customerChangeWork.PrsntAccRecBalance;// 現在売掛残高
            //--- DEL 2008/06/23 ---------->>>>>
            //customerChange.PresentCustSlipNo = customerChangeWork.PresentCustSlipNo;  // 現在得意先伝票番号
            //customerChange.StartCustSlipNo = customerChangeWork.StartCustSlipNo;      // 開始得意先伝票番号
            //customerChange.EndCustSlipNo = customerChangeWork.EndCustSlipNo;          // 終了得意先伝票番号
            //customerChange.NoCharcterCount = customerChangeWork.NoCharcterCount;      // 番号桁数
            //customerChange.CustSlipNoHeader = customerChangeWork.CustSlipNoHeader;    // 得意先伝票番号ヘッダ
            //customerChange.CustSlipNoFooter = customerChangeWork.CustSlipNoFooter;    // 得意先伝票番号フッタ
            //--- DEL 2008/06/23 ----------<<<<<

            // テーブル更新
            _customerchangeDic[customerChangeWork.FileHeaderGuid] = customerChangeWork;

            return customerChange;
        }

        /// <summary>
        /// 得意先マスタ(変動情報)オブジェクトメインDataSet展開処理
        /// </summary>
        /// <param name="customerChangeWork">得意先マスタ(変動情報)オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)オブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        private void CustomerChangeWorkToDataSet(CustomerChangeWork customerChangeWork)
        {
            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            DataRow dr = this._customerchangeTable.Rows.Find(customerChangeWork.CustomerCode);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._customerchangeTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 削除日
            if (customerChangeWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", customerChangeWork.UpdateDateTime);
            }

            // 得意先コード
            dr[COL_CUSTOMERCODE_TITLE] = customerChangeWork.CustomerCode;
            // 得意先略称
            dr[COL_CUSTOMERSNM_TITLE] = GetCustomerName(customerChangeWork.CustomerCode);
            // 与信額
            dr[COL_CREDITMONEY_TITLE] = customerChangeWork.CreditMoney;
            // 警告与信額
            dr[COL_WARNINGCREDITMONEY_TITLE] = customerChangeWork.WarningCreditMoney;
            // 現在売掛残高
            dr[COL_PRSNTACCRECBALANCE_TITLE] = customerChangeWork.PrsntAccRecBalance;

            //--- DEL 2008/06/23 ---------->>>>>
            //// 現在得意先伝票番号
            //dr[COL_PRESENTCUSTSLIPNO_TITLE] = customerChangeWork.PresentCustSlipNo;
            //// 開始得意先伝票番号
            //dr[COL_STARTCUSTSLIPNO_TITLE] = customerChangeWork.StartCustSlipNo;
            //// 終了得意先伝票番号
            //dr[COL_ENDCUSTSLIPNO_TITLE] = customerChangeWork.EndCustSlipNo;
            //// 番号桁数
            //dr[COL_NOCHARCTERCOUNT_TITLE] = customerChangeWork.NoCharcterCount;
            //// 得意先伝票番号ヘッダ
            //dr[COL_CUSTSLIPNOHEADER_TITLE] = customerChangeWork.CustSlipNoHeader;
            //// 得意先伝票番号フッタ
            //dr[COL_CUSTSLIPNOFOOTER_TITLE] = customerChangeWork.CustSlipNoFooter;
            //--- DEL 2008/06/23 ----------<<<<<

            // GUID
            dr[COL_GUID_TITLE] = customerChangeWork.FileHeaderGuid;

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._customerchangeTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._customerchangeDic.ContainsKey(customerChangeWork.FileHeaderGuid) == true)
            {
                this._customerchangeDic.Remove(customerChangeWork.FileHeaderGuid);
            }
            this._customerchangeDic.Add(customerChangeWork.FileHeaderGuid, customerChangeWork);
        }
		#endregion

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerChange">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out CustomerChange customerChange)
        {
            int status = -1;
            customerChange = new CustomerChange();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add(GUIDE_ENTERPRISECODE_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                customerChange.CustomerCode = (Int32)retObj[GUIDE_CUSTOMERCODE_TITLE];               // 得意先コード
                //customerChange.CustomerSnm = retObj[GUIDE_CUSTOMERSNM_TITLE].ToString();             // 得意先略称    // DEL 2008/06/23
                customerChange.CreditMoney = (Int64)retObj[GUIDE_CREDITMONEY_TITLE];                 // 与信額
                customerChange.WarningCreditMoney = (Int64)retObj[GUIDE_WARNINGCREDITMONEY_TITLE];   // 警告与信額

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
                            column.ColumnName = GUIDE_CUSTOMERCODE_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CUSTOMERSNM_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_CREDITMONEY_TITLE;
                            table.Columns.Add(column);

                            column = new DataColumn();
                            column.DataType = Type.GetType("System.String");
                            column.ColumnName = GUIDE_WARNINGCREDITMONEY_TITLE;
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
                        while (dataCnt < this._customerchangeTable.Rows.Count)
                        {
                            // 論理削除区分:有効
                            if ((string)this._customerchangeTable.DefaultView[dataCnt][COL_DELETEDATE_TITLE] == "")
                            {
                                DataRow dr = retDataSet.Tables[0].NewRow();
                                // 得意先コード
                                dr[GUIDE_CUSTOMERCODE_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_CUSTOMERCODE_TITLE];
                                // 得意先名称
                                dr[GUIDE_CUSTOMERSNM_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_CUSTOMERSNM_TITLE];
                                // 与信額
                                dr[GUIDE_CREDITMONEY_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_CREDITMONEY_TITLE];
                                // 警告与信額
                                dr[GUIDE_WARNINGCREDITMONEY_TITLE] = this._customerchangeTable.DefaultView[dataCnt][COL_WARNINGCREDITMONEY_TITLE];

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
        ///得意先マスタ(変動情報)比較クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ(変動情報)オブジェクトの比較を行います。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.09.18</br>
        /// </remarks>
        public class CustomerChangeCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>
            /// 比較用メソッド
            /// </summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 得意先マスタ(変動情報)オブジェクトの比較を行います。</br>
            /// <br>Programmer : 20081 疋田 勇人</br>
            /// <br>Date       : 2007.09.18</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustomerChange obj1 = x as CustomerChange;
                CustomerChange obj2 = y as CustomerChange;

                // 得意先コードで比較
                return obj1.CustomerCode.CompareTo(obj2.CustomerCode);
            }

            #endregion
        }

		#endregion

        //--- ADD 2008/06/24 ---------->>>>>
        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";

            // --- CHG 2009/02/09 障害ID:10981対応------------------------------------------------------>>>>>
            //int status;

            //CustomerInfo customerInfo = new CustomerInfo();
            //CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            //try
            //{
            //    status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

            //    if (status == 0)
            //    {
            //        customerName = customerInfo.CustomerSnm.Trim();
            //    }
            //}
            //catch
            //{
            //    customerName = "";
            //}
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                customerName = this._customerSearchRetDic[customerCode].Snm.Trim();
            }
            // --- CHG 2009/02/09 障害ID:10981対応------------------------------------------------------<<<<<

            return customerName;
        }
        //--- ADD 2008/06/24 ----------<<<<<

        // --- ADD 2008/10/16 ------------------------------------------------------------------------------------------>>>>>
        /// <summary>
        /// 与信管理区分取得処理
        /// </summary>
        /// <param name="fileHeaderGuid">得意先情報取得用Key</param>
        /// <param name="creditMngCode">与信管理区分</param>
        /// <returns>True：成功、False：失敗</returns>
        /// <remarks>
        /// <br>Note       : 与信管理区分を取得します。</br>
        /// <br>Programmer :       照田 貴志</br>
        /// <br>Date       : 2008/10/16</br>
        /// </remarks>
        public bool GetCreditMngCode(Guid fileHeaderGuid, out int creditMngCode)
        {
            return this.GetCreditMngCodeProc(fileHeaderGuid, out creditMngCode);
        }
        private bool GetCreditMngCodeProc(Guid fileHeaderGuid, out int creditMngCode)
        {
            creditMngCode = 0;

            CustomerInfo customerInfo = new CustomerInfo();
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            // 得意先情報取得
            CustomerChangeWork customerChangeWork = (this._customerchangeDic[fileHeaderGuid] as CustomerChangeWork);

            //int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerChangeWork.CustomerCode, out customerInfo);     //DEL 2008/12/03 得意先が論理削除された変動情報に対して削除を行うとエラーとなる為
            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetDataAll, this._enterpriseCode, customerChangeWork.CustomerCode, out customerInfo);    //ADD 2008/12/03
            if (status == 0)
            {
                creditMngCode = customerInfo.CreditMngCode;     // 与信管理区分
                return true;
            }

            return false;
        }
        // --- ADD 2008/10/16 ------------------------------------------------------------------------------------------<<<<<
    }
}
