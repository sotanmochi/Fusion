# Set the project name and version
project(ImuFusion.Native LANGUAGES C)
set(PROJECT_VERSION 1.0.0)

# Set source files
set(LIB_SOURCE_FILES
    ./Api.c
    ../../Fusion/FusionAhrs.c
    ../../Fusion/FusionCompass.c
    ../../Fusion/FusionOffset.c
)

# Targets
# Add a dynamic link library
add_library(ImuFusion.Native SHARED ${LIB_SOURCE_FILES})