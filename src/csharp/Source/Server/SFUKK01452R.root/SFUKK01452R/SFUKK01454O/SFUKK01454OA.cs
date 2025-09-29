using System;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 入金/引当READDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金/引当READDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 90027　高口　勝</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: 2007.04.06 18322 T.Kimura Search関数にDBコネクションを渡す版を作成</br>
	/// <br></br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

	public interface IDepositReadDB
	{
		#region カスタムシリアライズ

        /// <summary>
        /// 入金/引当READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="depsitDataWork">検索結果</param>
        /// <param name="depositAlwWork">検索結果</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.16</br>
        //--- DEL 2008/06/27 M.Kubota --->>>
        //    int Search(
        //        [CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
        //        out object depsitMainWork,
        ////        [CustomSerializationMethodParameterAttribute("SFUKK01346D","Broadleaf.Application.Remoting.ParamData.DepositAlwWork")]
        //        out object depositAlwWork,
        //        object searchParaDepositRead,
        //        int readMode,
        //        ConstantManagement.LogicalMode logicalMode);
        //--- DEL 2008/06/27 M.Kubota ---<<<
        //--- ADD 2008/06/27 M.Kubota --->>>
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitDataWork")]
            out object depsitDataWork,
            [CustomSerializationMethodParameterAttribute("SFUKK01346D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork")]
            out object depositAlwWork,
            object searchParaDepositRead,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        //--- ADD 2008/06/27 M.Kubota ---<<<

        # region --- DEL 2008/06/27 M.Kubota ---
        //--- UI から SqlConnection を渡す？ 使って無いから削除
# if false
        // ↓ 20070406 18322 a
        /// <summary>
        /// 入金/引当READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="depsitMainWork">検索結果</param>
        /// <param name="depositAlwWork">検索結果</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">DBコネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.04.06</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
            out object depsitMainWork,
            out object depositAlwWork,
            object searchParaDepositRead,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection);
        // ↑ 20070406 18322 a

//		/// <summary>
//		/// 指定された企業コードの入金/引当READを戻します
//		/// </summary>
//		/// <param name="depsitMainWork">DepsitMainWorkオブジェクト</param>
//        /// <param name="depositAlwWork">DepositAlwWorkオブジェクト</param>
//        /// <param name="searchParaDepositRead">検索パラメータ</param>
//        /// <param name="readMode">検索区分</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 指定された企業コードの入金/引当READを戻します</br>
//		/// <br>Programmer : 90027　高口　勝</br>
//		/// <br>Date       : 2005.08.16</br>
//		[MustCustomSerialization]
//		int Read(
//			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
//			ref object depsitMainWork,
//            [CustomSerializationMethodParameterAttribute("SFUKK01346D","Broadleaf.Application.Remoting.ParamData.DepositAlwWork")]
//            ref object depositAlwWork,
//            object searchParaDepositRead,
//            int readMode
//			);
# endif			
        # endregion

        #endregion



        /// <summary>
        /// 入金/引当READLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="DepsitDataWork">検索結果</param>
        /// <param name="DepositAlwWork">検索結果</param>
        /// <param name="searchParaDepositRead">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027　高口　勝</br>
        /// <br>Date       : 2005.08.16</br>
        int Search(out byte[] DepsitDataWork , out byte[] DepositAlwWork , object searchParaDepositRead , int readMode,ConstantManagement.LogicalMode logicalMode);

//		/// <summary>
//		/// 指定された入金/引当READGuidの入金/引当READを戻します
//		/// </summary>
//		/// <param name="DepsitMainWork">DepsitMainWork</param>
//        /// <param name="DepositAlwWork">DepositAlwWork</param>
//        /// <param name="searchParaDepositRead">検索パラメータ</param>
//        /// <param name="readMode">検索区分</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : 指定された入金/引当READGuidの入金/引当READを戻します</br>
//		/// <br>Programmer : 90027　高口　勝</br>
//		/// <br>Date       : 2005.08.16</br>
//		int Read(ref byte[] DepsitMainWork , ref byte[] DepositAlwWork , byte[] searchParaDepositRead , int readMode);

	}
}
