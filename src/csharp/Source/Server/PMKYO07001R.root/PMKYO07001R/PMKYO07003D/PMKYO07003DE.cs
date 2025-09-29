//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���o�E�X�VDB����N���X
//                  :   PMKYO07003D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   ����
// Date             :   2011.07.28
//----------------------------------------------------------------------
// Update Note      :�@ Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
// Programmer       :   ���|��
// Date             :   2011/11/01
//----------------------------------------------------------------------
// Update Note      :�@ Redmine#8293�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
// Programmer       :   杍^
// Date             :   2011/11/30
//----------------------------------------------------------------------
// Update Note      :�@ �Ǘ��ԍ�:10900690-00 2013/3/13�z�M���ً̋}�Ή�
//                      Redmine#34588 ���_�Ǘ����ǁ^���M�m�F��ʂ̒ǉ��d�l�̕ύX�Ή�
// Programmer       :   zhlj
// Date             :   2013/02/07
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : 杍^
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   APSendDataWork
	/// <summary>
	///                      ���M�f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���M�f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2020/09/25 杍^</br>
    /// <br>�Ǘ��ԍ�         : 11600006-00</br>
    /// <br>                 : PMKOBETSU-3877�̑Ή�</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class APSendDataWork 
	{
		/// <summary>PM��ƃR�[�h</summary>
		/// <remarks>���i���̊�ƃR�[�h</remarks>
		private string _pmEnterpriseCode = "";

		/// <summary>�J�n���t����</summary>
		private Int64 _startDateTime;

		/// <summary>�I�����t����</summary>
		private Int64 _endDateTime;

        /// <summary>�V���N���s���t����</summary>
        private Int64 _syncExecDate;

        /// <summary>�I�����t����</summary>
        private Int64 _endDateTimeTicks;

		/// <summary>���_�R�[�h</summary>
		private string _pmSectionCode = "";

		/// <summary>����v�ۃt���O</summary>
		private Boolean _doSalesSlipFlg;

		/// <summary>���㖾�חv�ۃt���O</summary>
		private Boolean _doSalesDetailFlg;

		/// <summary>�󒍃}�X�^�i�ԗ��j�v�ۃt���O</summary>
		private Boolean _doAcceptOdrCarFlg;

		/// <summary>�󒍃}�X�^�v�ۃt���O</summary>
		private Boolean _doAcceptOdrFlg;

		/// <summary>���㗚��v�ۃt���O</summary>
		private Boolean _doSalesHistoryFlg;

		/// <summary>���㗚�𖾍חv�ۃt���O</summary>
		private Boolean _doSalesHistDtlFlg;

		/// <summary>�����v�ۃt���O</summary>
		private Boolean _doDepsitMainFlg;

		/// <summary>�������חv�ۃt���O</summary>
		private Boolean _doDepsitDtlFlg;

		/// <summary>�d���v�ۃt���O</summary>
		private Boolean _doStockSlipFlg;

		/// <summary>�d�����חv�ۃt���O</summary>
		private Boolean _doStockDetailFlg;

		/// <summary>�d������v�ۃt���O</summary>
		private Boolean _doStockSlipHistFlg;

		/// <summary>�d�����𖾍חv�ۃt���O</summary>
		private Boolean _doStockSlHistDtlFlg;

		/// <summary>�x���`�[�v�ۃt���O</summary>
		private Boolean _doPaymentSlpFlg;

		/// <summary>�x�����חv�ۃt���O</summary>
		private Boolean _doPaymentDtlFlg;

        // ----- ADD 2011/11/01 xupz---------->>>>>
        /// <summary>�f�[�^���M���o�����敪(0:����;1:�`�[���t)</summary>
        private Int32 _sndMesExtraCondDiv;
        // ----- ADD 2011/11/01 xupz----------<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// <summary>���M�ԍ������敪(0:��������;1:�������Ȃ�)</summary>
        private Int32 _sndNoCreateDiv;
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        /// <summary>�󒍃f�[�^���M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _acptAnOdrSendDiv;

        /// <summary>�ݏo�f�[�^���M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _shipmentSendDiv;

        /// <summary>���σf�[�^���M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _estimateSendDiv;
        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

		/// public propaty name  :  PmEnterpriseCode
		/// <summary>PM��ƃR�[�h�v���p�e�B</summary>
		/// <value>���i���̊�ƃR�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmEnterpriseCode
		{
			get { return _pmEnterpriseCode; }
			set { _pmEnterpriseCode = value; }
		}

		/// public propaty name  :  StartDateTime
		/// <summary>�J�n���t���ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���t���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StartDateTime
		{
			get { return _startDateTime; }
			set { _startDateTime = value; }
		}

		/// public propaty name  :  EndDateTime
		/// <summary>�I�����t���ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����t���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 EndDateTime
		{
			get { return _endDateTime; }
			set { _endDateTime = value; }
		}

        /// public propaty name  :  SyncExecDate
        /// <summary>�V���N���s���t���ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
        }

        /// public propaty name  :  EndDateTime
        /// <summary>�I�����t���ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����t���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 EndDateTimeTicks
        {
            get { return _endDateTimeTicks; }
            set { _endDateTimeTicks = value; }
        }

		/// public propaty name  :  PmSectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmSectionCode
		{
			get { return _pmSectionCode; }
			set { _pmSectionCode = value; }
		}

		/// public propaty name  :  DoSalesSlipFlg
		/// <summary>����v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoSalesSlipFlg
		{
			get { return _doSalesSlipFlg; }
			set { _doSalesSlipFlg = value; }
		}

		/// public propaty name  :  DoSalesDetailFlg
		/// <summary>���㖾�חv�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㖾�חv�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoSalesDetailFlg
		{
			get { return _doSalesDetailFlg; }
			set { _doSalesDetailFlg = value; }
		}

		/// public propaty name  :  DoAcceptOdrCarFlg
		/// <summary>�󒍃}�X�^�i�ԗ��j�v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃}�X�^�i�ԗ��j�v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoAcceptOdrCarFlg
		{
			get { return _doAcceptOdrCarFlg; }
			set { _doAcceptOdrCarFlg = value; }
		}

		/// public propaty name  :  DoAcceptOdrFlg
		/// <summary>�󒍃}�X�^�v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃}�X�^�v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoAcceptOdrFlg
		{
			get { return _doAcceptOdrFlg; }
			set { _doAcceptOdrFlg = value; }
		}

		/// public propaty name  :  DoSalesHistoryFlg
		/// <summary>���㗚��v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㗚��v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoSalesHistoryFlg
		{
			get { return _doSalesHistoryFlg; }
			set { _doSalesHistoryFlg = value; }
		}

		/// public propaty name  :  DoSalesHistDtlFlg
		/// <summary>���㗚�𖾍חv�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㗚�𖾍חv�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoSalesHistDtlFlg
		{
			get { return _doSalesHistDtlFlg; }
			set { _doSalesHistDtlFlg = value; }
		}

		/// public propaty name  :  DoDepsitMainFlg
		/// <summary>�����v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoDepsitMainFlg
		{
			get { return _doDepsitMainFlg; }
			set { _doDepsitMainFlg = value; }
		}

		/// public propaty name  :  DoDepsitDtlFlg
		/// <summary>�������חv�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������חv�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoDepsitDtlFlg
		{
			get { return _doDepsitDtlFlg; }
			set { _doDepsitDtlFlg = value; }
		}

		/// public propaty name  :  DoStockSlipFlg
		/// <summary>�d���v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoStockSlipFlg
		{
			get { return _doStockSlipFlg; }
			set { _doStockSlipFlg = value; }
		}

		/// public propaty name  :  DoStockDetailFlg
		/// <summary>�d�����חv�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����חv�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoStockDetailFlg
		{
			get { return _doStockDetailFlg; }
			set { _doStockDetailFlg = value; }
		}

		/// public propaty name  :  DoStockSlipHistFlg
		/// <summary>�d������v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d������v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoStockSlipHistFlg
		{
			get { return _doStockSlipHistFlg; }
			set { _doStockSlipHistFlg = value; }
		}

		/// public propaty name  :  DoStockSlHistDtlFlg
		/// <summary>�d�����𖾍חv�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�����𖾍חv�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoStockSlHistDtlFlg
		{
			get { return _doStockSlHistDtlFlg; }
			set { _doStockSlHistDtlFlg = value; }
		}

		/// public propaty name  :  DoPaymentSlpFlg
		/// <summary>�x���`�[�v�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���`�[�v�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoPaymentSlpFlg
		{
			get { return _doPaymentSlpFlg; }
			set { _doPaymentSlpFlg = value; }
		}

		/// public propaty name  :  DoPaymentDtlFlg
		/// <summary>�x�����חv�ۃt���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x�����חv�ۃt���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean DoPaymentDtlFlg
		{
			get { return _doPaymentDtlFlg; }
			set { _doPaymentDtlFlg = value; }
		}

        // ----- ADD 2011/11/01 xupz---------->>>>>
        /// public propaty name  :  SndMesExtraCondDiv;
        /// <summary>�f�[�^���M���o�����敪</summary>
        /// <value>0:����;�@1:�`�[���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M���o�����敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndMesExtraCondDiv
        {
            get { return _sndMesExtraCondDiv; }
            set { _sndMesExtraCondDiv = value; }
        }
        // ----- ADD 2011/11/01 xupz----------<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        /// public propaty name  :  SndNoCreateDiv
        /// <summary>���M�ԍ������敪</summary>
        /// <value>0:��������;1:�������Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���M���o�����敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndNoCreateDiv
        {
            get { return _sndNoCreateDiv; }
            set { _sndNoCreateDiv = value; }
        }
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        /// public propaty name  :  AcptAnOdrSendDiv
        /// <summary>�󒍃f�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrSendDiv
        {
            get { return _acptAnOdrSendDiv; }
            set { _acptAnOdrSendDiv = value; }
        }

        /// public propaty name  :  ShipmentSendDiv
        /// <summary>�ݏo�f�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�f�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentSendDiv
        {
            get { return _shipmentSendDiv; }
            set { _shipmentSendDiv = value; }
        }

        /// public propaty name  :  EstimateSendDiv
        /// <summary>���σf�[�^���M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateSendDiv
        {
            get { return _estimateSendDiv; }
            set { _estimateSendDiv = value; }
        }
        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

		/// <summary>
		/// ���M�f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>APSendDataWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   APSendDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public APSendDataWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>APSendDataWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   APSendDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class APSendDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   APSendDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  APSendDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is APSendDataWork || graph is ArrayList || graph is APSendDataWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(APSendDataWork).FullName));

			if (graph != null && graph is APSendDataWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.APSendDataWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is APSendDataWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((APSendDataWork[])graph).Length;
			}
			else if (graph is APSendDataWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//PM��ƃR�[�h
			serInfo.MemberInfo.Add(typeof(string)); //PmEnterpriseCode
			//�J�n���t����
			serInfo.MemberInfo.Add(typeof(Int64)); //StartDateTime
			//�I�����t����
			serInfo.MemberInfo.Add(typeof(Int64)); //EndDateTime
            //�V���N���s���t����
            serInfo.MemberInfo.Add(typeof(Int64)); //SyncExecDate
            //�I�����t����
            serInfo.MemberInfo.Add(typeof(Int64)); //EndDateTimeTicks
			//���_�R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //PmSectionCode
			//����v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesSlipFlg
			//���㖾�חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesDetailFlg
			//�󒍃}�X�^�i�ԗ��j�v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoAcceptOdrCarFlg
			//�󒍃}�X�^�v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoAcceptOdrFlg
			//���㗚��v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesHistoryFlg
			//���㗚�𖾍חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoSalesHistDtlFlg
			//�����v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoDepsitMainFlg
			//�������חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoDepsitDtlFlg
			//�d���v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockSlipFlg
			//�d�����חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockDetailFlg
			//�d������v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockSlipHistFlg
			//�d�����𖾍חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoStockSlHistDtlFlg
			//�x���`�[�v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoPaymentSlpFlg
			//�x�����חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); //DoPaymentDtlFlg
            // ----- ADD 2011/11/01 xupz---------->>>>>
            //�f�[�^���M���o�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SndMesExtraCondDiv
            // ----- ADD 2011/11/01 xupz----------<<<<<
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
            //���M�ԍ������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SndNoCreateDiv
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^���M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrSendDiv
            //�ݏo�f�[�^���M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentSendDiv
            //���σf�[�^���M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateSendDiv
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

			serInfo.Serialize(writer, serInfo);
			if (graph is APSendDataWork)
			{
				APSendDataWork temp = (APSendDataWork)graph;

				SetAPSendDataWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is APSendDataWork[])
				{
					lst = new ArrayList();
					lst.AddRange((APSendDataWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (APSendDataWork temp in lst)
				{
					SetAPSendDataWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// APSendDataWork�����o��(public�v���p�e�B��)
		/// </summary>
		//private const int currentMemberCount = 18;
        //private const int currentMemberCount = 19;
        //private const int currentMemberCount = 20;// DEL zhlj 2013/02/07 For Redmine#34588
        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        //private const int currentMemberCount = 21;// ADD zhlj 2013/02/07 For Redmine#34588
        private const int currentMemberCount = 24;
        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

		/// <summary>
		///  APSendDataWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   APSendDataWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetAPSendDataWork(System.IO.BinaryWriter writer, APSendDataWork temp)
		{
			//PM��ƃR�[�h
			writer.Write(temp.PmEnterpriseCode);
			//�J�n���t����
			writer.Write(temp.StartDateTime);
			//�I�����t����
			writer.Write(temp.EndDateTime);
            //�I�����t����
            writer.Write(temp.EndDateTimeTicks);
            //�V���N���s���t����
            writer.Write(temp.SyncExecDate);
			//���_�R�[�h
			writer.Write(temp.PmSectionCode);
			//����v�ۃt���O
			writer.Write(temp.DoSalesSlipFlg);
			//���㖾�חv�ۃt���O
			writer.Write(temp.DoSalesDetailFlg);
			//�󒍃}�X�^�i�ԗ��j�v�ۃt���O
			writer.Write(temp.DoAcceptOdrCarFlg);
			//�󒍃}�X�^�v�ۃt���O
			writer.Write(temp.DoAcceptOdrFlg);
			//���㗚��v�ۃt���O
			writer.Write(temp.DoSalesHistoryFlg);
			//���㗚�𖾍חv�ۃt���O
			writer.Write(temp.DoSalesHistDtlFlg);
			//�����v�ۃt���O
			writer.Write(temp.DoDepsitMainFlg);
			//�������חv�ۃt���O
			writer.Write(temp.DoDepsitDtlFlg);
			//�d���v�ۃt���O
			writer.Write(temp.DoStockSlipFlg);
			//�d�����חv�ۃt���O
			writer.Write(temp.DoStockDetailFlg);
			//�d������v�ۃt���O
			writer.Write(temp.DoStockSlipHistFlg);
			//�d�����𖾍חv�ۃt���O
			writer.Write(temp.DoStockSlHistDtlFlg);
			//�x���`�[�v�ۃt���O
			writer.Write(temp.DoPaymentSlpFlg);
			//�x�����חv�ۃt���O
			writer.Write(temp.DoPaymentDtlFlg);
            // ----- ADD 2011/11/01 xupz---------->>>>>
            //�f�[�^���M���o�����敪
            writer.Write(temp.SndMesExtraCondDiv);
            // ----- ADD 2011/11/01 xupz----------<<<<<
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
            //���M�ԍ������敪
            writer.Write(temp.SndNoCreateDiv);
            // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^���M�敪
            writer.Write(temp.AcptAnOdrSendDiv);
            //�ݏo�f�[�^���M�敪
            writer.Write(temp.ShipmentSendDiv);
            //���σf�[�^���M�敪
            writer.Write(temp.EstimateSendDiv);
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

		}

		/// <summary>
		///  APSendDataWork�C���X�^���X�擾
		/// </summary>
		/// <returns>APSendDataWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   APSendDataWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private APSendDataWork GetAPSendDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
	{
		// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		// serInfo.MemberInfo.Count < currentMemberCount
		// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		APSendDataWork temp = new APSendDataWork();

		//PM��ƃR�[�h
		temp.PmEnterpriseCode = reader.ReadString();
		//�J�n���t����
		temp.StartDateTime = reader.ReadInt64();
		//�I�����t����
		temp.EndDateTime = reader.ReadInt64();
        //�V���N���s���t����
        temp.SyncExecDate = reader.ReadInt64();
        //�I�����t����
        temp.EndDateTimeTicks = reader.ReadInt64();
		//���_�R�[�h
		temp.PmSectionCode = reader.ReadString();
		//����v�ۃt���O
		temp.DoSalesSlipFlg = reader.ReadBoolean();
		//���㖾�חv�ۃt���O
		temp.DoSalesDetailFlg = reader.ReadBoolean();
		//�󒍃}�X�^�i�ԗ��j�v�ۃt���O
		temp.DoAcceptOdrCarFlg = reader.ReadBoolean();
		//�󒍃}�X�^�v�ۃt���O
		temp.DoAcceptOdrFlg = reader.ReadBoolean();
		//���㗚��v�ۃt���O
		temp.DoSalesHistoryFlg = reader.ReadBoolean();
		//���㗚�𖾍חv�ۃt���O
		temp.DoSalesHistDtlFlg = reader.ReadBoolean();
		//�����v�ۃt���O
		temp.DoDepsitMainFlg = reader.ReadBoolean();
		//�������חv�ۃt���O
		temp.DoDepsitDtlFlg = reader.ReadBoolean();
		//�d���v�ۃt���O
		temp.DoStockSlipFlg = reader.ReadBoolean();
		//�d�����חv�ۃt���O
		temp.DoStockDetailFlg = reader.ReadBoolean();
		//�d������v�ۃt���O
		temp.DoStockSlipHistFlg = reader.ReadBoolean();
		//�d�����𖾍חv�ۃt���O
		temp.DoStockSlHistDtlFlg = reader.ReadBoolean();
		//�x���`�[�v�ۃt���O
		temp.DoPaymentSlpFlg = reader.ReadBoolean();
		//�x�����חv�ۃt���O
		temp.DoPaymentDtlFlg = reader.ReadBoolean();
        // ----- ADD 2011/11/01 xupz---------->>>>>
        //�f�[�^���M���o�����敪
        temp.SndMesExtraCondDiv = reader.ReadInt32();
        // ----- ADD 2011/11/01 xupz----------<<<<<
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        //���M�ԍ������敪
        temp.SndNoCreateDiv = reader.ReadInt32();
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        //�󒍃f�[�^���M�敪
        temp.AcptAnOdrSendDiv = reader.ReadInt32();
        //�ݏo�f�[�^���M�敪
        temp.ShipmentSendDiv = reader.ReadInt32();
        //���σf�[�^���M�敪
        temp.EstimateSendDiv = reader.ReadInt32();
        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
			
		//�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			//�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			//�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			//�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
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
		/// <returns>APSendDataWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   APSendDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				APSendDataWork temp = GetAPSendDataWork(reader, serInfo);
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
					retValue = (APSendDataWork[])lst.ToArray(typeof(APSendDataWork));
					break;
			}
			return retValue;
		}

		#endregion
	}


}

