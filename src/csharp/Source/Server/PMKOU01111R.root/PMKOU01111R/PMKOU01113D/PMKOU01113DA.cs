//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d�������W�v�f�[�^�X�V�p�����[�^���[�N
//                  :   PMKOU01113D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.12.12
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
    /// public class name:   MTtlStockUpdParaWork
    /// <summary>
    ///                      �d�������W�v�f�[�^�X�V�p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�������W�v�f�[�^�X�V�p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlStockUpdParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�d�����_�R�[�h</summary>
        private string _stockSectionCd = "";

        // ---ADD 2009/12/24 -------->>>
        /// <summary>�v�㋒�_�R�[�h�J�n</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _stockSectionCdSt = "";

        /// <summary>�v�㋒�_�R�[�h�I��</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _stockSectionCdEd = "";
        // ---ADD 2009/12/24 --------<<<

        /// <summary>�d���N��(�J�n)</summary>
        /// <remarks>YYYYMM 0:���ݒ�</remarks>
        private Int32 _stockDateYmSt;

        /// <summary>�d���N��(�I��)</summary>
        /// <remarks>YYYYMM 0:���ݒ�</remarks>
        private Int32 _stockDateYmEd;

        /// <summary>�`�[�o�^�敪</summary>
        /// <remarks>0:�폜 1:�o�^ 2:�ďW�v</remarks>
        private Int32 _slipRegDiv;


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

        /// public propaty name  :  StockSectionCd
        /// <summary>�d�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCd
        {
            get { return _stockSectionCd; }
            set { _stockSectionCd = value; }
        }

        // ---ADD 2009/12/24 -------->>>
        /// public propaty name  :  StockSectionCdSt
        /// <summary>�d�����_�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCdSt
        {
            get { return _stockSectionCdSt; }
            set { _stockSectionCdSt = value; }
        }

        /// public propaty name  :  StockSectionCdEd
        /// <summary>�d�����_�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����_�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockSectionCdEd
        {
            get { return _stockSectionCdEd; }
            set { _stockSectionCdEd = value; }
        }
        // ---ADD 2009/12/24 --------<<<

        /// public propaty name  :  StockDateYmSt
        /// <summary>�d���N��(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMM 0:���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���N��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDateYmSt
        {
            get { return _stockDateYmSt; }
            set { _stockDateYmSt = value; }
        }

        /// public propaty name  :  StockDateYmEd
        /// <summary>�d���N��(�I��)�v���p�e�B</summary>
        /// <value>YYYYMM 0:���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���N��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDateYmEd
        {
            get { return _stockDateYmEd; }
            set { _stockDateYmEd = value; }
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


        /// <summary>
        /// �d�������W�v�f�[�^�X�V�p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MTtlStockUpdParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlStockUpdParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MTtlStockUpdParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MTtlStockUpdParaWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MTtlStockUpdParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MTtlStockUpdParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlStockUpdParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlStockUpdParaWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlStockUpdParaWork || graph is ArrayList || graph is MTtlStockUpdParaWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MTtlStockUpdParaWork).FullName));

            if (graph != null && graph is MTtlStockUpdParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlStockUpdParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlStockUpdParaWork[])graph).Length;
            }
            else if (graph is MTtlStockUpdParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�d�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCd

            // ---ADD 2009/12/24 -------->>>
            //�d�����_�R�[�h(�J�n)
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCdSt
            //�d�����_�R�[�h(�I��)
            serInfo.MemberInfo.Add(typeof(string)); //StockSectionCdEd
            // ---ADD 2009/12/24 --------<<<

            //�d���N��(�J�n)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateYmSt
            //�d���N��(�I��)
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDateYmEd
            //�`�[�o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipRegDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlStockUpdParaWork)
            {
                MTtlStockUpdParaWork temp = (MTtlStockUpdParaWork)graph;

                SetMTtlStockUpdParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlStockUpdParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlStockUpdParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlStockUpdParaWork temp in lst)
                {
                    SetMTtlStockUpdParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlStockUpdParaWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  MTtlStockUpdParaWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlStockUpdParaWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMTtlStockUpdParaWork(System.IO.BinaryWriter writer, MTtlStockUpdParaWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�d�����_�R�[�h
            writer.Write(temp.StockSectionCd);

            // ---ADD 2009/12/24 -------->>>
            //�d�����_�R�[�h(�J�n)
            writer.Write(temp.StockSectionCdSt);
            //�d�����_�R�[�h(�I��)
            writer.Write(temp.StockSectionCdEd);
            // ---ADD 2009/12/24 --------<<<

            //�d���N��(�J�n)
            writer.Write(temp.StockDateYmSt);
            //�d���N��(�I��)
            writer.Write(temp.StockDateYmEd);
            //�`�[�o�^�敪
            writer.Write(temp.SlipRegDiv);

        }

        /// <summary>
        ///  MTtlStockUpdParaWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MTtlStockUpdParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlStockUpdParaWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MTtlStockUpdParaWork GetMTtlStockUpdParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MTtlStockUpdParaWork temp = new MTtlStockUpdParaWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�d�����_�R�[�h
            temp.StockSectionCd = reader.ReadString();

            // ---ADD 2009/12/24 -------->>>
            //�d�����_�R�[�h(�J�n)
            temp.StockSectionCdSt = reader.ReadString();
            //�d�����_�R�[�h(�I��)
            temp.StockSectionCdEd = reader.ReadString();
            // ---ADD 2009/12/24 --------<<<

            //�d���N��(�J�n)
            temp.StockDateYmSt = reader.ReadInt32();
            //�d���N��(�I��)
            temp.StockDateYmEd = reader.ReadInt32();
            //�`�[�o�^�敪
            temp.SlipRegDiv = reader.ReadInt32();


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
        /// <returns>MTtlStockUpdParaWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MTtlStockUpdParaWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlStockUpdParaWork temp = GetMTtlStockUpdParaWork(reader, serInfo);
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
                    retValue = (MTtlStockUpdParaWork[])lst.ToArray(typeof(MTtlStockUpdParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
