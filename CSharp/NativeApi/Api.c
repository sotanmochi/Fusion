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

EXPORT_API FusionEuler QuaternionToEuler(FusionQuaternion quaternion)
{
    return FusionQuaternionToEuler(quaternion);
}