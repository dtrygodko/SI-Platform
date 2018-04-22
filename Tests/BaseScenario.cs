﻿using System;
using Abstractions.Bus;
using Abstractions.CQRS;
using Application;
using Autofac;
using DataAccess.Modules;
using Infrastructure;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public abstract class BaseScenario
    {
        public Exception Exception { get; private set; }

        protected abstract void Given();
        protected abstract void When();

        private IContainer _container;
        private ICommandBus _commandBus;
        private IRequestBus _requestBus;

        public IResponse Response { get; private set; }

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<TestDataAccessReadModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<TestDataAccessWriteModule>();

            _container = builder.Build();

            _requestBus = _container.Resolve<IRequestBus>();
            _commandBus = _container.Resolve<ICommandBus>();

            Given();

            When();
        }

        public T Resolve<T>() => _container.Resolve<T>();

        public async void SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                await _commandBus.ExecuteAsync(command);
            }
            catch (Exception e)
            {
                Exception = e;
            }
        }

        public async void SendRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : IResponse
        {
            try
            {
                Response = await _requestBus.RequestAsync<TRequest, TResponse>(request);
            }
            catch (Exception e)
            {
                Exception = e;
            }
        }
    }
}