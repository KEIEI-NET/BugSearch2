using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 従業員DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 従業員DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 96137　山田　圭</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IEmployeeDB
	{
		/// <summary>
		/// 指定された企業コードの従業員LISTの件数を戻します
		/// </summary>
		/// <param name="retCnt">該当データ件数</param>
		/// <param name="parabyte">検索パラメータ</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 指定された企業コードの従業員LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="paraobj">検索パラメータ</param>		
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchCnt(
            out int retCnt,
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			object paraobj, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode
            );
        
        /// <summary>
		/// 指定された企業コードの従業員LISTを全て戻します（論理削除除く）
		/// </summary>
		/// <param name="employeeWork">検索結果</param>
		/// <param name="paraemployeeWork">検索パラメータ</param>
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			out object employeeWork, 
			object paraemployeeWork,
			int readMode,ConstantManagement.LogicalMode logicalMode);
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 指定された企業コードの従業員LISTを指定件数分全て戻します（論理削除除く）
		/// </summary>
		/// <param name="employeeWork">検索結果</param>
		/// <param name="retTotalCnt">検索対象総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="paraemployeeWork">検索パラメータ（NextRead時は前回最終レコードクラス）</param>		
		/// <param name="readMode">検索区分</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="readCnt">検索件数</param>		
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);
		[MustCustomSerialization]
		int SearchSpecification(
			[CustomSerializationMethodParameterAttribute("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			out object employeeWork,
			out int retTotalCnt,out bool nextData,
			object paraemployeeWork, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// 指定された従業員Guidの従業員を戻します
		/// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj,
			int readMode);

		/// <summary>
		/// 従業員情報を登録、更新します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// 従業員情報を登録、更新します
		/// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj
            );

        /// <summary>
		/// 従業員情報を物理削除します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int Delete(byte[] parabyte);

        /// <summary>
        /// 従業員情報を物理削除します
        /// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			object paraobj
            );

        /// <summary>
		/// 従業員情報を論理削除します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int LogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// 従業員情報を論理削除します
        /// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj
            );
        
        /// <summary>
		/// 論理削除従業員情報を復活します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <returns>STATUS</returns>
		int RevivalLogicalDelete(ref byte[] parabyte);
    
        /// <summary>
        /// 論理削除従業員情報を復活します
        /// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj
            );
    }
}
