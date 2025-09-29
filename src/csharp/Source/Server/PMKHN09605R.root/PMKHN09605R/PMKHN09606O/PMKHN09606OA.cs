using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// キャンペーン管理マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : キャンペーン管理マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350　櫻井　亮太</br>
	/// <br>Date       : 2009.05.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignMngDB
	{

		/// <summary>
        /// 指定されたキャンペーン管理マスタGuidのキャンペーン管理マスタを戻します
		/// </summary>
        /// <param name="parabyte">CampaignMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 指定されたキャンペーン管理マスタGuidのキャンペーン管理マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// キャンペーン管理マスタ情報を物理削除します
		/// </summary>
        /// <param name="parabyte">CampaignMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
        /// キャンペーン管理マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
        /// <param name="campaignMngWork">検索結果</param>
        /// <param name="paracampaignMngWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			out object campaignMngWork,
			object paracampaignMngWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// キャンペーン管理マスタ情報を登録、更新します
		/// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngWork
			);

		/// <summary>
        /// キャンペーン管理マスタ情報を論理削除します
		/// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン管理マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngWork
			);

		/// <summary>
        /// 論理削除在キャンペーン管理マスタ情報を復活します
		/// </summary>
        /// <param name="campaignMngWork">CampaignMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : 論理削除キャンペーン管理マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngWork
			);
		#endregion
	}
}
