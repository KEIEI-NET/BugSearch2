//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ（インポート）
// プログラム概要   : 掛率マスタ（インポート）抽出条件クラス。
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
    /// public class name:   DepsitMainRfImportWorkTbl
    /// <summary>
    ///                      掛率マスタ（インポート）抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率マスタ（インポート）抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class DepsitMainRfImportWorkTbl
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>CSVデータ情報リスト</summary>
        private List<string[]> _csvDataInfoList;

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

        /// public propaty name  :  CsvDataInfoList
        /// <summary>CSVデータ情報リスト</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CSVデータ情報リスト</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string[]> CsvDataInfoList
        {
            get { return _csvDataInfoList; }
            set { _csvDataInfoList = value; }
        }

        /// <summary>
        /// 掛率マスタ（インポート）抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>DepsitMainRfImportWorkTblクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepsitMainRfImportWorkTblクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepsitMainRfImportWorkTbl()
        {
        }
    }
}
