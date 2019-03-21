// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: rpcNatMsg.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Pb {
  public static partial class NatTask
  {
    static readonly string __ServiceName = "pb.NatTask";

    static readonly grpc::Marshaller<global::Pb.NatStatusResQuest> __Marshaller_pb_NatStatusResQuest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.NatStatusResQuest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.NatStatusResponse> __Marshaller_pb_NatStatusResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.NatStatusResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Pb.NatStatusResQuest, global::Pb.NatStatusResponse> __Method_NatStatus = new grpc::Method<global::Pb.NatStatusResQuest, global::Pb.NatStatusResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "NatStatus",
        __Marshaller_pb_NatStatusResQuest,
        __Marshaller_pb_NatStatusResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Pb.RpcNatMsgReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of NatTask</summary>
    public abstract partial class NatTaskBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Pb.NatStatusResponse> NatStatus(global::Pb.NatStatusResQuest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for NatTask</summary>
    public partial class NatTaskClient : grpc::ClientBase<NatTaskClient>
    {
      /// <summary>Creates a new client for NatTask</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public NatTaskClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for NatTask that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public NatTaskClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected NatTaskClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected NatTaskClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Pb.NatStatusResponse NatStatus(global::Pb.NatStatusResQuest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return NatStatus(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.NatStatusResponse NatStatus(global::Pb.NatStatusResQuest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_NatStatus, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.NatStatusResponse> NatStatusAsync(global::Pb.NatStatusResQuest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return NatStatusAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.NatStatusResponse> NatStatusAsync(global::Pb.NatStatusResQuest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_NatStatus, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override NatTaskClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new NatTaskClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(NatTaskBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_NatStatus, serviceImpl.NatStatus).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, NatTaskBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_NatStatus, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.NatStatusResQuest, global::Pb.NatStatusResponse>(serviceImpl.NatStatus));
    }

  }
}
#endregion
