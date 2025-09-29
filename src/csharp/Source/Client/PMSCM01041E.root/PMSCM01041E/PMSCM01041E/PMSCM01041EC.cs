using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SmplInqChg
    /// <summary>
    ///                      簡単問合せID変換マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   簡単問合せID変換マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   中村仁</br>
    /// <br>Genarated Date   :   2010/04/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SmplInqChg
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

        /// <summary>簡単問合せID付属情報管理番号</summary>
        /// <remarks>ユーザー単位の連番</remarks>
        private Int64 _simpleInqIdInfMngNo;

        /// <summary>簡単問合せID変換サービスシステム区分</summary>
        /// <remarks>100:SF,BK,CS,VX 200:PM 300:MK 400:TR ・・・</remarks>
        private Int32 _simpleInqIdCngSysCd;

        /// <summary>変換元アカウント識別キー</summary>
        /// <remarks>(半角全角混在)システム区分毎にユーザーが識別できるキー(企業CD,BLユーザコード等)</remarks>
        private string _originalAcntDiskKey = "";

        /// <summary>変換元アカウントID</summary>
        /// <remarks>(半角全角混在)変換元のアカウントID(従業員CDなど)</remarks>
        private string _originalAcntId = "";


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

        /// public propaty name  :  SimpleInqIdInfMngNo
        /// <summary>簡単問合せID付属情報管理番号プロパティ</summary>
        /// <value>ユーザー単位の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せID付属情報管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SimpleInqIdInfMngNo
        {
            get { return _simpleInqIdInfMngNo; }
            set { _simpleInqIdInfMngNo = value; }
        }

        /// public propaty name  :  SimpleInqIdCngSysCd
        /// <summary>簡単問合せID変換サービスシステム区分プロパティ</summary>
        /// <value>100:SF,BK,CS,VX 200:PM 300:MK 400:TR ・・・</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せID変換サービスシステム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SimpleInqIdCngSysCd
        {
            get { return _simpleInqIdCngSysCd; }
            set { _simpleInqIdCngSysCd = value; }
        }

        /// public propaty name  :  OriginalAcntDiskKey
        /// <summary>変換元アカウント識別キープロパティ</summary>
        /// <value>(半角全角混在)システム区分毎にユーザーが識別できるキー(企業CD,BLユーザコード等)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元アカウント識別キープロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OriginalAcntDiskKey
        {
            get { return _originalAcntDiskKey; }
            set { _originalAcntDiskKey = value; }
        }

        /// public propaty name  :  OriginalAcntId
        /// <summary>変換元アカウントIDプロパティ</summary>
        /// <value>(半角全角混在)変換元のアカウントID(従業員CDなど)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元アカウントIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OriginalAcntId
        {
            get { return _originalAcntId; }
            set { _originalAcntId = value; }
        }


        /// <summary>
        /// 簡単問合せID変換マスタコンストラクタ
        /// </summary>
        /// <returns>SmplInqChgクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqChgクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqChg()
        {
        }

        /// <summary>
        /// 簡単問合せID変換マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="simpleInqIdInfMngNo">簡単問合せID付属情報管理番号(ユーザー単位の連番)</param>
        /// <param name="simpleInqIdCngSysCd">簡単問合せID変換サービスシステム区分(100:SF,BK,CS,VX 200:PM 300:MK 400:TR ・・・)</param>
        /// <param name="originalAcntDiskKey">変換元アカウント識別キー((半角全角混在)システム区分毎にユーザーが識別できるキー(企業CD,BLユーザコード等))</param>
        /// <param name="originalAcntId">変換元アカウントID((半角全角混在)変換元のアカウントID(従業員CDなど))</param>
        /// <returns>SmplInqChgクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqChgクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqChg(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int64 simpleInqIdInfMngNo, Int32 simpleInqIdCngSysCd, string originalAcntDiskKey, string originalAcntId)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._simpleInqIdInfMngNo = simpleInqIdInfMngNo;
            this._simpleInqIdCngSysCd = simpleInqIdCngSysCd;
            this._originalAcntDiskKey = originalAcntDiskKey;
            this._originalAcntId = originalAcntId;

        }

        /// <summary>
        /// 簡単問合せID変換マスタ複製処理
        /// </summary>
        /// <returns>SmplInqChgクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSmplInqChgクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqChg Clone()
        {
            return new SmplInqChg(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._simpleInqIdInfMngNo, this._simpleInqIdCngSysCd, this._originalAcntDiskKey, this._originalAcntId);
        }

        /// <summary>
        /// 簡単問合せID変換マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSmplInqChgクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqChgクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SmplInqChg target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SimpleInqIdInfMngNo == target.SimpleInqIdInfMngNo )
                 && ( this.SimpleInqIdCngSysCd == target.SimpleInqIdCngSysCd )
                 && ( this.OriginalAcntDiskKey == target.OriginalAcntDiskKey )
                 && ( this.OriginalAcntId == target.OriginalAcntId ) );
        }

        /// <summary>
        /// 簡単問合せID変換マスタ比較処理
        /// </summary>
        /// <param name="smplInqChg1">
        ///                    比較するSmplInqChgクラスのインスタンス
        /// </param>
        /// <param name="smplInqChg2">比較するSmplInqChgクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqChgクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SmplInqChg smplInqChg1, SmplInqChg smplInqChg2)
        {
            return ( ( smplInqChg1.CreateDateTime == smplInqChg2.CreateDateTime )
                 && ( smplInqChg1.UpdateDateTime == smplInqChg2.UpdateDateTime )
                 && ( smplInqChg1.LogicalDeleteCode == smplInqChg2.LogicalDeleteCode )
                 && ( smplInqChg1.SimpleInqIdInfMngNo == smplInqChg2.SimpleInqIdInfMngNo )
                 && ( smplInqChg1.SimpleInqIdCngSysCd == smplInqChg2.SimpleInqIdCngSysCd )
                 && ( smplInqChg1.OriginalAcntDiskKey == smplInqChg2.OriginalAcntDiskKey )
                 && ( smplInqChg1.OriginalAcntId == smplInqChg2.OriginalAcntId ) );
        }
        /// <summary>
        /// 簡単問合せID変換マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSmplInqChgクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqChgクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SmplInqChg target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SimpleInqIdInfMngNo != target.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (this.SimpleInqIdCngSysCd != target.SimpleInqIdCngSysCd) resList.Add("SimpleInqIdCngSysCd");
            if (this.OriginalAcntDiskKey != target.OriginalAcntDiskKey) resList.Add("OriginalAcntDiskKey");
            if (this.OriginalAcntId != target.OriginalAcntId) resList.Add("OriginalAcntId");

            return resList;
        }

        /// <summary>
        /// 簡単問合せID変換マスタ比較処理
        /// </summary>
        /// <param name="smplInqChg1">比較するSmplInqChgクラスのインスタンス</param>
        /// <param name="smplInqChg2">比較するSmplInqChgクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqChgクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SmplInqChg smplInqChg1, SmplInqChg smplInqChg2)
        {
            ArrayList resList = new ArrayList();
            if (smplInqChg1.CreateDateTime != smplInqChg2.CreateDateTime) resList.Add("CreateDateTime");
            if (smplInqChg1.UpdateDateTime != smplInqChg2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (smplInqChg1.LogicalDeleteCode != smplInqChg2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (smplInqChg1.SimpleInqIdInfMngNo != smplInqChg2.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (smplInqChg1.SimpleInqIdCngSysCd != smplInqChg2.SimpleInqIdCngSysCd) resList.Add("SimpleInqIdCngSysCd");
            if (smplInqChg1.OriginalAcntDiskKey != smplInqChg2.OriginalAcntDiskKey) resList.Add("OriginalAcntDiskKey");
            if (smplInqChg1.OriginalAcntId != smplInqChg2.OriginalAcntId) resList.Add("OriginalAcntId");

            return resList;
        }
    }
}
