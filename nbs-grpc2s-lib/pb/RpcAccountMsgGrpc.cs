// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: rpcAccountMsg.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Pb {
  public static partial class AccountTask
  {
    static readonly string __ServiceName = "pb.AccountTask";

    static readonly grpc::Marshaller<global::Pb.AccountRequest> __Marshaller_pb_AccountRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.AccountRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.AccountResponse> __Marshaller_pb_AccountResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.AccountResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.AccountUnlockRequest> __Marshaller_pb_AccountUnlockRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.AccountUnlockRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.AccountUnlockResponse> __Marshaller_pb_AccountUnlockResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.AccountUnlockResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.CreateAccountRequest> __Marshaller_pb_CreateAccountRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.CreateAccountRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Pb.CreateAccountResponse> __Marshaller_pb_CreateAccountResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Pb.CreateAccountResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Pb.AccountRequest, global::Pb.AccountResponse> __Method_Account = new grpc::Method<global::Pb.AccountRequest, global::Pb.AccountResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Account",
        __Marshaller_pb_AccountRequest,
        __Marshaller_pb_AccountResponse);

    static readonly grpc::Method<global::Pb.AccountUnlockRequest, global::Pb.AccountUnlockResponse> __Method_AccountUnlock = new grpc::Method<global::Pb.AccountUnlockRequest, global::Pb.AccountUnlockResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AccountUnlock",
        __Marshaller_pb_AccountUnlockRequest,
        __Marshaller_pb_AccountUnlockResponse);

    static readonly grpc::Method<global::Pb.CreateAccountRequest, global::Pb.CreateAccountResponse> __Method_CreateAccount = new grpc::Method<global::Pb.CreateAccountRequest, global::Pb.CreateAccountResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateAccount",
        __Marshaller_pb_CreateAccountRequest,
        __Marshaller_pb_CreateAccountResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Pb.RpcAccountMsgReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AccountTask</summary>
    public abstract partial class AccountTaskBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Pb.AccountResponse> Account(global::Pb.AccountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Pb.AccountUnlockResponse> AccountUnlock(global::Pb.AccountUnlockRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::Pb.CreateAccountResponse> CreateAccount(global::Pb.CreateAccountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for AccountTask</summary>
    public partial class AccountTaskClient : grpc::ClientBase<AccountTaskClient>
    {
      /// <summary>Creates a new client for AccountTask</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public AccountTaskClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for AccountTask that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public AccountTaskClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected AccountTaskClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected AccountTaskClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Pb.AccountResponse Account(global::Pb.AccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Account(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.AccountResponse Account(global::Pb.AccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Account, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.AccountResponse> AccountAsync(global::Pb.AccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AccountAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.AccountResponse> AccountAsync(global::Pb.AccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Account, null, options, request);
      }
      public virtual global::Pb.AccountUnlockResponse AccountUnlock(global::Pb.AccountUnlockRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AccountUnlock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.AccountUnlockResponse AccountUnlock(global::Pb.AccountUnlockRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AccountUnlock, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.AccountUnlockResponse> AccountUnlockAsync(global::Pb.AccountUnlockRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AccountUnlockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.AccountUnlockResponse> AccountUnlockAsync(global::Pb.AccountUnlockRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AccountUnlock, null, options, request);
      }
      public virtual global::Pb.CreateAccountResponse CreateAccount(global::Pb.CreateAccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAccount(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Pb.CreateAccountResponse CreateAccount(global::Pb.CreateAccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateAccount, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.CreateAccountResponse> CreateAccountAsync(global::Pb.CreateAccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAccountAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Pb.CreateAccountResponse> CreateAccountAsync(global::Pb.CreateAccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateAccount, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override AccountTaskClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new AccountTaskClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(AccountTaskBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Account, serviceImpl.Account)
          .AddMethod(__Method_AccountUnlock, serviceImpl.AccountUnlock)
          .AddMethod(__Method_CreateAccount, serviceImpl.CreateAccount).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AccountTaskBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Account, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.AccountRequest, global::Pb.AccountResponse>(serviceImpl.Account));
      serviceBinder.AddMethod(__Method_AccountUnlock, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.AccountUnlockRequest, global::Pb.AccountUnlockResponse>(serviceImpl.AccountUnlock));
      serviceBinder.AddMethod(__Method_CreateAccount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Pb.CreateAccountRequest, global::Pb.CreateAccountResponse>(serviceImpl.CreateAccount));
    }

  }
}
#endregion
