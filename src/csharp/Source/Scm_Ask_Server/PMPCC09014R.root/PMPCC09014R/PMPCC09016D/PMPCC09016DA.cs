//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC自社設定マスタメンテ印刷抽出結果ワーク
// プログラム概要   : PCC自社設定マスタメンテ印刷抽出結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2011.08.08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上 
// 修 正 日  2013/09/13  修正内容 : SCM仕掛一覧№10571対応　参照倉庫コード追加
//----------------------------------------------------------------------------//
// 管理番号  11070147-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/07/23  修正内容 : SCM仕掛一覧№10659の1現在庫数表示区分の追加     
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 修 正 日  2014/09/04  修正内容 : SCM仕掛一覧№10678対応　回答納期表示区分追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PccCmpnyStWork
    /// <summary>
    ///                      PCC自社設定マスタメンテ印刷抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC自社設定マスタメンテ印刷抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.08.08  (CSharp File Generated Date)</br>
    /// <br>Programmer       :   鄧潘ハン</br>
    /// <br>Date             :   2014/07/23</br>
    /// <br>Update Note      :   SCM仕掛一覧№10659の1現在庫数表示区分の追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PccCmpnyStWork
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>PCC自社コード</summary>
        /// <remarks>PMの得意先コード</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>PCC倉庫コード</summary>
        private string _pccWarehouseCd = "";

        /// <summary>PCC優先倉庫コード1</summary>
        private string _pccPriWarehouseCd1 = "";

        /// <summary>PCC優先倉庫コード2</summary>
        private string _pccPriWarehouseCd2 = "";

        /// <summary>PCC優先倉庫コード3</summary>
        private string _pccPriWarehouseCd3 = "";

        /// <summary>品番表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _goodsNoDspDiv;

        /// <summary>標準価格表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _listPrcDspDiv;

        /// <summary>仕切価格表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _costDspDiv;

        /// <summary>棚番表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _shelfDspDiv;

        /// <summary>在庫表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _stockDspDiv;

        /// <summary>コメント表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _commentDspDiv;

        /// <summary>出荷数表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _spmtCntDspDiv;

        /// <summary>受注数表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _acptCntDspDiv;

        /// <summary>部品選択品番表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelGdNoDspDiv;

        /// <summary>部品選択標準価格表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelLsPrDspDiv;

        /// <summary>部品選択棚番表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelSelfDspDiv;

        /// <summary>部品選択在庫表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelStckDspDiv;

        /// <summary>在庫状況マーク1</summary>
        /// <remarks>(半角全角混在)在庫あり</remarks>
        private string _stckStMark1 = "";

        /// <summary>在庫状況マーク2</summary>
        /// <remarks>(半角全角混在)在庫なし</remarks>
        private string _stckStMark2 = "";

        /// <summary>在庫状況マーク3</summary>
        /// <remarks>(半角全角混在)在庫不足</remarks>
        private string _stckStMark3 = "";

        /// <summary>PCC発注先名称1</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccSuplName1 = "";

        /// <summary>PCC発注先名称2</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccSuplName2 = "";

        /// <summary>PCC発注先カナ名称</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _pccSuplKana = "";

        /// <summary>PCC発注先略称</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccSuplSnm = "";

        /// <summary>PCC発注先郵便番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _pccSuplPostNo = "";

        /// <summary>PCC発注先住所1</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccSuplAddr1 = "";

        /// <summary>PCC発注先住所2</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccSuplAddr2 = "";

        /// <summary>PCC発注先住所3</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _pccSuplAddr3 = "";

        /// <summary>PCC発注先電話番号1</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _pccSuplTelNo1 = "";

        /// <summary>PCC発注先電話番号2</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _pccSuplTelNo2 = "";

        /// <summary>PCC発注先FAX番号</summary>
        /// <remarks>(半角のみ)</remarks>
        private string _pccSuplFaxNo = "";

        /// <summary>伝票発行区分（PCC）</summary>
        /// <remarks>0:しない 1:回答 2:ﾘﾓｰﾄ 3:両方</remarks>
        private Int32 _pccSlipPrtDiv;

        /// <summary>伝票再発行区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _pccSlipRePrtDiv;

        /// <summary>部品選択優良表示区分</summary>
        /// <remarks>0:全て 1:自社優先在庫 2:自社在庫</remarks>
        private Int32 _prtSelPrmDspDiv;

        /// <summary>在庫状況表示区分</summary>
        /// <remarks>0:マーク 1:現在庫数</remarks>
        private Int32 _stckStDspDiv;

        /// <summary>在庫状況コメント1</summary>
        /// <remarks>(半角全角混在) 在庫あり</remarks>
        private string _stckStComment1 = "";

        /// <summary>在庫状況コメント2</summary>
        /// <remarks>(半角全角混在) 在庫なし</remarks>
        private string _stckStComment2 = "";

        /// <summary>在庫状況コメント3</summary>
        /// <remarks>(半角全角混在) 在庫不足</remarks>
        private string _stckStComment3 = "";

        /// <summary>倉庫表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _warehouseDspDiv;

        /// <summary>取消表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _cancelDspDiv;

        /// <summary>品番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _goodsNoDspDivOd;

        /// <summary>標準価格表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _listPrcDspDivOd;

        /// <summary>仕切価格表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _costDspDivOd;

        /// <summary>棚番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _shelfDspDivOd;

        /// <summary>在庫表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _stockDspDivOd;

        /// <summary>コメント表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _commentDspDivOd;

        /// <summary>出荷数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _spmtCntDspDivOd;

        /// <summary>受注数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _acptCntDspDivOd;

        /// <summary>部品選択品番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelGdNoDspDivOd;

        /// <summary>部品選択標準価格表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelLsPrDspDivOd;

        /// <summary>部品選択棚番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelSelfDspDivOd;

        /// <summary>部品選択在庫表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelStckDspDivOd;

        /// <summary>倉庫表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _warehouseDspDivOd;

        /// <summary>取消表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _cancelDspDivOd;

        /// <summary>問合せ発注表示区分設定</summary>
        /// <remarks>0:問合せ発注共通 1:問合せ発注個別</remarks>
        private Int32 _inqOdrDspDivSet;

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        /// <summary>PCC優先倉庫コード4</summary>
        private string _pccPriWarehouseCd4 = "";
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
        /// <summary>現在庫数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _prsntStkCtDspDivOd;
        /// <summary>現在庫数表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _prsntStkCtDspDiv;
        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        /// <summary>回答納期表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _ansDeliDtDspDiv;

        /// <summary>回答納期表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _ansDeliDtDspDivOd;
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC自社コードプロパティ</summary>
        /// <value>PMの得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC自社コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  PccWarehouseCd
        /// <summary>PCC倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccWarehouseCd
        {
            get { return _pccWarehouseCd; }
            set { _pccWarehouseCd = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd1
        /// <summary>PCC優先倉庫コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC優先倉庫コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccPriWarehouseCd1
        {
            get { return _pccPriWarehouseCd1; }
            set { _pccPriWarehouseCd1 = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd2
        /// <summary>PCC優先倉庫コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC優先倉庫コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccPriWarehouseCd2
        {
            get { return _pccPriWarehouseCd2; }
            set { _pccPriWarehouseCd2 = value; }
        }

        /// public propaty name  :  PccPriWarehouseCd3
        /// <summary>PCC優先倉庫コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC優先倉庫コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccPriWarehouseCd3
        {
            get { return _pccPriWarehouseCd3; }
            set { _pccPriWarehouseCd3 = value; }
        }

        /// public propaty name  :  GoodsNoDspDiv
        /// <summary>品番表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoDspDiv
        {
            get { return _goodsNoDspDiv; }
            set { _goodsNoDspDiv = value; }
        }

        /// public propaty name  :  ListPrcDspDiv
        /// <summary>標準価格表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPrcDspDiv
        {
            get { return _listPrcDspDiv; }
            set { _listPrcDspDiv = value; }
        }

        /// public propaty name  :  CostDspDiv
        /// <summary>仕切価格表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕切価格表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CostDspDiv
        {
            get { return _costDspDiv; }
            set { _costDspDiv = value; }
        }

        /// public propaty name  :  ShelfDspDiv
        /// <summary>棚番表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShelfDspDiv
        {
            get { return _shelfDspDiv; }
            set { _shelfDspDiv = value; }
        }

        /// public propaty name  :  StockDspDiv
        /// <summary>在庫表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDspDiv
        {
            get { return _stockDspDiv; }
            set { _stockDspDiv = value; }
        }

        /// public propaty name  :  CommentDspDiv
        /// <summary>コメント表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CommentDspDiv
        {
            get { return _commentDspDiv; }
            set { _commentDspDiv = value; }
        }

        /// public propaty name  :  SpmtCntDspDiv
        /// <summary>出荷数表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SpmtCntDspDiv
        {
            get { return _spmtCntDspDiv; }
            set { _spmtCntDspDiv = value; }
        }

        /// public propaty name  :  AcptCntDspDiv
        /// <summary>受注数表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptCntDspDiv
        {
            get { return _acptCntDspDiv; }
            set { _acptCntDspDiv = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDiv
        /// <summary>部品選択品番表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択品番表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDiv
        {
            get { return _prtSelGdNoDspDiv; }
            set { _prtSelGdNoDspDiv = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDiv
        /// <summary>部品選択標準価格表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択標準価格表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDiv
        {
            get { return _prtSelLsPrDspDiv; }
            set { _prtSelLsPrDspDiv = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDiv
        /// <summary>部品選択棚番表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択棚番表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDiv
        {
            get { return _prtSelSelfDspDiv; }
            set { _prtSelSelfDspDiv = value; }
        }

        /// public propaty name  :  PrtSelStckDspDiv
        /// <summary>部品選択在庫表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択在庫表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelStckDspDiv
        {
            get { return _prtSelStckDspDiv; }
            set { _prtSelStckDspDiv = value; }
        }

        /// public propaty name  :  StckStMark1
        /// <summary>在庫状況マーク1プロパティ</summary>
        /// <value>(半角全角混在)在庫あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況マーク1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStMark1
        {
            get { return _stckStMark1; }
            set { _stckStMark1 = value; }
        }

        /// public propaty name  :  StckStMark2
        /// <summary>在庫状況マーク2プロパティ</summary>
        /// <value>(半角全角混在)在庫なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況マーク2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStMark2
        {
            get { return _stckStMark2; }
            set { _stckStMark2 = value; }
        }

        /// public propaty name  :  StckStMark3
        /// <summary>在庫状況マーク3プロパティ</summary>
        /// <value>(半角全角混在)在庫不足</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況マーク3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStMark3
        {
            get { return _stckStMark3; }
            set { _stckStMark3 = value; }
        }

        /// public propaty name  :  PccSuplName1
        /// <summary>PCC発注先名称1プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplName1
        {
            get { return _pccSuplName1; }
            set { _pccSuplName1 = value; }
        }

        /// public propaty name  :  PccSuplName2
        /// <summary>PCC発注先名称2プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplName2
        {
            get { return _pccSuplName2; }
            set { _pccSuplName2 = value; }
        }

        /// public propaty name  :  PccSuplKana
        /// <summary>PCC発注先カナ名称プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先カナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplKana
        {
            get { return _pccSuplKana; }
            set { _pccSuplKana = value; }
        }

        /// public propaty name  :  PccSuplSnm
        /// <summary>PCC発注先略称プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplSnm
        {
            get { return _pccSuplSnm; }
            set { _pccSuplSnm = value; }
        }

        /// public propaty name  :  PccSuplPostNo
        /// <summary>PCC発注先郵便番号プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplPostNo
        {
            get { return _pccSuplPostNo; }
            set { _pccSuplPostNo = value; }
        }

        /// public propaty name  :  PccSuplAddr1
        /// <summary>PCC発注先住所1プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先住所1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplAddr1
        {
            get { return _pccSuplAddr1; }
            set { _pccSuplAddr1 = value; }
        }

        /// public propaty name  :  PccSuplAddr2
        /// <summary>PCC発注先住所2プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先住所2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplAddr2
        {
            get { return _pccSuplAddr2; }
            set { _pccSuplAddr2 = value; }
        }

        /// public propaty name  :  PccSuplAddr3
        /// <summary>PCC発注先住所3プロパティ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先住所3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplAddr3
        {
            get { return _pccSuplAddr3; }
            set { _pccSuplAddr3 = value; }
        }

        /// public propaty name  :  PccSuplTelNo1
        /// <summary>PCC発注先電話番号1プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplTelNo1
        {
            get { return _pccSuplTelNo1; }
            set { _pccSuplTelNo1 = value; }
        }

        /// public propaty name  :  PccSuplTelNo2
        /// <summary>PCC発注先電話番号2プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplTelNo2
        {
            get { return _pccSuplTelNo2; }
            set { _pccSuplTelNo2 = value; }
        }

        /// public propaty name  :  PccSuplFaxNo
        /// <summary>PCC発注先FAX番号プロパティ</summary>
        /// <value>(半角のみ)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC発注先FAX番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSuplFaxNo
        {
            get { return _pccSuplFaxNo; }
            set { _pccSuplFaxNo = value; }
        }

        /// public propaty name  :  PccSlipPrtDiv
        /// <summary>伝票発行区分（PCC）プロパティ</summary>
        /// <value>0:しない 1:回答 2:ﾘﾓｰﾄ 3:両方</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行区分（PCC）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccSlipPrtDiv
        {
            get { return _pccSlipPrtDiv; }
            set { _pccSlipPrtDiv = value; }
        }

        /// public propaty name  :  PccSlipRePrtDiv
        /// <summary>伝票再発行区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票再発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccSlipRePrtDiv
        {
            get { return _pccSlipRePrtDiv; }
            set { _pccSlipRePrtDiv = value; }
        }

        /// public propaty name  :  PrtSelPrmDspDiv
        /// <summary>部品選択優良表示区分プロパティ</summary>
        /// <value>0:全て 1:自社優先在庫 2:自社在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択優良表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelPrmDspDiv
        {
            get { return _prtSelPrmDspDiv; }
            set { _prtSelPrmDspDiv = value; }
        }

        /// public propaty name  :  StckStDspDiv
        /// <summary>在庫状況表示区分プロパティ</summary>
        /// <value>0:マーク 1:現在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StckStDspDiv
        {
            get { return _stckStDspDiv; }
            set { _stckStDspDiv = value; }
        }

        /// public propaty name  :  StckStComment1
        /// <summary>在庫状況コメント1プロパティ</summary>
        /// <value>(半角全角混在) 在庫あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStComment1
        {
            get { return _stckStComment1; }
            set { _stckStComment1 = value; }
        }

        /// public propaty name  :  StckStComment2
        /// <summary>在庫状況コメント2プロパティ</summary>
        /// <value>(半角全角混在) 在庫なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStComment2
        {
            get { return _stckStComment2; }
            set { _stckStComment2 = value; }
        }

        /// public propaty name  :  StckStComment3
        /// <summary>在庫状況コメント3プロパティ</summary>
        /// <value>(半角全角混在) 在庫不足</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況コメント3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStComment3
        {
            get { return _stckStComment3; }
            set { _stckStComment3 = value; }
        }

        /// public propaty name  :  WarehouseDspDiv
        /// <summary>倉庫表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseDspDiv
        {
            get { return _warehouseDspDiv; }
            set { _warehouseDspDiv = value; }
        }

        /// public propaty name  :  CancelDspDiv
        /// <summary>取消表示区分(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取消表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CancelDspDiv
        {
            get { return _cancelDspDiv; }
            set { _cancelDspDiv = value; }
        }

        /// public propaty name  :  GoodsNoDspDivOd
        /// <summary>品番表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoDspDivOd
        {
            get { return _goodsNoDspDivOd; }
            set { _goodsNoDspDivOd = value; }
        }

        /// public propaty name  :  ListPrcDspDivOd
        /// <summary>標準価格表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPrcDspDivOd
        {
            get { return _listPrcDspDivOd; }
            set { _listPrcDspDivOd = value; }
        }

        /// public propaty name  :  CostDspDivOd
        /// <summary>仕切価格表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕切価格表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CostDspDivOd
        {
            get { return _costDspDivOd; }
            set { _costDspDivOd = value; }
        }

        /// public propaty name  :  ShelfDspDivOd
        /// <summary>棚番表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShelfDspDivOd
        {
            get { return _shelfDspDivOd; }
            set { _shelfDspDivOd = value; }
        }

        /// public propaty name  :  StockDspDivOd
        /// <summary>在庫表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDspDivOd
        {
            get { return _stockDspDivOd; }
            set { _stockDspDivOd = value; }
        }

        /// public propaty name  :  CommentDspDivOd
        /// <summary>コメント表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CommentDspDivOd
        {
            get { return _commentDspDivOd; }
            set { _commentDspDivOd = value; }
        }

        /// public propaty name  :  SpmtCntDspDivOd
        /// <summary>出荷数表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SpmtCntDspDivOd
        {
            get { return _spmtCntDspDivOd; }
            set { _spmtCntDspDivOd = value; }
        }

        /// public propaty name  :  AcptCntDspDivOd
        /// <summary>受注数表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptCntDspDivOd
        {
            get { return _acptCntDspDivOd; }
            set { _acptCntDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDivOd
        /// <summary>部品選択品番表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択品番表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDivOd
        {
            get { return _prtSelGdNoDspDivOd; }
            set { _prtSelGdNoDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDivOd
        /// <summary>部品選択標準価格表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択標準価格表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDivOd
        {
            get { return _prtSelLsPrDspDivOd; }
            set { _prtSelLsPrDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDivOd
        /// <summary>部品選択棚番表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択棚番表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDivOd
        {
            get { return _prtSelSelfDspDivOd; }
            set { _prtSelSelfDspDivOd = value; }
        }

        /// public propaty name  :  PrtSelStckDspDivOd
        /// <summary>部品選択在庫表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択在庫表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelStckDspDivOd
        {
            get { return _prtSelStckDspDivOd; }
            set { _prtSelStckDspDivOd = value; }
        }

        /// public propaty name  :  WarehouseDspDivOd
        /// <summary>倉庫表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseDspDivOd
        {
            get { return _warehouseDspDivOd; }
            set { _warehouseDspDivOd = value; }
        }

        /// public propaty name  :  CancelDspDivOd
        /// <summary>取消表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取消表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CancelDspDivOd
        {
            get { return _cancelDspDivOd; }
            set { _cancelDspDivOd = value; }
        }

        /// public propaty name  :  InqOdrDspDivSet
        /// <summary>問合せ発注表示区分設定プロパティ</summary>
        /// <value>0:問合せ発注共通 1:問合せ発注個別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ発注表示区分設定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqOdrDspDivSet
        {
            get { return _inqOdrDspDivSet; }
            set { _inqOdrDspDivSet = value; }
        }

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        /// public propaty name  :  PccPriWarehouseCd4
        /// <summary>PCC優先倉庫コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC優先倉庫コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccPriWarehouseCd4
        {
            get { return _pccPriWarehouseCd4; }
            set { _pccPriWarehouseCd4 = value; }
        }
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<


        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
        /// public propaty name  :  PrsntStkCtDspDivOd
        /// <summary>現在庫数表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PrsntStkCtDspDivOd
        {
            get { return _prsntStkCtDspDivOd; }
            set { _prsntStkCtDspDivOd = value; }
        }
        /// public propaty name  :  PrsntStkCtDspDiv
        /// <summary>現在庫数表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PrsntStkCtDspDiv
        {
            get { return _prsntStkCtDspDiv; }
            set { _prsntStkCtDspDiv = value; }
        }
        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        /// public propaty name  :  AnsDeliDtDspDivRF
        /// <summary>回答納期表示区分(問合せ)プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期表示区分(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDeliDtDspDiv
        {
            get { return _ansDeliDtDspDiv; }
            set { _ansDeliDtDspDiv = value; }
        }

        /// public propaty name  :  AnsDeliDtDspDivRF
        /// <summary>回答納期表示区分(発注)プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDeliDtDspDivOd
        {
            get { return _ansDeliDtDspDivOd; }
            set { _ansDeliDtDspDivOd = value; }
        }
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

        /// <summary>
        /// PCC自社設定ワークコンストラクタ
        /// </summary>
        /// <returns>PccCmpnyStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCmpnyStWork()
        {
        }

        /// <summary>
        /// PCC自社設定ワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="pccCompanyCode">PCC自社コード(PMの得意先コード)</param>
        /// <param name="pccWarehouseCd">PCC倉庫コード</param>
        /// <param name="pccPriWarehouseCd1">PCC優先倉庫コード1</param>
        /// <param name="pccPriWarehouseCd2">PCC優先倉庫コード2</param>
        /// <param name="pccPriWarehouseCd3">PCC優先倉庫コード3</param>
        /// <param name="goodsNoDspDiv">品番表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="listPrcDspDiv">標準価格表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="costDspDiv">仕切価格表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="shelfDspDiv">棚番表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="stockDspDiv">在庫表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="commentDspDiv">コメント表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="spmtCntDspDiv">出荷数表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="acptCntDspDiv">受注数表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="prtSelGdNoDspDiv">部品選択品番表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="prtSelLsPrDspDiv">部品選択標準価格表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="prtSelSelfDspDiv">部品選択棚番表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="prtSelStckDspDiv">部品選択在庫表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="stckStMark1">在庫状況マーク1((半角全角混在)在庫あり)</param>
        /// <param name="stckStMark2">在庫状況マーク2((半角全角混在)在庫なし)</param>
        /// <param name="stckStMark3">在庫状況マーク3((半角全角混在)在庫不足)</param>
        /// <param name="pccSuplName1">PCC発注先名称1((半角全角混在))</param>
        /// <param name="pccSuplName2">PCC発注先名称2((半角全角混在))</param>
        /// <param name="pccSuplKana">PCC発注先カナ名称((半角のみ))</param>
        /// <param name="pccSuplSnm">PCC発注先略称((半角全角混在))</param>
        /// <param name="pccSuplPostNo">PCC発注先郵便番号((半角のみ))</param>
        /// <param name="pccSuplAddr1">PCC発注先住所1((半角全角混在))</param>
        /// <param name="pccSuplAddr2">PCC発注先住所2((半角全角混在))</param>
        /// <param name="pccSuplAddr3">PCC発注先住所3((半角全角混在))</param>
        /// <param name="pccSuplTelNo1">PCC発注先電話番号1((半角のみ))</param>
        /// <param name="pccSuplTelNo2">PCC発注先電話番号2((半角のみ))</param>
        /// <param name="pccSuplFaxNo">PCC発注先FAX番号((半角のみ))</param>
        /// <param name="pccSlipPrtDiv">伝票発行区分（PCC）(0:しない 1:回答 2:ﾘﾓｰﾄ 3:両方)</param>
        /// <param name="pccSlipRePrtDiv">伝票再発行区分(0:しない 1:する)</param>
        /// <param name="prtSelPrmDspDiv">部品選択優良表示区分(0:全て 1:自社優先在庫 2:自社在庫)</param>
        /// <param name="stckStDspDiv">在庫状況表示区分(0:マーク 1:現在庫数)</param>
        /// <param name="stckStComment1">在庫状況コメント1((半角全角混在) 在庫あり)</param>
        /// <param name="stckStComment2">在庫状況コメント2((半角全角混在) 在庫なし)</param>
        /// <param name="stckStComment3">在庫状況コメント3((半角全角混在) 在庫不足)</param>
        /// <param name="warehouseDspDiv">倉庫表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="cancelDspDiv">取消表示区分(問合せ)(0:する 1:しない)</param>
        /// <param name="goodsNoDspDivOd">品番表示区分(発注)(0:する 1:しない)</param>
        /// <param name="listPrcDspDivOd">標準価格表示区分(発注)(0:する 1:しない)</param>
        /// <param name="costDspDivOd">仕切価格表示区分(発注)(0:する 1:しない)</param>
        /// <param name="shelfDspDivOd">棚番表示区分(発注)(0:する 1:しない)</param>
        /// <param name="stockDspDivOd">在庫表示区分(発注)(0:する 1:しない)</param>
        /// <param name="commentDspDivOd">コメント表示区分(発注)(0:する 1:しない)</param>
        /// <param name="spmtCntDspDivOd">出荷数表示区分(発注)(0:する 1:しない)</param>
        /// <param name="acptCntDspDivOd">受注数表示区分(発注)(0:する 1:しない)</param>
        /// <param name="prtSelGdNoDspDivOd">部品選択品番表示区分(発注)(0:する 1:しない)</param>
        /// <param name="prtSelLsPrDspDivOd">部品選択標準価格表示区分(発注)(0:する 1:しない)</param>
        /// <param name="prtSelSelfDspDivOd">部品選択棚番表示区分(発注)(0:する 1:しない)</param>
        /// <param name="prtSelStckDspDivOd">部品選択在庫表示区分(発注)(0:する 1:しない)</param>
        /// <param name="warehouseDspDivOd">倉庫表示区分(発注)(0:する 1:しない)</param>
        /// <param name="cancelDspDivOd">取消表示区分(発注)(0:する 1:しない)</param>
        /// <param name="inqOdrDspDivSet">問合せ発注表示区分設定(0:問合せ発注共通 1:問合せ発注個別)</param>
        /// <param name="pccPriWarehouseCd4">PCC優先倉庫コード4</param>
        /// <param name="prsntStkCtDspDivOd">現在庫数表示区分(発注)</param>
        /// <param name="prsntStkCtDspDiv">現在庫数表示区分</param>
        /// <param name="ansDeliDtDspDiv">回答納期表示区分(問合せ)</param>
        /// <param name="ansDeliDtDspDivOd">回答納期表示区分(発注)</param>
        /// <returns>PccCmpnyStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        //public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet)
        //public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string pccPriWarehouseCd4)// DEL 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
        // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        //public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, Int16 prsntStkCtDspDiv)// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        public PccCmpnyStWork(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccWarehouseCd, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, Int32 listPrcDspDiv, Int32 costDspDiv, Int32 shelfDspDiv, Int32 stockDspDiv, Int32 commentDspDiv, Int32 spmtCntDspDiv, Int32 acptCntDspDiv, Int32 prtSelGdNoDspDiv, Int32 prtSelLsPrDspDiv, Int32 prtSelSelfDspDiv, Int32 prtSelStckDspDiv, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, Int32 pccSlipRePrtDiv, Int32 prtSelPrmDspDiv, Int32 stckStDspDiv, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, Int16 prsntStkCtDspDiv, Int16 ansDeliDtDspDiv, Int16 ansDeliDtDspDivOd)
        // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd;
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._pccWarehouseCd = pccWarehouseCd;
            this._pccPriWarehouseCd1 = pccPriWarehouseCd1;
            this._pccPriWarehouseCd2 = pccPriWarehouseCd2;
            this._pccPriWarehouseCd3 = pccPriWarehouseCd3;
            this._goodsNoDspDiv = goodsNoDspDiv;
            this._listPrcDspDiv = listPrcDspDiv;
            this._costDspDiv = costDspDiv;
            this._shelfDspDiv = shelfDspDiv;
            this._stockDspDiv = stockDspDiv;
            this._commentDspDiv = commentDspDiv;
            this._spmtCntDspDiv = spmtCntDspDiv;
            this._acptCntDspDiv = acptCntDspDiv;
            this._prtSelGdNoDspDiv = prtSelGdNoDspDiv;
            this._prtSelLsPrDspDiv = prtSelLsPrDspDiv;
            this._prtSelSelfDspDiv = prtSelSelfDspDiv;
            this._prtSelStckDspDiv = prtSelStckDspDiv;
            this._stckStMark1 = stckStMark1;
            this._stckStMark2 = stckStMark2;
            this._stckStMark3 = stckStMark3;
            this._pccSuplName1 = pccSuplName1;
            this._pccSuplName2 = pccSuplName2;
            this._pccSuplKana = pccSuplKana;
            this._pccSuplSnm = pccSuplSnm;
            this._pccSuplPostNo = pccSuplPostNo;
            this._pccSuplAddr1 = pccSuplAddr1;
            this._pccSuplAddr2 = pccSuplAddr2;
            this._pccSuplAddr3 = pccSuplAddr3;
            this._pccSuplTelNo1 = pccSuplTelNo1;
            this._pccSuplTelNo2 = pccSuplTelNo2;
            this._pccSuplFaxNo = pccSuplFaxNo;
            this._pccSlipPrtDiv = pccSlipPrtDiv;
            this._pccSlipRePrtDiv = pccSlipRePrtDiv;
            this._prtSelPrmDspDiv = prtSelPrmDspDiv;
            this._stckStDspDiv = stckStDspDiv;
            this._stckStComment1 = stckStComment1;
            this._stckStComment2 = stckStComment2;
            this._stckStComment3 = stckStComment3;
            this._warehouseDspDiv = warehouseDspDiv;
            this._cancelDspDiv = cancelDspDiv;
            this._goodsNoDspDivOd = goodsNoDspDivOd;
            this._listPrcDspDivOd = listPrcDspDivOd;
            this._costDspDivOd = costDspDivOd;
            this._shelfDspDivOd = shelfDspDivOd;
            this._stockDspDivOd = stockDspDivOd;
            this._commentDspDivOd = commentDspDivOd;
            this._spmtCntDspDivOd = spmtCntDspDivOd;
            this._acptCntDspDivOd = acptCntDspDivOd;
            this._prtSelGdNoDspDivOd = prtSelGdNoDspDivOd;
            this._prtSelLsPrDspDivOd = prtSelLsPrDspDivOd;
            this._prtSelSelfDspDivOd = prtSelSelfDspDivOd;
            this._prtSelStckDspDivOd = prtSelStckDspDivOd;
            this._warehouseDspDivOd = warehouseDspDivOd;
            this._cancelDspDivOd = cancelDspDivOd;
            this._inqOdrDspDivSet = inqOdrDspDivSet;

            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            this._pccPriWarehouseCd4 = pccPriWarehouseCd4;
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            this._prsntStkCtDspDivOd = prsntStkCtDspDivOd;
            this._prsntStkCtDspDiv = prsntStkCtDspDiv;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            this._ansDeliDtDspDiv = ansDeliDtDspDiv;
            this._ansDeliDtDspDivOd = ansDeliDtDspDivOd;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC自社設定ワーク複製処理
        /// </summary>
        /// <returns>PccCmpnyStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccCmpnyStWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCmpnyStWork Clone()
        {
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet);
            //return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._pccPriWarehouseCd4);// DEL 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            //return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDiv);// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
            return new PccCmpnyStWork(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccWarehouseCd, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._listPrcDspDiv, this._costDspDiv, this._shelfDspDiv, this._stockDspDiv, this._commentDspDiv, this._spmtCntDspDiv, this._acptCntDspDiv, this._prtSelGdNoDspDiv, this._prtSelLsPrDspDiv, this._prtSelSelfDspDiv, this._prtSelStckDspDiv, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipRePrtDiv, this._prtSelPrmDspDiv, this._stckStDspDiv, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDiv, this._ansDeliDtDspDiv, this._ansDeliDtDspDivOd);
            // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC自社設定ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCmpnyStWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccCmpnyStWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccWarehouseCd == target.PccWarehouseCd)
                 && (this.PccPriWarehouseCd1 == target.PccPriWarehouseCd1)
                 && (this.PccPriWarehouseCd2 == target.PccPriWarehouseCd2)
                 && (this.PccPriWarehouseCd3 == target.PccPriWarehouseCd3)
                 && (this.GoodsNoDspDiv == target.GoodsNoDspDiv)
                 && (this.ListPrcDspDiv == target.ListPrcDspDiv)
                 && (this.CostDspDiv == target.CostDspDiv)
                 && (this.ShelfDspDiv == target.ShelfDspDiv)
                 && (this.StockDspDiv == target.StockDspDiv)
                 && (this.CommentDspDiv == target.CommentDspDiv)
                 && (this.SpmtCntDspDiv == target.SpmtCntDspDiv)
                 && (this.AcptCntDspDiv == target.AcptCntDspDiv)
                 && (this.PrtSelGdNoDspDiv == target.PrtSelGdNoDspDiv)
                 && (this.PrtSelLsPrDspDiv == target.PrtSelLsPrDspDiv)
                 && (this.PrtSelSelfDspDiv == target.PrtSelSelfDspDiv)
                 && (this.PrtSelStckDspDiv == target.PrtSelStckDspDiv)
                 && (this.StckStMark1 == target.StckStMark1)
                 && (this.StckStMark2 == target.StckStMark2)
                 && (this.StckStMark3 == target.StckStMark3)
                 && (this.PccSuplName1 == target.PccSuplName1)
                 && (this.PccSuplName2 == target.PccSuplName2)
                 && (this.PccSuplKana == target.PccSuplKana)
                 && (this.PccSuplSnm == target.PccSuplSnm)
                 && (this.PccSuplPostNo == target.PccSuplPostNo)
                 && (this.PccSuplAddr1 == target.PccSuplAddr1)
                 && (this.PccSuplAddr2 == target.PccSuplAddr2)
                 && (this.PccSuplAddr3 == target.PccSuplAddr3)
                 && (this.PccSuplTelNo1 == target.PccSuplTelNo1)
                 && (this.PccSuplTelNo2 == target.PccSuplTelNo2)
                 && (this.PccSuplFaxNo == target.PccSuplFaxNo)
                 && (this.PccSlipPrtDiv == target.PccSlipPrtDiv)
                 && (this.PccSlipRePrtDiv == target.PccSlipRePrtDiv)
                 && (this.PrtSelPrmDspDiv == target.PrtSelPrmDspDiv)
                 && (this.StckStDspDiv == target.StckStDspDiv)
                 && (this.StckStComment1 == target.StckStComment1)
                 && (this.StckStComment2 == target.StckStComment2)
                 && (this.StckStComment3 == target.StckStComment3)
                 && (this.WarehouseDspDiv == target.WarehouseDspDiv)
                 && (this.CancelDspDiv == target.CancelDspDiv)
                 && (this.GoodsNoDspDivOd == target.GoodsNoDspDivOd)
                 && (this.ListPrcDspDivOd == target.ListPrcDspDivOd)
                 && (this.CostDspDivOd == target.CostDspDivOd)
                 && (this.ShelfDspDivOd == target.ShelfDspDivOd)
                 && (this.StockDspDivOd == target.StockDspDivOd)
                 && (this.CommentDspDivOd == target.CommentDspDivOd)
                 && (this.SpmtCntDspDivOd == target.SpmtCntDspDivOd)
                 && (this.AcptCntDspDivOd == target.AcptCntDspDivOd)
                 && (this.PrtSelGdNoDspDivOd == target.PrtSelGdNoDspDivOd)
                 && (this.PrtSelLsPrDspDivOd == target.PrtSelLsPrDspDivOd)
                 && (this.PrtSelSelfDspDivOd == target.PrtSelSelfDspDivOd)
                 && (this.PrtSelStckDspDivOd == target.PrtSelStckDspDivOd)
                 && (this.WarehouseDspDivOd == target.WarehouseDspDivOd)
                 && (this.CancelDspDivOd == target.CancelDspDivOd)
                 && (this.InqOdrDspDivSet == target.InqOdrDspDivSet)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                 && (this.PccPriWarehouseCd4 == target.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                 && (this.PrsntStkCtDspDivOd == target.PrsntStkCtDspDivOd)
                 && (this.PrsntStkCtDspDiv == target.PrsntStkCtDspDiv)
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                 && (this.AnsDeliDtDspDiv == target.AnsDeliDtDspDiv)
                 && (this.AnsDeliDtDspDivOd == target.AnsDeliDtDspDivOd)
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                 );
        }

        /// <summary>
        /// PCC自社設定ワーク比較処理
        /// </summary>
        /// <param name="pccCmpnySt1">
        ///                    比較するPccCmpnyStWorkクラスのインスタンス
        /// </param>
        /// <param name="pccCmpnySt2">比較するPccCmpnyStWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccCmpnyStWork pccCmpnySt1, PccCmpnyStWork pccCmpnySt2)
        {
            return ((pccCmpnySt1.CreateDateTime == pccCmpnySt2.CreateDateTime)
                 && (pccCmpnySt1.UpdateDateTime == pccCmpnySt2.UpdateDateTime)
                 && (pccCmpnySt1.LogicalDeleteCode == pccCmpnySt2.LogicalDeleteCode)
                 && (pccCmpnySt1.InqOriginalEpCd == pccCmpnySt2.InqOriginalEpCd)
                 && (pccCmpnySt1.InqOriginalSecCd == pccCmpnySt2.InqOriginalSecCd)
                 && (pccCmpnySt1.InqOtherEpCd == pccCmpnySt2.InqOtherEpCd)
                 && (pccCmpnySt1.InqOtherSecCd == pccCmpnySt2.InqOtherSecCd)
                 && (pccCmpnySt1.PccCompanyCode == pccCmpnySt2.PccCompanyCode)
                 && (pccCmpnySt1.PccWarehouseCd == pccCmpnySt2.PccWarehouseCd)
                 && (pccCmpnySt1.PccPriWarehouseCd1 == pccCmpnySt2.PccPriWarehouseCd1)
                 && (pccCmpnySt1.PccPriWarehouseCd2 == pccCmpnySt2.PccPriWarehouseCd2)
                 && (pccCmpnySt1.PccPriWarehouseCd3 == pccCmpnySt2.PccPriWarehouseCd3)
                 && (pccCmpnySt1.GoodsNoDspDiv == pccCmpnySt2.GoodsNoDspDiv)
                 && (pccCmpnySt1.ListPrcDspDiv == pccCmpnySt2.ListPrcDspDiv)
                 && (pccCmpnySt1.CostDspDiv == pccCmpnySt2.CostDspDiv)
                 && (pccCmpnySt1.ShelfDspDiv == pccCmpnySt2.ShelfDspDiv)
                 && (pccCmpnySt1.StockDspDiv == pccCmpnySt2.StockDspDiv)
                 && (pccCmpnySt1.CommentDspDiv == pccCmpnySt2.CommentDspDiv)
                 && (pccCmpnySt1.SpmtCntDspDiv == pccCmpnySt2.SpmtCntDspDiv)
                 && (pccCmpnySt1.AcptCntDspDiv == pccCmpnySt2.AcptCntDspDiv)
                 && (pccCmpnySt1.PrtSelGdNoDspDiv == pccCmpnySt2.PrtSelGdNoDspDiv)
                 && (pccCmpnySt1.PrtSelLsPrDspDiv == pccCmpnySt2.PrtSelLsPrDspDiv)
                 && (pccCmpnySt1.PrtSelSelfDspDiv == pccCmpnySt2.PrtSelSelfDspDiv)
                 && (pccCmpnySt1.PrtSelStckDspDiv == pccCmpnySt2.PrtSelStckDspDiv)
                 && (pccCmpnySt1.StckStMark1 == pccCmpnySt2.StckStMark1)
                 && (pccCmpnySt1.StckStMark2 == pccCmpnySt2.StckStMark2)
                 && (pccCmpnySt1.StckStMark3 == pccCmpnySt2.StckStMark3)
                 && (pccCmpnySt1.PccSuplName1 == pccCmpnySt2.PccSuplName1)
                 && (pccCmpnySt1.PccSuplName2 == pccCmpnySt2.PccSuplName2)
                 && (pccCmpnySt1.PccSuplKana == pccCmpnySt2.PccSuplKana)
                 && (pccCmpnySt1.PccSuplSnm == pccCmpnySt2.PccSuplSnm)
                 && (pccCmpnySt1.PccSuplPostNo == pccCmpnySt2.PccSuplPostNo)
                 && (pccCmpnySt1.PccSuplAddr1 == pccCmpnySt2.PccSuplAddr1)
                 && (pccCmpnySt1.PccSuplAddr2 == pccCmpnySt2.PccSuplAddr2)
                 && (pccCmpnySt1.PccSuplAddr3 == pccCmpnySt2.PccSuplAddr3)
                 && (pccCmpnySt1.PccSuplTelNo1 == pccCmpnySt2.PccSuplTelNo1)
                 && (pccCmpnySt1.PccSuplTelNo2 == pccCmpnySt2.PccSuplTelNo2)
                 && (pccCmpnySt1.PccSuplFaxNo == pccCmpnySt2.PccSuplFaxNo)
                 && (pccCmpnySt1.PccSlipPrtDiv == pccCmpnySt2.PccSlipPrtDiv)
                 && (pccCmpnySt1.PccSlipRePrtDiv == pccCmpnySt2.PccSlipRePrtDiv)
                 && (pccCmpnySt1.PrtSelPrmDspDiv == pccCmpnySt2.PrtSelPrmDspDiv)
                 && (pccCmpnySt1.StckStDspDiv == pccCmpnySt2.StckStDspDiv)
                 && (pccCmpnySt1.StckStComment1 == pccCmpnySt2.StckStComment1)
                 && (pccCmpnySt1.StckStComment2 == pccCmpnySt2.StckStComment2)
                 && (pccCmpnySt1.StckStComment3 == pccCmpnySt2.StckStComment3)
                 && (pccCmpnySt1.WarehouseDspDiv == pccCmpnySt2.WarehouseDspDiv)
                 && (pccCmpnySt1.CancelDspDiv == pccCmpnySt2.CancelDspDiv)
                 && (pccCmpnySt1.GoodsNoDspDivOd == pccCmpnySt2.GoodsNoDspDivOd)
                 && (pccCmpnySt1.ListPrcDspDivOd == pccCmpnySt2.ListPrcDspDivOd)
                 && (pccCmpnySt1.CostDspDivOd == pccCmpnySt2.CostDspDivOd)
                 && (pccCmpnySt1.ShelfDspDivOd == pccCmpnySt2.ShelfDspDivOd)
                 && (pccCmpnySt1.StockDspDivOd == pccCmpnySt2.StockDspDivOd)
                 && (pccCmpnySt1.CommentDspDivOd == pccCmpnySt2.CommentDspDivOd)
                 && (pccCmpnySt1.SpmtCntDspDivOd == pccCmpnySt2.SpmtCntDspDivOd)
                 && (pccCmpnySt1.AcptCntDspDivOd == pccCmpnySt2.AcptCntDspDivOd)
                 && (pccCmpnySt1.PrtSelGdNoDspDivOd == pccCmpnySt2.PrtSelGdNoDspDivOd)
                 && (pccCmpnySt1.PrtSelLsPrDspDivOd == pccCmpnySt2.PrtSelLsPrDspDivOd)
                 && (pccCmpnySt1.PrtSelSelfDspDivOd == pccCmpnySt2.PrtSelSelfDspDivOd)
                 && (pccCmpnySt1.PrtSelStckDspDivOd == pccCmpnySt2.PrtSelStckDspDivOd)
                 && (pccCmpnySt1.WarehouseDspDivOd == pccCmpnySt2.WarehouseDspDivOd)
                 && (pccCmpnySt1.CancelDspDivOd == pccCmpnySt2.CancelDspDivOd)
                 && (pccCmpnySt1.InqOdrDspDivSet == pccCmpnySt2.InqOdrDspDivSet)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                 && (pccCmpnySt1.PccPriWarehouseCd4 == pccCmpnySt2.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                 && (pccCmpnySt1.PrsntStkCtDspDivOd == pccCmpnySt2.PrsntStkCtDspDivOd)
                 && (pccCmpnySt1.PrsntStkCtDspDiv == pccCmpnySt2.PrsntStkCtDspDiv)
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                 && (pccCmpnySt1.AnsDeliDtDspDiv == pccCmpnySt2.AnsDeliDtDspDiv)
                 && (pccCmpnySt1.AnsDeliDtDspDivOd == pccCmpnySt2.AnsDeliDtDspDivOd)
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                 );
        }
        /// <summary>
        /// PCC自社設定ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCmpnyStWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccCmpnyStWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccWarehouseCd != target.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (this.PccPriWarehouseCd1 != target.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (this.PccPriWarehouseCd2 != target.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (this.PccPriWarehouseCd3 != target.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (this.GoodsNoDspDiv != target.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (this.ListPrcDspDiv != target.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (this.CostDspDiv != target.CostDspDiv) resList.Add("CostDspDiv");
            if (this.ShelfDspDiv != target.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (this.StockDspDiv != target.StockDspDiv) resList.Add("StockDspDiv");
            if (this.CommentDspDiv != target.CommentDspDiv) resList.Add("CommentDspDiv");
            if (this.SpmtCntDspDiv != target.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (this.AcptCntDspDiv != target.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (this.PrtSelGdNoDspDiv != target.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (this.PrtSelLsPrDspDiv != target.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (this.PrtSelSelfDspDiv != target.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (this.PrtSelStckDspDiv != target.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (this.StckStMark1 != target.StckStMark1) resList.Add("StckStMark1");
            if (this.StckStMark2 != target.StckStMark2) resList.Add("StckStMark2");
            if (this.StckStMark3 != target.StckStMark3) resList.Add("StckStMark3");
            if (this.PccSuplName1 != target.PccSuplName1) resList.Add("PccSuplName1");
            if (this.PccSuplName2 != target.PccSuplName2) resList.Add("PccSuplName2");
            if (this.PccSuplKana != target.PccSuplKana) resList.Add("PccSuplKana");
            if (this.PccSuplSnm != target.PccSuplSnm) resList.Add("PccSuplSnm");
            if (this.PccSuplPostNo != target.PccSuplPostNo) resList.Add("PccSuplPostNo");
            if (this.PccSuplAddr1 != target.PccSuplAddr1) resList.Add("PccSuplAddr1");
            if (this.PccSuplAddr2 != target.PccSuplAddr2) resList.Add("PccSuplAddr2");
            if (this.PccSuplAddr3 != target.PccSuplAddr3) resList.Add("PccSuplAddr3");
            if (this.PccSuplTelNo1 != target.PccSuplTelNo1) resList.Add("PccSuplTelNo1");
            if (this.PccSuplTelNo2 != target.PccSuplTelNo2) resList.Add("PccSuplTelNo2");
            if (this.PccSuplFaxNo != target.PccSuplFaxNo) resList.Add("PccSuplFaxNo");
            if (this.PccSlipPrtDiv != target.PccSlipPrtDiv) resList.Add("PccSlipPrtDiv");
            if (this.PccSlipRePrtDiv != target.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (this.PrtSelPrmDspDiv != target.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (this.StckStDspDiv != target.StckStDspDiv) resList.Add("StckStDspDiv");
            if (this.StckStComment1 != target.StckStComment1) resList.Add("StckStComment1");
            if (this.StckStComment2 != target.StckStComment2) resList.Add("StckStComment2");
            if (this.StckStComment3 != target.StckStComment3) resList.Add("StckStComment3");
            if (this.WarehouseDspDiv != target.WarehouseDspDiv) resList.Add("WarehouseDspDiv");
            if (this.CancelDspDiv != target.CancelDspDiv) resList.Add("CancelDspDiv");
            if (this.GoodsNoDspDivOd != target.GoodsNoDspDivOd) resList.Add("GoodsNoDspDivOd");
            if (this.ListPrcDspDivOd != target.ListPrcDspDivOd) resList.Add("ListPrcDspDivOd");
            if (this.CostDspDivOd != target.CostDspDivOd) resList.Add("CostDspDivOd");
            if (this.ShelfDspDivOd != target.ShelfDspDivOd) resList.Add("ShelfDspDivOd");
            if (this.StockDspDivOd != target.StockDspDivOd) resList.Add("StockDspDivOd");
            if (this.CommentDspDivOd != target.CommentDspDivOd) resList.Add("CommentDspDivOd");
            if (this.SpmtCntDspDivOd != target.SpmtCntDspDivOd) resList.Add("SpmtCntDspDivOd");
            if (this.AcptCntDspDivOd != target.AcptCntDspDivOd) resList.Add("AcptCntDspDivOd");
            if (this.PrtSelGdNoDspDivOd != target.PrtSelGdNoDspDivOd) resList.Add("PrtSelGdNoDspDivOd");
            if (this.PrtSelLsPrDspDivOd != target.PrtSelLsPrDspDivOd) resList.Add("PrtSelLsPrDspDivOd");
            if (this.PrtSelSelfDspDivOd != target.PrtSelSelfDspDivOd) resList.Add("PrtSelSelfDspDivOd");
            if (this.PrtSelStckDspDivOd != target.PrtSelStckDspDivOd) resList.Add("PrtSelStckDspDivOd");
            if (this.WarehouseDspDivOd != target.WarehouseDspDivOd) resList.Add("WarehouseDspDivOd");
            if (this.CancelDspDivOd != target.CancelDspDivOd) resList.Add("CancelDspDivOd");
            if (this.InqOdrDspDivSet != target.InqOdrDspDivSet) resList.Add("InqOdrDspDivSet");
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (this.PccPriWarehouseCd4 != target.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            if (this.PrsntStkCtDspDivOd != target.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (this.PrsntStkCtDspDiv != target.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            if (this.AnsDeliDtDspDiv != target.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (this.AnsDeliDtDspDivOd != target.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// PCC自社設定ワーク比較処理
        /// </summary>
        /// <param name="pccCmpnySt1">比較するPccCmpnyStWorkクラスのインスタンス</param>
        /// <param name="pccCmpnySt2">比較するPccCmpnyStWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccCmpnyStWork pccCmpnySt1, PccCmpnyStWork pccCmpnySt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCmpnySt1.CreateDateTime != pccCmpnySt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCmpnySt1.UpdateDateTime != pccCmpnySt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCmpnySt1.LogicalDeleteCode != pccCmpnySt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCmpnySt1.InqOriginalEpCd != pccCmpnySt2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (pccCmpnySt1.InqOriginalSecCd != pccCmpnySt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccCmpnySt1.InqOtherEpCd != pccCmpnySt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCmpnySt1.InqOtherSecCd != pccCmpnySt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCmpnySt1.PccCompanyCode != pccCmpnySt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccCmpnySt1.PccWarehouseCd != pccCmpnySt2.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (pccCmpnySt1.PccPriWarehouseCd1 != pccCmpnySt2.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (pccCmpnySt1.PccPriWarehouseCd2 != pccCmpnySt2.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (pccCmpnySt1.PccPriWarehouseCd3 != pccCmpnySt2.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (pccCmpnySt1.GoodsNoDspDiv != pccCmpnySt2.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (pccCmpnySt1.ListPrcDspDiv != pccCmpnySt2.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (pccCmpnySt1.CostDspDiv != pccCmpnySt2.CostDspDiv) resList.Add("CostDspDiv");
            if (pccCmpnySt1.ShelfDspDiv != pccCmpnySt2.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (pccCmpnySt1.StockDspDiv != pccCmpnySt2.StockDspDiv) resList.Add("StockDspDiv");
            if (pccCmpnySt1.CommentDspDiv != pccCmpnySt2.CommentDspDiv) resList.Add("CommentDspDiv");
            if (pccCmpnySt1.SpmtCntDspDiv != pccCmpnySt2.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (pccCmpnySt1.AcptCntDspDiv != pccCmpnySt2.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (pccCmpnySt1.PrtSelGdNoDspDiv != pccCmpnySt2.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (pccCmpnySt1.PrtSelLsPrDspDiv != pccCmpnySt2.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (pccCmpnySt1.PrtSelSelfDspDiv != pccCmpnySt2.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (pccCmpnySt1.PrtSelStckDspDiv != pccCmpnySt2.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (pccCmpnySt1.StckStMark1 != pccCmpnySt2.StckStMark1) resList.Add("StckStMark1");
            if (pccCmpnySt1.StckStMark2 != pccCmpnySt2.StckStMark2) resList.Add("StckStMark2");
            if (pccCmpnySt1.StckStMark3 != pccCmpnySt2.StckStMark3) resList.Add("StckStMark3");
            if (pccCmpnySt1.PccSuplName1 != pccCmpnySt2.PccSuplName1) resList.Add("PccSuplName1");
            if (pccCmpnySt1.PccSuplName2 != pccCmpnySt2.PccSuplName2) resList.Add("PccSuplName2");
            if (pccCmpnySt1.PccSuplKana != pccCmpnySt2.PccSuplKana) resList.Add("PccSuplKana");
            if (pccCmpnySt1.PccSuplSnm != pccCmpnySt2.PccSuplSnm) resList.Add("PccSuplSnm");
            if (pccCmpnySt1.PccSuplPostNo != pccCmpnySt2.PccSuplPostNo) resList.Add("PccSuplPostNo");
            if (pccCmpnySt1.PccSuplAddr1 != pccCmpnySt2.PccSuplAddr1) resList.Add("PccSuplAddr1");
            if (pccCmpnySt1.PccSuplAddr2 != pccCmpnySt2.PccSuplAddr2) resList.Add("PccSuplAddr2");
            if (pccCmpnySt1.PccSuplAddr3 != pccCmpnySt2.PccSuplAddr3) resList.Add("PccSuplAddr3");
            if (pccCmpnySt1.PccSuplTelNo1 != pccCmpnySt2.PccSuplTelNo1) resList.Add("PccSuplTelNo1");
            if (pccCmpnySt1.PccSuplTelNo2 != pccCmpnySt2.PccSuplTelNo2) resList.Add("PccSuplTelNo2");
            if (pccCmpnySt1.PccSuplFaxNo != pccCmpnySt2.PccSuplFaxNo) resList.Add("PccSuplFaxNo");
            if (pccCmpnySt1.PccSlipPrtDiv != pccCmpnySt2.PccSlipPrtDiv) resList.Add("PccSlipPrtDiv");
            if (pccCmpnySt1.PccSlipRePrtDiv != pccCmpnySt2.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (pccCmpnySt1.PrtSelPrmDspDiv != pccCmpnySt2.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (pccCmpnySt1.StckStDspDiv != pccCmpnySt2.StckStDspDiv) resList.Add("StckStDspDiv");
            if (pccCmpnySt1.StckStComment1 != pccCmpnySt2.StckStComment1) resList.Add("StckStComment1");
            if (pccCmpnySt1.StckStComment2 != pccCmpnySt2.StckStComment2) resList.Add("StckStComment2");
            if (pccCmpnySt1.StckStComment3 != pccCmpnySt2.StckStComment3) resList.Add("StckStComment3");
            if (pccCmpnySt1.WarehouseDspDiv != pccCmpnySt2.WarehouseDspDiv) resList.Add("WarehouseDspDiv");
            if (pccCmpnySt1.CancelDspDiv != pccCmpnySt2.CancelDspDiv) resList.Add("CancelDspDiv");
            if (pccCmpnySt1.GoodsNoDspDivOd != pccCmpnySt2.GoodsNoDspDivOd) resList.Add("GoodsNoDspDivOd");
            if (pccCmpnySt1.ListPrcDspDivOd != pccCmpnySt2.ListPrcDspDivOd) resList.Add("ListPrcDspDivOd");
            if (pccCmpnySt1.CostDspDivOd != pccCmpnySt2.CostDspDivOd) resList.Add("CostDspDivOd");
            if (pccCmpnySt1.ShelfDspDivOd != pccCmpnySt2.ShelfDspDivOd) resList.Add("ShelfDspDivOd");
            if (pccCmpnySt1.StockDspDivOd != pccCmpnySt2.StockDspDivOd) resList.Add("StockDspDivOd");
            if (pccCmpnySt1.CommentDspDivOd != pccCmpnySt2.CommentDspDivOd) resList.Add("CommentDspDivOd");
            if (pccCmpnySt1.SpmtCntDspDivOd != pccCmpnySt2.SpmtCntDspDivOd) resList.Add("SpmtCntDspDivOd");
            if (pccCmpnySt1.AcptCntDspDivOd != pccCmpnySt2.AcptCntDspDivOd) resList.Add("AcptCntDspDivOd");
            if (pccCmpnySt1.PrtSelGdNoDspDivOd != pccCmpnySt2.PrtSelGdNoDspDivOd) resList.Add("PrtSelGdNoDspDivOd");
            if (pccCmpnySt1.PrtSelLsPrDspDivOd != pccCmpnySt2.PrtSelLsPrDspDivOd) resList.Add("PrtSelLsPrDspDivOd");
            if (pccCmpnySt1.PrtSelSelfDspDivOd != pccCmpnySt2.PrtSelSelfDspDivOd) resList.Add("PrtSelSelfDspDivOd");
            if (pccCmpnySt1.PrtSelStckDspDivOd != pccCmpnySt2.PrtSelStckDspDivOd) resList.Add("PrtSelStckDspDivOd");
            if (pccCmpnySt1.WarehouseDspDivOd != pccCmpnySt2.WarehouseDspDivOd) resList.Add("WarehouseDspDivOd");
            if (pccCmpnySt1.CancelDspDivOd != pccCmpnySt2.CancelDspDivOd) resList.Add("CancelDspDivOd");
            if (pccCmpnySt1.InqOdrDspDivSet != pccCmpnySt2.InqOdrDspDivSet) resList.Add("InqOdrDspDivSet");
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (pccCmpnySt1.PccPriWarehouseCd4 != pccCmpnySt2.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            if (pccCmpnySt1.PrsntStkCtDspDivOd != pccCmpnySt2.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (pccCmpnySt1.PrsntStkCtDspDiv != pccCmpnySt2.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            if (pccCmpnySt1.AnsDeliDtDspDiv != pccCmpnySt2.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (pccCmpnySt1.AnsDeliDtDspDivOd != pccCmpnySt2.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

            return resList;
        }
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PccCmpnyStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PccCmpnyStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PccCmpnyStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PccCmpnyStWork || graph is ArrayList || graph is PccCmpnyStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PccCmpnyStWork).FullName));

            if (graph != null && graph is PccCmpnyStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PccCmpnyStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PccCmpnyStWork[])graph).Length;
            }
            else if (graph is PccCmpnyStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //PCC自社コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PccCompanyCode
            //PCC倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //PccWarehouseCd
            //PCC優先倉庫コード1
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd1
            //PCC優先倉庫コード2
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd2
            //PCC優先倉庫コード3
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd3
            //品番表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoDspDiv
            //標準価格表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPrcDspDiv
            //仕切価格表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //CostDspDiv
            //棚番表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //ShelfDspDiv
            //在庫表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDspDiv
            //コメント表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //CommentDspDiv
            //出荷数表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //SpmtCntDspDiv
            //受注数表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptCntDspDiv
            //部品選択品番表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelGdNoDspDiv
            //部品選択標準価格表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelLsPrDspDiv
            //部品選択棚番表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelSelfDspDiv
            //部品選択在庫表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelStckDspDiv
            //在庫状況マーク1
            serInfo.MemberInfo.Add(typeof(string)); //StckStMark1
            //在庫状況マーク2
            serInfo.MemberInfo.Add(typeof(string)); //StckStMark2
            //在庫状況マーク3
            serInfo.MemberInfo.Add(typeof(string)); //StckStMark3
            //PCC発注先名称1
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplName1
            //PCC発注先名称2
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplName2
            //PCC発注先カナ名称
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplKana
            //PCC発注先略称
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplSnm
            //PCC発注先郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplPostNo
            //PCC発注先住所1
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplAddr1
            //PCC発注先住所2
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplAddr2
            //PCC発注先住所3
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplAddr3
            //PCC発注先電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplTelNo1
            //PCC発注先電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplTelNo2
            //PCC発注先FAX番号
            serInfo.MemberInfo.Add(typeof(string)); //PccSuplFaxNo
            //伝票発行区分（PCC）
            serInfo.MemberInfo.Add(typeof(Int32)); //PccSlipPrtDiv
            //伝票再発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PccSlipRePrtDiv
            //部品選択優良表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelPrmDspDiv
            //在庫状況表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StckStDspDiv
            //在庫状況コメント1
            serInfo.MemberInfo.Add(typeof(string)); //StckStComment1
            //在庫状況コメント2
            serInfo.MemberInfo.Add(typeof(string)); //StckStComment2
            //在庫状況コメント3
            serInfo.MemberInfo.Add(typeof(string)); //StckStComment3
            //倉庫表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseDspDiv
            //取消表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int32)); //CancelDspDiv
            //品番表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoDspDivOd
            //標準価格表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPrcDspDivOd
            //仕切価格表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //CostDspDivOd
            //棚番表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //ShelfDspDivOd
            //在庫表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDspDivOd
            //コメント表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //CommentDspDivOd
            //出荷数表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //SpmtCntDspDivOd
            //受注数表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptCntDspDivOd
            //部品選択品番表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelGdNoDspDivOd
            //部品選択標準価格表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelLsPrDspDivOd
            //部品選択棚番表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelSelfDspDivOd
            //部品選択在庫表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtSelStckDspDivOd
            //倉庫表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseDspDivOd
            //取消表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int32)); //CancelDspDivOd
            //問合せ発注表示区分設定
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOdrDspDivSet
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            serInfo.MemberInfo.Add(typeof(string)); //PccPriWarehouseCd4
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int16)); //PrsntStkCtDspDivOd
            //現在庫数表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int16)); //PrsntStkCtDspDiv
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            serInfo.MemberInfo.Add(typeof(Int16));  //AnsDeliDtDspDiv
            // 回答納期表示区分(発注)
            serInfo.MemberInfo.Add(typeof(Int16));  //AnsDeliDtDspDivOd
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is PccCmpnyStWork)
            {
                PccCmpnyStWork temp = (PccCmpnyStWork)graph;

                SetPccCmpnyStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PccCmpnyStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PccCmpnyStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PccCmpnyStWork temp in lst)
                {
                    SetPccCmpnyStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PccCmpnyStWorkメンバ数(publicプロパティ数)
        /// </summary>
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        //private const int currentMemberCount = 62;
        //private const int currentMemberCount = 63;// DEL 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        //private const int currentMemberCount = 65;// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        private const int currentMemberCount = 67;
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

        /// <summary>
        ///  PccCmpnyStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPccCmpnyStWork(System.IO.BinaryWriter writer, PccCmpnyStWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //PCC自社コード
            writer.Write(temp.PccCompanyCode);
            //PCC倉庫コード
            writer.Write(temp.PccWarehouseCd);
            //PCC優先倉庫コード1
            writer.Write(temp.PccPriWarehouseCd1);
            //PCC優先倉庫コード2
            writer.Write(temp.PccPriWarehouseCd2);
            //PCC優先倉庫コード3
            writer.Write(temp.PccPriWarehouseCd3);
            //品番表示区分(問合せ)
            writer.Write(temp.GoodsNoDspDiv);
            //標準価格表示区分(問合せ)
            writer.Write(temp.ListPrcDspDiv);
            //仕切価格表示区分(問合せ)
            writer.Write(temp.CostDspDiv);
            //棚番表示区分(問合せ)
            writer.Write(temp.ShelfDspDiv);
            //在庫表示区分(問合せ)
            writer.Write(temp.StockDspDiv);
            //コメント表示区分(問合せ)
            writer.Write(temp.CommentDspDiv);
            //出荷数表示区分(問合せ)
            writer.Write(temp.SpmtCntDspDiv);
            //受注数表示区分(問合せ)
            writer.Write(temp.AcptCntDspDiv);
            //部品選択品番表示区分(問合せ)
            writer.Write(temp.PrtSelGdNoDspDiv);
            //部品選択標準価格表示区分(問合せ)
            writer.Write(temp.PrtSelLsPrDspDiv);
            //部品選択棚番表示区分(問合せ)
            writer.Write(temp.PrtSelSelfDspDiv);
            //部品選択在庫表示区分(問合せ)
            writer.Write(temp.PrtSelStckDspDiv);
            //在庫状況マーク1
            writer.Write(temp.StckStMark1);
            //在庫状況マーク2
            writer.Write(temp.StckStMark2);
            //在庫状況マーク3
            writer.Write(temp.StckStMark3);
            //PCC発注先名称1
            writer.Write(temp.PccSuplName1);
            //PCC発注先名称2
            writer.Write(temp.PccSuplName2);
            //PCC発注先カナ名称
            writer.Write(temp.PccSuplKana);
            //PCC発注先略称
            writer.Write(temp.PccSuplSnm);
            //PCC発注先郵便番号
            writer.Write(temp.PccSuplPostNo);
            //PCC発注先住所1
            writer.Write(temp.PccSuplAddr1);
            //PCC発注先住所2
            writer.Write(temp.PccSuplAddr2);
            //PCC発注先住所3
            writer.Write(temp.PccSuplAddr3);
            //PCC発注先電話番号1
            writer.Write(temp.PccSuplTelNo1);
            //PCC発注先電話番号2
            writer.Write(temp.PccSuplTelNo2);
            //PCC発注先FAX番号
            writer.Write(temp.PccSuplFaxNo);
            //伝票発行区分（PCC）
            writer.Write(temp.PccSlipPrtDiv);
            //伝票再発行区分
            writer.Write(temp.PccSlipRePrtDiv);
            //部品選択優良表示区分
            writer.Write(temp.PrtSelPrmDspDiv);
            //在庫状況表示区分
            writer.Write(temp.StckStDspDiv);
            //在庫状況コメント1
            writer.Write(temp.StckStComment1);
            //在庫状況コメント2
            writer.Write(temp.StckStComment2);
            //在庫状況コメント3
            writer.Write(temp.StckStComment3);
            //倉庫表示区分(問合せ)
            writer.Write(temp.WarehouseDspDiv);
            //取消表示区分(問合せ)
            writer.Write(temp.CancelDspDiv);
            //品番表示区分(発注)
            writer.Write(temp.GoodsNoDspDivOd);
            //標準価格表示区分(発注)
            writer.Write(temp.ListPrcDspDivOd);
            //仕切価格表示区分(発注)
            writer.Write(temp.CostDspDivOd);
            //棚番表示区分(発注)
            writer.Write(temp.ShelfDspDivOd);
            //在庫表示区分(発注)
            writer.Write(temp.StockDspDivOd);
            //コメント表示区分(発注)
            writer.Write(temp.CommentDspDivOd);
            //出荷数表示区分(発注)
            writer.Write(temp.SpmtCntDspDivOd);
            //受注数表示区分(発注)
            writer.Write(temp.AcptCntDspDivOd);
            //部品選択品番表示区分(発注)
            writer.Write(temp.PrtSelGdNoDspDivOd);
            //部品選択標準価格表示区分(発注)
            writer.Write(temp.PrtSelLsPrDspDivOd);
            //部品選択棚番表示区分(発注)
            writer.Write(temp.PrtSelSelfDspDivOd);
            //部品選択在庫表示区分(発注)
            writer.Write(temp.PrtSelStckDspDivOd);
            //倉庫表示区分(発注)
            writer.Write(temp.WarehouseDspDivOd);
            //取消表示区分(発注)
            writer.Write(temp.CancelDspDivOd);
            //問合せ発注表示区分設定
            writer.Write(temp.InqOdrDspDivSet);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            writer.Write(temp.PccPriWarehouseCd4);
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            writer.Write(temp.PrsntStkCtDspDivOd);
            //現在庫数表示区分(問合せ)
            writer.Write(temp.PrsntStkCtDspDiv);
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            writer.Write(temp.AnsDeliDtDspDiv);
            // 回答納期表示区分(発注)
            writer.Write(temp.AnsDeliDtDspDivOd);
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

        }

        /// <summary>
        ///  PccCmpnyStWorkインスタンス取得
        /// </summary>
        /// <returns>PccCmpnyStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PccCmpnyStWork GetPccCmpnyStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PccCmpnyStWork temp = new PccCmpnyStWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //PCC自社コード
            temp.PccCompanyCode = reader.ReadInt32();
            //PCC倉庫コード
            temp.PccWarehouseCd = reader.ReadString();
            //PCC優先倉庫コード1
            temp.PccPriWarehouseCd1 = reader.ReadString();
            //PCC優先倉庫コード2
            temp.PccPriWarehouseCd2 = reader.ReadString();
            //PCC優先倉庫コード3
            temp.PccPriWarehouseCd3 = reader.ReadString();
            //品番表示区分(問合せ)
            temp.GoodsNoDspDiv = reader.ReadInt32();
            //標準価格表示区分(問合せ)
            temp.ListPrcDspDiv = reader.ReadInt32();
            //仕切価格表示区分(問合せ)
            temp.CostDspDiv = reader.ReadInt32();
            //棚番表示区分(問合せ)
            temp.ShelfDspDiv = reader.ReadInt32();
            //在庫表示区分(問合せ)
            temp.StockDspDiv = reader.ReadInt32();
            //コメント表示区分(問合せ)
            temp.CommentDspDiv = reader.ReadInt32();
            //出荷数表示区分(問合せ)
            temp.SpmtCntDspDiv = reader.ReadInt32();
            //受注数表示区分(問合せ)
            temp.AcptCntDspDiv = reader.ReadInt32();
            //部品選択品番表示区分(問合せ)
            temp.PrtSelGdNoDspDiv = reader.ReadInt32();
            //部品選択標準価格表示区分(問合せ)
            temp.PrtSelLsPrDspDiv = reader.ReadInt32();
            //部品選択棚番表示区分(問合せ)
            temp.PrtSelSelfDspDiv = reader.ReadInt32();
            //部品選択在庫表示区分(問合せ)
            temp.PrtSelStckDspDiv = reader.ReadInt32();
            //在庫状況マーク1
            temp.StckStMark1 = reader.ReadString();
            //在庫状況マーク2
            temp.StckStMark2 = reader.ReadString();
            //在庫状況マーク3
            temp.StckStMark3 = reader.ReadString();
            //PCC発注先名称1
            temp.PccSuplName1 = reader.ReadString();
            //PCC発注先名称2
            temp.PccSuplName2 = reader.ReadString();
            //PCC発注先カナ名称
            temp.PccSuplKana = reader.ReadString();
            //PCC発注先略称
            temp.PccSuplSnm = reader.ReadString();
            //PCC発注先郵便番号
            temp.PccSuplPostNo = reader.ReadString();
            //PCC発注先住所1
            temp.PccSuplAddr1 = reader.ReadString();
            //PCC発注先住所2
            temp.PccSuplAddr2 = reader.ReadString();
            //PCC発注先住所3
            temp.PccSuplAddr3 = reader.ReadString();
            //PCC発注先電話番号1
            temp.PccSuplTelNo1 = reader.ReadString();
            //PCC発注先電話番号2
            temp.PccSuplTelNo2 = reader.ReadString();
            //PCC発注先FAX番号
            temp.PccSuplFaxNo = reader.ReadString();
            //伝票発行区分（PCC）
            temp.PccSlipPrtDiv = reader.ReadInt32();
            //伝票再発行区分
            temp.PccSlipRePrtDiv = reader.ReadInt32();
            //部品選択優良表示区分
            temp.PrtSelPrmDspDiv = reader.ReadInt32();
            //在庫状況表示区分
            temp.StckStDspDiv = reader.ReadInt32();
            //在庫状況コメント1
            temp.StckStComment1 = reader.ReadString();
            //在庫状況コメント2
            temp.StckStComment2 = reader.ReadString();
            //在庫状況コメント3
            temp.StckStComment3 = reader.ReadString();
            //倉庫表示区分(問合せ)
            temp.WarehouseDspDiv = reader.ReadInt32();
            //取消表示区分(問合せ)
            temp.CancelDspDiv = reader.ReadInt32();
            //品番表示区分(発注)
            temp.GoodsNoDspDivOd = reader.ReadInt32();
            //標準価格表示区分(発注)
            temp.ListPrcDspDivOd = reader.ReadInt32();
            //仕切価格表示区分(発注)
            temp.CostDspDivOd = reader.ReadInt32();
            //棚番表示区分(発注)
            temp.ShelfDspDivOd = reader.ReadInt32();
            //在庫表示区分(発注)
            temp.StockDspDivOd = reader.ReadInt32();
            //コメント表示区分(発注)
            temp.CommentDspDivOd = reader.ReadInt32();
            //出荷数表示区分(発注)
            temp.SpmtCntDspDivOd = reader.ReadInt32();
            //受注数表示区分(発注)
            temp.AcptCntDspDivOd = reader.ReadInt32();
            //部品選択品番表示区分(発注)
            temp.PrtSelGdNoDspDivOd = reader.ReadInt32();
            //部品選択標準価格表示区分(発注)
            temp.PrtSelLsPrDspDivOd = reader.ReadInt32();
            //部品選択棚番表示区分(発注)
            temp.PrtSelSelfDspDivOd = reader.ReadInt32();
            //部品選択在庫表示区分(発注)
            temp.PrtSelStckDspDivOd = reader.ReadInt32();
            //倉庫表示区分(発注)
            temp.WarehouseDspDivOd = reader.ReadInt32();
            //取消表示区分(発注)
            temp.CancelDspDivOd = reader.ReadInt32();
            //問合せ発注表示区分設定
            temp.InqOdrDspDivSet = reader.ReadInt32();
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //PCC優先倉庫コード4
            temp.PccPriWarehouseCd4 = reader.ReadString();
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            //現在庫数表示区分(発注)
            temp.PrsntStkCtDspDivOd = reader.ReadInt16();
            //現在庫数表示区分(問合せ)
            temp.PrsntStkCtDspDiv = reader.ReadInt16();
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            // 回答納期表示区分(問合せ)
            temp.AnsDeliDtDspDiv = reader.ReadInt16();
            // 回答納期表示区分(発注)
            temp.AnsDeliDtDspDivOd = reader.ReadInt16();
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

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
        /// <returns>PccCmpnyStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PccCmpnyStWork temp = GetPccCmpnyStWork(reader, serInfo);
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
                    retValue = (PccCmpnyStWork[])lst.ToArray(typeof(PccCmpnyStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
