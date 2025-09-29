using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.IO;  // ADD 2010/07/07
using WinForms = System.Windows.Forms; // ADD 2010/07/07
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ԗ������R���g���[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ������R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: �ԑ�ԍ��ˎԑ�ԍ��A�ԑ�ԍ��i�����p�j�ɏC��</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.01.28</br>        
    /// <br></br>
    /// <br>Update Note: 2009/10/13  22018  ��� ���b</br>
    /// <br>           : ���o�\�t�@�\�̏C���Ή��i�t���^���Œ�ԍ����[���̏ꍇ�̑Ή��j</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/21  22018  ��� ���b</br>
    /// <br>           : ���o�\�t�@�\�̏C���Ή��i�^��������ɕi�ԓ��̓��[�h�ɕύX���Č^������͂����ꍇ�̑Ή��j</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/27  21024�@���X�� ��</br>
    /// <br>           : ��^�I�v�V�����̃t���O�̌����C��(MANTIS[0014520])</br>
    /// <br>           : �t���^���Œ�ԍ�0(���i�����^)��PM7�Ɠ��l�ɔN�����k����悤�ɏC��(MANTIS[0014519])</br>
    /// <br></br>
    /// <br>Update Note: 2009/12/17  20056�@���n ���</br>
    /// <br>           : MANTIS[14559] �V���[�Y�^���ƌ^��(�ޕʋL��)�̃Z�b�g���@�ύX</br>
    /// <br>           : MANTIS[14790] �r�K�X�L���̃Z�b�g���@�ύX</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/04  21024�@���X�� ��</br>
    /// <br>           : MANTIS[0014831] �ԑ�^���������������ꍇ�̕����ԑ�^���������ꍇ�̍i�荞�ݕ��@�ύX </br>
    /// <br></br>
    /// <br>Update Note: 2010/03/29  20056�@���n ���</br>
    /// <br>           : MANTIS[0015220] �N���͈͂𐳂����\������悤�Ɉ��k���@�ύX</br>
    /// <br>           : MANTIS[0015168] ���q�����͑�^�����I�v�V�������l�������A��ɑ�^�����\�Ƃ���</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/19  22018�@��� ���b</br>
    /// <br>           : ���R�����I�v�V�����Ή��i���[�U�[�c�a�̎��R�����^���}�X�^���璊�o�j</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/01  22018�@��� ���b</br>
    /// <br>           : ���R�������i�}�X�����ł̎��q�����Ɋ֘A���ĕύX</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/25  22008�@���� ���n</br>
    /// <br>           : �I�t���C���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/15  22018�@��� ���b</br>
    /// <br>           : ���ʕ�����</br>
    /// <br>           :   �I�t���C���Ή� 2010/05/25 �̑g��</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/07  22008�@���� ���n</br>
    /// <br>           : MANTIS�Ή� 15715</br>
    /// <br>           :   �I�t���C�������Ɋւ��āASCM���l����������Ƃ���悤�ɏC��</br>
    /// <br></br>
    /// <br>Update Note: 2011/04/04  22008�@���� ���n</br>
    /// <br>           : �t���^�������iSearchByFullModelFixedNo�j�Ńt���^���Œ�ԍ����w�莞�͒񋟂̌��������Ȃ��悤�ɏC��</br>
    /// <br></br>
    /// <br>Update Note: 2012/05/28  20056�@���n ���</br>
    /// <br>           : SCM���� No135</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/27  20073�@�� �B</br>
    /// <br>           : �ޕʌ^������͂��A�^���I����ʂ��\�������ꍇ�ɁA������񂪃Z�b�g����Ȃ����ۂ̏C��</br>
    /// <br>Update Note: 2012/09/18  �e�c ���V</br>
    /// <br>           : �@���q�Ǘ��}�X�^��������A����̃f�[�^��ҏW���悤�Ƃ���ƃt���[�Y���Ă��܂����̏C��</br>
    /// <br>           : �A���q�Ǘ��}�X�^���G���[�ŕۑ��ł��Ȃ��Ȃ錏�̏C��</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/21 FSI�֓� �a�G</br>
    /// <br>           : 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>           : �ԗ��^���}�X�^����u���Y/�O�ԋ敪�v�u�n���h���ʒu���v��ǉ��Ŏ擾����悤�C��</br>
    /// </remarks>
    public class CarSearchController
    {
        #region [ �����o�[�ϐ���` ]
        private PMKEN01010E dataSet = null;

        // �����[�g�I�u�W�F�N�g �C���^�[�t�F�[�X
        private ICarModelCtlDB _ICarModelCtlDB = null;		//���q���������[�g
        private IColTrmEquInfDB _IColTrmEquInfDB = null;		//�J���[�E�g�����E������񃊃��[�g
        private IPrdTypYearDB _IPrdTypYearDB = null;
        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        private IFreeSearchModelSearchDB _IFreeSearchModelSearchDB = null;
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
        // --- ADD T.Nishi 2012/07/27 ---------->>>>>
        private ArrayList _equipmentRetWork = null;
        // --- ADD T.Nishi 2012/07/27 ----------<<<<<

        /// <summary>0:��^�_��Ȃ� 1:��^�_�񂠂�</summary>
        private int _bigCarOfferDiv;

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>0:���R�����Ȃ� 1:���R��������</summary>
        private int _freeSearchDiv;
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

        // ��^�����I�v�V�����p��^���[�J�[���X�g
        private List<int> bigMakerList = new List<int>(new int[] { 10, 12, 13, 16 }); // 14�F���{�t�H�[�h�͊֌W�Ȃ��H

        #endregion

        #region [ �R���X�g���N�^�E�f�X�g���N�^ ]
        /// <summary>
        /// �ԗ������R���g���[�� �R���X�g���N�^
        /// </summary>
        public CarSearchController()
        {
            // ��^�񋟋敪 �_���
            // 2009/10/27 >>>
            //PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData );
            // 2009/10/27 <<<
            //>>>2010/03/29
            //if (psBigCarOffer == PurchaseStatus.Contract || psBigCarOffer == PurchaseStatus.Trial_Contract)   // ��^�_�񂠂�
            //    _bigCarOfferDiv = 1;

            // ���q�����́A��^�I�v�V�����ɖ��֌W�ɑ�^�������\�Ƃ���
            _bigCarOfferDiv = 1;
            //<<<2010/03/29

            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            // ���R�����I�v�V�����`�F�b�N
            PurchaseStatus psFreeSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch );
            if ( psFreeSearch == PurchaseStatus.Contract || psFreeSearch == PurchaseStatus.Trial_Contract )
            {
                // ���R��������
                _freeSearchDiv = 1;
            }
            else
            {
                // ���R�����Ȃ�
                _freeSearchDiv = 0;
            }
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            dataSet = new PMKEN01010E();

            //// �����[�g�����ɕK�v�ȍ\���t�@�C����ǂݎ��A�����[�g�����C���t���X�g���N�`�����\������B
            //RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
        }

        /// <summary>
        /// �ԗ������R���g���[�� �f�X�g���N�^
        /// </summary>
        ~CarSearchController()
        {
        }
        #endregion

        #region [ �������� ]
        /// <summary>
        /// �ԗ��������\�b�h
        /// </summary>
        /// <param name="_searchCond">�ԗ���������</param>
        /// <param name="_carSearchInfo">�f�[�^�Z�b�g�N���X</param>
        /// <returns></returns>
        public CarSearchResultReport Search(CarSearchCondition _searchCond, ref PMKEN01010E _carSearchInfo)
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            dataSet.Clear();
            bool flgColorTrimSearched = false;

            if (_carSearchInfo.CarModelInfo != null && _carSearchInfo.CarModelInfo.Rows.Count > 0)
            {
                _carSearchInfo.AcceptChanges();
                dataSet.Merge(_carSearchInfo, false);
                ret = ColorTrimSearch();
                flgColorTrimSearched = true;
                // --- ADD T.Nishi 2012/07/27 ---------->>>>>
              #region �ԗ��������ݒ�
                if (_equipmentRetWork != null)
                {
                    foreach (CtgryEquipWork wkSource in _equipmentRetWork)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}",
                            dataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName, wkSource.EquipmentCode,
                            dataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, wkSource.EquipmentGenreCd);
                        PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])dataSet.CEqpDefDspInfo.Select(filter);
                        if (rows.Length > 0)
                        {
                            rows[0].SelectionState = true;
                        }
                    }
                }
              #endregion
                // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            }
            else if (_carSearchInfo.CarKindInfo != null && _carSearchInfo.CarKindInfo.Rows.Count > 0)
            {
                ret = CarModelInfoSearch(_searchCond, ref _carSearchInfo);
            }
            else
            {
                ret = CarKindInfoSearch(_searchCond);
            }

            // Summarizing
            if (ret == CarSearchResultReport.retSingleCarModel || flgColorTrimSearched)
            {
                PMKEN01010E.CarModelInfoRow[] retRows = (PMKEN01010E.CarModelInfoRow[])dataSet.CarModelInfoSummarized.Select("SelectionState = True");
                if (dataSet.CarModelUIData.Rows.Count == 0)
                {
                    if (retRows.Length > 0)
                    {
                        dataSet.CarModelUIData.AddCarModelInfoRowCopy(retRows[0]);
                        dataSet.CarModelUIData[0].ModelDesignationNo = _searchCond.ModelDesignationNo;
                        dataSet.CarModelUIData[0].CategoryNo = _searchCond.CategoryNo;
                        dataSet.CarModelUIData.AcceptChanges();
                    }
                }
                else
                {
                    if (retRows.Length > 0)
                    {
                        dataSet.CarModelUIData.AddCarModelInfoRowCopy(retRows[0]);
                        dataSet.CarModelUIData[1].ModelDesignationNo = _searchCond.ModelDesignationNo;
                        dataSet.CarModelUIData[1].CategoryNo = _searchCond.CategoryNo;
                        // 2009.01.28 >>>
                        //dataSet.CarModelUIData[1].ProduceFrameNoInput = dataSet.CarModelUIData[0].ProduceFrameNoInput;
                        dataSet.CarModelUIData[1].FrameNo= dataSet.CarModelUIData[0].FrameNo;
                        dataSet.CarModelUIData[1].SearchFrameNo = dataSet.CarModelUIData[0].SearchFrameNo;
                        // 2009.01.28 <<<
                        dataSet.CarModelUIData[1].ProduceTypeOfYearInput = dataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                        dataSet.CarModelUIData[0].Delete();
                        dataSet.CarModelUIData.AcceptChanges();
                    }
                }
                PMKEN01010E.CarModelUIDataTable carModelUITable = dataSet.CarModelUIData;
                PMKEN01010E.CarModelUIRow carModelUIRowTmp = dataSet.CarModelUIData[0];
                if (carModelUIRowTmp.AddiCarSpec1 != string.Empty)
                {
                    carModelUITable.AddiCarSpec1Column.Caption = retRows[0].AddiCarSpecTitle1;
                }
                if (carModelUIRowTmp.AddiCarSpec2 != string.Empty)
                {
                    carModelUITable.AddiCarSpec2Column.Caption = retRows[0].AddiCarSpecTitle2;
                }
                if (carModelUIRowTmp.AddiCarSpec3 != string.Empty)
                {
                    carModelUITable.AddiCarSpec3Column.Caption = retRows[0].AddiCarSpecTitle3;
                }
                if (carModelUIRowTmp.AddiCarSpec4 != string.Empty)
                {
                    carModelUITable.AddiCarSpec4Column.Caption = retRows[0].AddiCarSpecTitle4;
                }
                if (carModelUIRowTmp.AddiCarSpec5 != string.Empty)
                {
                    carModelUITable.AddiCarSpec5Column.Caption = retRows[0].AddiCarSpecTitle5;
                }
                if (carModelUIRowTmp.AddiCarSpec6 != string.Empty)
                {
                    carModelUITable.AddiCarSpec6Column.Caption = retRows[0].AddiCarSpecTitle6;
                }
            }
            if (dataSet.CarModelUIData.Rows.Count > 0)
            {
                dataSet.CarModelUIData[0].ModelDesignationNo = _searchCond.ModelDesignationNo;
                dataSet.CarModelUIData[0].CategoryNo = _searchCond.CategoryNo;
            }
            _carSearchInfo = (PMKEN01010E)dataSet.Copy();
            _carSearchInfo.CarSearchCondition = _searchCond;

            // --- ADD m.suzuki 2010/06/01 ---------->>>>>
            // DefaultView��Sort����ݒ肷��(���R�������i�}�X�����Ŏg�p�����)
            _carSearchInfo.CarModelInfo.DefaultView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", 
                _carSearchInfo.CarModelInfo.FreeSearchSortDivColumn.ColumnName,
                _carSearchInfo.CarModelInfo.FullModelColumn.ColumnName,
                _carSearchInfo.CarModelInfo.ModelGradeNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.BodyNameColumn.ColumnName,
                _carSearchInfo.CarModelInfo.DoorCountColumn.ColumnName,
                _carSearchInfo.CarModelInfo.EngineModelNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.EngineDisplaceNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.EDivNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.TransmissionNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.ShiftNmColumn.ColumnName,
                _carSearchInfo.CarModelInfo.WheelDriveMethodNmColumn.ColumnName
            );
            // --- ADD m.suzuki 2010/06/01 ----------<<<<<

            return ret;
        }

        // --- ADD 2012/09/18 Y.Wakita ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_extraInfo">�t���^���Œ�ԍ��z��</param>
        /// <param name="_carSearchInfo">�������ʃf�[�^�N���X</param>
        /// <returns></returns>
        public CarSearchResultReport SearchByFullModelFixedNo(CarMangInputExtraInfo _extraInfo, ref PMKEN01010E _carSearchInfo)
        {
            // �����A�Z���u���Ƃ̌݊����ׂ̈ɖ{���\�b�h��p�ӂ��܂��B
            //   �ʏ��CarSearchCondition���󂯎���(��)�̃��\�b�h���g�p���ĉ������B

            CarSearchCondition carSearchCond = new CarSearchCondition();
            carSearchCond.ModelDesignationNo = _extraInfo.ModelDesignationNo;
            carSearchCond.CategoryNo = _extraInfo.CategoryNo;
            carSearchCond.CarModel.ExhaustGasSign = _extraInfo.ExhaustGasSign;
            carSearchCond.CarModel.SeriesModel = _extraInfo.SeriesModel;
            carSearchCond.CarModel.CategorySign = _extraInfo.CategorySignModel;
            carSearchCond.MakerCode = _extraInfo.MakerCode;
            carSearchCond.ModelCode = _extraInfo.ModelCode;
            carSearchCond.ModelSubCode = _extraInfo.ModelSubCode;

            return SearchByFullModelFixedNo(_extraInfo.FullModelFixedNoAry, carSearchCond, ref _carSearchInfo);
        }
        // --- ADD 2012/09/18 Y.Wakita ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ��z��</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʔԍ�</param>
        /// <param name="_carSearchInfo">�������ʃf�[�^�N���X</param>
        /// <returns></returns>
        public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E _carSearchInfo )
        {
            // �����A�Z���u���Ƃ̌݊����ׂ̈ɖ{���\�b�h��p�ӂ��܂��B
            //   �ʏ��CarSearchCondition���󂯎���(��)�̃��\�b�h���g�p���ĉ������B

            CarSearchCondition carSearchCond = new CarSearchCondition();
            carSearchCond.ModelDesignationNo = modelDesignationNo;
            carSearchCond.CategoryNo = categoryNo;
            return SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref _carSearchInfo );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ��z��</param>
        /// <param name="carSearchCond">�Ԏ팟�������N���X</param>
        /// <param name="_carSearchInfo">�������ʃf�[�^�N���X</param>
        /// <returns></returns>
        public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E _carSearchInfo )
        {
            // �����A�Z���u���Ƃ̌݊����ׂ̈ɖ{���\�b�h��p�ӂ��܂��B
            //   �ʏ��freeSrchMdlFxdNo���󂯎���(��)�̃��\�b�h���g�p���ĉ������B
            return SearchByFullModelFixedNo( fullModelFixedNo, new string[0], carSearchCond, ref _carSearchInfo );
        }
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ��z��</param>
        /// <param name="freeSrchMdlFxdNo">���R�����^���Œ�ԍ��z��</param>
        /// <param name="carSearchCond">�Ԏ팟�������N���X</param>
        /// <param name="_carSearchInfo">�������ʃf�[�^�N���X</param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
        ////public CarSearchResultReport SearchByFullModelFixedNo(int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E _carSearchInfo)
        //public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E _carSearchInfo )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD
        public CarSearchResultReport SearchByFullModelFixedNo( int[] fullModelFixedNo, string[] freeSrchMdlFxdNo, CarSearchCondition carSearchCond, ref PMKEN01010E _carSearchInfo )
        // --- UPD m.suzuki 2010/04/19 ----------<<<<<
        {
            // -- ADD 2010/05/25 ----------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 -----------------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            // --- ADD T.Nishi 2012/07/27 ---------->>>>>
            _equipmentRetWork = null;
            // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            //���ʃN���X
            ArrayList kindList = null;

            ArrayList carModelRetList = null;
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList prdTypYearRetWork = null;
            ArrayList categoryEquipmentRetWork = null;
            ArrayList ctgyMdlLnkRetWork = null;
            ArrayList equipmentRetWork = null;

            CarModelCondWork _searchCond = new CarModelCondWork();
            _searchCond.FullModelFixedNos = fullModelFixedNo;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
            //_searchCond.ModelDesignationNo = modelDesignationNo;
            //_searchCond.CategoryNo = categoryNo;

            _searchCond.ModelDesignationNo = carSearchCond.ModelDesignationNo;
            _searchCond.CategoryNo = carSearchCond.CategoryNo;

            _searchCond.ExhaustGasSign = carSearchCond.CarModel.ExhaustGasSign;
            _searchCond.SeriesModel = carSearchCond.CarModel.SeriesModel;
            _searchCond.CategorySignModel = carSearchCond.CarModel.CategorySign;
            _searchCond.MakerCode = carSearchCond.MakerCode;
            _searchCond.ModelCode = carSearchCond.ModelCode;
            _searchCond.ModelSubCode = carSearchCond.ModelSubCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD

            if (_ICarModelCtlDB == null)
                _ICarModelCtlDB = MediationCarModelCtlDB.GetRemoteObject();
            // -- UPD 2011/04/04 -------------------------------------------->>>
            //_ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
            //                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
            //                            out equipmentRetWork);

            if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
            {
                _ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                                            out equipmentRetWork);
            }

            if (kindList == null)
            {
                kindList = new ArrayList();
            }
            // -- UPD 2011/04/04 --------------------------------------------<<<

            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            // ���R�����^���擾����
            //if ( _freeSearchDiv != 0 )
            if ( _freeSearchDiv != 0 && freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0 )
            {
                ArrayList fsKindList;
                ArrayList fsCarModelRetList;
                FreeSearchModelSCndtnWork fsSearchCond = CopyToFSCndtnFromCarModelCond( _searchCond );
                fsSearchCond.FreeSrchMdlFxdNos = freeSrchMdlFxdNo;
                if ( _IFreeSearchModelSearchDB == null )
                {
                    _IFreeSearchModelSearchDB = MediationFreeSearchModelSearchDB.GetRemoteObject();
                }
                _IFreeSearchModelSearchDB.GetCarFullModelNo( fsSearchCond, out fsKindList, out fsCarModelRetList );

                // �Ԏ탊�X�g
                if ( kindList == null && fsKindList != null && fsKindList.Count > 0 )
                {
                    kindList = new ArrayList();
                }
                foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                {
                    AddKindListDistinct( ref kindList, carKindInfo );
                }
                // �^�����X�g
                if ( carModelRetList == null && fsCarModelRetList != null && fsCarModelRetList.Count > 0 )
                {
                    carModelRetList = new ArrayList();
                }
                foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                {
                    carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                }
            }
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 ADD
            // 
            if ( kindList.Count == 0 )
            {
                if ( (_searchCond.ExhaustGasSign == string.Empty)
                    && (_searchCond.SeriesModel != string.Empty)
                    && (_searchCond.CategorySignModel == string.Empty) )
                {
                    _searchCond.ExhaustGasSign = carSearchCond.CarModel.SeriesModel;
                    _searchCond.SeriesModel = string.Empty;
                    
                    // -- UPD 2011/04/04 --------------------------->>>
                    //_ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                    //                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                    //                            out equipmentRetWork);
                    
                    if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
                    {
                        _ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                                                    out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                                                    out equipmentRetWork);
                    }
                    // -- UPD 2011/04/04 ---------------------------<<<
                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    // ���R�����^���擾����
                    //if ( _freeSearchDiv != 0 )
                    if ( _freeSearchDiv != 0 && freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0 )
                    {
                        ArrayList fsKindList;
                        ArrayList fsCarModelRetList;
                        FreeSearchModelSCndtnWork fsSearchCond = CopyToFSCndtnFromCarModelCond( _searchCond );
                        fsSearchCond.FreeSrchMdlFxdNos = freeSrchMdlFxdNo;
                        _IFreeSearchModelSearchDB.GetCarFullModelNo( fsSearchCond, out fsKindList, out fsCarModelRetList );

                        // �Ԏ탊�X�g
                        if ( kindList == null && fsKindList != null && fsKindList.Count > 0 )
                        {
                            kindList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                        {
                            AddKindListDistinct( ref kindList, carKindInfo );
                        }
                        // �^�����X�g
                        if ( carModelRetList == null && fsCarModelRetList != null && fsCarModelRetList.Count > 0 )
                        {
                            carModelRetList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                        {
                            carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                        }
                    }
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                    if ( kindList.Count > 0 ) // �V���[�Y���f���łȂ��r�K�X�L���Ō��������������A���̌����������X�V����B
                    {
                        carSearchCond.CarModel.ExhaustGasSign = _searchCond.ExhaustGasSign;
                        carSearchCond.CarModel.SeriesModel = string.Empty;
                    }
                }
                else if ( _searchCond.CategorySignModel == string.Empty )
                {
                    _searchCond.CategorySignModel = carSearchCond.CarModel.SeriesModel;
                    _searchCond.SeriesModel = carSearchCond.CarModel.ExhaustGasSign;
                    _searchCond.ExhaustGasSign = string.Empty;

                    // -- UPD 2011/04/04 -------------------------------------------->>>
                    //_ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                    //                            out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                    //                            out equipmentRetWork);

                    if (fullModelFixedNo != null && fullModelFixedNo.Length > 0)
                    {
                        _ICarModelCtlDB.GetCarFullModelNo(_searchCond, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork,
                                                    out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork, out categoryEquipmentRetWork,
                                                    out equipmentRetWork);
                    }
                    // -- UPD 2011/04/04 --------------------------------------------<<<

                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    // ���R�����^���擾����
                    //if ( _freeSearchDiv != 0 )
                    if ( _freeSearchDiv != 0 && freeSrchMdlFxdNo != null && freeSrchMdlFxdNo.Length > 0 )
                    {
                        ArrayList fsKindList;
                        ArrayList fsCarModelRetList;
                        FreeSearchModelSCndtnWork fsSearchCond = CopyToFSCndtnFromCarModelCond( _searchCond );
                        fsSearchCond.FreeSrchMdlFxdNos = freeSrchMdlFxdNo;
                        _IFreeSearchModelSearchDB.GetCarFullModelNo( fsSearchCond, out fsKindList, out fsCarModelRetList );

                        // �Ԏ탊�X�g
                        if ( kindList == null && fsKindList != null && fsKindList.Count > 0 )
                        {
                            kindList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                        {
                            AddKindListDistinct( ref kindList, carKindInfo );
                        }
                        // �^�����X�g
                        if ( carModelRetList == null && fsCarModelRetList != null && fsCarModelRetList.Count > 0 )
                        {
                            carModelRetList = new ArrayList();
                        }
                        foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                        {
                            carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                        }
                    }
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                    if ( kindList.Count > 0 ) // �V���[�Y���f���łȂ��r�K�X�L���Ō��������������A���̌����������X�V����B
                    {
                        carSearchCond.CarModel.ExhaustGasSign = _searchCond.ExhaustGasSign;
                        carSearchCond.CarModel.SeriesModel = _searchCond.SeriesModel;
                        carSearchCond.CarModel.CategorySign = _searchCond.CategorySignModel;
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/21 ADD
            // �����ŊY�����Ȃ���Ό^������͂Ƃ݂Ȃ��B
            if ( kindList.Count == 0 ) return ret;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/21 ADD

            #region �Ԏ���[CarKindInfoWork]
            // �Ԏ팟�����ʂ�DataTable�Ɋi�[����
            foreach (CarKindInfoWork wkCarKind in kindList)
            {
                PMKEN01010E.CarKindInfoRow row = _carSearchInfo.CarKindInfo.NewCarKindInfoRow();

                row.MakerCode = wkCarKind.MakerCode;
                row.MakerFullName = wkCarKind.MakerFullName;
                row.MakerHalfName = wkCarKind.MakerHalfName;
                row.ModelCode = wkCarKind.ModelCode;
                row.ModelSubCode = wkCarKind.ModelSubCode;
                row.ModelFullName = wkCarKind.ModelFullName;
                row.ModelHalfName = wkCarKind.ModelHalfName;
                row.EngineModelNm = wkCarKind.EngineModelNm;

                if (kindList.Count == 1)
                {
                    row.SelectionState = true;
                }
                else
                {
                    row.SelectionState = false;
                }
                _carSearchInfo.CarKindInfo.AddCarKindInfoRow(row);
            }
            #endregion

            PMKEN01010E.CarModelUIRow newRow = _carSearchInfo.CarModelUIData.NewCarModelInfoRow();
            newRow.MakerCode = _carSearchInfo.CarKindInfo[0].MakerCode;
            newRow.ModelCode = _carSearchInfo.CarKindInfo[0].ModelCode;
            newRow.ModelSubCode = _carSearchInfo.CarKindInfo[0].ModelSubCode;
            newRow.FullModel = string.Empty;
            newRow.DoorCount = 0;
            newRow.EngineModelNm = _carSearchInfo.CarKindInfo[0].EngineModelNm;

            _carSearchInfo.CarModelUIData.AddCarModelInfoRow(newRow);

            # region ���q���[CarModelRetWork]
            if (carModelRetList != null)
            {
                ret = CarModelInfoSet(carModelRetList, _carSearchInfo);
                for (int i = 0; i < _carSearchInfo.CarModelInfo.Count; i++)
                {
                    _carSearchInfo.CarModelInfo[i].SelectionState = true;
                }
                if (_carSearchInfo.CarModelInfo.Count > 0)
                // --- UPD 2013/03/21 ---------->>>>>
                    //_carSearchInfo.CarModelUIData[0].FullModel = _carSearchInfo.CarModelInfo[0].FullModel;
                {
                    _carSearchInfo.CarModelUIData[0].FullModel = _carSearchInfo.CarModelInfo[0].FullModel;

                    _carSearchInfo.CarModelUIData[0].DomesticForeignCode = _carSearchInfo.CarModelInfo[0].DomesticForeignCode;
                    _carSearchInfo.CarModelUIData[0].DomesticForeignName = _carSearchInfo.CarModelInfo[0].DomesticForeignName;
                    _carSearchInfo.CarModelUIData[0].HandleInfoCd = _carSearchInfo.CarModelInfo[0].HandleInfoCd;
                    _carSearchInfo.CarModelUIData[0].HandleInfoNm = _carSearchInfo.CarModelInfo[0].HandleInfoNm;
                }
                // --- UPD 2013/03/21 ----------<<<<<

            }
            # endregion

            # region �ޕʌ^�����[CtgyMdlLnkRetWork]
            // �ޕʌ^�����f�[�^�[�Z�b�g
            if (ctgyMdlLnkRetWork != null)
            {
                foreach (CtgyMdlLnkRetWork wkSource in ctgyMdlLnkRetWork)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/13 UPD
                    //if (modelDesignationNo == 0 || categoryNo == 0 ||
                    //    (modelDesignationNo == wkSource.ModelDesignationNo && categoryNo == wkSource.CategoryNo))
                    if ( _searchCond.ModelDesignationNo == 0 || _searchCond.CategoryNo == 0 ||
                        (_searchCond.ModelDesignationNo == wkSource.ModelDesignationNo && _searchCond.CategoryNo == wkSource.CategoryNo) )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/13 UPD
                    {
                        PMKEN01010E.CtgyMdlLnkInfoRow row = _carSearchInfo.CtgyMdlLnkInfo.NewCtgyMdlLnkInfoRow();

                        row.ModelDesignationNo = wkSource.ModelDesignationNo;
                        row.CategoryNo = wkSource.CategoryNo;
                        row.CarProperNo = wkSource.CarProperNo;
                        row.FullModelFixedNo = wkSource.FullModelFixedNo;

                        _carSearchInfo.CtgyMdlLnkInfo.AddCtgyMdlLnkInfoRow(row);
                    }
                }
            }
            # endregion

            # region ���Y�N�����[PrdTypYearRetWork]
            // ���Y�N�����f�[�^�[�Z�b�g
            if (prdTypYearRetWork != null)
            {
                foreach (PrdTypYearRetWork wkSource in prdTypYearRetWork)
                {
                    PMKEN01010E.PrdTypYearInfoRow row = _carSearchInfo.PrdTypYearInfo.NewPrdTypYearInfoRow();

                    row.MakerCode = wkSource.MakerCode;
                    row.FrameModel = wkSource.FrameModel;
                    row.StProduceFrameNo = wkSource.StProduceFrameNo;
                    row.EdProduceFrameNo = wkSource.EdProduceFrameNo;
                    row.ProduceTypeOfYear = wkSource.ProduceTypeOfYear;

                    _carSearchInfo.PrdTypYearInfo.AddPrdTypYearInfoRow(row);
                }
            }
            # endregion

            # region �^���ޕʏ��[CategoryEquipmentRetWork]
            // --- ADD T.Nishi 2012/07/27 ---------->>>>>
            _equipmentRetWork = equipmentRetWork;  //�������I���f�[�^�ޔ�
            // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            // �^���ޕʏ��f�[�^�[�Z�b�g
            if (categoryEquipmentRetWork != null)
            {
                foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                {
                    PMKEN01010E.CategoryEquipmentInfoRow row = _carSearchInfo.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                    row.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                    row.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                    row.EquipmentMngCode = wkSource.EquipmentMngCode;
                    row.EquipmentMngName = wkSource.EquipmentMngName;
                    row.EquipmentCode = wkSource.EquipmentCode;
                    row.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                    row.TbsPartsCode = wkSource.TbsPartsCode;
                    row.EquipmentName = wkSource.EquipmentName;
                    row.EquipmentShortName = wkSource.EquipmentShortName;
                    row.EquipmentIconCode = wkSource.EquipmentIconCode;
                    row.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                    row.EquipmentUnitName = wkSource.EquipmentUnitName;
                    row.EquipmentCnt = wkSource.EquipmentCnt;
                    row.EquipmentComment1 = wkSource.EquipmentComment1;
                    row.EquipmentComment2 = wkSource.EquipmentComment2;

                    _carSearchInfo.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(row);
                }
            }
            # endregion

            ColorTrimSearch(_carSearchInfo);

            #region �ԗ��������ݒ�
            if (equipmentRetWork != null)
            {
                foreach (CtgryEquipWork wkSource in equipmentRetWork)
                {
                    string filter = string.Format("{0}={1} AND {2}={3}",
                        _carSearchInfo.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName, wkSource.EquipmentCode,
                        _carSearchInfo.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, wkSource.EquipmentGenreCd);
                    PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])_carSearchInfo.CEqpDefDspInfo.Select(filter);
                    if (rows.Length > 0)
                    {
                        rows[0].SelectionState = true;
                    }
                }
            }
            #endregion

            return ret;
        }

        # region �� �Ԏ팟�� ��
        private CarSearchResultReport CarKindInfoSearch(CarSearchCondition _searchCond)
        {
            // -- ADD 2010/05/25 ------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 -------------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;

            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if (_searchCond.MakerCode != 0 && _bigCarOfferDiv == 0 && bigMakerList.Contains(_searchCond.MakerCode))
                return CarSearchResultReport.retFailed;

            //�������o�N���X
            CarModelCondWork carModelCondWork = new CarModelCondWork();

            // --- ADD T.Nishi 2012/07/27 ---------->>>>>
            _equipmentRetWork = null;  //�������I���f�[�^������
            // --- ADD T.Nishi 2012/07/27 ----------<<<<<
            //���ʃN���X
            ArrayList kindList = null;

            ArrayList carModelRetList = null;
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList prdTypYearRetWork = null;
            ArrayList categoryEquipmentRetWork = null;
            ArrayList ctgyMdlLnkRetWork = null;
            ArrayList equipmentRetWork = null;
            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            ArrayList fsKindList = null;
            ArrayList fsCarModelRetList = null;
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            try
            {
                _ICarModelCtlDB = MediationCarModelCtlDB.GetRemoteObject();
                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                if ( _freeSearchDiv != 0 )
                {
                    _IFreeSearchModelSearchDB = MediationFreeSearchModelSearchDB.GetRemoteObject();
                }
                // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                //�Ԏ�
                if (_searchCond.Type != CarSearchType.csCategory)
                {
                    carModelCondWork.MakerCode = _searchCond.MakerCode;
                    carModelCondWork.ModelCode = _searchCond.ModelCode;
                    carModelCondWork.ModelSubCode = _searchCond.ModelSubCode;
                }
                carModelCondWork.SearchMode = 0; // 0 : �Ԏ��񌟍�

                switch (_searchCond.Type)
                {
                    case CarSearchType.csCategory:      // �ޕʌ���
                        carModelCondWork.ModelDesignationNo = _searchCond.ModelDesignationNo;
                        carModelCondWork.CategoryNo = _searchCond.CategoryNo;

                        // �ޕʂł̎Ԏ팟��������
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                        //    out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                        //    out equipmentRetWork );
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                                out equipmentRetWork );
                        }
                        else
                        {
                            // ���R�����^��Only�ˌ�������ArrayList������
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            categoryEquipmentRetWork = new ArrayList();
                            equipmentRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // ���R�����^������
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarCtgyMdl( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                            {
                                AddKindListDistinct( ref kindList, carKindInfo ); // �Ԏ탊�X�g
                            }
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) ); // �^�����X�g
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        break;
                    case CarSearchType.csModel:         // �^������
                        carModelCondWork.ExhaustGasSign = _searchCond.CarModel.ExhaustGasSign;
                        carModelCondWork.SeriesModel = _searchCond.CarModel.SeriesModel;
                        carModelCondWork.CategorySignModel = _searchCond.CarModel.CategorySign;
                        // �ԗ��^��(�V���[�Y/�t��)�ł̎Ԏ팟��������
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                        }
                        else
                        {
                            // ���R�����^��Only�ˌ�������ArrayList������
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            ctgyMdlLnkRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // ���R�����^������
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                            {
                                AddKindListDistinct( ref kindList, carKindInfo );
                            }
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        if (kindList.Count == 0)
                        {
                            if ((carModelCondWork.ExhaustGasSign == string.Empty)
                                && (carModelCondWork.SeriesModel != string.Empty)
                                && (carModelCondWork.CategorySignModel == string.Empty))
                            {
                                carModelCondWork.ExhaustGasSign = _searchCond.CarModel.SeriesModel;
                                carModelCondWork.SeriesModel = string.Empty;
                                // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                                //_ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                                if ( !_searchCond.FreeSearchModelOnly )
                                {
                                    _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                                }
                                else
                                {
                                    // ���R�����^��Only�ˌ�������ArrayList������
                                    carModelRetList = new ArrayList();
                                    kindList = new ArrayList();
                                    colorCdRetWork = new ArrayList();
                                    trimCdRetWork = new ArrayList();
                                    cEqpDefDspRetWork = new ArrayList();
                                    prdTypYearRetWork = new ArrayList();
                                    ctgyMdlLnkRetWork = new ArrayList();
                                }
                                // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                                // ���R�����^������
                                if ( _freeSearchDiv != 0 )
                                {
                                    _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                                    foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                                    {
                                        AddKindListDistinct( ref kindList, carKindInfo );
                                    }
                                    foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                                    {
                                        carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                                    }
                                }
                                // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                                
                                if (kindList.Count > 0) // �V���[�Y���f���łȂ��r�K�X�L���Ō��������������A���̌����������X�V����B
                                {
                                    _searchCond.CarModel.ExhaustGasSign = carModelCondWork.ExhaustGasSign;
                                    _searchCond.CarModel.SeriesModel = string.Empty;
                                }
                            }
                            else if (carModelCondWork.CategorySignModel == string.Empty)
                            {
                                carModelCondWork.CategorySignModel = carModelCondWork.SeriesModel;
                                carModelCondWork.SeriesModel = carModelCondWork.ExhaustGasSign;
                                carModelCondWork.ExhaustGasSign = string.Empty;
                                // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                                //_ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                                if ( !_searchCond.FreeSearchModelOnly )
                                {
                                    _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                                }
                                else
                                {
                                    // ���R�����^��Only�ˌ�������ArrayList������
                                    carModelRetList = new ArrayList();
                                    kindList = new ArrayList();
                                    colorCdRetWork = new ArrayList();
                                    trimCdRetWork = new ArrayList();
                                    cEqpDefDspRetWork = new ArrayList();
                                    prdTypYearRetWork = new ArrayList();
                                    ctgyMdlLnkRetWork = new ArrayList();
                                }
                                // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                                // ���R�����^������
                                if ( _freeSearchDiv != 0 )
                                {
                                    _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                                    foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                                    {
                                        AddKindListDistinct( ref kindList, carKindInfo );
                                    }
                                    foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                                    {
                                        carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                                    }
                                }
                                // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                                
                                if (kindList.Count > 0) // �V���[�Y���f���łȂ��r�K�X�L���Ō��������������A���̌����������X�V����B
                                {
                                    _searchCond.CarModel.ExhaustGasSign = carModelCondWork.ExhaustGasSign;
                                    _searchCond.CarModel.SeriesModel = carModelCondWork.SeriesModel;
                                    _searchCond.CarModel.CategorySign = carModelCondWork.CategorySignModel;
                                }
                            }

                        }
                        break;
                    case CarSearchType.csEngineModel:   // �G���W���^������
                        carModelCondWork.EngineModelNm = _searchCond.EngineModel.ModelNm;
                        // �G���W���^���ł̎Ԏ팟��������
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarEngine( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                        }
                        else
                        {
                            // ���R�����^��Only�ˌ�������ArrayList������
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // ���R�����^������
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarEngine( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                            {
                                AddKindListDistinct( ref kindList, carKindInfo ); // �Ԏ탊�X�g
                            }
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) ); // �^�����X�g
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        
                        break;
                    case CarSearchType.csPlate:         // �v���[�g����
                        carModelCondWork.ModelPlate = _searchCond.ModelPlate;
                        // �v���[�g�ԍ��ł̎Ԏ팟��������
                        _ICarModelCtlDB.GetCarPlate(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);
                        break;
                }

                //switch (kindList.Count)
                //{
                //    case 0:
                //        ret = CarSearchResultReport.retFailed;
                //        return ret;
                //    case 1:
                //        if (carModelRetList.Count == 1)
                //        {
                //            ret = CarSearchResultReport.retSingleCarModel;
                //        }
                //        else
                //        {
                //            ret = CarSearchResultReport.retMultipleCarModel;
                //        }
                //        break;
                //    default:
                //        ret = CarSearchResultReport.retMultipleCarKind;
                //        break;
                //}

                #region �Ԏ���[CarKindInfoWork]
                // �Ԏ팟�����ʂ�DataTable�Ɋi�[����
                foreach (CarKindInfoWork wkCarKind in kindList)
                {
                    if (_bigCarOfferDiv == 0 && bigMakerList.Contains(wkCarKind.MakerCode)) // ��^�_��Ȃ��ő�^���[�J�[�͓o�^���Ȃ��B
                        continue;

                    PMKEN01010E.CarKindInfoRow row = dataSet.CarKindInfo.NewCarKindInfoRow();

                    row.MakerCode = wkCarKind.MakerCode;
                    row.MakerFullName = wkCarKind.MakerFullName;
                    row.MakerHalfName = wkCarKind.MakerHalfName;
                    row.ModelCode = wkCarKind.ModelCode;
                    row.ModelSubCode = wkCarKind.ModelSubCode;
                    row.ModelFullName = wkCarKind.ModelFullName;
                    row.ModelHalfName = wkCarKind.ModelHalfName;
                    row.EngineModelNm = wkCarKind.EngineModelNm;

                    dataSet.CarKindInfo.AddCarKindInfoRow(row);
                }
                if (dataSet.CarKindInfo.Count == 0)
                {
                    ret = CarSearchResultReport.retFailed;
                    return ret;
                }
                if (dataSet.CarKindInfo.Count == 1)
                {
                    dataSet.CarKindInfo[0].SelectionState = true;
                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    if (!_searchCond.FreeSearchModelOnly)
                    {
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        #region [ ��^�t�B���^�����O�ɂ��Ԏ킪1�ɂȂ����ꍇ�^�����⑫�������s�� ]
                        if ( kindList.Count != 1 ) // �Ԏ킪1�łȂ��̂ɎԎ�e�[�u���ɂ�1�����Ȃ��̂͑�^�t�B���^�����O�̂��߂Ȃ̂�
                        { // �K�v�Ȍ^���̏�񂪂Ƃ�Ȃ������͂��B���@�^�����擾�����������ōs���B
                            //�Ԏ�
                            carModelCondWork.MakerCode = dataSet.CarKindInfo[0].MakerCode;
                            carModelCondWork.ModelCode = dataSet.CarKindInfo[0].ModelCode;
                            carModelCondWork.ModelSubCode = dataSet.CarKindInfo[0].ModelSubCode;
                            carModelCondWork.SearchMode = 1; // 1 : �^����񌟍�

                            switch ( _searchCond.Type )
                            {
                                case CarSearchType.csCategory:      // �ޕʌ���
                                    carModelCondWork.ModelDesignationNo = _searchCond.ModelDesignationNo;
                                    carModelCondWork.CategoryNo = _searchCond.CategoryNo;
                                    // �ޕʂł̎Ԏ팟��������
                                    _ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                        out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                                        out equipmentRetWork );
                                    break;
                                case CarSearchType.csModel:         // �^������
                                    carModelCondWork.ExhaustGasSign = _searchCond.CarModel.ExhaustGasSign;
                                    carModelCondWork.SeriesModel = _searchCond.CarModel.SeriesModel;
                                    carModelCondWork.CategorySignModel = _searchCond.CarModel.CategorySign;
                                    // �ԗ��^��(�V���[�Y/�t��)�ł̎Ԏ팟��������
                                    _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                                    break;
                                case CarSearchType.csEngineModel:   // �G���W���^������
                                    carModelCondWork.EngineModelNm = dataSet.CarKindInfo[0].EngineModelNm;
                                    // �G���W���^���ł̎Ԏ팟��������
                                    _ICarModelCtlDB.GetCarEngine( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                                    break;
                                case CarSearchType.csPlate:         // �v���[�g����
                                    carModelCondWork.ModelPlate = _searchCond.ModelPlate;
                                    // �v���[�g�ԍ��ł̎Ԏ팟��������
                                    _ICarModelCtlDB.GetCarPlate( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                                    break;
                            }
                            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                            // ���R�����^���擾�����}�[�W����(kindList��carModelRetList��out�w��ŏ㏑������Ă��܂���)
                            if ( _freeSearchDiv != 0 )
                            {
                                // �Ԏ탊�X�g
                                if ( fsKindList != null )
                                {
                                    foreach ( FreeSearchModelSCarKindInfoWork carKindInfo in fsKindList )
                                    {
                                        AddKindListDistinct( ref kindList, carKindInfo );
                                    }
                                }
                                // �^�����X�g
                                if ( fsCarModelRetList != null )
                                {
                                    foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                                    {
                                        carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                                    }
                                }
                            }
                            // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        }
                        #endregion
                    // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                    }
                    // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                    if (carModelRetList.Count == 1)
                    {
                        ret = CarSearchResultReport.retSingleCarModel;
                    }
                    else
                    {
                        ret = CarSearchResultReport.retMultipleCarModel;
                    }
                }
                #endregion

                # region ���͏��i���������j�ޔ�
                PMKEN01010E.CarModelUIRow newRow = dataSet.CarModelUIData.NewCarModelInfoRow();
                newRow.MakerCode = _searchCond.MakerCode;
                newRow.ModelCode = _searchCond.ModelCode;
                newRow.ModelSubCode = _searchCond.ModelSubCode;
                newRow.FullModel = _searchCond.CarModel.FullModel;
                newRow.EngineModelNm = _searchCond.EngineModel.ModelNm;
                newRow.DoorCount = 0;

                dataSet.CarModelUIData.AddCarModelInfoRow(newRow);
                # endregion

                if (dataSet.CarKindInfo.Count > 1) // �Ԏ킪1������Ȃ�^�����Ȃǂ͐ݒ肵�Ȃ��B
                {
                    ret = CarSearchResultReport.retMultipleCarKind;
                    return ret;
                }

                # region ���q���[CarModelRetWork]
                if (carModelRetList != null)
                {
                    ret = CarModelInfoSet(carModelRetList);
                }
                # endregion

                # region �ޕʌ^�����[CtgyMdlLnkRetWork]
                // �ޕʌ^�����f�[�^�[�Z�b�g
                if (ctgyMdlLnkRetWork != null)
                {
                    foreach (CtgyMdlLnkRetWork wkSource in ctgyMdlLnkRetWork)
                    {
                        PMKEN01010E.CtgyMdlLnkInfoRow row = dataSet.CtgyMdlLnkInfo.NewCtgyMdlLnkInfoRow();

                        row.ModelDesignationNo = wkSource.ModelDesignationNo;
                        row.CategoryNo = wkSource.CategoryNo;
                        row.CarProperNo = wkSource.CarProperNo;
                        row.FullModelFixedNo = wkSource.FullModelFixedNo;

                        dataSet.CtgyMdlLnkInfo.AddCtgyMdlLnkInfoRow(row);
                    }
                }
                # endregion

                # region ���Y�N�����[PrdTypYearRetWork]
                // ���Y�N�����f�[�^�[�Z�b�g
                if (prdTypYearRetWork != null)
                {
                    foreach (PrdTypYearRetWork wkSource in prdTypYearRetWork)
                    {
                        PMKEN01010E.PrdTypYearInfoRow row = dataSet.PrdTypYearInfo.NewPrdTypYearInfoRow();

                        row.MakerCode = wkSource.MakerCode;
                        row.FrameModel = wkSource.FrameModel;
                        row.StProduceFrameNo = wkSource.StProduceFrameNo;
                        row.EdProduceFrameNo = wkSource.EdProduceFrameNo;
                        row.ProduceTypeOfYear = wkSource.ProduceTypeOfYear;

                        dataSet.PrdTypYearInfo.AddPrdTypYearInfoRow(row);
                    }
                }
                # endregion

                # region �^���ޕʏ��[CategoryEquipmentRetWork]
                // �^���ޕʏ��f�[�^�[�Z�b�g
                if (categoryEquipmentRetWork != null)
                {
                    foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow row = dataSet.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                        row.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                        row.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                        row.EquipmentMngCode = wkSource.EquipmentMngCode;
                        row.EquipmentMngName = wkSource.EquipmentMngName;
                        row.EquipmentCode = wkSource.EquipmentCode;
                        row.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                        row.TbsPartsCode = wkSource.TbsPartsCode;
                        row.EquipmentName = wkSource.EquipmentName;
                        row.EquipmentShortName = wkSource.EquipmentShortName;
                        row.EquipmentIconCode = wkSource.EquipmentIconCode;
                        row.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                        row.EquipmentUnitName = wkSource.EquipmentUnitName;
                        row.EquipmentCnt = wkSource.EquipmentCnt;
                        row.EquipmentComment1 = wkSource.EquipmentComment1;
                        row.EquipmentComment2 = wkSource.EquipmentComment2;

                        dataSet.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(row);
                    }
                }
                # endregion

                // --- ADD T.Nishi 2012/07/27 ---------->>>>>
                _equipmentRetWork = equipmentRetWork;  //�������I���f�[�^�ޔ�
                // --- ADD T.Nishi 2012/07/27 ----------<<<<<
                if (ret == CarSearchResultReport.retSingleCarModel)
                {
                    //ColorTrimSearch();
                    if (carModelRetList.Count > 1) // �����̌^�����������ꂽ���A���k���ꂽ�ꍇ�̓J���[�E�g�������擾�������s��
                    {
                        ColorTrimSearch();
                    }
                    else
                    {
                        ColorTrimSet(colorCdRetWork, trimCdRetWork, cEqpDefDspRetWork, dataSet);
                        SetSummarizedData(dataSet);
                    }
                    #region �ԗ��������ݒ�
                    if (equipmentRetWork != null)
                    {
                        foreach (CtgryEquipWork wkSource in equipmentRetWork)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}",
                                dataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName, wkSource.EquipmentCode,
                                dataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName, wkSource.EquipmentGenreCd);
                            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])dataSet.CEqpDefDspInfo.Select(filter);
                            if (rows.Length > 0)
                            {
                                rows[0].SelectionState = true;
                            }
                        }
                    }
                    #endregion
                }

            }
            catch
            {
                ret = CarSearchResultReport.retError;
            }
            finally
            {
                // �S�� DataTable �ɑޔ����Ă���̂ŃN���A����
            }
            return ret;
        }
        # endregion

        #region �� �^������ ��
        private CarSearchResultReport CarModelInfoSearch(CarSearchCondition _searchCond, ref PMKEN01010E _carSearchInfo)
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;

            //�������o�N���X
            CarModelCondWork carModelCondWork = new CarModelCondWork();

            //���ʃN���X
            ArrayList carModelRetList = null;
            ArrayList kindList = null;
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList prdTypYearRetWork = null;
            ArrayList categoryEquipmentRetWork = null;
            ArrayList ctgyMdlLnkRetWork = null;
            ArrayList equipmentRetWork = null;
            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            ArrayList fsKindList;
            ArrayList fsCarModelRetList;
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            // �I����ԂƂȂ��Ă���ŏ��̃f�[�^�̃��[�J�[�E�Ԏ�E�Ԏ�T�u�R�[�h��ݒ肷��
            PMKEN01010E.CarKindInfoRow[] rowCarKindInfo = _carSearchInfo.CarKindInfo.Select("SelectionState = True") as PMKEN01010E.CarKindInfoRow[];
            # region �� �ԗ����� ��
            try
            {
                //�Ԏ�
                carModelCondWork.MakerCode = rowCarKindInfo[0].MakerCode;
                carModelCondWork.ModelCode = rowCarKindInfo[0].ModelCode;
                carModelCondWork.ModelSubCode = rowCarKindInfo[0].ModelSubCode;
                carModelCondWork.SearchMode = 1; // 1 : �^����񌟍�

                switch (_searchCond.Type)
                {
                    case CarSearchType.csCategory:      // �ޕʌ���
                        carModelCondWork.ModelDesignationNo = _searchCond.ModelDesignationNo;
                        carModelCondWork.CategoryNo = _searchCond.CategoryNo;
                        // �ޕʂł̎Ԏ팟��������
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarCtgyMdl(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                        //    out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                        //    out equipmentRetWork);
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarCtgyMdl( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork,
                                out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out categoryEquipmentRetWork,
                                out equipmentRetWork );
                        }
                        else
                        {
                            // ���R����ONLY�ˌ������ʂ�������
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            categoryEquipmentRetWork = new ArrayList();
                            equipmentRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // ���R�����^���擾
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarCtgyMdl( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        break;
                    case CarSearchType.csModel:         // �^������
                        carModelCondWork.ExhaustGasSign = _searchCond.CarModel.ExhaustGasSign;
                        carModelCondWork.SeriesModel = _searchCond.CarModel.SeriesModel;
                        carModelCondWork.CategorySignModel = _searchCond.CarModel.CategorySign;
                        // �ԗ��^��(�V���[�Y/�t��)�ł̎Ԏ팟��������
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarModel( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork );
                        }
                        else
                        {
                            // ���R����ONLY�ˌ������ʂ�������
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                            ctgyMdlLnkRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        //if ((kindList.Count == 0)
                        //    && (carModelCondWork.ExhaustGasSign == "")
                        //    && (carModelCondWork.SeriesModel != "")
                        //    && (carModelCondWork.CategorySignModel == ""))
                        //{
                        //    carModelCondWork.ExhaustGasSign = _searchCond.CarModel.SeriesModel;
                        //    carModelCondWork.SeriesModel = "";
                        //    carModelCondWork.CategorySignModel = "";
                        //    _ICarModelCtlDB.GetCarModel(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork, out ctgyMdlLnkRetWork);
                        //}

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // ���R�����^���擾
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarModel( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                        break;
                    case CarSearchType.csEngineModel:   // �G���W���^������
                        carModelCondWork.EngineModelNm = rowCarKindInfo[0].EngineModelNm;
                        // �G���W���^���ł̎Ԏ팟��������
                        // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                        //_ICarModelCtlDB.GetCarEngine(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);
                        if ( !_searchCond.FreeSearchModelOnly )
                        {
                            _ICarModelCtlDB.GetCarEngine( carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork );
                        }
                        else
                        {
                            // ���R����ONLY�ˌ������ʂ�������
                            carModelRetList = new ArrayList();
                            kindList = new ArrayList();
                            colorCdRetWork = new ArrayList();
                            trimCdRetWork = new ArrayList();
                            cEqpDefDspRetWork = new ArrayList();
                            prdTypYearRetWork = new ArrayList();
                        }
                        // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                        // ���R�����^���擾
                        if ( _freeSearchDiv != 0 )
                        {
                            _IFreeSearchModelSearchDB.GetCarEngine( CopyToFSCndtnFromCarModelCond( carModelCondWork ), out fsKindList, out fsCarModelRetList );
                            foreach ( FreeSearchModelSRetWork carModelRet in fsCarModelRetList )
                            {
                                carModelRetList.Add( CopyToCarModelRetFromFSCarModelRet( carModelRet ) );
                            }
                        }
                        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
                        
                        break;
                    case CarSearchType.csPlate:         // �v���[�g����
                        carModelCondWork.ModelPlate = _searchCond.ModelPlate;
                        // �v���[�g�ԍ��ł̎Ԏ팟��������
                        _ICarModelCtlDB.GetCarPlate(carModelCondWork, out carModelRetList, out kindList, out colorCdRetWork, out trimCdRetWork, out cEqpDefDspRetWork, out prdTypYearRetWork);
                        break;
                }

                # region �� �f�[�^�Z�b�g ��

                # region �Ԏ���N���X
                if (carModelRetList.Count == 1)
                {
                    ret = CarSearchResultReport.retSingleCarModel;
                }
                else if (carModelRetList.Count > 1)
                {
                    ret = CarSearchResultReport.retMultipleCarModel;
                }
                # region ���͏��i���������j�ޔ�
                PMKEN01010E.CarModelUIRow newRow = dataSet.CarModelUIData.NewCarModelInfoRow();
                newRow.MakerCode = _carSearchInfo.CarModelUIData[0].MakerCode;
                newRow.ModelCode = _carSearchInfo.CarModelUIData[0].ModelCode;
                newRow.ModelSubCode = _carSearchInfo.CarModelUIData[0].ModelSubCode;
                newRow.FullModel = _carSearchInfo.CarModelUIData[0].FullModel;
                newRow.EngineModelNm = _carSearchInfo.CarModelUIData[0].EngineModelNm;
                newRow.DoorCount = _carSearchInfo.CarModelUIData[0].DoorCount;
                newRow.ModelDesignationNo = _carSearchInfo.CarModelUIData[0].ModelDesignationNo;
                newRow.CategoryNo = _carSearchInfo.CarModelUIData[0].CategoryNo;

                dataSet.CarModelUIData.AddCarModelInfoRow(newRow);
                # endregion

                # endregion

                # region ���q���
                if (carModelRetList != null)
                {
                    ret = CarModelInfoSet(carModelRetList);
                }
                # endregion

                # region �ޕʌ^�����
                // �ޕʌ^�����f�[�^�[�Z�b�g
                if (ctgyMdlLnkRetWork != null)
                {
                    foreach (CtgyMdlLnkRetWork wkSource in ctgyMdlLnkRetWork)
                    {
                        PMKEN01010E.CtgyMdlLnkInfoRow row = dataSet.CtgyMdlLnkInfo.NewCtgyMdlLnkInfoRow();

                        row.ModelDesignationNo = wkSource.ModelDesignationNo;
                        row.CategoryNo = wkSource.CategoryNo;
                        row.CarProperNo = wkSource.CarProperNo;
                        row.FullModelFixedNo = wkSource.FullModelFixedNo;

                        dataSet.CtgyMdlLnkInfo.AddCtgyMdlLnkInfoRow(row);
                    }
                }
                # endregion

                # region ���Y�N�����
                // ���Y�N�����f�[�^�[�Z�b�g
                if (prdTypYearRetWork != null)
                {
                    foreach (PrdTypYearRetWork wkSource in prdTypYearRetWork)
                    {
                        PMKEN01010E.PrdTypYearInfoRow row = dataSet.PrdTypYearInfo.NewPrdTypYearInfoRow();

                        row.MakerCode = wkSource.MakerCode;
                        row.FrameModel = wkSource.FrameModel;
                        row.StProduceFrameNo = wkSource.StProduceFrameNo;
                        row.EdProduceFrameNo = wkSource.EdProduceFrameNo;
                        row.ProduceTypeOfYear = wkSource.ProduceTypeOfYear;

                        dataSet.PrdTypYearInfo.AddPrdTypYearInfoRow(row);
                    }
                }
                # endregion

                # region �^���ޕʏ��
                // �^���ޕʏ��f�[�^�[�Z�b�g
                if (categoryEquipmentRetWork != null)
                {
                    foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow row = dataSet.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                        row.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                        row.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                        row.EquipmentMngCode = wkSource.EquipmentMngCode;
                        row.EquipmentMngName = wkSource.EquipmentMngName;
                        row.EquipmentCode = wkSource.EquipmentCode;
                        row.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                        row.TbsPartsCode = wkSource.TbsPartsCode;
                        row.EquipmentName = wkSource.EquipmentName;
                        row.EquipmentShortName = wkSource.EquipmentShortName;
                        row.EquipmentIconCode = wkSource.EquipmentIconCode;
                        row.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                        row.EquipmentUnitName = wkSource.EquipmentUnitName;
                        row.EquipmentCnt = wkSource.EquipmentCnt;
                        row.EquipmentComment1 = wkSource.EquipmentComment1;
                        row.EquipmentComment2 = wkSource.EquipmentComment2;

                        dataSet.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(row);
                    }
                }
                # endregion

                if (ret == CarSearchResultReport.retSingleCarModel)
                {
                    //ColorTrimSearch();
                    ColorTrimSet(colorCdRetWork, trimCdRetWork, cEqpDefDspRetWork, dataSet);
                    SetSummarizedData(dataSet);
                }
                # endregion
            }
            catch
            {
                ret = CarSearchResultReport.retError;
            }
            finally
            {
            }
            return ret;
            # endregion
        }
        #endregion

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        # region �� ���R�����֘A ��

        # region [�^�ϊ�����]
        /// <summary>
        /// �񋟌^������.���������ˎ��R�����^������.�������� �ϊ�
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <returns></returns>
        private FreeSearchModelSCndtnWork CopyToFSCndtnFromCarModelCond( CarModelCondWork carModelCondWork )
        {
            FreeSearchModelSCndtnWork fsModelSCndtn = new FreeSearchModelSCndtnWork();

            fsModelSCndtn.CategoryNo = carModelCondWork.CategoryNo;
            fsModelSCndtn.CategorySignModel = carModelCondWork.CategorySignModel;
            fsModelSCndtn.EngineModelNm = carModelCondWork.EngineModelNm;
            fsModelSCndtn.ExhaustGasSign = carModelCondWork.ExhaustGasSign;
            //fsModelSCndtn.FullModelFixedNos = carModelCondWork.FullModelFixedNos;
            fsModelSCndtn.MakerCode = carModelCondWork.MakerCode;
            fsModelSCndtn.ModelCode = carModelCondWork.ModelCode;
            fsModelSCndtn.ModelDesignationNo = carModelCondWork.ModelDesignationNo;
            fsModelSCndtn.ModelPlate = carModelCondWork.ModelPlate;
            fsModelSCndtn.ModelSubCode = carModelCondWork.ModelSubCode;
            fsModelSCndtn.SearchMode = carModelCondWork.SearchMode;
            fsModelSCndtn.SeriesModel = carModelCondWork.SeriesModel;

            return fsModelSCndtn;
        }
        /// <summary>
        /// ���R�����^������.�Ԏ���˒񋟌^������.�Ԏ��� �ϊ�
        /// </summary>
        /// <param name="carKindInfo"></param>
        /// <returns></returns>
        private CarKindInfoWork CopyToCarKindInfoFromFSCarKindInfo( FreeSearchModelSCarKindInfoWork carKindInfo )
        {
            CarKindInfoWork retWork = new CarKindInfoWork();

            retWork.EngineModelNm = carKindInfo.EngineModelNm;
            retWork.MakerCode = carKindInfo.MakerCode;
            retWork.MakerFullName = carKindInfo.MakerFullName;
            retWork.MakerHalfName = carKindInfo.MakerHalfName;
            retWork.ModelCode = carKindInfo.ModelCode;
            retWork.ModelFullName = carKindInfo.ModelFullName;
            retWork.ModelHalfName = carKindInfo.ModelHalfName;
            retWork.ModelSubCode = carKindInfo.ModelSubCode;

            return retWork;
        }
        /// <summary>
        /// ���R�����^������.�^�����˒񋟌^������.�^����� �ϊ�
        /// </summary>
        /// <param name="carModelRet"></param>
        /// <returns></returns>
        private CarModelRetWork CopyToCarModelRetFromFSCarModelRet( FreeSearchModelSRetWork carModelRet )
        {
            CarModelRetWorkEx retWork = new CarModelRetWorkEx();

            retWork.MakerCode = carModelRet.MakerCode;
            retWork.MakerFullName = carModelRet.MakerFullName;
            retWork.MakerHalfName = carModelRet.MakerHalfName;
            retWork.ModelCode = carModelRet.ModelCode;
            retWork.ModelSubCode = carModelRet.ModelSubCode;
            retWork.ModelFullName = carModelRet.ModelFullName;
            retWork.ModelHalfName = carModelRet.ModelHalfName;
            retWork.SystematicCode = carModelRet.SystematicCode;
            retWork.SystematicName = carModelRet.SystematicName;
            retWork.ProduceTypeOfYearCd = carModelRet.ProduceTypeOfYearCd;
            retWork.ProduceTypeOfYearNm = carModelRet.ProduceTypeOfYearNm;
            retWork.StProduceTypeOfYear = carModelRet.StProduceTypeOfYear;
            retWork.EdProduceTypeOfYear = carModelRet.EdProduceTypeOfYear;
            retWork.DoorCount = carModelRet.DoorCount;
            retWork.BodyNameCode = carModelRet.BodyNameCode;
            retWork.BodyName = carModelRet.BodyName;
            retWork.CarProperNo = carModelRet.CarProperNo;
            retWork.FullModelFixedNo = carModelRet.FullModelFixedNo;
            retWork.ExhaustGasSign = carModelRet.ExhaustGasSign;
            retWork.SeriesModel = carModelRet.SeriesModel;
            retWork.CategorySignModel = carModelRet.CategorySignModel;
            retWork.FullModel = carModelRet.FullModel;
            retWork.FrameModel = carModelRet.FrameModel;
            retWork.StProduceFrameNo = carModelRet.StProduceFrameNo;
            retWork.EdProduceFrameNo = carModelRet.EdProduceFrameNo;
            retWork.ModelGradeNm = carModelRet.ModelGradeNm;
            retWork.EngineModelNm = carModelRet.EngineModelNm;
            retWork.EngineDisplaceNm = carModelRet.EngineDisplaceNm;
            retWork.EDivNm = carModelRet.EDivNm;
            retWork.TransmissionNm = carModelRet.TransmissionNm;
            retWork.WheelDriveMethodNm = carModelRet.WheelDriveMethodNm;
            retWork.ShiftNm = carModelRet.ShiftNm;
            retWork.AddiCarSpec1 = carModelRet.AddiCarSpec1;
            retWork.AddiCarSpec2 = carModelRet.AddiCarSpec2;
            retWork.AddiCarSpec3 = carModelRet.AddiCarSpec3;
            retWork.AddiCarSpec4 = carModelRet.AddiCarSpec4;
            retWork.AddiCarSpec5 = carModelRet.AddiCarSpec5;
            retWork.AddiCarSpec6 = carModelRet.AddiCarSpec6;
            retWork.AddiCarSpecTitle1 = carModelRet.AddiCarSpecTitle1;
            retWork.AddiCarSpecTitle2 = carModelRet.AddiCarSpecTitle2;
            retWork.AddiCarSpecTitle3 = carModelRet.AddiCarSpecTitle3;
            retWork.AddiCarSpecTitle4 = carModelRet.AddiCarSpecTitle4;
            retWork.AddiCarSpecTitle5 = carModelRet.AddiCarSpecTitle5;
            retWork.AddiCarSpecTitle6 = carModelRet.AddiCarSpecTitle6;
            retWork.RelevanceModel = carModelRet.RelevanceModel;
            retWork.SubCarNmCd = carModelRet.SubCarNmCd;
            retWork.ModelGradeSname = carModelRet.ModelGradeSname;
            retWork.BlockIllustrationCd = carModelRet.BlockIllustrationCd;
            retWork.ThreeDIllustNo = carModelRet.ThreeDIllustNo;
            retWork.PartsDataOfferFlag = carModelRet.PartsDataOfferFlag;

            retWork.FreeSrchMdlFxdNo = carModelRet.FreeSrchMdlFxdNo;

            if ( retWork.StProduceTypeOfYear < 101 ) retWork.StProduceTypeOfYear = 101; // 0001�N01��
            if ( retWork.EdProduceTypeOfYear < 101 ) retWork.EdProduceTypeOfYear = 101; // 0001�N01��

            return retWork;
        }
        # endregion

        # region [���o���ʃ��X�g����]
        /// <summary>
        /// �Ԏ탊�X�g�Ɂu�d�����Ȃ��ꍇ�̂݁v�ǉ�����
        /// </summary>
        /// <param name="kindList"></param>
        /// <param name="carKindInfo"></param>
        private void AddKindListDistinct( ref ArrayList kindList, FreeSearchModelSCarKindInfoWork carKindInfo )
        {
            // �d���`�F�b�N
            foreach ( CarKindInfoWork kind in kindList )
            {
                if ( kind.MakerCode == carKindInfo.MakerCode &&
                     kind.ModelCode == carKindInfo.ModelCode &&
                     kind.ModelSubCode == carKindInfo.ModelSubCode )
                {
                    // ���X�g���Ɋ��ɑ��݂���Ԏ�
                    return;
                }
            }

            // ���X�g�ɒǉ�
            kindList.Add( CopyToCarKindInfoFromFSCarKindInfo( carKindInfo ) );
        }
        # endregion

        # endregion
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<


        /// <summary>
        /// �J���[�E�g�����ݒ菈��
        /// </summary>
        /// <param name="colorCdRetWork">�J���[</param>
        /// <param name="trimCdRetWork">�g����</param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="_carSearchInfo"></param>
        private void ColorTrimSet(ArrayList colorCdRetWork, ArrayList trimCdRetWork, ArrayList cEqpDefDspRetWork, PMKEN01010E _carSearchInfo)
        {
            # region �J���[���
            // �J���[���f�[�^�[�Z�b�g
            if (colorCdRetWork != null)
            {
                foreach (Broadleaf.Application.Remoting.ParamData.ColorCdRetWork wkSource in colorCdRetWork)
                {
                    PMKEN01010E.ColorCdInfoRow colorCdRow = _carSearchInfo.ColorCdInfo.NewColorCdInfoRow();
                    colorCdRow.MakerCode = wkSource.MakerCode;
                    colorCdRow.ModelCode = wkSource.ModelCode;
                    colorCdRow.ModelSubCode = wkSource.ModelSubCode;
                    //colorCdRow.SystematicCode = wkSource.SystematicCode;
                    //colorCdRow.ProduceTypeOfYearCd = wkSource.ProduceTypeOfYearCd;
                    colorCdRow.ColorCode = wkSource.ColorCode;
                    colorCdRow.ColorName1 = wkSource.ColorName1;
                    //colorCdRow.ColorCdDupDerivedNo = wkSource.ColorCdDupDerivedNo; // �s�v�̉\���́H
                    _carSearchInfo.ColorCdInfo.AddColorCdInfoRow(colorCdRow);
                }
            }
            # endregion

            # region �g�������
            // �g�������f�[�^�[�Z�b�g
            if (trimCdRetWork != null)
            {
                foreach (Broadleaf.Application.Remoting.ParamData.TrimCdRetWork wkSource in trimCdRetWork)
                {
                    PMKEN01010E.TrimCdInfoRow trimCdRow = _carSearchInfo.TrimCdInfo.NewTrimCdInfoRow();
                    trimCdRow.MakerCode = wkSource.MakerCode;
                    trimCdRow.ModelCode = wkSource.ModelCode;
                    trimCdRow.ModelSubCode = wkSource.ModelSubCode;
                    //trimCdRow.SystematicCode = wkSource.SystematicCode;
                    //trimCdRow.ProduceTypeOfYearCd = wkSource.ProduceTypeOfYearCd;
                    trimCdRow.TrimCode = wkSource.TrimCode;
                    trimCdRow.TrimName = wkSource.TrimName;

                    _carSearchInfo.TrimCdInfo.AddTrimCdInfoRow(trimCdRow);
                }
            }
            # endregion

            # region �������
            // �������f�[�^�[�Z�b�g
            if (cEqpDefDspRetWork != null)
            {
                foreach (CEqpDefDspRetWork wkSource in cEqpDefDspRetWork)
                {
                    PMKEN01010E.CEqpDefDspInfoRow cEqpRow = _carSearchInfo.CEqpDefDspInfo.NewCEqpDefDspInfoRow();
                    cEqpRow.MakerCode = wkSource.MakerCode;
                    cEqpRow.ModelCode = wkSource.ModelCode;
                    cEqpRow.ModelSubCode = wkSource.ModelSubCode;
                    cEqpRow.SystematicCode = wkSource.SystematicCode;
                    cEqpRow.EquipmentCode = wkSource.EquipmentCode;
                    cEqpRow.EquipmentName = wkSource.EquipmentName;
                    cEqpRow.EquipmentShortName = wkSource.EquipmentShortName;
                    cEqpRow.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                    cEqpRow.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                    cEqpRow.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                    cEqpRow.EquipmentIconCode = wkSource.EquipmentIconCode;

                    _carSearchInfo.CEqpDefDspInfo.AddCEqpDefDspInfoRow(cEqpRow);
                }
            }
            # endregion
        }

        /// <summary>
        /// �I��UI�őI�����ꂽ�^�����̈��k����
        /// </summary>
        /// <param name="_carSearchInfo"></param>
        private void SetSummarizedData(PMKEN01010E _carSearchInfo)
        {
            bool flgExhaustGasSign = true;
            bool flgSeriesModel = true;
            PMKEN01010E.CarModelInfoRow[] rowCarModelInfos = _carSearchInfo.CarModelInfo.Select("SelectionState = True") as PMKEN01010E.CarModelInfoRow[];

            // --- ADD m.suzuki 2010/04/19 ---------->>>>>
            if ( rowCarModelInfos.Length == 0 ) return;
            // --- ADD m.suzuki 2010/04/19 ----------<<<<<

            PMKEN01010E.CarModelInfoRow rowCarInfoSum = _carSearchInfo.CarModelInfoSummarized.AddCarModelInfoRowCopy(rowCarModelInfos[0]);
            for (int i = 1; i < rowCarModelInfos.Length; i++)
            {
                PMKEN01010E.CarModelInfoRow rowToComp = rowCarModelInfos[i];
                if (rowCarInfoSum.ProduceTypeOfYearCd != rowToComp.ProduceTypeOfYearCd)
                    rowCarInfoSum.ProduceTypeOfYearCd = 0;
                if (rowCarInfoSum.StProduceTypeOfYear > rowToComp.StProduceTypeOfYear)    // �J�n���Y�N��
                    rowCarInfoSum.StProduceTypeOfYear = rowToComp.StProduceTypeOfYear;
                if (rowCarInfoSum.EdProduceTypeOfYear < rowToComp.EdProduceTypeOfYear)    // �I�����Y�N��
                    rowCarInfoSum.EdProduceTypeOfYear = rowToComp.EdProduceTypeOfYear;
                if (rowCarInfoSum.StProduceFrameNo > rowToComp.StProduceFrameNo)          // �J�n�ԑ�ԍ�
                    rowCarInfoSum.StProduceFrameNo = rowToComp.StProduceFrameNo;
                if (rowCarInfoSum.EdProduceFrameNo < rowToComp.EdProduceFrameNo)          // �I���ԑ�ԍ�
                    rowCarInfoSum.EdProduceFrameNo = rowToComp.EdProduceFrameNo;
                if (rowCarInfoSum.ModelGradeNm != rowToComp.ModelGradeNm)                 // �^���O���[�h����
                    rowCarInfoSum.ModelGradeNm = string.Empty;
                if (rowCarInfoSum.BodyName != rowToComp.BodyName)                         // �{�f�B�[����
                    rowCarInfoSum.BodyName = string.Empty;
                if (rowCarInfoSum.DoorCount != rowToComp.DoorCount)                       // �h�A��
                    rowCarInfoSum.DoorCount = 0;
                if (rowCarInfoSum.EngineModelNm != rowToComp.EngineModelNm)               // �G���W���^������
                    rowCarInfoSum.EngineModelNm = string.Empty;
                if (rowCarInfoSum.EngineDisplaceNm != rowToComp.EngineDisplaceNm)         // �r�C�ʖ���
                    rowCarInfoSum.EngineDisplaceNm = string.Empty;
                if (rowCarInfoSum.EDivNm != rowToComp.EDivNm)                             // E�敪����
                    rowCarInfoSum.EDivNm = string.Empty;
                if (rowCarInfoSum.TransmissionNm != rowToComp.TransmissionNm)             // �~�b�V��������
                    rowCarInfoSum.TransmissionNm = string.Empty;
                if (rowCarInfoSum.WheelDriveMethodNm != rowToComp.WheelDriveMethodNm)     // �쓮��������
                    rowCarInfoSum.WheelDriveMethodNm = string.Empty;
                if (rowCarInfoSum.ShiftNm != rowToComp.ShiftNm)                           // �V�t�g����
                    rowCarInfoSum.ShiftNm = string.Empty;
                // 2010/01/04 Add >>>
                if (rowCarInfoSum.FrameModel != rowToComp.FrameModel)                     // �ԑ�^��
                    rowCarInfoSum.FrameModel = string.Empty;
                // 2010/01/04 Add <<<
                if (rowCarInfoSum.SystematicCode != rowToComp.SystematicCode)
                    rowCarInfoSum.SystematicCode = 0;
                if (rowCarInfoSum.FullModel != rowToComp.FullModel)                       // �^��
                {   // �^�����Ⴄ���A�V���[�Y���f���̋��ʕ���\�����邽�߁A�ȉ��̏������s���B
                    rowCarInfoSum.FullModel = string.Empty;

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //int j;
                    //string compFullModel = _carSearchInfo.CarModelUIData[0].FullModel;
                    //for (j = rowCarInfoSum.SeriesModel.Length; j > 0; j--)
                    //{
                    //    if (rowToComp.SeriesModel.Contains(rowCarInfoSum.SeriesModel.Substring(0, j)))
                    //    {
                    //        rowCarInfoSum.SeriesModel = rowCarInfoSum.SeriesModel.Substring(0, j);
                    //        if (j < rowToComp.SeriesModel.Length)
                    //            flgSeriesModel = false; // �V���[�Y�^���̑��Ⴀ��
                    //        break;
                    //    }
                    //}
                    //if (j == 0)
                    //    rowCarInfoSum.SeriesModel = string.Empty;

                    // �V���[�Y�^���A�^��(�ޕʋL��)�́A�������P������Ƃ��Ĉ��k����
                    int j;
                    string compFullModel = _carSearchInfo.CarModelUIData[0].FullModel;
                    for (j = rowCarInfoSum.SeriesModel.Length; j > 0; j--)
                    {
                        if (rowToComp.SeriesModel.Contains(rowCarInfoSum.SeriesModel.Substring(0, j)))
                        {
                            rowCarInfoSum.SeriesModel = rowCarInfoSum.SeriesModel.Substring(0, j);
                            if (j < rowToComp.SeriesModel.Length) flgSeriesModel = false; // �V���[�Y�^���̑��Ⴀ��
                            break;
                        }
                    }

                    string dummyComp = rowToComp.SeriesModel + '-' + rowToComp.CategorySignModel;
                    string dummySum = rowCarInfoSum.SeriesModel + '-' + rowCarInfoSum.CategorySignModel;

                    for (j = dummySum.Length; j > 0; j--)
                    {
                        if (dummyComp.Contains(dummySum.Substring(0, j)))
                        {
                            dummySum = dummySum.Substring(0, j);
                            break;
                        }
                    }
                    if (dummySum.Contains("-"))
                    {
                        string[] temp = dummySum.Split('-');
                        rowCarInfoSum.SeriesModel = temp[0];
                        rowCarInfoSum.CategorySignModel = temp[1];
                    }
                    else
                    {
                        rowCarInfoSum.SeriesModel = dummySum;
                        rowCarInfoSum.CategorySignModel = string.Empty;
                    }
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //for (j = rowCarInfoSum.ExhaustGasSign.Length; j > 0; j--)
                    //{
                    //    if (rowToComp.ExhaustGasSign.Contains(rowCarInfoSum.ExhaustGasSign.Substring(0, j)))
                    //    {
                    //        rowCarInfoSum.ExhaustGasSign = rowCarInfoSum.ExhaustGasSign.Substring(0, j);
                    //        if (j < rowToComp.ExhaustGasSign.Length)
                    //            flgExhaustGasSign = false; // �r�K�X�L���̑��Ⴀ��
                    //        break;
                    //    }
                    //}
                    //if (j == 0)
                    //    rowCarInfoSum.ExhaustGasSign = string.Empty;

                    // �r�K�X�L���͊��S��v�őΏۂƂ���
                    if (rowCarInfoSum.ExhaustGasSign == rowToComp.ExhaustGasSign)
                    {
                        rowCarInfoSum.ExhaustGasSign = rowCarInfoSum.ExhaustGasSign;
                    }
                    else
                    {
                        flgExhaustGasSign = false; // �r�K�X�L���̑��Ⴀ��
                        rowCarInfoSum.ExhaustGasSign = string.Empty;
                    }
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //for (j = rowCarInfoSum.CategorySignModel.Length; j > 0; j--)
                    //{
                    //    if (rowToComp.CategorySignModel.Contains(rowCarInfoSum.CategorySignModel.Substring(0, j)))
                    //    {
                    //        rowCarInfoSum.CategorySignModel = rowCarInfoSum.CategorySignModel.Substring(0, j);
                    //        break;
                    //    }
                    //}
                    //if (j == 0)
                    //    rowCarInfoSum.CategorySignModel = string.Empty;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            string fullModel = string.Empty;
            if (rowCarInfoSum.FullModel == string.Empty) // �t���^���̈��k�������K�v
            {
                if (flgSeriesModel)
                {
                    if ((flgExhaustGasSign && rowCarInfoSum.ExhaustGasSign != string.Empty)
                        || rowCarInfoSum.ExhaustGasSign != string.Empty)
                    {
                        fullModel = string.Format("{0}-{1}", rowCarInfoSum.ExhaustGasSign, rowCarInfoSum.SeriesModel);
                    }
                    else
                    {
                        fullModel = rowCarInfoSum.SeriesModel;
                    }
                    if (rowCarInfoSum.CategorySignModel != string.Empty)
                    {
                        fullModel += "-" + rowCarInfoSum.CategorySignModel;
                    }
                }
                else if (flgExhaustGasSign && rowCarInfoSum.ExhaustGasSign != string.Empty)
                {
                    fullModel = rowCarInfoSum.ExhaustGasSign;
                    if (rowCarInfoSum.SeriesModel != string.Empty)
                    {
                        fullModel += "-" + rowCarInfoSum.SeriesModel;
                    }
                }
                else
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 DEL
                    //if ( rowCarInfoSum.ExhaustGasSign != string.Empty )
                    //{
                    //    fullModel = rowCarInfoSum.ExhaustGasSign;
                    //}
                    //else if ( rowCarInfoSum.SeriesModel != string.Empty )
                    //{
                    //    fullModel = rowCarInfoSum.SeriesModel;
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/23 ADD
                    if ( rowCarInfoSum.SeriesModel != string.Empty )
                    {
                        fullModel = rowCarInfoSum.SeriesModel;
                    }
                    else if ( rowCarInfoSum.ExhaustGasSign != string.Empty )
                    {
                        fullModel = rowCarInfoSum.ExhaustGasSign;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/23 ADD
                }
                //if (_carSearchInfo.CarModelUIData[0].FullModel.Contains(rowCarInfoSum.SeriesModel) ||
                //    rowCarInfoSum.SeriesModel.Contains(_carSearchInfo.CarModelUIData[0].FullModel))
                //{
                //    if (_carSearchInfo.CarModelUIData[0].FullModel.Contains(rowCarInfoSum.ExhaustGasSign)
                //        && _carSearchInfo.CarModelUIData[0].FullModel.Contains("-"))
                //    {
                //        fullModel = string.Format("{0}-{1}-{2}", rowCarInfoSum.ExhaustGasSign, rowCarInfoSum.SeriesModel, rowCarInfoSum.CategorySignModel);
                //    }
                //    else
                //    {
                //        fullModel = rowCarInfoSum.SeriesModel;
                //        if (flgSeriesModel) // SeriesModel�����S��v����ꍇ
                //        {
                //            if (flgExhaustGasSign && rowCarInfoSum.ExhaustGasSign != string.Empty)
                //            {
                //                fullModel = string.Format("{0}-{1}", rowCarInfoSum.ExhaustGasSign, fullModel);
                //            }
                //            if (rowCarInfoSum.CategorySignModel != string.Empty) // �^���i�ޕʋL���j�̋��ʕ���ǉ�
                //            {
                //                fullModel = string.Format("{0}-{1}", fullModel, rowCarInfoSum.CategorySignModel);
                //            }
                //        }
                //    }
                //}
                //else if (_carSearchInfo.CarModelUIData[0].FullModel.Contains(rowCarInfoSum.ExhaustGasSign))
                //{
                //    fullModel = rowCarInfoSum.ExhaustGasSign;
                //}
                //else
                //{
                //    if (rowCarInfoSum.ExhaustGasSign != string.Empty)
                //    {
                //        fullModel = rowCarInfoSum.ExhaustGasSign + "-";
                //    }
                //    if (rowCarInfoSum.SeriesModel != string.Empty)
                //    {
                //        fullModel += rowCarInfoSum.SeriesModel + "-";
                //    }
                //    if (rowCarInfoSum.CategorySignModel != string.Empty)
                //    {
                //        fullModel += rowCarInfoSum.CategorySignModel;
                //    }
                //}
                if (fullModel.EndsWith("-"))
                {
                    fullModel = fullModel.Remove(fullModel.Length - 1);
                }

                rowCarInfoSum.FullModel = fullModel;
            }
        }

        private CarSearchResultReport ColorTrimSearch()
        {
            return ColorTrimSearch(null);
        }

        private CarSearchResultReport ColorTrimSearch(PMKEN01010E _carSearchInfo)
        {
            // -- ADD 2010/05/25 --------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return CarSearchResultReport.retFailed;
            }
            // -- ADD 2010/05/25 ---------------------------<<<

            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            PMKEN01010E carInfo = null;
            if (_carSearchInfo == null)
                carInfo = dataSet;
            else
                carInfo = _carSearchInfo;

            //���ʃN���X
            ArrayList colorCdRetWork = null;
            ArrayList trimCdRetWork = null;
            ArrayList cEqpDefDspRetWork = null;
            ArrayList categoryEquipmentRetWork = null;

            carInfo.CarModelInfo.AcceptChanges();
            PMKEN01010E.CarModelInfoRow[] rowCarModelInfos = carInfo.CarModelInfo.Select("SelectionState = True") as PMKEN01010E.CarModelInfoRow[];
            if (rowCarModelInfos.Length == 1)
            {
                ret = CarSearchResultReport.retSingleCarModel;
            }
            else // �����̌^����I�񂾏ꍇ�A�v����𒊏o����B
            {
                ret = CarSearchResultReport.retMultipleCarModel;
            }
            SetSummarizedData(carInfo);
            PMKEN01010E.CarModelInfoRow rowCarInfoSum = carInfo.CarModelInfoSummarized[0];

            List<int> lstSystematicCd = new List<int>();
            List<int> lstProduceYearCd = new List<int>();
            List<int> lstFullModelFixedNo = new List<int>();

            for (int i = 0; i < rowCarModelInfos.Length; i++)
            {
                PMKEN01010E.CarModelInfoRow rowToComp = rowCarModelInfos[i];
                if (lstSystematicCd.Contains(rowToComp.SystematicCode) == false)
                {
                    lstSystematicCd.Add(rowToComp.SystematicCode);
                }
                if (lstProduceYearCd.Contains(rowToComp.ProduceTypeOfYearCd) == false)
                {
                    lstProduceYearCd.Add(rowToComp.ProduceTypeOfYearCd);
                }
                if (lstFullModelFixedNo.Contains(rowToComp.FullModelFixedNo) == false)
                {
                    lstFullModelFixedNo.Add(rowToComp.FullModelFixedNo);
                }
            }

            //�����̐ݒ�
            ColTrmEquSearchCondWork colTrmEquSearchCondWork = new ColTrmEquSearchCondWork();
            colTrmEquSearchCondWork.MakerCode = rowCarInfoSum.MakerCode;
            colTrmEquSearchCondWork.ModelCode = rowCarInfoSum.ModelCode;
            if (rowCarInfoSum.ModelSubCode != -1)
            {
                colTrmEquSearchCondWork.ModelSubCode = rowCarInfoSum.ModelSubCode;
            }
            if (lstProduceYearCd.Count > 0)
            {
                colTrmEquSearchCondWork.ProduceTypeOfYearCd = lstProduceYearCd.ToArray();
            }
            if (lstSystematicCd.Count > 0)
            {
                colTrmEquSearchCondWork.SystematicCode = lstSystematicCd.ToArray();
            }
            if (lstFullModelFixedNo.Count > 0)
            {
                colTrmEquSearchCondWork.FullModelFixedNo = lstFullModelFixedNo.ToArray();
            }

            //�߂�l�̏�����
            object objcolorCdRetWork = null;
            object objtrimCdRetWork = null;
            object objcEqpDefDspRetWork = null;
            object objPrdTypRetWork = null;
            object objcolTrmEquSearchCondWork = colTrmEquSearchCondWork as object;

            // �N����񏈗�
            if (carInfo.PrdTypYearInfo.Count == 0)
            {
                PrdTypYearCondWork condWork = new PrdTypYearCondWork();
                _IPrdTypYearDB = MediationPrdTypYearDB.GetRemoteObject();
                condWork.MakerCode = rowCarInfoSum.MakerCode;
                condWork.FrameModel = rowCarInfoSum.FrameModel;
                condWork.StProduceTypeOfYear = rowCarInfoSum.StProduceTypeOfYear;
                condWork.EdProduceTypeOfYear = rowCarInfoSum.EdProduceTypeOfYear;
                _IPrdTypYearDB.SearchPrdTypYearInf(out objPrdTypRetWork, condWork);
                ArrayList prdTypRetWork = objPrdTypRetWork as ArrayList;
                if (prdTypRetWork != null)
                {
                    foreach (PrdTypYearRetWork wkPrdTypYear in prdTypRetWork)
                    {
                        PMKEN01010E.PrdTypYearInfoRow prdTypRow = carInfo.PrdTypYearInfo.NewPrdTypYearInfoRow();
                        prdTypRow.MakerCode = wkPrdTypYear.MakerCode;
                        prdTypRow.FrameModel = wkPrdTypYear.FrameModel;
                        prdTypRow.ProduceTypeOfYear = wkPrdTypYear.ProduceTypeOfYear;
                        prdTypRow.StProduceFrameNo = wkPrdTypYear.StProduceFrameNo;
                        prdTypRow.EdProduceFrameNo = wkPrdTypYear.EdProduceFrameNo;
                        carInfo.PrdTypYearInfo.AddPrdTypYearInfoRow(prdTypRow);
                    }
                }
            }

            //�����[�g�����̌Ăяo��
            _IColTrmEquInfDB = MediationColTrmEquInfDB.GetRemoteObject();
            _IColTrmEquInfDB.SearchColTrmEquInf(out objcolorCdRetWork, out objtrimCdRetWork, out objcEqpDefDspRetWork, ref objcolTrmEquSearchCondWork);

            colorCdRetWork = objcolorCdRetWork as ArrayList;
            trimCdRetWork = objtrimCdRetWork as ArrayList;
            cEqpDefDspRetWork = objcEqpDefDspRetWork as ArrayList;

            if (carInfo.CategoryEquipmentInfo.Count == 0 &&
                carInfo.CarModelUIData[0].ModelDesignationNo != 0 && carInfo.CarModelUIData[0].CategoryNo != 0)
            {
                ICategoryEquipmentDB _ICategoryEquipmentDB = MediationCategoryEquipmentDB.GetRemoteObject();
                object objCategoryEquipment = null;
                _ICategoryEquipmentDB.SearchCategoryEquipment(out objCategoryEquipment, carInfo.CarModelUIData[0].ModelDesignationNo, carInfo.CarModelUIData[0].CategoryNo);
                categoryEquipmentRetWork = objCategoryEquipment as ArrayList;

                # region �^���ޕʏ��[CategoryEquipmentRetWork]
                // �^���ޕʏ��f�[�^�[�Z�b�g
                if (categoryEquipmentRetWork != null)
                {
                    foreach (CategoryEquipmentRetWork wkSource in categoryEquipmentRetWork)
                    {
                        PMKEN01010E.CategoryEquipmentInfoRow categoryRow = carInfo.CategoryEquipmentInfo.NewCategoryEquipmentInfoRow();

                        categoryRow.EquipmentGenreCd = wkSource.EquipmentGenreCd;
                        categoryRow.EquipmentGenreNm = wkSource.EquipmentGenreNm;
                        categoryRow.EquipmentMngCode = wkSource.EquipmentMngCode;
                        categoryRow.EquipmentMngName = wkSource.EquipmentMngName;
                        categoryRow.EquipmentCode = wkSource.EquipmentCode;
                        categoryRow.EquipmentDispOrder = wkSource.EquipmentDispOrder;
                        categoryRow.TbsPartsCode = wkSource.TbsPartsCode;
                        categoryRow.EquipmentName = wkSource.EquipmentName;
                        categoryRow.EquipmentShortName = wkSource.EquipmentShortName;
                        categoryRow.EquipmentIconCode = wkSource.EquipmentIconCode;
                        categoryRow.EquipmentUnitCode = wkSource.EquipmentUnitCode;
                        categoryRow.EquipmentUnitName = wkSource.EquipmentUnitName;
                        categoryRow.EquipmentCnt = wkSource.EquipmentCnt;
                        categoryRow.EquipmentComment1 = wkSource.EquipmentComment1;
                        categoryRow.EquipmentComment2 = wkSource.EquipmentComment2;

                        carInfo.CategoryEquipmentInfo.AddCategoryEquipmentInfoRow(categoryRow);
                    }
                }
                # endregion
            }
            //carInfo.CarModelInfo = (PMKEN01010E.CarModelInfoDataTable)carInfo.CarModelInfo.Copy();

            //�߂�l�̐ݒ�
            ColorTrimSet(colorCdRetWork, trimCdRetWork, cEqpDefDspRetWork, carInfo);

            return ret;
        }

        private CarSearchResultReport CarModelInfoSet(ArrayList carModelRetList)
        {
            return CarModelInfoSet(carModelRetList, null);
        }

        private CarSearchResultReport CarModelInfoSet(ArrayList carModelRetList, PMKEN01010E _carInfo)
        {
            PMKEN01010E carInfo = null;
            if (_carInfo != null) // �t���^���Œ�ԍ��ɂ�錟���͓���DataSet�łȂ��A������DataSet�ŏ������s���B
                carInfo = _carInfo;
            else
                carInfo = dataSet;

            CarSearchResultReport ret = CarSearchResultReport.retMultipleCarModel;
            foreach (CarModelRetWork wkCarModel in carModelRetList)
            {
                PMKEN01010E.CarModelInfoRow rowCarModelInfo = carInfo.CarModelInfo.NewCarModelInfoRow();
                rowCarModelInfo.MakerCode = wkCarModel.MakerCode;
                rowCarModelInfo.MakerFullName = wkCarModel.MakerFullName;
                rowCarModelInfo.MakerHalfName = wkCarModel.MakerHalfName;
                rowCarModelInfo.ModelCode = wkCarModel.ModelCode;
                rowCarModelInfo.ModelSubCode = wkCarModel.ModelSubCode;
                rowCarModelInfo.ModelFullName = wkCarModel.ModelFullName;
                rowCarModelInfo.ModelHalfName = wkCarModel.ModelHalfName;
                rowCarModelInfo.SystematicCode = wkCarModel.SystematicCode;
                rowCarModelInfo.SystematicName = wkCarModel.SystematicName;
                rowCarModelInfo.ProduceTypeOfYearCd = wkCarModel.ProduceTypeOfYearCd;
                rowCarModelInfo.ProduceTypeOfYearNm = wkCarModel.ProduceTypeOfYearNm;
                rowCarModelInfo.StProduceTypeOfYear = wkCarModel.StProduceTypeOfYear;
                rowCarModelInfo.EdProduceTypeOfYear = wkCarModel.EdProduceTypeOfYear;
                rowCarModelInfo.DoorCount = wkCarModel.DoorCount;
                rowCarModelInfo.BodyNameCode = wkCarModel.BodyNameCode;
                rowCarModelInfo.BodyName = wkCarModel.BodyName;
                rowCarModelInfo.CarProperNo = wkCarModel.CarProperNo;
                rowCarModelInfo.FullModelFixedNo = wkCarModel.FullModelFixedNo;
                rowCarModelInfo.ExhaustGasSign = wkCarModel.ExhaustGasSign;
                rowCarModelInfo.SeriesModel = wkCarModel.SeriesModel;
                rowCarModelInfo.CategorySignModel = wkCarModel.CategorySignModel;
                rowCarModelInfo.FullModel = wkCarModel.FullModel;
                rowCarModelInfo.FrameModel = wkCarModel.FrameModel;
                rowCarModelInfo.StProduceFrameNo = wkCarModel.StProduceFrameNo;
                rowCarModelInfo.EdProduceFrameNo = wkCarModel.EdProduceFrameNo;
                rowCarModelInfo.ModelGradeNm = wkCarModel.ModelGradeNm;
                rowCarModelInfo.EngineModelNm = wkCarModel.EngineModelNm;
                rowCarModelInfo.EngineDisplaceNm = wkCarModel.EngineDisplaceNm;
                rowCarModelInfo.EDivNm = wkCarModel.EDivNm;
                rowCarModelInfo.TransmissionNm = wkCarModel.TransmissionNm;
                rowCarModelInfo.WheelDriveMethodNm = wkCarModel.WheelDriveMethodNm;
                rowCarModelInfo.ShiftNm = wkCarModel.ShiftNm;
                rowCarModelInfo.AddiCarSpec1 = wkCarModel.AddiCarSpec1;
                rowCarModelInfo.AddiCarSpec2 = wkCarModel.AddiCarSpec2;
                rowCarModelInfo.AddiCarSpec3 = wkCarModel.AddiCarSpec3;
                rowCarModelInfo.AddiCarSpec4 = wkCarModel.AddiCarSpec4;
                rowCarModelInfo.AddiCarSpec5 = wkCarModel.AddiCarSpec5;
                rowCarModelInfo.AddiCarSpec6 = wkCarModel.AddiCarSpec6;
                rowCarModelInfo.AddiCarSpecTitle1 = wkCarModel.AddiCarSpecTitle1;
                rowCarModelInfo.AddiCarSpecTitle2 = wkCarModel.AddiCarSpecTitle2;
                rowCarModelInfo.AddiCarSpecTitle3 = wkCarModel.AddiCarSpecTitle3;
                rowCarModelInfo.AddiCarSpecTitle4 = wkCarModel.AddiCarSpecTitle4;
                rowCarModelInfo.AddiCarSpecTitle5 = wkCarModel.AddiCarSpecTitle5;
                rowCarModelInfo.AddiCarSpecTitle6 = wkCarModel.AddiCarSpecTitle6;
                rowCarModelInfo.RelevanceModel = wkCarModel.RelevanceModel;
                rowCarModelInfo.SubCarNmCd = wkCarModel.SubCarNmCd;
                rowCarModelInfo.ModelGradeSname = wkCarModel.ModelGradeSname;
                rowCarModelInfo.BlockIllustrationCd = wkCarModel.BlockIllustrationCd;
                rowCarModelInfo.ThreeDIllustNo = wkCarModel.ThreeDIllustNo;
                rowCarModelInfo.PartsDataOfferFlag = wkCarModel.PartsDataOfferFlag;
                rowCarModelInfo.SelectionState = false;
                // --- ADD m.suzuki 2010/04/19 ---------->>>>>
                if ( wkCarModel is CarModelRetWorkEx )
                {
                    rowCarModelInfo.FreeSrchMdlFxdNo = (wkCarModel as CarModelRetWorkEx).FreeSrchMdlFxdNo;
                    rowCarModelInfo.FreeSearchSortDiv = 0; // 0:���R����
                }
                else
                {
                    rowCarModelInfo.FreeSrchMdlFxdNo = string.Empty;
                    rowCarModelInfo.FreeSearchSortDiv = 1; // 1:���R�����ȊO
                }
                // --- ADD m.suzuki 2010/04/19 ----------<<<<<

                rowCarModelInfo.GradeFullName = wkCarModel.GradeFullName; // 2012/05/28

                // --- ADD 2013/03/21 ---------->>>>>
                //���Y/�O�ԋ敪
                rowCarModelInfo.DomesticForeignCode = wkCarModel.DomesticForeignCode;
                //���Y/�O�ԋ敪����
                rowCarModelInfo.DomesticForeignName = wkCarModel.DomesticForeignName;
                //�n���h���ʒu
                rowCarModelInfo.HandleInfoCd = wkCarModel.HandleInfoCd;
                //�n���h���ʒu����
                rowCarModelInfo.HandleInfoNm = wkCarModel.HandleInfoNm;
                // --- ADD 2013/03/21 ----------<<<<<

                // �ԗ��ŗL�ԍ�������āA�t���^���Œ�ԍ�������^���Ɋւ��Ă͈��k�������s��
                string select = string.Format("FullModelFixedNo = {0}", rowCarModelInfo.FullModelFixedNo);

                // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                //// 2009/10/27 Add >>>
                //// �t���^���Œ�ԍ� = 0�̃f�[�^�́A�t���^���A�ԑ�ԍ����g�p���Č���
                //if (rowCarModelInfo.FullModelFixedNo == 0) select += string.Format(" AND {0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}", 
                //    carInfo.CarModelInfo.FullModelColumn.ColumnName, 
                //    rowCarModelInfo.FullModel,
                //    carInfo.CarModelInfo.ModelGradeNmColumn,
                //    rowCarModelInfo.ModelGradeNm,
                //    carInfo.CarModelInfo.StProduceFrameNoColumn.ColumnName, 
                //    rowCarModelInfo.StProduceFrameNo,
                //    carInfo.CarModelInfo.EdProduceFrameNoColumn.ColumnName, 
                //    rowCarModelInfo.EdProduceFrameNo
                //    );
                //// 2009/10/27 Add <<<
                // �t���^���Œ�ԍ� = 0�̃f�[�^�́A�t���^���A�O���[�h�A�ԑ�ԍ��i�J�n�^�I���j�A���R�����^���Œ�ԍ����g�p���Č���
                if ( rowCarModelInfo.FullModelFixedNo == 0 )
                {
                    select += string.Format( " AND {0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7} AND {8} = '{9}'",
                      carInfo.CarModelInfo.FullModelColumn.ColumnName,
                      rowCarModelInfo.FullModel,
                      carInfo.CarModelInfo.ModelGradeNmColumn,
                      rowCarModelInfo.ModelGradeNm,
                      carInfo.CarModelInfo.StProduceFrameNoColumn.ColumnName,
                      rowCarModelInfo.StProduceFrameNo,
                      carInfo.CarModelInfo.EdProduceFrameNoColumn.ColumnName,
                      rowCarModelInfo.EdProduceFrameNo,
                      carInfo.CarModelInfo.FreeSrchMdlFxdNoColumn.ColumnName,
                      rowCarModelInfo.FreeSrchMdlFxdNo
                      );
                }
                // --- UPD m.suzuki 2010/04/19 ----------<<<<<

                if (carInfo.CarModelInfo.Select(select).Length == 0)
                {
                    carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                }
                else
                {
                    // 2009/10/27 Add >>>
                    if (rowCarModelInfo.FullModelFixedNo == 0)
                    {
                        PMKEN01010E.CarModelInfoRow[] rows = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                        bool exists = false;
                        foreach (PMKEN01010E.CarModelInfoRow row in rows)
                        {
                            if ((row.ModelGradeNm == rowCarModelInfo.ModelGradeNm) &&               // �^���O���[�h����
                                ( row.BodyName == rowCarModelInfo.BodyName ) &&                     // �{�f�B�[����
                                ( row.DoorCount == rowCarModelInfo.DoorCount ) &&                   // �h�A��
                                ( row.EngineModelNm == rowCarModelInfo.EngineModelNm ) &&           // �G���W���^������
                                ( row.EngineDisplaceNm == rowCarModelInfo.EngineDisplaceNm ) &&     // �r�C�ʖ���
                                ( row.EDivNm == rowCarModelInfo.EDivNm ) &&                         // E�敪����
                                ( row.TransmissionNm == rowCarModelInfo.TransmissionNm ) &&         // �~�b�V��������
                                ( row.ShiftNm == rowCarModelInfo.ShiftNm ) &&                       // �V�t�g����
                                ( row.WheelDriveMethodNm == rowCarModelInfo.WheelDriveMethodNm ) && // �쓮��������
                                ( row.AddiCarSpec1 == rowCarModelInfo.AddiCarSpec1 ) &&             // �ǉ�����1
                                ( row.AddiCarSpec2 == rowCarModelInfo.AddiCarSpec2 ) &&             // �ǉ�����2
                                ( row.AddiCarSpec3 == rowCarModelInfo.AddiCarSpec3 ) &&             // �ǉ�����3
                                ( row.AddiCarSpec4 == rowCarModelInfo.AddiCarSpec4 ) &&             // �ǉ�����4
                                ( row.AddiCarSpec5 == rowCarModelInfo.AddiCarSpec5 ) &&             // �ǉ�����5
                                ( row.AddiCarSpec6 == rowCarModelInfo.AddiCarSpec6 )                // �ǉ�����6
                               )
                            {
                                // �N�����S��v�i�f�[�^�d���j
                                if (row.StProduceTypeOfYear == rowCarModelInfo.StProduceTypeOfYear &&
                                    row.EdProduceTypeOfYear == rowCarModelInfo.EdProduceTypeOfYear)
                                {
                                    exists = true;
                                    break;
                                }

                                // �����f�[�^�̔N���͈͂��A�Ώۃf�[�^�̔N���͈͓�
                                if (row.StProduceTypeOfYear <= rowCarModelInfo.StProduceTypeOfYear &&
                                    row.EdProduceTypeOfYear >= rowCarModelInfo.EdProduceTypeOfYear)
                                {
                                    exists = true;
                                    break;
                                }

                                // �Ώۃf�[�^�̔N���͈͂��A�����f�[�^�̔N���͈͓�
                                if (rowCarModelInfo.StProduceTypeOfYear <= row.StProduceTypeOfYear &&
                                    rowCarModelInfo.EdProduceTypeOfYear >= row.EdProduceTypeOfYear)
                                {
                                    // �Ώۃf�[�^�̕����N���͈̔͂��L���̂ōX�V
                                    row.StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                                    row.EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                                    exists = true;
                                    break;
                                }

                                // �����f�[�^�̊J�n�N�� < �Ώۃf�[�^�̊J�n�N��
                                if (row.StProduceTypeOfYear < rowCarModelInfo.StProduceTypeOfYear)
                                {
                                    // �N�����A����
                                    if (row.EdProduceTypeOfYear == rowCarModelInfo.StProduceTypeOfYear)
                                    {
                                        row.EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                                        exists = true;
                                    }
                                    // �����f�[�^�̏I���N�� < �Ώۃf�[�^�̊J�n�N���́A�f��㕜�����ꂽ���f��
                                    else if (row.EdProduceTypeOfYear < rowCarModelInfo.StProduceTypeOfYear)
                                    {
                                        // �ʓr�o�^����B
                                        carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                                        exists = true;
                                    }
                                }
                                // �����f�[�^�̏I���N�� > �Ώۃf�[�^�̏I���N��
                                else if (row.EdProduceTypeOfYear > rowCarModelInfo.EdProduceTypeOfYear)
                                {
                                    // �N�����A����
                                    if (row.StProduceTypeOfYear == rowCarModelInfo.EdProduceTypeOfYear)
                                    {
                                        row.StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                                        exists = true;
                                    }
                                    // �����f�[�^�̊J�n�N�� > �Ώۃf�[�^�̏I���N���́A�f��㕜�����ꂽ���f��
                                    else if (row.StProduceTypeOfYear > rowCarModelInfo.EdProduceTypeOfYear)
                                    {
                                        // �ʓr�o�^����B
                                        carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                                        exists = true;
                                    }
                                }
                                break;
                            }
                        }
                        if (!exists) carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo);
                    }
                    else
                    {
                    // 2009/10/27 Add <<<
                        select = string.Format("FullModelFixedNo = {0} AND StProduceTypeOfYear = {1} AND EdProduceTypeOfYear = {2}",
                            rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.StProduceTypeOfYear, rowCarModelInfo.EdProduceTypeOfYear);
                        if (carInfo.CarModelInfo.Select(select).Length == 0) // �N�������S��v����^�����Ȃ��ꍇ
                        {
                            select = string.Format("FullModelFixedNo = {0} AND StProduceTypeOfYear < {1}",
                                rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.StProduceTypeOfYear);
                            PMKEN01010E.CarModelInfoRow[] rowst = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                            if (rowst.Length != 0) // �ߋ��̔N���̃f�[�^���e�[�u���Ɋ��ɑ��݂��邩�H
                            {   // �f��㕜����1�񂾂��Ɖ��肷��B### 2��ȏ�f��A�����̃��f���Ή����܂���B###
                                if (rowst[0].EdProduceTypeOfYear == rowCarModelInfo.StProduceTypeOfYear) // �N�����A����
                                {
                                    rowst[0].EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                                }
                                else if (rowst[0].EdProduceTypeOfYear < rowCarModelInfo.StProduceTypeOfYear)
                                {
                                    carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo); // 1��f��㕜�����ꂽ���f���̂��߁A�ʓr�o�^����B
                                }
                            }
                            else
                            {
                                select = string.Format("FullModelFixedNo = {0} AND EdProduceTypeOfYear > {1}",
                                    rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.EdProduceTypeOfYear);
                                PMKEN01010E.CarModelInfoRow[] rowed = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                                if (rowed.Length != 0)
                                {
                                    if (rowed[0].StProduceTypeOfYear == rowCarModelInfo.EdProduceTypeOfYear) // �N�����A����
                                    {
                                        rowed[0].StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                                    }
                                    else if (rowed[0].StProduceTypeOfYear > rowCarModelInfo.EdProduceTypeOfYear)
                                    {
                                        carInfo.CarModelInfo.AddCarModelInfoRow(rowCarModelInfo); // 1��f��㕜�����ꂽ���f���̂��߁A�ʓr�o�^����B
                                    }
                                }
                            }

                            //>>>2010/03/29
                            // �N���͈͊J�n���Â��ꍇ�A�Â��N���ōX�V
                            select = string.Format("FullModelFixedNo = {0} AND StProduceTypeOfYear > {1}",
                                rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.StProduceTypeOfYear);
                            rowst = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                            if (rowst.Length != 0)
                            {
                                rowst[0].StProduceTypeOfYear = rowCarModelInfo.StProduceTypeOfYear;
                            }

                            // �N���͈͏I�����V�����ꍇ�A�V�����N���ōX�V
                            select = string.Format("FullModelFixedNo = {0} AND EdProduceTypeOfYear < {1}",
                                rowCarModelInfo.FullModelFixedNo, rowCarModelInfo.EdProduceTypeOfYear);
                            rowst = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(select);
                            if (rowst.Length != 0)
                            {
                                rowst[0].EdProduceTypeOfYear = rowCarModelInfo.EdProduceTypeOfYear;
                            }
                            //<<<2010/03/29
                        }
                    }   // 2009/10/27 Add
                }
            }
            // 2009/10/27 Add >>>
            // �t���^���Œ�ԍ����O�f�[�^�̍Ĉ��k
            this.CompressFullModelFixedNoZero(carInfo);
            // 2009/10/27 Add <<<
            if (carInfo.CarModelInfo.Rows.Count == 1)
            {
                carInfo.CarModelInfo[0].SelectionState = true;
                ret = CarSearchResultReport.retSingleCarModel;
            }

            return ret;
        }
        #endregion

        #region [ �������UI�f�[�^�擾 ]
