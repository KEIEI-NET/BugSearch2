//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良部品バーコード更新処理
// プログラム概要   : 優良部品バーコード更新条件パラメータワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PrmGoodsBrcdUpdateParamWork
    /// <summary>
    ///                      優良部品バーコード更新条件パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良部品バーコード更新条件パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/09/20</br>
    /// <br>Genarated Date   :   2017/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PrmGoodsBrcdUpdateParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>メーカーコード（開始）</summary>
        private Int32 _makerCdST;

        /// <summary>メーカーコード（終了）</summary>
        private Int32 _makerCdED;

        /// <summary>商品中分類コード</summary>
        private Int32 _goodMGroup;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>レコード件数</summary>
        /// <remarks>処理件数で使用</remarks>
        private Int32 _recordCnt;

        /// <summary>バーコード更新区分</summary>
        private Int32 _barcodeUpdateKndDiv;


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

        /// public propaty name  :  MakerCdST
        /// <summary>メーカーコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCdST
        {
            get { return _makerCdST; }
            set { _makerCdST = value; }
        }

        /// public propaty name  :  MakerCdED
        /// <summary>メーカーコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCdED
        {
            get { return _makerCdED; }
            set { _makerCdED = value; }
        }

        /// public propaty name  :  GoodMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodMGroup
        {
            get { return _goodMGroup; }
            set { _goodMGroup = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
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

        /// public propaty name  :  RecordCnt
        /// <summary>レコード件数プロパティ</summary>
        /// <value>処理件数で使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レコード件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecordCnt
        {
            get { return _recordCnt; }
            set { _recordCnt = value; }
        }

        /// public propaty name  :  BarcodeUpdateKndDiv
        /// <summary>バーコード更新区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バーコード更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BarcodeUpdateKndDiv
        {
            get { return _barcodeUpdateKndDiv; }
            set { _barcodeUpdateKndDiv = value; }
        }


        /// <summary>
        /// 優良部品バーコード更新条件パラメータワークコンストラクタ
        /// </summary>
        /// <returns>PrmGoodsBarCodeRevnUpdateParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmGoodsBarCodeRevnUpdateParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmGoodsBrcdUpdateParamWork()
        {
        }

    }
}