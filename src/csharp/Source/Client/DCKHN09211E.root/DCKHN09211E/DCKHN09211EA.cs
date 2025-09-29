using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesTtlSt
	/// <summary>
	///                      売上全体設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上全体設定マスタヘッダファイル</br>
	/// <br>Programmer       :   30167 上野　弘貴</br>
	/// <br>Date             :   2007/12/06</br>
	/// <br>Update Note      :   2008.02.18 30167 上野　弘貴</br>
	/// <br>					 自動入金関連項目追加</br>
	/// <br>Update Note      :   2008.02.26 30167 上野　弘貴</br>
	/// <br>					 項目追加（入出荷数区分２, 値引名称）</br>
    /// <br>Programmer       :   30415 柴田 倫幸</br>
    /// <br>Date             :   2008/06/06</br>
    /// <br>Programmer       :   30415 柴田 倫幸</br>
    /// <br>Date             :   2008/07/22 項目削除の為、修正</br>
    /// <br></br>
    /// <br>Update Note      :   2009/10/19 朱俊成</br>
    /// <br>                     PM.NS-3-A・保守依頼②</br>
    /// <br>                     表示区分プロセスを追加</br>
    /// <br>Update Note      :   2010/01/29 李侠</br>
    /// <br>                     PM1003・四次改良</br>
    /// <br>                     受注数入力を追加</br>
    /// <br>Update Note      :   2010/04/30 姜凱</br>
    /// <br>                     PM1007D改良</br>
    /// <br>                     自由検索部品自動登録区分を追加</br>    
    /// <br>Update Note     :    2010/05/04 王海立</br>
    /// <br>                     PM1007・6次改良</br>
    /// <br>                     発行者チェック区分、入力倉庫チェック区分を追加</br>
    /// <br>Update Note      :   2010/05/14 工藤</br>
    /// <br>                     品名表示対応</br>
    /// <br>                     BLコード検索品名表示区分1～4、品番検索品名表示区分1～4、優良部品検索品名使用区分を追加</br>    
    /// <br>Update Note      :   2010/08/04 楊明俊</br>
    /// <br>                     PM1012</br>
    /// <br>                     小数点表示区分を追加</br>
    /// <br>Update Note      :   2011/06/07 22008 長内数馬</br>
    /// <br>                     販売区分表示区分を追加</br>
    /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫</br>
    /// <br>                     貸出仕入区分を追加</br>
    /// <br>Update Note      :   2012/12/27 脇田 靖之</br>
    /// <br>                     自社品番印字対応</br>
    /// <br>Update Note      :   2013/01/09 西 毅</br>
    /// <br>                     自社品番印字対応デフォルト値の変更</br>
    /// <br>Update Note      :   2013/01/15 FSI福原 一樹</br>
    /// <br>                     仕入返品予定機能区分を追加</br>
    /// <br>Update Note      :   2013/01/16 脇田 靖之</br>
    /// <br>                     自社品番印字対応仕様変更対応</br>
    /// <br>Update Note      :   2013/01/21 cheq</br>
    /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
    /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
    /// <br>Update Note      :   2013/02/05 脇田 靖之</br>
    /// <br>                     ＢＬコード０対応</br>
    /// <br>Update Note     :    2017/04/13 譚洪</br>
    /// <br>                     売上伝票入力画面の仕入担当者セット方法を変更</br>
    /// <br>                     仕入担当参照区分の追加</br>
    // ---------------------------------------------------------------------//
    /// </remarks>
	public class SalesTtlSt
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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        /// <remarks>オール０は全社</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/06 --------------------------------<<<<< 

		/// <summary>売上伝票発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _salesSlipPrtDiv;

		/// <summary>出荷伝票発行区分</summary>
		/// <remarks>0:する　1:しない</remarks>
		private Int32 _shipmSlipPrtDiv;

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// <summary>ゼロ円印刷区分</summary>
        ///// <remarks>0:する　1:しない　(ゼロ円明細の印字）</remarks>
        //private Int32 _zeroPrtDiv;
        // --- DEL 2008/07/22 --------------------------------<<<<< 

		/// <summary>出荷伝票単価印刷区分</summary>
		/// <remarks>0:しない　1:する</remarks>
		private Int32 _shipmSlipUnPrcPrtDiv;

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// <summary>入出荷数区分</summary>
        ///// <remarks>0:警告無し　1:警告  2:警告＋再入力(売上仕入同時入力の際の入荷数＜出荷数のチェック）</remarks>
        //private Int32 _ioGoodsCntDiv;

        ////----- ueno add ---------- start 2008.02.26
        ///// <summary>入出荷数区分２</summary>
        ///// <remarks>0:警告無し　1:警告  2:警告＋再入力(売上仕入同時入力の際の入荷数＜出荷数のチェック）</remarks>
        //private Int32 _ioGoodsCntDiv2;
        ////----- ueno add ---------- end 2008.02.26
        // --- DEL 2008/07/22 --------------------------------<<<<< 

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// <summary>売上形式初期値</summary>
        ///// <remarks>0:売上　1:出荷　(売仕入同時入力の初期値）</remarks>
        //private Int32 _salesFormalIn;

        ///// <summary>仕入明細確認</summary>
        ///// <remarks>0:任意　1:必須　（売仕入同時入力の仕入明細確認）</remarks>
        //private Int32 _stockDetailConf;
        // --- DEL 2008/07/22 --------------------------------<<<<< 

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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// <summary>見積データ計上残区分</summary>
        /// <remarks>0:残す　1:残さない</remarks>
        private Int32 _estmateAddUpRemDiv;
        // --- ADD 2008/06/06 --------------------------------<<<<< 

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

        // 2008.12.11 30413 犬飼 伝票修正区分の補足変更＋返品伝票修正区分の追加 >>>>>>START
		/// <summary>伝票修正区分（日付）</summary>
        ///// <remarks>0:可能　1:返品伝票以外可 2:返品伝票のみ可 1:不可</remarks>
        /// <remarks>0:可能　1:不可</remarks>
        private Int32 _slipChngDivDate;

		/// <summary>伝票修正区分（原価）</summary>
        ///// <remarks>0:可能　1:返品伝票以外可 2:返品伝票のみ可 1:不可</remarks>
        /// <remarks>0:可能　1:不可 2:未使用 3:在庫時不可</remarks>
        private Int32 _slipChngDivCost;

		/// <summary>伝票修正区分（売価）</summary>
        ///// <remarks>0:可能　1:返品伝票以外可 2:返品伝票のみ可 1:不可</remarks>
        /// <remarks>0:可能　1:不可 2:未使用 3:在庫時不可</remarks>
        private Int32 _slipChngDivUnPrc;

		/// <summary>伝票修正区分（定価）</summary>
        ///// <remarks>0:可能　1:不可　2:在庫がある場合修正不可　（返品伝票以外）</remarks>
        /// <remarks>0:可能　1:不可　（返品伝票以外）</remarks>
        private Int32 _slipChngDivLPrice;

        /// <summary>返品伝票修正区分（原価）</summary>
        /// <remarks>0:可能　1:不可 2:未使用 3:在庫時不可</remarks>
        private Int32 _retSlipChngDivCost;

        /// <summary>返品伝票修正区分（売価）</summary>
        /// <remarks>0:可能　1:不可 2:未使用 3:在庫時不可</remarks>
        private Int32 _retSlipChngDivUnPrc;
        // 2008.12.11 30413 犬飼 伝票修正区分の補足変更＋返品伝票修正区分の追加 <<<<<<END
		
		//----- ueno add ---------- start 2008.02.18
		/// <summary>自動入金金種コード</summary>
		/// <remarks>エントリでの自動入金の金種</remarks>
		private Int32 _autoDepoKindCode;

		/// <summary>自動入金金種名称</summary>
		/// <remarks>エントリでの自動入金の金種</remarks>
		private string _autoDepoKindName;

		/// <summary>自動入金金種区分</summary>
		/// <remarks>エントリでの自動入金の金種</remarks>
		private Int32 _autoDepoKindDivCd;
		//----- ueno add ---------- end 2008.02.18

		//----- ueno add ---------- start 2008.02.26
		/// <summary>値引名称</summary>
		/// <remarks>値引名称</remarks>
		private string _discountName;
		//----- ueno add ---------- end 2008.02.26

        // --- ADD 2008/06/06 -------------------------------->>>>>
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
        // --- ADD 2009/10/19 ----------<<<<<

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

        // 2008.12.11 30413 犬飼 倉庫(在庫)チェック区分の補足を修正 >>>>>>START
        /// <summary>倉庫チェック区分</summary>
        ///// <remarks>0:警告　1:無視</remarks>
        /// <remarks>0:無視 1:再入力 2:警告</remarks>
        private Int32 _warehouseChkDiv;
        // 2008.12.11 30413 犬飼 倉庫(在庫)チェック区分の補足を修正 <<<<<<END
        
        /// <summary>部品検索区分</summary>
        /// <remarks>0:部品検索,1:品番検索</remarks>
        private Int32 _partsSearchDivCd;

        /// <summary>粗利表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
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
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        // --- ADD 2008/07/22 -------------------------------->>>>>
        /// <summary>入力粗利チェック上限区分</summary>
        /// <remarks>0:再入力,1:警告,2:無視</remarks>
        private Int32 _inpGrsProfChkUppDiv;

        /// <summary>入力粗利チェック下限区分</summary>
        /// <remarks>0:再入力,1:警告,2:無視</remarks>
        private Int32 _inpGrsProfChkLowDiv;

        /// <summary>入力粗利チェック上限</summary>
        private Double _inpGrsProfChkUpper;

        /// <summary>入力粗利チェック下限</summary>
        private Double _inpGrsProfChkLower;
        // --- ADD 2008/07/22 --------------------------------<<<<< 

        // ADD 2008/09/29 不具合対応[5665]---------->>>>>
        /// <summary>優良代替条件区分</summary>
        /// <remarks>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</remarks>
        private int _prmSubstCondDivCd;

        /// <summary>代替適用区分</summary>
        /// <remarks>0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）</remarks>
        private int _substApplyDivCd;
        // ADD 2008/09/29 不具合対応[5665]----------<<<<<

        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
        /// <summary>品名表示区分</summary>
        /// <remarks>0:品名優先, 1:提供優先</remarks>
        private int _partsNameDspDivCd;
        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<

        // --- ADD 2010/04/30-------------------------------->>>>>
        /// <summary>自由検索部品自動登録区分</summary>
        /// <remarks>0:しない, 1:する</remarks>
        private int _frSrchPrtAutoEntDiv;
        // --- ADD 2010/04/30 --------------------------------<<<<<

        /// <summary>BLコード枝番区分</summary>
        /// <remarks>0:枝番なし, 1:枝番あり</remarks>
        private Int32 _bLGoodsCdDerivNoDiv;

        // --- ADD 2010/08/04 ---------->>>>>
        /// <summary>小数点表示区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _dwnPLCdSpDivCd;
        // --- ADD 2010/08/04 ----------<<<<<

        // --- ADD 2011/06/07 ---------->>>>>
        /// <summary>販売区分表示区分</summary>
        /// <remarks>0:する 1:しない 2:必須</remarks>
        private Int32 _salesCdDspDivCd;
        // --- ADD 2011/06/07 ----------<<<<<

        // --- ADD 2012/04/23 ---------->>>>>
        /// <summary>貸出仕入区分</summary>
        /// <remarks>0:しない 1:する 2:必須</remarks>
        private Int32 _rentStockDiv;
        // --- ADD 2012/04/23 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>自社品番印字区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _EpPartsNoPrtCd;

        /// <summary>自社品番付加文字</summary>
        private string _EpPartsNoAddChar = "";
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// <summary>印字品番初期値</summary>
        /// <remarks>0:優良　1:自社　2:無し</remarks>
        private Int32 _PrintGoodsNoDef;
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
        // --- ADD 2013/01/15 ---------->>>>>
        /// <summary>仕入返品予定機能区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _stockRetGoodsPlnDiv;
        // --- ADD 2013/01/15 ----------<<<<<
        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// <summary>自動入金備考区分</summary>
        /// <remarks>0:売上伝票番号 1:売上伝票備考 2:無し</remarks>
        private Int32 _autoDepositNoteDiv;
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// <summary>BLコード０対応</summary>
        /// <remarks>0:する　1:しない</remarks>
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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>オール０は全社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/06 --------------------------------<<<<< 

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

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// public propaty name  :  ZeroPrtDiv
        ///// <summary>ゼロ円印刷区分プロパティ</summary>
        ///// <value>0:する　1:しない　(ゼロ円明細の印字）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ゼロ円印刷区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 ZeroPrtDiv
        //{
        //    get{return _zeroPrtDiv;}
        //    set{_zeroPrtDiv = value;}
        //}
        // --- DEL 2008/07/22 --------------------------------<<<<< 

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

        // --- DEL 2008/07/22 -------------------------------->>>>>
        ///// public propaty name  :  IoGoodsCntDiv
        ///// <summary>入出荷数区分プロパティ</summary>
        ///// <value>0:警告無し　1:警告  2:警告＋再入力(売上仕入同時入力の際の入荷数＜出荷数のチェック）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   入出荷数区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 IoGoodsCntDiv
        //{
        //    get{return _ioGoodsCntDiv;}
        //    set{_ioGoodsCntDiv = value;}
        //}

        ////----- ueno add ---------- start 2008.02.26
        ///// public propaty name  :  IoGoodsCntDiv2
        ///// <summary>入出荷数区分２プロパティ</summary>
        ///// <value>0:警告無し　1:警告  2:警告＋再入力(売上仕入同時入力の際の入荷数＜出荷数のチェック）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   入出荷数区分プロパティ２</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 IoGoodsCntDiv2
        //{
        //    get { return _ioGoodsCntDiv2; }
        //    set { _ioGoodsCntDiv2 = value; }
        //}
        ////----- ueno add ---------- end 2008.02.26

        ///// public propaty name  :  SalesFormalIn
        ///// <summary>売上形式初期値プロパティ</summary>
        ///// <value>0:売上　1:出荷　(売仕入同時入力の初期値）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   売上形式初期値プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 SalesFormalIn
        //{
        //    get{return _salesFormalIn;}
        //    set{_salesFormalIn = value;}
        //}

        ///// public propaty name  :  StockDetailConf
        ///// <summary>仕入明細確認プロパティ</summary>
        ///// <value>0:任意　1:必須　（売仕入同時入力の仕入明細確認）</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   仕入明細確認プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 StockDetailConf
        //{
        //    get{return _stockDetailConf;}
        //    set{_stockDetailConf = value;}
        //}
        // --- DEL 2008/07/22 --------------------------------<<<<< 

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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// public propaty name  :  EstmateAddUpRemDiv
        /// <summary>見積データ計上残区分プロパティ</summary>
        /// <value>0:残す　1:残さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積データ計上残区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 EstmateAddUpRemDiv
        {
            get { return _estmateAddUpRemDiv; }
            set { _estmateAddUpRemDiv = value; }
        }
        // --- ADD 2008/06/06 --------------------------------<<<<< 

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

        // 2008.12.11 30413 犬飼 伝票修正区分の補足変更＋返品伝票修正区分の追加 >>>>>>START
        /// public propaty name  :  SlipChngDivDate
		/// <summary>伝票修正区分（日付）プロパティ</summary>
        ///// <value>0:可能　1:返品伝票以外可 2:返品伝票のみ可 1:不可</value>
        /// <value>0:可能　1:不可</value>
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
        ///// <value>0:可能　1:返品伝票以外可 2:返品伝票のみ可 1:不可</value>
        /// <value>0:可能　1:不可 2:未使用 3:在庫時不可</value>
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
        ///// <value>0:可能　1:返品伝票以外可 2:返品伝票のみ可 1:不可</value>
        /// <value>0:可能　1:不可 2:未使用 3:在庫時不可</value>
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
        ///// <value>0:可能　1:不可　2:在庫がある場合修正不可　（返品伝票以外）</value>
        /// <value>0:可能　1:不可　（返品伝票以外）</value>
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

        /// public propaty name  :  RetSlipChngDivCost
        /// <summary>返品伝票修正区分（原価）プロパティ</summary>
        /// <value>0:可能　1:不可 2:未使用 3:在庫時不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品伝票修正区分（原価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetSlipChngDivCost
        {
            get { return _retSlipChngDivCost; }
            set { _retSlipChngDivCost = value; }
        }

        /// public propaty name  :  RetSlipChngDivUnPrc
        /// <summary>返品伝票修正区分（売価）プロパティ</summary>
        /// <value>0:可能　1:不可 2:未使用 3:在庫時不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品伝票修正区分（売価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetSlipChngDivUnPrc
        {
            get { return _retSlipChngDivUnPrc; }
            set { _retSlipChngDivUnPrc = value; }
        }
        // 2008.12.11 30413 犬飼 伝票修正区分の補足変更＋返品伝票修正区分の追加 <<<<<<END
		
		//----- ueno add ---------- start 2008.02.18
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
			get { return _autoDepoKindCode; }
			set { _autoDepoKindCode = value; }
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
			get { return _autoDepoKindName; }
			set { _autoDepoKindName = value; }
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
			get { return _autoDepoKindDivCd; }
			set { _autoDepoKindDivCd = value; }
		}
		//----- ueno add ---------- end 2008.02.18
		
		//----- ueno add ---------- start 2008.02.26
		/// public propaty name  :  DiscountName
		/// <summary>値引名称プロパティ</summary>
		/// <value>値引名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   値引名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DiscountName
		{
			get { return _discountName; }
			set { _discountName = value; }
		}
		//----- ueno add ---------- end 2008.02.26

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// public propaty name  :  InpAgentDispDiv
        /// <summary>発行者表示区分プロパティ</summary>
        /// <value>0:する　1:しない　 2:必須　（無しの場合、画面項目を非表示) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 InpAgentDispDiv
        {
            get { return _inpAgentDispDiv; }
            set { _inpAgentDispDiv = value; }
        }

        /// public propaty name  :  CustOrderNoDispDiv
        /// <summary>得意先注番表示区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先注番表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustOrderNoDispDiv
        {
            get { return _custOrderNoDispDiv; }
            set { _custOrderNoDispDiv = value; }
        }

        /// public propaty name  :  CarMngNoDispDiv
        /// <summary>車輌管理番号表示区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理番号表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CarMngNoDispDiv
        {
            get { return _carMngNoDispDiv; }
            set { _carMngNoDispDiv = value; }
        }

        // --- ADD 2009/10/19 ---------->>>>>
        /// public propaty name  :  PriceSelectDispDiv
        /// <summary>表示区分プロセスプロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロセスプロパティ</br>
        /// <br>Programer        :   朱俊成</br>
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
        /// <br>Programer        :   李侠</br>
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
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 BrSlipNote3DispDiv
        {
            get { return _brSlipNote3DispDiv; }
            set { _brSlipNote3DispDiv = value; }
        }

        /// public propaty name  :  SlipDateClrDivCd
        /// <summary>伝票日付クリア区分プロパティ</summary>
        /// <value>0:システム日付 1:入力日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票日付クリア区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SlipDateClrDivCd
        {
            get { return _slipDateClrDivCd; }
            set { _slipDateClrDivCd = value; }
        }

        /// public propaty name  :  AutoEntryGoodsDivCd
        /// <summary>商品自動登録プロパティ</summary>
        /// <value>0:なし　1:あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品自動登録プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 AutoEntryGoodsDivCd
        {
            get { return _autoEntryGoodsDivCd; }
            set { _autoEntryGoodsDivCd = value; }
        }

        /// public propaty name  :  CostCheckDivCd
        /// <summary>原価チェック区分プロパティ</summary>
        /// <value>0:無視　1:再入力　2:警告MSG　（定価＜単価の場合）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価チェック区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CostCheckDivCd
        {
            get { return _costCheckDivCd; }
            set { _costCheckDivCd = value; }
        }

        /// public propaty name  :  JoinInitDispDiv
        /// <summary>結合初期表示区分プロパティ</summary>
        /// <value>0:表示順 1:在庫順</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合初期表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 JoinInitDispDiv
        {
            get { return _joinInitDispDiv; }
            set { _joinInitDispDiv = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>自動入金区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動入金区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        /// public propaty name  :  SubstCondDivCd
        /// <summary>代替条件区分プロパティ</summary>
        /// <value>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替条件区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SubstCondDivCd
        {
            get { return _substCondDivCd; }
            set { _substCondDivCd = value; }
        }

        /// public propaty name  :  SlipCreateProcess
        /// <summary>伝票作成方法プロパティ</summary>
        /// <value>0:入力順 1:在庫別 2:倉庫別 3:出力先別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票作成方法プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SlipCreateProcess
        {
            get { return _slipCreateProcess; }
            set { _slipCreateProcess = value; }
        }

        /// public propaty name  :  WarehouseChkDiv
        /// <summary>倉庫チェック区分プロパティ</summary>
        /// <value>0:警告　1:無視</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫チェック区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 WarehouseChkDiv
        {
            get { return _warehouseChkDiv; }
            set { _warehouseChkDiv = value; }
        }

        /// public propaty name  :  PartsSearchDivCd
        /// <summary>部品検索区分プロパティ</summary>
        /// <value>0:部品検索,1:品番検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PartsSearchDivCd
        {
            get { return _partsSearchDivCd; }
            set { _partsSearchDivCd = value; }
        }

        /// public propaty name  :  GrsProfitDspCd
        /// <summary>粗利表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 GrsProfitDspCd
        {
            get { return _grsProfitDspCd; }
            set { _grsProfitDspCd = value; }
        }

        /// public propaty name  :  PartsSearchPriDivCd
        /// <summary>部品検索優先順区分プロパティ</summary>
        /// <value>0:純正　1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索優先順区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PartsSearchPriDivCd
        {
            get { return _partsSearchPriDivCd; }
            set { _partsSearchPriDivCd = value; }
        }

        /// public propaty name  :  SalesStockDiv
        /// <summary>売上仕入区分プロパティ</summary>
        /// <value>0:しない　1:する　2:必須入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上仕入区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SalesStockDiv
        {
            get { return _salesStockDiv; }
            set { _salesStockDiv = value; }
        }

        /// public propaty name  :  PrtBLGoodsCodeDiv
        /// <summary>印刷用BL商品コード区分プロパティ</summary>
        /// <value>0:部品,1:検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用BL商品コード区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 PrtBLGoodsCodeDiv
        {
            get { return _prtBLGoodsCodeDiv; }
            set { _prtBLGoodsCodeDiv = value; }
        }

        /// public propaty name  :  SectDspDivCd
        /// <summary>拠点表示区分プロパティ</summary>
        /// <value>0:標準　1:自拠点　2:表示無し　※標準は 得意先の管理拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SectDspDivCd
        {
            get { return _sectDspDivCd; }
            set { _sectDspDivCd = value; }
        }

        /// public propaty name  :  GoodsNmReDispDivCd
        /// <summary>商品名再表示区分プロパティ</summary>
        /// <value>0:しない　1:する ※BLｺｰﾄﾞ変更時にBL名称で上書き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名再表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 GoodsNmReDispDivCd
        {
            get { return _goodsNmReDispDivCd; }
            set { _goodsNmReDispDivCd = value; }
        }

        /// public propaty name  :  CostDspDivCd
        /// <summary>原価表示区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価表示区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CostDspDivCd
        {
            get { return _costDspDivCd; }
            set { _costDspDivCd = value; }
        }

        /// public propaty name  :  DepoSlipDateClrDiv
        /// <summary>入金伝票日付クリア区分プロパティ</summary>
        /// <value>0:システム日付 1:入力日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票日付クリア区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DepoSlipDateClrDiv
        {
            get { return _depoSlipDateClrDiv; }
            set { _depoSlipDateClrDiv = value; }
        }

        /// public propaty name  :  DepoSlipDateAmbit
        /// <summary>入金伝票日付範囲区分プロパティ</summary>
        /// <value>0:制限なし 1:システム日付以降入力不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票日付範囲区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DepoSlipDateAmbit
        {
            get { return _depoSlipDateAmbit; }
            set { _depoSlipDateAmbit = value; }
        }
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        // --- ADD 2008/07/22 -------------------------------->>>>>
        /// public propaty name  :  InpGrsProfChkUppDiv
        /// <summary>入力粗利チェック上限区分プロパティ</summary>
        /// <value>0:再入力,1:警告,2:無視</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力粗利チェック上限区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 InpGrsProfChkUppDiv
        {
            get { return _inpGrsProfChkUppDiv; }
            set { _inpGrsProfChkUppDiv = value; }
        }

        /// public propaty name  :  InpGrsPrfChkLowDiv
        /// <summary>入力粗利チェック下限区分プロパティ</summary>
        /// <value>0:再入力,1:警告,2:無視</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力粗利チェック下限区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 InpGrsProfChkLowDiv
        {
            get { return _inpGrsProfChkLowDiv; }
            set { _inpGrsProfChkLowDiv = value; }
        }

        /// public propaty name  :  InpGrsProfChkUpper
        /// <summary>入力粗利チェック上限プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力粗利チェック上限プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Double InpGrsProfChkUpper
        {
            get { return _inpGrsProfChkUpper; }
            set { _inpGrsProfChkUpper = value; }
        }

        /// public propaty name  :  InpGrsProfChkLower
        /// <summary>入力粗利チェック下限プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力粗利チェック下限プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Double InpGrsProfChkLower
        {
            get { return _inpGrsProfChkLower; }
            set { _inpGrsProfChkLower = value; }
        }
        // --- ADD 2008/07/22 --------------------------------<<<<< 

        // ADD 2008/09/29 不具合対応[5665]---------->>>>>
        /// <summary>
        /// 優良代替条件区分プロパティ
        /// </summary>
        /// <remarks>
        /// 0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）
        /// </remarks>
        public int PrmSubstCondDivCd
        {
            get { return _prmSubstCondDivCd; }
            set { _prmSubstCondDivCd = value; }
        }

        /// <summary>
        /// 代替適用区分プロパティ
        /// </summary>
        /// <remarks>
        /// 0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）
        /// </remarks>
        public int SubstApplyDivCd
        {
            get { return _substApplyDivCd; }
            set { _substApplyDivCd = value; }
        }
        // ADD 2008/09/29 不具合対応[5665]----------<<<<<

        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
        /// <summary>
        /// 品名表示区分プロパティ
        /// </summary>
        /// <remarks>0:品名優先, 1:提供優先</remarks>
        public int PartsNameDspDivCd
        {
            get { return _partsNameDspDivCd; }
            set { _partsNameDspDivCd = value; }
        }
        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<

        // --- ADD 2010/04/30-------------------------------->>>>>
        /// <summary>
        /// 自由検索部品自動登録区分プロパティ
        /// </summary>
        /// <remarks>0:しない, 1:する</remarks>
        public int FrSrchPrtAutoEntDiv
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

        // --- ADD 2010/08/04 ---------->>>>>
        /// public propaty name  :  DwnPLCdSpDivCd
        /// <summary>小数点表示区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   小数点表示区分プロパティ</br>
        /// <br>Programer        :   楊明俊</br>
        /// </remarks>
        public Int32 DwnPLCdSpDivCd
        {
            get { return _dwnPLCdSpDivCd; }
            set { _dwnPLCdSpDivCd = value; }
        }
        // --- ADD 2010/08/04 ----------<<<<<

        // --- ADD 2011/06/07 ---------->>>>>
        /// public propaty name  :  SalesCdDspDivCd
        /// <summary>販売区分表示区分プロパティ</summary>
        /// <value>0:する 1:しない 2:必須</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分表示区分プロパティ</br>
        /// <br>Programer        :   長内数馬</br>
        /// </remarks>
        public Int32 SalesCdDspDivCd
        {
            get { return _salesCdDspDivCd; }
            set { _salesCdDspDivCd = value; }
        }
        // --- ADD 2011/06/07 ----------<<<<<

        // --- ADD 2012/04/23 ---------->>>>>
        /// public propaty name  :  RentStockDiv
        /// <summary>貸出仕入区分プロパティ</summary>
        /// <value>0:しない 1:する 2:必須</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出仕入区分プロパティ</br>
        /// <br>Programer        :   福田康夫</br>
        /// </remarks>
        public Int32 RentStockDiv
        {
            get { return _rentStockDiv; }
            set { _rentStockDiv = value; }
        }
        // --- ADD 2012/04/23 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// public propaty name  :  EpPartsNoPrtCd
        /// <summary>自社品番印字区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社品番印字区分プロパティ</br>
        /// <br>Programer        :   脇田靖之</br>
        /// </remarks>
        public Int32 EpPartsNoPrtCd
        {
            get { return _EpPartsNoPrtCd; }
            set { _EpPartsNoPrtCd = value; }
        }

        /// public propaty name  :  EpPartsNoAddChar
        /// <summary>自社品番付加文字プロパティ</summary>
        /// <value>自社品番付加文字名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社品番付加文字プロパティ</br>
        /// <br>Programer        :   脇田靖之</br>
        /// </remarks>
        public string EpPartsNoAddChar
        {
            get { return _EpPartsNoAddChar; }
            set { _EpPartsNoAddChar = value; }
        }
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// public propaty name  :  PrintGoodsNoDef
        /// <summary>印字品番初期値プロパティ</summary>
        /// <value>0:優良 1:自社 2:無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印字品番初期値プロパティ</br>
        /// <br>Programer        :   脇田靖之</br>
        /// </remarks>
        public Int32 PrintGoodsNoDef
        {
            get { return _PrintGoodsNoDef; }
            set { _PrintGoodsNoDef = value; }
        }
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
        // --- ADD 2013/01/15 ---------->>>>>
        /// <summary>仕入返品予定機能区分</summary>
        /// <remarks>0:無効　1:有効</remarks>
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
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード０対応プロパティ</br>
        /// <br>Programer        :   脇田靖之</br>
        /// </remarks>
        public Int32 BLGoodsCdZeroSuprt
        {
            get { return _BLGoodsCdZeroSuprt; }
            set { _BLGoodsCdZeroSuprt = value; }
        }

        /// public propaty name  :  BLGoodsCdChange
        /// <summary>変換コードプロパティ</summary>
        /// <value>変換コード名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換コードプロパティ</br>
        /// <br>Programer        :   脇田靖之</br>
        /// </remarks>
        public Int32 BLGoodsCdChange
        {
            get { return _BLGoodsCdChange; }
            set { _BLGoodsCdChange = value; }
        }

        // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
        /// public propaty name  :  StockEmpRefDiv
        /// <summary>仕入担当参照区分プロパティ</summary>
        /// <value>仕入担当参照区分名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当参照区分プロパティ</br>
        /// <br>Programer        :   譚洪</br>
        /// </remarks>
        public Int32 StockEmpRefDiv
        {
            get { return _stockEmpRefDiv; }
            set { _stockEmpRefDiv = value; }
        }
        // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<


        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
        /// <summary>
		/// 売上全体設定マスタコンストラクタ
		/// </summary>
		/// <returns>SalesTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesTtlSt()
		{
		}

		/// <summary>
		/// 売上全体設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="salesSlipPrtDiv">拠点コード(オール0は全社)</param>
        /// <param name="salesSlipPrtDiv">売上伝票発行区分</param>
		/// <param name="shipmSlipPrtDiv">出荷伝票発行区分</param>
		/// <param name="zeroPrtDiv">ゼロ円印刷区分</param>
		/// <param name="shipmSlipUnPrcPrtDiv">出荷伝票単価印刷区分</param>
		/// <param name="ioGoodsCntDiv">入出荷数区分</param>
		/// <param name="ioGoodsCntDiv2">入出荷数区分２</param>
		/// <param name="salesFormalIn">売上形式初期値</param>
		/// <param name="stockDetailConf">仕入明細確認</param>
		/// <param name="grsProfitCheckLower">粗利チェック下限</param>
		/// <param name="grsProfitCheckBest">粗利チェック適正</param>
		/// <param name="grsProfitCheckUpper">粗利チェック上限</param>
		/// <param name="grsProfitChkLowSign">粗利チェック下限記号</param>
		/// <param name="grsProfitChkBestSign">粗利チェック適正記号</param>
		/// <param name="grsProfitChkUprSign">粗利チェック上限記号</param>
		/// <param name="grsProfitChkMaxSign">粗利チェック最大記号</param>
		/// <param name="salesAgentChngDiv">売上担当変更区分</param>
		/// <param name="acpOdrAgentDispDiv">受注者表示区分</param>
		/// <param name="brSlipNote2DispDiv">伝票備考２表示区分</param>
		/// <param name="dtlNoteDispDiv">明細備考表示区分</param>
		/// <param name="unPrcNonSettingDiv">売価未設定時区分</param>
        /// <param name="unPrcNonSettingDiv">見積データ計上残区分（0:残す　1:残さない）</param>
		/// <param name="acpOdrrAddUpRemDiv">受注データ計上残区分</param>
		/// <param name="shipmAddUpRemDiv">出荷データ計上残区分</param>
		/// <param name="retGoodsStockEtyDiv">返品時在庫登録区分</param>
		/// <param name="listPriceSelectDiv">定価選択区分</param>
		/// <param name="makerInpDiv">メーカー入力区分</param>
		/// <param name="bLGoodsCdInpDiv">BL商品コード入力区分</param>
		/// <param name="supplierInpDiv">仕入先入力区分</param>
		/// <param name="supplierSlipDelDiv">仕入伝票削除区分</param>
		/// <param name="custGuideDispDiv">得意先ガイド初期表示区分</param>
		/// <param name="slipChngDivDate">伝票修正区分（日付）</param>
		/// <param name="slipChngDivCost">伝票修正区分（原価）</param>
		/// <param name="slipChngDivUnPrc">伝票修正区分（売価）</param>
		/// <param name="slipChngDivLPrice">伝票修正区分（定価）</param>
		/// <param name="autoDepoKindCode">自動入金金種コード</param>
		/// <param name="autoDepoKindName">自動入金金種名称</param>
		/// <param name="autoDepoKindDivCd">自動入金金種区分</param>
		/// <param name="discountName">値引名称</param>
        /// <param name="InpAgentDispDiv">発行者表示区分（0:する　1:しない　 2:必須　（無しの場合、画面項目を非表示) ）</param>
        /// <param name="CustOrderNoDispDiv">得意先注番表示区分（0:しない　1:する）</param>
        /// <param name="CarMngNoDispDiv">車輌管理番号表示区分（0:しない　1:する）</param>
        /// <param name="PriceSelectDispDiv">表示区分プロセス（0:しない　1:する）</param>
        /// <param name="BrSlipNote3DispDiv">伝票備考３表示区分（0:する　1:しない　（無しの場合、画面項目を非表示) ）</param>
        /// <param name="SlipDateClrDivCd">伝票日付クリア区分（0:システム日付 1:入力日付）</param>
        /// <param name="AutoEntryGoodsDivCd">商品自動登録（0:なし　1:あり）</param>
        /// <param name="CostCheckDivCd">原価チェック区分（0:無視　1:再入力　2:警告MSG　（定価＜単価の場合））</param>
        /// <param name="JoinInitDispDiv">結合初期表示区分（0:表示順 1:在庫順）</param>
        /// <param name="AutoDepositCd">自動入金区分（0:しない,1:する）</param>
        /// <param name="SubstCondDivCd">代替条件区分（0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視））</param>
        /// <param name="SlipCreateProcess">伝票作成方法（0:入力順 1:在庫別 2:倉庫別 3:出力先別）</param>
        /// <param name="WarehouseChkDiv">倉庫チェック区分（0:警告　1:無視）</param>
        /// <param name="PartsSearchDivCd">部品検索区分（0:部品検索,1:品番検索）</param>
        /// <param name="GrsProfitDspCd">粗利表示区分（0:する 1:しない）</param>
        /// <param name="PartsSearchPriDivCd">部品検索優先順区分（0:純正　1:優良）</param>
        /// <param name="SalesStockDiv">売上仕入区分（0:しない　1:する　2:必須入力）</param>
        /// <param name="PrtBLGoodsCodeDiv">印刷用BL商品コード区分（0:部品,1:検索）</param>
        /// <param name="SectDspDivCd">拠点表示区分（0:標準　1:自拠点　2:表示無し　※標準は 得意先の管理拠点）</param>
        /// <param name="GoodsNmReDispDivCd">商品名再表示区分（0:しない　1:する ※BLｺｰﾄﾞ変更時にBL名称で上書き）</param>
        /// <param name="CostDspDivCd">原価表示区分（0:しない 1:する）</param>
        /// <param name="DepoSlipDateClrDiv">入金伝票日付クリア区分（0:システム日付 1:入力日付）</param>
        /// <param name="DepoSlipDateAmbit">入金伝票日付範囲区分（0:制限なし 1:システム日付以降入力不可）</param>
        /// <param name="InpGrsProfChkLower">入力粗利チェック下限</param>
        /// <param name="InpGrsProfChkUpper">入力粗利チェック上限</param>
        /// <param name="InpGrsPrfChkLowDiv">入力粗利チェック下限区分（0:再入力,1:警告,2:無視）</param>
        /// <param name="InpGrsProfChkUppDiv">入力粗利チェック上限区分（0:再入力,1:警告,2:無視）</param>
        /// <param name="bLGoodsCdDerivNoDiv">BLコード枝番</param>
        /// <param name="autoDepositNoteDiv">自動入金備考区分（0:売上伝票番号 1:売上伝票備考 2:無し）</param> // ADD cheq 2013/01/21 Redmine#33797 
        /// <returns>SalesTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号         :   11370030-00 2017/04/13 譚洪</br>
        /// <br>                     Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		public SalesTtlSt(	DateTime createDateTime,
							DateTime updateDateTime,
							string enterpriseCode,
							Guid fileHeaderGuid,
							string updEmployeeCode,
							string updAssemblyId1,
							string updAssemblyId2,
							Int32 logicalDeleteCode,
			                string sectionCode,			// ADD 2008/06/06
							Int32 salesSlipPrtDiv,
							Int32 shipmSlipPrtDiv,
							//Int32 zeroPrtDiv,         // DEL 2008/07/22
							Int32 shipmSlipUnPrcPrtDiv,
                            // --- DEL 2008/07/22 -------------------------------->>>>>
                            //Int32 ioGoodsCntDiv,
                            ////----- ueno add ---------- start 2008.02.26
                            //Int32 ioGoodsCntDiv2,
                            ////----- ueno add ---------- end 2008.02.26
                            //Int32 salesFormalIn,
                            //Int32 stockDetailConf,
                            // --- DEL 2008/07/22 --------------------------------<<<<< 
							Double grsProfitCheckLower,
							Double grsProfitCheckBest,
							Double grsProfitCheckUpper,
							string grsProfitChkLowSign,
							string grsProfitChkBestSign,
							string grsProfitChkUprSign,
							string grsProfitChkMaxSign,
							Int32 salesAgentChngDiv,
							Int32 acpOdrAgentDispDiv,
							Int32 brSlipNote2DispDiv,
							Int32 dtlNoteDispDiv,
							Int32 unPrcNonSettingDiv,
                            Int32 estmateAddUpRemDiv,  // ADD 2008/06/06
							Int32 acpOdrrAddUpRemDiv,
							Int32 shipmAddUpRemDiv,
							Int32 retGoodsStockEtyDiv,
							Int32 listPriceSelectDiv,
							Int32 makerInpDiv,
							Int32 bLGoodsCdInpDiv,
							Int32 supplierInpDiv,
							Int32 supplierSlipDelDiv,
							Int32 custGuideDispDiv,
							Int32 slipChngDivDate,
							Int32 slipChngDivCost,
							Int32 slipChngDivUnPrc,
							Int32 slipChngDivLPrice,
                            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
                            Int32 retSlipChngDivCost,
                            Int32 retSlipChngDivUnPrc,
                            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
                            //----- ueno add ---------- start 2008.02.18
							Int32 autoDepoKindCode,
							string autoDepoKindName,
							Int32 autoDepoKindDivCd,
							//----- ueno add ---------- end 2008.02.18
							//----- ueno add ---------- start 2008.02.26
							string discountName,
							//----- ueno add ---------- end 2008.02.26

                            // --- ADD 2008/06/06 -------------------------------->>>>>
                            Int32 inpAgentDispDiv,
                            Int32 custOrderNoDispDiv,
                            Int32 carMngNoDispDiv,
                            // --- ADD 2009/10/19 ---------->>>>>
                            Int32 priceSelectDispDiv,
                            // --- ADD 2009/10/19 ----------<<<<<
                            Int32 acpOdrInputDiv,        // ADD 2010/01/29 受注数入力を追加
                            Int32 inpAgentChkDiv,        // ADD 2010/05/04 発行者チェック区分を追加
                            Int32 inpWarehChkDiv,        // ADD 2010/05/04 入力倉庫チェック区分を追加
                            Int32 brSlipNote3DispDiv,
                            Int32 slipDateClrDivCd,
                            Int32 autoEntryGoodsDivCd,
                            Int32 costCheckDivCd,
                            Int32 joinInitDispDiv,
                            Int32 autoDepositCd,
                            Int32 autoDepositNoteDiv,    // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797 
                            Int32 substCondDivCd,
                            Int32 slipCreateProcess,
                            Int32 warehouseChkDiv,
                            Int32 partsSearchDivCd,
                            Int32 grsProfitDspCd,
                            Int32 partsSearchPriDivCd,
                            Int32 salesStockDiv,
                            Int32 prtBLGoodsCodeDiv,
                            Int32 sectDspDivCd,
                            Int32 goodsNmReDispDivCd,
                            Int32 costDspDivCd,
                            Int32 depoSlipDateClrDiv,
                            Int32 depoSlipDateAmbit,
                            // --- ADD 2008/06/06 --------------------------------<<<<< 

                            // --- ADD 2008/07/22 -------------------------------->>>>>
                            Double inpGrsProfChkLower,
                            Double inpGrsProfChkUpper,
                            Int32 inpGrsPrfChkLowDiv,
                            Int32 inpGrsProfChkUppDiv,
                            // --- ADD 2008/07/22 --------------------------------<<<<<
                            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
                            int prmSubstCondDivCd,
                            int substApplyDivCd,
                            // ADD 2008/09/29 不具合対応[5665]----------<<<<<
                            int partsNameDspDivCd,   // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
                            int frSrchPrtAutoEntDiv,   // ADD 2010/04/30
                            Int32 bLGoodsCdDerivNoDiv

                            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
                            , int blCdPrtsNmDspDivCd1
                            , int blCdPrtsNmDspDivCd2
                            , int blCdPrtsNmDspDivCd3
                            , int blCdPrtsNmDspDivCd4
                            , int gdNoPrtsNmDspDivCd1
                            , int gdNoPrtsNmDspDivCd2
                            , int gdNoPrtsNmDspDivCd3
                            , int gdNoPrtsNmDspDivCd4
                            , int prmPrtsNmUseDivCd
                             // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<

                            // --- ADD 2010/08/04 ---------->>>>>
                            , Int32 dwnPLCdSpDivCd
                            // --- ADD 2010/08/04 ----------<<<<<
                            // --- ADD 2011/06/07 ---------->>>>>
                            , Int32 salesCdDspDivCd
                            // --- ADD 2011/06/07 ----------<<<<<
                            // --- ADD 2012/04/23 ---------->>>>>
                            , Int32 rentStockDiv
                            // --- ADD 2012/04/23 ----------<<<<<
                            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                            , Int32 EpPartsNoPrtCd
                            , string EpPartsNoAddChar
                            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                            , Int32 PrintGoodsNoDef
                            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                            // --- ADD 2013/01/15 ---------->>>>>
                            , Int32 StockRetGoodsPlnDiv
                            // --- ADD 2013/01/15 ----------<<<<<
                            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                            , Int32 BLGoodsCdZeroSuprt
                            , Int32 BLGoodsCdChange
                            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
                            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
                            , Int32 stockEmpRefDiv
                            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
                           )      
		{
			this.CreateDateTime		= createDateTime;
			this.UpdateDateTime		= updateDateTime;
			this._enterpriseCode	= enterpriseCode;
			this._fileHeaderGuid	= fileHeaderGuid;
			this._updEmployeeCode	= updEmployeeCode;
			this._updAssemblyId1	= updAssemblyId1;
			this._updAssemblyId2	= updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode       = sectionCode;  // ADD 2008/06/06
			this._salesSlipPrtDiv	= salesSlipPrtDiv;
			this._shipmSlipPrtDiv	= shipmSlipPrtDiv;
			//this._zeroPrtDiv		= zeroPrtDiv;               // DEL 2008/07/22
			this._shipmSlipUnPrcPrtDiv = shipmSlipUnPrcPrtDiv;
            //this._ioGoodsCntDiv		= ioGoodsCntDiv;        // DEL 2008/07/22

            // --- DEL 2008/07/22 -------------------------------->>>>>
            ////----- ueno add ---------- start 2008.02.26
            //this._ioGoodsCntDiv2 = ioGoodsCntDiv2;
            ////----- ueno add ---------- end 2008.02.26
            //this._salesFormalIn		= salesFormalIn;
            //this._stockDetailConf	= stockDetailConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			this._grsProfitCheckLower	= grsProfitCheckLower;
			this._grsProfitCheckBest	= grsProfitCheckBest;
			this._grsProfitCheckUpper	= grsProfitCheckUpper;
			this._grsProfitChkLowSign	= grsProfitChkLowSign;
			this._grsProfitChkBestSign	= grsProfitChkBestSign;
			this._grsProfitChkUprSign	= grsProfitChkUprSign;
			this._grsProfitChkMaxSign	= grsProfitChkMaxSign;
			this._salesAgentChngDiv		= salesAgentChngDiv;
			this._acpOdrAgentDispDiv	= acpOdrAgentDispDiv;
			this._brSlipNote2DispDiv	= brSlipNote2DispDiv;
			this._dtlNoteDispDiv		= dtlNoteDispDiv;
			this._unPrcNonSettingDiv	= unPrcNonSettingDiv;
            this._estmateAddUpRemDiv    = estmateAddUpRemDiv;  // ADD 2008/06/06
			this._acpOdrrAddUpRemDiv	= acpOdrrAddUpRemDiv;
			this._shipmAddUpRemDiv		= shipmAddUpRemDiv;
			this._retGoodsStockEtyDiv	= retGoodsStockEtyDiv;
			this._listPriceSelectDiv	= listPriceSelectDiv;
			this._makerInpDiv			= makerInpDiv;
			this._bLGoodsCdInpDiv		= bLGoodsCdInpDiv;
			this._supplierInpDiv		= supplierInpDiv;
			this._supplierSlipDelDiv	= supplierSlipDelDiv;
			this._custGuideDispDiv		= custGuideDispDiv;
			this._slipChngDivDate		= slipChngDivDate;
			this._slipChngDivCost		= slipChngDivCost;
			this._slipChngDivUnPrc		= slipChngDivUnPrc;
			this._slipChngDivLPrice		= slipChngDivLPrice;
            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
            this._retSlipChngDivCost = retSlipChngDivCost;
            this._retSlipChngDivUnPrc = retSlipChngDivUnPrc;
            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
            //----- ueno add ---------- start 2008.02.18
			this._autoDepoKindCode	= autoDepoKindCode;
			this._autoDepoKindName	= autoDepoKindName;
			this._autoDepoKindDivCd = autoDepoKindDivCd;
			//----- ueno add ---------- end 2008.02.18
			//----- ueno add ---------- start 2008.02.26
			this._discountName = discountName;
			//----- ueno add ---------- end 2008.02.26

            // --- ADD 2008/06/06 -------------------------------->>>>>
			this._inpAgentDispDiv = inpAgentDispDiv;
			this._custOrderNoDispDiv = custOrderNoDispDiv;
			this._carMngNoDispDiv = carMngNoDispDiv;
            // --- ADD 2009/10/19 ---------->>>>>
            this._priceSelectDispDiv = priceSelectDispDiv;
            // --- ADD 2009/10/19 ----------<<<<<
            this._acpOdrInputDiv = acpOdrInputDiv;           // ADD 2010/01/29 受注数入力を追加
            this._inpAgentChkDiv = inpAgentChkDiv;           // ADD 2010/05/04 発行者チェック区分を追加
            this._inpWarehChkDiv = inpWarehChkDiv;           // ADD 2010/05/04 入力倉庫チェック区分を追加
			this._brSlipNote3DispDiv = brSlipNote3DispDiv;
			this._slipDateClrDivCd = slipDateClrDivCd;
			this._autoEntryGoodsDivCd = autoEntryGoodsDivCd;
			this._costCheckDivCd = costCheckDivCd;
			this._joinInitDispDiv = joinInitDispDiv;
			this._autoDepositCd = autoDepositCd;
            this._autoDepositNoteDiv = autoDepositNoteDiv;   // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797 
			this._substCondDivCd = substCondDivCd;
			this._slipCreateProcess = slipCreateProcess;
			this._warehouseChkDiv = warehouseChkDiv;
			this._partsSearchDivCd = partsSearchDivCd;
			this._grsProfitDspCd = grsProfitDspCd;
			this._partsSearchPriDivCd = partsSearchPriDivCd;
			this._salesStockDiv = salesStockDiv;
			this._prtBLGoodsCodeDiv = prtBLGoodsCodeDiv;
			this._sectDspDivCd = sectDspDivCd;
			this._goodsNmReDispDivCd = goodsNmReDispDivCd;
			this._costDspDivCd = costDspDivCd;
			this._depoSlipDateClrDiv = depoSlipDateClrDiv;
            this._depoSlipDateAmbit = depoSlipDateAmbit;
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // --- ADD 2008/07/22 -------------------------------->>>>>
            this._inpGrsProfChkLower = inpGrsProfChkLower;
            this._inpGrsProfChkUpper = inpGrsProfChkUpper;
            this._inpGrsProfChkLowDiv = inpGrsPrfChkLowDiv;
            this._inpGrsProfChkUppDiv = inpGrsProfChkUppDiv;
            // --- ADD 2008/07/22 --------------------------------<<<<<

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            this._prmSubstCondDivCd = prmSubstCondDivCd;
            this._substApplyDivCd = substApplyDivCd;
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<
            this._partsNameDspDivCd = partsNameDspDivCd;    // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
            this._frSrchPrtAutoEntDiv = frSrchPrtAutoEntDiv;    // ADD 2010/04/30
            this._bLGoodsCdDerivNoDiv = bLGoodsCdDerivNoDiv;

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            this._blCdPrtsNmDspDivCd1 = blCdPrtsNmDspDivCd1;
            this._blCdPrtsNmDspDivCd2 = blCdPrtsNmDspDivCd2;
            this._blCdPrtsNmDspDivCd3 = blCdPrtsNmDspDivCd3;
            this._blCdPrtsNmDspDivCd4 = blCdPrtsNmDspDivCd4;
            this._gdNoPrtsNmDspDivCd1 = gdNoPrtsNmDspDivCd1;
            this._gdNoPrtsNmDspDivCd2 = gdNoPrtsNmDspDivCd2;
            this._gdNoPrtsNmDspDivCd3 = gdNoPrtsNmDspDivCd3;
            this._gdNoPrtsNmDspDivCd4 = gdNoPrtsNmDspDivCd4;
            this._prmPrtsNmUseDivCd = prmPrtsNmUseDivCd;
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            this._dwnPLCdSpDivCd = dwnPLCdSpDivCd;
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            this._salesCdDspDivCd = salesCdDspDivCd;
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            this._rentStockDiv = rentStockDiv;
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            this._EpPartsNoPrtCd = EpPartsNoPrtCd;
            this._EpPartsNoAddChar = EpPartsNoAddChar;
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            this._PrintGoodsNoDef = PrintGoodsNoDef;
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            this._stockRetGoodsPlnDiv = StockRetGoodsPlnDiv;
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            this._BLGoodsCdZeroSuprt = BLGoodsCdZeroSuprt;
            this._BLGoodsCdChange = BLGoodsCdChange;
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            this._stockEmpRefDiv = stockEmpRefDiv;
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
        }

		/// <summary>
		/// 売上全体設定マスタ複製処理
		/// </summary>
		/// <returns>SalesTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesTtlStクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号         :   11370030-00 2017/04/13 譚洪</br>
        /// <br>                     Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		public SalesTtlSt Clone()
		{
			return new SalesTtlSt(	this._createDateTime,
									this._updateDateTime,
									this._enterpriseCode,
									this._fileHeaderGuid,
									this._updEmployeeCode,
									this._updAssemblyId1,
									this._updAssemblyId2,
									this._logicalDeleteCode,
                                    this._sectionCode,  // ADD 2008/06/06
									this._salesSlipPrtDiv,
									this._shipmSlipPrtDiv,
									//this._zeroPrtDiv,          // DEL 2008/07/22
									this._shipmSlipUnPrcPrtDiv,
                                    //this._ioGoodsCntDiv,       // DEL 2008/07/22

                                    // --- DEL 2008/07/22 -------------------------------->>>>>
                                    ////----- ueno add ---------- start 2008.02.26
                                    //this._ioGoodsCntDiv2,
                                    ////----- ueno add ---------- end 2008.02.26
                                    //this._salesFormalIn,
                                    //this._stockDetailConf,
                                    // --- DEL 2008/07/22 --------------------------------<<<<< 

									this._grsProfitCheckLower,
									this._grsProfitCheckBest,
									this._grsProfitCheckUpper,
									this._grsProfitChkLowSign,
									this._grsProfitChkBestSign,
									this._grsProfitChkUprSign,
									this._grsProfitChkMaxSign,
									this._salesAgentChngDiv,
									this._acpOdrAgentDispDiv,
									this._brSlipNote2DispDiv,
									this._dtlNoteDispDiv,
									this._unPrcNonSettingDiv,
                                    this._estmateAddUpRemDiv,  // ADD 2008/06/06
									this._acpOdrrAddUpRemDiv,
									this._shipmAddUpRemDiv,
									this._retGoodsStockEtyDiv,
									this._listPriceSelectDiv,
									this._makerInpDiv,
									this._bLGoodsCdInpDiv,
									this._supplierInpDiv,
									this._supplierSlipDelDiv,
									this._custGuideDispDiv,
									this._slipChngDivDate,
									this._slipChngDivCost,
									this._slipChngDivUnPrc,
									this._slipChngDivLPrice,
                                    // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
                                    this._retSlipChngDivCost,
                                    this._retSlipChngDivUnPrc,
                                    // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
                                    //----- ueno add ---------- start 2008.02.18
									this._autoDepoKindCode,
									this._autoDepoKindName,
									this._autoDepoKindDivCd,
									//----- ueno add ---------- end 2008.02.18
									//----- ueno add ---------- start 2008.02.26
									this._discountName,
									//----- ueno add ---------- end 2008.02.26

                                    // --- ADD 2008/06/06 -------------------------------->>>>>
									this._inpAgentDispDiv,
									this._custOrderNoDispDiv,
									this._carMngNoDispDiv,
                                    // --- ADD 2009/10/19 ---------->>>>>
                                    this._priceSelectDispDiv,
                                    // --- ADD 2009/10/19 ----------<<<<<
                                    this._acpOdrInputDiv,        // ADD 2010/01/29 受注数入力を追加
                                    this._inpAgentChkDiv,        // ADD 2010/05/04 発行者チェック区分を追加
                                    this._inpWarehChkDiv,        // ADD 2010/05/04 入力倉庫チェック区分を追加
									this._brSlipNote3DispDiv,
									this._slipDateClrDivCd,
									this._autoEntryGoodsDivCd,
									this._costCheckDivCd,
									this._joinInitDispDiv,
									this._autoDepositCd,
                                    this._autoDepositNoteDiv,   // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797 
									this._substCondDivCd,
									this._slipCreateProcess,
									this._warehouseChkDiv,
									this._partsSearchDivCd,
									this._grsProfitDspCd,
									this._partsSearchPriDivCd,
									this._salesStockDiv,
									this._prtBLGoodsCodeDiv,
									this._sectDspDivCd,
									this._goodsNmReDispDivCd,
									this._costDspDivCd,
									this._depoSlipDateClrDiv,
									this._depoSlipDateAmbit,
                                    // --- ADD 2008/06/06 --------------------------------<<<<< 

                                    // --- ADD 2008/07/22 -------------------------------->>>>>
                                    this._inpGrsProfChkLower,
                                    this._inpGrsProfChkUpper,
                                    this._inpGrsProfChkLowDiv,
                                    this._inpGrsProfChkUppDiv,
                                    // --- ADD 2008/07/22 --------------------------------<<<<<
                                    // ADD 2008/09/29 不具合対応[5665]---------->>>>>
                                    this._prmSubstCondDivCd,
                                    this._substApplyDivCd,
                                    // ADD 2008/09/29 不具合対応[5665]----------<<<<<
                                    this._partsNameDspDivCd, // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
                                    this._frSrchPrtAutoEntDiv, // ADD 2010/04/30
                                    this._bLGoodsCdDerivNoDiv

                                    // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
                                    , this._blCdPrtsNmDspDivCd1
                                    , this._blCdPrtsNmDspDivCd2
                                    , this._blCdPrtsNmDspDivCd3
                                    , this._blCdPrtsNmDspDivCd4
                                    , this._gdNoPrtsNmDspDivCd1
                                    , this._gdNoPrtsNmDspDivCd2
                                    , this._gdNoPrtsNmDspDivCd3
                                    , this._gdNoPrtsNmDspDivCd4
                                    , this._prmPrtsNmUseDivCd
                                    // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
                                    // --- ADD 2010/08/04 ---------->>>>>
                                    , this._dwnPLCdSpDivCd
                                    // --- ADD 2010/08/04 ----------<<<<<
                                    // --- ADD 2011/06/07 ---------->>>>>
                                    , this._salesCdDspDivCd
                                    // --- ADD 2011/06/07 ----------<<<<<
                                    // --- ADD 2012/04/23 ---------->>>>>
                                    , this._rentStockDiv
                                    // --- ADD 2012/04/23 ----------<<<<<
                                    // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                                    , this._EpPartsNoPrtCd
                                    , this._EpPartsNoAddChar
                                    // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                                    // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                                    , this._PrintGoodsNoDef
                                    // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                                    // --- ADD 2013/01/15 ---------->>>>>
                                    , this._stockRetGoodsPlnDiv
                                    // --- ADD 2013/01/15 ----------<<<<<
                                    // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                                    , this._BLGoodsCdZeroSuprt
                                    , this._BLGoodsCdChange
                                    // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
                                    // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
                                    , this._stockEmpRefDiv
                                    // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
                               );
		}

		/// <summary>
		/// 売上全体設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesTtlStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/07 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号         :   11370030-00 2017/04/13 譚洪</br>
        /// <br>                     Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		public bool Equals(SalesTtlSt target)
		{
			return ((this.CreateDateTime		== target.CreateDateTime)
				&& (this.UpdateDateTime			== target.UpdateDateTime)
				&& (this.EnterpriseCode			== target.EnterpriseCode)
				&& (this.FileHeaderGuid			== target.FileHeaderGuid)
				&& (this.UpdEmployeeCode		== target.UpdEmployeeCode)
				&& (this.UpdAssemblyId1			== target.UpdAssemblyId1)
				&& (this.UpdAssemblyId2			== target.UpdAssemblyId2)
				&& (this.LogicalDeleteCode		== target.LogicalDeleteCode)
                && (this.SectionCode            == target.SectionCode)  // ADD 2008/06/06
				&& (this.SalesSlipPrtDiv		== target.SalesSlipPrtDiv)
				&& (this.ShipmSlipPrtDiv		== target.ShipmSlipPrtDiv)
				//&& (this.ZeroPrtDiv				== target.ZeroPrtDiv)        // DEL 2008/07/22
				&& (this.ShipmSlipUnPrcPrtDiv	== target.ShipmSlipUnPrcPrtDiv)
                //&& (this.IoGoodsCntDiv			== target.IoGoodsCntDiv)     // DEL 2008/07/22 

                // --- DEL 2008/07/22 -------------------------------->>>>>
                ////----- ueno add ---------- start 2008.02.26
                //&& (this.IoGoodsCntDiv2			== target.IoGoodsCntDiv2)
                ////----- ueno add ---------- end 2008.02.26
                //&& (this.SalesFormalIn			== target.SalesFormalIn)
                //&& (this.StockDetailConf		== target.StockDetailConf)
                // --- DEL 2008/07/22 --------------------------------<<<<< 

				&& (this.GrsProfitCheckLower	== target.GrsProfitCheckLower)
				&& (this.GrsProfitCheckBest		== target.GrsProfitCheckBest)
				&& (this.GrsProfitCheckUpper	== target.GrsProfitCheckUpper)
				&& (this.GrsProfitChkLowSign	== target.GrsProfitChkLowSign)
				&& (this.GrsProfitChkBestSign	== target.GrsProfitChkBestSign)
				&& (this.GrsProfitChkUprSign	== target.GrsProfitChkUprSign)
				&& (this.GrsProfitChkMaxSign	== target.GrsProfitChkMaxSign)
				&& (this.SalesAgentChngDiv		== target.SalesAgentChngDiv)
				&& (this.AcpOdrAgentDispDiv		== target.AcpOdrAgentDispDiv)
				&& (this.BrSlipNote2DispDiv		== target.BrSlipNote2DispDiv)
				&& (this.DtlNoteDispDiv			== target.DtlNoteDispDiv)
				&& (this.UnPrcNonSettingDiv		== target.UnPrcNonSettingDiv)
                && (this.EstmateAddUpRemDiv     == target.EstmateAddUpRemDiv)  // ADD 2008/06/06
				&& (this.AcpOdrrAddUpRemDiv		== target.AcpOdrrAddUpRemDiv)
				&& (this.ShipmAddUpRemDiv		== target.ShipmAddUpRemDiv)
				&& (this.RetGoodsStockEtyDiv	== target.RetGoodsStockEtyDiv)
				&& (this.ListPriceSelectDiv		== target.ListPriceSelectDiv)
				&& (this.MakerInpDiv			== target.MakerInpDiv)
				&& (this.BLGoodsCdInpDiv		== target.BLGoodsCdInpDiv)
				&& (this.SupplierInpDiv			== target.SupplierInpDiv)
				&& (this.SupplierSlipDelDiv		== target.SupplierSlipDelDiv)
				&& (this.CustGuideDispDiv		== target.CustGuideDispDiv)
				&& (this.SlipChngDivDate		== target.SlipChngDivDate)
				&& (this.SlipChngDivCost		== target.SlipChngDivCost)
				&& (this.SlipChngDivUnPrc		== target.SlipChngDivUnPrc)
				&& (this.SlipChngDivLPrice		== target.SlipChngDivLPrice)
                // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
                && (this.RetSlipChngDivCost == target.RetSlipChngDivCost)
                && (this.RetSlipChngDivUnPrc == target.RetSlipChngDivUnPrc)
                // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
                //----- ueno add ---------- start 2008.02.18
				&& (this.AutoDepoKindCode		== target.AutoDepoKindCode)
				&& (this.AutoDepoKindName		== target.AutoDepoKindName)
				&& (this.AutoDepoKindDivCd		== target.AutoDepoKindDivCd)
				//----- ueno add ---------- end 2008.02.18
				//----- ueno add ---------- start 2008.02.26
				&& (this.DiscountName			== target.DiscountName)
				//----- ueno add ---------- end 2008.02.26

                // --- ADD 2008/06/06 -------------------------------->>>>>
                && (this.InpAgentDispDiv        == target.InpAgentDispDiv)
				&& (this.CustOrderNoDispDiv     == target.CustOrderNoDispDiv)
				&& (this.CarMngNoDispDiv        == target.CarMngNoDispDiv)
                // --- ADD 2009/10/19 ---------->>>>>
                && (this.PriceSelectDispDiv     == target.PriceSelectDispDiv)
                // --- ADD 2009/10/19 ----------<<<<<
                && (this.AcpOdrInputDiv         == target.AcpOdrInputDiv)　　　// ADD 2010/01/29 受注数入力を追加
                && (this.InpAgentChkDiv         == target.InpAgentChkDiv)　　　// ADD 2010/05/04 発行者チェック区分を追加
                && (this.InpWarehChkDiv         == target.InpWarehChkDiv)　　　// ADD 2010/05/04 入力倉庫チェック区分を追加
				&& (this.BrSlipNote3DispDiv     == target.BrSlipNote3DispDiv)
				&& (this.SlipDateClrDivCd       == target.SlipDateClrDivCd)
				&& (this.AutoEntryGoodsDivCd    == target.AutoEntryGoodsDivCd)
				&& (this.CostCheckDivCd         == target.CostCheckDivCd)
				&& (this.JoinInitDispDiv        == target.JoinInitDispDiv)
				&& (this.AutoDepositCd          == target.AutoDepositCd)
                && (this.AutoDepositNoteDiv     == target.AutoDepositNoteDiv)  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
				&& (this.SubstCondDivCd         == target.SubstCondDivCd)
				&& (this.SlipCreateProcess      == target.SlipCreateProcess)
				&& (this.WarehouseChkDiv        == target.WarehouseChkDiv)
				&& (this.PartsSearchDivCd       == target.PartsSearchDivCd)
				&& (this.GrsProfitDspCd         == target.GrsProfitDspCd)
				&& (this.PartsSearchPriDivCd    == target.PartsSearchPriDivCd)
				&& (this.SalesStockDiv          == target.SalesStockDiv)
				&& (this.PrtBLGoodsCodeDiv      == target.PrtBLGoodsCodeDiv)
				&& (this.SectDspDivCd           == target.SectDspDivCd)
				&& (this.GoodsNmReDispDivCd     == target.GoodsNmReDispDivCd)
                && (this.CostDspDivCd           == target.CostDspDivCd)
                && (this.DepoSlipDateClrDiv     == target.DepoSlipDateClrDiv)
				&& (this.DepoSlipDateAmbit      == target.DepoSlipDateAmbit)
                // --- ADD 2008/06/06 --------------------------------<<<<< 

                // --- ADD 2008/07/22 -------------------------------->>>>>
                && (this.InpGrsProfChkLower == target.InpGrsProfChkLower)
                && (this.InpGrsProfChkUpper == target.InpGrsProfChkUpper)
                && (this.InpGrsProfChkLowDiv == target.InpGrsProfChkLowDiv)
                && (this.InpGrsProfChkUppDiv == target.InpGrsProfChkUppDiv)
                // --- ADD 2008/07/22 --------------------------------<<<<<

                // ADD 2008/09/29 不具合対応[5665]---------->>>>>
                && (this.PrmSubstCondDivCd.Equals(target.PrmSubstCondDivCd))
				&& (this.SubstApplyDivCd.Equals(target.SubstApplyDivCd))
				// ADD 2008/09/29 不具合対応[5665]----------<<<<<
				&& (this.PartsNameDspDivCd.Equals(target.PartsNameDspDivCd))    // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
                && (this.FrSrchPrtAutoEntDiv.Equals(target.FrSrchPrtAutoEntDiv))    // ADD 2010/04/30
				&& (this.BLGoodsCdDerivNoDiv == target.BLGoodsCdDerivNoDiv)

                // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
                && (this.BLCdPrtsNmDspDivCd1 == target.BLCdPrtsNmDspDivCd1)
                && (this.BLCdPrtsNmDspDivCd2 == target.BLCdPrtsNmDspDivCd2)
                && (this.BLCdPrtsNmDspDivCd3 == target.BLCdPrtsNmDspDivCd3)
                && (this.BLCdPrtsNmDspDivCd4 == target.BLCdPrtsNmDspDivCd4)
                && (this.GdNoPrtsNmDspDivCd1 == target.GdNoPrtsNmDspDivCd1)
                && (this.GdNoPrtsNmDspDivCd2 == target.GdNoPrtsNmDspDivCd2)
                && (this.GdNoPrtsNmDspDivCd3 == target.GdNoPrtsNmDspDivCd3)
                && (this.GdNoPrtsNmDspDivCd4 == target.GdNoPrtsNmDspDivCd4)
                && (this.PrmPrtsNmUseDivCd == target.PrmPrtsNmUseDivCd)
                // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
                // --- ADD 2010/08/04 ---------->>>>>
                && (this.DwnPLCdSpDivCd == target.DwnPLCdSpDivCd)
                // --- ADD 2010/08/04 ----------<<<<<
                // --- ADD 2011/06/07 ---------->>>>>
                && (this.SalesCdDspDivCd == target.SalesCdDspDivCd)
                // --- ADD 2011/06/07 ----------<<<<<
                // --- ADD 2012/04/23 ---------->>>>>
                && (this.RentStockDiv == target.RentStockDiv)
                // --- ADD 2012/04/23 ----------<<<<<
                // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                && (this.EpPartsNoPrtCd == target.EpPartsNoPrtCd)
                && (this.EpPartsNoAddChar == target.EpPartsNoAddChar)
                // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                && (this.PrintGoodsNoDef == target.PrintGoodsNoDef)
                // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                // --- ADD 2013/01/15
                && (this.StockRetGoodsPlnDiv == target.StockRetGoodsPlnDiv)
                // --- ADD 2013/01/15
                // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                && (this.BLGoodsCdZeroSuprt == target.BLGoodsCdZeroSuprt)
                && (this.BLGoodsCdChange == target.BLGoodsCdChange)
                // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
                // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
                && (this.StockEmpRefDiv == target.StockEmpRefDiv)
                // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
                );
		}

		/// <summary>
		/// 売上全体設定マスタ比較処理
		/// </summary>
		/// <param name="salesTtlSt1">
		///                    比較するSalesTtlStクラスのインスタンス
		/// </param>
		/// <param name="salesTtlSt2">比較するSalesTtlStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号         :   11370030-00 2017/04/13 譚洪</br>
        /// <br>                     Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		public static bool Equals(SalesTtlSt salesTtlSt1, SalesTtlSt salesTtlSt2)
		{
			return ((salesTtlSt1.CreateDateTime			== salesTtlSt2.CreateDateTime)
				&& (salesTtlSt1.UpdateDateTime			== salesTtlSt2.UpdateDateTime)
				&& (salesTtlSt1.EnterpriseCode			== salesTtlSt2.EnterpriseCode)
				&& (salesTtlSt1.FileHeaderGuid			== salesTtlSt2.FileHeaderGuid)
				&& (salesTtlSt1.UpdEmployeeCode			== salesTtlSt2.UpdEmployeeCode)
				&& (salesTtlSt1.UpdAssemblyId1			== salesTtlSt2.UpdAssemblyId1)
				&& (salesTtlSt1.UpdAssemblyId2			== salesTtlSt2.UpdAssemblyId2)
				&& (salesTtlSt1.LogicalDeleteCode		== salesTtlSt2.LogicalDeleteCode)
                && (salesTtlSt1.SectionCode             == salesTtlSt2.SectionCode)  // ADD 2008/06/06
				&& (salesTtlSt1.SalesSlipPrtDiv			== salesTtlSt2.SalesSlipPrtDiv)
				&& (salesTtlSt1.ShipmSlipPrtDiv			== salesTtlSt2.ShipmSlipPrtDiv)
				//&& (salesTtlSt1.ZeroPrtDiv				== salesTtlSt2.ZeroPrtDiv)        // DEL 2008/07/22
				&& (salesTtlSt1.ShipmSlipUnPrcPrtDiv	== salesTtlSt2.ShipmSlipUnPrcPrtDiv)
                //&& (salesTtlSt1.IoGoodsCntDiv			== salesTtlSt2.IoGoodsCntDiv)         // DEL 2008/07/22

                // --- DEL 2008/07/22 -------------------------------->>>>>
				//----- ueno add ---------- start 2008.02.26
                //&& (salesTtlSt1.IoGoodsCntDiv2 == salesTtlSt2.IoGoodsCntDiv2)
                ////----- ueno add ---------- end 2008.02.26
                //&& (salesTtlSt1.SalesFormalIn			== salesTtlSt2.SalesFormalIn)
                //&& (salesTtlSt1.StockDetailConf			== salesTtlSt2.StockDetailConf)
                // --- DEL 2008/07/22 --------------------------------<<<<< 

				&& (salesTtlSt1.GrsProfitCheckLower		== salesTtlSt2.GrsProfitCheckLower)
				&& (salesTtlSt1.GrsProfitCheckBest		== salesTtlSt2.GrsProfitCheckBest)
				&& (salesTtlSt1.GrsProfitCheckUpper		== salesTtlSt2.GrsProfitCheckUpper)
				&& (salesTtlSt1.GrsProfitChkLowSign		== salesTtlSt2.GrsProfitChkLowSign)
				&& (salesTtlSt1.GrsProfitChkBestSign	== salesTtlSt2.GrsProfitChkBestSign)
				&& (salesTtlSt1.GrsProfitChkUprSign		== salesTtlSt2.GrsProfitChkUprSign)
				&& (salesTtlSt1.GrsProfitChkMaxSign		== salesTtlSt2.GrsProfitChkMaxSign)
				&& (salesTtlSt1.SalesAgentChngDiv		== salesTtlSt2.SalesAgentChngDiv)
				&& (salesTtlSt1.AcpOdrAgentDispDiv		== salesTtlSt2.AcpOdrAgentDispDiv)
				&& (salesTtlSt1.BrSlipNote2DispDiv		== salesTtlSt2.BrSlipNote2DispDiv)
				&& (salesTtlSt1.DtlNoteDispDiv			== salesTtlSt2.DtlNoteDispDiv)
				&& (salesTtlSt1.UnPrcNonSettingDiv		== salesTtlSt2.UnPrcNonSettingDiv)
                && (salesTtlSt1.EstmateAddUpRemDiv      == salesTtlSt2.EstmateAddUpRemDiv)  // ADD 2008/06/06
				&& (salesTtlSt1.AcpOdrrAddUpRemDiv		== salesTtlSt2.AcpOdrrAddUpRemDiv)
				&& (salesTtlSt1.ShipmAddUpRemDiv		== salesTtlSt2.ShipmAddUpRemDiv)
				&& (salesTtlSt1.RetGoodsStockEtyDiv		== salesTtlSt2.RetGoodsStockEtyDiv)
				&& (salesTtlSt1.ListPriceSelectDiv		== salesTtlSt2.ListPriceSelectDiv)
				&& (salesTtlSt1.MakerInpDiv				== salesTtlSt2.MakerInpDiv)
				&& (salesTtlSt1.BLGoodsCdInpDiv			== salesTtlSt2.BLGoodsCdInpDiv)
				&& (salesTtlSt1.SupplierInpDiv			== salesTtlSt2.SupplierInpDiv)
				&& (salesTtlSt1.SupplierSlipDelDiv		== salesTtlSt2.SupplierSlipDelDiv)
				&& (salesTtlSt1.CustGuideDispDiv		== salesTtlSt2.CustGuideDispDiv)
				&& (salesTtlSt1.SlipChngDivDate			== salesTtlSt2.SlipChngDivDate)
				&& (salesTtlSt1.SlipChngDivCost			== salesTtlSt2.SlipChngDivCost)
				&& (salesTtlSt1.SlipChngDivUnPrc		== salesTtlSt2.SlipChngDivUnPrc)
				&& (salesTtlSt1.SlipChngDivLPrice		== salesTtlSt2.SlipChngDivLPrice)
                // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
                && (salesTtlSt1.RetSlipChngDivCost == salesTtlSt2.RetSlipChngDivCost)
                && (salesTtlSt1.RetSlipChngDivUnPrc == salesTtlSt2.RetSlipChngDivUnPrc)
                // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
                //----- ueno add ---------- start 2008.02.18
				&& (salesTtlSt1.AutoDepoKindCode		== salesTtlSt2.AutoDepoKindCode)
				&& (salesTtlSt1.AutoDepoKindName		== salesTtlSt2.AutoDepoKindName)
				&& (salesTtlSt1.AutoDepoKindDivCd		== salesTtlSt2.AutoDepoKindDivCd)
				//----- ueno add ---------- end 2008.02.18
				//----- ueno add ---------- start 2008.02.26
				&& (salesTtlSt1.DiscountName			== salesTtlSt2.DiscountName)
				//----- ueno add ---------- end 2008.02.26

                // --- ADD 2008/06/06 -------------------------------->>>>>
				&& (salesTtlSt1.InpAgentDispDiv         == salesTtlSt2.InpAgentDispDiv)
				&& (salesTtlSt1.CustOrderNoDispDiv      == salesTtlSt2.CustOrderNoDispDiv)
				&& (salesTtlSt1.CarMngNoDispDiv         == salesTtlSt2.CarMngNoDispDiv)
                // --- ADD 2009/10/19 ---------->>>>>
                && (salesTtlSt1.PriceSelectDispDiv      == salesTtlSt2.PriceSelectDispDiv)
                // --- ADD 2009/10/19 ----------<<<<<
                && (salesTtlSt1.AcpOdrInputDiv 　　　　 == salesTtlSt2.AcpOdrInputDiv)　　　// ADD 2010/01/29 受注数入力を追加
                && (salesTtlSt1.InpAgentChkDiv          == salesTtlSt2.InpAgentChkDiv)　　　// ADD 2010/05/04 発行者チェック区分を追加
                && (salesTtlSt1.InpWarehChkDiv          == salesTtlSt2.InpWarehChkDiv)　　　// ADD 2010/05/04 入力倉庫チェック区分を追加
				&& (salesTtlSt1.BrSlipNote3DispDiv      == salesTtlSt2.BrSlipNote3DispDiv)
				&& (salesTtlSt1.SlipDateClrDivCd        == salesTtlSt2.SlipDateClrDivCd)
				&& (salesTtlSt1.AutoEntryGoodsDivCd     == salesTtlSt2.AutoEntryGoodsDivCd)
				&& (salesTtlSt1.CostCheckDivCd          == salesTtlSt2.CostCheckDivCd)
				&& (salesTtlSt1.JoinInitDispDiv         == salesTtlSt2.JoinInitDispDiv)
				&& (salesTtlSt1.AutoDepositCd           == salesTtlSt2.AutoDepositCd)
                && (salesTtlSt1.AutoDepositNoteDiv      == salesTtlSt2.AutoDepositNoteDiv)  // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
				&& (salesTtlSt1.SubstCondDivCd          == salesTtlSt2.SubstCondDivCd)
				&& (salesTtlSt1.SlipCreateProcess       == salesTtlSt2.SlipCreateProcess)
				&& (salesTtlSt1.WarehouseChkDiv         == salesTtlSt2.WarehouseChkDiv)
				&& (salesTtlSt1.PartsSearchDivCd        == salesTtlSt2.PartsSearchDivCd)
				&& (salesTtlSt1.GrsProfitDspCd          == salesTtlSt2.GrsProfitDspCd)
				&& (salesTtlSt1.PartsSearchPriDivCd     == salesTtlSt2.PartsSearchPriDivCd)
				&& (salesTtlSt1.SalesStockDiv           == salesTtlSt2.SalesStockDiv)
				&& (salesTtlSt1.PrtBLGoodsCodeDiv       == salesTtlSt2.PrtBLGoodsCodeDiv)
				&& (salesTtlSt1.SectDspDivCd            == salesTtlSt2.SectDspDivCd)
				&& (salesTtlSt1.GoodsNmReDispDivCd      == salesTtlSt2.GoodsNmReDispDivCd)
				&& (salesTtlSt1.CostDspDivCd            == salesTtlSt2.CostDspDivCd)
				&& (salesTtlSt1.DepoSlipDateClrDiv      == salesTtlSt2.DepoSlipDateClrDiv)
                && (salesTtlSt1.DepoSlipDateAmbit       == salesTtlSt2.DepoSlipDateAmbit)
                // --- ADD 2008/06/06 --------------------------------<<<<< 

                // --- ADD 2008/07/22 -------------------------------->>>>>
                && (salesTtlSt1.InpGrsProfChkLower == salesTtlSt2.InpGrsProfChkLower)
                && (salesTtlSt1.InpGrsProfChkUpper == salesTtlSt2.InpGrsProfChkUpper)
                && (salesTtlSt1.InpGrsProfChkLowDiv == salesTtlSt2.InpGrsProfChkLowDiv)
                && (salesTtlSt1.InpGrsProfChkUppDiv == salesTtlSt2.InpGrsProfChkUppDiv)
                // --- ADD 2008/07/22 --------------------------------<<<<<

                // ADD 2008/09/29 不具合対応[5665]---------->>>>>
                && (salesTtlSt1.PrmSubstCondDivCd.Equals(salesTtlSt2.PrmSubstCondDivCd))
                && (salesTtlSt1.SubstApplyDivCd.Equals(salesTtlSt2.SubstApplyDivCd))
                // ADD 2008/09/29 不具合対応[5665]----------<<<<<
                && (salesTtlSt1.PartsNameDspDivCd.Equals(salesTtlSt2.PartsNameDspDivCd))    // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
                && (salesTtlSt1.FrSrchPrtAutoEntDiv.Equals(salesTtlSt2.FrSrchPrtAutoEntDiv))    // ADD 2010/04/30
                && (salesTtlSt1.BLGoodsCdDerivNoDiv == salesTtlSt2.BLGoodsCdDerivNoDiv)

                // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
                && (salesTtlSt1.BLCdPrtsNmDspDivCd1 == salesTtlSt2.BLCdPrtsNmDspDivCd1)
                && (salesTtlSt1.BLCdPrtsNmDspDivCd2 == salesTtlSt2.BLCdPrtsNmDspDivCd2)
                && (salesTtlSt1.BLCdPrtsNmDspDivCd3 == salesTtlSt2.BLCdPrtsNmDspDivCd3)
                && (salesTtlSt1.BLCdPrtsNmDspDivCd4 == salesTtlSt2.BLCdPrtsNmDspDivCd4)
                && (salesTtlSt1.GdNoPrtsNmDspDivCd1 == salesTtlSt2.GdNoPrtsNmDspDivCd1)
                && (salesTtlSt1.GdNoPrtsNmDspDivCd2 == salesTtlSt2.GdNoPrtsNmDspDivCd2)
                && (salesTtlSt1.GdNoPrtsNmDspDivCd3 == salesTtlSt2.GdNoPrtsNmDspDivCd3)
                && (salesTtlSt1.GdNoPrtsNmDspDivCd4 == salesTtlSt2.GdNoPrtsNmDspDivCd4)
                && (salesTtlSt1.PrmPrtsNmUseDivCd == salesTtlSt2.PrmPrtsNmUseDivCd)
                // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
                // --- ADD 2010/08/04 ---------->>>>>
                && (salesTtlSt1.DwnPLCdSpDivCd == salesTtlSt2.DwnPLCdSpDivCd)
                // --- ADD 2010/08/04 ----------<<<<<
                // --- ADD 2011/06/07 ---------->>>>>
                && (salesTtlSt1.SalesCdDspDivCd == salesTtlSt2.SalesCdDspDivCd)
                // --- ADD 2011/06/07 ----------<<<<<
                // --- ADD 2012/04/23 ---------->>>>>
                && (salesTtlSt1.RentStockDiv == salesTtlSt2.RentStockDiv)
                // --- ADD 2012/04/23 ----------<<<<<
                // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
                && (salesTtlSt1.EpPartsNoPrtCd == salesTtlSt2.EpPartsNoPrtCd)
                && (salesTtlSt1.EpPartsNoAddChar == salesTtlSt2.EpPartsNoAddChar)
                // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
                // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
                && (salesTtlSt1.PrintGoodsNoDef == salesTtlSt2.PrintGoodsNoDef)
                // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
                // --- ADD 2013/01/15 ---------->>>>>
                && (salesTtlSt1.StockRetGoodsPlnDiv == salesTtlSt2.StockRetGoodsPlnDiv)
                // --- ADD 2013/01/15 ----------<<<<<
                // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                && (salesTtlSt1.BLGoodsCdZeroSuprt == salesTtlSt2.BLGoodsCdZeroSuprt)
                && (salesTtlSt1.BLGoodsCdChange == salesTtlSt2.BLGoodsCdChange)
                // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
                // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
                && (salesTtlSt1.StockEmpRefDiv == salesTtlSt2.StockEmpRefDiv)
                // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
                );
		}
		/// <summary>
		/// 売上全体設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesTtlStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note      :   2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号         :   11370030-00 2017/04/13 譚洪</br>
        /// <br>                     Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		public ArrayList Compare(SalesTtlSt target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime			!= target.CreateDateTime)		resList.Add("CreateDateTime");
			if (this.UpdateDateTime			!= target.UpdateDateTime)		resList.Add("UpdateDateTime");
			if (this.EnterpriseCode			!= target.EnterpriseCode)		resList.Add("EnterpriseCode");
			if (this.FileHeaderGuid			!= target.FileHeaderGuid)		resList.Add("FileHeaderGuid");
			if (this.UpdEmployeeCode		!= target.UpdEmployeeCode)		resList.Add("UpdEmployeeCode");
			if (this.UpdAssemblyId1			!= target.UpdAssemblyId1)		resList.Add("UpdAssemblyId1");
			if (this.UpdAssemblyId2			!= target.UpdAssemblyId2)		resList.Add("UpdAssemblyId2");
			if (this.LogicalDeleteCode		!= target.LogicalDeleteCode)	resList.Add("LogicalDeleteCode");
            if (this.SectionCode            != target.SectionCode)          resList.Add("SectionCode");  // ADD 2008/06/06
            if (this.SalesSlipPrtDiv		!= target.SalesSlipPrtDiv)		resList.Add("SalesSlipPrtDiv");
			if (this.ShipmSlipPrtDiv		!= target.ShipmSlipPrtDiv)		resList.Add("ShipmSlipPrtDiv");
			//if (this.ZeroPrtDiv				!= target.ZeroPrtDiv)			resList.Add("ZeroPrtDiv");        // DEL 2008/07/22
			if (this.ShipmSlipUnPrcPrtDiv	!= target.ShipmSlipUnPrcPrtDiv)	resList.Add("ShipmSlipUnPrcPrtDiv");
            //if (this.IoGoodsCntDiv			!= target.IoGoodsCntDiv)		resList.Add("IoGoodsCntDiv");     // DEL 2008/07/22

            // --- DEL 2008/07/22 -------------------------------->>>>>
            ////----- ueno add ---------- start 2008.02.26
            //if (this.IoGoodsCntDiv2			!= target.IoGoodsCntDiv2)		resList.Add("IoGoodsCntDiv2");
            ////----- ueno add ---------- end 2008.02.26
            //if (this.SalesFormalIn			!= target.SalesFormalIn)		resList.Add("SalesFormalIn");
            //if (this.StockDetailConf		!= target.StockDetailConf)		resList.Add("StockDetailConf");
            // --- DEL 2008/07/22 --------------------------------<<<<< 

			if (this.GrsProfitCheckLower	!= target.GrsProfitCheckLower)	resList.Add("GrsProfitCheckLower");
			if (this.GrsProfitCheckBest		!= target.GrsProfitCheckBest)	resList.Add("GrsProfitCheckBest");
			if (this.GrsProfitCheckUpper	!= target.GrsProfitCheckUpper)	resList.Add("GrsProfitCheckUpper");
			if (this.GrsProfitChkLowSign	!= target.GrsProfitChkLowSign)	resList.Add("GrsProfitChkLowSign");
			if (this.GrsProfitChkBestSign	!= target.GrsProfitChkBestSign)	resList.Add("GrsProfitChkBestSign");
			if (this.GrsProfitChkUprSign	!= target.GrsProfitChkUprSign)	resList.Add("GrsProfitChkUprSign");
			if (this.GrsProfitChkMaxSign	!= target.GrsProfitChkMaxSign)	resList.Add("GrsProfitChkMaxSign");
			if (this.SalesAgentChngDiv		!= target.SalesAgentChngDiv)	resList.Add("SalesAgentChngDiv");
			if (this.AcpOdrAgentDispDiv		!= target.AcpOdrAgentDispDiv)	resList.Add("AcpOdrAgentDispDiv");
			if (this.BrSlipNote2DispDiv		!= target.BrSlipNote2DispDiv)	resList.Add("BrSlipNote2DispDiv");
			if (this.DtlNoteDispDiv			!= target.DtlNoteDispDiv)		resList.Add("DtlNoteDispDiv");
			if (this.UnPrcNonSettingDiv		!= target.UnPrcNonSettingDiv)	resList.Add("UnPrcNonSettingDiv");
            if (this.EstmateAddUpRemDiv     != target.EstmateAddUpRemDiv)   resList.Add("EstmateAddUpRemDiv");  // ADD 2008/06/06
            if (this.AcpOdrrAddUpRemDiv		!= target.AcpOdrrAddUpRemDiv)	resList.Add("AcpOdrrAddUpRemDiv");
			if (this.ShipmAddUpRemDiv		!= target.ShipmAddUpRemDiv)		resList.Add("ShipmAddUpRemDiv");
			if (this.RetGoodsStockEtyDiv	!= target.RetGoodsStockEtyDiv)	resList.Add("RetGoodsStockEtyDiv");
			if (this.ListPriceSelectDiv		!= target.ListPriceSelectDiv)	resList.Add("ListPriceSelectDiv");
			if (this.MakerInpDiv			!= target.MakerInpDiv)			resList.Add("MakerInpDiv");
			if (this.BLGoodsCdInpDiv		!= target.BLGoodsCdInpDiv)		resList.Add("BLGoodsCdInpDiv");
			if (this.SupplierInpDiv			!= target.SupplierInpDiv)		resList.Add("SupplierInpDiv");
			if (this.SupplierSlipDelDiv		!= target.SupplierSlipDelDiv)	resList.Add("SupplierSlipDelDiv");
			if (this.CustGuideDispDiv		!= target.CustGuideDispDiv)		resList.Add("CustGuideDispDiv");
			if (this.SlipChngDivDate		!= target.SlipChngDivDate)		resList.Add("SlipChngDivDate");
			if (this.SlipChngDivCost		!= target.SlipChngDivCost)		resList.Add("SlipChngDivCost");
			if (this.SlipChngDivUnPrc		!= target.SlipChngDivUnPrc)		resList.Add("SlipChngDivUnPrc");
			if (this.SlipChngDivLPrice		!= target.SlipChngDivLPrice)	resList.Add("SlipChngDivLPrice");
            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
            if (this.RetSlipChngDivCost     != target.RetSlipChngDivCost)       resList.Add("RetSlipChngDivCost");
            if (this.RetSlipChngDivUnPrc    != target.RetSlipChngDivUnPrc)     resList.Add("RetSlipChngDivUnPrc");
            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
            //----- ueno add ---------- start 2008.02.18
			if (this.AutoDepoKindCode		!= target.AutoDepoKindCode)		resList.Add("AutoDepoKindCode");
			if (this.AutoDepoKindName		!= target.AutoDepoKindName)		resList.Add("AutoDepoKindName");
			if (this.AutoDepoKindDivCd		!= target.AutoDepoKindDivCd)	resList.Add("AutoDepoKindDivCd");
			//----- ueno add ---------- end 2008.02.18
			//----- ueno add ---------- start 2008.02.26
			if (this.DiscountName			!= target.DiscountName)			resList.Add("DiscountName");
			//----- ueno add ---------- end 2008.02.26

            // --- ADD 2008/06/06 -------------------------------->>>>>
			if (this.InpAgentDispDiv        != target.InpAgentDispDiv)      resList.Add("InpAgentDispDiv");
			if (this.CustOrderNoDispDiv     != target.CustOrderNoDispDiv)   resList.Add("CustOrderNoDispDiv");
			if (this.CarMngNoDispDiv        != target.CarMngNoDispDiv)      resList.Add("CarMngNoDispDiv");
            // --- ADD 2009/10/19 ---------->>>>>
            if (this.PriceSelectDispDiv     != target.PriceSelectDispDiv)   resList.Add("PriceSelectDispDiv");
            // --- ADD 2009/10/19 ----------<<<<<
            if (this.AcpOdrInputDiv         != target.AcpOdrInputDiv)       resList.Add("AcpOdrInputDiv");          // ADD 2010/01/29 受注数入力を追加
            if (this.InpAgentChkDiv         != target.InpAgentChkDiv)       resList.Add("InpAgentChkDiv");          // ADD 2010/05/04 発行者チェック区分を追加
            if (this.InpWarehChkDiv         != target.InpWarehChkDiv)       resList.Add("InpWarehChkDiv");          // ADD 2010/05/04 入力倉庫チェック区分を追加
            if (this.BrSlipNote3DispDiv 　　!= target.BrSlipNote3DispDiv)   resList.Add("BrSlipNote3DispDiv");　　
			if (this.SlipDateClrDivCd       != target.SlipDateClrDivCd)     resList.Add("SlipDateClrDivCd");
			if (this.AutoEntryGoodsDivCd    != target.AutoEntryGoodsDivCd)  resList.Add("AutoEntryGoodsDivCd");
			if (this.CostCheckDivCd         != target.CostCheckDivCd)       resList.Add("CostCheckDivCd");
			if (this.JoinInitDispDiv        != target.JoinInitDispDiv)      resList.Add("JoinInitDispDiv");
			if (this.AutoDepositCd          != target.AutoDepositCd)        resList.Add("AutoDepositCd");
            if (this.AutoDepositNoteDiv     != target.AutoDepositNoteDiv)   resList.Add("AutoDepositNoteDiv");   // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
			if (this.SubstCondDivCd         != target.SubstCondDivCd)       resList.Add("SubstCondDivCd");
			if (this.SlipCreateProcess      != target.SlipCreateProcess)    resList.Add("SlipCreateProcess");
			if (this.WarehouseChkDiv        != target.WarehouseChkDiv)      resList.Add("WarehouseChkDiv");
			if (this.PartsSearchDivCd       != target.PartsSearchDivCd)     resList.Add("PartsSearchDivCd");
			if (this.GrsProfitDspCd         != target.GrsProfitDspCd)       resList.Add("GrsProfitDspCd");
			if (this.PartsSearchPriDivCd    != target.PartsSearchPriDivCd)  resList.Add("PartsSearchPriDivCd");
			if (this.SalesStockDiv          != target.SalesStockDiv)        resList.Add("SalesStockDiv");
			if (this.PrtBLGoodsCodeDiv      != target.PrtBLGoodsCodeDiv)    resList.Add("PrtBLGoodsCodeDiv");
			if (this.SectDspDivCd           != target.SectDspDivCd)         resList.Add("SectDspDivCd");
			if (this.GoodsNmReDispDivCd     != target.GoodsNmReDispDivCd)   resList.Add("GoodsNmReDispDivCd");
			if (this.CostDspDivCd           != target.CostDspDivCd)         resList.Add("CostDspDivCd");
			if (this.DepoSlipDateClrDiv     != target.DepoSlipDateClrDiv)   resList.Add("DepoSlipDateClrDiv");
            if (this.DepoSlipDateAmbit      != target.DepoSlipDateAmbit)    resList.Add("DepoSlipDateAmbit");
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // --- ADD 2008/07/22 -------------------------------->>>>>
            if (this.InpGrsProfChkLower != target.InpGrsProfChkLower) resList.Add("InpGrsProfChkLower");
            if (this.InpGrsProfChkUpper != target.InpGrsProfChkUpper) resList.Add("InpGrsProfChkUpper");
            if (this.InpGrsProfChkLowDiv != target.InpGrsProfChkLowDiv) resList.Add("InpGrsProfChkLowDiv");
            if (this.InpGrsProfChkUppDiv != target.InpGrsProfChkUppDiv) resList.Add("InpGrsProfChkUppDiv");
            // --- ADD 2008/07/22 --------------------------------<<<<< 

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            if (!this.PrmSubstCondDivCd.Equals(target.PrmSubstCondDivCd))   resList.Add("PrmSubstCondDivCd");
            if (!this.SubstApplyDivCd.Equals(target.SubstApplyDivCd))       resList.Add("SubstApplyDivCd");
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<
            if (!this.PartsNameDspDivCd.Equals(target.PartsNameDspDivCd)) resList.Add("PartsNameDspDivCd");   // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
            if (!this.FrSrchPrtAutoEntDiv.Equals(target.FrSrchPrtAutoEntDiv)) resList.Add("FrSrchPrtAutoEntDiv");   // ADD 2010/04/30
            if (this.BLGoodsCdDerivNoDiv != target.BLGoodsCdDerivNoDiv) resList.Add("BLGoodsCdDerivNoDiv");
            
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            if (this.BLCdPrtsNmDspDivCd1 != target.BLCdPrtsNmDspDivCd1) resList.Add("BLCdPrtsNmDspDivCd1");
            if (this.BLCdPrtsNmDspDivCd2 != target.BLCdPrtsNmDspDivCd2) resList.Add("BLCdPrtsNmDspDivCd2");
            if (this.BLCdPrtsNmDspDivCd3 != target.BLCdPrtsNmDspDivCd3) resList.Add("BLCdPrtsNmDspDivCd3");
            if (this.BLCdPrtsNmDspDivCd4 != target.BLCdPrtsNmDspDivCd4) resList.Add("BLCdPrtsNmDspDivCd4");
            if (this.GdNoPrtsNmDspDivCd1 != target.GdNoPrtsNmDspDivCd1) resList.Add("GdNoPrtsNmDspDivCd1");
            if (this.GdNoPrtsNmDspDivCd2 != target.GdNoPrtsNmDspDivCd2) resList.Add("GdNoPrtsNmDspDivCd2");
            if (this.GdNoPrtsNmDspDivCd3 != target.GdNoPrtsNmDspDivCd3) resList.Add("GdNoPrtsNmDspDivCd3");
            if (this.GdNoPrtsNmDspDivCd4 != target.GdNoPrtsNmDspDivCd4) resList.Add("GdNoPrtsNmDspDivCd4");
            if (this.PrmPrtsNmUseDivCd != target.PrmPrtsNmUseDivCd) resList.Add("PrmPrtsNmUseDivCd");
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            if (this.DwnPLCdSpDivCd != target.DwnPLCdSpDivCd) resList.Add("DwnPLCdSpDivCd");
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            if (this.SalesCdDspDivCd != target.SalesCdDspDivCd) resList.Add("SalesCdDspDivCd");
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            if (this.RentStockDiv != target.RentStockDiv) resList.Add("RentStockDiv");
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            if (this.EpPartsNoPrtCd != target.EpPartsNoPrtCd) resList.Add("EpPartsNoPrtCd");
            if (this.EpPartsNoAddChar != target.EpPartsNoAddChar) resList.Add("EpPartsNoAddChar");
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            if (this.PrintGoodsNoDef != target.PrintGoodsNoDef) resList.Add("PrintGoodsNoDef");
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ----------->>>>>
            if (this.StockRetGoodsPlnDiv != target.StockRetGoodsPlnDiv) resList.Add("StockRetGoodsPlnDiv");
            // --- ADD 2013/01/15 -----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            if (this.BLGoodsCdZeroSuprt != target.BLGoodsCdZeroSuprt) resList.Add("BLGoodsCdZeroSuprt");
            if (this.BLGoodsCdChange != target.BLGoodsCdChange) resList.Add("BLGoodsCdChange");
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            if (this.StockEmpRefDiv != target.StockEmpRefDiv) resList.Add("StockEmpRefDiv");
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
            return resList;
		}

		/// <summary>
		/// 売上全体設定マスタ比較処理
		/// </summary>
		/// <param name="salesTtlSt1">比較するSalesTtlStクラスのインスタンス</param>
		/// <param name="salesTtlSt2">比較するSalesTtlStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTtlStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2009/10/19 朱俊成 表示区分プロセスを追加</br>
        /// <br>Update Note      :   2010/01/29 李侠 受注数入力を追加</br>
        /// <br>Update Note      :   2010/05/04 王海立 発行者チェック区分、入力倉庫チェック区分を追加</br>
        /// <br>Update Note: 2010/08/04 楊明俊 小数点表示区分を追加</br>
        /// <br>Update Note      :   2011/06/07 22008 長内数馬 販売区分表示区分を追加</br>
        /// <br>Update Note      :   2012/04/23 管理NO.611 福田康夫 貸出仕入区分を追加</br>
        /// <br>Update Note      :   2013/01/15 FSI福原 一樹 仕入返品予定機能区分を追加</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号         :   11370030-00 2017/04/13 譚洪</br>
        /// <br>                     Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		public static ArrayList Compare(SalesTtlSt salesTtlSt1, SalesTtlSt salesTtlSt2)
		{
			ArrayList resList = new ArrayList();
			if (salesTtlSt1.CreateDateTime			!= salesTtlSt2.CreateDateTime)			resList.Add("CreateDateTime");
			if (salesTtlSt1.UpdateDateTime			!= salesTtlSt2.UpdateDateTime)			resList.Add("UpdateDateTime");
			if (salesTtlSt1.EnterpriseCode			!= salesTtlSt2.EnterpriseCode)			resList.Add("EnterpriseCode");
			if (salesTtlSt1.FileHeaderGuid			!= salesTtlSt2.FileHeaderGuid)			resList.Add("FileHeaderGuid");
			if (salesTtlSt1.UpdEmployeeCode			!= salesTtlSt2.UpdEmployeeCode)			resList.Add("UpdEmployeeCode");
			if (salesTtlSt1.UpdAssemblyId1			!= salesTtlSt2.UpdAssemblyId1)			resList.Add("UpdAssemblyId1");
			if (salesTtlSt1.UpdAssemblyId2			!= salesTtlSt2.UpdAssemblyId2)			resList.Add("UpdAssemblyId2");
			if (salesTtlSt1.LogicalDeleteCode		!= salesTtlSt2.LogicalDeleteCode)		resList.Add("LogicalDeleteCode");
            if (salesTtlSt1.SectionCode             != salesTtlSt2.SectionCode)             resList.Add("SectionCode");  // ADD 2008/06/06
            if (salesTtlSt1.SalesSlipPrtDiv			!= salesTtlSt2.SalesSlipPrtDiv)			resList.Add("SalesSlipPrtDiv");
			if (salesTtlSt1.ShipmSlipPrtDiv			!= salesTtlSt2.ShipmSlipPrtDiv)			resList.Add("ShipmSlipPrtDiv");
			//if (salesTtlSt1.ZeroPrtDiv				!= salesTtlSt2.ZeroPrtDiv)				resList.Add("ZeroPrtDiv");        // DEL 2008/07/22
			if (salesTtlSt1.ShipmSlipUnPrcPrtDiv	!= salesTtlSt2.ShipmSlipUnPrcPrtDiv)	resList.Add("ShipmSlipUnPrcPrtDiv");
            //if (salesTtlSt1.IoGoodsCntDiv			!= salesTtlSt2.IoGoodsCntDiv)			resList.Add("IoGoodsCntDiv");         // DEL 2008/07/22

            // --- DEL 2008/07/22 -------------------------------->>>>>
            ////----- ueno add ---------- start 2008.02.26
            //if (salesTtlSt1.IoGoodsCntDiv2			!= salesTtlSt2.IoGoodsCntDiv2)			resList.Add("IoGoodsCntDiv2");
            ////----- ueno add ---------- end 2008.02.26
            //if (salesTtlSt1.SalesFormalIn			!= salesTtlSt2.SalesFormalIn)			resList.Add("SalesFormalIn");
            //if (salesTtlSt1.StockDetailConf			!= salesTtlSt2.StockDetailConf)			resList.Add("StockDetailConf");
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            if (salesTtlSt1.GrsProfitCheckLower		!= salesTtlSt2.GrsProfitCheckLower)		resList.Add("GrsProfitCheckLower");
			if (salesTtlSt1.GrsProfitCheckBest		!= salesTtlSt2.GrsProfitCheckBest)		resList.Add("GrsProfitCheckBest");
			if (salesTtlSt1.GrsProfitCheckUpper		!= salesTtlSt2.GrsProfitCheckUpper)		resList.Add("GrsProfitCheckUpper");
			if (salesTtlSt1.GrsProfitChkLowSign		!= salesTtlSt2.GrsProfitChkLowSign)		resList.Add("GrsProfitChkLowSign");
			if (salesTtlSt1.GrsProfitChkBestSign	!= salesTtlSt2.GrsProfitChkBestSign)	resList.Add("GrsProfitChkBestSign");
			if (salesTtlSt1.GrsProfitChkUprSign		!= salesTtlSt2.GrsProfitChkUprSign)		resList.Add("GrsProfitChkUprSign");
			if (salesTtlSt1.GrsProfitChkMaxSign		!= salesTtlSt2.GrsProfitChkMaxSign)		resList.Add("GrsProfitChkMaxSign");
			if (salesTtlSt1.SalesAgentChngDiv		!= salesTtlSt2.SalesAgentChngDiv)		resList.Add("SalesAgentChngDiv");
			if (salesTtlSt1.AcpOdrAgentDispDiv		!= salesTtlSt2.AcpOdrAgentDispDiv)		resList.Add("AcpOdrAgentDispDiv");
			if (salesTtlSt1.BrSlipNote2DispDiv		!= salesTtlSt2.BrSlipNote2DispDiv)		resList.Add("BrSlipNote2DispDiv");
			if (salesTtlSt1.DtlNoteDispDiv			!= salesTtlSt2.DtlNoteDispDiv)			resList.Add("DtlNoteDispDiv");
			if (salesTtlSt1.UnPrcNonSettingDiv		!= salesTtlSt2.UnPrcNonSettingDiv)		resList.Add("UnPrcNonSettingDiv");
            if (salesTtlSt1.EstmateAddUpRemDiv      != salesTtlSt2.EstmateAddUpRemDiv)      resList.Add("EstmateAddUpRemDiv");  // ADD 2008/06/06
            if (salesTtlSt1.AcpOdrrAddUpRemDiv		!= salesTtlSt2.AcpOdrrAddUpRemDiv)		resList.Add("AcpOdrrAddUpRemDiv");
			if (salesTtlSt1.ShipmAddUpRemDiv		!= salesTtlSt2.ShipmAddUpRemDiv)		resList.Add("ShipmAddUpRemDiv");
			if (salesTtlSt1.RetGoodsStockEtyDiv		!= salesTtlSt2.RetGoodsStockEtyDiv)		resList.Add("RetGoodsStockEtyDiv");
			if (salesTtlSt1.ListPriceSelectDiv		!= salesTtlSt2.ListPriceSelectDiv)		resList.Add("ListPriceSelectDiv");
			if (salesTtlSt1.MakerInpDiv				!= salesTtlSt2.MakerInpDiv)				resList.Add("MakerInpDiv");
			if (salesTtlSt1.BLGoodsCdInpDiv			!= salesTtlSt2.BLGoodsCdInpDiv)			resList.Add("BLGoodsCdInpDiv");
			if (salesTtlSt1.SupplierInpDiv			!= salesTtlSt2.SupplierInpDiv)			resList.Add("SupplierInpDiv");
			if (salesTtlSt1.SupplierSlipDelDiv		!= salesTtlSt2.SupplierSlipDelDiv)		resList.Add("SupplierSlipDelDiv");
			if (salesTtlSt1.CustGuideDispDiv		!= salesTtlSt2.CustGuideDispDiv)		resList.Add("CustGuideDispDiv");
			if (salesTtlSt1.SlipChngDivDate			!= salesTtlSt2.SlipChngDivDate)			resList.Add("SlipChngDivDate");
			if (salesTtlSt1.SlipChngDivCost			!= salesTtlSt2.SlipChngDivCost)			resList.Add("SlipChngDivCost");
			if (salesTtlSt1.SlipChngDivUnPrc		!= salesTtlSt2.SlipChngDivUnPrc)		resList.Add("SlipChngDivUnPrc");
			if (salesTtlSt1.SlipChngDivLPrice		!= salesTtlSt2.SlipChngDivLPrice)		resList.Add("SlipChngDivLPrice");
            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 >>>>>>START
            if (salesTtlSt1.RetSlipChngDivCost      != salesTtlSt2.RetSlipChngDivCost)      resList.Add("RetSlipChngDivCost");
            if (salesTtlSt1.RetSlipChngDivUnPrc     != salesTtlSt2.RetSlipChngDivUnPrc)     resList.Add("RetSlipChngDivUnPrc");
            // 2008.12.10 30413 犬飼 返品伝票修正区分の追加 <<<<<<END
            //----- ueno add ---------- start 2008.02.18
			if (salesTtlSt1.AutoDepoKindCode		!= salesTtlSt2.AutoDepoKindCode)		resList.Add("AutoDepoKindCode");
			if (salesTtlSt1.AutoDepoKindName		!= salesTtlSt2.AutoDepoKindName)		resList.Add("AutoDepoKindName");
			if (salesTtlSt1.AutoDepoKindDivCd		!= salesTtlSt2.AutoDepoKindDivCd)		resList.Add("AutoDepoKindDivCd");
			//----- ueno add ---------- end 2008.02.18
			//----- ueno add ---------- start 2008.02.26
			if (salesTtlSt1.DiscountName			!= salesTtlSt2.DiscountName)			resList.Add("DiscountName");
			//----- ueno add ---------- end 2008.02.26

            // --- ADD 2008/06/06 -------------------------------->>>>>
			if (salesTtlSt1.InpAgentDispDiv         != salesTtlSt2.InpAgentDispDiv)         resList.Add("InpAgentDispDiv");
			if (salesTtlSt1.CustOrderNoDispDiv      != salesTtlSt2.CustOrderNoDispDiv)      resList.Add("CustOrderNoDispDiv");
			if (salesTtlSt1.CarMngNoDispDiv         != salesTtlSt2.CarMngNoDispDiv)         resList.Add("CarMngNoDispDiv");
            // --- ADD 2009/10/19 ---------->>>>>
            if (salesTtlSt1.PriceSelectDispDiv      != salesTtlSt2.PriceSelectDispDiv)      resList.Add("PriceSelectDispDiv");
            // --- ADD 2009/10/19 ----------<<<<<
            if (salesTtlSt1.AcpOdrInputDiv 　　　　 != salesTtlSt2.AcpOdrInputDiv) 　　　　 resList.Add("AcpOdrInputDiv");　　           // ADD 2010/01/29 受注数入力を追加
            if (salesTtlSt1.InpAgentChkDiv          != salesTtlSt2.InpAgentChkDiv)          resList.Add("InpAgentChkDiv");               // ADD 2010/05/04 発行者チェック区分を追加
            if (salesTtlSt1.InpWarehChkDiv          != salesTtlSt2.InpWarehChkDiv)          resList.Add("InpWarehChkDiv");               // ADD 2010/05/04 入力倉庫チェック区分を追加
			if (salesTtlSt1.BrSlipNote3DispDiv      != salesTtlSt2.BrSlipNote3DispDiv)      resList.Add("BrSlipNote3DispDiv");
			if (salesTtlSt1.SlipDateClrDivCd        != salesTtlSt2.SlipDateClrDivCd)        resList.Add("SlipDateClrDivCd");
			if (salesTtlSt1.AutoEntryGoodsDivCd     != salesTtlSt2.AutoEntryGoodsDivCd)     resList.Add("AutoEntryGoodsDivCd");
			if (salesTtlSt1.CostCheckDivCd          != salesTtlSt2.CostCheckDivCd)          resList.Add("CostCheckDivCd");
			if (salesTtlSt1.JoinInitDispDiv         != salesTtlSt2.JoinInitDispDiv)         resList.Add("JoinInitDispDiv");
			if (salesTtlSt1.AutoDepositCd           != salesTtlSt2.AutoDepositCd)           resList.Add("AutoDepositCd");
            if (salesTtlSt1.AutoDepositNoteDiv      != salesTtlSt2.AutoDepositNoteDiv)      resList.Add("AutoDepositNoteDiv");   // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
			if (salesTtlSt1.SubstCondDivCd          != salesTtlSt2.SubstCondDivCd)          resList.Add("SubstCondDivCd");
			if (salesTtlSt1.SlipCreateProcess       != salesTtlSt2.SlipCreateProcess)       resList.Add("SlipCreateProcess");
			if (salesTtlSt1.WarehouseChkDiv         != salesTtlSt2.WarehouseChkDiv)         resList.Add("WarehouseChkDiv");
			if (salesTtlSt1.PartsSearchDivCd        != salesTtlSt2.PartsSearchDivCd)        resList.Add("PartsSearchDivCd");
			if (salesTtlSt1.GrsProfitDspCd          != salesTtlSt2.GrsProfitDspCd)          resList.Add("GrsProfitDspCd");
			if (salesTtlSt1.PartsSearchPriDivCd     != salesTtlSt2.PartsSearchPriDivCd)     resList.Add("PartsSearchPriDivCd");
			if (salesTtlSt1.SalesStockDiv           != salesTtlSt2.SalesStockDiv)           resList.Add("SalesStockDiv");
			if (salesTtlSt1.PrtBLGoodsCodeDiv       != salesTtlSt2.PrtBLGoodsCodeDiv)       resList.Add("PrtBLGoodsCodeDiv");
			if (salesTtlSt1.SectDspDivCd            != salesTtlSt2.SectDspDivCd)            resList.Add("SectDspDivCd");
			if (salesTtlSt1.GoodsNmReDispDivCd      != salesTtlSt2.GoodsNmReDispDivCd)      resList.Add("GoodsNmReDispDivCd");
			if (salesTtlSt1.CostDspDivCd            != salesTtlSt2.CostDspDivCd)            resList.Add("CostDspDivCd");
			if (salesTtlSt1.DepoSlipDateClrDiv      != salesTtlSt2.DepoSlipDateClrDiv)      resList.Add("DepoSlipDateClrDiv");
            if (salesTtlSt1.DepoSlipDateAmbit       != salesTtlSt2.DepoSlipDateAmbit)       resList.Add("DepoSlipDateAmbit");
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // --- ADD 2008/07/16 -------------------------------->>>>>
            if (salesTtlSt1.InpGrsProfChkLower != salesTtlSt2.InpGrsProfChkLower) resList.Add("InpGrsProfChkLower");
            if (salesTtlSt1.InpGrsProfChkUpper != salesTtlSt2.InpGrsProfChkUpper) resList.Add("InpGrsProfChkUpper");
            if (salesTtlSt1.InpGrsProfChkLowDiv != salesTtlSt2.InpGrsProfChkLowDiv) resList.Add("InpGrsProfChkLowDiv");
            if (salesTtlSt1.InpGrsProfChkUppDiv != salesTtlSt2.InpGrsProfChkUppDiv) resList.Add("InpGrsProfChkUppDiv");
            // --- ADD 2008/07/16 --------------------------------<<<<< 

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            if (!salesTtlSt1.PrmSubstCondDivCd.Equals(salesTtlSt2.PrmSubstCondDivCd))   resList.Add("PrmSubstCondDivCd");
            if (!salesTtlSt1.SubstApplyDivCd.Equals(salesTtlSt2.SubstApplyDivCd))       resList.Add("SubstApplyDivCd");
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<
            if (!salesTtlSt1.PartsNameDspDivCd.Equals(salesTtlSt2.PartsNameDspDivCd)) resList.Add("PartsNameDspDivCd");   // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
            if (!salesTtlSt1.FrSrchPrtAutoEntDiv.Equals(salesTtlSt2.FrSrchPrtAutoEntDiv)) resList.Add("FrSrchPrtAutoEntDiv");   // ADD 2010/04/30
            if (salesTtlSt1.BLGoodsCdDerivNoDiv != salesTtlSt2.BLGoodsCdDerivNoDiv) resList.Add("BLGoodsCdDerivNoDiv");

            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
            if (salesTtlSt1.BLCdPrtsNmDspDivCd1 != salesTtlSt2.BLCdPrtsNmDspDivCd1) resList.Add("BLCdPrtsNmDspDivCd1");
            if (salesTtlSt1.BLCdPrtsNmDspDivCd2 != salesTtlSt2.BLCdPrtsNmDspDivCd2) resList.Add("BLCdPrtsNmDspDivCd2");
            if (salesTtlSt1.BLCdPrtsNmDspDivCd3 != salesTtlSt2.BLCdPrtsNmDspDivCd3) resList.Add("BLCdPrtsNmDspDivCd3");
            if (salesTtlSt1.BLCdPrtsNmDspDivCd4 != salesTtlSt2.BLCdPrtsNmDspDivCd4) resList.Add("BLCdPrtsNmDspDivCd4");
            if (salesTtlSt1.GdNoPrtsNmDspDivCd1 != salesTtlSt2.GdNoPrtsNmDspDivCd1) resList.Add("GdNoPrtsNmDspDivCd1");
            if (salesTtlSt1.GdNoPrtsNmDspDivCd2 != salesTtlSt2.GdNoPrtsNmDspDivCd2) resList.Add("GdNoPrtsNmDspDivCd2");
            if (salesTtlSt1.GdNoPrtsNmDspDivCd3 != salesTtlSt2.GdNoPrtsNmDspDivCd3) resList.Add("GdNoPrtsNmDspDivCd3");
            if (salesTtlSt1.GdNoPrtsNmDspDivCd4 != salesTtlSt2.GdNoPrtsNmDspDivCd4) resList.Add("GdNoPrtsNmDspDivCd4");
            if (salesTtlSt1.PrmPrtsNmUseDivCd != salesTtlSt2.PrmPrtsNmUseDivCd) resList.Add("PrmPrtsNmUseDivCd");
            // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
            // --- ADD 2010/08/04 ---------->>>>>
            if (salesTtlSt1.DwnPLCdSpDivCd != salesTtlSt2.DwnPLCdSpDivCd) resList.Add("DwnPLCdSpDivCd");
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/07 ---------->>>>>
            if (salesTtlSt1.SalesCdDspDivCd != salesTtlSt2.SalesCdDspDivCd) resList.Add("SalesCdDspDivCd");
            // --- ADD 2011/06/07 ----------<<<<<
            // --- ADD 2012/04/23 ---------->>>>>
            if (salesTtlSt1.RentStockDiv != salesTtlSt2.RentStockDiv) resList.Add("RentStockDiv");
            // --- ADD 2012/04/23 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            if (salesTtlSt1.EpPartsNoPrtCd != salesTtlSt2.EpPartsNoPrtCd) resList.Add("EpPartsNoPrtCd");
            if (salesTtlSt1.EpPartsNoAddChar != salesTtlSt2.EpPartsNoAddChar) resList.Add("EpPartsNoAddChar");
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            if (salesTtlSt1.PrintGoodsNoDef != salesTtlSt2.PrintGoodsNoDef) resList.Add("PrintGoodsNoDef");
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            if (salesTtlSt1.StockRetGoodsPlnDiv != salesTtlSt2.StockRetGoodsPlnDiv) resList.Add("StockRetGoodsPlnDiv");
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            if (salesTtlSt1.BLGoodsCdZeroSuprt != salesTtlSt2.BLGoodsCdZeroSuprt) resList.Add("BLGoodsCdZeroSuprt");
            if (salesTtlSt1.BLGoodsCdChange != salesTtlSt2.BLGoodsCdChange) resList.Add("BLGoodsCdChange");
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            if (salesTtlSt1.StockEmpRefDiv != salesTtlSt2.StockEmpRefDiv) resList.Add("StockEmpRefDiv");
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
			return resList;
		}

		/// <summary>するしないリスト</summary>
		public static SortedList _yesNoList;

		/// <summary>しないするリスト</summary>
		public static SortedList _noYesList;

		/// <summary>警告リスト生成</summary>
		public static SortedList _alarmList;

		/// <summary>売上出荷リスト</summary>
		public static SortedList _salesShipmList;

		/// <summary>任意必須リスト</summary>
		public static SortedList _optNecessaryList;

		/// <summary>可能警告不可リスト</summary>
		public static SortedList _enableAlarmList;

		/// <summary>有無必須リスト</summary>
		public static SortedList _onOffNecessaryList;

		/// <summary>有無リスト</summary>
		public static SortedList _onOffList;

		/// <summary>ゼロ定価リスト</summary>
		public static SortedList _zeroLPriceList;

		/// <summary>残す残さないリスト</summary>
		public static SortedList _reserveList;

		/// <summary>確認リスト</summary>
		public static SortedList _noConfYesList;

		/// <summary>表示区分リスト</summary>
		public static SortedList _dispList;

		/// <summary>伝票修正リスト</summary>
		public static SortedList _slipChngDivList;

		/// <summary>伝票修正在庫リスト</summary>
		public static SortedList _slipChngDivStcList;

		//----- ueno add ---------- start 2008.02.18
		/// <summary>自動入金金種リスト</summary>
		public static SortedList _autoDepoKindCodeList;

		/// <summary>金額種別区分リスト</summary>
		public static SortedList _mnyKindDivList;
		//----- ueno add ---------- end 2008.02.18

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// <summary>発行者表示区分リスト</summary>
        public static SortedList _inpAgentDispDivList;

        /// <summary>日付区分リスト</summary>
        public static SortedList _dateList;

        /// <summary>商品自動登録リスト</summary>
        public static SortedList _autoEntryGoodsDivCdList;

        /// <summary>原価チェック区分リスト</summary>
        public static SortedList _costCheckDivCdList;

        /// <summary>結合初期表示区分リスト</summary>
        public static SortedList _joinInitDispDivList;

        /// <summary>代替条件区分リスト</summary>
        public static SortedList _substCondDivCdList;

        /// <summary>伝票作成方法リスト</summary>
        public static SortedList _slipCreateProcessList;

        /// <summary>倉庫チェック区分リスト</summary>
        public static SortedList _warehouseChkDivList;

        /// <summary>部品検索区分リスト</summary>
        public static SortedList _partsSearchDivCdList;

        /// <summary>部品検索優先順区分リスト</summary>
        public static SortedList _partsSearchPriDivCdList;

        /// <summary>売上仕入区分リスト</summary>
        public static SortedList _salesStockDivList;

        /// <summary>印刷用BL商品コード区分リスト</summary>
        public static SortedList _prtBLGoodsCodeDivList;

        /// <summary>拠点表示区分リスト</summary>
        public static SortedList _sectDspDivCdList;

        /// <summary>入金伝票日付範囲区分リスト</summary>
        public static SortedList _depoSlipDateAmbitList;
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        // --- ADD 2008/07/22 -------------------------------->>>>>
        /// <summary>入力粗利チェック区分リスト</summary>
        public static SortedList _inpGrsPrfChkList;
        // --- ADD 2008/07/22 --------------------------------<<<<< 

        // ADD 2008/09/29 不具合対応[5665]---------->>>>>
        /// <summary>優良代替条件区分リスト</summary>
        public static SortedList _prmSubstCondDivCdList;

        /// <summary>代替適用区分リスト</summary>
        public static SortedList _substApplyDivCdList;
        // ADD 2008/09/29 不具合対応[5665]----------<<<<<

        /// <summary>品名表示区分リスト</summary>
        public static SortedList _partsNameDspDivCdList;    // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加

        /// <summary>BL枝番リスト</summary>
        public static SortedList _bLGoodsCdDerivNoDivList;

        // --- ADD 2010/05/04 ---------->>>>>
        /// <summary>発行者チェック区分</summary>
        public static SortedList _inpAgentChkDivList;

        /// <summary>入力倉庫チェック区分</summary>
        public static SortedList _inpWarehChkDivList;
        // --- ADD 2010/05/04 ----------<<<<<

        // --- ADD 2011/06/07 ---------->>>>>
        /// <summary>販売区分表示区分</summary>
        public static SortedList _salesCdDspDivCdList;
        // --- ADD 2011/06/07 ----------<<<<<

        // --- ADD 2012/04/23 ---------->>>>>
        /// <summary>貸出仕入区分</summary>
        public static SortedList _rentStockDivList;
        // --- ADD 2012/04/23 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>自社品番印字区分</summary>
        public static SortedList _EpPartsNoPrtCdList;
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// <summary>印字品番初期値</summary>
        public static SortedList _PrintGoodsNoDefList;
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
        // --- ADD 2013/01/15 ---------->>>>>
        /// <summary>仕入返品予定機能区分</summary>
        public static SortedList _stockRetGoodsPlnDivList;
        // --- ADD 2013/01/15 ----------<<<<<

        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// <summary>自動入金備考区分</summary>
        public static SortedList _autoDepositNoteDivList;
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// <summary>BLコード０対応</summary>
        public static SortedList _BLGoodsCdZeroSuprtList;
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

        // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
        /// <summary>仕入担当参照区分リスト</summary>
        public static SortedList _stockEmpRefDivList;
        // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
        /// <summary>
		/// コンボボックス名称取得処理
		/// </summary>
		/// <param name="code">コンボボックスコード</param>
		/// <returns>コンボボックス名称</returns>
		/// <remarks>
		/// <br>Note       : コンボボックスコードからコンボボックス名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public static string GetComboBoxNm(int code, SortedList sList)
		{
			string retStr = "";

			if (sList.ContainsKey((object)code))
			{
				retStr = sList[code].ToString();
			}
			return retStr;
		}

		/// <summary>
		/// 静的コンストラクタ
		/// </summary>
        /// <remarks>
        /// <br>Update Note: 2013/01/21 cheq</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#33797 自動入金備考区分を追加</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        /// </remarks>
		static SalesTtlSt()
		{
			_yesNoList			= MakeYesNoList();
			_noYesList			= MakeNoYesList();
			_alarmList			= MakeAlarmList();
			_salesShipmList		= MakeSalesShipmList();
			_optNecessaryList	= MakeOptNecessaryList();
			_enableAlarmList	= MakeEnableAlarmList();
			_onOffNecessaryList = MakeOnOffNecessaryList();
			_onOffList			= MakeOnOffList();
			_zeroLPriceList		= MakeZeroLPriceList();
			_reserveList		= MakeReserveList();
			_noConfYesList		= MakeNoConfYesList();
			_dispList			= MakeDispList();
			_slipChngDivList	= MakeSlipChngDivList();
			_slipChngDivStcList = MakeSlipChngDivStcList();

            // --- ADD 2008/06/06 -------------------------------->>>>>
            _inpAgentDispDivList     = MakeInpAgentDispDivList();
            _dateList                = MakeDateList();
            _autoEntryGoodsDivCdList = MakeAutoEntryGoodsDivCdList();
            _costCheckDivCdList      = MakeCostCheckDivCdList();
            _joinInitDispDivList     = MakeJoinInitDispDivList();
            _substCondDivCdList      = MakeSubstCondDivCdList();
            _slipCreateProcessList   = MakeSlipCreateProcessList();
            _warehouseChkDivList     = MakeWarehouseChkDivList();
            _partsSearchDivCdList    = MakePartsSearchDivCdList();
            _partsSearchPriDivCdList = MakePartsSearchPriDivCdList();
            _salesStockDivList       = MakeSalesStockDivList();
            _prtBLGoodsCodeDivList   = MakePrtBLGoodsCodeDivList();
            _sectDspDivCdList        = MakeSectDspDivCdList();
            _depoSlipDateAmbitList   = MakeDepoSlipDateAmbitList();
            _inpGrsPrfChkList        = MakeInpGrsPrfChkList();
            // --- ADD 2008/06/06 --------------------------------<<<<<

            // ADD 2008/09/29 不具合対応[5665]---------->>>>>
            _prmSubstCondDivCdList  = MakePrmSubstCondDivCdList();
            _substApplyDivCdList    = MakeSubstApplyDivCdList();
            // ADD 2008/09/29 不具合対応[5665]----------<<<<<
            _partsNameDspDivCdList = MakePartsNameDspDivCdList();   // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加
            _bLGoodsCdDerivNoDivList = MakeBLGoodsCdDerivNoDivList();
            // --- ADD 2010/05/04 ---------->>>>>
            _inpAgentChkDivList = MakeInpAgentChkDivListt();
            _inpWarehChkDivList = MakeInpWarehChkDivList();
            // --- ADD 2010/05/04 ----------<<<<<
            _salesCdDspDivCdList = MakeSalesCdDspDivCdList();// ADD 2011/06/07
            _rentStockDivList = MakeRentStockDivList();// ADD 2012/04/23
            _EpPartsNoPrtCdList = MakeEpPartsNoPrtCdList();                   // ADD 2012/12/27 Y.Wakita
            _PrintGoodsNoDefList = MakePrintGoodsNoDefList();                 // ADD 2013/01/16 Y.Wakita
            // --- ADD 2013/01/15 ---------->>>>>
            _stockRetGoodsPlnDivList = MakeStockRetGoodsPlnDivList();
            // --- ADD 2013/01/15 ----------<<<<<
            _autoDepositNoteDivList = MakeAutoDepositNoteDivList(); // 自動入金備考区分 // ADD cheq 2013/01/21 Redmine#33797
            _BLGoodsCdZeroSuprtList = MakeBLGoodsCdZeroSuprtList();                   // ADD 2013/02/05 Y.Wakita
            // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
            _stockEmpRefDivList = MakeStockEmpRefDivList(); // 仕入担当参照区分
            // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<
        }

        private static SortedList MakeBLGoodsCdDerivNoDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "枝番なし");
            retSortedList.Add(1, "枝番あり");
            return retSortedList;
        }

		/// <summary>
		/// するしないリスト生成
		/// </summary>
		/// <returns>するしないのリスト</returns>
		/// <remarks>
		/// <br>Note	   : するしないのリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeYesNoList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "する");
			retSortedList.Add(1, "しない");
			return retSortedList;
		}

		/// <summary>
		/// しないするリスト生成
		/// </summary>
		/// <returns>しないするリスト</returns>
		/// <remarks>
		/// <br>Note	   : しないするリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeNoYesList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "しない");
			retSortedList.Add(1, "する");
			return retSortedList;
		}

		/// <summary>
		/// 警告リスト生成
		/// </summary>
		/// <returns>警告リスト</returns>
		/// <remarks>
		/// <br>Note	   : 警告リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeAlarmList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "警告無し");
			retSortedList.Add(1, "警告");
			retSortedList.Add(2, "警告＋再入力");
			return retSortedList;
		}

		/// <summary>
		/// 売上出荷リスト生成
		/// </summary>
		/// <returns>売上出荷リスト</returns>
		/// <remarks>
		/// <br>Note	   : 売上出荷リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeSalesShipmList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "売上");
			retSortedList.Add(1, "出荷");
			return retSortedList;
		}

		/// <summary>
		/// 任意必須リスト生成
		/// </summary>
		/// <returns>任意必須リスト</returns>
		/// <remarks>
		/// <br>Note	   : 任意必須リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeOptNecessaryList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "任意");
			retSortedList.Add(1, "必須");
			return retSortedList;
		}

		/// <summary>
		/// 可能警告不可リスト生成
		/// </summary>
		/// <returns>可能警告不可リスト</returns>
		/// <remarks>
		/// <br>Note	   : 可能警告不可リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeEnableAlarmList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "可能");
			retSortedList.Add(1, "変更時警告");
			retSortedList.Add(2, "不可");
			return retSortedList;
		}

		/// <summary>
		/// 有無必須リスト生成
		/// </summary>
		/// <returns>有無必須リスト</returns>
		/// <remarks>
		/// <br>Note	   : 有無必須リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeOnOffNecessaryList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "有り");
			retSortedList.Add(1, "無し");
			retSortedList.Add(2, "必須");
			return retSortedList;
		}

		/// <summary>
		/// 有無リスト生成
		/// </summary>
		/// <returns>有無リスト</returns>
		/// <remarks>
		/// <br>Note	   : 有無リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeOnOffList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "有り");
			retSortedList.Add(1, "無し");
			return retSortedList;
		}

		/// <summary>
		/// ゼロ定価リスト生成
		/// </summary>
		/// <returns>ゼロ定価リスト</returns>
		/// <remarks>
		/// <br>Note	   : ゼロ定価リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeZeroLPriceList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "ゼロを表示");
			retSortedList.Add(1, "定価を表示");
			return retSortedList;
		}

		/// <summary>
		/// 残す残さないリスト生成
		/// </summary>
		/// <returns>残す残さないリスト</returns>
		/// <remarks>
		/// <br>Note	   : 残す残さないリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeReserveList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "残す");
			retSortedList.Add(1, "残さない");
			return retSortedList;
		}

		/// <summary>
		/// 確認リスト生成
		/// </summary>
		/// <returns>確認リスト</returns>
		/// <remarks>
		/// <br>Note	   : 確認リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeNoConfYesList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(0, "しない");
			retSortedList.Add(1, "確認");
			retSortedList.Add(2, "する");
			return retSortedList;
		}

		/// <summary>
		/// 表示区分リスト生成
		/// </summary>
		/// <returns>表示区分リスト</returns>
		/// <remarks>
		/// <br>Note	   : 表示区分リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeDispList()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(1, "自拠点のみ表示");
			retSortedList.Add(0, "全て表示");
			return retSortedList;
		}

		/// <summary>
		/// 伝票修正リスト生成
		/// </summary>
		/// <returns>伝票修正リスト</returns>
		/// <remarks>
		/// <br>Note	   : 伝票修正リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeSlipChngDivList()
		{
			SortedList retSortedList = new SortedList();
            // 2008.12.11 30413 犬飼 項目変更 >>>>>>START
			retSortedList.Add(0, "可能");
            //retSortedList.Add(1, "返品伝票以外可");
            //retSortedList.Add(2, "返品伝票のみ可");
            //retSortedList.Add(3, "不可");
            retSortedList.Add(1, "不可");
            retSortedList.Add(2, "未使用");
            retSortedList.Add(3, "在庫時不可");
            // 2008.12.11 30413 犬飼 項目変更 <<<<<<END
            return retSortedList;
		}

		/// <summary>
		/// 伝票修正在庫リスト生成
		/// </summary>
		/// <returns>伝票修正在庫リスト</returns>
		/// <remarks>
		/// <br>Note	   : 伝票修正在庫リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		private static SortedList MakeSlipChngDivStcList()
		{
			SortedList retSortedList = new SortedList();
            // 2008.12.11 30413 犬飼 項目変更 >>>>>>START
            retSortedList.Add(0, "可能");
			retSortedList.Add(1, "不可");
            //retSortedList.Add(2, "在庫がある場合修正可");
            // 2008.12.11 30413 犬飼 項目変更 <<<<<<END
            return retSortedList;
		}

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// <summary>
        /// 発行者表示区分リスト生成
        /// </summary>
        /// <returns>発行者表示区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 発行者表示区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeInpAgentDispDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "する");
            retSortedList.Add(1, "しない");
            retSortedList.Add(2, "必須");
            return retSortedList;
        }

        /// <summary>
        /// 日付区分リスト生成
        /// </summary>
        /// <returns>日付区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 日付区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeDateList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "システム日付");
            retSortedList.Add(1, "入力日付");
            return retSortedList;
        }

        /// <summary>
        /// 商品自動登録リスト生成
        /// </summary>
        /// <returns>商品自動登録リスト</returns>
        /// <remarks>
        /// <br>Note	   : 商品自動登録リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeAutoEntryGoodsDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "なし");
            retSortedList.Add(1, "あり");
            return retSortedList;
        }

        /// <summary>
        /// 原価チェック区分リスト生成
        /// </summary>
        /// <returns>原価チェック区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 原価チェック区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeCostCheckDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "無視");
            retSortedList.Add(1, "再入力");
            retSortedList.Add(2, "警告MSG");
            return retSortedList;
        }

        /// <summary>
        /// 結合初期表示区分リスト生成
        /// </summary>
        /// <returns>結合初期表示区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 結合初期表示区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeJoinInitDispDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "表示順");
            retSortedList.Add(1, "在庫順");
            return retSortedList;
        }

        /// <summary>
        /// 代替条件区分リスト生成
        /// </summary>
        /// <returns>代替条件区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 代替条件区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeSubstCondDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "代替しない");
            retSortedList.Add(1, "代替する(在庫無)");
            retSortedList.Add(2, "代替する(在庫無視)");
            return retSortedList;
        }

        /// <summary>
        /// 伝票作成方法リスト生成
        /// </summary>
        /// <returns>伝票作成方法リスト</returns>
        /// <remarks>
        /// <br>Note	   : 伝票作成方法リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeSlipCreateProcessList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "入力順");
            retSortedList.Add(1, "在庫別");
            retSortedList.Add(2, "倉庫別");
            retSortedList.Add(3, "出力先別");
            return retSortedList;
        }

        /// <summary>
        /// 倉庫チェック区分リスト生成
        /// </summary>
        /// <returns>倉庫チェック区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 倉庫チェック区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeWarehouseChkDivList()
        {
            SortedList retSortedList = new SortedList();
            // 2008.12.11 30413 犬飼 項目変更 >>>>>>START
            //retSortedList.Add(0, "警告");
            //retSortedList.Add(1, "無視");
            retSortedList.Add(0, "無視");
            retSortedList.Add(1, "再入力");
            retSortedList.Add(2, "警告");
            // 2008.12.11 30413 犬飼 項目変更 >>>>>>START
            return retSortedList;
        }

        /// <summary>
        /// 部品検索区分リスト生成
        /// </summary>
        /// <returns>部品検索区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 部品検索区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakePartsSearchDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "部品検索");
            retSortedList.Add(1, "品番検索");
            return retSortedList;
        }

        /// <summary>
        /// 部品検索優先順区分リスト生成
        /// </summary>
        /// <returns>部品検索優先順区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 部品検索優先順区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakePartsSearchPriDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "純正");
            retSortedList.Add(1, "優良");
            return retSortedList;
        }

        /// <summary>
        /// 売上仕入区分リスト生成
        /// </summary>
        /// <returns>売上仕入区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 売上仕入区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeSalesStockDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "しない");
            retSortedList.Add(1, "する");
            retSortedList.Add(2, "必須入力");
            return retSortedList;
        }

        /// <summary>
        /// 印刷用BL商品コード区分リスト生成
        /// </summary>
        /// <returns>印刷用BL商品コード区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 印刷用BL商品コード区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakePrtBLGoodsCodeDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "部品");
            retSortedList.Add(1, "検索");
            return retSortedList;
        }

        /// <summary>
        /// 拠点表示区分リスト生成
        /// </summary>
        /// <returns>拠点表示区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 拠点表示区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeSectDspDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "標準");
            retSortedList.Add(1, "自拠点");
            retSortedList.Add(2, "表示無し");
            return retSortedList;
        }

        /// <summary>
        /// 入金伝票日付範囲区分リスト生成
        /// </summary>
        /// <returns>入金伝票日付範囲区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 入金伝票日付範囲区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private static SortedList MakeDepoSlipDateAmbitList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "制限なし");
            retSortedList.Add(1, "システム日付以降入力不可");
            return retSortedList;
        }
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        // --- ADD 2017/04/13 譚洪 Redmine#49283---------->>>>>
        /// <summary>
        /// 仕入担当参照区分リスト生成
        /// </summary>
        /// <returns>仕入担当参照区分リスト</returns>
        /// <remarks>
        /// <br>Note	   : 仕入担当参照区分リストを生成します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/13</br>
        /// </remarks>
        private static SortedList MakeStockEmpRefDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "仕入先マスタ");
            retSortedList.Add(1, "画面担当者");
            return retSortedList;
        }
        // --- ADD 2017/04/13 譚洪 Redmine#49283----------<<<<<

        // --- ADD 2008/07/22 -------------------------------->>>>>
        /// <summary>
        /// 入力粗利チェック下限区分リスト生成
        /// </summary>
        /// <returns>入力粗利チェック下限区分リスト</returns>
        /// <remarks>
        /// <br>Note	   :入力粗利チェック下限区分リストを生成します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/07/22</br>
        /// </remarks>
        private static SortedList MakeInpGrsPrfChkList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "再入力");
            retSortedList.Add(1, "警告");
            retSortedList.Add(2, "無視");
            return retSortedList;
        }
        // --- ADD 2008/07/22 --------------------------------<<<<<

        // ADD 2008/09/29 不具合対応[5665]---------->>>>>
        /// <summary>
        /// 優良代替条件区分リストを生成します。
        /// </summary>
        /// <remarks>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</remarks>
        /// <returns>優良代替条件区分リスト</returns>
        private static SortedList MakePrmSubstCondDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "代替しない");
            retSortedList.Add(1, "代替する(在庫無)");
            retSortedList.Add(2, "代替する(在庫無視)");
            return retSortedList;
        }

        /// <summary>
        /// 代替適用区分リストを生成します。
        /// </summary>
        /// <remarks>0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）</remarks>
        /// <returns>代替適用区分リスト</returns>
        private static SortedList MakeSubstApplyDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "代替しない");
            retSortedList.Add(1, "代替する(結合、セット)");
            retSortedList.Add(2, "全て(結合、セット、純正)");
            return retSortedList;
        }
        // ADD 2008/09/29 不具合対応[5665]----------<<<<<

        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ---------->>>>>
        /// <summary>
        /// 品名表示区分リストを生成します。
        /// </summary>
        /// <remarks>0:商品優先, 1:提供優先</remarks>
        /// <returns>品名表示区分リスト</returns>
        private static SortedList MakePartsNameDspDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "商品優先");
            retSortedList.Add(1, "提供優先");
            retSortedList.Add(2, "任意設定");   // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加
            return retSortedList;
        }
        // ADD 2008/11/05 不具合対応[7101] 品名表示区分の追加 ----------<<<<<

        // --- ADD 2010/05/04 ---------->>>>>
        /// <summary>
        /// 発行者チェック区分リストを生成します。
        /// </summary>
        /// <remarks>0:無視 1:再入力 2:警告</remarks>
        /// <returns>発行者チェック区分リスト</returns>
        private static SortedList MakeInpAgentChkDivListt()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "無視");
            retSortedList.Add(1, "再入力");
            retSortedList.Add(2, "警告");
            return retSortedList;
        }

        /// <summary>
        /// 入力倉庫チェック区分リストを生成します。
        /// </summary>
        /// <remarks>0:無視 1:再入力 2:警告</remarks>
        /// <returns>入力倉庫チェック区分リスト</returns>
        private static SortedList MakeInpWarehChkDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "無視");
            retSortedList.Add(1, "再入力");
            retSortedList.Add(2, "警告");
            return retSortedList;
        }
        // --- ADD 2010/05/04 ----------<<<<<
        
        // -- ADD 2011/06/07 ------------------->>>
        /// <summary>
        /// 販売区分表示区分リストを生成します。
        /// </summary>
        /// <remarks>0:する 1:しない 2:必須</remarks>
        /// <returns>販売区分表示区分リスト</returns>
        private static SortedList MakeSalesCdDspDivCdList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "する");
            retSortedList.Add(1, "しない");
            retSortedList.Add(2, "必須");
            return retSortedList;
        }
        // -- ADD 2011/06/07 -------------------<<<

        // -- ADD 2012/04/23 ------------------->>>
        /// <summary>
        /// 貸出仕入区分リストを生成します。</br>
        /// </summary>
        /// <remarks> 0:しない 1:する 2:必須入力</remarks>
        /// <returns>貸出仕入区分リスト</returns>
        private static SortedList MakeRentStockDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "しない");
            retSortedList.Add(1, "する");
            retSortedList.Add(2, "必須入力");
            return retSortedList;
        }
        // -- ADD 2012/04/23 -------------------<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>
        /// 自社品番印字区分を生成します。</br>
        /// </summary>
        /// <remarks> 0:する 1:しない</remarks>
        /// <returns>自社品番印字区分リスト</returns>
        private static SortedList MakeEpPartsNoPrtCdList()
        {
            SortedList retSortedList = new SortedList();
            // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
            //// --- UPD 2013/01/09 T.Nishi ---------->>>>>
            ////retSortedList.Add(0, "しない");
            ////retSortedList.Add(1, "する");
            //retSortedList.Add(0, "優良");
            //retSortedList.Add(1, "自社");
            //retSortedList.Add(2, "無し");
            //// --- UPD 2013/01/09 T.Nishi ----------<<<<<
            retSortedList.Add(0, "しない");
            retSortedList.Add(1, "する");
            // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
            return retSortedList;
        }
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// <summary>
        /// 印字品番初期値を生成します。</br>
        /// </summary>
        /// <remarks> 0:優良 1:自社 2:無し</remarks>
        /// <returns>印字品番初期値リスト</returns>
        private static SortedList MakePrintGoodsNoDefList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "優良");
            retSortedList.Add(1, "自社");
            retSortedList.Add(2, "無し");
            return retSortedList;
        }
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
        
        // --- ADD 2013/01/15 ---------->>>>>
        /// <summary>
        /// 仕入返品予定機能区分リストを生成します。</br>
        /// </summary>
        /// <remarks> 0:無効 1:有効</remarks>
        /// <returns>仕入返品予定機能区分リスト</returns>
        private static SortedList MakeStockRetGoodsPlnDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "しない");
            retSortedList.Add(1, "する");
            return retSortedList;
        }
        // --- ADD 2013/01/15 ----------<<<<<

        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// <summary>
        /// 自動入金備考区分リストを生成します。</br>
        /// </summary>
        /// <returns>自動入金備考区分リスト</returns>
        /// <remarks>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>管理番号         :   10806793-00 2013/03/13配信分</br>
        /// <br>                     Redmine#33797 自動入金備考区分を追加</br>
        /// </remarks>
        private static SortedList MakeAutoDepositNoteDivList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "売上伝票番号");
            retSortedList.Add(1, "売上伝票備考");
            retSortedList.Add(2, "無し");
            return retSortedList;
        }
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// <summary>
        /// BLコード０対応を生成します。</br>
        /// </summary>
        /// <remarks> 0:しない 1:する</remarks>
        /// <returns>BLコード０対応リスト</returns>
        private static SortedList MakeBLGoodsCdZeroSuprtList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "しない");
            retSortedList.Add(1, "する");
            return retSortedList;
        }
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

        // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ---------->>>>>
        private int _blCdPrtsNmDspDivCd1;
        /// <summary>BLコード検索品名表示区分１</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int BLCdPrtsNmDspDivCd1
        {
            get { return _blCdPrtsNmDspDivCd1; }
            set { _blCdPrtsNmDspDivCd1 = value; }
        }

        private int _blCdPrtsNmDspDivCd2;
        /// <summary>BLコード検索品名表示区分２</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int BLCdPrtsNmDspDivCd2
        {
            get { return _blCdPrtsNmDspDivCd2; }
            set { _blCdPrtsNmDspDivCd2 = value; }
        }

        private int _blCdPrtsNmDspDivCd3;
        /// <summary>BLコード検索品名表示区分３</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int BLCdPrtsNmDspDivCd3
        {
            get { return _blCdPrtsNmDspDivCd3; }
            set { _blCdPrtsNmDspDivCd3 = value; }
        }

        private int _blCdPrtsNmDspDivCd4;
        /// <summary>BLコード検索品名表示区分４</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int BLCdPrtsNmDspDivCd4
        {
            get { return _blCdPrtsNmDspDivCd4; }
            set { _blCdPrtsNmDspDivCd4 = value; }
        }

        private int _gdNoPrtsNmDspDivCd1;
        /// <summary>品番検索品名表示区分１</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int GdNoPrtsNmDspDivCd1
        {
            get { return _gdNoPrtsNmDspDivCd1; }
            set { _gdNoPrtsNmDspDivCd1 = value; }
        }

        private int _gdNoPrtsNmDspDivCd2;
        /// <summary>品番検索品名表示区分２</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int GdNoPrtsNmDspDivCd2
        {
            get { return _gdNoPrtsNmDspDivCd2; }
            set { _gdNoPrtsNmDspDivCd2 = value; }
        }

        private int _gdNoPrtsNmDspDivCd3;
        /// <summary>品番検索品名表示区分３</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int GdNoPrtsNmDspDivCd3
        {
            get { return _gdNoPrtsNmDspDivCd3; }
            set { _gdNoPrtsNmDspDivCd3 = value; }
        }

        private int _gdNoPrtsNmDspDivCd4;
        /// <summary>品番検索品名表示区分４</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        public int GdNoPrtsNmDspDivCd4
        {
            get { return _gdNoPrtsNmDspDivCd4; }
            set { _gdNoPrtsNmDspDivCd4 = value; }
        }

        private int _prmPrtsNmUseDivCd;
        /// <summary>優良部品検索品名使用区分</summary>
        /// <remarks>0:使用 1:未使用</remarks>
        public int PrmPrtsNmUseDivCd
        {
            get { return _prmPrtsNmUseDivCd; }
            set { _prmPrtsNmUseDivCd = value; }
        }

        /// <summary>
        /// 品名表示区分の値列挙型
        /// </summary>
        public enum PartsNameDspDivCdValue : int
        {
            /// <summary>0:商品優先</summary>
            Goods = 0,
            /// <summary>1:提供優先</summary>
            Offer = 1,
            /// <summary>2:任意設定</summary>
            Option = 2
        }

        /// <summary>
        /// 検索時の品名表示区分の値列挙型
        /// </summary>
        public enum PrtsNmDspDivCdValue : int
        {
            /// <summary>0:無し</summary>
            None = 0,
            /// <summary>1:商品マスタ</summary>
            GoodsMaster = 1,
            /// <summary>2:部品マスタ</summary>
            PartsMaster = 2,
            /// <summary>3:検索品名マスタ</summary>
            SearchedGoodsNameMaster = 3,
            /// <summary>4:BLコードマスタ</summary>
            BLCodeMaster = 4
        }

        /// <summary>
        /// 優良部品検索品名使用区分の値列挙型
        /// </summary>
        public enum PrmPrtsNmUseDivCdValue : int
        {
            /// <summary>0:使用</summary>
            Using = 0,
            /// <summary>1:未使用</summary>
            NotUsing = 1
        }
        // ADD 2010/05/14 品名表示対応：品名表示区分の詳細設定を追加 ----------<<<<<
	}
}