#if EQUIPINFO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public Dictionary<string, ValueList> GetEquipUIInfo()
        {
            PMKEN01010E.CEqpDefDspInfoDataTable eqpInfoTable = dat.CEqpDefDspInfo;
            PMKEN01010E.CategoryEquipmentInfoDataTable ctgEquipInfoTable = dat.CategoryEquipmentInfo;
            DataTable retTable = new DataTable();
            Dictionary<string, ValueList> lst = new Dictionary<string, ValueList>();
            List<string> equipGenreLst = new List<string>();
            ValueList vList;

            for (int i = 0; i < dat.CEqpDefDspInfo.Count; i++)
            {
                if (lst.ContainsKey(eqpInfoTable[i].EquipmentGenreNm))
                {
                    vList = lst[eqpInfoTable[i].EquipmentGenreNm];
                    ValueListItem item = new ValueListItem(eqpInfoTable[i].EquipmentName);
                    item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[eqpInfoTable[i].EquipmentIconCode];
                    vList.ValueListItems.Add(item);
                }
                else
                {
                    vList = new ValueList();
                    vList.DisplayStyle = ValueListDisplayStyle.DataValueAndPicture;
                    vList.Key = eqpInfoTable[i].EquipmentGenreNm;
                    ValueListItem item = new ValueListItem(eqpInfoTable[i].EquipmentName);

                    item.Appearance.Image = EquipmentIconResourceManagement.Equipment_ImageList16.Images[eqpInfoTable[i].EquipmentIconCode];
                    vList.ValueListItems.Add(item);
                    lst.Add(vList.Key, vList);
                }
            }

            return lst;
        }
