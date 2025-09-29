//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM優先設定マスタ
// プログラム概要   : SCM優先設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SCMPriorSt
    /// <summary>
    ///                      SCM優先設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM優先設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2011/08/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/08/08  杉村</br>
    /// <br>                 :   ○項目変更</br>
    /// <br>                 :   優先設定コード６～１０</br>
    /// <br>                 :   優先設定名称６～１０</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   優先価格設定コード１～５</br>
    /// <br>                 :   優先価格設定名称１～５</br>
    /// </remarks>
    public class SCMPriorSt 
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

        /// <summary>優先設定コード１</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _prioritySettingCd1;

        /// <summary>優先設定名称１</summary>
        private string _prioritySettingNm1 = "";

        /// <summary>優先設定コード２</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _prioritySettingCd2;

        /// <summary>優先設定名称２</summary>
        private string _prioritySettingNm2 = "";

        /// <summary>優先設定コード３</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _prioritySettingCd3;

        /// <summary>優先設定名称３</summary>
        private string _prioritySettingNm3 = "";

        /// <summary>優先設定コード４</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _prioritySettingCd4;

        /// <summary>優先設定名称４</summary>
        private string _prioritySettingNm4 = "";

        /// <summary>優先設定コード５</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _prioritySettingCd5;

        /// <summary>優先設定名称５</summary>
        private string _prioritySettingNm5 = "";

        /// <summary>優先価格設定コード１</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _priorPriceSetCd1;

        /// <summary>優先価格設定名称１</summary>
        private string _priorPriceSetNm1 = "";

        /// <summary>優先価格設定コード２</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _priorPriceSetCd2;

        /// <summary>優先価格設定名称２</summary>
        private string _priorPriceSetNm2 = "";

        /// <summary>優先価格設定コード３</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _priorPriceSetCd3;

        /// <summary>優先価格設定名称３</summary>
        private string _priorPriceSetNm3 = "";

        /// <summary>優先価格設定コード４</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _priorPriceSetCd4;

        /// <summary>優先価格設定名称４</summary>
        private string _priorPriceSetNm4 = "";

        /// <summary>優先価格設定コード５</summary>
        /// <remarks>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</remarks>
        private Int32 _priorPriceSetCd5;

        /// <summary>優先価格設定名称５</summary>
        private string _priorPriceSetNm5 = "";

        /// <summary>優先適用区分</summary>
        /// <remarks>0:共通, 1:PCC, 2:PCCUOE</remarks>
        private Int32 _priorAppliDiv;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>選択時対象純優区分</summary>
        /// <remarks>0:全て, 1:純正</remarks>
        private Int32 _selTgtPureDiv;

        /// <summary>選択時対象在庫区分</summary>
        /// <remarks>0:全て, 1:在庫, 2:委託・優先倉庫, 3:委託</remarks>
        private Int32 _selTgtStckDiv;

        /// <summary>選択時対象キャンペーン区分</summary>
        /// <remarks>0:全て, 1:キャンペーン</remarks>
        private Int32 _selTgtCampDiv;

        /// <summary>選択時対象価格区分１</summary>
        /// <remarks>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</remarks>
        private Int32 _selTgtPricDiv1;

        /// <summary>選択時対象価格区分２</summary>
        /// <remarks>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</remarks>
        private Int32 _selTgtPricDiv2;

        /// <summary>選択時対象価格区分３</summary>
        /// <remarks>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</remarks>
        private Int32 _selTgtPricDiv3;

        /// <summary>非選択時対象純優区分</summary>
        /// <remarks>0:全て, 1:純正</remarks>
        private Int32 _unSelTgtPureDiv;

        /// <summary>非選択時対象在庫区分</summary>
        /// <remarks>0:全て, 1:在庫, 2:委託・優先倉庫, 3:委託</remarks>
        private Int32 _unSelTgtStckDiv;

        /// <summary>非選択時対象キャンペーン区分</summary>
        /// <remarks>0:全て, 1:キャンペーン</remarks>
        private Int32 _unSelTgtCampDiv;

        /// <summary>非選択時対象価格区分１</summary>
        /// <remarks>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</remarks>
        private Int32 _unSelTgtPricDiv1;

        /// <summary>非選択時対象価格区分２</summary>
        /// <remarks>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</remarks>
        private Int32 _unSelTgtPricDiv2;

        /// <summary>非選択時対象価格区分３</summary>
        /// <remarks>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</remarks>
        private Int32 _unSelTgtPricDiv3;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  PrioritySettingCd1
        /// <summary>優先設定コード１プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd1
        {
            get { return _prioritySettingCd1; }
            set { _prioritySettingCd1 = value; }
        }

        /// public propaty name  :  PrioritySettingNm1
        /// <summary>優先設定名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrioritySettingNm1
        {
            get { return _prioritySettingNm1; }
            set { _prioritySettingNm1 = value; }
        }

        /// public propaty name  :  PrioritySettingCd2
        /// <summary>優先設定コード２プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd2
        {
            get { return _prioritySettingCd2; }
            set { _prioritySettingCd2 = value; }
        }

        /// public propaty name  :  PrioritySettingNm2
        /// <summary>優先設定名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrioritySettingNm2
        {
            get { return _prioritySettingNm2; }
            set { _prioritySettingNm2 = value; }
        }

        /// public propaty name  :  PrioritySettingCd3
        /// <summary>優先設定コード３プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd3
        {
            get { return _prioritySettingCd3; }
            set { _prioritySettingCd3 = value; }
        }

        /// public propaty name  :  PrioritySettingNm3
        /// <summary>優先設定名称３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定名称３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrioritySettingNm3
        {
            get { return _prioritySettingNm3; }
            set { _prioritySettingNm3 = value; }
        }

        /// public propaty name  :  PrioritySettingCd4
        /// <summary>優先設定コード４プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd4
        {
            get { return _prioritySettingCd4; }
            set { _prioritySettingCd4 = value; }
        }

        /// public propaty name  :  PrioritySettingNm4
        /// <summary>優先設定名称４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定名称４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrioritySettingNm4
        {
            get { return _prioritySettingNm4; }
            set { _prioritySettingNm4 = value; }
        }

        /// public propaty name  :  PrioritySettingCd5
        /// <summary>優先設定コード５プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd5
        {
            get { return _prioritySettingCd5; }
            set { _prioritySettingCd5 = value; }
        }

        /// public propaty name  :  PrioritySettingNm5
        /// <summary>優先設定名称５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定名称５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrioritySettingNm5
        {
            get { return _prioritySettingNm5; }
            set { _prioritySettingNm5 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd1
        /// <summary>優先価格設定コード１プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorPriceSetCd1
        {
            get { return _priorPriceSetCd1; }
            set { _priorPriceSetCd1 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm1
        /// <summary>優先価格設定名称１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriorPriceSetNm1
        {
            get { return _priorPriceSetNm1; }
            set { _priorPriceSetNm1 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd2
        /// <summary>優先価格設定コード２プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorPriceSetCd2
        {
            get { return _priorPriceSetCd2; }
            set { _priorPriceSetCd2 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm2
        /// <summary>優先価格設定名称２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriorPriceSetNm2
        {
            get { return _priorPriceSetNm2; }
            set { _priorPriceSetNm2 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd3
        /// <summary>優先価格設定コード３プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorPriceSetCd3
        {
            get { return _priorPriceSetCd3; }
            set { _priorPriceSetCd3 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm3
        /// <summary>優先価格設定名称３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定名称３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriorPriceSetNm3
        {
            get { return _priorPriceSetNm3; }
            set { _priorPriceSetNm3 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd4
        /// <summary>優先価格設定コード４プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorPriceSetCd4
        {
            get { return _priorPriceSetCd4; }
            set { _priorPriceSetCd4 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm4
        /// <summary>優先価格設定名称４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定名称４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriorPriceSetNm4
        {
            get { return _priorPriceSetNm4; }
            set { _priorPriceSetNm4 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd5
        /// <summary>優先価格設定コード５プロパティ</summary>
        /// <value>0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorPriceSetCd5
        {
            get { return _priorPriceSetCd5; }
            set { _priorPriceSetCd5 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm5
        /// <summary>優先価格設定名称５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先価格設定名称５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PriorPriceSetNm5
        {
            get { return _priorPriceSetNm5; }
            set { _priorPriceSetNm5 = value; }
        }

        /// public propaty name  :  PriorAppliDiv
        /// <summary>優先適用区分プロパティ</summary>
        /// <value>0:共通, 1:PCC, 2:PCCUOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriorAppliDiv
        {
            get { return _priorAppliDiv; }
            set { _priorAppliDiv = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
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

        /// public propaty name  :  SelTgtPureDiv
        /// <summary>選択時対象純優区分プロパティ</summary>
        /// <value>0:全て, 1:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択時対象純優区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelTgtPureDiv
        {
            get { return _selTgtPureDiv; }
            set { _selTgtPureDiv = value; }
        }

        /// public propaty name  :  SelTgtStckDiv
        /// <summary>選択時対象在庫区分プロパティ</summary>
        /// <value>0:全て, 1:在庫, 2:委託・優先倉庫, 3:委託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択時対象在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelTgtStckDiv
        {
            get { return _selTgtStckDiv; }
            set { _selTgtStckDiv = value; }
        }

        /// public propaty name  :  SelTgtCampDiv
        /// <summary>選択時対象キャンペーン区分プロパティ</summary>
        /// <value>0:全て, 1:キャンペーン</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択時対象キャンペーン区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelTgtCampDiv
        {
            get { return _selTgtCampDiv; }
            set { _selTgtCampDiv = value; }
        }

        /// public propaty name  :  SelTgtPricDiv1
        /// <summary>選択時対象価格区分１プロパティ</summary>
        /// <value>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択時対象価格区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelTgtPricDiv1
        {
            get { return _selTgtPricDiv1; }
            set { _selTgtPricDiv1 = value; }
        }

        /// public propaty name  :  SelTgtPricDiv2
        /// <summary>選択時対象価格区分２プロパティ</summary>
        /// <value>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択時対象価格区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelTgtPricDiv2
        {
            get { return _selTgtPricDiv2; }
            set { _selTgtPricDiv2 = value; }
        }

        /// public propaty name  :  SelTgtPricDiv3
        /// <summary>選択時対象価格区分３プロパティ</summary>
        /// <value>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択時対象価格区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelTgtPricDiv3
        {
            get { return _selTgtPricDiv3; }
            set { _selTgtPricDiv3 = value; }
        }

        /// public propaty name  :  UnSelTgtPureDiv
        /// <summary>非選択時対象純優区分プロパティ</summary>
        /// <value>0:全て, 1:純正</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   非選択時対象純優区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnSelTgtPureDiv
        {
            get { return _unSelTgtPureDiv; }
            set { _unSelTgtPureDiv = value; }
        }

        /// public propaty name  :  UnSelTgtStckDiv
        /// <summary>非選択時対象在庫区分プロパティ</summary>
        /// <value>0:全て, 1:在庫, 2:委託・優先倉庫, 3:委託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   非選択時対象在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnSelTgtStckDiv
        {
            get { return _unSelTgtStckDiv; }
            set { _unSelTgtStckDiv = value; }
        }

        /// public propaty name  :  UnSelTgtCampDiv
        /// <summary>非選択時対象キャンペーン区分プロパティ</summary>
        /// <value>0:全て, 1:キャンペーン</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   非選択時対象キャンペーン区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnSelTgtCampDiv
        {
            get { return _unSelTgtCampDiv; }
            set { _unSelTgtCampDiv = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv1
        /// <summary>非選択時対象価格区分１プロパティ</summary>
        /// <value>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   非選択時対象価格区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv1
        {
            get { return _unSelTgtPricDiv1; }
            set { _unSelTgtPricDiv1 = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv2
        /// <summary>非選択時対象価格区分２プロパティ</summary>
        /// <value>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   非選択時対象価格区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv2
        {
            get { return _unSelTgtPricDiv2; }
            set { _unSelTgtPricDiv2 = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv3
        /// <summary>非選択時対象価格区分３プロパティ</summary>
        /// <value>0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   非選択時対象価格区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv3
        {
            get { return _unSelTgtPricDiv3; }
            set { _unSelTgtPricDiv3 = value; }
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


        /// <summary>
        /// SCM優先設定マスタコンストラクタ
        /// </summary>
        /// <returns>SCMPriorStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMPriorStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMPriorSt()
        {
        }

        /// <summary>
        /// SCM優先設定マスタコンストラクタ
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
        /// <param name="prioritySettingCd1">優先設定コード１(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="prioritySettingNm1">優先設定名称１</param>
        /// <param name="prioritySettingCd2">優先設定コード２(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="prioritySettingNm2">優先設定名称２</param>
        /// <param name="prioritySettingCd3">優先設定コード３(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="prioritySettingNm3">優先設定名称３</param>
        /// <param name="prioritySettingCd4">優先設定コード４(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="prioritySettingNm4">優先設定名称４</param>
        /// <param name="prioritySettingCd5">優先設定コード５(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="prioritySettingNm5">優先設定名称５</param>
        /// <param name="priorPriceSetCd1">優先価格設定コード１(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="priorPriceSetNm1">優先価格設定名称１</param>
        /// <param name="priorPriceSetCd2">優先価格設定コード２(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="priorPriceSetNm2">優先価格設定名称２</param>
        /// <param name="priorPriceSetCd3">優先価格設定コード３(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="priorPriceSetNm3">優先価格設定名称３</param>
        /// <param name="priorPriceSetCd4">優先価格設定コード４(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="priorPriceSetNm4">優先価格設定名称４</param>
        /// <param name="priorPriceSetCd5">優先価格設定コード５(0:なし1:粗利率,2:単価,3:定価(高),4:定価(低),5:キャンペーン,6:在庫,7:委託,8:優先倉庫,9:純正)</param>
        /// <param name="priorPriceSetNm5">優先価格設定名称５</param>
        /// <param name="priorAppliDiv">優先適用区分(0:共通, 1:PCC, 2:PCCUOE)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="selTgtPureDiv">選択時対象純優区分(0:全て, 1:純正)</param>
        /// <param name="selTgtStckDiv">選択時対象在庫区分(0:全て, 1:在庫, 2:委託・優先倉庫, 3:委託)</param>
        /// <param name="selTgtCampDiv">選択時対象キャンペーン区分(0:全て, 1:キャンペーン)</param>
        /// <param name="selTgtPricDiv1">選択時対象価格区分１(0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低))</param>
        /// <param name="selTgtPricDiv2">選択時対象価格区分２(0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低))</param>
        /// <param name="selTgtPricDiv3">選択時対象価格区分３(0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低))</param>
        /// <param name="unSelTgtPureDiv">非選択時対象純優区分(0:全て, 1:純正)</param>
        /// <param name="unSelTgtStckDiv">非選択時対象在庫区分(0:全て, 1:在庫, 2:委託・優先倉庫, 3:委託)</param>
        /// <param name="unSelTgtCampDiv">非選択時対象キャンペーン区分(0:全て, 1:キャンペーン)</param>
        /// <param name="unSelTgtPricDiv1">非選択時対象価格区分１(0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低))</param>
        /// <param name="unSelTgtPricDiv2">非選択時対象価格区分２(0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低))</param>
        /// <param name="unSelTgtPricDiv3">非選択時対象価格区分３(0:なし, 1:粗利率(高), 2:単価(高), 3:定価(高), 4:定価(低))</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>SCMPriorStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMPriorStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMPriorSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 prioritySettingCd1, string prioritySettingNm1, Int32 prioritySettingCd2, string prioritySettingNm2, Int32 prioritySettingCd3, string prioritySettingNm3, Int32 prioritySettingCd4, string prioritySettingNm4, Int32 prioritySettingCd5, string prioritySettingNm5, Int32 priorPriceSetCd1, string priorPriceSetNm1, Int32 priorPriceSetCd2, string priorPriceSetNm2, Int32 priorPriceSetCd3, string priorPriceSetNm3, Int32 priorPriceSetCd4, string priorPriceSetNm4, Int32 priorPriceSetCd5, string priorPriceSetNm5, Int32 priorAppliDiv, Int32 customerCode, Int32 selTgtPureDiv, Int32 selTgtStckDiv, Int32 selTgtCampDiv, Int32 selTgtPricDiv1, Int32 selTgtPricDiv2, Int32 selTgtPricDiv3, Int32 unSelTgtPureDiv, Int32 unSelTgtStckDiv, Int32 unSelTgtCampDiv, Int32 unSelTgtPricDiv1, Int32 unSelTgtPricDiv2, Int32 unSelTgtPricDiv3, string enterpriseName, string updEmployeeName)
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
            this._prioritySettingCd1 = prioritySettingCd1;
            this._prioritySettingNm1 = prioritySettingNm1;
            this._prioritySettingCd2 = prioritySettingCd2;
            this._prioritySettingNm2 = prioritySettingNm2;
            this._prioritySettingCd3 = prioritySettingCd3;
            this._prioritySettingNm3 = prioritySettingNm3;
            this._prioritySettingCd4 = prioritySettingCd4;
            this._prioritySettingNm4 = prioritySettingNm4;
            this._prioritySettingCd5 = prioritySettingCd5;
            this._prioritySettingNm5 = prioritySettingNm5;
            this._priorPriceSetCd1 = priorPriceSetCd1;
            this._priorPriceSetNm1 = priorPriceSetNm1;
            this._priorPriceSetCd2 = priorPriceSetCd2;
            this._priorPriceSetNm2 = priorPriceSetNm2;
            this._priorPriceSetCd3 = priorPriceSetCd3;
            this._priorPriceSetNm3 = priorPriceSetNm3;
            this._priorPriceSetCd4 = priorPriceSetCd4;
            this._priorPriceSetNm4 = priorPriceSetNm4;
            this._priorPriceSetCd5 = priorPriceSetCd5;
            this._priorPriceSetNm5 = priorPriceSetNm5;
            this._priorAppliDiv = priorAppliDiv;
            this._customerCode = customerCode;
            this._selTgtPureDiv = selTgtPureDiv;
            this._selTgtStckDiv = selTgtStckDiv;
            this._selTgtCampDiv = selTgtCampDiv;
            this._selTgtPricDiv1 = selTgtPricDiv1;
            this._selTgtPricDiv2 = selTgtPricDiv2;
            this._selTgtPricDiv3 = selTgtPricDiv3;
            this._unSelTgtPureDiv = unSelTgtPureDiv;
            this._unSelTgtStckDiv = unSelTgtStckDiv;
            this._unSelTgtCampDiv = unSelTgtCampDiv;
            this._unSelTgtPricDiv1 = unSelTgtPricDiv1;
            this._unSelTgtPricDiv2 = unSelTgtPricDiv2;
            this._unSelTgtPricDiv3 = unSelTgtPricDiv3;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// SCM優先設定マスタ複製処理
        /// </summary>
        /// <returns>SCMPriorStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSCMPriorStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SCMPriorSt Clone()
        {
            return new SCMPriorSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._prioritySettingCd1, this._prioritySettingNm1, this._prioritySettingCd2, this._prioritySettingNm2, this._prioritySettingCd3, this._prioritySettingNm3, this._prioritySettingCd4, this._prioritySettingNm4, this._prioritySettingCd5, this._prioritySettingNm5, this._priorPriceSetCd1, this._priorPriceSetNm1, this._priorPriceSetCd2, this._priorPriceSetNm2, this._priorPriceSetCd3, this._priorPriceSetNm3, this._priorPriceSetCd4, this._priorPriceSetNm4, this._priorPriceSetCd5, this._priorPriceSetNm5, this._priorAppliDiv, this._customerCode, this._selTgtPureDiv, this._selTgtStckDiv, this._selTgtCampDiv, this._selTgtPricDiv1, this._selTgtPricDiv2, this._selTgtPricDiv3, this._unSelTgtPureDiv, this._unSelTgtStckDiv, this._unSelTgtCampDiv, this._unSelTgtPricDiv1, this._unSelTgtPricDiv2, this._unSelTgtPricDiv3, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// SCM優先設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMPriorStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMPriorStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SCMPriorSt target)
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
                 && (this.PrioritySettingCd1 == target.PrioritySettingCd1)
                 && (this.PrioritySettingNm1 == target.PrioritySettingNm1)
                 && (this.PrioritySettingCd2 == target.PrioritySettingCd2)
                 && (this.PrioritySettingNm2 == target.PrioritySettingNm2)
                 && (this.PrioritySettingCd3 == target.PrioritySettingCd3)
                 && (this.PrioritySettingNm3 == target.PrioritySettingNm3)
                 && (this.PrioritySettingCd4 == target.PrioritySettingCd4)
                 && (this.PrioritySettingNm4 == target.PrioritySettingNm4)
                 && (this.PrioritySettingCd5 == target.PrioritySettingCd5)
                 && (this.PrioritySettingNm5 == target.PrioritySettingNm5)
                 && (this.PriorPriceSetCd1 == target.PriorPriceSetCd1)
                 && (this.PriorPriceSetNm1 == target.PriorPriceSetNm1)
                 && (this.PriorPriceSetCd2 == target.PriorPriceSetCd2)
                 && (this.PriorPriceSetNm2 == target.PriorPriceSetNm2)
                 && (this.PriorPriceSetCd3 == target.PriorPriceSetCd3)
                 && (this.PriorPriceSetNm3 == target.PriorPriceSetNm3)
                 && (this.PriorPriceSetCd4 == target.PriorPriceSetCd4)
                 && (this.PriorPriceSetNm4 == target.PriorPriceSetNm4)
                 && (this.PriorPriceSetCd5 == target.PriorPriceSetCd5)
                 && (this.PriorPriceSetNm5 == target.PriorPriceSetNm5)
                 && (this.PriorAppliDiv == target.PriorAppliDiv)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SelTgtPureDiv == target.SelTgtPureDiv)
                 && (this.SelTgtStckDiv == target.SelTgtStckDiv)
                 && (this.SelTgtCampDiv == target.SelTgtCampDiv)
                 && (this.SelTgtPricDiv1 == target.SelTgtPricDiv1)
                 && (this.SelTgtPricDiv2 == target.SelTgtPricDiv2)
                 && (this.SelTgtPricDiv3 == target.SelTgtPricDiv3)
                 && (this.UnSelTgtPureDiv == target.UnSelTgtPureDiv)
                 && (this.UnSelTgtStckDiv == target.UnSelTgtStckDiv)
                 && (this.UnSelTgtCampDiv == target.UnSelTgtCampDiv)
                 && (this.UnSelTgtPricDiv1 == target.UnSelTgtPricDiv1)
                 && (this.UnSelTgtPricDiv2 == target.UnSelTgtPricDiv2)
                 && (this.UnSelTgtPricDiv3 == target.UnSelTgtPricDiv3)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// SCM優先設定マスタ比較処理
        /// </summary>
        /// <param name="sCMPriorSt1">
        ///                    比較するSCMPriorStクラスのインスタンス
        /// </param>
        /// <param name="sCMPriorSt2">比較するSCMPriorStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMPriorStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SCMPriorSt sCMPriorSt1, SCMPriorSt sCMPriorSt2)
        {
            return ((sCMPriorSt1.CreateDateTime == sCMPriorSt2.CreateDateTime)
                 && (sCMPriorSt1.UpdateDateTime == sCMPriorSt2.UpdateDateTime)
                 && (sCMPriorSt1.EnterpriseCode == sCMPriorSt2.EnterpriseCode)
                 && (sCMPriorSt1.FileHeaderGuid == sCMPriorSt2.FileHeaderGuid)
                 && (sCMPriorSt1.UpdEmployeeCode == sCMPriorSt2.UpdEmployeeCode)
                 && (sCMPriorSt1.UpdAssemblyId1 == sCMPriorSt2.UpdAssemblyId1)
                 && (sCMPriorSt1.UpdAssemblyId2 == sCMPriorSt2.UpdAssemblyId2)
                 && (sCMPriorSt1.LogicalDeleteCode == sCMPriorSt2.LogicalDeleteCode)
                 && (sCMPriorSt1.SectionCode == sCMPriorSt2.SectionCode)
                 && (sCMPriorSt1.PrioritySettingCd1 == sCMPriorSt2.PrioritySettingCd1)
                 && (sCMPriorSt1.PrioritySettingNm1 == sCMPriorSt2.PrioritySettingNm1)
                 && (sCMPriorSt1.PrioritySettingCd2 == sCMPriorSt2.PrioritySettingCd2)
                 && (sCMPriorSt1.PrioritySettingNm2 == sCMPriorSt2.PrioritySettingNm2)
                 && (sCMPriorSt1.PrioritySettingCd3 == sCMPriorSt2.PrioritySettingCd3)
                 && (sCMPriorSt1.PrioritySettingNm3 == sCMPriorSt2.PrioritySettingNm3)
                 && (sCMPriorSt1.PrioritySettingCd4 == sCMPriorSt2.PrioritySettingCd4)
                 && (sCMPriorSt1.PrioritySettingNm4 == sCMPriorSt2.PrioritySettingNm4)
                 && (sCMPriorSt1.PrioritySettingCd5 == sCMPriorSt2.PrioritySettingCd5)
                 && (sCMPriorSt1.PrioritySettingNm5 == sCMPriorSt2.PrioritySettingNm5)
                 && (sCMPriorSt1.PriorPriceSetCd1 == sCMPriorSt2.PriorPriceSetCd1)
                 && (sCMPriorSt1.PriorPriceSetNm1 == sCMPriorSt2.PriorPriceSetNm1)
                 && (sCMPriorSt1.PriorPriceSetCd2 == sCMPriorSt2.PriorPriceSetCd2)
                 && (sCMPriorSt1.PriorPriceSetNm2 == sCMPriorSt2.PriorPriceSetNm2)
                 && (sCMPriorSt1.PriorPriceSetCd3 == sCMPriorSt2.PriorPriceSetCd3)
                 && (sCMPriorSt1.PriorPriceSetNm3 == sCMPriorSt2.PriorPriceSetNm3)
                 && (sCMPriorSt1.PriorPriceSetCd4 == sCMPriorSt2.PriorPriceSetCd4)
                 && (sCMPriorSt1.PriorPriceSetNm4 == sCMPriorSt2.PriorPriceSetNm4)
                 && (sCMPriorSt1.PriorPriceSetCd5 == sCMPriorSt2.PriorPriceSetCd5)
                 && (sCMPriorSt1.PriorPriceSetNm5 == sCMPriorSt2.PriorPriceSetNm5)
                 && (sCMPriorSt1.PriorAppliDiv == sCMPriorSt2.PriorAppliDiv)
                 && (sCMPriorSt1.CustomerCode == sCMPriorSt2.CustomerCode)
                 && (sCMPriorSt1.SelTgtPureDiv == sCMPriorSt2.SelTgtPureDiv)
                 && (sCMPriorSt1.SelTgtStckDiv == sCMPriorSt2.SelTgtStckDiv)
                 && (sCMPriorSt1.SelTgtCampDiv == sCMPriorSt2.SelTgtCampDiv)
                 && (sCMPriorSt1.SelTgtPricDiv1 == sCMPriorSt2.SelTgtPricDiv1)
                 && (sCMPriorSt1.SelTgtPricDiv2 == sCMPriorSt2.SelTgtPricDiv2)
                 && (sCMPriorSt1.SelTgtPricDiv3 == sCMPriorSt2.SelTgtPricDiv3)
                 && (sCMPriorSt1.UnSelTgtPureDiv == sCMPriorSt2.UnSelTgtPureDiv)
                 && (sCMPriorSt1.UnSelTgtStckDiv == sCMPriorSt2.UnSelTgtStckDiv)
                 && (sCMPriorSt1.UnSelTgtCampDiv == sCMPriorSt2.UnSelTgtCampDiv)
                 && (sCMPriorSt1.UnSelTgtPricDiv1 == sCMPriorSt2.UnSelTgtPricDiv1)
                 && (sCMPriorSt1.UnSelTgtPricDiv2 == sCMPriorSt2.UnSelTgtPricDiv2)
                 && (sCMPriorSt1.UnSelTgtPricDiv3 == sCMPriorSt2.UnSelTgtPricDiv3)
                 && (sCMPriorSt1.EnterpriseName == sCMPriorSt2.EnterpriseName)
                 && (sCMPriorSt1.UpdEmployeeName == sCMPriorSt2.UpdEmployeeName));
        }
        /// <summary>
        /// SCM優先設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMPriorStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMPriorStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SCMPriorSt target)
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
            if (this.PrioritySettingCd1 != target.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (this.PrioritySettingNm1 != target.PrioritySettingNm1) resList.Add("PrioritySettingNm1");
            if (this.PrioritySettingCd2 != target.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (this.PrioritySettingNm2 != target.PrioritySettingNm2) resList.Add("PrioritySettingNm2");
            if (this.PrioritySettingCd3 != target.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (this.PrioritySettingNm3 != target.PrioritySettingNm3) resList.Add("PrioritySettingNm3");
            if (this.PrioritySettingCd4 != target.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (this.PrioritySettingNm4 != target.PrioritySettingNm4) resList.Add("PrioritySettingNm4");
            if (this.PrioritySettingCd5 != target.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (this.PrioritySettingNm5 != target.PrioritySettingNm5) resList.Add("PrioritySettingNm5");
            if (this.PriorPriceSetCd1 != target.PriorPriceSetCd1) resList.Add("PriorPriceSetCd1");
            if (this.PriorPriceSetNm1 != target.PriorPriceSetNm1) resList.Add("PriorPriceSetNm1");
            if (this.PriorPriceSetCd2 != target.PriorPriceSetCd2) resList.Add("PriorPriceSetCd2");
            if (this.PriorPriceSetNm2 != target.PriorPriceSetNm2) resList.Add("PriorPriceSetNm2");
            if (this.PriorPriceSetCd3 != target.PriorPriceSetCd3) resList.Add("PriorPriceSetCd3");
            if (this.PriorPriceSetNm3 != target.PriorPriceSetNm3) resList.Add("PriorPriceSetNm3");
            if (this.PriorPriceSetCd4 != target.PriorPriceSetCd4) resList.Add("PriorPriceSetCd4");
            if (this.PriorPriceSetNm4 != target.PriorPriceSetNm4) resList.Add("PriorPriceSetNm4");
            if (this.PriorPriceSetCd5 != target.PriorPriceSetCd5) resList.Add("PriorPriceSetCd5");
            if (this.PriorPriceSetNm5 != target.PriorPriceSetNm5) resList.Add("PriorPriceSetNm5");
            if (this.PriorAppliDiv != target.PriorAppliDiv) resList.Add("PriorAppliDiv");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SelTgtPureDiv != target.SelTgtPureDiv) resList.Add("SelTgtPureDiv");
            if (this.SelTgtStckDiv != target.SelTgtStckDiv) resList.Add("SelTgtStckDiv");
            if (this.SelTgtCampDiv != target.SelTgtCampDiv) resList.Add("SelTgtCampDiv");
            if (this.SelTgtPricDiv1 != target.SelTgtPricDiv1) resList.Add("SelTgtPricDiv1");
            if (this.SelTgtPricDiv2 != target.SelTgtPricDiv2) resList.Add("SelTgtPricDiv2");
            if (this.SelTgtPricDiv3 != target.SelTgtPricDiv3) resList.Add("SelTgtPricDiv3");
            if (this.UnSelTgtPureDiv != target.UnSelTgtPureDiv) resList.Add("UnSelTgtPureDiv");
            if (this.UnSelTgtStckDiv != target.UnSelTgtStckDiv) resList.Add("UnSelTgtStckDiv");
            if (this.UnSelTgtCampDiv != target.UnSelTgtCampDiv) resList.Add("UnSelTgtCampDiv");
            if (this.UnSelTgtPricDiv1 != target.UnSelTgtPricDiv1) resList.Add("UnSelTgtPricDiv1");
            if (this.UnSelTgtPricDiv2 != target.UnSelTgtPricDiv2) resList.Add("UnSelTgtPricDiv2");
            if (this.UnSelTgtPricDiv3 != target.UnSelTgtPricDiv3) resList.Add("UnSelTgtPricDiv3");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// SCM優先設定マスタ比較処理
        /// </summary>
        /// <param name="sCMPriorSt1">比較するSCMPriorStクラスのインスタンス</param>
        /// <param name="sCMPriorSt2">比較するSCMPriorStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMPriorStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SCMPriorSt sCMPriorSt1, SCMPriorSt sCMPriorSt2)
        {
            ArrayList resList = new ArrayList();
            if (sCMPriorSt1.CreateDateTime != sCMPriorSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (sCMPriorSt1.UpdateDateTime != sCMPriorSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sCMPriorSt1.EnterpriseCode != sCMPriorSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sCMPriorSt1.FileHeaderGuid != sCMPriorSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sCMPriorSt1.UpdEmployeeCode != sCMPriorSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sCMPriorSt1.UpdAssemblyId1 != sCMPriorSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sCMPriorSt1.UpdAssemblyId2 != sCMPriorSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sCMPriorSt1.LogicalDeleteCode != sCMPriorSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sCMPriorSt1.SectionCode != sCMPriorSt2.SectionCode) resList.Add("SectionCode");
            if (sCMPriorSt1.PrioritySettingCd1 != sCMPriorSt2.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (sCMPriorSt1.PrioritySettingNm1 != sCMPriorSt2.PrioritySettingNm1) resList.Add("PrioritySettingNm1");
            if (sCMPriorSt1.PrioritySettingCd2 != sCMPriorSt2.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (sCMPriorSt1.PrioritySettingNm2 != sCMPriorSt2.PrioritySettingNm2) resList.Add("PrioritySettingNm2");
            if (sCMPriorSt1.PrioritySettingCd3 != sCMPriorSt2.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (sCMPriorSt1.PrioritySettingNm3 != sCMPriorSt2.PrioritySettingNm3) resList.Add("PrioritySettingNm3");
            if (sCMPriorSt1.PrioritySettingCd4 != sCMPriorSt2.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (sCMPriorSt1.PrioritySettingNm4 != sCMPriorSt2.PrioritySettingNm4) resList.Add("PrioritySettingNm4");
            if (sCMPriorSt1.PrioritySettingCd5 != sCMPriorSt2.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (sCMPriorSt1.PrioritySettingNm5 != sCMPriorSt2.PrioritySettingNm5) resList.Add("PrioritySettingNm5");
            if (sCMPriorSt1.PriorPriceSetCd1 != sCMPriorSt2.PriorPriceSetCd1) resList.Add("PriorPriceSetCd1");
            if (sCMPriorSt1.PriorPriceSetNm1 != sCMPriorSt2.PriorPriceSetNm1) resList.Add("PriorPriceSetNm1");
            if (sCMPriorSt1.PriorPriceSetCd2 != sCMPriorSt2.PriorPriceSetCd2) resList.Add("PriorPriceSetCd2");
            if (sCMPriorSt1.PriorPriceSetNm2 != sCMPriorSt2.PriorPriceSetNm2) resList.Add("PriorPriceSetNm2");
            if (sCMPriorSt1.PriorPriceSetCd3 != sCMPriorSt2.PriorPriceSetCd3) resList.Add("PriorPriceSetCd3");
            if (sCMPriorSt1.PriorPriceSetNm3 != sCMPriorSt2.PriorPriceSetNm3) resList.Add("PriorPriceSetNm3");
            if (sCMPriorSt1.PriorPriceSetCd4 != sCMPriorSt2.PriorPriceSetCd4) resList.Add("PriorPriceSetCd4");
            if (sCMPriorSt1.PriorPriceSetNm4 != sCMPriorSt2.PriorPriceSetNm4) resList.Add("PriorPriceSetNm4");
            if (sCMPriorSt1.PriorPriceSetCd5 != sCMPriorSt2.PriorPriceSetCd5) resList.Add("PriorPriceSetCd5");
            if (sCMPriorSt1.PriorPriceSetNm5 != sCMPriorSt2.PriorPriceSetNm5) resList.Add("PriorPriceSetNm5");
            if (sCMPriorSt1.PriorAppliDiv != sCMPriorSt2.PriorAppliDiv) resList.Add("PriorAppliDiv");
            if (sCMPriorSt1.CustomerCode != sCMPriorSt2.CustomerCode) resList.Add("CustomerCode");
            if (sCMPriorSt1.SelTgtPureDiv != sCMPriorSt2.SelTgtPureDiv) resList.Add("SelTgtPureDiv");
            if (sCMPriorSt1.SelTgtStckDiv != sCMPriorSt2.SelTgtStckDiv) resList.Add("SelTgtStckDiv");
            if (sCMPriorSt1.SelTgtCampDiv != sCMPriorSt2.SelTgtCampDiv) resList.Add("SelTgtCampDiv");
            if (sCMPriorSt1.SelTgtPricDiv1 != sCMPriorSt2.SelTgtPricDiv1) resList.Add("SelTgtPricDiv1");
            if (sCMPriorSt1.SelTgtPricDiv2 != sCMPriorSt2.SelTgtPricDiv2) resList.Add("SelTgtPricDiv2");
            if (sCMPriorSt1.SelTgtPricDiv3 != sCMPriorSt2.SelTgtPricDiv3) resList.Add("SelTgtPricDiv3");
            if (sCMPriorSt1.UnSelTgtPureDiv != sCMPriorSt2.UnSelTgtPureDiv) resList.Add("UnSelTgtPureDiv");
            if (sCMPriorSt1.UnSelTgtStckDiv != sCMPriorSt2.UnSelTgtStckDiv) resList.Add("UnSelTgtStckDiv");
            if (sCMPriorSt1.UnSelTgtCampDiv != sCMPriorSt2.UnSelTgtCampDiv) resList.Add("UnSelTgtCampDiv");
            if (sCMPriorSt1.UnSelTgtPricDiv1 != sCMPriorSt2.UnSelTgtPricDiv1) resList.Add("UnSelTgtPricDiv1");
            if (sCMPriorSt1.UnSelTgtPricDiv2 != sCMPriorSt2.UnSelTgtPricDiv2) resList.Add("UnSelTgtPricDiv2");
            if (sCMPriorSt1.UnSelTgtPricDiv3 != sCMPriorSt2.UnSelTgtPricDiv3) resList.Add("UnSelTgtPricDiv3");
            if (sCMPriorSt1.EnterpriseName != sCMPriorSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (sCMPriorSt1.UpdEmployeeName != sCMPriorSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}