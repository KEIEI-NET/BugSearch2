using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.RCDS.Web.Services;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���ꉿ�i�I���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2010/06/17</br>
    /// </remarks>
    public class SelectionMarketPriceAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        private MarketPriceInfoDataSet _dataSet;
        private MarketPriceInfoDataSet.MarketPriceInfoDataTable _priceInfoTable;
        private SobaServiceAcs _sobaServiceAcs;

        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� Public Enum
        #endregion


        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Property

        /// <summary>
        /// ���ꉿ�i���f�[�^�e�[�u��
        /// </summary>
        public MarketPriceInfoDataSet.MarketPriceInfoDataTable PriceInfoDataTable
        {
            get { return _priceInfoTable; }
            set { _priceInfoTable = value; }
        }


        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Costructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SelectionMarketPriceAcs()
        {
        }

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method

        /// <summary>
        /// ���ꉿ�i����
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public int MarketPriceSearch( MarketPriceAcqCond condition, out string errMsg )
        {
            return MarketPriceSearchProc( condition, out errMsg );
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// ���ꉿ�i����
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        private int MarketPriceSearchProc( MarketPriceAcqCond marketPriceAcqCond, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            errMsg = string.Empty;

            try
            {
                //--------------------------------------------------
                // �@���ꉿ�i�ݒ�}�X�^�̎擾
                //--------------------------------------------------
                SCMMrktPriSt scmMrktPriSt = this.GetMrktPriSt( marketPriceAcqCond.EnterpriseCode, marketPriceAcqCond.SectionCode );
                if ( scmMrktPriSt == null ) return 1000;

                //--------------------------------------------------
                // �A������̎擾�{���ꉿ�i�̌v�Z
                //--------------------------------------------------

                // ����T�[�r�X�A�N�Z�X�N���X����
                if ( _sobaServiceAcs == null )
                {
                    _sobaServiceAcs = new SobaServiceAcs();
                }
                // ������擾
                List<SobaServiceAcs.GetSobaResTypeUnitData> sobaResList = _sobaServiceAcs.GetSobaResponce( marketPriceAcqCond, scmMrktPriSt );
                if ( sobaResList == null || sobaResList.Count == 0 )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                // �f�[�^�e�[�u���֊i�[
                _dataSet = new MarketPriceInfoDataSet();
                _priceInfoTable = _dataSet.MarketPriceInfo;
                if ( sobaResList != null )
                {
                    foreach ( SobaServiceAcs.GetSobaResTypeUnitData sobaRes in sobaResList )
                    {
                        MarketPriceInfoDataSet.MarketPriceInfoRow row = _priceInfoTable.NewMarketPriceInfoRow();
                        CopyToRowFromRes( ref row, sobaRes, scmMrktPriSt );

                        // �Z�o�������z���[���ȊO�Ȃ�Ε\���e�[�u���ɒǉ�
                        if ( row.MarketPrice != 0 )
                        {
                            _priceInfoTable.Rows.Add( row );
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }

                // �\�[�g���ݒ�
                _priceInfoTable.DefaultView.Sort = string.Format( "{0}", _priceInfoTable.PriorityColumn.ColumnName );
            }
            catch ( Exception ex )
            {
                // ��O����
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�e�[�u���ւ̊i�[����
        /// </summary>
        /// <param name="row"></param>
        /// <param name="sobaRes"></param>
        private void CopyToRowFromRes( ref MarketPriceInfoDataSet.MarketPriceInfoRow row, SobaServiceAcs.GetSobaResTypeUnitData sobaRes, SCMMrktPriSt scmMrktPriSt )
        {
            // �I���t���O������
            row.Selected = false;

            // �D�揇��
            row.Priority = sobaRes.Index + 1; // 1,2,3 �� 0,1,2

            // �n��
            row.MarketPriceAreaCd = sobaRes.GetSobaReqType.AreaCode;
            row.MarketPriceAreaNm = _sobaServiceAcs.GetMarketPriceAreaNm( scmMrktPriSt.EnterpriseCode, sobaRes.GetSobaReqType.AreaCode );
            
            // ���
            row.MarketPriceKindCd = sobaRes.GetSobaReqType.KindCode;
            row.MarketPriceKindNm = _sobaServiceAcs.GetMarketPriceKindNm( scmMrktPriSt.EnterpriseCode, sobaRes.GetSobaReqType.KindCode );

            // �i��
            row.MarketPriceQualityCd = sobaRes.GetSobaReqType.QualityCode;
            row.MarketPriceQualityNm = _sobaServiceAcs.GetMarketPriceQualityNm( scmMrktPriSt.EnterpriseCode, sobaRes.GetSobaReqType.QualityCode );

            // ���ʑ��ꉿ�i(�����X�̉��i)
            row.DstrMarketPrice = sobaRes.GetSobaResType.SobaList[0].StdDev;

            // ���ꉿ�i(�����ꉿ�i�|���ɏ]��)
            row.MarketPrice = SobaServiceAcs.GetMarketPrice( sobaRes.GetSobaResType, scmMrktPriSt );
        }

        /// <summary>
        /// ����ݒ�}�X�^�̎擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private SCMMrktPriSt GetMrktPriSt( string enterpriseCode, string sectionCode )
        {
            SCMMrktPriSt scmMrktPriSt = null;

            SCMMrktPriStAcs scmMrktPriStAcs = new SCMMrktPriStAcs();
            {
                ArrayList al;
                int status = scmMrktPriStAcs.SearchAll( out al, enterpriseCode );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && al != null && al.Count > 0 )
                {
                    List<SCMMrktPriSt> dataList = new List<SCMMrktPriSt>();
                    foreach ( SCMMrktPriSt data in al )
                    {
                        dataList.Add( data );
                    }

                    dataList.Sort( new SCMMrktPriStComparer() );

                    scmMrktPriSt = dataList.Find
                        (
                            delegate( SCMMrktPriSt dt )
                            {
                                if ( dt.SectionCode.Trim() == sectionCode.Trim() || dt.SectionCode.Trim() == "00".Trim() )
                                {
                                    return true;
                                }
                                return false;
                            }
                        );
                }
            }
            return scmMrktPriSt;
        }

        #endregion



        #region �\�[�g�p�N���X

        /// <summary>
        /// ����ݒ�}�X�^���A���_�R�[�h�t���Ƀ\�[�g����
        /// </summary>
        /// <remarks></remarks>
        private class SCMMrktPriStComparer : Comparer<SCMMrktPriSt>
        {
            public override int Compare( SCMMrktPriSt x, SCMMrktPriSt y )
            {
                int result = y.SectionCode.Trim().CompareTo( x.SectionCode.Trim() );
                if ( result != 0 ) return result;

                return result;
            }
        }
        #endregion
    }

}
