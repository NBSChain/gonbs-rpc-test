// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: rpcGetMessage.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Pb {
  public static partial class GetTask
  {
    static readonly string __ServiceName = "pb.GetTask";

    static readonly grpc::Marshaller<global::Pb.GetRequest> __Marshaller_pb_GetRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.GetRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.GetResponse> __Marshaller_pb_GetResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.GetResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Pb.GetRequest, global::Pb.GetResponse> __Method_Get = new grpc::Method<global::Pb.GetRequest, global::Pb.GetResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "Get",
        __Marshaller_pb_GetRequest,
        __Marshaller_pb_GetResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Pb.RpcGetMessageReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of GetTask</summary>
    public abstract partial class GetTaskBase
    {
      public virtual global::System.Threading.Tasks.Task Get(global::Pb.GetRequest request, grpc::IServerStreamWriter<global::Pb.GetResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for GetTask</summary>
    public partial class GetTaskClient : grpc::ClientBase<GetTaskClient>
    {
      /// <summary>Creates a new client for GetTask</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GetTaskClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for GetTask that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GetTaskClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GetTaskClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GetTaskClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::Pb.GetResponse> Get(global::Pb.GetRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Get(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Pb.GetResponse> Get(global::Pb.GetRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_Get, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GetTaskClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GetTaskClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GetTaskBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Get, serviceImpl.Get).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GetTaskBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Get, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Pb.GetRequest, global::Pb.GetResponse>(serviceImpl.Get));
    }

  }
}
#endregion
