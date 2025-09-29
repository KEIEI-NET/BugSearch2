using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesTtlStWork
	/// <summary>
	///                      売上全体設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上全体設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/28</br>
	/// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br></br>
    /// <br>Update Note     :    2009/10/19 朱俊成</br>
    /// <br>                     PM.NS-3-A・保守依頼②</br>
    /// <br>                     表示区分プロセスを追加</br>
    /// <br>Update Note     :    2010/01/29 李侠</br>
    /// <br>                     PM1003・四次改良</br>
    /// <br>                     受注数入力を追加</br>
    /// <br>Update Note     :    2010/04/30 姜凱</br>
    /// <br>                     PM1007D・自由検索</br>
    /// <br>                     自由検索部品自動登録区分を追加</br>    
    /// <br>Update Note     :    2010/05/04 王海立</br>
    /// <br>                     PM1007・6次改良</br>
    /// <br>                     発行者チェック区分、入力倉庫チェック区分を追加</br>
    /// <br>Update Note     :    2010/05/14 21024 佐々木 健</br>
    /// <br>                     ・６次改良</br>
    /// <br>                     　BLコード検索品名表示区分１～４、品番検索品名表示区分１～４、優良部品検索品名使用区分を追加</br>   
    /// <br>Update Note     :    2010/08/04 楊明俊</br>
    /// <br>                     PM1012</br>
    /// <br>                     小数点表示区分を追加</br>
    /// <br>Update Note     :    2011/06/06 長内数馬</br>
    /// <br>                     販売区分表示区分を追加</br>
    /// <br>Update Note     :    2012/04/13 福田康夫</br>
    /// <br>                     貸出仕入区分を追加</br>
    /// <br>Update Note     :    2012/12/27 脇田靖之</br>
    /// <br>                     自社品番印字対応</br>
    /// <br>Update Note     :    2013/01/15 FSI福原 一樹</br>
    /// <br>                     仕入返品予定機能区分を追加</br>
    /// <br>Update Note     :    2013/01/16 脇田靖之</br>
    /// <br>                     自社品番印字対応仕様変更対応</br>
    /// <br>Update Note     :    2013/01/21 cheq</br>
    /// <br>管理番号        :    10806793-00 2013/03/13配信分</br>
    /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
    /// <br>Update Note     :    2013/02/05 脇田靖之</br>
    /// <br>                :    ＢＬコード０対応</br>
    /// <br>Update Note     :    2017/04/13 譚洪</br>
    /// <br>                     売上伝票入力画面の仕入担当者セット方法を変更</br>
    /// <br>                     仕入担当参照区分の追加</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesTtlStWork : IFileHeader
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
		/// <remarks>オール０は全社</remarks>
		private string _sectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>売上伝票発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _salesSlipPrtDiv;

		/// <summary>出荷伝票発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _shipmSlipPrtDiv;

		/// <summary>出荷伝票単価印刷区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _shipmSlipUnPrcPrtDiv;

		/// <summary>粗利チェック下限</summary>
		/// <remarks>粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckLower;

		/// <summary>粗利チェック適正</summary>
		/// <remarks>粗利チェックの適正値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>粗利チェック上限</summary>
		/// <remarks>粗利チェックの上限値（％で入力）　XX.X％　以上</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>粗利チェック下限記号</summary>
		/// <remarks>粗利チェックの下限値未満の記号</remarks>
		private string _grsProfitChkLowSign = "";

		/// <summary>粗利チェック適正記号</summary>
		/// <remarks>粗利チェックの適正値から下限値までの記号</remarks>
		private string _grsProfitChkBestSign = "";

		/// <summary>粗利チェック上限記号</summary>
		/// <remarks>粗利チェックの上限値から適正値までの記号</remarks>
		private string _grsProfitChkUprSign = "";

		/// <summary>粗利チェック最大記号</summary>
		/// <remarks>粗利チェックの上限値オーバーの記号</remarks>
		private string _grsProfitChkMaxSign = "";

		/// <summary>売上担当変更区分</summary>
		/// <remarks>0:可能　1:変更時警告　2:不可</remarks>
		private Int32 _salesAgentChngDiv;

		/// <summary>受注者表示区分</summary>
		/// <remarks>0:有り　1:無し　 2:必須　（無しの場合、画面項目を非表示) </remarks>
		private Int32 _acpOdrAgentDispDiv;

		/// <summary>伝票備考２表示区分</summary>
		/// <remarks>0:有り　1:無し　（無しの場合、画面項目を非表示) </remarks>
		private Int32 _brSlipNote2DispDiv;

		/// <summary>明細備考表示区分</summary>
		/// <remarks>0:有り　1:無し　（無しの場合、画面項目を非表示) </remarks>
		private Int32 _dtlNoteDispDiv;

		/// <summary>売価未設定時区分</summary>
		/// <remarks>0:ゼロを表示　1:定価を表示</remarks>
		private Int32 _unPrcNonSettingDiv;

		/// <summary>見積データ計上残区分</summary>
		/// <remarks>0:残す　1:残さない</remarks>
		private Int32 _estmateAddUpRemDiv;

		/// <summary>受注データ計上残区分</summary>
		/// <remarks>0:残す　1:残さない</remarks>
		private Int32 _acpOdrrAddUpRemDiv;

		/// <summary>出荷データ計上残区分</summary>
		/// <remarks>0:残す　1:残さない</remarks>
		private Int32 _shipmAddUpRemDiv;

		/// <summary>返品時在庫登録区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _retGoodsStockEtyDiv;

		/// <summary>定価選択区分</summary>
		/// <remarks>0:しない 1:する</remarks>
		private Int32 _listPriceSelectDiv;

		/// <summary>メーカー入力区分</summary>
		/// <remarks>0:任意　1:必須</remarks>
		private Int32 _makerInpDiv;

		/// <summary>BL商品コード入力区分</summary>
		/// <remarks>0:任意　1:必須</remarks>
		private Int32 _bLGoodsCdInpDiv;

		/// <summary>仕入先入力区分</summary>
		/// <remarks>0:任意　1:必須</remarks>
		private Int32 _supplierInpDiv;

		/// <summary>仕入伝票削除区分</summary>
		/// <remarks>0:しない　1:確認　2:する（する:売仕入同時計上の仕入伝票を売伝削除時に同時削除）</remarks>
		private Int32 _supplierSlipDelDiv;

		/// <summary>得意先ガイド初期表示区分</summary>
		/// <remarks>1:自拠点のみ表示　0:全て表示 </remarks>
		private Int32 _custGuideDispDiv;

		/// <summary>伝票修正区分（日付）</summary>
		/// <remarks>0:可能　1:返品伝票以外可 2:返品伝票のみ可 3:不可</remarks>
		private Int32 _slipChngDivDate;

		/// <summary>伝票修正区分（原価）</summary>
		/// <remarks>0:可能　1:返品伝票以外可 2:返品伝票のみ可 3:不可</remarks>
		private Int32 _slipChngDivCost;

		/// <summary>伝票修正区分（売価）</summary>
		/// <remarks>0:可能　1:返品伝票以外可 2:返品伝票のみ可 3:不可</remarks>
		private Int32 _slipChngDivUnPrc;

		/// <summary>伝票修正区分（定価）</summary>
		/// <remarks>0:可能　1:不可　2:在庫がある場合修正不可　（返品伝票以外）</remarks>
		private Int32 _slipChngDivLPrice;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
        /// <summary>返品伝票修正区分（原価）</summary>
        /// <remarks>0:可能　1:不可　2:未使用　3:在庫時不可</remarks>
        private Int32 _retSlipChngDivCost;

        /// <summary>返品伝票修正区分（売価）</summary>
        /// <remarks>0:可能　1:不可　2:未使用　3:在庫時不可</remarks>
        private Int32 _retSlipChngDivUnPrc;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD

		/// <summary>自動入金金種コード</summary>
		/// <remarks>エントリでの自動入金の金種</remarks>
		private Int32 _autoDepoKindCode;

		/// <summary>自動入金金種名称</summary>
		/// <remarks>エントリでの自動入金の金種</remarks>
		private string _autoDepoKindName = "";

		/// <summary>自動入金金種区分</summary>
		/// <remarks>エントリでの自動入金の金種</remarks>
		private Int32 _autoDepoKindDivCd;

		/// <summary>値引名称</summary>
		private string _discountName = "";

		/// <summary>発行者表示区分</summary>
		/// <remarks>0:する　1:しない　 2:必須　（無しの場合、画面項目を非表示) </remarks>
		private Int32 _inpAgentDispDiv;

		/// <summary>得意先注番表示区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _custOrderNoDispDiv;

		/// <summary>車輌管理番号表示区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _carMngNoDispDiv;

        // --- ADD 2009/10/19 ---------->>>>>
        /// <summary>表示区分プロセス</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _priceSelectDispDiv;
        // --- ADD 2009/10/19 ----------<<<<<

        // --- ADD 2010/01/29 ---------->>>>>
        /// <summary>受注数入力</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _acpOdrInputDiv;
        // --- ADD 2010/01/29 ----------<<<<<

        // --- ADD 2010/05/04 ---------->>>>>
        /// <summary>発行者チェック区分</summary>
        /// <remarks>0:無視 1:再入力 2:警告</remarks>
        private Int32 _inpAgentChkDiv;

        /// <summary>入力倉庫チェック区分</summary>
        /// <remarks>0:無視 1:再入力 2:警告</remarks>
        private Int32 _inpWarehChkDiv;
        // --- ADD 2010/05/04 ----------<<<<<

		/// <summary>伝票備考３表示区分</summary>
		/// <remarks>0:する　1:しない　（無しの場合、画面項目を非表示) </remarks>
		private Int32 _brSlipNote3DispDiv;

		/// <summary>伝票日付クリア区分</summary>
		/// <remarks>0:システム日付 1:入力日付</remarks>
		private Int32 _slipDateClrDivCd;

		/// <summary>商品自動登録</summary>
		/// <remarks>0:なし　1:あり</remarks>
		private Int32 _autoEntryGoodsDivCd;

		/// <summary>原価チェック区分</summary>
		/// <remarks>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</remarks>
		private Int32 _costCheckDivCd;

		/// <summary>結合初期表示区分</summary>
		/// <remarks>0:表示順 1:在庫順</remarks>
		private Int32 _joinInitDispDiv;

		/// <summary>自動入金区分</summary>
		/// <remarks>0:しない,1:する</remarks>
		private Int32 _autoDepositCd;

		/// <summary>代替条件区分</summary>
		/// <remarks>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</remarks>
		private Int32 _substCondDivCd;

		/// <summary>伝票作成方法</summary>
		/// <remarks>0:入力順 1:在庫別 2:倉庫別 3:出力先別</remarks>
		private Int32 _slipCreateProcess;

		/// <summary>倉庫チェック区分</summary>
		/// <remarks>0:警告　1:無視</remarks>
		private Int32 _warehouseChkDiv;

		/// <summary>部品検索区分</summary>
		/// <remarks>0:部品検索,1:品番検索</remarks>
		private Int32 _partsSearchDivCd;

		/// <summary>粗利表示区分</summary>
		/// <remarks>0:する 1:しない,</remarks>
		private Int32 _grsProfitDspCd;

		/// <summary>部品検索優先順区分</summary>
		/// <remarks>0:純正　1:優良</remarks>
		private Int32 _partsSearchPriDivCd;

		/// <summary>売上仕入区分</summary>
		/// <remarks>0:しない　1:する　2:必須入力</remarks>
		private Int32 _salesStockDiv;

		/// <summary>印刷用BL商品コード区分</summary>
		/// <remarks>0:部品,1:検索</remarks>
		private Int32 _prtBLGoodsCodeDiv;

		/// <summary>拠点表示区分</summary>
		/// <remarks>0:標準　1:自拠点　2:表示無し　※標準は 得意先の管理拠点</remarks>
		private Int32 _sectDspDivCd;

		/// <summary>商品名再表示区分</summary>
		/// <remarks>0:しない　1:する ※BLｺｰﾄﾞ変更時にBL名称で上書き</remarks>
		private Int32 _goodsNmReDispDivCd;

		/// <summary>原価表示区分</summary>
		/// <remarks>0:しない 1:する　</remarks>
		private Int32 _costDspDivCd;

		/// <summary>入金伝票日付クリア区分</summary>
		/// <remarks>0:システム日付 1:入力日付</remarks>
		private Int32 _depoSlipDateClrDiv;

		/// <summary>入金伝票日付範囲区分</summary>
		/// <remarks>0:制限なし 1:システム日付以降入力不可</remarks>
		private Int32 _depoSlipDateAmbit;

		/// <summary>入力粗利チェック下限</summary>
		/// <remarks>入力粗利チェックの下限値（％で入力）　XX.X％　以上</remarks>
		private Double _inpGrsProfChkLower;

		/// <summary>入力粗利チェック上限</summary>
		/// <remarks>入力粗利チェックの上限値（％で入力）　XX.X％　未満</remarks>
		private Double _inpGrsProfChkUpper;

		/// <summary>入力粗利チェック下限区分</summary>
		/// <remarks>0:再入力,1:警告,2:無視</remarks>
		private Int32 _inpGrsPrfChkLowDiv;

		/// <summary>入力粗利チェック上限区分</summary>
		/// <remarks>0:再入力,1:警告,2:無視</remarks>
		private Int32 _inpGrsPrfChkUppDiv;

		/// <summary>優良代替条件区分</summary>
		/// <remarks>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</remarks>
		private Int32 _prmSubstCondDivCd;

		/// <summary>代替適用区分</summary>
		/// <remarks>0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）</remarks>
		private Int32 _substApplyDivCd;

        /// <summary>品名表示区分</summary>
        /// <remarks>0:商品優先, 1:提供優先</remarks>
        private Int32 _partsNameDspDivCd;

        // --- ADD 2010/04/30-------------------------------->>>>>
        /// <summary>自由検索部品自動登録区分</summary>
        /// <remarks>0:しない　1:する </remarks>
        private Int32 _frSrchPrtAutoEntDiv;
        // --- ADD 2010/04/30 --------------------------------<<<<<

        /// <summary>BLコード枝番区分</summary>
        /// <remarks>0:枝番なし, 1:枝番あり</remarks>
        private Int32 _bLGoodsCdDerivNoDiv;

        // 2010/05/14 Add >>>
        /// <summary>BLコード検索品名表示区分１</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _bLCdPrtsNmDspDivCd1;

        /// <summary>BLコード検索品名表示区分２</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _bLCdPrtsNmDspDivCd2;

        /// <summary>BLコード検索品名表示区分３</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _bLCdPrtsNmDspDivCd3;

        /// <summary>BLコード検索品名表示区分４</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _bLCdPrtsNmDspDivCd4;

        /// <summary>品番検索品名表示区分１</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _gdNoPrtsNmDspDivCd1;

        /// <summary>品番検索品名表示区分２</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _gdNoPrtsNmDspDivCd2;

        /// <summary>品番検索品名表示区分３</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _gdNoPrtsNmDspDivCd3;

        /// <summary>品番検索品名表示区分４</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private Int32 _gdNoPrtsNmDspDivCd4;

        /// <summary>優良部品検索品名使用区分</summary>
        /// <remarks>0:使用 1:未使用</remarks>
        private Int32 _prmPrtsNmUseDivCd;
        // 2010/05/14 Add <<<

        // --- ADD 2010/08/04 ---------->>>>>
        /// <summary>小数点表示区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _dwnPLCdSpDivCd;
        // --- ADD 2010/08/04 ----------<<<<<

        // --- ADD 2011/06/06 ---------->>>>>
        /// <summary>販売区分表示区分</summary>
        /// <remarks>0:する, 1:しない, 2:必須</remarks>
        private Int32 _salesCdDspDivCd;
        // --- ADD 2011/06/06 ----------<<<<<

        // --- ADD 2012/04/13 ---------->>>>>
        /// <summary>貸出仕入区分</summary>
        /// <remarks>0:しない, 1:する, 2:必須入力</remarks>
        private Int32 _rentStockDiv;  
        // --- ADD 2012/04/13 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>自社品番印字区分</summary>
        /// <remarks>0:しない, 1:する</remarks>
        private Int32 _EpPartsNoPrtCd;

        /// <summary>自社品番付加文字</summary>
        private string _EpPartsNoAddChar;
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// <summary>印字品番初期値</summary>
        /// <remarks>0:優良, 1:自社, 2:無し</remarks>
        private Int32 _PrintGoodsNoDef;
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
		// --- ADD 2013/01/15 ---------->>>>>
        /// <summary>仕入返品予定機能区分</summary>
        private Int32 _stockRetGoodsPlnDiv;
        // --- ADD 2013/01/15 ----------<<<<<

        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// <summary>自動入金備考区分</summary>
        /// <remarks>0:売上伝票番号 1:売上伝票備考 2:無し</remarks>
        private Int32 _autoDepositNoteDiv;
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// <summary>BLコード０対応</summary>
        /// <remarks>0:しない, 1:する</remarks>
        private Int32 _BLGoodsCdZeroSuprt;

        /// <summary>変換コード</summary>
        private Int32 _BLGoodsCdChange;
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

        // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
        /// <summary>仕入担当参照区分</summary>
        private Int32 _stockEmpRefDiv;
        // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

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
		/// <value>オール０は全社</value>
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

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  SalesSlipPrtDiv
		/// <summary>売上伝票発行区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipPrtDiv
		{
			get{return _salesSlipPrtDiv;}
			set{_salesSlipPrtDiv = value;}
		}

		/// public propaty name  :  ShipmSlipPrtDiv
		/// <summary>出荷伝票発行区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmSlipPrtDiv
		{
			get{return _shipmSlipPrtDiv;}
			set{_shipmSlipPrtDiv = value;}
		}

		/// public propaty name  :  ShipmSlipUnPrcPrtDiv
		/// <summary>出荷伝票単価印刷区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷伝票単価印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmSlipUnPrcPrtDiv
		{
			get{return _shipmSlipUnPrcPrtDiv;}
			set{_shipmSlipUnPrcPrtDiv = value;}
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>粗利チェック下限プロパティ</summary>
		/// <value>粗利チェックの下限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック下限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckLower
		{
			get{return _grsProfitCheckLower;}
			set{_grsProfitCheckLower = value;}
		}

		/// public propaty name  :  GrsProfitCheckBest
		/// <summary>粗利チェック適正プロパティ</summary>
		/// <value>粗利チェックの適正値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック適正プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckBest
		{
			get{return _grsProfitCheckBest;}
			set{_grsProfitCheckBest = value;}
		}

		/// public propaty name  :  GrsProfitCheckUpper
		/// <summary>粗利チェック上限プロパティ</summary>
		/// <value>粗利チェックの上限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック上限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double GrsProfitCheckUpper
		{
			get{return _grsProfitCheckUpper;}
			set{_grsProfitCheckUpper = value;}
		}

		/// public propaty name  :  GrsProfitChkLowSign
		/// <summary>粗利チェック下限記号プロパティ</summary>
		/// <value>粗利チェックの下限値未満の記号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック下限記号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrsProfitChkLowSign
		{
			get{return _grsProfitChkLowSign;}
			set{_grsProfitChkLowSign = value;}
		}

		/// public propaty name  :  GrsProfitChkBestSign
		/// <summary>粗利チェック適正記号プロパティ</summary>
		/// <value>粗利チェックの適正値から下限値までの記号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック適正記号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrsProfitChkBestSign
		{
			get{return _grsProfitChkBestSign;}
			set{_grsProfitChkBestSign = value;}
		}

		/// public propaty name  :  GrsProfitChkUprSign
		/// <summary>粗利チェック上限記号プロパティ</summary>
		/// <value>粗利チェックの上限値から適正値までの記号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック上限記号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrsProfitChkUprSign
		{
			get{return _grsProfitChkUprSign;}
			set{_grsProfitChkUprSign = value;}
		}

		/// public propaty name  :  GrsProfitChkMaxSign
		/// <summary>粗利チェック最大記号プロパティ</summary>
		/// <value>粗利チェックの上限値オーバーの記号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック最大記号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GrsProfitChkMaxSign
		{
			get{return _grsProfitChkMaxSign;}
			set{_grsProfitChkMaxSign = value;}
		}

		/// public propaty name  :  SalesAgentChngDiv
		/// <summary>売上担当変更区分プロパティ</summary>
		/// <value>0:可能　1:変更時警告　2:不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上担当変更区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesAgentChngDiv
		{
			get{return _salesAgentChngDiv;}
			set{_salesAgentChngDiv = value;}
		}

		/// public propaty name  :  AcpOdrAgentDispDiv
		/// <summary>受注者表示区分プロパティ</summary>
		/// <value>0:有り　1:無し　 2:必須　（無しの場合、画面項目を非表示) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注者表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcpOdrAgentDispDiv
		{
			get{return _acpOdrAgentDispDiv;}
			set{_acpOdrAgentDispDiv = value;}
		}

		/// public propaty name  :  BrSlipNote2DispDiv
		/// <summary>伝票備考２表示区分プロパティ</summary>
		/// <value>0:有り　1:無し　（無しの場合、画面項目を非表示) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考２表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BrSlipNote2DispDiv
		{
			get{return _brSlipNote2DispDiv;}
			set{_brSlipNote2DispDiv = value;}
		}

		/// public propaty name  :  DtlNoteDispDiv
		/// <summary>明細備考表示区分プロパティ</summary>
		/// <value>0:有り　1:無し　（無しの場合、画面項目を非表示) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細備考表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DtlNoteDispDiv
		{
			get{return _dtlNoteDispDiv;}
			set{_dtlNoteDispDiv = value;}
		}

		/// public propaty name  :  UnPrcNonSettingDiv
		/// <summary>売価未設定時区分プロパティ</summary>
		/// <value>0:ゼロを表示　1:定価を表示</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売価未設定時区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcNonSettingDiv
		{
			get{return _unPrcNonSettingDiv;}
			set{_unPrcNonSettingDiv = value;}
		}

		/// public propaty name  :  EstmateAddUpRemDiv
		/// <summary>見積データ計上残区分プロパティ</summary>
		/// <value>0:残す　1:残さない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積データ計上残区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstmateAddUpRemDiv
		{
			get{return _estmateAddUpRemDiv;}
			set{_estmateAddUpRemDiv = value;}
		}

		/// public propaty name  :  AcpOdrrAddUpRemDiv
		/// <summary>受注データ計上残区分プロパティ</summary>
		/// <value>0:残す　1:残さない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注データ計上残区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcpOdrrAddUpRemDiv
		{
			get{return _acpOdrrAddUpRemDiv;}
			set{_acpOdrrAddUpRemDiv = value;}
		}

		/// public propaty name  :  ShipmAddUpRemDiv
		/// <summary>出荷データ計上残区分プロパティ</summary>
		/// <value>0:残す　1:残さない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷データ計上残区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipmAddUpRemDiv
		{
			get{return _shipmAddUpRemDiv;}
			set{_shipmAddUpRemDiv = value;}
		}

		/// public propaty name  :  RetGoodsStockEtyDiv
		/// <summary>返品時在庫登録区分プロパティ</summary>
		/// <value>0:する　1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品時在庫登録区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RetGoodsStockEtyDiv
		{
			get{return _retGoodsStockEtyDiv;}
			set{_retGoodsStockEtyDiv = value;}
		}

		/// public propaty name  :  ListPriceSelectDiv
		/// <summary>定価選択区分プロパティ</summary>
		/// <value>0:しない 1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価選択区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListPriceSelectDiv
		{
			get{return _listPriceSelectDiv;}
			set{_listPriceSelectDiv = value;}
		}

		/// public propaty name  :  MakerInpDiv
		/// <summary>メーカー入力区分プロパティ</summary>
		/// <value>0:任意　1:必須</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー入力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerInpDiv
		{
			get{return _makerInpDiv;}
			set{_makerInpDiv = value;}
		}

		/// public propaty name  :  BLGoodsCdInpDiv
		/// <summary>BL商品コード入力区分プロパティ</summary>
		/// <value>0:任意　1:必須</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード入力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCdInpDiv
		{
			get{return _bLGoodsCdInpDiv;}
			set{_bLGoodsCdInpDiv = value;}
		}

		/// public propaty name  :  SupplierInpDiv
		/// <summary>仕入先入力区分プロパティ</summary>
		/// <value>0:任意　1:必須</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先入力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierInpDiv
		{
			get{return _supplierInpDiv;}
			set{_supplierInpDiv = value;}
		}

		/// public propaty name  :  SupplierSlipDelDiv
		/// <summary>仕入伝票削除区分プロパティ</summary>
		/// <value>0:しない　1:確認　2:する（する:売仕入同時計上の仕入伝票を売伝削除時に同時削除）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipDelDiv
		{
			get{return _supplierSlipDelDiv;}
			set{_supplierSlipDelDiv = value;}
		}

		/// public propaty name  :  CustGuideDispDiv
		/// <summary>得意先ガイド初期表示区分プロパティ</summary>
		/// <value>1:自拠点のみ表示　0:全て表示 </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先ガイド初期表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustGuideDispDiv
		{
			get{return _custGuideDispDiv;}
			set{_custGuideDispDiv = value;}
		}

		/// public propaty name  :  SlipChngDivDate
		/// <summary>伝票修正区分（日付）プロパティ</summary>
		/// <value>0:可能　1:返品伝票以外可 2:返品伝票のみ可 3:不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票修正区分（日付）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipChngDivDate
		{
			get{return _slipChngDivDate;}
			set{_slipChngDivDate = value;}
		}

		/// public propaty name  :  SlipChngDivCost
		/// <summary>伝票修正区分（原価）プロパティ</summary>
		/// <value>0:可能　1:返品伝票以外可 2:返品伝票のみ可 3:不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票修正区分（原価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipChngDivCost
		{
			get{return _slipChngDivCost;}
			set{_slipChngDivCost = value;}
		}

		/// public propaty name  :  SlipChngDivUnPrc
		/// <summary>伝票修正区分（売価）プロパティ</summary>
		/// <value>0:可能　1:返品伝票以外可 2:返品伝票のみ可 3:不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票修正区分（売価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipChngDivUnPrc
		{
			get{return _slipChngDivUnPrc;}
			set{_slipChngDivUnPrc = value;}
		}

		/// public propaty name  :  SlipChngDivLPrice
		/// <summary>伝票修正区分（定価）プロパティ</summary>
		/// <value>0:可能　1:不可　2:在庫がある場合修正不可　（返品伝票以外）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票修正区分（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipChngDivLPrice
		{
			get{return _slipChngDivLPrice;}
			set{_slipChngDivLPrice = value;}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
        /// public propaty name  :  RetSlipChngDivCost
        /// <summary>返品伝票修正区分（原価）プロパティ</summary>
        /// <value>0:可能　1:不可　2:未使用　3:在庫時不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票修正区分（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetSlipChngDivCost
        {
            get { return _retSlipChngDivCost; }
            set { _retSlipChngDivCost = value; }
        }

        /// public propaty name  :  RetSlipChngDivUnPrc
        /// <summary>返品伝票修正区分（売価）プロパティ</summary>
        /// <value>0:可能　1:不可　2:未使用　3:在庫時不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票修正区分（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetSlipChngDivUnPrc
        {
            get { return _retSlipChngDivUnPrc; }
            set { _retSlipChngDivUnPrc = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD

		/// public propaty name  :  AutoDepoKindCode
		/// <summary>自動入金金種コードプロパティ</summary>
		/// <value>エントリでの自動入金の金種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金金種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepoKindCode
		{
			get{return _autoDepoKindCode;}
			set{_autoDepoKindCode = value;}
		}

		/// public propaty name  :  AutoDepoKindName
		/// <summary>自動入金金種名称プロパティ</summary>
		/// <value>エントリでの自動入金の金種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金金種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AutoDepoKindName
		{
			get{return _autoDepoKindName;}
			set{_autoDepoKindName = value;}
		}

		/// public propaty name  :  AutoDepoKindDivCd
		/// <summary>自動入金金種区分プロパティ</summary>
		/// <value>エントリでの自動入金の金種</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金金種区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepoKindDivCd
		{
			get{return _autoDepoKindDivCd;}
			set{_autoDepoKindDivCd = value;}
		}

		/// public propaty name  :  DiscountName
		/// <summary>値引名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DiscountName
		{
			get{return _discountName;}
			set{_discountName = value;}
		}

		/// public propaty name  :  InpAgentDispDiv
		/// <summary>発行者表示区分プロパティ</summary>
		/// <value>0:する　1:しない　 2:必須　（無しの場合、画面項目を非表示) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行者表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InpAgentDispDiv
		{
			get{return _inpAgentDispDiv;}
			set{_inpAgentDispDiv = value;}
		}

		/// public propaty name  :  CustOrderNoDispDiv
		/// <summary>得意先注番表示区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先注番表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustOrderNoDispDiv
		{
			get{return _custOrderNoDispDiv;}
			set{_custOrderNoDispDiv = value;}
		}

		/// public propaty name  :  CarMngNoDispDiv
		/// <summary>車輌管理番号表示区分プロパティ</summary>
		/// <value>0:しない　1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車輌管理番号表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarMngNoDispDiv
		{
			get{return _carMngNoDispDiv;}
			set{_carMngNoDispDiv = value;}
		}

        // --- ADD 2009/10/19 ---------->>>>>
        /// public propaty name  :  PriceSelectDispDiv
        /// <summary>表示区分プロセスプロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロセスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectDispDiv
        {
            get { return _priceSelectDispDiv; }
            set { _priceSelectDispDiv = value; }
        }
        // --- ADD 2009/10/19 ----------<<<<<

        // --- ADD 2010/01/29 ---------->>>>>
        /// public propaty name  :  AcpOdrInputDiv
        /// <summary>受注数入力プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数入力プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrInputDiv
        {
            get { return _acpOdrInputDiv; }
            set { _acpOdrInputDiv = value; }
        }
        // --- ADD 2010/01/29 ----------<<<<<

        // --- ADD 2010/05/04 ---------->>>>>
        /// public propaty name  :  InpAgentChkDiv
        /// <summary>発行者チェック区分プロパティ</summary>
        /// <value>0:無視 1:再入力 2:警告</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InpAgentChkDiv
        {
            get { return _inpAgentChkDiv; }
            set { _inpAgentChkDiv = value; }
        }

        /// public propaty name  :  InpWarehChkDiv
        /// <summary>入力倉庫チェック区分プロパティ</summary>
        /// <value>0:無視 1:再入力 2:警告</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力倉庫チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InpWarehChkDiv
        {
            get { return _inpWarehChkDiv; }
            set { _inpWarehChkDiv = value; }
        }
        // --- ADD 2010/05/04 ----------<<<<<

		/// public propaty name  :  BrSlipNote3DispDiv
		/// <summary>伝票備考３表示区分プロパティ</summary>
		/// <value>0:する　1:しない　（無しの場合、画面項目を非表示) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考３表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BrSlipNote3DispDiv
		{
			get{return _brSlipNote3DispDiv;}
			set{_brSlipNote3DispDiv = value;}
		}

		/// public propaty name  :  SlipDateClrDivCd
		/// <summary>伝票日付クリア区分プロパティ</summary>
		/// <value>0:システム日付 1:入力日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票日付クリア区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipDateClrDivCd
		{
			get{return _slipDateClrDivCd;}
			set{_slipDateClrDivCd = value;}
		}

		/// public propaty name  :  AutoEntryGoodsDivCd
		/// <summary>商品自動登録プロパティ</summary>
		/// <value>0:なし　1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品自動登録プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoEntryGoodsDivCd
		{
			get{return _autoEntryGoodsDivCd;}
			set{_autoEntryGoodsDivCd = value;}
		}

		/// public propaty name  :  CostCheckDivCd
		/// <summary>原価チェック区分プロパティ</summary>
		/// <value>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価チェック区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CostCheckDivCd
		{
			get{return _costCheckDivCd;}
			set{_costCheckDivCd = value;}
		}

		/// public propaty name  :  JoinInitDispDiv
		/// <summary>結合初期表示区分プロパティ</summary>
		/// <value>0:表示順 1:在庫順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合初期表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinInitDispDiv
		{
			get{return _joinInitDispDiv;}
			set{_joinInitDispDiv = value;}
		}

		/// public propaty name  :  AutoDepositCd
		/// <summary>自動入金区分プロパティ</summary>
		/// <value>0:しない,1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepositCd
		{
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		/// public propaty name  :  SubstCondDivCd
		/// <summary>代替条件区分プロパティ</summary>
		/// <value>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstCondDivCd
		{
			get{return _substCondDivCd;}
			set{_substCondDivCd = value;}
		}

		/// public propaty name  :  SlipCreateProcess
		/// <summary>伝票作成方法プロパティ</summary>
		/// <value>0:入力順 1:在庫別 2:倉庫別 3:出力先別</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票作成方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipCreateProcess
		{
			get{return _slipCreateProcess;}
			set{_slipCreateProcess = value;}
		}

		/// public propaty name  :  WarehouseChkDiv
		/// <summary>倉庫チェック区分プロパティ</summary>
		/// <value>0:警告　1:無視</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫チェック区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WarehouseChkDiv
		{
			get{return _warehouseChkDiv;}
			set{_warehouseChkDiv = value;}
		}

		/// public propaty name  :  PartsSearchDivCd
		/// <summary>部品検索区分プロパティ</summary>
		/// <value>0:部品検索,1:品番検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsSearchDivCd
		{
			get{return _partsSearchDivCd;}
			set{_partsSearchDivCd = value;}
		}

		/// public propaty name  :  GrsProfitDspCd
		/// <summary>粗利表示区分プロパティ</summary>
		/// <value>0:する 1:しない,</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GrsProfitDspCd
		{
			get{return _grsProfitDspCd;}
			set{_grsProfitDspCd = value;}
		}

		/// public propaty name  :  PartsSearchPriDivCd
		/// <summary>部品検索優先順区分プロパティ</summary>
		/// <value>0:純正　1:優良</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品検索優先順区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsSearchPriDivCd
		{
			get{return _partsSearchPriDivCd;}
			set{_partsSearchPriDivCd = value;}
		}

		/// public propaty name  :  SalesStockDiv
		/// <summary>売上仕入区分プロパティ</summary>
		/// <value>0:しない　1:する　2:必須入力</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上仕入区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesStockDiv
		{
			get{return _salesStockDiv;}
			set{_salesStockDiv = value;}
		}

		/// public propaty name  :  PrtBLGoodsCodeDiv
		/// <summary>印刷用BL商品コード区分プロパティ</summary>
		/// <value>0:部品,1:検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用BL商品コード区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtBLGoodsCodeDiv
		{
			get{return _prtBLGoodsCodeDiv;}
			set{_prtBLGoodsCodeDiv = value;}
		}

		/// public propaty name  :  SectDspDivCd
		/// <summary>拠点表示区分プロパティ</summary>
		/// <value>0:標準　1:自拠点　2:表示無し　※標準は 得意先の管理拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SectDspDivCd
		{
			get{return _sectDspDivCd;}
			set{_sectDspDivCd = value;}
		}

		/// public propaty name  :  GoodsNmReDispDivCd
		/// <summary>商品名再表示区分プロパティ</summary>
		/// <value>0:しない　1:する ※BLｺｰﾄﾞ変更時にBL名称で上書き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名再表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNmReDispDivCd
		{
			get{return _goodsNmReDispDivCd;}
			set{_goodsNmReDispDivCd = value;}
		}

		/// public propaty name  :  CostDspDivCd
		/// <summary>原価表示区分プロパティ</summary>
		/// <value>0:しない 1:する　</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CostDspDivCd
		{
			get{return _costDspDivCd;}
			set{_costDspDivCd = value;}
		}

		/// public propaty name  :  DepoSlipDateClrDiv
		/// <summary>入金伝票日付クリア区分プロパティ</summary>
		/// <value>0:システム日付 1:入力日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金伝票日付クリア区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepoSlipDateClrDiv
		{
			get{return _depoSlipDateClrDiv;}
			set{_depoSlipDateClrDiv = value;}
		}

		/// public propaty name  :  DepoSlipDateAmbit
		/// <summary>入金伝票日付範囲区分プロパティ</summary>
		/// <value>0:制限なし 1:システム日付以降入力不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入金伝票日付範囲区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DepoSlipDateAmbit
		{
			get{return _depoSlipDateAmbit;}
			set{_depoSlipDateAmbit = value;}
		}

		/// public propaty name  :  InpGrsProfChkLower
		/// <summary>入力粗利チェック下限プロパティ</summary>
		/// <value>入力粗利チェックの下限値（％で入力）　XX.X％　以上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力粗利チェック下限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double InpGrsProfChkLower
		{
			get{return _inpGrsProfChkLower;}
			set{_inpGrsProfChkLower = value;}
		}

		/// public propaty name  :  InpGrsProfChkUpper
		/// <summary>入力粗利チェック上限プロパティ</summary>
		/// <value>入力粗利チェックの上限値（％で入力）　XX.X％　未満</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力粗利チェック上限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double InpGrsProfChkUpper
		{
			get{return _inpGrsProfChkUpper;}
			set{_inpGrsProfChkUpper = value;}
		}

		/// public propaty name  :  InpGrsPrfChkLowDiv
		/// <summary>入力粗利チェック下限区分プロパティ</summary>
		/// <value>0:再入力,1:警告,2:無視</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力粗利チェック下限区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InpGrsPrfChkLowDiv
		{
			get{return _inpGrsPrfChkLowDiv;}
			set{_inpGrsPrfChkLowDiv = value;}
		}

		/// public propaty name  :  InpGrsPrfChkUppDiv
		/// <summary>入力粗利チェック上限区分プロパティ</summary>
		/// <value>0:再入力,1:警告,2:無視</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力粗利チェック上限区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InpGrsPrfChkUppDiv
		{
			get{return _inpGrsPrfChkUppDiv;}
			set{_inpGrsPrfChkUppDiv = value;}
		}

		/// public propaty name  :  PrmSubstCondDivCd
		/// <summary>優良代替条件区分プロパティ</summary>
		/// <value>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良代替条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrmSubstCondDivCd
		{
			get{return _prmSubstCondDivCd;}
			set{_prmSubstCondDivCd = value;}
		}

		/// public propaty name  :  SubstApplyDivCd
		/// <summary>代替適用区分プロパティ</summary>
		/// <value>0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstApplyDivCd
		{
			get{return _substApplyDivCd;}
			set{_substApplyDivCd = value;}
		}

        /// public propaty name  :  PartsNameDspDivCd
        /// <summary>品名表示区分プロパティ</summary>
        /// <value>0:商品優先, 1:提供優先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsNameDspDivCd
        {
            get { return _partsNameDspDivCd; }
            set { _partsNameDspDivCd = value; }
        }

        // --- ADD 2010/04/30-------------------------------->>>>>
        /// public propaty name  :  FrSrchPrtAutoEntDiv
        /// <summary>自由検索部品自動登録区分プロパティ</summary>
        /// <value>0:しない　1:する </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索部品自動登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FrSrchPrtAutoEntDiv
        {
            get { return _frSrchPrtAutoEntDiv; }
            set { _frSrchPrtAutoEntDiv = value; }
        }
        // --- ADD 2010/04/30 --------------------------------<<<<<


        /// public propaty name  :  BLGoodsCdDerivNoDiv
        /// <summary>BLコード枝番区分プロパティ</summary>
        /// <value>0:枝番なし, 1:枝番あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCdDerivNoDiv
        {
            get { return _bLGoodsCdDerivNoDiv; }
            set { _bLGoodsCdDerivNoDiv = value; }
        }

        // 2010/05/14 Add >>>
        /// public propaty name  :  BLCdPrtsNmDspDivCd1
        /// <summary>BLコード検索品名表示区分１プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード検索品名表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd1
        {
            get { return _bLCdPrtsNmDspDivCd1; }
            set { _bLCdPrtsNmDspDivCd1 = value; }
        }

        /// public propaty name  :  BLCdPrtsNmDspDivCd2
        /// <summary>BLコード検索品名表示区分２プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード検索品名表示区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd2
        {
            get { return _bLCdPrtsNmDspDivCd2; }
            set { _bLCdPrtsNmDspDivCd2 = value; }
        }

        /// public propaty name  :  BLCdPrtsNmDspDivCd3
        /// <summary>BLコード検索品名表示区分３プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード検索品名表示区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd3
        {
            get { return _bLCdPrtsNmDspDivCd3; }
            set { _bLCdPrtsNmDspDivCd3 = value; }
        }

        /// public propaty name  :  BLCdPrtsNmDspDivCd4
        /// <summary>BLコード検索品名表示区分４プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード検索品名表示区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd4
        {
            get { return _bLCdPrtsNmDspDivCd4; }
            set { _bLCdPrtsNmDspDivCd4 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd1
        /// <summary>品番検索品名表示区分１プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索品名表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd1
        {
            get { return _gdNoPrtsNmDspDivCd1; }
            set { _gdNoPrtsNmDspDivCd1 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd2
        /// <summary>品番検索品名表示区分２プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索品名表示区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd2
        {
            get { return _gdNoPrtsNmDspDivCd2; }
            set { _gdNoPrtsNmDspDivCd2 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd3
        /// <summary>品番検索品名表示区分３プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索品名表示区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd3
        {
            get { return _gdNoPrtsNmDspDivCd3; }
            set { _gdNoPrtsNmDspDivCd3 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd4
        /// <summary>品番検索品名表示区分４プロパティ</summary>
        /// <value>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番検索品名表示区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd4
        {
            get { return _gdNoPrtsNmDspDivCd4; }
            set { _gdNoPrtsNmDspDivCd4 = value; }
        }

        /// public propaty name  :  PrmPrtsNmUseDivCd
        /// <summary>優良部品検索品名使用区分プロパティ</summary>
        /// <value>0:使用 1:未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品検索品名使用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmPrtsNmUseDivCd
        {
            get { return _prmPrtsNmUseDivCd; }
            set { _prmPrtsNmUseDivCd = value; }
        }
        // 2010/05/14 Add <<<

        // --- ADD 2010/08/04 ---------->>>>>
        /// public propaty name  :  DwnPLCdSpDivCd
        /// <summary>小数点表示区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小数点表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DwnPLCdSpDivCd
        {
            get { return _dwnPLCdSpDivCd; }
            set { _dwnPLCdSpDivCd = value; }
        }
        // --- ADD 2010/08/04 ----------<<<<<

        // --- ADD 2011/06/06 ---------->>>>>
        /// public propaty name  :  SalesCdDspDivCd
        /// <summary>販売区分表示区分プロパティ</summary>
        /// <value>0:する, 1:しない, 2:必須</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCdDspDivCd
        {
            get { return _salesCdDspDivCd; }
            set { _salesCdDspDivCd = value; }
        }
        // --- ADD 2011/06/06 ----------<<<<<

        // --- ADD 2012/04/13 ---------->>>>>
        /// public propaty name  :  RentStockDiv
        /// <summary>貸出仕入区分プロパティ</summary>
        /// <value>0:しない, 1:する, 2:必須入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出仕入区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RentStockDiv
        {
            get { return _rentStockDiv; }
            set { _rentStockDiv = value; }
        }
        // --- ADD 2012/04/13 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// public propaty name  :  EpPartsNoPrtCd
        /// <summary>自社品番印字区分プロパティ</summary>
        /// <value>0:しない, 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社品番印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EpPartsNoPrtCd
        {
            get { return _EpPartsNoPrtCd; }
            set { _EpPartsNoPrtCd = value; }
        }

        /// public propaty name  :  EpPartsNoAddChar
        /// <summary>自社品番付加文字プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社品番付加文字プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String EpPartsNoAddChar
        {
            get { return _EpPartsNoAddChar; }
            set { _EpPartsNoAddChar = value; }
        }
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// public propaty name  :  PrintGoodsNoDef
        /// <summary>印字品番初期値プロパティ</summary>
        /// <value>0:優良, 1:自社, 2:無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印字品番初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintGoodsNoDef
        {
            get { return _PrintGoodsNoDef; }
            set { _PrintGoodsNoDef = value; }
        }
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
		
		// --- ADD 2013/01/15 ---------->>>>>
        /// public propaty name  :  StockRetGoodsPlnDiv
        /// <summary>仕入返品予定機能区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入返品予定機能区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRetGoodsPlnDiv
        {
            get { return _stockRetGoodsPlnDiv; }
            set { _stockRetGoodsPlnDiv = value; }
        }
        // --- ADD 2013/01/15 ----------<<<<<

        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// public propaty name  :  AutoDepositNoteDiv
        /// <summary>自動入金備考区分プロパティ</summary>
        /// <value>0:売上伝票番号 1:売上伝票備考 2:無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金備考区分プロパティ</br>
        /// <br>Programer        :   cheq</br>
        /// </remarks>
        public Int32 AutoDepositNoteDiv
        {
            get { return _autoDepositNoteDiv; }
            set { _autoDepositNoteDiv = value; }
        }
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// public propaty name  :  BLGoodsCdZeroSuprt
        /// <summary>BLコード０対応プロパティ</summary>
        /// <value>0:しない, 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード０対応プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCdZeroSuprt
        {
            get { return _BLGoodsCdZeroSuprt; }
            set { _BLGoodsCdZeroSuprt = value; }
        }

        /// public propaty name  :  BLGoodsCdChange
        /// <summary>変換コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCdChange
        {
            get { return _BLGoodsCdChange; }
            set { _BLGoodsCdChange = value; }
        }
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

        // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
        /// public propaty name  :  StockEmpRefDivRF
        /// <summary>仕入担当参照区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockEmpRefDiv
        {
            get { return _stockEmpRefDiv; }
            set { _stockEmpRefDiv = value; }
        }
        // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

        /// <summary>
		/// 売上全体設定ワークコンストラクタ
		/// </summary>
		/// <returns>SalesTtlStWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesTtlStWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesTtlStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesTtlStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTtlStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/06 長内数馬 小数点表示区分を追加</br>
        /// <br>Update Note      :   2012/04/13 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>   
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesTtlStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesTtlStWork || graph is ArrayList || graph is SalesTtlStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesTtlStWork).FullName));

            if (graph != null && graph is SalesTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesTtlStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesTtlStWork[])graph).Length;
            }
            else if (graph is SalesTtlStWork)
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
            //売上伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrtDiv
            //出荷伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmSlipPrtDiv
            //出荷伝票単価印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmSlipUnPrcPrtDiv
            //粗利チェック下限
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitCheckLower
            //粗利チェック適正
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitCheckBest
            //粗利チェック上限
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitCheckUpper
            //粗利チェック下限記号
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkLowSign
            //粗利チェック適正記号
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkBestSign
            //粗利チェック上限記号
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkUprSign
            //粗利チェック最大記号
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkMaxSign
            //売上担当変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAgentChngDiv
            //受注者表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrAgentDispDiv
            //伝票備考２表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BrSlipNote2DispDiv
            //明細備考表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlNoteDispDiv
            //売価未設定時区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcNonSettingDiv
            //見積データ計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstmateAddUpRemDiv
            //受注データ計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrAddUpRemDiv
            //出荷データ計上残区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmAddUpRemDiv
            //返品時在庫登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsStockEtyDiv
            //定価選択区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceSelectDiv
            //メーカー入力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerInpDiv
            //BL商品コード入力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdInpDiv
            //仕入先入力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierInpDiv
            //仕入伝票削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipDelDiv
            //得意先ガイド初期表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustGuideDispDiv
            //伝票修正区分（日付）
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivDate
            //伝票修正区分（原価）
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivCost
            //伝票修正区分（売価）
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivUnPrc
            //伝票修正区分（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivLPrice
            //返品伝票修正区分（原価）
            serInfo.MemberInfo.Add(typeof(Int32)); //RetSlipChngDivCost
            //返品伝票修正区分（売価）
            serInfo.MemberInfo.Add(typeof(Int32)); //RetSlipChngDivUnPrc
            //自動入金金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepoKindCode
            //自動入金金種名称
            serInfo.MemberInfo.Add(typeof(string)); //AutoDepoKindName
            //自動入金金種区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepoKindDivCd
            //値引名称
            serInfo.MemberInfo.Add(typeof(string)); //DiscountName
            //発行者表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InpAgentDispDiv
            //得意先注番表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustOrderNoDispDiv
            //車輌管理番号表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngNoDispDiv
            // --- ADD 2009/10/19 ---------->>>>>
            // 表示区分プロセス
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceSelectDispDiv
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            // 受注数入力
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrInputDiv
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            //発行者チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InpAgentChkDiv
            //入力倉庫チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InpWarehChkDiv
            // --- ADD 2010/05/04 ----------<<<<<
            //伝票備考３表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BrSlipNote3DispDiv
            //伝票日付クリア区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDateClrDivCd
            //商品自動登録
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoEntryGoodsDivCd
            //原価チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CostCheckDivCd
            //結合初期表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinInitDispDiv
            //自動入金区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //代替条件区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstCondDivCd
            //伝票作成方法
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipCreateProcess
            //倉庫チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseChkDiv
            //部品検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchDivCd
            //粗利表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GrsProfitDspCd
            //部品検索優先順区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchPriDivCd
            //売上仕入区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesStockDiv
            //印刷用BL商品コード区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCodeDiv
            //拠点表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SectDspDivCd
            //商品名再表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNmReDispDivCd
            //原価表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CostDspDivCd
            //入金伝票日付クリア区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoSlipDateClrDiv
            //入金伝票日付範囲区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoSlipDateAmbit
            //入力粗利チェック下限
            serInfo.MemberInfo.Add(typeof(Double)); //InpGrsProfChkLower
            //入力粗利チェック上限
            serInfo.MemberInfo.Add(typeof(Double)); //InpGrsProfChkUpper
            //入力粗利チェック下限区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InpGrsPrfChkLowDiv
            //入力粗利チェック上限区分
            serInfo.MemberInfo.Add(typeof(Int32)); //InpGrsPrfChkUppDiv
            //優良代替条件区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSubstCondDivCd
            //代替適用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstApplyDivCd
            //品名表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNameDspDivCd
            //BLコード枝番区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdDerivNoDiv
            // --- ADD 2010/04/30-------------------------------->>>>>
            //自由検索部品自動登録区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FrSrchPrtAutoEntDiv
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // 2010/05/14 Add >>>
            //BLコード検索品名表示区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd1
            //BLコード検索品名表示区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd2
            //BLコード検索品名表示区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd3
            //BLコード検索品名表示区分４
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd4
            //品番検索品名表示区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd1
            //品番検索品名表示区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd2
            //品番検索品名表示区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd3
            //品番検索品名表示区分４
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd4
            //優良部品検索品名使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmPrtsNmUseDivCd
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            // 小数点表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DwnPLCdSpDivCd
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            // 販売区分表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCdDspDivCd
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/13 ---------->>>>>
            // 貸出仕入区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RentStockDiv
            // --- ADD 2012/04/13 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EpPartsNoPrtCd
            // 自社品番付加文字
            serInfo.MemberInfo.Add(typeof(String)); //EpPartsNoAddChar
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // 印字品番初期値
            serInfo.MemberInfo.Add(typeof(Int32)); //PrintGoodsNoDef
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
			// --- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定機能区分
            serInfo.MemberInfo.Add(typeof(Int32));
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // 自動入金備考区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositNoteDiv
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BLコード０対応
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdZeroSuprt
            // 変換コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdChange
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            // 仕入担当参照区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockEmpRefDiv
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SalesTtlStWork)
            {
                SalesTtlStWork temp = (SalesTtlStWork)graph;

                SetSalesTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesTtlStWork temp in lst)
                {
                    SetSalesTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesTtlStWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD 2010/01/29 ---------->>>>>
        //private const int currentMemberCount = 75;
        //private const int currentMemberCount = 76;
        // --- UPD 2010/05/04 ---------->>>>>
        // --- UPD 2010/04/30 ---------->>>>>
        // private const int currentMemberCount = 78;
        // 2010/05/14 >>>
        //private const int currentMemberCount = 79;

        // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
        //// --- UPD 2012/12/27 Y.Wakita ---------->>>>>
        ////// -- UPD 2012/04/13 ------------------>>>
        ////// -- UPD 2011/06/06 ------------------>>>
        //////// --- UPD 2010/08/04 ---------->>>>>
        ////////private const int currentMemberCount = 88;
        //////private const int currentMemberCount = 89;  
        //////// --- UPD 2010/08/04 ----------<<<<<
        //////private const int currentMemberCount = 90;
        ////// -- UPD 2011/06/06 ------------------<<<
        ////private const int currentMemberCount = 91;
        ////// -- UPD 2012/04/13 ------------------<<<
        //private const int currentMemberCount = 93;
        //// --- UPD 2012/12/27 Y.Wakita ----------<<<<<
        //private const int currentMemberCount = 94;
        // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
		// --- UPD 2013/01/18 ---------->>>>>
		//private const int currentMemberCount = 95; // DEL cheq 2013/01/21 Redmine#33797 
        //private const int currentMemberCount = 96; // ADD cheq 2013/01/21 Redmine#33797 DEL 2013/02/05 Y.Wakita
        //private const int currentMemberCount = 98; // ADD 2013/02/05 Y.Wakita // DEL 2017/04/13 譚洪 Redmine#49283
        private const int currentMemberCount = 99; // ADD 2017/04/13 譚洪 Redmine#49283
        // --- UPD 2013/01/18 ----------<<<<<
        // 2010/05/14 <<<
        // --- UPD 2010/04/30 ----------<<<<<

		// --- UPD 2010/05/04 ----------<<<<<
        // --- UPD 2010/01/29 ----------<<<<<

        /// <summary>
        ///  SalesTtlStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTtlStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/06 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/13 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// </remarks>
        private void SetSalesTtlStWork(System.IO.BinaryWriter writer, SalesTtlStWork temp)
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
            //売上伝票発行区分
            writer.Write(temp.SalesSlipPrtDiv);
            //出荷伝票発行区分
            writer.Write(temp.ShipmSlipPrtDiv);
            //出荷伝票単価印刷区分
            writer.Write(temp.ShipmSlipUnPrcPrtDiv);
            //粗利チェック下限
            writer.Write(temp.GrsProfitCheckLower);
            //粗利チェック適正
            writer.Write(temp.GrsProfitCheckBest);
            //粗利チェック上限
            writer.Write(temp.GrsProfitCheckUpper);
            //粗利チェック下限記号
            writer.Write(temp.GrsProfitChkLowSign);
            //粗利チェック適正記号
            writer.Write(temp.GrsProfitChkBestSign);
            //粗利チェック上限記号
            writer.Write(temp.GrsProfitChkUprSign);
            //粗利チェック最大記号
            writer.Write(temp.GrsProfitChkMaxSign);
            //売上担当変更区分
            writer.Write(temp.SalesAgentChngDiv);
            //受注者表示区分
            writer.Write(temp.AcpOdrAgentDispDiv);
            //伝票備考２表示区分
            writer.Write(temp.BrSlipNote2DispDiv);
            //明細備考表示区分
            writer.Write(temp.DtlNoteDispDiv);
            //売価未設定時区分
            writer.Write(temp.UnPrcNonSettingDiv);
            //見積データ計上残区分
            writer.Write(temp.EstmateAddUpRemDiv);
            //受注データ計上残区分
            writer.Write(temp.AcpOdrrAddUpRemDiv);
            //出荷データ計上残区分
            writer.Write(temp.ShipmAddUpRemDiv);
            //返品時在庫登録区分
            writer.Write(temp.RetGoodsStockEtyDiv);
            //定価選択区分
            writer.Write(temp.ListPriceSelectDiv);
            //メーカー入力区分
            writer.Write(temp.MakerInpDiv);
            //BL商品コード入力区分
            writer.Write(temp.BLGoodsCdInpDiv);
            //仕入先入力区分
            writer.Write(temp.SupplierInpDiv);
            //仕入伝票削除区分
            writer.Write(temp.SupplierSlipDelDiv);
            //得意先ガイド初期表示区分
            writer.Write(temp.CustGuideDispDiv);
            //伝票修正区分（日付）
            writer.Write(temp.SlipChngDivDate);
            //伝票修正区分（原価）
            writer.Write(temp.SlipChngDivCost);
            //伝票修正区分（売価）
            writer.Write(temp.SlipChngDivUnPrc);
            //伝票修正区分（定価）
            writer.Write(temp.SlipChngDivLPrice);
            //返品伝票修正区分（原価）
            writer.Write(temp.RetSlipChngDivCost);
            //返品伝票修正区分（売価）
            writer.Write(temp.RetSlipChngDivUnPrc);
            //自動入金金種コード
            writer.Write(temp.AutoDepoKindCode);
            //自動入金金種名称
            writer.Write(temp.AutoDepoKindName);
            //自動入金金種区分
            writer.Write(temp.AutoDepoKindDivCd);
            //値引名称
            writer.Write(temp.DiscountName);
            //発行者表示区分
            writer.Write(temp.InpAgentDispDiv);
            //得意先注番表示区分
            writer.Write(temp.CustOrderNoDispDiv);
            //車輌管理番号表示区分
            writer.Write(temp.CarMngNoDispDiv);
            // --- ADD 2009/10/19 ---------->>>>>
            // 表示区分プロセス
            writer.Write(temp.PriceSelectDispDiv);
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            // 受注数入力
            writer.Write(temp.AcpOdrInputDiv);
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            //発行者チェック区分
            writer.Write(temp.InpAgentChkDiv);
            //入力倉庫チェック区分
            writer.Write(temp.InpWarehChkDiv);
            // --- ADD 2010/05/04 ----------<<<<<
            //伝票備考３表示区分
            writer.Write(temp.BrSlipNote3DispDiv);
            //伝票日付クリア区分
            writer.Write(temp.SlipDateClrDivCd);
            //商品自動登録
            writer.Write(temp.AutoEntryGoodsDivCd);
            //原価チェック区分
            writer.Write(temp.CostCheckDivCd);
            //結合初期表示区分
            writer.Write(temp.JoinInitDispDiv);
            //自動入金区分
            writer.Write(temp.AutoDepositCd);
            //代替条件区分
            writer.Write(temp.SubstCondDivCd);
            //伝票作成方法
            writer.Write(temp.SlipCreateProcess);
            //倉庫チェック区分
            writer.Write(temp.WarehouseChkDiv);
            //部品検索区分
            writer.Write(temp.PartsSearchDivCd);
            //粗利表示区分
            writer.Write(temp.GrsProfitDspCd);
            //部品検索優先順区分
            writer.Write(temp.PartsSearchPriDivCd);
            //売上仕入区分
            writer.Write(temp.SalesStockDiv);
            //印刷用BL商品コード区分
            writer.Write(temp.PrtBLGoodsCodeDiv);
            //拠点表示区分
            writer.Write(temp.SectDspDivCd);
            //商品名再表示区分
            writer.Write(temp.GoodsNmReDispDivCd);
            //原価表示区分
            writer.Write(temp.CostDspDivCd);
            //入金伝票日付クリア区分
            writer.Write(temp.DepoSlipDateClrDiv);
            //入金伝票日付範囲区分
            writer.Write(temp.DepoSlipDateAmbit);
            //入力粗利チェック下限
            writer.Write(temp.InpGrsProfChkLower);
            //入力粗利チェック上限
            writer.Write(temp.InpGrsProfChkUpper);
            //入力粗利チェック下限区分
            writer.Write(temp.InpGrsPrfChkLowDiv);
            //入力粗利チェック上限区分
            writer.Write(temp.InpGrsPrfChkUppDiv);
            //優良代替条件区分
            writer.Write(temp.PrmSubstCondDivCd);
            //代替適用区分
            writer.Write(temp.SubstApplyDivCd);
            //品名表示区分
            writer.Write(temp.PartsNameDspDivCd);
            //BLコード枝番区分
            writer.Write(temp.BLGoodsCdDerivNoDiv);
            // --- ADD 2010/04/30-------------------------------->>>>>
            //自由検索部品自動登録区分
            writer.Write(temp.FrSrchPrtAutoEntDiv);
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // 2010/05/14 Add >>>
            //BLコード検索品名表示区分１
            writer.Write(temp.BLCdPrtsNmDspDivCd1);
            //BLコード検索品名表示区分２
            writer.Write(temp.BLCdPrtsNmDspDivCd2);
            //BLコード検索品名表示区分３
            writer.Write(temp.BLCdPrtsNmDspDivCd3);
            //BLコード検索品名表示区分４
            writer.Write(temp.BLCdPrtsNmDspDivCd4);
            //品番検索品名表示区分１
            writer.Write(temp.GdNoPrtsNmDspDivCd1);
            //品番検索品名表示区分２
            writer.Write(temp.GdNoPrtsNmDspDivCd2);
            //品番検索品名表示区分３
            writer.Write(temp.GdNoPrtsNmDspDivCd3);
            //品番検索品名表示区分４
            writer.Write(temp.GdNoPrtsNmDspDivCd4);
            //優良部品検索品名使用区分
            writer.Write(temp.PrmPrtsNmUseDivCd);
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            // 小数点表示区分
            writer.Write(temp.DwnPLCdSpDivCd);
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            // 販売区分表示区分
            writer.Write(temp.SalesCdDspDivCd);
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/13 ---------->>>>>
            // 貸出仕入区分
            writer.Write(temp.RentStockDiv);
            // --- ADD 2012/04/13 ----------<<<<< 
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // 自社品番印字区分
            writer.Write(temp.EpPartsNoPrtCd);
            // 自社品番付加文字
            writer.Write(temp.EpPartsNoAddChar);
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // 印字品番初期値
            writer.Write(temp.PrintGoodsNoDef);
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定機能区分
            writer.Write(temp.StockRetGoodsPlnDiv);
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // 自動入金備考区分
            writer.Write(temp.AutoDepositNoteDiv);
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BLコード０対応
            writer.Write(temp.BLGoodsCdZeroSuprt);
            // 変換コード
            writer.Write(temp.BLGoodsCdChange);
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            // 仕入担当参照区分
            writer.Write(temp.StockEmpRefDiv);
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
        }

        /// <summary>
        ///  SalesTtlStWorkインスタンス取得
        /// </summary>
        /// <returns>SalesTtlStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTtlStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/04/30 姜凱 自由検索部品自動登録区分を追加</br>        
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/06 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/13 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// </remarks>
        private SalesTtlStWork GetSalesTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesTtlStWork temp = new SalesTtlStWork();

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
            //売上伝票発行区分
            temp.SalesSlipPrtDiv = reader.ReadInt32();
            //出荷伝票発行区分
            temp.ShipmSlipPrtDiv = reader.ReadInt32();
            //出荷伝票単価印刷区分
            temp.ShipmSlipUnPrcPrtDiv = reader.ReadInt32();
            //粗利チェック下限
            temp.GrsProfitCheckLower = reader.ReadDouble();
            //粗利チェック適正
            temp.GrsProfitCheckBest = reader.ReadDouble();
            //粗利チェック上限
            temp.GrsProfitCheckUpper = reader.ReadDouble();
            //粗利チェック下限記号
            temp.GrsProfitChkLowSign = reader.ReadString();
            //粗利チェック適正記号
            temp.GrsProfitChkBestSign = reader.ReadString();
            //粗利チェック上限記号
            temp.GrsProfitChkUprSign = reader.ReadString();
            //粗利チェック最大記号
            temp.GrsProfitChkMaxSign = reader.ReadString();
            //売上担当変更区分
            temp.SalesAgentChngDiv = reader.ReadInt32();
            //受注者表示区分
            temp.AcpOdrAgentDispDiv = reader.ReadInt32();
            //伝票備考２表示区分
            temp.BrSlipNote2DispDiv = reader.ReadInt32();
            //明細備考表示区分
            temp.DtlNoteDispDiv = reader.ReadInt32();
            //売価未設定時区分
            temp.UnPrcNonSettingDiv = reader.ReadInt32();
            //見積データ計上残区分
            temp.EstmateAddUpRemDiv = reader.ReadInt32();
            //受注データ計上残区分
            temp.AcpOdrrAddUpRemDiv = reader.ReadInt32();
            //出荷データ計上残区分
            temp.ShipmAddUpRemDiv = reader.ReadInt32();
            //返品時在庫登録区分
            temp.RetGoodsStockEtyDiv = reader.ReadInt32();
            //定価選択区分
            temp.ListPriceSelectDiv = reader.ReadInt32();
            //メーカー入力区分
            temp.MakerInpDiv = reader.ReadInt32();
            //BL商品コード入力区分
            temp.BLGoodsCdInpDiv = reader.ReadInt32();
            //仕入先入力区分
            temp.SupplierInpDiv = reader.ReadInt32();
            //仕入伝票削除区分
            temp.SupplierSlipDelDiv = reader.ReadInt32();
            //得意先ガイド初期表示区分
            temp.CustGuideDispDiv = reader.ReadInt32();
            //伝票修正区分（日付）
            temp.SlipChngDivDate = reader.ReadInt32();
            //伝票修正区分（原価）
            temp.SlipChngDivCost = reader.ReadInt32();
            //伝票修正区分（売価）
            temp.SlipChngDivUnPrc = reader.ReadInt32();
            //伝票修正区分（定価）
            temp.SlipChngDivLPrice = reader.ReadInt32();
            //返品伝票修正区分（原価）
            temp.RetSlipChngDivCost = reader.ReadInt32();
            //返品伝票修正区分（売価）
            temp.RetSlipChngDivUnPrc = reader.ReadInt32();
            //自動入金金種コード
            temp.AutoDepoKindCode = reader.ReadInt32();
            //自動入金金種名称
            temp.AutoDepoKindName = reader.ReadString();
            //自動入金金種区分
            temp.AutoDepoKindDivCd = reader.ReadInt32();
            //値引名称
            temp.DiscountName = reader.ReadString();
            //発行者表示区分
            temp.InpAgentDispDiv = reader.ReadInt32();
            //得意先注番表示区分
            temp.CustOrderNoDispDiv = reader.ReadInt32();
            //車輌管理番号表示区分
            temp.CarMngNoDispDiv = reader.ReadInt32();
            // --- ADD 2009/10/19 ---------->>>>>
            // 表示区分プロセス
            temp.PriceSelectDispDiv = reader.ReadInt32();
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            // 受注数入力
            temp.AcpOdrInputDiv = reader.ReadInt32();
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            //発行者チェック区分
            temp.InpAgentChkDiv = reader.ReadInt32();
            //入力倉庫チェック区分
            temp.InpWarehChkDiv = reader.ReadInt32();
            // --- ADD 2010/05/04 ----------<<<<<
            //伝票備考３表示区分
            temp.BrSlipNote3DispDiv = reader.ReadInt32();
            //伝票日付クリア区分
            temp.SlipDateClrDivCd = reader.ReadInt32();
            //商品自動登録
            temp.AutoEntryGoodsDivCd = reader.ReadInt32();
            //原価チェック区分
            temp.CostCheckDivCd = reader.ReadInt32();
            //結合初期表示区分
            temp.JoinInitDispDiv = reader.ReadInt32();
            //自動入金区分
            temp.AutoDepositCd = reader.ReadInt32();
            //代替条件区分
            temp.SubstCondDivCd = reader.ReadInt32();
            //伝票作成方法
            temp.SlipCreateProcess = reader.ReadInt32();
            //倉庫チェック区分
            temp.WarehouseChkDiv = reader.ReadInt32();
            //部品検索区分
            temp.PartsSearchDivCd = reader.ReadInt32();
            //粗利表示区分
            temp.GrsProfitDspCd = reader.ReadInt32();
            //部品検索優先順区分
            temp.PartsSearchPriDivCd = reader.ReadInt32();
            //売上仕入区分
            temp.SalesStockDiv = reader.ReadInt32();
            //印刷用BL商品コード区分
            temp.PrtBLGoodsCodeDiv = reader.ReadInt32();
            //拠点表示区分
            temp.SectDspDivCd = reader.ReadInt32();
            //商品名再表示区分
            temp.GoodsNmReDispDivCd = reader.ReadInt32();
            //原価表示区分
            temp.CostDspDivCd = reader.ReadInt32();
            //入金伝票日付クリア区分
            temp.DepoSlipDateClrDiv = reader.ReadInt32();
            //入金伝票日付範囲区分
            temp.DepoSlipDateAmbit = reader.ReadInt32();
            //入力粗利チェック下限
            temp.InpGrsProfChkLower = reader.ReadDouble();
            //入力粗利チェック上限
            temp.InpGrsProfChkUpper = reader.ReadDouble();
            //入力粗利チェック下限区分
            temp.InpGrsPrfChkLowDiv = reader.ReadInt32();
            //入力粗利チェック上限区分
            temp.InpGrsPrfChkUppDiv = reader.ReadInt32();
            //優良代替条件区分
            temp.PrmSubstCondDivCd = reader.ReadInt32();
            //代替適用区分
            temp.SubstApplyDivCd = reader.ReadInt32();
            //品名表示区分
            temp.PartsNameDspDivCd = reader.ReadInt32();
            //BLコード枝番区分
            temp.BLGoodsCdDerivNoDiv = reader.ReadInt32();
            // --- ADD 2010/04/30-------------------------------->>>>>
            //自由検索部品自動登録区分
            temp.FrSrchPrtAutoEntDiv = reader.ReadInt32();
            // --- ADD 2010/04/30 --------------------------------<<<<<
            // 2010/05/14 Add >>>
            //BLコード検索品名表示区分１
            temp.BLCdPrtsNmDspDivCd1 = reader.ReadInt32();
            //BLコード検索品名表示区分２
            temp.BLCdPrtsNmDspDivCd2 = reader.ReadInt32();
            //BLコード検索品名表示区分３
            temp.BLCdPrtsNmDspDivCd3 = reader.ReadInt32();
            //BLコード検索品名表示区分４
            temp.BLCdPrtsNmDspDivCd4 = reader.ReadInt32();
            //品番検索品名表示区分１
            temp.GdNoPrtsNmDspDivCd1 = reader.ReadInt32();
            //品番検索品名表示区分２
            temp.GdNoPrtsNmDspDivCd2 = reader.ReadInt32();
            //品番検索品名表示区分３
            temp.GdNoPrtsNmDspDivCd3 = reader.ReadInt32();
            //品番検索品名表示区分４
            temp.GdNoPrtsNmDspDivCd4 = reader.ReadInt32();
            //優良部品検索品名使用区分
            temp.PrmPrtsNmUseDivCd = reader.ReadInt32();
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            // 小数点表示区分
            temp.DwnPLCdSpDivCd = reader.ReadInt32();
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            // 販売区分表示区分
            temp.SalesCdDspDivCd = reader.ReadInt32();
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/13 ---------->>>>>
            // 貸出仕入区分
            temp.RentStockDiv = reader.ReadInt32();
            // --- ADD 2012/04/13 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            temp.EpPartsNoPrtCd = reader.ReadInt32();
            temp.EpPartsNoAddChar = reader.ReadString();
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            temp.PrintGoodsNoDef = reader.ReadInt32();
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定機能区分
            temp.StockRetGoodsPlnDiv = reader.ReadInt32();
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // 自動入金備考区分
            temp.AutoDepositNoteDiv = reader.ReadInt32();
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            temp.BLGoodsCdZeroSuprt = reader.ReadInt32();
            temp.BLGoodsCdChange = reader.ReadInt32();
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            temp.StockEmpRefDiv = reader.ReadInt32();
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

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
        /// <returns>SalesTtlStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesTtlStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesTtlStWork temp = GetSalesTtlStWork(reader, serInfo);
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
                    retValue = (SalesTtlStWork[])lst.ToArray(typeof(SalesTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
