using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockAdjRefSearchParaWork
    /// <summary>
    ///                      �݌Ɏd���`�[�Ɖ�o�������[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɏd���`�[�Ɖ�o�������[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/08/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockAdjRefSearchParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>�󕥌��`�[�敪</summary>
        /// <remarks>10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>�󕥌�����敪</summary>
        /// <remarks>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</remarks>
        private Int32 _acPayTransCd;

        /// <summary>�J�n���͓��t</summary>
        /// <remarks>���͓�</remarks>
        private Int32 _st_InputDay;

        /// <summary>�I�����͓��t</summary>
        /// <remarks>���͓�</remarks>
        private Int32 _ed_InputDay;

        /// <summary>�J�n�������t</summary>
        /// <remarks>�쐬��</remarks>
        private Int32 _st_AdjustDate;

        /// <summary>�I���������t</summary>
        /// <remarks>�쐬��</remarks>
        private Int32 _ed_AdjustDate;

        /// <summary>�J�n�݌ɒ����`�[�ԍ�</summary>
        /// <remarks>�`�[�ԍ�</remarks>
        private Int32 _st_StockAdjustSlipNo;

        /// <summary>�I���݌ɒ����`�[�ԍ�</summary>
        /// <remarks>�`�[�ԍ�</remarks>
        private Int32 _ed_StockAdjustSlipNo;

        /// <summary>�d���S���҃R�[�h</summary>
        /// <remarks>�S����</remarks>
        private string _stockAgentCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i�ԍ������^�C�v</summary>
        /// <remarks>0:���S��v�A1:�O����v�A2:�����v�A3:�����܂�</remarks>
        private Int32 _goodsNoTyp;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̌����^�C�v</summary>
        /// <remarks>0:���S��v�A1:�O����v�A2:�����v�A3:�����܂�</remarks>
        private Int32 _goodsNameTyp;

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�q�ɒI�Ԍ����^�C�v</summary>
        /// <remarks>0:���S��v�A1:�O����v�A2:�����v�A3:�����܂�</remarks>
        private Int32 _warehouseShelfNoTyp;


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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  AcPaySlipCd
        /// <summary>�󕥌��`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,11:���,12:��v��,13:�݌Ɏd��,20:����,21:���v��,22:�ϑ�,23:����,30:�ړ��o��,31:�ړ�����,40:����,41:����,42:�}�X�^�����e,50:�I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌��`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>�󕥌�����敪�v���p�e�B</summary>
        /// <value>10:�ʏ�`�[,11:�ԕi,12:�l��,20:�ԓ`,21:�폜,22:����,30:�݌ɐ�����,31:��������,32:���Ԓ���,33:�s�Ǖi,34:���o,35:����,40:�ߕs���X�V,90:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󕥌�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>�J�n���͓��t�v���p�e�B</summary>
        /// <value>���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>�I�����͓��t�v���p�e�B</summary>
        /// <value>���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  St_AdjustDate
        /// <summary>�J�n�������t�v���p�e�B</summary>
        /// <value>�쐬��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_AdjustDate
        {
            get { return _st_AdjustDate; }
            set { _st_AdjustDate = value; }
        }

        /// public propaty name  :  Ed_AdjustDate
        /// <summary>�I���������t�v���p�e�B</summary>
        /// <value>�쐬��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_AdjustDate
        {
            get { return _ed_AdjustDate; }
            set { _ed_AdjustDate = value; }
        }

        /// public propaty name  :  St_StockAdjustSlipNo
        /// <summary>�J�n�݌ɒ����`�[�ԍ��v���p�e�B</summary>
        /// <value>�`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�݌ɒ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_StockAdjustSlipNo
        {
            get { return _st_StockAdjustSlipNo; }
            set { _st_StockAdjustSlipNo = value; }
        }

        /// public propaty name  :  Ed_StockAdjustSlipNo
        /// <summary>�I���݌ɒ����`�[�ԍ��v���p�e�B</summary>
        /// <value>�`�[�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌ɒ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_StockAdjustSlipNo
        {
            get { return _ed_StockAdjustSlipNo; }
            set { _ed_StockAdjustSlipNo = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// <value>�S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
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

        /// public propaty name  :  GoodsNoTyp
        /// <summary>���i�ԍ������^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v�A1:�O����v�A2:�����v�A3:�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoTyp
        {
            get { return _goodsNoTyp; }
            set { _goodsNoTyp = value; }
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

        /// public propaty name  :  GoodsNameTyp
        /// <summary>���i���̌����^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v�A1:�O����v�A2:�����v�A3:�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̌����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNameTyp
        {
            get { return _goodsNameTyp; }
            set { _goodsNameTyp = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  WarehouseShelfNoTyp
        /// <summary>�q�ɒI�Ԍ����^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v�A1:�O����v�A2:�����v�A3:�����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�Ԍ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseShelfNoTyp
        {
            get { return _warehouseShelfNoTyp; }
            set { _warehouseShelfNoTyp = value; }
        }


        /// <summary>
        /// �݌Ɏd���`�[�Ɖ�o�������[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockAdjRefSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAdjRefSearchParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockAdjRefSearchParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockAdjRefSearchParaWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockAdjRefSearchParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockAdjRefSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAdjRefSearchParaWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  StockAdjRefSearchParaWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is StockAdjRefSearchParaWork || graph is ArrayList || graph is StockAdjRefSearchParaWork[]) )
                throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof( StockAdjRefSearchParaWork ).FullName ) );

            if ( graph != null && graph is StockAdjRefSearchParaWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockAdjRefSearchParaWork" );

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is StockAdjRefSearchParaWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockAdjRefSearchParaWork[])graph).Length;
            }
            else if ( graph is StockAdjRefSearchParaWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //�󕥌��`�[�敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcPaySlipCd
            //�󕥌�����敪
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcPayTransCd
            //�J�n���͓��t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //St_InputDay
            //�I�����͓��t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Ed_InputDay
            //�J�n�������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //St_AdjustDate
            //�I���������t
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Ed_AdjustDate
            //�J�n�݌ɒ����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //St_StockAdjustSlipNo
            //�I���݌ɒ����`�[�ԍ�
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Ed_StockAdjustSlipNo
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //���i�ԍ������^�C�v
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsNoTyp
            //���i����
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //���i���̌����^�C�v
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsNameTyp
            //�q�ɒI��
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //�q�ɒI�Ԍ����^�C�v
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //WarehouseShelfNoTyp


            serInfo.Serialize( writer, serInfo );
            if ( graph is StockAdjRefSearchParaWork )
            {
                StockAdjRefSearchParaWork temp = (StockAdjRefSearchParaWork)graph;

                SetStockAdjRefSearchParaWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is StockAdjRefSearchParaWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (StockAdjRefSearchParaWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( StockAdjRefSearchParaWork temp in lst )
                {
                    SetStockAdjRefSearchParaWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// StockAdjRefSearchParaWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  StockAdjRefSearchParaWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAdjRefSearchParaWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockAdjRefSearchParaWork( System.IO.BinaryWriter writer, StockAdjRefSearchParaWork temp )
        {
            //��ƃR�[�h
            writer.Write( temp.EnterpriseCode );
            //���_�R�[�h
            writer.Write( temp.SectionCode );
            //�q�ɃR�[�h
            writer.Write( temp.WarehouseCode );
            //�󕥌��`�[�敪
            writer.Write( temp.AcPaySlipCd );
            //�󕥌�����敪
            writer.Write( temp.AcPayTransCd );
            //�J�n���͓��t
            writer.Write( temp.St_InputDay );
            //�I�����͓��t
            writer.Write( temp.Ed_InputDay );
            //�J�n�������t
            writer.Write( temp.St_AdjustDate );
            //�I���������t
            writer.Write( temp.Ed_AdjustDate );
            //�J�n�݌ɒ����`�[�ԍ�
            writer.Write( temp.St_StockAdjustSlipNo );
            //�I���݌ɒ����`�[�ԍ�
            writer.Write( temp.Ed_StockAdjustSlipNo );
            //�d���S���҃R�[�h
            writer.Write( temp.StockAgentCode );
            //���i���[�J�[�R�[�h
            writer.Write( temp.GoodsMakerCd );
            //���i�ԍ�
            writer.Write( temp.GoodsNo );
            //���i�ԍ������^�C�v
            writer.Write( temp.GoodsNoTyp );
            //���i����
            writer.Write( temp.GoodsName );
            //���i���̌����^�C�v
            writer.Write( temp.GoodsNameTyp );
            //�q�ɒI��
            writer.Write( temp.WarehouseShelfNo );
            //�q�ɒI�Ԍ����^�C�v
            writer.Write( temp.WarehouseShelfNoTyp );

        }

        /// <summary>
        ///  StockAdjRefSearchParaWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockAdjRefSearchParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAdjRefSearchParaWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockAdjRefSearchParaWork GetStockAdjRefSearchParaWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockAdjRefSearchParaWork temp = new StockAdjRefSearchParaWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�󕥌��`�[�敪
            temp.AcPaySlipCd = reader.ReadInt32();
            //�󕥌�����敪
            temp.AcPayTransCd = reader.ReadInt32();
            //�J�n���͓��t
            temp.St_InputDay = reader.ReadInt32();
            //�I�����͓��t
            temp.Ed_InputDay = reader.ReadInt32();
            //�J�n�������t
            temp.St_AdjustDate = reader.ReadInt32();
            //�I���������t
            temp.Ed_AdjustDate = reader.ReadInt32();
            //�J�n�݌ɒ����`�[�ԍ�
            temp.St_StockAdjustSlipNo = reader.ReadInt32();
            //�I���݌ɒ����`�[�ԍ�
            temp.Ed_StockAdjustSlipNo = reader.ReadInt32();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i�ԍ������^�C�v
            temp.GoodsNoTyp = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̌����^�C�v
            temp.GoodsNameTyp = reader.ReadInt32();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();
            //�q�ɒI�Ԍ����^�C�v
            temp.WarehouseShelfNoTyp = reader.ReadInt32();


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
        /// <returns>StockAdjRefSearchParaWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockAdjRefSearchParaWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                StockAdjRefSearchParaWork temp = GetStockAdjRefSearchParaWork( reader, serInfo );
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
                    retValue = (StockAdjRefSearchParaWork[])lst.ToArray( typeof( StockAdjRefSearchParaWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
