using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMDeliDateStWork
    /// <summary>
    ///                      SCM納期設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM納期設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/04/28  (CSharp File Generated Date)</br>
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
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMDeliDateStWork : IFileHeader
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
        /// <remarks>0:在庫設定に従う、1:棚番、2:委託用に設定</remarks>
        private Int32 _entStckAnsDeliDtDiv;

        /// <summary>委託在庫回答納期</summary>
        /// <remarks></remarks>
        private string _entStckAnsDeliDate = "";
        // 2011/01/06 Add <<<

        // 2011/10/11 Add >>>
        /// <summary>優先在庫回答納期区分</summary>
        /// <remarks>0:在庫設定に従う、1:優先用に設定</remarks>
        private Int32 _priStckAnsDeliDtDiv;

        /// <summary>優先在庫回答納期</summary>
        /// <remarks></remarks>
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
        /// <br>note             :   委託在庫回答納期区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EntStckAnsDeliDtDiv
        {
            get { return _entStckAnsDeliDtDiv; }
            set { _entStckAnsDeliDtDiv = value; }
        }

        /// public propaty name  :  EntStckAnsDeliDate
        /// <summary>委託在庫回答納期プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託在庫回答納期プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EntStckAnsDeliDate
        {
            get { return _entStckAnsDeliDate; }
            set { _entStckAnsDeliDate = value; }
        }
        // 2011/01/06 Add <<<

        // 2011/10/11 Add >>>
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
        /// <value></value>
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
        // 2011/10/11 Add <<<

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
        /// <summary>参照在庫回答納期（在庫数無し）プロパティ</summary>
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
        /// SCM納期設定ワークコンストラクタ
        /// </summary>
        /// <returns>SCMDeliDateStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMDeliDateStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMDeliDateStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMDeliDateStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMDeliDateStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMDeliDateStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMDeliDateStWork || graph is ArrayList || graph is SCMDeliDateStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMDeliDateStWork).FullName));

            if (graph != null && graph is SCMDeliDateStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMDeliDateStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMDeliDateStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMDeliDateStWork[])graph).Length;
            }
            else if (graph is SCMDeliDateStWork)
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
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //回答締切時刻１
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime1
            //回答締切時刻２
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime2
            //回答締切時刻３
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime3
            //回答締切時刻４
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime4
            //回答締切時刻５
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime5
            //回答締切時刻６
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime6
            //回答納期１
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate1
            //回答納期２
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate2
            //回答納期３
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate3
            //回答納期４
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate4
            //回答納期５
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate5
            //回答納期６
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate6
            // 2011/01/06 Add >>>
            //回答締切時刻１（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime1Stc
            //回答締切時刻２（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime2Stc
            //回答締切時刻３（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime3Stc
            //回答締切時刻４（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime4Stc
            //回答締切時刻５（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime5Stc
            //回答締切時刻６（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDeadTime6Stc
            //回答納期１（在庫）
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate1Stc
            //回答納期２（在庫）
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate2Stc
            //回答納期３（在庫）
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate3Stc
            //回答納期４（在庫）
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate4Stc
            //回答納期５（在庫）
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate5Stc
            //回答納期６（在庫）
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDelivDate6Stc
            //委託在庫回答納期区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EntStckAnsDeliDtDiv
            //委託在庫回答納期
            serInfo.MemberInfo.Add(typeof(string)); //EntStckAnsDeliDate
            // 2011/01/06 Add <<<

            // 2011/10/11 Add >>>
            //優先在庫回答納期区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PriStckAnsDeliDtDiv
            //優先在庫回答納期
            serInfo.MemberInfo.Add(typeof(string)); //PriStckAnsDeliDate
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            serInfo.MemberInfo.Add(typeof(string)); // AnsDelDatShortOfStc
            serInfo.MemberInfo.Add(typeof(string)); // AnsDelDatWithoutStc
            serInfo.MemberInfo.Add(typeof(string)); // EntStcAnsDelDatShort
            serInfo.MemberInfo.Add(typeof(string)); // EntStcAnsDelDatWiout
            serInfo.MemberInfo.Add(typeof(string)); // PriStcAnsDelDatShort
            serInfo.MemberInfo.Add(typeof(string)); // PriStcAnsDelDatWiout
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //回答納期区分１
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv1
            //回答納期区分２
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv2
            //回答納期区分３
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv3
            //回答納期区分４
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv4
            //回答納期区分５
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv5
            //回答納期区分６
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv6
            //回答納期区分１（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv1Stc
            //回答納期区分２（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv2Stc
            //回答納期区分３（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv3Stc
            //回答納期区分４（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv4Stc
            //回答納期区分５（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv5Stc
            //回答納期区分６（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtDiv6Stc
            //委託在庫回答納期区分（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //EntAnsDelDtStcDiv
            //優先在庫回答納期区分（在庫）
            serInfo.MemberInfo.Add(typeof(Int16)); //PriAnsDelDtStcDiv
            //回答納期区分（在庫不足）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtShoStcDiv
            //回答納期区分（在庫数無し）
            serInfo.MemberInfo.Add(typeof(Int16)); //AnsDelDtWioStcDiv
            //委託在庫回答納期区分（在庫不足）
            serInfo.MemberInfo.Add(typeof(Int16)); //EntAnsDelDtShoDiv
            //委託在庫回答納期区分（在庫数無し）
            serInfo.MemberInfo.Add(typeof(Int16)); //EntAnsDelDtWioDiv
            //優先在庫回答納期区分（在庫不足）
            serInfo.MemberInfo.Add(typeof(Int16)); //PriAnsDelDtShoDiv
            //優先在庫回答納期区分（在庫数無し）
            serInfo.MemberInfo.Add(typeof(Int16)); //PriAnsDelDtWioDiv
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMDeliDateStWork)
            {
                SCMDeliDateStWork temp = (SCMDeliDateStWork)graph;

                SetSCMDeliDateStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMDeliDateStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMDeliDateStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMDeliDateStWork temp in lst)
                {
                    SetSCMDeliDateStWork(writer, temp);
                }

            }


        }

        /// <summary>
        /// SCMDeliDateStWorkメンバ数(publicプロパティ数)
        /// </summary>
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //// 2011/01/06 >>>
        ////private const int currentMemberCount = 22;
        //// 2011/10/11 >>>
        ////private const int currentMemberCount = 36;
        //// 2012/08/30 UPD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        ////private const int currentMemberCount = 38;
        //private const int currentMemberCount = 44;
        //// 2012/08/30 UPD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// 2011/10/11 <<<
        //// 2011/01/06 <<<
        #endregion
        private const int currentMemberCount = 64;
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        ///  SCMDeliDateStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMDeliDateStWork(System.IO.BinaryWriter writer, SCMDeliDateStWork temp)
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
            //得意先コード
            writer.Write(temp.CustomerCode);
            //回答締切時刻１
            writer.Write(temp.AnswerDeadTime1);
            //回答締切時刻２
            writer.Write(temp.AnswerDeadTime2);
            //回答締切時刻３
            writer.Write(temp.AnswerDeadTime3);
            //回答締切時刻４
            writer.Write(temp.AnswerDeadTime4);
            //回答締切時刻５
            writer.Write(temp.AnswerDeadTime5);
            //回答締切時刻６
            writer.Write(temp.AnswerDeadTime6);
            //回答納期１
            writer.Write(temp.AnswerDelivDate1);
            //回答納期２
            writer.Write(temp.AnswerDelivDate2);
            //回答納期３
            writer.Write(temp.AnswerDelivDate3);
            //回答納期４
            writer.Write(temp.AnswerDelivDate4);
            //回答納期５
            writer.Write(temp.AnswerDelivDate5);
            //回答納期６
            writer.Write(temp.AnswerDelivDate6);
            // 2011/01/06 Add >>>
            //回答締切時刻１（在庫）
            writer.Write(temp.AnswerDeadTime1Stc);
            //回答締切時刻２（在庫）
            writer.Write(temp.AnswerDeadTime2Stc);
            //回答締切時刻３（在庫）
            writer.Write(temp.AnswerDeadTime3Stc);
            //回答締切時刻４（在庫）
            writer.Write(temp.AnswerDeadTime4Stc);
            //回答締切時刻５（在庫）
            writer.Write(temp.AnswerDeadTime5Stc);
            //回答締切時刻６（在庫）
            writer.Write(temp.AnswerDeadTime6Stc);
            //回答納期１（在庫）
            writer.Write(temp.AnswerDelivDate1Stc);
            //回答納期２（在庫）
            writer.Write(temp.AnswerDelivDate2Stc);
            //回答納期３（在庫）
            writer.Write(temp.AnswerDelivDate3Stc);
            //回答納期４（在庫）
            writer.Write(temp.AnswerDelivDate4Stc);
            //回答納期５（在庫）
            writer.Write(temp.AnswerDelivDate5Stc);
            //回答納期６（在庫）
            writer.Write(temp.AnswerDelivDate6Stc);
            //委託在庫回答納期区分
            writer.Write(temp.EntStckAnsDeliDtDiv);
            //委託在庫回答納期
            writer.Write(temp.EntStckAnsDeliDate);
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            //優先在庫回答納期区分
            writer.Write(temp.PriStckAnsDeliDtDiv);
            //優先在庫回答納期
            writer.Write(temp.PriStckAnsDeliDate);
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            writer.Write(temp.AnsDelDatShortOfStc);
            // 回答納期（在庫数無し）
            writer.Write(temp.AnsDelDatWithoutStc);
            // 委託在庫回答納期（在庫不足）
            writer.Write(temp.EntStcAnsDelDatShort);
            // 委託在庫回答納期（在庫数無し）
            writer.Write(temp.EntStcAnsDelDatWiout);
            // 参照在庫回答納期（在庫不足）
            writer.Write(temp.PriStcAnsDelDatShort);
            // 参照在庫回答納期（在庫数無し）
            writer.Write(temp.PriStcAnsDelDatWiout);
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //回答納期区分１
            writer.Write(temp.AnsDelDtDiv1);
            //回答納期区分２
            writer.Write(temp.AnsDelDtDiv2);
            //回答納期区分３
            writer.Write(temp.AnsDelDtDiv3);
            //回答納期区分４
            writer.Write(temp.AnsDelDtDiv4);
            //回答納期区分５
            writer.Write(temp.AnsDelDtDiv5);
            //回答納期区分６
            writer.Write(temp.AnsDelDtDiv6);
            //回答納期区分１（在庫）
            writer.Write(temp.AnsDelDtDiv1Stc);
            //回答納期区分２（在庫）
            writer.Write(temp.AnsDelDtDiv2Stc);
            //回答納期区分３（在庫）
            writer.Write(temp.AnsDelDtDiv3Stc);
            //回答納期区分４（在庫）
            writer.Write(temp.AnsDelDtDiv4Stc);
            //回答納期区分５（在庫）
            writer.Write(temp.AnsDelDtDiv5Stc);
            //回答納期区分６（在庫）
            writer.Write(temp.AnsDelDtDiv6Stc);
            //委託在庫回答納期区分（在庫）
            writer.Write(temp.EntAnsDelDtStcDiv);
            //優先在庫回答納期区分（在庫）
            writer.Write(temp.PriAnsDelDtStcDiv);
            //回答納期区分（在庫不足）
            writer.Write(temp.AnsDelDtShoStcDiv);
            //回答納期区分（在庫数無し）
            writer.Write(temp.AnsDelDtWioStcDiv);
            //委託在庫回答納期区分（在庫不足）
            writer.Write(temp.EntAnsDelDtShoDiv);
            //委託在庫回答納期区分（在庫数無し）
            writer.Write(temp.EntAnsDelDtWioDiv);
            //優先在庫回答納期区分（在庫不足）
            writer.Write(temp.PriAnsDelDtShoDiv);
            //優先在庫回答納期区分（在庫数無し）
            writer.Write(temp.PriAnsDelDtWioDiv);
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        ///  SCMDeliDateStWorkインスタンス取得
        /// </summary>
        /// <returns>SCMDeliDateStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMDeliDateStWork GetSCMDeliDateStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMDeliDateStWork temp = new SCMDeliDateStWork();

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
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //回答締切時刻１
            temp.AnswerDeadTime1 = reader.ReadInt32();
            //回答締切時刻２
            temp.AnswerDeadTime2 = reader.ReadInt32();
            //回答締切時刻３
            temp.AnswerDeadTime3 = reader.ReadInt32();
            //回答締切時刻４
            temp.AnswerDeadTime4 = reader.ReadInt32();
            //回答締切時刻５
            temp.AnswerDeadTime5 = reader.ReadInt32();
            //回答締切時刻６
            temp.AnswerDeadTime6 = reader.ReadInt32();
            //回答納期１
            temp.AnswerDelivDate1 = reader.ReadString();
            //回答納期２
            temp.AnswerDelivDate2 = reader.ReadString();
            //回答納期３
            temp.AnswerDelivDate3 = reader.ReadString();
            //回答納期４
            temp.AnswerDelivDate4 = reader.ReadString();
            //回答納期５
            temp.AnswerDelivDate5 = reader.ReadString();
            //回答納期６
            temp.AnswerDelivDate6 = reader.ReadString();
            // 2011/01/06 Add >>>
            //回答締切時刻１（在庫）
            temp.AnswerDeadTime1Stc = reader.ReadInt32();
            //回答締切時刻２（在庫）
            temp.AnswerDeadTime2Stc = reader.ReadInt32();
            //回答締切時刻３（在庫）
            temp.AnswerDeadTime3Stc = reader.ReadInt32();
            //回答締切時刻４（在庫）
            temp.AnswerDeadTime4Stc = reader.ReadInt32();
            //回答締切時刻５（在庫）
            temp.AnswerDeadTime5Stc = reader.ReadInt32();
            //回答締切時刻６（在庫）
            temp.AnswerDeadTime6Stc = reader.ReadInt32();
            //回答納期１（在庫）
            temp.AnswerDelivDate1Stc = reader.ReadString();
            //回答納期２（在庫）
            temp.AnswerDelivDate2Stc = reader.ReadString();
            //回答納期３（在庫）
            temp.AnswerDelivDate3Stc = reader.ReadString();
            //回答納期４（在庫）
            temp.AnswerDelivDate4Stc = reader.ReadString();
            //回答納期５（在庫）
            temp.AnswerDelivDate5Stc = reader.ReadString();
            //回答納期６（在庫）
            temp.AnswerDelivDate6Stc = reader.ReadString();
            //委託在庫回答納期区分
            temp.EntStckAnsDeliDtDiv = reader.ReadInt32();
            //委託在庫回答納期
            temp.EntStckAnsDeliDate = reader.ReadString();
            // 2011/01/06 Add <<<
            // 2011/10/11 Add >>>
            //優先在庫回答納期区分
            temp.PriStckAnsDeliDtDiv = reader.ReadInt32();
            //優先在庫回答納期
            temp.PriStckAnsDeliDate = reader.ReadString();
            // 2011/10/11 Add <<<
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期（在庫不足）
            temp.AnsDelDatShortOfStc = reader.ReadString();
            // 回答納期（在庫数無し）
            temp.AnsDelDatWithoutStc = reader.ReadString();
            // 委託在庫回答納期（在庫不足）
            temp.EntStcAnsDelDatShort = reader.ReadString();
            // 委託在庫回答納期（在庫数無し）
            temp.EntStcAnsDelDatWiout = reader.ReadString();
            // 参照在庫回答納期（在庫不足）
            temp.PriStcAnsDelDatShort = reader.ReadString();
            // 参照在庫回答納期（在庫数無し）
            temp.PriStcAnsDelDatWiout = reader.ReadString();
            // 2012/08/30 ADD TAKAGAWA 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //回答納期区分１
            temp.AnsDelDtDiv1 = reader.ReadInt16();
            //回答納期区分２
            temp.AnsDelDtDiv2 = reader.ReadInt16();
            //回答納期区分３
            temp.AnsDelDtDiv3 = reader.ReadInt16();
            //回答納期区分４
            temp.AnsDelDtDiv4 = reader.ReadInt16();
            //回答納期区分５
            temp.AnsDelDtDiv5 = reader.ReadInt16();
            //回答納期区分６
            temp.AnsDelDtDiv6 = reader.ReadInt16();
            //回答納期区分１（在庫）
            temp.AnsDelDtDiv1Stc = reader.ReadInt16();
            //回答納期区分２（在庫）
            temp.AnsDelDtDiv2Stc = reader.ReadInt16();
            //回答納期区分３（在庫）
            temp.AnsDelDtDiv3Stc = reader.ReadInt16();
            //回答納期区分４（在庫）
            temp.AnsDelDtDiv4Stc = reader.ReadInt16();
            //回答納期区分５（在庫）
            temp.AnsDelDtDiv5Stc = reader.ReadInt16();
            //回答納期区分６（在庫）
            temp.AnsDelDtDiv6Stc = reader.ReadInt16();
            //委託在庫回答納期区分（在庫）
            temp.EntAnsDelDtStcDiv = reader.ReadInt16();
            //優先在庫回答納期区分（在庫）
            temp.PriAnsDelDtStcDiv = reader.ReadInt16();
            //回答納期区分（在庫不足）
            temp.AnsDelDtShoStcDiv = reader.ReadInt16();
            //回答納期区分（在庫数無し）
            temp.AnsDelDtWioStcDiv = reader.ReadInt16();
            //委託在庫回答納期区分（在庫不足）
            temp.EntAnsDelDtShoDiv = reader.ReadInt16();
            //委託在庫回答納期区分（在庫数無し）
            temp.EntAnsDelDtWioDiv = reader.ReadInt16();
            //優先在庫回答納期区分（在庫不足）
            temp.PriAnsDelDtShoDiv = reader.ReadInt16();
            //優先在庫回答納期区分（在庫数無し）
            temp.PriAnsDelDtWioDiv = reader.ReadInt16();
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
        /// <returns>SCMDeliDateStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMDeliDateStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMDeliDateStWork temp = GetSCMDeliDateStWork(reader, serInfo);
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
                    retValue = (SCMDeliDateStWork[])lst.ToArray(typeof(SCMDeliDateStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}