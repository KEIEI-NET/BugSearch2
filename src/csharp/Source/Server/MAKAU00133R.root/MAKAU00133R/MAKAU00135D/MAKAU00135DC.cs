using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MonthlyAddUpHisWork
    /// <summary>
    ///                      �������X�V�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �������X�V�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/8/8  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �R���o�[�g�����敪</br>
    /// <br>Update Note      :   2008/10/02  ����</br>
    /// <br>                 :   �����ڒǉ��i�L�[�ύX�j</br>
    /// <br>                 :   �f�[�^�X�V����</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MonthlyAddUpHisWork : IFileHeader
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

        /// <summary>���|���|�敪</summary>
        /// <remarks>�O�F���| �P�F���|</remarks>
        private Int32 _accRecAccPayDiv;

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�󔒂͑S���_�̈ꊇ����</remarks>
        private string _addUpSecCode = "";

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _stMonCAddUpUpdDate;

        /// <summary>�����X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�N����</remarks>
        private DateTime _monthlyAddUpDate;

        /// <summary>�����X�V�N��</summary>
        /// <remarks>"YYYYMM"    �����X�V�ΏۂƂȂ����N��</remarks>
        private DateTime _monthAddUpYearMonth;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD�@�����X�V���s�N����</remarks>
        private DateTime _monthAddUpExpDate;

        /// <summary>�O�񌎎��X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _laMonCAddUpUpdDate;

        /// <summary>�f�[�^�X�V����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _dataUpdateDateTime;

        /// <summary>�����敪</summary>
        /// <remarks>0:�X�V���� 1:��������</remarks>
        private Int32 _procDivCd;

        /// <summary>�G���[�X�e�[�^�X</summary>
        /// <remarks>0:����@1:�G���[</remarks>
        private Int32 _errorStatus;

        /// <summary>���𐧌�敪</summary>
        /// <remarks>0:�m�� 1:���m��(�������)</remarks>
        private Int32 _histCtlCd;

        /// <summary>��������</summary>
        /// <remarks>�������ʂ��Z�b�g�@��j�G���[�X�e�[�^�X0�̎��u����I���v</remarks>
        private string _procResult = "";

        /// <summary>�R���o�[�g�����敪</summary>
        /// <remarks>0:�ʏ�@1:�R���o�[�g�f�[�^</remarks>
        private Int32 _convertProcessDivCd;


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

        /// public propaty name  :  AccRecAccPayDiv
        /// <summary>���|���|�敪�v���p�e�B</summary>
        /// <value>�O�F���| �P�F���|</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecAccPayDiv
        {
            get { return _accRecAccPayDiv; }
            set { _accRecAccPayDiv = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�󔒂͑S���_�̈ꊇ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  StMonCAddUpUpdDate
        /// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StMonCAddUpUpdDate
        {
            get { return _stMonCAddUpUpdDate; }
            set { _stMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  MonthlyAddUpDate
        /// <summary>�����X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MonthlyAddUpDate
        {
            get { return _monthlyAddUpDate; }
            set { _monthlyAddUpDate = value; }
        }

        /// public propaty name  :  MonthAddUpYearMonth
        /// <summary>�����X�V�N���v���p�e�B</summary>
        /// <value>"YYYYMM"    �����X�V�ΏۂƂȂ����N��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MonthAddUpYearMonth
        {
            get { return _monthAddUpYearMonth; }
            set { _monthAddUpYearMonth = value; }
        }

        /// public propaty name  :  MonthAddUpExpDate
        /// <summary>�����X�V���s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�����X�V���s�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MonthAddUpExpDate
        {
            get { return _monthAddUpExpDate; }
            set { _monthAddUpExpDate = value; }
        }

        /// public propaty name  :  LaMonCAddUpUpdDate
        /// <summary>�O�񌎎��X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񌎎��X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>�f�[�^�X�V�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }

        /// public propaty name  :  ProcDivCd
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�X�V���� 1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDivCd
        {
            get { return _procDivCd; }
            set { _procDivCd = value; }
        }

        /// public propaty name  :  ErrorStatus
        /// <summary>�G���[�X�e�[�^�X�v���p�e�B</summary>
        /// <value>0:����@1:�G���[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorStatus
        {
            get { return _errorStatus; }
            set { _errorStatus = value; }
        }

        /// public propaty name  :  HistCtlCd
        /// <summary>���𐧌�敪�v���p�e�B</summary>
        /// <value>0:�m�� 1:���m��(�������)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���𐧌�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 HistCtlCd
        {
            get { return _histCtlCd; }
            set { _histCtlCd = value; }
        }

        /// public propaty name  :  ProcResult
        /// <summary>�������ʃv���p�e�B</summary>
        /// <value>�������ʂ��Z�b�g�@��j�G���[�X�e�[�^�X0�̎��u����I���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ProcResult
        {
            get { return _procResult; }
            set { _procResult = value; }
        }

        /// public propaty name  :  ConvertProcessDivCd
        /// <summary>�R���o�[�g�����敪�v���p�e�B</summary>
        /// <value>0:�ʏ�@1:�R���o�[�g�f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R���o�[�g�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConvertProcessDivCd
        {
            get { return _convertProcessDivCd; }
            set { _convertProcessDivCd = value; }
        }


        /// <summary>
        /// �������X�V�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MonthlyAddUpHisWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpHisWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MonthlyAddUpHisWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MonthlyAddUpHisWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpHisWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MonthlyAddUpHisWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpHisWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MonthlyAddUpHisWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MonthlyAddUpHisWork || graph is ArrayList || graph is MonthlyAddUpHisWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MonthlyAddUpHisWork).FullName));

            if (graph != null && graph is MonthlyAddUpHisWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpHisWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MonthlyAddUpHisWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MonthlyAddUpHisWork[])graph).Length;
            }
            else if (graph is MonthlyAddUpHisWork)
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
            //���|���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecAccPayDiv
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�����X�V�J�n�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //StMonCAddUpUpdDate
            //�����X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthlyAddUpDate
            //�����X�V�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpYearMonth
            //�����X�V���s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate
            //�O�񌎎��X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LaMonCAddUpUpdDate
            //�f�[�^�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcDivCd
            //�G���[�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorStatus
            //���𐧌�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //HistCtlCd
            //��������
            serInfo.MemberInfo.Add(typeof(string)); //ProcResult
            //�R���o�[�g�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ConvertProcessDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is MonthlyAddUpHisWork)
            {
                MonthlyAddUpHisWork temp = (MonthlyAddUpHisWork)graph;

                SetMonthlyAddUpHisWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MonthlyAddUpHisWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MonthlyAddUpHisWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MonthlyAddUpHisWork temp in lst)
                {
                    SetMonthlyAddUpHisWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MonthlyAddUpHisWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 21;

        /// <summary>
        ///  MonthlyAddUpHisWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpHisWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMonthlyAddUpHisWork(System.IO.BinaryWriter writer, MonthlyAddUpHisWork temp)
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
            //���|���|�敪
            writer.Write(temp.AccRecAccPayDiv);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�����X�V�J�n�N����
            writer.Write((Int64)temp.StMonCAddUpUpdDate.Ticks);
            //�����X�V�N����
            writer.Write((Int64)temp.MonthlyAddUpDate.Ticks);
            //�����X�V�N��
            writer.Write((Int64)temp.MonthAddUpYearMonth.Ticks);
            //�����X�V���s�N����
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);
            //�O�񌎎��X�V�N����
            writer.Write((Int64)temp.LaMonCAddUpUpdDate.Ticks);
            //�f�[�^�X�V����
            writer.Write((Int64)temp.DataUpdateDateTime.Ticks);
            //�����敪
            writer.Write(temp.ProcDivCd);
            //�G���[�X�e�[�^�X
            writer.Write(temp.ErrorStatus);
            //���𐧌�敪
            writer.Write(temp.HistCtlCd);
            //��������
            writer.Write(temp.ProcResult);
            //�R���o�[�g�����敪
            writer.Write(temp.ConvertProcessDivCd);

        }

        /// <summary>
        ///  MonthlyAddUpHisWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MonthlyAddUpHisWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpHisWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MonthlyAddUpHisWork GetMonthlyAddUpHisWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MonthlyAddUpHisWork temp = new MonthlyAddUpHisWork();

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
            //���|���|�敪
            temp.AccRecAccPayDiv = reader.ReadInt32();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�����X�V�J�n�N����
            temp.StMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�����X�V�N����
            temp.MonthlyAddUpDate = new DateTime(reader.ReadInt64());
            //�����X�V�N��
            temp.MonthAddUpYearMonth = new DateTime(reader.ReadInt64());
            //�����X�V���s�N����
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());
            //�O�񌎎��X�V�N����
            temp.LaMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�f�[�^�X�V����
            temp.DataUpdateDateTime = new DateTime(reader.ReadInt64());
            //�����敪
            temp.ProcDivCd = reader.ReadInt32();
            //�G���[�X�e�[�^�X
            temp.ErrorStatus = reader.ReadInt32();
            //���𐧌�敪
            temp.HistCtlCd = reader.ReadInt32();
            //��������
            temp.ProcResult = reader.ReadString();
            //�R���o�[�g�����敪
            temp.ConvertProcessDivCd = reader.ReadInt32();


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
        /// <returns>MonthlyAddUpHisWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthlyAddUpHisWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MonthlyAddUpHisWork temp = GetMonthlyAddUpHisWork(reader, serInfo);
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
                    retValue = (MonthlyAddUpHisWork[])lst.ToArray(typeof(MonthlyAddUpHisWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
