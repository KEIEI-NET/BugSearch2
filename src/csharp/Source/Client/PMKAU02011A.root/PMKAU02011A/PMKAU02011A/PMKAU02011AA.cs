//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 電子帳簿連携更新処理
// プログラム概要   : 電子帳簿連携更新処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00 作成担当 : 3H 尹安
// 作 成 日  2022/03/18  新規作成
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using ar = DataDynamics.ActiveReports;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    ///  電子帳簿連携更新処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        :  電子帳簿連携更新処理を行う</br>
    /// <br>Programmer	: 3H 尹安</br>
    /// <br>Date		: 2022/03/18</br>
    /// </remarks>
    public class EBooksCooprtUpdateAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public EBooksCooprtUpdateAcs()
        {
            // 取引先リスト出力 アクセスクラス
            if (_denchoDXCustomerExportAcs == null)
            {
                // 取引先リスト出力 アクセスクラス　暗号化
                _denchoDXCustomerExportAcs = new DenchoDXCustomerExportAcs(true);
            }
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static EBooksCooprtUpdateAcs _eBooksCooprtUpdateAcs = null;            // 電子帳簿連携更新処理アクセスクラス
        private static DenchoDXCustomerExportAcs _denchoDXCustomerExportAcs = null;    // 取引先リスト出力 アクセスクラス
        private static FrePrtGuideAcs _frePrtGuideAcs = null;                          // 自由帳票選択ガイドアクセスクラス
        private static FrePrtPSetAcs _frePrtPSetAcs = null;
        private EBooksLinkSetInfo _eBooksLinkSetInfo;
        private static Employee stc_Employee;
        private static Dictionary<string, Int32> _customerItemDic = null;
        /// <summary>出力可能請求書パターン情報XMLファイル名</summary>
        private const string ctXML_DMDPRTPTN_FILE_NAME = "PMKAU02010U_DmdPrtPtnSetting.XML";
        /// <summary>電子帳簿連携サポート設定XMLファイル名</summary>
        private const string ctXML_EBOOKLINK_FILE_NAME = "MAKAU03000U_EbooksLinkSetting.XML";
        /// <summary>インストールディレクトリ</summary>
        private const string ctInstallDirectory = "InstallDirectory";
        /// <summary>インストール レジストリキー</summary>
        private const string ctRegistryKey = @"SOFTWARE\Broadleaf\Product\Partsman";
        /// <summary>インストール レジストリキー</summary>
        private const string ctIniCustomFolderPath = @"eBooks\Customer";
        /// <summary>得意先マスタテキストファイル名</summary>
        private const string ctCustomCsvName = "nN7_CustomerRF";
        #endregion

        #region[電子帳簿連携更新処理 アクセスクラス インスタンス取得処理]
        /// <summary>
        /// 電子帳簿連携更新処理 アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public static EBooksCooprtUpdateAcs GetInstance()
        {
            stc_Employee = null;

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 電子帳簿連携更新処理 アクセスクラス
            if (_eBooksCooprtUpdateAcs == null)
            {
                _eBooksCooprtUpdateAcs = new EBooksCooprtUpdateAcs();
            }

            return _eBooksCooprtUpdateAcs;
        }
        #endregion

        #region 出力可能請求書パターン抽出
        /// <summary>
        /// 出力可能請求書パターン抽出
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 出力可能請求書パターン抽出処理を行い。</br>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public int ExtraDmdPrtPtnData(ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                List<DmdPrtPtnSetInfo> listDmdPrtPtnSetInfo;
                getDmdPrtPtnInfo(out listDmdPrtPtnSetInfo, ref errMsg);
                // 明細請求書伝票をXMLに出力する
                if (string.IsNullOrEmpty(errMsg))
                {
                    DoXmlOutPrc(listDmdPrtPtnSetInfo, ref errMsg);
                }

            }
            catch (Exception ex)
            {
                errMsg = ex.Message.TrimEnd();
                return status;
            }
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion

        #region [出力可能請求書パターン取得]
        /// <summary>
        /// 出力可能請求書パターン取得
        /// </summary>
        /// <param name="errMsg"></param>
        /// <param name="ListDmdPrtPtnSetInfo"></param>       
        private void getDmdPrtPtnInfo(out List<DmdPrtPtnSetInfo> listDmdPrtPtnSetInfo, ref string errMsg)
        {
            const string sCustomNameMk = "ITEM";                    // 個別項目マック
            const int iMeisaiGrpCd = 1220;                          // 明細請求書コード区分
            ArrayList retList = new ArrayList();
            List<FrePrtPSet> listFrePrtPSet = new List<FrePrtPSet>();
            listDmdPrtPtnSetInfo = new List<DmdPrtPtnSetInfo>();

            int[] dataInputSystemArray = new int[] { 0 };           // データ入力システム            
            bool msgDiv = false;                                    // メッセージ区分
            string sControlNm = string.Empty;                       // 項目名
            bool bCustomFlg;                                        // 個別項目存在フラグ

            List<FrePprECnd> frePprECndLs = null;
            List<FrePprSrtO> frePprSrtOLs = null;
            _frePrtPSetAcs = new FrePrtPSetAcs();
            _frePrtGuideAcs = new FrePrtGuideAcs();

            if (_customerItemDic == null) 
            {
                _customerItemDic = new Dictionary<string, int>();
                //  個別項目名：ITEM01～ITEM99
                for (int i = 1; i < 100; i++)
                {
                    _customerItemDic.Add(sCustomNameMk + i.ToString("00"), 0);                    
                }
            }

            try
            {
                // 請求書帳票一覧を取得
                // ①企業コード　②帳票使用区分 ③帳票区分コード(　④データ入力システム配列　⑤読込結果コレクション　⑥メッセージ区分　⑦エラーメッセージ
                int st = _frePrtGuideAcs.SearchFrePrtPSetDLDB(stc_Employee.EnterpriseCode, 5, 0, dataInputSystemArray, out retList, out msgDiv, out errMsg);
                if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 明細請求書伝票リストを取得
                    foreach (FrePrtPSet retPSet in retList)
                    {
                        if (retPSet.FreePrtPprItemGrpCd == iMeisaiGrpCd)
                        {
                            listFrePrtPSet.Add(retPSet);
                        }
                    }

                    // 個別項目存在しないの明細請求書を取得
                    for (int i = 0; i < listFrePrtPSet.Count; i++)
                    {
                        frePprECndLs = null;
                        frePprSrtOLs = null;
                        FrePrtPSet frtpSet = listFrePrtPSet[i];
                        // 印字位置クラスデータを取得
                        st = _frePrtPSetAcs.ReadDBFrePrtPSet(ref frtpSet, out frePprECndLs, out frePprSrtOLs);

                        if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                            (st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                        {
                        }
                        else
                        {
                            errMsg = _frePrtPSetAcs.ErrorMessage;
                            return;
                        }

                        using (MemoryStream stream = new MemoryStream(frtpSet.PrintPosClassData))
                        {
                            // 個別項目存在判断フラグ
                            bCustomFlg = false;
                            // 個別項目存在チェック
                            // ActiveReport上で全て印刷項目を取得
                            ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                            prtRpt.LoadLayout(stream);
                            foreach (DataDynamics.ActiveReports.Section section in prtRpt.Sections)
                            {
                                foreach (ar.ARControl aRControl in section.Controls)
                                {

                                    if (aRControl is ar.TextBox && aRControl.Tag is string)
                                    {
                                        if (aRControl.DataField == null)
                                        {
                                            continue;
                                        }
                                        string dataFieldName = aRControl.DataField.ToUpper();
                                        if (dataFieldName.Contains("CUSTOMIZE"))
                                        {
                                            bCustomFlg = true;
                                            break;
                                        }
                                    }
                                }
                                // 個別項目存在、該当帳票チェック中止
                                if (bCustomFlg) 
                                {
                                    break;
                                }
                            }
                            // 個別項目存在しないの帳票
                            if (!bCustomFlg)
                            {   // 出力可能請求書パターン情報
                                DmdPrtPtnSetInfo dmdPrtPtnSetInfo = new DmdPrtPtnSetInfo();
                                dmdPrtPtnSetInfo.OutputFormFileName = frtpSet.OutputFormFileName;
                                dmdPrtPtnSetInfo.DisplayName = frtpSet.DisplayName;
                                listDmdPrtPtnSetInfo.Add(dmdPrtPtnSetInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message.TrimEnd();
            }
        }
        #endregion

        #region 得意先マスタ(暗号化)エクスポート
        /// <summary>
        /// 得意先マスタ(暗号化)エクスポート
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 得意先マスタト(暗号化)エクスポー処理を行い。</br>
        /// <br>Programmer	: 3H 尹安</br>
        /// <br>Date		: 2022/03/18</br>
        /// </remarks>
        public int ExtraCustomerData(ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            string sOutFileName = ctCustomCsvName + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            try
            {
                // 得意先マスタテキストファイル出力パスを取得
                string sCustomerListOutPath = Path.Combine(GetEBooksFolderPath(), sOutFileName);

                status = _denchoDXCustomerExportAcs.MakeCustomerCSVAll(stc_Employee.EnterpriseCode, sCustomerListOutPath);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message.TrimEnd();
            }
            return status;
        }
        #endregion

        # region[電子帳簿受け渡しフォルダパスを取得]
        /// <summary>
        /// 電子帳簿受け渡しフォルダパスを取得
        /// </summary>
        /// <returns>電子帳簿受け渡しフォルダパス</returns>
        /// <remarks> 
        /// </remarks>
        private string GetEBooksFolderPath()
        {
            string sCustomFoldertPath = string.Empty;
            _eBooksLinkSetInfo = new EBooksLinkSetInfo();

            // 取引先リスト受け渡しフォルダ　デフォルト値
            sCustomFoldertPath = Path.Combine(GetInstallDirectory(), ctIniCustomFolderPath);
            //  電子帳簿連携サポート設定情報XMLファイル存在の判断           
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME)))
            {
                try
                {
                    _eBooksLinkSetInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_EBOOKLINK_FILE_NAME));
                    // 取引先リスト受け渡しフォルダ 設定の場合、
                    if (!string.IsNullOrEmpty(_eBooksLinkSetInfo.CustomFolder))
                    {
                        sCustomFoldertPath = _eBooksLinkSetInfo.CustomFolder;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    return sCustomFoldertPath;
                }
            }

            return sCustomFoldertPath;
        }
        # endregion

        #region[出力可能請求書パターン情報出力]
        /// <summary>
        ///  出力可能請求書パターン情報出力
        /// </summary>
        /// <param name="listDmdPrtPtnSetInfo">出力可能請求書パターン情報</param>
        /// <param name="errMsg">エラーメッセージ</param>
        private void DoXmlOutPrc(List<DmdPrtPtnSetInfo> listDmdPrtPtnSetInfo, ref string errMsg)
        {
            string sXmlOutPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_DMDPRTPTN_FILE_NAME);

            try
            {
                if (listDmdPrtPtnSetInfo.Count == 0) 
                {
                    DmdPrtPtnSetInfo dmdPrtPtnSetInfo = new DmdPrtPtnSetInfo();
                    listDmdPrtPtnSetInfo.Add(dmdPrtPtnSetInfo);
                }
                UserSettingController.SerializeUserSetting(listDmdPrtPtnSetInfo, sXmlOutPath);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }

        }
        #endregion

        #region [PMNSのインストールパス取得]
        /// <summary>
        /// PMNSのインストールパス
        /// </summary>
        private string GetInstallDirectory()
        {
            // クライアント
            string sKeyPath = @String.Format(@ctRegistryKey);
            RegistryKey key = Registry.LocalMachine.OpenSubKey(sKeyPath);
            string directoryPath = "";
            if (key.GetValue(ctInstallDirectory) != null)
            {
                directoryPath = (string)key.GetValue(ctInstallDirectory);
            }
            return directoryPath;
        }
        # endregion

        # region [電子帳簿連携サポート設定情報XML]
        /// <summary>
        /// 電子帳簿連携サポート設定情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class EBooksLinkSetInfo
        {
            /// <summary>
            /// 電子帳簿連携サポート設定情報
            /// </summary>
            public EBooksLinkSetInfo() 
            {

            }

            /// <summary>電子帳簿受け渡しフォルダ</summary>
            private string _eBooksFolder;
            /// <summary>取引先リスト受け渡しフォルダ</summary>
            private string _customFolder;

            /// <summary>電子帳簿受け渡しフォルダ</summary>
            public string EBooksFolder
            {
                get { return _eBooksFolder; }
                set { _eBooksFolder = value; }
            }

            /// <summary>取引先リスト受け渡しフォルダ</summary>
            public string CustomFolder
            {
                get { return _customFolder; }
                set { _customFolder = value; }
            }
        }
        #endregion

        # region [出力可能請求書パターン情報XML]
        /// <summary>
        /// 出力可能請求書パターン情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class DmdPrtPtnSetInfo
        {
            /// <summary>
            /// 出力可能請求書パターン情報
            /// </summary>
            public DmdPrtPtnSetInfo()
            {

            }

            /// <summary>出力ファイル名</summary>
            private string _outputFormFileName;
            /// <summary>出力名称</summary>
            private string _displayName;

            /// <summary>出力ファイル名</summary>
            public string OutputFormFileName
            {
                get { return _outputFormFileName; }
                set { _outputFormFileName = value; }
            }

            /// <summary>出力名称</summary>
            public string DisplayName
            {
                get { return _displayName; }
                set { _displayName = value; }
            }
        }
        #endregion
    }
}
