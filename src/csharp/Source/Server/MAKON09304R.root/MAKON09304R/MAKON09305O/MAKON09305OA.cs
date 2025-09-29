using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入金額処理区分設定マスタDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入金額処理区分設定マスタDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2006.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)] // アプリケーションの接続先を属性で指定
    public interface IStockProcMoneyDB
    {
        /// <summary>
        /// 指定された仕入金額処理区分設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockProcMoneyWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された仕入金額処理区分設定マスタ戻りデータGuidの仕入金額処理区分設定マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// 仕入金額処理区分設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="stockProcMoneyWork">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKON09306D", "Broadleaf.Application.Remoting.ParamData.StockProcMoneyWork")]
			ref object stockProcMoneyWork
            );


        /// <summary>
        /// 仕入金額処理区分設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// 仕入金額処理区分設定マスタデータLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKON09306D", "Broadleaf.Application.Remoting.ParamData.StockProcMoneyWork")]
			out object retList,
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 仕入金額処理区分設定マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入金額処理区分設定マスタを論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKON09306D", "Broadleaf.Application.Remoting.ParamData.StockProcMoneyWork")]
			ref object paraObj
            );

        /// <summary>
        /// 論理削除仕入金額処理区分設定マスタを復活します
        /// </summary>
        /// <param name="paraObj">StockProcMoneyWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除仕入金額処理区分設定マスタを復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2006.12.12</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKON09306D", "Broadleaf.Application.Remoting.ParamData.StockProcMoneyWork")]
			ref object paraObj
            );
    }
}
