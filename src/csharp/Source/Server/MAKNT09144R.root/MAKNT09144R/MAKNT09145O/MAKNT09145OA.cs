using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// HolidaySettingDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : HolidaySettingDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20096　村瀬　勝也</br>
    /// <br>Date       : 2007.01.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface IHolidaySettingDB
    {
        /// <summary>
        /// 指定された休業日設定マスタGuidの休業日設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">HolidaySettingWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された休業日設定マスタGuidの休業日設定マスタを戻します</br>
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 休業日設定マスタを物理削除します
        /// </summary>
        /// <param name="parabyte">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタを物理削除します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        int Delete(byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 休業日設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="HolidaySettingWork">検索結果</param>
        /// <param name="paraHolidaySettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKNT09146D", "Broadleaf.Application.Remoting.ParamData.HolidaySettingWork")]
			out object HolidaySettingWork,
           object paraHolidaySettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);


        /// <summary>
        /// 休業日設定マスタLIST(複数拠点対応版)を全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="HolidaySettingWork">検索結果</param>
        /// <param name="paraHolidaySettingWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int SearchSecList(
            [CustomSerializationMethodParameterAttribute("MAKNT09146D", "Broadleaf.Application.Remoting.ParamData.HolidaySettingWork")]
			out object HolidaySettingWork,
           object paraHolidaySettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 休業日設定マスタを登録、更新します
        /// </summary>
        /// <param name="HolidaySettingWork">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタを登録、更新します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKNT09146D", "Broadleaf.Application.Remoting.ParamData.HolidaySettingWork")]
			ref object HolidaySettingWork
            );

        /// <summary>
        /// 休業日設定マスタを論理削除します
        /// </summary>
        /// <param name="HolidaySettingWork">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 休業日設定マスタを論理削除します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKNT09146D", "Broadleaf.Application.Remoting.ParamData.HolidaySettingWork")]
			ref object HolidaySettingWork
            );

        /// <summary>
        /// 論理削除休業日設定マスタを復活します
        /// </summary>
        /// <param name="HolidaySettingWork">HolidaySettingWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除休業日設定マスタを復活します</br>
        /// <br>Programmer : 20096 村瀬　勝也</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKNT09146D", "Broadleaf.Application.Remoting.ParamData.HolidaySettingWork")]
			ref object HolidaySettingWork
            );
        #endregion

    }
}
