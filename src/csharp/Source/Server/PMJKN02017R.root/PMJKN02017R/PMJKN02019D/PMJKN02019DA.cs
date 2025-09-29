//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ抽出条件クラスワーク
// プログラム概要   : 自由検索部品マスタ抽出条件クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchPartsParaWork
    /// <summary>
    ///                      自由検索部品マスタ抽出条件クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   当月車検車両一覧表抽出条件クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/04/21</br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchPartsParaWork
    {
        # region ■ private field ■
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>車種メーカーコード（開始）</summary>
        private Int32 _carMakerCodeSt;

        /// <summary>車種メーカーコード（終了）</summary>
        private Int32 _carMakerCodeEd;

        /// <summary>車種コード（開始）</summary>
        private Int32 _carModelCodeSt;

        /// <summary>車種コード（終了）</summary>
        private Int32 _carModelCodeEd;

        /// <summary>車種サブコード（開始）</summary>
        private Int32 _carModelSubCodeSt;

        /// <summary>車種サブコード（終了）</summary>
        private Int32 _carModelSubCodeEd;

        /// <summary>型式</summary>
        private string _modelName;

        /// <summary>メーカー開始</summary>
        private Int32 _makerCodeSt;

        /// <summary>メーカー終了</summary>
        private Int32 _makerCodeEd;

        /// <summary>開始BL商品コード</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>終了BL商品コード</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>登録日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _createDateTime;

        /// <summary>登録日（条件）</summary>
        /// <remarks>0:以前,1:以降,2:当日</remarks>
        private Int32 _createDateTimeCode;

        /// <summary>改頁</summary>
        /// <remarks>0:しない 1:車種</remarks>
        private Int32 _newPageDiv;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
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

        /// public propaty name  :  CarMakerCodeSt
        /// <summary>車種メーカーコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種メーカーコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCodeSt
        {
            get { return _carMakerCodeSt; }
            set { _carMakerCodeSt = value; }
        }

        /// public propaty name  :  CarMakerCodeEd
        /// <summary>車種メーカーコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種メーカーコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCodeEd
        {
            get { return _carMakerCodeEd; }
            set { _carMakerCodeEd = value; }
        }

        /// public propaty name  :  CarModelCodeSt
        /// <summary>車種コード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelCodeSt
        {
            get { return _carModelCodeSt; }
            set { _carModelCodeSt = value; }
        }

        /// public propaty name  :  CarModelCodeEd
        /// <summary>車種コード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelCodeEd
        {
            get { return _carModelCodeEd; }
            set { _carModelCodeEd = value; }
        }

        /// public propaty name  :  CarModelSubCodeSt
        /// <summary>車種サブコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelSubCodeSt
        {
            get { return _carModelSubCodeSt; }
            set { _carModelSubCodeSt = value; }
        }

        /// public propaty name  :  CarModelSubCodeEd
        /// <summary>車種サブコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarModelSubCodeEd
        {
            get { return _carModelSubCodeEd; }
            set { _carModelSubCodeEd = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  MakerCodeSt
        /// <summary>メーカー開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCodeSt
        {
            get { return _makerCodeSt; }
            set { _makerCodeSt = value; }
        }

        /// public propaty name  :  MakerCodeEd
        /// <summary>メーカー終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCodeEd
        {
            get { return _makerCodeEd; }
            set { _makerCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>開始BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>終了BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  CreateDateTime
        /// <summary>登録日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeCode
        /// <summary>登録日（条件）プロパティ</summary>
        /// <value>0:以前,1:以降,2:当日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録日（条件）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreateDateTimeCode
        {
            get { return _createDateTimeCode; }
            set { _createDateTimeCode = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>改頁プロパティ</summary>
        /// <value>0:なし 1:車輌</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除指定区分プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>開始削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>終了削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 自由検索部品マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>FreeSearchPartsParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchPartsParaWork()
        {
        }
        # endregion ■ Constructor ■
    }
}
