//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換データパラメータ(実行)クラス
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS統合ツール　得意先マスタコード変換データパラメータ(実行)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換データパラメータ(実行)クラスです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class CustomerConvertParamWork
    {
        #region -- Member --

        /// <summary>変更前得意先コード</summary>
        private int bfCustomerCd = 0;
        /// <summary>変更後得意先コード</summary>
        private int afCustomerCd = 0;

        #endregion

        #region -- Property --

        /// <summary>変更前得意先コードプロパティ</summary>
        public int BfCustomerCode
        {
            get { return this.bfCustomerCd; }
            set { this.bfCustomerCd = value; }
        }

        /// <summary>変更後得意先コードプロパティ</summary>
        public int AfCustomerCode
        {
            get { return this.afCustomerCd; }
            set { this.afCustomerCd = value; }
        }

        #endregion
    }
}
