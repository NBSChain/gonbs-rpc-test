// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: pb/rpcVersionMsg.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Pb {
  public static partial class VersionTask
  {
    static readonly string __ServiceName = "pb.VersionTask";

    static readonly grpc::Marshaller<global::Pb.VersionRequest> __Marshaller_pb_VersionRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.VersionRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.VersionResponse> __Marshaller_pb_VersionResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.VersionResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Pb.VersionRequest, global::Pb.VersionResponse> __Method_SystemVersion = new grpc::Method<global::Pb.VersionRequest, global::Pb.VersionResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SystemVersion",
        __Marshaller_pb_VersionRequest,
        __Marshaller_pb_VersionResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Pb.RpcVersionMsgReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of VersionTask</summary>
    public abstract partial class VersionTaskBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Pb.VersionResponse> SystemVersion(global::Pb.VersionRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for VersionTask</summary>
    public partial class VersionTaskClient : grpc::ClientBase<VersionTaskClient>
    {
      /// <summary>Creates a new client for VersionTask</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public VersionTaskClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for VersionTask that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public VersionTaskClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected VersionTaskClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected VersionTaskClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Pb.VersionResponse SystemVersion(global::Pb.VersionRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SystemVersion(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.VersionResponse SystemVersion(global::Pb.VersionRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SystemVersion, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.VersionResponse> SystemVersionAsync(global::Pb.VersionRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SystemVersionAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.VersionResponse> SystemVersionAsync(global::Pb.VersionRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SystemVersion, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override VersionTaskClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new VersionTaskClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(VersionTaskBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SystemVersion, serviceImpl.SystemVersion).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, VersionTaskBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SystemVersion, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.VersionRequest, global::Pb.VersionResponse>(serviceImpl.SystemVersion));
    }

  }
}
#endregion