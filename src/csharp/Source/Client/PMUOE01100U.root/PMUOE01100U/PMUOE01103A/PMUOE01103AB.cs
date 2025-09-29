    //****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ手入力発注 初期値取得アクセスクラス
// プログラム概要   : ＵＯＥ手入力発注を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
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
	/// ＵＯＥ手入力発注用　初期値取得アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ手入力発注の初期値取得データ制御を行います。</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2007.04.17</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// </remarks>
	public class StockInputInitDataAcs
	{
        //アクセスクラス
		private static StockInputInitDataAcs _stockInputInitDataAcs;
        private StockInputInitialDataSet _dataSet;
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		private IEmployeeDB _iEmployeeDB;			// 従業員情報 アクセスクラス
		private UOEGuideNameAcs _uOEGuideNameAcs;	// UOEガイド名称マスタ アクセスクラス
		private SecInfoAcs _secInfoAcs;				// 拠点 アクセスクラス
		private SecInfoSetAcs _secInfoSetAcs;		// 拠点設定 アクセスクラス
        private EmployeeAcs _employeeAcs; 			// 従業員情報 アクセスクラス
        //private CustomerInfoAcs _customerInfoAcs;
        private UOEOrderDtlAcs _uOEOrderDtlAcs;     //ＵＯＥ発注データアクセスクラス

		//拠点設定マスタ
		private SecInfoSet _secInfoSet = null;

		//企業コード
        public string _enterpriseCode = "";
		public string _sectionCode = "";

		//public定数
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;		// ログイン拠点コード
        private string _ownSectionCode = "";

        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";
        internal const string SECTIONCODE_ALL = "000000";
        private const string SECTIONNAME_ALL = "全社";

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region UOE発注先マスタアクセスクラス
        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _uoeSndRcvJnlAcs.uOESupplierAcs; }
        }
		# endregion

        # region 送受信ＪＮＬアクセスクラス
        /// <summary>
        /// 送受信ＪＮＬアクセスクラス
        /// </summary>
        public UoeSndRcvJnlAcs uoeSndRcvJnlAcs
        {
            get { return _uoeSndRcvJnlAcs; }
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

		# region 商品マスタ アクセスクラス
		/// <summary>
		/// 商品マスタ アクセスクラス
		/// </summary>
		public GoodsAcs _goodsAcs
		{
			get { return _uoeSndRcvJnlAcs.goodsAcs; }
			set { _uoeSndRcvJnlAcs.goodsAcs = value; }
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

		#region コンストラクタ
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
		private StockInputInitDataAcs()
		{
			// 変数初期化
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
			
			this._dataSet = new StockInputInitialDataSet();
			this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
			this._uOEGuideNameAcs = new UOEGuideNameAcs();
			this._secInfoSetAcs = new SecInfoSetAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._employeeAcs = new EmployeeAcs();
            //this._customerInfoAcs = new CustomerInfoAcs();
        	this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();
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

		#region 初期データ取得処理
		/// <summary>
		/// 初期データ取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
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
			}
			finally
			{
				this._dataSet.Employee.EndLoadData();
				this._dataSet.UOEGuideName.EndLoadData();
			}

			return 0;
		}
        #endregion

        # region 仕入税込金額の取得(double)
        /// <summary>
        /// 仕入税込金額の取得(double)
        /// </summary>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <returns>税込み金額</returns>
        public double GetStockPriceTaxInc(double targetPrice, int taxationCode, int stockCnsTaxFrcProcCd)
        {
            return (_uOEOrderDtlAcs.GetStockPriceTaxInc(targetPrice, taxationCode, stockCnsTaxFrcProcCd));
        }

        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockCount">仕入数</param>
        /// <param name="stockUnitPrice">仕入単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入消費税</param>
        /// <returns></returns>
        public bool CalculationStockPrice(double stockCount, double stockUnitPrice, int taxationCode, int stockMoneyFrcProcCd, int taxFracProcCode, out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {
            return(_uOEOrderDtlAcs.CalculationStockPrice(stockCount, stockUnitPrice, taxationCode, stockMoneyFrcProcCd, taxFracProcCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax));
        }

        #endregion

        # region 従業員マスタクラスの取得
        /// <summary>
        /// 従業員マスタクラスの取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public EmployeeDtl GetEmployeeDtl(string enterpriseCode, string employeeCode)
        {
            Employee employee = null;
            EmployeeDtl employeeDtl = null;

            try
            {
                int status = _employeeAcs.Read(out employee, out employeeDtl, enterpriseCode, employeeCode);
                if (status != 0)
                {
                    employeeDtl = null;
                }
            }
            catch (ConstraintException)
            {
                employeeDtl = null;
            }
            return (employeeDtl);
        }
        #endregion

        # region 商品マスタ アクセスクラス制御処理
        /// <summary>
		/// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
		/// </summary>
		/// <param name="goodsNo">品番</param>
		/// <param name="makerCdList">検索対象のメーカーコードリスト</param>
		/// <param name="list">検索結果クラス</param>
		/// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
		public int SearchPartsFromGoodsNoForMstInf(string goodsNo, List<Int32> makerCdList, out List<GoodsUnitData> list)
		{
           return(SearchPartsFromGoodsNoForMstInf(goodsNo, 0, makerCdList, out list));
		}

        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="makerCdList">検索対象のメーカーコードリスト</param>
        /// <param name="list">検索結果クラス</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, int goodsMakerCd, List<Int32> makerCdList, out List<GoodsUnitData> list)
        {
			string msg = "";
			int status = 0;
			list = null;

			try
			{
				GoodsCndtn cndtn = new GoodsCndtn();

				cndtn.EnterpriseCode = _enterpriseCode;
				cndtn.SectionCode = _sectionCode;
				cndtn.GoodsNo = goodsNo;
                cndtn.GoodsMakerCd = goodsMakerCd;

                // 優先倉庫設定
                List<string> SectWarehouseCd = new List<string>();
                SectWarehouseCd.Add(_secInfoSet.SectWarehouseCd1);
                SectWarehouseCd.Add(_secInfoSet.SectWarehouseCd2);
                SectWarehouseCd.Add(_secInfoSet.SectWarehouseCd3);

                cndtn.ListPriorWarehouse = SectWarehouseCd;

                // 品番検索
                int serchMode = 0;
                if (makerCdList != null)
                {
                    if (makerCdList.Count != 0)
                    {
                        serchMode = 1;
                    }
                }

                if (serchMode == 0)
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, out list, out msg);
                }
                else
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, makerCdList, out list, out msg);
                }
            }
			catch (ConstraintException)
			{
				status = -1;
			}
			return (status);
        }

		/// <summary>
		/// メーカー情報取得
		/// </summary>
		/// <param name="makerCode">メーカーコード</param>
		/// <param name="makerUMnt">メーカー情報クラス</param>
		/// <returns></returns>
		public int GetMakerInf(int makerCode, out MakerUMnt makerUMnt)
		{
			int status = 0;
			makerUMnt = null;

			try
			{
				status = _goodsAcs.GetMaker(_enterpriseCode, makerCode, out makerUMnt);
			}
			catch (ConstraintException)
			{
				status = -1;
			}
			return (status);
		}

		/// <summary>
		/// メーカー名取得
		/// </summary>
		/// <param name="makerCode"></param>
		/// <returns></returns>
		public string GetName_FromMakerCode(int makerCode)
		{
			string makerName = "";
			MakerUMnt makerUMnt = null;
			try
			{
				int status = GetMakerInf(makerCode, out makerUMnt);
				if((status == 0) && (makerUMnt != null))
				{
					makerName = makerUMnt.MakerName;
				}
				else
				{
					makerName = "";
				}
			}
			catch (ConstraintException)
			{
				makerName = "";
			}
			return (makerName);
		}

		/// <summary>
		/// ＢＬ情報取得
		/// </summary>
		/// <param name="makerCode">メーカーコード</param>
		/// <param name="makerUMnt">メーカー情報クラス</param>
		/// <returns></returns>
		public int GetBLGoodsCdInf(int blGoodsCode, out BLGoodsCdUMnt bLGoodsCdUMnt)
		{
			int status = 0;
			bLGoodsCdUMnt = null;

			try
			{
				status = _goodsAcs.GetBLGoodsCd(blGoodsCode, out bLGoodsCdUMnt);
			}
			catch (ConstraintException)
			{
				status = -1;
			}
			return (status);
		}

		/// <summary>
		/// ＢＬコード名取得
		/// </summary>
		/// <param name="makerCode"></param>
		/// <returns></returns>
		public string GetName_FromBLGoodsCd(int blGoodsCode)
		{
			string blGoodsName = "";
			BLGoodsCdUMnt bLGoodsCdUMnt = null;
			try
			{
				int status = GetBLGoodsCdInf(blGoodsCode, out bLGoodsCdUMnt);
				if ((status == 0) && (bLGoodsCdUMnt != null))
				{
					blGoodsName = bLGoodsCdUMnt.BLGoodsFullName;
				}
				else
				{
					blGoodsName = "";
				}
			}
			catch (ConstraintException)
			{
				blGoodsName = "";
			}
			return (blGoodsName);
		}

        /// <summary>
        /// 価格マスタの検索
        /// </summary>
        /// <param name="list">価格マスタリスト</param>
        /// <returns>価格マスタ</returns>
        public GoodsPrice GetGoodsPrice_FromGoodsPriceList(List<GoodsPrice> list)
        {
            return(_goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, list));
        }

		/// <summary>
		/// メイン倉庫の在庫情報取得
		/// </summary>
		/// <param name="list">在庫情報リスト</param>
        /// <param name="selectedWarehouseCode">選択倉庫コード</param>
        /// <returns>在庫情報</returns>
        public Stock GetStock_FromSecInfoSet(List<Stock> list, string selectedWarehouseCode)
		{
			string sectWarehouseCd = "";
			Stock returnStock = null;

			try
			{
                if (list == null)
                {
                    returnStock = new Stock();
                    return (returnStock);
                }

				for (int i = 0; (i < 4) && (returnStock == null); i++)
				{
					switch(i)
					{
                        //選択倉庫の検索
                        case 0:
                            sectWarehouseCd = selectedWarehouseCode;
                            break;
                        //優先倉庫①の検索
                        case 1:
							sectWarehouseCd = _secInfoSet.SectWarehouseCd1;
							break;
                        //優先倉庫②の検索
                        case 2:
							sectWarehouseCd = _secInfoSet.SectWarehouseCd2;
							break;
                        //優先倉庫③の検索
                        case 3:
							sectWarehouseCd = _secInfoSet.SectWarehouseCd3;
							break;
					}

                    if (sectWarehouseCd == null) continue;
					if (sectWarehouseCd.Trim() == "") continue;

					foreach (Stock stock in list)
					{
						if (stock.WarehouseCode.Trim() == sectWarehouseCd.Trim())
						{
							returnStock = stock;
							break;
						}
					}
				}
			}
			catch (ConstraintException)
			{
				returnStock = null;
			}
			if (returnStock == null)
			{
				returnStock = new Stock();
			}
			return (returnStock);
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
            return(returnBool);
        }

		/// <summary>
		/// UOEガイド名称取得＜ガイド区分・発注先・ガイドコード指定＞
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
        /// UOEガイド名称一覧取得＜業務区分＞
        /// </summary>
        /// <param name="UOEGuideDivCd"></param>
        /// <param name="uOESupplier"></param>
        /// <returns>UOEガイド名称クラス</returns>
        public List<UOEGuideName> GetBusinessCodeList_FromUOEGuideName(int UOEGuideDivCd, UOESupplier uOESupplier)
        {
            List<UOEGuideName> list = new List<UOEGuideName>();

            string[] nm = new string[] {"発注", "見積","在庫確認"};

            try
			{
                string commAssemblyId = "";
                if (uOESupplier != null)
                {
                    commAssemblyId = uOESupplier.CommAssemblyId.Trim();
                }

                for (int i = 0; i < 3; i++)
                {
                    if ((commAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_1001)
                    && (i == 1))
                    {
                    }
                    else
                    {
                        UOEGuideName uOEGuideName = new UOEGuideName();
                        uOEGuideName.UOEGuideCode = String.Format("{0}", i+1);
                        uOEGuideName.UOEGuideNm = nm[i];
                        list.Add(uOEGuideName);
                    }
                }
            }
            catch (Exception)
            {
                list = new List<UOEGuideName>();
            }
            return (list);
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

			defaultUOEGuideCode = list[0].UOEGuideCode.Trim();
			if (uOEGuideCode.Trim() != "")
			{
				foreach (UOEGuideName dtl in list)
				{
					if (dtl.UOEGuideCode.Trim() == uOEGuideCode.Trim())
					{
                        defaultUOEGuideCode = uOEGuideCode.Trim();
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
			sec.DataValue = 0;
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
		/// メーカーガイドコンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender">対象コンボボックスバリューリスト</param>
		/// <param name="userGuideDivCd">ユーザーガイド区分</param>
		public void SetEnableOdrMakerCdComboEditor(out Infragistics.Win.ValueList sender, List<int> enableOdrMakerCd)
		{
			sender = new Infragistics.Win.ValueList();

			Infragistics.Win.ValueListItem sec = new Infragistics.Win.ValueListItem();
			sec.Tag = 0;
			sec.DataValue = 0;
			sec.DisplayText = "";
			sender.ValueListItems.Add(sec);

			foreach (int makerCode in enableOdrMakerCd)
			{
				Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
				secInfoItem.Tag = makerCode;
				secInfoItem.DataValue = makerCode;
				secInfoItem.DisplayText = GetName_FromMakerCode(makerCode);
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
