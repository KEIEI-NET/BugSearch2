//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�f�[�^���[�N
// �v���O�����T�v   : ���i�f�[�^���[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/06/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : ���O
// �� �� ��  2017/08/02  �C�����e : �n���f�B�^�[�~�i���񎟊J���̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInspectDataWork
    /// <summary>
    ///                      ���i�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/06/30</br>
    /// <br>Genarated Date   :   2017/06/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   ���O</br>
    /// <br>Date             :   2017/08/02</br>
    /// <br>�Ǘ��ԍ�         :   11370074-00</br>
    /// <br>                 : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyInspectDataWork : IFileHeader
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

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ݏo,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>�󕥌��`�[�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</remarks>
        private string _acPaySlipNum = "";

        /// <summary>�󕥌��s�ԍ�</summary>
        /// <remarks>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</remarks>
        private Int32 _acPaySlipRowNo;

        /// <summary>�󕥌�����敪</summary>
        /// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</remarks>
        private Int32 _acPayTransCd;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�݌ɊǗ��Ȃ���"0"</remarks>
        private string _warehouseCode = "";

        /// <summary>���i����</summary>
        private DateTime _inspectDateTime;

        /// <summary>���i�X�e�[�^�X</summary>
        /// <remarks>1:���i�� 2:�s�b�L���O�ς� 3:���i�ς݁@�ꊇ���i��"2"��o�^���܂��B</remarks>
        private Int32 _inspectStatus;

        /// <summary>���i�敪</summary>
        /// <remarks>1:�ʏ� 2:�蓮���i </remarks>
        private Int32 _inspectCode;

        /// <summary>���i��</summary>
        private Double _inspectCnt;

        /// <summary>�n���f�B�^�[�~�i���敪</summary>
        /// <remarks>1:�n���f�B�^�[�~�i�� 9:���̑�</remarks>
        private Int32 _handTerminalCode;

        /// <summary>�[������</summary>
        private string _machineName = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>���i�]�ƈ�</remarks>
        private string _employeeCode = "";

        // ----------- ADD 2017/08/02 ���O ---------------->>>>
        /// <summary>�݌Ɉړ��m��敪</summary>
        /// <remarks>1�F�o�׊m�肠��A�Q�F�o�׊m��Ȃ�</remarks>
        private Int32 _stockMoveFixCode;

        /// <summary>�����敪</summary>
        /// <remarks>13�F�݌Ɏd��(����) , 14�F�݌Ɏd��(�o��),�@15:�ړ��o�� , 16�F�ړ����� </remarks>
        private Int32 _procDiv;

        /// <summary>�������_�R�[�h</summary>
        private string _belongSectionCode = "";
        // ----------- ADD 2017/08/02 ���O ----------------<<<<

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

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��20:����,21:���v��,22:�ݏo,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��,60:�g��,61:����,70:��[����,71:��[�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPaySlipNum
        /// <summary>�󕥌��`�[�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcPaySlipNum
        {
            get { return _acPaySlipNum; }
            set { _acPaySlipNum = value; }
        }

        /// public propaty name  :  AcPaySlipRowNo
        /// <summary>�󕥌��s�ԍ��v���p�e�B</summary>
        /// <value>�u�󕥌��`�[�v�̓`�[�s�ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipRowNo
        {
            get { return _acPaySlipRowNo; }
            set { _acPaySlipRowNo = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>�󕥌�����敪�v���p�e�B</summary>
        /// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�݌ɊǗ��Ȃ���"0"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  InspectDateTime
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InspectDateTime
        {
            get { return _inspectDateTime; }
            set { _inspectDateTime = value; }
        }

        /// public propaty name  :  InspectStatus
        /// <summary>���i�X�e�[�^�X�v���p�e�B</summary>
        /// <value>1:���i�� 2:�s�b�L���O�ς� 3:���i�ς݁@�ꊇ���i��"2"��o�^���܂��B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InspectStatus
        {
            get { return _inspectStatus; }
            set { _inspectStatus = value; }
        }

        /// public propaty name  :  InspectCode
        /// <summary>���i�敪�v���p�e�B</summary>
        /// <value>1:�ʏ� 2:�蓮���i </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InspectCode
        {
            get { return _inspectCode; }
            set { _inspectCode = value; }
        }

        /// public propaty name  :  InspectCnt
        /// <summary>���i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double InspectCnt
        {
            get { return _inspectCnt; }
            set { _inspectCnt = value; }
        }

        /// public propaty name  :  HandTerminalCode
        /// <summary>�n���f�B�^�[�~�i���敪�v���p�e�B</summary>
        /// <value>1:�n���f�B�^�[�~�i�� 9:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n���f�B�^�[�~�i���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HandTerminalCode
        {
            get { return _handTerminalCode; }
            set { _handTerminalCode = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>�[�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���i�]�ƈ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        // ----------- ADD 2017/08/02 ���O ---------------->>>>
        /// public propaty name  :  StockMoveFixCode
        /// <summary>�݌Ɉړ��m��敪�v���p�e�B</summary>
        /// <value>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��m��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>15:�ړ��o�� , 16�F�ړ�����" </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  BelongSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BelongSectionCode
        {
            get { return _belongSectionCode; }
            set { _belongSectionCode = value; }
        }
        // ----------- ADD 2017/08/02 ���O ----------------<<<<

        /// <summary>
        /// ���i�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyInspectDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyInspectDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł��B
    /// </summary>
    /// <returns>HandyInspectDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   HandyInspectDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class HandyInspectDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  InspectDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyInspectDataWork || graph is ArrayList || graph is HandyInspectDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(HandyInspectDataWork).FullName));

            if (graph != null && graph is HandyInspectDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyInspectDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyInspectDataWork[])graph).Length;
            }
            else if (graph is HandyInspectDataWork)
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
            //�󕥌��`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //�󕥌��`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AcPaySlipNum
            //�󕥌��s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipRowNo
            //�󕥌�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //���i����
            serInfo.MemberInfo.Add(typeof(Int64)); //InspectDateTime
            //���i�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectStatus
            //���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InspectCode
            //���i��
            serInfo.MemberInfo.Add(typeof(Double)); //InspectCnt
            //�n���f�B�^�[�~�i���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HandTerminalCode
            //�[������
            serInfo.MemberInfo.Add(typeof(string)); //MachineName
            //�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            // ----------- ADD 2017/08/02 ���O ---------------->>>>
            //�݌Ɉړ��m��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFixCode
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcDiv
            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            // ----------- ADD 2017/08/02 ���O ----------------<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is HandyInspectDataWork)
            {
                HandyInspectDataWork temp = (HandyInspectDataWork)graph;

                SetInspectDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyInspectDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyInspectDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyInspectDataWork temp in lst)
                {
                    SetInspectDataWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// HandyInspectDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 22;  // DEL 2017/08/02 ���O
        private const int currentMemberCount = 25;    // ADD 2017/08/02 ���O

        /// <summary>
        ///  HandyInspectDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetInspectDataWork(System.IO.BinaryWriter writer, HandyInspectDataWork temp)
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
            //�󕥌��`�[�敪
            writer.Write(temp.AcPaySlipCd);
            //�󕥌��`�[�ԍ�
            writer.Write(temp.AcPaySlipNum);
            //�󕥌��s�ԍ�
            writer.Write(temp.AcPaySlipRowNo);
            //�󕥌�����敪
            writer.Write(temp.AcPayTransCd);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //���i����
            writer.Write((Int64)temp.InspectDateTime.Ticks);
            //���i�X�e�[�^�X
            writer.Write(temp.InspectStatus);
            //���i�敪
            writer.Write(temp.InspectCode);
            //���i��
            writer.Write(temp.InspectCnt);
            //�n���f�B�^�[�~�i���敪
            writer.Write(temp.HandTerminalCode);
            //�[������
            writer.Write(temp.MachineName);
            //�]�ƈ��R�[�h
            writer.Write(temp.EmployeeCode);
            // ----------- ADD 2017/08/02 ���O ---------------->>>>
	        //�݌Ɉړ��m��敪
            writer.Write(temp.StockMoveFixCode);
            //�����敪
            writer.Write(temp.ProcDiv);
            //�������_�R�[�h
            writer.Write(temp.BelongSectionCode);
            // ----------- ADD 2017/08/02 ���O ----------------<<<<
        }

        /// <summary>
        ///  HandyInspectDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>HandyInspectDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private HandyInspectDataWork GetInspectDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            HandyInspectDataWork temp = new HandyInspectDataWork();

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
            //�󕥌��`�[�敪
            temp.AcPaySlipCd = reader.ReadInt32();
            //�󕥌��`�[�ԍ�
            temp.AcPaySlipNum = reader.ReadString();
            //�󕥌��s�ԍ�
            temp.AcPaySlipRowNo = reader.ReadInt32();
            //�󕥌�����敪
            temp.AcPayTransCd = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //���i����
            temp.InspectDateTime = new DateTime(reader.ReadInt64());
            //���i�X�e�[�^�X
            temp.InspectStatus = reader.ReadInt32();
            //���i�敪
            temp.InspectCode = reader.ReadInt32();
            //���i��
            temp.InspectCnt = reader.ReadDouble();
            //�n���f�B�^�[�~�i���敪
            temp.HandTerminalCode = reader.ReadInt32();
            //�[������
            temp.MachineName = reader.ReadString();
            //�]�ƈ��R�[�h
            temp.EmployeeCode = reader.ReadString();
            // ----------- ADD 2017/08/02 ���O ---------------->>>>
            //�݌Ɉړ��m��敪
            temp.StockMoveFixCode = reader.ReadInt32();
            //�����敪
            temp.ProcDiv = reader.ReadInt32();
            //�������_�R�[�h
            temp.BelongSectionCode = reader.ReadString();
            // ----------- ADD 2017/08/02 ���O ----------------<<<<

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
        /// <returns>HandyInspectDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyInspectDataWork temp = GetInspectDataWork(reader, serInfo);
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
                    retValue = (HandyInspectDataWork[])lst.ToArray(typeof(HandyInspectDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
