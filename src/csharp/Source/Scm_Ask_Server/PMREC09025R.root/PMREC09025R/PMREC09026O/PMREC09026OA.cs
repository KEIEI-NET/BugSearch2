//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品設定マスタメンテ
// プログラム概要   : お買い得商品設定マスタDBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鹿庭 一郎
// 作 成 日  2015/01/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 亘
// 作 成 日  2015/02/23  修正内容 : レイアウト変更対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///  お買い得商品設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買い得商品設定マスタDBインターフェース</br>
    /// <br>Programmer : 鹿庭 一郎</br>
    /// <br>Date       : 2015/01/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    //[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRecBgnGdsDB
    {
        //--- ADD  2015/02/23 佐々木 ----->>>>>

        #region Search：検索処理
        /// <summary>
        /// 購入者向け検索処理。
        /// </summary>
        /// <param name="retobj">RecBgnGdsWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買い得商品設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2015/02/25</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchForBuyer(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
			out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errmsg);

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ：検索処理（論理削除除く）
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork検索結果データリスト</param>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果データリスト</param>
        /// <param name="paraobj">RecBgnGdsPMSearchParaWork検索パラメータ</param>
        /// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
			out object retobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
			out object retCustobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errmsg);

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ：検索処理（論理削除除く）
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork検索結果データリスト</param>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果データリスト</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>結果ステータス</returns>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
			out object retobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
			out object retCustobj,
            string inqOtherEpCd,
            ConstantManagement.LogicalMode logicalMode,
            ref string errMsg);

        #endregion

        #region Write

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタ登録、更新処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork登録データ</param>
        /// <param name="paraCustobj">RecBgnCustPMWork登録データ</param>
        /// <param name="retIsolobj">PmISolPrcWork登録データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタを登録、更新します。</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object paraobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
            ref object paraCustobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.PmIsolPrcWork")]
            ref object retIsolobj
           );

        #endregion

        #region Read

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタ 検索処理
        /// </summary>
        /// <param name="retobj">RecBgnPMWork検索結果リスト</param>
        /// <param name="retCustobj">RecBgnCustPMWork検索結果リスト</param>
        /// <param name="paraobj">RecBgnGdsPMWork検索データ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを検索します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object retobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
            ref object retCustobj,
            object paraobj,
            ref string errMsg);

        #endregion

        #region Delte

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ 完全削除処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを物理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            object paraobj);

        #endregion

        #region RevivalLogicalDelete

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ完全削除・復活処理（リスト処理）
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork削除データリスト</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork復活データリスト</param>
        /// <returns>結果ステータス</returns>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを完全削除、復活します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        [MustCustomSerialization]
        int DeleteAndRevival(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            object paraDelObj,
            ref object paraUpdObj);

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ 復活処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object paraobj);

        #endregion

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタ 完全削除・論理削除・登録・更新処理（リスト処理）
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork削除データリスト</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork登録・更新データリスト</param>
        /// <param name="paraCustUpdObj">RecBgnCustPMWork登録・更新データリスト</param>
        /// <param name="paraIsolUpdObj">PmIsolPrcWork登録・更新データリスト</param>
        /// <param name="errorObj">RecBgnGdsWorkエラーリスト</param>
        /// <returns>結果ステータス</returns>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタ、PM離島価格マスタを完全削除、論理削除、登録・更新します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        [MustCustomSerialization]
        int DeleteAndWrite(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            object paraDelObj,
            ref object paraUpdObj,
            ref object paraCustUpdObj,
            ref object paraIsolUpdObj,
            out object errorObj);

        #region LogicalDelete

        /// <summary>
        /// お買得商品設定マスタ、お買得商品得意先個別設定マスタ論理削除処理
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWorkデータ</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ、お買得商品得意先個別設定マスタを論理削除します</br>
        /// <br>Programmer : 佐々木 亘</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object paraobj);

        #endregion

        //--- DEL  2015/02/23 佐々木 ----->>>>>
        #region レイアウト変更前コメント
        //#region Search：検索処理
        //
        ///// <summary>
        ///// 検索処理（論理削除除く）
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果データリスト</param>
        ///// <param name="paraobj">RecBgnGdsSearchParaWork検索パラメータ</param>
        ///// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="count">件数</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
		//	out object retobj,
        //    object paraobj,
        //    ConstantManagement.LogicalMode logicalMode,
        //    out int count,
        //    ref string errmsg);
        //
        ///// <summary>
        ///// お買い得商品設定マスタ：検索処理（論理削除除く）
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果データリスト</param>
        ///// <param name="inqOtherEpCd">問合せ先企業コード</param>
        ///// <param name="logicalMode">論理削除モード(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>結果ステータス</returns>
        ///// <br>Note       : お買い得商品設定マスタを検索し結果リストを返却します。（論理削除除く）</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //	out object retobj,
        //    string inqOtherEpCd,
        //    ConstantManagement.LogicalMode logicalMode,
        //    ref string errMsg);
        //
        //#endregion
        //
        //#region Write
        //
        ///// <summary>
        ///// お買い得商品設定マスタ登録、更新処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork登録データ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Write(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object paraobj);
        //
        //#endregion
        //
        //#region Read
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 検索処理
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork検索結果リスト</param>
        ///// <param name="paraobj">RecBgnGdsWork検索データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを検索します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Read(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object retobj,
        //    object paraobj,
        //    ref string errMsg);
        //
        //#endregion
        //
        //#region Delte
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを物理削除します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Delete(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    object paraobj);
        //
        //#endregion
        //
        //#region RevivalLogicalDelete
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除・復活処理（リスト処理）
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork削除データリスト</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork復活データリスト</param>
        ///// <returns>結果ステータス</returns>
        ///// <br>Note       : お買い得商品設定マスタを完全削除、復活します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        //[MustCustomSerialization]
        //int DeleteAndRevival(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    object paraDelObj,
        //    ref object paraUpdObj);
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 復活処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int RevivalLogicalDelete(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object paraobj);
        //
        //#endregion
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 完全削除・論理削除・登録・更新処理（リスト処理）
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork削除データリスト</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork登録・更新データリスト</param>
        ///// <param name="errorObj">RecBgnGdsWorkエラーリスト</param>
        ///// <returns>結果ステータス</returns>
        ///// <br>Note       : お買い得商品設定マスタを完全削除、論理削除、登録・更新します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        //[MustCustomSerialization]
        //int DeleteAndWrite(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    object paraDelObj,
        //    ref object paraUpdObj,
        //    out object errorObj);
        //
        //#region LogicalDelete
        //
        ///// <summary>
        ///// お買い得商品設定マスタ 論理削除処理
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWorkデータ</param>
        ///// <returns>結果ステータス</returns>
        ///// <remarks>
        ///// <br>Note       : お買い得商品設定マスタを論理削除します</br>
        ///// <br>Programmer : 鹿庭 一郎</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int LogicalDelete(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object paraobj);
        //
        //#endregion
        //
        #endregion
        //--- DEL  2015/02/23 佐々木 -----<<<<<

    }   
}