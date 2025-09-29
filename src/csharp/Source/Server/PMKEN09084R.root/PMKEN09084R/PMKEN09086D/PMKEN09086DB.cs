using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstUSearchResultWork
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
    public class PartsSubstUSearchResultWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�ϊ������[�J�[�R�[�h</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>�ϊ������i�ԍ�</summary>
        private string _chgSrcGoodsNo = "";

        /// <summary>�n�C�t�����ϊ������i�ԍ�</summary>
        private string _chgSrcGoodsNoNoneHp = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _chgSrcWarehouseCode = "";

        /// <summary>�q�ɒI��</summary>
        private string _chgSrcWarehouseShelfNo = "";

        /// <summary>�d���I�ԂP</summary>
        private string _chgSrcDuplicationShelfNo1 = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _chgSrcDuplicationShelfNo2 = "";

        /// <summary>�o�׉\��</summary>
        private Double _chgSrcShipmentPosCnt;

        /// <summary>�ϊ��惁�[�J�[�R�[�h</summary>
        private Int32 _chgDestMakerCd;

        /// <summary>�ϊ��揤�i�ԍ�</summary>
        private string _chgDestGoodsNo = "";

        /// <summary>�n�C�t�����ϊ��揤�i�ԍ�</summary>
        private string _chgDestGoodsNoNoneHp = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _chgDestWarehouseCode = "";

        /// <summary>�q�ɒI��</summary>
        private string _chgDestWarehouseShelfNo = "";

        /// <summary>�d���I�ԂP</summary>
        private string _chgDestDuplicationShelfNo1 = "";

        /// <summary>�d���I�ԂQ</summary>
        private string _chgDestDuplicationShelfNo2 = "";

        /// <summary>�o�׉\��</summary>
        private Double _chgDestShipmentPosCnt;


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

        /// public propaty name  :  ChgSrcMakerCd
        /// <summary>�ϊ������[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChgSrcMakerCd
        {
            get { return _chgSrcMakerCd; }
            set { _chgSrcMakerCd = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNo
        /// <summary>�ϊ������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcGoodsNo
        {
            get { return _chgSrcGoodsNo; }
            set { _chgSrcGoodsNo = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNoNoneHp
        /// <summary>�n�C�t�����ϊ������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ϊ������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcGoodsNoNoneHp
        {
            get { return _chgSrcGoodsNoNoneHp; }
            set { _chgSrcGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ChgSrcWarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcWarehouseCode
        {
            get { return _chgSrcWarehouseCode; }
            set { _chgSrcWarehouseCode = value; }
        }

        /// public propaty name  :  ChgSrcWarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcWarehouseShelfNo
        {
            get { return _chgSrcWarehouseShelfNo; }
            set { _chgSrcWarehouseShelfNo = value; }
        }

        /// public propaty name  :  ChgSrcDuplicationShelfNo1
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcDuplicationShelfNo1
        {
            get { return _chgSrcDuplicationShelfNo1; }
            set { _chgSrcDuplicationShelfNo1 = value; }
        }

        /// public propaty name  :  ChgSrcDuplicationShelfNo2
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgSrcDuplicationShelfNo2
        {
            get { return _chgSrcDuplicationShelfNo2; }
            set { _chgSrcDuplicationShelfNo2 = value; }
        }

        /// public propaty name  :  ChgSrcShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ChgSrcShipmentPosCnt
        {
            get { return _chgSrcShipmentPosCnt; }
            set { _chgSrcShipmentPosCnt = value; }
        }

        /// public propaty name  :  ChgDestMakerCd
        /// <summary>�ϊ��惁�[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��惁�[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChgDestMakerCd
        {
            get { return _chgDestMakerCd; }
            set { _chgDestMakerCd = value; }
        }

        /// public propaty name  :  ChgDestGoodsNo
        /// <summary>�ϊ��揤�i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��揤�i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestGoodsNo
        {
            get { return _chgDestGoodsNo; }
            set { _chgDestGoodsNo = value; }
        }

        /// public propaty name  :  ChgDestGoodsNoNoneHp
        /// <summary>�n�C�t�����ϊ��揤�i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ϊ��揤�i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestGoodsNoNoneHp
        {
            get { return _chgDestGoodsNoNoneHp; }
            set { _chgDestGoodsNoNoneHp = value; }
        }

        /// public propaty name  :  ChgDestWarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestWarehouseCode
        {
            get { return _chgDestWarehouseCode; }
            set { _chgDestWarehouseCode = value; }
        }

        /// public propaty name  :  ChgDestWarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestWarehouseShelfNo
        {
            get { return _chgDestWarehouseShelfNo; }
            set { _chgDestWarehouseShelfNo = value; }
        }

        /// public propaty name  :  ChgDestDuplicationShelfNo1
        /// <summary>�d���I�ԂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestDuplicationShelfNo1
        {
            get { return _chgDestDuplicationShelfNo1; }
            set { _chgDestDuplicationShelfNo1 = value; }
        }

        /// public propaty name  :  ChgDestDuplicationShelfNo2
        /// <summary>�d���I�ԂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���I�ԂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChgDestDuplicationShelfNo2
        {
            get { return _chgDestDuplicationShelfNo2; }
            set { _chgDestDuplicationShelfNo2 = value; }
        }

        /// public propaty name  :  ChgDestShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ChgDestShipmentPosCnt
        {
            get { return _chgDestShipmentPosCnt; }
            set { _chgDestShipmentPosCnt = value; }
        }


        /// <summary>
        /// ��֐V���֘A�\�����o���ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsSubstUSearchResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsSubstUSearchResultWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsSubstUSearchResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsSubstUSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstUSearchResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsSubstUSearchResultWork || graph is ArrayList || graph is PartsSubstUSearchResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsSubstUSearchResultWork).FullName));

            if (graph != null && graph is PartsSubstUSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsSubstUSearchResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsSubstUSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsSubstUSearchResultWork[])graph).Length;
            }
            else if (graph is PartsSubstUSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�ϊ������[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgSrcMakerCd
            //�ϊ������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsNo
            //�n�C�t�����ϊ������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcGoodsNoNoneHp
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcWarehouseCode
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcWarehouseShelfNo
            //�d���I�ԂP
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcDuplicationShelfNo1
            //�d���I�ԂQ
            serInfo.MemberInfo.Add(typeof(string)); //ChgSrcDuplicationShelfNo2
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ChgSrcShipmentPosCnt
            //�ϊ��惁�[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgDestMakerCd
            //�ϊ��揤�i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsNo
            //�n�C�t�����ϊ��揤�i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestGoodsNoNoneHp
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestWarehouseCode
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestWarehouseShelfNo
            //�d���I�ԂP
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestDuplicationShelfNo1
            //�d���I�ԂQ
            serInfo.MemberInfo.Add(typeof(string)); //ChgDestDuplicationShelfNo2
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ChgDestShipmentPosCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is PartsSubstUSearchResultWork)
            {
                PartsSubstUSearchResultWork temp = (PartsSubstUSearchResultWork)graph;

                SetPartsSubstUSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsSubstUSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsSubstUSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsSubstUSearchResultWork temp in lst)
                {
                    SetPartsSubstUSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsSubstUSearchResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  PartsSubstUSearchResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPartsSubstUSearchResultWork(System.IO.BinaryWriter writer, PartsSubstUSearchResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�ϊ������[�J�[�R�[�h
            writer.Write(temp.ChgSrcMakerCd);
            //�ϊ������i�ԍ�
            writer.Write(temp.ChgSrcGoodsNo);
            //�n�C�t�����ϊ������i�ԍ�
            writer.Write(temp.ChgSrcGoodsNoNoneHp);
            //�q�ɃR�[�h
            writer.Write(temp.ChgSrcWarehouseCode);
            //�q�ɒI��
            writer.Write(temp.ChgSrcWarehouseShelfNo);
            //�d���I�ԂP
            writer.Write(temp.ChgSrcDuplicationShelfNo1);
            //�d���I�ԂQ
            writer.Write(temp.ChgSrcDuplicationShelfNo2);
            //�o�׉\��
            writer.Write(temp.ChgSrcShipmentPosCnt);
            //�ϊ��惁�[�J�[�R�[�h
            writer.Write(temp.ChgDestMakerCd);
            //�ϊ��揤�i�ԍ�
            writer.Write(temp.ChgDestGoodsNo);
            //�n�C�t�����ϊ��揤�i�ԍ�
            writer.Write(temp.ChgDestGoodsNoNoneHp);
            //�q�ɃR�[�h
            writer.Write(temp.ChgDestWarehouseCode);
            //�q�ɒI��
            writer.Write(temp.ChgDestWarehouseShelfNo);
            //�d���I�ԂP
            writer.Write(temp.ChgDestDuplicationShelfNo1);
            //�d���I�ԂQ
            writer.Write(temp.ChgDestDuplicationShelfNo2);
            //�o�׉\��
            writer.Write(temp.ChgDestShipmentPosCnt);

        }

        /// <summary>
        ///  PartsSubstUSearchResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsSubstUSearchResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsSubstUSearchResultWork GetPartsSubstUSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsSubstUSearchResultWork temp = new PartsSubstUSearchResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�ϊ������[�J�[�R�[�h
            temp.ChgSrcMakerCd = reader.ReadInt32();
            //�ϊ������i�ԍ�
            temp.ChgSrcGoodsNo = reader.ReadString();
            //�n�C�t�����ϊ������i�ԍ�
            temp.ChgSrcGoodsNoNoneHp = reader.ReadString();
            //�q�ɃR�[�h
            temp.ChgSrcWarehouseCode = reader.ReadString();
            //�q�ɒI��
            temp.ChgSrcWarehouseShelfNo = reader.ReadString();
            //�d���I�ԂP
            temp.ChgSrcDuplicationShelfNo1 = reader.ReadString();
            //�d���I�ԂQ
            temp.ChgSrcDuplicationShelfNo2 = reader.ReadString();
            //�o�׉\��
            temp.ChgSrcShipmentPosCnt = reader.ReadDouble();
            //�ϊ��惁�[�J�[�R�[�h
            temp.ChgDestMakerCd = reader.ReadInt32();
            //�ϊ��揤�i�ԍ�
            temp.ChgDestGoodsNo = reader.ReadString();
            //�n�C�t�����ϊ��揤�i�ԍ�
            temp.ChgDestGoodsNoNoneHp = reader.ReadString();
            //�q�ɃR�[�h
            temp.ChgDestWarehouseCode = reader.ReadString();
            //�q�ɒI��
            temp.ChgDestWarehouseShelfNo = reader.ReadString();
            //�d���I�ԂP
            temp.ChgDestDuplicationShelfNo1 = reader.ReadString();
            //�d���I�ԂQ
            temp.ChgDestDuplicationShelfNo2 = reader.ReadString();
            //�o�׉\��
            temp.ChgDestShipmentPosCnt = reader.ReadDouble();


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
        /// <returns>PartsSubstUSearchResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstUSearchResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsSubstUSearchResultWork temp = GetPartsSubstUSearchResultWork(reader, serInfo);
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
                    retValue = (PartsSubstUSearchResultWork[])lst.ToArray(typeof(PartsSubstUSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
