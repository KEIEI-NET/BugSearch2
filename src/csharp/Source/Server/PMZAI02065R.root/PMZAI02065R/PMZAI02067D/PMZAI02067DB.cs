using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TrustStockResultWork
    /// <summary>
    ///                      �ϑ��݌ɕ�[�������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϑ��݌ɕ�[�������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TrustStockResultWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�q�ɃR�[�h(�ϑ�)</summary>
        /// <remarks>�q�Ƀ}�X�^</remarks>
        private string _tru_WarehouseCode = "";

        /// <summary>�q�ɖ���(�ϑ�)</summary>
        private string _tru_WarehouseName = "";

        /// <summary>�q�ɃR�[�h(��[��)</summary>
        /// <remarks>�݌Ƀ}�X�^ </remarks>
        private string _rep_WarehouseCode = "";

        /// <summary>�q�ɖ���(��[��)</summary>
        private string _rep_WarehouseName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�q�ɒI��(�ϑ�)</summary>
        private string _tru_WarehouseShelfNo = "";

        /// <summary>�ō��݌ɐ�</summary>
        private Double _maximumStockCnt;

        /// <summary>�o�׉\��(�ϑ�)</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _tru_ShipmentPosCnt;

        /// <summary>��[��</summary>
        /// <remarks>�ϑ��q�ɍō����|�ϑ��q�Ɍ��݌ɐ�</remarks>
        private Double _replenishCount;

        /// <summary>��[�㌻�݌�</summary>
        /// <remarks>�o�׉\���|��[��</remarks>
        private Double _replenishNStockCount;

        /// <summary>�q�ɒI��(��[��)</summary>
        private string _rep_WarehouseShelfNo = "";

        /// <summary>�o�׉\��(��[��)</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _rep_ShipmentPosCnt;

        /// <summary>���i�ԍ����o�^�t���O</summary>
        private Int32 _goodsFlg;

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

        /// public propaty name  :  Tru_WarehouseCode
        /// <summary>�q�ɃR�[�h(�ϑ�)�v���p�e�B</summary>
        /// <value>�q�Ƀ}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Tru_WarehouseCode
        {
            get { return _tru_WarehouseCode; }
            set { _tru_WarehouseCode = value; }
        }

        /// public propaty name  :  Tru_WarehouseName
        /// <summary>�q�ɖ���(�ϑ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Tru_WarehouseName
        {
            get { return _tru_WarehouseName; }
            set { _tru_WarehouseName = value; }
        }

        /// public propaty name  :  Rep_WarehouseCode
        /// <summary>�q�ɃR�[�h(��[��)�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^ </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Rep_WarehouseCode
        {
            get { return _rep_WarehouseCode; }
            set { _rep_WarehouseCode = value; }
        }

        /// public propaty name  :  Rep_WarehouseName
        /// <summary>�q�ɖ���(��[��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Rep_WarehouseName
        {
            get { return _rep_WarehouseName; }
            set { _rep_WarehouseName = value; }
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

        /// public propaty name  :  MakerShortName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  Tru_WarehouseShelfNo
        /// <summary>�q�ɒI��(�ϑ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI��(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Tru_WarehouseShelfNo
        {
            get { return _tru_WarehouseShelfNo; }
            set { _tru_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>�ō��݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ō��݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  Tru_ShipmentPosCnt
        /// <summary>�o�׉\��(�ϑ�)�v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\��(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Tru_ShipmentPosCnt
        {
            get { return _tru_ShipmentPosCnt; }
            set { _tru_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  ReplenishCount
        /// <summary>��[���v���p�e�B</summary>
        /// <value>�ϑ��q�ɍō����|�ϑ��q�Ɍ��݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ReplenishCount
        {
            get { return _replenishCount; }
            set { _replenishCount = value; }
        }

        /// public propaty name  :  ReplenishNStockCount
        /// <summary>��[�㌻�݌��v���p�e�B</summary>
        /// <value>�o�׉\���|��[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��[�㌻�݌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ReplenishNStockCount
        {
            get { return _replenishNStockCount; }
            set { _replenishNStockCount = value; }
        }

        /// public propaty name  :  Rep_WarehouseShelfNo
        /// <summary>�q�ɒI��(��[��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI��(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Rep_WarehouseShelfNo
        {
            get { return _rep_WarehouseShelfNo; }
            set { _rep_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Rep_ShipmentPosCnt
        /// <summary>�o�׉\��(��[��)�v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\��(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Rep_ShipmentPosCnt
        {
            get { return _rep_ShipmentPosCnt; }
            set { _rep_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i�ԍ����o�^�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ����o�^�t���O�v���p�e�B�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsFlg
        {
            get { return _goodsFlg; }
            set { _goodsFlg = value; }
        }


        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TrustStockResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TrustStockResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>TrustStockResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   TrustStockResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class TrustStockResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TrustStockResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TrustStockResultWork || graph is ArrayList || graph is TrustStockResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(TrustStockResultWork).FullName));

            if (graph != null && graph is TrustStockResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TrustStockResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TrustStockResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TrustStockResultWork[])graph).Length;
            }
            else if (graph is TrustStockResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //�q�ɃR�[�h(�ϑ�)
            serInfo.MemberInfo.Add(typeof(string)); //Tru_WarehouseCode
            //�q�ɖ���(�ϑ�)
            serInfo.MemberInfo.Add(typeof(string)); //Tru_WarehouseName
            //�q�ɃR�[�h(��[��)
            serInfo.MemberInfo.Add(typeof(string)); //Rep_WarehouseCode
            //�q�ɖ���(��[��)
            serInfo.MemberInfo.Add(typeof(string)); //Rep_WarehouseName
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�q�ɒI��(�ϑ�)
            serInfo.MemberInfo.Add(typeof(string)); //Tru_WarehouseShelfNo
            //�ō��݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //�o�׉\��(�ϑ�)
            serInfo.MemberInfo.Add(typeof(Double)); //Tru_ShipmentPosCnt
            //��[��
            serInfo.MemberInfo.Add(typeof(Double)); //ReplenishCount
            //��[�㌻�݌�
            serInfo.MemberInfo.Add(typeof(Double)); //ReplenishNStockCount
            //�q�ɒI��(��[��)
            serInfo.MemberInfo.Add(typeof(string)); //Rep_WarehouseShelfNo
            //�o�׉\��(��[��)
            serInfo.MemberInfo.Add(typeof(Double)); //Rep_ShipmentPosCnt
            //���i���o�^�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is TrustStockResultWork)
            {
                TrustStockResultWork temp = (TrustStockResultWork)graph;

                SetTrustStockResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TrustStockResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TrustStockResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TrustStockResultWork temp in lst)
                {
                    SetTrustStockResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TrustStockResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  TrustStockResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetTrustStockResultWork(System.IO.BinaryWriter writer, TrustStockResultWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //�q�ɃR�[�h(�ϑ�)
            writer.Write(temp.Tru_WarehouseCode);
            //�q�ɖ���(�ϑ�)
            writer.Write(temp.Tru_WarehouseName);
            //�q�ɃR�[�h(��[��)
            writer.Write(temp.Rep_WarehouseCode);
            //�q�ɖ���(��[��)
            writer.Write(temp.Rep_WarehouseName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���[�J�[����
            writer.Write(temp.MakerShortName);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //�q�ɒI��(�ϑ�)
            writer.Write(temp.Tru_WarehouseShelfNo);
            //�ō��݌ɐ�
            writer.Write(temp.MaximumStockCnt);
            //�o�׉\��(�ϑ�)
            writer.Write(temp.Tru_ShipmentPosCnt);
            //��[��
            writer.Write(temp.ReplenishCount);
            //��[�㌻�݌�
            writer.Write(temp.ReplenishNStockCount);
            //�q�ɒI��(��[��)
            writer.Write(temp.Rep_WarehouseShelfNo);
            //�o�׉\��(��[��)
            writer.Write(temp.Rep_ShipmentPosCnt);
            //���i�ԍ����o�^�t���O
            writer.Write(temp.GoodsFlg);

        }

        /// <summary>
        ///  TrustStockResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>TrustStockResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private TrustStockResultWork GetTrustStockResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            TrustStockResultWork temp = new TrustStockResultWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //�q�ɃR�[�h(�ϑ�)
            temp.Tru_WarehouseCode = reader.ReadString();
            //�q�ɖ���(�ϑ�)
            temp.Tru_WarehouseName = reader.ReadString();
            //�q�ɃR�[�h(��[��)
            temp.Rep_WarehouseCode = reader.ReadString();
            //�q�ɖ���(��[��)
            temp.Rep_WarehouseName = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���[�J�[����
            temp.MakerShortName = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�q�ɒI��(�ϑ�)
            temp.Tru_WarehouseShelfNo = reader.ReadString();
            //�ō��݌ɐ�
            temp.MaximumStockCnt = reader.ReadDouble();
            //�o�׉\��(�ϑ�)
            temp.Tru_ShipmentPosCnt = reader.ReadDouble();
            //��[��
            temp.ReplenishCount = reader.ReadDouble();
            //��[�㌻�݌�
            temp.ReplenishNStockCount = reader.ReadDouble();
            //�q�ɒI��(��[��)
            temp.Rep_WarehouseShelfNo = reader.ReadString();
            //�o�׉\��(��[��)
            temp.Rep_ShipmentPosCnt = reader.ReadDouble();
            //���i�ԍ����o�^�t���O
            temp.GoodsFlg = reader.ReadInt32();


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
        /// <returns>TrustStockResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TrustStockResultWork temp = GetTrustStockResultWork(reader, serInfo);
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
                    retValue = (TrustStockResultWork[])lst.ToArray(typeof(TrustStockResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
