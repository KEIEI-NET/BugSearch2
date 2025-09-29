using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// PM従業員DB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : PM従業員DB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 22011　Kashihara</br>
	/// <br>Date       : 2013.05.28</br>
    /// <br>Note       : 質問一覧_PM-TAB No.48</br>
    /// <br>Programmer : 鄭慕鈞</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Note       : ソースチェック確認事項一覧にNo.32</br>
    /// <br>Programmer : 鄭慕鈞</br>
    /// <br>Date       : 2013/06/17</br>
    /// <br>Note       : №10663 #43465 タブレット担当者対応</br>
    /// <br>Programmer : 吉岡 孝憲</br>
    /// <br>Date       : 2014/10/03</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]		//←アプリケーションサーバーの接続先を属性で指示
	public interface IPMEmployeeDB
	{
		/// <summary>
		/// 指定されたPM従業員GuidのPM従業員を戻します
		/// </summary>
		/// <param name="parabyte">WorkerWorkオブジェクト</param>
		/// <param name="readMode">検索区分</param>
		/// <returns>STATUS</returns>
		int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 指定されたPM従業員GuidのPM従業員を戻します
        /// </summary>
        /// <param name="parabyte">WorkerWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object parabyte,
            int readMode);

        /// <summary>
        /// 従業員情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">WorkerWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        int Write(ref object paraobj);

        //---DEL 鄭慕鈞 2013/06/17 ソースチェック確認事項一覧にNo.32の対応--->>>>>
        ////--ADD 鄭慕鈞 2013/06/11 質問一覧_PM-TAB No.48--->>>>>
        ///// <summary>
        ///// 指定された条件の拠点情報LISTを全て戻します
        ///// </summary>
        ///// <param name="parabyte">WorkerWorkオブジェクト</param>
        ///// <param name="searchPara">検索条件</param>
        ///// <param name="readMode">検索区分</param>
        ///// <param name="logicalMode">論理削除区分</param>
        ///// <returns>STATUS</returns>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("SFTOK09394D", "Broadleaf.Application.Remoting.ParamData.PMEmployeeWork")]
        //    out object parabyte,
        //    PMEmployeeWork searchPara,
        //    int readMode,
        //    ConstantManagement.LogicalMode logicalMode);
        ////--ADD 鄭慕鈞 2013/06/11 質問一覧_PM-TAB No.48---<<<<<
        //---DEL 鄭慕鈞 2013/06/17 ソースチェック確認事項一覧にNo.32の対応--->>>>>

        //---ADD 鄭慕鈞 2013/06/17 ソースチェック確認事項一覧にNo.9の対応--->>>>>
        /// <summary>
        /// PMTAB従業員検索結果情報を追加・更新します。
        /// </summary>
        /// <param name="pmTabEmployeeWorkList">追加・更新するPMTAB従業員検索結果情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB従業員検索結果情報を追加・更新します。</br>
        /// <br>Programmer : 鄭慕鈞 </br>
        /// <br>Date       : 2013.05.29</br>
        [MustCustomSerialization]
        int WriteForTablet(
            [CustomSerializationMethodParameterAttribute("SFTOK09394D", "Broadleaf.Application.Remoting.ParamData.PMEmployeeWork")]
            ref object pmTabEmployeeWorkList);
        //---ADD 鄭慕鈞 2013/06/17 ソースチェック確認事項一覧にNo.32の対応--->>>>>

        // ADD 2014/10/03 №10663 #43465 タブレット担当者対応 ---------------------------->>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 指定された条件の従業員LISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB従業員検索結果情報を検索します。</br>
        [MustCustomSerialization]
        int SearchForTablet(
            [CustomSerializationMethodParameterAttribute("SFTOK09394D", "Broadleaf.Application.Remoting.ParamData.PMEmployeeWork")]
			out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode);
        // ADD 2014/10/03 №10663 #43465 タブレット担当者対応 ----------------------------<<<<<<<<<<<<<<<<<<<<<<<<
    }
}