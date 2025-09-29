using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �q�Ƀe�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// -----------------------------------------------------------------------------------
    /// <br>Note       : �q�Ƀe�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22022 �i�� �m�q</br>
    /// <br>Date       : 2006.12.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: Read�A�K�C�h��Search �̏��������[�J��DB����̓Ǎ��ɕύX</br>
    /// <br>Programmer	: 980023�@�ђJ �k��</br>
    /// <br>Date		: 2007.04.04</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ���_�R�[�h�̔�r�̍ہATrimEnd����������Ԃōs���悤�ɏC��</br>
    /// <br>Programmer	: 980023�@�ђJ �k��</br>
    /// <br>Date		: 2007.05.25</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �K�C�h�ɘ_���폜�̃f�[�^���o�Ă��܂��Ă����̂��C��</br>
    /// <br>Programmer	: 980023�@�ђJ �k��</br>
    /// <br>Date		: 2007.06.05</br>
    /// -----------------------------------------------------------------------------------
	/// <br>UpdateNote	: Read�A�K�C�h��Search �̏����������[�gDB����̓Ǎ��ɕύX</br>
	/// <br>Programmer	: 30167�@���@�O�M</br>
	/// <br>Date		: 2007.09.12</br>
	/// -----------------------------------------------------------------------------------
	/// <br>Update Note : ���[�J���c�a�Ή��i�R�����g����Ă������������A�y�ѕs�������ǉ��j</br>
	/// <br>Programmer	: 30167 ���@�O�M</br>
	/// <br>Date		: 2008.01.31</br>
	/// -----------------------------------------------------------------------------------
    /// <br>Update Note : �u���Ӑ�v�u��Ǒq�Ɂv�u�݌Ɉꊇ���}�[�N�v�ǉ��A�u�q�ɔ��l2�`5�v�폜</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/06/04</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : �n���f�B�U������</br>
    /// <br>Programmer	: 31739 �݁@��</br>
    /// <br>Date		: 2019/11/13</br>
    /// -----------------------------------------------------------------------------------
    /// <br>Update Note : �n���f�B�d���ꎞ�݌ɓo�^�Ή�</br>
    /// <br>Programmer	: 31739 �݁@��</br>
    /// <br>Date		: 2020/04/08</br>
    /// -----------------------------------------------------------------------------------
    /// </remarks>
    public class WarehouseAcs : IGeneralGuideData
    {
        # region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        IWarehouseDB _iwarehouseDB = null;
        WarehouseLcDB _warehouseLcDB = null;  // iitani a

        // �L���b�V���p�n�b�V���e�[�u��
        static private Hashtable _WarehouseTable = null;

        // �K�C�h�ݒ�t�@�C����
        private const string GUIDE_XML_FILENAME = "WAREHOUSEGUIDEPARENT.XML";   // XML�t�@�C����

        // �K�C�h�p�����[�^
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // ��ƃR�[�h

        // �K�C�h���ڃ^�C�v
        private const string GUIDE_TYPE_STR = "System.String";              // String�^

        // �K�C�h���ږ�
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";                // ���_�R�[�h
        private const string GUIDE_WAREHOUSECODE_TITLE = "WarehouseCode";              // �q�ɃR�[�h
        private const string GUIDE_WAREHOUSENAME_TITLE = "WarehouseName";              // �q�ɖ���
        private const string GUIDE_WAREHOUSENOTE1_TITLE = "WarehouseNote1";             // �q�ɔ��l1
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string GUIDE_WAREHOUSENOTE2_TITLE = "WarehouseNote2";             // �q�ɔ��l2
        private const string GUIDE_WAREHOUSENOTE3_TITLE = "WarehouseNote3";             // �q�ɔ��l3
        private const string GUIDE_WAREHOUSENOTE4_TITLE = "WarehouseNote4";             // �q�ɔ��l4
        private const string GUIDE_WAREHOUSENOTE5_TITLE = "WarehouseNote5";             // �q�ɔ��l5
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";                 // ���Ӑ�R�[�h
        private const string GUIDE_MAINMNGWAREHOUSECD_TITLE = "MainMngWarehouseCd";     // ��Ǒq�ɃR�[�h
        private const string GUIDE_STOCKBLANKREMARK_TITLE = "StockBlnktRemark";         // �݌Ɉꊇ���}�[�N
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

        //----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		//----- ueno add ---------- end 2008.01.31

        # endregion

        # region Constructor

        /// <summary>
        /// �q�Ƀe�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�Ƀe�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public WarehouseAcs()
        {
            _WarehouseTable = null;
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iwarehouseDB = (IWarehouseDB)MediationWarehouseDB.GetWarehouseDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iwarehouseDB = null;
            }

            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._warehouseLcDB = new WarehouseLcDB();   // iitani a
        }

        # endregion

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

        #region GetOnlineMode

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iwarehouseDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Read Methods

        /// <summary>
        /// �q�ɓǂݍ��ݏ���
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɏ���ǂݍ��݂܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Read(out Warehouse warehouse, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            try
            {
                warehouse = null;
                int status = 0;
                WarehouseWork warehouseWork = new WarehouseWork();
                warehouseWork.EnterpriseCode = enterpriseCode;
                warehouseWork.SectionCode = sectionCode;
                warehouseWork.WarehouseCode = warehouseCode;

				//----- ueno upd ---------- start 2008.01.31
				// ���[�J��
				if (_isLocalDBRead)
				{
					status = this._warehouseLcDB.Read(ref warehouseWork, 0);
				}
				// �����[�g
				else
				{
					//----- ueno ---------- start 2007.09.12
					// XML�֕ϊ����A������̃o�C�i���� iitani d
					byte[] parabyte = XmlByteSerializer.Serialize(warehouseWork);
					
					// �q�ɓǂݍ���
					status = this._iwarehouseDB.Read(ref parabyte, 0);
					//----- ueno ---------- end   2007.09.12

					if (status == 0)
					{
						//----- ueno ---------- start 2007.09.12
						// XML�̓ǂݍ��� iitani d
						warehouseWork = (WarehouseWork)XmlByteSerializer.Deserialize(parabyte, typeof(WarehouseWork));
						//----- ueno ---------- end   2007.09.12
						
						// �N���X�������o�R�s�[
						//warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);
					}
				}

				if (status == 0)
				{
					// �N���X�������o�R�s�[
					warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);
				}
				//----- ueno upd ---------- end 2008.01.31

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                warehouse = null;
                //�I�t���C������null���Z�b�g
                this._iwarehouseDB = null;
                return -1;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// �q�ɓo�^�E�X�V����
        /// </summary>
        /// <param name="warehouse">�q��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɏ��̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Write(ref Warehouse warehouse)
        {
            // �q�ɃN���X����q�Ƀ��[�J�[�N���X�Ƀ����o�R�s�[
            WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);

            ArrayList paraList = new ArrayList();

            paraList.Add(warehouseWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //�q�ɏ�������
                status = this._iwarehouseDB.Write(ref paraObj);
                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    warehouseWork = (WarehouseWork)paraList[0];

                    // �N���X�������o�R�s�[
                    warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);

                    // �L���b�V���X�V
                    UpdateCache(warehouse);

                }
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// �q�ɘ_���폜����
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɏ��̘_���폜���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int LogicalDelete(ref Warehouse warehouse)
        {
            int status = 0;

            try
            {
                // �q�ɕϊ�
                ArrayList paraLst = new ArrayList();
                WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);
                paraLst.Add(warehouseWork);
                object paraObj = paraLst;

                // �_���폜
                status = this._iwarehouseDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    warehouseWork = (WarehouseWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);

                    // �L���b�V���X�V
                    UpdateCache(warehouse);

                    Warehouse deleteLineup = new Warehouse();
                    deleteLineup.EnterpriseCode = warehouse.EnterpriseCode;
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iwarehouseDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// �q�ɘ_���폜��������
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɏ��̕������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Revival(ref Warehouse warehouse)
        {
            try
            {
                WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(warehouseWork);

                object paraObj = paraLst;

                // ��������
                int status = this._iwarehouseDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    warehouseWork = (WarehouseWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    warehouse = CopyToWarehouseFromWarehouseWork(warehouseWork);

                    UpdateCache(warehouse);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iwarehouseDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// �q�ɕ����폜����
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɏ��̕����폜���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Delete(Warehouse warehouse)
        {
            try
            {
                WarehouseWork warehouseWork = CopyToWarehouseWorkFromWarehouse(warehouse);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(warehouseWork);

                // �q�ɕ����폜
                int status = this._iwarehouseDB.Delete(parabyte);

                if (status == 0)
                {
                    RemoveCache(warehouse);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iwarehouseDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// �q�ɑS���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }
        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// �n���f�B�p�q�ɑS���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 31739 ��</br>
        /// <br>Date       : 2019.11.13</br>
        /// </remarks>
        public int SearchHandy(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchHandyProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }
        // --- ADD 2019/11/13 ----------<<<<<
        // --- ADD 2020/04/08 ---------->>>>>
        /// <summary>
        /// �n���f�B�p�q�ɖ��擾�����i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ����擾���܂�</br>
        /// <br>Programmer : 31739 ��</br>
        /// <br>Date       : 2020.04.08</br>
        /// </remarks>
        public int ReadHandy(out object warehouseObj, object enterpriseCode, object sectioncode, object warehousecode)
        {
            string ent = enterpriseCode as string;
            string sec = sectioncode as string;
            string warecd = warehousecode as string;
            Warehouse result = new Warehouse();
            int status = this.Read(out result, ent, sec, warecd);
            ArrayList resultArrayList = new ArrayList();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            	if (result != null)
            	{
                    WarehouseWork resultWk = CopyToWarehouseWorkFromWarehouse(result);

                    resultArrayList.Add(resultWk);
                }
            }

            warehouseObj = (object)resultArrayList;
            return status;
        }
        // --- ADD 2020/04/08 ----------<<<<<

        /// <summary>
        /// �q�ɑS��������(���_�i����)�i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">���_�R�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null);
        }

        /// <summary>
        /// �q�Ɍ��������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// �q�Ɍ�������(���_�i�荞��)�i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">�q�ɃR�[�h</param>		        
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// �q�Ɍ�������(���_�i����)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevWarehouse��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevWarehouse">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̌����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, Warehouse prevWarehouse)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            if (prevWarehouse != null) warehouseWork = CopyToWarehouseWorkFromWarehouse(prevWarehouse);

            warehouseWork.EnterpriseCode = enterpriseCode;
            //warehouseWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            retTotalCnt = 0;
            int status_o = 0;

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = warehouseWork;
            object retobj = null;

			//----- ueno upd ---------- start 2008.01.31
			// ���[�J��
			if (_isLocalDBRead)
			{
                List<WarehouseWork> warehouseWorkList = new List<WarehouseWork>();
				status_o = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, logicalMode);

				if (status_o == 0)
				{
					ArrayList al = new ArrayList();
					al.AddRange(warehouseWorkList);
					retobj = (object)al;
				}
			}
			// �����[�g
			else
			{
                status_o = this._iwarehouseDB.Search(out retobj, paraobj, 0, logicalMode);
			}
			//----- ueno upd ---------- end 2008.01.31

            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        wkList = retobj as ArrayList;

                        if (wkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in wkList)
                            {
                                // ----- iitani c ---------- start 2007.05.25
                                //if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                //    ((wkLineupWork.SectionCode == sectionCode) || (wkLineupWork.SectionCode == "")))
                                if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                    ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                                // ----- iitani c ---------- end 2007.05.25
                                {
                                    //�����o�R�s�[
                                    retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                }
                            }

                            retTotalCnt = retList.Count;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status_o;
                    }
            }

            return status_o;

        }

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// �q�Ɍ�������(���_�i����)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevWarehouse��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevWarehouse">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ̌����������s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private int SearchHandyProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, Warehouse prevWarehouse)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            //if (prevWarehouse != null) warehouseWork = CopyToWarehouseWorkFromWarehouse(prevWarehouse);

            warehouseWork.EnterpriseCode = enterpriseCode;
            //warehouseWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            retTotalCnt = 0;
            int status_o = 0;

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = warehouseWork;
            object retobj = null;

            //----- ueno upd ---------- start 2008.01.31
            // ���[�J��
            if (_isLocalDBRead)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"c:\work\20191118_9332ALog.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "Local!");
                }
                List<WarehouseWork> warehouseWorkList = new List<WarehouseWork>();
                status_o = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, logicalMode);

                if (status_o == 0)
                {
                    ArrayList al = new ArrayList();
                    al.AddRange(warehouseWorkList);
                    retobj = (object)al;
                }
            }
            // �����[�g
            else
            {
                status_o = this._iwarehouseDB.Search(out retobj, paraobj, 0, logicalMode);
            }
            //----- ueno upd ---------- end 2008.01.31

            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        wkList = retobj as ArrayList;

                        if (wkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in wkList)
                            {
                                // ----- iitani c ---------- start 2007.05.25
                                //if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                //    ((wkLineupWork.SectionCode == sectionCode) || (wkLineupWork.SectionCode == "")))
                                if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                    ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                                // ----- iitani c ---------- end 2007.05.25
                                {
                                    //�����o�R�s�[
                                    //retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                    retList.Add(wkLineupWork);
                                }
                            }

                            retTotalCnt = retList.Count;
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status_o;
                    }
            }

            return status_o;

        }
        // --- ADD 2019/11/13 ----------<<<<<

        /// <summary>
        /// �q�Ƀ}�X�^���������i���[�J��DB(�K�C�h)�p�j
        /// </summary>
        /// <param name="retList">�擾���ʊi�[�pArrayList</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^�̃��[�J��DB�����������s���A�擾���ʂ�ArryList�ŕԂ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public int SearchLocalDB(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            WarehouseWork warehouseWork = new WarehouseWork();
            warehouseWork.EnterpriseCode = enterpriseCode;
            warehouseWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            int status = 0;

            List<WarehouseWork> warehouseWorkList = null;
            // ----- 2007.06.05 ---------- iitani c start ���[�J��DB�̑q�ɂ���_���폜���܂߂�Search�������P�[�X�͖����Ƒz��
            //status = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, ConstantManagement.LogicalMode.GetData01);
            status = this._warehouseLcDB.Search(out warehouseWorkList, warehouseWork, 0, ConstantManagement.LogicalMode.GetData0);
            // ----- 2007.06.05 ---------- iitani c start 

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (warehouseWorkList != null)
                        {
                            foreach (WarehouseWork wkLineupWork in warehouseWorkList)
                            {
                                // ----- iitani c ---------- start 2007.05.25
                                //if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                //    ((wkLineupWork.SectionCode == sectionCode) || (wkLineupWork.SectionCode == "")))
                                if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                    ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                                // ----- iitani c ---------- end 2007.05.25
                                {
                                    //�����o�R�s�[
                                    retList.Add(CopyToWarehouseFromWarehouseWork(wkLineupWork));
                                }
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        return status;
                    }
            }

            return status;
        }


        #endregion

        #region Cache Methods

        /// <summary>
        /// �L���b�V�����f�[�^�o�^�X�V����
        /// </summary>
        /// <param name="warehouse">�q�ɃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �L���b�V�����̃f�[�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void UpdateCache(Warehouse warehouse)
        {
            if (_WarehouseTable == null)
            {
                _WarehouseTable = new Hashtable();
            }

            Hashtable warehouseTable = null;		// �q�ɃR�[�h�ʃn�b�V���e�[�u��

            // �n�b�V���e�[�u���ɃL�����A���o�^����Ă���
            if (_WarehouseTable.ContainsKey(warehouse.SectionCode) == true)
            {
                // �q�ɃR�[�h�ʃn�b�V���e�[�u���擾
                warehouseTable = (Hashtable)_WarehouseTable[warehouse.SectionCode];
            }
            // �n�b�V���e�[�u���ɃL�����A���o�^����Ă��Ȃ�
            else
            {
                // �q�ɃR�[�h�ʃn�b�V���e�[�u���𐶐�
                warehouseTable = new Hashtable();
                // �L�����A�ʃn�b�V���e�[�u���ɒǉ�
                _WarehouseTable.Add(warehouse.SectionCode, warehouseTable);
            }
        }

        /// <summary>
        /// �L���b�V�����f�[�^�폜����
        /// </summary>
        /// <param name="Warehouse">���q�ɃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �L���b�V�����f�[�^����w�肳�ꂽ�q�ɃI�u�W�F�N�g���폜���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void RemoveCache(Warehouse Warehouse)
        {
            if (_WarehouseTable == null)
            {
                // �f�[�^�����݂��Ă��Ȃ�
                return;
            }

            Hashtable warehouseTable = null;		// �q�ɃR�[�h�ʃn�b�V���e�[�u��

            // �n�b�V���e�[�u���ɃL�����A���o�^����Ă���
            if (_WarehouseTable.ContainsKey(Warehouse.SectionCode) == false)
            {
                // �f�[�^�����݂��Ă��Ȃ�
                return;
            }
            // �q�ɃR�[�h�ʃn�b�V���e�[�u���擾
            warehouseTable = (Hashtable)_WarehouseTable[Warehouse.SectionCode];
        }

        # endregion

        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�q�Ƀ��[�N�N���X�ˑq�Ɂj
        /// </summary>
        /// <param name="warehouseWork">�q�Ƀ��[�N�N���X</param>
        /// <returns>�q��</returns>
        /// <remarks>
        /// <br>Note       : �q�Ƀ��[�N�N���X����q�ɂփ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private Warehouse CopyToWarehouseFromWarehouseWork(WarehouseWork warehouseWork)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.CreateDateTime = warehouseWork.CreateDateTime;
            warehouse.UpdateDateTime = warehouseWork.UpdateDateTime;
            warehouse.FileHeaderGuid = warehouseWork.FileHeaderGuid;
            warehouse.LogicalDeleteCode = warehouseWork.LogicalDeleteCode;
            warehouse.EnterpriseCode = warehouseWork.EnterpriseCode;

            warehouse.SectionCode = warehouseWork.SectionCode;
            warehouse.WarehouseCode = warehouseWork.WarehouseCode;
            warehouse.WarehouseName = warehouseWork.WarehouseName;
            warehouse.WarehouseNote1 = warehouseWork.WarehouseNote1;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.WarehouseNote2 = warehouseWork.WarehouseNote2;
            warehouse.WarehouseNote3 = warehouseWork.WarehouseNote3;
            warehouse.WarehouseNote4 = warehouseWork.WarehouseNote4;
            warehouse.WarehouseNote5 = warehouseWork.WarehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.CustomerCode = warehouseWork.CustomerCode;
            warehouse.MainMngWarehouseCd = warehouseWork.MainMngWarehouseCd;
            warehouse.StockBlnktRemark = warehouseWork.StockBlnktRemark;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return warehouse;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�q�Ɂˑq�Ƀ��[�N�N���X�j
        /// </summary>
        /// <param name="warehouse">�q�ɃN���X</param>
        /// <returns>�q�Ƀ��[�N</returns>
        /// <remarks>
        /// <br>Note       : �q�ɂ���q�Ƀ��[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private WarehouseWork CopyToWarehouseWorkFromWarehouse(Warehouse warehouse)
        {
            WarehouseWork warehouseWork = new WarehouseWork();

            warehouseWork.CreateDateTime = warehouse.CreateDateTime;
            warehouseWork.UpdateDateTime = warehouse.UpdateDateTime;
            warehouseWork.EnterpriseCode = warehouse.EnterpriseCode;
            warehouseWork.FileHeaderGuid = warehouse.FileHeaderGuid;

            warehouseWork.LogicalDeleteCode = warehouse.LogicalDeleteCode;
            warehouseWork.SectionCode = warehouse.SectionCode;
            warehouseWork.WarehouseCode = warehouse.WarehouseCode;
            warehouseWork.WarehouseName = warehouse.WarehouseName;
            warehouseWork.WarehouseNote1 = warehouse.WarehouseNote1;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouseWork.WarehouseNote2 = warehouse.WarehouseNote2;
            warehouseWork.WarehouseNote3 = warehouse.WarehouseNote3;
            warehouseWork.WarehouseNote4 = warehouse.WarehouseNote4;
            warehouseWork.WarehouseNote5 = warehouse.WarehouseNote5;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouseWork.CustomerCode = warehouse.CustomerCode;
            warehouseWork.MainMngWarehouseCd = warehouse.MainMngWarehouseCd;
            warehouseWork.StockBlnktRemark = warehouse.StockBlnktRemark;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return warehouseWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (�K�C�h�I���f�[�^�ˎd��Ȗڐݒ�}�X�^�N���X)
        /// </summary>
        /// <param name="guideData">�K�C�h�I���f�[�^</param>
        /// <returns>�d��Ȗڐݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�I���f�[�^����d��Ȗڐݒ�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private Warehouse CopyToWarehouseFromGuideData(Hashtable guideData)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.SectionCode = (string)guideData[GUIDE_SECTIONCODE_TITLE];       // ���_�R�[�h
            warehouse.WarehouseCode = (string)guideData[GUIDE_WAREHOUSECODE_TITLE];     // �q�ɃR�[�h
            warehouse.WarehouseName = (string)guideData[GUIDE_WAREHOUSENAME_TITLE];     // �q�ɖ���
            warehouse.WarehouseNote1 = (string)guideData[GUIDE_WAREHOUSENOTE1_TITLE];    // �q�ɔ��l1
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            warehouse.WarehouseNote2 = (string)guideData[GUIDE_WAREHOUSENOTE2_TITLE];    // �q�ɔ��l2
            warehouse.WarehouseNote3 = (string)guideData[GUIDE_WAREHOUSENOTE3_TITLE];    // �q�ɔ��l3
            warehouse.WarehouseNote4 = (string)guideData[GUIDE_WAREHOUSENOTE4_TITLE];    // �q�ɔ��l4
            warehouse.WarehouseNote5 = (string)guideData[GUIDE_WAREHOUSENOTE5_TITLE];    // �q�ɔ��l5
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if ((string)guideData[GUIDE_CUSTOMERCODE_TITLE] == null)
            {
                warehouse.CustomerCode = 0;
            }
            else
            {
                if ((string)guideData[GUIDE_CUSTOMERCODE_TITLE] == "")
                {
                    warehouse.CustomerCode = 0;
                }
                else
                {
                    warehouse.CustomerCode = int.Parse((string)guideData[GUIDE_CUSTOMERCODE_TITLE]);  // ���Ӑ�R�[�h
                }
            }
            warehouse.MainMngWarehouseCd = (string)guideData[GUIDE_MAINMNGWAREHOUSECD_TITLE];  // ��Ǒq�ɃR�[�h
            warehouse.StockBlnktRemark = (string)guideData[GUIDE_STOCKBLANKREMARK_TITLE];      // �݌Ɉꊇ���}�[�N
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            return warehouse;
        }

        /// <summary>
        /// DataRow�R�s�[�����i�q�ɃN���X�˃K�C�h�pDataRow�j
        /// </summary>
        /// <param name="guideRow">�K�C�h�pDataRow</param>
        /// <param name="warehouse">�q�ɃN���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃN���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void CopyToGuideRowFromWarehouse(ref DataRow guideRow, Warehouse warehouse)
        {
            guideRow[GUIDE_SECTIONCODE_TITLE] = warehouse.SectionCode;        // ���_�R�[�h
            guideRow[GUIDE_WAREHOUSECODE_TITLE] = warehouse.WarehouseCode;      // �q�ɃR�[�h
            guideRow[GUIDE_WAREHOUSENAME_TITLE] = warehouse.WarehouseName;      // �q�ɖ���
            guideRow[GUIDE_WAREHOUSENOTE1_TITLE] = warehouse.WarehouseNote1;     // �q�ɔ��l1
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            guideRow[GUIDE_WAREHOUSENOTE2_TITLE] = warehouse.WarehouseNote2;     // �q�ɔ��l2
            guideRow[GUIDE_WAREHOUSENOTE3_TITLE] = warehouse.WarehouseNote3;     // �q�ɔ��l3
            guideRow[GUIDE_WAREHOUSENOTE4_TITLE] = warehouse.WarehouseNote4;     // �q�ɔ��l4
            guideRow[GUIDE_WAREHOUSENOTE5_TITLE] = warehouse.WarehouseNote5;     // �q�ɔ��l5
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            guideRow[GUIDE_CUSTOMERCODE_TITLE] = warehouse.CustomerCode;               // ���Ӑ�R�[�h
            guideRow[GUIDE_MAINMNGWAREHOUSECD_TITLE] = warehouse.MainMngWarehouseCd;   // ��Ǒq�ɃR�[�h
            guideRow[GUIDE_STOCKBLANKREMARK_TITLE] = warehouse.StockBlnktRemark;       // �݌Ɉꊇ���}�[�N
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
        }

        #endregion

        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="jnlItemsSetDisp">�擾�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int ExecuteGuid(out Warehouse warehouse, string enterpriseCode, string sectionCode)
        {
            int status = -1;
            warehouse = new Warehouse();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);   // ��ƃR�[�h
            //inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);        // ���_�R�[�h  // DEL 2008/06/04
            
            //// --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            //if (sectionCode != "")
            //{
            //    inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);        // ���_�R�[�h
            //}
            //// --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // �K�C�h�N��
            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // �I���f�[�^�̎擾
                warehouse = CopyToWarehouseFromGuideData(retObj);
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="jnlItemsSetDisp">�擾�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 20414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int ExecuteGuid(out Warehouse warehouse, string enterpriseCode)
        {
            int status = -1;
            status = ExecuteGuid(out warehouse, enterpriseCode, "");

            return status;
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

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

            // ���_�R�[�h�ݒ�L��
            if (inParm.ContainsKey(GUIDE_SECTIONCODE_TITLE))
            {
                sectionCode = inParm[GUIDE_SECTIONCODE_TITLE].ToString();
            }

			//----- ueno upd ---------- start 2008.01.31
			// �}�X�^�e�[�u���Ǎ���
            ArrayList retList;

			// ���[�J��
			if (_isLocalDBRead)
            {
				status = this.SearchLocalDB(out retList, enterpriseCode, sectionCode);
			}
			// �����[�g
			else
			{
				status = this.Search(out retList, enterpriseCode, sectionCode);
			}
			//----- ueno upd ---------- end 2008.01.31

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
        /// <param name="inParm">�i������</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList, Hashtable inParm)
        {
            Warehouse warehouse = null;
            DataRow guideRow = null;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while (dataCnt < retList.Count)
            {
                warehouse = (Warehouse)retList[dataCnt];
                guideRow = retDataSet.Tables[0].NewRow();
                // �f�[�^�R�s�[����
                CopyToGuideRowFromWarehouse(ref guideRow, warehouse);
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
        /// <br>Note       : �K�C�h�p�f�[�^�Z�b�g�̗�����\�z���܂��B
        /// <br>Programmer : 22022 �i�� �m�q</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction(ref DataSet guideList)
        {
            DataTable table = new DataTable();
            DataColumn column;

            // ���_�R�[�h
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_SECTIONCODE_TITLE;
            table.Columns.Add(column);

            // �q�ɃR�[�h
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSECODE_TITLE;
            table.Columns.Add(column);

            // �q�ɖ���
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENAME_TITLE;
            table.Columns.Add(column);

            // �q�ɔ��l
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE1_TITLE;
            table.Columns.Add(column);

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // �q�ɔ��l2
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE2_TITLE;
            table.Columns.Add(column);

            // �q�ɔ��l3
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE3_TITLE;
            table.Columns.Add(column);

            // �q�ɔ��l4
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE4_TITLE;
            table.Columns.Add(column);

            // �q�ɔ��l5
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_WAREHOUSENOTE5_TITLE;
            table.Columns.Add(column);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���Ӑ�R�[�h
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_CUSTOMERCODE_TITLE;
            table.Columns.Add(column);

            // ��Ǒq�ɃR�[�h
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_MAINMNGWAREHOUSECD_TITLE;
            table.Columns.Add(column);

            // �݌Ɉꊇ���}�[�N
            column = new DataColumn();
            column.DataType = Type.GetType(GUIDE_TYPE_STR);
            column.ColumnName = GUIDE_STOCKBLANKREMARK_TITLE;
            table.Columns.Add(column);
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // �e�[�u���R�s�[
            guideList.Tables.Add(table.Clone());
        }

        #endregion
    }
}
