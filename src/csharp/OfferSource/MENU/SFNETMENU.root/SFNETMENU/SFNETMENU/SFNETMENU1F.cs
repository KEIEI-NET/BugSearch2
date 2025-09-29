using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// 従業員ログイン画面拡張クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : Felica対応</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2008.11.14</br>
    /// </remarks>
    internal class EmployeeLoginFormEx
    {
        private EmployeeLoginFormAF _employeeLoginFormAF = null;
        private EmployeeLogin2FormAF _employeeLogin2FormAF = null;
        private bool _felicaType = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param rKeyName="felicaType">Felica対応の有無</param>
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
        /// 従業員ログイン開始
        /// </summary>
        /// <param rKeyName="owner">ログイン画面Owner</param>
        /// <param rKeyName="accessTicket">アクセスチケット</param>
        /// <param rKeyName="domainStr">従業員ログインドメイン文字列</param>
        /// <param rKeyName="companyAuthInfoWork">企業ログイン情報</param>
        /// <param rKeyName="employeeAuthInfoWork">従業員ログイン情報</param>
        /// <returns>STATUS</returns>
        public int ShowDialog(IWin32Window owner, string accessTicket, string domainStr, CompanyAuthInfoWork companyAuthInfoWork, ref EmployeeAuthInfoWork employeeAuthInfoWork)
        {
            if( _felicaType )
            {
                //Felicaのオプション導入の場合
                return _employeeLogin2FormAF.ShowDialog(owner, accessTicket, domainStr, companyAuthInfoWork, ref employeeAuthInfoWork);
            }
            else
            {
                //Felicaのオプション非導入の場合
                return _employeeLoginFormAF.ShowDialog(owner, accessTicket, domainStr, companyAuthInfoWork, ref employeeAuthInfoWork);
            }
        }
    }
}
