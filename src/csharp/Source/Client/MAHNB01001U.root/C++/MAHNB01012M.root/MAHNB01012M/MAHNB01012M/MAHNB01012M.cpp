//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����`�[����
// �v���O�����T�v   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b 
// �� �� ��  2010/06/12  �C�����e : �g�у��[���@�\�̑g��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : yangyi
// �� �� ��  K2011/08/12 �C�����e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : �����
// �� �� ��  2012/02/09  �C�����e : Redmine#28289�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� ���T
// �� �� ��  2013/03/21  �C�����e : SPK�ԑ�ԍ�������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : �{�{�@����
// �� �� ��  2014/05/19  �C�����e : �d�|�ꗗ��2218 ���q���l���ɃR�[�h���͍��ڂ�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : �{�{�@����
// �� �� ��  2014/06/02  �C�����e : �V�X�e���e�X�g��Q��87 �Ǘ��ԍ��K�C�h�����̃p�����[�^�ݒ���C��
//----------------------------------------------------------------------------//
// ����� ���C�� DLL �t�@�C���ł��B

#include "stdafx.h"

#include "MAHNB01012C.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Collections;
using namespace System::Collections::Generic;

using namespace Broadleaf::Library::Resources;
using namespace Broadleaf::Application::Remoting::ParamData;
using namespace Broadleaf::Application::Controller;

//�ԗ������A�N�Z�X�N���X���b�p�[

