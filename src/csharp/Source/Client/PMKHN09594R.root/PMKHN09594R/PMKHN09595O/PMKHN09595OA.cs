//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール情報設定マスタメンテナンス
// プログラム概要   : メール情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/05/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// メール情報設定マスタメンテナンスDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : メール情報設定DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 李占川</br>
	/// <br>Date       : 2010/05/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示

	public interface IMailInfoSettingDB
	{
		/// <summary>
		/// 指定された企業コードのメール情報設定マスタLISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
        /// メール情報設定マスタLISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="retbyte">検索結果</param>
		/// <param name="parabyte">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// 指定された企業コードのメール情報設定マスタLISTを指定件数分全て戻します（論理削除除く）
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
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
        /// 指定されたメール情報設定マスタGuidのメール情報設定マスタを戻します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 指定されたメール情報設定マスタGuidのメール情報設定マスタを戻します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// メール情報設定マスタ情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール情報設定マスタ情報を登録、更新します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// メール情報設定マスタ情報を物理削除します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール情報設定マスタ情報を物理削除します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// メール情報設定マスタ情報を論理削除します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : メール情報設定マスタ情報を論理削除します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// 論理削除メール情報設定マスタ情報を復活します
		/// </summary>
		/// <param name="parabyte">MailSndMngWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 論理削除メール情報設定マスタ情報を復活します</br>
		/// <br>Programmer : 李占川</br>
		/// <br>Date       : 2010/05/24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// メール送信管理LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="mailInfoSettingWork">検索結果</param>
        /// <param name="paraMailInfoSettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/05/24</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09596D", "Broadleaf.Application.Remoting.ParamData.MailInfoSettingWork")]
			out object mailInfoSettingWork,
           object paraMailInfoSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);
    }
}
