using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Operation
    /// <summary>
    ///                      オペレーションマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   オペレーションマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/07/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class Operation
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>カテゴリコード</summary>
        /// <remarks>0:部品 1:エントリ 2:更新 3:照会 4:帳票 5:マスメン 99:その他</remarks>
        private Int32 _categoryCode;

        /// <summary>カテゴリ名称</summary>
        private string _categoryName = "";

        /// <summary>カテゴリ表示順位</summary>
        private Int32 _categoryDspOdr;

        /// <summary>プログラムＩＤ</summary>
        /// <remarks>カテゴリ設定の場合は String.Empty</remarks>
        private string _pgId = "";

        /// <summary>プログラム名称</summary>
        /// <remarks>全角で管理</remarks>
        private string _pgName = "";

        /// <summary>プログラム表示順位</summary>
        private Int32 _pgDspOdr;

        /// <summary>オペレーションコード</summary>
        /// <remarks>プログラム毎に採番</remarks>
        private Int32 _operationCode;

        /// <summary>オペレーション名称</summary>
        private string _operationName = "";

        /// <summary>オペレーション表示順位</summary>
        private Int32 _operationDspOdr;


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  CategoryCode
        /// <summary>カテゴリコードプロパティ</summary>
        /// <value>0:部品 1:エントリ 2:更新 3:照会 4:帳票 5:マスメン 99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カテゴリコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryCode
        {
            get { return _categoryCode; }
            set { _categoryCode = value; }
        }

        /// public propaty name  :  CategoryName
        /// <summary>カテゴリ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カテゴリ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        /// public propaty name  :  CategoryDspOdr
        /// <summary>カテゴリ表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カテゴリ表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryDspOdr
        {
            get { return _categoryDspOdr; }
            set { _categoryDspOdr = value; }
        }

        /// public propaty name  :  PgId
        /// <summary>プログラムＩＤプロパティ</summary>
        /// <value>カテゴリ設定の場合は String.Empty</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プログラムＩＤプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PgId
        {
            get { return _pgId; }
            set { _pgId = value; }
        }

        /// public propaty name  :  PgName
        /// <summary>プログラム名称プロパティ</summary>
        /// <value>全角で管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プログラム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PgName
        {
            get { return _pgName; }
            set { _pgName = value; }
        }

        /// public propaty name  :  PgDspOdr
        /// <summary>プログラム表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プログラム表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PgDspOdr
        {
            get { return _pgDspOdr; }
            set { _pgDspOdr = value; }
        }

        /// public propaty name  :  OperationCode
        /// <summary>オペレーションコードプロパティ</summary>
        /// <value>プログラム毎に採番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オペレーションコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OperationCode
        {
            get { return _operationCode; }
            set { _operationCode = value; }
        }

        /// public propaty name  :  OperationName
        /// <summary>オペレーション名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オペレーション名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OperationName
        {
            get { return _operationName; }
            set { _operationName = value; }
        }

        /// public propaty name  :  OperationDspOdr
        /// <summary>オペレーション表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オペレーション表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OperationDspOdr
        {
            get { return _operationDspOdr; }
            set { _operationDspOdr = value; }
        }


        /// <summary>
        /// オペレーションマスタコンストラクタ
        /// </summary>
        /// <returns>Operationクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Operationクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Operation()
        {
        }

        /// <summary>
        /// オペレーションマスタコンストラクタ
        /// </summary>
        /// <param name="offerDate">提供日付(YYYYMMDD)</param>
        /// <param name="categoryCode">カテゴリコード(0:部品 1:エントリ 2:更新 3:照会 4:帳票 5:マスメン 99:その他)</param>
        /// <param name="categoryName">カテゴリ名称</param>
        /// <param name="categoryDspOdr">カテゴリ表示順位</param>
        /// <param name="pgId">プログラムＩＤ(カテゴリ設定の場合は String.Empty)</param>
        /// <param name="pgName">プログラム名称(全角で管理)</param>
        /// <param name="pgDspOdr">プログラム表示順位</param>
        /// <param name="operationCode">オペレーションコード(プログラム毎に採番)</param>
        /// <param name="operationName">オペレーション名称</param>
        /// <param name="operationDspOdr">オペレーション表示順位</param>
        /// <returns>Operationクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Operationクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Operation(Int32 offerDate, Int32 categoryCode, string categoryName, Int32 categoryDspOdr, string pgId, string pgName, Int32 pgDspOdr, Int32 operationCode, string operationName, Int32 operationDspOdr)
        {
            this._offerDate = offerDate;
            this._categoryCode = categoryCode;
            this._categoryName = categoryName;
            this._categoryDspOdr = categoryDspOdr;
            this._pgId = pgId;
            this._pgName = pgName;
            this._pgDspOdr = pgDspOdr;
            this._operationCode = operationCode;
            this._operationName = operationName;
            this._operationDspOdr = operationDspOdr;

        }

        /// <summary>
        /// オペレーションマスタ複製処理
        /// </summary>
        /// <returns>Operationクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOperationクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Operation Clone()
        {
            return new Operation(this._offerDate, this._categoryCode, this._categoryName, this._categoryDspOdr, this._pgId, this._pgName, this._pgDspOdr, this._operationCode, this._operationName, this._operationDspOdr);
        }

        /// <summary>
        /// オペレーションマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOperationクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Operationクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(Operation target)
        {
            return ((this.OfferDate == target.OfferDate)
                 && (this.CategoryCode == target.CategoryCode)
                 && (this.CategoryName == target.CategoryName)
                 && (this.CategoryDspOdr == target.CategoryDspOdr)
                 && (this.PgId == target.PgId)
                 && (this.PgName == target.PgName)
                 && (this.PgDspOdr == target.PgDspOdr)
                 && (this.OperationCode == target.OperationCode)
                 && (this.OperationName == target.OperationName)
                 && (this.OperationDspOdr == target.OperationDspOdr));
        }

        /// <summary>
        /// オペレーションマスタ比較処理
        /// </summary>
        /// <param name="operation1">
        ///                    比較するOperationクラスのインスタンス
        /// </param>
        /// <param name="operation2">比較するOperationクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Operationクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(Operation operation1, Operation operation2)
        {
            return ((operation1.OfferDate == operation2.OfferDate)
                 && (operation1.CategoryCode == operation2.CategoryCode)
                 && (operation1.CategoryName == operation2.CategoryName)
                 && (operation1.CategoryDspOdr == operation2.CategoryDspOdr)
                 && (operation1.PgId == operation2.PgId)
                 && (operation1.PgName == operation2.PgName)
                 && (operation1.PgDspOdr == operation2.PgDspOdr)
                 && (operation1.OperationCode == operation2.OperationCode)
                 && (operation1.OperationName == operation2.OperationName)
                 && (operation1.OperationDspOdr == operation2.OperationDspOdr));
        }
        /// <summary>
        /// オペレーションマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のOperationクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Operationクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(Operation target)
        {
            ArrayList resList = new ArrayList();
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.CategoryCode != target.CategoryCode) resList.Add("CategoryCode");
            if (this.CategoryName != target.CategoryName) resList.Add("CategoryName");
            if (this.CategoryDspOdr != target.CategoryDspOdr) resList.Add("CategoryDspOdr");
            if (this.PgId != target.PgId) resList.Add("PgId");
            if (this.PgName != target.PgName) resList.Add("PgName");
            if (this.PgDspOdr != target.PgDspOdr) resList.Add("PgDspOdr");
            if (this.OperationCode != target.OperationCode) resList.Add("OperationCode");
            if (this.OperationName != target.OperationName) resList.Add("OperationName");
            if (this.OperationDspOdr != target.OperationDspOdr) resList.Add("OperationDspOdr");

            return resList;
        }

        /// <summary>
        /// オペレーションマスタ比較処理
        /// </summary>
        /// <param name="operation1">比較するOperationクラスのインスタンス</param>
        /// <param name="operation2">比較するOperationクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   Operationクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(Operation operation1, Operation operation2)
        {
            ArrayList resList = new ArrayList();
            if (operation1.OfferDate != operation2.OfferDate) resList.Add("OfferDate");
            if (operation1.CategoryCode != operation2.CategoryCode) resList.Add("CategoryCode");
            if (operation1.CategoryName != operation2.CategoryName) resList.Add("CategoryName");
            if (operation1.CategoryDspOdr != operation2.CategoryDspOdr) resList.Add("CategoryDspOdr");
            if (operation1.PgId != operation2.PgId) resList.Add("PgId");
            if (operation1.PgName != operation2.PgName) resList.Add("PgName");
            if (operation1.PgDspOdr != operation2.PgDspOdr) resList.Add("PgDspOdr");
            if (operation1.OperationCode != operation2.OperationCode) resList.Add("OperationCode");
            if (operation1.OperationName != operation2.OperationName) resList.Add("OperationName");
            if (operation1.OperationDspOdr != operation2.OperationDspOdr) resList.Add("OperationDspOdr");

            return resList;
        }
    }
}
