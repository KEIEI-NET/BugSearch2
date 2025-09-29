using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

using Broadleaf.Application.Resources;// 2010/06/29 Add

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �[���ʓ`�[�o�͐ݒ�}�X�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �[���ʓ`�[�o�͐ݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30167 ���@�O�M</br>
	/// <br>Date       : 2007.12.10</br>
	/// <br>Update     : 2007/12/19  30167 ���@�O�M</br>
	/// <br>     		 �`�[����ݒ�}�X�^�R�Â��Ή�</br>
	/// <br>Update Note: 2008.01.31 30167 ���@�O�M</br>
	/// <br>			 ���[�J���c�a�Ή�</br>
    /// <br>           : 2008/10/03       �Ɠc �M�u</br>
    /// <br>             �o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2008/12/08 30365 �{�� �⎟�Y�@���������ڂ̒ǉ��ɑΉ�</br>
    /// <br>UpdateNote   : 2010/06/29 30517 �Ė� �x��@Mantsi.15669�@Admin���O�C������USER_AP�̒[���Ǘ��ݒ���Q�Ƃ���l�ɕύX</br>
    /// <br>UpdateNote   : 2010/09/27 22018 ��� ���b�@��ʒ��[���ݒ�\�ɕύX</br>
    /// <br>UpdateNote   : 2010/10/12 22018 ��� ���b�@�f�[�^�r���[�̃\�[�g����ύX����ׂɃ\�[�g�p���ǉ�</br>
    /// </remarks>
	public class SlipOutputSetAcs
	{
		//----------------------------------------
		// �[���ʓ`�[�o�͐ݒ�ݒ�}�X�^�萔��`
		//----------------------------------------
		public const string CREATEDATETIME = "CreateDateTime";
		public const string UPDATEDATETIME = "UpdateDateTime";
		public const string ENTERPRISECODE = "EnterpriseCode";
		public const string FILEHEADERGUID = "FileHeaderGuid";
		public const string UPDEMPLOYEECODE = "UpdEmployeeCode";
		public const string UPDASSEMBLYID1 = "UpdAssemblyId1";
		public const string UPDASSEMBLYID2 = "UpdAssemblyId2";
		public const string LOGICALDELETECODE = "LogicalDeleteCode";

		public const string SECTIONCODE_TITLE		= "���_�R�[�h";
        public const string WAREHOUSECODE_TITLE     = "�q�ɃR�[�h";
        //public const string WAREHOUSENAME_TITLE     = "�q�ɖ���";             //DEL 2008/10/03 ���̕ύX
        public const string WAREHOUSENAME_TITLE = "�q�ɖ�";                     //ADD 2008/10/03
        public const string SECTIONNAME_TITLE = "���_����";	// �����ێ��p
		public const string CASHREGISTERNO_TITLE	= "�[���ԍ�";
		//----- h.ueno add---------- start 2007.12.19
		public const string DATAINPUTSYSTEM_TITLE	= "�f�[�^���̓V�X�e���R�[�h";
		public const string DATAINPUTSYSTEMNM_TITLE = "�f�[�^���̓V�X�e��";	// �O���b�h�\���p
		//----- h.ueno add---------- end   2007.12.19		
		public const string SLIPPRTKIND_TITLE		= "�`�[�����ʃR�[�h";
        // --- ADD m.suzuki 2010/10/12 ---------->>>>>
        public const string SLIPPRTKIND_SORT_TITLE = "�`�[�����ʃR�[�h(�\�[�g�p)";
        // --- ADD m.suzuki 2010/10/12 ----------<<<<<
		public const string SLIPPRTKINDNM_TITLE		= "�`�[������";		// �O���b�h�\���p
		// --- UPD m.suzuki 2010/09/27 ---------->>>>>
        //public const string SLIPPRTSETPAPERID_TITLE = "�`�[����ݒ�p���[ID";
        public const string SLIPPRTSETPAPERID_TITLE = "�`�[����ݒ�p���[ID(��\��)"; // �����ێ��p
        // --- UPD m.suzuki 2010/09/27 ----------<<<<<
        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        public const string SLIPPRTSETPAPERID_DISP_TITLE = "�`�[����ݒ�p���[ID"; // �O���b�h�\���p
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		public const string PRINTERMNGNO_TITLE		= "�v�����^�Ǘ�No";
        // DEL 2008/10/09 �s��Ή�[6428] ��
        //public const string SLIPCOMMENT_TITLE		= "�`�[�R�����g";
        public const string SLIPCOMMENT_TITLE       = "�`�[������[��"; // ADD 2008/10/09 �s��Ή�[6428]
		public const string PRINTERNAME_TITLE		= "�v�����^��";
		public const string PRINTERPORT_TITLE		= "�v�����^�p�X";
		public const string DELETE_DATE_TITLE		= "�폜��";

		// �e�[�u����
		public const string MAIN_TABLE				= "MainTable";
		public const string SECOND_TABLE			= "SecondTable";

        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        // �J������
        public const string ct_col_Pgid = "PGID";
        public const string ct_col_Name = "NAME";
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		// private member��`
		// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		private ISlipOutputSetDB _iSlipOutputSetDB = null;    // �[���ʓ`�[�o�͐ݒ�ݒ胊���[�g

		//----- ueno add ---------- start 2008.01.31
		private SlipOutputSetLcDB _slipOutputSetLcDB = null;

		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		//----- ueno add ---------- end 2008.01.31

		private DataSet _dataTableList = null;
		
		// ���_�}�X�^�A�N�Z�X
		private SecInfoAcs _secInfoAcs = null;
		
		// �[���Ǘ��}�X�^�A�N�Z�X
        private PosTerminalMgAcs _posTerminalMgAcs = null;

        //--- ADD 2008/06/20 ---------->>>>>
        // �q�Ƀ}�X�^�A�N�Z�X
        private WarehouseAcs _warehouseAcs = null;
        //--- ADD 2008/06/20 ----------<<<<<<

		// �`�[����ݒ�p�}�X�^�A�N�Z�X�N���X
        private SlipPrtSetAcs _slipPrtSetAcs = null;

        // >>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
        // ����������p�^�[���ݒ�p�}�X�^�A�N�Z�X�N���X
        private DmdPrtPtnAcs _dmdPrtPtnAcs = null;

        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        // �o�͐ݒ�A�N�Z�X�N���X
        private OutputSetAcs _outputSetAcs = null;
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		// �v�����^�}�X�^�A�N�Z�X�N���X
		private PrtManageAcs _prtManageAcs = null;
		
		// �����񌋍��p
		private StringBuilder _stringBuilder = null;

        private bool _scmFlg = false;    // 2010/06/29 Add

	    // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        // ��ʒ��[�̃^�C�g���擾�p�f�B�N�V���i��
        private Dictionary<string, string> _outputSetDic;
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<

		#region Construcstor
		/// <summary>
		/// �[���ʓ`�[�o�͐ݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �[���ʓ`�[�o�͐ݒ�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public SlipOutputSetAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iSlipOutputSetDB = (ISlipOutputSetDB)MediationSlipOutputSetDB.GetSlipOutputSetDB();

				//----- ueno del ---------- start 2008.01.31
				// ���[�J���c�a�Ή��ɂ��擾�ʒu�ύX
				// ���_�}�X�^�A�N�Z�X�N���X
				//this._secInfoAcs = new SecInfoAcs();
				//----- ueno del ---------- end 2008.01.31

				// �[���Ǘ��}�X�^�A�N�Z�X
				this._posTerminalMgAcs = new PosTerminalMgAcs();

                //--- ADD 2008/06/20 ---------->>>>>
                // �q�Ƀ}�X�^�A�N�Z�X
                this._warehouseAcs = new WarehouseAcs();
                //--- ADD 2008/06/20 ---------->>>>>

                // �`�[����ݒ�p�}�X�^�A�N�Z�X�N���X
				this._slipPrtSetAcs = new SlipPrtSetAcs();

                // >>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
                // ����������p�^�[���ݒ�p�}�X�^�A�N�Z�X�N���X
                this._dmdPrtPtnAcs = new DmdPrtPtnAcs();

                // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                // �o�͐ݒ�A�N�Z�X�N���X
                this._outputSetAcs = new OutputSetAcs();
                // --- ADD m.suzuki 2010/09/27 ----------<<<<<

				// �v�����^�}�X�^�A�N�Z�X�N���X
				this._prtManageAcs = new PrtManageAcs();

                // 2010/06/29 Add >>>
                Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
                scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
                if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    _scmFlg = true;
                }
                else
                {
                    _scmFlg = false;
                }
                // 2010/06/29 Add <<<
            }
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iSlipOutputSetDB = null;
			}

			//----- ueno add ---------- start 2008.01.31
			// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			this._slipOutputSetLcDB = new SlipOutputSetLcDB();
			//----- ueno add ---------- end 2008.01.31

			// �f�[�^�Z�b�g����\�z����
			this._dataTableList = new DataSet();
			DataSetColumnConstruction(ref this._dataTableList);

			// �����񌋍��p
			this._stringBuilder = new StringBuilder();
		}
		#endregion

		// �񋓌^
		/// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online
		}

		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  �v���p�e�B
		//================================================================================
		/// <summary>
		/// ���[�J���c�aRead���[�h
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSlipOutputSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		#region Property
		/// <summary>��P�e�[�u���i�[���ԍ��e�[�u���j</summary>
		public DataTable DtMainTable
		{
			get { return this._dataTableList.Tables[MAIN_TABLE]; }
		}
		/// <summary>��Q�e�[�u���i�`�[����e�[�u���j</summary>
		public DataTable DtDetailsTable
		{
			get { return this._dataTableList.Tables[SECOND_TABLE]; }
		}
		#endregion

		#region public member

		#region GetTable �e�[�u���擾
		/// <summary>
		/// �e�[�u���擾
		/// </summary>
		/// <param name="tableName">�e�[�u����</param>		
		/// <returns>DataTable</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�e�[�u���̃I�u�W�F�N�g��Ԃ��܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public DataTable GetTable(string tableName)
		{
			if (this._dataTableList.Tables.Contains(tableName))
			{
				return this._dataTableList.Tables[tableName];
			}
			return null;
		}
		#endregion

		#region GetSlipOutputSet �[���ʓ`�[�o�͐ݒ�ݒ�f�[�^�擾
		/// <summary>
		/// �[���ʓ`�[�o�͐ݒ�ݒ�f�[�^�擾
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>		
		/// <param name="cashRegisterNo">�[���ԍ�</param>		
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>		
		/// <param name="slipPrtKind">�`�[������</param>		
		/// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID</param>		
		/// <param name="slipOutputSet">�[���ʓ`�[�o�͐ݒ�ݒ�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>		
		/// <returns>�t�@���N�V�����̃X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽKEY�����[���ʓ`�[�o�͐ݒ�ݒ�N���X��Ԃ��܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int GetSlipOutputSet(//string sectionCode,       // DEL 2008/06/20
									int cashRegisterNo,
                                    //--- ADD 2008/06/20 ---------->>>>>
                                    string warehouseCode,
                                    //--- ADD 2008/06/20 ----------<<<<<
									//----- h.ueno add---------- start 2007.12.19
									int dataInputSystem,
									//----- h.ueno add---------- start 2007.12.19
									int slipPrtKind,
									string slipPrtSetPaperId,
									out SlipOutputSet slipOutputSet,
									out string message)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			slipOutputSet = new SlipOutputSet();
			message = "";

			try
			{
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {  //sectionCode,      // DEL 2008/06/20
																								cashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								warehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								dataInputSystem,
																								//----- h.ueno add---------- start 2007.12.19
																								slipPrtKind,
																								slipPrtSetPaperId });
				if (dr == null)
				{
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}

				// �쐬����
				slipOutputSet.CreateDateTime = (DateTime)dr[CREATEDATETIME];
				// �X�V����
				slipOutputSet.UpdateDateTime = (DateTime)dr[UPDATEDATETIME];
				// ��ƃR�[�h
				slipOutputSet.EnterpriseCode = dr[ENTERPRISECODE].ToString();
				// GUID
				slipOutputSet.FileHeaderGuid = (Guid)dr[FILEHEADERGUID];
				// �X�V�]�ƈ��R�[�h
				slipOutputSet.UpdEmployeeCode = dr[UPDEMPLOYEECODE].ToString();
				// �X�V�A�Z���u��ID1
				slipOutputSet.UpdAssemblyId1 = dr[UPDASSEMBLYID1].ToString();
				// �X�V�A�Z���u��ID2
				slipOutputSet.UpdAssemblyId2 = dr[UPDASSEMBLYID2].ToString();
				// �_���폜�敪
				slipOutputSet.LogicalDeleteCode = Convert.ToInt32(dr[LOGICALDELETECODE]);

				// ���_�R�[�h
                //slipOutputSet.SectionCode = dr[SECTIONCODE_TITLE].ToString();             // DEL 2008/06/20
                //--- ADD 2008/06/18 ---------->>>>>
                // �q�ɃR�[�h
                slipOutputSet.WarehouseCode = dr[WAREHOUSECODE_TITLE].ToString();
                //--- ADD 2008/06/18 ----------<<<<<
                // �[���ԍ�
				slipOutputSet.CashRegisterNo = (int)dr[CASHREGISTERNO_TITLE];
				//----- h.ueno add---------- start 2007.12.19
				// �f�[�^���̓V�X�e��
				slipOutputSet.DataInputSystem = (int)dr[DATAINPUTSYSTEM_TITLE];
				//----- h.ueno add---------- end   2007.12.19		
				// �`�[������
				slipOutputSet.SlipPrtKind = (int)dr[SLIPPRTKIND_TITLE];
				// �`�[����ݒ�p���[ID
				slipOutputSet.SlipPrtSetPaperId = dr[SLIPPRTSETPAPERID_TITLE].ToString();
				// �v�����^�Ǘ�No
				slipOutputSet.PrinterMngNo = (int)dr[PRINTERMNGNO_TITLE];
				
				status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				slipOutputSet = null;
			}

			return status;
		}
		#endregion
		
		#region �`�[�R�����g�擾
		/// <summary>
		/// �`�[�R�����g�擾
		/// </summary>
		/// <remarks>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>
		/// <param name="slipPrtKind">�`�[������</param>
		/// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID</param>
		/// <returns>�`�[�R�����g</returns>
		/// <br>Note       : �`�[�R�����g���擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public string GetSlipComment(int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId)
		{
			string retStr = "";

            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // 99:���[�̏ꍇ�̓f�B�N�V���i�����g�p����B
            // (�����O���Ń\�[�g����ׂ�KEY��index����ꂽ�ׁAKEY�w��ň����Ȃ�)
            if ( slipPrtKind == 99 )
            {
                if ( _outputSetDic != null && _outputSetDic.ContainsKey( slipPrtSetPaperId ) )
                {
                    return _outputSetDic[slipPrtSetPaperId];
                }
                else
                {
                    return string.Empty;
                }
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

			// �L�[�쐬�i�f�[�^���̓V�X�e���{�`�[�����ʁ{�`�[����ݒ�p���[ID�j
			this._stringBuilder.Remove(0, this._stringBuilder.Length);
			this._stringBuilder.Append(dataInputSystem.ToString("d2"));
			this._stringBuilder.Append(slipPrtKind.ToString("d4"));
			this._stringBuilder.Append(slipPrtSetPaperId.TrimEnd());

			string key = this._stringBuilder.ToString();

			if (SlipOutputSet._slipPrtSetPaperIdList.ContainsKey(key) == true)
			{
				SlipPrtSet slipPrtSetWk = (SlipPrtSet)SlipOutputSet._slipPrtSetPaperIdList[key];

				retStr = slipPrtSetWk.SlipComment;
			}
			return retStr;
		}
		#endregion

		#region �v�����^���擾
		/// <summary>
		/// �v�����^���擾
		/// </summary>
		/// <remarks>
		/// <param name="printerMngNo">�v�����^�Ǘ�No</param>
		/// <returns>�v�����^��</returns>
		/// <br>Note       : �v�����^�����擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public string GetPrinterName(int printerMngNo)
		{
			string retStr = "";

			if (SlipOutputSet._printerMngNoList.ContainsKey(printerMngNo) == true)
			{
				PrtManage prtManageWk = (PrtManage)SlipOutputSet._printerMngNoList[printerMngNo];
				retStr = prtManageWk.PrinterName;
			}
			return retStr;
		}
		#endregion

		#region �v�����^�|�[�g�擾
		/// <summary>
		/// �v�����^�|�[�g�擾
		/// </summary>
		/// <remarks>
		/// <param name="printerMngNo">�v�����^�Ǘ�No</param>
		/// <returns>�v�����^�|�[�g</returns>
		/// <br>Note       : �v�����^�|�[�g���擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public string GetPrinterPort(int printerMngNo)
		{
			string retStr = "";

			if (SlipOutputSet._printerMngNoList.ContainsKey(printerMngNo) == true)
			{
				PrtManage prtManageWk = (PrtManage)SlipOutputSet._printerMngNoList[printerMngNo];
				retStr = prtManageWk.PrinterPort;
			}
			return retStr;
		}
		#endregion

		#region Search ��������
		/// <summary>
		/// ���������i�_���폜�܂܂Ȃ��j
		/// </summary>
		/// <param name="retArrayList">�Ǎ����ʃR���N�V����(ArrayList)</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="message">���b�Z�[�W</param>		
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[�o�͐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Search(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
		{
			DataSet dmyDataSet = null;	// �f�[�^�Z�b�g�͎g�p���Ȃ�

			// ����
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, 0, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}

		/// <summary>
		/// ���������i�_���폜�܂܂Ȃ��j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����(DataSet)</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="message">���b�Z�[�W</param>		
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[�o�͐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Search(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
		{
			ArrayList dmyArrayList = null;	// ArrayList�͎g�p���Ȃ�

			// ����
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, 0, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}
		#endregion
		
		#region SearchAll ��������
		/// <summary>
		/// ���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retArrayList">�Ǎ����ʃR���N�V����(ArrayList)</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="message">���b�Z�[�W</param>		
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[�o�͐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int SearchAll(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, out string message)
		{
			DataSet dmyDataSet = null;	// �f�[�^�Z�b�g�͎g�p���Ȃ�
			
			// ����
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}
		
		/// <summary>
		/// ���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����(DataSet)</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="message">���b�Z�[�W</param>		
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �`�[�o�͐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int SearchAll(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
		{
			ArrayList dmyArrayList = null;	// ArrayList�͎g�p���Ȃ�
			
			// ����
            //--- DEL 2008/06/20 ---------->>>>>
            //int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- DEL 2008/06/20 ----------<<<<<
            //--- ADD 2008/06/20 ---------->>>>>
            int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, out message);
            //--- ADD 2008/06/20 ----------<<<<<
            return status;
		}
		#endregion

		#region Write �������ݏ���
		/// <summary>
		/// �������ݏ���
		/// </summary>
		/// <param name="slipOutputSet">�ۑ��f�[�^</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �������ݏ������s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Write(ref SlipOutputSet slipOutputSet, out string message)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

			try
			{
				// �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				ArrayList paraSlipOutputSetWorkList = new ArrayList();
				paraSlipOutputSetWorkList.Add(slipOutputSetWork);
				object paraObj = paraSlipOutputSetWorkList;

				// �������ݏ���
				status = this._iSlipOutputSetDB.Write(ref paraObj);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ��������̃G���[����
					message = "�o�^�Ɏ��s���܂����B";
					return status;
				}

				// ���[�N�f�[�^���N���X�f�[�^�ɕϊ�
				slipOutputSetWork = (SlipOutputSetWork)((ArrayList)paraObj)[0];
				slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

				// �f�[�^�o�^�ς݃`�F�b�N
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSetWork.SectionCode,    // DEL 2008/06/20
																						slipOutputSetWork.CashRegisterNo,
																						//--- ADD 2008/06/20 ---------->>>>>
																						slipOutputSetWork.WarehouseCode,
																						//--- ADD 2008/06/20 ----------<<<<<
																						//----- h.ueno add---------- start 2007.12.19
																						slipOutputSetWork.DataInputSystem,
																						//----- h.ueno add---------- end   2007.12.19
																						slipOutputSetWork.SlipPrtKind,
																						slipOutputSetWork.SlipPrtSetPaperId });
				if (dr == null)
				{
					// ���o�^�̏ꍇ�̓��[�N�f�[�^��DataRow�ɕϊ�
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);

					// ���o�^�̏ꍇ�̓��R�[�h��ǉ�
					this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
				}
				else
				{
					// �o�^�ς݂̏ꍇ�͍X�V
					dr[UPDATEDATETIME] = slipOutputSetWork.UpdateDateTime;
					dr[UPDEMPLOYEECODE] = slipOutputSetWork.UpdEmployeeCode;
					dr[UPDASSEMBLYID1] = slipOutputSetWork.UpdAssemblyId1;
					dr[UPDASSEMBLYID2] = slipOutputSetWork.UpdAssemblyId2;

					// ���_�R�[�h
                    //dr[SECTIONCODE_TITLE] = slipOutputSetWork.SectionCode;        // DEL 2008/06/20
                    // �[���ԍ�
					dr[CASHREGISTERNO_TITLE] = slipOutputSetWork.CashRegisterNo;
                    //--- ADD 2008/06/20 ---------->>>>>
                    // �q�ɃR�[�h
                    dr[WAREHOUSECODE_TITLE] = slipOutputSetWork.WarehouseCode;
                    //--- ADD 2008/06/20 ----------<<<<<
                    //----- h.ueno add---------- start 2007.12.19
					// �f�[�^���̓V�X�e��
					dr[DATAINPUTSYSTEM_TITLE] = slipOutputSetWork.DataInputSystem;
					// �f�[�^���̓V�X�e�����́i�O���b�h�\���p�j
					dr[DATAINPUTSYSTEMNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.DataInputSystem, SlipOutputSet._dataInputSystemList);
					//----- h.ueno add---------- end   2007.12.19
					// �`�[������
					dr[SLIPPRTKIND_TITLE] = slipOutputSetWork.SlipPrtKind;
                    // --- ADD m.suzuki 2010/10/12 ---------->>>>>
                    // �`�[�����ʁi�\�[�g�p�j
                    dr[SLIPPRTKIND_SORT_TITLE] = GetSlipPrtKindForSort( slipOutputSetWork.SlipPrtKind );
                    // --- ADD m.suzuki 2010/10/12 ----------<<<<<
					// �`�[�����ʖ��́i�O���b�h�\���p�j
					dr[SLIPPRTKINDNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.SlipPrtKind, SlipOutputSet._slipPrtKindList);				
					// �`�[����ݒ�p���[ID
					dr[SLIPPRTSETPAPERID_TITLE] = slipOutputSetWork.SlipPrtSetPaperId;
                    // --- ADD m.suzuki 2010/09/27 ---------->>>>>
                    // �`�[����ݒ�p���[ID�i�\���p�j
                    if ( slipOutputSetWork.SlipPrtKind == 99 )
                    {
                        // ��ʒ��[
                        dr[SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
                    }
                    else
                    {
                        // �`�[�E������
                        dr[SLIPPRTSETPAPERID_DISP_TITLE] = slipOutputSetWork.SlipPrtSetPaperId;
                    }
                    // --- ADD m.suzuki 2010/09/27 ----------<<<<<
					// �v�����^�Ǘ�No
					dr[PRINTERMNGNO_TITLE] = slipOutputSetWork.PrinterMngNo;
					
					//----------�\���p����----------//
					// �`�[�R�����g�i�`�[����ݒ�p���[���́j
					string wkStr = GetSlipComment(slipOutputSet.DataInputSystem, slipOutputSetWork.SlipPrtKind, slipOutputSetWork.SlipPrtSetPaperId);
					dr[SLIPCOMMENT_TITLE] = wkStr;

					// �v�����^��
					dr[PRINTERNAME_TITLE] = GetPrinterName(slipOutputSetWork.PrinterMngNo);
					// �v�����^�|�[�g�i�p�X�j
					dr[PRINTERPORT_TITLE] = GetPrinterPort(slipOutputSetWork.PrinterMngNo);
				}

				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// �I�t���C������null���Z�b�g
				this._iSlipOutputSetDB = null;
				// �ʐM�G���[
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

        // --- ADD m.suzuki 2010/10/12 ---------->>>>>
        /// <summary>
        /// �`�[�����ʁi�\�[�g�p�j�擾����
        /// </summary>
        /// <param name="slipPrtKind"></param>
        /// <returns></returns>
        private int GetSlipPrtKindForSort( int slipPrtKind )
        {
            // ���f�[�^�r���[��Ń\�[�g����ׂɁA
            //   ���f�[�^��̎�ʂ̒l�Ƃ͈قȂ�␳�l��ԋp���܂��B
            switch ( slipPrtKind )
            {
                default:
                    {
                        // 10:���Ϗ�
                        // 30:����`�[
                        // 120:�󒍓`�[
                        // 130:�ݏo�`�[
                        // 140:���ϓ`�[
                        // 150:�݌Ɉړ��`�[
                        // 160:�t�n�d�`�[
                        return (slipPrtKind);
                    }
                case 50:
                case 60:
                case 70:
                case 80:
                    {
                        // 50:���v������
                        // 60:���א�����
                        // 70:�`�[���v������
                        // 80:�̎���
                        return (2000 + slipPrtKind);
                    }
                case 99:
                    {
                        // 99:���[
                        return (9000 + slipPrtKind);
                    }
            }
        }
        // --- ADD m.suzuki 2010/10/12 ----------<<<<<
		#endregion

		#region LogicalDelete �_���폜����
		/// <summary>
		/// �_���폜����
		/// </summary>
		/// <param name="slipOutputSet">�`�[����ݒ�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �_���폜�������s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int LogicalDelete(ref SlipOutputSet slipOutputSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				ArrayList slipOutputSetWorkList = new ArrayList();
				slipOutputSetWorkList.Add(slipOutputSetWork);
				object paraObj = slipOutputSetWorkList;

				// �폜����
				status = this._iSlipOutputSetDB.LogicalDelete(ref paraObj);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ��������̃G���[����
					message = "�폜�Ɏ��s���܂����B";
					return status;
				}

				// �N���X�f�[�^�ɔ��f
				slipOutputSetWork = (SlipOutputSetWork)((ArrayList)paraObj)[0];
				slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

				// �f�[�^�e�[�u���ɔ��f
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,    // DEL 2008/06/20
																								slipOutputSet.CashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								slipOutputSet.WarehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								slipOutputSet.DataInputSystem,
																								//----- h.ueno add---------- end   2007.12.19
																								slipOutputSet.SlipPrtKind,
																								slipOutputSet.SlipPrtSetPaperId });
				if (dr != null)
				{
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);
				}
				this._dataTableList.AcceptChanges();


				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// �I�t���C������null���Z�b�g
				this._iSlipOutputSetDB = null;
				// �ʐM�G���[
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region Revival ��������
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="slipOutputSet">�`�[����ݒ�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <remarks>
		/// <returns>�X�e�[�^�X</returns>
		/// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Revival(ref SlipOutputSet slipOutputSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				ArrayList paraSlipOutputSetWorkList = new ArrayList();
				paraSlipOutputSetWorkList.Add(slipOutputSetWork);
				object paraObj = paraSlipOutputSetWorkList;

				// �������ݏ���
				status = this._iSlipOutputSetDB.RevivalLogicalDelete(ref paraObj);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ��������̃G���[����
					message = "�폜�Ɏ��s���܂����B";
					return status;
				}

				// �N���X�f�[�^�ɔ��f
				slipOutputSetWork = (SlipOutputSetWork)((ArrayList)paraObj)[0];
				slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

				// �f�[�^�e�[�u���ɔ��f
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,        // DEL 2008/06/20
																								slipOutputSet.CashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								slipOutputSet.WarehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								slipOutputSet.DataInputSystem,
																								//----- h.ueno add---------- end   2007.12.19
																								slipOutputSet.SlipPrtKind,
																								slipOutputSet.SlipPrtSetPaperId });
				if (dr != null)
				{
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);
				}
				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// �I�t���C������null���Z�b�g
				this._iSlipOutputSetDB = null;
				// �ʐM�G���[
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region Delete �폜����
		/// <summary>
		/// �폜����
		/// </summary>
		/// <param name="slipOutputSet">�`�[����ݒ�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Delete(ref SlipOutputSet slipOutputSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
				SlipOutputSetWork slipOutputSetWork = CopyToSlipOutputSetWorkFromSlipOutputSet(slipOutputSet);

				// �V���A���C�Y
				byte[] paraSlipOutputSetWork = XmlByteSerializer.Serialize(slipOutputSetWork);

				// �������ݏ���
				status = this._iSlipOutputSetDB.Delete(paraSlipOutputSetWork);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ��������̃G���[����
					message = "�폜�Ɏ��s���܂����B";
					return status;
				}

				// �f�[�^�o�^�ς݃`�F�b�N
				DataRow dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,        // DEL 2008/06/20
																								slipOutputSet.CashRegisterNo,
																								//--- ADD 2008/06/20 ---------->>>>>
																								slipOutputSet.WarehouseCode,
																								//--- ADD 2008/06/20 ----------<<<<<
																								//----- h.ueno add---------- start 2007.12.19
																								slipOutputSet.DataInputSystem,
																								//----- h.ueno add---------- end   2007.12.19
																								slipOutputSet.SlipPrtKind,
																								slipOutputSet.SlipPrtSetPaperId });
				if (dr != null)
				{
					// �����폜�����f�[�^���폜
					this._dataTableList.Tables[SECOND_TABLE].Rows.Remove(dr);
				}
				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// �I�t���C������null���Z�b�g
				this._iSlipOutputSetDB = null;
				// �ʐM�G���[
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#endregion

		#region private member

		#region �f�[�^�Z�b�g����\�z����
		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private void DataSetColumnConstruction(ref DataSet ds)
		{
			//----------------------------------------------------------------
			// �[���ԍ��e�[�u�����`
			//----------------------------------------------------------------
			DataTable cashRegisterNoTable = new DataTable(MAIN_TABLE);

			// ���_�R�[�h
            //cashRegisterNoTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));   // DEL 2008/06/20
			
			// ���_����
			cashRegisterNoTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));
			
			// �[���ԍ�
			cashRegisterNoTable.Columns.Add(CASHREGISTERNO_TITLE, typeof(Int32));

            //cashRegisterNoTable.PrimaryKey = new DataColumn[] { cashRegisterNoTable.Columns[SECTIONCODE_TITLE], cashRegisterNoTable.Columns[CASHREGISTERNO_TITLE] };  // DEL 2008/06/20
            cashRegisterNoTable.PrimaryKey = new DataColumn[] { cashRegisterNoTable.Columns[CASHREGISTERNO_TITLE] };    // ADD 2008/06/20
            this._dataTableList.Tables.Add(cashRegisterNoTable);

			//----------------------------------------------------------------
			// �[���ʓ`�[�o�͐ݒ�e�[�u�����`
			//----------------------------------------------------------------
			DataTable slipPrtTable = new DataTable(SECOND_TABLE);

			// �쐬����
			slipPrtTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
			// �X�V����
			slipPrtTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
			// ��ƃR�[�h
			slipPrtTable.Columns.Add(ENTERPRISECODE, typeof(string));
			// GUID
			slipPrtTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
			// �X�V�]�ƈ��R�[�h
			slipPrtTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
			// �X�V�A�Z���u��ID1
			slipPrtTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
			// �X�V�A�Z���u��ID2
			slipPrtTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
			// �_���폜�敪
			slipPrtTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));

			// ���_�R�[�h
            //slipPrtTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));      // DEL 2008/06/20
			// �[���ԍ�
			slipPrtTable.Columns.Add(CASHREGISTERNO_TITLE, typeof(Int32));

            //--- ADD 2008/06/20 ---------->>>>>
            // �q�ɃR�[�h
            slipPrtTable.Columns.Add(WAREHOUSECODE_TITLE, typeof(string));
            // �q�ɖ���
            slipPrtTable.Columns.Add(WAREHOUSENAME_TITLE, typeof(string));
            //--- ADD 2008/06/20 ----------<<<<<

			//----- h.ueno add---------- start 2007.12.19
			// �f�[�^���̓V�X�e��
			slipPrtTable.Columns.Add(DATAINPUTSYSTEM_TITLE, typeof(Int32));
			// �f�[�^���̓V�X�e�����́i�O���b�h�\���p�j
			slipPrtTable.Columns.Add(DATAINPUTSYSTEMNM_TITLE, typeof(string));
			//----- h.ueno add---------- end   2007.12.19
			// �`�[������
			slipPrtTable.Columns.Add(SLIPPRTKIND_TITLE, typeof(Int32));
            // --- ADD m.suzuki 2010/10/12 ---------->>>>>
            // �`�[������(�\�[�g�p)
            slipPrtTable.Columns.Add( SLIPPRTKIND_SORT_TITLE, typeof( Int32 ) );
            // --- ADD m.suzuki 2010/10/12 ----------<<<<<
			// �`�[�����ʖ��́i�O���b�h�\���p�j
			slipPrtTable.Columns.Add(SLIPPRTKINDNM_TITLE, typeof(string));
			// �`�[����ݒ�p���[ID
			slipPrtTable.Columns.Add(SLIPPRTSETPAPERID_TITLE, typeof(string));
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // �`�[����ݒ�p���[ID�i�\���p�j
            slipPrtTable.Columns.Add( SLIPPRTSETPAPERID_DISP_TITLE, typeof( string ) );
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
			// �v�����^�Ǘ�No
			slipPrtTable.Columns.Add(PRINTERMNGNO_TITLE, typeof(Int32));

			// �`�[�R�����g�i�`�[����ݒ�p���[���́j
			slipPrtTable.Columns.Add(SLIPCOMMENT_TITLE, typeof(string));
			// �v�����^��
			slipPrtTable.Columns.Add(PRINTERNAME_TITLE, typeof(string));
			// �v�����^�|�[�g�i�p�X�j
			slipPrtTable.Columns.Add(PRINTERPORT_TITLE, typeof(string));
			
			
			
			// �폜��
			slipPrtTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));

			slipPrtTable.PrimaryKey = new DataColumn[] { //slipPrtTable.Columns[SECTIONCODE_TITLE],     // DEL 2008/06/20
														 slipPrtTable.Columns[CASHREGISTERNO_TITLE],
											 			 //--- ADD 2008/06/20 ---------->>>>>
														 slipPrtTable.Columns[WAREHOUSECODE_TITLE],
											 			 //--- ADD 2008/06/20 ----------<<<<<
											 			 //----- h.ueno add---------- start 2007.12.19
														 slipPrtTable.Columns[DATAINPUTSYSTEM_TITLE],
														 //----- h.ueno add---------- end   2007.12.19
														 slipPrtTable.Columns[SLIPPRTKIND_TITLE],
														 slipPrtTable.Columns[SLIPPRTSETPAPERID_TITLE] };

			this._dataTableList.Tables.Add(slipPrtTable);

		}
		#endregion

		#region �N���X�����o�R�s�[����
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�[���ʓ`�[�o�͐ݒ�ݒ�N���X�˒[���ʓ`�[�o�͐ݒ�ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="slipOutputSet">�[���ʓ`�[�o�͐ݒ�ݒ�N���X</param>
		/// <returns>SlipOutputSetWork</returns>
		/// <remarks>
		/// <br>Note       : �[���ʓ`�[�o�͐ݒ�ݒ�N���X����[���ʓ`�[�o�͐ݒ�ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private SlipOutputSetWork CopyToSlipOutputSetWorkFromSlipOutputSet(SlipOutputSet slipOutputSet)
		{
			SlipOutputSetWork slipOutputSetWork = new SlipOutputSetWork();

			// �쐬����
			slipOutputSetWork.CreateDateTime = slipOutputSet.CreateDateTime;
			// �X�V����
			slipOutputSetWork.UpdateDateTime = slipOutputSet.UpdateDateTime;
			// ��ƃR�[�h
			slipOutputSetWork.EnterpriseCode = slipOutputSet.EnterpriseCode;
			// GUID
			slipOutputSetWork.FileHeaderGuid = slipOutputSet.FileHeaderGuid;
			// �X�V�]�ƈ��R�[�h
			slipOutputSetWork.UpdEmployeeCode = slipOutputSet.UpdEmployeeCode;
			// �X�V�A�Z���u��ID1
			slipOutputSetWork.UpdAssemblyId1 = slipOutputSet.UpdAssemblyId1;
			// �X�V�A�Z���u��ID2
			slipOutputSetWork.UpdAssemblyId2 = slipOutputSet.UpdAssemblyId2;
			// �_���폜�敪
			slipOutputSetWork.LogicalDeleteCode = slipOutputSet.LogicalDeleteCode;

			// ���_�R�[�h
            //slipOutputSetWork.SectionCode = slipOutputSet.SectionCode;        // DEL 2008/06/20
			// �[���ԍ�
			slipOutputSetWork.CashRegisterNo = slipOutputSet.CashRegisterNo;
            //--- ADD 2008/06/19 ---------->>>>>
            // �q�ɃR�[�h
            slipOutputSetWork.WarehouseCode = slipOutputSet.WarehouseCode;
            //--- ADD 2008/06/19 ----------<<<<<
			//----- h.ueno add---------- start 2007.12.19
			// �f�[�^���̓V�X�e��
			slipOutputSetWork.DataInputSystem = slipOutputSet.DataInputSystem;
			//----- h.ueno add---------- end   2007.12.19
			// �`�[������
			slipOutputSetWork.SlipPrtKind = slipOutputSet.SlipPrtKind;
			// �`�[����ݒ�p���[ID
			slipOutputSetWork.SlipPrtSetPaperId = slipOutputSet.SlipPrtSetPaperId;
			// �v�����^�Ǘ�No
			slipOutputSetWork.PrinterMngNo = slipOutputSet.PrinterMngNo;

			return slipOutputSetWork;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�[���ʓ`�[�o�͐ݒ�ݒ胏�[�N�N���X�˒[���ʓ`�[�o�͐ݒ�ݒ�N���X�j
		/// </summary>
		/// <param name="slipOutputSetWork">�[���ʓ`�[�o�͐ݒ�ݒ胏�[�N�N���X</param>
		/// <returns>SlipOutputSetWork</returns>
		/// <remarks>
		/// <br>Note       : �[���ʓ`�[�o�͐ݒ�ݒ胏�[�N�N���X����[���ʓ`�[�o�͐ݒ�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private SlipOutputSet CopyToSlipOutputSetFromSlipOutputSetWork(SlipOutputSetWork slipOutputSetWork)
		{
			SlipOutputSet slipOutputSet = new SlipOutputSet();

			// �쐬����
			slipOutputSet.CreateDateTime = slipOutputSetWork.CreateDateTime;
			// �X�V����
			slipOutputSet.UpdateDateTime = slipOutputSetWork.UpdateDateTime;
			// ��ƃR�[�h
			slipOutputSet.EnterpriseCode = slipOutputSetWork.EnterpriseCode;
			// GUID
			slipOutputSet.FileHeaderGuid = slipOutputSetWork.FileHeaderGuid;
			// �X�V�]�ƈ��R�[�h
			slipOutputSet.UpdEmployeeCode = slipOutputSetWork.UpdEmployeeCode;
			// �X�V�A�Z���u��ID1
			slipOutputSet.UpdAssemblyId1 = slipOutputSetWork.UpdAssemblyId1;
			// �X�V�A�Z���u��ID2
			slipOutputSet.UpdAssemblyId2 = slipOutputSetWork.UpdAssemblyId2;
			// �_���폜�敪
			slipOutputSet.LogicalDeleteCode = slipOutputSetWork.LogicalDeleteCode;
			
			// ���_�R�[�h
            //slipOutputSet.SectionCode = slipOutputSetWork.SectionCode;            // DEL 2008/06/20
			// �[���ԍ�
			slipOutputSet.CashRegisterNo = slipOutputSetWork.CashRegisterNo;
            //--- ADD 2008/06/19 ---------->>>>>
            // �q�ɃR�[�h
            slipOutputSet.WarehouseCode = slipOutputSetWork.WarehouseCode;
            //--- ADD 2008/06/19 ----------<<<<<
            //----- h.ueno add---------- start 2007.12.19
			// �f�[�^���̓V�X�e��
			slipOutputSet.DataInputSystem = slipOutputSetWork.DataInputSystem;
			//----- h.ueno add---------- end   2007.12.19
			// �`�[������
			slipOutputSet.SlipPrtKind = slipOutputSetWork.SlipPrtKind;
			// �`�[����ݒ�p���[ID
			slipOutputSet.SlipPrtSetPaperId = slipOutputSetWork.SlipPrtSetPaperId;
			// �v�����^�Ǘ�No
			slipOutputSet.PrinterMngNo = slipOutputSetWork.PrinterMngNo;

			return slipOutputSet;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�[���ʓ`�[�o�͐ݒ�ݒ�N���X��DataRow�j
		/// </summary>
		/// <param name="slipOutputSet">�[���ʓ`�[�o�͐ݒ�ݒ�N���X</param>
		/// <returns>DataRow</returns>
		/// <remarks>
		/// <br>Note       : �[���ʓ`�[�o�͐ݒ�ݒ胏�[�N�N���X����[���ʓ`�[�o�͐ݒ�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private DataRow CopyToDataRowFromSlipOutputSetWork(ref SlipOutputSetWork slipOutputSetWork)
		{
			SlipOutputSet slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);

			// �[���ʓ`�[�o�͐ݒ�ݒ�}�X�^�ւ̓o�^
			DataRow dr;
			dr = this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSet.SectionCode,        // DEL 2008/06/20
																					slipOutputSet.CashRegisterNo,
																					//--- ADD 2008/06/20 ---------->>>>>
                                                                                    slipOutputSet.WarehouseCode,
																					//--- ADD 2008/06/20 ----------<<<<<
																					//----- h.ueno add---------- start 2007.12.19
																					slipOutputSet.DataInputSystem,
																					//----- h.ueno add---------- end   2007.12.19
																					slipOutputSet.SlipPrtKind,
																					slipOutputSet.SlipPrtSetPaperId});
			if (dr == null)
			{
				dr = this._dataTableList.Tables[SECOND_TABLE].NewRow();
			}

			// �쐬����
			dr[CREATEDATETIME] = slipOutputSet.CreateDateTime;
			// �X�V����
			dr[UPDATEDATETIME] = slipOutputSet.UpdateDateTime;
			// ��ƃR�[�h
			dr[ENTERPRISECODE] = slipOutputSet.EnterpriseCode;

			if (slipOutputSet.FileHeaderGuid == Guid.Empty)
			{
				// GUID
				dr[FILEHEADERGUID] = Guid.NewGuid();
			}
			else
			{
				// GUID
				dr[FILEHEADERGUID] = slipOutputSet.FileHeaderGuid;
			}
			// �X�V�]�ƈ��R�[�h
			dr[UPDEMPLOYEECODE] = slipOutputSet.UpdEmployeeCode;
			// �X�V�A�Z���u��ID1
			dr[UPDASSEMBLYID1] = slipOutputSet.UpdAssemblyId1;
			// �X�V�A�Z���u��ID2
			dr[UPDASSEMBLYID2] = slipOutputSet.UpdAssemblyId2;
			// �_���폜�敪
			dr[LOGICALDELETECODE] = slipOutputSet.LogicalDeleteCode;

			// ���_�R�[�h
            //dr[SECTIONCODE_TITLE] = slipOutputSet.SectionCode;        // DEL 2008/06/20
			// �[���ԍ�
			dr[CASHREGISTERNO_TITLE] = slipOutputSet.CashRegisterNo;
            //--- ADD 2008/06/19 ---------->>>>>
            dr[WAREHOUSECODE_TITLE] = slipOutputSet.WarehouseCode;
            dr[WAREHOUSENAME_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.WarehouseCode, SlipOutputSet._warehouseCodeList);
            //--- ADD 2008/06/19 ----------<<<<<
            //----- h.ueno add---------- start 2007.12.19
			// �V�X�e���f�[�^����
			dr[DATAINPUTSYSTEM_TITLE] = slipOutputSet.DataInputSystem;
			// �V�X�e���f�[�^���́i�O���b�h�\���p�j
			dr[DATAINPUTSYSTEMNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSet.DataInputSystem, SlipOutputSet._dataInputSystemList);
			//----- h.ueno add---------- end   2007.12.19
			// �`�[������
			dr[SLIPPRTKIND_TITLE] = slipOutputSet.SlipPrtKind;
            // --- ADD m.suzuki 2010/10/12 ---------->>>>>
            dr[SLIPPRTKIND_SORT_TITLE] = GetSlipPrtKindForSort( slipOutputSet.SlipPrtKind );
            // --- ADD m.suzuki 2010/10/12 ----------<<<<<
			// �`�[����ݒ�p���[ID
			dr[SLIPPRTSETPAPERID_TITLE] = slipOutputSet.SlipPrtSetPaperId;
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // �`�[����ݒ�p���[ID�i�\���p�j
            if ( slipOutputSet.SlipPrtKind == 99 )
            {
                // ��ʒ��[
                dr[SLIPPRTSETPAPERID_DISP_TITLE] = string.Empty;
            }
            else
            {
                // �`�[�E������
                dr[SLIPPRTSETPAPERID_DISP_TITLE] = slipOutputSet.SlipPrtSetPaperId;
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<

			// �v�����^�Ǘ�No
			dr[PRINTERMNGNO_TITLE] = slipOutputSet.PrinterMngNo;
			
			//----------�\���p����----------//
			// �`�[�����ʖ��́i�O���b�h�\���p�j
			dr[SLIPPRTKINDNM_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSet.SlipPrtKind, SlipOutputSet._slipPrtKindList);
			// �`�[�R�����g�i�`�[����ݒ�p���[���́j
			string wkStr = GetSlipComment(slipOutputSet.DataInputSystem, slipOutputSet.SlipPrtKind, slipOutputSet.SlipPrtSetPaperId);
			dr[SLIPCOMMENT_TITLE] = wkStr;
			
			// �v�����^��
			dr[PRINTERNAME_TITLE] = GetPrinterName(slipOutputSet.PrinterMngNo);
			// �v�����^�|�[�g�i�p�X�j
			dr[PRINTERPORT_TITLE] = GetPrinterPort(slipOutputSet.PrinterMngNo);
			
			// �폜��
			if (slipOutputSet.LogicalDeleteCode == 0)
			{
				dr[DELETE_DATE_TITLE] = "";
			}
			else
			{
				dr[DELETE_DATE_TITLE] = slipOutputSet.UpdateDateTimeJpInFormal;
			}

			return dr;
		}

		#endregion

        // --- ADD 2009/03/30 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Renewal(string enterpriseCode)
        {
            ArrayList retList;
            DataSet retDataSet;
            int totalCount;
            bool nextData;
            string msg;

            int status = SearchProc(out retList, out retDataSet, out totalCount, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, out msg);

            return status;
        }
        // --- ADD 2009/03/30 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

		#region SearchProc �����������C���i�_���폜�܂ށj
		/// <summary>
		/// �����������C���i�_���폜�܂ށj
		/// </summary>
		/// <param name="retArrayList">�Ǎ����ʃR���N�V����(ArrayList)</param>
		/// <param name="retList">�Ǎ����ʃR���N�V����(DataSet)</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����������s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		private int SearchProc(	  out ArrayList retArrayList
								, out DataSet retList
								, out int retTotalCnt
								, out bool nextData
								, string enterpriseCode
                                //, string sectionCode          // DEL 2008/06/20
								, ConstantManagement.LogicalMode logicalMode
								, out string message)
		{

			int status = 0;
			retList = null;
			retTotalCnt = 0;
			nextData = false;
			message = "";
			
			retArrayList = new ArrayList();
			
			//------------------------------
			// �R���{�{�b�N�X�f�[�^������
			//------------------------------
			//----- h.ueno add---------- start 2007.12.19
            SlipOutputSet._dataInputSystemComboList = new SortedList();
			//----- h.ueno add---------- end   2007.12.19
			SlipOutputSet._slipPrtSetPaperIdList = new SortedList();
			SlipOutputSet._printerMngNoList = new SortedList();

			//============================
			// �`�[����ݒ�}�X�^�ǂݍ���
			//============================
			// �`�[����ݒ�p���[ID�S�擾
			ArrayList slipPrtRetList = null;

			//----- ueno add ---------- start 2008.01.31
			// �`�[����ݒ�p���[�J���t���O�ݒ�
			this._slipPrtSetAcs.IsLocalDBRead = _isLocalDBRead;
			//----- ueno add ---------- end 2008.01.31

			status = this._slipPrtSetAcs.SearchSlipPrtSet(out slipPrtRetList, enterpriseCode);
			
			if ((status == 0) && (slipPrtRetList.Count > 0))
			{
				string key = "";

				//----- h.ueno add---------- start 2007.12.19
				int wkDataInputSystem = -999;		// �f�[�^���̓V�X�e���i�_�~�[�ݒ�j
				string wkDataInputSystemNm = "";	// �f�[�^���̓V�X�e������
				//----- h.ueno add---------- end   2007.12.19

				foreach (SlipPrtSet slipPrtSet in (ArrayList)slipPrtRetList)
				{
					//----- h.ueno add---------- start 2007.12.19
					//------------------------------------------
					// �f�[�^���̓V�X�e�����R���{�{�b�N�X�ɐݒ�
					//------------------------------------------
					// ���O�̃f�[�^�ƈقȂ��Ă�����ݒ肷��
					if (wkDataInputSystem != slipPrtSet.DataInputSystem)
					{
						// �f�[�^���̓V�X�e�����̎擾
						wkDataInputSystemNm = SlipOutputSet.GetSortedListNm(slipPrtSet.DataInputSystem, SlipOutputSet._dataInputSystemList);
						
						SlipOutputSet._dataInputSystemComboList.Add(slipPrtSet.DataInputSystem, wkDataInputSystemNm);
						
						// ���݂̃f�[�^��ۑ�
						wkDataInputSystem = slipPrtSet.DataInputSystem;
					}
					//----- h.ueno add---------- end   2007.12.19

					//--------------------------------------------------------------------
					// Key  �F�t�@�C�����C�A�E�g�̃L�[���ڂ���������
					//   �ް����ͼ���(2��)�{�`�[������(4��)�{�`�[����ݒ�p���[ID(24��)
					// Value�F�`�[����ݒ�}�X�^�N���X
					//--------------------------------------------------------------------
					this._stringBuilder.Remove(0, this._stringBuilder.Length);
					this._stringBuilder.Append(slipPrtSet.DataInputSystem.ToString("d2"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtKind.ToString("d4"));
					this._stringBuilder.Append(slipPrtSet.SlipPrtSetPaperId.TrimEnd());
					key = this._stringBuilder.ToString();
					
					SlipOutputSet._slipPrtSetPaperIdList.Add(key, slipPrtSet);
				}
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
            status = 0;
            ArrayList dmdPrtPtnList = null;
            status = this._dmdPrtPtnAcs.Search(out dmdPrtPtnList, enterpriseCode);

            if ((status == 0) && (dmdPrtPtnList.Count > 0))
            {
                string key = "";

                //int wkDataInputSystem = -999;		// �f�[�^���̓V�X�e���i�_�~�[�ݒ�j
                //string wkDataInputSystemNm = "";	// �f�[�^���̓V�X�e������

                foreach (DmdPrtPtn dmdPrtPtn in (ArrayList)dmdPrtPtnList)
                {
                    #region [2008/12/08 G.Miyatsu DEL]
                    //>>>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu DEL
                    ////------------------------------------------
                    //// �f�[�^���̓V�X�e�����R���{�{�b�N�X�ɐݒ�
                    ////------------------------------------------
                    //// ���O�̃f�[�^�ƈقȂ��Ă�����ݒ肷��
                    //if (wkDataInputSystem != dmdPrtPtn.DataInputSystem)
                    //{
                    //    //// �f�[�^���̓V�X�e�����̎擾
                    //    //wkDataInputSystemNm = SlipOutputSet.GetSortedListNm(slipPrtSet.DataInputSystem, SlipOutputSet._dataInputSystemList);

                    //    //DmdPrtPtnAcs._dataInputSystemComboList.Add(slipPrtSet.DataInputSystem, wkDataInputSystemNm);

                    //    // ���݂̃f�[�^��ۑ�
                    //    //wkDataInputSystem = slipPrtSet.DataInputSystem;
                    //}
                    #endregion

                    //--------------------------------------------------------------------
                    // Key  �F�t�@�C�����C�A�E�g�̃L�[���ڂ���������
                    //   �ް����ͼ���(2��)�{�`�[������(4��)�{�`�[����ݒ�p���[ID(24��)
                    // Value�F�`�[����ݒ�}�X�^�N���X
                    //--------------------------------------------------------------------
                    this._stringBuilder.Remove(0, this._stringBuilder.Length);
                    this._stringBuilder.Append(dmdPrtPtn.DataInputSystem.ToString("d2"));
                    this._stringBuilder.Append(dmdPrtPtn.SlipPrtKind.ToString("d4"));
                    this._stringBuilder.Append(dmdPrtPtn.SlipPrtSetPaperId.TrimEnd());
                    key = this._stringBuilder.ToString();

                    //�g�p����l�݈̂ڂ��āAdmdPrtPtn��SlipPrtSet�ɕϊ�����B
                    SlipPrtSet slipPrtSet = new SlipPrtSet();
                    slipPrtSet.DataInputSystem = dmdPrtPtn.DataInputSystem;
                    slipPrtSet.SlipPrtKind = dmdPrtPtn.SlipPrtKind;
                    slipPrtSet.SlipPrtSetPaperId = dmdPrtPtn.SlipPrtSetPaperId;
                    slipPrtSet.SlipComment = dmdPrtPtn.SlipComment;

                    SlipOutputSet._slipPrtSetPaperIdList.Add(key, slipPrtSet);
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD
            #endregion
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            // �o�͐ݒ�}�X�^���Q�Ɓi���[�̈ꗗ���擾�j
            status = 0;
            ArrayList outputSetList = null;
            status = this._outputSetAcs.SearchAllOutputSet( out outputSetList, enterpriseCode );

            if ( (status == 0) && (outputSetList.Count > 0) )
            {
                string key = string.Empty;

                // �f�B�N�V���i����������
                if ( _outputSetDic == null )
                {
                    _outputSetDic = new Dictionary<string, string>();
                }
                else
                {
                    _outputSetDic.Clear();
                }

                // ���o���ʁ˃f�B�N�V���i��
                # region [outputSetList��Dictionary]
                // <Key:PGID,Value:���[��>�̃f�B�N�V���i���𐶐�
                foreach ( OutputSet outputSet in (ArrayList)outputSetList )
                {
                    // �_���폜���͏��O
                    if ( outputSet.LogicalDeleteCode != 0 ) continue;
                    // �e�L�X�g�o�͕��͏��O�i�I�����敪 0:���[,1:�e�L�X�g�o�́j
                    if ( outputSet.SelectInfoCode != 0 ) continue;

                    string dicKey = outputSet.PgId.Trim();
                    if ( !_outputSetDic.ContainsKey( dicKey ) )
                    {
                        // �f�B�N�V���i���ɒǉ�
                        _outputSetDic.Add( dicKey, outputSet.DisplayName.Trim() );
                    }
                    else
                    {
                        // �f�B�N�V���i������
                        _outputSetDic[dicKey] = AppendToDisplayName( _outputSetDic[dicKey], outputSet.DisplayName.Trim() );
                    }
                }
                # endregion

                // �f�B�N�V���i���˃f�[�^�r���[
                # region [Dictionary��DataView]
                // �f�B�N�V���i���˃f�[�^�e�[�u��(�\�[�g�p)
                DataTable table = CreateTable();
                foreach ( string dicKey in _outputSetDic.Keys )
                {
                    table.Rows.Add( CreateTableRow( table, dicKey, _outputSetDic[dicKey] ) );
                }
                // �f�[�^�r���[����(���O��sort)
                DataView view = new DataView( table );
                view.Sort = string.Format( "{0}", ct_col_Name );
                # endregion

                // �f�[�^�r���[�˕\���p�̃��X�g��
                # region [DataView��_slipPrtSetPaperIdList]
                int sortIndex = 0;
                foreach( DataRowView rowView in view )
                {
                    //�g�p����l�݈̂ڂ��āASlipPrtSet�𐶐�����B
                    SlipPrtSet slipPrtSet = new SlipPrtSet();
                    slipPrtSet.DataInputSystem = 0; // 0:����
                    slipPrtSet.SlipPrtKind = 99; // 99:���[
                    slipPrtSet.SlipPrtSetPaperId = (string)rowView[ct_col_Pgid]; // PGID
                    slipPrtSet.SlipComment = (string)rowView[ct_col_Name]; // ���[��

                    //KEY�����񐶐��isortIndex����ӂɂ��鎖�ŋ����I�Ƀ\�[�g����j
                    this._stringBuilder.Remove( 0, this._stringBuilder.Length );
                    this._stringBuilder.Append( slipPrtSet.DataInputSystem.ToString( "d2" ) );
                    this._stringBuilder.Append( slipPrtSet.SlipPrtKind.ToString( "d4" ) );
                    this._stringBuilder.Append( sortIndex.ToString( "d5" ) );
                    this._stringBuilder.Append( slipPrtSet.SlipPrtSetPaperId.TrimEnd() );
                    key = this._stringBuilder.ToString();

                    //���X�g�ɒǉ�
                    SlipOutputSet._slipPrtSetPaperIdList.Add( key, slipPrtSet );
                    sortIndex++;
                }
                # endregion
            }
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
            

            //============================
			// �v�����^�Ǘ��}�X�^�ǂݍ���
			//============================
			// �v�����^�Ǘ�No�S�擾
			ArrayList prtManageRetList = null;
			status = this._prtManageAcs.Search(out prtManageRetList, enterpriseCode);

			if ((status == 0) && (prtManageRetList.Count > 0))
			{
				foreach (PrtManage prtManage in (ArrayList)prtManageRetList)
				{
					//---------------------------------
					// Key  �F�v�����^�Ǘ�No
					// Value�F�v�����^�Ǘ��}�X�^�N���X
					//---------------------------------
					SlipOutputSet._printerMngNoList.Add(prtManage.PrinterMngNo, prtManage);
				}
			}
			
            //--- DEL 2008/06/20 ---------->>>>>
            ////==========================================
            //// ���_�}�X�^�ǂݍ���
            ////==========================================
            //// ���_���X�g������
            //SlipOutputSet._sectionCodeList = new SortedList();

            ////----- ueno add ---------- start 2008.01.31
            //// ���[�J���c�a���_�Ή�
            //ConstructSecInfoAcs();
            ////----- ueno add ---------- end 2008.01.31

            //if (this._secInfoAcs.SecInfoSetList.Length > 0)
            //{
            //    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //    {
            //        // ���_�R�[�h�Ɩ��̂�ۑ�	
            //        SlipOutputSet._sectionCodeList.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
            //    }
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            //--- DEL 2008/06/20 ----------<<<<<

            //--- ADD 2008/06/20 ---------->>>>>
            //==========================================
            // �q�Ƀ}�X�^�ǂݍ���
            //==========================================
            SlipOutputSet._warehouseCodeList = new SortedList();
            ArrayList warehouseCodeList = null;
            status = this._warehouseAcs.Search(out warehouseCodeList, enterpriseCode);

            if ((status == 0) && (warehouseCodeList.Count > 0))
            {
                foreach (Warehouse warehouse in (ArrayList)warehouseCodeList)
                {
                    //---------------------------------
                    // Key  �F�q�ɃR�[�h
                    // Value�F�q�ɖ���
                    //---------------------------------
                    SlipOutputSet._warehouseCodeList.Add(warehouse.WarehouseCode, warehouse.WarehouseName);
                }
            }
            //--- ADD 2008/06/20 ----------<<<<<

			//==========================================
			// �[���ʓ`�[�o�͐ݒ�}�X�^�ǂݍ���
			//==========================================
			// ���o�����p�����[�^
			SearchSlipOutputSetParaWork paraWork = new SearchSlipOutputSetParaWork();
			
			paraWork.EnterpriseCode = enterpriseCode;

			//----- h.ueno add---------- start 2007.12.19
			// ���l�^�̍��ڂ́u0�v�f�[�^���l�����A�S�����Ώێ��́u-1�v�Ƃ���
			paraWork.CashRegisterNo = -1;	// ���W�ԍ�
			paraWork.DataInputSystem = -1;	// �f�[�^���̓V�X�e��
			paraWork.SlipPrtKind = -1;		// �`�[������
			//----- h.ueno add---------- end   2007.12.19
			
			ArrayList paraList = new ArrayList();
			paraList.Add(paraWork);

			// �����[�g�߂胊�X�g
			object slipOutputSetWorkList = null;

			//----- ueno upd ---------- start 2008.01.31
			// ���[�J��
			if (_isLocalDBRead)
			{
				List<SlipOutputSetWork> wkSlipOutputSetWorkList = new List<SlipOutputSetWork>();
				status = this._slipOutputSetLcDB.Search(out wkSlipOutputSetWorkList, paraWork, 0, logicalMode);
				
				if(status == 0)
				{
					ArrayList al = new ArrayList();
					al.AddRange(wkSlipOutputSetWorkList);
					slipOutputSetWorkList = (object)al;
				}
			}
			// �����[�g
			else
			{
				// �[���ʓ`�[�o�͐ݒ�}�X�^����
				status = this._iSlipOutputSetDB.Search(out slipOutputSetWorkList, paraList, 0, logicalMode);
			}
			//----- ueno upd ---------- end 2008.01.31

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �f�[�^�e�[�u���ɃZ�b�g
				foreach (SlipOutputSetWork slipOutputSetWork in (ArrayList)slipOutputSetWorkList)
				{
					// �f�[�^�e�[�u���֊i�[
					AddRowFromSlipOutputSetWork(slipOutputSetWork);

					// ArrayList�֊i�[
					retArrayList.Add(CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork));
				}
			}

			//==========================================
			// �[���Ǘ��}�X�^�ǂݍ���
			//==========================================
            PosTerminalMg posTerminalMg = null;
            // 2010/06/29 Add >>>
            ArrayList posTerminalMgList = new ArrayList();
            if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)
                    status = this._posTerminalMgAcs.SearchServer(out posTerminalMgList, enterpriseCode);
                else
                    status = this._posTerminalMgAcs.Search(out posTerminalMg, enterpriseCode);
            }
            else
                // 2010/06/29 Add <<<
                status = this._posTerminalMgAcs.Search(out posTerminalMg, enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�e�[�u���ɃZ�b�g
                // 2010/06/29 Add >>>
                if (LoginInfoAcquisition.Employee.UserAdminFlag == 1)
                {
                    if (_scmFlg == true)
                    {
                        foreach (PosTerminalMg posTerminal in posTerminalMgList)
                        {
                            AddRowFromPosTerminalMg(posTerminal);
                        }
                    }
                    else
                        AddRowFromPosTerminalMg(posTerminalMg);
                }
                else
                    // 2010/06/29 Add <<<
                    AddRowFromPosTerminalMg(posTerminalMg);
            }

            // 2010/06/29 Add >>>
            // �[���ԍ����ɕ��ёւ�
            DataTable dt = new DataTable();
            dt = this._dataTableList.Tables[MAIN_TABLE].Clone();
            DataView dv = new DataView(_dataTableList.Tables[MAIN_TABLE]);
            dv.Sort = CASHREGISTERNO_TITLE;
            foreach (DataRowView drv in dv)
            {
                dt.ImportRow(drv.Row);
            }
            this._dataTableList.Tables[MAIN_TABLE].Clear();
            dv = new DataView(dt);
            foreach (DataRowView drv in dv)
            {
                this._dataTableList.Tables[MAIN_TABLE].ImportRow(drv.Row);
            }
            // 2010/06/29 Add <<<

			//==========================================
			// �f�[�^�Z�b�g��Ԃ�
			//==========================================
			retList = this._dataTableList;

			return status;
		}

        // --- ADD m.suzuki 2010/09/27 ---------->>>>>
        /// <summary>
        /// ���[�^�C�g���̘A������
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private string AppendToDisplayName( string currentText, string appendText )
        {
            // ���[�^�C�g���̍ő咷
            const int maxLength = 20;


            if ( currentText.Length < maxLength || currentText[currentText.Length - 1] != '�c' )
            {
                // �����e�ŘA���ς݂��`�F�b�N
                string[] currentTextSub = currentText.Split( ',' );
                foreach ( string sub in currentTextSub )
                {
                    if ( sub.Trim() == appendText.Trim() )
                    {
                        // �Y������������I��
                        return currentText;
                    }
                }

                // �J���}��؂�ŘA��
                currentText += "," + appendText;
            }
            else 
            {
                // ���ɍő咷�ŃJ�b�g�ς݂Ȃ�΁A����ȏ�͘A�������ɂ��̂܂ܕԂ��B
                return currentText;
            }


            // �ő咷�ŃJ�b�g
            if ( currentText.Length > maxLength )
            {
                // �ő咷-1�ŃJ�b�g
                currentText = currentText.Substring( 0, maxLength - 1 );

                // �ŏI������"�c"�ɂ���
                currentText += "�c";
            }

            return currentText;
        }
        /// <summary>
        /// �\�[�g�p�f�[�^�e�[�u������
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add( new DataColumn( ct_col_Pgid, typeof( string ) ) );
            table.Columns.Add( new DataColumn( ct_col_Name, typeof( string ) ) );
            return table;
        }
        /// <summary>
        /// �\�[�g�p�f�[�^�e�[�u���s����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private DataRow CreateTableRow( DataTable table, string key, string value )
        {
            DataRow row = table.NewRow();
            row[ct_col_Pgid] = key;
            row[ct_col_Name] = value;
            return row;
        }
        // --- ADD m.suzuki 2010/09/27 ----------<<<<<
		#endregion

		/// <summary>
		/// �[���ʓ`�[�o�͐ݒ�}�X�^�@���@�f�[�^�e�[�u���@�ǉ�����
		/// </summary>
		/// <param name="slipOutputSetWork">�[���ʓ`�[�o�͐ݒ胏�[�N�N���X</param>
		private void AddRowFromSlipOutputSetWork(SlipOutputSetWork slipOutputSetWork)
		{
			DataRow dr;

			try
			{
                //--- DEL 2008/06/20 ---------->>>>>
                // ��P�O���b�h�i�[���ԍ��j
                //if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { slipOutputSetWork.SectionCode, slipOutputSetWork.CashRegisterNo }) == null)
                //{
                //    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                //    dr[SECTIONCODE_TITLE] = slipOutputSetWork.SectionCode;
                //    dr[SECTIONNAME_TITLE] = SlipOutputSet.GetSortedListNm(slipOutputSetWork.SectionCode, SlipOutputSet._sectionCodeList);
                //    dr[CASHREGISTERNO_TITLE] = slipOutputSetWork.CashRegisterNo;
					
                //    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                //}
                //--- DEL 2008/06/20 ----------<<<<<

                //--- ADD 2008/06/20 ---------->>>>>
                // ��P�O���b�h�i�[���ԍ��j
                if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { slipOutputSetWork.CashRegisterNo }) == null)
                {
                    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                    dr[CASHREGISTERNO_TITLE] = slipOutputSetWork.CashRegisterNo;

                    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                }
                //--- ADD 2008/06/20 ----------<<<<<

				// ��Q�O���b�h�i�`�[����j
				if (this._dataTableList.Tables[SECOND_TABLE].Rows.Find(new object[] {	//slipOutputSetWork.SectionCode,        // DEL 2008/06/20
																						slipOutputSetWork.CashRegisterNo,
                                                                                        //--- ADD 2008/06/20 ---------->>>>>
                                                                                        slipOutputSetWork.WarehouseCode,
                                                                                        //--- ADD 2008/06/20 ----------<<<<<
																						//----- h.ueno add---------- start 2007.12.19
																						slipOutputSetWork.DataInputSystem,
																						//----- h.ueno add---------- end   2007.12.19
																						slipOutputSetWork.SlipPrtKind,
																						slipOutputSetWork.SlipPrtSetPaperId }) == null)
				{
					dr = CopyToDataRowFromSlipOutputSetWork(ref slipOutputSetWork);
					this._dataTableList.Tables[SECOND_TABLE].Rows.Add(dr);
				}
			}
			catch (Exception ex)
			{
                string err = ex.Message;
			}
		}

		/// <summary>
		/// �[���Ǘ��}�X�^�@���@�f�[�^�e�[�u���@�ǉ�����
		/// </summary>
		/// <param name="posTerminalMg">�[���Ǘ��N���X</param>
		private void AddRowFromPosTerminalMg(PosTerminalMg posTerminalMg)
		{
			DataRow dr;

			try
			{
                //--- DEL 2008/06/19 ----------->>>>>
                //// ��P�O���b�h�i�[���ԍ��j
                //if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { posTerminalMg.SectionCode, posTerminalMg.CashRegisterNo }) == null)
                //{
                //    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                //    dr[SECTIONCODE_TITLE] = posTerminalMg.SectionCode;
                //    dr[SECTIONNAME_TITLE] = SlipOutputSet.GetSortedListNm(posTerminalMg.SectionCode, SlipOutputSet._sectionCodeList);
                //    dr[CASHREGISTERNO_TITLE] = posTerminalMg.CashRegisterNo;

                //    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                //}
                //--- DEL 2008/06/19 -----------<<<<<

                //--- ADD 2008/06/19 ----------->>>>>
                // ��P�O���b�h�i�[���ԍ��j
                if (this._dataTableList.Tables[MAIN_TABLE].Rows.Find(new object[] { posTerminalMg.CashRegisterNo }) == null)
                {
                    dr = this._dataTableList.Tables[MAIN_TABLE].NewRow();
                    dr[CASHREGISTERNO_TITLE] = posTerminalMg.CashRegisterNo;

                    this._dataTableList.Tables[MAIN_TABLE].Rows.Add(dr);
                }
                //--- ADD 2008/06/19 -----------<<<<<
			}
			catch
			{
			}
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ���[�J���c�a�Ή����_���N���X�쐬����
		/// </summary>
		/// <returns>Boolean</returns>
		/// <remarks>
		/// <br>Note       : ���_���N���X�쐬�𖢍쐬���ɍ쐬���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		private Boolean ConstructSecInfoAcs()
		{
			if (this._secInfoAcs == null)
			{
				this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
				if (this._secInfoAcs != null)
				{
					return true;
				}
			}
			return false;
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �[���ʓ`�[�o�͐�ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="slipOutputSet">�[���ʓ`�[�o�͐�ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="dataInputSystem">�f�[�^���̓V�X�e��</param>		
		/// <param name="slipPrtKind">�`�[������</param>
		/// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �[���ʓ`�[�o�͐�ݒ����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
		public int Read(out SlipOutputSet slipOutputSet,
						string enterpriseCode,
                        //string sectionCode,        // DEL 2008/06/20
						Int32 cashRegisterNo,
                        //--- ADD 2008/06/19 ---------->>>>>
                        string warehouseCode,
                        //--- ADD 2008/06/19 ----------<<<<<
                        //----- h.ueno add---------- start 2007.12.19
						Int32 dataInputSystem,
						//----- h.ueno add---------- start 2007.12.19
						Int32 slipPrtKind,
						string slipPrtSetPaperId)
		{			
			try
			{
				int status = 0;
				slipOutputSet = null;
				SlipOutputSetWork slipOutputSetWork = new SlipOutputSetWork();
				
				// �L�[���ڐݒ�
				slipOutputSetWork.EnterpriseCode	= enterpriseCode;
                //slipOutputSetWork.SectionCode		= sectionCode;      // DEL 2008/06/20
				slipOutputSetWork.CashRegisterNo	= cashRegisterNo;
                //--- ADD 2008/06/20 ---------->>>>>
                slipOutputSetWork.WarehouseCode     = warehouseCode;
                //--- ADD 2008/06/20 ----------<<<<<
				//----- h.ueno add---------- start 2007.12.19
				slipOutputSetWork.DataInputSystem	= dataInputSystem;
				//----- h.ueno add---------- start 2007.12.19
				slipOutputSetWork.SlipPrtKind		= slipPrtKind;
				slipOutputSetWork.SlipPrtSetPaperId = slipPrtSetPaperId;

				//----- ueno upd ---------- start 2008.01.31
				if (_isLocalDBRead)
				{
					status = this._slipOutputSetLcDB.Read(ref slipOutputSetWork, 0);
				}
				else
				{
					// XML�֕ϊ����A������̃o�C�i����
					byte[] parabyte = XmlByteSerializer.Serialize(slipOutputSetWork);

					// �[���ʓ`�[�o�͐�ݒ�ǂݍ���
					status = this._iSlipOutputSetDB.Read(ref parabyte, 0);

					if (status == 0)
					{
						// XML�̓ǂݍ���
						slipOutputSetWork = (SlipOutputSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipOutputSetWork));

						// �N���X�������o�R�s�[
						//slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);
					}
				}

				if (status == 0)
				{
					// �N���X�������o�R�s�[
					slipOutputSet = CopyToSlipOutputSetFromSlipOutputSetWork(slipOutputSetWork);
				}
				//----- ueno upd ---------- end 2008.01.31

				return status;
			}
			catch (Exception)
			{
				//�ʐM�G���[��-1��߂�
				slipOutputSet = null;
				//�I�t���C������null���Z�b�g
				this._iSlipOutputSetDB = null;
				return -1;
			}
		}

		#region �e��ϊ�
		/// <summary>
		/// NULL�����ϊ�����
		/// </summary>
		/// <param name="obj">�I�u�W�F�N�g</param>
		/// <returns>string�^�f�[�^</returns>
		/// <remarks>
		/// <br>Note       : NULL�������܂܂�Ă���ꍇ�_�u���N�H�[�g�֕ϊ�����</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.12.10</br>
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
		/// <br>Date       : 2007.12.10</br>
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
		#endregion
	}
}
