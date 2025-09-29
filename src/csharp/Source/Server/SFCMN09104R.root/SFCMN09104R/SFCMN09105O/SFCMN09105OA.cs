using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 番号管理設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 番号管理設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 95016　牟田口　昌彦</br>
	/// <br>Date       : 2005.04.27</br>
	/// <br></br>
    /// <br>Update Note: 2008.05.28 20081 疋田 勇人</br>
    /// <br>           : PM.NS用に変更</br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

	public interface INoMngSetDB
	{
		/// <summary>
		/// 指定された番号管理設定Guidの番号管理設定を戻します
		/// </summary>
		/// <param name="parabyte">NoMngSetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		int ReadNoMngSet(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 番号管理設定情報を登録、更新します
		/// </summary>
		/// <param name="paraobj">NoMngSetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int WriteNoMngSet(
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoMngSetWork")]
			ref object paraobj);

		/// <summary>
		/// 指定された企業コードの番号タイプ管理LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retobj">検索結果</param>
		/// <param name="paraobj">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int SearchNoTypeMng(
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoTypeMngWork")]
			out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された企業コード、番号コードの番号タイプ設定を戻します
		/// </summary>
		/// <param name="parabyte">NoTypeMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		int ReadNoTypeMng(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 指定された企業コード、番号コードの番号タイプ設定を登録、更新します
		/// </summary>
		/// <param name="parabyte">NoTypeMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int WriteNoTypeMng(ref byte[] parabyte);

		/// <summary>
		/// 番号タイプ管理情報を論理削除します
		/// </summary>
		/// <param name="parabyte">NoTypeMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int LogicalDeleteNoTypeMng(ref byte[] parabyte);

		/// <summary>
		/// 論理削除番号タイプ管理情報を復活します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int RevivalLogicalDeleteNoTypeMng(ref byte[] parabyte);

		/// <summary>
		/// 番号タイプ管理情報を物理削除します
		/// </summary>
		/// <param name="parabyte">番号タイプ管理設定オブジェクト</param>
		/// <returns></returns>
		int DeleteNoTypeMng(byte[] parabyte);

        // 2008.05.28 del start -------------------------->>
        ///// <summary>
        ///// 指定された企業コード、番号要素コードの番号要素管理情報を戻します
        ///// </summary>
        ///// <param name="parabyte">NoElmntMngWorkオブジェクト</param>
        ///// <param name="readMode">検索区分</param>
        ///// <returns>STATUS</returns>
        //int ReadNoElmntMng(ref byte[] parabyte , int readMode);
        
        ///// <summary>
        ///// 番号要素管理情報を登録、更新します
        ///// </summary>
        ///// <param name="parabyte">NoElmntMngWorkオブジェクト</param>
        ///// <returns>STATUS</returns>
        //int WriteNoElmntMng(ref byte[] parabyte);
        
        ///// <summary>
        ///// 指定された企業コードの番号管理設定LIST、番号タイプ管理LIST、番号要素管理LISTを全て戻します。
        ///// </summary>
        ///// <param name="retNoMngSet">検索結果（番号管理設定）</param>
        ///// <param name="retNoTypeMng">検索結果（番号タイプ管理）</param>
        ///// <param name="retNoElmntMng">検索結果（番号要素管理）</param> 
        ///// <param name="enterpriseCode">検索パラメータ(企業コード)</param>
        ///// <param name="searchMode">検索区分(0:ALL、1:自動採番有りのデータのみ)</param>
        ///// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <returns>STATUS</returns>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoMngSetWork")]
        //    out object retNoMngSet, 
        //    [CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoTypeMngWork")]
        //    out object retNoTypeMng, 
        //    [CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoElmntMngWork")]
        //    out object retNoElmntMng,                                                                                             
        //    string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode);
        // 2008.05.28 del end ----------------------------<<

		/// <summary>
		/// 指定された企業コードの番号管理設定LIST、番号タイプ管理LIST、番号要素管理LISTを全て戻します。
		/// </summary>
		/// <param name="retNoMngSet">検索結果（番号管理設定）</param>
		/// <param name="retNoTypeMng">検索結果（番号タイプ管理）</param>
		/// <param name="enterpriseCode">検索パラメータ(企業コード)</param>
		/// <param name="searchMode">検索区分(0:ALL、1:自動採番有りのデータのみ)</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoMngSetWork")]
			out object retNoMngSet, 
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoTypeMngWork")]
			out object retNoTypeMng, 
			string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 番号管理設定情報、番号要素管理情報同時書き込み用メソッド
        /// </summary>
        /// <param name="paraNoMngSet">番号管理設定オブジェクト</param>
        /// <param name="paraNoElmntMng">番号要素管理オブジェクト</param>
        /// <returns>STATUS</returns>
        int Write(ref byte[] paraNoMngSet, ref byte[] paraNoElmntMng);
   	}
}
