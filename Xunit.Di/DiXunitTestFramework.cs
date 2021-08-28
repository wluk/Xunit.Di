﻿using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Di
{
    public sealed class DiXunitTestFramework: XunitTestFramework
    {
        public DiXunitTestFramework(IMessageSink messageSink) : base(messageSink)
        {
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
        {
            var serviceProvider = DiLoader.GetServiceProvider(assemblyName);
            return serviceProvider == null 
                ? base.CreateExecutor(assemblyName) 
                : new DiXunitTestFrameworkExecutor(serviceProvider, assemblyName, SourceInformationProvider, DiagnosticMessageSink);
        }
    }
}