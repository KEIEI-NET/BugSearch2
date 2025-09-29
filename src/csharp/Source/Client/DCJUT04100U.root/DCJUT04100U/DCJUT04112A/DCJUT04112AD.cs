// �g�p:  MAHNB06016D, DCHNB09053G, DCHNB09055O, DCKHN01070C 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����[�������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����[�������Z����s���܂��B</br>
    /// <br>             ���̃N���X��DCKHN01070C��FractionCalculate�N���X�݂̂�</br>
    /// <br>             ������z�ɑ΂���[���������\�ł��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.11.16</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.11.16 ��� ���b �V�K�쐬</br>
    /// </remarks>
    internal class SalesFractionCalculate
    {
        // �e�[�u����`�p
        /// <summary>�e�[�u�����@����[�������e�[�u��</summary>
        private const string ct_Tbl_SalesProcMoneyTable = "SalesProcMoneyTable";
        /// <summary>�[�������Ώۋ敪</summary>
        private const string ct_Col_FracProcMoneyDiv = "FracProcMoneyDiv";
        /// <summary>�[�������R�[�h</summary>
        private const string ct_Col_FractionProcCode = "FractionProcCode";
        /// <summary>������z</summary>
        private const string ct_Col_UpperLimitPrice = "UpperLimitPrice";
        /// <summary>�[�������P��</summary>
        private const string ct_Col_FractionProcUnit = "FractionProcUnit";
        /// <summary>�[�������敪</summary>
        private const string ct_Col_FractionProcCd = "FractionProcCd";

        // �[�������Ώۋ��z�敪��`
        /// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        private const int ctFracProcMoneyDiv_SalesPrice = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        private const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        private const int ctFracProcMoneyDiv_SalesUnitPrice = 2;

        // �������g�̃C���X�^���X
        static SalesFractionCalculate stc_salesFractionCalculate;

        // �����[�g�I�u�W�F�N�g
        private ISalesProcMoneyDB _iSalesProcMoneyDB;   // from DCHNB09055O.dll
        private DataTable _salesProcMoneyTable;

        /// <summary>
        /// �v���C�x�[�g�R���X�g���N�^
        /// </summary>
        private SalesFractionCalculate ()
        {
            // �����[�g�I�u�W�F�N�g�擾
            _iSalesProcMoneyDB = (ISalesProcMoneyDB)MediationSalesProcMoneyDB.GetSalesProcMoneyDB();

            // �e�[�u������
            this._salesProcMoneyTable = CreateTable();
        }
        /// <summary>
        /// �X�^�e�B�b�N�R���X�g���N�^
        /// </summary>
        static SalesFractionCalculate ()
        {
            stc_salesFractionCalculate = new SalesFractionCalculate();
        }
        /// <summary>
        /// �C���X�^���X�擾����
        /// </summary>
        public static SalesFractionCalculate GetInstance ()
        {
            return stc_salesFractionCalculate;
        }
        /// <summary>
        /// �擾�����E������������
        /// </summary>
        public void SearchInitial ( string enterpriseCode )
        {
            _salesProcMoneyTable.Clear();

            object returnStockProcMoney;
            SalesProcMoneyWork paraSalesProcMoneyWork = new SalesProcMoneyWork();
            paraSalesProcMoneyWork.EnterpriseCode = enterpriseCode;
            paraSalesProcMoneyWork.FracProcMoneyDiv = -1;

            int status = this._iSalesProcMoneyDB.Search( out returnStockProcMoney, paraSalesProcMoneyWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0 );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( returnStockProcMoney is ArrayList )
                {
                    foreach ( SalesProcMoneyWork salesProcMoneyWork in (ArrayList)returnStockProcMoney )
                    {
                        _salesProcMoneyTable.Rows.Add( CopyToDataRowFromSalesProcMoneyWork( salesProcMoneyWork ) );
                    }
                }
            }
        }
        /// <summary>
        /// ������z�[������
        /// </summary>
        /// <param name="targetPrice">�[�������Ώۋ��z ( �P���~���� ) </param>
        /// <param name="procCd">�[�������R�[�h ( ���Ӑ�d�����}�X�^�ɓo�^����Ă���[�������R�[�h ) </param>
        /// <returns>�Z�o����</returns>
        public double GetSalesPrice ( double targetPrice, int procCd )
        {
            double resultMoney;
            try
            {
                double fractionProcUnitPrice;
                int fractionProcCd;

                // �d�����z�[���������R�[�h�擾�i�[�������P�ʂƒ[�������敪���擾�j
                GetFractionProcInfo( ctFracProcMoneyDiv_SalesPrice, procCd, targetPrice, out fractionProcUnitPrice, out fractionProcCd );

                // �[�������N���X���\�b�h�ɓn���ĎZ�o
                FractionCalculate.FracCalcMoney( targetPrice, fractionProcUnitPrice, fractionProcCd, out resultMoney );
            }
            catch
            {
                resultMoney = targetPrice;
            }

            return resultMoney;
        }
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// 
        private void GetFractionProcInfo ( int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd )
        {
            //�f�t�H���g
            switch ( fracProcMoneyDiv )
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            // �[�������Ώۋ��z�敪�A�[�������R�[�h����v����f�[�^�������Ɏ擾
            DataRow[] dr = this._salesProcMoneyTable.Select( string.Format( "{0} = '{1}' AND {2} = '{3}'",
                                                                                ct_Col_FracProcMoneyDiv, fracProcMoneyDiv,
                                                                                ct_Col_FractionProcCode, fractionProcCode ),
                                                             string.Format( "{0} DESC", ct_Col_UpperLimitPrice ) );

            foreach ( DataRow stockProcMoneyRow in dr )
            {
                if ( (double)stockProcMoneyRow[ct_Col_UpperLimitPrice] < targetPrice )
                {
                    break;
                }
                fractionProcUnit = (double)stockProcMoneyRow[ct_Col_FractionProcUnit];
                fractionProcCd = (int)stockProcMoneyRow[ct_Col_FractionProcCd];
            }
        }
        /// <summary>
        /// SalesProcMoneyWork��DataRow �ڍs����
        /// </summary>
        /// <param name="salesProcMoneyWork"></param>
        private DataRow CopyToDataRowFromSalesProcMoneyWork ( SalesProcMoneyWork salesProcMoneyWork )
        {
            DataRow row = _salesProcMoneyTable.NewRow();

            row[ct_Col_FracProcMoneyDiv] = salesProcMoneyWork.FracProcMoneyDiv;
            row[ct_Col_FractionProcCode] = salesProcMoneyWork.FractionProcCode;
            row[ct_Col_UpperLimitPrice] = salesProcMoneyWork.UpperLimitPrice;
            row[ct_Col_FractionProcUnit] = salesProcMoneyWork.FractionProcUnit;
            row[ct_Col_FractionProcCd] = salesProcMoneyWork.FractionProcCd;

            return row;
        }
        /// <summary>
        /// ����[�������e�[�u������
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTable ()
        {
            DataTable table = new DataTable( ct_Tbl_SalesProcMoneyTable );

            table.Columns.Add( new DataColumn( ct_Col_FracProcMoneyDiv, typeof( Int32 ) ) );
            table.Columns.Add( new DataColumn( ct_Col_FractionProcCode, typeof( Int32 ) ) );
            table.Columns.Add( new DataColumn( ct_Col_UpperLimitPrice, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_FractionProcUnit, typeof( double ) ) );
            table.Columns.Add( new DataColumn( ct_Col_FractionProcCd, typeof( Int32 ) ) );

            return table;
        }
    }
}

