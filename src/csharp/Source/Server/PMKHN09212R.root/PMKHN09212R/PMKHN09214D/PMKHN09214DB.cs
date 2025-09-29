using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MergeObjectCondWork
    /// <summary>
    ///                      マージ対象取得条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   マージ対象取得条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MergeObjectCond
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>部品メーカー処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _pMakerFlg;

        /// <summary>車種処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _modelNameFlg;

        /// <summary>商品中分類処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _goodsMGroupFlg;

        /// <summary>BLグループ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _bLGroupFlg;

        /// <summary>BLコード処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _bLFlg;

        /*/// <summary>仕入先マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _supplierFlg;*/

        /// <summary>部位マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _partsPosFlg;

        /// <summary>優良設定変更マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _prmSetChgFlg;

        /// <summary>優良設定マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _prmSetFlg;

        /// <summary>商品マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _goodsUFlg;


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

        /// public propaty name  :  PMakerFlg
        /// <summary>部品メーカー処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカー処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMakerFlg
        {
            get { return _pMakerFlg; }
            set { _pMakerFlg = value; }
        }

        /// public propaty name  :  ModelNameFlg
        /// <summary>車種処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelNameFlg
        {
            get { return _modelNameFlg; }
            set { _modelNameFlg = value; }
        }

        /// public propaty name  :  GoodsMGroupFlg
        /// <summary>商品中分類処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroupFlg
        {
            get { return _goodsMGroupFlg; }
            set { _goodsMGroupFlg = value; }
        }

        /// public propaty name  :  BLGroupFlg
        /// <summary>BLグループ処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループ処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupFlg
        {
            get { return _bLGroupFlg; }
            set { _bLGroupFlg = value; }
        }

        /// public propaty name  :  BLFlg
        /// <summary>BLコード処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLFlg
        {
            get { return _bLFlg; }
            set { _bLFlg = value; }
        }

        /*/// public propaty name  :  SupplierFlg
        /// <summary>仕入先マスタ処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先マスタ処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFlg
        {
            get { return _supplierFlg; }
            set { _supplierFlg = value; }
        }*/

        /// public propaty name  :  PartsPosFlg
        /// <summary>部位マスタ処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部位マスタ処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPosFlg
        {
            get { return _partsPosFlg; }
            set { _partsPosFlg = value; }
        }

        /// public propaty name  :  PrmSetChgFlg
        /// <summary>優良設定変更マスタ処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定変更マスタ処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetChgFlg
        {
            get { return _prmSetChgFlg; }
            set { _prmSetChgFlg = value; }
        }

        /// public propaty name  :  PrmSetFlg
        /// <summary>優良設定マスタ処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部位マスタ処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetFlg
        {
            get { return _prmSetFlg; }
            set { _prmSetFlg = value; }
        }

        /// public propaty name  :  GoodsUFlg
        /// <summary>商品マスタ処理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品マスタ処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsUFlg
        {
            get { return _goodsUFlg; }
            set { _goodsUFlg = value; }
        }


        /// <summary>
        /// マージ対象取得条件ワークコンストラクタ
        /// </summary>
        /// <returns>MergeObjectCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MergeObjectCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MergeObjectCond()
        {
        }

    }

}
