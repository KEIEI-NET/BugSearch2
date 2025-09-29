using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMPriorStWork
    /// <summary>
    ///                      SCM�D��ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�D��ݒ胏�[�N�w�b�_�t�@�C��</br>
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
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMPriorStWork : IFileHeader
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

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬����</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V����</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h</summary>
        /// <value>00�͑S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  PrioritySettingCd1
        /// <summary>�D��ݒ�R�[�h�P</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�P</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd1
        {
            get { return _prioritySettingCd1; }
            set { _prioritySettingCd1 = value; }
        }

        /// public propaty name  :  PrioritySettingNm1
        /// <summary>�D��ݒ薼�̂P</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂P</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm1
        {
            get { return _prioritySettingNm1; }
            set { _prioritySettingNm1 = value; }
        }

        /// public propaty name  :  PrioritySettingCd2
        /// <summary>�D��ݒ�R�[�h�Q</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�Q</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd2
        {
            get { return _prioritySettingCd2; }
            set { _prioritySettingCd2 = value; }
        }

        /// public propaty name  :  PrioritySettingNm2
        /// <summary>�D��ݒ薼�̂Q</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂Q</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm2
        {
            get { return _prioritySettingNm2; }
            set { _prioritySettingNm2 = value; }
        }

        /// public propaty name  :  PrioritySettingCd3
        /// <summary>�D��ݒ�R�[�h�R</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�R</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd3
        {
            get { return _prioritySettingCd3; }
            set { _prioritySettingCd3 = value; }
        }

        /// public propaty name  :  PrioritySettingNm3
        /// <summary>�D��ݒ薼�̂R</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂R</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm3
        {
            get { return _prioritySettingNm3; }
            set { _prioritySettingNm3 = value; }
        }

        /// public propaty name  :  PrioritySettingCd4
        /// <summary>�D��ݒ�R�[�h�S</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�S</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd4
        {
            get { return _prioritySettingCd4; }
            set { _prioritySettingCd4 = value; }
        }

        /// public propaty name  :  PrioritySettingNm4
        /// <summary>�D��ݒ薼�̂S</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂S</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm4
        {
            get { return _prioritySettingNm4; }
            set { _prioritySettingNm4 = value; }
        }

        /// public propaty name  :  PrioritySettingCd5
        /// <summary>�D��ݒ�R�[�h�T</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�T</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd5
        {
            get { return _prioritySettingCd5; }
            set { _prioritySettingCd5 = value; }
        }

        /// public propaty name  :  PrioritySettingNm5
        /// <summary>�D��ݒ薼�̂T</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ薼�̂T</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrioritySettingNm5
        {
            get { return _prioritySettingNm5; }
            set { _prioritySettingNm5 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd1
        /// <summary>�D�承�i�ݒ�R�[�h�P</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�P</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd1
        {
            get { return _priorPriceSetCd1; }
            set { _priorPriceSetCd1 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm1
        /// <summary>�D�承�i�ݒ薼�̂P</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂P</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm1
        {
            get { return _priorPriceSetNm1; }
            set { _priorPriceSetNm1 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd2
        /// <summary>�D�承�i�ݒ�R�[�h�Q</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�Q</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd2
        {
            get { return _priorPriceSetCd2; }
            set { _priorPriceSetCd2 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm2
        /// <summary>�D�承�i�ݒ薼�̂Q</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂Q</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm2
        {
            get { return _priorPriceSetNm2; }
            set { _priorPriceSetNm2 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd3
        /// <summary>�D�承�i�ݒ�R�[�h�R</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�R</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd3
        {
            get { return _priorPriceSetCd3; }
            set { _priorPriceSetCd3 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm3
        /// <summary>�D�承�i�ݒ薼�̂R</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂R</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm3
        {
            get { return _priorPriceSetNm3; }
            set { _priorPriceSetNm3 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd4
        /// <summary>�D�承�i�ݒ�R�[�h�S</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�S</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd4
        {
            get { return _priorPriceSetCd4; }
            set { _priorPriceSetCd4 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm4
        /// <summary>�D�承�i�ݒ薼�̂S</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂S</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm4
        {
            get { return _priorPriceSetNm4; }
            set { _priorPriceSetNm4 = value; }
        }

        /// public propaty name  :  PriorPriceSetCd5
        /// <summary>�D�承�i�ݒ�R�[�h�T</summary>
        /// <value>0:�Ȃ�1:�e����,2:�P��,3:�艿(��),4:�艿(��),5:�L�����y�[��,6:�݌�,7:�ϑ�,8:�D��q��,9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ�R�[�h�T</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorPriceSetCd5
        {
            get { return _priorPriceSetCd5; }
            set { _priorPriceSetCd5 = value; }
        }

        /// public propaty name  :  PriorPriceSetNm5
        /// <summary>�D�承�i�ݒ薼�̂T</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�承�i�ݒ薼�̂T</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriorPriceSetNm5
        {
            get { return _priorPriceSetNm5; }
            set { _priorPriceSetNm5 = value; }
        }

        /// public propaty name  :  PriorAppliDiv
        /// <summary>�D��K�p�敪</summary>
        /// <value>0:����, 1:PCC, 2:PCCUOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��K�p�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriorAppliDiv
        {
            get { return _priorAppliDiv; }
            set { _priorAppliDiv = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SelTgtPureDiv
        /// <summary>�I�����Ώۏ��D�敪</summary>
        /// <value>0:�S��, 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۏ��D�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPureDiv
        {
            get { return _selTgtPureDiv; }
            set { _selTgtPureDiv = value; }
        }

        /// public propaty name  :  SelTgtStckDiv
        /// <summary>�I�����Ώۍ݌ɋ敪</summary>
        /// <value>0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۍ݌ɋ敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtStckDiv
        {
            get { return _selTgtStckDiv; }
            set { _selTgtStckDiv = value; }
        }

        /// public propaty name  :  SelTgtCampDiv
        /// <summary>�I�����ΏۃL�����y�[���敪</summary>
        /// <value>0:�S��, 1:�L�����y�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����ΏۃL�����y�[���敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtCampDiv
        {
            get { return _selTgtCampDiv; }
            set { _selTgtCampDiv = value; }
        }

        /// public propaty name  :  SelTgtPricDiv1
        /// <summary>�I�����Ώۉ��i�敪�P</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۉ��i�敪�P</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPricDiv1
        {
            get { return _selTgtPricDiv1; }
            set { _selTgtPricDiv1 = value; }
        }

        /// public propaty name  :  SelTgtPricDiv2
        /// <summary>�I�����Ώۉ��i�敪�Q</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۉ��i�敪�Q</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPricDiv2
        {
            get { return _selTgtPricDiv2; }
            set { _selTgtPricDiv2 = value; }
        }

        /// public propaty name  :  SelTgtPricDiv3
        /// <summary>�I�����Ώۉ��i�敪�R</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ώۉ��i�敪�R</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SelTgtPricDiv3
        {
            get { return _selTgtPricDiv3; }
            set { _selTgtPricDiv3 = value; }
        }

        /// public propaty name  :  UnSelTgtPureDiv
        /// <summary>��I�����Ώۏ��D�敪</summary>
        /// <value>0:�S��, 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۏ��D�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPureDiv
        {
            get { return _unSelTgtPureDiv; }
            set { _unSelTgtPureDiv = value; }
        }

        /// public propaty name  :  UnSelTgtStckDiv
        /// <summary>��I�����Ώۍ݌ɋ敪</summary>
        /// <value>0:�S��, 1:�݌�, 2:�ϑ��E�D��q��, 3:�ϑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۍ݌ɋ敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtStckDiv
        {
            get { return _unSelTgtStckDiv; }
            set { _unSelTgtStckDiv = value; }
        }

        /// public propaty name  :  UnSelTgtCampDiv
        /// <summary>��I�����ΏۃL�����y�[���敪</summary>
        /// <value>0:�S��, 1:�L�����y�[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����ΏۃL�����y�[���敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtCampDiv
        {
            get { return _unSelTgtCampDiv; }
            set { _unSelTgtCampDiv = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv1
        /// <summary>��I�����Ώۉ��i�敪�P</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۉ��i�敪�P</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv1
        {
            get { return _unSelTgtPricDiv1; }
            set { _unSelTgtPricDiv1 = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv2
        /// <summary>��I�����Ώۉ��i�敪�Q</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۉ��i�敪�Q</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv2
        {
            get { return _unSelTgtPricDiv2; }
            set { _unSelTgtPricDiv2 = value; }
        }

        /// public propaty name  :  UnSelTgtPricDiv3
        /// <summary>��I�����Ώۉ��i�敪�R</summary>
        /// <value>0:�Ȃ�, 1:�e����(��), 2:�P��(��), 3:�艿(��), 4:�艿(��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��I�����Ώۉ��i�敪�R</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UnSelTgtPricDiv3
        {
            get { return _unSelTgtPricDiv3; }
            set { _unSelTgtPricDiv3 = value; }
        }



        /// <summary>
        /// SCM�D��ݒ�}�X�^�����e���o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMPriorStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMPriorStWork()
        {
        }

    }

    /// <summary>
    ///  Ver8.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMPriorStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMPriorStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMPriorStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver8.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMPriorStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMPriorStWork || graph is ArrayList || graph is SCMPriorStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMPriorStWork).FullName));

            if (graph != null && graph is SCMPriorStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMPriorStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMPriorStWork[])graph).Length;
            }
            else if (graph is SCMPriorStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[])); //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�D��ݒ�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd1
            //�D��ݒ薼�̂P
            serInfo.MemberInfo.Add(typeof(string)); //PrioritySettingNm1
            //�D��ݒ�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd2
            //�D��ݒ薼�̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PrioritySettingNm2
            //�D��ݒ�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd3
            //�D��ݒ薼�̂R
            serInfo.MemberInfo.Add(typeof(string)); //PrioritySettingNm3
            //�D��ݒ�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd4
            //�D��ݒ薼�̂S
            serInfo.MemberInfo.Add(typeof(string)); //PrioritySettingNm4
            //�D��ݒ�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //PrioritySettingCd5
            //�D��ݒ薼�̂T
            serInfo.MemberInfo.Add(typeof(string)); //PrioritySettingNm5
            //�D�承�i�ݒ�R�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //PriorPriceSetCd1
            //�D�承�i�ݒ薼�̂P
            serInfo.MemberInfo.Add(typeof(string)); //PriorPriceSetNm1
            //�D�承�i�ݒ�R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //PriorPriceSetCd2
            //�D�承�i�ݒ薼�̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PriorPriceSetNm2
            //�D�承�i�ݒ�R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //PriorPriceSetCd3
            //�D�承�i�ݒ薼�̂R
            serInfo.MemberInfo.Add(typeof(string)); //PriorPriceSetNm3
            //�D�承�i�ݒ�R�[�h�S
            serInfo.MemberInfo.Add(typeof(Int32)); //PriorPriceSetCd4
            //�D�承�i�ݒ薼�̂S
            serInfo.MemberInfo.Add(typeof(string)); //PriorPriceSetNm4
            //�D�承�i�ݒ�R�[�h�T
            serInfo.MemberInfo.Add(typeof(Int32)); //PriorPriceSetCd5
            //�D�承�i�ݒ薼�̂T
            serInfo.MemberInfo.Add(typeof(string)); //PriorPriceSetNm5
            //�D��K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriorAppliDiv
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�I�����Ώۏ��D�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SelTgtPureDiv
            //�I�����Ώۍ݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SelTgtStckDiv
            //�I�����ΏۃL�����y�[���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SelTgtCampDiv
            //�I�����Ώۉ��i�敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //SelTgtPricDiv1
            //�I�����Ώۉ��i�敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //SelTgtPricDiv2
            //�I�����Ώۉ��i�敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //SelTgtPricDiv3
            //��I�����Ώۏ��D�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnSelTgtPureDiv
            //��I�����Ώۍ݌ɋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnSelTgtStckDiv
            //��I�����ΏۃL�����y�[���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnSelTgtCampDiv
            //��I�����Ώۉ��i�敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //UnSelTgtPricDiv1
            //��I�����Ώۉ��i�敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //UnSelTgtPricDiv2
            //��I�����Ώۉ��i�敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //UnSelTgtPricDiv3



            serInfo.Serialize(writer, serInfo);
            if (graph is SCMPriorStWork)
            {
                SCMPriorStWork temp = (SCMPriorStWork)graph;

                SetSCMPriorStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMPriorStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMPriorStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMPriorStWork temp in lst)
                {
                    SetSCMPriorStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMPriorStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 43;

        /// <summary>
        ///  SCMPriorStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMPriorStWork(System.IO.BinaryWriter writer, SCMPriorStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write((Int32)temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�D��ݒ�R�[�h�P
            writer.Write((Int32)temp.PrioritySettingCd1);
            //�D��ݒ薼�̂P
            writer.Write(temp.PrioritySettingNm1);
            //�D��ݒ�R�[�h�Q
            writer.Write((Int32)temp.PrioritySettingCd2);
            //�D��ݒ薼�̂Q
            writer.Write(temp.PrioritySettingNm2);
            //�D��ݒ�R�[�h�R
            writer.Write((Int32)temp.PrioritySettingCd3);
            //�D��ݒ薼�̂R
            writer.Write(temp.PrioritySettingNm3);
            //�D��ݒ�R�[�h�S
            writer.Write((Int32)temp.PrioritySettingCd4);
            //�D��ݒ薼�̂S
            writer.Write(temp.PrioritySettingNm4);
            //�D��ݒ�R�[�h�T
            writer.Write((Int32)temp.PrioritySettingCd5);
            //�D��ݒ薼�̂T
            writer.Write(temp.PrioritySettingNm5);
            //�D�承�i�ݒ�R�[�h�P
            writer.Write((Int32)temp.PriorPriceSetCd1);
            //�D�承�i�ݒ薼�̂P
            writer.Write(temp.PriorPriceSetNm1);
            //�D�承�i�ݒ�R�[�h�Q
            writer.Write((Int32)temp.PriorPriceSetCd2);
            //�D�承�i�ݒ薼�̂Q
            writer.Write(temp.PriorPriceSetNm2);
            //�D�承�i�ݒ�R�[�h�R
            writer.Write((Int32)temp.PriorPriceSetCd3);
            //�D�承�i�ݒ薼�̂R
            writer.Write(temp.PriorPriceSetNm3);
            //�D�承�i�ݒ�R�[�h�S
            writer.Write((Int32)temp.PriorPriceSetCd4);
            //�D�承�i�ݒ薼�̂S
            writer.Write(temp.PriorPriceSetNm4);
            //�D�承�i�ݒ�R�[�h�T
            writer.Write((Int32)temp.PriorPriceSetCd5);
            //�D�承�i�ݒ薼�̂T
            writer.Write(temp.PriorPriceSetNm5);
            //�D��K�p�敪
            writer.Write((Int32)temp.PriorAppliDiv);
            //���Ӑ�R�[�h
            writer.Write((Int32)temp.CustomerCode);
            //�I�����Ώۏ��D�敪
            writer.Write((Int32)temp.SelTgtPureDiv);
            //�I�����Ώۍ݌ɋ敪
            writer.Write((Int32)temp.SelTgtStckDiv);
            //�I�����ΏۃL�����y�[���敪
            writer.Write((Int32)temp.SelTgtCampDiv);
            //�I�����Ώۉ��i�敪�P
            writer.Write((Int32)temp.SelTgtPricDiv1);
            //�I�����Ώۉ��i�敪�Q
            writer.Write((Int32)temp.SelTgtPricDiv2);
            //�I�����Ώۉ��i�敪�R
            writer.Write((Int32)temp.SelTgtPricDiv3);
            //��I�����Ώۏ��D�敪
            writer.Write((Int32)temp.UnSelTgtPureDiv);
            //��I�����Ώۍ݌ɋ敪
            writer.Write((Int32)temp.UnSelTgtStckDiv);
            //��I�����ΏۃL�����y�[���敪
            writer.Write((Int32)temp.UnSelTgtCampDiv);
            //��I�����Ώۉ��i�敪�P
            writer.Write((Int32)temp.UnSelTgtPricDiv1);
            //��I�����Ώۉ��i�敪�Q
            writer.Write((Int32)temp.UnSelTgtPricDiv2);
            //��I�����Ώۉ��i�敪�R
            writer.Write((Int32)temp.UnSelTgtPricDiv3);


        }

        /// <summary>
        ///  SCMPriorStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMPriorStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMPriorStWork GetSCMPriorStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMPriorStWork temp = new SCMPriorStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�D��ݒ�R�[�h�P
            temp.PrioritySettingCd1 = reader.ReadInt32();
            //�D��ݒ薼�̂P
            temp.PrioritySettingNm1 = reader.ReadString();
            //�D��ݒ�R�[�h�Q
            temp.PrioritySettingCd2 = reader.ReadInt32();
            //�D��ݒ薼�̂Q
            temp.PrioritySettingNm2 = reader.ReadString();
            //�D��ݒ�R�[�h�R
            temp.PrioritySettingCd3 = reader.ReadInt32();
            //�D��ݒ薼�̂R
            temp.PrioritySettingNm3 = reader.ReadString();
            //�D��ݒ�R�[�h�S
            temp.PrioritySettingCd4 = reader.ReadInt32();
            //�D��ݒ薼�̂S
            temp.PrioritySettingNm4 = reader.ReadString();
            //�D��ݒ�R�[�h�T
            temp.PrioritySettingCd5 = reader.ReadInt32();
            //�D��ݒ薼�̂T
            temp.PrioritySettingNm5 = reader.ReadString();
            //�D�承�i�ݒ�R�[�h�P
            temp.PriorPriceSetCd1 = reader.ReadInt32();
            //�D�承�i�ݒ薼�̂P
            temp.PriorPriceSetNm1 = reader.ReadString();
            //�D�承�i�ݒ�R�[�h�Q
            temp.PriorPriceSetCd2 = reader.ReadInt32();
            //�D�承�i�ݒ薼�̂Q
            temp.PriorPriceSetNm2 = reader.ReadString();
            //�D�承�i�ݒ�R�[�h�R
            temp.PriorPriceSetCd3 = reader.ReadInt32();
            //�D�承�i�ݒ薼�̂R
            temp.PriorPriceSetNm3 = reader.ReadString();
            //�D�承�i�ݒ�R�[�h�S
            temp.PriorPriceSetCd4 = reader.ReadInt32();
            //�D�承�i�ݒ薼�̂S
            temp.PriorPriceSetNm4 = reader.ReadString();
            //�D�承�i�ݒ�R�[�h�T
            temp.PriorPriceSetCd5 = reader.ReadInt32();
            //�D�承�i�ݒ薼�̂T
            temp.PriorPriceSetNm5 = reader.ReadString();
            //�D��K�p�敪
            temp.PriorAppliDiv = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�I�����Ώۏ��D�敪
            temp.SelTgtPureDiv = reader.ReadInt32();
            //�I�����Ώۍ݌ɋ敪
            temp.SelTgtStckDiv = reader.ReadInt32();
            //�I�����ΏۃL�����y�[���敪
            temp.SelTgtCampDiv = reader.ReadInt32();
            //�I�����Ώۉ��i�敪�P
            temp.SelTgtPricDiv1 = reader.ReadInt32();
            //�I�����Ώۉ��i�敪�Q
            temp.SelTgtPricDiv2 = reader.ReadInt32();
            //�I�����Ώۉ��i�敪�R
            temp.SelTgtPricDiv3 = reader.ReadInt32();
            //��I�����Ώۏ��D�敪
            temp.UnSelTgtPureDiv = reader.ReadInt32();
            //��I�����Ώۍ݌ɋ敪
            temp.UnSelTgtStckDiv = reader.ReadInt32();
            //��I�����ΏۃL�����y�[���敪
            temp.UnSelTgtCampDiv = reader.ReadInt32();
            //��I�����Ώۉ��i�敪�P
            temp.UnSelTgtPricDiv1 = reader.ReadInt32();
            //��I�����Ώۉ��i�敪�Q
            temp.UnSelTgtPricDiv2 = reader.ReadInt32();
            //��I�����Ώۉ��i�敪�R
            temp.UnSelTgtPricDiv3 = reader.ReadInt32();



            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver8.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SCMPriorStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMPriorStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMPriorStWork temp = GetSCMPriorStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMPriorStWork[])lst.ToArray(typeof(SCMPriorStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}