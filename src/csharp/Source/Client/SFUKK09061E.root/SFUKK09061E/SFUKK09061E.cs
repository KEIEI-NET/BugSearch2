//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �����ݒ�
// �v���O�����T�v   : �����ݒ�}�X�^�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2006/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/22  �C�����e : �s��Ή�[13580]
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   DepositSt
    /// <summary>
    ///                      �����ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/07/13</br>
    /// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2009/06/22  �Ɠc �M�u�@�s��Ή�[13580]</br>
    /// </remarks>
    public class DepositSt
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
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�����ݒ�Ǘ��R�[�h</summary>
        /// <remarks>��ɂO�Œ�</remarks>
        private Int32 _depositStMngCd;

        /// <summary>���������\����ʔԍ�</summary>
        /// <remarks>1:�����^,2:�󒍎w��^</remarks>
        private Int32 _depositInitDspNo;

        ///// <summary>�����I������R�[�h</summary>
        ///// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        //private Int32 _initSelMoneyKindCd;

        ///// <summary>�����I������R�[�h</summary>
        //private string _initSelMoneyKindCdNm = "";

        /// <summary>�����ݒ����R�[�h1</summary>
        private Int32 _depositStKindCd1;

        /// <summary>�����ݒ����R�[�h2</summary>
        private Int32 _depositStKindCd2;

        /// <summary>�����ݒ����R�[�h3</summary>
        private Int32 _depositStKindCd3;

        /// <summary>�����ݒ����R�[�h4</summary>
        private Int32 _depositStKindCd4;

        /// <summary>�����ݒ����R�[�h5</summary>
        private Int32 _depositStKindCd5;

        /// <summary>�����ݒ����R�[�h6</summary>
        private Int32 _depositStKindCd6;

        /// <summary>�����ݒ����R�[�h7</summary>
        private Int32 _depositStKindCd7;

        /// <summary>�����ݒ����R�[�h8</summary>
        private Int32 _depositStKindCd8;

        /// <summary>�����ݒ����R�[�h9</summary>
        private Int32 _depositStKindCd9;

        /// <summary>�����ݒ����R�[�h10</summary>
        private Int32 _depositStKindCd10;

        /// <summary>�����ݒ����R�[�h1</summary>
        private string _depositStKindCdNm1 = "";

        /// <summary>�����ݒ����R�[�h2</summary>
        private string _depositStKindCdNm2 = "";

        /// <summary>�����ݒ����R�[�h3</summary>
        private string _depositStKindCdNm3 = "";

        /// <summary>�����ݒ����R�[�h4</summary>
        private string _depositStKindCdNm4 = "";

        /// <summary>�����ݒ����R�[�h5</summary>
        private string _depositStKindCdNm5 = "";

        /// <summary>�����ݒ����R�[�h6</summary>
        private string _depositStKindCdNm6 = "";

        /// <summary>�����ݒ����R�[�h7</summary>
        private string _depositStKindCdNm7 = "";

        /// <summary>�����ݒ����R�[�h8</summary>
        private string _depositStKindCdNm8 = "";

        /// <summary>�����ݒ����R�[�h9</summary>
        private string _depositStKindCdNm9 = "";

        /// <summary>�����ݒ����R�[�h10</summary>
        private string _depositStKindCdNm10 = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <summary>�����`�[�ďo����</summary>
        //private Int32 _depositCallMonths;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

        /// <summary>�����ϓ����`�[�ďo�敪</summary>
        /// <remarks>0:�����ς݂ł��Ăяo���A1:���z�����ς݂͌Ăяo���Ȃ�</remarks>
        private Int32 _alwcDepoCallMonthsCd;

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

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
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
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

        /// public propaty name  :  DepositStMngCd
        /// <summary>�����ݒ�Ǘ��R�[�h�v���p�e�B</summary>
        /// <value>��ɂO�Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStMngCd
        {
            get { return _depositStMngCd; }
            set { _depositStMngCd = value; }
        }

        /// public propaty name  :  DepositInitDspNo
        /// <summary>���������\����ʔԍ��v���p�e�B</summary>
        /// <value>1:�����^,2:�󒍎w��^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������\����ʔԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositInitDspNo
        {
            get { return _depositInitDspNo; }
            set { _depositInitDspNo = value; }
        }

        /// public propaty name  :  DepositInitDspNoName1
        /// <summary>���������\����ʔԍ����̃v���p�e�B</summary>
        /// <value>1:�����^,2:�󒍎w��^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������\����ʔԍ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String DepositInitDspNoName
        {
            get { return GetDepositInitDspNoName(_depositInitDspNo); }
        }
        /// <summary>���������\����ʋ敪 1:�����^</summary>
        public const int LUMP = 1;
        /// <summary>���������\����ʋ敪 2:�󒍎w��^</summary>
        public const int SLIP = 2;

        /// <summary>
        /// ���������\����ʔԍ����̎擾
        /// </summary>
        /// <param name="depositInitDspNo">���������\����ʋ敪</param>
        /// <returns>���������\����ʋ敪����</returns>
        /// <remarks>
        /// <br>Note       : ���������\����ʋ敪������������\����ʋ敪���̂��擾���܂�</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        public string GetDepositInitDspNoName(int depositInitDspNo)
        {
            switch (depositInitDspNo)
            {
                case LUMP:
                    return "�����^";
                case SLIP:
                    //return "�󒍎w��^";          //DEL 2009/06/22 �s��Ή�[13580]
                    return "����w��^";            //ADD 2009/06/22 �s��Ή�[13580]
                default:
                    return "���ݒ�";
            }
        }

        /// <summary>���������\����ʋ敪�̎��</summary>
        static private int[] _depositInitDspNos = { LUMP, SLIP };
        /// <summary>���������\����ʋ敪�̎�ރv���p�e�B</summary>
        /// <remarks>
        /// <br>Note       : ���������\����ʋ敪�̎�ރv���p�e�B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        static public int[] DepositInitDspNos
        {
            get
            {
                return _depositInitDspNos;
            }
        }

        ///// public propaty name  :  InitSelMoneyKindCd
        ///// <summary>�����I������R�[�h�v���p�e�B</summary>
        ///// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
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

        ///// public propaty name  :  InitSelMoneyKindCdNm
        ///// <summary>�����I�����햼�̃v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �����I�����햼�̃v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string InitSelMoneyKindCdNm
        //{
        //    get { return _initSelMoneyKindCdNm; }
        //    set { _initSelMoneyKindCdNm = value; }
        //}

        /// public propaty name  :  DepositStKindCd
        /// <summary>�����ݒ����R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd1
        {
            get { return _depositStKindCd1; }
            set { _depositStKindCd1 = value; }
        }

        /// public propaty name  :  DepositStKindCd2
        /// <summary>�����ݒ����R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd2
        {
            get { return _depositStKindCd2; }
            set { _depositStKindCd2 = value; }
        }

        /// public propaty name  :  DepositStKindCd3
        /// <summary>�����ݒ����R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd3
        {
            get { return _depositStKindCd3; }
            set { _depositStKindCd3 = value; }
        }

        /// public propaty name  :  DepositStKindCd4
        /// <summary>�����ݒ����R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd4
        {
            get { return _depositStKindCd4; }
            set { _depositStKindCd4 = value; }
        }

        /// public propaty name  :  DepositStKindCd5
        /// <summary>�����ݒ����R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd5
        {
            get { return _depositStKindCd5; }
            set { _depositStKindCd5 = value; }
        }

        /// public propaty name  :  DepositStKindCd6
        /// <summary>�����ݒ����R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd6
        {
            get { return _depositStKindCd6; }
            set { _depositStKindCd6 = value; }
        }

        /// public propaty name  :  DepositStKindCd7
        /// <summary>�����ݒ����R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd7
        {
            get { return _depositStKindCd7; }
            set { _depositStKindCd7 = value; }
        }

        /// public propaty name  :  DepositStKindCd8
        /// <summary>�����ݒ����R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd8
        {
            get { return _depositStKindCd8; }
            set { _depositStKindCd8 = value; }
        }

        /// public propaty name  :  DepositStKindCd9
        /// <summary>�����ݒ����R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd9
        {
            get { return _depositStKindCd9; }
            set { _depositStKindCd9 = value; }
        }

        /// public propaty name  :  DepositStKindCd10
        /// <summary>�����ݒ����R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ����R�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositStKindCd10
        {
            get { return _depositStKindCd10; }
            set { _depositStKindCd10 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm1
        /// <summary>�����ݒ���햼��1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm1
        {
            get { return _depositStKindCdNm1; }
            set { _depositStKindCdNm1 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm2
        /// <summary>�����ݒ���햼��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm2
        {
            get { return _depositStKindCdNm2; }
            set { _depositStKindCdNm2 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm3
        /// <summary>�����ݒ���햼��3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm3
        {
            get { return _depositStKindCdNm3; }
            set { _depositStKindCdNm3 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm4
        /// <summary>�����ݒ���햼��4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm4
        {
            get { return _depositStKindCdNm4; }
            set { _depositStKindCdNm4 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm5
        /// <summary>�����ݒ���햼��5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm5
        {
            get { return _depositStKindCdNm5; }
            set { _depositStKindCdNm5 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm6
        /// <summary>�����ݒ���햼��6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm6
        {
            get { return _depositStKindCdNm6; }
            set { _depositStKindCdNm6 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm7
        /// <summary>�����ݒ���햼��7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm7
        {
            get { return _depositStKindCdNm7; }
            set { _depositStKindCdNm7 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm8
        /// <summary>�����ݒ���햼��8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm8
        {
            get { return _depositStKindCdNm8; }
            set { _depositStKindCdNm8 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm9
        /// <summary>�����ݒ���햼��9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm9
        {
            get { return _depositStKindCdNm9; }
            set { _depositStKindCdNm9 = value; }
        }

        /// public propaty name  :  DepositStKindCdNm10
        /// <summary>�����ݒ���햼��10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݒ���햼��10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositStKindCdNm10
        {
            get { return _depositStKindCdNm10; }
            set { _depositStKindCdNm10 = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// public propaty name  :  DepositCallMonths
        /// <summary>�����`�[�ďo�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ďo�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public Int32 DepositCallMonths
        //{
            //get { return _depositCallMonths; }
            //set { _depositCallMonths = value; }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END


        /// public propaty name  :  AlwcDepoCallMonthsCd
        /// <summary>�����ϓ����`�[�ďo�敪�v���p�e�B</summary>
        /// <value>0:�����ς݂ł��Ăяo���A1:���z�����ς݂͌Ăяo���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ϓ����`�[�ďo�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AlwcDepoCallMonthsCd
        {
            get { return _alwcDepoCallMonthsCd; }
            set { _alwcDepoCallMonthsCd = value; }
        }

        /// public propaty name  :  AlwcDepoCallMonthsCdName
        /// <summary>�����ϓ����`�[�ďo���̃v���p�e�B</summary>
        /// <value>0:�����ς݂ł��Ăяo���A1:���z�����ς݂͌Ăяo���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������\����ʔԍ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String AlwcDepoCallMonthsCdName
        {
            get { return GetAlwcDepoCallMonthsCdName(_alwcDepoCallMonthsCd); }
        }
        /// <summary>���������\����ʋ敪 0:�����ς݂ł��Ăяo��</summary>
        public const int PULLREAD = 0;
        /// <summary>���������\����ʋ敪 1:���z�����ς݂͌Ăяo���Ȃ�</summary>
        public const int PULLNOREAD = 1;


        /// <summary>
        /// ���������\����ʔԍ����̎擾
        /// </summary>
        /// <param name="alwcDepoCallMonthsCd">���������\����ʋ敪</param>
        /// <returns>���������\����ʋ敪����</returns>
        /// <remarks>
        /// <br>Note       : ���������\����ʋ敪������������\����ʋ敪���̂��擾���܂�</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        public string GetAlwcDepoCallMonthsCdName(int alwcDepoCallMonthsCd)
        {
            switch (alwcDepoCallMonthsCd)
            {
                case PULLREAD:
                    return "�����ς݂ł��Ăяo��";
                case PULLNOREAD:
                    return "���z�����ς݂͌Ăяo���Ȃ�";
                default:
                    return "���ݒ�";
            }
        }

        /// <summary>���������\����ʋ敪�̎��</summary>
        static private int[] _alwcDepoCallMonthsCds = { PULLREAD, PULLNOREAD };
        /// <summary>���������\����ʋ敪�̎�ރv���p�e�B</summary>
        /// <remarks>
        /// <br>Note       : ���������\����ʋ敪�̎�ރv���p�e�B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2005.08.04</br>
        /// </remarks>
        static public int[] AlwcDepoCallMonthsCds
        {
            get
            {
                return _alwcDepoCallMonthsCds;
            }
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


        /// <summary>
        /// �����ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>DepositSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepositSt()
        {
        }

        /// <summary>
        /// �����ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="depositStMngCd">�����ݒ�Ǘ��R�[�h(��ɂO�Œ�)</param>
        /// <param name="depositInitDspNo">���������\����ʔԍ�(1:�ꊇ,2:�`�[,3:�ꗗ,4:���w��,5:�����ꗗ,6:�������`)</param>
        /// <param name="initSelMoneyKindCd">�����I������R�[�h(1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����)</param>
        /// <param name="initSelMoneyKindCdNm">�����I�����햼��(1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����)</param>
        /// <param name="depositStKindCd1">�����ݒ����R�[�h1</param>
        /// <param name="depositStKindCd2">�����ݒ����R�[�h2</param>
        /// <param name="depositStKindCd3">�����ݒ����R�[�h3</param>
        /// <param name="depositStKindCd4">�����ݒ����R�[�h4</param>
        /// <param name="depositStKindCd5">�����ݒ����R�[�h5</param>
        /// <param name="depositStKindCd6">�����ݒ����R�[�h6</param>
        /// <param name="depositStKindCd7">�����ݒ����R�[�h7</param>
        /// <param name="depositStKindCd8">�����ݒ����R�[�h8</param>
        /// <param name="depositStKindCd9">�����ݒ����R�[�h9</param>
        /// <param name="depositStKindCd10">�����ݒ����R�[�h10</param>
        /// <param name="depositStKindCdNm1">�����ݒ���햼��1</param>
        /// <param name="depositStKindCdNm2">�����ݒ���햼��2</param>
        /// <param name="depositStKindCdNm3">�����ݒ���햼��3</param>
        /// <param name="depositStKindCdNm4">�����ݒ���햼��4</param>
        /// <param name="depositStKindCdNm5">�����ݒ���햼��5</param>
        /// <param name="depositStKindCdNm6">�����ݒ���햼��6</param>
        /// <param name="depositStKindCdNm7">�����ݒ���햼��7</param>
        /// <param name="depositStKindCdNm8">�����ݒ���햼��8</param>
        /// <param name="depositStKindCdNm9">�����ݒ���햼��9</param>
        /// <param name="depositStKindCdNm10">�����ݒ���햼��10</param>
        /// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
        /// <param name="depositCallMonths">�����`�[�ďo����</param>
        /// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
        /// <param name="alwcDepoCallMonthsCd">�����ϓ����`�[�ďo�敪(0:�����ς݂ł��Ăяo���A1:���z�����ς݂͌Ăяo���Ȃ�)</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>DepositSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
        //public DepositSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 depositStMngCd, Int32 depositInitDspNo, Int32 initSelMoneyKindCd, string initSelMoneyKindCdNm, Int32 depositStKindCd1, Int32 depositStKindCd2, Int32 depositStKindCd3, Int32 depositStKindCd4, Int32 depositStKindCd5, Int32 depositStKindCd6, Int32 depositStKindCd7, Int32 depositStKindCd8, Int32 depositStKindCd9, Int32 depositStKindCd10, string depositStKindCdNm1, string depositStKindCdNm2, string depositStKindCdNm3, string depositStKindCdNm4, string depositStKindCdNm5, string depositStKindCdNm6, string depositStKindCdNm7, string depositStKindCdNm8, string depositStKindCdNm9, string depositStKindCdNm10, Int32 depositCallMonths, Int32 alwcDepoCallMonthsCd, string updEmployeeName, string enterpriseName)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        public DepositSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 depositStMngCd, Int32 depositInitDspNo, Int32 depositStKindCd1, Int32 depositStKindCd2, Int32 depositStKindCd3, Int32 depositStKindCd4, Int32 depositStKindCd5, Int32 depositStKindCd6, Int32 depositStKindCd7, Int32 depositStKindCd8, Int32 depositStKindCd9, Int32 depositStKindCd10, string depositStKindCdNm1, string depositStKindCdNm2, string depositStKindCdNm3, string depositStKindCdNm4, string depositStKindCdNm5, string depositStKindCdNm6, string depositStKindCdNm7, string depositStKindCdNm8, string depositStKindCdNm9, string depositStKindCdNm10, Int32 alwcDepoCallMonthsCd, string updEmployeeName, string enterpriseName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._depositStMngCd = depositStMngCd;
            this._depositInitDspNo = depositInitDspNo;
            //this._initSelMoneyKindCd = initSelMoneyKindCd;
            //this._initSelMoneyKindCdNm = initSelMoneyKindCdNm;
            this._depositStKindCd1 = depositStKindCd1;
            this._depositStKindCd2 = depositStKindCd2;
            this._depositStKindCd3 = depositStKindCd3;
            this._depositStKindCd4 = depositStKindCd4;
            this._depositStKindCd5 = depositStKindCd5;
            this._depositStKindCd6 = depositStKindCd6;
            this._depositStKindCd7 = depositStKindCd7;
            this._depositStKindCd8 = depositStKindCd8;
            this._depositStKindCd9 = depositStKindCd9;
            this._depositStKindCd10 = depositStKindCd10;
            this._depositStKindCdNm1 = depositStKindCdNm1;
            this._depositStKindCdNm2 = depositStKindCdNm2;
            this._depositStKindCdNm3 = depositStKindCdNm3;
            this._depositStKindCdNm4 = depositStKindCdNm4;
            this._depositStKindCdNm5 = depositStKindCdNm5;
            this._depositStKindCdNm6 = depositStKindCdNm6;
            this._depositStKindCdNm7 = depositStKindCdNm7;
            this._depositStKindCdNm8 = depositStKindCdNm8;
            this._depositStKindCdNm9 = depositStKindCdNm9;
            this._depositStKindCdNm10 = depositStKindCdNm10;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //this._depositCallMonths = depositCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            this._alwcDepoCallMonthsCd = alwcDepoCallMonthsCd;
            this._updEmployeeName = updEmployeeName;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// �����ݒ�N���X��������
        /// </summary>
        /// <returns>DepositSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����DepositSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepositSt Clone()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA MODIFY START
            return new DepositSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._depositStMngCd, this._depositInitDspNo, this._depositStKindCd1, this._depositStKindCd2, this._depositStKindCd3, this._depositStKindCd4, this._depositStKindCd5, this._depositStKindCd6, this._depositStKindCd7, this._depositStKindCd8, this._depositStKindCd9, this._depositStKindCd10, this._depositStKindCdNm1, this._depositStKindCdNm2, this._depositStKindCdNm3, this._depositStKindCdNm4, this._depositStKindCdNm5, this._depositStKindCdNm6, this._depositStKindCdNm7, this._depositStKindCdNm8, this._depositStKindCdNm9, this._depositStKindCdNm10, this._alwcDepoCallMonthsCd, this._updEmployeeName, this._enterpriseName);
            //return new DepositSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._depositStMngCd, this._depositInitDspNo, this._initSelMoneyKindCd, this._initSelMoneyKindCdNm, this._depositStKindCd1, this._depositStKindCd2, this._depositStKindCd3, this._depositStKindCd4, this._depositStKindCd5, this._depositStKindCd6, this._depositStKindCd7, this._depositStKindCd8, this._depositStKindCd9, this._depositStKindCd10, this._depositStKindCdNm1, this._depositStKindCdNm2, this._depositStKindCdNm3, this._depositStKindCdNm4, this._depositStKindCdNm5, this._depositStKindCdNm6, this._depositStKindCdNm7, this._depositStKindCdNm8, this._depositStKindCdNm9, this._depositStKindCdNm10, this._depositCallMonths, this._alwcDepoCallMonthsCd, this._updEmployeeName, this._enterpriseName);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA MODIFY END
        }

        /// <summary>
        /// �����ݒ�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�DepositSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(DepositSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                && (this.UpdateDateTime == target.UpdateDateTime)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.FileHeaderGuid == target.FileHeaderGuid)
                && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                && (this.DepositStMngCd == target.DepositStMngCd)
                && (this.DepositInitDspNo == target.DepositInitDspNo)
                //&& (this.InitSelMoneyKindCd == target.InitSelMoneyKindCd)
                //&& (this.InitSelMoneyKindCdNm == target.InitSelMoneyKindCdNm)
                && (this.DepositStKindCd1 == target.DepositStKindCd1)
                && (this.DepositStKindCd2 == target.DepositStKindCd2)
                && (this.DepositStKindCd3 == target.DepositStKindCd3)
                && (this.DepositStKindCd4 == target.DepositStKindCd4)
                && (this.DepositStKindCd5 == target.DepositStKindCd5)
                && (this.DepositStKindCd6 == target.DepositStKindCd6)
                && (this.DepositStKindCd7 == target.DepositStKindCd7)
                && (this.DepositStKindCd8 == target.DepositStKindCd8)
                && (this.DepositStKindCd9 == target.DepositStKindCd9)
                && (this.DepositStKindCd10 == target.DepositStKindCd10)
                && (this.DepositStKindCdNm1 == target.DepositStKindCdNm1)
                && (this.DepositStKindCdNm2 == target.DepositStKindCdNm2)
                && (this.DepositStKindCdNm3 == target.DepositStKindCdNm3)
                && (this.DepositStKindCdNm4 == target.DepositStKindCdNm4)
                && (this.DepositStKindCdNm5 == target.DepositStKindCdNm5)
                && (this.DepositStKindCdNm6 == target.DepositStKindCdNm6)
                && (this.DepositStKindCdNm7 == target.DepositStKindCdNm7)
                && (this.DepositStKindCdNm8 == target.DepositStKindCdNm8)
                && (this.DepositStKindCdNm9 == target.DepositStKindCdNm9)
                && (this.DepositStKindCdNm10 == target.DepositStKindCdNm10)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                //&& (this.DepositCallMonths == target.DepositCallMonths)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                && (this.AlwcDepoCallMonthsCd == target.AlwcDepoCallMonthsCd)
                && (this.UpdEmployeeName == target.UpdEmployeeName)
                && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �����ݒ�N���X��r����
        /// </summary>
        /// <param name="depositSt1">
        ///                    ��r����DepositSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="depositSt2">��r����DepositSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(DepositSt depositSt1, DepositSt depositSt2)
        {
            return ((depositSt1.CreateDateTime == depositSt2.CreateDateTime)
                && (depositSt1.UpdateDateTime == depositSt2.UpdateDateTime)
                && (depositSt1.EnterpriseCode == depositSt2.EnterpriseCode)
                && (depositSt1.FileHeaderGuid == depositSt2.FileHeaderGuid)
                && (depositSt1.UpdEmployeeCode == depositSt2.UpdEmployeeCode)
                && (depositSt1.UpdAssemblyId1 == depositSt2.UpdAssemblyId1)
                && (depositSt1.UpdAssemblyId2 == depositSt2.UpdAssemblyId2)
                && (depositSt1.LogicalDeleteCode == depositSt2.LogicalDeleteCode)
                && (depositSt1.DepositStMngCd == depositSt2.DepositStMngCd)
                && (depositSt1.DepositInitDspNo == depositSt2.DepositInitDspNo)
                //&& (depositSt1.InitSelMoneyKindCd == depositSt2.InitSelMoneyKindCd)
                //&& (depositSt1.InitSelMoneyKindCdNm == depositSt2.InitSelMoneyKindCdNm)
                && (depositSt1.DepositStKindCd1 == depositSt2.DepositStKindCd1)
                && (depositSt1.DepositStKindCd2 == depositSt2.DepositStKindCd2)
                && (depositSt1.DepositStKindCd3 == depositSt2.DepositStKindCd3)
                && (depositSt1.DepositStKindCd4 == depositSt2.DepositStKindCd4)
                && (depositSt1.DepositStKindCd5 == depositSt2.DepositStKindCd5)
                && (depositSt1.DepositStKindCd6 == depositSt2.DepositStKindCd6)
                && (depositSt1.DepositStKindCd7 == depositSt2.DepositStKindCd7)
                && (depositSt1.DepositStKindCd8 == depositSt2.DepositStKindCd8)
                && (depositSt1.DepositStKindCd9 == depositSt2.DepositStKindCd9)
                && (depositSt1.DepositStKindCd10 == depositSt2.DepositStKindCd10)
                && (depositSt1.DepositStKindCdNm1 == depositSt2.DepositStKindCdNm1)
                && (depositSt1.DepositStKindCdNm2 == depositSt2.DepositStKindCdNm2)
                && (depositSt1.DepositStKindCdNm3 == depositSt2.DepositStKindCdNm3)
                && (depositSt1.DepositStKindCdNm4 == depositSt2.DepositStKindCdNm4)
                && (depositSt1.DepositStKindCdNm5 == depositSt2.DepositStKindCdNm5)
                && (depositSt1.DepositStKindCdNm6 == depositSt2.DepositStKindCdNm6)
                && (depositSt1.DepositStKindCdNm7 == depositSt2.DepositStKindCdNm7)
                && (depositSt1.DepositStKindCdNm8 == depositSt2.DepositStKindCdNm8)
                && (depositSt1.DepositStKindCdNm9 == depositSt2.DepositStKindCdNm9)
                && (depositSt1.DepositStKindCdNm10 == depositSt2.DepositStKindCdNm10)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
                //&& (depositSt1.DepositCallMonths == depositSt2.DepositCallMonths)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
                && (depositSt1.AlwcDepoCallMonthsCd == depositSt2.AlwcDepoCallMonthsCd)
                && (depositSt1.UpdEmployeeName == depositSt2.UpdEmployeeName)
                && (depositSt1.EnterpriseName == depositSt2.EnterpriseName));
        }
        /// <summary>
        /// �����ݒ�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�DepositSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(DepositSt target)
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
            if (this.DepositStMngCd != target.DepositStMngCd) resList.Add("DepositStMngCd");
            if (this.DepositInitDspNo != target.DepositInitDspNo) resList.Add("DepositInitDspNo");
            //if (this.InitSelMoneyKindCd != target.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            //if (this.InitSelMoneyKindCdNm != target.InitSelMoneyKindCdNm) resList.Add("InitSelMoneyKindCdNm");
            if (this.DepositStKindCd1 != target.DepositStKindCd1) resList.Add("DepositStKindCd1");
            if (this.DepositStKindCd2 != target.DepositStKindCd2) resList.Add("DepositStKindCd2");
            if (this.DepositStKindCd3 != target.DepositStKindCd3) resList.Add("DepositStKindCd3");
            if (this.DepositStKindCd4 != target.DepositStKindCd4) resList.Add("DepositStKindCd4");
            if (this.DepositStKindCd5 != target.DepositStKindCd5) resList.Add("DepositStKindCd5");
            if (this.DepositStKindCd6 != target.DepositStKindCd6) resList.Add("DepositStKindCd6");
            if (this.DepositStKindCd7 != target.DepositStKindCd7) resList.Add("DepositStKindCd7");
            if (this.DepositStKindCd8 != target.DepositStKindCd8) resList.Add("DepositStKindCd8");
            if (this.DepositStKindCd9 != target.DepositStKindCd9) resList.Add("DepositStKindCd9");
            if (this.DepositStKindCd10 != target.DepositStKindCd10) resList.Add("DepositStKindCd10");
            if (this.DepositStKindCdNm1 != target.DepositStKindCdNm1) resList.Add("DepositStKindCdNm1");
            if (this.DepositStKindCdNm2 != target.DepositStKindCdNm2) resList.Add("DepositStKindCdNm2");
            if (this.DepositStKindCdNm3 != target.DepositStKindCdNm3) resList.Add("DepositStKindCdNm3");
            if (this.DepositStKindCdNm4 != target.DepositStKindCdNm4) resList.Add("DepositStKindCdNm4");
            if (this.DepositStKindCdNm5 != target.DepositStKindCdNm5) resList.Add("DepositStKindCdNm5");
            if (this.DepositStKindCdNm6 != target.DepositStKindCdNm6) resList.Add("DepositStKindCdNm6");
            if (this.DepositStKindCdNm7 != target.DepositStKindCdNm7) resList.Add("DepositStKindCdNm7");
            if (this.DepositStKindCdNm8 != target.DepositStKindCdNm8) resList.Add("DepositStKindCdNm8");
            if (this.DepositStKindCdNm9 != target.DepositStKindCdNm9) resList.Add("DepositStKindCdNm9");
            if (this.DepositStKindCdNm10 != target.DepositStKindCdNm10) resList.Add("DepositStKindCdNm10");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (this.DepositCallMonths != target.DepositCallMonths) resList.Add("DepositCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            if (this.AlwcDepoCallMonthsCd != target.AlwcDepoCallMonthsCd) resList.Add("AlwcDepoCallMonthsCd");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// �����ݒ�N���X��r����
        /// </summary>
        /// <param name="depositSt1">��r����DepositSt�N���X�̃C���X�^���X</param>
        /// <param name="depositSt2">��r����DepositSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(DepositSt depositSt1, DepositSt depositSt2)
        {
            ArrayList resList = new ArrayList();
            if (depositSt1.CreateDateTime != depositSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (depositSt1.UpdateDateTime != depositSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (depositSt1.EnterpriseCode != depositSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (depositSt1.FileHeaderGuid != depositSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (depositSt1.UpdEmployeeCode != depositSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (depositSt1.UpdAssemblyId1 != depositSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (depositSt1.UpdAssemblyId2 != depositSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (depositSt1.LogicalDeleteCode != depositSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (depositSt1.DepositStMngCd != depositSt2.DepositStMngCd) resList.Add("DepositStMngCd");
            if (depositSt1.DepositInitDspNo != depositSt2.DepositInitDspNo) resList.Add("DepositInitDspNo");
            //if (depositSt1.InitSelMoneyKindCd != depositSt2.InitSelMoneyKindCd) resList.Add("InitSelMoneyKindCd");
            //if (depositSt1.InitSelMoneyKindCdNm != depositSt2.InitSelMoneyKindCdNm) resList.Add("InitSelMoneyKindCdNm");
            if (depositSt1.DepositStKindCd1 != depositSt2.DepositStKindCd1) resList.Add("DepositStKindCd1");
            if (depositSt1.DepositStKindCd2 != depositSt2.DepositStKindCd2) resList.Add("DepositStKindCd2");
            if (depositSt1.DepositStKindCd3 != depositSt2.DepositStKindCd3) resList.Add("DepositStKindCd3");
            if (depositSt1.DepositStKindCd4 != depositSt2.DepositStKindCd4) resList.Add("DepositStKindCd4");
            if (depositSt1.DepositStKindCd5 != depositSt2.DepositStKindCd5) resList.Add("DepositStKindCd5");
            if (depositSt1.DepositStKindCd6 != depositSt2.DepositStKindCd6) resList.Add("DepositStKindCd6");
            if (depositSt1.DepositStKindCd7 != depositSt2.DepositStKindCd7) resList.Add("DepositStKindCd7");
            if (depositSt1.DepositStKindCd8 != depositSt2.DepositStKindCd8) resList.Add("DepositStKindCd8");
            if (depositSt1.DepositStKindCd9 != depositSt2.DepositStKindCd9) resList.Add("DepositStKindCd9");
            if (depositSt1.DepositStKindCd10 != depositSt2.DepositStKindCd10) resList.Add("DepositStKindCd10");
            if (depositSt1.DepositStKindCdNm1 != depositSt2.DepositStKindCdNm1) resList.Add("DepositStKindCdNm1");
            if (depositSt1.DepositStKindCdNm2 != depositSt2.DepositStKindCdNm2) resList.Add("DepositStKindCdNm2");
            if (depositSt1.DepositStKindCdNm3 != depositSt2.DepositStKindCdNm3) resList.Add("DepositStKindCdNm3");
            if (depositSt1.DepositStKindCdNm4 != depositSt2.DepositStKindCdNm4) resList.Add("DepositStKindCdNm4");
            if (depositSt1.DepositStKindCdNm5 != depositSt2.DepositStKindCdNm5) resList.Add("DepositStKindCdNm5");
            if (depositSt1.DepositStKindCdNm6 != depositSt2.DepositStKindCdNm6) resList.Add("DepositStKindCdNm6");
            if (depositSt1.DepositStKindCdNm7 != depositSt2.DepositStKindCdNm7) resList.Add("DepositStKindCdNm7");
            if (depositSt1.DepositStKindCdNm8 != depositSt2.DepositStKindCdNm8) resList.Add("DepositStKindCdNm8");
            if (depositSt1.DepositStKindCdNm9 != depositSt2.DepositStKindCdNm9) resList.Add("DepositStKindCdNm9");
            if (depositSt1.DepositStKindCdNm10 != depositSt2.DepositStKindCdNm10) resList.Add("DepositStKindCdNm10");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //if (depositSt1.DepositCallMonths != depositSt2.DepositCallMonths) resList.Add("DepositCallMonths");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
            if (depositSt1.AlwcDepoCallMonthsCd != depositSt2.AlwcDepoCallMonthsCd) resList.Add("AlwcDepoCallMonthsCd");
            if (depositSt1.UpdEmployeeName != depositSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (depositSt1.EnterpriseName != depositSt2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
