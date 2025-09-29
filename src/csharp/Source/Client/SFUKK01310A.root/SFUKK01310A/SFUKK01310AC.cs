using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ����KINGET�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���Ӑ搿�����z���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 18023 ����@����</br>
	/// <br>Date		: 2005.07.21</br>
	/// <br>Update Note	: 2006.03.13 ����@����
	///						�E��O�ʉ߃v���p�e�B��ǉ��B</br>
	/// <br>Update Note	: 2006.09.06 ����@����
	///						�E���Ӑ敪�̓R�[�h�ɂ�钊�o��ǉ��B</br>
	/// <br></br>
	/// </remarks>
	public class KingetCustDmdPrcAcs
	{
		# region Constructor
		/// <summary>
		/// ����KINGET�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����KINGET�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public KingetCustDmdPrcAcs()
		{
			// 2006.03.13 ADD START ����@����
			this._throughException = false;
			// 2006.03.13 ADD END ����@����

			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iSeiKingetDB = (ISeiKingetDB)MediationSeiKingetDB.GetSeiKingetDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iSeiKingetDB = null;
			}
		}
		# endregion

		#region Private Members
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ISeiKingetDB _iSeiKingetDB = null;
		// 2006.03.13 ADD START ����@����
		/// <summary>��O�ʉ�</summary>
		/// <remarks>true:�N���X���ŗ�O���擾�����A���̂܂ܒʉ߂��܂�,false:�N���X���ŗ�O���擾���܂�</remarks>
		private bool _throughException = false;
		// 2006.03.13 ADD END ����@����
		#endregion
		
		#region Private Const
		private const string ALLSECCODE				= "000000";	// �S���_�R�[�h
		private const int MAXCOUNT_CORPORATEDIVCODE	= 6;		// �l�E�@�l�敪 �ő匏��
		#endregion
		
		#region Properties
		// 2006.03.13 ADD START ����@����
		/// <summary>��O�ʉ� �v���p�e�B</summary>
		/// <value>true:�N���X���ŗ�O���擾�����A���̂܂ܒʉ߂��܂�,false:�N���X���ŗ�O���擾���܂�</value>
		/// <remarks>
		/// <br>Note       : �N���X����O���擾���邩���Ȃ�����ݒ肵�܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2006.03.13</br>
		/// </remarks>
		public bool ThroughException
		{
			get{return this._throughException;}
			set{this._throughException = value;}
		}
		// 2006.03.13 ADD END ����@����
		#endregion

		#region Public Members
		/// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSeiKingetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// KINGET�p���Ӑ搿�����z���ǂݍ��ݏ����i���t�w��j
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="readDate">�w����t(YYYYMMDD)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���t���v����t���Z�o����KINGET�p���Ӑ搿�����z�����擾���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int Read(out KingetCustDmdPrcWork kingetCustDmdPrcWork, string enterpriseCode,
			string addUpSecCode, int customerCode, int readDate)
		{
			return this.ReadDB(out kingetCustDmdPrcWork, enterpriseCode, addUpSecCode, customerCode, readDate);
		}
		
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍������i���Ӑ挳���p�j
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="dmdSalesWorkTable">����������e�[�u��(HashTable[�v����t]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">�������e�[�u��(HashTable[�v����t]->ArrayList)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�󔒂̏ꍇ�͑S�В��o)</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startAddUpYearMonth">�v��N���i�J�n�j(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">�v��N���i�I���j(YYYYMM)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int Search(out ArrayList kingetCustDmdPrcList, out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable,
			string enterpriseCode, string addUpSecCode, int customerCode, int startAddUpYearMonth, int endAddUpYearMonth)
		{
			SeiKingetParameter parameter = new SeiKingetParameter();
			parameter.EnterpriseCode		= enterpriseCode;
			parameter.IsSelectAllSection	= false;
			if (addUpSecCode == "")
			{
				parameter.IsSelectAllSection	= true;
			}
			else
			{
				parameter.AddUpSecCodeList.Add(addUpSecCode);
			}
			parameter.StartCustomerCode	= customerCode;
			parameter.EndCustomerCode		= customerCode;
			parameter.TotalDay				= 0;
			parameter.StartTotalDay		= 0;
			parameter.EndTotalDay			= 0;
			parameter.StartAddUpDate		= DateTime.MinValue;
			parameter.EndAddUpDate			= DateTime.MinValue;
			parameter.StartAddUpYearMonth	= startAddUpYearMonth;
			parameter.EndAddUpYearMonth	= endAddUpYearMonth;
			parameter.IsOutputZeroBlance	= true;
			parameter.IsOutputAllSecRec	= true;
			parameter.StartKana			= "";
			parameter.EndKana				= "";
			parameter.IsAllCorporateDivCode= true;
			parameter.IsJudgeBillOutputCode= false;
			parameter.EmployeeKind			= 0;
			parameter.StartEmployeeCode	= "";
			parameter.EndEmployeeCode		= "";
				
			return this.SearchDB(out kingetCustDmdPrcList, out dmdSalesWorkTable, out depsitMainWorkTable, parameter);
		}
		
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍������i�����ꊇ����p�j
		/// </summary>
		/// <param name="kingetCustDmdPrcTable">KINGET�p���Ӑ搿�����z���e�[�u��(HashTable[���Ӑ�R�[�h]->ArrayList)</param>
		/// <param name="dmdSalesWorkTable">����������e�[�u��(HashTable[������R�[�h]->HashTable[�v����t]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">�������e�[�u��(HashTable[���Ӑ�R�[�h]->HashTable[�v����t]->ArrayList)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h(�󔒂̏ꍇ�͑S�В��o)</param>
		/// <param name="startAddUpYearMonth">�v��N���i�J�n�j(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">�v��N���i�I���j(YYYYMM)</param>
		/// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
		/// <param name="startKana">���Ӑ�J�i(�J�n)</param>
		/// <param name="endKana">���Ӑ�J�i(�I��)</param>
		/// <param name="corporateDivCodeList">�l�E�@�l�敪���X�g</param>
		/// <param name="isOutputZeroBlance">�c���O�o��</param>
		/// <param name="isJudgeBillOutputCode">�������o�͋敪���f(true:�������o�͋敪�����������ɓ����,false:�������o�͋敪�����������ɓ���Ȃ�)</param>
		/// <param name="employeeKind">�]�ƈ��敪(0:���Ӑ�,1:�W��)</param>
		/// <param name="startEmployeeCode">�]�ƈ��R�[�h(�J�n)</param>
		/// <param name="endEmployeeCode">�]�ƈ��R�[�h(�I��)</param>
		/// <param name="startCustAnalysCodes">�J�n���Ӑ敪�̓R�[�h�z��(1�`6)</param>
		/// <param name="endCustAnalysCodes">�I�����Ӑ敪�̓R�[�h�z��(1�`6)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int SearchMotoAll(out Hashtable kingetCustDmdPrcTable,out Hashtable dmdSalesWorkTable,out Hashtable depsitMainWorkTable,
			string enterpriseCode,string addUpSecCode,int startAddUpYearMonth,int endAddUpYearMonth,int startCustomerCode,int endCustomerCode,
			string startKana,string endKana,ArrayList corporateDivCodeList,bool isOutputZeroBlance,bool isJudgeBillOutputCode,int employeeKind,
			string startEmployeeCode, string endEmployeeCode, int[] startCustAnalysCodes, int[] endCustAnalysCodes)
		{
			SeiKingetParameter parameter = new SeiKingetParameter();
			parameter.EnterpriseCode		= enterpriseCode;
			parameter.IsSelectAllSection	= false;
			parameter.IsOutputAllSecRec	= false;
			if (addUpSecCode == "")
			{
				parameter.IsSelectAllSection	= true;
				parameter.IsOutputAllSecRec	= true;
			}
			else
			if (addUpSecCode == ALLSECCODE)
			{
				parameter.IsOutputAllSecRec	= true;
				parameter.AddUpSecCodeList.Add(addUpSecCode);
			}
			else
			{
				parameter.AddUpSecCodeList.Add(addUpSecCode);
			}
			parameter.StartCustomerCode	= startCustomerCode;
			parameter.EndCustomerCode		= endCustomerCode;
			parameter.TotalDay				= 0;
			parameter.StartTotalDay		= 0;
			parameter.EndTotalDay			= 0;
			parameter.StartAddUpDate		= DateTime.MinValue;
			parameter.EndAddUpDate			= DateTime.MinValue;
			parameter.StartAddUpYearMonth	= startAddUpYearMonth;
			parameter.EndAddUpYearMonth	= endAddUpYearMonth;
			parameter.IsOutputZeroBlance	= isOutputZeroBlance;
			parameter.StartKana			= startKana;
			parameter.EndKana				= endKana;
			parameter.IsAllCorporateDivCode= false;
			if (corporateDivCodeList != null)
			{
				// �S�l�E�@�l�敪
				if (corporateDivCodeList.Count == MAXCOUNT_CORPORATEDIVCODE)
				{
					parameter.IsAllCorporateDivCode = true;
					parameter.CorporateDivCodeList = (ArrayList)corporateDivCodeList.Clone();
				}
				else
				{
					parameter.CorporateDivCodeList = (ArrayList)corporateDivCodeList.Clone();
				}
			}
			parameter.IsJudgeBillOutputCode= isJudgeBillOutputCode;
			parameter.EmployeeKind			= employeeKind;
			parameter.StartEmployeeCode	= startEmployeeCode;
			parameter.EndEmployeeCode		= endEmployeeCode;

			// 2006.09.06 ADD START ����@����
			// ���o�����ݒ�i���Ӑ敪�̓R�[�h�j
			SetParameterForCustAnalysCodes(parameter, startCustAnalysCodes, endCustAnalysCodes);
			// 2006.09.06 ADD END ����@����

			return this.SearchMotoAllDB(out kingetCustDmdPrcTable, out dmdSalesWorkTable, out depsitMainWorkTable, parameter);
		}

		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍������i�����ꗗ�\�E���v�������p�j
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCodeList">�v�㋒�_�R�[�h���X�g(null�܂���Count=0�̏ꍇ�͑I�𖳂�)</param>
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI�� false:�e���_�I��)</param>
		/// <param name="isOutputAllSecRec">�S���_���R�[�h�o��(true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�)</param>
		/// <param name="startTotalDay">����(�J�n)(DD)</param>
		/// <param name="endTotalDay">����(�I��)(DD)</param>
		/// <param name="startAddUpDate">�v��N����(�J�n)(YYYYMMDD)</param>
		/// <param name="endAddUpDate">�v��N����(�I��)(YYYYMMDD)</param>
		/// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
		/// <param name="startKana">���Ӑ�J�i(�J�n)</param>
		/// <param name="endKana">���Ӑ�J�i(�I��)</param>
		/// <param name="corporateDivCodeList">�l�E�@�l�敪���X�g</param>
		/// <param name="isJudgeBillOutputCode">�������o�͋敪���f(true:�������o�͋敪�����������ɓ����,false:�������o�͋敪�����������ɓ���Ȃ�)</param>
		/// <param name="employeeKind">�]�ƈ��敪(0:���Ӑ�,1:�W��)</param>
		/// <param name="startEmployeeCode">�]�ƈ��R�[�h(�J�n)</param>
		/// <param name="endEmployeeCode">�]�ƈ��R�[�h(�I��)</param>
		/// <param name="startCustAnalysCodes">�J�n���Ӑ敪�̓R�[�h�z��(1�`6)</param>
		/// <param name="endCustAnalysCodes">�I�����Ӑ敪�̓R�[�h�z��(1�`6)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int Search(out ArrayList kingetCustDmdPrcList,string enterpriseCode,ArrayList addUpSecCodeList,bool isSelectAllSection,
			bool isOutputAllSecRec,int startTotalDay,int endTotalDay,int startAddUpDate,int endAddUpDate,int startCustomerCode,int endCustomerCode,
			string startKana,string endKana,ArrayList corporateDivCodeList,bool isJudgeBillOutputCode,int employeeKind,
			string startEmployeeCode, string endEmployeeCode, int[] startCustAnalysCodes, int[] endCustAnalysCodes)
		{
			SeiKingetParameter parameter = new SeiKingetParameter();
			parameter.EnterpriseCode		= enterpriseCode;
			parameter.IsSelectAllSection	= isSelectAllSection;
			if ((addUpSecCodeList != null) && (addUpSecCodeList.Count > 0))
			{
				parameter.AddUpSecCodeList = (ArrayList)addUpSecCodeList.Clone();
			}
			parameter.StartCustomerCode	= startCustomerCode;
			parameter.EndCustomerCode		= endCustomerCode;
			parameter.TotalDay				= 0;
			parameter.StartTotalDay		= startTotalDay;
			parameter.EndTotalDay			= endTotalDay;
			parameter.StartAddUpDate		= TDateTime.LongDateToDateTime("YYYYMMDD", startAddUpDate);
			parameter.EndAddUpDate			= TDateTime.LongDateToDateTime("YYYYMMDD", endAddUpDate);
			parameter.StartAddUpYearMonth	= 0;
			parameter.EndAddUpYearMonth	= 0;
			parameter.IsOutputZeroBlance	= false;
			parameter.IsOutputAllSecRec	= isOutputAllSecRec;
			parameter.StartKana			= startKana;
			parameter.EndKana				= endKana;
			parameter.IsAllCorporateDivCode= false;
			if (corporateDivCodeList != null)
			{
				// �S�l�E�@�l�敪
				if (corporateDivCodeList.Count == MAXCOUNT_CORPORATEDIVCODE)
				{
					parameter.IsAllCorporateDivCode = true;
				}
				else
				{
					parameter.CorporateDivCodeList = (ArrayList)corporateDivCodeList.Clone();
				}
			}
			parameter.IsJudgeBillOutputCode= isJudgeBillOutputCode;
			parameter.EmployeeKind			= employeeKind;
			parameter.StartEmployeeCode	= startEmployeeCode;
			parameter.EndEmployeeCode		= endEmployeeCode;
				
			// 2006.09.06 ADD START ����@����
			// ���o�����ݒ�i���Ӑ敪�̓R�[�h�j
			SetParameterForCustAnalysCodes(parameter, startCustAnalysCodes, endCustAnalysCodes);
			// 2006.09.06 ADD END ����@����

			return this.SearchDB(out kingetCustDmdPrcList, parameter);
		}
		
		/// <summary>
		/// ���׏�񌟍������i���א������p�j
		/// </summary>
		/// <param name="dmdSalesWorkTable">����������e�[�u��(HashTable[������R�[�h]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">�������e�[�u��(HashTable[���Ӑ�R�[�h]->ArrayList)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="seiKingetDetailParameterList">���׌����p�����[�^���X�g</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int SearchDetails(out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable, string enterpriseCode,
			ArrayList seiKingetDetailParameterList)
		{
			return this.SearchDetailDB(out dmdSalesWorkTable, out depsitMainWorkTable, enterpriseCode, seiKingetDetailParameterList);
		}
		#endregion

		# region Private Methods
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍������i���t�w��j
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="readDate">�w����t(YYYYMMDD)</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int ReadDB(out KingetCustDmdPrcWork kingetCustDmdPrcWork, string enterpriseCode, string addUpSecCode, int customerCode, int readDate)
		{
			kingetCustDmdPrcWork = null;
			
			try
			{
				object objKingetCustDmdPrc = null;
				
				// ����
				int status = this._iSeiKingetDB.Read(out objKingetCustDmdPrc, enterpriseCode, addUpSecCode, customerCode, readDate);
				if (status == 0)
				{
					if (objKingetCustDmdPrc != null)
					{
						kingetCustDmdPrcWork = (KingetCustDmdPrcWork)objKingetCustDmdPrc;
					}
				}
				
				return status;
			}
			catch (Exception e)
			{
				// 2006.03.13 ADD START ����@����
				if (this._throughException)	throw(e);
				// 2006.03.13 ADD END ����@����

				kingetCustDmdPrcWork = null;
				//�I�t���C������null���Z�b�g
				this._iSeiKingetDB = null;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return -1;
			}
		}
		
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍�����
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="parameter">KINSET�p���o�����N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchDB(out ArrayList kingetCustDmdPrcList, SeiKingetParameter parameter)
		{
			kingetCustDmdPrcList = null;
			
			try
			{
				object objKingetCustDmdPrc = null;
				
				// ����
				int status = this._iSeiKingetDB.Search(out objKingetCustDmdPrc, parameter);
				if (status == 0)
				{
					if (objKingetCustDmdPrc != null)
					{
						kingetCustDmdPrcList = objKingetCustDmdPrc as ArrayList;
					}
				}
				
				return status;
			}
			catch (Exception e)
			{
				kingetCustDmdPrcList = null;

				// 2006.03.13 ADD START ����@����
				if (this._throughException)	throw(e);
				// 2006.03.13 ADD END ����@����

				//�I�t���C������null���Z�b�g
				this._iSeiKingetDB = null;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return -1;
			}
		}
		
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍������i���Ӑ挳���p�j
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="dmdSalesWorkTable">����������e�[�u��(HashTable[������R�[�h]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">�������e�[�u��(HashTable[���Ӑ�R�[�h]->ArrayList)</param>
		/// <param name="parameter">KINSET�p���o�����N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchDB(out ArrayList kingetCustDmdPrcList, out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable, 
			SeiKingetParameter parameter)
		{
			kingetCustDmdPrcList = null;
			dmdSalesWorkTable = null;
			depsitMainWorkTable = null;

            // �� 20070518 18322 a
            kingetCustDmdPrcList = new ArrayList();
            dmdSalesWorkTable    = new Hashtable();
            depsitMainWorkTable  = new Hashtable();

            return 0;
            // �� 20070518 18322 a
			
            // �� 20070518 18322 d �g�p���Ă��Ȃ��̂ō폜
            #region �������͂ł͎g�p���Ȃ��̂ō폜
			//try
			//{
			//	object objKingetCustDmdPrc = null;
			//	object objDmdSalesWorkList = null;
			//	object objDepsitMainWorkList = null;
			//	
			//	// ����
			//	int status = this._iSeiKingetDB.Search(out objKingetCustDmdPrc, out objDmdSalesWorkList, out objDepsitMainWorkList, parameter);
			//	if (status == 0)
			//	{
			//		if (objKingetCustDmdPrc != null)
			//		{
			//			kingetCustDmdPrcList = objKingetCustDmdPrc as ArrayList;
			//			
			//			ArrayList dmdSalesWorkList = null;
			//			ArrayList depsitMainWorkList = null;
			//			
			//			if (objDmdSalesWorkList != null)
			//			{
			//				dmdSalesWorkList = objDmdSalesWorkList as ArrayList;
			//			}
			//			
			//			if (objDepsitMainWorkList != null)
			//			{
			//				depsitMainWorkList = objDepsitMainWorkList as ArrayList;
			//			}
			//			
			//			dmdSalesWorkTable = new Hashtable();
			//			depsitMainWorkTable = new Hashtable();
			//			
			//			string sectionCode = "";
			//			int dmdSalesCounter = 0;
			//			int depsitMainCounter = 0;
			//			
			//			for (int ix = 0; ix < kingetCustDmdPrcList.Count; ix++)
			//			{
			//				KingetCustDmdPrcWork kingetCustDmdPrcWork = (KingetCustDmdPrcWork)kingetCustDmdPrcList[ix];
			//				
			//				if (ix == 0)
			//				{
			//					sectionCode = kingetCustDmdPrcWork.AddUpSecCode;
			//				}
			//				
			//				// ���_���ς��Ώ����𔲂���
			//				if (!sectionCode.Equals(kingetCustDmdPrcWork.AddUpSecCode))
			//				{
			//					break;
			//				}
			//										
			//				// ������������A�������z���̌v����t��KEY�Ƃ���Hashtable�ɕϊ�
			//				if ((dmdSalesWorkList != null) && (dmdSalesWorkList.Count > 0) && (dmdSalesCounter < dmdSalesWorkList.Count))
			//				{
            //                    // �� 20070124 18322 c MA.NS�p�ɕύX
			//					//foreach (DmdSalesWork work in dmdSalesWorkList)
			//
            //                    foreach (SalesSlipWork work in dmdSalesWorkList)
            //                    // �� 20070124 18322 c
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// �v����t�����ߓ��t�͈͂ɓ����Ă���ꍇ
			//						if ((workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							// �v����t
			//							if (!dmdSalesWorkTable.Contains(addUpDate))
			//							{
			//								dmdSalesWorkTable.Add(addUpDate, new ArrayList());
			//							}								
			//							ArrayList list = (ArrayList)dmdSalesWorkTable[addUpDate];
			//							list.Add(work.Clone());
			//							dmdSalesCounter++;
			//						}
			//					}
			//				}
			//				
			//				// ���������A�������z���̌v����t��KEY�Ƃ���Hashtable�ɕϊ�
			//				if ((depsitMainWorkList != null) && (depsitMainWorkList.Count > 0) && (depsitMainCounter < depsitMainWorkList.Count))
			//				{
			//					foreach (DepsitMainWork work in depsitMainWorkList)
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// �v����t�����ߓ��t�͈͂ɓ����Ă���ꍇ
			//						if ((workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							// �v����t
			//							if (!depsitMainWorkTable.Contains(addUpDate))
			//							{
			//								depsitMainWorkTable.Add(addUpDate, new ArrayList());
			//							}
			//							ArrayList list = (ArrayList)depsitMainWorkTable[addUpDate];
			//							list.Add(work.Clone());
			//							depsitMainCounter++;
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//	
			//	return status;
			//}
			//catch (Exception e)
			//{
			//	kingetCustDmdPrcList = null;
			//	dmdSalesWorkTable = null;
			//	depsitMainWorkTable = null;
            //
			//	// 2006.03.13 ADD START ����@����
			//	if (this._throughException)	throw(e);
			//	// 2006.03.13 ADD END ����@����
            //
			//	//�I�t���C������null���Z�b�g
			//	this._iSeiKingetDB = null;
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//	return -1;
			//}
			#endregion
			// �� 20070518 18322 d

		}
		
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍������i�����ꊇ����p�j
		/// </summary>
		/// <param name="kingetCustDmdPrcTable">KINGET�p���Ӑ搿�����z���e�[�u��(HashTable[���Ӑ�R�[�h]->ArrayList)</param>
		/// <param name="dmdSalesWorkTable">����������e�[�u��(HashTable[������R�[�h]->HashTable[�v����t]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">�������e�[�u��(HashTable[���Ӑ�R�[�h]->HashTable[�v����t]->ArrayList)</param>
		/// <param name="parameter">KINSET�p���o�����N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchMotoAllDB(out Hashtable kingetCustDmdPrcTable, out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable,
			SeiKingetParameter parameter)
		{
			kingetCustDmdPrcTable	= null;
			dmdSalesWorkTable		= null;
			depsitMainWorkTable		= null;

            // �� 20070518 18322 a
            kingetCustDmdPrcTable = new Hashtable();
            dmdSalesWorkTable     = new Hashtable();
            depsitMainWorkTable   = new Hashtable();

            return 0;
			// �� 20070518 18322 a

            // �� 20070518 18322 d �������͂ł͎g�p���Ă��Ȃ��̂ō폜
			#region �������͂ł͎g�p���Ȃ��̂ō폜
			//try
			//{
			//	object objKingetCustDmdPrcList	= null;
			//	object objDmdSalesWorkList		= null;
			//	object objDepsitMainWorkList	= null;
			//	
			//	// ����(�����ꊇ����p)
			//	int status = this._iSeiKingetDB.SearchMotoAll(out objKingetCustDmdPrcList, out objDmdSalesWorkList,
			//													out objDepsitMainWorkList, parameter);
			//	if (status == 0)
			//	{
			//		if (objKingetCustDmdPrcList != null)
			//		{
			//			ArrayList kingetCustDmdPrcList	= null;
			//			ArrayList dmdSalesWorkList		= null;
			//			ArrayList depsitMainWorkList	= null;
			//			
			//			if (objKingetCustDmdPrcList != null)
			//			{
			//				kingetCustDmdPrcList = objKingetCustDmdPrcList as ArrayList;
			//			}
			//			
			//			if (objDmdSalesWorkList != null)
			//			{
			//				dmdSalesWorkList = objDmdSalesWorkList as ArrayList;
			//			}
			//			
			//			if (objDepsitMainWorkList != null)
			//			{
			//				depsitMainWorkList = objDepsitMainWorkList as ArrayList;
			//			}
			//			
			//			kingetCustDmdPrcTable	= new Hashtable();
			//			dmdSalesWorkTable		= new Hashtable();
			//			depsitMainWorkTable		= new Hashtable();
			//			
			//			// KINGET�p���Ӑ搿�����z���
			//			foreach (KingetCustDmdPrcWork work in kingetCustDmdPrcList)
			//			{
			//				// ���Ӑ�R�[�h
			//				if (!kingetCustDmdPrcTable.Contains(work.CustomerCode))
			//				{
			//					kingetCustDmdPrcTable.Add(work.CustomerCode, new ArrayList());
			//				}
			//				ArrayList list = (ArrayList)kingetCustDmdPrcTable[work.CustomerCode];
			//				list.Add(work.Clone());
			//			}
			//			
			//			int dmdSalesCounter = 0;
			//			int depsitMainCounter = 0;
			//			
			//			// ���������񁕓��������A���z�������ɏW��
			//			for (int ix = 0; ix < kingetCustDmdPrcList.Count; ix++)
			//			{
			//				KingetCustDmdPrcWork kingetCustDmdPrcWork = (KingetCustDmdPrcWork)kingetCustDmdPrcList[ix];
			//				
			//				// �����������Hashtable�ɕϊ� (HashTable[������R�[�h]->HashTable[�v����t]->ArrayList)
			//				if ((dmdSalesWorkList != null) && (dmdSalesWorkList.Count > 0) && (dmdSalesCounter < dmdSalesWorkList.Count))
			//				{
            //                    // �� 20070124 18322 c MA.NS�p�ɕύX
			//					//foreach (DmdSalesWork work in dmdSalesWorkList)
			//
            //                    foreach (SalesSlipWork work in dmdSalesWorkList)
            //                    // �� 20070124 18322 c
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// ����������̐�����R�[�h�����z���̓��Ӑ�R�[�h ����
			//						// �v����t�����ߓ��t�͈͂ɓ����Ă���ꍇ
			//						if ((work.ClaimCode == kingetCustDmdPrcWork.CustomerCode) &&
			//							(workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							// ������R�[�h
			//							if (!dmdSalesWorkTable.Contains(work.ClaimCode))
			//							{
			//								dmdSalesWorkTable.Add(work.ClaimCode, new Hashtable());
			//							}
			//							Hashtable table = (Hashtable)dmdSalesWorkTable[work.ClaimCode];
			//							
			//							// �v����t
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							if (!table.Contains(addUpDate))
			//							{
			//								table.Add(addUpDate, new ArrayList());
			//							}								
			//							ArrayList list = (ArrayList)table[addUpDate];
			//							list.Add(work.Clone());
			//							dmdSalesCounter++;
			//						}
			//					}
			//				}
			//				
			//				// ��������Hashtable�ɕϊ� (HashTable[���Ӑ�R�[�h]->HashTable[�v����t]->ArrayList)
			//				if ((depsitMainWorkList != null) && (depsitMainWorkList.Count > 0) && (depsitMainCounter < depsitMainWorkList.Count))
			//				{
			//					foreach (DepsitMainWork work in depsitMainWorkList)
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// �������̓��Ӑ�R�[�h�����z���̓��Ӑ�R�[�h ����
			//						// �v����t�����ߓ��t�͈͂ɓ����Ă���ꍇ
			//						if ((work.CustomerCode == kingetCustDmdPrcWork.CustomerCode) &&
			//							(workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							// ���Ӑ�R�[�h
			//							if (!depsitMainWorkTable.Contains(work.CustomerCode))
			//							{
			//								depsitMainWorkTable.Add(work.CustomerCode, new Hashtable());
			//							}
			//							Hashtable table = (Hashtable)depsitMainWorkTable[work.CustomerCode];
			//							
			//							// �v����t
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							if (!table.Contains(addUpDate))
			//							{
			//								table.Add(addUpDate, new ArrayList());
			//							}
			//							ArrayList list = (ArrayList)table[addUpDate];
			//							list.Add(work.Clone());
			//							depsitMainCounter++;
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//	
			//	return status;
			//}
			//catch (Exception e)
			//{
			//	kingetCustDmdPrcTable = null;
			//	dmdSalesWorkTable = null;
			//	depsitMainWorkTable = null;
			//
			//	// 2006.03.13 ADD START ����@����
			//	if (this._throughException)	throw(e);
			//	// 2006.03.13 ADD END ����@����
			//
			//	//�I�t���C������null���Z�b�g
			//	this._iSeiKingetDB = null;
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//	return -1;
			//}
			#endregion
            // �� 20070518 18322 d
		}
		
		/// <summary>
		/// KINGET�p���Ӑ搿�����z��񌟍�����
		/// </summary>
		/// <param name="dmdSalesWorkTable">����������e�[�u��(HashTable[������R�[�h]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">�������e�[�u��(HashTable[���Ӑ�R�[�h]->ArrayList)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="seiKingetDetailParameterList">KINSET�p���o�����N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchDetailDB(out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable, string enterpriseCode,
			ArrayList seiKingetDetailParameterList)
		{
            // �� 20070518 18322 a
            dmdSalesWorkTable   = new Hashtable();
            depsitMainWorkTable = new Hashtable();

            return 0;
            // �� 20070518 18322 a

            // �� 20070518 18322 d �������͂ł͎g�p���Ȃ��̂ō폜
			#region �������͂ł͎g�p���Ȃ��̂ō폜
			//dmdSalesWorkTable = null;
			//depsitMainWorkTable = null;
            //
			//try
			//{
			//	object objDmdSalesWorkList = null;
			//	object objDepsitMainWorkList = null;
			//
			//	// ����
			//	int status = this._iSeiKingetDB.SearchDetails(out objDmdSalesWorkList, out objDepsitMainWorkList, enterpriseCode, seiKingetDetailParameterList);
			//	if (status == 0)
			//	{
			//		// ����������𐿋���R�[�h��KEY�Ƃ���Hashtable�ɕϊ�
			//		dmdSalesWorkTable = new Hashtable();
			//		if (objDmdSalesWorkList != null)
			//		{
			//			ArrayList dmdSalesWorkList = objDmdSalesWorkList as ArrayList;
			//			// ArrayList��Hashtable
			//			if (dmdSalesWorkList.Count > 0)
			//			{
            //                // �� 20040124 18322 c MA.NS�p�ɕύX
			//				//foreach (DmdSalesWork work in dmdSalesWorkList)
			//
            //                foreach (SalesSlipWork work in dmdSalesWorkList)
            //                // �� 20040124 18322 c
			//				{
			//					// ������R�[�h
			//					if (!dmdSalesWorkTable.Contains(work.ClaimCode))
			//					{
			//						dmdSalesWorkTable.Add(work.ClaimCode, new ArrayList());
			//					}
			//				
			//					ArrayList list = (ArrayList)dmdSalesWorkTable[work.ClaimCode];
			//					list.Add(work.Clone());
			//				}
			//			}						
			//		}
			//		
			//		// �������𓾈Ӑ�R�[�h��KEY�Ƃ���Hashtable�ɕϊ�
			//		depsitMainWorkTable = new Hashtable();
			//		if (objDepsitMainWorkList != null)
			//		{
			//			ArrayList depsitMainWorkList = objDepsitMainWorkList as ArrayList;
			//			// ArrayList��Hashtable
			//			if (depsitMainWorkList.Count > 0)
			//			{
			//				foreach (DepsitMainWork work in depsitMainWorkList)
			//				{
			//					// ���Ӑ�R�[�h
			//					if (!depsitMainWorkTable.Contains(work.CustomerCode))
			//					{
			//						depsitMainWorkTable.Add(work.CustomerCode, new ArrayList());
			//					}
			//				
			//					ArrayList list = (ArrayList)depsitMainWorkTable[work.CustomerCode];
			//					list.Add(work.Clone());
			//				}
			//			}						
			//		}
			//	}
			//	
			//	return status;
			//}
			//catch (Exception e)
			//{
			//	dmdSalesWorkTable = null;
			//	depsitMainWorkTable = null;
			//
			//	// 2006.03.13 ADD START ����@����
			//	if (this._throughException)	throw(e);
			//	// 2006.03.13 ADD END ����@����
			//
			//	//�I�t���C������null���Z�b�g
			//	this._iSeiKingetDB = null;
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//	return -1;
			//}
			#endregion
            // �� 20070518 18322 d
		}		

		/// <summary>
		/// ���o�����ݒ�i���Ӑ敪�̓R�[�h�j
		/// </summary>
		/// <param name="parameter">���o�����p�����[�^�N���X</param>
		/// <param name="startCustAnalysCodes">�J�n���Ӑ敪�̓R�[�h�z��(1�`6)</param>
		/// <param name="endCustAnalysCodes">�I�����Ӑ敪�̓R�[�h�z��(1�`6)</param>
		/// <remarks>
		/// <br>Note       : �����p�����[�^�ɓ��Ӑ敪�̓R�[�h�̒��o������ݒ肵�܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2006.09.06</br>
		/// </remarks>
		private void SetParameterForCustAnalysCodes(SeiKingetParameter parameter, int[] startCustAnalysCodes, int[] endCustAnalysCodes)
		{
			// �J�n���Ӑ敪�̓R�[�h
			if (startCustAnalysCodes != null)
			{
				if (startCustAnalysCodes.Length > 0) parameter.StartCustAnalysCode1	= startCustAnalysCodes[0];
				if (startCustAnalysCodes.Length > 1) parameter.StartCustAnalysCode2	= startCustAnalysCodes[1];
				if (startCustAnalysCodes.Length > 2) parameter.StartCustAnalysCode3	= startCustAnalysCodes[2];
				if (startCustAnalysCodes.Length > 3) parameter.StartCustAnalysCode4	= startCustAnalysCodes[3];
				if (startCustAnalysCodes.Length > 4) parameter.StartCustAnalysCode5	= startCustAnalysCodes[4];
				if (startCustAnalysCodes.Length > 5) parameter.StartCustAnalysCode6	= startCustAnalysCodes[5];
			}

			// �I�����Ӑ敪�̓R�[�h
			if ((endCustAnalysCodes != null) && (endCustAnalysCodes.Length > 0))
			{
				if (endCustAnalysCodes.Length > 0) parameter.EndCustAnalysCode1	= endCustAnalysCodes[0];
				if (endCustAnalysCodes.Length > 1) parameter.EndCustAnalysCode2	= endCustAnalysCodes[1];
				if (endCustAnalysCodes.Length > 2) parameter.EndCustAnalysCode3	= endCustAnalysCodes[2];
				if (endCustAnalysCodes.Length > 3) parameter.EndCustAnalysCode4	= endCustAnalysCodes[3];
				if (endCustAnalysCodes.Length > 4) parameter.EndCustAnalysCode5	= endCustAnalysCodes[4];
				if (endCustAnalysCodes.Length > 5) parameter.EndCustAnalysCode6	= endCustAnalysCodes[5];
			}
		}
		# endregion
	}
}
