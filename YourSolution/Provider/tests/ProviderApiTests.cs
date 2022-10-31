using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
// using tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;

namespace tests;

public class ProviderApiTests : IDisposable
{
    private string _providerUri { get; }
    private string _pactServiceUri { get; }
    private IWebHost _webHost { get; }
    private ITestOutputHelper _outputHelper { get; }

    public ProviderApiTests(ITestOutputHelper output)
    {
        _outputHelper = output;
        _providerUri = "http://localhost:9000";
        _pactServiceUri = "http://localhost:9001";

        _webHost = WebHost.CreateDefaultBuilder()
            .UseUrls(_pactServiceUri)
            .UseStartup<TestStartup>()
            .Build();

        _webHost.Start();
    }

    [Fact]
    public void EnsureProviderApiHonoursPactWithConsumer()
    {
    }

    #region IDisposable Support
    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _webHost.StopAsync().GetAwaiter().GetResult();
                _webHost.Dispose();
            }

            disposedValue = true;
        }
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
    }
    #endregion
}
