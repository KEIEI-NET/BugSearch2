//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索型式マスタ（印刷） データクラス
// プログラム概要   : 自由検索型式マスタ（印刷） データクラスヘッダファイル
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
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FreeSearchModelPrint
    /// <summary>
    ///                      自由検索型式マスタ（印刷）条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由検索型式マスタ（印刷）条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FreeSearchModelPrint
    {
        # region ■ private field ■
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
        /// 自由検索型式マスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>FreeSearchModelPrintクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchModelPrintクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchModelPrint()
        {
        }
        # endregion ■ Constructor ■
    }
}