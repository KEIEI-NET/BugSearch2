//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先ガイド
//                    PMKHN02830UC.exe
// プログラム概要   : 得意先ガイドの新規
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : zhujw
// 修 正 日  K2014/05/08 修正内容 : 丸徳商会個別開発個別対応、新規作成
// 管理番号  11770021-00 作成担当 : 32653   梶谷 貴士
// 修 正 日  2021/04/13 修正内容 : 得意先情報ガイド表示PKG対応
// 管理番号  11770021-00 作成担当 : 譚洪
// 修 正 日  2021/06/21 修正内容 : 得意先情報ガイド表示の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
// ADD 2021/04/13 梶谷 >>>>>>>>>>
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
// ADD 2021/04/13 梶谷 <<<<<<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>											
    /// 得意先ガイドUIクラス											
    /// </summary>											
    /// <remarks>											
    /// <br>Note       : 得意先ガイドUIクラス</br>											
    /// <br>Programmer : zhujw</br>
    /// <br>Date       : K2014/05/08</br>											
    /// <br>管理番号   : 11070071-00 丸徳商会個別開発個別対応</br>			
    /// <br>Programmer : 32653 梶谷 貴士</br>
    /// <br>Date       : 2021/04/13</br>											
    /// <br>管理番号   : 11770021-00 得意先情報ガイド表示PKG対応</br>		
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2021/06/21</br>
    /// <br>管理番号   : 11770021-00 得意先情報ガイド表示の対応</br>
    public partial class PMKHN02830UCA : Form
    {
        private const string XML_NAME_SALE = "MAHNB01001U";  // 売上伝票入力
        // ADD 2021/04/13 梶谷 >>>>>>>>>>
        private const string xPathDocPath = "PMKHN02830U_CustomerGuideDis.XML";
        private const string PartsmanPass = @"SOFTWARE\Broadleaf\Product\Partsman"; //Partsmanフォルダのパス
        private const string InstallDirectory = "InstallDirectory"; //インストールディレクトリ
        private const string elePosCustomer = "PosCustomer"; //得意先
        private const string eleCustomerClaim = "CustomerClaim"; //請求先
        private const string elePostNo = "PostNo"; //郵便番号
        private const string eleAddress = "Address"; //住所
        private const string eleHomeTelNoFaxNo = "HomeTelNoFaxNo"; //自宅電話/FAX
        private const string eleOfficeTelNoFaxNo = "OfficeTelNoFaxNo"; //勤務先電話/FAX
        private const string eleCellphoneNo = "CellphoneNo"; //携帯電話
        private const string elePureAll = "PureAll"; //純正ALL
        private const string elePrimeAll = "PrimeAll"; //優良ALL
        private const string eleAgent = "Agent"; //担当者
        private const string eleCustomerAgent = "CustomerAgent"; //得意先担当者
        private const string eleBusinessType = "BusinessType"; //業種
        private const string eleArea = "Area"; //地区
        private const string eleAccRecDiv = "AccRecDiv"; //売掛区分
        private const string eleCollectMoney = "CollectMoney"; //締日/回収月/回収日/回収条件
        private const string eleMemo = "Memo"; //メモ
        private const string CHECK_ON = "1"; //チェックがON
        private const int Top_Space = 15; //画面上部から各項目までの距離
        private const int Down_Space = 44; //画面下部から各項目までの距離
        private const int defItmHeight = 20; //各項目の高さ
        private const int defaultSize_Width = 592; //デフォルトの得意先情報ガイド画面の横幅
        private const int defaultSize_Height = 561; //デフォルトの得意先情報ガイド画面の縦幅
        // ログ出力部品
        OutLogCommon LogCommon;
        // クライアントログ出力内容
        private const string ErrorMessage1 = "PMKHN002830UC Ok_Button_Click XMLデータ取得で例外発生";
        private const string ErrorMessage2 = "PMKHN002830UC selectByXML XMLパス取得で例外発生";
        // PGID
        private const string CtPGID = "PMKHN002830UC";
        // ADD 2021/04/13 梶谷 <<<<<<<<<<
        private int _pID;
        // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 ----->>>>>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);
        private static bool ChangeState = false;

        private const int UFlags = 0x53;
        private const int LocationZero = 0;
        private const int KEY_ESC = 27;
        // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 -----<<<<<

        /// <summary>
        /// 得意先ガイドクラスコンストラクタ
        /// </summary>
        /// <param name="customerCode">得意先(コード)</param>
        /// <param name="customerSnm">得意先(名称)</param>
        /// <param name="claimCode">請求先(コード)</param>
        /// <param name="claimSnm">請求先(名称)</param>
        /// <param name="postNo">郵便番号</param>
        /// <param name="address1">住所１</param>
        /// <param name="address2">住所3</param>
        /// <param name="address3">住所4</param>
        /// <param name="homeTelNo">自宅電話</param>
        /// <param name="officeTelNo">自宅FAX</param>
        /// <param name="portableTelNo">勤務先電話</param>
        /// <param name="homeFaxNo">勤務先FAX</param>
        /// <param name="officeFaxNo">携帯電話</param>
        /// <param name="pureCustRateGrpCode">純正ALL</param>
        /// <param name="excellentCustRateGrpCode">優良ALL</param>
        /// <param name="customerAgent">得意先担当者</param>
        /// <param name="customerAgentCd">担当者(コード)</param>
        /// <param name="customerAgentNm">担当者名</param>
        /// <param name="businessTypeCode">業種(コード)</param>
        /// <param name="businessTypeName">業種名</param>
        /// <param name="salesAreaCode">地区(コード)</param>
        /// <param name="salesAreaName">地区(名称)</param>
        /// <param name="accRecDivCd">売掛区分</param>
        /// <param name="TotalDay">締日</param>
        /// <param name="collectMoneyName">集金月</param>
        /// <param name="collectMoneyDay">集金日</param>
        /// <param name="collectCond">回収条件</param>
        /// <param name="noteInfo">メモ</param>
        /// <param name="homeTelNoDspName">自宅電話</param>
        /// <param name="officeTelNoDspName">勤務先電話</param>
        /// <param name="mobileTelNoDspName">携帯電話</param>
        /// <param name="homeFaxNoDspName">自宅FAX</param>
        /// <param name="officeFaxNoDspName">勤務先FAX</param>
        /// <param name="PID">ProcessID</param>
        /// <param name="titleNo">タイトルNo</param>
        // UPD 2021/04/13 梶谷 >>>>>>>>>>
        //public PMKHN02830UCA(string customerCode, string customerSnm, string claimCode, 
        //    string claimSnm, string postNo,string address1, string address2,
        //    string address3,string homeTelNo,string officeTelNo,string portableTelNo,
        //    string homeFaxNo, string officeFaxNo, string pureCustRateGrpCode, string excellentCustRateGrpCode,
        //    string customerAgent,string customerAgentCd,string customerAgentNm,string businessTypeCode,
        //    string businessTypeName,string salesAreaCode,string salesAreaName,
        //    string accRecDivCd,string TotalDay,string collectMoneyName,string collectMoneyDay,
        //    string collectCond, string noteInfo,string homeTelNoDspName,
        //    string officeTelNoDspName,string mobileTelNoDspName,string homeFaxNoDspName,string officeFaxNoDspName,string PID)
        public PMKHN02830UCA(string customerCode, string customerSnm, string claimCode, 
            string claimSnm, string postNo,string address1, string address2,
            string address3,string homeTelNo,string officeTelNo,string portableTelNo,
            string homeFaxNo, string officeFaxNo, string pureCustRateGrpCode, string excellentCustRateGrpCode,
            string customerAgent,string customerAgentCd,string customerAgentNm,string businessTypeCode,
            string businessTypeName,string salesAreaCode,string salesAreaName,
            string accRecDivCd,string TotalDay,string collectMoneyName,string collectMoneyDay,
            string collectCond, string noteInfo,string homeTelNoDspName,
            string officeTelNoDspName,string mobileTelNoDspName,string homeFaxNoDspName,string officeFaxNoDspName,string PID,string titleNo)
        // UPD 2021/04/13 梶谷 <<<<<<<<<<
        {
            InitializeComponent();

            // ADD 2021/04/13 梶谷 >>>>>>>>>>
            // タイトルNo
            if (!string.IsNullOrEmpty(titleNo.Trim()))
            {
                // タイトル
                this.Text = this.Text + titleNo;
            }
            // ADD 2021/04/13 梶谷 <<<<<<<<<<

            // PID
            if (!string.IsNullOrEmpty(PID))
            {
                _pID = Convert.ToInt32(PID);
            }

            if (!string.IsNullOrEmpty(homeTelNoDspName.Trim()))
            {
                // 自宅電話
                this.uLabel_HomeTelNoDspName.Text = homeTelNoDspName;
            }
            else
            {
                this.uLabel_HomeTelNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(officeTelNoDspName.Trim()))
            {
                // 勤務先電話
                this.uLabel_OfficeTelNoDspName.Text = officeTelNoDspName;
            }
            else
            {
                this.uLabel_OfficeTelNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(mobileTelNoDspName.Trim()))
            {
                // 携帯電話
                this.uLabel_MobileTelNoDspName.Text = mobileTelNoDspName;
            }
            else
            {
                this.uLabel_MobileTelNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(homeFaxNoDspName.Trim()))
            {
                // 自宅FAX
                this.uLabel_HomeFaxNoDspName.Text = homeFaxNoDspName;
            }
            else
            {
                this.uLabel_HomeFaxNoDspName.Text = string.Empty;
            }

            if (!string.IsNullOrEmpty(officeFaxNoDspName.Trim()))
            {
                // 勤務先FAX
                this.uLabel_OfficeFaxNoDspName.Text = officeFaxNoDspName;
            }
            else
            {
                this.uLabel_OfficeFaxNoDspName.Text = string.Empty;
            }

            // 得意先(コード)
            this.uLabel_CustomerCode.Text = customerCode;
            // 得意先(名称)
            this.uLabel_CustomerName.Text = customerSnm;
            // 請求先(コード)
            this.ultraLabel_ClaimCode.Text = claimCode;
            // 請求先(名称)
            this.ultraLabel_ClaimName.Text = claimSnm;
            // 郵便番号 
            this.ultraLabel_PostNo.Text = postNo;
            // 住所１
            this.ultraLabel_Address1.Text = address1;
            // 住所２
            this.ultraLabel_Address3.Text = address2;
            // 住所３
            this.ultraLabel_Address4.Text = address3;
            // 自宅電話
            this.ultraLabel_HomeTelNo.Text = homeTelNo;
            // 自宅FAX
            this.ultraLabel_HomeFaxNo.Text = homeFaxNo;
            // 勤務先電話
            this.ultraLabel_OfficeTelNo.Text = officeTelNo;
            // 勤務先FAX
            this.ultraLabel_OfficeFaxNo.Text = officeFaxNo;
            // 携帯電話
            this.ultraLabel_PortableTelNo.Text = portableTelNo;
            // 純正ALL
            this.ultraLabel_Pure.Text = pureCustRateGrpCode;
            // 優良ALL
            this.ultraLabel_Excellent.Text = excellentCustRateGrpCode;
            // 得意先担当者
            this.ultraLabel_CustomerAgent.Text = customerAgent;
            // 担当者(コード)
            this.ultraLabel_CustomerAgentCd.Text = customerAgentCd;
            // 担当者名
            this.ultraLabel_CustomerAgentNm.Text = customerAgentNm;
            // 業種(コード)
            this.ultraLabel_BusinessTypeCode.Text = businessTypeCode;
            // 業種名
            this.ultraLabel_BusinessTypeName.Text = businessTypeName;
            // 地区(コード)
            this.ultraLabel_SalesAreaCode.Text = salesAreaCode;
            // 地区(名称)
            this.ultraLabel_SalesAreaName.Text = salesAreaName;
            // 売掛区分
            this.ultraLabel_AccRecDivCd.Text = accRecDivCd;
            // 締日
            this.ultraLabel_TotalDay.Text = TotalDay;
            // 集金月
            this.ultraLabel_CollectMoneyName.Text = collectMoneyName;
            // 集金日
            this.ultraLabel_CollectMoneyDay.Text = collectMoneyDay;
            // 回収条件
            this.ultraLabel_CollectCond.Text = collectCond;

            if (!string.IsNullOrEmpty(noteInfo.Trim()))
            {
                //情報の設定
                this.Memo_TextBox.Text = noteInfo;
            }
            else
            {
                //情報の設定
                this.Memo_TextBox.Text = string.Empty;
            }

            // ADD 2021/04/13 梶谷 >>>>>>>>>>
            //XMLから表示する情報を読み込む
            //selectByXML();
            // ADD 2021/04/13 梶谷 <<<<<<<<<<

            //フォーカスを先頭にセット
            this.Memo_TextBox.Select(0, 0);
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        /// <br>Programmer : 32653 梶谷 貴士</br>
        /// <br>Date       : 2021/04/13</br>											
        /// <br>管理番号   : 11770021-00 得意先情報ガイド表示PKG対応</br>	
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/06/21</br>											
        /// <br>管理番号   : 11770021-00 得意先情報ガイド表示の対応</br>	
        private void PMKHN02830UCA_Load(object sender, EventArgs e)
        {
            //画面は前面にセット
            selectByXML();// ADD 2021/04/13 梶谷
            //this.TopMost = true; //DEL 譚洪 2021/06/21 得意先情報ガイド表示の対応
            SetGuidButtonIcon();
        }

        /// <summary>
        /// 設定ボタンのアイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 設定ボタンにアイコンを設定します。</br>
        /// <br>Programmer  : 梶谷 貴士</br>
        /// <br>Date        : 2021/04/13</br>
        /// </remarks>
        private void SetGuidButtonIcon()
        {
            this.Ok_Button.ImageList = IconResourceManagement.ImageList16;
            this.Ok_Button.Appearance.Image = (int)Size16_Index.SETUP1;
        }

        /// <summary>
        /// timer1_Tickイベント
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
            timer1.Enabled = false;
        }

        /// <summary>
        /// timer2_Tickイベント
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/06/21</br>											
        /// <br>管理番号   : 11770021-00 得意先情報ガイド表示の対応</br>	
        /// </remarks>
        private void timer2_Tick(object sender, EventArgs e)
        {
            bool closeflag = false;
            IntPtr intptr = IntPtr.Zero; // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応
            Process[] allProgresse = System.Diagnostics.Process.GetProcessesByName(XML_NAME_SALE);
            if (allProgresse.Length == 0)
            {
                //売上伝票入力存在しない場合、本画面閉じる
                this.Close();
            }
            else
            {
                foreach (Process pro in allProgresse)
                {
                    if (pro.Id.Equals(Convert.ToInt32(_pID)))
                    {
                        closeflag = true;
                        intptr = pro.MainWindowHandle;// ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応
                    }
                }
                if (!closeflag)
                {
                    //売上伝票入力存在しない場合、本画面閉じる
                    this.Close();
                }
                // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 ----->>>>>
                else
                {
                    //現在アクティブになっているウィンドウが呼出元か？
                    if (intptr == GetForegroundWindow())
                    {
                        //前回チェック時は呼出元がアクティブではなかったか？
                        if (ChangeState == true)
                        {
                            //得意先ガイド表示を最前面表示する
                            SetWindowPos(this.Handle, intptr, LocationZero, LocationZero, LocationZero, LocationZero, UFlags);
                        }
                        ChangeState = false;
                    }
                    else
                    {
                        ChangeState = true;
                    }
                }
                // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 -----<<<<<
            }
        }

        /// <summary>
        /// MemoRichTextのMouseのRightClickイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Memo_TextBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // 元に戻す
                this.toolStripMenuItem_Undo.Enabled = false;
                // 切り取り
                this.toolStripMenuItem_Cut.Enabled = false;
                // 削除
                this.toolStripMenuItem_Clear.Enabled = false;
                // コピー
                if (string.IsNullOrEmpty(this.Memo_TextBox.SelectedText))
                {
                    this.toolStripMenuItem_Copy.Enabled = false;
                }
                else
                {
                    this.toolStripMenuItem_Copy.Enabled = true;
                }
                // 貼り付け
                this.toolStripMenuItem_Paste.Enabled = false;

                this.contextMenuStrip1.Show(this.Memo_TextBox, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// MouseRightClickのMenuイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // 元に戻す
            if (toolStripMenuItem_Undo.Selected)
            {
                this.Memo_TextBox.Undo();
            }
            // 切り取り
            if (toolStripMenuItem_Cut.Selected)
            {
                this.Memo_TextBox.Cut();
            }
            // コピー
            if (toolStripMenuItem_Copy.Selected)
            {
                this.Memo_TextBox.Copy();
            }
            // 貼り付け
            if (toolStripMenuItem_Paste.Selected)
            {
                this.Memo_TextBox.Paste();
            }
            // 削除
            if (toolStripMenuItem_Clear.Selected)
            {
                this.Memo_TextBox.Clear();
            }
            // すべて選択
            if (toolStripMenuItem_Select.Selected)
            {
                this.Memo_TextBox.SelectAll();
            }
        }

        /// <summary>
        /// 設定ボタンのクリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            try
            {
                PMKHN02840UA demandConfirm = new PMKHN02840UA();

                DialogResult dialogResult = demandConfirm.ShowDialog(this);

                //ダイアログにてＯＫボタンが押下された場合、項目を一新する
                if (dialogResult == DialogResult.OK)
                {
                    this.Hide();
                    this.selectByXML();
                    this.Show();
                    this.Memo_TextBox.Select(0, 0);
                }
            }
            catch (Exception ex)
            {
                // ログ出力
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(CtPGID, ErrorMessage1, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }
        }

        // ADD 2021/04/13 梶谷 >>>>>>>>>>
        /// <summary>
        /// xmlファイルの読み込みイベント
        /// </summary>
        private void selectByXML()
        {
            int dispItmCount = 0; //表示項目のチェック数カウント
            String xmlFileNameDocPrt = "";
            try
            {
                Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(PartsmanPass);
                xmlFileNameDocPrt = Path.Combine(Path.Combine((string)(keys.GetValue(InstallDirectory)), ConstantManagement_ClientDirectory.UISettings), xPathDocPath);
            }
            catch(Exception ex)
            {
                // ログ出力
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(CtPGID, ErrorMessage2, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }

            if (File.Exists(xmlFileNameDocPrt))
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

                //得意先情報表示設定のXMLファイルを読み込む
                using (XmlReader xmlReader = XmlReader.Create(xmlFileNameDocPrt, xmlReaderSettings))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement(elePosCustomer))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel1.Visible = true;
                                this.uLabel_CustomerCode.Visible = true;
                                this.uLabel_CustomerName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel1.Visible = false;
                                this.uLabel_CustomerCode.Visible = false;
                                this.uLabel_CustomerName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCustomerClaim))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel2.Location = new Point(this.ultraLabel2.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_ClaimCode.Location = new Point(this.ultraLabel_ClaimCode.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_ClaimName.Location = new Point(this.ultraLabel_ClaimName.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel2.Visible = true;
                                this.ultraLabel_ClaimCode.Visible = true;
                                this.ultraLabel_ClaimName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel2.Visible = false;
                                this.ultraLabel_ClaimCode.Visible = false;
                                this.ultraLabel_ClaimName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(elePostNo))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel3.Location = new Point(this.ultraLabel3.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_PostNo.Location = new Point(this.ultraLabel_PostNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel3.Visible = true;
                                this.ultraLabel_PostNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel3.Visible = false;
                                this.ultraLabel_PostNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleAddress))
                        {
                            //チェックが入っていれば表示をONにして、3行分のカウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel4.Location = new Point(this.ultraLabel4.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Address1.Location = new Point(this.ultraLabel_Address1.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Address3.Location = new Point(this.ultraLabel_Address3.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel_Address4.Location = new Point(this.ultraLabel_Address4.Location.X, Top_Space + defItmHeight * (dispItmCount + 2));

                                this.ultraLabel4.Visible = true;
                                this.ultraLabel_Address1.Visible = true;
                                this.ultraLabel_Address3.Visible = true;
                                this.ultraLabel_Address4.Visible = true;
                                dispItmCount = dispItmCount + 3;
                            }
                            else
                            {
                                this.ultraLabel4.Visible = false;
                                this.ultraLabel_Address1.Visible = false;
                                this.ultraLabel_Address3.Visible = false;
                                this.ultraLabel_Address4.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleHomeTelNoFaxNo))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.uLabel_HomeTelNoDspName.Location = new Point(this.uLabel_HomeTelNoDspName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_HomeTelNo.Location = new Point(this.ultraLabel_HomeTelNo.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.uLabel_HomeFaxNoDspName.Location = new Point(this.uLabel_HomeFaxNoDspName.Location.X, Top_Space + 1 + defItmHeight * dispItmCount);
                                this.ultraLabel_HomeFaxNo.Location = new Point(this.ultraLabel_HomeFaxNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.uLabel_HomeTelNoDspName.Visible = true;
                                this.ultraLabel_HomeTelNo.Visible = true;
                                this.uLabel_HomeFaxNoDspName.Visible = true;
                                this.ultraLabel_HomeFaxNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.uLabel_HomeTelNoDspName.Visible = false;
                                this.ultraLabel_HomeTelNo.Visible = false;
                                this.uLabel_HomeFaxNoDspName.Visible = false;
                                this.ultraLabel_HomeFaxNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleOfficeTelNoFaxNo))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.uLabel_OfficeTelNoDspName.Location = new Point(this.uLabel_OfficeTelNoDspName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_OfficeTelNo.Location = new Point(this.ultraLabel_OfficeTelNo.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.uLabel_OfficeFaxNoDspName.Location = new Point(this.uLabel_OfficeFaxNoDspName.Location.X, Top_Space + 1 + defItmHeight * dispItmCount);
                                this.ultraLabel_OfficeFaxNo.Location = new Point(this.ultraLabel_OfficeFaxNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.uLabel_OfficeTelNoDspName.Visible = true;
                                this.ultraLabel_OfficeTelNo.Visible = true;
                                this.uLabel_OfficeFaxNoDspName.Visible = true;
                                this.ultraLabel_OfficeFaxNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.uLabel_OfficeTelNoDspName.Visible = false;
                                this.ultraLabel_OfficeTelNo.Visible = false;
                                this.uLabel_OfficeFaxNoDspName.Visible = false;
                                this.ultraLabel_OfficeFaxNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCellphoneNo))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.uLabel_MobileTelNoDspName.Location = new Point(this.uLabel_MobileTelNoDspName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_PortableTelNo.Location = new Point(this.ultraLabel_PortableTelNo.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.uLabel_MobileTelNoDspName.Visible = true;
                                this.ultraLabel_PortableTelNo.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.uLabel_MobileTelNoDspName.Visible = false;
                                this.ultraLabel_PortableTelNo.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(elePureAll))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel10.Location = new Point(this.ultraLabel10.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Pure.Location = new Point(this.ultraLabel_Pure.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel10.Visible = true;
                                this.ultraLabel_Pure.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel10.Visible = false;
                                this.ultraLabel_Pure.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(elePrimeAll))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel11.Location = new Point(this.ultraLabel11.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_Excellent.Location = new Point(this.ultraLabel_Excellent.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel11.Visible = true;
                                this.ultraLabel_Excellent.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel11.Visible = false;
                                this.ultraLabel_Excellent.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleAgent))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel12.Location = new Point(this.ultraLabel12.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CustomerAgentCd.Location = new Point(this.ultraLabel_CustomerAgentCd.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CustomerAgentNm.Location = new Point(this.ultraLabel_CustomerAgentNm.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel12.Visible = true;
                                this.ultraLabel_CustomerAgentCd.Visible = true;
                                this.ultraLabel_CustomerAgentNm.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel12.Visible = false;
                                this.ultraLabel_CustomerAgentCd.Visible = false;
                                this.ultraLabel_CustomerAgentNm.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCustomerAgent))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel13.Location = new Point(this.ultraLabel13.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CustomerAgent.Location = new Point(this.ultraLabel_CustomerAgent.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel13.Visible = true;
                                this.ultraLabel_CustomerAgent.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel13.Visible = false;
                                this.ultraLabel_CustomerAgent.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleBusinessType))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel14.Location = new Point(this.ultraLabel14.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_BusinessTypeCode.Location = new Point(this.ultraLabel_BusinessTypeCode.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_BusinessTypeName.Location = new Point(this.ultraLabel_BusinessTypeName.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel14.Visible = true;
                                this.ultraLabel_BusinessTypeCode.Visible = true;
                                this.ultraLabel_BusinessTypeName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel14.Visible = false;
                                this.ultraLabel_BusinessTypeCode.Visible = false;
                                this.ultraLabel_BusinessTypeName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleArea))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel15.Location = new Point(this.ultraLabel15.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_SalesAreaCode.Location = new Point(this.ultraLabel_SalesAreaCode.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_SalesAreaName.Location = new Point(this.ultraLabel_SalesAreaName.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel15.Visible = true;
                                this.ultraLabel_SalesAreaCode.Visible = true;
                                this.ultraLabel_SalesAreaName.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel15.Visible = false;
                                this.ultraLabel_SalesAreaCode.Visible = false;
                                this.ultraLabel_SalesAreaName.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleAccRecDiv))
                        {
                            //チェックが入っていれば表示をONにして、カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel16.Location = new Point(this.ultraLabel16.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_AccRecDivCd.Location = new Point(this.ultraLabel_AccRecDivCd.Location.X, Top_Space + defItmHeight * dispItmCount);

                                this.ultraLabel16.Visible = true;
                                this.ultraLabel_AccRecDivCd.Visible = true;
                                dispItmCount++;
                            }
                            else
                            {
                                this.ultraLabel16.Visible = false;
                                this.ultraLabel_AccRecDivCd.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleCollectMoney))
                        {
                            //チェックが入っていれば表示をONにして、2行分のカウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel17.Location = new Point(this.ultraLabel17.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_TotalDay.Location = new Point(this.ultraLabel_TotalDay.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel18.Location = new Point(this.ultraLabel18.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel19.Location = new Point(this.ultraLabel19.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel_CollectMoneyName.Location = new Point(this.ultraLabel_CollectMoneyName.Location.X, Top_Space + defItmHeight * dispItmCount);
                                this.ultraLabel22.Location = new Point(this.ultraLabel22.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel_CollectCond.Location = new Point(this.ultraLabel_CollectCond.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel20.Location = new Point(this.ultraLabel20.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel_CollectMoneyDay.Location = new Point(this.ultraLabel_CollectMoneyDay.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));
                                this.ultraLabel21.Location = new Point(this.ultraLabel21.Location.X, Top_Space + defItmHeight * (dispItmCount + 1));

                                this.ultraLabel17.Visible = true;
                                this.ultraLabel_TotalDay.Visible = true;
                                this.ultraLabel18.Visible = true;
                                this.ultraLabel19.Visible = true;
                                this.ultraLabel_CollectMoneyName.Visible = true;
                                this.ultraLabel22.Visible = true;
                                this.ultraLabel_CollectCond.Visible = true;
                                this.ultraLabel20.Visible = true;
                                this.ultraLabel_CollectMoneyDay.Visible = true;
                                this.ultraLabel21.Visible = true;
                                dispItmCount = dispItmCount + 2;
                            }
                            else
                            {
                                this.ultraLabel17.Visible = false;
                                this.ultraLabel_TotalDay.Visible = false;
                                this.ultraLabel18.Visible = false;
                                this.ultraLabel19.Visible = false;
                                this.ultraLabel_CollectMoneyName.Visible = false;
                                this.ultraLabel22.Visible = false;
                                this.ultraLabel_CollectCond.Visible = false;
                                this.ultraLabel20.Visible = false;
                                this.ultraLabel_CollectMoneyDay.Visible = false;
                                this.ultraLabel21.Visible = false;
                            }
                        }

                        if (xmlReader.IsStartElement(eleMemo))
                        {
                            //チェックが入っていれば表示をONにして、7行分カウントを増やす
                            if (xmlReader.ReadElementContentAsString() == CHECK_ON)
                            {
                                this.ultraLabel73.Location = new Point(this.ultraLabel73.Location.X, Top_Space * 2 + defItmHeight * dispItmCount);
                                this.Memo_TextBox.Location = new Point(this.Memo_TextBox.Location.X, Top_Space * 2 + defItmHeight * dispItmCount);

                                this.ultraLabel73.Visible = true;
                                this.Memo_TextBox.Visible = true;
                                dispItmCount = dispItmCount + 7;
                            }
                            else
                            {
                                this.ultraLabel73.Visible = false;
                                this.Memo_TextBox.Visible = false;
                            }
                        }


                    }
                    //表示項目の数と種類に応じてウィンドウサイズを変更
                    this.Size = new Size(this.Size.Width, Top_Space + dispItmCount * defItmHeight + Down_Space);
                }
            }
            else
            {
                this.Size = new Size(defaultSize_Width, defaultSize_Height);
            }
        }

        /// <summary>
        /// フォームが非活性状態に変更イベント
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        private void PMKHN02830UCA_Deactivate(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, TMemPos.FormInfoData> formInfoDic = new Dictionary<string, TMemPos.FormInfoData>();
                // ウインドウズ位置情報を取得する
                Rectangle bounds = this.Bounds;
                // ウインドウズ状態を取得する
                FormWindowState windowsState = this.WindowState;
                switch (this.WindowState)
                {
                    case FormWindowState.Minimized:
                        bounds = this.RestoreBounds;
                        windowsState = FormWindowState.Normal;
                        break;
                    case FormWindowState.Maximized:
                        bounds = this.RestoreBounds;
                        break;
                }
                // フォーム情報を作成する
                formInfoDic[this.GetType().Name] = new TMemPos.FormInfoData(this.GetType().Name, bounds, windowsState);
                List<TMemPos.FormInfoData> list = new List<TMemPos.FormInfoData>(formInfoDic.Values);
                // 位置情報ファイルに保存する
                UserSettingController.SerializeUserSetting(list.ToArray(), ConstantManagement_ClientDirectory.UISettings_FormPos + "\\" + Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath) + ".pos");
            }
            catch
            {
            }
        }
        // ADD 2021/04/13 梶谷 <<<<<<<<<<

        // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 ----->>>>>
        /// <summary>
        /// フォームのKeyPressイベント
        /// </summary>
        /// <param name="object">sender</param>
        /// <param name="EventArgs">e</param>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2021/06/21</br>											
        /// <br>管理番号   : 11770021-00 得意先情報ガイド表示の対応</br>	
        /// </remarks>
        private void PMKHN02830UCA_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)KEY_ESC:
                    // ESC押下、画面を閉じる
                    this.Close();
                    break;
            }
        }
        // ADD 譚洪 2021/06/21 得意先情報ガイド表示の対応 -----<<<<<
    }
}