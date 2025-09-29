//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＢＬコード層別変換処理
// プログラム概要   : ＢＬコード層別変換処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/01/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :
// 修 正 日              修正内容 :
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExcellentSetParaBWork
    /// <summary>
    ///                      優良設定パラメータＢワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良設定パラメータＢワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/01/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExcellentSetParaBWork
    {
        /// <summary>ファイル名</summary>
        private string _fileName = "";

        /// <summary>セクション名</summary>
        private string _sectionName = "";

        /// <summary>変換前BLｺｰﾄﾞ</summary>
        private string _beforeBlCd = "";

        /// <summary>変換後ｾﾚｸﾄｺｰﾄﾞ</summary>
        private string _afterSelectCd = "";

        /// <summary>変換前ｾﾚｸﾄｺｰﾄﾞ</summary>
        private string _beforeSelectCd = "";

        /// <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
        private string _makerCd = "";


        /// public propaty name  :  FileName
        /// <summary>ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイル名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>セクション名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セクション名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  BeforeBlCd
        /// <summary>変換前BLｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換前BLｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BeforeBlCd
        {
            get { return _beforeBlCd; }
            set { _beforeBlCd = value; }
        }

        /// public propaty name  :  AfterSelectCd
        /// <summary>変換後ｾﾚｸﾄｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後ｾﾚｸﾄｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfterSelectCd
        {
            get { return _afterSelectCd; }
            set { _afterSelectCd = value; }
        }

        /// public propaty name  :  BeforeSelectCd
        /// <summary>変換前ｾﾚｸﾄｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換前ｾﾚｸﾄｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BeforeSelectCd
        {
            get { return _beforeSelectCd; }
            set { _beforeSelectCd = value; }
        }

        /// public propaty name  :  MakerCd
        /// <summary>ﾒｰｶｰｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerCd
        {
            get { return _makerCd; }
            set { _makerCd = value; }
        }


        /// <summary>
        /// 優良設定パラメータＢワークコンストラクタ
        /// </summary>
        /// <returns>ExcellentSetParaBWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ExcellentSetParaBWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ExcellentSetParaBWork()
        {
        }

    }
}
