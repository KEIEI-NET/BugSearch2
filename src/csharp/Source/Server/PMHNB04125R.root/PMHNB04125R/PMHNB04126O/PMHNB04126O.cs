using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// 得意先過年度実績照会DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : 得意先過年度実績照会DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 30350 櫻井 亮太</br>
	/// <br>Date       : 2008.10.8</br>
	/// <br></br>
    /// <br>Update Note: 2010/08/02 chenyd</br>
    /// <br>             Excel、テキスト出力対応</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomInqOrderWorkDB
	{
        
        /// <summary>
        /// 得意先過年度実績照会のLISTを全て戻します（論理削除除く）
		/// </summary>
        /// <param name="customInqResultWorkList">検索結果</param>
        /// <param name=" customInqOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
		/// <br>Date       : 2008.10.8</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB04127D", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork")]
			out object customInqResultWorkList,
         object customInqOrderCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        #region SearchAll
        // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
        /// <summary>
        /// 得意先過年度実績照会のLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name=" paraList">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/02</br>
        /// </remarks>
        //[MustCustomSerialization]
        int SearchAll(
			out object retObj,
        object paraList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
        #endregion

    }
}
