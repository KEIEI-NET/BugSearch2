using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
    # region // DEL
    ///// public class name:   SuppPrtPprBlTblRsltWork
    ///// <summary>
    /////                      �d����d�q�������o����(�c���ꗗ)�N���X���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   �d����d�q�������o����(�c���ꗗ)�N���X���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2008/08/18  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprBlTblRsltWork
    //{
    //    /// <summary>�v���</summary>
    //    /// <remarks>�v��N����(YYYYMMDD)</remarks>
    //    private DateTime _addUpDate;

    //    /// <summary>�O��c��</summary>
    //    /// <remarks>�O��x�����z/�O�񔃊|���z</remarks>
    //    private Int64 _lastTimeBlc;

    //    /// <summary>����x���z</summary>
    //    /// <remarks>����������z�i�ʏ�����j</remarks>
    //    private Int64 _thisTimePayNrml;

    //    /// <summary>�J�z�c��</summary>
    //    /// <remarks>����J�z�c���i�x���v�j/����J�z�c���i���|�v�j</remarks>
    //    private Int64 _thisTimeTtlBlc;

    //    /// <summary>����d��</summary>
    //    /// <remarks>����d�����z</remarks>
    //    private Int64 _thisTimeStockPrice;

    //    /// <summary>�ԕi�l��</summary>
    //    /// <remarks>����ԕi���z+����l�����z</remarks>
    //    private Int64 _thisStckPricRgdsDis;

    //    /// <summary>���d���z</summary>
    //    /// <remarks>���E�㍡��d�����z</remarks>
    //    private Int64 _ofsThisTimeStock;

    //    /// <summary>�����</summary>
    //    /// <remarks>���E�㍡��d�������</remarks>
    //    private Int64 _ofsThisStockTax;

    //    /// <summary>���񍇌v</summary>
    //    /// <remarks>������z+�����</remarks>
    //    private Int64 _thisStckPricTotal;

    //    /// <summary>����c��</summary>
    //    /// <remarks>�d�����v�c���i�x���v�j/�d�����v�c���i���|�v�j</remarks>
    //    private Int64 _stckTtlPayBlc;

    //    /// <summary>�`�[����</summary>
    //    /// <remarks>�d���`�[����</remarks>
    //    private Int32 _stockSlipCount;


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
    //    /// <value>�O��x�����z/�O�񔃊|���z</value>
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

    //    /// public propaty name  :  ThisTimePayNrml
    //    /// <summary>����x���z�v���p�e�B</summary>
    //    /// <value>����������z�i�ʏ�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����x���z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimePayNrml
    //    {
    //        get { return _thisTimePayNrml; }
    //        set { _thisTimePayNrml = value; }
    //    }

    //    /// public propaty name  :  ThisTimeTtlBlc
    //    /// <summary>�J�z�c���v���p�e�B</summary>
    //    /// <value>����J�z�c���i�x���v�j/����J�z�c���i���|�v�j</value>
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

    //    /// public propaty name  :  ThisTimeStockPrice
    //    /// <summary>����d���v���p�e�B</summary>
    //    /// <value>����d�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����d���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimeStockPrice
    //    {
    //        get { return _thisTimeStockPrice; }
    //        set { _thisTimeStockPrice = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricRgdsDis
    //    /// <summary>�ԕi�l���v���p�e�B</summary>
    //    /// <value>����ԕi���z+����l�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԕi�l���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricRgdsDis
    //    {
    //        get { return _thisStckPricRgdsDis; }
    //        set { _thisStckPricRgdsDis = value; }
    //    }

    //    /// public propaty name  :  OfsThisTimeStock
    //    /// <summary>���d���z�v���p�e�B</summary>
    //    /// <value>���E�㍡��d�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���d���z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 OfsThisTimeStock
    //    {
    //        get { return _ofsThisTimeStock; }
    //        set { _ofsThisTimeStock = value; }
    //    }

    //    /// public propaty name  :  OfsThisStockTax
    //    /// <summary>����Ńv���p�e�B</summary>
    //    /// <value>���E�㍡��d�������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����Ńv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 OfsThisStockTax
    //    {
    //        get { return _ofsThisStockTax; }
    //        set { _ofsThisStockTax = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricTotal
    //    /// <summary>���񍇌v�v���p�e�B</summary>
    //    /// <value>������z+�����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���񍇌v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricTotal
    //    {
    //        get { return _thisStckPricTotal; }
    //        set { _thisStckPricTotal = value; }
    //    }

    //    /// public propaty name  :  StckTtlPayBlc
    //    /// <summary>����c���v���p�e�B</summary>
    //    /// <value>�d�����v�c���i�x���v�j/�d�����v�c���i���|�v�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StckTtlPayBlc
    //    {
    //        get { return _stckTtlPayBlc; }
    //        set { _stckTtlPayBlc = value; }
    //    }

    //    /// public propaty name  :  StockSlipCount
    //    /// <summary>�`�[�����v���p�e�B</summary>
    //    /// <value>�d���`�[����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �`�[�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 StockSlipCount
    //    {
    //        get { return _stockSlipCount; }
    //        set { _stockSlipCount = value; }
    //    }


    //    /// <summary>
    //    /// �d����d�q�������o����(�c���ꗗ)�N���X���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SuppPrtPprBlTblRsltWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    ///// </summary>
    ///// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    ///// <remarks>
    ///// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    ///// <br>Programer        :   ��������</br>
    ///// </remarks>
    //public class SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate �����o

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public void Serialize(System.IO.BinaryWriter writer, object graph)
    //    {
    //        // TODO:  SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
    //        if (writer == null)
    //            throw new ArgumentNullException();

    //        if (graph != null && !(graph is SuppPrtPprBlTblRsltWork || graph is ArrayList || graph is SuppPrtPprBlTblRsltWork[]))
    //            throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuppPrtPprBlTblRsltWork).FullName));

    //        if (graph != null && graph is SuppPrtPprBlTblRsltWork)
    //        {
    //            Type t = graph.GetType();
    //            if (!CustomFormatterServices.NeedCustomSerialization(t))
    //                throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork");

    //        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
    //        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
    //        if (graph is ArrayList)
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if (graph is SuppPrtPprBlTblRsltWork[])
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprBlTblRsltWork[])graph).Length;
    //        }
    //        else if (graph is SuppPrtPprBlTblRsltWork)
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

    //        //�v���
    //        serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
    //        //�O��c��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeBlc
    //        //����x���z
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
    //        //�J�z�c��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlc
    //        //����d��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
    //        //�ԕi�l��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgdsDis
    //        //���d���z
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
    //        //�����
    //        serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
    //        //���񍇌v
    //        serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricTotal
    //        //����c��
    //        serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlPayBlc
    //        //�`�[����
    //        serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount


    //        serInfo.Serialize(writer, serInfo);
    //        if (graph is SuppPrtPprBlTblRsltWork)
    //        {
    //            SuppPrtPprBlTblRsltWork temp = (SuppPrtPprBlTblRsltWork)graph;

    //            SetSuppPrtPprBlTblRsltWork(writer, temp);
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if (graph is SuppPrtPprBlTblRsltWork[])
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange((SuppPrtPprBlTblRsltWork[])graph);
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach (SuppPrtPprBlTblRsltWork temp in lst)
    //            {
    //                SetSuppPrtPprBlTblRsltWork(writer, temp);
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprBlTblRsltWork�����o��(public�v���p�e�B��)
    //    /// </summary>
    //    private const int currentMemberCount = 11;

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWork�C���X�^���X��������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�̃C���X�^���X����������</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprBlTblRsltWork(System.IO.BinaryWriter writer, SuppPrtPprBlTblRsltWork temp)
    //    {
    //        //�v���
    //        writer.Write((Int64)temp.AddUpDate.Ticks);
    //        //�O��c��
    //        writer.Write(temp.LastTimeBlc);
    //        //����x���z
    //        writer.Write(temp.ThisTimePayNrml);
    //        //�J�z�c��
    //        writer.Write(temp.ThisTimeTtlBlc);
    //        //����d��
    //        writer.Write(temp.ThisTimeStockPrice);
    //        //�ԕi�l��
    //        writer.Write(temp.ThisStckPricRgdsDis);
    //        //���d���z
    //        writer.Write(temp.OfsThisTimeStock);
    //        //�����
    //        writer.Write(temp.OfsThisStockTax);
    //        //���񍇌v
    //        writer.Write(temp.ThisStckPricTotal);
    //        //����c��
    //        writer.Write(temp.StckTtlPayBlc);
    //        //�`�[����
    //        writer.Write(temp.StockSlipCount);

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWork�C���X�^���X�擾
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�̃C���X�^���X���擾���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private SuppPrtPprBlTblRsltWork GetSuppPrtPprBlTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    //    {
    //        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

    //        SuppPrtPprBlTblRsltWork temp = new SuppPrtPprBlTblRsltWork();

    //        //�v���
    //        temp.AddUpDate = new DateTime(reader.ReadInt64());
    //        //�O��c��
    //        temp.LastTimeBlc = reader.ReadInt64();
    //        //����x���z
    //        temp.ThisTimePayNrml = reader.ReadInt64();
    //        //�J�z�c��
    //        temp.ThisTimeTtlBlc = reader.ReadInt64();
    //        //����d��
    //        temp.ThisTimeStockPrice = reader.ReadInt64();
    //        //�ԕi�l��
    //        temp.ThisStckPricRgdsDis = reader.ReadInt64();
    //        //���d���z
    //        temp.OfsThisTimeStock = reader.ReadInt64();
    //        //�����
    //        temp.OfsThisStockTax = reader.ReadInt64();
    //        //���񍇌v
    //        temp.ThisStckPricTotal = reader.ReadInt64();
    //        //����c��
    //        temp.StckTtlPayBlc = reader.ReadInt64();
    //        //�`�[����
    //        temp.StockSlipCount = reader.ReadInt32();


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
    //    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public object Deserialize(System.IO.BinaryReader reader)
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
    //        ArrayList lst = new ArrayList();
    //        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
    //        {
    //            SuppPrtPprBlTblRsltWork temp = GetSuppPrtPprBlTblRsltWork(reader, serInfo);
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
    //                retValue = (SuppPrtPprBlTblRsltWork[])lst.ToArray(typeof(SuppPrtPprBlTblRsltWork));
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
    # region
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
    ///// public class name:   SuppPrtPprBlTblRsltWork
    ///// <summary>
    /////                      �d����d�q�������o����(�c���ꗗ)�N���X���[�N
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   �d����d�q�������o����(�c���ꗗ)�N���X���[�N�w�b�_�t�@�C��</br>
    ///// <br>Programmer       :   ��������</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class SuppPrtPprBlTblRsltWork
    //{
    //    /// <summary>�v��N����</summary>
    //    /// <remarks>�v��N����(YYYYMMDD)</remarks>
    //    private DateTime _addUpDate;

    //    /// <summary>�O��c��</summary>
    //    /// <remarks>�O��x�����z/�O�񔃊|���z</remarks>
    //    private Int64 _lastTimeBlc;

    //    /// <summary>����x�����z�i�ʏ�x���j</summary>
    //    /// <remarks>����������z�i�ʏ�����j</remarks>
    //    private Int64 _thisTimePayNrml;

    //    /// <summary>�J�z�c��</summary>
    //    /// <remarks>����J�z�c���i�x���v�j/����J�z�c���i���|�v�j</remarks>
    //    private Int64 _thisTimeTtlBlc;

    //    /// <summary>����d�����z</summary>
    //    /// <remarks>����d�����z</remarks>
    //    private Int64 _thisTimeStockPrice;

    //    /// <summary>�ԕi�l��</summary>
    //    /// <remarks>����ԕi���z+����l�����z</remarks>
    //    private Int64 _thisStckPricRgdsDis;

    //    /// <summary>���E�㍡��d�����z</summary>
    //    /// <remarks>���E�㍡��d�����z</remarks>
    //    private Int64 _ofsThisTimeStock;

    //    /// <summary>���E�㍡��d�������</summary>
    //    /// <remarks>���E�㍡��d�������</remarks>
    //    private Int64 _ofsThisStockTax;

    //    /// <summary>���񍇌v</summary>
    //    /// <remarks>������z+�����</remarks>
    //    private Int64 _thisStckPricTotal;

    //    /// <summary>����c��</summary>
    //    /// <remarks>�d�����v�c���i�x���v�j/�d�����v�c���i���|�v�j</remarks>
    //    private Int64 _stckTtlPayBlc;

    //    /// <summary>�d���`�[����</summary>
    //    /// <remarks>�d���`�[����</remarks>
    //    private Int32 _stockSlipCount;

    //    /// <summary>�v��N��</summary>
    //    /// <remarks>YYYYMM</remarks>
    //    private DateTime _addUpYearMonth;


    //    /// public propaty name  :  AddUpDate
    //    /// <summary>�v��N�����v���p�e�B</summary>
    //    /// <value>�v��N����(YYYYMMDD)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v��N�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime AddUpDate
    //    {
    //        get { return _addUpDate; }
    //        set { _addUpDate = value; }
    //    }

    //    /// public propaty name  :  LastTimeBlc
    //    /// <summary>�O��c���v���p�e�B</summary>
    //    /// <value>�O��x�����z/�O�񔃊|���z</value>
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

    //    /// public propaty name  :  ThisTimePayNrml
    //    /// <summary>����x�����z�i�ʏ�x���j�v���p�e�B</summary>
    //    /// <value>����������z�i�ʏ�����j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����x�����z�i�ʏ�x���j�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimePayNrml
    //    {
    //        get { return _thisTimePayNrml; }
    //        set { _thisTimePayNrml = value; }
    //    }

    //    /// public propaty name  :  ThisTimeTtlBlc
    //    /// <summary>�J�z�c���v���p�e�B</summary>
    //    /// <value>����J�z�c���i�x���v�j/����J�z�c���i���|�v�j</value>
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

    //    /// public propaty name  :  ThisTimeStockPrice
    //    /// <summary>����d�����z�v���p�e�B</summary>
    //    /// <value>����d�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����d�����z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisTimeStockPrice
    //    {
    //        get { return _thisTimeStockPrice; }
    //        set { _thisTimeStockPrice = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricRgdsDis
    //    /// <summary>�ԕi�l���v���p�e�B</summary>
    //    /// <value>����ԕi���z+����l�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �ԕi�l���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricRgdsDis
    //    {
    //        get { return _thisStckPricRgdsDis; }
    //        set { _thisStckPricRgdsDis = value; }
    //    }

    //    /// public propaty name  :  OfsThisTimeStock
    //    /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
    //    /// <value>���E�㍡��d�����z</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 OfsThisTimeStock
    //    {
    //        get { return _ofsThisTimeStock; }
    //        set { _ofsThisTimeStock = value; }
    //    }

    //    /// public propaty name  :  OfsThisStockTax
    //    /// <summary>���E�㍡��d������Ńv���p�e�B</summary>
    //    /// <value>���E�㍡��d�������</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 OfsThisStockTax
    //    {
    //        get { return _ofsThisStockTax; }
    //        set { _ofsThisStockTax = value; }
    //    }

    //    /// public propaty name  :  ThisStckPricTotal
    //    /// <summary>���񍇌v�v���p�e�B</summary>
    //    /// <value>������z+�����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ���񍇌v�v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 ThisStckPricTotal
    //    {
    //        get { return _thisStckPricTotal; }
    //        set { _thisStckPricTotal = value; }
    //    }

    //    /// public propaty name  :  StckTtlPayBlc
    //    /// <summary>����c���v���p�e�B</summary>
    //    /// <value>�d�����v�c���i�x���v�j/�d�����v�c���i���|�v�j</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ����c���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int64 StckTtlPayBlc
    //    {
    //        get { return _stckTtlPayBlc; }
    //        set { _stckTtlPayBlc = value; }
    //    }

    //    /// public propaty name  :  StockSlipCount
    //    /// <summary>�d���`�[�����v���p�e�B</summary>
    //    /// <value>�d���`�[����</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �d���`�[�����v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public Int32 StockSlipCount
    //    {
    //        get { return _stockSlipCount; }
    //        set { _stockSlipCount = value; }
    //    }

    //    /// public propaty name  :  AddUpYearMonth
    //    /// <summary>�v��N���v���p�e�B</summary>
    //    /// <value>YYYYMM</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   �v��N���v���p�e�B</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public DateTime AddUpYearMonth
    //    {
    //        get { return _addUpYearMonth; }
    //        set { _addUpYearMonth = value; }
    //    }


    //    /// <summary>
    //    /// �d����d�q�������o����(�c���ꗗ)�N���X���[�N�R���X�g���N�^
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public SuppPrtPprBlTblRsltWork()
    //    {
    //    }
    //}
    ///// <summary>
    /////  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    ///// </summary>
    ///// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    ///// <remarks>
    ///// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    ///// <br>Programer        :   ��������</br>
    ///// </remarks>
    //public class SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate �����o

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is SuppPrtPprBlTblRsltWork || graph is ArrayList || graph is SuppPrtPprBlTblRsltWork[]) )
    //            throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( SuppPrtPprBlTblRsltWork ).FullName ) );

    //        if ( graph != null && graph is SuppPrtPprBlTblRsltWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork" );

    //        //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
    //        int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is SuppPrtPprBlTblRsltWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((SuppPrtPprBlTblRsltWork[])graph).Length;
    //        }
    //        else if ( graph is SuppPrtPprBlTblRsltWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

    //        //�v��N����
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpDate
    //        //�O��c��
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //LastTimeBlc
    //        //����x�����z�i�ʏ�x���j
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimePayNrml
    //        //�J�z�c��
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeTtlBlc
    //        //����d�����z
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisTimeStockPrice
    //        //�ԕi�l��
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisStckPricRgdsDis
    //        //���E�㍡��d�����z
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisTimeStock
    //        //���E�㍡��d�������
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //OfsThisStockTax
    //        //���񍇌v
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //ThisStckPricTotal
    //        //����c��
    //        serInfo.MemberInfo.Add( typeof( Int64 ) ); //StckTtlPayBlc
    //        //�d���`�[����
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockSlipCount
    //        //�v��N��
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //AddUpYearMonth


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is SuppPrtPprBlTblRsltWork )
    //        {
    //            SuppPrtPprBlTblRsltWork temp = (SuppPrtPprBlTblRsltWork)graph;

    //            SetSuppPrtPprBlTblRsltWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is SuppPrtPprBlTblRsltWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (SuppPrtPprBlTblRsltWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( SuppPrtPprBlTblRsltWork temp in lst )
    //            {
    //                SetSuppPrtPprBlTblRsltWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// SuppPrtPprBlTblRsltWork�����o��(public�v���p�e�B��)
    //    /// </summary>
    //    private const int currentMemberCount = 12;

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWork�C���X�^���X��������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�̃C���X�^���X����������</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private void SetSuppPrtPprBlTblRsltWork( System.IO.BinaryWriter writer, SuppPrtPprBlTblRsltWork temp )
    //    {
    //        //�v��N����
    //        writer.Write( (Int64)temp.AddUpDate.Ticks );
    //        //�O��c��
    //        writer.Write( temp.LastTimeBlc );
    //        //����x�����z�i�ʏ�x���j
    //        writer.Write( temp.ThisTimePayNrml );
    //        //�J�z�c��
    //        writer.Write( temp.ThisTimeTtlBlc );
    //        //����d�����z
    //        writer.Write( temp.ThisTimeStockPrice );
    //        //�ԕi�l��
    //        writer.Write( temp.ThisStckPricRgdsDis );
    //        //���E�㍡��d�����z
    //        writer.Write( temp.OfsThisTimeStock );
    //        //���E�㍡��d�������
    //        writer.Write( temp.OfsThisStockTax );
    //        //���񍇌v
    //        writer.Write( temp.ThisStckPricTotal );
    //        //����c��
    //        writer.Write( temp.StckTtlPayBlc );
    //        //�d���`�[����
    //        writer.Write( temp.StockSlipCount );
    //        //�v��N��
    //        writer.Write( (Int64)temp.AddUpYearMonth.Ticks );

    //    }

    //    /// <summary>
    //    ///  SuppPrtPprBlTblRsltWork�C���X�^���X�擾
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�̃C���X�^���X���擾���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    private SuppPrtPprBlTblRsltWork GetSuppPrtPprBlTblRsltWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

    //        SuppPrtPprBlTblRsltWork temp = new SuppPrtPprBlTblRsltWork();

    //        //�v��N����
    //        temp.AddUpDate = new DateTime( reader.ReadInt64() );
    //        //�O��c��
    //        temp.LastTimeBlc = reader.ReadInt64();
    //        //����x�����z�i�ʏ�x���j
    //        temp.ThisTimePayNrml = reader.ReadInt64();
    //        //�J�z�c��
    //        temp.ThisTimeTtlBlc = reader.ReadInt64();
    //        //����d�����z
    //        temp.ThisTimeStockPrice = reader.ReadInt64();
    //        //�ԕi�l��
    //        temp.ThisStckPricRgdsDis = reader.ReadInt64();
    //        //���E�㍡��d�����z
    //        temp.OfsThisTimeStock = reader.ReadInt64();
    //        //���E�㍡��d�������
    //        temp.OfsThisStockTax = reader.ReadInt64();
    //        //���񍇌v
    //        temp.ThisStckPricTotal = reader.ReadInt64();
    //        //����c��
    //        temp.StckTtlPayBlc = reader.ReadInt64();
    //        //�d���`�[����
    //        temp.StockSlipCount = reader.ReadInt32();
    //        //�v��N��
    //        temp.AddUpYearMonth = new DateTime( reader.ReadInt64() );


    //        //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
    //        //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
    //        //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
    //        //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
    //        for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
    //        {
    //            //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
    //            //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
    //            //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
    //            //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if ( oMemberType is Type )
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
    //                if ( t.Equals( typeof( int ) ) )
    //                {
    //                    optCount = Convert.ToInt32( oData );
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if ( oMemberType is string )
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
    //                object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
    //    /// </summary>
    //    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    //    /// <remarks>
    //    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
    //    /// <br>Programer        :   ��������</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            SuppPrtPprBlTblRsltWork temp = GetSuppPrtPprBlTblRsltWork( reader, serInfo );
    //            lst.Add( temp );
    //        }
    //        switch ( serInfo.RetTypeInfo )
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (SuppPrtPprBlTblRsltWork[])lst.ToArray( typeof( SuppPrtPprBlTblRsltWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
    #endregion
    # region  ADD
    /// public class name:   SuppPrtPprBlTblRsltWork
    /// <summary>
    ///                      �d����d�q�������o����(�c���ꗗ)�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����d�q�������o����(�c���ꗗ)�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/07/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppPrtPprBlTblRsltWork
    {
        /// <summary>�v��N����</summary>
        /// <remarks>�v��N����(YYYYMMDD)</remarks>
        private DateTime _addUpDate;

        /// <summary>�O��c��</summary>
        /// <remarks>�O��x�����z/�O�񔃊|���z</remarks>
        private Int64 _lastTimeBlc;

        /// <summary>����x�����z�i�ʏ�x���j</summary>
        /// <remarks>����������z�i�ʏ�����j</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>�J�z�c��</summary>
        /// <remarks>����J�z�c���i�x���v�j/����J�z�c���i���|�v�j</remarks>
        private Int64 _thisTimeTtlBlc;

        /// <summary>����d�����z</summary>
        /// <remarks>����d�����z</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>�ԕi�l��</summary>
        /// <remarks>����ԕi���z+����l�����z</remarks>
        private Int64 _thisStckPricRgdsDis;

        /// <summary>���E�㍡��d�����z</summary>
        /// <remarks>���E�㍡��d�����z</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>���E�㍡��d�������</summary>
        /// <remarks>���E�㍡��d�������</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>���񍇌v</summary>
        /// <remarks>������z+�����</remarks>
        private Int64 _thisStckPricTotal;

        /// <summary>����c��</summary>
        /// <remarks>�d�����v�c���i�x���v�j/�d�����v�c���i���|�v�j</remarks>
        private Int64 _stckTtlPayBlc;

        /// <summary>�d���`�[����</summary>
        /// <remarks>�d���`�[����</remarks>
        private Int32 _stockSlipCount;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";


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
        /// <value>�O��x�����z/�O�񔃊|���z</value>
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

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>����x�����z�i�ʏ�x���j�v���p�e�B</summary>
        /// <value>����������z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����x�����z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlc
        /// <summary>�J�z�c���v���p�e�B</summary>
        /// <value>����J�z�c���i�x���v�j/����J�z�c���i���|�v�j</value>
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

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>����d�����z�v���p�e�B</summary>
        /// <value>����d�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
        }

        /// public propaty name  :  ThisStckPricRgdsDis
        /// <summary>�ԕi�l���v���p�e�B</summary>
        /// <value>����ԕi���z+����l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricRgdsDis
        {
            get { return _thisStckPricRgdsDis; }
            set { _thisStckPricRgdsDis = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
        /// <value>���E�㍡��d�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeStock
        {
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
        }

        /// public propaty name  :  OfsThisStockTax
        /// <summary>���E�㍡��d������Ńv���p�e�B</summary>
        /// <value>���E�㍡��d�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisStockTax
        {
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }

        /// public propaty name  :  ThisStckPricTotal
        /// <summary>���񍇌v�v���p�e�B</summary>
        /// <value>������z+�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񍇌v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricTotal
        {
            get { return _thisStckPricTotal; }
            set { _thisStckPricTotal = value; }
        }

        /// public propaty name  :  StckTtlPayBlc
        /// <summary>����c���v���p�e�B</summary>
        /// <value>�d�����v�c���i�x���v�j/�d�����v�c���i���|�v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckTtlPayBlc
        {
            get { return _stckTtlPayBlc; }
            set { _stckTtlPayBlc = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>�d���`�[�����v���p�e�B</summary>
        /// <value>�d���`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j</value>
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

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }



        /// <summary>
        /// �d����d�q�������o����(�c���ꗗ)�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppPrtPprBlTblRsltWork()
        {
        }
    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppPrtPprBlTblRsltWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppPrtPprBlTblRsltWork || graph is ArrayList || graph is SuppPrtPprBlTblRsltWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuppPrtPprBlTblRsltWork).FullName));

            if (graph != null && graph is SuppPrtPprBlTblRsltWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppPrtPprBlTblRsltWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppPrtPprBlTblRsltWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppPrtPprBlTblRsltWork[])graph).Length;
            }
            else if (graph is SuppPrtPprBlTblRsltWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�O��c��
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeBlc
            //����x�����z�i�ʏ�x���j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //�J�z�c��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlc
            //����d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //�ԕi�l��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgdsDis
            //���E�㍡��d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //���E�㍡��d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //���񍇌v
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricTotal
            //����c��
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlPayBlc
            //�d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpYearMonth
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1

            serInfo.Serialize(writer, serInfo);
            if (graph is SuppPrtPprBlTblRsltWork)
            {
                SuppPrtPprBlTblRsltWork temp = (SuppPrtPprBlTblRsltWork)graph;

                SetSuppPrtPprBlTblRsltWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppPrtPprBlTblRsltWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppPrtPprBlTblRsltWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppPrtPprBlTblRsltWork temp in lst)
                {
                    SetSuppPrtPprBlTblRsltWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppPrtPprBlTblRsltWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 15;

        /// <summary>
        ///  SuppPrtPprBlTblRsltWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSuppPrtPprBlTblRsltWork(System.IO.BinaryWriter writer, SuppPrtPprBlTblRsltWork temp)
        {
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�O��c��
            writer.Write(temp.LastTimeBlc);
            //����x�����z�i�ʏ�x���j
            writer.Write(temp.ThisTimePayNrml);
            //�J�z�c��
            writer.Write(temp.ThisTimeTtlBlc);
            //����d�����z
            writer.Write(temp.ThisTimeStockPrice);
            //�ԕi�l��
            writer.Write(temp.ThisStckPricRgdsDis);
            //���E�㍡��d�����z
            writer.Write(temp.OfsThisTimeStock);
            //���E�㍡��d�������
            writer.Write(temp.OfsThisStockTax);
            //���񍇌v
            writer.Write(temp.ThisStckPricTotal);
            //����c��
            writer.Write(temp.StckTtlPayBlc);
            //�d���`�[����
            writer.Write(temp.StockSlipCount);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);

        }

        /// <summary>
        ///  SuppPrtPprBlTblRsltWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SuppPrtPprBlTblRsltWork GetSuppPrtPprBlTblRsltWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuppPrtPprBlTblRsltWork temp = new SuppPrtPprBlTblRsltWork();

            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�O��c��
            temp.LastTimeBlc = reader.ReadInt64();
            //����x�����z�i�ʏ�x���j
            temp.ThisTimePayNrml = reader.ReadInt64();
            //�J�z�c��
            temp.ThisTimeTtlBlc = reader.ReadInt64();
            //����d�����z
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //�ԕi�l��
            temp.ThisStckPricRgdsDis = reader.ReadInt64();
            //���E�㍡��d�����z
            temp.OfsThisTimeStock = reader.ReadInt64();
            //���E�㍡��d�������
            temp.OfsThisStockTax = reader.ReadInt64();
            //���񍇌v
            temp.ThisStckPricTotal = reader.ReadInt64();
            //����c��
            temp.StckTtlPayBlc = reader.ReadInt64();
            //�d���`�[����
            temp.StockSlipCount = reader.ReadInt32();
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();


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
        /// <returns>SuppPrtPprBlTblRsltWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlTblRsltWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppPrtPprBlTblRsltWork temp = GetSuppPrtPprBlTblRsltWork(reader, serInfo);
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
                    retValue = (SuppPrtPprBlTblRsltWork[])lst.ToArray(typeof(SuppPrtPprBlTblRsltWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    #endregion
}
