using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MergeCond
    /// <summary>
    ///                      マージ対象取得条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   マージ対象取得条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
    /// </remarks>
    public class MergeCond
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

        // ADD 2009/01/28 機能追加：価格改正、優良設定マスタ ---------->>>>>
        /// <summary>する</summary>
        public const int DOING_FLG_AS_INT = 1;
        /// <summary>しない</summary>
        public const int NOT_DOING_FLG_AS_INT = 0;

        /// <summary>価格改正処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private int _priceRevisionFlg;

        /// <summary>優良設定変更マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private int _prmSetChgFlg;

        /// <summary>優良設定マスタ処理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private int _prmSetFlg;
        // ADD 2008/01/28 機能追加：価格改正、優良設定マスタ ----------<<<<<

        /// <summary>部品メーカー名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _pMakerNmOwFlg;

        /// <summary>車種名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _modelNameNmOwFlg;

        /// <summary>商品中分類名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _goodsMGroupNmOwFlg;

        /// <summary>BLグループ名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _bLGroupNmOwFlg;

        /// <summary>BLコード名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _bLNmOwFlg;

        /// <summary>部位マスタ名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _partsPosNmOwFlg;

        // ADD 2009/01/28 機能追加：価格改正、優良設定マスタ ---------->>>>>
        /// <summary>する</summary>
        public const bool DOING_FLG_AS_BOOL = true;
        /// <summary>しない</summary>
        public const bool NOT_DOING_FLG_AS_BOOL = !DOING_FLG_AS_BOOL;

        /// <summary>価格改正名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _priceRevisionNmOwFlg;

        /// <summary>優良設定変更マスタ名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _prmSetChgNmOwFlg;

        /// <summary>優良設定マスタ名称上書きフラグ</summary>
        /// <remarks>false:しない　true:する</remarks>
        private bool _prmSetNmOwFlg;

        /// <summary>更新対象の基準日付</summary>
        private DateTime _targetDate = DateTime.Now;
        // ADD 2008/01/28 機能追加：価格改正、優良設定マスタ ----------<<<<<

        /// public property name  :  EnterpriseCode
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

        /// public property name  :  PMakerFlg
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

        /// public property name  :  ModelNameFlg
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

        /// public property name  :  GoodsMGroupFlg
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

        /// public property name  :  BLGroupFlg
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

        /// public property name  :  BLFlg
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

        /*/// public property name  :  SupplierFlg
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

        /// public property name  :  PartsPosFlg
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

        // ADD 2009/01/28 機能追加：価格改正、優良設定マスタ ---------->>>>>
        /// <summary>
        /// 価格改正処理区分プロパティ
        /// </summary>
        /// <value>0:しない　1:する</value>
        public int PriceRevisionFlg
        {
            get { return _priceRevisionFlg; }
            set { _priceRevisionFlg = value; }
        }

        /// <summary>
        /// 優良設定変更マスタ処理区分プロパティ
        /// </summary>
        /// <value>0:しない　1:する</value>
        public int PrmSetChgFlg
        {
            get { return _prmSetChgFlg; }
            set { _prmSetChgFlg = value; }
        }

        /// <summary>
        /// 優良設定マスタ処理区分プロパティ
        /// </summary>
        /// <value>0:しない　1:する</value>
        public int PrmSetFlg
        {
            get { return _prmSetFlg; }
            set { _prmSetFlg = value; }
        }
        // ADD 2008/01/28 機能追加：価格改正、優良設定マスタ ----------<<<<<

        /// public property name  :  PMakerNmOwFlg
        /// <summary>部品メーカー名称上書きフラグプロパティ</summary>
        /// <value>false:しない　true:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカー名称上書きフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool PMakerNmOwFlg
        {
            get { return _pMakerNmOwFlg; }
            set { _pMakerNmOwFlg = value; }
        }

        /// public property name  :  ModelNameNmOwFlg
        /// <summary>車種名称名称上書きフラグプロパティ</summary>
        /// <value>false:しない　true:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名称名称上書きフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool ModelNameNmOwFlg
        {
            get { return _modelNameNmOwFlg; }
            set { _modelNameNmOwFlg = value; }
        }

        /// public property name  :  GoodsMGroupNmOwFlg
        /// <summary>商品中分類名称上書きフラグプロパティ</summary>
        /// <value>false:しない　true:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称上書きフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool GoodsMGroupNmOwFlg
        {
            get { return _goodsMGroupNmOwFlg; }
            set { _goodsMGroupNmOwFlg = value; }
        }

        /// public property name  :  BLGroupNmOwFlg
        /// <summary>BLグループ名称上書きフラグプロパティ</summary>
        /// <value>false:しない　true:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループ名称上書きフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool BLGroupNmOwFlg
        {
            get { return _bLGroupNmOwFlg; }
            set { _bLGroupNmOwFlg = value; }
        }

        /// public property name  :  BLNmOwFlg
        /// <summary>BLコード名称上書きフラグプロパティ</summary>
        /// <value>false:しない　true:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード名称上書きフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool BLNmOwFlg
        {
            get { return _bLNmOwFlg; }
            set { _bLNmOwFlg = value; }
        }

        /// public property name  :  PartsPosNmOwFlg
        /// <summary>部位マスタ名称上書きフラグプロパティ</summary>
        /// <value>false:しない　true:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部位マスタ名称上書きフラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool PartsPosNmOwFlg
        {
            get { return _partsPosNmOwFlg; }
            set { _partsPosNmOwFlg = value; }
        }

        // ADD 2009/01/28 機能追加：価格改正、優良設定マスタ ---------->>>>>
        /// <summary>
        /// 価格改正名称上書きフラグプロパティ
        /// </summary>
        /// <value>false:しない　true:する</value>
        public bool PriceRevisionNmOwFlg
        {
            get { return _priceRevisionNmOwFlg; }
            set { _priceRevisionNmOwFlg = value; }
        }

        /// <summary>
        /// 優良設定変更マスタ名称上書きフラグプロパティ
        /// </summary>
        /// <value>false:しない　true:する</value>
        public bool PrmSetChgNmOwFlg
        {
            get { return _prmSetChgNmOwFlg; }
            set { _prmSetChgNmOwFlg = value; }
        }

        /// <summary>
        /// 優良設定マスタ名称上書きフラグプロパティ
        /// </summary>
        /// <value>false:しない　true:する</value>
        public bool PrmSetNmOwFlg
        {
            get { return _prmSetNmOwFlg; }
            set { _prmSetNmOwFlg = value; }
        }

        /// <summary>
        /// 更新対象の基準日付プロパティ
        /// </summary>
        public DateTime TargetDate
        {
            get { return _targetDate; }
            set { _targetDate = value; }
        }
        // ADD 2008/01/28 機能追加：価格改正、優良設定マスタ ----------<<<<<

        /// <summary>
        /// マージ対象取得条件ワークコンストラクタ
        /// </summary>
        /// <returns>MergeObjectCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MergeObjectCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MergeCond()
        {
        }
    }
}
