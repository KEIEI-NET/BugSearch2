using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���j���[����ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���j���[����ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30747 �O�� �L��</br>
	/// <br>Date       : 2013/02/15</br>
	/// <br></br>
    /// </remarks>
	public class MenueStSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private IMenueStDB _menuStDB;
        

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���j���[����ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���j���[����ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        public MenueStSetAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._menuStDB = (IMenueStDB)MediationMenueStDB.GetMenueStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._menuStDB = null;
            }
        }

        

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}

        /// <summary>
        /// ���j���[����ݒ�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="menueStPrintWork"></param>
        /// <remarks>
        /// <br>Note       : ���j���[����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, MenueStPrintWork menueStPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, menueStPrintWork);
		}

        /// <summary>
        /// ���j���[����ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="menueStPrintWork"></param>
        /// <remarks>
        /// <br>Note       : ���j���[����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, MenueStPrintWork menueStPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, menueStPrintWork);
		}

		

		/// <summary>
		/// ���j���[����ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="menueStPrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���j���[����ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MenueStPrintWork menueStPrintWork)
		{
            if (this._menuStDB == null)
            {
                this._menuStDB = (IMenueStDB)MediationMenueStDB.GetMenueStDB();
            }

            int status = 0;
            //int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            object menueStBd = null;

            // ���[�U�[�K�C�h�i�{�f�B�j�擾
            status = this._menuStDB.Search(out menueStBd, enterpriseCode, menueStPrintWork.SortCode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = menueStBd as ArrayList;

                foreach (MenueStWork menueStbd in workList)
                {
                    // ���o����
                    if (menueStPrintWork.EmployeeCodeSt != "")
                    {
                        if (menueStbd.EmployeeCode.Trim().CompareTo(menueStPrintWork.EmployeeCodeSt) < 0) continue;
                    }
                    if (menueStPrintWork.EmployeeCodeEd != "")
                    {
                        if (menueStbd.EmployeeCode.Trim().CompareTo(menueStPrintWork.EmployeeCodeEd) > 0) continue;
                    }

                    retList.Add(CopyToMakerSetFromSecInfoSetWork(menueStbd));
                }

                //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
                if (readCnt == 0) retTotalCnt = retList.Count;
            }
				
			return status;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���j���[����ݒ胏�[�N�N���X�˃��j���[����ݒ�N���X�j
        /// </summary>
        /// <param name="menueStbd">���j���[����ݒ胏�[�N�N���X</param>
        /// <returns>���j���[����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���j���[����ݒ胏�[�N�N���X���烁�j���[����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30747 �O�� �L��</br>
        /// <br>Date       : 2013/02/15</br>
        /// </remarks>
        private MenueStSet CopyToMakerSetFromSecInfoSetWork(MenueStWork menueStbd)
        {

            MenueStSet menueStSet = new MenueStSet();

            menueStSet.EnterpriseCode = menueStbd.EnterpriseCode;       // ��ƃR�[�h
            menueStSet.RoleGroupCode = menueStbd.RoleGroupCode;         // ���[���O���[�v�R�[�h
            menueStSet.RoleGroupName = menueStbd.RoleGroupName;         // ���[���O���[�v����
            menueStSet.RoleCategoryId = menueStbd.RoleCategoryId;       // �J�e�S��
            menueStSet.RoleCategorySubId = menueStbd.RoleCategorySubId; // �T�u�J�e�S��
            menueStSet.RoleItemId = menueStbd.RoleItemId;               // �A�C�e��
            menueStSet.SystemName = menueStbd.SystemName;               // �V�X�e���@�\����
            menueStSet.EmployeeCode = menueStbd.EmployeeCode;           // �]�ƈ��R�[�h
            menueStSet.EmployeeName = menueStbd.EmployeeName;           // �]�ƈ�����

            return menueStSet;
        }

    }
}
