//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : Webサーバと送受信する処理クラス
// プログラム概要   : Webサーバと送受信する処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 堀田 剛生
// 作 成 日  2012/12/06  修正内容 : 明治産業WEB　アドレス変更対応
//　　　　　　　　　　　　　　　　　①WebReferences参照先を変更
//　　　　　　　　　　　　　　　　　②①に伴う参照フォルダの変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田村顕成
// 作 成 日  2023/01/27  修正内容 : TLS1.2対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.IO;
// 2012/12/06 ↓>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//using Broadleaf.Application.Controller.jp.mesaco.catalog;
using Broadleaf.Application.Controller.jp.mesaco.meijiweb;
// 2012/12/06 ↑>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
using System.Xml;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
// ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------>>>>>
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
// ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 送受信データを変換し、Webサーバと送受信するクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: Webサーバと送受信する処理クラス</br>
    /// <br>Programmer	: 高峰</br>
    /// <br>Date		: 2010/05/07</br>
    /// </remarks>
    public class MeijiWebClient : IUOEWebClient
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private System.Data.DataSet dsRequest;
        private System.Data.DataSet dsResponse;
        private NewDataSet1.InfomationReqTableDataTable _informationReqTableDataTable;
        private NewDataSet1.PartsmanRequestTblDataTable _netSendDataTable;
        private System.Data.DataTable tableinfo;
        private System.Data.DataTable tableresp;
        private UOESupplier _uoeSupplier;
        // ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------>>>>>
        // 証明書検証時のエラー内容(ログ出力は行わない)
        private string strSslPolErrMsg = string.Empty;
        // ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------<<<<<
        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members
        private const int DENBKB_35 = 35;
        private const int DENBKB_45 = 45;
        private const string ERROR_CODE_0 = "0";
        private const string ERROR_CODE_1 = "1";
        private const string ERROR_CODE_2 = "2";
        private const string ERROR_CODE_3 = "3";
        private const string REQUEST_ID = "BBB101";
        private const int DENBKB_60 = 60;
        private const string KUBUN_STOCK = "3";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// Webサーバと送受信する処理クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : Webサーバと送受信する処理クラスの初期化を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        public MeijiWebClient(UOESupplier uoeSupplier)
        {
            this.dsRequest = new NewDataSet1();
            this.dsResponse = new NewDataSet2();
            this._informationReqTableDataTable = ((NewDataSet1)this.dsRequest).InfomationReqTable;
            this._netSendDataTable = ((NewDataSet1)this.dsRequest).PartsmanRequestTbl;
            this._uoeSupplier = uoeSupplier;
        }
        # endregion

        #region IUOEWebClient メンバ

        /// <summary>
        /// Webサーバと送受信します。
        /// </summary>
        /// <param name="uoeSendingData"></param>
        /// <param name="isReceivingStock"></param>
        /// <param name="uoeReceivedData"></param>
        /// <param name="errorMessage"></param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : Webサーバと送受信する処理を行う。</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        public int SendAndReceive(UoeSndHed uoeSendingData, bool isReceivingStock, out UoeRecHed uoeReceivedData, out string errorMessage)
        {
            uoeReceivedData = new UoeRecHed();
            errorMessage = string.Empty;

            // 送信電文データをWebサービス用パラメータに変換する
            ConvertUoeSndHedToDataSet(uoeSendingData, isReceivingStock);
            // Webサービスを呼出す
            int status = WebServiceCall();

            //string errorCode = ((NewDataSet2.InfomationResTableRow)this._informationResTableDataTable.Rows[0]).ErrorCode;

            this.tableinfo = this.dsResponse.Tables["InfomationResTable"];
            this.tableresp = this.dsResponse.Tables["PartsmanResponseTbl"];
            string errorCode = string.Empty;

            if (this.tableinfo.Rows.Count != 0)
            {
                errorCode = (string)tableinfo.Rows[0]["ErrorCode"];
                switch (errorCode)
                {
                    case ERROR_CODE_0: { errorMessage = "正常"; break; }
                    case ERROR_CODE_1: { errorMessage = "I/Fエラー"; break; }
                    case ERROR_CODE_2: { errorMessage = "基幹エラー"; break; }
                }
            }
            else
            {
                errorCode = ERROR_CODE_3;
                errorMessage = "タイムアウトエラー";
            }

            if (errorCode == ERROR_CODE_0)
            {
                // Webサービスからの戻り値を受信電文データに変換する 
                ConvertDataSetToUoeSndHed(uoeSendingData, isReceivingStock, errorCode, out uoeReceivedData);
            }

            return status;
        }

        /// <summary>
        /// 送信電文データをWebサービス用パラメータに変換する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信電文データをWebサービス用パラメータに変換する</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void ConvertUoeSndHedToDataSet(UoeSndHed uoeSendingData, bool isReceivingStock)
        {
            // インフォメーション依頼情報の設定
            SetInformationReqTableDataTable(this._uoeSupplier);
            // 要求情報の設定
            SetNetsendDataTable(uoeSendingData, isReceivingStock);

        }

        /// <summary>
        /// Webサービスを呼出す
        /// </summary>
        /// <remarks>
        /// <br>Note       : Webサービスを呼出す</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// <br>Note       : TLS1.2対応</br>
        /// <br>Programmer : 田村顕成</br>
        /// <br>Date       : 2023/01/27</br>
        /// </remarks>
        private int WebServiceCall()
        {
            MeijiWebApp meijiWebApp = new MeijiWebApp();
            try
            {
                // ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------>>>>>
                // Partsman Product定数定義クラス(PMCMN00500C.dll)からセキュリティプロトコルを取得する。
                ServicePointManager.SecurityProtocol = ConstantManagement_PM_PRO.ScrtyPrtcl;

                // 証明書の検証確認追加
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(
                    Object certsender,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors)
                {
                    //検証は行うがログ出力はしない（証明書のエラーはブラウザ上で判断できるため）
                    return AddServerCertificateValidation(certsender, certificate, chain, sslPolicyErrors, out strSslPolErrMsg);
                });
                // ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------<<<<<
                this.dsResponse = meijiWebApp.GetRequestData(this.dsRequest);
            }
            catch (Exception ex)
            {
                return (int)EnumUoeConst.Status.ct_ERROR;
            }
            return (int)EnumUoeConst.Status.ct_NORMAL;
        }

        // ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------>>>>>
        /// <summary>
        /// 証明書の検証確認追加
        /// </summary>
        /// <param name="certsender">certsender</param>
        /// <param name="certificate">certificate</param>
        /// <param name="chain">chain</param>
        /// <param name="sslPolicyErrors">sslPolicyErrors</param>
        /// <param name="strSslPolErrMsg">strSslPolErrMsg</param>
        /// <remarks>
        /// <br>Note        : 証明書の検証確認を行います。</br>
        /// <br>Programmer  : 田村顕成</br>
        /// <br>Date        : 2023/01/27</br>
        /// </remarks>
        private bool AddServerCertificateValidation(Object certsender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors, out string strSslPolErrMsg)
        {
            strSslPolErrMsg = string.Empty;
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                strSslPolErrMsg = "サーバー証明書の検証に成功しました。";
                return true;
            }
            else
            {
                strSslPolErrMsg = "サーバー証明書の検証に失敗しました。";

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) ==
                    SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    strSslPolErrMsg += "ChainStatusが、空でない配列を返しました。";
                    strSslPolErrMsg += "[";
                    foreach (X509ChainStatus C509CS in chain.ChainStatus)
                    {
                        strSslPolErrMsg += string.Format("{0}:{1} ", C509CS.Status, C509CS.StatusInformation);
                    }
                    strSslPolErrMsg += "]";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) ==
                    SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    strSslPolErrMsg += "証明書名が不一致です。";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) ==
                    SslPolicyErrors.RemoteCertificateNotAvailable)
                {
                    strSslPolErrMsg += "証明書が利用できません。";
                }
                return false;
            }
        }
        // ------ADD 2023/01/27 田村顕成 TLS1.2対応 ------<<<<<

        /// <summary>
        /// Webサービスからの戻り値を受信電文データに変換する
        /// </summary>
        /// <param name="isReceivingStock"></param>
        /// <param name="errorCode"></param>
        /// <param name="uoeReceivedData"></param>
        /// <remarks>
        /// <br>Note       : Webサービスからの戻り値を受信電文データに変換する</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void ConvertDataSetToUoeSndHed(UoeSndHed uoeSendingData, bool isReceivingStock, string errorCode, out UoeRecHed uoeReceivedData)
        {
            uoeReceivedData = new UoeRecHed();
            uoeReceivedData.BusinessCode = uoeSendingData.BusinessCode;
            uoeReceivedData.CommAssemblyId = uoeSendingData.CommAssemblyId;
            uoeReceivedData.UOESupplierCd = uoeSendingData.UOESupplierCd;
            uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();

            UoeRecDtl uoeRecDtl;
            byte[] toByteArray;
            for (int index = 0; index < this.tableresp.Rows.Count; index++)
            {
                System.Data.DataRow netrecvRow = tableresp.Rows[index];
                uoeRecDtl = new UoeRecDtl();

                //卸商仕入受信の場合
                if (isReceivingStock)
                {
                    //最初に空明細の作成「開局と偽る」　
                    if (index == 0)
                    {
                        toByteArray = new byte[256];

                        uoeRecDtl.RecTelegram = toByteArray;
                        uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                        uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);
                        uoeRecDtl = new UoeRecDtl();

                    }

                    //電文区分が「69」は、該当データ無しにする。
                    if ((int)tableresp.Rows[index]["DENBKB"] == 69)
                    {
                        //該当データなしは、[UOESalesOrderNo]へ値をセットしない
                        uoeRecDtl.RecTelegram = ToByteArray(netrecvRow);
                        uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                        uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);
                        break;
                    }
                    else
                    {
                        //該当データの場合は、[UOESalesOrderNo]へ値をセット
                        //対象明細のSend情報の値をセット
                        uoeRecDtl.UOESalesOrderNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderNo;
                        uoeRecDtl.UOESalesOrderRowNo = new List<int>();
                        uoeRecDtl.UOESalesOrderRowNo = uoeSendingData.UoeSndDtlList[1].UOESalesOrderRowNo;
                    }
                }
                else
                {
                    //卸商仕入受信ではない場合
                    //該当データの場合は、[UOESalesOrderNo]へ値をセット
                    uoeRecDtl.UOESalesOrderNo = int.Parse((string)tableresp.Rows[index]["REQNO"]);
                    uoeRecDtl.UOESalesOrderRowNo = new List<int>();
                    uoeRecDtl.UOESalesOrderRowNo.Add((int)tableresp.Rows[index]["REQGYO"]);
                }

                //if ((int)netrecvRow["DENBKB"] == 69)
                //{
                //    uoeReceivedData.UoeRecDtlList = new List<UoeRecDtl>();
                //    break;
                //}

                //UoeRecDtl uoeRecDtl = new UoeRecDtl();
                ////発注番号
                //uoeRecDtl.UOESalesOrderNo = (int)netrecvRow["REQNO"];
                ////発注行番号
                //uoeRecDtl.UOESalesOrderRowNo = new List<int>();
                //uoeRecDtl.UOESalesOrderRowNo.Add((int)netrecvRow["EQGYO"]);

                //送信フラグ
                if (errorCode == ERROR_CODE_0)
                {
                    uoeRecDtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;
                }
                else
                {
                    uoeRecDtl.DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_RcvNG;
                }
                //復旧フラグ
                if (uoeRecDtl.DataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_OK)
                {
                    uoeRecDtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;	//復旧なし
                }
                else
                {
                    uoeRecDtl.DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_YES;	//復旧あり
                }
                //受信電文
                uoeRecDtl.RecTelegram = ToByteArray(netrecvRow);
                uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);

            }

            //卸商仕入受信の場合(ダミー明細の作成「閉局分を偽る」)
            if (isReceivingStock)
            {
                uoeRecDtl = new UoeRecDtl();
                toByteArray = new byte[256];

                uoeRecDtl.RecTelegram = toByteArray;
                uoeRecDtl.RecTelegramLen = uoeRecDtl.RecTelegram.Length;
                uoeReceivedData.UoeRecDtlList.Add(uoeRecDtl);
            }

        }

        /// <summary>
        /// インフォメーション依頼情報の設定
        /// </summary>
        /// <param name="uoeSupplier">ＵＯＥ発注先マスタクラス</param>
        /// <remarks>
        /// <br>Note       : インフォメーション依頼情報の設定</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void SetInformationReqTableDataTable(UOESupplier uoeSupplier)
        {
            NewDataSet1.InfomationReqTableRow informationReqRow = this._informationReqTableDataTable.NewInfomationReqTableRow();

            informationReqRow.RequestID = REQUEST_ID;
            informationReqRow.EigyousyoFlag = uoeSupplier.InqOrdDivCd.ToString();
            informationReqRow.JigyousyoCode = uoeSupplier.UOELoginUrl;
            informationReqRow.CoCode = uoeSupplier.UOEForcedTermUrl;
            informationReqRow.TerminalID = uoeSupplier.EPartsUserId;
            informationReqRow.Password = uoeSupplier.EPartsPassWord;
            informationReqRow.EigyousyoCode = uoeSupplier.UOEItemCd;
            informationReqRow.ESystemUseType = uoeSupplier.UOETestMode;

            this._informationReqTableDataTable.AddInfomationReqTableRow(informationReqRow);
        }

        /// <summary>
        /// 要求情報の設定
        /// </summary>
        /// <param name="uoeSendingData">ＵＯＥ受信ヘッダークラス</param>
        /// <remarks>
        /// <br>Note       : 要求情報の設定</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// </remarks>
        private void SetNetsendDataTable(UoeSndHed uoeSendingData, bool isReceivingStock)
        {
            int j = 1;
            //int k = 1;
            // 開局電文の発注区分
            string kubun = null;
            //foreach(UoeSndDtl uoeSndDtl in uoeSendingData.UoeSndDtlList) {
            for (int index = 0; index < uoeSendingData.UoeSndDtlList.Count; index++)
            {

                UoeSndDtl uoeSndDtl = uoeSendingData.UoeSndDtlList[index];

                if (index == 0)
                {
                    byte[] kaiTelegram = uoeSndDtl.SndTelegram;
                    UoeCommonFnc.MemCopy(ref kubun, ref kaiTelegram, 36, 1);
                }

                // 仕入受信処理である
                if (isReceivingStock && index != 0) 
                {
                    byte[] sndTelegram = uoeSndDtl.SndTelegram;

                    NewDataSet1.PartsmanRequestTblRow netsendRow = this._netSendDataTable.NewPartsmanRequestTblRow();
                    // 電文区分→電文区分
                    // 電文区分に“６０”を固定でセットし、他の項目は何もセット致しません
                    netsendRow.DENBKB = DENBKB_60;
                    netsendRow.GYONO = 0;  // 行番号
                    netsendRow.REQNO = 0;  // 電文問合番号
                    netsendRow.REQGYO = 0; // 伝票用行番号
                    netsendRow.HNSBT = 0;  // 部品種別
                    netsendRow.JYUSU = 0;  // 数量
                    this._netSendDataTable.AddPartsmanRequestTblRow(netsendRow);
                }

                if (index != 0 && index != uoeSendingData.UoeSndDtlList.Count - 1)
                {
                    byte[] sndTelegram = uoeSndDtl.SndTelegram;
                    string readStr = null;

                    // 仕入受信処理ではない
                    if (!isReceivingStock)
                    {
                        UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, 15, 1);
                        int detailCount = int.Parse(readStr);
                        for (int m = 1; m <= detailCount; m++)
                        {
                            int i = 0;
                            NewDataSet1.PartsmanRequestTblRow netsendRow = this._netSendDataTable.NewPartsmanRequestTblRow();
                            // 発注
                            if (uoeSendingData.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                            {
                                netsendRow.DENBKB = DENBKB_35;
                            }
                            // 在庫
                            else
                            {
                                netsendRow.DENBKB = DENBKB_45;
                            }
                            i = i + 1;

                            //// 電文区分→電文区分
                            //readStr = null;
                            //UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            //netsendRow.DENBKB = int.Parse(readStr);
                            //i = i + 1;

                            // 開局電文の発注区分→処理区分
                            //readStr = null;
                            //UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            netsendRow.KUBUN = kubun;
                            //// 手入力（緊急）発注
                            //if (readStr = (int)EnumUoeConst.ctSystemDivCd.ct_Input || readStr = (int)EnumUoeConst.ctSystemDivCd.ct_Search:)
                            //{
                            //    netsendRow.KUBUN = 1;
                            //// 伝発発注
                            //} else if (readStr =(int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                            //{
                            //    netsendRow.KUBUN = 9;
                            //// 在庫一括発注
                            //} else
                            //{
                            //    netsendRow.KUBUN = 3;
                            //}
                            i = i + 1;
                            // 行番号
                            //UoeCommonFnc.MemCopy(netsendRow.DENBKB, uoeSndDtl.SndTelegram, i, 7);
                            netsendRow.GYONO = j;
                            j++;
                            i = i + 7;
                            // 電文問合せ番号→電文問合せ番号
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 6);
                            netsendRow.REQNO = int.Parse(readStr);
                            //netsendRow.REQNO = k;
                            i = i + 6;
                            // 送信部品数→伝票用行番号
                            //readStr = null;
                            //UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            //netsendRow.REQGYO = int.Parse(readStr);
                            netsendRow.REQGYO = m;
                            i = i + 1;
                            // リマーク（備考）→リマーク（備考）
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                            netsendRow.REMARK = readStr;
                            i = i + 10;
                            // 納品区分→納品区分
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            netsendRow.NHNKB = readStr;
                            i = i + 1;
                            // 部品種別 1:国産部品を設定（固定）
                            netsendRow.HNSBT = 1;
                            i = i + 5 + (m - 1) * 43;
                            // 部品番号～ラインリマーク（備考）TODO
                            // 電文の部品番号→部品番号
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 20);
                            netsendRow.JYUHNNO = readStr;
                            i = i + 20;
                            // 電文のメーカーコード→メーカーコード
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 4);
                            netsendRow.MKCD = readStr;
                            i = i + 8;
                            // 電文の数量→数量
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 3);
                            netsendRow.JYUSU = int.Parse(readStr);
                            i = i + 3;
                            // 電文のＢ／Ｏ区分→Ｂ／Ｏ区分
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 1);
                            netsendRow.BOKB = readStr;
                            i = i + 2;
                            // 電文のチェックコード→ラインリマーク（備考）
                            readStr = null;
                            UoeCommonFnc.MemCopy(ref readStr, ref sndTelegram, i, 10);
                            netsendRow.CHKCD = readStr;
                            i = i + 10;

                            this._netSendDataTable.AddPartsmanRequestTblRow(netsendRow);
                        }

                    }
                    //k++;
                }
            }
        }

        /// <summary>
        /// バイト型配列に変換
        /// </summary>
        /// <returns>バイト型配列</returns>
        /// <remarks>
        /// <br>Note       : バイト型配列に変換</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2010/05/07</br>
        /// <br>Programmer : 堀田</br>
        /// <br>Date       : 2010/06/08</br>
        /// </remarks>
        public byte[] ToByteArray(System.Data.DataRow netrecvRow)
        {
            byte[] toByteArray = new byte[256];
            UoeCommonFnc.MemSet(ref toByteArray, 0x20, toByteArray.Length);
            byte[] byteArr = null;

            // Webサービス戻り値の電文区分→受信電文データの電文区分
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["DENBKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 0);

            // Webサービス戻り値の処理区分→受信電文データの処理区分
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["KUBUN"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 1);

            // Webサービス戻り値の処理結果→受信電文データの処理結果
            byteArr = new byte[2];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["RESULT"].ToString().PadLeft(2, '0'), 2);
            byteArr.CopyTo(toByteArray, 2);

            // Webサービス戻り値の電文問合せ番号→受信電文データの電文問合せ番号
            byteArr = new byte[6];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQNO"].ToString().PadLeft(6, '0'), 6);
            byteArr.CopyTo(toByteArray, 4);

            // Webサービス戻り値の伝票用行番号→受信電文データの回答電文対応行数
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REQGYO"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 10);

            // Webサービス戻り値のリマーク（備考）→受信電文データのリマーク（備考）
            byteArr = new byte[10];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["REMARK"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 11);

            // Webサービス戻り値の納品区分→受信電文データの納品区分
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["NHNKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 21);

            // Webサービス戻り値の受注部品番号→受信電文データの受注部品番号
            byteArr = new byte[20];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 25);

            // Webサービス戻り値の出荷部品番号→受信電文データの出荷部品番号
            byteArr = new byte[20];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUHNNO"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 45);

            // Webサービス戻り値のメーカーコード→受信電文データのメーカーコード
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["MKCD"].ToString().PadLeft(4, '0'), 4);
            byteArr.CopyTo(toByteArray, 65);

            // Webサービス戻り値の受付日付→受信電文データの分類コード
            byteArr = new byte[4];
            UoeCommonFnc.MemCopy(ref byteArr, TDateTime.LongDateToDateTime((Int32)netrecvRow["UKEYMD"]).ToString("yyyyMMdd").Substring(4, 4), 4);
            byteArr.CopyTo(toByteArray, 69);

            // Webサービス戻り値の品名→受信電文データの品名
            byteArr = new byte[20];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["HINNM"].ToString(), 20);
            byteArr.CopyTo(toByteArray, 73);

            // Webサービス戻り値の定価→受信電文データの定価
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SHOTIK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 93);

            // Webサービス戻り値の仕切単価→受信電文データの仕切単価
            byteArr = new byte[7];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SKRTNK"].ToString().PadLeft(7, '0'), 7);
            byteArr.CopyTo(toByteArray, 100);

            // Webサービス戻り値の受注数→受信電文データの受注数
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["JYUSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 107);

            // Webサービス戻り値の出庫数→受信電文データの出庫数
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 110);

            // Webサービス戻り値のＢ／Ｏ区分→受信電文データのＢ／Ｏ区分
            byteArr = new byte[1];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOKB"].ToString(), 1);
            byteArr.CopyTo(toByteArray, 113);

            // 予備コード
            byteArr = new byte[1];
            string prepareCode = string.Empty;
            if ((int)netrecvRow["HNSBT"] == 9)
            {
                prepareCode = "1";
            }
            else
            {
                prepareCode = "0";
            }
            UoeCommonFnc.MemCopy(ref byteArr, prepareCode, 1);
            byteArr.CopyTo(toByteArray, 114);

            // Webサービス戻り値のＢ／Ｏ数→受信電文データのＢ／Ｏ数
            byteArr = new byte[3];
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOSU"].ToString().PadLeft(3, '0'), 3);
            byteArr.CopyTo(toByteArray, 115);

            // Webサービス戻り値の出荷伝票番号→受信電文データの出荷伝票番号
            byteArr = new byte[6];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            if ((int)netrecvRow["SYUNO"] == 0)
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            else
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["SYUNO"].ToString(), 6);
            }
            byteArr.CopyTo(toByteArray, 118);

            // Webサービス戻り値のＢ／Ｏ受付番号→受信電文データのＢ／Ｏ受付番号
            byteArr = new byte[6];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            if ((int)netrecvRow["BOUKENO"] == 0)
            {
                UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            }
            else
            {
                UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["BOUKENO"].ToString(), 6);
            }
            byteArr.CopyTo(toByteArray, 124);

            // Webサービス戻り値のラインメッセージ→受信電文データのラインエラー
            byteArr = new byte[15];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["LINERR"].ToString(), 15);
            byteArr.CopyTo(toByteArray, 130);

            // Webサービス戻り値のラインマーク（備考）→受信電文データのチェックコード
            byteArr = new byte[10];
            // 2010/06/08 >>>
            UoeCommonFnc.MemSet(ref byteArr, 0x20, byteArr.Length);
            // 2010/06/08 >>>
            UoeCommonFnc.MemCopy(ref byteArr, netrecvRow["CHKCD"].ToString(), 10);
            byteArr.CopyTo(toByteArray, 145);

            return toByteArray;
        }

        # endregion

    }
}