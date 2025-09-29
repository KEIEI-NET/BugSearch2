using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R�������i�����o�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�����o�^�I���t�h�̐�����s���܂��B</br>
    /// <br>           : �i���̃A�N�Z�X�N���X�ł͓o�^�m�F�E�I���̐���̂ݍs���A���ۂ̓o�^��IOWriter�����pR���Ăяo���܂��j</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/05/13</br>
    /// <br></br>
    /// </remarks>
    public partial class AutoEntryFreeSearchPartsAcs
    {
        # region [�t�B�[���h]
        private static AutoEntryFreeSearchPartsAcs stc_AutoEntryFreeSearchPartsAcs;
        private IFreeSearchPartsSearchDB iFreeSearchPartsSearchDB;
        private AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable _autoEntryFSPartsDataTable;
        private AutoEntryFreeSearchPartsDataSet.CarModelDataTable _carModelDataTable;
        # endregion

        # region [�v���p�e�B]
        /// <summary>
        /// ���R�������i�����o�^�e�[�u��
        /// </summary>
        public AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable AutoEntryFSPartsDataTable
        {
            get 
            {
                if ( _autoEntryFSPartsDataTable == null )
                {
                    _autoEntryFSPartsDataTable = new AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsDataTable();
                }
                return _autoEntryFSPartsDataTable; 
            }
        }
        /// <summary>
        /// ���R�������i�����o�^ �^�����e�[�u��
        /// </summary>
        public AutoEntryFreeSearchPartsDataSet.CarModelDataTable CarModelDataTable
        {
            get 
            {
                if ( _carModelDataTable == null )
                {
                    _carModelDataTable = new AutoEntryFreeSearchPartsDataSet.CarModelDataTable();
                }
                return _carModelDataTable; 
            }
        }
        # endregion

        # region [�R���X�g���N�^��]
        /// <summary>
        /// private �R���X�g���N�^
        /// </summary>
        private AutoEntryFreeSearchPartsAcs()
        {
        }
        /// <summary>
        /// public static �R���X�g���N�^
        /// </summary>
        static AutoEntryFreeSearchPartsAcs()
        {
        }
        /// <summary>
        /// �C���X�^���X�擾
        /// </summary>
        /// <returns></returns>
        public static AutoEntryFreeSearchPartsAcs GetInsctance()
        {
            if ( stc_AutoEntryFreeSearchPartsAcs == null )
            {
                stc_AutoEntryFreeSearchPartsAcs = new AutoEntryFreeSearchPartsAcs();
            }
            return stc_AutoEntryFreeSearchPartsAcs;
        }
        # endregion

        # region [public���\�b�h]
        /// <summary>
        /// �f�[�^�ێ��e�[�u���̃N���A
        /// </summary>
        public void ClearTables()
        {
            // NULL���Z�b�g�˃v���p�e�B��get�ŐV�K�C���X�^���X�����������
            _autoEntryFSPartsDataTable = null;
            _carModelDataTable = null;
        }
        /// <summary>
        /// ���ז��̎����o�^�Ώۃt���^�����X�g�擾����
        /// </summary>
        /// <param name="dtlRelationGuid"></param>
        /// <returns></returns>
        public string[] GetCarModelsForAutoEntryFreeSearchParts( Guid dtlRelationGuid )
        {
            //---------------------------------------------------------------
            // [�G���g�����̓C���[�W]
            //
            // XX-XXX-XXXX, YY-YYY-YYYY
            //   hinban1 0001
            //   hinban2 0001
            // ZZ-ZZZ-ZZZZ
            //   hinban3 0001
            //
            // ��
            //
            // [�ԋp���ʃC���[�W]
            //
            // hinban1 0001 �c XX-XXX-XXXX, YY-YYY-YYYY
            // hinban2 0001 �c XX-XXX-XXXX, YY-YYY-YYYY
            // hinban3 0001 �c ZZ-ZZZ-ZZZZ
            //
            //---------------------------------------------------------------
            List<string> carModelList = new List<string>();

            // �w���GUID�ƍ��v���A���I���t�h�Ń`�F�b�N���t����ꂽ�s���擾
            AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[] targetRows
                = (AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow[])AutoEntryFSPartsDataTable.Select(
                    string.Format( "{0}='{1}' AND {2}='{3}'",
                        AutoEntryFSPartsDataTable.DtlRelationGuidColumn.ColumnName, dtlRelationGuid,
                        AutoEntryFSPartsDataTable.CheckedColumn.ColumnName, true
                    ) 
                  );

            // �Y���̏��i�̃t���^�������X�g������
            foreach ( AutoEntryFreeSearchPartsDataSet.AutoEntryFreeSearchPartsRow fsPartsRow in targetRows )
            {
                carModelList.Add( fsPartsRow.FullModel );
            }

            // ���ʂ̕ԋp
            if ( carModelList.Count == 0 )
            {
                return null;
            }
            return carModelList.ToArray();
        }
        /// <summary>
        /// ���R�������i ���݃`�F�b�N
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="carInfo"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        public bool CheckFreeSearchParts( string enterpriseCode, PMKEN01010E carInfo, int blGoodsCode, string goodsNo, int goodsMakerCd )
        {
            if ( iFreeSearchPartsSearchDB == null )
            {
                iFreeSearchPartsSearchDB = MediationFreeSearchPartsSearchDB.GetRemoteObject();
            }

            // ���o�����̃Z�b�g
            FreeSearchPartsSParaWork paraWork = new FreeSearchPartsSParaWork();
            # region [paraWork���Z�b�g]
            // ���i���̌�������
            paraWork.EnterpriseCode = enterpriseCode.Trim();
            paraWork.TbsPartsCode = blGoodsCode;
            paraWork.TbsPartsCdDerivedNo = 0;
            paraWork.GoodsNo = goodsNo;
            paraWork.GoodsMakerCd = goodsMakerCd;

            List<FreeSearchPartsSMdlParaWork> fsPartsSModelsList = new List<FreeSearchPartsSMdlParaWork>();
            foreach ( PMKEN01010E.CarModelInfoRow carModelInfoRow in carInfo.CarModelInfo.Rows )
            {
                // �^���������X�g�ɒǉ�
                FreeSearchPartsSMdlParaWork modelParaWork = new FreeSearchPartsSMdlParaWork();
                modelParaWork.MakerCode = carModelInfoRow.MakerCode;
                modelParaWork.ModelCode = carModelInfoRow.ModelCode;
                modelParaWork.ModelSubCode = carModelInfoRow.ModelSubCode;
                modelParaWork.FullModel = carModelInfoRow.FullModel;
                fsPartsSModelsList.Add( modelParaWork );
            }
            paraWork.FSPartsSModels = fsPartsSModelsList.ToArray();
            # endregion

            // ���R�������i����
            object retObj = null;
            long retCount;
            int status = iFreeSearchPartsSearchDB.Search( paraWork, ref retObj, out retCount );

            // ���ʕԋp
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retCount > 0 && retObj != null )
            {
                // ��������
                return true;
            }
            else
            {
                // �Ȃ�
                return false;
            }
        }
        # endregion
    }
}