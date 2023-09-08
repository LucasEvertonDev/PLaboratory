﻿using Microsoft.AspNetCore.Mvc;
using MS.Libs.WebApi.Infrastructure.Helpers;
using System.Diagnostics.CodeAnalysis;

namespace MS.Libs.WebApi.Infrastructure.Attributes;

public class HttpGetParamsAttribute<TParams> : HttpGetAttribute where TParams : class
{
    public HttpGetParamsAttribute()
        : base(Params.GetRoute(typeof(TParams)))
    {

    }

    /// <summary>
    /// Creates a new <see cref="HttpGetAttribute"/> with the given route template.
    /// </summary>
    /// <param name="template">The route template. May not be null.</param>
    public HttpGetParamsAttribute([StringSyntax("Route")] string template)
        : base(Params.GetRoute(typeof(TParams), template))
    {

    }
}