#endif
        #endregion

        #region [ �t���^���Œ�ԍ��z��擾 ]
        /// <summary>
        /// �ԗ��Ǘ��}�X�^�ɃZ�b�g����t���^���Œ�ԍ��z����쐬���܂��B
        /// </summary>
        /// <param name="carModelDat"></param>
        /// <returns></returns>
        public int[] GetFullModelFixedNoArray(PMKEN01010E.CarModelInfoDataTable carModelDat)
        {
            string query = string.Format("{0}=True", carModelDat.SelectionStateColumn.ColumnName);
            PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])carModelDat.Select(query);

            // --- UPD m.suzuki 2010/04/19 ---------->>>>>
            //int rowCount = row.Length;
            //int[] lst = new int[rowCount];
            //for (int i = 0; i < rowCount; i++)
            //{
            //    lst[i] = row[i].FullModelFixedNo;
            //}
            //return lst;

            int rowCount = row.Length;
            List<int> lst = new List<int>();
            for ( int i = 0; i < rowCount; i++ )
            {
                // ���R������������
                if ( row[i].FreeSrchMdlFxdNo.Trim() != string.Empty )
                {
                    continue;
                }
                lst.Add( row[i].FullModelFixedNo );
            }
            return lst.ToArray();
            // --- UPD m.suzuki 2010/04/19 ----------<<<<<
        }
        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>
        /// �ԗ��Ǘ��}�X�^�ɃZ�b�g����t���^���Œ�ԍ��z����쐬���܂��B
        /// </summary>
        /// <param name="carModelDat"></param>
        /// <param name="fullModelFixedNoArray"></param>
        /// <param name="freeSrchMdlFxdNoArray"></param>
        /// <returns></returns>
        public void GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo( PMKEN01010E.CarModelInfoDataTable carModelDat, out int[] fullModelFixedNoArray, out string[] freeSrchMdlFxdNoArray )
        {
            string query = string.Format( "{0}=True", carModelDat.SelectionStateColumn.ColumnName );
            PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])carModelDat.Select( query );

            int rowCount = row.Length;
            List<int> lst = new List<int>();
            List<string> fslst = new List<string>();

            for ( int i = 0; i < rowCount; i++ )
            {
                if ( row[i].FreeSrchMdlFxdNo.Trim() == string.Empty )
                {
                    // �񋟃f�[�^��
                    lst.Add( row[i].FullModelFixedNo );
                }
                else
                {
                    // ���R������
                    fslst.Add( row[i].FreeSrchMdlFxdNo );
                }
            }
            fullModelFixedNoArray = lst.ToArray();
            freeSrchMdlFxdNoArray = fslst.ToArray();
        }
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
        #endregion


        // 2009/10/27 Add >>>
        /// <summary>
        /// �t���^���Œ�ԍ����[���̃f�[�^�����k���܂��B
        /// </summary>
        /// <param name="carInfo">���q���e�[�u��</param>
        /// <returns>True:���k����</returns>
        public bool CompressFullModelFixedNoZero(PMKEN01010E carInfo )
        {
            bool compress = false;

            // ���k�Ώۂ������Ȃ�܂Ń��[�v������
            while (true)
            {
                compress = false;

                string selectStr = string.Format("{0} = 0 AND {1} > 0", carInfo.CarModelInfo.FullModelFixedNoColumn, carInfo.CarModelInfo.StProduceFrameNoColumn);
                
                PMKEN01010E.CarModelInfoRow[] baseRows = (PMKEN01010E.CarModelInfoRow[])carInfo.CarModelInfo.Select(selectStr);
                if (baseRows != null && baseRows.Length > 1)
                {
                    compress = false;
                    for (int ix = 0; ix < baseRows.Length; ix++)
                    {
                        PMKEN01010E.CarModelInfoRow row = baseRows[ix];

                        for (int iy = ix + 1; iy < baseRows.Length; iy++)
                        {
                            PMKEN01010E.CarModelInfoRow checkRow = baseRows[iy];

                            // --- UPD m.suzuki 2010/04/19 ---------->>>>>
                            //if (( row.FullModel == checkRow.FullModel ) &&                    // �t���^��
                            //    ( row.ModelGradeNm == checkRow.ModelGradeNm ) &&              // �^���O���[�h����
                            //    ( row.BodyName == checkRow.BodyName ) &&                      // �{�f�B�[����
                            //    ( row.DoorCount == checkRow.DoorCount ) &&                    // �h�A��
                            //    ( row.EngineModelNm == checkRow.EngineModelNm ) &&            // �G���W���^������
                            //    ( row.EngineDisplaceNm == checkRow.EngineDisplaceNm ) &&      // �r�C�ʖ���
                            //    ( row.EDivNm == checkRow.EDivNm ) &&                          // E�敪����
                            //    ( row.TransmissionNm == checkRow.TransmissionNm ) &&          // �~�b�V��������
                            //    ( row.ShiftNm == checkRow.ShiftNm ) &&                        // �V�t�g����
                            //    ( row.WheelDriveMethodNm == checkRow.WheelDriveMethodNm ) &&  // �쓮��������
                            //    ( row.AddiCarSpec1 == checkRow.AddiCarSpec1 ) &&              // �ǉ�����1
                            //    ( row.AddiCarSpec2 == checkRow.AddiCarSpec2 ) &&              // �ǉ�����2
                            //    ( row.AddiCarSpec3 == checkRow.AddiCarSpec3 ) &&              // �ǉ�����3
                            //    ( row.AddiCarSpec4 == checkRow.AddiCarSpec4 ) &&              // �ǉ�����4
                            //    ( row.AddiCarSpec5 == checkRow.AddiCarSpec5 ) &&              // �ǉ�����5
                            //    ( row.AddiCarSpec6 == checkRow.AddiCarSpec6 )                 // �ǉ�����6
                            //   )
                            if ( (row.FullModel == checkRow.FullModel) &&                    // �t���^��
                                (row.ModelGradeNm == checkRow.ModelGradeNm) &&              // �^���O���[�h����
                                (row.BodyName == checkRow.BodyName) &&                      // �{�f�B�[����
                                (row.DoorCount == checkRow.DoorCount) &&                    // �h�A��
                                (row.EngineModelNm == checkRow.EngineModelNm) &&            // �G���W���^������
                                (row.EngineDisplaceNm == checkRow.EngineDisplaceNm) &&      // �r�C�ʖ���
                                (row.EDivNm == checkRow.EDivNm) &&                          // E�敪����
                                (row.TransmissionNm == checkRow.TransmissionNm) &&          // �~�b�V��������
                                (row.ShiftNm == checkRow.ShiftNm) &&                        // �V�t�g����
                                (row.WheelDriveMethodNm == checkRow.WheelDriveMethodNm) &&  // �쓮��������
                                (row.AddiCarSpec1 == checkRow.AddiCarSpec1) &&              // �ǉ�����1
                                (row.AddiCarSpec2 == checkRow.AddiCarSpec2) &&              // �ǉ�����2
                                (row.AddiCarSpec3 == checkRow.AddiCarSpec3) &&              // �ǉ�����3
                                (row.AddiCarSpec4 == checkRow.AddiCarSpec4) &&              // �ǉ�����4
                                (row.AddiCarSpec5 == checkRow.AddiCarSpec5) &&              // �ǉ�����5
                                (row.AddiCarSpec6 == checkRow.AddiCarSpec6) &&              // �ǉ�����6
                                (row.FreeSrchMdlFxdNo == checkRow.FreeSrchMdlFxdNo)         // ���R�����^���Œ�ԍ�
                               )
                            // --- UPD m.suzuki 2010/04/19 ----------<<<<<
                            {
                                // �`�F�b�N���Ă���s�̎ԑ�ԍ��͈̔͂��A��ƂȂ�s�̎ԑ�ԍ��͈͓̔�
                                if (row.StProduceFrameNo <= checkRow.StProduceFrameNo &&
                                    row.EdProduceFrameNo >= checkRow.EdProduceFrameNo
                                   )
                                {
                                    // �N�����͈͓����q����ꍇ
                                    if ((row.StProduceTypeOfYear <= checkRow.StProduceTypeOfYear &&
                                         row.EdProduceTypeOfYear >= checkRow.EdProduceTypeOfYear ) || 
                                        (row.EdProduceTypeOfYear == checkRow.StProduceTypeOfYear)
                                       )
                                    {
                                        row.EdProduceTypeOfYear = checkRow.EdProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }

                                // ��ƂȂ�s�̎ԑ�ԍ��͈̔͂��A�`�F�b�N���Ă���s�̎ԑ�ԍ��͈͓̔�
                                if (checkRow.StProduceFrameNo <= row.StProduceFrameNo &&
                                    checkRow.EdProduceFrameNo >= row.EdProduceFrameNo
                                   )
                                {
                                    // �N�����͈͓����q����ꍇ
                                    if ((checkRow.StProduceTypeOfYear <= row.StProduceTypeOfYear &&
                                         checkRow.EdProduceTypeOfYear >= row.EdProduceTypeOfYear ) || 
                                        (checkRow.EdProduceTypeOfYear == row.StProduceTypeOfYear)
                                       )
                                    {
                                        row.StProduceTypeOfYear = checkRow.StProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }

                                // ��ƂȂ�s�ƁA�`�F�b�N���Ă���s�̎ԑ�ԍ����q����
                                if (row.EdProduceFrameNo + 1 == checkRow.StProduceFrameNo)
                                {
                                    // �N�����q����
                                    if (row.EdProduceTypeOfYear == checkRow.StProduceTypeOfYear)
                                    {
                                        row.EdProduceFrameNo = checkRow.EdProduceFrameNo;
                                        row.EdProduceTypeOfYear = checkRow.EdProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }
                                // �`�F�b�N���Ă���s�ƁA��ƂȂ�s�̎ԑ�ԍ����q����
                                if (checkRow.EdProduceFrameNo + 1 == row.StProduceFrameNo)
                                {
                                    // �N�����q����
                                    if (checkRow.EdProduceTypeOfYear == row.StProduceTypeOfYear)
                                    {
                                        row.StProduceFrameNo = checkRow.StProduceFrameNo;
                                        row.StProduceTypeOfYear = checkRow.StProduceTypeOfYear;
                                        carInfo.CarModelInfo.RemoveCarModelInfoRow(checkRow);
                                        compress = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (compress) break;
                    }
                }

                if (!compress) break;
            }
            return compress;
        }
        // 2009/10/27 Add <<<

        // --- ADD 2013/03/21 ---------->>>>>
        /// <summary>
        /// VIN�R�[�h�����񂩂�n���h���ʒu�����擾���܂��B
        /// </summary>
        /// <param name="VinCode">VIN�R�[�h������</param>
        /// <returns>�n���h���ʒu���(HandleInfoCdRet)</returns>
        public HandleInfoCdRet GetHandlePositionFromVinCode(string VinCode)
        {
            HandleInfoCdRet retValue = HandleInfoCdRet.PositionError;
            
            System.Text.Encoding Sjis_enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            
            string HandlePosiStr = string.Empty;
            int HandlePosiNum = -1;

            if (string.IsNullOrEmpty(VinCode))
            {
                // ��������
                return retValue;
            }
            else if (VinCode.Length != 17 ||
                     Sjis_enc.GetByteCount(VinCode) != 17)
            {
                // ��������17Byte�łȂ��B�܂��͑S�p�������܂܂�Ă���B
                return retValue;
            }

            // 10Byte�ڂ̕������1Byte�擾(VIN�R�[�h�̃t�H�[�}�b�g���)
            HandlePosiStr = VinCode.Substring(9, 1);

            if (!int.TryParse(HandlePosiStr, out HandlePosiNum))
            {
                // �n���h���ʒu��񂪔񐔒l
                return retValue;
            }
            else
            {
                if (HandlePosiNum == 2)
                {
                    // �E�n���h��
                    retValue = HandleInfoCdRet.PositionRight;
                }
                else if (HandlePosiNum == 1)
                {
                    // ���n���h��
                    retValue = HandleInfoCdRet.PositionLeft;
                }
                else
                {
                    // ���^��
                    retValue = HandleInfoCdRet.PositionBoth;
                }
            }

            return retValue;
        }
        // --- ADD 2013/03/21 ----------<<<<<

        // --- ADD m.suzuki 2010/04/19 ---------->>>>>
        /// <summary>
        /// ���q���f�[�^�N���X(�{���R�������)
        /// </summary>
        /// <remarks>CarModelRetWork�̃��X�g�Ɋi�[�\�Ȏ��R�����^�����p�̃N���X���`���܂��B</remarks>
        internal class CarModelRetWorkEx : CarModelRetWork
        {
            /// <summary>���R�����^���Œ�ԍ�</summary>
            private string _freeSrchMdlFxdNo;

            /// <summary>
            /// ���R�����^���Œ�ԍ�
            /// </summary>
            public string FreeSrchMdlFxdNo
            {
                get { return _freeSrchMdlFxdNo; }
                set { _freeSrchMdlFxdNo = value; }
            }
        }
        // --- ADD m.suzuki 2010/04/19 ----------<<<<<
    }
}
