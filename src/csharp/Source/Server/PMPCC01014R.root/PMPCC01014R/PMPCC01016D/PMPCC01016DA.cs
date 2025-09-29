//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����b�Z�[�W�ݒ菈�����o���ʃ��[�N
// �v���O�����T�v   : ���[�����b�Z�[�W�ݒ菈�����o���ʃ��[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2011.08.09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PccMailDtWork
    /// <summary>
    ///                      ���[�����b�Z�[�W�ݒ菈�����o���ʃ��[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�����b�Z�[�W�ݒ菈�����o���ʃ��[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011.08.09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PccMailDtWork
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>�X�V�����b�~���b</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>PCC���[������</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccMailTitle = "";

        /// <summary>PCC���[���{��</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _pccMailDocCnts = "";

        /// <summary>�Ώۓ��J�n</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDateSt;

        /// <summary>�Ώۓ��I��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDateEd;

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N����</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>�X�V�����b�~���b</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����b�~���b</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  PccMailTitle
        /// <summary>PCC���[������</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���[������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccMailTitle
        {
            get { return _pccMailTitle; }
            set { _pccMailTitle = value; }
        }

        /// public propaty name  :  PccMailDocCnts
        /// <summary>PCC���[���{��</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���[���{��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccMailDocCnts
        {
            get { return _pccMailDocCnts; }
            set { _pccMailDocCnts = value; }
        }

        /// public propaty name  :  UpdateDateSt
        /// <summary>�Ώۓ��J�n</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��J�n</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDateSt
        {
            get { return _updateDateSt; }
            set { _updateDateSt = value; }
        }

        /// public propaty name  :  UpdateDateEd
        /// <summary>�Ώۓ��I��</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώۓ��I��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDateEd
        {
            get { return _updateDateEd; }
            set { _updateDateEd = value; }
        }



        /// <summary>
        /// ���[�����b�Z�[�W�ݒ菈�����o���ʃ��[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PccMailDtWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDtWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccMailDtWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PccMailDtWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PccMailDtWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PccMailDtWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDtWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PccMailDtWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PccMailDtWork || graph is ArrayList || graph is PccMailDtWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PccMailDtWork).FullName));

            if (graph != null && graph is PccMailDtWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PccMailDtWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PccMailDtWork[])graph).Length;
            }
            else if (graph is PccMailDtWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V�����b�~���b
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //PCC���[������
            serInfo.MemberInfo.Add(typeof(string)); //PccMailTitle
            //PCC���[���{��
            serInfo.MemberInfo.Add(typeof(string)); //PccMailDocCnts
            //�Ώۓ��J�n
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDateSt
            //�Ώۓ��I��
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDateEd



            serInfo.Serialize(writer, serInfo);
            if (graph is PccMailDtWork)
            {
                PccMailDtWork temp = (PccMailDtWork)graph;

                SetPccMailDtWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PccMailDtWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PccMailDtWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PccMailDtWork temp in lst)
                {
                    SetPccMailDtWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PccMailDtWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 13;

        /// <summary>
        ///  PccMailDtWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDtWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPccMailDtWork(System.IO.BinaryWriter writer, PccMailDtWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write((Int32)temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //�X�V�N����
            writer.Write((Int32)temp.UpdateDate);
            //�X�V�����b�~���b
            writer.Write((Int32)temp.UpdateTime);
            //PCC���[������
            writer.Write(temp.PccMailTitle);
            //PCC���[���{��
            writer.Write(temp.PccMailDocCnts);
            //�Ώۓ��J�n
            writer.Write((Int32)temp.UpdateDateSt);
            //�Ώۓ��I��
            writer.Write((Int32)temp.UpdateDateEd);


        }

        /// <summary>
        ///  PccMailDtWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PccMailDtWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDtWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PccMailDtWork GetPccMailDtWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PccMailDtWork temp = new PccMailDtWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //�X�V�N����
            temp.UpdateDate = reader.ReadInt32();
            //�X�V�����b�~���b
            temp.UpdateTime = reader.ReadInt32();
            //PCC���[������
            temp.PccMailTitle = reader.ReadString();
            //PCC���[���{��
            temp.PccMailDocCnts = reader.ReadString();
            //�Ώۓ��J�n
            temp.UpdateDateSt = reader.ReadInt32();
            //�Ώۓ��I��
            temp.UpdateDateEd = reader.ReadInt32();



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
        /// <returns>PccMailDtWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccMailDtWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PccMailDtWork temp = GetPccMailDtWork(reader, serInfo);
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
                    retValue = (PccMailDtWork[])lst.ToArray(typeof(PccMailDtWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
