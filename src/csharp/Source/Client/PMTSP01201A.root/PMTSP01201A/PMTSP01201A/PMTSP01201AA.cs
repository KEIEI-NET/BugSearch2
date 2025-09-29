//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP.NSデータ作成部品アクセスクラス
// プログラム概要   : TSP.NSデータ作成部品アクセスクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 呉元嘯
// 作 成 日  2020/12/21  修正内容 : PMKOBETSU-4097 TSPインライン機能追加対応
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Windows.Forms;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Security.Cryptography;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TSP.NSデータ作成部品アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP.NSデータ作成部品アクセスクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/11/20</br>
    /// <br>Update Note: 2020/12/21 呉元嘯</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// </remarks>
    public class WriteTspSdRvDataAcs
    {
        # region
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "TspSend_UserSetting.XML";
        /// <summary>TSP伝票ファイル名</summary>
        private const string TspSdRvDtName = "TspSdRvDt{0}.XML";
        /// <summary>TSP明細ファイル名</summary>
        private const string TspSdRvDtlName = "TspSdRvDtl{0}.XML";
        // パス設定
        private TspSndPathInfo PathData;
        // 送信データファイルパス
        private string TspTrashPath;
        // 送信データファイルパス
        private string TspSendPath;
        // 一時ﾌｧｲﾙﾊﾟｽ
        private string TspTmpPath;
        // TSP伝票ファイル
        private TspSdRvDt TspSdRvDt;
        // TSP明細ファイル
        private List<TspSdRvDtl> TspSdRvDtlList = new List<TspSdRvDtl>();
        // 通信回数
        private int TspCommCountTemp = 0;
        // 共通通番を採番
        private ITspSdRvDataDB TspSdRvDataDB;
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタです。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public WriteTspSdRvDataAcs()
        {
            this.TspSdRvDataDB = (ITspSdRvDataDB)MediationTspSdRvDataDB.GetTspSdRvDataDB();
        }
        # endregion

        # region
        /// <summary>
        /// XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞのパスを取得する
        /// </summary>
        /// <remarks>
        /// <br>Note       : XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞのパスを取得する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool XmlRead()
        {
            PathData = new TspSndPathInfo();
            if (UserSettingController.ExistUserSetting(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    PathData = UserSettingController.DeserializeUserSetting<TspSndPathInfo>(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                    return true;
                }
                catch (Exception ex)
                {
                    LogWrite("XmlRead()", ex.ToString());
                    return false;
                }
            }
            else
            {
                LogWrite("XmlRead()", "設定ファイル存在しない、処理中止する。");
                return false;
            }
        }

        /// <summary>
        /// 削除の場合、送信データ移動処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞのパスを取得する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public bool MoveTspSdRvData(int customerCode, string salesSlipNum)
        {
            try
            {
                // XMLよりパスを取得する
                if (!this.XmlRead()) return false;
                // ﾌｫﾙﾀﾞ作成
                if (!CreateDirMain(customerCode, salesSlipNum,0)) return false;
                
                // 送信データ移動処理
                if (!DeleteProc()) return false;

                // TSP明細データ削除処理
                TspDtlWork paraTspDtlWork = new TspDtlWork();
                paraTspDtlWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;;
                paraTspDtlWork.AcptAnOdrStatus = 30;
                paraTspDtlWork.SalesSlipNum = salesSlipNum;
                int status = TspSdRvDataDB.Delete((object)paraTspDtlWork);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    LogWrite("MoveTspSdRvData()", "TSP明細データ削除処理に失敗しました。");
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWrite("MoveTspSdRvData()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// ﾌｧｲﾙの作成
        /// </summary>
        /// <param name="paraList">売上伝票情報</param>
        /// <param name="tspMode">0:削除、1:新規、2:更新</param>
        /// <param name="tspCprtStList">TSP連携マスタ設定情報</param>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞのパスを取得する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// <br>Update Note: 2020/12/21 呉元嘯</br>
        /// <br>管理番号   : 11670305-00</br>
        /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
        /// </remarks>
        // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
        //public bool GetTspSdRvData(CustomSerializeArrayList paraList, int tspMode, ArrayList tspCprtStList)
        public bool GetTspSdRvData(CustomSerializeArrayList paraList, int tspMode, ArrayList tspCprtStList, out bool dataFlg)
        // ---UPD 呉元嘯 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        {
            dataFlg = false;// ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 
            try
            {
                if (paraList.Count > 0)
                {
                    // XMLよりパスを取得する
                    if (!this.XmlRead()) return false;
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        SalesSlipWork salesSlip = new SalesSlipWork();
                        ArrayList salesDetailList = new ArrayList();
                        AddUpOrgSalesDetailWork addUpOrgDetailWork = new AddUpOrgSalesDetailWork();
                        ArrayList acceptOdrCarList = new ArrayList();
                        bool tspFlg = false;
                        int acceptAnOrderNo = 0;
                        AcceptOdrCarWork acceptOdrCarWork = new AcceptOdrCarWork();
                        if ((object)paraList[i] is CustomSerializeArrayList)
                        {
                            CustomSerializeArrayList list = (CustomSerializeArrayList)paraList[i];
                            foreach (object obj in list)
                            {
                                if (obj is SalesSlipWork)
                                {
                                    salesSlip = (SalesSlipWork)obj;
                                    if (salesSlip.AcptAnOdrStatus != 30)
                                    {
                                        break;
                                    }
                                }
                                else if (obj is ArrayList && ((ArrayList)obj).Count > 0)
                                {
                                    ArrayList al = (ArrayList)obj;
                                    if (al[0] is AcceptOdrCarWork)
                                    {
                                        acceptOdrCarList = (ArrayList)obj;
                                    }
                                    else if (al[0] is AddUpOrgSalesDetailWork)
                                    {
                                        addUpOrgDetailWork = (AddUpOrgSalesDetailWork)((ArrayList)obj)[0];
                                    }
                                    else if (al[0] is SalesDetailWork)
                                    {
                                        salesDetailList = (ArrayList)obj;
                                        foreach (SalesDetailWork salesDetail in salesDetailList)
                                        {
                                            // 値引/注釈は無視
                                            if (salesDetail.SalesSlipCdDtl == 0 || salesDetail.SalesSlipCdDtl == 1)
                                            {
                                                tspFlg = true;
                                            }
                                            if (salesDetail.SalesRowNo == 1)
                                            {
                                                acceptAnOrderNo = salesDetail.AcceptAnOrderNo;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
                        //if (salesSlip.AcptAnOdrStatus == 30 && salesDetailList.Count > 0 && !salesSlip.PartySaleSlipNum.Equals(string.Empty))
                        if (salesSlip.AcptAnOdrStatus == 30 && salesDetailList.Count > 0 && !salesSlip.PartySaleSlipNum.Equals(string.Empty) && tspFlg)
                        // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------<<<<
                        {
                            // ---DEL 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
                            ////TSP送信データなし
                            //if (!tspFlg)
                            //{
                            //    LogWrite("GetTspSdRvData()", "TSP送信データがない。");
                            //    return false;
                            //}
                            // ---DEL 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------<<<<
                            string sfEnterpriseCode = string.Empty;
                            bool tspCustomerCode = false;
                            // 得意先コードが設定するの判断
                            foreach (TspCprtStWork tspWork in tspCprtStList)
                            {
                                if (tspWork.CustomerCode != salesSlip.CustomerCode)
                                {
                                    continue;
                                }
                                tspCustomerCode = true;
                                sfEnterpriseCode = tspWork.SendEnterpriseCode;

                            }
                            // 得意先コードが設定するの場合
                            if (tspCustomerCode)
                            {
                                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                long commonSeqNo = 0;
                                // 1:新規
                                if (tspMode == 1)
                                {
                                    status = this.TspSdRvDataDB.GetTspCommonSeqNo(salesSlip.EnterpriseCode, salesSlip.SectionCode, out commonSeqNo);
                                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        LogWrite("GetTspSdRvData()", "TSPオンライン番号採番の処理に失敗しました。");
                                        return false;
                                    }
                                }
                                // 更新
                                else if (tspMode == 2)
                                {
                                    object tspDtlWorkList;
                                    TspDtlWork paraTspDtlWork = new TspDtlWork();
                                    paraTspDtlWork.EnterpriseCode = salesSlip.EnterpriseCode;
                                    paraTspDtlWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus;
                                    paraTspDtlWork.SalesSlipNum = salesSlip.SalesSlipNum;
                                    status = this.TspSdRvDataDB.Search(paraTspDtlWork, out tspDtlWorkList);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        status = this.TspSdRvDataDB.GetTspCommonSeqNo(salesSlip.EnterpriseCode, salesSlip.SectionCode, out commonSeqNo);
                                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            LogWrite("GetTspSdRvData()", "TSPオンライン番号採番の処理に失敗しました。");
                                            return false;
                                        }
                                    }
                                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        foreach (TspDtlWork tspDtlWork in (ArrayList)tspDtlWorkList)
                                        {
                                            commonSeqNo = tspDtlWork.TspOnlineNo;// TSP通信番号
                                        }
                                    }
                                    else
                                    {
                                        LogWrite("GetTspSdRvData()", "TSP明細データ取得処理に失敗しました。");
                                        return false;
                                    }
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    foreach (AcceptOdrCarWork acceptOdrCar in acceptOdrCarList)
                                    {
                                        if (acceptOdrCar.AcceptAnOrderNo == acceptAnOrderNo)
                                        {
                                            acceptOdrCarWork = acceptOdrCar;
                                        }
                                    }
                                    // 更新対象チェック処理
                                    if (!CheckProc(salesDetailList)) return false;
                                    // ﾌｫﾙﾀﾞ作成
                                    if (!CreateDirMain(salesSlip.CustomerCode, salesSlip.SalesSlipNum, tspMode)) return false;
                                    // 通信回数の決定
                                    this.TspCommCountTemp = 0;
                                    for (int j = 0; j < 100; j++)
                                    {
                                        if (this.TspCommCountTemp == 99) break;
                                        string xmlName = Path.Combine(this.TspSendPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                                        if (!File.Exists(xmlName))
                                        {
                                            break;
                                        }
                                        this.TspCommCountTemp++;
                                    }
                                    // 送信データ作成処理
                                    if (salesSlip.LogicalDeleteCode != 1)
                                    { 
                                        // TSP明細データ登録処理
                                        if (!WriteTspDtl(salesDetailList, commonSeqNo)) return false;
                                        // TSP伝票ﾌｧｲﾙの作成
                                        if (!GetTspSdRvDt(salesSlip, acceptOdrCarWork, addUpOrgDetailWork, commonSeqNo, sfEnterpriseCode)) return false;
                                        // TSP明細ﾌｧｲﾙの作成
                                        if (!GetTspSdRvDtl(salesSlip, salesDetailList, addUpOrgDetailWork, commonSeqNo, sfEnterpriseCode)) return false;
                                        // TSP伝票ファイルシリアライズ処理(一時)
                                        if (!this.Serialize()) return false;
                                        // TSP伝票ファイルシリアライズ処理(一時)
                                        if (!this.SerializeDtl()) return false;
                                        // ファイル暗号化
                                        if (!Encrypt()) return false;
                                    }
                                    // 送信データ削除処理
                                    else
                                    {
                                        if (!DeleteProc()) return false;
                                    }
                                    dataFlg = true;// ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応
                                }
                                else
                                {
                                    LogWrite("GetTspSdRvData()", "TSPオンライン番号採番が失敗しました。");
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWrite("GetTspSdRvData()", ex.ToString());
                return false;
            }

            return true;
            
        }

        /// <summary>
        ///  TSP明細データ登録処理
        /// </summary>
        /// <param name="salesDetailList">売上伝票明細データ</param>
        /// <param name="commonSeqNo">TSPオンライン番号</param>
        /// <returns></returns>
        private bool WriteTspDtl(ArrayList salesDetailList, long commonSeqNo)
        {
            ArrayList tspDtlList = new ArrayList();
            object tspDtlObj;
            foreach (SalesDetailWork salesDetail in salesDetailList)
            {
                // TSP明細データ作成
                TspDtlWork tspDtl = new TspDtlWork();
                tspDtl.EnterpriseCode = salesDetail.EnterpriseCode;
                tspDtl.SalesSlipNum = salesDetail.SalesSlipNum;
                tspDtl.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum;
                tspDtl.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus;
                tspDtl.TspOnlineNo = Convert.ToInt32(commonSeqNo);
                tspDtl.TspOnlineRowNo = salesDetail.SalesRowNo;
                tspDtlList.Add(tspDtl);
            }
            tspDtlObj = (object)tspDtlList;
            // TSP明細データ登録
            int status = TspSdRvDataDB.Write(ref tspDtlObj);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWrite("WriteTspDtl()", "TSP明細データ登録処理に失敗しました。");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 更新対象チェック処理
        /// </summary>
        /// <param name="salesDetailList">売上伝票明細データ</param>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : 更新対象チェック処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool CheckProc(ArrayList salesDetailList)
        {
            try
            {
                foreach (SalesDetailWork salesDetail in salesDetailList)
                {
                    // 行値引/注釈は無視
                    if (salesDetail.SalesSlipCdDtl == 2 || salesDetail.SalesSlipCdDtl == 3)
                    {
                        continue;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogWrite("CheckProc()", ex.ToString());
                return false;
            }
            return false;
        }

        /// <summary>
        /// ﾌｫﾙﾀﾞ作成
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="mode">0:削除、1:新規、2:更新</param>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞを作成する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool CreateDirMain(int customerCode, string salesSlipNum, int mode)
        {
            try
            {
                // TSP-SENDﾌｫﾙﾀﾞの作成
                if (this.PathData.TspSndPath.Trim().Equals(string.Empty) || this.PathData.TspSndTmpPath.Trim().Equals(string.Empty))
                    return false;
                this.TspSendPath = Path.Combine(this.PathData.TspSndPath.Trim(), "TSP-SEND");
                if (!CreateDir(this.TspSendPath)) return false;

                // 削除用用ﾌｫﾙﾀﾞの作成① TSP-SEND\TRASH
                this.TspTrashPath = Path.Combine(this.TspSendPath, "TRASH");
                if (!CreateDir(this.TspTrashPath)) return false;
                //---<< 送信用ﾌｫﾙﾀﾞの作成 >>---//
                // 送信用ﾌｫﾙﾀﾞの作成① TSP-SEND\(得意先)
                this.TspSendPath = Path.Combine(this.TspSendPath, customerCode.ToString().PadLeft(8, '0'));
                if (!CreateDir(this.TspSendPath)) return false;

                // 削除用ﾌｫﾙﾀﾞの作成
                if (mode == 0 || mode == 1)
                {
                    // 削除用ﾌｫﾙﾀﾞの作成② TSP-SEND\TRASH\(得意先)
                    this.TspTrashPath = Path.Combine(this.TspTrashPath, customerCode.ToString().PadLeft(8, '0'));
                    if (!CreateDir(this.TspTrashPath)) return false;

                    // 削除用ﾌｫﾙﾀﾞの作成③ TSP-SEND\TRASH\(得意先)\(伝票番号)
                    this.TspTrashPath = Path.Combine(this.TspTrashPath, salesSlipNum.ToString().PadLeft(9, '0'));
                }

                // 送信用ﾌｫﾙﾀﾞの作成② TSP-SEND\(得意先)\(伝票番号)
                this.TspSendPath = Path.Combine(this.TspSendPath, salesSlipNum.ToString().PadLeft(9, '0'));

                // 新規作成時はﾌｫﾙﾀﾞを一旦削除する
                if (mode == 1)
                {
                    if (!DeleteDir(this.TspTrashPath)) return false;
                    if (!DeleteDir(this.TspSendPath)) return false;
                    if (!CreateDir(this.TspSendPath)) return false;
                }
                else
                {
                    // ﾌｫﾙﾀﾞ作成
                    if (!CreateDir(this.TspSendPath)) return false;
                    if (this.TspTrashPath != string.Empty && !CreateDir(this.TspTrashPath)) return false;
                }

                // 一時ﾌｧｲﾙﾊﾟｽ
                this.TspTmpPath = this.PathData.TspSndTmpPath;
                if (!CreateDir(this.TspTmpPath)) return false;
            }
            catch (Exception ex)
            {
                LogWrite("CreateDirMain()", "フォルダパス：" + this.TspSendPath + "," + ex.ToString());
                return false;
            }

            return true;
            
        }

        /// <summary>
        /// ﾌｫﾙﾀﾞ作成
        /// </summary>
        /// <param name="sPath">パス</param>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞを作成する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool CreateDir(string sPath)
        {
            if (!Directory.Exists(sPath))
            {
                try
                {
                    Directory.CreateDirectory(sPath);
                }
                catch(Exception ex)
                {
                    LogWrite("CreateDir()", "フォルダパス" + sPath + "," + ex.ToString());
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ﾌｫﾙﾀﾞ削除
        /// </summary>
        /// <param name="sPath">パス</param>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : XMLﾌｧｲﾙ管理ﾌｫﾙﾀﾞを削除する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool DeleteDir(string sPath)
        {
            DirectoryInfo dir = new DirectoryInfo(sPath);
            try
            {
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        child.Delete(true);
                    }
                    dir.Delete(true);
                }
            }
            catch (Exception ex)
            {
                LogWrite("DeleteDir()", "フォルダパス" + sPath + "," + ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP伝票ﾌｧｲﾙの作成
        /// </summary>
        /// <param name="salesSlip">売上伝票データ</param>
        /// <param name="acceptOdrCarWork">受注マスタ（車両）</param>
        /// <param name="addUpOrgDetailWork"> 計上元明細データ</param>
        /// <param name="commonSeqNo">TSPオンライン番号</param>
        /// <param name="sfEnterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : TSP伝票ﾌｧｲﾙを作成する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool GetTspSdRvDt(SalesSlipWork salesSlip, AcceptOdrCarWork acceptOdrCarWork, AddUpOrgSalesDetailWork addUpOrgDetailWork, long commonSeqNo, string sfEnterpriseCode)
        {
            try
            {
                this.TspSdRvDt = new TspSdRvDt();
                this.TspSdRvDt.CreateDateTime = "0001-01-01T00:00:00";// 作成日時
                this.TspSdRvDt.UpdateDateTime = "0001-01-01T00:00:00"; // 更新日時
                this.TspSdRvDt.EnterpriseCode = EditItem(sfEnterpriseCode.Trim());// 企業コード
                this.TspSdRvDt.EnterpriseName = string.Empty;// 企業名
                this.TspSdRvDt.FileHeaderGuid = "00000000-0000-0000-0000-000000000000";// GUID
                this.TspSdRvDt.UpdEmployeeCode = string.Empty;// 更新従業員コード
                this.TspSdRvDt.UpdEmployeeName = string.Empty;// 更新従業員名
                this.TspSdRvDt.UpdAssemblyId1 = string.Empty;// 更新アセンブリID1
                this.TspSdRvDt.UpdAssemblyId2 = string.Empty;// 更新アセンブリID2
                this.TspSdRvDt.LogicalDeleteCode = 0;// 論理削除区分
                if (salesSlip.EnterpriseCode.Length >= 9)
                {
                    this.TspSdRvDt.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim().Substring(sfEnterpriseCode.Trim().Length - 9));// SF企業コードの下9位
                }
                else
                {
                    this.TspSdRvDt.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim());// SF企業コード
                }

                this.TspSdRvDt.TspCommNo = Convert.ToInt32(commonSeqNo);// TSP通信番号
                this.TspSdRvDt.TspCommCount = this.TspCommCountTemp;// TSP通信回数
                this.TspSdRvDt.OrderContentsDivCd = 0;// 発注内容区分 
                // 指示書番号（文字列）
                string slipNo = salesSlip.PartySaleSlipNum.TrimStart('0');
                if (slipNo.Length > 9)
                {
                    this.TspSdRvDt.InstSlipNoStr = EditItem(slipNo.Substring(0, 9));
                }
                else
                {
                    this.TspSdRvDt.InstSlipNoStr = EditItem(slipNo);
                }
                this.TspSdRvDt.AcceptAnOrderNo = 0;// 受注番号
                this.TspSdRvDt.DataInputSystem = 0;// データ入力システム
                this.TspSdRvDt.DataInputSystemName = string.Empty;// データ入力システム名
                this.TspSdRvDt.SlipNo = string.Empty;// 伝票番号
                this.TspSdRvDt.SlipKind = 0;// 伝票種別
                this.TspSdRvDt.CommConditionDivCd = 0;// 通信状態区分
                this.TspSdRvDt.NumberPlate1Code = 0;// 陸運事務所番号
                this.TspSdRvDt.NumberPlate1Name = string.Empty;// 陸運事務局名称
                this.TspSdRvDt.NumberPlate2 = string.Empty;// 車両登録番号（種別）
                this.TspSdRvDt.NumberPlate3 = string.Empty;// 車両登録番号（カナ）
                this.TspSdRvDt.NumberPlate4 = 0;// 車両登録番号（プレート番号）
                this.TspSdRvDt.ModelDesignationNo = acceptOdrCarWork.ModelDesignationNo;// 型式指定番号
                this.TspSdRvDt.CategoryNo = acceptOdrCarWork.CategoryNo;// 類別番号
                this.TspSdRvDt.MakerCode = acceptOdrCarWork.MakerCode;// メーカーコード
                this.TspSdRvDt.ModelCode = acceptOdrCarWork.ModelCode;// 車種コード
                this.TspSdRvDt.ModelSubCode = acceptOdrCarWork.ModelSubCode;// 車種サブコード
                this.TspSdRvDt.ModelName = EditItem(acceptOdrCarWork.ModelFullName);// 車種名
                this.TspSdRvDt.CarInspectCertModel = string.Empty;// 車検証型式
                this.TspSdRvDt.FullModel = EditItem(acceptOdrCarWork.FullModel);// 型式（フル型）
                // 車台番号
                int retFrameNo;
                if (Int32.TryParse(acceptOdrCarWork.FrameNo, out retFrameNo))
                {
                    this.TspSdRvDt.FrameNo = retFrameNo;
                }
                else
                {
                    this.TspSdRvDt.FrameNo = 0;
                }
                this.TspSdRvDt.FrameModel = string.Empty;// 車台型式
                this.TspSdRvDt.ChassisNo = string.Empty;// シャシーNo
                this.TspSdRvDt.CarProperNo = 0;// 車両固有番号
                this.TspSdRvDt.ProduceTypeOfYearNum = acceptOdrCarWork.FirstEntryDate;// 生産年式（NUMタイプ）
                this.TspSdRvDt.SalesOrderDate = "0001-01-01T00:00:00";// 発注日
                this.TspSdRvDt.SalesOrderEmployeeCd = string.Empty;// 発注者従業員コード
                this.TspSdRvDt.SalesOrderEmployeeNm = string.Empty;// 発注者従業員名称
                this.TspSdRvDt.SalesOrderComment = string.Empty;// 発注時コメント
                this.TspSdRvDt.OrderSideSystemVerCd = 0;// 発注側システムバージョン区分
                this.TspSdRvDt.TspAnswerDataMngNo = 0;// TSP回答データ管理番号
                this.TspSdRvDt.TspSlipType = 0;// TSP伝票タイプ
                this.TspSdRvDt.AcceptAnOrderDate = salesSlip.SalesDate.ToString("yyyy-MM-dd'T'00:00:00");// 受注日
                // PM伝票番号
                int retSalesSlipNum;
                if (Int32.TryParse(salesSlip.SalesSlipNum, out retSalesSlipNum))
                {
                    this.TspSdRvDt.PmSlipNo = retSalesSlipNum;
                }
                else
                {
                    this.TspSdRvDt.PmSlipNo = 0;
                }
                this.TspSdRvDt.AcceptAnOrderNm = salesSlip.FrontEmployeeNm;// 受注者名
                this.TspSdRvDt.TspTotalSlipPrice = salesSlip.SalesTotalTaxExc;// TSP伝票合計金額
                this.TspSdRvDt.PmComment = salesSlip.SlipNote + salesSlip.SlipNote2 + salesSlip.SlipNote3;// PMコメント
                this.TspSdRvDt.PmVersion = "8.10.1.0";// PMバージョン
                this.TspSdRvDt.PmSendDate = DateTime.UtcNow.ToString("yyyy-MM-dd'T'00:00:00");// PM送信日
                // PM伝票種別
                if (salesSlip.SalesSlipCd == 0)
                {
                    // 売上データ.売上伝票区分が「0：売上」の場合、「10:売上」をセット
                    this.TspSdRvDt.PmSlipKind = 10;
                }
                else if (salesSlip.SalesSlipCd == 1)
                {
                    // 売上データ.売上伝票区分が「1：返品」の場合、「20:返品」をセット
                    this.TspSdRvDt.PmSlipKind = 20;
                }
                // PM元黒伝票番号
                if (addUpOrgDetailWork != null && addUpOrgDetailWork.SalesSlipNum != string.Empty && addUpOrgDetailWork.AcptAnOdrStatus == 30)
                {
                    this.TspSdRvDt.PmOriginalSlipNo = Convert.ToInt32(addUpOrgDetailWork.SalesSlipNum);
                }
                else
                {
                    this.TspSdRvDt.PmOriginalSlipNo = 0;
                }
            }
            catch (Exception ex)
            {
                LogWrite("GetTspSdRvDt()", "売上伝票番号：" + salesSlip.SalesSlipNum + "," + ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP明細ﾌｧｲﾙの作成
        /// </summary>
        /// <param name="salesSlip">売上伝票データ</param>
        /// <param name="salesDetailList">売上明細データ</param>
        /// <param name="addUpOrgDetailWork"> 計上元明細データ</param>
        /// <param name="commonSeqNo">TSPオンライン番号</param>
        /// <param name="sfEnterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : TSP明細ﾌｧｲﾙを作成する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool GetTspSdRvDtl(SalesSlipWork salesSlip, ArrayList salesDetailList, AddUpOrgSalesDetailWork addUpOrgDetailWork, long commonSeqNo, string sfEnterpriseCode)
        {
            try
            {
                this.TspSdRvDtlList.Clear();
                foreach (SalesDetailWork salesDetail in salesDetailList)
                {
                    TspSdRvDtl tspSdRvDtl = new TspSdRvDtl();
                    tspSdRvDtl.CreateDateTime = "0001-01-01T00:00:00";// 作成日時
                    tspSdRvDtl.UpdateDateTime = "0001-01-01T00:00:00"; // 更新日時
                    tspSdRvDtl.EnterpriseCode = EditItem(sfEnterpriseCode.Trim()); // 企業コード
                    tspSdRvDtl.EnterpriseName = string.Empty;// 企業名
                    tspSdRvDtl.FileHeaderGuid = "00000000-0000-0000-0000-000000000000";// GUID
                    tspSdRvDtl.UpdEmployeeCode = string.Empty;// 更新従業員コード
                    tspSdRvDtl.UpdEmployeeName = string.Empty;// 更新従業員名
                    tspSdRvDtl.UpdAssemblyId1 = string.Empty;// 更新アセンブリID1
                    tspSdRvDtl.UpdAssemblyId2 = string.Empty;// 更新アセンブリID2
                    tspSdRvDtl.LogicalDeleteCode = 0;// 論理削除区分
                    if (salesSlip.EnterpriseCode.Length >= 9)
                    {
                        tspSdRvDtl.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim().Substring(sfEnterpriseCode.Trim().Length - 9));// SF企業コードの下9位
                    }
                    else
                    {
                        tspSdRvDtl.PmEnterpriseCode = EditItem(sfEnterpriseCode.Trim());// SF企業コード
                    }

                    tspSdRvDtl.TspCommNo = Convert.ToInt32(commonSeqNo);// TSP通信番号
                    tspSdRvDtl.TspCommCount = this.TspCommCountTemp;// TSP通信回数
                    tspSdRvDtl.TspCommRowNo = salesDetail.SalesRowNo;// TSP通信行番号(TSPオンライン行番号)
                    tspSdRvDtl.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv;// 納品区分
                    tspSdRvDtl.HandleDivCode = 0;// 取扱区分
                    //  品番
                    if (salesDetail.GoodsNo == string.Empty)
                    {
                        tspSdRvDtl.PartsShape = 2;// 部品形態
                    }
                    else
                    {
                        tspSdRvDtl.PartsShape = 1;// 部品形態
                    }
                    tspSdRvDtl.DelivrdGdsConfCd = 0;// 納品確認区分
                    tspSdRvDtl.DeliGdsCmpltDueDate = "0001-01-01T00:00:00";// 納品完了予定日
                    tspSdRvDtl.TbsPartsCode = salesDetail.BLGoodsCode;// 部品コード(変換後を使用)
                    tspSdRvDtl.PmPartsNameKana = salesDetail.GoodsName;// PM部品名
                    // 発注数、納品数
                    if (salesDetail.ShipmentCnt == 0)
                    {
                        tspSdRvDtl.SalesOrderCount = 1;
                        tspSdRvDtl.DeliveredGoodsCount = 1;
                    }
                    else
                    {
                        if (addUpOrgDetailWork != null && addUpOrgDetailWork.SalesSlipNum != string.Empty 
                            && addUpOrgDetailWork.AcptAnOdrStatus == 30 && salesDetail.ShipmentCnt < 0)
                        {
                            tspSdRvDtl.SalesOrderCount = salesDetail.ShipmentCnt*(-1);
                            tspSdRvDtl.DeliveredGoodsCount = salesDetail.ShipmentCnt * (-1);
                        }
                        else
                        {
                            tspSdRvDtl.SalesOrderCount = salesDetail.ShipmentCnt;
                            tspSdRvDtl.DeliveredGoodsCount = salesDetail.ShipmentCnt;
                        }
                    }
                    tspSdRvDtl.PartsNoWithHyphen = EditItem(salesDetail.GoodsNo);// ハイフン付品番
                    tspSdRvDtl.PmPartsMakerCode = salesDetail.GoodsMakerCd;// // PM部品メーカーコード
                    //---<< 純正品番、純正メーカーのセット >>---//
                    // 純正
                    if (salesDetail.GoodsKindCode == 0)
                    {
                        tspSdRvDtl.PurePartsMakerCode = salesDetail.GoodsMakerCd;
                        tspSdRvDtl.PurePrtsNoWithHyphen = EditItem(salesDetail.GoodsNo);
                    }

                    tspSdRvDtl.ListPrice = (long)salesDetail.ListPriceTaxExcFl;// 定価

                    if (salesDetail.ShipmentCnt == 0)
                    {
                        tspSdRvDtl.UnitPrice = salesDetail.SalesMoneyTaxExc;// 売上金額
                        tspSdRvDtl.PmDtlTakeinDivCd = 1;// PM明細取込区分
                    }
                    else
                    {
                        tspSdRvDtl.UnitPrice = (long)salesDetail.SalesUnPrcTaxExcFl;// 売上単価（税抜，浮動）
                        tspSdRvDtl.PmDtlTakeinDivCd = 0;// PM明細取込区分
                    }
                    TspSdRvDtlList.Add(tspSdRvDtl);
                }
            }
            catch(Exception ex)
            {
                LogWrite("GetTspSdRvDtl()", "売上伝票番号：" + salesSlip.SalesSlipNum + "," + ex.ToString());
                return false;
            }
            return true;

        }

        /// <summary>
        /// 項目編集処理(文字列用)
        /// </summary>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : 項目編集処理(文字列用)を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private string EditItem(string strValue)
        {
            string outValue = string.Empty;
            if (!strValue.Equals(string.Empty))
            {
                // xml使用禁止文字の置換
                outValue = strValue.Replace("&" ,"&amp;");// & → &amp;
                outValue = strValue.Replace("<", "&lt;");// < → &lt;
                outValue = strValue.Replace(">", "&gt;");// > → &gt;
                outValue = strValue.Replace("'", "&apos;");// ' → &apos;
                outValue = strValue.Replace("''" ,"&quot;");// " → &quot;
            }
            return outValue;
        }

        /// <summary>
        /// TSP伝票ファイルシリアライズ処理
        /// </summary>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : TSP伝票ファイルのシリアライズを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool Serialize()
        {
            try
            {
                string tspSdRvDt = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                UserSettingController.SerializeUserSetting(this.TspSdRvDt, Path.Combine(this.TspTmpPath, tspSdRvDt));
            }
            catch(Exception ex)
            {
                LogWrite("Serialize()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP伝票ファイルシリアライズ処理
        /// </summary>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : TSP伝票ファイルのシリアライズを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool SerializeDtl()
        {
            try
            {
                string tspSdRvDt1 = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtlName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                UserSettingController.SerializeUserSetting(this.TspSdRvDtlList, Path.Combine(this.TspTmpPath, tspSdRvDt1));
            }
            catch (Exception ex)
            {
                LogWrite("SerializeDtl()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// TSP伝票ファイルとTSP明細ファイル暗号化
        /// </summary>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : TSP伝票ファイルとTSP明細ファイル暗号化処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool Encrypt()
        {
            try
            {
                // TSP伝票ﾌｧｲﾙ暗号化
                string xmlDtName = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                string xmlToDtName = Path.Combine(this.TspSendPath, string.Format(TspSdRvDtName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TspSdRvDt));
                using (System.IO.FileStream stream = new System.IO.FileStream(xmlDtName, System.IO.FileMode.Create))
                {
                    MemoryStream memstr = new MemoryStream();
                    serializer.Serialize(memstr, TspSdRvDt);
                    byte[] baff = EncryptXML(memstr);
                    stream.Write(baff, 0, baff.Length);
                    stream.Close();
                }

                // TSP明細ﾌｧｲﾙ暗号化
                string xmlDtlName = Path.Combine(this.TspTmpPath, string.Format(TspSdRvDtlName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                string xmlToDtlName = Path.Combine(this.TspSendPath, string.Format(TspSdRvDtlName, this.TspCommCountTemp.ToString().PadLeft(2, '0')));
                System.Xml.Serialization.XmlSerializer serializer3 = new System.Xml.Serialization.XmlSerializer(typeof(TspSdRvDtl[]));

                using (System.IO.FileStream stream3 = new System.IO.FileStream(xmlDtlName, System.IO.FileMode.Create))
                {
                    MemoryStream memstr = new MemoryStream();
                    serializer3.Serialize(memstr, TspSdRvDtlList.ToArray());
                    byte[] baffDtl = EncryptXML(memstr);
                    stream3.Write(baffDtl, 0, baffDtl.Length);
                    stream3.Close();
                }
                if (File.Exists(xmlDtName))
                {
                    File.Copy(xmlDtName, xmlToDtName, false);
                    File.Delete(xmlDtName);
                }
                if (File.Exists(xmlDtlName))
                {
                    File.Copy(xmlDtlName, xmlToDtlName, false);
                    File.Delete(xmlDtlName);
                }
            }
            catch (Exception ex)
            {
                LogWrite("Encrypt()", ex.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// 暗号化処理
        /// </summary>
        /// <param name="stream"></param>
        /// <remarks>
        /// <br>Note       : 暗号化処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private static byte[] EncryptXML(MemoryStream stream)
        {
            MemoryStream ms = new MemoryStream();
            byte[] byteBuffer = new byte[stream.Length];
            // 3DES暗号化           
            stream.Position = 0;
            stream.Read(byteBuffer, 0, byteBuffer.Length);
            using (TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider())
            {
                // キー及び初期化ベクタを設定
                des3.Key = TspXMLDecryptTableResource.Key;
                des3.IV = TspXMLDecryptTableResource.InitVector;
                using (CryptoStream cs = new CryptoStream(ms, des3.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(byteBuffer, 0, byteBuffer.Length);
                    cs.FlushFinalBlock();
                }
            }
            return ms.ToArray();
        }

        /// <summary>
        /// 送信データ削除処理
        /// </summary>
        /// <returns>true:成功、false:失敗</returns>
        /// <remarks>
        /// <br>Note       : 送信データ削除処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private bool DeleteProc()
        {
            if (!Directory.Exists(this.TspTrashPath)) CreateDir(this.TspTrashPath);
            try
            {
                // フォルダ下のファイルを取り込
                string[] fileList = System.IO.Directory.GetFiles(this.TspSendPath, "*.XML");
                string bakName = string.Empty;
                if (fileList.Length == 0)
                {
                    LogWrite("DeleteProc()", "削除元ファイルがありません。");
                    return false;
                }
                foreach (string file in fileList)
                {
                    FileInfo info = new FileInfo(file);
                    bakName = Path.Combine(this.TspTrashPath, info.Name);
                    File.Copy(file, bakName);
                }

                DirectoryInfo di = new DirectoryInfo(this.TspSendPath); 
                di.Delete(true); 
            }
            catch(Exception ex)
            {
                LogWrite("DeleteProc()", ex.ToString());
                return false;
            }

            return true;

        }

        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="methodName">メソッド名</param>
        /// <param name="pMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : エラーログを書きます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private static void LogWrite(string methodName, string pMsg)
        {
            System.IO.FileStream fs;										// ファイルストリーム
            System.IO.StreamWriter sw;										// ストリームwriter
            // Logフォルダー
            string logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            if (!Directory.Exists(logFolderPath))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logFolderPath);
            }
            // ログファイル
            string logFilePath = Path.Combine(logFolderPath, "TSP送信データ作成");
            if (!Directory.Exists(logFilePath))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logFilePath);
            }
            string logFilePathName = Path.Combine(logFilePath, "PMTSP01201A.Log");
            fs = new FileStream(logFilePathName, FileMode.Append, FileAccess.Write, FileShare.Write);
            sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("shift_jis"));
            string log = string.Format("{0},{1},{2}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), methodName, pMsg);
            sw.WriteLine(log);
            if (sw != null)
                sw.Close();
            if (fs != null)
                fs.Close();
        }
        # endregion

    }

    # region [前回値保持]
    /// <summary>
    /// 前回値保持
    /// </summary>
    public class TspSndPathInfo
    {
        // パス
        private string _tspSndPath;

        // 一時パス
        private string _tspSndTmpPath;

        /// <summary>
        /// 前回値保持クラス
        /// </summary>
        public TspSndPathInfo()
        {

        }

        /// <summary>
        /// パス
        /// </summary>
        public string TspSndPath
        {
            get { return _tspSndPath; }
            set { _tspSndPath = value; }
        }

        /// <summary>
        /// パス
        /// </summary>
        public string TspSndTmpPath
        {
            get { return _tspSndTmpPath; }
            set { _tspSndTmpPath = value; }
        }

    }
    #endregion

    # region 売上伝票データ
    /// <summary>
    /// 売上伝票データ
    /// </summary>
    public class TspSdRvDt
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>PM企業コード</summary>
        /// <remarks>部品商の企業コード</remarks>
        private string _pmEnterpriseCode = "";

        /// <summary>TSP通信番号</summary>
        /// <remarks>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</remarks>
        private Int32 _tspCommNo;

        /// <summary>TSP通信回数</summary>
        /// <remarks>PM側が１発注に対して回答を行う回数</remarks>
        private Int32 _tspCommCount;

        /// <summary>発注内容区分</summary>
        /// <remarks>1:通常発注,2:価格問い合わせ,3:在庫問い合わせ</remarks>
        private Int32 _orderContentsDivCd;

        /// <summary>指示書番号（文字列）</summary>
        /// <remarks>文字型</remarks>
        private string _instSlipNoStr = "";

        /// <summary>受注番号</summary>
        /// <remarks>発注側(SF・BK)の受注番号</remarks>
        private Int32 _acceptAnOrderNo;

        /// <summary>データ入力システム</summary>
        /// <remarks>0:共通,1:整備,2:鈑金,3:車販　発注側のデータ入力システム</remarks>
        private Int32 _dataInputSystem;

        /// <summary>伝票番号</summary>
        private string _slipNo = "";

        /// <summary>伝票種別</summary>
        /// <remarks>10:見積,20:指示,21:承り書,30:納品,40:加修</remarks>
        private Int32 _slipKind;

        /// <summary>通信状態区分</summary>
        /// <remarks>0:未処理,1:送信済み,2:処理済,9:エラー</remarks>
        private Int32 _commConditionDivCd;

        /// <summary>陸運事務所番号</summary>
        private Int32 _numberPlate1Code;

        /// <summary>陸運事務局名称</summary>
        private string _numberPlate1Name = "";

        /// <summary>車両登録番号（種別）</summary>
        private string _numberPlate2 = "";

        /// <summary>車両登録番号（カナ）</summary>
        private string _numberPlate3 = "";

        /// <summary>車両登録番号（プレート番号）</summary>
        private Int32 _numberPlate4;

        /// <summary>型式指定番号</summary>
        private Int32 _modelDesignationNo;

        /// <summary>類別番号</summary>
        private Int32 _categoryNo;

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>車種名</summary>
        private string _modelName = "";

        /// <summary>車検証型式</summary>
        private string _carInspectCertModel = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>車台番号</summary>
        private Int32 _frameNo;

        /// <summary>車台型式</summary>
        private string _frameModel = "";

        /// <summary>シャシーNo</summary>
        private string _chassisNo = "";

        /// <summary>車両固有番号</summary>
        /// <remarks>ユニークな固定番号</remarks>
        private Int32 _carProperNo;

        /// <summary>生産年式（NUMタイプ）</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _produceTypeOfYearNum;

        /// <summary>発注日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _salesOrderDate;

        /// <summary>発注者従業員コード</summary>
        /// <remarks>発注した従業員コード</remarks>
        private string _salesOrderEmployeeCd = "";

        /// <summary>発注者従業員名称</summary>
        /// <remarks>発注した従業員名称</remarks>
        private string _salesOrderEmployeeNm = "";

        /// <summary>発注時コメント</summary>
        /// <remarks>発注する際に入力するコメント</remarks>
        private string _salesOrderComment = "";

        /// <summary>発注側システムバージョン区分</summary>
        /// <remarks>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</remarks>
        private Int32 _orderSideSystemVerCd;

        /// <summary>TSP回答データ管理番号</summary>
        /// <remarks>発注時、番号採番</remarks>
        private Int32 _tspAnswerDataMngNo;

        /// <summary>TSP伝票タイプ</summary>
        /// <remarks>0:オンライン発注分,1:電話発注分</remarks>
        private Int32 _tspSlipType;

        /// <summary>受注日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _acceptAnOrderDate;

        /// <summary>PM伝票番号</summary>
        private Int32 _pmSlipNo;

        /// <summary>受注者名</summary>
        /// <remarks>受注した従業員名称</remarks>
        private string _acceptAnOrderNm = "";

        /// <summary>TSP伝票合計金額</summary>
        private Int64 _tspTotalSlipPrice;

        /// <summary>PMコメント</summary>
        private string _pmComment = "";

        /// <summary>PMバージョン</summary>
        private string _pmVersion = "";

        /// <summary>PM送信日</summary>
        /// <remarks>PM側が送信した日付 YYYYMMDD</remarks>
        private string _pmSendDate;

        /// <summary>PM伝票種別</summary>
        /// <remarks>10:売上、20:返品</remarks>
        private Int32 _pmSlipKind;

        /// <summary>PM元黒伝票番号</summary>
        /// <remarks>赤伝・返品の場合に元の黒伝票番号を設定</remarks>
        private Int32 _pmOriginalSlipNo;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>データ入力システム名称</summary>
        /// <remarks>共通,整備,鈑金,車販</remarks>
        private string _dataInputSystemName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PmEnterpriseCode
        /// <summary>PM企業コードプロパティ</summary>
        /// <value>部品商の企業コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmEnterpriseCode
        {
            get { return _pmEnterpriseCode; }
            set { _pmEnterpriseCode = value; }
        }

        /// public propaty name  :  TspCommNo
        /// <summary>TSP通信番号プロパティ</summary>
        /// <value>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommNo
        {
            get { return _tspCommNo; }
            set { _tspCommNo = value; }
        }

        /// public propaty name  :  TspCommCount
        /// <summary>TSP通信回数プロパティ</summary>
        /// <value>PM側が１発注に対して回答を行う回数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommCount
        {
            get { return _tspCommCount; }
            set { _tspCommCount = value; }
        }

        /// public propaty name  :  OrderContentsDivCd
        /// <summary>発注内容区分プロパティ</summary>
        /// <value>1:通常発注,2:価格問い合わせ,3:在庫問い合わせ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注内容区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderContentsDivCd
        {
            get { return _orderContentsDivCd; }
            set { _orderContentsDivCd = value; }
        }

        /// public propaty name  :  InstSlipNoStr
        /// <summary>指示書番号（文字列）プロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   指示書番号（文字列）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InstSlipNoStr
        {
            get { return _instSlipNoStr; }
            set { _instSlipNoStr = value; }
        }

        /// public propaty name  :  AcceptAnOrderNo
        /// <summary>受注番号プロパティ</summary>
        /// <value>発注側(SF・BK)の受注番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptAnOrderNo
        {
            get { return _acceptAnOrderNo; }
            set { _acceptAnOrderNo = value; }
        }

        /// public propaty name  :  DataInputSystem
        /// <summary>データ入力システムプロパティ</summary>
        /// <value>0:共通,1:整備,2:鈑金,3:車販　発注側のデータ入力システム</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  SlipNo
        /// <summary>伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
        }

        /// public propaty name  :  SlipKind
        /// <summary>伝票種別プロパティ</summary>
        /// <value>10:見積,20:指示,21:承り書,30:納品,40:加修</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipKind
        {
            get { return _slipKind; }
            set { _slipKind = value; }
        }

        /// public propaty name  :  CommConditionDivCd
        /// <summary>通信状態区分プロパティ</summary>
        /// <value>0:未処理,1:送信済み,2:処理済,9:エラー</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信状態区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CommConditionDivCd
        {
            get { return _commConditionDivCd; }
            set { _commConditionDivCd = value; }
        }

        /// public propaty name  :  NumberPlate1Code
        /// <summary>陸運事務所番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務所番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate1Code
        {
            get { return _numberPlate1Code; }
            set { _numberPlate1Code = value; }
        }

        /// public propaty name  :  NumberPlate1Name
        /// <summary>陸運事務局名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   陸運事務局名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate1Name
        {
            get { return _numberPlate1Name; }
            set { _numberPlate1Name = value; }
        }

        /// public propaty name  :  NumberPlate2
        /// <summary>車両登録番号（種別）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（種別）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate2
        {
            get { return _numberPlate2; }
            set { _numberPlate2 = value; }
        }

        /// public propaty name  :  NumberPlate3
        /// <summary>車両登録番号（カナ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>車両登録番号（プレート番号）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両登録番号（プレート番号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  ModelDesignationNo
        /// <summary>型式指定番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式指定番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelDesignationNo
        {
            get { return _modelDesignationNo; }
            set { _modelDesignationNo = value; }
        }

        /// public propaty name  :  CategoryNo
        /// <summary>類別番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   類別番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名ｺｰﾄﾞ(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>車種名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  CarInspectCertModel
        /// <summary>車検証型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車検証型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarInspectCertModel
        {
            get { return _carInspectCertModel; }
            set { _carInspectCertModel = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  FrameModel
        /// <summary>車台型式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameModel
        {
            get { return _frameModel; }
            set { _frameModel = value; }
        }

        /// public propaty name  :  ChassisNo
        /// <summary>シャシーNoプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シャシーNoプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChassisNo
        {
            get { return _chassisNo; }
            set { _chassisNo = value; }
        }

        /// public propaty name  :  CarProperNo
        /// <summary>車両固有番号プロパティ</summary>
        /// <value>ユニークな固定番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両固有番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarProperNo
        {
            get { return _carProperNo; }
            set { _carProperNo = value; }
        }

        /// public propaty name  :  ProduceTypeOfYearNum
        /// <summary>生産年式（NUMタイプ）プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   生産年式（NUMタイプ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProduceTypeOfYearNum
        {
            get { return _produceTypeOfYearNum; }
            set { _produceTypeOfYearNum = value; }
        }

        /// public propaty name  :  SalesOrderDate
        /// <summary>発注日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderDate
        {
            get { return _salesOrderDate; }
            set { _salesOrderDate = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeCd
        /// <summary>発注者従業員コードプロパティ</summary>
        /// <value>発注した従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注者従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderEmployeeCd
        {
            get { return _salesOrderEmployeeCd; }
            set { _salesOrderEmployeeCd = value; }
        }

        /// public propaty name  :  SalesOrderEmployeeNm
        /// <summary>発注者従業員名称プロパティ</summary>
        /// <value>発注した従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注者従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderEmployeeNm
        {
            get { return _salesOrderEmployeeNm; }
            set { _salesOrderEmployeeNm = value; }
        }

        /// public propaty name  :  SalesOrderComment
        /// <summary>発注時コメントプロパティ</summary>
        /// <value>発注する際に入力するコメント</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注時コメントプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesOrderComment
        {
            get { return _salesOrderComment; }
            set { _salesOrderComment = value; }
        }

        /// public propaty name  :  OrderSideSystemVerCd
        /// <summary>発注側システムバージョン区分プロパティ</summary>
        /// <value>0:SF.NS or BK.NS,1:Pegasus,2:Phoenix</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注側システムバージョン区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OrderSideSystemVerCd
        {
            get { return _orderSideSystemVerCd; }
            set { _orderSideSystemVerCd = value; }
        }

        /// public propaty name  :  TspAnswerDataMngNo
        /// <summary>TSP回答データ管理番号プロパティ</summary>
        /// <value>発注時、番号採番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP回答データ管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspAnswerDataMngNo
        {
            get { return _tspAnswerDataMngNo; }
            set { _tspAnswerDataMngNo = value; }
        }

        /// public propaty name  :  TspSlipType
        /// <summary>TSP伝票タイププロパティ</summary>
        /// <value>0:オンライン発注分,1:電話発注分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP伝票タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspSlipType
        {
            get { return _tspSlipType; }
            set { _tspSlipType = value; }
        }

        /// public propaty name  :  AcceptAnOrderDate
        /// <summary>受注日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcceptAnOrderDate
        {
            get { return _acceptAnOrderDate; }
            set { _acceptAnOrderDate = value; }
        }

        /// public propaty name  :  PmSlipNo
        /// <summary>PM伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PmSlipNo
        {
            get { return _pmSlipNo; }
            set { _pmSlipNo = value; }
        }

        /// public propaty name  :  AcceptAnOrderNm
        /// <summary>受注者名プロパティ</summary>
        /// <value>受注した従業員名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AcceptAnOrderNm
        {
            get { return _acceptAnOrderNm; }
            set { _acceptAnOrderNm = value; }
        }

        /// public propaty name  :  TspTotalSlipPrice
        /// <summary>TSP伝票合計金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP伝票合計金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TspTotalSlipPrice
        {
            get { return _tspTotalSlipPrice; }
            set { _tspTotalSlipPrice = value; }
        }

        /// public propaty name  :  PmComment
        /// <summary>PMコメントプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PMコメントプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmComment
        {
            get { return _pmComment; }
            set { _pmComment = value; }
        }

        /// public propaty name  :  PmVersion
        /// <summary>PMバージョンプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PMバージョンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmVersion
        {
            get { return _pmVersion; }
            set { _pmVersion = value; }
        }

        /// public propaty name  :  PmSendDate
        /// <summary>PM送信日プロパティ</summary>
        /// <value>PM側が送信した日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM送信日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmSendDate
        {
            get { return _pmSendDate; }
            set { _pmSendDate = value; }
        }

        /// public propaty name  :  PmSlipKind
        /// <summary>PM伝票種別プロパティ</summary>
        /// <value>10:売上、20:返品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM伝票種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PmSlipKind
        {
            get { return _pmSlipKind; }
            set { _pmSlipKind = value; }
        }

        /// public propaty name  :  PmOriginalSlipNo
        /// <summary>PM元黒伝票番号プロパティ</summary>
        /// <value>赤伝・返品の場合に元の黒伝票番号を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM元黒伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PmOriginalSlipNo
        {
            get { return _pmOriginalSlipNo; }
            set { _pmOriginalSlipNo = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  DataInputSystemName
        /// <summary>データ入力システム名称プロパティ</summary>
        /// <value>共通,整備,鈑金,車販</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DataInputSystemName
        {
            get { return _dataInputSystemName; }
            set { _dataInputSystemName = value; }
        }
    }
    # endregion

    # region 売上明細データ
    /// <summary>
    /// 売上明細データ
    /// </summary>
    public class TspSdRvDtl
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>PM企業コード</summary>
        /// <remarks>部品商の企業コード</remarks>
        private string _pmEnterpriseCode = "";

        /// <summary>TSP通信番号</summary>
        /// <remarks>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</remarks>
        private Int32 _tspCommNo;

        /// <summary>TSP通信回数</summary>
        /// <remarks>PM側が１発注に対して回答を行う回数</remarks>
        private Int32 _tspCommCount;

        /// <summary>TSP通信行番号</summary>
        private Int32 _tspCommRowNo;

        /// <summary>納品区分</summary>
        /// <remarks>0:配送,1:引取</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>取扱区分</summary>
        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
        private Int32 _handleDivCode;

        /// <summary>部品形態</summary>
        /// <remarks>1:部品,2:用品</remarks>
        private Int32 _partsShape;

        /// <summary>納品確認区分</summary>
        /// <remarks>0:未確認,1:確認</remarks>
        private Int32 _delivrdGdsConfCd;

        /// <summary>納品完了予定日</summary>
        /// <remarks>納品予定日付 YYYYMMDD</remarks>
        private string _deliGdsCmpltDueDate;

        /// <summary>翼部品コード</summary>
        /// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>PM部品名（カナ）</summary>
        /// <remarks>PM側の品名</remarks>
        private string _pmPartsNameKana = "";

        /// <summary>発注数</summary>
        private Double _salesOrderCount;

        /// <summary>納品数</summary>
        private Double _deliveredGoodsCount;

        /// <summary>ハイフン付品番</summary>
        private string _partsNoWithHyphen = "";

        /// <summary>PM部品メーカーコード</summary>
        /// <remarks>PM側の部品メーカーコード</remarks>
        private Int32 _pmPartsMakerCode;

        /// <summary>純正部品メーカーコード</summary>
        private Int32 _purePartsMakerCode;

        /// <summary>純正ハイフン付品番</summary>
        /// <remarks>SF・BK引当時は、伝票明細のハイフン付品番となる</remarks>
        private string _purePrtsNoWithHyphen = "";

        /// <summary>定価</summary>
        private Int64 _listPrice;

        /// <summary>単価</summary>
        private Int64 _unitPrice;

        /// <summary>PM明細取込区分</summary>
        /// <remarks>0:取込可,1:取込不可</remarks>
        private Int32 _pmDtlTakeinDivCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PmEnterpriseCode
        /// <summary>PM企業コードプロパティ</summary>
        /// <value>部品商の企業コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmEnterpriseCode
        {
            get { return _pmEnterpriseCode; }
            set { _pmEnterpriseCode = value; }
        }

        /// public propaty name  :  TspCommNo
        /// <summary>TSP通信番号プロパティ</summary>
        /// <value>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommNo
        {
            get { return _tspCommNo; }
            set { _tspCommNo = value; }
        }

        /// public propaty name  :  TspCommCount
        /// <summary>TSP通信回数プロパティ</summary>
        /// <value>PM側が１発注に対して回答を行う回数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommCount
        {
            get { return _tspCommCount; }
            set { _tspCommCount = value; }
        }

        /// public propaty name  :  TspCommRowNo
        /// <summary>TSP通信行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommRowNo
        {
            get { return _tspCommRowNo; }
            set { _tspCommRowNo = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>納品区分プロパティ</summary>
        /// <value>0:配送,1:引取</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  HandleDivCode
        /// <summary>取扱区分プロパティ</summary>
        /// <value>0:取り扱い品,1:納期確認中,2:未取り扱い品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取扱区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandleDivCode
        {
            get { return _handleDivCode; }
            set { _handleDivCode = value; }
        }

        /// public propaty name  :  PartsShape
        /// <summary>部品形態プロパティ</summary>
        /// <value>1:部品,2:用品</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品形態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsShape
        {
            get { return _partsShape; }
            set { _partsShape = value; }
        }

        /// public propaty name  :  DelivrdGdsConfCd
        /// <summary>納品確認区分プロパティ</summary>
        /// <value>0:未確認,1:確認</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品確認区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelivrdGdsConfCd
        {
            get { return _delivrdGdsConfCd; }
            set { _delivrdGdsConfCd = value; }
        }

        /// public propaty name  :  DeliGdsCmpltDueDate
        /// <summary>納品完了予定日プロパティ</summary>
        /// <value>納品予定日付 YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品完了予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliGdsCmpltDueDate
        {
            get { return _deliGdsCmpltDueDate; }
            set { _deliGdsCmpltDueDate = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>翼部品コードプロパティ</summary>
        /// <value>1～99999:提供分,100000～ユーザー登録用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  PmPartsNameKana
        /// <summary>PM部品名（カナ）プロパティ</summary>
        /// <value>PM側の品名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM部品名（カナ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmPartsNameKana
        {
            get { return _pmPartsNameKana; }
            set { _pmPartsNameKana = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>発注数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  DeliveredGoodsCount
        /// <summary>納品数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double DeliveredGoodsCount
        {
            get { return _deliveredGoodsCount; }
            set { _deliveredGoodsCount = value; }
        }

        /// public propaty name  :  PartsNoWithHyphen
        /// <summary>ハイフン付品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsNoWithHyphen
        {
            get { return _partsNoWithHyphen; }
            set { _partsNoWithHyphen = value; }
        }

        /// public propaty name  :  PmPartsMakerCode
        /// <summary>PM部品メーカーコードプロパティ</summary>
        /// <value>PM側の部品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PmPartsMakerCode
        {
            get { return _pmPartsMakerCode; }
            set { _pmPartsMakerCode = value; }
        }

        /// public propaty name  :  PurePartsMakerCode
        /// <summary>純正部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PurePartsMakerCode
        {
            get { return _purePartsMakerCode; }
            set { _purePartsMakerCode = value; }
        }

        /// public propaty name  :  PurePrtsNoWithHyphen
        /// <summary>純正ハイフン付品番プロパティ</summary>
        /// <value>SF・BK引当時は、伝票明細のハイフン付品番となる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正ハイフン付品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PurePrtsNoWithHyphen
        {
            get { return _purePrtsNoWithHyphen; }
            set { _purePrtsNoWithHyphen = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  PmDtlTakeinDivCd
        /// <summary>PM明細取込区分プロパティ</summary>
        /// <value>0:取込可,1:取込不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM明細取込区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PmDtlTakeinDivCd
        {
            get { return _pmDtlTakeinDivCd; }
            set { _pmDtlTakeinDivCd = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }
    }
    # endregion
}
