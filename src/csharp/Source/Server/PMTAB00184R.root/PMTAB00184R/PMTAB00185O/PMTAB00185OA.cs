//****************************************************************************//
// システム         ：PM.NS                                                   //
// プログラム名称   ：PMTABアップロード排他制御検索マスタDBRemote  Interface  //
// プログラム概要   ：PMTABアップロード排他制御検索マスタDBRemote  Interface  //
// ---------------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				      //
// ===========================================================================//
// 履歴                                                                       //
// ---------------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 鄭慕鈞                                    //
// 作 成 日  2013/06/24  作成内容 : 新規作成                                  //
// ---------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// PMTABアップロード排他制御検索マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : PMTABアップロード排他制御検索マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 鄭慕鈞 </br>
	/// <br>Date       : 2013/06/24</br>
    /// <br></br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmTabUpldExclsvDB
	{
         /// <summary>
        /// 指定されたPMアップロード排他制御GuidのPMアップロード排他制御を戻します
        /// </summary>
        /// <param name="parabyte">WorkerWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/06/24</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork")]
			ref object parabyte,
            int readMode);

        /// <summary>
        /// アップロード排他制御情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/06/24</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork")]
            ref object paraobj);

        /// <summary>
        /// アップロード排他制御を物理削除します
        /// </summary>
        /// <param name="paraobj">PmTabTtlStSecWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : アップロード排他制御を物理削除します</br>
        /// <br>Programmer : 鄭慕鈞</br>
        /// <br>Date       : 2013/06/24</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork")]
            ref object paraobj);
	}
}
