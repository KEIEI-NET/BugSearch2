using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    //------------------------------------------------------------------
    //　※フル型式固定番号配列と装備情報配列は
    //　　ツールで生成した内容を手で修正する必要があります。
    //
    //　　（PMSYAR09013Dを参考にして下さい。）
    //------------------------------------------------------------------
    //  ※UpdateDateTimeはInt64のまま取得します。
    //    （件数が増加したとき、サーバーに負荷をかけたくない為）
    //------------------------------------------------------------------
    /// <br>Update Note: 2011/08/18 連番729 許雁波 10704766-00 </br>
    /// <br>             明細貼付ファンクションボタンを追加</br>
    /// <br>Update Note: 2012/04/01 Redmine#29250 </br>
    /// <br>             得意先電子元帳　データ更新日時の追加について(明細更新日時の追加)</br>

    # region // DEL
    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
    ///// public class name:   CustPrtPprSalTblRsltWork
    ///// <summary>
    /////                      得意先電子元帳抽出結果(伝票・明細)クラスワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   得意先電子元帳抽出結果(伝票・明細)クラスワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/08/25  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class CustPrtPprSalTblRsltWork
    //{
    //    /// <summary>データ区分</summary>
    //    /// <remarks>0:売上データ 1:入金データ</remarks>
    //    private Int32 _dataDiv;

    //    /// <summary>売上日付</summary>
    //    /// <remarks>売上日付(YYYYMMDD)/入金日付</remarks>
    //    private DateTime _salesDate;

    //    /// <summary>売上伝票番号</summary>
    //    /// <remarks>売上伝票番号/入金伝票番号</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>売上行番号</summary>
    //    /// <remarks>売上行番号/入金行番号</remarks>
    //    private Int32 _salesRowNo;

    //    /// <summary>受注ステータス</summary>
    //    /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
    //    private Int32 _acptAnOdrStatus;

    //    /// <summary>売上伝票区分</summary>
    //    /// <remarks>0:売上,1:返品</remarks>
    //    private Int32 _salesSlipCd;

    //    /// <summary>販売従業員名称</summary>
    //    /// <remarks>販売従業員名称/入金担当者名称</remarks>
    //    private string _salesEmployeeNm = "";

    //    /// <summary>売上伝票合計（税抜き）</summary>
    //    /// <remarks>売上伝票合計（税抜き）/入金の場合(入金金額+値引+手数料)</remarks>
    //    private Int64 _salesTotalTaxExc;

    //    /// <summary>商品名称</summary>
    //    /// <remarks>商品名称/金種名称</remarks>
    //    private string _goodsName = "";

    //    /// <summary>商品番号</summary>
    //    /// <remarks>商品番号</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>BL商品コード</summary>
    //    /// <remarks>BL商品コード</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>BLグループコード</summary>
    //    /// <remarks>BLグループコード</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>出荷数</summary>
    //    /// <remarks>出荷数</remarks>
    //    private Double _shipmentCnt;

    //    /// <summary>定価（税抜，浮動）</summary>
    //    /// <remarks>定価（税抜き、浮動）または"オープン価格"</remarks>
    //    private Double _listPriceTaxExcFl;

    //    /// <summary>オープン価格区分</summary>
    //    /// <remarks>0:通常／1:オープン価格</remarks>
    //    private Int32 _openPriceDiv;

    //    /// <summary>売上単価（税抜，浮動）</summary>
    //    /// <remarks>売上単価（税抜，浮動）</remarks>
    //    private Double _salesUnPrcTaxExcFl;

    //    /// <summary>原価単価</summary>
    //    /// <remarks>原価単価</remarks>
    //    private Double _salesUnitCost;

    //    /// <summary>売上金額（税抜き）</summary>
    //    /// <remarks>売上金額（税抜き）/入金金額</remarks>
    //    private Int64 _salesMoneyTaxExc;

    //    /// <summary>消費税転嫁方式</summary>
    //    /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
    //    private Int32 _consTaxLayMethod;

    //    /// <summary>売上伝票合計（税込み）</summary>
    //    /// <remarks>売上データ</remarks>
    //    private Int64 _salesTotalTaxInc;

    //    /// <summary>売上金額消費税額</summary>
    //    /// <remarks>売上明細データ</remarks>
    //    private Int64 _salesPriceConsTax;

    //    /// <summary>原価金額計</summary>
    //    /// <remarks>売上データ</remarks>
    //    private Int64 _totalCost;

    //    /// <summary>型式指定番号</summary>
    //    private Int32 _modelDesignationNo;

    //    /// <summary>類別番号</summary>
    //    /// <remarks>類別番号</remarks>
    //    private Int32 _categoryNo;

    //    /// <summary>車種全角名称</summary>
    //    /// <remarks>車種全角名称</remarks>
    //    private string _modelFullName = "";

    //    /// <summary>初年度</summary>
    //    /// <remarks>初年度(YYYYMM)</remarks>
    //    private DateTime _firstEntryDate;

    //    /// <summary>車台№</summary>
    //    /// <remarks>車台番号（検索用）</remarks>
    //    private Int32 _searchFrameNo;

    //    /// <summary>型式（フル型）</summary>
    //    /// <remarks>型式（フル型）</remarks>
    //    private string _fullModel = "";

    //    /// <summary>伝票備考</summary>
    //    /// <remarks>伝票備考/伝票摘要</remarks>
    //    private string _slipNote = "";

    //    /// <summary>伝票備考２</summary>
    //    /// <remarks>伝票備考２</remarks>
    //    private string _slipNote2 = "";

    //    /// <summary>伝票備考３</summary>
    //    /// <remarks>伝票備考３</remarks>
    //    private string _slipNote3 = "";

    //    /// <summary>受付従業員名称</summary>
    //    /// <remarks>受付従業員名称</remarks>
    //    private string _frontEmployeeNm = "";

    //    /// <summary>売上入力者名称</summary>
    //    /// <remarks>売上入力者名称/入金入力者名称</remarks>
    //    private string _salesInputName = "";

    //    /// <summary>得意先コード</summary>
    //    /// <remarks>得意先コード/得意先コード</remarks>
    //    private Int32 _customerCode;

    //    /// <summary>得意先略称</summary>
    //    /// <remarks>得意先略称</remarks>
    //    private string _customerSnm = "";

    //    /// <summary>仕入先コード</summary>
    //    /// <remarks>仕入先コード</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>仕入先略称</summary>
    //    /// <remarks>仕入先略称</remarks>
    //    private string _supplierSnm = "";

    //    /// <summary>相手先伝票番号</summary>
    //    /// <remarks>相手先伝票番号</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>車両管理コード</summary>
    //    /// <remarks>車輌管理コード</remarks>
    //    private string _carMngCode = "";

    //    /// <summary>受注番号</summary>
    //    /// <remarks>計上元受注番号</remarks>
    //    private Int32 _acceptAnOrderNo;

    //    /// <summary>計上元出荷№</summary>
    //    /// <remarks>計上元出荷番号</remarks>
    //    private string _shipmSalesSlipNum = "";

    //    /// <summary>元黒№(明細表示)</summary>
    //    /// <remarks>元黒伝番号</remarks>
    //    private string _srcSalesSlipNum = "";

    //    /// <summary>売上在庫取寄せ区分</summary>
    //    /// <remarks>売上在庫取寄せ区分(0:取寄せ，1:在庫)</remarks>
    //    private Int32 _salesOrderDivCd;

    //    /// <summary>倉庫名称</summary>
    //    /// <remarks>倉庫名称</remarks>
    //    private string _warehouseName = "";

    //    /// <summary>仕入伝票番号</summary>
    //    /// <remarks>同時仕入伝票番号</remarks>
    //    private Int32 _supplierSlipNo;

    //    /// <summary>UOE発注先コード</summary>
    //    /// <remarks>ＵＯＥ発注データ</remarks>
    //    private Int32 _uOESupplierCd;

    //    /// <summary>発注先名(明細表示)</summary>
    //    /// <remarks>ＵＯＥ発注データ</remarks>
    //    private string _uOESupplierSnm = "";

    //    /// <summary>ＵＯＥリマーク１</summary>
    //    /// <remarks>ＵＯＥリマーク１</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>ＵＯＥリマーク２</summary>
    //    /// <remarks>ＵＯＥリマーク２</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>ガイド名称</summary>
    //    /// <remarks>ガイド名称</remarks>
    //    private string _guideName = "";

    //    /// <summary>拠点ガイド名称</summary>
    //    /// <remarks>拠点ガイド名称/計上拠点コード</remarks>
    //    private string _sectionGuideNm = "";

    //    /// <summary>明細備考</summary>
    //    /// <remarks>明細備考/</remarks>
    //    private string _dtlNote = "";

    //    /// <summary>カラー名称1</summary>
    //    /// <remarks>カラー名称1</remarks>
    //    private string _colorName1 = "";

    //    /// <summary>トリム名称</summary>
    //    /// <remarks>トリム名称</remarks>
    //    private string _trimName = "";

    //    /// <summary>基準単価（定価）</summary>
    //    /// <remarks>基準単価（定価）</remarks>
    //    private Double _stdUnPrcLPrice;

    //    /// <summary>基準単価（売上単価）</summary>
    //    /// <remarks>基準単価（売上単価）</remarks>
    //    private Double _stdUnPrcSalUnPrc;

    //    /// <summary>基準単価（原価単価）</summary>
    //    /// <remarks>基準単価（原価単価）</remarks>
    //    private Double _stdUnPrcUnCst;

    //    /// <summary>商品メーカーコード</summary>
    //    /// <remarks>商品メーカーコード</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>メーカー名称</summary>
    //    /// <remarks>メーカー名称</remarks>
    //    private string _makerName = "";

    //    /// <summary>原価</summary>
    //    /// <remarks>売上明細データ</remarks>
    //    private Int64 _cost;

    //    /// <summary>得意先伝票番号</summary>
    //    /// <remarks>得意先伝票番号</remarks>
    //    private Int32 _custSlipNo;

    //    /// <summary>計上日付</summary>
    //    /// <remarks>計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</remarks>
    //    private DateTime _addUpADate;

    //    /// <summary>売掛区分</summary>
    //    /// <remarks>売掛区分(0:売掛なし,1:売掛)</remarks>
    //    private Int32 _accRecDivCd;

    //    /// <summary>赤伝区分</summary>
    //    /// <remarks>赤伝区分(0:黒伝,1:赤伝,2:元黒)/入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</remarks>
    //    private Int32 _debitNoteDiv;

    //    /// <summary>拠点コード</summary>
    //    /// <remarks>拠点コード</remarks>
    //    private string _sectionCode = "";

    //    /// <summary>倉庫コード</summary>
    //    /// <remarks>倉庫コード</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>総額表示方法区分</summary>
    //    /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
    //    private Int32 _totalAmountDispWayCd;

    //    /// <summary>課税区分[明細]</summary>
    //    /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
    //    private Int32 _taxationDivCd;

    //    /// <summary>相手先伝票番号</summary>
    //    /// <remarks>仕入先伝票番号に使用する</remarks>
    //    private string _stockPartySaleSlipNum = "";

    //    /// <summary>納品先コード</summary>
    //    private Int32 _addresseeCode;

    //    /// <summary>納品先名称</summary>
    //    private string _addresseeName = "";

    //    /// <summary>納品先名称2</summary>
    //    /// <remarks>追加(登録漏れ) 塩原</remarks>
    //    private string _addresseeName2 = "";

    //    /// <summary>車台番号</summary>
    //    private string _frameNo = "";

    //    /// <summary>受注残数</summary>
    //    /// <remarks>受注数量＋受注調整数－出荷数</remarks>
    //    private Double _acptAnOdrRemainCnt;

    //    /// <summary>自社分類コード</summary>
    //    private Int32 _enterpriseGanreCode;

    //    /// <summary>手数料入金額</summary>
    //    private Int64 _feeDeposit;

    //    /// <summary>値引入金額</summary>
    //    private Int64 _discountDeposit;

    //    /// <summary>入力日</summary>
    //    /// <remarks>YYYYMMDD　（更新年月日）</remarks>
    //    private DateTime _inputDay;

    //    /// <summary>商品属性</summary>
    //    /// <remarks>0:純正 1:優良</remarks>
    //    private Int32 _goodsKindCode;

    //    /// <summary>商品大分類コード</summary>
    //    /// <remarks>旧大分類（ユーザーガイド）</remarks>
    //    private Int32 _goodsLGroup;

    //    /// <summary>商品中分類コード</summary>
    //    /// <remarks>旧中分類コード</remarks>
    //    private Int32 _goodsMGroup;

    //    /// <summary>倉庫棚番</summary>
    //    private string _warehouseShelfNo = "";

    //    /// <summary>売上伝票区分（明細）</summary>
    //    /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
    //    private Int32 _salesSlipCdDtl;

    //    /// <summary>商品大分類名称</summary>
    //    private string _goodsLGroupName = "";

    //    /// <summary>商品中分類名称</summary>
    //    private string _goodsMGroupName = "";

    //    /// <summary>車両管理番号</summary>
    //    /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
    //    private Int32 _carMngNo;

    //    /// <summary>メーカーコード</summary>
    //    private Int32 _makerCode;

    //    /// <summary>車種コード</summary>
    //    private Int32 _modelCode;

    //    /// <summary>車種サブコード</summary>
    //    private Int32 _modelSubCode;

    //    /// <summary>エンジン型式名称</summary>
    //    /// <remarks>型式により変動</remarks>
    //    private string _engineModelNm = "";

    //    /// <summary>カラーコード</summary>
    //    /// <remarks>カタログの色コード</remarks>
    //    private string _colorCode = "";

    //    /// <summary>トリムコード</summary>
    //    private string _trimCode = "";

    //    /// <summary>納品区分</summary>
    //    private Int32 _deliveredGoodsDiv;

    //    /// <summary>フル型式固定番号配列</summary>
    //    private Int32[] _fullModelFixedNoAry = new Int32[0];

    //    /// <summary>装備オブジェクト配列</summary>
    //    private Byte[] _categoryObjAry = new Byte[0];

    //    /// <summary>売上入力者コード</summary>
    //    /// <remarks>入力担当者（発行者）</remarks>
    //    private string _salesInputCode = "";

    //    /// <summary>受付従業員コード</summary>
    //    /// <remarks>受付担当者（受注者）</remarks>
    //    private string _frontEmployeeCd = "";


    //    /// public propaty name  :  DataDiv
    //    /// <summary>データ区分プロパティ</summary>
    //    /// <value>0:売上データ 1:入金データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   データ区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DataDiv
    //    {
    //        get { return _dataDiv; }
    //        set { _dataDiv = value; }
    //    }

    //    /// public propaty name  :  SalesDate
    //    /// <summary>売上日付プロパティ</summary>
    //    /// <value>売上日付(YYYYMMDD)/入金日付</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime SalesDate
    //    {
    //        get { return _salesDate; }
    //        set { _salesDate = value; }
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>売上伝票番号プロパティ</summary>
    //    /// <value>売上伝票番号/入金伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get { return _salesSlipNum; }
    //        set { _salesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesRowNo
    //    /// <summary>売上行番号プロパティ</summary>
    //    /// <value>売上行番号/入金行番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上行番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesRowNo
    //    {
    //        get { return _salesRowNo; }
    //        set { _salesRowNo = value; }
    //    }

    //    /// public propaty name  :  AcptAnOdrStatus
    //    /// <summary>受注ステータスプロパティ</summary>
    //    /// <value>10:見積,20:受注,30:売上,40:出荷</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受注ステータスプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AcptAnOdrStatus
    //    {
    //        get { return _acptAnOdrStatus; }
    //        set { _acptAnOdrStatus = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCd
    //    /// <summary>売上伝票区分プロパティ</summary>
    //    /// <value>0:売上,1:返品</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCd
    //    {
    //        get { return _salesSlipCd; }
    //        set { _salesSlipCd = value; }
    //    }

    //    /// public propaty name  :  SalesEmployeeNm
    //    /// <summary>販売従業員名称プロパティ</summary>
    //    /// <value>販売従業員名称/入金担当者名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   販売従業員名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesEmployeeNm
    //    {
    //        get { return _salesEmployeeNm; }
    //        set { _salesEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxExc
    //    /// <summary>売上伝票合計（税抜き）プロパティ</summary>
    //    /// <value>売上伝票合計（税抜き）/入金の場合(入金金額+値引+手数料)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxExc
    //    {
    //        get { return _salesTotalTaxExc; }
    //        set { _salesTotalTaxExc = value; }
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>商品名称プロパティ</summary>
    //    /// <value>商品名称/金種名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get { return _goodsName; }
    //        set { _goodsName = value; }
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>商品番号プロパティ</summary>
    //    /// <value>商品番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get { return _goodsNo; }
    //        set { _goodsNo = value; }
    //    }

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>BL商品コードプロパティ</summary>
    //    /// <value>BL商品コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BL商品コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get { return _bLGoodsCode; }
    //        set { _bLGoodsCode = value; }
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>BLグループコードプロパティ</summary>
    //    /// <value>BLグループコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   BLグループコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get { return _bLGroupCode; }
    //        set { _bLGroupCode = value; }
    //    }

    //    /// public propaty name  :  ShipmentCnt
    //    /// <summary>出荷数プロパティ</summary>
    //    /// <value>出荷数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   出荷数プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double ShipmentCnt
    //    {
    //        get { return _shipmentCnt; }
    //        set { _shipmentCnt = value; }
    //    }

    //    /// public propaty name  :  ListPriceTaxExcFl
    //    /// <summary>定価（税抜，浮動）プロパティ</summary>
    //    /// <value>定価（税抜き、浮動）または"オープン価格"</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   定価（税抜，浮動）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double ListPriceTaxExcFl
    //    {
    //        get { return _listPriceTaxExcFl; }
    //        set { _listPriceTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  OpenPriceDiv
    //    /// <summary>オープン価格区分プロパティ</summary>
    //    /// <value>0:通常／1:オープン価格</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   オープン価格区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 OpenPriceDiv
    //    {
    //        get { return _openPriceDiv; }
    //        set { _openPriceDiv = value; }
    //    }

    //    /// public propaty name  :  SalesUnPrcTaxExcFl
    //    /// <summary>売上単価（税抜，浮動）プロパティ</summary>
    //    /// <value>売上単価（税抜，浮動）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double SalesUnPrcTaxExcFl
    //    {
    //        get { return _salesUnPrcTaxExcFl; }
    //        set { _salesUnPrcTaxExcFl = value; }
    //    }

    //    /// public propaty name  :  SalesUnitCost
    //    /// <summary>原価単価プロパティ</summary>
    //    /// <value>原価単価</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   原価単価プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double SalesUnitCost
    //    {
    //        get { return _salesUnitCost; }
    //        set { _salesUnitCost = value; }
    //    }

    //    /// public propaty name  :  SalesMoneyTaxExc
    //    /// <summary>売上金額（税抜き）プロパティ</summary>
    //    /// <value>売上金額（税抜き）/入金金額</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上金額（税抜き）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesMoneyTaxExc
    //    {
    //        get { return _salesMoneyTaxExc; }
    //        set { _salesMoneyTaxExc = value; }
    //    }

    //    /// public propaty name  :  ConsTaxLayMethod
    //    /// <summary>消費税転嫁方式プロパティ</summary>
    //    /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   消費税転嫁方式プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ConsTaxLayMethod
    //    {
    //        get { return _consTaxLayMethod; }
    //        set { _consTaxLayMethod = value; }
    //    }

    //    /// public propaty name  :  SalesTotalTaxInc
    //    /// <summary>売上伝票合計（税込み）プロパティ</summary>
    //    /// <value>売上データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesTotalTaxInc
    //    {
    //        get { return _salesTotalTaxInc; }
    //        set { _salesTotalTaxInc = value; }
    //    }

    //    /// public propaty name  :  SalesPriceConsTax
    //    /// <summary>売上金額消費税額プロパティ</summary>
    //    /// <value>売上明細データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上金額消費税額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SalesPriceConsTax
    //    {
    //        get { return _salesPriceConsTax; }
    //        set { _salesPriceConsTax = value; }
    //    }

    //    /// public propaty name  :  TotalCost
    //    /// <summary>原価金額計プロパティ</summary>
    //    /// <value>売上データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   原価金額計プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 TotalCost
    //    {
    //        get { return _totalCost; }
    //        set { _totalCost = value; }
    //    }

    //    /// public propaty name  :  ModelDesignationNo
    //    /// <summary>型式指定番号プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   型式指定番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ModelDesignationNo
    //    {
    //        get { return _modelDesignationNo; }
    //        set { _modelDesignationNo = value; }
    //    }

    //    /// public propaty name  :  CategoryNo
    //    /// <summary>類別番号プロパティ</summary>
    //    /// <value>類別番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   類別番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CategoryNo
    //    {
    //        get { return _categoryNo; }
    //        set { _categoryNo = value; }
    //    }

    //    /// public propaty name  :  ModelFullName
    //    /// <summary>車種全角名称プロパティ</summary>
    //    /// <value>車種全角名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車種全角名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ModelFullName
    //    {
    //        get { return _modelFullName; }
    //        set { _modelFullName = value; }
    //    }

    //    /// public propaty name  :  FirstEntryDate
    //    /// <summary>初年度プロパティ</summary>
    //    /// <value>初年度(YYYYMM)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   初年度プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime FirstEntryDate
    //    {
    //        get { return _firstEntryDate; }
    //        set { _firstEntryDate = value; }
    //    }

    //    /// public propaty name  :  SearchFrameNo
    //    /// <summary>車台№プロパティ</summary>
    //    /// <value>車台番号（検索用）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車台№プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SearchFrameNo
    //    {
    //        get { return _searchFrameNo; }
    //        set { _searchFrameNo = value; }
    //    }

    //    /// public propaty name  :  FullModel
    //    /// <summary>型式（フル型）プロパティ</summary>
    //    /// <value>型式（フル型）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   型式（フル型）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FullModel
    //    {
    //        get { return _fullModel; }
    //        set { _fullModel = value; }
    //    }

    //    /// public propaty name  :  SlipNote
    //    /// <summary>伝票備考プロパティ</summary>
    //    /// <value>伝票備考/伝票摘要</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票備考プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote
    //    {
    //        get { return _slipNote; }
    //        set { _slipNote = value; }
    //    }

    //    /// public propaty name  :  SlipNote2
    //    /// <summary>伝票備考２プロパティ</summary>
    //    /// <value>伝票備考２</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票備考２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote2
    //    {
    //        get { return _slipNote2; }
    //        set { _slipNote2 = value; }
    //    }

    //    /// public propaty name  :  SlipNote3
    //    /// <summary>伝票備考３プロパティ</summary>
    //    /// <value>伝票備考３</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票備考３プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote3
    //    {
    //        get { return _slipNote3; }
    //        set { _slipNote3 = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeNm
    //    /// <summary>受付従業員名称プロパティ</summary>
    //    /// <value>受付従業員名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受付従業員名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FrontEmployeeNm
    //    {
    //        get { return _frontEmployeeNm; }
    //        set { _frontEmployeeNm = value; }
    //    }

    //    /// public propaty name  :  SalesInputName
    //    /// <summary>売上入力者名称プロパティ</summary>
    //    /// <value>売上入力者名称/入金入力者名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上入力者名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesInputName
    //    {
    //        get { return _salesInputName; }
    //        set { _salesInputName = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>得意先コードプロパティ</summary>
    //    /// <value>得意先コード/得意先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  CustomerSnm
    //    /// <summary>得意先略称プロパティ</summary>
    //    /// <value>得意先略称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先略称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CustomerSnm
    //    {
    //        get { return _customerSnm; }
    //        set { _customerSnm = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>仕入先コードプロパティ</summary>
    //    /// <value>仕入先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get { return _supplierCd; }
    //        set { _supplierCd = value; }
    //    }

    //    /// public propaty name  :  SupplierSnm
    //    /// <summary>仕入先略称プロパティ</summary>
    //    /// <value>仕入先略称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先略称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSnm
    //    {
    //        get { return _supplierSnm; }
    //        set { _supplierSnm = value; }
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>相手先伝票番号プロパティ</summary>
    //    /// <value>相手先伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   相手先伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get { return _partySaleSlipNum; }
    //        set { _partySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  CarMngCode
    //    /// <summary>車両管理コードプロパティ</summary>
    //    /// <value>車輌管理コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車両管理コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CarMngCode
    //    {
    //        get { return _carMngCode; }
    //        set { _carMngCode = value; }
    //    }

    //    /// public propaty name  :  AcceptAnOrderNo
    //    /// <summary>受注番号プロパティ</summary>
    //    /// <value>計上元受注番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受注番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AcceptAnOrderNo
    //    {
    //        get { return _acceptAnOrderNo; }
    //        set { _acceptAnOrderNo = value; }
    //    }

    //    /// public propaty name  :  ShipmSalesSlipNum
    //    /// <summary>計上元出荷№プロパティ</summary>
    //    /// <value>計上元出荷番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上元出荷№プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ShipmSalesSlipNum
    //    {
    //        get { return _shipmSalesSlipNum; }
    //        set { _shipmSalesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SrcSalesSlipNum
    //    /// <summary>元黒№(明細表示)プロパティ</summary>
    //    /// <value>元黒伝番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   元黒№(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SrcSalesSlipNum
    //    {
    //        get { return _srcSalesSlipNum; }
    //        set { _srcSalesSlipNum = value; }
    //    }

    //    /// public propaty name  :  SalesOrderDivCd
    //    /// <summary>売上在庫取寄せ区分プロパティ</summary>
    //    /// <value>売上在庫取寄せ区分(0:取寄せ，1:在庫)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesOrderDivCd
    //    {
    //        get { return _salesOrderDivCd; }
    //        set { _salesOrderDivCd = value; }
    //    }

    //    /// public propaty name  :  WarehouseName
    //    /// <summary>倉庫名称プロパティ</summary>
    //    /// <value>倉庫名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseName
    //    {
    //        get { return _warehouseName; }
    //        set { _warehouseName = value; }
    //    }

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>仕入伝票番号プロパティ</summary>
    //    /// <value>同時仕入伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierSlipNo
    //    {
    //        get { return _supplierSlipNo; }
    //        set { _supplierSlipNo = value; }
    //    }

    //    /// public propaty name  :  UOESupplierCd
    //    /// <summary>UOE発注先コードプロパティ</summary>
    //    /// <value>ＵＯＥ発注データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   UOE発注先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 UOESupplierCd
    //    {
    //        get { return _uOESupplierCd; }
    //        set { _uOESupplierCd = value; }
    //    }

    //    /// public propaty name  :  UOESupplierSnm
    //    /// <summary>発注先名(明細表示)プロパティ</summary>
    //    /// <value>ＵＯＥ発注データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   発注先名(明細表示)プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UOESupplierSnm
    //    {
    //        get { return _uOESupplierSnm; }
    //        set { _uOESupplierSnm = value; }
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>ＵＯＥリマーク１プロパティ</summary>
    //    /// <value>ＵＯＥリマーク１</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get { return _uoeRemark1; }
    //        set { _uoeRemark1 = value; }
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>ＵＯＥリマーク２プロパティ</summary>
    //    /// <value>ＵＯＥリマーク２</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get { return _uoeRemark2; }
    //        set { _uoeRemark2 = value; }
    //    }

    //    /// public propaty name  :  GuideName
    //    /// <summary>ガイド名称プロパティ</summary>
    //    /// <value>ガイド名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ガイド名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GuideName
    //    {
    //        get { return _guideName; }
    //        set { _guideName = value; }
    //    }

    //    /// public propaty name  :  SectionGuideNm
    //    /// <summary>拠点ガイド名称プロパティ</summary>
    //    /// <value>拠点ガイド名称/計上拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点ガイド名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionGuideNm
    //    {
    //        get { return _sectionGuideNm; }
    //        set { _sectionGuideNm = value; }
    //    }

    //    /// public propaty name  :  DtlNote
    //    /// <summary>明細備考プロパティ</summary>
    //    /// <value>明細備考/</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   明細備考プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string DtlNote
    //    {
    //        get { return _dtlNote; }
    //        set { _dtlNote = value; }
    //    }

    //    /// public propaty name  :  ColorName1
    //    /// <summary>カラー名称1プロパティ</summary>
    //    /// <value>カラー名称1</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   カラー名称1プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ColorName1
    //    {
    //        get { return _colorName1; }
    //        set { _colorName1 = value; }
    //    }

    //    /// public propaty name  :  TrimName
    //    /// <summary>トリム名称プロパティ</summary>
    //    /// <value>トリム名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   トリム名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string TrimName
    //    {
    //        get { return _trimName; }
    //        set { _trimName = value; }
    //    }

    //    /// public propaty name  :  StdUnPrcLPrice
    //    /// <summary>基準単価（定価）プロパティ</summary>
    //    /// <value>基準単価（定価）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   基準単価（定価）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double StdUnPrcLPrice
    //    {
    //        get { return _stdUnPrcLPrice; }
    //        set { _stdUnPrcLPrice = value; }
    //    }

    //    /// public propaty name  :  StdUnPrcSalUnPrc
    //    /// <summary>基準単価（売上単価）プロパティ</summary>
    //    /// <value>基準単価（売上単価）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   基準単価（売上単価）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double StdUnPrcSalUnPrc
    //    {
    //        get { return _stdUnPrcSalUnPrc; }
    //        set { _stdUnPrcSalUnPrc = value; }
    //    }

    //    /// public propaty name  :  StdUnPrcUnCst
    //    /// <summary>基準単価（原価単価）プロパティ</summary>
    //    /// <value>基準単価（原価単価）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   基準単価（原価単価）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double StdUnPrcUnCst
    //    {
    //        get { return _stdUnPrcUnCst; }
    //        set { _stdUnPrcUnCst = value; }
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>商品メーカーコードプロパティ</summary>
    //    /// <value>商品メーカーコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品メーカーコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsMakerCd
    //    {
    //        get { return _goodsMakerCd; }
    //        set { _goodsMakerCd = value; }
    //    }

    //    /// public propaty name  :  MakerName
    //    /// <summary>メーカー名称プロパティ</summary>
    //    /// <value>メーカー名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカー名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string MakerName
    //    {
    //        get { return _makerName; }
    //        set { _makerName = value; }
    //    }

    //    /// public propaty name  :  Cost
    //    /// <summary>原価プロパティ</summary>
    //    /// <value>売上明細データ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   原価プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 Cost
    //    {
    //        get { return _cost; }
    //        set { _cost = value; }
    //    }

    //    /// public propaty name  :  CustSlipNo
    //    /// <summary>得意先伝票番号プロパティ</summary>
    //    /// <value>得意先伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustSlipNo
    //    {
    //        get { return _custSlipNo; }
    //        set { _custSlipNo = value; }
    //    }

    //    /// public propaty name  :  AddUpADate
    //    /// <summary>計上日付プロパティ</summary>
    //    /// <value>計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime AddUpADate
    //    {
    //        get { return _addUpADate; }
    //        set { _addUpADate = value; }
    //    }

    //    /// public propaty name  :  AccRecDivCd
    //    /// <summary>売掛区分プロパティ</summary>
    //    /// <value>売掛区分(0:売掛なし,1:売掛)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売掛区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AccRecDivCd
    //    {
    //        get { return _accRecDivCd; }
    //        set { _accRecDivCd = value; }
    //    }

    //    /// public propaty name  :  DebitNoteDiv
    //    /// <summary>赤伝区分プロパティ</summary>
    //    /// <value>赤伝区分(0:黒伝,1:赤伝,2:元黒)/入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   赤伝区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DebitNoteDiv
    //    {
    //        get { return _debitNoteDiv; }
    //        set { _debitNoteDiv = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>拠点コードプロパティ</summary>
    //    /// <value>拠点コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
    //    }

    //    /// public propaty name  :  WarehouseCode
    //    /// <summary>倉庫コードプロパティ</summary>
    //    /// <value>倉庫コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseCode
    //    {
    //        get { return _warehouseCode; }
    //        set { _warehouseCode = value; }
    //    }

    //    /// public propaty name  :  TotalAmountDispWayCd
    //    /// <summary>総額表示方法区分プロパティ</summary>
    //    /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   総額表示方法区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TotalAmountDispWayCd
    //    {
    //        get { return _totalAmountDispWayCd; }
    //        set { _totalAmountDispWayCd = value; }
    //    }

    //    /// public propaty name  :  TaxationDivCd
    //    /// <summary>課税区分[明細]プロパティ</summary>
    //    /// <value>0:課税,1:非課税,2:課税（内税）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   課税区分[明細]プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TaxationDivCd
    //    {
    //        get { return _taxationDivCd; }
    //        set { _taxationDivCd = value; }
    //    }

    //    /// public propaty name  :  StockPartySaleSlipNum
    //    /// <summary>相手先伝票番号プロパティ</summary>
    //    /// <value>仕入先伝票番号に使用する</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   相手先伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string StockPartySaleSlipNum
    //    {
    //        get { return _stockPartySaleSlipNum; }
    //        set { _stockPartySaleSlipNum = value; }
    //    }

    //    /// public propaty name  :  AddresseeCode
    //    /// <summary>納品先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AddresseeCode
    //    {
    //        get { return _addresseeCode; }
    //        set { _addresseeCode = value; }
    //    }

    //    /// public propaty name  :  AddresseeName
    //    /// <summary>納品先名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeName
    //    {
    //        get { return _addresseeName; }
    //        set { _addresseeName = value; }
    //    }

    //    /// public propaty name  :  AddresseeName2
    //    /// <summary>納品先名称2プロパティ</summary>
    //    /// <value>追加(登録漏れ) 塩原</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先名称2プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string AddresseeName2
    //    {
    //        get { return _addresseeName2; }
    //        set { _addresseeName2 = value; }
    //    }

    //    /// public propaty name  :  FrameNo
    //    /// <summary>車台番号プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車台番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FrameNo
    //    {
    //        get { return _frameNo; }
    //        set { _frameNo = value; }
    //    }

    //    /// public propaty name  :  AcptAnOdrRemainCnt
    //    /// <summary>受注残数プロパティ</summary>
    //    /// <value>受注数量＋受注調整数－出荷数</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受注残数プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Double AcptAnOdrRemainCnt
    //    {
    //        get { return _acptAnOdrRemainCnt; }
    //        set { _acptAnOdrRemainCnt = value; }
    //    }

    //    /// public propaty name  :  EnterpriseGanreCode
    //    /// <summary>自社分類コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   自社分類コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EnterpriseGanreCode
    //    {
    //        get { return _enterpriseGanreCode; }
    //        set { _enterpriseGanreCode = value; }
    //    }

    //    /// public propaty name  :  FeeDeposit
    //    /// <summary>手数料入金額プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   手数料入金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 FeeDeposit
    //    {
    //        get { return _feeDeposit; }
    //        set { _feeDeposit = value; }
    //    }

    //    /// public propaty name  :  DiscountDeposit
    //    /// <summary>値引入金額プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   値引入金額プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 DiscountDeposit
    //    {
    //        get { return _discountDeposit; }
    //        set { _discountDeposit = value; }
    //    }

    //    /// public propaty name  :  InputDay
    //    /// <summary>入力日プロパティ</summary>
    //    /// <value>YYYYMMDD　（更新年月日）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   入力日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime InputDay
    //    {
    //        get { return _inputDay; }
    //        set { _inputDay = value; }
    //    }

    //    /// public propaty name  :  GoodsKindCode
    //    /// <summary>商品属性プロパティ</summary>
    //    /// <value>0:純正 1:優良</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品属性プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsKindCode
    //    {
    //        get { return _goodsKindCode; }
    //        set { _goodsKindCode = value; }
    //    }

    //    /// public propaty name  :  GoodsLGroup
    //    /// <summary>商品大分類コードプロパティ</summary>
    //    /// <value>旧大分類（ユーザーガイド）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品大分類コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsLGroup
    //    {
    //        get { return _goodsLGroup; }
    //        set { _goodsLGroup = value; }
    //    }

    //    /// public propaty name  :  GoodsMGroup
    //    /// <summary>商品中分類コードプロパティ</summary>
    //    /// <value>旧中分類コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品中分類コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsMGroup
    //    {
    //        get { return _goodsMGroup; }
    //        set { _goodsMGroup = value; }
    //    }

    //    /// public propaty name  :  WarehouseShelfNo
    //    /// <summary>倉庫棚番プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫棚番プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseShelfNo
    //    {
    //        get { return _warehouseShelfNo; }
    //        set { _warehouseShelfNo = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCdDtl
    //    /// <summary>売上伝票区分（明細）プロパティ</summary>
    //    /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票区分（明細）プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCdDtl
    //    {
    //        get { return _salesSlipCdDtl; }
    //        set { _salesSlipCdDtl = value; }
    //    }

    //    /// public propaty name  :  GoodsLGroupName
    //    /// <summary>商品大分類名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品大分類名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsLGroupName
    //    {
    //        get { return _goodsLGroupName; }
    //        set { _goodsLGroupName = value; }
    //    }

    //    /// public propaty name  :  GoodsMGroupName
    //    /// <summary>商品中分類名称プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   商品中分類名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsMGroupName
    //    {
    //        get { return _goodsMGroupName; }
    //        set { _goodsMGroupName = value; }
    //    }

    //    /// public propaty name  :  CarMngNo
    //    /// <summary>車両管理番号プロパティ</summary>
    //    /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車両管理番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CarMngNo
    //    {
    //        get { return _carMngNo; }
    //        set { _carMngNo = value; }
    //    }

    //    /// public propaty name  :  MakerCode
    //    /// <summary>メーカーコードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカーコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 MakerCode
    //    {
    //        get { return _makerCode; }
    //        set { _makerCode = value; }
    //    }

    //    /// public propaty name  :  ModelCode
    //    /// <summary>車種コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車種コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ModelCode
    //    {
    //        get { return _modelCode; }
    //        set { _modelCode = value; }
    //    }

    //    /// public propaty name  :  ModelSubCode
    //    /// <summary>車種サブコードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車種サブコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ModelSubCode
    //    {
    //        get { return _modelSubCode; }
    //        set { _modelSubCode = value; }
    //    }

    //    /// public propaty name  :  EngineModelNm
    //    /// <summary>エンジン型式名称プロパティ</summary>
    //    /// <value>型式により変動</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   エンジン型式名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EngineModelNm
    //    {
    //        get { return _engineModelNm; }
    //        set { _engineModelNm = value; }
    //    }

    //    /// public propaty name  :  ColorCode
    //    /// <summary>カラーコードプロパティ</summary>
    //    /// <value>カタログの色コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   カラーコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ColorCode
    //    {
    //        get { return _colorCode; }
    //        set { _colorCode = value; }
    //    }

    //    /// public propaty name  :  TrimCode
    //    /// <summary>トリムコードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   トリムコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string TrimCode
    //    {
    //        get { return _trimCode; }
    //        set { _trimCode = value; }
    //    }

    //    /// public propaty name  :  DeliveredGoodsDiv
    //    /// <summary>納品区分プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DeliveredGoodsDiv
    //    {
    //        get { return _deliveredGoodsDiv; }
    //        set { _deliveredGoodsDiv = value; }
    //    }

    //    /// public propaty name  :  FullModelFixedNoAry
    //    /// <summary>フル型式固定番号配列プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   フル型式固定番号配列プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32[] FullModelFixedNoAry
    //    {
    //        get { return _fullModelFixedNoAry; }
    //        set { _fullModelFixedNoAry = value; }
    //    }

    //    /// public propaty name  :  CategoryObjAry
    //    /// <summary>装備オブジェクト配列プロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   装備オブジェクト配列プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Byte[] CategoryObjAry
    //    {
    //        get { return _categoryObjAry; }
    //        set { _categoryObjAry = value; }
    //    }

    //    /// public propaty name  :  SalesInputCode
    //    /// <summary>売上入力者コードプロパティ</summary>
    //    /// <value>入力担当者（発行者）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上入力者コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesInputCode
    //    {
    //        get { return _salesInputCode; }
    //        set { _salesInputCode = value; }
    //    }

    //    /// public propaty name  :  FrontEmployeeCd
    //    /// <summary>受付従業員コードプロパティ</summary>
    //    /// <value>受付担当者（受注者）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受付従業員コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FrontEmployeeCd
    //    {
    //        get { return _frontEmployeeCd; }
    //        set { _frontEmployeeCd = value; }
    //    }


    //    /// <summary>
    //    /// 得意先電子元帳抽出結果(伝票・明細)クラスワークコンストラクタ
    //    /// </summary>
    //    /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public CustPrtPprSalTblRsltWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is CustPrtPprSalTblRsltWork || graph is ArrayList || graph is CustPrtPprSalTblRsltWork[]) )
    //            throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( CustPrtPprSalTblRsltWork ).FullName ) );

    //        if ( graph != null && graph is CustPrtPprSalTblRsltWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork" );

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is CustPrtPprSalTblRsltWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((CustPrtPprSalTblRsltWork[])graph).Length;
    //        }
    //        else if ( graph is CustPrtPprSalTblRsltWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //データ区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
    //        //売上日付
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
    //        //売上伝票番号
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
    //        //売上行番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesRowNo
    //        //受注ステータス
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcptAnOdrStatus
    //        //売上伝票区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCd
    //        //販売従業員名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesEmployeeNm
    //        //売上伝票合計（税抜き）
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxExc
    //        //商品名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
    //        //商品番号
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
    //        //BL商品コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
    //        //BLグループコード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
    //        //出荷数
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //ShipmentCnt
    //        //定価（税抜，浮動）
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
    //        //オープン価格区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
    //        //売上単価（税抜，浮動）
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnPrcTaxExcFl
    //        //原価単価
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnitCost
    //        //売上金額（税抜き）
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesMoneyTaxExc
    //        //消費税転嫁方式
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConsTaxLayMethod
    //        //売上伝票合計（税込み）
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxInc
    //        //売上金額消費税額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPriceConsTax
    //        //原価金額計
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //TotalCost
    //        //型式指定番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelDesignationNo
    //        //類別番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CategoryNo
    //        //車種全角名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
    //        //初年度
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //FirstEntryDate
    //        //車台№
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SearchFrameNo
    //        //型式（フル型）
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
    //        //伝票備考
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote
    //        //伝票備考２
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote2
    //        //伝票備考３
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote3
    //        //受付従業員名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeNm
    //        //売上入力者名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputName
    //        //得意先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
    //        //得意先略称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
    //        //仕入先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
    //        //仕入先略称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
    //        //相手先伝票番号
    //        serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
    //        //車両管理コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //CarMngCode
    //        //受注番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcceptAnOrderNo
    //        //計上元出荷№
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ShipmSalesSlipNum
    //        //元黒№(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SrcSalesSlipNum
    //        //売上在庫取寄せ区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesOrderDivCd
    //        //倉庫名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
    //        //仕入伝票番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
    //        //UOE発注先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //UOESupplierCd
    //        //発注先名(明細表示)
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UOESupplierSnm
    //        //ＵＯＥリマーク１
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
    //        //ＵＯＥリマーク２
    //        serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
    //        //ガイド名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GuideName
    //        //拠点ガイド名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
    //        //明細備考
    //        serInfo.MemberInfo.Add( typeof( string ) ); //DtlNote
    //        //カラー名称1
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ColorName1
    //        //トリム名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //TrimName
    //        //基準単価（定価）
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcLPrice
    //        //基準単価（売上単価）
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcSalUnPrc
    //        //基準単価（原価単価）
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcUnCst
    //        //商品メーカーコード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
    //        //メーカー名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
    //        //原価
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //Cost
    //        //得意先伝票番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustSlipNo
    //        //計上日付
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpADate
    //        //売掛区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccRecDivCd
    //        //赤伝区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
    //        //拠点コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
    //        //倉庫コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
    //        //総額表示方法区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalAmountDispWayCd
    //        //課税区分[明細]
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationDivCd
    //        //相手先伝票番号
    //        serInfo.MemberInfo.Add( typeof( string ) ); //StockPartySaleSlipNum
    //        //納品先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddresseeCode
    //        //納品先名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName
    //        //納品先名称2
    //        serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName2
    //        //車台番号
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FrameNo
    //        //受注残数
    //        serInfo.MemberInfo.Add( typeof( Double ) ); //AcptAnOdrRemainCnt
    //        //自社分類コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //EnterpriseGanreCode
    //        //手数料入金額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeeDeposit
    //        //値引入金額
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountDeposit
    //        //入力日
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
    //        //商品属性
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsKindCode
    //        //商品大分類コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsLGroup
    //        //商品中分類コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
    //        //倉庫棚番
    //        serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
    //        //売上伝票区分（明細）
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCdDtl
    //        //商品大分類名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsLGroupName
    //        //商品中分類名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //GoodsMGroupName
    //        //車両管理番号
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarMngNo
    //        //メーカーコード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
    //        //車種コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
    //        //車種サブコード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
    //        //エンジン型式名称
    //        serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
    //        //カラーコード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //ColorCode
    //        //トリムコード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //TrimCode
    //        //納品区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //DeliveredGoodsDiv
    //        //フル型式固定番号配列
    //        serInfo.MemberInfo.Add( typeof( Int32[] ) ); //FullModelFixedNoAry
    //        //装備オブジェクト配列
    //        serInfo.MemberInfo.Add( typeof( Byte[] ) ); //CategoryObjAry
    //        //売上入力者コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputCode
    //        //受付従業員コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeCd


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is CustPrtPprSalTblRsltWork )
    //        {
    //            CustPrtPprSalTblRsltWork temp = (CustPrtPprSalTblRsltWork)graph;

    //            SetCustPrtPprSalTblRsltWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is CustPrtPprSalTblRsltWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (CustPrtPprSalTblRsltWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( CustPrtPprSalTblRsltWork temp in lst )
    //            {
    //                SetCustPrtPprSalTblRsltWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// CustPrtPprSalTblRsltWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 97;

    //    /// <summary>
    //    ///  CustPrtPprSalTblRsltWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetCustPrtPprSalTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprSalTblRsltWork temp )
    //    {
    //        //データ区分
    //        writer.Write( temp.DataDiv );
    //        //売上日付
    //        writer.Write( (Int64)temp.SalesDate.Ticks );
    //        //売上伝票番号
    //        writer.Write( temp.SalesSlipNum );
    //        //売上行番号
    //        writer.Write( temp.SalesRowNo );
    //        //受注ステータス
    //        writer.Write( temp.AcptAnOdrStatus );
    //        //売上伝票区分
    //        writer.Write( temp.SalesSlipCd );
    //        //販売従業員名称
    //        writer.Write( temp.SalesEmployeeNm );
    //        //売上伝票合計（税抜き）
    //        writer.Write( temp.SalesTotalTaxExc );
    //        //商品名称
    //        writer.Write( temp.GoodsName );
    //        //商品番号
    //        writer.Write( temp.GoodsNo );
    //        //BL商品コード
    //        writer.Write( temp.BLGoodsCode );
    //        //BLグループコード
    //        writer.Write( temp.BLGroupCode );
    //        //出荷数
    //        writer.Write( temp.ShipmentCnt );
    //        //定価（税抜，浮動）
    //        writer.Write( temp.ListPriceTaxExcFl );
    //        //オープン価格区分
    //        writer.Write( temp.OpenPriceDiv );
    //        //売上単価（税抜，浮動）
    //        writer.Write( temp.SalesUnPrcTaxExcFl );
    //        //原価単価
    //        writer.Write( temp.SalesUnitCost );
    //        //売上金額（税抜き）
    //        writer.Write( temp.SalesMoneyTaxExc );
    //        //消費税転嫁方式
    //        writer.Write( temp.ConsTaxLayMethod );
    //        //売上伝票合計（税込み）
    //        writer.Write( temp.SalesTotalTaxInc );
    //        //売上金額消費税額
    //        writer.Write( temp.SalesPriceConsTax );
    //        //原価金額計
    //        writer.Write( temp.TotalCost );
    //        //型式指定番号
    //        writer.Write( temp.ModelDesignationNo );
    //        //類別番号
    //        writer.Write( temp.CategoryNo );
    //        //車種全角名称
    //        writer.Write( temp.ModelFullName );
    //        //初年度
    //        writer.Write( (Int64)temp.FirstEntryDate.Ticks );
    //        //車台№
    //        writer.Write( temp.SearchFrameNo );
    //        //型式（フル型）
    //        writer.Write( temp.FullModel );
    //        //伝票備考
    //        writer.Write( temp.SlipNote );
    //        //伝票備考２
    //        writer.Write( temp.SlipNote2 );
    //        //伝票備考３
    //        writer.Write( temp.SlipNote3 );
    //        //受付従業員名称
    //        writer.Write( temp.FrontEmployeeNm );
    //        //売上入力者名称
    //        writer.Write( temp.SalesInputName );
    //        //得意先コード
    //        writer.Write( temp.CustomerCode );
    //        //得意先略称
    //        writer.Write( temp.CustomerSnm );
    //        //仕入先コード
    //        writer.Write( temp.SupplierCd );
    //        //仕入先略称
    //        writer.Write( temp.SupplierSnm );
    //        //相手先伝票番号
    //        writer.Write( temp.PartySaleSlipNum );
    //        //車両管理コード
    //        writer.Write( temp.CarMngCode );
    //        //受注番号
    //        writer.Write( temp.AcceptAnOrderNo );
    //        //計上元出荷№
    //        writer.Write( temp.ShipmSalesSlipNum );
    //        //元黒№(明細表示)
    //        writer.Write( temp.SrcSalesSlipNum );
    //        //売上在庫取寄せ区分
    //        writer.Write( temp.SalesOrderDivCd );
    //        //倉庫名称
    //        writer.Write( temp.WarehouseName );
    //        //仕入伝票番号
    //        writer.Write( temp.SupplierSlipNo );
    //        //UOE発注先コード
    //        writer.Write( temp.UOESupplierCd );
    //        //発注先名(明細表示)
    //        writer.Write( temp.UOESupplierSnm );
    //        //ＵＯＥリマーク１
    //        writer.Write( temp.UoeRemark1 );
    //        //ＵＯＥリマーク２
    //        writer.Write( temp.UoeRemark2 );
    //        //ガイド名称
    //        writer.Write( temp.GuideName );
    //        //拠点ガイド名称
    //        writer.Write( temp.SectionGuideNm );
    //        //明細備考
    //        writer.Write( temp.DtlNote );
    //        //カラー名称1
    //        writer.Write( temp.ColorName1 );
    //        //トリム名称
    //        writer.Write( temp.TrimName );
    //        //基準単価（定価）
    //        writer.Write( temp.StdUnPrcLPrice );
    //        //基準単価（売上単価）
    //        writer.Write( temp.StdUnPrcSalUnPrc );
    //        //基準単価（原価単価）
    //        writer.Write( temp.StdUnPrcUnCst );
    //        //商品メーカーコード
    //        writer.Write( temp.GoodsMakerCd );
    //        //メーカー名称
    //        writer.Write( temp.MakerName );
    //        //原価
    //        writer.Write( temp.Cost );
    //        //得意先伝票番号
    //        writer.Write( temp.CustSlipNo );
    //        //計上日付
    //        writer.Write( (Int64)temp.AddUpADate.Ticks );
    //        //売掛区分
    //        writer.Write( temp.AccRecDivCd );
    //        //赤伝区分
    //        writer.Write( temp.DebitNoteDiv );
    //        //拠点コード
    //        writer.Write( temp.SectionCode );
    //        //倉庫コード
    //        writer.Write( temp.WarehouseCode );
    //        //総額表示方法区分
    //        writer.Write( temp.TotalAmountDispWayCd );
    //        //課税区分[明細]
    //        writer.Write( temp.TaxationDivCd );
    //        //相手先伝票番号
    //        writer.Write( temp.StockPartySaleSlipNum );
    //        //納品先コード
    //        writer.Write( temp.AddresseeCode );
    //        //納品先名称
    //        writer.Write( temp.AddresseeName );
    //        //納品先名称2
    //        writer.Write( temp.AddresseeName2 );
    //        //車台番号
    //        writer.Write( temp.FrameNo );
    //        //受注残数
    //        writer.Write( temp.AcptAnOdrRemainCnt );
    //        //自社分類コード
    //        writer.Write( temp.EnterpriseGanreCode );
    //        //手数料入金額
    //        writer.Write( temp.FeeDeposit );
    //        //値引入金額
    //        writer.Write( temp.DiscountDeposit );
    //        //入力日
    //        writer.Write( (Int64)temp.InputDay.Ticks );
    //        //商品属性
    //        writer.Write( temp.GoodsKindCode );
    //        //商品大分類コード
    //        writer.Write( temp.GoodsLGroup );
    //        //商品中分類コード
    //        writer.Write( temp.GoodsMGroup );
    //        //倉庫棚番
    //        writer.Write( temp.WarehouseShelfNo );
    //        //売上伝票区分（明細）
    //        writer.Write( temp.SalesSlipCdDtl );
    //        //商品大分類名称
    //        writer.Write( temp.GoodsLGroupName );
    //        //商品中分類名称
    //        writer.Write( temp.GoodsMGroupName );
    //        //車両管理番号
    //        writer.Write( temp.CarMngNo );
    //        //メーカーコード
    //        writer.Write( temp.MakerCode );
    //        //車種コード
    //        writer.Write( temp.ModelCode );
    //        //車種サブコード
    //        writer.Write( temp.ModelSubCode );
    //        //エンジン型式名称
    //        writer.Write( temp.EngineModelNm );
    //        //カラーコード
    //        writer.Write( temp.ColorCode );
    //        //トリムコード
    //        writer.Write( temp.TrimCode );
    //        //納品区分
    //        writer.Write( temp.DeliveredGoodsDiv );
    //        //フル型式固定番号配列
    //        if ( temp.FullModelFixedNoAry == null ) temp.FullModelFixedNoAry = new int[0];
    //        int length = temp.FullModelFixedNoAry.Length;
    //        writer.Write( length );
    //        for ( int cnt = 0; cnt < length; cnt++ )
    //            writer.Write( temp.FullModelFixedNoAry[cnt] );
    //        //装備オブジェクト配列
    //        if ( temp.CategoryObjAry == null ) temp.CategoryObjAry = new byte[0];
    //        writer.Write( temp.CategoryObjAry.Length );
    //        writer.Write( temp.CategoryObjAry );
    //        //売上入力者コード
    //        writer.Write( temp.SalesInputCode );
    //        //受付従業員コード
    //        writer.Write( temp.FrontEmployeeCd );

    //    }

    //    /// <summary>
    //    ///  CustPrtPprSalTblRsltWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private CustPrtPprSalTblRsltWork GetCustPrtPprSalTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        CustPrtPprSalTblRsltWork temp = new CustPrtPprSalTblRsltWork();

    //        //データ区分
    //        temp.DataDiv = reader.ReadInt32();
    //        //売上日付
    //        temp.SalesDate = new DateTime( reader.ReadInt64() );
    //        //売上伝票番号
    //        temp.SalesSlipNum = reader.ReadString();
    //        //売上行番号
    //        temp.SalesRowNo = reader.ReadInt32();
    //        //受注ステータス
    //        temp.AcptAnOdrStatus = reader.ReadInt32();
    //        //売上伝票区分
    //        temp.SalesSlipCd = reader.ReadInt32();
    //        //販売従業員名称
    //        temp.SalesEmployeeNm = reader.ReadString();
    //        //売上伝票合計（税抜き）
    //        temp.SalesTotalTaxExc = reader.ReadInt64();
    //        //商品名称
    //        temp.GoodsName = reader.ReadString();
    //        //商品番号
    //        temp.GoodsNo = reader.ReadString();
    //        //BL商品コード
    //        temp.BLGoodsCode = reader.ReadInt32();
    //        //BLグループコード
    //        temp.BLGroupCode = reader.ReadInt32();
    //        //出荷数
    //        temp.ShipmentCnt = reader.ReadDouble();
    //        //定価（税抜，浮動）
    //        temp.ListPriceTaxExcFl = reader.ReadDouble();
    //        //オープン価格区分
    //        temp.OpenPriceDiv = reader.ReadInt32();
    //        //売上単価（税抜，浮動）
    //        temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
    //        //原価単価
    //        temp.SalesUnitCost = reader.ReadDouble();
    //        //売上金額（税抜き）
    //        temp.SalesMoneyTaxExc = reader.ReadInt64();
    //        //消費税転嫁方式
    //        temp.ConsTaxLayMethod = reader.ReadInt32();
    //        //売上伝票合計（税込み）
    //        temp.SalesTotalTaxInc = reader.ReadInt64();
    //        //売上金額消費税額
    //        temp.SalesPriceConsTax = reader.ReadInt64();
    //        //原価金額計
    //        temp.TotalCost = reader.ReadInt64();
    //        //型式指定番号
    //        temp.ModelDesignationNo = reader.ReadInt32();
    //        //類別番号
    //        temp.CategoryNo = reader.ReadInt32();
    //        //車種全角名称
    //        temp.ModelFullName = reader.ReadString();
    //        //初年度
    //        temp.FirstEntryDate = new DateTime( reader.ReadInt64() );
    //        //車台№
    //        temp.SearchFrameNo = reader.ReadInt32();
    //        //型式（フル型）
    //        temp.FullModel = reader.ReadString();
    //        //伝票備考
    //        temp.SlipNote = reader.ReadString();
    //        //伝票備考２
    //        temp.SlipNote2 = reader.ReadString();
    //        //伝票備考３
    //        temp.SlipNote3 = reader.ReadString();
    //        //受付従業員名称
    //        temp.FrontEmployeeNm = reader.ReadString();
    //        //売上入力者名称
    //        temp.SalesInputName = reader.ReadString();
    //        //得意先コード
    //        temp.CustomerCode = reader.ReadInt32();
    //        //得意先略称
    //        temp.CustomerSnm = reader.ReadString();
    //        //仕入先コード
    //        temp.SupplierCd = reader.ReadInt32();
    //        //仕入先略称
    //        temp.SupplierSnm = reader.ReadString();
    //        //相手先伝票番号
    //        temp.PartySaleSlipNum = reader.ReadString();
    //        //車両管理コード
    //        temp.CarMngCode = reader.ReadString();
    //        //受注番号
    //        temp.AcceptAnOrderNo = reader.ReadInt32();
    //        //計上元出荷№
    //        temp.ShipmSalesSlipNum = reader.ReadString();
    //        //元黒№(明細表示)
    //        temp.SrcSalesSlipNum = reader.ReadString();
    //        //売上在庫取寄せ区分
    //        temp.SalesOrderDivCd = reader.ReadInt32();
    //        //倉庫名称
    //        temp.WarehouseName = reader.ReadString();
    //        //仕入伝票番号
    //        temp.SupplierSlipNo = reader.ReadInt32();
    //        //UOE発注先コード
    //        temp.UOESupplierCd = reader.ReadInt32();
    //        //発注先名(明細表示)
    //        temp.UOESupplierSnm = reader.ReadString();
    //        //ＵＯＥリマーク１
    //        temp.UoeRemark1 = reader.ReadString();
    //        //ＵＯＥリマーク２
    //        temp.UoeRemark2 = reader.ReadString();
    //        //ガイド名称
    //        temp.GuideName = reader.ReadString();
    //        //拠点ガイド名称
    //        temp.SectionGuideNm = reader.ReadString();
    //        //明細備考
    //        temp.DtlNote = reader.ReadString();
    //        //カラー名称1
    //        temp.ColorName1 = reader.ReadString();
    //        //トリム名称
    //        temp.TrimName = reader.ReadString();
    //        //基準単価（定価）
    //        temp.StdUnPrcLPrice = reader.ReadDouble();
    //        //基準単価（売上単価）
    //        temp.StdUnPrcSalUnPrc = reader.ReadDouble();
    //        //基準単価（原価単価）
    //        temp.StdUnPrcUnCst = reader.ReadDouble();
    //        //商品メーカーコード
    //        temp.GoodsMakerCd = reader.ReadInt32();
    //        //メーカー名称
    //        temp.MakerName = reader.ReadString();
    //        //原価
    //        temp.Cost = reader.ReadInt64();
    //        //得意先伝票番号
    //        temp.CustSlipNo = reader.ReadInt32();
    //        //計上日付
    //        temp.AddUpADate = new DateTime( reader.ReadInt64() );
    //        //売掛区分
    //        temp.AccRecDivCd = reader.ReadInt32();
    //        //赤伝区分
    //        temp.DebitNoteDiv = reader.ReadInt32();
    //        //拠点コード
    //        temp.SectionCode = reader.ReadString();
    //        //倉庫コード
    //        temp.WarehouseCode = reader.ReadString();
    //        //総額表示方法区分
    //        temp.TotalAmountDispWayCd = reader.ReadInt32();
    //        //課税区分[明細]
    //        temp.TaxationDivCd = reader.ReadInt32();
    //        //相手先伝票番号
    //        temp.StockPartySaleSlipNum = reader.ReadString();
    //        //納品先コード
    //        temp.AddresseeCode = reader.ReadInt32();
    //        //納品先名称
    //        temp.AddresseeName = reader.ReadString();
    //        //納品先名称2
    //        temp.AddresseeName2 = reader.ReadString();
    //        //車台番号
    //        temp.FrameNo = reader.ReadString();
    //        //受注残数
    //        temp.AcptAnOdrRemainCnt = reader.ReadDouble();
    //        //自社分類コード
    //        temp.EnterpriseGanreCode = reader.ReadInt32();
    //        //手数料入金額
    //        temp.FeeDeposit = reader.ReadInt64();
    //        //値引入金額
    //        temp.DiscountDeposit = reader.ReadInt64();
    //        //入力日
    //        temp.InputDay = new DateTime( reader.ReadInt64() );
    //        //商品属性
    //        temp.GoodsKindCode = reader.ReadInt32();
    //        //商品大分類コード
    //        temp.GoodsLGroup = reader.ReadInt32();
    //        //商品中分類コード
    //        temp.GoodsMGroup = reader.ReadInt32();
    //        //倉庫棚番
    //        temp.WarehouseShelfNo = reader.ReadString();
    //        //売上伝票区分（明細）
    //        temp.SalesSlipCdDtl = reader.ReadInt32();
    //        //商品大分類名称
    //        temp.GoodsLGroupName = reader.ReadString();
    //        //商品中分類名称
    //        temp.GoodsMGroupName = reader.ReadString();
    //        //車両管理番号
    //        temp.CarMngNo = reader.ReadInt32();
    //        //メーカーコード
    //        temp.MakerCode = reader.ReadInt32();
    //        //車種コード
    //        temp.ModelCode = reader.ReadInt32();
    //        //車種サブコード
    //        temp.ModelSubCode = reader.ReadInt32();
    //        //エンジン型式名称
    //        temp.EngineModelNm = reader.ReadString();
    //        //カラーコード
    //        temp.ColorCode = reader.ReadString();
    //        //トリムコード
    //        temp.TrimCode = reader.ReadString();
    //        //納品区分
    //        temp.DeliveredGoodsDiv = reader.ReadInt32();
    //        //フル型式固定番号配列
    //        int length = reader.ReadInt32();
    //        temp.FullModelFixedNoAry = new int[length];
    //        for ( int cnt = 0; cnt < length; cnt++ )
    //            temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();
    //        //装備オブジェクト配列
    //        length = reader.ReadInt32();
    //        temp.CategoryObjAry = reader.ReadBytes( length );
    //        //売上入力者コード
    //        temp.SalesInputCode = reader.ReadString();
    //        //受付従業員コード
    //        temp.FrontEmployeeCd = reader.ReadString();


    //        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
    //        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
    //        //型情報にしたがって、ストリームから情報を読み出します...といっても
    //        //読み出して捨てることになります。
    //        for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
    //        {
    //            //byte[],char[]をデシリアライズする直前に、そのlengthが
    //            //デシリアライズされているケースがある、byte[],char[]の
    //            //デシリアライズにはlengthが必要なのでint型のデータをデ
    //            //シリアライズした場合は、この値をこの変数に退避します。
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if ( oMemberType is Type )
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
    //                if ( t.Equals( typeof( int ) ) )
    //                {
    //                    optCount = Convert.ToInt32( oData );
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if ( oMemberType is string )
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
    //                object userData = formatter.Deserialize( reader );  //読み飛ばし
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムデシリアライザです
    //    /// </summary>
    //    /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            CustPrtPprSalTblRsltWork temp = GetCustPrtPprSalTblRsltWork( reader, serInfo );
    //            lst.Add( temp );
    //        }
    //        switch ( serInfo.RetTypeInfo )
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (CustPrtPprSalTblRsltWork[])lst.ToArray( typeof( CustPrtPprSalTblRsltWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
    # endregion

# if false
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
    /// public class name:   CustPrtPprSalTblRsltWork
    /// <summary>
    ///                      得意先電子元帳抽出結果(伝票・明細)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先電子元帳抽出結果(伝票・明細)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/08/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprSalTblRsltWork
    {
        /// <summary>データ区分</summary>
        /// <remarks>0:売上データ 1:入金データ</remarks>
        private Int32 _dataDiv;

        /// <summary>売上日付</summary>
        /// <remarks>売上日付(YYYYMMDD)/入金日付</remarks>
        private DateTime _salesDate;

        /// <summary>売上伝票番号</summary>
        /// <remarks>売上伝票番号/入金伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>売上行番号</summary>
        /// <remarks>売上行番号/入金行番号</remarks>
        private Int32 _salesRowNo;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>販売従業員名称</summary>
        /// <remarks>販売従業員名称/入金担当者名称</remarks>
        private string _salesEmployeeNm = "";

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上伝票合計（税抜き）/入金の場合(入金金額+値引+手数料)</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>商品名称</summary>
        /// <remarks>商品名称/金種名称</remarks>
        private string _goodsName = "";

        /// <summary>商品番号</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>BL商品コード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>BLグループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>出荷数</summary>
        /// <remarks>出荷数</remarks>
        private Double _shipmentCnt;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>定価（税抜き、浮動）または"オープン価格"</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>売上単価（税抜，浮動）</summary>
        /// <remarks>売上単価（税抜，浮動）</remarks>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>原価単価</summary>
        /// <remarks>原価単価</remarks>
        private Double _salesUnitCost;

        /// <summary>売上金額（税抜き）</summary>
        /// <remarks>売上金額（税抜き）/入金金額</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上データ</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>売上金額消費税額</summary>
        /// <remarks>売上明細データ</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>原価金額計</summary>
        /// <remarks>売上データ</remarks>
        private Int64 _totalCost;

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        /// <remarks>類別番号</remarks>
        private Int32 _categoryNo;

        /// <summary>車種全角名称</summary>
        /// <remarks>車種全角名称</remarks>
        private string _modelFullName = "";

        /// <summary>初年度</summary>
        /// <remarks>初年度(YYYYMM)</remarks>
        private DateTime _firstEntryDate;

        /// <summary>車台№</summary>
        /// <remarks>車台番号（検索用）</remarks>
        private Int32 _searchFrameNo;

        /// <summary>型式（フル型）</summary>
        /// <remarks>型式（フル型）</remarks>
        private string _fullModel = "";

        /// <summary>伝票備考</summary>
        /// <remarks>伝票備考/伝票摘要</remarks>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        /// <remarks>伝票備考２</remarks>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        /// <remarks>伝票備考３</remarks>
        private string _slipNote3 = "";

        /// <summary>受付従業員名称</summary>
        /// <remarks>受付従業員名称</remarks>
        private string _frontEmployeeNm = "";

        /// <summary>売上入力者名称</summary>
        /// <remarks>売上入力者名称/入金入力者名称</remarks>
        private string _salesInputName = "";

        /// <summary>得意先コード</summary>
        /// <remarks>得意先コード/得意先コード</remarks>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        /// <remarks>得意先略称</remarks>
        private string _customerSnm = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入先コード</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        /// <remarks>仕入先略称</remarks>
        private string _supplierSnm = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>相手先伝票番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>車両管理コード</summary>
        /// <remarks>車輌管理コード</remarks>
        private string _carMngCode = "";

        /// <summary>受注番号</summary>
        /// <remarks>計上元受注番号</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>計上元出荷№</summary>
        /// <remarks>計上元出荷番号</remarks>
        private string _shipmSalesSlipNum = "";

        /// <summary>元黒№(明細表示)</summary>
        /// <remarks>元黒伝番号</remarks>
        private string _srcSalesSlipNum = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>売上在庫取寄せ区分(0:取寄せ，1:在庫)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>倉庫名称</summary>
        /// <remarks>倉庫名称</remarks>
        private string _warehouseName = "";

        /// <summary>仕入伝票番号</summary>
        /// <remarks>同時仕入伝票番号</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>UOE発注先コード</summary>
        /// <remarks>ＵＯＥ発注データ</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>発注先名(明細表示)</summary>
        /// <remarks>ＵＯＥ発注データ</remarks>
        private string _uOESupplierSnm = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>ＵＯＥリマーク１</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        /// <remarks>ＵＯＥリマーク２</remarks>
        private string _uoeRemark2 = "";

        /// <summary>ガイド名称</summary>
        /// <remarks>ガイド名称</remarks>
        private string _guideName = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>拠点ガイド名称/計上拠点コード</remarks>
        private string _sectionGuideNm = "";

        /// <summary>明細備考</summary>
        /// <remarks>明細備考/</remarks>
        private string _dtlNote = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>カラー名称1</remarks>
        private string _colorName1 = "";

        /// <summary>トリム名称</summary>
        /// <remarks>トリム名称</remarks>
        private string _trimName = "";

        /// <summary>基準単価（定価）</summary>
        /// <remarks>基準単価（定価）</remarks>
        private Double _stdUnPrcLPrice;

        /// <summary>基準単価（売上単価）</summary>
        /// <remarks>基準単価（売上単価）</remarks>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>基準単価（原価単価）</summary>
        /// <remarks>基準単価（原価単価）</remarks>
        private Double _stdUnPrcUnCst;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>メーカー名称</remarks>
        private string _makerName = "";

        /// <summary>原価</summary>
        /// <remarks>売上明細データ</remarks>
        private Int64 _cost;

        /// <summary>得意先伝票番号</summary>
        /// <remarks>得意先伝票番号</remarks>
        private Int32 _custSlipNo;

        /// <summary>計上日付</summary>
        /// <remarks>計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>売掛区分</summary>
        /// <remarks>売掛区分(0:売掛なし,1:売掛)</remarks>
        private Int32 _accRecDivCd;

        /// <summary>赤伝区分</summary>
        /// <remarks>赤伝区分(0:黒伝,1:赤伝,2:元黒)/入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コード</remarks>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _warehouseCode = "";

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>課税区分[明細]</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _stockPartySaleSlipNum = "";

        /// <summary>納品先コード</summary>
        private Int32 _addresseeCode;

        /// <summary>納品先名称</summary>
        private string _addresseeName = "";

        /// <summary>納品先名称2</summary>
        /// <remarks>追加(登録漏れ) 塩原</remarks>
        private string _addresseeName2 = "";

        /// <summary>車台番号</summary>
        private string _frameNo = "";

        /// <summary>受注残数</summary>
        /// <remarks>受注数量＋受注調整数－出荷数</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>手数料入金額</summary>
        private Int64 _feeDeposit;

        /// <summary>値引入金額</summary>
        private Int64 _discountDeposit;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _goodsKindCode;

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _goodsMGroup;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>商品大分類名称</summary>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        private Int32 _modelSubCode;

        /// <summary>エンジン型式名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineModelNm = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _colorCode = "";

        /// <summary>トリムコード</summary>
        private string _trimCode = "";

        /// <summary>納品区分</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>フル型式固定番号配列</summary>
        private Int32[] _fullModelFixedNoAry = new Int32[0];

        /// <summary>装備オブジェクト配列</summary>
        private Byte[] _categoryObjAry = new Byte[0];

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCode = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>履歴区分</summary>
        private Int32 _historyDiv;

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;   // ADD 2009/09/07

        /// <summary>車輌備考</summary>
        private string _carNote = "";   // ADD 2009/09/07

        // ---ADD 2009/09/07 ------>>>>>
        /// public propaty name  :  Mileage
        /// <summary>車両走行距離プロパティ</summary>
        /// <value>車両走行距離</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>車輌備考プロパティ</summary>
        /// <value>車輌備考</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }
        // ---ADD 2009/09/07 -----<<<<<

        /// public propaty name  :  DataDiv
        /// <summary>データ区分プロパティ</summary>
        /// <value>0:売上データ 1:入金データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>売上日付(YYYYMMDD)/入金日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>売上伝票番号/入金伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// <value>売上行番号/入金行番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// <value>販売従業員名称/入金担当者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上伝票合計（税抜き）/入金の場合(入金金額+値引+手数料)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>商品名称/金種名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// <value>BL商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>BLグループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>定価（税抜き、浮動）または"オープン価格"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
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
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// <value>売上単価（税抜，浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>原価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// <value>売上金額（税抜き）/入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>売上金額消費税額プロパティ</summary>
        /// <value>売上明細データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計プロパティ</summary>
        /// <value>売上データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// <value>類別番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>車種全角名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度プロパティ</summary>
        /// <value>初年度(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime FirstEntryDate
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  SearchFrameNo
        /// <summary>車台№プロパティ</summary>
        /// <value>車台番号（検索用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>型式（フル型）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// <value>伝票備考/伝票摘要</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>伝票備考２プロパティ</summary>
        /// <value>伝票備考２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>伝票備考３プロパティ</summary>
        /// <value>伝票備考３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
        /// <value>受付従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>売上入力者名称プロパティ</summary>
        /// <value>売上入力者名称/入金入力者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>得意先コード/得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// <value>得意先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// <value>仕入先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車両管理コードプロパティ</summary>
        /// <value>車輌管理コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// <value>計上元受注番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  ShipmSalesSlipNum
        /// <summary>計上元出荷№プロパティ</summary>
        /// <value>計上元出荷番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上元出荷№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmSalesSlipNum
        {
            get { return _shipmSalesSlipNum; }
            set { _shipmSalesSlipNum = value; }
        }

        /// public propaty name  :  SrcSalesSlipNum
        /// <summary>元黒№(明細表示)プロパティ</summary>
        /// <value>元黒伝番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元黒№(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SrcSalesSlipNum
        {
            get { return _srcSalesSlipNum; }
            set { _srcSalesSlipNum = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>売上在庫取寄せ区分(0:取寄せ，1:在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// <value>倉庫名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>同時仕入伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// <value>ＵＯＥ発注データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierSnm
        /// <summary>発注先名(明細表示)プロパティ</summary>
        /// <value>ＵＯＥ発注データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先名(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierSnm
        {
            get { return _uOESupplierSnm; }
            set { _uOESupplierSnm = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>ＵＯＥリマーク１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// <value>ＵＯＥリマーク２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  GuideName
        /// <summary>ガイド名称プロパティ</summary>
        /// <value>ガイド名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GuideName
        {
            get { return _guideName; }
            set { _guideName = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>拠点ガイド名称/計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// <value>明細備考/</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>カラー名称1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>トリム名称プロパティ</summary>
        /// <value>トリム名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  StdUnPrcLPrice
        /// <summary>基準単価（定価）プロパティ</summary>
        /// <value>基準単価（定価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcLPrice
        {
            get { return _stdUnPrcLPrice; }
            set { _stdUnPrcLPrice = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>基準単価（売上単価）プロパティ</summary>
        /// <value>基準単価（売上単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcUnCst
        /// <summary>基準単価（原価単価）プロパティ</summary>
        /// <value>基準単価（原価単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcUnCst
        {
            get { return _stdUnPrcUnCst; }
            set { _stdUnPrcUnCst = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// <value>メーカー名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// <value>売上明細データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>得意先伝票番号プロパティ</summary>
        /// <value>得意先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>売掛区分(0:売掛なし,1:売掛)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>赤伝区分(0:黒伝,1:赤伝,2:元黒)/入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
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
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分[明細]プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  StockPartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockPartySaleSlipNum
        {
            get { return _stockPartySaleSlipNum; }
            set { _stockPartySaleSlipNum = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>納品先名称2プロパティ</summary>
        /// <value>追加(登録漏れ) 塩原</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>受注残数プロパティ</summary>
        /// <value>受注数量＋受注調整数－出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  FeeDeposit
        /// <summary>手数料入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>値引入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  EngineModelNm
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  ColorCode
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  FullModelFixedNoAry
        /// <summary>フル型式固定番号配列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] FullModelFixedNoAry
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }

        /// public propaty name  :  CategoryObjAry
        /// <summary>装備オブジェクト配列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備オブジェクト配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  HistoryDiv
        /// <summary>履歴区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   履歴区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HistoryDiv
        {
            get { return _historyDiv; }
            set { _historyDiv = value; }
        }


        /// <summary>
        /// 得意先電子元帳抽出結果(伝票・明細)クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustPrtPprSalTblRsltWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
    #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is CustPrtPprSalTblRsltWork || graph is ArrayList || graph is CustPrtPprSalTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( CustPrtPprSalTblRsltWork ).FullName ) );

            if ( graph != null && graph is CustPrtPprSalTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is CustPrtPprSalTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprSalTblRsltWork[])graph).Length;
            }
            else if ( graph is CustPrtPprSalTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //データ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
            //売上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
            //売上伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
            //売上行番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesRowNo
            //受注ステータス
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcptAnOdrStatus
            //売上伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCd
            //販売従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesEmployeeNm
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxExc
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
            //BLグループコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
            //出荷数
            serInfo.MemberInfo.Add( typeof( Double ) ); //ShipmentCnt
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
            //オープン価格区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnPrcTaxExcFl
            //原価単価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnitCost
            //売上金額（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesMoneyTaxExc
            //消費税転嫁方式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConsTaxLayMethod
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxInc
            //売上金額消費税額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPriceConsTax
            //原価金額計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //TotalCost
            //型式指定番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CategoryNo
            //車種全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
            //初年度
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //FirstEntryDate
            //車台№
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SearchFrameNo
            //型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //伝票備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote
            //伝票備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote2
            //伝票備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote3
            //受付従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeNm
            //売上入力者名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputName
            //得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
            //相手先伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
            //車両管理コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CarMngCode
            //受注番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcceptAnOrderNo
            //計上元出荷№
            serInfo.MemberInfo.Add( typeof( string ) ); //ShipmSalesSlipNum
            //元黒№(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //SrcSalesSlipNum
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesOrderDivCd
            //倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //仕入伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
            //UOE発注先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //UOESupplierCd
            //発注先名(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //UOESupplierSnm
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
            //ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GuideName
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
            //明細備考
            serInfo.MemberInfo.Add( typeof( string ) ); //DtlNote
            //カラー名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorName1
            //トリム名称
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimName
            //基準単価（定価）
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcLPrice
            //基準単価（売上単価）
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcSalUnPrc
            //基準単価（原価単価）
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcUnCst
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
            //原価
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //Cost
            //得意先伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustSlipNo
            //計上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpADate
            //売掛区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccRecDivCd
            //赤伝区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //総額表示方法区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalAmountDispWayCd
            //課税区分[明細]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationDivCd
            //相手先伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //StockPartySaleSlipNum
            //納品先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddresseeCode
            //納品先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName
            //納品先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName2
            //車台番号
            serInfo.MemberInfo.Add( typeof( string ) ); //FrameNo
            //受注残数
            serInfo.MemberInfo.Add( typeof( Double ) ); //AcptAnOdrRemainCnt
            //自社分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EnterpriseGanreCode
            //手数料入金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeeDeposit
            //値引入金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountDeposit
            //入力日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
            //商品属性
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsKindCode
            //商品大分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsLGroup
            //商品中分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
            //倉庫棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCdDtl
            //商品大分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsLGroupName
            //商品中分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsMGroupName
            //車両管理番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarMngNo
            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //カラーコード
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorCode
            //トリムコード
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimCode
            //納品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DeliveredGoodsDiv
            //フル型式固定番号配列
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //FullModelFixedNoAry
            //装備オブジェクト配列
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //CategoryObjAry
            //売上入力者コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputCode
            //受付従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeCd
            //履歴区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HistoryDiv
            //車両走行距離   // ADD 2009/09/07
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Mileage
            //車輌備考   // ADD 2009/09/07
            serInfo.MemberInfo.Add( typeof( string ) ); //CarNote

            serInfo.Serialize( writer, serInfo );
            if ( graph is CustPrtPprSalTblRsltWork )
            {
                CustPrtPprSalTblRsltWork temp = (CustPrtPprSalTblRsltWork)graph;

                SetCustPrtPprSalTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is CustPrtPprSalTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (CustPrtPprSalTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( CustPrtPprSalTblRsltWork temp in lst )
                {
                    SetCustPrtPprSalTblRsltWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// CustPrtPprSalTblRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 100;

        /// <summary>
        ///  CustPrtPprSalTblRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustPrtPprSalTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprSalTblRsltWork temp )
        {
            //データ区分
            writer.Write( temp.DataDiv );
            //売上日付
            writer.Write( (Int64)temp.SalesDate.Ticks );
            //売上伝票番号
            writer.Write( temp.SalesSlipNum );
            //売上行番号
            writer.Write( temp.SalesRowNo );
            //受注ステータス
            writer.Write( temp.AcptAnOdrStatus );
            //売上伝票区分
            writer.Write( temp.SalesSlipCd );
            //販売従業員名称
            writer.Write( temp.SalesEmployeeNm );
            //売上伝票合計（税抜き）
            writer.Write( temp.SalesTotalTaxExc );
            //商品名称
            writer.Write( temp.GoodsName );
            //商品番号
            writer.Write( temp.GoodsNo );
            //BL商品コード
            writer.Write( temp.BLGoodsCode );
            //BLグループコード
            writer.Write( temp.BLGroupCode );
            //出荷数
            writer.Write( temp.ShipmentCnt );
            //定価（税抜，浮動）
            writer.Write( temp.ListPriceTaxExcFl );
            //オープン価格区分
            writer.Write( temp.OpenPriceDiv );
            //売上単価（税抜，浮動）
            writer.Write( temp.SalesUnPrcTaxExcFl );
            //原価単価
            writer.Write( temp.SalesUnitCost );
            //売上金額（税抜き）
            writer.Write( temp.SalesMoneyTaxExc );
            //消費税転嫁方式
            writer.Write( temp.ConsTaxLayMethod );
            //売上伝票合計（税込み）
            writer.Write( temp.SalesTotalTaxInc );
            //売上金額消費税額
            writer.Write( temp.SalesPriceConsTax );
            //原価金額計
            writer.Write( temp.TotalCost );
            //型式指定番号
            writer.Write( temp.ModelDesignationNo );
            //類別番号
            writer.Write( temp.CategoryNo );
            //車種全角名称
            writer.Write( temp.ModelFullName );
            //初年度
            writer.Write( (Int64)temp.FirstEntryDate.Ticks );
            //車台№
            writer.Write( temp.SearchFrameNo );
            //型式（フル型）
            writer.Write( temp.FullModel );
            //伝票備考
            writer.Write( temp.SlipNote );
            //伝票備考２
            writer.Write( temp.SlipNote2 );
            //伝票備考３
            writer.Write( temp.SlipNote3 );
            //受付従業員名称
            writer.Write( temp.FrontEmployeeNm );
            //売上入力者名称
            writer.Write( temp.SalesInputName );
            //得意先コード
            writer.Write( temp.CustomerCode );
            //得意先略称
            writer.Write( temp.CustomerSnm );
            //仕入先コード
            writer.Write( temp.SupplierCd );
            //仕入先略称
            writer.Write( temp.SupplierSnm );
            //相手先伝票番号
            writer.Write( temp.PartySaleSlipNum );
            //車両管理コード
            writer.Write( temp.CarMngCode );
            //受注番号
            writer.Write( temp.AcceptAnOrderNo );
            //計上元出荷№
            writer.Write( temp.ShipmSalesSlipNum );
            //元黒№(明細表示)
            writer.Write( temp.SrcSalesSlipNum );
            //売上在庫取寄せ区分
            writer.Write( temp.SalesOrderDivCd );
            //倉庫名称
            writer.Write( temp.WarehouseName );
            //仕入伝票番号
            writer.Write( temp.SupplierSlipNo );
            //UOE発注先コード
            writer.Write( temp.UOESupplierCd );
            //発注先名(明細表示)
            writer.Write( temp.UOESupplierSnm );
            //ＵＯＥリマーク１
            writer.Write( temp.UoeRemark1 );
            //ＵＯＥリマーク２
            writer.Write( temp.UoeRemark2 );
            //ガイド名称
            writer.Write( temp.GuideName );
            //拠点ガイド名称
            writer.Write( temp.SectionGuideNm );
            //明細備考
            writer.Write( temp.DtlNote );
            //カラー名称1
            writer.Write( temp.ColorName1 );
            //トリム名称
            writer.Write( temp.TrimName );
            //基準単価（定価）
            writer.Write( temp.StdUnPrcLPrice );
            //基準単価（売上単価）
            writer.Write( temp.StdUnPrcSalUnPrc );
            //基準単価（原価単価）
            writer.Write( temp.StdUnPrcUnCst );
            //商品メーカーコード
            writer.Write( temp.GoodsMakerCd );
            //メーカー名称
            writer.Write( temp.MakerName );
            //原価
            writer.Write( temp.Cost );
            //得意先伝票番号
            writer.Write( temp.CustSlipNo );
            //計上日付
            writer.Write( (Int64)temp.AddUpADate.Ticks );
            //売掛区分
            writer.Write( temp.AccRecDivCd );
            //赤伝区分
            writer.Write( temp.DebitNoteDiv );
            //拠点コード
            writer.Write( temp.SectionCode );
            //倉庫コード
            writer.Write( temp.WarehouseCode );
            //総額表示方法区分
            writer.Write( temp.TotalAmountDispWayCd );
            //課税区分[明細]
            writer.Write( temp.TaxationDivCd );
            //相手先伝票番号
            writer.Write( temp.StockPartySaleSlipNum );
            //納品先コード
            writer.Write( temp.AddresseeCode );
            //納品先名称
            writer.Write( temp.AddresseeName );
            //納品先名称2
            writer.Write( temp.AddresseeName2 );
            //車台番号
            writer.Write( temp.FrameNo );
            //受注残数
            writer.Write( temp.AcptAnOdrRemainCnt );
            //自社分類コード
            writer.Write( temp.EnterpriseGanreCode );
            //手数料入金額
            writer.Write( temp.FeeDeposit );
            //値引入金額
            writer.Write( temp.DiscountDeposit );
            //入力日
            writer.Write( (Int64)temp.InputDay.Ticks );
            //商品属性
            writer.Write( temp.GoodsKindCode );
            //商品大分類コード
            writer.Write( temp.GoodsLGroup );
            //商品中分類コード
            writer.Write( temp.GoodsMGroup );
            //倉庫棚番
            writer.Write( temp.WarehouseShelfNo );
            //売上伝票区分（明細）
            writer.Write( temp.SalesSlipCdDtl );
            //商品大分類名称
            writer.Write( temp.GoodsLGroupName );
            //商品中分類名称
            writer.Write( temp.GoodsMGroupName );
            //車両管理番号
            writer.Write( temp.CarMngNo );
            //メーカーコード
            writer.Write( temp.MakerCode );
            //車種コード
            writer.Write( temp.ModelCode );
            //車種サブコード
            writer.Write( temp.ModelSubCode );
            //エンジン型式名称
            writer.Write( temp.EngineModelNm );
            //カラーコード
            writer.Write( temp.ColorCode );
            //トリムコード
            writer.Write( temp.TrimCode );
            //納品区分
            writer.Write( temp.DeliveredGoodsDiv );
            //フル型式固定番号配列
            if ( temp.FullModelFixedNoAry == null ) temp.FullModelFixedNoAry = new int[0];
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write( length );
            for ( int cnt = 0; cnt < length; cnt++ )
                writer.Write( temp.FullModelFixedNoAry[cnt] );
            //装備オブジェクト配列
            if ( temp.CategoryObjAry == null ) temp.CategoryObjAry = new byte[0];
            writer.Write( temp.CategoryObjAry.Length );
            writer.Write( temp.CategoryObjAry );
            //売上入力者コード
            writer.Write( temp.SalesInputCode );
            //受付従業員コード
            writer.Write( temp.FrontEmployeeCd );
            //履歴区分
            writer.Write( temp.HistoryDiv );
            //車両走行距離　// ADD 2009/09/07
            writer.Write( temp.Mileage );
            //車輌備考   // ADD 2009/09/07
            writer.Write( temp.CarNote );


        }

        /// <summary>
        ///  CustPrtPprSalTblRsltWorkインスタンス取得
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CustPrtPprSalTblRsltWork GetCustPrtPprSalTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0なので不要ですが、V5.1.0.1以降では
		// serInfo.MemberInfo.Count < currentMemberCount
		// のケースについての配慮が必要になります。

		CustPrtPprSalTblRsltWork temp = new CustPrtPprSalTblRsltWork();

		//データ区分
		temp.DataDiv = reader.ReadInt32();
		//売上日付
		temp.SalesDate = new DateTime(reader.ReadInt64());
		//売上伝票番号
		temp.SalesSlipNum = reader.ReadString();
		//売上行番号
		temp.SalesRowNo = reader.ReadInt32();
		//受注ステータス
		temp.AcptAnOdrStatus = reader.ReadInt32();
		//売上伝票区分
		temp.SalesSlipCd = reader.ReadInt32();
		//販売従業員名称
		temp.SalesEmployeeNm = reader.ReadString();
		//売上伝票合計（税抜き）
		temp.SalesTotalTaxExc = reader.ReadInt64();
		//商品名称
		temp.GoodsName = reader.ReadString();
		//商品番号
		temp.GoodsNo = reader.ReadString();
		//BL商品コード
		temp.BLGoodsCode = reader.ReadInt32();
		//BLグループコード
		temp.BLGroupCode = reader.ReadInt32();
		//出荷数
		temp.ShipmentCnt = reader.ReadDouble();
		//定価（税抜，浮動）
		temp.ListPriceTaxExcFl = reader.ReadDouble();
		//オープン価格区分
		temp.OpenPriceDiv = reader.ReadInt32();
		//売上単価（税抜，浮動）
		temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
		//原価単価
		temp.SalesUnitCost = reader.ReadDouble();
		//売上金額（税抜き）
		temp.SalesMoneyTaxExc = reader.ReadInt64();
		//消費税転嫁方式
		temp.ConsTaxLayMethod = reader.ReadInt32();
		//売上伝票合計（税込み）
		temp.SalesTotalTaxInc = reader.ReadInt64();
		//売上金額消費税額
		temp.SalesPriceConsTax = reader.ReadInt64();
		//原価金額計
		temp.TotalCost = reader.ReadInt64();
		//型式指定番号
		temp.ModelDesignationNo = reader.ReadInt32();
		//類別番号
		temp.CategoryNo = reader.ReadInt32();
		//車種全角名称
		temp.ModelFullName = reader.ReadString();
		//初年度
		temp.FirstEntryDate = new DateTime(reader.ReadInt64());
		//車台№
		temp.SearchFrameNo = reader.ReadInt32();
		//型式（フル型）
		temp.FullModel = reader.ReadString();
		//伝票備考
		temp.SlipNote = reader.ReadString();
		//伝票備考２
		temp.SlipNote2 = reader.ReadString();
		//伝票備考３
		temp.SlipNote3 = reader.ReadString();
		//受付従業員名称
		temp.FrontEmployeeNm = reader.ReadString();
		//売上入力者名称
		temp.SalesInputName = reader.ReadString();
		//得意先コード
		temp.CustomerCode = reader.ReadInt32();
		//得意先略称
		temp.CustomerSnm = reader.ReadString();
		//仕入先コード
		temp.SupplierCd = reader.ReadInt32();
		//仕入先略称
		temp.SupplierSnm = reader.ReadString();
		//相手先伝票番号
		temp.PartySaleSlipNum = reader.ReadString();
		//車両管理コード
		temp.CarMngCode = reader.ReadString();
		//受注番号
		temp.AcceptAnOrderNo = reader.ReadInt32();
		//計上元出荷№
		temp.ShipmSalesSlipNum = reader.ReadString();
		//元黒№(明細表示)
		temp.SrcSalesSlipNum = reader.ReadString();
		//売上在庫取寄せ区分
		temp.SalesOrderDivCd = reader.ReadInt32();
		//倉庫名称
		temp.WarehouseName = reader.ReadString();
		//仕入伝票番号
		temp.SupplierSlipNo = reader.ReadInt32();
		//UOE発注先コード
		temp.UOESupplierCd = reader.ReadInt32();
		//発注先名(明細表示)
		temp.UOESupplierSnm = reader.ReadString();
		//ＵＯＥリマーク１
		temp.UoeRemark1 = reader.ReadString();
		//ＵＯＥリマーク２
		temp.UoeRemark2 = reader.ReadString();
		//ガイド名称
		temp.GuideName = reader.ReadString();
		//拠点ガイド名称
		temp.SectionGuideNm = reader.ReadString();
		//明細備考
		temp.DtlNote = reader.ReadString();
		//カラー名称1
		temp.ColorName1 = reader.ReadString();
		//トリム名称
		temp.TrimName = reader.ReadString();
		//基準単価（定価）
		temp.StdUnPrcLPrice = reader.ReadDouble();
		//基準単価（売上単価）
		temp.StdUnPrcSalUnPrc = reader.ReadDouble();
		//基準単価（原価単価）
		temp.StdUnPrcUnCst = reader.ReadDouble();
		//商品メーカーコード
		temp.GoodsMakerCd = reader.ReadInt32();
		//メーカー名称
		temp.MakerName = reader.ReadString();
		//原価
		temp.Cost = reader.ReadInt64();
		//得意先伝票番号
		temp.CustSlipNo = reader.ReadInt32();
		//計上日付
		temp.AddUpADate = new DateTime(reader.ReadInt64());
		//売掛区分
		temp.AccRecDivCd = reader.ReadInt32();
		//赤伝区分
		temp.DebitNoteDiv = reader.ReadInt32();
		//拠点コード
		temp.SectionCode = reader.ReadString();
		//倉庫コード
		temp.WarehouseCode = reader.ReadString();
		//総額表示方法区分
		temp.TotalAmountDispWayCd = reader.ReadInt32();
		//課税区分[明細]
		temp.TaxationDivCd = reader.ReadInt32();
		//相手先伝票番号
		temp.StockPartySaleSlipNum = reader.ReadString();
		//納品先コード
		temp.AddresseeCode = reader.ReadInt32();
		//納品先名称
		temp.AddresseeName = reader.ReadString();
		//納品先名称2
		temp.AddresseeName2 = reader.ReadString();
		//車台番号
		temp.FrameNo = reader.ReadString();
		//受注残数
		temp.AcptAnOdrRemainCnt = reader.ReadDouble();
		//自社分類コード
		temp.EnterpriseGanreCode = reader.ReadInt32();
		//手数料入金額
		temp.FeeDeposit = reader.ReadInt64();
		//値引入金額
		temp.DiscountDeposit = reader.ReadInt64();
		//入力日
		temp.InputDay = new DateTime(reader.ReadInt64());
		//商品属性
		temp.GoodsKindCode = reader.ReadInt32();
		//商品大分類コード
		temp.GoodsLGroup = reader.ReadInt32();
		//商品中分類コード
		temp.GoodsMGroup = reader.ReadInt32();
		//倉庫棚番
		temp.WarehouseShelfNo = reader.ReadString();
		//売上伝票区分（明細）
		temp.SalesSlipCdDtl = reader.ReadInt32();
		//商品大分類名称
		temp.GoodsLGroupName = reader.ReadString();
		//商品中分類名称
		temp.GoodsMGroupName = reader.ReadString();
		//車両管理番号
		temp.CarMngNo = reader.ReadInt32();
		//メーカーコード
		temp.MakerCode = reader.ReadInt32();
		//車種コード
		temp.ModelCode = reader.ReadInt32();
		//車種サブコード
		temp.ModelSubCode = reader.ReadInt32();
		//エンジン型式名称
		temp.EngineModelNm = reader.ReadString();
		//カラーコード
		temp.ColorCode = reader.ReadString();
		//トリムコード
		temp.TrimCode = reader.ReadString();
		//納品区分
		temp.DeliveredGoodsDiv = reader.ReadInt32();
        //フル型式固定番号配列
        int length = reader.ReadInt32();
        temp.FullModelFixedNoAry = new int[length];
        for ( int cnt = 0; cnt < length; cnt++ )
            temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();
        //装備オブジェクト配列
        length = reader.ReadInt32();
        temp.CategoryObjAry = reader.ReadBytes( length );
        //売上入力者コード
		temp.SalesInputCode = reader.ReadString();
		//受付従業員コード
		temp.FrontEmployeeCd = reader.ReadString();
		//履歴区分
		temp.HistoryDiv = reader.ReadInt32();
        //車両走行距離   // ADD 2009/09/07
        temp.Mileage = reader.ReadInt32();
        //車輌備考   // ADD 2009/09/07
        temp.CarNote = reader.ReadString();

			
		//以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
		//データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
		//型情報にしたがって、ストリームから情報を読み出します...といっても
		//読み出して捨てることになります。
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]をデシリアライズする直前に、そのlengthが
			//デシリアライズされているケースがある、byte[],char[]の
			//デシリアライズにはlengthが必要なのでint型のデータをデ
			//シリアライズした場合は、この値をこの変数に退避します。
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
			{
				Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				object userData = formatter.Deserialize( reader );  //読み飛ばし
			}
		}
		return temp;
	}

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                CustPrtPprSalTblRsltWork temp = GetCustPrtPprSalTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustPrtPprSalTblRsltWork[])lst.ToArray( typeof( CustPrtPprSalTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
# endif

    /// public class name:   CustPrtPprSalTblRsltWork
    /// <summary>
    ///                      得意先電子元帳抽出結果(伝票・明細)クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先電子元帳抽出結果(伝票・明細)クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/10/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/01/12 呉元嘯</br>
    /// <br>                     年のみ入力した年式の伝票を売上伝票入力で正常に見出貼付できるように変更する。</br>
    /// <br>Update Note      :   2010/01/29 楊明俊 4次改良</br>
    /// <br>                     赤伝発行時に、返品数の上限を制限が可能となるように、返品不可設定機能の追加を行う。</br>
    /// <br></br>
    /// <br>Update Note      :   2010/04/02 22018 鈴木 正臣 【MANTIS:0015241】見出貼付の修正</br>
    /// <br></br>
    /// <br>Update Note      :   2010/04/15 30517 夏野 駿希 【MANTIS:0015323】伝票区分に入金が含まれるとエラーとなる件の修正</br>
    /// <br>Update Note      :   2010/04/27 gaoyh 受注マスタ（車両）に自由検索型式固定番号配列の追加</br>
    /// <br>Update Note      :   2010/08/05 呉元嘯 変更前定価の追加</br>
    /// <br>Update Note      :   2010/12/20 楊明俊 計上元受注№・計上元貸出№の表示内容修正</br>
    /// <br>Update Note      :   2011/07/18 zhubj 回答区分追加対応</br>
    /// <br>Update Note      :   2011/11/28 楊洋 redmine#8172の追加対応</br>
    /// <br>Update Note      :   2014/12/28 陳永康 変換後品番の追加対応</br>
    /// <br>Update Note      :   K2015/06/16 鮑晶</br>
    /// <br>管理番号         :   11101427-00</br>
    /// <br>                 :   メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprSalTblRsltWork
    {
        /// <summary>データ区分</summary>
        /// <remarks>0:売上データ 1:入金データ</remarks>
        private Int32 _dataDiv;

        /// <summary>売上日付</summary>
        /// <remarks>売上日付(YYYYMMDD)/入金日付</remarks>
        private DateTime _salesDate;

        /// <summary>売上伝票番号</summary>
        /// <remarks>売上伝票番号/入金伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>売上行番号</summary>
        /// <remarks>売上行番号/入金行番号</remarks>
        private Int32 _salesRowNo;

        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上伝票区分</summary>
        /// <remarks>0:売上,1:返品</remarks>
        private Int32 _salesSlipCd;

        /// <summary>販売従業員名称</summary>
        /// <remarks>販売従業員名称/入金担当者名称</remarks>
        private string _salesEmployeeNm = "";

        /// <summary>売上伝票合計（税抜き）</summary>
        /// <remarks>売上伝票合計（税抜き）/入金の場合(入金金額+値引+手数料)</remarks>
        private Int64 _salesTotalTaxExc;

        /// <summary>商品名称</summary>
        /// <remarks>商品名称/金種名称</remarks>
        private string _goodsName = "";

        /// <summary>商品番号</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        // --- ADD 陳永康 2014/12/28 変換後品番の追加対応----->>>>>
        /// <summary>変換後品番</summary>
        /// <remarks>変換後品番</remarks>
        private string _changeGoodsNo = "";
        // --- ADD 陳永康 2014/12/28 変換後品番の追加対応-----<<<<<

        /// <summary>BL商品コード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>BLグループコード</summary>
        /// <remarks>BLグループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>出荷数</summary>
        /// <remarks>出荷数</remarks>
        private Double _shipmentCnt;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>定価（税抜き、浮動）または"オープン価格"</remarks>
        private Double _listPriceTaxExcFl;

        // ----------- ADD 連番729 2011/08/18 -------------------->>>>>
        /// <summary>原価率</summary>
        /// <remarks>原価率</remarks>
        private Double _costRate;

        /// <summary>売価率</summary>
        /// <remarks>売価率</remarks>
        private Double _salesRate;
        // ----------- ADD 連番729 2011/08/18 --------------------<<<<<

        // ADD 時シン 2020/03/11 PMKOBETSU-2912 -------->>>>>
        /// <summary>消費税税率</summary>
        /// <remarks>消費税税率</remarks>
        private Double _consTaxRate;
        // ADD 時シン 2020/03/11 PMKOBETSU-2912 --------<<<<<

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>売上単価（税抜，浮動）</summary>
        /// <remarks>売上単価（税抜，浮動）</remarks>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>原価単価</summary>
        /// <remarks>原価単価</remarks>
        private Double _salesUnitCost;

        /// <summary>売上金額（税抜き）</summary>
        /// <remarks>売上金額（税抜き）/入金金額</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>売上伝票合計（税込み）</summary>
        /// <remarks>売上データ</remarks>
        private Int64 _salesTotalTaxInc;

        /// <summary>売上金額消費税額</summary>
        /// <remarks>売上明細データ</remarks>
        private Int64 _salesPriceConsTax;

        /// <summary>原価金額計</summary>
        /// <remarks>売上データ</remarks>
        private Int64 _totalCost;

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        /// <remarks>類別番号</remarks>
        private Int32 _categoryNo;

        /// <summary>車種全角名称</summary>
        /// <remarks>車種全角名称</remarks>
        private string _modelFullName = "";

        /// <summary>初年度</summary>
        /// <remarks>初年度(YYYYMM)</remarks>
        //private DateTime _firstEntryDate;// DEL 20010/01/12
        private Int32 _firstEntryDate;// ADD 20010/01/12

        /// <summary>車台№</summary>
        /// <remarks>車台番号（検索用）</remarks>
        private Int32 _searchFrameNo;

        /// <summary>型式（フル型）</summary>
        /// <remarks>型式（フル型）</remarks>
        private string _fullModel = "";

        /// <summary>伝票備考</summary>
        /// <remarks>伝票備考/伝票摘要</remarks>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        /// <remarks>伝票備考２</remarks>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        /// <remarks>伝票備考３</remarks>
        private string _slipNote3 = "";

        /// <summary>受付従業員名称</summary>
        /// <remarks>受付従業員名称</remarks>
        private string _frontEmployeeNm = "";

        /// <summary>売上入力者名称</summary>
        /// <remarks>売上入力者名称/入金入力者名称</remarks>
        private string _salesInputName = "";

        /// <summary>得意先コード</summary>
        /// <remarks>得意先コード/得意先コード</remarks>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        /// <remarks>得意先略称</remarks>
        private string _customerSnm = "";

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入先コード</remarks>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        /// <remarks>仕入先略称</remarks>
        private string _supplierSnm = "";

        /// <summary>相手先伝票番号</summary>
        /// <remarks>相手先伝票番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>車両管理コード</summary>
        /// <remarks>車輌管理コード</remarks>
        private string _carMngCode = "";

        /// <summary>受注番号</summary>
        /// <remarks>計上元受注番号</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>計上元出荷№</summary>
        /// <remarks>計上元出荷番号</remarks>
        private string _shipmSalesSlipNum = "";

        /// <summary>元黒№(明細表示)</summary>
        /// <remarks>元黒伝番号</remarks>
        private string _srcSalesSlipNum = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>売上在庫取寄せ区分(0:取寄せ，1:在庫)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>倉庫名称</summary>
        /// <remarks>倉庫名称</remarks>
        private string _warehouseName = "";

        /// <summary>仕入伝票番号</summary>
        /// <remarks>同時仕入伝票番号</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>UOE発注先コード</summary>
        /// <remarks>ＵＯＥ発注データ</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>発注先名(明細表示)</summary>
        /// <remarks>ＵＯＥ発注データ</remarks>
        private string _uOESupplierSnm = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>ＵＯＥリマーク１</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        /// <remarks>ＵＯＥリマーク２</remarks>
        private string _uoeRemark2 = "";

        /// <summary>ガイド名称</summary>
        /// <remarks>ガイド名称</remarks>
        private string _guideName = "";

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>拠点ガイド名称/計上拠点コード</remarks>
        private string _sectionGuideNm = "";

        /// <summary>明細備考</summary>
        /// <remarks>明細備考/</remarks>
        private string _dtlNote = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>カラー名称1</remarks>
        private string _colorName1 = "";

        /// <summary>トリム名称</summary>
        /// <remarks>トリム名称</remarks>
        private string _trimName = "";

        /// <summary>基準単価（定価）</summary>
        /// <remarks>基準単価（定価）</remarks>
        private Double _stdUnPrcLPrice;

        /// <summary>基準単価（売上単価）</summary>
        /// <remarks>基準単価（売上単価）</remarks>
        private Double _stdUnPrcSalUnPrc;

        /// <summary>基準単価（原価単価）</summary>
        /// <remarks>基準単価（原価単価）</remarks>
        private Double _stdUnPrcUnCst;

        // -------------ADD 2009/12/28-------------->>>>>
        /// <summary>変更前単価</summary>
        /// <remarks>変更前単価</remarks>
        private Double _bfSalesUnitPrice;

        /// <summary>変更前原価</summary>
        /// <remarks>変更前原価</remarks>
        private Double _bfUnitCost;
        // -------------ADD 2009/12/28--------------<<<<<

        // -------------ADD 2010/08/05-------------->>>>>
        /// <summary>変更前定価</summary>
        /// <remarks>変更前定価</remarks>
        private Double _bfListPrice;
        // -------------ADD 2010/08/05--------------<<<<<

        // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;
        // ---------------------- ADD END   2011.02.09 zhubj -----------------<<<<<

        //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;
        //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<
        
        /// <summary>商品メーカーコード</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        /// <remarks>メーカー名称</remarks>
        private string _makerName = "";

        /// <summary>原価</summary>
        /// <remarks>売上明細データ</remarks>
        private Int64 _cost;

        /// <summary>得意先伝票番号</summary>
        /// <remarks>得意先伝票番号</remarks>
        private Int32 _custSlipNo;

        /// <summary>計上日付</summary>
        /// <remarks>計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</remarks>
        private DateTime _addUpADate;

        /// <summary>売掛区分</summary>
        /// <remarks>売掛区分(0:売掛なし,1:売掛)</remarks>
        private Int32 _accRecDivCd;

        /// <summary>赤伝区分</summary>
        /// <remarks>赤伝区分(0:黒伝,1:赤伝,2:元黒)/入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>拠点コード</summary>
        /// <remarks>拠点コード</remarks>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _warehouseCode = "";

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>課税区分[明細]</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>相手先伝票番号</summary>
        /// <remarks>仕入先伝票番号に使用する</remarks>
        private string _stockPartySaleSlipNum = "";

        /// <summary>納品先コード</summary>
        private Int32 _addresseeCode;

        /// <summary>納品先名称</summary>
        private string _addresseeName = "";

        /// <summary>納品先名称2</summary>
        /// <remarks>追加(登録漏れ) 塩原</remarks>
        private string _addresseeName2 = "";

        /// <summary>車台番号</summary>
        private string _frameNo = "";

        /// <summary>受注残数</summary>
        /// <remarks>受注数量＋受注調整数－出荷数</remarks>
        private Double _acptAnOdrRemainCnt;

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>手数料入金額</summary>
        private Int64 _feeDeposit;

        /// <summary>値引入金額</summary>
        private Int64 _discountDeposit;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _goodsKindCode;

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _goodsMGroup;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>商品大分類名称</summary>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _carMngNo;

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        private Int32 _modelSubCode;

        /// <summary>エンジン型式名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineModelNm = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _colorCode = "";

        /// <summary>トリムコード</summary>
        private string _trimCode = "";

        /// <summary>納品区分</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>フル型式固定番号配列</summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        private Int32[] _fullModelFixedNoAry;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD

        /// <summary>装備オブジェクト配列</summary>
        private Byte[] _categoryObjAry;

        /// <summary>売上入力者コード</summary>
        /// <remarks>入力担当者（発行者）</remarks>
        private string _salesInputCode = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付担当者（受注者）</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>履歴区分</summary>
        private Int32 _historyDiv;

        /// <summary>車両走行距離</summary>
        private Int32 _mileage;

        /// <summary>車輌備考</summary>
        private string _carNote = "";
        // -------------ADD 2010/01/29 ---------->>>>>
        /// <summary>返品上限数</summary>
        private Double _retuppercnt;

        /// <summary>返品上限数存在フラグ</summary>
        private Int32 _retuppercntDiv;
        // -------------ADD 2010/01/29 ----------<<<<<
        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        private Int64 _updateDateTime;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        // ADD 2012/04/01 gezh Redmine#29250 --------->>>>>
        /// <summary>更新日時(明細)</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _updateDateTimeDetail;
        // ADD 2012/04/01 gezh Redmine#29250 ---------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// <summary>車種半角名称</summary>
        // 2010/04/15 >>>
        //private string _modelHalfName;
        private string _modelHalfName = "";
        // 2010/04/15 <<<
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// <summary>自由検索型式固定番号配列</summary>
        /// <remarks>自由検索シリアル№の配列クラスを格納（再検索不要になる）</remarks>
        private Byte[] _freeSrchMdlFxdNoAry;
        // --- ADD 2010/04/27 ----------<<<<<

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>売上伝票番号</summary>
        private string _hisDtlSlipNum = "";

        /// <summary>受注ステータス（元）</summary>
        private Int32 _acptAnOdrStatusSrc;
        // --- ADD 2010/12/20 ----------<<<<<

        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
        /// <summary>販売エリアコード</summary>
        private string _salesAreaName = "";

        /// <summary>得意先分析コード1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード6</summary>
        private Int32 _custAnalysCode6;

        /// public propaty name  :  SalesAreaCode
        /// <summary>地区番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }
        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
             
        // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>0:通常(PCC連携なし)、1:手動回答、2:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }
        // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

        //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
        /// public propaty name  :  St_InquiryNumber
        /// <summary>問合せ番号プロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   楊洋</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }
        //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

        /// public propaty name  :  DataDiv
        /// <summary>データ区分プロパティ</summary>
        /// <value>0:売上データ 1:入金データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataDiv
        {
            get { return _dataDiv; }
            set { _dataDiv = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>売上日付(YYYYMMDD)/入金日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>売上伝票番号/入金伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// <value>売上行番号/入金行番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>0:売上,1:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// <value>販売従業員名称/入金担当者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計（税抜き）プロパティ</summary>
        /// <value>売上伝票合計（税抜き）/入金の場合(入金金額+値引+手数料)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>商品名称/金種名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        // --- ADD 陳永康 2014/12/28 変換後品番の追加対応----->>>>>
        /// public propaty name  :  ChangeGoodsNo
        /// <summary>変換後品番プロパティ</summary>
        /// <value>変換後品番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChangeGoodsNo
        {
            get { return _changeGoodsNo; }
            set { _changeGoodsNo = value; }
        }
        // --- ADD 陳永康 2014/12/28 変換後品番の追加対応-----<<<<<

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// <value>BL商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>BLグループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// <value>出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>定価（税抜き、浮動）または"オープン価格"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        // ----------- ADD 連番729 2011/08/18 -------------------->>>>>
        /// public propaty name  :  CostRate
        /// <summary>原価率プロパティ</summary>
        /// <value>原価率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CostRate
        {
            get { return _costRate; }
            set { _costRate = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>売価率プロパティ</summary>
        /// <value>売価率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }
        // ----------- ADD 連番729 2011/08/18 --------------------<<<<<


        // ADD 時シン 2020/03/11 PMKOBETSU-2912 -------->>>>>
        /// public propaty name  :  ConsTaxRate
        /// <summary>消費税税率プロパティ</summary>
        /// <value>消費税税率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税税率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }
        // ADD 時シン 2020/03/11 PMKOBETSU-2912 --------<<<<<

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
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// <value>売上単価（税抜，浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>原価単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// <value>売上金額（税抜き）/入金金額</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>売上伝票合計（税込み）プロパティ</summary>
        /// <value>売上データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesPriceConsTax
        /// <summary>売上金額消費税額プロパティ</summary>
        /// <value>売上明細データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額消費税額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesPriceConsTax
        {
            get { return _salesPriceConsTax; }
            set { _salesPriceConsTax = value; }
        }

        /// public propaty name  :  TotalCost
        /// <summary>原価金額計プロパティ</summary>
        /// <value>売上データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// <value>類別番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>車種全角名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FirstEntryDate
        /// <summary>初年度プロパティ</summary>
        /// <value>初年度(YYYYMM)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public DateTime FirstEntryDate // DEL 2010/01/12
        public Int32 FirstEntryDate // ADD 2010/01/12
        {
            get { return _firstEntryDate; }
            set { _firstEntryDate = value; }
        }

        /// public propaty name  :  SearchFrameNo
        /// <summary>車台№プロパティ</summary>
        /// <value>車台番号（検索用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>型式（フル型）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// <value>伝票備考/伝票摘要</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>伝票備考２プロパティ</summary>
        /// <value>伝票備考２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>伝票備考３プロパティ</summary>
        /// <value>伝票備考３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
        /// <value>受付従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>売上入力者名称プロパティ</summary>
        /// <value>売上入力者名称/入金入力者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>得意先コード/得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// <value>得意先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// <value>仕入先略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車両管理コードプロパティ</summary>
        /// <value>車輌管理コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// <value>計上元受注番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  ShipmSalesSlipNum
        /// <summary>計上元出荷№プロパティ</summary>
        /// <value>計上元出荷番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上元出荷№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmSalesSlipNum
        {
            get { return _shipmSalesSlipNum; }
            set { _shipmSalesSlipNum = value; }
        }

        /// public propaty name  :  SrcSalesSlipNum
        /// <summary>元黒№(明細表示)プロパティ</summary>
        /// <value>元黒伝番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元黒№(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SrcSalesSlipNum
        {
            get { return _srcSalesSlipNum; }
            set { _srcSalesSlipNum = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>売上在庫取寄せ区分(0:取寄せ，1:在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// <value>倉庫名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>同時仕入伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// <value>ＵＯＥ発注データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierSnm
        /// <summary>発注先名(明細表示)プロパティ</summary>
        /// <value>ＵＯＥ発注データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先名(明細表示)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierSnm
        {
            get { return _uOESupplierSnm; }
            set { _uOESupplierSnm = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>ＵＯＥリマーク１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// <value>ＵＯＥリマーク２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  GuideName
        /// <summary>ガイド名称プロパティ</summary>
        /// <value>ガイド名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GuideName
        {
            get { return _guideName; }
            set { _guideName = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>拠点ガイド名称/計上拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// <value>明細備考/</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>カラー名称1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>トリム名称プロパティ</summary>
        /// <value>トリム名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  StdUnPrcLPrice
        /// <summary>基準単価（定価）プロパティ</summary>
        /// <value>基準単価（定価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（定価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcLPrice
        {
            get { return _stdUnPrcLPrice; }
            set { _stdUnPrcLPrice = value; }
        }

        /// public propaty name  :  StdUnPrcSalUnPrc
        /// <summary>基準単価（売上単価）プロパティ</summary>
        /// <value>基準単価（売上単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（売上単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcSalUnPrc
        {
            get { return _stdUnPrcSalUnPrc; }
            set { _stdUnPrcSalUnPrc = value; }
        }

        /// public propaty name  :  StdUnPrcUnCst
        /// <summary>基準単価（原価単価）プロパティ</summary>
        /// <value>基準単価（原価単価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   基準単価（原価単価）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StdUnPrcUnCst
        {
            get { return _stdUnPrcUnCst; }
            set { _stdUnPrcUnCst = value; }
        }

        // -------------ADD 2009/12/28-------------->>>>>
        /// public propaty name  :  BfSalesUnitPrice
        /// <summary>変更前単価プロパティ</summary>
        /// <value>変更前単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfSalesUnitPrice
        {
            get { return _bfSalesUnitPrice; }
            set { _bfSalesUnitPrice = value; }
        }

        /// public propaty name  :  BfUnitCost
        /// <summary>変更前原価プロパティ</summary>
        /// <value>変更前原価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfUnitCost
        {
            get { return _bfUnitCost; }
            set { _bfUnitCost = value; }
        }
        // -------------ADD 2009/12/28--------------<<<<<

        // -------------ADD 2010/08/05-------------->>>>>
        /// public propaty name  :  BfListPrice
        /// <summary>変更前定価プロパティ</summary>
        /// <value>変更前定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfListPrice
        {
            get { return _bfListPrice; }
            set { _bfListPrice = value; }
        }
        // -------------ADD 2010/08/05--------------<<<<<

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// <value>メーカー名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>原価プロパティ</summary>
        /// <value>売上明細データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  CustSlipNo
        /// <summary>得意先伝票番号プロパティ</summary>
        /// <value>得意先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipNo
        {
            get { return _custSlipNo; }
            set { _custSlipNo = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>計上日付プロパティ</summary>
        /// <value>計上日付(YYYYMMDD)/計上日付(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>売掛区分(0:売掛なし,1:売掛)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  DebitNoteDiv
        /// <summary>赤伝区分プロパティ</summary>
        /// <value>赤伝区分(0:黒伝,1:赤伝,2:元黒)/入金赤黒区分(0:黒,1:赤,2:相殺済み黒)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   赤伝区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
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
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分[明細]プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  StockPartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>仕入先伝票番号に使用する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockPartySaleSlipNum
        {
            get { return _stockPartySaleSlipNum; }
            set { _stockPartySaleSlipNum = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  AddresseeName
        /// <summary>納品先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName
        {
            get { return _addresseeName; }
            set { _addresseeName = value; }
        }

        /// public propaty name  :  AddresseeName2
        /// <summary>納品先名称2プロパティ</summary>
        /// <value>追加(登録漏れ) 塩原</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddresseeName2
        {
            get { return _addresseeName2; }
            set { _addresseeName2 = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  AcptAnOdrRemainCnt
        /// <summary>受注残数プロパティ</summary>
        /// <value>受注数量＋受注調整数－出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcptAnOdrRemainCnt
        {
            get { return _acptAnOdrRemainCnt; }
            set { _acptAnOdrRemainCnt = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  FeeDeposit
        /// <summary>手数料入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手数料入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>値引入金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引入金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  CarMngNo
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngNo
        {
            get { return _carMngNo; }
            set { _carMngNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  EngineModelNm
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  ColorCode
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        /// public propaty name  :  TrimCode
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimCode
        {
            get { return _trimCode; }
            set { _trimCode = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  FullModelFixedNoAry
        /// <summary>フル型式固定番号配列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フル型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        public Int32[] FullModelFixedNoAry
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        {
            get { return _fullModelFixedNoAry; }
            set { _fullModelFixedNoAry = value; }
        }

        /// public propaty name  :  CategoryObjAry
        /// <summary>装備オブジェクト配列プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備オブジェクト配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] CategoryObjAry
        {
            get { return _categoryObjAry; }
            set { _categoryObjAry = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>入力担当者（発行者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付担当者（受注者）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  HistoryDiv
        /// <summary>履歴区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   履歴区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HistoryDiv
        {
            get { return _historyDiv; }
            set { _historyDiv = value; }
        }

        /// public propaty name  :  Mileage
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }

        /// public propaty name  :  CarNote
        /// <summary>車輌備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarNote
        {
            get { return _carNote; }
            set { _carNote = value; }
        }
        // -------------ADD 2010/01/29 ---------->>>>>
        /// public propaty name  :  Retuppercnt
        /// <summary>返品上限数</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品上限数</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Retuppercnt
        {
            get { return _retuppercnt; }
            set { _retuppercnt = value; }
        }

        /// public propaty name  :  RetuppercntDiv
        /// <summary>返品上限数存在フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品上限数存在フラグ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetuppercntDiv
        {
            get { return _retuppercntDiv; }
            set { _retuppercntDiv = value; }
        }
        // -------------ADD 2010/01/29 ----------<<<<<
        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        public Int64 UpdateDateTime
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }
        // ADD 2012/04/01 gezh Redmine#29250 --------->>>>>
        public Int64 UpdateDateTimeDetail
        {
            get { return _updateDateTimeDetail; }
            set { _updateDateTimeDetail = value; }
        }
        // ADD 2012/04/01 gezh Redmine#29250 ---------<<<<<
        // --- ADD m.suzuki 2010/04/02 ---------->>>>>
        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }
        // --- ADD m.suzuki 2010/04/02 ----------<<<<<

        // --- ADD 2010/04/27 ---------->>>>>
        /// public propaty name  :  FreeSrchMdlFxdNoAry
        /// <summary>自由検索型式固定番号配列プロパティ</summary>
        /// <value>自由検索シリアル№の配列クラスを格納（再検索不要になる）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索型式固定番号配列プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] FreeSrchMdlFxdNoAry
        {
            get { return _freeSrchMdlFxdNoAry; }
            set { _freeSrchMdlFxdNoAry = value; }
        }
        // --- ADD 2010/04/27 ----------<<<<

        // --- ADD 2010/12/20 ---------->>>>>
        /// public propaty name  :  HisDtlSlipNum
        /// <summary>売上伝票番号</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HisDtlSlipNum
        {
            get { return _hisDtlSlipNum; }
            set { _hisDtlSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSrc
        /// <summary>>受注ステータス（元）</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   >受注ステータス（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSrc
        {
            get { return _acptAnOdrStatusSrc; }
            set { _acptAnOdrStatusSrc = value; }
        }
        // --- ADD 2010/12/20 ----------<<<<<

        /// <summary>
        /// 得意先電子元帳抽出結果(伝票・明細)クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustPrtPprSalTblRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   K2015/06/16 鮑晶</br>
    /// <br>管理番号         :   11101427-00</br>
    /// <br>                 :   メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
    /// </remarks>
    public class CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/11/28 楊洋 redmine#8172の追加対応</br>
        /// <br>Update Note      :   K2015/06/16 鮑晶</br>
        /// <br>管理番号         :   11101427-00</br>
        /// <br>                 :   メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  CustPrtPprSalTblRsltWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is CustPrtPprSalTblRsltWork || graph is ArrayList || graph is CustPrtPprSalTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( CustPrtPprSalTblRsltWork ).FullName ) );

            if ( graph != null && graph is CustPrtPprSalTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprSalTblRsltWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is CustPrtPprSalTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprSalTblRsltWork[])graph).Length;
            }
            else if ( graph is CustPrtPprSalTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //データ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DataDiv
            //売上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesDate
            //売上伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesSlipNum
            //売上行番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesRowNo
            //受注ステータス
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcptAnOdrStatus
            //売上伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCd
            //販売従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesEmployeeNm
            //売上伝票合計（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxExc
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            // --- ADD 陳永康 2014/12/28 変換後品番の追加対応----->>>>>
            //変換後品番
            serInfo.MemberInfo.Add(typeof(string)); //ChangeGoodsNo
            // --- ADD 陳永康 2014/12/28 変換後品番の追加対応-----<<<<<
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode
            //BLグループコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGroupCode
            //出荷数
            serInfo.MemberInfo.Add( typeof( Double ) ); //ShipmentCnt
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //ListPriceTaxExcFl
            // ----------- ADD 連番729 2011/08/18 -------------------->>>>>
            //原価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //CostRate
            //売価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesRate
            // ----------- ADD 連番729 2011/08/18 --------------------<<<<<
            //消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate // ADD 時シン 2020/03/11 PMKOBETSU-2912
            //オープン価格区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnPrcTaxExcFl
            //原価単価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SalesUnitCost
            //売上金額（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesMoneyTaxExc
            //消費税転嫁方式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConsTaxLayMethod
            //売上伝票合計（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesTotalTaxInc
            //売上金額消費税額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPriceConsTax
            //原価金額計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //TotalCost
            //型式指定番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelDesignationNo
            //類別番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CategoryNo
            //車種全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelFullName
            //初年度
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //FirstEntryDate
            //車台№
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SearchFrameNo
            //型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //伝票備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote
            //伝票備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote2
            //伝票備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote3
            //受付従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeNm
            //売上入力者名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputName
            //得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //CustomerSnm
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SupplierSnm
            //相手先伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //PartySaleSlipNum
            //車両管理コード
            serInfo.MemberInfo.Add( typeof( string ) ); //CarMngCode
            //受注番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcceptAnOrderNo
            //計上元出荷№
            serInfo.MemberInfo.Add( typeof( string ) ); //ShipmSalesSlipNum
            //元黒№(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //SrcSalesSlipNum
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesOrderDivCd
            //倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //仕入伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierSlipNo
            //UOE発注先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //UOESupplierCd
            //発注先名(明細表示)
            serInfo.MemberInfo.Add( typeof( string ) ); //UOESupplierSnm
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add( typeof( string ) ); //UoeRemark2
            //ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GuideName
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideNm
            //明細備考
            serInfo.MemberInfo.Add( typeof( string ) ); //DtlNote
            //カラー名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorName1
            //トリム名称
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimName
            //基準単価（定価）
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcLPrice
            //基準単価（売上単価）
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcSalUnPrc
            //基準単価（原価単価）
            serInfo.MemberInfo.Add( typeof( Double ) ); //StdUnPrcUnCst
            // -------------ADD 2009/12/28-------------->>>>>
            //変更前単価
            serInfo.MemberInfo.Add( typeof( Double ) ); //BfSalesUnitPrice
            //変更前原価
            serInfo.MemberInfo.Add( typeof( Double ) ); //BfUnitCost
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            //変更前定価
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            // -------------ADD 2010/08/05--------------<<<<<
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MakerName
            //原価
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //Cost
            //得意先伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustSlipNo
            //計上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpADate
            //売掛区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AccRecDivCd
            //赤伝区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DebitNoteDiv
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //総額表示方法区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalAmountDispWayCd
            //課税区分[明細]
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TaxationDivCd
            //相手先伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //StockPartySaleSlipNum
            //納品先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddresseeCode
            //納品先名称
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName
            //納品先名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //AddresseeName2
            //車台番号
            serInfo.MemberInfo.Add( typeof( string ) ); //FrameNo
            //受注残数
            serInfo.MemberInfo.Add( typeof( Double ) ); //AcptAnOdrRemainCnt
            //自社分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //EnterpriseGanreCode
            //手数料入金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //FeeDeposit
            //値引入金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //DiscountDeposit
            //入力日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
            //商品属性
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsKindCode
            //商品大分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsLGroup
            //商品中分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
            //倉庫棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCdDtl
            //商品大分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsLGroupName
            //商品中分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsMGroupName
            //車両管理番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CarMngNo
            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //カラーコード
            serInfo.MemberInfo.Add( typeof( string ) ); //ColorCode
            //トリムコード
            serInfo.MemberInfo.Add( typeof( string ) ); //TrimCode
            //納品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DeliveredGoodsDiv
            //フル型式固定番号配列
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //FullModelFixedNoAry
            //装備オブジェクト配列
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //CategoryObjAry
            //売上入力者コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SalesInputCode
            //受付従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //FrontEmployeeCd
            //履歴区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HistoryDiv
            //車両走行距離
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Mileage
            //車輌備考
            serInfo.MemberInfo.Add( typeof( string ) ); //CarNote
            // -------------ADD 2010/01/29 ---------->>>>>
            //返品上限数
            serInfo.MemberInfo.Add( typeof( Double ) ); //retuppercnt
            //返品上限数存在フラグ
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //retuppercntDiv
            // -------------ADD 2010/01/29 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            serInfo.MemberInfo.Add(typeof(Byte[])); // FreeSrchMdlFxdNoAryRF
            // --- ADD 2010/04/27 ----------<<<<<

            // --- ADD 2010/12/20 ---------->>>>>
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //HisDtlSlipNum

            //受注ステータス（元）
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSrc
            // --- ADD 2010/12/20 ----------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //自動回答区分(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

            //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64));
            //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

            //更新日時
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //UpdateDateTime
            serInfo.MemberInfo.Add(typeof(Int64));  //UpdateDateTimeDetail // ADD 2012/04/01 gezh Redmine#29250

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            //販売エリア 地区
            serInfo.MemberInfo.Add(typeof(string));//salesAreaName
            //得意先分析コード1
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode1
            //得意先分析コード2
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode2
            //得意先分析コード3
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode3
            //得意先分析コード4
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode4
            //得意先分析コード5
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode5
            //得意先分析コード6
            serInfo.MemberInfo.Add(typeof(Int32));//CustAnalysCode6
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

            serInfo.Serialize( writer, serInfo );
            if ( graph is CustPrtPprSalTblRsltWork )
            {
                CustPrtPprSalTblRsltWork temp = (CustPrtPprSalTblRsltWork)graph;

                SetCustPrtPprSalTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is CustPrtPprSalTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (CustPrtPprSalTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( CustPrtPprSalTblRsltWork temp in lst )
                {
                    SetCustPrtPprSalTblRsltWork( writer, temp );
                }

            }
        }


        /// <summary>
        /// CustPrtPprSalTblRsltWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD m.suzuki 2010/04/02 ---------->>>>>
        ////private const int currentMemberCount = 101;// DEL 2009/12/28
        //// -------------UPD 2010/01/29 ---------->>>>>
        ////private const int currentMemberCount = 103;// ADD 2009/12/28
        //private const int currentMemberCount = 105;
        //// -------------UPD 2010/01/29 ----------<<<<<
        //private const int currentMemberCount = 106;// DEL 2010/04/27
        //private const int currentMemberCount = 107;// ADD 2010/04/27// DEL 2010/08/05
        // --- UPD m.suzuki 2010/04/02 ----------<<<<<
        //private const int currentMemberCount = 108;// ADD 2010/08/05 // DEL 2010/12/20
        //private const int currentMemberCount = 110;// ADD 2010/12/20 // del 2011/07/18 zhubj
        //private const int currentMemberCount = 111;// add 2011/07/18 zhubj // DEL 連番729 2011/08/18
        //private const int currentMemberCount = 113;// ADD 連番729 2011/08/18 //DEL 楊洋 2011/11/28
        //private const int currentMemberCount = 114;  //ADD 2011/11/28　楊洋  // DEL 2012/04/01 gezh Redmine#29250
        //private const int currentMemberCount = 115;  // ADD 2012/04/01 gezh Redmine#29250 // DEL 陳永康 2014/12/28 変換後品番の追加対応
        //private const int currentMemberCount = 116;// ADD 陳永康 2014/12/28 変換後品番の追加対応 //DEL K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する
        private const int currentMemberCount = 123;//ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する
        /// <summary>
        ///  CustPrtPprSalTblRsltWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/11/28 楊洋 redmine#8172の追加対応</br>
        /// <br>Update Note      :   K2015/06/16 鮑晶</br>
        /// <br>管理番号         :   11101427-00</br>
        /// <br>                 :   メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// </remarks>
        private void SetCustPrtPprSalTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprSalTblRsltWork temp )
        {
            //データ区分
            writer.Write( temp.DataDiv );
            //売上日付
            writer.Write( (Int64)temp.SalesDate.Ticks );
            //売上伝票番号
            writer.Write( temp.SalesSlipNum );
            //売上行番号
            writer.Write( temp.SalesRowNo );
            //受注ステータス
            writer.Write( temp.AcptAnOdrStatus );
            //売上伝票区分
            writer.Write( temp.SalesSlipCd );
            //販売従業員名称
            writer.Write( temp.SalesEmployeeNm );
            //売上伝票合計（税抜き）
            writer.Write( temp.SalesTotalTaxExc );
            //商品名称
            writer.Write( temp.GoodsName );
            //商品番号
            writer.Write( temp.GoodsNo );
            // --- ADD 陳永康 2014/12/28 変換後品番の追加対応----->>>>>
            //変換後品番
            writer.Write(temp.ChangeGoodsNo);
            // --- ADD 陳永康 2014/12/28 変換後品番の追加対応-----<<<<<
            //BL商品コード
            writer.Write( temp.BLGoodsCode );
            //BLグループコード
            writer.Write( temp.BLGroupCode );
            //出荷数
            writer.Write( temp.ShipmentCnt );
            //定価（税抜，浮動）
            writer.Write( temp.ListPriceTaxExcFl );
            // ----------- ADD 連番729 2011/08/18 -------------------->>>>>
            //原価率
            writer.Write(temp.CostRate);
            //売価率
            writer.Write(temp.SalesRate);
            // ----------- ADD 連番729 2011/08/18 --------------------<<<<<
            //消費税率
            writer.Write(temp.ConsTaxRate); // ADD 時シン 2020/03/11 PMKOBETSU-2912
            //オープン価格区分
            writer.Write( temp.OpenPriceDiv );
            //売上単価（税抜，浮動）
            writer.Write( temp.SalesUnPrcTaxExcFl );
            //原価単価
            writer.Write( temp.SalesUnitCost );
            //売上金額（税抜き）
            writer.Write( temp.SalesMoneyTaxExc );
            //消費税転嫁方式
            writer.Write( temp.ConsTaxLayMethod );
            //売上伝票合計（税込み）
            writer.Write( temp.SalesTotalTaxInc );
            //売上金額消費税額
            writer.Write( temp.SalesPriceConsTax );
            //原価金額計
            writer.Write( temp.TotalCost );
            //型式指定番号
            writer.Write( temp.ModelDesignationNo );
            //類別番号
            writer.Write( temp.CategoryNo );
            //車種全角名称
            writer.Write( temp.ModelFullName );
            //初年度
            //writer.Write( (Int64)temp.FirstEntryDate.Ticks );// DEL 2010/01/12
            writer.Write( temp.FirstEntryDate );// ADD 2010/01/12
            //車台№
            writer.Write( temp.SearchFrameNo );
            //型式（フル型）
            writer.Write( temp.FullModel );
            //伝票備考
            writer.Write( temp.SlipNote );
            //伝票備考２
            writer.Write( temp.SlipNote2 );
            //伝票備考３
            writer.Write( temp.SlipNote3 );
            //受付従業員名称
            writer.Write( temp.FrontEmployeeNm );
            //売上入力者名称
            writer.Write( temp.SalesInputName );
            //得意先コード
            writer.Write( temp.CustomerCode );
            //得意先略称
            writer.Write( temp.CustomerSnm );
            //仕入先コード
            writer.Write( temp.SupplierCd );
            //仕入先略称
            writer.Write( temp.SupplierSnm );
            //相手先伝票番号
            writer.Write( temp.PartySaleSlipNum );
            //車両管理コード
            writer.Write( temp.CarMngCode );
            //受注番号
            writer.Write( temp.AcceptAnOrderNo );
            //計上元出荷№
            writer.Write( temp.ShipmSalesSlipNum );
            //元黒№(明細表示)
            writer.Write( temp.SrcSalesSlipNum );
            //売上在庫取寄せ区分
            writer.Write( temp.SalesOrderDivCd );
            //倉庫名称
            writer.Write( temp.WarehouseName );
            //仕入伝票番号
            writer.Write( temp.SupplierSlipNo );
            //UOE発注先コード
            writer.Write( temp.UOESupplierCd );
            //発注先名(明細表示)
            writer.Write( temp.UOESupplierSnm );
            //ＵＯＥリマーク１
            writer.Write( temp.UoeRemark1 );
            //ＵＯＥリマーク２
            writer.Write( temp.UoeRemark2 );
            //ガイド名称
            writer.Write( temp.GuideName );
            //拠点ガイド名称
            writer.Write( temp.SectionGuideNm );
            //明細備考
            writer.Write( temp.DtlNote );
            //カラー名称1
            writer.Write( temp.ColorName1 );
            //トリム名称
            writer.Write( temp.TrimName );
            //基準単価（定価）
            writer.Write( temp.StdUnPrcLPrice );
            //基準単価（売上単価）
            writer.Write( temp.StdUnPrcSalUnPrc );
            //基準単価（原価単価）
            writer.Write( temp.StdUnPrcUnCst );
            // -------------ADD 2009/12/28-------------->>>>>
            //変更前単価
            writer.Write( temp.BfSalesUnitPrice );
            //変更前原価
            writer.Write( temp.BfUnitCost );
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            //変更前定価
            writer.Write(temp.BfListPrice);
            // -------------ADD 2010/08/05--------------<<<<<
            //商品メーカーコード
            writer.Write( temp.GoodsMakerCd );
            //メーカー名称
            writer.Write( temp.MakerName );
            //原価
            writer.Write( temp.Cost );
            //得意先伝票番号
            writer.Write( temp.CustSlipNo );
            //計上日付
            writer.Write( (Int64)temp.AddUpADate.Ticks );
            //売掛区分
            writer.Write( temp.AccRecDivCd );
            //赤伝区分
            writer.Write( temp.DebitNoteDiv );
            //拠点コード
            writer.Write( temp.SectionCode );
            //倉庫コード
            writer.Write( temp.WarehouseCode );
            //総額表示方法区分
            writer.Write( temp.TotalAmountDispWayCd );
            //課税区分[明細]
            writer.Write( temp.TaxationDivCd );
            //相手先伝票番号
            writer.Write( temp.StockPartySaleSlipNum );
            //納品先コード
            writer.Write( temp.AddresseeCode );
            //納品先名称
            writer.Write( temp.AddresseeName );
            //納品先名称2
            writer.Write( temp.AddresseeName2 );
            //車台番号
            writer.Write( temp.FrameNo );
            //受注残数
            writer.Write( temp.AcptAnOdrRemainCnt );
            //自社分類コード
            writer.Write( temp.EnterpriseGanreCode );
            //手数料入金額
            writer.Write( temp.FeeDeposit );
            //値引入金額
            writer.Write( temp.DiscountDeposit );
            //入力日
            writer.Write( (Int64)temp.InputDay.Ticks );
            //商品属性
            writer.Write( temp.GoodsKindCode );
            //商品大分類コード
            writer.Write( temp.GoodsLGroup );
            //商品中分類コード
            writer.Write( temp.GoodsMGroup );
            //倉庫棚番
            writer.Write( temp.WarehouseShelfNo );
            //売上伝票区分（明細）
            writer.Write( temp.SalesSlipCdDtl );
            //商品大分類名称
            writer.Write( temp.GoodsLGroupName );
            //商品中分類名称
            writer.Write( temp.GoodsMGroupName );
            //車両管理番号
            writer.Write( temp.CarMngNo );
            //メーカーコード
            writer.Write( temp.MakerCode );
            //車種コード
            writer.Write( temp.ModelCode );
            //車種サブコード
            writer.Write( temp.ModelSubCode );
            //エンジン型式名称
            writer.Write( temp.EngineModelNm );
            //カラーコード
            writer.Write( temp.ColorCode );
            //トリムコード
            writer.Write( temp.TrimCode );
            //納品区分
            writer.Write( temp.DeliveredGoodsDiv );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            //フル型式固定番号配列
            if ( temp.FullModelFixedNoAry == null ) temp.FullModelFixedNoAry = new int[0];
            int length = temp.FullModelFixedNoAry.Length;
            writer.Write( length );
            for ( int cnt = 0; cnt < length; cnt++ )
                writer.Write( temp.FullModelFixedNoAry[cnt] );
            //装備オブジェクト配列
            if ( temp.CategoryObjAry == null ) temp.CategoryObjAry = new byte[0];
            writer.Write( temp.CategoryObjAry.Length );
            writer.Write( temp.CategoryObjAry );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            //売上入力者コード
            writer.Write( temp.SalesInputCode );
            //受付従業員コード
            writer.Write( temp.FrontEmployeeCd );
            //履歴区分
            writer.Write( temp.HistoryDiv );
            //車両走行距離
            writer.Write( temp.Mileage );
            //車輌備考
            writer.Write( temp.CarNote );
            // -------------ADD 2010/01/29 ---------->>>>>
            //返品上限数
            writer.Write( temp.Retuppercnt );
            //返品上限数存在フラグ   
            writer.Write( temp.RetuppercntDiv );
            // -------------ADD 2010/01/29 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //更新日時
            writer.Write( temp.UpdateDateTime );
            writer.Write(temp.UpdateDateTimeDetail);  // ADD 2012/04/01 gezh Redmine#29250
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            // --- ADD m.suzuki 2010/04/02 ---------->>>>>
            //車種半角名称
            writer.Write( temp.ModelHalfName );
            // --- ADD m.suzuki 2010/04/02 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            //自由検索型式固定番号配列
            if (temp.FreeSrchMdlFxdNoAry == null) temp.FreeSrchMdlFxdNoAry = new byte[0];
            writer.Write(temp.FreeSrchMdlFxdNoAry.Length);
            writer.Write(temp.FreeSrchMdlFxdNoAry);
            // --- ADD 2010/04/27 ----------<<<<<

            // --- ADD 2010/12/20 ---------->>>>>
            //売上伝票番号
            writer.Write(temp.HisDtlSlipNum);
            //受注ステータス（元）
            writer.Write(temp.AcptAnOdrStatusSrc);
            // --- ADD 2010/12/20 ----------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //自動回答区分(SCM)
            writer.Write(temp.AutoAnswerDivSCM);
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

            //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            //販売エリア
            writer.Write(temp.SalesAreaName);
            //得意先分析コード1
            writer.Write(temp.CustAnalysCode1);
            //得意先分析コード2
            writer.Write(temp.CustAnalysCode2);
            //得意先分析コード3
            writer.Write(temp.CustAnalysCode3);
            //得意先分析コード4
            writer.Write(temp.CustAnalysCode4);
            //得意先分析コード5
            writer.Write(temp.CustAnalysCode5);
            //得意先分析コード6
            writer.Write(temp.CustAnalysCode6);
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
        }

        /// <summary>
        ///  CustPrtPprSalTblRsltWorkインスタンス取得
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/11/28 楊洋 redmine#8172の追加対応</br>
        /// <br>Update Note      :   K2015/06/16 鮑晶</br>
        /// <br>管理番号         :   11101427-00</br>
        /// <br>                 :   メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// </remarks>
        private CustPrtPprSalTblRsltWork GetCustPrtPprSalTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CustPrtPprSalTblRsltWork temp = new CustPrtPprSalTblRsltWork();

            //データ区分
            temp.DataDiv = reader.ReadInt32();
            //売上日付
            temp.SalesDate = new DateTime( reader.ReadInt64() );
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票区分
            temp.SalesSlipCd = reader.ReadInt32();
            //販売従業員名称
            temp.SalesEmployeeNm = reader.ReadString();
            //売上伝票合計（税抜き）
            temp.SalesTotalTaxExc = reader.ReadInt64();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            // --- ADD 陳永康 2014/12/28 変換後品番の追加対応----->>>>>
            //変換後品番
            temp.ChangeGoodsNo = reader.ReadString();
            // --- ADD 陳永康 2014/12/28 変換後品番の追加対応-----<<<<<
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            // ----------- ADD 連番729 2011/08/18 -------------------->>>>>
            //原価率
            temp.CostRate = reader.ReadDouble();
            //売価率
            temp.SalesRate = reader.ReadDouble();
            // ----------- ADD 連番729 2011/08/18 --------------------<<<<<
            //消費税率
            temp.ConsTaxRate = reader.ReadDouble(); // ADD 時シン 2020/03/11 PMKOBETSU-2912
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //売上伝票合計（税込み）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //売上金額消費税額
            temp.SalesPriceConsTax = reader.ReadInt64();
            //原価金額計
            temp.TotalCost = reader.ReadInt64();
            //型式指定番号
            temp.ModelDesignationNo = reader.ReadInt32();
            //類別番号
            temp.CategoryNo = reader.ReadInt32();
            //車種全角名称
            temp.ModelFullName = reader.ReadString();
            //初年度
            //temp.FirstEntryDate = new DateTime(reader.ReadInt64());// DEL 2010/01/12
            temp.FirstEntryDate = reader.ReadInt32();// ADD 2010/01/12
            //車台№
            temp.SearchFrameNo = reader.ReadInt32();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //伝票備考
            temp.SlipNote = reader.ReadString();
            //伝票備考２
            temp.SlipNote2 = reader.ReadString();
            //伝票備考３
            temp.SlipNote3 = reader.ReadString();
            //受付従業員名称
            temp.FrontEmployeeNm = reader.ReadString();
            //売上入力者名称
            temp.SalesInputName = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //相手先伝票番号
            temp.PartySaleSlipNum = reader.ReadString();
            //車両管理コード
            temp.CarMngCode = reader.ReadString();
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //計上元出荷№
            temp.ShipmSalesSlipNum = reader.ReadString();
            //元黒№(明細表示)
            temp.SrcSalesSlipNum = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
            //発注先名(明細表示)
            temp.UOESupplierSnm = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //ガイド名称
            temp.GuideName = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //明細備考
            temp.DtlNote = reader.ReadString();
            //カラー名称1
            temp.ColorName1 = reader.ReadString();
            //トリム名称
            temp.TrimName = reader.ReadString();
            //基準単価（定価）
            temp.StdUnPrcLPrice = reader.ReadDouble();
            //基準単価（売上単価）
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //基準単価（原価単価）
            temp.StdUnPrcUnCst = reader.ReadDouble();
            // -------------ADD 2009/12/28-------------->>>>>
            //変更前単価
            temp.BfSalesUnitPrice = reader.ReadDouble();
            //変更前原価
            temp.BfUnitCost = reader.ReadDouble();
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            //変更前定価
            temp.BfListPrice = reader.ReadDouble();
            // -------------ADD 2010/08/05--------------<<<<<
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //原価
            temp.Cost = reader.ReadInt64();
            //得意先伝票番号
            temp.CustSlipNo = reader.ReadInt32();
            //計上日付
            temp.AddUpADate = new DateTime( reader.ReadInt64() );
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //赤伝区分
            temp.DebitNoteDiv = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //総額表示方法区分
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //課税区分[明細]
            temp.TaxationDivCd = reader.ReadInt32();
            //相手先伝票番号
            temp.StockPartySaleSlipNum = reader.ReadString();
            //納品先コード
            temp.AddresseeCode = reader.ReadInt32();
            //納品先名称
            temp.AddresseeName = reader.ReadString();
            //納品先名称2
            temp.AddresseeName2 = reader.ReadString();
            //車台番号
            temp.FrameNo = reader.ReadString();
            //受注残数
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //手数料入金額
            temp.FeeDeposit = reader.ReadInt64();
            //値引入金額
            temp.DiscountDeposit = reader.ReadInt64();
            //入力日
            temp.InputDay = new DateTime( reader.ReadInt64() );
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //商品大分類名称
            temp.GoodsLGroupName = reader.ReadString();
            //商品中分類名称
            temp.GoodsMGroupName = reader.ReadString();
            //車両管理番号
            temp.CarMngNo = reader.ReadInt32();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //エンジン型式名称
            temp.EngineModelNm = reader.ReadString();
            //カラーコード
            temp.ColorCode = reader.ReadString();
            //トリムコード
            temp.TrimCode = reader.ReadString();
            //納品区分
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            //フル型式固定番号配列
            int length = reader.ReadInt32();
            temp.FullModelFixedNoAry = new int[length];
            for ( int cnt = 0; cnt < length; cnt++ )
                temp.FullModelFixedNoAry[cnt] = reader.ReadInt32();
            //装備オブジェクト配列
            length = reader.ReadInt32();
            temp.CategoryObjAry = reader.ReadBytes( length );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            //売上入力者コード
            temp.SalesInputCode = reader.ReadString();
            //受付従業員コード
            temp.FrontEmployeeCd = reader.ReadString();
            //履歴区分
            temp.HistoryDiv = reader.ReadInt32();
            //車両走行距離
            temp.Mileage = reader.ReadInt32();
            //車輌備考
            temp.CarNote = reader.ReadString();
            // -------------ADD 2010/01/29 ---------->>>>>
            //返品上限数
            temp.Retuppercnt = reader.ReadDouble();
            //返品上限数存在フラグ
            temp.RetuppercntDiv = reader.ReadInt32();
            // -------------ADD 2010/01/29 ----------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //更新日時
            temp.UpdateDateTime = reader.ReadInt64();
            temp.UpdateDateTimeDetail = reader.ReadInt64();  // ADD 2012/04/01 gezh Redmine#29250
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            // --- UPD m.suzuki 2010/04/02 ---------->>>>>
            // 車種半角名称
            temp.ModelHalfName = reader.ReadString();
            // --- UPD m.suzuki 2010/04/02 ----------<<<<<

            // --- ADD 2010/04/27 ---------->>>>>
            //自由検索型式固定番号配列
            length = reader.ReadInt32();
            temp.FreeSrchMdlFxdNoAry = reader.ReadBytes(length);
            // --- ADD 2010/04/27 ----------<<<<<

            // --- ADD 2010/12/20 ---------->>>>>
            //売上伝票番号
            temp.HisDtlSlipNum = reader.ReadString();
            //受注ステータス（元）
            temp.AcptAnOdrStatusSrc = reader.ReadInt32();
            // --- ADD 2010/12/20 ----------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //自動回答区分(SCM)
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

            //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            //販売エリア
            temp.SalesAreaName = reader.ReadString();
            //得意先分析コード1
            temp.CustAnalysCode1 = reader.ReadInt32();
            //得意先分析コード2
            temp.CustAnalysCode2 = reader.ReadInt32();
            //得意先分析コード3
            temp.CustAnalysCode3 = reader.ReadInt32();
            //得意先分析コード4
            temp.CustAnalysCode4 = reader.ReadInt32();
            //得意先分析コード5
            temp.CustAnalysCode5 = reader.ReadInt32();
            //得意先分析コード6
            temp.CustAnalysCode6 = reader.ReadInt32();
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
 
            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>CustPrtPprSalTblRsltWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprSalTblRsltWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                CustPrtPprSalTblRsltWork temp = GetCustPrtPprSalTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustPrtPprSalTblRsltWork[])lst.ToArray( typeof( CustPrtPprSalTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
