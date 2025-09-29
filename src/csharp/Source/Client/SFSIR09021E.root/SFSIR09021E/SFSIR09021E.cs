using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PaymentSet
    /// <summary>
    ///                      �x���ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x���ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/03/30</br>
    /// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006.08.01  23006 ���� ���q</br>
    /// <br>			            �E���ڒǉ�</br>
    /// <br>Update Note      :   2008.06.18  ���i �r��</br>
    /// <br>	�@                  �E���ځu�x���`�[�ďo�����v�폜</br>
    /// </remarks>
    public class PaymentSet
    {
        /*----------------------------------------------------------------------------------*/
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        private Int32 _logicalDeleteCode;

        /// <summary>�x���ݒ�Ǘ�No</summary>
        /// <remarks>0�Œ�</remarks>
        private Int32 _payStMngNo;

        ///// <summary>�����I������R�[�h</summary>
        //private Int32 _initSelMoneyKindCd;

        /// <summary>�x���ݒ����R�[�h1</summary>
        private Int32 _payStMoneyKindCd1;

        /// <summary>�x���ݒ����R�[�h2</summary>
        private Int32 _payStMoneyKindCd2;

        /// <summary>�x���ݒ����R�[�h3</summary>
        private Int32 _payStMoneyKindCd3;

        /// <summary>�x���ݒ����R�[�h4</summary>
        private Int32 _payStMoneyKindCd4;

        /// <summary>�x���ݒ����R�[�h5</summary>
        private Int32 _payStMoneyKindCd5;

        /// <summary>�x���ݒ����R�[�h6</summary>
        private Int32 _payStMoneyKindCd6;

        /// <summary>�x���ݒ����R�[�h7</summary>
        private Int32 _payStMoneyKindCd7;

        /// <summary>�x���ݒ����R�[�h8</summary>
        private Int32 _payStMoneyKindCd8;

        /// <summary>�x���ݒ����R�[�h9</summary>
        private Int32 _payStMoneyKindCd9;

        /// <summary>�x���ݒ����R�[�h10</summary>
        private Int32 _payStMoneyKindCd10;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <summary>�x���`�[�ďo����</summary>
        //private Int32 _paySlipCallMonths;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
        ///// <summary>�����I�����햼��</summary>
        //private string _initSelMoneyKindNm = "";

        /// <summary>�x���ݒ���햼��1</summary>
        private string _payStMoneyKindNm1 = "";

        /// <summary>�x���ݒ���햼��2</summary>
        private string _payStMoneyKindNm2 = "";

        /// <summary>�x���ݒ���햼��3</summary>
        private string _payStMoneyKindNm3 = "";

        /// <summary>�x���ݒ���햼��4</summary>
        private string _payStMoneyKindNm4 = "";

        /// <summary>�x���ݒ���햼��5</summary>
        private string _payStMoneyKindNm5 = "";

        /// <summary>�x���ݒ���햼��6</summary>
        private string _payStMoneyKindNm6 = "";

        /// <summary>�x���ݒ���햼��7</summary>
        private string _payStMoneyKindNm7 = "";

        /// <summary>�x���ݒ���햼��8</summary>
        private string _payStMoneyKindNm8 = "";

        /// <summary>�x���ݒ���햼��9</summary>
        private string _payStMoneyKindNm9 = "";

        /// <summary>�x���ݒ���햼��10</summary>
        private string _payStMoneyKindNm10 = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

        /*----------------------------------------------------------------------------------*/
        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PayStMngNo
        /// <summary>�x���ݒ�Ǘ�No�v���p�e�B</summary>
        /// <value>0�Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ�Ǘ�No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMngNo
        {
            get { return _payStMngNo; }
            set { _payStMngNo = value; }
        }

        ///// public propaty name  :  InitSelMoneyKindCd
        ///// <summary>�����I������R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �����I������R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 InitSelMoneyKindCd
        //{
        //    get { return _initSelMoneyKindCd; }
        //    set { _initSelMoneyKindCd = value; }
        //}

        /// public propaty name  :  PayStMoneyKindCd1
        /// <summary>�x���ݒ����R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd1
        {
            get { return _payStMoneyKindCd1; }
            set { _payStMoneyKindCd1 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd2
        /// <summary>�x���ݒ����R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd2
        {
            get { return _payStMoneyKindCd2; }
            set { _payStMoneyKindCd2 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd3
        /// <summary>�x���ݒ����R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd3
        {
            get { return _payStMoneyKindCd3; }
            set { _payStMoneyKindCd3 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd4
        /// <summary>�x���ݒ����R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd4
        {
            get { return _payStMoneyKindCd4; }
            set { _payStMoneyKindCd4 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd5
        /// <summary>�x���ݒ����R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd5
        {
            get { return _payStMoneyKindCd5; }
            set { _payStMoneyKindCd5 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd6
        /// <summary>�x���ݒ����R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd6
        {
            get { return _payStMoneyKindCd6; }
            set { _payStMoneyKindCd6 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd7
        /// <summary>�x���ݒ����R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd7
        {
            get { return _payStMoneyKindCd7; }
            set { _payStMoneyKindCd7 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd8
        /// <summary>�x���ݒ����R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd8
        {
            get { return _payStMoneyKindCd8; }
            set { _payStMoneyKindCd8 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd9
        /// <summary>�x���ݒ����R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd9
        {
            get { return _payStMoneyKindCd9; }
            set { _payStMoneyKindCd9 = value; }
        }

        /// public propaty name  :  PayStMoneyKindCd10
        /// <summary>�x���ݒ����R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ����R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayStMoneyKindCd10
        {
            get { return _payStMoneyKindCd10; }
            set { _payStMoneyKindCd10 = value; }
        }


        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// public propaty name  :  PaySlipCallMonths
        /// <summary>�x���`�[�ďo�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�ďo�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public Int32 PaySlipCallMonths
        //{
            //get { return _paySlipCallMonths; }
            //set { _paySlipCallMonths = value; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
        ///// public propaty name  :  InitSelMoneyKindNm
        ///// <summary>�����I�����햼��</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �����I�����햼�̃v���p�e�B</br>
        ///// <br>Programer        :   23006  ���� ���q</br>
        ///// </remarks>
        //public string InitSelMoneyKindNm
        //{
        //    get { return _initSelMoneyKindNm; }
        //    set { _initSelMoneyKindNm = value; }
        //}

        /// public propaty name  :  PayStMoneyKindNm1
        /// <summary>�x���ݒ���햼��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��1�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm1
        {
            get { return _payStMoneyKindNm1; }
            set { _payStMoneyKindNm1 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm2
        /// <summary>�x���ݒ���햼��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��2�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm2
        {
            get { return _payStMoneyKindNm2; }
            set { _payStMoneyKindNm2 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm3
        /// <summary>�x���ݒ���햼��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��3�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm3
        {
            get { return _payStMoneyKindNm3; }
            set { _payStMoneyKindNm3 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm4
        /// <summary>�x���ݒ���햼��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��4�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm4
        {
            get { return _payStMoneyKindNm4; }
            set { _payStMoneyKindNm4 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm5
        /// <summary>�x���ݒ���햼��5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��5�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm5
        {
            get { return _payStMoneyKindNm5; }
            set { _payStMoneyKindNm5 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm6
        /// <summary>�x���ݒ���햼��6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��6�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm6
        {
            get { return _payStMoneyKindNm6; }
            set { _payStMoneyKindNm6 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm7
        /// <summary>�x���ݒ���햼��7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��7�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm7
        {
            get { return _payStMoneyKindNm7; }
            set { _payStMoneyKindNm7 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm8
        /// <summary>�x���ݒ���햼��8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��8�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm8
        {
            get { return _payStMoneyKindNm8; }
            set { _payStMoneyKindNm8 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm9
        /// <summary>�x���ݒ���햼��9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��9�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm9
        {
            get { return _payStMoneyKindNm9; }
            set { _payStMoneyKindNm9 = value; }
        }

        /// public propaty name  :  PayStMoneyKindNm10
        /// <summary>�x���ݒ���햼��10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���ݒ���햼��10�v���p�e�B</br>
        /// <br>Programer        :   23006  ���� ���q</br>
        /// </remarks>
        public string PayStMoneyKindNm10
        {
            get { return _payStMoneyKindNm10; }
            set { _payStMoneyKindNm10 = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentSet()
        {
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="payStMngNo">�x���ݒ�Ǘ�No(0�Œ�)</param>
        /// <param name="initSelMoneyKindCd">�����I������R�[�h</param>
        /// <param name="payStMoneyKindCd1">�x���ݒ����R�[�h1</param>
        /// <param name="payStMoneyKindCd2">�x���ݒ����R�[�h2</param>
        /// <param name="payStMoneyKindCd3">�x���ݒ����R�[�h3</param>
        /// <param name="payStMoneyKindCd4">�x���ݒ����R�[�h4</param>
        /// <param name="payStMoneyKindCd5">�x���ݒ����R�[�h5</param>
        /// <param name="payStMoneyKindCd6">�x���ݒ����R�[�h6</param>
        /// <param name="payStMoneyKindCd7">�x���ݒ����R�[�h7</param>
        /// <param name="payStMoneyKindCd8">�x���ݒ����R�[�h8</param>
        /// <param name="payStMoneyKindCd9">�x���ݒ����R�[�h9</param>
        /// <param name="payStMoneyKindCd10">�x���ݒ����R�[�h10</param>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <param name="paySlipCallMonths">�x���`�[�ďo����</param>
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="payStMoneyKindNm1">�x���ݒ���햼��1</param>
        /// <param name="payStMoneyKindNm2">�x���ݒ���햼��2</param>
        /// <param name="payStMoneyKindNm3">�x���ݒ���햼��3</param>
        /// <param name="payStMoneyKindNm4">�x���ݒ���햼��4</param>
        /// <param name="payStMoneyKindNm5">�x���ݒ���햼��5</param>
        /// <param name="payStMoneyKindNm6">�x���ݒ���햼��6</param>
        /// <param name="payStMoneyKindNm7">�x���ݒ���햼��7</param>
        /// <param name="payStMoneyKindNm8">�x���ݒ���햼��8</param>
        /// <param name="payStMoneyKindNm9">�x���ݒ���햼��9</param>
        /// <param name="payStMoneyKindNm10">�x���ݒ���햼��10</param>
        /// <param name="initSelMoneyKindNm">�����I�����햼��(1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����)</param>
        /// <returns>PaymentSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
        //public PaymentSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 payStMngNo, Int32 initSelMoneyKindCd, Int32 payStMoneyKindCd1, Int32 payStMoneyKindCd2, Int32 payStMoneyKindCd3, Int32 payStMoneyKindCd4, Int32 payStMoneyKindCd5, Int32 payStMoneyKindCd6, Int32 payStMoneyKindCd7, Int32 payStMoneyKindCd8, Int32 payStMoneyKindCd9, Int32 payStMoneyKindCd10, Int32 paySlipCallMonths, string payStMoneyKindNm1, string payStMoneyKindNm2, string payStMoneyKindNm3, string payStMoneyKindNm4, string payStMoneyKindNm5, string payStMoneyKindNm6, string payStMoneyKindNm7, string payStMoneyKindNm8, string payStMoneyKindNm9, string payStMoneyKindNm10, string updEmployeeName, string enterpriseName, string initSelMoneyKindNm)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        public PaymentSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 payStMngNo, Int32 payStMoneyKindCd1, Int32 payStMoneyKindCd2, Int32 payStMoneyKindCd3, Int32 payStMoneyKindCd4, Int32 payStMoneyKindCd5, Int32 payStMoneyKindCd6, Int32 payStMoneyKindCd7, Int32 payStMoneyKindCd8, Int32 payStMoneyKindCd9, Int32 payStMoneyKindCd10, string payStMoneyKindNm1, string payStMoneyKindNm2, string payStMoneyKindNm3, string payStMoneyKindNm4, string payStMoneyKindNm5, string payStMoneyKindNm6, string payStMoneyKindNm7, string payStMoneyKindNm8, string payStMoneyKindNm9, string payStMoneyKindNm10, string updEmployeeName, string enterpriseName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._payStMngNo = payStMngNo;
            //this._initSelMoneyKindCd = initSelMoneyKindCd;
            this._payStMoneyKindCd1 = payStMoneyKindCd1;
            this._payStMoneyKindCd2 = payStMoneyKindCd2;
            this._payStMoneyKindCd3 = payStMoneyKindCd3;
            this._payStMoneyKindCd4 = payStMoneyKindCd4;
            this._payStMoneyKindCd5 = payStMoneyKindCd5;
            this._payStMoneyKindCd6 = payStMoneyKindCd6;
            this._payStMoneyKindCd7 = payStMoneyKindCd7;
            this._payStMoneyKindCd8 = payStMoneyKindCd8;
            this._payStMoneyKindCd9 = payStMoneyKindCd9;
            this._payStMoneyKindCd10 = payStMoneyKindCd10;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //this._paySlipCallMonths = paySlipCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

            this._updEmployeeName = updEmployeeName;
            this._enterpriseName = enterpriseName;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
            //this._initSelMoneyKindNm = initSelMoneyKindNm;
            this._payStMoneyKindNm1 = payStMoneyKindNm1;
            this._payStMoneyKindNm2 = payStMoneyKindNm2;
            this._payStMoneyKindNm3 = payStMoneyKindNm3;
            this._payStMoneyKindNm4 = payStMoneyKindNm4;
            this._payStMoneyKindNm5 = payStMoneyKindNm5;
            this._payStMoneyKindNm6 = payStMoneyKindNm6;
            this._payStMoneyKindNm7 = payStMoneyKindNm7;
            this._payStMoneyKindNm8 = payStMoneyKindNm8;
            this._payStMoneyKindNm9 = payStMoneyKindNm9;
            this._payStMoneyKindNm10 = payStMoneyKindNm10;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^��������
        /// </summary>
        /// <returns>PaymentSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PaymentSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentSet Clone()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
            return new PaymentSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._payStMngNo, this._payStMoneyKindCd1, this._payStMoneyKindCd2, this._payStMoneyKindCd3, this._payStMoneyKindCd4, this._payStMoneyKindCd5, this._payStMoneyKindCd6, this._payStMoneyKindCd7, this._payStMoneyKindCd8, this._payStMoneyKindCd9, this._payStMoneyKindCd10, this._payStMoneyKindNm1, this._payStMoneyKindNm2, this._payStMoneyKindNm3, this._payStMoneyKindNm4, this._payStMoneyKindNm5, this._payStMoneyKindNm6, this._payStMoneyKindNm7, this._payStMoneyKindNm8, this._payStMoneyKindNm9, this._payStMoneyKindNm10, this._updEmployeeName, this._enterpriseName);
            //return new PaymentSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._payStMngNo, this._initSelMoneyKindCd, this._payStMoneyKindCd1, this._payStMoneyKindCd2, this._payStMoneyKindCd3, this._payStMoneyKindCd4, this._payStMoneyKindCd5, this._payStMoneyKindCd6, this._payStMoneyKindCd7, this._payStMoneyKindCd8, this._payStMoneyKindCd9, this._payStMoneyKindCd10, this._paySlipCallMonths, this._payStMoneyKindNm1, this._payStMoneyKindNm2, this._payStMoneyKindNm3, this._payStMoneyKindNm4, this._payStMoneyKindNm5, this._payStMoneyKindNm6, this._payStMoneyKindNm7, this._payStMoneyKindNm8, this._payStMoneyKindNm9, this._payStMoneyKindNm10, this._updEmployeeName, this._enterpriseName, this._initSelMoneyKindNm);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PaymentSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PaymentSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PayStMngNo == target.PayStMngNo)
                 //&& (this.InitSelMoneyKindCd == target.InitSelMoneyKindCd)
                 && (this.PayStMoneyKindCd1 == target.PayStMoneyKindCd1)
                 && (this.PayStMoneyKindCd2 == target.PayStMoneyKindCd2)
                 && (this.PayStMoneyKindCd3 == target.PayStMoneyKindCd3)
                 && (this.PayStMoneyKindCd4 == target.PayStMoneyKindCd4)
                 && (this.PayStMoneyKindCd5 == target.PayStMoneyKindCd5)
                 && (this.PayStMoneyKindCd6 == target.PayStMoneyKindCd6)
                 && (this.PayStMoneyKindCd7 == target.PayStMoneyKindCd7)
                 && (this.PayStMoneyKindCd8 == target.PayStMoneyKindCd8)
                 && (this.PayStMoneyKindCd9 == target.PayStMoneyKindCd9)
                 && (this.PayStMoneyKindCd10 == target.PayStMoneyKindCd10)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                // && (this.PaySlipCallMonths == target.PaySlipCallMonths)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.EnterpriseName == target.EnterpriseName)

                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
                 //&& (this.InitSelMoneyKindNm == target.InitSelMoneyKindNm)
                 && (this.PayStMoneyKindNm1 == target.PayStMoneyKindNm1)
                 && (this.PayStMoneyKindNm2 == target.PayStMoneyKindNm2)
                 && (this.PayStMoneyKindNm3 == target.PayStMoneyKindNm3)
                 && (this.PayStMoneyKindNm4 == target.PayStMoneyKindNm4)
                 && (this.PayStMoneyKindNm5 == target.PayStMoneyKindNm5)
                 && (this.PayStMoneyKindNm6 == target.PayStMoneyKindNm6)
                 && (this.PayStMoneyKindNm7 == target.PayStMoneyKindNm7)
                 && (this.PayStMoneyKindNm8 == target.PayStMoneyKindNm8)
                 && (this.PayStMoneyKindNm9 == target.PayStMoneyKindNm9)
                 && (this.PayStMoneyKindNm10 == target.PayStMoneyKindNm10));
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="paymentSet1">
        ///                    ��r����PaymentSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="paymentSet2">��r����PaymentSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PaymentSet paymentSet1, PaymentSet paymentSet2)
        {
            return ((paymentSet1.CreateDateTime == paymentSet2.CreateDateTime)
                 && (paymentSet1.UpdateDateTime == paymentSet2.UpdateDateTime)
                 && (paymentSet1.EnterpriseCode == paymentSet2.EnterpriseCode)
                 && (paymentSet1.FileHeaderGuid == paymentSet2.FileHeaderGuid)
                 && (paymentSet1.UpdEmployeeCode == paymentSet2.UpdEmployeeCode)
                 && (paymentSet1.UpdAssemblyId1 == paymentSet2.UpdAssemblyId1)
                 && (paymentSet1.UpdAssemblyId2 == paymentSet2.UpdAssemblyId2)
                 && (paymentSet1.LogicalDeleteCode == paymentSet2.LogicalDeleteCode)
                 && (paymentSet1.PayStMngNo == paymentSet2.PayStMngNo)

                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                 //&& (paymentSet1.PaySlipCallMonths == paymentSet2.PaySlipCallMonths)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

                 && (paymentSet1.EnterpriseName == paymentSet2.EnterpriseName)
                 && (paymentSet1.UpdEmployeeName == paymentSet2.UpdEmployeeName)

                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
                 //&& (paymentSet1.InitSelMoneyKindCd == paymentSet2.InitSelMoneyKindCd)
                 && (paymentSet1.PayStMoneyKindCd1 == paymentSet2.PayStMoneyKindCd1)
                 && (paymentSet1.PayStMoneyKindCd2 == paymentSet2.PayStMoneyKindCd2)
                 && (paymentSet1.PayStMoneyKindCd3 == paymentSet2.PayStMoneyKindCd3)
                 && (paymentSet1.PayStMoneyKindCd4 == paymentSet2.PayStMoneyKindCd4)
                 && (paymentSet1.PayStMoneyKindCd5 == paymentSet2.PayStMoneyKindCd5)
                 && (paymentSet1.PayStMoneyKindCd6 == paymentSet2.PayStMoneyKindCd6)
                 && (paymentSet1.PayStMoneyKindCd7 == paymentSet2.PayStMoneyKindCd7)
                 && (paymentSet1.PayStMoneyKindCd8 == paymentSet2.PayStMoneyKindCd8)
                 && (paymentSet1.PayStMoneyKindCd9 == paymentSet2.PayStMoneyKindCd9)
                 && (paymentSet1.PayStMoneyKindCd10 == paymentSet2.PayStMoneyKindCd10));
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PaymentSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PaymentSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.PayStMngNo != target.PayStMngNo) resList.Add("PayStMngNo");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (this.PaySlipCallMonths != target.PaySlipCallMonths) resList.Add("PaySlipCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
            //if (this.InitSelMoneyKindCd != target.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            if (this.PayStMoneyKindCd1 != target.PayStMoneyKindCd1) resList.Add("PayStMoneyKindCd1");
            if (this.PayStMoneyKindCd2 != target.PayStMoneyKindCd2) resList.Add("PayStMoneyKindCd2");
            if (this.PayStMoneyKindCd3 != target.PayStMoneyKindCd3) resList.Add("PayStMoneyKindCd3");
            if (this.PayStMoneyKindCd4 != target.PayStMoneyKindCd4) resList.Add("PayStMoneyKindCd4");
            if (this.PayStMoneyKindCd5 != target.PayStMoneyKindCd5) resList.Add("PayStMoneyKindCd5");
            if (this.PayStMoneyKindCd6 != target.PayStMoneyKindCd6) resList.Add("PayStMoneyKindCd6");
            if (this.PayStMoneyKindCd7 != target.PayStMoneyKindCd7) resList.Add("PayStMoneyKindCd7");
            if (this.PayStMoneyKindCd8 != target.PayStMoneyKindCd8) resList.Add("PayStMoneyKindCd8");
            if (this.PayStMoneyKindCd9 != target.PayStMoneyKindCd9) resList.Add("PayStMoneyKindCd9");
            if (this.PayStMoneyKindCd10 != target.PayStMoneyKindCd10) resList.Add("PayStMoneyKindCd10");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

            return resList;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �x���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="paymentSet1">��r����PaymentSet�N���X�̃C���X�^���X</param>
        /// <param name="paymentSet2">��r����PaymentSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PaymentSet paymentSet1, PaymentSet paymentSet2)
        {
            ArrayList resList = new ArrayList();
            if (paymentSet1.CreateDateTime != paymentSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (paymentSet1.UpdateDateTime != paymentSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (paymentSet1.EnterpriseCode != paymentSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (paymentSet1.FileHeaderGuid != paymentSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (paymentSet1.UpdEmployeeCode != paymentSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (paymentSet1.UpdAssemblyId1 != paymentSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (paymentSet1.UpdAssemblyId2 != paymentSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (paymentSet1.LogicalDeleteCode != paymentSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (paymentSet1.PayStMngNo != paymentSet2.PayStMngNo) resList.Add("PayStMngNo");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (paymentSet1.PaySlipCallMonths != paymentSet2.PaySlipCallMonths) resList.Add("PaySlipCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

            if (paymentSet1.EnterpriseName != paymentSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (paymentSet1.UpdEmployeeName != paymentSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.01 TAKAHASHI ADD START
            //if (paymentSet1.InitSelMoneyKindCd != paymentSet2.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            if (paymentSet1.PayStMoneyKindCd1 != paymentSet2.PayStMoneyKindCd1) resList.Add("PayStMoneyKindCd1");
            if (paymentSet1.PayStMoneyKindCd2 != paymentSet2.PayStMoneyKindCd2) resList.Add("PayStMoneyKindCd2");
            if (paymentSet1.PayStMoneyKindCd3 != paymentSet2.PayStMoneyKindCd3) resList.Add("PayStMoneyKindCd3");
            if (paymentSet1.PayStMoneyKindCd4 != paymentSet2.PayStMoneyKindCd4) resList.Add("PayStMoneyKindCd4");
            if (paymentSet1.PayStMoneyKindCd5 != paymentSet2.PayStMoneyKindCd5) resList.Add("PayStMoneyKindCd5");
            if (paymentSet1.PayStMoneyKindCd6 != paymentSet2.PayStMoneyKindCd6) resList.Add("PayStMoneyKindCd6");
            if (paymentSet1.PayStMoneyKindCd7 != paymentSet2.PayStMoneyKindCd7) resList.Add("PayStMoneyKindCd7");
            if (paymentSet1.PayStMoneyKindCd8 != paymentSet2.PayStMoneyKindCd8) resList.Add("PayStMoneyKindCd8");
            if (paymentSet1.PayStMoneyKindCd9 != paymentSet2.PayStMoneyKindCd9) resList.Add("PayStMoneyKindCd9");
            if (paymentSet1.PayStMoneyKindCd10 != paymentSet2.PayStMoneyKindCd10) resList.Add("PayStMoneyKindCd10");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.01 TAKAHASHI ADD END

            return resList;
        }
    }
}
