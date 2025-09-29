using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_UpdHisDspWork
    /// <summary>
    ///                      �X�V����\�����o���ʃ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �X�V����\�����o���ʃ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_UpdHisDspWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�󔒂͑S���_�̈ꊇ����</remarks>
        private string _addUpSecCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�O�̏ꍇ�͈ꊇ����</remarks>
        private Int32 _customerCode;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�O�̏ꍇ�͈ꊇ����</remarks>
        private Int32 _supplierCd;

        /// <summary>���|���|�敪</summary>
        /// <remarks>�O�F���| �P�F���|</remarks>
        private Int32 _accRecAccPayDiv;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>�����X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _cAddUpUpdDate;

        /// <summary>�����X�V�N��</summary>
        /// <remarks>"YYYYMM"    �����X�V�ΏۂƂȂ����N��</remarks>
        private DateTime _cAddUpUpdYearMonth;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>�O������X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _lastCAddUpUpdDate;

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

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�������_�R�[�h</summary>
        private string _belongSectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�f�[�^�X�V����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private Int64 _dataUpdateDateTime;


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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�O�̏ꍇ�͈ꊇ����</value>
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�O�̏ꍇ�͈ꊇ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
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

        /// public propaty name  :  StartCAddUpUpdDate
        /// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartCAddUpUpdDate
        {
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }

        /// public propaty name  :  CAddUpUpdDate
        /// <summary>�����X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CAddUpUpdDate
        {
            get { return _cAddUpUpdDate; }
            set { _cAddUpUpdDate = value; }
        }

        /// public propaty name  :  CAddUpUpdYearMonth
        /// <summary>�����X�V�N���v���p�e�B</summary>
        /// <value>"YYYYMM"    �����X�V�ΏۂƂȂ����N��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CAddUpUpdYearMonth
        {
            get { return _cAddUpUpdYearMonth; }
            set { _cAddUpUpdYearMonth = value; }
        }

        /// public propaty name  :  CAddUpUpdExecDate
        /// <summary>�����X�V���s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CAddUpUpdExecDate
        {
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

        /// public propaty name  :  LastCAddUpUpdDate
        /// <summary>�O������X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastCAddUpUpdDate
        {
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>�f�[�^�X�V�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }


        /// <summary>
        /// �X�V����\�����o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_UpdHisDspWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_UpdHisDspWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_UpdHisDspWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RsltInfo_UpdHisDspWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RsltInfo_UpdHisDspWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RsltInfo_UpdHisDspWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_UpdHisDspWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RsltInfo_UpdHisDspWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RsltInfo_UpdHisDspWork || graph is ArrayList || graph is RsltInfo_UpdHisDspWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RsltInfo_UpdHisDspWork).FullName));

            if (graph != null && graph is RsltInfo_UpdHisDspWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RsltInfo_UpdHisDspWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RsltInfo_UpdHisDspWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RsltInfo_UpdHisDspWork[])graph).Length;
            }
            else if (graph is RsltInfo_UpdHisDspWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���|���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecAccPayDiv
            //�����X�V�J�n�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //StartCAddUpUpdDate
            //�����X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdDate
            //�����X�V�N��
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdYearMonth
            //�����X�V���s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //CAddUpUpdExecDate
            //�O������X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LastCAddUpUpdDate
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
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�f�[�^�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is RsltInfo_UpdHisDspWork)
            {
                RsltInfo_UpdHisDspWork temp = (RsltInfo_UpdHisDspWork)graph;

                SetRsltInfo_UpdHisDspWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RsltInfo_UpdHisDspWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RsltInfo_UpdHisDspWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RsltInfo_UpdHisDspWork temp in lst)
                {
                    SetRsltInfo_UpdHisDspWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RsltInfo_UpdHisDspWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RsltInfo_UpdHisDspWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_UpdHisDspWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRsltInfo_UpdHisDspWork(System.IO.BinaryWriter writer, RsltInfo_UpdHisDspWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���|���|�敪
            writer.Write(temp.AccRecAccPayDiv);
            //�����X�V�J�n�N����
            writer.Write((Int64)temp.StartCAddUpUpdDate.Ticks);
            //�����X�V�N����
            writer.Write((Int64)temp.CAddUpUpdDate.Ticks);
            //�����X�V�N��
            writer.Write((Int64)temp.CAddUpUpdYearMonth.Ticks);
            //�����X�V���s�N����
            writer.Write((Int64)temp.CAddUpUpdExecDate.Ticks);
            //�O������X�V�N����
            writer.Write((Int64)temp.LastCAddUpUpdDate.Ticks);
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
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�������_�R�[�h
            writer.Write(temp.BelongSectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //�f�[�^�X�V����
            writer.Write(temp.DataUpdateDateTime);

        }

        /// <summary>
        ///  RsltInfo_UpdHisDspWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RsltInfo_UpdHisDspWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_UpdHisDspWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RsltInfo_UpdHisDspWork GetRsltInfo_UpdHisDspWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RsltInfo_UpdHisDspWork temp = new RsltInfo_UpdHisDspWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���|���|�敪
            temp.AccRecAccPayDiv = reader.ReadInt32();
            //�����X�V�J�n�N����
            temp.StartCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�����X�V�N����
            temp.CAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�����X�V�N��
            temp.CAddUpUpdYearMonth = new DateTime(reader.ReadInt64());
            //�����X�V���s�N����
            temp.CAddUpUpdExecDate = new DateTime(reader.ReadInt64());
            //�O������X�V�N����
            temp.LastCAddUpUpdDate = new DateTime(reader.ReadInt64());
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
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�������_�R�[�h
            temp.BelongSectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //�f�[�^�X�V����
            temp.DataUpdateDateTime = reader.ReadInt64();


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
        /// <returns>RsltInfo_UpdHisDspWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RsltInfo_UpdHisDspWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RsltInfo_UpdHisDspWork temp = GetRsltInfo_UpdHisDspWork(reader, serInfo);
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
                    retValue = (RsltInfo_UpdHisDspWork[])lst.ToArray(typeof(RsltInfo_UpdHisDspWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
