#pragma once

#if defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(_WIN64) || defined(WINAPI_FAMILY)
#define EXPORT_API __declspec(dllexport)
#else
#define EXPORT_API
#endif

#include "../../Fusion/FusionAhrs.h"
#include "../../Fusion/FusionAxes.h"
#include "../../Fusion/FusionCalibration.h"
#include "../../Fusion/FusionCompass.h"
#include "../../Fusion/FusionMath.h"
#include "../../Fusion/FusionOffset.h"

#include <stdlib.h>

EXPORT_API FusionEuler QuaternionToEuler(FusionQuaternion quaternion)
{
    return FusionQuaternionToEuler(quaternion);
}

EXPORT_API FusionAhrs* CreateAhrs()
{
    FusionAhrs* ahrs = (FusionAhrs*)malloc(sizeof(FusionAhrs));
    FusionAhrsInitialise(ahrs);
    return ahrs;
}

EXPORT_API void ReleaseAhrs(FusionAhrs* ahrs)
{
    free(ahrs);
}

EXPORT_API void UpdateNoMagnetometer(FusionAhrs* ahrs, FusionVector gyroscope, FusionVector accelerometer, float deltaTime)
{
    FusionAhrsUpdateNoMagnetometer(ahrs, gyroscope, accelerometer, deltaTime);
}

EXPORT_API FusionQuaternion GetQuaternion(FusionAhrs* ahrs)
{
    return FusionAhrsGetQuaternion(ahrs);
}

EXPORT_API FusionVector GetEarthAcceleration(FusionAhrs* ahrs)
{
    return FusionAhrsGetEarthAcceleration(ahrs);
}

EXPORT_API FusionAhrsSettings* CreateAhrsSettings(float gain, float accelerationRejection, float magneticRejection, unsigned int rejectionTimeout)
{
    FusionAhrsSettings* ahrsSettings = (FusionAhrsSettings*)malloc(sizeof(FusionAhrsSettings));

    ahrsSettings->gain = gain;
    ahrsSettings->accelerationRejection = accelerationRejection;
    ahrsSettings->magneticRejection = magneticRejection;
    ahrsSettings->rejectionTimeout = rejectionTimeout;

    return ahrsSettings;
}

EXPORT_API void ReleaseAhrsSettings(FusionAhrsSettings* ahrsSettings)
{
    free(ahrsSettings);
}

EXPORT_API void SetAhrsSettings(FusionAhrs* ahrs, FusionAhrsSettings* ahrsSettings)
{
    FusionAhrsSetSettings(ahrs, ahrsSettings);
}

EXPORT_API FusionOffset* CreateOffset(unsigned int sampleRate)
{
    FusionOffset* offset = (FusionOffset*)malloc(sizeof(FusionOffset));
    FusionOffsetInitialise(offset, sampleRate);
    return offset;
}

EXPORT_API void ReleaseOffset(FusionOffset* offset)
{
    free(offset);
}

EXPORT_API FusionVector OffsetUpdate(FusionOffset* offset, FusionVector gyroscope)
{
    return FusionOffsetUpdate(offset, gyroscope);
}