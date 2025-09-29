using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AllDefSet
    /// <summary>
    ///                      �S�̏����l�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �S�̏����l�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/04 30414  �E�@�K�j</br>
    /// <br>                     �u�ڋq�R�[�h�������ԁv�u���Ӑ�폜�`�F�b�N�v�u������Ǘ��v�폜</br>
    /// <br>Update Note      :   2010/01/18 30531  ��� �r��</br>
    /// <br>                     �������^�C�v���̏o�͋敪���ڒǉ��i�R���ځj</br>
    /// <br>Update Note      : 2011/07/19 zhouyu</br>
    /// <br>                �E�A�� 1028</br>
    /// <br>                  �C�����e�F�A�� 1028 �݌Ɏd�����͂ŁA�i�ԓ��͌�Ɏ����� �d����=�P �ƕ\������A���݌ɐ���������ĕ\���ɂȂ蕪���肸�炢</br>
    /// <br>                  PM7�ł́A�d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������</br>
    /// <br>                  ����`�[���́C�d���`�[���� ������</br>
    /// <br>Update Note      :   2013/05/02 ���N</br>
    /// <br>�Ǘ��ԍ��@       :   10901273-00 2013/06/18�z�M���@
    /// �@�@�@�@�@�@�@�@�@   :   Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
    /// </remarks>
    public class AllDefSet
    {
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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���z�\�����@�敪</summary>
        /// <remarks>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</remarks>
        private Int32 _totalAmountDispWayCd;

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>���Ӑ�폜�`�F�b�N�敪</summary>
        /// <remarks>0:�������`�[�����݂���ꍇ�͍폜�s�Ƃ���,1:�������`�[�����݂���ꍇ�ł��폜�\�Ƃ���</remarks>
        private Int32 _customerDelChkDivCd;

        /// <summary>�ڋq�R�[�h�������ԋ敪</summary>
        /// <remarks>0:����͉�,1:����͕s��</remarks>
        private Int32 _custCdAutoNumbering;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�����\���ڋq����</summary>
        /// <remarks>0�`31</remarks>
        private Int32 _defDspCustTtlDay;

        /// <summary>�����\���ڋq�W����</summary>
        /// <remarks>0�`31</remarks>
        private Int32 _defDspCustClctMnyDay;

        /// <summary>�����\���W�����敪</summary>
        /// <remarks>0:����,1:����,2:���X��</remarks>
        private Int32 _defDspClctMnyMonthCd;

        /// <summary>�����\���l�E�@�l�敪</summary>
        /// <remarks>0:�l,1:�@�l</remarks>
        private Int32 _iniDspPrslOrCorpCd;

        /// <summary>�����\��DM�敪</summary>
        /// <remarks>0:�c�l�o�͂���,1:�c�l�o�͂��Ȃ�</remarks>
        private Int32 _initDspDmDiv;

        /// <summary>�����\���������o�͋敪</summary>
        /// <remarks>0:�������o�͂���,1:�������o�͂��Ȃ�</remarks>
        private Int32 _defDspBillPrtDivCd;

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>������Ǘ��敪</summary>
        /// <remarks>0:������Ǘ�����A1:������Ǘ����Ȃ�</remarks>
        private Int32 _memberInfoDispCd;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�����\���敪�P</summary>
        /// <remarks>0:����@1:�a��i�ʏ�j�@�@</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>�����\���敪�Q</summary>
        /// <remarks>0:����@1:�a��i�N���j</remarks>
        private Int32 _eraNameDispCd2;

        /// <summary>�����\���敪�R</summary>
        /// <remarks>0:����@1:�a��i���̑��j</remarks>
        private Int32 _eraNameDispCd3;

        /// <summary>�����Ǘ��敪</summary>
        /// <remarks>0:���_�@1:���_�{���@2:���_�{���{��</remarks>
        private Int32 _secMngDiv;

        /// <summary>���i�ԍ����͋敪</summary>
        /// <remarks>0:�C�Ӂ@1:�K�{</remarks>
        private Int32 _goodsNoInpDiv;



        /// <summary>����Ŏ����␳�敪</summary>
        /// <remarks>0:�����@1:�蓮</remarks>
        private Int32 _cnsTaxAutoCorrDiv;

        /// <summary>�c���Ǘ��敪</summary>
        /// <remarks>0:���� 1:���Ȃ� ���`�[�폜���Ɏc�ɖ߂����ǂ���</remarks>
        private Int32 _remainCntMngDiv;

        /// <summary>�������ʋ敪</summary>
        /// <remarks>0:����@1:�ЊO�����̂݁@2:���Ȃ�</remarks>
        private Int32 _memoMoveDiv;

        /// <summary>�c�������\���敪</summary>
        /// <remarks>0:���Ȃ�,1:�o�׎c,���׎c�̂݁C2:�󔭒��c�̂݁C3:�o�׎c,���׎c ->�󔭒��c 4:�󔭒��c -> �o�׎c,���׎c</remarks>
        private Int32 _remCntAutoDspDiv;

        /// <summary>���z�\���|���K�p�敪</summary>
        /// <remarks>0�F�ō��P��, 1:�Ŕ��P��</remarks>
        private Int32 _ttlAmntDspRateDivCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        // --- ADD  ���r��  2010/01/18 ---------->>>>>
        /// <summary>�����\�����v�������o�͋敪</summary>
        /// <remarks>0:�o�͂���@1:�o�͂��Ȃ�</remarks>
        private Int32 _defTtlBillOutput;

        /// <summary>�����\�����א������o�͋敪</summary>
        /// <remarks>0:�o�͂���@1:�o�͂��Ȃ�</remarks>
        private Int32 _defDtlBillOutput;

        /// <summary>�����\���`�[���v�������o�͋敪</summary>
        /// <remarks>0:�o�͂���@1:�o�͂��Ȃ�</remarks>
        private Int32 _defSlTtlBillOutput;
        // --- ADD  ���r��  2010/01/18 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>�d���E�o�׌㐔�\���敪</summary>
        /// <remarks>0:�i�Ԋm���X�V�@1:���׊m���X�V</remarks>
        private Int32 _dtlCalcStckCntDsp;
        //ADD 2011/07/19

        // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>���i�݌Ƀ}�X�^�\���敪</summary>
        /// <remarks>0:���i�݌Ƀ}�X�^�T�@1:���i�݌Ƀ}�X�^�U</remarks>
        private Int32 _goodsStockMSTBootDiv;
        // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>���z�\�����@�敪�v���p�e�B</summary>
        /// <value>0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  CustomerDelChkDivCd
        /// <summary>���Ӑ�폜�`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:�������`�[�����݂���ꍇ�͍폜�s�Ƃ���,1:�������`�[�����݂���ꍇ�ł��폜�\�Ƃ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�폜�`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerDelChkDivCd
        {
            get { return _customerDelChkDivCd; }
            set { _customerDelChkDivCd = value; }
        }

        /// public propaty name  :  CustCdAutoNumbering
        /// <summary>�ڋq�R�[�h�������ԋ敪�v���p�e�B</summary>
        /// <value>0:����͉�,1:����͕s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�R�[�h�������ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustCdAutoNumbering
        {
            get { return _custCdAutoNumbering; }
            set { _custCdAutoNumbering = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DefDspCustTtlDay
        /// <summary>�����\���ڋq�����v���p�e�B</summary>
        /// <value>0�`31</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���ڋq�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefDspCustTtlDay
        {
            get { return _defDspCustTtlDay; }
            set { _defDspCustTtlDay = value; }
        }

        /// public propaty name  :  DefDspCustClctMnyDay
        /// <summary>�����\���ڋq�W�����v���p�e�B</summary>
        /// <value>0�`31</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���ڋq�W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefDspCustClctMnyDay
        {
            get { return _defDspCustClctMnyDay; }
            set { _defDspCustClctMnyDay = value; }
        }

        /// public propaty name  :  DefDspClctMnyMonthCd
        /// <summary>�����\���W�����敪�v���p�e�B</summary>
        /// <value>0:����,1:����,2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���W�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefDspClctMnyMonthCd
        {
            get { return _defDspClctMnyMonthCd; }
            set { _defDspClctMnyMonthCd = value; }
        }

        /// public propaty name  :  IniDspPrslOrCorpCd
        /// <summary>�����\���l�E�@�l�敪�v���p�e�B</summary>
        /// <value>0:�l,1:�@�l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���l�E�@�l�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 IniDspPrslOrCorpCd
        {
            get { return _iniDspPrslOrCorpCd; }
            set { _iniDspPrslOrCorpCd = value; }
        }

        /// public propaty name  :  InitDspDmDiv
        /// <summary>�����\��DM�敪�v���p�e�B</summary>
        /// <value>0:�c�l�o�͂���,1:�c�l�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��DM�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InitDspDmDiv
        {
            get { return _initDspDmDiv; }
            set { _initDspDmDiv = value; }
        }

        /// public propaty name  :  DefDspBillPrtDivCd
        /// <summary>�����\���������o�͋敪�v���p�e�B</summary>
        /// <value>0:�������o�͂���,1:�������o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefDspBillPrtDivCd
        {
            get { return _defDspBillPrtDivCd; }
            set { _defDspBillPrtDivCd = value; }
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  MemberInfoDispCd
        /// <summary>������Ǘ��敪�v���p�e�B</summary>
        /// <value>0:������Ǘ�����A1:������Ǘ����Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MemberInfoDispCd
        {
            get { return _memberInfoDispCd; }
            set { _memberInfoDispCd = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  EraNameDispCd1
        /// <summary>�����\���敪�P�v���p�e�B</summary>
        /// <value>0:����@1:�a��i�ʏ�j�@�@</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// public propaty name  :  EraNameDispCd2
        /// <summary>�����\���敪�Q�v���p�e�B</summary>
        /// <value>0:����@1:�a��i�N���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd2
        {
            get { return _eraNameDispCd2; }
            set { _eraNameDispCd2 = value; }
        }

        /// public propaty name  :  EraNameDispCd3
        /// <summary>�����\���敪�R�v���p�e�B</summary>
        /// <value>0:����@1:�a��i���̑��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EraNameDispCd3
        {
            get { return _eraNameDispCd3; }
            set { _eraNameDispCd3 = value; }
        }

        /// public propaty name  :  SecMngDiv
        /// <summary>�����Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���_�@1:���_�{���@2:���_�{���{��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecMngDiv
        {
            get { return _secMngDiv; }
            set { _secMngDiv = value; }
        }

        /// public propaty name  :  GoodsNoInpDiv
        /// <summary>���i�ԍ����͋敪�v���p�e�B</summary>
        /// <value>0:�C�Ӂ@1:�K�{</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ����͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoInpDiv
        {
            get { return _goodsNoInpDiv; }
            set { _goodsNoInpDiv = value; }
        }


        /// public propaty name  :  CnsTaxAutoCorrDiv
        /// <summary>����Ŏ����␳�敪�v���p�e�B</summary>
        /// <value>0:�����@1:�蓮</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ŏ����␳�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CnsTaxAutoCorrDiv
        {
            get { return _cnsTaxAutoCorrDiv; }
            set { _cnsTaxAutoCorrDiv = value; }
        }

        /// public propaty name  :  RemainCntMngDiv
        /// <summary>�c���Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���� 1:���Ȃ� ���`�[�폜���Ɏc�ɖ߂����ǂ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c���Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RemainCntMngDiv
        {
            get { return _remainCntMngDiv; }
            set { _remainCntMngDiv = value; }
        }

        /// public propaty name  :  MemoMoveDiv
        /// <summary>�������ʋ敪�v���p�e�B</summary>
        /// <value>0:����@1:�ЊO�����̂݁@2:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MemoMoveDiv
        {
            get { return _memoMoveDiv; }
            set { _memoMoveDiv = value; }
        }

        /// public propaty name  :  RemCntAutoDspDiv
        /// <summary>�c�������\���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�,1:�o�׎c,���׎c�̂݁C2:�󔭒��c�̂݁C3:�o�׎c,���׎c ->�󔭒��c 4:�󔭒��c -> �o�׎c,���׎c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RemCntAutoDspDiv
        {
            get { return _remCntAutoDspDiv; }
            set { _remCntAutoDspDiv = value; }
        }

        /// public propaty name  :  TtlAmntDspRateDivCd
        /// <summary>���z�\���|���K�p�敪�v���p�e�B</summary>
        /// <value>0�F�ō��P��, 1:�Ŕ��P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���z�\���|���K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TtlAmntDspRateDivCd
        {
            get { return _ttlAmntDspRateDivCd; }
            set { _ttlAmntDspRateDivCd = value; }
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

        // --- ADD  ���r��  2010/01/18 ---------->>>>>
        /// public propaty name  :  DefTtlBillOutput
        /// <summary>�����\�����v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���@1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefTtlBillOutput
        {
            get { return _defTtlBillOutput; }
            set { _defTtlBillOutput = value; }
        }

        /// public propaty name  :  DefDtlBillOutput
        /// <summary>�����\�����א������o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���@1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����א������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefDtlBillOutput
        {
            get { return _defDtlBillOutput; }
            set { _defDtlBillOutput = value; }
        }

        /// public propaty name  :  DefSlTtlBillOutput
        /// <summary>�����\���`�[���v�������o�͋敪�v���p�e�B</summary>
        /// <value>0:�o�͂���@1:�o�͂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\���`�[���v�������o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DefSlTtlBillOutput
        {
            get { return _defSlTtlBillOutput; }
            set { _defSlTtlBillOutput = value; }
        }
        // --- ADD  ���r��  2010/01/18 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>�d���E�o�׌㐔�\���敪�v���p�e�B</summary>
        /// <value>0:�i�Ԋm���X�V�@1:���׊m���X�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���E�o�׌㐔�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DtlCalcStckCntDsp
        {
            get { return _dtlCalcStckCntDsp; }
            set { _dtlCalcStckCntDsp = value; }
        }
        //ADD 2011/07/19

        // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>���i�݌Ƀ}�X�^�\���敪�v���p�e�B</summary>
        /// <value>0:���i�݌Ƀ}�X�^�T�@1:���i�݌Ƀ}�X�^�U</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�݌ɕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsStockMSTBootDiv
        {
            get { return _goodsStockMSTBootDiv; }
            set { _goodsStockMSTBootDiv = value; }
        }
        // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>AllDefSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AllDefSet()
        {
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪(0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j)</param>
        /// <param name="defDspCustTtlDay">�����\���ڋq����(0�`31)</param>
        /// <param name="defDspCustClctMnyDay">�����\���ڋq�W����(0�`31)</param>
        /// <param name="defDspClctMnyMonthCd">�����\���W�����敪(0:����,1:����,2:���X��)</param>
        /// <param name="iniDspPrslOrCorpCd">�����\���l�E�@�l�敪(0:�l,1:�@�l)</param>
        /// <param name="initDspDmDiv">�����\��DM�敪(0:�c�l�o�͂���,1:�c�l�o�͂��Ȃ�)</param>
        /// <param name="defDspBillPrtDivCd">�����\���������o�͋敪(0:�������o�͂���,1:�������o�͂��Ȃ�)</param>
        /// <param name="eraNameDispCd1">�����\���敪�P(0:����@1:�a��i�ʏ�j�@�@)</param>
        /// <param name="eraNameDispCd2">�����\���敪�Q(0:����@1:�a��i�N���j)</param>
        /// <param name="eraNameDispCd3">�����\���敪�R(0:����@1:�a��i���̑��j)</param>
        /// <param name="secMngDiv">�����Ǘ��敪(0:���_�@1:���_�{���@2:���_�{���{��)</param>
        /// <param name="goodsNoInpDiv">���i�ԍ����͋敪(0:�C�Ӂ@1:�K�{)</param>
        /// <param name="cnsTaxAutoCorrDiv">����Ŏ����␳�敪(0:�����@1:�蓮)</param>
        /// <param name="remainCntMngDiv">�c���Ǘ��敪(0:���� 1:���Ȃ� ���`�[�폜���Ɏc�ɖ߂����ǂ���)</param>
        /// <param name="memoMoveDiv">�������ʋ敪(0:����@1:�ЊO�����̂݁@2:���Ȃ�)</param>
        /// <param name="remCntAutoDspDiv">�c�������\���敪(0:���Ȃ�,1:�o�׎c,���׎c�̂݁C2:�󔭒��c�̂݁C3:�o�׎c,���׎c ->�󔭒��c 4:�󔭒��c -> �o�׎c,���׎c)</param>
        /// <param name="ttlAmntDspRateDivCd">���z�\���|���K�p�敪(0�F�ō��P��, 1:�Ŕ��P��)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="dtlCalcStckCntDsp">���׎Z�o��݌ɐ��\���敪(0:�����㔽�f 1:�s�ړ������f)</param>
        /// <returns>AllDefSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ��@       :   10901273-00 2013/06/18�z�M���@
        /// �@�@�@�@�@�@�@�@�@   :   Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
        /// </remarks>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 customerDelChkDivCd, Int32 custCdAutoNumbering, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 memberInfoDispCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName)
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        // --- UPD  ���r��  2010/01/18 ---------->>>>>
        //public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName)
        //public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName, Int32 defTtlBillOutput, Int32 defDtlBillOutput, Int32 defSlTtlBillOutput)  //DEL 2011/07/19
        // --- UPD  ���r��  2010/01/18 ----------<<<<<
        //public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName, Int32 defTtlBillOutput, Int32 defDtlBillOutput, Int32 defSlTtlBillOutput, Int32 dtlCalcStckCntDsp)  //ADD 2011/07/19  //DEL ���N 2013/05/02 Redmine#35434
        public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName, Int32 defTtlBillOutput, Int32 defDtlBillOutput, Int32 defSlTtlBillOutput, Int32 dtlCalcStckCntDsp, Int32 goodsStockMSTBootDiv)  //ADD ���N 2013/05/02 Redmine#35434
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._customerDelChkDivCd = customerDelChkDivCd;
            this._custCdAutoNumbering = custCdAutoNumbering;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this._defDspCustTtlDay = defDspCustTtlDay;
            this._defDspCustClctMnyDay = defDspCustClctMnyDay;
            this._defDspClctMnyMonthCd = defDspClctMnyMonthCd;
            this._iniDspPrslOrCorpCd = iniDspPrslOrCorpCd;
            this._initDspDmDiv = initDspDmDiv;
            this._defDspBillPrtDivCd = defDspBillPrtDivCd;
            //this._memberInfoDispCd = memberInfoDispCd;  // DEL 2008/06/04
            this._eraNameDispCd1 = eraNameDispCd1;
            this._eraNameDispCd2 = eraNameDispCd2;
            this._eraNameDispCd3 = eraNameDispCd3;
            this._secMngDiv = secMngDiv;
            this._goodsNoInpDiv = goodsNoInpDiv;
            this._cnsTaxAutoCorrDiv = cnsTaxAutoCorrDiv;
            this._remainCntMngDiv = remainCntMngDiv;
            this._memoMoveDiv = memoMoveDiv;
            this._remCntAutoDspDiv = remCntAutoDspDiv;
            this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            this._defTtlBillOutput = defTtlBillOutput;
            this._defDtlBillOutput = defDtlBillOutput;
            this._defSlTtlBillOutput = defSlTtlBillOutput;
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            this._dtlCalcStckCntDsp = dtlCalcStckCntDsp; //ADD 2011/07/19
            this._goodsStockMSTBootDiv = goodsStockMSTBootDiv; // ADD ���N�@2013/05/02�@Redmine#35434

        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^��������
        /// </summary>
        /// <returns>AllDefSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AllDefSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ��@       :   10901273-00 2013/06/18�z�M���@
        /// �@�@�@�@�@�@�@�@�@   :   Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
        /// </remarks>
        public AllDefSet Clone()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._customerDelChkDivCd, this._custCdAutoNumbering, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._memberInfoDispCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            //return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName);
            //return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName, this._defTtlBillOutput, this._defDtlBillOutput, this._defSlTtlBillOutput);  //DEL 2011/07/19
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName, this._defTtlBillOutput, this._defDtlBillOutput, this._defSlTtlBillOutput, this._dtlCalcStckCntDsp);  //ADD 2011/07/19 //DEL ���N 2013/05/02 Redmine#35434
            return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName, this._defTtlBillOutput, this._defDtlBillOutput, this._defSlTtlBillOutput, this._dtlCalcStckCntDsp, this._goodsStockMSTBootDiv);   //ADD ���N 2013/05/02 Redmine#35434
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AllDefSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AllDefSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (this.CustomerDelChkDivCd == target.CustomerDelChkDivCd)
                && (this.CustCdAutoNumbering == target.CustCdAutoNumbering)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (this.DefDspCustTtlDay == target.DefDspCustTtlDay)
                 && (this.DefDspCustClctMnyDay == target.DefDspCustClctMnyDay)
                 && (this.DefDspClctMnyMonthCd == target.DefDspClctMnyMonthCd)
                 && (this.IniDspPrslOrCorpCd == target.IniDspPrslOrCorpCd)
                 && (this.InitDspDmDiv == target.InitDspDmDiv)
                 && (this.DefDspBillPrtDivCd == target.DefDspBillPrtDivCd)
                //&& (this.MemberInfoDispCd == target.MemberInfoDispCd)  // DEL 2008/06/04
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EraNameDispCd2 == target.EraNameDispCd2)
                 && (this.EraNameDispCd3 == target.EraNameDispCd3)
                 && (this.SecMngDiv == target.SecMngDiv)
                 && (this.GoodsNoInpDiv == target.GoodsNoInpDiv)
                 && (this.CnsTaxAutoCorrDiv == target.CnsTaxAutoCorrDiv)
                 && (this.RemainCntMngDiv == target.RemainCntMngDiv)
                 && (this.MemoMoveDiv == target.MemoMoveDiv)
                 && (this.RemCntAutoDspDiv == target.RemCntAutoDspDiv)
                 && (this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                // --- UPD  ���r��  2010/01/18 ---------->>>>>
                //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DefTtlBillOutput == target.DefTtlBillOutput)
                 && (this.DefDtlBillOutput == target.DefDtlBillOutput)
                 //&& (this.DefSlTtlBillOutput == target.DefSlTtlBillOutput)); //DEL 2011/07/19
                // --- UPD  ���r��  2010/01/18 ----------<<<<<
                // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
                && (this.GoodsStockMSTBootDiv == target.GoodsStockMSTBootDiv)
                // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<
                //ADD 2011/07/19
                && (this.DefSlTtlBillOutput == target.DefSlTtlBillOutput)
                && (this.DtlCalcStckCntDsp == target.DtlCalcStckCntDsp));
                //ADD 2011/07/19
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="allDefSet1">
        ///                    ��r����AllDefSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="allDefSet2">��r����AllDefSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ��@       :   10901273-00 2013/06/18�z�M���@
        /// �@�@�@�@�@�@�@�@�@   :   Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
        /// </remarks>
        public static bool Equals(AllDefSet allDefSet1, AllDefSet allDefSet2)
        {
            return ((allDefSet1.CreateDateTime == allDefSet2.CreateDateTime)
                 && (allDefSet1.UpdateDateTime == allDefSet2.UpdateDateTime)
                 && (allDefSet1.EnterpriseCode == allDefSet2.EnterpriseCode)
                 && (allDefSet1.FileHeaderGuid == allDefSet2.FileHeaderGuid)
                 && (allDefSet1.UpdEmployeeCode == allDefSet2.UpdEmployeeCode)
                 && (allDefSet1.UpdAssemblyId1 == allDefSet2.UpdAssemblyId1)
                 && (allDefSet1.UpdAssemblyId2 == allDefSet2.UpdAssemblyId2)
                 && (allDefSet1.LogicalDeleteCode == allDefSet2.LogicalDeleteCode)
                 && (allDefSet1.SectionCode == allDefSet2.SectionCode)
                 && (allDefSet1.TotalAmountDispWayCd == allDefSet2.TotalAmountDispWayCd)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (allDefSet1.CustomerDelChkDivCd == allDefSet2.CustomerDelChkDivCd)
                && (allDefSet1.CustCdAutoNumbering == allDefSet2.CustCdAutoNumbering)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (allDefSet1.DefDspCustTtlDay == allDefSet2.DefDspCustTtlDay)
                 && (allDefSet1.DefDspCustClctMnyDay == allDefSet2.DefDspCustClctMnyDay)
                 && (allDefSet1.DefDspClctMnyMonthCd == allDefSet2.DefDspClctMnyMonthCd)
                 && (allDefSet1.IniDspPrslOrCorpCd == allDefSet2.IniDspPrslOrCorpCd)
                 && (allDefSet1.InitDspDmDiv == allDefSet2.InitDspDmDiv)
                 && (allDefSet1.DefDspBillPrtDivCd == allDefSet2.DefDspBillPrtDivCd)
                //&& (allDefSet1.MemberInfoDispCd == allDefSet2.MemberInfoDispCd)  // DEL 2008/06/04
                 && (allDefSet1.EraNameDispCd1 == allDefSet2.EraNameDispCd1)
                 && (allDefSet1.EraNameDispCd2 == allDefSet2.EraNameDispCd2)
                 && (allDefSet1.EraNameDispCd3 == allDefSet2.EraNameDispCd3)
                 && (allDefSet1.SecMngDiv == allDefSet2.SecMngDiv)
                 && (allDefSet1.GoodsNoInpDiv == allDefSet2.GoodsNoInpDiv)
                 && (allDefSet1.CnsTaxAutoCorrDiv == allDefSet2.CnsTaxAutoCorrDiv)
                 && (allDefSet1.RemainCntMngDiv == allDefSet2.RemainCntMngDiv)
                 && (allDefSet1.MemoMoveDiv == allDefSet2.MemoMoveDiv)
                 && (allDefSet1.RemCntAutoDspDiv == allDefSet2.RemCntAutoDspDiv)
                 && (allDefSet1.TtlAmntDspRateDivCd == allDefSet2.TtlAmntDspRateDivCd)
                 && (allDefSet1.EnterpriseName == allDefSet2.EnterpriseName)
                // --- UPD  ���r��  2010/01/18 ---------->>>>>
                //&& (allDefSet1.UpdEmployeeName == allDefSet2.UpdEmployeeName));
                 && (allDefSet1.UpdEmployeeName == allDefSet2.UpdEmployeeName)
                 && (allDefSet1.DefTtlBillOutput == allDefSet2.DefTtlBillOutput)
                 && (allDefSet1.DefDtlBillOutput == allDefSet2.DefDtlBillOutput)
                 //&& (allDefSet1.DefSlTtlBillOutput == allDefSet2.DefSlTtlBillOutput)); //DEL 2011/07/19
                // --- UPD  ���r��  2010/01/18 ----------<<<<<
                 && (allDefSet1.GoodsStockMSTBootDiv == allDefSet2.GoodsStockMSTBootDiv) //  ADD ���N 2013/05/02 Redmine#35434 
                //ADD 2011/07/19
                && (allDefSet1.DefSlTtlBillOutput == allDefSet2.DefSlTtlBillOutput)
                && (allDefSet1.DtlCalcStckCntDsp == allDefSet2.DtlCalcStckCntDsp));
                //ADD 2011/07/19
        }
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AllDefSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ��@       :   10901273-00 2013/06/18�z�M���@
        /// �@�@�@�@�@�@�@�@�@   :   Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
        /// </remarks>
        public ArrayList Compare(AllDefSet target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this.CustomerDelChkDivCd != target.CustomerDelChkDivCd) resList.Add("CustomerDelChkDivCd");
            if (this.CustCdAutoNumbering != target.CustCdAutoNumbering) resList.Add("CustCdAutoNumbering");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (this.DefDspCustTtlDay != target.DefDspCustTtlDay) resList.Add("DefDspCustTtlDay");
            if (this.DefDspCustClctMnyDay != target.DefDspCustClctMnyDay) resList.Add("DefDspCustClctMnyDay");
            if (this.DefDspClctMnyMonthCd != target.DefDspClctMnyMonthCd) resList.Add("DefDspClctMnyMonthCd");
            if (this.IniDspPrslOrCorpCd != target.IniDspPrslOrCorpCd) resList.Add("IniDspPrslOrCorpCd");
            if (this.InitDspDmDiv != target.InitDspDmDiv) resList.Add("InitDspDmDiv");
            if (this.DefDspBillPrtDivCd != target.DefDspBillPrtDivCd) resList.Add("DefDspBillPrtDivCd");
            //if (this.MemberInfoDispCd != target.MemberInfoDispCd) resList.Add("MemberInfoDispCd");  // DEL 2008/06/04
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.EraNameDispCd2 != target.EraNameDispCd2) resList.Add("EraNameDispCd2");
            if (this.EraNameDispCd3 != target.EraNameDispCd3) resList.Add("EraNameDispCd3");
            if (this.SecMngDiv != target.SecMngDiv) resList.Add("SecMngDiv");
            if (this.GoodsNoInpDiv != target.GoodsNoInpDiv) resList.Add("GoodsNoInpDiv");
            if (this.CnsTaxAutoCorrDiv != target.CnsTaxAutoCorrDiv) resList.Add("CnsTaxAutoCorrDiv");
            if (this.RemainCntMngDiv != target.RemainCntMngDiv) resList.Add("RemainCntMngDiv");
            if (this.MemoMoveDiv != target.MemoMoveDiv) resList.Add("MemoMoveDiv");
            if (this.RemCntAutoDspDiv != target.RemCntAutoDspDiv) resList.Add("RemCntAutoDspDiv");
            if (this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            if (this.DefTtlBillOutput != target.DefTtlBillOutput) resList.Add("DefTtlBillOutput");
            if (this.DefDtlBillOutput != target.DefDtlBillOutput) resList.Add("DefDtlBillOutput");
            if (this.DefSlTtlBillOutput != target.DefSlTtlBillOutput) resList.Add("DefSlTtlBillOutput");
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            if (this.DtlCalcStckCntDsp != target.DtlCalcStckCntDsp) resList.Add("DtlCalcStckCntDsp"); //ADD 2011/07/19
            if (this.GoodsStockMSTBootDiv != target.GoodsStockMSTBootDiv) resList.Add("GoodsStockMSTBootDiv"); // ADD ���N 2013/05/02 Redmine#35434

            return resList;
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="allDefSet1">��r����AllDefSet�N���X�̃C���X�^���X</param>
        /// <param name="allDefSet2">��r����AllDefSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AllDefSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2013/05/02 ���N</br>
        /// <br>�Ǘ��ԍ��@       :   10901273-00 2013/06/18�z�M���@
        /// �@�@�@�@�@�@�@�@�@   :   Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
        /// </remarks>
        public static ArrayList Compare(AllDefSet allDefSet1, AllDefSet allDefSet2)
        {
            ArrayList resList = new ArrayList();
            if (allDefSet1.CreateDateTime != allDefSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (allDefSet1.UpdateDateTime != allDefSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (allDefSet1.EnterpriseCode != allDefSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (allDefSet1.FileHeaderGuid != allDefSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (allDefSet1.UpdEmployeeCode != allDefSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (allDefSet1.UpdAssemblyId1 != allDefSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (allDefSet1.UpdAssemblyId2 != allDefSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (allDefSet1.LogicalDeleteCode != allDefSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (allDefSet1.SectionCode != allDefSet2.SectionCode) resList.Add("SectionCode");
            if (allDefSet1.TotalAmountDispWayCd != allDefSet2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (allDefSet1.CustomerDelChkDivCd != allDefSet2.CustomerDelChkDivCd) resList.Add("CustomerDelChkDivCd");
            if (allDefSet1.CustCdAutoNumbering != allDefSet2.CustCdAutoNumbering) resList.Add("CustCdAutoNumbering");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (allDefSet1.DefDspCustTtlDay != allDefSet2.DefDspCustTtlDay) resList.Add("DefDspCustTtlDay");
            if (allDefSet1.DefDspCustClctMnyDay != allDefSet2.DefDspCustClctMnyDay) resList.Add("DefDspCustClctMnyDay");
            if (allDefSet1.DefDspClctMnyMonthCd != allDefSet2.DefDspClctMnyMonthCd) resList.Add("DefDspClctMnyMonthCd");
            if (allDefSet1.IniDspPrslOrCorpCd != allDefSet2.IniDspPrslOrCorpCd) resList.Add("IniDspPrslOrCorpCd");
            if (allDefSet1.InitDspDmDiv != allDefSet2.InitDspDmDiv) resList.Add("InitDspDmDiv");
            if (allDefSet1.DefDspBillPrtDivCd != allDefSet2.DefDspBillPrtDivCd) resList.Add("DefDspBillPrtDivCd");
            //if (allDefSet1.MemberInfoDispCd != allDefSet2.MemberInfoDispCd) resList.Add("MemberInfoDispCd");  // DEL 2008/06/04
            if (allDefSet1.EraNameDispCd1 != allDefSet2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (allDefSet1.EraNameDispCd2 != allDefSet2.EraNameDispCd2) resList.Add("EraNameDispCd2");
            if (allDefSet1.EraNameDispCd3 != allDefSet2.EraNameDispCd3) resList.Add("EraNameDispCd3");
            if (allDefSet1.SecMngDiv != allDefSet2.SecMngDiv) resList.Add("SecMngDiv");
            if (allDefSet1.GoodsNoInpDiv != allDefSet2.GoodsNoInpDiv) resList.Add("GoodsNoInpDiv");


            if (allDefSet1.CnsTaxAutoCorrDiv != allDefSet2.CnsTaxAutoCorrDiv) resList.Add("CnsTaxAutoCorrDiv");
            if (allDefSet1.RemainCntMngDiv != allDefSet2.RemainCntMngDiv) resList.Add("RemainCntMngDiv");
            if (allDefSet1.MemoMoveDiv != allDefSet2.MemoMoveDiv) resList.Add("MemoMoveDiv");
            if (allDefSet1.RemCntAutoDspDiv != allDefSet2.RemCntAutoDspDiv) resList.Add("RemCntAutoDspDiv");
            if (allDefSet1.TtlAmntDspRateDivCd != allDefSet2.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (allDefSet1.EnterpriseName != allDefSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (allDefSet1.UpdEmployeeName != allDefSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            if (allDefSet1.DefTtlBillOutput != allDefSet2.DefTtlBillOutput) resList.Add("DefTtlBillOutput");
            if (allDefSet1.DefDtlBillOutput != allDefSet2.DefDtlBillOutput) resList.Add("DefDtlBillOutput");
            if (allDefSet1.DefSlTtlBillOutput != allDefSet2.DefSlTtlBillOutput) resList.Add("DefSlTtlBillOutput");
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            if (allDefSet1.DtlCalcStckCntDsp != allDefSet2.DtlCalcStckCntDsp) resList.Add("DtlCalcStckCntDsp"); //ADD 2011/07/19
            if (allDefSet1.GoodsStockMSTBootDiv != allDefSet2.GoodsStockMSTBootDiv) resList.Add("GoodsStockMSTBootDiv"); // ADD ���N 2013/05/02 Redmine#35434

            return resList;
        }
    }
}
