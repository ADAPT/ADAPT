using AgGateway.ADAPT.ApplicationDataModel;namespace AgGateway.ADAPT.Representation.RepresentationSystem
{
    public enum RepresentationList 
    {
        DataDictionaryVersion = 0,

        SetpointVolumePerAreaApplicationRate = 1,

        ActualVolumePerAreaApplicationRate = 2,

        DefaultVolumePerAreaApplicationRate = 3,

        MinimumVolumePerAreaApplicationRate = 4,

        MaximumVolumePerAreaApplicationRate = 5,

        SetpointMassPerAreaApplicationRate = 6,

        ActualMassPerAreaApplicationRate = 7,

        DefaultMassPerAreaApplicationRate = 8,

        MinimumMassPerAreaApplicationRate = 9,

        MaximumMassPerAreaApplicationRate = 10,

        SetpointCountPerAreaApplicationRate = 11,

        ActualCountPerAreaApplicationRate = 12,

        DefaultCountPerAreaApplicationRate = 13,

        MinimumCountPerAreaApplicationRate = 14,

        MaximumCountPerAreaApplicationRate = 15,

        SetpointSpacingApplicationRate = 16,

        ActualSpacingApplicationRate = 17,

        DefaultSpacingApplicationRate = 18,

        MinimumSpacingApplicationRate = 19,

        MaximumSpacingApplicationRate = 20,

        SetpointVolumePerVolumeApplicationRate = 21,

        ActualVolumePerVolumeApplicationRate = 22,

        DefaultVolumePerVolumeApplicationRate = 23,

        MinimumVolumePerVolumeApplicationRate = 24,

        MaximumVolumePerVolumeApplicationRate = 25,

        SetpointMassPerMassApplicationRate = 26,

        ActualMassPerMassApplicationRate = 27,

        DefaultMassPerMassApplicationRate = 28,

        MinimumMassPerMassApplicationRate = 29,

        MaximumMassPerMassApplicationRate = 30,

        SetpointVolumePerMassApplicationRate = 31,

        ActualVolumePerMassApplicationRate = 32,

        DefaultVolumePerMassApplicationRate = 33,

        MinimumVolumePerMassApplicationRate = 34,

        MaximumVolumePerMassApplicationRate = 35,

        SetpointVolumePerTimeApplicationRate = 36,

        ActualVolumePerTimeApplicationRate = 37,

        DefaultVolumePerTimeApplicationRate = 38,

        MinimumVolumePerTimeApplicationRate = 39,

        MaximumVolumePerTimeApplicationRate = 40,

        SetpointMassPerTimeApplicationRate = 41,

        ActualMassPerTimeApplicationRate = 42,

        DefaultMassPerTimeApplicationRate = 43,

        MinimumMassPerTimeApplicationRate = 44,

        MaximumMassPerTimeApplicationRate = 45,

        SetpointCountPerTimeApplicationRate = 46,

        ActualCountPerTimeApplicationRate = 47,

        DefaultCountPerTimeApplicationRate = 48,

        MinimumCountPerTimeApplicationRate = 49,

        MaximumCountPerTimeApplicationRate = 50,

        SetpointTillageDepth = 51,

        ActualTillageDepth = 52,

        DefaultTillageDepth = 53,

        MinimumTillageDepth = 54,

        MaximumTillageDepth = 55,

        SetpointSeedingDepth = 56,

        ActualSeedingDepth = 57,

        DefaultSeedingDepth = 58,

        MinimumSeedingDepth = 59,

        MaximumSeedingDepth = 60,

        SetpointWorkingHeight = 61,

        ActualWorkingHeight = 62,

        DefaultWorkingHeight = 63,

        MinimumWorkingHeight = 64,

        MaximumWorkingHeight = 65,

        SetpointWorkingWidth = 66,

        ActualWorkingWidth = 67,

        DefaultWorkingWidth = 68,

        MinimumWorkingWidth = 69,

        MaximumWorkingWidth = 70,

        SetpointVolumeContent = 71,

        ActualVolumeContent = 72,

        MaximumVolumeContent = 73,

        SetpointMassContent = 74,

        ActualMassContent = 75,

        MaximumMassContent = 76,

        SetpointCountContent = 77,

        ActualCountContent = 78,

        MaximumCountContent = 79,

        ApplicationTotalVolumeinL = 80,

        ApplicationTotalMassinkg = 81,

        ApplicationTotalCount = 82,

        VolumePerAreaYield = 83,

        MassPerAreaYield = 84,

        CountPerAreaYield = 85,

        VolumePerTimeYield = 86,

        MassPerTimeYield = 87,

        CountPerTimeYield = 88,

        YieldTotalVolume = 89,

        YieldTotalMass = 90,

        YieldTotalCount = 91,

        VolumePerAreaCropLoss = 92,

        MassPerAreaCropLoss = 93,

        CountPerAreaCropLoss = 94,

        VolumePerTimeCropLoss = 95,

        MassPerTimeCropLoss = 96,

        CountPerTimeCropLoss = 97,

        PercentageCropLoss = 98,

        CropMoisture = 99,

        CropContamination = 100,

        SetpointBaleWidth = 101,

        ActualBaleWidth = 102,

        DefaultBaleWidth = 103,

        MinimumBaleWidth = 104,

        MaximumBaleWidth = 105,

        SetpointBaleHeight = 106,

        ActualBaleHeight = 107,

        DefaultBaleHeight = 108,

        MinimumBaleHeight = 109,

        MaximumBaleHeight = 110,

        SetpointBaleSize = 111,

        ActualBaleSize = 112,

        DefaultBaleSize = 113,

        MinimumBaleSize = 114,

        MaximumBaleSize = 115,

        TotalArea = 116,

        EffectiveTotalDistance = 117,

        IneffectiveTotalDistance = 118,

        EffectiveTotalTime = 119,

        IneffectiveTotalTime = 120,

        ProductDensityMassPerVolume = 121,

        ProductDensityMassPerCount = 122,

        ProductDensityVolumePerCount = 123,

        AuxiliaryValveScalingExtend = 124,

        AuxiliaryValveScalingRetract = 125,

        AuxiliaryValveRampExtendUp = 126,

        AuxiliaryValveRampExtendDown = 127,

        AuxiliaryValveRampRetractUp = 128,

        AuxiliaryValveRampRetractDown = 129,

        AuxiliaryValveFloatThreshold = 130,

        AuxiliaryValveProgressivityExtend = 131,

        AuxiliaryValveProgressivityRetract = 132,

        AuxiliaryValveInvertPorts = 133,

        DeviceElementOffsetX = 134,

        DeviceElementOffsetY = 135,

        DeviceElementOffsetZ = 136,

        DeviceVolumeCapacity = 137,

        DeviceMassCapacity = 138,

        DeviceCountCapacity = 139,

        SetpointPercentageApplicationRate = 140,

        ActualWorkState = 141,

        PhysicalSetpointTimeLatency = 142,

        PhysicalActualValueTimeLatency = 143,

        YawAngle = 144,

        RollAngle = 145,

        PitchAngle = 146,

        LogCount = 147,

        TotalFuelConsumption = 148,

        InstantaneousFuelConsumptionperTime = 149,

        InstantaneousFuelConsumptionperArea = 150,

        InstantaneousAreaPerTimeCapacity = 151,

        ActualNormalizedDifferenceVegetativeIndexNDVI = 153,

        PhysicalObjectLength = 154,

        PhysicalObjectWidth = 155,

        PhysicalObjectHeight = 156,

        ConnectorType = 157,

        PrescriptionControlState = 158,

        NumberofSubUnitsperSection = 159,

        SectionControlState = 160,

        ActualCondensedWorkState116 = 161,

        ActualCondensedWorkState1732 = 162,

        ActualCondensedWorkState3348 = 163,

        ActualCondensedWorkState4964 = 164,

        ActualCondensedWorkState6580 = 165,

        ActualCondensedWorkState8196 = 166,

        ActualCondensedWorkState97112 = 167,

        ActualCondensedWorkState113128 = 168,

        ActualCondensedWorkState129144 = 169,

        ActualCondensedWorkState145160 = 170,

        ActualCondensedWorkState161176 = 171,

        ActualCondensedWorkState177192 = 172,

        ActualCondensedWorkState193208 = 173,

        ActualCondensedWorkState209224 = 174,

        ActualCondensedWorkState225240 = 175,

        ActualCondensedWorkState241256 = 176,

        Actuallengthofcut = 177,

        ElementTypeInstance = 178,

        ActualCulturalPractice = 179,

        DeviceReferencePointDRPtoGrounddistance = 180,

        DryMassPerAreaYield = 181,

        DryMassPerTimeYield = 182,

        YieldTotalDryMass = 183,

        ReferenceMoistureForDryMass = 184,

        SeedCottonMassPerAreaYield = 185,

        LintCottonMassPerAreaYield = 186,

        SeedCottonMassPerTimeYield = 187,

        LintCottonMassPerTimeYield = 188,

        YieldTotalSeedCottonMass = 189,

        YieldTotalLintCottonMass = 190,

        LintTurnoutPercentage = 191,

        Ambienttemperature = 192,

        SetpointProductPressure = 193,

        ActualProductPressure = 194,

        MinimumProductPressure = 195,

        MaximumProductPressure = 196,

        SetpointPumpOutputPressure = 197,

        ActualPumpOutputPressure = 198,

        MinimumPumpOutputPressure = 199,

        MaximumPumpOutputPressure = 200,

        SetpointTankAgitationPressure = 201,

        ActualTankAgitationPressure = 202,

        MinimumTankAgitationPressure = 203,

        MaximumTankAgitationPressure = 204,

        SCTurnOnTime = 205,

        SCTurnOffTime = 206,

        Windspeed = 207,

        Winddirection = 208,

        AirHumidity = 209,

        Skyconditions = 210,

        LastBaleFlakesperBale = 211,

        LastBaleAverageMoisture = 212,

        LastBaleAverageStrokesperFlake = 213,

        LifetimeBaleCount = 214,

        LifetimeWorkingHours = 215,

        ActualBaleHydraulicPressure = 216,

        LastBaleAverageHydraulicPressure = 217,

        SetpointBaleCompressionPlungerLoad = 218,

        ActualBaleCompressionPlungerLoad = 219,

        LastBaleAverageBaleCompressionPlungerLoad = 220,

        LastBaleAppliedPreservative = 221,

        LastBaleTagNumber = 222,

        LastBaleMass = 223,

        DeltaT = 224,

        SetpointWorkingLength = 225,

        ActualWorkingLength = 226,

        MinimumWorkingLength = 227,

        MaximumWorkingLength = 228,

        ActualNetWeight = 229,

        NetWeightState = 230,

        SetpointNetWeight = 231,

        ActualGrossWeight = 232,

        GrossWeightState = 233,

        MinimumGrossWeight = 234,

        MaximumGrossWeight = 235,

        ThresherEngagementTotalTime = 236,

        ActualHeaderWorkingHeightStatus = 237,

        ActualHeaderRotationalSpeedStatus = 238,

        YieldHoldStatus = 239,

        ActualUnLoadingSystemStatus = 240,

        CropTemperature = 241,

        SetpointSieveClearance = 242,

        ActualSieveClearance = 243,

        MinimumSieveClearance = 244,

        MaximumSieveClearance = 245,

        SetpointChafferClearance = 246,

        ActualChafferClearance = 247,

        MinimumChafferClearance = 248,

        MaximumChafferClearance = 249,

        SetpointConcaveClearance = 250,

        ActualConcaveClearance = 251,

        MinimumConcaveClearance = 252,

        MaximumConcaveClearance = 253,

        SetpointSeparationFanRotationalSpeed = 254,

        ActualSeparationFanRotationalSpeed = 255,

        MinimumSeparationFanRotationalSpeed = 256,

        MaximumSeparationFanRotationalSpeed = 257,

        HydraulicOilTemperature = 258,

        YieldLagIgnoreTime = 259,

        YieldLeadIgnoreTime = 260,

        AverageYieldMassPerTime = 261,

        AverageCropMoisture = 262,

        AverageYieldMassPerArea = 263,

        ConnectorPivotXOffset = 264,

        RemainingArea = 265,

        LifetimeApplicationTotalMass = 266,

        LifetimeApplicationTotalCount = 267,

        LifetimeYieldTotalVolume = 268,

        LifetimeYieldTotalMass = 269,

        LifetimeYieldTotalCount = 270,

        LifetimeTotalArea = 271,

        LifetimeTotalDistance = 272,

        LifetimeIneffectiveTotalDistance = 273,

        LifetimeEffectiveTotalTime = 274,

        LifetimeIneffectiveTotalTime = 275,

        LifetimeFuelConsumption = 276,

        LifetimeAverageFuelConsumptionperTime = 277,

        LifetimeAverageFuelConsumptionperArea = 278,

        LifetimeYieldTotalDryMass = 279,

        LifetimeYieldTotalSeedCottonMass = 280,

        LifetimeYieldTotalLintCottonMass = 281,

        LifetimeThreshingEngagementTotalTime = 282,

        PrecutTotalCount = 283,

        UncutTotalCount = 284,

        LifetimePrecutTotalCount = 285,

        LifetimeUncutTotalCount = 286,

        SetpointPrescriptionMode = 287,

        ActualPrescriptionMode = 288,

        SetpointWorkState = 289,

        SetpointCondensedWorkState116 = 290,

        SetpointCondensedWorkState1732 = 291,

        SetpointCondensedWorkState3348 = 292,

        SetpointCondensedWorkState4964 = 293,

        SetpointCondensedWorkState6580 = 294,

        SetpointCondensedWorkState8196 = 295,

        SetpointCondensedWorkState97112 = 296,

        SetpointCondensedWorkState113128 = 297,

        SetpointCondensedWorkState129144 = 298,

        SetpointCondensedWorkState145160 = 299,

        SetpointCondensedWorkState161176 = 300,

        SetpointCondensedWorkState177192 = 301,

        SetpointCondensedWorkState193208 = 302,

        SetpointCondensedWorkState209224 = 303,

        SetpointCondensedWorkState225240 = 304,

        SetpointCondensedWorkState241256 = 305,

        TrueRotationPointXOffset = 306,

        TrueRotationPointYOffset = 307,

        ActualPercentageApplicationRate = 308,

        MinimumPercentageApplicationRate = 309,

        MaximumPercentageApplicationRate = 310,

        RelativeYieldPotential = 311,

        MinimumRelativeYieldPotential = 312,

        MaximumRelativeYieldPotential = 313,

        ActualPercentageCropDryMatter = 314,

        AveragePercentageCropDryMatter = 315,

        EffectiveTotalFuelConsumption = 316,

        IneffectiveTotalFuelConsumption = 317,

        EffectiveTotalDieselExhaustFluidConsumption = 318,

        IneffectiveTotalDieselExhaustFluidConsumption = 319,

        LastloadedWeight = 320,

        LastunloadedWeight = 321,

        LoadIdentificationNumber = 322,

        UnloadIdentificationNumber = 323,

        ChopperEngagementTotalTime = 324,

        LifetimeApplicationTotalVolume = 325,

        MinimumHeaderSpeed = 328,

        MaximumHeaderSpeed = 329,

        SetpointCuttingdrumspeed = 330,

        ActualCuttingdrumspeed = 331,

        MaximumCuttingdrumspeed = 333,

        OperatingHoursSinceLastSharpening = 334,

        FrontPTOhours = 335,

        RearPTOhours = 336,

        LifetimeFrontPTOhours = 337,

        LifetimeRearPTOHours = 338,

        EffectiveLoadingTime = 339,

        EffectiveUnloadingTime = 340,

        SetpointGrainKernelCrackerGap = 341,

        ActualGrainKernelCrackerGap = 342,

        MinimumGrainKernelCrackerGap = 343,

        MaximumGrainKernelCrackerGap = 344,

        SetpointSwathingWidth = 345,

        ActualSwathingWidth = 346,

        MinimumSwathingWidth = 347,

        MaximumSwathingWidth = 348,

        NozzleDriftReduction = 349,

        FunctionType = 350,

        ApplicationTotalVolumeinml = 351,

        ApplicationTotalMassingramg = 352,

        TotalApplicationofNitrogen = 353,

        TotalApplicationofAmmonium = 354,

        TotalApplicationofPhosphor = 355,

        TotalApplicationofPotassium = 356,

        TotalApplicationofDryMatter = 357,

        AverageDryYieldMassPerTime = 358,

        AverageDryYieldMassPerArea = 359,

        LastBaleSize = 360,

        LastBaleDensity = 361,

        TotalBaleLength = 362,

        LastBaleDryMass = 363,

        ActualFlakeSize = 364,

        SetpointDownforcePressure = 365,

        ActualDownforcePressure = 366,

        CondensedSectionOverrideState116 = 367,

        CondensedSectionOverrideState1732 = 368,

        CondensedSectionOverrideState3348 = 369,

        CondensedSectionOverrideState4964 = 370,

        CondensedSectionOverrideState145160 = 376,

        CondensedSectionOverrideState161176 = 377,

        CondensedSectionOverrideState177192 = 378,

        CondensedSectionOverrideState193208 = 379,

        CondensedSectionOverrideState209224 = 380,

        CondensedSectionOverrideState225240 = 381,

        CondensedSectionOverrideState241256 = 382,

        ApparentWindDirection = 383,

        ApparentWindSpeed = 384,

        MSLAtmosphericPressure = 385,

        ActualAtmosphericPressure = 386,

        TotalRevolutionsinFractionalRevolutions = 387,

        TotalRevolutionsinCompleteRevolutions = 388,

        SetpointRevolutionsspecifiedascountpertime = 389,

        ActualRevolutionsPerTime = 390,

        DefaultRevolutionsPerTime = 391,

        MinimumRevolutionsPerTime = 392,

        MaximumRevolutionsPerTime = 393,

        ActualFuelTankContent = 394,

        ActualDieselExhaustFluidTankContent = 395,

        SetpointSpeed = 396,

        ActualSpeed = 397,

        MinimumSpeed = 398,

        MaximumSpeed = 399,

        SpeedSource = 400,

        ActualApplicationofNitrogen = 401,

        ActualapplicationofAmmonium = 402,

        ActualapplicationofPhosphor = 403,

        ActualapplicationofPotassium = 404,

        ActualapplicationofDryMatter = 405,

        ActualProteinContent = 406,

        AverageProteinContent = 407,

        AverageCropContamination = 408,

        TotalDieselExhaustFluidConsumption = 409,

        InstantaneousDieselExhaustFluidConsumptionperTime = 410,

        InstantaneousDieselExhaustFluidConsumptionperArea = 411,

        LifetimeDieselExhaustFluidConsumption = 412,

        LifetimeAverageDieselExhaustFluidConsumptionperTime = 413,

        LifetimeAverageDieselExhaustFluidConsumptionperArea = 414,

        ActualSeedSingulationPercentage = 415,

        AverageSeedSingulationPercentage = 416,

        ActualSeedSkipPercentage = 417,

        AverageSeedSkipPercentage = 418,

        ActualSeedMultiplePercentage = 419,

        AverageSeedMultiplePercentage = 420,

        ActualSeedSpacingDeviation = 421,

        AverageSeedSpacingDeviation = 422,

        ActualCoefficientofVariationofSeedSpacingPercentage = 423,

        AverageCoefficientofVariationofSeedSpacingPercentage = 424,

        SetpointMaximumAllowedSeedSpacingDeviation = 425,

        SetpointDownforceasForce = 426,

        ActualDownforceasForce = 427,

        PGNBasedData = 57342,

    }
}