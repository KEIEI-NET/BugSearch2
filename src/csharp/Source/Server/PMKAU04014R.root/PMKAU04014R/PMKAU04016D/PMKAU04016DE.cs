using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
    # region // DEL
    ///// public class name:   CustPrtPprBlTblRsltWork
    ///// <summary>
    /////                      ���Ӑ�d�q�������o����(�c���ꗗ)�N���X���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   ���Ӑ�d�q�������o����(�c���ꗗ)�N���X���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/08/05  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class CustPrtPprBlTblRsltWork
    //{
    //    /// <summary>�v���</summary>
    //    /// <remarks>�v��N����(YYYYMMDD)</remarks>
    //    private DateTime _addUpDate;

    //    /// <summary>�O��c��</summary>
    //    /// <remarks>�O�񐿋����z/�O�񔄊|���z</remarks>
    //    private Int64 _lastTimeBlc;

    //    /// <summary>��������z</summary>
    //    /// <remarks>����������z�i�ʏ�����j</remarks>
    //    private Int64 _thisTimeDmdNrml;

    //    /// <summary>�J�z�c��</summary>
    //    /// <remarks>����J�z�c���i�����v�j/����J�z�c���i���|�v�j</remarks>
    //    private Int64 _thisTimeTtlBlc;

    //    /// <summary>���񔄏�</summary>
    //    /// <remarks>���񔄏���z</remarks>
    //    private Int64 _thisTimeSales;

    //    /// <summary>�ԕi�l��</summary>
    //    /// <remarks>���񔄏�ԕi���z+���񔄏�l�����z</remarks>
    //    private Int64 _salesPricRgdsDis;

    //    /// <summary>������z</summary>
    //    /// <remarks>���E�㍡�񔄏���z</remarks>
    //    private Int64 _ofsThisTimeSales;

    //    /// <summary>�����</summary>
    //    /// <remarks>���E�㍡�񔄏�����</remarks>
    //    private Int64 _ofsThisSalesTax;

    //    /// <summary>���񍇌v</summary>
    //    /// <remarks>������z+�����</remarks>
    //    private Int64 _thisSalesPricTotal;

    //    /// <summary>����c��</summary>
    //    /// <remarks>�v�Z�㐿�����z/�v�Z�㓖�����|���z</remarks>
    //    private Int64 _afCalBlc;

    //    /// <summary>�`�[����</summary>
    //    /// <remarks>����`�[����</remarks>
    //    private Int32 _salesSlipCount;


    //    /// public propaty name  :  AddUpDate
    //    /// <summary>�v����v���p�e�B</summary>
    //    /// <value>�v��N����(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime AddUpDate
    //    {
    //        get { return _addUpDate; }
    //        set { _addUpDate = value; }
    //    }

    //    /// public propaty name  :  LastTimeBlc
    //    /// <summary>�O��c���v���p�e�B</summary>
    //    /// <value>�O�񐿋����z/�O�񔄊|���z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �O��c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 LastTimeBlc
    //    {
    //        get { return _lastTimeBlc; }
    //        set { _lastTimeBlc = value; }
    //    }

    //    /// public propaty name  :  ThisTimeDmdNrml
    //    /// <summary>��������z�v���p�e�B</summary>
    //    /// <value>����������z�i�ʏ�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ��������z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimeDmdNrml
    //    {
    //        get { return _thisTimeDmdNrml; }
    //        set { _thisTimeDmdNrml = value; }
    //    }

    //    /// public propaty name  :  ThisTimeTtlBlc
    //    /// <summary>�J�z�c���v���p�e�B</summary>
    //    /// <value>����J�z�c���i�����v�j/����J�z�c���i���|�v�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �J�z�c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimeTtlBlc
    //    {
    //        get { return _thisTimeTtlBlc; }
    //        set { _thisTimeTtlBlc = value; }
    //    }

    //    /// public propaty name  :  ThisTimeSales
    //    /// <summary>���񔄏�v���p�e�B</summary>
    //    /// <value>���񔄏���z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���񔄏�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimeSales
    //    {
    //        get { return _thisTimeSales; }
    //        set { _thisTimeSales = value; }
    //    }

    //    /// public propaty name  :  SalesPricRgdsDis
    //    /// <summary>�ԕi�l���v���p�e�B</summary>
    //    /// <value>���񔄏�ԕi���z+���񔄏�l�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԕi�l���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 SalesPricRgdsDis
    //    {
    //        get { return _salesPricRgdsDis; }
    //        set { _salesPricRgdsDis = value; }
    //    }

    //    /// public propaty name  :  OfsThisTimeSales
    //    /// <summary>������z�v���p�e�B</summary>
    //    /// <value>���E�㍡�񔄏���z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ������z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 OfsThisTimeSales
    //    {
    //        get { return _ofsThisTimeSales; }
    //        set { _ofsThisTimeSales = value; }
    //    }

    //    /// public propaty name  :  OfsThisSalesTax
    //    /// <summary>����Ńv���p�e�B</summary>
    //    /// <value>���E�㍡�񔄏�����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����Ńv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 OfsThisSalesTax
    //    {
    //        get { return _ofsThisSalesTax; }
    //        set { _ofsThisSalesTax = value; }
    //    }

    //    /// public propaty name  :  ThisSalesPricTotal
    //    /// <summary>���񍇌v�v���p�e�B</summary>
    //    /// <value>������z+�����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���񍇌v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisSalesPricTotal
    //    {
    //        get { return _thisSalesPricTotal; }
    //        set { _thisSalesPricTotal = value; }
    //    }

    //    /// public propaty name  :  AfCalBlc
    //    /// <summary>����c���v���p�e�B</summary>
    //    /// <value>�v�Z�㐿�����z/�v�Z�㓖�����|���z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 AfCalBlc
    //    {
    //        get { return _afCalBlc; }
    //        set { _afCalBlc = value; }
    //    }

    //    /// public propaty name  :  SalesSlipCount
    //    /// <summary>�`�[�����v���p�e�B</summary>
    //    /// <value>����`�[����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 SalesSlipCount
    //    {
    //        get { return _salesSlipCount; }
    //        set { _salesSlipCount = value; }
    //    }


    //    /// <summary>
    //    /// ���Ӑ�d�q�������o����(�c���ꗗ)�N���X���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public CustPrtPprBlTblRsltWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    ///// </summary>
    ///// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    ///// <remarks>
    ///// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    ///// <br>Programer        :   ��������</br>
    ///// </remarks>
    //public class CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate �����o

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public void Serialize(System.IO.BinaryWriter writer, object graph)
    //    {
    //        // TODO:  CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
    //        if (writer == null)
    //            throw new ArgumentNullException();

    //        if (graph != null && !(graph is CustPrtPprBlTblRsltWork || graph is ArrayList || graph is CustPrtPprBlTblRsltWork[]))
    //            throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustPrtPprBlTblRsltWork).FullName));

    //        if (graph != null && graph is CustPrtPprBlTblRsltWork)
    //        {
    //            Type t = graph.GetType();
    //            if (!CustomFormatterServices.NeedCustomSerialization(t))
    //                throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork");

    //        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
    //        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
    //        if (graph is ArrayList)
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if (graph is CustPrtPprBlTblRsltWork[])
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((CustPrtPprBlTblRsltWork[])graph).Length;
    //        }
    //        else if (graph is CustPrtPprBlTblRsltWork)
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

    //        //�v���
    //        serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
    //        //�O��c��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeBlc
    //        //��������z
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
    //        //�J�z�c��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlc
    //        //���񔄏�
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
    //        //�ԕi�l��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //SalesPricRgdsDis
    //        //������z
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
    //        //�����
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
    //        //���񍇌v
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricTotal
    //        //����c��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //AfCalBlc
    //        //�`�[����
    //        serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount


    //        serInfo.Serialize(writer, serInfo);
    //        if (graph is CustPrtPprBlTblRsltWork)
    //        {
    //            CustPrtPprBlTblRsltWork temp = (CustPrtPprBlTblRsltWork)graph;

    //            SetCustPrtPprBlTblRsltWork(writer, temp);
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if (graph is CustPrtPprBlTblRsltWork[])
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange((CustPrtPprBlTblRsltWork[])graph);
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach (CustPrtPprBlTblRsltWork temp in lst)
    //            {
    //                SetCustPrtPprBlTblRsltWork(writer, temp);
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// CustPrtPprBlTblRsltWork�����o��(public�v���p�e�B��)
    //    /// </summary>
    //    private const int currentMemberCount = 11;

    //    /// <summary>
    //    ///  CustPrtPprBlTblRsltWork�C���X�^���X��������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�̃C���X�^���X����������</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private void SetCustPrtPprBlTblRsltWork(System.IO.BinaryWriter writer, CustPrtPprBlTblRsltWork temp)
    //    {
    //        //�v���
    //        writer.Write((Int64)temp.AddUpDate.Ticks);
    //        //�O��c��
    //        writer.Write(temp.LastTimeBlc);
    //        //��������z
    //        writer.Write(temp.ThisTimeDmdNrml);
    //        //�J�z�c��
    //        writer.Write(temp.ThisTimeTtlBlc);
    //        //���񔄏�
    //        writer.Write(temp.ThisTimeSales);
    //        //�ԕi�l��
    //        writer.Write(temp.SalesPricRgdsDis);
    //        //������z
    //        writer.Write(temp.OfsThisTimeSales);
    //        //�����
    //        writer.Write(temp.OfsThisSalesTax);
    //        //���񍇌v
    //        writer.Write(temp.ThisSalesPricTotal);
    //        //����c��
    //        writer.Write(temp.AfCalBlc);
    //        //�`�[����
    //        writer.Write(temp.SalesSlipCount);

    //    }

    //    /// <summary>
    //    ///  CustPrtPprBlTblRsltWork�C���X�^���X�擾
    //    /// </summary>
    //    /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�̃C���X�^���X���擾���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private CustPrtPprBlTblRsltWork GetCustPrtPprBlTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    //    {
    //        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

    //        CustPrtPprBlTblRsltWork temp = new CustPrtPprBlTblRsltWork();

    //        //�v���
    //        temp.AddUpDate = new DateTime(reader.ReadInt64());
    //        //�O��c��
    //        temp.LastTimeBlc = reader.ReadInt64();
    //        //��������z
    //        temp.ThisTimeDmdNrml = reader.ReadInt64();
    //        //�J�z�c��
    //        temp.ThisTimeTtlBlc = reader.ReadInt64();
    //        //���񔄏�
    //        temp.ThisTimeSales = reader.ReadInt64();
    //        //�ԕi�l��
    //        temp.SalesPricRgdsDis = reader.ReadInt64();
    //        //������z
    //        temp.OfsThisTimeSales = reader.ReadInt64();
    //        //�����
    //        temp.OfsThisSalesTax = reader.ReadInt64();
    //        //���񍇌v
    //        temp.ThisSalesPricTotal = reader.ReadInt64();
    //        //����c��
    //        temp.AfCalBlc = reader.ReadInt64();
    //        //�`�[����
    //        temp.SalesSlipCount = reader.ReadInt32();


    //        //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
    //        //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
    //        //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
    //        //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
    //        for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
    //        {
    //            //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
    //            //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
    //            //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
    //            //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if (oMemberType is Type)
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
    //                if (t.Equals(typeof(int)))
    //                {
    //                    optCount = Convert.ToInt32(oData);
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if (oMemberType is string)
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
    //                object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
    //    /// </summary>
    //    /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public object Deserialize(System.IO.BinaryReader reader)
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
    //        ArrayList lst = new ArrayList();
    //        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
    //        {
    //            CustPrtPprBlTblRsltWork temp = GetCustPrtPprBlTblRsltWork(reader, serInfo);
    //            lst.Add(temp);
    //        }
    //        switch (serInfo.RetTypeInfo)
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (CustPrtPprBlTblRsltWork[])lst.ToArray(typeof(CustPrtPprBlTblRsltWork));
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
    /// public class name:   CustPrtPprBlTblRsltWork
    /// <summary>
    ///                      ���Ӑ�d�q�������o����(�c���ꗗ)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�d�q�������o����(�c���ꗗ)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprBlTblRsltWork
    {
        /// <summary>�v��N����</summary>
        /// <remarks>�v��N����(YYYYMMDD)</remarks>
        private DateTime _addUpDate;

        /// <summary>�O��c��</summary>
        /// <remarks>�O�񐿋����z/�O�񔄊|���z</remarks>
        private Int64 _lastTimeBlc;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>����������z�i�ʏ�����j</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>�J�z�c��</summary>
        /// <remarks>����J�z�c���i�����v�j/����J�z�c���i���|�v�j</remarks>
        private Int64 _thisTimeTtlBlc;

        /// <summary>���񔄏���z</summary>
        /// <remarks>���񔄏���z</remarks>
        private Int64 _thisTimeSales;

        /// <summary>�ԕi�l��</summary>
        /// <remarks>���񔄏�ԕi���z+���񔄏�l�����z</remarks>
        private Int64 _salesPricRgdsDis;

        /// <summary>���E�㍡�񔄏���z</summary>
        /// <remarks>���E�㍡�񔄏���z</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>���E�㍡�񔄏�����</summary>
        /// <remarks>���E�㍡�񔄏�����</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>���񍇌v</summary>
        /// <remarks>������z+�����</remarks>
        private Int64 _thisSalesPricTotal;

        /// <summary>����c��</summary>
        /// <remarks>�v�Z�㐿�����z/�v�Z�㓖�����|���z</remarks>
        private Int64 _afCalBlc;

        /// <summary>����`�[����</summary>
        /// <remarks>����`�[����</remarks>
        private Int32 _salesSlipCount;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        /// <summary>�^�M�Ǘ��敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _creditMngCode;

        /// <summary>�^�M�z</summary>
        /// <remarks>�^�M�z</remarks>
        private Int64 _creditMoney;

        /// <summary>�x���^�M�z</summary>
        /// <remarks>�x���^�M�z</remarks>
        private Int64 _warningCreditMoney;

        /// <summary>�^�M���|�c��</summary>
        /// <remarks>�^�M���|�c��</remarks>
        private Int64 _prsntAccRecBalance;

        /// <summary>�����c</summary>
        /// <remarks>�����c</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>���|�敪</summary>
        /// <remarks>0:���|�Ȃ� 1:���|����</remarks>
        private Int32 _accRecDivCd;

        /// <summary>���В���</summary>
        /// <remarks>���В���</remarks>
        private Int32 _companyTotalDay;

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<


        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>�v��N����(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  LastTimeBlc
        /// <summary>�O��c���v���p�e�B</summary>
        /// <value>�O�񐿋����z/�O�񔄊|���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeBlc
        {
            get { return _lastTimeBlc; }
            set { _lastTimeBlc = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>����������z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlc
        /// <summary>�J�z�c���v���p�e�B</summary>
        /// <value>����J�z�c���i�����v�j/����J�z�c���i���|�v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�z�c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlc
        {
            get { return _thisTimeTtlBlc; }
            set { _thisTimeTtlBlc = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>���񔄏���z�v���p�e�B</summary>
        /// <value>���񔄏���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  SalesPricRgdsDis
        /// <summary>�ԕi�l���v���p�e�B</summary>
        /// <value>���񔄏�ԕi���z+���񔄏�l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPricRgdsDis
        {
            get { return _salesPricRgdsDis; }
            set { _salesPricRgdsDis = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
        /// <value>���E�㍡�񔄏���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
        /// <value>���E�㍡�񔄏�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ThisSalesPricTotal
        /// <summary>���񍇌v�v���p�e�B</summary>
        /// <value>������z+�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񍇌v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricTotal
        {
            get { return _thisSalesPricTotal; }
            set { _thisSalesPricTotal = value; }
        }

        /// public propaty name  :  AfCalBlc
        /// <summary>����c���v���p�e�B</summary>
        /// <value>�v�Z�㐿�����z/�v�Z�㓖�����|���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalBlc
        {
            get { return _afCalBlc; }
            set { _afCalBlc = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// <value>����`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>

        /// public propaty name  :  CreditMngCode
        /// <summary>�^�M�Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>�^�M�z�v���p�e�B</summary>
        /// <value>�^�M�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  WarningCreditMoney
        /// <summary>�x���^�M�z�v���p�e�B</summary>
        /// <value>�x���^�M�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���^�M�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 WarningCreditMoney
        {
            get { return _warningCreditMoney; }
            set { _warningCreditMoney = value; }
        }

        /// public propaty name  :  PrsntAccRecBalance
        /// <summary>�^�M���|�c���v���p�e�B</summary>
        /// <value>�^�M���|�c��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M���|�c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PrsntAccRecBalance
        {
            get { return _prsntAccRecBalance; }
            set { _prsntAccRecBalance = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>�����c�v���p�e�B</summary>
        /// <value>�����c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// <value>0:���|�Ȃ� 1:���|����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  CompanyTotalDay
        /// <summary>���В����v���p�e�B</summary>
        /// <value>���В���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���В����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyTotalDay
        {
            get { return _companyTotalDay; }
            set { _companyTotalDay = value; }
        }
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

        /// <summary>
        /// ���Ӑ�d�q�������o����(�c���ꗗ)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustPrtPprBlTblRsltWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  CustPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is CustPrtPprBlTblRsltWork || graph is ArrayList || graph is CustPrtPprBlTblRsltWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( CustPrtPprBlTblRsltWork ).FullName ) );

            if ( graph != null && graph is CustPrtPprBlTblRsltWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustPrtPprBlTblRsltWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is CustPrtPprBlTblRsltWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustPrtPprBlTblRsltWork[])graph).Length;
            }
            else if ( graph is CustPrtPprBlTblRsltWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v��N����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpDate
            //�O��c��
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //LastTimeBlc
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeDmdNrml
            //�J�z�c��
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeTtlBlc
            //���񔄏���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeSales
            //�ԕi�l��
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //SalesPricRgdsDis
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisTimeSales
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisSalesTax
            //���񍇌v
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisSalesPricTotal
            //����c��
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //AfCalBlc
            //����`�[����
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SalesSlipCount
            //�v��N��
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpYearMonth
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //�^�M�Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CreditMngCode
            //�^�M�z
            serInfo.MemberInfo.Add(typeof(Int64)); //CreditMoney
            //�x���^�M�z
            serInfo.MemberInfo.Add(typeof(Int64)); //WarningCreditMoney
            //�^�M���|�c��
            serInfo.MemberInfo.Add(typeof(Int64)); //PrsntAccRecBalance
            //�����c
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalDemandPrice
            //���|�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //���В���
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyTotalDay
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<


            serInfo.Serialize( writer, serInfo );
            if ( graph is CustPrtPprBlTblRsltWork )
            {
                CustPrtPprBlTblRsltWork temp = (CustPrtPprBlTblRsltWork)graph;

                SetCustPrtPprBlTblRsltWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is CustPrtPprBlTblRsltWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (CustPrtPprBlTblRsltWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( CustPrtPprBlTblRsltWork temp in lst )
                {
                    SetCustPrtPprBlTblRsltWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// CustPrtPprBlTblRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //private const int currentMemberCount = 12;
        private const int currentMemberCount = 19;
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

        /// <summary>
        ///  CustPrtPprBlTblRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustPrtPprBlTblRsltWork( System.IO.BinaryWriter writer, CustPrtPprBlTblRsltWork temp )
        {
            //�v��N����
            writer.Write( (Int64)temp.AddUpDate.Ticks );
            //�O��c��
            writer.Write( temp.LastTimeBlc );
            //����������z�i�ʏ�����j
            writer.Write( temp.ThisTimeDmdNrml );
            //�J�z�c��
            writer.Write( temp.ThisTimeTtlBlc );
            //���񔄏���z
            writer.Write( temp.ThisTimeSales );
            //�ԕi�l��
            writer.Write( temp.SalesPricRgdsDis );
            //���E�㍡�񔄏���z
            writer.Write( temp.OfsThisTimeSales );
            //���E�㍡�񔄏�����
            writer.Write( temp.OfsThisSalesTax );
            //���񍇌v
            writer.Write( temp.ThisSalesPricTotal );
            //����c��
            writer.Write( temp.AfCalBlc );
            //����`�[����
            writer.Write( temp.SalesSlipCount );
            //�v��N��
            writer.Write( (Int64)temp.AddUpYearMonth.Ticks );
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //�^�M�敪
            writer.Write(temp.CreditMngCode);
            //�^�M�z
            writer.Write(temp.CreditMoney);
            //�x���^�M�z
            writer.Write(temp.WarningCreditMoney);
            //�^�M���|�c��
            writer.Write(temp.PrsntAccRecBalance);
            //�����c
            writer.Write(temp.AfCalDemandPrice);
            //���|�敪
            writer.Write(temp.AccRecDivCd);
            //���В���
            writer.Write(temp.CompanyTotalDay);
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

        }

        /// <summary>
        ///  CustPrtPprBlTblRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustPrtPprBlTblRsltWork GetCustPrtPprBlTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustPrtPprBlTblRsltWork temp = new CustPrtPprBlTblRsltWork();

            //�v��N����
            temp.AddUpDate = new DateTime( reader.ReadInt64() );
            //�O��c��
            temp.LastTimeBlc = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //�J�z�c��
            temp.ThisTimeTtlBlc = reader.ReadInt64();
            //���񔄏���z
            temp.ThisTimeSales = reader.ReadInt64();
            //�ԕi�l��
            temp.SalesPricRgdsDis = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //���񍇌v
            temp.ThisSalesPricTotal = reader.ReadInt64();
            //����c��
            temp.AfCalBlc = reader.ReadInt64();
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //�v��N��
            temp.AddUpYearMonth = new DateTime( reader.ReadInt64() );
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //�^�M�敪
            temp.CreditMngCode = reader.ReadInt32();
            //�^�M�z
            temp.CreditMoney = reader.ReadInt64();
            //�x���^�M�z
            temp.WarningCreditMoney = reader.ReadInt64();
            //�^�M���|�c��
            temp.PrsntAccRecBalance = reader.ReadInt64();
            //�����c
            temp.AfCalDemandPrice = reader.ReadInt64();
            //���|�敪
            temp.AccRecDivCd = reader.ReadInt32();
            //���В���
            temp.CompanyTotalDay = reader.ReadInt32();
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>CustPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                CustPrtPprBlTblRsltWork temp = GetCustPrtPprBlTblRsltWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustPrtPprBlTblRsltWork[])lst.ToArray( typeof( CustPrtPprBlTblRsltWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
}
