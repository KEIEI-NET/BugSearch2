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
    /// public class name:   GoodsParaBWork
    /// <summary>
    ///                      商品パラメータＢワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品パラメータＢワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/01/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsParaBWork
    {
        /// <summary>ファイル名</summary>
        private string _fileName = "";

        /// <summary>セクション名</summary>
        private string _sectionName = "";

        /// <summary>ﾒｰｶｰｺｰﾄﾞ</summary>
        private string _makerCd = "";

        /// <summary>ﾊｲﾌﾝ付品番</summary>
        private string _halfGoodsNp = "";

        /// <summary>変換後BLｺｰﾄﾞ</summary>
        private string _afterBlCd = "";


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

        /// public propaty name  :  halfGoodsNp
        /// <summary>ﾊｲﾌﾝ付品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾊｲﾌﾝ付品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string halfGoodsNp
        {
            get { return _halfGoodsNp; }
            set { _halfGoodsNp = value; }
        }

        /// public propaty name  :  AfterBlCd
        /// <summary>変換後BLｺｰﾄﾞプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後BLｺｰﾄﾞプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfterBlCd
        {
            get { return _afterBlCd; }
            set { _afterBlCd = value; }
        }


        /// <summary>
        /// 商品パラメータＢワークコンストラクタ
        /// </summary>
        /// <returns>GoodsParaBWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsParaBWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsParaBWork()
        {
        }

    }
}
