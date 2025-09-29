using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 商品別売上目標設定マスタDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品別売上目標設定マスタDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 20036　斉藤　雅明</br>
	/// <br>Date       : 2007.04.16</br>
    /// <br></br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>             障害改良対応１２月</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGcdSalesTargetDB
	{

		/// <summary>
		/// 指定された商品別売上目標設定マスタGuidの商品別売上目標設定マスタを戻します
		/// </summary>
		/// <param name="parabyte">GcdSalesTargetWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定された商品別売上目標設定マスタGuidの商品別売上目標設定マスタを戻します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.16</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 商品別売上目標設定マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">GcdSalesTargetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品別売上目標設定マスタ情報を物理削除します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.16</br>
		int Delete(byte[] parabyte);

		#region カスタムシリアライズ対応メソッド
		/// <summary>
		/// 商品別売上目標設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
		/// </summary>
		/// <param name="gcdsalestargetWork">検索結果</param>
		/// <param name="paragcdsalestargetWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.16</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			out object gcdsalestargetWork,
			object paragcdsalestargetWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 商品別売上目標設定マスタ情報を登録、更新します
		/// </summary>
		/// <param name="gcdsalestargetWork">GcdSalesTargetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品別売上目標設定マスタ情報を登録、更新します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.16</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			ref object gcdsalestargetWork
			);

		/// <summary>
		/// 商品別売上目標設定マスタ情報を論理削除します
		/// </summary>
		/// <param name="gcdsalestargetWork">GcdSalesTargetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 商品別売上目標設定マスタ情報を論理削除します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			ref object gcdsalestargetWork
			);

		/// <summary>
		/// 論理削除商品別売上目標設定マスタ情報を復活します
		/// </summary>
		/// <param name="gcdsalestargetWork">GcdSalesTargetWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除商品別売上目標設定マスタ情報を復活します</br>
		/// <br>Programmer : 20036　斉藤　雅明</br>
		/// <br>Date       : 2007.04.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAMOK09136D","Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
			ref object gcdsalestargetWork
			);
		#endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// 商品別売上目標設定マスタ情報を更新します
        /// </summary>
        /// <param name="gcdsalestargetWork">GcdSalesTargetWorkオブジェクト(write用)</param>
        /// <param name="parabyte">GcdSalesTargetWorkオブジェクト(delete用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品別売上目標設定マスタ情報を更新します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        [MustCustomSerialization]
        int WriteProc(
            [CustomSerializationMethodParameterAttribute("MAMOK09136D", "Broadleaf.Application.Remoting.ParamData.GcdSalesTargetWork")]
            ref object gcdsalestargetWork,
            byte[] parabyte
            );
        #endregion
        // ---ADD 2010/12/20---------<<<<<
	}
}
