/*******************************************************************************
  * Copyright (C) 2015-2016 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-2016 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *******************************************************************************/

namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public enum DefinedTypeInstanceList
    {
        dti1InchAway = 5041,

        dti2InchAway = 5042,

        dtiAerial = 5043,

        dtiBanding = 5044,

        dtiChemigation = 5045,

        dtiInFurrow = 5001,

        dtiInjected = 5047,

        dtiSurface = 5039,

        dtiTBand = 5049,

        dtiBackpackSpray = 5050,

        dtiBand = 5051,

        dtiHoodedSprayer = 5052,

        dtiImpregnate = 5053,

        dtiPlanter = 5054,

        dtiPostDirSpray = 5055,

        dtiRopeWick = 5056,

        dtiSideDress = 5057,

        dtiBroadcast = 5040,

        dtiMisApplication = 5059,

        dtiCoApplication = 5060,

        dtiAirBlast = 5061,

        dtiElectroStatic = 5062,

        dtiGround = 5063,

        dtiFertigation = 5064,

        dtiRecordingStatusOn = 5003,

        dtiRecordingStatusOff = 5004,

        dtiWindDirectionN = 5005,

        dtiWindDirectionS = 5006,

        dtiWindDirectionE = 5007,

        dtiWindDirectionW = 5008,

        dtiWindDirectionNE = 5009,

        dtiWindDirectionSE = 5010,

        dtiWindDirectionSW = 5011,

        dtiWindDirectionNW = 5012,

        dtiABLineMethodBPoint = 5014,

        dtiABLineMethodHeading = 5015,

        dtiABLineMethodManualEntry = 5016,

        dtiABLineMethodAutomaticB = 5017,

        dtiABLineMethodLatLonHeading = 5088,

        dtiSunny = 5019,

        dtiCloudy = 5020,

        dtiPartlyCloudy = 5021,

        dtiRain = 5022,

        dtiSnow = 5023,

        dtiClear = 5024,

        dtiInlineFront = 5025,

        dtiInlineCenter = 5026,

        dtiInlineRear = 5027,

        dtiLateralLeft = 5028,

        dtiLateralCenter = 5029,

        dtiLateralRight = 5030,

        dtiThreePoint = 5031,

        dtiRearTwoPoint = 5146,

        dtiDrawbar = 5032,

        dtiRearPivotWagonHitch = 5147,

        dtiFrontRigidThreePoint = 5148,

        dtiCloddy = 5033,

        dtiDry = 5034,

        dtiFrozen = 5035,

        dtiIdeal = 5036,

        dtiMuddy = 5037,

        dtiWet = 5038,

        dtiBroadcastSeeding = 5065,

        dtiInGround = 5066,

        dtiTillage = 5070,

        dtiHarvest = 5071,

        dtiSeeding = 5072,

        dtiApplication = 5073,

        dtiOther = 5074,

        dtiSurfaceWaterManagement = 5152,

        dtiSensorOn = 5067,

        dtiFail = 5068,

        dtiSensorOff = 5069,

        dtiPrescriptionUsed = 5075,

        dtiPrescriptionNotUsed = 5076,

        dtiPrescriptionOverridden = 5077,

        dtiLoadField = 5078,

        dtiLoadTruck = 5079,

        dtiLoadTank = 5080,

        dtiCottonLoadField = 5082,

        dtiCottonLoadModule = 5083,

        dtiCottonLoadBasket = 5084,

        dtiCottonLoadRoundModule = 5085,

        dtiCircleMethodDriving = 5086,

        dtiCircleMethodLatLong = 5087,

        dtiMaterialClassDry = 5089,

        dtiMaterialClassLiquid = 5090,

        dtiFunctionModifyGroundSpeed = 5091,

        dtiFunctionAdjustHitch = 5092,

        dtiFunctionAdjustFrontHitch = 5195,

        dtiFunctionChangePTO = 5093,

        dtiFunctionChangeDiffLock = 5094,

        dtiFunctionChange4WD = 5095,

        dtiFunctionChangeSCV1 = 5096,

        dtiFunctionChangeSCV2 = 5097,

        dtiFunctionChangeSCV3 = 5098,

        dtiFunctionChangeSCV4 = 5099,

        dtiFunctionChangeSCV5 = 5100,

        dtiFunctionChangeSCV6 = 5101,

        dtiFunctionChangeSCV7 = 5179,

        dtiFunctionChangeSCV11 = 5180,

        dtiFunctionChangeSCV12 = 5181,

        dtiFunctionChangeSCV13 = 5182,

        dtiFunctionChangeSCV14 = 5193,

        dtiFunctionChangeSCV15 = 5194,

        dtiFunctionModifyFieldCruise = 5183,

        dtiFunctionChangeAccuDepth1 = 5132,

        dtiFunctionChangeAccuDepth2 = 5133,

        dtiFunctionChangeAccuDepth3 = 5134,

        dtiFunctionChangeAccuDepth4 = 5135,

        dtiFunctionChangeAccuDepth5 = 5136,

        dtiFunctionChangeAccuDepth6 = 5137,

        dtiFunctionChangeAPS = 5138,

        dtiFunctionChangeGear = 5149,

        dtiFunctionChangeFrontPTO = 5157,

        dtiFunctionLowerHitch = 5102,

        dtiFunctionRaiseHitch = 5103,

        dtiFunctionEngagePTO = 5104,

        dtiFunctionDisengagePTO = 5105,

        dtiFunctionEngageDiffLock = 5106,

        dtiFunctionDisengageDiffLock = 5107,

        dtiFunctionEngage4WD = 5108,

        dtiFunctionDisengage4WD = 5109,

        dtiFunctionManualEngage4WD = 5161,

        dtiFunctionSCVExtend = 5110,

        dtiFunctionSCVRetract = 5111,

        dtiFunctionSCVFloat = 5112,

        dtiFunctionSCVCancel = 5113,

        dtiFunctionEngageFieldCruise = 5184,

        dtiFunctionDisengageFieldCruise = 5185,

        dtiStraightLineProjection = 5114,

        dtiAutogeneratedTurns = 5115,

        dtiFollowRecordedPath = 5116,

        dtiAlternateRows = 5117,

        dtiSkip1AndFill = 5118,

        dtiAutomaticSkipPattern = 5119,

        dtiCoverageMinimizeOverlap = 5121,

        dtiCoverageMinimizeSkips = 5122,

        dtiSignalTypeUnknown = 5123,

        dtiSignalTypeDigitized = 5124,

        dtiSignalTypeNoDiff = 5125,

        dtiSignalTypeUnknownDiff = 5126,

        dtiSignalTypeWAAS = 5127,

        dtiSignalTypeSF1 = 5128,

        dtiSignalTypeSF2 = 5129,

        dtiSignalTypeRTKX = 5130,

        dtiSignalTypeRTK = 5131,

        dtiSignalTypeSF3 = 6035,

        dtiFunctionEngage = 5139,

        dtiVehicleGPS = 5140,

        dtiComputedImplement = 5141,

        dtiImplementGPS = 5142,

        dtiFrontAxle = 5143,

        dtiRearAxle = 5144,

        dtiSPFHLoadField = 5150,

        dtiSPFHLoadTruck = 5151,

        dtiSWMDitches = 5153,

        dtiSWMLevees = 5154,

        dtiFunctionEngageFrontPTO = 5155,

        dtiFunctionDisengageFrontPTO = 5156,

        dtiDrainTypeUnknown = 5158,

        dtiDrainTypeLinear = 5159,

        dtiDrainTypeBestFit = 5160,

        dtiHeaderStatusOn = 5162,

        dtiHeaderStatusOff = 5163,

        dtiNew = 5165,

        dtiModified = 5166,

        dtiDeleted = 5167,

        dtiBufferZone = 5168,

        dtiWaitingTime = 5169,

        dtiProductContent = 5170,

        dtiActiveIngredient = 5171,

        dtiProductLimitIndication = 5172,

        dtiThousandCropWeight = 5173,

        dtiPrimingInformation = 5174,

        dtiGerminationRate = 5175,

        dtiGmoInformation = 5176,

        dtiLoad = 5177,

        dtiUnload = 5178,

        dtiWeightStable = 5186,

        dtiWeightUnStable = 5187,

        dtiWeightError = 5188,

        dtiProjectionDeere = 5189,

        dtiNonJohnDeere1 = 5190,

        dtiNonJohnDeere2 = 5191,

        dtiNonJohnDeere3 = 5192,

        dtiTillageTypeDisk = 5196,

        dtiTillageTypeRipper = 5197,

        dtiTillageTypeClosingDisk = 5198,

        dtiTillageTypeShank = 5199,

        dtiTillageTypeOpener = 5200,

        dtiTillageTypeBasket = 5201,

        dtiTillageTypeCoulter = 5202,

        dtiTillageTypeHarrow = 5203,

        dtiTillageTypeRoller = 5204,

        dtiUnloadingAugerStateDisabled = 6000,

        dtiUnloadingAugerStateEnabled = 6001,

        dtiUnloadingAugerStateError = 6002,

        dtiUnloadingAugerStateNotAvailable = 6003,

        dtiReady = 6004,

        dtiIBSDisabled = 6005,

        dtiManualDisabled = 6006,

        dtiMasterDisabled = 6007,

        dtiSCMasterManualOff = 6008,

        dtiSCMasterAutoOn = 6009,

        dtiSCMasterError = 6010,

        dtiSCMasterUndefined = 6011,

        dtiSysemIdle = 6012,

        dtiSpraySystemRinse = 6013,

        dtiSolutionPumpCal = 6014,

        dtiFlowMeterCal = 6015,

        dtiPressureSensorCal = 6016,

        dtiRemoteLoading = 6017,

        dtiNozzleFlowCheck = 6018,

        dtiEductorInUse = 6019,

        dtiBoomPressureRelief = 6020,

        dtiLoadCommandInUse = 6021,

        dtiDirectInjectionDisable = 6022,

        dtiInjectionPrime = 6023,

        dtiBoomPrime = 6024,

        dtiMinSprayPressure = 6025,

        dtiTargetPressure = 6026,

        dtiTargetApplRate = 6027,

        dtiPrescription = 6028,

        dtiError = 6029,

        dtiNotAvailable = 6030,

        dtiPrscMasterManualOff = 6031,

        dtiPrscMasterAutoOn = 6032,

        dtiPrscMasterError = 6033,

        dtiPrscMasterUndefined = 6034,

        dtiCaneHarvester = 6036,

        dtiCombine = 6037,

        dtiCottonPicker = 6038,

        dtiCottonStripper = 6039,

        dtiForageHarvester = 6040,

        dtiIrrigationSystem = 6041,

        dtiLifter = 6042,

        dtiMachineTypeOther = 6043,

        dtiPickupTruck = 6044,

        dtiSprayer = 6045,

        dtiTractor = 6046,

        dtiTreeShaker = 6047,

        dtiUtilityVehicle = 6048,

        dtiWindrower = 6049,

        dtiImpTillage = 6050,

        dtiSecondaryTillage = 6051,

        dtiSeedersPlanter = 6052,

        dtiFertilizer = 6053,

        dtiImpSprayer = 6054,

        dtiHarvester = 6055,

        dtiRootHarvester = 6056,

        dtiForage = 6057,

        dtiIrrigation = 6058,

        dtiTransportTrailers = 6059,

        dtiFarmsteadOperations = 6060,

        dtiPoweredAuxiliaryDevices = 6061,

        dtiSpecialCrop = 6062,

        dtiEarthworks = 6063,

        dtiSkidders = 6064,

        dtiSensorSystems = 6065,

        dtiSlurryApplicators = 6066,

        dtiImpPlanter = 6067,

        dtiSeeder = 6068,

        dtiPullBehindSprayer = 6069,

        dtiLiquidFertTool = 6070,

        dtiNH3Tool = 6071,

        dtiGrainDrill = 6072,

        dtiDrySpreader = 6073,

        dtiBeltPickup = 6074,

        dtiDraper = 6075,

        dtiPlatform = 6076,

        dtiCornHead = 6077,

        dtiRowCropHead = 6078,

        dtiRowUnits = 6079,

        dtiRowDependent = 6080,

        dtiRowIndependent = 6081,

        dtiBoom = 6082,

        dtiImplementTypeOther = 6083,

        dtiRotaryDitcher = 6084,

        dtiScraper = 6085,

        dtiPickup = 6086,

        dtiAirCart = 6087,

        dtiCart = 6088,

        dtiChoppingCornHead = 6089,

        dtiRigidPlatform = 6090,

        dtiFlexibleDraper = 6091,

        dtiFlexPlatform = 6092,

        dtiHydraflexPlatform = 6093,

        dtiUnknownHead = 6094,

        dtiBaler = 6095,

        dtiImpCottonStripper = 6096,

        dtiImpCaneHarvester = 6097,

        dtiImpCottonPicker = 6098,

        dtiRotary = 6099,

    }
}