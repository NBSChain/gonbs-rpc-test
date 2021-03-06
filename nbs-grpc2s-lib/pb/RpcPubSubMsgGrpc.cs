// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: rpcPubSubMsg.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Pb {
  public static partial class PubSubTask
  {
    static readonly string __ServiceName = "pb.PubSubTask";

    static readonly grpc::Marshaller<global::Pb.PublishRequest> __Marshaller_pb_PublishRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.PublishRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.PublishResponse> __Marshaller_pb_PublishResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.PublishResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.SubscribeRequest> __Marshaller_pb_SubscribeRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.SubscribeRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.SubscribeResponse> __Marshaller_pb_SubscribeResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.SubscribeResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.PeersRequest> __Marshaller_pb_PeersRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.PeersRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.PeersResponse> __Marshaller_pb_PeersResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.PeersResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.TopicsRequest> __Marshaller_pb_TopicsRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.TopicsRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.TopicsResponse> __Marshaller_pb_TopicsResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.TopicsResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Pb.PublishRequest, global::Pb.PublishResponse> __Method_Publish = new grpc::Method<global::Pb.PublishRequest, global::Pb.PublishResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Publish",
        __Marshaller_pb_PublishRequest,
        __Marshaller_pb_PublishResponse);

    static readonly grpc::Method<global::Pb.SubscribeRequest, global::Pb.SubscribeResponse> __Method_Subscribe = new grpc::Method<global::Pb.SubscribeRequest, global::Pb.SubscribeResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "Subscribe",
        __Marshaller_pb_SubscribeRequest,
        __Marshaller_pb_SubscribeResponse);

    static readonly grpc::Method<global::Pb.PeersRequest, global::Pb.PeersResponse> __Method_Peers = new grpc::Method<global::Pb.PeersRequest, global::Pb.PeersResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Peers",
        __Marshaller_pb_PeersRequest,
        __Marshaller_pb_PeersResponse);

    static readonly grpc::Method<global::Pb.TopicsRequest, global::Pb.TopicsResponse> __Method_Topics = new grpc::Method<global::Pb.TopicsRequest, global::Pb.TopicsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Topics",
        __Marshaller_pb_TopicsRequest,
        __Marshaller_pb_TopicsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Pb.RpcPubSubMsgReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PubSubTask</summary>
    public abstract partial class PubSubTaskBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Pb.PublishResponse> Publish(global::Pb.PublishRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task Subscribe(global::Pb.SubscribeRequest request, grpc::IServerStreamWriter<global::Pb.SubscribeResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Pb.PeersResponse> Peers(global::Pb.PeersRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Pb.TopicsResponse> Topics(global::Pb.TopicsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PubSubTask</summary>
    public partial class PubSubTaskClient : grpc::ClientBase<PubSubTaskClient>
    {
      /// <summary>Creates a new client for PubSubTask</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PubSubTaskClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PubSubTask that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PubSubTaskClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PubSubTaskClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PubSubTaskClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Pb.PublishResponse Publish(global::Pb.PublishRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Publish(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.PublishResponse Publish(global::Pb.PublishRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Publish, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.PublishResponse> PublishAsync(global::Pb.PublishRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PublishAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.PublishResponse> PublishAsync(global::Pb.PublishRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Publish, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Pb.SubscribeResponse> Subscribe(global::Pb.SubscribeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Subscribe(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Pb.SubscribeResponse> Subscribe(global::Pb.SubscribeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_Subscribe, null, options, request);
      }
      public virtual global::Pb.PeersResponse Peers(global::Pb.PeersRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Peers(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.PeersResponse Peers(global::Pb.PeersRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Peers, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.PeersResponse> PeersAsync(global::Pb.PeersRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PeersAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.PeersResponse> PeersAsync(global::Pb.PeersRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Peers, null, options, request);
      }
      public virtual global::Pb.TopicsResponse Topics(global::Pb.TopicsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Topics(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.TopicsResponse Topics(global::Pb.TopicsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Topics, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.TopicsResponse> TopicsAsync(global::Pb.TopicsRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return TopicsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.TopicsResponse> TopicsAsync(global::Pb.TopicsRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Topics, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override PubSubTaskClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PubSubTaskClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PubSubTaskBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Publish, serviceImpl.Publish)
          .AddMethod(__Method_Subscribe, serviceImpl.Subscribe)
          .AddMethod(__Method_Peers, serviceImpl.Peers)
          .AddMethod(__Method_Topics, serviceImpl.Topics).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PubSubTaskBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Publish, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.PublishRequest, global::Pb.PublishResponse>(serviceImpl.Publish));
      serviceBinder.AddMethod(__Method_Subscribe, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Pb.SubscribeRequest, global::Pb.SubscribeResponse>(serviceImpl.Subscribe));
      serviceBinder.AddMethod(__Method_Peers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.PeersRequest, global::Pb.PeersResponse>(serviceImpl.Peers));
      serviceBinder.AddMethod(__Method_Topics, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.TopicsRequest, global::Pb.TopicsResponse>(serviceImpl.Topics));
    }

  }
}
#endregion
