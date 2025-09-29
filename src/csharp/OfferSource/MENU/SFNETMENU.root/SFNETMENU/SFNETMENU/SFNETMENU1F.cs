using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// �]�ƈ����O�C����ʊg���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : Felica�Ή�</br>
    /// <br>Programmer : 23002 ��� �k��</br>
    /// <br>Date       : 2008.11.14</br>
    /// </remarks>
    internal class EmployeeLoginFormEx
    {
        private EmployeeLoginFormAF _employeeLoginFormAF = null;
        private EmployeeLogin2FormAF _employeeLogin2FormAF = null;
        private bool _felicaType = false;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param rKeyName="felicaType">Felica�Ή��̗L��</param>
        public EmployeeLoginFormEx(bool felicaType)
        {
            _felicaType = felicaType;
            if( _felicaType )
            {
                _employeeLogin2FormAF = new EmployeeLogin2FormAF();
            }
            else
            {
                _employeeLoginFormAF = new EmployeeLoginFormAF();
            }
        }

        /// <summary>
        /// �]�ƈ����O�C���J�n
        /// </summary>
        /// <param rKeyName="owner">���O�C�����Owner</param>
        /// <param rKeyName="accessTicket">�A�N�Z�X�`�P�b�g</param>
        /// <param rKeyName="domainStr">�]�ƈ����O�C���h���C��������</param>
        /// <param rKeyName="companyAuthInfoWork">��ƃ��O�C�����</param>
        /// <param rKeyName="employeeAuthInfoWork">�]�ƈ����O�C�����</param>
        /// <returns>STATUS</returns>
        public int ShowDialog(IWin32Window owner, string accessTicket, string domainStr, CompanyAuthInfoWork companyAuthInfoWork, ref EmployeeAuthInfoWork employeeAuthInfoWork)
        {
            if( _felicaType )
            {
                //Felica�̃I�v�V���������̏ꍇ
                return _employeeLogin2FormAF.ShowDialog(owner, accessTicket, domainStr, companyAuthInfoWork, ref employeeAuthInfoWork);
            }
            else
            {
                //Felica�̃I�v�V�����񓱓��̏ꍇ
                return _employeeLoginFormAF.ShowDialog(owner, accessTicket, domainStr, companyAuthInfoWork, ref employeeAuthInfoWork);
            }
        }
    }
}
