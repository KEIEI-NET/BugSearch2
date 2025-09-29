//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e������o���ʃ��[�N
// �v���O�����T�v   : BL�R�[�h�ϊ��擾�ݒ�}�X�^�����e������o���ʃ��[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2012/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BLGoodsCdChgUWork
    /// <summary>
    ///                      BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2012/7/25</br>
    /// <br>Genarated Date   :   2012/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BLGoodsCdChgUWork : IFileHeader
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

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>PM��BL���i�R�[�h</summary>
        private Int32 _pMBLGoodsCode;

        /// <summary>PM��BL���i�R�[�h�}��</summary>
        private Int32 _pMBLGoodsCodeDerivNo;

        /// <summary>SF��BL���i�R�[�h</summary>
        private Int32 _sFBLGoodsCode;

        /// <summary>SF��BL���i�R�[�h�}��</summary>
        private Int32 _sFBLGoodsCodeDerivNo;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";


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

        /// public propaty name  :  PMBLGoodsCode
        /// <summary>PM��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMBLGoodsCode
        {
            get { return _pMBLGoodsCode; }
            set { _pMBLGoodsCode = value; }
        }

        /// public propaty name  :  PMBLGoodsCodeDerivNo
        /// <summary>PM��BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMBLGoodsCodeDerivNo
        {
            get { return _pMBLGoodsCodeDerivNo; }
            set { _pMBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  SFBLGoodsCode
        /// <summary>SF��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SFBLGoodsCode
        {
            get { return _sFBLGoodsCode; }
            set { _sFBLGoodsCode = value; }
        }

        /// public propaty name  :  SFBLGoodsCodeDerivNo
        /// <summary>SF��BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF��BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SFBLGoodsCodeDerivNo
        {
            get { return _sFBLGoodsCodeDerivNo; }
            set { _sFBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }


        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>BLGoodsCdChgUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdChgUWork()
        {
        }

        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N�R���X�g���N�^
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
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="pMBLGoodsCode">PM��BL���i�R�[�h</param>
        /// <param name="pMBLGoodsCodeDerivNo">PM��BL���i�R�[�h�}��</param>
        /// <param name="sFBLGoodsCode">SF��BL���i�R�[�h</param>
        /// <param name="sFBLGoodsCodeDerivNo">SF��BL���i�R�[�h�}��</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="bLGoodsHalfName">BL���i�R�[�h���́i���p�j</param>
        /// <returns>BLGoodsCdChgUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdChgUWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 pMBLGoodsCode, Int32 pMBLGoodsCodeDerivNo, Int32 sFBLGoodsCode, Int32 sFBLGoodsCodeDerivNo, string bLGoodsFullName, string bLGoodsHalfName)
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
            this._customerCode = customerCode;
            this._pMBLGoodsCode = pMBLGoodsCode;
            this._pMBLGoodsCodeDerivNo = pMBLGoodsCodeDerivNo;
            this._sFBLGoodsCode = sFBLGoodsCode;
            this._sFBLGoodsCodeDerivNo = sFBLGoodsCodeDerivNo;
            this._bLGoodsFullName = bLGoodsFullName;
            this._bLGoodsHalfName = bLGoodsHalfName;

        }

        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N��������
        /// </summary>
        /// <returns>BLGoodsCdChgUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BLGoodsCdChgUWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdChgUWork Clone()
        {
            return new BLGoodsCdChgUWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._pMBLGoodsCode, this._pMBLGoodsCodeDerivNo, this._sFBLGoodsCode, this._sFBLGoodsCodeDerivNo, this._bLGoodsFullName, this._bLGoodsHalfName);
        }

        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BLGoodsCdChgUWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(BLGoodsCdChgUWork target)
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
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PMBLGoodsCode == target.PMBLGoodsCode)
                 && (this.PMBLGoodsCodeDerivNo == target.PMBLGoodsCodeDerivNo)
                 && (this.SFBLGoodsCode == target.SFBLGoodsCode)
                 && (this.SFBLGoodsCodeDerivNo == target.SFBLGoodsCodeDerivNo)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName));
        }

        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N��r����
        /// </summary>
        /// <param name="bLGoodsCdChgU1">
        ///                    ��r����BLGoodsCdChgUWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="bLGoodsCdChgU2">��r����BLGoodsCdChgUWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(BLGoodsCdChgUWork bLGoodsCdChgU1, BLGoodsCdChgUWork bLGoodsCdChgU2)
        {
            return ((bLGoodsCdChgU1.CreateDateTime == bLGoodsCdChgU2.CreateDateTime)
                 && (bLGoodsCdChgU1.UpdateDateTime == bLGoodsCdChgU2.UpdateDateTime)
                 && (bLGoodsCdChgU1.EnterpriseCode == bLGoodsCdChgU2.EnterpriseCode)
                 && (bLGoodsCdChgU1.FileHeaderGuid == bLGoodsCdChgU2.FileHeaderGuid)
                 && (bLGoodsCdChgU1.UpdEmployeeCode == bLGoodsCdChgU2.UpdEmployeeCode)
                 && (bLGoodsCdChgU1.UpdAssemblyId1 == bLGoodsCdChgU2.UpdAssemblyId1)
                 && (bLGoodsCdChgU1.UpdAssemblyId2 == bLGoodsCdChgU2.UpdAssemblyId2)
                 && (bLGoodsCdChgU1.LogicalDeleteCode == bLGoodsCdChgU2.LogicalDeleteCode)
                 && (bLGoodsCdChgU1.SectionCode == bLGoodsCdChgU2.SectionCode)
                 && (bLGoodsCdChgU1.CustomerCode == bLGoodsCdChgU2.CustomerCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCode == bLGoodsCdChgU2.PMBLGoodsCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo == bLGoodsCdChgU2.PMBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.SFBLGoodsCode == bLGoodsCdChgU2.SFBLGoodsCode)
                 && (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo == bLGoodsCdChgU2.SFBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.BLGoodsFullName == bLGoodsCdChgU2.BLGoodsFullName)
                 && (bLGoodsCdChgU1.BLGoodsHalfName == bLGoodsCdChgU2.BLGoodsHalfName));
        }
        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BLGoodsCdChgUWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(BLGoodsCdChgUWork target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PMBLGoodsCode != target.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (this.PMBLGoodsCodeDerivNo != target.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (this.SFBLGoodsCode != target.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (this.SFBLGoodsCodeDerivNo != target.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");

            return resList;
        }

        /// <summary>
        /// BL�R�[�h�ϊ��i���[�U�[�o�^�j���[�N��r����
        /// </summary>
        /// <param name="bLGoodsCdChgU1">��r����BLGoodsCdChgUWork�N���X�̃C���X�^���X</param>
        /// <param name="bLGoodsCdChgU2">��r����BLGoodsCdChgUWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(BLGoodsCdChgUWork bLGoodsCdChgU1, BLGoodsCdChgUWork bLGoodsCdChgU2)
        {
            ArrayList resList = new ArrayList();
            if (bLGoodsCdChgU1.CreateDateTime != bLGoodsCdChgU2.CreateDateTime) resList.Add("CreateDateTime");
            if (bLGoodsCdChgU1.UpdateDateTime != bLGoodsCdChgU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (bLGoodsCdChgU1.EnterpriseCode != bLGoodsCdChgU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (bLGoodsCdChgU1.FileHeaderGuid != bLGoodsCdChgU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (bLGoodsCdChgU1.UpdEmployeeCode != bLGoodsCdChgU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (bLGoodsCdChgU1.UpdAssemblyId1 != bLGoodsCdChgU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (bLGoodsCdChgU1.UpdAssemblyId2 != bLGoodsCdChgU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (bLGoodsCdChgU1.LogicalDeleteCode != bLGoodsCdChgU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (bLGoodsCdChgU1.SectionCode != bLGoodsCdChgU2.SectionCode) resList.Add("SectionCode");
            if (bLGoodsCdChgU1.CustomerCode != bLGoodsCdChgU2.CustomerCode) resList.Add("CustomerCode");
            if (bLGoodsCdChgU1.PMBLGoodsCode != bLGoodsCdChgU2.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo != bLGoodsCdChgU2.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.SFBLGoodsCode != bLGoodsCdChgU2.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo != bLGoodsCdChgU2.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.BLGoodsFullName != bLGoodsCdChgU2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (bLGoodsCdChgU1.BLGoodsHalfName != bLGoodsCdChgU2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");

            return resList;
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>BLGoodsCdChgUWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class BLGoodsCdChgUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BLGoodsCdChgUWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BLGoodsCdChgUWork || graph is ArrayList || graph is BLGoodsCdChgUWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(BLGoodsCdChgUWork).FullName));

            if (graph != null && graph is BLGoodsCdChgUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BLGoodsCdChgUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BLGoodsCdChgUWork[])graph).Length;
            }
            else if (graph is BLGoodsCdChgUWork)
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
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
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
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //PM��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PMBLGoodsCode
            //PM��BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //PMBLGoodsCodeDerivNo
            //SF��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SFBLGoodsCode
            //SF��BL���i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //SFBLGoodsCodeDerivNo
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is BLGoodsCdChgUWork)
            {
                BLGoodsCdChgUWork temp = (BLGoodsCdChgUWork)graph;

                SetBLGoodsCdChgUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BLGoodsCdChgUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BLGoodsCdChgUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BLGoodsCdChgUWork temp in lst)
                {
                    SetBLGoodsCdChgUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BLGoodsCdChgUWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  BLGoodsCdChgUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetBLGoodsCdChgUWork(System.IO.BinaryWriter writer, BLGoodsCdChgUWork temp)
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
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //PM��BL���i�R�[�h
            writer.Write(temp.PMBLGoodsCode);
            //PM��BL���i�R�[�h�}��
            writer.Write(temp.PMBLGoodsCodeDerivNo);
            //SF��BL���i�R�[�h
            writer.Write(temp.SFBLGoodsCode);
            //SF��BL���i�R�[�h�}��
            writer.Write(temp.SFBLGoodsCodeDerivNo);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);

        }

        /// <summary>
        ///  BLGoodsCdChgUWork�C���X�^���X�擾
        /// </summary>
        /// <returns>BLGoodsCdChgUWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private BLGoodsCdChgUWork GetBLGoodsCdChgUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            BLGoodsCdChgUWork temp = new BLGoodsCdChgUWork();

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
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //PM��BL���i�R�[�h
            temp.PMBLGoodsCode = reader.ReadInt32();
            //PM��BL���i�R�[�h�}��
            temp.PMBLGoodsCodeDerivNo = reader.ReadInt32();
            //SF��BL���i�R�[�h
            temp.SFBLGoodsCode = reader.ReadInt32();
            //SF��BL���i�R�[�h�}��
            temp.SFBLGoodsCodeDerivNo = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();


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
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>BLGoodsCdChgUWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgUWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BLGoodsCdChgUWork temp = GetBLGoodsCdChgUWork(reader, serInfo);
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
                    retValue = (BLGoodsCdChgUWork[])lst.ToArray(typeof(BLGoodsCdChgUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
