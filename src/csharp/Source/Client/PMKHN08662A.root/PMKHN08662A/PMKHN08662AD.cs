using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
//using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
//using Broadleaf.Application.Remoting;
////using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Application.Remoting.ParamData;
namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �Z�b�g�}�X�^�i����j����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �Z�b�g�}�X�^�i����j����Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer   : 30462 �s�V �m��</br>
    /// <br>Date         : 2008.10.30</br>
    /// <br>             : </br>
    /// </remarks>
    public class GoodsSetPrintReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// �Z�b�g�}�X�^�i����j����A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�i����j����A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public GoodsSetPrintReportAcs()
		{
		}

        /// <summary>
        /// �Z�b�g�}�X�^�i����j����A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�i����j����A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.30</br>
		/// </remarks>
        static GoodsSetPrintReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

            
            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

		}
		#endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			                // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // ���[�o�͐ݒ�A�N�Z�X�N���X
        #endregion �� Static Member

       

        #region �� Private Method
        #region �� ���[�ݒ�f�[�^�擾
		#region �� ���[�o�͐ݒ�擾����
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.07.17</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// �f�[�^�͓Ǎ��ς݂��H
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion �� ���[�ݒ�f�[�^�擾
		#endregion �� Private Method
    }
}
