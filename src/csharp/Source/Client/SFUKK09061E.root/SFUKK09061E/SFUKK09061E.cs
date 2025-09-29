//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 入金設定
// プログラム概要   : 入金設定マスタヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2006/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/22  修正内容 : 不具合対応[13580]
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   DepositSt
    /// <summary>
    ///                      入金設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/07/13</br>
    /// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2009/06/22  照田 貴志　不具合対応[13580]</br>
    /// </remarks>
    public class DepositSt
    {
        /*----------------------------------------------------------------------------------*/
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

        /// <summary>入金設定管理コード</summary>
        /// <remarks>常に０固定</remarks>
        private Int32 _depositStMngCd;

        /// <summary>入金初期表示画面番号</summary>
        /// <remarks>1:入金型,2:受注指定型</remarks>
        private Int32 _depositInitDspNo;

        ///// <summary>初期選択金種コード</summary>
        ///// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        //private Int32 _initSelMoneyKindCd;

        ///// <summary>初期選択金種コード</summary>
        //private string _initSelMoneyKindCdNm = "";

        /// <summary>入金設定金種コード1</summary>
        private Int32 _depositStKindCd1;

        /// <summary>入金設定金種コード2</summary>
        private Int32 _depositStKindCd2;

        /// <summary>入金設定金種コード3</summary>
        private Int32 _depositStKindCd3;

        /// <summary>入金設定金種コード4</summary>
        private Int32 _depositStKindCd4;

        /// <summary>入金設定金種コード5</summary>
        private Int32 _depositStKindCd5;

        /// <summary>入金設定金種コード6</summary>
        private Int32 _depositStKindCd6;

        /// <summary>入金設定金種コード7</summary>
        private Int32 _depositStKindCd7;

        /// <summary>入金設定金種コード8</summary>
        private Int32 _depositStKindCd8;

        /// <summary>入金設定金種コード9</summary>
        private Int32 _depositStKindCd9;

        /// <summary>入金設定金種コード10</summary>
        private Int32 _depositStKindCd10;

        /// <summary>入金設定金種コード1</summary>
        private string _depositStKindCdNm1 = "";

        /// <summary>入金設定金種コード2</summary>
        private string _depositStKindCdNm2 = "";

        /// <summary>入金設定金種コード3</summary>
        private string _depositStKindCdNm3 = "";

        /// <summary>入金設定金種コード4</summary>
        private string _depositStKindCdNm4 = "";

        /// <summary>入金設定金種コード5</summary>
        private string _depositStKindCdNm5 = "";

        /// <summary>入金設定金種コード6</summary>
        private string _depositStKindCdNm6 = "";

        /// <summary>入金設定金種コード7</summary>
        private string _depositStKindCdNm7 = "";

        /// <summary>入金設定金種コード8</summary>
        private string _depositStKindCdNm8 = "";

        /// <summary>入金設定金種コード9</summary>
        private string _depositStKindCdNm9 = "";

        /// <summary>入金設定金種コード10</summary>
        private string _depositStKindCdNm10 = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <summary>入金伝票呼出月数</summary>
        //private Int32 _depositCallMonths;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

        /// <summary>引当済入金伝票呼出区分</summary>
        /// <remarks>0:引当済みでも呼び出す、1:金額引当済みは呼び出さない</remarks>
        private Int32 _alwcDepoCallMonthsCd;

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /*----------------------------------------------------------------------------------*/
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

        /// public propaty name  :  DepositStMngCd
        /// <summary>入金設定管理コードプロパティ</summary>
        /// <value>常に０固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStMngCd
        {
            get { return _depositStMngCd; }
            set { _depositStMngCd = value; }
        }

        /// public propaty name  :  DepositInitDspNo
        /// <summary>入金初期表示画面番号プロパティ</summary>
        /// <value>1:入金型,2:受注指定型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金初期表示画面番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositInitDspNo
        {
            get { return _depositInitDspNo; }
            set { _depositInitDspNo = value; }
        }

        /// public propaty name  :  DepositInitDspNoName1
        /// <summary>入金初期表示画面番号名称プロパティ</summary>
        /// <value>1:入金型,2:受注指定型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金初期表示画面番号名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String DepositInitDspNoName
        {
            get { return GetDepositInitDspNoName(_depositInitDspNo); }
        }
        /// <summary>入金初期表示画面区分 1:入金型</summary>
        public const int LUMP = 1;
        /// <summary>入金初期表示画面区分 2:受注指定型</summary>
        public const int SLIP = 2;

        /// <summary>
        /// 入金初期表示画面番号名称取得
        /// </summary>
        /// <param name="depositInitDspNo">入金初期表示画面区分</param>
        /// <returns>入金初期表示画面区分名称</returns>
        /// <remarks>
        /// <br>Note       : 入金初期表示画面区分から入金初期表示画面区分名称を取得します</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        public string GetDepositInitDspNoName(int depositInitDspNo)
        {
            switch (depositInitDspNo)
            {
                case LUMP:
                    return "入金型";
                case SLIP:
                    //return "受注指定型";          //DEL 2009/06/22 不具合対応[13580]
                    return "売上指定型";            //ADD 2009/06/22 不具合対応[13580]
                default:
                    return "未設定";
            }
        }

        /// <summary>入金初期表示画面区分の種類</summary>
        static private int[] _depositInitDspNos = { LUMP, SLIP };
        /// <summary>入金初期表示画面区分の種類プロパティ</summary>
        /// <remarks>
        /// <br>Note       : 入金初期表示画面区分の種類プロパティ</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        static public int[] DepositInitDspNos
        {
            get
            {
                return _depositInitDspNos;
            }
        }

        ///// public propaty name  :  InitSelMoneyKindCd
        ///// <summary>初期選択金種コードプロパティ</summary>
        ///// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初期選択金種コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 InitSelMoneyKindCd
        //{
        //    get { return _initSelMoneyKindCd; }
        //    set { _initSelMoneyKindCd = value; }
        //}

        ///// public propaty name  :  InitSelMoneyKindCdNm
        ///// <summary>初期選択金種名称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   初期選択金種名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string InitSelMoneyKindCdNm
        //{
        //    get { return _initSelMoneyKindCdNm; }
        //    set { _initSelMoneyKindCdNm = value; }
        //}

        /// public propaty name  :  DepositStKindCd
        /// <summary>入金設定金種コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd1
        {
            get { return _depositStKindCd1; }
            set { _depositStKindCd1 = value; }
        }

        /// public propaty name  :  DepositStKindCd2
        /// <summary>入金設定金種コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd2
        {
            get { return _depositStKindCd2; }
            set { _depositStKindCd2 = value; }
        }

        /// public propaty name  :  DepositStKindCd3
        /// <summary>入金設定金種コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd3
        {
            get { return _depositStKindCd3; }
            set { _depositStKindCd3 = value; }
        }

        /// public propaty name  :  DepositStKindCd4
        /// <summary>入金設定金種コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd4
        {
            get { return _depositStKindCd4; }
            set { _depositStKindCd4 = value; }
        }

        /// public propaty name  :  DepositStKindCd5
        /// <summary>入金設定金種コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd5
        {
            get { return _depositStKindCd5; }
            set { _depositStKindCd5 = value; }
        }

        /// public propaty name  :  DepositStKindCd6
        /// <summary>入金設定金種コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd6
        {
            get { return _depositStKindCd6; }
            set { _depositStKindCd6 = value; }
        }

        /// public propaty name  :  DepositStKindCd7
        /// <summary>入金設定金種コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd7
        {
            get { return _depositStKindCd7; }
            set { _depositStKindCd7 = value; }
        }

        /// public propaty name  :  DepositStKindCd8
        /// <summary>入金設定金種コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd8
        {
            get { return _depositStKindCd8; }
            set { _depositStKindCd8 = value; }
        }

        /// public propaty name  :  DepositStKindCd9
        /// <summary>入金設定金種コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd9
        {
            get { return _depositStKindCd9; }
            set { _depositStKindCd9 = value; }
        }

        /// public propaty name  :  DepositStKindCd10
        /// <summary>入金設定金種コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd10
        {
            get { return _depositStKindCd10; }
            set { _depositStKindCd10 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm1
        /// <summary>入金設定金種名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm1
        {
            get { return _depositStKindCdNm1; }
            set { _depositStKindCdNm1 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm2
        /// <summary>入金設定金種名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm2
        {
            get { return _depositStKindCdNm2; }
            set { _depositStKindCdNm2 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm3
        /// <summary>入金設定金種名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm3
        {
            get { return _depositStKindCdNm3; }
            set { _depositStKindCdNm3 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm4
        /// <summary>入金設定金種名称4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm4
        {
            get { return _depositStKindCdNm4; }
            set { _depositStKindCdNm4 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm5
        /// <summary>入金設定金種名称5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm5
        {
            get { return _depositStKindCdNm5; }
            set { _depositStKindCdNm5 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm6
        /// <summary>入金設定金種名称6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm6
        {
            get { return _depositStKindCdNm6; }
            set { _depositStKindCdNm6 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm7
        /// <summary>入金設定金種名称7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm7
        {
            get { return _depositStKindCdNm7; }
            set { _depositStKindCdNm7 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm8
        /// <summary>入金設定金種名称8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm8
        {
            get { return _depositStKindCdNm8; }
            set { _depositStKindCdNm8 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm9
        /// <summary>入金設定金種名称9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm9
        {
            get { return _depositStKindCdNm9; }
            set { _depositStKindCdNm9 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm10
        /// <summary>入金設定金種名称10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種名称10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepositStKindCdNm10
        {
            get { return _depositStKindCdNm10; }
            set { _depositStKindCdNm10 = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// public propaty name  :  DepositCallMonths
        /// <summary>入金伝票呼出月数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票呼出月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public Int32 DepositCallMonths
        //{
            //get { return _depositCallMonths; }
            //set { _depositCallMonths = value; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END


        /// public propaty name  :  AlwcDepoCallMonthsCd
        /// <summary>引当済入金伝票呼出区分プロパティ</summary>
        /// <value>0:引当済みでも呼び出す、1:金額引当済みは呼び出さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引当済入金伝票呼出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AlwcDepoCallMonthsCd
        {
            get { return _alwcDepoCallMonthsCd; }
            set { _alwcDepoCallMonthsCd = value; }
        }

        /// public propaty name  :  AlwcDepoCallMonthsCdName
        /// <summary>引当済入金伝票呼出名称プロパティ</summary>
        /// <value>0:引当済みでも呼び出す、1:金額引当済みは呼び出さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金初期表示画面番号名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public String AlwcDepoCallMonthsCdName
        {
            get { return GetAlwcDepoCallMonthsCdName(_alwcDepoCallMonthsCd); }
        }
        /// <summary>入金初期表示画面区分 0:引当済みでも呼び出す</summary>
        public const int PULLREAD = 0;
        /// <summary>入金初期表示画面区分 1:金額引当済みは呼び出さない</summary>
        public const int PULLNOREAD = 1;


        /// <summary>
        /// 入金初期表示画面番号名称取得
        /// </summary>
        /// <param name="alwcDepoCallMonthsCd">入金初期表示画面区分</param>
        /// <returns>入金初期表示画面区分名称</returns>
        /// <remarks>
        /// <br>Note       : 入金初期表示画面区分から入金初期表示画面区分名称を取得します</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        public string GetAlwcDepoCallMonthsCdName(int alwcDepoCallMonthsCd)
        {
            switch (alwcDepoCallMonthsCd)
            {
                case PULLREAD:
                    return "引当済みでも呼び出す";
                case PULLNOREAD:
                    return "金額引当済みは呼び出さない";
                default:
                    return "未設定";
            }
        }

        /// <summary>入金初期表示画面区分の種類</summary>
        static private int[] _alwcDepoCallMonthsCds = { PULLREAD, PULLNOREAD };
        /// <summary>入金初期表示画面区分の種類プロパティ</summary>
        /// <remarks>
        /// <br>Note       : 入金初期表示画面区分の種類プロパティ</br>
        /// <br>Programmer : 23013 牧　将人</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        static public int[] AlwcDepoCallMonthsCds
        {
            get
            {
                return _alwcDepoCallMonthsCds;
            }
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


        /// <summary>
        /// 入金設定クラスコンストラクタ
        /// </summary>
        /// <returns>DepositStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepositSt()
        {
        }

        /// <summary>
        /// 入金設定クラスコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="depositStMngCd">入金設定管理コード(常に０固定)</param>
        /// <param name="depositInitDspNo">入金初期表示画面番号(1:一括,2:伝票,3:一覧,4:売指定,5:消込一覧,6:消込売伝)</param>
        /// <param name="initSelMoneyKindCd">初期選択金種コード(1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金)</param>
        /// <param name="initSelMoneyKindCdNm">初期選択金種名称(1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金)</param>
        /// <param name="depositStKindCd1">入金設定金種コード1</param>
        /// <param name="depositStKindCd2">入金設定金種コード2</param>
        /// <param name="depositStKindCd3">入金設定金種コード3</param>
        /// <param name="depositStKindCd4">入金設定金種コード4</param>
        /// <param name="depositStKindCd5">入金設定金種コード5</param>
        /// <param name="depositStKindCd6">入金設定金種コード6</param>
        /// <param name="depositStKindCd7">入金設定金種コード7</param>
        /// <param name="depositStKindCd8">入金設定金種コード8</param>
        /// <param name="depositStKindCd9">入金設定金種コード9</param>
        /// <param name="depositStKindCd10">入金設定金種コード10</param>
        /// <param name="depositStKindCdNm1">入金設定金種名称1</param>
        /// <param name="depositStKindCdNm2">入金設定金種名称2</param>
        /// <param name="depositStKindCdNm3">入金設定金種名称3</param>
        /// <param name="depositStKindCdNm4">入金設定金種名称4</param>
        /// <param name="depositStKindCdNm5">入金設定金種名称5</param>
        /// <param name="depositStKindCdNm6">入金設定金種名称6</param>
        /// <param name="depositStKindCdNm7">入金設定金種名称7</param>
        /// <param name="depositStKindCdNm8">入金設定金種名称8</param>
        /// <param name="depositStKindCdNm9">入金設定金種名称9</param>
        /// <param name="depositStKindCdNm10">入金設定金種名称10</param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <param name="depositCallMonths">入金伝票呼出月数</param>
        /// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
        /// <param name="alwcDepoCallMonthsCd">引当済入金伝票呼出区分(0:引当済みでも呼び出す、1:金額引当済みは呼び出さない)</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>DepositStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
        //public DepositSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 depositStMngCd, Int32 depositInitDspNo, Int32 initSelMoneyKindCd, string initSelMoneyKindCdNm, Int32 depositStKindCd1, Int32 depositStKindCd2, Int32 depositStKindCd3, Int32 depositStKindCd4, Int32 depositStKindCd5, Int32 depositStKindCd6, Int32 depositStKindCd7, Int32 depositStKindCd8, Int32 depositStKindCd9, Int32 depositStKindCd10, string depositStKindCdNm1, string depositStKindCdNm2, string depositStKindCdNm3, string depositStKindCdNm4, string depositStKindCdNm5, string depositStKindCdNm6, string depositStKindCdNm7, string depositStKindCdNm8, string depositStKindCdNm9, string depositStKindCdNm10, Int32 depositCallMonths, Int32 alwcDepoCallMonthsCd, string updEmployeeName, string enterpriseName)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        public DepositSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 depositStMngCd, Int32 depositInitDspNo, Int32 depositStKindCd1, Int32 depositStKindCd2, Int32 depositStKindCd3, Int32 depositStKindCd4, Int32 depositStKindCd5, Int32 depositStKindCd6, Int32 depositStKindCd7, Int32 depositStKindCd8, Int32 depositStKindCd9, Int32 depositStKindCd10, string depositStKindCdNm1, string depositStKindCdNm2, string depositStKindCdNm3, string depositStKindCdNm4, string depositStKindCdNm5, string depositStKindCdNm6, string depositStKindCdNm7, string depositStKindCdNm8, string depositStKindCdNm9, string depositStKindCdNm10, Int32 alwcDepoCallMonthsCd, string updEmployeeName, string enterpriseName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._depositStMngCd = depositStMngCd;
            this._depositInitDspNo = depositInitDspNo;
            //this._initSelMoneyKindCd = initSelMoneyKindCd;
            //this._initSelMoneyKindCdNm = initSelMoneyKindCdNm;
            this._depositStKindCd1 = depositStKindCd1;
            this._depositStKindCd2 = depositStKindCd2;
            this._depositStKindCd3 = depositStKindCd3;
            this._depositStKindCd4 = depositStKindCd4;
            this._depositStKindCd5 = depositStKindCd5;
            this._depositStKindCd6 = depositStKindCd6;
            this._depositStKindCd7 = depositStKindCd7;
            this._depositStKindCd8 = depositStKindCd8;
            this._depositStKindCd9 = depositStKindCd9;
            this._depositStKindCd10 = depositStKindCd10;
            this._depositStKindCdNm1 = depositStKindCdNm1;
            this._depositStKindCdNm2 = depositStKindCdNm2;
            this._depositStKindCdNm3 = depositStKindCdNm3;
            this._depositStKindCdNm4 = depositStKindCdNm4;
            this._depositStKindCdNm5 = depositStKindCdNm5;
            this._depositStKindCdNm6 = depositStKindCdNm6;
            this._depositStKindCdNm7 = depositStKindCdNm7;
            this._depositStKindCdNm8 = depositStKindCdNm8;
            this._depositStKindCdNm9 = depositStKindCdNm9;
            this._depositStKindCdNm10 = depositStKindCdNm10;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //this._depositCallMonths = depositCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            this._alwcDepoCallMonthsCd = alwcDepoCallMonthsCd;
            this._updEmployeeName = updEmployeeName;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 入金設定クラス複製処理
        /// </summary>
        /// <returns>DepositStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいDepositStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepositSt Clone()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
            return new DepositSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._depositStMngCd, this._depositInitDspNo, this._depositStKindCd1, this._depositStKindCd2, this._depositStKindCd3, this._depositStKindCd4, this._depositStKindCd5, this._depositStKindCd6, this._depositStKindCd7, this._depositStKindCd8, this._depositStKindCd9, this._depositStKindCd10, this._depositStKindCdNm1, this._depositStKindCdNm2, this._depositStKindCdNm3, this._depositStKindCdNm4, this._depositStKindCdNm5, this._depositStKindCdNm6, this._depositStKindCdNm7, this._depositStKindCdNm8, this._depositStKindCdNm9, this._depositStKindCdNm10, this._alwcDepoCallMonthsCd, this._updEmployeeName, this._enterpriseName);
            //return new DepositSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._depositStMngCd, this._depositInitDspNo, this._initSelMoneyKindCd, this._initSelMoneyKindCdNm, this._depositStKindCd1, this._depositStKindCd2, this._depositStKindCd3, this._depositStKindCd4, this._depositStKindCd5, this._depositStKindCd6, this._depositStKindCd7, this._depositStKindCd8, this._depositStKindCd9, this._depositStKindCd10, this._depositStKindCdNm1, this._depositStKindCdNm2, this._depositStKindCdNm3, this._depositStKindCdNm4, this._depositStKindCdNm5, this._depositStKindCdNm6, this._depositStKindCdNm7, this._depositStKindCdNm8, this._depositStKindCdNm9, this._depositStKindCdNm10, this._depositCallMonths, this._alwcDepoCallMonthsCd, this._updEmployeeName, this._enterpriseName);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        }

        /// <summary>
        /// 入金設定クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のDepositStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(DepositSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                && (this.UpdateDateTime == target.UpdateDateTime)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.FileHeaderGuid == target.FileHeaderGuid)
                && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                && (this.DepositStMngCd == target.DepositStMngCd)
                && (this.DepositInitDspNo == target.DepositInitDspNo)
                //&& (this.InitSelMoneyKindCd == target.InitSelMoneyKindCd)
                //&& (this.InitSelMoneyKindCdNm == target.InitSelMoneyKindCdNm)
                && (this.DepositStKindCd1 == target.DepositStKindCd1)
                && (this.DepositStKindCd2 == target.DepositStKindCd2)
                && (this.DepositStKindCd3 == target.DepositStKindCd3)
                && (this.DepositStKindCd4 == target.DepositStKindCd4)
                && (this.DepositStKindCd5 == target.DepositStKindCd5)
                && (this.DepositStKindCd6 == target.DepositStKindCd6)
                && (this.DepositStKindCd7 == target.DepositStKindCd7)
                && (this.DepositStKindCd8 == target.DepositStKindCd8)
                && (this.DepositStKindCd9 == target.DepositStKindCd9)
                && (this.DepositStKindCd10 == target.DepositStKindCd10)
                && (this.DepositStKindCdNm1 == target.DepositStKindCdNm1)
                && (this.DepositStKindCdNm2 == target.DepositStKindCdNm2)
                && (this.DepositStKindCdNm3 == target.DepositStKindCdNm3)
                && (this.DepositStKindCdNm4 == target.DepositStKindCdNm4)
                && (this.DepositStKindCdNm5 == target.DepositStKindCdNm5)
                && (this.DepositStKindCdNm6 == target.DepositStKindCdNm6)
                && (this.DepositStKindCdNm7 == target.DepositStKindCdNm7)
                && (this.DepositStKindCdNm8 == target.DepositStKindCdNm8)
                && (this.DepositStKindCdNm9 == target.DepositStKindCdNm9)
                && (this.DepositStKindCdNm10 == target.DepositStKindCdNm10)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                //&& (this.DepositCallMonths == target.DepositCallMonths)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                && (this.AlwcDepoCallMonthsCd == target.AlwcDepoCallMonthsCd)
                && (this.UpdEmployeeName == target.UpdEmployeeName)
                && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 入金設定クラス比較処理
        /// </summary>
        /// <param name="depositSt1">
        ///                    比較するDepositStクラスのインスタンス
        /// </param>
        /// <param name="depositSt2">比較するDepositStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(DepositSt depositSt1, DepositSt depositSt2)
        {
            return ((depositSt1.CreateDateTime == depositSt2.CreateDateTime)
                && (depositSt1.UpdateDateTime == depositSt2.UpdateDateTime)
                && (depositSt1.EnterpriseCode == depositSt2.EnterpriseCode)
                && (depositSt1.FileHeaderGuid == depositSt2.FileHeaderGuid)
                && (depositSt1.UpdEmployeeCode == depositSt2.UpdEmployeeCode)
                && (depositSt1.UpdAssemblyId1 == depositSt2.UpdAssemblyId1)
                && (depositSt1.UpdAssemblyId2 == depositSt2.UpdAssemblyId2)
                && (depositSt1.LogicalDeleteCode == depositSt2.LogicalDeleteCode)
                && (depositSt1.DepositStMngCd == depositSt2.DepositStMngCd)
                && (depositSt1.DepositInitDspNo == depositSt2.DepositInitDspNo)
                //&& (depositSt1.InitSelMoneyKindCd == depositSt2.InitSelMoneyKindCd)
                //&& (depositSt1.InitSelMoneyKindCdNm == depositSt2.InitSelMoneyKindCdNm)
                && (depositSt1.DepositStKindCd1 == depositSt2.DepositStKindCd1)
                && (depositSt1.DepositStKindCd2 == depositSt2.DepositStKindCd2)
                && (depositSt1.DepositStKindCd3 == depositSt2.DepositStKindCd3)
                && (depositSt1.DepositStKindCd4 == depositSt2.DepositStKindCd4)
                && (depositSt1.DepositStKindCd5 == depositSt2.DepositStKindCd5)
                && (depositSt1.DepositStKindCd6 == depositSt2.DepositStKindCd6)
                && (depositSt1.DepositStKindCd7 == depositSt2.DepositStKindCd7)
                && (depositSt1.DepositStKindCd8 == depositSt2.DepositStKindCd8)
                && (depositSt1.DepositStKindCd9 == depositSt2.DepositStKindCd9)
                && (depositSt1.DepositStKindCd10 == depositSt2.DepositStKindCd10)
                && (depositSt1.DepositStKindCdNm1 == depositSt2.DepositStKindCdNm1)
                && (depositSt1.DepositStKindCdNm2 == depositSt2.DepositStKindCdNm2)
                && (depositSt1.DepositStKindCdNm3 == depositSt2.DepositStKindCdNm3)
                && (depositSt1.DepositStKindCdNm4 == depositSt2.DepositStKindCdNm4)
                && (depositSt1.DepositStKindCdNm5 == depositSt2.DepositStKindCdNm5)
                && (depositSt1.DepositStKindCdNm6 == depositSt2.DepositStKindCdNm6)
                && (depositSt1.DepositStKindCdNm7 == depositSt2.DepositStKindCdNm7)
                && (depositSt1.DepositStKindCdNm8 == depositSt2.DepositStKindCdNm8)
                && (depositSt1.DepositStKindCdNm9 == depositSt2.DepositStKindCdNm9)
                && (depositSt1.DepositStKindCdNm10 == depositSt2.DepositStKindCdNm10)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                //&& (depositSt1.DepositCallMonths == depositSt2.DepositCallMonths)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                && (depositSt1.AlwcDepoCallMonthsCd == depositSt2.AlwcDepoCallMonthsCd)
                && (depositSt1.UpdEmployeeName == depositSt2.UpdEmployeeName)
                && (depositSt1.EnterpriseName == depositSt2.EnterpriseName));
        }
        /// <summary>
        /// 入金設定クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のDepositStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(DepositSt target)
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
            if (this.DepositStMngCd != target.DepositStMngCd) resList.Add("DepositStMngCd");
            if (this.DepositInitDspNo != target.DepositInitDspNo) resList.Add("DepositInitDspNo");
            //if (this.InitSelMoneyKindCd != target.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            //if (this.InitSelMoneyKindCdNm != target.InitSelMoneyKindCdNm) resList.Add("InitSelMoneyKindCdNm");
            if (this.DepositStKindCd1 != target.DepositStKindCd1) resList.Add("DepositStKindCd1");
            if (this.DepositStKindCd2 != target.DepositStKindCd2) resList.Add("DepositStKindCd2");
            if (this.DepositStKindCd3 != target.DepositStKindCd3) resList.Add("DepositStKindCd3");
            if (this.DepositStKindCd4 != target.DepositStKindCd4) resList.Add("DepositStKindCd4");
            if (this.DepositStKindCd5 != target.DepositStKindCd5) resList.Add("DepositStKindCd5");
            if (this.DepositStKindCd6 != target.DepositStKindCd6) resList.Add("DepositStKindCd6");
            if (this.DepositStKindCd7 != target.DepositStKindCd7) resList.Add("DepositStKindCd7");
            if (this.DepositStKindCd8 != target.DepositStKindCd8) resList.Add("DepositStKindCd8");
            if (this.DepositStKindCd9 != target.DepositStKindCd9) resList.Add("DepositStKindCd9");
            if (this.DepositStKindCd10 != target.DepositStKindCd10) resList.Add("DepositStKindCd10");
            if (this.DepositStKindCdNm1 != target.DepositStKindCdNm1) resList.Add("DepositStKindCdNm1");
            if (this.DepositStKindCdNm2 != target.DepositStKindCdNm2) resList.Add("DepositStKindCdNm2");
            if (this.DepositStKindCdNm3 != target.DepositStKindCdNm3) resList.Add("DepositStKindCdNm3");
            if (this.DepositStKindCdNm4 != target.DepositStKindCdNm4) resList.Add("DepositStKindCdNm4");
            if (this.DepositStKindCdNm5 != target.DepositStKindCdNm5) resList.Add("DepositStKindCdNm5");
            if (this.DepositStKindCdNm6 != target.DepositStKindCdNm6) resList.Add("DepositStKindCdNm6");
            if (this.DepositStKindCdNm7 != target.DepositStKindCdNm7) resList.Add("DepositStKindCdNm7");
            if (this.DepositStKindCdNm8 != target.DepositStKindCdNm8) resList.Add("DepositStKindCdNm8");
            if (this.DepositStKindCdNm9 != target.DepositStKindCdNm9) resList.Add("DepositStKindCdNm9");
            if (this.DepositStKindCdNm10 != target.DepositStKindCdNm10) resList.Add("DepositStKindCdNm10");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (this.DepositCallMonths != target.DepositCallMonths) resList.Add("DepositCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            if (this.AlwcDepoCallMonthsCd != target.AlwcDepoCallMonthsCd) resList.Add("AlwcDepoCallMonthsCd");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// 入金設定クラス比較処理
        /// </summary>
        /// <param name="depositSt1">比較するDepositStクラスのインスタンス</param>
        /// <param name="depositSt2">比較するDepositStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(DepositSt depositSt1, DepositSt depositSt2)
        {
            ArrayList resList = new ArrayList();
            if (depositSt1.CreateDateTime != depositSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (depositSt1.UpdateDateTime != depositSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (depositSt1.EnterpriseCode != depositSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (depositSt1.FileHeaderGuid != depositSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (depositSt1.UpdEmployeeCode != depositSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (depositSt1.UpdAssemblyId1 != depositSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (depositSt1.UpdAssemblyId2 != depositSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (depositSt1.LogicalDeleteCode != depositSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (depositSt1.DepositStMngCd != depositSt2.DepositStMngCd) resList.Add("DepositStMngCd");
            if (depositSt1.DepositInitDspNo != depositSt2.DepositInitDspNo) resList.Add("DepositInitDspNo");
            //if (depositSt1.InitSelMoneyKindCd != depositSt2.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            //if (depositSt1.InitSelMoneyKindCdNm != depositSt2.InitSelMoneyKindCdNm) resList.Add("InitSelMoneyKindCdNm");
            if (depositSt1.DepositStKindCd1 != depositSt2.DepositStKindCd1) resList.Add("DepositStKindCd1");
            if (depositSt1.DepositStKindCd2 != depositSt2.DepositStKindCd2) resList.Add("DepositStKindCd2");
            if (depositSt1.DepositStKindCd3 != depositSt2.DepositStKindCd3) resList.Add("DepositStKindCd3");
            if (depositSt1.DepositStKindCd4 != depositSt2.DepositStKindCd4) resList.Add("DepositStKindCd4");
            if (depositSt1.DepositStKindCd5 != depositSt2.DepositStKindCd5) resList.Add("DepositStKindCd5");
            if (depositSt1.DepositStKindCd6 != depositSt2.DepositStKindCd6) resList.Add("DepositStKindCd6");
            if (depositSt1.DepositStKindCd7 != depositSt2.DepositStKindCd7) resList.Add("DepositStKindCd7");
            if (depositSt1.DepositStKindCd8 != depositSt2.DepositStKindCd8) resList.Add("DepositStKindCd8");
            if (depositSt1.DepositStKindCd9 != depositSt2.DepositStKindCd9) resList.Add("DepositStKindCd9");
            if (depositSt1.DepositStKindCd10 != depositSt2.DepositStKindCd10) resList.Add("DepositStKindCd10");
            if (depositSt1.DepositStKindCdNm1 != depositSt2.DepositStKindCdNm1) resList.Add("DepositStKindCdNm1");
            if (depositSt1.DepositStKindCdNm2 != depositSt2.DepositStKindCdNm2) resList.Add("DepositStKindCdNm2");
            if (depositSt1.DepositStKindCdNm3 != depositSt2.DepositStKindCdNm3) resList.Add("DepositStKindCdNm3");
            if (depositSt1.DepositStKindCdNm4 != depositSt2.DepositStKindCdNm4) resList.Add("DepositStKindCdNm4");
            if (depositSt1.DepositStKindCdNm5 != depositSt2.DepositStKindCdNm5) resList.Add("DepositStKindCdNm5");
            if (depositSt1.DepositStKindCdNm6 != depositSt2.DepositStKindCdNm6) resList.Add("DepositStKindCdNm6");
            if (depositSt1.DepositStKindCdNm7 != depositSt2.DepositStKindCdNm7) resList.Add("DepositStKindCdNm7");
            if (depositSt1.DepositStKindCdNm8 != depositSt2.DepositStKindCdNm8) resList.Add("DepositStKindCdNm8");
            if (depositSt1.DepositStKindCdNm9 != depositSt2.DepositStKindCdNm9) resList.Add("DepositStKindCdNm9");
            if (depositSt1.DepositStKindCdNm10 != depositSt2.DepositStKindCdNm10) resList.Add("DepositStKindCdNm10");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (depositSt1.DepositCallMonths != depositSt2.DepositCallMonths) resList.Add("DepositCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            if (depositSt1.AlwcDepoCallMonthsCd != depositSt2.AlwcDepoCallMonthsCd) resList.Add("AlwcDepoCallMonthsCd");
            if (depositSt1.UpdEmployeeName != depositSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (depositSt1.EnterpriseName != depositSt2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
