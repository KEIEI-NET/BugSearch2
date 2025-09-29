using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region [��r�N���X]
    
    /// <summary>
    /// �`�[���גǉ����f�[�^���[�N�̖��׊֘A�t��GUID�Ŕ�r���܂��B
    /// </summary>
    public class SlipDetailAddInfoDtlRelationGuidComparer : IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            Guid xGuid = Guid.Empty;

            if (x is Guid)
            {
                xGuid = (Guid)x;
            }
            else if (x is SlipDetailAddInfoWork)
            {
                xGuid = (x as SlipDetailAddInfoWork).DtlRelationGuid;
            }

            Guid yGuid = Guid.Empty;

            if (y is Guid)
            {
                yGuid = (Guid)y;
            }
            else if (y is SlipDetailAddInfoWork)
            {
                yGuid = (y as SlipDetailAddInfoWork).DtlRelationGuid;
            }

            return xGuid.CompareTo(yGuid);
        }
    }

    /// <summary>
    /// �`�[���גǉ����f�[�^���[�N�̓`�[���דo�^���ʂŔ�r���܂��B
    /// </summary>
    public class SlipDetailAddInfoRegOrderComparer : IComparer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            SlipDetailAddInfoWork xInfo = x as SlipDetailAddInfoWork;
            SlipDetailAddInfoWork yInfo = y as SlipDetailAddInfoWork;

            int ret = (xInfo == null ? 0 : 1) - (yInfo == null ? 0 : 1);

            if (ret == 0 && xInfo != null)
            {
                ret = xInfo.SlipDtlRegOrder.CompareTo(yInfo.SlipDtlRegOrder);
            }

            return ret;
        }
    }
    # endregion

    # region [�폜]
    # if false
    /// public class name:   SlipDetailAddInfoWork
    /// <summary>
    /// �`�[���גǉ����f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �`�[���גǉ����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/06/05</br>
    /// <br>Genarated Date   :   2008/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/02  �v�ۓc</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SlipDetailAddInfoWork
	{
		/// <summary>���׊֘A�t��GUID</summary>
		/// <remarks>�`�[���ׂƕR�t����ׂ�GUID�AUI���Őݒ�</remarks>
		private Guid _dtlRelationGuid;

		/// <summary>���i�o�^�敪</summary>
		/// <remarks>0:�Ȃ��@1:����</remarks>
		private Int32 _goodsEntryDiv;

		/// <summary>���i�񋟓��t</summary>
		/// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</remarks>
		private DateTime _goodsOfferDate;

		/// <summary>���i�X�V�敪</summary>
		/// <remarks>0:�Ȃ��@1:����</remarks>
		private Int32 _priceUpdateDiv;

		/// <summary>���i�J�n���t</summary>
		/// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</remarks>
		private DateTime _priceStartDate;

		/// <summary>���i�񋟓��t</summary>
		/// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</remarks>
		private DateTime _priceOfferDate;

		/// <summary>�ԗ��֘A�t��GUID</summary>
		/// <remarks>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</remarks>
		private Guid _carRelationGuid;

        /// <summary>�`�[���דo�^����</summary>
        /// <remarks>�`�[�E���ׂ̓o�^���ʂ�ݒ�</remarks>
        private Int32 _slipDtlRegOrder;


		/// public propaty name  :  DtlRelationGuid
		/// <summary>���׊֘A�t��GUID�v���p�e�B</summary>
		/// <value>�`�[���ׂƕR�t����ׂ�GUID�AUI���Őݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���׊֘A�t��GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid DtlRelationGuid
		{
			get{return _dtlRelationGuid;}
			set{_dtlRelationGuid = value;}
		}

		/// public propaty name  :  GoodsEntryDiv
		/// <summary>���i�o�^�敪�v���p�e�B</summary>
		/// <value>0:�Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�o�^�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsEntryDiv
		{
			get{return _goodsEntryDiv;}
			set{_goodsEntryDiv = value;}
		}

		/// public propaty name  :  GoodsOfferDate
		/// <summary>���i�񋟓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime GoodsOfferDate
		{
			get{return _goodsOfferDate;}
			set{_goodsOfferDate = value;}
		}

		/// public propaty name  :  PriceUpdateDiv
		/// <summary>���i�X�V�敪�v���p�e�B</summary>
		/// <value>0:�Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�X�V�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceUpdateDiv
		{
			get{return _priceUpdateDiv;}
			set{_priceUpdateDiv = value;}
		}

		/// public propaty name  :  PriceStartDate
		/// <summary>���i�J�n���t�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�J�n���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PriceStartDate
		{
			get{return _priceStartDate;}
			set{_priceStartDate = value;}
		}

		/// public propaty name  :  PriceOfferDate
		/// <summary>���i�񋟓��t�v���p�e�B</summary>
		/// <value>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime PriceOfferDate
		{
			get{return _priceOfferDate;}
			set{_priceOfferDate = value;}
		}

		/// public propaty name  :  CarRelationGuid
		/// <summary>�ԗ��֘A�t��GUID�v���p�e�B</summary>
		/// <value>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��֘A�t��GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid CarRelationGuid
		{
			get{return _carRelationGuid;}
			set{_carRelationGuid = value;}
		}

        /// public propaty name  :  SlipDtlRegOrder
        /// <summary>�`�[���דo�^���ʃv���p�e�B</summary>
        /// <value>�`�[�E���ׂ̓o�^���ʂ�ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���דo�^���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipDtlRegOrder
        {
            get { return _slipDtlRegOrder; }
            set { _slipDtlRegOrder = value; }
        }

		/// <summary>
		/// �`�[���גǉ����f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SlipDetailAddInfoWork()
		{
		}
	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SlipDetailAddInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipDetailAddInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipDetailAddInfoWork || graph is ArrayList || graph is SlipDetailAddInfoWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SlipDetailAddInfoWork).FullName));

            if (graph != null && graph is SlipDetailAddInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipDetailAddInfoWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipDetailAddInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipDetailAddInfoWork[])graph).Length;
            }
            else if (graph is SlipDetailAddInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���׊֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid
            //���i�o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsEntryDiv
            //���i�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //GoodsOfferDate
            //���i�X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceUpdateDiv
            //���i�J�n���t
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //���i�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceOfferDate
            //�ԗ��֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //CarRelationGuid
            //�`�[���דo�^����
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDtlRegOrder

            serInfo.Serialize(writer, serInfo);
            if (graph is SlipDetailAddInfoWork)
            {
                SlipDetailAddInfoWork temp = (SlipDetailAddInfoWork)graph;

                SetSlipDetailAddInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipDetailAddInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipDetailAddInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipDetailAddInfoWork temp in lst)
                {
                    SetSlipDetailAddInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipDetailAddInfoWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  SlipDetailAddInfoWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSlipDetailAddInfoWork(System.IO.BinaryWriter writer, SlipDetailAddInfoWork temp)
        {
            //���׊֘A�t��GUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
            //���i�o�^�敪
            writer.Write(temp.GoodsEntryDiv);
            //���i�񋟓��t
            writer.Write(temp.GoodsOfferDate.Ticks);
            //���i�X�V�敪
            writer.Write(temp.PriceUpdateDiv);
            //���i�J�n���t
            writer.Write(temp.PriceStartDate.Ticks);
            //���i�񋟓��t
            writer.Write(temp.PriceOfferDate.Ticks);
            //�ԗ��֘A�t��GUID
            byte[] carRelationGuidArray = temp.CarRelationGuid.ToByteArray();
            writer.Write(carRelationGuidArray.Length);
            writer.Write(temp.CarRelationGuid.ToByteArray());
            //�`�[���דo�^����
            writer.Write(temp.SlipDtlRegOrder);
        }

        /// <summary>
        ///  SlipDetailAddInfoWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SlipDetailAddInfoWork GetSlipDetailAddInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SlipDetailAddInfoWork temp = new SlipDetailAddInfoWork();

            //���׊֘A�t��GUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);
            //���i�o�^�敪
            temp.GoodsEntryDiv = reader.ReadInt32();
            //���i�񋟓��t
            temp.GoodsOfferDate = new DateTime(reader.ReadInt64());
            //���i�X�V�敪
            temp.PriceUpdateDiv = reader.ReadInt32();
            //���i�J�n���t
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //���i�񋟓��t
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());
            //�ԗ��֘A�t��GUID
            int lenOfCarRelationGuidArray = reader.ReadInt32();
            byte[] carRelationGuidArray = reader.ReadBytes(lenOfCarRelationGuidArray);
            temp.CarRelationGuid = new Guid(carRelationGuidArray);
            //�`�[���דo�^����
            temp.SlipDtlRegOrder = reader.ReadInt32();


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
        /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipDetailAddInfoWork temp = GetSlipDetailAddInfoWork(reader, serInfo);
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
                    retValue = (SlipDetailAddInfoWork[])lst.ToArray(typeof(SlipDetailAddInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    # endif
    # endregion

    /// public class name:   SlipDetailAddInfoWork
    /// <summary>
    ///                      �`�[���גǉ����f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �`�[���גǉ����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/06/05</br>
    /// <br>Genarated Date   :   2008/10/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/02  �v�ۓc</br>
    /// <br></br>
    /// <br>Update Note      :   �t�^�o�ʑΉ�</br>
    /// <br>                     �ԓ`��ԕi��폜���݌Ɉ��������Ή�</br>
    /// <br>Programmer       :   �e�c ���V</br>
    /// <br>Date             :   K2014/06/12</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SlipDetailAddInfoWork
    {
        /// <summary>���׊֘A�t��GUID</summary>
        /// <remarks>�`�[���ׂƕR�t����ׂ�GUID�AUI���Őݒ�</remarks>
        private Guid _dtlRelationGuid;

        /// <summary>���i�o�^�敪</summary>
        /// <remarks>0:�Ȃ��@1:����</remarks>
        private Int32 _goodsEntryDiv;

        /// <summary>���i�񋟓��t</summary>
        /// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</remarks>
        private DateTime _goodsOfferDate;

        /// <summary>���i�X�V�敪</summary>
        /// <remarks>0:�Ȃ��@1:����</remarks>
        private Int32 _priceUpdateDiv;

        /// <summary>���i�J�n���t</summary>
        /// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</remarks>
        private DateTime _priceStartDate;

        /// <summary>���i�񋟓��t</summary>
        /// <remarks>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</remarks>
        private DateTime _priceOfferDate;

        /// <summary>�ԗ��֘A�t��GUID</summary>
        /// <remarks>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</remarks>
        private Guid _carRelationGuid;

        /// <summary>�`�[���דo�^����</summary>
        /// <remarks>�`�[�E���ׂ̓o�^���ʂ�ݒ�</remarks>
        private Int32 _slipDtlRegOrder;

        /// <summary>�v��c�敪</summary>
        /// <remarks>0:IOWriteCtrlOptWork�̌v��c�敪�ɏ����@1:�c���@2:�c���Ȃ�</remarks>
        private Int32 _addUpRemDiv;

        /// <summary>�����c������</summary>
        /// <remarks>���̔����c������Z�b�g���ꂽ�l�����Z���Ĕ����c�̌v�Z���s��</remarks>
        private Double _orderRemainAdjustCnt;

        // --- ADD m.suzuki 2010/04/30 ---------->>>>>
        /// <summary>���R�������i�o�^�敪</summary>
        /// <remarks>0:�Ȃ��@1:����</remarks>
        private Int32 _freeSearchPartsEntryDiv;
        /// <summary>�t���^�����X�g</summary>
        /// <remarks>�����R�������i�����o�^�Ŏg�p����</remarks>
        private string[] _fullModelList;
        // --- ADD m.suzuki 2010/04/30 ----------<<<<<

        // --- ADD K2014/06/12 y.wakita ----->>>>>
        /// <summary>�݌ɍX�V�L���敪���t�^�o�ʑΉ�</summary>
        /// <remarks>true:�X�V�Ȃ��@false:�X�V����</remarks>
        private bool _zaiUpdFlg;

        /// <summary>�v��c�敪���t�^�o�ʑΉ�</summary>
        /// <remarks>true:�c���@false:IOWriteCtrlOptWork�̌v��c�敪�ɏ���</remarks>
        private bool _addUpRemFlg;
        // --- ADD K2014/06/12 y.wakita -----<<<<<

        /// public propaty name  :  DtlRelationGuid
        /// <summary>���׊֘A�t��GUID�v���p�e�B</summary>
        /// <value>�`�[���ׂƕR�t����ׂ�GUID�AUI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���׊֘A�t��GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
        }

        /// public propaty name  :  GoodsEntryDiv
        /// <summary>���i�o�^�敪�v���p�e�B</summary>
        /// <value>0:�Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsEntryDiv
        {
            get { return _goodsEntryDiv; }
            set { _goodsEntryDiv = value; }
        }

        /// public propaty name  :  GoodsOfferDate
        /// <summary>���i�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime GoodsOfferDate
        {
            get { return _goodsOfferDate; }
            set { _goodsOfferDate = value; }
        }

        /// public propaty name  :  PriceUpdateDiv
        /// <summary>���i�X�V�敪�v���p�e�B</summary>
        /// <value>0:�Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceUpdateDiv
        {
            get { return _priceUpdateDiv; }
            set { _priceUpdateDiv = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@���i�}�X�^�ɓo�^���鉿�i�J�n���AUI���Őݒ�@��DateTime�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  PriceOfferDate
        /// <summary>���i�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD�@���i�}�X�^�ɓo�^����񋟓��t�AUI���Őݒ�@��DateTime�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }

        /// public propaty name  :  CarRelationGuid
        /// <summary>�ԗ��֘A�t��GUID�v���p�e�B</summary>
        /// <value>�ԗ��Ǘ����Ɠ`�[���ׂ�R�t����GUID�AUI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��֘A�t��GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid CarRelationGuid
        {
            get { return _carRelationGuid; }
            set { _carRelationGuid = value; }
        }

        /// public propaty name  :  SlipDtlRegOrder
        /// <summary>�`�[���דo�^���ʃv���p�e�B</summary>
        /// <value>�`�[�E���ׂ̓o�^���ʂ�ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[���דo�^���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipDtlRegOrder
        {
            get { return _slipDtlRegOrder; }
            set { _slipDtlRegOrder = value; }
        }

        /// public propaty name  :  AddUpRemDiv
        /// <summary>�v��c�敪�v���p�e�B</summary>
        /// <value>0:IOWriteCtrlOptWork�̌v��c�敪�ɏ����@1:�c���@2:�c���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��c�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpRemDiv
        {
            get { return _addUpRemDiv; }
            set { _addUpRemDiv = value; }
        }

        /// public propaty name  :  OrderRemainAdjustCnt
        /// <summary>�����c�������v���p�e�B</summary>
        /// <value>���̔����c������Z�b�g���ꂽ�l�����Z���Ĕ����c�̌v�Z���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����c�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double OrderRemainAdjustCnt
        {
            get { return _orderRemainAdjustCnt; }
            set { _orderRemainAdjustCnt = value; }
        }

        // --- ADD m.suzuki 2010/04/30 ---------->>>>>
        /// public propaty name  :  FreeSearchPartsEntryDiv
        /// <summary>���R�������i�o�^�敪�v���p�e�B</summary>
        /// <value>0:�Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�������i�o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FreeSearchPartsEntryDiv
        {
            get { return _freeSearchPartsEntryDiv; }
            set { _freeSearchPartsEntryDiv = value; }
        }
        /// public propaty name  :  FreeSearchPartsEntryDiv
        /// <summary>�t���^�����X�g�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t���^�����X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] FullModelList
        {
            get { return _fullModelList; }
            set { _fullModelList = value; }
        }
        // --- ADD m.suzuki 2010/04/30 ----------<<<<<

        // --- ADD K2014/06/12 y.wakita ----->>>>>
        /// public propaty name  :  ZaiUpdFlg
        /// <summary>�݌ɍX�V�L���敪�v���p�e�B���t�^�o�ʑΉ�</summary>
        /// <value>true:�X�V�Ȃ��@false:�X�V����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɍX�V�L���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool ZaiUpdFlg
        {
            get { return _zaiUpdFlg; }
            set { _zaiUpdFlg = value; }
        }

        /// public propaty name  :  AddUpRemFlg
        /// <summary>�v��c�敪�v���p�e�B���t�^�o�ʑΉ�</summary>
        /// <value>true:�c���@false:IOWriteCtrlOptWork�̌v��c�敪�ɏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��c�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool AddUpRemFlg
        {
            get { return _addUpRemFlg; }
            set { _addUpRemFlg = value; }
        }
        // --- ADD K2014/06/12 y.wakita -----<<<<<

        /// <summary>
        /// �`�[���גǉ����f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipDetailAddInfoWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SlipDetailAddInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipDetailAddInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipDetailAddInfoWork || graph is ArrayList || graph is SlipDetailAddInfoWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SlipDetailAddInfoWork).FullName));

            if (graph != null && graph is SlipDetailAddInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipDetailAddInfoWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipDetailAddInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipDetailAddInfoWork[])graph).Length;
            }
            else if (graph is SlipDetailAddInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���׊֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //DtlRelationGuid
            //���i�o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsEntryDiv
            //���i�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //GoodsOfferDate
            //���i�X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceUpdateDiv
            //���i�J�n���t
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceStartDate
            //���i�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceOfferDate
            //�ԗ��֘A�t��GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //CarRelationGuid
            //�`�[���דo�^����
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDtlRegOrder
            //�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpRemDiv
            //�����c������
            serInfo.MemberInfo.Add(typeof(Double)); //OrderRemainAdjustCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is SlipDetailAddInfoWork)
            {
                SlipDetailAddInfoWork temp = (SlipDetailAddInfoWork)graph;

                SetSlipDetailAddInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipDetailAddInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipDetailAddInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipDetailAddInfoWork temp in lst)
                {
                    SetSlipDetailAddInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipDetailAddInfoWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  SlipDetailAddInfoWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSlipDetailAddInfoWork(System.IO.BinaryWriter writer, SlipDetailAddInfoWork temp)
        {
            //���׊֘A�t��GUID
            byte[] dtlRelationGuidArray = temp.DtlRelationGuid.ToByteArray();
            writer.Write(dtlRelationGuidArray.Length);
            writer.Write(temp.DtlRelationGuid.ToByteArray());
            //���i�o�^�敪
            writer.Write(temp.GoodsEntryDiv);
            //���i�񋟓��t
            writer.Write(temp.GoodsOfferDate.Ticks);
            //���i�X�V�敪
            writer.Write(temp.PriceUpdateDiv);
            //���i�J�n���t
            writer.Write(temp.PriceStartDate.Ticks);
            //���i�񋟓��t
            writer.Write(temp.PriceOfferDate.Ticks);
            //�ԗ��֘A�t��GUID
            byte[] carRelationGuidArray = temp.CarRelationGuid.ToByteArray();
            writer.Write(carRelationGuidArray.Length);
            writer.Write(temp.CarRelationGuid.ToByteArray());
            //�`�[���דo�^����
            writer.Write(temp.SlipDtlRegOrder);
            //�v��c�敪
            writer.Write(temp.AddUpRemDiv);
            //�����c������
            writer.Write(temp.OrderRemainAdjustCnt);

        }

        /// <summary>
        ///  SlipDetailAddInfoWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SlipDetailAddInfoWork GetSlipDetailAddInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SlipDetailAddInfoWork temp = new SlipDetailAddInfoWork();

            //���׊֘A�t��GUID
            int lenOfDtlRelationGuidArray = reader.ReadInt32();
            byte[] dtlRelationGuidArray = reader.ReadBytes(lenOfDtlRelationGuidArray);
            temp.DtlRelationGuid = new Guid(dtlRelationGuidArray);
            //���i�o�^�敪
            temp.GoodsEntryDiv = reader.ReadInt32();
            //���i�񋟓��t
            temp.GoodsOfferDate = new DateTime(reader.ReadInt64());
            //���i�X�V�敪
            temp.PriceUpdateDiv = reader.ReadInt32();
            //���i�J�n���t
            temp.PriceStartDate = new DateTime(reader.ReadInt64());
            //���i�񋟓��t
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());
            //�ԗ��֘A�t��GUID
            int lenOfCarRelationGuidArray = reader.ReadInt32();
            byte[] carRelationGuidArray = reader.ReadBytes(lenOfCarRelationGuidArray);
            temp.CarRelationGuid = new Guid(carRelationGuidArray);
            //�`�[���דo�^����
            temp.SlipDtlRegOrder = reader.ReadInt32();
            //�v��c�敪
            temp.AddUpRemDiv = reader.ReadInt32();
            //�����c������
            temp.OrderRemainAdjustCnt = reader.ReadDouble();


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
        /// <returns>SlipDetailAddInfoWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipDetailAddInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipDetailAddInfoWork temp = GetSlipDetailAddInfoWork(reader, serInfo);
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
                    retValue = (SlipDetailAddInfoWork[])lst.ToArray(typeof(SlipDetailAddInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}