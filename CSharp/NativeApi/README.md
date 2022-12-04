# Native API for ImuFusion

## Build (Windows)
- Start `x64 Native Tools Command Prompt for VS 2022`.
- Go the `Fusion/CSharp/NativeApi` directory.
- Run cmake and `build.cmd` from the command line.

```
> cmake -B ./build -G "Visual Studio 17 2022"
> build.cmd
```
```
> copy /Y build\Release\ImuFusion.Native.dll  ..\Examples\Libs\x64
```