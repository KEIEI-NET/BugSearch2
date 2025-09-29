using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// メール送信管理設定DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : メール送信管理設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

	public interface IMailSndMngDB
	{
		/// <summary>
		/// 指定された企業コードのメール送信管理設定LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// メール送信管理設定LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// 指定された企業コードのメール送信管理設定LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="parabyte">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
		/// 指定されたメール送信管理設定Guidのメール送信管理設定を戻します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたメール送信管理設定Guidのメール送信管理設定を戻します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// メール送信管理設定情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール送信管理設定情報を登録、更新します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// メール送信管理設定情報を物理削除します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール送信管理設定情報を物理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// メール送信管理設定情報を論理削除します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール送信管理設定情報を論理削除します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除メール送信管理設定情報を復活します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除メール送信管理設定情報を復活します</br>
		/// <br>Programmer : 21015　金巻　芳則</br>
		/// <br>Date       : 2005.03.24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// メール送信管理LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="mailSndMngWork">検索結果</param>
        /// <param name="paramailSndMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2006.06.17</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFDML09066D", "Broadleaf.Application.Remoting.ParamData.MailSndMngWork")]
			out object mailSndMngWork,
            object paramailSndMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);
    }
}
