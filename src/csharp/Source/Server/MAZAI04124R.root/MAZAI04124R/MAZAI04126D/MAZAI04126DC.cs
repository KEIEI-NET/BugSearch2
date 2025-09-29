using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMoveSlipSearchCondWork
    /// <summary>
    ///                      �݌Ɉړ��`�[�����������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɉړ��`�[�����������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/01/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      :   2012/05/22 wangf </br>
    /// <br>�@�@�@�@         :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMoveSlipSearchCondWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h</summary>
        /// <remarks>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _stockMvEmpCode = "";

        /// <summary>�o�גS���]�ƈ��R�[�h</summary>
        /// <remarks>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</remarks>
        private string _shipAgentCd = "";

        /// <summary>����S���]�ƈ��R�[�h</summary>
        /// <remarks>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</remarks>
        private string _receiveAgentCd = "";

        /// <summary>�o�ח\��J�n��</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentScdlStDay;

        /// <summary>�o�ח\��I����</summary>
        /// <remarks>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentScdlEdDay;

        /// <summary>�o�׊m��J�n��</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentFixStDay;

        /// <summary>�o�׊m��I����</summary>
        /// <remarks>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</remarks>
        private DateTime _shipmentFixEdDay;

        /// <summary>���׊J�n��</summary>
        private DateTime _arrivalGoodsStDay;

        /// <summary>���׏I����</summary>
        private DateTime _arrivalGoodsEdDay;

        /// <summary>�ړ������_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _afEnterWarehCode = "";

        /// <summary>�ړ����</summary>
        /// <remarks>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</remarks>
        private Int32[] _moveStatus;

        /// <summary>�݌Ɉړ��m��敪</summary>
        /// <remarks>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </remarks>
        private Int32 _stockMoveFixCode;

        /// <summary>�`�[�敪</summary>
        /// <remarks>1:�o�ɓ`�[�A2�F���ɓ`�[</remarks>
        private Int32 _slipDiv;

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// <summary>�ďo���@�\�敪</summary>
        /// <remarks>1:�݌Ɉړ����͌����K�C�h�A2�F���̏ꍇ</remarks>
        private Int32 _callerFunction;
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

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

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMvEmpCode
        /// <summary>�݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌Ɉړ��`�[����͂���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ����͏]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _stockMvEmpCode; }
            set { _stockMvEmpCode = value; }
        }

        /// public propaty name  :  ShipAgentCd
        /// <summary>�o�גS���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�o�׊m�菈�����s���]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�גS���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _shipAgentCd; }
            set { _shipAgentCd = value; }
        }

        /// public propaty name  :  ReceiveAgentCd
        /// <summary>����S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�݌ɂ̓��ב��̏]�ƈ��R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _receiveAgentCd; }
            set { _receiveAgentCd = value; }
        }

        /// public propaty name  :  ShipmentScdlStDay
        /// <summary>�o�ח\��J�n���v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\��J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentScdlStDay
        {
            get { return _shipmentScdlStDay; }
            set { _shipmentScdlStDay = value; }
        }

        /// public propaty name  :  ShipmentScdlEdDay
        /// <summary>�o�ח\��I�����v���p�e�B</summary>
        /// <value>�݌Ɉړ������i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ח\��I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentScdlEdDay
        {
            get { return _shipmentScdlEdDay; }
            set { _shipmentScdlEdDay = value; }
        }

        /// public propaty name  :  ShipmentFixStDay
        /// <summary>�o�׊m��J�n���v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׊m��J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentFixStDay
        {
            get { return _shipmentFixStDay; }
            set { _shipmentFixStDay = value; }
        }

        /// public propaty name  :  ShipmentFixEdDay
        /// <summary>�o�׊m��I�����v���p�e�B</summary>
        /// <value>�o�׊m�菈���i�o�ב��j���s�������ɃZ�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׊m��I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipmentFixEdDay
        {
            get { return _shipmentFixEdDay; }
            set { _shipmentFixEdDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsStDay
        /// <summary>���׊J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׊J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ArrivalGoodsStDay
        {
            get { return _arrivalGoodsStDay; }
            set { _arrivalGoodsStDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsEdDay
        /// <summary>���׏I�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׏I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ArrivalGoodsEdDay
        {
            get { return _arrivalGoodsEdDay; }
            set { _arrivalGoodsEdDay = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ����q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ��拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  MoveStatus
        /// <summary>�ړ���ԃv���p�e�B</summary>
        /// <value>0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ړ���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  StockMoveFixCode
        /// <summary>�݌Ɉړ��m��敪�v���p�e�B</summary>
        /// <value>1�F���׊m�肠��A�Q�F���׊m��Ȃ� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉړ��m��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

        /// public propaty name  :  StockMoveFormal
        /// <summary>�`�[�敪�v���p�e�B</summary>
        /// <value>1:�o�ɓ`�[�A2�F���ɓ`�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipDiv
        {
            get { return _slipDiv; }
            set { _slipDiv = value; }
        }

        // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
        /// public propaty name  :  CallerFunction
        /// <summary>�ďo���@�\�敪�v���p�e�B</summary>
        /// <value>1:�݌Ɉړ����͌����K�C�h�A2�F���̏ꍇ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ďo���@�\�敪�v���p�e�B</br>
        /// <br>Programer        :   wangf</br>
        /// </remarks>
        public Int32 CallerFunction
        {
            get { return _callerFunction; }
            set { _callerFunction = value; }
        }
        // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        /// <summary>
        /// �݌Ɉړ��`�[�����������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockMoveSlipSearchCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveSlipSearchCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockMoveSlipSearchCondWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockMoveSlipSearchCondWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockMoveSlipSearchCondWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockMoveSlipSearchCondWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveSlipSearchCondWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/05/22 wangf </br>
        /// <br>                 :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMoveSlipSearchCondWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMoveSlipSearchCondWork || graph is ArrayList || graph is StockMoveSlipSearchCondWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockMoveSlipSearchCondWork).FullName));

            if (graph != null && graph is StockMoveSlipSearchCondWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMoveSlipSearchCondWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMoveSlipSearchCondWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMoveSlipSearchCondWork[])graph).Length;
            }
            else if (graph is StockMoveSlipSearchCondWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�݌Ɉړ��`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //�݌Ɉړ����͏]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockMvEmpCode
            //�o�גS���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ShipAgentCd
            //����S���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ReceiveAgentCd
            //�o�ח\��J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlStDay
            //�o�ח\��I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlEdDay
            //�o�׊m��J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixStDay
            //�o�׊m��I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixEdDay
            //���׊J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsStDay
            //���׏I����
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsEdDay
            //�ړ������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //�ړ����q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //�ړ��拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //�ړ���q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            ////�ړ����
            //serInfo.MemberInfo.Add(typeof(Int32[])); //MoveStatus
            //�݌Ɉړ��m��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFixCode
            //�`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDiv
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //�ďo���@�\�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CallerFunction
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMoveSlipSearchCondWork)
            {
                StockMoveSlipSearchCondWork temp = (StockMoveSlipSearchCondWork)graph;

                SetStockMoveSlipSearchCondWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMoveSlipSearchCondWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMoveSlipSearchCondWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMoveSlipSearchCondWork temp in lst)
                {
                    SetStockMoveSlipSearchCondWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMoveSlipSearchCondWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 18; // DEL wangf 2012/05/22 FOR Redmine#29881
        private const int currentMemberCount = 19; // ADD wangf 2012/05/22 FOR Redmine#29881

        /// <summary>
        ///  StockMoveSlipSearchCondWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveSlipSearchCondWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/05/22 wangf </br>
        /// <br>                 :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
        /// </remarks>
        private void SetStockMoveSlipSearchCondWork(System.IO.BinaryWriter writer, StockMoveSlipSearchCondWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�݌Ɉړ��`�[�ԍ�
            writer.Write(temp.StockMoveSlipNo);
            //�݌Ɉړ����͏]�ƈ��R�[�h
            writer.Write(temp.StockMvEmpCode);
            //�o�גS���]�ƈ��R�[�h
            writer.Write(temp.ShipAgentCd);
            //����S���]�ƈ��R�[�h
            writer.Write(temp.ReceiveAgentCd);
            //�o�ח\��J�n��
            writer.Write((Int64)temp.ShipmentScdlStDay.Ticks);
            //�o�ח\��I����
            writer.Write((Int64)temp.ShipmentScdlEdDay.Ticks);
            //�o�׊m��J�n��
            writer.Write((Int64)temp.ShipmentFixStDay.Ticks);
            //�o�׊m��I����
            writer.Write((Int64)temp.ShipmentFixEdDay.Ticks);
            //���׊J�n��
            writer.Write((Int64)temp.ArrivalGoodsStDay.Ticks);
            //���׏I����
            writer.Write((Int64)temp.ArrivalGoodsEdDay.Ticks);
            //�ړ������_�R�[�h
            writer.Write(temp.BfSectionCode);
            //�ړ����q�ɃR�[�h
            writer.Write(temp.BfEnterWarehCode);
            //�ړ��拒�_�R�[�h
            writer.Write(temp.AfSectionCode);
            //�ړ���q�ɃR�[�h
            writer.Write(temp.AfEnterWarehCode);
            ////�ړ����
            //writer.Write(temp.MoveStatus);
            //�݌Ɉړ��m��敪
            writer.Write(temp.StockMoveFixCode);
            //�`�[�敪
            writer.Write(temp.SlipDiv);
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //�ďo���@�\�敪
            writer.Write(temp.CallerFunction);
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<

        }

        /// <summary>
        ///  StockMoveSlipSearchCondWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockMoveSlipSearchCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveSlipSearchCondWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2012/05/22 wangf </br>
        /// <br>                 :   10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�</br>
        /// </remarks>
        private StockMoveSlipSearchCondWork GetStockMoveSlipSearchCondWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockMoveSlipSearchCondWork temp = new StockMoveSlipSearchCondWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�݌Ɉړ��`�[�ԍ�
            temp.StockMoveSlipNo = reader.ReadInt32();
            //�݌Ɉړ����͏]�ƈ��R�[�h
            temp.StockMvEmpCode = reader.ReadString();
            //�o�גS���]�ƈ��R�[�h
            temp.ShipAgentCd = reader.ReadString();
            //����S���]�ƈ��R�[�h
            temp.ReceiveAgentCd = reader.ReadString();
            //�o�ח\��J�n��
            temp.ShipmentScdlStDay = new DateTime(reader.ReadInt64());
            //�o�ח\��I����
            temp.ShipmentScdlEdDay = new DateTime(reader.ReadInt64());
            //�o�׊m��J�n��
            temp.ShipmentFixStDay = new DateTime(reader.ReadInt64());
            //�o�׊m��I����
            temp.ShipmentFixEdDay = new DateTime(reader.ReadInt64());
            //���׊J�n��
            temp.ArrivalGoodsStDay = new DateTime(reader.ReadInt64());
            //���׏I����
            temp.ArrivalGoodsEdDay = new DateTime(reader.ReadInt64());
            //�ړ������_�R�[�h
            temp.BfSectionCode = reader.ReadString();
            //�ړ����q�ɃR�[�h
            temp.BfEnterWarehCode = reader.ReadString();
            //�ړ��拒�_�R�[�h
            temp.AfSectionCode = reader.ReadString();
            //�ړ���q�ɃR�[�h
            temp.AfEnterWarehCode = reader.ReadString();
            ////�ړ����
            //temp.MoveStatus = reader.ReadInt32();
            //�݌Ɉړ��m��敪
            temp.StockMoveFixCode = reader.ReadInt32();
            //�`�[�敪
            temp.SlipDiv = reader.ReadInt32();
            // ------------ADD START wangf 2012/05/22 FOR Redmine#29881--------->>>>
            //�ďo���@�\�敪
            temp.CallerFunction = reader.ReadInt32();
            // ------------ADD END wangf 2012/05/22 FOR Redmine#29881---------<<<<<


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
        /// <returns>StockMoveSlipSearchCondWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockMoveSlipSearchCondWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMoveSlipSearchCondWork temp = GetStockMoveSlipSearchCondWork(reader, serInfo);
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
                    retValue = (StockMoveSlipSearchCondWork[])lst.ToArray(typeof(StockMoveSlipSearchCondWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
