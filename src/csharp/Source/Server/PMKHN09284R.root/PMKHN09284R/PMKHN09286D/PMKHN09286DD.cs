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
    /// public class name:   GoodsParaAWork
    /// <summary>
    ///                      商品パラメータＡワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品パラメータＡワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/01/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsParaAWork
    {
        /// <summary>ファイル名</summary>
        private string _fileName = "";

        /// <summary>セクション名</summary>
        private string _sectionName = "";

        /// <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
        private string _makerCd = "";

        /// <summary>変換前BLｺｰﾄﾞ</summary>
        private string _beforeBlCd = "";

        /// <summary>頭品番</summary>
        private string _topGoodsNo = "";

        /// <summary>変換後層別</summary>
        private string _afterLevel = "";

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

        /// public propaty name  :  TopGoodsNo
        /// <summary>頭品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   頭品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TopGoodsNo
        {
            get { return _topGoodsNo; }
            set { _topGoodsNo = value; }
        }

        /// public propaty name  :  AfterLevel
        /// <summary>変換後層別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後層別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfterLevel
        {
            get { return _afterLevel; }
            set { _afterLevel = value; }
        }


        /// <summary>
        /// 商品パラメータＡワークコンストラクタ
        /// </summary>
        /// <returns>GoodsParaAWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsParaAWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsParaAWork()
        {
        }

    }
}
