using System;
using System.Collections;
using System.Data;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.LocalAccess;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �S�̏����l�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �S�̏����l�ݒ�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 23006�@���� ���q</br>
	/// <br>Date       : 2005.10.03</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.04  23006 ���� ���q</br>
	/// <br>			   �E�t�@�C���d�l���ύX�ׁ̈A�Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.20  23006 ���� ���q</br>
	/// <br>			   �E���_���擾���i�Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.26  23006 ���� ���q</br>
	/// <br>				�E����I�t���C���Ή�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.19  23006 ���� ���q</br>
	/// <br>				�E�L���b�V����{���Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2006.08.31  23006 ���� ���q</br>
    /// <br>				�E���_�@�\�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2006.09.05  23006 ���� ���q</br>
    /// <br>				�ESetStaticMemory���\�b�h�ǉ�</br>
    /// <br></br>
    /// <br>Update Note : 2006.12.05  18322 �ؑ� ����</br>
    /// <br>				�� �g�уV�X�e���Ή��ɂ��ȉ��̍��ڂ��폜</br>
    /// <br>                     �E�ǋ�R�[�h</br>
    /// <br>                     �E�����\���Z���R�[�h1�`3</br>
    /// <br>                     �E�����\���Z��1�`3</br>
    /// <br>                     �E88No.�̎����ӎZ��敪</br>
    /// <br>                     �E�ԗ��m��I�����</br>
    /// <br>                     �E���^�������ԍ�</br>
    /// <br></br>
    /// <br>Update Note : 2007.03.05  30005 �،��@��</br>
    /// <br>                �� �g�уV�X�e���Ή��ɂ��ȉ��̍��ڂ�ǉ�</br>
    /// <br>                     �E������Ǘ��敪</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.23  30005 �،��@��</br>
    /// <br>                �� MobileKing �ł͎g�p���Ȃ��������폜(�T�[�o�ŃG���[��������������)</br>
    /// <br>                     �EAreaGroupAcs, AreaGroup �̍폜</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.25�@19026�@���R�@����</br>
    /// <br>				�� ���[�J���A�N�Z�X�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2007.08.08 20056  ���n ���</br>
    /// <br>                �����ʔ̔���Ή�</br>
    /// <br>                �E�����\���敪�P�E�Q�E�R</br>
	/// <br>Update Note : 2008.01.31 30167 ���@�O�M</br>
	/// <br>			 �@ �E���[�J���c�a�Ή�</br>
    /// <br>Update Note : 2008/06/04 30414  �E�@�K�j</br>
    /// <br>                �E�u�ڋq�R�[�h�������ԁv�u���Ӑ�폜�`�F�b�N�v�u������Ǘ��v�폜</br>
    /// <br>Update Note : 2010/01/18 30531  ���@�r��</br>
    /// <br>                �E�������^�C�v���̏o�͋敪��ǉ��i�R���ځj</br>
    /// <br>Update Note : 2010/05/25 22008  �����@���n</br>
    /// <br>                �E�I�t���C���Ή�</br>
    /// <br>Update Note : 2011/07/19 zhouyu</br>
    /// <br>                �E�A�� 1028</br>
    /// <br>                  �C�����e�F�A�� 1028 �݌Ɏd�����͂ŁA�i�ԓ��͌�Ɏ����� �d����=�P �ƕ\������A���݌ɐ���������ĕ\���ɂȂ蕪���肸�炢</br>
    /// <br>                  PM7�ł́A�d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������</br>
    /// <br>                  ����`�[���́C�d���`�[���� ������</br>
    /// <br>Update Note : ���N</br>
    /// <br>Date        : 2013/05/02</br>
    /// <br>�Ǘ��ԍ�    : 10901273-00 2013/06/18�z�M�� </br>
    /// <br>            : Redmine#35434 ���i�݌Ƀ}�X�^�N���敪�̒ǉ�</br>
    /// </remarks>
	public class AllDefSetAcs
	{
		#region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		private IAllDefSetDB _iAllDefSetDB = null;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.20 TAKAHASHI ADD START
		// ���_���擾�p
		private SecInfoAcs _secInfoAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.20 TAKAHASHI ADD END

		/// <remarks>�ǋ於�̎擾�p</remarks>
		public ArrayList areaKindList;
		private Hashtable areaKindTable;
		// 2007.05.23 deleted by T-Kidate : MobileKing�ł͎g�p���Ȃ�
        //private AreaGroupAcs areaGroupAcs;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.26 TAKAHASHI ADD START
		// Static�i�[�pHashTable
		private static Hashtable _static_AllDefSetTable = null;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.26 TAKAHASHI ADD END

		//----- ueno add ---------- start 2008.01.31
		// ���[�J���c�a���[�h        
		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g	        
		//----- ueno add ---------- end 2008.01.31	

		#endregion

        #region [���[�J���A�N�Z�X�p]
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        /// <summary> ���[�J���A�N�Z�X�I�u�W�F�N�g </summary>
        private AllDefSetLcDB _allDefSetLcDB = null;
        #endregion

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
		static AllDefSetAcs()
		{
			// Static�i�[�pHashTable
			_static_AllDefSetTable = new Hashtable();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// <br></br>
		/// <br>Note       : �I�t���C���Ή�</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public AllDefSetAcs()
		{
            // -- UPD 2010/05/25 --------------------------->>>
            ////�I�����C���̏ꍇ
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iAllDefSetDB = (IAllDefSetDB)MediationAllDefSetDB.GetAllDefSetDB();
            //    }
            //    catch(Exception)
            //    {
            //        // �I�t���C������null���Z�b�g
            //        this._iAllDefSetDB = null;
            //    }
            //}
            //else
            //// �I�t���C���̏ꍇ
            //{
            //    // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            //    OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            //    // HashTable��Key�ݒ�
            //    string [] keyList = new string[1];
            //    keyList[0] = LoginInfoAcquisition.EnterpriseCode;

            //    // ���[�J���t�@�C���Ǎ��ݏ���
            //    object wkObj = offlineDataSerializer.DeSerialize("AllDefSetAcs", keyList);

            //    ArrayList wkList = wkObj as ArrayList;

            //    // �S�̏����l�ݒ胏�[�N�N���X�iArrayList�j��UI�N���X�iStatic�j�ϊ�����
            //    CopyToAllDefSetFromAllDefSetWork(wkList);
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iAllDefSetDB = (IAllDefSetDB)MediationAllDefSetDB.GetAllDefSetDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iAllDefSetDB = null;
            }
            // -- UPD 2010/05/25 ---------------------------<<<

			//----- ueno del ---------- start 2008.01.31
			// ���[�J���c�a�Ή��ɂ��擾�ʒu�ύX
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.20 TAKAHASHI ADD START
			// ���_���擾�p
			//this._secInfoAcs = new SecInfoAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.20 TAKAHASHI ADD END
			//----- ueno del ---------- end 2008.01.31

			// �ǋ於�̎擾�p
			this.areaKindList = null;
			this.areaKindTable = new Hashtable();
            // 2007.05.23 deleted by T-Kidate : MobileKing�ł͎g�p���Ȃ�
			//this.areaGroupAcs = new AreaGroupAcs();

            //���[�J���A�N�Z�X�I�u�W�F�N�g�C���X�^���X��
            _allDefSetLcDB = new AllDefSetLcDB();
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
		/// <br>Date       : 2005.10.03</br>
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
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iAllDefSetDB == null)
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
		/// �ǂݍ��ݏ���
		/// </summary>
		/// <param name="allDefSet">UI�f�[�^�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param> 
		/// <param name="sectionCode">���_�R�[�h</param>  
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
        public int Read(out AllDefSet allDefSet, string enterpriseCode, string sectionCode)
        {
            return Read(out allDefSet, enterpriseCode, sectionCode, SearchMode.Remote);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="allDefSet">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2006.05.25</br>
        /// </remarks>
        public int Read(out AllDefSet allDefSet, string enterpriseCode, string sectionCode, SearchMode searchMode)
		{
			try
			{
                int status = 0;

                allDefSet = null;

				//----- ueno add---------- start 2008.01.31
				_isLocalDBRead = searchMode == SearchMode.Local ? true : false;
				//----- ueno add---------- end 2008.01.31

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI DELETE START
                //AllDefSetWork allDefSetWork = new AllDefSetWork();
                //allDefSetWork.EnterpriseCode = enterpriseCode;
                //allDefSetWork.SectionCode    = sectionCode;

                //// �I�����C���̏ꍇ
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                //    // ���[�N�N���X���w�l�k�i�o�C�i�����j
                //    byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);

                //    // �ǂݍ��ݏ���
                //    status = this._iAllDefSetDB.Read(ref parabyte,0);

                //    if (status == 0)
                //    {
                //        // ���[�N�N���X���w�l�k
                //        allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));

                //        // UI�f�[�^�N���X�����[�N�N���X
                //        allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                //        // HashTable��Key
                //        string keysOfHashTable = allDefSet.SectionCode;

                //        // �X�^�e�B�b�N�̈�ɏ���ێ�
                //        _static_AllDefSetTable[keysOfHashTable] = allDefSet;
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                //    }
                //}
                //// �I�t���C���̏ꍇ
                //else
                //{
                //    status = ReadStaticMemory(out allDefSet, enterpriseCode, sectionCode);
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI DELETE END

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                if ((_static_AllDefSetTable == null) || (_static_AllDefSetTable.Count <= 0))
                {
                    ArrayList dataList;

                    status = this.SearchAll(out dataList, enterpriseCode, searchMode);
                }
                
                status = ReadStaticMemory(out allDefSet, enterpriseCode, sectionCode);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI ADD END

				return status;
			}
			catch (Exception)
			{				    
                allDefSet = null;
                // �I�t���C������null���Z�b�g
                this._iAllDefSetDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;                
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static�̈�ێ������i�I�t���C���Ή��j
		/// </summary>
		/// <param name="allDefSet">�S�̏����l�ݒ�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �擾�����l��Static�̈�ɕێ����܂��B�i�I�t���C���Ή��j</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int ReadStaticMemory(out AllDefSet allDefSet, string enterpriseCode, string sectionCode)
		{
			allDefSet = new AllDefSet();

			// HashTable��Key
			string keysOfHashTable = sectionCode;

			if (_static_AllDefSetTable == null)
			{
				return -1;
			}

			// Static����f�[�^����������
			if (_static_AllDefSetTable[keysOfHashTable] == null)
			{
				return 4;
			}
			else
			{
				allDefSet = (AllDefSet)_static_AllDefSetTable[keysOfHashTable];
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

			if (_static_AllDefSetTable == null)
			{
				return -1;
			}
			else if (_static_AllDefSetTable.Count == 0)
			{
				return 9;
			}

			foreach (AllDefSet allDefSet in _static_AllDefSetTable.Values)
			{
				sortedList.Add(allDefSet.SectionCode, allDefSet);
			}

			retList.AddRange(sortedList.Values);

			return 0;
		}
		#endregion

		#region -- �f�V���A���C�Y���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>UI�f�[�^�N���X���X�g</returns>
		/// <remarks>
		/// <br>Note       : ���[�N�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public AllDefSet Deserialize(string fileName)
		{
			AllDefSet allDefSet = null;
			// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
			AllDefSetWork allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(fileName, typeof(AllDefSetWork));

			//�f�V���A���C�Y���ʂ�UI�N���X�փR�s�[
			if (allDefSetWork != null)
			{
				allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);
			}

			return allDefSet;
		}
		#endregion

		#region -- �S�̏����l�ݒ背�R�[�h�ǉ����� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����l�ݒ背�R�[�h�ǉ�����
		/// </summary>
		/// <param name="allDefSet">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ背�R�[�h��ǉ����܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M�� </br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private int AddNewAllDefSetRecord(out AllDefSet allDefSet, string enterpriseCode, string sectionCode)
		{
			allDefSet = new AllDefSet();  

			// ��ƃR�[�h
			allDefSet.EnterpriseCode = enterpriseCode;

			// ���_�R�[�h  
			allDefSet.SectionCode    = sectionCode;				 

            // �� 20061205 18322 d
			//// �ǋ�R�[�h �����l
			//allDefSet.DistrictCode = 4;
            //


			//// �����\���Z���R�[�h1 �����l
			//allDefSet.DefDispAddrCd1 = 0;
            //
			//// �����\���Z���R�[�h2 �����l
			//allDefSet.DefDispAddrCd2 = 0;
            //
			//// �����\���Z���R�[�h3 �����l
			//allDefSet.DefDispAddrCd3 = 0;
            // �� 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
			// �����\���Z���R�[�h4 �����l
//			allDefSet.DefDispAddrCd4 = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END

            // �� 20061205 18322 d
            //// �����\���Z��1 �����l
			//allDefSet.DefDispAddress = "";
            //
			//// 88No.�̎����ӎZ��敪 �����l
			//allDefSet.No88AutoLiaCalcDiv = 0;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �ڋq�R�[�h�������ԋ敪 �����l
			allDefSet.CustCdAutoNumbering = 0;

			// ���Ӑ�폜�`�F�b�N�敪 �����l
			allDefSet.CustomerDelChkDivCd = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // �����\���ڋq���� �����l
			allDefSet.DefDspCustTtlDay = 31;

			// �����\���ڋq�W���� �����l
			allDefSet.DefDspCustClctMnyDay = 10;

			// �����\���W�����敪 �����l
			allDefSet.DefDspClctMnyMonthCd = 1;

			// �����\���l�E�@�l�敪 �����l
			allDefSet.IniDspPrslOrCorpCd = 0;

			// �����\��DM�敪 �����l
			allDefSet.InitDspDmDiv = 0;

			// �����\���������o�͋敪 �����l
			allDefSet.DefDspBillPrtDivCd = 0;

            // �� 20061205 18322 d
			//// �ԗ��m��I����� �����l
			//allDefSet.CarFixSelectMethod = 0;
            //
            //// ���^�������ԍ� �����l
            //allDefSet.LandTransBranchCd = 0;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // ������Ǘ��敪 �����l
            allDefSet.MemberInfoDispCd = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			// ���z�\�����@�敪 �����l
			allDefSet.TotalAmountDispWayCd = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // �����\���敪�P �����l
            allDefSet.EraNameDispCd1 = 0;
            // �����\���敪�Q �����l
            allDefSet.EraNameDispCd2 = 0;
            // �����\���敪�R �����l
            allDefSet.EraNameDispCd3 = 0;

            // ���i�ԍ����͋敪
            allDefSet.GoodsNoInpDiv = 0;
            // ����Ŏ����␳�敪
            allDefSet.CnsTaxAutoCorrDiv = 0;
            // �c���Ǘ��敪
            allDefSet.RemainCntMngDiv = 0;
            // �������ʋ敪
            allDefSet.MemoMoveDiv = 0;
            // �c�������\���敪
            allDefSet.RemCntAutoDspDiv = 0;
            // ���z�\���|���K�p�敪
            allDefSet.TtlAmntDspRateDivCd = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            //�����\�����v�������o�͋敪�@�����l
            allDefSet.DefTtlBillOutput = 0;
            //�����\�����א������o�͋敪�@�����l
            allDefSet.DefDtlBillOutput = 0;
            //�����\���`�[���v�������o�͋敪�@�����l
            allDefSet.DefSlTtlBillOutput = 0;
            // --- ADD  ���r��  2010/01/18 ----------<<<<<

            //ADD 2011/07/19
            //�d���E�o�׌㐔�\���敪
            allDefSet.DtlCalcStckCntDsp = 0;
            //ADD 2011/07/19

            // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
            // ���i�݌Ƀ}�X�^�N���敪
            allDefSet.GoodsStockMSTBootDiv = 0;
            // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

			// �V�K�o�^����
			int status = this.Write(ref allDefSet);
			return status;
		}
		#endregion

		#region -- �o�^��X�V���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �o�^�E�X�V����
		/// </summary>
		/// <param name="allDefSet">UI�f�[�^�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Write(ref AllDefSet allDefSet)
		{		
			// UI�f�[�^�N���X�����[�N
			AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);

			int status = 0;

			try
			{
				// �������ݏ���
				status = this._iAllDefSetDB.Write(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
					allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(AllDefSetWork));
					// �N���X�������o�R�s�[
					allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                    //_static_AllDefSetTable[allDefSet.SectionCode] = allDefSet;
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI ADD END
                }
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iAllDefSetDB = null;
				// �ʐM�G���[��-1��߂�
				status = -1;
			}
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �o�^�E�X�V�����i�I�t���C���Ή��j
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �o�^�E�X�V�������s���܂��B�i�I�t���C���Ή��j</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status = 0;

			if (_static_AllDefSetTable.Count != 0)
			{
				// HashTable��Key
				string [] keyList = new string[1];
				keyList[0] = LoginInfoAcquisition.EnterpriseCode;

				AllDefSetWork allDefSetWork = new AllDefSetWork();

				ArrayList allDefSetList = new ArrayList();

				foreach (AllDefSet allDefSet in _static_AllDefSetTable.Values)
				{
					allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);
					allDefSetList.Add(allDefSetWork);
				}

				// �S�̏����l�ݒ胏�[�N���i�o�C�i���j
				status = offlineDataSerializer.Serialize("AllDefSetAcs", keyList, allDefSetList);
			}

			return status;
		}
		#endregion

		#region -- �폜���� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �_���폜����
		/// </summary>
		/// <param name="allDefSet">�S�̏����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̘_���폜���s���܂��B�i�������j</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int LogicalDelete(ref AllDefSet allDefSet)
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            try
            {
                AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);
                // ���_���_���폜
                int status = this._iAllDefSetDB.LogicalDelete(ref parabyte);
                if (status == 0)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(AllDefSetWork));
                    // �N���X�������o�R�s�[
                    allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iAllDefSetDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����폜����
		/// </summary>
		/// <param name="allDefSet">�S�̏����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̕����폜���s���܂��B�i�������j</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Delete(AllDefSet allDefSet)
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            try
            {
                AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);
                // ���_��񕨗��폜
                int status = this._iAllDefSetDB.Delete(parabyte);
                if (status == 0)
                {
                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iAllDefSetDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}
		#endregion

		#region -- ������������� --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ茟���������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntProc(out retTotalCnt, enterpriseCode, 0);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ茟���������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����l�ݒ茏����������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ茏���̌������s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		private int SearchCntProc(out int retTotalCnt,string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			AllDefSetWork allDefSetWork = new AllDefSetWork();

			allDefSetWork.EnterpriseCode = enterpriseCode;
			
			//	XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);

			//	�S�̏����l�ݒ茏������
			int status = this._iAllDefSetDB.SearchCnt(out retTotalCnt, parabyte, 0,logicalMode);

			if ( status != 0 ) retTotalCnt = 0;

			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����l�ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;            
			return SearchProc(out retList,out retTotalCnt,out nextData, enterpriseCode, 0, 0, null, SearchMode.Remote);            
		}

		//----- ueno add---------- start 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����l�ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, searchMode);
		}
		//----- ueno add---------- end 2008.01.31

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����l�ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {            
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);            
        }

        /// <summary>
        /// �S�̏����l�ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2006.05.25</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����w��S�̏����l�ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevAllDefSet">�O��ŏI�S�̏����l�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ĎԔ̏��ޑS�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,AllDefSet prevAllDefSet)
		{			
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevAllDefSet, SearchMode.Remote);
            
		}

		//----- ueno add---------- start 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����w��S�̏����l�ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevAllDefSet">�O��ŏI�S�̏����l�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ĎԔ̏��ޑS�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, AllDefSet prevAllDefSet, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevAllDefSet, searchMode);
		}
		//----- ueno add---------- end 2008.01.31

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����w��S�̏����l�ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevCSlpPrtSet��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevAllDefSet">�O��ŏI�S�̏����l�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�đS�̏����l�ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,AllDefSet prevAllDefSet)
		{			    
			return SearchProc(out retList,out retTotalCnt, out nextData,enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevAllDefSet, SearchMode.Remote);            
		}

		//----- ueno add---------- start 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �����w��S�̏����l�ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevCSlpPrtSet��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevAllDefSet">�O��ŏI�S�̏����l�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�đS�̏����l�ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, AllDefSet prevAllDefSet, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevAllDefSet, searchMode);
		}
		//----- ueno add---------- end 2008.01.31
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����l�ݒ�_���폜��������
		/// </summary>
		/// <param name="allDefSet">�S�̏����l�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̕������s���܂��B�i�������j</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		public int Revival(ref AllDefSet allDefSet)
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            try
            {
                AllDefSetWork allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(allDefSet);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(allDefSetWork);
                // ��������
                int status = this._iAllDefSetDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                    allDefSetWork = (AllDefSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(AllDefSetWork));
                    // �N���X�������o�R�s�[
                    allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);

                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

                    // 2006.09.01 N.TANIFUJI ADD
                    this._secInfoAcs.ResetSectionInfo();

                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iAllDefSetDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/		
		/// <summary>
		/// �S�̏����l�ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>  
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevAllDefSet">�O��ŏI�Ԕ̏��ޑS�̐ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.16</br>
        /// <br></br>
        /// <br>UpdateNote : 2007.05.25�@19026�@���R�@����</br>
        /// <br>             ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, AllDefSet prevAllDefSet, SearchMode searchMode)
		{
			//----- ueno add---------- start 2008.01.31
			_isLocalDBRead = searchMode == SearchMode.Local ? true : false;
			//----- ueno add---------- end 2008.01.31

			AllDefSetWork allDefSetWork = new AllDefSetWork();

			if (prevAllDefSet != null)
			{
				allDefSetWork = CopyToAllDefSetWorkFromAllDefSet(prevAllDefSet);
			}

			allDefSetWork.EnterpriseCode = enterpriseCode;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �폜����Ă��Ȃ����_�R�[�h�m�ۗp
			ArrayList aliveSectionCodeList = new ArrayList();
            
            // ���_�R�[�h�̃R���N�V�������擾
			int sectionStatus = GetAliveSectionCodeList(out aliveSectionCodeList, enterpriseCode);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ���f�[�^�L��������
			nextData = false;

			// �Ǎ��Ώۃf�[�^������0�ŏ�����
			retTotalCnt = 0;

			retList = new ArrayList();
			retList.Clear();

			ArrayList allDefSetWorkList = new ArrayList();
			allDefSetWorkList.Clear();

			// ���_���擾����
			ArrayList wkList = new ArrayList() ;
			wkList.Clear();

			int status = 0;

			object paraobj = allDefSetWork;
			object retobj = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2007.05.23 T-Kidate DELETE START
            //this.MakeAreaKindTable(enterpriseCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<2007.05.23 T-Kidate DELETE END

            // ���� 2007.05.25 ���R �I�t���C���ł��I�����C���ł��������� ����
            //// �I�t���C���̏ꍇ
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);
            //}
            //// �I�����C���̏ꍇ
            //else
            //{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                if ((_static_AllDefSetTable != null) && (_static_AllDefSetTable.Count > 0))
                {
                    status = this.SearchStaticMemory(out retList);
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
                else
                {
                    // �S�̐ݒ茟��
                    
                    if (searchMode == SearchMode.Remote)
                    {
                        status = this._iAllDefSetDB.Search(out retobj, paraobj, 0, logicalMode);
                    }
                    // ���[�J���A�N�Z�X�Ή�  -- 2007.05.25 ���R
                    else                                       
                    {
                        List<AllDefSetWork> list;
                        status = this._allDefSetLcDB.Search(out list, (AllDefSetWork)paraobj, 0, logicalMode);
                        ArrayList al = new ArrayList(list);
                        retobj = (object)al;
                    }

                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {

                        allDefSetWorkList = retobj as ArrayList;

                        if (allDefSetWorkList == null)
                        {
                            return status; //7
                        }

                        foreach (AllDefSetWork wkallDefSetWork in allDefSetWorkList)
                        {
                            //wkList.Add(CopyToAllDefSetFromAllDefSetWork(wkallDefSetWork));  // DEL 2008/06/04
                            retList.Add(CopyToAllDefSetFromAllDefSetWork(wkallDefSetWork));  // ADD 2008/06/04
                        }

                        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                        // ���_������ꍇ
                        if (sectionStatus == 0)
                        {
                            foreach (string sectionCode in aliveSectionCodeList)
                            {
                                AllDefSet allDefSet = null;

                                for (int ix = 0; ix < wkList.Count; ix++)
                                {

                                    if (((AllDefSet)wkList[ix]).SectionCode.TrimEnd() == sectionCode.TrimEnd())
                                    {
                                        // ���_������̂Ń��X�g�ɒǉ�
                                        allDefSet = (AllDefSet)wkList[ix];
                                        retList.Add(allDefSet);
                                    }
                                }

                                // ���_�͂��邪�S�̏����l�ݒ�ɖ����Ƃ�
                                if (allDefSet == null)
                                {
                                    // ���_���ɍ��킹�ă��R�[�h��ǉ�
                                    int st = AddNewAllDefSetRecord(out allDefSet, enterpriseCode, sectionCode);

                                    if (st == 0)
                                    {
                                        retList.Add(allDefSet);
                                    }
                                }

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                                // HashTable��Key
                                string keysOfHashTable = allDefSet.SectionCode;

                                // �X�^�e�B�b�N�̈�ɏ���ێ�
                                _static_AllDefSetTable[keysOfHashTable] = allDefSet;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                            }
                        }
                           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                        // �Ǎ��Ώۃf�[�^��������ArrayList�̌���
                        retTotalCnt = retList.Count;
                    }
                }

				// STATUS ��ݒ�
				if( ( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) && 
					( retList.Count == 0 ) ) {
					status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
				}
			//}
			// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0)
			{
				retTotalCnt = retList.Count;
			}

			return status;
		}
		#endregion

        #region -- SetStatic --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// StaticData�̓o�^�E�X�V
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : StaticData�̓o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : 23006�@���� ���q</br>
        /// <br>Date       : 2006.09.05</br>
        /// </remarks>
        public static int SetStaticMemory(ArrayList setDataList)
        {
            if ((setDataList == null) || (setDataList.Count <= 0))
            {
                return -1;
            }

            foreach (AllDefSet allDefSet in setDataList)
            {
                string keysOfHashTable = allDefSet.SectionCode;

                _static_AllDefSetTable[keysOfHashTable] = allDefSet;
            }

            return 0;
        }
        #endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�S�̏����l�ݒ胏�[�N�N���X�ˑS�̏����l�ݒ�N���X�j
		/// </summary>
		/// <param name="allDefSetWork">�S�̏����l�ݒ胏�[�N�N���X</param>
		/// <returns>�S�̏����l�ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ胏�[�N�N���X����S�̏����l�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M�� </br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private AllDefSet CopyToAllDefSetFromAllDefSetWork(AllDefSetWork allDefSetWork)
		{
			AllDefSet allDefSet = new AllDefSet();

			allDefSet.CreateDateTime    = allDefSetWork.CreateDateTime;
			allDefSet.UpdateDateTime    = allDefSetWork.UpdateDateTime;
			allDefSet.EnterpriseCode    = allDefSetWork.EnterpriseCode;
			allDefSet.FileHeaderGuid    = allDefSetWork.FileHeaderGuid;
			allDefSet.UpdEmployeeCode   = allDefSetWork.UpdEmployeeCode;
			allDefSet.UpdAssemblyId1    = allDefSetWork.UpdAssemblyId1;
			allDefSet.UpdAssemblyId2    = allDefSetWork.UpdAssemblyId2;
			allDefSet.LogicalDeleteCode = allDefSetWork.LogicalDeleteCode;
			allDefSet.SectionCode       = allDefSetWork.SectionCode;

            // �� 20061205 18322 d
			//allDefSet.DistrictCode         = allDefSetWork.DistrictCode;
			//allDefSet.DefDispAddrCd1       = allDefSetWork.DefDispAddrCd1;
			//allDefSet.DefDispAddrCd2       = allDefSetWork.DefDispAddrCd2;
			//allDefSet.DefDispAddrCd3       = allDefSetWork.DefDispAddrCd3;
			//allDefSet.DefDispAddress       = allDefSetWork.DefDispAddress;
			//allDefSet.No88AutoLiaCalcDiv   = allDefSetWork.No88AutoLiaCalcDiv;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSet.CustCdAutoNumbering  = allDefSetWork.CustCdAutoNumbering;
			allDefSet.CustomerDelChkDivCd  = allDefSetWork.CustomerDelChkDivCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            allDefSet.DefDspCustTtlDay     = allDefSetWork.DefDspCustTtlDay;
			allDefSet.DefDspCustClctMnyDay = allDefSetWork.DefDspCustClctMnyDay;
			allDefSet.DefDspClctMnyMonthCd = allDefSetWork.DefDspClctMnyMonthCd;
			allDefSet.IniDspPrslOrCorpCd   = allDefSetWork.IniDspPrslOrCorpCd;
			allDefSet.InitDspDmDiv         = allDefSetWork.InitDspDmDiv;
			allDefSet.DefDspBillPrtDivCd   = allDefSetWork.DefDspBillPrtDivCd;

            // �� 20061205 18322 d
			//allDefSet.CarFixSelectMethod   = allDefSetWork.CarFixSelectMethod;
            //allDefSet.LandTransBranchCd    = allDefSetWork.LandTransBranchCd;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            allDefSet.MemberInfoDispCd = allDefSetWork.MemberInfoDispCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            //allDefSet.SectionName  = GetSectionName(allDefSetWork.EnterpriseCode, allDefSetWork.SectionCode);

            // �� 20061205 18322 d
			//allDefSet.DistrictName = GetDistrictName(allDefSetWork.EnterpriseCode, allDefSetWork.DistrictCode);
            // �� 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			allDefSet.TotalAmountDispWayCd = allDefSetWork.TotalAmountDispWayCd;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            allDefSet.EraNameDispCd1 = allDefSetWork.EraNameDispCd1;
            allDefSet.EraNameDispCd2 = allDefSetWork.EraNameDispCd2;
            allDefSet.EraNameDispCd3 = allDefSetWork.EraNameDispCd3;
            allDefSet.GoodsNoInpDiv = allDefSetWork.GoodsNoInpDiv;
            allDefSet.CnsTaxAutoCorrDiv = allDefSetWork.CnsTaxAutoCorrDiv;
            allDefSet.RemainCntMngDiv = allDefSetWork.RemainCntMngDiv;
            allDefSet.MemoMoveDiv = allDefSetWork.MemoMoveDiv;
            allDefSet.RemCntAutoDspDiv = allDefSetWork.RemCntAutoDspDiv;
            allDefSet.TtlAmntDspRateDivCd = allDefSetWork.TtlAmntDspRateDivCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            allDefSet.DefTtlBillOutput = allDefSetWork.DefTtlBillOutput;
            allDefSet.DefDtlBillOutput = allDefSetWork.DefDtlBillOutput;
            allDefSet.DefSlTtlBillOutput = allDefSetWork.DefSlTtlBillOutput;
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD 2011/07/19
            //�d���E�o�׌㐔�\���敪
            allDefSet.DtlCalcStckCntDsp = allDefSetWork.DtlCalcStckCntDsp;
            //ADD 2011/07/19

            allDefSet.GoodsStockMSTBootDiv = allDefSetWork.GoodsStockMstBootDiv; // ���i�݌ɋN���敪�@// ADD ���N 2013/05/02 Redmine#35434
            return allDefSet;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�S�̏����l�ݒ胏�[�N�N���X�ˑS�̏����l�ݒ�N���X�j
		/// </summary>
		/// <param name="allDefSetWorkList">�S�̏����l�ݒ胏�[�N�N���X</param>
		/// <returns>�S�̏����l�ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ胏�[�N�N���X����S�̏����l�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.26</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M�� </br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void CopyToAllDefSetFromAllDefSetWork(ArrayList allDefSetWorkList)
		{
			// HashTable��Key
			string keyOfHashTable = null;

			// ArrayList����̏ꍇ
			if (allDefSetWorkList == null)
				return;

			foreach (AllDefSetWork allDefSetWork in allDefSetWorkList)
			{
				AllDefSet allDefSet = new AllDefSet();

				keyOfHashTable = allDefSetWork.SectionCode;

				allDefSet.CreateDateTime    = allDefSetWork.CreateDateTime;
				allDefSet.UpdateDateTime    = allDefSetWork.UpdateDateTime;
				allDefSet.EnterpriseCode    = allDefSetWork.EnterpriseCode;
				allDefSet.FileHeaderGuid    = allDefSetWork.FileHeaderGuid;
				allDefSet.UpdEmployeeCode   = allDefSetWork.UpdEmployeeCode;
				allDefSet.UpdAssemblyId1    = allDefSetWork.UpdAssemblyId1;
				allDefSet.UpdAssemblyId2    = allDefSetWork.UpdAssemblyId2;
				allDefSet.LogicalDeleteCode = allDefSetWork.LogicalDeleteCode;
				allDefSet.SectionCode       = allDefSetWork.SectionCode;

                // �� 20061205 18322 d
				//allDefSet.DistrictCode   = allDefSetWork.DistrictCode;
				//allDefSet.DefDispAddrCd1 = allDefSetWork.DefDispAddrCd1;
				//allDefSet.DefDispAddrCd2 = allDefSetWork.DefDispAddrCd2;
				//allDefSet.DefDispAddrCd3 = allDefSetWork.DefDispAddrCd3;
				//allDefSet.DefDispAddress       = allDefSetWork.DefDispAddress;
				//allDefSet.No88AutoLiaCalcDiv   = allDefSetWork.No88AutoLiaCalcDiv;
                // �� 20061205 18322 d

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                allDefSet.CustCdAutoNumbering = allDefSetWork.CustCdAutoNumbering;
				allDefSet.CustomerDelChkDivCd  = allDefSetWork.CustomerDelChkDivCd;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                
                allDefSet.DefDspCustTtlDay     = allDefSetWork.DefDspCustTtlDay;
				allDefSet.DefDspCustClctMnyDay = allDefSetWork.DefDspCustClctMnyDay;
				allDefSet.DefDspClctMnyMonthCd = allDefSetWork.DefDspClctMnyMonthCd;
				allDefSet.IniDspPrslOrCorpCd   = allDefSetWork.IniDspPrslOrCorpCd;
				allDefSet.InitDspDmDiv         = allDefSetWork.InitDspDmDiv;
				allDefSet.DefDspBillPrtDivCd   = allDefSetWork.DefDspBillPrtDivCd;
                allDefSet.TotalAmountDispWayCd = allDefSetWork.TotalAmountDispWayCd;

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                // 2007.03.05 added by T-Kidate
                allDefSet.MemberInfoDispCd = allDefSetWork.MemberInfoDispCd;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                // �� 20061205 18322 d
				//allDefSet.CarFixSelectMethod   = allDefSetWork.CarFixSelectMethod;
                //allDefSet.LandTransBranchCd    = allDefSetWork.LandTransBranchCd;
                // �� 20061205 18322 d

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
                allDefSet.EraNameDispCd1 = allDefSetWork.EraNameDispCd1;
                allDefSet.EraNameDispCd2 = allDefSetWork.EraNameDispCd2;
                allDefSet.EraNameDispCd3 = allDefSetWork.EraNameDispCd3;
                allDefSet.GoodsNoInpDiv = allDefSetWork.GoodsNoInpDiv;
                allDefSet.CnsTaxAutoCorrDiv = allDefSetWork.CnsTaxAutoCorrDiv;
                allDefSet.RemainCntMngDiv = allDefSetWork.RemainCntMngDiv;
                allDefSet.MemoMoveDiv = allDefSetWork.MemoMoveDiv;
                allDefSet.RemCntAutoDspDiv = allDefSetWork.RemCntAutoDspDiv;
                allDefSet.TtlAmntDspRateDivCd = allDefSetWork.TtlAmntDspRateDivCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

                // --- ADD  ���r��  2010/01/18 ---------->>>>>
                allDefSet.DefTtlBillOutput = allDefSetWork.DefTtlBillOutput;
                allDefSet.DefDtlBillOutput = allDefSetWork.DefDtlBillOutput;
                allDefSet.DefSlTtlBillOutput = allDefSetWork.DefSlTtlBillOutput;
                // --- ADD  ���r��  2010/01/18 ----------<<<<<
                //ADD 2011/07/19
                //�d���E�o�׌㐔�\���敪
                allDefSet.DtlCalcStckCntDsp = allDefSetWork.DtlCalcStckCntDsp;
                //ADD 2011/07/19
                allDefSet.GoodsStockMSTBootDiv = allDefSetWork.GoodsStockMstBootDiv; // ���i�݌ɋN���敪 // ADD ���N 2013/05/02 Redmine#35434 
                
                _static_AllDefSetTable[keyOfHashTable] = allDefSet;

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�S�̏����l�ݒ�N���X�ˑS�̏����l�ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="allDefSet">�S�̏����l�ݒ�N���X</param>
		/// <returns>�Ԕ̏��ޑS�̐ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �S�̏����l�ݒ�N���X����S�̏����l�ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M�� </br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private AllDefSetWork CopyToAllDefSetWorkFromAllDefSet(AllDefSet allDefSet)
		{
			AllDefSetWork allDefSetWork = new AllDefSetWork();

			allDefSetWork.CreateDateTime      = allDefSet.CreateDateTime;
			allDefSetWork.UpdateDateTime      = allDefSet.UpdateDateTime;
			allDefSetWork.EnterpriseCode      = allDefSet.EnterpriseCode;
			allDefSetWork.FileHeaderGuid      = allDefSet.FileHeaderGuid;
			allDefSetWork.UpdEmployeeCode     = allDefSet.UpdEmployeeCode;
			allDefSetWork.UpdAssemblyId1      = allDefSet.UpdAssemblyId1;
			allDefSetWork.UpdAssemblyId2      = allDefSet.UpdAssemblyId2;
			allDefSetWork.LogicalDeleteCode   = allDefSet.LogicalDeleteCode;
			allDefSetWork.SectionCode         = allDefSet.SectionCode;

            // �� 20061205 18322 d
			//allDefSetWork.DistrictCode         = allDefSet.DistrictCode;
			//allDefSetWork.DefDispAddrCd1       = allDefSet.DefDispAddrCd1;
			//allDefSetWork.DefDispAddrCd2       = allDefSet.DefDispAddrCd2;
			//allDefSetWork.DefDispAddrCd3       = allDefSet.DefDispAddrCd3;
            // �� 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
//			allDefSetWork.DefDispAddrCd4       = allDefSet.DefDispAddrCd4;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			
            // �� 20061205 18322 d
			//allDefSetWork.DefDispAddress       = allDefSet.DefDispAddress.TrimEnd();
			//allDefSetWork.No88AutoLiaCalcDiv   = allDefSet.No88AutoLiaCalcDiv;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			allDefSetWork.CustCdAutoNumbering  = allDefSet.CustCdAutoNumbering;
			allDefSetWork.CustomerDelChkDivCd  = allDefSet.CustomerDelChkDivCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            allDefSetWork.DefDspCustTtlDay     = allDefSet.DefDspCustTtlDay;
			allDefSetWork.DefDspCustClctMnyDay = allDefSet.DefDspCustClctMnyDay;
			allDefSetWork.DefDspClctMnyMonthCd = allDefSet.DefDspClctMnyMonthCd;
			allDefSetWork.IniDspPrslOrCorpCd   = allDefSet.IniDspPrslOrCorpCd;
			allDefSetWork.InitDspDmDiv         = allDefSet.InitDspDmDiv;
			allDefSetWork.DefDspBillPrtDivCd   = allDefSet.DefDspBillPrtDivCd;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            allDefSetWork.MemberInfoDispCd = allDefSet.MemberInfoDispCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // �� 20061205 18322 d
			//allDefSetWork.CarFixSelectMethod   = allDefSet.CarFixSelectMethod;
            //allDefSetWork.LandTransBranchCd    = allDefSet.LandTransBranchCd;
            // �� 20061205 18322 d

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			allDefSetWork.TotalAmountDispWayCd = allDefSet.TotalAmountDispWayCd;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            allDefSetWork.EraNameDispCd1 = allDefSet.EraNameDispCd1;
            allDefSetWork.EraNameDispCd2 = allDefSet.EraNameDispCd2;
            allDefSetWork.EraNameDispCd3 = allDefSet.EraNameDispCd3;

            allDefSetWork.GoodsNoInpDiv = allDefSet.GoodsNoInpDiv;
            allDefSetWork.CnsTaxAutoCorrDiv = allDefSet.CnsTaxAutoCorrDiv;
            allDefSetWork.RemainCntMngDiv = allDefSet.RemainCntMngDiv;
            allDefSetWork.MemoMoveDiv = allDefSet.MemoMoveDiv;
            allDefSetWork.RemCntAutoDspDiv = allDefSet.RemCntAutoDspDiv;
            allDefSetWork.TtlAmntDspRateDivCd = allDefSet.TtlAmntDspRateDivCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            allDefSetWork.DefTtlBillOutput = allDefSet.DefTtlBillOutput;
            allDefSetWork.DefDtlBillOutput = allDefSet.DefDtlBillOutput;
            allDefSetWork.DefSlTtlBillOutput = allDefSet.DefSlTtlBillOutput;            
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD 2011/07/19
            //�d���E�o�׌㐔�\���敪
            allDefSetWork.DtlCalcStckCntDsp = allDefSet.DtlCalcStckCntDsp;
            //ADD 2011/07/19
            allDefSetWork.GoodsStockMstBootDiv = allDefSet.GoodsStockMSTBootDiv;// ���i�݌ɋN���敪 // ADD ���N 2013/05/02 Redmine#35434 
            return allDefSetWork;
		}
		#endregion
		
		#region -- �Ώۃf�[�^�`�F�b�N�A���̎擾 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �Ώۃf�[�^�`�F�b�N
		/// </summary>
		/// <param name="allDefSet">�Ώۃf�[�^</param>
		/// <param name="allDefSetPara">�p�����[�^</param>
		/// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �Ώۃf�[�^�ƃp�����[�^���r���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// </remarks>
		private bool checkTarGetData(AllDefSet allDefSet, AllDefSet allDefSetPara)
		{
			// ��ƃR�[�h���r
			if (allDefSetPara.EnterpriseCode != null)
			{
				if (!allDefSetPara.EnterpriseCode.Equals(allDefSet.EnterpriseCode))
					return false;
			}
			return true;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_���̎擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>���_����</returns>
		/// <remarks>
		/// <br>Note       : ���_�R�[�h���狒�_���̂��擾���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// <br></br>
		/// <br>Note       : ���_���擾���i�Ή�</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Update Note: 2005.10.20</br>
		/// </remarks>
		public string GetSectionName(string enterpriseCode, string sectionCode)
		{
			//----- ueno add ---------- start 2008.01.31
			// ���[�J���c�a���_�Ή�
			ConstructSecInfoAcs();
			//----- ueno add ---------- end 2008.01.31

			foreach (SecInfoSet	secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				if (secInfoSet.SectionCode.TrimEnd() == "0")
				{
					return "���o�^";
				}
				else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
					(secInfoSet.LogicalDeleteCode == 0))
				{
					return secInfoSet.SectionGuideNm;
				}
			}
			return "���o�^";

//			SecInfoSet secInfoSet = new SecInfoSet();
//			SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
//
//			int status = secInfoSetAcs.Read(out secInfoSet, enterpriseCode, sectionCode);
//
//			switch (status)
//			{
//				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//				{
//					if (secInfoSet.LogicalDeleteCode == 0)
//					{
//						return secInfoSet.SectionGuideNm;
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���_���擾����
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̌����������s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.03</br>
		/// <br></br>
		/// <br>Note       : ���_���擾���i�Ή�</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Update Note: 2005.10.20</br>
		/// </remarks>
		private int GetAliveSectionCodeList(out ArrayList retList, string enterpriseCode)
        {
            retList = new ArrayList();

			//----- ueno add ---------- start 2008.01.31
			// ���[�J���c�a���_�Ή�
			ConstructSecInfoAcs();
			//----- ueno add ---------- end 2008.01.31

            if (this._secInfoAcs.SecInfoSetList.Length != 0)
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.31 TAKAHASHI DELETE START
                    //retList.Add(secInfoSet.SectionCode);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.31 TAKAHASHI DELETE END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.31 TAKAHASHI ADD START
                    if (this._secInfoAcs.SecInfoSet.MainOfficeFuncFlag == 0)
                    {
                        // �{�Ћ@�\�t���O��0:���_�̏ꍇ�A�����_�̃f�[�^�݂̂��i�[
                        if (this._secInfoAcs.SecInfoSet.SectionCode.TrimEnd() == secInfoSet.SectionCode.TrimEnd())
                        {
                            retList.Add(secInfoSet.SectionCode);
                        }
                    }
                    else
                    {
                        // �{�Ћ@�\�t���O��1:�{�Ђ̏ꍇ�A�S���_�̃f�[�^���i�[
                        retList.Add(secInfoSet.SectionCode);
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.31 TAKAHASHI ADD END
                }
                return 0;
            }
            else
            {
                return -1;
            }

            //			SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            //			ArrayList wkList = new ArrayList();
            //			retList = new ArrayList();
            //			int status = secInfoSetAcs.SearchAll(out wkList, enterpriseCode);
            //
            //			if(status==0)
            //			{
            //				foreach(SecInfoSet secInfoSet in wkList)
            //				{
            //					if(secInfoSet.LogicalDeleteCode == 0)
            //					{
            //						retList.Add(secInfoSet.SectionCode);
            //					}
            //				}
            //			}
            //			return status;
        }

        // 2007.05.23 deleted by T-Kidate : MobileKing�ł͎g�p���Ȃ����߁@<<<<<<<<<<<<<<<<<<<<<<Start
        /*----------------------------------------------------------------------------------*/
        ///// <summary>
        ///// AreaKindTable�쐬
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : AreaKindTable�쐬���쐬���܂��B</br>
        ///// <br>Programmer : 23006�@���� ���q</br>
        ///// <br>Date       : 2006.09.05</br>
        ///// </remarks>
        //private void MakeAreaKindTable(string enterpriseCode)
        //{
            
            //// �ǋ於�̓ǂݍ���(����̂�)
            //// �_���폜���͊܂܂Ȃ�
            //if (this.areaKindTable.Count == 0)
            //{
            //    this.areaKindList = new ArrayList();

            //    int status = this.areaGroupAcs.SearchAll(out areaKindList, enterpriseCode);

            //    foreach (AreaGroup areaGroupWork in areaKindList)
            //    {
            //        if ((areaGroupWork.LogicalDeleteCode == 0) &&
            //            (areaGroupWork.AreaKind == 0))
            //        {
            //            this.areaKindTable.Add(areaGroupWork.AreaGroupCode, areaGroupWork.Clone());
            //        }
            //    }
            //}
            //                                                                <<<<<<<<<<<<End
        //}
		/*----------------------------------------------------------------------------------*/
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<End

		/// <summary>
		/// �ǋ於�̎擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="districtCd">�ǋ�R�[�h</param>
		/// <returns>�ǋ於��</returns>
		/// <remarks>
		/// <br>Note       : �ǋ�R�[�h����ǋ於�̂��擾���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date       : 2005.10.04</br>
		/// <br></br>
		/// <br>Update Note : 2005.12.19  23006 ���� ���q</br>
		/// <br>				�E�L���b�V����{���Ή�</br>
		/// </remarks>
		private string GetDistrictName(string enterpriseCode, int districtCd)
		{
			//nt status = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2007.05.23 T-Kidate DELETE START
			//AreaGroup areaGroup = null;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<2007.05.23 T-Kidate DELETE END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI DELETE START
            //// �ǋ於�̓ǂݍ���(����̂�)
            //// �_���폜���͊܂܂Ȃ�
            //if 	(this.areaKindTable.Count == 0)
            //{	
            //    this.areaKindList = new ArrayList();

            //    status = this.areaGroupAcs.SearchAll(out areaKindList, enterpriseCode);
			
            //    foreach(AreaGroup areaGroupWork in areaKindList)
            //    {
            //        if ((areaGroupWork.LogicalDeleteCode == 0) &&
            //            (areaGroupWork.AreaKind == 0))
            //        {
            //            this.areaKindTable.Add(areaGroupWork.AreaGroupCode, areaGroupWork.Clone());
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI DELETE END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.05 TAKAHASHI ADD START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate DELETE START
            //this.MakeAreaKindTable(enterpriseCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate DELETE END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.05 TAKAHASHI ADD END
						
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.23 T-Kidate DELETE START   
			// �ǋ�Buffer����擾
            //areaGroup = (AreaGroup)this.areaKindTable[districtCd];
								
            //// �Y���R�[�h�����������ꍇStatus��NotFound��ݒ�
            //if (areaGroup == null)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //    {
            //        if (areaGroup.LogicalDeleteCode != 0)
            //        {
            //            return "�폜��";
            //        }
            //        else
            //        {
            //            // �ǋ於�̂�Ԃ�
            //            return areaGroup.AreaName;
            //        }
					
            //    }
            //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //    {
            //        return "���o�^";
            //    }
            //    default:
            //    {
                    return "";
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.23 T-Kidate DELETE END
			
        }
		#endregion
	}
}
