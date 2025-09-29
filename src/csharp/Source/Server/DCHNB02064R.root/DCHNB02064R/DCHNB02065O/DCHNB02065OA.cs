using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 出荷商品順位表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出荷商品順位表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応</br>
    /// <br>           : 23015 森本 大輝</br>
    /// <br>           : 2008.08.25</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IShipmGoodsOdrReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 出荷商品順位表データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="shipmGoodsOdrReportResultWork">検索結果</param>
        /// <param name="shipmGoodsOdrReportParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.11.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCHNB02066D", "Broadleaf.Application.Remoting.ParamData.ShipmGoodsOdrReportResultWork")]
			out object shipmGoodsOdrReportResultWork,
         object shipmGoodsOdrReportParamWork);
        #endregion
    }
}
