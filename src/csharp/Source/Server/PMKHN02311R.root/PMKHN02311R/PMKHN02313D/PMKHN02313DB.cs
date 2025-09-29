//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 卸商商品価格改正
// プログラム概要   : 卸商商品価格改正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
       /// public class name:   TrustStockOrderCndtnWork
    /// <summary>
    ///                      卸商商品価格改正抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   卸商商品価格改正抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsInfoCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>ファイル名称</summary>
        private string _fileName;

        /// <summary>更新区分</summary>
        private Int32 _updateType;

        /// <summary>入力件数</summary>
        private Int32 _insertNum;

        /// <summary>更新件数</summary>
        private Int32 _updateNum;

        /// <summary>追加件数</summary>
        private Int32 _addNum;

        /// <summary>警告件数</summary>
        private Int32 _warnNum;

        /// <summary>エラー件数</summary>
        private Int32 _errorNum;


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


        /// public propaty name  :  FileName
        /// <summary>ファイル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  UpdateType
        /// <summary>更新区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateType
        {
            get { return _updateType; }
            set { _updateType = value; }
        }




        /// public propaty name  :  InsertNum
        /// <summary>入力件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InsertNum
        {
            get { return _insertNum; }
            set { _insertNum = value; }
        }


        /// public propaty name  :  UpdateNum
        /// <summary>更新件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateNum
        {
            get { return _updateNum; }
            set { _updateNum = value; }
        }

        /// public propaty name  :  AddNum
        /// <summary>追加件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   追加件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddNum
        {
            get { return _addNum; }
            set { _addNum = value; }
        }


        /// public propaty name  :  WarnNum
        /// <summary>警告件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   警告件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarnNum
        {
            get { return _warnNum; }
            set { _warnNum = value; }
        }



        /// public propaty name  :  ErrorNum
        /// <summary>エラー件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラー件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ErrorNum
        {
            get { return _errorNum; }
            set { _errorNum = value; }
        }

        /// <summary>
        /// 卸商テキスト出力抽出条件クラス
        /// </summary>
        /// <returns>DispatchInstsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   卸商テキスト出力抽出条件クラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsInfoCndtnWork()
        {
        }

    }
}
