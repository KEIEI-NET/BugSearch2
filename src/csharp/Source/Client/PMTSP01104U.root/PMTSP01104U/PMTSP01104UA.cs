using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    public class TspSendController
    {
        private TspSendTableCls _SdRvData = null;		//送受信データテーブルクラス
        private DataTable _TSPCustomerList = null;
        private TspSendSettingInfo _settinginfo = null;
        private string _start_EnterpriseCD = "";
        private string _pm_EnterpriseCD = "";
        private const string AssmblyID = "PMTSP01104U";
        private const string AssmblyTitle = "ＴＳＰ送信制御";
        private string _LogFilePath = "";
        private TextWriter _TextWriter = null;
        private TspCprtStAcs _tspCprtStAcs;				// TSP連携設定アクセスクラス

        /// <summary>得意先情報アクセスクラス</summary>
        private CustomerInfoAcs _customerInfoAcs;

        private int _stat0Cnt = 0;
        private int _stat1Cnt = 0;
        private int _stat2Cnt = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TspSendController()
        {
#if DEBUG
            MessageBox.Show("aaa");

#endif
            _settinginfo = new TspSendSettingInfo();
            _settinginfo.Load();
            _SdRvData = new TspSendTableCls();
            _LogFilePath = _settinginfo.TSPSdRvDataPath + @"\TspSendLog.txt";
            this._tspCprtStAcs = new TspCprtStAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            _pm_EnterpriseCD = LoginInfoAcquisition.EnterpriseCode;
        }

        /// <summary>
        /// 送受信データテーブル
        /// </summary>
        public TspSendTableCls TspSendData
        {
            get { return this._SdRvData; }
        }

        /// <summary>
        /// 送受信データテーブル
        /// </summary>
        public DataTable TSPCustomerList
        {
            get { return this._TSPCustomerList; }
        }

        /// <summary>
        /// 送受信データテーブル
        /// </summary>
        public TspSendSettingInfo TspInfo
        {
            get { return this._settinginfo; }
            set { _settinginfo = value; }
        }

        /// <summary>
        /// 先頭SF企業コード
        /// </summary>
        public string Start_EnterpriseCD
        {
            get { return this._start_EnterpriseCD; }
        }

        public string LogFilePath
        {
            get { return this._LogFilePath; }
            set { _LogFilePath = value; }
        }

        /// <summary>
        /// 未送信データ件数
        /// </summary>
        public int Stat0Cnt
        {
            get { return this._stat0Cnt; }
        }
        /// <summary>
        /// 未送信データ件数
        /// </summary>
        public int Stat1Cnt
        {
            get { return this._stat1Cnt; }
        }
        /// <summary>
        /// 未送信データ件数
        /// </summary>
        public int Stat2Cnt
        {
            get { return this._stat2Cnt; }
        }


        #region 得意先リスト読み込み
        /// <summary>
        /// 得意先リスト読み込み
        /// </summary>
        /// <returns>得意先件数</returns>

        public int ReadTSPList()
        {
            DataSet ds = new DataSet();
            _TSPCustomerList = ds.Tables.Add("TSP-LIST");

            _TSPCustomerList.Columns.Add(CreateColumn(TspCustomer.CUST_PmCustomerCode, typeof(string), "送信先得意先コード"));	//送信先得意先コード			
            _TSPCustomerList.Columns.Add(CreateColumn(TspCustomer.CUST_PmCustomerName, typeof(string), "送信先得意先名称"));	//送信先得意先コード	
            _TSPCustomerList.Columns.Add(CreateColumn(TspCustomer.CUST_PmEnterpriseCode, typeof(string), "PM企業コード"));	//PM企業コード
            _TSPCustomerList.Columns.Add(CreateColumn(TspCustomer.CUST_SfEnterpriseCode, typeof(string), "SF企業コード"));	//SF企業コード
            int iRetry = 0;
            // 送受信データ (PMTSP01101E)
            TspCustomer[] tsplst;
            while (true)
            {
                tsplst = null;
                try
                {
           			int status = 0;
                    TspCprtStWork tspCprtWork = new TspCprtStWork();
                    tspCprtWork.EnterpriseCode = this._pm_EnterpriseCD;

                    ArrayList tspCprtWorkList = null;

	                // TSP連携マスタ抽出
                    status = this._tspCprtStAcs.Search(tspCprtWork, out tspCprtWorkList);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                tsplst = new TspCustomer[tspCprtWorkList.Count];
                                int idx = 0;
                                foreach (TspCprtStWork tspCprtStWork in tspCprtWorkList)
                                {
                                    tsplst[idx] = new TspCustomer();
                                    // 得意先名称取得
                                    CustomerInfo customerInfo;
                                    this._customerInfoAcs.ReadDBData(this._pm_EnterpriseCD, tspCprtStWork.CustomerCode, out customerInfo);
                                    if ((customerInfo != null) && (!string.IsNullOrEmpty(customerInfo.CustomerSnm)))
                                    {
                                        // 得意先名称
                                        tsplst[idx].PmCustomerName = customerInfo.CustomerSnm.TrimEnd();
                                    }
                                    else
                                    {
                                        // 得意先マスタに存在しない場合は名称空白で進む
                                        tsplst[idx].PmCustomerName = string.Empty;
                                    }

                                    // PM企業コード
                                    tsplst[idx].PmEnterpriseCode = _pm_EnterpriseCD;

                                    // 得意先コード
                                    tsplst[idx].PmCustomerCode = tspCprtStWork.CustomerCode;

                                    // SF企業コード
                                    tsplst[idx].SfEnterpriseCode = tspCprtStWork.SendEnterpriseCode;

                                    idx++;
                                }

                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                break;
                            }
                        default:
                            {
                                if (iRetry > 5)
                                {
                                    MessageBox.Show(
                                        "TSP連携マスタの取得に失敗しました。\n" +
                                        "status:" + status.ToString(),
                                        AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    iRetry++;
                                }

                                // リトライ
                                continue;
                            }
                    } 

                    break;

                }
                catch (Exception ex)
                {

                    if (iRetry > 5)
                    {
                        MessageBox.Show(
                            "TSP得意先データの取り込みに失敗しました。\n" +
                            ex.Message,
                            AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                        iRetry++;
                    }
                }
            }
            if (tsplst != null)
            {
                foreach (TspCustomer tc in tsplst)
                {
                    DataRow tc_dr = _TSPCustomerList.NewRow();
                    tc_dr[TspCustomer.CUST_PmCustomerCode] = tc.PmCustomerCode.ToString("d8");	//得意先コード
                    tc_dr[TspCustomer.CUST_PmCustomerName] = tc.PmCustomerName;	//得意先名称
                    tc_dr[TspCustomer.CUST_PmEnterpriseCode] = tc.PmEnterpriseCode;	//PM企業コード
                    tc_dr[TspCustomer.CUST_SfEnterpriseCode] = tc.SfEnterpriseCode;	//SF企業コード

                    _TSPCustomerList.Rows.Add(tc_dr);
                    if (_start_EnterpriseCD == "") _start_EnterpriseCD = tc.SfEnterpriseCode;
                    if (_pm_EnterpriseCD == "") _pm_EnterpriseCD = tc.PmEnterpriseCode;
#if DEBUG                    
                    _pm_EnterpriseCD = "8420200";
#endif
                }
            }
            
            return _TSPCustomerList.Rows.Count;

        }
        #endregion

        #region	■ 送受信データ検索

        /// <summary>
        /// 送受信データ検索
        /// </summary>
        /// <returns>結果ステータス	0:正常,-1:エラー</returns>
        public int SearchTspSdRvDt(string TSPSdRvDataPath, string TableName)
        {

            int st = 0;
            string[] _CustFolders;
            string[] _SdRvFolders;
            string _SdRvDtFile;
            string _SdRvDtlFile;

            if (TableName == TspSendTableCls.SDR_TABLENAME)
                _SdRvData.SerchTable.Clear();
            ((DataTable)_SdRvData.GetTable(TableName)).Rows.Clear();

            _CustFolders = Directory.GetDirectories(TSPSdRvDataPath);

            foreach (string _CustFolder in _CustFolders)
            {

                _SdRvFolders = Directory.GetDirectories(_CustFolder);
                foreach (string _SdRvFolder in _SdRvFolders)
                {
                    
                    for (int iCnt = 0; iCnt < 99; iCnt++)
                    {
                        _SdRvDtFile = _SdRvFolder + String.Format(@"\TspSdRvDt{0}.xml", iCnt.ToString("d2"));
                        _SdRvDtlFile = _SdRvFolder + String.Format(@"\TspSdRvDtl{0}.xml", iCnt.ToString("d2"));
                        if (!System.IO.File.Exists(_SdRvDtFile)||!System.IO.File.Exists(_SdRvDtlFile)) { continue; }

                        // 送受信データ (PMTSP01101E)
                        Broadleaf.Application.UIData.TspSdRvDt sdrv;
                        int iRetry = 0;
                        while (true)
                        {
                            // 送受信データ (PMTSP01101E)
                            sdrv = null;
                            try
                            {

                                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Broadleaf.Application.UIData.TspSdRvDt));
                                using (System.IO.FileStream stream = new System.IO.FileStream(_SdRvDtFile, System.IO.FileMode.Open))
                                {

                                    MemoryStream memstr = new MemoryStream(TSPSendXMLReader.DecryptXML(stream));
                                    sdrv = (Broadleaf.Application.UIData.TspSdRvDt)serializer.Deserialize(memstr);

                                }
                                break;

                            }
                            catch (Exception ex)
                            {
                                if (iRetry > 5)
                                {
                                    MessageBox.Show(
                                        "送受信データの取り込みに失敗しました。\n" +
                                        ex.Message,
                                        AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    iRetry++;
                                }

                            }
                        }
                        // 送受信明細データ (PMTSP01101E)
                        Broadleaf.Application.UIData.TspSdRvDtl[] dtls;
                        iRetry = 0;
                        while (true)
                        {
                            try
                            {
                                // 送受信明細データ (PMTSP01101E)
                                dtls = null;

                                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Broadleaf.Application.UIData.TspSdRvDtl[]));
                                using (System.IO.FileStream stream = new System.IO.FileStream(_SdRvDtlFile, System.IO.FileMode.Open))
                                {
                                    MemoryStream memstr = new MemoryStream(TSPSendXMLReader.DecryptXML(stream));
                                    dtls = (Broadleaf.Application.UIData.TspSdRvDtl[])serializer.Deserialize(memstr);
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (iRetry > 5)
                                {
                                    MessageBox.Show(
                                    "送受信明細データの取り込みに失敗しました。\n" +
                                        ex.Message,
                                        AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(1000);
                                    iRetry++;
                                }

                            }
                        }

                        if (sdrv == null)
                        {
                        }
                        else
                        {
                            if (TableName == TspSendTableCls.TRASH_TABLENAME)
                            {
                                DataRow trash_dr = _SdRvData.TrashTable.NewRow();
                                _SdRvData.TrashTable.Rows.Add(_SdRvData.SetSdrvDataRow(trash_dr, sdrv, dtls));
                                trash_dr[TspSendTableCls.SDR_XMLSdrvPath] = _SdRvDtFile;
                                trash_dr[TspSendTableCls.SDR_XMLDtlPath] = _SdRvDtlFile;
                                trash_dr[TspSendTableCls.SDR_XMLFolderPath] = _SdRvFolder;
                            }
                            else
                            {
                                DataRow sdrv_dr = _SdRvData.SdrvTable.NewRow();
                                _SdRvData.SdrvTable.Rows.Add(_SdRvData.SetSdrvDataRow(sdrv_dr, sdrv, dtls));
                                sdrv_dr[TspSendTableCls.SDR_XMLSdrvPath] = _SdRvDtFile;
                                sdrv_dr[TspSendTableCls.SDR_XMLDtlPath] = _SdRvDtlFile;
                                sdrv_dr[TspSendTableCls.SDR_XMLFolderPath] = _SdRvFolder;
                                
                                //サーチテーブルに登録
                                if (_SdRvData.SerchTable[sdrv.EnterpriseCode + sdrv.TspCommNo.ToString("d9")] == null)
                                {
                                    ArrayList ar = new ArrayList();
                                    ar.Add(sdrv_dr);
                                    _SdRvData.SerchTable.Add((sdrv.EnterpriseCode + sdrv.TspCommNo.ToString("d9")), ar);
                                }
                                else
                                {
                                    ArrayList ar = (ArrayList)_SdRvData.SerchTable[sdrv.EnterpriseCode + sdrv.TspCommNo.ToString("d9")];
                                    ar.Add(sdrv_dr);
                                }
                            }
                        }
                    }
                }
            }
            return st;
        }
        #endregion

        #region カラム作成
        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }
        #endregion

        /// <summary>
        /// 送信（未送信、エラー）のデータを送信する
        /// </summary>
        /// <returns></returns>
        public int Send()
        {
            ArrayList tspDataList = new ArrayList();

            // フィルタ式
            _SdRvData.WrokView.RowFilter = String.Format("{0}=0", TspSendTableCls.SDR_CommConditionDivCd);

            Hashtable ht = new Hashtable();
            foreach (DataRowView drv in _SdRvData.WrokView)
            {
                //HashTableに登録済みの場合は何もしない
                TspSdRvDt tspdt = (TspSdRvDt)drv[TspSendTableCls.SDR_DataClass];
                if (ht[tspdt.EnterpriseCode + tspdt.TspCommNo.ToString("d9")] == null)
                {

                    ArrayList ar = (ArrayList)_SdRvData.SerchTable[tspdt.EnterpriseCode + tspdt.TspCommNo.ToString("d9")];
                    DataRow wk_dr = null;
                    TspSdRvDt wk_tspdt = null;
                    foreach (DataRow dr in ar)
                    {
                        TspSdRvDt tspdt2 = (TspSdRvDt)dr[TspSendTableCls.SDR_DataClass];
                        if (wk_tspdt == null)
                        {
                            wk_tspdt = tspdt2;
                            wk_dr = dr;
                        }
                        else
                        {

                            if (wk_tspdt.TspCommCount < tspdt2.TspCommCount)
                            {
                                wk_tspdt = tspdt2;
                                wk_dr = dr;
                            }
                        }
                    }
                    ht.Add(wk_tspdt.EnterpriseCode + wk_tspdt.TspCommNo.ToString("d9"), wk_dr);
                }

            }

            foreach (DataRow dr in ht.Values)
            {
                Broadleaf.Application.UIData.TspServiceData tspData = new Broadleaf.Application.UIData.TspServiceData();
                TspSdRvDt sdrv = (TspSdRvDt)dr[TspSendTableCls.SDR_DataClass];
                TspSdRvDtl[] dtlList = (TspSdRvDtl[])dr[TspSendTableCls.DTL_DataClass];
                tspData.TspSdRvDtlDataList = dtlList;
                tspData.TspSdRvData = sdrv;
                tspDataList.Add(tspData);
            }

            if (tspDataList.Count == 0) return 0;

            // サービスクライアントをインスタンス化
            TSPServiceClientForPM tspSClient = new TSPServiceClientForPM();
            // 送信データの作成
            TspServiceDataManager sendDataParam = new TspServiceDataManager();

            // TSP送受信データ検索の条件を指定
            sendDataParam.EnterpriseCode = this._pm_EnterpriseCD;	//企業コード
            sendDataParam.TspServiceDataList = (TspServiceData[])tspDataList.ToArray(typeof(TspServiceData));

            try
            {
                // TSP送受信データ
                int _stat = tspSClient.SendPMTspData(sendDataParam);
                // 送信結果を判定（マイナスはエラー）
                if (_stat < 0) {
                    WriteErrorLog(String.Format("伝票登録失敗 {0}：{1}", _stat, TSPServiceMessageHelperForPM.GetMessage(_stat)));
                    return -1;
                } 

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                return -1;
            }

            // 送信に成功した時は、送信データ(XML)に
            //未送信と送信エラーの全てのデータに送信済みをセット
            TspRequest[] tspRequestList = sendDataParam.ResultTspRequestList;
            foreach (TspRequest tres in tspRequestList)
            {
                if (tres.CommConditionDivCd == 9)
                {
                    WriteErrorLog(String.Format("伝票登録失敗 通信番号[{0}]", tres.TspCommNo));
                }
                ArrayList ar = (ArrayList)_SdRvData.SerchTable[tres.EnterpriseCode + tres.TspCommNo.ToString("d9")];

                foreach (DataRow dr3 in ar)
                {
                    TspSdRvDt sdrv = (TspSdRvDt)dr3[TspSendTableCls.SDR_DataClass];
                    //未送信でエラーになった伝票は９にする。
                    if (tres.CommConditionDivCd == 9 && sdrv.CommConditionDivCd == 0)
                    {
                        dr3[TspSendTableCls.SDR_CommConditionDivCd] = 9;
                    }
                    else
                    {
                        dr3[TspSendTableCls.SDR_CommConditionDivCd] = 1;
                        if (sdrv.CommConditionDivCd == 0)
                        {
                            string _SdRvDtFile = (string)dr3[TspSendTableCls.SDR_XMLSdrvPath];
                            sdrv.CommConditionDivCd = 1;
                            sdrv.PmSendDate = System.DateTime.Now;
                            using (System.IO.FileStream stream = new System.IO.FileStream(_SdRvDtFile, System.IO.FileMode.Create))
                            {
                                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Broadleaf.Application.UIData.TspSdRvDt));
                                MemoryStream memstr = new MemoryStream();
                                serializer.Serialize(memstr, sdrv);
                                byte[] buff = TSPSendXMLWriter.EncryptXML(memstr);
                                stream.Write(buff, 0, buff.Length);
                                stream.Close();
                            }
                        }
                    }
                }
            }

            return 0;

        }

        /// <summary>
        /// ステータスチェック（送信済→処理済のチェック）
        /// </summary>
        /// <returns>処理済に変更した数、マイナスはエラー</returns>
        public int Check()
        {
            int iCnt = 0;

            // フィルタ式
            _SdRvData.WrokView.RowFilter = String.Format("{0}=1", TspSendTableCls.SDR_CommConditionDivCd);

            ArrayList tspReqArr = new ArrayList();
            //HashTableで重複チェック
            Hashtable ht = new Hashtable();
            //WEBサーバーに問い合わせ
            foreach (DataRowView drv in _SdRvData.WrokView)
            {
                TspSdRvDt tspdt = (TspSdRvDt)drv[TspSendTableCls.SDR_DataClass];
                //HashTableに登録済みの場合は何もしない
                if ( ht[tspdt.EnterpriseCode + tspdt.TspCommNo.ToString("d9")] ==null){
                    TspRequest tr = new TspRequest();
                    tr.PmEnterpriseCode = tspdt.PmEnterpriseCode;
                    tr.EnterpriseCode = tspdt.EnterpriseCode;
#if DEBUG
                    tr.PmEnterpriseCode = "8420200";
#endif
                    tr.TspCommNo = tspdt.TspCommNo;
                    tspReqArr.Add(tr);
                    ht.Add(tspdt.EnterpriseCode + tspdt.TspCommNo.ToString("d9"), tr);
                }
            }

            if (tspReqArr.Count == 0) return 0;

            TspRequest[] tspRequestList = (TspRequest[])tspReqArr.ToArray(typeof(TspRequest));

            TSPServiceClientForPM tspclnt = new TSPServiceClientForPM();
            try
            {
                int _stat = tspclnt.InquiryPMTspData(ref tspRequestList);
                //問い合わせが失敗した場合更新しないで終了
                // 送信結果を判定（マイナスはエラー）
                if (_stat < 0) 
                {
                    WriteErrorLog(String.Format("伝票問合せ失敗 {0}：{1}", _stat, TSPServiceMessageHelperForPM.GetMessage(_stat)));
                    return -1;
                }

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                return -1;
            }

            // 送受信データ (PMTSP01101E)
            foreach (TspRequest tres in tspRequestList)
            {
                int _CommConditionDivCd = tres.CommConditionDivCd;
                ArrayList ar =(ArrayList)_SdRvData.SerchTable[tres.EnterpriseCode + tres.TspCommNo.ToString("d9")];
                foreach (DataRow dr2 in ar)
                {
                    TspSdRvDt tspdt = (TspSdRvDt)dr2[TspSendTableCls.SDR_DataClass];
                    string _SdRvDtFile = (string)dr2[TspSendTableCls.SDR_XMLSdrvPath];
                    try
                    {
                        //区分が変更になっていたら更新する
                        //サーバーが処理済の場合
                        if (_CommConditionDivCd == 2)
                        {
                            //2:処理済をセット
                            tspdt.CommConditionDivCd = 2;
                            dr2[TspSendTableCls.SDR_CommConditionDivCd] = 2;
                            using (System.IO.FileStream stream = new System.IO.FileStream(_SdRvDtFile, System.IO.FileMode.Create))
                            {
                                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Broadleaf.Application.UIData.TspSdRvDt));
                                MemoryStream memstr = new MemoryStream();
                                serializer.Serialize(memstr, tspdt);
                                byte[] baff = TSPSendXMLWriter.EncryptXML(memstr);
                                stream.Write(baff, 0, baff.Length);
                                stream.Close();
                            }
                            iCnt++;
                        }
                        //ローカルにあるデータがサーバーにない場合
                        else if (_CommConditionDivCd == 9)
                        {
                            dr2[TspSendTableCls.SDR_CommConditionDivCd] = 9;
                            WriteErrorLog(String.Format("伝票問合せ失敗 TSP通信番号[{0}]", tres.TspCommNo));
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(ex.Message);
                    }
                }
            }
            return iCnt;
        }

        /// <summary>
        /// 自動削除（終了時に実行）
        /// </summary>
        /// <returns>削除した数、マイナスはエラー</returns>
        public int AutoDelete()
        {
            int iCnt = 0;

            DateTime limitdate = System.DateTime.Now;
            switch (_settinginfo.SaveDistance)
            {
                case 1:
                    {
                        limitdate = limitdate.AddMonths(-1);
                        break;
                    }
                case 2:
                    {
                        limitdate = limitdate.AddMonths(-3);
                        break;
                    }
            }

            // フィルタ式
            _SdRvData.WrokView.RowFilter = String.Format("{0} = 2", TspSendTableCls.SDR_CommConditionDivCd);

            ArrayList tspReqArr = new ArrayList();

            //WEBサーバーを消す（このフェーズでエラーが出ても対処しようが無いので処理はとめない）
            foreach (DataRowView drv in _SdRvData.WrokView)
            {
                TspSdRvDt tspdt = (TspSdRvDt)drv[TspSendTableCls.SDR_DataClass];
                if (tspdt.PmSendDate < limitdate)
                {
                    TspRequest tr = new TspRequest();
                    tr.PmEnterpriseCode = tspdt.PmEnterpriseCode;
#if DEBUG
                    tr.PmEnterpriseCode = "8420200";
#endif
                    tr.EnterpriseCode = tspdt.EnterpriseCode;
                    tr.TspCommNo = tspdt.TspCommNo;
                    tspReqArr.Add(tr);
                }
            }

            if (tspReqArr.Count == 0) return 0;
            TspRequest[] tspRequestList = (TspRequest[])tspReqArr.ToArray(typeof(TspRequest));

            TSPServiceClientForPM tspclnt = new TSPServiceClientForPM();
            try
            {
                int _stat = tspclnt.DeletePMTspData(tspRequestList);
                //サーバー削除が失敗した場合削除しないで終了
                // 送信結果を判定（マイナスはエラー）
                if (_stat < 0) return -1;

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
                return -1;
            }

            //ローカルファイルを消す
            foreach (DataRowView drv in _SdRvData.WrokView)
            {
                TspSdRvDt tspdt = (TspSdRvDt)drv[TspSendTableCls.SDR_DataClass];
                if (tspdt.PmSendDate < limitdate)
                {
                    try
                    {
                        System.IO.File.Delete((string)drv[TspSendTableCls.SDR_XMLSdrvPath]);
                        System.IO.File.Delete((string)drv[TspSendTableCls.SDR_XMLDtlPath]);
                        string[] sl = Directory.GetFiles((string)drv[TspSendTableCls.SDR_XMLFolderPath]);
                        if (sl.Length == 0)
                        {
                            //ファイルが無くなったらフォルダも消す。
                            Directory.Delete((string)drv[TspSendTableCls.SDR_XMLFolderPath]);
                        }
                        iCnt++;
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(ex.Message);
                    }
                }
            }
            return iCnt;
        }

        /// <summary>
        /// ゴミ箱ファイルを削除
        /// </summary>
        /// <returns>削除したファイルの数、マイナスはエラー</returns>
        public int TrashDelete()
        {
            int iCnt = 0;
            ArrayList tspReqArr = new ArrayList();

            //WEBサーバーを消す（このフェーズでエラーが出ても対処しようが無いので処理はとめない）
            foreach (DataRow dr in _SdRvData.TrashTable.Rows)
            {
                TspSdRvDt tspdt = (TspSdRvDt)dr[TspSendTableCls.SDR_DataClass];
                TspRequest tr = new TspRequest();
                tr.PmEnterpriseCode = tspdt.PmEnterpriseCode;
#if DEBUG
                tr.PmEnterpriseCode = "8420200";
#endif
                tr.EnterpriseCode = tspdt.EnterpriseCode;
                tr.TspCommNo = tspdt.TspCommNo;
                tspReqArr.Add(tr);
            }
            if (tspReqArr.Count == 0) return 0;

            //ここでWEB削除アクセスクラス呼び出し。
            TspRequest[] tspRequestList = (TspRequest[])tspReqArr.ToArray(typeof(TspRequest));
            TSPServiceClientForPM tspclnt = new TSPServiceClientForPM();
            try
            {
                int _stat = tspclnt.DeletePMTspData(tspRequestList);
                //サーバー削除が失敗した場合削除しないで終了
                // 送信結果を判定（マイナスはエラー）
                if (_stat < 0) return -1;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
            }

            //ローカルファイルを消す
            foreach (DataRow dr in _SdRvData.TrashTable.Rows)
            {
                TspSdRvDt tspdt = (TspSdRvDt)dr[TspSendTableCls.SDR_DataClass];
                try
                {
                    System.IO.File.Delete((string)dr[TspSendTableCls.SDR_XMLSdrvPath]);
                    System.IO.File.Delete((string)dr[TspSendTableCls.SDR_XMLDtlPath]);
                    string[] sl = Directory.GetFiles((string)dr[TspSendTableCls.SDR_XMLFolderPath]);
                    if (sl.Length == 0)
                    {
                        //ファイルが無くなったらフォルダも消す。
                        Directory.Delete((string)dr[TspSendTableCls.SDR_XMLFolderPath]);
                    }
                    dr[TspSendTableCls.SDR_CommConditionDivCd] = 4;

                    iCnt++;
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex.Message);

                }
            }
 
            return iCnt;

        }


        /// <summary>
        /// データの単独削除:画面で削除ボタンを押した場合
        /// </summary>
        /// <param name="drv">DataRowView（グリッドの選択行）</param>
        /// <returns>失敗した場合false</returns>
        public bool Delete(DataRowView drv)
        {
            bool stat = false;

            ArrayList tspReqArr = new ArrayList();

            //WEBサーバーを消す（このフェーズでエラーが出ても対処しようが無いので処理はとめない）
            TspSdRvDt tspdt = (TspSdRvDt)drv[TspSendTableCls.SDR_DataClass];
            //未処理の場合はサーバーに送信しない
            if (tspdt.CommConditionDivCd != 0)
            {
                TspRequest tr = new TspRequest();
                tr.PmEnterpriseCode = tspdt.PmEnterpriseCode;
#if DEBUG
                //tr.PmEnterpriseCode = "8420200";
#endif
                tr.EnterpriseCode = tspdt.EnterpriseCode;
                tr.TspCommNo = tspdt.TspCommNo;
                tspReqArr.Add(tr);

                //ここでWEB削除アクセスクラス呼び出し。引数はArrayList
                TspRequest[] tspRequestList = (TspRequest[])tspReqArr.ToArray(typeof(TspRequest));
                TSPServiceClientForPM tspclnt = new TSPServiceClientForPM();
                try
                {
                    int _stat = tspclnt.DeletePMTspData(tspRequestList);
                    //サーバー削除が失敗しても強制終了可能とする
                    // 送信結果を判定（マイナスはエラー）
                    if (_stat < 0) 
                    {
                        if (MessageBox.Show("Webサーバーのデータが削除出来ませんでした。\nローカルデータを削除しますか？",
                            "削除エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return false;
                    }
                }
                catch (Exception ex)
                {
                    WriteErrorLog(ex.Message);
                }

            }
            //ローカルファイルを消す
            try
            {
                System.IO.File.Delete((string)drv[TspSendTableCls.SDR_XMLSdrvPath]);
                System.IO.File.Delete((string)drv[TspSendTableCls.SDR_XMLDtlPath]);
                string[] sl = Directory.GetFiles((string)drv[TspSendTableCls.SDR_XMLFolderPath]);
                if (sl.Length == 0)
                {
                    //ファイルが無くなったらフォルダも消す。
                    Directory.Delete((string)drv[TspSendTableCls.SDR_XMLFolderPath]);
                }
                drv[TspSendTableCls.SDR_CommConditionDivCd] = 4;
                _SdRvData.SdrvTable.AcceptChanges();
                stat = true;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex.Message);
            }

            return stat;

        }

        /// <summary>
        /// 対象伝票の取得
        /// </summary>
        public void GetSlipCnt()
        {
            _SdRvData.WrokView.RowFilter = "";
            
            // フィルタ式(SF企業コード、通信状態＝０：未送信)
            _SdRvData.WrokView.RowFilter = String.Format("{0}=0 ", TspSendTableCls.SDR_CommConditionDivCd);
            _stat0Cnt = _SdRvData.WrokView.Count;

            // フィルタ式(SF企業コード、通信状態＝０：未送信)
            _SdRvData.WrokView.RowFilter = String.Format("{0}=1 ", TspSendTableCls.SDR_CommConditionDivCd);
            _stat1Cnt = _SdRvData.WrokView.Count;

            // フィルタ式(SF企業コード、通信状態＝０：未送信)
            _SdRvData.WrokView.RowFilter = String.Format("{0}=2 ", TspSendTableCls.SDR_CommConditionDivCd);
            _stat2Cnt = _SdRvData.WrokView.Count;

        }

        public void WriteErrorLog(string Msg)
        {
            if (_TextWriter != null)
            {
                string s = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                _TextWriter.WriteLine(s + "  " + Msg);
            }
            
        }

        /// <summary>
        /// ログファイルをオープンする
        /// 排他処理も兼ねる（リトライ6回）
        /// </summary>
        /// <returns>-1の時はオープン失敗</returns>
        public int OpenErrorLog()
        {
            int iCnt = 0;
            while (iCnt < 5)
            {
                try
                {
                    _TextWriter = new System.IO.StreamWriter(this.LogFilePath, true, System.Text.Encoding.GetEncoding("SHIFT-JIS"));
                    return 0;
                }
                catch
                {
                    iCnt++;
                    System.Threading.Thread.Sleep(1000);
                }
            }
            return -1;
        }
        /// <summary>
        /// エラーログの保存と終了
        /// </summary>
        public void CloseErrorLog()
        {
            if (_TextWriter != null)
            {
                _TextWriter.Close();
            }
        }

    }


    /// <summary>
    /// TSP送信先得意先テーブルクラス
    /// </summary>
    public class TspCustomer
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TspCustomer()
        {
            _SfEnterpriseCode = "";
            _PmEnterpriseCode = "";
            _PmCustomerCode = 0;
            _PmCustomerName = "";
        }
        #endregion

        #region フィールド

        public const string CUST_SfEnterpriseCode = "CUST_0001";	//SF企業コード			SFの企業コード	
        public const string CUST_PmEnterpriseCode = "CUST_0002";	//PM企業コード			部品商の企業コード	
        public const string CUST_PmCustomerCode = "CUST_0003";	//得意先コード			部品商の得意先コード	
        public const string CUST_PmCustomerName = "CUST_0004";	//得意先名			部品商の得意先名	
        #endregion

        #region プロパティ
        private string _SfEnterpriseCode;
        private string _PmEnterpriseCode;
        private int _PmCustomerCode;
        private string _PmCustomerName;

        /// <summary>
        /// 送受信データテーブル
        /// </summary>
        public string SfEnterpriseCode
        {
            set { _SfEnterpriseCode = value; }

            get { return _SfEnterpriseCode; }
        }
        /// <summary>
        /// 送受信明細データテーブル
        /// </summary>
        public string PmEnterpriseCode
        {
            set { _PmEnterpriseCode = value; }

            get { return _PmEnterpriseCode; }
        }
        /// <summary>
        /// 送受信データView
        /// </summary>
        public int PmCustomerCode
        {
            set { _PmCustomerCode = value; }

            get { return _PmCustomerCode; }
        }
        /// <summary>
        /// 送受信明細データView
        /// </summary>
        public string PmCustomerName
        {
            set { _PmCustomerName = value; }

            get { return _PmCustomerName; }
        }

        #endregion
    }

    /// <summary>
    /// 送信データテーブルクラス
    /// </summary>
    public class TspSendTableCls
    {
        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TspSendTableCls()
        {
            this._dataSet = new DataSet();
            this._dataSet.Tables.Add(CreateTable(SDR_TABLENAME));
            this._dataSet.Tables.Add(CreateTable(TRASH_TABLENAME));
            this._workView = new DataView(_dataSet.Tables[SDR_TABLENAME]);
            this._hashTable = new Hashtable();

        }

        #endregion

        #region フィールド

        private DataSet _dataSet = null;
        private Hashtable _hashTable = null;
        private DataView _workView = null;

        #endregion

        #region プロパティ

        /// <summary>
        /// 検索テーブル
        /// </summary>
        public Hashtable SerchTable
        {
            get { return this._hashTable; }
        }

        /// <summary>
        /// 送受信データテーブル
        /// </summary>
        public DataTable SdrvTable
        {
            get { return this._dataSet.Tables[SDR_TABLENAME]; }
        }

        /// <summary>
        /// 送受信データテーブル
        /// </summary>
        public DataTable TrashTable
        {
            get { return this._dataSet.Tables[TRASH_TABLENAME]; }
        }

        /// <summary>
        /// 送受信データView
        /// </summary>
        public DataView SdrvView
        {
            get { return this._dataSet.Tables[SDR_TABLENAME].DefaultView; }
        }

        /// <summary>
        /// 送受信データView
        /// </summary>
        public DataView TrashView
        {
            get { return this._dataSet.Tables[TRASH_TABLENAME].DefaultView; }
        }

        /// <summary>
        /// 送受信データView
        /// </summary>
        public DataView WrokView
        {
            get { return this._workView; }
        }

        #endregion

        #region 送受信データ
        public const string SDR_TABLENAME = "TspSdRvDt_Table";
        public const string TRASH_TABLENAME = "TspTrashDt_Table";
        public const string SDR_SfEnterpriseCode = "SDR_0001";	//SF企業コード			SFの企業コード	
        public const string SDR_PmEnterpriseCode = "SDR_0002";	//PM企業コード			部品商の企業コード	
        public const string SDR_TspCommNo = "SDR_0003";	        //TSP通信番号			１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)
        public const string SDR_TspCommCount = "SDR_0004";	    //TSP通信回数			PM側が１発注に対して回答を行う回数
        public const string SDR_InstSlipNoStr = "SDR_0006";	    //指示書番号（文字列）	文字型
        public const string SDR_AcceptAnOrderNo = "SDR_0007";	//受注番号				発注側(SF・BK)の受注番号
        public const string SDR_SlipNo = "SDR_0009";	        //伝票番号				   
        public const string SDR_SlipKind = "SDR_0010";      	//伝票種別				10:見積,20:指示,21:承り書,30:納品,40:加修
        public const string SDR_CommConditionDivCd = "SDR_0011";	//通信状態区分			0:SF・BK発注中,1:PM受注中,2:PM納期回答中,3:PM一部回答中,4:PM全回答中,9:完
        public const string SDR_AcceptAnOrderDate = "SDR_0037";	//受注日				YYYYMMDD
        public const string SDR_PmSlipNo = "SDR_0038";	        //PM伝票番号				
        public const string SDR_TspTotalSlipPrice = "SDR_0039";	//TSP伝票合計金額		
        public const string SDR_PmComment = "SDR_0041";     	//PMコメント				
        public const string SDR_PmSlipKind = "SDR_0042";	        //PM伝票番号				   
        public const string SDR_XMLSdrvPath = "SDR_1000";	//XMLソースパス
        public const string SDR_XMLDtlPath = "SDR_1001";	//XMLソースパス
        public const string SDR_XMLFolderPath = "SDR_1002";	//XMLソースパス
        public const string SDR_FixDivCd = "SDR_9996";	        //確定
        public const string SDR_LogicalDeleteCode = "SDR_9997";	//論理削除区分
        public const string SDR_RowStatus = "SDR_9998";	        //ステータス
        public const string SDR_DataClass = "SDR_9999";	        //データクラス
        //送受信明細データ
        public const string DTL_DataClass = "DTL_9999";	//データクラス

        #endregion



        #region プライベイトメソッド

        /// <summary>
        /// データテーブルを作成する
        /// </summary>
        public DataTable GetTable(string tableName)
        {
            return this._dataSet.Tables[tableName];
        }

        /// <summary>
        /// データテーブルを作成する
        /// </summary>
        private DataTable CreateTable(string tableName)
        {
            DataTable dt = new DataTable(tableName);

            //カラムの定義
            dt.Columns.Add(CreateColumn(SDR_SfEnterpriseCode, typeof(string), "SF企業コード"));	//通信状態区分			
            dt.Columns.Add(CreateColumn(SDR_CommConditionDivCd, typeof(int), "通信状態"));	//通信状態区分			
            dt.Columns.Add(CreateColumn(SDR_InstSlipNoStr, typeof(string), "指示書番号"));	//指示書番号（文字列）	
            dt.Columns.Add(CreateColumn(SDR_PmSlipKind, typeof(int), "伝票種別"));	//伝票種別				
            dt.Columns.Add(CreateColumn(SDR_AcceptAnOrderDate, typeof(string), "売上日付"));	//受注日		
            dt.Columns.Add(CreateColumn(SDR_PmSlipNo, typeof(string), "伝票番号"));	//PM伝票番号					
            dt.Columns.Add(CreateColumn(SDR_TspTotalSlipPrice, typeof(string), "合計金額"));	//TSP伝票合計金額					
            dt.Columns.Add(CreateColumn(SDR_PmComment, typeof(string), "備考"));	//PMコメント					
            dt.Columns.Add(CreateColumn(SDR_TspCommNo, typeof(string), "通信番号"));	//PMコメント					
            dt.Columns.Add(CreateColumn(SDR_XMLSdrvPath, typeof(string), ""));	//XMLソースパス
            dt.Columns.Add(CreateColumn(SDR_XMLDtlPath, typeof(string), ""));	//XMLソースパス
            dt.Columns.Add(CreateColumn(SDR_XMLFolderPath, typeof(string), ""));	//XMLソースフォルダ
            dt.Columns.Add(CreateColumn(SDR_DataClass, typeof(object), ""));	//伝票データクラス
            dt.Columns.Add(CreateColumn(DTL_DataClass, typeof(object), ""));	//明細データクラス

            return dt;
        }

        /// <summary>
        /// データテーブルの列を作成する
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="type">型</param>
        /// <param name="caption">キャプション</param>
        /// <returns></returns>
        public DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }

        /// <summary>
        /// 指定の行に送受信データをセット
        /// </summary>
        /// <returns>セット後のデータ行</returns>
        public DataRow SetSdrvDataRow(DataRow dr, Broadleaf.Application.UIData.TspSdRvDt sdrv, TspSdRvDtl[] dtls)
        {
            dr[SDR_SfEnterpriseCode] = sdrv.EnterpriseCode;	//EnterpriseCode
            dr[SDR_CommConditionDivCd] = sdrv.CommConditionDivCd;	//通信状態区分
            dr[SDR_InstSlipNoStr] = sdrv.InstSlipNoStr;	//指示書番号（文字列）	
            //☆
            dr[SDR_PmSlipKind] = sdrv.PmSlipKind;	//伝票種別		
            if (sdrv.TspCommCount > 0)
            {
                dr[SDR_PmSlipKind] = sdrv.PmSlipKind + 1;	//伝票種別
            }
            dr[SDR_AcceptAnOrderDate] = sdrv.AcceptAnOrderDate;	//受注日				
            dr[SDR_PmSlipNo] = sdrv.PmSlipNo;	//PM伝票番号
            dr[SDR_TspTotalSlipPrice] = sdrv.TspTotalSlipPrice;	//TSP伝票合計金額
            dr[SDR_TspCommNo] = sdrv.TspCommNo;	//PMコメント
            dr[SDR_PmComment] = sdrv.PmComment;	//PMコメント
            dr[SDR_DataClass] = sdrv;	//伝票データクラス
            dr[DTL_DataClass] = dtls;	//明細データクラス

            return dr;
        }

        #endregion

        #region パブリックメソッド

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfEnterpriseCode"></param>
        /// <returns></returns>
        public void SetRowFilter(string sfEnterpriseCode)
        {
            // フィルタ式
            SdrvView.RowFilter = String.Format("{0}='{1}'", SDR_SfEnterpriseCode, sfEnterpriseCode);
            SdrvView.Sort = SDR_PmSlipNo;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfEnterpriseCode"></param>
        /// <param name="CommConditionDivCd"></param>
        public void SetRowFilter(string SfEnterpriseCode, int[] CommConditionDivCd)
        {
            string s = "";
            if (SfEnterpriseCode == "") return;
            string rowfilter = "";
            rowfilter = " AND ( ";

            foreach (int divcd in CommConditionDivCd)
            {
                // フィルタ式
                rowfilter += s + String.Format(" {0}={1}", SDR_CommConditionDivCd, divcd);
                s = " OR ";

            }
            rowfilter += " )";

            SdrvView.RowFilter = String.Format("{0}='{1}'", SDR_SfEnterpriseCode, SfEnterpriseCode) + rowfilter;
            SdrvView.Sort = SDR_PmSlipNo;

        }

        #endregion
    }


    #region 設定情報クラス
    /// <summary>
    /// 画面情報クラス
    /// </summary>
    public class TspSendSettingInfo
    {
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMTSP01104U_UserSetting.XML";

        private const string CT_TSP_SEND_SEARCH = @"\TSP-SEND";
        private const string CT_TSP_SEND = "TSP-SEND";
        private const string CT_TMP = "Tmp";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TspSendSettingInfo()
        {
            PathData = new TspSndPathInfo();
        }

        ~TspSendSettingInfo()
        {
            Save(false);
        }

        //Filds
        private string _TSPSdRvDataPath = "";
        private int _SaveDistance = 0;
        private DateTime _LastDate = DateTime.MinValue;

        private string bk_TSPSdRvDataPath = "";
        private int bk_SaveDistance = 0;
        private DateTime bk_LastDate = DateTime.MinValue;

        // パス設定
        private TspSndPathInfo PathData;

        //Properties
        /// <summary>
        /// TSPパス
        /// </summary>
        public string TSPSdRvDataPath
        {
            get { return _TSPSdRvDataPath; }
            set { _TSPSdRvDataPath = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SaveDistance
        {
            get { return _SaveDistance; }
            set { _SaveDistance = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastDate
        {
            get { return _LastDate; }
            set { _LastDate = value; }
        }

        //Methods
        /// <summary>
        /// 画面情報を読み込む
        /// </summary>
        public int Load()
        {
            TspSendSettingInfo info = null;
            try
            {
                PathData.Load();

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TspSendSettingInfo));

                if (UserSettingController.ExistUserSetting(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
                {
                    info = UserSettingController.DeserializeUserSetting<TspSendSettingInfo>(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                else
                {
                    //ファイルが存在しない場合、何もしない
                    return -1;
                }

            }
            catch (Exception)
            {
            }

            if (info == null)
            {
                //読み取り失敗した場合は、自動送信設定情報を格納
                if (this.PathData.TspSndPath.IndexOf(CT_TSP_SEND_SEARCH) < 0)
                {
                    _TSPSdRvDataPath = Path.Combine(this.PathData.TspSndPath.Trim(), CT_TSP_SEND);
                }
                else
                {
                    _TSPSdRvDataPath = this.PathData.TspSndPath;
                }

                return -1;
            }
            else
            {
                this._SaveDistance = info.SaveDistance;
                this._TSPSdRvDataPath = info.TSPSdRvDataPath;
                this._LastDate = info.LastDate;


                this.bk_TSPSdRvDataPath = info.TSPSdRvDataPath;
                this.bk_SaveDistance = info.SaveDistance;
                this.bk_LastDate = info.LastDate;

                return 0;
            }
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        public void Save(bool overwrite)
        {
            if (_SaveDistance != bk_SaveDistance || _TSPSdRvDataPath != bk_TSPSdRvDataPath || bk_LastDate != LastDate || overwrite==true)
            {
                try
                {
                    if (_TSPSdRvDataPath.IndexOf(CT_TSP_SEND_SEARCH) < 0)
                    {
                        PathData.TspSndPath = _TSPSdRvDataPath.TrimEnd('\\');

                        // 手動送信パスは末尾"TSP-SEND"にする
                        _TSPSdRvDataPath = Path.Combine(_TSPSdRvDataPath, CT_TSP_SEND);
                    }
                    else
                    {
                        // 自動送信パスは末尾"TSP-SEND"を除く
                        PathData.TspSndPath = _TSPSdRvDataPath.Substring(0, _TSPSdRvDataPath.LastIndexOf(CT_TSP_SEND_SEARCH)).TrimEnd('\\');
                    }

                    // 手動送信パス保存
                    UserSettingController.SerializeUserSetting(this, Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                    // 自動送信パス保存
                    PathData.TspSndTmpPath = Path.Combine(PathData.TspSndPath.Substring(0, PathData.TspSndPath.LastIndexOf(@"\")), CT_TMP);

                    PathData.Save();
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 設定画面を表示
        /// </summary>
        public void Setting()
        {
            PMTSP01104UC _PMTSP01104UC = new PMTSP01104UC(this.TSPSdRvDataPath, this.SaveDistance);
            _PMTSP01104UC.ShowDialog();
            if (_PMTSP01104UC.DialogResult == DialogResult.OK)
            {
                this._SaveDistance = _PMTSP01104UC.SaveDist;
                this._TSPSdRvDataPath = _PMTSP01104UC.TSPDtPath;
                this.Save(true);
            }
        }
    }

    #endregion // 設定情報クラス


    # region [自動送信用設定ファイル]
    /// <summary>
    /// 前回値保持
    /// </summary>
    public class TspSndPathInfo
    {
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "TspSend_UserSetting.XML";

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

        /// <summary>
        /// 画面情報を読み込む
        /// </summary>
        public int Load()
        {
            TspSndPathInfo info = null;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TspSndPathInfo));

                if (UserSettingController.ExistUserSetting(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
                {
                    info = UserSettingController.DeserializeUserSetting<TspSndPathInfo>(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                else
                {
                    //読み取り失敗した場合は何もしない
                    return -1;
                }

            }
            catch (Exception)
            {
                //読み取り失敗した場合は何もしない
                return -1;
            }

            if (info == null)
            {
                //読み取り失敗した場合は何もしない
                return -1;

            }
            else
            {
                this._tspSndPath = info.TspSndPath;
                this._tspSndTmpPath = info.TspSndTmpPath;

                return 0;
            }
        }

        /// <summary>
        /// 設定を保存する
        /// </summary>
        public void Save()
        {
            try
            {
                UserSettingController.SerializeUserSetting(this, Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception)
            {
            }
        }

    }
    #endregion // [自動送信用設定ファイル]
}
