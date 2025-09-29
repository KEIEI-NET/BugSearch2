using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// RateProtyMngDB リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : RateProtyMngDB リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2007.09.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]

    public interface IRateProtyMngDB
    {
        /// <summary>
        /// 指定された掛率優先管理マスタの情報を返します。
        /// </summary>
        /// <param name="paraByte">シリアライズされた RateProtyMngWork オブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された掛率優先管理マスタの情報を返します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        int Read(ref byte[] paraByte, int readMode);

        /// <summary>
        /// 指定された掛率優先管理マスタの情報を物理削除します。
        /// </summary>
        /// <param name="paraByte">シリアライズされた RateProtyMngWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された掛率優先管理マスタの情報を物理削除します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        int Delete(byte[] paraByte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 検索パラメータに適合する掛率優先管理マスタの全情報を返します。
        /// </summary>
        /// <param name="objRateProtyMngWork">検索結果</param>
        /// <param name="paraRateProtyMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09106D", "Broadleaf.Application.Remoting.ParamData.RateProtyMngWork")]
			out object objRateProtyMngWork,
            object paraRateProtyMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 掛率優先管理マスタに情報を追加又は更新します。
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率優先管理マスタに情報を追加又は更新します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09106D", "Broadleaf.Application.Remoting.ParamData.RateProtyMngWork")]
			ref object objRateProtyMngWork
            );

        /// <summary>
        /// 指定された掛率優先管理マスタの情報を論理削除します。
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された掛率優先管理マスタの情報を論理削除します。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09106D", "Broadleaf.Application.Remoting.ParamData.RateProtyMngWork")]
			ref object objRateProtyMngWork
            );

        /// <summary>
        /// 論理削除されている掛率優先管理マスタの情報を復活させます。
        /// </summary>
        /// <param name="objRateProtyMngWork">RateProtyMngWork オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除されている掛率優先管理マスタの情報を復活させます。</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09106D", "Broadleaf.Application.Remoting.ParamData.RateProtyMngWork")]
			ref object objRateProtyMngWork
            );
        #endregion

    }
}
