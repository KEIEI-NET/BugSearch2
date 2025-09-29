using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using System.Reflection;
using System.Xml;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 得意先情報ガイド画面フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 得意先情報ガイド画面フォームクラスです。</br>
	/// <br>Programmer	: 32653　梶谷 貴士</br>
	/// <br>Date		: 2021.04.13</br>
    /// </remarks>
	public partial class PMKHN02840UA : Form
	{
		#region■Constructor

		/// <summary>
		///  コンストラクタ
		/// </summary>
		public PMKHN02840UA()
		{
            InitializeComponent();
            ReadXML();
		}
        
		#endregion

		#region■Private Member
        private const string xPathDocPath = "PMKHN02830U_CustomerGuideDis.XML";  //xmlファイルのパス
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
        private const int AllCheckCount = 16; //「すべてチェック」以外の全項目数
        private const string CHECK_ON = "1"; //チェックがON(1)
        // ログ出力部品
        OutLogCommon LogCommon;
        // クライアントログ出力内容
        private const string ErrorMessage1 = "PMKHN002840U ReadXML XMLパス取得で例外発生";
        private const string ErrorMessage2 = "PMKHN002840U WriteXML XMLパス取得で例外発生";
        private const string ErrorMessage3 = "PMKHN002840U Button1_Click チェック状態取得で例外発生";
        // PGID
        private const string CtPGID = "PMKHN002840U";
		#endregion

        #region ■Private Method

		/// <summary>
		/// 確定処理
		/// </summary>
		private void DecisionProc()
		{
            WriteXML();
            this.Close();
		}

		#endregion

        /// <summary>
        /// xmlファイルを読み込む
        /// </summary>
        private void ReadXML()
        {
            String xmlFileNameDocPrt = "";
            try
            {
                Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(PartsmanPass);
                xmlFileNameDocPrt = Path.Combine(Path.Combine((string)(keys.GetValue(InstallDirectory)), ConstantManagement_ClientDirectory.UISettings), xPathDocPath);
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

            if (File.Exists(xmlFileNameDocPrt))
            {
                XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

                using (XmlReader xmlReader = XmlReader.Create(xmlFileNameDocPrt, xmlReaderSettings))
                {
                    int count = 0;
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement(elePosCustomer) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkPosCustomer.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleCustomerClaim) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkCustomerClaim.Checked = true; count++; }
                        if (xmlReader.IsStartElement(elePostNo) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkPostNo.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleAddress) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkAddress.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleHomeTelNoFaxNo) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkHomeTelNoFaxNo.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleOfficeTelNoFaxNo) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkOfficeTelNoFaxNo.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleCellphoneNo) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkCellphoneNo.Checked = true; count++; }
                        if (xmlReader.IsStartElement(elePureAll) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkPureAll.Checked = true; count++; }
                        if (xmlReader.IsStartElement(elePrimeAll) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkPrimeAll.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleAgent) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkAgent.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleCustomerAgent) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkCustomerAgent.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleBusinessType) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkBusinessType.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleArea) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkArea.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleAccRecDiv) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkAccRecDiv.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleCollectMoney) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkCollectMoney.Checked = true; count++; }
                        if (xmlReader.IsStartElement(eleMemo) && xmlReader.ReadElementContentAsString() == CHECK_ON) { chkMemo.Checked = true; count++; }
                    }
                    //16個すべてにチェックがついたら「すべてチェック」にチェックを入れる。
                    if (checkAllCheckBox(true) == true)
                    {
                        chkAll.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        chkAll.CheckState = CheckState.Unchecked;
                    }
                }
            }
            else
            {
                allCheckBoxChange(true);
            }
        }

        /// <summary>
        /// xmlファイルに各項目のチェック状況を書き出す
        /// </summary>
        private void WriteXML()
        {
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;

                Microsoft.Win32.RegistryKey keys = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(PartsmanPass);
                String xmlFileNameDocPrt = Path.Combine(Path.Combine((string)(keys.GetValue(InstallDirectory)), ConstantManagement_ClientDirectory.UISettings), xPathDocPath);

                XmlWriter xmlWriter = XmlWriter.Create(xmlFileNameDocPrt, xmlWriterSettings);

                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement(CtPGID);     //PMKHN02840Uの書き込み開始

                xmlWriter.WriteStartElement(elePosCustomer);
                if (chkPosCustomer.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleCustomerClaim);
                if (chkCustomerClaim.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(elePostNo);
                if (chkPostNo.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleAddress);
                if (chkAddress.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleHomeTelNoFaxNo);
                if (chkHomeTelNoFaxNo.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleOfficeTelNoFaxNo);
                if (chkOfficeTelNoFaxNo.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleCellphoneNo);
                if (chkCellphoneNo.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(elePureAll);
                if (chkPureAll.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(elePrimeAll);
                if (chkPrimeAll.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleAgent);
                if (chkAgent.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleCustomerAgent);
                if (chkCustomerAgent.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleBusinessType);
                if (chkBusinessType.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleArea);
                if (chkArea.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleAccRecDiv);
                if (chkAccRecDiv.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleCollectMoney);
                if (chkCollectMoney.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteStartElement(eleMemo);
                if (chkMemo.Checked == true) xmlWriter.WriteValue(CHECK_ON); else xmlWriter.WriteValue("");
                xmlWriter.WriteFullEndElement();

                xmlWriter.WriteFullEndElement();  //PMKHN02840Uの書き込み終了

                xmlWriter.Flush();

                xmlWriter.Close();
            }catch(IOException ex){
                // ログ出力
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(CtPGID, ErrorMessage2, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }
        }

        /// <summary>
        /// ＯＫボタンのクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //すべてのチェックボックスにチェックが入っていない場合は強制的にメモのみを表示する。
            this.DialogResult = DialogResult.OK;
            try
            {
                if (checkAllCheckBox(false) == false)
                {
                    chkMemo.Checked = true;
                }
                DecisionProc();
            }
            catch(Exception ex){
                this.DialogResult = DialogResult.Abort;
                // ログ出力
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(CtPGID, ErrorMessage3, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, ex);
            }

        }

        /// <summary>
        /// キャンセルボタンがクリックされた際のイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 「すべてチェック」のチェック状況変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void chkAll_Click(object sender, EventArgs e)
        {
            //「すべてチェック」のチェック状況に変化があるととすべてのチェックの状態が「すべてチェック」と同じになる。
            allCheckBoxChange(!chkAll.Checked);
        }

        /// <summary>
        /// 各項目のいずれかのチェックが変更された際のイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void anyCheckBoxClick(object sender, EventArgs e)
        {
            //「すべてチェック」のチェック状態を設定する。
            if (checkAllCheckBox(true) == true)
            {
                chkAll.CheckState = CheckState.Checked;
            }
            else
            {
                chkAll.CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// 「すべてチェック」を除くチェックボックスの状態確認
        /// </summary>
        /// <param name="chkStatus">チェック状態</param>
        private bool checkAllCheckBox(bool chkStatus)
        {
            if ((chkPosCustomer.Checked == chkStatus &&
                 chkCustomerClaim.Checked == chkStatus &&
                 chkPostNo.Checked == chkStatus &&
                 chkAddress.Checked == chkStatus &&
                 chkHomeTelNoFaxNo.Checked == chkStatus &&
                 chkOfficeTelNoFaxNo.Checked == chkStatus &&
                 chkCellphoneNo.Checked == chkStatus &&
                 chkPureAll.Checked == chkStatus &&
                 chkPrimeAll.Checked == chkStatus &&
                 chkAgent.Checked == chkStatus &&
                 chkCustomerAgent.Checked == chkStatus &&
                 chkBusinessType.Checked == chkStatus &&
                 chkArea.Checked == chkStatus &&
                 chkAccRecDiv.Checked == chkStatus &&
                 chkCollectMoney.Checked == chkStatus &&
                 chkMemo.Checked == chkStatus))
            {
                return chkStatus;
            }
            return !chkStatus;
        }

        /// <summary>
        /// すべてのチェックボックスの状態を一度に変更する
        /// </summary>
        /// <param name="chkStatus">チェック状態</param>
        private void allCheckBoxChange(bool chkStatus)
        {
            chkAll.Checked = chkStatus;
            chkPosCustomer.Checked = chkAll.Checked;
            chkCustomerClaim.Checked = chkAll.Checked;
            chkPostNo.Checked = chkAll.Checked;
            chkAddress.Checked = chkAll.Checked;
            chkHomeTelNoFaxNo.Checked = chkAll.Checked;
            chkOfficeTelNoFaxNo.Checked = chkAll.Checked;
            chkCellphoneNo.Checked = chkAll.Checked;
            chkPureAll.Checked = chkAll.Checked;
            chkPrimeAll.Checked = chkAll.Checked;
            chkAgent.Checked = chkAll.Checked;
            chkCustomerAgent.Checked = chkAll.Checked;
            chkBusinessType.Checked = chkAll.Checked;
            chkArea.Checked = chkAll.Checked;
            chkAccRecDiv.Checked = chkAll.Checked;
            chkCollectMoney.Checked = chkAll.Checked;
            chkMemo.Checked = chkAll.Checked;
        }
    }
}
