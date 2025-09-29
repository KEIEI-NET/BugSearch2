using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 抽出中画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 抽出処理</br>
	/// <br>Programmer	: 19077 渡邉 貴裕</br>
	/// <br>Date		: 2007.01.22</br>
	/// </remarks>
	public class MAZAI04310UB
	{
		#region Private Member
		private int _searchmode;            // 検索モード
		private string	_enterprisecode;    // 企業コード
		private int		_customercode;      // 顧客コード
		private int		_readCnt;           // 読み込み件数
		private int		_startCnt;          // 開始件数
        private int _carrierEp;             // 事業者コード
        private int _carrier;               // キャリア
        private int _tde_st_IoGoodsDay;            // 入出荷日(開始)
        private int _tde_ed_IoGoodsDay;         // 入出荷日(終了)
        private string _goodsCd;            // 商品コード
        private string _wareHouseCd;        // 倉庫コード
        private string _sectioncode;        // 拠点コード
        private int _acpayslipcd;        // 伝票区分
        private int _acpaytrancecd;      // 取引区分
        private int _makercd;               // メーカーコード
        private string _stocktellno;        // 携帯番号
        private string _productno;          // 製造番号

                    
		//private List<StockAcPayHist> _stockAcPayHistList;                 //DEL 2008/07/17 使用クラス変更の為
        private List<StockAcPayHisSearchRet> _stockAcPayHisSearchRetList;   //ADD 2008/07/17
        private List<StockCarEnterCarOutRet> _stockCarEnterCarOutRetList;   //ADD 2008/07/17
        #endregion

		#region Property
		/// <summary>
		/// 抽出モード
		/// </summary>
		internal int SearchMode
		{
			set{ this._searchmode = value; }
		}

		/// <summary>
		/// 企業コード
		/// </summary>
		internal string EnterpriseCode
		{
			set{ this._enterprisecode = value; }
			get{ return this._enterprisecode; }
		}

		/// <summary>
		/// 仕入先コード
		/// </summary>
		internal int CustomerCode
		{
			set{ this._customercode = value; }
			get{ return this._customercode; }
		}
		
		/// <summary>
        /// 事業者
        /// </summary>
        internal int CarrierEP
        {
            set { this._carrierEp = value; }
            get { return this._carrierEp; }
        }

        /// <summary>
        /// キャリア
        /// </summary>
        internal int Carrier
        {
            set { this._carrier = value; }
            get { return this._carrier; }
        }
        
        /// <sammary>
        /// 入出荷日
        /// </sammary>
        internal int tde_st_IoGoodsDay
        {
            set { this._tde_st_IoGoodsDay = value; }
            get { return this._tde_st_IoGoodsDay; }
        }

        /// <sammary>
        /// 入出荷日
        /// </sammary>
        internal int tde_ed_IoGoodsDay
        {
            set
            {
                if (value > 1000)
                {
                    this._tde_ed_IoGoodsDay = value;
                }
                else
                {
                    this._tde_ed_IoGoodsDay = AddDays(tde_st_IoGoodsDay, value);
                }
            }
                  
            get { return this._tde_ed_IoGoodsDay; }
        }

        /// <summary>
        /// 商品コード
        /// </summary>
		internal string GoodsCd
		{
			set{ this._goodsCd = value; }
			get{ return this._goodsCd; }
		}

        /// <summary>
        /// 倉庫コード
        /// </summary>
        internal string WareHouse
        {
            set { this._wareHouseCd = value; }
            get { return this._wareHouseCd; }
        }

        /// <summary>
        /// 拠点コード
        /// </summary>
        internal string SectionCd
        {
            set { this._sectioncode = value; }
            get { return this._sectioncode; }
        }

        /// <summary>
        /// 伝票区分
        /// </summary>
        internal int AcPaySlipCd
        {
            set { this._acpayslipcd  = value; }
            get { return this._acpayslipcd; }
        }

        /// <summary>
        /// 取引区分
        /// </summary>
        internal int AcPayTranceCd
        {
            set { this._acpaytrancecd = value; }
            get { return this._acpaytrancecd; }
        }
        
        /// <summary>
        /// メーカーコード
        /// </summary>
        internal int MakerCode
        {
            set { this._makercd = value; }
            get { return this._makercd; }
        }
        
        /// <summary>
        /// 携帯番号
        /// </summary>
        internal string StockTellNo
        {
            set { this._stocktellno = value; }
            get { return this._stocktellno; }
        }

        /// <summary>
        /// 製造番号
        /// </summary>
        internal string ProductNo
        {
            set { this._productno = value; }
            get { return this._productno; }
        }

		/// <summary>
		/// 抽出結果データ
		/// </summary>
        /* -----DEL 2008/07/17 使用クラス変更の為 ------------>>>>>
        internal List<StockAcPayHist> StockAcPayHistList
        {
            set{ this._stockAcPayHistList = value; }
            get{ return this._stockAcPayHistList; }
        }
           -----DEL 2008/07/17 -------------------------------<<<<< */
        // -----ADD 2008/07/17 ------------------------------->>>>>
        internal List<StockAcPayHisSearchRet> StockAcPayHisSearchRetList
        {
            set { this._stockAcPayHisSearchRetList = value; }
            get { return this._stockAcPayHisSearchRetList; }
        }

        internal List<StockCarEnterCarOutRet> StockCarEnterCarOutRetList
        {
            set { this._stockCarEnterCarOutRetList = value; }
            get { return this._stockCarEnterCarOutRetList; }
        }
        // -----ADD 2008/07/17 -------------------------------<<<<<

		/// <summary>
		/// 抽出開始行数
		/// </summary>
		internal int StartCnt
		{
			set{ this._startCnt = value; }
			get{ return this._startCnt; }
		}
		
		/// <summary>
		/// 抽出件数
		/// </summary>
		internal int ReadCnt
		{
			set{ this._readCnt = value; }
			get{ return this._readCnt; }
		}

        //日付範囲        
        private const int SEC_1 = 7;
        private const int SEC_2 = 14;
        private const int SEC_3 = 21;
        private const int SEC_4 = 100;
        private const int SEC_5 = 200;
        private const int SEC_6 = 300;

        private const int SEC_R1 = -7;
        private const int SEC_R2 = -14;
        private const int SEC_R3 = -21;
        private const int SEC_R4 = -100;
        private const int SEC_R5 = -200;
        private const int SEC_R6 = -300;

        #endregion

		#region Private Event
		/// <summary>
		/// フォームロード処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : フォームを開始します</br>
		/// <br>Programer  : 19077 渡邉貴裕</br>
		/// <br>Date       : 2007.01.23</br>
		/// </remarks>
		public void ReadProc()
		{
            try
            {
                // 履歴データ読込処理
                ReadHistoryData(this._searchmode);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
                    , ex.Source
                    , "履歴検索"
                    , ex.TargetSite.Name
                    , TMsgDisp.OPE_CALL
                    , ex.Message + "\n" + ex.StackTrace.ToString()
                    , 0
                    , null
                    , ex
                    , MessageBoxButtons.OK
                    , MessageBoxDefaultButton.Button1);
            }
            finally
            {
            }
        }
        #endregion

		#region Private Method
		/// <summary>
		/// 履歴読込処理
		/// </summary>
		/// <param name="_searchmode">履歴データ読込モード</param>
		/// <remarks>
		/// <br>Note       : 履歴データ読込みます</br>
		/// <br>Programer  : 19077 渡邉 貴裕</br>
		/// <br>Date       : 2007.01.23</br>
		/// </remarks>
		private void ReadHistoryData(int _searchmode)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 履歴データ初期化
            //ArrayList retArray = new ArrayList();

            //// アクセス部品
            //StockAcPayHistAcs _stockAcPayHistAcs = new StockAcPayHistAcs();
                                    
            //// パラメータオブジェクト作成     
            //StockAcPayHisSearchParaWork _parameter = new StockAcPayHisSearchParaWork();


            //// 検索・絞込条件セット
            //_parameter.EnterpriseCode	= this.EnterpriseCode;  //企業コード
            //_parameter.ProductNumber = this.ProductNo;          //製番
            //_parameter.StockTelNo1 = this.StockTellNo;          //携帯番号

            //_parameter.MakerCode = this.MakerCode;            //メーカーコード
            //_parameter.GoodsCode = this.GoodsCd;                //商品コード

            //if (this.tde_st_IoGoodsDay.ToString().Trim() != "0")
            //{
            //    _parameter.Starttde_st_IoGoodsDay = DateTime.ParseExact((this.tde_st_IoGoodsDay.ToString() + "000000"), "yyyyMMddHHmmss", null);
            //}
            //if (this.tde_ed_IoGoodsDay.ToString().Trim() != "0")
            //{
            //    _parameter.Endtde_st_IoGoodsDay = DateTime.ParseExact((this.tde_ed_IoGoodsDay.ToString() + "000000"), "yyyyMMddHHmmss", null);
            //}
            //else
            //{
            //    _parameter.Endtde_st_IoGoodsDay = DateTime.ParseExact(("99991231" + "000000"), "yyyyMMddHHmmss", null);
            //}
            
            //if (this.AcPaySlipCd != 0)
            //{
            //    _parameter.AcPaySlipCd = this.AcPaySlipCd;          //伝票区分
            //}

            //if (this.AcPayTranceCd != 0)
            //{
            //    //taka _parameter.AcPaySlipCd = this.AcPaySlipCd;          //伝票区分

            //}
            //this.retList = new ArrayList();

            //_parameter.SectionCode = this.SectionCd;            //拠点コード
            //_parameter.CarrierEpCode = this.CarrierEP;          //事業者コード
            //_parameter.CarrierCode = this.Carrier;              //キャリア
            //// 履歴データ読込 ※全件抽出の為、開始日・終了日は0指定
            //int st = _stockAcPayHistAcs.SearchAll(out retArray, _parameter);
            
            //// 該当データが存在する場合のみグリッドに履歴データをセット

            //// 抽出件数が存在する場合
            //if (retArray.Count != 0)
            //{

            //    // 既存データが存在する場合は抽出結果をマージする
            //    StockAcPayHist[] _getStockAcPayHistArr = null;
            //    StockAcPayHisDt[] _getStockAcPayHisDtArr = null;

            //    StockAcPayHist _getStockAcPayHist = null;
            //    StockAcPayHisDt _getStockAcPayHisDt = null; 

            //    int ii = 0;

            //    int mainStockAcPayHistLen = retArray.Count;

            //    ii = 0;

            //    bool bModeDt = false;

            //    _getStockAcPayHistArr = new StockAcPayHist[mainStockAcPayHistLen];
            //    _getStockAcPayHisDtArr = new StockAcPayHisDt[mainStockAcPayHistLen];
            //    foreach(Object wkObj in retArray)
            //    {
            //        if (wkObj is StockAcPayHist)
            //        {
            //            _getStockAcPayHist = (StockAcPayHist)wkObj;
            //            _getStockAcPayHistArr[ii] = _getStockAcPayHist;
            //            ii++;
            //        }
            //        else if (wkObj is StockAcPayHisDt)
            //        {
            //            bModeDt = true;
            //            _getStockAcPayHisDt = (StockAcPayHisDt)wkObj;
            //            _getStockAcPayHisDtArr[ii] = _getStockAcPayHisDt;
            //            ii++;
            //        }
            //    }

            //    StockAcPayHist[] _newStockAcPayHist = new StockAcPayHist[mainStockAcPayHistLen];
            //    StockAcPayHisDt[] _newStockAcPayHisDt = new StockAcPayHisDt[mainStockAcPayHistLen];

            //    int cnt = 0;

            //    if (bModeDt != true)
            //    {
            //        if (_getStockAcPayHistArr != null)
            //        {
            //            for (int ix = 0; ix < _getStockAcPayHistArr.Length; ix++)
            //            {
            //                _newStockAcPayHist[cnt] = _getStockAcPayHistArr[ix];
            //                cnt++;
            //            }

            //            for (int ix = 0; ix < _newStockAcPayHist.Length; ix++)
            //            {
            //                this.retList.Add(_newStockAcPayHist[ix]);
            //            }
            //        }

            //    }else if (_getStockAcPayHisDtArr != null)
            //    {
            //        for (int ix = 0; ix < _getStockAcPayHisDtArr.Length; ix++)
            //        {
            //            _newStockAcPayHisDt[cnt] = _getStockAcPayHisDtArr[ix];
            //            cnt++;
            //        }
            //        for (int ix = 0; ix < _newStockAcPayHisDt.Length; ix++)
            //        {
            //            this.retList.Add(_newStockAcPayHisDt[ix]);
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // 履歴データ初期化
            ArrayList retArray = new ArrayList();
            ArrayList retArray2 = new ArrayList();      //ADD 2008/07/17

            // アクセス部品
            StockAcPayHistAcs stockAcPayHistAcs = new StockAcPayHistAcs();

            //--------------------------------------------------------------------
            // 抽出条件の生成
            //--------------------------------------------------------------------
            // パラメータオブジェクト作成     
            StockAcPayHisSearchPara cndtn = new StockAcPayHisSearchPara();

            // 検索・絞込条件セット
            cndtn.EnterpriseCode = this.EnterpriseCode;  //企業コード

            cndtn.St_GoodsMakerCd = this.MakerCode;             //メーカーコード
            cndtn.Ed_GoodsMakerCd = this.MakerCode;             //メーカーコード
            cndtn.St_GoodsNo = this.GoodsCd;                    //商品番号
            cndtn.Ed_GoodsNo = this.GoodsCd;                    //商品番号
            
            // 拠点コード
            //cndtn.SectionCodes = new string[] { this.SectionCd };         //DEL 2009/01/09 不具合対応[9799]
            // --- ADD 2009/01/09 不具合対応[9799] ----------------------------------------------------->>>>>
            if (this.SectionCd == null)
            {
                cndtn.SectionCodes = null;
            }
            else
            {
                cndtn.SectionCodes = new string[] { this.SectionCd };
            }
            // --- ADD 2009/01/09 不具合対応[9799] -----------------------------------------------------<<<<<
            // 倉庫コード
            cndtn.St_WarehouseCode = this.WareHouse;
            cndtn.Ed_WarehouseCode = this.WareHouse;

            // 入出荷日
            if ( this.tde_st_IoGoodsDay.ToString().Trim() != "0" )
            {
                cndtn.St_IoGoodsDay = DateTime.ParseExact( ( this.tde_st_IoGoodsDay.ToString() + "000000" ), "yyyyMMddHHmmss", null );
            }
            if ( this.tde_ed_IoGoodsDay.ToString().Trim() != "0" )
            {
                cndtn.Ed_IoGoodsDay = DateTime.ParseExact( ( this.tde_ed_IoGoodsDay.ToString() + "000000" ), "yyyyMMddHHmmss", null );
            }
            else
            {
                cndtn.Ed_IoGoodsDay = DateTime.ParseExact( ( "99991231" + "000000" ), "yyyyMMddHHmmss", null );
            }

            // -----ADD 2008/07/17 --------------------------------------------------->>>>>
            // 年月度、締日の翌日取得
            DateTime yearMonth;
            Int32 year;
            DateTime startMonthDate;
            DateTime endMonthDate;
            DateGetAcs dateGetAcs = DateGetAcs.GetInstance();

            // 日付取得
            dateGetAcs.GetYearMonth(cndtn.St_IoGoodsDay, out yearMonth, out year, out startMonthDate, out endMonthDate);

            yearMonth = yearMonth.AddMonths(-1);
            cndtn.St_HisYearMonth = yearMonth.Year * 100 + yearMonth.Month;
            cndtn.St_AcPayDate = startMonthDate.Year * 10000 + startMonthDate.Month * 100 + startMonthDate.Day;
            //cndtn.St_AddUpADate = DateTime.ParseExact("20000101000000", "yyyyMMddHHmmss", null);
            //cndtn.Ed_AddUpADate = DateTime.ParseExact("99991231000000", "yyyyMMddHHmmss", null);
            // -----ADD 2008/07/17 ---------------------------------------------------<<<<<


            // 伝票区分
            if ( this.AcPaySlipCd != 0 )
            {
                cndtn.AcPaySlipCd = this.AcPaySlipCd;          //伝票区分
            }
            else
            {
                cndtn.AcPaySlipCd = -1;
            }
            // 有効区分=0:有効のみ
            cndtn.ValidDivCd = 0;

            //--------------------------------------------------------------------
            // 読み込み
            //--------------------------------------------------------------------

            // 履歴データ読込 ※全件抽出の為、開始日・終了日は0指定
            //int st = stockAcPayHistAcs.SearchAll( out retArray, cndtn );      //DEL 2008/07/17 在庫入出庫照会抽出結果追加の為
            int st = stockAcPayHistAcs.SearchAll(out retArray, out retArray2, cndtn);       

            //--------------------------------------------------------------------
            // 抽出結果の取得
            //--------------------------------------------------------------------

            // 抽出結果をコピー
            /* -----DEL 2008/07/17 使用クラス変更の為 ------------------------------->>>>>
            this._stockAcPayHistList = new List<StockAcPayHist>();
            
            foreach ( object retObj in retArray )
            {
                StockAcPayHist stockAcPayHist = (StockAcPayHist)retObj;

                // 結果リストに追加
                this._stockAcPayHistList.Add( stockAcPayHist );
            }
               -----DEL 2008/07/17 --------------------------------------------------<<<<< */
            // -----ADD 2008/07/17 -------------------------------------------------->>>>>
            this._stockAcPayHisSearchRetList = new List<StockAcPayHisSearchRet>();

            foreach (object retObj in retArray)
            {
                StockAcPayHisSearchRet stockAcPayHisSearchRet = (StockAcPayHisSearchRet)retObj;

                // 結果リストに追加
                this._stockAcPayHisSearchRetList.Add(stockAcPayHisSearchRet);
            }

            this._stockCarEnterCarOutRetList = new List<StockCarEnterCarOutRet>();

            foreach (object retObj in retArray2)
            {
                StockCarEnterCarOutRet stockCarEnterCarOutRet = (StockCarEnterCarOutRet)retObj;

                // 結果リストに追加
                this._stockCarEnterCarOutRetList.Add(stockCarEnterCarOutRet);
            }
            // -----ADD 2008/07/17 --------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        /// <summary>
        /// 日数分加算処理
        /// </summary>
        /// <param name="tgtDay">加算対象</param>
        /// <param name="addDay">加算区分</param>
        /// <remarks>
        /// <br>Note       : 対象日付に指定日数分加算します。</br>
        /// <br>Programer  : 19077 渡邉 貴裕</br>
        /// <br>Date       : 2007.01.23</br>
        /// </remarks>
        public int AddDays(int tgtDay, int addDay)
        {
            int year = (tgtDay - (tgtDay % 10000)) / 10000;
            int month = ( tgtDay % 10000) / 100;
            int day = ( tgtDay % 10000) % 100;

            int add = 0;
            switch (addDay)
            {
                case -1:
                    {
                        add = SEC_R1;
                        break;
                    }
                case -2:
                    {
                        add = SEC_R2;
                        break;
                    }
                case -3:
                    {
                        add = SEC_R3;
                        break;
                    }
                case -4:
                    {
                        add = SEC_R4;
                        break;
                    }
                case -5:
                    {
                        add = SEC_R5;
                        break;
                    }
                case -6:
                    {
                        add = SEC_R6;
                        break;
                    }
                case 0:
                    {
                        add = 0;
                        break;
                    }
                case 1:
                    {
                        add = SEC_1;
                        break;
                    }
                case 2:
                    {
                        add = SEC_2;
                        break;
                    }
                case 3:
                    {
                        add = SEC_3;
                        break;
                    }
                case 4:
                    {
                        add = SEC_4;
                        break;
                    }
                case 5:
                    {
                        add = SEC_5;
                        break;
                    }
                case 6:
                    {
                        add = SEC_6;
                        break;
                    }
            }

            DateTime datetime = new DateTime();

            datetime = DateTime.ParseExact(tgtDay.ToString() + "000000", "yyyyMMddHHmmss", null);
            
            if (Math.Abs(add) < 100)
            {
                datetime = datetime.AddDays(add);
            }
            else
            {
                datetime = datetime.AddMonths(add / 100);
            }
                        
            return datetime.Year * 10000 + datetime.Month * 100 + datetime.Day;
            
        }
		#endregion
	}
}
