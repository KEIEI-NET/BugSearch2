//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM�D��ݒ�}�X�^
// �v���O�����T�v   : SCM�D��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SCMPriorSt
    /// <summary>
    ///                      SCM�D��ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�D��ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2011/08/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/08/08  ����</br>
    /// <br>                 :   �����ڕύX</br>
    /// <br>                 :   �D��ݒ�R�[�h�U�`�P�O</br>
    /// <br>                 :   �D��ݒ薼�̂U�`�P�O</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   �D�承�i�ݒ�R�[�h�P�`�T</br>
    /// <br>                 :   �D�承�i�ݒ薼�̂P�`�T</br>
    /// </remarks>
    public class SCMPriorSt 
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
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>�D��ݒ�R�[�h�P</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _prioritySettingCd1;

        /// <summary>�D��ݒ薼�̂P</summary>
        private string _prioritySettingNm1 = "";

        /// <summary>�D��ݒ�R�[�h�Q</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _prioritySettingCd2;

        /// <summary>�D��ݒ薼�̂Q</summary>
        private string _prioritySettingNm2 = "";

        /// <summary>�D��ݒ�R�[�h�R</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _prioritySettingCd3;

        /// <summary>�D��ݒ薼�̂R</summary>
        private string _prioritySettingNm3 = "";

        /// <summary>�D��ݒ�R�[�h�S</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _prioritySettingCd4;

        /// <summary>�D��ݒ薼�̂S</summary>
        private string _prioritySettingNm4 = "";

        /// <summary>�D��ݒ�R�[�h�T</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _prioritySettingCd5;

        /// <summary>�D��ݒ薼�̂T</summary>
        private string _prioritySettingNm5 = "";

        /// <summary>�D�承�i�ݒ�R�[�h�P</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _priorPriceSetCd1;

        /// <summary>�D�承�i�ݒ薼�̂P</summary>
        private string _priorPriceSetNm1 = "";

        /// <summary>�D�承�i�ݒ�R�[�h�Q</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _priorPriceSetCd2;

        /// <summary>�D�承�i�ݒ薼�̂Q</summary>
        private string _priorPriceSetNm2 = "";

        /// <summary>�D�承�i�ݒ�R�[�h�R</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _priorPriceSetCd3;

        /// <summary>�D�承�i�ݒ薼�̂R</summary>
        private string _priorPriceSetNm3 = "";

        /// <summary>�D�承�i�ݒ�R�[�h�S</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _priorPriceSetCd4;

        /// <summary>�D�承�i�ݒ薼�̂S</summary>
        private string _priorPriceSetNm4 = "";

        /// <summary>�D�承�i�ݒ�R�[�h�T</summary>
        /// <remarks>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</remarks>
        private Int32 _priorPriceSetCd5;

        /// <summary>�D�承�i�ݒ薼�̂T</summary>
        private string _priorPriceSetNm5 = "";

        /// <summary>�D��K�p�敪</summary>
        /// <remarks>0:����, 1:PCC, 2:PCCUOE</remarks>
        private Int32 _priorAppliDiv;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�I�����Ώۏ��D�敪</summary>
        /// <remarks>0:�S��, 1:����</remarks>
        private Int32 _selTgtPureDiv;

        /// <summary>�I�����Ώۍ݌ɋ敪</summary>
        /// <remarks>0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�</remarks>
        private Int32 _selTgtStckDiv;

        /// <summary>�I�����ΏۃL�����y�[���敪</summary>
        /// <remarks>0:�S��, 1:�L�����y�[��</remarks>
        private Int32 _selTgtCampDiv;

        /// <summary>�I�����Ώۉ��i�敪�P</summary>
        /// <remarks>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</remarks>
        private Int32 _selTgtPricDiv1;

        /// <summary>�I�����Ώۉ��i�敪�Q</summary>
        /// <remarks>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</remarks>
        private Int32 _selTgtPricDiv2;

        /// <summary>�I�����Ώۉ��i�敪�R</summary>
        /// <remarks>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</remarks>
        private Int32 _selTgtPricDiv3;

        /// <summary>��I�����Ώۏ��D�敪</summary>
        /// <remarks>0:�S��, 1:����</remarks>
        private Int32 _unSelTgtPureDiv;

        /// <summary>��I�����Ώۍ݌ɋ敪</summary>
        /// <remarks>0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�</remarks>
        private Int32 _unSelTgtStckDiv;

        /// <summary>��I�����ΏۃL�����y�[���敪</summary>
        /// <remarks>0:�S��, 1:�L�����y�[��</remarks>
        private Int32 _unSelTgtCampDiv;

        /// <summary>��I�����Ώۉ��i�敪�P</summary>
        /// <remarks>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</remarks>
        private Int32 _unSelTgtPricDiv1;

        /// <summary>��I�����Ώۉ��i�敪�Q</summary>
        /// <remarks>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</remarks>
        private Int32 _unSelTgtPricDiv2;

        /// <summary>��I�����Ώۉ��i�敪�R</summary>
        /// <remarks>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</remarks>
        private Int32 _unSelTgtPricDiv3;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  PrioritySettingCd1
        /// <summary>�D��ݒ�R�[�h�P�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd1
        {
            get { return _prioritySettingCd1; }
            set { _prioritySettingCd1 = value; }
        }

        /// public propaty name  :  PrioritySettingNm1
        /// <summary>�D��ݒ薼�̂P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm1
        {
            get { return _prioritySettingNm1; }
            set { _prioritySettingNm1 = value; }
        }

        /// public propaty name  :  PrioritySettingCd2
        /// <summary>�D��ݒ�R�[�h�Q�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd2
        {
            get { return _prioritySettingCd2; }
            set { _prioritySettingCd2 = value; }
        }

        /// public propaty name  :  PrioritySettingNm2
        /// <summary>�D��ݒ薼�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm2
        {
            get { return _prioritySettingNm2; }
            set { _prioritySettingNm2 = value; }
        }

        /// public propaty name  :  PrioritySettingCd3
        /// <summary>�D��ݒ�R�[�h�R�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd3
        {
            get { return _prioritySettingCd3; }
            set { _prioritySettingCd3 = value; }
        }

        /// public propaty name  :  PrioritySettingNm3
        /// <summary>�D��ݒ薼�̂R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm3
        {
            get { return _prioritySettingNm3; }
            set { _prioritySettingNm3 = value; }
        }

        /// public propaty name  :  PrioritySettingCd4
        /// <summary>�D��ݒ�R�[�h�S�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd4
        {
            get { return _prioritySettingCd4; }
            set { _prioritySettingCd4 = value; }
        }

        /// public propaty name  :  PrioritySettingNm4
        /// <summary>�D��ݒ薼�̂S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm4
        {
            get { return _prioritySettingNm4; }
            set { _prioritySettingNm4 = value; }
        }

        /// public propaty name  :  PrioritySettingCd5
        /// <summary>�D��ݒ�R�[�h�T�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd5
        {
            get { return _prioritySettingCd5; }
            set { _prioritySettingCd5 = value; }
        }

        /// public propaty name  :  PrioritySettingNm5
        /// <summary>�D��ݒ薼�̂T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm5
        {
            get { return _prioritySettingNm5; }
            set { _prioritySettingNm5 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd1
        /// <summary>�D�承�i�ݒ�R�[�h�P�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd1
        {
            get { return _priorPriceSetCd1; }
            set { _priorPriceSetCd1 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm1
        /// <summary>�D�承�i�ݒ薼�̂P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm1
        {
            get { return _priorPriceSetNm1; }
            set { _priorPriceSetNm1 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd2
        /// <summary>�D�承�i�ݒ�R�[�h�Q�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd2
        {
            get { return _priorPriceSetCd2; }
            set { _priorPriceSetCd2 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm2
        /// <summary>�D�承�i�ݒ薼�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm2
        {
            get { return _priorPriceSetNm2; }
            set { _priorPriceSetNm2 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd3
        /// <summary>�D�承�i�ݒ�R�[�h�R�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd3
        {
            get { return _priorPriceSetCd3; }
            set { _priorPriceSetCd3 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm3
        /// <summary>�D�承�i�ݒ薼�̂R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm3
        {
            get { return _priorPriceSetNm3; }
            set { _priorPriceSetNm3 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd4
        /// <summary>�D�承�i�ݒ�R�[�h�S�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd4
        {
            get { return _priorPriceSetCd4; }
            set { _priorPriceSetCd4 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm4
        /// <summary>�D�承�i�ݒ薼�̂S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm4
        {
            get { return _priorPriceSetNm4; }
            set { _priorPriceSetNm4 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd5
        /// <summary>�D�承�i�ݒ�R�[�h�T�v���p�e�B</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd5
        {
            get { return _priorPriceSetCd5; }
            set { _priorPriceSetCd5 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm5
        /// <summary>�D�承�i�ݒ薼�̂T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm5
        {
            get { return _priorPriceSetNm5; }
            set { _priorPriceSetNm5 = value; }
        }

        /// public propaty name  :  PriorAppliDiv
        /// <summary>�D��K�p�敪�v���p�e�B</summary>
        /// <value>0:����, 1:PCC, 2:PCCUOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorAppliDiv
        {
            get { return _priorAppliDiv; }
            set { _priorAppliDiv = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SelTgtPureDiv
        /// <summary>�I�����Ώۏ��D�敪�v���p�e�B</summary>
        /// <value>0:�S��, 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۏ��D�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPureDiv
        {
            get { return _selTgtPureDiv; }
            set { _selTgtPureDiv = value; }
        }

        /// public propaty name  :  SelTgtStckDiv
        /// <summary>�I�����Ώۍ݌ɋ敪�v���p�e�B</summary>
        /// <value>0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۍ݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtStckDiv
        {
            get { return _selTgtStckDiv; }
            set { _selTgtStckDiv = value; }
        }

        /// public propaty name  :  SelTgtCampDiv
        /// <summary>�I�����ΏۃL�����y�[���敪�v���p�e�B</summary>
        /// <value>0:�S��, 1:�L�����y�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����ΏۃL�����y�[���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtCampDiv
        {
            get { return _selTgtCampDiv; }
            set { _selTgtCampDiv = value; }
        }

        /// public propaty name  :  SelTgtPricDiv1
        /// <summary>�I�����Ώۉ��i�敪�P�v���p�e�B</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۉ��i�敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPricDiv1
        {
            get { return _selTgtPricDiv1; }
            set { _selTgtPricDiv1 = value; }
        }

        /// public propaty name  :  SelTgtPricDiv2
        /// <summary>�I�����Ώۉ��i�敪�Q�v���p�e�B</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۉ��i�敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPricDiv2
        {
            get { return _selTgtPricDiv2; }
            set { _selTgtPricDiv2 = value; }
        }

        /// public propaty name  :  SelTgtPricDiv3
        /// <summary>�I�����Ώۉ��i�敪�R�v���p�e�B</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۉ��i�敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPricDiv3
        {
            get { return _selTgtPricDiv3; }
            set { _selTgtPricDiv3 = value; }
        }

        /// public propaty name  :  UnSelTgtPureDiv
        /// <summary>��I�����Ώۏ��D�敪�v���p�e�B</summary>
        /// <value>0:�S��, 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۏ��D�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPureDiv
        {
            get { return _unSelTgtPureDiv; }
            set { _unSelTgtPureDiv = value; }
        }

        /// public propaty name  :  UnSelTgtStckDiv
        /// <summary>��I�����Ώۍ݌ɋ敪�v���p�e�B</summary>
        /// <value>0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۍ݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtStckDiv
        {
            get { return _unSelTgtStckDiv; }
            set { _unSelTgtStckDiv = value; }
        }

        /// public propaty name  :  UnSelTgtCampDiv
        /// <summary>��I�����ΏۃL�����y�[���敪�v���p�e�B</summary>
        /// <value>0:�S��, 1:�L�����y�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����ΏۃL�����y�[���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtCampDiv
        {
            get { return _unSelTgtCampDiv; }
            set { _unSelTgtCampDiv = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv1
        /// <summary>��I�����Ώۉ��i�敪�P�v���p�e�B</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۉ��i�敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv1
        {
            get { return _unSelTgtPricDiv1; }
            set { _unSelTgtPricDiv1 = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv2
        /// <summary>��I�����Ώۉ��i�敪�Q�v���p�e�B</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۉ��i�敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv2
        {
            get { return _unSelTgtPricDiv2; }
            set { _unSelTgtPricDiv2 = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv3
        /// <summary>��I�����Ώۉ��i�敪�R�v���p�e�B</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۉ��i�敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv3
        {
            get { return _unSelTgtPricDiv3; }
            set { _unSelTgtPricDiv3 = value; }
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


        /// <summary>
        /// SCM�D��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SCMPriorSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMPriorSt()
        {
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="prioritySettingCd1">�D��ݒ�R�[�h�P(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="prioritySettingNm1">�D��ݒ薼�̂P</param>
        /// <param name="prioritySettingCd2">�D��ݒ�R�[�h�Q(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="prioritySettingNm2">�D��ݒ薼�̂Q</param>
        /// <param name="prioritySettingCd3">�D��ݒ�R�[�h�R(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="prioritySettingNm3">�D��ݒ薼�̂R</param>
        /// <param name="prioritySettingCd4">�D��ݒ�R�[�h�S(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="prioritySettingNm4">�D��ݒ薼�̂S</param>
        /// <param name="prioritySettingCd5">�D��ݒ�R�[�h�T(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="prioritySettingNm5">�D��ݒ薼�̂T</param>
        /// <param name="priorPriceSetCd1">�D�承�i�ݒ�R�[�h�P(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="priorPriceSetNm1">�D�承�i�ݒ薼�̂P</param>
        /// <param name="priorPriceSetCd2">�D�承�i�ݒ�R�[�h�Q(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="priorPriceSetNm2">�D�承�i�ݒ薼�̂Q</param>
        /// <param name="priorPriceSetCd3">�D�承�i�ݒ�R�[�h�R(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="priorPriceSetNm3">�D�承�i�ݒ薼�̂R</param>
        /// <param name="priorPriceSetCd4">�D�承�i�ݒ�R�[�h�S(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="priorPriceSetNm4">�D�承�i�ݒ薼�̂S</param>
        /// <param name="priorPriceSetCd5">�D�承�i�ݒ�R�[�h�T(0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����)</param>
        /// <param name="priorPriceSetNm5">�D�承�i�ݒ薼�̂T</param>
        /// <param name="priorAppliDiv">�D��K�p�敪(0:����, 1:PCC, 2:PCCUOE)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="selTgtPureDiv">�I�����Ώۏ��D�敪(0:�S��, 1:����)</param>
        /// <param name="selTgtStckDiv">�I�����Ώۍ݌ɋ敪(0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�)</param>
        /// <param name="selTgtCampDiv">�I�����ΏۃL�����y�[���敪(0:�S��, 1:�L�����y�[��)</param>
        /// <param name="selTgtPricDiv1">�I�����Ώۉ��i�敪�P(0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��))</param>
        /// <param name="selTgtPricDiv2">�I�����Ώۉ��i�敪�Q(0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��))</param>
        /// <param name="selTgtPricDiv3">�I�����Ώۉ��i�敪�R(0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��))</param>
        /// <param name="unSelTgtPureDiv">��I�����Ώۏ��D�敪(0:�S��, 1:����)</param>
        /// <param name="unSelTgtStckDiv">��I�����Ώۍ݌ɋ敪(0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�)</param>
        /// <param name="unSelTgtCampDiv">��I�����ΏۃL�����y�[���敪(0:�S��, 1:�L�����y�[��)</param>
        /// <param name="unSelTgtPricDiv1">��I�����Ώۉ��i�敪�P(0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��))</param>
        /// <param name="unSelTgtPricDiv2">��I�����Ώۉ��i�敪�Q(0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��))</param>
        /// <param name="unSelTgtPricDiv3">��I�����Ώۉ��i�敪�R(0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��))</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>SCMPriorSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMPriorSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 prioritySettingCd1, string prioritySettingNm1, Int32 prioritySettingCd2, string prioritySettingNm2, Int32 prioritySettingCd3, string prioritySettingNm3, Int32 prioritySettingCd4, string prioritySettingNm4, Int32 prioritySettingCd5, string prioritySettingNm5, Int32 priorPriceSetCd1, string priorPriceSetNm1, Int32 priorPriceSetCd2, string priorPriceSetNm2, Int32 priorPriceSetCd3, string priorPriceSetNm3, Int32 priorPriceSetCd4, string priorPriceSetNm4, Int32 priorPriceSetCd5, string priorPriceSetNm5, Int32 priorAppliDiv, Int32 customerCode, Int32 selTgtPureDiv, Int32 selTgtStckDiv, Int32 selTgtCampDiv, Int32 selTgtPricDiv1, Int32 selTgtPricDiv2, Int32 selTgtPricDiv3, Int32 unSelTgtPureDiv, Int32 unSelTgtStckDiv, Int32 unSelTgtCampDiv, Int32 unSelTgtPricDiv1, Int32 unSelTgtPricDiv2, Int32 unSelTgtPricDiv3, string enterpriseName, string updEmployeeName)
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
            this._prioritySettingCd1 = prioritySettingCd1;
            this._prioritySettingNm1 = prioritySettingNm1;
            this._prioritySettingCd2 = prioritySettingCd2;
            this._prioritySettingNm2 = prioritySettingNm2;
            this._prioritySettingCd3 = prioritySettingCd3;
            this._prioritySettingNm3 = prioritySettingNm3;
            this._prioritySettingCd4 = prioritySettingCd4;
            this._prioritySettingNm4 = prioritySettingNm4;
            this._prioritySettingCd5 = prioritySettingCd5;
            this._prioritySettingNm5 = prioritySettingNm5;
            this._priorPriceSetCd1 = priorPriceSetCd1;
            this._priorPriceSetNm1 = priorPriceSetNm1;
            this._priorPriceSetCd2 = priorPriceSetCd2;
            this._priorPriceSetNm2 = priorPriceSetNm2;
            this._priorPriceSetCd3 = priorPriceSetCd3;
            this._priorPriceSetNm3 = priorPriceSetNm3;
            this._priorPriceSetCd4 = priorPriceSetCd4;
            this._priorPriceSetNm4 = priorPriceSetNm4;
            this._priorPriceSetCd5 = priorPriceSetCd5;
            this._priorPriceSetNm5 = priorPriceSetNm5;
            this._priorAppliDiv = priorAppliDiv;
            this._customerCode = customerCode;
            this._selTgtPureDiv = selTgtPureDiv;
            this._selTgtStckDiv = selTgtStckDiv;
            this._selTgtCampDiv = selTgtCampDiv;
            this._selTgtPricDiv1 = selTgtPricDiv1;
            this._selTgtPricDiv2 = selTgtPricDiv2;
            this._selTgtPricDiv3 = selTgtPricDiv3;
            this._unSelTgtPureDiv = unSelTgtPureDiv;
            this._unSelTgtStckDiv = unSelTgtStckDiv;
            this._unSelTgtCampDiv = unSelTgtCampDiv;
            this._unSelTgtPricDiv1 = unSelTgtPricDiv1;
            this._unSelTgtPricDiv2 = unSelTgtPricDiv2;
            this._unSelTgtPricDiv3 = unSelTgtPricDiv3;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^��������
        /// </summary>
        /// <returns>SCMPriorSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMPriorSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMPriorSt Clone()
        {
            return new SCMPriorSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._prioritySettingCd1, this._prioritySettingNm1, this._prioritySettingCd2, this._prioritySettingNm2, this._prioritySettingCd3, this._prioritySettingNm3, this._prioritySettingCd4, this._prioritySettingNm4, this._prioritySettingCd5, this._prioritySettingNm5, this._priorPriceSetCd1, this._priorPriceSetNm1, this._priorPriceSetCd2, this._priorPriceSetNm2, this._priorPriceSetCd3, this._priorPriceSetNm3, this._priorPriceSetCd4, this._priorPriceSetNm4, this._priorPriceSetCd5, this._priorPriceSetNm5, this._priorAppliDiv, this._customerCode, this._selTgtPureDiv, this._selTgtStckDiv, this._selTgtCampDiv, this._selTgtPricDiv1, this._selTgtPricDiv2, this._selTgtPricDiv3, this._unSelTgtPureDiv, this._unSelTgtStckDiv, this._unSelTgtCampDiv, this._unSelTgtPricDiv1, this._unSelTgtPricDiv2, this._unSelTgtPricDiv3, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SCMPriorSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SCMPriorSt target)
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
                 && (this.PrioritySettingCd1 == target.PrioritySettingCd1)
                 && (this.PrioritySettingNm1 == target.PrioritySettingNm1)
                 && (this.PrioritySettingCd2 == target.PrioritySettingCd2)
                 && (this.PrioritySettingNm2 == target.PrioritySettingNm2)
                 && (this.PrioritySettingCd3 == target.PrioritySettingCd3)
                 && (this.PrioritySettingNm3 == target.PrioritySettingNm3)
                 && (this.PrioritySettingCd4 == target.PrioritySettingCd4)
                 && (this.PrioritySettingNm4 == target.PrioritySettingNm4)
                 && (this.PrioritySettingCd5 == target.PrioritySettingCd5)
                 && (this.PrioritySettingNm5 == target.PrioritySettingNm5)
                 && (this.PriorPriceSetCd1 == target.PriorPriceSetCd1)
                 && (this.PriorPriceSetNm1 == target.PriorPriceSetNm1)
                 && (this.PriorPriceSetCd2 == target.PriorPriceSetCd2)
                 && (this.PriorPriceSetNm2 == target.PriorPriceSetNm2)
                 && (this.PriorPriceSetCd3 == target.PriorPriceSetCd3)
                 && (this.PriorPriceSetNm3 == target.PriorPriceSetNm3)
                 && (this.PriorPriceSetCd4 == target.PriorPriceSetCd4)
                 && (this.PriorPriceSetNm4 == target.PriorPriceSetNm4)
                 && (this.PriorPriceSetCd5 == target.PriorPriceSetCd5)
                 && (this.PriorPriceSetNm5 == target.PriorPriceSetNm5)
                 && (this.PriorAppliDiv == target.PriorAppliDiv)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SelTgtPureDiv == target.SelTgtPureDiv)
                 && (this.SelTgtStckDiv == target.SelTgtStckDiv)
                 && (this.SelTgtCampDiv == target.SelTgtCampDiv)
                 && (this.SelTgtPricDiv1 == target.SelTgtPricDiv1)
                 && (this.SelTgtPricDiv2 == target.SelTgtPricDiv2)
                 && (this.SelTgtPricDiv3 == target.SelTgtPricDiv3)
                 && (this.UnSelTgtPureDiv == target.UnSelTgtPureDiv)
                 && (this.UnSelTgtStckDiv == target.UnSelTgtStckDiv)
                 && (this.UnSelTgtCampDiv == target.UnSelTgtCampDiv)
                 && (this.UnSelTgtPricDiv1 == target.UnSelTgtPricDiv1)
                 && (this.UnSelTgtPricDiv2 == target.UnSelTgtPricDiv2)
                 && (this.UnSelTgtPricDiv3 == target.UnSelTgtPricDiv3)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="sCMPriorSt1">
        ///                    ��r����SCMPriorSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="sCMPriorSt2">��r����SCMPriorSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SCMPriorSt sCMPriorSt1, SCMPriorSt sCMPriorSt2)
        {
            return ((sCMPriorSt1.CreateDateTime == sCMPriorSt2.CreateDateTime)
                 && (sCMPriorSt1.UpdateDateTime == sCMPriorSt2.UpdateDateTime)
                 && (sCMPriorSt1.EnterpriseCode == sCMPriorSt2.EnterpriseCode)
                 && (sCMPriorSt1.FileHeaderGuid == sCMPriorSt2.FileHeaderGuid)
                 && (sCMPriorSt1.UpdEmployeeCode == sCMPriorSt2.UpdEmployeeCode)
                 && (sCMPriorSt1.UpdAssemblyId1 == sCMPriorSt2.UpdAssemblyId1)
                 && (sCMPriorSt1.UpdAssemblyId2 == sCMPriorSt2.UpdAssemblyId2)
                 && (sCMPriorSt1.LogicalDeleteCode == sCMPriorSt2.LogicalDeleteCode)
                 && (sCMPriorSt1.SectionCode == sCMPriorSt2.SectionCode)
                 && (sCMPriorSt1.PrioritySettingCd1 == sCMPriorSt2.PrioritySettingCd1)
                 && (sCMPriorSt1.PrioritySettingNm1 == sCMPriorSt2.PrioritySettingNm1)
                 && (sCMPriorSt1.PrioritySettingCd2 == sCMPriorSt2.PrioritySettingCd2)
                 && (sCMPriorSt1.PrioritySettingNm2 == sCMPriorSt2.PrioritySettingNm2)
                 && (sCMPriorSt1.PrioritySettingCd3 == sCMPriorSt2.PrioritySettingCd3)
                 && (sCMPriorSt1.PrioritySettingNm3 == sCMPriorSt2.PrioritySettingNm3)
                 && (sCMPriorSt1.PrioritySettingCd4 == sCMPriorSt2.PrioritySettingCd4)
                 && (sCMPriorSt1.PrioritySettingNm4 == sCMPriorSt2.PrioritySettingNm4)
                 && (sCMPriorSt1.PrioritySettingCd5 == sCMPriorSt2.PrioritySettingCd5)
                 && (sCMPriorSt1.PrioritySettingNm5 == sCMPriorSt2.PrioritySettingNm5)
                 && (sCMPriorSt1.PriorPriceSetCd1 == sCMPriorSt2.PriorPriceSetCd1)
                 && (sCMPriorSt1.PriorPriceSetNm1 == sCMPriorSt2.PriorPriceSetNm1)
                 && (sCMPriorSt1.PriorPriceSetCd2 == sCMPriorSt2.PriorPriceSetCd2)
                 && (sCMPriorSt1.PriorPriceSetNm2 == sCMPriorSt2.PriorPriceSetNm2)
                 && (sCMPriorSt1.PriorPriceSetCd3 == sCMPriorSt2.PriorPriceSetCd3)
                 && (sCMPriorSt1.PriorPriceSetNm3 == sCMPriorSt2.PriorPriceSetNm3)
                 && (sCMPriorSt1.PriorPriceSetCd4 == sCMPriorSt2.PriorPriceSetCd4)
                 && (sCMPriorSt1.PriorPriceSetNm4 == sCMPriorSt2.PriorPriceSetNm4)
                 && (sCMPriorSt1.PriorPriceSetCd5 == sCMPriorSt2.PriorPriceSetCd5)
                 && (sCMPriorSt1.PriorPriceSetNm5 == sCMPriorSt2.PriorPriceSetNm5)
                 && (sCMPriorSt1.PriorAppliDiv == sCMPriorSt2.PriorAppliDiv)
                 && (sCMPriorSt1.CustomerCode == sCMPriorSt2.CustomerCode)
                 && (sCMPriorSt1.SelTgtPureDiv == sCMPriorSt2.SelTgtPureDiv)
                 && (sCMPriorSt1.SelTgtStckDiv == sCMPriorSt2.SelTgtStckDiv)
                 && (sCMPriorSt1.SelTgtCampDiv == sCMPriorSt2.SelTgtCampDiv)
                 && (sCMPriorSt1.SelTgtPricDiv1 == sCMPriorSt2.SelTgtPricDiv1)
                 && (sCMPriorSt1.SelTgtPricDiv2 == sCMPriorSt2.SelTgtPricDiv2)
                 && (sCMPriorSt1.SelTgtPricDiv3 == sCMPriorSt2.SelTgtPricDiv3)
                 && (sCMPriorSt1.UnSelTgtPureDiv == sCMPriorSt2.UnSelTgtPureDiv)
                 && (sCMPriorSt1.UnSelTgtStckDiv == sCMPriorSt2.UnSelTgtStckDiv)
                 && (sCMPriorSt1.UnSelTgtCampDiv == sCMPriorSt2.UnSelTgtCampDiv)
                 && (sCMPriorSt1.UnSelTgtPricDiv1 == sCMPriorSt2.UnSelTgtPricDiv1)
                 && (sCMPriorSt1.UnSelTgtPricDiv2 == sCMPriorSt2.UnSelTgtPricDiv2)
                 && (sCMPriorSt1.UnSelTgtPricDiv3 == sCMPriorSt2.UnSelTgtPricDiv3)
                 && (sCMPriorSt1.EnterpriseName == sCMPriorSt2.EnterpriseName)
                 && (sCMPriorSt1.UpdEmployeeName == sCMPriorSt2.UpdEmployeeName));
        }
        /// <summary>
        /// SCM�D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SCMPriorSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SCMPriorSt target)
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
            if (this.PrioritySettingCd1 != target.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (this.PrioritySettingNm1 != target.PrioritySettingNm1) resList.Add("PrioritySettingNm1");
            if (this.PrioritySettingCd2 != target.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (this.PrioritySettingNm2 != target.PrioritySettingNm2) resList.Add("PrioritySettingNm2");
            if (this.PrioritySettingCd3 != target.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (this.PrioritySettingNm3 != target.PrioritySettingNm3) resList.Add("PrioritySettingNm3");
            if (this.PrioritySettingCd4 != target.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (this.PrioritySettingNm4 != target.PrioritySettingNm4) resList.Add("PrioritySettingNm4");
            if (this.PrioritySettingCd5 != target.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (this.PrioritySettingNm5 != target.PrioritySettingNm5) resList.Add("PrioritySettingNm5");
            if (this.PriorPriceSetCd1 != target.PriorPriceSetCd1) resList.Add("PriorPriceSetCd1");
            if (this.PriorPriceSetNm1 != target.PriorPriceSetNm1) resList.Add("PriorPriceSetNm1");
            if (this.PriorPriceSetCd2 != target.PriorPriceSetCd2) resList.Add("PriorPriceSetCd2");
            if (this.PriorPriceSetNm2 != target.PriorPriceSetNm2) resList.Add("PriorPriceSetNm2");
            if (this.PriorPriceSetCd3 != target.PriorPriceSetCd3) resList.Add("PriorPriceSetCd3");
            if (this.PriorPriceSetNm3 != target.PriorPriceSetNm3) resList.Add("PriorPriceSetNm3");
            if (this.PriorPriceSetCd4 != target.PriorPriceSetCd4) resList.Add("PriorPriceSetCd4");
            if (this.PriorPriceSetNm4 != target.PriorPriceSetNm4) resList.Add("PriorPriceSetNm4");
            if (this.PriorPriceSetCd5 != target.PriorPriceSetCd5) resList.Add("PriorPriceSetCd5");
            if (this.PriorPriceSetNm5 != target.PriorPriceSetNm5) resList.Add("PriorPriceSetNm5");
            if (this.PriorAppliDiv != target.PriorAppliDiv) resList.Add("PriorAppliDiv");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SelTgtPureDiv != target.SelTgtPureDiv) resList.Add("SelTgtPureDiv");
            if (this.SelTgtStckDiv != target.SelTgtStckDiv) resList.Add("SelTgtStckDiv");
            if (this.SelTgtCampDiv != target.SelTgtCampDiv) resList.Add("SelTgtCampDiv");
            if (this.SelTgtPricDiv1 != target.SelTgtPricDiv1) resList.Add("SelTgtPricDiv1");
            if (this.SelTgtPricDiv2 != target.SelTgtPricDiv2) resList.Add("SelTgtPricDiv2");
            if (this.SelTgtPricDiv3 != target.SelTgtPricDiv3) resList.Add("SelTgtPricDiv3");
            if (this.UnSelTgtPureDiv != target.UnSelTgtPureDiv) resList.Add("UnSelTgtPureDiv");
            if (this.UnSelTgtStckDiv != target.UnSelTgtStckDiv) resList.Add("UnSelTgtStckDiv");
            if (this.UnSelTgtCampDiv != target.UnSelTgtCampDiv) resList.Add("UnSelTgtCampDiv");
            if (this.UnSelTgtPricDiv1 != target.UnSelTgtPricDiv1) resList.Add("UnSelTgtPricDiv1");
            if (this.UnSelTgtPricDiv2 != target.UnSelTgtPricDiv2) resList.Add("UnSelTgtPricDiv2");
            if (this.UnSelTgtPricDiv3 != target.UnSelTgtPricDiv3) resList.Add("UnSelTgtPricDiv3");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// SCM�D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="sCMPriorSt1">��r����SCMPriorSt�N���X�̃C���X�^���X</param>
        /// <param name="sCMPriorSt2">��r����SCMPriorSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SCMPriorSt sCMPriorSt1, SCMPriorSt sCMPriorSt2)
        {
            ArrayList resList = new ArrayList();
            if (sCMPriorSt1.CreateDateTime != sCMPriorSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (sCMPriorSt1.UpdateDateTime != sCMPriorSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sCMPriorSt1.EnterpriseCode != sCMPriorSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sCMPriorSt1.FileHeaderGuid != sCMPriorSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sCMPriorSt1.UpdEmployeeCode != sCMPriorSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sCMPriorSt1.UpdAssemblyId1 != sCMPriorSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sCMPriorSt1.UpdAssemblyId2 != sCMPriorSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sCMPriorSt1.LogicalDeleteCode != sCMPriorSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sCMPriorSt1.SectionCode != sCMPriorSt2.SectionCode) resList.Add("SectionCode");
            if (sCMPriorSt1.PrioritySettingCd1 != sCMPriorSt2.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (sCMPriorSt1.PrioritySettingNm1 != sCMPriorSt2.PrioritySettingNm1) resList.Add("PrioritySettingNm1");
            if (sCMPriorSt1.PrioritySettingCd2 != sCMPriorSt2.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (sCMPriorSt1.PrioritySettingNm2 != sCMPriorSt2.PrioritySettingNm2) resList.Add("PrioritySettingNm2");
            if (sCMPriorSt1.PrioritySettingCd3 != sCMPriorSt2.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (sCMPriorSt1.PrioritySettingNm3 != sCMPriorSt2.PrioritySettingNm3) resList.Add("PrioritySettingNm3");
            if (sCMPriorSt1.PrioritySettingCd4 != sCMPriorSt2.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (sCMPriorSt1.PrioritySettingNm4 != sCMPriorSt2.PrioritySettingNm4) resList.Add("PrioritySettingNm4");
            if (sCMPriorSt1.PrioritySettingCd5 != sCMPriorSt2.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (sCMPriorSt1.PrioritySettingNm5 != sCMPriorSt2.PrioritySettingNm5) resList.Add("PrioritySettingNm5");
            if (sCMPriorSt1.PriorPriceSetCd1 != sCMPriorSt2.PriorPriceSetCd1) resList.Add("PriorPriceSetCd1");
            if (sCMPriorSt1.PriorPriceSetNm1 != sCMPriorSt2.PriorPriceSetNm1) resList.Add("PriorPriceSetNm1");
            if (sCMPriorSt1.PriorPriceSetCd2 != sCMPriorSt2.PriorPriceSetCd2) resList.Add("PriorPriceSetCd2");
            if (sCMPriorSt1.PriorPriceSetNm2 != sCMPriorSt2.PriorPriceSetNm2) resList.Add("PriorPriceSetNm2");
            if (sCMPriorSt1.PriorPriceSetCd3 != sCMPriorSt2.PriorPriceSetCd3) resList.Add("PriorPriceSetCd3");
            if (sCMPriorSt1.PriorPriceSetNm3 != sCMPriorSt2.PriorPriceSetNm3) resList.Add("PriorPriceSetNm3");
            if (sCMPriorSt1.PriorPriceSetCd4 != sCMPriorSt2.PriorPriceSetCd4) resList.Add("PriorPriceSetCd4");
            if (sCMPriorSt1.PriorPriceSetNm4 != sCMPriorSt2.PriorPriceSetNm4) resList.Add("PriorPriceSetNm4");
            if (sCMPriorSt1.PriorPriceSetCd5 != sCMPriorSt2.PriorPriceSetCd5) resList.Add("PriorPriceSetCd5");
            if (sCMPriorSt1.PriorPriceSetNm5 != sCMPriorSt2.PriorPriceSetNm5) resList.Add("PriorPriceSetNm5");
            if (sCMPriorSt1.PriorAppliDiv != sCMPriorSt2.PriorAppliDiv) resList.Add("PriorAppliDiv");
            if (sCMPriorSt1.CustomerCode != sCMPriorSt2.CustomerCode) resList.Add("CustomerCode");
            if (sCMPriorSt1.SelTgtPureDiv != sCMPriorSt2.SelTgtPureDiv) resList.Add("SelTgtPureDiv");
            if (sCMPriorSt1.SelTgtStckDiv != sCMPriorSt2.SelTgtStckDiv) resList.Add("SelTgtStckDiv");
            if (sCMPriorSt1.SelTgtCampDiv != sCMPriorSt2.SelTgtCampDiv) resList.Add("SelTgtCampDiv");
            if (sCMPriorSt1.SelTgtPricDiv1 != sCMPriorSt2.SelTgtPricDiv1) resList.Add("SelTgtPricDiv1");
            if (sCMPriorSt1.SelTgtPricDiv2 != sCMPriorSt2.SelTgtPricDiv2) resList.Add("SelTgtPricDiv2");
            if (sCMPriorSt1.SelTgtPricDiv3 != sCMPriorSt2.SelTgtPricDiv3) resList.Add("SelTgtPricDiv3");
            if (sCMPriorSt1.UnSelTgtPureDiv != sCMPriorSt2.UnSelTgtPureDiv) resList.Add("UnSelTgtPureDiv");
            if (sCMPriorSt1.UnSelTgtStckDiv != sCMPriorSt2.UnSelTgtStckDiv) resList.Add("UnSelTgtStckDiv");
            if (sCMPriorSt1.UnSelTgtCampDiv != sCMPriorSt2.UnSelTgtCampDiv) resList.Add("UnSelTgtCampDiv");
            if (sCMPriorSt1.UnSelTgtPricDiv1 != sCMPriorSt2.UnSelTgtPricDiv1) resList.Add("UnSelTgtPricDiv1");
            if (sCMPriorSt1.UnSelTgtPricDiv2 != sCMPriorSt2.UnSelTgtPricDiv2) resList.Add("UnSelTgtPricDiv2");
            if (sCMPriorSt1.UnSelTgtPricDiv3 != sCMPriorSt2.UnSelTgtPricDiv3) resList.Add("UnSelTgtPricDiv3");
            if (sCMPriorSt1.EnterpriseName != sCMPriorSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (sCMPriorSt1.UpdEmployeeName != sCMPriorSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}