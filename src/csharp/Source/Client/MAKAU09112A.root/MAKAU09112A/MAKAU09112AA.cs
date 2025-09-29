//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先実績修正
// プログラム概要   ：得意先実績修正の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：21024 佐々木 健
// 修正日    2009/01/06     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/01/30     修正内容：障害ID:10603対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/23     修正内容：Mantis【13484】請求書Noを追加
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
    ///得意先売掛金額マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先売掛金額マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30154 安藤 昌仁</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Note       : 流通.NS用に変更</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br></br>
    /// <br>Note       : PM.NS用に変更</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.06</br>
    /// <br></br>
    /// <br>Note       : 障害ID:10603対応</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2009.01.30</br>
    /// </remarks>
	public class CustAccRecDmdPrcAcs
	{
		// --------------------------------------------------
		#region Private Members

        // 企業コード
        private string              _enterpriseCode         = "";

        /// <summary>得意先売掛金額マスタリモートオブジェクト格納バッファ</summary>
        private ICustRsltUpdDB _iCustRsltUpdDB = null;

        // データセット
        private DataSet             _bindDataSet        = null;
        private DataTable           _custAccRecTable    = null;
        private DataTable           _custDmdPrcTable    = null;
        // 2009.01.06 Add >>>
        private DataTable _custAccRecTotalTable = null;
        private DataTable _custDmdPrcTotalTable = null;
        // 2009.01.06 Add <<<
        

        // マスタクラス格納リスト
        private Dictionary<Guid, CustAccRecWork>  _custAccRecDic  = null;               // 得意先売掛金額マスタ格納用
        private Dictionary<Guid, CustDmdPrcWork>  _custDmdPrcDic  = null;               // 得意先請求金額マスタ格納用

        // マスタ取得用リスト
        // 2009.01.06 >>>
        //private ArrayList           _custAccRecList     = null;                         // 得意先売掛金額マスタ取得用
        //private ArrayList           _custDmdPrcList     = null;                         // 得意先請求金額マスタ取得用
        private CustomSerializeArrayList _custAccRecList = null;                         // 得意先売掛金額マスタ取得用
        private CustomSerializeArrayList _custDmdPrcList = null;                         // 得意先請求金額マスタ取得用

        MoneyKindAcs _moneyKindAcs = null;
        // 2009.01.06 <<<

        #endregion

        // --------------------------------------------------
        #region Public Members

        // FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        public static readonly string TBL_CUSTACCREC_TITLE           = "CUSTACCREC_TABLE";
        public static readonly string TBL_CUSTDMDPRC_TITLE           = "CUSTDMDPRC_TABLE";
        //public static readonly string TBL_CUSTACCREC_TITLE           = "campanyTab";
        //public static readonly string TBL_CUSTDMDPRC_TITLE           = "customerTab";

        // 2009.01.06 Add >>>
        public static readonly string TBL_CUSTACCRECTOTAL_TITLE = "CUSTACCRECTOTAL_TABLE";
        public static readonly string TBL_CUSTDMDPRCTOTAL_TITLE = "CUSTDMDPRCTOTAL_TABLE";
        // 2009.01.06 Add <<<
        
        public static readonly string COL_DELETEDATE_TITLE           = "削除日";
        public static readonly string COL_ADDUPSECCODE_TITLE         = "計上拠点コード";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        public static readonly string COL_RESULTSECCODE_TITLE       = "実績拠点コード";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
        
        public static readonly string COL_CUSTOMERCODE_TITLE         = "得意先コード";
        public static readonly string COL_CUSTOMERNAME_TITLE         = "得意先名称";
        public static readonly string COL_CUSTOMERNAME2_TITLE        = "得意先名称2";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_CUSTOMERSNM_TITLE          = "得意先略称";
        public static readonly string COL_CLAIMCODE_TITLE            = "請求先コード";
        public static readonly string COL_CLAIMNAME_TITLE            = "請求先名称";
        public static readonly string COL_CLAIMNAME2_TITLE           = "請求先名称2";
        public static readonly string COL_CLAIMSNM_TITLE             = "請求先略称";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_ADDUPDATEJP_TITLE          = "計上日";
        public static readonly string COL_ADDUPYEARMONTHJP_TITLE     = "計上年月";
		public static readonly string COL_ADDUPYEARMONTH_TITLE       = "_計上年月";
		public static readonly string COL_ADDUPDATE_TITLE            = "_計上年月日";
        public static readonly string COL_LASTTIMEACCREC_TITLE       = "前回残高";                  // 前回売掛金額
        public static readonly string COL_LASTTIMEDEMAND_TITLE       = "前回残高";                  // 前回請求金額
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_THISTIMEDMDNRML_TITLE      = "今回入金金額（通常入金）";
        //public static readonly string COL_THISTIMEFEEDMDNRML_TITLE   = "今回手数料額（通常入金）";
        //public static readonly string COL_THISTIMEDISDMDNRML_TITLE   = "今回値引額（通常入金）";
        //public static readonly string COL_THISTIMERBTDMDNRML_TITLE   = "今回リベート額（通常入金）";
        //public static readonly string COL_THISTIMEDMDDEPO_TITLE      = "今回入金金額（預り金）";
        //public static readonly string COL_THISTIMEFEEDMDDEPO_TITLE   = "今回手数料額（預り金）";
        //public static readonly string COL_THISTIMEDISDMDDEPO_TITLE   = "今回値引額（預り金）";
        //public static readonly string COL_THISTIMERBTDMDDEPO_TITLE   = "今回リベート額（預り金）";
        public static readonly string COL_THISTIMEDMDNRML_TITLE      = "今回入金金額";
        public static readonly string COL_THISTIMEFEEDMDNRML_TITLE   = "今回手数料額";
        public static readonly string COL_THISTIMEDISDMDNRML_TITLE   = "今回値引額";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_THISTIMEDEPODMD_TITLE      = "今回入金";
        public static readonly string COL_THISTIMETTLBLCACC_TITLE    = "今回繰越残高（売掛計）";
        public static readonly string COL_THISTIMETTLBLCDMD_TITLE    = "今回繰越残高（請求計）";
        public static readonly string COL_THISTIMESALES_TITLE        = "今回売上金額";                  // 今回売上金額
        public static readonly string COL_THISSALESTAX_TITLE         = "今回売上消費税";                    // 今回売上消費税
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_TTLINCDTBTTAXEXC_TITLE     = "今回支払";                  // 支払インセンティブ額合計（税抜き）
        //public static readonly string COL_TTLINCDTBTTAX_TITLE        = "支払消費税";                // 支払インセンティブ額合計（税）
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_OFSTHISTIMESALES_TITLE     = "今回売上";  // 純売上金額
        public static readonly string COL_OFSTHISSALESTAX_TITLE      = "消費税";    // 純売上消費税
        public static readonly string COL_ITDEDOFFSETOUTTAX_TITLE    = "相殺後外税対象額";
        public static readonly string COL_ITDEDOFFSETINTAX_TITLE     = "相殺後内税対象額";
        public static readonly string COL_ITDEDOFFSETTAXFREE_TITLE   = "相殺後非課税対象額";
        public static readonly string COL_OFFSETOUTTAX_TITLE         = "相殺後外税消費税";
        public static readonly string COL_OFFSETINTAX_TITLE          = "相殺後内税消費税";
        public static readonly string COL_ITDEDSALESOUTTAX_TITLE     = "売上外税対象額";
        public static readonly string COL_ITDEDSALESINTAX_TITLE      = "売上内税対象額";
        public static readonly string COL_ITDEDSALESTAXFREE_TITLE    = "売上非課税対象額";
        public static readonly string COL_SALESOUTTAX_TITLE          = "売上外税額";
        public static readonly string COL_SALESINTAX_TITLE           = "売上内税額";
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
        public static readonly string COL_BALANCEADJUST_TITLE        = "残高調整額";

        public static readonly string COL_NONSTMNTAPPEARANCE_TITLE   = "未決済金額（自振）";
        public static readonly string COL_NONSTMNTISDONE_TITLE       = "未決済金額（廻し）";
        public static readonly string COL_STMNTAPPEARANCE_TITLE      = "決済金額（自振）";
        public static readonly string COL_STMNTISDONE_TITLE          = "決済金額（廻し）";

        //public static readonly string COL_THISCASHSALEPRICE          = "今回現金売上額";
        //public static readonly string COL_THISCASHSALETAX            = "今回現金売上消費税額";
        public static readonly string COL_SALESSLIPCOUNT_TITLE             = "売上伝票枚数";
        public static readonly string COL_BILLPRINTDATE_TITLE              = "請求書発行日";
        public static readonly string COL_EXPECTEDDEPOSITDATE_TITLE        = "入金予定日";
        public static readonly string COL_COLLECTCOND_TITLE                = "回収条件";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_CONSTAXLAYMETHOD_TITLE     = "消費税転嫁方式";
        public static readonly string COL_CONSTAXRATE_TITLE          = "消費税率";
        public static readonly string COL_FRACTIONPROCCD_TITLE       = "端数処理区分";
        public static readonly string COL_AFCALTMONTHACCREC_TITLE    = "売掛残高";                  // 計算後当月売掛金額
        public static readonly string COL_AFCALDEMANDPRICE_TITLE     = "売掛残高";                  // 計算後請求金額
        public static readonly string COL_ACPODRTTL2TMBFACCREC_TITLE = "前々回残高";              // 受注2回前残高(売掛計)
        public static readonly string COL_ACPODRTTL2TMBFBLDMD_TITLE  = "前々回残高";              // 受注2回前残高(請求計)
        public static readonly string COL_ACPODRTTL3TMBFACCREC_TITLE = "前々々回残高";              // 受注3回前残高(売掛計)
        public static readonly string COL_ACPODRTTL3TMBFBLDMD_TITLE  = "前々々回残高";              // 受注3回前残高(請求計)
        public static readonly string COL_MONTHADDUPEXPDATE_TITLE    = "月次更新実行年月日";
        public static readonly string COL_CADDUPUPDEXECDATE_TITLE    = "締次更新実行年月日";
        // 2009.01.06 Add >>>
        public static readonly string COL_STMONCADDUPUPDDATE_TITLE = "月次更新開始年月日";
        public static readonly string COL_LAMONCADDUPUPDDATE_TITLE = "前回月次更新年月日";
        public static readonly string COL_STARTCADDUPUPDDATE_TITLE = "締次更新開始年月日";
        public static readonly string COL_LASTCADDUPUPDDATE_TITLE = "前回締次更新年月日";
        // 2009.01.06 Add <<<
        public static readonly string COL_DMDPROCNUM_TITLE           = "請求処理通番";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_THISPAYOFFSET_TITLE        = "今回支払相殺金額";
        //public static readonly string COL_THISPAYOFFSETTAX_TITLE     = "今回支払相殺消費税";
        //public static readonly string COL_ITDEDPAYMOUTTAX_TITLE      = "支払外税対象額";
        //public static readonly string COL_ITDEDPAYMINTAX_TITLE       = "支払内税対象額";
        //public static readonly string COL_ITDEDPAYMTAXFREE_TITLE     = "支払非課税対象額";
        //public static readonly string COL_PAYMENTOUTTAX_TITLE        = "支払外税消費税";
        //public static readonly string COL_PAYMENTINTAX_TITLE         = "支払内税消費税";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

        public static readonly string COL_TAXADJUST_TITLE = "消費税調整額";
        public static readonly string COL_TOTALADJUST_TITLE = "残高調整額表示";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        public static readonly string COL_GUID_TITLE                 = "GUID";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_CREATEDATETIME             = "作成日時";
        public static readonly string COL_UPDATEDATETIME             = "更新日時";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // ADD 2009/06/23 ------>>>
        public static readonly string COL_BILLNO_TITLE = "請求書No";
        // ADD 2009/06/23 ------<<<
        
        // 2009.01.06 Add >>>
        public static readonly string COL_DEPOTOTAL = "入金集計データ";
        public static readonly string ALL_SECTION = "00";
        // 2009.01.06 Add <<<

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>得意先売掛金額マスタテーブルアクセスクラスコンストラクタ</summary>
		/// <remarks>
        /// <br>Note       : 得意先売掛金額マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public CustAccRecDmdPrcAcs()
		{
			try {
				// 企業コード取得
				this._enterpriseCode          = LoginInfoAcquisition.EnterpriseCode;

				// リモートオブジェクト取得
                this._iCustRsltUpdDB          = (ICustRsltUpdDB)MediationCustRsltUpdDB.GetCustRsltUpdDB();

                // マスタクラス格納リスト初期化
                this._custAccRecDic       = new Dictionary<Guid, CustAccRecWork>();
                this._custDmdPrcDic       = new Dictionary<Guid, CustDmdPrcWork>();

                // マスタ取得用リスト初期化
                // 2009.01.06 >>>
                //this._custAccRecList      = new ArrayList();
                //this._custDmdPrcList      = new ArrayList();
                this._custAccRecList = new CustomSerializeArrayList();
                this._custDmdPrcList = new CustomSerializeArrayList();

                this._moneyKindAcs = new MoneyKindAcs();
                // 2009.01.06 <<<

                // データセット初期化
                this._bindDataSet             = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // データセット列情報構築
                this.DataSetColumnConstruction();
			}
            catch ( Exception )
            {
                // オフライン時はnullをセット
                this._iCustRsltUpdDB = null;
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
			// 得意先売掛金額マスタテーブル
            this._custAccRecTable = new DataTable(TBL_CUSTACCREC_TITLE);

			// Addを行う順番が、列の表示順位となります。
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_CREATEDATETIME,             typeof( DateTime ) );    // 作成日時
            this._custAccRecTable.Columns.Add(COL_UPDATEDATETIME,             typeof( DateTime ) );    // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_DELETEDATE_TITLE,           typeof(string));  // 削除日
            this._custAccRecTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // 計上拠点コード
            this._custAccRecTable.Columns.Add(COL_CUSTOMERCODE_TITLE,         typeof(Int32));   // 得意先コード
            this._custAccRecTable.Columns.Add(COL_CUSTOMERNAME_TITLE,         typeof(string));  // 得意先名称
            this._custAccRecTable.Columns.Add(COL_CUSTOMERNAME2_TITLE,        typeof(string));  // 得意先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_CUSTOMERSNM_TITLE,          typeof(string));  // 得意先略称
            this._custAccRecTable.Columns.Add(COL_CLAIMCODE_TITLE,            typeof(Int32));   // 請求先コード
            this._custAccRecTable.Columns.Add(COL_CLAIMNAME_TITLE,            typeof(string));  // 請求先名称
            this._custAccRecTable.Columns.Add(COL_CLAIMNAME2_TITLE,           typeof(string));  // 請求先名称2
            this._custAccRecTable.Columns.Add(COL_CLAIMSNM_TITLE,             typeof(string));  // 請求先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // 計上年月日
            // 2009.01.06 Add >>>
            this._custAccRecTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "月次更新日";        // 計上年月日のキャプション
            // 2009.01.06 Add <<<
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // 計上年月
            this._custAccRecTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _計上年月
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _計上年月日
            this._custAccRecTable.Columns.Add(COL_THISTIMEDMDNRML_TITLE,      typeof(Int64));   // 今回入金金額（通常入金）
            this._custAccRecTable.Columns.Add(COL_THISTIMEFEEDMDNRML_TITLE,   typeof(Int64));   // 今回手数料額（通常入金）
            this._custAccRecTable.Columns.Add(COL_THISTIMEDISDMDNRML_TITLE,   typeof(Int64));   // 今回値引額（通常入金）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // 今回リベート額（通常入金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // 今回入金金額（預り金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // 今回手数料額（預り金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // 今回値引額（預り金）
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMETTLBLCACC_TITLE,    typeof(Int64));   // 今回繰越残高（売掛計）
            //this._custAccRecTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // 相殺後今回売上金額
            //this._custAccRecTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // 相殺後今回売上消費税
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // 相殺後外税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // 相殺後内税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // 相殺後非課税対象額
            this._custAccRecTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // 相殺後外税消費税
            this._custAccRecTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // 相殺後内税消費税
            this._custAccRecTable.Columns.Add(COL_ITDEDSALESOUTTAX_TITLE,     typeof(Int64));   // 売上外税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDSALESINTAX_TITLE,      typeof(Int64));   // 売上内税対象額
            this._custAccRecTable.Columns.Add(COL_ITDEDSALESTAXFREE_TITLE,    typeof(Int64));   // 売上非課税対象額
            this._custAccRecTable.Columns.Add(COL_SALESOUTTAX_TITLE,          typeof(Int64));   // 売上外税額
            this._custAccRecTable.Columns.Add(COL_SALESINTAX_TITLE,           typeof(Int64));   // 売上内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // 支払外税対象額
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // 支払内税対象額
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // 支払非課税対象額
            //this._custAccRecTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // 支払外税消費税
            //this._custAccRecTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_CONSTAXLAYMETHOD_TITLE,     typeof(Int32));   // 消費税転嫁方式
            this._custAccRecTable.Columns.Add(COL_CONSTAXRATE_TITLE,          typeof(Double));  // 消費税率
            this._custAccRecTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // 端数処理区分
            this._custAccRecTable.Columns.Add(COL_MONTHADDUPEXPDATE_TITLE,    typeof(Int32));   // 月次更新実行年月日
            this._custAccRecTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custAccRecTable.Columns.Add(COL_ACPODRTTL3TMBFACCREC_TITLE, typeof(Int64));   // 受注3回前残高（売掛計）
            this._custAccRecTable.Columns.Add(COL_ACPODRTTL2TMBFACCREC_TITLE, typeof(Int64));   // 受注2回前残高（売掛計）
            this._custAccRecTable.Columns.Add(COL_LASTTIMEACCREC_TITLE,       typeof(Int64));   // 前回売掛金額
            this._custAccRecTable.Columns.Add(COL_THISTIMESALES_TITLE,        typeof(Int64));   // 今回売上金額
            this._custAccRecTable.Columns.Add(COL_THISSALESTAX_TITLE,         typeof(Int64));   // 今回売上消費税
            this._custAccRecTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // 相殺後今回売上金額
            this._custAccRecTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // 相殺後今回売上消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // 支払インセンティブ額合計（税抜き）
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMEDEPODMD_TITLE,      typeof(Int64));   // 今回入金
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
            this._custAccRecTable.Columns.Add(COL_TOTALADJUST_TITLE,          typeof(Int64));   // 残高調整額標示用
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // 未決済金額（自振）
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // 未決済金額（廻し）
            //this._custAccRecTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // 決済金額（自振）
            //this._custAccRecTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //this._custAccRecTable.Columns.Add(COL_THISCASHSALEPRICE,          typeof(Int64));   // 今回売上金額
            //this._custAccRecTable.Columns.Add(COL_THISCASHSALETAX,            typeof(Int64));   // 今回売上金消費税額
            this._custAccRecTable.Columns.Add(COL_SALESSLIPCOUNT_TITLE,             typeof(Int64));   // 売上伝票枚数
            this._custAccRecTable.Columns.Add(COL_BILLPRINTDATE_TITLE,              typeof(Int64));   // 請求書発行日
            this._custAccRecTable.Columns.Add(COL_EXPECTEDDEPOSITDATE_TITLE,        typeof(Int64));   // 入金予定日
            this._custAccRecTable.Columns.Add(COL_COLLECTCOND_TITLE,                typeof(Int64));   // 回収条件
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_AFCALTMONTHACCREC_TITLE,    typeof(Int64));   // 計算後当月売掛金額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add( COL_THISPAYOFFSET_TITLE, typeof( Int64 ) ); // 今回支払相殺金額
            //this._custAccRecTable.Columns.Add( COL_THISPAYOFFSETTAX_TITLE, typeof( Int64 ) ); // 今回支払相殺消費税
            //this._custAccRecTable.Columns.Add( COL_ITDEDPAYMOUTTAX_TITLE, typeof( Int64 ) ); // 支払外税対象額
            //this._custAccRecTable.Columns.Add( COL_ITDEDPAYMINTAX_TITLE, typeof( Int64 ) ); // 支払内税対象額
            //this._custAccRecTable.Columns.Add( COL_ITDEDPAYMTAXFREE_TITLE, typeof( Int64 ) ); // 支払非課税対象額
            //this._custAccRecTable.Columns.Add( COL_PAYMENTOUTTAX_TITLE, typeof( Int64 ) ); // 支払外税消費税
            //this._custAccRecTable.Columns.Add( COL_PAYMENTINTAX_TITLE, typeof( Int64 ) ); // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            this._custAccRecTable.Columns.Add( COL_TAXADJUST_TITLE, typeof( Int64 ) ); // 消費税調整額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            this._custAccRecTable.Columns.Add(COL_STMONCADDUPUPDDATE_TITLE, typeof(Int32));     // 月次更新開始年月日
            this._custAccRecTable.Columns.Add(COL_LAMONCADDUPUPDDATE_TITLE, typeof(Int32));     // 前回月次更新年月日
            this._custAccRecTable.Columns.Add(COL_DEPOTOTAL, typeof(List<AccRecDepoTotal>));    // 入金集計データ
            // 2009.01.06 Add <<<
            
            // PrimaryKey設定
            this._custAccRecTable.PrimaryKey = new DataColumn[] { this._custAccRecTable.Columns[COL_ADDUPSECCODE_TITLE],    // 計上拠点コード
                                                                  this._custAccRecTable.Columns[COL_CLAIMCODE_TITLE],       // 請求先コード
                                                                  this._custAccRecTable.Columns[COL_CUSTOMERCODE_TITLE],    // 得意先コード
                                                                  this._custAccRecTable.Columns[COL_ADDUPDATE_TITLE]};            // 計上年月日

            this._bindDataSet.Tables.Add(this._custAccRecTable);

            // 2009.01.06 Add >>>
            this._custAccRecTotalTable = new DataTable(TBL_CUSTACCRECTOTAL_TITLE);
            this._custAccRecTotalTable = this._custAccRecTable.Clone();
            this._custAccRecTotalTable.TableName = TBL_CUSTACCRECTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custAccRecTotalTable);
            // 2009.01.06 Add <<<

        			// 得意先売掛金額マスタテーブル
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            // 得意先請求金額マスタテーブル
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
            this._custDmdPrcTable = new DataTable(TBL_CUSTDMDPRC_TITLE);

			// Addを行う順番が、列の表示順位となります。
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_CREATEDATETIME,             typeof( DateTime ) );    // 作成日時
            this._custDmdPrcTable.Columns.Add(COL_UPDATEDATETIME,             typeof( DateTime ) );    // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add( COL_DELETEDATE_TITLE,          typeof( string ) );  // 削除日
            this._custDmdPrcTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // 計上拠点コード

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            this._custDmdPrcTable.Columns.Add(COL_RESULTSECCODE_TITLE,        typeof(string));  // 実績拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERCODE_TITLE,         typeof(Int32));   // 得意先コード
            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERNAME_TITLE,         typeof(string));  // 得意先名称
            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERNAME2_TITLE,        typeof(string));  // 得意先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERSNM_TITLE,          typeof(string));  // 得意先略称
            this._custDmdPrcTable.Columns.Add(COL_CLAIMCODE_TITLE,            typeof(Int32));   // 請求先コード
            this._custDmdPrcTable.Columns.Add(COL_CLAIMNAME_TITLE,            typeof(string));  // 請求先名称
            this._custDmdPrcTable.Columns.Add(COL_CLAIMNAME2_TITLE,           typeof(string));  // 請求先名称2
            this._custDmdPrcTable.Columns.Add(COL_CLAIMSNM_TITLE,             typeof(string));  // 請求先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // 計上年月日
            // 2009.01.06 Add >>>
            this._custDmdPrcTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "締処理日";          // 計上年月日のキャプション
            // 2009.01.06 Add <<<
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // 計上年月
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _計上年月
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _計上年月日
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDMDNRML_TITLE,      typeof(Int64));   // 今回入金金額（通常入金）
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEDMDNRML_TITLE,   typeof(Int64));   // 今回手数料額（通常入金）
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISDMDNRML_TITLE,   typeof(Int64));   // 今回値引額（通常入金）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // 今回リベート額（通常入金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // 今回入金金額（預り金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // 今回手数料額（預り金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // 今回値引額（預り金）
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMETTLBLCDMD_TITLE,    typeof(Int64));   // 今回繰越残高（請求計）
            //this._custDmdPrcTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // 相殺後今回売上金額
            //this._custDmdPrcTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // 相殺後今回売上消費税
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // 相殺後外税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // 相殺後内税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // 相殺後非課税対象額
            this._custDmdPrcTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // 相殺後外税消費税
            this._custDmdPrcTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // 相殺後内税消費税
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSALESOUTTAX_TITLE,     typeof(Int64));   // 売上外税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSALESINTAX_TITLE,      typeof(Int64));   // 売上内税対象額
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSALESTAXFREE_TITLE,    typeof(Int64));   // 売上非課税対象額
            this._custDmdPrcTable.Columns.Add(COL_SALESOUTTAX_TITLE,          typeof(Int64));   // 売上外税額
            this._custDmdPrcTable.Columns.Add(COL_SALESINTAX_TITLE,           typeof(Int64));   // 売上内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // 支払外税対象額
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // 支払内税対象額
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // 支払非課税対象額
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // 支払外税消費税
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_CONSTAXLAYMETHOD_TITLE,     typeof(Int32));   // 消費税転嫁方式
            this._custDmdPrcTable.Columns.Add(COL_CONSTAXRATE_TITLE,          typeof(Double));  // 消費税率
            this._custDmdPrcTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // 端数処理区分
            this._custDmdPrcTable.Columns.Add(COL_CADDUPUPDEXECDATE_TITLE,    typeof(Int32));   // 締次更新実行年月日
            this._custDmdPrcTable.Columns.Add(COL_DMDPROCNUM_TITLE,           typeof(Int32));   // 請求処理通番
            this._custDmdPrcTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL3TMBFBLDMD_TITLE,  typeof(Int64));   // 受注3回前残高（請求計）
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL2TMBFBLDMD_TITLE,  typeof(Int64));   // 受注2回前残高（請求計）
            this._custDmdPrcTable.Columns.Add(COL_LASTTIMEDEMAND_TITLE,       typeof(Int64));   // 前回請求金額
            this._custDmdPrcTable.Columns.Add(COL_THISTIMESALES_TITLE,        typeof(Int64));   // 今回売上金額
            this._custDmdPrcTable.Columns.Add(COL_THISSALESTAX_TITLE,         typeof(Int64));   // 今回売上消費税
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // 相殺後今回売上金額
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // 相殺後今回売上消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // 支払インセンティブ額合計（税抜き）
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDEPODMD_TITLE,      typeof(Int64));   // 今回入金
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
            this._custDmdPrcTable.Columns.Add(COL_TOTALADJUST_TITLE, typeof(Int64));   // 残高調整額標示用
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // 未決済金額（自振）
            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // 未決済金額（廻し）
            this._custDmdPrcTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // 決済金額（自振）
            this._custDmdPrcTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSALEPRICE,          typeof(Int64));   // 今回現金売上金額
            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSALETAX,            typeof(Int64));   // 今回現金売上金消費税額
            this._custDmdPrcTable.Columns.Add(COL_SALESSLIPCOUNT_TITLE,             typeof(Int64));   // 売上伝票枚数
            this._custDmdPrcTable.Columns.Add(COL_BILLPRINTDATE_TITLE,              typeof(Int64));   // 請求書発行日
            this._custDmdPrcTable.Columns.Add(COL_EXPECTEDDEPOSITDATE_TITLE,        typeof(Int64));   // 入金予定日
            this._custDmdPrcTable.Columns.Add(COL_COLLECTCOND_TITLE,                typeof(Int64));   // 回収条件
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_AFCALDEMANDPRICE_TITLE,     typeof(Int64));   // 計算後請求金額

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add( COL_THISPAYOFFSET_TITLE, typeof( Int64 ) ); // 今回支払相殺金額
            //this._custDmdPrcTable.Columns.Add( COL_THISPAYOFFSETTAX_TITLE, typeof( Int64 ) ); // 今回支払相殺消費税
            //this._custDmdPrcTable.Columns.Add( COL_ITDEDPAYMOUTTAX_TITLE, typeof( Int64 ) ); // 支払外税対象額
            //this._custDmdPrcTable.Columns.Add( COL_ITDEDPAYMINTAX_TITLE, typeof( Int64 ) ); // 支払内税対象額
            //this._custDmdPrcTable.Columns.Add( COL_ITDEDPAYMTAXFREE_TITLE, typeof( Int64 ) ); // 支払非課税対象額
            //this._custDmdPrcTable.Columns.Add( COL_PAYMENTOUTTAX_TITLE, typeof( Int64 ) ); // 支払外税消費税
            //this._custDmdPrcTable.Columns.Add( COL_PAYMENTINTAX_TITLE, typeof( Int64 ) ); // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            this._custDmdPrcTable.Columns.Add( COL_TAXADJUST_TITLE, typeof( Int64 ) ); // 消費税調整額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            this._custDmdPrcTable.Columns.Add(COL_STARTCADDUPUPDDATE_TITLE, typeof(Int32));     // 締次更新開始年月日
            this._custDmdPrcTable.Columns.Add(COL_LASTCADDUPUPDDATE_TITLE, typeof(Int32));      // 前回締次更新年月日
            this._custDmdPrcTable.Columns.Add(COL_DEPOTOTAL, typeof(List<DmdDepoTotal>));       // 入金集計データ
            // 2009.01.06 Add <<<

            // ADD 2009/06/23 ------>>>
            this._custDmdPrcTable.Columns.Add(COL_BILLNO_TITLE, typeof(Int32));                 // 請求書No
            // ADD 2009/06/23 ------<<<
            
            // PrimaryKey設定
            this._custDmdPrcTable.PrimaryKey = new DataColumn[] { this._custDmdPrcTable.Columns[COL_ADDUPSECCODE_TITLE],    // 計上拠点コード
                                                                  this._custDmdPrcTable.Columns[COL_CLAIMCODE_TITLE],       // 請求先コード
                                                                  this._custDmdPrcTable.Columns[COL_CUSTOMERCODE_TITLE],    // 得意先コード
                                                                  // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
                                                                  this._custDmdPrcTable.Columns[COL_RESULTSECCODE_TITLE],  // 実績拠点コード
                                                                  // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
                                                                  this._custDmdPrcTable.Columns[COL_ADDUPDATE_TITLE]};            // 計上年月日
            this._bindDataSet.Tables.Add(this._custDmdPrcTable);

            // 2009.01.06 Add >>>
            this._custDmdPrcTotalTable = new DataTable(TBL_CUSTDMDPRCTOTAL_TITLE);
            this._custDmdPrcTotalTable = this._custDmdPrcTable.Clone();
            this._custDmdPrcTotalTable.TableName = TBL_CUSTDMDPRCTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custDmdPrcTotalTable);
            // 2009.01.06 Add <<<
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
            if (this._iCustRsltUpdDB == null)
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

		/// <summary>書き込み処理(売掛)</summary>
        /// <param name="custAccRec">得意先売掛金額マスタオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.06 >>>
        //public int WriteCustAccRec(CustAccRec custAccRec, out string errMsg)
        public int WriteCustAccRec(CustAccRec custAccRec, List<AccRecDepoTotal> accRecDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
            // 得意先売掛金額マスタ更新
            // 2009.01.06 >>>
            //return this.WriteCustAccRecProc(custAccRec, out errMsg);
            return this.WriteCustAccRecProc(custAccRec, accRecDepoTotalList, out errMsg);
            // 2009.01.06 <<<
        }

		/// <summary>得意先売掛金額マスタ書き込み処理(売掛)</summary>
        /// <param name="custAccRec">得意先売掛金額マスタオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先売掛金額マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.06 >>>
        //private int WriteCustAccRecProc(CustAccRec custAccRec, out string errMsg)
        private int WriteCustAccRecProc(CustAccRec custAccRec, List<AccRecDepoTotal> accRecDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
			int status = 0;
            errMsg     = "";

			try {
                CustAccRecWork custAccRecWork = new CustAccRecWork();

                // 編集前情報取得
                if (this._custAccRecDic.ContainsKey(custAccRec.FileHeaderGuid) == true)
                {
                    custAccRecWork = (this._custAccRecDic[custAccRec.FileHeaderGuid] as CustAccRecWork);
                }

                // 編集情報取得
                CopyToCustAccRecWorkFromCustAccRec(ref custAccRecWork, custAccRec);

                // 2009.01.06 >>>
                //object retObj = (object)custAccRecWork;

                // 入金集計データの取得
                ArrayList accRecDepoTotalWorkArrayList = new ArrayList();

                foreach (AccRecDepoTotal dmdDepoTotal in accRecDepoTotalList)
                {
                    AccRecDepoTotalWork accRecDepoTotalWork = ParamDataFromUIData(dmdDepoTotal);
                    accRecDepoTotalWork.EnterpriseCode = custAccRecWork.EnterpriseCode;     // 企業コード
                    accRecDepoTotalWork.AddUpSecCode = custAccRecWork.AddUpSecCode;         // 計上拠点コード
                    accRecDepoTotalWork.ClaimCode = custAccRecWork.ClaimCode;               // 請求先コード
                    accRecDepoTotalWork.CustomerCode = custAccRecWork.ClaimCode;            // 得意先コード（請求先をセット）
                    accRecDepoTotalWork.AddUpDate = custAccRecWork.AddUpDate;               // 計上年月日
                    accRecDepoTotalWorkArrayList.Add(accRecDepoTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custAccRecWork);

                // --- CHG 2009/01/30 障害ID:10603対応------------------------------------------------------>>>>>
                //if (accRecDepoTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(accRecDepoTotalWorkArrayList);
                //}
                dataList.Add(accRecDepoTotalWorkArrayList);
                // --- CHG 2009/01/30 障害ID:10603対応------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.06 <<<

                //得意先売掛金額マスタ書き込み
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //status = this._iCustRsltUpdDB.WriteAccRec(ref retObj, out errMsg);
                status = this._iCustRsltUpdDB.WriteTotalAccRec(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {

                    // データセットに追加
                    // 2009.01.06 >>>
                    //custAccRecWork = (CustAccRecWork)retObj;
                    //this.CustAccRecWorkToDataSet(custAccRecWork);
                    accRecDepoTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0; i < retDataList.Count; i++)
                        {
                            if (retDataList[i] is CustAccRecWork)
                            {
                                custAccRecWork = (CustAccRecWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                accRecDepoTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.CustAccRecWorkToDataSet(custAccRecWork, accRecDepoTotalWorkArrayList);

                    // 請求先指定の場合は集計レコードへ反映
                    if (custAccRecWork.CustomerCode == 0)
                    {
                        this.CustAccRecWorkTotalToDataSet(custAccRecWork, accRecDepoTotalWorkArrayList);
                    }
                    // 2009.01.06 <<<
                }
			}
			catch(Exception) {
				// オフライン時はnullをセット
                this._iCustRsltUpdDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

        /// <summary>書き込み処理(請求)</summary>
        /// <param name="custDmdPrc">得意先請求金額マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //public int WriteCustDmdPrc(CustDmdPrc custDmdPrc, out string errMsg)
        public int WriteCustDmdPrc(CustDmdPrc custDmdPrc, List<DmdDepoTotal> dmdDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
            // 得意先請求金額マスタ更新
            // 2009.01.06 >>>
            //return this.WriteCustDmdPrcProc(custDmdPrc, out errMsg);
            return this.WriteCustDmdPrcProc(custDmdPrc, dmdDepoTotalList, out errMsg);
            // 2009.01.06 <<<
        }

        /// <summary>得意先請求金額マスタ書き込み処理(売掛)</summary>
        /// <param name="custDmdPrc">得意先請求金額マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタの書き込み処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private int WriteCustDmdPrcProc(CustDmdPrc custDmdPrc, out string errMsg)
        private int WriteCustDmdPrcProc(CustDmdPrc custDmdPrc, List<DmdDepoTotal> dmdDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
			int status = 0;
            errMsg     = "";

            try
            {
                CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

                // 編集前情報取得
                if (this._custDmdPrcDic.ContainsKey(custDmdPrc.FileHeaderGuid) == true)
                {
                    custDmdPrcWork = (this._custDmdPrcDic[custDmdPrc.FileHeaderGuid] as CustDmdPrcWork);
                }

                // 編集情報取得
                CopyToCustDmdPrcWorkFromCustDmdPrc(ref custDmdPrcWork, custDmdPrc);

                // 2009.01.06 >>>
                //object retObj = (object)custDmdPrcWork;

                // 入金集計データの取得
                ArrayList dmdDepoTotalWorkArrayList = new ArrayList();

                foreach (DmdDepoTotal dmdDepoTotal in dmdDepoTotalList)
                {
                    DmdDepoTotalWork dmdDepoTotalWork = ParamDataFromUIData(dmdDepoTotal);
                    dmdDepoTotalWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode;    // 企業コード
                    dmdDepoTotalWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;        // 計上拠点コード
                    dmdDepoTotalWork.ClaimCode = custDmdPrcWork.ClaimCode;              // 請求先コード
                    dmdDepoTotalWork.CustomerCode = custDmdPrcWork.ClaimCode;           // 得意先コード（請求先をセット）
                    dmdDepoTotalWork.AddUpDate = custDmdPrcWork.AddUpDate;              // 計上年月日
                    dmdDepoTotalWorkArrayList.Add(dmdDepoTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custDmdPrcWork);

                // --- CHG 2009/01/30 障害ID:10603対応------------------------------------------------------>>>>>
                //if (dmdDepoTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(dmdDepoTotalWorkArrayList);
                //}
                dataList.Add(dmdDepoTotalWorkArrayList);
                // --- CHG 2009/01/30 障害ID:10603対応------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.06 <<<

                //得意先売掛金額マスタ書き込み
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //status = this._iCustRsltUpdDB.WriteDmdPrc(ref retObj, out errMsg);
                status = this._iCustRsltUpdDB.WriteTotalDmdPrc(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.06 >>>
                    //// データセットに追加
                    //custDmdPrcWork = (CustDmdPrcWork)retObj;
                    //this.CustDmdPrcWorkToDataSet(custDmdPrcWork);

                    dmdDepoTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0;i < retDataList.Count;i++)
                        {
                            if (retDataList[i] is CustAccRecWork)
                            {
                                custDmdPrcWork = (CustDmdPrcWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                dmdDepoTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.CustDmdPrcWorkToDataSet(custDmdPrcWork, dmdDepoTotalWorkArrayList);

                    // 請求先指定の場合は集計レコードへ反映
                    if (custDmdPrcWork.CustomerCode == 0)
                    {
                        this.CustDmdPrcWorkTotalToDataSet(custDmdPrcWork, dmdDepoTotalWorkArrayList);
                    }
                    // 2009.01.06 <<<
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show( ex.Message );

                // オフライン時はnullをセット
                this._iCustRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Delete Methods

		/// <summary>物理削除処理</summary>
        /// <param name="custAccRec">得意先売掛金額マスタクラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int DeleteCustAccRec(CustAccRec custAccRec)
        {
            // 得意先売掛金額マスタ物理削除
            return this.DeleteCustAccRecProc(custAccRec);
        }

		/// <summary>得意先売掛金額マスタ物理削除処理</summary>
        /// <param name="custAccRec">得意先売掛金額マスタクラス</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : 得意先売掛金額マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private int DeleteCustAccRecProc(CustAccRec custAccRec)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                CustAccRecWork custAccRecWork = new CustAccRecWork();

                // 編集前情報取得
                if (this._custAccRecDic.ContainsKey(custAccRec.FileHeaderGuid) == true)
                {
                    custAccRecWork = (this._custAccRecDic[custAccRec.FileHeaderGuid] as CustAccRecWork);
                }

                CopyToCustAccRecWorkFromCustAccRec(ref custAccRecWork, custAccRec);

                // 2009.01.06 Add >>>
                //object paraObj = (object)custAccRecWork;
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custAccRecWork);
                object paraObj = (object)dataList;
                // 2009.01.06 Add <<<

                // 得意先売掛金額マスタ物理削除
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //status = this._iCustRsltUpdDB.DeleteAccRec(paraObj);
                status = this._iCustRsltUpdDB.DeleteTotalAccRec(paraObj);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._custAccRecDic.Remove(custAccRec.FileHeaderGuid);
                    // データテーブルから削除
                    object[] key = { custAccRec.AddUpSecCode, custAccRec.ClaimCode, custAccRec.CustomerCode, TDateTime.DateTimeToLongDate(custAccRec.AddUpDate) };
                    DataRow dr = this._custAccRecTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iCustRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        /// <summary>物理削除処理</summary>
        /// <param name="custDmdPrc">得意先請求金額</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int DeleteCustDmdPrc(CustDmdPrc custDmdPrc)
        {
            // 得意先請求金額マスタ物理削除
            return this.DeleteCustDmdPrcProc(custDmdPrc);
        }

        /// <summary>得意先請求金額マスタ物理削除処理</summary>
        /// <param name="custDmdPrc">得意先請求金額マスタ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタの物理削除処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int DeleteCustDmdPrcProc(CustDmdPrc custDmdPrc)
        {
            int status = 0;

            try
            {
                // 編集前情報取得
                CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

                // 編集前情報取得
                if (this._custDmdPrcDic.ContainsKey(custDmdPrc.FileHeaderGuid) == true)
                {
                    custDmdPrcWork = (this._custDmdPrcDic[custDmdPrc.FileHeaderGuid] as CustDmdPrcWork);
                }

                CopyToCustDmdPrcWorkFromCustDmdPrc(ref custDmdPrcWork, custDmdPrc);

                // 得意先請求金額マスタ物理削除
                // 2009.01.06 >>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                ////status = this._iCustRsltUpdDB.DeleteDmdPrc(custDmdPrcWork);
                //status = this._iCustRsltUpdDB.DeleteTotalDmdPrc(custDmdPrcWork);
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custDmdPrcWork);
                object paraObj = (object)dataList;
                status = this._iCustRsltUpdDB.DeleteTotalDmdPrc(paraObj);
                // 2009.01.06 <<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 詳細グリッド用キャッシュテーブルから削除
                    this._custDmdPrcDic.Remove(custDmdPrc.FileHeaderGuid);
                    // データテーブルから削除
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    //object[] key = { custDmdPrc.AddUpSecCode, custDmdPrc.ClaimCode, custDmdPrc.CustomerCode, custDmdPrc. TDateTime.DateTimeToLongDate(custDmdPrc.AddUpDate) };
                    object[] key = { custDmdPrc.AddUpSecCode, custDmdPrc.ClaimCode, custDmdPrc.CustomerCode, custDmdPrc.ResultsSectCd, TDateTime.DateTimeToLongDate(custDmdPrc.AddUpDate) };
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                    DataRow dr = this._custDmdPrcTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception ex)
            {
                
                // オフライン時はnullをセット
                this._iCustRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Search Methods

		/// <summary>検索処理(論理削除除く)(売掛)</summary>
        /// <param name="totalCount">取得件数</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int SearchCustAccRec(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode)
        {
            // 得意先売掛金額マスタ検索
            return this.SearchCustAccRecProc(out totalCount, enterpriseCode, sectionCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>検索処理(論理削除含む)(売掛)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データも検索対象に含みます。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int SearchCustAccRecAll(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode)
        {
            // 得意先売掛金額マスタ検索
            return this.SearchCustAccRecProc(out totalCount, enterpriseCode, sectionCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>検索処理(売掛)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int SearchCustAccRecProc(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // 得意先売掛金額マスタ検索
            status1 = this.SearchCustAccRecProc2(out totalCount, enterpriseCode, sectionCode, claimCode, customerCode, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // キャッシュ処理
            // 2009.01.06 >>>
            //status2 = this.CacheCustAccRec(this._custAccRecList);
            status2 = this.CacheCustAccRec(this._custAccRecList, sectionCode, claimCode, customerCode);
            // 2009.01.06 <<<
            
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>得意先売掛金額マスタ検索処理(売掛)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先売掛金額マスタの検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private int SearchCustAccRecProc2(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
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

                // 得意先売掛金額マスタ検索
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
                //if (customerCode == claimCode) {
                //    customerCode = 0;   // 親レコードの場合は得意先コード＝０にして読み込み
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
                status = this._iCustRsltUpdDB.SearchAccRec(enterpriseCode,sectionCode,claimCode,customerCode,0,out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.06 >>>
                    //this._custAccRecList = retobj as ArrayList;
                    this._custAccRecList = retobj as CustomSerializeArrayList;
                    // 2009.01.06 <<<

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
                this._iCustRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        /// <summary>検索処理(論理削除除く)(請求)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報の検索処理を行います。論理削除データは検索対象外です。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int SearchCustDmdPrc(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode)
        {
            // 得意先請求金額マスタ検索
            return this.SearchCustDmdPrcProc(out totalCount, enterpriseCode, sectionCode, resultSecCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>検索処理(論理削除含む)(請求)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="resultSecCode">実績拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
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
        public int SearchCustDmdPrcAll(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode)
        {
            // 得意先請求金額マスタ検索
            return this.SearchCustDmdPrcProc(out totalCount, enterpriseCode, sectionCode, resultSecCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>検索処理(請求)</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="resultSecCode">実績拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
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
        private int SearchCustDmdPrcProc(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // 得意先請求金額マスタ検索
            status1 = this.SearchCustDmdPrcProc2(out totalCount, enterpriseCode, sectionCode, resultSecCode, claimCode, customerCode, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // キャッシュ処理
            // 2009.01.06 >>>
            //status2 = this.CacheCustDmdPrc(this._custDmdPrcList);
            status2 = this.CacheCustDmdPrc(this._custDmdPrcList, sectionCode, resultSecCode, claimCode, customerCode);
            // 2009.01.06 <<<
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>得意先請求金額マスタ検索処理</summary>
        /// <param name="totalCount">取得件数</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="resultSecCode">実績拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタの検索処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.03.08</br>
        /// <br>-------------------------</br>
        /// <br>Note       : 引数に実績拠点コードを追加</br>
        /// <br>Modifier   : 徳永 俊詞</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private int SearchCustDmdPrcProc2(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
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

                // 得意先請求金額マスタ検索
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
                //if (customerCode == claimCode) {
                //    customerCode = 0;   // 親レコードの場合は得意先コード＝０で読み込み
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
                status = this._iCustRsltUpdDB.SearchDmdPrc(enterpriseCode, sectionCode, claimCode, resultSecCode, customerCode, 0, out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.06 >>>
                    //this._custDmdPrcList = retobj as ArrayList;
                    this._custDmdPrcList = retobj as CustomSerializeArrayList;
                    // 2009.01.06 <<<

                    // 該当件数格納
                    totalCount = this._custDmdPrcList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                //..debug
                //System.Windows.Forms.MessageBox.Show( ex.Message );

                // オフライン時はnullをセット
                this._iCustRsltUpdDB = null;

                // 通信エラーは-1を返す
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>マスタキャッシュ処理(売掛)</summary>
        /// <param name="custAccRecList">得意先売掛金額マスタ取得結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //public int CacheCustAccRec(ArrayList custAccRecList)
        public int CacheCustAccRec(CustomSerializeArrayList custAccRecList, string sectionCode, Int32 claimCode, Int32 customerCode)
        // 2009.01.06 <<<
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._custAccRecTable.BeginLoadData();
                    this._custAccRecTotalTable.BeginLoadData(); // 2009.01.06 Add

                    // テーブルをクリア
                    this._custAccRecTable.Clear();
                    this._custAccRecTotalTable.Clear();         // 2009.01.06 Add
                    // 2009.01.06 >>>
                    //// 得意先売掛金額マスタデータをDataSetに格納
                    //foreach (CustAccRecWork custAccRecWork in custAccRecList)
                    //{
                    //    // 未登録の時
                    //    if (this._custAccRecDic.ContainsKey(custAccRecWork.FileHeaderGuid) == false)
                    //    {
                    //        // データセットに追加
                    //        this.CustAccRecWorkToDataSet(custAccRecWork);
                    //    }
                    //}

                    for (int i = 0; i < custAccRecList.Count; i++)
                    {
                        if (custAccRecList[i] is ArrayList)
                        {
                            ArrayList accDataArrayList = (ArrayList)custAccRecList[i];

                            CustAccRecWork custAccRecWork = null;
                            CustAccRecWork custAccRecWorkTotal = null;
                            ArrayList accRecDepoTotalWorkArrayList = null;

                            for (int n = 0; n < accDataArrayList.Count; n++)
                            {
                                if (accDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)accDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is CustAccRecWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (CustAccRecWork custAccRecWorkWk in data)
                                                {
                                                    if (custAccRecWorkWk.CustomerCode == 0)
                                                    {
                                                        custAccRecWorkTotal = custAccRecWorkWk;
                                                    }

                                                    if (( custAccRecWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( custAccRecWorkWk.ClaimCode == claimCode ) &&
                                                        ( custAccRecWorkWk.CustomerCode == customerCode ))
                                                    {
                                                        custAccRecWork = custAccRecWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is AccRecDepoTotalWork)
                                        {
                                            // 入金データのリスト
                                            accRecDepoTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }
                            // 集計レコードとパラメータが合わない可能性がある(拠点)ので念のため
                            if (( customerCode == 0 ) && ( custAccRecWorkTotal != null ))
                            {
                                if (custAccRecWork == null) custAccRecWork = custAccRecWorkTotal;
                            }
                            if (custAccRecWork != null)
                            {
                                // 未登録の時
                                if (this._custAccRecDic.ContainsKey(custAccRecWork.FileHeaderGuid) == false)
                                {
                                    // データセットに追加
                                    this.CustAccRecWorkToDataSet(custAccRecWork, ( custAccRecWork.CustomerCode == 0 ) ? accRecDepoTotalWorkArrayList : null);
                                }
                            }
                            if (custAccRecWorkTotal != null)
                            {
                                this.CustAccRecWorkTotalToDataSet(custAccRecWorkTotal, accRecDepoTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.06 <<<
                }
                finally
                {
                    // 更新処理終了
                    this._custAccRecTable.EndLoadData();
                    this._custAccRecTotalTable.EndLoadData();   // 2009.01.06 Add
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }

            return 0;
        }

        /// <summary>マスタキャッシュ処理(請求)</summary>
        /// <param name="custDmdPrcList">得意先請求金額マスタ取得結果リスト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報のキャッシュ処理を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //public int CacheCustDmdPrc(ArrayList custDmdPrcList)
        private int CacheCustDmdPrc(CustomSerializeArrayList custDmdPrcList, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode)
        // 2009.01.06 <<<
        {
            try
            {
                try
                {
                    // 更新処理開始
                    this._custDmdPrcTable.BeginLoadData();
                    this._custDmdPrcTotalTable.BeginLoadData();     // 2009.01.06 Add

                    // テーブルをクリア
                    this._custDmdPrcTable.Clear();
                    this._custDmdPrcTotalTable.Clear();     // 2009.01.06 Add

                    // 2009.01.06 >>>
                    //// 得意先請求金額マスタデータをDataSetに格納
                    //foreach (CustDmdPrcWork custDmdPrcWork in custDmdPrcList)
                    //{
                    //    // 未登録の時
                    //    if (this._custDmdPrcDic.ContainsKey(custDmdPrcWork.FileHeaderGuid) == false)
                    //    {
                    //        // データセットに追加
                    //        this.CustDmdPrcWorkToDataSet(custDmdPrcWork);
                    //    }
                    //}

                    for (int i = 0; i < custDmdPrcList.Count; i++)
                    {
                        if (custDmdPrcList[i] is ArrayList)
                        {
                            ArrayList dmdDataArrayList = (ArrayList)custDmdPrcList[i];

                            CustDmdPrcWork custDmdPrcWork = null;
                            CustDmdPrcWork custDmdPrcWorkTotal = null;
                            ArrayList dmdDepoTotalWorkArrayList = null;

                            for (int n = 0; n < dmdDataArrayList.Count; n++)
                            {
                                if (dmdDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)dmdDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is CustDmdPrcWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (CustDmdPrcWork custDmdPrcWorkWk in data)
                                                {
                                                    if (( custDmdPrcWorkWk.ResultsSectCd.Trim() == ALL_SECTION ) && ( custDmdPrcWorkWk.CustomerCode == 0 ))
                                                    {
                                                        custDmdPrcWorkTotal = custDmdPrcWorkWk;
                                                    }

                                                    if (( custDmdPrcWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( custDmdPrcWorkWk.ResultsSectCd.Trim() == resultSecCode.Trim() ) &&
                                                        ( custDmdPrcWorkWk.ClaimCode == claimCode ) &&
                                                        ( custDmdPrcWorkWk.CustomerCode == customerCode ))
                                                    {
                                                        custDmdPrcWork = custDmdPrcWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is DmdDepoTotalWork)
                                        {
                                            // 入金データのリスト
                                            dmdDepoTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }

                            // 集計レコードとパラメータが合わない可能性がある(拠点)ので念のため
                            if (( customerCode == 0 ) && ( custDmdPrcWorkTotal != null ))
                            {
                                if (custDmdPrcWork == null) custDmdPrcWork = custDmdPrcWorkTotal;
                            }
                            if (custDmdPrcWork != null)
                            {
                                // 未登録の時
                                if (this._custDmdPrcDic.ContainsKey(custDmdPrcWork.FileHeaderGuid) == false)
                                {
                                    // データセットに追加
                                    this.CustDmdPrcWorkToDataSet(custDmdPrcWork, ( custDmdPrcWork.CustomerCode == 0 ) ? dmdDepoTotalWorkArrayList : null);
                                }
                            }
                            if (custDmdPrcWorkTotal != null)
                            {
                                this.CustDmdPrcWorkTotalToDataSet(custDmdPrcWorkTotal, dmdDepoTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.06 <<<
                }
                finally
                {
                    // 更新処理終了
                    this._custDmdPrcTable.EndLoadData();
                    this._custDmdPrcTotalTable.EndLoadData();   // 2009.01.06 Add
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>クラスメンバコピー処理 (画面変更得意先売掛金額マスタクラス⇒得意先売掛金額マスタワーククラス)</summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタワーククラス</param>
        /// <param name="custAccRec">得意先売掛金額マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更得意先売掛金額マスタクラスから
        ///                  得意先売掛金額マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToCustAccRecWorkFromCustAccRec(ref CustAccRecWork custAccRecWork, CustAccRec custAccRec)
        {
            # region delete
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRecWork.EnterpriseCode       = custAccRec.EnterpriseCode;
            //custAccRecWork.AddUpSecCode         = custAccRec.AddUpSecCode;
            //custAccRecWork.CustomerCode         = custAccRec.CustomerCode;
            //custAccRecWork.CustomerName         = custAccRec.CustomerName;
            //custAccRecWork.CustomerName2        = custAccRec.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRecWork.CustomerSnm          = custAccRec.CustomerSnm;
            //custAccRecWork.ClaimCode            = custAccRec.ClaimCode;
            //custAccRecWork.ClaimName            = custAccRec.ClaimName;
            //custAccRecWork.ClaimName2           = custAccRec.ClaimName2;
            //custAccRecWork.ClaimSnm             = custAccRec.ClaimSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.AddUpDate            = TDateTime.LongDateToDateTime(custAccRec.AddUpDate);
            ////custAccRecWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(custAccRec.AddUpYearMonth);
            //custAccRecWork.AddUpDate = custAccRec.AddUpDate;
            //custAccRecWork.AddUpYearMonth = custAccRec.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.LastTimeAccRec       = custAccRec.LastTimeAccRec;
            //custAccRecWork.ThisTimeDmdNrml      = custAccRec.ThisTimeDmdNrml;
            //custAccRecWork.ThisTimeFeeDmdNrml   = custAccRec.ThisTimeFeeDmdNrml;
            //custAccRecWork.ThisTimeDisDmdNrml   = custAccRec.ThisTimeDisDmdNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.ThisTimeRbtDmdNrml   = custAccRec.ThisTimeRbtDmdNrml;
            ////custAccRecWork.ThisTimeDmdDepo      = custAccRec.ThisTimeDmdDepo;
            ////custAccRecWork.ThisTimeFeeDmdDepo   = custAccRec.ThisTimeFeeDmdDepo;
            ////custAccRecWork.ThisTimeDisDmdDepo   = custAccRec.ThisTimeDisDmdDepo;
            ////custAccRecWork.ThisTimeRbtDmdDepo   = custAccRec.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.ThisTimeTtlBlcAcc    = custAccRec.ThisTimeTtlBlcAcc;
            //custAccRecWork.ThisTimeSales        = custAccRec.ThisTimeSales;
            //custAccRecWork.ThisSalesTax         = custAccRec.ThisSalesTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.TtlIncDtbtTaxExc     = custAccRec.TtlIncDtbtTaxExc;
            ////custAccRecWork.TtlIncDtbtTax        = custAccRec.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.OfsThisTimeSales     = custAccRec.OfsThisTimeSales;
            //custAccRecWork.OfsThisSalesTax      = custAccRec.OfsThisSalesTax;
            //custAccRecWork.ItdedOffsetOutTax    = custAccRec.ItdedOffsetOutTax;
            //custAccRecWork.ItdedOffsetInTax     = custAccRec.ItdedOffsetInTax;
            //custAccRecWork.ItdedOffsetTaxFree   = custAccRec.ItdedOffsetTaxFree;
            //custAccRecWork.OffsetOutTax         = custAccRec.OffsetOutTax;
            //custAccRecWork.OffsetInTax          = custAccRec.OffsetInTax;
            //custAccRecWork.ItdedSalesOutTax = custAccRec.ItdedSalesOutTax;
            //custAccRecWork.ItdedSalesInTax = custAccRec.ItdedSalesInTax;
            //custAccRecWork.ItdedSalesTaxFree = custAccRec.ItdedSalesTaxFree;
            //custAccRecWork.SalesOutTax = custAccRec.SalesOutTax;
            //custAccRecWork.SalesInTax = custAccRec.SalesInTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.ItdedPaymOutTax      = custAccRec.ItdedPaymOutTax;
            ////custAccRecWork.ItdedPaymInTax       = custAccRec.ItdedPaymInTax;
            ////custAccRecWork.ItdedPaymTaxFree     = custAccRec.ItdedPaymTaxFree;
            ////custAccRecWork.PaymentOutTax        = custAccRec.PaymentOutTax;
            ////custAccRecWork.PaymentInTax         = custAccRec.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRecWork.TtlItdedRetOutTax    = custAccRec.TtlItdedRetOutTax;
            //custAccRecWork.TtlItdedRetInTax     = custAccRec.TtlItdedRetInTax;
            //custAccRecWork.TtlItdedRetTaxFree   = custAccRec.TtlItdedRetTaxFree;
            //custAccRecWork.TtlRetOuterTax       = custAccRec.TtlRetOuterTax;
            //custAccRecWork.TtlRetInnerTax       = custAccRec.TtlRetInnerTax;
            //custAccRecWork.TtlItdedDisOutTax    = custAccRec.TtlItdedDisOutTax;
            //custAccRecWork.TtlItdedDisInTax     = custAccRec.TtlItdedDisInTax;
            //custAccRecWork.TtlItdedDisTaxFree   = custAccRec.TtlItdedDisTaxFree;
            //custAccRecWork.TtlDisOuterTax       = custAccRec.TtlDisOuterTax;
            //custAccRecWork.TtlDisInnerTax       = custAccRec.TtlDisInnerTax;
            //custAccRecWork.BalanceAdjust        = custAccRec.BalanceAdjust;
            //custAccRecWork.ThisCashSalePrice    = custAccRec.ThisCashSalePrice;
            //custAccRecWork.ThisCashSaleTax      = custAccRec.ThisCashSaleTax;
            //custAccRecWork.ThisSalesPricRgds    = custAccRec.ThisSalesPricRgds;
            //custAccRecWork.ThisSalesPricDis     = custAccRec.ThisSalesPricDis;
            //custAccRecWork.ThisSalesPrcTaxRgds  = custAccRec.ThisSalesPrcTaxRgds;
            //custAccRecWork.ThisSalesPrcTaxDis   = custAccRec.ThisSalesPrcTaxDis;
            //custAccRecWork.NonStmntAppearance   = custAccRec.NonStmntAppearance;
            //custAccRecWork.NonStmntIsdone       = custAccRec.NonStmntIsdone;
            //custAccRecWork.StmntAppearance      = custAccRec.StmntAppearance;
            //custAccRecWork.StmntIsdone          = custAccRec.StmntIsdone;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.ConsTaxLayMethod     = custAccRec.ConsTaxLayMethod;
            //custAccRecWork.ConsTaxRate          = custAccRec.ConsTaxRate;
            //custAccRecWork.FractionProcCd       = custAccRec.FractionProcCd;
            //custAccRecWork.AfCalTMonthAccRec    = custAccRec.AfCalTMonthAccRec;
            //custAccRecWork.AcpOdrTtl2TmBfAccRec = custAccRec.AcpOdrTtl2TmBfAccRec;
            //custAccRecWork.AcpOdrTtl3TmBfAccRec = custAccRec.AcpOdrTtl3TmBfAccRec;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.MonthAddUpExpDate    = TDateTime.LongDateToDateTime(custAccRec.MonthAddUpExpDate);
            //custAccRecWork.MonthAddUpExpDate = custAccRec.MonthAddUpExpDate;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custAccRecWork.CreateDateTime = custAccRec.CreateDateTime; // 作成日時
            custAccRecWork.UpdateDateTime = custAccRec.UpdateDateTime; // 更新日時
            custAccRecWork.EnterpriseCode = custAccRec.EnterpriseCode; // 企業コード
            custAccRecWork.FileHeaderGuid = custAccRec.FileHeaderGuid; // GUID
            custAccRecWork.UpdEmployeeCode = custAccRec.UpdEmployeeCode; // 更新従業員コード
            custAccRecWork.UpdAssemblyId1 = custAccRec.UpdAssemblyId1; // 更新アセンブリID1
            custAccRecWork.UpdAssemblyId2 = custAccRec.UpdAssemblyId2; // 更新アセンブリID2
            custAccRecWork.LogicalDeleteCode = custAccRec.LogicalDeleteCode; // 論理削除区分
            custAccRecWork.AddUpSecCode = custAccRec.AddUpSecCode; // 計上拠点コード
            custAccRecWork.ClaimCode = custAccRec.ClaimCode; // 請求先コード
            custAccRecWork.ClaimName = custAccRec.ClaimName; // 請求先名称
            custAccRecWork.ClaimName2 = custAccRec.ClaimName2; // 請求先名称2
            custAccRecWork.ClaimSnm = custAccRec.ClaimSnm; // 請求先略称
            custAccRecWork.CustomerCode = custAccRec.CustomerCode; // 得意先コード
            custAccRecWork.CustomerName = custAccRec.CustomerName; // 得意先名称
            custAccRecWork.CustomerName2 = custAccRec.CustomerName2; // 得意先名称2
            custAccRecWork.CustomerSnm = custAccRec.CustomerSnm; // 得意先略称
            custAccRecWork.AddUpDate = custAccRec.AddUpDate; // 計上年月日
            custAccRecWork.AddUpYearMonth = custAccRec.AddUpYearMonth; // 計上年月
            custAccRecWork.LastTimeAccRec = custAccRec.LastTimeAccRec; // 前回売掛金額
            custAccRecWork.ThisTimeFeeDmdNrml = custAccRec.ThisTimeFeeDmdNrml; // 今回手数料額（通常入金）
            custAccRecWork.ThisTimeDisDmdNrml = custAccRec.ThisTimeDisDmdNrml; // 今回値引額（通常入金）
            custAccRecWork.ThisTimeDmdNrml = custAccRec.ThisTimeDmdNrml; // 今回入金金額（通常入金）
            custAccRecWork.ThisTimeTtlBlcAcc = custAccRec.ThisTimeTtlBlcAcc; // 今回繰越残高（売掛計）
            custAccRecWork.OfsThisTimeSales = custAccRec.OfsThisTimeSales; // 相殺後今回売上金額
            custAccRecWork.OfsThisSalesTax = custAccRec.OfsThisSalesTax; // 相殺後今回売上消費税
            custAccRecWork.ItdedOffsetOutTax = custAccRec.ItdedOffsetOutTax; // 相殺後外税対象額
            custAccRecWork.ItdedOffsetInTax = custAccRec.ItdedOffsetInTax; // 相殺後内税対象額
            custAccRecWork.ItdedOffsetTaxFree = custAccRec.ItdedOffsetTaxFree; // 相殺後非課税対象額
            custAccRecWork.OffsetOutTax = custAccRec.OffsetOutTax; // 相殺後外税消費税
            custAccRecWork.OffsetInTax = custAccRec.OffsetInTax; // 相殺後内税消費税
            custAccRecWork.ThisTimeSales = custAccRec.ThisTimeSales; // 今回売上金額
            custAccRecWork.ThisSalesTax = custAccRec.ThisSalesTax; // 今回売上消費税
            custAccRecWork.ItdedSalesOutTax = custAccRec.ItdedSalesOutTax; // 売上外税対象額
            custAccRecWork.ItdedSalesInTax = custAccRec.ItdedSalesInTax; // 売上内税対象額
            custAccRecWork.ItdedSalesTaxFree = custAccRec.ItdedSalesTaxFree; // 売上非課税対象額
            custAccRecWork.SalesOutTax = custAccRec.SalesOutTax; // 売上外税額
            custAccRecWork.SalesInTax = custAccRec.SalesInTax; // 売上内税額
            custAccRecWork.ThisSalesPricRgds = custAccRec.ThisSalesPricRgds; // 今回売上返品金額
            custAccRecWork.ThisSalesPrcTaxRgds = custAccRec.ThisSalesPrcTaxRgds; // 今回売上返品消費税
            custAccRecWork.TtlItdedRetOutTax = custAccRec.TtlItdedRetOutTax; // 返品外税対象額合計
            custAccRecWork.TtlItdedRetInTax = custAccRec.TtlItdedRetInTax; // 返品内税対象額合計
            custAccRecWork.TtlItdedRetTaxFree = custAccRec.TtlItdedRetTaxFree; // 返品非課税対象額合計
            custAccRecWork.TtlRetOuterTax = custAccRec.TtlRetOuterTax; // 返品外税額合計
            custAccRecWork.TtlRetInnerTax = custAccRec.TtlRetInnerTax; // 返品内税額合計
            custAccRecWork.ThisSalesPricDis = custAccRec.ThisSalesPricDis; // 今回売上値引金額
            custAccRecWork.ThisSalesPrcTaxDis = custAccRec.ThisSalesPrcTaxDis; // 今回売上値引消費税
            custAccRecWork.TtlItdedDisOutTax = custAccRec.TtlItdedDisOutTax; // 値引外税対象額合計
            custAccRecWork.TtlItdedDisInTax = custAccRec.TtlItdedDisInTax; // 値引内税対象額合計
            custAccRecWork.TtlItdedDisTaxFree = custAccRec.TtlItdedDisTaxFree; // 値引非課税対象額合計
            custAccRecWork.TtlDisOuterTax = custAccRec.TtlDisOuterTax; // 値引外税額合計
            custAccRecWork.TtlDisInnerTax = custAccRec.TtlDisInnerTax; // 値引内税額合計

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custAccRecWork.ThisPayOffset = custAccRec.ThisPayOffset; // 今回支払相殺金額
            //custAccRecWork.ThisPayOffsetTax = custAccRec.ThisPayOffsetTax; // 今回支払相殺消費税
            //custAccRecWork.ItdedPaymOutTax = custAccRec.ItdedPaymOutTax; // 支払外税対象額
            //custAccRecWork.ItdedPaymInTax = custAccRec.ItdedPaymInTax; // 支払内税対象額
            //custAccRecWork.ItdedPaymTaxFree = custAccRec.ItdedPaymTaxFree; // 支払非課税対象額
            //custAccRecWork.PaymentOutTax = custAccRec.PaymentOutTax; // 支払外税消費税
            //custAccRecWork.PaymentInTax = custAccRec.PaymentInTax; // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            custAccRecWork.TaxAdjust = custAccRec.TaxAdjust; // 消費税調整額
            custAccRecWork.BalanceAdjust = custAccRec.BalanceAdjust; // 残高調整額
            custAccRecWork.AfCalTMonthAccRec = custAccRec.AfCalTMonthAccRec; // 計算後当月売掛金額
            custAccRecWork.AcpOdrTtl2TmBfAccRec = custAccRec.AcpOdrTtl2TmBfAccRec; // 受注2回前残高（売掛計）
            custAccRecWork.AcpOdrTtl3TmBfAccRec = custAccRec.AcpOdrTtl3TmBfAccRec; // 受注3回前残高（売掛計）
            custAccRecWork.MonthAddUpExpDate = custAccRec.MonthAddUpExpDate; // 月次更新実行年月日
            custAccRecWork.StMonCAddUpUpdDate = custAccRec.StMonCAddUpUpdDate; // 月次更新開始年月日
            custAccRecWork.LaMonCAddUpUpdDate = custAccRec.LaMonCAddUpUpdDate; // 前回月次更新年月日
            custAccRecWork.SalesSlipCount = custAccRec.SalesSlipCount; // 売上伝票枚数

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custAccRecWork.NonStmntAppearance = custAccRec.NonStmntAppearance; // 未決済金額（自振）
            //custAccRecWork.NonStmntIsdone = custAccRec.NonStmntIsdone; // 未決済金額（廻し）
            //custAccRecWork.StmntAppearance = custAccRec.StmntAppearance; // 決済金額（自振）
            //custAccRecWork.StmntIsdone = custAccRec.StmntIsdone; // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            custAccRecWork.ConsTaxLayMethod = custAccRec.ConsTaxLayMethod; // 消費税転嫁方式
            custAccRecWork.ConsTaxRate = custAccRec.ConsTaxRate; // 消費税率
            custAccRecWork.FractionProcCd = custAccRec.FractionProcCd; // 端数処理区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( custAccRecWork.CustomerCode == custAccRecWork.ClaimCode )
            //{
            //    custAccRecWork.CustomerCode = 0;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
        }

        /// <summary>クラスメンバコピー処理 (画面変更得意先請求金額マスタクラス⇒得意先請求金額マスタワーククラス)</summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタワーククラス</param>
        /// <param name="custDmdPrc">得意先請求金額マスタクラス</param>
        /// <remarks>
        /// <br>Note       : 画面変更得意先請求金額マスタクラスから
        ///                  得意先請求金額マスタワーククラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToCustDmdPrcWorkFromCustDmdPrc(ref CustDmdPrcWork custDmdPrcWork, CustDmdPrc custDmdPrc)
        {
            # region delete
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrcWork.EnterpriseCode       = custDmdPrc.EnterpriseCode;
            //custDmdPrcWork.AddUpSecCode         = custDmdPrc.AddUpSecCode;
            //custDmdPrcWork.CustomerCode         = custDmdPrc.CustomerCode;
            //custDmdPrcWork.CustomerName         = custDmdPrc.CustomerName;
            //custDmdPrcWork.CustomerName2        = custDmdPrc.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrcWork.CustomerSnm          = custDmdPrc.CustomerSnm;
            //custDmdPrcWork.ClaimCode            = custDmdPrc.ClaimCode;
            //custDmdPrcWork.ClaimName            = custDmdPrc.ClaimName;
            //custDmdPrcWork.ClaimName2           = custDmdPrc.ClaimName2;
            //custDmdPrcWork.ClaimSnm             = custDmdPrc.ClaimSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.AddUpDate            = TDateTime.LongDateToDateTime(custDmdPrc.AddUpDate);
            ////custDmdPrcWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(custDmdPrc.AddUpYearMonth);
            //custDmdPrcWork.AddUpDate = custDmdPrc.AddUpDate;
            //custDmdPrcWork.AddUpYearMonth = custDmdPrc.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.LastTimeDemand       = custDmdPrc.LastTimeDemand;
            //custDmdPrcWork.ThisTimeDmdNrml      = custDmdPrc.ThisTimeDmdNrml;
            //custDmdPrcWork.ThisTimeFeeDmdNrml   = custDmdPrc.ThisTimeFeeDmdNrml;
            //custDmdPrcWork.ThisTimeDisDmdNrml   = custDmdPrc.ThisTimeDisDmdNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.ThisTimeRbtDmdNrml   = custDmdPrc.ThisTimeRbtDmdNrml;
            ////custDmdPrcWork.ThisTimeDmdDepo      = custDmdPrc.ThisTimeDmdDepo;
            ////custDmdPrcWork.ThisTimeFeeDmdDepo   = custDmdPrc.ThisTimeFeeDmdDepo;
            ////custDmdPrcWork.ThisTimeDisDmdDepo   = custDmdPrc.ThisTimeDisDmdDepo;
            ////custDmdPrcWork.ThisTimeRbtDmdDepo   = custDmdPrc.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.ThisTimeTtlBlcDmd    = custDmdPrc.ThisTimeTtlBlcDmd;
            //custDmdPrcWork.ThisTimeSales        = custDmdPrc.ThisTimeSales;
            //custDmdPrcWork.ThisSalesTax         = custDmdPrc.ThisSalesTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.TtlIncDtbtTaxExc     = custDmdPrc.TtlIncDtbtTaxExc;
            ////custDmdPrcWork.TtlIncDtbtTax        = custDmdPrc.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.OfsThisTimeSales     = custDmdPrc.OfsThisTimeSales;
            //custDmdPrcWork.OfsThisSalesTax      = custDmdPrc.OfsThisSalesTax;
            //custDmdPrcWork.ItdedOffsetOutTax    = custDmdPrc.ItdedOffsetOutTax;
            //custDmdPrcWork.ItdedOffsetInTax     = custDmdPrc.ItdedOffsetInTax;
            //custDmdPrcWork.ItdedOffsetTaxFree   = custDmdPrc.ItdedOffsetTaxFree;
            //custDmdPrcWork.OffsetOutTax         = custDmdPrc.OffsetOutTax;
            //custDmdPrcWork.OffsetInTax          = custDmdPrc.OffsetInTax;
            //custDmdPrcWork.ItdedSalesOutTax     = custDmdPrc.ItdedSalesOutTax;
            //custDmdPrcWork.ItdedSalesInTax      = custDmdPrc.ItdedSalesInTax;
            //custDmdPrcWork.ItdedSalesTaxFree    = custDmdPrc.ItdedSalesTaxFree;
            //custDmdPrcWork.SalesOutTax          = custDmdPrc.SalesOutTax;
            //custDmdPrcWork.SalesInTax           = custDmdPrc.SalesInTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.ItdedPaymOutTax      = custDmdPrc.ItdedPaymOutTax;
            ////custDmdPrcWork.ItdedPaymInTax       = custDmdPrc.ItdedPaymInTax;
            ////custDmdPrcWork.ItdedPaymTaxFree     = custDmdPrc.ItdedPaymTaxFree;
            ////custDmdPrcWork.PaymentOutTax        = custDmdPrc.PaymentOutTax;
            ////custDmdPrcWork.PaymentInTax         = custDmdPrc.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrcWork.TtlItdedRetOutTax    = custDmdPrc.TtlItdedRetOutTax;
            //custDmdPrcWork.TtlItdedRetInTax     = custDmdPrc.TtlItdedRetInTax;
            //custDmdPrcWork.TtlItdedRetTaxFree   = custDmdPrc.TtlItdedRetTaxFree;
            //custDmdPrcWork.TtlRetOuterTax       = custDmdPrc.TtlRetOuterTax;
            //custDmdPrcWork.TtlRetInnerTax       = custDmdPrc.TtlRetInnerTax;
            //custDmdPrcWork.TtlItdedDisOutTax    = custDmdPrc.TtlItdedDisOutTax;
            //custDmdPrcWork.TtlItdedDisInTax     = custDmdPrc.TtlItdedDisInTax;
            //custDmdPrcWork.TtlItdedDisTaxFree   = custDmdPrc.TtlItdedDisTaxFree;
            //custDmdPrcWork.TtlDisOuterTax       = custDmdPrc.TtlDisOuterTax;
            //custDmdPrcWork.TtlDisInnerTax       = custDmdPrc.TtlDisInnerTax;
            //custDmdPrcWork.BalanceAdjust        = custDmdPrc.BalanceAdjust;
            //custDmdPrcWork.ThisSalesPricRgds    = custDmdPrc.ThisSalesPricRgds;
            //custDmdPrcWork.ThisSalesPricDis     = custDmdPrc.ThisSalesPricDis;
            //custDmdPrcWork.ThisSalesPrcTaxRgds  = custDmdPrc.ThisSalesPrcTaxRgds;
            //custDmdPrcWork.ThisSalesPrcTaxDis   = custDmdPrc.ThisSalesPrcTaxDis;
            //custDmdPrcWork.SaleslSlipCount      = custDmdPrc.SaleslSlipCount;
            //custDmdPrcWork.BillPrintDate        = custDmdPrc.BillPrintDate;
            //custDmdPrcWork.ExpectedDepositDate  = custDmdPrc.ExpectedDepositDate;
            //custDmdPrcWork.CollectCond          = custDmdPrc.CollectCond;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.ConsTaxLayMethod     = custDmdPrc.ConsTaxLayMethod;
            //custDmdPrcWork.ConsTaxRate          = custDmdPrc.ConsTaxRate;
            //custDmdPrcWork.FractionProcCd       = custDmdPrc.FractionProcCd;
            //custDmdPrcWork.AfCalDemandPrice     = custDmdPrc.AfCalDemandPrice;
            //custDmdPrcWork.AcpOdrTtl2TmBfBlDmd  = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
            //custDmdPrcWork.AcpOdrTtl3TmBfBlDmd  = custDmdPrc.AcpOdrTtl3TmBfBlDmd;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.CAddUpUpdExecDate    = TDateTime.LongDateToDateTime(custDmdPrc.CAddUpUpdExecDate);
            //custDmdPrcWork.CAddUpUpdExecDate = custDmdPrc.CAddUpUpdExecDate;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.DmdProcNum           = custDmdPrc.DmdProcNum;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custDmdPrcWork.CreateDateTime = custDmdPrc.CreateDateTime; // 作成日時
            custDmdPrcWork.UpdateDateTime = custDmdPrc.UpdateDateTime; // 更新日時
            custDmdPrcWork.EnterpriseCode = custDmdPrc.EnterpriseCode; // 企業コード
            custDmdPrcWork.FileHeaderGuid = custDmdPrc.FileHeaderGuid; // GUID
            custDmdPrcWork.UpdEmployeeCode = custDmdPrc.UpdEmployeeCode; // 更新従業員コード
            custDmdPrcWork.UpdAssemblyId1 = custDmdPrc.UpdAssemblyId1; // 更新アセンブリID1
            custDmdPrcWork.UpdAssemblyId2 = custDmdPrc.UpdAssemblyId2; // 更新アセンブリID2
            custDmdPrcWork.LogicalDeleteCode = custDmdPrc.LogicalDeleteCode; // 論理削除区分
            custDmdPrcWork.AddUpSecCode = custDmdPrc.AddUpSecCode; // 計上拠点コード

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            custDmdPrcWork.ResultsSectCd = custDmdPrc.ResultsSectCd;    // 実績拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            custDmdPrcWork.ClaimCode = custDmdPrc.ClaimCode; // 請求先コード
            custDmdPrcWork.ClaimName = custDmdPrc.ClaimName; // 請求先名称
            custDmdPrcWork.ClaimName2 = custDmdPrc.ClaimName2; // 請求先名称2
            custDmdPrcWork.ClaimSnm = custDmdPrc.ClaimSnm; // 請求先略称
            custDmdPrcWork.CustomerCode = custDmdPrc.CustomerCode; // 得意先コード
            custDmdPrcWork.CustomerName = custDmdPrc.CustomerName; // 得意先名称
            custDmdPrcWork.CustomerName2 = custDmdPrc.CustomerName2; // 得意先名称2
            custDmdPrcWork.CustomerSnm = custDmdPrc.CustomerSnm; // 得意先略称
            custDmdPrcWork.AddUpDate = custDmdPrc.AddUpDate; // 計上年月日
            custDmdPrcWork.AddUpYearMonth = custDmdPrc.AddUpYearMonth; // 計上年月
            custDmdPrcWork.LastTimeDemand = custDmdPrc.LastTimeDemand; // 前回請求金額
            custDmdPrcWork.ThisTimeFeeDmdNrml = custDmdPrc.ThisTimeFeeDmdNrml; // 今回手数料額（通常入金）
            custDmdPrcWork.ThisTimeDisDmdNrml = custDmdPrc.ThisTimeDisDmdNrml; // 今回値引額（通常入金）
            custDmdPrcWork.ThisTimeDmdNrml = custDmdPrc.ThisTimeDmdNrml; // 今回入金金額（通常入金）
            custDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrc.ThisTimeTtlBlcDmd; // 今回繰越残高（請求計）
            custDmdPrcWork.OfsThisTimeSales = custDmdPrc.OfsThisTimeSales; // 相殺後今回売上金額
            custDmdPrcWork.OfsThisSalesTax = custDmdPrc.OfsThisSalesTax; // 相殺後今回売上消費税
            custDmdPrcWork.ItdedOffsetOutTax = custDmdPrc.ItdedOffsetOutTax; // 相殺後外税対象額
            custDmdPrcWork.ItdedOffsetInTax = custDmdPrc.ItdedOffsetInTax; // 相殺後内税対象額
            custDmdPrcWork.ItdedOffsetTaxFree = custDmdPrc.ItdedOffsetTaxFree; // 相殺後非課税対象額
            custDmdPrcWork.OffsetOutTax = custDmdPrc.OffsetOutTax; // 相殺後外税消費税
            custDmdPrcWork.OffsetInTax = custDmdPrc.OffsetInTax; // 相殺後内税消費税
            custDmdPrcWork.ThisTimeSales = custDmdPrc.ThisTimeSales; // 今回売上金額
            custDmdPrcWork.ThisSalesTax = custDmdPrc.ThisSalesTax; // 今回売上消費税
            custDmdPrcWork.ItdedSalesOutTax = custDmdPrc.ItdedSalesOutTax; // 売上外税対象額
            custDmdPrcWork.ItdedSalesInTax = custDmdPrc.ItdedSalesInTax; // 売上内税対象額
            custDmdPrcWork.ItdedSalesTaxFree = custDmdPrc.ItdedSalesTaxFree; // 売上非課税対象額
            custDmdPrcWork.SalesOutTax = custDmdPrc.SalesOutTax; // 売上外税額
            custDmdPrcWork.SalesInTax = custDmdPrc.SalesInTax; // 売上内税額
            custDmdPrcWork.ThisSalesPricRgds = custDmdPrc.ThisSalesPricRgds; // 今回売上返品金額
            custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrc.ThisSalesPrcTaxRgds; // 今回売上返品消費税
            custDmdPrcWork.TtlItdedRetOutTax = custDmdPrc.TtlItdedRetOutTax; // 返品外税対象額合計
            custDmdPrcWork.TtlItdedRetInTax = custDmdPrc.TtlItdedRetInTax; // 返品内税対象額合計
            custDmdPrcWork.TtlItdedRetTaxFree = custDmdPrc.TtlItdedRetTaxFree; // 返品非課税対象額合計
            custDmdPrcWork.TtlRetOuterTax = custDmdPrc.TtlRetOuterTax; // 返品外税額合計
            custDmdPrcWork.TtlRetInnerTax = custDmdPrc.TtlRetInnerTax; // 返品内税額合計
            custDmdPrcWork.ThisSalesPricDis = custDmdPrc.ThisSalesPricDis; // 今回売上値引金額
            custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrc.ThisSalesPrcTaxDis; // 今回売上値引消費税
            custDmdPrcWork.TtlItdedDisOutTax = custDmdPrc.TtlItdedDisOutTax; // 値引外税対象額合計
            custDmdPrcWork.TtlItdedDisInTax = custDmdPrc.TtlItdedDisInTax; // 値引内税対象額合計
            custDmdPrcWork.TtlItdedDisTaxFree = custDmdPrc.TtlItdedDisTaxFree; // 値引非課税対象額合計
            custDmdPrcWork.TtlDisOuterTax = custDmdPrc.TtlDisOuterTax; // 値引外税額合計
            custDmdPrcWork.TtlDisInnerTax = custDmdPrc.TtlDisInnerTax; // 値引内税額合計

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custDmdPrcWork.ThisPayOffset = custDmdPrc.ThisPayOffset; // 今回支払相殺金額
            //custDmdPrcWork.ThisPayOffsetTax = custDmdPrc.ThisPayOffsetTax; // 今回支払相殺消費税
            //custDmdPrcWork.ItdedPaymOutTax = custDmdPrc.ItdedPaymOutTax; // 支払外税対象額
            //custDmdPrcWork.ItdedPaymInTax = custDmdPrc.ItdedPaymInTax; // 支払内税対象額
            //custDmdPrcWork.ItdedPaymTaxFree = custDmdPrc.ItdedPaymTaxFree; // 支払非課税対象額
            //custDmdPrcWork.PaymentOutTax = custDmdPrc.PaymentOutTax; // 支払外税消費税
            //custDmdPrcWork.PaymentInTax = custDmdPrc.PaymentInTax; // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            custDmdPrcWork.TaxAdjust = custDmdPrc.TaxAdjust; // 消費税調整額
            custDmdPrcWork.BalanceAdjust = custDmdPrc.BalanceAdjust; // 残高調整額
            custDmdPrcWork.AfCalDemandPrice = custDmdPrc.AfCalDemandPrice; // 計算後請求金額
            custDmdPrcWork.AcpOdrTtl2TmBfBlDmd = custDmdPrc.AcpOdrTtl2TmBfBlDmd; // 受注2回前残高（請求計）
            custDmdPrcWork.AcpOdrTtl3TmBfBlDmd = custDmdPrc.AcpOdrTtl3TmBfBlDmd; // 受注3回前残高（請求計）
            custDmdPrcWork.CAddUpUpdExecDate = custDmdPrc.CAddUpUpdExecDate; // 締次更新実行年月日
            custDmdPrcWork.StartCAddUpUpdDate = custDmdPrc.StartCAddUpUpdDate; // 締次更新開始年月日
            custDmdPrcWork.LastCAddUpUpdDate = custDmdPrc.LastCAddUpUpdDate; // 前回締次更新年月日
            custDmdPrcWork.SalesSlipCount = custDmdPrc.SalesSlipCount; // 売上伝票枚数
            custDmdPrcWork.BillPrintDate = custDmdPrc.BillPrintDate; // 請求書発行日
            custDmdPrcWork.ExpectedDepositDate = custDmdPrc.ExpectedDepositDate; // 入金予定日
            custDmdPrcWork.CollectCond = custDmdPrc.CollectCond; // 回収条件
            custDmdPrcWork.ConsTaxLayMethod = custDmdPrc.ConsTaxLayMethod; // 消費税転嫁方式
            custDmdPrcWork.ConsTaxRate = custDmdPrc.ConsTaxRate; // 消費税率
            custDmdPrcWork.FractionProcCd = custDmdPrc.FractionProcCd; // 端数処理区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2009/06/23 ------>>>
            custDmdPrcWork.BillNo = custDmdPrc.BillNo; // 請求書No
            // ADD 2009/06/23 ------<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( custDmdPrcWork.CustomerCode == custDmdPrcWork.ClaimCode )
            //{
            //    custDmdPrcWork.CustomerCode = 0;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
        }

        #region    ********** 不要 **********
        /// <summary>クラスメンバコピー処理 (得意先売掛金額マスタワーククラス⇒得意先売掛金額マスタクラス)
		/// </summary>
        /// <param name="financStmntOutWork">得意先売掛金額マスタワーククラス</param>
        /// <returns>得意先売掛金額マスタクラス</returns>
		/// <remarks>
        /// <br>Note       : 得意先売掛金額マスタワーククラスから
        ///                  得意先売掛金額マスタクラスへメンバコピーを行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        //private CustAccRec CopyToFinancStmntOutFromFinancStmntOutWork(CustAccRecWork custAccRecWork)
        //{
        //    FinancStmntOut financStmntOut = new FinancStmntOut();

        //    custAccRec.CreateDateTime       = custAccRecWork.CreateDateTime;       // 作成日時
        //    custAccRec.UpdateDateTime       = custAccRecWork.UpdateDateTime;       // 更新日時
        //    custAccRec.EnterpriseCode       = custAccRecWork.EnterpriseCode;       // 企業コード
        //    custAccRec.FileHeaderGuid       = custAccRecWork.FileHeaderGuid;       // GUID
        //    custAccRec.UpdEmployeeCode      = custAccRecWork.UpdEmployeeCode;      // 更新従業員コード
        //    custAccRec.UpdAssemblyId1       = custAccRecWork.UpdAssemblyId1;       // 更新アセンブリID1
        //    custAccRec.UpdAssemblyId2       = custAccRecWork.UpdAssemblyId2;       // 更新アセンブリID2
        //    custAccRec.LogicalDeleteCode    = custAccRecWork.LogicalDeleteCode;    // 論理削除区分
        //    custAccRec.EnterpriseCode       = custAccRecWork.EnterpriseCode;
        //    custAccRec.AddUpSecCode         = custAccRecWork.AddUpSecCode;
        //    custAccRec.CustomerCode         = custAccRecWork.CustomerCode;
        //    custAccRec.CustomerName         = custAccRecWork.CustomerName;
        //    custAccRec.CustomerName2        = custAccRecWork.CustomerName2;
        //    custAccRec.AddUpDate            = custAccRecWork.AddUpDate;
        //    custAccRec.AddUpYearMonth       = custAccRecWork.AddUpYearMonth;
        //    custAccRec.LastTimeAccRec       = custAccRecWork.LastTimeAccRec;
        //    custAccRec.ThisTimeDmdNrml      = custAccRecWork.ThisTimeDmdNrml;
        //    custAccRec.ThisTimeFeeDmdNrml   = custAccRecWork.ThisTimeFeeDmdNrml;
        //    custAccRec.ThisTimeDisDmdNrml   = custAccRecWork.ThisTimeDisDmdNrml;
        //    custAccRec.ThisTimeRbtDmdNrml   = custAccRecWork.ThisTimeRbtDmdNrml;
        //    custAccRec.ThisTimeDmdDepo      = custAccRecWork.ThisTimeDmdDepo;
        //    custAccRec.ThisTimeFeeDmdDepo   = custAccRecWork.ThisTimeFeeDmdDepo;
        //    custAccRec.ThisTimeDisDmdDepo   = custAccRecWork.ThisTimeDisDmdDepo;
        //    custAccRec.ThisTimeRbtDmdDepo   = custAccRecWork.ThisTimeRbtDmdDepo;
        //    custAccRec.ThisTimeTtlBlcAcc    = custAccRecWork.ThisTimeTtlBlcAcc;
        //    custAccRec.ThisTimeSales        = custAccRecWork.ThisTimeSales;
        //    custAccRec.ThisSalesTax         = custAccRecWork.ThisSalesTax;
        //    custAccRec.TtlIncDtbtTaxExc     = custAccRecWork.TtlIncDtbtTaxExc;
        //    custAccRec.TtlIncDtbtTax        = custAccRecWork.TtlIncDtbtTax;
        //    custAccRec.OfsThisTimeSales     = custAccRecWork.OfsThisTimeSales;
        //    custAccRec.OfsThisSalesTax      = custAccRecWork.OfsThisSalesTax;
        //    custAccRec.ItdedOffsetOutTax    = custAccRecWork.ItdedOffsetOutTax;
        //    custAccRec.ItdedOffsetInTax     = custAccRecWork.ItdedOffsetInTax;
        //    custAccRec.ItdedOffsetTaxFree   = custAccRecWork.ItdedOffsetTaxFree;
        //    custAccRec.OffsetOutTax         = custAccRecWork.OffsetOutTax;
        //    custAccRec.OffsetInTax          = custAccRecWork.OffsetInTax;
        //    custAccRec.ItdedSalesOutTax     = custAccRecWork.ItdedSalesOutTax;
        //    custAccRec.ItdedSalesInTax      = custAccRecWork.ItdedSalesInTax;
        //    custAccRec.ItdedSalesTaxFree    = custAccRecWork.ItdedSalesTaxFree;
        //    custAccRec.SalesOutTax          = custAccRecWork.SalesOutTax;
        //    custAccRec.SalesInTax           = custAccRecWork.SalesInTax;
        //    custAccRec.ItdedPaymOutTax      = custAccRecWork.ItdedPaymOutTax;
        //    custAccRec.ItdedPaymInTax       = custAccRecWork.ItdedPaymInTax;
        //    custAccRec.ItdedPaymTaxFree     = custAccRecWork.ItdedPaymTaxFree;
        //    custAccRec.PaymentOutTax        = custAccRecWork.PaymentOutTax;
        //    custAccRec.PaymentInTax         = custAccRecWork.PaymentInTax;
        //    custAccRec.ConsTaxLayMethod     = custAccRecWork.ConsTaxLayMethod;
        //    custAccRec.ConsTaxRate          = custAccRecWork.ConsTaxRate;
        //    custAccRec.FractionProcCd       = custAccRecWork.FractionProcCd;
        //    custAccRec.AfCalTMonthAccRec    = custAccRecWork.AfCalTMonthAccRec;
        //    custAccRec.AcpOdrTtl2TmBfAccRec = custAccRecWork.AcpOdrTtl2TmBfAccRec;
        //    custAccRec.AcpOdrTtl3TmBfAccRec = custAccRecWork.AcpOdrTtl3TmBfAccRec;
        //    custAccRec.MonthAddUpExpDate    = custAccRecWork.MonthAddUpExpDate;

        //    // テーブル更新
        //    this._custAccRecDic[custAccRecWork.FileHeaderGuid] = custAccRecWork;

        //    return custAccRec;
        //}
        #endregion ********** 不要 **********

        /// <summary>得意先売掛金額マスタオブジェクトメインDataSet展開処理</summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先売掛金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private void CustAccRecWorkToDataSet(CustAccRecWork custAccRecWork)
        private void CustAccRecWorkToDataSet(CustAccRecWork custAccRecWork, ArrayList accRecDepoTotalWorkArrayList)
        // 2009.01.06 <<<
        {
            // 2009.01.06 Del >>>
            //// 親レコードの場合は得意先コードに請求先コードと同値を再設定
            //if (custAccRecWork.CustomerCode == 0) {
            //    custAccRecWork.CustomerCode = custAccRecWork.ClaimCode;
            //}
            // 2009.01.06 Del <<<

            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            object[] primryKey = new object[] { custAccRecWork.AddUpSecCode, 
                                                custAccRecWork.ClaimCode,
                                                custAccRecWork.CustomerCode, 
                                                TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate) };
            DataRow dr = this._custAccRecTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._custAccRecTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 2009.01.06 >>>
            // 実際のデータセットは別メソッドで行うためコメントアウト
#if false
            // 削除日
            if (custAccRecWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custAccRecWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = custAccRecWork.AddUpSecCode;                                           // 計上拠点コード
            dr[COL_CUSTOMERCODE_TITLE]         = custAccRecWork.CustomerCode;                                           // 得意先コード

            dr[COL_CUSTOMERNAME_TITLE]         = custAccRecWork.CustomerName;                                           // 得意先名称
            dr[COL_CUSTOMERNAME2_TITLE]        = custAccRecWork.CustomerName2;                                          // 得意先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CUSTOMERSNM_TITLE]          = custAccRecWork.CustomerSnm;                                            // 得意先略称
            dr[COL_CLAIMCODE_TITLE]            = custAccRecWork.ClaimCode;                                              // 請求先コード
            dr[COL_CLAIMNAME_TITLE]            = custAccRecWork.ClaimName;                                              // 請求先名称
            dr[COL_CLAIMNAME2_TITLE]           = custAccRecWork.ClaimName2;                                             // 請求先名称2
            dr[COL_CLAIMSNM_TITLE]             = custAccRecWork.ClaimSnm;                                               // 請求先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE]          = TDateTime.DateTimeToString("YYYY/MM/DD", custAccRecWork.AddUpDate);    // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", custAccRecWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate);                // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpYearMonth);           // _計上年月
            dr[COL_LASTTIMEACCREC_TITLE]       = custAccRecWork.LastTimeAccRec;                                         // 前回売掛金額
            dr[COL_THISTIMEDMDNRML_TITLE]      = custAccRecWork.ThisTimeDmdNrml;                                        // 今回入金金額（通常入金）
            dr[COL_THISTIMEFEEDMDNRML_TITLE]   = custAccRecWork.ThisTimeFeeDmdNrml;                                     // 今回手数料額（通常入金）
            dr[COL_THISTIMEDISDMDNRML_TITLE]   = custAccRecWork.ThisTimeDisDmdNrml;                                     // 今回値引額（通常入金）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = custAccRecWork.ThisTimeRbtDmdNrml;                                     // 今回リベート額（通常入金）
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = custAccRecWork.ThisTimeDmdDepo;                                        // 今回入金金額（預り金）
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = custAccRecWork.ThisTimeFeeDmdDepo;                                     // 今回手数料額（預り金）
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = custAccRecWork.ThisTimeDisDmdDepo;                                     // 今回値引額（預り金）
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = custAccRecWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEDEPODMD_TITLE]      = custAccRecWork.ThisTimeDmdNrml    +                                    // 今回入金金額（通常入金）
            //                                     custAccRecWork.ThisTimeFeeDmdNrml +                                    // 今回手数料額（通常入金）
            //                                     custAccRecWork.ThisTimeDisDmdNrml +                                    // 今回値引額（通常入金）
            //                                     custAccRecWork.ThisTimeRbtDmdNrml +                                    // 今回リベート額（通常入金）
            //                                     custAccRecWork.ThisTimeDmdDepo    +                                    // 今回入金金額（預り金）
            //                                     custAccRecWork.ThisTimeFeeDmdDepo +                                    // 今回手数料額（預り金）
            //                                     custAccRecWork.ThisTimeDisDmdDepo +                                    // 今回値引額（預り金）
            //                                     custAccRecWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            dr[COL_THISTIMEDEPODMD_TITLE] = custAccRecWork.ThisTimeDmdNrml +                                    // 今回入金金額（通常入金）
                                                 custAccRecWork.ThisTimeFeeDmdNrml +                                    // 今回手数料額（通常入金）
                                                 custAccRecWork.ThisTimeDisDmdNrml ;                                    // 今回値引額（通常入金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCACC_TITLE]    = custAccRecWork.ThisTimeTtlBlcAcc;                                      // 今回繰越残高（売掛計）
            dr[COL_THISTIMESALES_TITLE]        = custAccRecWork.ThisTimeSales;                                          // 今回売上金額
            dr[COL_THISSALESTAX_TITLE]         = custAccRecWork.ThisSalesTax;                                           // 今回売上消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = custAccRecWork.TtlIncDtbtTaxExc;                                       // 支払インセンティブ額合計（税抜き）
            //dr[COL_TTLINCDTBTTAX_TITLE]        = custAccRecWork.TtlIncDtbtTax;                                          // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_OFSTHISTIMESALES_TITLE]     = custAccRecWork.OfsThisTimeSales;                                       // 相殺後今回売上金額
            dr[COL_OFSTHISSALESTAX_TITLE]      = custAccRecWork.OfsThisSalesTax;                                        // 相殺後今回売上消費税
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = custAccRecWork.ItdedOffsetOutTax;                                      // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = custAccRecWork.ItdedOffsetInTax;                                       // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = custAccRecWork.ItdedOffsetTaxFree;                                     // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE]         = custAccRecWork.OffsetOutTax;                                           // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE]          = custAccRecWork.OffsetInTax;                                            // 相殺後内税消費税
            dr[COL_ITDEDSALESOUTTAX_TITLE]     = custAccRecWork.ItdedSalesOutTax;                                       // 売上外税対象額
            dr[COL_ITDEDSALESINTAX_TITLE]      = custAccRecWork.ItdedSalesInTax;                                        // 売上内税対象額
            dr[COL_ITDEDSALESTAXFREE_TITLE]    = custAccRecWork.ItdedSalesTaxFree;                                      // 売上非課税対象額
            dr[COL_SALESOUTTAX_TITLE]          = custAccRecWork.SalesOutTax;                                            // 売上外税額
            dr[COL_SALESINTAX_TITLE]           = custAccRecWork.SalesInTax;                                             // 売上内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = custAccRecWork.ItdedPaymOutTax;                                        // 支払外税対象額
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = custAccRecWork.ItdedPaymInTax;                                         // 支払内税対象額
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = custAccRecWork.ItdedPaymTaxFree;                                       // 支払非課税対象額
            //dr[COL_PAYMENTOUTTAX_TITLE]        = custAccRecWork.PaymentOutTax;                                          // 支払外税消費税
            //dr[COL_PAYMENTINTAX_TITLE]         = custAccRecWork.PaymentInTax;                                           // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = custAccRecWork.TtlItdedRetOutTax;                                       // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE]     = custAccRecWork.TtlItdedRetInTax;                                        // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = custAccRecWork.TtlItdedRetTaxFree;                                      // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE]       = custAccRecWork.TtlRetOuterTax;                                            // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE]       = custAccRecWork.TtlRetInnerTax;                                             // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = custAccRecWork.TtlItdedDisOutTax;                                       // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE]     = custAccRecWork.TtlItdedDisInTax;                                        // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = custAccRecWork.TtlItdedDisTaxFree;                                      // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE]       = custAccRecWork.TtlDisOuterTax;                                            // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE]       = custAccRecWork.TtlDisInnerTax;                                             // 値引内税額
            dr[COL_BALANCEADJUST_TITLE] = custAccRecWork.BalanceAdjust;                                          // 残高調整額
            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            // 調整額(表示のみ)
            dr[COL_TOTALADJUST_TITLE] = custAccRecWork.BalanceAdjust + custAccRecWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_NONSTMNTAPPEARANCE_TITLE]   = custAccRecWork.NonStmntAppearance;                                     // 未決済金額（自振）
            //dr[COL_NONSTMNTISDONE_TITLE]       = custAccRecWork.NonStmntIsdone;                                         // 未決済金額（廻し） 
            //dr[COL_STMNTAPPEARANCE_TITLE]      = custAccRecWork.StmntAppearance;                                        // 決済金額（自振）
            //dr[COL_STMNTISDONE_TITLE]          = custAccRecWork.StmntIsdone;                                            // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //dr[COL_THISCASHSALEPRICE]          = custAccRecWork.ThisCashSalePrice;                                      // 現金売上金額
            //dr[COL_THISCASHSALETAX]            = custAccRecWork.ThisCashSaleTax;                                        // 現金売上消費税額
            //dr[COL_SALESSLIPCOUNT]             = 0;                                                                     // （伝票枚数）
            dr[COL_BILLPRINTDATE_TITLE]              = 0;                                                                     // （請求書発行日）
            dr[COL_EXPECTEDDEPOSITDATE_TITLE]        = 0;                                                                     // （入金予定日）
            dr[COL_COLLECTCOND_TITLE]                = 0;                                                                     // （回収条件）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_CONSTAXLAYMETHOD_TITLE]     = custAccRecWork.ConsTaxLayMethod;                                       // 消費税転嫁方式
            dr[COL_CONSTAXRATE_TITLE]          = custAccRecWork.ConsTaxRate;                                            // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE]       = custAccRecWork.FractionProcCd;                                         // 端数処理区分
            dr[COL_AFCALTMONTHACCREC_TITLE]    = custAccRecWork.AfCalTMonthAccRec;                                      // 計算後当月売掛金額
            //dr[COL_AFCALTMONTHACCREC_TITLE] = custAccRecWork.AfCalTMonthAccRec + custAccRecWork.BalanceAdjust + custAccRecWork.TaxAdjust;  // 計算後当月売掛金額
            dr[COL_ACPODRTTL2TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl2TmBfAccRec;                                   // 受注2回前残高（売掛計）
            dr[COL_ACPODRTTL3TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl3TmBfAccRec;                                   // 受注3回前残高（売掛計）
            dr[COL_MONTHADDUPEXPDATE_TITLE]    = TDateTime.DateTimeToLongDate(custAccRecWork.MonthAddUpExpDate);        // 月次更新実行年月日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_SALESSLIPCOUNT_TITLE] = custAccRecWork.SalesSlipCount;  // （伝票枚数）

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_THISPAYOFFSET_TITLE] = custAccRecWork.ThisPayOffset; // 今回支払相殺金額
            //dr[COL_THISPAYOFFSETTAX_TITLE] = custAccRecWork.ThisPayOffsetTax; // 今回支払相殺消費税
            //dr[COL_ITDEDPAYMOUTTAX_TITLE] = custAccRecWork.ItdedPaymOutTax; // 支払外税対象額
            //dr[COL_ITDEDPAYMINTAX_TITLE] = custAccRecWork.ItdedPaymInTax; // 支払内税対象額
            //dr[COL_ITDEDPAYMTAXFREE_TITLE] = custAccRecWork.ItdedPaymTaxFree; // 支払非課税対象額
            //dr[COL_PAYMENTOUTTAX_TITLE] = custAccRecWork.PaymentOutTax; // 支払外税消費税
            //dr[COL_PAYMENTINTAX_TITLE] = custAccRecWork.PaymentInTax; // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust; // 消費税調整額
            //dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust + custAccRecWork.BalanceAdjust; // 消費税調整額 + 残高調整額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_GUID_TITLE]                 = custAccRecWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = custAccRecWork.CreateDateTime; // 作成日時
            dr[COL_UPDATEDATETIME] = custAccRecWork.UpdateDateTime; // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, custAccRecWork, accRecDepoTotalWorkArrayList);
            // 2009.01.06 <<<

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._custAccRecTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._custAccRecDic.ContainsKey(custAccRecWork.FileHeaderGuid) == true)
            {
                this._custAccRecDic.Remove(custAccRecWork.FileHeaderGuid);
            }
            this._custAccRecDic.Add(custAccRecWork.FileHeaderGuid, custAccRecWork);
        }

        /// <summary>得意先請求金額マスタオブジェクトメインDataSet展開処理</summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private void CustDmdPrcWorkToDataSet(CustDmdPrcWork custDmdPrcWork)
        private void CustDmdPrcWorkToDataSet(CustDmdPrcWork custDmdPrcWork, ArrayList dmdDepoTotalWorkArrayList)
        // 2009.01.06 <<<
        {
            // 2009.01.06 Del >>>
            //// 親レコードの場合は得意先コードに請求先コードと同値を再設定
            //if ( custDmdPrcWork.CustomerCode == 0 ) {
            //    custDmdPrcWork.CustomerCode = custDmdPrcWork.ClaimCode;
            //}
            // 2009.01.06 Del <<<


            bool newFlg = false;    // 新規・既存フラグ

            // 更新対象行の取得
            object[] primryKey = new object[] { custDmdPrcWork.AddUpSecCode,
                                                custDmdPrcWork.ClaimCode,
                                                custDmdPrcWork.CustomerCode, 
                                                custDmdPrcWork.ResultsSectCd, //実績拠点コード
                                                TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate) };
            DataRow dr = this._custDmdPrcTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // 新規に行を作成
                dr = this._custDmdPrcTable.NewRow();

                // 新規レコードチェック
                newFlg = true;
            }

            // 2009.01.06 >>>

            // 実際のデータセットは別メソッドで行うためコメントアウト
#if false
            // 削除日
            if (custDmdPrcWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custDmdPrcWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = custDmdPrcWork.AddUpSecCode;                                           // 計上拠点コード

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            dr[COL_RESULTSECCODE_TITLE]        = custDmdPrcWork.ResultsSectCd;                                          // 実績拠点コード
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            dr[COL_CUSTOMERCODE_TITLE]         = custDmdPrcWork.CustomerCode;                                           // 得意先コード
            dr[COL_CUSTOMERNAME_TITLE]         = custDmdPrcWork.CustomerName;                                           // 得意先名称
            dr[COL_CUSTOMERNAME2_TITLE]        = custDmdPrcWork.CustomerName2;                                          // 得意先名称2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CUSTOMERSNM_TITLE]          = custDmdPrcWork.CustomerSnm;                                            // 得意先略称
            dr[COL_CLAIMCODE_TITLE]            = custDmdPrcWork.ClaimCode;                                              // 得意先コード
            dr[COL_CLAIMNAME_TITLE]            = custDmdPrcWork.ClaimName;                                              // 得意先名称
            dr[COL_CLAIMNAME2_TITLE]           = custDmdPrcWork.ClaimName2;                                             // 得意先名称2
            dr[COL_CLAIMSNM_TITLE]             = custDmdPrcWork.ClaimSnm;                                               // 得意先略称
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", custDmdPrcWork.AddUpDate);    // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", custDmdPrcWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate);                // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpYearMonth);           // _計上年月
            dr[COL_LASTTIMEDEMAND_TITLE]       = custDmdPrcWork.LastTimeDemand;                                         // 前回請求金額
            dr[COL_THISTIMEDMDNRML_TITLE]      = custDmdPrcWork.ThisTimeDmdNrml;                                        // 今回入金金額（通常入金）
            dr[COL_THISTIMEFEEDMDNRML_TITLE]   = custDmdPrcWork.ThisTimeFeeDmdNrml;                                     // 今回手数料額（通常入金）
            dr[COL_THISTIMEDISDMDNRML_TITLE]   = custDmdPrcWork.ThisTimeDisDmdNrml;                                     // 今回値引額（通常入金）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = custDmdPrcWork.ThisTimeRbtDmdNrml;                                     // 今回リベート額（通常入金）
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = custDmdPrcWork.ThisTimeDmdDepo;                                        // 今回入金金額（預り金）
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = custDmdPrcWork.ThisTimeFeeDmdDepo;                                     // 今回手数料額（預り金）
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = custDmdPrcWork.ThisTimeDisDmdDepo;                                     // 今回値引額（預り金）
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = custDmdPrcWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEDEPODMD_TITLE]      = custDmdPrcWork.ThisTimeDmdNrml    +                                    // 今回入金金額（通常入金）
            //                                     custDmdPrcWork.ThisTimeFeeDmdNrml +                                    // 今回手数料額（通常入金）
            //                                     custDmdPrcWork.ThisTimeDisDmdNrml +                                    // 今回値引額（通常入金）
            //                                     custDmdPrcWork.ThisTimeRbtDmdNrml +                                    // 今回リベート額（通常入金）
            //                                     custDmdPrcWork.ThisTimeDmdDepo    +                                    // 今回入金金額（預り金）
            //                                     custDmdPrcWork.ThisTimeFeeDmdDepo +                                    // 今回手数料額（預り金）
            //                                     custDmdPrcWork.ThisTimeDisDmdDepo +                                    // 今回値引額（預り金）
            //                                     custDmdPrcWork.ThisTimeRbtDmdDepo;                                     // 今回リベート額（預り金）
            dr[COL_THISTIMEDEPODMD_TITLE] = custDmdPrcWork.ThisTimeDmdNrml +                                    // 今回入金金額（通常入金）
                                                 custDmdPrcWork.ThisTimeFeeDmdNrml +                                    // 今回手数料額（通常入金）
                                                 custDmdPrcWork.ThisTimeDisDmdNrml ;                                    // 今回値引額（通常入金）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCDMD_TITLE]    = custDmdPrcWork.ThisTimeTtlBlcDmd;                                      // 今回繰越残高（請求計）
            dr[COL_THISTIMESALES_TITLE]        = custDmdPrcWork.ThisTimeSales;                                          // 今回売上金額
            dr[COL_THISSALESTAX_TITLE]         = custDmdPrcWork.ThisSalesTax;                                           // 今回売上消費税
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = custDmdPrcWork.TtlIncDtbtTaxExc;                                       // 支払インセンティブ額合計（税抜き）
            //dr[COL_TTLINCDTBTTAX_TITLE]        = custDmdPrcWork.TtlIncDtbtTax;                                          // 支払インセンティブ額合計（税）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_OFSTHISTIMESALES_TITLE]     = custDmdPrcWork.OfsThisTimeSales;                                       // 相殺後今回売上金額
            dr[COL_OFSTHISSALESTAX_TITLE]      = custDmdPrcWork.OfsThisSalesTax;                                        // 相殺後今回売上消費税
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = custDmdPrcWork.ItdedOffsetOutTax;                                      // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = custDmdPrcWork.ItdedOffsetInTax;                                       // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = custDmdPrcWork.ItdedOffsetTaxFree;                                     // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE]         = custDmdPrcWork.OffsetOutTax;                                           // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE]          = custDmdPrcWork.OffsetInTax;                                            // 相殺後内税消費税
            dr[COL_ITDEDSALESOUTTAX_TITLE]     = custDmdPrcWork.ItdedSalesOutTax;                                       // 売上外税対象額
            dr[COL_ITDEDSALESINTAX_TITLE]      = custDmdPrcWork.ItdedSalesInTax;                                        // 売上内税対象額
            dr[COL_ITDEDSALESTAXFREE_TITLE]    = custDmdPrcWork.ItdedSalesTaxFree;                                      // 売上非課税対象額
            dr[COL_SALESOUTTAX_TITLE]          = custDmdPrcWork.SalesOutTax;                                            // 売上外税額
            dr[COL_SALESINTAX_TITLE]           = custDmdPrcWork.SalesInTax;                                             // 売上内税額
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = custDmdPrcWork.ItdedPaymOutTax;                                        // 支払外税対象額
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = custDmdPrcWork.ItdedPaymInTax;                                         // 支払内税対象額
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = custDmdPrcWork.ItdedPaymTaxFree;                                       // 支払非課税対象額
            //dr[COL_PAYMENTOUTTAX_TITLE]        = custDmdPrcWork.PaymentOutTax;                                          // 支払外税消費税
            //dr[COL_PAYMENTINTAX_TITLE]         = custDmdPrcWork.PaymentInTax;                                           // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = custDmdPrcWork.TtlItdedRetOutTax;                                       // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE]     = custDmdPrcWork.TtlItdedRetInTax;                                        // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = custDmdPrcWork.TtlItdedRetTaxFree;                                      // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE]       = custDmdPrcWork.TtlRetOuterTax;                                            // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE]       = custDmdPrcWork.TtlRetInnerTax;                                             // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = custDmdPrcWork.TtlItdedDisOutTax;                                       // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE]     = custDmdPrcWork.TtlItdedDisInTax;                                        // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = custDmdPrcWork.TtlItdedDisTaxFree;                                      // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE]       = custDmdPrcWork.TtlDisOuterTax;                                            // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE]       = custDmdPrcWork.TtlDisInnerTax;                                             // 値引内税額

            dr[COL_BALANCEADJUST_TITLE] = custDmdPrcWork.BalanceAdjust;                          // 残高調整額
            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            // 調整額(標示用のみ)
            dr[COL_TOTALADJUST_TITLE] = custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            dr[COL_NONSTMNTAPPEARANCE_TITLE]   = 0;                                                                     // 未決済金額（自振）
            dr[COL_NONSTMNTISDONE_TITLE]       = 0;                                                                     // 未決済金額（廻し） 
            dr[COL_STMNTAPPEARANCE_TITLE]      = 0;                                                                     // 決済金額（自振）
            dr[COL_STMNTISDONE_TITLE]          = 0;                                                                     // 決済金額（廻し）
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //dr[COL_THISCASHSALEPRICE]          = 0;                                                                     // 現金売上金額
            //dr[COL_THISCASHSALETAX]            = 0;                                                                     // 現金売上消費税額
            dr[COL_SALESSLIPCOUNT_TITLE]             = custDmdPrcWork.SalesSlipCount;                                         // 伝票枚数
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_BILLPRINTDATE_TITLE] = custDmdPrcWork.BillPrintDate;                                          // 請求書発行日
            dr[COL_BILLPRINTDATE_TITLE] = TDateTime.DateTimeToLongDate( custDmdPrcWork.BillPrintDate );                                          // 請求書発行日
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki            
            dr[COL_EXPECTEDDEPOSITDATE_TITLE]        = TDateTime.DateTimeToLongDate(custDmdPrcWork.ExpectedDepositDate);      // 入金予定日
            dr[COL_COLLECTCOND_TITLE]                = custDmdPrcWork.CollectCond;                                            // 回収条件
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_CONSTAXLAYMETHOD_TITLE]     = custDmdPrcWork.ConsTaxLayMethod;                                       // 消費税転嫁方式
            dr[COL_CONSTAXRATE_TITLE]          = custDmdPrcWork.ConsTaxRate;                                            // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE]       = custDmdPrcWork.FractionProcCd;                                         // 端数処理区分
            dr[COL_AFCALDEMANDPRICE_TITLE]     = custDmdPrcWork.AfCalDemandPrice;                                       // 計算後請求金額
            //dr[COL_AFCALDEMANDPRICE_TITLE] = custDmdPrcWork.AfCalDemandPrice + custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;     // 計算後請求金額
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE]  = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;                                    // 受注2回前残高（請求計）
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE]  = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;                                    // 受注3回前残高（請求計）
            dr[COL_CADDUPUPDEXECDATE_TITLE]    = TDateTime.DateTimeToLongDate(custDmdPrcWork.CAddUpUpdExecDate);        // 締次更新実行年月日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_DMDPROCNUM_TITLE]           = custDmdPrcWork.DmdProcNum;                                             // 請求処理通番
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            //dr[COL_THISPAYOFFSET_TITLE] = custDmdPrcWork.ThisPayOffset; // 今回支払相殺金額
            //dr[COL_THISPAYOFFSETTAX_TITLE] = custDmdPrcWork.ThisPayOffsetTax; // 今回支払相殺消費税
            //dr[COL_ITDEDPAYMOUTTAX_TITLE] = custDmdPrcWork.ItdedPaymOutTax; // 支払外税対象額
            //dr[COL_ITDEDPAYMINTAX_TITLE] = custDmdPrcWork.ItdedPaymInTax; // 支払内税対象額
            //dr[COL_ITDEDPAYMTAXFREE_TITLE] = custDmdPrcWork.ItdedPaymTaxFree; // 支払非課税対象額
            //dr[COL_PAYMENTOUTTAX_TITLE] = custDmdPrcWork.PaymentOutTax; // 支払外税消費税
            //dr[COL_PAYMENTINTAX_TITLE] = custDmdPrcWork.PaymentInTax; // 支払内税消費税
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust; // 消費税調整額
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_GUID_TITLE]                 = custDmdPrcWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = custDmdPrcWork.CreateDateTime; // 作成日時
            dr[COL_UPDATEDATETIME] = custDmdPrcWork.UpdateDateTime; // 更新日時
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, custDmdPrcWork, dmdDepoTotalWorkArrayList);

            // 2009.01.06 <<<

            // 新規レコードの場合のみ
            if (newFlg == true)
            {
                // 新規行の追加
                this._custDmdPrcTable.Rows.Add(dr);
            }

            // テーブルに格納
            if (this._custDmdPrcDic.ContainsKey(custDmdPrcWork.FileHeaderGuid) == true)
            {
                this._custDmdPrcDic.Remove(custDmdPrcWork.FileHeaderGuid);
            }
            this._custDmdPrcDic.Add(custDmdPrcWork.FileHeaderGuid, custDmdPrcWork);
        }

        // 2009.01.06 Add >>>
        /// <summary>
        /// 得意先売掛金額マスタオブジェクト(集計レコード)メインDataSet展開処理
        /// </summary>
        /// <param name="custAccRecWork">得意先売掛金額マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先売掛金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private void CustAccRecWorkTotalToDataSet(CustAccRecWork custAccRecWork, ArrayList accRecDepoTotalWorkArrayList)
        {
            try
            {
                this._custAccRecTotalTable.BeginLoadData();
                // 更新対象行の取得
                object[] primryKey = new object[] { custAccRecWork.AddUpSecCode, 
                                                custAccRecWork.ClaimCode,
                                                custAccRecWork.CustomerCode, 
                                                TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate) };
                DataRow dr = this._custAccRecTotalTable.Rows.Find(primryKey);
                if (dr == null)
                {
                    // 新規に行を作成・追加
                    dr = this._custAccRecTotalTable.NewRow();
                    this._custAccRecTotalTable.Rows.Add(dr);
                }
                this.DataRowFromParamData(ref dr, custAccRecWork, accRecDepoTotalWorkArrayList);
            }
            finally
            {
                this._custAccRecTotalTable.EndLoadData();
            }
        }

        /// <summary>
        /// 売掛金額マスタワーク、売掛入金集計データワーク→DataRow移項処理
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="custAccRecWork"></param>
        /// <param name="accRecDepoTotalArrayList"></param>
        private void DataRowFromParamData(ref DataRow dr, CustAccRecWork custAccRecWork, ArrayList accRecDepoTotalArrayList)
        {
            // 削除日
            if (custAccRecWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custAccRecWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = custAccRecWork.AddUpSecCode;                                               // 計上拠点コード
            dr[COL_CUSTOMERCODE_TITLE] = custAccRecWork.CustomerCode;                                               // 得意先コード

            dr[COL_CUSTOMERNAME_TITLE] = custAccRecWork.CustomerName;                                               // 得意先名称
            dr[COL_CUSTOMERNAME2_TITLE] = custAccRecWork.CustomerName2;                                             // 得意先名称2
            dr[COL_CUSTOMERSNM_TITLE] = custAccRecWork.CustomerSnm;                                                 // 得意先略称
            dr[COL_CLAIMCODE_TITLE] = custAccRecWork.ClaimCode;                                                     // 請求先コード
            dr[COL_CLAIMNAME_TITLE] = custAccRecWork.ClaimName;                                                     // 請求先名称
            dr[COL_CLAIMNAME2_TITLE] = custAccRecWork.ClaimName2;                                                   // 請求先名称2
            dr[COL_CLAIMSNM_TITLE] = custAccRecWork.ClaimSnm;                                                       // 請求先略称
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", custAccRecWork.AddUpDate);         // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", custAccRecWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate);                       // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpYearMonth);             // _計上年月
            dr[COL_LASTTIMEACCREC_TITLE] = custAccRecWork.LastTimeAccRec;                                           // 前回売掛金額
            dr[COL_THISTIMEDMDNRML_TITLE] = custAccRecWork.ThisTimeDmdNrml;                                         // 今回入金金額（通常入金）
            dr[COL_THISTIMEFEEDMDNRML_TITLE] = custAccRecWork.ThisTimeFeeDmdNrml;                                   // 今回手数料額（通常入金）
            dr[COL_THISTIMEDISDMDNRML_TITLE] = custAccRecWork.ThisTimeDisDmdNrml;                                   // 今回値引額（通常入金）
            dr[COL_THISTIMEDEPODMD_TITLE] = custAccRecWork.ThisTimeDmdNrml;                                         // 今回入金金額（通常入金）

            dr[COL_THISTIMETTLBLCACC_TITLE] = custAccRecWork.ThisTimeTtlBlcAcc;                                     // 今回繰越残高（売掛計）
            dr[COL_THISTIMESALES_TITLE] = custAccRecWork.ThisTimeSales;                                             // 今回売上金額
            dr[COL_THISSALESTAX_TITLE] = custAccRecWork.ThisSalesTax;                                               // 今回売上消費税
            dr[COL_OFSTHISTIMESALES_TITLE] = custAccRecWork.OfsThisTimeSales;                                       // 相殺後今回売上金額
            dr[COL_OFSTHISSALESTAX_TITLE] = custAccRecWork.OfsThisSalesTax;                                         // 相殺後今回売上消費税
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = custAccRecWork.ItdedOffsetOutTax;                                     // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE] = custAccRecWork.ItdedOffsetInTax;                                       // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = custAccRecWork.ItdedOffsetTaxFree;                                   // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE] = custAccRecWork.OffsetOutTax;                                               // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE] = custAccRecWork.OffsetInTax;                                                 // 相殺後内税消費税
            dr[COL_ITDEDSALESOUTTAX_TITLE] = custAccRecWork.ItdedSalesOutTax;                                       // 売上外税対象額
            dr[COL_ITDEDSALESINTAX_TITLE] = custAccRecWork.ItdedSalesInTax;                                         // 売上内税対象額
            dr[COL_ITDEDSALESTAXFREE_TITLE] = custAccRecWork.ItdedSalesTaxFree;                                     // 売上非課税対象額
            dr[COL_SALESOUTTAX_TITLE] = custAccRecWork.SalesOutTax;                                                 // 売上外税額
            dr[COL_SALESINTAX_TITLE] = custAccRecWork.SalesInTax;                                                   // 売上内税額
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = custAccRecWork.TtlItdedRetOutTax;                                     // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE] = custAccRecWork.TtlItdedRetInTax;                                       // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = custAccRecWork.TtlItdedRetTaxFree;                                   // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE] = custAccRecWork.TtlRetOuterTax;                                           // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE] = custAccRecWork.TtlRetInnerTax;                                           // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = custAccRecWork.TtlItdedDisOutTax;                                     // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE] = custAccRecWork.TtlItdedDisInTax;                                       // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = custAccRecWork.TtlItdedDisTaxFree;                                   // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE] = custAccRecWork.TtlDisOuterTax;                                           // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE] = custAccRecWork.TtlDisInnerTax;                                           // 値引内税額
            dr[COL_BALANCEADJUST_TITLE] = custAccRecWork.BalanceAdjust;                                             // 残高調整額
            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust;

            // 調整額(表示のみ)
            dr[COL_TOTALADJUST_TITLE] = custAccRecWork.BalanceAdjust + custAccRecWork.TaxAdjust;

            dr[COL_BILLPRINTDATE_TITLE] = 0;                                                                        // （請求書発行日）
            dr[COL_EXPECTEDDEPOSITDATE_TITLE] = 0;                                                                  // （入金予定日）
            dr[COL_COLLECTCOND_TITLE] = 0;                                                                          // （回収条件）
            dr[COL_CONSTAXLAYMETHOD_TITLE] = custAccRecWork.ConsTaxLayMethod;                                       // 消費税転嫁方式
            dr[COL_CONSTAXRATE_TITLE] = custAccRecWork.ConsTaxRate;                                                 // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE] = custAccRecWork.FractionProcCd;                                           // 端数処理区分
            dr[COL_AFCALTMONTHACCREC_TITLE] = custAccRecWork.AfCalTMonthAccRec;                                     // 計算後当月売掛金額
            dr[COL_ACPODRTTL2TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl2TmBfAccRec;                               // 受注2回前残高（売掛計）
            dr[COL_ACPODRTTL3TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl3TmBfAccRec;                               // 受注3回前残高（売掛計）
            dr[COL_MONTHADDUPEXPDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.MonthAddUpExpDate);       // 月次更新実行年月日
            dr[COL_STMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.StMonCAddUpUpdDate);     // 月次更新開始年月日
            dr[COL_LAMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.LaMonCAddUpUpdDate);     // 前回月次更新年月日
            dr[COL_SALESSLIPCOUNT_TITLE] = custAccRecWork.SalesSlipCount;                                           // （伝票枚数）

            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust;                                                     // 消費税調整額

            dr[COL_GUID_TITLE] = custAccRecWork.FileHeaderGuid;                                                     // GUID
            dr[COL_CREATEDATETIME] = custAccRecWork.CreateDateTime;                                                 // 作成日時
            dr[COL_UPDATEDATETIME] = custAccRecWork.UpdateDateTime;                                                 // 更新日時



            List<AccRecDepoTotal> accRecDepoTotalList = new List<AccRecDepoTotal>();
            if (accRecDepoTotalArrayList != null)
            {
                foreach (AccRecDepoTotalWork accRecDepoTotalWork in accRecDepoTotalArrayList)
                {
                    accRecDepoTotalList.Add(UIDataFromParamData(accRecDepoTotalWork));
                }
            }
            dr[COL_DEPOTOTAL] = accRecDepoTotalList;
        }

        /// <summary>
        /// 得意先請求金額マスタオブジェクト(集計レコード)メインDataSet展開処理
        /// </summary>
        /// <param name="custDmdPrcWork">得意先請求金額マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタオブジェクトを、メインDataSetに格納します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void CustDmdPrcWorkTotalToDataSet(CustDmdPrcWork custDmdPrcWork, ArrayList dmdDepoTotalWorkArrayList)
        {

            try
            {
                this._custDmdPrcTotalTable.BeginLoadData();
                // 更新対象行の取得
                object[] primryKey = new object[] { custDmdPrcWork.AddUpSecCode,
                                                custDmdPrcWork.ClaimCode,
                                                custDmdPrcWork.CustomerCode, 
                                                custDmdPrcWork.ResultsSectCd, //実績拠点コード
                                                TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate) };
                DataRow dr = this._custDmdPrcTotalTable.Rows.Find(primryKey);


                if (dr == null)
                {
                    // 新規に行を作成・追加
                    dr = this._custDmdPrcTotalTable.NewRow();
                    this._custDmdPrcTotalTable.Rows.Add(dr);
                }

                this.DataRowFromParamData(ref dr, custDmdPrcWork, dmdDepoTotalWorkArrayList);
            }
            finally
            {
                this._custDmdPrcTotalTable.EndLoadData();
            }
        }

        /// <summary>
        /// 請求金額マスタワーク、請求入金集計データワーク→DataRow移項処理
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="custDmdPrcWork"></param>
        /// <param name="dmdDepoTotalArrayList"></param>
        private void DataRowFromParamData(ref DataRow dr, CustDmdPrcWork custDmdPrcWork, ArrayList dmdDepoTotalArrayList)
        {
            // 削除日
            if (custDmdPrcWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custDmdPrcWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = custDmdPrcWork.AddUpSecCode;                                               // 計上拠点コード

            dr[COL_RESULTSECCODE_TITLE] = custDmdPrcWork.ResultsSectCd;                                             // 実績拠点コード

            dr[COL_CUSTOMERCODE_TITLE] = custDmdPrcWork.CustomerCode;                                               // 得意先コード
            dr[COL_CUSTOMERNAME_TITLE] = custDmdPrcWork.CustomerName;                                               // 得意先名称
            dr[COL_CUSTOMERNAME2_TITLE] = custDmdPrcWork.CustomerName2;                                             // 得意先名称2
            dr[COL_CUSTOMERSNM_TITLE] = custDmdPrcWork.CustomerSnm;                                                 // 得意先略称
            dr[COL_CLAIMCODE_TITLE] = custDmdPrcWork.ClaimCode;                                                     // 得意先コード
            dr[COL_CLAIMNAME_TITLE] = custDmdPrcWork.ClaimName;                                                     // 得意先名称
            dr[COL_CLAIMNAME2_TITLE] = custDmdPrcWork.ClaimName2;                                                   // 得意先名称2
            dr[COL_CLAIMSNM_TITLE] = custDmdPrcWork.ClaimSnm;                                                       // 得意先略称
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", custDmdPrcWork.AddUpDate);         // 計上年月日
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", custDmdPrcWork.AddUpYearMonth);  // 計上年月
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate);                       // _計上年月日
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpYearMonth);             // _計上年月
            dr[COL_LASTTIMEDEMAND_TITLE] = custDmdPrcWork.LastTimeDemand;                                           // 前回請求金額
            dr[COL_THISTIMEDMDNRML_TITLE] = custDmdPrcWork.ThisTimeDmdNrml;                                         // 今回入金金額（通常入金）
            dr[COL_THISTIMEFEEDMDNRML_TITLE] = custDmdPrcWork.ThisTimeFeeDmdNrml;                                   // 今回手数料額（通常入金）
            dr[COL_THISTIMEDISDMDNRML_TITLE] = custDmdPrcWork.ThisTimeDisDmdNrml;                                   // 今回値引額（通常入金）
            dr[COL_THISTIMEDEPODMD_TITLE] = custDmdPrcWork.ThisTimeDmdNrml;                                         // 今回入金金額（通常入金）
            dr[COL_THISTIMETTLBLCDMD_TITLE] = custDmdPrcWork.ThisTimeTtlBlcDmd;                                     // 今回繰越残高（請求計）
            dr[COL_THISTIMESALES_TITLE] = custDmdPrcWork.ThisTimeSales;                                             // 今回売上金額
            dr[COL_THISSALESTAX_TITLE] = custDmdPrcWork.ThisSalesTax;                                               // 今回売上消費税
            dr[COL_OFSTHISTIMESALES_TITLE] = custDmdPrcWork.OfsThisTimeSales;                                       // 相殺後今回売上金額
            dr[COL_OFSTHISSALESTAX_TITLE] = custDmdPrcWork.OfsThisSalesTax;                                         // 相殺後今回売上消費税
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = custDmdPrcWork.ItdedOffsetOutTax;                                     // 相殺後外税対象額
            dr[COL_ITDEDOFFSETINTAX_TITLE] = custDmdPrcWork.ItdedOffsetInTax;                                       // 相殺後内税対象額
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = custDmdPrcWork.ItdedOffsetTaxFree;                                   // 相殺後非課税対象額
            dr[COL_OFFSETOUTTAX_TITLE] = custDmdPrcWork.OffsetOutTax;                                               // 相殺後外税消費税
            dr[COL_OFFSETINTAX_TITLE] = custDmdPrcWork.OffsetInTax;                                                 // 相殺後内税消費税
            dr[COL_ITDEDSALESOUTTAX_TITLE] = custDmdPrcWork.ItdedSalesOutTax;                                       // 売上外税対象額
            dr[COL_ITDEDSALESINTAX_TITLE] = custDmdPrcWork.ItdedSalesInTax;                                         // 売上内税対象額
            dr[COL_ITDEDSALESTAXFREE_TITLE] = custDmdPrcWork.ItdedSalesTaxFree;                                     // 売上非課税対象額
            dr[COL_SALESOUTTAX_TITLE] = custDmdPrcWork.SalesOutTax;                                                 // 売上外税額
            dr[COL_SALESINTAX_TITLE] = custDmdPrcWork.SalesInTax;                                                   // 売上内税額
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = custDmdPrcWork.TtlItdedRetOutTax;                                     // 返品外税対象額
            dr[COL_TTLITDEDRETINTAX_TITLE] = custDmdPrcWork.TtlItdedRetInTax;                                       // 返品内税対象額
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = custDmdPrcWork.TtlItdedRetTaxFree;                                   // 返品非課税対象額
            dr[COL_TTLRETOUTERTAX_TITLE] = custDmdPrcWork.TtlRetOuterTax;                                           // 返品外税額
            dr[COL_TTLRETINNERTAX_TITLE] = custDmdPrcWork.TtlRetInnerTax;                                           // 返品内税額
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = custDmdPrcWork.TtlItdedDisOutTax;                                     // 値引外税対象額
            dr[COL_TTLITDEDDISINTAX_TITLE] = custDmdPrcWork.TtlItdedDisInTax;                                       // 値引内税対象額
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = custDmdPrcWork.TtlItdedDisTaxFree;                                   // 値引非課税対象額
            dr[COL_TTLDISOUTERTAX_TITLE] = custDmdPrcWork.TtlDisOuterTax;                                           // 値引外税額
            dr[COL_TTLDISINNERTAX_TITLE] = custDmdPrcWork.TtlDisInnerTax;                                           // 値引内税額

            dr[COL_BALANCEADJUST_TITLE] = custDmdPrcWork.BalanceAdjust;                                             // 残高調整額
            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust;
            // 調整額(標示用のみ)
            dr[COL_TOTALADJUST_TITLE] = custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;
            dr[COL_NONSTMNTAPPEARANCE_TITLE] = 0;                                                                   // 未決済金額（自振）
            dr[COL_NONSTMNTISDONE_TITLE] = 0;                                                                       // 未決済金額（廻し） 
            dr[COL_STMNTAPPEARANCE_TITLE] = 0;                                                                      // 決済金額（自振）
            dr[COL_STMNTISDONE_TITLE] = 0;                                                                          // 決済金額（廻し）

            dr[COL_SALESSLIPCOUNT_TITLE] = custDmdPrcWork.SalesSlipCount;                                           // 伝票枚数
            dr[COL_BILLPRINTDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.BillPrintDate);                                          // 請求書発行日
            dr[COL_EXPECTEDDEPOSITDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.ExpectedDepositDate);   // 入金予定日
            dr[COL_COLLECTCOND_TITLE] = custDmdPrcWork.CollectCond;                                                 // 回収条件
            dr[COL_CONSTAXLAYMETHOD_TITLE] = custDmdPrcWork.ConsTaxLayMethod;                                       // 消費税転嫁方式
            dr[COL_CONSTAXRATE_TITLE] = custDmdPrcWork.ConsTaxRate;                                                 // 消費税率
            dr[COL_FRACTIONPROCCD_TITLE] = custDmdPrcWork.FractionProcCd;                                           // 端数処理区分
            dr[COL_AFCALDEMANDPRICE_TITLE] = custDmdPrcWork.AfCalDemandPrice;                                       // 計算後請求金額
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE] = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;                                 // 受注2回前残高（請求計）
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE] = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;                                 // 受注3回前残高（請求計）
            dr[COL_CADDUPUPDEXECDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.CAddUpUpdExecDate);       // 締次更新実行年月日
            dr[COL_STARTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.StartCAddUpUpdDate);     // 締次更新開始年月日
            dr[COL_LASTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.LastCAddUpUpdDate);       // 前回締次更新年月日

            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust;                                                     // 消費税調整額
            dr[COL_GUID_TITLE] = custDmdPrcWork.FileHeaderGuid;                                                     // GUID
            dr[COL_CREATEDATETIME] = custDmdPrcWork.CreateDateTime;                                                 // 作成日時
            dr[COL_UPDATEDATETIME] = custDmdPrcWork.UpdateDateTime;                                                 // 更新日時

            List<DmdDepoTotal> dmdDepoTotalList = new List<DmdDepoTotal>();
            if ( dmdDepoTotalArrayList != null )
            {
                foreach (DmdDepoTotalWork dmdDepoTotalWork in dmdDepoTotalArrayList)
                {
                    dmdDepoTotalList.Add(UIDataFromParamData(dmdDepoTotalWork));
                }
            }
            dr[COL_DEPOTOTAL] = dmdDepoTotalList;

            // ADD 2009/06/23 ------>>>
            dr[COL_BILLNO_TITLE] = custDmdPrcWork.BillNo;                                                           // 請求書No
            // ADD 2009/06/23 ------<<<
            
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="accRecDepoTotalWork">売掛入金集計データワーク</param>
        /// <returns>売掛入金集計データ</returns>
        private static AccRecDepoTotal UIDataFromParamData(AccRecDepoTotalWork accRecDepoTotalWork)
        {
            AccRecDepoTotal accRecDepoTotal = new AccRecDepoTotal();

            accRecDepoTotal.CreateDateTime = accRecDepoTotalWork.CreateDateTime;        // 作成日時
            accRecDepoTotal.UpdateDateTime = accRecDepoTotalWork.UpdateDateTime;        // 更新日時
            accRecDepoTotal.EnterpriseCode = accRecDepoTotalWork.EnterpriseCode;        // 企業コード
            accRecDepoTotal.FileHeaderGuid = accRecDepoTotalWork.FileHeaderGuid;        // GUID
            accRecDepoTotal.UpdEmployeeCode = accRecDepoTotalWork.UpdEmployeeCode;      // 更新従業員コード
            accRecDepoTotal.UpdAssemblyId1 = accRecDepoTotalWork.UpdAssemblyId1;        // 更新アセンブリID1
            accRecDepoTotal.UpdAssemblyId2 = accRecDepoTotalWork.UpdAssemblyId2;        // 更新アセンブリID2
            accRecDepoTotal.LogicalDeleteCode = accRecDepoTotalWork.LogicalDeleteCode;  // 論理削除区分
            accRecDepoTotal.AddUpSecCode = accRecDepoTotalWork.AddUpSecCode;            // 計上拠点コード
            accRecDepoTotal.ClaimCode = accRecDepoTotalWork.ClaimCode;                  // 請求先コード
            accRecDepoTotal.CustomerCode = accRecDepoTotalWork.CustomerCode;            // 得意先コード
            accRecDepoTotal.AddUpDate = accRecDepoTotalWork.AddUpDate;                  // 計上年月日
            accRecDepoTotal.MoneyKindCode = accRecDepoTotalWork.MoneyKindCode;          // 金種コード
            accRecDepoTotal.MoneyKindName = accRecDepoTotalWork.MoneyKindName;          // 金種名称
            accRecDepoTotal.MoneyKindDiv = accRecDepoTotalWork.MoneyKindDiv;            // 金種区分
            accRecDepoTotal.Deposit = accRecDepoTotalWork.Deposit;                      // 入金金額

            return accRecDepoTotal;
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="accRecDepoTotal">売掛入金集計データ</param>
        /// <returns>売掛入金集計データワーク</returns>
        private static AccRecDepoTotalWork ParamDataFromUIData(AccRecDepoTotal accRecDepoTotal)
        {
            AccRecDepoTotalWork accRecDepoTotalWork = new AccRecDepoTotalWork();

            accRecDepoTotalWork.CreateDateTime = accRecDepoTotal.CreateDateTime;        // 作成日時
            accRecDepoTotalWork.UpdateDateTime = accRecDepoTotal.UpdateDateTime;        // 更新日時
            accRecDepoTotalWork.EnterpriseCode = accRecDepoTotal.EnterpriseCode;        // 企業コード
            accRecDepoTotalWork.FileHeaderGuid = accRecDepoTotal.FileHeaderGuid;        // GUID
            accRecDepoTotalWork.UpdEmployeeCode = accRecDepoTotal.UpdEmployeeCode;      // 更新従業員コード
            accRecDepoTotalWork.UpdAssemblyId1 = accRecDepoTotal.UpdAssemblyId1;        // 更新アセンブリID1
            accRecDepoTotalWork.UpdAssemblyId2 = accRecDepoTotal.UpdAssemblyId2;        // 更新アセンブリID2
            accRecDepoTotalWork.LogicalDeleteCode = accRecDepoTotal.LogicalDeleteCode;  // 論理削除区分
            accRecDepoTotalWork.AddUpSecCode = accRecDepoTotal.AddUpSecCode;            // 計上拠点コード
            accRecDepoTotalWork.ClaimCode = accRecDepoTotal.ClaimCode;                  // 請求先コード
            accRecDepoTotalWork.CustomerCode = accRecDepoTotal.CustomerCode;            // 得意先コード
            accRecDepoTotalWork.AddUpDate = accRecDepoTotal.AddUpDate;                  // 計上年月日
            accRecDepoTotalWork.MoneyKindCode = accRecDepoTotal.MoneyKindCode;          // 金種コード
            accRecDepoTotalWork.MoneyKindName = accRecDepoTotal.MoneyKindName;          // 金種名称
            accRecDepoTotalWork.MoneyKindDiv = accRecDepoTotal.MoneyKindDiv;            // 金種区分
            accRecDepoTotalWork.Deposit = accRecDepoTotal.Deposit;                      // 入金金額

            return accRecDepoTotalWork;
        }

        /// <summary>
        /// PramData→UIData移項処理
        /// </summary>
        /// <param name="dmdDepoTotalWork">請求入金集計データワーク</param>
        /// <returns>請求入金集計データ</returns>
        private static DmdDepoTotal UIDataFromParamData(DmdDepoTotalWork dmdDepoTotalWork)
        {
            DmdDepoTotal dmdDepoTotal = new DmdDepoTotal();

            dmdDepoTotal.CreateDateTime = dmdDepoTotalWork.CreateDateTime;          // 作成日時
            dmdDepoTotal.UpdateDateTime = dmdDepoTotalWork.UpdateDateTime;          // 更新日時
            dmdDepoTotal.EnterpriseCode = dmdDepoTotalWork.EnterpriseCode;          // 企業コード
            dmdDepoTotal.FileHeaderGuid = dmdDepoTotalWork.FileHeaderGuid;          // GUID
            dmdDepoTotal.UpdEmployeeCode = dmdDepoTotalWork.UpdEmployeeCode;        // 更新従業員コード
            dmdDepoTotal.UpdAssemblyId1 = dmdDepoTotalWork.UpdAssemblyId1;          // 更新アセンブリID1
            dmdDepoTotal.UpdAssemblyId2 = dmdDepoTotalWork.UpdAssemblyId2;          // 更新アセンブリID2
            dmdDepoTotal.LogicalDeleteCode = dmdDepoTotalWork.LogicalDeleteCode;    // 論理削除区分
            dmdDepoTotal.AddUpSecCode = dmdDepoTotalWork.AddUpSecCode;              // 計上拠点コード
            dmdDepoTotal.ClaimCode = dmdDepoTotalWork.ClaimCode;                    // 請求先コード
            dmdDepoTotal.CustomerCode = dmdDepoTotalWork.CustomerCode;              // 得意先コード
            dmdDepoTotal.AddUpDate = dmdDepoTotalWork.AddUpDate;                    // 計上年月日
            dmdDepoTotal.MoneyKindCode = dmdDepoTotalWork.MoneyKindCode;            // 金種コード
            dmdDepoTotal.MoneyKindName = dmdDepoTotalWork.MoneyKindName;            // 金種名称
            dmdDepoTotal.MoneyKindDiv = dmdDepoTotalWork.MoneyKindDiv;              // 金種区分
            dmdDepoTotal.Deposit = dmdDepoTotalWork.Deposit;                        // 入金金額

            return dmdDepoTotal;
        }

        /// <summary>
        /// UIData→PramData移項処理
        /// </summary>
        /// <param name="source">請求入金集計データ</param>
        /// <returns>請求入金集計データワーク</returns>
        private static DmdDepoTotalWork ParamDataFromUIData(DmdDepoTotal dmdDepoTotal)
        {
            DmdDepoTotalWork dmdDepoTotalWork = new DmdDepoTotalWork();

            dmdDepoTotalWork.CreateDateTime = dmdDepoTotal.CreateDateTime;          // 作成日時
            dmdDepoTotalWork.UpdateDateTime = dmdDepoTotal.UpdateDateTime;          // 更新日時
            dmdDepoTotalWork.EnterpriseCode = dmdDepoTotal.EnterpriseCode;          // 企業コード
            dmdDepoTotalWork.FileHeaderGuid = dmdDepoTotal.FileHeaderGuid;          // GUID
            dmdDepoTotalWork.UpdEmployeeCode = dmdDepoTotal.UpdEmployeeCode;        // 更新従業員コード
            dmdDepoTotalWork.UpdAssemblyId1 = dmdDepoTotal.UpdAssemblyId1;          // 更新アセンブリID1
            dmdDepoTotalWork.UpdAssemblyId2 = dmdDepoTotal.UpdAssemblyId2;          // 更新アセンブリID2
            dmdDepoTotalWork.LogicalDeleteCode = dmdDepoTotal.LogicalDeleteCode;    // 論理削除区分
            dmdDepoTotalWork.AddUpSecCode = dmdDepoTotal.AddUpSecCode;              // 計上拠点コード
            dmdDepoTotalWork.ClaimCode = dmdDepoTotal.ClaimCode;                    // 請求先コード
            dmdDepoTotalWork.CustomerCode = dmdDepoTotal.CustomerCode;              // 得意先コード
            dmdDepoTotalWork.AddUpDate = dmdDepoTotal.AddUpDate;                    // 計上年月日
            dmdDepoTotalWork.MoneyKindCode = dmdDepoTotal.MoneyKindCode;            // 金種コード
            dmdDepoTotalWork.MoneyKindName = dmdDepoTotal.MoneyKindName;            // 金種名称
            dmdDepoTotalWork.MoneyKindDiv = dmdDepoTotal.MoneyKindDiv;              // 金種区分
            dmdDepoTotalWork.Deposit = dmdDepoTotal.Deposit;                        // 入金金額

            return dmdDepoTotalWork;
        }
        // 2009.01.06 Add <<<

        #endregion

        // 2009.01.06 Add >>>
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
        // 2009.01.06 Add <<<


        // --------------------------------------------------
		#region 比較用クラス

        /// <summary>得意先売掛金額マスタ比較クラス</summary>
        /// <remarks>
        /// <br>Note       : 得意先売掛金額マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class CustAccRecCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>比較用メソッド</summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 得意先売掛金額マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 30154 安藤 昌仁</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustAccRec obj1 = x as CustAccRec;
                CustAccRec obj2 = y as CustAccRec;

                // キー情報で比較する
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.CustomerCode + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.CustomerCode + "_" + obj2.AddUpDate;
                // 得意先売掛金額出力マスタのキーで比較
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        /// <summary>得意先請求金額マスタ比較クラス</summary>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタオブジェクトの比較を行います。</br>
        /// <br>Programmer : 30154 安藤 昌仁</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class CustDmdPrcCompare : IComparer
        {
            #region IComparer メンバ

            /// <summary>比較用メソッド</summary>
            /// <param name="x">比較対象オブジェクト</param>
            /// <param name="y">比較対象オブジェクト</param>
            /// <returns>比較結果(x ＞ y : 0より大きい整数, x ＜ y : 0より小さい整数, x ＝ y : 0)</returns>
            /// <remarks>
            /// <br>Note       : 得意先請求金額マスタオブジェクトの比較を行います。</br>
            /// <br>Programmer : 30154 安藤 昌仁</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustDmdPrc obj1 = x as CustDmdPrc;
                CustDmdPrc obj2 = y as CustDmdPrc;

                // キー情報で比較する
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.CustomerCode + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.CustomerCode + "_" + obj2.AddUpDate;
                // 得意先請求金額出力マスタのキーで比較
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        #endregion

    }
}
