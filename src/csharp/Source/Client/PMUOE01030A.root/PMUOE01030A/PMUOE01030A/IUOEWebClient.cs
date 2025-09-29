//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Webサーバと送受信する処理インターフェース
// プログラム概要   : Webサーバと送受信する処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE Webクライアントインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note		: Webサーバと送受信する処理インターフェース</br>
    /// <br>Programmer	: 高峰</br>
    /// <br>Date		: 2010/05/07</br>
    /// </remarks>
    public interface IUOEWebClient
    {
        /// <summary>
        /// Webサーバと送受信します。
        /// </summary>
        /// <param name="uoeSendingData">送信電文データ</param>
        /// <param name="isReceivingStock">仕入受信処理フラグ</param>
        /// <param name="uoeReceivedData">受信電文データ</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>処理結果ステータス</returns>
        int SendAndReceive(
            UoeSndHed uoeSendingData,
            bool isReceivingStock,
            out UoeRecHed uoeReceivedData,
            out string errorMessage
        );
    }

    /// <summary>
    /// UOE Webクライアントのファクトリクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE Webクライアントのファクトリクラス</br>
    /// <br>Programmer	: 高峰</br>
    /// <br>Date		: 2010/05/07</br>
    /// </remarks>
    public static class UOEWebClientFactory
    {
        /// <summary>
        /// UOE Webクライアントを生成します。
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        /// <returns>
        /// <c>EnumUoeConst.ctCommAssemblyId_1004</c>の場合、明治産業を返します。
        /// (該当なしの場合、<c>string.Empty</c>を返します)
        /// </returns>
        public static IUOEWebClient Create(UOESupplier uoeSupplier)
        {
            switch (uoeSupplier.CommAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_1004:    //優良メーカー(明治産業)
                    return new MeijiWebClient(uoeSupplier);
                case EnumUoeConst.ctCommAssemblyId_1003:    //優良メーカー(卸NET)
                    return new NetWebClient(uoeSupplier);
                default:
                    throw new ArgumentException("優良UOE Webでは未サポートの通信アセンブリIDです。");
            }
        }
    }
}
