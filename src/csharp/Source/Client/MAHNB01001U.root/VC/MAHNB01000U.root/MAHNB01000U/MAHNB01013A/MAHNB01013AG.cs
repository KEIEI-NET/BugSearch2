using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Update Note : 2010/05/30 20056 ���n ��� </br>
    /// <br>              ���ʕ�����(�U�����ǁ{�V�����ǁ{���R�����{SCM)</br>
    /// <br>Update Note : 2010/06/26 ����� </br>
    /// <br>              BL�R�[�h�ϊ������̃��W�b�N�̍폜</br>
    /// <br>Update Note : 2010/07/29 20056 ���n ��� </br>
    /// <br>              �\���敪�}�X�^������^�C�~���O�Ɏ擾�ł��Ȃ����̑Ή�(�����擾�}�X�^�ŏI���Ƀ��X�g��null�̏ꍇ�A�Ď擾����)</br>
    /// <br>Update Note : 2011/09/27 20056 ���n ���</br>
    /// <br>              �݌ɐ��\���敪���Q�Ƃ��A���݌ɐ��̕\��������s��</br>
    /// <br>Update Note : 2012/02/07  2012/03/28�z�M���@#28284 liusy</br>
    /// <br>              �N�����̃}�X�^�擾�������ɓ��Ӑ�|���O���[�v�̎擾������ǉ�����</br>
    /// <br>Update Note: 2012/11/13 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��1668</br>
    /// <br>             ����ߋ����t������ʃI�v�V�������i�C�X�R�܂��̓I�v�V��������œ��t����j</br>
    /// <br>Update Note: 2012/12/21 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             �R�`���i�I�v�V�����Ή�</br>
    /// <br>Update Note: K2013/09/20 �{�{ ����</br>
    /// <br>             ���t�^�o�I�v�V�����Ή��i�ʁj</br>
    /// <br>Update Note: 2013/05/09 �� �B</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 �d�|�ꗗ��935(#30784) </br>
    /// <br>             ����S�̐ݒ�̂a�k�R�[�h�}�ԋ敪���u�}�Ԃ���v�Őݒ肷�鎞�A��ʋN�������A�a�k�R�[�h�����ł��Ȃ�</br>
    /// <br>Update Note: K2014/01/22 杍^</br>
    /// <br>�Ǘ��ԍ�   : 10970602-00</br>
    /// <br>             �o�ˌʓ��̋敪�̕ύX�Ή�</br>
    /// <br>Update Note: K2014/02/17 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10970602-00</br>
    /// <br>             �t�r�a�o�ˌʃI�v�V�����n�m �`�m�c ���̊Ǘ��}�X�^�̌�</br>
    /// <br>             �A�Z���u����������ɑ��݂���ꍇ �˃I�v�V�����n�m�̑Ή�</br>
    /// <br>Update Note: K2015/04/01 ���t </br>
    /// <br>�Ǘ��ԍ�   : 11100713-00</br>
    /// <br>           : �X�암�i�ʈ˗��̉��Ǎ�ƑS���_�݌ɏ��ꗗ�@�\�ǉ�</br>
    /// <br>Update Note: K2015/04/29 �����M</br>
    /// <br>�Ǘ��ԍ�   : 11100543-00 �x�m�W�[���C������ UOE�捞�Ή�</br>
    /// <br>Update Note: K2015/06/18 �I��</br>
    /// <br>�Ǘ��ԍ�   : 11101427-00 �����C�S�@WebUOE�����񓚎捞�Ή�</br>
    /// <br>Update Note: K2016/11/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11202099-00 ����`�[���͂���O��PG���N�����Ĕ��P�����Z�o�̑Ή�</br>
    /// <br>             ���R�[�G�C�I�v�V�����i�ʁj</br>
    /// <br>Update Note: K2016/12/14  ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11202330-00</br>
    /// <br>           : �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�</br>
    /// <br>Update Note: K2016/12/26 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11270116-00 ����`�[���̓p�b�P�[�W�o�חp�\�[�X�̃}�[�W</br>
    /// <br>             �����c���i�I�v�V�����i�ʁj</br>
    /// <br>Update Note: K2016/12/30 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11202452-00</br>
    /// <br>             ���쏤�H�l�ʕύX���e��PM.NS�ɂĎ������邽�߁A��񔄉��̑Ή��s���܂��B</br>
    /// <br>Update Note: 2020/11/20 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSP�C�����C���@�\�ǉ��Ή�</br>
    /// <br>Update Note: 2022/01/05 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11800082-00</br>
    /// <br>           : PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ�</br> 
    /// </remarks>
    public class DelphiGetSalesSlipInputInitDataAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiGetSalesSlipInputInitDataAcs()
        {
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            this._delphiSalesSlipInputInitDataAcs = DelphiSalesSlipInputInitDataAcs.GetInstance();
            this._delphiSalesSlipInputInitDataSecondAcs = DelphiSalesSlipInputInitDataSecondAcs.GetInstance();
            this._delphiSalesSlipInputInitDataThirdAcs = DelphiSalesSlipInputInitDataThirdAcs.GetInstance();
            this._delphiSalesSlipInputInitDataFourthAcs = DelphiSalesSlipInputInitDataFourthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataFifthAcs = DelphiSalesSlipInputInitDataFifthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataSixthAcs = DelphiSalesSlipInputInitDataSixthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataSeventhAcs = DelphiSalesSlipInputInitDataSeventhAcs.GetInstance();
            this._delphiSalesSlipInputInitDataEighthAcs = DelphiSalesSlipInputInitDataEighthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataNinthAcs = DelphiSalesSlipInputInitDataNinthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataTenthAcs = DelphiSalesSlipInputInitDataTenthAcs.GetInstance();
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiGetSalesSlipInputInitDataAcs GetInstance()
        {
            if (_delphiGetSalesSlipInputInitDataAcs == null)
            {
                _delphiGetSalesSlipInputInitDataAcs = new DelphiGetSalesSlipInputInitDataAcs();
            }
            return _delphiGetSalesSlipInputInitDataAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private static DelphiGetSalesSlipInputInitDataAcs _delphiGetSalesSlipInputInitDataAcs;
        private DelphiSalesSlipInputInitDataAcs _delphiSalesSlipInputInitDataAcs;
        private DelphiSalesSlipInputInitDataSecondAcs _delphiSalesSlipInputInitDataSecondAcs;
        private DelphiSalesSlipInputInitDataThirdAcs _delphiSalesSlipInputInitDataThirdAcs;
        private DelphiSalesSlipInputInitDataFourthAcs _delphiSalesSlipInputInitDataFourthAcs;
        private DelphiSalesSlipInputInitDataFifthAcs _delphiSalesSlipInputInitDataFifthAcs;
        private DelphiSalesSlipInputInitDataSixthAcs _delphiSalesSlipInputInitDataSixthAcs;
        private DelphiSalesSlipInputInitDataSeventhAcs _delphiSalesSlipInputInitDataSeventhAcs;
        private DelphiSalesSlipInputInitDataEighthAcs _delphiSalesSlipInputInitDataEighthAcs;
        private DelphiSalesSlipInputInitDataNinthAcs _delphiSalesSlipInputInitDataNinthAcs;
        private DelphiSalesSlipInputInitDataTenthAcs _delphiSalesSlipInputInitDataTenthAcs;

        #endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        public void GetInitData()
        {
            //// ��Ԃ̃X���[�g
            this._salesSlipInputInitDataAcs.SetMakerUMntList(_delphiSalesSlipInputInitDataAcs.GetMakerUMntList());
            this._salesSlipInputInitDataAcs.SetBlGoodsCdUMntList(_delphiSalesSlipInputInitDataAcs.GetBlGoodsCdUMntList());
            this._salesSlipInputInitDataAcs.SetGoodsAcs(_delphiSalesSlipInputInitDataAcs.GetGoodsAcs());
            this._salesSlipInputInitDataAcs.SetDisplayDivList(_delphiSalesSlipInputInitDataAcs.GetDisplayDivList()); // 2010/07/29
            this._salesSlipInputInitDataAcs.SetAllCustRateGroupList(_delphiSalesSlipInputInitDataAcs.GetCustRateGroupList()); //add by liusy 2012/02/07 #28284
            //2013/05/09 T.Nishi
            this._salesSlipInputInitDataAcs.SetTbsPartsCodeList(_delphiSalesSlipInputInitDataAcs.GetTbsPartsCodeList()); 
            //2013/05/09 T.Nishi
            // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� --->>>>>
            //�d����}�X�^
            this._salesSlipInputInitDataAcs.SetSupplierList(_delphiSalesSlipInputInitDataSecondAcs.GetSupplierList());
            // --- ADD 2022/01/05 ���O PMKOBETSU-4148 ���[�J�[���Ǝd���於�`�F�b�N�ǉ� ---<<<<<
 
            //// ��Ԃ̃X���[�g
            this._salesSlipInputInitDataAcs.SetUoeSetting(_delphiSalesSlipInputInitDataSecondAcs.GetUoeSetting());
            this._salesSlipInputInitDataAcs.SetTaxRateSet(_delphiSalesSlipInputInitDataSecondAcs.GetTaxRateSet(), _delphiSalesSlipInputInitDataEighthAcs.GetTaxRate());
            this._salesSlipInputInitDataAcs.SetPosTerminalMg(_delphiSalesSlipInputInitDataSecondAcs.GetPosTerminalMg());
            this._salesSlipInputInitDataAcs.SetEmployeeInfo(_delphiSalesSlipInputInitDataSecondAcs.GetEmployeeList(), _delphiSalesSlipInputInitDataSecondAcs.GetEmployeeDtlList());
            // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
            ////>>>2010/05/30
            ////this._salesSlipInputInitDataAcs.SetOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptCarMng(),
            ////    _delphiSalesSlipInputInitDataSecondAcs.GetOptFreeSearch(), _delphiSalesSlipInputInitDataSecondAcs.GetOptPCC(),
            ////    _delphiSalesSlipInputInitDataSecondAcs.GetOpt_RCLink(), _delphiSalesSlipInputInitDataSecondAcs.GetOptUOE(),
            ////    _delphiSalesSlipInputInitDataSecondAcs.GetOptStockingPayment());
            //this._salesSlipInputInitDataAcs.SetOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptCarMng(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptFreeSearch(), _delphiSalesSlipInputInitDataSecondAcs.GetOptPCC(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOpt_RCLink(), _delphiSalesSlipInputInitDataSecondAcs.GetOptUOE(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptStockingPayment(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptSCM(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptQRMail());
            ////<<<2010/05/30
            this._salesSlipInputInitDataAcs.SetOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptCarMng(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptFreeSearch(), _delphiSalesSlipInputInitDataSecondAcs.GetOptPCC(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOpt_RCLink(), _delphiSalesSlipInputInitDataSecondAcs.GetOptUOE(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptPermitForKoei(), // ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C
                _delphiSalesSlipInputInitDataSecondAcs.GetOptFukudaCustom(), // ADD 杍^ K2016/12/26 �����c���i
                _delphiSalesSlipInputInitDataSecondAcs.GetOptStockingPayment(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptSCM(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptQRMail(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptDateCtrl(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptNoBuTo(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptForFuJi(),// ADD K2015/04/29 �����M �x�m�W�[���C������
                _delphiSalesSlipInputInitDataSecondAcs.GetOptForMeiGo(),// ADD K2015/06/18 �I�� �����C�S WebUOE�����񓚎捞
                _delphiSalesSlipInputInitDataSecondAcs.GetOptForMizuno2ndSellPriceCtl(),   // ADD K2016/12/30 杍^ ���쏤�H��
                // ---ADD ���N�n�� K2014/02/17--------------->>>>>
                _delphiSalesSlipInputInitDataSecondAcs.MyMethodNobuto,
                //�@_delphiSalesSlipInputInitDataSecondAcs.ObjNobuto�@// DEL K2015/04/01 ���t �X�암�i�ʈ˗�
                // ---ADD ���N�n�� K2014/02/17---------------<<<<<
                _delphiSalesSlipInputInitDataSecondAcs.GetOptYamagataCustom(),  //  ADD ���V�� K2016/12/14 �R�`���i�l �`�[�C���ł̎d����A�̔��敪�A������ύX���ɉ��i�E������ύX���Ȃ��Ή�
                // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ---------->>>>>
                _delphiSalesSlipInputInitDataSecondAcs.ObjNobuto,
                // ---UPD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------>>>>
                _delphiSalesSlipInputInitDataSecondAcs.GetOptMoriKawa(),
                // --- UPD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�--->>>>>
                //_delphiSalesSlipInputInitDataSecondAcs.GetOptTSP()
                _delphiSalesSlipInputInitDataSecondAcs.GetOptTSP(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptEBooks()
                // --- UPD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�---<<<<<
                // ---UPD ���O 2020/11/20 PMKOBETSU-4097�̑Ή� ------<<<<
                // --- ADD K2015/04/01 ���t �X�암�i�ʈ˗� ----------<<<<<
                ); // ADD 杍^ K2014/01/22
            // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
            this._salesSlipInputInitDataAcs.SetYamagataOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptStockEntCtrl()
                                                             , _delphiSalesSlipInputInitDataSecondAcs.GetOptStockDateCtrl()
                                                             , _delphiSalesSlipInputInitDataSecondAcs.GetOptSalesCostCtrl()
                                                              );
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            this._salesSlipInputInitDataAcs.SetFutabaOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaSlipPrtCtl()
                                                            , _delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaWarehAlloc()
                                                            , _delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaUOECtl()
                                                            , _delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaOutSlipCtl()
                                                            );

            this._salesSlipInputInitDataAcs.Opt_BLPRefWarehouse = _delphiSalesSlipInputInitDataThirdAcs.Opt_BLPRefWarehouse();
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            //>>>2010/05/30
            //this._salesSlipInputInitDataAcs.SetTbsPartsCdChgWorkList(_delphiSalesSlipInputInitDataSecondAcs.GetTbsPartsCdChgWorkList()); // 2010/06/26
            //<<<2010/05/30

            //// �O�Ԃ̃X���[�g
            this._salesSlipInputInitDataAcs.SetAcptAnOdrTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetAcptAnOdrTtlSt());
            this._salesSlipInputInitDataAcs.SetSalesTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetSalesTtlSt());
            this._salesSlipInputInitDataAcs.SetEstimateDefSet(_delphiSalesSlipInputInitDataThirdAcs.GetEstimateDefSet());
            this._salesSlipInputInitDataAcs.SetStockTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetStockTtlSt());
            this._salesSlipInputInitDataAcs.SetAllDefSet(_delphiSalesSlipInputInitDataThirdAcs.GetAllDefSet());
            this._salesSlipInputInitDataAcs.SetInputMode(_delphiSalesSlipInputInitDataThirdAcs.GetAllDefSet().GoodsNoInpDiv);
            this._salesSlipInputInitDataAcs.SetCompanyInf(_delphiSalesSlipInputInitDataThirdAcs.GetCompanyInf());
            this._salesSlipInputInitDataAcs.SetSlipPrtSetList(_delphiSalesSlipInputInitDataThirdAcs.GetSlipPrtSetList());
            this._salesSlipInputInitDataAcs.SetCustSlipMngList(_delphiSalesSlipInputInitDataThirdAcs.GetCustSlipMngList());
            this._salesSlipInputInitDataAcs.SetUoeGuideNameList(_delphiSalesSlipInputInitDataThirdAcs.GetUoeGuideNameList());
            this._salesSlipInputInitDataAcs.SetSubSectionList(_delphiSalesSlipInputInitDataThirdAcs.GetSubSectionList());
            this._salesSlipInputInitDataAcs.SetRateProtyMngList(_delphiSalesSlipInputInitDataThirdAcs.GetRateProtyMngList());
            this._salesSlipInputInitDataAcs.SetSalesProcMoneyList(_delphiSalesSlipInputInitDataThirdAcs.GetSalesProcMoneyList());
            this._salesSlipInputInitDataAcs.SetStockProcMoneyList(_delphiSalesSlipInputInitDataThirdAcs.GetStockProcMoneyList());
            this._salesSlipInputInitDataAcs.SetUserGdBdList(_delphiSalesSlipInputInitDataThirdAcs.GetUserGdBdList());
            this._salesSlipInputInitDataAcs.Opt_CarMng = _delphiSalesSlipInputInitDataThirdAcs.OptCarMng();
            this._salesSlipInputInitDataAcs.Opt_StockingPayment = _delphiSalesSlipInputInitDataThirdAcs.OptStockingPayment();
            //>>>2010/05/30
            this._salesSlipInputInitDataAcs.SetSCMTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetScmTtlSt());
            this._salesSlipInputInitDataAcs.SetSCMDeliDateStList(_delphiSalesSlipInputInitDataThirdAcs.GetScmDeliDateStList());
            //this._salesSlipInputInitDataAcs.SetTbsPartsCdChgWorkList(_delphiSalesSlipInputInitDataThirdAcs.GetTbsPartsCdChgWorkList()); // DEL 2010/06/26
            //<<<2010/05/30
            this._salesSlipInputInitDataAcs.SetStockMngTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetStockMngTtlSt()); // 2011/09/27
            
            
            //if (_delphiSalesSlipInputInitDataSecondAcs.GetTaxRateSet() == null)
            //{
            //    MessageBox.Show("ERR");
            //}
            //else
            //{
            //    MessageBox.Show(_delphiSalesSlipInputInitDataThirdAcs.GetUserGdBdList().Count.ToString());
            //}



            //this._salesSlipInputInitDataAcs.SetUserGuideAcs(_delphiSalesSlipInputInitDataThirdAcs.GetUserGuideAcs());
            //// �l�Ԃ̃X���[�g
            //this._salesSlipInputInitDataAcs.SetWarehouseList(_delphiSalesSlipInputInitDataFourthAcs.GetWarehouseList());
            //// �ܔԂ̃X���[�g
            //// �Z�Ԃ̃X���[�g
            //this._salesSlipInputInitDataAcs.SetDisplayDivList(_delphiSalesSlipInputInitDataSixthAcs.GetDisplayDivList());
            //this._salesSlipInputInitDataAcs.SetNoteGuidList(_delphiSalesSlipInputInitDataSixthAcs.GetNoteGuidList());
            //// ���Ԃ̃X���[�g
            //this._salesSlipInputInitDataAcs.Opt_CarMng = _delphiSalesSlipInputInitDataSeventhAcs.GetOpt_CarMng();

            //this._salesSlipInputInitDataAcs.SetAllCustRateGroupList(_delphiSalesSlipInputInitDataAcs.GetAllCustRateGroupList());

            //// ���Ԃ̃X���[�g

            //// ��Ԃ̃X���[�g

            //// �\�Ԃ̃X���[�g

        }
        #endregion

    }
}
