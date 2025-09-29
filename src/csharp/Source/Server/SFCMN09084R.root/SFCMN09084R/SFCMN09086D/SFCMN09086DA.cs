using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   AllDefSetWork
	/// <summary>
	///                      全体初期値設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   全体初期値設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/10</br>
	/// <br>Genarated Date   :   2008/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      : 2011/07/19 zhouyu</br>
    /// <br>                 : 連番 1028</br>
    /// <br>                  修正内容：連番 1028 在庫仕入入力で、品番入力後に自動で 仕入数=１ と表示され、現在庫数が足されて表示になり分かりずらい</br>
    /// <br>                  PM7では、仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>                  売上伝票入力，仕入伝票入力 も同じ</br>
    /// <br>Update Note      : 2013/05/02 王君</br>
    /// <br>管理番号         : 10901273-00 2013/06/18配信分</br>
    /// <br>                 : Redmine#35434の対応</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class AllDefSetWork : IFileHeader
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>総額表示方法区分</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>初期表示顧客締日</summary>
		/// <remarks>0～31</remarks>
		private Int32 _defDspCustTtlDay;

		/// <summary>初期表示顧客集金日</summary>
		/// <remarks>0～31</remarks>
		private Int32 _defDspCustClctMnyDay;

		/// <summary>初期表示集金月区分</summary>
		/// <remarks>0:当月,1:翌月,2:翌々月</remarks>
		private Int32 _defDspClctMnyMonthCd;

		/// <summary>初期表示個人・法人区分</summary>
		/// <remarks>0:個人,1:法人</remarks>
		private Int32 _iniDspPrslOrCorpCd;

		/// <summary>初期表示DM区分</summary>
		/// <remarks>0:ＤＭ出力する,1:ＤＭ出力しない</remarks>
		private Int32 _initDspDmDiv;

		/// <summary>初期表示請求書出力区分</summary>
		/// <remarks>0:請求書出力する,1:請求書出力しない</remarks>
		private Int32 _defDspBillPrtDivCd;

		/// <summary>元号表示区分１</summary>
		/// <remarks>0:西暦　1:和暦（年式）</remarks>
		private Int32 _eraNameDispCd1;

		/// <summary>元号表示区分２</summary>
		/// <remarks>0:西暦　1:和暦（通常）　　</remarks>
		private Int32 _eraNameDispCd2;

		/// <summary>元号表示区分３</summary>
		/// <remarks>0:西暦　1:和暦（その他）</remarks>
		private Int32 _eraNameDispCd3;

		/// <summary>商品番号入力区分</summary>
		/// <remarks>0:任意　1:必須</remarks>
		private Int32 _goodsNoInpDiv;




		/// <summary>消費税自動補正区分</summary>
		/// <remarks>0:自動　1:手動</remarks>
		private Int32 _cnsTaxAutoCorrDiv;

		/// <summary>残数管理区分</summary>
		/// <remarks>0:する　1:しない 　　※伝票削除時に残に戻すかどうか </remarks>
		private Int32 _remainCntMngDiv;

		/// <summary>メモ複写区分</summary>
		/// <remarks>0:する　1:社外メモのみ　2:しない</remarks>
		private Int32 _memoMoveDiv;

		/// <summary>残数自動表示区分</summary>
		/// <remarks>0:しない,1:出荷残,入荷残のみ，2:受発注残のみ，3:出荷残,入荷残 ->受発注残 4:受発注残 -> 出荷残,入荷残</remarks>
		private Int32 _remCntAutoDspDiv;

		/// <summary>総額表示掛率適用区分</summary>
		/// <remarks>0：税込単価, 1:税抜単価</remarks>
		private Int32 _ttlAmntDspRateDivCd;

        // --- ADD  大矢睦美  2010/01/15 ---------->>>>>
        /// <summary>初期表示合計請求書出力区分</summary>
        /// <remarks>0:出力する　1:出力しない</remarks>
        private Int32 _defTtlBillOutput;

        /// <summary>初期表示明細請求書出力区分</summary>
        /// <remarks>0:出力する　1:出力しない</remarks>
        private Int32 _defDtlBillOutput;

        /// <summary>初期表示伝票合計請求書出力区分</summary>
        /// <remarks>0:出力する　1:出力しない</remarks>
        private Int32 _defSlTtlBillOutput;
        // --- ADD  大矢睦美  2010/01/15 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>明細算出後在庫数表示区分</summary>
        /// <remarks>0:検索後反映 1:行移動時反映</remarks>
        private Int32 _dtlCalcStckCntDsp;
        //ADD 2011/07/19

        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>商品在庫起動区分</summary>
        /// <remarks>0:商品在庫マスタⅠ　1:商品在庫マスタⅡ</remarks>
        private Int32 _goodsStockMstBootDiv;
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>総額表示方法区分プロパティ</summary>
		/// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示方法区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalAmountDispWayCd
		{
			get{return _totalAmountDispWayCd;}
			set{_totalAmountDispWayCd = value;}
		}

		/// public propaty name  :  DefDspCustTtlDay
		/// <summary>初期表示顧客締日プロパティ</summary>
		/// <value>0～31</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期表示顧客締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DefDspCustTtlDay
		{
			get{return _defDspCustTtlDay;}
			set{_defDspCustTtlDay = value;}
		}

		/// public propaty name  :  DefDspCustClctMnyDay
		/// <summary>初期表示顧客集金日プロパティ</summary>
		/// <value>0～31</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期表示顧客集金日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DefDspCustClctMnyDay
		{
			get{return _defDspCustClctMnyDay;}
			set{_defDspCustClctMnyDay = value;}
		}

		/// public propaty name  :  DefDspClctMnyMonthCd
		/// <summary>初期表示集金月区分プロパティ</summary>
		/// <value>0:当月,1:翌月,2:翌々月</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期表示集金月区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DefDspClctMnyMonthCd
		{
			get{return _defDspClctMnyMonthCd;}
			set{_defDspClctMnyMonthCd = value;}
		}

		/// public propaty name  :  IniDspPrslOrCorpCd
		/// <summary>初期表示個人・法人区分プロパティ</summary>
		/// <value>0:個人,1:法人</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期表示個人・法人区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 IniDspPrslOrCorpCd
		{
			get{return _iniDspPrslOrCorpCd;}
			set{_iniDspPrslOrCorpCd = value;}
		}

		/// public propaty name  :  InitDspDmDiv
		/// <summary>初期表示DM区分プロパティ</summary>
		/// <value>0:ＤＭ出力する,1:ＤＭ出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期表示DM区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InitDspDmDiv
		{
			get{return _initDspDmDiv;}
			set{_initDspDmDiv = value;}
		}

		/// public propaty name  :  DefDspBillPrtDivCd
		/// <summary>初期表示請求書出力区分プロパティ</summary>
		/// <value>0:請求書出力する,1:請求書出力しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   初期表示請求書出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DefDspBillPrtDivCd
		{
			get{return _defDspBillPrtDivCd;}
			set{_defDspBillPrtDivCd = value;}
		}

		/// public propaty name  :  EraNameDispCd1
		/// <summary>元号表示区分１プロパティ</summary>
		/// <value>0:西暦　1:和暦（年式）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   元号表示区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EraNameDispCd1
		{
			get{return _eraNameDispCd1;}
			set{_eraNameDispCd1 = value;}
		}

		/// public propaty name  :  EraNameDispCd2
		/// <summary>元号表示区分２プロパティ</summary>
		/// <value>0:西暦　1:和暦（通常）　　</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   元号表示区分２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EraNameDispCd2
		{
			get{return _eraNameDispCd2;}
			set{_eraNameDispCd2 = value;}
		}

		/// public propaty name  :  EraNameDispCd3
		/// <summary>元号表示区分３プロパティ</summary>
		/// <value>0:西暦　1:和暦（その他）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   元号表示区分３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EraNameDispCd3
		{
			get{return _eraNameDispCd3;}
			set{_eraNameDispCd3 = value;}
		}

		/// public propaty name  :  GoodsNoInpDiv
		/// <summary>商品番号入力区分プロパティ</summary>
		/// <value>0:任意　1:必須</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号入力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNoInpDiv
		{
			get{return _goodsNoInpDiv;}
			set{_goodsNoInpDiv = value;}
		}


		/// public propaty name  :  CnsTaxAutoCorrDiv
		/// <summary>消費税自動補正区分プロパティ</summary>
		/// <value>0:自動　1:手動</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税自動補正区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CnsTaxAutoCorrDiv
		{
			get{return _cnsTaxAutoCorrDiv;}
			set{_cnsTaxAutoCorrDiv = value;}
		}

		/// public propaty name  :  RemainCntMngDiv
		/// <summary>残数管理区分プロパティ</summary>
		/// <value>0:する　1:しない 　　※伝票削除時に残に戻すかどうか </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数管理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RemainCntMngDiv
		{
			get{return _remainCntMngDiv;}
			set{_remainCntMngDiv = value;}
		}

		/// public propaty name  :  MemoMoveDiv
		/// <summary>メモ複写区分プロパティ</summary>
		/// <value>0:する　1:社外メモのみ　2:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メモ複写区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MemoMoveDiv
		{
			get{return _memoMoveDiv;}
			set{_memoMoveDiv = value;}
		}

		/// public propaty name  :  RemCntAutoDspDiv
		/// <summary>残数自動表示区分プロパティ</summary>
		/// <value>0:しない,1:出荷残,入荷残のみ，2:受発注残のみ，3:出荷残,入荷残 ->受発注残 4:受発注残 -> 出荷残,入荷残</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数自動表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RemCntAutoDspDiv
		{
			get{return _remCntAutoDspDiv;}
			set{_remCntAutoDspDiv = value;}
		}

		/// public propaty name  :  TtlAmntDspRateDivCd
		/// <summary>総額表示掛率適用区分プロパティ</summary>
		/// <value>0：税込単価, 1:税抜単価</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示掛率適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlAmntDspRateDivCd
		{
			get{return _ttlAmntDspRateDivCd;}
			set{_ttlAmntDspRateDivCd = value;}
		}

        // --- ADD  大矢睦美  2010/01/15 ---------->>>>>
        /// public propaty name  :  DefTtlBillOutput
        /// <summary>初期表示合計請求書出力区分プロパティ</summary>
        /// <value>0:出力する　1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefTtlBillOutput
        {
            get { return _defTtlBillOutput; }
            set { _defTtlBillOutput = value; }
        }

        /// public propaty name  :  DefDtlBillOutput
        /// <summary>初期表示明細請求書出力区分プロパティ</summary>
        /// <value>0:出力する　1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefDtlBillOutput
        {
            get { return _defDtlBillOutput; }
            set { _defDtlBillOutput = value; }
        }

        /// public propaty name  :  DefSlTtlBillOutput
        /// <summary>初期表示伝票合計請求書出力区分プロパティ</summary>
        /// <value>0:出力する　1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示伝票合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefSlTtlBillOutput
        {
            get { return _defSlTtlBillOutput; }
            set { _defSlTtlBillOutput = value; }
        }
        // --- ADD  大矢睦美  2010/01/15 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>明細算出後在庫数表示区分プロパティ</summary>
        /// <value>0:検索後反映 1:行移動時反映</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細算出後在庫数表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlCalcStckCntDsp
        {
            get { return _dtlCalcStckCntDsp; }
            set { _dtlCalcStckCntDsp = value; }
        }
        //ADD 2011/07/19

        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>商品在庫起動区分</summary>
        /// <value>0:商品在庫マスタⅠ 1:商品在庫マスタⅡ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品在庫表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsStockMstBootDiv
        {
            get { return _goodsStockMstBootDiv; }
            set { _goodsStockMstBootDiv = value; }
        }
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

		/// <summary>
		/// 全体初期値設定ワークコンストラクタ
		/// </summary>
		/// <returns>AllDefSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AllDefSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AllDefSetWork()
		{
		}

	}
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AllDefSetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AllDefSetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AllDefSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 　2013/05/02 王君</br>
        /// <br>管理番号         :   10901273-00 2013/06/18配信分</br>
        /// <br>                 : 　Redmine#35434の対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AllDefSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AllDefSetWork || graph is ArrayList || graph is AllDefSetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AllDefSetWork).FullName));

            if (graph != null && graph is AllDefSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AllDefSetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AllDefSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AllDefSetWork[])graph).Length;
            }
            else if (graph is AllDefSetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //初期表示顧客締日
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspCustTtlDay
            //初期表示顧客集金日
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspCustClctMnyDay
            //初期表示集金月区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspClctMnyMonthCd
            //初期表示個人・法人区分
            serInfo.MemberInfo.Add(typeof(Int32)); //IniDspPrslOrCorpCd
            //初期表示DM区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InitDspDmDiv
            //初期表示請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDspBillPrtDivCd
            //元号表示区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd1
            //元号表示区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd2
            //元号表示区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //EraNameDispCd3
            //商品番号入力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoInpDiv
            //消費税自動補正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CnsTaxAutoCorrDiv
            //残数管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntMngDiv
            //メモ複写区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MemoMoveDiv
            //残数自動表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RemCntAutoDspDiv
            //総額表示掛率適用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TtlAmntDspRateDivCd
            // --- ADD  大矢睦美  2010/01/15 ---------->>>>>
            //初期表示合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DefTtlBillOutput
            //初期表示明細請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DefDtlBillOutput
            //初期表示伝票合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DefSlTtlBillOutput
            // --- ADD  大矢睦美  2010/01/15 ----------<<<<<
            //ADD 2011/07/19
            //明細算出後在庫数表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlCalcStckCntDsp
            //ADD 2011/07/19
            serInfo.MemberInfo.Add(typeof(Int32));//GoodsStockMstBootDiv // ADD 王君 2013/05/02 Redmine#35434


            serInfo.Serialize(writer, serInfo);
            if (graph is AllDefSetWork)
            {
                AllDefSetWork temp = (AllDefSetWork)graph;

                SetAllDefSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AllDefSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AllDefSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AllDefSetWork temp in lst)
                {
                    SetAllDefSetWork(writer, temp);
                }

            }
        }


        /// <summary>
        /// AllDefSetWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 29; // DEL 王君 2013/05/02 Redmine#35434
        private const int currentMemberCount = 30;// ADD 王君 2013/05/02 Redmine#35434

        /// <summary>
        ///  AllDefSetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 　2013/05/02 王君</br>
        /// <br>管理番号         :   10901273-00 2013/06/18配信分</br>
        /// <br>                 : 　Redmine#35434の対応</br>
        /// </remarks>
        private void SetAllDefSetWork(System.IO.BinaryWriter writer, AllDefSetWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //総額表示方法区分
            writer.Write(temp.TotalAmountDispWayCd);
            //初期表示顧客締日
            writer.Write(temp.DefDspCustTtlDay);
            //初期表示顧客集金日
            writer.Write(temp.DefDspCustClctMnyDay);
            //初期表示集金月区分
            writer.Write(temp.DefDspClctMnyMonthCd);
            //初期表示個人・法人区分
            writer.Write(temp.IniDspPrslOrCorpCd);
            //初期表示DM区分
            writer.Write(temp.InitDspDmDiv);
            //初期表示請求書出力区分
            writer.Write(temp.DefDspBillPrtDivCd);
            //元号表示区分１
            writer.Write(temp.EraNameDispCd1);
            //元号表示区分２
            writer.Write(temp.EraNameDispCd2);
            //元号表示区分３
            writer.Write(temp.EraNameDispCd3);
            //商品番号入力区分
            writer.Write(temp.GoodsNoInpDiv);
            //消費税自動補正区分
            writer.Write(temp.CnsTaxAutoCorrDiv);
            //残数管理区分
            writer.Write(temp.RemainCntMngDiv);
            //メモ複写区分
            writer.Write(temp.MemoMoveDiv);
            //残数自動表示区分
            writer.Write(temp.RemCntAutoDspDiv);
            //総額表示掛率適用区分
            writer.Write(temp.TtlAmntDspRateDivCd);
            // --- ADD  大矢睦美  2010/01/15 ---------->>>>>
            //初期表示合計請求書出力区分
            writer.Write(temp.DefTtlBillOutput);
            //初期表示明細請求書出力区分
            writer.Write(temp.DefDtlBillOutput);
            //初期表示伝票合計請求書出力区分
            writer.Write(temp.DefSlTtlBillOutput);
            // --- ADD  大矢睦美  2010/01/15 ----------<<<<<
            //ADD 2011/07/19
            //明細算出後在庫数表示区分
            writer.Write(temp.DtlCalcStckCntDsp);
            //ADD 2011/07/19
            writer.Write(temp.GoodsStockMstBootDiv); // ADD 王君 2013/05/02 Redmine#35434

        }

        /// <summary>
        ///  AllDefSetWorkインスタンス取得
        /// </summary>
        /// <returns>AllDefSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 　2013/05/02 王君</br>
        /// <br>管理番号         :   10901273-00 2013/06/18配信分</br>
        /// <br>                 : 　Redmine#35434の対応</br>
        /// </remarks>
        private AllDefSetWork GetAllDefSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AllDefSetWork temp = new AllDefSetWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //総額表示方法区分
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //初期表示顧客締日
            temp.DefDspCustTtlDay = reader.ReadInt32();
            //初期表示顧客集金日
            temp.DefDspCustClctMnyDay = reader.ReadInt32();
            //初期表示集金月区分
            temp.DefDspClctMnyMonthCd = reader.ReadInt32();
            //初期表示個人・法人区分
            temp.IniDspPrslOrCorpCd = reader.ReadInt32();
            //初期表示DM区分
            temp.InitDspDmDiv = reader.ReadInt32();
            //初期表示請求書出力区分
            temp.DefDspBillPrtDivCd = reader.ReadInt32();
            //元号表示区分１
            temp.EraNameDispCd1 = reader.ReadInt32();
            //元号表示区分２
            temp.EraNameDispCd2 = reader.ReadInt32();
            //元号表示区分３
            temp.EraNameDispCd3 = reader.ReadInt32();
            //商品番号入力区分
            temp.GoodsNoInpDiv = reader.ReadInt32();
            //消費税自動補正区分
            temp.CnsTaxAutoCorrDiv = reader.ReadInt32();
            //残数管理区分
            temp.RemainCntMngDiv = reader.ReadInt32();
            //メモ複写区分
            temp.MemoMoveDiv = reader.ReadInt32();
            //残数自動表示区分
            temp.RemCntAutoDspDiv = reader.ReadInt32();
            //総額表示掛率適用区分
            temp.TtlAmntDspRateDivCd = reader.ReadInt32();
            // --- ADD  大矢睦美  2010/01/15 ---------->>>>>
            //初期表示合計請求書出力区分
            temp.DefTtlBillOutput = reader.ReadInt32();
            //初期表示明細請求書出力区分
            temp.DefDtlBillOutput = reader.ReadInt32();
            //初期表示伝票合計請求書出力区分
            temp.DefSlTtlBillOutput = reader.ReadInt32();
            // --- ADD  大矢睦美  2010/01/15 ----------<<<<<
            //ADD 2011/07/19
            //明細算出後在庫数表示区分
            temp.DtlCalcStckCntDsp = reader.ReadInt32();
            //ADD 2011/07/19
            temp.GoodsStockMstBootDiv = reader.ReadInt32(); // ADD 王君 2013/05/02 Redmine#35434


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>AllDefSetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AllDefSetWork temp = GetAllDefSetWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (AllDefSetWork[])lst.ToArray(typeof(AllDefSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
