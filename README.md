# Chargify API V2 .NET Wrapper [![Build status](https://ci.appveyor.com/api/projects/status/x937xtx3qwv78kkx/branch/master?svg=true)](https://ci.appveyor.com/project/kfrancis/chargify2/branch/master)
============================

* Chargify2: [![NuGet downloads](https://img.shields.io/nuget/dt/chargify2.svg)](http://www.nuget.org/packages/chargify2) [![NuGet version](https://img.shields.io/nuget/v/chargify2.svg)](http://www.nuget.org/packages/chargify2)

This library is meant to be used with the [Chargify Direct API](http://docs.chargify.com/chargify-direct-introduction).

You'll need Chargify Direct credentials to interact with the Chargify V2 API, which you can get by generating credentials within your site settings.

Getting Started
---------------

Install the nuget:
    
    Install-Package chargify2

Sample Code
-----------

Check out the [Chargify Direct .NET Sample](https://github.com/kfrancis/ChargifyDirectSampleDotNet) for usage examples.

View a *call* resource:

``` c#
chargify = new Chargify2.Client(api_id: "f43ee0a0-4356-012e-0f5f-0025009f114a", api_password: "direct777test", api_secret: "supersecret" );
call = chargify.ReadCall("4dbc42ecc21d93ec8f9bb581346dd41c5c3c2cf5");
```

Contributing
------------

**What to contribute:**

* Check out the project's [issues page](https://github.com/kfrancis/Chargify2/issues)
* Refactor something that looks messy to you!

**How to contribute:**

* Fork the project.
* Implement your feature on a topic branch.
* Add tests for it.  This is important so we don't break it in a future version unintentionally.
* Commit, do not mess with the nuspec, version, or history.  If you want to have your own version, that's fine but bump version in a commit by itself that we can ignore when we pull.
* Send us a pull request.
 
Copyright
---------

Copyright (c) 2013 Kori Francis, See LICENSE.txt for further details.
