//*************************************************************************************//
// System			:	Partsman									                   //
// Sub System       :				     								               //
// Program name     :	��ʓ��̓N���X					�@�@�@�@�@�@                   //
//					:	PMSCM01211E.DLL									               //
// Name Space		:	Broadleaf.Application.UIData							       //
// Programmer		:	���e										                   //
// Date				:	2011.07.31	                                                   //
//                                                                                     //
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpDisplay
    /// <summary>
    ///                      ��ʓ��̓N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��ʓ��̓N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/12</br>
    /// <br>Genarated Date   :   2011/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpDisplay
    {
        /// <summary>�����From</summary>
        private DateTime _salesDateSt;

        /// <summary>�����To</summary>
        private DateTime _salesDateEd;

        /// <summary>���͓�From</summary>
        private DateTime _inpDateSt;

        /// <summary>���͓�To</summary>
        private DateTime _inpDateEd;

        /// <summary>���_From</summary>
        private string _sectionCodeSt = "";

        /// <summary>���_From����</summary>
        private string _sectionNameSt = "";

        /// <summary>���_To</summary>
        private string _sectionCodeEd = "";

        /// <summary>���_To����</summary>
        private string _sectionNameEd = "";

        /// <summary>���Ӑ�From</summary>
        private Int32 _customerCodeSt;

        /// <summary>���Ӑ�From����</summary>
        private string _customerNameSt = "";

        /// <summary>���Ӑ�To</summary>
        private Int32 _customerCodeEd;

        /// <summary>���Ӑ�To����</summary>
        private string _customerNameEd = "";

        /// <summary>�`�[�ԍ�From</summary>
        private Int32 _slipNoSt;

        /// <summary>�`�[�ԍ�To</summary>
        private Int32 _slipNoEd;

        /// <summary>�e�L�X�g�i�[�t�H���_</summary>
        private string _textSaveFolder = "";

        /// <summary>�o�͌���</summary>
        private Int32 _outpCount;


        /// public propaty name  :  SalesDateSt
        /// <summary>�����From�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����From�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>�����To�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����To�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  InpDateSt
        /// <summary>���͓�From�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�From�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InpDateSt
        {
            get { return _inpDateSt; }
            set { _inpDateSt = value; }
        }

        /// public propaty name  :  InpDateEd
        /// <summary>���͓�To�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�To�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InpDateEd
        {
            get { return _inpDateEd; }
            set { _inpDateEd = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>���_From�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_From�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionNameSt
        /// <summary>���_From���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_From���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionNameSt
        {
            get { return _sectionNameSt; }
            set { _sectionNameSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>���_To�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_To�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SectionNameEd
        /// <summary>���_To���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_To���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionNameEd
        {
            get { return _sectionNameEd; }
            set { _sectionNameEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>���Ӑ�From�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�From�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerNameSt
        /// <summary>���Ӑ�From���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�From���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerNameSt
        {
            get { return _customerNameSt; }
            set { _customerNameSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>���Ӑ�To�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�To�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  CustomerNameEd
        /// <summary>���Ӑ�To���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�To���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerNameEd
        {
            get { return _customerNameEd; }
            set { _customerNameEd = value; }
        }

        /// public propaty name  :  SlipNoSt
        /// <summary>�`�[�ԍ�From�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ�From�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNoSt
        {
            get { return _slipNoSt; }
            set { _slipNoSt = value; }
        }

        /// public propaty name  :  SlipNoEd
        /// <summary>�`�[�ԍ�To�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ�To�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNoEd
        {
            get { return _slipNoEd; }
            set { _slipNoEd = value; }
        }

        /// public propaty name  :  TextSaveFolder
        /// <summary>�e�L�X�g�i�[�t�H���_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�L�X�g�i�[�t�H���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TextSaveFolder
        {
            get { return _textSaveFolder; }
            set { _textSaveFolder = value; }
        }

        /// public propaty name  :  OutpCount
        /// <summary>�o�͌����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͌����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutpCount
        {
            get { return _outpCount; }
            set { _outpCount = value; }
        }


        /// <summary>
        /// ��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay()
        {
        }

        /// <summary>
        /// ��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <param name="salesDateSt">�����From</param>
        /// <param name="salesDateEd">�����To</param>
        /// <param name="inpDateSt">���͓�From</param>
        /// <param name="inpDateEd">���͓�To</param>
        /// <param name="sectionCodeSt">���_From</param>
        /// <param name="sectionNameSt">���_From����</param>
        /// <param name="sectionCodeEd">���_To</param>
        /// <param name="sectionNameEd">���_To����</param>
        /// <param name="customerCodeSt">���Ӑ�From</param>
        /// <param name="customerNameSt">���Ӑ�From����</param>
        /// <param name="customerCodeEd">���Ӑ�To</param>
        /// <param name="customerNameEd">���Ӑ�To����</param>
        /// <param name="slipNoSt">�`�[�ԍ�From</param>
        /// <param name="slipNoEd">�`�[�ԍ�To</param>
        /// <param name="textSaveFolder">�e�L�X�g�i�[�t�H���_</param>
        /// <param name="outpCount">�o�͌���</param>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay(DateTime salesDateSt, DateTime salesDateEd, DateTime inpDateSt, DateTime inpDateEd, string sectionCodeSt, string sectionNameSt, string sectionCodeEd, string sectionNameEd, Int32 customerCodeSt, string customerNameSt, Int32 customerCodeEd, string customerNameEd, Int32 slipNoSt, Int32 slipNoEd, string textSaveFolder, Int32 outpCount)
        {
            this._salesDateSt = salesDateSt;
            this._salesDateEd = salesDateEd;
            this._inpDateSt = inpDateSt;
            this._inpDateEd = inpDateEd;
            this._sectionCodeSt = sectionCodeSt;
            this._sectionNameSt = sectionNameSt;
            this._sectionCodeEd = sectionCodeEd;
            this._sectionNameEd = sectionNameEd;
            this._customerCodeSt = customerCodeSt;
            this._customerNameSt = customerNameSt;
            this._customerCodeEd = customerCodeEd;
            this._customerNameEd = customerNameEd;
            this._slipNoSt = slipNoSt;
            this._slipNoEd = slipNoEd;
            this._textSaveFolder = textSaveFolder;
            this._outpCount = outpCount;

        }

        /// <summary>
        /// ��ʓ��̓N���X��������
        /// </summary>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����InpDisplay�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay Clone()
        {
            return new InpDisplay(this._salesDateSt, this._salesDateEd, this._inpDateSt, this._inpDateEd, this._sectionCodeSt, this._sectionNameSt, this._sectionCodeEd, this._sectionNameEd, this._customerCodeSt, this._customerNameSt, this._customerCodeEd, this._customerNameEd, this._slipNoSt, this._slipNoEd, this._textSaveFolder, this._outpCount);
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(InpDisplay target)
        {
            return ((this.SalesDateSt == target.SalesDateSt)
                 && (this.SalesDateEd == target.SalesDateEd)
                 && (this.InpDateSt == target.InpDateSt)
                 && (this.InpDateEd == target.InpDateEd)
                 && (this.SectionCodeSt == target.SectionCodeSt)
                 && (this.SectionNameSt == target.SectionNameSt)
                 && (this.SectionCodeEd == target.SectionCodeEd)
                 && (this.SectionNameEd == target.SectionNameEd)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
                 && (this.CustomerNameSt == target.CustomerNameSt)
                 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.CustomerNameEd == target.CustomerNameEd)
                 && (this.SlipNoSt == target.SlipNoSt)
                 && (this.SlipNoEd == target.SlipNoEd)
                 && (this.TextSaveFolder == target.TextSaveFolder)
                 && (this.OutpCount == target.OutpCount));
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpDisplay1">
        ///                    ��r����InpDisplay�N���X�̃C���X�^���X
        /// </param>
        /// <param name="inpDisplay2">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            return ((inpDisplay1.SalesDateSt == inpDisplay2.SalesDateSt)
                 && (inpDisplay1.SalesDateEd == inpDisplay2.SalesDateEd)
                 && (inpDisplay1.InpDateSt == inpDisplay2.InpDateSt)
                 && (inpDisplay1.InpDateEd == inpDisplay2.InpDateEd)
                 && (inpDisplay1.SectionCodeSt == inpDisplay2.SectionCodeSt)
                 && (inpDisplay1.SectionNameSt == inpDisplay2.SectionNameSt)
                 && (inpDisplay1.SectionCodeEd == inpDisplay2.SectionCodeEd)
                 && (inpDisplay1.SectionNameEd == inpDisplay2.SectionNameEd)
                 && (inpDisplay1.CustomerCodeSt == inpDisplay2.CustomerCodeSt)
                 && (inpDisplay1.CustomerNameSt == inpDisplay2.CustomerNameSt)
                 && (inpDisplay1.CustomerCodeEd == inpDisplay2.CustomerCodeEd)
                 && (inpDisplay1.CustomerNameEd == inpDisplay2.CustomerNameEd)
                 && (inpDisplay1.SlipNoSt == inpDisplay2.SlipNoSt)
                 && (inpDisplay1.SlipNoEd == inpDisplay2.SlipNoEd)
                 && (inpDisplay1.TextSaveFolder == inpDisplay2.TextSaveFolder)
                 && (inpDisplay1.OutpCount == inpDisplay2.OutpCount));
        }
        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(InpDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
            if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
            if (this.InpDateSt != target.InpDateSt) resList.Add("InpDateSt");
            if (this.InpDateEd != target.InpDateEd) resList.Add("InpDateEd");
            if (this.SectionCodeSt != target.SectionCodeSt) resList.Add("SectionCodeSt");
            if (this.SectionNameSt != target.SectionNameSt) resList.Add("SectionNameSt");
            if (this.SectionCodeEd != target.SectionCodeEd) resList.Add("SectionCodeEd");
            if (this.SectionNameEd != target.SectionNameEd) resList.Add("SectionNameEd");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (this.CustomerNameSt != target.CustomerNameSt) resList.Add("CustomerNameSt");
            if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (this.CustomerNameEd != target.CustomerNameEd) resList.Add("CustomerNameEd");
            if (this.SlipNoSt != target.SlipNoSt) resList.Add("SlipNoSt");
            if (this.SlipNoEd != target.SlipNoEd) resList.Add("SlipNoEd");
            if (this.TextSaveFolder != target.TextSaveFolder) resList.Add("TextSaveFolder");
            if (this.OutpCount != target.OutpCount) resList.Add("OutpCount");

            return resList;
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpDisplay1">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <param name="inpDisplay2">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpDisplay1.SalesDateSt != inpDisplay2.SalesDateSt) resList.Add("SalesDateSt");
            if (inpDisplay1.SalesDateEd != inpDisplay2.SalesDateEd) resList.Add("SalesDateEd");
            if (inpDisplay1.InpDateSt != inpDisplay2.InpDateSt) resList.Add("InpDateSt");
            if (inpDisplay1.InpDateEd != inpDisplay2.InpDateEd) resList.Add("InpDateEd");
            if (inpDisplay1.SectionCodeSt != inpDisplay2.SectionCodeSt) resList.Add("SectionCodeSt");
            if (inpDisplay1.SectionNameSt != inpDisplay2.SectionNameSt) resList.Add("SectionNameSt");
            if (inpDisplay1.SectionCodeEd != inpDisplay2.SectionCodeEd) resList.Add("SectionCodeEd");
            if (inpDisplay1.SectionNameEd != inpDisplay2.SectionNameEd) resList.Add("SectionNameEd");
            if (inpDisplay1.CustomerCodeSt != inpDisplay2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (inpDisplay1.CustomerNameSt != inpDisplay2.CustomerNameSt) resList.Add("CustomerNameSt");
            if (inpDisplay1.CustomerCodeEd != inpDisplay2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (inpDisplay1.CustomerNameEd != inpDisplay2.CustomerNameEd) resList.Add("CustomerNameEd");
            if (inpDisplay1.SlipNoSt != inpDisplay2.SlipNoSt) resList.Add("SlipNoSt");
            if (inpDisplay1.SlipNoEd != inpDisplay2.SlipNoEd) resList.Add("SlipNoEd");
            if (inpDisplay1.TextSaveFolder != inpDisplay2.TextSaveFolder) resList.Add("TextSaveFolder");
            if (inpDisplay1.OutpCount != inpDisplay2.OutpCount) resList.Add("OutpCount");

            return resList;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                