//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
// �v���O�����T�v   : �L�����y�[���Ώۏ��i�ݒ�}�X�^�ꊇ�폜
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CampaignGoodsDataWork
    /// <summary>
    ///                      �L�����y�[���Ǘ����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���Ǘ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2011/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CampaignGoodsDataWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i��</summary>
        private string _headerGoodsNo = "";

        /// <summary>�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜����</summary>
        private Int32 _goodsStCount;

        /// <summary>�L�����y�[�����̐ݒ�}�X�^�폜����</summary>
        private Int32 _nameStCount;

        /// <summary>�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜����</summary>
        private Int32 _customStCount;

        /// <summary>�L�����y�[���ڕW�ݒ�}�X�^�폜����</summary>
        private Int32 _targetStCount;

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>Ұ����</summary>
        private string _goodsMakerNm = "";

        /// <summary>��ƺ���</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";


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

        /// public propaty name  :  HeaderGoodsNo
        /// <summary>���i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HeaderGoodsNo
        {
            get { return _headerGoodsNo; }
            set { _headerGoodsNo = value; }
        }

        /// public propaty name  :  GoodsStCount
        /// <summary>�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۏ��i�ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsStCount
        {
            get { return _goodsStCount; }
            set { _goodsStCount = value; }
        }

        /// public propaty name  :  NameStCount
        /// <summary>�L�����y�[�����̐ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̐ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NameStCount
        {
            get { return _nameStCount; }
            set { _nameStCount = value; }
        }

        /// public propaty name  :  CustomStCount
        /// <summary>�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomStCount
        {
            get { return _customStCount; }
            set { _customStCount = value; }
        }

        /// public propaty name  :  TargetStCount
        /// <summary>�L�����y�[���ڕW�ݒ�}�X�^�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���ڕW�ݒ�}�X�^�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetStCount
        {
            get { return _targetStCount; }
            set { _targetStCount = value; }
        }

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>Ұ�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ұ�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƺ��ރv���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƺ��ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }


        /// <summary>
        /// �L�����y�[���Ǘ����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignGoodsDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignGoodsDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CampaignGoodsDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CampaignGoodsDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CampaignGoodsDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CampaignGoodsDataWork || graph is ArrayList || graph is CampaignGoodsDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CampaignGoodsDataWork).FullName));

            if (graph != null && graph is CampaignGoodsDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CampaignGoodsDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CampaignGoodsDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CampaignGoodsDataWork[])graph).Length;
            }
            else if (graph is CampaignGoodsDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i��
            serInfo.MemberInfo.Add(typeof(string)); //HeaderGoodsNo
            //�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsStCount
            //�L�����y�[�����̐ݒ�}�X�^�폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //NameStCount
            //�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomStCount
            //�L�����y�[���ڕW�ݒ�}�X�^�폜����
            serInfo.MemberInfo.Add(typeof(Int32)); //TargetStCount
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //Ұ����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //��ƺ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode


            serInfo.Serialize(writer, serInfo);
            if (graph is CampaignGoodsDataWork)
            {
                CampaignGoodsDataWork temp = (CampaignGoodsDataWork)graph;

                SetCampaignGoodsDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CampaignGoodsDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CampaignGoodsDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CampaignGoodsDataWork temp in lst)
                {
                    SetCampaignGoodsDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CampaignGoodsDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  CampaignGoodsDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCampaignGoodsDataWork(System.IO.BinaryWriter writer, CampaignGoodsDataWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i��
            writer.Write(temp.HeaderGoodsNo);
            //�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜����
            writer.Write(temp.GoodsStCount);
            //�L�����y�[�����̐ݒ�}�X�^�폜����
            writer.Write(temp.NameStCount);
            //�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜����
            writer.Write(temp.CustomStCount);
            //�L�����y�[���ڕW�ݒ�}�X�^�폜����
            writer.Write(temp.TargetStCount);
            //���_����
            writer.Write(temp.SectionName);
            //Ұ����
            writer.Write(temp.GoodsMakerNm);
            //��ƺ���
            writer.Write(temp.EnterpriseCode);

        }

        /// <summary>
        ///  CampaignGoodsDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CampaignGoodsDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CampaignGoodsDataWork GetCampaignGoodsDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CampaignGoodsDataWork temp = new CampaignGoodsDataWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i��
            temp.HeaderGoodsNo = reader.ReadString();
            //�L�����y�[���Ώۏ��i�ݒ�}�X�^�폜����
            temp.GoodsStCount = reader.ReadInt32();
            //�L�����y�[�����̐ݒ�}�X�^�폜����
            temp.NameStCount = reader.ReadInt32();
            //�L�����y�[���Ώۓ��Ӑ�ݒ�}�X�^�폜����
            temp.CustomStCount = reader.ReadInt32();
            //�L�����y�[���ڕW�ݒ�}�X�^�폜����
            temp.TargetStCount = reader.ReadInt32();
            //���_����
            temp.SectionName = reader.ReadString();
            //Ұ����
            temp.GoodsMakerNm = reader.ReadString();
            //��ƺ���
            temp.EnterpriseCode = reader.ReadString();


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
        /// <returns>CampaignGoodsDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignGoodsDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CampaignGoodsDataWork temp = GetCampaignGoodsDataWork(reader, serInfo);
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
                    retValue = (CampaignGoodsDataWork[])lst.ToArray(typeof(CampaignGoodsDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
