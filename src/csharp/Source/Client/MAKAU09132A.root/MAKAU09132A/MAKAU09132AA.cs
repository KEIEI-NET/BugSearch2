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
    ///仕入先買掛金額マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 仕入先買掛金額マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30154 安藤 昌仁</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Note       : 流通.NS用に変更</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br></br>
    /// <br>Note       : PM.NS用に変更</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.14</br>
    /// <br></br>
    /// <br>Note       : 障害ID:10605対応</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2009.01.30</br>
    /// </remarks>
	public class SuplAccPayAcs
	{
		// --------------------------------------------------
		#region Private Members

        // 企業コード
        private string              _enterpriseCode         = "";

        /// <summary>仕入先買掛金額マスタリモートオブジェクト格納バッファ</summary>
        private ISuppRsltUpdDB _iSuppRsltUpdDB = null;

        // データセット
        private DataSet             _bindDataSet        = null;
        private DataTable           _custAccRecTable    = null;
        private DataTable           _custDmdPrcTable    = null;

        // 2009.01.14 Add >>>
        private DataTable _custAccRecTotalTable = null;
        private DataTable _custDmdPrcTotalTable = null;
        // 2009.01.14 Add <<<

        // マスタクラス格納リスト
        private Dictionary<Guid, SuplAccPayWork>  _custAccRecDic  = null;               // 仕入先買掛金額マスタ格納用
        private Dictionary<Guid, SuplierPayWork>  _custDmdPrcDic  = null;               // 仕入先支払金額マスタ格納用

        // マスタ取得用リスト
        // 2009.01.14 >>>
        //private ArrayList           _custAccRecList     = null;                         // 仕入先買掛金額マスタ取得用
        //private ArrayList           _custDmdPrcList     = null;                         // 仕入先支払金額マスタ取得用
        private CustomSerializeArrayList _custAccRecList = null;                          // 仕入先買掛金額マスタ取得用
        private CustomSerializeArrayList _custDmdPrcList = null;                          // 仕入先支払金額マスタ取得用

        MoneyKindAcs _moneyKindAcs = null;
        // 2009.01.14 <<<

        #endregion

        // --------------------------------------------------
        #region Public Members

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        public static readonly string TBL_CUSTACCREC_TITLE           = "CUSTACCREC_TABLE";
        public static readonly string TBL_CUSTDMDPRC_TITLE           = "CUSTDMDPRC_TABLE";
        // 2009.01.14 Add >>>
        public static readonly string TBL_CUSTACCRECTOTAL_TITLE = "CUSTACCRECTOTAL_TABLE";
        public static readonly string TBL_CUSTDMDPRCTOTAL_TITLE = "CUSTDMDPRCTOTAL_TABLE";
        // 2009.01.14 Add <<<
        public static readonly string COL_DELETEDATE_TITLE           = "削除日";
        public static readonly string COL_ADDUPSECCODE_TITLE         = "計上拠点コード";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
        public static readonly string COL_SUPPLIERCODE_TITLE = "仕入先コード";
        public static readonly string COL_SUPPLIERNAME_TITLE = "仕入先名称";
        public static readonly string COL_SUPPLIERNAME2_TITLE = "仕入先名称2";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_SUPPLIERSNM_TITLE = "仕入先略称";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
        public static readonly string COL_RESULTSECCODE_TITLE = "実績拠点コード";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

        public static readonly string COL_PAYEECODE_TITLE = "支払先コード";
        public static readonly string COL_PAYEENAME_TITLE            = "支払先名称";
        public static readonly string COL_PAYEENAME2_TITLE           = "支払先名称2";
        public static readonly string COL_PAYEESNM_TITLE             = "支払先略称";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_ADDUPDATEJP_TITLE          = "計上日";
        public static readonly string COL_ADDUPYEARMONTHJP_TITLE     = "計上年月";
		public static readonly string COL_ADDUPYEARMONTH_TITLE       = "_計上年月";
		public static readonly string COL_ADDUPDATE_TITLE            = "_計上日";
        public static readonly string COL_LASTTIMEACCPAY_TITLE       = "前回残高";                  // 前回買掛金額
        public static readonly string COL_LASTTIMEDEMAND_TITLE       = "前回残高";                  // 前回支払金額
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_THISTIMEPAYNRML_TITLE      = "今回支払金額（通常支払）";
        //public static readonly string COL_THISTIMEFEEPAYNRML_TITLE   = "今回手数料額（通常支払）";
        //public static readonly string COL_THISTIMEDISPAYNRML_TITLE   = "今回値引額（通常支払）";
        //public static readonly string COL_THISTIMERBTDMDNRML_TITLE   = "今回リベート額（通常支払）";
        //public static readonly string COL_THISTIMEDMDDEPO_TITLE      = "今回支払金額（預り金）";
        //public static readonly string COL_THISTIMEFEEDMDDEPO_TITLE   = "今回手数料額（預り金）";
        //public static readonly string COL_THISTIMEDISDMDDEPO_TITLE   = "今回値引額（預り金）";
        //public static readonly string COL_THISTIMERBTDMDDEPO_TITLE   = "今回リベート額（預り金）";
        public static readonly string COL_THISTIMEPAYNRML_TITLE      = "今回支払金額";
        public static readonly string COL_THISTIMEFEEPAYNRML_TITLE   = "今回手数料額";
        public static readonly string COL_THISTIMEDISPAYNRML_TITLE   = "今回値引額";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_THISTIMEPAYMENT_TITLE      = "今回支払";
        public static readonly string COL_THISTIMETTLBLCACPAY_TITLE    = "今回繰越残高（買掛計）";
        public static readonly string COL_THISTIMETTLBLCDMD_TITLE    = "今回繰越残高（支払計）";
        public static readonly string COL_THISTIMESTOCKPRICE_TITLE        = "今回仕入金額";                  // 今回仕入金額
        public static readonly string COL_THISSTCPRCTAX_TITLE         = "今回仕入消費税";                    // 今回仕入消費税
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_TTLINCDTBTTAXEXC_TITLE     = "今回支払";                  // 支払インセンティブ額合計（税抜き）
        //public static readonly string COL_TTLINCDTBTTAX_TITLE        = "支払消費税";                // 支払インセンティブ額合計（税）
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_OFSTHISTIMESTOCK_TITLE     = "今回仕入";  // 純仕入金額
        public static readonly string COL_OFSTHISSTOCKTAX_TITLE      = "消費税";   // 純仕入消費税
        public static readonly string COL_ITDEDOFFSETOUTTAX_TITLE    = "相殺後外税対象額";
        public static readonly string COL_ITDEDOFFSETINTAX_TITLE     = "相殺後内税対象額";
        public static readonly string COL_ITDEDOFFSETTAXFREE_TITLE   = "相殺後非課税対象額";
        public static readonly string COL_OFFSETOUTTAX_TITLE         = "相殺後外税消費税";
        public static readonly string COL_OFFSETINTAX_TITLE          = "相殺後内税消費税";
        public static readonly string COL_ITDEDSTCOUTTAX_TITLE     = "仕入外税対象額";
        public static readonly string COL_ITDEDSTCINTAX_TITLE      = "仕入内税対象額";
        public static readonly string COL_ITDEDSTCTAXFREE_TITLE    = "仕入非課税対象額";
        public static readonly string COL_TTLSTOCKOUTERTAX_TITLE          = "仕入外税額";
        public static readonly string COL_TTLSTOCKINNERTAX_TITLE           = "仕入内税額";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_ITDEDPAYMOUTTAX_TITLE      = "支払外税対象額";
        //public static readonly string COL_ITDEDPAYMINTAX_TITLE       = "支払内税対象額";
        //public static readonly string COL_ITDEDPAYMTAXFREE_TITLE     = "支払非課税対象額";
        //public static readonly string COL_PAYMENTOUTTAX_TITLE        = "支払外税消費税";
        //public static readonly string COL_PAYMENTINTAX_TITLE         = "支払内税消費税";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_TTLITDEDRETOUTTAX_TITLE    = "返品外税対象額";
        public static readonly string COL_TTLITDEDRETINTAX_TITLE     = "返品内税対象額";
        public static readonly string COL_TTLITDEDRETTAXFREE_TITLE   = "返品非課税対象額";
        public static readonly string COL_TTLRETOUTERTAX_TITLE       = "返品外税額";
        public static readonly string COL_TTLRETINNERTAX_TITLE       = "返品内税額";
        public static readonly string COL_TTLITDEDDISOUTTAX_TITLE    = "値引外税対象額";
        public static readonly string COL_TTLITDEDDISINTAX_TITLE     = "値引内税対象額";
        public static readonly string COL_TTLITDEDDISTAXFREE_TITLE   = "値引非課税対象額";
        public static readonly string COL_TTLDISOUTERTAX_TITLE       = "値引外税額";
        public static readonly string COL_TTLDISINNERTAX_TITLE       = "値引内税額";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_BALANCEADJUST_TITLE        = "残高調整額";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
        public static readonly string COL_TAXADJUST_TITLE = "消費税調整額";
        public static readonly string COL_TOTALADJUST_TITLE = "残高調整額表示";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

        // 買掛テーブルからは削除されたが、支払テーブルに残ったままなので削除しない
        public static readonly string COL_NONSTMNTAPPEARANCE_TITLE   = "未決済金額（自振）";
        public static readonly string COL_NONSTMNTISDONE_TITLE       = "未決済金額（廻し）";
        public static readonly string COL_STMNTAPPEARANCE_TITLE      = "決済金額（自振）";
        public static readonly string COL_STMNTISDONE_TITLE          = "決済金額（廻し）";
        
        //public static readonly string COL_THISCASHSTOCKPRICE          = "今回現金仕入額";
        //public static readonly string COL_THISCASHSTOCKTAX            = "今回現金仕入消費税額";
        public static readonly string COL_STOCKSLIPCOUNT             = "仕入伝票枚数";
        public static readonly string COL_BILLPRINTDATE              = "支払書発行日";
        public static readonly string COL_PAYMENTSCHEDULE        = "支払予定日";
        public static readonly string COL_PAYMENTCOND                = "回収条件";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_SUPPCTAXLAYCD_TITLE     = "消費税転嫁方式";
        public static readonly string COL_SUPPLIERCONSTAXRATE_TITLE          = "消費税率";
        public static readonly string COL_FRACTIONPROCCD_TITLE       = "端数処理区分";
        public static readonly string COL_STCKTTLACCPAYBALANCE_TITLE    = "買掛残高";                  // 計算後当月買掛金額
        public static readonly string COL_AFCALDEMANDPRICE_TITLE     = "買掛残高";                  // 計算後支払金額
        public static readonly string COL_STCKTTL2TMBFBLACCPAY_TITLE = "前々回残高";              // 受注2回前残高(買掛計)
        public static readonly string COL_ACPODRTTL2TMBFBLDMD_TITLE = "前々回残高";              // 受注2回前残高(支払計)
        public static readonly string COL_STCKTTL3TMBFBLACCPAY_TITLE = "前々々回残高";              // 受注3回前残高(買掛計)
        public static readonly string COL_ACPODRTTL3TMBFBLDMD_TITLE = "前々々回残高";              // 受注3回前残高(支払計)
        public static readonly string COL_MONTHADDUPEXPDATE_TITLE    = "月次更新実行年月日";
        public static readonly string COL_CADDUPUPDEXECDATE_TITLE    = "締次更新実行年月日";
        public static readonly string COL_DMDPROCNUM_TITLE           = "支払処理通番";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
        //public static readonly string COL_THISRECVOFFSET_TITLE = "今回受取相殺金額";
        //public static readonly string COL_THISRECVOFFSETTAX_TITLE = "今回受取相殺消費税額";
        //public static readonly string COL_THISRECVOUTTAX_TITLE = "受取外税対象額";
        //public static readonly string COL_THISRECVINTAX_TITLE = "受取内税対象額";
        //public static readonly string COL_THISRECVTAXFREE_TITLE = "受取非課税対象額";
        //public static readonly string COL_THISRECVOUTERTAX_TITLE = "受取外税消費税";
        //public static readonly string COL_THISRECVINNERTAX_TITLE = "受取内税消費税";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
        
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_GUID_TITLE                 = "GUID";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_CREATEDATETIME = "作成日時";
        public static readonly string COL_UPDATEDATETIME = "更新日時";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // 2009.01.14 Add >>>
        public static readonly string COL_STMONCADDUPUPDDATE_TITLE = "月次更新開始年月日";
        public static readonly string COL_LAMONCADDUPUPDDATE_TITLE = "前回月次更新年月日";
        public static readonly string COL_STARTCADDUPUPDDATE_TITLE = "締次更新開始年月日";
        public static readonly string COL_LASTCADDUPUPDDATE_TITLE = "前回締次更新年月日";

        public static readonly string COL_PAYTOTAL = "支払集計データ";
        public static readonly string ALL_SECTION = "00";
        // 2009.01.14 Add <<<

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>仕入先買掛金額マスタテーブルアクセスクラスコンストラクタ</summary>
		/// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public SuplAccPayAcs ()
		{
			try {
				// 企業コード取得
				this._enterpriseCode          = LoginInfoAcquisition.EnterpriseCode;

				// リモートオブジェクト取得
                this._iSuppRsltUpdDB          = (ISuppRsltUpdDB)MediationSuppRsltUpdDB.GetSuppRsltUpdDB();

                // マスタクラス格納リスト初期化
                this._custAccRecDic       = new Dictionary<Guid, SuplAccPayWork>();
                this._custDmdPrcDic       = new Dictionary<Guid, SuplierPayWork>();

                // マスタ取得用リスト初期化
                // 2009.01.14 >>>
                //this._custAccRecList      = new ArrayList();
                //this._custDmdPrcList      = new ArrayList();
                this._custAccRecList = new CustomSerializeArrayList();
                this._custDmdPrcList = new CustomSerializeArrayList();
                this._moneyKindAcs = new MoneyKindAcs();
                // 2009.01.14 <<<

                // データセット初期化
                this._bindDataSet             = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();
			}
			catch( Exception ) {
				// オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;
			}
		}

		/// <summary>データセット列情報構築処理</summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
        ///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// 仕入先買掛金額マスタテーブル
            this._custAccRecTable = new DataTable(TBL_CUSTACCREC_TITLE);

			// Addを行う順番が、列の表示順位となります。
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add( COL_CREATEDATETIME, typeof( DateTime ) );  // 作成日時
            this._custAccRecTable.Columns.Add( COL_UPDATEDATETIME, typeof( DateTime ) );  // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add( COL_DELETEDATE_TITLE, typeof( string ) );  // 削除日
            this._custAccRecTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // 計上拠点コード

            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            this._custAccRecTable.Columns.Add(COL_SUPPLIERCODE_TITLE, typeof(Int32));   // 仕入先コード
            this._custAccRecTable.Columns.Add(COL_SUPPLIERNAME_TITLE, typeof(string));  // 仕入先名称
            this._custAccRecTable.Columns.Add(COL_SUPPLIERNAME2_TITLE, typeof(string));  // 仕入先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_SUPPLIERSNM_TITLE, typeof(string));  // 仕入先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            this._custAccRecTable.Columns.Add(COL_PAYEECODE_TITLE,            typeof(Int32));   // 支払先コード
            this._custAccRecTable.Columns.Add(COL_PAYEENAME_TITLE,            typeof(string));  // 支払先名称
            this._custAccRecTable.Columns.Add(COL_PAYEENAME2_TITLE,           typeof(string));  // 支払先名称2
            this._custAccRecTable.Columns.Add(COL_PAYEESNM_TITLE,             typeof(string));  // 支払先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // 計上年月日
            // 2009.01.14 Add >>>
            this._custAccRecTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "月次更新日";
            // 2009.01.14 Add <<<
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // 計上年月
            this._custAccRecTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _計上年月
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _計上年月日
            this._custAccRecTable.Columns.Add(COL_THISTIMEPAYNRML_TITLE,      typeof(Int64));   // 今回支払金額（通常支払）
            this._custAccRecTable.Columns.Add(COL_THISTIMEFEEPAYNRML_TITLE,   typeof(Int64));   // 今回手数料額（通常支払）
            this._custAccRecTable.Columns.Add(COL_THISTIMEDISPAYNRML_TITLE,   typeof(Int64));   // 今回値引額（通常支払）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // 今回リベート額（通常支払）
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // 今回支払金額（預り金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // 今回手数料額（預り金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // 今回値引額（預り金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMETTLBLCACPAY_TITLE,    typeof(Int64));   // 今回繰越残高（買掛計）
            //this._custAccRecTable.Columns.Add(COL_THISNETSTCKPRICE_TITLE,     typeof(Int64));   // 相殺後今回仕入金額
            //this._custAccRecTable.Columns.Add(COL_THISNETSTCPRCTAX_TITLE,      typeof(Int64));   // 相殺後今回仕入消費税
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // 相殺後外税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // 相殺後内税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // 相殺後非課税対象額
            this._custAccRecTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // 相殺後外税消費税
            this._custAccRecTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // 相殺後内税消費税
            this._custAccRecTable.Columns.Add(COL_ITDEDSTCOUTTAX_TITLE,     typeof(Int64));   // 仕入外税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDSTCINTAX_TITLE,      typeof(Int64));   // 仕入内税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDSTCTAXFREE_TITLE,    typeof(Int64));   // 仕入非課税対象額
            this._custAccRecTable.Columns.Add(COL_TTLSTOCKOUTERTAX_TITLE,          typeof(Int64));   // 仕入外税額
            this._custAccRecTable.Columns.Add(COL_TTLSTOCKINNERTAX_TITLE,           typeof(Int64));   // 仕入内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // 支払外税対象額
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // 支払内税対象額
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // 支払非課税対象額
            //this._custAccRecTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // 支払外税消費税
            //this._custAccRecTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_SUPPCTAXLAYCD_TITLE,     typeof(Int32));   // 消費税転嫁方式
            this._custAccRecTable.Columns.Add(COL_SUPPLIERCONSTAXRATE_TITLE,          typeof(Double));  // 消費税率
            this._custAccRecTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // 端数処理区分
            this._custAccRecTable.Columns.Add(COL_MONTHADDUPEXPDATE_TITLE,    typeof(Int32));   // 月次更新実行年月日
            this._custAccRecTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custAccRecTable.Columns.Add(COL_STCKTTL3TMBFBLACCPAY_TITLE, typeof(Int64));   // 受注3回前残高（買掛計）
            this._custAccRecTable.Columns.Add(COL_STCKTTL2TMBFBLACCPAY_TITLE, typeof(Int64));   // 受注2回前残高（買掛計）
            this._custAccRecTable.Columns.Add(COL_LASTTIMEACCPAY_TITLE,       typeof(Int64));   // 前回買掛金額
            this._custAccRecTable.Columns.Add(COL_THISTIMESTOCKPRICE_TITLE,        typeof(Int64));   // 今回仕入金額
            this._custAccRecTable.Columns.Add(COL_THISSTCPRCTAX_TITLE,         typeof(Int64));   // 今回仕入消費税
            this._custAccRecTable.Columns.Add(COL_OFSTHISTIMESTOCK_TITLE, typeof(Int64));   // 相殺後今回仕入金額
            this._custAccRecTable.Columns.Add(COL_OFSTHISSTOCKTAX_TITLE, typeof(Int64));   // 相殺後今回仕入消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // 支払インセンティブ額合計（税抜き）
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMEPAYMENT_TITLE,      typeof(Int64));   // 今回支払
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_TTLITDEDRETOUTTAX_TITLE,    typeof(Int64));   // 返品外税対象額
            this._custAccRecTable.Columns.Add(COL_TTLITDEDRETINTAX_TITLE,     typeof(Int64));   // 返品内税対象額
            this._custAccRecTable.Columns.Add(COL_TTLITDEDRETTAXFREE_TITLE,   typeof(Int64));   // 返品非課税対象額
            this._custAccRecTable.Columns.Add(COL_TTLRETOUTERTAX_TITLE,       typeof(Int64));   // 返品外税額
            this._custAccRecTable.Columns.Add(COL_TTLRETINNERTAX_TITLE,       typeof(Int64));   // 返品内税額
            this._custAccRecTable.Columns.Add(COL_TTLITDEDDISOUTTAX_TITLE,    typeof(Int64));   // 値引外税対象額
            this._custAccRecTable.Columns.Add(COL_TTLITDEDDISINTAX_TITLE,     typeof(Int64));   // 値引内税対象額
            this._custAccRecTable.Columns.Add(COL_TTLITDEDDISTAXFREE_TITLE,   typeof(Int64));   // 値引非課税対象額
            this._custAccRecTable.Columns.Add(COL_TTLDISOUTERTAX_TITLE,       typeof(Int64));   // 値引外税額
            this._custAccRecTable.Columns.Add(COL_TTLDISINNERTAX_TITLE,       typeof(Int64));   // 値引内税額
            this._custAccRecTable.Columns.Add(COL_BALANCEADJUST_TITLE,        typeof(Int64));   // 残高調整額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            this._custAccRecTable.Columns.Add(COL_TAXADJUST_TITLE, typeof(Int64));   // 消費税調整額
            this._custAccRecTable.Columns.Add(COL_TOTALADJUST_TITLE, typeof(Int64));   // 残高調整額表示
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // 未決済金額（自振）
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // 未決済金額（廻し）
            //this._custAccRecTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // 決済金額（自振）
            //this._custAccRecTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //this._custAccRecTable.Columns.Add(COL_THISCASHSTOCKPRICE,          typeof(Int64));   // 今回仕入金額
            //this._custAccRecTable.Columns.Add(COL_THISCASHSTOCKTAX,            typeof(Int64));   // 今回仕支払消費税額
            this._custAccRecTable.Columns.Add(COL_STOCKSLIPCOUNT,             typeof(Int64));   // 仕入伝票枚数
            this._custAccRecTable.Columns.Add(COL_BILLPRINTDATE,              typeof(Int64));   // 支払書発行日
            this._custAccRecTable.Columns.Add(COL_PAYMENTSCHEDULE,        typeof(Int64));   // 支払予定日
            this._custAccRecTable.Columns.Add(COL_PAYMENTCOND,                typeof(Int64));   // 回収条件
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_STCKTTLACCPAYBALANCE_TITLE,    typeof(Int64));   // 計算後当月買掛金額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //this._custAccRecTable.Columns.Add( COL_THISRECVINNERTAX_TITLE, typeof( Int64 ) );   // 受取内税消費税 
            //this._custAccRecTable.Columns.Add( COL_THISRECVINTAX_TITLE, typeof( Int64 ) );   // 受取内税対象額
            //this._custAccRecTable.Columns.Add( COL_THISRECVOFFSET_TITLE, typeof( Int64 ) );   // 今回受取相殺金額
            //this._custAccRecTable.Columns.Add( COL_THISRECVOFFSETTAX_TITLE, typeof( Int64 ) );   // 今回受取相殺消費税
            //this._custAccRecTable.Columns.Add( COL_THISRECVOUTERTAX_TITLE, typeof( Int64 ) );   // 受取外税消費税
            //this._custAccRecTable.Columns.Add( COL_THISRECVOUTTAX_TITLE, typeof( Int64 ) );   // 受取外税対象額
            //this._custAccRecTable.Columns.Add( COL_THISRECVTAXFREE_TITLE, typeof( Int64 ) );   // 受取非課税対象額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.14 Add >>>
            this._custAccRecTable.Columns.Add(COL_STMONCADDUPUPDDATE_TITLE, typeof(Int32));     // 月次更新開始年月日
            this._custAccRecTable.Columns.Add(COL_LAMONCADDUPUPDDATE_TITLE, typeof(Int32));     // 前回月次更新年月日
            this._custAccRecTable.Columns.Add(COL_PAYTOTAL, typeof(List<ACalcPayTotal>));      // 支払集計データ
            // 2009.01.14 Add <<<

            // PrimaryKey設定
            this._custAccRecTable.PrimaryKey = new DataColumn[] { this._custAccRecTable.Columns[COL_ADDUPSECCODE_TITLE],    // 計上拠点コード
                                                                  this._custAccRecTable.Columns[COL_PAYEECODE_TITLE],       // 支払先コード
                                                                  this._custAccRecTable.Columns[COL_SUPPLIERCODE_TITLE],    // 仕入先コード
                                                                  this._custAccRecTable.Columns[COL_ADDUPDATE_TITLE]};      // 計上年月日

            this._bindDataSet.Tables.Add(this._custAccRecTable);

            // 2009.01.14 Add >>>
            this._custAccRecTotalTable = new DataTable(TBL_CUSTACCRECTOTAL_TITLE);
            this._custAccRecTotalTable = this._custAccRecTable.Clone();
            this._custAccRecTotalTable.TableName = TBL_CUSTACCRECTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custAccRecTotalTable);
            // 2009.01.14 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            // x仕入先買掛金額マスタテーブル
            // 仕入先請求金額マスタテーブル (※テーブル名間違い)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
            this._custDmdPrcTable = new DataTable(TBL_CUSTDMDPRC_TITLE);

			// Addを行う順番が、列の表示順位となります。
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add( COL_CREATEDATETIME, typeof( DateTime ) );  // 作成日時
            this._custDmdPrcTable.Columns.Add( COL_UPDATEDATETIME, typeof( DateTime ) );  // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add( COL_DELETEDATE_TITLE, typeof( string ) );  // 削除日
            this._custDmdPrcTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // 計上拠点コード

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERCODE_TITLE, typeof(Int32));   // 仕入先コード
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERNAME_TITLE, typeof(string));  // 仕入先名称
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERNAME2_TITLE, typeof(string));  // 仕入先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERSNM_TITLE, typeof(string));  // 
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            this._custDmdPrcTable.Columns.Add(COL_RESULTSECCODE_TITLE, typeof(string));     // 実績拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

            this._custDmdPrcTable.Columns.Add(COL_PAYEECODE_TITLE, typeof(Int32));   // 支払先コード
            this._custDmdPrcTable.Columns.Add(COL_PAYEENAME_TITLE,            typeof(string));  // 支払先名称
            this._custDmdPrcTable.Columns.Add(COL_PAYEENAME2_TITLE,           typeof(string));  // 支払先名称2
            this._custDmdPrcTable.Columns.Add(COL_PAYEESNM_TITLE,             typeof(string));  // 支払先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // 計上年月日
            // 2009.01.14 Add >>>
            this._custDmdPrcTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "締処理日";  // 計上年月日
            // 2009.01.14 Add <<<
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // 計上年月
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _計上年月
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _計上年月日
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEPAYNRML_TITLE,      typeof(Int64));   // 今回支払金額（通常支払）
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEPAYNRML_TITLE,   typeof(Int64));   // 今回手数料額（通常支払）
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISPAYNRML_TITLE,   typeof(Int64));   // 今回値引額（通常支払）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // 今回リベート額（通常支払）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // 今回支払金額（預り金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // 今回手数料額（預り金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // 今回値引額（預り金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMETTLBLCDMD_TITLE,    typeof(Int64));   // 今回繰越残高（支払計）
            //this._custDmdPrcTable.Columns.Add(COL_THISNETSTCKPRICE_TITLE,     typeof(Int64));   // 相殺後今回仕入金額
            //this._custDmdPrcTable.Columns.Add(COL_THISNETSTCPRCTAX_TITLE,      typeof(Int64));   // 相殺後今回仕入消費税
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // 相殺後外税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // 相殺後内税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // 相殺後非課税対象額
            this._custDmdPrcTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // 相殺後外税消費税
            this._custDmdPrcTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // 相殺後内税消費税
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSTCOUTTAX_TITLE,     typeof(Int64));   // 仕入外税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSTCINTAX_TITLE,      typeof(Int64));   // 仕入内税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSTCTAXFREE_TITLE,    typeof(Int64));   // 仕入非課税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLSTOCKOUTERTAX_TITLE,          typeof(Int64));   // 仕入外税額
            this._custDmdPrcTable.Columns.Add(COL_TTLSTOCKINNERTAX_TITLE,           typeof(Int64));   // 仕入内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // 支払外税対象額
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // 支払内税対象額
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // 支払非課税対象額
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // 支払外税消費税
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_SUPPCTAXLAYCD_TITLE,     typeof(Int32));   // 消費税転嫁方式
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERCONSTAXRATE_TITLE,          typeof(Double));  // 消費税率
            this._custDmdPrcTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // 端数処理区分
            this._custDmdPrcTable.Columns.Add(COL_CADDUPUPDEXECDATE_TITLE,    typeof(Int32));   // 締次更新実行年月日
            this._custDmdPrcTable.Columns.Add(COL_DMDPROCNUM_TITLE,           typeof(Int32));   // 支払処理通番
            this._custDmdPrcTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL3TMBFBLDMD_TITLE,  typeof(Int64));   // 受注3回前残高（支払計）
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL2TMBFBLDMD_TITLE,  typeof(Int64));   // 受注2回前残高（支払計）
            this._custDmdPrcTable.Columns.Add(COL_LASTTIMEDEMAND_TITLE,       typeof(Int64));   // 前回支払金額
            this._custDmdPrcTable.Columns.Add(COL_THISTIMESTOCKPRICE_TITLE,        typeof(Int64));   // 今回仕入金額
            this._custDmdPrcTable.Columns.Add(COL_THISSTCPRCTAX_TITLE,         typeof(Int64));   // 今回仕入消費税
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISTIMESTOCK_TITLE,     typeof(Int64));   // 相殺後今回仕入金額
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISSTOCKTAX_TITLE,      typeof(Int64));   // 相殺後今回仕入消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // 支払インセンティブ額合計（税抜き）
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEPAYMENT_TITLE,      typeof(Int64));   // 今回支払
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDRETOUTTAX_TITLE,    typeof(Int64));   // 返品外税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDRETINTAX_TITLE,     typeof(Int64));   // 返品内税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDRETTAXFREE_TITLE,   typeof(Int64));   // 返品非課税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLRETOUTERTAX_TITLE,       typeof(Int64));   // 返品外税額
            this._custDmdPrcTable.Columns.Add(COL_TTLRETINNERTAX_TITLE,       typeof(Int64));   // 返品内税額
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDDISOUTTAX_TITLE,    typeof(Int64));   // 値引外税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDDISINTAX_TITLE,     typeof(Int64));   // 値引内税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDDISTAXFREE_TITLE,   typeof(Int64));   // 値引非課税対象額
            this._custDmdPrcTable.Columns.Add(COL_TTLDISOUTERTAX_TITLE,       typeof(Int64));   // 値引外税額
            this._custDmdPrcTable.Columns.Add(COL_TTLDISINNERTAX_TITLE,       typeof(Int64));   // 値引内税額
            this._custDmdPrcTable.Columns.Add(COL_BALANCEADJUST_TITLE,        typeof(Int64));   // 残高調整額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            this._custDmdPrcTable.Columns.Add(COL_TAXADJUST_TITLE, typeof(Int64));   // 消費税調整額
            this._custDmdPrcTable.Columns.Add(COL_TOTALADJUST_TITLE, typeof(Int64));   // 残高調整額表示
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // 未決済金額（自振）
            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // 未決済金額（廻し）
            this._custDmdPrcTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // 決済金額（自振）
            this._custDmdPrcTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // 決済金額（廻し）

            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSTOCKPRICE,          typeof(Int64));   // 今回現金仕入金額
            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSTOCKTAX,            typeof(Int64));   // 今回現金仕支払消費税額
            this._custDmdPrcTable.Columns.Add(COL_STOCKSLIPCOUNT,             typeof(Int64));   // 仕入伝票枚数
            this._custDmdPrcTable.Columns.Add(COL_BILLPRINTDATE,              typeof(Int64));   // 支払書発行日
            this._custDmdPrcTable.Columns.Add(COL_PAYMENTSCHEDULE,        typeof(Int64));   // 支払予定日
            this._custDmdPrcTable.Columns.Add(COL_PAYMENTCOND,                typeof(Int64));   // 回収条件
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_AFCALDEMANDPRICE_TITLE,     typeof(Int64));   // 計算後支払金額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVINNERTAX_TITLE, typeof( Int64 ) );   // 受取内税消費税 
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVINTAX_TITLE, typeof( Int64 ) );   // 受取内税対象額
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOFFSET_TITLE, typeof( Int64 ) );   // 今回受取相殺金額
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOFFSETTAX_TITLE, typeof( Int64 ) );   // 今回受取相殺消費税
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOUTERTAX_TITLE, typeof( Int64 ) );   // 受取外税消費税
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOUTTAX_TITLE, typeof( Int64 ) );   // 受取外税対象額
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVTAXFREE_TITLE, typeof( Int64 ) );   // 受取非課税対象額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // 2009.01.14 Add >>>
            this._custDmdPrcTable.Columns.Add(COL_STARTCADDUPUPDDATE_TITLE, typeof(Int32));     // 締次更新開始年月日
            this._custDmdPrcTable.Columns.Add(COL_LASTCADDUPUPDDATE_TITLE, typeof(Int32));      // 前回締次更新年月日
            this._custDmdPrcTable.Columns.Add(COL_PAYTOTAL, typeof(List<AccPayTotal>));        // 支払集計データ
            // 2009.01.14 Add <<<

            // PrimaryKey設定
            this._custDmdPrcTable.PrimaryKey = new DataColumn[] { this._custDmdPrcTable.Columns[COL_ADDUPSECCODE_TITLE],    // 計上拠点コード
                                                                  this._custDmdPrcTable.Columns[COL_PAYEECODE_TITLE],       // 支払先コード
                                                                  this._custDmdPrcTable.Columns[COL_SUPPLIERCODE_TITLE],    // 仕入先コード
                                                                  // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
                                                                  this._custDmdPrcTable.Columns[COL_RESULTSECCODE_TITLE],
                                                                  // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END
                                                                  this._custDmdPrcTable.Columns[COL_ADDUPDATE_TITLE]};            // 計上年月日

            this._bindDataSet.Tables.Add(this._custDmdPrcTable);

            // 2009.01.14 Add >>>
            this._custDmdPrcTotalTable = new DataTable(TBL_CUSTDMDPRCTOTAL_TITLE);
            this._custDmdPrcTotalTable = this._custDmdPrcTable.Clone();
            this._custDmdPrcTotalTable.TableName = TBL_CUSTDMDPRCTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custDmdPrcTotalTable);
            // 2009.01.14 Add <<<
        }

		#endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>データセットプロパティ</summary>
        /// <value>データセットを取得します。</value>
        public DataSet BindDataSet
        {
            get { return this._bindDataSet; }
        }

        #endregion

		// --------------------------------------------------
		#region GetOnlineMode

		/// <summary>オンラインモード取得処理</summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードの取得を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// オンラインモードを取得
            if (this._iSuppRsltUpdDB == null)
            {
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
		#region Write Methods

		/// <summary>書き込み処理(買掛)</summary>
        /// <param name="suplAccPay">仕入先買掛金額マスタオブジェクト</param>
        /// <param name="aCalcPayTotalList">買掛支払集計データオブジェクトリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.14 >>>
        //public int WriteSuplAccPay(SuplAccPay suplAccPay, out string errMsg)
        public int WriteSuplAccPay(SuplAccPay suplAccPay, List<ACalcPayTotal> aCalcPayTotalList, out string errMsg)
        // 2009.01.14 <<<
        {
            // 仕入先買掛金額マスタ更新
            // 2009.01.14 >>>
            //return this.WriteSuplAccPayProc(suplAccPay, out errMsg);
            return this.WriteSuplAccPayProc(suplAccPay, aCalcPayTotalList, out errMsg);
            // 2009.01.14 <<<
        }

		/// <summary>仕入先買掛金額マスタ書き込み処理(買掛)</summary>
        /// <param name="suplAccPay">仕入先買掛金額マスタオブジェクト</param>
        /// <param name="aCalcPayTotalList">買掛支払集計データオブジェクトリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.14 >>>
        //private int WriteSuplAccPayProc(SuplAccPay suplAccPay, out string errMsg)
        private int WriteSuplAccPayProc(SuplAccPay suplAccPay, List<ACalcPayTotal> aCalcPayTotalList, out string errMsg)
        // 2009.01.14 <<<
		{
			int status = 0;
            errMsg     = "";

			try {
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                // 編集前情報取得
                if (this._custAccRecDic.ContainsKey(suplAccPay.FileHeaderGuid) == true)
                {
                    suplAccPayWork = (this._custAccRecDic[suplAccPay.FileHeaderGuid] as SuplAccPayWork);
                }

                // 編集情報取得
                //if ( suplAccPayWork.SupplierCd == suplAccPayWork.PayeeCode ) {
                //    suplAccPayWork.SupplierCd = 0;
                //}
                CopyToSuplAccPayWorkFromSuplAccPay(ref suplAccPayWork, suplAccPay);

                // 2009.01.14 >>>
                //object retObj = (object)suplAccPayWork;

                // 入金集計データの取得
                ArrayList aCalcPayTotalWorkArrayList = new ArrayList();

                foreach (ACalcPayTotal aCalcPayTotal in aCalcPayTotalList)
                {
                    ACalcPayTotalWork aCalcPayTotalWork = ParamDataFromUIData(aCalcPayTotal);
                    aCalcPayTotalWork.EnterpriseCode = suplAccPayWork.EnterpriseCode;     // 企業コード
                    aCalcPayTotalWork.AddUpSecCode = suplAccPayWork.AddUpSecCode;         // 計上拠点コード
                    aCalcPayTotalWork.PayeeCode = suplAccPayWork.PayeeCode;               // 支払先コード
                    aCalcPayTotalWork.SupplierCd = suplAccPayWork.PayeeCode;              // 仕入先コード（支払先をセット）
                    aCalcPayTotalWork.AddUpDate = suplAccPayWork.AddUpDate;               // 計上年月日
                    aCalcPayTotalWorkArrayList.Add(aCalcPayTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplAccPayWork);

                // --- CHG 2009/01/30 障害ID:10605対応------------------------------------------------------>>>>>
                //if (aCalcPayTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(aCalcPayTotalWorkArrayList);
                //}
                dataList.Add(aCalcPayTotalWorkArrayList);
                // --- CHG 2009/01/30 障害ID:10605対応------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.14 <<<

                //仕入先買掛金額マスタ書き込み
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                //status = this._iSuppRsltUpdDB.WriteAccPay(ref retObj, out errMsg);
                status = this._iSuppRsltUpdDB.WriteTotalAccPay(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // データセットに追加
                    // 2009.01.14 >>>
                    //suplAccPayWork = (SuplAccPayWork)retObj;
                    //this.SuplAccPayWorkToDataSet(suplAccPayWork);
                    aCalcPayTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0; i < retDataList.Count; i++)
                        {
                            if (retDataList[i] is SuplAccPayWork)
                            {
                                suplAccPayWork = (SuplAccPayWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                aCalcPayTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.SuplAccPayWorkToDataSet(suplAccPayWork, aCalcPayTotalWorkArrayList);

                    // 請求先指定の場合は集計レコードへ反映
                    if (suplAccPayWork.SupplierCd == 0)
                    {
                        this.SuplAccPayWorkTotalToDataSet(suplAccPayWork, aCalcPayTotalWorkArrayList);
                    }

                    // 2009.01.14 <<<
                }
			}
			catch(Exception) {
				// オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

        /// <summary>書き込み処理(支払)</summary>
        /// <param name="suplierPay">仕入先支払金額マスタオブジェクト</param>
        /// <param name="accPayTotalList">精算支払集計データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //public int WriteSuplierPay(SuplierPay suplierPay, out string errMsg)
        public int WriteSuplierPay(SuplierPay suplierPay, List<AccPayTotal> accPayTotalList, out string errMsg)
        // 2009.01.14 <<<
        {
            // 仕入先支払金額マスタ更新
            // 2009.01.14 >>>
            //return this.WriteSuplierPayProc(suplierPay, out errMsg);
            return this.WriteSuplierPayProc(suplierPay, accPayTotalList, out errMsg);
            // 2009.01.14 <<<
        }

        /// <summary>仕入先支払金額マスタ書き込み処理(買掛)</summary>
        /// <param name="suplierPay">仕入先支払金額マスタオブジェクト</param>
        /// <param name="accPayTotalList">精算支払集計データリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private int WriteSuplierPayProc(SuplierPay suplierPay, out string errMsg)
        private int WriteSuplierPayProc(SuplierPay suplierPay, List<AccPayTotal> accPayTotalList, out string errMsg)
        // 2009.01.14 <<<
        {
			int status = 0;
            errMsg     = "";

            try
            {
                SuplierPayWork suplierPayWork = new SuplierPayWork();

                // 編集前情報取得
                if (this._custDmdPrcDic.ContainsKey(suplierPay.FileHeaderGuid) == true)
                {
                    suplierPayWork = (this._custDmdPrcDic[suplierPay.FileHeaderGuid] as SuplierPayWork);
                }

                // 編集情報取得
                //if (suplierPayWork.SupplierCd == suplierPayWork.PayeeCode)
                //{
                //    suplierPayWork.SupplierCd = 0;
                //}
                CopyToSuplierPayWorkFromSuplierPay(ref suplierPayWork, suplierPay);

                // 2009.01.14 >>>
                //object retObj = (object)suplierPayWork;
                // 入金集計データの取得
                ArrayList accPayTotalWorkArrayList = new ArrayList();

                foreach (AccPayTotal accPayTotal in accPayTotalList)
                {
                    AccPayTotalWork accPayTotalWork = ParamDataFromUIData(accPayTotal);
                    accPayTotalWork.EnterpriseCode = suplierPayWork.EnterpriseCode;     // 企業コード
                    accPayTotalWork.AddUpSecCode = suplierPayWork.AddUpSecCode;         // 計上拠点コード
                    accPayTotalWork.PayeeCode = suplierPayWork.PayeeCode;               // 支払先コード
                    accPayTotalWork.SupplierCd = suplierPayWork.PayeeCode;              // 仕入先コード（支払先をセット）
                    accPayTotalWork.AddUpDate = suplierPayWork.AddUpDate;               // 計上年月日
                    accPayTotalWorkArrayList.Add(accPayTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplierPayWork);

                // --- ADD 2009/01/30 障害ID:10605対応------------------------------------------------------>>>>>
                //if (accPayTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(accPayTotalWorkArrayList);
                //}
                dataList.Add(accPayTotalWorkArrayList);
                // --- ADD 2009/01/30 障害ID:10605対応------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.14 <<<

                //仕入先支払金額マスタ書き込み
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                //status = this._iSuppRsltUpdDB.WriteSuplierPay(ref retObj, out errMsg);
                //System.Windows.Forms.MessageBox.Show(suplierPayWork.AddUpSecCode);
                status = this._iSuppRsltUpdDB.WriteTotalSuplierPay(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.14 >>>
                    //// データセットに追加
                    //suplierPayWork = (SuplierPayWork)retObj;
                    //this.SuplierPayWorkToDataSet(suplierPayWork);

                    accPayTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0; i < retDataList.Count; i++)
                        {
                            if (retDataList[i] is SuplierPayWork)
                            {
                                suplierPayWork = (SuplierPayWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                accPayTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.SuplierPayWorkToDataSet(suplierPayWork, accPayTotalWorkArrayList);

                    // 請求先指定の場合は集計レコードへ反映
                    if (suplierPayWork.SupplierCd == 0)
                    {
                        this.SuplierPayWorkTotalToDataSet(suplierPayWork, accPayTotalWorkArrayList);
                    }
                    // 2009.01.14 <<<
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Delete Methods

		/// <summary>物理削除処理</summary>
        /// <param name="suplAccPay">仕入先買掛金額マスタクラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int DeleteSuplAccPay(SuplAccPay suplAccPay)
        {
            // 仕入先買掛金額マスタ物理削除
            return this.DeleteSuplAccPayProc(suplAccPay);
        }

		/// <summary>仕入先買掛金額マスタ物理削除処理</summary>
        /// <param name="suplAccPay">仕入先買掛金額マスタクラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private int DeleteSuplAccPayProc(SuplAccPay suplAccPay)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                // 編集前情報取得
                if (this._custAccRecDic.ContainsKey(suplAccPay.FileHeaderGuid) == true)
                {
                    suplAccPayWork = (this._custAccRecDic[suplAccPay.FileHeaderGuid] as SuplAccPayWork);
                }

                CopyToSuplAccPayWorkFromSuplAccPay(ref suplAccPayWork, suplAccPay);

                // 2009.01.14 >>>
                //object paraObj = (object)suplAccPayWork;
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplAccPayWork);
                object paraObj = (object)dataList;
                // 2009.01.14 <<<

                // 仕入先買掛金額マスタ物理削除
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                //status = this._iSuppRsltUpdDB.DeleteAccPay(paraObj);
                status = this._iSuppRsltUpdDB.DeleteTotalAccPay(paraObj);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._custAccRecDic.Remove(suplAccPay.FileHeaderGuid);
                    // データテーブルから削除
                    object[] key = { suplAccPay.AddUpSecCode, suplAccPay.PayeeCode, suplAccPay.SupplierCd, TDateTime.DateTimeToLongDate(suplAccPay.AddUpDate) };
                    DataRow dr = this._custAccRecTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        /// <summary>物理削除処理</summary>
        /// <param name="suplierPay">仕入先支払金額</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int DeleteSuplierPay(SuplierPay suplierPay)
        {
            // 仕入先支払金額マスタ物理削除
            return this.DeleteSuplierPayProc(suplierPay);
        }

        /// <summary>仕入先支払金額マスタ物理削除処理</summary>
        /// <param name="suplierPay">仕入先支払金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int DeleteSuplierPayProc(SuplierPay suplierPay)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                SuplierPayWork suplierPayWork = new SuplierPayWork();

                // 編集前情報取得
                if (this._custDmdPrcDic.ContainsKey(suplierPay.FileHeaderGuid) == true)
                {
                    suplierPayWork = (this._custDmdPrcDic[suplierPay.FileHeaderGuid] as SuplierPayWork);
                }

                CopyToSuplierPayWorkFromSuplierPay(ref suplierPayWork, suplierPay);

                // 仕入先支払金額マスタ物理削除
                // 2009.01.14 >>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                ////status = this._iSuppRsltUpdDB.DeleteSuplierPay(suplierPayWork);
                //status = this._iSuppRsltUpdDB.DeleteTotalSuplierPay(suplierPayWork);
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END

                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplierPayWork);
                object paraObj = (object)dataList;
                status = this._iSuppRsltUpdDB.DeleteTotalSuplierPay(paraObj);
                // 2009.01.14 <<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._custDmdPrcDic.Remove(suplierPay.FileHeaderGuid);
                    // データテーブルから削除
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                    // ResultSectCdがキーに増えたため追加
                    object[] key = { suplierPay.AddUpSecCode, suplierPay.PayeeCode, suplierPay.SupplierCd, suplierPay.ResultsSectCd, TDateTime.DateTimeToLongDate(suplierPay.AddUpDate) };
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                    DataRow dr = this._custDmdPrcTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception ex)
            {

                // オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Search Methods

		/// <summary>検索処理(論理削除除く)(買掛)</summary>
        /// <param name="totalCount">取得件数</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int SearchSuplAccPay(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 customerCode)
        {
            // 仕入先買掛金額マスタ検索
            return this.SearchSuplAccPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, customerCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>検索処理(論理削除含む)(買掛)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int SearchSuplAccPayAll(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 customerCode)
        {
            // 仕入先買掛金額マスタ検索
            return this.SearchSuplAccPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, customerCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>検索処理(買掛)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int SearchSuplAccPayProc(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 supplierCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // 仕入先買掛金額マスタ検索
            status1 = this.SearchSuplAccPayProc2(out totalCount, enterpriseCode, sectionCode, payeeCode, supplierCd, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // キャッシュ処理
            // 2009.01.14 >>>
            //status2 = this.CacheSuplAccPay(this._custAccRecList);
            status2 = this.CacheSuplAccPay(this._custAccRecList, sectionCode, payeeCode, supplierCd);
            // 2009.01.14 <<<
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>仕入先買掛金額マスタ検索処理(買掛)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタの検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private int SearchSuplAccPayProc2(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._custAccRecList.Clear();

                // キャッシュ用テーブルをクリア
                this._custAccRecDic.Clear();

                object retobj = null;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA DEL START
                // データの管理は親子に変更されたためこの部分は不要
                // 仕入先買掛金額マスタ検索
                //if ( customerCode == payeeCode ) {
                //    customerCode = 0;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA DEL END

                status = this._iSuppRsltUpdDB.SearchAccPay(enterpriseCode,sectionCode,payeeCode,customerCode,0,out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.14 >>>
                    //this._custAccRecList = retobj as ArrayList;
                    this._custAccRecList = retobj as CustomSerializeArrayList;
                    // 2009.01.14 <<<

                    // 該当件数格納
                    totalCount = this._custAccRecList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        /// <summary>検索処理(論理削除除く)(支払)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>-------------------------</br>
        /// <br>Note       : 引数に実績拠点コードを追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        public int SearchSuplierPay(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 supplierCode)
        {
            // 仕入先支払金額マスタ検索
            return this.SearchSuplierPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, resultSectCode, supplierCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>検索処理(論理削除含む)(支払)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="payeeCode">仕入先コード</param>
        /// <param name="resultSectCode">実績拠点コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>-------------------------</br>
        /// <br>Note       : 引数に実績拠点コードを追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        public int SearchSuplierPayAll(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 supplierCode)
        {
            // 仕入先支払金額マスタ検索
            return this.SearchSuplierPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, resultSectCode, supplierCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>検索処理(支払)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="resultSectCode">実績拠点コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>-------------------------</br>
        /// <br>Note       : 引数に実績拠点コードを追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private int SearchSuplierPayProc(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 supplierCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // 仕入先支払金額マスタ検索
            status1 = this.SearchSuplierPayProc2(out totalCount, enterpriseCode, sectionCode, payeeCode, resultSectCode, supplierCd, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // キャッシュ処理
            // 2009.01.14 >>>
            //status2 = this.CacheSuplierPay(this._custDmdPrcList);
            status2 = this.CacheSuplierPay(this._custDmdPrcList, sectionCode, resultSectCode, payeeCode, supplierCd);
            // 2009.01.14 <<<
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>仕入先支払金額マスタ検索処理</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="payeeCode">仕入先コード</param>
        /// <param name="resultSectCode">実績拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタの検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.03.08</br>
        /// <br>-------------------------</br>
        /// <br>Note       : 引数に実績拠点コードを追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private int SearchSuplierPayProc2(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // 取得リスト初期化
                this._custDmdPrcList.Clear();

                // キャッシュ用テーブルをクリア
                this._custDmdPrcDic.Clear();

                object retobj = null;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA DEL START
                // データの管理が親子更新に変わったた不要
                // 仕入先支払金額マスタ検索
                //if ( customerCode == payeeCode ) {
                //    customerCode = 0;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA DEL END
                status = this._iSuppRsltUpdDB.SearchSuplierPay(enterpriseCode, sectionCode, payeeCode, resultSectCode, customerCode, 0, out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.14 >>>
                    //this._custDmdPrcList = retobj as ArrayList;
                    this._custDmdPrcList = retobj as CustomSerializeArrayList;
                    // 2009.01.14 <<<

                    // 該当件数格納
                    totalCount = this._custDmdPrcList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSuppRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>マスタキャッシュ処理(買掛)</summary>
        /// <param name="custAccRecList">仕入先買掛金額マスタ取得結果リスト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //public int CacheSuplAccPay(ArrayList custAccRecList)
        public int CacheSuplAccPay(ArrayList custAccRecList, string sectionCode, Int32 payeeCode, Int32 supplierCd)
        // 2009.01.14 <<<
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._custAccRecTable.BeginLoadData();
                    this._custAccRecTotalTable.BeginLoadData(); // 2009.01.14 Add

                    // テーブルをクリア
                    this._custAccRecTable.Clear();
                    this._custAccRecTotalTable.Clear(); // 2009.01.14 Add

                    // 2009.01.14 >>>
                    //// 仕入先買掛金額マスタデータをDataSetに格納
                    //foreach (SuplAccPayWork suplAccPayWork in custAccRecList)
                    //{
                    //    // 未登録の時
                    //    if (this._custAccRecDic.ContainsKey(suplAccPayWork.FileHeaderGuid) == false)
                    //    {
                    //        // データセットに追加
                    //        this.SuplAccPayWorkToDataSet(suplAccPayWork);
                    //    }
                    //}

                    for (int i = 0; i < custAccRecList.Count; i++)
                    {
                        if (custAccRecList[i] is ArrayList)
                        {
                            ArrayList accDataArrayList = (ArrayList)custAccRecList[i];

                            SuplAccPayWork suplAccPayWork = null;
                            SuplAccPayWork suplAccPayWorkTotal = null;
                            ArrayList aCalcPayTotalWorkArrayList = null;

                            for (int n = 0; n < accDataArrayList.Count; n++)
                            {
                                if (accDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)accDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is SuplAccPayWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (SuplAccPayWork suplAccPayWorkWk in data)
                                                {
                                                    if (suplAccPayWorkWk.SupplierCd == 0)
                                                    {
                                                        suplAccPayWorkTotal = suplAccPayWorkWk;
                                                    }

                                                    if (( suplAccPayWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( suplAccPayWorkWk.PayeeCode == payeeCode ) &&
                                                        ( suplAccPayWorkWk.SupplierCd == supplierCd ))
                                                    {
                                                        suplAccPayWork = suplAccPayWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is ACalcPayTotalWork)
                                        {
                                            // 入金データのリスト
                                            aCalcPayTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }
                            // 集計レコードとパラメータが合わない可能性がある(拠点)ので念のため
                            if (( supplierCd == 0 ) && ( suplAccPayWorkTotal != null ))
                            {
                                if (suplAccPayWork == null) suplAccPayWork = suplAccPayWorkTotal;
                            }
                            if (suplAccPayWork != null)
                            {
                                // 未登録の時
                                if (this._custAccRecDic.ContainsKey(suplAccPayWork.FileHeaderGuid) == false)
                                {
                                    // データセットに追加
                                    this.SuplAccPayWorkToDataSet(suplAccPayWork, ( suplAccPayWork.SupplierCd == 0 ) ? aCalcPayTotalWorkArrayList : null);
                                }
                            }
                            if (suplAccPayWorkTotal != null)
                            {
                                this.SuplAccPayWorkTotalToDataSet(suplAccPayWorkTotal, aCalcPayTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.14 <<<
                }
                finally
                {
                    // 更新処理終了
                    this._custAccRecTable.EndLoadData();
                    this._custAccRecTotalTable.EndLoadData();   // 2009.01.14 Add
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>マスタキャッシュ処理(支払)</summary>
        /// <param name="custDmdPrcList">仕入先支払金額マスタ取得結果リスト</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="resultSecCode">実績計上拠点コード</param>
        /// <param name="payeeCode">支払先コード</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //public int CacheSuplierPay(ArrayList custDmdPrcList)
        public int CacheSuplierPay(ArrayList custDmdPrcList, string sectionCode, string resultSecCode, Int32 payeeCode, Int32 supplierCd)
        //string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode
        // 2009.01.14 <<<
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._custDmdPrcTable.BeginLoadData();
                    this._custDmdPrcTotalTable.BeginLoadData(); // 2009.01.14 Add

                    // テーブルをクリア
                    this._custDmdPrcTable.Clear();
                    this._custDmdPrcTotalTable.Clear();     // 2009.01.14 Add

                    // 2009.01.14 >>>
                    //// 仕入先支払金額マスタデータをDataSetに格納
                    //foreach (SuplierPayWork suplierPayWork in custDmdPrcList)
                    //{
                    //    // 未登録の時
                    //    if (this._custDmdPrcDic.ContainsKey(suplierPayWork.FileHeaderGuid) == false)
                    //    {
                    //        // データセットに追加
                    //        this.SuplierPayWorkToDataSet(suplierPayWork);
                    //    }
                    //}

                    for (int i = 0; i < custDmdPrcList.Count; i++)
                    {
                        if (custDmdPrcList[i] is ArrayList)
                        {
                            ArrayList dmdDataArrayList = (ArrayList)custDmdPrcList[i];

                            SuplierPayWork suplierPayWork = null;
                            SuplierPayWork suplierPayWorkTotal = null;
                            ArrayList accPayTotalWorkArrayList = null;

                            for (int n = 0; n < dmdDataArrayList.Count; n++)
                            {
                                if (dmdDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)dmdDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is SuplierPayWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (SuplierPayWork suplierPayWorkWk in data)
                                                {
                                                    if (( suplierPayWorkWk.ResultsSectCd.Trim() == ALL_SECTION ) && ( suplierPayWorkWk.SupplierCd == 0 ))
                                                    {
                                                        suplierPayWorkTotal = suplierPayWorkWk;
                                                    }

                                                    if (( suplierPayWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( suplierPayWorkWk.ResultsSectCd.Trim() == resultSecCode.Trim() ) &&
                                                        ( suplierPayWorkWk.PayeeCode == payeeCode ) &&
                                                        ( suplierPayWorkWk.SupplierCd == supplierCd ))
                                                    {
                                                        suplierPayWork = suplierPayWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is AccPayTotalWork)
                                        {
                                            // 入金データのリスト
                                            accPayTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }

                            // 集計レコードとパラメータが合わない可能性がある(拠点)ので念のため
                            if (( supplierCd == 0 ) && ( suplierPayWorkTotal != null ))
                            {
                                if (suplierPayWork == null) suplierPayWork = suplierPayWorkTotal;
                            }
                            if (suplierPayWork != null)
                            {
                                // 未登録の時
                                if (this._custDmdPrcDic.ContainsKey(suplierPayWork.FileHeaderGuid) == false)
                                {
                                    // データセットに追加
                                    this.SuplierPayWorkToDataSet(suplierPayWork, ( suplierPayWork.SupplierCd == 0 ) ? accPayTotalWorkArrayList : null);
                                }
                            }
                            if (suplierPayWorkTotal != null)
                            {
                                this.SuplierPayWorkTotalToDataSet(suplierPayWorkTotal, accPayTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.14 <<<
                }
                finally
                {
                    // 更新処理終了
                    this._custDmdPrcTable.EndLoadData();
                    this._custDmdPrcTotalTable.EndLoadData();   // 2009.01.14 Add
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

        /// <summary>クラスメンバコピー処理 (画面変更仕入先買掛金額マスタクラス⇒仕入先買掛金額マスタワーククラス)</summary>
        /// <param name="suplAccPayWork">仕入先買掛金額マスタワーククラス</param>
        /// <param name="suplAccPay">仕入先買掛金額マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更仕入先買掛金額マスタクラスから
        ///                  仕入先買掛金額マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToSuplAccPayWorkFromSuplAccPay(ref SuplAccPayWork suplAccPayWork, SuplAccPay suplAccPay)
        {
            # region // 削除
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPayWork.EnterpriseCode       = suplAccPay.EnterpriseCode;
            //suplAccPayWork.AddUpSecCode         = suplAccPay.AddUpSecCode;
            //suplAccPayWork.CustomerCode         = suplAccPay.CustomerCode;
            //suplAccPayWork.CustomerName         = suplAccPay.CustomerName;
            //suplAccPayWork.CustomerName2        = suplAccPay.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPayWork.CustomerSnm          = suplAccPay.CustomerSnm;
            //suplAccPayWork.PayeeCode            = suplAccPay.PayeeCode;
            //suplAccPayWork.PayeeName            = suplAccPay.PayeeName;
            //suplAccPayWork.PayeeName2           = suplAccPay.PayeeName2;
            //suplAccPayWork.PayeeSnm             = suplAccPay.PayeeSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.AddUpDate            = TDateTime.LongDateToDateTime(suplAccPay.AddUpDate);
            ////suplAccPayWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(suplAccPay.AddUpYearMonth);
            //suplAccPayWork.AddUpDate = suplAccPay.AddUpDate;
            //suplAccPayWork.AddUpYearMonth = suplAccPay.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.LastTimeAccPay       = suplAccPay.LastTimeAccPay;
            //suplAccPayWork.ThisTimePayNrml      = suplAccPay.ThisTimePayNrml;
            //suplAccPayWork.ThisTimeFeePayNrml   = suplAccPay.ThisTimeFeePayNrml;
            //suplAccPayWork.ThisTimeDisPayNrml   = suplAccPay.ThisTimeDisPayNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.ThisTimeRbtDmdNrml   = suplAccPay.ThisTimeRbtDmdNrml;
            ////suplAccPayWork.ThisTimeDmdDepo      = suplAccPay.ThisTimeDmdDepo;
            ////suplAccPayWork.ThisTimeFeeDmdDepo   = suplAccPay.ThisTimeFeeDmdDepo;
            ////suplAccPayWork.ThisTimeDisDmdDepo   = suplAccPay.ThisTimeDisDmdDepo;
            ////suplAccPayWork.ThisTimeRbtDmdDepo   = suplAccPay.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.ThisTimeTtlBlcAcPay    = suplAccPay.ThisTimeTtlBlcAcPay;
            //suplAccPayWork.ThisTimeStockPrice        = suplAccPay.ThisTimeStockPrice;
            //suplAccPayWork.ThisStcPrcTax         = suplAccPay.ThisStcPrcTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.TtlIncDtbtTaxExc     = suplAccPay.TtlIncDtbtTaxExc;
            ////suplAccPayWork.TtlIncDtbtTax        = suplAccPay.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.ThisNetStckPrice     = suplAccPay.ThisNetStckPrice;
            //suplAccPayWork.ThisNetStcPrcTax      = suplAccPay.ThisNetStcPrcTax;
            //suplAccPayWork.ItdedOffsetOutTax    = suplAccPay.ItdedOffsetOutTax;
            //suplAccPayWork.ItdedOffsetInTax     = suplAccPay.ItdedOffsetInTax;
            //suplAccPayWork.ItdedOffsetTaxFree   = suplAccPay.ItdedOffsetTaxFree;
            //suplAccPayWork.OffsetOutTax         = suplAccPay.OffsetOutTax;
            //suplAccPayWork.OffsetInTax          = suplAccPay.OffsetInTax;
            //suplAccPayWork.TtlItdedStcOutTax = suplAccPay.TtlItdedStcOutTax;
            //suplAccPayWork.TtlItdedStcInTax = suplAccPay.TtlItdedStcInTax;
            //suplAccPayWork.TtlItdedStcTaxFree = suplAccPay.TtlItdedStcTaxFree;
            //suplAccPayWork.TtlStockOuterTax = suplAccPay.TtlStockOuterTax;
            //suplAccPayWork.TtlStockInnerTax = suplAccPay.TtlStockInnerTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.ItdedPaymOutTax      = suplAccPay.ItdedPaymOutTax;
            ////suplAccPayWork.ItdedPaymInTax       = suplAccPay.ItdedPaymInTax;
            ////suplAccPayWork.ItdedPaymTaxFree     = suplAccPay.ItdedPaymTaxFree;
            ////suplAccPayWork.PaymentOutTax        = suplAccPay.PaymentOutTax;
            ////suplAccPayWork.PaymentInTax         = suplAccPay.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPayWork.TtlItdedRetOutTax    = suplAccPay.TtlItdedRetOutTax;
            //suplAccPayWork.TtlItdedRetInTax     = suplAccPay.TtlItdedRetInTax;
            //suplAccPayWork.TtlItdedRetTaxFree   = suplAccPay.TtlItdedRetTaxFree;
            //suplAccPayWork.TtlRetOuterTax       = suplAccPay.TtlRetOuterTax;
            //suplAccPayWork.TtlRetInnerTax       = suplAccPay.TtlRetInnerTax;
            //suplAccPayWork.TtlItdedDisOutTax    = suplAccPay.TtlItdedDisOutTax;
            //suplAccPayWork.TtlItdedDisInTax     = suplAccPay.TtlItdedDisInTax;
            //suplAccPayWork.TtlItdedDisTaxFree   = suplAccPay.TtlItdedDisTaxFree;
            //suplAccPayWork.TtlDisOuterTax       = suplAccPay.TtlDisOuterTax;
            //suplAccPayWork.TtlDisInnerTax       = suplAccPay.TtlDisInnerTax;
            //suplAccPayWork.BalanceAdjust        = suplAccPay.BalanceAdjust;
            //suplAccPayWork.ThisCashStockPrice    = suplAccPay.ThisCashStockPrice;
            //suplAccPayWork.ThisCashStockTax      = suplAccPay.ThisCashStockTax;
            //suplAccPayWork.ThisStckPricRgds    = suplAccPay.ThisStckPricRgds;
            //suplAccPayWork.ThisStckPricDis     = suplAccPay.ThisStckPricDis;
            //suplAccPayWork.ThisStcPrcTaxRgds  = suplAccPay.ThisStcPrcTaxRgds;
            //suplAccPayWork.ThisStcPrcTaxDis   = suplAccPay.ThisStcPrcTaxDis;
            //suplAccPayWork.NonStmntAppearance   = suplAccPay.NonStmntAppearance;
            //suplAccPayWork.NonStmntIsdone       = suplAccPay.NonStmntIsdone;
            //suplAccPayWork.StmntAppearance      = suplAccPay.StmntAppearance;
            //suplAccPayWork.StmntIsdone          = suplAccPay.StmntIsdone;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.SuppCTaxLayCd     = suplAccPay.SuppCTaxLayCd;
            //suplAccPayWork.SupplierConsTaxRate          = suplAccPay.SupplierConsTaxRate;
            //suplAccPayWork.FractionProcCd       = suplAccPay.FractionProcCd;
            //suplAccPayWork.StckTtlAccPayBalance    = suplAccPay.StckTtlAccPayBalance;
            //suplAccPayWork.StckTtl2TmBfBlAccPay = suplAccPay.StckTtl2TmBfBlAccPay;
            //suplAccPayWork.StckTtl3TmBfBlAccPay = suplAccPay.StckTtl3TmBfBlAccPay;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.MonthAddUpExpDate    = TDateTime.LongDateToDateTime(suplAccPay.MonthAddUpExpDate);
            //suplAccPayWork.MonthAddUpExpDate = suplAccPay.MonthAddUpExpDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplAccPayWork.CreateDateTime = suplAccPay.CreateDateTime; // 作成日時
            suplAccPayWork.UpdateDateTime = suplAccPay.UpdateDateTime; // 更新日時
            suplAccPayWork.EnterpriseCode = suplAccPay.EnterpriseCode; // 企業コード
            suplAccPayWork.FileHeaderGuid = suplAccPay.FileHeaderGuid; // GUID
            suplAccPayWork.UpdEmployeeCode = suplAccPay.UpdEmployeeCode; // 更新従業員コード
            suplAccPayWork.UpdAssemblyId1 = suplAccPay.UpdAssemblyId1; // 更新アセンブリID1
            suplAccPayWork.UpdAssemblyId2 = suplAccPay.UpdAssemblyId2; // 更新アセンブリID2
            suplAccPayWork.LogicalDeleteCode = suplAccPay.LogicalDeleteCode; // 論理削除区分
            suplAccPayWork.AddUpSecCode = suplAccPay.AddUpSecCode; // 計上拠点コード
            suplAccPayWork.PayeeCode = suplAccPay.PayeeCode; // 支払先コード
            suplAccPayWork.PayeeName = suplAccPay.PayeeName; // 支払先名称
            suplAccPayWork.PayeeName2 = suplAccPay.PayeeName2; // 支払先名称2
            suplAccPayWork.PayeeSnm = suplAccPay.PayeeSnm; // 支払先略称
            suplAccPayWork.SupplierCd = suplAccPay.SupplierCd; // 得意先コード
            suplAccPayWork.SupplierNm1 = suplAccPay.SupplierNm1; // 得意先名称
            suplAccPayWork.SupplierNm2 = suplAccPay.SupplierNm2; // 得意先名称2
            suplAccPayWork.SupplierSnm = suplAccPay.SupplierSnm; // 得意先略称
            suplAccPayWork.AddUpDate = suplAccPay.AddUpDate; // 計上年月日
            suplAccPayWork.AddUpYearMonth = suplAccPay.AddUpYearMonth; // 計上年月
            suplAccPayWork.LastTimeAccPay = suplAccPay.LastTimeAccPay; // 前回買掛金額
            suplAccPayWork.ThisTimeFeePayNrml = suplAccPay.ThisTimeFeePayNrml; // 今回手数料額（通常支払）
            suplAccPayWork.ThisTimeDisPayNrml = suplAccPay.ThisTimeDisPayNrml; // 今回値引額（通常支払）
            suplAccPayWork.ThisTimePayNrml = suplAccPay.ThisTimePayNrml; // 今回支払金額（通常支払）
            suplAccPayWork.ThisTimeTtlBlcAcPay = suplAccPay.ThisTimeTtlBlcAcPay; // 今回繰越残高（買掛計）
            suplAccPayWork.OfsThisTimeStock = suplAccPay.OfsThisTimeStock; // 相殺後今回仕入金額
            suplAccPayWork.OfsThisStockTax = suplAccPay.OfsThisStockTax; // 相殺後今回仕入消費税
            suplAccPayWork.ItdedOffsetOutTax = suplAccPay.ItdedOffsetOutTax; // 相殺後外税対象額
            suplAccPayWork.ItdedOffsetInTax = suplAccPay.ItdedOffsetInTax; // 相殺後内税対象額
            suplAccPayWork.ItdedOffsetTaxFree = suplAccPay.ItdedOffsetTaxFree; // 相殺後非課税対象額
            suplAccPayWork.OffsetOutTax = suplAccPay.OffsetOutTax; // 相殺後外税消費税
            suplAccPayWork.OffsetInTax = suplAccPay.OffsetInTax; // 相殺後内税消費税
            suplAccPayWork.ThisTimeStockPrice = suplAccPay.ThisTimeStockPrice; // 今回仕入金額
            suplAccPayWork.ThisStcPrcTax = suplAccPay.ThisStcPrcTax; // 今回仕入消費税
            suplAccPayWork.TtlItdedStcOutTax = suplAccPay.TtlItdedStcOutTax; // 仕入外税対象額合計
            suplAccPayWork.TtlItdedStcInTax = suplAccPay.TtlItdedStcInTax; // 仕入内税対象額合計
            suplAccPayWork.TtlItdedStcTaxFree = suplAccPay.TtlItdedStcTaxFree; // 仕入非課税対象額合計
            suplAccPayWork.TtlStockOuterTax = suplAccPay.TtlStockOuterTax; // 仕入外税額合計
            suplAccPayWork.TtlStockInnerTax = suplAccPay.TtlStockInnerTax; // 仕入内税額合計
            suplAccPayWork.ThisStckPricRgds = suplAccPay.ThisStckPricRgds; // 今回返品金額
            suplAccPayWork.ThisStcPrcTaxRgds = suplAccPay.ThisStcPrcTaxRgds; // 今回返品消費税
            suplAccPayWork.TtlItdedRetOutTax = suplAccPay.TtlItdedRetOutTax; // 返品外税対象額合計
            suplAccPayWork.TtlItdedRetInTax = suplAccPay.TtlItdedRetInTax; // 返品内税対象額合計
            suplAccPayWork.TtlItdedRetTaxFree = suplAccPay.TtlItdedRetTaxFree; // 返品非課税対象額合計
            suplAccPayWork.TtlRetOuterTax = suplAccPay.TtlRetOuterTax; // 返品外税額合計
            suplAccPayWork.TtlRetInnerTax = suplAccPay.TtlRetInnerTax; // 返品内税額合計
            suplAccPayWork.ThisStckPricDis = suplAccPay.ThisStckPricDis; // 今回値引金額
            suplAccPayWork.ThisStcPrcTaxDis = suplAccPay.ThisStcPrcTaxDis; // 今回値引消費税
            suplAccPayWork.TtlItdedDisOutTax = suplAccPay.TtlItdedDisOutTax; // 値引外税対象額合計
            suplAccPayWork.TtlItdedDisInTax = suplAccPay.TtlItdedDisInTax; // 値引内税対象額合計
            suplAccPayWork.TtlItdedDisTaxFree = suplAccPay.TtlItdedDisTaxFree; // 値引非課税対象額合計
            suplAccPayWork.TtlDisOuterTax = suplAccPay.TtlDisOuterTax; // 値引外税額合計
            suplAccPayWork.TtlDisInnerTax = suplAccPay.TtlDisInnerTax; // 値引内税額合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //suplAccPayWork.ThisRecvOffset = suplAccPay.ThisRecvOffset; // 今回受取金額
            //suplAccPayWork.ThisRecvOffsetTax = suplAccPay.ThisRecvOffsetTax; // 今回受取相殺消費税
            //suplAccPayWork.ThisRecvOutTax = suplAccPay.ThisRecvOutTax; // 今回受取外税対象額合計
            //suplAccPayWork.ThisRecvInTax = suplAccPay.ThisRecvInTax; // 今回受取内税対象額合計
            //suplAccPayWork.ThisRecvTaxFree = suplAccPay.ThisRecvTaxFree; // 今回受取非課税対象額合計
            //suplAccPayWork.ThisRecvOuterTax = suplAccPay.ThisRecvOuterTax; // 今回受取外税額合計
            //suplAccPayWork.ThisRecvInnerTax = suplAccPay.ThisRecvInnerTax; // 今回受取内税額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            suplAccPayWork.TaxAdjust = suplAccPay.TaxAdjust; // 消費税調整額
            suplAccPayWork.BalanceAdjust = suplAccPay.BalanceAdjust; // 残高調整額
            //suplAccPayWork.StckTtlAccPayBalance = suplAccPay.StckTtlAccPayBalance - suplAccPay.BalanceAdjust - suplAccPay.TaxAdjust; // 仕入合計残高（買掛計）
            suplAccPayWork.StckTtlAccPayBalance = suplAccPay.StckTtlAccPayBalance; // 仕入合計残高（買掛計）
            suplAccPayWork.StckTtl2TmBfBlAccPay = suplAccPay.StckTtl2TmBfBlAccPay; // 仕入2回前残高（買掛計）
            suplAccPayWork.StckTtl3TmBfBlAccPay = suplAccPay.StckTtl3TmBfBlAccPay; // 仕入3回前残高（買掛計）
            suplAccPayWork.MonthAddUpExpDate = suplAccPay.MonthAddUpExpDate; // 月次更新実行年月日
            suplAccPayWork.StMonCAddUpUpdDate = suplAccPay.StMonCAddUpUpdDate; // 月次更新開始年月日
            suplAccPayWork.LaMonCAddUpUpdDate = suplAccPay.LaMonCAddUpUpdDate; // 前回月次更新年月日
            suplAccPayWork.StockSlipCount = suplAccPay.StockSlipCount; // 仕入伝票枚数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //suplAccPayWork.NonStmntAppearance = suplAccPay.NonStmntAppearance; // 未決済金額（自振）
            //suplAccPayWork.NonStmntIsdone = suplAccPay.NonStmntIsdone; // 未決済金額（廻し）
            //suplAccPayWork.StmntAppearance = suplAccPay.StmntAppearance; // 決済金額（自振）
            //suplAccPayWork.StmntIsdone = suplAccPay.StmntIsdone; // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END            suplAccPayWork.SuppCTaxLayCd = suplAccPay.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            suplAccPayWork.SupplierConsTaxRate = suplAccPay.SupplierConsTaxRate; // 仕入先消費税税率
            suplAccPayWork.FractionProcCd = suplAccPay.FractionProcCd; // 端数処理区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //if (suplAccPayWork.SupplierCd == suplAccPayWork.PayeeCode)
            //{
            //    suplAccPayWork.SupplierCd = 0;
            //}
        }

        /// <summary>クラスメンバコピー処理 (画面変更仕入先支払金額マスタクラス⇒仕入先支払金額マスタワーククラス)</summary>
        /// <param name="suplierPayWork">仕入先支払金額マスタワーククラス</param>
        /// <param name="suplierPay">仕入先支払金額マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更仕入先支払金額マスタクラスから
        ///                  仕入先支払金額マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToSuplierPayWorkFromSuplierPay(ref SuplierPayWork suplierPayWork, SuplierPay suplierPay)
        {
            # region // 削除
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPayWork.EnterpriseCode       = suplierPay.EnterpriseCode;
            //suplierPayWork.AddUpSecCode         = suplierPay.AddUpSecCode;
            //suplierPayWork.CustomerCode         = suplierPay.CustomerCode;
            //suplierPayWork.CustomerName         = suplierPay.CustomerName;
            //suplierPayWork.CustomerName2        = suplierPay.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPayWork.CustomerSnm          = suplierPay.CustomerSnm;
            //suplierPayWork.PayeeCode            = suplierPay.PayeeCode;
            //suplierPayWork.PayeeName            = suplierPay.PayeeName;
            //suplierPayWork.PayeeName2           = suplierPay.PayeeName2;
            //suplierPayWork.PayeeSnm             = suplierPay.PayeeSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.AddUpDate            = TDateTime.LongDateToDateTime(suplierPay.AddUpDate);
            ////suplierPayWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(suplierPay.AddUpYearMonth);
            //suplierPayWork.AddUpDate = suplierPay.AddUpDate;
            //suplierPayWork.AddUpYearMonth = suplierPay.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.LastTimePayment       = suplierPay.LastTimePayment;
            //suplierPayWork.ThisTimePayNrml      = suplierPay.ThisTimePayNrml;
            //suplierPayWork.ThisTimeFeePayNrml   = suplierPay.ThisTimeFeePayNrml;
            //suplierPayWork.ThisTimeDisPayNrml   = suplierPay.ThisTimeDisPayNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.ThisTimeRbtDmdNrml   = suplierPay.ThisTimeRbtDmdNrml;
            ////suplierPayWork.ThisTimeDmdDepo      = suplierPay.ThisTimeDmdDepo;
            ////suplierPayWork.ThisTimeFeeDmdDepo   = suplierPay.ThisTimeFeeDmdDepo;
            ////suplierPayWork.ThisTimeDisDmdDepo   = suplierPay.ThisTimeDisDmdDepo;
            ////suplierPayWork.ThisTimeRbtDmdDepo   = suplierPay.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.ThisTimeTtlBlcPay    = suplierPay.ThisTimeTtlBlcPay;
            //suplierPayWork.ThisTimeStockPrice        = suplierPay.ThisTimeStockPrice;
            //suplierPayWork.ThisStcPrcTax         = suplierPay.ThisStcPrcTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.TtlIncDtbtTaxExc     = suplierPay.TtlIncDtbtTaxExc;
            ////suplierPayWork.TtlIncDtbtTax        = suplierPay.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.ThisNetStckPrice     = suplierPay.ThisNetStckPrice;
            //suplierPayWork.ThisNetStcPrcTax      = suplierPay.ThisNetStcPrcTax;
            //suplierPayWork.ItdedOffsetOutTax    = suplierPay.ItdedOffsetOutTax;
            //suplierPayWork.ItdedOffsetInTax     = suplierPay.ItdedOffsetInTax;
            //suplierPayWork.ItdedOffsetTaxFree   = suplierPay.ItdedOffsetTaxFree;
            //suplierPayWork.OffsetOutTax         = suplierPay.OffsetOutTax;
            //suplierPayWork.OffsetInTax          = suplierPay.OffsetInTax;
            //suplierPayWork.TtlItdedStcOutTax     = suplierPay.TtlItdedStcOutTax;
            //suplierPayWork.TtlItdedStcInTax      = suplierPay.TtlItdedStcInTax;
            //suplierPayWork.TtlItdedStcTaxFree    = suplierPay.TtlItdedStcTaxFree;
            //suplierPayWork.TtlStockOuterTax          = suplierPay.TtlStockOuterTax;
            //suplierPayWork.TtlStockInnerTax           = suplierPay.TtlStockInnerTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.ItdedPaymOutTax      = suplierPay.ItdedPaymOutTax;
            ////suplierPayWork.ItdedPaymInTax       = suplierPay.ItdedPaymInTax;
            ////suplierPayWork.ItdedPaymTaxFree     = suplierPay.ItdedPaymTaxFree;
            ////suplierPayWork.PaymentOutTax        = suplierPay.PaymentOutTax;
            ////suplierPayWork.PaymentInTax         = suplierPay.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPayWork.TtlItdedRetOutTax    = suplierPay.TtlItdedRetOutTax;
            //suplierPayWork.TtlItdedRetInTax     = suplierPay.TtlItdedRetInTax;
            //suplierPayWork.TtlItdedRetTaxFree   = suplierPay.TtlItdedRetTaxFree;
            //suplierPayWork.TtlRetOuterTax       = suplierPay.TtlRetOuterTax;
            //suplierPayWork.TtlRetInnerTax       = suplierPay.TtlRetInnerTax;
            //suplierPayWork.TtlItdedDisOutTax    = suplierPay.TtlItdedDisOutTax;
            //suplierPayWork.TtlItdedDisInTax     = suplierPay.TtlItdedDisInTax;
            //suplierPayWork.TtlItdedDisTaxFree   = suplierPay.TtlItdedDisTaxFree;
            //suplierPayWork.TtlDisOuterTax       = suplierPay.TtlDisOuterTax;
            //suplierPayWork.TtlDisInnerTax       = suplierPay.TtlDisInnerTax;
            //suplierPayWork.BalanceAdjust        = suplierPay.BalanceAdjust;
            //suplierPayWork.ThisStckPricRgds    = suplierPay.ThisStckPricRgds;
            //suplierPayWork.ThisStckPricDis     = suplierPay.ThisStckPricDis;
            //suplierPayWork.ThisStcPrcTaxRgds  = suplierPay.ThisStcPrcTaxRgds;
            //suplierPayWork.ThisStcPrcTaxDis   = suplierPay.ThisStcPrcTaxDis;
            //suplierPayWork.StockSlipCount      = suplierPay.StockSlipCount;
            //suplierPayWork.PaymentSchedule  = suplierPay.PaymentSchedule;
            //suplierPayWork.PaymentCond          = suplierPay.PaymentCond;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.SuppCTaxLayCd     = suplierPay.SuppCTaxLayCd;
            //suplierPayWork.SupplierConsTaxRate          = suplierPay.SupplierConsTaxRate;
            //suplierPayWork.FractionProcCd       = suplierPay.FractionProcCd;
            //suplierPayWork.StockTotalPayBalance     = suplierPay.StockTotalPayBalance;
            //suplierPayWork.StockTtl2TmBfBlPay  = suplierPay.StockTtl2TmBfBlPay;
            //suplierPayWork.StockTtl3TmBfBlPay  = suplierPay.StockTtl3TmBfBlPay;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.CAddUpUpdExecDate    = TDateTime.LongDateToDateTime(suplierPay.CAddUpUpdExecDate);
            //suplierPayWork.CAddUpUpdExecDate = suplierPay.CAddUpUpdExecDate;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.DmdProcNum           = suplierPay.DmdProcNum;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplierPayWork.CreateDateTime = suplierPay.CreateDateTime; // 作成日時
            suplierPayWork.UpdateDateTime = suplierPay.UpdateDateTime; // 更新日時
            suplierPayWork.EnterpriseCode = suplierPay.EnterpriseCode; // 企業コード
            suplierPayWork.FileHeaderGuid = suplierPay.FileHeaderGuid; // GUID
            suplierPayWork.UpdEmployeeCode = suplierPay.UpdEmployeeCode; // 更新従業員コード
            suplierPayWork.UpdAssemblyId1 = suplierPay.UpdAssemblyId1; // 更新アセンブリID1
            suplierPayWork.UpdAssemblyId2 = suplierPay.UpdAssemblyId2; // 更新アセンブリID2
            suplierPayWork.LogicalDeleteCode = suplierPay.LogicalDeleteCode; // 論理削除区分
            suplierPayWork.AddUpSecCode = suplierPay.AddUpSecCode; // 計上拠点コード
            suplierPayWork.PayeeCode = suplierPay.PayeeCode; // 支払先コード
            suplierPayWork.PayeeName = suplierPay.PayeeName; // 支払先名称
            suplierPayWork.PayeeName2 = suplierPay.PayeeName2; // 支払先名称2
            suplierPayWork.PayeeSnm = suplierPay.PayeeSnm; // 支払先略称
            suplierPayWork.SupplierCd = suplierPay.SupplierCd; // 得意先コード
            suplierPayWork.SupplierNm1 = suplierPay.SupplierNm1; // 得意先名称
            suplierPayWork.SupplierNm2 = suplierPay.SupplierNm2; // 得意先名称2
            suplierPayWork.SupplierSnm = suplierPay.SupplierSnm; // 得意先略称

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            suplierPayWork.ResultsSectCd = suplierPay.ResultsSectCd;    // 実績拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

            suplierPayWork.AddUpDate = suplierPay.AddUpDate; // 計上年月日
            suplierPayWork.AddUpYearMonth = suplierPay.AddUpYearMonth; // 計上年月
            suplierPayWork.LastTimePayment = suplierPay.LastTimePayment; // 前回支払金額
            suplierPayWork.ThisTimeFeePayNrml = suplierPay.ThisTimeFeePayNrml; // 今回手数料額（通常支払）
            suplierPayWork.ThisTimeDisPayNrml = suplierPay.ThisTimeDisPayNrml; // 今回値引額（通常支払）
            suplierPayWork.ThisTimePayNrml = suplierPay.ThisTimePayNrml; // 今回支払金額（通常支払）
            suplierPayWork.ThisTimeTtlBlcPay = suplierPay.ThisTimeTtlBlcPay; // 今回繰越残高（支払計）
            suplierPayWork.OfsThisTimeStock = suplierPay.OfsThisTimeStock; // 相殺後今回仕入金額
            suplierPayWork.OfsThisStockTax = suplierPay.OfsThisStockTax; // 相殺後今回仕入消費税
            suplierPayWork.ItdedOffsetOutTax = suplierPay.ItdedOffsetOutTax; // 相殺後外税対象額
            suplierPayWork.ItdedOffsetInTax = suplierPay.ItdedOffsetInTax; // 相殺後内税対象額
            suplierPayWork.ItdedOffsetTaxFree = suplierPay.ItdedOffsetTaxFree; // 相殺後非課税対象額
            suplierPayWork.OffsetOutTax = suplierPay.OffsetOutTax; // 相殺後外税消費税
            suplierPayWork.OffsetInTax = suplierPay.OffsetInTax; // 相殺後内税消費税
            suplierPayWork.ThisTimeStockPrice = suplierPay.ThisTimeStockPrice; // 今回仕入金額
            suplierPayWork.ThisStcPrcTax = suplierPay.ThisStcPrcTax; // 今回仕入消費税
            suplierPayWork.TtlItdedStcOutTax = suplierPay.TtlItdedStcOutTax; // 仕入外税対象額合計
            suplierPayWork.TtlItdedStcInTax = suplierPay.TtlItdedStcInTax; // 仕入内税対象額合計
            suplierPayWork.TtlItdedStcTaxFree = suplierPay.TtlItdedStcTaxFree; // 仕入非課税対象額合計
            suplierPayWork.TtlStockOuterTax = suplierPay.TtlStockOuterTax; // 仕入外税額合計
            suplierPayWork.TtlStockInnerTax = suplierPay.TtlStockInnerTax; // 仕入内税額合計
            suplierPayWork.ThisStckPricRgds = suplierPay.ThisStckPricRgds; // 今回返品金額
            suplierPayWork.ThisStcPrcTaxRgds = suplierPay.ThisStcPrcTaxRgds; // 今回返品消費税
            suplierPayWork.TtlItdedRetOutTax = suplierPay.TtlItdedRetOutTax; // 返品外税対象額合計
            suplierPayWork.TtlItdedRetInTax = suplierPay.TtlItdedRetInTax; // 返品内税対象額合計
            suplierPayWork.TtlItdedRetTaxFree = suplierPay.TtlItdedRetTaxFree; // 返品非課税対象額合計
            suplierPayWork.TtlRetOuterTax = suplierPay.TtlRetOuterTax; // 返品外税額合計
            suplierPayWork.TtlRetInnerTax = suplierPay.TtlRetInnerTax; // 返品内税額合計
            suplierPayWork.ThisStckPricDis = suplierPay.ThisStckPricDis; // 今回値引金額
            suplierPayWork.ThisStcPrcTaxDis = suplierPay.ThisStcPrcTaxDis; // 今回値引消費税
            suplierPayWork.TtlItdedDisOutTax = suplierPay.TtlItdedDisOutTax; // 値引外税対象額合計
            suplierPayWork.TtlItdedDisInTax = suplierPay.TtlItdedDisInTax; // 値引内税対象額合計
            suplierPayWork.TtlItdedDisTaxFree = suplierPay.TtlItdedDisTaxFree; // 値引非課税対象額合計
            suplierPayWork.TtlDisOuterTax = suplierPay.TtlDisOuterTax; // 値引外税額合計
            suplierPayWork.TtlDisInnerTax = suplierPay.TtlDisInnerTax; // 値引内税額合計
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //suplierPayWork.ThisRecvOffset = suplierPay.ThisRecvOffset; // 今回受取金額
            //suplierPayWork.ThisRecvOffsetTax = suplierPay.ThisRecvOffsetTax; // 今回受取相殺消費税
            //suplierPayWork.ThisRecvOutTax = suplierPay.ThisRecvOutTax; // 今回受取外税対象額合計
            //suplierPayWork.ThisRecvInTax = suplierPay.ThisRecvInTax; // 今回受取内税対象額合計
            //suplierPayWork.ThisRecvTaxFree = suplierPay.ThisRecvTaxFree; // 今回受取非課税対象額合計
            //suplierPayWork.ThisRecvOuterTax = suplierPay.ThisRecvOuterTax; // 今回受取外税額合計
            //suplierPayWork.ThisRecvInnerTax = suplierPay.ThisRecvInnerTax; // 今回受取内税額合計
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            suplierPayWork.TaxAdjust = suplierPay.TaxAdjust; // 消費税調整額
            suplierPayWork.BalanceAdjust = suplierPay.BalanceAdjust; // 残高調整額
            suplierPayWork.StockTotalPayBalance = suplierPay.StockTotalPayBalance - suplierPay.BalanceAdjust - suplierPay.TaxAdjust; // 仕入合計残高（支払計）
            suplierPayWork.StockTtl2TmBfBlPay = suplierPay.StockTtl2TmBfBlPay; // 仕入2回前残高（支払計）
            suplierPayWork.StockTtl3TmBfBlPay = suplierPay.StockTtl3TmBfBlPay; // 仕入3回前残高（支払計）
            suplierPayWork.CAddUpUpdExecDate = suplierPay.CAddUpUpdExecDate; // 締次更新実行年月日
            suplierPayWork.StartCAddUpUpdDate = suplierPay.StartCAddUpUpdDate; // 締次更新開始年月日
            suplierPayWork.LastCAddUpUpdDate = suplierPay.LastCAddUpUpdDate; // 前回締次更新年月日
            suplierPayWork.StockSlipCount = suplierPay.StockSlipCount; // 仕入伝票枚数
            suplierPayWork.PaymentSchedule = suplierPay.PaymentSchedule; // 支払予定日
            suplierPayWork.PaymentCond = suplierPay.PaymentCond; // 支払条件
            suplierPayWork.SuppCTaxLayCd = suplierPay.SuppCTaxLayCd; // 仕入先消費税転嫁方式コード
            suplierPayWork.SupplierConsTaxRate = suplierPay.SupplierConsTaxRate; // 仕入先消費税税率
            suplierPayWork.FractionProcCd = suplierPay.FractionProcCd; // 端数処理区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //if ( suplierPayWork.SupplierCd == suplierPayWork.PayeeCode ) {
            //    suplierPayWork.SupplierCd = 0;
            //}
        }

        #region    ********** 不要 **********
        /// <summary>クラスメンバコピー処理 (仕入先買掛金額マスタワーククラス⇒仕入先買掛金額マスタクラス)
		/// </summary>
        /// <param name="financStmntOutWork">仕入先買掛金額マスタワーククラス</param>
        /// <returns>仕入先買掛金額マスタクラス</returns>
		/// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタワーククラスから
        ///                  仕入先買掛金額マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        //private SuplAccPay CopyToFinancStmntOutFromFinancStmntOutWork(SuplAccPayWork suplAccPayWork)
        //{
        //    FinancStmntOut financStmntOut = new FinancStmntOut();

        //    suplAccPay.CreateDateTime       = suplAccPayWork.CreateDateTime;       // 作成日時
        //    suplAccPay.UpdateDateTime       = suplAccPayWork.UpdateDateTime;       // 更新日時
        //    suplAccPay.EnterpriseCode       = suplAccPayWork.EnterpriseCode;       // 企業コード
        //    suplAccPay.FileHeaderGuid       = suplAccPayWork.FileHeaderGuid;       // GUID
        //    suplAccPay.UpdEmployeeCode      = suplAccPayWork.UpdEmployeeCode;      // 更新従業員コード
        //    suplAccPay.UpdAssemblyId1       = suplAccPayWork.UpdAssemblyId1;       // 更新アセンブリID1
        //    suplAccPay.UpdAssemblyId2       = suplAccPayWork.UpdAssemblyId2;       // 更新アセンブリID2
        //    suplAccPay.LogicalDeleteCode    = suplAccPayWork.LogicalDeleteCode;    // 論理削除区分
        //    suplAccPay.EnterpriseCode       = suplAccPayWork.EnterpriseCode;
        //    suplAccPay.AddUpSecCode         = suplAccPayWork.AddUpSecCode;
        //    suplAccPay.CustomerCode         = suplAccPayWork.CustomerCode;
        //    suplAccPay.CustomerName         = suplAccPayWork.CustomerName;
        //    suplAccPay.CustomerName2        = suplAccPayWork.CustomerName2;
        //    suplAccPay.AddUpDate            = suplAccPayWork.AddUpDate;
        //    suplAccPay.AddUpYearMonth       = suplAccPayWork.AddUpYearMonth;
        //    suplAccPay.LastTimeAccPay       = suplAccPayWork.LastTimeAccPay;
        //    suplAccPay.ThisTimePayNrml      = suplAccPayWork.ThisTimePayNrml;
        //    suplAccPay.ThisTimeFeePayNrml   = suplAccPayWork.ThisTimeFeePayNrml;
        //    suplAccPay.ThisTimeDisPayNrml   = suplAccPayWork.ThisTimeDisPayNrml;
        //    suplAccPay.ThisTimeRbtDmdNrml   = suplAccPayWork.ThisTimeRbtDmdNrml;
        //    suplAccPay.ThisTimeDmdDepo      = suplAccPayWork.ThisTimeDmdDepo;
        //    suplAccPay.ThisTimeFeeDmdDepo   = suplAccPayWork.ThisTimeFeeDmdDepo;
        //    suplAccPay.ThisTimeDisDmdDepo   = suplAccPayWork.ThisTimeDisDmdDepo;
        //    suplAccPay.ThisTimeRbtDmdDepo   = suplAccPayWork.ThisTimeRbtDmdDepo;
        //    suplAccPay.ThisTimeTtlBlcAcPay    = suplAccPayWork.ThisTimeTtlBlcAcPay;
        //    suplAccPay.ThisTimeStockPrice        = suplAccPayWork.ThisTimeStockPrice;
        //    suplAccPay.ThisStcPrcTax         = suplAccPayWork.ThisStcPrcTax;
        //    suplAccPay.TtlIncDtbtTaxExc     = suplAccPayWork.TtlIncDtbtTaxExc;
        //    suplAccPay.TtlIncDtbtTax        = suplAccPayWork.TtlIncDtbtTax;
        //    suplAccPay.ThisNetStckPrice     = suplAccPayWork.ThisNetStckPrice;
        //    suplAccPay.ThisNetStcPrcTax      = suplAccPayWork.ThisNetStcPrcTax;
        //    suplAccPay.ItdedOffsetOutTax    = suplAccPayWork.ItdedOffsetOutTax;
        //    suplAccPay.ItdedOffsetInTax     = suplAccPayWork.ItdedOffsetInTax;
        //    suplAccPay.ItdedOffsetTaxFree   = suplAccPayWork.ItdedOffsetTaxFree;
        //    suplAccPay.OffsetOutTax         = suplAccPayWork.OffsetOutTax;
        //    suplAccPay.OffsetInTax          = suplAccPayWork.OffsetInTax;
        //    suplAccPay.TtlItdedStcOutTax     = suplAccPayWork.TtlItdedStcOutTax;
        //    suplAccPay.TtlItdedStcInTax      = suplAccPayWork.TtlItdedStcInTax;
        //    suplAccPay.TtlItdedStcTaxFree    = suplAccPayWork.TtlItdedStcTaxFree;
        //    suplAccPay.TtlStockOuterTax          = suplAccPayWork.TtlStockOuterTax;
        //    suplAccPay.TtlStockInnerTax           = suplAccPayWork.TtlStockInnerTax;
        //    suplAccPay.ItdedPaymOutTax      = suplAccPayWork.ItdedPaymOutTax;
        //    suplAccPay.ItdedPaymInTax       = suplAccPayWork.ItdedPaymInTax;
        //    suplAccPay.ItdedPaymTaxFree     = suplAccPayWork.ItdedPaymTaxFree;
        //    suplAccPay.PaymentOutTax        = suplAccPayWork.PaymentOutTax;
        //    suplAccPay.PaymentInTax         = suplAccPayWork.PaymentInTax;
        //    suplAccPay.SuppCTaxLayCd     = suplAccPayWork.SuppCTaxLayCd;
        //    suplAccPay.SupplierConsTaxRate          = suplAccPayWork.SupplierConsTaxRate;
        //    suplAccPay.FractionProcCd       = suplAccPayWork.FractionProcCd;
        //    suplAccPay.StckTtlAccPayBalance    = suplAccPayWork.StckTtlAccPayBalance;
        //    suplAccPay.StckTtl2TmBfBlAccPay = suplAccPayWork.StckTtl2TmBfBlAccPay;
        //    suplAccPay.StckTtl3TmBfBlAccPay = suplAccPayWork.StckTtl3TmBfBlAccPay;
        //    suplAccPay.MonthAddUpExpDate    = suplAccPayWork.MonthAddUpExpDate;

        //    // テーブル更新
        //    this._custAccRecDic[suplAccPayWork.FileHeaderGuid] = suplAccPayWork;

        //    return suplAccPay;
        //}
        #endregion ********** 不要 **********

        /// <summary>仕入先買掛金額マスタオブジェクトメインDataSet展開処理</summary>
        /// <param name="suplAccPayWork">仕入先買掛金額マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private void SuplAccPayWorkToDataSet(SuplAccPayWork suplAccPayWork)
        private void SuplAccPayWorkToDataSet(SuplAccPayWork suplAccPayWork, ArrayList aCalcPayTotalWorkArrayList)
        // 2009.01.14 <<<
        {
            // 2009.01.14 Del >>>
            //// 親レコードの場合は得意先コードに支払先コードと同じ値を再セット
            //if (suplAccPayWork.SupplierCd == 0)
            //{
            //    suplAccPayWork.SupplierCd = suplAccPayWork.PayeeCode;
            //}
            // 2009.01.14 Del <<<

            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            object[] primryKey = new object[] { suplAccPayWork.AddUpSecCode, 
                                                suplAccPayWork.PayeeCode,
                                                suplAccPayWork.SupplierCd, 
                                                TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate) };
            DataRow dr = this._custAccRecTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._custAccRecTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 2009.01.14 Del >>>
            // 実際のデータセットは別メソッドで行うためコメントアウト
#if false
            // 削除日
            if (suplAccPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplAccPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = suplAccPayWork.AddUpSecCode;                                           // 計上拠点コード

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            dr[COL_SUPPLIERCODE_TITLE] = suplAccPayWork.SupplierCd;                                           // 仕入先コード
            dr[COL_SUPPLIERNAME_TITLE]         = suplAccPayWork.SupplierNm1;                                           // 仕入先名称
            dr[COL_SUPPLIERNAME2_TITLE] = suplAccPayWork.SupplierNm2;                                          // 仕入先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_SUPPLIERSNM_TITLE] = suplAccPayWork.SupplierSnm;                                            // 仕入先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            dr[COL_PAYEECODE_TITLE]            = suplAccPayWork.PayeeCode;                                              // 支払先コード
            dr[COL_PAYEENAME_TITLE]            = suplAccPayWork.PayeeName;                                              // 支払先名称
            dr[COL_PAYEENAME2_TITLE]           = suplAccPayWork.PayeeName2;                                             // 支払先名称2
            dr[COL_PAYEESNM_TITLE]             = suplAccPayWork.PayeeSnm;                                               // 支払先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE]          = TDateTime.DateTimeToString("YYYY/MM/DD", suplAccPayWork.AddUpDate);    // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", suplAccPayWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate);                // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpYearMonth);           // _計上年月
            dr[COL_LASTTIMEACCPAY_TITLE]       = suplAccPayWork.LastTimeAccPay;                                         // 前回買掛金額
            dr[COL_THISTIMEPAYNRML_TITLE]      = suplAccPayWork.ThisTimePayNrml;                                        // 今回支払金額（通常支払）
            dr[COL_THISTIMEFEEPAYNRML_TITLE]   = suplAccPayWork.ThisTimeFeePayNrml;                                     // 今回手数料額（通常支払）
            dr[COL_THISTIMEDISPAYNRML_TITLE]   = suplAccPayWork.ThisTimeDisPayNrml;                                     // 今回値引額（通常支払）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = suplAccPayWork.ThisTimeRbtDmdNrml;                                     // 今回リベート額（通常支払）
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = suplAccPayWork.ThisTimeDmdDepo;                                        // 今回支払金額（預り金）
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = suplAccPayWork.ThisTimeFeeDmdDepo;                                     // 今回手数料額（預り金）
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = suplAccPayWork.ThisTimeDisDmdDepo;                                     // 今回値引額（預り金）
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = suplAccPayWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEPAYMENT_TITLE]      = suplAccPayWork.ThisTimePayNrml    +                                    // 今回支払金額（通常支払）
            //                                     suplAccPayWork.ThisTimeFeePayNrml +                                    // 今回手数料額（通常支払）
            //                                     suplAccPayWork.ThisTimeDisPayNrml +                                    // 今回値引額（通常支払）
            //                                     suplAccPayWork.ThisTimeRbtDmdNrml +                                    // 今回リベート額（通常支払）
            //                                     suplAccPayWork.ThisTimeDmdDepo    +                                    // 今回支払金額（預り金）
            //                                     suplAccPayWork.ThisTimeFeeDmdDepo +                                    // 今回手数料額（預り金）
            //                                     suplAccPayWork.ThisTimeDisDmdDepo +                                    // 今回値引額（預り金）
            //                                     suplAccPayWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            dr[COL_THISTIMEPAYMENT_TITLE] = suplAccPayWork.ThisTimePayNrml +                                    // 今回支払金額（通常支払）
                                                 suplAccPayWork.ThisTimeFeePayNrml +                                    // 今回手数料額（通常支払）
                                                 suplAccPayWork.ThisTimeDisPayNrml ;                                    // 今回値引額（通常支払）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCACPAY_TITLE]    = suplAccPayWork.ThisTimeTtlBlcAcPay;                                      // 今回繰越残高（買掛計）
            dr[COL_THISTIMESTOCKPRICE_TITLE]        = suplAccPayWork.ThisTimeStockPrice;                                          // 今回仕入金額
            dr[COL_THISSTCPRCTAX_TITLE]         = suplAccPayWork.ThisStcPrcTax;                                           // 今回仕入消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = suplAccPayWork.TtlIncDtbtTaxExc;                                       // 支払インセンティブ額合計（税抜き）
            //dr[COL_TTLINCDTBTTAX_TITLE]        = suplAccPayWork.TtlIncDtbtTax;                                          // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISNETSTCKPRICE_TITLE]     = suplAccPayWork.ThisNetStckPrice;                                       // 相殺後今回仕入金額
            //dr[COL_THISNETSTCPRCTAX_TITLE]      = suplAccPayWork.ThisNetStcPrcTax;                                        // 相殺後今回仕入消費税
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplAccPayWork.OfsThisTimeStock;                                       // 相殺後今回仕入金額
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplAccPayWork.OfsThisStockTax;                                        // 相殺後今回仕入消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = suplAccPayWork.ItdedOffsetOutTax;                                      // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = suplAccPayWork.ItdedOffsetInTax;                                       // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = suplAccPayWork.ItdedOffsetTaxFree;                                     // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE]         = suplAccPayWork.OffsetOutTax;                                           // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE]          = suplAccPayWork.OffsetInTax;                                            // 相殺後内税消費税
            dr[COL_ITDEDSTCOUTTAX_TITLE]     = suplAccPayWork.TtlItdedStcOutTax;                                       // 仕入外税対象額
            dr[COL_ITDEDSTCINTAX_TITLE]      = suplAccPayWork.TtlItdedStcInTax;                                        // 仕入内税対象額
            dr[COL_ITDEDSTCTAXFREE_TITLE]    = suplAccPayWork.TtlItdedStcTaxFree;                                      // 仕入非課税対象額
            dr[COL_TTLSTOCKOUTERTAX_TITLE]          = suplAccPayWork.TtlStockOuterTax;                                            // 仕入外税額
            dr[COL_TTLSTOCKINNERTAX_TITLE]           = suplAccPayWork.TtlStockInnerTax;                                             // 仕入内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = suplAccPayWork.ItdedPaymOutTax;                                        // 支払外税対象額
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = suplAccPayWork.ItdedPaymInTax;                                         // 支払内税対象額
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = suplAccPayWork.ItdedPaymTaxFree;                                       // 支払非課税対象額
            //dr[COL_PAYMENTOUTTAX_TITLE]        = suplAccPayWork.PaymentOutTax;                                          // 支払外税消費税
            //dr[COL_PAYMENTINTAX_TITLE]         = suplAccPayWork.PaymentInTax;                                           // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = suplAccPayWork.TtlItdedRetOutTax;                                       // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE]     = suplAccPayWork.TtlItdedRetInTax;                                        // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = suplAccPayWork.TtlItdedRetTaxFree;                                      // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE]       = suplAccPayWork.TtlRetOuterTax;                                            // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE]       = suplAccPayWork.TtlRetInnerTax;                                             // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = suplAccPayWork.TtlItdedDisOutTax;                                       // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE]     = suplAccPayWork.TtlItdedDisInTax;                                        // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = suplAccPayWork.TtlItdedDisTaxFree;                                      // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE]       = suplAccPayWork.TtlDisOuterTax;                                            // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE]       = suplAccPayWork.TtlDisInnerTax;                                             // 値引内税額
            dr[COL_BALANCEADJUST_TITLE]        = suplAccPayWork.BalanceAdjust;                                          // 残高調整額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            dr[COL_TAXADJUST_TITLE] = suplAccPayWork.TaxAdjust;                                                         // 消費税調整額
            dr[COL_TOTALADJUST_TITLE] = suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_NONSTMNTAPPEARANCE_TITLE]   = suplAccPayWork.NonStmntAppearance;                                     // 未決済金額（自振）
            //dr[COL_NONSTMNTISDONE_TITLE]       = suplAccPayWork.NonStmntIsdone;                                         // 未決済金額（廻し） 
            //dr[COL_STMNTAPPEARANCE_TITLE]      = suplAccPayWork.StmntAppearance;                                        // 決済金額（自振）
            //dr[COL_STMNTISDONE_TITLE]          = suplAccPayWork.StmntIsdone;                                            // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //dr[COL_THISCASHSTOCKPRICE]          = suplAccPayWork.ThisCashStockPrice;                                      // 現金仕入金額
            //dr[COL_THISCASHSTOCKTAX]            = suplAccPayWork.ThisCashStockTax;                                        // 現金仕入消費税額
            //dr[COL_STOCKSLIPCOUNT]             = 0;                                                                     // （伝票枚数）
            dr[COL_PAYMENTSCHEDULE]        = 0;                                                                     // （支払予定日）
            dr[COL_PAYMENTCOND]                = 0;                                                                     // （回収条件）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_SUPPCTAXLAYCD_TITLE]     = suplAccPayWork.SuppCTaxLayCd;                                       // 消費税転嫁方式
            dr[COL_SUPPLIERCONSTAXRATE_TITLE]          = suplAccPayWork.SupplierConsTaxRate;                                            // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE]       = suplAccPayWork.FractionProcCd;                                         // 端数処理区分
            dr[COL_STCKTTLACCPAYBALANCE_TITLE] = suplAccPayWork.StckTtlAccPayBalance +suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;                                      // 計算後当月買掛金額
            //dr[COL_STCKTTLACCPAYBALANCE_TITLE] = suplAccPayWork.StckTtlAccPayBalance;                                      // 計算後当月買掛金額
            dr[COL_STCKTTL2TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl2TmBfBlAccPay;                                   // 受注2回前残高（買掛計）
            dr[COL_STCKTTL3TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl3TmBfBlAccPay;                                   // 受注3回前残高（買掛計）
            dr[COL_MONTHADDUPEXPDATE_TITLE]    = TDateTime.DateTimeToLongDate(suplAccPayWork.MonthAddUpExpDate);        // 月次更新実行年月日

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISRECVINNERTAX_TITLE] = suplAccPayWork.ThisRecvInnerTax;
            //dr[COL_THISRECVINTAX_TITLE] = suplAccPayWork.ThisRecvInTax;
            //dr[COL_THISRECVOFFSET_TITLE] = suplAccPayWork.ThisRecvOffset;
            //dr[COL_THISRECVOFFSETTAX_TITLE] = suplAccPayWork.ThisRecvOffsetTax;
            //dr[COL_THISRECVOUTERTAX_TITLE] = suplAccPayWork.ThisRecvOuterTax;
            //dr[COL_THISRECVOUTTAX_TITLE] = suplAccPayWork.ThisRecvOutTax;
            //dr[COL_THISRECVTAXFREE_TITLE] = suplAccPayWork.ThisRecvTaxFree;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            dr[COL_GUID_TITLE] = suplAccPayWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = suplAccPayWork.CreateDateTime; // 作成日時
            dr[COL_UPDATEDATETIME] = suplAccPayWork.UpdateDateTime; // 更新日時
            dr[COL_STOCKSLIPCOUNT] = suplAccPayWork.StockSlipCount; // [5047]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, suplAccPayWork, aCalcPayTotalWorkArrayList);
            // 2009.01.14 Del <<<

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._custAccRecTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._custAccRecDic.ContainsKey(suplAccPayWork.FileHeaderGuid) == true)
            {
                this._custAccRecDic.Remove(suplAccPayWork.FileHeaderGuid);
            }
            this._custAccRecDic.Add(suplAccPayWork.FileHeaderGuid, suplAccPayWork);
        }

        /// <summary>仕入先支払金額マスタオブジェクトメインDataSet展開処理</summary>
        /// <param name="suplAccPayWork">仕入先支払金額マスタオブジェクト</param>
        /// <param name="accPayTotalWorkArrayList">精算支払集計データオブジェクトリスト</param>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private void SuplierPayWorkToDataSet(SuplierPayWork suplierPayWork)
        private void SuplierPayWorkToDataSet(SuplierPayWork suplierPayWork, ArrayList accPayTotalWorkArrayList)
        // 2009.01.14 <<<
        {
            // 2009.01.14 Del >>>
            //// 親レコードの場合は得意先コードに支払先コードと同じ値を再セット
            //if (suplierPayWork.SupplierCd == 0)
            //{
            //    suplierPayWork.SupplierCd = suplierPayWork.PayeeCode;
            //}
            // 2009.01.14 Del <<<

            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            object[] primryKey = new object[] { suplierPayWork.AddUpSecCode,
                                                suplierPayWork.PayeeCode,
                                                suplierPayWork.SupplierCd, 
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
                                                suplierPayWork.ResultsSectCd,
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END
                                                TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate) };
            DataRow dr = this._custDmdPrcTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._custDmdPrcTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 2009.01.14 Del >>>
#if false
            // 削除日
            if (suplierPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplierPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = suplierPayWork.AddUpSecCode;                                           // 計上拠点コード

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            dr[COL_SUPPLIERCODE_TITLE] = suplierPayWork.SupplierCd;                                           // 仕入先コード
            dr[COL_SUPPLIERNAME_TITLE] = suplierPayWork.SupplierNm1;                                           // 仕入先名称
            dr[COL_SUPPLIERNAME2_TITLE] = suplierPayWork.SupplierNm2;                                          // 仕入先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_SUPPLIERSNM_TITLE] = suplierPayWork.SupplierSnm;                                            // 仕入先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            dr[COL_RESULTSECCODE_TITLE] = suplierPayWork.ResultsSectCd;                                                 // 実績拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END


            dr[COL_PAYEECODE_TITLE]            = suplierPayWork.PayeeCode;                                              // 支払先コード
            dr[COL_PAYEENAME_TITLE]            = suplierPayWork.PayeeName;                                              // 支払先名称
            dr[COL_PAYEENAME2_TITLE]           = suplierPayWork.PayeeName2;                                             // 支払先名称2
            dr[COL_PAYEESNM_TITLE]             = suplierPayWork.PayeeSnm;                                               // 支払先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", suplierPayWork.AddUpDate);    // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", suplierPayWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate);                // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpYearMonth);           // _計上年月
            dr[COL_LASTTIMEDEMAND_TITLE]       = suplierPayWork.LastTimePayment;                                         // 前回支払金額
            dr[COL_THISTIMEPAYNRML_TITLE]      = suplierPayWork.ThisTimePayNrml;                                        // 今回支払金額（通常支払）
            dr[COL_THISTIMEFEEPAYNRML_TITLE]   = suplierPayWork.ThisTimeFeePayNrml;                                     // 今回手数料額（通常支払）
            dr[COL_THISTIMEDISPAYNRML_TITLE]   = suplierPayWork.ThisTimeDisPayNrml;                                     // 今回値引額（通常支払）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = suplierPayWork.ThisTimeRbtDmdNrml;                                     // 今回リベート額（通常支払）
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = suplierPayWork.ThisTimeDmdDepo;                                        // 今回支払金額（預り金）
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = suplierPayWork.ThisTimeFeeDmdDepo;                                     // 今回手数料額（預り金）
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = suplierPayWork.ThisTimeDisDmdDepo;                                     // 今回値引額（預り金）
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = suplierPayWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEPAYMENT_TITLE]      = suplierPayWork.ThisTimePayNrml    +                                    // 今回支払金額（通常支払）
            //                                     suplierPayWork.ThisTimeFeePayNrml +                                    // 今回手数料額（通常支払）
            //                                     suplierPayWork.ThisTimeDisPayNrml +                                    // 今回値引額（通常支払）
            //                                     suplierPayWork.ThisTimeRbtDmdNrml +                                    // 今回リベート額（通常支払）
            //                                     suplierPayWork.ThisTimeDmdDepo    +                                    // 今回支払金額（預り金）
            //                                     suplierPayWork.ThisTimeFeeDmdDepo +                                    // 今回手数料額（預り金）
            //                                     suplierPayWork.ThisTimeDisDmdDepo +                                    // 今回値引額（預り金）
            //                                     suplierPayWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            dr[COL_THISTIMEPAYMENT_TITLE] = suplierPayWork.ThisTimePayNrml +                                    // 今回支払金額（通常支払）
                                                 suplierPayWork.ThisTimeFeePayNrml +                                    // 今回手数料額（通常支払）
                                                 suplierPayWork.ThisTimeDisPayNrml ;                                    // 今回値引額（通常支払）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCDMD_TITLE]    = suplierPayWork.ThisTimeTtlBlcPay;                                      // 今回繰越残高（支払計）
            dr[COL_THISTIMESTOCKPRICE_TITLE]        = suplierPayWork.ThisTimeStockPrice;                                          // 今回仕入金額
            dr[COL_THISSTCPRCTAX_TITLE]         = suplierPayWork.ThisStcPrcTax;                                           // 今回仕入消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = suplierPayWork.TtlIncDtbtTaxExc;                                       // 支払インセンティブ額合計（税抜き）
            //dr[COL_TTLINCDTBTTAX_TITLE]        = suplierPayWork.TtlIncDtbtTax;                                          // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISNETSTCKPRICE_TITLE]     = suplierPayWork.ThisNetStckPrice;                                       // 相殺後今回仕入金額
            //dr[COL_THISNETSTCPRCTAX_TITLE]      = suplierPayWork.ThisNetStcPrcTax;                                        // 相殺後今回仕入消費税
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplierPayWork.OfsThisTimeStock;                                       // 相殺後今回仕入金額
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplierPayWork.OfsThisStockTax;                                        // 相殺後今回仕入消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = suplierPayWork.ItdedOffsetOutTax;                                      // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = suplierPayWork.ItdedOffsetInTax;                                       // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = suplierPayWork.ItdedOffsetTaxFree;                                     // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE]         = suplierPayWork.OffsetOutTax;                                           // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE]          = suplierPayWork.OffsetInTax;                                            // 相殺後内税消費税
            dr[COL_ITDEDSTCOUTTAX_TITLE]     = suplierPayWork.TtlItdedStcOutTax;                                       // 仕入外税対象額
            dr[COL_ITDEDSTCINTAX_TITLE]      = suplierPayWork.TtlItdedStcInTax;                                        // 仕入内税対象額
            dr[COL_ITDEDSTCTAXFREE_TITLE]    = suplierPayWork.TtlItdedStcTaxFree;                                      // 仕入非課税対象額
            dr[COL_TTLSTOCKOUTERTAX_TITLE]          = suplierPayWork.TtlStockOuterTax;                                            // 仕入外税額
            dr[COL_TTLSTOCKINNERTAX_TITLE]           = suplierPayWork.TtlStockInnerTax;                                             // 仕入内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = suplierPayWork.ItdedPaymOutTax;                                        // 支払外税対象額
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = suplierPayWork.ItdedPaymInTax;                                         // 支払内税対象額
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = suplierPayWork.ItdedPaymTaxFree;                                       // 支払非課税対象額
            //dr[COL_PAYMENTOUTTAX_TITLE]        = suplierPayWork.PaymentOutTax;                                          // 支払外税消費税
            //dr[COL_PAYMENTINTAX_TITLE]         = suplierPayWork.PaymentInTax;                                           // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = suplierPayWork.TtlItdedRetOutTax;                                       // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE]     = suplierPayWork.TtlItdedRetInTax;                                        // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = suplierPayWork.TtlItdedRetTaxFree;                                      // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE]       = suplierPayWork.TtlRetOuterTax;                                            // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE]       = suplierPayWork.TtlRetInnerTax;                                             // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = suplierPayWork.TtlItdedDisOutTax;                                       // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE]     = suplierPayWork.TtlItdedDisInTax;                                        // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = suplierPayWork.TtlItdedDisTaxFree;                                      // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE]       = suplierPayWork.TtlDisOuterTax;                                            // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE]       = suplierPayWork.TtlDisInnerTax;                                             // 値引内税額
            dr[COL_BALANCEADJUST_TITLE]        = suplierPayWork.BalanceAdjust;                                          // 残高調整額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            dr[COL_TAXADJUST_TITLE] = suplierPayWork.TaxAdjust;                                                         // 消費税調整額
            dr[COL_TOTALADJUST_TITLE] = suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            dr[COL_NONSTMNTAPPEARANCE_TITLE]   = 0;                                                                     // 未決済金額（自振）
            dr[COL_NONSTMNTISDONE_TITLE]       = 0;                                                                     // 未決済金額（廻し） 
            dr[COL_STMNTAPPEARANCE_TITLE]      = 0;                                                                     // 決済金額（自振）
            dr[COL_STMNTISDONE_TITLE]          = 0;                                                                     // 決済金額（廻し）

            //dr[COL_THISCASHSTOCKPRICE]          = 0;                                                                     // 現金仕入金額
            //dr[COL_THISCASHSTOCKTAX]            = 0;                                                                     // 現金仕入消費税額
            dr[COL_STOCKSLIPCOUNT]             = suplierPayWork.StockSlipCount;                                        // 伝票枚数
            dr[COL_PAYMENTSCHEDULE]        = TDateTime.DateTimeToLongDate(suplierPayWork.PaymentSchedule);      // 支払予定日
            dr[COL_PAYMENTCOND]                = suplierPayWork.PaymentCond;                                            // 回収条件

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_SUPPCTAXLAYCD_TITLE]     = suplierPayWork.SuppCTaxLayCd;                                       // 消費税転嫁方式
            dr[COL_SUPPLIERCONSTAXRATE_TITLE]          = suplierPayWork.SupplierConsTaxRate;                                            // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE]       = suplierPayWork.FractionProcCd;                                         // 端数処理区分
            dr[COL_AFCALDEMANDPRICE_TITLE] = suplierPayWork.StockTotalPayBalance + suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;                                       // 計算後支払金額
            //dr[COL_AFCALDEMANDPRICE_TITLE] = suplierPayWork.StockTotalPayBalance;                                       // 計算後支払金額
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE]  = suplierPayWork.StockTtl2TmBfBlPay;                                    // 受注2回前残高（支払計）
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE]  = suplierPayWork.StockTtl3TmBfBlPay;                                    // 受注3回前残高（支払計）
            dr[COL_CADDUPUPDEXECDATE_TITLE]    = TDateTime.DateTimeToLongDate(suplierPayWork.CAddUpUpdExecDate);        // 締次更新実行年月日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_THISRECVINNERTAX_TITLE] = suplierPayWork.ThisRecvInnerTax;
            //dr[COL_THISRECVINTAX_TITLE] = suplierPayWork.ThisRecvInTax;
            //dr[COL_THISRECVOFFSET_TITLE] = suplierPayWork.ThisRecvOffset;
            //dr[COL_THISRECVOFFSETTAX_TITLE] = suplierPayWork.ThisRecvOffsetTax;
            //dr[COL_THISRECVOUTERTAX_TITLE] = suplierPayWork.ThisRecvOuterTax;
            //dr[COL_THISRECVOUTTAX_TITLE] = suplierPayWork.ThisRecvOutTax;
            //dr[COL_THISRECVTAXFREE_TITLE] = suplierPayWork.ThisRecvTaxFree;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_DMDPROCNUM_TITLE]           = suplierPayWork.DmdProcNum;                                             // 支払処理通番
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_GUID_TITLE]                 = suplierPayWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = suplierPayWork.CreateDateTime; // 作成日時
            dr[COL_UPDATEDATETIME] = suplierPayWork.UpdateDateTime; // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, suplierPayWork, accPayTotalWorkArrayList);
            // 2009.01.14 Del <<<

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._custDmdPrcTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._custDmdPrcDic.ContainsKey(suplierPayWork.FileHeaderGuid) == true)
            {
                this._custDmdPrcDic.Remove(suplierPayWork.FileHeaderGuid);
            }
            this._custDmdPrcDic.Add(suplierPayWork.FileHeaderGuid, suplierPayWork);
        }

        // 2009.01.14 Add >>>

        /// <summary>仕入先買掛金額マスタオブジェクト(集計レコード)メインDataSet展開処理</summary>
        /// <param name="suplAccPayWork">仕入先買掛金額マスタオブジェクト</param>
        /// <param name="aCalcPayTotalWorkArrayList">買掛支払集計データオブジェクトリスト</param>
        /// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void SuplAccPayWorkTotalToDataSet(SuplAccPayWork suplAccPayWork, ArrayList aCalcPayTotalWorkArrayList)
        {
            try
            {
                this._custAccRecTotalTable.BeginLoadData();
                // 更新対象行の取得
                object[] primryKey = new object[] { suplAccPayWork.AddUpSecCode, 
                                                suplAccPayWork.PayeeCode,
                                                suplAccPayWork.SupplierCd, 
                                                TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate) };

                DataRow dr = this._custAccRecTotalTable.Rows.Find(primryKey);
                if (dr == null)
                {
                    // 新規に行を作成
                    dr = this._custAccRecTotalTable.NewRow();
                    this._custAccRecTotalTable.Rows.Add(dr);
                }

                this.DataRowFromParamData(ref dr, suplAccPayWork, aCalcPayTotalWorkArrayList);
            }
            finally
            {
                this._custAccRecTotalTable.EndLoadData();
            }
        }

        /// <summary>仕入先支払金額マスタオブジェクトメインDataSet展開処理</summary>
        /// <param name="suplAccPayWork">仕入先支払金額マスタオブジェクト</param>
        /// <param name="accPayTotalWorkArrayList">精算支払集計データオブジェクトリスト</param>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void SuplierPayWorkTotalToDataSet(SuplierPayWork suplierPayWork, ArrayList accPayTotalWorkArrayList)
        {
            try
            {
                this._custDmdPrcTotalTable.BeginLoadData();

                // 更新対象行の取得
                object[] primryKey = new object[] { suplierPayWork.AddUpSecCode,
                                                suplierPayWork.PayeeCode,
                                                suplierPayWork.SupplierCd, 
                                                suplierPayWork.ResultsSectCd,
                                                TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate) };
                DataRow dr = this._custDmdPrcTotalTable.Rows.Find(primryKey);
                if (dr == null)
                {
                    // 新規に行を作成
                    dr = this._custDmdPrcTotalTable.NewRow();
                    this._custDmdPrcTotalTable.Rows.Add(dr);
                }

                this.DataRowFromParamData(ref dr, suplierPayWork, accPayTotalWorkArrayList);
            }
            finally
            {
                this._custDmdPrcTotalTable.EndLoadData();
            }
        }

        /// <summary>
        /// 仕入先買掛金額マスタワーク、買掛支払集計データワークリスト→DataRow移項処理
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="custAccRecWork">仕入先買掛金額マスタワーク</param>
        /// <param name="accRecDepoTotalArrayList">買掛支払集計データワークリスト</param>
        private void DataRowFromParamData(ref DataRow dr, SuplAccPayWork suplAccPayWork, ArrayList aCalcPayTotalWorkArrayList)
        {
            // 削除日
            if (suplAccPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplAccPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = suplAccPayWork.AddUpSecCode;                                           // 計上拠点コード

            dr[COL_SUPPLIERCODE_TITLE] = suplAccPayWork.SupplierCd;                                             // 仕入先コード
            dr[COL_SUPPLIERNAME_TITLE] = suplAccPayWork.SupplierNm1;                                            // 仕入先名称
            dr[COL_SUPPLIERNAME2_TITLE] = suplAccPayWork.SupplierNm2;                                           // 仕入先名称2
            dr[COL_SUPPLIERSNM_TITLE] = suplAccPayWork.SupplierSnm;                                             // 仕入先略称

            dr[COL_PAYEECODE_TITLE] = suplAccPayWork.PayeeCode;                                                 // 支払先コード
            dr[COL_PAYEENAME_TITLE] = suplAccPayWork.PayeeName;                                                 // 支払先名称
            dr[COL_PAYEENAME2_TITLE] = suplAccPayWork.PayeeName2;                                               // 支払先名称2
            dr[COL_PAYEESNM_TITLE] = suplAccPayWork.PayeeSnm;                                                   // 支払先略称
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", suplAccPayWork.AddUpDate);     // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", suplAccPayWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate);                   // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpYearMonth);         // _計上年月
            dr[COL_LASTTIMEACCPAY_TITLE] = suplAccPayWork.LastTimeAccPay;                                       // 前回買掛金額
            dr[COL_THISTIMEPAYNRML_TITLE] = suplAccPayWork.ThisTimePayNrml;                                     // 今回支払金額（通常支払）
            dr[COL_THISTIMEFEEPAYNRML_TITLE] = suplAccPayWork.ThisTimeFeePayNrml;                               // 今回手数料額（通常支払）
            dr[COL_THISTIMEDISPAYNRML_TITLE] = suplAccPayWork.ThisTimeDisPayNrml;                               // 今回値引額（通常支払）
            dr[COL_THISTIMEPAYMENT_TITLE] = suplAccPayWork.ThisTimePayNrml;                                     // 今回支払金額（通常支払）
            dr[COL_THISTIMETTLBLCACPAY_TITLE] = suplAccPayWork.ThisTimeTtlBlcAcPay;                             // 今回繰越残高（買掛計）
            dr[COL_THISTIMESTOCKPRICE_TITLE] = suplAccPayWork.ThisTimeStockPrice;                               // 今回仕入金額
            dr[COL_THISSTCPRCTAX_TITLE] = suplAccPayWork.ThisStcPrcTax;                                         // 今回仕入消費税
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplAccPayWork.OfsThisTimeStock;                                   // 相殺後今回仕入金額
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplAccPayWork.OfsThisStockTax;                                     // 相殺後今回仕入消費税
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = suplAccPayWork.ItdedOffsetOutTax;                                 // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE] = suplAccPayWork.ItdedOffsetInTax;                                   // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = suplAccPayWork.ItdedOffsetTaxFree;                               // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE] = suplAccPayWork.OffsetOutTax;                                           // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE] = suplAccPayWork.OffsetInTax;                                             // 相殺後内税消費税
            dr[COL_ITDEDSTCOUTTAX_TITLE] = suplAccPayWork.TtlItdedStcOutTax;                                    // 仕入外税対象額
            dr[COL_ITDEDSTCINTAX_TITLE] = suplAccPayWork.TtlItdedStcInTax;                                      // 仕入内税対象額
            dr[COL_ITDEDSTCTAXFREE_TITLE] = suplAccPayWork.TtlItdedStcTaxFree;                                  // 仕入非課税対象額
            dr[COL_TTLSTOCKOUTERTAX_TITLE] = suplAccPayWork.TtlStockOuterTax;                                   // 仕入外税額
            dr[COL_TTLSTOCKINNERTAX_TITLE] = suplAccPayWork.TtlStockInnerTax;                                   // 仕入内税額
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = suplAccPayWork.TtlItdedRetOutTax;                                 // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE] = suplAccPayWork.TtlItdedRetInTax;                                   // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = suplAccPayWork.TtlItdedRetTaxFree;                               // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE] = suplAccPayWork.TtlRetOuterTax;                                       // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE] = suplAccPayWork.TtlRetInnerTax;                                       // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = suplAccPayWork.TtlItdedDisOutTax;                                 // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE] = suplAccPayWork.TtlItdedDisInTax;                                   // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = suplAccPayWork.TtlItdedDisTaxFree;                               // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE] = suplAccPayWork.TtlDisOuterTax;                                       // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE] = suplAccPayWork.TtlDisInnerTax;                                       // 値引内税額
            dr[COL_BALANCEADJUST_TITLE] = suplAccPayWork.BalanceAdjust;                                         // 残高調整額
            dr[COL_TAXADJUST_TITLE] = suplAccPayWork.TaxAdjust;                                                 // 消費税調整額

            dr[COL_TOTALADJUST_TITLE] = suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;

            dr[COL_PAYMENTSCHEDULE] = 0;                                                                        // （支払予定日）
            dr[COL_PAYMENTCOND] = 0;                                                                            // （回収条件）
            dr[COL_SUPPCTAXLAYCD_TITLE] = suplAccPayWork.SuppCTaxLayCd;                                         // 消費税転嫁方式
            dr[COL_SUPPLIERCONSTAXRATE_TITLE] = suplAccPayWork.SupplierConsTaxRate;                             // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE] = suplAccPayWork.FractionProcCd;                                       // 端数処理区分
            dr[COL_STCKTTLACCPAYBALANCE_TITLE] = suplAccPayWork.StckTtlAccPayBalance + suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;                                      // 計算後当月買掛金額
            dr[COL_STCKTTL2TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl2TmBfBlAccPay;                           // 受注2回前残高（買掛計）
            dr[COL_STCKTTL3TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl3TmBfBlAccPay;                           // 受注3回前残高（買掛計）
            dr[COL_MONTHADDUPEXPDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.MonthAddUpExpDate);   // 月次更新実行年月日
            dr[COL_GUID_TITLE] = suplAccPayWork.FileHeaderGuid;                                                 // GUID
            dr[COL_CREATEDATETIME] = suplAccPayWork.CreateDateTime;                                             // 作成日時
            dr[COL_UPDATEDATETIME] = suplAccPayWork.UpdateDateTime;                                             // 更新日時
            dr[COL_STOCKSLIPCOUNT] = suplAccPayWork.StockSlipCount;                                             // [5047]

            dr[COL_STMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.StMonCAddUpUpdDate); // 月次更新開始年月日
            dr[COL_LAMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.LaMonCAddUpUpdDate); // 前回月次更新年月日

            List<ACalcPayTotal> aCalcPayTotalList = new List<ACalcPayTotal>();
            if (aCalcPayTotalWorkArrayList != null)
            {
                foreach (ACalcPayTotalWork aCalcPayTotalWork in aCalcPayTotalWorkArrayList)
                {
                    aCalcPayTotalList.Add(UIDataFromParamData(aCalcPayTotalWork));
                }
            }
            dr[COL_PAYTOTAL] = aCalcPayTotalList;
        }

        /// <summary>
        /// 仕入先支払金額マスタワーク、精算支払集計データワークリスト→DataRow移項処理
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="suplierPayWork">仕入先支払金額マスタワーク</param>
        /// <param name="accPayTotalWorkArrayList">精算支払集計データワークリスト</param>
        private void DataRowFromParamData(ref DataRow dr, SuplierPayWork suplierPayWork, ArrayList accPayTotalWorkArrayList)
        {
            // 削除日
            if (suplierPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplierPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = suplierPayWork.AddUpSecCode;                                           // 計上拠点コード

            dr[COL_SUPPLIERCODE_TITLE] = suplierPayWork.SupplierCd;                                             // 仕入先コード
            dr[COL_SUPPLIERNAME_TITLE] = suplierPayWork.SupplierNm1;                                            // 仕入先名称
            dr[COL_SUPPLIERNAME2_TITLE] = suplierPayWork.SupplierNm2;                                           // 仕入先名称2
            dr[COL_SUPPLIERSNM_TITLE] = suplierPayWork.SupplierSnm;                                             // 仕入先略称

            dr[COL_RESULTSECCODE_TITLE] = suplierPayWork.ResultsSectCd;                                         // 実績拠点コード


            dr[COL_PAYEECODE_TITLE] = suplierPayWork.PayeeCode;                                                 // 支払先コード
            dr[COL_PAYEENAME_TITLE] = suplierPayWork.PayeeName;                                                 // 支払先名称
            dr[COL_PAYEENAME2_TITLE] = suplierPayWork.PayeeName2;                                               // 支払先名称2
            dr[COL_PAYEESNM_TITLE] = suplierPayWork.PayeeSnm;                                                   // 支払先略称
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", suplierPayWork.AddUpDate);     // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", suplierPayWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate);                   // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpYearMonth);         // _計上年月
            dr[COL_LASTTIMEDEMAND_TITLE] = suplierPayWork.LastTimePayment;                                      // 前回支払金額
            dr[COL_THISTIMEPAYNRML_TITLE] = suplierPayWork.ThisTimePayNrml;                                     // 今回支払金額（通常支払）
            dr[COL_THISTIMEFEEPAYNRML_TITLE] = suplierPayWork.ThisTimeFeePayNrml;                               // 今回手数料額（通常支払）
            dr[COL_THISTIMEDISPAYNRML_TITLE] = suplierPayWork.ThisTimeDisPayNrml;                               // 今回値引額（通常支払）
            dr[COL_THISTIMEPAYMENT_TITLE] = suplierPayWork.ThisTimePayNrml;                                     // 今回支払金額（通常支払）
            dr[COL_THISTIMETTLBLCDMD_TITLE] = suplierPayWork.ThisTimeTtlBlcPay;                                 // 今回繰越残高（支払計）
            dr[COL_THISTIMESTOCKPRICE_TITLE] = suplierPayWork.ThisTimeStockPrice;                               // 今回仕入金額
            dr[COL_THISSTCPRCTAX_TITLE] = suplierPayWork.ThisStcPrcTax;                                         // 今回仕入消費税
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplierPayWork.OfsThisTimeStock;                                   // 相殺後今回仕入金額
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplierPayWork.OfsThisStockTax;                                     // 相殺後今回仕入消費税
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = suplierPayWork.ItdedOffsetOutTax;                                 // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE] = suplierPayWork.ItdedOffsetInTax;                                   // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = suplierPayWork.ItdedOffsetTaxFree;                               // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE] = suplierPayWork.OffsetOutTax;                                           // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE] = suplierPayWork.OffsetInTax;                                             // 相殺後内税消費税
            dr[COL_ITDEDSTCOUTTAX_TITLE] = suplierPayWork.TtlItdedStcOutTax;                                    // 仕入外税対象額
            dr[COL_ITDEDSTCINTAX_TITLE] = suplierPayWork.TtlItdedStcInTax;                                      // 仕入内税対象額
            dr[COL_ITDEDSTCTAXFREE_TITLE] = suplierPayWork.TtlItdedStcTaxFree;                                  // 仕入非課税対象額
            dr[COL_TTLSTOCKOUTERTAX_TITLE] = suplierPayWork.TtlStockOuterTax;                                   // 仕入外税額
            dr[COL_TTLSTOCKINNERTAX_TITLE] = suplierPayWork.TtlStockInnerTax;                                   // 仕入内税額
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = suplierPayWork.TtlItdedRetOutTax;                                 // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE] = suplierPayWork.TtlItdedRetInTax;                                   // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = suplierPayWork.TtlItdedRetTaxFree;                               // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE] = suplierPayWork.TtlRetOuterTax;                                       // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE] = suplierPayWork.TtlRetInnerTax;                                       // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = suplierPayWork.TtlItdedDisOutTax;                                 // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE] = suplierPayWork.TtlItdedDisInTax;                                   // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = suplierPayWork.TtlItdedDisTaxFree;                               // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE] = suplierPayWork.TtlDisOuterTax;                                       // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE] = suplierPayWork.TtlDisInnerTax;                                       // 値引内税額
            dr[COL_BALANCEADJUST_TITLE] = suplierPayWork.BalanceAdjust;                                         // 残高調整額

            dr[COL_TAXADJUST_TITLE] = suplierPayWork.TaxAdjust;                                                 // 消費税調整額
            dr[COL_TOTALADJUST_TITLE] = suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;

            dr[COL_NONSTMNTAPPEARANCE_TITLE] = 0;                                                               // 未決済金額（自振）
            dr[COL_NONSTMNTISDONE_TITLE] = 0;                                                                   // 未決済金額（廻し） 
            dr[COL_STMNTAPPEARANCE_TITLE] = 0;                                                                  // 決済金額（自振）
            dr[COL_STMNTISDONE_TITLE] = 0;                                                                      // 決済金額（廻し）

            dr[COL_STOCKSLIPCOUNT] = suplierPayWork.StockSlipCount;                                             // 伝票枚数
            dr[COL_PAYMENTSCHEDULE] = TDateTime.DateTimeToLongDate(suplierPayWork.PaymentSchedule);             // 支払予定日
            dr[COL_PAYMENTCOND] = suplierPayWork.PaymentCond;                                                   // 回収条件

            dr[COL_SUPPCTAXLAYCD_TITLE] = suplierPayWork.SuppCTaxLayCd;                                         // 消費税転嫁方式
            dr[COL_SUPPLIERCONSTAXRATE_TITLE] = suplierPayWork.SupplierConsTaxRate;                             // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE] = suplierPayWork.FractionProcCd;                                       // 端数処理区分
            dr[COL_AFCALDEMANDPRICE_TITLE] = suplierPayWork.StockTotalPayBalance + suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;                                       // 計算後支払金額
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE] = suplierPayWork.StockTtl2TmBfBlPay;                              // 受注2回前残高（支払計）
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE] = suplierPayWork.StockTtl3TmBfBlPay;                              // 受注3回前残高（支払計）
            dr[COL_CADDUPUPDEXECDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.CAddUpUpdExecDate);   // 締次更新実行年月日

            dr[COL_GUID_TITLE] = suplierPayWork.FileHeaderGuid;                                                 // GUID
            dr[COL_CREATEDATETIME] = suplierPayWork.CreateDateTime;                                             // 作成日時
            dr[COL_UPDATEDATETIME] = suplierPayWork.UpdateDateTime;                                             // 更新日時

            dr[COL_STARTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.StartCAddUpUpdDate); // 締次更新開始年月日
            dr[COL_LASTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.LastCAddUpUpdDate);   // 前回締次更新年月日

            List<AccPayTotal> accPayTotalList = new List<AccPayTotal>();
            if (accPayTotalWorkArrayList != null)
            {
                foreach (AccPayTotalWork accPayTotalWork in accPayTotalWorkArrayList)
                {
                    accPayTotalList.Add(UIDataFromParamData(accPayTotalWork));
                }
            }
            dr[COL_PAYTOTAL] = accPayTotalList;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="aCalcPayTotalWork">買掛支払集計データワーク</param>
        /// <returns>買掛支払集計データ</returns>
        private ACalcPayTotal UIDataFromParamData(ACalcPayTotalWork aCalcPayTotalWork)
        {
            ACalcPayTotal aCalcPayTotal = new ACalcPayTotal();

            aCalcPayTotal.CreateDateTime = aCalcPayTotalWork.CreateDateTime; // 作成日時
            aCalcPayTotal.UpdateDateTime = aCalcPayTotalWork.UpdateDateTime; // 更新日時
            aCalcPayTotal.EnterpriseCode = aCalcPayTotalWork.EnterpriseCode; // 企業コード
            aCalcPayTotal.FileHeaderGuid = aCalcPayTotalWork.FileHeaderGuid; // GUID
            aCalcPayTotal.UpdEmployeeCode = aCalcPayTotalWork.UpdEmployeeCode; // 更新従業員コード
            aCalcPayTotal.UpdAssemblyId1 = aCalcPayTotalWork.UpdAssemblyId1; // 更新アセンブリID1
            aCalcPayTotal.UpdAssemblyId2 = aCalcPayTotalWork.UpdAssemblyId2; // 更新アセンブリID2
            aCalcPayTotal.LogicalDeleteCode = aCalcPayTotalWork.LogicalDeleteCode; // 論理削除区分
            aCalcPayTotal.AddUpSecCode = aCalcPayTotalWork.AddUpSecCode; // 計上拠点コード
            aCalcPayTotal.PayeeCode = aCalcPayTotalWork.PayeeCode; // 支払先コード
            aCalcPayTotal.SupplierCd = aCalcPayTotalWork.SupplierCd; // 仕入先コード
            aCalcPayTotal.AddUpDate = aCalcPayTotalWork.AddUpDate; // 計上年月日
            aCalcPayTotal.MoneyKindCode = aCalcPayTotalWork.MoneyKindCode; // 金種コード
            aCalcPayTotal.MoneyKindName = aCalcPayTotalWork.MoneyKindName; // 金種名称
            aCalcPayTotal.MoneyKindDiv = aCalcPayTotalWork.MoneyKindDiv; // 金種区分
            aCalcPayTotal.Payment = aCalcPayTotalWork.Payment; // 支払金額

            return aCalcPayTotal;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="aCalcPayTotalWork">精算支払集計データワーク</param>
        /// <returns>精算支払集計データ</returns>
        private AccPayTotal UIDataFromParamData(AccPayTotalWork accPayTotalWork)
        {
            AccPayTotal accPayTotal = new AccPayTotal();

            accPayTotal.CreateDateTime = accPayTotalWork.CreateDateTime; // 作成日時
            accPayTotal.UpdateDateTime = accPayTotalWork.UpdateDateTime; // 更新日時
            accPayTotal.EnterpriseCode = accPayTotalWork.EnterpriseCode; // 企業コード
            accPayTotal.FileHeaderGuid = accPayTotalWork.FileHeaderGuid; // GUID
            accPayTotal.UpdEmployeeCode = accPayTotalWork.UpdEmployeeCode; // 更新従業員コード
            accPayTotal.UpdAssemblyId1 = accPayTotalWork.UpdAssemblyId1; // 更新アセンブリID1
            accPayTotal.UpdAssemblyId2 = accPayTotalWork.UpdAssemblyId2; // 更新アセンブリID2
            accPayTotal.LogicalDeleteCode = accPayTotalWork.LogicalDeleteCode; // 論理削除区分
            accPayTotal.AddUpSecCode = accPayTotalWork.AddUpSecCode; // 計上拠点コード
            accPayTotal.PayeeCode = accPayTotalWork.PayeeCode; // 支払先コード
            accPayTotal.SupplierCd = accPayTotalWork.SupplierCd; // 仕入先コード
            accPayTotal.AddUpDate = accPayTotalWork.AddUpDate; // 計上年月日
            accPayTotal.MoneyKindCode = accPayTotalWork.MoneyKindCode; // 金種コード
            accPayTotal.MoneyKindName = accPayTotalWork.MoneyKindName; // 金種名称
            accPayTotal.MoneyKindDiv = accPayTotalWork.MoneyKindDiv; // 金種区分
            accPayTotal.Payment = accPayTotalWork.Payment; // 支払金額

            return accPayTotal;
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="source">買掛支払集計データ</param>
        /// <returns>買掛支払集計データワーク</returns>
        private static ACalcPayTotalWork ParamDataFromUIData(ACalcPayTotal aCalcPayTotal)
        {
            ACalcPayTotalWork aCalcPayTotalWork = new ACalcPayTotalWork();

            aCalcPayTotalWork.CreateDateTime = aCalcPayTotal.CreateDateTime; // 作成日時
            aCalcPayTotalWork.UpdateDateTime = aCalcPayTotal.UpdateDateTime; // 更新日時
            aCalcPayTotalWork.EnterpriseCode = aCalcPayTotal.EnterpriseCode; // 企業コード
            aCalcPayTotalWork.FileHeaderGuid = aCalcPayTotal.FileHeaderGuid; // GUID
            aCalcPayTotalWork.UpdEmployeeCode = aCalcPayTotal.UpdEmployeeCode; // 更新従業員コード
            aCalcPayTotalWork.UpdAssemblyId1 = aCalcPayTotal.UpdAssemblyId1; // 更新アセンブリID1
            aCalcPayTotalWork.UpdAssemblyId2 = aCalcPayTotal.UpdAssemblyId2; // 更新アセンブリID2
            aCalcPayTotalWork.LogicalDeleteCode = aCalcPayTotal.LogicalDeleteCode; // 論理削除区分
            aCalcPayTotalWork.AddUpSecCode = aCalcPayTotal.AddUpSecCode; // 計上拠点コード
            aCalcPayTotalWork.PayeeCode = aCalcPayTotal.PayeeCode; // 支払先コード
            aCalcPayTotalWork.SupplierCd = aCalcPayTotal.SupplierCd; // 仕入先コード
            aCalcPayTotalWork.AddUpDate = aCalcPayTotal.AddUpDate; // 計上年月日
            aCalcPayTotalWork.MoneyKindCode = aCalcPayTotal.MoneyKindCode; // 金種コード
            aCalcPayTotalWork.MoneyKindName = aCalcPayTotal.MoneyKindName; // 金種名称
            aCalcPayTotalWork.MoneyKindDiv = aCalcPayTotal.MoneyKindDiv; // 金種区分
            aCalcPayTotalWork.Payment = aCalcPayTotal.Payment; // 支払金額


            return aCalcPayTotalWork;
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="source">精算支払集計データ</param>
        /// <returns>精算支払集計データワーク</returns>
        private static AccPayTotalWork ParamDataFromUIData(AccPayTotal accPayTotal)
        {
            AccPayTotalWork accPayTotalWork = new AccPayTotalWork();

            accPayTotalWork.CreateDateTime = accPayTotal.CreateDateTime; // 作成日時
            accPayTotalWork.UpdateDateTime = accPayTotal.UpdateDateTime; // 更新日時
            accPayTotalWork.EnterpriseCode = accPayTotal.EnterpriseCode; // 企業コード
            accPayTotalWork.FileHeaderGuid = accPayTotal.FileHeaderGuid; // GUID
            accPayTotalWork.UpdEmployeeCode = accPayTotal.UpdEmployeeCode; // 更新従業員コード
            accPayTotalWork.UpdAssemblyId1 = accPayTotal.UpdAssemblyId1; // 更新アセンブリID1
            accPayTotalWork.UpdAssemblyId2 = accPayTotal.UpdAssemblyId2; // 更新アセンブリID2
            accPayTotalWork.LogicalDeleteCode = accPayTotal.LogicalDeleteCode; // 論理削除区分
            accPayTotalWork.AddUpSecCode = accPayTotal.AddUpSecCode; // 計上拠点コード
            accPayTotalWork.PayeeCode = accPayTotal.PayeeCode; // 支払先コード
            accPayTotalWork.SupplierCd = accPayTotal.SupplierCd; // 仕入先コード
            accPayTotalWork.AddUpDate = accPayTotal.AddUpDate; // 計上年月日
            accPayTotalWork.MoneyKindCode = accPayTotal.MoneyKindCode; // 金種コード
            accPayTotalWork.MoneyKindName = accPayTotal.MoneyKindName; // 金種名称
            accPayTotalWork.MoneyKindDiv = accPayTotal.MoneyKindDiv; // 金種区分
            accPayTotalWork.Payment = accPayTotal.Payment; // 支払金額

            return accPayTotalWork;
        }
        // 2009.01.14 Add <<<


        #endregion

        // 2009.01.14 Add >>>
        // --------------------------------------------------
        #region 金種名称取得用処理

        /// <summary>
        /// 金種名称取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="depositStKindCd">金種コード</param>   
        /// <remarks>
        /// <br>Update Note : 金種名称を取得します。</br>
        /// <br>Programmer  : 21024  佐々木 健</br>
        /// <br>Date        : 2009.01.14</br>
        /// </remarks>
        public string GetDepsitStKindNm(string enterpriseCode, int depositStKindCd)
        {
            int status = 0;
            int moneyKindMode = 1;

            ArrayList allMoneyKindList = new ArrayList();
            Hashtable moneyKindTable = new Hashtable();

            // 金額種別マスタより、論理削除分も含むデータを取得
            status = this._moneyKindAcs.GetBuff(out allMoneyKindList, enterpriseCode, moneyKindMode);

            if (status == 0)
            {
                foreach (MoneyKind moneyKindInfo in allMoneyKindList)
                {
                    // 金額設定区分が「0:入金」の場合、比較
                    if (( moneyKindInfo.PriceStCode == 0 ) && ( moneyKindInfo.MoneyKindCode == depositStKindCd ))
                    {
                        if (moneyKindInfo.LogicalDeleteCode == 0)
                        {
                            return moneyKindInfo.MoneyKindName;
                        }
                        else
                        {
                            return "削除済";
                        }
                    }
                }

                return "未登録";
            }
            else
            {
                return "";
            }
        }
        #endregion
        // 2009.01.14 Add <<<

        // --------------------------------------------------
		#region 比較用クラス

        /// <summary>仕入先買掛金額マスタ比較クラス</summary>
        /// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class SuplAccPayCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>比較用メソッド</summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 仕入先買掛金額マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 30154 安藤 昌仁</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                SuplAccPay obj1 = x as SuplAccPay;
                SuplAccPay obj2 = y as SuplAccPay;

                // キー情報で比較する
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.SupplierCd + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.SupplierCd + "_" + obj2.AddUpDate;
                // 仕入先買掛金額出力マスタのキーで比較
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        /// <summary>仕入先支払金額マスタ比較クラス</summary>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class SuplierPayCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>比較用メソッド</summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 仕入先支払金額マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 30154 安藤 昌仁</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                SuplierPay obj1 = x as SuplierPay;
                SuplierPay obj2 = y as SuplierPay;

                // キー情報で比較する
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.SupplierCd + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.SupplierCd + "_" + obj2.AddUpDate;
                // 仕入先支払金額出力マスタのキーで比較
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        #endregion

    }
}
