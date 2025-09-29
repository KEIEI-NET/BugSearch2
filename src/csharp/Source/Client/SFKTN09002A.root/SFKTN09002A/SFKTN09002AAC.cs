using System;
using System.Collections;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using System.Collections.Generic;
using System.Text;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���_���e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_���e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2004.03.22</br>
	/// <br></br>
    /// <br>Update Note: 2005.06.21 22025 �c�� �L</br>
    /// <br>					�E�ۑ����ɃX�y�[�X�J�b�g�Ή�</br>
    /// <br>Update Note: 2006.12.13 22022 �i�� �m�q</br>
    /// <br>					1.SF�ł𗬗p���g�єł��쐬</br>
    /// <br>					2.���Ж���1��K�{���͂֕ύX</br>
    /// <br>Update Note: 2007.05.23 980023 �ђJ �k��</br>
    /// <br>               �E���_���̎擾��������[�g�ɏC��</br>
    /// <br>Update Note: 2007.05.29 22022 �i�� �m�q</br>
    /// <br>					1.���Ж��̃R�[�h���_���폜�E���o�^�������ꍇ�̕\�����̂̎d�l�ύX</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�(���_���)</br>
	/// -----------------------------------------------------------------------
	/// <br>UpdateNote : 2008.02.18 30167�@��� �O�M</br>
	/// <br>           : �S�Ћ��_�R�[�h���X�y�[�X����"000000"�֕ύX</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/06/03 30414�@�E�@�K�j</br>
    /// <br>           :�u���_���́v�u�����N�����v�ǉ��A�u�����_�`�[���Ж�����敪�v�u�\���Q�`�P�O�v�폜</br>
    /// </remarks>
	public class SecInfoSetAcs : IGeneralGuideData
	{

		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ISecInfoSetDB _iSecInfoSetDB = null;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        private SectionInfoLcDB _sectionInfoLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

		/// <summary>���Ж��̊i�[�o�b�t�@</summary>
		private Hashtable _companyNmTable = null;

        /* --- DEL 2008/12/11 --------------------------------------------------------------------->>>>>
        // �� 2007.10.5 add///////////////////////////////
        /// <summary>���_�q�ɖ��̊i�[�o�b�t�@</summary>
        private Hashtable _sectWarehouseNmTable = null;
        // �� 2007.10.5 add//////////////////////////////
           --- DEL 2008/12/11 ---------------------------------------------------------------------<<<<<*/
        
        // 2005.12.15 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		private SecInfoAcs _secInfoAcs;
		// 2005.12.15 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
        private WarehouseAcs _warehouseAcs;

        private Dictionary<string, Warehouse> _warehouseDic;
        // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<

        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

        /// <summary>
		/// ���_���e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���_���e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�(���_���)</br>
        /// </remarks>
		public SecInfoSetAcs()
		{
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
            //// 2005.12.15 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// ----- iitani c ----- start 2007.05.23
            ////this._secInfoAcs = new SecInfoAcs();
            //this._secInfoAcs = new SecInfoAcs(1);   // searchMode(0: 1:)
            //// ----- iitani c ----- end 2007.05.23
            //// 2005.12.15 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

			this._companyNmTable = null;

			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iSecInfoSetDB = (ISecInfoSetDB)MediationSecInfoSetDB.GetSecInfoSetDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iSecInfoSetDB = null;
			}
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._sectionInfoLcDB = new SectionInfoLcDB();
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

            // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
            this._warehouseAcs = new WarehouseAcs();
            ReadWarehouse();
            // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
        }

        // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
        private void ReadWarehouse()
        {
            this._warehouseDic = new Dictionary<string, Warehouse>();

            ArrayList retList;

            try
            {
                int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }
        // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<

        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
        /// <summary>
        /// ���[�J���c�a�Ή����_���N���X�쐬����
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : ���_���N���X�쐬�𖢍쐬���ɍ쐬���܂��B</br>
        /// <br>Programmer : 96012 ���F�@�]</br>
        /// <br>Date       : 2008.02.12</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                this._secInfoAcs.ResetSectionInfo();
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
        }
        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

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
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSecInfoSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// ���_���ǂݍ��ݏ���
		/// </summary>
		/// <param name="secInfoSet">���_���I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public int Read(out SecInfoSet secInfoSet, string enterpriseCode, string sectionCode)
		{			
			try
			{
				secInfoSet = null;
				SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
				secInfoSetWork.EnterpriseCode = enterpriseCode;
				secInfoSetWork.SectionCode = sectionCode;

                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// XML�֕ϊ����A������̃o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
                //
				////�]�ƈ��ǂݍ���
				//int status = this._iSecInfoSetDB.Read(ref parabyte,0);
                //
				//if (status == 0)
				//{
				//	// XML�̓ǂݍ���
				//	secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
				//	// �N���X�������o�R�s�[
				//	secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);
				//}
                int status;
                if (_isLocalDBRead)
                {
                    //�]�ƈ��ǂݍ���
                    status = this._sectionInfoLcDB.Read(ref secInfoSetWork, 0);
                    if (status == 0)
                    {
                        // �N���X�������o�R�s�[
                        secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);
                    }
                }
                else
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
                    
                    //�]�ƈ��ǂݍ���
                    status = this._iSecInfoSetDB.Read(ref parabyte,0);
                    if (status == 0)
                    {
                    	// XML�̓ǂݍ���
                    	secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
                    	// �N���X�������o�R�s�[
                    	secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);
                    }
                }
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
				
				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				secInfoSet = null;
				//�I�t���C������null���Z�b�g
				this._iSecInfoSetDB = null;
				return -1;
			}
		}

		/// <summary>
		/// ���_���N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���_���N���X</returns>
		/// <remarks>
		/// <br>Note       : ���_���N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public SecInfoSet Deserialize(string fileName)
		{
			SecInfoSet secInfoSet = null;

			// �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
			SecInfoSetWork secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(fileName,typeof(SecInfoSetWork));

			//�f�V���A���C�Y���ʂ����_���N���X�փR�s�[
			if (secInfoSetWork != null) secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

			return secInfoSet;
		}

		/// <summary>
		/// ���_���List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���_���N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : ���_��񃊃X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			al.Clear();

			// �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
			SecInfoSetWork[] secInfoSetWorks;
			secInfoSetWorks = (SecInfoSetWork[])XmlByteSerializer.Deserialize(fileName,typeof(SecInfoSetWork[]));

			//�f�V���A���C�Y���ʂ����_���N���X�փR�s�[
			if (secInfoSetWorks != null) 
			{
				al.Capacity = secInfoSetWorks.Length;
				for(int i=0; i < secInfoSetWorks.Length; i++)
				{
					al.Add(CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// ���_���o�^�E�X�V����
		/// </summary>
		/// <param name="secInfoSet">���_���N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref SecInfoSet secInfoSet)
		{
			//���_���N���X���狒�_��񃏁[�J�[�N���X�Ƀ����o�R�s�[
			SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			int status = 0;
			try
			{
				//���_��񏑂�����
				status = this._iSecInfoSetDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
					secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
					// �N���X�������o�R�s�[
					secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

                    return 0;
                    // 2006.09.01 N.TANIFUJI ADD
                    //status = this._secInfoAcs.ResetSectionInfo();
                }

			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iSecInfoSetDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ���_���V���A���C�Y����
		/// </summary>
		/// <param name="secInfoSet">�V���A���C�Y�Ώۋ��_���N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���_���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void Serialize(SecInfoSet secInfoSet, string fileName)
		{
			//���_���N���X���狒�_��񃏁[�J�[�N���X�Ƀ����o�R�s�[
			SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
			//���_��񃏁[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(secInfoSetWork,fileName);
		}

		/// <summary>
		/// ���_���List�V���A���C�Y����
		/// </summary>
		/// <param name="secInfoSetList">�V���A���C�Y�Ώۋ��_���List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���_���List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void ListSerialize(ArrayList secInfoSetList, string fileName)
		{
			SecInfoSetWork[] secInfoSetWorks = new SecInfoSetWork[secInfoSetList.Count];
			for(int i= 0; i < secInfoSetList.Count; i++)
			{
				secInfoSetWorks[i] = CopyToSecInfoSetWorkFromSecInfoSet((SecInfoSet)secInfoSetList[i]);
			}
			//���_��񃏁[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(secInfoSetWorks,fileName);
		}

		/// <summary>
		/// ���_���_���폜����
		/// </summary>
		/// <param name="secInfoSet">���_���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̘_���폜���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int LogicalDelete(ref SecInfoSet secInfoSet)
		{
			try
			{
				SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
				// ���_���_���폜
				int status = this._iSecInfoSetDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
					secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
					// �N���X�������o�R�s�[
					secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

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
				this._iSecInfoSetDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���_��񕨗��폜����
		/// </summary>
		/// <param name="secInfoSet">���_���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̕����폜���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Delete(SecInfoSet secInfoSet)
		{
			try
			{
				SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
				// ���_��񕨗��폜
				int status = this._iSecInfoSetDB.Delete(parabyte);

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                ConstructSecInfoAcs();
                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

                // 2006.09.01 N.TANIFUJI ADD
                this._secInfoAcs.ResetSectionInfo();
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                
                return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iSecInfoSetDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���_��񌟍������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���_��񌟍��������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt, string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode,0);
		}

		/// <summary>
		/// ���_��񌟍������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���_��񌟍��������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt, string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// ���_��񐔌�������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_��񐔂̌������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		private int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			secInfoSetWork.EnterpriseCode = enterpriseCode;

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //// XML�֕ϊ����A������̃o�C�i����
			//byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
            //
			//// ���_��񌟍�
			//int status = this._iSecInfoSetDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            int status;
            if (_isLocalDBRead)
            {
                List<SecInfoSetWork> workList = new List<SecInfoSetWork>();
                // ���_��񌟍�
                status = this._sectionInfoLcDB.Search(out workList, secInfoSetWork, 0, logicalMode);
                retTotalCnt = workList.Count;
            }
            else
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
                
                // ���_��񌟍�
                status = this._iSecInfoSetDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

			if (status != 0) retTotalCnt = 0;
				
			return status;
		}


		/// <summary>
		/// ���_���S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null);
		}

		/// <summary>
		/// ���_��񌟍������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode)
		{

			bool nextData;
			int	 retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
		}

		/// <summary>
		/// �����w�苒�_��񌟍������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevSecInfoSet">�O��ŏI���_���f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ċ��_���̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, SecInfoSet prevSecInfoSet)
		{			
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevSecInfoSet);
		}

		/// <summary>
		/// �����w�苒�_��񌟍������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevSecInfoSet">�O��ŏI���_���f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ċ��_���̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, SecInfoSet prevSecInfoSet)
		{			
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevSecInfoSet);
		}

		/// <summary>
		/// ���_���_���폜��������
		/// </summary>
		/// <param name="secInfoSet">���_���I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̕������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Revival(ref SecInfoSet secInfoSet)
		{
			try
			{
				SecInfoSetWork secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(secInfoSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);
				// ��������
				int status = this._iSecInfoSetDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
					secInfoSetWork = (SecInfoSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SecInfoSetWork));
					// �N���X�������o�R�s�[
					secInfoSet = CopyToSecInfoSetFromSecInfoSetWork(secInfoSetWork);

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
				this._iSecInfoSetDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}


		/// <summary>
		/// ���_��񌟍�����
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevSecInfoSet">�O��ŏI���_���f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̌����������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SecInfoSet prevSecInfoSet)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			if (prevSecInfoSet != null) secInfoSetWork = CopyToSecInfoSetWorkFromSecInfoSet(prevSecInfoSet);
			secInfoSetWork.EnterpriseCode = enterpriseCode;
			
			//���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;

			SecInfoSetWork[] al;
			retList = new ArrayList();
			retList.Clear();

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			byte[] retbyte;

			// ���_��񌟍�
			int status = 0;
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //if (readCnt == 0)
			//{
			//	status = this._iSecInfoSetDB.Search(out retbyte,parabyte,0,logicalMode);
			//}
			//else
			//{
			//	status = this._iSecInfoSetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte,0,logicalMode,readCnt);
			//}
            //
			//if (status == 0)
			//{
			//	// XML�̓ǂݍ���
			//	al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));
            //
			//	for(int i = 0;i < al.Length;i++)
			//	{
			//		//�T�[�`���ʎ擾
			//		SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];
			//		//���_���N���X�փ����o�R�s�[
			//		retList.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork));
			//	}
			//}
            if (_isLocalDBRead)
            {
                List<SecInfoSetWork> workList = new List<SecInfoSetWork>();
                // ���_��񌟍�
                status = this._sectionInfoLcDB.Search(out workList, secInfoSetWork, 0, logicalMode);
                if (status == 0)
                {
                    //���_���N���X�փ����o�R�s�[
                    for (int i = 0; i < workList.Count; i++)
                    {
                        //���_���N���X�փ����o�R�s�[
                        retList.Add(CopyToSecInfoSetFromSecInfoSetWork(workList[i]));
                    }
                }
            }
            else
            {
                if (readCnt == 0)
                {
                	status = this._iSecInfoSetDB.Search(out retbyte,parabyte,0,logicalMode);
                }
                else
                {
                	status = this._iSecInfoSetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte,0,logicalMode,readCnt);
                }
                if (status == 0)
                {
                	// XML�̓ǂݍ���
                	al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));
                	for(int i = 0;i < al.Length;i++)
                	{
                		//�T�[�`���ʎ擾
                		SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];
                		//���_���N���X�փ����o�R�s�[
                		retList.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork));
                	}
                }
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

		/// <summary>
		/// ���_��񌟍������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="dispAllSecInfo">"�S��"�ݒ�L��[true:�ݒ�,false:���ݒ�]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode, bool dispAllSecInfo)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			secInfoSetWork.EnterpriseCode = enterpriseCode;
            ArrayList ar = new ArrayList();
            
            // XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			byte[] retbyte;

            SecInfoSet[] secInfoSets;
			// �]�ƈ��T�[�`
            int status = 0;
			// 2005.12.15 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//          int i;