//�ԗ���������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CarSearch(
    StructCarSearchCondition condition, 
    int salesRowNo, 
    int conditionType
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            CarSearchCondition^ paraCondition = gcnew CarSearchCondition();

            CopyStructToClass_CarSearchCondition(&condition, paraCondition);
            int salesRowNoResult = salesRowNo;
            int conditionTypeResult = conditionType;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->CarSearch(paraCondition, salesRowNoResult, conditionTypeResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            conditionType = conditionTypeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����s�I�u�W�F�N�g�擾
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetCarInfoRow(
    int salesRowNo, 
    int getCarInfoMode, 
    StructCarInfo &carInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            int getCarInfoModeResult = getCarInfoMode;
            Broadleaf::Application::Controller::SalesSlipInputAcs::CarInfo^ paraCarInfo;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->GetCarInfoRow(salesRowNoResult, getCarInfoModeResult, paraCarInfo);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            getCarInfoMode = getCarInfoModeResult;
            if(paraCarInfo != nullptr){
                CopyClassToStruct_CarInfo(paraCarInfo, &carInfo);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�J���[���擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetColorInfo(
    BSTR carRelationGuid, 
    StructCustomArrayB2 &colorInfoList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            ArrayList^ paraColorInfoList;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetColorInfo(carRelationGuidResult, paraColorInfoList);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraColorInfoList != nullptr){
                CopyClassToStruct_CustomArrayB2(paraColorInfoList, &colorInfoList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�I���J���[���擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSelectColorInfo(
    BSTR carRelationGuid, 
    StructColorInfo &colorInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            Broadleaf::Application::Controller::SalesSlipInputAcs::ColorInfo^ paraColorInfo;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetSelectColorInfo(carRelationGuidResult, paraColorInfo);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraColorInfo != nullptr){
                CopyClassToStruct_ColorInfo(paraColorInfo, &colorInfo);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�g�������擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetTrimInfo(
    BSTR carRelationGuid, 
    StructCustomArrayB3 &trimInfoList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            ArrayList^ paraTrimInfoList;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetTrimInfo(carRelationGuidResult, paraTrimInfoList);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraTrimInfoList != nullptr){
                CopyClassToStruct_CustomArrayB3(paraTrimInfoList, &trimInfoList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�I���g�������擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSelectTrimInfo(
    BSTR carRelationGuid, 
    StructTrimInfo &trimInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            Broadleaf::Application::Controller::SalesSlipInputAcs::TrimInfo^ paraTrimInfo;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetSelectTrimInfo(carRelationGuidResult, paraTrimInfo);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraTrimInfo != nullptr){
                CopyClassToStruct_TrimInfo(paraTrimInfo, &trimInfo);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�������擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetEquipInfo(
    BSTR carRelationGuid, 
    StructCustomArrayB4 &cEqpDefDspInfoList
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            ArrayList^ paraCEqpDefDspInfoList;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetEquipInfo(carRelationGuidResult, paraCEqpDefDspInfoList);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            if(paraCEqpDefDspInfoList != nullptr){
                CopyClassToStruct_CustomArrayB4(paraCEqpDefDspInfoList, &cEqpDefDspInfoList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�J���[���I������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SelectColorInfo(
    BSTR carRelationGuid, 
    BSTR colorCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ colorCodeResult = gcnew String(colorCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->SelectColorInfo(carRelationGuidResult, colorCodeResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            colorCode = static_cast<BSTR>(Marshal::StringToBSTR(colorCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�g�������I������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SelectTrimInfo(
    BSTR carRelationGuid, 
    BSTR trimCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ trimCodeResult = gcnew String(trimCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->SelectTrimInfo(carRelationGuidResult, trimCodeResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            trimCode = static_cast<BSTR>(Marshal::StringToBSTR(trimCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���Y�N���͈̓`�F�b�N
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CheckProduceTypeOfYearRange(
    BSTR carRelationGuid, 
    int firstEntryDate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            int firstEntryDateResult = firstEntryDate;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->CheckProduceTypeOfYearRange(carRelationGuidResult, firstEntryDateResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            firstEntryDate = firstEntryDateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ������f�[�^�e�[�u���N���ݒ菈��
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate(
    BSTR carRelationGuid, 
    int firstEntryDate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            int firstEntryDateResult = firstEntryDate;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarModelUIDataFromFirstEntryDate(carRelationGuidResult, firstEntryDateResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            firstEntryDate = firstEntryDateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԑ�ԍ��͈̓`�F�b�N
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CheckProduceFrameNo(
    BSTR carRelationGuid, 
    BSTR inputFrameNo, 
    int searchFrameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ inputFrameNoResult = gcnew String(inputFrameNo);
            int searchFrameNoResult = searchFrameNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->CheckProduceFrameNo(carRelationGuidResult, inputFrameNoResult, searchFrameNoResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            inputFrameNo = static_cast<BSTR>(Marshal::StringToBSTR(inputFrameNoResult).ToPointer());
            searchFrameNo = searchFrameNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈��
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo(
    BSTR carRelationGuid, 
    BSTR frameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ frameNoResult = gcnew String(frameNo);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarModelUIDataFromProduceFrameNo(carRelationGuidResult, frameNoResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            frameNo = static_cast<BSTR>(Marshal::StringToBSTR(frameNoResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ώ۔N���擾����(�ԑ�ԍ����擾)
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetProduceTypeOfYear(
    BSTR carRelationGuid, 
    int frameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            int frameNoResult = frameNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetProduceTypeOfYear(gcnew String(carRelationGuidResult), frameNoResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            frameNo = frameNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���̃N���A
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ClearCarInfoRow(
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ClearCarInfoRow(salesRowNoResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̔N���Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate(
    int salesRowNo, 
    int firstEntryDate
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            int firstEntryDateResult = firstEntryDate;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromFirstEntryDate(salesRowNoResult, firstEntryDateResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            firstEntryDate = firstEntryDateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromFrameNo(
    int salesRowNo, 
    BSTR frameNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            String^ frameNoResult = gcnew String(frameNo);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromFrameNo(salesRowNoResult, frameNoResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            frameNo = static_cast<BSTR>(Marshal::StringToBSTR(frameNoResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̎Ԏ���Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromModelInfo(
    int salesRowNo, 
    int makerCode, 
    BSTR makerFullName, 
    BSTR makerHalfName, 
    int modelCode, 
    int modelSubCode, 
    BSTR modelFullName, 
    BSTR modelHalfName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            int makerCodeResult = makerCode;
            String^ makerFullNameResult = gcnew String(makerFullName);
            String^ makerHalfNameResult = gcnew String(makerHalfName);
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            String^ modelFullNameResult = gcnew String(modelFullName);
            String^ modelHalfNameResult = gcnew String(modelHalfName);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromModelInfo(salesRowNoResult, makerCodeResult, makerFullNameResult, makerHalfNameResult, modelCodeResult, modelSubCodeResult, modelFullNameResult, modelHalfNameResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            makerCode = makerCodeResult;
            makerFullName = static_cast<BSTR>(Marshal::StringToBSTR(makerFullNameResult).ToPointer());
            makerHalfName = static_cast<BSTR>(Marshal::StringToBSTR(makerHalfNameResult).ToPointer());
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
            modelHalfName = static_cast<BSTR>(Marshal::StringToBSTR(modelHalfNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ԏ햼�̎擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetModelFullName(
    int makerCode, 
    int modelCode, 
    int modelSubCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetModelFullName(makerCodeResult, modelCodeResult, modelSubCodeResult);

            //.NET�N���X���\���̕ϊ�
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ԏ피�p���̎擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetModelHalfName(
    int makerCode, 
    int modelCode, 
    int modelSubCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetModelHalfName(makerCodeResult, modelCodeResult, modelSubCodeResult);

            //.NET�N���X���\���̕ϊ�
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCarMngCode(
    int salesRowNo, 
    BSTR carMngCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            String^ carMngCodeResult = gcnew String(carMngCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromCarMngCode(salesRowNoResult, carMngCodeResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo(
    int salesRowNo, 
    int modelDesignationNo, 
    int categoryNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            int modelDesignationNoResult = modelDesignationNo;
            int categoryNoResult = categoryNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNoResult, modelDesignationNoResult, categoryNoResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            modelDesignationNo = modelDesignationNoResult;
            categoryNo = categoryNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̌^���Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromFullModel(
    int salesRowNo, 
    BSTR fullModel
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            String^ fullModelResult = gcnew String(fullModel);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromFullModel(salesRowNoResult, fullModelResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            fullModel = static_cast<BSTR>(Marshal::StringToBSTR(fullModelResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̃G���W���^���Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm(
    int salesRowNo, 
    BSTR engineModelNm
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            String^ engineModelNmResult = gcnew String(engineModelNm);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromEngineModelNm(salesRowNoResult, engineModelNmResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            engineModelNm = static_cast<BSTR>(Marshal::StringToBSTR(engineModelNmResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ���񑶍݃`�F�b�N
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ExistCarInfo(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->ExistCarInfo();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
//�ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode(
    int salesRowNo, 
    int carNoteCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            int carNoteCodeResult = carNoteCode;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromCarNoteCode(salesRowNoResult, carNoteCodeResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            carNoteCode = carNoteCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

//�ԗ����e�[�u���s�̎��q���l�Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromCarNote(
    int salesRowNo, 
    BSTR carNote
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            String^ carNoteResult = gcnew String(carNote);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromCarNote(salesRowNoResult, carNoteResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            carNote = static_cast<BSTR>(Marshal::StringToBSTR(carNoteResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�ԗ����e�[�u���s�̎��q���s�����Z�b�g
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingCarInfoRowFromMileage(
    int salesRowNo, 
    int mileage
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;
            int mileageResult = mileage;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingCarInfoRowFromMileage(salesRowNoResult, mileageResult);

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
            mileage = mileageResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
// add by Zhangkai start

//�I�v�V������񏈗�
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSettingOptionInfo(
    int &optCarMng, 
    int &optStockingPayment
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        optCarMng = 0;
        optStockingPayment = 0;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int optCarMngResult;
            int optStockingPaymentResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetSettingOptionInfo(optCarMngResult, optStockingPaymentResult);

            //.NET�N���X���\���̕ϊ�
            optCarMng = optCarMngResult;
            optStockingPayment = optStockingPaymentResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


// add by Zhangkai end

// add by Lizc start
//�J�[���[�J�[�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterMakerCodeFocus(
    int makerCode, 
    int salesRowNo, 
    BSTR &makerName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        makerName = NULL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int makerCodeResult = makerCode;
            int salesRowNoResult = salesRowNo;
            String^ makerNameResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterMakerCodeFocus(makerCodeResult, salesRowNoResult, makerNameResult);

            //.NET�N���X���\���̕ϊ�
            makerCode = makerCodeResult;
            salesRowNo = salesRowNoResult;
            makerName = static_cast<BSTR>(Marshal::StringToBSTR(makerNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ԏ�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterModelCodeFocus(
    int makerCode, 
    int modelCode, 
    int modelSubCode, 
    int salesRowNo, 
    BSTR &modelFullName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        modelFullName = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            int salesRowNoResult = salesRowNo;
            String^ modelFullNameResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterModelCodeFocus(makerCodeResult, modelCodeResult, modelSubCodeResult, salesRowNoResult, modelFullNameResult);

            //.NET�N���X���\���̕ϊ�
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            salesRowNo = salesRowNoResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ԏ�ď̃R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterModelSubCodeFocus(
    int makerCode, 
    int modelCode, 
    int modelSubCode, 
    int salesRowNo, 
    BSTR &modelFullName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        modelFullName = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            int salesRowNoResult = salesRowNo;
            String^ modelFullNameResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterModelSubCodeFocus(makerCodeResult, modelCodeResult, modelSubCodeResult, salesRowNoResult, modelFullNameResult);

            //.NET�N���X���\���̕ϊ�
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            salesRowNo = salesRowNoResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ԏ햼�̂̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterModelFullNameFocus(
    int makerCode, 
    int modelCode, 
    int modelSubCode, 
    BSTR modelFullName, 
    int salesRowNo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            String^ modelFullNameResult = gcnew String(modelFullName);
            int salesRowNoResult = salesRowNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterModelFullNameFocus(makerCodeResult, modelCodeResult, modelSubCodeResult, modelFullNameResult, salesRowNoResult);

            //.NET�N���X���\���̕ϊ�
            makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            modelFullName = static_cast<BSTR>(Marshal::StringToBSTR(modelFullNameResult).ToPointer());
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�N���̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterFirstEntryDateFocus(
    int firstEntryDate, 
    int salesRowNo, 
    bool &boolRet
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int firstEntryDateResult = firstEntryDate;
            int salesRowNoResult = salesRowNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterFirstEntryDateFocus(firstEntryDateResult, salesRowNoResult, boolRet);

            //.NET�N���X���\���̕ϊ�
            firstEntryDate = firstEntryDateResult;
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//�ԑ�ԍ��̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterProduceFrameNoFocus(
    BSTR produceFrameNo, 
    int salesRowNo, 
    bool &boolRet,
	int mode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ produceFrameNoResult = gcnew String(produceFrameNo);
            int salesRowNoResult = salesRowNo;
            bool paraBoolRet;
			int modeResult = mode;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterProduceFrameNoFocus(produceFrameNoResult, salesRowNoResult, paraBoolRet, modeResult);

            //.NET�N���X���\���̕ϊ�
            produceFrameNo = static_cast<BSTR>(Marshal::StringToBSTR(produceFrameNoResult).ToPointer());
            salesRowNo = salesRowNoResult;
            boolRet = paraBoolRet;
			mode = modeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�ǉ����^�u����Visible�ݒ�
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SettingAddInfoVisible(
    int customerCode, 
    BSTR carMngCode, 
    int salesRowNo, 
    bool &boolRet
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int customerCodeResult = customerCode;
            String^ carMngCodeResult = gcnew String(carMngCode);
            int salesRowNoResult = salesRowNo;
            bool paraBoolRet;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SettingAddInfoVisible(customerCodeResult, carMngCodeResult, salesRowNoResult, paraBoolRet);

            //.NET�N���X���\���̕ϊ�
            customerCode = customerCodeResult;
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
            salesRowNo = salesRowNoResult;
            boolRet = paraBoolRet;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�Ԏ�ύX�{�^��Visible
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetChangeCarInfoVisible(
    int customerCode, 
    BSTR carMngCode, 
    int &visibleFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        visibleFlag = 0;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int customerCodeResult = customerCode;
            String^ carMngCodeResult = gcnew String(carMngCode);
            int visibleFlagResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetChangeCarInfoVisible(customerCodeResult, carMngCodeResult, visibleFlagResult);

            //.NET�N���X���\���̕ϊ�
            customerCode = customerCodeResult;
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
            visibleFlag = visibleFlagResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�Ǘ��ԍ��̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterCarMngCodeFocus(
    BSTR carMngCode, 
    int customerCode, 
    BSTR enterpriseCode,
	int salesRowNo,
    StructCarMangInputExtraInfo &selectedInfo, 
    bool &returnFlag,
	bool &clearCarInfoFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carMngCodeResult = gcnew String(carMngCode);
            int customerCodeResult = customerCode;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
			int salesRowNoResult = salesRowNo;
            CarMangInputExtraInfo^ paraSelectedInfo;

            bool paraReturnFlag;
			bool paraClearCarInfoFlag;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->AfterCarMngCodeFocus(carMngCodeResult, customerCodeResult, enterpriseCodeResult, salesRowNoResult,  paraSelectedInfo, paraReturnFlag, paraClearCarInfoFlag);

            //.NET�N���X���\���̕ϊ�
            carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
            customerCode = customerCodeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
			salesRowNo = salesRowNoResult;
            if(paraSelectedInfo != nullptr){
                CopyClassToStruct_CarMangInputExtraInfo(paraSelectedInfo, &selectedInfo);
            }
			returnFlag = paraReturnFlag;
			clearCarInfoFlag = paraClearCarInfoFlag;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
	//���_�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSectionCodeFocus(
    BSTR sectionCode, 
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ sectionCodeResult = gcnew String(sectionCode);
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->AfterSectionCodeFocus(sectionCodeResult, paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            sectionCode = static_cast<BSTR>(Marshal::StringToBSTR(sectionCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    
//���喼�̎擾����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetNameFromSubSection(
    int subSectionCode, 
    BSTR &subSectionNm
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        subSectionNm = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int subSectionCodeResult = subSectionCode;
            String^ subSectionNmResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetNameFromSubSection(subSectionCodeResult, subSectionNmResult);

            //.NET�N���X���\���̕ϊ�
            subSectionCode = subSectionCodeResult;
            subSectionNm = static_cast<BSTR>(Marshal::StringToBSTR(subSectionNmResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�S���ҕύX����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesEmployee(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR code, 
    bool canChangeFocus,
    bool &refCanChangeFocus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);
            bool paraCanChangeFocus = canChangeFocus;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeSalesEmployee(paraSalesSlip, paraSalesSlipCurrent, codeResult, paraCanChangeFocus);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
			refCanChangeFocus = paraCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�󒍎ҕύX����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeFrontEmployee(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR code, 
    bool canChangeFocus,
    bool &refCanChangeFocus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);
            bool paraCanChangeFocus = canChangeFocus;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeFrontEmployee(paraSalesSlip, paraSalesSlipCurrent, codeResult, paraCanChangeFocus);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
            refCanChangeFocus = paraCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���s�ҕύX����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesInput(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    BSTR code, 
    bool canChangeFocus,
    bool &refCanChangeFocus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);
            bool paraCanChangeFocus = canChangeFocus;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeSalesInput(paraSalesSlip, paraSalesSlipCurrent, codeResult, paraCanChangeFocus);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
            refCanChangeFocus = paraCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//�`�[�敪�ύX����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesSlip(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    bool isCache, 
    int code, 
    bool changeSalesSlipDisplay,
    bool &refChangeSalesSlipDisplay, 
    bool &clearDetailInput, 
    bool &clearCarInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            bool paraIsCache = isCache;

            int codeResult = code;
            bool paraChangeSalesSlipDisplay = changeSalesSlipDisplay;

            bool paraClearDetailInput;

            bool paraClearCarInfo;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeSalesSlip(paraSalesSlip, paraIsCache, codeResult, paraChangeSalesSlipDisplay, paraClearDetailInput, paraClearCarInfo);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = codeResult;
			refChangeSalesSlipDisplay = paraChangeSalesSlipDisplay;
			clearDetailInput = paraClearDetailInput;
			clearCarInfo = paraClearCarInfo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���i�敪�ύX����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeSalesGoodsCd(
    StructSalesSlip salesSlipCurrent, 
    int code, 
    bool changeSalesGoodsCd,
    bool &refChangeSalesGoodsCd, 
    bool &clearDetailInput, 
    bool &clearCarInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            int codeResult = code;
            bool paraChangeSalesGoodsCd = changeSalesGoodsCd;

            bool paraClearDetailInput;

            bool paraClearCarInfo;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeSalesGoodsCd(paraSalesSlipCurrent, codeResult, paraChangeSalesGoodsCd, paraClearDetailInput, paraClearCarInfo);

            //.NET�N���X���\���̕ϊ�
            code = codeResult;
			refChangeSalesGoodsCd = paraChangeSalesGoodsCd;
			clearDetailInput = paraClearDetailInput;
			clearCarInfo = paraClearCarInfo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }


//���Ӑ�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterCustomerCodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int code, 
    StructCustomerInfo customerInfo,
    StructCustomerInfo &refCustomerInfo, 
    bool &clearAddCarInfo, 
    bool canChangeFocus,
    bool &refCanChangeFocus, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice, 
    bool guideStart,
    bool &refGuideStart, 
    bool &clearDetailInput, 
    bool &clearCarInfo, 
    bool reCalcSalesUnitPrice,
    bool &refReCalcSalesUnitPrice, 
    bool clearRateInfo,
    bool &refClearRateInfo
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int codeResult = code;
            CustomerInfo^ paraCustomerInfo = gcnew CustomerInfo();

            CopyStructToClass_CustomerInfo(&customerInfo, paraCustomerInfo);
            bool paraClearAddCarInfo;

            bool paraCanChangeFocus = canChangeFocus;

            //CopyStructToClass_bool(&canChangeFocus, paraCanChangeFocus);
            bool paraReCalcSalesPrice = reCalcSalesPrice;

            //CopyStructToClass_bool(&reCalcSalesPrice, paraReCalcSalesPrice);
            bool paraGuideStart = guideStart;

            //CopyStructToClass_bool(&guideStart, paraGuideStart);
            bool paraClearDetailInput;

            bool paraClearCarInfo;

            bool paraReCalcSalesUnitPrice = reCalcSalesUnitPrice;

            //CopyStructToClass_bool(&reCalcSalesUnitPrice, paraReCalcSalesUnitPrice);
            bool paraClearRateInfo = clearRateInfo;

            //CopyStructToClass_bool(&clearRateInfo, paraClearRateInfo);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterCustomerCodeFocus(paraSalesSlip, codeResult, paraCustomerInfo, paraClearAddCarInfo, paraCanChangeFocus, paraReCalcSalesPrice, paraGuideStart, paraClearDetailInput, paraClearCarInfo, paraReCalcSalesUnitPrice, paraClearRateInfo);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = codeResult;
            if(paraCustomerInfo != nullptr){
                CopyClassToStruct_CustomerInfo(paraCustomerInfo, &refCustomerInfo);
            }
			clearAddCarInfo = paraClearAddCarInfo;
			refCanChangeFocus = paraCanChangeFocus;
			refReCalcSalesPrice = paraReCalcSalesPrice;
			refGuideStart = paraGuideStart;
			clearDetailInput = paraClearDetailInput;
			clearCarInfo = paraClearCarInfo;
			refReCalcSalesUnitPrice = paraReCalcSalesUnitPrice;
			refClearRateInfo = paraClearRateInfo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//�`�[�ԍ��̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSalesSlipNumFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent,
    StructSalesSlip &refSalesSlipCurrent, 
    BSTR code, 
    BSTR enterpriseCode, 
    bool &equelFlag, 
    int &readDBDatStatus, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice, 
    bool &deleteEmptyRow,
	bool &findDataFlg  // ADD 2010/07/01
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        readDBDatStatus = 0;

		//SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();
		DelphiSalesSlipInputAcs^ salesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();
            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            String^ codeResult = gcnew String(code);

            String^ enterpriseCodeResult = gcnew String(enterpriseCode);

            int readDBDatStatusResult;
            bool paraReCalcSalesPrice = reCalcSalesPrice;

            //�A�N�Z�X�N���X���\�b�h�ďo��
			// --- UPD 2010/07/01 --------->>>>>
            //salesSlipInputAcs->AfterSalesSlipNumFocus(paraSalesSlip, paraSalesSlipCurrent, codeResult, enterpriseCodeResult, equelFlag, readDBDatStatusResult, paraReCalcSalesPrice, deleteEmptyRow);
			salesSlipInputAcs->AfterSalesSlipNumFocus(paraSalesSlip, paraSalesSlipCurrent, codeResult, enterpriseCodeResult, equelFlag, readDBDatStatusResult, paraReCalcSalesPrice, deleteEmptyRow, findDataFlg);
			// --- UPD 2010/07/01 ---------<<<<<

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            if(paraSalesSlipCurrent != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlipCurrent, &refSalesSlipCurrent);
            }
            code = static_cast<BSTR>(Marshal::StringToBSTR(codeResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            readDBDatStatus = readDBDatStatusResult;
			refReCalcSalesPrice = paraReCalcSalesPrice;

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�󒍃X�e�[�^�X���X�g�쐬
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetStateList(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SetStateList();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //������̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSalesDateFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    StructSalesSlip salesSlipCurrent, 
    long long salesDate, 
    BSTR salesDateText, 
    bool reCalcSalesUnitPrice,
    bool &refReCalcSalesUnitPrice, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice, 
    double &taxRate,
	bool &refReCanChangeFocus // ADD K2011/08/12
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            DateTime salesDateResult = DateTime(salesDate);
            String^ salesDateTextResult = gcnew String(salesDateText);
            bool paraReCalcSalesUnitPrice = reCalcSalesUnitPrice;

            bool paraReCalcSalesPrice = reCalcSalesPrice;

            double taxRateResult = taxRate;
			bool paraReCanChangeFocus = true; // ADD K2011/08/12

            //�A�N�Z�X�N���X���\�b�h�ďo��
            //salesSlipInputAcs->AfterSalesDateFocus(paraSalesSlip, paraSalesSlipCurrent, salesDateResult, salesDateTextResult, paraReCalcSalesUnitPrice, paraReCalcSalesPrice, taxRateResult); // DEL K2011/08/12
			salesSlipInputAcs->AfterSalesDateFocus(paraSalesSlip, paraSalesSlipCurrent, salesDateResult, salesDateTextResult, paraReCalcSalesUnitPrice, paraReCalcSalesPrice, taxRateResult, paraReCanChangeFocus); // ADD K2011/08/12

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
			salesDate = salesDateResult.Ticks;
            salesDateText = static_cast<BSTR>(Marshal::StringToBSTR(salesDateTextResult).ToPointer());
			refReCalcSalesUnitPrice = paraReCalcSalesUnitPrice;
			refReCalcSalesPrice = paraReCalcSalesPrice;
            taxRate = taxRateResult;
			refReCanChangeFocus = paraReCanChangeFocus; // ADD K2011/08/12
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�[����R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterAddresseeCodeFocue(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int code, 
    BSTR enterpriseCode, 
    bool reCalcSalesPrice,
    bool &refReCalcSalesPrice
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int codeResult = code;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            bool paraReCalcSalesPrice = reCalcSalesPrice;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterAddresseeCodeFocue(paraSalesSlip, codeResult, enterpriseCodeResult, paraReCalcSalesPrice);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            code = codeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
			refReCalcSalesPrice = paraReCalcSalesPrice;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CacheForChange(
    StructSalesSlip salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs =SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->CacheForChange(paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //��������̓��e�Ɣ�r
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CompareSalesSlip(
    StructSalesSlip salesSlip, 
    StructSalesSlip salesSlipCurrent, 
    bool &compareRes
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            SalesSlip^ paraSalesSlipCurrent = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlipCurrent, paraSalesSlipCurrent);
            //bool^ paraCompareRes;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->CompareSalesSlip(paraSalesSlip, paraSalesSlipCurrent, compareRes);
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //����P���Čv�Z
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ReCalcSalesUnitPrice(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ReCalcSalesUnitPrice(paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�|�����N���A�����i�S�āj
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ClearAllRateInfo(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ClearAllRateInfo();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���l�P�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNoteCodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int value
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int valueResult = value;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterSlipNoteCodeFocus(paraSalesSlip, valueResult);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = valueResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���l�Q�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNote2CodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int value,
	bool &refCanChangeFocus // ADD K2011/08/12
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int valueResult = value;
			bool paraReCanChangeFocus = true; // ADD K2011/08/12

            //�A�N�Z�X�N���X���\�b�h�ďo��
            //salesSlipInputAcs->AfterSlipNote2CodeFocus(paraSalesSlip, valueResult); // DEL K2011/08/12
            salesSlipInputAcs->AfterSlipNote2CodeFocus(paraSalesSlip, valueResult, paraReCanChangeFocus); // ADD K2011/08/12

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = valueResult;
			refCanChangeFocus = paraReCanChangeFocus; // ADD K2011/08/12
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// ----- ADD K2011/08/12 --------------------------->>>>>
//���l�Q�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNote2Focus(
    StructSalesSlip salesSlip,
    BSTR slipNote2,
	bool &refCanChangeFocus // ADD K2011/08/12
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            String^ slipNote2Result = gcnew String(slipNote2);
			bool paraReCanChangeFocus = true;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterSlipNote2Focus(paraSalesSlip, slipNote2Result, paraReCanChangeFocus);

            //.NET�N���X���\���̕ϊ�
			refCanChangeFocus = paraReCanChangeFocus;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ----- ADD K2011/08/12 ---------------------------<<<<<

//���l�R�R�[�h�̃t�H�[�J�X����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AfterSlipNote3CodeFocus(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int value
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int valueResult = value;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AfterSlipNote3CodeFocus(paraSalesSlip, valueResult);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            value = valueResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //����f�[�^����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSalesSlip(
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetSalesSlip(paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //������m�F�{�^���N���b�N
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CustomerClaimConfirmationClick(
    long long salesDate, 
    BSTR &focus
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        focus = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            DateTime salesDateResult = DateTime(salesDate);
            String^ focusResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->CustomerClaimConfirmationClick(salesDateResult, focusResult);

            //.NET�N���X���\���̕ϊ�
            salesDate = salesDateResult.Ticks;
            focus = static_cast<BSTR>(Marshal::StringToBSTR(focusResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�[����m�F�{�^���N���b�N
__declspec(dllexport) int __stdcall SalesSlipInputAcs_AddresseeConfirmationClick(
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->AddresseeConfirmationClick(paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //���㖾�׃f�[�^�̑��݃`�F�b�N
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ExistSalesDetail(
    bool &exist
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ExistSalesDetail(exist);

        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//����`���ύX�\�`�F�b�N����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeCheckAcptAnOdrStatus(
    int code, 
    StructSalesSlip salesSlip, 
    bool &clearDisplayCarInfo, 
    bool &clearAddUpInfo, 
    bool &result
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int codeResult = code;
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            bool paraClearDisplayCarInfo;

            bool paraClearAddUpInfo;

            bool paraResult;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeCheckAcptAnOdrStatus(codeResult, paraSalesSlip, paraClearDisplayCarInfo, paraClearAddUpInfo, paraResult);

            //.NET�N���X���\���̕ϊ�
            code = codeResult;
			clearDisplayCarInfo = paraClearDisplayCarInfo;
			clearAddUpInfo = paraClearAddUpInfo;
			result = paraResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//����`���ύX�\����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_ChangeAcptAnOdrStatus(
    int code, 
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip, 
    int svCode
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int codeResult = code;
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);
            int svCodeResult = svCode;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->ChangeAcptAnOdrStatus(codeResult, paraSalesSlip, svCodeResult);

            //.NET�N���X���\���̕ϊ�
            code = codeResult;
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
            svCode = svCodeResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//����f�[�^�L���b�V������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_Cache(
    StructSalesSlip salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->Cache(paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂�
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay(
    StructSalesSlip salesSlip,
    StructSalesSlip &refSalesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            SalesSlip^ paraSalesSlip = gcnew SalesSlip();

            CopyStructToClass_SalesSlip(&salesSlip, paraSalesSlip);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SetSlipCdAndAccRecDivCdFromDisplay(paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &refSalesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�������I������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SelectEquipInfo(
    BSTR carRelationGuid, 
    BSTR equipmentGenreCd, 
    BSTR equipmentName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ equipmentGenreCdResult = gcnew String(equipmentGenreCd);
            String^ equipmentNameResult = gcnew String(equipmentName);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SelectEquipInfo(carRelationGuidResult, equipmentGenreCdResult, equipmentNameResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            equipmentGenreCd = static_cast<BSTR>(Marshal::StringToBSTR(equipmentGenreCdResult).ToPointer());
            equipmentName = static_cast<BSTR>(Marshal::StringToBSTR(equipmentNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //�f�[�^�ύX�t���O�̐ݒ菈��
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetGetIsDataChanged(
    int flag, 
    bool isDataChanged,
    bool &refIsDataChanged
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int flagResult = flag;
            bool paraIsDataChanged = refIsDataChanged;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SetGetIsDataChanged(flagResult, paraIsDataChanged);

            //.NET�N���X���\���̕ϊ�
            flag = flagResult;
            refIsDataChanged = paraIsDataChanged;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
//�w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetHeaderFocusConstructionListValue(
    StructCustomArrayB5 &headerFocusConstructionList, 
    StructCustomArrayB6 &footerFocusConstructionList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            ArrayList^ paraHeaderFocusConstructionList;

            ArrayList^ paraFooterFocusConstructionList;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetHeaderFocusConstructionListValue(paraHeaderFocusConstructionList, paraFooterFocusConstructionList);

            //.NET�N���X���\���̕ϊ�
            if(paraHeaderFocusConstructionList != nullptr){
                CopyClassToStruct_CustomArrayB5(paraHeaderFocusConstructionList, &headerFocusConstructionList);
            }
            if(paraFooterFocusConstructionList != nullptr){
                CopyClassToStruct_CustomArrayB6(paraFooterFocusConstructionList, &footerFocusConstructionList);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�t�H�[�J�X�ݒ胊�X�g�̎捞����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetFocusConstructionValue(
    BSTR &headerList, 
    BSTR &footerList
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        headerList = NULL;
        footerList = NULL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ headerListResult;
            String^ footerListResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetFocusConstructionValue(headerListResult, footerListResult);

            //.NET�N���X���\���̕ϊ�
            headerList = static_cast<BSTR>(Marshal::StringToBSTR(headerListResult).ToPointer());
            footerList = static_cast<BSTR>(Marshal::StringToBSTR(footerListResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
    
    //���_���̂̎捞����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetSectionNm(
    BSTR section, 
    BSTR &sectionName
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;
        sectionName = NULL;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ sectionResult = gcnew String(section);
            String^ sectionNameResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetSectionNm(sectionResult, sectionNameResult);

            //.NET�N���X���\���̕ϊ�
            section = static_cast<BSTR>(Marshal::StringToBSTR(sectionResult).ToPointer());
            sectionName = static_cast<BSTR>(Marshal::StringToBSTR(sectionNameResult).ToPointer());
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2010/07/16 ---------->>>>>    
    //�ԗ������敪�̎捞����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_SetGetSearchCarDiv(
    int flag, 
    bool searchCarDiv,
    bool &refSearchCarDiv
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int flagResult = flag;
            bool paraSearchCarDiv = searchCarDiv;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->SetGetSearchCarDiv(flagResult, paraSearchCarDiv);

            //.NET�N���X���\���̕ϊ�
            flag = flagResult;
            refSearchCarDiv = paraSearchCarDiv;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/07/16 ----------<<<<<
// add by Lizc end

// add by gaofeng start
//���_�K�C�h����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_sectionGuide(
    BSTR enterpriseCode, 
    BSTR formName, 
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            String^ formNameResult = gcnew String(formName);
            SalesSlip^ paraSalesSlip;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            delphiSalesSlipInputAcs->sectionGuide(enterpriseCodeResult, formNameResult, paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            formName = static_cast<BSTR>(Marshal::StringToBSTR(formNameResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//����K�C�h����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_subSectionGuide(
    BSTR enterpriseCode, 
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            SalesSlip^ paraSalesSlip;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            delphiSalesSlipInputAcs->subSectionGuide(enterpriseCodeResult, paraSalesSlip);

            //.NET�N���X���\���̕ϊ�
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�]�ƈ��K�C�h����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_employeeGuide(
    BSTR sender, 
    BSTR enterpriseCode, 
	BSTR salesInputNm, 
    BSTR salesInputCode, 
    StructSalesSlip &salesSlip,
	bool &isReInputErr
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ senderResult = gcnew String(sender);
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
			String^ salesInputNmResult = gcnew String(salesInputNm);
            String^ salesInputCodeResult = gcnew String(salesInputCode);

            SalesSlip^ paraSalesSlip;
			bool paraIsReInputErr = isReInputErr;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            delphiSalesSlipInputAcs->employeeGuide(senderResult, enterpriseCodeResult, salesInputNmResult, salesInputCodeResult, paraSalesSlip, paraIsReInputErr);

            //.NET�N���X���\���̕ϊ�
            sender = static_cast<BSTR>(Marshal::StringToBSTR(senderResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
			isReInputErr = paraIsReInputErr;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ǘ��ԍ��K�C�h����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_carMngNoGuide(
    int customerCode, 
    BSTR enterpriseCode, 
    StructCarMangInputExtraInfo &selectedInfo,
	int &resultStatus,
	int salesRowNo,
	BSTR carMngCode
	
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int customerCodeResult = customerCode;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            CarMangInputExtraInfo^ paraSelectedInfo;
			int paraResultStatus;
			// --- UPD 2014/06/02 T.Miyamoto �V�X�e���e�X�g��Q��87 ------------------------------>>>>>
			//int paraSalesRowNo;
			int paraSalesRowNo = salesRowNo;
			// --- UPD 2014/06/02 T.Miyamoto �V�X�e���e�X�g��Q��87 ------------------------------<<<<<
			String^ carMngCodeResult = gcnew String(carMngCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            delphiSalesSlipInputAcs->carMngNoGuide(customerCodeResult, enterpriseCodeResult, paraSelectedInfo, paraResultStatus, paraSalesRowNo, carMngCodeResult);

            //.NET�N���X���\���̕ϊ�
            customerCode = customerCodeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSelectedInfo != nullptr){
                CopyClassToStruct_CarMangInputExtraInfo(paraSelectedInfo, &selectedInfo);
            }
            resultStatus = paraResultStatus;
			carMngCode = static_cast<BSTR>(Marshal::StringToBSTR(carMngCodeResult).ToPointer());
			salesRowNo = paraSalesRowNo;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//�Ԏ�K�C�h����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_modelFullGuide(
	int makerCode,
    int modelCode, 
    int modelSubCode, 
    BSTR enterpriseCode,
    int salesRowNo, 
    StructModelNameU &modelNameU
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

        DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
			int makerCodeResult = makerCode;
            int modelCodeResult = modelCode;
            int modelSubCodeResult = modelSubCode;
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            int salesRowNoResult = salesRowNo;
            Broadleaf::Application::UIData::ModelNameU^ paraModelNameU;


            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = delphiSalesSlipInputAcs->modelFullGuide(makerCodeResult, modelCodeResult, modelSubCodeResult, enterpriseCodeResult, salesRowNoResult, paraModelNameU);

            //.NET�N���X���\���̕ϊ�
			makerCode = makerCodeResult;
            modelCode = modelCodeResult;
            modelSubCode = modelSubCodeResult;
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            salesRowNo = salesRowNoResult;
            if(paraModelNameU != nullptr){
                CopyClassToStruct_ModelNameU(paraModelNameU, &modelNameU);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���l�K�C�h�{�{�^������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_slipNote(
    BSTR sender, 
    BSTR enterpriseCode, 
    StructSalesSlip &salesSlip
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;

		DelphiSalesSlipInputAcs^ delphiSalesSlipInputAcs = DelphiSalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ senderResult = gcnew String(sender);
            String^ enterpriseCodeResult = gcnew String(enterpriseCode);
            SalesSlip^ paraSalesSlip;


            //�A�N�Z�X�N���X���\�b�h�ďo��
			// --- UPD 2010/07/12 ---------->>>>>
            //delphiSalesSlipInputAcs->slipNote(senderResult, enterpriseCodeResult, paraSalesSlip);
			status = delphiSalesSlipInputAcs->slipNote(senderResult, enterpriseCodeResult, paraSalesSlip);
			// --- UPD 2010/07/12 ----------<<<<<

            //.NET�N���X���\���̕ϊ�
            sender = static_cast<BSTR>(Marshal::StringToBSTR(senderResult).ToPointer());
            enterpriseCode = static_cast<BSTR>(Marshal::StringToBSTR(enterpriseCodeResult).ToPointer());
            if(paraSalesSlip != nullptr){
                CopyClassToStruct_SalesSlip(paraSalesSlip, &salesSlip);
            }
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

//���Z�菈��
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetRate(
    double numerator, 
    double denominator, 
    double &rate
    ){
		int status = (int)ConstantManagement::DB_Status::ctDB_NORMAL;
        rate = 0;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            double numeratorResult = numerator;
            double denominatorResult = denominator;
            double rateResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetRate(numeratorResult, denominatorResult, rateResult);

            //.NET�N���X���\���̕ϊ�
            numerator = numeratorResult;
            denominator = denominatorResult;
            rate = rateResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }

// --- ADD 2010/05/31 ---------->>>>>
//������z�v�Z����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CalculationSalesPrice(

    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->CalculationSalesPrice();

            //.NET�N���X���\���̕ϊ�
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// --- ADD 2010/05/31 ----------<<<<<

// add by gaofeng end

// add by Yangmj start
//�c�[���`�b�v��������
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CreateStockCountInfoString(
    int salesRowNo,
	BSTR &StockCountInfo
    ){
		int status = 0;
        BSTR str;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int salesRowNoResult = salesRowNo;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            StockCountInfo = static_cast<BSTR>(Marshal::StringToBSTR(salesSlipInputAcs->CreateStockCountInfoString(salesRowNoResult)).ToPointer());

            //.NET�N���X���\���̕ϊ�
            salesRowNo = salesRowNoResult;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// add by Yangmj end

// add by Tanhong start

// add by Tanhong end

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
__declspec(dllexport) int __stdcall SalesSlipInputAcs_CopyToRC(
    int salesRowNo
    ){

		int status = 0;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            int    salesRowNoResult = salesRowNo   ;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->CopyToRC(salesRowNoResult);

            salesRowNo = salesRowNoResult ;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeColorInfo(StructColorInfo *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeColorInfo(deleteStructList, deleteStructListCount);
}

__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeTrimInfo(StructTrimInfo *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeTrimInfo(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCEqpDefDspInfo(StructCEqpDefDspInfo *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCEqpDefDspInfo(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarSpecInfo(StructCarSpecInfo *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCarSpecInfo(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarInfo(StructCarInfo *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCarInfo(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarModel(StructCarModel *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCarModel(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeEngineModel(StructEngineModel *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeEngineModel(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarSearchCondition(StructCarSearchCondition *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCarSearchCondition(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB4(StructCustomArrayB4 *deleteStructList, int deleteStructListCount){
    //�������b�h�Ăяo��
    FreeCustomArrayB4(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB3(StructCustomArrayB3 *deleteStructList, int deleteStructListCount){
    //�������b�h�Ăяo��
    FreeCustomArrayB3(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB2(StructCustomArrayB2 *deleteStructList, int deleteStructListCount){
    //�������b�h�Ăяo��
    FreeCustomArrayB2(deleteStructList, deleteStructListCount);
}

////��������
//__declspec(dllexport) void __stdcall ShowUAcs_FreeMessage(BSTR message){
//	//�����������\�b�h�Ăяo��
//	FreeMessage(message);
//}

__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeMessage(BSTR message){
	//�����������\�b�h�Ăяo��
	FreeMessage(message);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayA2(StructCustomArrayA2 *deleteStructList, int deleteStructListCount){
    //�������b�h�Ăяo��
    FreeCustomArrayA2(deleteStructList, deleteStructListCount);
}

// add by gaofeng start

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCarMangInputExtraInfo(StructCarMangInputExtraInfo *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeCarMangInputExtraInfo(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeModelNameU(StructModelNameU *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeModelNameU(deleteStructList, deleteStructListCount);
}
// add by gaofeng end

// add by Zhangkai start
//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeSalesDetail(StructSalesDetail *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeSalesDetail(deleteStructList, deleteStructListCount);
}

// add by gaofeng start
//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeSalesSlip(StructSalesSlip *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeSalesSlip(deleteStructList, deleteStructListCount);
}

// add by gaofeng end

// add by Zhangkai end

// add by Lizc start
//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeHeaderFocusConstruction(StructHeaderFocusConstruction *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeHeaderFocusConstruction(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeFooterFocusConstruction(StructFooterFocusConstruction *deleteStructList, int deleteStructListCount){
    //������\�b�h�Ăяo��
    FreeFooterFocusConstruction(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB6(StructCustomArrayB6 *deleteStructList, int deleteStructListCount){
    //�������b�h�Ăяo��
    FreeCustomArrayB6(deleteStructList, deleteStructListCount);
}

//���������
__declspec(dllexport) void __stdcall SalesSlipInputAcs_FreeCustomArrayB5(StructCustomArrayB5 *deleteStructList, int deleteStructListCount){
    //�������b�h�Ăяo��
    FreeCustomArrayB5(deleteStructList, deleteStructListCount);
}
// add by Lizc end

// add by Yangmj start

// add by Yangmj end

// add by Tanhong start

// add by Tanhong end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//**************************************************
// ���[���f�t�H���g�f�[�^�쐬
//**************************************************
__declspec(dllexport) void __stdcall SalesSlipInputAcs_MakeMailDefaultData(
    BSTR &fileName 
    ){
        fileName = NULL;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
			String^ fileNameResult;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->MakeMailDefaultData(fileNameResult);

            //.NET�N���X���\���̕ϊ�
			fileName = static_cast<BSTR>(Marshal::StringToBSTR(fileNameResult).ToPointer());
		}
        catch(Exception ^ex){
        }

    }
// --- ADD m.suzuki 2010/06/12 ----------<<<<<

// ADD 2012/02/09 ����� Redmine#28289 --- >>>>>
//������t���O�̎捞����
__declspec(dllexport) int __stdcall SalesSlipInputAcs_GetPrintThreadOverFlag(
    bool &printThreadOverFlag
    ){
        int status = (int)ConstantManagement::DB_Status::ctDB_ERROR;

		SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            bool paraPrintThreadOverFlag;

            //�A�N�Z�X�N���X���\�b�h�ďo��
            salesSlipInputAcs->GetPrintThreadOverFlag(paraPrintThreadOverFlag);

            //.NET�N���X���\���̕ϊ�

			printThreadOverFlag = paraPrintThreadOverFlag;
        }
        catch(Exception ^ex){
            status = -1;
        }

        return status;
    }
// ADD 2012/02/09 ����� Redmine#28289 --- <<<<

// --- ADD 2013/03/21 ---------->>>>>
//�n���h���ʒu�`�F�b�N����
__declspec(dllexport) bool __stdcall SalesSlipInputAcs_CheckHandlePosition(
    BSTR carRelationGuid, 
    BSTR vinCode
    ){
        // �f�t�H���g��true��Ԃ�
        bool status = true;

        SalesSlipInputAcs^ salesSlipInputAcs = SalesSlipInputAcs::GetInstance();

        try{
            //�\���́�.NET�N���X�֕ϊ�
            String^ carRelationGuidResult = gcnew String(carRelationGuid);
            String^ vinCodeResult = gcnew String(vinCode);

            //�A�N�Z�X�N���X���\�b�h�ďo��
            status = salesSlipInputAcs->CheckHandlePosition(carRelationGuidResult, vinCodeResult);

            //.NET�N���X���\���̕ϊ�
            carRelationGuid = static_cast<BSTR>(Marshal::StringToBSTR(carRelationGuidResult).ToPointer());
            vinCode = static_cast<BSTR>(Marshal::StringToBSTR(vinCodeResult).ToPointer());
        }
        catch(Exception ^ex){
            //status = true;
        }

        return status;
    }
// --- ADD 2013/03/21 ----------<<<<<
