using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Drawing.Printing;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ActiveReport���ʊ֐����i�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ActiveReport���ʊ֐����i�N���X(SFANL08203UC)�̎��R���[�Ł@�{���͌p�������������E�E�E</br>
    /// <br>Programmer : 22011 Kashihara Yorihito</br>
    /// <br>Date       : 2007.06.15</br>
    /// <br>           : </br>
    /// </remarks>
    public class SFANL08203UC
    {
        //================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// ActiveReport�֐����i�N���X�R���X�g���N�^
		/// </summary>
        public SFANL08203UC()
		{
		}
		#endregion

        #region private member
        private XmlDocument doc = new XmlDocument();			// �ݒ�t�@�C���Ǎ��p�h�L�������g
        #endregion

        #region public methods

        #region ��ʐݒ�t�@�C���Ǎ�����
        /// <summary>
        /// ��ʐݒ�t�@�C���Ǎ�����
        /// </summary>
        /// <param name="fileName">�ݒ�t�@�C����</param>
        public bool ReadSettingFile(string fileName)
        {
            bool result = false;
            try
            {
                // �t�@�C���̑��݊m�F
                if (System.IO.File.Exists(fileName))
                {
                    doc.Load(fileName);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFANL08203UC", "��ʐݒ�t�@�C���Ǎ������Ɏ��s���܂����B\r\n�ڍׁF" + ex.Message, 0, MessageBoxButtons.OK);
            }
            return result;
        }
        #endregion

        #region �Z�N�V�����Ǎ�����
        /// <summary>
        /// �Z�N�V�����Ǎ�����
        /// </summary>
        /// <param name="sectionName">�Z�N�V������</param>
        /// <param name="key">�L�[</param>
        /// <returns></returns>
        public object ReadSection(string sectionName, string key)
        {
            object retObj = null;

            try
            {
                if (doc != null)
                {
                    //�Z�N�V������KEY����ݒ�����擾
                    // XML�t�@�C���̌���
                    XmlNode xmlNode = doc.SelectSingleNode("/Sections/Section/" + sectionName + "/" + key);
                    string retStr = xmlNode.FirstChild.InnerText;

                    retObj = retStr;
                }
            }
            catch (Exception)
            {
            }
            return retObj;
        }
        #endregion

        #region �v�����^�[���ݒ菈��
        /// <summary>
        /// �v�����^�[���ݒ菈��
        /// </summary>
        /// <param name="rpt">�Ώ�ActiveReport�N���X</param>
        /// <param name="commonInfo">���ʃp�����[�^���</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        public int SetPrinterInfo(ref DataDynamics.ActiveReports.ActiveReport3 rpt, SFANL08203UD commonInfo, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            try
            {
                // ����h�L�������g��
                rpt.Document.Name = commonInfo.PrintName;

                // �㉺���E�]���ݒ�
                float marginsTop = rpt.PageSettings.Margins.Top;
                float marginsBottom = rpt.PageSettings.Margins.Bottom;
                float marginsLeft = rpt.PageSettings.Margins.Left;
                float marginsRight = rpt.PageSettings.Margins.Right;

                marginsTop += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsTop / 100);
                if (marginsTop < 0) marginsTop = (float)0;

                marginsBottom += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsBottom / 100);
                if (marginsBottom < 0) marginsBottom = (float)0;

                marginsLeft += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsLeft / 100);
                if (marginsLeft < 0) marginsLeft = (float)0;

                marginsRight += DataDynamics.ActiveReports.ActiveReport3.CmToInch((float)commonInfo.MarginsRight / 100);
                if (marginsRight < 0) marginsRight = (float)0;

                rpt.PageSettings.Margins.Top = marginsTop;
                rpt.PageSettings.Margins.Bottom = marginsBottom;
                rpt.PageSettings.Margins.Left = marginsLeft;
                rpt.PageSettings.Margins.Right = marginsRight;

                // ����͈͂��w��
                // �S�y�[�W
                if (commonInfo.PrintRange == 0)
                {
                    rpt.Document.Printer.PrinterSettings.PrintRange = PrintRange.AllPages;
                }

                    // �y�[�W�͈͎w��
                else
                {
                    rpt.Document.Printer.PrinterSettings.PrintRange = PrintRange.SomePages;
                    rpt.Document.Printer.PrinterSettings.FromPage = commonInfo.PrintTopPage;
                    rpt.Document.Printer.PrinterSettings.ToPage = commonInfo.PrintEndPage;
                }

                rpt.Document.Printer.PrinterSettings.PrintRange = PrintRange.AllPages;

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
                    // isPaperKind = CheckSupportPaperKind(rpt.PageSettings.PaperKind, rpt.Document.Printer.DefaultPageSettings.PrinterSettings.PaperSizes);

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
        #endregion

        #region �p���T�|�[�g�`�F�b�N
        /// <summary>
        /// �p���T�|�[�g�`�F�b�N
        /// </summary>
        /// <param name="paperKind">�p���T�C�Y</param>
        /// <param name="paperSizeCollection">�Y���v�����^�̗p���T�C�Y�R���N�V����</param>
        /// <returns>[T:�T�|�[�g,F:��T�|�[�g]</returns>
        internal bool CheckSupportPaperKind(PaperKind paperKind, PrinterSettings.PaperSizeCollection paperSizeCollection)
        {
            foreach (PaperSize paperSize in paperSizeCollection)
            {
                if (paperKind.Equals(paperSize.Kind)) return true;
            }
            return false;
        }
        #endregion

        #region ���b�Z�[�W�\��
        /// <summary>
        /// ���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
        public DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "SFANL08203U", iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        #endregion
    }
}
