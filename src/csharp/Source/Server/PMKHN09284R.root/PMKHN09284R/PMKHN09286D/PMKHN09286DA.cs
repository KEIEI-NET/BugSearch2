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
    /// public class name:   RateParaAWork
    /// <summary>
    ///                      掛率パラメータＡワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   掛率パラメータＡワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/01/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RateParaAWork
    {
        /// <summary>ファイル名</summary>
        private string _fileName = "";

        /// <summary>セクション名</summary>
        private string _sectionName = "";

        /// <summary>変換前BLｺｰﾄﾞ</summary>
        private string _beforeBlCd = "";

        /// <summary>ﾒｰｶｰｺｰﾄﾞﾘｽﾄ</summary>
        private ArrayList _makerList = null;

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

        /// public propaty name  :  MakerList
        /// <summary>ﾒｰｶｰｺｰﾄﾞﾘｽﾄプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ﾒｰｶｰｺｰﾄﾞﾘｽﾄプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList MakerList
        {
            get
            {
                if (_makerList == null)
                    _makerList = new ArrayList();
                return _makerList;
            }
            set { _makerList = value; }
        }


        /// <summary>
        /// 掛率パラメータＡワークコンストラクタ
        /// </summary>
        /// <returns>RateParaAWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RateParaAWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RateParaAWork()
        {
        }

    }
}
