using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AlItmDspNmWork
    /// <summary>
    ///                      �S�̍��ڕ\�����̃��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �S�̍��ڕ\�����̃��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2008/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AlItmDspNmWork : IFileHeader
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

        /// <summary>����TEL�\������</summary>
        private string _homeTelNoDspName = "";

        /// <summary>�Ζ���TEL�\������</summary>
        private string _officeTelNoDspName = "";

        /// <summary>�g��TEL�\������</summary>
        private string _mobileTelNoDspName = "";

        /// <summary>���̑�TEL�\������</summary>
        private string _otherTelNoDspName = "";

        /// <summary>����FAX�\������</summary>
        private string _homeFaxNoDspName = "";

        /// <summary>�Ζ���FAX�\������</summary>
        private string _officeFaxNoDspName = "";

        /// <summary>�ǉ����1�\������</summary>
        private string _addInfo1DspName = "";

        /// <summary>�ǉ����2�\������</summary>
        private string _addInfo2DspName = "";

        /// <summary>�ǉ����3�\������</summary>
        private string _addInfo3DspName = "";

        /// <summary>�����\������</summary>
        private string _joinDspName = "";

        /// <summary>�d�����\������</summary>
        private string _stockRateDspName = "";

        /// <summary>���P���\������</summary>
        private string _unitCostDspName = "";

        /// <summary>�e���z�\������</summary>
        private string _profitDspName = "";

        /// <summary>�e�����\������</summary>
        private string _profitRateDspName = "";

        /// <summary>�O�ŕ\������</summary>
        /// <remarks>�i�O�j�A�O��</remarks>
        private string _outTaxDspName = "";

        /// <summary>���ŕ\������</summary>
        private string _inTaxDspName = "";

        /// <summary>�艿�\������</summary>
        /// <remarks>�W�����i�A�艿</remarks>
        private string _listPriceDspName = "";

        /// <summary>�[�i���h�̏����l</summary>
        private string _deliHonorTtlDef = "";

        /// <summary>�������h�̏����l</summary>
        private string _billHonorTtlDef = "";

        /// <summary>���Ϗ��h�̏����l</summary>
        private string _estmHonorTtlDef = "";

        /// <summary>�������h�̏����l</summary>
        private string _rectHonorTtlDef = "";


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

        /// public propaty name  :  HomeTelNoDspName
        /// <summary>����TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNoDspName
        {
            get { return _homeTelNoDspName; }
            set { _homeTelNoDspName = value; }
        }

        /// public propaty name  :  OfficeTelNoDspName
        /// <summary>�Ζ���TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ζ���TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNoDspName
        {
            get { return _officeTelNoDspName; }
            set { _officeTelNoDspName = value; }
        }

        /// public propaty name  :  MobileTelNoDspName
        /// <summary>�g��TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g��TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MobileTelNoDspName
        {
            get { return _mobileTelNoDspName; }
            set { _mobileTelNoDspName = value; }
        }

        /// public propaty name  :  OtherTelNoDspName
        /// <summary>���̑�TEL�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̑�TEL�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OtherTelNoDspName
        {
            get { return _otherTelNoDspName; }
            set { _otherTelNoDspName = value; }
        }

        /// public propaty name  :  HomeFaxNoDspName
        /// <summary>����FAX�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����FAX�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNoDspName
        {
            get { return _homeFaxNoDspName; }
            set { _homeFaxNoDspName = value; }
        }

        /// public propaty name  :  OfficeFaxNoDspName
        /// <summary>�Ζ���FAX�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ζ���FAX�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNoDspName
        {
            get { return _officeFaxNoDspName; }
            set { _officeFaxNoDspName = value; }
        }

        /// public propaty name  :  AddInfo1DspName
        /// <summary>�ǉ����1�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ����1�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddInfo1DspName
        {
            get { return _addInfo1DspName; }
            set { _addInfo1DspName = value; }
        }

        /// public propaty name  :  AddInfo2DspName
        /// <summary>�ǉ����2�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ����2�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddInfo2DspName
        {
            get { return _addInfo2DspName; }
            set { _addInfo2DspName = value; }
        }

        /// public propaty name  :  AddInfo3DspName
        /// <summary>�ǉ����3�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ����3�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddInfo3DspName
        {
            get { return _addInfo3DspName; }
            set { _addInfo3DspName = value; }
        }

        /// public propaty name  :  JoinDspName
        /// <summary>�����\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDspName
        {
            get { return _joinDspName; }
            set { _joinDspName = value; }
        }

        /// public propaty name  :  StockRateDspName
        /// <summary>�d�����\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRateDspName
        {
            get { return _stockRateDspName; }
            set { _stockRateDspName = value; }
        }

        /// public propaty name  :  UnitCostDspName
        /// <summary>���P���\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���P���\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UnitCostDspName
        {
            get { return _unitCostDspName; }
            set { _unitCostDspName = value; }
        }

        /// public propaty name  :  ProfitDspName
        /// <summary>�e���z�\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ProfitDspName
        {
            get { return _profitDspName; }
            set { _profitDspName = value; }
        }

        /// public propaty name  :  ProfitRateDspName
        /// <summary>�e�����\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�����\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ProfitRateDspName
        {
            get { return _profitRateDspName; }
            set { _profitRateDspName = value; }
        }

        /// public propaty name  :  OutTaxDspName
        /// <summary>�O�ŕ\�����̃v���p�e�B</summary>
        /// <value>�i�O�j�A�O��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�ŕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutTaxDspName
        {
            get { return _outTaxDspName; }
            set { _outTaxDspName = value; }
        }

        /// public propaty name  :  InTaxDspName
        /// <summary>���ŕ\�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ŕ\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InTaxDspName
        {
            get { return _inTaxDspName; }
            set { _inTaxDspName = value; }
        }

        /// public propaty name  :  ListPriceDspName
        /// <summary>�艿�\�����̃v���p�e�B</summary>
        /// <value>�W�����i�A�艿</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�\�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ListPriceDspName
        {
            get { return _listPriceDspName; }
            set { _listPriceDspName = value; }
        }

        /// public propaty name  :  DeliHonorTtlDef
        /// <summary>�[�i���h�̏����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i���h�̏����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliHonorTtlDef
        {
            get { return _deliHonorTtlDef; }
            set { _deliHonorTtlDef = value; }
        }

        /// public propaty name  :  BillHonorTtlDef
        /// <summary>�������h�̏����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̏����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillHonorTtlDef
        {
            get { return _billHonorTtlDef; }
            set { _billHonorTtlDef = value; }
        }

        /// public propaty name  :  EstmHonorTtlDef
        /// <summary>���Ϗ��h�̏����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ϗ��h�̏����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EstmHonorTtlDef
        {
            get { return _estmHonorTtlDef; }
            set { _estmHonorTtlDef = value; }
        }

        /// public propaty name  :  RectHonorTtlDef
        /// <summary>�������h�̏����l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̏����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RectHonorTtlDef
        {
            get { return _rectHonorTtlDef; }
            set { _rectHonorTtlDef = value; }
        }


        /// <summary>
        /// �S�̍��ڕ\�����̃��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>AlItmDspNmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AlItmDspNmWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AlItmDspNmWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AlItmDspNmWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AlItmDspNmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class AlItmDspNmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AlItmDspNmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AlItmDspNmWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AlItmDspNmWork || graph is ArrayList || graph is AlItmDspNmWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AlItmDspNmWork).FullName));

            if (graph != null && graph is AlItmDspNmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AlItmDspNmWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AlItmDspNmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AlItmDspNmWork[])graph).Length;
            }
            else if (graph is AlItmDspNmWork)
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
            //����TEL�\������
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNoDspName
            //�Ζ���TEL�\������
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNoDspName
            //�g��TEL�\������
            serInfo.MemberInfo.Add(typeof(string)); //MobileTelNoDspName
            //���̑�TEL�\������
            serInfo.MemberInfo.Add(typeof(string)); //OtherTelNoDspName
            //����FAX�\������
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNoDspName
            //�Ζ���FAX�\������
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNoDspName
            //�ǉ����1�\������
            serInfo.MemberInfo.Add(typeof(string)); //AddInfo1DspName
            //�ǉ����2�\������
            serInfo.MemberInfo.Add(typeof(string)); //AddInfo2DspName
            //�ǉ����3�\������
            serInfo.MemberInfo.Add(typeof(string)); //AddInfo3DspName
            //�����\������
            serInfo.MemberInfo.Add(typeof(string)); //JoinDspName
            //�d�����\������
            serInfo.MemberInfo.Add(typeof(string)); //StockRateDspName
            //���P���\������
            serInfo.MemberInfo.Add(typeof(string)); //UnitCostDspName
            //�e���z�\������
            serInfo.MemberInfo.Add(typeof(string)); //ProfitDspName
            //�e�����\������
            serInfo.MemberInfo.Add(typeof(string)); //ProfitRateDspName
            //�O�ŕ\������
            serInfo.MemberInfo.Add(typeof(string)); //OutTaxDspName
            //���ŕ\������
            serInfo.MemberInfo.Add(typeof(string)); //InTaxDspName
            //�艿�\������
            serInfo.MemberInfo.Add(typeof(string)); //ListPriceDspName
            //�[�i���h�̏����l
            serInfo.MemberInfo.Add(typeof(string)); //DeliHonorTtlDef
            //�������h�̏����l
            serInfo.MemberInfo.Add(typeof(string)); //BillHonorTtlDef
            //���Ϗ��h�̏����l
            serInfo.MemberInfo.Add(typeof(string)); //EstmHonorTtlDef
            //�������h�̏����l
            serInfo.MemberInfo.Add(typeof(string)); //RectHonorTtlDef


            serInfo.Serialize(writer, serInfo);
            if (graph is AlItmDspNmWork)
            {
                AlItmDspNmWork temp = (AlItmDspNmWork)graph;

                SetAlItmDspNmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AlItmDspNmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AlItmDspNmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AlItmDspNmWork temp in lst)
                {
                    SetAlItmDspNmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AlItmDspNmWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 30;

        /// <summary>
        ///  AlItmDspNmWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AlItmDspNmWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetAlItmDspNmWork(System.IO.BinaryWriter writer, AlItmDspNmWork temp)
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
            //����TEL�\������
            writer.Write(temp.HomeTelNoDspName);
            //�Ζ���TEL�\������
            writer.Write(temp.OfficeTelNoDspName);
            //�g��TEL�\������
            writer.Write(temp.MobileTelNoDspName);
            //���̑�TEL�\������
            writer.Write(temp.OtherTelNoDspName);
            //����FAX�\������
            writer.Write(temp.HomeFaxNoDspName);
            //�Ζ���FAX�\������
            writer.Write(temp.OfficeFaxNoDspName);
            //�ǉ����1�\������
            writer.Write(temp.AddInfo1DspName);
            //�ǉ����2�\������
            writer.Write(temp.AddInfo2DspName);
            //�ǉ����3�\������
            writer.Write(temp.AddInfo3DspName);
            //�����\������
            writer.Write(temp.JoinDspName);
            //�d�����\������
            writer.Write(temp.StockRateDspName);
            //���P���\������
            writer.Write(temp.UnitCostDspName);
            //�e���z�\������
            writer.Write(temp.ProfitDspName);
            //�e�����\������
            writer.Write(temp.ProfitRateDspName);
            //�O�ŕ\������
            writer.Write(temp.OutTaxDspName);
            //���ŕ\������
            writer.Write(temp.InTaxDspName);
            //�艿�\������
            writer.Write(temp.ListPriceDspName);
            //�[�i���h�̏����l
            writer.Write(temp.DeliHonorTtlDef);
            //�������h�̏����l
            writer.Write(temp.BillHonorTtlDef);
            //���Ϗ��h�̏����l
            writer.Write(temp.EstmHonorTtlDef);
            //�������h�̏����l
            writer.Write(temp.RectHonorTtlDef);

        }

        /// <summary>
        ///  AlItmDspNmWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AlItmDspNmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AlItmDspNmWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private AlItmDspNmWork GetAlItmDspNmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AlItmDspNmWork temp = new AlItmDspNmWork();

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
            //����TEL�\������
            temp.HomeTelNoDspName = reader.ReadString();
            //�Ζ���TEL�\������
            temp.OfficeTelNoDspName = reader.ReadString();
            //�g��TEL�\������
            temp.MobileTelNoDspName = reader.ReadString();
            //���̑�TEL�\������
            temp.OtherTelNoDspName = reader.ReadString();
            //����FAX�\������
            temp.HomeFaxNoDspName = reader.ReadString();
            //�Ζ���FAX�\������
            temp.OfficeFaxNoDspName = reader.ReadString();
            //�ǉ����1�\������
            temp.AddInfo1DspName = reader.ReadString();
            //�ǉ����2�\������
            temp.AddInfo2DspName = reader.ReadString();
            //�ǉ����3�\������
            temp.AddInfo3DspName = reader.ReadString();
            //�����\������
            temp.JoinDspName = reader.ReadString();
            //�d�����\������
            temp.StockRateDspName = reader.ReadString();
            //���P���\������
            temp.UnitCostDspName = reader.ReadString();
            //�e���z�\������
            temp.ProfitDspName = reader.ReadString();
            //�e�����\������
            temp.ProfitRateDspName = reader.ReadString();
            //�O�ŕ\������
            temp.OutTaxDspName = reader.ReadString();
            //���ŕ\������
            temp.InTaxDspName = reader.ReadString();
            //�艿�\������
            temp.ListPriceDspName = reader.ReadString();
            //�[�i���h�̏����l
            temp.DeliHonorTtlDef = reader.ReadString();
            //�������h�̏����l
            temp.BillHonorTtlDef = reader.ReadString();
            //���Ϗ��h�̏����l
            temp.EstmHonorTtlDef = reader.ReadString();
            //�������h�̏����l
            temp.RectHonorTtlDef = reader.ReadString();


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
        /// <returns>AlItmDspNmWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AlItmDspNmWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AlItmDspNmWork temp = GetAlItmDspNmWork(reader, serInfo);
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
                    retValue = (AlItmDspNmWork[])lst.ToArray(typeof(AlItmDspNmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
