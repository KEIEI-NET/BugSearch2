using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StckAssemOvhulRstWork
    /// <summary>
    ///                      �݌ɑg���E�����������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɑg���E�����������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StckAssemOvhulRstWork
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�e���i�ԍ�</summary>
        private string _parentGoodsNo = "";

        /// <summary>�e���i���̃J�i</summary>
        private string _parentGoodsNameKana = "";

        /// <summary>�e���i���[�J�[�R�[�h</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>�e���[�J�[����</summary>
        private string _parentMakerShortName = "";

        /// <summary>�e�q�ɃR�[�h</summary>
        private string _parentWarehouseCode = "";

        /// <summary>�e�q�ɖ���</summary>
        private string _parentWarehouseName = "";

        /// <summary>�e���ݍ݌ɐ�</summary>
        /// <remarks>�d���݌ɐ�</remarks>
        private Double _parentSupplierStock;

        /// <summary>�e�ō��݌ɐ�</summary>
        private Double _parentMaximumStockCnt;

        /// <summary>�e�Œ�݌ɐ�</summary>
        private Double _parentMinimumStockCnt;

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>�q���i�ԍ�</summary>
        private string _subGoodsNo = "";

        /// <summary>�q���i���̃J�i</summary>
        private string _subGoodsNameKana = "";

        /// <summary>�q���i���[�J�[�R�[�h</summary>
        private Int32 _subGoodsMakerCd;

        /// <summary>QTY</summary>
        /// <remarks>���ʁi�����j</remarks>
        private Double _cntFl;

        /// <summary>�񋟋敪</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;

        /// <summary>�q���ݍ݌ɐ�</summary>
        /// <remarks>�d���݌ɐ�</remarks>
        private Double _subSupplierStock;

        /// <summary>���_�q�ɃR�[�h�P</summary>
        /// <remarks>���_���̑q�ɗD�揇��1</remarks>
        private string _sectWarehouseCd1 = "";

        /// <summary>���_�q�ɃR�[�h�Q</summary>
        /// <remarks>���_���̑q�ɗD�揇��2</remarks>
        private string _sectWarehouseCd2 = "";

        /// <summary>���_�q�ɃR�[�h�R</summary>
        /// <remarks>���_���̑q�ɗD�揇��3</remarks>
        private string _sectWarehouseCd3 = "";


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  ParentGoodsNo
        /// <summary>�e���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentGoodsNo
        {
            get { return _parentGoodsNo; }
            set { _parentGoodsNo = value; }
        }

        /// public propaty name  :  ParentGoodsNameKana
        /// <summary>�e���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentGoodsNameKana
        {
            get { return _parentGoodsNameKana; }
            set { _parentGoodsNameKana = value; }
        }

        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>�e���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
        }

        /// public propaty name  :  ParentMakerShortName
        /// <summary>�e���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentMakerShortName
        {
            get { return _parentMakerShortName; }
            set { _parentMakerShortName = value; }
        }

        /// public propaty name  :  ParentWarehouseCode
        /// <summary>�e�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentWarehouseCode
        {
            get { return _parentWarehouseCode; }
            set { _parentWarehouseCode = value; }
        }

        /// public propaty name  :  ParentWarehouseName
        /// <summary>�e�q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ParentWarehouseName
        {
            get { return _parentWarehouseName; }
            set { _parentWarehouseName = value; }
        }

        /// public propaty name  :  ParentSupplierStock
        /// <summary>�e���ݍ݌ɐ��v���p�e�B</summary>
        /// <value>�d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���ݍ݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ParentSupplierStock
        {
            get { return _parentSupplierStock; }
            set { _parentSupplierStock = value; }
        }

        /// public propaty name  :  ParentMaximumStockCnt
        /// <summary>�e�ō��݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�ō��݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ParentMaximumStockCnt
        {
            get { return _parentMaximumStockCnt; }
            set { _parentMaximumStockCnt = value; }
        }

        /// public propaty name  :  ParentMinimumStockCnt
        /// <summary>�e�Œ�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�Œ�݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ParentMinimumStockCnt
        {
            get { return _parentMinimumStockCnt; }
            set { _parentMinimumStockCnt = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  SubGoodsNo
        /// <summary>�q���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubGoodsNo
        {
            get { return _subGoodsNo; }
            set { _subGoodsNo = value; }
        }

        /// public propaty name  :  SubGoodsNameKana
        /// <summary>�q���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubGoodsNameKana
        {
            get { return _subGoodsNameKana; }
            set { _subGoodsNameKana = value; }
        }

        /// public propaty name  :  SubGoodsMakerCd
        /// <summary>�q���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubGoodsMakerCd
        {
            get { return _subGoodsMakerCd; }
            set { _subGoodsMakerCd = value; }
        }

        /// public propaty name  :  CntFl
        /// <summary>QTY�v���p�e�B</summary>
        /// <value>���ʁi�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CntFl
        {
            get { return _cntFl; }
            set { _cntFl = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟋敪�v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// public propaty name  :  SubSupplierStock
        /// <summary>�q���ݍ݌ɐ��v���p�e�B</summary>
        /// <value>�d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q���ݍ݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SubSupplierStock
        {
            get { return _subSupplierStock; }
            set { _subSupplierStock = value; }
        }

        /// public propaty name  :  SectWarehouseCd1
        /// <summary>���_�q�ɃR�[�h�P�v���p�e�B</summary>
        /// <value>���_���̑q�ɗD�揇��1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�q�ɃR�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

        /// public propaty name  :  SectWarehouseCd2
        /// <summary>���_�q�ɃR�[�h�Q�v���p�e�B</summary>
        /// <value>���_���̑q�ɗD�揇��2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�q�ɃR�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectWarehouseCd2
        {
            get { return _sectWarehouseCd2; }
            set { _sectWarehouseCd2 = value; }
        }

        /// public propaty name  :  SectWarehouseCd3
        /// <summary>���_�q�ɃR�[�h�R�v���p�e�B</summary>
        /// <value>���_���̑q�ɗD�揇��3</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�q�ɃR�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectWarehouseCd3
        {
            get { return _sectWarehouseCd3; }
            set { _sectWarehouseCd3 = value; }
        }


        /// <summary>
        /// �݌ɑg���E�����������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StckAssemOvhulRstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StckAssemOvhulRstWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StckAssemOvhulRstWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StckAssemOvhulRstWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StckAssemOvhulRstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StckAssemOvhulRstWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StckAssemOvhulRstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StckAssemOvhulRstWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StckAssemOvhulRstWork || graph is ArrayList || graph is StckAssemOvhulRstWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StckAssemOvhulRstWork).FullName));

            if (graph != null && graph is StckAssemOvhulRstWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StckAssemOvhulRstWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StckAssemOvhulRstWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StckAssemOvhulRstWork[])graph).Length;
            }
            else if (graph is StckAssemOvhulRstWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�e���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //ParentGoodsNo
            //�e���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //ParentGoodsNameKana
            //�e���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ParentGoodsMakerCd
            //�e���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //ParentMakerShortName
            //�e�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ParentWarehouseCode
            //�e�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //ParentWarehouseName
            //�e���ݍ݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //ParentSupplierStock
            //�e�ō��݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //ParentMaximumStockCnt
            //�e�Œ�݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //ParentMinimumStockCnt
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //�q���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SubGoodsNo
            //�q���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //SubGoodsNameKana
            //�q���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubGoodsMakerCd
            //QTY
            serInfo.MemberInfo.Add(typeof(Double)); //CntFl
            //�񋟋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //�q���ݍ݌ɐ�
            serInfo.MemberInfo.Add(typeof(Double)); //SubSupplierStock
            //���_�q�ɃR�[�h�P
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd1
            //���_�q�ɃR�[�h�Q
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd2
            //���_�q�ɃR�[�h�R
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd3


            serInfo.Serialize(writer, serInfo);
            if (graph is StckAssemOvhulRstWork)
            {
                StckAssemOvhulRstWork temp = (StckAssemOvhulRstWork)graph;

                SetStckAssemOvhulRstWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StckAssemOvhulRstWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StckAssemOvhulRstWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StckAssemOvhulRstWork temp in lst)
                {
                    SetStckAssemOvhulRstWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StckAssemOvhulRstWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  StckAssemOvhulRstWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StckAssemOvhulRstWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStckAssemOvhulRstWork(System.IO.BinaryWriter writer, StckAssemOvhulRstWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�e���i�ԍ�
            writer.Write(temp.ParentGoodsNo);
            //�e���i���̃J�i
            writer.Write(temp.ParentGoodsNameKana);
            //�e���i���[�J�[�R�[�h
            writer.Write(temp.ParentGoodsMakerCd);
            //�e���[�J�[����
            writer.Write(temp.ParentMakerShortName);
            //�e�q�ɃR�[�h
            writer.Write(temp.ParentWarehouseCode);
            //�e�q�ɖ���
            writer.Write(temp.ParentWarehouseName);
            //�e���ݍ݌ɐ�
            writer.Write(temp.ParentSupplierStock);
            //�e�ō��݌ɐ�
            writer.Write(temp.ParentMaximumStockCnt);
            //�e�Œ�݌ɐ�
            writer.Write(temp.ParentMinimumStockCnt);
            //�\������
            writer.Write(temp.DisplayOrder);
            //�q���i�ԍ�
            writer.Write(temp.SubGoodsNo);
            //�q���i���̃J�i
            writer.Write(temp.SubGoodsNameKana);
            //�q���i���[�J�[�R�[�h
            writer.Write(temp.SubGoodsMakerCd);
            //QTY
            writer.Write(temp.CntFl);
            //�񋟋敪
            writer.Write(temp.OfferDataDiv);
            //�q���ݍ݌ɐ�
            writer.Write(temp.SubSupplierStock);
            //���_�q�ɃR�[�h�P
            writer.Write(temp.SectWarehouseCd1);
            //���_�q�ɃR�[�h�Q
            writer.Write(temp.SectWarehouseCd2);
            //���_�q�ɃR�[�h�R
            writer.Write(temp.SectWarehouseCd3);

        }

        /// <summary>
        ///  StckAssemOvhulRstWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StckAssemOvhulRstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StckAssemOvhulRstWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StckAssemOvhulRstWork GetStckAssemOvhulRstWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StckAssemOvhulRstWork temp = new StckAssemOvhulRstWork();

            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�e���i�ԍ�
            temp.ParentGoodsNo = reader.ReadString();
            //�e���i���̃J�i
            temp.ParentGoodsNameKana = reader.ReadString();
            //�e���i���[�J�[�R�[�h
            temp.ParentGoodsMakerCd = reader.ReadInt32();
            //�e���[�J�[����
            temp.ParentMakerShortName = reader.ReadString();
            //�e�q�ɃR�[�h
            temp.ParentWarehouseCode = reader.ReadString();
            //�e�q�ɖ���
            temp.ParentWarehouseName = reader.ReadString();
            //�e���ݍ݌ɐ�
            temp.ParentSupplierStock = reader.ReadDouble();
            //�e�ō��݌ɐ�
            temp.ParentMaximumStockCnt = reader.ReadDouble();
            //�e�Œ�݌ɐ�
            temp.ParentMinimumStockCnt = reader.ReadDouble();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //�q���i�ԍ�
            temp.SubGoodsNo = reader.ReadString();
            //�q���i���̃J�i
            temp.SubGoodsNameKana = reader.ReadString();
            //�q���i���[�J�[�R�[�h
            temp.SubGoodsMakerCd = reader.ReadInt32();
            //QTY
            temp.CntFl = reader.ReadDouble();
            //�񋟋敪
            temp.OfferDataDiv = reader.ReadInt32();
            //�q���ݍ݌ɐ�
            temp.SubSupplierStock = reader.ReadDouble();
            //���_�q�ɃR�[�h�P
            temp.SectWarehouseCd1 = reader.ReadString();
            //���_�q�ɃR�[�h�Q
            temp.SectWarehouseCd2 = reader.ReadString();
            //���_�q�ɃR�[�h�R
            temp.SectWarehouseCd3 = reader.ReadString();


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
        /// <returns>StckAssemOvhulRstWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StckAssemOvhulRstWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StckAssemOvhulRstWork temp = GetStckAssemOvhulRstWork(reader, serInfo);
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
                    retValue = (StckAssemOvhulRstWork[])lst.ToArray(typeof(StckAssemOvhulRstWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
