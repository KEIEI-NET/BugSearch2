using System;
using System.Collections;

//using Broadleaf.Library.Data; // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesDetailWork
    /// <summary>
    ///                      自由帳票売上明細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票売上明細データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/01/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/7/19  douch</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   回答区分追加</br>
    /// <br>Update Note      :   2011/08/11 zhouzy</br>
    /// <br>                     リモート伝発</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePSalesDetailWork
    {
        /// <summary>受注ステータス</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </remarks>
        private Int32 _sALESDETAILRF_ACPTANODRSTATUSRF;

        /// <summary>売上伝票番号</summary>
        /// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        private string _sALESDETAILRF_SALESSLIPNUMRF = "";

        /// <summary>受注番号</summary>
        private Int32 _sALESDETAILRF_ACCEPTANORDERNORF;

        /// <summary>売上行番号</summary>
        private Int32 _sALESDETAILRF_SALESROWNORF;

        /// <summary>売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESDETAILRF_SALESDATERF;

        /// <summary>共通通番</summary>
        private Int64 _sALESDETAILRF_COMMONSEQNORF;

        /// <summary>売上明細通番</summary>
        private Int64 _sALESDETAILRF_SALESSLIPDTLNUMRF;

        /// <summary>受注ステータス（元）</summary>
        /// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
        private Int32 _sALESDETAILRF_ACPTANODRSTATUSSRCRF;

        /// <summary>売上明細通番（元）</summary>
        /// <remarks>計上時の元データ明細通番をセット</remarks>
        private Int64 _sALESDETAILRF_SALESSLIPDTLNUMSRCRF;

        /// <summary>仕入形式（同時）</summary>
        /// <remarks>0:仕入,1:入荷</remarks>
        private Int32 _sALESDETAILRF_SUPPLIERFORMALSYNCRF;

        /// <summary>仕入明細通番（同時）</summary>
        /// <remarks>同時計上時の仕入明細通番をセット</remarks>
        private Int64 _sALESDETAILRF_STOCKSLIPDTLNUMSYNCRF;

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計</remarks>
        private Int32 _sALESDETAILRF_SALESSLIPCDDTLRF;

        /// <summary>在庫管理有無区分</summary>
        /// <remarks>0:在庫管理しない,1:在庫管理する</remarks>
        private Int32 _sALESDETAILRF_STOCKMNGEXISTCDRF;

        /// <summary>納品完了予定日</summary>
        /// <remarks>客先納期(YYYYMMDD)</remarks>
        private Int32 _sALESDETAILRF_DELIGDSCMPLTDUEDATERF;

        /// <summary>商品属性</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _sALESDETAILRF_GOODSKINDCODERF;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _sALESDETAILRF_GOODSMAKERCDRF;

        /// <summary>メーカー名称</summary>
        private string _sALESDETAILRF_MAKERNAMERF = "";

        /// <summary>商品番号</summary>
        private string _sALESDETAILRF_GOODSNORF = "";

        /// <summary>商品名称</summary>
        private string _sALESDETAILRF_GOODSNAMERF = "";

        /// <summary>商品名略称</summary>
        private string _sALESDETAILRF_GOODSSHORTNAMERF = "";

        /// <summary>BL商品コード</summary>
        private Int32 _sALESDETAILRF_BLGOODSCODERF;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _sALESDETAILRF_BLGOODSFULLNAMERF = "";

        /// <summary>自社分類コード</summary>
        private Int32 _sALESDETAILRF_ENTERPRISEGANRECODERF;

        /// <summary>自社分類名称</summary>
        private string _sALESDETAILRF_ENTERPRISEGANRENAMERF = "";

        /// <summary>倉庫コード</summary>
        private string _sALESDETAILRF_WAREHOUSECODERF = "";

        /// <summary>倉庫名称</summary>
        private string _sALESDETAILRF_WAREHOUSENAMERF = "";

        /// <summary>倉庫棚番</summary>
        private string _sALESDETAILRF_WAREHOUSESHELFNORF = "";

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private Int32 _sALESDETAILRF_SALESORDERDIVCDRF;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _sALESDETAILRF_OPENPRICEDIVRF;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>商品の掛率用ランク</remarks>
        private string _sALESDETAILRF_GOODSRATERANKRF = "";

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _sALESDETAILRF_CUSTRATEGRPCODERF;

        /// <summary>定価率</summary>
        private Double _sALESDETAILRF_LISTPRICERATERF;

        /// <summary>定価（税込，浮動）</summary>
        /// <remarks>税抜き</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXINCFLRF;

        /// <summary>定価（税抜，浮動）</summary>
        /// <remarks>税込み</remarks>
        private Double _sALESDETAILRF_LISTPRICETAXEXCFLRF;

        /// <summary>定価変更区分</summary>
        /// <remarks>0:変更なし,1:変更あり　（定価手入力）</remarks>
        private Int32 _sALESDETAILRF_LISTPRICECHNGCDRF;

        /// <summary>売価率</summary>
        private Double _sALESDETAILRF_SALESRATERF;

        /// <summary>売上単価（税込，浮動）</summary>
        private Double _sALESDETAILRF_SALESUNPRCTAXINCFLRF;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _sALESDETAILRF_SALESUNPRCTAXEXCFLRF;

        /// <summary>原価率</summary>
        private Double _sALESDETAILRF_COSTRATERF;

        /// <summary>原価単価</summary>
        private Double _sALESDETAILRF_SALESUNITCOSTRF;

        /// <summary>出荷数</summary>
        private Double _sALESDETAILRF_SHIPMENTCNTRF;

        /// <summary>受注数量</summary>
        /// <remarks>受注,出荷で使用</remarks>
        private Double _sALESDETAILRF_ACCEPTANORDERCNTRF;

        /// <summary>受注調整数</summary>
        /// <remarks>現在の受注数は「受注数量＋受注調整数」で算出</remarks>
        private Double _sALESDETAILRF_ACPTANODRADJUSTCNTRF;

        /// <summary>受注残数</summary>
        /// <remarks>受注数量＋受注調整数－出荷数</remarks>
        private Double _sALESDETAILRF_ACPTANODRREMAINCNTRF;

        /// <summary>残数更新日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _sALESDETAILRF_REMAINCNTUPDDATERF;

        /// <summary>売上金額（税込み）</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXINCRF;

        /// <summary>売上金額（税抜き）</summary>
        private Int64 _sALESDETAILRF_SALESMONEYTAXEXCRF;

        /// <summary>原価</summary>
        private Int64 _sALESDETAILRF_COSTRF;

        /// <summary>粗利チェック区分</summary>
        /// <remarks>0:正常,1:原価割れ,2:利益の上げ過ぎ</remarks>
        private Int32 _sALESDETAILRF_GRSPROFITCHKDIVRF;

        /// <summary>売上商品区分</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private Int32 _sALESDETAILRF_SALESGOODSCDRF;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _sALESDETAILRF_TAXATIONDIVCDRF;

        /// <summary>相手先伝票番号（明細）</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _sALESDETAILRF_PARTYSLIPNUMDTLRF = "";

        /// <summary>明細備考</summary>
        private string _sALESDETAILRF_DTLNOTERF = "";

        /// <summary>仕入先コード</summary>
        private Int32 _sALESDETAILRF_SUPPLIERCDRF;

        /// <summary>仕入先略称</summary>
        private string _sALESDETAILRF_SUPPLIERSNMRF = "";

        /// <summary>発注番号</summary>
        private string _sALESDETAILRF_ORDERNUMBERRF = "";

        /// <summary>伝票メモ１</summary>
        private string _sALESDETAILRF_SLIPMEMO1RF = "";

        /// <summary>伝票メモ２</summary>
        private string _sALESDETAILRF_SLIPMEMO2RF = "";

        /// <summary>伝票メモ３</summary>
        private string _sALESDETAILRF_SLIPMEMO3RF = "";

        /// <summary>社内メモ１</summary>
        private string _sALESDETAILRF_INSIDEMEMO1RF = "";

        /// <summary>社内メモ２</summary>
        private string _sALESDETAILRF_INSIDEMEMO2RF = "";

        /// <summary>社内メモ３</summary>
        private string _sALESDETAILRF_INSIDEMEMO3RF = "";

        /// <summary>変更前定価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _sALESDETAILRF_BFLISTPRICERF;

        /// <summary>変更前売価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _sALESDETAILRF_BFSALESUNITPRICERF;

        /// <summary>変更前原価</summary>
        /// <remarks>税抜き、掛率算出結果</remarks>
        private Double _sALESDETAILRF_BFUNITCOSTRF;

        /// <summary>一式明細番号</summary>
        /// <remarks>0:一式なし　1～一式連番</remarks>
        private Int32 _sALESDETAILRF_CMPLTSALESROWNORF;

        /// <summary>メーカーコード（一式）</summary>
        private Int32 _sALESDETAILRF_CMPLTGOODSMAKERCDRF;

        /// <summary>メーカー名称（一式）</summary>
        private string _sALESDETAILRF_CMPLTMAKERNAMERF = "";

        /// <summary>商品名称（一式）</summary>
        private string _sALESDETAILRF_CMPLTGOODSNAMERF = "";

        /// <summary>数量（一式）</summary>
        private Double _sALESDETAILRF_CMPLTSHIPMENTCNTRF;

        /// <summary>売上単価（一式）</summary>
        /// <remarks>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
        private Double _sALESDETAILRF_CMPLTSALESUNPRCFLRF;

        /// <summary>売上金額（一式）</summary>
        /// <remarks>売上金額（税抜き）の同一一式明細の合計</remarks>
        private Int64 _sALESDETAILRF_CMPLTSALESMONEYRF;

        /// <summary>原価単価（一式）</summary>
        /// <remarks>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
        private Double _sALESDETAILRF_CMPLTSALESUNITCOSTRF;

        /// <summary>原価金額（一式）</summary>
        /// <remarks>原価の同一一式明細の合計</remarks>
        private Int64 _sALESDETAILRF_CMPLTCOSTRF;

        /// <summary>相手先伝票番号（一式）</summary>
        /// <remarks>得意先注文番号</remarks>
        private string _sALESDETAILRF_CMPLTPARTYSALSLNUMRF = "";

        /// <summary>一式備考</summary>
        private string _sALESDETAILRF_CMPLTNOTERF = "";

        /// <summary>車両管理番号</summary>
        /// <remarks>自動採番（無重複のシーケンス）PM7での車両SEQ</remarks>
        private Int32 _aCCEPTODRCARRF_CARMNGNORF;

        /// <summary>車輌管理コード</summary>
        /// <remarks>※PM7での車両管理番号</remarks>
        private string _aCCEPTODRCARRF_CARMNGCODERF = "";

        /// <summary>陸運事務所番号</summary>
        private Int32 _aCCEPTODRCARRF_NUMBERPLATE1CODERF;

        /// <summary>陸運事務局名称</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE1NAMERF = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE2RF = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _aCCEPTODRCARRF_NUMBERPLATE3RF = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _aCCEPTODRCARRF_NUMBERPLATE4RF;

        /// <summary>初年度</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aCCEPTODRCARRF_FIRSTENTRYDATERF;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _aCCEPTODRCARRF_MAKERCODERF;

        /// <summary>メーカー全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _aCCEPTODRCARRF_MAKERFULLNAMERF = "";

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _aCCEPTODRCARRF_MODELCODERF;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _aCCEPTODRCARRF_MODELSUBCODERF;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _aCCEPTODRCARRF_MODELFULLNAMERF = "";

        /// <summary>排ガス記号</summary>
        private string _aCCEPTODRCARRF_EXHAUSTGASSIGNRF = "";

        /// <summary>シリーズ型式</summary>
        private string _aCCEPTODRCARRF_SERIESMODELRF = "";

        /// <summary>型式（類別記号）</summary>
        private string _aCCEPTODRCARRF_CATEGORYSIGNMODELRF = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _aCCEPTODRCARRF_FULLMODELRF = "";

        /// <summary>型式指定番号</summary>
        private Int32 _aCCEPTODRCARRF_MODELDESIGNATIONNORF;

        /// <summary>類別番号</summary>
        private Int32 _aCCEPTODRCARRF_CATEGORYNORF;

        /// <summary>車台型式</summary>
        private string _aCCEPTODRCARRF_FRAMEMODELRF = "";

        /// <summary>車台番号</summary>
        /// <remarks>車検証記載フォーマット対応（ HCR32-100251584 等）</remarks>
        private string _aCCEPTODRCARRF_FRAMENORF = "";

        /// <summary>車台番号（検索用）</summary>
        /// <remarks>PM7の車台番号と同意</remarks>
        private Int32 _aCCEPTODRCARRF_SEARCHFRAMENORF;

        /// <summary>エンジン型式名称</summary>
        /// <remarks>エンジン検索</remarks>
        private string _aCCEPTODRCARRF_ENGINEMODELNMRF = "";

        /// <summary>関連型式</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _aCCEPTODRCARRF_RELEVANCEMODELRF = "";

        /// <summary>サブ車名コード</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private Int32 _aCCEPTODRCARRF_SUBCARNMCDRF;

        /// <summary>型式グレード略称</summary>
        /// <remarks>リサイクル系で使用</remarks>
        private string _aCCEPTODRCARRF_MODELGRADESNAMERF = "";

        /// <summary>カラーコード</summary>
        /// <remarks>カタログの色コード</remarks>
        private string _aCCEPTODRCARRF_COLORCODERF = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>画面表示用正式名称</remarks>
        private string _aCCEPTODRCARRF_COLORNAME1RF = "";

        /// <summary>トリムコード</summary>
        private string _aCCEPTODRCARRF_TRIMCODERF = "";

        /// <summary>トリム名称</summary>
        private string _aCCEPTODRCARRF_TRIMNAMERF = "";

        /// <summary>車両走行距離</summary>
        private Int32 _aCCEPTODRCARRF_MILEAGERF;

        /// <summary>部品メーカー略称</summary>
        private string _mAKGDS_MAKERSHORTNAMERF = "";

        /// <summary>部品メーカーカナ名称</summary>
        private string _mAKGDS_MAKERKANANAMERF = "";

        /// <summary>ユーザー検索部品メーカーコード</summary>
        /// <remarks>（ユーザーデータに該当が有る事をチェックする為の項目）</remarks>
        private Int32 _mAKGDS_GOODSMAKERCDRF;

        /// <summary>一式メーカー略称</summary>
        private string _mAKCMP_MAKERSHORTNAMERF = "";

        /// <summary>一式メーカーカナ名称</summary>
        private string _mAKCMP_MAKERKANANAMERF = "";

        /// <summary>ユーザー検索一式メーカーコード</summary>
        /// <remarks>（ユーザーデータに該当が有る事をチェックする為の項目）</remarks>
        private Int32 _mAKCMP_GOODSMAKERCDRF;

        /// <summary>商品名称カナ</summary>
        private string _gOODSURF_GOODSNAMEKANARF = "";

        /// <summary>JANコード</summary>
        private string _gOODSURF_JANRF = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _gOODSURF_GOODSRATERANKRF = "";

        /// <summary>ハイフン無商品番号</summary>
        private string _gOODSURF_GOODSNONONEHYPHENRF = "";

        /// <summary>商品備考１</summary>
        private string _gOODSURF_GOODSNOTE1RF = "";

        /// <summary>商品備考２</summary>
        private string _gOODSURF_GOODSNOTE2RF = "";

        /// <summary>商品規格・特記事項</summary>
        private string _gOODSURF_GOODSSPECIALNOTERF = "";

        /// <summary>出荷可能数</summary>
        /// <remarks>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</remarks>
        private Double _sTOCKRF_SHIPMENTPOSCNTRF;

        /// <summary>重複棚番１</summary>
        private string _sTOCKRF_DUPLICATIONSHELFNO1RF = "";

        /// <summary>重複棚番２</summary>
        private string _sTOCKRF_DUPLICATIONSHELFNO2RF = "";

        /// <summary>部品管理区分１</summary>
        private string _sTOCKRF_PARTSMANAGEMENTDIVIDE1RF = "";

        /// <summary>部品管理区分２</summary>
        private string _sTOCKRF_PARTSMANAGEMENTDIVIDE2RF = "";

        /// <summary>在庫備考１</summary>
        private string _sTOCKRF_STOCKNOTE1RF = "";

        /// <summary>在庫備考２</summary>
        private string _sTOCKRF_STOCKNOTE2RF = "";

        /// <summary>倉庫備考1</summary>
        private string _wAREHOUSERF_WAREHOUSENOTE1RF = "";

        /// <summary>得意先掛率ＧＲ名称</summary>
        private string _uSRCSG_GUIDENAMERF = "";

        /// <summary>ユーザー検索仕入先コード</summary>
        /// <remarks>（ユーザーＤＢに該当があるかチェックする為の項目）</remarks>
        private Int32 _sUPPLIERRF_SUPPLIERCDRF;

        /// <summary>仕入先名1</summary>
        private string _sUPPLIERRF_SUPPLIERNM1RF = "";

        /// <summary>仕入先名2</summary>
        private string _sUPPLIERRF_SUPPLIERNM2RF = "";

        /// <summary>仕入先敬称</summary>
        private string _sUPPLIERRF_SUPPHONORIFICTITLERF = "";

        /// <summary>仕入先カナ</summary>
        private string _sUPPLIERRF_SUPPLIERKANARF = "";

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private Int32 _sUPPLIERRF_PURECODERF;

        /// <summary>仕入先備考1</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE1RF = "";

        /// <summary>仕入先備考2</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE2RF = "";

        /// <summary>仕入先備考3</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE3RF = "";

        /// <summary>仕入先備考4</summary>
        private string _sUPPLIERRF_SUPPLIERNOTE4RF = "";

        /// <summary>ユーザー検索BL商品コード</summary>
        /// <remarks>（ユーザーＤＢに該当が有るかチェックする為の項目）</remarks>
        private Int32 _bLGOODSCDURF_BLGOODSCODERF;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGOODSCDURF_BLGOODSHALFNAMERF = "";

        /// <summary>在庫管理有無区分名称</summary>
        /// <remarks>0:在庫管理しない,1:在庫管理する</remarks>
        private string _dADD_STOCKMNGEXISTNMRF = "";

        /// <summary>商品属性名称</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private string _dADD_GOODSKINDNAMERF = "";

        /// <summary>売上在庫取寄せ区分名称</summary>
        /// <remarks>0:取寄せ，1:在庫</remarks>
        private string _dADD_SALESORDERDIVNMRF = "";

        /// <summary>オープン価格区分名称</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private string _dADD_OPENPRICEDIVNMRF = "";

        /// <summary>粗利チェック区分名称</summary>
        /// <remarks>0:正常,1:原価割れ,2:利益の上げ過ぎ</remarks>
        private string _dADD_GRSPROFITCHKDIVNMRF = "";

        /// <summary>売上商品区分名称</summary>
        /// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
        private string _dADD_SALESGOODSNMRF = "";

        /// <summary>課税区分名称</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private string _dADD_TAXATIONDIVNMRF = "";

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private string _dADD_PURECODENMRF = "";

        /// <summary>納品完了予定日西暦年</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFYRF;

        /// <summary>納品完了予定日西暦年略</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFSRF;

        /// <summary>納品完了予定日和暦年</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFWRF;

        /// <summary>納品完了予定日月</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFMRF;

        /// <summary>納品完了予定日日</summary>
        private Int32 _dADD_DELIGDSCMPLTDUEDATEFDRF;

        /// <summary>納品完了予定日元号</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFGRF = "";

        /// <summary>納品完了予定日略号</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFRRF = "";

        /// <summary>納品完了予定日リテラル(/)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLSRF = "";

        /// <summary>納品完了予定日リテラル(.)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLPRF = "";

        /// <summary>納品完了予定日リテラル(年)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLYRF = "";

        /// <summary>納品完了予定日リテラル(月)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLMRF = "";

        /// <summary>納品完了予定日リテラル(日)</summary>
        private string _dADD_DELIGDSCMPLTDUEDATEFLDRF = "";

        /// <summary>初年度西暦年</summary>
        private Int32 _dADD_FIRSTENTRYDATEFYRF;

        /// <summary>初年度西暦年略</summary>
        private Int32 _dADD_FIRSTENTRYDATEFSRF;

        /// <summary>初年度和暦年</summary>
        private Int32 _dADD_FIRSTENTRYDATEFWRF;

        /// <summary>初年度月</summary>
        private Int32 _dADD_FIRSTENTRYDATEFMRF;

        /// <summary>初年度元号</summary>
        private string _dADD_FIRSTENTRYDATEFGRF = "";

        /// <summary>初年度略号</summary>
        private string _dADD_FIRSTENTRYDATEFRRF = "";

        /// <summary>初年度リテラル(/)</summary>
        private string _dADD_FIRSTENTRYDATEFLSRF = "";

        /// <summary>初年度リテラル(.)</summary>
        private string _dADD_FIRSTENTRYDATEFLPRF = "";

        /// <summary>初年度リテラル(年)</summary>
        private string _dADD_FIRSTENTRYDATEFLYRF = "";

        /// <summary>初年度リテラル(月)</summary>
        private string _dADD_FIRSTENTRYDATEFLMRF = "";

        /// <summary>在庫取寄区分マーク</summary>
        /// <remarks>*:取寄，空白:在庫</remarks>
        private string _dADD_SALESORDERDIVMARKRF = "";

        /// <summary>メーカー半角名称</summary>
        private string _aCCEPTODRCARRF_MAKERHALFNAMERF = "";

        /// <summary>車種半角名称</summary>
        private string _aCCEPTODRCARRF_MODELHALFNAMERF = "";

        /// <summary>BL商品コード（印刷）</summary>
        /// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
        private Int32 _sALESDETAILRF_PRTBLGOODSCODERF;

        /// <summary>BL商品コード名称（印刷）</summary>
        /// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
        private string _sALESDETAILRF_PRTBLGOODSNAMERF = "";

        /// <summary>印刷用品番</summary>
        private string _sALESDETAILRF_PRTGOODSNORF = "";

        /// <summary>印刷用メーカーコード</summary>
        private Int32 _sALESDETAILRF_PRTMAKERCODERF;

        /// <summary>印刷用メーカー名称</summary>
        private string _sALESDETAILRF_PRTMAKERNAMERF = "";

        /// <summary>印刷用メーカーカナ名称</summary>
        private string _mAKPRT_MAKERKANANAMERF = "";

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _sALESDETAILRF_GOODSLGROUPRF;

        /// <summary>商品大分類名称</summary>
        private string _sALESDETAILRF_GOODSLGROUPNAMERF = "";

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _sALESDETAILRF_GOODSMGROUPRF;

        /// <summary>商品中分類名称</summary>
        private string _sALESDETAILRF_GOODSMGROUPNAMERF = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>旧グループコード</remarks>
        private Int32 _sALESDETAILRF_BLGROUPCODERF;

        /// <summary>BLグループコード名称</summary>
        private string _sALESDETAILRF_BLGROUPNAMERF = "";

        /// <summary>販売区分コード</summary>
        private Int32 _sALESDETAILRF_SALESCODERF;

        /// <summary>販売区分名称</summary>
        private string _sALESDETAILRF_SALESCDNMRF = "";

        /// <summary>商品名称カナ</summary>
        private string _sALESDETAILRF_GOODSNAMEKANARF = "";

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// <summary>AB商品コード</summary>
        private string _sANDEGOODSCDCHGRF_ABGOODSCODE = "";
        // --- ADD 2009.07.24 劉洋 ------ <<<<<<

        // --- ADD 2011.07.19  ------ >>>>>>
        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _sALESDETAILRF_AUTOANSWERDIVSCMRF;
        // --- ADD 2011.07.19  ------ <<<<<<
	    // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>受発注種別</summary>
        private Int16 _sALESDETAILRF_ACCEPTORORDERKINDRF;
        /// <summary>問合せ番号</summary>
        private Int64 _sALESDETAILRF_INQUIRYNUMBERRF;
        /// <summary>問合せ行番号</summary>
        private Int32 _sALESDETAILRF_INQROWNUMBERRF;
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end


        /// public propaty name  :  SALESDETAILRF_ACPTANODRSTATUSRF
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACPTANODRSTATUSRF
        {
            get { return _sALESDETAILRF_ACPTANODRSTATUSRF; }
            set { _sALESDETAILRF_ACPTANODRSTATUSRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPNUMRF
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SALESSLIPNUMRF
        {
            get { return _sALESDETAILRF_SALESSLIPNUMRF; }
            set { _sALESDETAILRF_SALESSLIPNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACCEPTANORDERNORF
        /// <summary>受注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACCEPTANORDERNORF
        {
            get { return _sALESDETAILRF_ACCEPTANORDERNORF; }
            set { _sALESDETAILRF_ACCEPTANORDERNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESROWNORF
        /// <summary>売上行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESROWNORF
        {
            get { return _sALESDETAILRF_SALESROWNORF; }
            set { _sALESDETAILRF_SALESROWNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESDATERF
        /// <summary>売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESDATERF
        {
            get { return _sALESDETAILRF_SALESDATERF; }
            set { _sALESDETAILRF_SALESDATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COMMONSEQNORF
        /// <summary>共通通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_COMMONSEQNORF
        {
            get { return _sALESDETAILRF_COMMONSEQNORF; }
            set { _sALESDETAILRF_COMMONSEQNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPDTLNUMRF
        /// <summary>売上明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESSLIPDTLNUMRF
        {
            get { return _sALESDETAILRF_SALESSLIPDTLNUMRF; }
            set { _sALESDETAILRF_SALESSLIPDTLNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACPTANODRSTATUSSRCRF
        /// <summary>受注ステータス（元）プロパティ</summary>
        /// <value>10:見積,20:受注,30:売上,40:出荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ACPTANODRSTATUSSRCRF
        {
            get { return _sALESDETAILRF_ACPTANODRSTATUSSRCRF; }
            set { _sALESDETAILRF_ACPTANODRSTATUSSRCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPDTLNUMSRCRF
        /// <summary>売上明細通番（元）プロパティ</summary>
        /// <value>計上時の元データ明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESSLIPDTLNUMSRCRF
        {
            get { return _sALESDETAILRF_SALESSLIPDTLNUMSRCRF; }
            set { _sALESDETAILRF_SALESSLIPDTLNUMSRCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERFORMALSYNCRF
        /// <summary>仕入形式（同時）プロパティ</summary>
        /// <value>0:仕入,1:入荷</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SUPPLIERFORMALSYNCRF
        {
            get { return _sALESDETAILRF_SUPPLIERFORMALSYNCRF; }
            set { _sALESDETAILRF_SUPPLIERFORMALSYNCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF
        /// <summary>仕入明細通番（同時）プロパティ</summary>
        /// <value>同時計上時の仕入明細通番をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番（同時）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF
        {
            get { return _sALESDETAILRF_STOCKSLIPDTLNUMSYNCRF; }
            set { _sALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESSLIPCDDTLRF
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESSLIPCDDTLRF
        {
            get { return _sALESDETAILRF_SALESSLIPCDDTLRF; }
            set { _sALESDETAILRF_SALESSLIPCDDTLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_STOCKMNGEXISTCDRF
        /// <summary>在庫管理有無区分プロパティ</summary>
        /// <value>0:在庫管理しない,1:在庫管理する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫管理有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_STOCKMNGEXISTCDRF
        {
            get { return _sALESDETAILRF_STOCKMNGEXISTCDRF; }
            set { _sALESDETAILRF_STOCKMNGEXISTCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_DELIGDSCMPLTDUEDATERF
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>客先納期(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_DELIGDSCMPLTDUEDATERF
        {
            get { return _sALESDETAILRF_DELIGDSCMPLTDUEDATERF; }
            set { _sALESDETAILRF_DELIGDSCMPLTDUEDATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSKINDCODERF
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSKINDCODERF
        {
            get { return _sALESDETAILRF_GOODSKINDCODERF; }
            set { _sALESDETAILRF_GOODSKINDCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMAKERCDRF
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSMAKERCDRF
        {
            get { return _sALESDETAILRF_GOODSMAKERCDRF; }
            set { _sALESDETAILRF_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_MAKERNAMERF
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_MAKERNAMERF
        {
            get { return _sALESDETAILRF_MAKERNAMERF; }
            set { _sALESDETAILRF_MAKERNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNORF
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNORF
        {
            get { return _sALESDETAILRF_GOODSNORF; }
            set { _sALESDETAILRF_GOODSNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNAMERF
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNAMERF
        {
            get { return _sALESDETAILRF_GOODSNAMERF; }
            set { _sALESDETAILRF_GOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSSHORTNAMERF
        /// <summary>商品名略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSSHORTNAMERF
        {
            get { return _sALESDETAILRF_GOODSSHORTNAMERF; }
            set { _sALESDETAILRF_GOODSSHORTNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGOODSCODERF
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_BLGOODSCODERF
        {
            get { return _sALESDETAILRF_BLGOODSCODERF; }
            set { _sALESDETAILRF_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGOODSFULLNAMERF
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_BLGOODSFULLNAMERF
        {
            get { return _sALESDETAILRF_BLGOODSFULLNAMERF; }
            set { _sALESDETAILRF_BLGOODSFULLNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ENTERPRISEGANRECODERF
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_ENTERPRISEGANRECODERF
        {
            get { return _sALESDETAILRF_ENTERPRISEGANRECODERF; }
            set { _sALESDETAILRF_ENTERPRISEGANRECODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ENTERPRISEGANRENAMERF
        /// <summary>自社分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_ENTERPRISEGANRENAMERF
        {
            get { return _sALESDETAILRF_ENTERPRISEGANRENAMERF; }
            set { _sALESDETAILRF_ENTERPRISEGANRENAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSECODERF
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSECODERF
        {
            get { return _sALESDETAILRF_WAREHOUSECODERF; }
            set { _sALESDETAILRF_WAREHOUSECODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSENAMERF
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSENAMERF
        {
            get { return _sALESDETAILRF_WAREHOUSENAMERF; }
            set { _sALESDETAILRF_WAREHOUSENAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_WAREHOUSESHELFNORF
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_WAREHOUSESHELFNORF
        {
            get { return _sALESDETAILRF_WAREHOUSESHELFNORF; }
            set { _sALESDETAILRF_WAREHOUSESHELFNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESORDERDIVCDRF
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESORDERDIVCDRF
        {
            get { return _sALESDETAILRF_SALESORDERDIVCDRF; }
            set { _sALESDETAILRF_SALESORDERDIVCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_OPENPRICEDIVRF
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_OPENPRICEDIVRF
        {
            get { return _sALESDETAILRF_OPENPRICEDIVRF; }
            set { _sALESDETAILRF_OPENPRICEDIVRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSRATERANKRF
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>商品の掛率用ランク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSRATERANKRF
        {
            get { return _sALESDETAILRF_GOODSRATERANKRF; }
            set { _sALESDETAILRF_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CUSTRATEGRPCODERF
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CUSTRATEGRPCODERF
        {
            get { return _sALESDETAILRF_CUSTRATEGRPCODERF; }
            set { _sALESDETAILRF_CUSTRATEGRPCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICERATERF
        /// <summary>定価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICERATERF
        {
            get { return _sALESDETAILRF_LISTPRICERATERF; }
            set { _sALESDETAILRF_LISTPRICERATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICETAXINCFLRF
        /// <summary>定価（税込，浮動）プロパティ</summary>
        /// <value>税抜き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICETAXINCFLRF
        {
            get { return _sALESDETAILRF_LISTPRICETAXINCFLRF; }
            set { _sALESDETAILRF_LISTPRICETAXINCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICETAXEXCFLRF
        /// <summary>定価（税抜，浮動）プロパティ</summary>
        /// <value>税込み</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_LISTPRICETAXEXCFLRF
        {
            get { return _sALESDETAILRF_LISTPRICETAXEXCFLRF; }
            set { _sALESDETAILRF_LISTPRICETAXEXCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_LISTPRICECHNGCDRF
        /// <summary>定価変更区分プロパティ</summary>
        /// <value>0:変更なし,1:変更あり　（定価手入力）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価変更区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_LISTPRICECHNGCDRF
        {
            get { return _sALESDETAILRF_LISTPRICECHNGCDRF; }
            set { _sALESDETAILRF_LISTPRICECHNGCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESRATERF
        /// <summary>売価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESRATERF
        {
            get { return _sALESDETAILRF_SALESRATERF; }
            set { _sALESDETAILRF_SALESRATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNPRCTAXINCFLRF
        /// <summary>売上単価（税込，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税込，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNPRCTAXINCFLRF
        {
            get { return _sALESDETAILRF_SALESUNPRCTAXINCFLRF; }
            set { _sALESDETAILRF_SALESUNPRCTAXINCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNPRCTAXEXCFLRF
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNPRCTAXEXCFLRF
        {
            get { return _sALESDETAILRF_SALESUNPRCTAXEXCFLRF; }
            set { _sALESDETAILRF_SALESUNPRCTAXEXCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COSTRATERF
        /// <summary>原価率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_COSTRATERF
        {
            get { return _sALESDETAILRF_COSTRATERF; }
            set { _sALESDETAILRF_COSTRATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESUNITCOSTRF
        /// <summary>原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SALESUNITCOSTRF
        {
            get { return _sALESDETAILRF_SALESUNITCOSTRF; }
            set { _sALESDETAILRF_SALESUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SHIPMENTCNTRF
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_SHIPMENTCNTRF
        {
            get { return _sALESDETAILRF_SHIPMENTCNTRF; }
            set { _sALESDETAILRF_SHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACCEPTANORDERCNTRF
        /// <summary>受注数量プロパティ</summary>
        /// <value>受注,出荷で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_ACCEPTANORDERCNTRF
        {
            get { return _sALESDETAILRF_ACCEPTANORDERCNTRF; }
            set { _sALESDETAILRF_ACCEPTANORDERCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACPTANODRADJUSTCNTRF
        /// <summary>受注調整数プロパティ</summary>
        /// <value>現在の受注数は「受注数量＋受注調整数」で算出</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_ACPTANODRADJUSTCNTRF
        {
            get { return _sALESDETAILRF_ACPTANODRADJUSTCNTRF; }
            set { _sALESDETAILRF_ACPTANODRADJUSTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ACPTANODRREMAINCNTRF
        /// <summary>受注残数プロパティ</summary>
        /// <value>受注数量＋受注調整数－出荷数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注残数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_ACPTANODRREMAINCNTRF
        {
            get { return _sALESDETAILRF_ACPTANODRREMAINCNTRF; }
            set { _sALESDETAILRF_ACPTANODRREMAINCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_REMAINCNTUPDDATERF
        /// <summary>残数更新日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数更新日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_REMAINCNTUPDDATERF
        {
            get { return _sALESDETAILRF_REMAINCNTUPDDATERF; }
            set { _sALESDETAILRF_REMAINCNTUPDDATERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESMONEYTAXINCRF
        /// <summary>売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税込み）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESMONEYTAXINCRF
        {
            get { return _sALESDETAILRF_SALESMONEYTAXINCRF; }
            set { _sALESDETAILRF_SALESMONEYTAXINCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESMONEYTAXEXCRF
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_SALESMONEYTAXEXCRF
        {
            get { return _sALESDETAILRF_SALESMONEYTAXEXCRF; }
            set { _sALESDETAILRF_SALESMONEYTAXEXCRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_COSTRF
        /// <summary>原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_COSTRF
        {
            get { return _sALESDETAILRF_COSTRF; }
            set { _sALESDETAILRF_COSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GRSPROFITCHKDIVRF
        /// <summary>粗利チェック区分プロパティ</summary>
        /// <value>0:正常,1:原価割れ,2:利益の上げ過ぎ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GRSPROFITCHKDIVRF
        {
            get { return _sALESDETAILRF_GRSPROFITCHKDIVRF; }
            set { _sALESDETAILRF_GRSPROFITCHKDIVRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESGOODSCDRF
        /// <summary>売上商品区分プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESGOODSCDRF
        {
            get { return _sALESDETAILRF_SALESGOODSCDRF; }
            set { _sALESDETAILRF_SALESGOODSCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_TAXATIONDIVCDRF
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_TAXATIONDIVCDRF
        {
            get { return _sALESDETAILRF_TAXATIONDIVCDRF; }
            set { _sALESDETAILRF_TAXATIONDIVCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PARTYSLIPNUMDTLRF
        /// <summary>相手先伝票番号（明細）プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PARTYSLIPNUMDTLRF
        {
            get { return _sALESDETAILRF_PARTYSLIPNUMDTLRF; }
            set { _sALESDETAILRF_PARTYSLIPNUMDTLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_DTLNOTERF
        /// <summary>明細備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_DTLNOTERF
        {
            get { return _sALESDETAILRF_DTLNOTERF; }
            set { _sALESDETAILRF_DTLNOTERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERCDRF
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SUPPLIERCDRF
        {
            get { return _sALESDETAILRF_SUPPLIERCDRF; }
            set { _sALESDETAILRF_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SUPPLIERSNMRF
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SUPPLIERSNMRF
        {
            get { return _sALESDETAILRF_SUPPLIERSNMRF; }
            set { _sALESDETAILRF_SUPPLIERSNMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_ORDERNUMBERRF
        /// <summary>発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_ORDERNUMBERRF
        {
            get { return _sALESDETAILRF_ORDERNUMBERRF; }
            set { _sALESDETAILRF_ORDERNUMBERRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO1RF
        /// <summary>伝票メモ１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO1RF
        {
            get { return _sALESDETAILRF_SLIPMEMO1RF; }
            set { _sALESDETAILRF_SLIPMEMO1RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO2RF
        /// <summary>伝票メモ２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO2RF
        {
            get { return _sALESDETAILRF_SLIPMEMO2RF; }
            set { _sALESDETAILRF_SLIPMEMO2RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SLIPMEMO3RF
        /// <summary>伝票メモ３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SLIPMEMO3RF
        {
            get { return _sALESDETAILRF_SLIPMEMO3RF; }
            set { _sALESDETAILRF_SLIPMEMO3RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO1RF
        /// <summary>社内メモ１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO1RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO1RF; }
            set { _sALESDETAILRF_INSIDEMEMO1RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO2RF
        /// <summary>社内メモ２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO2RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO2RF; }
            set { _sALESDETAILRF_INSIDEMEMO2RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INSIDEMEMO3RF
        /// <summary>社内メモ３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   社内メモ３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_INSIDEMEMO3RF
        {
            get { return _sALESDETAILRF_INSIDEMEMO3RF; }
            set { _sALESDETAILRF_INSIDEMEMO3RF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFLISTPRICERF
        /// <summary>変更前定価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_BFLISTPRICERF
        {
            get { return _sALESDETAILRF_BFLISTPRICERF; }
            set { _sALESDETAILRF_BFLISTPRICERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFSALESUNITPRICERF
        /// <summary>変更前売価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前売価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_BFSALESUNITPRICERF
        {
            get { return _sALESDETAILRF_BFSALESUNITPRICERF; }
            set { _sALESDETAILRF_BFSALESUNITPRICERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BFUNITCOSTRF
        /// <summary>変更前原価プロパティ</summary>
        /// <value>税抜き、掛率算出結果</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_BFUNITCOSTRF
        {
            get { return _sALESDETAILRF_BFUNITCOSTRF; }
            set { _sALESDETAILRF_BFUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESROWNORF
        /// <summary>一式明細番号プロパティ</summary>
        /// <value>0:一式なし　1～一式連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式明細番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CMPLTSALESROWNORF
        {
            get { return _sALESDETAILRF_CMPLTSALESROWNORF; }
            set { _sALESDETAILRF_CMPLTSALESROWNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTGOODSMAKERCDRF
        /// <summary>メーカーコード（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_CMPLTGOODSMAKERCDRF
        {
            get { return _sALESDETAILRF_CMPLTGOODSMAKERCDRF; }
            set { _sALESDETAILRF_CMPLTGOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTMAKERNAMERF
        /// <summary>メーカー名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTMAKERNAMERF
        {
            get { return _sALESDETAILRF_CMPLTMAKERNAMERF; }
            set { _sALESDETAILRF_CMPLTMAKERNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTGOODSNAMERF
        /// <summary>商品名称（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTGOODSNAMERF
        {
            get { return _sALESDETAILRF_CMPLTGOODSNAMERF; }
            set { _sALESDETAILRF_CMPLTGOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSHIPMENTCNTRF
        /// <summary>数量（一式）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSHIPMENTCNTRF
        {
            get { return _sALESDETAILRF_CMPLTSHIPMENTCNTRF; }
            set { _sALESDETAILRF_CMPLTSHIPMENTCNTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESUNPRCFLRF
        /// <summary>売上単価（一式）プロパティ</summary>
        /// <value>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSALESUNPRCFLRF
        {
            get { return _sALESDETAILRF_CMPLTSALESUNPRCFLRF; }
            set { _sALESDETAILRF_CMPLTSALESUNPRCFLRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESMONEYRF
        /// <summary>売上金額（一式）プロパティ</summary>
        /// <value>売上金額（税抜き）の同一一式明細の合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_CMPLTSALESMONEYRF
        {
            get { return _sALESDETAILRF_CMPLTSALESMONEYRF; }
            set { _sALESDETAILRF_CMPLTSALESMONEYRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTSALESUNITCOSTRF
        /// <summary>原価単価（一式）プロパティ</summary>
        /// <value>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SALESDETAILRF_CMPLTSALESUNITCOSTRF
        {
            get { return _sALESDETAILRF_CMPLTSALESUNITCOSTRF; }
            set { _sALESDETAILRF_CMPLTSALESUNITCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTCOSTRF
        /// <summary>原価金額（一式）プロパティ</summary>
        /// <value>原価の同一一式明細の合計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価金額（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_CMPLTCOSTRF
        {
            get { return _sALESDETAILRF_CMPLTCOSTRF; }
            set { _sALESDETAILRF_CMPLTCOSTRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTPARTYSALSLNUMRF
        /// <summary>相手先伝票番号（一式）プロパティ</summary>
        /// <value>得意先注文番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号（一式）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTPARTYSALSLNUMRF
        {
            get { return _sALESDETAILRF_CMPLTPARTYSALSLNUMRF; }
            set { _sALESDETAILRF_CMPLTPARTYSALSLNUMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_CMPLTNOTERF
        /// <summary>一式備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_CMPLTNOTERF
        {
            get { return _sALESDETAILRF_CMPLTNOTERF; }
            set { _sALESDETAILRF_CMPLTNOTERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CARMNGNORF
        /// <summary>車両管理番号プロパティ</summary>
        /// <value>自動採番（無重複のシーケンス）PM7での車両SEQ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_CARMNGNORF
        {
            get { return _aCCEPTODRCARRF_CARMNGNORF; }
            set { _aCCEPTODRCARRF_CARMNGNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CARMNGCODERF
        /// <summary>車輌管理コードプロパティ</summary>
        /// <value>※PM7での車両管理番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_CARMNGCODERF
        {
            get { return _aCCEPTODRCARRF_CARMNGCODERF; }
            set { _aCCEPTODRCARRF_CARMNGCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE1CODERF
        /// <summary>陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_NUMBERPLATE1CODERF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE1CODERF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE1CODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE1NAMERF
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE1NAMERF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE1NAMERF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE1NAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE2RF
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE2RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE2RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE2RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE3RF
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_NUMBERPLATE3RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE3RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE3RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_NUMBERPLATE4RF
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_NUMBERPLATE4RF
        {
            get { return _aCCEPTODRCARRF_NUMBERPLATE4RF; }
            set { _aCCEPTODRCARRF_NUMBERPLATE4RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FIRSTENTRYDATERF
        /// <summary>初年度プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_FIRSTENTRYDATERF
        {
            get { return _aCCEPTODRCARRF_FIRSTENTRYDATERF; }
            set { _aCCEPTODRCARRF_FIRSTENTRYDATERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERCODERF
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MAKERCODERF
        {
            get { return _aCCEPTODRCARRF_MAKERCODERF; }
            set { _aCCEPTODRCARRF_MAKERCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERFULLNAMERF
        /// <summary>メーカー全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MAKERFULLNAMERF
        {
            get { return _aCCEPTODRCARRF_MAKERFULLNAMERF; }
            set { _aCCEPTODRCARRF_MAKERFULLNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELCODERF
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELCODERF
        {
            get { return _aCCEPTODRCARRF_MODELCODERF; }
            set { _aCCEPTODRCARRF_MODELCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELSUBCODERF
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELSUBCODERF
        {
            get { return _aCCEPTODRCARRF_MODELSUBCODERF; }
            set { _aCCEPTODRCARRF_MODELSUBCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELFULLNAMERF
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELFULLNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELFULLNAMERF; }
            set { _aCCEPTODRCARRF_MODELFULLNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_EXHAUSTGASSIGNRF
        /// <summary>排ガス記号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_EXHAUSTGASSIGNRF
        {
            get { return _aCCEPTODRCARRF_EXHAUSTGASSIGNRF; }
            set { _aCCEPTODRCARRF_EXHAUSTGASSIGNRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SERIESMODELRF
        /// <summary>シリーズ型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_SERIESMODELRF
        {
            get { return _aCCEPTODRCARRF_SERIESMODELRF; }
            set { _aCCEPTODRCARRF_SERIESMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CATEGORYSIGNMODELRF
        /// <summary>型式（類別記号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_CATEGORYSIGNMODELRF
        {
            get { return _aCCEPTODRCARRF_CATEGORYSIGNMODELRF; }
            set { _aCCEPTODRCARRF_CATEGORYSIGNMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FULLMODELRF
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FULLMODELRF
        {
            get { return _aCCEPTODRCARRF_FULLMODELRF; }
            set { _aCCEPTODRCARRF_FULLMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELDESIGNATIONNORF
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MODELDESIGNATIONNORF
        {
            get { return _aCCEPTODRCARRF_MODELDESIGNATIONNORF; }
            set { _aCCEPTODRCARRF_MODELDESIGNATIONNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_CATEGORYNORF
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_CATEGORYNORF
        {
            get { return _aCCEPTODRCARRF_CATEGORYNORF; }
            set { _aCCEPTODRCARRF_CATEGORYNORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FRAMEMODELRF
        /// <summary>車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FRAMEMODELRF
        {
            get { return _aCCEPTODRCARRF_FRAMEMODELRF; }
            set { _aCCEPTODRCARRF_FRAMEMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_FRAMENORF
        /// <summary>車台番号プロパティ</summary>
        /// <value>車検証記載フォーマット対応（ HCR32-100251584 等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_FRAMENORF
        {
            get { return _aCCEPTODRCARRF_FRAMENORF; }
            set { _aCCEPTODRCARRF_FRAMENORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SEARCHFRAMENORF
        /// <summary>車台番号（検索用）プロパティ</summary>
        /// <value>PM7の車台番号と同意</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号（検索用）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_SEARCHFRAMENORF
        {
            get { return _aCCEPTODRCARRF_SEARCHFRAMENORF; }
            set { _aCCEPTODRCARRF_SEARCHFRAMENORF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_ENGINEMODELNMRF
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>エンジン検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_ENGINEMODELNMRF
        {
            get { return _aCCEPTODRCARRF_ENGINEMODELNMRF; }
            set { _aCCEPTODRCARRF_ENGINEMODELNMRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_RELEVANCEMODELRF
        /// <summary>関連型式プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   関連型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_RELEVANCEMODELRF
        {
            get { return _aCCEPTODRCARRF_RELEVANCEMODELRF; }
            set { _aCCEPTODRCARRF_RELEVANCEMODELRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_SUBCARNMCDRF
        /// <summary>サブ車名コードプロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サブ車名コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_SUBCARNMCDRF
        {
            get { return _aCCEPTODRCARRF_SUBCARNMCDRF; }
            set { _aCCEPTODRCARRF_SUBCARNMCDRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELGRADESNAMERF
        /// <summary>型式グレード略称プロパティ</summary>
        /// <value>リサイクル系で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELGRADESNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELGRADESNAMERF; }
            set { _aCCEPTODRCARRF_MODELGRADESNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_COLORCODERF
        /// <summary>カラーコードプロパティ</summary>
        /// <value>カタログの色コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_COLORCODERF
        {
            get { return _aCCEPTODRCARRF_COLORCODERF; }
            set { _aCCEPTODRCARRF_COLORCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_COLORNAME1RF
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>画面表示用正式名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_COLORNAME1RF
        {
            get { return _aCCEPTODRCARRF_COLORNAME1RF; }
            set { _aCCEPTODRCARRF_COLORNAME1RF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_TRIMCODERF
        /// <summary>トリムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_TRIMCODERF
        {
            get { return _aCCEPTODRCARRF_TRIMCODERF; }
            set { _aCCEPTODRCARRF_TRIMCODERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_TRIMNAMERF
        /// <summary>トリム名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_TRIMNAMERF
        {
            get { return _aCCEPTODRCARRF_TRIMNAMERF; }
            set { _aCCEPTODRCARRF_TRIMNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MILEAGERF
        /// <summary>車両走行距離プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両走行距離プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ACCEPTODRCARRF_MILEAGERF
        {
            get { return _aCCEPTODRCARRF_MILEAGERF; }
            set { _aCCEPTODRCARRF_MILEAGERF = value; }
        }

        /// public propaty name  :  MAKGDS_MAKERSHORTNAMERF
        /// <summary>部品メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKGDS_MAKERSHORTNAMERF
        {
            get { return _mAKGDS_MAKERSHORTNAMERF; }
            set { _mAKGDS_MAKERSHORTNAMERF = value; }
        }

        /// public propaty name  :  MAKGDS_MAKERKANANAMERF
        /// <summary>部品メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKGDS_MAKERKANANAMERF
        {
            get { return _mAKGDS_MAKERKANANAMERF; }
            set { _mAKGDS_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  MAKGDS_GOODSMAKERCDRF
        /// <summary>ユーザー検索部品メーカーコードプロパティ</summary>
        /// <value>（ユーザーデータに該当が有る事をチェックする為の項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー検索部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MAKGDS_GOODSMAKERCDRF
        {
            get { return _mAKGDS_GOODSMAKERCDRF; }
            set { _mAKGDS_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  MAKCMP_MAKERSHORTNAMERF
        /// <summary>一式メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKCMP_MAKERSHORTNAMERF
        {
            get { return _mAKCMP_MAKERSHORTNAMERF; }
            set { _mAKCMP_MAKERSHORTNAMERF = value; }
        }

        /// public propaty name  :  MAKCMP_MAKERKANANAMERF
        /// <summary>一式メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   一式メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKCMP_MAKERKANANAMERF
        {
            get { return _mAKCMP_MAKERKANANAMERF; }
            set { _mAKCMP_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  MAKCMP_GOODSMAKERCDRF
        /// <summary>ユーザー検索一式メーカーコードプロパティ</summary>
        /// <value>（ユーザーデータに該当が有る事をチェックする為の項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー検索一式メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MAKCMP_GOODSMAKERCDRF
        {
            get { return _mAKCMP_GOODSMAKERCDRF; }
            set { _mAKCMP_GOODSMAKERCDRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNAMEKANARF
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_GOODSNAMEKANARF
        {
            get { return _gOODSURF_GOODSNAMEKANARF; }
            set { _gOODSURF_GOODSNAMEKANARF = value; }
        }

        /// public propaty name  :  GOODSURF_JANRF
        /// <summary>JANコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JANコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_JANRF
        {
            get { return _gOODSURF_JANRF; }
            set { _gOODSURF_JANRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSRATERANKRF
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_GOODSRATERANKRF
        {
            get { return _gOODSURF_GOODSRATERANKRF; }
            set { _gOODSURF_GOODSRATERANKRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNONONEHYPHENRF
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_GOODSNONONEHYPHENRF
        {
            get { return _gOODSURF_GOODSNONONEHYPHENRF; }
            set { _gOODSURF_GOODSNONONEHYPHENRF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNOTE1RF
        /// <summary>商品備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_GOODSNOTE1RF
        {
            get { return _gOODSURF_GOODSNOTE1RF; }
            set { _gOODSURF_GOODSNOTE1RF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSNOTE2RF
        /// <summary>商品備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_GOODSNOTE2RF
        {
            get { return _gOODSURF_GOODSNOTE2RF; }
            set { _gOODSURF_GOODSNOTE2RF = value; }
        }

        /// public propaty name  :  GOODSURF_GOODSSPECIALNOTERF
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GOODSURF_GOODSSPECIALNOTERF
        {
            get { return _gOODSURF_GOODSSPECIALNOTERF; }
            set { _gOODSURF_GOODSSPECIALNOTERF = value; }
        }

        /// public propaty name  :  STOCKRF_SHIPMENTPOSCNTRF
        /// <summary>出荷可能数プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数＋受託在庫数－（仕入在庫分委託数＋受託分委託数）－（移動中仕入在庫数＋移動中受託在庫数）－受注数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double STOCKRF_SHIPMENTPOSCNTRF
        {
            get { return _sTOCKRF_SHIPMENTPOSCNTRF; }
            set { _sTOCKRF_SHIPMENTPOSCNTRF = value; }
        }

        /// public propaty name  :  STOCKRF_DUPLICATIONSHELFNO1RF
        /// <summary>重複棚番１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STOCKRF_DUPLICATIONSHELFNO1RF
        {
            get { return _sTOCKRF_DUPLICATIONSHELFNO1RF; }
            set { _sTOCKRF_DUPLICATIONSHELFNO1RF = value; }
        }

        /// public propaty name  :  STOCKRF_DUPLICATIONSHELFNO2RF
        /// <summary>重複棚番２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   重複棚番２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STOCKRF_DUPLICATIONSHELFNO2RF
        {
            get { return _sTOCKRF_DUPLICATIONSHELFNO2RF; }
            set { _sTOCKRF_DUPLICATIONSHELFNO2RF = value; }
        }

        /// public propaty name  :  STOCKRF_PARTSMANAGEMENTDIVIDE1RF
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STOCKRF_PARTSMANAGEMENTDIVIDE1RF
        {
            get { return _sTOCKRF_PARTSMANAGEMENTDIVIDE1RF; }
            set { _sTOCKRF_PARTSMANAGEMENTDIVIDE1RF = value; }
        }

        /// public propaty name  :  STOCKRF_PARTSMANAGEMENTDIVIDE2RF
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STOCKRF_PARTSMANAGEMENTDIVIDE2RF
        {
            get { return _sTOCKRF_PARTSMANAGEMENTDIVIDE2RF; }
            set { _sTOCKRF_PARTSMANAGEMENTDIVIDE2RF = value; }
        }

        /// public propaty name  :  STOCKRF_STOCKNOTE1RF
        /// <summary>在庫備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STOCKRF_STOCKNOTE1RF
        {
            get { return _sTOCKRF_STOCKNOTE1RF; }
            set { _sTOCKRF_STOCKNOTE1RF = value; }
        }

        /// public propaty name  :  STOCKRF_STOCKNOTE2RF
        /// <summary>在庫備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string STOCKRF_STOCKNOTE2RF
        {
            get { return _sTOCKRF_STOCKNOTE2RF; }
            set { _sTOCKRF_STOCKNOTE2RF = value; }
        }

        /// public propaty name  :  WAREHOUSERF_WAREHOUSENOTE1RF
        /// <summary>倉庫備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WAREHOUSERF_WAREHOUSENOTE1RF
        {
            get { return _wAREHOUSERF_WAREHOUSENOTE1RF; }
            set { _wAREHOUSERF_WAREHOUSENOTE1RF = value; }
        }

        /// public propaty name  :  USRCSG_GUIDENAMERF
        /// <summary>得意先掛率ＧＲ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率ＧＲ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string USRCSG_GUIDENAMERF
        {
            get { return _uSRCSG_GUIDENAMERF; }
            set { _uSRCSG_GUIDENAMERF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERCDRF
        /// <summary>ユーザー検索仕入先コードプロパティ</summary>
        /// <value>（ユーザーＤＢに該当があるかチェックする為の項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー検索仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SUPPLIERRF_SUPPLIERCDRF
        {
            get { return _sUPPLIERRF_SUPPLIERCDRF; }
            set { _sUPPLIERRF_SUPPLIERCDRF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNM1RF
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNM1RF
        {
            get { return _sUPPLIERRF_SUPPLIERNM1RF; }
            set { _sUPPLIERRF_SUPPLIERNM1RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNM2RF
        /// <summary>仕入先名2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNM2RF
        {
            get { return _sUPPLIERRF_SUPPLIERNM2RF; }
            set { _sUPPLIERRF_SUPPLIERNM2RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPHONORIFICTITLERF
        /// <summary>仕入先敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPHONORIFICTITLERF
        {
            get { return _sUPPLIERRF_SUPPHONORIFICTITLERF; }
            set { _sUPPLIERRF_SUPPHONORIFICTITLERF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERKANARF
        /// <summary>仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERKANARF
        {
            get { return _sUPPLIERRF_SUPPLIERKANARF; }
            set { _sUPPLIERRF_SUPPLIERKANARF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_PURECODERF
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SUPPLIERRF_PURECODERF
        {
            get { return _sUPPLIERRF_PURECODERF; }
            set { _sUPPLIERRF_PURECODERF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE1RF
        /// <summary>仕入先備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE1RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE1RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE1RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE2RF
        /// <summary>仕入先備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE2RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE2RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE2RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE3RF
        /// <summary>仕入先備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE3RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE3RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE3RF = value; }
        }

        /// public propaty name  :  SUPPLIERRF_SUPPLIERNOTE4RF
        /// <summary>仕入先備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SUPPLIERRF_SUPPLIERNOTE4RF
        {
            get { return _sUPPLIERRF_SUPPLIERNOTE4RF; }
            set { _sUPPLIERRF_SUPPLIERNOTE4RF = value; }
        }

        /// public propaty name  :  BLGOODSCDURF_BLGOODSCODERF
        /// <summary>ユーザー検索BL商品コードプロパティ</summary>
        /// <value>（ユーザーＤＢに該当が有るかチェックする為の項目）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザー検索BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGOODSCDURF_BLGOODSCODERF
        {
            get { return _bLGOODSCDURF_BLGOODSCODERF; }
            set { _bLGOODSCDURF_BLGOODSCODERF = value; }
        }

        /// public propaty name  :  BLGOODSCDURF_BLGOODSHALFNAMERF
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGOODSCDURF_BLGOODSHALFNAMERF
        {
            get { return _bLGOODSCDURF_BLGOODSHALFNAMERF; }
            set { _bLGOODSCDURF_BLGOODSHALFNAMERF = value; }
        }

        /// public propaty name  :  DADD_STOCKMNGEXISTNMRF
        /// <summary>在庫管理有無区分名称プロパティ</summary>
        /// <value>0:在庫管理しない,1:在庫管理する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫管理有無区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_STOCKMNGEXISTNMRF
        {
            get { return _dADD_STOCKMNGEXISTNMRF; }
            set { _dADD_STOCKMNGEXISTNMRF = value; }
        }

        /// public propaty name  :  DADD_GOODSKINDNAMERF
        /// <summary>商品属性名称プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_GOODSKINDNAMERF
        {
            get { return _dADD_GOODSKINDNAMERF; }
            set { _dADD_GOODSKINDNAMERF = value; }
        }

        /// public propaty name  :  DADD_SALESORDERDIVNMRF
        /// <summary>売上在庫取寄せ区分名称プロパティ</summary>
        /// <value>0:取寄せ，1:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESORDERDIVNMRF
        {
            get { return _dADD_SALESORDERDIVNMRF; }
            set { _dADD_SALESORDERDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_OPENPRICEDIVNMRF
        /// <summary>オープン価格区分名称プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_OPENPRICEDIVNMRF
        {
            get { return _dADD_OPENPRICEDIVNMRF; }
            set { _dADD_OPENPRICEDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_GRSPROFITCHKDIVNMRF
        /// <summary>粗利チェック区分名称プロパティ</summary>
        /// <value>0:正常,1:原価割れ,2:利益の上げ過ぎ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利チェック区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_GRSPROFITCHKDIVNMRF
        {
            get { return _dADD_GRSPROFITCHKDIVNMRF; }
            set { _dADD_GRSPROFITCHKDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_SALESGOODSNMRF
        /// <summary>売上商品区分名称プロパティ</summary>
        /// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上商品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESGOODSNMRF
        {
            get { return _dADD_SALESGOODSNMRF; }
            set { _dADD_SALESGOODSNMRF = value; }
        }

        /// public propaty name  :  DADD_TAXATIONDIVNMRF
        /// <summary>課税区分名称プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_TAXATIONDIVNMRF
        {
            get { return _dADD_TAXATIONDIVNMRF; }
            set { _dADD_TAXATIONDIVNMRF = value; }
        }

        /// public propaty name  :  DADD_PURECODENMRF
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_PURECODENMRF
        {
            get { return _dADD_PURECODENMRF; }
            set { _dADD_PURECODENMRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFYRF
        /// <summary>納品完了予定日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFYRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFYRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFSRF
        /// <summary>納品完了予定日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFSRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFSRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFWRF
        /// <summary>納品完了予定日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFWRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFWRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFMRF
        /// <summary>納品完了予定日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFMRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFMRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFDRF
        /// <summary>納品完了予定日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_DELIGDSCMPLTDUEDATEFDRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFDRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFDRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFGRF
        /// <summary>納品完了予定日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFGRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFGRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFRRF
        /// <summary>納品完了予定日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFRRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFRRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLSRF
        /// <summary>納品完了予定日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLSRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLSRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLPRF
        /// <summary>納品完了予定日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLPRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLPRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLYRF
        /// <summary>納品完了予定日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLYRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLYRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLMRF
        /// <summary>納品完了予定日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLMRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLMRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_DELIGDSCMPLTDUEDATEFLDRF
        /// <summary>納品完了予定日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_DELIGDSCMPLTDUEDATEFLDRF
        {
            get { return _dADD_DELIGDSCMPLTDUEDATEFLDRF; }
            set { _dADD_DELIGDSCMPLTDUEDATEFLDRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFYRF
        /// <summary>初年度西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFYRF
        {
            get { return _dADD_FIRSTENTRYDATEFYRF; }
            set { _dADD_FIRSTENTRYDATEFYRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFSRF
        /// <summary>初年度西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFSRF
        {
            get { return _dADD_FIRSTENTRYDATEFSRF; }
            set { _dADD_FIRSTENTRYDATEFSRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFWRF
        /// <summary>初年度和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFWRF
        {
            get { return _dADD_FIRSTENTRYDATEFWRF; }
            set { _dADD_FIRSTENTRYDATEFWRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFMRF
        /// <summary>初年度月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DADD_FIRSTENTRYDATEFMRF
        {
            get { return _dADD_FIRSTENTRYDATEFMRF; }
            set { _dADD_FIRSTENTRYDATEFMRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFGRF
        /// <summary>初年度元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFGRF
        {
            get { return _dADD_FIRSTENTRYDATEFGRF; }
            set { _dADD_FIRSTENTRYDATEFGRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFRRF
        /// <summary>初年度略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFRRF
        {
            get { return _dADD_FIRSTENTRYDATEFRRF; }
            set { _dADD_FIRSTENTRYDATEFRRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLSRF
        /// <summary>初年度リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLSRF
        {
            get { return _dADD_FIRSTENTRYDATEFLSRF; }
            set { _dADD_FIRSTENTRYDATEFLSRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLPRF
        /// <summary>初年度リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLPRF
        {
            get { return _dADD_FIRSTENTRYDATEFLPRF; }
            set { _dADD_FIRSTENTRYDATEFLPRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLYRF
        /// <summary>初年度リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLYRF
        {
            get { return _dADD_FIRSTENTRYDATEFLYRF; }
            set { _dADD_FIRSTENTRYDATEFLYRF = value; }
        }

        /// public propaty name  :  DADD_FIRSTENTRYDATEFLMRF
        /// <summary>初年度リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初年度リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_FIRSTENTRYDATEFLMRF
        {
            get { return _dADD_FIRSTENTRYDATEFLMRF; }
            set { _dADD_FIRSTENTRYDATEFLMRF = value; }
        }

        /// public propaty name  :  DADD_SALESORDERDIVMARKRF
        /// <summary>在庫取寄区分マークプロパティ</summary>
        /// <value>*:取寄，空白:在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄区分マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DADD_SALESORDERDIVMARKRF
        {
            get { return _dADD_SALESORDERDIVMARKRF; }
            set { _dADD_SALESORDERDIVMARKRF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MAKERHALFNAMERF
        /// <summary>メーカー半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MAKERHALFNAMERF
        {
            get { return _aCCEPTODRCARRF_MAKERHALFNAMERF; }
            set { _aCCEPTODRCARRF_MAKERHALFNAMERF = value; }
        }

        /// public propaty name  :  ACCEPTODRCARRF_MODELHALFNAMERF
        /// <summary>車種半角名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ACCEPTODRCARRF_MODELHALFNAMERF
        {
            get { return _aCCEPTODRCARRF_MODELHALFNAMERF; }
            set { _aCCEPTODRCARRF_MODELHALFNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTBLGOODSCODERF
        /// <summary>BL商品コード（印刷）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_PRTBLGOODSCODERF
        {
            get { return _sALESDETAILRF_PRTBLGOODSCODERF; }
            set { _sALESDETAILRF_PRTBLGOODSCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTBLGOODSNAMERF
        /// <summary>BL商品コード名称（印刷）プロパティ</summary>
        /// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（印刷）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PRTBLGOODSNAMERF
        {
            get { return _sALESDETAILRF_PRTBLGOODSNAMERF; }
            set { _sALESDETAILRF_PRTBLGOODSNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTGOODSNORF
        /// <summary>印刷用品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PRTGOODSNORF
        {
            get { return _sALESDETAILRF_PRTGOODSNORF; }
            set { _sALESDETAILRF_PRTGOODSNORF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTMAKERCODERF
        /// <summary>印刷用メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_PRTMAKERCODERF
        {
            get { return _sALESDETAILRF_PRTMAKERCODERF; }
            set { _sALESDETAILRF_PRTMAKERCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_PRTMAKERNAMERF
        /// <summary>印刷用メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_PRTMAKERNAMERF
        {
            get { return _sALESDETAILRF_PRTMAKERNAMERF; }
            set { _sALESDETAILRF_PRTMAKERNAMERF = value; }
        }

        /// public propaty name  :  MAKPRT_MAKERKANANAMERF
        /// <summary>印刷用メーカーカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷用メーカーカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MAKPRT_MAKERKANANAMERF
        {
            get { return _mAKPRT_MAKERKANANAMERF; }
            set { _mAKPRT_MAKERKANANAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSLGROUPRF
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSLGROUPRF
        {
            get { return _sALESDETAILRF_GOODSLGROUPRF; }
            set { _sALESDETAILRF_GOODSLGROUPRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSLGROUPNAMERF
        /// <summary>商品大分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSLGROUPNAMERF
        {
            get { return _sALESDETAILRF_GOODSLGROUPNAMERF; }
            set { _sALESDETAILRF_GOODSLGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMGROUPRF
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_GOODSMGROUPRF
        {
            get { return _sALESDETAILRF_GOODSMGROUPRF; }
            set { _sALESDETAILRF_GOODSMGROUPRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSMGROUPNAMERF
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSMGROUPNAMERF
        {
            get { return _sALESDETAILRF_GOODSMGROUPNAMERF; }
            set { _sALESDETAILRF_GOODSMGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGROUPCODERF
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>旧グループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_BLGROUPCODERF
        {
            get { return _sALESDETAILRF_BLGROUPCODERF; }
            set { _sALESDETAILRF_BLGROUPCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_BLGROUPNAMERF
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_BLGROUPNAMERF
        {
            get { return _sALESDETAILRF_BLGROUPNAMERF; }
            set { _sALESDETAILRF_BLGROUPNAMERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESCODERF
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_SALESCODERF
        {
            get { return _sALESDETAILRF_SALESCODERF; }
            set { _sALESDETAILRF_SALESCODERF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_SALESCDNMRF
        /// <summary>販売区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_SALESCDNMRF
        {
            get { return _sALESDETAILRF_SALESCDNMRF; }
            set { _sALESDETAILRF_SALESCDNMRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_GOODSNAMEKANARF
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SALESDETAILRF_GOODSNAMEKANARF
        {
            get { return _sALESDETAILRF_GOODSNAMEKANARF; }
            set { _sALESDETAILRF_GOODSNAMEKANARF = value; }
        }

        // --- ADD 2009.07.24 劉洋 ------ >>>>>>
        /// public propaty name  :  SAndEGoodsCdChgRF_ABGoodsCode
        /// <summary>AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SANDEGOODSCDCHGRF_ABGOODSCODE
        {
            get { return _sANDEGOODSCDCHGRF_ABGOODSCODE; }
            set { _sANDEGOODSCDCHGRF_ABGOODSCODE = value; }
        }
        // --- ADD 2009.07.24 劉洋 ------ <<<<<<

        // --- ADD 2011.07.19  ------ >>>>>>
        /// public propaty name  :  SALESDETAILRF_AUTOANSWERDIVSCMRF        
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>0:通常(PCC連携なし)、1:手動回答、2:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_AUTOANSWERDIVSCMRF
        {
            get { return _sALESDETAILRF_AUTOANSWERDIVSCMRF; }
            set { _sALESDETAILRF_AUTOANSWERDIVSCMRF = value; }
        }
        // --- ADD 2011.07.19  ------ <<<<<<
		// add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// public propaty name  :  SALESDETAILRF_ACCEPTORORDERKINDRF
        /// <summary>受発注種別カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 SALESDETAILRF_ACCEPTORORDERKINDRF
        {
            get { return _sALESDETAILRF_ACCEPTORORDERKINDRF; }
            set { _sALESDETAILRF_ACCEPTORORDERKINDRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INQUIRYNUMBERRF
        /// <summary>問合せ番号カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SALESDETAILRF_INQUIRYNUMBERRF
        {
            get { return _sALESDETAILRF_INQUIRYNUMBERRF; }
            set { _sALESDETAILRF_INQUIRYNUMBERRF = value; }
        }

        /// public propaty name  :  SALESDETAILRF_INQROWNUMBERRF
        /// <summary>問合せ行番号カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ行番号カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SALESDETAILRF_INQROWNUMBERRF
        {
            get { return _sALESDETAILRF_INQROWNUMBERRF; }
            set { _sALESDETAILRF_INQROWNUMBERRF = value; }
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end


        /// <summary>
        /// 自由帳票売上明細データワークコンストラクタ
        /// </summary>
        /// <returns>FrePSalesDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesDetailWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePSalesDetailWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FrePSalesDetailWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FrePSalesDetailWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FrePSalesDetailWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesDetailWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePSalesDetailWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePSalesDetailWork || graph is ArrayList || graph is FrePSalesDetailWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( FrePSalesDetailWork ).FullName ) );

            if ( graph != null && graph is FrePSalesDetailWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePSalesDetailWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePSalesDetailWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePSalesDetailWork[])graph).Length;
            }
            else if ( graph is FrePSalesDetailWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //受注ステータス
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACPTANODRSTATUSRF
            //売上伝票番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SALESSLIPNUMRF
            //受注番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACCEPTANORDERNORF
            //売上行番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESROWNORF
            //売上日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESDATERF
            //共通通番
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_COMMONSEQNORF
            //売上明細通番
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESSLIPDTLNUMRF
            //受注ステータス（元）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ACPTANODRSTATUSSRCRF
            //売上明細通番（元）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESSLIPDTLNUMSRCRF
            //仕入形式（同時）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SUPPLIERFORMALSYNCRF
            //仕入明細通番（同時）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESSLIPCDDTLRF
            //在庫管理有無区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_STOCKMNGEXISTCDRF
            //納品完了予定日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_DELIGDSCMPLTDUEDATERF
            //商品属性
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSKINDCODERF
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSMAKERCDRF
            //メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_MAKERNAMERF
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNORF
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMERF
            //商品名略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSSHORTNAMERF
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_BLGOODSCODERF
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_BLGOODSFULLNAMERF
            //自社分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_ENTERPRISEGANRECODERF
            //自社分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_ENTERPRISEGANRENAMERF
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSECODERF
            //倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSENAMERF
            //倉庫棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_WAREHOUSESHELFNORF
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESORDERDIVCDRF
            //オープン価格区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_OPENPRICEDIVRF
            //商品掛率ランク
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSRATERANKRF
            //得意先掛率グループコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CUSTRATEGRPCODERF
            //定価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICERATERF
            //定価（税込，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXINCFLRF
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_LISTPRICETAXEXCFLRF
            //定価変更区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_LISTPRICECHNGCDRF
            //売価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESRATERF
            //売上単価（税込，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNPRCTAXINCFLRF
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNPRCTAXEXCFLRF
            //原価率
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_COSTRATERF
            //原価単価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SALESUNITCOSTRF
            //出荷数
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_SHIPMENTCNTRF
            //受注数量
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_ACCEPTANORDERCNTRF
            //受注調整数
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_ACPTANODRADJUSTCNTRF
            //受注残数
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_ACPTANODRREMAINCNTRF
            //残数更新日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_REMAINCNTUPDDATERF
            //売上金額（税込み）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXINCRF
            //売上金額（税抜き）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_SALESMONEYTAXEXCRF
            //原価
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_COSTRF
            //粗利チェック区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GRSPROFITCHKDIVRF
            //売上商品区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESGOODSCDRF
            //課税区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_TAXATIONDIVCDRF
            //相手先伝票番号（明細）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PARTYSLIPNUMDTLRF
            //明細備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_DTLNOTERF
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SUPPLIERCDRF
            //仕入先略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SUPPLIERSNMRF
            //発注番号
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_ORDERNUMBERRF
            //伝票メモ１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO1RF
            //伝票メモ２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO2RF
            //伝票メモ３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SLIPMEMO3RF
            //社内メモ１
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO1RF
            //社内メモ２
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO2RF
            //社内メモ３
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_INSIDEMEMO3RF
            //変更前定価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFLISTPRICERF
            //変更前売価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFSALESUNITPRICERF
            //変更前原価
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_BFUNITCOSTRF
            //一式明細番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CMPLTSALESROWNORF
            //メーカーコード（一式）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_CMPLTGOODSMAKERCDRF
            //メーカー名称（一式）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTMAKERNAMERF
            //商品名称（一式）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTGOODSNAMERF
            //数量（一式）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSHIPMENTCNTRF
            //売上単価（一式）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSALESUNPRCFLRF
            //売上金額（一式）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_CMPLTSALESMONEYRF
            //原価単価（一式）
            serInfo.MemberInfo.Add( typeof( Double ) ); //SALESDETAILRF_CMPLTSALESUNITCOSTRF
            //原価金額（一式）
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SALESDETAILRF_CMPLTCOSTRF
            //相手先伝票番号（一式）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTPARTYSALSLNUMRF
            //一式備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_CMPLTNOTERF
            //車両管理番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_CARMNGNORF
            //車輌管理コード
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_CARMNGCODERF
            //陸運事務所番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_NUMBERPLATE1CODERF
            //陸運事務局名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE1NAMERF
            //車両登録番号（種別）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE2RF
            //車両登録番号（カナ）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_NUMBERPLATE3RF
            //車両登録番号（プレート番号）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_NUMBERPLATE4RF
            //初年度
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_FIRSTENTRYDATERF
            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MAKERCODERF
            //メーカー全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MAKERFULLNAMERF
            //車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELCODERF
            //車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELSUBCODERF
            //車種全角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELFULLNAMERF
            //排ガス記号
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_EXHAUSTGASSIGNRF
            //シリーズ型式
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_SERIESMODELRF
            //型式（類別記号）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_CATEGORYSIGNMODELRF
            //型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FULLMODELRF
            //型式指定番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MODELDESIGNATIONNORF
            //類別番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_CATEGORYNORF
            //車台型式
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FRAMEMODELRF
            //車台番号
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_FRAMENORF
            //車台番号（検索用）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_SEARCHFRAMENORF
            //エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_ENGINEMODELNMRF
            //関連型式
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_RELEVANCEMODELRF
            //サブ車名コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_SUBCARNMCDRF
            //型式グレード略称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELGRADESNAMERF
            //カラーコード
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_COLORCODERF
            //カラー名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_COLORNAME1RF
            //トリムコード
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_TRIMCODERF
            //トリム名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_TRIMNAMERF
            //車両走行距離
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ACCEPTODRCARRF_MILEAGERF
            //部品メーカー略称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKGDS_MAKERSHORTNAMERF
            //部品メーカーカナ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKGDS_MAKERKANANAMERF
            //ユーザー検索部品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MAKGDS_GOODSMAKERCDRF
            //一式メーカー略称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKCMP_MAKERSHORTNAMERF
            //一式メーカーカナ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKCMP_MAKERKANANAMERF
            //ユーザー検索一式メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MAKCMP_GOODSMAKERCDRF
            //商品名称カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNAMEKANARF
            //JANコード
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_JANRF
            //商品掛率ランク
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSRATERANKRF
            //ハイフン無商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNONONEHYPHENRF
            //商品備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNOTE1RF
            //商品備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSNOTE2RF
            //商品規格・特記事項
            serInfo.MemberInfo.Add( typeof( string ) ); //GOODSURF_GOODSSPECIALNOTERF
            //出荷可能数
            serInfo.MemberInfo.Add( typeof( Double ) ); //STOCKRF_SHIPMENTPOSCNTRF
            //重複棚番１
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_DUPLICATIONSHELFNO1RF
            //重複棚番２
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_DUPLICATIONSHELFNO2RF
            //部品管理区分１
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_PARTSMANAGEMENTDIVIDE1RF
            //部品管理区分２
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_PARTSMANAGEMENTDIVIDE2RF
            //在庫備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_STOCKNOTE1RF
            //在庫備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //STOCKRF_STOCKNOTE2RF
            //倉庫備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //WAREHOUSERF_WAREHOUSENOTE1RF
            //得意先掛率ＧＲ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //USRCSG_GUIDENAMERF
            //ユーザー検索仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SUPPLIERRF_SUPPLIERCDRF
            //仕入先名1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNM1RF
            //仕入先名2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNM2RF
            //仕入先敬称
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPHONORIFICTITLERF
            //仕入先カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERKANARF
            //純正区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SUPPLIERRF_PURECODERF
            //仕入先備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE1RF
            //仕入先備考2
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE2RF
            //仕入先備考3
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE3RF
            //仕入先備考4
            serInfo.MemberInfo.Add( typeof( string ) ); //SUPPLIERRF_SUPPLIERNOTE4RF
            //ユーザー検索BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGOODSCDURF_BLGOODSCODERF
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGOODSCDURF_BLGOODSHALFNAMERF
            //在庫管理有無区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_STOCKMNGEXISTNMRF
            //商品属性名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_GOODSKINDNAMERF
            //売上在庫取寄せ区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESORDERDIVNMRF
            //オープン価格区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_OPENPRICEDIVNMRF
            //粗利チェック区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_GRSPROFITCHKDIVNMRF
            //売上商品区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESGOODSNMRF
            //課税区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_TAXATIONDIVNMRF
            //純正区分
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_PURECODENMRF
            //納品完了予定日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFYRF
            //納品完了予定日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFSRF
            //納品完了予定日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFWRF
            //納品完了予定日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFMRF
            //納品完了予定日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_DELIGDSCMPLTDUEDATEFDRF
            //納品完了予定日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFGRF
            //納品完了予定日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFRRF
            //納品完了予定日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLSRF
            //納品完了予定日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLPRF
            //納品完了予定日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLYRF
            //納品完了予定日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLMRF
            //納品完了予定日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_DELIGDSCMPLTDUEDATEFLDRF
            //初年度西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFYRF
            //初年度西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFSRF
            //初年度和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFWRF
            //初年度月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DADD_FIRSTENTRYDATEFMRF
            //初年度元号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFGRF
            //初年度略号
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFRRF
            //初年度リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLSRF
            //初年度リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLPRF
            //初年度リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLYRF
            //初年度リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_FIRSTENTRYDATEFLMRF
            //在庫取寄区分マーク
            serInfo.MemberInfo.Add( typeof( string ) ); //DADD_SALESORDERDIVMARKRF
            //メーカー半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MAKERHALFNAMERF
            //車種半角名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ACCEPTODRCARRF_MODELHALFNAMERF
            //BL商品コード（印刷）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTBLGOODSCODERF
            //BL商品コード名称（印刷）
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTBLGOODSNAMERF
            //印刷用品番
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTGOODSNORF
            //印刷用メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_PRTMAKERCODERF
            //印刷用メーカー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_PRTMAKERNAMERF
            //印刷用メーカーカナ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MAKPRT_MAKERKANANAMERF
            //商品大分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSLGROUPRF
            //商品大分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSLGROUPNAMERF
            //商品中分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_GOODSMGROUPRF
            //商品中分類名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSMGROUPNAMERF
            //BLグループコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_BLGROUPCODERF
            //BLグループコード名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_BLGROUPNAMERF
            //販売区分コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SALESDETAILRF_SALESCODERF
            //販売区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_SALESCDNMRF
            //商品名称カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //SALESDETAILRF_GOODSNAMEKANARF
            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //AB商品コード
            serInfo.MemberInfo.Add(typeof(string)); //SAndEGoodsCdChgRF_ABGoodsCode
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD 2011.07.19  ------ >>>>>>
            //自動回答区分(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //SALESDETAILRF_AUTOANSWERDIVSCMRF
            // --- ADD 2011.07.19  ------ <<<<<<
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            //受発注種別
            serInfo.MemberInfo.Add(typeof(Int16)); //SALESDETAILRF_ACCEPTORORDERKINDRF
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //SALESDETAILRF_INQUIRYNUMBERRF
            //問合せ行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SALESDETAILRF_INQROWNUMBERRF
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end


            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePSalesDetailWork )
            {
                FrePSalesDetailWork temp = (FrePSalesDetailWork)graph;

                SetFrePSalesDetailWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePSalesDetailWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePSalesDetailWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePSalesDetailWork temp in lst )
                {
                    SetFrePSalesDetailWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePSalesDetailWorkメンバ数(publicプロパティ数)
        /// </summary>
        // private const int currentMemberCount = 189; // DEL 劉洋 2009.07.24
        // private const int currentMemberCount = 190; // ADD 劉洋 2009.07.24 // DEL 2011.07.19
        private const int currentMemberCount = 191; // ADD 2011.07.19

        /// <summary>
        ///  FrePSalesDetailWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesDetailWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFrePSalesDetailWork( System.IO.BinaryWriter writer, FrePSalesDetailWork temp )
        {
            //受注ステータス
            writer.Write( temp.SALESDETAILRF_ACPTANODRSTATUSRF );
            //売上伝票番号
            writer.Write( temp.SALESDETAILRF_SALESSLIPNUMRF );
            //受注番号
            writer.Write( temp.SALESDETAILRF_ACCEPTANORDERNORF );
            //売上行番号
            writer.Write( temp.SALESDETAILRF_SALESROWNORF );
            //売上日付
            writer.Write( temp.SALESDETAILRF_SALESDATERF );
            //共通通番
            writer.Write( temp.SALESDETAILRF_COMMONSEQNORF );
            //売上明細通番
            writer.Write( temp.SALESDETAILRF_SALESSLIPDTLNUMRF );
            //受注ステータス（元）
            writer.Write( temp.SALESDETAILRF_ACPTANODRSTATUSSRCRF );
            //売上明細通番（元）
            writer.Write( temp.SALESDETAILRF_SALESSLIPDTLNUMSRCRF );
            //仕入形式（同時）
            writer.Write( temp.SALESDETAILRF_SUPPLIERFORMALSYNCRF );
            //仕入明細通番（同時）
            writer.Write( temp.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF );
            //売上伝票区分（明細）
            writer.Write( temp.SALESDETAILRF_SALESSLIPCDDTLRF );
            //在庫管理有無区分
            writer.Write( temp.SALESDETAILRF_STOCKMNGEXISTCDRF );
            //納品完了予定日
            writer.Write( temp.SALESDETAILRF_DELIGDSCMPLTDUEDATERF );
            //商品属性
            writer.Write( temp.SALESDETAILRF_GOODSKINDCODERF );
            //商品メーカーコード
            writer.Write( temp.SALESDETAILRF_GOODSMAKERCDRF );
            //メーカー名称
            writer.Write( temp.SALESDETAILRF_MAKERNAMERF );
            //商品番号
            writer.Write( temp.SALESDETAILRF_GOODSNORF );
            //商品名称
            writer.Write( temp.SALESDETAILRF_GOODSNAMERF );
            //商品名略称
            writer.Write( temp.SALESDETAILRF_GOODSSHORTNAMERF );
            //BL商品コード
            writer.Write( temp.SALESDETAILRF_BLGOODSCODERF );
            //BL商品コード名称（全角）
            writer.Write( temp.SALESDETAILRF_BLGOODSFULLNAMERF );
            //自社分類コード
            writer.Write( temp.SALESDETAILRF_ENTERPRISEGANRECODERF );
            //自社分類名称
            writer.Write( temp.SALESDETAILRF_ENTERPRISEGANRENAMERF );
            //倉庫コード
            writer.Write( temp.SALESDETAILRF_WAREHOUSECODERF );
            //倉庫名称
            writer.Write( temp.SALESDETAILRF_WAREHOUSENAMERF );
            //倉庫棚番
            writer.Write( temp.SALESDETAILRF_WAREHOUSESHELFNORF );
            //売上在庫取寄せ区分
            writer.Write( temp.SALESDETAILRF_SALESORDERDIVCDRF );
            //オープン価格区分
            writer.Write( temp.SALESDETAILRF_OPENPRICEDIVRF );
            //商品掛率ランク
            writer.Write( temp.SALESDETAILRF_GOODSRATERANKRF );
            //得意先掛率グループコード
            writer.Write( temp.SALESDETAILRF_CUSTRATEGRPCODERF );
            //定価率
            writer.Write( temp.SALESDETAILRF_LISTPRICERATERF );
            //定価（税込，浮動）
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXINCFLRF );
            //定価（税抜，浮動）
            writer.Write( temp.SALESDETAILRF_LISTPRICETAXEXCFLRF );
            //定価変更区分
            writer.Write( temp.SALESDETAILRF_LISTPRICECHNGCDRF );
            //売価率
            writer.Write( temp.SALESDETAILRF_SALESRATERF );
            //売上単価（税込，浮動）
            writer.Write( temp.SALESDETAILRF_SALESUNPRCTAXINCFLRF );
            //売上単価（税抜，浮動）
            writer.Write( temp.SALESDETAILRF_SALESUNPRCTAXEXCFLRF );
            //原価率
            writer.Write( temp.SALESDETAILRF_COSTRATERF );
            //原価単価
            writer.Write( temp.SALESDETAILRF_SALESUNITCOSTRF );
            //出荷数
            writer.Write( temp.SALESDETAILRF_SHIPMENTCNTRF );
            //受注数量
            writer.Write( temp.SALESDETAILRF_ACCEPTANORDERCNTRF );
            //受注調整数
            writer.Write( temp.SALESDETAILRF_ACPTANODRADJUSTCNTRF );
            //受注残数
            writer.Write( temp.SALESDETAILRF_ACPTANODRREMAINCNTRF );
            //残数更新日
            writer.Write( temp.SALESDETAILRF_REMAINCNTUPDDATERF );
            //売上金額（税込み）
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXINCRF );
            //売上金額（税抜き）
            writer.Write( temp.SALESDETAILRF_SALESMONEYTAXEXCRF );
            //原価
            writer.Write( temp.SALESDETAILRF_COSTRF );
            //粗利チェック区分
            writer.Write( temp.SALESDETAILRF_GRSPROFITCHKDIVRF );
            //売上商品区分
            writer.Write( temp.SALESDETAILRF_SALESGOODSCDRF );
            //課税区分
            writer.Write( temp.SALESDETAILRF_TAXATIONDIVCDRF );
            //相手先伝票番号（明細）
            writer.Write( temp.SALESDETAILRF_PARTYSLIPNUMDTLRF );
            //明細備考
            writer.Write( temp.SALESDETAILRF_DTLNOTERF );
            //仕入先コード
            writer.Write( temp.SALESDETAILRF_SUPPLIERCDRF );
            //仕入先略称
            writer.Write( temp.SALESDETAILRF_SUPPLIERSNMRF );
            //発注番号
            writer.Write( temp.SALESDETAILRF_ORDERNUMBERRF );
            //伝票メモ１
            writer.Write( temp.SALESDETAILRF_SLIPMEMO1RF );
            //伝票メモ２
            writer.Write( temp.SALESDETAILRF_SLIPMEMO2RF );
            //伝票メモ３
            writer.Write( temp.SALESDETAILRF_SLIPMEMO3RF );
            //社内メモ１
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO1RF );
            //社内メモ２
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO2RF );
            //社内メモ３
            writer.Write( temp.SALESDETAILRF_INSIDEMEMO3RF );
            //変更前定価
            writer.Write( temp.SALESDETAILRF_BFLISTPRICERF );
            //変更前売価
            writer.Write( temp.SALESDETAILRF_BFSALESUNITPRICERF );
            //変更前原価
            writer.Write( temp.SALESDETAILRF_BFUNITCOSTRF );
            //一式明細番号
            writer.Write( temp.SALESDETAILRF_CMPLTSALESROWNORF );
            //メーカーコード（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTGOODSMAKERCDRF );
            //メーカー名称（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTMAKERNAMERF );
            //商品名称（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTGOODSNAMERF );
            //数量（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSHIPMENTCNTRF );
            //売上単価（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSALESUNPRCFLRF );
            //売上金額（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSALESMONEYRF );
            //原価単価（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTSALESUNITCOSTRF );
            //原価金額（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTCOSTRF );
            //相手先伝票番号（一式）
            writer.Write( temp.SALESDETAILRF_CMPLTPARTYSALSLNUMRF );
            //一式備考
            writer.Write( temp.SALESDETAILRF_CMPLTNOTERF );
            //車両管理番号
            writer.Write( temp.ACCEPTODRCARRF_CARMNGNORF );
            //車輌管理コード
            writer.Write( temp.ACCEPTODRCARRF_CARMNGCODERF );
            //陸運事務所番号
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE1CODERF );
            //陸運事務局名称
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE1NAMERF );
            //車両登録番号（種別）
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE2RF );
            //車両登録番号（カナ）
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE3RF );
            //車両登録番号（プレート番号）
            writer.Write( temp.ACCEPTODRCARRF_NUMBERPLATE4RF );
            //初年度
            writer.Write( temp.ACCEPTODRCARRF_FIRSTENTRYDATERF );
            //メーカーコード
            writer.Write( temp.ACCEPTODRCARRF_MAKERCODERF );
            //メーカー全角名称
            writer.Write( temp.ACCEPTODRCARRF_MAKERFULLNAMERF );
            //車種コード
            writer.Write( temp.ACCEPTODRCARRF_MODELCODERF );
            //車種サブコード
            writer.Write( temp.ACCEPTODRCARRF_MODELSUBCODERF );
            //車種全角名称
            writer.Write( temp.ACCEPTODRCARRF_MODELFULLNAMERF );
            //排ガス記号
            writer.Write( temp.ACCEPTODRCARRF_EXHAUSTGASSIGNRF );
            //シリーズ型式
            writer.Write( temp.ACCEPTODRCARRF_SERIESMODELRF );
            //型式（類別記号）
            writer.Write( temp.ACCEPTODRCARRF_CATEGORYSIGNMODELRF );
            //型式（フル型）
            writer.Write( temp.ACCEPTODRCARRF_FULLMODELRF );
            //型式指定番号
            writer.Write( temp.ACCEPTODRCARRF_MODELDESIGNATIONNORF );
            //類別番号
            writer.Write( temp.ACCEPTODRCARRF_CATEGORYNORF );
            //車台型式
            writer.Write( temp.ACCEPTODRCARRF_FRAMEMODELRF );
            //車台番号
            writer.Write( temp.ACCEPTODRCARRF_FRAMENORF );
            //車台番号（検索用）
            writer.Write( temp.ACCEPTODRCARRF_SEARCHFRAMENORF );
            //エンジン型式名称
            writer.Write( temp.ACCEPTODRCARRF_ENGINEMODELNMRF );
            //関連型式
            writer.Write( temp.ACCEPTODRCARRF_RELEVANCEMODELRF );
            //サブ車名コード
            writer.Write( temp.ACCEPTODRCARRF_SUBCARNMCDRF );
            //型式グレード略称
            writer.Write( temp.ACCEPTODRCARRF_MODELGRADESNAMERF );
            //カラーコード
            writer.Write( temp.ACCEPTODRCARRF_COLORCODERF );
            //カラー名称1
            writer.Write( temp.ACCEPTODRCARRF_COLORNAME1RF );
            //トリムコード
            writer.Write( temp.ACCEPTODRCARRF_TRIMCODERF );
            //トリム名称
            writer.Write( temp.ACCEPTODRCARRF_TRIMNAMERF );
            //車両走行距離
            writer.Write( temp.ACCEPTODRCARRF_MILEAGERF );
            //部品メーカー略称
            writer.Write( temp.MAKGDS_MAKERSHORTNAMERF );
            //部品メーカーカナ名称
            writer.Write( temp.MAKGDS_MAKERKANANAMERF );
            //ユーザー検索部品メーカーコード
            writer.Write( temp.MAKGDS_GOODSMAKERCDRF );
            //一式メーカー略称
            writer.Write( temp.MAKCMP_MAKERSHORTNAMERF );
            //一式メーカーカナ名称
            writer.Write( temp.MAKCMP_MAKERKANANAMERF );
            //ユーザー検索一式メーカーコード
            writer.Write( temp.MAKCMP_GOODSMAKERCDRF );
            //商品名称カナ
            writer.Write( temp.GOODSURF_GOODSNAMEKANARF );
            //JANコード
            writer.Write( temp.GOODSURF_JANRF );
            //商品掛率ランク
            writer.Write( temp.GOODSURF_GOODSRATERANKRF );
            //ハイフン無商品番号
            writer.Write( temp.GOODSURF_GOODSNONONEHYPHENRF );
            //商品備考１
            writer.Write( temp.GOODSURF_GOODSNOTE1RF );
            //商品備考２
            writer.Write( temp.GOODSURF_GOODSNOTE2RF );
            //商品規格・特記事項
            writer.Write( temp.GOODSURF_GOODSSPECIALNOTERF );
            //出荷可能数
            writer.Write( temp.STOCKRF_SHIPMENTPOSCNTRF );
            //重複棚番１
            writer.Write( temp.STOCKRF_DUPLICATIONSHELFNO1RF );
            //重複棚番２
            writer.Write( temp.STOCKRF_DUPLICATIONSHELFNO2RF );
            //部品管理区分１
            writer.Write( temp.STOCKRF_PARTSMANAGEMENTDIVIDE1RF );
            //部品管理区分２
            writer.Write( temp.STOCKRF_PARTSMANAGEMENTDIVIDE2RF );
            //在庫備考１
            writer.Write( temp.STOCKRF_STOCKNOTE1RF );
            //在庫備考２
            writer.Write( temp.STOCKRF_STOCKNOTE2RF );
            //倉庫備考1
            writer.Write( temp.WAREHOUSERF_WAREHOUSENOTE1RF );
            //得意先掛率ＧＲ名称
            writer.Write( temp.USRCSG_GUIDENAMERF );
            //ユーザー検索仕入先コード
            writer.Write( temp.SUPPLIERRF_SUPPLIERCDRF );
            //仕入先名1
            writer.Write( temp.SUPPLIERRF_SUPPLIERNM1RF );
            //仕入先名2
            writer.Write( temp.SUPPLIERRF_SUPPLIERNM2RF );
            //仕入先敬称
            writer.Write( temp.SUPPLIERRF_SUPPHONORIFICTITLERF );
            //仕入先カナ
            writer.Write( temp.SUPPLIERRF_SUPPLIERKANARF );
            //純正区分
            writer.Write( temp.SUPPLIERRF_PURECODERF );
            //仕入先備考1
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE1RF );
            //仕入先備考2
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE2RF );
            //仕入先備考3
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE3RF );
            //仕入先備考4
            writer.Write( temp.SUPPLIERRF_SUPPLIERNOTE4RF );
            //ユーザー検索BL商品コード
            writer.Write( temp.BLGOODSCDURF_BLGOODSCODERF );
            //BL商品コード名称（半角）
            writer.Write( temp.BLGOODSCDURF_BLGOODSHALFNAMERF );
            //在庫管理有無区分名称
            writer.Write( temp.DADD_STOCKMNGEXISTNMRF );
            //商品属性名称
            writer.Write( temp.DADD_GOODSKINDNAMERF );
            //売上在庫取寄せ区分名称
            writer.Write( temp.DADD_SALESORDERDIVNMRF );
            //オープン価格区分名称
            writer.Write( temp.DADD_OPENPRICEDIVNMRF );
            //粗利チェック区分名称
            writer.Write( temp.DADD_GRSPROFITCHKDIVNMRF );
            //売上商品区分名称
            writer.Write( temp.DADD_SALESGOODSNMRF );
            //課税区分名称
            writer.Write( temp.DADD_TAXATIONDIVNMRF );
            //純正区分
            writer.Write( temp.DADD_PURECODENMRF );
            //納品完了予定日西暦年
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFYRF );
            //納品完了予定日西暦年略
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFSRF );
            //納品完了予定日和暦年
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFWRF );
            //納品完了予定日月
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFMRF );
            //納品完了予定日日
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFDRF );
            //納品完了予定日元号
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFGRF );
            //納品完了予定日略号
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFRRF );
            //納品完了予定日リテラル(/)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLSRF );
            //納品完了予定日リテラル(.)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLPRF );
            //納品完了予定日リテラル(年)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLYRF );
            //納品完了予定日リテラル(月)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLMRF );
            //納品完了予定日リテラル(日)
            writer.Write( temp.DADD_DELIGDSCMPLTDUEDATEFLDRF );
            //初年度西暦年
            writer.Write( temp.DADD_FIRSTENTRYDATEFYRF );
            //初年度西暦年略
            writer.Write( temp.DADD_FIRSTENTRYDATEFSRF );
            //初年度和暦年
            writer.Write( temp.DADD_FIRSTENTRYDATEFWRF );
            //初年度月
            writer.Write( temp.DADD_FIRSTENTRYDATEFMRF );
            //初年度元号
            writer.Write( temp.DADD_FIRSTENTRYDATEFGRF );
            //初年度略号
            writer.Write( temp.DADD_FIRSTENTRYDATEFRRF );
            //初年度リテラル(/)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLSRF );
            //初年度リテラル(.)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLPRF );
            //初年度リテラル(年)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLYRF );
            //初年度リテラル(月)
            writer.Write( temp.DADD_FIRSTENTRYDATEFLMRF );
            //在庫取寄区分マーク
            writer.Write( temp.DADD_SALESORDERDIVMARKRF );
            //メーカー半角名称
            writer.Write( temp.ACCEPTODRCARRF_MAKERHALFNAMERF );
            //車種半角名称
            writer.Write( temp.ACCEPTODRCARRF_MODELHALFNAMERF );
            //BL商品コード（印刷）
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSCODERF );
            //BL商品コード名称（印刷）
            writer.Write( temp.SALESDETAILRF_PRTBLGOODSNAMERF );
            //印刷用品番
            writer.Write( temp.SALESDETAILRF_PRTGOODSNORF );
            //印刷用メーカーコード
            writer.Write( temp.SALESDETAILRF_PRTMAKERCODERF );
            //印刷用メーカー名称
            writer.Write( temp.SALESDETAILRF_PRTMAKERNAMERF );
            //印刷用メーカーカナ名称
            writer.Write( temp.MAKPRT_MAKERKANANAMERF );
            //商品大分類コード
            writer.Write( temp.SALESDETAILRF_GOODSLGROUPRF );
            //商品大分類名称
            writer.Write( temp.SALESDETAILRF_GOODSLGROUPNAMERF );
            //商品中分類コード
            writer.Write( temp.SALESDETAILRF_GOODSMGROUPRF );
            //商品中分類名称
            writer.Write( temp.SALESDETAILRF_GOODSMGROUPNAMERF );
            //BLグループコード
            writer.Write( temp.SALESDETAILRF_BLGROUPCODERF );
            //BLグループコード名称
            writer.Write( temp.SALESDETAILRF_BLGROUPNAMERF );
            //販売区分コード
            writer.Write( temp.SALESDETAILRF_SALESCODERF );
            //販売区分名称
            writer.Write( temp.SALESDETAILRF_SALESCDNMRF );
            //商品名称カナ
            writer.Write( temp.SALESDETAILRF_GOODSNAMEKANARF );
            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //AB商品コード
            writer.Write(temp.SANDEGOODSCDCHGRF_ABGOODSCODE);
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD 2011.07.19 ------ >>>>>>
            //自動回答区分(SCM)
            writer.Write(temp.SALESDETAILRF_AUTOANSWERDIVSCMRF);
            // --- ADD 2011.07.19 ------ <<<<<<
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            //受発注種別
            writer.Write(temp.SALESDETAILRF_ACCEPTORORDERKINDRF);
            //問合せ番号
            writer.Write(temp.SALESDETAILRF_INQUIRYNUMBERRF);
            //問合せ行番号
            writer.Write(temp.SALESDETAILRF_INQROWNUMBERRF);
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        }

        /// <summary>
        ///  FrePSalesDetailWorkインスタンス取得
        /// </summary>
        /// <returns>FrePSalesDetailWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesDetailWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FrePSalesDetailWork GetFrePSalesDetailWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FrePSalesDetailWork temp = new FrePSalesDetailWork();

            //受注ステータス
            temp.SALESDETAILRF_ACPTANODRSTATUSRF = reader.ReadInt32();
            //売上伝票番号
            temp.SALESDETAILRF_SALESSLIPNUMRF = reader.ReadString();
            //受注番号
            temp.SALESDETAILRF_ACCEPTANORDERNORF = reader.ReadInt32();
            //売上行番号
            temp.SALESDETAILRF_SALESROWNORF = reader.ReadInt32();
            //売上日付
            temp.SALESDETAILRF_SALESDATERF = reader.ReadInt32();
            //共通通番
            temp.SALESDETAILRF_COMMONSEQNORF = reader.ReadInt64();
            //売上明細通番
            temp.SALESDETAILRF_SALESSLIPDTLNUMRF = reader.ReadInt64();
            //受注ステータス（元）
            temp.SALESDETAILRF_ACPTANODRSTATUSSRCRF = reader.ReadInt32();
            //売上明細通番（元）
            temp.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = reader.ReadInt64();
            //仕入形式（同時）
            temp.SALESDETAILRF_SUPPLIERFORMALSYNCRF = reader.ReadInt32();
            //仕入明細通番（同時）
            temp.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = reader.ReadInt64();
            //売上伝票区分（明細）
            temp.SALESDETAILRF_SALESSLIPCDDTLRF = reader.ReadInt32();
            //在庫管理有無区分
            temp.SALESDETAILRF_STOCKMNGEXISTCDRF = reader.ReadInt32();
            //納品完了予定日
            temp.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = reader.ReadInt32();
            //商品属性
            temp.SALESDETAILRF_GOODSKINDCODERF = reader.ReadInt32();
            //商品メーカーコード
            temp.SALESDETAILRF_GOODSMAKERCDRF = reader.ReadInt32();
            //メーカー名称
            temp.SALESDETAILRF_MAKERNAMERF = reader.ReadString();
            //商品番号
            temp.SALESDETAILRF_GOODSNORF = reader.ReadString();
            //商品名称
            temp.SALESDETAILRF_GOODSNAMERF = reader.ReadString();
            //商品名略称
            temp.SALESDETAILRF_GOODSSHORTNAMERF = reader.ReadString();
            //BL商品コード
            temp.SALESDETAILRF_BLGOODSCODERF = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.SALESDETAILRF_BLGOODSFULLNAMERF = reader.ReadString();
            //自社分類コード
            temp.SALESDETAILRF_ENTERPRISEGANRECODERF = reader.ReadInt32();
            //自社分類名称
            temp.SALESDETAILRF_ENTERPRISEGANRENAMERF = reader.ReadString();
            //倉庫コード
            temp.SALESDETAILRF_WAREHOUSECODERF = reader.ReadString();
            //倉庫名称
            temp.SALESDETAILRF_WAREHOUSENAMERF = reader.ReadString();
            //倉庫棚番
            temp.SALESDETAILRF_WAREHOUSESHELFNORF = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SALESDETAILRF_SALESORDERDIVCDRF = reader.ReadInt32();
            //オープン価格区分
            temp.SALESDETAILRF_OPENPRICEDIVRF = reader.ReadInt32();
            //商品掛率ランク
            temp.SALESDETAILRF_GOODSRATERANKRF = reader.ReadString();
            //得意先掛率グループコード
            temp.SALESDETAILRF_CUSTRATEGRPCODERF = reader.ReadInt32();
            //定価率
            temp.SALESDETAILRF_LISTPRICERATERF = reader.ReadDouble();
            //定価（税込，浮動）
            temp.SALESDETAILRF_LISTPRICETAXINCFLRF = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.SALESDETAILRF_LISTPRICETAXEXCFLRF = reader.ReadDouble();
            //定価変更区分
            temp.SALESDETAILRF_LISTPRICECHNGCDRF = reader.ReadInt32();
            //売価率
            temp.SALESDETAILRF_SALESRATERF = reader.ReadDouble();
            //売上単価（税込，浮動）
            temp.SALESDETAILRF_SALESUNPRCTAXINCFLRF = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = reader.ReadDouble();
            //原価率
            temp.SALESDETAILRF_COSTRATERF = reader.ReadDouble();
            //原価単価
            temp.SALESDETAILRF_SALESUNITCOSTRF = reader.ReadDouble();
            //出荷数
            temp.SALESDETAILRF_SHIPMENTCNTRF = reader.ReadDouble();
            //受注数量
            temp.SALESDETAILRF_ACCEPTANORDERCNTRF = reader.ReadDouble();
            //受注調整数
            temp.SALESDETAILRF_ACPTANODRADJUSTCNTRF = reader.ReadDouble();
            //受注残数
            temp.SALESDETAILRF_ACPTANODRREMAINCNTRF = reader.ReadDouble();
            //残数更新日
            temp.SALESDETAILRF_REMAINCNTUPDDATERF = reader.ReadInt32();
            //売上金額（税込み）
            temp.SALESDETAILRF_SALESMONEYTAXINCRF = reader.ReadInt64();
            //売上金額（税抜き）
            temp.SALESDETAILRF_SALESMONEYTAXEXCRF = reader.ReadInt64();
            //原価
            temp.SALESDETAILRF_COSTRF = reader.ReadInt64();
            //粗利チェック区分
            temp.SALESDETAILRF_GRSPROFITCHKDIVRF = reader.ReadInt32();
            //売上商品区分
            temp.SALESDETAILRF_SALESGOODSCDRF = reader.ReadInt32();
            //課税区分
            temp.SALESDETAILRF_TAXATIONDIVCDRF = reader.ReadInt32();
            //相手先伝票番号（明細）
            temp.SALESDETAILRF_PARTYSLIPNUMDTLRF = reader.ReadString();
            //明細備考
            temp.SALESDETAILRF_DTLNOTERF = reader.ReadString();
            //仕入先コード
            temp.SALESDETAILRF_SUPPLIERCDRF = reader.ReadInt32();
            //仕入先略称
            temp.SALESDETAILRF_SUPPLIERSNMRF = reader.ReadString();
            //発注番号
            temp.SALESDETAILRF_ORDERNUMBERRF = reader.ReadString();
            //伝票メモ１
            temp.SALESDETAILRF_SLIPMEMO1RF = reader.ReadString();
            //伝票メモ２
            temp.SALESDETAILRF_SLIPMEMO2RF = reader.ReadString();
            //伝票メモ３
            temp.SALESDETAILRF_SLIPMEMO3RF = reader.ReadString();
            //社内メモ１
            temp.SALESDETAILRF_INSIDEMEMO1RF = reader.ReadString();
            //社内メモ２
            temp.SALESDETAILRF_INSIDEMEMO2RF = reader.ReadString();
            //社内メモ３
            temp.SALESDETAILRF_INSIDEMEMO3RF = reader.ReadString();
            //変更前定価
            temp.SALESDETAILRF_BFLISTPRICERF = reader.ReadDouble();
            //変更前売価
            temp.SALESDETAILRF_BFSALESUNITPRICERF = reader.ReadDouble();
            //変更前原価
            temp.SALESDETAILRF_BFUNITCOSTRF = reader.ReadDouble();
            //一式明細番号
            temp.SALESDETAILRF_CMPLTSALESROWNORF = reader.ReadInt32();
            //メーカーコード（一式）
            temp.SALESDETAILRF_CMPLTGOODSMAKERCDRF = reader.ReadInt32();
            //メーカー名称（一式）
            temp.SALESDETAILRF_CMPLTMAKERNAMERF = reader.ReadString();
            //商品名称（一式）
            temp.SALESDETAILRF_CMPLTGOODSNAMERF = reader.ReadString();
            //数量（一式）
            temp.SALESDETAILRF_CMPLTSHIPMENTCNTRF = reader.ReadDouble();
            //売上単価（一式）
            temp.SALESDETAILRF_CMPLTSALESUNPRCFLRF = reader.ReadDouble();
            //売上金額（一式）
            temp.SALESDETAILRF_CMPLTSALESMONEYRF = reader.ReadInt64();
            //原価単価（一式）
            temp.SALESDETAILRF_CMPLTSALESUNITCOSTRF = reader.ReadDouble();
            //原価金額（一式）
            temp.SALESDETAILRF_CMPLTCOSTRF = reader.ReadInt64();
            //相手先伝票番号（一式）
            temp.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = reader.ReadString();
            //一式備考
            temp.SALESDETAILRF_CMPLTNOTERF = reader.ReadString();
            //車両管理番号
            temp.ACCEPTODRCARRF_CARMNGNORF = reader.ReadInt32();
            //車輌管理コード
            temp.ACCEPTODRCARRF_CARMNGCODERF = reader.ReadString();
            //陸運事務所番号
            temp.ACCEPTODRCARRF_NUMBERPLATE1CODERF = reader.ReadInt32();
            //陸運事務局名称
            temp.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = reader.ReadString();
            //車両登録番号（種別）
            temp.ACCEPTODRCARRF_NUMBERPLATE2RF = reader.ReadString();
            //車両登録番号（カナ）
            temp.ACCEPTODRCARRF_NUMBERPLATE3RF = reader.ReadString();
            //車両登録番号（プレート番号）
            temp.ACCEPTODRCARRF_NUMBERPLATE4RF = reader.ReadInt32();
            //初年度
            temp.ACCEPTODRCARRF_FIRSTENTRYDATERF = reader.ReadInt32();
            //メーカーコード
            temp.ACCEPTODRCARRF_MAKERCODERF = reader.ReadInt32();
            //メーカー全角名称
            temp.ACCEPTODRCARRF_MAKERFULLNAMERF = reader.ReadString();
            //車種コード
            temp.ACCEPTODRCARRF_MODELCODERF = reader.ReadInt32();
            //車種サブコード
            temp.ACCEPTODRCARRF_MODELSUBCODERF = reader.ReadInt32();
            //車種全角名称
            temp.ACCEPTODRCARRF_MODELFULLNAMERF = reader.ReadString();
            //排ガス記号
            temp.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = reader.ReadString();
            //シリーズ型式
            temp.ACCEPTODRCARRF_SERIESMODELRF = reader.ReadString();
            //型式（類別記号）
            temp.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = reader.ReadString();
            //型式（フル型）
            temp.ACCEPTODRCARRF_FULLMODELRF = reader.ReadString();
            //型式指定番号
            temp.ACCEPTODRCARRF_MODELDESIGNATIONNORF = reader.ReadInt32();
            //類別番号
            temp.ACCEPTODRCARRF_CATEGORYNORF = reader.ReadInt32();
            //車台型式
            temp.ACCEPTODRCARRF_FRAMEMODELRF = reader.ReadString();
            //車台番号
            temp.ACCEPTODRCARRF_FRAMENORF = reader.ReadString();
            //車台番号（検索用）
            temp.ACCEPTODRCARRF_SEARCHFRAMENORF = reader.ReadInt32();
            //エンジン型式名称
            temp.ACCEPTODRCARRF_ENGINEMODELNMRF = reader.ReadString();
            //関連型式
            temp.ACCEPTODRCARRF_RELEVANCEMODELRF = reader.ReadString();
            //サブ車名コード
            temp.ACCEPTODRCARRF_SUBCARNMCDRF = reader.ReadInt32();
            //型式グレード略称
            temp.ACCEPTODRCARRF_MODELGRADESNAMERF = reader.ReadString();
            //カラーコード
            temp.ACCEPTODRCARRF_COLORCODERF = reader.ReadString();
            //カラー名称1
            temp.ACCEPTODRCARRF_COLORNAME1RF = reader.ReadString();
            //トリムコード
            temp.ACCEPTODRCARRF_TRIMCODERF = reader.ReadString();
            //トリム名称
            temp.ACCEPTODRCARRF_TRIMNAMERF = reader.ReadString();
            //車両走行距離
            temp.ACCEPTODRCARRF_MILEAGERF = reader.ReadInt32();
            //部品メーカー略称
            temp.MAKGDS_MAKERSHORTNAMERF = reader.ReadString();
            //部品メーカーカナ名称
            temp.MAKGDS_MAKERKANANAMERF = reader.ReadString();
            //ユーザー検索部品メーカーコード
            temp.MAKGDS_GOODSMAKERCDRF = reader.ReadInt32();
            //一式メーカー略称
            temp.MAKCMP_MAKERSHORTNAMERF = reader.ReadString();
            //一式メーカーカナ名称
            temp.MAKCMP_MAKERKANANAMERF = reader.ReadString();
            //ユーザー検索一式メーカーコード
            temp.MAKCMP_GOODSMAKERCDRF = reader.ReadInt32();
            //商品名称カナ
            temp.GOODSURF_GOODSNAMEKANARF = reader.ReadString();
            //JANコード
            temp.GOODSURF_JANRF = reader.ReadString();
            //商品掛率ランク
            temp.GOODSURF_GOODSRATERANKRF = reader.ReadString();
            //ハイフン無商品番号
            temp.GOODSURF_GOODSNONONEHYPHENRF = reader.ReadString();
            //商品備考１
            temp.GOODSURF_GOODSNOTE1RF = reader.ReadString();
            //商品備考２
            temp.GOODSURF_GOODSNOTE2RF = reader.ReadString();
            //商品規格・特記事項
            temp.GOODSURF_GOODSSPECIALNOTERF = reader.ReadString();
            //出荷可能数
            temp.STOCKRF_SHIPMENTPOSCNTRF = reader.ReadDouble();
            //重複棚番１
            temp.STOCKRF_DUPLICATIONSHELFNO1RF = reader.ReadString();
            //重複棚番２
            temp.STOCKRF_DUPLICATIONSHELFNO2RF = reader.ReadString();
            //部品管理区分１
            temp.STOCKRF_PARTSMANAGEMENTDIVIDE1RF = reader.ReadString();
            //部品管理区分２
            temp.STOCKRF_PARTSMANAGEMENTDIVIDE2RF = reader.ReadString();
            //在庫備考１
            temp.STOCKRF_STOCKNOTE1RF = reader.ReadString();
            //在庫備考２
            temp.STOCKRF_STOCKNOTE2RF = reader.ReadString();
            //倉庫備考1
            temp.WAREHOUSERF_WAREHOUSENOTE1RF = reader.ReadString();
            //得意先掛率ＧＲ名称
            temp.USRCSG_GUIDENAMERF = reader.ReadString();
            //ユーザー検索仕入先コード
            temp.SUPPLIERRF_SUPPLIERCDRF = reader.ReadInt32();
            //仕入先名1
            temp.SUPPLIERRF_SUPPLIERNM1RF = reader.ReadString();
            //仕入先名2
            temp.SUPPLIERRF_SUPPLIERNM2RF = reader.ReadString();
            //仕入先敬称
            temp.SUPPLIERRF_SUPPHONORIFICTITLERF = reader.ReadString();
            //仕入先カナ
            temp.SUPPLIERRF_SUPPLIERKANARF = reader.ReadString();
            //純正区分
            temp.SUPPLIERRF_PURECODERF = reader.ReadInt32();
            //仕入先備考1
            temp.SUPPLIERRF_SUPPLIERNOTE1RF = reader.ReadString();
            //仕入先備考2
            temp.SUPPLIERRF_SUPPLIERNOTE2RF = reader.ReadString();
            //仕入先備考3
            temp.SUPPLIERRF_SUPPLIERNOTE3RF = reader.ReadString();
            //仕入先備考4
            temp.SUPPLIERRF_SUPPLIERNOTE4RF = reader.ReadString();
            //ユーザー検索BL商品コード
            temp.BLGOODSCDURF_BLGOODSCODERF = reader.ReadInt32();
            //BL商品コード名称（半角）
            temp.BLGOODSCDURF_BLGOODSHALFNAMERF = reader.ReadString();
            //在庫管理有無区分名称
            temp.DADD_STOCKMNGEXISTNMRF = reader.ReadString();
            //商品属性名称
            temp.DADD_GOODSKINDNAMERF = reader.ReadString();
            //売上在庫取寄せ区分名称
            temp.DADD_SALESORDERDIVNMRF = reader.ReadString();
            //オープン価格区分名称
            temp.DADD_OPENPRICEDIVNMRF = reader.ReadString();
            //粗利チェック区分名称
            temp.DADD_GRSPROFITCHKDIVNMRF = reader.ReadString();
            //売上商品区分名称
            temp.DADD_SALESGOODSNMRF = reader.ReadString();
            //課税区分名称
            temp.DADD_TAXATIONDIVNMRF = reader.ReadString();
            //純正区分
            temp.DADD_PURECODENMRF = reader.ReadString();
            //納品完了予定日西暦年
            temp.DADD_DELIGDSCMPLTDUEDATEFYRF = reader.ReadInt32();
            //納品完了予定日西暦年略
            temp.DADD_DELIGDSCMPLTDUEDATEFSRF = reader.ReadInt32();
            //納品完了予定日和暦年
            temp.DADD_DELIGDSCMPLTDUEDATEFWRF = reader.ReadInt32();
            //納品完了予定日月
            temp.DADD_DELIGDSCMPLTDUEDATEFMRF = reader.ReadInt32();
            //納品完了予定日日
            temp.DADD_DELIGDSCMPLTDUEDATEFDRF = reader.ReadInt32();
            //納品完了予定日元号
            temp.DADD_DELIGDSCMPLTDUEDATEFGRF = reader.ReadString();
            //納品完了予定日略号
            temp.DADD_DELIGDSCMPLTDUEDATEFRRF = reader.ReadString();
            //納品完了予定日リテラル(/)
            temp.DADD_DELIGDSCMPLTDUEDATEFLSRF = reader.ReadString();
            //納品完了予定日リテラル(.)
            temp.DADD_DELIGDSCMPLTDUEDATEFLPRF = reader.ReadString();
            //納品完了予定日リテラル(年)
            temp.DADD_DELIGDSCMPLTDUEDATEFLYRF = reader.ReadString();
            //納品完了予定日リテラル(月)
            temp.DADD_DELIGDSCMPLTDUEDATEFLMRF = reader.ReadString();
            //納品完了予定日リテラル(日)
            temp.DADD_DELIGDSCMPLTDUEDATEFLDRF = reader.ReadString();
            //初年度西暦年
            temp.DADD_FIRSTENTRYDATEFYRF = reader.ReadInt32();
            //初年度西暦年略
            temp.DADD_FIRSTENTRYDATEFSRF = reader.ReadInt32();
            //初年度和暦年
            temp.DADD_FIRSTENTRYDATEFWRF = reader.ReadInt32();
            //初年度月
            temp.DADD_FIRSTENTRYDATEFMRF = reader.ReadInt32();
            //初年度元号
            temp.DADD_FIRSTENTRYDATEFGRF = reader.ReadString();
            //初年度略号
            temp.DADD_FIRSTENTRYDATEFRRF = reader.ReadString();
            //初年度リテラル(/)
            temp.DADD_FIRSTENTRYDATEFLSRF = reader.ReadString();
            //初年度リテラル(.)
            temp.DADD_FIRSTENTRYDATEFLPRF = reader.ReadString();
            //初年度リテラル(年)
            temp.DADD_FIRSTENTRYDATEFLYRF = reader.ReadString();
            //初年度リテラル(月)
            temp.DADD_FIRSTENTRYDATEFLMRF = reader.ReadString();
            //在庫取寄区分マーク
            temp.DADD_SALESORDERDIVMARKRF = reader.ReadString();
            //メーカー半角名称
            temp.ACCEPTODRCARRF_MAKERHALFNAMERF = reader.ReadString();
            //車種半角名称
            temp.ACCEPTODRCARRF_MODELHALFNAMERF = reader.ReadString();
            //BL商品コード（印刷）
            temp.SALESDETAILRF_PRTBLGOODSCODERF = reader.ReadInt32();
            //BL商品コード名称（印刷）
            temp.SALESDETAILRF_PRTBLGOODSNAMERF = reader.ReadString();
            //印刷用品番
            temp.SALESDETAILRF_PRTGOODSNORF = reader.ReadString();
            //印刷用メーカーコード
            temp.SALESDETAILRF_PRTMAKERCODERF = reader.ReadInt32();
            //印刷用メーカー名称
            temp.SALESDETAILRF_PRTMAKERNAMERF = reader.ReadString();
            //印刷用メーカーカナ名称
            temp.MAKPRT_MAKERKANANAMERF = reader.ReadString();
            //商品大分類コード
            temp.SALESDETAILRF_GOODSLGROUPRF = reader.ReadInt32();
            //商品大分類名称
            temp.SALESDETAILRF_GOODSLGROUPNAMERF = reader.ReadString();
            //商品中分類コード
            temp.SALESDETAILRF_GOODSMGROUPRF = reader.ReadInt32();
            //商品中分類名称
            temp.SALESDETAILRF_GOODSMGROUPNAMERF = reader.ReadString();
            //BLグループコード
            temp.SALESDETAILRF_BLGROUPCODERF = reader.ReadInt32();
            //BLグループコード名称
            temp.SALESDETAILRF_BLGROUPNAMERF = reader.ReadString();
            //販売区分コード
            temp.SALESDETAILRF_SALESCODERF = reader.ReadInt32();
            //販売区分名称
            temp.SALESDETAILRF_SALESCDNMRF = reader.ReadString();
            //商品名称カナ
            temp.SALESDETAILRF_GOODSNAMEKANARF = reader.ReadString();
            // --- ADD 2009.07.24 劉洋 ------ >>>>>>
            //AB商品コード
            temp.SANDEGOODSCDCHGRF_ABGOODSCODE = reader.ReadString();
            // --- ADD 2009.07.24 劉洋 ------ <<<<<<
            // --- ADD 2011.07.19 ------ >>>>>>
            //自動回答区分(SCM)
            temp.SALESDETAILRF_AUTOANSWERDIVSCMRF = reader.ReadInt32();
            // --- ADD 2011.07.19 ------ <<<<<<
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            //受発注種別
            temp.SALESDETAILRF_ACCEPTORORDERKINDRF = reader.ReadInt16();
            //問合せ番号
            temp.SALESDETAILRF_INQUIRYNUMBERRF = reader.ReadInt64();
            //問合せ行番号
            temp.SALESDETAILRF_INQROWNUMBERRF = reader.ReadInt32();
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

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
        /// <returns>FrePSalesDetailWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePSalesDetailWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePSalesDetailWork temp = GetFrePSalesDetailWork( reader, serInfo );
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
                    retValue = (FrePSalesDetailWork[])lst.ToArray( typeof( FrePSalesDetailWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
