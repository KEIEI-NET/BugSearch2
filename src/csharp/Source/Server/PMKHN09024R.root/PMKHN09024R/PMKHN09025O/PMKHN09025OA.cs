//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタDBインターフェース
//                  :   PMKHN09025O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田　誠
// Date             :   2008.4.24
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタDBインターフェースです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.4.24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISupplierDB
    {
        /// <summary>
        /// 単一の仕入先マスタ情報を取得します。
        /// </summary>
        /// <param name="parabyte">SupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// 仕入先マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SupplierWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する仕入先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 仕入先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outsupplierList">検索結果</param>
        /// <param name="parasupplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する、全ての仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                   out object outsupplierList, object parasupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
        /// <summary>
        /// 仕入先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outsupplierList">検索結果</param>
        /// <param name="parasupplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払先コードが一致する、全ての仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2009.5.27</br>
        [MustCustomSerialization]
        int SearchWithChildren( [CustomSerializationMethodParameterAttribute( "PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork" )]
                   out object outsupplierList, object parasupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

        /// <summary>
        /// 仕入先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="supplierWork">追加・更新する仕入先マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                  ref object supplierWork);

        /// <summary>
        /// 仕入先マスタ情報を論理削除します。
        /// </summary>
        /// <param name="supplierWork">論理削除する仕入先マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                          ref object supplierWork);

        /// <summary>
        /// 仕入先マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="supplierWork">論理削除を解除する仕入先マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09026D","Broadleaf.Application.Remoting.ParamData.SupplierWork")]
                                 ref object supplierWork);
    }
}
