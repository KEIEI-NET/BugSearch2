// ����� ���C�� DLL �t�@�C���ł��B

#include "stdafx.h"

#include "MAHNB01019C.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Collections;
using namespace System::Collections::Generic;

using namespace Broadleaf::Library::Resources;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::Controller;

//�������A�N�Z�X�N���X���b�p�[

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitData(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputInitDataAcs^ delphiSalesSlipInputInitDataAcs = DelphiSalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataAcs->ReadInitData(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataSecond(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataSecondAcs^ delphiSalesSlipInputInitDataSecondAcs = DelphiSalesSlipInputInitDataSecondAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataSecondAcs->ReadInitDataSecond(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataThird(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputInitDataThirdAcs^ delphiSalesSlipInputInitDataThirdAcs = DelphiSalesSlipInputInitDataThirdAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataThirdAcs->ReadInitDataThird(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataFourth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataFourthAcs^ delphiSalesSlipInputInitDataFourthAcs = DelphiSalesSlipInputInitDataFourthAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataFourthAcs->ReadInitDataFourth(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataFifth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataFifthAcs^ delphiSalesSlipInputInitDataFifthAcs = DelphiSalesSlipInputInitDataFifthAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataFifthAcs->ReadInitDataFifth(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataSixth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataSixthAcs^ delphiSalesSlipInputInitDataSixthAcs = DelphiSalesSlipInputInitDataSixthAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataSixthAcs->ReadInitDataSixth(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataSeventh(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataSeventhAcs^ delphiSalesSlipInputInitDataSeventhAcs = DelphiSalesSlipInputInitDataSeventhAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataSeventhAcs->ReadInitDataSeventh(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataEighth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataEighthAcs^ delphiSalesSlipInputInitDataEighthAcs = DelphiSalesSlipInputInitDataEighthAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataEighthAcs->ReadInitDataEighth(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataNinth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataNinthAcs^ delphiSalesSlipInputInitDataNinthAcs = DelphiSalesSlipInputInitDataNinthAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataNinthAcs->ReadInitDataNinth(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//������͂Ŏg�p���鏉���f�[�^���c�a���擾
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_ReadInitDataTenth(
    BSTR enterpriseCode, 
    BSTR sectionCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        DelphiSalesSlipInputInitDataTenthAcs^ delphiSalesSlipInputInitDataTenthAcs = DelphiSalesSlipInputInitDataTenthAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ sectionCodeResult = gcnew String(sectionCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputInitDataTenthAcs->ReadInitDataTenth(enterpriseCodeResult, sectionCodeResult);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�[���Ǘ��}�X�^
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetPosTerminalMg(
    StructPosTerminalMg &posTerminalMg
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            PosTerminalMg^ paraPosTerminalMg;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->GetPosTerminalMg(paraPosTerminalMg);

            //.NET�N���X���\���̕ϊ�
            if(paraPosTerminalMg != nullptr){
                CopyClassToStruct_PosTerminalMg(paraPosTerminalMg, &posTerminalMg);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�I�v�V������񏈗�
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetOptInfo(
    int &optCarMng, 
    int &optFreeSearch, 
    int &optPcc, 
    int &optRCLink, 
    int &optUoe, 
    int &optStockingPayment, 
    int &optScm, 
    int &opt_QRMail,
    int &opt_DateCtrl, // ADD T.Miyamoto 2012/11/13
	int &opt_NoBuTo // ADD 杍^ K2014/01/22
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        optCarMng = 0;
        optFreeSearch = 0;
        optPcc = 0;
        optRCLink = 0;
        optUoe = 0;
        optStockingPayment = 0;
        optScm = 0;
        opt_QRMail = 0;
        opt_DateCtrl = 0; // ADD T.Miyamoto 2012/11/13
		opt_NoBuTo = 0; // ADD 杍^ K2014/01/22

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int optCarMngResult;
            int optFreeSearchResult;
            int optPccResult;
            int optRCLinkResult;
            int optUoeResult;
            int optStockingPaymentResult;
            int optScmResult;
            int opt_QRMailResult;
            int opt_DateCtrlResult; // ADD T.Miyamoto 2012/11/13
			int opt_NoBuToResult; // ADD 杍^ K2014/01/22

            //�A�N�Z�X�N���X���\�b�h�ďo��
			// --- UPD T.Miyamoto 2012/11/13 ------------------------------>>>>>
            //salesSlipInputInitDataAcs->GetOptInfo(optCarMngResult, optFreeSearchResult, optPccResult, optRCLinkResult, optUoeResult, optStockingPaymentResult, optScmResult, opt_QRMailResult);
            //salesSlipInputInitDataAcs->GetOptInfo(optCarMngResult, optFreeSearchResult, optPccResult, optRCLinkResult, optUoeResult, optStockingPaymentResult, optScmResult, opt_QRMailResult, opt_DateCtrlResult); // DEL 杍^ K2014/01/22
			salesSlipInputInitDataAcs->GetOptInfo(optCarMngResult, optFreeSearchResult, optPccResult, optRCLinkResult, optUoeResult, optStockingPaymentResult, optScmResult, opt_QRMailResult, opt_DateCtrlResult, opt_NoBuToResult); // ADD 杍^ K2014/01/22
			// --- UPD T.Miyamoto 2012/11/13 ------------------------------<<<<<

            //.NET�N���X���\���̕ϊ�
            optCarMng = optCarMngResult;
            optFreeSearch = optFreeSearchResult;
            optPcc = optPccResult;
            optRCLink = optRCLinkResult;
            optUoe = optUoeResult;
            optStockingPayment = optStockingPaymentResult;
            optScm = optScmResult;
            opt_QRMail = opt_QRMailResult;
            opt_DateCtrl = opt_DateCtrlResult; // ADD T.Miyamoto 2012/11/13
			opt_NoBuTo = opt_NoBuToResult; // ADD 杍^ K2014/01/22
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ---- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
//�R�`���i�I�v�V������񏈗�
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetYamagataOptInfo(
    int &optStockEntCtrl
   ,int &optStockDateCtrl
   ,int &optSalesCostCtrl
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
		optStockEntCtrl = 0;  
		optStockDateCtrl = 0; 
		optSalesCostCtrl = 0; 

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
			int optStockEntCtrlResult;
			int optStockDateCtrlResult;
			int optSalesCostCtrlResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->GetYamagataOptInfo(optStockEntCtrlResult  
                                                        , optStockDateCtrlResult 
														, optSalesCostCtrlResult 
														 );

			//.NET�N���X���\���̕ϊ�
			optStockEntCtrl = optStockEntCtrlResult;   
			optStockDateCtrl = optStockDateCtrlResult; 
			optSalesCostCtrl = optSalesCostCtrlResult; 
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ---- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

// -- Add St 2012.07.23 30182 R.Tachiya --
//�󔭒��Ǘ��S�̐ݒ�}�X�^
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt(
    StructAcptAnOdrTtlSt &acptAnOdrTtlSt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            AcptAnOdrTtlSt^ paraAcptAnOdrTtlSt;


            //�A�N�Z�X�N���X���\�b�h�ďo��
			salesSlipInputInitDataAcs->GetAcptAnOdrTtlSt(paraAcptAnOdrTtlSt);

            //.NET�N���X���\���̕ϊ�
            if(paraAcptAnOdrTtlSt != nullptr){
                CopyClassToStruct_AcptAnOdrTtlSt(paraAcptAnOdrTtlSt, &acptAnOdrTtlSt);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// -- Add Ed 2012.07.23 30182 R.Tachiya --

//����S�̐ݒ�}�X�^
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetSalesTtlSt(
    StructSalesTtlSt &salesTtlSt
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesTtlSt^ paraSalesTtlSt;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->GetSalesTtlSt(paraSalesTtlSt);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesTtlSt != nullptr){
                CopyClassToStruct_SalesTtlSt(paraSalesTtlSt, &salesTtlSt);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�S�̏����l�ݒ�}�X�^
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetAllDefSet(
    StructAllDefSet &allDefSet
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            AllDefSet^ paraAllDefSet;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->GetAllDefSet(paraAllDefSet);

            //.NET�N���X���\���̕ϊ�
            if(paraAllDefSet != nullptr){
                CopyClassToStruct_AllDefSet(paraAllDefSet, &allDefSet);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���Џ��ݒ�}�X�^
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_GetCompanyInf(
    StructCompanyInf &companyInf
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            CompanyInf^ paraCompanyInf;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->GetCompanyInf(paraCompanyInf);

            //.NET�N���X���\���̕ϊ�
            if(paraCompanyInf != nullptr){
                CopyClassToStruct_CompanyInf(paraCompanyInf, &companyInf);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//������z�����敪�ݒ�}�X�^���䏈��
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->CacheSalesProcMoneyListCall();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�d�����z�����敪�ݒ�}�X�^���䏈��
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_CacheStockProcMoneyListCall(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->CacheStockProcMoneyListCall();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�|���D��Ǘ��}�X�^���䏈��
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_CacheRateProtyMngListCall(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->CacheRateProtyMngListCall();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�����敪�}�X�^���X�g�ݒ菈��
__declspec(dllexport) int __stdcall SalesSlipInputInitDataAcs_SettingProcMoney(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputInitDataAcs^ salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputInitDataAcs->SettingProcMoney();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���������
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreePosTerminalMg(StructPosTerminalMg *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreePosTerminalMg(deleteStructList, deleteStructListCount);
}

// -- Add St 2012.07.23 30182 R.Tachiya --
//���������
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt(StructAcptAnOdrTtlSt *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeAcptAnOdrTtlSt(deleteStructList, deleteStructListCount);
}
// -- Add Ed 2012.07.23 30182 R.Tachiya --

//���������
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeSalesTtlSt(StructSalesTtlSt *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeSalesTtlSt(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeAllDefSet(StructAllDefSet *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeAllDefSet(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeCompanyInf(StructCompanyInf *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCompanyInf(deleteStructList, deleteStructListCount);
}

//��������
__declspec(dllexport) void __stdcall SalesSlipInputInitDataAcs_FreeMessage(BSTR message){
	//�����������\�b�h�Ăяo��
	FreeMessage(message);
}