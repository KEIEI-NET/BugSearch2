using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCmpnySt
    /// <summary>
    ///                      BLP自社設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   BLP自社設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PccCmpnySt
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

        /// <summary>PCC自社名称</summary>
        /// <remarks>PMの得意先名称</remarks>
        private string _pccCompanyName = "";

        /// <summary>PCC倉庫コード</summary>
        private string _pccWarehouseCd = "";

        /// <summary>PCC倉庫名称</summary>
        private string _pccWarehouseNm = "";

        /// <summary>PCC優先倉庫コード1</summary>
        private string _pccPriWarehouseCd1 = "";

        /// <summary>PCC優先倉庫コード2</summary>
        private string _pccPriWarehouseCd2 = "";

        /// <summary>PCC優先倉庫コード3</summary>
        private string _pccPriWarehouseCd3 = "";

        /// <summary>品番表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _goodsNoDspDiv;

        /// <summary>品番表示区分名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _goodsNoDspDivName = "";

        /// <summary>標準価格表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _listPrcDspDiv;

        /// <summary>標準価格表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _listPrcDspDivName = "";

        /// <summary>仕切価格表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _costDspDiv;

        /// <summary>仕切価格表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _costDspDivName = "";

        /// <summary>棚番表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _shelfDspDiv;

        /// <summary>棚番表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _shelfDspDivName = "";

        /// <summary>在庫表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _stockDspDiv;

        /// <summary>在庫表示区分名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _stockDspDivName = "";

        /// <summary>コメント表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _commentDspDiv;

        /// <summary>コメント表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _commentDspDivName = "";

        /// <summary>出荷数表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _spmtCntDspDiv;

        /// <summary>出荷数表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _spmtCntDspDivName = "";

        /// <summary>受注数表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _acptCntDspDiv;

        /// <summary>受注数表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _acptCntDspDivName = "";

        /// <summary>部品選択品番表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelGdNoDspDiv;

        /// <summary>部品選択品番表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelGdNoDspDivName = "";

        /// <summary>部品選択標準価格表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelLsPrDspDiv;

        /// <summary>部品選択標準価格表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelLsPrDspDivName = "";

        /// <summary>部品選択棚番表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelSelfDspDiv;

        /// <summary>部品選択棚番表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelSelfDspDivName = "";

        /// <summary>部品選択在庫表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelStckDspDiv;

        /// <summary>部品選択在庫表示名称</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelStckDspDivName = "";

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

        /// <summary>伝票発行名称（PCC）</summary>
        /// <remarks>0:しない 1:回答 2:ﾘﾓｰﾄ 3:両方</remarks>
        private string _pccSlipPrtDivName = "";

        /// <summary>伝票再発行区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _pccSlipRePrtDiv;

        /// <summary>伝票再発行名称</summary>
        /// <remarks>0:しない 1:する</remarks>
        private string _pccSlipRePrtDivName = "";

        /// <summary>部品選択優良表示区分</summary>
        /// <remarks>0:全て 1:自社優先在庫 2:自社在庫</remarks>
        private Int32 _prtSelPrmDspDiv;

        /// <summary>部品選択優良表示名称</summary>
        /// <remarks>0:全て 1:自社優先在庫 2:自社在庫</remarks>
        private string _prtSelPrmDspDivName = "";

        /// <summary>在庫状況表示区分</summary>
        /// <remarks>0:マーク 1:現在庫数</remarks>
        private Int32 _stckStDspDiv;

        /// <summary>在庫状況表示名称</summary>
        /// <remarks>0:マーク 1:現在庫数</remarks>
        private string _stckStDspDivName = "";

        /// <summary>在庫コメント1</summary>
        private string _stckStComment1 = "";

        /// <summary>在庫コメント2</summary>
        private string _stckStComment2 = "";

        /// <summary>在庫コメント3</summary>
        private string _stckStComment3 = "";

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

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  PccCompanyName
        /// <summary>PCC自社名称プロパティ</summary>
        /// <value>PMの得意先名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC自社名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccCompanyName
        {
            get { return _pccCompanyName; }
            set { _pccCompanyName = value; }
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

        /// public propaty name  :  PccWarehouseNm
        /// <summary>PCC倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccWarehouseNm
        {
            get { return _pccWarehouseNm; }
            set { _pccWarehouseNm = value; }
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
        /// <summary>品番表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoDspDiv
        {
            get { return _goodsNoDspDiv; }
            set { _goodsNoDspDiv = value; }
        }

        /// public propaty name  :  GoodsNoDspDivName
        /// <summary>品番表示区分名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoDspDivName
        {
            get { return _goodsNoDspDivName; }
            set { _goodsNoDspDivName = value; }
        }

        /// public propaty name  :  ListPrcDspDiv
        /// <summary>標準価格表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPrcDspDiv
        {
            get { return _listPrcDspDiv; }
            set { _listPrcDspDiv = value; }
        }

        /// public propaty name  :  ListPrcDspDivName
        /// <summary>標準価格表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrcDspDivName
        {
            get { return _listPrcDspDivName; }
            set { _listPrcDspDivName = value; }
        }

        /// public propaty name  :  CostDspDiv
        /// <summary>仕切価格表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕切価格表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CostDspDiv
        {
            get { return _costDspDiv; }
            set { _costDspDiv = value; }
        }

        /// public propaty name  :  CostDspDivName
        /// <summary>仕切価格表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕切価格表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CostDspDivName
        {
            get { return _costDspDivName; }
            set { _costDspDivName = value; }
        }

        /// public propaty name  :  ShelfDspDiv
        /// <summary>棚番表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShelfDspDiv
        {
            get { return _shelfDspDiv; }
            set { _shelfDspDiv = value; }
        }

        /// public propaty name  :  ShelfDspDivName
        /// <summary>棚番表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShelfDspDivName
        {
            get { return _shelfDspDivName; }
            set { _shelfDspDivName = value; }
        }

        /// public propaty name  :  StockDspDiv
        /// <summary>在庫表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDspDiv
        {
            get { return _stockDspDiv; }
            set { _stockDspDiv = value; }
        }

        /// public propaty name  :  StockDspDivName
        /// <summary>在庫表示区分名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫表示区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDspDivName
        {
            get { return _stockDspDivName; }
            set { _stockDspDivName = value; }
        }

        /// public propaty name  :  CommentDspDiv
        /// <summary>コメント表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CommentDspDiv
        {
            get { return _commentDspDiv; }
            set { _commentDspDiv = value; }
        }

        /// public propaty name  :  CommentDspDivName
        /// <summary>コメント表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommentDspDivName
        {
            get { return _commentDspDivName; }
            set { _commentDspDivName = value; }
        }

        /// public propaty name  :  SpmtCntDspDiv
        /// <summary>出荷数表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SpmtCntDspDiv
        {
            get { return _spmtCntDspDiv; }
            set { _spmtCntDspDiv = value; }
        }

        /// public propaty name  :  SpmtCntDspDivName
        /// <summary>出荷数表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SpmtCntDspDivName
        {
            get { return _spmtCntDspDivName; }
            set { _spmtCntDspDivName = value; }
        }

        /// public propaty name  :  AcptCntDspDiv
        /// <summary>受注数表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptCntDspDiv
        {
            get { return _acptCntDspDiv; }
            set { _acptCntDspDiv = value; }
        }

        /// public propaty name  :  AcptCntDspDivName
        /// <summary>受注数表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcptCntDspDivName
        {
            get { return _acptCntDspDivName; }
            set { _acptCntDspDivName = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDiv
        /// <summary>部品選択品番表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelGdNoDspDiv
        {
            get { return _prtSelGdNoDspDiv; }
            set { _prtSelGdNoDspDiv = value; }
        }

        /// public propaty name  :  PrtSelGdNoDspDivName
        /// <summary>部品選択品番表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択品番表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelGdNoDspDivName
        {
            get { return _prtSelGdNoDspDivName; }
            set { _prtSelGdNoDspDivName = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDiv
        /// <summary>部品選択標準価格表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択標準価格表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelLsPrDspDiv
        {
            get { return _prtSelLsPrDspDiv; }
            set { _prtSelLsPrDspDiv = value; }
        }

        /// public propaty name  :  PrtSelLsPrDspDivName
        /// <summary>部品選択標準価格表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択標準価格表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelLsPrDspDivName
        {
            get { return _prtSelLsPrDspDivName; }
            set { _prtSelLsPrDspDivName = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDiv
        /// <summary>部品選択棚番表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択棚番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelSelfDspDiv
        {
            get { return _prtSelSelfDspDiv; }
            set { _prtSelSelfDspDiv = value; }
        }

        /// public propaty name  :  PrtSelSelfDspDivName
        /// <summary>部品選択棚番表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択棚番表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelSelfDspDivName
        {
            get { return _prtSelSelfDspDivName; }
            set { _prtSelSelfDspDivName = value; }
        }

        /// public propaty name  :  PrtSelStckDspDiv
        /// <summary>部品選択在庫表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択在庫表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrtSelStckDspDiv
        {
            get { return _prtSelStckDspDiv; }
            set { _prtSelStckDspDiv = value; }
        }

        /// public propaty name  :  PrtSelStckDspDivName
        /// <summary>部品選択在庫表示名称プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択在庫表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelStckDspDivName
        {
            get { return _prtSelStckDspDivName; }
            set { _prtSelStckDspDivName = value; }
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

        /// public propaty name  :  PccSlipPrtDivName
        /// <summary>伝票発行名称（PCC）プロパティ</summary>
        /// <value>0:しない 1:回答 2:ﾘﾓｰﾄ 3:両方</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行名称（PCC）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSlipPrtDivName
        {
            get { return _pccSlipPrtDivName; }
            set { _pccSlipPrtDivName = value; }
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

        /// public propaty name  :  PccSlipRePrtDivName
        /// <summary>伝票再発行名称プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票再発行名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccSlipRePrtDivName
        {
            get { return _pccSlipRePrtDivName; }
            set { _pccSlipRePrtDivName = value; }
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

        /// public propaty name  :  PrtSelPrmDspDivName
        /// <summary>部品選択優良表示名称プロパティ</summary>
        /// <value>0:全て 1:自社優先在庫 2:自社在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択優良表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelPrmDspDivName
        {
            get { return _prtSelPrmDspDivName; }
            set { _prtSelPrmDspDivName = value; }
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

        /// public propaty name  :  StckStDspDivName
        /// <summary>在庫状況表示名称プロパティ</summary>
        /// <value>0:マーク 1:現在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況表示名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStDspDivName
        {
            get { return _stckStDspDivName; }
            set { _stckStDspDivName = value; }
        }


        /// public propaty name  :  StckStComment1
        /// <summary>在庫コメント1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStComment1
        {
            get { return _stckStComment1; }
            set { _stckStComment1 = value; }
        }

        /// public propaty name  :  StckStComment2
        /// <summary>在庫コメント2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStComment2
        {
            get { return _stckStComment2; }
            set { _stckStComment2 = value; }
        }

        /// public propaty name  :  StckStComment3
        /// <summary>在庫コメント3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫コメント3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StckStComment3
        {
            get { return _stckStComment3; }
            set { _stckStComment3 = value; }
        }


        /// <summary>
        /// BLP自社設定マスタコンストラクタ
        /// </summary>
        /// <returns>PccCmpnyStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCmpnySt()
        {
        }

        /// <summary>
        /// BLP自社設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="pccCompanyCode">PCC自社コード(PMの得意先コード)</param>
        /// <param name="pccCompanyName">PCC自社名称(PMの得意先名称)</param>
        /// <param name="pccWarehouseCd">PCC倉庫コード</param>
        /// <param name="pccWarehouseNm">PCC倉庫名称</param>
        /// <param name="pccPriWarehouseCd1">PCC優先倉庫コード1</param>
        /// <param name="pccPriWarehouseCd2">PCC優先倉庫コード2</param>
        /// <param name="pccPriWarehouseCd3">PCC優先倉庫コード3</param>
        /// <param name="goodsNoDspDiv">品番表示区分(0:する 1:しない)</param>
        /// <param name="goodsNoDspDivName">品番表示区分名称(0:する 1:しない)</param>
        /// <param name="listPrcDspDiv">標準価格表示区分(0:する 1:しない)</param>
        /// <param name="listPrcDspDivName">標準価格表示名称(0:する 1:しない)</param>
        /// <param name="costDspDiv">仕切価格表示区分(0:する 1:しない)</param>
        /// <param name="costDspDivName">仕切価格表示名称(0:する 1:しない)</param>
        /// <param name="shelfDspDiv">棚番表示区分(0:する 1:しない)</param>
        /// <param name="shelfDspDivName">棚番表示名称(0:する 1:しない)</param>
        /// <param name="stockDspDiv">在庫表示区分(0:する 1:しない)</param>
        /// <param name="stockDspDivName">在庫表示区分名称(0:する 1:しない)</param>
        /// <param name="commentDspDiv">コメント表示区分(0:する 1:しない)</param>
        /// <param name="commentDspDivName">コメント表示名称(0:する 1:しない)</param>
        /// <param name="spmtCntDspDiv">出荷数表示区分(0:する 1:しない)</param>
        /// <param name="spmtCntDspDivName">出荷数表示名称(0:する 1:しない)</param>
        /// <param name="acptCntDspDiv">受注数表示区分(0:する 1:しない)</param>
        /// <param name="acptCntDspDivName">受注数表示名称(0:する 1:しない)</param>
        /// <param name="prtSelGdNoDspDiv">部品選択品番表示区分(0:する 1:しない)</param>
        /// <param name="prtSelGdNoDspDivName">部品選択品番表示名称(0:する 1:しない)</param>
        /// <param name="prtSelLsPrDspDiv">部品選択標準価格表示区分(0:する 1:しない)</param>
        /// <param name="prtSelLsPrDspDivName">部品選択標準価格表示名称(0:する 1:しない)</param>
        /// <param name="prtSelSelfDspDiv">部品選択棚番表示区分(0:する 1:しない)</param>
        /// <param name="prtSelSelfDspDivName">部品選択棚番表示名称(0:する 1:しない)</param>
        /// <param name="prtSelStckDspDiv">部品選択在庫表示区分(0:する 1:しない)</param>
        /// <param name="prtSelStckDspDivName">部品選択在庫表示名称(0:する 1:しない)</param>
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
        /// <param name="pccSlipPrtDivName">伝票発行名称（PCC）(0:しない 1:回答 2:ﾘﾓｰﾄ 3:両方)</param>
        /// <param name="pccSlipRePrtDiv">伝票再発行区分(0:しない 1:する)</param>
        /// <param name="pccSlipRePrtDivName">伝票再発行名称(0:しない 1:する)</param>
        /// <param name="prtSelPrmDspDiv">部品選択優良表示区分(0:全て 1:自社優先在庫 2:自社在庫)</param>
        /// <param name="prtSelPrmDspDivName">部品選択優良表示名称(0:全て 1:自社優先在庫 2:自社在庫)</param>
        /// <param name="stckStDspDiv">在庫状況表示区分(0:マーク 1:現在庫数)</param>
        /// <param name="stckStDspDivName">在庫状況表示名称(0:マーク 1:現在庫数)</param>
        /// <param name="stckStComment1">在庫コメント1</param>
        /// <param name="stckStComment2">在庫コメント2</param>
        /// <param name="stckStComment3">在庫コメント3</param>
        /// <returns>PccCmpnyStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._pccCompanyCode = pccCompanyCode;
            this._pccCompanyName = pccCompanyName;
            this._pccWarehouseCd = pccWarehouseCd;
            this._pccWarehouseNm = pccWarehouseNm;
            this._pccPriWarehouseCd1 = pccPriWarehouseCd1;
            this._pccPriWarehouseCd2 = pccPriWarehouseCd2;
            this._pccPriWarehouseCd3 = pccPriWarehouseCd3;
            this._goodsNoDspDiv = goodsNoDspDiv;
            this._goodsNoDspDivName = goodsNoDspDivName;
            this._listPrcDspDiv = listPrcDspDiv;
            this._listPrcDspDivName = listPrcDspDivName;
            this._costDspDiv = costDspDiv;
            this._costDspDivName = costDspDivName;
            this._shelfDspDiv = shelfDspDiv;
            this._shelfDspDivName = shelfDspDivName;
            this._stockDspDiv = stockDspDiv;
            this._stockDspDivName = stockDspDivName;
            this._commentDspDiv = commentDspDiv;
            this._commentDspDivName = commentDspDivName;
            this._spmtCntDspDiv = spmtCntDspDiv;
            this._spmtCntDspDivName = spmtCntDspDivName;
            this._acptCntDspDiv = acptCntDspDiv;
            this._acptCntDspDivName = acptCntDspDivName;
            this._prtSelGdNoDspDiv = prtSelGdNoDspDiv;
            this._prtSelGdNoDspDivName = prtSelGdNoDspDivName;
            this._prtSelLsPrDspDiv = prtSelLsPrDspDiv;
            this._prtSelLsPrDspDivName = prtSelLsPrDspDivName;
            this._prtSelSelfDspDiv = prtSelSelfDspDiv;
            this._prtSelSelfDspDivName = prtSelSelfDspDivName;
            this._prtSelStckDspDiv = prtSelStckDspDiv;
            this._prtSelStckDspDivName = prtSelStckDspDivName;
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
            this._pccSlipPrtDivName = pccSlipPrtDivName;
            this._pccSlipRePrtDiv = pccSlipRePrtDiv;
            this._pccSlipRePrtDivName = pccSlipRePrtDivName;
            this._prtSelPrmDspDiv = prtSelPrmDspDiv;
            this._prtSelPrmDspDivName = prtSelPrmDspDivName;
            this._stckStDspDiv = stckStDspDiv;
            this._stckStDspDivName = stckStDspDivName;
            this._stckStComment1 = stckStComment1;
            this._stckStComment2 = stckStComment2;
            this._stckStComment3 = stckStComment3;
        }

        /// <summary>
        /// BLP自社設定マスタ複製処理
        /// </summary>
        /// <returns>PccCmpnyStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccCmpnyStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCmpnySt Clone()
        {
            return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3);//@@@@20230303
        }

        /// <summary>
        /// BLP自社設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCmpnyStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccCmpnySt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccCompanyName == target.PccCompanyName)
                 && (this.PccWarehouseCd == target.PccWarehouseCd)
                 && (this.PccWarehouseNm == target.PccWarehouseNm)
                 && (this.PccPriWarehouseCd1 == target.PccPriWarehouseCd1)
                 && (this.PccPriWarehouseCd2 == target.PccPriWarehouseCd2)
                 && (this.PccPriWarehouseCd3 == target.PccPriWarehouseCd3)
                 && (this.GoodsNoDspDiv == target.GoodsNoDspDiv)
                 && (this.GoodsNoDspDivName == target.GoodsNoDspDivName)
                 && (this.ListPrcDspDiv == target.ListPrcDspDiv)
                 && (this.ListPrcDspDivName == target.ListPrcDspDivName)
                 && (this.CostDspDiv == target.CostDspDiv)
                 && (this.CostDspDivName == target.CostDspDivName)
                 && (this.ShelfDspDiv == target.ShelfDspDiv)
                 && (this.ShelfDspDivName == target.ShelfDspDivName)
                 && (this.StockDspDiv == target.StockDspDiv)
                 && (this.StockDspDivName == target.StockDspDivName)
                 && (this.CommentDspDiv == target.CommentDspDiv)
                 && (this.CommentDspDivName == target.CommentDspDivName)
                 && (this.SpmtCntDspDiv == target.SpmtCntDspDiv)
                 && (this.SpmtCntDspDivName == target.SpmtCntDspDivName)
                 && (this.AcptCntDspDiv == target.AcptCntDspDiv)
                 && (this.AcptCntDspDivName == target.AcptCntDspDivName)
                 && (this.PrtSelGdNoDspDiv == target.PrtSelGdNoDspDiv)
                 && (this.PrtSelGdNoDspDivName == target.PrtSelGdNoDspDivName)
                 && (this.PrtSelLsPrDspDiv == target.PrtSelLsPrDspDiv)
                 && (this.PrtSelLsPrDspDivName == target.PrtSelLsPrDspDivName)
                 && (this.PrtSelSelfDspDiv == target.PrtSelSelfDspDiv)
                 && (this.PrtSelSelfDspDivName == target.PrtSelSelfDspDivName)
                 && (this.PrtSelStckDspDiv == target.PrtSelStckDspDiv)
                 && (this.PrtSelStckDspDivName == target.PrtSelStckDspDivName)
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
                 && (this.PccSlipPrtDivName == target.PccSlipPrtDivName)
                 && (this.PccSlipRePrtDiv == target.PccSlipRePrtDiv)
                 && (this.PccSlipRePrtDivName == target.PccSlipRePrtDivName)
                 && (this.PrtSelPrmDspDiv == target.PrtSelPrmDspDiv)
                 && (this.PrtSelPrmDspDivName == target.PrtSelPrmDspDivName)
                 && (this.StckStDspDiv == target.StckStDspDiv)
                 && (this.StckStDspDivName == target.StckStDspDivName)
                 && (this.StckStComment1 == target.StckStComment1)
                 && (this.StckStComment2 == target.StckStComment2)
                 && (this.StckStComment3 == target.StckStComment3));
        }

        /// <summary>
        /// BLP自社設定マスタ比較処理
        /// </summary>
        /// <param name="pccCmpnySt1">
        ///                    比較するPccCmpnyStクラスのインスタンス
        /// </param>
        /// <param name="pccCmpnySt2">比較するPccCmpnyStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccCmpnySt pccCmpnySt1, PccCmpnySt pccCmpnySt2)
        {
            return ((pccCmpnySt1.CreateDateTime == pccCmpnySt2.CreateDateTime)
                 && (pccCmpnySt1.UpdateDateTime == pccCmpnySt2.UpdateDateTime)
                 && (pccCmpnySt1.LogicalDeleteCode == pccCmpnySt2.LogicalDeleteCode)
                 && (pccCmpnySt1.InqOriginalEpCd.Trim() == pccCmpnySt2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccCmpnySt1.InqOriginalSecCd == pccCmpnySt2.InqOriginalSecCd)
                 && (pccCmpnySt1.InqOtherEpCd == pccCmpnySt2.InqOtherEpCd)
                 && (pccCmpnySt1.InqOtherSecCd == pccCmpnySt2.InqOtherSecCd)
                 && (pccCmpnySt1.PccCompanyCode == pccCmpnySt2.PccCompanyCode)
                 && (pccCmpnySt1.PccCompanyName == pccCmpnySt2.PccCompanyName)
                 && (pccCmpnySt1.PccWarehouseCd == pccCmpnySt2.PccWarehouseCd)
                 && (pccCmpnySt1.PccWarehouseNm == pccCmpnySt2.PccWarehouseNm)
                 && (pccCmpnySt1.PccPriWarehouseCd1 == pccCmpnySt2.PccPriWarehouseCd1)
                 && (pccCmpnySt1.PccPriWarehouseCd2 == pccCmpnySt2.PccPriWarehouseCd2)
                 && (pccCmpnySt1.PccPriWarehouseCd3 == pccCmpnySt2.PccPriWarehouseCd3)
                 && (pccCmpnySt1.GoodsNoDspDiv == pccCmpnySt2.GoodsNoDspDiv)
                 && (pccCmpnySt1.GoodsNoDspDivName == pccCmpnySt2.GoodsNoDspDivName)
                 && (pccCmpnySt1.ListPrcDspDiv == pccCmpnySt2.ListPrcDspDiv)
                 && (pccCmpnySt1.ListPrcDspDivName == pccCmpnySt2.ListPrcDspDivName)
                 && (pccCmpnySt1.CostDspDiv == pccCmpnySt2.CostDspDiv)
                 && (pccCmpnySt1.CostDspDivName == pccCmpnySt2.CostDspDivName)
                 && (pccCmpnySt1.ShelfDspDiv == pccCmpnySt2.ShelfDspDiv)
                 && (pccCmpnySt1.ShelfDspDivName == pccCmpnySt2.ShelfDspDivName)
                 && (pccCmpnySt1.StockDspDiv == pccCmpnySt2.StockDspDiv)
                 && (pccCmpnySt1.StockDspDivName == pccCmpnySt2.StockDspDivName)
                 && (pccCmpnySt1.CommentDspDiv == pccCmpnySt2.CommentDspDiv)
                 && (pccCmpnySt1.CommentDspDivName == pccCmpnySt2.CommentDspDivName)
                 && (pccCmpnySt1.SpmtCntDspDiv == pccCmpnySt2.SpmtCntDspDiv)
                 && (pccCmpnySt1.SpmtCntDspDivName == pccCmpnySt2.SpmtCntDspDivName)
                 && (pccCmpnySt1.AcptCntDspDiv == pccCmpnySt2.AcptCntDspDiv)
                 && (pccCmpnySt1.AcptCntDspDivName == pccCmpnySt2.AcptCntDspDivName)
                 && (pccCmpnySt1.PrtSelGdNoDspDiv == pccCmpnySt2.PrtSelGdNoDspDiv)
                 && (pccCmpnySt1.PrtSelGdNoDspDivName == pccCmpnySt2.PrtSelGdNoDspDivName)
                 && (pccCmpnySt1.PrtSelLsPrDspDiv == pccCmpnySt2.PrtSelLsPrDspDiv)
                 && (pccCmpnySt1.PrtSelLsPrDspDivName == pccCmpnySt2.PrtSelLsPrDspDivName)
                 && (pccCmpnySt1.PrtSelSelfDspDiv == pccCmpnySt2.PrtSelSelfDspDiv)
                 && (pccCmpnySt1.PrtSelSelfDspDivName == pccCmpnySt2.PrtSelSelfDspDivName)
                 && (pccCmpnySt1.PrtSelStckDspDiv == pccCmpnySt2.PrtSelStckDspDiv)
                 && (pccCmpnySt1.PrtSelStckDspDivName == pccCmpnySt2.PrtSelStckDspDivName)
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
                 && (pccCmpnySt1.PccSlipPrtDivName == pccCmpnySt2.PccSlipPrtDivName)
                 && (pccCmpnySt1.PccSlipRePrtDiv == pccCmpnySt2.PccSlipRePrtDiv)
                 && (pccCmpnySt1.PccSlipRePrtDivName == pccCmpnySt2.PccSlipRePrtDivName)
                 && (pccCmpnySt1.PrtSelPrmDspDiv == pccCmpnySt2.PrtSelPrmDspDiv)
                 && (pccCmpnySt1.PrtSelPrmDspDivName == pccCmpnySt2.PrtSelPrmDspDivName)
                 && (pccCmpnySt1.StckStDspDiv == pccCmpnySt2.StckStDspDiv)
                 && (pccCmpnySt1.StckStDspDivName == pccCmpnySt2.StckStDspDivName)
                 && (pccCmpnySt1.StckStComment1 == pccCmpnySt2.StckStComment1)
                 && (pccCmpnySt1.StckStComment2 == pccCmpnySt2.StckStComment2)
                 && (pccCmpnySt1.StckStComment3 == pccCmpnySt2.StckStComment3));
        }
        /// <summary>
        /// BLP自社設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccCmpnyStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccCmpnySt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccCompanyName != target.PccCompanyName) resList.Add("PccCompanyName");
            if (this.PccWarehouseCd != target.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (this.PccWarehouseNm != target.PccWarehouseNm) resList.Add("PccWarehouseNm");
            if (this.PccPriWarehouseCd1 != target.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (this.PccPriWarehouseCd2 != target.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (this.PccPriWarehouseCd3 != target.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (this.GoodsNoDspDiv != target.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (this.GoodsNoDspDivName != target.GoodsNoDspDivName) resList.Add("GoodsNoDspDivName");
            if (this.ListPrcDspDiv != target.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (this.ListPrcDspDivName != target.ListPrcDspDivName) resList.Add("ListPrcDspDivName");
            if (this.CostDspDiv != target.CostDspDiv) resList.Add("CostDspDiv");
            if (this.CostDspDivName != target.CostDspDivName) resList.Add("CostDspDivName");
            if (this.ShelfDspDiv != target.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (this.ShelfDspDivName != target.ShelfDspDivName) resList.Add("ShelfDspDivName");
            if (this.StockDspDiv != target.StockDspDiv) resList.Add("StockDspDiv");
            if (this.StockDspDivName != target.StockDspDivName) resList.Add("StockDspDivName");
            if (this.CommentDspDiv != target.CommentDspDiv) resList.Add("CommentDspDiv");
            if (this.CommentDspDivName != target.CommentDspDivName) resList.Add("CommentDspDivName");
            if (this.SpmtCntDspDiv != target.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (this.SpmtCntDspDivName != target.SpmtCntDspDivName) resList.Add("SpmtCntDspDivName");
            if (this.AcptCntDspDiv != target.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (this.AcptCntDspDivName != target.AcptCntDspDivName) resList.Add("AcptCntDspDivName");
            if (this.PrtSelGdNoDspDiv != target.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (this.PrtSelGdNoDspDivName != target.PrtSelGdNoDspDivName) resList.Add("PrtSelGdNoDspDivName");
            if (this.PrtSelLsPrDspDiv != target.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (this.PrtSelLsPrDspDivName != target.PrtSelLsPrDspDivName) resList.Add("PrtSelLsPrDspDivName");
            if (this.PrtSelSelfDspDiv != target.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (this.PrtSelSelfDspDivName != target.PrtSelSelfDspDivName) resList.Add("PrtSelSelfDspDivName");
            if (this.PrtSelStckDspDiv != target.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (this.PrtSelStckDspDivName != target.PrtSelStckDspDivName) resList.Add("PrtSelStckDspDivName");
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
            if (this.PccSlipPrtDivName != target.PccSlipPrtDivName) resList.Add("PccSlipPrtDivName");
            if (this.PccSlipRePrtDiv != target.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (this.PccSlipRePrtDivName != target.PccSlipRePrtDivName) resList.Add("PccSlipRePrtDivName");
            if (this.PrtSelPrmDspDiv != target.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (this.PrtSelPrmDspDivName != target.PrtSelPrmDspDivName) resList.Add("PrtSelPrmDspDivName");
            if (this.StckStDspDiv != target.StckStDspDiv) resList.Add("StckStDspDiv");
            if (this.StckStDspDivName != target.StckStDspDivName) resList.Add("StckStDspDivName");
            if (this.StckStComment1 != target.StckStComment1) resList.Add("StckStComment1");
            if (this.StckStComment2 != target.StckStComment2) resList.Add("StckStComment2");
            if (this.StckStComment3 != target.StckStComment3) resList.Add("StckStComment3");

            return resList;
        }

        /// <summary>
        /// BLP自社設定マスタ比較処理
        /// </summary>
        /// <param name="pccCmpnySt1">比較するPccCmpnyStクラスのインスタンス</param>
        /// <param name="pccCmpnySt2">比較するPccCmpnyStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccCmpnySt pccCmpnySt1, PccCmpnySt pccCmpnySt2)
        {
            ArrayList resList = new ArrayList();
            if (pccCmpnySt1.CreateDateTime != pccCmpnySt2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccCmpnySt1.UpdateDateTime != pccCmpnySt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccCmpnySt1.LogicalDeleteCode != pccCmpnySt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccCmpnySt1.InqOriginalEpCd.Trim() != pccCmpnySt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccCmpnySt1.InqOriginalSecCd != pccCmpnySt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccCmpnySt1.InqOtherEpCd != pccCmpnySt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccCmpnySt1.InqOtherSecCd != pccCmpnySt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccCmpnySt1.PccCompanyCode != pccCmpnySt2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccCmpnySt1.PccCompanyName != pccCmpnySt2.PccCompanyName) resList.Add("PccCompanyName");
            if (pccCmpnySt1.PccWarehouseCd != pccCmpnySt2.PccWarehouseCd) resList.Add("PccWarehouseCd");
            if (pccCmpnySt1.PccWarehouseNm != pccCmpnySt2.PccWarehouseNm) resList.Add("PccWarehouseNm");
            if (pccCmpnySt1.PccPriWarehouseCd1 != pccCmpnySt2.PccPriWarehouseCd1) resList.Add("PccPriWarehouseCd1");
            if (pccCmpnySt1.PccPriWarehouseCd2 != pccCmpnySt2.PccPriWarehouseCd2) resList.Add("PccPriWarehouseCd2");
            if (pccCmpnySt1.PccPriWarehouseCd3 != pccCmpnySt2.PccPriWarehouseCd3) resList.Add("PccPriWarehouseCd3");
            if (pccCmpnySt1.GoodsNoDspDiv != pccCmpnySt2.GoodsNoDspDiv) resList.Add("GoodsNoDspDiv");
            if (pccCmpnySt1.GoodsNoDspDivName != pccCmpnySt2.GoodsNoDspDivName) resList.Add("GoodsNoDspDivName");
            if (pccCmpnySt1.ListPrcDspDiv != pccCmpnySt2.ListPrcDspDiv) resList.Add("ListPrcDspDiv");
            if (pccCmpnySt1.ListPrcDspDivName != pccCmpnySt2.ListPrcDspDivName) resList.Add("ListPrcDspDivName");
            if (pccCmpnySt1.CostDspDiv != pccCmpnySt2.CostDspDiv) resList.Add("CostDspDiv");
            if (pccCmpnySt1.CostDspDivName != pccCmpnySt2.CostDspDivName) resList.Add("CostDspDivName");
            if (pccCmpnySt1.ShelfDspDiv != pccCmpnySt2.ShelfDspDiv) resList.Add("ShelfDspDiv");
            if (pccCmpnySt1.ShelfDspDivName != pccCmpnySt2.ShelfDspDivName) resList.Add("ShelfDspDivName");
            if (pccCmpnySt1.StockDspDiv != pccCmpnySt2.StockDspDiv) resList.Add("StockDspDiv");
            if (pccCmpnySt1.StockDspDivName != pccCmpnySt2.StockDspDivName) resList.Add("StockDspDivName");
            if (pccCmpnySt1.CommentDspDiv != pccCmpnySt2.CommentDspDiv) resList.Add("CommentDspDiv");
            if (pccCmpnySt1.CommentDspDivName != pccCmpnySt2.CommentDspDivName) resList.Add("CommentDspDivName");
            if (pccCmpnySt1.SpmtCntDspDiv != pccCmpnySt2.SpmtCntDspDiv) resList.Add("SpmtCntDspDiv");
            if (pccCmpnySt1.SpmtCntDspDivName != pccCmpnySt2.SpmtCntDspDivName) resList.Add("SpmtCntDspDivName");
            if (pccCmpnySt1.AcptCntDspDiv != pccCmpnySt2.AcptCntDspDiv) resList.Add("AcptCntDspDiv");
            if (pccCmpnySt1.AcptCntDspDivName != pccCmpnySt2.AcptCntDspDivName) resList.Add("AcptCntDspDivName");
            if (pccCmpnySt1.PrtSelGdNoDspDiv != pccCmpnySt2.PrtSelGdNoDspDiv) resList.Add("PrtSelGdNoDspDiv");
            if (pccCmpnySt1.PrtSelGdNoDspDivName != pccCmpnySt2.PrtSelGdNoDspDivName) resList.Add("PrtSelGdNoDspDivName");
            if (pccCmpnySt1.PrtSelLsPrDspDiv != pccCmpnySt2.PrtSelLsPrDspDiv) resList.Add("PrtSelLsPrDspDiv");
            if (pccCmpnySt1.PrtSelLsPrDspDivName != pccCmpnySt2.PrtSelLsPrDspDivName) resList.Add("PrtSelLsPrDspDivName");
            if (pccCmpnySt1.PrtSelSelfDspDiv != pccCmpnySt2.PrtSelSelfDspDiv) resList.Add("PrtSelSelfDspDiv");
            if (pccCmpnySt1.PrtSelSelfDspDivName != pccCmpnySt2.PrtSelSelfDspDivName) resList.Add("PrtSelSelfDspDivName");
            if (pccCmpnySt1.PrtSelStckDspDiv != pccCmpnySt2.PrtSelStckDspDiv) resList.Add("PrtSelStckDspDiv");
            if (pccCmpnySt1.PrtSelStckDspDivName != pccCmpnySt2.PrtSelStckDspDivName) resList.Add("PrtSelStckDspDivName");
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
            if (pccCmpnySt1.PccSlipPrtDivName != pccCmpnySt2.PccSlipPrtDivName) resList.Add("PccSlipPrtDivName");
            if (pccCmpnySt1.PccSlipRePrtDiv != pccCmpnySt2.PccSlipRePrtDiv) resList.Add("PccSlipRePrtDiv");
            if (pccCmpnySt1.PccSlipRePrtDivName != pccCmpnySt2.PccSlipRePrtDivName) resList.Add("PccSlipRePrtDivName");
            if (pccCmpnySt1.PrtSelPrmDspDiv != pccCmpnySt2.PrtSelPrmDspDiv) resList.Add("PrtSelPrmDspDiv");
            if (pccCmpnySt1.PrtSelPrmDspDivName != pccCmpnySt2.PrtSelPrmDspDivName) resList.Add("PrtSelPrmDspDivName");
            if (pccCmpnySt1.StckStDspDiv != pccCmpnySt2.StckStDspDiv) resList.Add("StckStDspDiv");
            if (pccCmpnySt1.StckStDspDivName != pccCmpnySt2.StckStDspDivName) resList.Add("StckStDspDivName");
            if (pccCmpnySt1.StckStComment1 != pccCmpnySt2.StckStComment1) resList.Add("StckStComment1");
            if (pccCmpnySt1.StckStComment2 != pccCmpnySt2.StckStComment2) resList.Add("StckStComment2");
            if (pccCmpnySt1.StckStComment3 != pccCmpnySt2.StckStComment3) resList.Add("StckStComment3");

            return resList;
        }
    }
}
