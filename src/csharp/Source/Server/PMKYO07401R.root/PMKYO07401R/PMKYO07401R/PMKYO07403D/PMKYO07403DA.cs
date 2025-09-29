//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : dingjx
// �C �� ��  2011/11/01  �C�����e : Redmine#26228 ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/24  �C�����e : ���_�Ǘ�DC���O���Ԓǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : 杍^
// �C �� ��  2020/09/25  �C�����e : PMKOBETSU-3877�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ReceiveDataWork
    /// <summary>
    ///                      ��M�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��M�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note : 2012/07/24 �L�w�� </br>
    /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
    /// <br>Update Note      : 2020/09/25 杍^</br>
    /// <br>�Ǘ��ԍ�         : 11600006-00</br>
    /// <br>                 : PMKOBETSU-3877�̑Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCReceiveDataWork
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

        /// <summary>�I�����t����TICKS</summary>
        private Int64 _endDateTimeTicks;

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
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

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        //  ADD dingjx  2011/11/01  ----------------------------->>>>>>
        /// <summary>���</summary>
        /// <remarks>0:�f�[�^�@1:�}�X�^</remarks>
        private Int32 _kind;

        /// <summary>����M���O���o�����敪</summary>
        /// <remarks>0:����,1:�`�[���t</remarks>
        private Int32 _sndLogExtraCondDiv;

        // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
        /// <summary>����M�������O���M�ԍ�</summary>
        private Int32 _sndRcvHisConsNo;

        /// <summary>���M���ƃR�[�h</summary>
        private string _sendDestEpCode = "";

        /// <summary>���M�拒�_�R�[�h</summary>
        private string _sendDestSecCode = "";

        /// <summary>����M���</summary>
        /// <remarks>0:����,1:���s</remarks>
        private Int32 _sndRcvCondition;

        /// <summary>����M�敪</summary>
        /// <remarks >1:��M,2:����M</remarks>
        private Int32 _tempReceiveDiv;

        /// <summary>����M�G���[���e</summary>
        private string _sndRcvErrContents = "";

        /// <summary>����M�t�@�C���h�c</summary>
        private string _sndRcvFileID = "";
        // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<

        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        /// <summary>�󒍃f�[�^��M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _acptAnOdrRecvDiv;

        /// <summary>�ݏo�f�[�^��M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _shipmentRecvDiv;

        /// <summary>���σf�[�^��M�敪</summary>
        /// <remarks>0:���M�Ȃ� 1:���M����</remarks>
        private Int32 _estimateRecvDiv;
        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

        /// <summary>
        /// ���
        /// </summary>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// <summary>
        /// ����M���O���o�����敪
        /// </summary>
        public Int32 SndLogExtraCondDiv
        {
            get { return _sndLogExtraCondDiv; }
            set { _sndLogExtraCondDiv = value; }
        }
        //  ADD dingjx  2011/11/01  -----------------------------<<<<<<

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

        /// public propaty name  :  EndDateTimeTicks
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

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
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
		/// <summary>����v�ۃt���O</summary>
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
		/// <summary>���㖾�חv�ۃt���O</summary>
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
		/// <summary>�󒍃}�X�^�i�ԗ��j�v�ۃt���O</summary>
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
		/// <summary>�󒍃}�X�^�v�ۃt���O</summary>
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
		/// <summary>���㗚��v�ۃt���O</summary>
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
		/// <summary>���㗚�𖾍חv�ۃt���O</summary>
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
		/// <summary>�����v�ۃt���O</summary>
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
		/// <summary>�������חv�ۃt���O</summary>
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
		/// <summary>�d���v�ۃt���O</summary>
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
		/// <summary>�d�����חv�ۃt���O</summary>
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
		/// <summary>�d������v�ۃt���O</summary>
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
		/// <summary>�d�����𖾍חv�ۃt���O</summary>
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
		/// <summary>�x���`�[�v�ۃt���O</summary>
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
		/// <summary>�x�����חv�ۃt���O</summary>
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

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
        /// public propaty name  :  SndRcvHisConsNo
        /// <summary>����M�������O���M�ԍ�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�������O���M�ԍ��p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndRcvHisConsNo
        {
            get { return _sndRcvHisConsNo; }
            set { _sndRcvHisConsNo = value; }
        }

        /// public propaty name  :  SendDestEpCode
        /// <summary>���M���ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M���ƃR�[�h�p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendDestEpCode
        {
            get { return _sendDestEpCode; }
            set { _sendDestEpCode = value; }
        }

        /// public propaty name  :  SendDestSecCode
        /// <summary>���M�拒�_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�拒�_�R�[�h�p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendDestSecCode
        {
            get { return _sendDestSecCode; }
            set { _sendDestSecCode = value; }
        }

        /// public propaty name  :  SndRcvCondition
        /// <summary>����M���</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M��ԃp�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SndRcvCondition
        {
            get { return _sndRcvCondition; }
            set { _sndRcvCondition = value; }
        }

        /// public propaty name  :  TempReceiveDiv
        /// <summary>����M�敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�敪�p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TempReceiveDiv
        {
            get { return _tempReceiveDiv; }
            set { _tempReceiveDiv = value; }
        }

        /// public propaty name  :  SndRcvErrContents
        /// <summary>����M�G���[���e</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�G���[���e�p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SndRcvErrContents
        {
            get { return _sndRcvErrContents; }
            set { _sndRcvErrContents = value; }
        }

        /// public propaty name  :  SndRcvFileID
        /// <summary>����M�t�@�C���h�c</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�t�@�C���h�c�p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SndRcvFileID
        {
            get { return _sndRcvFileID; }
            set { _sndRcvFileID = value; }
        }
        // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<

        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        /// public propaty name  :  AcptAnOdrRecvDiv
        /// <summary>�󒍃f�[�^��M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃f�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrRecvDiv
        {
            get { return _acptAnOdrRecvDiv; }
            set { _acptAnOdrRecvDiv = value; }
        }

        /// public propaty name  :  ShipmentRecvDiv
        /// <summary>�ݏo�f�[�^��M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�f�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentRecvDiv
        {
            get { return _shipmentRecvDiv; }
            set { _shipmentRecvDiv = value; }
        }

        /// public propaty name  :  EstimateRecvDiv
        /// <summary>���σf�[�^��M�敪�v���p�e�B</summary>
        /// <value>0:���M�Ȃ� 1:���M����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���σf�[�^��M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EstimateRecvDiv
        {
            get { return _estimateRecvDiv; }
            set { _estimateRecvDiv = value; }
        }
        // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

        /// <summary>
        /// ��M�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ReceiveDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ReceiveDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DCReceiveDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ReceiveDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ReceiveDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class DCReceiveDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ReceiveDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note : 2012/07/24 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ReceiveDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCReceiveDataWork || graph is ArrayList || graph is DCReceiveDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(DCReceiveDataWork).FullName));

            if (graph != null && graph is DCReceiveDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DCReceiveDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCReceiveDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCReceiveDataWork[])graph).Length;
            }
            else if (graph is DCReceiveDataWork)
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
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
			//���_�R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //PmSectionCode
			//����v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesSlipFlg
			//���㖾�חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesDetailFlg
			//�󒍃}�X�^�i�ԗ��j�v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoAcceptOdrCarFlg
			//�󒍃}�X�^�v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoAcceptOdrFlg
			//���㗚��v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesHistoryFlg
			//���㗚�𖾍חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoSalesHistDtlFlg
			//�����v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoDepsitMainFlg
			//�������חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoDepsitDtlFlg
			//�d���v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockSlipFlg
			//�d�����חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockDetailFlg
			//�d������v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockSlipHistFlg
			//�d�����𖾍חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoStockSlHistDtlFlg
			//�x���`�[�v�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoPaymentSlpFlg
			//�x�����חv�ۃt���O
			serInfo.MemberInfo.Add(typeof(Boolean)); // DoPaymentDtlFlg		
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            //����M�������O���M�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32));  // SndRcvHisConsNo
            //���M���ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string));  // SendDestEpCode
            //���M�拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string));  // SendDestSecCode
            //����M���
            serInfo.MemberInfo.Add(typeof(Int32));  // SndRcvCondition
            //����M�敪
            serInfo.MemberInfo.Add(typeof(Int32));  // TempReceiveDiv
            //����M�G���[���e
            serInfo.MemberInfo.Add(typeof(string)); // SndRcvErrContents
            //����M�t�@�C���h�c
            serInfo.MemberInfo.Add(typeof(string)); // SndRcvFileID
            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<

            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^��M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrRecvDiv
            //�ݏo�f�[�^��M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentRecvDiv
            //���σf�[�^��M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimateRecvDiv
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is DCReceiveDataWork)
            {
                DCReceiveDataWork temp = (DCReceiveDataWork)graph;

                SetReceiveDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCReceiveDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCReceiveDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCReceiveDataWork temp in lst)
                {
                    SetReceiveDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ReceiveDataWork�����o��(public�v���p�e�B��)
        /// <br>Update Note : 2012/07/24 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// </summary>
        //private const int currentMemberCount = 18;
        //private const int currentMemberCount = 20;    // DEL 2012/07/24 �L�w��
        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
        //private const int currentMemberCount = 27;  // ADD 2012/07/24 �L�w��
        private const int currentMemberCount = 30;
        // --- UPD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
        /// <summary>
        ///  ReceiveDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ReceiveDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note : 2012/07/24 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// </remarks>
        private void SetReceiveDataWork(System.IO.BinaryWriter writer, DCReceiveDataWork temp)
        {
            //PM��ƃR�[�h
            writer.Write(temp.PmEnterpriseCode);
            //�J�n���t����
            writer.Write(temp.StartDateTime);
            //�I�����t����
            writer.Write(temp.EndDateTime);
            //�V���N���s���t����
            writer.Write(temp.SyncExecDate);
            //�I�����t����
            writer.Write(temp.EndDateTimeTicks);
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
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
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            //����M�������O���M�ԍ�
            writer.Write(temp.SndRcvHisConsNo);
            //���M���ƃR�[�h
            writer.Write(temp.SendDestEpCode);
            //���M�拒�_�R�[�h
            writer.Write(temp.SendDestSecCode);
            //����M���
            writer.Write(temp.SndRcvCondition);
            //����M�敪
            writer.Write(temp.TempReceiveDiv);
            //����M�G���[���e
            writer.Write(temp.SndRcvErrContents);
            //����M�t�@�C���h�c
            writer.Write(temp.SndRcvFileID);
            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^��M�敪
            writer.Write(temp.AcptAnOdrRecvDiv);
            //�ݏo�f�[�^��M�敪
            writer.Write(temp.ShipmentRecvDiv);
            //���σf�[�^��M�敪
            writer.Write(temp.EstimateRecvDiv);
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<
        }

        /// <summary>
        ///  ReceiveDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ReceiveDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ReceiveDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note : 2012/07/24 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#31026 ���_�Ǘ��c�b���O���Ԓǉ�����</br>
        /// </remarks>
        private DCReceiveDataWork GetReceiveDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            DCReceiveDataWork temp = new DCReceiveDataWork();

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
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
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
			// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026-------->>>>>
            //����M�������O���M�ԍ�
            temp.SndRcvHisConsNo = reader.ReadInt32();
            //���M���ƃR�[�h
            temp.SendDestEpCode = reader.ReadString();
            //���M�拒�_�R�[�h
            temp.SendDestSecCode = reader.ReadString();
            //����M���
            temp.SndRcvCondition = reader.ReadInt32();
            //����M�敪
            temp.TempReceiveDiv = reader.ReadInt32();
            //����M�G���[���e
            temp.SndRcvErrContents = reader.ReadString();
            //����M�t�@�C���h�c
            temp.SndRcvFileID = reader.ReadString();
            // ------------ADD �L�w�� 2012/07/24 FOR Redmine#31026---------<<<<<

            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------>>>>>
            //�󒍃f�[�^��M�敪
            temp.AcptAnOdrRecvDiv = reader.ReadInt32();
            //�ݏo�f�[�^��M�敪
            temp.ShipmentRecvDiv = reader.ReadInt32();
            //���σf�[�^��M�敪
            temp.EstimateRecvDiv = reader.ReadInt32();
            // --- ADD 2020/09/25 杍^ PMKOBETSU-3877�̑Ή� ------<<<<<

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
        /// <returns>ReceiveDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ReceiveDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCReceiveDataWork temp = GetReceiveDataWork(reader, serInfo);
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
                    retValue = (DCReceiveDataWork[])lst.ToArray(typeof(DCReceiveDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
