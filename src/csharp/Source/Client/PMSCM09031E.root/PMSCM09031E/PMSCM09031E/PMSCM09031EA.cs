//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM納期設定マスタ
// プログラム概要   : SCM納期設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SCMDeliDateSt
    /// <summary>
    ///                      SCM納期設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM納期設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/01  (CSharp File Generated Date)</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/01/06 30517 夏野 駿希</br>
    /// <br>           : SCM検証結果対応No.7　納期設定を取寄品・在庫品で別に設定出来る様に修正</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2011/10/11  呉軍</br>
    /// <br>Note       : Redmine #25765</br>
    /// <br>           : 優先在庫回答納期区分、優先在庫回答納期の追加</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2012/08/30 高川 悟</br>
    /// <br>           : SCM障害対応No.10345　回答納期の設定方法を変更</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2015/02/10 吉岡</br>
    /// <br>           : SCM高速化 回答納期区分対応</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// </remarks>
    public class SCMDeliDateSt
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

        /// <summary>得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _customerCode;

        /// <summary>回答締切時刻１</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime1;

        /// <summary>回答締切時刻２</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime2;

        /// <summary>回答締切時刻３</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime3;

        /// <summary>回答締切時刻４</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime4;

        /// <summary>回答締切時刻５</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime5;

        /// <summary>回答締切時刻６</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime6;

        /// <summary>回答納期１</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate1 = "";

        /// <summary>回答納期２</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate2 = "";

        /// <summary>回答納期３</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate3 = "";

        /// <summary>回答納期４</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate4 = "";

        /// <summary>回答納期５</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate5 = "";

        /// <summary>回答納期６</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate6 = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // 2011/01/06 Add >>>
        /// <summary>回答締切時刻１（在庫）</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime1Stc;

        /// <summary>回答締切時刻２（在庫）</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime2Stc;

        /// <summary>回答締切時刻３（在庫）</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime3Stc;

        /// <summary>回答締切時刻４（在庫）</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime4Stc;

        /// <summary>回答締切時刻５（在庫）</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime5Stc;

        /// <summary>回答締切時刻６（在庫）</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _answerDeadTime6Stc;

        /// <summary>回答納期１（在庫）</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate1Stc = "";

        /// <summary>回答納期２（在庫）</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate2Stc = "";

        /// <summary>回答納期３（在庫）</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate3Stc = "";

        /// <summary>回答納期４（在庫）</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate4Stc = "";

        /// <summary>回答納期５（在庫）</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate5Stc = "";

        /// <summary>回答納期６（在庫）</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _answerDelivDate6Stc = "";

        /// <summary>委託在庫回答納期区分</summary>
        /// <remarks>0:在庫設定に従う、1:棚番、2:委託用に設定　</remarks>
        private Int32 _entStckAnsDeliDtDiv;

        /// <summary>委託在庫回答納期</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _entStckAnsDeliDate = "";
        // 2011/01/06 Add <<<

        // 2011/10/11 Add >>>
        /// <summary>優先在庫回答納期区分</summary>
        /// <remarks>0:在庫設定に従う、1:優先用に設定　</remarks>
        private Int32 _priStckAnsDeliDtDiv;

        /// <summary>優先在庫回答納期</summary>
        /// <remarks>１便,２便,最終便,翌朝便 等　</remarks>
        private string _priStckAnsDeliDate = "";
        // 2011/10/11 Add <<<

        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>回答納期（在庫不足）</summary>
        private string _ansDelDatShortOfStc = "";

        /// <summary>回答納期（在庫数無し）</summary>
        private string _ansDelDatWithoutStc = "";

        /// <summary>委託在庫回答納期（在庫不足）</summary>
        private string _entStcAnsDelDatShort = "";

        /// <summary>委託在庫回答納期（在庫数無し）</summary>
        private string _entStcAnsDelDatWiout = "";

        /// <summary>参照在庫回答納期（在庫不足）</summary>
        private string _priStcAnsDelDatShort = "";

        /// <summary>参照在庫回答納期（在庫数無し）</summary>
        private string _priStcAnsDelDatWiout = "";
        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>回答納期区分１</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv1;

        /// <summary>回答納期区分２</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv2;

        /// <summary>回答納期区分３</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv3;

        /// <summary>回答納期区分４</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv4;

        /// <summary>回答納期区分５</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv5;

        /// <summary>回答納期区分６</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv6;

        /// <summary>回答納期区分１（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv1Stc;

        /// <summary>回答納期区分２（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv2Stc;

        /// <summary>回答納期区分３（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv3Stc;

        /// <summary>回答納期区分４（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv4Stc;

        /// <summary>回答納期区分５（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv5Stc;

        /// <summary>回答納期区分６（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtDiv6Stc;

        /// <summary>委託在庫回答納期区分（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _entAnsDelDtStcDiv;

        /// <summary>優先在庫回答納期区分（在庫）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _priAnsDelDtStcDiv;

        /// <summary>回答納期区分（在庫不足）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtShoStcDiv;

        /// <summary>回答納期区分（在庫数無し）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _ansDelDtWioStcDiv;

        /// <summary>委託在庫回答納期区分（在庫不足）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _entAnsDelDtShoDiv;

        /// <summary>委託在庫回答納期区分（在庫数無し）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _entAnsDelDtWioDiv;

        /// <summary>優先在庫回答納期区分（在庫不足）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _priAnsDelDtShoDiv;

        /// <summary>優先在庫回答納期区分（在庫数無し）</summary>
        /// <remarks>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</remarks>
        private Int16 _priAnsDelDtWioDiv;
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
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

        /// public propaty name  :  AnswerDeadTime1
        /// <summary>回答締切時刻１プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime1
        {
            get { return _answerDeadTime1; }
            set { _answerDeadTime1 = value; }
        }

        /// public propaty name  :  AnswerDeadTime2
        /// <summary>回答締切時刻２プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime2
        {
            get { return _answerDeadTime2; }
            set { _answerDeadTime2 = value; }
        }

        /// public propaty name  :  AnswerDeadTime3
        /// <summary>回答締切時刻３プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime3
        {
            get { return _answerDeadTime3; }
            set { _answerDeadTime3 = value; }
        }

        /// public propaty name  :  AnswerDeadTime4
        /// <summary>回答締切時刻４プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime4
        {
            get { return _answerDeadTime4; }
            set { _answerDeadTime4 = value; }
        }

        /// public propaty name  :  AnswerDeadTime5
        /// <summary>回答締切時刻５プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime5
        {
            get { return _answerDeadTime5; }
            set { _answerDeadTime5 = value; }
        }

        /// public propaty name  :  AnswerDeadTime6
        /// <summary>回答締切時刻６プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime6
        {
            get { return _answerDeadTime6; }
            set { _answerDeadTime6 = value; }
        }

        /// public propaty name  :  AnswerDelivDate1
        /// <summary>回答納期１プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate1
        {
            get { return _answerDelivDate1; }
            set { _answerDelivDate1 = value; }
        }

        /// public propaty name  :  AnswerDelivDate2
        /// <summary>回答納期２プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate2
        {
            get { return _answerDelivDate2; }
            set { _answerDelivDate2 = value; }
        }

        /// public propaty name  :  AnswerDelivDate3
        /// <summary>回答納期３プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate3
        {
            get { return _answerDelivDate3; }
            set { _answerDelivDate3 = value; }
        }

        /// public propaty name  :  AnswerDelivDate4
        /// <summary>回答納期４プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate4
        {
            get { return _answerDelivDate4; }
            set { _answerDelivDate4 = value; }
        }

        /// public propaty name  :  AnswerDelivDate5
        /// <summary>回答納期５プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate5
        {
            get { return _answerDelivDate5; }
            set { _answerDelivDate5 = value; }
        }

        /// public propaty name  :  AnswerDelivDate6
        /// <summary>回答納期６プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate6
        {
            get { return _answerDelivDate6; }
            set { _answerDelivDate6 = value; }
        }

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

        // 2011/01/06 Add >>>
        /// public propaty name  :  AnswerDeadTime1Stc
        /// <summary>回答締切時刻１（在庫）プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻１（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime1Stc
        {
            get { return _answerDeadTime1Stc; }
            set { _answerDeadTime1Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime2Stc
        /// <summary>回答締切時刻２（在庫）プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻２（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime2Stc
        {
            get { return _answerDeadTime2Stc; }
            set { _answerDeadTime2Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime3Stc
        /// <summary>回答締切時刻３（在庫）プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻３（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime3Stc
        {
            get { return _answerDeadTime3Stc; }
            set { _answerDeadTime3Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime4Stc
        /// <summary>回答締切時刻４（在庫）プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻４（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime4Stc
        {
            get { return _answerDeadTime4Stc; }
            set { _answerDeadTime4Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime5Stc
        /// <summary>回答締切時刻５（在庫）プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻５（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime5Stc
        {
            get { return _answerDeadTime5Stc; }
            set { _answerDeadTime5Stc = value; }
        }

        /// public propaty name  :  AnswerDeadTime6Stc
        /// <summary>回答締切時刻６（在庫）プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答締切時刻６（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerDeadTime6Stc
        {
            get { return _answerDeadTime6Stc; }
            set { _answerDeadTime6Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate1Stc
        /// <summary>回答納期１（在庫）プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期１（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate1Stc
        {
            get { return _answerDelivDate1Stc; }
            set { _answerDelivDate1Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate2Stc
        /// <summary>回答納期２（在庫）プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期２（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate2Stc
        {
            get { return _answerDelivDate2Stc; }
            set { _answerDelivDate2Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate3Stc
        /// <summary>回答納期３（在庫）プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期３（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate3Stc
        {
            get { return _answerDelivDate3Stc; }
            set { _answerDelivDate3Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate4Stc
        /// <summary>回答納期４（在庫）プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期４（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate4Stc
        {
            get { return _answerDelivDate4Stc; }
            set { _answerDelivDate4Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate5Stc
        /// <summary>回答納期５（在庫）プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期５（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate5Stc
        {
            get { return _answerDelivDate5Stc; }
            set { _answerDelivDate5Stc = value; }
        }

        /// public propaty name  :  AnswerDelivDate6Stc
        /// <summary>回答納期６（在庫）プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期６（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerDelivDate6Stc
        {
            get { return _answerDelivDate6Stc; }
            set { _answerDelivDate6Stc = value; }
        }

        /// public propaty name  :  EntStckAnsDeliDtDiv
        /// <summary>委託在庫回答納期区分プロパティ</summary>
        /// <value>0:在庫設定に従う、1:棚番、2:委託用に設定　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期６（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EntStckAnsDeliDtDiv
        {
            get { return _entStckAnsDeliDtDiv; }
            set { _entStckAnsDeliDtDiv = value; }
        }

        /// public propaty name  :  EntStckAnsDeliDate
        /// <summary>委託在庫回答納期プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期６（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EntStckAnsDeliDate
        {
            get { return _entStckAnsDeliDate; }
            set { _entStckAnsDeliDate = value; }
        }
        // 2011/01/06 Add <<<

        /// public propaty name  :  PriStckAnsDeliDtDiv
        /// <summary>優先在庫回答納期区分プロパティ</summary>
        /// <value>0:在庫設定に従う、1:優先用に設定　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先在庫回答納期区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriStckAnsDeliDtDiv
        {
            get { return _priStckAnsDeliDtDiv; }
            set { _priStckAnsDeliDtDiv = value; }
        }

        /// public propaty name  :  PriStckAnsDeliDate
        /// <summary>優先在庫回答納期プロパティ</summary>
        /// <value>１便,２便,最終便,翌朝便 等　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先在庫回答納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriStckAnsDeliDate
        {
            get { return _priStckAnsDeliDate; }
            set { _priStckAnsDeliDate = value; }
        }

        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDelDatShortOfStc
        /// <summary>回答納期（在庫不足）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期（在庫不足）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsDelDatShortOfStc
        {
            get { return _ansDelDatShortOfStc; }
            set { _ansDelDatShortOfStc = value; }
        }

        /// public propaty name  :  AnsDelDatWithoutStc
        /// <summary>回答納期（在庫数無し）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期（在庫数無し）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnsDelDatWithoutStc
        {
            get { return _ansDelDatWithoutStc; }
            set { _ansDelDatWithoutStc = value; }
        }

        /// public propaty name  :  EntStcAnsDelDatShort
        /// <summary>委託在庫回答納期（在庫不足）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託在庫回答納期（在庫不足）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EntStcAnsDelDatShort
        {
            get { return _entStcAnsDelDatShort; }
            set { _entStcAnsDelDatShort = value; }
        }

        /// public propaty name  :  EntStcAnsDelDatWiout
        /// <summary>委託在庫回答納期（在庫数無し）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託在庫回答納期（在庫数無し）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EntStcAnsDelDatWiout
        {
            get { return _entStcAnsDelDatWiout; }
            set { _entStcAnsDelDatWiout = value; }
        }

        /// public propaty name  :  PriStcAnsDelDatShort
        /// <summary>参照在庫回答納期（在庫不足）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   参照在庫回答納期（在庫不足）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriStcAnsDelDatShort
        {
            get { return _priStcAnsDelDatShort; }
            set { _priStcAnsDelDatShort = value; }
        }

        /// public propaty name  :  PriStcAnsDelDatWiout
        /// <summary>参照優先在庫回答納期（在庫数無し）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   参照在庫回答納期（在庫数無し）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriStcAnsDelDatWiout
        {
            get { return _priStcAnsDelDatWiout; }
            set { _priStcAnsDelDatWiout = value; }
        }
        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDelDtDiv1
        /// <summary>回答納期区分１プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv1
        {
            get { return _ansDelDtDiv1; }
            set { _ansDelDtDiv1 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv2
        /// <summary>回答納期区分２プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv2
        {
            get { return _ansDelDtDiv2; }
            set { _ansDelDtDiv2 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv3
        /// <summary>回答納期区分３プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv3
        {
            get { return _ansDelDtDiv3; }
            set { _ansDelDtDiv3 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv4
        /// <summary>回答納期区分４プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv4
        {
            get { return _ansDelDtDiv4; }
            set { _ansDelDtDiv4 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv5
        /// <summary>回答納期区分５プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv5
        {
            get { return _ansDelDtDiv5; }
            set { _ansDelDtDiv5 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv6
        /// <summary>回答納期区分６プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv6
        {
            get { return _ansDelDtDiv6; }
            set { _ansDelDtDiv6 = value; }
        }

        /// public propaty name  :  AnsDelDtDiv1Stc
        /// <summary>回答納期区分１（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分１（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv1Stc
        {
            get { return _ansDelDtDiv1Stc; }
            set { _ansDelDtDiv1Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv2Stc
        /// <summary>回答納期区分２（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分２（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv2Stc
        {
            get { return _ansDelDtDiv2Stc; }
            set { _ansDelDtDiv2Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv3Stc
        /// <summary>回答納期区分３（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分３（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv3Stc
        {
            get { return _ansDelDtDiv3Stc; }
            set { _ansDelDtDiv3Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv4Stc
        /// <summary>回答納期区分４（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分４（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv4Stc
        {
            get { return _ansDelDtDiv4Stc; }
            set { _ansDelDtDiv4Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv5Stc
        /// <summary>回答納期区分５（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分５（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv5Stc
        {
            get { return _ansDelDtDiv5Stc; }
            set { _ansDelDtDiv5Stc = value; }
        }

        /// public propaty name  :  AnsDelDtDiv6Stc
        /// <summary>回答納期区分６（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分６（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtDiv6Stc
        {
            get { return _ansDelDtDiv6Stc; }
            set { _ansDelDtDiv6Stc = value; }
        }

        /// public propaty name  :  EntAnsDelDtStcDiv
        /// <summary>委託在庫回答納期区分（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託在庫回答納期区分（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 EntAnsDelDtStcDiv
        {
            get { return _entAnsDelDtStcDiv; }
            set { _entAnsDelDtStcDiv = value; }
        }

        /// public propaty name  :  PriAnsDelDtStcDiv
        /// <summary>優先在庫回答納期区分（在庫）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先在庫回答納期区分（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PriAnsDelDtStcDiv
        {
            get { return _priAnsDelDtStcDiv; }
            set { _priAnsDelDtStcDiv = value; }
        }

        /// public propaty name  :  AnsDelDtShoStcDiv
        /// <summary>回答納期区分（在庫不足）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分（在庫不足）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtShoStcDiv
        {
            get { return _ansDelDtShoStcDiv; }
            set { _ansDelDtShoStcDiv = value; }
        }

        /// public propaty name  :  AnsDelDtWioStcDiv
        /// <summary>回答納期区分（在庫数無し）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分（在庫数無し）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 AnsDelDtWioStcDiv
        {
            get { return _ansDelDtWioStcDiv; }
            set { _ansDelDtWioStcDiv = value; }
        }

        /// public propaty name  :  EntAnsDelDtShoDiv
        /// <summary>委託在庫回答納期区分（在庫不足）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託在庫回答納期区分（在庫不足）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 EntAnsDelDtShoDiv
        {
            get { return _entAnsDelDtShoDiv; }
            set { _entAnsDelDtShoDiv = value; }
        }

        /// public propaty name  :  EntAnsDelDtWioDiv
        /// <summary>委託在庫回答納期区分（在庫数無し）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託在庫回答納期区分（在庫数無し）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 EntAnsDelDtWioDiv
        {
            get { return _entAnsDelDtWioDiv; }
            set { _entAnsDelDtWioDiv = value; }
        }

        /// public propaty name  :  PriAnsDelDtShoDiv
        /// <summary>優先在庫回答納期区分（在庫不足）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先在庫回答納期区分（在庫不足）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PriAnsDelDtShoDiv
        {
            get { return _priAnsDelDtShoDiv; }
            set { _priAnsDelDtShoDiv = value; }
        }

        /// public propaty name  :  PriAnsDelDtWioDiv
        /// <summary>優先在庫回答納期区分（在庫数無し）プロパティ</summary>
        /// <value>0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先在庫回答納期区分（在庫数無し）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PriAnsDelDtWioDiv
        {
            get { return _priAnsDelDtWioDiv; }
            set { _priAnsDelDtWioDiv = value; }
        }
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// SCM納期設定マスタコンストラクタ
        /// </summary>
        /// <returns>SCMDeliDateStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMDeliDateSt()
        {
        }

        /// <summary>
        /// SCM納期設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="customerCode">得意先コード(0は全得意先)</param>
        /// <param name="answerDeadTime1">回答締切時刻１(HHMMSS)</param>
        /// <param name="answerDeadTime2">回答締切時刻２(HHMMSS)</param>
        /// <param name="answerDeadTime3">回答締切時刻３(HHMMSS)</param>
        /// <param name="answerDeadTime4">回答締切時刻４(HHMMSS)</param>
        /// <param name="answerDeadTime5">回答締切時刻５(HHMMSS)</param>
        /// <param name="answerDeadTime6">回答締切時刻６(HHMMSS)</param>
        /// <param name="answerDelivDate1">回答納期１(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate2">回答納期２(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate3">回答納期３(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate4">回答納期４(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate5">回答納期５(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate6">回答納期６(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDeadTime1Stc">回答締切時刻１（在庫）(HHMMSS)</param>
        /// <param name="answerDeadTime2Stc">回答締切時刻２（在庫）(HHMMSS)</param>
        /// <param name="answerDeadTime3Stc">回答締切時刻３（在庫）(HHMMSS)</param>
        /// <param name="answerDeadTime4Stc">回答締切時刻４（在庫）(HHMMSS)</param>
        /// <param name="answerDeadTime5Stc">回答締切時刻５（在庫）(HHMMSS)</param>
        /// <param name="answerDeadTime6Stc">回答締切時刻６（在庫）(HHMMSS)</param>
        /// <param name="answerDelivDate1Stc">回答納期１（在庫）(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate2Stc">回答納期２（在庫）(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate3Stc">回答納期３（在庫）(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate4Stc">回答納期４（在庫）(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate5Stc">回答納期５（在庫）(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="answerDelivDate6Stc">回答納期６（在庫）(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="entStckAnsDeliDtDiv">委託在庫回答納期区分(0:在庫設定に従う、1:棚番、2:委託用に設定　)</param>
        /// <param name="entStckAnsDeliDate">委託在庫回答納期(１便,２便,最終便,翌朝便 等　)</param>
        /// <param name="priStckAnsDeliDtDiv">優先在庫回答納期区分(0:在庫設定に従う、1:優先用に設定　)</param>
        /// <param name="priStckAnsDeliDate">優先在庫回答納期(１便,２便,最終便,翌朝便 等　)</param>
        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <param name="ansDelDatShortOfStc">回答納期（在庫不足）</param>
        /// <param name="ansDelDatWithoutStc">回答納期（在庫数無し）</param>
        /// <param name="entStcAnsDelDatShort">委託在庫回答納期（在庫不足）</param>
        /// <param name="entStcAnsDelDatWiout">委託在庫回答納期（在庫数無し）</param>
        /// <param name="priStcAnsDelDatShort">参照在庫回答納期（在庫不足）</param>
        /// <param name="priStcAnsDelDatWiout">参照在庫回答納期（在庫数無し）</param>
        // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        /// <param name="ansDelDtDiv1">回答納期区分１(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv2">回答納期区分２(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv3">回答納期区分３(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv4">回答納期区分４(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv5">回答納期区分５(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv6">回答納期区分６(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv1Stc">回答納期区分１（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv2Stc">回答納期区分２（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv3Stc">回答納期区分３（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv4Stc">回答納期区分４（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv5Stc">回答納期区分５（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtDiv6Stc">回答納期区分６（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="entAnsDelDtStcDiv">委託在庫回答納期区分（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="priAnsDelDtStcDiv">優先在庫回答納期区分（在庫）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtShoStcDiv">回答納期区分（在庫不足）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="ansDelDtWioStcDiv">回答納期区分（在庫数無し）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="entAnsDelDtShoDiv">委託在庫回答納期区分（在庫不足）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="entAnsDelDtWioDiv">委託在庫回答納期区分（在庫数無し）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="priAnsDelDtShoDiv">優先在庫回答納期区分（在庫不足）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// <param name="priAnsDelDtWioDiv">優先在庫回答納期区分（在庫数無し）(0:未設定,1:当日,2:1日,3:2～3日,4:1週間,5:要確認)</param>
        /// /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>SCMDeliDateStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //// 2011/01/06 >>>
        ////public SCMDeliDateSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 answerDeadTime1, Int32 answerDeadTime2, Int32 answerDeadTime3, Int32 answerDeadTime4, Int32 answerDeadTime5, Int32 answerDeadTime6, string answerDelivDate1, string answerDelivDate2, string answerDelivDate3, string answerDelivDate4, string answerDelivDate5, string answerDelivDate6, string enterpriseName, string updEmployeeName)
        //// 2011/10/11 >>>
        ////public SCMDeliDateSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 answerDeadTime1, Int32 answerDeadTime2, Int32 answerDeadTime3, Int32 answerDeadTime4, Int32 answerDeadTime5, Int32 answerDeadTime6, string answerDelivDate1, string answerDelivDate2, string answerDelivDate3, string answerDelivDate4, string answerDelivDate5, string answerDelivDate6, string enterpriseName, string updEmployeeName, Int32 answerDeadTime1Stc, Int32 answerDeadTime2Stc, Int32 answerDeadTime3Stc, Int32 answerDeadTime4Stc, Int32 answerDeadTime5Stc, Int32 answerDeadTime6Stc, string answerDelivDate1Stc, string answerDelivDate2Stc, string answerDelivDate3Stc, string answerDelivDate4Stc, string answerDelivDate5Stc, string answerDelivDate6Stc, Int32 entStckAnsDeliDtDiv, string entStckAnsDeliDate)
        //// 2012/08/30 UPD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        ////public SCMDeliDateSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 answerDeadTime1, Int32 answerDeadTime2, Int32 answerDeadTime3, Int32 answerDeadTime4, Int32 answerDeadTime5, Int32 answerDeadTime6, string answerDelivDate1, string answerDelivDate2, string answerDelivDate3, string answerDelivDate4, string answerDelivDate5, string answerDelivDate6, string enterpriseName, string updEmployeeName, Int32 answerDeadTime1Stc, Int32 answerDeadTime2Stc, Int32 answerDeadTime3Stc, Int32 answerDeadTime4Stc, Int32 answerDeadTime5Stc, Int32 answerDeadTime6Stc, string answerDelivDate1Stc, string answerDelivDate2Stc, string answerDelivDate3Stc, string answerDelivDate4Stc, string answerDelivDate5Stc, string answerDelivDate6Stc, Int32 entStckAnsDeliDtDiv, string entStckAnsDeliDate, Int32 priStckAnsDeliDtDiv, string priStckAnsDeliDate)
        //public SCMDeliDateSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 answerDeadTime1, Int32 answerDeadTime2, Int32 answerDeadTime3, Int32 answerDeadTime4, Int32 answerDeadTime5, Int32 answerDeadTime6, string answerDelivDate1, string answerDelivDate2, string answerDelivDate3, string answerDelivDate4, string answerDelivDate5, string answerDelivDate6, string enterpriseName, string updEmployeeName, Int32 answerDeadTime1Stc, Int32 answerDeadTime2Stc, Int32 answerDeadTime3Stc, Int32 answerDeadTime4Stc, Int32 answerDeadTime5Stc, Int32 answerDeadTime6Stc, string answerDelivDate1Stc, string answerDelivDate2Stc, string answerDelivDate3Stc, string answerDelivDate4Stc, string answerDelivDate5Stc, string answerDelivDate6Stc, Int32 entStckAnsDeliDtDiv, string entStckAnsDeliDate, Int32 priStckAnsDeliDtDiv, string priStckAnsDeliDate, string ansDelDatShortOfStc, string ansDelDatWithoutStc, string entStcAnsDelDatShort, string entStcAnsDelDatWiout, string priStcAnsDelDatShort, string priStcAnsDelDatWiout)
        //// 2012/08/30 UPD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// 2011/10/11 <<<
        //// 2011/01/06 <<<
        #endregion
        public SCMDeliDateSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 answerDeadTime1, Int32 answerDeadTime2, Int32 answerDeadTime3, Int32 answerDeadTime4, Int32 answerDeadTime5, Int32 answerDeadTime6, string answerDelivDate1, string answerDelivDate2, string answerDelivDate3, string answerDelivDate4, string answerDelivDate5, string answerDelivDate6, string enterpriseName, string updEmployeeName, Int32 answerDeadTime1Stc, Int32 answerDeadTime2Stc, Int32 answerDeadTime3Stc, Int32 answerDeadTime4Stc, Int32 answerDeadTime5Stc, Int32 answerDeadTime6Stc, string answerDelivDate1Stc, string answerDelivDate2Stc, string answerDelivDate3Stc, string answerDelivDate4Stc, string answerDelivDate5Stc, string answerDelivDate6Stc, Int32 entStckAnsDeliDtDiv, string entStckAnsDeliDate, Int32 priStckAnsDeliDtDiv, string priStckAnsDeliDate, string ansDelDatShortOfStc, string ansDelDatWithoutStc, string entStcAnsDelDatShort, string entStcAnsDelDatWiout, string priStcAnsDelDatShort, string priStcAnsDelDatWiout
            ,Int16 ansDelDtDiv1, Int16 ansDelDtDiv2, Int16 ansDelDtDiv3, Int16 ansDelDtDiv4, Int16 ansDelDtDiv5, Int16 ansDelDtDiv6, Int16 ansDelDtDiv1Stc, Int16 ansDelDtDiv2Stc, Int16 ansDelDtDiv3Stc, Int16 ansDelDtDiv4Stc, Int16 ansDelDtDiv5Stc, Int16 ansDelDtDiv6Stc, Int16 entAnsDelDtStcDiv, Int16 priAnsDelDtStcDiv, Int16 ansDelDtShoStcDiv, Int16 ansDelDtWioStcDiv, Int16 entAnsDelDtShoDiv, Int16 entAnsDelDtWioDiv, Int16 priAnsDelDtShoDiv, Int16 priAnsDelDtWioDiv
            )
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._answerDeadTime1 = answerDeadTime1;
            this._answerDeadTime2 = answerDeadTime2;
            this._answerDeadTime3 = answerDeadTime3;
            this._answerDeadTime4 = answerDeadTime4;
            this._answerDeadTime5 = answerDeadTime5;
            this._answerDeadTime6 = answerDeadTime6;
            this._answerDelivDate1 = answerDelivDate1;
            this._answerDelivDate2 = answerDelivDate2;
            this._answerDelivDate3 = answerDelivDate3;
            this._answerDelivDate4 = answerDelivDate4;
            this._answerDelivDate5 = answerDelivDate5;
            this._answerDelivDate6 = answerDelivDate6;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // 2011/01/06 Add >>>
            this._answerDeadTime1Stc = answerDeadTime1Stc;
            this._answerDeadTime2Stc = answerDeadTime2Stc;
            this._answerDeadTime3Stc = answerDeadTime3Stc;
            this._answerDeadTime4Stc = answerDeadTime4Stc;
            this._answerDeadTime5Stc = answerDeadTime5Stc;
            this._answerDeadTime6Stc = answerDeadTime6Stc;
            this._answerDelivDate1Stc = answerDelivDate1Stc;
            this._answerDelivDate2Stc = answerDelivDate2Stc;
            this._answerDelivDate3Stc = answerDelivDate3Stc;
            this._answerDelivDate4Stc = answerDelivDate4Stc;
            this._answerDelivDate5Stc = answerDelivDate5Stc;
            this._answerDelivDate6Stc = answerDelivDate6Stc;
            this._entStckAnsDeliDtDiv = entStckAnsDeliDtDiv;
            this._entStckAnsDeliDate = entStckAnsDeliDate;
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            this._priStckAnsDeliDtDiv = priStckAnsDeliDtDiv;
            this._priStckAnsDeliDate = priStckAnsDeliDate;
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._ansDelDatShortOfStc = ansDelDatShortOfStc;
            this._ansDelDatWithoutStc = ansDelDatWithoutStc;
            this._entStcAnsDelDatShort = entStcAnsDelDatShort;
            this._entStcAnsDelDatWiout = entStcAnsDelDatWiout;
            this._priStcAnsDelDatShort = priStcAnsDelDatShort;
            this._priStcAnsDelDatWiout = priStcAnsDelDatWiout;
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._ansDelDtDiv1 = ansDelDtDiv1;
            this._ansDelDtDiv2 = ansDelDtDiv2;
            this._ansDelDtDiv3 = ansDelDtDiv3;
            this._ansDelDtDiv4 = ansDelDtDiv4;
            this._ansDelDtDiv5 = ansDelDtDiv5;
            this._ansDelDtDiv6 = ansDelDtDiv6;
            this._ansDelDtDiv1Stc = ansDelDtDiv1Stc;
            this._ansDelDtDiv2Stc = ansDelDtDiv2Stc;
            this._ansDelDtDiv3Stc = ansDelDtDiv3Stc;
            this._ansDelDtDiv4Stc = ansDelDtDiv4Stc;
            this._ansDelDtDiv5Stc = ansDelDtDiv5Stc;
            this._ansDelDtDiv6Stc = ansDelDtDiv6Stc;
            this._entAnsDelDtStcDiv = entAnsDelDtStcDiv;
            this._priAnsDelDtStcDiv = priAnsDelDtStcDiv;
            this._ansDelDtShoStcDiv = ansDelDtShoStcDiv;
            this._ansDelDtWioStcDiv = ansDelDtWioStcDiv;
            this._entAnsDelDtShoDiv = entAnsDelDtShoDiv;
            this._entAnsDelDtWioDiv = entAnsDelDtWioDiv;
            this._priAnsDelDtShoDiv = priAnsDelDtShoDiv;
            this._priAnsDelDtWioDiv = priAnsDelDtWioDiv;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// SCM納期設定マスタ複製処理
        /// </summary>
        /// <returns>SCMDeliDateStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSCMDeliDateStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMDeliDateSt Clone()
        {
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// 2011/01/06 >>>
            ////return new SCMDeliDateSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._answerDeadTime1, this._answerDeadTime2, this._answerDeadTime3, this._answerDeadTime4, this._answerDeadTime5, this._answerDeadTime6, this._answerDelivDate1, this._answerDelivDate2, this._answerDelivDate3, this._answerDelivDate4, this._answerDelivDate5, this._answerDelivDate6, this._enterpriseName, this._updEmployeeName);
            //// 2011/10/11 Add >>>
            ////return new SCMDeliDateSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._answerDeadTime1, this._answerDeadTime2, this._answerDeadTime3, this._answerDeadTime4, this._answerDeadTime5, this._answerDeadTime6, this._answerDelivDate1, this._answerDelivDate2, this._answerDelivDate3, this._answerDelivDate4, this._answerDelivDate5, this._answerDelivDate6, this._enterpriseName, this._updEmployeeName, this._answerDeadTime1Stc, this._answerDeadTime2Stc, this._answerDeadTime3Stc, this._answerDeadTime4Stc, this._answerDeadTime5Stc, this._answerDeadTime6Stc, this._answerDelivDate1Stc, this._answerDelivDate2Stc, this._answerDelivDate3Stc, this._answerDelivDate4Stc, this._answerDelivDate5Stc, this._answerDelivDate6Stc, this._entStckAnsDeliDtDiv, this._entStckAnsDeliDate);
            //// 2012/08/30 UPD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            ////return new SCMDeliDateSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._answerDeadTime1, this._answerDeadTime2, this._answerDeadTime3, this._answerDeadTime4, this._answerDeadTime5, this._answerDeadTime6, this._answerDelivDate1, this._answerDelivDate2, this._answerDelivDate3, this._answerDelivDate4, this._answerDelivDate5, this._answerDelivDate6, this._enterpriseName, this._updEmployeeName, this._answerDeadTime1Stc, this._answerDeadTime2Stc, this._answerDeadTime3Stc, this._answerDeadTime4Stc, this._answerDeadTime5Stc, this._answerDeadTime6Stc, this._answerDelivDate1Stc, this._answerDelivDate2Stc, this._answerDelivDate3Stc, this._answerDelivDate4Stc, this._answerDelivDate5Stc, this._answerDelivDate6Stc, this._entStckAnsDeliDtDiv, this._entStckAnsDeliDate, this._priStckAnsDeliDtDiv, this._priStckAnsDeliDate);
            //return new SCMDeliDateSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._answerDeadTime1, this._answerDeadTime2, this._answerDeadTime3, this._answerDeadTime4, this._answerDeadTime5, this._answerDeadTime6, this._answerDelivDate1, this._answerDelivDate2, this._answerDelivDate3, this._answerDelivDate4, this._answerDelivDate5, this._answerDelivDate6, this._enterpriseName, this._updEmployeeName, this._answerDeadTime1Stc, this._answerDeadTime2Stc, this._answerDeadTime3Stc, this._answerDeadTime4Stc, this._answerDeadTime5Stc, this._answerDeadTime6Stc, this._answerDelivDate1Stc, this._answerDelivDate2Stc, this._answerDelivDate3Stc, this._answerDelivDate4Stc, this._answerDelivDate5Stc, this._answerDelivDate6Stc, this._entStckAnsDeliDtDiv, this._entStckAnsDeliDate, this._priStckAnsDeliDtDiv, this._priStckAnsDeliDate, this._ansDelDatShortOfStc, this._ansDelDatWithoutStc, this._entStcAnsDelDatShort, this._entStcAnsDelDatWiout, this._priStcAnsDelDatShort, this._priStcAnsDelDatWiout);
            //// 2012/08/30 UPD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //// 2011/10/11 Add <<<
            //// 2011/01/06 <<<
            #endregion
            return new SCMDeliDateSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._answerDeadTime1, this._answerDeadTime2, this._answerDeadTime3, this._answerDeadTime4, this._answerDeadTime5, this._answerDeadTime6, this._answerDelivDate1, this._answerDelivDate2, this._answerDelivDate3, this._answerDelivDate4, this._answerDelivDate5, this._answerDelivDate6, this._enterpriseName, this._updEmployeeName, this._answerDeadTime1Stc, this._answerDeadTime2Stc, this._answerDeadTime3Stc, this._answerDeadTime4Stc, this._answerDeadTime5Stc, this._answerDeadTime6Stc, this._answerDelivDate1Stc, this._answerDelivDate2Stc, this._answerDelivDate3Stc, this._answerDelivDate4Stc, this._answerDelivDate5Stc, this._answerDelivDate6Stc, this._entStckAnsDeliDtDiv, this._entStckAnsDeliDate, this._priStckAnsDeliDtDiv, this._priStckAnsDeliDate, this._ansDelDatShortOfStc, this._ansDelDatWithoutStc, this._entStcAnsDelDatShort, this._entStcAnsDelDatWiout, this._priStcAnsDelDatShort, this._priStcAnsDelDatWiout
                , this._ansDelDtDiv1, this._ansDelDtDiv2, this._ansDelDtDiv3, this._ansDelDtDiv4, this._ansDelDtDiv5, this._ansDelDtDiv6, this._ansDelDtDiv1Stc, this._ansDelDtDiv2Stc, this._ansDelDtDiv3Stc, this._ansDelDtDiv4Stc, this._ansDelDtDiv5Stc, this._ansDelDtDiv6Stc, this._entAnsDelDtStcDiv, this._priAnsDelDtStcDiv, this._ansDelDtShoStcDiv, this._ansDelDtWioStcDiv, this._entAnsDelDtShoDiv, this._entAnsDelDtWioDiv, this._priAnsDelDtShoDiv, this._priAnsDelDtWioDiv
                );
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// SCM納期設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMDeliDateStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SCMDeliDateSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.AnswerDeadTime1 == target.AnswerDeadTime1)
                 && (this.AnswerDeadTime2 == target.AnswerDeadTime2)
                 && (this.AnswerDeadTime3 == target.AnswerDeadTime3)
                 && (this.AnswerDeadTime4 == target.AnswerDeadTime4)
                 && (this.AnswerDeadTime5 == target.AnswerDeadTime5)
                 && (this.AnswerDeadTime6 == target.AnswerDeadTime6)
                 && (this.AnswerDelivDate1 == target.AnswerDelivDate1)
                 && (this.AnswerDelivDate2 == target.AnswerDelivDate2)
                 && (this.AnswerDelivDate3 == target.AnswerDelivDate3)
                 && (this.AnswerDelivDate4 == target.AnswerDelivDate4)
                 && (this.AnswerDelivDate5 == target.AnswerDelivDate5)
                 && (this.AnswerDelivDate6 == target.AnswerDelivDate6)
                // 2011/01/06 Add >>>
                 && (this.AnswerDeadTime1Stc == target.AnswerDeadTime1Stc)
                 && (this.AnswerDeadTime2Stc == target.AnswerDeadTime2Stc)
                 && (this.AnswerDeadTime3Stc == target.AnswerDeadTime3Stc)
                 && (this.AnswerDeadTime4Stc == target.AnswerDeadTime4Stc)
                 && (this.AnswerDeadTime5Stc == target.AnswerDeadTime5Stc)
                 && (this.AnswerDeadTime6Stc == target.AnswerDeadTime6Stc)
                 && (this.AnswerDelivDate1Stc == target.AnswerDelivDate1Stc)
                 && (this.AnswerDelivDate2Stc == target.AnswerDelivDate2Stc)
                 && (this.AnswerDelivDate3Stc == target.AnswerDelivDate3Stc)
                 && (this.AnswerDelivDate4Stc == target.AnswerDelivDate4Stc)
                 && (this.AnswerDelivDate5Stc == target.AnswerDelivDate5Stc)
                 && (this.AnswerDelivDate6Stc == target.AnswerDelivDate6Stc)
                 && (this.EntStckAnsDeliDtDiv == target.EntStckAnsDeliDtDiv)
                 && (this.EntStckAnsDeliDate == target.EntStckAnsDeliDate)
                // 2011/01/06 Add <<<
                // 2011/10/11 Add >>>
                 && (this.PriStckAnsDeliDtDiv == target.PriStckAnsDeliDtDiv)
                 && (this.PriStckAnsDeliDate == target.PriStckAnsDeliDate)
                // 2011/10/11 Add <<<
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.AnsDelDatShortOfStc == target.AnsDelDatShortOfStc)
                 && (this.AnsDelDatWithoutStc == target.AnsDelDatWithoutStc)
                 && (this.EntStcAnsDelDatShort == target.EntStcAnsDelDatShort)
                 && (this.EntStcAnsDelDatWiout == target.EntStcAnsDelDatWiout)
                 && (this.PriStcAnsDelDatShort == target.PriStcAnsDelDatShort)
                 && (this.PriStcAnsDelDatWiout == target.PriStcAnsDelDatWiout)
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.AnsDelDtDiv1 == target.AnsDelDtDiv1)
                 && (this.AnsDelDtDiv2 == target.AnsDelDtDiv2)
                 && (this.AnsDelDtDiv3 == target.AnsDelDtDiv3)
                 && (this.AnsDelDtDiv4 == target.AnsDelDtDiv4)
                 && (this.AnsDelDtDiv5 == target.AnsDelDtDiv5)
                 && (this.AnsDelDtDiv6 == target.AnsDelDtDiv6)
                 && (this.AnsDelDtDiv1Stc == target.AnsDelDtDiv1Stc)
                 && (this.AnsDelDtDiv2Stc == target.AnsDelDtDiv2Stc)
                 && (this.AnsDelDtDiv3Stc == target.AnsDelDtDiv3Stc)
                 && (this.AnsDelDtDiv4Stc == target.AnsDelDtDiv4Stc)
                 && (this.AnsDelDtDiv5Stc == target.AnsDelDtDiv5Stc)
                 && (this.AnsDelDtDiv6Stc == target.AnsDelDtDiv6Stc)
                 && (this.EntAnsDelDtStcDiv == target.EntAnsDelDtStcDiv)
                 && (this.PriAnsDelDtStcDiv == target.PriAnsDelDtStcDiv)
                 && (this.AnsDelDtShoStcDiv == target.AnsDelDtShoStcDiv)
                 && (this.AnsDelDtWioStcDiv == target.AnsDelDtWioStcDiv)
                 && (this.EntAnsDelDtShoDiv == target.EntAnsDelDtShoDiv)
                 && (this.EntAnsDelDtWioDiv == target.EntAnsDelDtWioDiv)
                 && (this.PriAnsDelDtShoDiv == target.PriAnsDelDtShoDiv)
                 && (this.PriAnsDelDtWioDiv == target.PriAnsDelDtWioDiv)
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// SCM納期設定マスタ比較処理
        /// </summary>
        /// <param name="sCMDeliDateSt1">
        ///                    比較するSCMDeliDateStクラスのインスタンス
        /// </param>
        /// <param name="sCMDeliDateSt2">比較するSCMDeliDateStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SCMDeliDateSt sCMDeliDateSt1, SCMDeliDateSt sCMDeliDateSt2)
        {
            return ((sCMDeliDateSt1.CreateDateTime == sCMDeliDateSt2.CreateDateTime)
                 && (sCMDeliDateSt1.UpdateDateTime == sCMDeliDateSt2.UpdateDateTime)
                 && (sCMDeliDateSt1.EnterpriseCode == sCMDeliDateSt2.EnterpriseCode)
                 && (sCMDeliDateSt1.FileHeaderGuid == sCMDeliDateSt2.FileHeaderGuid)
                 && (sCMDeliDateSt1.UpdEmployeeCode == sCMDeliDateSt2.UpdEmployeeCode)
                 && (sCMDeliDateSt1.UpdAssemblyId1 == sCMDeliDateSt2.UpdAssemblyId1)
                 && (sCMDeliDateSt1.UpdAssemblyId2 == sCMDeliDateSt2.UpdAssemblyId2)
                 && (sCMDeliDateSt1.LogicalDeleteCode == sCMDeliDateSt2.LogicalDeleteCode)
                 && (sCMDeliDateSt1.SectionCode == sCMDeliDateSt2.SectionCode)
                 && (sCMDeliDateSt1.CustomerCode == sCMDeliDateSt2.CustomerCode)
                 && (sCMDeliDateSt1.AnswerDeadTime1 == sCMDeliDateSt2.AnswerDeadTime1)
                 && (sCMDeliDateSt1.AnswerDeadTime2 == sCMDeliDateSt2.AnswerDeadTime2)
                 && (sCMDeliDateSt1.AnswerDeadTime3 == sCMDeliDateSt2.AnswerDeadTime3)
                 && (sCMDeliDateSt1.AnswerDeadTime4 == sCMDeliDateSt2.AnswerDeadTime4)
                 && (sCMDeliDateSt1.AnswerDeadTime5 == sCMDeliDateSt2.AnswerDeadTime5)
                 && (sCMDeliDateSt1.AnswerDeadTime6 == sCMDeliDateSt2.AnswerDeadTime6)
                 && (sCMDeliDateSt1.AnswerDelivDate1 == sCMDeliDateSt2.AnswerDelivDate1)
                 && (sCMDeliDateSt1.AnswerDelivDate2 == sCMDeliDateSt2.AnswerDelivDate2)
                 && (sCMDeliDateSt1.AnswerDelivDate3 == sCMDeliDateSt2.AnswerDelivDate3)
                 && (sCMDeliDateSt1.AnswerDelivDate4 == sCMDeliDateSt2.AnswerDelivDate4)
                 && (sCMDeliDateSt1.AnswerDelivDate5 == sCMDeliDateSt2.AnswerDelivDate5)
                 && (sCMDeliDateSt1.AnswerDelivDate6 == sCMDeliDateSt2.AnswerDelivDate6)
                // 2011/01/06 Add >>>
                 && (sCMDeliDateSt1.AnswerDeadTime1Stc == sCMDeliDateSt2.AnswerDeadTime1Stc)
                 && (sCMDeliDateSt1.AnswerDeadTime2Stc == sCMDeliDateSt2.AnswerDeadTime2Stc)
                 && (sCMDeliDateSt1.AnswerDeadTime3Stc == sCMDeliDateSt2.AnswerDeadTime3Stc)
                 && (sCMDeliDateSt1.AnswerDeadTime4Stc == sCMDeliDateSt2.AnswerDeadTime4Stc)
                 && (sCMDeliDateSt1.AnswerDeadTime5Stc == sCMDeliDateSt2.AnswerDeadTime5Stc)
                 && (sCMDeliDateSt1.AnswerDeadTime6Stc == sCMDeliDateSt2.AnswerDeadTime6Stc)
                 && (sCMDeliDateSt1.AnswerDelivDate1Stc == sCMDeliDateSt2.AnswerDelivDate1Stc)
                 && (sCMDeliDateSt1.AnswerDelivDate2Stc == sCMDeliDateSt2.AnswerDelivDate2Stc)
                 && (sCMDeliDateSt1.AnswerDelivDate3Stc == sCMDeliDateSt2.AnswerDelivDate3Stc)
                 && (sCMDeliDateSt1.AnswerDelivDate4Stc == sCMDeliDateSt2.AnswerDelivDate4Stc)
                 && (sCMDeliDateSt1.AnswerDelivDate5Stc == sCMDeliDateSt2.AnswerDelivDate5Stc)
                 && (sCMDeliDateSt1.AnswerDelivDate6Stc == sCMDeliDateSt2.AnswerDelivDate6Stc)
                 && (sCMDeliDateSt1.EntStckAnsDeliDtDiv == sCMDeliDateSt2.EntStckAnsDeliDtDiv)
                 && (sCMDeliDateSt1.EntStckAnsDeliDate == sCMDeliDateSt2.EntStckAnsDeliDate)
                // 2011/01/06 Add <<<
                // 2011/10/11 Add >>>
                 && (sCMDeliDateSt1.PriStckAnsDeliDtDiv == sCMDeliDateSt2.PriStckAnsDeliDtDiv)
                 && (sCMDeliDateSt1.PriStckAnsDeliDate == sCMDeliDateSt2.PriStckAnsDeliDate)
                // 2011/10/11 Add <<<
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (sCMDeliDateSt1.AnsDelDatShortOfStc == sCMDeliDateSt2.AnsDelDatShortOfStc)
                 && (sCMDeliDateSt1.AnsDelDatWithoutStc == sCMDeliDateSt2.AnsDelDatWithoutStc)
                 && (sCMDeliDateSt1.EntStcAnsDelDatShort == sCMDeliDateSt2.EntStcAnsDelDatShort)
                 && (sCMDeliDateSt1.EntStcAnsDelDatWiout == sCMDeliDateSt2.EntStcAnsDelDatWiout)
                 && (sCMDeliDateSt1.PriStcAnsDelDatShort == sCMDeliDateSt2.PriStcAnsDelDatShort)
                 && (sCMDeliDateSt1.PriStcAnsDelDatWiout == sCMDeliDateSt2.PriStcAnsDelDatWiout)
                // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (sCMDeliDateSt1.AnsDelDtDiv1 == sCMDeliDateSt2.AnsDelDtDiv1)
                 && (sCMDeliDateSt1.AnsDelDtDiv2 == sCMDeliDateSt2.AnsDelDtDiv2)
                 && (sCMDeliDateSt1.AnsDelDtDiv3 == sCMDeliDateSt2.AnsDelDtDiv3)
                 && (sCMDeliDateSt1.AnsDelDtDiv4 == sCMDeliDateSt2.AnsDelDtDiv4)
                 && (sCMDeliDateSt1.AnsDelDtDiv5 == sCMDeliDateSt2.AnsDelDtDiv5)
                 && (sCMDeliDateSt1.AnsDelDtDiv6 == sCMDeliDateSt2.AnsDelDtDiv6)
                 && (sCMDeliDateSt1.AnsDelDtDiv1Stc == sCMDeliDateSt2.AnsDelDtDiv1Stc)
                 && (sCMDeliDateSt1.AnsDelDtDiv2Stc == sCMDeliDateSt2.AnsDelDtDiv2Stc)
                 && (sCMDeliDateSt1.AnsDelDtDiv3Stc == sCMDeliDateSt2.AnsDelDtDiv3Stc)
                 && (sCMDeliDateSt1.AnsDelDtDiv4Stc == sCMDeliDateSt2.AnsDelDtDiv4Stc)
                 && (sCMDeliDateSt1.AnsDelDtDiv5Stc == sCMDeliDateSt2.AnsDelDtDiv5Stc)
                 && (sCMDeliDateSt1.AnsDelDtDiv6Stc == sCMDeliDateSt2.AnsDelDtDiv6Stc)
                 && (sCMDeliDateSt1.EntAnsDelDtStcDiv == sCMDeliDateSt2.EntAnsDelDtStcDiv)
                 && (sCMDeliDateSt1.PriAnsDelDtStcDiv == sCMDeliDateSt2.PriAnsDelDtStcDiv)
                 && (sCMDeliDateSt1.AnsDelDtShoStcDiv == sCMDeliDateSt2.AnsDelDtShoStcDiv)
                 && (sCMDeliDateSt1.AnsDelDtWioStcDiv == sCMDeliDateSt2.AnsDelDtWioStcDiv)
                 && (sCMDeliDateSt1.EntAnsDelDtShoDiv == sCMDeliDateSt2.EntAnsDelDtShoDiv)
                 && (sCMDeliDateSt1.EntAnsDelDtWioDiv == sCMDeliDateSt2.EntAnsDelDtWioDiv)
                 && (sCMDeliDateSt1.PriAnsDelDtShoDiv == sCMDeliDateSt2.PriAnsDelDtShoDiv)
                 && (sCMDeliDateSt1.PriAnsDelDtWioDiv == sCMDeliDateSt2.PriAnsDelDtWioDiv)
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                 && (sCMDeliDateSt1.EnterpriseName == sCMDeliDateSt2.EnterpriseName)
                 && (sCMDeliDateSt1.UpdEmployeeName == sCMDeliDateSt2.UpdEmployeeName));
        }
        /// <summary>
        /// SCM納期設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMDeliDateStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SCMDeliDateSt target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.AnswerDeadTime1 != target.AnswerDeadTime1) resList.Add("AnswerDeadTime1");
            if (this.AnswerDeadTime2 != target.AnswerDeadTime2) resList.Add("AnswerDeadTime2");
            if (this.AnswerDeadTime3 != target.AnswerDeadTime3) resList.Add("AnswerDeadTime3");
            if (this.AnswerDeadTime4 != target.AnswerDeadTime4) resList.Add("AnswerDeadTime4");
            if (this.AnswerDeadTime5 != target.AnswerDeadTime5) resList.Add("AnswerDeadTime5");
            if (this.AnswerDeadTime6 != target.AnswerDeadTime6) resList.Add("AnswerDeadTime6");
            if (this.AnswerDelivDate1 != target.AnswerDelivDate1) resList.Add("AnswerDelivDate1");
            if (this.AnswerDelivDate2 != target.AnswerDelivDate2) resList.Add("AnswerDelivDate2");
            if (this.AnswerDelivDate3 != target.AnswerDelivDate3) resList.Add("AnswerDelivDate3");
            if (this.AnswerDelivDate4 != target.AnswerDelivDate4) resList.Add("AnswerDelivDate4");
            if (this.AnswerDelivDate5 != target.AnswerDelivDate5) resList.Add("AnswerDelivDate5");
            if (this.AnswerDelivDate6 != target.AnswerDelivDate6) resList.Add("AnswerDelivDate6");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // 2011/01/06 Add >>>
            if (this.AnswerDeadTime1Stc != target.AnswerDeadTime1Stc) resList.Add("AnswerDeadTime1Stc");
            if (this.AnswerDeadTime2Stc != target.AnswerDeadTime2Stc) resList.Add("AnswerDeadTime2Stc");
            if (this.AnswerDeadTime3Stc != target.AnswerDeadTime3Stc) resList.Add("AnswerDeadTime3Stc");
            if (this.AnswerDeadTime4Stc != target.AnswerDeadTime4Stc) resList.Add("AnswerDeadTime4Stc");
            if (this.AnswerDeadTime5Stc != target.AnswerDeadTime5Stc) resList.Add("AnswerDeadTime5Stc");
            if (this.AnswerDeadTime6Stc != target.AnswerDeadTime6Stc) resList.Add("AnswerDeadTime6Stc");
            if (this.AnswerDelivDate1Stc != target.AnswerDelivDate1Stc) resList.Add("AnswerDelivDate1Stc");
            if (this.AnswerDelivDate2Stc != target.AnswerDelivDate2Stc) resList.Add("AnswerDelivDate2Stc");
            if (this.AnswerDelivDate3Stc != target.AnswerDelivDate3Stc) resList.Add("AnswerDelivDate3Stc");
            if (this.AnswerDelivDate4Stc != target.AnswerDelivDate4Stc) resList.Add("AnswerDelivDate4Stc");
            if (this.AnswerDelivDate5Stc != target.AnswerDelivDate5Stc) resList.Add("AnswerDelivDate5Stc");
            if (this.AnswerDelivDate6Stc != target.AnswerDelivDate6Stc) resList.Add("AnswerDelivDate6Stc");
            if (this.EntStckAnsDeliDtDiv != target.EntStckAnsDeliDtDiv) resList.Add("EntStckAnsDeliDtDiv");
            if (this.EntStckAnsDeliDate != target.EntStckAnsDeliDate) resList.Add("EntStckAnsDeliDate");
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            if (this.PriStckAnsDeliDtDiv != target.PriStckAnsDeliDtDiv) resList.Add("PriStckAnsDeliDtDiv");
            if (this.PriStckAnsDeliDate != target.PriStckAnsDeliDate) resList.Add("PriStckAnsDeliDate");
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AnsDelDatShortOfStc != target.AnsDelDatShortOfStc) resList.Add("AnsDelDatShortOfStc");
            if (this.AnsDelDatWithoutStc != target.AnsDelDatWithoutStc) resList.Add("AnsDelDatWithoutStc");
            if (this.EntStcAnsDelDatShort != target.EntStcAnsDelDatShort) resList.Add("EntStcAnsDelDatShort");
            if (this.EntStcAnsDelDatWiout != target.EntStcAnsDelDatWiout) resList.Add("EntStcAnsDelDatWiout");
            if (this.PriStcAnsDelDatShort != target.PriStcAnsDelDatShort) resList.Add("PriStcAnsDelDatShort");
            if (this.PriStcAnsDelDatWiout != target.PriStcAnsDelDatWiout) resList.Add("PriStcAnsDelDatWiout");
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AnsDelDtDiv1 != target.AnsDelDtDiv1) resList.Add("AnsDelDtDiv1");
            if (this.AnsDelDtDiv2 != target.AnsDelDtDiv2) resList.Add("AnsDelDtDiv2");
            if (this.AnsDelDtDiv3 != target.AnsDelDtDiv3) resList.Add("AnsDelDtDiv3");
            if (this.AnsDelDtDiv4 != target.AnsDelDtDiv4) resList.Add("AnsDelDtDiv4");
            if (this.AnsDelDtDiv5 != target.AnsDelDtDiv5) resList.Add("AnsDelDtDiv5");
            if (this.AnsDelDtDiv6 != target.AnsDelDtDiv6) resList.Add("AnsDelDtDiv6");
            if (this.AnsDelDtDiv1Stc != target.AnsDelDtDiv1Stc) resList.Add("AnsDelDtDiv1Stc");
            if (this.AnsDelDtDiv2Stc != target.AnsDelDtDiv2Stc) resList.Add("AnsDelDtDiv2Stc");
            if (this.AnsDelDtDiv3Stc != target.AnsDelDtDiv3Stc) resList.Add("AnsDelDtDiv3Stc");
            if (this.AnsDelDtDiv4Stc != target.AnsDelDtDiv4Stc) resList.Add("AnsDelDtDiv4Stc");
            if (this.AnsDelDtDiv5Stc != target.AnsDelDtDiv5Stc) resList.Add("AnsDelDtDiv5Stc");
            if (this.AnsDelDtDiv6Stc != target.AnsDelDtDiv6Stc) resList.Add("AnsDelDtDiv6Stc");
            if (this.EntAnsDelDtStcDiv != target.EntAnsDelDtStcDiv) resList.Add("EntAnsDelDtStcDiv");
            if (this.PriAnsDelDtStcDiv != target.PriAnsDelDtStcDiv) resList.Add("PriAnsDelDtStcDiv");
            if (this.AnsDelDtShoStcDiv != target.AnsDelDtShoStcDiv) resList.Add("AnsDelDtShoStcDiv");
            if (this.AnsDelDtWioStcDiv != target.AnsDelDtWioStcDiv) resList.Add("AnsDelDtWioStcDiv");
            if (this.EntAnsDelDtShoDiv != target.EntAnsDelDtShoDiv) resList.Add("EntAnsDelDtShoDiv");
            if (this.EntAnsDelDtWioDiv != target.EntAnsDelDtWioDiv) resList.Add("EntAnsDelDtWioDiv");
            if (this.PriAnsDelDtShoDiv != target.PriAnsDelDtShoDiv) resList.Add("PriAnsDelDtShoDiv");
            if (this.PriAnsDelDtWioDiv != target.PriAnsDelDtWioDiv) resList.Add("PriAnsDelDtWioDiv");
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// SCM納期設定マスタ比較処理
        /// </summary>
        /// <param name="sCMDeliDateSt1">比較するSCMDeliDateStクラスのインスタンス</param>
        /// <param name="sCMDeliDateSt2">比較するSCMDeliDateStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SCMDeliDateSt sCMDeliDateSt1, SCMDeliDateSt sCMDeliDateSt2)
        {
            ArrayList resList = new ArrayList();
            if (sCMDeliDateSt1.CreateDateTime != sCMDeliDateSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (sCMDeliDateSt1.UpdateDateTime != sCMDeliDateSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sCMDeliDateSt1.EnterpriseCode != sCMDeliDateSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sCMDeliDateSt1.FileHeaderGuid != sCMDeliDateSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sCMDeliDateSt1.UpdEmployeeCode != sCMDeliDateSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sCMDeliDateSt1.UpdAssemblyId1 != sCMDeliDateSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sCMDeliDateSt1.UpdAssemblyId2 != sCMDeliDateSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sCMDeliDateSt1.LogicalDeleteCode != sCMDeliDateSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sCMDeliDateSt1.SectionCode != sCMDeliDateSt2.SectionCode) resList.Add("SectionCode");
            if (sCMDeliDateSt1.CustomerCode != sCMDeliDateSt2.CustomerCode) resList.Add("CustomerCode");
            if (sCMDeliDateSt1.AnswerDeadTime1 != sCMDeliDateSt2.AnswerDeadTime1) resList.Add("AnswerDeadTime1");
            if (sCMDeliDateSt1.AnswerDeadTime2 != sCMDeliDateSt2.AnswerDeadTime2) resList.Add("AnswerDeadTime2");
            if (sCMDeliDateSt1.AnswerDeadTime3 != sCMDeliDateSt2.AnswerDeadTime3) resList.Add("AnswerDeadTime3");
            if (sCMDeliDateSt1.AnswerDeadTime4 != sCMDeliDateSt2.AnswerDeadTime4) resList.Add("AnswerDeadTime4");
            if (sCMDeliDateSt1.AnswerDeadTime5 != sCMDeliDateSt2.AnswerDeadTime5) resList.Add("AnswerDeadTime5");
            if (sCMDeliDateSt1.AnswerDeadTime6 != sCMDeliDateSt2.AnswerDeadTime6) resList.Add("AnswerDeadTime6");
            if (sCMDeliDateSt1.AnswerDelivDate1 != sCMDeliDateSt2.AnswerDelivDate1) resList.Add("AnswerDelivDate1");
            if (sCMDeliDateSt1.AnswerDelivDate2 != sCMDeliDateSt2.AnswerDelivDate2) resList.Add("AnswerDelivDate2");
            if (sCMDeliDateSt1.AnswerDelivDate3 != sCMDeliDateSt2.AnswerDelivDate3) resList.Add("AnswerDelivDate3");
            if (sCMDeliDateSt1.AnswerDelivDate4 != sCMDeliDateSt2.AnswerDelivDate4) resList.Add("AnswerDelivDate4");
            if (sCMDeliDateSt1.AnswerDelivDate5 != sCMDeliDateSt2.AnswerDelivDate5) resList.Add("AnswerDelivDate5");
            if (sCMDeliDateSt1.AnswerDelivDate6 != sCMDeliDateSt2.AnswerDelivDate6) resList.Add("AnswerDelivDate6");
            if (sCMDeliDateSt1.EnterpriseName != sCMDeliDateSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (sCMDeliDateSt1.UpdEmployeeName != sCMDeliDateSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // 2011/01/06 Add >>>
            if (sCMDeliDateSt1.AnswerDeadTime1Stc != sCMDeliDateSt2.AnswerDeadTime1Stc) resList.Add("AnswerDeadTime1Stc");
            if (sCMDeliDateSt1.AnswerDeadTime2Stc != sCMDeliDateSt2.AnswerDeadTime2Stc) resList.Add("AnswerDeadTime2Stc");
            if (sCMDeliDateSt1.AnswerDeadTime3Stc != sCMDeliDateSt2.AnswerDeadTime3Stc) resList.Add("AnswerDeadTime3Stc");
            if (sCMDeliDateSt1.AnswerDeadTime4Stc != sCMDeliDateSt2.AnswerDeadTime4Stc) resList.Add("AnswerDeadTime4Stc");
            if (sCMDeliDateSt1.AnswerDeadTime5Stc != sCMDeliDateSt2.AnswerDeadTime5Stc) resList.Add("AnswerDeadTime5Stc");
            if (sCMDeliDateSt1.AnswerDeadTime6Stc != sCMDeliDateSt2.AnswerDeadTime6Stc) resList.Add("AnswerDeadTime6Stc");
            if (sCMDeliDateSt1.AnswerDelivDate1Stc != sCMDeliDateSt2.AnswerDelivDate1Stc) resList.Add("AnswerDelivDate1Stc");
            if (sCMDeliDateSt1.AnswerDelivDate2Stc != sCMDeliDateSt2.AnswerDelivDate2Stc) resList.Add("AnswerDelivDate2Stc");
            if (sCMDeliDateSt1.AnswerDelivDate3Stc != sCMDeliDateSt2.AnswerDelivDate3Stc) resList.Add("AnswerDelivDate3Stc");
            if (sCMDeliDateSt1.AnswerDelivDate4Stc != sCMDeliDateSt2.AnswerDelivDate4Stc) resList.Add("AnswerDelivDate4Stc");
            if (sCMDeliDateSt1.AnswerDelivDate5Stc != sCMDeliDateSt2.AnswerDelivDate5Stc) resList.Add("AnswerDelivDate5Stc");
            if (sCMDeliDateSt1.AnswerDelivDate6Stc != sCMDeliDateSt2.AnswerDelivDate6Stc) resList.Add("AnswerDelivDate6Stc");
            if (sCMDeliDateSt1.EntStckAnsDeliDtDiv != sCMDeliDateSt2.EntStckAnsDeliDtDiv) resList.Add("EntStckAnsDeliDtDiv");
            if (sCMDeliDateSt1.EntStckAnsDeliDate != sCMDeliDateSt2.EntStckAnsDeliDate) resList.Add("EntStckAnsDeliDate");
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            if (sCMDeliDateSt1.PriStckAnsDeliDtDiv != sCMDeliDateSt2.PriStckAnsDeliDtDiv) resList.Add("PriStckAnsDeliDtDiv");
            if (sCMDeliDateSt1.PriStckAnsDeliDate != sCMDeliDateSt2.PriStckAnsDeliDate) resList.Add("PriStckAnsDeliDate");
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (sCMDeliDateSt1.AnsDelDatShortOfStc != sCMDeliDateSt2.AnsDelDatShortOfStc) resList.Add("AnsDelDatShortOfStc");
            if (sCMDeliDateSt1.AnsDelDatWithoutStc != sCMDeliDateSt2.AnsDelDatWithoutStc) resList.Add("AnsDelDatWithoutStc");
            if (sCMDeliDateSt1.EntStcAnsDelDatShort != sCMDeliDateSt2.EntStcAnsDelDatShort) resList.Add("EntStcAnsDelDatShort");
            if (sCMDeliDateSt1.EntStcAnsDelDatWiout != sCMDeliDateSt2.EntStcAnsDelDatWiout) resList.Add("EntStcAnsDelDatWiout");
            if (sCMDeliDateSt1.PriStcAnsDelDatShort != sCMDeliDateSt2.PriStcAnsDelDatShort) resList.Add("PriStcAnsDelDatShort");
            if (sCMDeliDateSt1.PriStcAnsDelDatWiout != sCMDeliDateSt2.PriStcAnsDelDatWiout) resList.Add("PriStcAnsDelDatWiout");
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (sCMDeliDateSt1.AnsDelDtDiv1 != sCMDeliDateSt2.AnsDelDtDiv1) resList.Add("AnsDelDtDiv1");
            if (sCMDeliDateSt1.AnsDelDtDiv2 != sCMDeliDateSt2.AnsDelDtDiv2) resList.Add("AnsDelDtDiv2");
            if (sCMDeliDateSt1.AnsDelDtDiv3 != sCMDeliDateSt2.AnsDelDtDiv3) resList.Add("AnsDelDtDiv3");
            if (sCMDeliDateSt1.AnsDelDtDiv4 != sCMDeliDateSt2.AnsDelDtDiv4) resList.Add("AnsDelDtDiv4");
            if (sCMDeliDateSt1.AnsDelDtDiv5 != sCMDeliDateSt2.AnsDelDtDiv5) resList.Add("AnsDelDtDiv5");
            if (sCMDeliDateSt1.AnsDelDtDiv6 != sCMDeliDateSt2.AnsDelDtDiv6) resList.Add("AnsDelDtDiv6");
            if (sCMDeliDateSt1.AnsDelDtDiv1Stc != sCMDeliDateSt2.AnsDelDtDiv1Stc) resList.Add("AnsDelDtDiv1Stc");
            if (sCMDeliDateSt1.AnsDelDtDiv2Stc != sCMDeliDateSt2.AnsDelDtDiv2Stc) resList.Add("AnsDelDtDiv2Stc");
            if (sCMDeliDateSt1.AnsDelDtDiv3Stc != sCMDeliDateSt2.AnsDelDtDiv3Stc) resList.Add("AnsDelDtDiv3Stc");
            if (sCMDeliDateSt1.AnsDelDtDiv4Stc != sCMDeliDateSt2.AnsDelDtDiv4Stc) resList.Add("AnsDelDtDiv4Stc");
            if (sCMDeliDateSt1.AnsDelDtDiv5Stc != sCMDeliDateSt2.AnsDelDtDiv5Stc) resList.Add("AnsDelDtDiv5Stc");
            if (sCMDeliDateSt1.AnsDelDtDiv6Stc != sCMDeliDateSt2.AnsDelDtDiv6Stc) resList.Add("AnsDelDtDiv6Stc");
            if (sCMDeliDateSt1.EntAnsDelDtStcDiv != sCMDeliDateSt2.EntAnsDelDtStcDiv) resList.Add("EntAnsDelDtStcDiv");
            if (sCMDeliDateSt1.PriAnsDelDtStcDiv != sCMDeliDateSt2.PriAnsDelDtStcDiv) resList.Add("PriAnsDelDtStcDiv");
            if (sCMDeliDateSt1.AnsDelDtShoStcDiv != sCMDeliDateSt2.AnsDelDtShoStcDiv) resList.Add("AnsDelDtShoStcDiv");
            if (sCMDeliDateSt1.AnsDelDtWioStcDiv != sCMDeliDateSt2.AnsDelDtWioStcDiv) resList.Add("AnsDelDtWioStcDiv");
            if (sCMDeliDateSt1.EntAnsDelDtShoDiv != sCMDeliDateSt2.EntAnsDelDtShoDiv) resList.Add("EntAnsDelDtShoDiv");
            if (sCMDeliDateSt1.EntAnsDelDtWioDiv != sCMDeliDateSt2.EntAnsDelDtWioDiv) resList.Add("EntAnsDelDtWioDiv");
            if (sCMDeliDateSt1.PriAnsDelDtShoDiv != sCMDeliDateSt2.PriAnsDelDtShoDiv) resList.Add("PriAnsDelDtShoDiv");
            if (sCMDeliDateSt1.PriAnsDelDtWioDiv != sCMDeliDateSt2.PriAnsDelDtWioDiv) resList.Add("PriAnsDelDtWioDiv");
            if (sCMDeliDateSt1.EnterpriseName != sCMDeliDateSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (sCMDeliDateSt1.UpdEmployeeName != sCMDeliDateSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
