using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockAcPayHisSearchRet
	/// <summary>
	///                      在庫受払履歴抽出結果クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫受払履歴抽出結果クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/22  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockAcPayHisSearchRet
	{
		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>入出荷日</summary>
		private DateTime _ioGoodsDay;

		/// <summary>受払元伝票番号</summary>
		/// <remarks>「受払元伝票」の伝票番号を格納</remarks>
		private string _acPaySlipNum = "";

		/// <summary>受払元伝票区分</summary>
		/// <remarks>10:仕入,11:入荷,12:受計上,20:売上,21:売計上,22:出荷,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸(名称変更 11:受託->入荷　22:委託->出荷）</remarks>
		private Int32 _acPaySlipCd;

		/// <summary>受払元取引区分</summary>
		/// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,36:一括登録,40:過不足更新,90:取消</remarks>
		private Int32 _acPayTransCd;

		/// <summary>移動先拠点コード</summary>
		/// <remarks>移動（出荷）の場合は 相手情報　　移動（入荷）の場合は自情報</remarks>
		private string _afSectionCode = "";

		/// <summary>移動先拠点ガイド名称</summary>
		/// <remarks>同上</remarks>
		private string _afSectionGuideNm = "";

		/// <summary>移動先倉庫コード</summary>
		/// <remarks>同上</remarks>
		private string _afEnterWarehCode = "";

		/// <summary>移動先倉庫名称</summary>
		/// <remarks>同上</remarks>
		private string _afEnterWarehName = "";

		/// <summary>移動先棚番</summary>
		/// <remarks>同上</remarks>
		private string _afShelfNo = "";

		/// <summary>出荷数（未計上）</summary>
		/// <remarks>貸出、出荷と同意</remarks>
		private Double _nonAddUpShipmCnt;

		/// <summary>入荷数（未計上）</summary>
		/// <remarks>入荷</remarks>
		private Double _nonAddUpArrGdsCnt;

		/// <summary>定価（税抜，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>仕入単価（税抜，浮動）</summary>
		/// <remarks>売上の場合原価単価</remarks>
		private Double _stockUnitPriceFl;

		/// <summary>計上日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _addUpADate;

		/// <summary>受払元行番号</summary>
		/// <remarks>「受払元伝票」の伝票行番号を格納</remarks>
		private Int32 _acPaySlipRowNo;

		/// <summary>入力拠点コード</summary>
		/// <remarks>入力を行った拠点ｺｰﾄﾞ</remarks>
		private string _inputSectionCd = "";

		/// <summary>入力拠点ガイド名称</summary>
		private string _inputSectionGuidNm = "";

		/// <summary>入力担当者コード</summary>
		private string _inputAgenCd = "";

		/// <summary>入力担当者名称</summary>
		private string _inputAgenNm = "";

		/// <summary>移動状態</summary>
		/// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
		private Int32 _moveStatus;

		/// <summary>相手先伝票番号</summary>
		/// <remarks>得意先伝票番号、仕入先伝票番号</remarks>
		private string _custSlipNo = "";

		/// <summary>明細通番</summary>
		private Int64 _slipDtlNum;

		/// <summary>受払備考</summary>
		/// <remarks>受払した情報を格納</remarks>
		private string _acPayNote = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>移動元拠点コード</summary>
		/// <remarks>移動（出荷）の場合は 自情報　　移動（入荷）の場合は相手情報</remarks>
		private string _bfSectionCode = "";

		/// <summary>移動元拠点ガイド名称</summary>
		/// <remarks>同上</remarks>
		private string _bfSectionGuideNm = "";

		/// <summary>移動元倉庫コード</summary>
		/// <remarks>同上</remarks>
		private string _bfEnterWarehCode = "";

		/// <summary>移動元倉庫名称</summary>
		/// <remarks>同上</remarks>
		private string _bfEnterWarehName = "";

		/// <summary>移動元棚番</summary>
		/// <remarks>同上</remarks>
		private string _bfShelfNo = "";

		/// <summary>得意先コード</summary>
		/// <remarks>売上時の得意先コードをセット</remarks>
		private Int32 _customerCode;

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>仕入時の仕入先コードをセット</remarks>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>オープン価格区分</summary>
		/// <remarks>0:通常／1:オープン価格</remarks>
		private Int32 _openPriceDiv;

		/// <summary>仕入金額</summary>
		/// <remarks>売上の場合原価金額</remarks>
		private Int64 _stockPrice;

		/// <summary>売上単価（税抜，浮動）</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>売上金額</summary>
		/// <remarks>税抜き</remarks>
		private Int64 _salesMoney;

		/// <summary>仕入在庫数</summary>
		/// <remarks>入荷数(未計上）、出荷数(未計上）を含まない在庫数（自社在庫）</remarks>
		private Double _supplierStock;

		/// <summary>受注数</summary>
		private Double _acpOdrCount;

		/// <summary>発注数</summary>
		private Double _salesOrderCount;

		/// <summary>移動中仕入在庫数</summary>
		/// <remarks>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</remarks>
		private Double _movingSupliStock;

		/// <summary>出荷可能数</summary>
		/// <remarks>出荷可能数＝仕入在庫数＋入荷数(未計上）－出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
		private Double _shipmentPosCnt;

		/// <summary>現在庫数量</summary>
		/// <remarks>現在庫数量＝仕入在庫数＋入荷数（未計上）－出荷数（未計上）－移動中仕入在庫数</remarks>
		private Double _presentStockCnt;

		/// <summary>入荷数</summary>
		/// <remarks>仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット</remarks>
		private Double _arrivalCnt;

		/// <summary>出荷数</summary>
		/// <remarks>売上入力、在庫移動（出荷）時にセット</remarks>
		private Double _shipmentCnt;

		/// <summary>受払履歴作成日時</summary>
		/// <remarks>DateTime:精度は100ナノ秒</remarks>
		private DateTime _acPayHistDateTime;

		/// <summary>棚番</summary>
		/// <remarks>出荷、入荷が発生する棚番</remarks>
		private string _shelfNo = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";


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

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakerName
		{
			get{return _makerName;}
			set{_makerName = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  IoGoodsDay
		/// <summary>入出荷日プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入出荷日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime IoGoodsDay
		{
			get{return _ioGoodsDay;}
			set{_ioGoodsDay = value;}
		}

		/// public propaty name  :  IoGoodsDayJpFormal
		/// <summary>入出荷日 和暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入出荷日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string IoGoodsDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  IoGoodsDayJpInFormal
		/// <summary>入出荷日 和暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入出荷日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string IoGoodsDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  IoGoodsDayAdFormal
		/// <summary>入出荷日 西暦プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入出荷日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string IoGoodsDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  IoGoodsDayAdInFormal
		/// <summary>入出荷日 西暦(略)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入出荷日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string IoGoodsDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _ioGoodsDay);}
			set{}
		}

		/// public propaty name  :  AcPaySlipNum
		/// <summary>受払元伝票番号プロパティ</summary>
		/// <value>「受払元伝票」の伝票番号を格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcPaySlipNum
		{
			get{return _acPaySlipNum;}
			set{_acPaySlipNum = value;}
		}

		/// public propaty name  :  AcPaySlipCd
		/// <summary>受払元伝票区分プロパティ</summary>
		/// <value>10:仕入,11:入荷,12:受計上,20:売上,21:売計上,22:出荷,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸(名称変更 11:受託->入荷　22:委託->出荷）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPaySlipCd
		{
			get{return _acPaySlipCd;}
			set{_acPaySlipCd = value;}
		}

		/// public propaty name  :  AcPayTransCd
		/// <summary>受払元取引区分プロパティ</summary>
		/// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,36:一括登録,40:過不足更新,90:取消</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元取引区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPayTransCd
		{
			get{return _acPayTransCd;}
			set{_acPayTransCd = value;}
		}

		/// public propaty name  :  AfSectionCode
		/// <summary>移動先拠点コードプロパティ</summary>
		/// <value>移動（出荷）の場合は 相手情報　　移動（入荷）の場合は自情報</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfSectionCode
		{
			get{return _afSectionCode;}
			set{_afSectionCode = value;}
		}

		/// public propaty name  :  AfSectionGuideNm
		/// <summary>移動先拠点ガイド名称プロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfSectionGuideNm
		{
			get{return _afSectionGuideNm;}
			set{_afSectionGuideNm = value;}
		}

		/// public propaty name  :  AfEnterWarehCode
		/// <summary>移動先倉庫コードプロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfEnterWarehCode
		{
			get{return _afEnterWarehCode;}
			set{_afEnterWarehCode = value;}
		}

		/// public propaty name  :  AfEnterWarehName
		/// <summary>移動先倉庫名称プロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfEnterWarehName
		{
			get{return _afEnterWarehName;}
			set{_afEnterWarehName = value;}
		}

		/// public propaty name  :  AfShelfNo
		/// <summary>移動先棚番プロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動先棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfShelfNo
		{
			get{return _afShelfNo;}
			set{_afShelfNo = value;}
		}

		/// public propaty name  :  NonAddUpShipmCnt
		/// <summary>出荷数（未計上）プロパティ</summary>
		/// <value>貸出、出荷と同意</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数（未計上）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double NonAddUpShipmCnt
		{
			get{return _nonAddUpShipmCnt;}
			set{_nonAddUpShipmCnt = value;}
		}

		/// public propaty name  :  NonAddUpArrGdsCnt
		/// <summary>入荷数（未計上）プロパティ</summary>
		/// <value>入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷数（未計上）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double NonAddUpArrGdsCnt
		{
			get{return _nonAddUpArrGdsCnt;}
			set{_nonAddUpArrGdsCnt = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>定価（税抜，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  StockUnitPriceFl
		/// <summary>仕入単価（税抜，浮動）プロパティ</summary>
		/// <value>売上の場合原価単価</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StockUnitPriceFl
		{
			get{return _stockUnitPriceFl;}
			set{_stockUnitPriceFl = value;}
		}

		/// public propaty name  :  AddUpADate
		/// <summary>計上日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
		}

		/// public propaty name  :  AddUpADateJpFormal
		/// <summary>計上日付 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateJpInFormal
		/// <summary>計上日付 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateAdFormal
		/// <summary>計上日付 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateAdInFormal
		/// <summary>計上日付 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AcPaySlipRowNo
		/// <summary>受払元行番号プロパティ</summary>
		/// <value>「受払元伝票」の伝票行番号を格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払元行番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcPaySlipRowNo
		{
			get{return _acPaySlipRowNo;}
			set{_acPaySlipRowNo = value;}
		}

		/// public propaty name  :  InputSectionCd
		/// <summary>入力拠点コードプロパティ</summary>
		/// <value>入力を行った拠点ｺｰﾄﾞ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputSectionCd
		{
			get{return _inputSectionCd;}
			set{_inputSectionCd = value;}
		}

		/// public propaty name  :  InputSectionGuidNm
		/// <summary>入力拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputSectionGuidNm
		{
			get{return _inputSectionGuidNm;}
			set{_inputSectionGuidNm = value;}
		}

		/// public propaty name  :  InputAgenCd
		/// <summary>入力担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputAgenCd
		{
			get{return _inputAgenCd;}
			set{_inputAgenCd = value;}
		}

		/// public propaty name  :  InputAgenNm
		/// <summary>入力担当者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InputAgenNm
		{
			get{return _inputAgenNm;}
			set{_inputAgenNm = value;}
		}

		/// public propaty name  :  MoveStatus
		/// <summary>移動状態プロパティ</summary>
		/// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動状態プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MoveStatus
		{
			get{return _moveStatus;}
			set{_moveStatus = value;}
		}

		/// public propaty name  :  CustSlipNo
		/// <summary>相手先伝票番号プロパティ</summary>
		/// <value>得意先伝票番号、仕入先伝票番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustSlipNo
		{
			get{return _custSlipNo;}
			set{_custSlipNo = value;}
		}

		/// public propaty name  :  SlipDtlNum
		/// <summary>明細通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SlipDtlNum
		{
			get{return _slipDtlNum;}
			set{_slipDtlNum = value;}
		}

		/// public propaty name  :  AcPayNote
		/// <summary>受払備考プロパティ</summary>
		/// <value>受払した情報を格納</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcPayNote
		{
			get{return _acPayNote;}
			set{_acPayNote = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsFullName
		/// <summary>BL商品コード名称（全角）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（全角）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsFullName
		{
			get{return _bLGoodsFullName;}
			set{_bLGoodsFullName = value;}
		}

		/// public propaty name  :  BfSectionCode
		/// <summary>移動元拠点コードプロパティ</summary>
		/// <value>移動（出荷）の場合は 自情報　　移動（入荷）の場合は相手情報</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfSectionCode
		{
			get{return _bfSectionCode;}
			set{_bfSectionCode = value;}
		}

		/// public propaty name  :  BfSectionGuideNm
		/// <summary>移動元拠点ガイド名称プロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfSectionGuideNm
		{
			get{return _bfSectionGuideNm;}
			set{_bfSectionGuideNm = value;}
		}

		/// public propaty name  :  BfEnterWarehCode
		/// <summary>移動元倉庫コードプロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfEnterWarehCode
		{
			get{return _bfEnterWarehCode;}
			set{_bfEnterWarehCode = value;}
		}

		/// public propaty name  :  BfEnterWarehName
		/// <summary>移動元倉庫名称プロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfEnterWarehName
		{
			get{return _bfEnterWarehName;}
			set{_bfEnterWarehName = value;}
		}

		/// public propaty name  :  BfShelfNo
		/// <summary>移動元棚番プロパティ</summary>
		/// <value>同上</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動元棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BfShelfNo
		{
			get{return _bfShelfNo;}
			set{_bfShelfNo = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// <value>売上時の得意先コードをセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>得意先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>仕入時の仕入先コードをセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  SupplierSnm
		/// <summary>仕入先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SupplierSnm
		{
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  OpenPriceDiv
		/// <summary>オープン価格区分プロパティ</summary>
		/// <value>0:通常／1:オープン価格</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オープン価格区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OpenPriceDiv
		{
			get{return _openPriceDiv;}
			set{_openPriceDiv = value;}
		}

		/// public propaty name  :  StockPrice
		/// <summary>仕入金額プロパティ</summary>
		/// <value>売上の場合原価金額</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockPrice
		{
			get{return _stockPrice;}
			set{_stockPrice = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxExcFl
		/// <summary>売上単価（税抜，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnPrcTaxExcFl
		{
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
		}

		/// public propaty name  :  SalesMoney
		/// <summary>売上金額プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesMoney
		{
			get{return _salesMoney;}
			set{_salesMoney = value;}
		}

		/// public propaty name  :  SupplierStock
		/// <summary>仕入在庫数プロパティ</summary>
		/// <value>入荷数(未計上）、出荷数(未計上）を含まない在庫数（自社在庫）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SupplierStock
		{
			get{return _supplierStock;}
			set{_supplierStock = value;}
		}

		/// public propaty name  :  AcpOdrCount
		/// <summary>受注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AcpOdrCount
		{
			get{return _acpOdrCount;}
			set{_acpOdrCount = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>発注数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  MovingSupliStock
		/// <summary>移動中仕入在庫数プロパティ</summary>
		/// <value>在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   移動中仕入在庫数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double MovingSupliStock
		{
			get{return _movingSupliStock;}
			set{_movingSupliStock = value;}
		}

		/// public propaty name  :  ShipmentPosCnt
		/// <summary>出荷可能数プロパティ</summary>
		/// <value>出荷可能数＝仕入在庫数＋入荷数(未計上）－出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷可能数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentPosCnt
		{
			get{return _shipmentPosCnt;}
			set{_shipmentPosCnt = value;}
		}

		/// public propaty name  :  PresentStockCnt
		/// <summary>現在庫数量プロパティ</summary>
		/// <value>現在庫数量＝仕入在庫数＋入荷数（未計上）－出荷数（未計上）－移動中仕入在庫数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   現在庫数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PresentStockCnt
		{
			get{return _presentStockCnt;}
			set{_presentStockCnt = value;}
		}

		/// public propaty name  :  ArrivalCnt
		/// <summary>入荷数プロパティ</summary>
		/// <value>仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ArrivalCnt
		{
			get{return _arrivalCnt;}
			set{_arrivalCnt = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>出荷数プロパティ</summary>
		/// <value>売上入力、在庫移動（出荷）時にセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  AcPayHistDateTime
		/// <summary>受払履歴作成日時プロパティ</summary>
		/// <value>DateTime:精度は100ナノ秒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払履歴作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AcPayHistDateTime
		{
			get{return _acPayHistDateTime;}
			set{_acPayHistDateTime = value;}
		}

		/// public propaty name  :  AcPayHistDateTimeJpFormal
		/// <summary>受払履歴作成日時 和暦プロパティ</summary>
		/// <value>DateTime:精度は100ナノ秒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払履歴作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcPayHistDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  AcPayHistDateTimeJpInFormal
		/// <summary>受払履歴作成日時 和暦(略)プロパティ</summary>
		/// <value>DateTime:精度は100ナノ秒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払履歴作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcPayHistDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  AcPayHistDateTimeAdFormal
		/// <summary>受払履歴作成日時 西暦プロパティ</summary>
		/// <value>DateTime:精度は100ナノ秒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払履歴作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcPayHistDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  AcPayHistDateTimeAdInFormal
		/// <summary>受払履歴作成日時 西暦(略)プロパティ</summary>
		/// <value>DateTime:精度は100ナノ秒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受払履歴作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AcPayHistDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _acPayHistDateTime);}
			set{}
		}

		/// public propaty name  :  ShelfNo
		/// <summary>棚番プロパティ</summary>
		/// <value>出荷、入荷が発生する棚番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShelfNo
		{
			get{return _shelfNo;}
			set{_shelfNo = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL商品コード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}


		/// <summary>
		/// 在庫受払履歴抽出結果クラスコンストラクタ
		/// </summary>
		/// <returns>StockAcPayHisSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHisSearchRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAcPayHisSearchRet()
		{
		}

		/// <summary>
		/// 在庫受払履歴抽出結果クラスコンストラクタ
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="sectionGuideNm">拠点ガイド名称</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="ioGoodsDay">入出荷日</param>
		/// <param name="acPaySlipNum">受払元伝票番号(「受払元伝票」の伝票番号を格納)</param>
		/// <param name="acPaySlipCd">受払元伝票区分(10:仕入,11:入荷,12:受計上,20:売上,21:売計上,22:出荷,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸(名称変更 11:受託->入荷　22:委託->出荷）)</param>
		/// <param name="acPayTransCd">受払元取引区分(10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,36:一括登録,40:過不足更新,90:取消)</param>
		/// <param name="afSectionCode">移動先拠点コード(移動（出荷）の場合は 相手情報　　移動（入荷）の場合は自情報)</param>
		/// <param name="afSectionGuideNm">移動先拠点ガイド名称(同上)</param>
		/// <param name="afEnterWarehCode">移動先倉庫コード(同上)</param>
		/// <param name="afEnterWarehName">移動先倉庫名称(同上)</param>
		/// <param name="afShelfNo">移動先棚番(同上)</param>
		/// <param name="nonAddUpShipmCnt">出荷数（未計上）(貸出、出荷と同意)</param>
		/// <param name="nonAddUpArrGdsCnt">入荷数（未計上）(入荷)</param>
		/// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税抜き)</param>
		/// <param name="stockUnitPriceFl">仕入単価（税抜，浮動）(売上の場合原価単価)</param>
		/// <param name="addUpADate">計上日付(YYYYMMDD)</param>
		/// <param name="acPaySlipRowNo">受払元行番号(「受払元伝票」の伝票行番号を格納)</param>
		/// <param name="inputSectionCd">入力拠点コード(入力を行った拠点ｺｰﾄﾞ)</param>
		/// <param name="inputSectionGuidNm">入力拠点ガイド名称</param>
		/// <param name="inputAgenCd">入力担当者コード</param>
		/// <param name="inputAgenNm">入力担当者名称</param>
		/// <param name="moveStatus">移動状態(0:移動対象外、1:未出荷状態、2:移動中、9:入荷済)</param>
		/// <param name="custSlipNo">相手先伝票番号(得意先伝票番号、仕入先伝票番号)</param>
		/// <param name="slipDtlNum">明細通番</param>
		/// <param name="acPayNote">受払備考(受払した情報を格納)</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="bfSectionCode">移動元拠点コード(移動（出荷）の場合は 自情報　　移動（入荷）の場合は相手情報)</param>
		/// <param name="bfSectionGuideNm">移動元拠点ガイド名称(同上)</param>
		/// <param name="bfEnterWarehCode">移動元倉庫コード(同上)</param>
		/// <param name="bfEnterWarehName">移動元倉庫名称(同上)</param>
		/// <param name="bfShelfNo">移動元棚番(同上)</param>
		/// <param name="customerCode">得意先コード(売上時の得意先コードをセット)</param>
		/// <param name="customerSnm">得意先略称</param>
		/// <param name="supplierCd">仕入先コード(仕入時の仕入先コードをセット)</param>
		/// <param name="supplierSnm">仕入先略称</param>
		/// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
		/// <param name="stockPrice">仕入金額(売上の場合原価金額)</param>
		/// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）</param>
		/// <param name="salesMoney">売上金額(税抜き)</param>
		/// <param name="supplierStock">仕入在庫数(入荷数(未計上）、出荷数(未計上）を含まない在庫数（自社在庫）)</param>
		/// <param name="acpOdrCount">受注数</param>
		/// <param name="salesOrderCount">発注数</param>
		/// <param name="movingSupliStock">移動中仕入在庫数(在庫移動後、かつ移動先が入荷する前までの間に有効値が入る。)</param>
		/// <param name="shipmentPosCnt">出荷可能数(出荷可能数＝仕入在庫数＋入荷数(未計上）－出荷数（未計上）－受注数 － 移動中仕入在庫数)</param>
		/// <param name="presentStockCnt">現在庫数量(現在庫数量＝仕入在庫数＋入荷数（未計上）－出荷数（未計上）－移動中仕入在庫数)</param>
		/// <param name="arrivalCnt">入荷数(仕入入力、在庫移動（入荷）、在庫調整、棚卸し時にセット)</param>
		/// <param name="shipmentCnt">出荷数(売上入力、在庫移動（出荷）時にセット)</param>
		/// <param name="acPayHistDateTime">受払履歴作成日時(DateTime:精度は100ナノ秒)</param>
		/// <param name="shelfNo">棚番(出荷、入荷が発生する棚番)</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <returns>StockAcPayHisSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHisSearchRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAcPayHisSearchRet(string sectionCode,string sectionGuideNm,string warehouseCode,string warehouseName,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,DateTime ioGoodsDay,string acPaySlipNum,Int32 acPaySlipCd,Int32 acPayTransCd,string afSectionCode,string afSectionGuideNm,string afEnterWarehCode,string afEnterWarehName,string afShelfNo,Double nonAddUpShipmCnt,Double nonAddUpArrGdsCnt,Double listPriceTaxExcFl,Double stockUnitPriceFl,DateTime addUpADate,Int32 acPaySlipRowNo,string inputSectionCd,string inputSectionGuidNm,string inputAgenCd,string inputAgenNm,Int32 moveStatus,string custSlipNo,Int64 slipDtlNum,string acPayNote,Int32 bLGoodsCode,string bLGoodsFullName,string bfSectionCode,string bfSectionGuideNm,string bfEnterWarehCode,string bfEnterWarehName,string bfShelfNo,Int32 customerCode,string customerSnm,Int32 supplierCd,string supplierSnm,Int32 openPriceDiv,Int64 stockPrice,Double salesUnPrcTaxExcFl,Int64 salesMoney,Double supplierStock,Double acpOdrCount,Double salesOrderCount,Double movingSupliStock,Double shipmentPosCnt,Double presentStockCnt,Double arrivalCnt,Double shipmentCnt,DateTime acPayHistDateTime,string shelfNo,string bLGoodsName)
		{
			this._sectionCode = sectionCode;
			this._sectionGuideNm = sectionGuideNm;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this.IoGoodsDay = ioGoodsDay;
			this._acPaySlipNum = acPaySlipNum;
			this._acPaySlipCd = acPaySlipCd;
			this._acPayTransCd = acPayTransCd;
			this._afSectionCode = afSectionCode;
			this._afSectionGuideNm = afSectionGuideNm;
			this._afEnterWarehCode = afEnterWarehCode;
			this._afEnterWarehName = afEnterWarehName;
			this._afShelfNo = afShelfNo;
			this._nonAddUpShipmCnt = nonAddUpShipmCnt;
			this._nonAddUpArrGdsCnt = nonAddUpArrGdsCnt;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._stockUnitPriceFl = stockUnitPriceFl;
			this.AddUpADate = addUpADate;
			this._acPaySlipRowNo = acPaySlipRowNo;
			this._inputSectionCd = inputSectionCd;
			this._inputSectionGuidNm = inputSectionGuidNm;
			this._inputAgenCd = inputAgenCd;
			this._inputAgenNm = inputAgenNm;
			this._moveStatus = moveStatus;
			this._custSlipNo = custSlipNo;
			this._slipDtlNum = slipDtlNum;
			this._acPayNote = acPayNote;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._bfSectionCode = bfSectionCode;
			this._bfSectionGuideNm = bfSectionGuideNm;
			this._bfEnterWarehCode = bfEnterWarehCode;
			this._bfEnterWarehName = bfEnterWarehName;
			this._bfShelfNo = bfShelfNo;
			this._customerCode = customerCode;
			this._customerSnm = customerSnm;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._openPriceDiv = openPriceDiv;
			this._stockPrice = stockPrice;
			this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			this._salesMoney = salesMoney;
			this._supplierStock = supplierStock;
			this._acpOdrCount = acpOdrCount;
			this._salesOrderCount = salesOrderCount;
			this._movingSupliStock = movingSupliStock;
			this._shipmentPosCnt = shipmentPosCnt;
			this._presentStockCnt = presentStockCnt;
			this._arrivalCnt = arrivalCnt;
			this._shipmentCnt = shipmentCnt;
			this.AcPayHistDateTime = acPayHistDateTime;
			this._shelfNo = shelfNo;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// 在庫受払履歴抽出結果クラス複製処理
		/// </summary>
		/// <returns>StockAcPayHisSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockAcPayHisSearchRetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockAcPayHisSearchRet Clone()
		{
			return new StockAcPayHisSearchRet(this._sectionCode,this._sectionGuideNm,this._warehouseCode,this._warehouseName,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._ioGoodsDay,this._acPaySlipNum,this._acPaySlipCd,this._acPayTransCd,this._afSectionCode,this._afSectionGuideNm,this._afEnterWarehCode,this._afEnterWarehName,this._afShelfNo,this._nonAddUpShipmCnt,this._nonAddUpArrGdsCnt,this._listPriceTaxExcFl,this._stockUnitPriceFl,this._addUpADate,this._acPaySlipRowNo,this._inputSectionCd,this._inputSectionGuidNm,this._inputAgenCd,this._inputAgenNm,this._moveStatus,this._custSlipNo,this._slipDtlNum,this._acPayNote,this._bLGoodsCode,this._bLGoodsFullName,this._bfSectionCode,this._bfSectionGuideNm,this._bfEnterWarehCode,this._bfEnterWarehName,this._bfShelfNo,this._customerCode,this._customerSnm,this._supplierCd,this._supplierSnm,this._openPriceDiv,this._stockPrice,this._salesUnPrcTaxExcFl,this._salesMoney,this._supplierStock,this._acpOdrCount,this._salesOrderCount,this._movingSupliStock,this._shipmentPosCnt,this._presentStockCnt,this._arrivalCnt,this._shipmentCnt,this._acPayHistDateTime,this._shelfNo,this._bLGoodsName);
		}

		/// <summary>
		/// 在庫受払履歴抽出結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockAcPayHisSearchRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHisSearchRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockAcPayHisSearchRet target)
		{
			return ((this.SectionCode == target.SectionCode)
				 && (this.SectionGuideNm == target.SectionGuideNm)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.IoGoodsDay == target.IoGoodsDay)
				 && (this.AcPaySlipNum == target.AcPaySlipNum)
				 && (this.AcPaySlipCd == target.AcPaySlipCd)
				 && (this.AcPayTransCd == target.AcPayTransCd)
				 && (this.AfSectionCode == target.AfSectionCode)
				 && (this.AfSectionGuideNm == target.AfSectionGuideNm)
				 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
				 && (this.AfEnterWarehName == target.AfEnterWarehName)
				 && (this.AfShelfNo == target.AfShelfNo)
				 && (this.NonAddUpShipmCnt == target.NonAddUpShipmCnt)
				 && (this.NonAddUpArrGdsCnt == target.NonAddUpArrGdsCnt)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
				 && (this.AddUpADate == target.AddUpADate)
				 && (this.AcPaySlipRowNo == target.AcPaySlipRowNo)
				 && (this.InputSectionCd == target.InputSectionCd)
				 && (this.InputSectionGuidNm == target.InputSectionGuidNm)
				 && (this.InputAgenCd == target.InputAgenCd)
				 && (this.InputAgenNm == target.InputAgenNm)
				 && (this.MoveStatus == target.MoveStatus)
				 && (this.CustSlipNo == target.CustSlipNo)
				 && (this.SlipDtlNum == target.SlipDtlNum)
				 && (this.AcPayNote == target.AcPayNote)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.BfSectionCode == target.BfSectionCode)
				 && (this.BfSectionGuideNm == target.BfSectionGuideNm)
				 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
				 && (this.BfEnterWarehName == target.BfEnterWarehName)
				 && (this.BfShelfNo == target.BfShelfNo)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.StockPrice == target.StockPrice)
				 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
				 && (this.SalesMoney == target.SalesMoney)
				 && (this.SupplierStock == target.SupplierStock)
				 && (this.AcpOdrCount == target.AcpOdrCount)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.MovingSupliStock == target.MovingSupliStock)
				 && (this.ShipmentPosCnt == target.ShipmentPosCnt)
				 && (this.PresentStockCnt == target.PresentStockCnt)
				 && (this.ArrivalCnt == target.ArrivalCnt)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.AcPayHistDateTime == target.AcPayHistDateTime)
				 && (this.ShelfNo == target.ShelfNo)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// 在庫受払履歴抽出結果クラス比較処理
		/// </summary>
		/// <param name="stockAcPayHisSearchRet1">
		///                    比較するStockAcPayHisSearchRetクラスのインスタンス
		/// </param>
		/// <param name="stockAcPayHisSearchRet2">比較するStockAcPayHisSearchRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHisSearchRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockAcPayHisSearchRet stockAcPayHisSearchRet1, StockAcPayHisSearchRet stockAcPayHisSearchRet2)
		{
			return ((stockAcPayHisSearchRet1.SectionCode == stockAcPayHisSearchRet2.SectionCode)
				 && (stockAcPayHisSearchRet1.SectionGuideNm == stockAcPayHisSearchRet2.SectionGuideNm)
				 && (stockAcPayHisSearchRet1.WarehouseCode == stockAcPayHisSearchRet2.WarehouseCode)
				 && (stockAcPayHisSearchRet1.WarehouseName == stockAcPayHisSearchRet2.WarehouseName)
				 && (stockAcPayHisSearchRet1.GoodsMakerCd == stockAcPayHisSearchRet2.GoodsMakerCd)
				 && (stockAcPayHisSearchRet1.MakerName == stockAcPayHisSearchRet2.MakerName)
				 && (stockAcPayHisSearchRet1.GoodsNo == stockAcPayHisSearchRet2.GoodsNo)
				 && (stockAcPayHisSearchRet1.GoodsName == stockAcPayHisSearchRet2.GoodsName)
				 && (stockAcPayHisSearchRet1.IoGoodsDay == stockAcPayHisSearchRet2.IoGoodsDay)
				 && (stockAcPayHisSearchRet1.AcPaySlipNum == stockAcPayHisSearchRet2.AcPaySlipNum)
				 && (stockAcPayHisSearchRet1.AcPaySlipCd == stockAcPayHisSearchRet2.AcPaySlipCd)
				 && (stockAcPayHisSearchRet1.AcPayTransCd == stockAcPayHisSearchRet2.AcPayTransCd)
				 && (stockAcPayHisSearchRet1.AfSectionCode == stockAcPayHisSearchRet2.AfSectionCode)
				 && (stockAcPayHisSearchRet1.AfSectionGuideNm == stockAcPayHisSearchRet2.AfSectionGuideNm)
				 && (stockAcPayHisSearchRet1.AfEnterWarehCode == stockAcPayHisSearchRet2.AfEnterWarehCode)
				 && (stockAcPayHisSearchRet1.AfEnterWarehName == stockAcPayHisSearchRet2.AfEnterWarehName)
				 && (stockAcPayHisSearchRet1.AfShelfNo == stockAcPayHisSearchRet2.AfShelfNo)
				 && (stockAcPayHisSearchRet1.NonAddUpShipmCnt == stockAcPayHisSearchRet2.NonAddUpShipmCnt)
				 && (stockAcPayHisSearchRet1.NonAddUpArrGdsCnt == stockAcPayHisSearchRet2.NonAddUpArrGdsCnt)
				 && (stockAcPayHisSearchRet1.ListPriceTaxExcFl == stockAcPayHisSearchRet2.ListPriceTaxExcFl)
				 && (stockAcPayHisSearchRet1.StockUnitPriceFl == stockAcPayHisSearchRet2.StockUnitPriceFl)
				 && (stockAcPayHisSearchRet1.AddUpADate == stockAcPayHisSearchRet2.AddUpADate)
				 && (stockAcPayHisSearchRet1.AcPaySlipRowNo == stockAcPayHisSearchRet2.AcPaySlipRowNo)
				 && (stockAcPayHisSearchRet1.InputSectionCd == stockAcPayHisSearchRet2.InputSectionCd)
				 && (stockAcPayHisSearchRet1.InputSectionGuidNm == stockAcPayHisSearchRet2.InputSectionGuidNm)
				 && (stockAcPayHisSearchRet1.InputAgenCd == stockAcPayHisSearchRet2.InputAgenCd)
				 && (stockAcPayHisSearchRet1.InputAgenNm == stockAcPayHisSearchRet2.InputAgenNm)
				 && (stockAcPayHisSearchRet1.MoveStatus == stockAcPayHisSearchRet2.MoveStatus)
				 && (stockAcPayHisSearchRet1.CustSlipNo == stockAcPayHisSearchRet2.CustSlipNo)
				 && (stockAcPayHisSearchRet1.SlipDtlNum == stockAcPayHisSearchRet2.SlipDtlNum)
				 && (stockAcPayHisSearchRet1.AcPayNote == stockAcPayHisSearchRet2.AcPayNote)
				 && (stockAcPayHisSearchRet1.BLGoodsCode == stockAcPayHisSearchRet2.BLGoodsCode)
				 && (stockAcPayHisSearchRet1.BLGoodsFullName == stockAcPayHisSearchRet2.BLGoodsFullName)
				 && (stockAcPayHisSearchRet1.BfSectionCode == stockAcPayHisSearchRet2.BfSectionCode)
				 && (stockAcPayHisSearchRet1.BfSectionGuideNm == stockAcPayHisSearchRet2.BfSectionGuideNm)
				 && (stockAcPayHisSearchRet1.BfEnterWarehCode == stockAcPayHisSearchRet2.BfEnterWarehCode)
				 && (stockAcPayHisSearchRet1.BfEnterWarehName == stockAcPayHisSearchRet2.BfEnterWarehName)
				 && (stockAcPayHisSearchRet1.BfShelfNo == stockAcPayHisSearchRet2.BfShelfNo)
				 && (stockAcPayHisSearchRet1.CustomerCode == stockAcPayHisSearchRet2.CustomerCode)
				 && (stockAcPayHisSearchRet1.CustomerSnm == stockAcPayHisSearchRet2.CustomerSnm)
				 && (stockAcPayHisSearchRet1.SupplierCd == stockAcPayHisSearchRet2.SupplierCd)
				 && (stockAcPayHisSearchRet1.SupplierSnm == stockAcPayHisSearchRet2.SupplierSnm)
				 && (stockAcPayHisSearchRet1.OpenPriceDiv == stockAcPayHisSearchRet2.OpenPriceDiv)
				 && (stockAcPayHisSearchRet1.StockPrice == stockAcPayHisSearchRet2.StockPrice)
				 && (stockAcPayHisSearchRet1.SalesUnPrcTaxExcFl == stockAcPayHisSearchRet2.SalesUnPrcTaxExcFl)
				 && (stockAcPayHisSearchRet1.SalesMoney == stockAcPayHisSearchRet2.SalesMoney)
				 && (stockAcPayHisSearchRet1.SupplierStock == stockAcPayHisSearchRet2.SupplierStock)
				 && (stockAcPayHisSearchRet1.AcpOdrCount == stockAcPayHisSearchRet2.AcpOdrCount)
				 && (stockAcPayHisSearchRet1.SalesOrderCount == stockAcPayHisSearchRet2.SalesOrderCount)
				 && (stockAcPayHisSearchRet1.MovingSupliStock == stockAcPayHisSearchRet2.MovingSupliStock)
				 && (stockAcPayHisSearchRet1.ShipmentPosCnt == stockAcPayHisSearchRet2.ShipmentPosCnt)
				 && (stockAcPayHisSearchRet1.PresentStockCnt == stockAcPayHisSearchRet2.PresentStockCnt)
				 && (stockAcPayHisSearchRet1.ArrivalCnt == stockAcPayHisSearchRet2.ArrivalCnt)
				 && (stockAcPayHisSearchRet1.ShipmentCnt == stockAcPayHisSearchRet2.ShipmentCnt)
				 && (stockAcPayHisSearchRet1.AcPayHistDateTime == stockAcPayHisSearchRet2.AcPayHistDateTime)
				 && (stockAcPayHisSearchRet1.ShelfNo == stockAcPayHisSearchRet2.ShelfNo)
				 && (stockAcPayHisSearchRet1.BLGoodsName == stockAcPayHisSearchRet2.BLGoodsName));
		}
		/// <summary>
		/// 在庫受払履歴抽出結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockAcPayHisSearchRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHisSearchRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockAcPayHisSearchRet target)
		{
			ArrayList resList = new ArrayList();
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SectionGuideNm != target.SectionGuideNm)resList.Add("SectionGuideNm");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.IoGoodsDay != target.IoGoodsDay)resList.Add("IoGoodsDay");
			if(this.AcPaySlipNum != target.AcPaySlipNum)resList.Add("AcPaySlipNum");
			if(this.AcPaySlipCd != target.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(this.AcPayTransCd != target.AcPayTransCd)resList.Add("AcPayTransCd");
			if(this.AfSectionCode != target.AfSectionCode)resList.Add("AfSectionCode");
			if(this.AfSectionGuideNm != target.AfSectionGuideNm)resList.Add("AfSectionGuideNm");
			if(this.AfEnterWarehCode != target.AfEnterWarehCode)resList.Add("AfEnterWarehCode");
			if(this.AfEnterWarehName != target.AfEnterWarehName)resList.Add("AfEnterWarehName");
			if(this.AfShelfNo != target.AfShelfNo)resList.Add("AfShelfNo");
			if(this.NonAddUpShipmCnt != target.NonAddUpShipmCnt)resList.Add("NonAddUpShipmCnt");
			if(this.NonAddUpArrGdsCnt != target.NonAddUpArrGdsCnt)resList.Add("NonAddUpArrGdsCnt");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.StockUnitPriceFl != target.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(this.AddUpADate != target.AddUpADate)resList.Add("AddUpADate");
			if(this.AcPaySlipRowNo != target.AcPaySlipRowNo)resList.Add("AcPaySlipRowNo");
			if(this.InputSectionCd != target.InputSectionCd)resList.Add("InputSectionCd");
			if(this.InputSectionGuidNm != target.InputSectionGuidNm)resList.Add("InputSectionGuidNm");
			if(this.InputAgenCd != target.InputAgenCd)resList.Add("InputAgenCd");
			if(this.InputAgenNm != target.InputAgenNm)resList.Add("InputAgenNm");
			if(this.MoveStatus != target.MoveStatus)resList.Add("MoveStatus");
			if(this.CustSlipNo != target.CustSlipNo)resList.Add("CustSlipNo");
			if(this.SlipDtlNum != target.SlipDtlNum)resList.Add("SlipDtlNum");
			if(this.AcPayNote != target.AcPayNote)resList.Add("AcPayNote");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.BfSectionCode != target.BfSectionCode)resList.Add("BfSectionCode");
			if(this.BfSectionGuideNm != target.BfSectionGuideNm)resList.Add("BfSectionGuideNm");
			if(this.BfEnterWarehCode != target.BfEnterWarehCode)resList.Add("BfEnterWarehCode");
			if(this.BfEnterWarehName != target.BfEnterWarehName)resList.Add("BfEnterWarehName");
			if(this.BfShelfNo != target.BfShelfNo)resList.Add("BfShelfNo");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.StockPrice != target.StockPrice)resList.Add("StockPrice");
			if(this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(this.SalesMoney != target.SalesMoney)resList.Add("SalesMoney");
			if(this.SupplierStock != target.SupplierStock)resList.Add("SupplierStock");
			if(this.AcpOdrCount != target.AcpOdrCount)resList.Add("AcpOdrCount");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.MovingSupliStock != target.MovingSupliStock)resList.Add("MovingSupliStock");
			if(this.ShipmentPosCnt != target.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(this.PresentStockCnt != target.PresentStockCnt)resList.Add("PresentStockCnt");
			if(this.ArrivalCnt != target.ArrivalCnt)resList.Add("ArrivalCnt");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.AcPayHistDateTime != target.AcPayHistDateTime)resList.Add("AcPayHistDateTime");
			if(this.ShelfNo != target.ShelfNo)resList.Add("ShelfNo");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// 在庫受払履歴抽出結果クラス比較処理
		/// </summary>
		/// <param name="stockAcPayHisSearchRet1">比較するStockAcPayHisSearchRetクラスのインスタンス</param>
		/// <param name="stockAcPayHisSearchRet2">比較するStockAcPayHisSearchRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockAcPayHisSearchRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockAcPayHisSearchRet stockAcPayHisSearchRet1, StockAcPayHisSearchRet stockAcPayHisSearchRet2)
		{
			ArrayList resList = new ArrayList();
			if(stockAcPayHisSearchRet1.SectionCode != stockAcPayHisSearchRet2.SectionCode)resList.Add("SectionCode");
			if(stockAcPayHisSearchRet1.SectionGuideNm != stockAcPayHisSearchRet2.SectionGuideNm)resList.Add("SectionGuideNm");
			if(stockAcPayHisSearchRet1.WarehouseCode != stockAcPayHisSearchRet2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockAcPayHisSearchRet1.WarehouseName != stockAcPayHisSearchRet2.WarehouseName)resList.Add("WarehouseName");
			if(stockAcPayHisSearchRet1.GoodsMakerCd != stockAcPayHisSearchRet2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockAcPayHisSearchRet1.MakerName != stockAcPayHisSearchRet2.MakerName)resList.Add("MakerName");
			if(stockAcPayHisSearchRet1.GoodsNo != stockAcPayHisSearchRet2.GoodsNo)resList.Add("GoodsNo");
			if(stockAcPayHisSearchRet1.GoodsName != stockAcPayHisSearchRet2.GoodsName)resList.Add("GoodsName");
			if(stockAcPayHisSearchRet1.IoGoodsDay != stockAcPayHisSearchRet2.IoGoodsDay)resList.Add("IoGoodsDay");
			if(stockAcPayHisSearchRet1.AcPaySlipNum != stockAcPayHisSearchRet2.AcPaySlipNum)resList.Add("AcPaySlipNum");
			if(stockAcPayHisSearchRet1.AcPaySlipCd != stockAcPayHisSearchRet2.AcPaySlipCd)resList.Add("AcPaySlipCd");
			if(stockAcPayHisSearchRet1.AcPayTransCd != stockAcPayHisSearchRet2.AcPayTransCd)resList.Add("AcPayTransCd");
			if(stockAcPayHisSearchRet1.AfSectionCode != stockAcPayHisSearchRet2.AfSectionCode)resList.Add("AfSectionCode");
			if(stockAcPayHisSearchRet1.AfSectionGuideNm != stockAcPayHisSearchRet2.AfSectionGuideNm)resList.Add("AfSectionGuideNm");
			if(stockAcPayHisSearchRet1.AfEnterWarehCode != stockAcPayHisSearchRet2.AfEnterWarehCode)resList.Add("AfEnterWarehCode");
			if(stockAcPayHisSearchRet1.AfEnterWarehName != stockAcPayHisSearchRet2.AfEnterWarehName)resList.Add("AfEnterWarehName");
			if(stockAcPayHisSearchRet1.AfShelfNo != stockAcPayHisSearchRet2.AfShelfNo)resList.Add("AfShelfNo");
			if(stockAcPayHisSearchRet1.NonAddUpShipmCnt != stockAcPayHisSearchRet2.NonAddUpShipmCnt)resList.Add("NonAddUpShipmCnt");
			if(stockAcPayHisSearchRet1.NonAddUpArrGdsCnt != stockAcPayHisSearchRet2.NonAddUpArrGdsCnt)resList.Add("NonAddUpArrGdsCnt");
			if(stockAcPayHisSearchRet1.ListPriceTaxExcFl != stockAcPayHisSearchRet2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(stockAcPayHisSearchRet1.StockUnitPriceFl != stockAcPayHisSearchRet2.StockUnitPriceFl)resList.Add("StockUnitPriceFl");
			if(stockAcPayHisSearchRet1.AddUpADate != stockAcPayHisSearchRet2.AddUpADate)resList.Add("AddUpADate");
			if(stockAcPayHisSearchRet1.AcPaySlipRowNo != stockAcPayHisSearchRet2.AcPaySlipRowNo)resList.Add("AcPaySlipRowNo");
			if(stockAcPayHisSearchRet1.InputSectionCd != stockAcPayHisSearchRet2.InputSectionCd)resList.Add("InputSectionCd");
			if(stockAcPayHisSearchRet1.InputSectionGuidNm != stockAcPayHisSearchRet2.InputSectionGuidNm)resList.Add("InputSectionGuidNm");
			if(stockAcPayHisSearchRet1.InputAgenCd != stockAcPayHisSearchRet2.InputAgenCd)resList.Add("InputAgenCd");
			if(stockAcPayHisSearchRet1.InputAgenNm != stockAcPayHisSearchRet2.InputAgenNm)resList.Add("InputAgenNm");
			if(stockAcPayHisSearchRet1.MoveStatus != stockAcPayHisSearchRet2.MoveStatus)resList.Add("MoveStatus");
			if(stockAcPayHisSearchRet1.CustSlipNo != stockAcPayHisSearchRet2.CustSlipNo)resList.Add("CustSlipNo");
			if(stockAcPayHisSearchRet1.SlipDtlNum != stockAcPayHisSearchRet2.SlipDtlNum)resList.Add("SlipDtlNum");
			if(stockAcPayHisSearchRet1.AcPayNote != stockAcPayHisSearchRet2.AcPayNote)resList.Add("AcPayNote");
			if(stockAcPayHisSearchRet1.BLGoodsCode != stockAcPayHisSearchRet2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockAcPayHisSearchRet1.BLGoodsFullName != stockAcPayHisSearchRet2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(stockAcPayHisSearchRet1.BfSectionCode != stockAcPayHisSearchRet2.BfSectionCode)resList.Add("BfSectionCode");
			if(stockAcPayHisSearchRet1.BfSectionGuideNm != stockAcPayHisSearchRet2.BfSectionGuideNm)resList.Add("BfSectionGuideNm");
			if(stockAcPayHisSearchRet1.BfEnterWarehCode != stockAcPayHisSearchRet2.BfEnterWarehCode)resList.Add("BfEnterWarehCode");
			if(stockAcPayHisSearchRet1.BfEnterWarehName != stockAcPayHisSearchRet2.BfEnterWarehName)resList.Add("BfEnterWarehName");
			if(stockAcPayHisSearchRet1.BfShelfNo != stockAcPayHisSearchRet2.BfShelfNo)resList.Add("BfShelfNo");
			if(stockAcPayHisSearchRet1.CustomerCode != stockAcPayHisSearchRet2.CustomerCode)resList.Add("CustomerCode");
			if(stockAcPayHisSearchRet1.CustomerSnm != stockAcPayHisSearchRet2.CustomerSnm)resList.Add("CustomerSnm");
			if(stockAcPayHisSearchRet1.SupplierCd != stockAcPayHisSearchRet2.SupplierCd)resList.Add("SupplierCd");
			if(stockAcPayHisSearchRet1.SupplierSnm != stockAcPayHisSearchRet2.SupplierSnm)resList.Add("SupplierSnm");
			if(stockAcPayHisSearchRet1.OpenPriceDiv != stockAcPayHisSearchRet2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(stockAcPayHisSearchRet1.StockPrice != stockAcPayHisSearchRet2.StockPrice)resList.Add("StockPrice");
			if(stockAcPayHisSearchRet1.SalesUnPrcTaxExcFl != stockAcPayHisSearchRet2.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(stockAcPayHisSearchRet1.SalesMoney != stockAcPayHisSearchRet2.SalesMoney)resList.Add("SalesMoney");
			if(stockAcPayHisSearchRet1.SupplierStock != stockAcPayHisSearchRet2.SupplierStock)resList.Add("SupplierStock");
			if(stockAcPayHisSearchRet1.AcpOdrCount != stockAcPayHisSearchRet2.AcpOdrCount)resList.Add("AcpOdrCount");
			if(stockAcPayHisSearchRet1.SalesOrderCount != stockAcPayHisSearchRet2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(stockAcPayHisSearchRet1.MovingSupliStock != stockAcPayHisSearchRet2.MovingSupliStock)resList.Add("MovingSupliStock");
			if(stockAcPayHisSearchRet1.ShipmentPosCnt != stockAcPayHisSearchRet2.ShipmentPosCnt)resList.Add("ShipmentPosCnt");
			if(stockAcPayHisSearchRet1.PresentStockCnt != stockAcPayHisSearchRet2.PresentStockCnt)resList.Add("PresentStockCnt");
			if(stockAcPayHisSearchRet1.ArrivalCnt != stockAcPayHisSearchRet2.ArrivalCnt)resList.Add("ArrivalCnt");
			if(stockAcPayHisSearchRet1.ShipmentCnt != stockAcPayHisSearchRet2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(stockAcPayHisSearchRet1.AcPayHistDateTime != stockAcPayHisSearchRet2.AcPayHistDateTime)resList.Add("AcPayHistDateTime");
			if(stockAcPayHisSearchRet1.ShelfNo != stockAcPayHisSearchRet2.ShelfNo)resList.Add("ShelfNo");
			if(stockAcPayHisSearchRet1.BLGoodsName != stockAcPayHisSearchRet2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}
	}
}
