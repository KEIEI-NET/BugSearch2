using System;
using System.Xml;
using System.Windows.Forms;
using System.Drawing.Printing;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Drawing.Printing;
using DataDynamics.ActiveReports.Document;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using DataDynamics.ActiveReports;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ActiveReport���ʊ֐����i�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveReport���ʊ֐����i�N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.18</br>
	/// <br>Update Note: 2006.11.28 Y.Sasaki</br>
	/// <br>           : �P.�������p���T�C�Y���T�|�[�g����Ă��Ȃ��ꍇ�̑Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.22 ��� ���b</br>
    /// <br>           : PM.NS�����Ή��B�h�b�g�v�����^����ɑΉ����邽�ߗp���T�C�Y�ݒ�����������B</br>
    /// <br>Update Note: 2012/05/17 yangmj</br>
    /// <br>           : �w��y�[�W����̒ǉ�</br>
    /// <br></br>
	/// </remarks>
	public class SFCMN00293UZ
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// ActiveReport���ʊ֐����i�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public SFCMN00293UZ()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
            _prtManageList = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD
		}
		#endregion
	
		#region private member
		private XmlDocument doc                   = new XmlDocument();			// �ݒ�t�@�C���Ǎ��p�h�L�������g
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        private ActiveReport3 _report; // �Ώۃ��|�[�g
        private bool _cancel; // �Ώۃ��|�[�g�ʏ����L�����Z���t���O
        private ArrayList _prtManageList; // �v�����^�ݒ胊�X�g
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

        //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�----->>>>>
        private ArrayList _pageList;
        //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�-----<<<<<
		#endregion
		
		/// <summary>
		/// �v�����^�[���ݒ菈��
		/// </summary>
		/// <param name="rpt">�Ώ�ActiveReport�N���X</param>
		/// <param name="commonInfo">���ʃp�����[�^���</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <remarks>
		/// <br>Note       : �v�����^���̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		internal int SetPrinterInfo(ref DataDynamics.ActiveReports.ActiveReport3 rpt, SFCMN00293UC commonInfo, out string message)
		{
			message = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			try
			{
				// ����h�L�������g��
				rpt.Document.Name = commonInfo.PrintName;
				
				// �㉺���E�]���ݒ�
				float marginsTop    = rpt.PageSettings.Margins.Top; 
				float marginsBottom = rpt.PageSettings.Margins.Bottom; 
				float marginsLeft   = rpt.PageSettings.Margins.Left; 
				float marginsRight  = rpt.PageSettings.Margins.Right; 
				
				marginsTop += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsTop / 100);
				if (marginsTop < 0) marginsTop = (float)0;
				
				marginsBottom += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsBottom / 100);
				if (marginsBottom < 0) marginsBottom = (float)0;
				
				marginsLeft += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsLeft / 100);
				if (marginsLeft < 0) marginsLeft = (float)0;
				
				marginsRight += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsRight / 100);
				if (marginsRight < 0) marginsRight = (float)0;

				rpt.PageSettings.Margins.Top    = marginsTop; 
				rpt.PageSettings.Margins.Bottom = marginsBottom;
				rpt.PageSettings.Margins.Left   = marginsLeft;
				rpt.PageSettings.Margins.Right  = marginsRight; 
				
				// ����͈͂��w��
				// �S�y�[�W
				if (commonInfo.PrintRange == 0)
				{
					rpt.Document.Printer.PrinterSettings.PrintRange	= PrintRange.AllPages;
				} 

					// �y�[�W�͈͎w��
				else 
				{
					rpt.Document.Printer.PrinterSettings.PrintRange	= PrintRange.SomePages;
					rpt.Document.Printer.PrinterSettings.FromPage	  = commonInfo.PrintTopPage;
					rpt.Document.Printer.PrinterSettings.ToPage		  = commonInfo.PrintEndPage;
				}
				
				rpt.Document.Printer.PrinterSettings.PrintRange	= PrintRange.AllPages;
				
				// �g�p�v�����^�[�̐ݒ�
				foreach (string wkStr in PrinterSettings.InstalledPrinters)
				{
					if (wkStr.Equals(commonInfo.PrinterName))
					{
						rpt.Document.Printer.PrinterSettings.PrinterName = commonInfo.PrinterName;
						break;
					}
				}
				
				// �g�p�v�����^�̗L���L��
				if (!rpt.Document.Printer.PrinterSettings.IsValid)
				{
					rpt.Document.Printer.PrinterSettings.PrinterName = "";
				}

				// >>>>> 2006.11.28 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
				
				// �p���T�C�Y�擾�t���O[T:�T�|�[�g,F:�T�|�[�g�Ȃ�]
				bool isPaperKind = false;
				
				// �󎚕����ύX�t���O[T:�ύX,F:�ύX��]
				bool isChangeOrientation = false;

				// �T�|�[�g����Ă���p���T�C�Y���`�F�b�N����
				isPaperKind = CheckSupportPaperKind(rpt.PageSettings.PaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes);
				
				// �����T�|�[�g����ĂȂ�������c
				if (!isPaperKind)
				{
					// �������p���T�C�Y
					switch (rpt.PageSettings.PaperKind)
					{
						case (PaperKind)PaperKind.A3Rotated:
							{	// A3��
								rpt.PageSettings.PaperKind = PaperKind.A3;
								isChangeOrientation = true;
								break;
							}
						case (PaperKind)PaperKind.A4Rotated:
							{	// A4�� 
								rpt.PageSettings.PaperKind = PaperKind.A4;
								isChangeOrientation = true;
								break;
							}
						case (PaperKind)PaperKind.A5Rotated:
							{	// A5���@�@�@�@�@�@
								rpt.PageSettings.PaperKind = PaperKind.A5;
								isChangeOrientation = true;
								break;
							}
						case (PaperKind)PaperKind.A6Rotated:
							{	// A6���@�@�@�@�@�@
								rpt.PageSettings.PaperKind = PaperKind.A6;
								isChangeOrientation = true;
								break;
							}
						case (PaperKind)PaperKind.B4JisRotated:
							{	// B4���@�@�@�@�@�@
								rpt.PageSettings.PaperKind = PaperKind.B4;
								isChangeOrientation = true;
								break;
							}
						case (PaperKind)PaperKind.B5JisRotated:
							{	// B5���@�@�@�@�@�@
								rpt.PageSettings.PaperKind = PaperKind.B5;
								isChangeOrientation = true;
								break;
							}
						case (PaperKind)PaperKind.B6JisRotated:
							{	// B6���@�@�@�@�@�@
								rpt.PageSettings.PaperKind = PaperKind.B6Jis;
								isChangeOrientation = true;
								break;
							}
						default:  // �����Ď擾���Ȃ������Ŏ擾����
							//rpt.PageSettings.PaperKind = rpt.Document.Printer.PrinterSettings.DefaultPageSettings.PaperSize.Kind;
							break;
					}

					// �T�|�[�g����Ă���p���T�C�Y���`�F�b�N����
					isPaperKind = CheckSupportPaperKind(rpt.PageSettings.PaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes);
    
					// �����T�|�[�g����ĂȂ�������A���̃v�����^�ɐݒ肳��Ă�������擾����
					if (!isPaperKind)
					{
						// �v�����^�̗p���̃T�C�Y���擾
						rpt.PageSettings.PaperKind = rpt.Document.Printer.PrinterSettings.DefaultPageSettings.PaperSize.Kind;

						// �v�����^�̈���������擾
						// �y�[�W���������ň������ꍇ�� true�B����ȊO�̏ꍇ�� false
						if (rpt.Document.Printer.PrinterSettings.DefaultPageSettings.Landscape)
						{
							rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
						}
						else
						{
							rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
						}

						// ��������̕ύX�́A����ȏサ�Ȃ�
						isChangeOrientation = false;
					}

					// ��FA4����A4�ɕύX�ɂȂ����ꍇ�ɂ́A��������̕ύX���s��
					if (isChangeOrientation)
					{
						// �p��������FA�S����A�S���Ŏ擾�ł����Ȃ�A�c���𔽓]����
						switch (rpt.PageSettings.Orientation)
						{
							case ((PageOrientation)PageOrientation.Landscape):
								rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
								break;
							case ((PageOrientation)PageOrientation.Portrait):
								rpt.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
								break;
						}
					}
				}
				// <<<<< 2006.11.28 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
                SettingPaperKind( ref rpt, PaperKind.A3, PaperKind.A3Rotated );
                SettingPaperKind( ref rpt, PaperKind.A4, PaperKind.A4Rotated );
                SettingPaperKind( ref rpt, PaperKind.A5, PaperKind.A5Rotated );
                SettingPaperKind( ref rpt, PaperKind.A6, PaperKind.A6Rotated );
                SettingPaperKind( ref rpt, PaperKind.B4, PaperKind.B4JisRotated );
                SettingPaperKind( ref rpt, PaperKind.B5, PaperKind.B5JisRotated );
                SettingPaperKind( ref rpt, PaperKind.B6Jis, PaperKind.B6JisRotated );
                // ���ɗ\��\��Letter�ō쐬����Ă����בΉ��B
                SettingPaperKind( ref rpt, PaperKind.Letter, PaperKind.A4Rotated );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; 
			}
			catch (Exception ex)
			{
				message = "�v�����^�[���Z�b�g���������ɂė�O���������܂����B"
					+ "\n\r" + ex.Message;
				throw new ActiveReportPrintException(message, status);
			}
			return status;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        /// <summary>
        /// �p����ʐݒ菈���iA4�c/�c�����]��A4��/�ʏ�j
        /// </summary>
        /// <param name="rpt"></param>
        /// <param name="orgPaperKind"></param>
        /// <param name="newPaperKind"></param>
        private void SettingPaperKind( ref DataDynamics.ActiveReports.ActiveReport3 rpt, PaperKind orgPaperKind, PaperKind newPaperKind )
        {
            if ( rpt.PageSettings.PaperKind == orgPaperKind && rpt.PageSettings.Orientation == PageOrientation.Landscape )
            {
                if ( CheckSupportPaperKind( newPaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes ) )
                {
                    rpt.PageSettings.PaperKind = newPaperKind;
                    rpt.PageSettings.Orientation = PageOrientation.Portrait;
                }
            }        
        }
        /// <summary>
        /// �h�b�g�v�����^�I�������i�v�����^�ݒ�̒�����h�b�g�v�����^���P�I�����܂��j
        /// </summary>
        /// <param name="commonInfo"></param>
        internal void SelectDotPrinter( ref SFCMN00293UC commonInfo )
        {
            PrtManage prtManage = null;

            int status;
            ArrayList retList = _prtManageList;
            if ( retList == null )
            {
                PrtManageAcs prtManageAcs = new Broadleaf.Application.Controller.PrtManageAcs();
                status = prtManageAcs.SearchAll( out retList, LoginInfoAcquisition.EnterpriseCode.Trim() );
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                List<PrtManage> prtManageList = new List<PrtManage>( (PrtManage[])retList.ToArray( typeof( PrtManage ) ) );
                if ( prtManageList != null )
                {
                    prtManage = prtManageList.Find(
                                    delegate( PrtManage prt )
                                    {
                                        // 1:�h�b�g�v�����^
                                        return (prt.PrinterKind == 1);
                                    } );
                }
            }

            // �Y��������΃v�����^���������ւ���
            if ( prtManage != null )
            {
                commonInfo.PrinterName = prtManage.PrinterName;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

		/// <summary>
		/// �p���T�|�[�g�`�F�b�N
		/// </summary>
		/// <param name="paperKind">�p���T�C�Y</param>
		/// <param name="paperSizeCollection">�Y���v�����^�̗p���T�C�Y�R���N�V����</param>
		/// <returns>[T:�T�|�[�g,F:��T�|�[�g]</returns>
		/// <remarks>
		/// <br>Note       : �Y���p���T�C�Y�̃T�|�[�g�L���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.11.28</br>
		/// </remarks>
		internal bool CheckSupportPaperKind(PaperKind paperKind, PrinterSettings.PaperSizeCollection paperSizeCollection)
		{
			foreach (PaperSize paperSize in paperSizeCollection)
			{
				if (paperKind.Equals(paperSize.Kind))	return true;
			}
			return false;
		}
		
		/// <summary>
		/// �󎚈ʒu����
		/// </summary>
		/// <param name="positionAdjLib">�󎚈ʒu�������i�I�u�W�F�N�g</param>
		/// <param name="rpt">�Ώۃ��|�[�g�I�u�W�F�N�g</param>
		/// <param name="commonInfo">���ʃp�����[�^���</param>
		/// <param name="isBackGroundPicture">�w�i�摜�쐬�L��</param>
		/// <remarks>
		/// <br>Note       : �󎚈ʒu�������i�ɂ��󎚈ʒu�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.06</br>
		/// </remarks>
		internal void AdjustPrintPosition(ref SFCMN00294CA positionAdjLib, ref DataDynamics.ActiveReports.ActiveReport3 rpt,SFCMN00293UC commonInfo,bool isBackGroundPicture)
		{
			// �󎚈ʒu��������
			if (commonInfo.PrintPositionAdjust == 1)
			{
				// �󎚈ʒu�������s
				positionAdjLib.XmlRead_OutputPrtItemInfoSet(
					commonInfo.OutputFormID,
					rpt,
					isBackGroundPicture);
			}
		}

		/// <summary>
		/// �ݒ�t�@�C���Ǎ�����
		/// </summary>
		/// <param name="fileName">�ݒ�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���ʐݒ��ʂ̐݃t�@�C����Ǎ��܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.09</br>
		/// </remarks>
		internal bool ReadSettingFile(string fileName)
		{
			bool result = false;
			try
			{
				// �t�@�C���̑��݊m�F
				if(System.IO.File.Exists(fileName))
				{
					doc.Load(fileName);
					result = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return result;
		}
		
		/// <summary>
		/// �Z�N�V�����Ǎ�����
		/// </summary>
		/// <param name="sectionName">�Z�N�V������</param>
		/// <param name="key">�L�[</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �Z�N�V�����A�L�[�����ݒ�l���擾���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.12.09</br>
		/// </remarks>
		internal object ReadSection(string sectionName, string key)
		{
			object retObj = null;

			try
			{
				if (doc != null)
				{
					//�Z�N�V������KEY����ݒ�����擾
					// XML�t�@�C���̌���
					XmlNode xmlNode = doc.SelectSingleNode("/Sections/Section/"+sectionName+"/"+key);			
					string retStr = xmlNode.FirstChild.InnerText;

					retObj = retStr;
				}
			}
			catch (Exception)
			{
			}
			return retObj;
		}
		
		/// <summary>
		/// ���b�Z�[�W�\��
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="iMsg">�G���[���b�Z�[�W</param>
		/// <param name="iSt">�X�e�[�^�X</param>
		/// <param name="iButton">�\���{�^��</param>
		/// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		internal DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "SFCMN00293U", iMsg, iSt, iButton, iDefButton);
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        /// <summary>
        /// �v�����^�ݒ�擾����
        /// </summary>
        /// <param name="enterpriseName"></param>
        /// <param name="printerName"></param>
        /// <returns></returns>
        internal PrtManage GetPrtManage( string enterpriseName, string printerName )
        {
            PrtManage prtManage = null;

            int status;
            ArrayList retList = _prtManageList;
            if ( retList == null )
            {
                PrtManageAcs prtManageAcs = new Broadleaf.Application.Controller.PrtManageAcs();
                status = prtManageAcs.SearchAll( out retList, enterpriseName );
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                List<PrtManage> prtManageList = new List<PrtManage>( (PrtManage[])retList.ToArray( typeof( PrtManage ) ) );
                if ( prtManageList != null )
                {
                    prtManage = prtManageList.Find( 
                                    delegate( PrtManage prt )
                                    {
                                        return (prt.PrinterName.Trim() == printerName.Trim());
                                    } );
                }
            }
            return prtManage;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/22 ADD
        /// <summary>
        /// �h�L�������g�������
        /// </summary>
        /// <param name="showDialog"></param>
        /// <param name="report"></param>
        /// <param name="printerName"></param>
        /// <returns></returns>
        /// <br>Update Note: 2012/05/17 yangmj</br>
        /// <br>           : �w��y�[�W����̒ǉ�</br>
        internal bool PrintDocument( bool showDialog, DataDynamics.ActiveReports.ActiveReport3 report, string printerName )
        {
            // ���|�[�g��ޔ�
            _report = report;
            //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�----->>>>>
            if (_pageList != null && _pageList.Count > 0)
            {
                for (int i = _report.Document.Pages.Count - 1; i >= 0; i--)
                {
                    if (!_pageList.Contains(i))
                    {
                        _report.Document.Pages.RemoveAt(i);
                    }
                }
            }
            //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�-----<<<<<

            // �L�����Z���t���O������
            _cancel = false;
            // �C�x���g�o�^
            report.Document.Printer.BeginPrint += new PrintEventHandler( Printer_BeginPrint );
            
            // ����i�J�n����Printer_BeginPrint���R�[�������j
            //report.Document.Print( showDialog, false, false );
            report.Document.Print( false, false, false );

            return _cancel;
        }
        //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�----->>>>>
        /// <summary>
        /// �I�����ꂽ�y�[�W�̐ݒ�
        /// </summary>
        /// <param name="pageList"></param>
        /// <returns></returns>
        /// <br>Note       : �I�����ꂽ�y�[�W��ݒ肷��B</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2012/05/17</br>
        /// <br></br>
        internal void setPageRange(ArrayList pageList)
        {
            _pageList = pageList;
        }
        //--- ADD 2012/05/17 yangmj �w��y�[�W����̒ǉ�-----<<<<<

        /// <summary>
        /// ����J�n�����i�ʏ폈���E�J�X�^�����������؂�ւ���j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Printer_BeginPrint( object sender, PrintEventArgs e )
        {
            try
            {
                // �v�����^���擾���v�����^�ݒ�擾
                string printerName = _report.Document.Printer.PrinterSettings.PrinterName.Trim();
                PrtManage prtManage = GetPrtManage( LoginInfoAcquisition.EnterpriseCode.Trim(), printerName );

                // �Y���Ȃ��A0:���[�U�[�A�p���T�C�Y=Custom�Ȃ�Βʏ�̏���
                if ( prtManage == null || prtManage.PrinterKind == 0 || _report.PageSettings.PaperKind == PaperKind.Custom )
                {
                    //-----------------------------------------------
                    // .NS�W���̈�������i���[�U�[�v�����^�j
                    //-----------------------------------------------
                    e.Cancel = false;
                }
                else
                {
                    //-----------------------------------------------
                    // �p���g�傷��i�h�b�g�v�����^�Ή��j
                    //-----------------------------------------------
                    e.Cancel = true;

                    // �ʏ폈�����L�����Z�����Ĉȉ��̏����ō����ւ���
                    PrintDocusmentControl printDocusmentControl = new PrintDocusmentControl();
                    printDocusmentControl.Report = _report;
                    printDocusmentControl.PrinterName = printerName;
                    printDocusmentControl.Print();
                }
                _cancel = e.Cancel;
            }
            catch
            {
            }
        }

        # region [�h�L�������g�������N���X]
        /// <summary>
        /// �h�L�������g�������N���X
        /// </summary>
        internal class PrintDocusmentControl
        {
            private DataDynamics.ActiveReports.Document.Document ardoc;
            private int arPages;
            private DataDynamics.ActiveReports.ActiveReport3 _report;
            private string _printerName;

            /// <summary>
            /// �v�����^��
            /// </summary>
            public string PrinterName
            {
                get { return _printerName; }
                set { _printerName = value; }
            }

            /// <summary>
            /// ���|�[�g
            /// </summary>
            public DataDynamics.ActiveReports.ActiveReport3 Report
            {
                get { return _report; }
                set { _report = value; }
            }

            /// <summary>
            /// �y�[�W����C�x���g����
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void PrintPage( object sender, System.Drawing.Printing.PrintPageEventArgs e )
            {
                if ( _report.Document.Printer.PrinterSettings.PrintRange == PrintRange.AllPages ||
                     (_report.Document.Printer.PrinterSettings.FromPage <= arPages &&
                      arPages <= _report.Document.Printer.PrinterSettings.ToPage) )
                {
                    // PrintDocumet�̍��W�P�ʂ�1/100�C���`�Ȃ̂ŁA�ȍ~�A�C���`�ň������߂ɂ����ŕϊ����܂��B
                    float width = e.PageBounds.Width / 100.0f;
                    float height = e.PageBounds.Height / 100.0f;

                    //RectangleF boundsInch = new RectangleF( 0, 0, width, height );
                    RectangleF boundsInch = new RectangleF( -0.2f, 0, width - 0.5f, height );

                    // PrintDocument�ɕ`�悷��ActiveReports�y�[�W���擾���܂��B
                    DataDynamics.ActiveReports.Document.Page page = ardoc.Pages[arPages];

                    // �g��k����̌v�Z
                    float scaleX = boundsInch.Width / page.Width;
                    float scaleY = boundsInch.Height / page.Height;

                    // ���|�[�g�̃A�X�y�N�g����ێ����邽�߂ɁAscaleX��scaleY��
                    // �����l�ɃZ�b�g���܂��B
                    // �����̃A�X�y�N�g�䂪�ێ�����Ȃ��ꍇ�A������Ƀt�H���g�������ȂǕ��Q���������܂��B
                    if ( scaleX > scaleY ) scaleX = scaleY;
                    else scaleY = scaleX;

                    // �y�[�W��`�悵�܂��B
                    page.Draw( e.Graphics, boundsInch, scaleX, scaleY, true );
                }
                else
                {
                    // �ΏۊO
                }

                arPages++;

                // �S�y�[�W���������I�����܂��B
                if ( arPages < ardoc.Pages.Count )
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }
            }
            /// <summary>
            /// ������s
            /// </summary>
            public void Print()
            {
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();

                // �h�L�������g��
                pd.DocumentName = _report.Document.Name;
                // �v�����^��
                pd.PrinterSettings.PrinterName = _printerName;
                // �p���T�C�Y
                // �@���X�g�b�N�t�H�[���ɍ��킹��i15.00[inch]�~11.00[inch]�j
                pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize( "ARCustomForm", 1500, 1100 );

                // �p������
                pd.DefaultPageSettings.Landscape = (_report.PageSettings.Orientation == PageOrientation.Landscape);

                // ������_�C�A���O���o���Ȃ�
                pd.PrintController = new StandardPrintController();

                // �ň���C�x���g�����̓o�^
                pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler( PrintPage );
                ardoc = _report.Document;
                arPages = 0;

                pd.Print();
            }
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/22 ADD
	}

	/// <summary>
	/// ActiveReport���ʕ��i��O�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ActiveReport���ʕ��i��O�N���X�ł��B</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2005.11.18</br>
	/// <br></br>
	/// </remarks>
	public class ActiveReportPrintException: ApplicationException
	{
		private int _status;

		/// <summary>
		/// ActiveReport���ʕ��i��O�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.18</br>
		/// </remarks>
		public ActiveReportPrintException(string message, int status): base(message)
		{
			this._status = status;
		}
	
		/// <summary>
		/// �G���[�X�e�[�^�X
		/// </summary>
		public int Status
		{
			get{return this._status;}
		}
	}

}
