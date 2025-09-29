using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ModelNameSet
    /// <summary>
    ///                      車種マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   車種マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class ModelNameSet
    {
        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        private Int32 _modelSubCode;

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>車種半角名称</summary>
        /// <remarks>正式名称（半角で管理）</remarks>
        private string _modelHalfName = "";

        /// <summary>車種呼び名名称</summary>
        /// <remarks>呼び名（発音で管理）</remarks>
        private string _modelAliasName = "";


        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  ModelHalfName
        /// <summary>車種半角名称プロパティ</summary>
        /// <value>正式名称（半角で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種半角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelHalfName
        {
            get { return _modelHalfName; }
            set { _modelHalfName = value; }
        }

        /// public propaty name  :  ModelAliasName
        /// <summary>車種呼び名名称プロパティ</summary>
        /// <value>呼び名（発音で管理）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種呼び名名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelAliasName
        {
            get { return _modelAliasName; }
            set { _modelAliasName = value; }
        }

        /// <summary>
        /// 車種（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameSet Clone()
        {
            return new ModelNameSet(this._makerCode, this._modelCode, this._modelSubCode, this._modelFullName, this._modelHalfName, this._modelAliasName);
        }

        /// <summary>
        /// 車種（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>EmployeeSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ModelNameSet()
        {
        }

        /// <summary>
        /// 車種（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="MakerCode"></param>
        /// <param name="ModelCode"></param>
        /// <param name="ModelSubCode"></param>
        /// <param name="ModelFullName"></param>
        /// <param name="ModelHalfName"></param>
        /// <param name="ModelAliasName"></param>
        public ModelNameSet(Int32 MakerCode, Int32 ModelCode, Int32 ModelSubCode, string ModelFullName, string ModelHalfName, string ModelAliasName)
        {
            this._makerCode = MakerCode;
            this._modelCode = ModelCode;
            this._modelSubCode = ModelSubCode;
            this._modelFullName = ModelFullName;
            this._modelHalfName = ModelHalfName;
            this._modelAliasName = ModelAliasName;
        }
    }
}
