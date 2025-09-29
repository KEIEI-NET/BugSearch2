using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Control;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �ύXPG�ē��������i
	/// </summary>
	/// <remarks>
	/// <br/>Note       : �ύX�ē��T�[�r�X�p  �������i�ł��B
	/// <br/>Programer  : 21027 �{��  ���u�Y
	/// <br/>Date       : 2007.03.05
	/// <br/>
	/// <br/>UpdataNote : 2007.12.10  Kouguchi  �V���C�A�E�g�Ή�
	/// </remarks>
	public class ChangeInfoSearchManager
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public ChangeInfoSearchManager()
		{

		}

		// ���[���擾�p�o�[�W�����萔
		private const string ctCODE_GenerationCode = "2.0";


		#region Public Methods

        #region Del  2007.12.10  Kouguchi
        //#region ReadSvrMntInfo
        ///// <summary>
        ///// �T�[�o�[�����e�i���X���擾����<br/>
        ///// �A�N�Z�X�`�P�b�g���w�肵�āA���[�����̎����ݒ���s���܂��B
        ///// </summary>
        ///// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
        ///// <param name="serverMainteConsNo">�T�[�o�[�����e�i���X�A��</param>
        ///// <param name="readData">�擾�f�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //public int ReadSvrMntInfo(string ticket, int serverMainteConsNo, out SvrMntInfoWork readData, out string errMsg)
        //{
        //    // �Ǎ��ݗp�p�����[�^�쐬
        //    SvrMntInfoWork readParam = new SvrMntInfoWork();
        //    readParam.ServerMainteConsNo = serverMainteConsNo;

        //    // �Ǎ��ݏ���
        //    return this.ReadSvrMntInfoProc(ticket, true, readParam, out readData, out errMsg);
        //}
        //#endregion

        //#region ReadSvrMntInfoNoTicket
        ///// <summary>
        ///// �T�[�o�[�����e�i���X���擾����
        ///// </summary>
        ///// <param name="productCode">�p�b�P�[�W�敪</param>
        ///// <param name="serverMainteConsNo">�T�[�o�[�����e�i���X�A��</param>
        ///// <param name="readData">�擾�f�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //public int ReadSvrMntInfoNoTicket(string productCode, int serverMainteConsNo, out SvrMntInfoWork readData, out string errMsg)
        //{
        //    // �Ǎ��ݗp�p�����[�^�쐬
        //    SvrMntInfoWork readParam = new SvrMntInfoWork();
        //    readParam.ProductCode = productCode;
        //    readParam.ServerMainteConsNo = serverMainteConsNo;

        //    // �Ǎ��ݏ���
        //    return this.ReadSvrMntInfoProc(null, false, readParam, out readData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfo
        ///// <summary>
        ///// �T�[�o�[�����e�i���X��񌟍�����<br/>
        ///// �w�肳�ꂽ�T�[�o�[�����e�i���X�敪�̑S���R�[�h���擾���܂��B<br/>
        ///// �A�N�Z�X�`�P�b�g���w�肵�āA���[�����̎����ݒ���s���܂��B
        ///// </summary>
        ///// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
        ///// <param name="serverMainteDivCd">�T�[�o�[�����e�i���X�敪[1:��������e�i���X, 9:�ً}�����e�i���X, -1:����]</param>
        ///// <param name="searchData">�������ʃf�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfo(string ticket, int serverMainteDivCd, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    int totalCount = 0;

        //    // �����p�p�����[�^�쐬
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // ��������(�����w�薳��)
        //    return this.SearchSvrMntInfoProc(ticket, true, searchParam, 0, 0, out totalCount, out searchData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfoNoTicket
        ///// <summary>
        ///// �T�[�o�[�����e�i���X��񌟍�����<br/>
        ///// �w�肳�ꂽ�T�[�o�[�����e�i���X�敪�̑S���R�[�h���擾���܂��B
        ///// </summary>
        ///// <param name="productCode">�p�b�P�[�W�敪</param>
        ///// <param name="serverMainteDivCd">�T�[�o�[�����e�i���X�敪[1:��������e�i���X, 9:�ً}�����e�i���X, -1:����]</param>
        ///// <param name="searchData">�������ʃf�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfoNoTicket(string productCode, int serverMainteDivCd, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    int totalCount = 0;

        //    // �����p�p�����[�^�쐬
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ProductCode = productCode;
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // ��������(�����w�薳��)
        //    return this.SearchSvrMntInfoProc(null, false, searchParam, 0, 0, out totalCount, out searchData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfo
        ///// <summary>
        ///// �T�[�o�[�����e�i���X��񌟍�����<br/>
        ///// �w�肳�ꂽ�T�[�o�[�����e�i���X�敪�̃��R�[�h�������w��Ŏ擾���܂��B<br/>
        ///// �A�N�Z�X�`�P�b�g���w�肵�āA���[�����̎����ݒ���s���܂��B
        ///// </summary>
        ///// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
        ///// <param name="serverMainteDivCd">�T�[�o�[�����e�i���X�敪[1:��������e�i���X, 9:�ً}�����e�i���X, -1:����]</param>
        ///// <param name="startIndex">�����J�n�C���f�b�N�X</param>
        ///// <param name="searchCount">��������</param>
        ///// <param name="totalCount">�������ʍő匏��</param>
        ///// <param name="searchData">�������ʃf�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfo(string ticket, int serverMainteDivCd, int startIndex, int searchCount, out int totalCount, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    // �����p�p�����[�^�쐬
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // ��������
        //    return this.SearchSvrMntInfoProc(ticket, true, searchParam, startIndex, searchCount, out totalCount, out searchData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfoNoTicket
        ///// <summary>
        ///// �T�[�o�[�����e�i���X��񌟍�����<br/>
        ///// �w�肳�ꂽ�T�[�o�[�����e�i���X�敪�̃��R�[�h�������w��Ŏ擾���܂��B
        ///// </summary>
        ///// <param name="productCode">�p�b�P�[�W�敪</param>
        ///// <param name="serverMainteDivCd">�T�[�o�[�����e�i���X�敪[1:��������e�i���X, 9:�ً}�����e�i���X, -1:����]</param>
        ///// <param name="startIndex">�����J�n�C���f�b�N�X</param>
        ///// <param name="searchCount">��������</param>
        ///// <param name="totalCount">�������ʍő匏��</param>
        ///// <param name="searchData">�������ʃf�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfoNoTicket(string productCode, int serverMainteDivCd, int startIndex, int searchCount, out int totalCount, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    // �����p�p�����[�^�쐬
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ProductCode = productCode;
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // ��������
        //    return this.SearchSvrMntInfoProc(null, false, searchParam, startIndex, searchCount, out totalCount, out searchData, out errMsg);
        //}
        //#endregion
        #endregion


        #region SearchChangGidnc
        /// <summary>
		/// �ύX�ē���񌟍�����<br/>
		/// �w�肳�ꂽ�z�M�o�[�W�����̑S���R�[�h���擾���܂��B<br/>
		/// �A�N�Z�X�`�P�b�g���w�肵�āA���[�����̎����ݒ���s���܂��B
		/// </summary>
		/// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
		/// <param name="multicastVersion">�z�M�o�[�W����</param>
		/// <param name="searchData">�������ʃf�[�^</param>
		/// <param name="searchDetail">�������ʖ��׃f�[�^</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:����I��</description></item>
		/// <item><description>-99:���[�����擾���s</description></item>
		/// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
		/// </list>
		/// </returns>
		public int SearchChangGidnc(string ticket, string multicastVersion, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			int totalCount = 0;

			// �����p�p�����[�^�쐬
			ChangGidncParaWork searchParam = new ChangGidncParaWork();
			searchParam.MulticastVersion = multicastVersion;	// �z�M�o�[�V����
			searchParam.MulticastSystemDivCd = -1;				// �z�M�V�X�e���敪(-1:�S��)

			// ��������
			return this.SearchChangGidncProc(ticket, true, searchParam, 0, 1, out totalCount, out searchData, out searchDetail, out errMsg);
		}
        #endregion

        #region SearchChangGidnc
        /// <summary>
		/// �ύX�ē���񌟍�����<br/>
		/// �w�肳�ꂽ�����̃��R�[�h�������w��Ŏ擾���܂��B<br/>
		/// �A�N�Z�X�`�P�b�g���w�肵�āA���[�����̎����ݒ���s���܂��B
		/// </summary>
		/// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
		/// <param name="searchParam">�����p�p�����[�^</param>
		/// <param name="startIndex">�����J�n�C���f�b�N�X</param>
		/// <param name="searchCount">��������</param>
		/// <param name="totalCount">�������ʍő匏��</param>
		/// <param name="searchData">�������ʃf�[�^</param>
		/// <param name="searchDetail">�������ʖ��׃f�[�^</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:����I��</description></item>
		/// <item><description>-99:���[�����擾���s</description></item>
		/// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
		/// </list>
		/// </returns>
		public int SearchChangGidnc(string ticket, ChangGidncParaWork searchParam, int startIndex, int searchCount, out int totalCount, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			return SearchChangGidncProc(ticket, true, searchParam, startIndex, searchCount, out totalCount, out searchData, out searchDetail, out errMsg);
        }
        #endregion

        #region SearchChangGidncNoTicket
        /// <summary>
		/// �ύX�ē���񌟍�����<br/>
		/// �w�肳�ꂽ�����̃��R�[�h�������w��Ŏ擾���܂��B
		/// </summary>
		/// <param name="searchParam">�����p�p�����[�^</param>
		/// <param name="startIndex">�����J�n�C���f�b�N�X</param>
		/// <param name="searchCount">��������</param>
		/// <param name="totalCount">�������ʍő匏��</param>
		/// <param name="searchData">�������ʃf�[�^</param>
		/// <param name="searchDetail">�������ʖ��׃f�[�^</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:����I��</description></item>
		/// <item><description>-99:���[�����擾���s</description></item>
		/// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
		/// </list>
		/// </returns>
		public int SearchChangGidncNoTicket(ChangGidncParaWork searchParam, int startIndex, int searchCount, out int totalCount, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			return SearchChangGidncProc(null, false, searchParam, startIndex, searchCount, out totalCount, out searchData, out searchDetail, out errMsg);
		}
		#endregion

        #endregion



		#region Private Methods

        #region Del  2007.12.10  Kouguchi
        //#region ReadSvrMntInfoProc
        ///// <summary>
        ///// �T�[�o�[�����e�i���X���擾����
        ///// </summary>
        ///// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
        ///// <param name="getRoleInf">���[����񎩓��擾�L��</param>
        ///// <param name="readParam">�Ǎ��ݗp�p�����[�^</param>
        ///// <param name="readData">�擾�f�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>�����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //private int ReadSvrMntInfoProc(string ticket, bool getRoleInf, SvrMntInfoWork readParam, out SvrMntInfoWork readData, out string errMsg)
        //{
        //    int status = 0;

        //    // ���[�������p�����[�^�ݒ�
        //    if (getRoleInf)
        //    {
        //        status = this.GetRoleInfoForSvrMntInfo(ticket, ref readParam, out errMsg);
        //        if (status != 0)
        //        {
        //            readData = null;
        //            return status;
        //        }
        //    }

        //    // �A�N�Z�X�N���XRead
        //    ChangePgGuideDBAcs changePgGuideDBAcs = new ChangePgGuideDBAcs();
        //    status = changePgGuideDBAcs.ReadSvrMntInf(readParam, out readData, out errMsg);

        //    return status;
        //}
        //#endregion

        //#region SearchSvrMntInfoProc
        ///// <summary>
        ///// �T�[�o�[�����e�i���X��񌟍�����
        ///// </summary>
        ///// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
        ///// <param name="getRoleInf">���[����񎩓��擾�L��</param>
        ///// <param name="searchParam">�����p�p�����[�^</param>
        ///// <param name="startIndex">�����J�n�C���f�b�N�X</param>
        ///// <param name="searchCount">�ő匟������</param>
        ///// <param name="searchData">�������ʃf�[�^</param>
        ///// <param name="totalCount">�������ʍő匏��</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>�����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
        ///// </list>
        ///// </returns>
        //private int SearchSvrMntInfoProc(string ticket, bool getRoleInf, SvrMntInfoWork searchParam, int startIndex, int searchCount, out int totalCount, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    int status = 0;

        //    // ���[�������p�����[�^�ݒ�
        //    if (getRoleInf)
        //    {
        //        status = this.GetRoleInfoForSvrMntInfo(ticket, ref searchParam, out errMsg);
        //        if (status != 0)
        //        {
        //            totalCount = 0;
        //            searchData = null;
        //            return status;
        //        }
        //    }

        //    // �A�N�Z�X�N���XRead
        //    ChangePgGuideDBAcs changePgGuideDBAcs = new ChangePgGuideDBAcs();
        //    status = changePgGuideDBAcs.SearchSvrMntInf(out searchData, searchParam, startIndex, searchCount, out totalCount, out errMsg);

        //    return status;
        //}
        //#endregion

        //#region GetRoleInfoForSvrMntInfo
        ///// <summary>
        ///// ���[���擾/�p�����[�^�ݒ菈��[�T�[�o�[�����e�i���X���p]
        ///// </summary>
        ///// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
        ///// <param name="svrMntInfoParam">�p�����[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>
        ///// �����X�e�[�^�X
        ///// <list type="bullet">
        ///// <item><description>0:����I��</description></item>
        ///// <item><description>-99:���[�����擾���s</description></item>
        ///// </list>
        ///// </returns>
        //private int GetRoleInfoForSvrMntInfo(string ticket, ref SvrMntInfoWork svrMntInfoParam, out string errMsg)
        //{
        //    errMsg = "";

        //    if ((ticket == null) || (ticket == String.Empty))
        //    {
        //        errMsg = "�A�N�Z�X�`�P�b�g���ݒ肳��Ă��܂���B";
        //        return -99;
        //    }

        //    // �A�N�Z�X�`�P�b�g��胍�[�����擾
        //    ChangePgGuideRoleInfo roleInfoAcs = new ChangePgGuideRoleInfo();
        //    RoleInfo roleInfo = roleInfoAcs.ReadRoleInfo(ticket, ctCODE_GenerationCode);

        //    if (roleInfo == null)
        //    {
        //        errMsg = "���[�����̎擾�Ɏ��s���܂����B";
        //        return -99;
        //    }

        //    // ���[�������p�����[�^�쐬
        //    svrMntInfoParam.ProductCode = roleInfo.ProductCode;		// �p�b�P�[�W�敪

        //    return 0;
        //}
        //#endregion
        #endregion


        #region SearchChangGidncProc
        /// <summary>
		/// �ύX�ē���񌟍�����
		/// </summary>
		/// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
		/// <param name="getRoleInf">���[����񎩓��擾�L��</param>
		/// <param name="searchParam">�����p�p�����[�^</param>
		/// <param name="startIndex">�����J�n�C���f�b�N�X</param>
		/// <param name="searchCount">��������</param>
		/// <param name="totalCount">�������ʍő匏��</param>
		/// <param name="searchData">�������ʃf�[�^</param>
		/// <param name="searchDetail">�������ʖ��׃f�[�^</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:����I��</description></item>
		/// <item><description>-99:���[�����擾���s</description></item>
		/// <item><description>��:�A�N�Z�X�N���X�����X�e�[�^�X</description></item>
		/// </list>
		/// </returns>
		private int SearchChangGidncProc(string ticket, bool getRoleInf, ChangGidncParaWork searchParam, int startIndex, int searchCount, out int totalCount, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			int status = 0;

			// ���[�������p�����[�^�ݒ�
			if (getRoleInf)
			{
				status = this.GetRoleInfoForChangGidnc(ticket, ref searchParam, out errMsg);
				if (status != 0)
				{
					totalCount = 0;
					searchData = null;
					searchDetail = null;
					return status;
				}
			}

			// �A�N�Z�X�N���XRead
			ChangePgGuideDBAcs changePgGuideDBAcs = new ChangePgGuideDBAcs();
			status = changePgGuideDBAcs.ChangGidnc(searchParam, out searchData, out searchDetail, startIndex, searchCount, out totalCount, out errMsg);

			return status;
        }
        #endregion

        #region GetRoleInfoForChangGidnc
        /// <summary>
		/// ���[���擾/�p�����[�^�ݒ菈��
		/// </summary>
		/// <param name="ticket">�A�N�Z�X�`�P�b�g</param>
		/// <param name="changGidncParam">�p�����[�^</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>
		/// �����X�e�[�^�X
		/// <list type="bullet">
		/// <item><description>0:����I��</description></item>
		/// <item><description>-99:���[�����擾���s</description></item>
		/// </list>
		/// </returns>
		private int GetRoleInfoForChangGidnc(string ticket, ref ChangGidncParaWork changGidncParam, out string errMsg)
		{
			errMsg = "";

			if ((ticket == null) || (ticket == String.Empty))
			{
				errMsg = "�A�N�Z�X�`�P�b�g���ݒ肳��Ă��܂���B";
				return -99;
			}

			// �A�N�Z�X�`�P�b�g��胍�[�����擾
			ChangePgGuideRoleInfo roleInfoAcs = new ChangePgGuideRoleInfo();
			RoleInfo roleInfo = roleInfoAcs.ReadRoleInfo(ticket, ctCODE_GenerationCode);

			if (roleInfo == null)
			{
				errMsg = "���[�����̎擾�Ɏ��s���܂����B";
				return -99;
			}

			// ���[�������p�����[�^�쐬
			changGidncParam.ProductCode = roleInfo.ProductCode;					// �p�b�P�[�W�敪
			switch (roleInfo.IndividuallyCode)
			{
				case 0:		// �ʖ���
					changGidncParam.McastOfferDivCd = 0;						// �z�M�񋟋敪(-1:�}�[�W, 0:�W��, 1:��)
					break;
				case 1:		// �O���[�v�P�ʌʗL��
					changGidncParam.McastOfferDivCd = -1;
					changGidncParam.UpdateGroupCode = roleInfo.IndividuallyGroupCode;				// �X�V�O���[�v�R�[�h
					break;
				case 2:		// ��ƒP�ʌʗL��
					changGidncParam.McastOfferDivCd = -1;
					changGidncParam.EnterpriseCode = roleInfo.IndividuallyEnterpriseCode;			// ��ƃR�[�h
					break;
				case 3:		// �O���[�v�E��ƒP�ʌʗL��
					changGidncParam.McastOfferDivCd = -1;
					changGidncParam.UpdateGroupCode = roleInfo.IndividuallyGroupCode;
					break;
			}

			changGidncParam.StdDate = Int64.Parse(String.Format("{0:yyyyMMddHHmm}", DateTime.Now));	// ���J���
			changGidncParam.OpenDtTmDiv = roleInfo.BroadleafFlag ? 1 : 2;							// 1:�T�|�[�g���J����,2:���[�U�[���J����

			return 0;
        }
        #endregion

        #endregion

    }
}
