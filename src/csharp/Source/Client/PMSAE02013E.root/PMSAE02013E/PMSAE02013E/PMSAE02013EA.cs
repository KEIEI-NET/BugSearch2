//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o�̓N���X
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�̓N���X���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhuhh
// �� �� ��  2013/03/06  �C�����e : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10901034-00  �쐬�S�� : �c����
// �� �� ��  2013/06/26  �C�����e : �r���d(AB) �e�L�X�g�o�͎������M�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesHistoryCndtn
    /// <summary>
    ///                      ���㗚���f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㗚���f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2009/08/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/9  ����</br>
    /// <br>                 :   ���X�y���~�X�C��</br>
    /// <br>                 :   ����l����ېőΏۊz���v</br>
    /// <br>                 :   ���㐳�����z</br>
    /// <br>                 :   ������z����Ŋz�i�O�Łj</br>
    /// <br>Update Note      :   2008/7/29  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   ���Ӑ�`�[�ԍ�</br>
    /// <br>UpdateNote       :   2013/02/25 zhuhh</br>
    /// <br>                 :   �r���d(AB) �e�L�X�g�o�͂̃��C�A�E�g�ύX</br>
    /// <br>UpdateNote       :   2013/06/26 �c����</br>
    /// <br>                 :   �������M�����̒ǉ��y�ё��M���O�̓o�^</br>
    /// </remarks>
    public class SalesHistoryCndtn
    {

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string[] _sectionCodeList;

        /// <summary>�v���(�J�n)</summary>
        private Int32 _addUpADateSt;

        /// <summary>�v���(�I��)</summary>
        private Int32 _addUpADateEd;

        /// <summary>���Ӑ�(�J�n)</summary>
        private Int32 _customerCodeSt;

        /// <summary>���Ӑ�(�I��)</summary>
        private Int32 _customerCodeEd;

        /// <summary>�m�F���X�g</summary>
        private Int32 _conFirmDiv;

        /// <summary>�o�͎w��</summary>
        private Int32 _pdfOutDiv;

        /// <summary>�t�@�C����</summary>
        private string _fileName = "";

        /// <summary>��ʃ��[�h</summary>
        private Int32 _mode;

        // ----- ADD zhuhh 2013/03/06 for Redmine#35011----->>>>>
        /// <summary>�������M�敪</summary>
        private Int32 _autoDataSendDiv;
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        //----- ADD �c���� 2013/06/26 ----->>>>>
        /// <summary>���M�敪(0:�蓮;1:����)</summary>
        private Int32 _sendDataDiv;
        //----- ADD �c���� 2013/06/26 -----<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCodeList
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// public propaty name  :  AddUpADateSt
        /// <summary>�v���(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpADateSt
        {
            get { return _addUpADateSt; }
            set { _addUpADateSt = value; }
        }

        /// public propaty name  :  AddUpADateEd
        /// <summary>�v���(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpADateEd
        {
            get { return _addUpADateEd; }
            set { _addUpADateEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>���Ӑ�(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>���Ӑ�(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  ConFirmDiv
        /// <summary>�m�F���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �m�F���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConFirmDiv
        {
            get { return _conFirmDiv; }
            set { _conFirmDiv = value; }
        }

        /// public propaty name  :  PdfOutDiv
        /// <summary>�o�͎w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PdfOutDiv
        {
            get { return _pdfOutDiv; }
            set { _pdfOutDiv = value; }
        }

        /// public propaty name  :  FileName
        /// <summary>�t�@�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  Mode
        /// <summary>��ʃ��[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        // ----- ADD zhuhh 2013/03/06 for Redmine#A35011----->>>>>
        /// public propaty name  :  AutoDataSendDiv
        /// <summary>�������M�敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������M�敪�i0�F���M����@1�F���M���Ȃ��j</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDataSendDiv
        {
            get { return _autoDataSendDiv; }
            set { _autoDataSendDiv = value; }
        }
        // ----- ADD zhuhh 2013/03/06 for Redmine#35011-----<<<<<

        //----- ADD �c���� 2013/06/26 ----->>>>>
        /// public propaty name  :  SendDataDiv
        /// <summary>���M�敪(0:�蓮;1:����)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�敪(0:�蓮;1:����)</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SendDataDiv
        {
            get { return _sendDataDiv; }
            set { _sendDataDiv = value; }
        }
        //----- ADD �c���� 2013/06/26 -----<<<<<

        /// <summary>
        /// ���㗚���f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>SalesHistoryCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesHistoryCndtn()
        {
        }

        /// <summary>
        /// ���㗚���f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="addUpADateSt">�v���(�J�n)</param>
        /// <param name="addUpADateEd">�v���(�I��)</param>
        /// <param name="customerCodeSt">���Ӑ�(�J�n)</param>
        /// <param name="customerCodeEd">���Ӑ�(�I��)</param>
        /// <param name="conFirmDiv">�m�F���X�g</param>
        /// <param name="pdfOutDiv">�o�͎w��</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="mode">��ʃ��[�h</param>
        /// <returns>SalesHistoryCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public SalesHistoryCndtn(Int32 addUpADateSt, Int32 addUpADateEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 conFirmDiv, Int32 pdfOutDiv, string fileName, Int32 mode) // DEL �c���� 2013/06/26
        public SalesHistoryCndtn(Int32 addUpADateSt, Int32 addUpADateEd, Int32 customerCodeSt, Int32 customerCodeEd, Int32 conFirmDiv, Int32 pdfOutDiv, string fileName, Int32 mode, Int32 autoDataSendDiv, Int32 sendDataDiv) // ADD �c���� 2013/06/26
        {
            this._addUpADateSt = addUpADateSt;
            this._addUpADateEd = addUpADateEd;
            this._customerCodeSt = customerCodeSt;
            this._customerCodeEd = customerCodeEd;
            this._conFirmDiv = conFirmDiv;
            this._pdfOutDiv = pdfOutDiv;
            this._fileName = fileName;
            this._mode = mode;
            this._autoDataSendDiv = autoDataSendDiv; // ADD �c���� 2013/06/26
            this._sendDataDiv = sendDataDiv; // ADD �c���� 2013/06/26

        }

        /// <summary>
        /// ���㗚���f�[�^��������
        /// </summary>
        /// <returns>SalesHistoryCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesHistoryCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesHistoryCndtn Clone()
        {
            //return new SalesHistoryCndtn(this._addUpADateSt, this._addUpADateEd, this._customerCodeSt, this._customerCodeEd, this._conFirmDiv, this._pdfOutDiv, this._fileName,this._mode); // DEL �c���� 2013/06/26
            return new SalesHistoryCndtn(this._addUpADateSt, this._addUpADateEd, this._customerCodeSt, this._customerCodeEd, this._conFirmDiv, this._pdfOutDiv, this._fileName, this._mode, this._autoDataSendDiv, this._sendDataDiv); // ADD �c���� 2013/06/26
        }

        /// <summary>
        /// ���㗚���f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesHistoryCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalesHistoryCndtn target)
        {
            return ((this.AddUpADateSt == target.AddUpADateSt)
                 && (this.AddUpADateEd == target.AddUpADateEd)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
                 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.ConFirmDiv == target.ConFirmDiv)
                 && (this.PdfOutDiv == target.PdfOutDiv)
                 && (this.FileName == target.FileName)
                //&& (this.Mode == target.Mode)); // DEL �c���� 2013/06/26
                //----- ADD �c���� 2013/06/26 ----->>>>>
                && (this.Mode == target.Mode)
                && (this.AutoDataSendDiv == target.AutoDataSendDiv)
                && (this.SendDataDiv == target.SendDataDiv));
                //----- ADD �c���� 2013/06/26 -----<<<<<
        }

        /// <summary>
        /// ���㗚���f�[�^��r����
        /// </summary>
        /// <param name="salesHistoryCndtn1">
        ///                    ��r����SalesHistoryCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesHistoryCndtn2">��r����SalesHistoryCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalesHistoryCndtn salesHistoryCndtn1, SalesHistoryCndtn salesHistoryCndtn2)
        {
            return ((salesHistoryCndtn1.AddUpADateSt == salesHistoryCndtn2.AddUpADateSt)
                 && (salesHistoryCndtn1.AddUpADateEd == salesHistoryCndtn2.AddUpADateEd)
                 && (salesHistoryCndtn1.CustomerCodeSt == salesHistoryCndtn2.CustomerCodeSt)
                 && (salesHistoryCndtn1.CustomerCodeEd == salesHistoryCndtn2.CustomerCodeEd)
                 && (salesHistoryCndtn1.ConFirmDiv == salesHistoryCndtn2.ConFirmDiv)
                 && (salesHistoryCndtn1.PdfOutDiv == salesHistoryCndtn2.PdfOutDiv)
                 && (salesHistoryCndtn1.FileName == salesHistoryCndtn2.FileName)
                //&& (salesHistoryCndtn1.Mode == salesHistoryCndtn2.Mode)); // DEL �c���� 2013/06/26
                //----- ADD �c���� 2013/06/26 ----->>>>>
                && (salesHistoryCndtn1.Mode == salesHistoryCndtn2.Mode)
                && (salesHistoryCndtn1.AutoDataSendDiv == salesHistoryCndtn2.AutoDataSendDiv)
                && (salesHistoryCndtn1.SendDataDiv == salesHistoryCndtn2.SendDataDiv));
                //----- ADD �c���� 2013/06/26 -----<<<<<
        }
        /// <summary>
        /// ���㗚���f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesHistoryCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalesHistoryCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.AddUpADateSt != target.AddUpADateSt) resList.Add("AddUpADateSt");
            if (this.AddUpADateEd != target.AddUpADateEd) resList.Add("AddUpADateEd");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (this.ConFirmDiv != target.ConFirmDiv) resList.Add("ConFirmDiv");
            if (this.PdfOutDiv != target.PdfOutDiv) resList.Add("PdfOutDiv");
            if (this.FileName != target.FileName) resList.Add("FileName");
            if (this.Mode != target.Mode) resList.Add("Mode");
            //----- ADD �c���� 2013/06/26 ----->>>>>
            if (this.AutoDataSendDiv != target.AutoDataSendDiv) resList.Add("AutoDataSendDiv");
            if (this.SendDataDiv != target.SendDataDiv) resList.Add("SendDataDiv");
            //----- ADD �c���� 2013/06/26 -----<<<<<

            return resList;
        }

        /// <summary>
        /// ���㗚���f�[�^��r����
        /// </summary>
        /// <param name="salesHistoryCndtn1">��r����SalesHistoryCndtn�N���X�̃C���X�^���X</param>
        /// <param name="salesHistoryCndtn2">��r����SalesHistoryCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesHistoryCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalesHistoryCndtn salesHistoryCndtn1, SalesHistoryCndtn salesHistoryCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (salesHistoryCndtn1.AddUpADateSt != salesHistoryCndtn2.AddUpADateSt) resList.Add("AddUpADateSt");
            if (salesHistoryCndtn1.AddUpADateEd != salesHistoryCndtn2.AddUpADateEd) resList.Add("AddUpADateEd");
            if (salesHistoryCndtn1.CustomerCodeSt != salesHistoryCndtn2.CustomerCodeSt) resList.Add("CustomerCodeSt");
            if (salesHistoryCndtn1.CustomerCodeEd != salesHistoryCndtn2.CustomerCodeEd) resList.Add("CustomerCodeEd");
            if (salesHistoryCndtn1.ConFirmDiv != salesHistoryCndtn2.ConFirmDiv) resList.Add("ConFirmDiv");
            if (salesHistoryCndtn1.PdfOutDiv != salesHistoryCndtn2.PdfOutDiv) resList.Add("PdfOutDiv");
            if (salesHistoryCndtn1.FileName != salesHistoryCndtn2.FileName) resList.Add("FileName");
            if (salesHistoryCndtn1.Mode != salesHistoryCndtn2.Mode) resList.Add("Mode");
            //----- ADD �c���� 2013/06/26 ----->>>>>
            if (salesHistoryCndtn1.AutoDataSendDiv != salesHistoryCndtn2.AutoDataSendDiv) resList.Add("AutoDataSendDiv");
            if (salesHistoryCndtn1.SendDataDiv != salesHistoryCndtn2.SendDataDiv) resList.Add("SendDataDiv");
            //----- ADD �c���� 2013/06/26 -----<<<<<

            return resList;
        }
    }
}
