using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SmplInqInf
    /// <summary>
    ///                      簡単問合せID情報管理マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   簡単問合せID情報管理マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   中村 仁</br>
    /// <br>Genarated Date   :   2010/04/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SmplInqInf
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

        /// <summary>簡単問合せアカウントID</summary>
        /// <remarks>(半角英数)</remarks>
        private string _simplInqAcntAcntId = "";

        /// <summary>簡単問合せアカウントパスワード</summary>
        /// <remarks>(半角のみ)(半角英数)</remarks>
        private string _simplInqAcntPass = "";


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

        /// public propaty name  :  SimplInqAcntAcntId
        /// <summary>簡単問合せアカウントIDプロパティ</summary>
        /// <value>(半角英数)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せアカウントIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SimplInqAcntAcntId
        {
            get { return _simplInqAcntAcntId; }
            set { _simplInqAcntAcntId = value; }
        }

        /// public propaty name  :  SimplInqAcntPass
        /// <summary>簡単問合せアカウントパスワードプロパティ</summary>
        /// <value>(半角のみ)(半角英数)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   簡単問合せアカウントパスワードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SimplInqAcntPass
        {
            get { return _simplInqAcntPass; }
            set { _simplInqAcntPass = value; }
        }


        /// <summary>
        /// 簡単問合せID情報管理マスタコンストラクタ
        /// </summary>
        /// <returns>SmplInqInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqInfクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqInf()
        {
        }

        /// <summary>
        /// 簡単問合せID情報管理マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="simpleInqIdInfMngNo">簡単問合せID付属情報管理番号(ユーザー単位の連番)</param>
        /// <param name="simplInqAcntAcntId">簡単問合せアカウントID((半角英数))</param>
        /// <param name="simplInqAcntPass">簡単問合せアカウントパスワード((半角のみ)(半角英数))</param>
        /// <returns>SmplInqInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqInfクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqInf(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int64 simpleInqIdInfMngNo, string simplInqAcntAcntId, string simplInqAcntPass)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._simpleInqIdInfMngNo = simpleInqIdInfMngNo;
            this._simplInqAcntAcntId = simplInqAcntAcntId;
            this._simplInqAcntPass = simplInqAcntPass;

        }

        /// <summary>
        /// 簡単問合せID情報管理マスタ複製処理
        /// </summary>
        /// <returns>SmplInqInfクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSmplInqInfクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SmplInqInf Clone()
        {
            return new SmplInqInf(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._simpleInqIdInfMngNo, this._simplInqAcntAcntId, this._simplInqAcntPass);
        }

        /// <summary>
        /// 簡単問合せID情報管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSmplInqInfクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqInfクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SmplInqInf target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SimpleInqIdInfMngNo == target.SimpleInqIdInfMngNo )
                 && ( this.SimplInqAcntAcntId == target.SimplInqAcntAcntId )
                 && ( this.SimplInqAcntPass == target.SimplInqAcntPass ) );
        }

        /// <summary>
        /// 簡単問合せID情報管理マスタ比較処理
        /// </summary>
        /// <param name="smplInqInf1">
        ///                    比較するSmplInqInfクラスのインスタンス
        /// </param>
        /// <param name="smplInqInf2">比較するSmplInqInfクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqInfクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SmplInqInf smplInqInf1, SmplInqInf smplInqInf2)
        {
            return ( ( smplInqInf1.CreateDateTime == smplInqInf2.CreateDateTime )
                 && ( smplInqInf1.UpdateDateTime == smplInqInf2.UpdateDateTime )
                 && ( smplInqInf1.LogicalDeleteCode == smplInqInf2.LogicalDeleteCode )
                 && ( smplInqInf1.SimpleInqIdInfMngNo == smplInqInf2.SimpleInqIdInfMngNo )
                 && ( smplInqInf1.SimplInqAcntAcntId == smplInqInf2.SimplInqAcntAcntId )
                 && ( smplInqInf1.SimplInqAcntPass == smplInqInf2.SimplInqAcntPass ) );
        }
        /// <summary>
        /// 簡単問合せID情報管理マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSmplInqInfクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqInfクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SmplInqInf target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SimpleInqIdInfMngNo != target.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (this.SimplInqAcntAcntId != target.SimplInqAcntAcntId) resList.Add("SimplInqAcntAcntId");
            if (this.SimplInqAcntPass != target.SimplInqAcntPass) resList.Add("SimplInqAcntPass");

            return resList;
        }

        /// <summary>
        /// 簡単問合せID情報管理マスタ比較処理
        /// </summary>
        /// <param name="smplInqInf1">比較するSmplInqInfクラスのインスタンス</param>
        /// <param name="smplInqInf2">比較するSmplInqInfクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SmplInqInfクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SmplInqInf smplInqInf1, SmplInqInf smplInqInf2)
        {
            ArrayList resList = new ArrayList();
            if (smplInqInf1.CreateDateTime != smplInqInf2.CreateDateTime) resList.Add("CreateDateTime");
            if (smplInqInf1.UpdateDateTime != smplInqInf2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (smplInqInf1.LogicalDeleteCode != smplInqInf2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (smplInqInf1.SimpleInqIdInfMngNo != smplInqInf2.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (smplInqInf1.SimplInqAcntAcntId != smplInqInf2.SimplInqAcntAcntId) resList.Add("SimplInqAcntAcntId");
            if (smplInqInf1.SimplInqAcntPass != smplInqInf2.SimplInqAcntPass) resList.Add("SimplInqAcntPass");

            return resList;
        }
    }
}
