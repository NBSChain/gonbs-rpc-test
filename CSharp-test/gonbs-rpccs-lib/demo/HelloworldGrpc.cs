// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: pb/helloworld.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Demo {
  public static partial class Greeter
  {
    static readonly string __ServiceName = "demo.Greeter";

    static readonly grpc::Marshaller<global::Demo.HelloRequest> __Marshaller_demo_HelloRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Demo.HelloRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Demo.HelloReply> __Marshaller_demo_HelloReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Demo.HelloReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Demo.HelloRequest, global::Demo.HelloReply> __Method_SayHello = new grpc::Method<global::Demo.HelloRequest, global::Demo.HelloReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_demo_HelloRequest,
        __Marshaller_demo_HelloReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Demo.HelloworldReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Greeter</summary>
    public abstract partial class GreeterBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Demo.HelloReply> SayHello(global::Demo.HelloRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for Greeter</summary>
    public partial class GreeterClient : grpc::ClientBase<GreeterClient>
    {
      /// <summary>Creates a new client for Greeter</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GreeterClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Greeter that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GreeterClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GreeterClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GreeterClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Demo.HelloReply SayHello(global::Demo.HelloRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHello(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Demo.HelloReply SayHello(global::Demo.HelloRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SayHello, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Demo.HelloReply> SayHelloAsync(global::Demo.HelloRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHelloAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Demo.HelloReply> SayHelloAsync(global::Demo.HelloRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SayHello, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GreeterClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GreeterClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GreeterBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GreeterBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Demo.HelloRequest, global::Demo.HelloReply>(serviceImpl.SayHello));
    }

  }
}
#endregion
