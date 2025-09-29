using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMngTtlSt
    /// <summary>
    ///                      在庫管理全体設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫管理全体設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/20  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/06/04 30415 柴田 倫幸</br>
    /// <br>        	         ・データ項目の追加/削除による修正</br>   
    /// <br>UpdateNote       :   2008/07/03 30415 柴田 倫幸</br>
    /// <br>        	         ・端数処理区分追加による修正</br>
    /// <br>Update Note      :   2009/12/02 朱俊成</br>
    /// <br>                     PM.NS-4</br>
    /// <br>                     棚卸運用区分の追加</br>
    /// <br>Update Note      :   2011/08/29 周雨</br>
    /// <br>                     連番 1016 「現在庫表示区分」を画面に追加　</br>
    /// <br>Update Note      :   2012/06/08 lanl</br>
    /// <br>                     #Redmine30282 「棚卸データ削除区分」をに追加　</br>
    /// <br>Update Note      :   2012/07/02 三戸　伸悟</br>
    /// <br>                     「移動時在庫自動登録区分」を画面に追加　</br>
    /// <br>Update Note      :   2014/10/27 wangf </br>
    /// <br>                 :   Redmine#43854画面に列「移動伝票出力先区分」追加</br>
    /// </remarks>
    public class StockMngTtlSt
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

        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        /// <remarks>オール０は全社</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// <summary>在庫管理全体設定管理コード</summary>
        /// <remarks>常に０設定</remarks>
        private Int32 _stockMngTtlStCd;

        /// <summary>受託在庫拠点間移動区分</summary>
        /// <remarks>1：移動なし、２：移動あり</remarks>
        private Int32 _trustStSectMoveCd;

        /// <summary>受託在庫倉庫移動区分</summary>
        /// <remarks>1：移動なし、２：移動あり</remarks>
        private Int32 _trustStWhouMoveCd;

        /// <summary>受託在庫委託許可区分</summary>
        /// <remarks>1：委託出荷なし、２：委託出荷あり</remarks>
        private Int32 _trEntrustPermCd;
           --- DEL 2008/06/04 --------------------------------<<<<< */

        /// <summary>在庫移動確定区分</summary>
        /// <remarks>1：出荷確定あり、２：出荷確定なし</remarks>
        private Int32 _stockMoveFixCode;

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// <summary>在庫管理有無区分初期表示値</summary>
        /// <remarks>0:在庫管理する,1:在庫管理しない</remarks>
        private Int32 _stockMngExistCdDisp;
           --- DEL 2008/06/04 --------------------------------<<<<< */

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// <summary>最適在庫条件区分</summary>
        private Int32 _beatStockCondCd;
           --- DEL 2008/06/04 --------------------------------<<<<< */

        /// <summary>在庫評価方法</summary>
        /// <remarks>1:最終仕入原価法,2:移動平均法,3:個別単価法</remarks>
        private Int32 _stockPointWay;

        // --- ADD 2008/07/03 -------------------------------->>>>>
        /// <summary>端数処理区分</summary>
        /// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
        private Int32 _fractionProcCd;
        // --- ADD 2008/07/03 --------------------------------<<<<< 

        // --- ADD 2009/12/02 ---------->>>>>
        /// <summary>棚卸運用区分</summary>
        /// <remarks>0：ＰＭ．ＮＳ,1：ＰＭ７</remarks>
        private Int32 _inventoryMngDiv;
        // --- ADD 2009/12/02 ----------<<<<<

        /// <summary>在庫切れ出荷区分</summary>
        /// <remarks>0:無し,1:警告,2:警告+再入力,3:再入力 （在庫切れチェック)</remarks>
        private Int32 _stockTolerncShipmDiv;

        /// <summary>棚卸印刷順初期設定区分</summary>
        /// <remarks>0:棚番順 1:仕入先順 2:BLｺｰﾄﾞ順 3:ﾒｰｶｰｺｰﾄﾞ順 4:仕入先･棚番順 5:仕入先･ﾒｰｶｰ順 （棚卸記入表、差異表で使用）</remarks>
        private Int32 _invntryPrtOdrIniDiv;

        /// <summary>最高在庫数超え発注区分</summary>
        /// <remarks>0:しない(最高在庫数まで)　1:する(最高在庫を超えた最小ﾛｯﾄ)発注点発注時最高在庫数を超えて発注データを作成するか否か</remarks>
        private Int32 _maxStkCntOverOderDiv;

        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// <summary>棚番重複区分</summary>
        /// <remarks>0:可能 1:不可 ※不可は1品番1棚で管理</remarks>
        private Int32 _shelfNoDuplDiv;

        /// <summary>ロット使用区分</summary>
        /// <remarks>0:発注ロット(在庫マスタ) 1:流通ロット(商品マスタ)※発注一覧表</remarks>
        private Int32 _lotUseDivCd;

        /// <summary>拠点表示区分</summary>
        /// <remarks>0:倉庫ﾏｽﾀ　1:自社ﾏｽﾀ　2:表示無し</remarks>
        private Int32 _sectDspDivCd;
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // ---------------------- ADD 2011/08/29 ------------------ >>>>>
        /// <summary>現在庫表示区分</summary>
        /// <remarks>0:受注分含む 1:受注分含まない</remarks>
        private Int32 _preStckCntDspDiv;
        // ---------------------- ADD 2011/08/29 ------------------ <<<<<

        // ---------------------- ADD lanl 2012/06/08 Redmine#30282 ------------------ >>>>>
        /// <summary>棚卸データ削除区分</summary>
        /// <remarks>0:可能 1:可能(拠点指定可能) 2:不可</remarks>
        private Int32 _invntryDtDelDiv;
        // ---------------------- ADD lanl 2012/06/08 Redmine#30282 ------------------ <<<<<

        // --- ADD 三戸 2012/07/02 ---------->>>>>
        /// <summary>移動時在庫自動登録区分</summary>
        /// <remarks>0:する 1:しない</remarks>
        private Int32 _moveStockAutoInsDiv;
        // --- ADD 三戸 2012/07/02 ----------<<<<<

        // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
        /// <summary>移動伝票出力先区分</summary>
        /// <remarks>0:入庫倉庫 1:出庫倉庫</remarks>
        private Int32 _moveSlipOutPutDiv;
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<

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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   柴田　倫幸</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// public propaty name  :  StockMngTtlStCd
        /// <summary>在庫管理全体設定管理コードプロパティ</summary>
        /// <value>常に０設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫管理全体設定管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMngTtlStCd
        {
            get { return _stockMngTtlStCd; }
            set { _stockMngTtlStCd = value; }
        }

        /// public propaty name  :  TrustStSectMoveCd
        /// <summary>受託在庫拠点間移動区分プロパティ</summary>
        /// <value>1：移動なし、２：移動あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受託在庫拠点間移動区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TrustStSectMoveCd
        {
            get { return _trustStSectMoveCd; }
            set { _trustStSectMoveCd = value; }
        }

        /// public propaty name  :  TrustStWhouMoveCd
        /// <summary>受託在庫倉庫移動区分プロパティ</summary>
        /// <value>1：移動なし、２：移動あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受託在庫倉庫移動区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TrustStWhouMoveCd
        {
            get { return _trustStWhouMoveCd; }
            set { _trustStWhouMoveCd = value; }
        }

        /// public propaty name  :  TrEntrustPermCd
        /// <summary>受託在庫委託許可区分プロパティ</summary>
        /// <value>1：委託出荷なし、２：委託出荷あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受託在庫委託許可区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TrEntrustPermCd
        {
            get { return _trEntrustPermCd; }
            set { _trEntrustPermCd = value; }
        }
           --- DEL 2008/06/04 --------------------------------<<<<< */

        /// public propaty name  :  StockMoveFixCode
        /// <summary>在庫移動確定区分プロパティ</summary>
        /// <value>1：出荷確定あり、２：出荷確定なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動確定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// public propaty name  :  StockMngExistCdDisp
        /// <summary>在庫管理有無区分初期表示値プロパティ</summary>
        /// <value>0:在庫管理する,1:在庫管理しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫管理有無区分初期表示値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMngExistCdDisp
        {
            get { return _stockMngExistCdDisp; }
            set { _stockMngExistCdDisp = value; }
        }
           --- DEL 2008/06/04 --------------------------------<<<<< */

        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// public propaty name  :  BeatStockCondCd
        /// <summary>最適在庫条件区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最適在庫条件区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BeatStockCondCd
        {
            get { return _beatStockCondCd; }
            set { _beatStockCondCd = value; }
        }
           --- DEL 2008/06/04 --------------------------------<<<<< */

        /// public propaty name  :  StockPointWay
        /// <summary>在庫評価方法プロパティ</summary>
        /// <value>1:最終仕入原価法,2:移動平均法,3:個別単価法</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫評価方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockPointWay
        {
            get { return _stockPointWay; }
            set { _stockPointWay = value; }
        }

        // --- ADD 2008/07/03 -------------------------------->>>>>
        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// <value>1：切捨て,2：四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }
        // --- ADD 2008/07/03 --------------------------------<<<<< 

        // --- ADD 2009/12/02 ---------->>>>>
        /// public propaty name  :  InventoryMngDiv
        /// <summary>棚卸運用区分プロパティ</summary>
        /// <value>0：ＰＭ．ＮＳ,1：ＰＭ７</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸運用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }
        // --- ADD 2009/12/02 ----------<<<<<

        /// public propaty name  :  StockTolerncShipmDiv
        /// <summary>在庫切れ出荷区分プロパティ</summary>
        /// <value>0:無し,1:警告,2:警告+再入力,3:再入力 （在庫切れチェック)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫切れ出荷区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockTolerncShipmDiv
        {
            get { return _stockTolerncShipmDiv; }
            set { _stockTolerncShipmDiv = value; }
        }

        /// public propaty name  :  InvntryPrtOdrIniDiv
        /// <summary>棚卸印刷順初期設定区分プロパティ</summary>
        /// <value>0:棚番順 1:仕入先順 2:BLｺｰﾄﾞ順 3:ﾒｰｶｰｺｰﾄﾞ順 4:仕入先･棚番順 5:仕入先･ﾒｰｶｰ順 （棚卸記入表、差異表で使用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸印刷順初期設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InvntryPrtOdrIniDiv
        {
            get { return _invntryPrtOdrIniDiv; }
            set { _invntryPrtOdrIniDiv = value; }
        }

        /// public propaty name  :  MaxStkCntOverOderDiv
        /// <summary>最高在庫数超え発注区分プロパティ</summary>
        /// <value>0:しない(最高在庫数まで)　1:する(最高在庫を超えた最小ﾛｯﾄ)発注点発注時最高在庫数を超えて発注データを作成するか否か</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高在庫数超え発注区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MaxStkCntOverOderDiv
        {
            get { return _maxStkCntOverOderDiv; }
            set { _maxStkCntOverOderDiv = value; }
        }

        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// public propaty name  :  ShelfNoDuplDiv
        /// <summary>棚番重複区分プロパティ</summary>
        /// <value>0:可能 1:不可　※不可は1品番1棚で管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番重複区分プロパティ</br>
        /// <br>Programer        :   柴田　倫幸</br>
        /// </remarks>
        public Int32 ShelfNoDuplDiv
        {
            get { return _shelfNoDuplDiv; }
            set { _shelfNoDuplDiv = value; }
        }

        /// public propaty name  :  LotUseDivCd
        /// <summary>ロット使用区分プロパティ</summary>
        /// <value>0:発注ロット(在庫マスタ)　1:流通ロット(商品マスタ)※発注一覧表</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロット使用区分プロパティ</br>
        /// <br>Programer        :   柴田　倫幸</br>
        /// </remarks>
        public Int32 LotUseDivCd
        {
            get { return _lotUseDivCd; }
            set { _lotUseDivCd = value; }
        }

        /// public propaty name  :  SectDspDivCd
        /// <summary>拠点表示区分プロパティ</summary>
        /// <value>0:倉庫ﾏｽﾀ　1:自社ﾏｽﾀ　2:表示無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点表示区分プロパティ</br>
        /// <br>Programer        :   柴田　倫幸</br>
        /// </remarks>
        public Int32 SectDspDivCd
        {
            get { return _sectDspDivCd; }
            set { _sectDspDivCd = value; }
        }
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        // ---------------- ADD 2011/08/29 ------------------- >>>>>
        /// public propaty name  :  PreStckCntDspDiv
        /// <summary>現在庫表示区分プロパティ</summary>
        /// <value>0:受注分含む 1:受注分含まない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在庫表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PreStckCntDspDiv
        {
            get { return _preStckCntDspDiv; }
            set { _preStckCntDspDiv = value; }
        }
        // ---------------- ADD 2011/08/29 ------------------- <<<<<


        // ---------------- ADD lanl 2012/06/08 Redmine#30282 ------------------- >>>>>
        /// public propaty name  :  InvntryDtDelDiv
        /// <summary>棚卸データ削除区分プロパティ</summary>
        /// <value>0:可能 1:可能(拠点指定可能) 2:不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸データ削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InvntryDtDelDiv
        {
            get { return _invntryDtDelDiv; }
            set { _invntryDtDelDiv = value; }
        }
        // ---------------- ADD 2011/06/07 ------------------- <<<<<

        // --- ADD 三戸 2012/07/02 ---------->>>>>
        /// public propaty name  :  MoveStockAutoInsDiv
        /// <summary>移動時在庫自動登録区分プロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動時在庫自動登録区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveStockAutoInsDiv
        {
            get { return _moveStockAutoInsDiv; }
            set { _moveStockAutoInsDiv = value; }
        }
        // --- ADD 三戸 2012/07/02 ----------<<<<<

        // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
        /// public propaty name  :  MoveSlipOutPutDiv
        /// <summary>移動伝票出力先区分プロパティ</summary>
        /// <value>0:入庫倉庫 1:出庫倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動伝票出力先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveSlipOutPutDiv
        {
            get { return _moveSlipOutPutDiv; }
            set { _moveSlipOutPutDiv = value; }
        }
        // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<

        /// <summary>
        /// 在庫管理全体設定マスタコンストラクタ
        /// </summary>
        /// <returns>StockMngTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMngTtlSt()
        {
        }

        /// <summary>
        /// 在庫管理全体設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// <param name="sectionCode">拠点コード(オール０は全社)</param>
        // --- ADD 2008/06/04 --------------------------------<<<<< 
        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// <param name="stockMngTtlStCd">在庫管理全体設定管理コード(常に０設定)</param>
        /// <param name="trustStSectMoveCd">受託在庫拠点間移動区分(1：移動なし、２：移動あり)</param>
        /// <param name="trustStWhouMoveCd">受託在庫倉庫移動区分(1：移動なし、２：移動あり)</param>
        /// <param name="trEntrustPermCd">受託在庫委託許可区分(1：委託出荷なし、２：委託出荷あり)</param>
           --- DEL 2008/06/04 --------------------------------<<<<< */
        /// <param name="stockMoveFixCode">在庫移動確定区分(1：出荷確定あり、２：出荷確定なし)</param>
        /* --- DEL 2008/06/04 -------------------------------->>>>>
        /// <param name="stockMngExistCdDisp">在庫管理有無区分初期表示値(0:在庫管理する,1:在庫管理しない)</param>
           --- DEL 2008/06/04 --------------------------------<<<<< */
        /// <param name="beatStockCondCd">最適在庫条件区分</param>
        /// <param name="stockPointWay">在庫評価方法(1:最終仕入原価法,2:移動平均法,3:個別単価法)</param>
        /// <param name="fractionProcCd">端数処理区分(1：切捨て,2：四捨五入,3:切上げ)</param>
        /// <param name="inventoryMngDiv">棚卸運用区分(0：ＰＭ．ＮＳ,1：ＰＭ７)</param>
        /// <param name="stockTolerncShipmDiv">在庫切れ出荷区分(0:無し,1:警告,2:警告+再入力,3:再入力 （在庫切れチェック))</param>
        /// <param name="invntryPrtOdrIniDiv">棚卸印刷順初期設定区分(0:棚番順 1:仕入先順 2:BLｺｰﾄﾞ順 3:ﾒｰｶｰｺｰﾄﾞ順 4:仕入先･棚番順 5:仕入先･ﾒｰｶｰ順 （棚卸記入表、差異表で使用）)</param>
        /// <param name="maxStkCntOverOderDiv">最高在庫数超え発注区分(0:しない(最高在庫数まで)　1:する(最高在庫を超えた最小ﾛｯﾄ)発注点発注時最高在庫数を超えて発注データを作成するか否か)</param>
        // --- ADD 2008/06/04 -------------------------------->>>>>
        /// <param name="shelfNoDuplDiv">棚番重複区分(0:可能 1:不可　※不可は1品番1棚で管理)</param>
        /// <param name="lotUseDivCd">ロット使用区分(0:発注ロット(在庫マスタ)　1:流通ロット(商品マスタ)※発注一覧表)</param>
        /// <param name="sectDspDivCd">拠点表示区分(0:倉庫ﾏｽﾀ　1:自社ﾏｽﾀ　2:表示無し)</param>
        // --- ADD 2008/06/04 --------------------------------<<<<< 
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="preStckCntDspDiv">現在庫表示区分(0:受注分含む 1:受注分含まない)</param>  // ADD 2011/08/29
        /// <param name="InvntryDtDelDiv">棚卸データ削除区分(0:可能 1:可能(拠点指定可能) 2:不可)</param>  // ADD ADD lanl 2012/06/08 Redmine#30282
        /// <param name="MoveStockAutoInsDiv">移動時在庫自動登録区分(0:する 1:しない)</param>  // ADD 三戸　伸悟 2012/07/02 
        /// <param name="moveSlipOutPutDiv">移動伝票出力先区分(0:入庫倉庫 1:出庫倉庫)</param>  // ADD wangf 2014/10/27 FOR Redmine#43854
        /// <returns>StockMngTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public StockMngTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockMngTtlStCd, Int32 trustStSectMoveCd, Int32 trustStWhouMoveCd, Int32 trEntrustPermCd, Int32 stockMoveFixCode, Int32 stockMngExistCdDisp, Int32 beatStockCondCd, Int32 stockPointWay, Int32 fractionProcCd, Int32 stockTolerncShipmDiv, Int32 invntryPrtOdrIniDiv, Int32 maxStkCntOverOderDiv, string enterpriseName, string updEmployeeName)  // DEL 2008/06/04
        //public StockMngTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockMoveFixCode,  Int32 stockPointWay, Int32 fractionProcCd, Int32 inventoryMngDiv, Int32 stockTolerncShipmDiv, Int32 invntryPrtOdrIniDiv, Int32 maxStkCntOverOderDiv, string enterpriseName, string updEmployeeName, Int32 shelfNoDuplDiv, Int32 lotUseDivCd, Int32 sectDspDivCd)    // ADD 2008/06/04  // DEL 2011/08/29
        //public StockMngTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockMoveFixCode, Int32 stockPointWay, Int32 fractionProcCd, Int32 inventoryMngDiv, Int32 stockTolerncShipmDiv, Int32 invntryPrtOdrIniDiv, Int32 maxStkCntOverOderDiv, string enterpriseName, string updEmployeeName, Int32 shelfNoDuplDiv, Int32 lotUseDivCd, Int32 sectDspDivCd, Int32 preStckCntDspDiv)  // ADD 2011/08/29 // DEL lanl 2012/06/08 Redmine#30282
        //public StockMngTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockMoveFixCode, Int32 stockPointWay, Int32 fractionProcCd, Int32 inventoryMngDiv, Int32 stockTolerncShipmDiv, Int32 invntryPrtOdrIniDiv, Int32 maxStkCntOverOderDiv, string enterpriseName, string updEmployeeName, Int32 shelfNoDuplDiv, Int32 lotUseDivCd, Int32 sectDspDivCd, Int32 preStckCntDspDiv, Int32 invntryDtDelDiv) // ADD lanl 2012/06/08 Redmine#30282 // DEL 三戸　伸悟 2012/07/02
        //public StockMngTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockMoveFixCode, Int32 stockPointWay, Int32 fractionProcCd, Int32 inventoryMngDiv, Int32 stockTolerncShipmDiv, Int32 invntryPrtOdrIniDiv, Int32 maxStkCntOverOderDiv, string enterpriseName, string updEmployeeName, Int32 shelfNoDuplDiv, Int32 lotUseDivCd, Int32 sectDspDivCd, Int32 preStckCntDspDiv, Int32 invntryDtDelDiv, Int32 moveStockAutoInsDiv) // ADD 三戸　伸悟 2012/07/02 // DEL wangf 2014/10/27 FOR Redmine#43854
        public StockMngTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockMoveFixCode, Int32 stockPointWay, Int32 fractionProcCd, Int32 inventoryMngDiv, Int32 stockTolerncShipmDiv, Int32 invntryPrtOdrIniDiv, Int32 maxStkCntOverOderDiv, string enterpriseName, string updEmployeeName, Int32 shelfNoDuplDiv, Int32 lotUseDivCd, Int32 sectDspDivCd, Int32 preStckCntDspDiv, Int32 invntryDtDelDiv, Int32 moveStockAutoInsDiv, Int32 moveSlipOutPutDiv) // ADD wangf 2014/10/27 FOR Redmine#43854
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;

            this._sectionCode = sectionCode;  // ADD 2008/06/04

            /* --- DEL 2008/06/04 -------------------------------->>>>>
            this._stockMngTtlStCd = stockMngTtlStCd;
            this._trustStSectMoveCd = trustStSectMoveCd;
            this._trustStWhouMoveCd = trustStWhouMoveCd;
            this._trEntrustPermCd = trEntrustPermCd;
               --- DEL 2008/06/04 --------------------------------<<<<< */

            this._stockMoveFixCode = stockMoveFixCode;

            //this._stockMngExistCdDisp = stockMngExistCdDisp;  // DEL 2008/06/04

            //this._beatStockCondCd = beatStockCondCd;          // DEL 2008/06/04
            this._stockPointWay = stockPointWay;
            this._fractionProcCd = fractionProcCd;              // ADD 2008/07/03
            // --- ADD 2009/12/02 ---------->>>>>
            this._inventoryMngDiv = inventoryMngDiv;
            // --- ADD 2009/12/02 ----------<<<<<
            this._stockTolerncShipmDiv = stockTolerncShipmDiv;
            this._invntryPrtOdrIniDiv = invntryPrtOdrIniDiv;
            this._maxStkCntOverOderDiv = maxStkCntOverOderDiv;

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this._shelfNoDuplDiv = shelfNoDuplDiv;
            this._lotUseDivCd = lotUseDivCd;
            this._sectDspDivCd = sectDspDivCd;
            // --- ADD 2008/06/04 --------------------------------<<<<< 

            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._preStckCntDspDiv = preStckCntDspDiv;  // ADD 2011/08/29
            this._invntryDtDelDiv = invntryDtDelDiv;  // ADD 2012/06/08 Redmine#30282
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            this._moveStockAutoInsDiv = moveStockAutoInsDiv;
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
            // 移動伝票出力先区分
            this._moveSlipOutPutDiv = moveSlipOutPutDiv;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<

        }

        /// <summary>
        /// 在庫管理全体設定マスタ複製処理
        /// </summary>
        /// <returns>StockMngTtlStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockMngTtlStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMngTtlSt Clone()
        {
            //return new StockMngTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockMngTtlStCd, this._trustStSectMoveCd, this._trustStWhouMoveCd, this._trEntrustPermCd, this._stockMoveFixCode, this._stockMngExistCdDisp,  this._beatStockCondCd, this._stockPointWay, this._fractionProcCd, this._stockTolerncShipmDiv, this._invntryPrtOdrIniDiv, this._maxStkCntOverOderDiv, this._enterpriseName, this._updEmployeeName);  // DEL 2008/06/04
            //return new StockMngTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockMoveFixCode, this._stockPointWay, this._fractionProcCd, this._inventoryMngDiv, this._stockTolerncShipmDiv, this._invntryPrtOdrIniDiv, this._maxStkCntOverOderDiv, this._enterpriseName, this._updEmployeeName, this._shelfNoDuplDiv, this._lotUseDivCd, this._sectDspDivCd);  // ADD 2008/06/04  // DEL 2011/08/29
            //return new StockMngTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockMoveFixCode, this._stockPointWay, this._fractionProcCd, this._inventoryMngDiv, this._stockTolerncShipmDiv, this._invntryPrtOdrIniDiv, this._maxStkCntOverOderDiv, this._enterpriseName, this._updEmployeeName, this._shelfNoDuplDiv, this._lotUseDivCd, this._sectDspDivCd,this._preStckCntDspDiv);  // ADD 2011/08/29 // DEL lanl 2012/06/08 Redmine#30282
            //return new StockMngTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockMoveFixCode, this._stockPointWay, this._fractionProcCd, this._inventoryMngDiv, this._stockTolerncShipmDiv, this._invntryPrtOdrIniDiv, this._maxStkCntOverOderDiv, this._enterpriseName, this._updEmployeeName, this._shelfNoDuplDiv, this._lotUseDivCd, this._sectDspDivCd, this._preStckCntDspDiv, this._invntryDtDelDiv); // ADD lanl 2012/06/08 Redmine#30282 // DEL 三戸　伸悟 2012/07/02
            //return new StockMngTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockMoveFixCode, this._stockPointWay, this._fractionProcCd, this._inventoryMngDiv, this._stockTolerncShipmDiv, this._invntryPrtOdrIniDiv, this._maxStkCntOverOderDiv, this._enterpriseName, this._updEmployeeName, this._shelfNoDuplDiv, this._lotUseDivCd, this._sectDspDivCd, this._preStckCntDspDiv, this._invntryDtDelDiv, this._moveStockAutoInsDiv); // ADD 三戸　伸悟 2012/07/02 // DEL wangf 2014/10/27 FOR Redmine#43854
            return new StockMngTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockMoveFixCode, this._stockPointWay, this._fractionProcCd, this._inventoryMngDiv, this._stockTolerncShipmDiv, this._invntryPrtOdrIniDiv, this._maxStkCntOverOderDiv, this._enterpriseName, this._updEmployeeName, this._shelfNoDuplDiv, this._lotUseDivCd, this._sectDspDivCd, this._preStckCntDspDiv, this._invntryDtDelDiv, this._moveStockAutoInsDiv, this._moveSlipOutPutDiv); // ADD wangf 2014/10/27 FOR Redmine#43854
        }

        /// <summary>
        /// 在庫管理全体設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMngTtlStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockMngTtlSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)  // ADD 2008/06/04
                 /* --- DEL 2008/06/04 -------------------------------->>>>>
                 && (this.StockMngTtlStCd == target.StockMngTtlStCd)
                 && (this.TrustStSectMoveCd == target.TrustStSectMoveCd)
                 && (this.TrustStWhouMoveCd == target.TrustStWhouMoveCd)
                 && (this.TrEntrustPermCd == target.TrEntrustPermCd)
                    --- DEL 2008/06/04 --------------------------------<<<<< */
                 && (this.StockMoveFixCode == target.StockMoveFixCode)
                 //&& (this.StockMngExistCdDisp == target.StockMngExistCdDisp)  // DEL 2008/06/04
                 //&& (this.BeatStockCondCd == target.BeatStockCondCd)          // DEL 2008/06/04
                 && (this.StockPointWay == target.StockPointWay)
                 && (this.FractionProcCd == target.FractionProcCd)              // ADD 2008/07/03
                 // --- ADD 2009/12/02 ---------->>>>>
                 && (this.InventoryMngDiv == target.InventoryMngDiv)  
                 // --- ADD 2009/12/02 ----------<<<<<
                 && (this.StockTolerncShipmDiv == target.StockTolerncShipmDiv)
                 && (this.InvntryPrtOdrIniDiv == target.InvntryPrtOdrIniDiv)
                 && (this.MaxStkCntOverOderDiv == target.MaxStkCntOverOderDiv)
                 // --- ADD 2008/06/04 -------------------------------->>>>>
                 && (this.ShelfNoDuplDiv == target.ShelfNoDuplDiv)
                 && (this.LotUseDivCd == target.LotUseDivCd)
                 && (this.SectDspDivCd == target.SectDspDivCd)
                 // --- ADD 2008/06/04 --------------------------------<<<<< 
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.PreStckCntDspDiv == target.PreStckCntDspDiv)  // ADD 2011/08/29
                 && (this.InvntryDtDelDiv == target.InvntryDtDelDiv)  // ADD lanl 2012/06/08 Redmine#30282
                // --- ADD 三戸 2012/07/02 ---------->>>>>
                // 移動時在庫自動登録区分
                 && (this.MoveStockAutoInsDiv == target.MoveStockAutoInsDiv)
                // --- ADD 三戸 2012/07/02 ----------<<<<<
                // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
                // 移動伝票出力先区分
                 && (this.MoveSlipOutPutDiv == target.MoveSlipOutPutDiv)
                // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 在庫管理全体設定マスタ比較処理
        /// </summary>
        /// <param name="stockMngTtlSt1">
        ///                    比較するStockMngTtlStクラスのインスタンス
        /// </param>
        /// <param name="stockMngTtlSt2">比較するStockMngTtlStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockMngTtlSt stockMngTtlSt1, StockMngTtlSt stockMngTtlSt2)
        {
            return ((stockMngTtlSt1.CreateDateTime == stockMngTtlSt2.CreateDateTime)
                 && (stockMngTtlSt1.UpdateDateTime == stockMngTtlSt2.UpdateDateTime)
                 && (stockMngTtlSt1.EnterpriseCode == stockMngTtlSt2.EnterpriseCode)
                 && (stockMngTtlSt1.FileHeaderGuid == stockMngTtlSt2.FileHeaderGuid)
                 && (stockMngTtlSt1.UpdEmployeeCode == stockMngTtlSt2.UpdEmployeeCode)
                 && (stockMngTtlSt1.UpdAssemblyId1 == stockMngTtlSt2.UpdAssemblyId1)
                 && (stockMngTtlSt1.UpdAssemblyId2 == stockMngTtlSt2.UpdAssemblyId2)
                 && (stockMngTtlSt1.LogicalDeleteCode == stockMngTtlSt2.LogicalDeleteCode)
                 && (stockMngTtlSt1.SectionCode == stockMngTtlSt2.SectionCode)  // ADD 2008/06/04
                 /* --- DEL 2008/06/04 -------------------------------->>>>>
                 && (stockMngTtlSt1.StockMngTtlStCd == stockMngTtlSt2.StockMngTtlStCd)
                 && (stockMngTtlSt1.TrustStSectMoveCd == stockMngTtlSt2.TrustStSectMoveCd)
                 && (stockMngTtlSt1.TrustStWhouMoveCd == stockMngTtlSt2.TrustStWhouMoveCd)
                 && (stockMngTtlSt1.TrEntrustPermCd == stockMngTtlSt2.TrEntrustPermCd)
                    --- DEL 2008/06/04 --------------------------------<<<<< */
                 && (stockMngTtlSt1.StockMoveFixCode == stockMngTtlSt2.StockMoveFixCode)
                 //&& (stockMngTtlSt1.StockMngExistCdDisp == stockMngTtlSt2.StockMngExistCdDisp)  // DEL 2008/06/04
                 //&& (stockMngTtlSt1.BeatStockCondCd == stockMngTtlSt2.BeatStockCondCd)          // DEL 2008/06/04
                 && (stockMngTtlSt1.StockPointWay == stockMngTtlSt2.StockPointWay)
                 && (stockMngTtlSt1.FractionProcCd == stockMngTtlSt2.FractionProcCd)              // ADD 2008/07/03
                 // --- ADD 2009/12/02 ---------->>>>>
                 && (stockMngTtlSt1.InventoryMngDiv == stockMngTtlSt2.InventoryMngDiv)
                 // --- ADD 2009/12/02 ----------<<<<<
                 && (stockMngTtlSt1.StockTolerncShipmDiv == stockMngTtlSt2.StockTolerncShipmDiv)
                 && (stockMngTtlSt1.InvntryPrtOdrIniDiv == stockMngTtlSt2.InvntryPrtOdrIniDiv)
                 && (stockMngTtlSt1.MaxStkCntOverOderDiv == stockMngTtlSt2.MaxStkCntOverOderDiv)
                 // --- ADD 2008/06/04 -------------------------------->>>>>
                 && (stockMngTtlSt1.ShelfNoDuplDiv == stockMngTtlSt2.ShelfNoDuplDiv)
                 && (stockMngTtlSt1.LotUseDivCd == stockMngTtlSt2.LotUseDivCd)
                 && (stockMngTtlSt1.SectDspDivCd == stockMngTtlSt2.SectDspDivCd)
                 // --- ADD 2008/06/04 --------------------------------<<<<< 
                 && (stockMngTtlSt1.EnterpriseName == stockMngTtlSt2.EnterpriseName)
                 && (stockMngTtlSt1.PreStckCntDspDiv == stockMngTtlSt2.PreStckCntDspDiv)  // ADD 2011/08/29
                 && (stockMngTtlSt1.InvntryDtDelDiv == stockMngTtlSt2.InvntryDtDelDiv)  // ADD lanl 2012/06/08 Redmine#30282
                // --- ADD 三戸 2012/07/02 ---------->>>>>
                // 移動時在庫自動登録区分
                 && (stockMngTtlSt1.MoveStockAutoInsDiv == stockMngTtlSt2.MoveStockAutoInsDiv)
                // --- ADD 三戸 2012/07/02 ----------<<<<<
                // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
                // 移動伝票出力先区分
                 && (stockMngTtlSt1.MoveSlipOutPutDiv == stockMngTtlSt2.MoveSlipOutPutDiv)
                // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<
                 && (stockMngTtlSt1.UpdEmployeeName == stockMngTtlSt2.UpdEmployeeName));
        }
        /// <summary>
        /// 在庫管理全体設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMngTtlStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockMngTtlSt target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");  // ADD 2008/06/04
            /* --- DEL 2008/06/04 -------------------------------->>>>>
            if (this.StockMngTtlStCd != target.StockMngTtlStCd) resList.Add("StockMngTtlStCd");
            if (this.TrustStSectMoveCd != target.TrustStSectMoveCd) resList.Add("TrustStSectMoveCd");
            if (this.TrustStWhouMoveCd != target.TrustStWhouMoveCd) resList.Add("TrustStWhouMoveCd");
            if (this.TrEntrustPermCd != target.TrEntrustPermCd) resList.Add("TrEntrustPermCd");
               --- DEL 2008/06/04 --------------------------------<<<<< */
            if (this.StockMoveFixCode != target.StockMoveFixCode) resList.Add("StockMoveFixCode");
            //if (this.StockMngExistCdDisp != target.StockMngExistCdDisp) resList.Add("StockMngExistCdDisp");  // DEL 2008/06/04
            //if (this.BeatStockCondCd != target.BeatStockCondCd) resList.Add("BeatStockCondCd");              // DEL 2008/06/04
            if (this.StockPointWay != target.StockPointWay) resList.Add("StockPointWay");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");                   // ADD 2008/07/03
            // --- ADD 2009/12/02 ---------->>>>>
            if (this.InventoryMngDiv != target.InventoryMngDiv) resList.Add("InventoryMngDiv");
            // --- ADD 2009/12/02 ----------<<<<<
            if (this.StockTolerncShipmDiv != target.StockTolerncShipmDiv) resList.Add("StockTolerncShipmDiv");
            if (this.InvntryPrtOdrIniDiv != target.InvntryPrtOdrIniDiv) resList.Add("InvntryPrtOdrIniDiv");
            if (this.MaxStkCntOverOderDiv != target.MaxStkCntOverOderDiv) resList.Add("MaxStkCntOverOderDiv");
            // --- ADD 2008/06/04 -------------------------------->>>>>
            if (this.ShelfNoDuplDiv != target.ShelfNoDuplDiv) resList.Add("ShelfNoDuplDiv");
            if (this.LotUseDivCd != target.LotUseDivCd) resList.Add("LotUseDivCd");
            if (this.SectDspDivCd != target.SectDspDivCd) resList.Add("SectDspDivCd");
            // --- ADD 2008/06/04 --------------------------------<<<<< 
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.PreStckCntDspDiv != target.PreStckCntDspDiv) resList.Add("PreStckCntDspDiv");  // ADD 2011/08/29
            if (this.InvntryDtDelDiv != target.InvntryDtDelDiv) resList.Add("InvntryDtDelDiv");  //ADD lanl 2012/06/08 Redmine#30282
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            if (this.MoveStockAutoInsDiv != target.MoveStockAutoInsDiv) resList.Add("MoveStockAutoInsDiv");
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
            // 移動伝票出力先区分
            if (this.MoveSlipOutPutDiv != target.MoveSlipOutPutDiv) resList.Add("MoveSlipOutPutDiv");
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 在庫管理全体設定マスタ比較処理
        /// </summary>
        /// <param name="stockMngTtlSt1">比較するStockMngTtlStクラスのインスタンス</param>
        /// <param name="stockMngTtlSt2">比較するStockMngTtlStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMngTtlStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockMngTtlSt stockMngTtlSt1, StockMngTtlSt stockMngTtlSt2)
        {
            ArrayList resList = new ArrayList();
            if (stockMngTtlSt1.CreateDateTime != stockMngTtlSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockMngTtlSt1.UpdateDateTime != stockMngTtlSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockMngTtlSt1.EnterpriseCode != stockMngTtlSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMngTtlSt1.FileHeaderGuid != stockMngTtlSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockMngTtlSt1.UpdEmployeeCode != stockMngTtlSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockMngTtlSt1.UpdAssemblyId1 != stockMngTtlSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockMngTtlSt1.UpdAssemblyId2 != stockMngTtlSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockMngTtlSt1.LogicalDeleteCode != stockMngTtlSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockMngTtlSt1.SectionCode != stockMngTtlSt2.SectionCode) resList.Add("SectionCode");  // ADD 2008/06/04
            /* --- DEL 2008/06/04 -------------------------------->>>>>
            if (stockMngTtlSt1.StockMngTtlStCd != stockMngTtlSt2.StockMngTtlStCd) resList.Add("StockMngTtlStCd");
            if (stockMngTtlSt1.TrustStSectMoveCd != stockMngTtlSt2.TrustStSectMoveCd) resList.Add("TrustStSectMoveCd");
            if (stockMngTtlSt1.TrustStWhouMoveCd != stockMngTtlSt2.TrustStWhouMoveCd) resList.Add("TrustStWhouMoveCd");
            if (stockMngTtlSt1.TrEntrustPermCd != stockMngTtlSt2.TrEntrustPermCd) resList.Add("TrEntrustPermCd");
               --- DEL 2008/06/04 --------------------------------<<<<< */
            if (stockMngTtlSt1.StockMoveFixCode != stockMngTtlSt2.StockMoveFixCode) resList.Add("StockMoveFixCode");
            //if (stockMngTtlSt1.StockMngExistCdDisp != stockMngTtlSt2.StockMngExistCdDisp) resList.Add("StockMngExistCdDisp");  // DEL 2008/06/04
            //if (stockMngTtlSt1.BeatStockCondCd != stockMngTtlSt2.BeatStockCondCd) resList.Add("BeatStockCondCd");              // DEL 2008/06/04
            if (stockMngTtlSt1.StockPointWay != stockMngTtlSt2.StockPointWay) resList.Add("StockPointWay");
            if (stockMngTtlSt1.FractionProcCd != stockMngTtlSt2.FractionProcCd) resList.Add("FractionProcCd");                   // ADD 2008/07/03
            // --- ADD 2009/12/02 ---------->>>>>
            if (stockMngTtlSt1.InventoryMngDiv != stockMngTtlSt2.InventoryMngDiv) resList.Add("InventoryMngDiv"); 
            // --- ADD 2009/12/02 ----------<<<<<
            if (stockMngTtlSt1.StockTolerncShipmDiv != stockMngTtlSt2.StockTolerncShipmDiv) resList.Add("StockTolerncShipmDiv");
            if (stockMngTtlSt1.InvntryPrtOdrIniDiv != stockMngTtlSt2.InvntryPrtOdrIniDiv) resList.Add("InvntryPrtOdrIniDiv");
            if (stockMngTtlSt1.MaxStkCntOverOderDiv != stockMngTtlSt2.MaxStkCntOverOderDiv) resList.Add("MaxStkCntOverOderDiv");
            // --- ADD 2008/06/04 -------------------------------->>>>>
            if (stockMngTtlSt1.ShelfNoDuplDiv != stockMngTtlSt2.ShelfNoDuplDiv) resList.Add("ShelfNoDuplDiv");
            if (stockMngTtlSt1.LotUseDivCd != stockMngTtlSt2.LotUseDivCd) resList.Add("LotUseDivCd");
            if (stockMngTtlSt1.SectDspDivCd != stockMngTtlSt2.SectDspDivCd) resList.Add("SectDspDivCd");
            // --- ADD 2008/06/04 --------------------------------<<<<< 
            if (stockMngTtlSt1.EnterpriseName != stockMngTtlSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockMngTtlSt1.PreStckCntDspDiv != stockMngTtlSt2.PreStckCntDspDiv) resList.Add("PreStckCntDspDiv");  // ADD 2011/08/29
            if (stockMngTtlSt1.InvntryDtDelDiv != stockMngTtlSt2.InvntryDtDelDiv) resList.Add("InvntryDtDelDiv");  // ADD lanl 2012/06/08 Redmine#30282
            // --- ADD 三戸 2012/07/02 ---------->>>>>
            // 移動時在庫自動登録区分
            if (stockMngTtlSt1.MoveStockAutoInsDiv != stockMngTtlSt2.MoveStockAutoInsDiv) resList.Add("MoveStockAutoInsDiv");
            // --- ADD 三戸 2012/07/02 ----------<<<<<
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854--------->>>>
            // 移動伝票出力先区分
            if (stockMngTtlSt1.MoveSlipOutPutDiv != stockMngTtlSt2.MoveSlipOutPutDiv) resList.Add("MoveSlipOutPutDiv");
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854---------<<<<
            if (stockMngTtlSt1.UpdEmployeeName != stockMngTtlSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
