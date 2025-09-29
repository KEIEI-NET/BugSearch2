//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ� 
// �v���O�����T�v   : ���Е��i���������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/19  �C�����e : Redmine#17394
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/24  �C�����e : Redmine#17451
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ScmInqLogInquiryWork
    /// <summary>
    ///                      SCM�⍇�����O�⍇�����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�⍇�����O�⍇�����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/10/14</br>
    /// <br>Genarated Date   :   2010/11/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ScmInqLogInquiryWork
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�A������Ɩ���</summary>
        private string _cnectOriginalEpNm = "";

        /// <summary>�⍇�����f�[�^���̓V�X�e��</summary>
        /// <remarks>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</remarks>
        private Int32 _inqDataInputSystem;

        /// <summary>SCM�⍇�����e</summary>
        /// <remarks>nvarchar(max)</remarks>
        private string _scmInqContents = "";


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

        /// public propaty name  :  CnectOriginalEpNm
        /// <summary>�A������Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A������Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectOriginalEpNm
        {
            get { return _cnectOriginalEpNm; }
            set { _cnectOriginalEpNm = value; }
        }

        /// public propaty name  :  InqDataInputSystem
        /// <summary>�⍇�����f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqDataInputSystem
        {
            get { return _inqDataInputSystem; }
            set { _inqDataInputSystem = value; }
        }

        /// public propaty name  :  ScmInqContents
        /// <summary>SCM�⍇�����e�v���p�e�B</summary>
        /// <value>nvarchar(max)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM�⍇�����e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ScmInqContents
        {
            get { return _scmInqContents; }
            set { _scmInqContents = value; }
        }


        /// <summary>
        /// SCM�⍇�����O�⍇�����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ScmInqLogInquiryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquiryWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ScmInqLogInquiryWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ScmInqLogInquiryWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquiryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ScmInqLogInquiryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquiryWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ScmInqLogInquiryWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !( graph is ScmInqLogInquiryWork || graph is ArrayList || graph is ScmInqLogInquiryWork[] ))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ScmInqLogInquiryWork).FullName));

            if (graph != null && graph is ScmInqLogInquiryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ScmInqLogInquiryWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ( (ArrayList)graph ).Count;
            }
            else if (graph is ScmInqLogInquiryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ( (ScmInqLogInquiryWork[])graph ).Length;
            }
            else if (graph is ScmInqLogInquiryWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�A������Ɩ���
            serInfo.MemberInfo.Add(typeof(string)); //CnectOriginalEpNm
            //�⍇�����f�[�^���̓V�X�e��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqDataInputSystem
            //SCM�⍇�����e
            serInfo.MemberInfo.Add(typeof(string)); //ScmInqContents


            serInfo.Serialize(writer, serInfo);
            if (graph is ScmInqLogInquiryWork)
            {
                ScmInqLogInquiryWork temp = (ScmInqLogInquiryWork)graph;

                SetScmInqLogInquiryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ScmInqLogInquiryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ScmInqLogInquiryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ScmInqLogInquiryWork temp in lst)
                {
                    SetScmInqLogInquiryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ScmInqLogInquiryWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  ScmInqLogInquiryWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquiryWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetScmInqLogInquiryWork(System.IO.BinaryWriter writer, ScmInqLogInquiryWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�A������Ɩ���
            writer.Write(temp.CnectOriginalEpNm);
            //�⍇�����f�[�^���̓V�X�e��
            writer.Write(temp.InqDataInputSystem);
            //SCM�⍇�����e
            writer.Write(temp.ScmInqContents);

        }

        /// <summary>
        ///  ScmInqLogInquiryWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ScmInqLogInquiryWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquiryWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ScmInqLogInquiryWork GetScmInqLogInquiryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ScmInqLogInquiryWork temp = new ScmInqLogInquiryWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�A������Ɩ���
            temp.CnectOriginalEpNm = reader.ReadString();
            //�⍇�����f�[�^���̓V�X�e��
            temp.InqDataInputSystem = reader.ReadInt32();
            //SCM�⍇�����e
            temp.ScmInqContents = reader.ReadString();


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
        /// <returns>ScmInqLogInquiryWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ScmInqLogInquiryWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ScmInqLogInquiryWork temp = GetScmInqLogInquiryWork(reader, serInfo);
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
                    retValue = (ScmInqLogInquiryWork[])lst.ToArray(typeof(ScmInqLogInquiryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
