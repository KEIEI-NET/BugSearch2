using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMTtlStWork
    /// <summary>
    ///                      SCM全体設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM全体設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/07/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/5/12  杉村</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :   旧システム連携フォルダ</br>
    /// <br>Update Note      :   2009/5/15  杉村</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :   自動回答区分</br>
    /// <br>Update Note      :   2009/5/28  杉村</br>
    /// <br>                 :   ○補足修正</br>
    /// <br>                 :   0:しない 1:する</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする</br>
    /// <br>Update Note      :   2009/7/7  杉村</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :   見積書発行区分</br>
    /// <br>Update Note      :   2012/08/31  30747 三戸 伸悟</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :   自動回答時表示区分(2012/10月配信予定 SCM障害№76の対応)</br>
    /// <br>Update Note      :   2012/11/09 30744 湯上 千加子</br>
    /// <br>                 :   ○項目追加 </br>
    /// <br>                 :   自動回答区分（問合せ）、自動回答区分（発注）</br>
    /// <br>                 :   受付従業員コード、受付従業員名称、納品区分、納品区分名称</br>
    /// <br>Update Note      :   2013/02/13 30744 湯上 千加子</br>
    /// <br>                 :   ○SCM障害対応 項目追加 </br>
    /// <br>                 :   該当無自動回答区分</br>
    /// <br>Update Note      :   管理番号  10900690-00 作成担当 : qijh</br>
    /// <br>                 :   配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応 </br>
    /// <br>Update Note      :   管理番号  10801804-00 作成担当 : wangl2</br>
    /// <br>                 :   2013/05/15 配信分 Redmine#35269 </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMTtlStWork : IFileHeader
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
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>売上伝票発行区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>受注伝票発行区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>旧システム連携区分</summary>
        /// <remarks>0:しない(PM.NS)　1:する（PM7SP）</remarks>
        private Int32 _oldSysCooperatDiv;

        /// <summary>旧システム連携フォルダ</summary>
        /// <remarks>デフォルトは"C:\SCMSHARE"</remarks>
        private string _oldSysCoopFolder = "";

        /// <summary>BLコード変換区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _bLCodeChgDiv;

        /// <summary>自動連携値引</summary>
        /// <remarks>値引き率</remarks>
        private Double _autoCooperatDis;

        /// <summary>値引適用区分</summary>
        /// <remarks>0:しない 1:全て 2:外装品以外 3:重点品目</remarks>
        private Int32 _discountApplyCd;

        /// <summary>自動回答区分</summary>
        /// <remarks>0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする</remarks>
        private Int32 _autoAnswerDiv;

        /// <summary>見積書発行区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _estimatePrtDiv;
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// <summary>レジ番号</summary>
        private Int32 _cashRegisterNo;

        /// <summary>受信処理起動間隔</summary>
        private Int32 _rcvProcStInterval;

        /// <summary>販売区分設定(自動回答時)</summary>
        private Int32 _salesCdStAutoAns;

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>自動回答時表示区分</summary>
        /// <remarks>0:使用しない,1:PM設定に従う,2:優良,3:純正,4:高い方(1:N),5:高い方(1:1)</remarks>
        private Int32 _autoAnsHourDspDiv;
        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// <summary>自動回答区分（問合せ）</summary>
        private Int32 _autoAnsInquiryDiv = 0;

        /// <summary>自動回答区分（発注）</summary>
        private Int32 _autoAnsOrderDiv = 0;

        /// <summary>受付従業員コード</summary>
        /// <remarks>PM受注者コード</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>受付従業員名称</summary>
        private string _frontEmployeeNm = "";

        /// <summary>納品区分</summary>
        private Int32 _deliveredGoodsDiv;

        /// <summary>納品区分名称</summary>
        private string _deliveredGoodsNm = "";

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
        /// <summary>該当無自動回答区分</summary>
        private Int32 _fuwioutAutoAnsDiv = 0;
        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>データ更新倉庫区分</summary>
        /// <remarks>0:委託倉庫,1:主管倉庫</remarks>
        private Int32 _dataUpDateWareHDiv;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // --------------- ADD START 2013.04.11 wangl2 FOR RedMine#35269------>>>> 
        /// <summary>売上入力者コード</summary>
        private string _salesInputCode;
        // --------------- ADD END 2013.04.11 wangl2 FOR RedMine#35269------<<<<<

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>00は全社</value>
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

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>売上伝票発行区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>受注伝票発行区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  OldSysCooperatDiv
        /// <summary>旧システム連携区分プロパティ</summary>
        /// <value>0:しない(PM.NS)　1:する（PM7SP）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧システム連携区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OldSysCooperatDiv
        {
            get { return _oldSysCooperatDiv; }
            set { _oldSysCooperatDiv = value; }
        }

        /// public propaty name  :  OldSysCoopFolder
        /// <summary>旧システム連携フォルダプロパティ</summary>
        /// <value>デフォルトは"C:\SCMSHARE"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧システム連携フォルダプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldSysCoopFolder
        {
            get { return _oldSysCoopFolder; }
            set { _oldSysCoopFolder = value; }
        }

        /// public propaty name  :  BLCodeChgDiv
        /// <summary>BLコード変換区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード変換区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCodeChgDiv
        {
            get { return _bLCodeChgDiv; }
            set { _bLCodeChgDiv = value; }
        }

        /// public propaty name  :  AutoCooperatDis
        /// <summary>自動連携値引プロパティ</summary>
        /// <value>値引き率</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動連携値引プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AutoCooperatDis
        {
            get { return _autoCooperatDis; }
            set { _autoCooperatDis = value; }
        }

        /// public propaty name  :  DiscountApplyCd
        /// <summary>値引適用区分プロパティ</summary>
        /// <value>0:しない 1:全て 2:外装品以外 3:重点品目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DiscountApplyCd
        {
            get { return _discountApplyCd; }
            set { _discountApplyCd = value; }
        }

        /// public propaty name  :  AutoAnswerDiv
        /// <summary>自動回答区分プロパティ</summary>
        /// <value>0:しない,1:一部でも回答可能な場合する,2:全て回答可能な場合のみする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDiv
        {
            get { return _autoAnswerDiv; }
            set { _autoAnswerDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>見積書発行区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  RcvProcStInterval
        /// <summary>受信処理起動間隔プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信処理起動間隔プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RcvProcStInterval
        {
            get { return _rcvProcStInterval; }
            set { _rcvProcStInterval = value; }
        }

        /// public propaty name  :  SalesCdStAutoAns
        /// <summary>販売区分設定(自動回答時)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分設定(自動回答時)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCdStAutoAns
        {
            get { return _salesCdStAutoAns; }
            set { _salesCdStAutoAns = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AutoAnsHourDspDiv
        /// <summary>自動回答時表示区分プロパティ</summary>
        /// <value>0:使用しない,1:PM設定に従う,2:優良,3:純正,4:高い方(1:N),5:高い方(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答時表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnsHourDspDiv
        {
            get { return _autoAnsHourDspDiv; }
            set { _autoAnsHourDspDiv = value; }
        }
        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// public propaty name  :  AutoAnsInquiryDiv
        /// <summary>自動回答区分（問合せ）プロパティ</summary>
        /// <value>0:しない(手動),1:する(全て自動回答),2:する(絞り込み時自動回答)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分（問合せ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnsInquiryDiv
        {
            get { return _autoAnsInquiryDiv; }
            set { _autoAnsInquiryDiv = value; }
        }


        /// public propaty name  : AutoAnsOrderDiv
        /// <summary>自動回答区分（発注）プロパティ</summary>
        /// <value>0:しない(手動),1:する(全て自動回答),2:する(委託在庫分のみ自動回答)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分（発注）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnsOrderDiv
        {
            get { return _autoAnsOrderDiv; }
            set { _autoAnsOrderDiv = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>PM受注者コード</value>
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

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>受付従業員名称プロパティ</summary>
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

        /// public propaty name  :  DeliveredGoodsNm
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsNm
        {
            get { return _deliveredGoodsNm; }
            set { _deliveredGoodsNm = value; }
        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
        /// public propaty name  :  FuwioutAutoAnsDiv
        /// <summary>該当無自動回答区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   該当無自動回答区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FuwioutAutoAnsDiv
        {
            get { return _fuwioutAutoAnsDiv;  }
            set { _fuwioutAutoAnsDiv = value; }
        }
        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<


        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  DataUpDateWareHDiv
        /// <summary>データ更新倉庫区分プロパティ</summary>
        /// <value>0:委託倉庫,1:主管倉庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新倉庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataUpDateWareHDiv
        {
            get { return _dataUpDateWareHDiv; }
            set { _dataUpDateWareHDiv = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // --------------- ADD START 2013.04.11 wangl2 FOR RedMine#35269------>>>> 
        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }
        // --------------- ADD END 2013.04.11 wangl2 FOR RedMine#35269------<<<<<

        /// <summary>
        /// SCM全体設定ワークコンストラクタ
        /// </summary>
        /// <returns>SCMTtlStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMTtlStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMTtlStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMTtlStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMTtlStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMTtlStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMTtlStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMTtlStWork || graph is ArrayList || graph is SCMTtlStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMTtlStWork).FullName));

            if (graph != null && graph is SCMTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMTtlStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMTtlStWork[])graph).Length;
            }
            else if (graph is SCMTtlStWork)
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
            //受注伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrSlipPrtDiv
            //旧システム連携区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OldSysCooperatDiv
            //旧システム連携フォルダ
            serInfo.MemberInfo.Add(typeof(string)); //OldSysCoopFolder
            //BLコード変換区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCodeChgDiv
            //自動連携値引
            serInfo.MemberInfo.Add(typeof(Double)); //AutoCooperatDis
            //値引適用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DiscountApplyCd
            //自動回答区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDiv
            //見積書発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimatePrtDiv
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //レジ番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //受信処理起動間隔
            serInfo.MemberInfo.Add(typeof(Int32)); //RcvProcStInterval
            //販売区分設定(自動回答時)
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCdStAutoAns
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnsHourDspDiv
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            //自動回答区分（問合せ）
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnsInquiryDivRF
            //自動回答区分（発注）
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnsOrderDivRF
            //受付従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //受付従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //納品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliveredGoodsDiv
            //納品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DeliveredGoodsNm
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            //該当無自動回答区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FuwioutAutoAnsDiv
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //データ更新倉庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DataUpDateWareHDiv
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // 売上入力者コード
            serInfo.MemberInfo.Add(typeof(string));// SalesInputCode //ADD 2013.04.11 wangl2 FOR RedMine#35269

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMTtlStWork)
            {
                SCMTtlStWork temp = (SCMTtlStWork)graph;

                SetSCMTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMTtlStWork temp in lst)
                {
                    SetSCMTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMTtlStWorkメンバ数(publicプロパティ数)
        /// </summary>
        //2012/04/20 UPD T.Nishi >>>>>>>>>>
        //private const int currentMemberCount = 18;
        // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //private const int currentMemberCount = 22;
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        //private const int currentMemberCount = 23;
        // UPD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
        //private const int currentMemberCount = 29;
        //private const int currentMemberCount = 30;// DEL 2013/02/27 qijh #34752
        // UPD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
        // --- UPD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        //2012/04/20 UPD T.Nishi <<<<<<<<<<
        //private const int currentMemberCount = 31;// ADD 2013/02/27 qijh #34752  // DEL  2013.04.11 wangl2 FOR RedMine#35269
        private const int currentMemberCount = 32;// ADD  2013.04.11 wangl2 FOR RedMine#35269

        /// <summary>
        ///  SCMTtlStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMTtlStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMTtlStWork(System.IO.BinaryWriter writer, SCMTtlStWork temp)
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
            //受注伝票発行区分
            writer.Write(temp.AcpOdrrSlipPrtDiv);
            //旧システム連携区分
            writer.Write(temp.OldSysCooperatDiv);
            //旧システム連携フォルダ
            writer.Write(temp.OldSysCoopFolder);
            //BLコード変換区分
            writer.Write(temp.BLCodeChgDiv);
            //自動連携値引
            writer.Write(temp.AutoCooperatDis);
            //値引適用区分
            writer.Write(temp.DiscountApplyCd);
            //自動回答区分
            writer.Write(temp.AutoAnswerDiv);
            //見積書発行区分
            writer.Write(temp.EstimatePrtDiv);
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //レジ番号
            writer.Write(temp.CashRegisterNo);
            //受信処理起動間隔
            writer.Write(temp.RcvProcStInterval);
            //販売区分設定(自動回答時)
            writer.Write(temp.SalesCdStAutoAns);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            writer.Write(temp.AutoAnsHourDspDiv);
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 自動回答区分（問合せ）
            writer.Write(temp.AutoAnsInquiryDiv);
            // 自動回答区分（発注）
            writer.Write(temp.AutoAnsOrderDiv);
            //受付従業員コード
            writer.Write(temp.FrontEmployeeCd);
            //受付従業員名称
            writer.Write(temp.FrontEmployeeNm);
            //納品区分
            writer.Write(temp.DeliveredGoodsDiv);
            //納品区分名称
            writer.Write(temp.DeliveredGoodsNm);
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            //該当無自動回答区分
            writer.Write(temp.FuwioutAutoAnsDiv);
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //データ更新倉庫区分
            writer.Write(temp.DataUpDateWareHDiv);
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // 売上入力者コード
            writer.Write(temp.SalesInputCode);// ADD 2013.04.11 wangl2 FOR RedMine#35269

        }

        /// <summary>
        ///  SCMTtlStWorkインスタンス取得
        /// </summary>
        /// <returns>SCMTtlStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMTtlStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMTtlStWork GetSCMTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMTtlStWork temp = new SCMTtlStWork();

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
            //受注伝票発行区分
            temp.AcpOdrrSlipPrtDiv = reader.ReadInt32();
            //旧システム連携区分
            temp.OldSysCooperatDiv = reader.ReadInt32();
            //旧システム連携フォルダ
            temp.OldSysCoopFolder = reader.ReadString();
            //BLコード変換区分
            temp.BLCodeChgDiv = reader.ReadInt32();
            //自動連携値引
            temp.AutoCooperatDis = reader.ReadDouble();
            //値引適用区分
            temp.DiscountApplyCd = reader.ReadInt32();
            //自動回答区分
            temp.AutoAnswerDiv = reader.ReadInt32();
            //見積書発行区分
            temp.EstimatePrtDiv = reader.ReadInt32();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //レジ番号
            temp.CashRegisterNo = reader.ReadInt32();
            //受信処理起動間隔
            temp.RcvProcStInterval = reader.ReadInt32();
            //販売区分設定(自動回答時)
            temp.SalesCdStAutoAns = reader.ReadInt32();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            temp.AutoAnsHourDspDiv = reader.ReadInt32();
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 自動回答区分（問合せ）
            temp.AutoAnsInquiryDiv = reader.ReadInt32();
            // 自動回答区分（発注）
            temp.AutoAnsOrderDiv = reader.ReadInt32();
            //受付従業員コード
            temp.FrontEmployeeCd = reader.ReadString();
            //受付従業員名称
            temp.FrontEmployeeNm = reader.ReadString();
            //納品区分
            temp.DeliveredGoodsDiv = reader.ReadInt32();
            //納品区分名称
            temp.DeliveredGoodsNm = reader.ReadString();
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            //該当無自動回答区分
            temp.FuwioutAutoAnsDiv = reader.ReadInt32();
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //データ更新倉庫区分
            temp.DataUpDateWareHDiv = reader.ReadInt32();
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // 売上入力者コード
            temp.SalesInputCode = reader.ReadString();// ADD 2013.04.11 wangl2 FOR RedMine#35269

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
        /// <returns>SCMTtlStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMTtlStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMTtlStWork temp = GetSCMTtlStWork(reader, serInfo);
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
                    retValue = (SCMTtlStWork[])lst.ToArray(typeof(SCMTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}