//          SecInfoSetWork[] secInfoSetWorks;
//			int status = this._iSecInfoSetDB.Search(out retbyte, parabyte, 0,0);
			// 2005.12.15 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END





            if (status == 0)
            {
                // "�S��"�\�����䔻��
                if (dispAllSecInfo)
                {
                    SecInfoSet secInfoSet = new SecInfoSet();
                    
                    secInfoSet.EnterpriseCode = enterpriseCode;

					//----- ueno upd ---------- start 2008.02.18
					// �S�Ћ��ʋ��_�R�[�h��"000000"��ݒ肷��
                    //secInfoSet.SectionCode    = "            ";
					secInfoSet.SectionCode = "00";
					//----- ueno upd ---------- end 2008.02.18

                    secInfoSet.SectionGuideNm = "�S��";
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//					secInfoSet.CompanyName1   = "�S��";
//					secInfoSet.CompanyName2   = "�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@";
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
            
                    ar.Add(secInfoSet.Clone());
                }


                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                ConstructSecInfoAcs();
                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

                // 2005.12.15 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                // XML�̓Ǎ���
//              secInfoSetWorks = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));
//              for(i = 0;i<secInfoSetWorks.Length;i++)
//              {
//                  // �T�[�`���ʎ擾
//                  SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)secInfoSetWorks[i];
//					ar.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork).Clone());
//              }
				// 2005.12.15 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            
				// 2005.12.15 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				ArrayList secarrlist = new ArrayList();
				for (int idx = 0; idx<this._secInfoAcs.SecInfoSetList.Length; idx++)
				{
					ar.Add(this._secInfoAcs.SecInfoSetList[idx].Clone());

				}
				// 2005.12.15 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                if (ar.Count != 0)
                {
                    secInfoSets = (SecInfoSet[])ar.ToArray(typeof(SecInfoSet));
                    retbyte = XmlByteSerializer.Serialize(secInfoSets);
                    XmlByteSerializer.ReadXml(ref ds ,retbyte);
                } 
                else 
                {
                    status = 4;
                }
            }
				
			return status;
		}

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
		/// <summary>
		/// ���Ж��̂P�E�Q�擾����
		/// </summary>
		/// <param name="companyName1">���Ж��̂P</param>
		/// <param name="companyName2">���Ж��̂Q</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="companyNameCd">���Ж��̃R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃R�[�h���玩�Ж��̂P�ƂQ���擾���܂�</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.13</br>
		/// </remarks>
		public int GetCompanyName( out string companyName1, out string companyName2, string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			CompanyNm companyNm = null;
            
			companyName1 = "";
			companyName2 = "";

			if( companyNameCd > 0 ) {

				// ���Ж��̓ǂݍ���
				status = ReadCompanyNm( out companyNm, enterpriseCode, companyNameCd );
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( companyNm.LogicalDeleteCode == 0 ) {
						companyName1 = companyNm.CompanyName1;
						companyName2 = companyNm.CompanyName2;
					}
					else {
                        companyName1 = "�폜��";
                        // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                        companyName2 = "";
                        //companyName2 = "�폜��";
                        // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
						status = -1;
					}
				}
				else {
                    companyName1 = "���o�^";
                    // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                    companyName2 = "";
                    //companyName2 = "���o�^";
                    // 2007.05.29 DANJO CHG  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				}
			}

			return status;
		}

		/// <summary>
		/// ���Ж��̓Ǎ�����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="companyNameCd">���Ж��̃R�[�h</param>
		/// <returns>STATUS</returns>
		public int ReadCompanyNm( out CompanyNm companyNm, string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			companyNm = null;

//			if( this._companyNmTable == null ) {
				status = SetCompanyNmTable( enterpriseCode );
				if( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// �ǂݍ��ݎ��s
					return status;
				}
//			}

			// �e�[�u���ɃL�[�����݂��Ă���
			if( this._companyNmTable.ContainsKey( companyNameCd ) == true ) {
				companyNm = ( ( CompanyNm )this._companyNmTable[ companyNameCd ] ).Clone();
			}
			else {
				status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

			return status;
		}

		/// <summary>
		/// ���Ж��̌�������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̌����������s���A�o�b�t�@�Ɋi�[���܂��B</br>
		/// <br>Programmer : �H�R�@����</br>
		/// <br>Date       : 2005.09.13</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		private int SetCompanyNmTable( string enterpriseCode )
		{
			
            //this._companyNmTable = new Hashtable();
            //CompanyNmAcs companyNmAcs = new CompanyNmAcs();
            //ArrayList retList = null;
            //this._companyNmTable.Clear();
            //int status = companyNmAcs.SearchAll( out retList, enterpriseCode );
            //if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
            //    foreach( CompanyNm companyNm in retList ) {
            //        if( this._companyNmTable.ContainsKey( companyNm.CompanyNameCd ) == false ) {
            //            this._companyNmTable.Add( companyNm.CompanyNameCd, companyNm.Clone() );
            //        }
            //    }
            //}


            // 2006.09.08 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._companyNmTable == null)
            {
                this._companyNmTable = new Hashtable();
                CompanyNmAcs companyNmAcs = new CompanyNmAcs();
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                companyNmAcs.IsLocalDBRead = _isLocalDBRead;
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
                ArrayList retList = null;
                this._companyNmTable.Clear();
                status = companyNmAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CompanyNm companyNm in retList)
                    {
                        if (this._companyNmTable.ContainsKey(companyNm.CompanyNameCd) == false)
                        {
                            this._companyNmTable.Add(companyNm.CompanyNameCd, companyNm.Clone());
                        }
                    }
                }
            }
            // 2006.09.08 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
            

			return status;
		}

// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        
        // �� 2007.10.5 add//////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ���_�q�ɖ��̂̎擾����
        /// </summary>
        /// <param name="warehouseName">���_�q�ɖ���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">���_�q�ɃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�q�ɃR�[�h���狒�_�q�ɖ��̂��擾���܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
        /// 
        public int GetWarehouseName(out string warehouseName, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            int status = 0;
            // --- CHG 2008/12/11 --------------------------------------------------------------------->>>>>
            //warehouseName = "";

            //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //Warehouse warehouse = null;

            //this._sectWarehouseNmTable = new Hashtable();

            //WarehouseAcs warehouseAcs = new WarehouseAcs();
            //// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            //warehouseAcs.IsLocalDBRead = _isLocalDBRead;
            //// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

            //// ���_�q�ɖ��̂̓Ǎ�
            //status = warehouseAcs.Read(out warehouse, enterpriseCode, sectionCode, warehouseCode);

            //if (warehouseCode != "")
            //{
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        if (warehouse.LogicalDeleteCode == 0)
            //        {
            //            warehouseName = warehouse.WarehouseName;
            //        }

            //        else
            //        {
            //            warehouseName = "�폜��";
            //            //status = -1;  // DEL 2008/06/03
            //        }
            //    }

            //    else
            //    {
            //        warehouseName = "���o�^";
            //    }
            //}

            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // �ǂݍ��ݎ��s
            //    return status;
            //}
            if (this._warehouseDic.ContainsKey(warehouseCode.Trim()))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim()].WarehouseName.Trim();
            }
            else
            {
                warehouseName = "";
            }
            // --- CHG 2008/12/11 ---------------------------------------------------------------------<<<<<

            return status;
        }
        // �� 2007.10.5 add//////////////////////////////////////////////////////////////////////////////////////////


		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���_��񃏁[�N�N���X�ˋ��_���N���X�j
		/// </summary>
		/// <param name="secInfoSetWork">���_��񃏁[�N�N���X</param>
		/// <returns>���_���N���X</returns>
		/// <remarks>
		/// <br>Note       : ���_��񃏁[�N�N���X���狒�_���N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private SecInfoSet CopyToSecInfoSetFromSecInfoSetWork(SecInfoSetWork secInfoSetWork)
		{

			SecInfoSet secInfoSet = new SecInfoSet();
			
			secInfoSet.CreateDateTime		= secInfoSetWork.CreateDateTime;
			secInfoSet.UpdateDateTime		= secInfoSetWork.UpdateDateTime;
			secInfoSet.EnterpriseCode		= secInfoSetWork.EnterpriseCode;
			secInfoSet.FileHeaderGuid		= secInfoSetWork.FileHeaderGuid;
			secInfoSet.UpdEmployeeCode		= secInfoSetWork.UpdEmployeeCode;
			secInfoSet.UpdAssemblyId1		= secInfoSetWork.UpdAssemblyId1;
			secInfoSet.UpdAssemblyId2		= secInfoSetWork.UpdAssemblyId2;
			secInfoSet.LogicalDeleteCode	= secInfoSetWork.LogicalDeleteCode;
			
			secInfoSet.SectionCode			= secInfoSetWork.SectionCode;
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSet.CompanyPr			= secInfoSetWork.CompanyPr;
//			secInfoSet.CompanyName1			= secInfoSetWork.CompanyName1;
//			secInfoSet.CompanyName2			= secInfoSetWork.CompanyName2;
//			secInfoSet.PostNo				= secInfoSetWork.PostNo;
//			secInfoSet.Address1				= secInfoSetWork.Address1;
//			secInfoSet.Address2				= secInfoSetWork.Address2;
//			secInfoSet.Address3				= secInfoSetWork.Address3;
//			secInfoSet.Address4				= secInfoSetWork.Address4;
//			secInfoSet.CompanyTelNo1		= secInfoSetWork.CompanyTelNo1;
//			secInfoSet.CompanyTelNo2		= secInfoSetWork.CompanyTelNo2;
//			secInfoSet.CompanyTelNo3		= secInfoSetWork.CompanyTelNo3;
//			secInfoSet.CompanyTelTitle1		= secInfoSetWork.CompanyTelTitle1;
//			secInfoSet.CompanyTelTitle2		= secInfoSetWork.CompanyTelTitle2;
//			secInfoSet.CompanyTelTitle3		= secInfoSetWork.CompanyTelTitle3;
//			secInfoSet.TransferGuidance		= secInfoSetWork.TransferGuidance;
//			secInfoSet.AccountNoInfo1		= secInfoSetWork.AccountNoInfo1;
//			secInfoSet.AccountNoInfo2		= secInfoSetWork.AccountNoInfo2;
//			secInfoSet.AccountNoInfo3		= secInfoSetWork.AccountNoInfo3;
//			secInfoSet.CompanySetNote1		= secInfoSetWork.CompanySetNote1;
//			secInfoSet.CompanySetNote2		= secInfoSetWork.CompanySetNote2;
//			secInfoSet.SlipCompanyNmCd		= secInfoSetWork.SlipCompanyNmCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //secInfoSet.OthrSlipCompanyNmCd	= secInfoSetWork.OthrSlipCompanyNmCd;  // DEL 2008/06/03
			secInfoSet.SectionGuideNm		= secInfoSetWork.SectionGuideNm;
			secInfoSet.MainOfficeFuncFlag	= secInfoSetWork.MainOfficeFuncFlag;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //secInfoSet.SecCdForNumbering	= secInfoSetWork.SecCdForNumbering;  // DEL 2008/06/03
			secInfoSet.CompanyNameCd1		= secInfoSetWork.CompanyNameCd1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			secInfoSet.CompanyNameCd2		= secInfoSetWork.CompanyNameCd2;
			secInfoSet.CompanyNameCd3		= secInfoSetWork.CompanyNameCd3;
			secInfoSet.CompanyNameCd4		= secInfoSetWork.CompanyNameCd4;
			secInfoSet.CompanyNameCd5		= secInfoSetWork.CompanyNameCd5;
			secInfoSet.CompanyNameCd6		= secInfoSetWork.CompanyNameCd6;
			secInfoSet.CompanyNameCd7		= secInfoSetWork.CompanyNameCd7;
			secInfoSet.CompanyNameCd8		= secInfoSetWork.CompanyNameCd8;
			secInfoSet.CompanyNameCd9		= secInfoSetWork.CompanyNameCd9;
			secInfoSet.CompanyNameCd10		= secInfoSetWork.CompanyNameCd10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // �� 2007.10.5 add//////////////////////////////////////////////////
            secInfoSet.SectWarehouseCd1     = secInfoSetWork.SectWarehouseCd1;
            secInfoSet.SectWarehouseCd2     = secInfoSetWork.SectWarehouseCd2;
            secInfoSet.SectWarehouseCd3     = secInfoSetWork.SectWarehouseCd3;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSet.SectWarehouseNm1     = secInfoSetWork.SectWarehouseNm1;
            secInfoSet.SectWarehouseNm2     = secInfoSetWork.SectWarehouseNm2;
            secInfoSet.SectWarehouseNm3     = secInfoSetWork.SectWarehouseNm3;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // �� 2007.10.5 add/////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSet.SectionGuideSnm = secInfoSetWork.SectionGuideSnm;
            secInfoSet.IntroductionDate = secInfoSetWork.IntroductionDate;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

			// ���Ж��̎擾
            //for( int ix = 0; ix < 10; ix++ ) {  // DEL 2008/06/03
			for( int ix = 0; ix < 1; ix++ ) {  // ADD 2008/06/03
				string companyName1 = null;
				string companyName2 = null;
				GetCompanyName( out companyName1, out companyName2, 
					secInfoSetWork.EnterpriseCode, secInfoSet.GetCompanyNameCd( ix ) );
				secInfoSet.SetCompanyName( companyName1 + "�@" + companyName2, ix );
			}
// 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 add//////////////////////////////////////////////////////////////////
            //���_�q�ɖ��̎擾
            for (int ix = 0; ix < 3; ix++) {
                string warehouse1 = null;
                GetWarehouseName(out warehouse1, secInfoSetWork.EnterpriseCode,
                    secInfoSetWork.SectionCode, secInfoSet.GetSectWarehouseCd(ix));
                secInfoSet.SetSectWarehouseNm(warehouse1, ix);
            }
            // �� 2007.10.5 add//////////////////////////////////////////////////////////////////


                ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //			secInfoSet.BillCompanyNmPrtCd	= secInfoSetWork.BillCompanyNmPrtCd;
                //			
                //			switch (secInfoSetWork.SlipCompanyNmCd)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.SlipCompanyNm = "���_�ݒ�";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.SlipCompanyNm = "���Аݒ�";
                //					break;
                //				}
                //			}
                //			switch (secInfoSetWork.OthrSlipCompanyNmCd)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.OthrSlipCompanyNm = "�����_���";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.OthrSlipCompanyNm = "�����_���";
                //					break;
                //				}
                //			}
                //			switch (secInfoSetWork.MainOfficeFuncFlag)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.MainOfficeFuncNm = "���_";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.MainOfficeFuncNm = "�{��";
                //					break;
                //				}
                //			}
                //			switch (secInfoSetWork.BillCompanyNmPrtCd)
                //			{
                //				case 0:
                //				{
                //					secInfoSet.BillCompanyNmPrtNm = "���_�ݒ�";
                //					break;
                //				}
                //				case 1:
                //				{
                //					secInfoSet.BillCompanyNmPrtNm = "���Аݒ�";
                //					break;
                //				}
                //			}
                //			// �� �v�ύX /////////////////////////////////////////////////////////////////
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                return secInfoSet;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���_���N���X�ˋ��_��񃏁[�N�N���X�j
		/// </summary>
		/// <param name="secInfoSet">���_��񃏁[�N�N���X</param>
		/// <returns>���_���N���X</returns>
		/// <remarks>
		/// <br>Note       : ���_���N���X���狒�_��񃏁[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private SecInfoSetWork CopyToSecInfoSetWorkFromSecInfoSet(SecInfoSet secInfoSet)
		{

			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			
			secInfoSetWork.CreateDateTime		= secInfoSet.CreateDateTime;
			secInfoSetWork.UpdateDateTime		= secInfoSet.UpdateDateTime;
			secInfoSetWork.EnterpriseCode		= secInfoSet.EnterpriseCode.Trim();
			secInfoSetWork.FileHeaderGuid		= secInfoSet.FileHeaderGuid;
			secInfoSetWork.UpdEmployeeCode		= secInfoSet.UpdEmployeeCode;
			secInfoSetWork.UpdAssemblyId1		= secInfoSet.UpdAssemblyId1;
			secInfoSetWork.UpdAssemblyId2		= secInfoSet.UpdAssemblyId2;
			secInfoSetWork.LogicalDeleteCode	= secInfoSet.LogicalDeleteCode;

			secInfoSetWork.SectionCode			= secInfoSet.SectionCode;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetWork.CompanyPr			= secInfoSet.CompanyPr.TrimEnd();
//			secInfoSetWork.CompanyName1			= secInfoSet.CompanyName1.TrimEnd();
//			secInfoSetWork.CompanyName2			= secInfoSet.CompanyName2.TrimEnd();
//			secInfoSetWork.PostNo				= secInfoSet.PostNo;
//			secInfoSetWork.Address1				= secInfoSet.Address1.TrimEnd();
//			secInfoSetWork.Address2				= secInfoSet.Address2;
//			secInfoSetWork.Address3				= secInfoSet.Address3.TrimEnd();
//			secInfoSetWork.Address4				= secInfoSet.Address4.TrimEnd();
//			secInfoSetWork.CompanyTelNo1		= secInfoSet.CompanyTelNo1.Trim();
//			secInfoSetWork.CompanyTelNo2		= secInfoSet.CompanyTelNo2.Trim();
//			secInfoSetWork.CompanyTelNo3		= secInfoSet.CompanyTelNo3.Trim();
//			secInfoSetWork.CompanyTelTitle1		= secInfoSet.CompanyTelTitle1.TrimEnd();
//			secInfoSetWork.CompanyTelTitle2		= secInfoSet.CompanyTelTitle2.TrimEnd();
//			secInfoSetWork.CompanyTelTitle3		= secInfoSet.CompanyTelTitle3.TrimEnd();
//			secInfoSetWork.TransferGuidance		= secInfoSet.TransferGuidance.TrimEnd();
//			secInfoSetWork.AccountNoInfo1		= secInfoSet.AccountNoInfo1.TrimEnd();
//			secInfoSetWork.AccountNoInfo2		= secInfoSet.AccountNoInfo2.TrimEnd();
//			secInfoSetWork.AccountNoInfo3		= secInfoSet.AccountNoInfo3.TrimEnd();
//			secInfoSetWork.CompanySetNote1		= secInfoSet.CompanySetNote1.TrimEnd();
//			secInfoSetWork.CompanySetNote2		= secInfoSet.CompanySetNote2.TrimEnd();
//			secInfoSetWork.SlipCompanyNmCd		= secInfoSet.SlipCompanyNmCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //secInfoSetWork.OthrSlipCompanyNmCd	= secInfoSet.OthrSlipCompanyNmCd;  // DEL 2008/06/03
			secInfoSetWork.SectionGuideNm		= secInfoSet.SectionGuideNm.TrimEnd();
			secInfoSetWork.MainOfficeFuncFlag	= secInfoSet.MainOfficeFuncFlag;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //secInfoSetWork.SecCdForNumbering	= secInfoSet.SecCdForNumbering;  // DEL 2008/06/03
			secInfoSetWork.CompanyNameCd1		= secInfoSet.CompanyNameCd1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
			secInfoSetWork.CompanyNameCd2		= secInfoSet.CompanyNameCd2;
			secInfoSetWork.CompanyNameCd3		= secInfoSet.CompanyNameCd3;
			secInfoSetWork.CompanyNameCd4		= secInfoSet.CompanyNameCd4;
			secInfoSetWork.CompanyNameCd5		= secInfoSet.CompanyNameCd5;
			secInfoSetWork.CompanyNameCd6		= secInfoSet.CompanyNameCd6;
			secInfoSetWork.CompanyNameCd7		= secInfoSet.CompanyNameCd7;
			secInfoSetWork.CompanyNameCd8		= secInfoSet.CompanyNameCd8;
			secInfoSetWork.CompanyNameCd9		= secInfoSet.CompanyNameCd9;
			secInfoSetWork.CompanyNameCd10		= secInfoSet.CompanyNameCd10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 add//////////////////////////////////////////////////
            secInfoSetWork.SectWarehouseCd1		= secInfoSet.SectWarehouseCd1;
            secInfoSetWork.SectWarehouseCd2     = secInfoSet.SectWarehouseCd2;
            secInfoSetWork.SectWarehouseCd3     = secInfoSet.SectWarehouseCd3;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetWork.SectWarehouseNm1     = secInfoSet.SectWarehouseNm1;
            secInfoSetWork.SectWarehouseNm2     = secInfoSet.SectWarehouseNm2;
            secInfoSetWork.SectWarehouseNm3     = secInfoSet.SectWarehouseNm3;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // �� 2007.10.5 add/////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            secInfoSetWork.SectionGuideSnm = secInfoSet.SectionGuideSnm;
            secInfoSetWork.IntroductionDate = secInfoSet.IntroductionDate;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			secInfoSetWork.BillCompanyNmPrtCd	= secInfoSet.BillCompanyNmPrtCd;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			return secInfoSetWork;
		}
        /// <summary>
        /// ���_���K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="dispAllSecInfo">"�S��"�ݒ�L��[true:�ݒ�,false:���ݒ�]</param>
        /// <param name="secInfoSet">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: ���_���ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2005.05.07</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, out SecInfoSet secInfoSet)
        {
            int status = -1;
            secInfoSet = new SecInfoSet();

            TableGuideParent tableGuideParent = new TableGuideParent("SECINFOSETGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();
 
            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            // "�S��"�\������t���O
            inObj.Add("DispAllSecInfo", dispAllSecInfo);
            
            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                secInfoSet.EnterpriseCode       = retObj["EnterpriseCode"].ToString(); 
                secInfoSet.SectionCode          = retObj["SectionCode"].ToString();
                secInfoSet.SectionGuideNm       = retObj["SectionGuideNm"].ToString();

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
				secInfoSet.CompanyNameCd1		= Convert.ToInt32( retObj["CompanyNameCd1"] );
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
				secInfoSet.CompanyNameCd2		= Convert.ToInt32( retObj["CompanyNameCd2"] );
				secInfoSet.CompanyNameCd3		= Convert.ToInt32( retObj["CompanyNameCd3"] );
				secInfoSet.CompanyNameCd4		= Convert.ToInt32( retObj["CompanyNameCd4"] );
				secInfoSet.CompanyNameCd5		= Convert.ToInt32( retObj["CompanyNameCd5"] );
				secInfoSet.CompanyNameCd6		= Convert.ToInt32( retObj["CompanyNameCd6"] );
				secInfoSet.CompanyNameCd7		= Convert.ToInt32( retObj["CompanyNameCd7"] );
				secInfoSet.CompanyNameCd8		= Convert.ToInt32( retObj["CompanyNameCd8"] );
				secInfoSet.CompanyNameCd9		= Convert.ToInt32( retObj["CompanyNameCd9"] );
				secInfoSet.CompanyNameCd10		= Convert.ToInt32( retObj["CompanyNameCd10"] );
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//				secInfoSet.CompanyName1         = retObj["CompanyName1"].ToString();
//				secInfoSet.CompanyName2         = retObj["CompanyName2"].ToString();
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                // �� 2007.10.5 add/////////////////////////////////////////////////////////
                secInfoSet.SectWarehouseCd1     = retObj["SectWarehouseCd1"].ToString();
                secInfoSet.SectWarehouseCd2     = retObj["SectWarehouseCd2"].ToString();
                secInfoSet.SectWarehouseCd3     = retObj["SectWarehouseCd3"].ToString();
                secInfoSet.SectWarehouseNm1     = retObj["SectWarehouseNm1"].ToString();
                secInfoSet.SectWarehouseNm2     = retObj["SectWarehouseNm2"].ToString();
                secInfoSet.SectWarehouseNm3     = retObj["SectWarehouseNm3"].ToString();
                // �� 2007.10.5 add////////////////////////////////////////////////////////

                status = 0;
            } 
                // �L�����Z��
            else 
            {
                status = 1;
            }
            
            return status;
        }
        
        #region IGeneralGuidData Method
        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 18012 Y.Sasaki</br>
        /// <br>Date		: 2005.05.07</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status   = -1;
            string enterpriseCode = "";
            bool dispAllSecInfo = false;
            
            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            } 
                // ��ƃR�[�h�ݒ薳��
            else 
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }
            
            // "�S��"�\������t���O
            if (inParm.ContainsKey("DispAllSecInfo"))
            {
                dispAllSecInfo = (bool)inParm["DispAllSecInfo"];
            } 
            else 
            {
            }
            
            // ���_���ݒ�e�[�u���Ǎ���
            status = Search(ref guideList, enterpriseCode, dispAllSecInfo);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                {
                    status = 4;
                    break;
                }
                default:
                    status = -1;
                    break;
            }
            return status;
        }
        #endregion
    }
}
