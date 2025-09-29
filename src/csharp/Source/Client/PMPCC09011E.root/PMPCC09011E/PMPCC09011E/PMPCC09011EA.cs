using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccCmpnySt
    /// <summary>
    ///                      PCC自社設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   PCC自社設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Genarated Date   :   2011/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   湯上</br>
    /// <br>Date             :   2013/02/12</br>
    /// <br>Update Note      :   2013/03/06配信　SCM障害№10342,10343対応</br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   湯上</br>
    /// <br>Date             :   2013/09/13</br>
    /// <br>Update Note      :   SCM仕掛一覧№10571対応 参照倉庫コード追加</br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   鄧潘ハン</br>
    /// <br>Date             :   2014/07/23</br>
    /// <br>Update Note      :   SCM仕掛一覧№10659の1現在庫数表示区分の追加</br>
    /// --------------------------------------------------------------------------
    /// <br>Programmer       :   30746 高川 悟</br>
    /// <br>Date             :   2014/09/04</br>
    /// <br>Update Note      :   SCM仕掛一覧№10678対応　回答納期表示区分追加</br>
    /// --------------------------------------------------------------------------
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

        // ADD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
        /// <summary>倉庫表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _warehouseDspDiv;

        /// <summary>倉庫表示区分名称(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _warehouseDspDivName = "";

        /// <summary>取消表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _cancelDspDiv;

        /// <summary>取消表示区分名称(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _cancelDspDivName = "";

        /// <summary>品番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _goodsNoDspDivOd;

        /// <summary>品番表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _goodsNoDspDivOdName = "";

        /// <summary>標準価格表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _listPrcDspDivOd;

        /// <summary>標準価格表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _listPrcDspDivOdName = "";

        /// <summary>仕切価格表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _costDspDivOd;

        /// <summary>仕切価格表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _costDspDivOdName = "";

        /// <summary>棚番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _shelfDspDivOd;

        /// <summary>棚番表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _shelfDspDivOdName = "";

        /// <summary>在庫表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _stockDspDivOd;

        /// <summary>在庫表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _stockDspDivOdName = "";

        /// <summary>コメント表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _commentDspDivOd;

        /// <summary>コメント表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _commentDspDivOdName = "";

        /// <summary>出荷数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _spmtCntDspDivOd;

        /// <summary>出荷数表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _spmtCntDspDivOdName = "";

        /// <summary>受注数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _acptCntDspDivOd;

        /// <summary>受注数表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _acptCntDspDivOdName = "";

        /// <summary>部品選択品番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelGdNoDspDivOd;

        /// <summary>部品選択品番表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelGdNoDspDivOdName = "";

        /// <summary>部品選択標準価格表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelLsPrDspDivOd;

        /// <summary>部品選択標準価格表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelLsPrDspDivOdName = "";

        /// <summary>部品選択棚番表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelSelfDspDivOd;

        /// <summary>部品選択棚番表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelSelfDspDivOdName = "";

        /// <summary>部品選択在庫表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _prtSelStckDspDivOd;

        /// <summary>部品選択在庫表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prtSelStckDspDivOdName = "";

        /// <summary>倉庫表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _warehouseDspDivOd;

        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
        /// <summary>現在庫数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _prsntStkCtDspDivOd;

        /// <summary>現在庫数表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prsntStkCtDspDivOdName;

        /// <summary>現在庫数表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _prsntStkCtDspDiv;

        /// <summary>現在庫数表示区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _prsntStkCtDspDivName;
        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

        /// <summary>倉庫表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _warehouseDspDivOdName = "";

        /// <summary>取消表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _cancelDspDivOd;

        /// <summary>取消表示区分名称(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private string _cancelDspDivOdName = "";

        /// <summary>問合せ発注表示区分設定</summary>
        /// <remarks>0:問合せ発注共通 1:問合せ発注個別</remarks>
        private Int32 _inqOdrDspDivSet;

        /// <summary>問合せ発注表示区分設定</summary>
        /// <remarks>0:問合せ発注共通 1:問合せ発注個別</remarks>
        private string _inqOdrDspDivSetName = "";
        // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        /// <summary>PCC優先倉庫コード4</summary>
        private string _pccPriWarehouseCd4 = "";
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        /// <summary>回答納期表示区分(問合せ)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _ansDeliDtDspDiv;

        /// <summary>回答納期表示区分名称(問合せ)</summary>
        private string _ansDeliDtDspDivName = "";

        /// <summary>回答納期表示区分(発注)</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int16 _ansDeliDtDspDivOd;

        /// <summary>回答納期表示区分名称(発注)</summary>
        private string _ansDeliDtDspDivOdName = "";
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

        /// public propaty name  :  PrsntStkCtDspDivOdName
        /// <summary>現在庫数表示区分(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数表示区分(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrsntStkCtDspDivOdName
        {
            get { return _prsntStkCtDspDivOdName; }
            set { _prsntStkCtDspDivOdName = value; }
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

        /// public propaty name  :  PrsntStkCtDspDivOdName
        /// <summary>現在庫数表示区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫数表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrsntStkCtDspDivName
        {
            get { return _prsntStkCtDspDivName; }
            set { _prsntStkCtDspDivName = value; }
        }
        // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

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

        // ADD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
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


        /// public propaty name  :  WarehouseDspDivName
        /// <summary>倉庫表示区分名称(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫表示区分名称(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseDspDivName
        {
            get { return _warehouseDspDivName; }
            set { _warehouseDspDivName = value; }
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


        /// public propaty name  :  CancelDspDivName
        /// <summary>取消表示区分名称(問合せ)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取消表示区分名称(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CancelDspDivName
        {
            get { return _cancelDspDivName; }
            set { _cancelDspDivName = value; }
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

        /// public propaty name  :  GoodsNoDspDivOdName
        /// <summary>品番表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoDspDivOdName
        {
            get { return _goodsNoDspDivOdName; }
            set { _goodsNoDspDivOdName = value; }
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

        /// public propaty name  :  ListPrcDspDivOdName
        /// <summary>標準価格表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ListPrcDspDivOdName
        {
            get { return _listPrcDspDivOdName; }
            set { _listPrcDspDivOdName = value; }
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

        /// public propaty name  :  CostDspDivOdName
        /// <summary>仕切価格表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕切価格表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CostDspDivOdName
        {
            get { return _costDspDivOdName; }
            set { _costDspDivOdName = value; }
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

        /// public propaty name  :  ShelfDspDivOdName
        /// <summary>棚番表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShelfDspDivOdName
        {
            get { return _shelfDspDivOdName; }
            set { _shelfDspDivOdName = value; }
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

        /// public propaty name  :  StockDspDivOdName
        /// <summary>在庫表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockDspDivOdName
        {
            get { return _stockDspDivOdName; }
            set { _stockDspDivOdName = value; }
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

        /// public propaty name  :  CommentDspDivOdName
        /// <summary>コメント表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コメント表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommentDspDivOdName
        {
            get { return _commentDspDivOdName; }
            set { _commentDspDivOdName = value; }
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


        /// public propaty name  :  SpmtCntDspDivOdName
        /// <summary>出荷数表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SpmtCntDspDivOdName
        {
            get { return _spmtCntDspDivOdName; }
            set { _spmtCntDspDivOdName = value; }
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

        /// public propaty name  :  AcptCntDspDivOdName
        /// <summary>受注数表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcptCntDspDivOdName
        {
            get { return _acptCntDspDivOdName; }
            set { _acptCntDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelGdNoDspDivOdName
        /// <summary>部品選択品番表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択品番表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelGdNoDspDivOdName
        {
            get { return _prtSelGdNoDspDivOdName; }
            set { _prtSelGdNoDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelLsPrDspDivOdName
        /// <summary>部品選択標準価格表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択標準価格表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelLsPrDspDivOdName
        {
            get { return _prtSelLsPrDspDivOdName; }
            set { _prtSelLsPrDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelSelfDspDivOdName
        /// <summary>部品選択棚番表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択棚番表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelSelfDspDivOdName
        {
            get { return _prtSelSelfDspDivOdName; }
            set { _prtSelSelfDspDivOdName = value; }
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

        /// public propaty name  :  PrtSelStckDspDivOdName
        /// <summary>部品選択在庫表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品選択在庫表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtSelStckDspDivOdName
        {
            get { return _prtSelStckDspDivOdName; }
            set { _prtSelStckDspDivOdName = value; }
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

        /// public propaty name  :  WarehouseDspDivOdName
        /// <summary>倉庫表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseDspDivOdName
        {
            get { return _warehouseDspDivOdName; }
            set { _warehouseDspDivOdName = value; }
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

        /// public propaty name  :  CancelDspDivOdName
        /// <summary>取消表示区分名称(発注)プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取消表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CancelDspDivOdName
        {
            get { return _cancelDspDivOdName; }
            set { _cancelDspDivOdName = value; }
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

        /// public propaty name  :  InqOdrDspDivSetName
        /// <summary>問合せ発注表示区分設定名称プロパティ</summary>
        /// <value>0:問合せ発注共通 1:問合せ発注個別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ発注表示区分設定名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOdrDspDivSetName
        {
            get { return _inqOdrDspDivSetName; }
            set { _inqOdrDspDivSetName = value; }
        }
        // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

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

        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        /// public propaty name  :  AnsDeliDtDspDiv
        /// <summary>回答納期表示区分(問合せ)プロパティ</summary>
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

        /// public propaty name  :  AnsDeliDtDspDivName
        /// <summary>回答納期表示区分名称(問合せ)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期表示区分名称(問合せ)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsDeliDtDspDivName
        {
            get { return _ansDeliDtDspDivName; }
            set { _ansDeliDtDspDivName = value; }
        }

        /// public propaty name  :  AnsDeliDtDspDivOd
        /// <summary>回答納期表示区分(発注)プロパティ</summary>
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

        /// public propaty name  :  AnsDeliDtDspDivOdName
        /// <summary>回答納期表示区分名称(発注)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期表示区分名称(発注)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsDeliDtDspDivOdName
        {
            get { return _ansDeliDtDspDivOdName; }
            set { _ansDeliDtDspDivOdName = value; }
        }
        // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

        /// <summary>
        /// PCC自社設定マスタコンストラクタ
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
        /// PCC自社設定マスタコンストラクタ
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
        /// <param name="warehouseDspDiv">倉庫表示区分(問合せ)</param>
        /// <param name="cancelDspDiv">取消表示区分(問合せ)</param>
        /// <param name="goodsNoDspDivOd">品番表示区分(発注)</param>
        /// <param name="listPrcDspDivOd">標準価格表示区分(発注)</param>
        /// <param name="costDspDivOd">仕切価格表示区分(発注)</param>
        /// <param name="shelfDspDivOd">棚番表示区分(発注)</param>
        /// <param name="stockDspDivOd">在庫表示区分(発注)</param>
        /// <param name="commentDspDivOd">コメント表示区分(発注)</param>
        /// <param name="spmtCntDspDivOd">出荷数表示区分(発注)</param>
        /// <param name="acptCntDspDivOd">受注数表示区分(発注)</param>
        /// <param name="prtSelGdNoDspDivOd">部品選択品番表示区分(発注)</param>
        /// <param name="prtSelLsPrDspDivOd">部品選択標準価格表示区分(発注)</param>
        /// <param name="prtSelSelfDspDivOd">部品選択棚番表示区分(発注)</param>
        /// <param name="prtSelStckDspDivOd">部品選択在庫表示区分(発注)</param>
        /// <param name="warehouseDspDivOd">倉庫表示区分(発注)</param>
        /// <param name="cancelDspDivOd">取消表示区分(発注)</param>
        /// <param name="inqOdrDspDivSet">問合せ発注表示区分設定</param>
        /// <param name="pccPriWarehouseCd4">PCC優先倉庫コード4</param>
        /// <param name="prsntStkCtDspDivOd">現在庫数表示区分(発注)</param>
        /// <param name="prsntStkCtDspDivOdName">現在庫数表示区分(発注)名称</param>
        /// <param name="prsntStkCtDspDiv">現在庫数表示区分</param>
        /// <param name="prsntStkCtDspDivName">現在庫数表示区分名称</param>
        /// <param name="ansDeliDtDspDiv">回答納期表示区分(問合せ)</param>
        /// <param name="ansDeliDtDspDivName">回答納期表示区分名称(問合せ)</param>
        /// <param name="ansDeliDtDspDivOd">回答納期表示区分(発注)</param>
        /// <param name="ansDeliDtDspDivOdName">回答納期表示区分名称(発注)</param>
        /// <returns>PccCmpnyStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccCmpnyStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // UPD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信 -------------------------------------------->>>>>
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3)
        // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName)
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName, string pccPriWarehouseCd4)// DEL 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
        // UPD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
        // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
        //public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, string prsntStkCtDspDivOdName, Int16 prsntStkCtDspDiv, string prsntStkCtDspDivName)// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
        public PccCmpnySt(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int32 pccCompanyCode, string pccCompanyName, string pccWarehouseCd, string pccWarehouseNm, string pccPriWarehouseCd1, string pccPriWarehouseCd2, string pccPriWarehouseCd3, Int32 goodsNoDspDiv, string goodsNoDspDivName, Int32 listPrcDspDiv, string listPrcDspDivName, Int32 costDspDiv, string costDspDivName, Int32 shelfDspDiv, string shelfDspDivName, Int32 stockDspDiv, string stockDspDivName, Int32 commentDspDiv, string commentDspDivName, Int32 spmtCntDspDiv, string spmtCntDspDivName, Int32 acptCntDspDiv, string acptCntDspDivName, Int32 prtSelGdNoDspDiv, string prtSelGdNoDspDivName, Int32 prtSelLsPrDspDiv, string prtSelLsPrDspDivName, Int32 prtSelSelfDspDiv, string prtSelSelfDspDivName, Int32 prtSelStckDspDiv, string prtSelStckDspDivName, string stckStMark1, string stckStMark2, string stckStMark3, string pccSuplName1, string pccSuplName2, string pccSuplKana, string pccSuplSnm, string pccSuplPostNo, string pccSuplAddr1, string pccSuplAddr2, string pccSuplAddr3, string pccSuplTelNo1, string pccSuplTelNo2, string pccSuplFaxNo, Int32 pccSlipPrtDiv, string pccSlipPrtDivName, Int32 pccSlipRePrtDiv, string pccSlipRePrtDivName, Int32 prtSelPrmDspDiv, string prtSelPrmDspDivName, Int32 stckStDspDiv, string stckStDspDivName, string stckStComment1, string stckStComment2, string stckStComment3, Int32 warehouseDspDiv, Int32 cancelDspDiv, Int32 goodsNoDspDivOd, Int32 listPrcDspDivOd, Int32 costDspDivOd, Int32 shelfDspDivOd, Int32 stockDspDivOd, Int32 commentDspDivOd, Int32 spmtCntDspDivOd, Int32 acptCntDspDivOd, Int32 prtSelGdNoDspDivOd, Int32 prtSelLsPrDspDivOd, Int32 prtSelSelfDspDivOd, Int32 prtSelStckDspDivOd, Int32 warehouseDspDivOd, Int32 cancelDspDivOd, Int32 inqOdrDspDivSet, string warehouseDspDivName, string cancelDspDivName, string goodsNoDspDivOdName, string listPrcDspDivOdName, string costDspDivOdName, string shelfDspDivOdName, string stockDspDivOdName, string commentDspDivOdName, string spmtCntDspDivOdName, string acptCntDspDivOdName, string prtSelGdNoDspDivOdName, string prtSelLsPrDspDivOdName, string prtSelSelfDspDivOdName, string prtSelStckDspDivOdName, string warehouseDspDivOdName, string cancelDspDivOdName, string inqOdrDspDivSetName, string pccPriWarehouseCd4, Int16 prsntStkCtDspDivOd, string prsntStkCtDspDivOdName, Int16 prsntStkCtDspDiv, string prsntStkCtDspDivName, Int16 ansDeliDtDspDiv, string ansDeliDtDspDivName, Int16 ansDeliDtDspDivOd, string ansDeliDtDspDivOdName)
        // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
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
            // ADD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
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
            this._warehouseDspDivName = warehouseDspDivName;
            this._cancelDspDivName = cancelDspDivName;
            this._goodsNoDspDivOdName = goodsNoDspDivOdName;
            this._listPrcDspDivOdName = listPrcDspDivOdName;
            this._costDspDivOdName = costDspDivOdName;
            this._shelfDspDivOdName = shelfDspDivOdName;
            this._stockDspDivOdName = stockDspDivOdName;
            this._commentDspDivOdName = commentDspDivOdName;
            this._spmtCntDspDivOdName = spmtCntDspDivOdName;
            this._acptCntDspDivOdName = acptCntDspDivOdName;
            this._prtSelGdNoDspDivOdName = prtSelGdNoDspDivOdName;
            this._prtSelLsPrDspDivOdName = prtSelLsPrDspDivOdName;
            this._prtSelSelfDspDivOdName = prtSelSelfDspDivOdName;
            this._prtSelStckDspDivOdName = prtSelStckDspDivOdName;
            this._warehouseDspDivOdName = warehouseDspDivOdName;
            this._cancelDspDivOdName = cancelDspDivOdName;
            this._inqOdrDspDivSetName = inqOdrDspDivSetName;
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            this._pccPriWarehouseCd4 = pccPriWarehouseCd4;
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            this._prsntStkCtDspDivOd = prsntStkCtDspDivOd;
            this._prsntStkCtDspDivOdName = prsntStkCtDspDivOdName;
            this._prsntStkCtDspDiv = prsntStkCtDspDiv;
            this._prsntStkCtDspDivName = prsntStkCtDspDivName;
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            this._ansDeliDtDspDiv = ansDeliDtDspDiv;
            this._ansDeliDtDspDivName = ansDeliDtDspDivName;
            this._ansDeliDtDspDivOd = ansDeliDtDspDivOd;
            this._ansDeliDtDspDivOdName = ansDeliDtDspDivOdName;
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC自社設定マスタ複製処理
        /// </summary>
        /// <returns>PccCmpnyStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccCmpnyStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccCmpnySt Clone()
        {
            // UPD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3);
            // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName);
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName, this._pccPriWarehouseCd4);// DEL 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
            // UPD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // UPD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            //return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDivOdName, this._prsntStkCtDspDiv, this._prsntStkCtDspDivName);// ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加
            return new PccCmpnySt(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._pccCompanyCode, this._pccCompanyName, this._pccWarehouseCd, this._pccWarehouseNm, this._pccPriWarehouseCd1, this._pccPriWarehouseCd2, this._pccPriWarehouseCd3, this._goodsNoDspDiv, this._goodsNoDspDivName, this._listPrcDspDiv, this._listPrcDspDivName, this._costDspDiv, this._costDspDivName, this._shelfDspDiv, this._shelfDspDivName, this._stockDspDiv, this._stockDspDivName, this._commentDspDiv, this._commentDspDivName, this._spmtCntDspDiv, this._spmtCntDspDivName, this._acptCntDspDiv, this._acptCntDspDivName, this._prtSelGdNoDspDiv, this._prtSelGdNoDspDivName, this._prtSelLsPrDspDiv, this._prtSelLsPrDspDivName, this._prtSelSelfDspDiv, this._prtSelSelfDspDivName, this._prtSelStckDspDiv, this._prtSelStckDspDivName, this._stckStMark1, this._stckStMark2, this._stckStMark3, this._pccSuplName1, this._pccSuplName2, this._pccSuplKana, this._pccSuplSnm, this._pccSuplPostNo, this._pccSuplAddr1, this._pccSuplAddr2, this._pccSuplAddr3, this._pccSuplTelNo1, this._pccSuplTelNo2, this._pccSuplFaxNo, this._pccSlipPrtDiv, this._pccSlipPrtDivName, this._pccSlipRePrtDiv, this._pccSlipRePrtDivName, this._prtSelPrmDspDiv, this._prtSelPrmDspDivName, this._stckStDspDiv, this._stckStDspDivName, this._stckStComment1, this._stckStComment2, this._stckStComment3, this._warehouseDspDiv, this._cancelDspDiv, this._goodsNoDspDivOd, this._listPrcDspDivOd, this._costDspDivOd, this._shelfDspDivOd, this._stockDspDivOd, this._commentDspDivOd, this._spmtCntDspDivOd, this._acptCntDspDivOd, this._prtSelGdNoDspDivOd, this._prtSelLsPrDspDivOd, this._prtSelSelfDspDivOd, this._prtSelStckDspDivOd, this._warehouseDspDivOd, this._cancelDspDivOd, this._inqOdrDspDivSet, this._warehouseDspDivName, this._cancelDspDivName, this._goodsNoDspDivOdName, this._listPrcDspDivOdName, this._costDspDivOdName, this._shelfDspDivOdName, this._stockDspDivOdName, this._commentDspDivOdName, this._spmtCntDspDivOdName, this._acptCntDspDivOdName, this._prtSelGdNoDspDivOdName, this._prtSelLsPrDspDivOdName, this._prtSelSelfDspDivOdName, this._prtSelStckDspDivOdName, this._warehouseDspDivOdName, this._cancelDspDivOdName, this._inqOdrDspDivSetName, this._pccPriWarehouseCd4, this._prsntStkCtDspDivOd, this._prsntStkCtDspDivOdName, this._prsntStkCtDspDiv, this._prsntStkCtDspDivName, this._ansDeliDtDspDiv, this._ansDeliDtDspDivName, this._ansDeliDtDspDivOd, this._ansDeliDtDspDivOdName);//@@@@20230303
            // 2014/09/04 UPD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
        }

        /// <summary>
        /// PCC自社設定マスタ比較処理
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
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
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
                // UPD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
                //&& (this.StckStComment3 == target.StckStComment3));
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
                 && (this.WarehouseDspDivName == target.WarehouseDspDivName)
                 && (this.CancelDspDivName == target.CancelDspDivName)
                 && (this.GoodsNoDspDivOdName == target.GoodsNoDspDivOdName)
                 && (this.ListPrcDspDivOdName == target.ListPrcDspDivOdName)
                 && (this.CostDspDivOdName == target.CostDspDivOdName)
                 && (this.ShelfDspDivOdName == target.ShelfDspDivOdName)
                 && (this.StockDspDivOdName == target.StockDspDivOdName)
                 && (this.CommentDspDivOdName == target.CommentDspDivOdName)
                 && (this.SpmtCntDspDivOdName == target.SpmtCntDspDivOdName)
                 && (this.AcptCntDspDivOdName == target.AcptCntDspDivOdName)
                 && (this.PrtSelGdNoDspDivOdName == target.PrtSelGdNoDspDivOdName)
                 && (this.PrtSelLsPrDspDivOdName == target.PrtSelLsPrDspDivOdName)
                 && (this.PrtSelSelfDspDivOdName == target.PrtSelSelfDspDivOdName)
                 && (this.PrtSelStckDspDivOdName == target.PrtSelStckDspDivOdName)
                 && (this.WarehouseDspDivOdName == target.WarehouseDspDivOdName)
                 && (this.CancelDspDivOdName == target.CancelDspDivOdName)
                 && (this.InqOdrDspDivSetName == target.InqOdrDspDivSetName)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                 && (this.PccPriWarehouseCd4 == target.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                 && (this.PrsntStkCtDspDivOd == target.PrsntStkCtDspDivOd)
                 && (this.PrsntStkCtDspDivOdName == target.PrsntStkCtDspDivOdName)
                 && (this.PrsntStkCtDspDiv == target.PrsntStkCtDspDiv)
                 && (this.PrsntStkCtDspDivName == target.PrsntStkCtDspDivName)
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                 && (this.AnsDeliDtDspDiv == target.AnsDeliDtDspDiv)
                 && (this.AnsDeliDtDspDivName == target.AnsDeliDtDspDivName)
                 && (this.AnsDeliDtDspDivOd == target.AnsDeliDtDspDivOd)
                 && (this.AnsDeliDtDspDivOdName == target.AnsDeliDtDspDivOdName)
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                );
            // UPD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
        }

        /// <summary>
        /// PCC自社設定マスタ比較処理
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
                // UPD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
                //&& (pccCmpnySt1.StckStComment3 == pccCmpnySt2.StckStComment3));
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
                 && (pccCmpnySt1.WarehouseDspDivName == pccCmpnySt2.WarehouseDspDivName)
                 && (pccCmpnySt1.CancelDspDivName == pccCmpnySt2.CancelDspDivName)
                 && (pccCmpnySt1.GoodsNoDspDivOdName == pccCmpnySt2.GoodsNoDspDivOdName)
                 && (pccCmpnySt1.ListPrcDspDivOdName == pccCmpnySt2.ListPrcDspDivOdName)
                 && (pccCmpnySt1.CostDspDivOdName == pccCmpnySt2.CostDspDivOdName)
                 && (pccCmpnySt1.ShelfDspDivOdName == pccCmpnySt2.ShelfDspDivOdName)
                 && (pccCmpnySt1.StockDspDivOdName == pccCmpnySt2.StockDspDivOdName)
                 && (pccCmpnySt1.CommentDspDivOdName == pccCmpnySt2.CommentDspDivOdName)
                 && (pccCmpnySt1.SpmtCntDspDivOdName == pccCmpnySt2.SpmtCntDspDivOdName)
                 && (pccCmpnySt1.AcptCntDspDivOdName == pccCmpnySt2.AcptCntDspDivOdName)
                 && (pccCmpnySt1.PrtSelGdNoDspDivOdName == pccCmpnySt2.PrtSelGdNoDspDivOdName)
                 && (pccCmpnySt1.PrtSelLsPrDspDivOdName == pccCmpnySt2.PrtSelLsPrDspDivOdName)
                 && (pccCmpnySt1.PrtSelSelfDspDivOdName == pccCmpnySt2.PrtSelSelfDspDivOdName)
                 && (pccCmpnySt1.PrtSelStckDspDivOdName == pccCmpnySt2.PrtSelStckDspDivOdName)
                 && (pccCmpnySt1.WarehouseDspDivOdName == pccCmpnySt2.WarehouseDspDivOdName)
                 && (pccCmpnySt1.CancelDspDivOdName == pccCmpnySt2.CancelDspDivOdName)
                 && (pccCmpnySt1.InqOdrDspDivSetName == pccCmpnySt2.InqOdrDspDivSetName)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                 && (pccCmpnySt1.PccPriWarehouseCd4 == pccCmpnySt2.PccPriWarehouseCd4)
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                 && (pccCmpnySt1.PrsntStkCtDspDivOd == pccCmpnySt2.PrsntStkCtDspDivOd)
                 && (pccCmpnySt1.PrsntStkCtDspDivOdName == pccCmpnySt2.PrsntStkCtDspDivOdName)
                 && (pccCmpnySt1.PrsntStkCtDspDiv == pccCmpnySt2.PrsntStkCtDspDiv)
                 && (pccCmpnySt1.PrsntStkCtDspDivName == pccCmpnySt2.PrsntStkCtDspDivName)
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                 && (pccCmpnySt1.AnsDeliDtDspDiv == pccCmpnySt2.AnsDeliDtDspDiv)
                 && (pccCmpnySt1.AnsDeliDtDspDivName == pccCmpnySt2.AnsDeliDtDspDivName)
                 && (pccCmpnySt1.AnsDeliDtDspDivOd == pccCmpnySt2.AnsDeliDtDspDivOd)
                 && (pccCmpnySt1.AnsDeliDtDspDivOdName == pccCmpnySt2.AnsDeliDtDspDivOdName)
                // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
                 );
            // UPD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
        }
        /// <summary>
        /// PCC自社設定マスタ比較処理
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
            // ADD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
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
            if (this.WarehouseDspDivName != target.WarehouseDspDivName) resList.Add("WarehouseDspDivName");
            if (this.CancelDspDivName != target.CancelDspDivName) resList.Add("CancelDspDivName");
            if (this.GoodsNoDspDivOdName != target.GoodsNoDspDivOdName) resList.Add("GoodsNoDspDivOdName");
            if (this.ListPrcDspDivOdName != target.ListPrcDspDivOdName) resList.Add("ListPrcDspDivOdName");
            if (this.CostDspDivOdName != target.CostDspDivOdName) resList.Add("CostDspDivOdName");
            if (this.ShelfDspDivOdName != target.ShelfDspDivOdName) resList.Add("ShelfDspDivOdName");
            if (this.StockDspDivOdName != target.StockDspDivOdName) resList.Add("StockDspDivOdName");
            if (this.CommentDspDivOdName != target.CommentDspDivOdName) resList.Add("CommentDspDivOdName");
            if (this.SpmtCntDspDivOdName != target.SpmtCntDspDivOdName) resList.Add("SpmtCntDspDivOdName");
            if (this.AcptCntDspDivOdName != target.AcptCntDspDivOdName) resList.Add("AcptCntDspDivOdName");
            if (this.PrtSelGdNoDspDivOdName != target.PrtSelGdNoDspDivOdName) resList.Add("PrtSelGdNoDspDivOdName");
            if (this.PrtSelLsPrDspDivOdName != target.PrtSelLsPrDspDivOdName) resList.Add("PrtSelLsPrDspDivOdName");
            if (this.PrtSelSelfDspDivOdName != target.PrtSelSelfDspDivOdName) resList.Add("PrtSelSelfDspDivOdName");
            if (this.PrtSelStckDspDivOdName != target.PrtSelStckDspDivOdName) resList.Add("PrtSelStckDspDivOdName");
            if (this.WarehouseDspDivOdName != target.WarehouseDspDivOdName) resList.Add("WarehouseDspDivOdName");
            if (this.CancelDspDivOdName != target.CancelDspDivOdName) resList.Add("CancelDspDivOdName");
            if (this.InqOdrDspDivSetName != target.InqOdrDspDivSetName) resList.Add("InqOdrDspDivSetName");
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (this.PccPriWarehouseCd4 != target.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            if (this.PrsntStkCtDspDivOd != target.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (this.PrsntStkCtDspDivOdName != target.PrsntStkCtDspDivOdName) resList.Add("PrsntStkCtDspDivOdName");
            if (this.PrsntStkCtDspDiv != target.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            if (this.PrsntStkCtDspDivName != target.PrsntStkCtDspDivName) resList.Add("PrsntStkCtDspDivNam");
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            if (this.AnsDeliDtDspDiv != target.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (this.AnsDeliDtDspDivName != target.AnsDeliDtDspDivName) resList.Add("AnsDeliDtDspDivName");
            if (this.AnsDeliDtDspDivOd != target.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            if (this.AnsDeliDtDspDivOdName != target.AnsDeliDtDspDivOdName) resList.Add("AnsDeliDtDspDivOdName");
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            return resList;
        }

        /// <summary>
        /// PCC自社設定マスタ比較処理
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
            // ADD 2013/02/12 SCM障害№10342,10343対応 2013/03/06配信-------------------------------------------->>>>>
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
            if (pccCmpnySt1.WarehouseDspDivName != pccCmpnySt2.WarehouseDspDivName) resList.Add("WarehouseDspDivName");
            if (pccCmpnySt1.CancelDspDivName != pccCmpnySt2.CancelDspDivName) resList.Add("CancelDspDivName");
            if (pccCmpnySt1.GoodsNoDspDivOdName != pccCmpnySt2.GoodsNoDspDivOdName) resList.Add("GoodsNoDspDivOdName");
            if (pccCmpnySt1.ListPrcDspDivOdName != pccCmpnySt2.ListPrcDspDivOdName) resList.Add("ListPrcDspDivOdName");
            if (pccCmpnySt1.CostDspDivOdName != pccCmpnySt2.CostDspDivOdName) resList.Add("CostDspDivOdName");
            if (pccCmpnySt1.ShelfDspDivOdName != pccCmpnySt2.ShelfDspDivOdName) resList.Add("ShelfDspDivOdName");
            if (pccCmpnySt1.StockDspDivOdName != pccCmpnySt2.StockDspDivOdName) resList.Add("StockDspDivOdName");
            if (pccCmpnySt1.CommentDspDivOdName != pccCmpnySt2.CommentDspDivOdName) resList.Add("CommentDspDivOdName");
            if (pccCmpnySt1.SpmtCntDspDivOdName != pccCmpnySt2.SpmtCntDspDivOdName) resList.Add("SpmtCntDspDivOdName");
            if (pccCmpnySt1.AcptCntDspDivOdName != pccCmpnySt2.AcptCntDspDivOdName) resList.Add("AcptCntDspDivOdName");
            if (pccCmpnySt1.PrtSelGdNoDspDivOdName != pccCmpnySt2.PrtSelGdNoDspDivOdName) resList.Add("PrtSelGdNoDspDivOdName");
            if (pccCmpnySt1.PrtSelLsPrDspDivOdName != pccCmpnySt2.PrtSelLsPrDspDivOdName) resList.Add("PrtSelLsPrDspDivOdName");
            if (pccCmpnySt1.PrtSelSelfDspDivOdName != pccCmpnySt2.PrtSelSelfDspDivOdName) resList.Add("PrtSelSelfDspDivOdName");
            if (pccCmpnySt1.PrtSelStckDspDivOdName != pccCmpnySt2.PrtSelStckDspDivOdName) resList.Add("PrtSelStckDspDivOdName");
            if (pccCmpnySt1.WarehouseDspDivOdName != pccCmpnySt2.WarehouseDspDivOdName) resList.Add("WarehouseDspDivOdName");
            if (pccCmpnySt1.CancelDspDivOdName != pccCmpnySt2.CancelDspDivOdName) resList.Add("CancelDspDivOdName");
            if (pccCmpnySt1.InqOdrDspDivSetName != pccCmpnySt2.InqOdrDspDivSetName) resList.Add("InqOdrDspDivSetName");
            // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
            if (pccCmpnySt1.PccPriWarehouseCd4 != pccCmpnySt2.PccPriWarehouseCd4) resList.Add("PccPriWarehouseCd4");
            // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
            if (pccCmpnySt1.PrsntStkCtDspDivOd != pccCmpnySt2.PrsntStkCtDspDivOd) resList.Add("PrsntStkCtDspDivOd");
            if (pccCmpnySt1.PrsntStkCtDspDivOdName != pccCmpnySt2.PrsntStkCtDspDivOdName) resList.Add("PrsntStkCtDspDivOdName");
            if (pccCmpnySt1.PrsntStkCtDspDiv != pccCmpnySt2.PrsntStkCtDspDiv) resList.Add("PrsntStkCtDspDiv");
            if (pccCmpnySt1.PrsntStkCtDspDivName != pccCmpnySt2.PrsntStkCtDspDivName) resList.Add("PrsntStkCtDspDivName");
            // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
            if (pccCmpnySt1.AnsDeliDtDspDiv != pccCmpnySt2.AnsDeliDtDspDiv) resList.Add("AnsDeliDtDspDiv");
            if (pccCmpnySt1.AnsDeliDtDspDivName != pccCmpnySt2.AnsDeliDtDspDivName) resList.Add("AnsDeliDtDspDivName");
            if (pccCmpnySt1.AnsDeliDtDspDivOd != pccCmpnySt2.AnsDeliDtDspDivOd) resList.Add("AnsDeliDtDspDivOd");
            if (pccCmpnySt1.AnsDeliDtDspDivOdName != pccCmpnySt2.AnsDeliDtDspDivOdName) resList.Add("AnsDeliDtDspDivOdName");
            // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<
            return resList;
        }
    }
}
