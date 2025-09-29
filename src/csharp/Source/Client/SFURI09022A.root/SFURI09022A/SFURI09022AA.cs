using System;
using System.Collections;
// 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
using System.Collections.Generic;
using System.Text;
// 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;     // 2006.09.05 TAKAHASHI ADD
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
// 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �`�[����ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`�[����ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 23006  ���� ���q</br>
	/// <br>Date       : 2005.08.31</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 ���� ���q</br>
	/// <br>				�E�d�l�ύX�̂��߁A���ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.14  23006 ���� ���q</br>
	/// <br>				�E�d�l�ύX�̂��߁A���ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.15  23006 ���� ���q</br>
	/// <br>				�E�d�l�ύX�̂��߁A���ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.16  23006 ���� ���q</br>
	/// <br>				�E�d�l�ύX�̂��߁A���ڒǉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.25  23006 ���� ���q</br>
	/// <br>				�E����I�t���C���Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.05  23006 ���� ���q</br>
	/// <br>				�E�e�}�X�^���f�����Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.24  22024 ���� �_�u</br>
	/// <br>				�E�t�@�C�����C�A�E�g�ύX�ɔ������ڒǉ�</br>
	/// <br>Update Note : 2006.01.30  23002 ���@�k��</br>
	/// <br>				�E�t�@�C�����C�A�E�g�ύX�ɔ������ڒǉ�</br>
	/// <br>Update Note : 2006.03.14  23010 �����@�m</br>
	/// <br>				�E�t�@�C�����C�A�E�g�ύX�ɔ������ڒǉ�</br>
    /// <br></br>
    /// <br>Update Note : 2006.04.25  22024 ���� �_�u</br>
    /// <br>				�E�ύX��񃍁[�J���ۑ��Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2006.06.21  22024 ���� �_�u</br>
	/// <br>				�E�����I�v�V�����`�F�b�N������ǉ�</br>
	/// <br></br>
    /// <br>Update Note : 2006.09.13  23006 ���� ���q</br>
    /// <br>			   �EXML���[�J���ۑ��Ή�</br>
	/// <br>Update Note : 2007.12.17  30167 ���@�O�M</br>
	/// <br>               �EDC.NS�Ή��i�t�@�C�����C�A�E�g�ύX�E�K�C�h�ǉ��j</br>
    /// <br>Update Note : 2008.02.05  96012�@���F �]</br>
    /// <br>               �E���[�J���c�a�Q�ƑΉ�</br>
    /// <br>Update Note : 2009.07.13 20056 ���n ��� LoginInfoAcquisition.OnlineFlag���Q�Ƃ��Đ���ؑւ��s��Ȃ�(���Online)</br>
    /// <br>Update Note : 2009/12/31  ���M</br>
    /// <br>              �E PM.NS-5-A�EPM.NS�ێ�˗��C</br>
    /// <br>              �E �`�[���l�����A�`�[���l�Q�����A�`�[���l�R������ǉ��Ή�</br>
    /// <br>Update Note : 2010/08/06  caowj</br>
    /// <br>              �E PM.NS1012</br>
    /// <br>              �E �`�[�������ݐݒ�Ή�</br>
    /// <br>Update Note : 2011/02/16  ���N�n��</br>
    /// <br>             �E���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
    /// <br>Update Note : 2011/07/19  chenyd</br>
    /// <br>             �E�񓚋敪�ǉ��̑Ή�</br>
    /// </remarks>
	public class SlipPrtSetAcs : IGeneralGuideData
	{
		#region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.08.30</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		private ISlipPrtSetDB _iSlipPrtSetDB = null;

        // --ADD 2010/08/06--------------------------------------------------------------->>>>>
        private ICustSlipMngDB _iCustSlipMngDB = null;
        // --ADD 2010/08/06---------------------------------------------------------------<<<<<

		// �v�����^���擾�p
		private PrtManage prtManage;
		private PrtManageAcs prtManageAcs;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.26 TAKAHASHI ADD START
		// Static�i�[�pHashTable
		private static Hashtable _static_SlipPrtSetTable = null;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.26 TAKAHASHI ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
        // �I�t���C���f�[�^�i�[��p�X
        private string _offlineDataDirPath = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
        private SlipPrtSetLcDB _slipPrtSetLcDB = null;
        private static bool _isLocalDBRead = false;
        /// <summary>
        /// ���[�J���c�aRead���[�h
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
        #endregion

		//----- h.ueno add---------- start 2007.12.17
		#region Public Members
		// �K�C�h�ݒ�t�@�C����
		private const string GUIDE_XML_FILENAME = "SLIPPRTSETGUIDEPARENT.XML";   // XML�t�@�C����
		
		// �K�C�h�p�����[�^
		private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";       // ��ƃR�[�h
		
		// �K�C�h���ڃ^�C�v
		private const string GUIDE_TYPE_STR = "System.String";              // String�^

		// �K�C�h���ږ�
		private const string GUIDE_DATAINPUTSYSTEM_TITLE		= "DataInputSystem";		// �f�[�^���̓V�X�e��
		private const string GUIDE_DATAINPUTSYSTEMNAME_TITLE	= "DataInputSystemName";	// �f�[�^���̓V�X�e����
		private const string GUIDE_SLIPPRTKIND_TITLE			= "SlipPrtKind";			// �`�[������
		private const string GUIDE_SLIPPRTKINDNAME_TITLE		= "SlipPrtKindName";		// �`�[�����ʖ�
		private const string GUIDE_SLIPPRTSETPAPERID_TITLE		= "SlipPrtSetPaperId";		// �`�[����ݒ�p���[ID
		private const string GUIDE_SLIPCOMMENT_TITLE			= "SlipComment";			// �`�[�R�����g
		
		#endregion
		//----- h.ueno add---------- end   2007.12.17

////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//		#region -- �w�l�k�t�@�C���� --
//		/*----------------------------------------------------------------------------------*/
//		/// <summary>
//		/// �w�l�k�t�@�C����
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : </br>
//		/// <br>Programmer : 23006  ���� ���q</br>
//		/// <br>Date       : 2005.08.30</br>
//		/// </remarks>
//		private string _fileNamePrtInfoSet;
//		#endregion
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////

		#region -- �R���X�g���N�^ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		static SlipPrtSetAcs()
		{
			// Static�i�[�pHashTable
			_static_SlipPrtSetTable = new Hashtable();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.08.30</br>
		/// <br></br>
		/// <br>Note       : �I�t���C���Ή�</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// <br>UpdateNote : 2010.08.06 caowj</br>
        /// <br>           : PM.NS1012�Ή�</br>
        /// </remarks>
        public SlipPrtSetAcs()
        {
////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//			// �w�l�k�t�@�C������ݒ�
//			this._fileNamePrtInfoSet = "PrtInfoSet.xml";
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////

            // �v�����^���擾�p
            prtManage = new PrtManage();
            prtManageAcs = new PrtManageAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            // �I�t���C���f�[�^�i�[��p�X
            this._offlineDataDirPath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�����C���̏ꍇ
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iSlipPrtSetDB = (ISlipPrtSetDB)MediationSlipPrtSetDB.GetSlipPrtSetDB();
            //    }
            //    catch (Exception)
            //    {
            //        // �I�t���C������null���Z�b�g
            //        this._iSlipPrtSetDB = null;
            //    }
            //}
            //else
            //// �I�t���C���̏ꍇ
            //{
            //    // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            //    OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            //    // HashTable��Key�ݒ�
            //    string[] keyList = new string[1];
            //    keyList[0] = LoginInfoAcquisition.EnterpriseCode;

            //    // ���[�J���t�@�C���Ǎ��ݏ���
            //    //object wkObj = offlineDataSerializer.DeSerialize("SlipPrtSetAcs", keyList);                             // 2006.09.13 TAKAHASHI DELETE
            //    object wkObj = offlineDataSerializer.DeSerialize("SlipPrtSetAcs", keyList, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD

            //    ArrayList wkList = wkObj as ArrayList;

            //    // �`�[����ݒ胏�[�N�N���X�iArrayList�j��UI�N���X�iStatic�j�ϊ�����
            //    CopyToSlipPrtSetFromSlipPrtSetWork(wkList);
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSlipPrtSetDB = (ISlipPrtSetDB)MediationSlipPrtSetDB.GetSlipPrtSetDB();
                // --ADD 2010/08/06--------------------------------------------------------------->>>>>
                this._iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();
                // --ADD 2010/08/06---------------------------------------------------------------<<<<<
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSlipPrtSetDB = null;
                // --ADD 2010/08/06--------------------------------------------------------------->>>>>
                this._iCustSlipMngDB = null;
                // --ADD 2010/08/06---------------------------------------------------------------<<<<<
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._slipPrtSetLcDB = new SlipPrtSetLcDB();
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
        }
		#endregion

		#region -- �I�����C�����[�h �񋓌^ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �I�����C�����[�h�̗񋓌^�ł��B
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.08.30</br>
		/// </remarks>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}
		#endregion

		#region -- �I�����C�����[�h�擾���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.30</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSlipPrtSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}
		#endregion

		#region -- �ǂݍ��ݏ��� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>
		/// <param name="slipPrtKind">�`�[������</param>
		/// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID</param>
		/// <returns>�`�[����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.30</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public int ReadSlipPrtSet(out SlipPrtSet slipPrtSet, string enterpriseCode, int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId)
		{			
			try
			{
				slipPrtSet = null;
				SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
				
				int status = 0;

				slipPrtSetWork.EnterpriseCode  = enterpriseCode;
				slipPrtSetWork.DataInputSystem = dataInputSystem;

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.14 TAKAHASHI ADD START
				slipPrtSetWork.SlipPrtKind = slipPrtKind;
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.14 TAKAHASHI ADD END

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
				slipPrtSetWork.SlipPrtSetPaperId = slipPrtSetPaperId;
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// �I�����C���̏ꍇ
				//if (LoginInfoAcquisition.OnlineFlag)
				//{
				//	// �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
				//	byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);
                //
				//	// �ǂݍ��ݏ���
				//	status = this._iSlipPrtSetDB.Read(ref parabyte,0);
                //
				//	if (status == 0)
				//	{
				//		// �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
				//		slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));
                ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
				//		if ((!slipPrtSetWork.OptionCode.Trim().Equals(string.Empty)) &&
				//			(!slipPrtSetWork.OptionCode.Trim().Equals(null)) &&
				//			(!slipPrtSetWork.OptionCode.Trim().Equals("0")))
				//		{
				//			PurchaseStatus purchaseStatus
				//				= LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetWork.OptionCode);
				//			if (purchaseStatus < PurchaseStatus.Contract)
				//			{
				//				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				//			}
				//		}
                //// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
                ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                //        ReadSlipPrtSetFromXml(ref slipPrtSetWork);
                //// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                //
				//		// �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N�N���X
				//		slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                //
				//		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
				//		// HashTable��Key
				//		string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
				//			+ "," + slipPrtSet.SlipPrtSetPaperId;
                //
				//		// �X�^�e�B�b�N�̈�ɏ���ێ�
				//		_static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
				//		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
				//	}
				//}
				//// �I�t���C���̏ꍇ
				//else
				//{
				//	status = ReadStaticMemory(out slipPrtSet, dataInputSystem, slipPrtKind, slipPrtSetPaperId);
				//}
                if (_isLocalDBRead)
                {
                    // �ǂݍ��ݏ���
                    status = this._slipPrtSetLcDB.Read(ref slipPrtSetWork, 0);
                    if (status == 0)
                    {
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                        //if ((!slipPrtSetWork.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetWork.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetWork.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetWork.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //    {
                        //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        //    }
                        //}
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END
                        ReadSlipPrtSetFromXml(ref slipPrtSetWork);
                        // �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N�N���X
                        slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                        // HashTable��Key
                        string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
                            + "," + slipPrtSet.SlipPrtSetPaperId;
                        // �X�^�e�B�b�N�̈�ɏ���ێ�
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
                    }
                }
                else
                {
                    // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// �I�����C���̏ꍇ
                    //if (LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    // �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
                    //    byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);
                    
                    //    // �ǂݍ��ݏ���
                    //    status = this._iSlipPrtSetDB.Read(ref parabyte,0);
                    
                    //    if (status == 0)
                    //    {
                    //        // �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
                    //        slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));
                    ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                    //        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                    //        //if ((!slipPrtSetWork.OptionCode.Trim().Equals(string.Empty)) &&
                    //        //    (!slipPrtSetWork.OptionCode.Trim().Equals(null)) &&
                    //        //    (!slipPrtSetWork.OptionCode.Trim().Equals("0")))
                    //        //{
                    //        //    PurchaseStatus purchaseStatus
                    //        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetWork.OptionCode);
                    //        //    if (purchaseStatus < PurchaseStatus.Contract)
                    //        //    {
                    //        //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    //        //    }
                    //        //}
                    //        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END                        
                    //// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
                    ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                    //        ReadSlipPrtSetFromXml(ref slipPrtSetWork);
                    //// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                    
                    //        // �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N�N���X
                    //        slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                    
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                    //        // HashTable��Key
                    //        string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
                    //            + "," + slipPrtSet.SlipPrtSetPaperId;
                    
                    //        // �X�^�e�B�b�N�̈�ɏ���ێ�
                    //        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                    //    }
                    //}
                    //// �I�t���C���̏ꍇ
                    //else
                    //{
                    //    status = ReadStaticMemory(out slipPrtSet, dataInputSystem, slipPrtKind, slipPrtSetPaperId);
                    //}

                    // �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
                    byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

                    // �ǂݍ��ݏ���
                    status = this._iSlipPrtSetDB.Read(ref parabyte, 0);

                    if (status == 0)
                    {
                        // �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
                        slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));
                        ReadSlipPrtSetFromXml(ref slipPrtSetWork);

                        // �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N�N���X
                        slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);

                        string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
                            + "," + slipPrtSet.SlipPrtSetPaperId;

                        // �X�^�e�B�b�N�̈�ɏ���ێ�
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
                    }
                    // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end

				return status;
			}
			catch (Exception)
			{				
				slipPrtSet = null;

				// �I�t���C������null���Z�b�g
				this._iSlipPrtSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static�̈�ێ������i�I�t���C���Ή��j
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�N���X</param>
		/// <param name="dataInputSystem"></param>
		/// <param name="slipPrtKind"></param>
		/// <param name="slipPrtSetPaperId"></param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �擾�����l��Static�̈�ɕێ����܂��B�i�I�t���C���Ή��j</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int ReadStaticMemory(out SlipPrtSet slipPrtSet, int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId)
		{
			slipPrtSet = new SlipPrtSet();

			// HashTable��Key
			string keysOfHashTable = dataInputSystem.ToString() + "," + slipPrtKind.ToString() + "," + slipPrtSetPaperId;

			if (_static_SlipPrtSetTable == null)
			{
				return -1;
			}

			// Static����f�[�^����������
			if (_static_SlipPrtSetTable[keysOfHashTable] == null)
			{
				return 4;
			}
			else
			{
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//				slipPrtSet = (SlipPrtSet)_static_SlipPrtSetTable[keysOfHashTable];
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
				SlipPrtSet slipPrtSetTemp = (SlipPrtSet)_static_SlipPrtSetTable[keysOfHashTable];
                // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                //{
                //    PurchaseStatus purchaseStatus
                //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                //    if (purchaseStatus < PurchaseStatus.Contract)
                //    {
                //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }
                //}
                // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END                        
// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
				SlipPrtSetWork slipPrtSetWorkTemp = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSetTemp);
				if (ReadSlipPrtSetFromXml(ref slipPrtSetWorkTemp) == 0)
				{
					slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
				}
				else
				{
					slipPrtSet = slipPrtSetTemp;
				}
// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
			}
			
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static�̈�S���擾�����i�I�t���C���Ή��j
		/// </summary>
		/// <param name="retList">�N���XList</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
		/// <remarks>
		/// <br>Note       : Static�̈�̃f�[�^�S�����擾���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			string keyObHashTable = null;

			if (_static_SlipPrtSetTable == null)
			{
				return -1;
			}
			else if (_static_SlipPrtSetTable.Count == 0)
			{
				return 9;
			}

			foreach (SlipPrtSet slipPrtSet in _static_SlipPrtSetTable.Values)
			{
				keyObHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
					+ "," + slipPrtSet.SlipPrtSetPaperId;
				sortedList.Add(keyObHashTable, slipPrtSet);
			}

			retList.AddRange(sortedList.Values);

			return 0;
		}
		#endregion

		#region -- �f�V���A���C�Y���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�`�[����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public SlipPrtSet SlipPrtSetDeserialize(string fileName)
		{
			SlipPrtSet slipPrtSet = null;

			// �t�@�C������n���ē`�[����ݒ胏�[�N�N���X���f�V���A���C�Y����
			SlipPrtSetWork slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(fileName,typeof(SlipPrtSetWork));

			// �f�V���A���C�Y���ʂ�`�[����ݒ�N���X�փR�s�[
			if (slipPrtSetWork != null) slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);

			return slipPrtSet;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�`�[����ݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public ArrayList SlipPrtSetListDeserialize(string fileName)
		{
			ArrayList slipPrtSetList = new ArrayList();
			slipPrtSetList.Clear();

			// �t�@�C������n���ē`�[����ݒ�N���X���f�V���A���C�Y����
			SlipPrtSetWork[] slipPrtSetWorks = (SlipPrtSetWork[])XmlByteSerializer.Deserialize(fileName, typeof(SlipPrtSetWork[]));

			// �f�V���A���C�Y���ʂ�`�[����ݒ�N���X�փR�s�[
			foreach (SlipPrtSetWork slipPrtSetWork in slipPrtSetWorks)
			{
				slipPrtSetList.Add(CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork));
			}

			return slipPrtSetList;
		}
		#endregion

		#region -- �o�^��X�V���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ���̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int WriteSlipPrtSet(ref SlipPrtSet slipPrtSet)
		{
            // �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
            SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

            // �`�[����ݒ胏�[�N���w�l�k�i�o�C�i���j
            byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

            int status = 0;

            try
            {
                // �������ݏ���
                status = this._iSlipPrtSetDB.Write(ref parabyte);
                // 2008.06.10 30413 ���� �������ݏ���������̌㏈�����R�����g�� >>>>>>START
                //if ( status == 0 )
                //{
////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                //    ArrayList retList;
                //    if ( SearchSlipPrtSetFromXml(out retList, LoginInfoAcquisition.EnterpriseCode) == 0 )
                //    {                        
                //        retList = DBAndXMLDataMergeParts.MergeSlipPrtSetForWriteToXml(slipPrtSetWork, retList);
                //    }
                //    else
                //    {
                //        retList = new ArrayList();
                //        retList.Add(slipPrtSetWork);
                //    }
                //    
			    //    // �������ݏ���
                //    OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
                //    string[] keyList = new string[1];
                //    keyList[0] = LoginInfoAcquisition.EnterpriseCode;
                //    
                    //status = offlineDataSerializer.Serialize("SlipPrtSetAcs_1", keyList, retList);                             // 2006.09.13 TAKAHASHI DELETE
                //    status = offlineDataSerializer.Serialize("SlipPrtSetAcs_1", keyList, retList, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD
// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                //    // �`�[����ݒ胏�[�N���w�l�k
                //    slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));
                //    // �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
                //    slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                //}
                // 2008.06.10 30413 ���� �������ݏ���������̌㏈�����R�����g�� <<<<<<END
            }
            catch ( Exception )
            {
                // �I�t���C������null���Z�b�g
                this._iSlipPrtSetDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�o�^�E�X�V�����i�I�t���C���Ή��j
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ���̓o�^�E�X�V���s���܂��B�i�I�t���C���Ή��j</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status = 0;

			if (_static_SlipPrtSetTable.Count != 0)
			{
				// HashTable��Key
				string [] keyList = new string[1];
				keyList[0] = LoginInfoAcquisition.EnterpriseCode;

				SortedList sortedList = new SortedList();
				SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

				ArrayList slipPrtSetList = new ArrayList();

				foreach (SlipPrtSet slipPrtSet in _static_SlipPrtSetTable.Values)
				{
					slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);
					slipPrtSetList.Add(slipPrtSetWork);
				}

				// �`�[����ݒ胏�[�N���i�o�C�i���j
                //status = offlineDataSerializer.Serialize("SlipPrtSetAcs", keyList, slipPrtSetList);                             // 2006.09.13 TAKAHASHI DELETE
                status = offlineDataSerializer.Serialize("SlipPrtSetAcs", keyList, slipPrtSetList, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD
			}

			return status;
		}
		#endregion

//----- h.ueno add---------- start 2007.12.17

		/// <summary>
		/// �`�[����ݒ�폜����
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ���̘_���폜���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int LogicalDelete(ref SlipPrtSet slipPrtSet)
		{
			try
			{
				int status = 0;

				// �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
				SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

				// �`�[����ݒ胏�[�N���w�l�k�i�o�C�i���j
				byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

				// �_���폜
				status = this._iSlipPrtSetDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �`�[����ݒ胏�[�N���w�l�k
					slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));
					
					// �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
					slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
				}
				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iSlipPrtSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �`�[����ݒ蕨���폜����
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ���̕����폜���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int Delete(SlipPrtSet slipPrtSet)
		{
			try
			{
				int status = 0;

				// �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
				SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

				// �`�[����ݒ胏�[�N���w�l�k�i�o�C�i���j
				byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

				// �����폜
				status = this._iSlipPrtSetDB.Delete(parabyte);

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iSlipPrtSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �`�[����ݒ�_���폜��������
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ���̕������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int Revival(ref SlipPrtSet slipPrtSet)
		{
			try
			{
				int status = 0;

				// �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
				SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

				// �`�[����ݒ胏�[�N���w�l�k�i�o�C�i���j
				byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

				// ��������
				status = this._iSlipPrtSetDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �`�[����ݒ胏�[�N���w�l�k
					slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));

					// �`�[����ݒ�f�[�^�N���X���`�[����ݒ胏�[�N
					slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
				}
				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iSlipPrtSetDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}
		
//----- h.ueno add---------- end   2007.12.17

		#region -- �V���A���C�Y���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�V���A���C�Y����
		/// </summary>
		/// <param name="slipPrtSet">�V���A���C�Y�Ώۓ`�[����ݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public void SlipPrtSetSerialize(SlipPrtSet slipPrtSet,string fileName)
		{
			// �`�[����ݒ胏�[�N���`�[����ݒ�f�[�^�N���X
			SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

			// �`�[����ݒ胏�[�N�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(slipPrtSetWork,fileName);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="slipPrtSetList">�V���A���C�Y�Ώۓ`�[����ݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public void SlipPrtSetListSerialize(ArrayList slipPrtSetList, string fileName)
		{
			// ArrayList����z��𐶐�
			SlipPrtSet[] slipPrtSets = (SlipPrtSet[])slipPrtSetList.ToArray(typeof(SlipPrtSet));

			// �`�[����ݒ�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(slipPrtSets,fileName);
		}
		#endregion

		#region -- �������� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchSlipPrtSet(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;

			// �`�[����ݒ茟������
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchAllSlipPrtSet(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;

			// �`�[����ݒ茟������
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����w��`�[����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSlipPrtSet��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevSlipPrtSet">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ē`�[����ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchSpecificationSlipPrtSet(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,SlipPrtSet prevSlipPrtSet)
		{			
			// �`�[����ݒ茟������
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevSlipPrtSet);			
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����w��`�[����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSlipPrtSet��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevSlipPrtSet">�O��ŏI�`�[����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ē`�[����ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchSpecificationAllSlipPrtSet(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,SlipPrtSet prevSlipPrtSet)
		{			
			// �`�[����ݒ茟������
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,readCnt,prevSlipPrtSet);	
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSlipPrtSet��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevSlipPrtSet">�O��ŏI�`�[����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		private int SearchSlipPrtSetProc(
			out ArrayList retList,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			int readCnt,
			SlipPrtSet prevSlipPrtSet)
		{
			int status = 0;
			
			// �`�[����ݒ�N���X�˓`�[����ݒ胏�[�N�N���X
			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

			if (prevSlipPrtSet != null) 
			{
				slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(prevSlipPrtSet);
			}

			slipPrtSetWork.EnterpriseCode = enterpriseCode;
			
			// �������ʃ��X�g��������
			retList = new ArrayList();
			retList.Clear();

			// �Ǎ��Ώۃf�[�^������0�ŏ�����
			retTotalCnt = 0;

			nextData = false;

			// �T�[�`�p���X�g������
			ArrayList paraList = new ArrayList();
			paraList.Clear();
			
			// �`�[����ݒ胏�[�N���w�l�k�i�o�C�i���j
			object paraobj = slipPrtSetWork;
			object retobj = null;

            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// �I�t���C���̏ꍇ
			//if (!LoginInfoAcquisition.OnlineFlag)
			//{
			//	status = SearchStaticMemory(out retList);
            //
			//}
			//// �I�����C���̏ꍇ
			//else
			//{
			//	// ��������
			//	status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0,logicalMode);
            //
			//	if (status == 0)
			//	{
			//		ArrayList slipPrtSetWorkList = new ArrayList();
			//		slipPrtSetWorkList = retobj as ArrayList;
            //
            //////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
            //        ArrayList xmlList;
            //        if ( SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0 )
            //        {
            //            slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
            //        }
            //// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
			//		foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
			//		{
			//			SlipPrtSet slipPrtSetTemp = new SlipPrtSet();
            //
			//			// �`�[����ݒ聩�`�[����ݒ胏�[�N
			//			slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
            //////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
			//			if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
			//				(!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
			//				(!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
			//			{
			//				PurchaseStatus purchaseStatus
			//					= LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
			//				if (purchaseStatus < PurchaseStatus.Contract)
			//					continue;
			//			}
            //// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
            //
			//			// �Ǎ����ʃR���N�V�����֒ǉ�
			//			retList.Add(slipPrtSetTemp);
            //
			//			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
			//			// HashTable��Key
			//			string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
			//				+ "," + slipPrtSetTemp.SlipPrtSetPaperId;
            //
			//			// �X�^�e�B�b�N�̈�ɏ���ێ�
			//			_static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
			//			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
			//		}
			//	}
			//}
            if (_isLocalDBRead)
            {
                // ��������
                List<SlipPrtSetWork> workList = new List<SlipPrtSetWork>();
                status = this._slipPrtSetLcDB.Search(out workList, slipPrtSetWork, 0, logicalMode);
                if (status == 0)
                {
                    ArrayList slipPrtSetWorkList = new ArrayList();
                    slipPrtSetWorkList.AddRange(workList);

                    ArrayList xmlList;
                    if (SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0)
                    {
                        slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                    }
                    foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
                    {
                        SlipPrtSet slipPrtSetTemp = new SlipPrtSet();

                        // �`�[����ݒ聩�`�[����ݒ胏�[�N
                        slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                        //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //        continue;
                        //}
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END
                        // �Ǎ����ʃR���N�V�����֒ǉ�
                        retList.Add(slipPrtSetTemp);
                        // HashTable��Key
                        string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
                            + "," + slipPrtSetTemp.SlipPrtSetPaperId;

                        // �X�^�e�B�b�N�̈�ɏ���ێ�
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
                    }
                }
            }
            else
            {
                // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// �I�t���C���̏ꍇ
                //if (!LoginInfoAcquisition.OnlineFlag)
                //{
                //    status = SearchStaticMemory(out retList);

                //}
                //// �I�����C���̏ꍇ
                //else
                //{
                //    // ��������
                //    status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0, logicalMode);

                //    if (status == 0)
                //    {
                //        ArrayList slipPrtSetWorkList = new ArrayList();
                //        slipPrtSetWorkList = retobj as ArrayList;

                //        ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                //        ArrayList xmlList;
                //        if (SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0)
                //        {
                //            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�ɂ��擾���\�b�h�ύX >>>>>>START
                //            // SFCMN00721B�̃��\�b�h�ł̓G���[�ɂȂ邽�߁A����̃��\�b�h�����s����悤�ɏC��
                //            //slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                //            slipPrtSetWorkList = MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                //            // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�ɂ��擾���\�b�h�ύX <<<<<<END
                            
                //        }
                //        // 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                //        foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
                //        {
                //            SlipPrtSet slipPrtSetTemp = new SlipPrtSet();

                //            // �`�[����ݒ聩�`�[����ݒ胏�[�N
                //            slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
                //            ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                //            // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                //            //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                //            //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                //            //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                //            //{
                //            //    PurchaseStatus purchaseStatus
                //            //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                //            //    if (purchaseStatus < PurchaseStatus.Contract)
                //            //        continue;
                //            //}
                //            // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END
                //            // 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////

                //            // �Ǎ����ʃR���N�V�����֒ǉ�
                //            retList.Add(slipPrtSetTemp);

                //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                //            // HashTable��Key
                //            string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
                //                + "," + slipPrtSetTemp.SlipPrtSetPaperId;

                //            // �X�^�e�B�b�N�̈�ɏ���ێ�
                //            _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
                //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                //        }
                //    }
                //}

                // ��������
                status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0, logicalMode);

                if (status == 0)
                {
                    ArrayList slipPrtSetWorkList = new ArrayList();
                    slipPrtSetWorkList = retobj as ArrayList;

                    ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                    ArrayList xmlList;
                    if (SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0)
                    {
                        // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�ɂ��擾���\�b�h�ύX >>>>>>START
                        // SFCMN00721B�̃��\�b�h�ł̓G���[�ɂȂ邽�߁A����̃��\�b�h�����s����悤�ɏC��
                        //slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                        slipPrtSetWorkList = MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                        // 2008.06.06 30413 ���� �v�����^�Ǘ�No�폜�ɂ��擾���\�b�h�ύX <<<<<<END

                    }
                    // 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                    foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
                    {
                        SlipPrtSet slipPrtSetTemp = new SlipPrtSet();

                        // �`�[����ݒ聩�`�[����ݒ胏�[�N
                        slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
                        ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                        //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //        continue;
                        //}
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END
                        // 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////

                        // �Ǎ����ʃR���N�V�����֒ǉ�
                        retList.Add(slipPrtSetTemp);

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                        // HashTable��Key
                        string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
                            + "," + slipPrtSetTemp.SlipPrtSetPaperId;

                        // �X�^�e�B�b�N�̈�ɏ���ێ�
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                    }
                }
                // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
			
			// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0)
			{
				retTotalCnt = retList.Count;
			}
				
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �`�[����ݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public int SearchSlipPrtSetDS(ref DataSet ds,string enterpriseCode)
		{
			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
			slipPrtSetWork.EnterpriseCode = enterpriseCode;

			// �`�[����ݒ胏�[�N���w�l�k�i�o�C�i���j
			object paraobj = slipPrtSetWork;
			object retobj = null;

            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// ��������
			//int status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0,0);
            //
			//if (status == 0) XmlByteSerializer.ReadXml(ref ds, (byte[])retobj);
			//
            int status;
            if (_isLocalDBRead)
            {
                // ��������
                List<SlipPrtSetWork> workList = new List<SlipPrtSetWork>();
                status = this._slipPrtSetLcDB.Search(out workList, slipPrtSetWork, 0, 0);
                if (status == 0)
                {
                    byte[] bytes = XmlByteSerializer.Serialize(workList);
                    XmlByteSerializer.ReadXml(ref ds, bytes);
                }
            }
            else
            {
                // ��������
                status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0, 0);

                if (status == 0) XmlByteSerializer.ReadXml(ref ds, (byte[])retobj);
            }
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
				
			return status;
		}
////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
        /// <summary>
        /// �`�[����ݒ茟������
        /// </summary>
		/// <param name="retList">�擾���ʊi�[�p</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : XML���`�[����ݒ�}�X�^�̌����������s���A�擾���ʂ�ArrayList�ŕԂ��܂��B</br>
        /// <br>Programmer : 22024�@���� �_�u</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int SearchSlipPrtSetFromXml(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;
            string[] keyArray = new string[1] { enterpriseCode };
            retList = new ArrayList();
            ArrayList readList;

            OfflineDataSerializer serializer = new OfflineDataSerializer();
            try
            {
                //readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray);                              // 2006.09.13 TAKAHASHI DELETE
                readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray, this._offlineDataDirPath);      // 2006.09.13 TAKAHASHI ADD

                if ( readList != null )
                {
                    foreach ( SlipPrtSetWork slipPrtSetTemp in readList )
                    {
////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v >>>>>>START
                        //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //        continue;
                        //}
                        // 2008.09.24 30413 ���� �}�X�^���o���Ƀ`�F�b�N���Ă���̂ŕs�v <<<<<<END                        
// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
                        retList.Add(slipPrtSetTemp);
                    }
                }
                else
                {
                    status = 4;
                }
            }
            catch ( Exception )
            {
                // �ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }

        // --ADD 2010/08/06--------------------------------------------------------------->>>>>
        /// <summary>
        /// ���Ӑ�i�`�[�Ǘ��j�ǂݍ��ݏ���
        /// </summary>
        /// <param name="custSlipMngWork">���Ӑ�i�`�[�Ǘ��j���[�N�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�i�`�[�Ǘ��j���[�N��ǂݍ��݁A�X�e�[�^�X��Ԃ��܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/06</br>
        /// </remarks>
        public int SearchCustSlipMng(ref CustSlipMngWork custSlipMngWork)
        {
            object outObj = custSlipMngWork as object;
            object obj = custSlipMngWork as object;

            int status = this._iCustSlipMngDB.Search(out outObj, obj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList custSlipMngWorkList = new ArrayList();
                custSlipMngWorkList = outObj as ArrayList;
                for (int i = 0; i < custSlipMngWorkList.Count; i++)
                {
                    custSlipMngWork = custSlipMngWorkList[i] as CustSlipMngWork;
                }
            }

            return status;
        }

        /// <summary>
        /// �`�[�ݒ�p�^�[���}�X�^ �ǂݍ��ݏ���
        /// </summary>
        /// <param name="slipPrtSetWork">�`�[�ݒ�p�^�[���}�X�^ ���[�N�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ݒ�p�^�[���}�X�^ �ǂݍ��݁A�X�e�[�^�X��Ԃ��܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/06</br>
        /// </remarks>
        public int SearchSlipPrtSet(SlipPrtSetWork slipPrtSetWork)
        {
            // �`�[����ݒ胏�[�N�N���X���w�l�k�i�o�C�i���j
            byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

            // �ǂݍ��ݏ���
            int status = this._iSlipPrtSetDB.Read(ref parabyte, 0);

            return status;
        }

        /// <summary>
        /// ���Ӑ�i�`�[�Ǘ��j�����폜����
        /// </summary>
        /// <param name="custSlipMngWork">���Ӑ�i�`�[�Ǘ��j���[�N�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�i�`�[�Ǘ��j�����폜����</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/06</br>
        /// </remarks>
        public int DeleteCustSlipMng(CustSlipMngWork custSlipMngWork)
        {
            // ���Ӑ�i�`�[�Ǘ��j���[�N�N���X���w�l�k�i�o�C�i���j
            byte[] parabyte = XmlByteSerializer.Serialize(custSlipMngWork);

            // �����폜����
            int status = this._iCustSlipMngDB.Delete(parabyte);

            return status;
        }
        // --ADD 2010/08/06---------------------------------------------------------------<<<<<

        /// <summary>
        /// �`�[����ݒ�ǂݍ��ݏ���
        /// </summary>
		/// <param name="slipPrtSetWork">�`�[����ݒ胏�[�N�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : XML���`�[����ݒ��ǂݍ��݁A�����Ɠ����L�[�̃��R�[�h���������ꍇ�̓}�[�W���܂��B</br>
        /// <br>Programmer : 22024�@���� �_�u</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private int ReadSlipPrtSetFromXml(ref SlipPrtSetWork slipPrtSetWork)
        {
            int status = 0;
            bool isExistRecord = false;
            string[] keyArray = new string[1] { LoginInfoAcquisition.EnterpriseCode };
            ArrayList readList;

            OfflineDataSerializer serializer = new OfflineDataSerializer();
            try
            {
                //readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray);                             // 2006.09.13 TAKAHASHI DELETE
                readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD

                if ( readList != null )
                {
                    foreach ( SlipPrtSetWork slipPrtSetTemp in readList )
                    {
                        // �L�[����v����f�[�^������ꍇXML�f�[�^��D�悷��
                        if ( ( slipPrtSetWork.EnterpriseCode.Equals(slipPrtSetTemp.EnterpriseCode) ) &&
                            ( slipPrtSetWork.DataInputSystem.Equals(slipPrtSetTemp.DataInputSystem) ) &&
                            ( slipPrtSetWork.SlipPrtKind.Equals(slipPrtSetTemp.SlipPrtKind) ) &&
                            ( slipPrtSetWork.SlipPrtSetPaperId.Equals(slipPrtSetTemp.SlipPrtSetPaperId) ) )
                        {
                            slipPrtSetWork.TopMargin = slipPrtSetTemp.TopMargin;
                            slipPrtSetWork.BottomMargin = slipPrtSetTemp.BottomMargin;
                            slipPrtSetWork.LeftMargin = slipPrtSetTemp.LeftMargin;
                            slipPrtSetWork.RightMargin = slipPrtSetTemp.RightMargin;
                            // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 >>>>>>START
                            //slipPrtSetWork.PrinterMngNo = slipPrtSetTemp.PrinterMngNo;
                            // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 <<<<<<END
                            isExistRecord = true;
                        }
                    }
                    if ( !isExistRecord )
                    {
                        status = 4;
                    }
                }
                else
                {
                    status = 4;
                }
            }
            catch ( Exception )
            {
                // �ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }
// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
		#endregion

		#region -- �N���X�����o�[�R�s�[���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�`�[����ݒ胏�[�N�N���X�˓`�[����ݒ�N���X�j
		/// </summary>
		/// <param name="slipPrtSetWork">�`�[����ݒ胏�[�N�N���X</param>
		/// <returns>�`�[����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ胏�[�N�N���X����`�[����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
        /// <br>Update Note: 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private SlipPrtSet CopyToSlipPrtSetFromSlipPrtSetWork(SlipPrtSetWork slipPrtSetWork)
		{
			SlipPrtSet slipPrtSet = new SlipPrtSet();

			slipPrtSet.CreateDateTime		= slipPrtSetWork.CreateDateTime;
			slipPrtSet.UpdateDateTime		= slipPrtSetWork.UpdateDateTime;
			slipPrtSet.EnterpriseCode		= slipPrtSetWork.EnterpriseCode;
			slipPrtSet.FileHeaderGuid		= slipPrtSetWork.FileHeaderGuid;
			slipPrtSet.UpdEmployeeCode		= slipPrtSetWork.UpdEmployeeCode;
			slipPrtSet.UpdAssemblyId1		= slipPrtSetWork.UpdAssemblyId1;
			slipPrtSet.UpdAssemblyId2		= slipPrtSetWork.UpdAssemblyId2;
			slipPrtSet.LogicalDeleteCode	= slipPrtSetWork.LogicalDeleteCode;

			slipPrtSet.DataInputSystem     = slipPrtSetWork.DataInputSystem;
			slipPrtSet.OutputPgId          = slipPrtSetWork.OutputPgId;
			slipPrtSet.OutputPgClassId     = slipPrtSetWork.OutputPgClassId;
			slipPrtSet.OutputFormFileName  = slipPrtSetWork.OutputFormFileName;
			slipPrtSet.EnterpriseNamePrtCd = slipPrtSetWork.EnterpriseNamePrtCd;
			slipPrtSet.PrtCirculation      = slipPrtSetWork.PrtCirculation;
			slipPrtSet.SlipFormCd          = slipPrtSetWork.SlipFormCd;
			slipPrtSet.OutConfimationMsg   = slipPrtSetWork.OutConfimationMsg;
			slipPrtSet.OptionCode          = slipPrtSetWork.OptionCode;
            // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 >>>>>>START
			//slipPrtSet.PrinterMngNo        = slipPrtSetWork.PrinterMngNo;
            // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 <<<<<<END
            slipPrtSet.TopMargin = slipPrtSetWork.TopMargin;
			slipPrtSet.LeftMargin          = slipPrtSetWork.LeftMargin;
			slipPrtSet.PrtPreviewExistCode = slipPrtSetWork.PrtPreviewExistCode;
			slipPrtSet.OutputPurpose       = slipPrtSetWork.OutputPurpose;
			// �`�[�^�C�v�ʗ�ID
			slipPrtSet.EachSlipTypeColId1  = slipPrtSetWork.EachSlipTypeColId1;
			slipPrtSet.EachSlipTypeColId2  = slipPrtSetWork.EachSlipTypeColId2;
			slipPrtSet.EachSlipTypeColId3  = slipPrtSetWork.EachSlipTypeColId3;
			slipPrtSet.EachSlipTypeColId4  = slipPrtSetWork.EachSlipTypeColId4;
			slipPrtSet.EachSlipTypeColId5  = slipPrtSetWork.EachSlipTypeColId5;
			slipPrtSet.EachSlipTypeColId6  = slipPrtSetWork.EachSlipTypeColId6;
			slipPrtSet.EachSlipTypeColId7  = slipPrtSetWork.EachSlipTypeColId7;
			slipPrtSet.EachSlipTypeColId8  = slipPrtSetWork.EachSlipTypeColId8;
			slipPrtSet.EachSlipTypeColId9  = slipPrtSetWork.EachSlipTypeColId9;
			slipPrtSet.EachSlipTypeColId10 = slipPrtSetWork.EachSlipTypeColId10;
            // �`�[�^�C�v�ʗ񖼏�
			slipPrtSet.EachSlipTypeColNm1  = slipPrtSetWork.EachSlipTypeColNm1;
			slipPrtSet.EachSlipTypeColNm2  = slipPrtSetWork.EachSlipTypeColNm2;
			slipPrtSet.EachSlipTypeColNm3  = slipPrtSetWork.EachSlipTypeColNm3;
			slipPrtSet.EachSlipTypeColNm4  = slipPrtSetWork.EachSlipTypeColNm4;
			slipPrtSet.EachSlipTypeColNm5  = slipPrtSetWork.EachSlipTypeColNm5;
			slipPrtSet.EachSlipTypeColNm6  = slipPrtSetWork.EachSlipTypeColNm6;
			slipPrtSet.EachSlipTypeColNm7  = slipPrtSetWork.EachSlipTypeColNm7;
			slipPrtSet.EachSlipTypeColNm8  = slipPrtSetWork.EachSlipTypeColNm8;
			slipPrtSet.EachSlipTypeColNm9  = slipPrtSetWork.EachSlipTypeColNm9;
			slipPrtSet.EachSlipTypeColNm10 = slipPrtSetWork.EachSlipTypeColNm10;
			// �`�[�^�C�v�ʗ�󎚋敪
			slipPrtSet.EachSlipTypeColPrt1  = slipPrtSetWork.EachSlipTypeColPrt1;
			slipPrtSet.EachSlipTypeColPrt2  = slipPrtSetWork.EachSlipTypeColPrt2;
			slipPrtSet.EachSlipTypeColPrt3  = slipPrtSetWork.EachSlipTypeColPrt3;
			slipPrtSet.EachSlipTypeColPrt4  = slipPrtSetWork.EachSlipTypeColPrt4;
			slipPrtSet.EachSlipTypeColPrt5  = slipPrtSetWork.EachSlipTypeColPrt5;
			slipPrtSet.EachSlipTypeColPrt6  = slipPrtSetWork.EachSlipTypeColPrt6;
			slipPrtSet.EachSlipTypeColPrt7  = slipPrtSetWork.EachSlipTypeColPrt7;
			slipPrtSet.EachSlipTypeColPrt8  = slipPrtSetWork.EachSlipTypeColPrt8;
			slipPrtSet.EachSlipTypeColPrt9  = slipPrtSetWork.EachSlipTypeColPrt9;
			slipPrtSet.EachSlipTypeColPrt10 = slipPrtSetWork.EachSlipTypeColPrt10;

			slipPrtSet.SlipFontName  = slipPrtSetWork.SlipFontName;
			slipPrtSet.SlipFontSize  = slipPrtSetWork.SlipFontSize;
			slipPrtSet.SlipFontStyle = slipPrtSetWork.SlipFontStyle;

            // 2008.06.05 30413 ���� �v�����^�Ǘ�No���̍폜 >>>>>>START
			//slipPrtSet.PrinterMngName = GetPrinterMngName(slipPrtSetWork.EnterpriseCode, slipPrtSetWork.PrinterMngNo);
            // 2008.06.05 30413 ���� �v�����^�Ǘ�No���̍폜 <<<<<<END
			

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			slipPrtSet.SlipPrtSetPaperId = slipPrtSetWork.SlipPrtSetPaperId;
			slipPrtSet.SlipComment       = slipPrtSetWork.SlipComment;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.14 TAKAHASHI ADD START
			slipPrtSet.SlipPrtKind  = slipPrtSetWork.SlipPrtKind;
			slipPrtSet.RightMargin  = slipPrtSetWork.RightMargin;
			slipPrtSet.BottomMargin = slipPrtSetWork.BottomMargin;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.14 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.15 TAKAHASHI ADD START
			slipPrtSet.SlipBaseColorRed1 = slipPrtSetWork.SlipBaseColorRed1;
			slipPrtSet.SlipBaseColorRed2 = slipPrtSetWork.SlipBaseColorRed2;
			slipPrtSet.SlipBaseColorRed3 = slipPrtSetWork.SlipBaseColorRed3;
			slipPrtSet.SlipBaseColorRed4 = slipPrtSetWork.SlipBaseColorRed4;
			slipPrtSet.SlipBaseColorRed5 = slipPrtSetWork.SlipBaseColorRed5;

			slipPrtSet.SlipBaseColorGrn1 = slipPrtSetWork.SlipBaseColorGrn1;
			slipPrtSet.SlipBaseColorGrn2 = slipPrtSetWork.SlipBaseColorGrn2;
			slipPrtSet.SlipBaseColorGrn3 = slipPrtSetWork.SlipBaseColorGrn3;
			slipPrtSet.SlipBaseColorGrn4 = slipPrtSetWork.SlipBaseColorGrn4;
			slipPrtSet.SlipBaseColorGrn5 = slipPrtSetWork.SlipBaseColorGrn5;

			slipPrtSet.SlipBaseColorBlu1 = slipPrtSetWork.SlipBaseColorBlu1;
			slipPrtSet.SlipBaseColorBlu2 = slipPrtSetWork.SlipBaseColorBlu2;
			slipPrtSet.SlipBaseColorBlu3 = slipPrtSetWork.SlipBaseColorBlu3;
			slipPrtSet.SlipBaseColorBlu4 = slipPrtSetWork.SlipBaseColorBlu4;
			slipPrtSet.SlipBaseColorBlu5 = slipPrtSetWork.SlipBaseColorBlu5;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.15 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//slipPrtSet.CustTelNoPrtDivCd = slipPrtSetWork.CustTelNoPrtDivCd;
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			slipPrtSet.CopyCount  = slipPrtSetWork.CopyCount;
			slipPrtSet.TitleName1 = slipPrtSetWork.TitleName1;
			slipPrtSet.TitleName2 = slipPrtSetWork.TitleName2;
			slipPrtSet.TitleName3 = slipPrtSetWork.TitleName3;
			slipPrtSet.TitleName4 = slipPrtSetWork.TitleName4;
			slipPrtSet.SpecialPurpose1 = slipPrtSetWork.SpecialPurpose1;
			slipPrtSet.SpecialPurpose2 = slipPrtSetWork.SpecialPurpose2;
			slipPrtSet.SpecialPurpose3 = slipPrtSetWork.SpecialPurpose3;
			slipPrtSet.SpecialPurpose4 = slipPrtSetWork.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//slipPrtSet.BarCodeAcpOdrNoPrtCd = slipPrtSetWork.BarCodeAcpOdrNoPrtCd;
			//slipPrtSet.BarCodeCustCodePrtCd = slipPrtSetWork.BarCodeCustCodePrtCd;
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
			//2006.12.08 deleted by T-Kidate
            //slipPrtSet.BarCodeCarMngNoPrtCd = slipPrtSetWork.BarCodeCarMngNoPrtCd;
			///// 2006.01.30 UENO ADD END //////////////////////////////////////////////
			
			// 2006/03/14 H.NAKAMURA ADD STA
			slipPrtSet.TitleName102 = slipPrtSetWork.TitleName102;
			slipPrtSet.TitleName103 = slipPrtSetWork.TitleName103;
			slipPrtSet.TitleName104 = slipPrtSetWork.TitleName104;
			slipPrtSet.TitleName105 = slipPrtSetWork.TitleName105;
			slipPrtSet.TitleName202 = slipPrtSetWork.TitleName202;
			slipPrtSet.TitleName203 = slipPrtSetWork.TitleName203;
			slipPrtSet.TitleName204 = slipPrtSetWork.TitleName204;
			slipPrtSet.TitleName205 = slipPrtSetWork.TitleName205;
			slipPrtSet.TitleName302 = slipPrtSetWork.TitleName302;
			slipPrtSet.TitleName303 = slipPrtSetWork.TitleName303;
			slipPrtSet.TitleName304 = slipPrtSetWork.TitleName304;
			slipPrtSet.TitleName305 = slipPrtSetWork.TitleName305;
			slipPrtSet.TitleName402 = slipPrtSetWork.TitleName402;
			slipPrtSet.TitleName403 = slipPrtSetWork.TitleName403;
			slipPrtSet.TitleName404 = slipPrtSetWork.TitleName404;
			slipPrtSet.TitleName405 = slipPrtSetWork.TitleName405;

            // 2008.06.05 30413 ���� ���ڂ̒ǉ� >>>>>>START
            slipPrtSet.Note1 = slipPrtSetWork.Note1;                            // ���l�P
            slipPrtSet.Note2 = slipPrtSetWork.Note2;                            // ���l�Q
            slipPrtSet.Note3 = slipPrtSetWork.Note3;                            // ���l�R
            slipPrtSet.QRCodePrintDivCd = slipPrtSetWork.QRCodePrintDivCd;      // QR�R�[�h�󎚋敪
            slipPrtSet.TimePrintDivCd = slipPrtSetWork.TimePrintDivCd;          // �����󎚋敪
            slipPrtSet.ReissueMark = slipPrtSetWork.ReissueMark;                // �Ĕ��s�}�[�N
            slipPrtSet.RefConsTaxDivCd = slipPrtSetWork.RefConsTaxDivCd;        // �Q�l����ŋ敪
            slipPrtSet.RefConsTaxPrtNm = slipPrtSetWork.RefConsTaxPrtNm;        // �Q�l����ň󎚖���
            slipPrtSet.DetailRowCount = slipPrtSetWork.DetailRowCount;          // ���׍s��
            // 2008.06.05 30413 ���� ���ڂ̒ǉ� <<<<<<END

            // 2008.08.28 30413 ���� ���ڂ̒ǉ� >>>>>>START
            slipPrtSet.HonorificTitle = slipPrtSetWork.HonorificTitle;          // �h��
            // 2008.08.28 30413 ���� ���ڂ̒ǉ� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            slipPrtSet.SlipNoteCharCnt = slipPrtSetWork.SlipNoteCharCnt;          // �`�[���l����
            slipPrtSet.SlipNote2CharCnt = slipPrtSetWork.SlipNote2CharCnt;        // �`�[���l�Q����
            slipPrtSet.SlipNote3CharCnt = slipPrtSetWork.SlipNote3CharCnt;        // �`�[���l�R����
            // --- ADD 2009/12/31 ----------<<<<<

            // 2008.12.11 30413 ���� ���ڂ̒ǉ� >>>>>>START
            slipPrtSet.ConsTaxPrtCd = slipPrtSetWork.ConsTaxPrtCdRF;              // ����ň�
            // 2008.12.11 30413 ���� ���ڂ̒ǉ� <<<<<<END

            //2006.12.08 deleted by T-Kidate
            //slipPrtSet.MainWorkLinePrtDivCd = slipPrtSetWork.MainWorkLinePrtDivCd;

			//2006/03/14 H.NAKAMURA ADD END

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////�_��ԍ��󎚋敪
			//slipPrtSet.ContractNoPrtDivCd = slipPrtSetWork.ContractNoPrtDivCd;
			////�_��g�ѓd�b�ԍ��󎚋敪
			//slipPrtSet.ContCpNoPrtDivCd = slipPrtSetWork.ContCpNoPrtDivCd;
			//----- h.ueno del---------- end   2007.12.17

            slipPrtSet.EntNmPrtExpDiv = slipPrtSetWork.EntNmPrtExpDiv; // ADD 2011/02/16
            // --- ADD START 2011/07/19 ---------->>>>>
            slipPrtSet.SCMAnsMarkPrtDiv = slipPrtSetWork.SCMAnsMarkPrtDiv;
            slipPrtSet.NormalPrtMark = slipPrtSetWork.NormalPrtMark;
            slipPrtSet.SCMManualAnsMark = slipPrtSetWork.SCMManualAnsMark;
            slipPrtSet.SCMAutoAnsMark = slipPrtSetWork.SCMAutoAnsMark;
            // --- ADD END 2011/07/19 ----------<<<<<

			return slipPrtSet;
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.26 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�`�[����ݒ胏�[�N�N���X�˓`�[����ݒ�N���X�j
		/// </summary>
		/// <param name="slipPrtSetWorkList">�`�[����ݒ胏�[�N�N���X���X�g</param>
		/// <returns>�`�[����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ胏�[�N�N���X����`�[����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		private void CopyToSlipPrtSetFromSlipPrtSetWork(ArrayList slipPrtSetWorkList)
		{
			// HashTable��Key
			string keyOfHashTable = null;

			// ArrayList����̏ꍇ
			if (slipPrtSetWorkList == null)
				return;

			foreach (SlipPrtSetWork slipPrtSetWork in slipPrtSetWorkList)
			{
				SlipPrtSet slipPrtSet = new SlipPrtSet();

				keyOfHashTable = slipPrtSetWork.DataInputSystem.ToString() + "," + slipPrtSetWork.SlipPrtKind + ","
					+ slipPrtSetWork.SlipPrtSetPaperId;

				slipPrtSet.CreateDateTime	 = slipPrtSetWork.CreateDateTime;
				slipPrtSet.UpdateDateTime	 = slipPrtSetWork.UpdateDateTime;
				slipPrtSet.EnterpriseCode	 = slipPrtSetWork.EnterpriseCode;
				slipPrtSet.FileHeaderGuid	 = slipPrtSetWork.FileHeaderGuid;
				slipPrtSet.UpdEmployeeCode	 = slipPrtSetWork.UpdEmployeeCode;
				slipPrtSet.UpdAssemblyId1	 = slipPrtSetWork.UpdAssemblyId1;
				slipPrtSet.UpdAssemblyId2	 = slipPrtSetWork.UpdAssemblyId2;
				slipPrtSet.LogicalDeleteCode = slipPrtSetWork.LogicalDeleteCode;

				slipPrtSet.DataInputSystem     = slipPrtSetWork.DataInputSystem;
				slipPrtSet.OutputPgId          = slipPrtSetWork.OutputPgId;
				slipPrtSet.OutputPgClassId     = slipPrtSetWork.OutputPgClassId;
				slipPrtSet.OutputFormFileName  = slipPrtSetWork.OutputFormFileName;
				slipPrtSet.EnterpriseNamePrtCd = slipPrtSetWork.EnterpriseNamePrtCd;
				slipPrtSet.PrtCirculation      = slipPrtSetWork.PrtCirculation;
				slipPrtSet.SlipFormCd          = slipPrtSetWork.SlipFormCd;
				slipPrtSet.OutConfimationMsg   = slipPrtSetWork.OutConfimationMsg;
				slipPrtSet.OptionCode          = slipPrtSetWork.OptionCode;
                // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 >>>>>>START
				//slipPrtSet.PrinterMngNo        = slipPrtSetWork.PrinterMngNo;
                // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 <<<<<<END
				slipPrtSet.TopMargin           = slipPrtSetWork.TopMargin;
				slipPrtSet.LeftMargin          = slipPrtSetWork.LeftMargin;
				slipPrtSet.PrtPreviewExistCode = slipPrtSetWork.PrtPreviewExistCode;
				slipPrtSet.OutputPurpose       = slipPrtSetWork.OutputPurpose;
				// �`�[�^�C�v�ʗ�ID
				slipPrtSet.EachSlipTypeColId1  = slipPrtSetWork.EachSlipTypeColId1;
				slipPrtSet.EachSlipTypeColId2  = slipPrtSetWork.EachSlipTypeColId2;
				slipPrtSet.EachSlipTypeColId3  = slipPrtSetWork.EachSlipTypeColId3;
				slipPrtSet.EachSlipTypeColId4  = slipPrtSetWork.EachSlipTypeColId4;
				slipPrtSet.EachSlipTypeColId5  = slipPrtSetWork.EachSlipTypeColId5;
				slipPrtSet.EachSlipTypeColId6  = slipPrtSetWork.EachSlipTypeColId6;
				slipPrtSet.EachSlipTypeColId7  = slipPrtSetWork.EachSlipTypeColId7;
				slipPrtSet.EachSlipTypeColId8  = slipPrtSetWork.EachSlipTypeColId8;
				slipPrtSet.EachSlipTypeColId9  = slipPrtSetWork.EachSlipTypeColId9;
				slipPrtSet.EachSlipTypeColId10 = slipPrtSetWork.EachSlipTypeColId10;
				// �`�[�^�C�v�ʗ񖼏�
				slipPrtSet.EachSlipTypeColNm1  = slipPrtSetWork.EachSlipTypeColNm1;
				slipPrtSet.EachSlipTypeColNm2  = slipPrtSetWork.EachSlipTypeColNm2;
				slipPrtSet.EachSlipTypeColNm3  = slipPrtSetWork.EachSlipTypeColNm3;
				slipPrtSet.EachSlipTypeColNm4  = slipPrtSetWork.EachSlipTypeColNm4;
				slipPrtSet.EachSlipTypeColNm5  = slipPrtSetWork.EachSlipTypeColNm5;
				slipPrtSet.EachSlipTypeColNm6  = slipPrtSetWork.EachSlipTypeColNm6;
				slipPrtSet.EachSlipTypeColNm7  = slipPrtSetWork.EachSlipTypeColNm7;
				slipPrtSet.EachSlipTypeColNm8  = slipPrtSetWork.EachSlipTypeColNm8;
				slipPrtSet.EachSlipTypeColNm9  = slipPrtSetWork.EachSlipTypeColNm9;
				slipPrtSet.EachSlipTypeColNm10 = slipPrtSetWork.EachSlipTypeColNm10;
				// �`�[�^�C�v�ʗ�󎚋敪
				slipPrtSet.EachSlipTypeColPrt1  = slipPrtSetWork.EachSlipTypeColPrt1;
				slipPrtSet.EachSlipTypeColPrt2  = slipPrtSetWork.EachSlipTypeColPrt2;
				slipPrtSet.EachSlipTypeColPrt3  = slipPrtSetWork.EachSlipTypeColPrt3;
				slipPrtSet.EachSlipTypeColPrt4  = slipPrtSetWork.EachSlipTypeColPrt4;
				slipPrtSet.EachSlipTypeColPrt5  = slipPrtSetWork.EachSlipTypeColPrt5;
				slipPrtSet.EachSlipTypeColPrt6  = slipPrtSetWork.EachSlipTypeColPrt6;
				slipPrtSet.EachSlipTypeColPrt7  = slipPrtSetWork.EachSlipTypeColPrt7;
				slipPrtSet.EachSlipTypeColPrt8  = slipPrtSetWork.EachSlipTypeColPrt8;
				slipPrtSet.EachSlipTypeColPrt9  = slipPrtSetWork.EachSlipTypeColPrt9;
				slipPrtSet.EachSlipTypeColPrt10 = slipPrtSetWork.EachSlipTypeColPrt10;

				slipPrtSet.SlipFontName      = slipPrtSetWork.SlipFontName;
				slipPrtSet.SlipFontSize      = slipPrtSetWork.SlipFontSize;
				slipPrtSet.SlipFontStyle     = slipPrtSetWork.SlipFontStyle;
                // 2008.06.05 30413 ���� �v�����^�Ǘ�No���̍폜 >>>>>>START
				//slipPrtSet.PrinterMngName    = GetPrinterMngName(slipPrtSetWork.EnterpriseCode, slipPrtSetWork.PrinterMngNo);
                // 2008.06.05 30413 ���� �v�����^�Ǘ�No���̍폜 <<<<<<END
				slipPrtSet.SlipPrtSetPaperId = slipPrtSetWork.SlipPrtSetPaperId;
				slipPrtSet.SlipComment       = slipPrtSetWork.SlipComment;
				slipPrtSet.SlipPrtKind       = slipPrtSetWork.SlipPrtKind;
				slipPrtSet.RightMargin       = slipPrtSetWork.RightMargin;
				slipPrtSet.BottomMargin      = slipPrtSetWork.BottomMargin;

				slipPrtSet.SlipBaseColorRed1 = slipPrtSetWork.SlipBaseColorRed1;
				slipPrtSet.SlipBaseColorRed2 = slipPrtSetWork.SlipBaseColorRed2;
				slipPrtSet.SlipBaseColorRed3 = slipPrtSetWork.SlipBaseColorRed3;
				slipPrtSet.SlipBaseColorRed4 = slipPrtSetWork.SlipBaseColorRed4;
				slipPrtSet.SlipBaseColorRed5 = slipPrtSetWork.SlipBaseColorRed5;

				slipPrtSet.SlipBaseColorGrn1 = slipPrtSetWork.SlipBaseColorGrn1;
				slipPrtSet.SlipBaseColorGrn2 = slipPrtSetWork.SlipBaseColorGrn2;
				slipPrtSet.SlipBaseColorGrn3 = slipPrtSetWork.SlipBaseColorGrn3;
				slipPrtSet.SlipBaseColorGrn4 = slipPrtSetWork.SlipBaseColorGrn4;
				slipPrtSet.SlipBaseColorGrn5 = slipPrtSetWork.SlipBaseColorGrn5;

				slipPrtSet.SlipBaseColorBlu1 = slipPrtSetWork.SlipBaseColorBlu1;
				slipPrtSet.SlipBaseColorBlu2 = slipPrtSetWork.SlipBaseColorBlu2;
				slipPrtSet.SlipBaseColorBlu3 = slipPrtSetWork.SlipBaseColorBlu3;
				slipPrtSet.SlipBaseColorBlu4 = slipPrtSetWork.SlipBaseColorBlu4;
				slipPrtSet.SlipBaseColorBlu5 = slipPrtSetWork.SlipBaseColorBlu5;

                // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
                //slipPrtSet.CustTelNoPrtDivCd = slipPrtSetWork.CustTelNoPrtDivCd;
                // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
				slipPrtSet.CopyCount  = slipPrtSetWork.CopyCount;
				slipPrtSet.TitleName1 = slipPrtSetWork.TitleName1;
				slipPrtSet.TitleName2 = slipPrtSetWork.TitleName2;
				slipPrtSet.TitleName3 = slipPrtSetWork.TitleName3;
				slipPrtSet.TitleName4 = slipPrtSetWork.TitleName4;
				slipPrtSet.SpecialPurpose1 = slipPrtSetWork.SpecialPurpose1;
				slipPrtSet.SpecialPurpose2 = slipPrtSetWork.SpecialPurpose2;
				slipPrtSet.SpecialPurpose3 = slipPrtSetWork.SpecialPurpose3;
				slipPrtSet.SpecialPurpose4 = slipPrtSetWork.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

				////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
                // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
				//slipPrtSet.BarCodeAcpOdrNoPrtCd = slipPrtSetWork.BarCodeAcpOdrNoPrtCd;
				//slipPrtSet.BarCodeCustCodePrtCd = slipPrtSetWork.BarCodeCustCodePrtCd;
                // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
                //2006.12.08 deleted by T-Kidate
                //slipPrtSet.BarCodeCarMngNoPrtCd = slipPrtSetWork.BarCodeCarMngNoPrtCd;
				///// 2006.01.30 UENO ADD END //////////////////////////////////////////////
				
				// 2006/03/14 H.NAKAMURA ADD STA
				slipPrtSet.TitleName102 = slipPrtSetWork.TitleName102;
				slipPrtSet.TitleName103 = slipPrtSetWork.TitleName103;
				slipPrtSet.TitleName104 = slipPrtSetWork.TitleName104;
				slipPrtSet.TitleName105 = slipPrtSetWork.TitleName105;
				slipPrtSet.TitleName202 = slipPrtSetWork.TitleName202;
				slipPrtSet.TitleName203 = slipPrtSetWork.TitleName203;
				slipPrtSet.TitleName204 = slipPrtSetWork.TitleName204;
				slipPrtSet.TitleName205 = slipPrtSetWork.TitleName205;
				slipPrtSet.TitleName302 = slipPrtSetWork.TitleName302;
				slipPrtSet.TitleName303 = slipPrtSetWork.TitleName303;
				slipPrtSet.TitleName304 = slipPrtSetWork.TitleName304;
				slipPrtSet.TitleName305 = slipPrtSetWork.TitleName305;
				slipPrtSet.TitleName402 = slipPrtSetWork.TitleName402;
				slipPrtSet.TitleName403 = slipPrtSetWork.TitleName403;
				slipPrtSet.TitleName404 = slipPrtSetWork.TitleName404;
				slipPrtSet.TitleName405 = slipPrtSetWork.TitleName405;

                // 2008.06.05 30413 ���� ���ڂ̒ǉ� >>>>>>START
                slipPrtSet.Note1 = slipPrtSetWork.Note1;                            // ���l�P
                slipPrtSet.Note2 = slipPrtSetWork.Note2;                            // ���l�Q
                slipPrtSet.Note3 = slipPrtSetWork.Note3;                            // ���l�R
                slipPrtSet.QRCodePrintDivCd = slipPrtSetWork.QRCodePrintDivCd;      // QR�R�[�h�󎚋敪
                slipPrtSet.TimePrintDivCd = slipPrtSetWork.TimePrintDivCd;          // �����󎚋敪
                slipPrtSet.ReissueMark = slipPrtSetWork.ReissueMark;                // �Ĕ��s�}�[�N
                slipPrtSet.RefConsTaxDivCd = slipPrtSetWork.RefConsTaxDivCd;        // �Q�l����ŋ敪
                slipPrtSet.RefConsTaxPrtNm = slipPrtSetWork.RefConsTaxPrtNm;        // �Q�l����ň󎚖���
                slipPrtSet.DetailRowCount = slipPrtSetWork.DetailRowCount;          // ���׍s��
                // 2008.06.05 30413 ���� ���ڂ̒ǉ� <<<<<<END

                // 2008.08.28 30413 ���� ���ڂ̒ǉ� >>>>>>START
                slipPrtSet.HonorificTitle = slipPrtSetWork.HonorificTitle;          // �h��
                // 2008.08.28 30413 ���� ���ڂ̒ǉ� <<<<<<END

                // --- ADD 2009/12/31 ---------->>>>>
                slipPrtSet.SlipNoteCharCnt = slipPrtSetWork.SlipNoteCharCnt;          // �`�[���l����
                slipPrtSet.SlipNote2CharCnt = slipPrtSetWork.SlipNote2CharCnt;        // �`�[���l�Q����
                slipPrtSet.SlipNote3CharCnt = slipPrtSetWork.SlipNote3CharCnt;        // �`�[���l�R����
                // --- ADD 2009/12/31 ----------<<<<<

                // 2008.12.11 30413 ���� ���ڂ̒ǉ� >>>>>>START
                slipPrtSet.ConsTaxPrtCd = slipPrtSetWork.ConsTaxPrtCdRF;              // ����ň�
                // 2008.12.11 30413 ���� ���ڂ̒ǉ� <<<<<<END

                //2006.12.08 deleted by T-Kidate
                //slipPrtSet.MainWorkLinePrtDivCd = slipPrtSetWork.MainWorkLinePrtDivCd;
				
                //2006/03/14 H.NAKAMURA ADD END

				//----- h.ueno del---------- start 2007.12.17
				////2006.12.08 added by T-Kidate
				////�_��ԍ��󎚋敪
				//slipPrtSet.ContractNoPrtDivCd = slipPrtSetWork.ContractNoPrtDivCd;
				////�_��g�ѓd�b�ԍ��󎚋敪
				//slipPrtSet.ContCpNoPrtDivCd = slipPrtSetWork.ContCpNoPrtDivCd;
				//----- h.ueno del---------- end   2007.12.17

				_static_SlipPrtSetTable[keyOfHashTable] = slipPrtSet;
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.26 TAKAHASHI ADD END
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�`�[����ݒ�N���X�˓`�[����ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="slipPrtSet">�`�[����ݒ胏�[�N�N���X</param>
		/// <returns>�`�[����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�N���X����`�[����ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
        /// <br>Update Note: 2009/12/31 ���M PM.NS�ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2010/08/06 caowj PM.NS1012�Ή�</br>
        /// <br>Update Note: 2011/02/16  ���N�n��</br>
        /// <br>             ���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s��̑Ή�</br>
        /// </remarks>
		private SlipPrtSetWork CopyToSlipPrtSetWorkFromSlipPrtSet(SlipPrtSet slipPrtSet)
		{
			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

			slipPrtSetWork.CreateDateTime		= slipPrtSet.CreateDateTime;
			slipPrtSetWork.UpdateDateTime		= slipPrtSet.UpdateDateTime;
			slipPrtSetWork.EnterpriseCode		= slipPrtSet.EnterpriseCode;
			slipPrtSetWork.FileHeaderGuid		= slipPrtSet.FileHeaderGuid;
			slipPrtSetWork.UpdEmployeeCode		= slipPrtSet.UpdEmployeeCode;
			slipPrtSetWork.UpdAssemblyId1		= slipPrtSet.UpdAssemblyId1;
			slipPrtSetWork.UpdAssemblyId2		= slipPrtSet.UpdAssemblyId2;
			slipPrtSetWork.LogicalDeleteCode	= slipPrtSet.LogicalDeleteCode;

			slipPrtSetWork.DataInputSystem     = slipPrtSet.DataInputSystem;
			slipPrtSetWork.OutputPgId          = slipPrtSet.OutputPgId.TrimEnd();
			slipPrtSetWork.OutputPgClassId     = slipPrtSet.OutputPgClassId.TrimEnd();
			slipPrtSetWork.OutputFormFileName  = slipPrtSet.OutputFormFileName.TrimEnd();
			slipPrtSetWork.EnterpriseNamePrtCd = slipPrtSet.EnterpriseNamePrtCd;
			slipPrtSetWork.PrtCirculation      = slipPrtSet.PrtCirculation;
			slipPrtSetWork.SlipFormCd          = slipPrtSet.SlipFormCd;
			slipPrtSetWork.OutConfimationMsg   = slipPrtSet.OutConfimationMsg.TrimEnd();
			slipPrtSetWork.OptionCode          = slipPrtSet.OptionCode;
            // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 >>>>>>START
            //slipPrtSetWork.PrinterMngNo        = slipPrtSet.PrinterMngNo;
            // 2008.06.05 30413 ���� �v�����^�Ǘ�No�폜 <<<<<<END
			slipPrtSetWork.TopMargin           = slipPrtSet.TopMargin;
			slipPrtSetWork.LeftMargin          = slipPrtSet.LeftMargin;
			slipPrtSetWork.PrtPreviewExistCode = slipPrtSet.PrtPreviewExistCode;
			slipPrtSetWork.OutputPurpose       = slipPrtSet.OutputPurpose;
			// �`�[�^�C�v�ʗ�ID
			slipPrtSetWork.EachSlipTypeColId1  = slipPrtSet.EachSlipTypeColId1.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId2  = slipPrtSet.EachSlipTypeColId2.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId3  = slipPrtSet.EachSlipTypeColId3.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId4  = slipPrtSet.EachSlipTypeColId4.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId5  = slipPrtSet.EachSlipTypeColId5.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId6  = slipPrtSet.EachSlipTypeColId6.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId7  = slipPrtSet.EachSlipTypeColId7.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId8  = slipPrtSet.EachSlipTypeColId8.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId9  = slipPrtSet.EachSlipTypeColId9.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId10 = slipPrtSet.EachSlipTypeColId10.TrimEnd();
			// �`�[�^�C�v�ʗ񖼏�
			slipPrtSetWork.EachSlipTypeColNm1  = slipPrtSet.EachSlipTypeColNm1.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm2  = slipPrtSet.EachSlipTypeColNm2.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm3  = slipPrtSet.EachSlipTypeColNm3.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm4  = slipPrtSet.EachSlipTypeColNm4.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm5  = slipPrtSet.EachSlipTypeColNm5.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm6  = slipPrtSet.EachSlipTypeColNm6.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm7  = slipPrtSet.EachSlipTypeColNm7.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm8  = slipPrtSet.EachSlipTypeColNm8.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm9  = slipPrtSet.EachSlipTypeColNm9.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm10 = slipPrtSet.EachSlipTypeColNm10.TrimEnd();
			// �`�[�^�C�v�ʗ�󎚋敪
			slipPrtSetWork.EachSlipTypeColPrt1  = slipPrtSet.EachSlipTypeColPrt1;
			slipPrtSetWork.EachSlipTypeColPrt2  = slipPrtSet.EachSlipTypeColPrt2;
			slipPrtSetWork.EachSlipTypeColPrt3  = slipPrtSet.EachSlipTypeColPrt3;
			slipPrtSetWork.EachSlipTypeColPrt4  = slipPrtSet.EachSlipTypeColPrt4;
			slipPrtSetWork.EachSlipTypeColPrt5  = slipPrtSet.EachSlipTypeColPrt5;
			slipPrtSetWork.EachSlipTypeColPrt6  = slipPrtSet.EachSlipTypeColPrt6;
			slipPrtSetWork.EachSlipTypeColPrt7  = slipPrtSet.EachSlipTypeColPrt7;
			slipPrtSetWork.EachSlipTypeColPrt8  = slipPrtSet.EachSlipTypeColPrt8;
			slipPrtSetWork.EachSlipTypeColPrt9  = slipPrtSet.EachSlipTypeColPrt9;
			slipPrtSetWork.EachSlipTypeColPrt10 = slipPrtSet.EachSlipTypeColPrt10;

			slipPrtSetWork.SlipFontName  = slipPrtSet.SlipFontName.TrimEnd();
			slipPrtSetWork.SlipFontSize  = slipPrtSet.SlipFontSize;
			slipPrtSetWork.SlipFontStyle = slipPrtSet.SlipFontStyle;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			slipPrtSetWork.SlipPrtSetPaperId = slipPrtSet.SlipPrtSetPaperId.TrimEnd();
			slipPrtSetWork.SlipComment       = slipPrtSet.SlipComment.TrimEnd();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.14 TAKAHASHI ADD START
			slipPrtSetWork.SlipPrtKind  = slipPrtSet.SlipPrtKind;
			slipPrtSetWork.RightMargin  = slipPrtSet.RightMargin;
			slipPrtSetWork.BottomMargin = slipPrtSet.BottomMargin;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.14 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.15 TAKAHASHI ADD START
			slipPrtSetWork.SlipBaseColorRed1 = slipPrtSet.SlipBaseColorRed1;
			slipPrtSetWork.SlipBaseColorRed2 = slipPrtSet.SlipBaseColorRed2;
			slipPrtSetWork.SlipBaseColorRed3 = slipPrtSet.SlipBaseColorRed3;
			slipPrtSetWork.SlipBaseColorRed4 = slipPrtSet.SlipBaseColorRed4;
			slipPrtSetWork.SlipBaseColorRed5 = slipPrtSet.SlipBaseColorRed5;

			slipPrtSetWork.SlipBaseColorGrn1 = slipPrtSet.SlipBaseColorGrn1;
			slipPrtSetWork.SlipBaseColorGrn2 = slipPrtSet.SlipBaseColorGrn2;
			slipPrtSetWork.SlipBaseColorGrn3 = slipPrtSet.SlipBaseColorGrn3;
			slipPrtSetWork.SlipBaseColorGrn4 = slipPrtSet.SlipBaseColorGrn4;
			slipPrtSetWork.SlipBaseColorGrn5 = slipPrtSet.SlipBaseColorGrn5;

			slipPrtSetWork.SlipBaseColorBlu1 = slipPrtSet.SlipBaseColorBlu1;
			slipPrtSetWork.SlipBaseColorBlu2 = slipPrtSet.SlipBaseColorBlu2;
			slipPrtSetWork.SlipBaseColorBlu3 = slipPrtSet.SlipBaseColorBlu3;
			slipPrtSetWork.SlipBaseColorBlu4 = slipPrtSet.SlipBaseColorBlu4;
			slipPrtSetWork.SlipBaseColorBlu5 = slipPrtSet.SlipBaseColorBlu5;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.15 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//slipPrtSetWork.CustTelNoPrtDivCd = slipPrtSet.CustTelNoPrtDivCd;
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			slipPrtSetWork.CopyCount  = slipPrtSet.CopyCount;
			slipPrtSetWork.TitleName1 = slipPrtSet.TitleName1;
			slipPrtSetWork.TitleName2 = slipPrtSet.TitleName2;
			slipPrtSetWork.TitleName3 = slipPrtSet.TitleName3;
			slipPrtSetWork.TitleName4 = slipPrtSet.TitleName4;
			slipPrtSetWork.SpecialPurpose1 = slipPrtSet.SpecialPurpose1;
			slipPrtSetWork.SpecialPurpose2 = slipPrtSet.SpecialPurpose2;
			slipPrtSetWork.SpecialPurpose3 = slipPrtSet.SpecialPurpose3;
			slipPrtSetWork.SpecialPurpose4 = slipPrtSet.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� >>>>>>START
			//slipPrtSetWork.BarCodeAcpOdrNoPrtCd = slipPrtSet. ;
			//slipPrtSetWork.BarCodeCustCodePrtCd = slipPrtSet.BarCodeCustCodePrtCd;
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�R�����g�� <<<<<<END
            //2006.12.08 deleted by T-Kidate
            //slipPrtSetWork.BarCodeCarMngNoPrtCd = slipPrtSet.BarCodeCarMngNoPrtCd;
			///// 2006.01.30 UENO ADD END //////////////////////////////////////////////
			
			// 2006/03/14 H.NAKAMURA ADD STA
			slipPrtSetWork.TitleName102 = slipPrtSet.TitleName102;
			slipPrtSetWork.TitleName103 = slipPrtSet.TitleName103;
			slipPrtSetWork.TitleName104 = slipPrtSet.TitleName104;
			slipPrtSetWork.TitleName105 = slipPrtSet.TitleName105;
			slipPrtSetWork.TitleName202 = slipPrtSet.TitleName202;
			slipPrtSetWork.TitleName203 = slipPrtSet.TitleName203;
			slipPrtSetWork.TitleName204 = slipPrtSet.TitleName204;
			slipPrtSetWork.TitleName205 = slipPrtSet.TitleName205;
			slipPrtSetWork.TitleName302 = slipPrtSet.TitleName302;
			slipPrtSetWork.TitleName303 = slipPrtSet.TitleName303;
			slipPrtSetWork.TitleName304 = slipPrtSet.TitleName304;
			slipPrtSetWork.TitleName305 = slipPrtSet.TitleName305; 
			slipPrtSetWork.TitleName402 = slipPrtSet.TitleName402;
			slipPrtSetWork.TitleName403 = slipPrtSet.TitleName403;
		    slipPrtSetWork.TitleName404 = slipPrtSet.TitleName404;
			slipPrtSetWork.TitleName405 = slipPrtSet.TitleName405;

            // 2008.06.05 30413 ���� ���ڂ̒ǉ� >>>>>>START
            slipPrtSetWork.Note1 = slipPrtSet.Note1;                            // ���l�P
            slipPrtSetWork.Note2 = slipPrtSet.Note2;                            // ���l�Q
            slipPrtSetWork.Note3 = slipPrtSet.Note3;                            // ���l�R
            slipPrtSetWork.QRCodePrintDivCd = slipPrtSet.QRCodePrintDivCd;      // QR�R�[�h�󎚋敪
            slipPrtSetWork.TimePrintDivCd = slipPrtSet.TimePrintDivCd;          // �����󎚋敪
            slipPrtSetWork.ReissueMark = slipPrtSet.ReissueMark;                // �Ĕ��s�}�[�N
            slipPrtSetWork.RefConsTaxDivCd = slipPrtSet.RefConsTaxDivCd;        // �Q�l����ŋ敪
            slipPrtSetWork.RefConsTaxPrtNm = slipPrtSet.RefConsTaxPrtNm;        // �Q�l����ň󎚖���
            slipPrtSetWork.DetailRowCount = slipPrtSet.DetailRowCount;          // ���׍s��
            // 2008.06.05 30413 ���� ���ڂ̒ǉ� <<<<<<END

            // 2008.08.28 30413 ���� ���ڂ̒ǉ� >>>>>>START
            slipPrtSetWork.HonorificTitle = slipPrtSet.HonorificTitle;          // �h��
            // 2008.08.28 30413 ���� ���ڂ̒ǉ� <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            slipPrtSetWork.SlipNoteCharCnt = slipPrtSet.SlipNoteCharCnt;          // �`�[���l����
            slipPrtSetWork.SlipNote2CharCnt = slipPrtSet.SlipNote2CharCnt;        // �`�[���l�Q����
            slipPrtSetWork.SlipNote3CharCnt = slipPrtSet.SlipNote3CharCnt;        // �`�[���l�R����
            // --- ADD 2009/12/31 ----------<<<<<

            // 2008.12.11 30413 ���� ���ڂ̒ǉ� >>>>>>START
            slipPrtSetWork.ConsTaxPrtCdRF = slipPrtSet.ConsTaxPrtCd;              // ����ň�
            // 2008.12.11 30413 ���� ���ڂ̒ǉ� <<<<<<END

            //2006.12.08 deleted by T-Kidate
            //slipPrtSetWork.MainWorkLinePrtDivCd = slipPrtSet.MainWorkLinePrtDivCd;
			
            //2006/03/14 H.NAKAMURA ADD END

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////�_��ԍ��󎚋敪
			//slipPrtSetWork.ContractNoPrtDivCd = slipPrtSet.ContractNoPrtDivCd;
			////�_��g�ѓd�b�ԍ��󎚋敪
			//slipPrtSetWork.ContCpNoPrtDivCd = slipPrtSet.ContCpNoPrtDivCd;
			//----- h.ueno del---------- end   2007.12.17

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            slipPrtSetWork.CustomerCode = slipPrtSet.CustomerCode;
            slipPrtSetWork.UpdateFlag = slipPrtSet.UpdateFlag;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
            slipPrtSetWork.EntNmPrtExpDiv = slipPrtSet.EntNmPrtExpDiv; // ADD 2011/02/16

            // --- ADD START 2011/07/19 ---------->>>>>
            slipPrtSetWork.SCMAnsMarkPrtDiv = slipPrtSet.SCMAnsMarkPrtDiv;
            slipPrtSetWork.NormalPrtMark = slipPrtSet.NormalPrtMark;
            slipPrtSetWork.SCMManualAnsMark = slipPrtSet.SCMManualAnsMark;
            slipPrtSetWork.SCMAutoAnsMark = slipPrtSet.SCMAutoAnsMark;
            // --- ADD END 2011/07/19 ----------<<<<<

			return slipPrtSetWork;
		}
		#endregion

		#region -- ���̎擾 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �v�����^�Ǘ������̎擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="printerMngNo">�v�����^�Ǘ���</param>
		/// <returns>�v�����^�Ǘ�������</returns>
		/// <remarks>
		/// <br>Note       : �v�����^�Ǘ�������v�����^�Ǘ������̂��擾���܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public string GetPrinterMngName(string enterpriseCode, int printerMngNo)
		{
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI ADD START
			int status = 0;

			int getMode = 1;

			ArrayList guideBuff = new ArrayList();
			
			status = prtManageAcs.GetBuff(out guideBuff, enterpriseCode, getMode);

			if (status != 0)
			{
				return "���o�^";
			}

			foreach (PrtManage prtManageGuide in guideBuff)
			{
				if (prtManageGuide.PrinterMngNo == printerMngNo)
				{
					if (prtManageGuide.LogicalDeleteCode == 0)
					{
						return prtManageGuide.PrinterName;
					}
					else
					{
						return "�폜��";
					}
				}
			}

			return "���o�^";
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI DELETE START
//			int status = prtManageAcs.Read(out prtManage, enterpriseCode, printerMngNo);
//
//			switch (status)
//			{
//				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//				{
//					if (prtManage.LogicalDeleteCode == 0)
//					{
//						return prtManage.PrinterName;
//					}
//					else
//					{
//						return "�폜��";
//					}
//				}
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					return "���o�^";
//				}
//				default :
//				{
//					return "";
//				}
//			}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI DELETE END
		}
		#endregion

//----- h.ueno add---------- start 2007.12.17
		#region Guide Methods
		
		/// <summary>
		/// �}�X�^�K�C�h�N������
		/// </summary>
		/// <param name="SlipPrtSet">�擾�f�[�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
		/// <remarks>
		/// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int ExecuteGuid(out SlipPrtSet SlipPrtSet, string enterpriseCode)
		{
			int status = -1;
			SlipPrtSet = new SlipPrtSet();
			
			TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();
			
			inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);		// ��ƃR�[�h

			// �K�C�h�N��
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				// �I���f�[�^�̎擾
				SlipPrtSet = CopyToSlipPrtSetFromGuideData(retObj);
				status = 0;
			}
			// �L�����Z��
			else
			{
				status = 1;
			}

			return status;
		}

		/// <summary>
		/// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
		/// <remarks>
		/// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = -1;
			string enterpriseCode = "";
			
			// ��ƃR�[�h�ݒ�L��
			if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA))
			{
				enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
			}
			// ��ƃR�[�h�ݒ薳��
			else
			{
				// �L�蓾�Ȃ��̂ŃG���[
				return status;
			}
			
			// �}�X�^�e�[�u���Ǎ���
			//DataSet retList;
			ArrayList retList = null;
			status = this.SearchAllSlipPrtSet(out retList, enterpriseCode);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// �K�C�h�����N����
						if (guideList.Tables.Count == 0)
						{
							// �K�C�h�p�f�[�^�Z�b�g����\�z
							this.GuideDataSetColumnConstruction(ref guideList);
						}

						// �K�C�h�p�f�[�^�Z�b�g�̍쐬
						this.GetGuideDataSet(ref guideList, retList, inParm);

						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				default:
					{
						status = -1;
						break;
					}
			}

			return status;
		}

		/// <summary>
		/// �K�C�h�p�f�[�^�Z�b�g�쐬����
		/// </summary>
		/// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
		/// <param name="retList">�i�[�A���C���X�g</param>>
		/// <param name="inParm">�p�����[�^</param>>
		/// <remarks>
		/// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList, Hashtable inParm)
		{
			SlipPrtSet slipPrtSet = null;
			DataRow guideRow = null;
			
			// �s�����������ĐV�����f�[�^��ǉ�
			retDataSet.Tables[0].Rows.Clear();
			retDataSet.Tables[0].BeginLoadData();

			int dataCnt = 0;
			while (dataCnt < retList.Count)
			{
				slipPrtSet = (SlipPrtSet)retList[dataCnt];
				guideRow = retDataSet.Tables[0].NewRow();
				// �f�[�^�R�s�[����
				CopyToGuideRowFromSlipPrtSet(ref guideRow, slipPrtSet);
				// �f�[�^�ǉ�
				retDataSet.Tables[0].Rows.Add(guideRow);
				
				dataCnt++;
			}

			retDataSet.Tables[0].EndLoadData();
		}

		/// <summary>
		/// �K�C�h�p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <param name="guideList">�K�C�h�p�f�[�^�Z�b�g</param>>
		/// <remarks>
		/// <br>Note       : �K�C�h�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void GuideDataSetColumnConstruction(ref DataSet guideList)
		{
			DataTable table = new DataTable();
			DataColumn column;

			// �f�[�^�V�X�e��
			column = new DataColumn();
			column.DataType = typeof(int);
			column.ColumnName = GUIDE_DATAINPUTSYSTEM_TITLE;
			table.Columns.Add(column);

			// �f�[�^�V�X�e����
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_DATAINPUTSYSTEMNAME_TITLE;
			table.Columns.Add(column);

			// �`�[������
			column = new DataColumn();
			column.DataType = typeof(int);
			column.ColumnName = GUIDE_SLIPPRTKIND_TITLE;
			table.Columns.Add(column);

			// �`�[�����ʖ�
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SLIPPRTKINDNAME_TITLE;
			table.Columns.Add(column);

			// �`�[����ݒ�p���[ID
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SLIPPRTSETPAPERID_TITLE;
			table.Columns.Add(column);

			// �`�[�R�����g
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SLIPCOMMENT_TITLE;
			table.Columns.Add(column);
			
			// �e�[�u���R�s�[
			guideList.Tables.Add(table.Clone());
		}

		/// <summary>
		/// �N���X�����o�R�s�[���� (�K�C�h�I���f�[�^�˓`�[����ݒ�N���X)
		/// </summary>
		/// <param name="guideData">�K�C�h�I���f�[�^</param>
		/// <returns>�`�[����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�I���f�[�^����`�[����ݒ�N���X�փ����o�R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private SlipPrtSet CopyToSlipPrtSetFromGuideData(Hashtable guideData)
		{
			SlipPrtSet slipPrtSet = new SlipPrtSet();
			slipPrtSet.DataInputSystem = (int)guideData[GUIDE_DATAINPUTSYSTEM_TITLE];
			slipPrtSet.SlipPrtKind = (int)guideData[GUIDE_SLIPPRTKIND_TITLE];
			slipPrtSet.SlipPrtSetPaperId = (string)guideData[GUIDE_SLIPPRTSETPAPERID_TITLE];
			return slipPrtSet;
		}

		/// <summary>
		/// DataRow�R�s�[�����i�`�[����ݒ�N���X�˃K�C�h�pDataRow�j
		/// </summary>
		/// <param name="guideRow">�K�C�h�pDataRow</param>
		/// <param name="slipPrtSet">�`�[����ݒ�N���X</param>
		/// <remarks>
		/// <br>Note       : �`�[����ݒ�N���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void CopyToGuideRowFromSlipPrtSet(ref DataRow guideRow, SlipPrtSet slipPrtSet)
		{
			guideRow[GUIDE_DATAINPUTSYSTEM_TITLE] = slipPrtSet.DataInputSystem;						// �f�[�^���̓V�X�e��
            // 2008.06.05 30413 ���� �������Ɩ��̐ݒ肵�Ă���ӏ��������̂ŁA�f�[�^���̓V�X�e�����̐ݒ肷�� >>>>>>START
			//guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = slipPrtSet.DataInputSystemName;				// �f�[�^���̓V�X�e����
            switch (slipPrtSet.DataInputSystem)
            {
                case 0:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "����";
                    break;
                case 1:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "����";
                    break;
                case 2:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "���";
                    break;
                case 3:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "�Ԕ�";
                    break;
            }
            // 2008.06.05 30413 ���� �������Ɩ��̐ݒ肵�Ă���ӏ��������̂ŁA�f�[�^���̓V�X�e�����̐ݒ肷�� <<<<<<END
			guideRow[GUIDE_SLIPPRTKIND_TITLE] = slipPrtSet.SlipPrtKind;								// �`�[������
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�����ʖ��̐ݒ��ύX >>>>>>START
			//guideRow[GUIDE_SLIPPRTKINDNAME_TITLE]
			//	= SlipPrtSet.GetSortedListNm(slipPrtSet.SlipPrtKind, SlipPrtSet._slipPrtKindList);	// �`�[�����ʖ�
            switch (slipPrtSet.SlipPrtKind)
            {
                case 10:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "���Ϗ�";
                    break;
                case 20:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�w����";
                    break;
                case 21:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "���菑";
                    break;
                case 30:
                    // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX >>>>>>START
                    //guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�[�i��";
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "����`�[";
                    // 2008.10.17 30413 ���� �[�i��������`�[�ɕύX <<<<<<END
                    break;
                case 40:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�ԕi�`�[";
                    break;
                case 100:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "���[�N�V�[�g";
                    break;
                case 110:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�{�f�B���@�}";
                    break;
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� >>>>>>START
                case 120:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�󒍓`�[";
                    break;
                case 130:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�ݏo�`�[";
                    break;
                case 140:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "���ϓ`�[";
                    break;
                case 150:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�݌Ɉړ��`�[";
                    break;
                case 160:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "�t�n�d�`�[";
                    break;
                // 2008.10.17 30413 ���� �`�[�����ʂ̒ǉ� <<<<<<END
            }
            // 2008.06.05 30413 ���� �r���h�G���[�̂��߁A�`�[�����ʖ��̐ݒ��ύX <<<<<<END
			guideRow[GUIDE_SLIPPRTSETPAPERID_TITLE] = slipPrtSet.SlipPrtSetPaperId;					// �`�[����ݒ�p���[ID
			guideRow[GUIDE_SLIPCOMMENT_TITLE] = slipPrtSet.SlipComment;								// �`�[�R�����g
		}
		#endregion

		#region �e��ϊ�
		/// <summary>
		/// NULL�����ϊ�����
		/// </summary>
		/// <param name="obj">�I�u�W�F�N�g</param>
		/// <returns>string�^�f�[�^</returns>
		/// <remarks>
		/// <br>Note       : NULL�������܂܂�Ă���ꍇ�_�u���N�H�[�g�֕ϊ�����</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public static string NullChgStr(object obj)
		{
			string ret;
			try
			{
				if (obj == null)
				{
					ret = "";
				}
				else
				{
					ret = obj.ToString();
				}
			}
			catch
			{
				ret = "";
			}
			return ret;
		}

		/// <summary>
		/// NULL�����ϊ�����
		/// </summary>
		/// <param name="obj">�I�u�W�F�N�g</param>
		/// <returns>int�^�f�[�^</returns>
		/// <remarks>
		/// <br>Note       : NULL�������܂܂�Ă���ꍇ�u0�v�֕ϊ�����</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public static int NullChgInt(object obj)
		{
			int ret;
			try
			{
				if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
				{
					ret = 0;
				}
				else
				{
					ret = Convert.ToInt32(obj);
				}
			}
			catch
			{
				ret = 0;
			}
			return ret;
		}

        /// <summary>
        /// �v�����^�Ǘ����擾
        /// </summary>
        /// <param name="dbList">�c�a���X�g</param>
        /// <param name="xmlList">�w�l�k���X�g</param>
        /// <returns>ArrayList�^�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : XML���X�g����v�����^�Ǘ������擾(SFCMN00721B����u������)</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public static ArrayList MergeSlipPrtSet(ArrayList dbList, ArrayList xmlList)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i != dbList.Count; i++)
            {
                SlipPrtSetWork work = (SlipPrtSetWork)dbList[i];
                if (work != null)
                {
                    for (int j = 0; j != xmlList.Count; j++)
                    {
                        SlipPrtSetWork work2 = (SlipPrtSetWork)xmlList[j];
                        if ((work2 != null)
                            && (work.EnterpriseCode.Equals(work2.EnterpriseCode))
                            && (work.DataInputSystem.Equals(work2.DataInputSystem))
                            && (work.SlipPrtKind.Equals(work2.SlipPrtKind))
                            && (work.SlipPrtSetPaperId.Equals(work2.SlipPrtSetPaperId))
                            && (work.FileHeaderGuid.Equals(work2.FileHeaderGuid)))
                        {
                            work.TopMargin = work2.TopMargin;
                            work.BottomMargin = work2.BottomMargin;
                            work.LeftMargin = work2.LeftMargin;
                            work.RightMargin = work2.RightMargin;
                        }
                    }
                    list.Add(work);
                }
            }
            return list;
        }
        #endregion

        //----- h.ueno add---------- end   2007.12.17
    }
}