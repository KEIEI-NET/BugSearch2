//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�ݒ�}�X�^���o���ʁiPM���j���[�N
// �v���O�����T�v   : �����������i�ݒ�}�X�^���o���ʁiPM���j���[�N�f�[�^�p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��������
// �� �� ��  2015/02/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecBgnGdsPMWork
    /// <summary>
    ///                      �����������i�ݒ�}�X�^���o���ʁiPM���j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����������i�ݒ�}�X�^���o���ʁiPM���j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGdsPMWork 
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

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i���[�J�[����</summary>
        private string _goodsMakerNm = "";

        /// <summary>���i����</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _goodsName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>(PM�ŗ��p) ���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i�R�����g</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _goodsComment = "";

        /// <summary>���[�J�[��]�������i</summary>
        private Int64 _mkrSuggestRtPric;

        /// <summary>�艿</summary>
        private Int64 _listPrice;

        /// <summary>�P���Z�o�|��</summary>
        /// <remarks>(9.99)</remarks>
        private double _unitCalcRate;

        /// <summary>�P��</summary>
        private Int64 _unitPrice;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

        /// <summary>�K���Ԏ�敪</summary>
        /// <remarks>0:�K���Ԏ�Ȃ�,1:�K���Ԏ킠��</remarks>
        private Int16 _modelFitDiv;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        /// <remarks>(PM�ŗ��p)</remarks>
        private Int32 _custRateGrpCode;

        /// <summary>�\���敪</summary>
        /// <remarks>0:�\��,1:��\��</remarks>
        private Int32 _displayDivCode;

        /// <summary>���������i�O���[�v�R�[�h</summary>
        /// <remarks>0:�O���[�v����</remarks>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>���i�摜</summary>
        private Byte[] _goodsImage = new Byte[0];

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

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerNm
        /// <summary>���i���[�J�[����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerNm
        {
            get { return _goodsMakerNm; }
            set { _goodsMakerNm = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i����</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <value>(PM�ŗ��p) ���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsComment
        /// <summary>���i�R�����g</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�R�����g</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsComment
        {
            get { return _goodsComment; }
            set { _goodsComment = value; }
        }

        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>���[�J�[��]�������i</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[��]�������i</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  UnitCalcRate
        /// <summary>�P���Z�o�|��</summary>
        /// <value>(9.99)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P���Z�o�|��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double UnitCalcRate
        {
            get { return _unitCalcRate; }
            set { _unitCalcRate = value; }
        }

        /// public propaty name  :  UnitPrice
        /// <summary>�P��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �P��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n��</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I����</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ModelFitDiv
        /// <summary>�K���Ԏ�敪</summary>
        /// <value>0:�K���Ԏ�Ȃ�,1:�K���Ԏ킠��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K���Ԏ�敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ModelFitDiv
        {
            get { return _modelFitDiv; }
            set { _modelFitDiv = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        /// <value>(PM�ŗ��p)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }

        /// public propaty name  :  DisplayDivCode
        /// <summary>�\���敪</summary>
        /// <value>0:�\��,1:��\��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>���������i�O���[�v�R�[�h</summary>
        /// <value>0:�O���[�v����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�O���[�v�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }

        /// public propaty name  :  GoodsImage
        /// <summary>���i�摜</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�摜</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] GoodsImage
        {
            get { return _goodsImage; }
            set { _goodsImage = value; }
        }



        /// <summary>
        /// �����������i�ݒ�}�X�^���o���ʁiPM���j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RecBgnGdsPMWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RecBgnGdsPMWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RecBgnGdsPMWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RecBgnGdsPMWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnGdsPMWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGdsPMWork || graph is ArrayList || graph is RecBgnGdsPMWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RecBgnGdsPMWork).FullName));

            if (graph != null && graph is RecBgnGdsPMWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGdsPMWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGdsPMWork[])graph).Length;
            }
            else if (graph is RecBgnGdsPMWork)
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
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���i�R�����g
            serInfo.MemberInfo.Add(typeof(string)); //GoodsComment
            //���[�J�[��]�������i
            serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
            //�艿
            serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
            //�P���Z�o�|��
            serInfo.MemberInfo.Add(typeof(double)); //UnitCalcRate
            //�P��
            serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
            //�K�p�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
            //�K�p�I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
            //�K���Ԏ�敪
            serInfo.MemberInfo.Add(typeof(Int16)); //ModelFitDiv
            //���Ӑ�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayDivCode
            //���������i�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int16)); //BrgnGoodsGrpCode
            //���i�摜
            serInfo.MemberInfo.Add(typeof(Byte[])); //GoodsImage



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGdsPMWork)
            {
                RecBgnGdsPMWork temp = (RecBgnGdsPMWork)graph;

                SetRecBgnGdsPMWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGdsPMWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGdsPMWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGdsPMWork temp in lst)
                {
                    SetRecBgnGdsPMWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGdsPMWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 23;

        /// <summary>
        ///  RecBgnGdsPMWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRecBgnGdsPMWork(System.IO.BinaryWriter writer, RecBgnGdsPMWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //�_���폜�敪
            writer.Write((Int32)temp.LogicalDeleteCode);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write((Int32)temp.GoodsMakerCd);
            //���i���[�J�[����
            writer.Write(temp.GoodsMakerNm);
            //���i����
            writer.Write(temp.GoodsName);
            //BL�O���[�v�R�[�h
            writer.Write((Int32)temp.BLGroupCode);
            //BL���i�R�[�h
            writer.Write((Int32)temp.BLGoodsCode);
            //���i�R�����g
            writer.Write(temp.GoodsComment);
            //���[�J�[��]�������i
            writer.Write((Int64)temp.MkrSuggestRtPric);
            //�艿
            writer.Write((Int64)temp.ListPrice);
            //�P���Z�o�|��
            writer.Write((double)temp.UnitCalcRate);
            //�P��
            writer.Write((Int64)temp.UnitPrice);
            //�K�p�J�n��
            writer.Write((Int32)temp.ApplyStaDate);
            //�K�p�I����
            writer.Write((Int32)temp.ApplyEndDate);
            //�K���Ԏ�敪
            writer.Write(temp.ModelFitDiv);
            //���Ӑ�|���O���[�v�R�[�h
            writer.Write((Int32)temp.CustRateGrpCode);
            //�\���敪
            writer.Write((Int32)temp.DisplayDivCode);
            //���������i�O���[�v�R�[�h
            writer.Write(temp.BrgnGoodsGrpCode);
            //���i�摜
            writer.Write(temp.GoodsImage.Length);
            writer.Write(temp.GoodsImage);


        }

        /// <summary>
        ///  RecBgnGdsPMWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RecBgnGdsPMWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RecBgnGdsPMWork GetRecBgnGdsPMWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RecBgnGdsPMWork temp = new RecBgnGdsPMWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i���[�J�[����
            temp.GoodsMakerNm = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���i�R�����g
            temp.GoodsComment = reader.ReadString();
            //���[�J�[��]�������i
            temp.MkrSuggestRtPric = reader.ReadInt64();
            //�艿
            temp.ListPrice = reader.ReadInt64();
            //�P���Z�o�|��
            temp.UnitCalcRate = reader.ReadDouble();
            //�P��
            temp.UnitPrice = reader.ReadInt64();
            //�K�p�J�n��
            temp.ApplyStaDate = reader.ReadInt32();
            //�K�p�I����
            temp.ApplyEndDate = reader.ReadInt32();
            //�K���Ԏ�敪
            temp.ModelFitDiv = reader.ReadInt16();
            //���Ӑ�|���O���[�v�R�[�h
            temp.CustRateGrpCode = reader.ReadInt32();
            //�\���敪
            temp.DisplayDivCode = reader.ReadInt32();
            //���������i�O���[�v�R�[�h
            temp.BrgnGoodsGrpCode = reader.ReadInt16();
            //���i�摜
            int length = reader.ReadInt32();
            temp.GoodsImage = reader.ReadBytes(length);



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
        /// <returns>RecBgnGdsPMWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RecBgnGdsPMWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGdsPMWork temp = GetRecBgnGdsPMWork(reader, serInfo);
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
                    retValue = (RecBgnGdsPMWork[])lst.ToArray(typeof(RecBgnGdsPMWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
