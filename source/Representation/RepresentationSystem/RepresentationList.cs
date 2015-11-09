/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
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
    public enum RepresentationList 
    {
        dtApplicationMethod = 1001,

        dtRecordingStatus = 1003,

        dtWindDirection = 1004,

        dtABLineSaveMethod = 1005,

        dtSkyCondition = 1006,

        dtInlineOffsetType = 1007,

        dtLateralOffsetType = 1008,

        dtHitchType = 1009,

        dtSoilMoisture = 1010,

        dtSeedingApplicationMethod = 1011,

        dtOperationClass = 1012,

        dtSensorStatus = 1013,

        dtPrescriptionState = 1014,

        dtLoadType = 1015,

        dtCottonLoadType = 1016,

        dtCircleSaveMethod = 1017,

        dtMaterialClass = 1018,

        dtFunctionType = 1019,

        dtFunctionHitchChange = 1020,

        dtFunctionPTOChange = 1021,

        dtFunctionDiffLocChange = 1022,

        dtFunction4WDChange = 1023,

        dtFunctionSCVChange = 1024,

        dtFunctionFieldCruiseChange = 1041,

        dtGuidanceBoundaryBehavior = 1025,

        dtSkipPattern = 1026,

        dtCoverageSetting = 1027,

        dtSignalType = 1028,

        dtFunctionAPSChange = 1029,

        dtNavigationType = 1030,

        dtNonSteeringAxleLocation = 1031,

        dtSPFHLoadType = 1032,

        dtSurfaceWaterManagementOpType = 1033,

        dtFunctionFrontPTOChange = 1034,

        dtDrainType = 1035,

        dtHeaderStatus = 1036,

        dtTicketStatus = 1037,

        dtProductDetailsProductType = 1038,

        dtProductDetailsSeedType = 1039,

        dtTicketType = 1040,

        dtMeasuredWeightStatus = 1042,

        dtProjectionType = 1043,

        dtTillageType = 1044,

        dtUnloadingAugerState = 1500,

        dtJDArmedDWS = 1501,

        dtSectionControlMasterState = 1502,

        dtSprayerSystemOperatingMode = 1503,

        dtPrescriptionControlMasterState = 1504,

        vrABRowSpacing = 1,

        vrABShiftTrack = 2,

        vrABLineHeading = 3,

        vrCommodityPricePerBale = 4,

        vrCommodityPricePerVolume = 5,

        vrHarvestMoisture = 6,

        vrCropWeightBale = 7,

        vrCropWeightVolume = 8,

        vrFSAArea = 9,

        vrReportedFieldArea = 10,

        vrSpatialFieldArea = 11,

        vrYieldTotalMass = 12,

        vrYieldTotalVolume = 13,

        vrHeadlandOffset = 14,

        vrLatency = 15,

        vrLoadArea = 16,

        vrMassPer1000Seeds = 17,

        vrMassPerContainer = 18,

        vrMaturity = 19,

        vrEquipmentWidth = 20,

        vrTrackSpacing = 21,

        vrPathOverlap = 22,

        vrInlineOffset = 23,

        vrLateralOffset = 24,

        vrTotalInlineDistance = 280,

        vrTotalLateralDistance = 281,

        vrVerticalOffset = 25,

        vrSectionWidth = 26,

        vrSeedGerminationPercent = 27,

        vrSeedLoadQuantity = 28,

        vrSeedsPerContainer = 29,

        vrSeedsPerMass = 30,

        vrSolutionRateLiquid = 31,

        vrSolutionRateMass = 32,

        vrSwathWidth = 33,

        vrYieldBale = 34,

        vrYieldBalePerArea = 35,

        vrYieldWetMass = 36,

        vrYieldWetMassPerArea = 37,

        vrYieldWetVolume = 38,

        vrYieldWetVolumePerArea = 39,

        vrYieldMass = 40,

        vrYieldMassPerArea = 41,

        vrYieldVolume = 42,

        vrYieldVolumePerArea = 43,

        vrAppRateMassMetered = 44,

        vrAppRateMassMeasured = 45,

        vrAppRateMassControl = 46,

        vrAppRateMassTarget = 47,

        vrAppRateVolumeMetered = 48,

        vrAppRateVolumeMeasured = 49,

        vrAppRateVolumeControl = 50,

        vrAppRateVolumeTarget = 51,

        vrAppRateVolumePerHour = 600,

        vrAppHeightTarget = 52,

        vrTillageDepthTarget = 53,

        vrSeedRateMassMetered = 54,

        vrSeedRateMassMeasured = 55,

        vrSeedRateMassControl = 56,

        vrSeedRateMassTarget = 57,

        vrSeedRateSeedsMetered = 58,

        vrSeedRateSeedsMeasured = 59,

        vrSeedRateSeedsControl = 60,

        vrSeedRateSeedsTarget = 61,

        vrSeedDepthTarget = 62,

        vrRelativeHumidity = 63,

        vrAirTemperature = 64,

        vrWindSpeed = 65,

        vrSoilTemperature = 66,

        vrTotalAreaCovered = 67,

        vrTotalQuantityAppliedMass = 68,

        vrTotalQuantityAppliedVolume = 69,

        vrTotalSeedQuantityAppliedSeed = 70,

        vrTotalSeedQuantityAppliedMass = 71,

        vrTotalOperationTime = 72,

        vrHeading = 73,

        vrElevation = 74,

        vrStandardPayableMoisture = 75,

        vrLatitude = 76,

        vrLongitude = 77,

        vrDistanceTraveled = 78,

        vrNonLogTime = 80,

        vrVehicleSpeed = 81,

        vrDeltaTime = 82,

        vrEquipmentLogFrequency = 84,

        vrCommodityPricePerArea = 85,

        vrCommodityPricePerYield = 86,

        vrCommodityPricePerContainer = 87,

        vrRowWidth = 88,

        vrGuidanceSmallShift = 89,

        vrGuidanceLargeShift = 90,

        vrPathAccuracyIndicator = 91,

        vrTrackToneBeginningDistance = 92,

        vrLeadCompensation = 93,

        vrAccuracyBarStepSize = 94,

        vrTurnDistance = 95,

        vrTrackSpacingRows = 96,

        vrEquipmentWidthRows = 97,

        vrPathOverlapRows = 98,

        vrFuelRatePerHour = 99,

        vrFuelTotal = 100,

        vrTotalYieldVolume = 101,

        vrTotalYieldMass = 102,

        vrTotalYieldWetMass = 103,

        vrTotalYieldWetVolume = 104,

        vrTotalYieldBale = 105,

        vrHarvestMinimumMoisture = 106,

        vrHarvestMaximumMoisture = 107,

        vrYieldMassMinimum = 108,

        vrYieldMassMaximum = 109,

        vrYieldMassPerAreaMinimum = 110,

        vrYieldMassPerAreaMaximum = 111,

        vrYieldVolumeMinimum = 112,

        vrYieldVolumeMaximum = 113,

        vrYieldVolumePerAreaMinimum = 114,

        vrYieldVolumePerAreaMaximum = 115,

        vrYieldBaleMinimum = 116,

        vrYieldBaleMaximum = 117,

        vrYieldBalePerAreaMinimum = 118,

        vrYieldWetMassMinimum = 119,

        vrYieldWetMassMaximum = 120,

        vrYieldWetMassPerAreaMinumum = 121,

        vrYieldWetMassPerAreaMaximum = 122,

        vrYieldWetVolumeMinimum = 123,

        vrYieldWetVolumeMaximum = 124,

        vrYieldWetVolumePerAreaMinimum = 125,

        vrYieldWetVolumePerAreaMaximum = 126,

        vrEastShiftComponent = 127,

        vrNorthShiftComponent = 128,

        vrTurnout = 129,

        vrTaskArea = 130,

        vrBoundaryOffset = 131,

        vrSpatialFieldPerimeter = 132,

        vrAreaProductivity = 133,

        vrMassProductivity = 134,

        vrVolumeProductivity = 135,

        vrBaleProductivity = 136,

        vrSeedsProductivity = 137,

        vrRadiusOffset = 138,

        vrRadialHeading = 139,

        vrRadiusShift = 140,

        vrRecordingTimeRemaining = 141,

        vrReceiverOffset = 142,

        vrManagementZoneClipping = 143,

        vrTrackRowWidth = 144,

        vrInoculantDosing = 145,

        vrLengthOfCut = 146,

        vrHeadland = 147,

        vrGenericZoneValue = 148,

        vrHarvestMoistureTotal = 149,

        vrHarvestMoistureCount = 150,

        vrCutWidthIncrement = 151,

        vrCutWidthIncrementRows = 152,

        vrBoundaryIntersectionDistance = 153,

        vrSequenceActivationDistance = 155,

        vrSequenceActivationTime = 156,

        vrSequenceOffsetDistance = 157,

        vrFunctionOffsetDistance = 158,

        vrFunctionValueSpeed = 159,

        vrFunctionValueEngineSpeed = 276,

        vrMachineTurnRadius = 160,

        vrImplementTurnRadius = 161,

        vrInteriorHeadlandOffset = 162,

        vrPhysicalImplementWidth = 163,

        vrImplementLength = 164,

        vrImplementFrontOffset = 165,

        vrGPSToNonSteeringAxleOffset = 166,

        vrNonSteeringAxleToConnectionOffset = 167,

        vrLateralControlPointToConnectionOffset = 168,

        vrInlineControlPointToConnectionOffset = 169,

        vrInRowSteerLimitation = 170,

        vrSlopeCompensation = 171,

        vrInlineConnectionPointToReceiverOffset = 172,

        vrLateralConnectionPointToReceiverOffset = 173,

        vrImplementReceiverHeight = 174,

        vrStarfireHeight = 175,

        vrStarfireForeAft = 176,

        vrBoundaryDistance = 177,

        vrFeelerHoldOffTime = 178,

        vrRowSensorOffset = 179,

        vrMapDistance = 180,

        vrYieldTotalMassForage = 181,

        vrYieldWetMassFrgPerArea = 182,

        vrYieldMassFrgPerArea = 183,

        vrModuleDiameter = 184,

        vrModuleWeight = 185,

        vrYieldMassForage = 186,

        vrSurveyTimeInterval = 187,

        vrSurveyDistanceInterval = 188,

        vrSurveyFrequencyInterval = 189,

        vrVDOP = 190,

        vrPitchAngle = 191,

        vrRollAngle = 192,

        vrEndTurnOffset = 193,

        vrLeveeDrop = 194,

        vrYieldWetMassForage = 195,

        vrYieldTotalWetMassForage = 196,

        vrYieldMassMinForage = 197,

        vrYieldMassMaxForage = 198,

        vrYieldMassPerAreaMinForage = 199,

        vrYieldMassPerAreaMaxForage = 200,

        vrYieldWetMassMinForage = 201,

        vrYieldWetMassMaxForage = 202,

        vrYieldWetMassPerAreaMinForage = 203,

        vrYieldWetMassPerAreaMaxForage = 204,

        vrInoculantDosingTotal = 205,

        vrForageMassProductivity = 206,

        vrGear = 207,

        vrVerticalAccuracyIndicator = 208,

        vrInlineRearConnectionPointToConnectionPointOffset = 209,

        vrLateralRearConnectionPointToConnectionPointOffset = 210,

        vrMachineVerticalReceiverOffset = 211,

        vrImplementVerticalReceiverToCuttingEdgeOffset = 212,

        vrImplementVerticalCuttingEdgeToGroundOffset = 213,

        vrVerticalProfileGridSize = 214,

        vrHorizontalProfileGridSize = 215,

        vrLinearFitDrainSlope = 216,

        vrMaxBestFitDrainCutDepth = 217,

        vrMinBestFitDrainCutDepth = 218,

        vrRoverDistance = 219,

        vrPositiveLeveeElevationOffset = 220,

        vrNegativeLeveeElevationOffset = 221,

        vrLeveeDial = 222,

        vrGPSAccuracy = 223,

        vrGPSVerticalAccuracy = 224,

        vrFlagArea = 225,

        vrNormalizedMapPercent = 226,

        vrRowFinderDisableTime = 227,

        vrSeedsPerBag = 228,

        vrSeedsPerSack = 229,

        vrCommodityPricePerBag = 230,

        vrMassPerBag = 231,

        vrMassPerSack = 232,

        vrSeedLoadQuantityContainer = 233,

        vrSeedLoadQuantitySack = 234,

        vrCutVolume = 235,

        vrMaxBestFitDrainSlope = 236,

        vrMinBestFitDrainSlope = 237,

        vrLinearFitDrainOffset = 238,

        vrFlagLength = 239,

        vrVerticalAccuracyBarStepSize = 240,

        vrRowGuidanceSensorOffset = 241,

        vrTankFillSessionArea = 242,

        vrTankVolume = 243,

        vrCargoWeightMass = 244,

        vrCargoWeightVolume = 245,

        vrTankVolumePercentage = 246,

        vrEngineHours = 247,

        vrFuelAmount = 248,

        vrBufferZone = 249,

        vrWaitingTime = 250,

        vrProductContent = 251,

        vrActiveIngredientMass = 252,

        vrActiveIngredientVolume = 253,

        vrProductLimitIndicationCount = 254,

        vrProductLimitIndicationPercent = 255,

        vrThousandCropWeight = 256,

        vrPrimingInfoVolPerMass = 257,

        vrPrimingInfoMassPerMass = 258,

        vrActiveIngredientVolPerVol = 259,

        vrGerminationRate = 260,

        vrProvidedAmountVolume = 261,

        vrProvidedAmountMass = 262,

        vrTimeUntilEmpty = 263,

        vrBatteryVoltage = 266,

        vrEngineCoolantTemperature = 267,

        vrEngineOilPressure = 268,

        vrHydraulicOilTemperature = 269,

        vrEngineSpeed = 271,

        vrAirBrakePressure = 272,

        vrAmbientAirTemperature = 273,

        vrLFLateralNudgeExtent = 277,

        vrLFInlineNudgeExtent = 278,

        vrTransportDistance = 279,

        vrIngredientDensity = 282,

        vrProvidedAmountTotalMass = 283,

        vrProvidedAmountTotalVolume = 284,

        vrActiveIngredientMassPerMass = 285,

        vrSeedSpacing = 286,

        vrDownForceMargin = 287,

        vrTransmissionOilTemperature = 288,

        vrPricePerContainer = 289,

        vrPricePerBushel = 290,

        vrPricePerBag = 291,

        vrPricePerSack = 292,

        vrPriceSolutionLiquid = 293,

        vrPriceSolutionDry = 294,

        vrPriceSolutionGas = 295,

        vrPricePerTime = 296,

        vrPricePerArea = 297,

        vrPricePerField = 298,

        vrPricePerBale = 299,

        vrPricePerMassCrop = 300,

        vrPricePerMassCotton = 301,

        vrMeasuredWeight = 302,

        vrBaleSize = 303,

        vrBaleTotal = 304,

        vrLookAheadTime = 305,

        vrTankNumber = 306,

        vrImplementInGroundTurnRadius = 307,

        vrDeltaT = 308,

        vrCountPerArea = 309,

        vrConstituentCrudeProtein = 310,

        vrConstituentStarch = 311,

        vrConstituentAcidDetergentFiber = 312,

        vrConstituentNeutralDetergentFiber = 313,

        vrConstituentSugar = 314,

        vrConstituentAsh = 315,

        vrConstituentCrudeFat = 316,

        vrConstituentCrudeFiber = 317,

        vrConstituentLignin = 318,

        vrConstituentLactic = 319,

        vrConstituentAcetic = 320,

        vrConstituentButyric = 321,

        vrConstituentAmmonia = 322,

        vrConstituentNonStructuralCarbohydrate = 323,

        vrConstituentProteinSolubility = 324,

        vrConstituentAdjustedCrudeProtein = 325,

        vrConstituentRumenUndegradableProtein = 326,

        vrConstituentNonProteinNitrogen = 327,

        vrConstituentTotalNitrogenKjeldahl = 328,

        vrConstituentNitrogenNitrate = 329,

        vrConstituentNitrogenAmmonium = 330,

        vrConstituentDigestibleFat = 331,

        vrConstituentNeutralDetergentFiberDigestibility = 332,

        vrConstituentCellulose = 333,

        vrConstituentHemicellulose = 334,

        vrConstituentTotalDigestibleNutrients = 335,

        vrConstituentNetEnergyForLactation = 336,

        vrConstituentNetEnergyForMaintenance = 337,

        vrConstituentNetEnergyForGain = 338,

        vrConstituentDigestibleEnergy = 339,

        vrConstituentMetabolizableEnergy = 340,

        vrConstituentOil = 341,

        vrConstituentSuspendedNitrogen = 342,

        vrConstituentTotalPhosphorus = 343,

        vrConstituentSuspendedPhosphorus = 344,

        vrConstituentPotassium = 345,

        vrConstituentSodium = 346,

        vrConstituentMagnesium = 347,

        vrConstituentCalcium = 348,

        vrConstituentSulphur = 349,

        vrConstituentMoistureReferenceA = 350,

        vrConstituentMoistureReferenceB = 351,

        vrConstituentMoistureReferenceC = 352,

        vrConstituentInvalid = 353,

        vrConstituentNitrogenAmmonia = 354,

        vrConstituentPhosphorusAllTypes = 355,

        vrInoculantDosingRateLow = 356,

        vrInoculantDosingRateLowTotal = 357,

        vrFuelVolumePerWetMass = 358,

        vrFuelVolumePerDryMass = 359,

        vrWetMassPerFuelVolume = 360,

        vrDryMassPerFuelVolume = 361,

        vrManureTotalSolids = 362,

        vrTillageDepthMeasured = 363,

        vrTillageDepthControl = 364,

        vrCircleEdgeRadius = 365,

        vrABCurveRadialShift = 366,

        vrABCurveRadialTotalShift = 367,

        vrTillagePressureTarget = 368,

        vrTillagePressureMeasured = 369,

        vrFuelProductivity = 370,

        vrGuidanceShift = 371,

        vrRemainingABLineDistance = 372,

        vrTrackSpacingGap = 374,

        vrSlowSpeed = 375,

        vrActualSeedSpacingCV = 376,

        vrPlantingSingulation = 377,

        vrPlantingSkips = 378,

        vrPlantingDoubles = 379,

        vrDownForceApplied = 380,

        vrGroundContact = 381,

        vrRideQuality = 382,

        vrTillagePressureControl = 383,

        vrSCTurnOnTime = 500,

        vrSCTurnOffTime = 501,

        vrAppliedYieldLatency = 503,

        vrAppliedMoistureLatency = 504,

        vrHeaderHours = 505,

        vrSeparatorHours = 506,

        vrDeltaDistance = 507,

        vrDeltaArea = 508,

        vrDeltaAppliedVolume = 509,

        vrHarvestWetMassFlow = 510,

        vrSolutionSystemFlowRatePerMinute = 511,

        vrSCTuningDistance = 512,

        vrSCTuningSpeed = 513,

        vrFanSpeedControl = 514,

        vrFanSpeedTarget = 515,

        vrFanSpeedMeasured = 516,

        vrThreshingSpeedControl = 517,

        vrThreshingSpeedTarget = 518,

        vrThreshingSpeedMeasured = 519,

        vrThreshingClearanceControl = 520,

        vrThreshingClearanceTarget = 521,

        vrThreshingClearanceMeasured = 522,

        vrChaferPositionControl = 523,

        vrChafferPositionTarget = 524,

        vrChafferPositionMeasured = 525,

        vrSievePositionControl = 526,

        vrSievePositionTarget = 527,

        vrSievePositionMeasured = 528,

        vrRipperDepthControl = 529,

        vrRipperDepthTarget = 530,

        vrRipperDepthMeasured = 531,

        vrOpeningDiscDepthControl = 532,

        vrOpeningDiscDepthTarget = 533,

        vrOpeningDiscDepthMeasured = 534,

        vrClosingDiscDepthControl = 535,

        vrClosingDiscDepthTarget = 536,

        vrClosingDiscDepthMeasured = 537,

        vrBasketPressureControl = 538,

        vrBasketPressureTarget = 539,

        vrBasketPressureMeasured = 540,

        vrPrescriptionRateMultiplier = 541,

        vrPrescriptionLookAheadTime = 542,

        vrYieldCalibration = 543,

        vrAvgYieldWetMassPerArea = 544,

        vrAvgYieldMassPerArea = 545,

        vrAvgHarvestMoisture = 546,

        vrPlantingSkipsCount = 547,

        vrPlantingDoublesCount = 548,

        vrDistanceFromTrack = 549,

        vrEngineLoadCurrentSpeed = 550,

        vrProductIndex = 551,

        vrDeltaAppRateMass = 552,

    }
}