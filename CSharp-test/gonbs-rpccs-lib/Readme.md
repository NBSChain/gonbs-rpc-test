# gonbs-rpccs-lib
  an go-nbs gRPC C# library
## dependency install
	use Nuget

## lib info
	protobuf version 3.7.0
	grpc version  1.19.0


## generated cs code

packages\Grpc.Tools.1.19.0\tools\windows_x64\protoc.exe -Igonbs-rpccs-lib --csharp_out gonbs-rpccs-lib\pb --grpc_out gonbs-rpccs-lib\pb --plugin=protoc-gen-grpc=packages\Grpc.Tools.1.19.0\tools\windows_x64\grpc_csharp_plugin.exe gonbs-rpccs-lib\pb\rpcVersionMsg.proto
