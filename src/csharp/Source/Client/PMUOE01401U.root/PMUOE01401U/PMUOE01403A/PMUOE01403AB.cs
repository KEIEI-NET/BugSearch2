//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ復旧処理 初期値取得アクセスクラス
// プログラム概要   : ＵＯＥ復旧処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ復旧処理用　初期値取得アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ復旧処理の初期値取得データ制御を行います。</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/12/01</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// </remarks>
	public class StockInputInitDataAcs
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        //アクセスクラス
		private static StockInputInitDataAcs _stockInputInitDataAcs;
        private StockInputInitialDataSet _dataSet;
        private UoeSndRcvCtlAcs _uoeSndRcvCtlAcs;
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;
        private UOEOrderDtlAcs _uOEOrderDtlAcs;
        private SupplierAcs _supplierAcs;                               // 仕入先 アクセスクラス

        private IEmployeeDB _iEmployeeDB;                               // 従業員情報 アクセスクラス
        private UOEGuideNameAcs _uOEGuideNameAcs;                       // UOEガイド名称マスタ アクセスクラス
		private SecInfoAcs _secInfoAcs;									// 拠点アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;		                    // 拠点設定 アクセスクラス

        //拠点設定マスタ
        private SecInfoSet _secInfoSet = null;

        // 得意先マスタ(key：得意先コード)
        private Hashtable _customerHTable = null;

        // 仕入先マスタ
        private Dictionary<int, Supplier> _supplierDictionary = null;

        //企業コード
        private string _enterpriseCode;
        private string _sectionCode = "";

        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ログイン拠点コード
        private string _ownSectionCode = "";

        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
        internal const string SECTIONCODE_ALL = "000000";
        private const string SECTIONNAME_ALL = "全社";
        # endregion

        // ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region ＵＯＥ送受信制御アクセスクラス
        /// <summary>
        /// ＵＯＥ送受信制御アクセスクラス
        /// </summary>
        public UoeSndRcvCtlAcs uoeSndRcvCtlAcs
        {
            get { return _uoeSndRcvCtlAcs; }
        }
        # endregion

        # region ＵＯＥ送受信ＪＮＬアクセスクラス
        /// <summary>
        /// ＵＯＥ送受信ＪＮＬアクセスクラス
        /// </summary>
        public UoeSndRcvJnlAcs uoeSndRcvJnlAcs
        {
            get { return _uoeSndRcvJnlAcs; }
        }
        # endregion

        # region ＵＯＥ発注データアクセスクラス
        /// <summary>
        /// ＵＯＥ発注データアクセスクラス
        /// </summary>
        public UOEOrderDtlAcs uOEOrderDtlAcs
        {
            get { return _uOEOrderDtlAcs; }
        }
        # endregion

        # region UOE発注先マスタアクセスクラス
        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _uoeSndRcvJnlAcs.uOESupplierAcs; }
        }
        # endregion

        # region UOE自社設定マスタ
        /// <summary>
        /// UOE自社設定マスタ
        /// </summary>
        public UOESetting uOESetting
        {
            get { return this._uoeSndRcvJnlAcs.uOESetting; }
            set { this._uoeSndRcvJnlAcs.uOESetting = value; }
        }
        # endregion

        # region 自端末コード
        /// <summary>
        /// 自端末コード
        /// </summary>
        public int cashRegisterNo
        {
            get { return this._uoeSndRcvJnlAcs.cashRegisterNo; }
            set { this._uoeSndRcvJnlAcs.cashRegisterNo = value; }
        }
        # endregion

        # region UOEガイド名称マスタ アクセスクラス
        /// <summary>
        /// UOEガイド名称マスタ アクセスクラス
        /// </summary>
        public UOEGuideNameAcs uOEGuideNameAcs
        {
            get { return _uOEGuideNameAcs; }
            set { _uOEGuideNameAcs = value; }
        }
        # endregion
		# endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private StockInputInitDataAcs()
		{
            // 変数初期化
            this._uoeSndRcvCtlAcs = new UoeSndRcvCtlAcs();
            this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
            this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();
            this._supplierAcs = new SupplierAcs();

		    this._dataSet = new StockInputInitialDataSet();
			this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
			this._uOEGuideNameAcs = new UOEGuideNameAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

		/// <summary>
		/// 初期値取得アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns>仕入入力用初期値取得アクセスクラス インスタンス</returns>
		public static StockInputInitDataAcs GetInstance()
		{
			if (_stockInputInitDataAcs == null)
			{
				_stockInputInitDataAcs = new StockInputInitDataAcs();
			}

			return _stockInputInitDataAcs;
		}
        #endregion

        // ===================================================================================== //
        // メソッド
        // ===================================================================================== //
        #region 初期データ取得処理
        /// <summary>
		/// 初期データ取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		public int ReadInitData(string enterpriseCode,string sectionCode)
		{
            try
			{
                //各DataSetに初期値Set
				this._dataSet.Employee.BeginLoadData();
				this._dataSet.UOEGuideName.BeginLoadData();

                //-----------------------------------------------------------
                //全従業員情報を取得
                //-----------------------------------------------------------
                object returnEmployee;
                EmployeeWork paraEmployee = new EmployeeWork();
                paraEmployee.EnterpriseCode = enterpriseCode;

                int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (returnEmployee is ArrayList)
                    {
                        foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                        {
                            this.CacheEmployee(employeeWork);
                        }
                    }
                }

                //-----------------------------------------------------------
                //拠点情報取得
                //-----------------------------------------------------------
                SecInfoSet returnSecInfoSet = new SecInfoSet();
                status = this._secInfoSetAcs.Read(out returnSecInfoSet, _enterpriseCode, _sectionCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    _secInfoSet = returnSecInfoSet;
                }

                //-----------------------------------------------------------
                //UOEガイド名称情報を取得
                //-----------------------------------------------------------
                ArrayList rturnUOEGuideName;
                UOEGuideName uOEGuideName = new UOEGuideName();
                uOEGuideName.EnterpriseCode = _enterpriseCode;
                uOEGuideName.SectionCode = _sectionCode;

                status = this._uOEGuideNameAcs.SearchAll(out rturnUOEGuideName, uOEGuideName);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (rturnUOEGuideName is ArrayList)
                    {
                        foreach (UOEGuideName guideName in rturnUOEGuideName)
                        {
                            if (guideName.LogicalDeleteCode != (int)ConstantManagement.LogicalMode.GetData0)
                            {
                                continue;
                            }

                            this.CacheUOEGuideName(guideName);
                        }
                    }
                }

                //-----------------------------------------------------------
                // 得意先データHashTalbe作成
                //-----------------------------------------------------------
                this.CreateCustomerHTable();

                //-----------------------------------------------------------
                // 仕入先キャッシュ処理
                //-----------------------------------------------------------
                this.CacheSupplier();
			}
			finally
			{
				this._dataSet.Employee.EndLoadData();
				this._dataSet.UOEGuideName.EndLoadData();
			}

			return 0;
		}
        #endregion

		# region 従業員マスタキャッシュ制御処理
		/// <summary>
		/// 従業員マスタキャッシュ処理
		/// </summary>
		/// <param name="employeeWork">従業員マスタワーククラス</param>
		internal void CacheEmployee(EmployeeWork employeeWork)
		{
			try
			{                
				_dataSet.Employee.AddEmployeeRow(this.RowFromUIData(employeeWork));
			}
			catch (ConstraintException)
			{
				StockInputInitialDataSet.EmployeeRow row = this._dataSet.Employee.FindByEmployeeCode(employeeWork.EmployeeCode.Trim());
				this.SetRowFromUIData(ref row, employeeWork);
			}
		}

		/// <summary>
		/// 従業員名称取得処理
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <returns>従業員名称</returns>
		public string GetName_FromEmployee(string employeeCode)
		{
			StockInputInitialDataSet.EmployeeRow row = this._dataSet.Employee.FindByEmployeeCode(employeeCode.Trim());

			if (row == null)
			{
				return "";
			}
			else
			{
				return row.Name;
			}
		}

		/// <summary>
		/// 従業員マスタワーク→従業員マスタ行クラス設定処理
		/// </summary>
		/// <param name="row">従業員マスタ行クラス</param>
		/// <param name="employeeWork">従業員マスタワーククラス</param>
		internal void SetRowFromUIData(ref StockInputInitialDataSet.EmployeeRow row, EmployeeWork employeeWork)
		{
			// 従業員コード
			row.EmployeeCode = employeeWork.EmployeeCode.Trim();

			// 従業員名称
			row.Name = employeeWork.Name;
		}

		/// <summary>
		/// 従業員マスタワーククラス→従業員マスタ行クラス変換処理
		/// </summary>
		/// <param name="employeeWork">従業員マスタ行クラス</param>
		/// <returns>従業員マスタワークタクラス</returns>
		internal StockInputInitialDataSet.EmployeeRow RowFromUIData(EmployeeWork employeeWork)
		{
			StockInputInitialDataSet.EmployeeRow row = _dataSet.Employee.NewEmployeeRow();

			this.SetRowFromUIData(ref row, employeeWork);
			return row;
		}


		/// <summary>
		/// 従業員存在チェック
		/// </summary>
		/// <param name="sectionCode"></param>
		/// <param name="warehouseCode"></param>
		/// <returns></returns>
		public bool EmployeeExists(string employeeCode)
		{
			StockInputInitialDataSet.EmployeeRow row = this._dataSet.Employee.FindByEmployeeCode(employeeCode.Trim());
			return (row != null);
		}

		# endregion

        # region UOE発注先情報キャッシュ制御処理
        /// <summary>
        /// UOE発注先名称取得
        /// </summary>
        /// <param name="UOESupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先名称</returns>
        public string GetName_FromUOESupplier(int uOESupplierCd)
        {
            UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);

            if (uOESupplier == null)
            {
                return "";
            }
            else
            {
                return uOESupplier.UOESupplierName;
            }
        }

        /// <summary>
        /// 発注可能メーカーをチェック
        /// </summary>
        /// <param name="uOESupplierCd">発注先コード</param>
        /// <param name="enableOdrMakerCdList">メーカーコード</param>
        /// <returns>ステータス</returns>
        public bool ExistUOESupplierMaker(Int32 uOESupplierCd, List<Int32> enableOdrMakerCdList)
        {
            return (_uoeSndRcvJnlAcs.ExistUOESupplierMaker(uOESupplierCd, enableOdrMakerCdList));
        }

        /// <summary>
        /// UOE発注先クラス取得
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns>UOE発注先クラス</returns>
        public UOESupplier GetUOESupplier(int uOESupplierCd)
        {
            UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);
            return (uOESupplier);
        }

        /// <summary>
        /// UOE発注先存在チェック
        /// </summary>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <returns></returns>
        public bool UOESupplierExists(int uOESupplierCd)
        {
            UOESupplier uOESupplier = GetUOESupplier(uOESupplierCd);
            return (uOESupplier != null);
        }
        # endregion

        # region 仕入先情報キャッシュ制御処理
        /// <summary>
        /// 仕入先情報キャッシュ制御処理
        /// </summary>
        public void CacheSupplier()
        {
   			try
			{
                ArrayList retList = null;

                int status = _supplierAcs.Search(out retList, _enterpriseCode, _sectionCode);
                if(status != 0) return;
                
                _supplierDictionary = new Dictionary<int,Supplier>();
                foreach(Supplier supplier in retList)
                {
			        if (_supplierDictionary.ContainsKey(supplier.SupplierCd) != true)
			        {
                        _supplierDictionary.Add(supplier.SupplierCd, supplier);
			        }
                }
			}
			catch (ConstraintException)
			{
                _supplierDictionary = null;
			}
        }

        /// <summary>
        /// 仕入先クラス取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>仕入先クラス</returns>
        public Supplier GetSupplier(int supplierCd)
        {
            Supplier supplier = null;
   			try
			{
                if (_supplierDictionary.ContainsKey(supplierCd))
                {
                    supplier = _supplierDictionary[supplierCd];
                }
            }
            catch (ConstraintException)
            {
                supplier = null;
            }
            return supplier;
        }

        /// <summary>
        /// 仕入先存在チェック
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>ステータス</returns>
        public bool SupplierExists(int supplierCd)
        {
            Supplier supplier = GetSupplier(supplierCd);
            return (supplier != null);
        }
        # endregion

		# region UOEガイド名称情報キャッシュ制御処理
		/// <summary>
		/// UOEガイド名称キャッシュ処理
		/// </summary>
		/// <param name="uOEGuideName">UOEガイド名称クラス</param>
		internal void CacheUOEGuideName(UOEGuideName uOEGuideName)
		{
			try
			{
				_dataSet.UOEGuideName.AddUOEGuideNameRow(this.RowFromUIData(uOEGuideName));
			}
			catch (ConstraintException)
			{
				StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				uOEGuideName.UOEGuideDivCd, uOEGuideName.UOESupplierCd, uOEGuideName.UOEGuideCode.Trim()
				);
				this.SetRowFromUIData(ref row, uOEGuideName);
			}
		}

        /// <summary>
        /// UOEガイド名称の存在チェック＜ガイド区分・発注先・ガイドコード指定＞
        /// </summary>
        /// <param name="UOEGuideDivCd">UOEガイド区分</param>
        /// <param name="UOESupplierCd">UOE発注先コード</param>
        /// <param name="UOEGuideCode">UOEガイドコード</param>
        /// <returns>ステータス</returns>
        public bool UOEGuideExists(int UOEGuideDivCd, int UOESupplierCd, string UOEGuideCode)
        {
            bool returnBool = false;

            try
            {
                StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
                    UOEGuideDivCd, UOESupplierCd, UOEGuideCode.Trim()
                );

                if (row == null)
                {
                    returnBool = false;
                }
                else
                {
                    returnBool = true;
                }
            }
            catch (Exception)
            {
                returnBool = false;
            }
            return (returnBool);
        }


		/// <summary>
		/// UOEガイド名称取得
		/// </summary>
		/// <param name="UOEGuideDivCd">UOEガイド区分</param>
		/// <param name="UOESupplierCd">UOE発注先コード</param>
		/// <param name="UOEGuideCode">UOEガイドコード</param>
		/// <returns>UOEガイド名称</returns>
		public string GetName_FromUOEGuideName(int UOEGuideDivCd, int UOESupplierCd, string UOEGuideCode)
		{
			StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				UOEGuideDivCd, UOESupplierCd, UOEGuideCode.Trim()
			);

			if (row == null)
			{
				return "";
			}
			else
			{
				return row.UOEGuideNm;
			}
		}

		/// <summary>
		/// UOEガイド名称一覧取得＜ガイド区分・発注先・ガイドコード指定＞
		/// </summary>
		/// <param name="UOEGuideDivCd"></param>
		/// <param name="UOESupplierCd"></param>
		/// <returns>UOEガイド名称クラス</returns>
		public List<UOEGuideName> GetList_FromUOEGuideName(int UOEGuideDivCd, int UOESupplierCd)
		{
			List<UOEGuideName> list = new List<UOEGuideName>();

			try
			{
				DataView dv = new DataView(this._dataSet.UOEGuideName);
				string filinf = "{0} = " + UOEGuideDivCd
						 + " AND {1} = " + UOESupplierCd;

				
				dv.RowFilter = String.Format(filinf,
								"UOEGuideDivCd",
								"UOESupplierCd");
				dv.Sort = "UOEGuideCode";

				//＜DataRow → クラス＞格納処理
				if (dv.Count > 0)
				{
					for (int i = 0; i < dv.Count; i++)
					{
						DataRow dr = dv[i].Row;
						UOEGuideName uOEGuideName = ToUOEGuideNameFromRow(ref dr);
						list.Add(uOEGuideName);
					}
				}
			}
			catch(Exception)
			{
				list = new List<UOEGuideName>();
			}
			return (list);
		}

		/// <summary>
		/// UOEガイド名称コードの初期表示値取得
		/// </summary>
		/// <param name="list">UOEガイド名称リスト</param>
		/// <param name="uOEGuideCode">UOEガイド名称コード</param>
		/// <returns>UOEガイド名称コード</returns>
		public string GetDefaultUOEGuideCode(List<UOEGuideName> list, string uOEGuideCode)
		{
			string defaultUOEGuideCode = "";

			if (list == null) return (defaultUOEGuideCode);
			if (list.Count == 0) return (defaultUOEGuideCode);

			defaultUOEGuideCode = list[0].UOEGuideCode;
			if (uOEGuideCode.Trim() != "")
			{
				foreach (UOEGuideName dtl in list)
				{
					if (dtl.UOEGuideCode.Trim() == uOEGuideCode.Trim())
					{
						defaultUOEGuideCode = uOEGuideCode;
						break;
					}
				}
			}
			return (defaultUOEGuideCode);
		}

		/// <summary>
		/// ユーザーガイドコンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスバリューリスト</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分</param>
		public void SetUOEGuideNameComboEditor(out Infragistics.Win.ValueList sender, int UOEGuideDivCd, int UOESupplierCd)
		{
			sender = new Infragistics.Win.ValueList();

			Infragistics.Win.ValueListItem sec = new Infragistics.Win.ValueListItem();
			sec.Tag = 0;
			sec.DataValue = "";
			sec.DisplayText = "";
			sender.ValueListItems.Add(sec);

			DataRow[] rows = this._dataSet.UOEGuideName.Select(string.Format("UOEGuideDivCd = {0} AND UOESupplierCd = {1}", UOEGuideDivCd, UOESupplierCd), "UOEGuideCode ASC");

			foreach (StockInputInitialDataSet.UOEGuideNameRow row in rows)
			{
				Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
				secInfoItem.Tag = row.UOEGuideCode;
				secInfoItem.DataValue = row.UOEGuideCode;
				secInfoItem.DisplayText = row.UOEGuideNm;
				sender.ValueListItems.Add(secInfoItem);
			}
		}

		/// <summary>
		/// UOEガイド名称ワーク→UOEガイド名称行クラス設定処理
		/// </summary>
		/// <param name="row">UOE発注先行クラス</param>
		/// <returns>UOEガイド名称クラス</returns>
		internal UOEGuideName ToUOEGuideNameFromRow(ref DataRow row)
		{
			UOEGuideName uOEGuideName = new UOEGuideName();

			StockInputInitialDataSet.UOEGuideNameDataTable uOEGuideNameDataTable = this._dataSet.UOEGuideName;

			uOEGuideName.UOEGuideDivCd = (int)row[uOEGuideNameDataTable.UOEGuideDivCdColumn.ColumnName];	// UOEガイド区分
			uOEGuideName.UOESupplierCd = (int)row[uOEGuideNameDataTable.UOESupplierCdColumn.ColumnName];	// UOE発注先コード
			uOEGuideName.UOEGuideCode = (string)row[uOEGuideNameDataTable.UOEGuideCodeColumn.ColumnName];	// UOEガイドコード
			uOEGuideName.UOEGuideNm = (string)row[uOEGuideNameDataTable.UOEGuideNmColumn.ColumnName];		// UOEガイド名称

			return (uOEGuideName);
		}

		/// <summary>
		/// UOEガイド名称ワーク→UOEガイド名称行クラス設定処理
		/// </summary>
		/// <param name="row">UOEガイド名称行クラス</param>
		/// <param name="uOESupplier">UOEガイド名称クラス</param>
		internal void SetRowFromUIData(ref StockInputInitialDataSet.UOEGuideNameRow row, UOEGuideName uOEGuideName)
		{
			row.UOEGuideDivCd = uOEGuideName.UOEGuideDivCd; // UOEガイド区分
			row.UOESupplierCd = uOEGuideName.UOESupplierCd; // UOE発注先コード
			row.UOEGuideCode = uOEGuideName.UOEGuideCode; // UOEガイドコード
			row.UOEGuideNm = uOEGuideName.UOEGuideNm; // UOEガイド名称
		}

		/// <summary>
		/// UOEガイド名称ワーク→UOEガイド名称行クラス設定処理
		/// </summary>
		/// <param name="row">UOEガイド名称</param>
		/// <returns>UOEガイド名称行クラス</returns>
		internal StockInputInitialDataSet.UOEGuideNameRow RowFromUIData(UOEGuideName uOEGuideName)
		{
			StockInputInitialDataSet.UOEGuideNameRow row = _dataSet.UOEGuideName.NewUOEGuideNameRow();
			this.SetRowFromUIData(ref row, uOEGuideName);
			return row;
		}

		/// <summary>
		/// UOEガイド名称存在チェック
		/// </summary>
		/// <param name="UOEGuideDivCd">UOEガイド区分</param>
		/// <param name="UOESupplierCd">UOE発注先コード</param>
		/// <param name="UOEGuideCode">UOEガイドコード</param>
		/// <returns></returns>
		public bool UOEGuideNameExists(int UOEGuideDivCd, int UOESupplierCd, string UOEGuideCode)
		{
			StockInputInitialDataSet.UOEGuideNameRow row = this._dataSet.UOEGuideName.FindByUOEGuideDivCdUOESupplierCdUOEGuideCode(
				UOEGuideDivCd, UOESupplierCd, UOEGuideCode.Trim()
				);
			return (row != null);
		}
		# endregion

        #region 得意先マスタ関連
        #region CreateCustomerHTable(HashTable作成)
        /// <summary>
        /// 得意先マスタHashTable作成
        /// </summary>
        private void CreateCustomerHTable()
        {
            CustomerSearchRet[] customerSearchRetArray = null;

            // 条件設定
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = this._enterpriseCode;

            // 得意先マスタデータ取得(PMKHN09012A)
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();
            int status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);

            // 異常
            if (status != 0)
            {
                this._customerHTable = null;
                return;
            }
            // データなし
            if (customerSearchRetArray == null)
            {
                this._customerHTable = null;
                return;
            }

            // HashTable作成
            this._customerHTable = new Hashtable();
            foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
            {
                this._customerHTable[customerSearchRet.CustomerCode] = customerSearchRet.Name + customerSearchRet.Name2;
            }
        }
        #endregion

        #region GetCustomerNameFromCustomerHTable(得意先名称取得)
        /// <summary>
        /// 得意先名称取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName">得意先名称</param>
        /// <returns>True：データあり、False：データなし</returns>
        public bool GetCustomerNameFromCustomerHTable(int customerCode, out string customerName)
        {
            customerName = string.Empty;
            if (this.HashTableIsNullOrEmpty(this._customerHTable, customerCode))
            {
                return false;
            }

            // HashTableより取得
            customerName = this._customerHTable[customerCode].ToString();

            return true;
        }
        #endregion

        #region ▼HashTableIsNullOrDataNothing(HashTableデータ存在チェック)
        /// <summary>
        /// HashTableデータ存在チェック
        /// </summary>
        /// <param name="uoeSupplierCd"></param>
        /// <returns>True:データなし、False:データあり</returns>
        private bool HashTableIsNullOrEmpty(Hashtable hashTable, int key)
        {
            // データが無い
            if (hashTable == null)
            {
                return true;
            }

            // INDEX範囲外
            if (hashTable.ContainsKey(key) == false)
            {
                return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region 拠点制御関連
        /// <summary>
        /// 拠点オプション導入チェックプロパティ
        /// </summary>
        /// <returns>true:導入 false:未導入</returns>
        public static bool IsSectionOptionIntroduce
        {
            get
            {
                // 拠点オプションチェック
                if ( ( int ) LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0 ) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs ( ArrayList secInfoSetWorkArrayList, ArrayList secCtrlSetWorkArrayList, ArrayList companyNmWorkArrayList )
        {
            if ( ( secInfoSetWorkArrayList == null ) || ( secCtrlSetWorkArrayList == null ) || ( companyNmWorkArrayList == null ) ) {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            SecInfoAcs.SetSecInfo(secInfoSetWorkArrayList, secCtrlSetWorkArrayList, companyNmWorkArrayList);

            this.CreateSecInfoAcs();
        }

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs ()
        {
            if ( _secInfoAcs == null ) {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if ( _secInfoAcs.SecInfoSet == null ) {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 拠点設定マスタ配列プロパティ
        /// </summary>
        internal SecInfoSet[] SecInfoSetArray
        {
            get
            {
                // 拠点制御アクセスクラスインスタンス化処理
                this.CreateSecInfoAcs();

                return _secInfoAcs.SecInfoSetList;
            }
        }

        /// <summary>
        /// 自拠点コードプロパティ
        /// </summary>
        public string OwnSectionCode
        {
            get
            {
                if ( this._ownSectionCode == "" ) {
                    return this.GetOwnSectionCode();
                }
                else {
                    return this._ownSectionCode;
                }
            }
        }

        /// <summary>
        /// 自拠点コード取得処理
        /// </summary>
        /// <returns>自拠点コード</returns>
        private string GetOwnSectionCode ()
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // 自拠点の取得
            SecInfoSet secInfoSet;
            //_secInfoAcs.GetSecInfo(this._loginSectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out secInfoSet);
			_secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);
			if (secInfoSet != null)
			{
                // 自拠点コードの保存
                this._ownSectionCode = secInfoSet.SectionCode;
            }

            return this._ownSectionCode;
        }

        /// <summary>
        /// 本社機能／拠点機能チェック処理
        /// </summary>
        /// <returns>true:本社機能 false:拠点機能</returns>
        public bool IsMainOfficeFunc ()
        {
            bool isMainOfficeFunc = false;

            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // ログイン担当拠点情報の取得
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if ( secInfoSet != null ) {
                // 本社機能か？
                if ( secInfoSet.MainOfficeFuncFlag == 1 ) {
                    isMainOfficeFunc = true;
                }
            }
            else {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }

        /// <summary>
        /// 拠点コンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="isAllSection">全社設定フラグ</param>
        public void SetSectionComboEditor ( ref TComboEditor sender, bool isAllSection )
        {
            Infragistics.Win.ValueList valueList;
            this.SetSectionComboEditor(out valueList, isAllSection);

            if ( valueList != null ) {
                for ( int i = 0; i < valueList.ValueListItems.Count; i++ ) {
                    sender.Items.Add(valueList.ValueListItems[i]);
                }

                sender.MaxDropDownItems = valueList.ValueListItems.Count;

                if ( this.IsMainOfficeFunc() ) {
                    sender.ReadOnly = false;
                }
                else {
                    sender.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 拠点コンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender">対象コンボボックスツール</param>
        /// <param name="isAllSection">全社設定フラグ</param>
        public void SetSectionComboEditor ( ref Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, bool isAllSection )
        {
            Infragistics.Win.ValueList valueList;
            this.SetSectionComboEditor(out valueList, isAllSection);

            if ( valueList != null ) {
                sender.ValueList = valueList;
                sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

                if ( this.IsMainOfficeFunc() ) {
                    sender.SharedProps.Enabled = true;
                }
                else {
                    sender.SharedProps.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 拠点コンボエディタリスト設定処理
        /// </summary>
        /// <param name="sender">対象コンボボックスバリューリスト</param>
        /// <param name="isAllSection">全社設定フラグ</param>
        public void SetSectionComboEditor ( out Infragistics.Win.ValueList sender, bool isAllSection )
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            sender = new Infragistics.Win.ValueList();

            // ログイン担当拠点情報の取得
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if ( secInfoSet != null ) {
                if ( isAllSection ) {
                    Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                    secInfoItem.DataValue = SECTIONCODE_ALL;
                    secInfoItem.DisplayText = SECTIONNAME_ALL;
                    sender.ValueListItems.Add(secInfoItem);
                }

                // 拠点情報リストの取得
                if ( ( _secInfoAcs.SecInfoSetList != null ) && ( _secInfoAcs.SecInfoSetList.Length > 0 ) ) {
                    foreach ( SecInfoSet setSecInfoSet in _secInfoAcs.SecInfoSetList ) {
                        Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
                        secInfoItem.DataValue = setSecInfoSet.SectionCode;
                        secInfoItem.DisplayText = setSecInfoSet.SectionGuideNm;
                        sender.ValueListItems.Add(secInfoItem);
                    }
                }
            }
        }

        /// <summary>
        /// 拠点コンボエディタ選択値設定処理
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>true:設定成功 false:設定失敗</returns>
        public bool SetSectionComboEditorValue ( TComboEditor sender, string sectionCode )
        {
            bool isSetting = false;

            if ( sender.Items.Count > 0 ) {
                // 1つの拠点しかない場合は先頭を選択
                if ( sender.Items.Count == 1 ) {
                    sender.SelectedIndex = 0;
                    isSetting = true;
                }
                else {
                    for ( int i = 0; i < sender.Items.Count; i++ ) {
                        if ( sender.Items[i].DataValue.ToString().Trim() == sectionCode.Trim() ) {
                            sender.SelectedIndex = i;
                            isSetting = true;
                            break;
                        }
                    }
                }

                if ( !isSetting ) {
                    for ( int i = 0; i < sender.Items.Count; i++ ) {
                        if ( sender.Items[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim() ) {
                            sender.SelectedIndex = i;
                            isSetting = true;
                            break;
                        }
                    }
                }
            }

            return isSetting;
        }

        /// <summary>
        /// 拠点コンボエディタ選択値設定処理
        /// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
        /// <br>・OwnSecSetting = 自拠点設定</br>
        /// <br>・DemandAddUpSecCd = 請求計上拠点</br>
        /// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
        /// <br>・BillSettingSecCd = 請求設定拠点</br>
        /// <br>・BalanceDispSecCd = 残高表示拠点</br>
        /// <br>・PayAddUpSecCd = 支払計上拠点</br>
        /// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
        /// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
        /// <br>・StockUpdateSecCd = 在庫更新拠点</br>
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="ctrlFuncCode">取得する制御機能コード</param>
        /// <returns>true:設定成功 false:設定失敗</returns>
        public bool SetSectionComboEditorValue ( TComboEditor sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode )
        {
            if ( sectionCode.Trim() == SECTIONCODE_ALL ) {
                return this.SetSectionComboEditorValue(sender, sectionCode);
            }
            else {
                string ctrlSectionCode;
                string ctrlSectionName;
                int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

                if ( status == 0 ) {
                    return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
                }
                else {
                    return false;
                }
            }
        }

        /// <summary>
        /// 拠点コンボエディタ選択値設定処理
        /// </summary>
        /// <param name="sender">対象コンボボックス</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>true:設定成功 false:設定失敗</returns>
        public bool SetSectionComboEditorValue ( Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode )
        {
            bool isSetting = false;

            if ( sender.ValueList.ValueListItems.Count > 0 ) {
                sender.ValueList.MaxDropDownItems = sender.ValueList.ValueListItems.Count;

                // 1つの拠点しかない場合は先頭を選択
                if ( sender.ValueList.ValueListItems.Count == 1 ) {
                    sender.SelectedIndex = 0;
                    isSetting = true;
                }
                else {
                    for ( int i = 0; i < sender.ValueList.ValueListItems.Count; i++ ) {
                        if ( sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == sectionCode.Trim() ) {
                            sender.Value = sectionCode;
                            isSetting = true;
                            break;
                        }
                    }
                }

                if ( !isSetting ) {
                    for ( int i = 0; i < sender.ValueList.ValueListItems.Count; i++ ) {
                        if ( sender.ValueList.ValueListItems[i].DataValue.ToString().Trim() == this._loginSectionCode.Trim() ) {
                            sender.Value = this._loginSectionCode;
                            isSetting = true;
                            break;
                        }
                    }
                }
            }

            return isSetting;
        }

        /// <summary>
        /// 拠点コンボエディタ選択値設定処理
        /// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
        /// <br>・OwnSecSetting = 自拠点設定</br>
        /// <br>・DemandAddUpSecCd = 請求計上拠点</br>
        /// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
        /// <br>・BillSettingSecCd = 請求設定拠点</br>
        /// <br>・BalanceDispSecCd = 残高表示拠点</br>
        /// <br>・PayAddUpSecCd = 支払計上拠点</br>
        /// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
        /// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
        /// <br>・StockUpdateSecCd = 在庫更新拠点</br>
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="ctrlFuncCode">取得する制御機能コード</param>
        /// <returns>true:設定成功 false:設定失敗</returns>
        public bool SetSectionComboEditorValue ( Infragistics.Win.UltraWinToolbars.ComboBoxTool sender, string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode )
        {
            if ( sectionCode.Trim() == SECTIONCODE_ALL ) {
                return this.SetSectionComboEditorValue(sender, sectionCode);
            }
            else {
                string ctrlSectionCode;
                string ctrlSectionName;
                int status = this.GetOwnSeCtrlCode(sectionCode, ctrlFuncCode, out ctrlSectionCode, out ctrlSectionName);

                if ( status == 0 ) {
                    return this.SetSectionComboEditorValue(sender, ctrlSectionCode);
                }
                else {
                    return false;
                }
            }
        }

        /// <summary>
        /// 制御機能拠点取得処理
        /// <br>SecInfoAcs.CtrlFuncCode(SFKTN01210A)の詳細は以下の通り。</br>
        /// <br>・OwnSecSetting = 自拠点設定</br>
        /// <br>・DemandAddUpSecCd = 請求計上拠点</br>
        /// <br>・ResultsAddUpSecCd = 実績計上拠点</br>
        /// <br>・BillSettingSecCd = 請求設定拠点</br>
        /// <br>・BalanceDispSecCd = 残高表示拠点</br>
        /// <br>・PayAddUpSecCd = 支払計上拠点</br>
        /// <br>・PayAddUpSetSecCd = 支払設定拠点</br>
        /// <br>・PayBlcDispSecCd = 支払残高表示拠点</br>
        /// <br>・StockUpdateSecCd = 在庫更新拠点</br>
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="ctrlFuncCode">取得する制御機能コード</param>
        /// <param name="ctrlSectionCode">対象制御拠点コード</param>
        /// <param name="ctrlSectionName">対象制御拠点名称</param>
        public int GetOwnSeCtrlCode ( string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode, out string ctrlSectionName )
        {
            // 拠点制御アクセスクラスインスタンス化処理
            this.CreateSecInfoAcs();

            // 対象制御拠点の初期値はログイン担当拠点
            ctrlSectionCode = sectionCode.TrimEnd();
            ctrlSectionName = "";

            SecInfoSet secInfoSet;
            //int status = _secInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);
			int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);

            switch ( status ) {
                case ( int ) ConstantManagement.DB_Status.ctDB_NORMAL: {
                        if ( secInfoSet != null ) {
                            ctrlSectionCode = secInfoSet.SectionCode.Trim();
                            ctrlSectionName = secInfoSet.SectionGuideNm.Trim();
                        }
                        else {
                            // 拠点制御設定がされていない
                            status = ( int ) ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                        break;
                    }
                default: {
                        break;
                    }
            }

            return status;
        }
        #endregion
	
	}
}
