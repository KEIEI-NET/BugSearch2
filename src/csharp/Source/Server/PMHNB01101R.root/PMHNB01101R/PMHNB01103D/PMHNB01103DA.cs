//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���㌎���W�v�f�[�^�X�V�p�����[�^���[�N
//                  :   PMHNB01103D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc�@��
// Date             :   2008.05.19
//----------------------------------------------------------------------
// Update Note      :�@ 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C
//                             �E�ꊇ���A���X�V�̐V�K��Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSalesUpdParaWork
    /// <summary>
    /// ���㌎���W�v�f�[�^�X�V�p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㌎���W�v�f�[�^�X�V�p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlSalesUpdParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�v��N��(�J�n)</summary>
        /// <remarks>YYYYMM�`�� 0:���ݒ�</remarks>
        private Int32 _addUpYearMonthSt;

        /// <summary>�v��N��(�I��)</summary>
        /// <remarks>YYYYMM�`�� 0:���ݒ�</remarks>
        private Int32 _addUpYearMonthEd;

        /// <summary>�`�[�o�^�敪</summary>
        /// <remarks>0:�폜 1:�o�^</remarks>
        private Int32 _slipRegDiv;

        /// <summary>���㌎���W�v�f�[�^�����Ώۃt���O</summary>
        /// <remarks>0:��Ώ� 1:�Ώ�</remarks>
        private Int32 _mTtlSalesPrcFlg;

        /// <summary>���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O</summary>
        /// <remarks>0:��Ώ� 1:�Ώ�</remarks>
        private Int32 _goodsMTtlSaPrcFlg;

        // ---ADD 2009/12/24 -------->>>
        /// <summary>�v�㋒�_�R�[�h�J�n</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCodeSt = "";

        /// <summary>�v�㋒�_�R�[�h�I��</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCodeEd = "";
        // ---ADD 2009/12/24 --------<<<


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
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

        // ---ADD 2009/12/24 -------->>>
        /// public propaty name  :  AddUpSecCodeSt
        /// <summary>�v�㋒�_�R�[�h�J�n�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCodeSt
        {
            get { return _addUpSecCodeSt; }
            set { _addUpSecCodeSt = value; }
        }

        /// public propaty name  :  AddUpSecCodeEd
        /// <summary>�v�㋒�_�R�[�h�I���v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCodeEd
        {
            get { return _addUpSecCodeEd; }
            set { _addUpSecCodeEd = value; }
        }
        // ---ADD 2009/12/24 --------<<<

        /// public propaty name  :  AddUpYearMonthSt
        /// <summary>�v��N��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMM�`�� 0:���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpYearMonthSt
        {
            get { return _addUpYearMonthSt; }
            set { _addUpYearMonthSt = value; }
        }

        /// public propaty name  :  AddUpYearMonthEd
        /// <summary>�v��N��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMM�`�� 0:���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpYearMonthEd
        {
            get { return _addUpYearMonthEd; }
            set { _addUpYearMonthEd = value; }
        }

        /// public propaty name  :  SlipRegDiv
        /// <summary>�`�[�o�^�敪�v���p�e�B</summary>
        /// <value>0:�폜 1:�o�^ 2:�ďW�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipRegDiv
        {
            get { return _slipRegDiv; }
            set { _slipRegDiv = value; }
        }

        /// public propaty name  :  MTtlSalesPrcFlg
        /// <summary>���㌎���W�v�f�[�^�����Ώۃt���O�v���p�e�B</summary>
        /// <value>0:��Ώ� 1:�Ώ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎���W�v�f�[�^�����Ώۃt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MTtlSalesPrcFlg
        {
            get { return _mTtlSalesPrcFlg; }
            set { _mTtlSalesPrcFlg = value; }
        }

        /// public propaty name  :  GoodsMTtlSaPrcFlg
        /// <summary>���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O�v���p�e�B</summary>
        /// <value>0:��Ώ� 1:�Ώ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMTtlSaPrcFlg
        {
            get { return _goodsMTtlSaPrcFlg; }
            set { _goodsMTtlSaPrcFlg = value; }
        }


        /// <summary>
        /// ���㌎���W�v�f�[�^�X�V�p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MTtlSalesUpdParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesUpdParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MTtlSalesUpdParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MTtlSalesUpdParaWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MTtlSalesUpdParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MTtlSalesUpdParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesUpdParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlSalesUpdParaWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlSalesUpdParaWork || graph is ArrayList || graph is MTtlSalesUpdParaWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MTtlSalesUpdParaWork).FullName));

            if (graph != null && graph is MTtlSalesUpdParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlSalesUpdParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlSalesUpdParaWork[])graph).Length;
            }
            else if (graph is MTtlSalesUpdParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode

            // ---ADD 2009/12/24 -------->>>
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCodeSt
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCodeEd
            // ---ADD 2009/12/24 --------<<<

            //�v��N��(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonthSt
            //�v��N��(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonthEd
            //�`�[�o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipRegDiv
            //���㌎���W�v�f�[�^�����Ώۃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //MTtlSalesPrcFlg
            //���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMTtlSaPrcFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlSalesUpdParaWork)
            {
                MTtlSalesUpdParaWork temp = (MTtlSalesUpdParaWork)graph;

                SetMTtlSalesUpdParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlSalesUpdParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlSalesUpdParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlSalesUpdParaWork temp in lst)
                {
                    SetMTtlSalesUpdParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlSalesUpdParaWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 7;

        /// <summary>
        ///  MTtlSalesUpdParaWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesUpdParaWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMTtlSalesUpdParaWork(System.IO.BinaryWriter writer, MTtlSalesUpdParaWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);

            // ---ADD 2009/12/24 -------->>>
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCodeSt);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCodeEd);
            // ---ADD 2009/12/24 --------<<<

            //�v��N��(�J�n)
            writer.Write(temp.AddUpYearMonthSt);
            //�v��N��(�I��)
            writer.Write(temp.AddUpYearMonthEd);
            //�`�[�o�^�敪
            writer.Write(temp.SlipRegDiv);
            //���㌎���W�v�f�[�^�����Ώۃt���O
            writer.Write(temp.MTtlSalesPrcFlg);
            //���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O
            writer.Write(temp.GoodsMTtlSaPrcFlg);

        }

        /// <summary>
        ///  MTtlSalesUpdParaWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MTtlSalesUpdParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesUpdParaWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MTtlSalesUpdParaWork GetMTtlSalesUpdParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MTtlSalesUpdParaWork temp = new MTtlSalesUpdParaWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();

            // ---ADD 2009/12/24 -------->>>
            //�v�㋒�_�R�[�h
            temp.AddUpSecCodeSt = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCodeEd = reader.ReadString();
            // ---ADD 2009/12/24 --------<<<

            //�v��N��(�J�n)
            temp.AddUpYearMonthSt = reader.ReadInt32();
            //�v��N��(�I��)
            temp.AddUpYearMonthEd = reader.ReadInt32();
            //�`�[�o�^�敪
            temp.SlipRegDiv = reader.ReadInt32();
            //���㌎���W�v�f�[�^�����Ώۃt���O
            temp.MTtlSalesPrcFlg = reader.ReadInt32();
            //���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O
            temp.GoodsMTtlSaPrcFlg = reader.ReadInt32();


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
        /// <returns>MTtlSalesUpdParaWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlSalesUpdParaWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlSalesUpdParaWork temp = GetMTtlSalesUpdParaWork(reader, serInfo);
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
                    retValue = (MTtlSalesUpdParaWork[])lst.ToArray(typeof(MTtlSalesUpdParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
