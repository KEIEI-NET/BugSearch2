﻿using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   JoinPartsU
    /// <summary>
    ///                      結合マスタ（ユーザー登録）
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合マスタ（ユーザー登録）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2006/11/22</br>
    /// <br>Genarated Date   :   2008/07/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class JoinPartsU
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

        /// <summary>結合表示順位</summary>
        /// <remarks>ユーザー登録分の表示順位（提供より必ず上になる）</remarks>
        private Int32 _joinDispOrder;

        /// <summary>結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCode;

        /// <summary>結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithH = "";

        /// <summary>結合元品番(－無し品番)</summary>
        private string _joinSourPartsNoNoneH = "";

        /// <summary>結合先メーカーコード</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>結合先品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>結合QTY</summary>
        private Double _joinQty;

        /// <summary>結合規格・特記事項</summary>
        private string _joinSpecialNote = "";

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

        /// public propaty name  :  JoinDispOrder
        /// <summary>結合表示順位プロパティ</summary>
        /// <value>ユーザー登録分の表示順位（提供より必ず上になる）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  JoinSourPartsNoNoneH
        /// <summary>結合元品番(－無し品番)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－無し品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoNoneH
        {
            get { return _joinSourPartsNoNoneH; }
            set { _joinSourPartsNoNoneH = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>結合先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>結合先品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>結合QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>結合規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
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
        /// 結合マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <returns>JoinPartsUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsU()
        {
        }

        /// <summary>
        /// 結合マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="joinDispOrder">結合表示順位(ユーザー登録分の表示順位（提供より必ず上になる）)</param>
        /// <param name="joinSourceMakerCode">結合元メーカーコード</param>
        /// <param name="joinSourPartsNoWithH">結合元品番(－付き品番)(ハイフン付き)</param>
        /// <param name="joinSourPartsNoNoneH">結合元品番(－無し品番)</param>
        /// <param name="joinDestMakerCd">結合先メーカーコード</param>
        /// <param name="joinDestPartsNo">結合先品番(－付き品番)(ハイフン付き)</param>
        /// <param name="joinQty">結合QTY</param>
        /// <param name="joinSpecialNote">結合規格・特記事項</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>JoinPartsUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 joinDispOrder, Int32 joinSourceMakerCode, string joinSourPartsNoWithH, string joinSourPartsNoNoneH, Int32 joinDestMakerCd, string joinDestPartsNo, Double joinQty, string joinSpecialNote, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._joinDispOrder = joinDispOrder;
            this._joinSourceMakerCode = joinSourceMakerCode;
            this._joinSourPartsNoWithH = joinSourPartsNoWithH;
            this._joinSourPartsNoNoneH = joinSourPartsNoNoneH;
            this._joinDestMakerCd = joinDestMakerCd;
            this._joinDestPartsNo = joinDestPartsNo;
            this._joinQty = joinQty;
            this._joinSpecialNote = joinSpecialNote;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 結合マスタ（ユーザー登録）複製処理
        /// </summary>
        /// <returns>JoinPartsUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいJoinPartsUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsU Clone()
        {
            return new JoinPartsU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._joinDispOrder, this._joinSourceMakerCode, this._joinSourPartsNoWithH, this._joinSourPartsNoNoneH, this._joinDestMakerCd, this._joinDestPartsNo, this._joinQty, this._joinSpecialNote, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 結合マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のJoinPartsUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(JoinPartsU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.JoinDispOrder == target.JoinDispOrder)
                 && (this.JoinSourceMakerCode == target.JoinSourceMakerCode)
                 && (this.JoinSourPartsNoWithH == target.JoinSourPartsNoWithH)
                 && (this.JoinSourPartsNoNoneH == target.JoinSourPartsNoNoneH)
                 && (this.JoinDestMakerCd == target.JoinDestMakerCd)
                 && (this.JoinDestPartsNo == target.JoinDestPartsNo)
                 && (this.JoinQty == target.JoinQty)
                 && (this.JoinSpecialNote == target.JoinSpecialNote)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 結合マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="joinPartsU1">
        ///                    比較するJoinPartsUクラスのインスタンス
        /// </param>
        /// <param name="joinPartsU2">比較するJoinPartsUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(JoinPartsU joinPartsU1, JoinPartsU joinPartsU2)
        {
            return ((joinPartsU1.CreateDateTime == joinPartsU2.CreateDateTime)
                 && (joinPartsU1.UpdateDateTime == joinPartsU2.UpdateDateTime)
                 && (joinPartsU1.EnterpriseCode == joinPartsU2.EnterpriseCode)
                 && (joinPartsU1.FileHeaderGuid == joinPartsU2.FileHeaderGuid)
                 && (joinPartsU1.UpdEmployeeCode == joinPartsU2.UpdEmployeeCode)
                 && (joinPartsU1.UpdAssemblyId1 == joinPartsU2.UpdAssemblyId1)
                 && (joinPartsU1.UpdAssemblyId2 == joinPartsU2.UpdAssemblyId2)
                 && (joinPartsU1.LogicalDeleteCode == joinPartsU2.LogicalDeleteCode)
                 && (joinPartsU1.JoinDispOrder == joinPartsU2.JoinDispOrder)
                 && (joinPartsU1.JoinSourceMakerCode == joinPartsU2.JoinSourceMakerCode)
                 && (joinPartsU1.JoinSourPartsNoWithH == joinPartsU2.JoinSourPartsNoWithH)
                 && (joinPartsU1.JoinSourPartsNoNoneH == joinPartsU2.JoinSourPartsNoNoneH)
                 && (joinPartsU1.JoinDestMakerCd == joinPartsU2.JoinDestMakerCd)
                 && (joinPartsU1.JoinDestPartsNo == joinPartsU2.JoinDestPartsNo)
                 && (joinPartsU1.JoinQty == joinPartsU2.JoinQty)
                 && (joinPartsU1.JoinSpecialNote == joinPartsU2.JoinSpecialNote)
                 && (joinPartsU1.EnterpriseName == joinPartsU2.EnterpriseName)
                 && (joinPartsU1.UpdEmployeeName == joinPartsU2.UpdEmployeeName));
        }
        /// <summary>
        /// 結合マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のJoinPartsUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(JoinPartsU target)
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
            if (this.JoinDispOrder != target.JoinDispOrder) resList.Add("JoinDispOrder");
            if (this.JoinSourceMakerCode != target.JoinSourceMakerCode) resList.Add("JoinSourceMakerCode");
            if (this.JoinSourPartsNoWithH != target.JoinSourPartsNoWithH) resList.Add("JoinSourPartsNoWithH");
            if (this.JoinSourPartsNoNoneH != target.JoinSourPartsNoNoneH) resList.Add("JoinSourPartsNoNoneH");
            if (this.JoinDestMakerCd != target.JoinDestMakerCd) resList.Add("JoinDestMakerCd");
            if (this.JoinDestPartsNo != target.JoinDestPartsNo) resList.Add("JoinDestPartsNo");
            if (this.JoinQty != target.JoinQty) resList.Add("JoinQty");
            if (this.JoinSpecialNote != target.JoinSpecialNote) resList.Add("JoinSpecialNote");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 結合マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="joinPartsU1">比較するJoinPartsUクラスのインスタンス</param>
        /// <param name="joinPartsU2">比較するJoinPartsUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   JoinPartsUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(JoinPartsU joinPartsU1, JoinPartsU joinPartsU2)
        {
            ArrayList resList = new ArrayList();
            if (joinPartsU1.CreateDateTime != joinPartsU2.CreateDateTime) resList.Add("CreateDateTime");
            if (joinPartsU1.UpdateDateTime != joinPartsU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (joinPartsU1.EnterpriseCode != joinPartsU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (joinPartsU1.FileHeaderGuid != joinPartsU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (joinPartsU1.UpdEmployeeCode != joinPartsU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (joinPartsU1.UpdAssemblyId1 != joinPartsU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (joinPartsU1.UpdAssemblyId2 != joinPartsU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (joinPartsU1.LogicalDeleteCode != joinPartsU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (joinPartsU1.JoinDispOrder != joinPartsU2.JoinDispOrder) resList.Add("JoinDispOrder");
            if (joinPartsU1.JoinSourceMakerCode != joinPartsU2.JoinSourceMakerCode) resList.Add("JoinSourceMakerCode");
            if (joinPartsU1.JoinSourPartsNoWithH != joinPartsU2.JoinSourPartsNoWithH) resList.Add("JoinSourPartsNoWithH");
            if (joinPartsU1.JoinSourPartsNoNoneH != joinPartsU2.JoinSourPartsNoNoneH) resList.Add("JoinSourPartsNoNoneH");
            if (joinPartsU1.JoinDestMakerCd != joinPartsU2.JoinDestMakerCd) resList.Add("JoinDestMakerCd");
            if (joinPartsU1.JoinDestPartsNo != joinPartsU2.JoinDestPartsNo) resList.Add("JoinDestPartsNo");
            if (joinPartsU1.JoinQty != joinPartsU2.JoinQty) resList.Add("JoinQty");
            if (joinPartsU1.JoinSpecialNote != joinPartsU2.JoinSpecialNote) resList.Add("JoinSpecialNote");
            if (joinPartsU1.EnterpriseName != joinPartsU2.EnterpriseName) resList.Add("EnterpriseName");
            if (joinPartsU1.UpdEmployeeName != joinPartsU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
