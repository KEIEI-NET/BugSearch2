using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Infragistics.Win.Misc;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
    class Iko
    {
        private string _enterpriseCode;         // ��ƃR�[�h
        private string _loginSectionCode;
        private PccCmpnyStAcs _pccCmpnyStAcs = null;


        public Iko()
        {
            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //���O�C���S���҂̋��_ 
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        }

        public int Iko_Main(bool batch)
        {
            return Search(batch);

        }

        /// <summary>
        /// BLP���Аݒ�}�X�^�q�Ɉڍs��������
        /// </summary>
        /// <param name="batch">�o�b�`����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// </remarks>
        public int Search(bool batch)
        {
            if (_pccCmpnyStAcs == null)
            {
                _pccCmpnyStAcs = new PccCmpnyStAcs();
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
                parsePccCmpnySt.InqOtherEpCd = this._enterpriseCode;
                parsePccCmpnySt.InqOtherSecCd = this._loginSectionCode;
                status = this._pccCmpnyStAcs.Search(parsePccCmpnySt, batch);
                if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                    return status;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                return status;
            }

            return status;
        }

    }
}
