using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace PMKHN02830UC
{
    /// <summary>
    /// 画面の起動クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 画面を起動する</br>											
    /// <br>Programmer : zhujw</br>
    /// <br>Date       : K2014/05/08</br>											
    /// <br>管理番号   : 11070071-00 丸徳商会個別開発個別対応</br>	
    /// </remarks>	
    static class Program
    {
        private const string BLANKALL = "b2#_%";   //全角スペース
        private const string BLANKHALF = "b1#_%";  //半角スペース
        private const string BLANKDOUBLEQUOTE = "b3#_%";  //ダブルクォーテーションマーク

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 得意先(コード)
            string customerCode = string.Empty;

            // 得意先(名称)
            string customerSnm = string.Empty;

            // 請求先(コード)
            string claimCode  = string.Empty;

            // 請求先(名称)
            string claimSnm = string.Empty;

            // 郵便番号 
            string postNo = string.Empty;

            // 住所１
            string address1  = string.Empty;

            // 住所２
            string address2 = string.Empty;

            // 住所３
            string address3 = string.Empty;

            // 自宅電話
            string homeTelNo = string.Empty;

            // 自宅FAX
            string homeFaxNo = string.Empty;

            // 勤務先電話
            string officeTelNo = string.Empty;

            // 勤務先FAX
            string officeFaxNo = string.Empty;

            // 携帯電話
            string portableTelNo = string.Empty;

            // 純正ALL
            string pureCustRateGrpCode = string.Empty;

            // 優良ALL
            string excellentCustRateGrpCode  = string.Empty;

            // 得意先担当者
            string customerAgent = string.Empty;

            // 担当者(コード)
            string customerAgentCd = string.Empty;

            // 担当者名
            string customerAgentNm = string.Empty;

            // 業種(コード)
            string businessTypeCode = string.Empty;
            
            // 業種名
            string businessTypeName = string.Empty;

            // 地区(コード)
            string salesAreaCode = string.Empty;

            // 地区(名称)
            string salesAreaName = string.Empty;

            // 売掛区分
            string accRecDivCd = string.Empty;

            // 締日
            string TotalDay = string.Empty;

            // 集金月
            string collectMoneyName = string.Empty;

            // 集金日
            string collectMoneyDay = string.Empty;

            // 回収条件
            string collectCond = string.Empty;

            // メモ
            string noteInfo = string.Empty;

            // 企業コード
            string enterpriseCode = string.Empty;

            // 自宅電話
            string homeTelNoDspName = string.Empty;

            // 勤務先電話
            string officeTelNoDspName = string.Empty;

            // 携帯電話
            string mobileTelNoDspName = string.Empty;

            // 自宅FAX
            string homeFaxNoDspName = string.Empty;

            // 勤務先FAX
            string officeFaxNoDspName = string.Empty;

            // PID 
            string PID = string.Empty;

            // UPD 2021/04/13 梶谷 >>>>>>>>>>
            // タイトルNo
            string titleNo = string.Empty;
            // UPD 2021/04/13 梶谷 <<<<<<<<<<

            if (args.Length > 0)
            {
                // 得意先(コード)
                if (!string.IsNullOrEmpty(args[0].Trim()))
                {
                    customerCode = GetNewString(args[0]);
                }
                // 得意先(名称)
                if (!string.IsNullOrEmpty(args[1].Trim()))
                {
                    customerSnm = GetNewString(args[1]);
                }
                // 請求先(コード)
                if (!string.IsNullOrEmpty(args[2].Trim()))
                {
                    claimCode = GetNewString(args[2]);
                }

                // 請求先(名称)
                if (!string.IsNullOrEmpty(args[3].Trim()))
                {
                    claimSnm = GetNewString(args[3]);
                }

                // 郵便番号 
                if (!string.IsNullOrEmpty(args[4].Trim()))
                {
                    postNo = GetNewString(args[4]);
                }

                // 住所１
                if (!string.IsNullOrEmpty(args[5].Trim()))
                {
                    address1 = GetNewString(args[5]);
                }

                // 住所２
                if (!string.IsNullOrEmpty(args[6].Trim()))
                {
                    address2 = GetNewString(args[6]);
                }

                // 住所３
                if (!string.IsNullOrEmpty(args[7].Trim()))
                {
                    address3 = GetNewString(args[7]);
                }

                // 自宅電話
                if (!string.IsNullOrEmpty(args[8].Trim()))
                {
                    homeTelNo = GetNewString(args[8]);
                }

                // 自宅FAX
                if (!string.IsNullOrEmpty(args[9].Trim()))
                {
                    homeFaxNo = GetNewString(args[9]);
                }

                // 勤務先電話
                if (!string.IsNullOrEmpty(args[10].Trim()))
                {
                    officeTelNo = GetNewString(args[10]);
                }

                // 勤務先FAX
                if (!string.IsNullOrEmpty(args[11].Trim()))
                {
                    officeFaxNo = GetNewString(args[11]);
                }

                // 携帯電話
                if (!string.IsNullOrEmpty(args[12].Trim()))
                {
                    portableTelNo = GetNewString(args[12]);
                }

                // 純正ALL
                if (!string.IsNullOrEmpty(args[13].Trim()))
                {
                    pureCustRateGrpCode = GetNewString(args[13]);
                }

                // 優良ALL
                if (!string.IsNullOrEmpty(args[14].Trim()))
                {
                    excellentCustRateGrpCode = GetNewString(args[14]);
                }

                // 得意先担当者
                if (!string.IsNullOrEmpty(args[15].Trim()))
                {
                    customerAgent = GetNewString(args[15]);
                }

                // 担当者(コード)
                if (!string.IsNullOrEmpty(args[16].Trim()))
                {
                    customerAgentCd = GetNewString(args[16]);
                }

                // 担当者名
                if (!string.IsNullOrEmpty(args[17].Trim()))
                {
                    customerAgentNm = GetNewString(args[17]);
                }

                // 業種(コード)
                if (!string.IsNullOrEmpty(args[18].Trim()))
                {
                    businessTypeCode = GetNewString(args[18]);
                }

                // 業種名
                if (!string.IsNullOrEmpty(args[19].Trim()))
                {
                    businessTypeName = GetNewString(args[19]);
                }

                // 地区(コード)
                if (!string.IsNullOrEmpty(args[20].Trim()))
                {
                    salesAreaCode = GetNewString(args[20]);
                }

                // 地区(名称)
                if (!string.IsNullOrEmpty(args[21].Trim()))
                {
                    salesAreaName = GetNewString(args[21]);
                }

                // 売掛区分
                if (!string.IsNullOrEmpty(args[22].Trim()))
                {
                    accRecDivCd = GetNewString(args[22]);
                }

                // 締日
                if (!string.IsNullOrEmpty(args[23].Trim()))
                {
                    TotalDay = GetNewString(args[23]);
                }

                // 集金月
                if (!string.IsNullOrEmpty(args[24].Trim()))
                {
                    collectMoneyName = GetNewString(args[24]);
                }

                // 集金日
                if (!string.IsNullOrEmpty(args[25].Trim()))
                {
                    collectMoneyDay = GetNewString(args[25]);
                }

                // 回収条件
                if (!string.IsNullOrEmpty(args[26].Trim()))
                {
                    collectCond = GetNewString(args[26]);
                }

                // メモ
                if (!string.IsNullOrEmpty(args[27].Trim()))
                {
                    noteInfo = GetNewString(args[27]);
                }

                // 自宅電話
                if (!string.IsNullOrEmpty(args[28].Trim()))
                {
                    homeTelNoDspName = GetNewString(args[28]);
                }

                // 勤務先電話
                if (!string.IsNullOrEmpty(args[29].Trim()))
                {
                    officeTelNoDspName = GetNewString(args[29]);
                }

                // 携帯電話
                if (!string.IsNullOrEmpty(args[30].Trim()))
                {
                    mobileTelNoDspName = GetNewString(args[30]);
                }

                // 自宅FAX
                if (!string.IsNullOrEmpty(args[31].Trim()))
                {
                    homeFaxNoDspName = GetNewString(args[31]);
                }

                // 勤務先FAX
                if (!string.IsNullOrEmpty(args[32].Trim()))
                {
                    officeFaxNoDspName = GetNewString(args[32]);
                }

                // PID
                if (!string.IsNullOrEmpty(args[33].Trim()))
                {
                    PID = GetNewString(args[33]);
                }

                // UPD 2021/04/13 梶谷 >>>>>>>>>>
                // タイトルNo
                if (!string.IsNullOrEmpty(args[34].Trim()))
                {
                    titleNo = GetNewString(args[34]);
                }
                // UPD 2021/04/13 梶谷 <<<<<<<<<<

            }

            // UPD 2021/04/13 梶谷 >>>>>>>>>>
            //Application.Run(new PMKHN02830UCA(customerCode, customerSnm, claimCode,
            // claimSnm, postNo, address1, address2,
            // address3, homeTelNo, officeTelNo, portableTelNo,
            // homeFaxNo, officeFaxNo, pureCustRateGrpCode, excellentCustRateGrpCode,
            // customerAgent, customerAgentCd, customerAgentNm, businessTypeCode,
            // businessTypeName, salesAreaCode, salesAreaName,
            // accRecDivCd, TotalDay, collectMoneyName, collectMoneyDay,
            // collectCond, noteInfo, homeTelNoDspName, officeTelNoDspName, mobileTelNoDspName, homeFaxNoDspName, officeFaxNoDspName,PID));
            Application.Run(new PMKHN02830UCA(customerCode,  customerSnm,  claimCode, 
             claimSnm,  postNo, address1,  address2,
             address3, homeTelNo, officeTelNo, portableTelNo,
             homeFaxNo,  officeFaxNo,  pureCustRateGrpCode,  excellentCustRateGrpCode,
             customerAgent, customerAgentCd, customerAgentNm, businessTypeCode,
             businessTypeName, salesAreaCode, salesAreaName,
             accRecDivCd, TotalDay, collectMoneyName, collectMoneyDay,
             collectCond, noteInfo, homeTelNoDspName, officeTelNoDspName, mobileTelNoDspName, homeFaxNoDspName, officeFaxNoDspName, PID, titleNo));
            // UPD 2021/04/13 梶谷 <<<<<<<<<<
        }

        static string GetNewString(string stringValue)
        {
            string Info = string.Empty;
            string Info2 = string.Empty;
            string info3 = string.Empty;
            Info = stringValue.Replace(BLANKHALF, " ");
            Info2 = Info.Replace(BLANKALL, "　");
            info3 = Info2.Replace(BLANKDOUBLEQUOTE, "\"");
            return info3;
        }
    }
}