//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）モデル
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.UIData {

    /// <summary>
    /// プリンタ設定マスタ（サーバ用）データセット
    /// </summary>
    partial class ServerPrinterSettingDataSet
    {
        #region <プリンタ種別>

        /// <summary>
        /// プリンタ種別列挙型
        /// </summary>
        public enum PrinterKind : int
        {
            /// <summary>レーザープリンタ</summary>
            LaserPrinter = 0,
            /// <summary>ドットプリンタ</summary>
            DotPrinter = 1
        }

        /// <summary>
        /// プリンタ種別名のリストを取得します。
        /// </summary>
        /// <returns>
        /// [0]:レーザープリンタ
        /// [1]:ドットプリンタ
        /// </returns>
        public static List<string> GetPrinterKindNameList()
        {
            List<string> printerKindNameList = new List<string>();
            {
                printerKindNameList.Add(GetPrinterKindName((int)PrinterKind.LaserPrinter));
                printerKindNameList.Add(GetPrinterKindName((int)PrinterKind.DotPrinter));
            }
            return printerKindNameList;
        }

        /// <summary>
        /// プリンタ種別名を取得します。
        /// </summary>
        /// <param name="printerKind">プリンタ種別</param>
        /// <returns>
        /// <c>0</c>:レーザープリンタ<br/>
        /// <c>1</c>:ドットプリンタ
        /// </returns>
        public static string GetPrinterKindName(int printerKind)
        {
            switch (printerKind)
            {
                case (int)PrinterKind.LaserPrinter:
                    return "レーザープリンタ";  // LITERAL:
                case (int)PrinterKind.DotPrinter:
                    return "ドットプリンタ";    // LITERAL:
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// プリンタ種別を取得します。
        /// </summary>
        /// <param name="printerKindName">プリンタ種別名</param>
        /// <returns>該当するプリンタ種別 ※該当する種別がない場合、レーザープリンタを返します。</returns>
        public static int GetPrinterKind(string printerKindName)
        {
            if (string.IsNullOrEmpty(printerKindName)) return (int)PrinterKind.LaserPrinter;

            int foundIndex = GetPrinterKindNameList().FindIndex(
                delegate(string kindName)
                {
                    return printerKindName.Trim().Equals(kindName);
                }
            );
            return foundIndex >= 0 ? foundIndex : (int)PrinterKind.LaserPrinter;
        }

        #endregion // </プリンタ種別>

        /// <summary>
        /// プリンタ設定データを追加します。
        /// </summary>
        /// <param name="prtManage">プリンタ設定データ</param>
        public void AddPrtManage(PrtManage prtManage)
        {
            this.SrvPrtSt.AddSrvPrtStRow(
                prtManage.CreateDateTime,
                prtManage.UpdateDateTime,
                prtManage.EnterpriseCode,
                prtManage.FileHeaderGuid,
                prtManage.UpdEmployeeCode,
                prtManage.UpdAssemblyId1,
                prtManage.UpdAssemblyId2,
                prtManage.LogicalDeleteCode,
                prtManage.PrinterMngNo,
                prtManage.PrinterName,
                prtManage.PrinterPort,
                prtManage.PrinterKind,
                EntityUtil.GetDeletedDateIf(prtManage, prtManage.UpdateDateTimeJpInFormal.Trim()),
                GetPrinterKindName(prtManage.PrinterKind)
            );
        }
    }
}
