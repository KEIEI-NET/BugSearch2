using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePrtItmSetPrmWork
    /// <summary>
    ///                      ���R���[�󎚍��ڃp�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�󎚍��ڃp�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/7/23</br>
    /// <br>Genarated Date   :   2007/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePrtItmSetPrmWork
    {
        /// <summary>
        /// ���R���[�󎚍��ڃp�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FrePrtItmSetPrmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePrtItmSetPrmWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePrtItmSetPrmWork()
        {
        }

        /// <summary>
        /// �R���X�g���N�^�F�I�[�o�[���[�h(+1)
        /// </summary>
        /// <param name="fileNm">�t�@�C������</param>
        /// <param name="ddName">DD����</param>
        /// <param name="ddCharCnt">DD����</param>
        /// <param name="cipherFlg">�Í����t���O</param>
        /// <param name="extractionItdedFlg">���o�Ώۃt���O</param>
        public FrePrtItmSetPrmWork(string fileNm,string ddName, int ddCharCnt,int cipherFlg,int extractionItdedFlg)
		{
            _fileNm = fileNm;
            _dDName = ddName;
            _dDCharCnt = ddCharCnt;
            _cipherFlg = cipherFlg;
            _extractionItdedFlg = extractionItdedFlg;
        }

        /// <summary>�t�@�C������</summary>
        /// <remarks>DB�̃e�[�u��ID</remarks>
        private string _fileNm = "";

        /// <summary>DD����</summary>
        /// <remarks>�������œo�^</remarks>
        private string _dDName = "";

        /// <summary>DD����</summary>
        private Int32 _dDCharCnt;

        /// <summary>�Í����t���O</summary>
        /// <remarks>0:�Í������@1:�Í����L</remarks>
        private Int32 _cipherFlg;

        /// <summary>���o�Ώۃt���O</summary>
        /// <remarks>0:��Ώ� 1:�Ώ�    (����ID�͉�)</remarks>
        private Int32 _extractionItdedFlg;


        /// public propaty name  :  FileNm
        /// <summary>�t�@�C�����̃v���p�e�B</summary>
        /// <value>DB�̃e�[�u��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileNm
        {
            get { return _fileNm; }
            set { _fileNm = value; }
        }

        /// public propaty name  :  DDName
        /// <summary>DD���̃v���p�e�B</summary>
        /// <value>�������œo�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DD���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DDName
        {
            get { return _dDName; }
            set { _dDName = value; }
        }

        /// public propaty name  :  DDCharCnt
        /// <summary>DD�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DD�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DDCharCnt
        {
            get { return _dDCharCnt; }
            set { _dDCharCnt = value; }
        }

        /// public propaty name  :  CipherFlg
        /// <summary>�Í����t���O�v���p�e�B</summary>
        /// <value>0:�Í������@1:�Í����L</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Í����t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CipherFlg
        {
            get { return _cipherFlg; }
            set { _cipherFlg = value; }
        }

        /// public propaty name  :  ExtractionItdedFlg
        /// <summary>���o�Ώۃt���O�v���p�e�B</summary>
        /// <value>0:��Ώ� 1:�Ώ�    (����ID�͉�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�Ώۃt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExtractionItdedFlg
        {
            get { return _extractionItdedFlg; }
            set { _extractionItdedFlg = value; }
        }
    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>FrePrtItmSetPrmWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   FrePrtItmSetPrmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class FrePrtItmSetPrmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o
        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePrtItmSetPrmWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  FrePrtItmSetPrmWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is FrePrtItmSetPrmWork || graph is ArrayList || graph is FrePrtItmSetPrmWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(FrePrtItmSetPrmWork).FullName));

            if (graph != null && graph is FrePrtItmSetPrmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePrtItmSetPrmWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is FrePrtItmSetPrmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePrtItmSetPrmWork[])graph).Length;
            }
            else if (graph is FrePrtItmSetPrmWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�t�@�C������
            serInfo.MemberInfo.Add(typeof(string)); //FileNm
            //DD����
            serInfo.MemberInfo.Add(typeof(string)); //DDName
            //DD����
            serInfo.MemberInfo.Add(typeof(Int32)); //DDCharCnt
            //�Í����t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //CipherFlg
            //���o�Ώۃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //ExtraTrgFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is FrePrtItmSetPrmWork)
            {
                FrePrtItmSetPrmWork temp = (FrePrtItmSetPrmWork)graph;

                SetFrePrtItmSetPrmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is FrePrtItmSetPrmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((FrePrtItmSetPrmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (FrePrtItmSetPrmWork temp in lst)
                {
                    SetFrePrtItmSetPrmWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// FrePrtItmSetPrmWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  FrePrtItmSetPrmWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePrtItmSetPrmWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetFrePrtItmSetPrmWork(System.IO.BinaryWriter writer, FrePrtItmSetPrmWork temp)
        {
            //�t�@�C������
            writer.Write(temp.FileNm);
            //DD����
            writer.Write(temp.DDName);
            //DD����
            writer.Write(temp.DDCharCnt);
            //�Í����t���O
            writer.Write(temp.CipherFlg);
            //���o�Ώۃt���O
            writer.Write(temp.ExtractionItdedFlg);

        }

        /// <summary>
        ///  FrePrtItmSetPrmWork�C���X�^���X�擾
        /// </summary>
        /// <returns>FrePrtItmSetPrmWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePrtItmSetPrmWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private FrePrtItmSetPrmWork GetFrePrtItmSetPrmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            FrePrtItmSetPrmWork temp = new FrePrtItmSetPrmWork();

            //�t�@�C������
            temp.FileNm = reader.ReadString();
            //DD����
            temp.DDName = reader.ReadString();
            //DD����
            temp.DDCharCnt = reader.ReadInt32();
            //�Í����t���O
            temp.CipherFlg = reader.ReadInt32();
            //���o�Ώۃt���O
            temp.ExtractionItdedFlg = reader.ReadInt32();


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
        /// <returns>FrePrtItmSetPrmWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePrtItmSetPrmWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                FrePrtItmSetPrmWork temp = GetFrePrtItmSetPrmWork(reader, serInfo);
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
                    retValue = (FrePrtItmSetPrmWork[])lst.ToArray(typeof(FrePrtItmSetPrmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}