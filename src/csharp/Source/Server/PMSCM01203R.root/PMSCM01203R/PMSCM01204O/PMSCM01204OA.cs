//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   自動送受信バッチ処理クラス                    //
//                  :   PMSCM01203R.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting                //
// Programmer       :   qianl                                         //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 自動送受信バッチ処理クラスDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 自動送受信バッチ処理クラスDBインターフェースです。</br>
    /// <br>Programmer : qianl</br>
    /// <br>Date       : 2011.07.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISndAndRcvCSVDB
    {
        /// <summary>
        /// 売上データ抽出処理
        /// </summary>
        /// <param name="salesSlipArray">売上データのリスト</param>
        /// <param name="salesDetailArray">売上明細データのリスト</param>
        /// <param name="acceptOdrCarArray">受注マスタ（車両）のリスト</param>
        /// <param name="minUpdateDateTime">送信開始日付</param>
        /// <param name="maxUpdateDateTime">送信終了日付</param>
        /// <param name="startModeCode">モード</param>
        /// <param name="salesDateStart">売上日付From</param>
        /// <param name="salesDateEnd">売上日付To</param>
        /// <param name="addUpADateStart">入力日From</param>
        /// <param name="addUpADateEnd">入力日To</param>
        /// <param name="sectionCodeStart">拠点コードFrom</param>
        /// <param name="sectionCodeEnd">拠点コードTo</param>
        /// <param name="customerCodeStart">得意先コードFrom</param>
        /// <param name="customerCodeEnd">得意先コードTo</param>
        /// <param name="custSlipNoStart">伝票番号From</param>
        /// <param name="custSlipNoEnd">伝票番号To</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="outSalesTotal">出力件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス処理結果(0:成功,9:データ無し,それ以外:テキスト出力エラー)</returns>
        /// <remarks>
        /// <br>Note       : 売上データ抽出処理。</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSCM01205D", "Broadleaf.Application.Remoting.ParamData.SalesSlipWork")]
            ref ArrayList salesSlipArray,
            [CustomSerializationMethodParameterAttribute("PMSCM01205D", "Broadleaf.Application.Remoting.ParamData.SalesDetailWork")]
            ref ArrayList salesDetailArray,
            [CustomSerializationMethodParameterAttribute("PMSCM01205D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref ArrayList acceptOdrCarArray,
            ref Int64 minUpdateDateTime, ref Int64 maxUpdateDateTime, Int32 startModeCode, Int32 salesDateStart, Int32 salesDateEnd,
            Int32 addUpADateStart, Int32 addUpADateEnd, Int32 sectionCodeStart, Int32 sectionCodeEnd, Int32 customerCodeStart, Int32 customerCodeEnd,
          Int32 custSlipNoStart, Int32 custSlipNoEnd, string enterpriseCode, string sectionCode,ref Int32 outSalesTotal, ref string errMsg);

        /// <summary>
        /// マスタ取込処理
        /// </summary>
        /// <param name="tableID">テーブルID</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="deployDataList">デーダList</param>
        /// <param name="errList">エラーList</param>
        /// <param name="result">コンバート結果ワーク</param>
        /// <returns>ステータス処理結果</returns>
        /// <remarks>
        /// <br>Note       : マスタ取込処理</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            string tableID,
            string enterpriseCode,
            CustomSerializeArrayList deployDataList,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref CustomSerializeArrayList errList,
            [CustomSerializationMethodParameter("PMKHN08005D", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork")]
            ref ConvertResultWork result
            );

        /// <summary>
        /// PM7連携送受信履歴ログデータを登録
        /// </summary>
        /// <param name="pM7RkSRHistWork">PM7連携送受信履歴ログデータワーク</param>
        /// <param name="SectionCode">自拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="pM7RkHistCode">PM7連携履歴区分(1：送信　2：受信)</param>
        /// <param name="pM7RkAutoCode">PM7連携自動区分(0：手動　1：自動)</param>
        /// <returns>ステータス処理結果</returns>
        /// <remarks>
        /// <br>Note       : PM7連携送受信履歴ログデータを登録</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        int WritePM7RkSRHistDB(
            PM7RkSRHistWork pM7RkSRHistWork,
            string SectionCode,
            string enterpriseCode,
            int pM7RkHistCode,
            int pM7RkAutoCode);

        /// <summary>
        /// 自動送信履歴データを検索する(マスタ取込処理)
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="pM7RkHistCode">PM7連携履歴区分(1：送信　2：受信)</param>
        /// <param name="rcvFileNm">受信ファイル名称</param>
        /// <param name="returnBL">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 自動送信履歴データを検索する(マスタ取込処理)</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        int SeachRcvFileNm(
            string sectionCode,
            Int32 pM7RkHistCode,
            string rcvFileNm,
            ref bool returnBL);
    }
}